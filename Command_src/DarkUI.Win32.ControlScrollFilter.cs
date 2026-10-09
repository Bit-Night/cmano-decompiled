using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Win32;

public sealed class ControlScrollFilter : IMessageFilter
{
	public bool PreFilterMessage(ref Message m)
	{
		int msg = ((Message)(ref m)).Msg;
		if (msg != 522 && msg != 526)
		{
			return false;
		}
		IntPtr intPtr = Native.WindowFromPoint(new Point((int)((Message)(ref m)).LParam));
		if (intPtr == ((Message)(ref m)).HWnd)
		{
			return false;
		}
		Native.SendMessage(intPtr, (uint)((Message)(ref m)).Msg, ((Message)(ref m)).WParam, ((Message)(ref m)).LParam);
		return true;
	}

	static ControlScrollFilter()
	{
		Class72.smethod_20();
	}
}
