using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace timeapp
{
    public partial class Form1 : Form
    {
        private const string Title = "The time, and more!";

        //(the elapsed time came from the wall clock, so a clock or daylight saving change moved it; Stop and Start
        //started again from 0)
        private readonly Stopwatch _stopwatch = new Stopwatch();

        //the countdown: its length, and the time it has run (it subtracted the timer interval at each tick, which
        //drifted: ticks come late)
        private TimeSpan? _cdLength;
        private readonly Stopwatch _cdRunning = new Stopwatch();
        private bool _cdDone;

        private static readonly HttpClient Http = new HttpClient {Timeout = TimeSpan.FromSeconds(15)};

        private TabPage _tpConverter;
        private TextBox _txtConvert;
        private ListBox _lstConverted;
        //the current time in each format, a box each: only a value that changed is drawn again (one label for all of
        //them was drawn again at every tick, and flickered: Issues #251)
        private Label[] _nowValues;

        public Form1()
        {
            InitializeComponent();

            //the program's own icon (it was a copy in Form1.resx: binary resources need extra libraries under the .NET SDK)
            try
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Title;

            BuildConverterTab();

            LayOutTimeTab();

            tcMain.SelectedIndexChanged += (ss, ee) =>
            {
                timer1.Enabled = tcMain.SelectedTab == tpTime || tcMain.SelectedTab == _tpConverter;
                UpdateNow();
            };

            lblStatus.Text = string.Empty;
            lblIPAddress4.Text = string.Empty;
            lblIPAddress6.Text = string.Empty;

            ckTopMost.CheckedChanged += (ss, ee) => { TopMost = ckTopMost.Checked; };

            ckGetPublicIp.CheckedChanged += async (ss, ee) =>
            {
                lblIPAddress4.Text = string.Empty;
                lblIPAddress6.Text = string.Empty;
                lblStatus.Text = string.Empty;

                if (!ckGetPublicIp.Checked)
                {
                    return;
                }

                //(HTTPS; WebClient over HTTP before. The address has a line break at its end)
                try
                {
                    var ip4 = (await Http.GetStringAsync("https://ipv4.icanhazip.com")).Trim();
                    lblIPAddress4.Text = $"Public IPv4 address:\r\n{ip4}";
                }
                catch (Exception exception)
                {
                    lblStatus.Text = $"Error getting IPv4: {exception.Message}";
                }

                try
                {
                    var ip6 = (await Http.GetStringAsync("https://ipv6.icanhazip.com")).Trim();
                    lblIPAddress6.Text = $"Public IPv6 address:\r\n{ip6}";
                }
                catch (Exception exception)
                {
                    lblStatus.Text += $"\r\nNo public IPv6 address ({exception.Message})";
                }
            };

            FormClosing += (ss, ee) =>
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    ee.Cancel = true;
                }
            };

            //the stopwatch: Stop pauses, Start goes on, Reset while running starts again from 0
            btnStartSw.Click += (ss, ee) =>
            {
                _stopwatch.Start();
                timerSw.Start();
                btnStartSw.Enabled = false;
                btnStopSw.Enabled = true;
            };

            btnResetSw.Click += (ss, ee) =>
            {
                if (_stopwatch.IsRunning)
                {
                    _stopwatch.Restart();
                }
                else
                {
                    _stopwatch.Reset();
                }

                ShowElapsed();
            };

            btnStopSw.Click += (ss, ee) =>
            {
                _stopwatch.Stop();
                timerSw.Stop();
                ShowElapsed();
                btnStartSw.Enabled = true;
                btnStopSw.Enabled = false;
            };

            timerSw.Tick += (ss, ee) => ShowElapsed();

            //the countdown
            btnStartCd.Click += (ss, ee) =>
            {
                if (_cdLength == null)
                {
                    _cdLength = new TimeSpan((int) numDays.Value, (int) numHours.Value, (int) numMins.Value, (int) numSecs.Value);
                    _cdRunning.Reset();
                    _cdDone = false;
                }

                _cdRunning.Start();
                timerCountdown.Start();
                btnStartCd.Enabled = false;
                btnStopCd.Enabled = true;
                panelSettings.Visible = false;
                ShowCountdown();
            };

            btnResetCd.Click += (ss, ee) =>
            {
                btnStopCd.PerformClick();

                _cdLength = null;
                _cdRunning.Reset();
                _cdDone = false;

                lblCountdown.Text = "0";
                lblCountdown.ForeColor = SystemColors.ControlText;
                Text = Title;
            };

            btnStopCd.Click += (ss, ee) =>
            {
                _cdRunning.Stop();
                timerCountdown.Stop();
                btnStartCd.Enabled = true;
                btnStopCd.Enabled = false;
                panelSettings.Visible = true;
            };

            timerCountdown.Tick += (ss, ee) => ShowCountdown();

            timer1.Tick += (ss, ee) =>
            {
                if (tcMain.SelectedTab == _tpConverter)
                {
                    UpdateNow();
                    return;
                }

                var now = DateTimeOffset.Now;
                lblLocalTime.Text = now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zzz");
                lblUTCTime.Text = now.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss.ffffff zzz");
            };

            //the times change at every tick: drawn off screen, so they don't flicker (as the converter's Now values)
            foreach (var label in new[] {lblLocalTime, lblUTCTime, lblElapsed, lblCountdown})
            {
                SetDoubleBuffered(label);
            }

            //double click a time: copied
            foreach (var label in new[] {lblLocalTime, lblUTCTime, lblElapsed, lblCountdown, lblIPAddress4, lblIPAddress6})
            {
                label.DoubleClick += (ss, ee) => Copy(((Label) ss).Text.Replace("Public IPv4 address:\r\n", "").Replace("Public IPv6 address:\r\n", ""));
            }

            toolTip1.SetToolTip(lblLocalTime, "Double-click to copy");
            toolTip1.SetToolTip(lblUTCTime, "Double-click to copy");
        }

        /// <summary>
        ///     The time tab laid out from the labels' real sizes, and the window wide enough for them (the fixed positions
        ///     overlapped and cut the time off when the fonts scaled for the monitor)
        /// </summary>
        private void LayOutTimeTab()
        {
            var sample = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff zzz");
            lblLocalTime.Text = sample;
            lblUTCTime.Text = sample;

            var gap = label2.Font.Height / 3;
            var valueLeft = Math.Max(label2.Right, label3.Right) + gap;

            lblLocalTime.Left = valueLeft;
            lblUTCTime.Left = valueLeft;
            lblLocalTime.Top = label2.Top;
            label3.Top = label2.Bottom;
            lblUTCTime.Top = label3.Top;

            var neededWidth = Math.Max(lblLocalTime.Right, lblUTCTime.Right) + gap;
            var neededHeight = lblUTCTime.Bottom + gap / 2;

            var growX = Math.Max(0, neededWidth - tpTime.ClientSize.Width);
            var growY = Math.Max(0, neededHeight - tpTime.ClientSize.Height);

            if (growX > 0 || growY > 0)
            {
                MinimumSize = new Size(MinimumSize.Width + growX, MinimumSize.Height + growY);
                ClientSize = new Size(ClientSize.Width + growX, ClientSize.Height + growY);
            }
        }

        private void ShowElapsed()
        {
            lblElapsed.Text = _stopwatch.Elapsed.ToString(@"d\.hh\:mm\:ss\.ff");
        }

        private void ShowCountdown()
        {
            if (_cdLength == null)
            {
                return;
            }

            var remaining = _cdLength.Value - _cdRunning.Elapsed;

            if (remaining > TimeSpan.Zero)
            {
                //(rounded up: 0.4 s left shows 1 s)
                var shown = TimeSpan.FromSeconds(Math.Ceiling(remaining.TotalSeconds));
                lblCountdown.Text = shown.ToString(@"d\.hh\:mm\:ss");
                lblCountdown.ForeColor = SystemColors.ControlText;
                Text = $"{lblCountdown.Text} - {Title}";
            }
            else
            {
                var over = TimeSpan.FromSeconds(Math.Floor(-remaining.TotalSeconds));
                lblCountdown.Text = over.ToString(@"\-d\.hh\:mm\:ss");
                lblCountdown.ForeColor = Color.Red;
                Text = $"Time's up! {lblCountdown.Text} - {Title}";

                if (!_cdDone)
                {
                    //once, when it reaches 0: a sound, and the taskbar button flashes until the window is used
                    _cdDone = true;
                    SystemSounds.Exclamation.Play();
                    Flash();
                }
            }
        }

        private void Copy(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            try
            {
                Clipboard.SetText(text.Trim());
            }
            catch (ExternalException)
            {
                //the clipboard is in use
            }
        }

        /// <summary>
        ///     The timestamp converter tab: a number or hex value as Unix, FILETIME, WebKit, Cocoa and OLE times
        /// </summary>
        private void BuildConverterTab()
        {
            var mono = new Font("Consolas", 9.75F);

            _tpConverter = new TabPage("Timestamp converter") {UseVisualStyleBackColor = true, Padding = new Padding(3)};

            var top = new FlowLayoutPanel {Dock = DockStyle.Top, AutoSize = true, WrapContents = false};
            _txtConvert = new TextBox {Font = mono, Width = TextRenderer.MeasureText(new string('0', 30), mono).Width};
            var hint = new Label
            {
                AutoSize = true,
                Font = mono,
                ForeColor = SystemColors.GrayText,
                Text = "a number (Unix, FILETIME, WebKit, Cocoa, OLE) or hex FILETIME bytes",
                Margin = new Padding(6, 6, 3, 3)
            };
            top.Controls.Add(_txtConvert);
            top.Controls.Add(hint);

            var now = new FlowLayoutPanel {Dock = DockStyle.Bottom, AutoSize = true, WrapContents = true, Padding = new Padding(0, 3, 0, 0)};
            _nowValues = new Label[TimestampConverter.NowNames.Length];
            for (var i = 0; i < _nowValues.Length; i++)
            {
                var name = TimestampConverter.NowNames[i];
                now.Controls.Add(new Label {AutoSize = true, Text = name, ForeColor = SystemColors.GrayText, Margin = new Padding(i == 0 ? 0 : 9, 6, 0, 3)});
                var value = new Label {AutoSize = true, Font = mono, BorderStyle = BorderStyle.FixedSingle, Padding = new Padding(2), Margin = new Padding(3, 3, 3, 3)};
                SetDoubleBuffered(value);
                toolTip1.SetToolTip(value, $"Now as {name}. Double-click to copy");
                value.DoubleClick += (ss, ee) => Copy(((Label) ss).Text);
                _nowValues[i] = value;
                now.Controls.Add(value);
            }

            _lstConverted = new ListBox {Dock = DockStyle.Fill, Font = mono, IntegralHeight = false, BorderStyle = BorderStyle.None};
            toolTip1.SetToolTip(_lstConverted, "Double-click a line to copy its time");
            _lstConverted.DoubleClick += (ss, ee) =>
            {
                if (_lstConverted.SelectedItem is string line)
                {
                    Copy(line.Substring(0, Math.Min(line.Length, TimestampConverter.Format.Length)));
                }
            };

            _tpConverter.Controls.Add(_lstConverted);
            _tpConverter.Controls.Add(now);
            _tpConverter.Controls.Add(top);

            _txtConvert.TextChanged += (ss, ee) =>
            {
                _lstConverted.BeginUpdate();
                _lstConverted.Items.Clear();

                foreach (var r in TimestampConverter.Interpret(_txtConvert.Text))
                {
                    _lstConverted.Items.Add($"{r.Time.UtcDateTime.ToString(TimestampConverter.Format)} UTC   {r.Format}");
                }

                if (_lstConverted.Items.Count == 0 && _txtConvert.Text.Trim().Length > 0)
                {
                    _lstConverted.Items.Add("(not a time from 1980 to 2100 in any of the formats)");
                }

                _lstConverted.EndUpdate();
            };

            //before Options
            tcMain.TabPages.Insert(tcMain.TabPages.IndexOf(tpOptions), _tpConverter);
        }

        private void UpdateNow()
        {
            if (_nowValues != null && tcMain.SelectedTab == _tpConverter)
            {
                var values = TimestampConverter.NowValues(DateTimeOffset.UtcNow);
                for (var i = 0; i < values.Length; i++)
                {
                    //(setting the same text draws it again too)
                    if (_nowValues[i].Text != values[i])
                    {
                        _nowValues[i].Text = values[i];
                    }
                }
            }
        }

        /// <summary>
        ///     Draws <paramref name="control" /> off screen first, so a label whose text changes many times a second
        ///     doesn't flicker (its background was drawn, then the text). DoubleBuffered is protected: set by reflection
        /// </summary>
        private static void SetDoubleBuffered(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(control, true, null);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        ///     The window and its taskbar button flash until the window is brought to the front
        /// </summary>
        private void Flash()
        {
            const uint FLASHW_ALL = 3;
            const uint FLASHW_TIMERNOFG = 12;

            var info = new FLASHWINFO
            {
                cbSize = (uint) Marshal.SizeOf<FLASHWINFO>(),
                hwnd = Handle,
                dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG,
                uCount = uint.MaxValue,
                dwTimeout = 0
            };

            FlashWindowEx(ref info);
        }
    }
}
