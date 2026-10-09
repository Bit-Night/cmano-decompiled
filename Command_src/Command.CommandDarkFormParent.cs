using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Forms;

namespace Command;

public class CommandDarkFormParent : DarkForm
{
	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private uint uint_0;

	protected virtual bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
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

	public CommandDarkFormParent()
	{
		((Form)this).Shown += CommandDarkFormParent_Shown;
		RTMPEnabled = false;
		RTMPPendingUIEvent = 0u;
	}

	private void CommandDarkFormParent_Shown(object sender, EventArgs e)
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

	static CommandDarkFormParent()
	{
		Class72.smethod_20();
	}
}
