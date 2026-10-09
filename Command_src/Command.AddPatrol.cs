using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class AddPatrol : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("Cancel_Button")]
	[CompilerGenerated]
	private DarkUIButton _Cancel_Button;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_PatrolName")]
	private DarkUITextBox _TB_PatrolName;

	private bool bool_2;

	public double OffsetFromAxis;

	public double theDistance;

	[field: AccessedThroughProperty("TableLayoutPanel1")]
	internal virtual TableLayoutPanel TableLayoutPanel1 { get; set; }

	[field: AccessedThroughProperty("OK_Button")]
	internal virtual DarkUIButton OK_Button { get; set; }

	internal virtual DarkUIButton Cancel_Button
	{
		[CompilerGenerated]
		get
		{
			return _Cancel_Button;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Cancel_Button;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Cancel_Button = value;
			darkUIButton = _Cancel_Button;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUITextBox TB_PatrolName
	{
		[CompilerGenerated]
		get
		{
			return _TB_PatrolName;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			EventHandler eventHandler2 = method_4;
			DarkUITextBox darkUITextBox = _TB_PatrolName;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TB_PatrolName = value;
			darkUITextBox = _TB_PatrolName;
			if (darkUITextBox != null)
			{
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	public AddPatrol()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(AddPatrol_FormClosing);
		((Control)this).KeyDown += new KeyEventHandler(AddPatrol_KeyDown);
		((Form)this).Load += AddPatrol_Load;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		TableLayoutPanel1 = new TableLayoutPanel();
		OK_Button = new DarkUIButton();
		Cancel_Button = new DarkUIButton();
		Label1 = new DarkLabel();
		TB_PatrolName = new DarkUITextBox();
		((Control)TableLayoutPanel1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TableLayoutPanel1).Anchor = (AnchorStyles)10;
		TableLayoutPanel1.ColumnCount = 2;
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		TableLayoutPanel1.ColumnStyles.Add(new ColumnStyle((SizeType)2, 50f));
		TableLayoutPanel1.Controls.Add((Control)(object)OK_Button, 0, 0);
		TableLayoutPanel1.Controls.Add((Control)(object)Cancel_Button, 1, 0);
		((Control)TableLayoutPanel1).Location = new Point(154, 45);
		((Control)TableLayoutPanel1).Name = "TableLayoutPanel1";
		TableLayoutPanel1.RowCount = 1;
		TableLayoutPanel1.RowStyles.Add(new RowStyle((SizeType)2, 50f));
		((Control)TableLayoutPanel1).Size = new Size(146, 29);
		((Control)TableLayoutPanel1).TabIndex = 0;
		((Control)OK_Button).Anchor = (AnchorStyles)0;
		((Control)OK_Button).Location = new Point(3, 3);
		((Control)OK_Button).Name = "OK_Button";
		((Control)OK_Button).Size = new Size(67, 23);
		((Control)OK_Button).TabIndex = 0;
		OK_Button.Text = "OK";
		((Control)Cancel_Button).Anchor = (AnchorStyles)0;
		((Control)Cancel_Button).Location = new Point(76, 3);
		((Control)Cancel_Button).Name = "Cancel_Button";
		((Control)Cancel_Button).Size = new Size(67, 23);
		((Control)Cancel_Button).TabIndex = 1;
		Cancel_Button.Text = "Cancel";
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(13, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(63, 13);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Patrol name";
		((Control)TB_PatrolName).Anchor = (AnchorStyles)15;
		((Control)TB_PatrolName).Location = new Point(82, 10);
		((Control)TB_PatrolName).Name = "TB_PatrolName";
		((Control)TB_PatrolName).Size = new Size(215, 20);
		((Control)TB_PatrolName).TabIndex = 2;
		((Form)this).AcceptButton = (IButtonControl)(object)OK_Button;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).CancelButton = (IButtonControl)(object)Cancel_Button;
		((Form)this).ClientSize = new Size(312, 86);
		((Control)this).Controls.Add((Control)(object)TB_PatrolName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TableLayoutPanel1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "AddPatrol";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Add new Patrol";
		((Control)TableLayoutPanel1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void AddPatrol_FormClosing(object sender, FormClosingEventArgs e)
	{
		Client.CurrentUserAction = Client.UserAction.None;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void AddPatrol_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
			return;
		}
		if (bool_2)
		{
			if (e.KeyValue == 13 && ((Control)this).Visible)
			{
				((Control)OK_Button).Select();
				return;
			}
			if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!bool_2 && (e.KeyValue != 32 || !((Control)this).Visible))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		bool_2 = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		bool_2 = false;
		((Control)OK_Button).Select();
	}

	private void AddPatrol_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static AddPatrol()
	{
		Class72.smethod_20();
	}
}
