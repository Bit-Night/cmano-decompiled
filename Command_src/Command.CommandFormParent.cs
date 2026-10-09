using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;

namespace Command;

public class CommandFormParent : Form
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private uint uint_0;

	protected virtual bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	internal virtual uint RTMPPendingUIEvent
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public CommandFormParent()
	{
		((Form)this).Shown += CommandFormParent_Shown;
		RTMPEnabled = false;
		RTMPPendingUIEvent = 0u;
	}

	private void CommandFormParent_Shown(object sender, EventArgs e)
	{
		if (!Client.ShutdownInitiated && !RTMPEnabled && MyProject.Forms.MainForm.Realtime)
		{
			Client.ShowACRequiredWarning();
			Client.Dispatcher.BeginInvoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
			{
				((Form)this).Close();
			}), new object[0]);
		}
	}

	static CommandFormParent()
	{
		Class72.smethod_20();
	}
}
