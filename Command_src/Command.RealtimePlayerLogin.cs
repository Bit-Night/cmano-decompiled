using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using CommandNetcode.RT;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimePlayerLogin : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonCancel")]
	private DarkUIButton _ButtonCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonOk")]
	private DarkUIButton _ButtonOk;

	[CompilerGenerated]
	private bool bool_2;

	public string ErrorString;

	internal virtual DarkUIButton ButtonCancel
	{
		[CompilerGenerated]
		get
		{
			return _ButtonCancel;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonCancel = value;
			darkUIButton = _ButtonCancel;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton ButtonOk
	{
		[CompilerGenerated]
		get
		{
			return _ButtonOk;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _ButtonOk;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonOk = value;
			darkUIButton = _ButtonOk;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ErrorLabel")]
	internal virtual DarkLabel ErrorLabel { get; set; }

	[field: AccessedThroughProperty("PlayerNameLabel")]
	internal virtual DarkLabel PlayerNameLabel { get; set; }

	[field: AccessedThroughProperty("Label_HostIP")]
	internal virtual DarkLabel Label_HostIP { get; set; }

	[field: AccessedThroughProperty("Label_LockedSideName")]
	internal virtual DarkLabel Label_LockedSideName { get; set; }

	[field: AccessedThroughProperty("Label_AccessLevel")]
	internal virtual DarkLabel Label_AccessLevel { get; set; }

	[field: AccessedThroughProperty("HostIPTextBox")]
	internal virtual DarkUITextBox HostIPTextBox { get; set; }

	[field: AccessedThroughProperty("PlayerNameTextBox")]
	internal virtual DarkUITextBox PlayerNameTextBox { get; set; }

	[field: AccessedThroughProperty("AccessLevelComboBox")]
	internal virtual DarkUIComboBox AccessLevelComboBox { get; set; }

	[field: AccessedThroughProperty("ShowPeerViewportsCheckBox")]
	internal virtual DarkCheckBox ShowPeerViewportsCheckBox { get; set; }

	[field: AccessedThroughProperty("HostPortTextBox")]
	internal virtual DarkUITextBox HostPortTextBox { get; set; }

	[field: AccessedThroughProperty("Label_HostPort")]
	internal virtual DarkLabel Label_HostPort { get; set; }

	[field: AccessedThroughProperty("SideNameComboBox")]
	internal virtual DarkUIComboBox SideNameComboBox { get; set; }

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

	public RealtimePlayerLogin()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Load += RealtimePlayerLogin_Load;
		((Control)this).KeyDown += new KeyEventHandler(RealtimePlayerLogin_KeyDown);
		RTMPEnabled = true;
		ErrorString = "";
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
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071f: Expected O, but got Unknown
		//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ee: Expected O, but got Unknown
		((Form)this).KeyPreview = true;
		ButtonCancel = new DarkUIButton();
		ButtonOk = new DarkUIButton();
		ErrorLabel = new DarkLabel();
		PlayerNameLabel = new DarkLabel();
		Label_HostIP = new DarkLabel();
		Label_LockedSideName = new DarkLabel();
		Label_AccessLevel = new DarkLabel();
		HostIPTextBox = new DarkUITextBox();
		PlayerNameTextBox = new DarkUITextBox();
		AccessLevelComboBox = new DarkUIComboBox();
		ShowPeerViewportsCheckBox = new DarkCheckBox();
		HostPortTextBox = new DarkUITextBox();
		Label_HostPort = new DarkLabel();
		SideNameComboBox = new DarkUIComboBox();
		((Control)this).SuspendLayout();
		((Control)ButtonCancel).Anchor = (AnchorStyles)0;
		((ButtonBase)ButtonCancel).BackColor = Color.Transparent;
		((Control)ButtonCancel).ForeColor = SystemColors.Control;
		((Control)ButtonCancel).Location = new Point(199, 230);
		((Control)ButtonCancel).Name = "ButtonCancel";
		((Control)ButtonCancel).Padding = new Padding(5);
		ButtonCancel.RoundRadius = 0;
		((Control)ButtonCancel).Size = new Size(91, 23);
		((Control)ButtonCancel).TabIndex = 32;
		ButtonCancel.Text = "Cancel";
		((Control)ButtonOk).Anchor = (AnchorStyles)0;
		((ButtonBase)ButtonOk).BackColor = Color.Transparent;
		((Control)ButtonOk).ForeColor = SystemColors.Control;
		((Control)ButtonOk).Location = new Point(83, 230);
		((Control)ButtonOk).Name = "ButtonOk";
		((Control)ButtonOk).Padding = new Padding(5);
		ButtonOk.RoundRadius = 0;
		((Control)ButtonOk).Size = new Size(91, 23);
		((Control)ButtonOk).TabIndex = 31;
		ButtonOk.Text = "Ok";
		((Control)ErrorLabel).Font = new Font("Segoe UI", 9f, (FontStyle)1);
		((Control)ErrorLabel).ForeColor = Color.Red;
		((Control)ErrorLabel).Location = new Point(12, 10);
		((Control)ErrorLabel).Name = "ErrorLabel";
		((Control)ErrorLabel).Size = new Size(350, 36);
		((Control)ErrorLabel).TabIndex = 33;
		((Label)ErrorLabel).TextAlign = (ContentAlignment)32;
		((Control)PlayerNameLabel).ForeColor = Color.White;
		((Label)PlayerNameLabel).ImageAlign = (ContentAlignment)64;
		((Control)PlayerNameLabel).Location = new Point(12, 103);
		((Control)PlayerNameLabel).Name = "PlayerNameLabel";
		((Control)PlayerNameLabel).Size = new Size(124, 20);
		((Control)PlayerNameLabel).TabIndex = 34;
		((Label)PlayerNameLabel).Text = "Player Name:";
		((Label)PlayerNameLabel).TextAlign = (ContentAlignment)64;
		((Control)Label_HostIP).ForeColor = Color.White;
		((Label)Label_HostIP).ImageAlign = (ContentAlignment)64;
		((Control)Label_HostIP).Location = new Point(12, 51);
		((Control)Label_HostIP).Name = "Label_HostIP";
		((Control)Label_HostIP).Size = new Size(124, 20);
		((Control)Label_HostIP).TabIndex = 36;
		((Label)Label_HostIP).Text = "Host IP Address:";
		((Label)Label_HostIP).TextAlign = (ContentAlignment)64;
		((Control)Label_LockedSideName).ForeColor = Color.White;
		((Label)Label_LockedSideName).ImageAlign = (ContentAlignment)64;
		((Control)Label_LockedSideName).Location = new Point(12, 131);
		((Control)Label_LockedSideName).Name = "Label_LockedSideName";
		((Control)Label_LockedSideName).Size = new Size(124, 20);
		((Control)Label_LockedSideName).TabIndex = 37;
		((Label)Label_LockedSideName).Text = "Locked Side Name:";
		((Label)Label_LockedSideName).TextAlign = (ContentAlignment)64;
		((Control)Label_AccessLevel).ForeColor = Color.White;
		((Label)Label_AccessLevel).ImageAlign = (ContentAlignment)64;
		((Control)Label_AccessLevel).Location = new Point(12, 160);
		((Control)Label_AccessLevel).Name = "Label_AccessLevel";
		((Control)Label_AccessLevel).Size = new Size(124, 20);
		((Control)Label_AccessLevel).TabIndex = 38;
		((Label)Label_AccessLevel).Text = "Access Level:";
		((Label)Label_AccessLevel).TextAlign = (ContentAlignment)64;
		HostIPTextBox.AutoCompleteCustomSource = null;
		HostIPTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		HostIPTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)HostIPTextBox).BackColor = Color.Transparent;
		((Control)HostIPTextBox).Enabled = false;
		((Control)HostIPTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		HostIPTextBox.Image = null;
		HostIPTextBox.Lines = null;
		((Control)HostIPTextBox).Location = new Point(142, 52);
		HostIPTextBox.MaxLength = 32767;
		HostIPTextBox.Multiline = false;
		((Control)HostIPTextBox).Name = "HostIPTextBox";
		HostIPTextBox.ReadOnly = false;
		HostIPTextBox.ScrollBars = (ScrollBars)0;
		HostIPTextBox.SelectionStart = 0;
		((Control)HostIPTextBox).Size = new Size(172, 18);
		((Control)HostIPTextBox).TabIndex = 39;
		HostIPTextBox.TextAlign = (HorizontalAlignment)0;
		HostIPTextBox.UseSystemPasswordChar = false;
		HostIPTextBox.WatermarkText = "";
		HostIPTextBox.WordWrap = false;
		PlayerNameTextBox.AutoCompleteCustomSource = null;
		PlayerNameTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		PlayerNameTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)PlayerNameTextBox).BackColor = Color.Transparent;
		((Control)PlayerNameTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		PlayerNameTextBox.Image = null;
		PlayerNameTextBox.Lines = null;
		((Control)PlayerNameTextBox).Location = new Point(142, 104);
		PlayerNameTextBox.MaxLength = 32767;
		PlayerNameTextBox.Multiline = false;
		((Control)PlayerNameTextBox).Name = "PlayerNameTextBox";
		PlayerNameTextBox.ReadOnly = false;
		PlayerNameTextBox.ScrollBars = (ScrollBars)0;
		PlayerNameTextBox.SelectionStart = 0;
		((Control)PlayerNameTextBox).Size = new Size(170, 18);
		((Control)PlayerNameTextBox).TabIndex = 40;
		PlayerNameTextBox.TextAlign = (HorizontalAlignment)0;
		PlayerNameTextBox.UseSystemPasswordChar = false;
		PlayerNameTextBox.WatermarkText = "";
		PlayerNameTextBox.WordWrap = false;
		((ComboBox)AccessLevelComboBox).BackColor = Color.Transparent;
		((ComboBox)AccessLevelComboBox).DrawMode = (DrawMode)1;
		((ComboBox)AccessLevelComboBox).DropDownStyle = (ComboBoxStyle)2;
		((Control)AccessLevelComboBox).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)AccessLevelComboBox).FormattingEnabled = true;
		((Control)AccessLevelComboBox).Location = new Point(142, 160);
		((Control)AccessLevelComboBox).Name = "AccessLevelComboBox";
		((Control)AccessLevelComboBox).Size = new Size(170, 21);
		((Control)AccessLevelComboBox).TabIndex = 42;
		((ButtonBase)ShowPeerViewportsCheckBox).AutoSize = true;
		((Control)ShowPeerViewportsCheckBox).Location = new Point(142, 190);
		((Control)ShowPeerViewportsCheckBox).Name = "ShowPeerViewportsCheckBox";
		((Control)ShowPeerViewportsCheckBox).RightToLeft = (RightToLeft)0;
		((Control)ShowPeerViewportsCheckBox).Size = new Size(136, 19);
		((Control)ShowPeerViewportsCheckBox).TabIndex = 45;
		((ButtonBase)ShowPeerViewportsCheckBox).Text = "Show Peer Viewports";
		HostPortTextBox.AutoCompleteCustomSource = null;
		HostPortTextBox.AutoCompleteMode = (AutoCompleteMode)0;
		HostPortTextBox.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)HostPortTextBox).BackColor = Color.Transparent;
		((Control)HostPortTextBox).Enabled = false;
		((Control)HostPortTextBox).ForeColor = Color.FromArgb(189, 189, 189);
		HostPortTextBox.Image = null;
		HostPortTextBox.Lines = null;
		((Control)HostPortTextBox).Location = new Point(142, 76);
		HostPortTextBox.MaxLength = 32767;
		HostPortTextBox.Multiline = false;
		((Control)HostPortTextBox).Name = "HostPortTextBox";
		HostPortTextBox.ReadOnly = false;
		HostPortTextBox.ScrollBars = (ScrollBars)0;
		HostPortTextBox.SelectionStart = 0;
		((Control)HostPortTextBox).Size = new Size(57, 18);
		((Control)HostPortTextBox).TabIndex = 47;
		HostPortTextBox.TextAlign = (HorizontalAlignment)0;
		HostPortTextBox.UseSystemPasswordChar = false;
		HostPortTextBox.WatermarkText = "";
		HostPortTextBox.WordWrap = false;
		((Control)Label_HostPort).ForeColor = Color.White;
		((Label)Label_HostPort).ImageAlign = (ContentAlignment)64;
		((Control)Label_HostPort).Location = new Point(12, 75);
		((Control)Label_HostPort).Name = "Label_HostPort";
		((Control)Label_HostPort).Size = new Size(124, 20);
		((Control)Label_HostPort).TabIndex = 46;
		((Label)Label_HostPort).Text = "Host Port:";
		((Label)Label_HostPort).TextAlign = (ContentAlignment)64;
		((ComboBox)SideNameComboBox).BackColor = Color.Transparent;
		((ComboBox)SideNameComboBox).DrawMode = (DrawMode)1;
		((ComboBox)SideNameComboBox).DropDownStyle = (ComboBoxStyle)2;
		((Control)SideNameComboBox).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)SideNameComboBox).FormattingEnabled = true;
		((Control)SideNameComboBox).Location = new Point(142, 131);
		((Control)SideNameComboBox).Name = "SideNameComboBox";
		((Control)SideNameComboBox).Size = new Size(170, 21);
		((Control)SideNameComboBox).TabIndex = 48;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(373, 264);
		((Control)this).Controls.Add((Control)(object)SideNameComboBox);
		((Control)this).Controls.Add((Control)(object)HostPortTextBox);
		((Control)this).Controls.Add((Control)(object)Label_HostPort);
		((Control)this).Controls.Add((Control)(object)ShowPeerViewportsCheckBox);
		((Control)this).Controls.Add((Control)(object)AccessLevelComboBox);
		((Control)this).Controls.Add((Control)(object)PlayerNameTextBox);
		((Control)this).Controls.Add((Control)(object)HostIPTextBox);
		((Control)this).Controls.Add((Control)(object)Label_AccessLevel);
		((Control)this).Controls.Add((Control)(object)Label_LockedSideName);
		((Control)this).Controls.Add((Control)(object)Label_HostIP);
		((Control)this).Controls.Add((Control)(object)PlayerNameLabel);
		((Control)this).Controls.Add((Control)(object)ErrorLabel);
		((Control)this).Controls.Add((Control)(object)ButtonCancel);
		((Control)this).Controls.Add((Control)(object)ButtonOk);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "RealtimePlayerLogin";
		((Form)this).ShowInTaskbar = false;
		((Form)this).Text = "Join Multi-player";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RealtimePlayerLogin_Load(object sender, EventArgs e)
	{
		string value = Client.RealtimeTerminal.TerminalLockedSide;
		if (Client.CurrentScenario != null && Operators.CompareString(Client.CurrentScenario.Title, Client.RealtimeTerminal.ServerScenarioTitle, true) == 0 && Client.CurrentSide != null)
		{
			value = Client.CurrentSide.Name;
		}
		((Label)ErrorLabel).Text = ErrorString;
		if (((ComboBox)AccessLevelComboBox).Items.Count == 0)
		{
			((ComboBox)AccessLevelComboBox).Items.Add((object)"Player");
		}
		((ComboBox)AccessLevelComboBox).SelectedIndex = 0;
		((Control)AccessLevelComboBox).Enabled = false;
		((Control)AccessLevelComboBox).Visible = false;
		((Control)Label_AccessLevel).Visible = false;
		((Control)ButtonCancel).Visible = false;
		((Control)ButtonOk).Left = ((Control)this).Width / 2 - ((Control)ButtonOk).Width / 2;
		((ComboBox)SideNameComboBox).Items.Clear();
		if (Client.RealtimeTerminal == null)
		{
			HostIPTextBox.Text = "127.0.0.1";
			HostPortTextBox.Text = 9000.ToString();
			PlayerNameTextBox.Text = Dns.GetHostName();
			return;
		}
		HostIPTextBox.Text = Client.RealtimeTerminal.DefaultIP;
		HostPortTextBox.Text = Client.RealtimeTerminal.DefaultPort.ToString();
		PlayerNameTextBox.Text = Client.RealtimeTerminal.ClientName;
		((CheckBox)ShowPeerViewportsCheckBox).Checked = Client.RealtimeTerminal.ShowPeerViewports;
		int num = 0;
		((ComboBox)SideNameComboBox).SelectedIndex = -1;
		foreach (string serverScenarioPlayableSideName in Client.RealtimeTerminal.ServerScenarioPlayableSideNames)
		{
			num = ((ComboBox)SideNameComboBox).Items.Add((object)serverScenarioPlayableSideName);
			if (((ComboBox)SideNameComboBox).SelectedIndex == -1 && serverScenarioPlayableSideName.Equals(value, StringComparison.OrdinalIgnoreCase))
			{
				((ComboBox)SideNameComboBox).SelectedIndex = num;
			}
		}
		if (((ComboBox)SideNameComboBox).SelectedIndex == -1)
		{
			((ComboBox)SideNameComboBox).SelectedIndex = 0;
		}
		((Control)HostIPTextBox).Visible = false;
		((Control)HostPortTextBox).Visible = false;
		((Control)Label_HostIP).Visible = false;
		((Control)Label_HostPort).Visible = false;
	}

	private void RealtimePlayerLogin_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		if ((int)e.Modifiers == 0 && (int)e.KeyCode == 67 && !PlayerNameTextBox.Focused && !((ComboBox)SideNameComboBox).Focused)
		{
			Client.OpenChatPanel();
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		if (Client.RealtimeTerminal == null)
		{
			((Label)ErrorLabel).Text = "Error: Realtime Terminal not initialized. Click 'Cancel' and retry.";
		}
		else
		{
			Client.RealtimeTerminal.DefaultIP = HostIPTextBox.Text;
			if (int.TryParse(HostPortTextBox.Text, out var result) && result > 0 && result < 65536)
			{
				Client.RealtimeTerminal.DefaultPort = result;
			}
			Client.RealtimeTerminal.ClientName = PlayerNameTextBox.Text;
			Client.RealtimeTerminal.TerminalLockedSide = ((ComboBox)SideNameComboBox).Text;
			Client.RealtimeTerminal.ShowPeerViewports = ((CheckBox)ShowPeerViewportsCheckBox).Checked;
			Client.RealtimeTerminal.TerminalRights = TerminalRights.Player;
			((Form)this).DialogResult = (DialogResult)1;
		}
		if (MyProject.Forms.m_RealtimeChatInputBar != null && ((Control)MyProject.Forms.RealtimeChatInputBar).Visible)
		{
			((Form)MyProject.Forms.RealtimeChatInputBar).Close();
		}
		((Form)this).Close();
	}

	private void method_3(object sender, EventArgs e)
	{
		((Form)this).DialogResult = (DialogResult)2;
		if (MyProject.Forms.m_RealtimeChatInputBar != null && ((Control)MyProject.Forms.RealtimeChatInputBar).Visible)
		{
			((Form)MyProject.Forms.RealtimeChatInputBar).Close();
		}
		((Form)this).Close();
	}

	static RealtimePlayerLogin()
	{
		Class72.smethod_20();
	}
}
