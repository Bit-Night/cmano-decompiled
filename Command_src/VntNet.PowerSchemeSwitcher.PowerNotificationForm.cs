// VntNet.PowerSchemeSwitcher.PowerNotificationForm: whole-type decompilation failed; members decompiled one by one.
private PowerSettingNotificationMsgFilter powerSettingNotificationMsgFilter_0;

private PowerLineHelper powerLineHelper_0;

private string string_0;

private PowerSettingNotificationMsgFilter.PowerSavingLevelEnum powerSavingLevelEnum_0;

using System;
using System.Runtime.CompilerServices;

[CompilerGenerated]
private Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> action_0;

using System.ComponentModel;

private IContainer icontainer_0;

using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal event Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> PowerStatusChangedEvent
{
	[CompilerGenerated]
	add
	{
		Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> action = action_0;
		Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> action2;
		do
		{
			action2 = action;
			Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> value2 = (Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum>)Delegate.Combine(action2, value);
			action = Interlocked.CompareExchange(ref action_0, value2, action2);
		}
		while ((object)action != action2);
	}
	[CompilerGenerated]
	remove
	{
		Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> action = action_0;
		Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> action2;
		do
		{
			action2 = action;
			Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum> value2 = (Action<string, PowerSettingNotificationMsgFilter.PowerSavingLevelEnum>)Delegate.Remove(action2, value);
			action = Interlocked.CompareExchange(ref action_0, value2, action2);
		}
		while ((object)action != action2);
	}
}

// FAILED VntNet.PowerSchemeSwitcher.PowerNotificationForm..ctor (token 0x0600c685): ArgumentNullException: Value cannot be null. (Parameter 'methodReference')
private void method_0(int int_0)
{
	method_1();
}

using System;
using System.Windows.Forms;

protected override void WndProc(ref Message m)
{
	int num;
	if (powerSettingNotificationMsgFilter_0 != null)
	{
		if (powerSettingNotificationMsgFilter_0.PreFilterMessage(ref m))
		{
			num = 17;
		}
		else
		{
			((Form)this).WndProc(ref m);
			num = 17;
		}
	}
	else
	{
		((Form)this).WndProc(ref m);
		num = 17;
	}
	int num2 = num;
	int num3 = 22;
	if (((Message)(ref m)).Msg == num2)
	{
		((Message)(ref m)).Result = (IntPtr)1;
	}
	else if (((Message)(ref m)).Msg == num3)
	{
		method_3();
		((Message)(ref m)).Result = (IntPtr)0;
		((Form)this).Close();
		Application.Exit();
	}
}

private void method_1()
{
	if (action_0 != null)
	{
		action_0(string_0, powerSavingLevelEnum_0);
	}
}

using System;
using System.Windows.Forms;

private void PowerNotificationForm_Shown(object sender, EventArgs e)
{
	((Control)this).Hide();
}

using System;

private void PowerNotificationForm_Load(object sender, EventArgs e)
{
	method_2();
}

using System.Windows.Forms;

private void PowerNotificationForm_FormClosing(object sender, FormClosingEventArgs e)
{
	method_3();
}

using System.Windows.Forms;

private void method_2()
{
	powerSettingNotificationMsgFilter_0 = new PowerSettingNotificationMsgFilter((Form)(object)this);
	powerSettingNotificationMsgFilter_0.PowerSchemeChanged += method_5;
}

private void method_3()
{
	powerSettingNotificationMsgFilter_0.Destroy();
}

// FAILED VntNet.PowerSchemeSwitcher.PowerNotificationForm.method_4 (token 0x0600c68e): ArgumentNullException: Value cannot be null. (Parameter 'methodReference')
private void method_5(PowerSettingNotificationMsgFilter.PowerSavingLevelEnum powerSavingLevelEnum_1)
{
	powerSavingLevelEnum_0 = powerSavingLevelEnum_1;
	method_1();
}

using System.Windows.Forms;

protected override void Dispose(bool disposing)
{
	if (disposing && icontainer_0 != null)
	{
		icontainer_0.Dispose();
	}
	((Form)this).Dispose(disposing);
}

using System.Drawing;
using System.Windows.Forms;

private void InitializeComponent()
{
	//IL_004e: Unknown result type (might be due to invalid IL or missing references)
	//IL_0058: Expected O, but got Unknown
	((Control)this).SuspendLayout();
	((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
	((Form)this).ClientSize = new Size(284, 262);
	((Control)this).Name = "PowerNotificationForm";
	((Control)this).Text = "PowerNotificationForm";
	((Form)this).FormClosing += new FormClosingEventHandler(PowerNotificationForm_FormClosing);
	((Form)this).Load += PowerNotificationForm_Load;
	((Form)this).Shown += PowerNotificationForm_Shown;
	((Control)this).ResumeLayout(false);
}

static PowerNotificationForm()
{
	Class72.smethod_20();
}

