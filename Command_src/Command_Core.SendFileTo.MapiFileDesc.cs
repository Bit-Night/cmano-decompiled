using System;
using System.Runtime.InteropServices;

namespace Command_Core.SendFileTo;

[StructLayout(LayoutKind.Sequential)]
public sealed class MapiFileDesc
{
	public int reserved;

	public int flags;

	public int position;

	public string path;

	public string name;

	public IntPtr type;

	static MapiFileDesc()
	{
		Class72.smethod_20();
	}
}
