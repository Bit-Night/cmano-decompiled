using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Faster.Map.Core;

[DebuggerDisplay("psl - {Psl}")]
public struct InfoByte
{
	private byte byte_0;

	public byte Psl
	{
		get
		{
			return (byte)(byte_0 & 0x7F);
		}
		set
		{
			byte_0 = (value |= 0x80);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool IsEmpty()
	{
		return (byte_0 & 0x80) == 0;
	}

	static InfoByte()
	{
		Class72.smethod_20();
	}
}
