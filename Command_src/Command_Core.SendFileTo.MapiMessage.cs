using System;
using System.Runtime.InteropServices;

namespace Command_Core.SendFileTo;

[StructLayout(LayoutKind.Sequential)]
public sealed class MapiMessage
{
	public int reserved;

	public string subject;

	public string noteText;

	public string messageType;

	public string dateReceived;

	public string conversationID;

	public int flags;

	public IntPtr originator;

	public int recipCount;

	public IntPtr recips;

	public int fileCount;

	public IntPtr files;

	static MapiMessage()
	{
		Class72.smethod_20();
	}
}
