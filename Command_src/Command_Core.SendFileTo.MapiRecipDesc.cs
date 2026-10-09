using System;
using System.Runtime.InteropServices;

namespace Command_Core.SendFileTo;

[StructLayout(LayoutKind.Sequential)]
public sealed class MapiRecipDesc
{
	public int reserved;

	public int recipClass;

	public string name;

	public string address;

	public int eIDSize;

	public IntPtr enTryID;

	static MapiRecipDesc()
	{
		Class72.smethod_20();
	}
}
