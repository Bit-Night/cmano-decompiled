using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class RenameObject : DarkSecondaryFormBase
{
	public enum E_RenamingOption
	{
		ReferencePoint,
		Unit,
		Unit_Generic
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	private bool bool_2;

	public string SelectedName;

	public E_RenamingOption RenamingOption;

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkUITextBox TextBox1 { get; set; }

	internal virtual DarkUIButton Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Button1_Click;
			DarkUIButton darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button1 = value;
			darkUIButton = _Button1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button2 = value;
			darkUIButton = _Button2;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public RenameObject()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(RenameObject_FormClosing);
		((Form)this).Load += RenameObject_Load;
		((Control)this).KeyDown += new KeyEventHandler(RenameObject_KeyDown);
		RTMPEnabled = true;
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
		TextBox1 = new DarkUITextBox();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		((Control)this).SuspendLayout();
		((Control)TextBox1).Anchor = (AnchorStyles)13;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(12, 12);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(317, 20);
		((Control)TextBox1).TabIndex = 0;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)1;
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(12, 44);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 1;
		Button1.Text = "OK";
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)2;
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(254, 44);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 2;
		Button2.Text = "Cancel";
		((Form)this).AcceptButton = (IButtonControl)(object)Button1;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).AutoValidate = (AutoValidate)2;
		((Form)this).CancelButton = (IButtonControl)(object)Button2;
		((Form)this).ClientSize = new Size(341, 77);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RenameObject";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Rename Object";
		((Control)this).ResumeLayout(false);
	}

	private void RenameObject_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		Client.MustRefreshMainForm = true;
		if (!Information.IsNothing((object)MyProject.Forms.AirOps) && ((Control)MyProject.Forms.AirOps).Visible)
		{
			MyProject.Forms.AirOps.RefreshForm();
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
		if (((Control)MyProject.Forms.ScenAttachmentsWindow).Visible)
		{
			MyProject.Forms.ScenAttachmentsWindow.RefreshForm();
		}
	}

	private void RenameObject_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		((Control)MyProject.Forms.MainForm).Enabled = false;
		if (RenamingOption != E_RenamingOption.ReferencePoint)
		{
			if (RenamingOption == E_RenamingOption.Unit)
			{
				SelectedName = Client.SelectedUnit.Name;
				((Form)this).Text = "Rename a unit";
			}
			else if (RenamingOption == E_RenamingOption.Unit_Generic)
			{
				((Form)this).Text = "Rename a unit";
			}
		}
		else
		{
			if (Client.HighlightedRefPoints.Count < 1)
			{
				return;
			}
			SelectedName = Client.HighlightedRefPoints[0].Name;
			((Form)this).Text = "Rename a reference point";
		}
		TextBox1.Text = SelectedName;
		((Control)TextBox1._T).Select();
		TextBox1.SelectionStart = 0;
		((TextBoxBase)TextBox1._T).SelectionLength = SelectedName.Length;
	}

	public void Button1_Click(object sender, EventArgs e)
	{
		ConfirmRenaming();
	}

	public void ConfirmRenaming()
	{
		SelectedName = TextBox1.Text;
		((Form)this).DialogResult = (DialogResult)1;
		if (RenamingOption == E_RenamingOption.ReferencePoint)
		{
			if (Client.HighlightedRefPoints.Count < 1)
			{
				return;
			}
			Client.HighlightedRefPoints[0].Name = SelectedName;
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendReferencePointUpdate(Client.CurrentSide, Client.HighlightedRefPoints[0]);
			}
		}
		else if (RenamingOption == E_RenamingOption.Unit)
		{
			if (Client.SelectedUnit == null)
			{
				return;
			}
			Client.SelectedUnit.Name = SelectedName;
			if (Client.Realtime)
			{
				Client.RealtimeTerminal.SendUnitRename(Client.SelectedUnit, SelectedName);
			}
			MyProject.Forms.MainForm.RefreshRightColumn();
		}
		((Form)this).Close();
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		((Form)this).Close();
	}

	private void RenameObject_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 27)
		{
			_ = ((Control)this).Visible;
		}
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)keyData == 13)
		{
			ConfirmRenaming();
			return true;
		}
		if ((int)keyData == 27)
		{
			((Form)this).Close();
			return true;
		}
		return false;
	}

	static RenameObject()
	{
		Class72.smethod_20();
	}
}
