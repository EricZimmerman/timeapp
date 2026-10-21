# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

TimeApp (`timeapp/timeapp.csproj`, WinForms, no DevExpress; `net48` (the download: on every supported Windows) and `net10.0-windows`): local and UTC time to the microsecond, a stopwatch, a countdown, the public IP addresses, and a timestamp converter.

- Stopwatch and countdown use `System.Diagnostics.Stopwatch` (not the wall clock or tick counts). The countdown shows in the title, and at 0 plays a sound and flashes the taskbar button.
- `TimestampConverter`: a number as Unix seconds/ms/µs, FILETIME, WebKit, Cocoa, OLE date, or hex as FILETIME (value, and bytes in file order); only times from 1980 to 2100 are shown. Built in code (`Form1.BuildConverterTab`), like the time tab's layout (`LayOutTimeTab`: from the labels' sizes, for Per-Monitor V2 on .NET 10).
- Keep the `net48` build a single exe: no packages for it (no binary resources in resx files: they need System.Resources.Extensions under the .NET SDK; the form icon is read from the exe).

## Commands

```bash
dotnet build timeapp.slnx -c Release
```

Debug symbols: embedded portable pdbs and, for Release, `ContinuousIntegrationBuild` (source paths `/_/...`) are set in `Directory.Build.props` (Eric, 2026-10-20: stack traces and Exceptionless reports get file and line numbers); no pdb file ships. Don't add `DebugType` or `DebugSymbols` to the project files.

## Versioning and release

`<Version>` in the csproj, bumped by hand. Eric builds, signs and releases.
- Release builds are staged, signed and zipped by `Build-ZimmermanTools.ps1` in the get-zimmermantools repository (cloned next to this one). Its program table says what goes in this tool's download zip (the files taken from the build, folders copied from the repositories, files kept from the current release zip); a new output file, a content folder or a change in how the tool is built (single file, another framework) needs that entry updated.
