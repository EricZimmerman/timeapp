using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace timeapp
{
    /// <summary>
    ///     What a number could be as a time stamp: the common forensic formats, as UTC
    /// </summary>
    public sealed class Interpretation
    {
        public Interpretation(string format, DateTimeOffset time)
        {
            Format = format;
            Time = time;
        }

        public string Format { get; }
        public DateTimeOffset Time { get; }
    }

    public static class TimestampConverter
    {
        //times outside 1980 to 2100 are not shown (a number is plausible as only some of the formats; small numbers read as milliseconds or microseconds were all 1970)
        private static readonly DateTimeOffset Earliest = new DateTimeOffset(1980, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset Latest = new DateTimeOffset(2100, 1, 1, 0, 0, 0, TimeSpan.Zero);

        private static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset FileTimeEpoch = new DateTimeOffset(1601, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset CocoaEpoch = new DateTimeOffset(2001, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static readonly DateTimeOffset OleEpoch = new DateTimeOffset(1899, 12, 30, 0, 0, 0, TimeSpan.Zero);

        public const string Format = "yyyy-MM-dd HH:mm:ss.fffffff";

        /// <summary>
        ///     The time stamp formats <paramref name="input" /> is a plausible time in (1980 to 2100), as (format, UTC time)
        /// </summary>
        /// <remarks>
        ///     Decimal: Unix seconds, milliseconds and microseconds, Windows FILETIME, WebKit/Chrome, Mac (Cocoa) seconds;
        ///     with a fraction: OLE automation date, Unix and Cocoa seconds. Hex (0x... or 16 hex digits, spaces allowed):
        ///     FILETIME as a number, and from bytes in file order (little endian, as a hex editor shows them)
        /// </remarks>
        public static List<Interpretation> Interpret(string input)
        {
            var results = new List<Interpretation>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return results;
            }

            var text = input.Trim();
            var compact = new string(text.Where(c => !char.IsWhiteSpace(c) && c != '-' && c != ':').ToArray());

            var isHex = compact.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ||
                        compact.Length == 16 && compact.All(Uri.IsHexDigit) && compact.Any(c => !char.IsDigit(c)) ||
                        text.Contains(' ') && compact.Length == 16 && compact.All(Uri.IsHexDigit);

            if (isHex)
            {
                var hex = compact.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? compact.Substring(2) : compact;

                if (hex.Length > 0 && hex.Length <= 16 && hex.All(Uri.IsHexDigit))
                {
                    var value = ulong.Parse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                    Add(results, "FILETIME (hex value)", () => FileTimeEpoch.AddTicks(checked((long) value)));

                    if (hex.Length == 16)
                    {
                        //the bytes as they are in a file: reversed
                        var bytes = Enumerable.Range(0, 8).Select(i => Convert.ToByte(hex.Substring(i * 2, 2), 16)).Reverse();
                        var le = bytes.Aggregate(0UL, (acc, b) => (acc << 8) | b);
                        Add(results, "FILETIME (hex bytes, little endian)", () => FileTimeEpoch.AddTicks(checked((long) le)));
                    }
                }

                return results;
            }

            if (long.TryParse(text, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var n))
            {
                Add(results, "Unix seconds", () => UnixEpoch.AddSeconds(n));
                Add(results, "Unix milliseconds", () => UnixEpoch.AddMilliseconds(n));
                Add(results, "Unix microseconds", () => UnixEpoch.AddTicks(checked(n * 10)));
                Add(results, "Windows FILETIME", () => FileTimeEpoch.AddTicks(n));
                Add(results, "WebKit/Chrome (microseconds since 1601)", () => FileTimeEpoch.AddTicks(checked(n * 10)));
                Add(results, "Mac absolute time (Cocoa seconds)", () => CocoaEpoch.AddSeconds(n));
                return results;
            }

            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var d))
            {
                Add(results, "OLE automation date (days)", () => OleEpoch.AddDays(d));
                Add(results, "Unix seconds", () => UnixEpoch.AddSeconds(d));
                Add(results, "Mac absolute time (Cocoa seconds)", () => CocoaEpoch.AddSeconds(d));
            }

            return results;
        }

        private static void Add(List<Interpretation> results, string format, Func<DateTimeOffset> time)
        {
            try
            {
                var t = time();
                if (t >= Earliest && t < Latest)
                {
                    results.Add(new Interpretation(format, t));
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (OverflowException)
            {
            }
        }

        /// <summary>
        ///     <paramref name="time" /> in each format, for the Now line
        /// </summary>
        public static string Now(DateTimeOffset time)
        {
            var unix = time.ToUnixTimeSeconds();
            var ft = time.ToFileTime();
            return $"Unix {unix}   FILETIME 0x{ft:X16}   WebKit {(time - FileTimeEpoch).Ticks / 10}   Cocoa {(long) (time - CocoaEpoch).TotalSeconds}";
        }
    }
}
