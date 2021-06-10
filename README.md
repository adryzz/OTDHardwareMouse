# Hardware mouse spoofing for [OpenTabletDriver](https://github.com/OpenTabletDriver/OpenTabletDriver)

[![Total Download Count](https://img.shields.io/github/downloads/adryzz/OTDHardwareMouse/total.svg)](https://github.com/adryzz/OTDHardwareMouse/releases)

## Why hardware mouse?
This was made primarily to get around limitations of some anti-cheat software (especially **Vanguard**) as they make [VMulti](https://github.com/X9VoiD/VoiDPlugins#vmultimode) input unreliable for tablet users.

This is **NOT** intended for cheating **in any way**, but set this up at your own risk.

You are the only responsible for bans related to anti-cheat updates detecting this as a cheat.

## Installation guide
Go to the [wiki](https://github.com/adryzz/OTDHardwareMouse/wiki) to learn how to set this up.

## How this works

This is an [OpenTabletDriver](https://github.com/OpenTabletDriver/OpenTabletDriver) plugin, that sends the input to a hardware device through a USB serial port.

The hardware device will be recognized as a physical mouse, allowing you to control the pointer/buttons that way.

## Building
### Requirements:
* .NET 5 SDK

### All platforms:
`dotnet build -c Release`

## Contributing
Contributions are welcome!
If you wish to contribute, [open an issue ticket](https://github.com/adryzz/OTDHardwareMouse/issues/new) before working on the contribution, so that we don't waste time making pull requests that won't get merged.
