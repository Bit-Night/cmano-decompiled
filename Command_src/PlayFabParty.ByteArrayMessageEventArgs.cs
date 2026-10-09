using System;
using System.Runtime.CompilerServices;

namespace PlayFabParty;

public class ByteArrayMessageEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly uint uint_0;

	[CompilerGenerated]
	private readonly byte[] byte_0;

	public uint SenderId
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
	}

	public byte[] Message
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
	}

	public ByteArrayMessageEventArgs(uint senderId, byte[] message)
	{
		uint_0 = senderId;
		byte_0 = message;
	}

	static ByteArrayMessageEventArgs()
	{
		Class72.smethod_20();
	}
}
