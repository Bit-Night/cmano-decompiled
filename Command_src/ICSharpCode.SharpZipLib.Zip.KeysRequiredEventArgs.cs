using System;

namespace ICSharpCode.SharpZipLib.Zip;

public class KeysRequiredEventArgs : EventArgs
{
	private readonly string string_0;

	private byte[] byte_0;

	public string FileName => string_0;

	public byte[] Key
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public KeysRequiredEventArgs(string name)
	{
		string_0 = name;
	}

	public KeysRequiredEventArgs(string name, byte[] keyValue)
	{
		string_0 = name;
		byte_0 = keyValue;
	}

	static KeysRequiredEventArgs()
	{
		Class72.smethod_20();
	}
}
