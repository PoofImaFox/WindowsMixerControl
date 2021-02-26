# WindowsMixerControl
This is an interface to the native mixer control API inside of winmm.dll. It is nice and simple and to the point with no bloat. This must be used inside of a 64bit (x64 arch) program to work correctly. I have documented the code with docs found on Microsoft for their API. [Microsoft Docs](https://docs.microsoft.com/en-us/windows/win32/multimedia/audio-mixer-reference)

# Example usage:
Mute all input devices;  
```cs
	var deviceComponent = MixerLineInfoComponentType.Wavein;
	WindowsMixer.MuteAllDevices(deviceComponent);
```

Enumerate all Input devices;
```cs
	var deviceComponent = MixerLineInfoComponentType.Wavein;
	var inputDevices = WindowsMixer.FindAllDevices(deviceComponent).ToArray();

	var deviceEnumeration = string.Join("\n", inputDevices.Select(i =>
     		i.SourceMixerLineInfo.target.productName));

	Console.WriteLine(deviceEnumeration);
```
