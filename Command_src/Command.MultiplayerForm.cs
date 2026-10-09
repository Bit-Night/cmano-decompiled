using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MultiplayerForm : Form
{
	private IContainer icontainer_0;

	[AccessedThroughProperty("IPTextBox")]
	[CompilerGenerated]
	private TextBox textBox_0;

	[AccessedThroughProperty("ScenarioNameTextBox")]
	[CompilerGenerated]
	private TextBox jygHifpWmbp;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox10")]
	private GroupBox groupBox_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	[field: AccessedThroughProperty("UsernameTextBox")]
	internal virtual TextBox UsernameTextBox { get; set; }

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1 { get; set; }

	[field: AccessedThroughProperty("GroupBox2")]
	internal virtual GroupBox GroupBox2 { get; set; }

	[field: AccessedThroughProperty("ConnectButton")]
	internal virtual Button ConnectButton { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2 { get; set; }

	internal virtual TextBox IPTextBox
	{
		[CompilerGenerated]
		get
		{
			return textBox_0;
		}
		[CompilerGenerated]
		set
		{
			textBox_0 = value;
		}
	}

	[field: AccessedThroughProperty("LogListBox")]
	internal virtual ListBox LogListBox { get; set; }

	[field: AccessedThroughProperty("TeamsTreeView")]
	internal virtual TreeView TeamsTreeView { get; set; }

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3 { get; set; }

	internal virtual TextBox ScenarioNameTextBox
	{
		[CompilerGenerated]
		get
		{
			return jygHifpWmbp;
		}
		[CompilerGenerated]
		set
		{
			jygHifpWmbp = value;
		}
	}

	[field: AccessedThroughProperty("GroupBox5")]
	internal virtual GroupBox GroupBox5 { get; set; }

	[field: AccessedThroughProperty("GroupBox4")]
	internal virtual GroupBox GroupBox4 { get; set; }

	[field: AccessedThroughProperty("JoinTeamButton")]
	internal virtual Button JoinTeamButton { get; set; }

	[field: AccessedThroughProperty("PlayersListBox")]
	internal virtual ListBox PlayersListBox { get; set; }

	[field: AccessedThroughProperty("DisconnectButton")]
	internal virtual Button DisconnectButton { get; set; }

	[field: AccessedThroughProperty("ObserverButton")]
	internal virtual Button ObserverButton { get; set; }

	[field: AccessedThroughProperty("UmpireButton")]
	internal virtual Button UmpireButton { get; set; }

	[field: AccessedThroughProperty("PortTextBox")]
	internal virtual TextBox PortTextBox { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3 { get; set; }

	[field: AccessedThroughProperty("TeamNameTextBox")]
	internal virtual TextBox TeamNameTextBox { get; set; }

	[field: AccessedThroughProperty("GroupBox6")]
	internal virtual GroupBox GroupBox6 { get; set; }

	[field: AccessedThroughProperty("ClearLogButton")]
	internal virtual Button ClearLogButton { get; set; }

	[field: AccessedThroughProperty("GroupBox7")]
	internal virtual GroupBox GroupBox7 { get; set; }

	[field: AccessedThroughProperty("GroupBox8")]
	internal virtual GroupBox GroupBox8 { get; set; }

	[field: AccessedThroughProperty("GlobalChatButton")]
	internal virtual Button GlobalChatButton { get; set; }

	[field: AccessedThroughProperty("GlobalChatInputTextBox")]
	internal virtual TextBox GlobalChatInputTextBox { get; set; }

	[field: AccessedThroughProperty("TeamChatButton")]
	internal virtual Button TeamChatButton { get; set; }

	[field: AccessedThroughProperty("TeamChatInputTextBox")]
	internal virtual TextBox TeamChatInputTextBox { get; set; }

	[field: AccessedThroughProperty("GlobalChatTextBox")]
	internal virtual RichTextBox GlobalChatTextBox { get; set; }

	[field: AccessedThroughProperty("TeamChatTextBox")]
	internal virtual RichTextBox TeamChatTextBox { get; set; }

	[field: AccessedThroughProperty("GroupBox9")]
	internal virtual GroupBox GroupBox9 { get; set; }

	[field: AccessedThroughProperty("CommitTurnButton")]
	internal virtual Button CommitTurnButton { get; set; }

	[field: AccessedThroughProperty("MultiplayerStatusRichTextBox")]
	internal virtual RichTextBox MultiplayerStatusRichTextBox { get; set; }

	internal virtual GroupBox GroupBox10
	{
		[CompilerGenerated]
		get
		{
			return groupBox_0;
		}
		[CompilerGenerated]
		set
		{
			groupBox_0 = value;
		}
	}

	[field: AccessedThroughProperty("TurnReplay_ReturnToPresent")]
	internal virtual Button TurnReplay_ReturnToPresent { get; set; }

	[field: AccessedThroughProperty("TurnReplayListBox")]
	internal virtual ListBox TurnReplayListBox { get; set; }

	[field: AccessedThroughProperty("TurnReplay_Prev")]
	internal virtual Button TurnReplay_Prev { get; set; }

	[field: AccessedThroughProperty("TurnReplay_Play")]
	internal virtual Button TurnReplay_Play { get; set; }

	[field: AccessedThroughProperty("TurnReplay_Next")]
	internal virtual Button TurnReplay_Next { get; set; }

	[field: AccessedThroughProperty("TurnReplay_Pause")]
	internal virtual Button TurnReplay_Pause { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4 { get; set; }

	[field: AccessedThroughProperty("MultiplayerOptionsGroupBox")]
	internal virtual GroupBox MultiplayerOptionsGroupBox { get; set; }

	[field: AccessedThroughProperty("MPRuleScenarioEndButton")]
	internal virtual CheckBox MPRuleScenarioEndButton { get; set; }

	[field: AccessedThroughProperty("SpeedChess_CommitCountdownLabel")]
	internal virtual Label SpeedChess_CommitCountdownLabel { get; set; }

	[field: AccessedThroughProperty("SpeedChessGroupBox")]
	internal virtual GroupBox SpeedChessGroupBox { get; set; }

	[field: AccessedThroughProperty("SpeedChess_EventLabel")]
	internal virtual Label SpeedChess_EventLabel { get; set; }

	[field: AccessedThroughProperty("SpeedChess_MoreTimeRequestButton1")]
	internal virtual Button SpeedChess_MoreTimeRequestButton1 { get; set; }

	[field: AccessedThroughProperty("SpeedChess_MoreTimeRequestButton3")]
	internal virtual Button SpeedChess_MoreTimeRequestButton3 { get; set; }

	[field: AccessedThroughProperty("SpeedChess_MoreTimeRequestButton2")]
	internal virtual Button SpeedChess_MoreTimeRequestButton2 { get; set; }

	[field: AccessedThroughProperty("SpecialNoticeLabel")]
	internal virtual Label SpecialNoticeLabel { get; set; }

	[field: AccessedThroughProperty("TimeTableComboBox")]
	internal virtual ComboBox TimeTableComboBox { get; set; }

	[field: AccessedThroughProperty("UmpirePauseButton")]
	internal virtual Button UmpirePauseButton { get; set; }

	[field: AccessedThroughProperty("UmpireResumeButton")]
	internal virtual Button UmpireResumeButton { get; set; }

	[field: AccessedThroughProperty("ForceCommitButton")]
	internal virtual Button ForceCommitButton { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual Label Label5 { get; set; }

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6 { get; set; }

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7 { get; set; }

	[field: AccessedThroughProperty("AbortExecutionButton")]
	internal virtual Button AbortExecutionButton { get; set; }

	public MultiplayerForm()
	{
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0ef5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eff: Expected O, but got Unknown
		//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Expected O, but got Unknown
		//IL_1120: Unknown result type (might be due to invalid IL or missing references)
		//IL_112a: Expected O, but got Unknown
		//IL_1222: Unknown result type (might be due to invalid IL or missing references)
		//IL_122c: Expected O, but got Unknown
		//IL_1b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b29: Expected O, but got Unknown
		//IL_1bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bce: Expected O, but got Unknown
		Label1 = new Label();
		UsernameTextBox = new TextBox();
		GroupBox1 = new GroupBox();
		Label3 = new Label();
		TeamNameTextBox = new TextBox();
		GroupBox2 = new GroupBox();
		PortTextBox = new TextBox();
		DisconnectButton = new Button();
		ConnectButton = new Button();
		Label4 = new Label();
		Label2 = new Label();
		IPTextBox = new TextBox();
		LogListBox = new ListBox();
		TeamsTreeView = new TreeView();
		GroupBox3 = new GroupBox();
		GroupBox5 = new GroupBox();
		UmpireButton = new Button();
		ObserverButton = new Button();
		PlayersListBox = new ListBox();
		GroupBox4 = new GroupBox();
		JoinTeamButton = new Button();
		ScenarioNameTextBox = new TextBox();
		GroupBox6 = new GroupBox();
		ClearLogButton = new Button();
		GroupBox7 = new GroupBox();
		GlobalChatTextBox = new RichTextBox();
		GlobalChatButton = new Button();
		GlobalChatInputTextBox = new TextBox();
		GroupBox8 = new GroupBox();
		TeamChatTextBox = new RichTextBox();
		TeamChatButton = new Button();
		TeamChatInputTextBox = new TextBox();
		GroupBox9 = new GroupBox();
		MultiplayerStatusRichTextBox = new RichTextBox();
		CommitTurnButton = new Button();
		GroupBox10 = new GroupBox();
		TurnReplay_Pause = new Button();
		TurnReplay_Play = new Button();
		TurnReplay_Next = new Button();
		TurnReplay_Prev = new Button();
		TurnReplayListBox = new ListBox();
		TurnReplay_ReturnToPresent = new Button();
		MultiplayerOptionsGroupBox = new GroupBox();
		SpecialNoticeLabel = new Label();
		MPRuleScenarioEndButton = new CheckBox();
		SpeedChess_CommitCountdownLabel = new Label();
		SpeedChessGroupBox = new GroupBox();
		SpeedChess_MoreTimeRequestButton3 = new Button();
		SpeedChess_MoreTimeRequestButton2 = new Button();
		SpeedChess_MoreTimeRequestButton1 = new Button();
		SpeedChess_EventLabel = new Label();
		TimeTableComboBox = new ComboBox();
		UmpirePauseButton = new Button();
		UmpireResumeButton = new Button();
		ForceCommitButton = new Button();
		Label5 = new Label();
		Label6 = new Label();
		Label7 = new Label();
		AbortExecutionButton = new Button();
		((Control)GroupBox1).SuspendLayout();
		((Control)GroupBox2).SuspendLayout();
		((Control)GroupBox3).SuspendLayout();
		((Control)GroupBox5).SuspendLayout();
		((Control)GroupBox4).SuspendLayout();
		((Control)GroupBox6).SuspendLayout();
		((Control)GroupBox7).SuspendLayout();
		((Control)GroupBox8).SuspendLayout();
		((Control)GroupBox9).SuspendLayout();
		((Control)GroupBox10).SuspendLayout();
		((Control)MultiplayerOptionsGroupBox).SuspendLayout();
		((Control)SpeedChessGroupBox).SuspendLayout();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(6, 16);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(55, 13);
		((Control)Label1).TabIndex = 0;
		Label1.Text = "Username";
		((Control)UsernameTextBox).Anchor = (AnchorStyles)13;
		((Control)UsernameTextBox).Location = new Point(9, 32);
		((Control)UsernameTextBox).Name = "UsernameTextBox";
		((Control)UsernameTextBox).Size = new Size(211, 20);
		((Control)UsernameTextBox).TabIndex = 1;
		((Control)GroupBox1).Controls.Add((Control)(object)Label3);
		((Control)GroupBox1).Controls.Add((Control)(object)TeamNameTextBox);
		((Control)GroupBox1).Controls.Add((Control)(object)Label1);
		((Control)GroupBox1).Controls.Add((Control)(object)UsernameTextBox);
		((Control)GroupBox1).Location = new Point(12, 12);
		((Control)GroupBox1).Name = "GroupBox1";
		((Control)GroupBox1).Size = new Size(226, 89);
		((Control)GroupBox1).TabIndex = 2;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Player Information";
		Label3.AutoSize = true;
		((Control)Label3).Location = new Point(10, 58);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(34, 13);
		((Control)Label3).TabIndex = 3;
		Label3.Text = "Team";
		((Control)TeamNameTextBox).Location = new Point(50, 58);
		((Control)TeamNameTextBox).Name = "TeamNameTextBox";
		((TextBoxBase)TeamNameTextBox).ReadOnly = true;
		((Control)TeamNameTextBox).Size = new Size(170, 20);
		((Control)TeamNameTextBox).TabIndex = 2;
		((Control)GroupBox2).Controls.Add((Control)(object)PortTextBox);
		((Control)GroupBox2).Controls.Add((Control)(object)DisconnectButton);
		((Control)GroupBox2).Controls.Add((Control)(object)ConnectButton);
		((Control)GroupBox2).Controls.Add((Control)(object)Label4);
		((Control)GroupBox2).Controls.Add((Control)(object)Label2);
		((Control)GroupBox2).Controls.Add((Control)(object)IPTextBox);
		((Control)GroupBox2).Location = new Point(13, 107);
		((Control)GroupBox2).Name = "GroupBox2";
		((Control)GroupBox2).Size = new Size(226, 94);
		((Control)GroupBox2).TabIndex = 3;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Remote Computer";
		((Control)PortTextBox).Anchor = (AnchorStyles)9;
		((Control)PortTextBox).Location = new Point(145, 32);
		((TextBoxBase)PortTextBox).MaxLength = 8;
		((Control)PortTextBox).Name = "PortTextBox";
		((Control)PortTextBox).Size = new Size(75, 20);
		((Control)PortTextBox).TabIndex = 4;
		((Control)DisconnectButton).Anchor = (AnchorStyles)9;
		((Control)DisconnectButton).Location = new Point(145, 59);
		((Control)DisconnectButton).Name = "DisconnectButton";
		((Control)DisconnectButton).Size = new Size(75, 23);
		((Control)DisconnectButton).TabIndex = 3;
		((ButtonBase)DisconnectButton).Text = "Disconnect";
		((ButtonBase)DisconnectButton).UseVisualStyleBackColor = true;
		((Control)ConnectButton).Anchor = (AnchorStyles)6;
		((Control)ConnectButton).Location = new Point(9, 59);
		((Control)ConnectButton).Name = "ConnectButton";
		((Control)ConnectButton).Size = new Size(75, 23);
		((Control)ConnectButton).TabIndex = 2;
		((ButtonBase)ConnectButton).Text = "Connect";
		((ButtonBase)ConnectButton).UseVisualStyleBackColor = true;
		Label4.AutoSize = true;
		((Control)Label4).Location = new Point(142, 16);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(26, 13);
		((Control)Label4).TabIndex = 0;
		Label4.Text = "Port";
		Label2.AutoSize = true;
		((Control)Label2).Location = new Point(6, 16);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(17, 13);
		((Control)Label2).TabIndex = 0;
		Label2.Text = "IP";
		((Control)IPTextBox).Anchor = (AnchorStyles)13;
		((Control)IPTextBox).Location = new Point(9, 32);
		((Control)IPTextBox).Name = "IPTextBox";
		((Control)IPTextBox).Size = new Size(130, 20);
		((Control)IPTextBox).TabIndex = 1;
		IPTextBox.Text = "127.0.0.1";
		((Control)LogListBox).Anchor = (AnchorStyles)15;
		((ListControl)LogListBox).FormattingEnabled = true;
		((Control)LogListBox).Location = new Point(6, 19);
		((Control)LogListBox).Name = "LogListBox";
		((Control)LogListBox).Size = new Size(523, 95);
		((Control)LogListBox).TabIndex = 4;
		((Control)TeamsTreeView).Anchor = (AnchorStyles)15;
		((Control)TeamsTreeView).Location = new Point(6, 19);
		((Control)TeamsTreeView).Name = "TeamsTreeView";
		((Control)TeamsTreeView).Size = new Size(194, 150);
		((Control)TeamsTreeView).TabIndex = 5;
		((Control)GroupBox3).Controls.Add((Control)(object)GroupBox5);
		((Control)GroupBox3).Controls.Add((Control)(object)GroupBox4);
		((Control)GroupBox3).Controls.Add((Control)(object)ScenarioNameTextBox);
		((Control)GroupBox3).Location = new Point(14, 207);
		((Control)GroupBox3).Name = "GroupBox3";
		((Control)GroupBox3).Size = new Size(225, 461);
		((Control)GroupBox3).TabIndex = 6;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Scenario Information";
		((Control)GroupBox5).Controls.Add((Control)(object)UmpireButton);
		((Control)GroupBox5).Controls.Add((Control)(object)ObserverButton);
		((Control)GroupBox5).Controls.Add((Control)(object)PlayersListBox);
		((Control)GroupBox5).Location = new Point(8, 47);
		((Control)GroupBox5).Name = "GroupBox5";
		((Control)GroupBox5).Size = new Size(206, 199);
		((Control)GroupBox5).TabIndex = 8;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Players";
		((Control)UmpireButton).Anchor = (AnchorStyles)6;
		((Control)UmpireButton).Location = new Point(6, 141);
		((Control)UmpireButton).Name = "UmpireButton";
		((Control)UmpireButton).Size = new Size(194, 23);
		((Control)UmpireButton).TabIndex = 1;
		((ButtonBase)UmpireButton).Text = "Become Umpire";
		((ButtonBase)UmpireButton).UseVisualStyleBackColor = true;
		((Control)ObserverButton).Anchor = (AnchorStyles)6;
		((Control)ObserverButton).Location = new Point(6, 170);
		((Control)ObserverButton).Name = "ObserverButton";
		((Control)ObserverButton).Size = new Size(194, 23);
		((Control)ObserverButton).TabIndex = 9;
		((ButtonBase)ObserverButton).Text = "Become Observer";
		((ButtonBase)ObserverButton).UseVisualStyleBackColor = true;
		((Control)PlayersListBox).Anchor = (AnchorStyles)15;
		((ListControl)PlayersListBox).FormattingEnabled = true;
		((Control)PlayersListBox).Location = new Point(6, 19);
		((Control)PlayersListBox).Name = "PlayersListBox";
		((Control)PlayersListBox).Size = new Size(194, 108);
		((Control)PlayersListBox).TabIndex = 0;
		((Control)GroupBox4).Controls.Add((Control)(object)JoinTeamButton);
		((Control)GroupBox4).Controls.Add((Control)(object)TeamsTreeView);
		((Control)GroupBox4).Location = new Point(8, 251);
		((Control)GroupBox4).Name = "GroupBox4";
		((Control)GroupBox4).Size = new Size(206, 204);
		((Control)GroupBox4).TabIndex = 7;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Team Information";
		((Control)JoinTeamButton).Anchor = (AnchorStyles)6;
		((Control)JoinTeamButton).Location = new Point(6, 175);
		((Control)JoinTeamButton).Name = "JoinTeamButton";
		((Control)JoinTeamButton).Size = new Size(75, 23);
		((Control)JoinTeamButton).TabIndex = 6;
		((ButtonBase)JoinTeamButton).Text = "Join Team";
		((ButtonBase)JoinTeamButton).UseVisualStyleBackColor = true;
		((Control)ScenarioNameTextBox).Anchor = (AnchorStyles)13;
		((Control)ScenarioNameTextBox).Location = new Point(8, 20);
		((Control)ScenarioNameTextBox).Name = "ScenarioNameTextBox";
		((TextBoxBase)ScenarioNameTextBox).ReadOnly = true;
		((Control)ScenarioNameTextBox).Size = new Size(211, 20);
		((Control)ScenarioNameTextBox).TabIndex = 6;
		((Control)GroupBox6).Controls.Add((Control)(object)ClearLogButton);
		((Control)GroupBox6).Controls.Add((Control)(object)LogListBox);
		((Control)GroupBox6).Location = new Point(245, 12);
		((Control)GroupBox6).Name = "GroupBox6";
		((Control)GroupBox6).Size = new Size(535, 153);
		((Control)GroupBox6).TabIndex = 7;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Log";
		((Control)ClearLogButton).Anchor = (AnchorStyles)6;
		((Control)ClearLogButton).Location = new Point(6, 123);
		((Control)ClearLogButton).Name = "ClearLogButton";
		((Control)ClearLogButton).Size = new Size(75, 23);
		((Control)ClearLogButton).TabIndex = 5;
		((ButtonBase)ClearLogButton).Text = "Clear Log";
		((ButtonBase)ClearLogButton).UseVisualStyleBackColor = true;
		((Control)GroupBox7).Controls.Add((Control)(object)GlobalChatTextBox);
		((Control)GroupBox7).Controls.Add((Control)(object)GlobalChatButton);
		((Control)GroupBox7).Controls.Add((Control)(object)GlobalChatInputTextBox);
		((Control)GroupBox7).Location = new Point(244, 171);
		((Control)GroupBox7).Name = "GroupBox7";
		((Control)GroupBox7).Size = new Size(535, 176);
		((Control)GroupBox7).TabIndex = 8;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "Global Chat";
		((Control)GlobalChatTextBox).Anchor = (AnchorStyles)15;
		GlobalChatTextBox.Font = new Font("Lucida Console", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)GlobalChatTextBox).Location = new Point(7, 20);
		((Control)GlobalChatTextBox).Name = "GlobalChatTextBox";
		((TextBoxBase)GlobalChatTextBox).ReadOnly = true;
		((Control)GlobalChatTextBox).Size = new Size(522, 122);
		((Control)GlobalChatTextBox).TabIndex = 3;
		GlobalChatTextBox.Text = "";
		((Control)GlobalChatButton).Anchor = (AnchorStyles)6;
		((Control)GlobalChatButton).Location = new Point(454, 146);
		((Control)GlobalChatButton).Name = "GlobalChatButton";
		((Control)GlobalChatButton).Size = new Size(75, 22);
		((Control)GlobalChatButton).TabIndex = 2;
		((ButtonBase)GlobalChatButton).Text = "Send";
		((ButtonBase)GlobalChatButton).UseVisualStyleBackColor = true;
		((Control)GlobalChatInputTextBox).Anchor = (AnchorStyles)6;
		((Control)GlobalChatInputTextBox).Font = new Font("Lucida Console", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)GlobalChatInputTextBox).Location = new Point(6, 148);
		((Control)GlobalChatInputTextBox).Name = "GlobalChatInputTextBox";
		((Control)GlobalChatInputTextBox).Size = new Size(440, 18);
		((Control)GlobalChatInputTextBox).TabIndex = 1;
		((Control)GroupBox8).Controls.Add((Control)(object)TeamChatTextBox);
		((Control)GroupBox8).Controls.Add((Control)(object)TeamChatButton);
		((Control)GroupBox8).Controls.Add((Control)(object)TeamChatInputTextBox);
		((Control)GroupBox8).Location = new Point(1053, 289);
		((Control)GroupBox8).Name = "GroupBox8";
		((Control)GroupBox8).Size = new Size(407, 419);
		((Control)GroupBox8).TabIndex = 9;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "Team Chat";
		((Control)GroupBox8).Visible = false;
		((Control)TeamChatTextBox).Anchor = (AnchorStyles)15;
		TeamChatTextBox.Font = new Font("Lucida Console", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TeamChatTextBox).Location = new Point(7, 20);
		((Control)TeamChatTextBox).Name = "TeamChatTextBox";
		((TextBoxBase)TeamChatTextBox).ReadOnly = true;
		((Control)TeamChatTextBox).Size = new Size(393, 366);
		((Control)TeamChatTextBox).TabIndex = 3;
		TeamChatTextBox.Text = "";
		((Control)TeamChatButton).Anchor = (AnchorStyles)10;
		((Control)TeamChatButton).Location = new Point(325, 391);
		((Control)TeamChatButton).Name = "TeamChatButton";
		((Control)TeamChatButton).Size = new Size(75, 22);
		((Control)TeamChatButton).TabIndex = 2;
		((ButtonBase)TeamChatButton).Text = "Send";
		((ButtonBase)TeamChatButton).UseVisualStyleBackColor = true;
		((Control)TeamChatInputTextBox).Anchor = (AnchorStyles)14;
		((Control)TeamChatInputTextBox).Font = new Font("Lucida Console", 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TeamChatInputTextBox).Location = new Point(7, 393);
		((Control)TeamChatInputTextBox).Name = "TeamChatInputTextBox";
		((Control)TeamChatInputTextBox).Size = new Size(313, 18);
		((Control)TeamChatInputTextBox).TabIndex = 1;
		((Control)GroupBox9).Controls.Add((Control)(object)MultiplayerStatusRichTextBox);
		((Control)GroupBox9).Controls.Add((Control)(object)CommitTurnButton);
		((Control)GroupBox9).Location = new Point(246, 353);
		((Control)GroupBox9).Name = "GroupBox9";
		((Control)GroupBox9).Size = new Size(234, 207);
		((Control)GroupBox9).TabIndex = 10;
		GroupBox9.TabStop = false;
		GroupBox9.Text = "Multiplayer Turn";
		((Control)MultiplayerStatusRichTextBox).Anchor = (AnchorStyles)15;
		((Control)MultiplayerStatusRichTextBox).Location = new Point(8, 75);
		((Control)MultiplayerStatusRichTextBox).Name = "MultiplayerStatusRichTextBox";
		((TextBoxBase)MultiplayerStatusRichTextBox).ReadOnly = true;
		((Control)MultiplayerStatusRichTextBox).Size = new Size(216, 124);
		((Control)MultiplayerStatusRichTextBox).TabIndex = 3;
		MultiplayerStatusRichTextBox.Text = "";
		((Control)CommitTurnButton).Location = new Point(7, 19);
		((Control)CommitTurnButton).Name = "CommitTurnButton";
		((Control)CommitTurnButton).Size = new Size(219, 50);
		((Control)CommitTurnButton).TabIndex = 1;
		((ButtonBase)CommitTurnButton).Text = "COMMIT TURN";
		((ButtonBase)CommitTurnButton).UseVisualStyleBackColor = true;
		((Control)GroupBox10).Controls.Add((Control)(object)TurnReplay_Pause);
		((Control)GroupBox10).Controls.Add((Control)(object)TurnReplay_Play);
		((Control)GroupBox10).Controls.Add((Control)(object)TurnReplay_Next);
		((Control)GroupBox10).Controls.Add((Control)(object)TurnReplay_Prev);
		((Control)GroupBox10).Controls.Add((Control)(object)TurnReplayListBox);
		((Control)GroupBox10).Controls.Add((Control)(object)TurnReplay_ReturnToPresent);
		((Control)GroupBox10).Location = new Point(158, 674);
		((Control)GroupBox10).Name = "GroupBox10";
		((Control)GroupBox10).Size = new Size(293, 207);
		((Control)GroupBox10).TabIndex = 11;
		GroupBox10.TabStop = false;
		GroupBox10.Text = "Turn Replay";
		((Control)GroupBox10).Visible = false;
		((Control)TurnReplay_Pause).Location = new Point(45, 19);
		((Control)TurnReplay_Pause).Name = "TurnReplay_Pause";
		((Control)TurnReplay_Pause).Size = new Size(33, 23);
		((Control)TurnReplay_Pause).TabIndex = 3;
		((ButtonBase)TurnReplay_Pause).Text = "||";
		((ButtonBase)TurnReplay_Pause).UseVisualStyleBackColor = true;
		((Control)TurnReplay_Play).Location = new Point(83, 19);
		((Control)TurnReplay_Play).Name = "TurnReplay_Play";
		((Control)TurnReplay_Play).Size = new Size(33, 23);
		((Control)TurnReplay_Play).TabIndex = 3;
		((ButtonBase)TurnReplay_Play).Text = "▶";
		((ButtonBase)TurnReplay_Play).UseVisualStyleBackColor = true;
		((Control)TurnReplay_Next).Location = new Point(122, 19);
		((Control)TurnReplay_Next).Name = "TurnReplay_Next";
		((Control)TurnReplay_Next).Size = new Size(33, 23);
		((Control)TurnReplay_Next).TabIndex = 2;
		((ButtonBase)TurnReplay_Next).Text = ">>";
		((ButtonBase)TurnReplay_Next).UseVisualStyleBackColor = true;
		((Control)TurnReplay_Prev).Location = new Point(6, 19);
		((Control)TurnReplay_Prev).Name = "TurnReplay_Prev";
		((Control)TurnReplay_Prev).Size = new Size(33, 23);
		((Control)TurnReplay_Prev).TabIndex = 2;
		((ButtonBase)TurnReplay_Prev).Text = "<<";
		((ButtonBase)TurnReplay_Prev).UseVisualStyleBackColor = true;
		((ListControl)TurnReplayListBox).DisplayMember = "DisplayMember";
		((ListControl)TurnReplayListBox).FormattingEnabled = true;
		((Control)TurnReplayListBox).Location = new Point(6, 48);
		((Control)TurnReplayListBox).Name = "TurnReplayListBox";
		((Control)TurnReplayListBox).Size = new Size(277, 147);
		((Control)TurnReplayListBox).TabIndex = 1;
		((Control)TurnReplay_ReturnToPresent).Location = new Point(161, 19);
		((Control)TurnReplay_ReturnToPresent).Name = "TurnReplay_ReturnToPresent";
		((Control)TurnReplay_ReturnToPresent).Size = new Size(122, 23);
		((Control)TurnReplay_ReturnToPresent).TabIndex = 0;
		((ButtonBase)TurnReplay_ReturnToPresent).Text = "Return to Present";
		((ButtonBase)TurnReplay_ReturnToPresent).UseVisualStyleBackColor = true;
		((Control)MultiplayerOptionsGroupBox).Controls.Add((Control)(object)SpecialNoticeLabel);
		((Control)MultiplayerOptionsGroupBox).Controls.Add((Control)(object)MPRuleScenarioEndButton);
		((Control)MultiplayerOptionsGroupBox).Location = new Point(736, 659);
		((Control)MultiplayerOptionsGroupBox).Name = "MultiplayerOptionsGroupBox";
		((Control)MultiplayerOptionsGroupBox).Size = new Size(294, 101);
		((Control)MultiplayerOptionsGroupBox).TabIndex = 12;
		MultiplayerOptionsGroupBox.TabStop = false;
		MultiplayerOptionsGroupBox.Text = "Multiplayer Events";
		((Control)MultiplayerOptionsGroupBox).Visible = false;
		SpecialNoticeLabel.AutoSize = true;
		((Control)SpecialNoticeLabel).Location = new Point(6, 16);
		((Control)SpecialNoticeLabel).Name = "SpecialNoticeLabel";
		((Control)SpecialNoticeLabel).Size = new Size(0, 13);
		((Control)SpecialNoticeLabel).TabIndex = 1;
		MPRuleScenarioEndButton.Appearance = (Appearance)1;
		((ButtonBase)MPRuleScenarioEndButton).AutoSize = true;
		((Control)MPRuleScenarioEndButton).Location = new Point(9, 37);
		((Control)MPRuleScenarioEndButton).Name = "MPRuleScenarioEndButton";
		((Control)MPRuleScenarioEndButton).Size = new Size(124, 23);
		((Control)MPRuleScenarioEndButton).TabIndex = 0;
		((ButtonBase)MPRuleScenarioEndButton).Text = "Request End Scenario";
		((ButtonBase)MPRuleScenarioEndButton).UseVisualStyleBackColor = true;
		((Control)MPRuleScenarioEndButton).Visible = false;
		SpeedChess_CommitCountdownLabel.AutoSize = true;
		((Control)SpeedChess_CommitCountdownLabel).Location = new Point(5, 16);
		((Control)SpeedChess_CommitCountdownLabel).Name = "SpeedChess_CommitCountdownLabel";
		((Control)SpeedChess_CommitCountdownLabel).Size = new Size(187, 13);
		((Control)SpeedChess_CommitCountdownLabel).TabIndex = 1;
		SpeedChess_CommitCountdownLabel.Text = "SpeedChess_CommitCountdownLabel";
		((Control)SpeedChessGroupBox).Controls.Add((Control)(object)SpeedChess_MoreTimeRequestButton3);
		((Control)SpeedChessGroupBox).Controls.Add((Control)(object)SpeedChess_MoreTimeRequestButton2);
		((Control)SpeedChessGroupBox).Controls.Add((Control)(object)SpeedChess_MoreTimeRequestButton1);
		((Control)SpeedChessGroupBox).Controls.Add((Control)(object)SpeedChess_EventLabel);
		((Control)SpeedChessGroupBox).Controls.Add((Control)(object)SpeedChess_CommitCountdownLabel);
		((Control)SpeedChessGroupBox).Location = new Point(486, 660);
		((Control)SpeedChessGroupBox).Name = "SpeedChessGroupBox";
		((Control)SpeedChessGroupBox).Size = new Size(235, 100);
		((Control)SpeedChessGroupBox).TabIndex = 13;
		SpeedChessGroupBox.TabStop = false;
		SpeedChessGroupBox.Text = "Speed Chess";
		((Control)SpeedChessGroupBox).Visible = false;
		((Control)SpeedChess_MoreTimeRequestButton3).Location = new Point(162, 71);
		((Control)SpeedChess_MoreTimeRequestButton3).Name = "SpeedChess_MoreTimeRequestButton3";
		((Control)SpeedChess_MoreTimeRequestButton3).Size = new Size(67, 23);
		((Control)SpeedChess_MoreTimeRequestButton3).TabIndex = 3;
		((ButtonBase)SpeedChess_MoreTimeRequestButton3).Text = "+5 min";
		((ButtonBase)SpeedChess_MoreTimeRequestButton3).UseVisualStyleBackColor = true;
		((Control)SpeedChess_MoreTimeRequestButton2).Location = new Point(87, 71);
		((Control)SpeedChess_MoreTimeRequestButton2).Name = "SpeedChess_MoreTimeRequestButton2";
		((Control)SpeedChess_MoreTimeRequestButton2).Size = new Size(67, 23);
		((Control)SpeedChess_MoreTimeRequestButton2).TabIndex = 3;
		((ButtonBase)SpeedChess_MoreTimeRequestButton2).Text = "+1 min";
		((ButtonBase)SpeedChess_MoreTimeRequestButton2).UseVisualStyleBackColor = true;
		((Control)SpeedChess_MoreTimeRequestButton1).Location = new Point(9, 71);
		((Control)SpeedChess_MoreTimeRequestButton1).Name = "SpeedChess_MoreTimeRequestButton1";
		((Control)SpeedChess_MoreTimeRequestButton1).Size = new Size(67, 23);
		((Control)SpeedChess_MoreTimeRequestButton1).TabIndex = 3;
		((ButtonBase)SpeedChess_MoreTimeRequestButton1).Text = "+10 sec";
		((ButtonBase)SpeedChess_MoreTimeRequestButton1).UseVisualStyleBackColor = true;
		SpeedChess_EventLabel.AutoSize = true;
		((Control)SpeedChess_EventLabel).Font = new Font("Microsoft Sans Serif", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)SpeedChess_EventLabel).ForeColor = SystemColors.Highlight;
		((Control)SpeedChess_EventLabel).Location = new Point(6, 32);
		((Control)SpeedChess_EventLabel).MaximumSize = new Size(200, 0);
		((Control)SpeedChess_EventLabel).Name = "SpeedChess_EventLabel";
		((Control)SpeedChess_EventLabel).Size = new Size(148, 13);
		((Control)SpeedChess_EventLabel).TabIndex = 2;
		SpeedChess_EventLabel.Text = "SpeedChess_EventLabel";
		TimeTableComboBox.DropDownStyle = (ComboBoxStyle)2;
		((Control)TimeTableComboBox).Font = new Font("Microsoft Sans Serif", 14.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)TimeTableComboBox).FormattingEnabled = true;
		((Control)TimeTableComboBox).Location = new Point(246, 567);
		((Control)TimeTableComboBox).Name = "TimeTableComboBox";
		((Control)TimeTableComboBox).Size = new Size(534, 32);
		((Control)TimeTableComboBox).TabIndex = 14;
		((Control)TimeTableComboBox).Visible = false;
		((Control)UmpirePauseButton).Location = new Point(646, 604);
		((Control)UmpirePauseButton).Name = "UmpirePauseButton";
		((Control)UmpirePauseButton).Size = new Size(134, 23);
		((Control)UmpirePauseButton).TabIndex = 15;
		((ButtonBase)UmpirePauseButton).Text = "Pause Game";
		((ButtonBase)UmpirePauseButton).UseVisualStyleBackColor = true;
		((Control)UmpirePauseButton).Visible = false;
		((Control)UmpireResumeButton).Location = new Point(646, 633);
		((Control)UmpireResumeButton).Name = "UmpireResumeButton";
		((Control)UmpireResumeButton).Size = new Size(134, 23);
		((Control)UmpireResumeButton).TabIndex = 15;
		((ButtonBase)UmpireResumeButton).Text = "Resume Game";
		((ButtonBase)UmpireResumeButton).UseVisualStyleBackColor = true;
		((Control)UmpireResumeButton).Visible = false;
		((Control)ForceCommitButton).Location = new Point(507, 604);
		((Control)ForceCommitButton).Name = "ForceCommitButton";
		((Control)ForceCommitButton).Size = new Size(134, 23);
		((Control)ForceCommitButton).TabIndex = 15;
		((ButtonBase)ForceCommitButton).Text = "Force All Players Commit";
		((ButtonBase)ForceCommitButton).UseVisualStyleBackColor = true;
		((Control)ForceCommitButton).Visible = false;
		Label5.AutoSize = true;
		((Control)Label5).Location = new Point(246, 604);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(0, 13);
		((Control)Label5).TabIndex = 16;
		Label6.AutoSize = true;
		((Control)Label6).Location = new Point(246, 617);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(0, 13);
		((Control)Label6).TabIndex = 16;
		Label7.AutoSize = true;
		((Control)Label7).Location = new Point(246, 630);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(0, 13);
		((Control)Label7).TabIndex = 17;
		((Control)AbortExecutionButton).ForeColor = Color.Red;
		((Control)AbortExecutionButton).Location = new Point(507, 633);
		((Control)AbortExecutionButton).Name = "AbortExecutionButton";
		((Control)AbortExecutionButton).Size = new Size(134, 23);
		((Control)AbortExecutionButton).TabIndex = 15;
		((ButtonBase)AbortExecutionButton).Text = "Abort Server Execution";
		((ButtonBase)AbortExecutionButton).UseVisualStyleBackColor = true;
		((Control)AbortExecutionButton).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(788, 680);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)UmpireResumeButton);
		((Control)this).Controls.Add((Control)(object)AbortExecutionButton);
		((Control)this).Controls.Add((Control)(object)ForceCommitButton);
		((Control)this).Controls.Add((Control)(object)UmpirePauseButton);
		((Control)this).Controls.Add((Control)(object)TimeTableComboBox);
		((Control)this).Controls.Add((Control)(object)SpeedChessGroupBox);
		((Control)this).Controls.Add((Control)(object)MultiplayerOptionsGroupBox);
		((Control)this).Controls.Add((Control)(object)GroupBox10);
		((Control)this).Controls.Add((Control)(object)GroupBox9);
		((Control)this).Controls.Add((Control)(object)GroupBox7);
		((Control)this).Controls.Add((Control)(object)GroupBox6);
		((Control)this).Controls.Add((Control)(object)GroupBox3);
		((Control)this).Controls.Add((Control)(object)GroupBox2);
		((Control)this).Controls.Add((Control)(object)GroupBox1);
		((Control)this).Controls.Add((Control)(object)GroupBox8);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).MaximizeBox = false;
		((Control)this).Name = "MultiplayerForm";
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).Text = "Multiplayer";
		((Form)this).TopMost = true;
		((Control)GroupBox1).ResumeLayout(false);
		((Control)GroupBox1).PerformLayout();
		((Control)GroupBox2).ResumeLayout(false);
		((Control)GroupBox2).PerformLayout();
		((Control)GroupBox3).ResumeLayout(false);
		((Control)GroupBox3).PerformLayout();
		((Control)GroupBox5).ResumeLayout(false);
		((Control)GroupBox4).ResumeLayout(false);
		((Control)GroupBox6).ResumeLayout(false);
		((Control)GroupBox7).ResumeLayout(false);
		((Control)GroupBox7).PerformLayout();
		((Control)GroupBox8).ResumeLayout(false);
		((Control)GroupBox8).PerformLayout();
		((Control)GroupBox9).ResumeLayout(false);
		((Control)GroupBox10).ResumeLayout(false);
		((Control)MultiplayerOptionsGroupBox).ResumeLayout(false);
		((Control)MultiplayerOptionsGroupBox).PerformLayout();
		((Control)SpeedChessGroupBox).ResumeLayout(false);
		((Control)SpeedChessGroupBox).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_0()
	{
		if (Client.CurrentScenario == null)
		{
			return;
		}
		ConcurrentDictionary<long, LoggedMessage> concurrentDictionary = new ConcurrentDictionary<long, LoggedMessage>();
		foreach (LoggedMessage item in Client.CurrentScenario.MessageLog)
		{
			if (SimConfiguration.DefaultGamePreferences.MessageLogSettings.ContainsKey(item.Type) && SimConfiguration.DefaultGamePreferences.MessageLogSettings[item.Type].ShowOnMessageLog)
			{
				concurrentDictionary.TryAdd(item.Increment, item);
			}
		}
		Client.CurrentScenario.MessageLog = concurrentDictionary.Values.ToList();
	}

	static MultiplayerForm()
	{
		Class72.smethod_20();
	}
}
