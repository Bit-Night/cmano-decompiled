using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Command.SlitherinePBEM3;
using Command.SlitherinePBEM3.Models;
using CommandNetcode.RT.PlayFabWrapper;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Steamworks;

namespace Command;

[DesignerGenerated]
public class RealtimeLobby : DarkSecondaryFormBase
{
	public struct PlayerInfoStruct
	{
		public string Name;

		public int ID;

		public string string_0;

		public int State;

		public string HostedScenarioName;

		public string HostedScenarioDescription;

		public DateTime LastUpdate;
	}

	private struct Struct6
	{
		public string string_0;

		public int int_0;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_113_RealtimeLobby_Load : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal RealtimeLobby $VB$Me;

		internal Task<string> $VB$ResumableLocal_t0$0;

		internal Task<GeneralResponseModel<List<SerialVerificationModel>>> $VB$ResumableLocal_t2$1;

		internal TaskAwaiter<string> $A0;

		internal TaskAwaiter<GeneralResponseModel<List<SerialVerificationModel>>> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_0507: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0430: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05bd: Invalid comparison between Unknown and I4
			int num = $State;
			try
			{
				switch (num)
				{
				default:
					((DataGridView)$VB$Me.PlayerGridView).EnableHeadersVisualStyles = false;
					((DataGridView)$VB$Me.PlayerGridView).ColumnHeadersDefaultCellStyle.SelectionBackColor = ((DataGridView)$VB$Me.PlayerGridView).ColumnHeadersDefaultCellStyle.BackColor;
					if (Client.CurrentGame.Status == Game._GameStatus.Running)
					{
						Client.CurrentGame.Pause();
					}
					$VB$Me.int_0 = 0;
					$VB$Me.int_2 = 0;
					$VB$Me.ContinueConnection = false;
					$VB$Me.HostedScenarioName = "";
					$VB$Me.HostedScenarioDesc = "";
					$VB$Me.HostedScenarioFilePath = "";
					$VB$Me.dByHggGwteJ();
					if (Client.RunningInSteamMode || !string.IsNullOrEmpty($VB$Me.SerialNumber))
					{
						$VB$Me.Button_Host.Enabled = true;
						$VB$Me.Button_Join.Enabled = false;
						$VB$Me.PingTimer.Enabled = false;
						$VB$Me.PingTimer.Interval = 250;
						$VB$Me.int_0 = 1;
						goto case -3;
					}
					DarkMessageBox.ShowError("Unable to locate your product serial number. Please re-install.", "Error");
					$VB$Me.method_20();
					goto end_IL_0008;
				case -3:
				case 0:
					try
					{
						if (num == -3)
						{
							num = -1;
							$State = -1;
							return;
						}
						TaskAwaiter<string> awaiter;
						if (num != 0)
						{
							((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Connecting to Lobby...";
							((Form)MyProject.Forms.RealtimeLobbyLoginWait).Show((IWin32Window)(object)$VB$Me);
							((Form)MyProject.Forms.RealtimeLobbyLoginWait).Activate();
							$VB$ResumableLocal_t0$0 = ApiMethods.smethod_0();
							awaiter = $VB$ResumableLocal_t0$0.GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								$State = 0;
								$A0 = awaiter;
								$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
						}
						else
						{
							num = -1;
							$State = -1;
							awaiter = $A0;
							$A0 = default(TaskAwaiter<string>);
						}
						awaiter.GetResult();
						awaiter = default(TaskAwaiter<string>);
						if (!string.IsNullOrEmpty($VB$ResumableLocal_t0$0.Result))
						{
							SlitherineLobby.string_0 = "https://" + $VB$ResumableLocal_t0$0.Result;
							goto IL_02e5;
						}
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						DarkMessageBox.ShowError("Unable to locate Slitherine lobby server.  Please try again.", "Error");
						$VB$Me.method_20();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
						DarkMessageBox.ShowError("Unable to locate Slitherine lobby server. Please try again." + ex2.Message, "Error");
						$VB$Me.method_20();
						ProjectData.ClearProjectError();
					}
					goto end_IL_0008;
				case -4:
				case 1:
					{
						try
						{
							if (num == -4)
							{
								num = -1;
								$State = -1;
								return;
							}
							TaskAwaiter<GeneralResponseModel<List<SerialVerificationModel>>> awaiter2;
							if (num != 1)
							{
								((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Verifying your serial number...";
								if (!((Control)MyProject.Forms.RealtimeLobbyLoginWait).Visible)
								{
									((Form)MyProject.Forms.RealtimeLobbyLoginWait).Show((IWin32Window)(object)$VB$Me);
								}
								$VB$ResumableLocal_t2$1 = ApiMethods.VerifySerialAsync(SlitherineLobby.string_0, $VB$Me.SerialNumber);
								awaiter2 = $VB$ResumableLocal_t2$1.GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = 1;
									$State = 1;
									$A1 = awaiter2;
									$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
									return;
								}
							}
							else
							{
								num = -1;
								$State = -1;
								awaiter2 = $A1;
								$A1 = default(TaskAwaiter<GeneralResponseModel<List<SerialVerificationModel>>>);
							}
							awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<GeneralResponseModel<List<SerialVerificationModel>>>);
							if ($VB$ResumableLocal_t2$1.Result.Message.ErrorCode != 0)
							{
								((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
								DarkMessageBox.ShowError("Error verifying serial number - " + $VB$ResumableLocal_t2$1.Result.Message.ErrorComment, "Error");
								$VB$Me.method_20();
							}
							else
							{
								if ($VB$ResumableLocal_t2$1.Result.Result != null && $VB$ResumableLocal_t2$1.Result.Result.Count >= 1 && $VB$ResumableLocal_t2$1.Result.Result[0].GameID == 353)
								{
									goto end_IL_0311;
								}
								((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
								DarkMessageBox.ShowError("Failed to verify serial number.", "Error");
								$VB$Me.method_20();
							}
							goto end_IL_0008;
							end_IL_0311:;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
							DarkMessageBox.ShowError("Error verifying serial number. " + ex4.Message, "Error");
							$VB$Me.method_20();
							ProjectData.ClearProjectError();
							goto end_IL_0008;
						}
						$VB$Me.VerifiedSerialNumber = $VB$Me.SerialNumber;
						break;
					}
					IL_02e5:
					if (Client.RunningInSteamMode || Operators.CompareString($VB$Me.SerialNumber, $VB$Me.VerifiedSerialNumber, true) == 0)
					{
						break;
					}
					goto case -4;
				}
				if (((Control)MyProject.Forms.RealtimeLobbyLoginWait).Visible)
				{
					((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
				}
				if (SlitherineLobby.UserLoginInfo != null && SlitherineLobby.UserLoginInfo.UserID > 0)
				{
					$VB$Me.UserName = SlitherineLobby.UserLoginInfo.Username;
					$VB$Me.Password = SlitherineLobby.UserLoginInfo.Password;
					$VB$Me.UserID = SlitherineLobby.UserLoginInfo.UserID;
					goto IL_0619;
				}
				if ((int)((Form)MyProject.Forms.RealtimeLobbyLogin).ShowDialog() != 2)
				{
					$VB$Me.UserName = SlitherineLobby.UserLoginInfo.Username;
					$VB$Me.Password = SlitherineLobby.UserLoginInfo.Password;
					$VB$Me.UserID = SlitherineLobby.UserLoginInfo.UserID;
					$VB$Me.method_8();
					goto IL_0619;
				}
				$VB$Me.method_20();
				goto end_IL_0008;
				IL_0619:
				$VB$Me.method_26();
				$VB$Me.Connected = true;
				$VB$Me.PingTimer.Tick += $VB$Me.method_10;
				SlitherineLobby.OnPlayerInfoRequest += $VB$Me.HandleRoutingServerPlayerInfoRequest;
				SlitherineLobby.OnPlayerInfoUpdated += $VB$Me.HandleRoutingServerPlayerInfoUpdate;
				SlitherineLobby.OnPlayerDisconnected += $VB$Me.HandleRoutingServerPlayerDisconnect;
				SlitherineLobby.OnPlayerJoinRequest += $VB$Me.HandleRoutingServerPlayerJoinRequest;
				SlitherineLobby.OnPlayerJoinAccept += $VB$Me.HandleRoutingServerPlayerJoinAccept;
				SlitherineLobby.OnPlayerJoinDecline += $VB$Me.HandleRoutingServerPlayerJoinDecline;
				SlitherineLobby.OnRoutingServerError += $VB$Me.HandleRoutingServerError;
				$VB$Me.method_28();
				end_IL_0008:;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception exception = ex5;
				$State = -2;
				$Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = -2;
			$State = -2;
			$Builder.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			$Builder.SetStateMachine(stateMachine);
		}

		static VB$StateMachine_113_RealtimeLobby_Load()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Host")]
	private DarkUIButton _Button_Host;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Join")]
	private DarkUIButton _Button_Join;

	[AccessedThroughProperty("Button_Exit")]
	[CompilerGenerated]
	private DarkUIButton _Button_Exit;

	[AccessedThroughProperty("PlayerGridView")]
	[CompilerGenerated]
	private DarkDataGridView _PlayerGridView;

	[CompilerGenerated]
	private bool bool_2;

	public string UserName;

	public string Password;

	public string SerialNumber;

	public string SteamToken;

	private HAuthTicket hauthTicket_0;

	public int UserID;

	public int UserState;

	public string VerifiedSerialNumber;

	public int PendingOpponentID;

	public int CommandHostUserID;

	public string HostedScenarioName;

	public string HostedScenarioDesc;

	public string HostedScenarioFilePath;

	public string RoutingServerIP;

	public int RoutingServerPort;

	public string PlayFabNetworkId;

	public string PlayFabInviteCode;

	public bool ContinueConnection;

	public bool Connected;

	private int int_0;

	private Socket socket_0;

	private int int_1;

	private PlayerInfoStruct[] playerInfoStruct_0;

	public Timer PingTimer;

	public const int PingInterval_s = 60;

	private DateTime dateTime_0;

	private int int_2;

	private Thread thread_0;

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkUIButton Button_Host
	{
		[CompilerGenerated]
		get
		{
			return _Button_Host;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_17;
			DarkUIButton darkUIButton = _Button_Host;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Host = value;
			darkUIButton = _Button_Host;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Join
	{
		[CompilerGenerated]
		get
		{
			return _Button_Join;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_18;
			DarkUIButton darkUIButton = _Button_Join;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Join = value;
			darkUIButton = _Button_Join;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkUIButton Button_Exit
	{
		[CompilerGenerated]
		get
		{
			return _Button_Exit;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_11;
			DarkUIButton darkUIButton = _Button_Exit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Exit = value;
			darkUIButton = _Button_Exit;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual DarkDataGridView PlayerGridView
	{
		[CompilerGenerated]
		get
		{
			return _PlayerGridView;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkDataGridView darkDataGridView = _PlayerGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged -= eventHandler;
			}
			_PlayerGridView = value;
			darkDataGridView = _PlayerGridView;
			if (darkDataGridView != null)
			{
				((DataGridView)darkDataGridView).SelectionChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("HostInfoGroupBox")]
	internal virtual DarkGroupBox HostInfoGroupBox { get; set; }

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	[field: AccessedThroughProperty("Text_ScenarioDesc")]
	internal virtual DarkTextBox Text_ScenarioDesc { get; set; }

	[field: AccessedThroughProperty("Label_ScenarioName")]
	internal virtual DarkLabel Label_ScenarioName { get; set; }

	[field: AccessedThroughProperty("PlayerID")]
	internal virtual DataGridViewTextBoxColumn PlayerID { get; set; }

	[field: AccessedThroughProperty("PlayerName")]
	internal virtual DataGridViewTextBoxColumn PlayerName { get; set; }

	[field: AccessedThroughProperty("Status")]
	internal virtual DataGridViewTextBoxColumn Status { get; set; }

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

	public RealtimeLobby()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		((Form)this).Load += RealtimeLobby_Load;
		((Form)this).FormClosed += (FormClosedEventHandler)([SpecialName] (object sender, FormClosedEventArgs e) =>
		{
			method_19();
		});
		RTMPEnabled = true;
		hauthTicket_0 = HAuthTicket.Invalid;
		VerifiedSerialNumber = "";
		ContinueConnection = false;
		Connected = false;
		int_0 = 0;
		int_1 = 0;
		playerInfoStruct_0 = new PlayerInfoStruct[0];
		PingTimer = new Timer();
		dateTime_0 = DateTime.Now;
		int_2 = 0;
		thread_0 = null;
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
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected O, but got Unknown
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DarkLabel1 = new DarkLabel();
		Button_Host = new DarkUIButton();
		Button_Join = new DarkUIButton();
		Button_Exit = new DarkUIButton();
		PlayerGridView = new DarkDataGridView();
		PlayerID = new DataGridViewTextBoxColumn();
		PlayerName = new DataGridViewTextBoxColumn();
		Status = new DataGridViewTextBoxColumn();
		HostInfoGroupBox = new DarkGroupBox();
		Label_ScenarioName = new DarkLabel();
		Text_ScenarioDesc = new DarkTextBox();
		DarkLabel4 = new DarkLabel();
		((ISupportInitialize)(object)PlayerGridView).BeginInit();
		((Control)HostInfoGroupBox).SuspendLayout();
		((Control)this).SuspendLayout();
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(12, 9);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(108, 15);
		((Control)DarkLabel1).TabIndex = 0;
		((Label)DarkLabel1).Text = "Connected Players:";
		((Control)Button_Host).Anchor = (AnchorStyles)1;
		((Control)Button_Host).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Host).Location = new Point(378, 50);
		((Control)Button_Host).Name = "Button_Host";
		((Control)Button_Host).Padding = new Padding(5);
		Button_Host.RoundRadius = 0;
		((Control)Button_Host).Size = new Size(96, 23);
		((Control)Button_Host).TabIndex = 1;
		Button_Host.Text = "Host";
		((Control)Button_Join).Anchor = (AnchorStyles)1;
		((Control)Button_Join).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Join).Location = new Point(378, 89);
		((Control)Button_Join).Name = "Button_Join";
		((Control)Button_Join).Padding = new Padding(5);
		Button_Join.RoundRadius = 0;
		((Control)Button_Join).Size = new Size(96, 23);
		((Control)Button_Join).TabIndex = 2;
		Button_Join.Text = "Join";
		((Control)Button_Exit).Anchor = (AnchorStyles)2;
		((Control)Button_Exit).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_Exit).Location = new Point(346, 431);
		((Control)Button_Exit).Name = "Button_Exit";
		((Control)Button_Exit).Padding = new Padding(5);
		Button_Exit.RoundRadius = 0;
		((Control)Button_Exit).Size = new Size(108, 23);
		((Control)Button_Exit).TabIndex = 3;
		Button_Exit.Text = "Exit Lobby";
		((DataGridView)PlayerGridView).AllowUserToAddRows = false;
		((DataGridView)PlayerGridView).AllowUserToDeleteRows = false;
		((DataGridView)PlayerGridView).AllowUserToOrderColumns = true;
		((DataGridView)PlayerGridView).AllowUserToResizeColumns = false;
		((DataGridView)PlayerGridView).AllowUserToResizeRows = false;
		((Control)PlayerGridView).Anchor = (AnchorStyles)7;
		((DataGridView)PlayerGridView).BackgroundColor = Color.FromArgb(60, 63, 65);
		((DataGridView)PlayerGridView).BorderStyle = (BorderStyle)2;
		((DataGridView)PlayerGridView).CellBorderStyle = (DataGridViewCellBorderStyle)8;
		((DataGridView)PlayerGridView).ClipboardCopyMode = (DataGridViewClipboardCopyMode)2;
		((DataGridView)PlayerGridView).ColumnHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val.Alignment = (DataGridViewContentAlignment)16;
		val.BackColor = Color.FromArgb(66, 77, 95);
		val.Font = new Font("Segoe UI", 9f);
		val.ForeColor = Color.LightGray;
		val.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val.WrapMode = (DataGridViewTriState)1;
		((DataGridView)PlayerGridView).ColumnHeadersDefaultCellStyle = val;
		((DataGridView)PlayerGridView).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)2;
		((DataGridView)PlayerGridView).Columns.AddRange((DataGridViewColumn[])(object)new DataGridViewColumn[3]
		{
			(DataGridViewColumn)PlayerID,
			(DataGridViewColumn)PlayerName,
			(DataGridViewColumn)Status
		});
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = Color.FromArgb(60, 63, 65);
		val2.Font = new Font("Segoe UI", 9f);
		val2.ForeColor = Color.LightGray;
		val2.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val2.SelectionForeColor = Color.FromArgb(122, 128, 132);
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)PlayerGridView).DefaultCellStyle = val2;
		((DataGridView)PlayerGridView).EnableHeadersVisualStyles = false;
		((Control)PlayerGridView).Location = new Point(9, 31);
		((DataGridView)PlayerGridView).MultiSelect = false;
		((Control)PlayerGridView).Name = "PlayerGridView";
		((DataGridView)PlayerGridView).ReadOnly = true;
		((DataGridView)PlayerGridView).RowHeadersBorderStyle = (DataGridViewHeaderBorderStyle)4;
		val3.BackColor = Color.FromArgb(60, 63, 65);
		val3.Font = new Font("Segoe UI", 9f);
		val3.ForeColor = Color.LightGray;
		val3.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val3.SelectionForeColor = Color.LightGray;
		((DataGridView)PlayerGridView).RowHeadersDefaultCellStyle = val3;
		((DataGridView)PlayerGridView).RowHeadersVisible = false;
		((DataGridView)PlayerGridView).RowHeadersWidth = 32;
		((DataGridView)PlayerGridView).RowHeadersWidthSizeMode = (DataGridViewRowHeadersWidthSizeMode)1;
		val4.BackColor = Color.FromArgb(60, 63, 65);
		val4.ForeColor = Color.LightGray;
		val4.SelectionBackColor = Color.FromArgb(75, 110, 175);
		val4.SelectionForeColor = Color.LightGray;
		((DataGridView)PlayerGridView).RowsDefaultCellStyle = val4;
		((DataGridView)PlayerGridView).SelectionMode = (DataGridViewSelectionMode)1;
		((DataGridView)PlayerGridView).ShowCellErrors = false;
		((DataGridView)PlayerGridView).ShowCellToolTips = false;
		((DataGridView)PlayerGridView).ShowEditingIcon = false;
		((DataGridView)PlayerGridView).ShowRowErrors = false;
		((Control)PlayerGridView).Size = new Size(345, 380);
		((Control)PlayerGridView).TabIndex = 0;
		((DataGridViewColumn)PlayerID).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)PlayerID).HeaderText = "ID";
		((DataGridViewColumn)PlayerID).Name = "PlayerID";
		((DataGridViewColumn)PlayerID).ReadOnly = true;
		((DataGridViewColumn)PlayerID).Resizable = (DataGridViewTriState)2;
		PlayerID.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)PlayerID).Visible = false;
		((DataGridViewColumn)PlayerName).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)PlayerName).HeaderText = "Name";
		PlayerName.MaxInputLength = 48;
		((DataGridViewColumn)PlayerName).Name = "PlayerName";
		((DataGridViewColumn)PlayerName).ReadOnly = true;
		((DataGridViewColumn)PlayerName).Resizable = (DataGridViewTriState)2;
		PlayerName.SortMode = (DataGridViewColumnSortMode)0;
		((DataGridViewColumn)PlayerName).Width = 240;
		((DataGridViewColumn)Status).AutoSizeMode = (DataGridViewAutoSizeColumnMode)1;
		((DataGridViewColumn)Status).HeaderText = "Status";
		Status.MaxInputLength = 24;
		((DataGridViewColumn)Status).Name = "Status";
		((DataGridViewColumn)Status).ReadOnly = true;
		((DataGridViewColumn)Status).Resizable = (DataGridViewTriState)2;
		Status.SortMode = (DataGridViewColumnSortMode)0;
		((Control)HostInfoGroupBox).Anchor = (AnchorStyles)11;
		((Control)HostInfoGroupBox).Controls.Add((Control)(object)Label_ScenarioName);
		((Control)HostInfoGroupBox).Controls.Add((Control)(object)Text_ScenarioDesc);
		((Control)HostInfoGroupBox).Controls.Add((Control)(object)DarkLabel4);
		((Control)HostInfoGroupBox).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)HostInfoGroupBox).Location = new Point(495, 27);
		((Control)HostInfoGroupBox).Name = "HostInfoGroupBox";
		((Control)HostInfoGroupBox).Size = new Size(302, 384);
		((Control)HostInfoGroupBox).TabIndex = 5;
		((GroupBox)HostInfoGroupBox).TabStop = false;
		((GroupBox)HostInfoGroupBox).Text = "Scenario Information";
		((Control)Label_ScenarioName).Anchor = (AnchorStyles)13;
		Label_ScenarioName.AutoSize = true;
		((Control)Label_ScenarioName).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_ScenarioName).Location = new Point(6, 23);
		((Control)Label_ScenarioName).Name = "Label_ScenarioName";
		((Control)Label_ScenarioName).Size = new Size(0, 15);
		((Control)Label_ScenarioName).TabIndex = 10;
		((Control)Text_ScenarioDesc).Anchor = (AnchorStyles)15;
		((TextBoxBase)Text_ScenarioDesc).BackColor = Color.FromArgb(49, 51, 53);
		((TextBoxBase)Text_ScenarioDesc).BorderStyle = (BorderStyle)1;
		((TextBoxBase)Text_ScenarioDesc).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Text_ScenarioDesc).Location = new Point(6, 66);
		((TextBox)Text_ScenarioDesc).Multiline = true;
		((Control)Text_ScenarioDesc).Name = "Text_ScenarioDesc";
		Text_ScenarioDesc.PlaceholderText = "";
		((TextBoxBase)Text_ScenarioDesc).ReadOnly = true;
		((Control)Text_ScenarioDesc).Size = new Size(290, 311);
		((Control)Text_ScenarioDesc).TabIndex = 9;
		((Control)DarkLabel4).Anchor = (AnchorStyles)9;
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(6, 48);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(70, 15);
		((Control)DarkLabel4).TabIndex = 8;
		((Label)DarkLabel4).Text = "Description:";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(800, 462);
		((Control)this).Controls.Add((Control)(object)HostInfoGroupBox);
		((Control)this).Controls.Add((Control)(object)PlayerGridView);
		((Control)this).Controls.Add((Control)(object)Button_Exit);
		((Control)this).Controls.Add((Control)(object)Button_Join);
		((Control)this).Controls.Add((Control)(object)Button_Host);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Name = "RealtimeLobby";
		((Form)this).ShowInTaskbar = false;
		((Form)this).Text = "Multi-Player Lobby";
		((Form)this).StartPosition = (FormStartPosition)4;
		((ISupportInitialize)(object)PlayerGridView).EndInit();
		((Control)HostInfoGroupBox).ResumeLayout(false);
		((Control)HostInfoGroupBox).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void NotifyWaitCancel()
	{
		switch (int_0)
		{
		case 1:
			method_20();
			break;
		case 2:
			PendingOpponentID = 0;
			UserState = 0;
			int_0 = 0;
			break;
		case 3:
			PendingOpponentID = 0;
			int_0 = 0;
			break;
		case 4:
			int_0 = 0;
			break;
		}
	}

	private bool method_2()
	{
		int userState = UserState;
		if (userState != 1 && (uint)(userState - 3) > 2u)
		{
			return false;
		}
		return true;
	}

	private void method_3()
	{
		if (socket_0 != null && socket_0.Connected)
		{
			SlitherineLobby.SendRoutingServerUserInfoMessage(UserID, UserName, UserState, HostedScenarioName, HostedScenarioDesc, socket_0);
		}
	}

	private void method_4()
	{
		if (socket_0 != null && socket_0.Connected)
		{
			SlitherineLobby.SendRoutingServerUserInfoRequestMessage(UserID, socket_0);
		}
	}

	private void method_5()
	{
		if (socket_0 != null && socket_0.Connected)
		{
			SlitherineLobby.SendRoutingServerDisconnectMessage(UserID, socket_0);
		}
	}

	private void method_6()
	{
		if (Client.RunningInSteamMode && hauthTicket_0 != HAuthTicket.Invalid)
		{
			SteamUser.CancelAuthTicket(hauthTicket_0);
		}
		hauthTicket_0 = HAuthTicket.Invalid;
		SteamToken = "";
	}

	private string method_7()
	{
		string text = "";
		if (Client.RunningInSteamMode)
		{
			try
			{
				byte[] array = new byte[1024];
				uint pcbTicket = 0u;
				method_6();
				hauthTicket_0 = SteamUser.GetAuthSessionTicket(array, 1024, out pcbTicket);
				if (hauthTicket_0 != HAuthTicket.Invalid && (long)pcbTicket > 0L)
				{
					int num = (int)((long)pcbTicket - 1L);
					for (int i = 0; i <= num; i++)
					{
						text += array[i].ToString("X2");
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				text = "";
				ProjectData.ClearProjectError();
			}
		}
		return text;
	}

	private void dByHggGwteJ()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			UserName = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SavedLobbyUsername", (object)""));
			string text = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SavedLobbyPassword", (object)""));
			if (!string.IsNullOrEmpty(text))
			{
				Password = Crypto.DecryptStringAES(text, "Serenity_Now");
				if (Password == null)
				{
					Password = "";
				}
			}
			else
			{
				Password = "";
			}
			if (Client.RunningInSteamMode)
			{
				SerialNumber = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SteamID", (object)""));
				SteamToken = method_7();
				if (string.IsNullOrEmpty(SteamToken))
				{
					DarkMessageBox.ShowError("Steam authorization failed.  Re-start the Stream client and try again.", "Steam Error");
					ContinueConnection = false;
					method_20();
				}
			}
			else
			{
				SerialNumber = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "Authorized", (object)""));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in L0000", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_8()
	{
		try
		{
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SavedLobbyUsername", (object)UserName);
			string text = "";
			if (!string.IsNullOrEmpty(Password))
			{
				text = Crypto.EncryptStringAES(Password, "Serenity_Now");
			}
			Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SavedLobbyPassword", (object)text);
			if (Client.RunningInSteamMode)
			{
				string text2 = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SteamID", (object)""));
				if (!string.IsNullOrEmpty(SerialNumber) && Operators.CompareString(SerialNumber, text2, true) != 0)
				{
					Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "SteamID", (object)SerialNumber);
				}
			}
			else
			{
				string value = Conversions.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "Authorized", (object)""));
				if (!string.IsNullOrEmpty(SerialNumber) && string.IsNullOrEmpty(value))
				{
					Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Matrix Games\\Command Modern Operations\\", "Authorized", (object)SerialNumber);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in L0002", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_113_RealtimeLobby_Load))]
	private void RealtimeLobby_Load(object sender, EventArgs e)
	{
		VB$StateMachine_113_RealtimeLobby_Load stateMachine = default(VB$StateMachine_113_RealtimeLobby_Load);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_9(object sender, EventArgs e)
	{
		method_23();
	}

	private void method_10(object sender, EventArgs e)
	{
		if (!Connected)
		{
			return;
		}
		SlitherineLobby.PollRoutingServerSocket(socket_0);
		if ((DateTime.Now - dateTime_0).TotalSeconds >= 60.0)
		{
			method_3();
			method_24();
			dateTime_0 = DateTime.Now;
		}
		else if (int_2 < 2)
		{
			switch (int_2)
			{
			case 1:
				SlitherineLobby.SendRoutingServerUserInfoRequestMessage(UserID, socket_0);
				int_2++;
				break;
			case 0:
				SlitherineLobby.SendRoutingServerUserInfoMessage(UserID, UserName, 0, "", "", socket_0);
				int_2++;
				break;
			}
		}
		else if (thread_0 != null)
		{
			if (!thread_0.IsAlive)
			{
				thread_0 = null;
				method_13();
			}
		}
		else if (UserState == 1 && !IsRTMPHostRunning())
		{
			method_15();
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		method_20();
	}

	private string method_12(string string_0)
	{
		string text = "";
		string[] array = string_0.Split(new char[1] { '|' });
		if (array.Count() >= 4)
		{
			if (!string.IsNullOrEmpty(array[0]))
			{
				text = "Duration: " + TimeSpan.FromMinutes(double.Parse(array[0], CultureInfo.InvariantCulture)).ToString() + "\r\n\r\n";
			}
			if (!string.IsNullOrEmpty(array[1]))
			{
				text = text + "Total unit count: " + array[1] + "\r\n\r\n";
			}
			if (!string.IsNullOrEmpty(array[2]))
			{
				text += "Playable Sides (and controllable unit count):\r\n";
				string[] array2 = array[2].Split(new char[1] { '#' });
				int num = array2.Length - 1;
				for (int i = 0; i <= num; i += 2)
				{
					text = text + "  * " + array2[i] + " (" + array2[i + 1] + ")\r\n";
				}
				text += "\r\n";
			}
			if (!string.IsNullOrEmpty(array[3]))
			{
				text += "Scenario features:\r\n";
				string[] array3 = array[3].Split(new char[1] { ',' });
				int num2 = array3.Length - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (!string.IsNullOrEmpty(array3[j]))
					{
						Scenario.ScenarioFeatureOption theFeature = (Scenario.ScenarioFeatureOption)int.Parse(array3[j]);
						text = text + "  * " + Misc.ToEnglishString(theFeature) + "\r\n";
					}
				}
				text += "\r\n";
			}
		}
		return text;
	}

	private void method_13()
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		int num;
		if (!((Control)MyProject.Forms.RealtimeLobbyLoginWait).Visible)
		{
			num = 1;
		}
		else
		{
			((Control)MyProject.Forms.RealtimeLobbyLoginWait).Hide();
			num = 1;
		}
		bool flag = (byte)num != 0;
		if (int_0 != 4)
		{
			flag = false;
			UserState = 0;
			if (IsRTMPHostRunning())
			{
				KillRTMPHost();
			}
		}
		int_0 = 0;
		if (UserState == 1)
		{
			Button_Host.Text = "Stop Hosting";
			Button_Host.Enabled = true;
			Button_Join.Enabled = false;
			((GroupBox)HostInfoGroupBox).Text = "YOU ARE HOSTING:";
			((Label)Label_ScenarioName).Text = HostedScenarioName;
			((TextBox)Text_ScenarioDesc).Text = method_12(HostedScenarioDesc);
			method_3();
			method_24();
		}
		else
		{
			if (flag)
			{
				DarkMessageBox.ShowError("Unable to start CommandHost", "Hosting Error");
			}
			Button_Host.Enabled = true;
		}
	}

	private void method_14()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		bool flag = default(bool);
		try
		{
			if ((flag = PlayFabClientWrapper.LoginWithCustomID(UserID)) && (flag = PlayFabClientWrapper.CreateNewNetwork()))
			{
				string serializedNetworkDescriptor = PlayFabClientWrapper.GetSerializedNetworkDescriptor();
				string inviteCode = PlayFabClientWrapper.GetInviteCode();
				if (string.IsNullOrEmpty(serializedNetworkDescriptor))
				{
					flag = false;
				}
				else if (method_27(serializedNetworkDescriptor, inviteCode, UserID, PendingOpponentID))
				{
					UserState = 1;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in L1000", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (!flag)
		{
			((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
			DarkMessageBox.ShowError(PlayFabClientWrapper.LastErrorMessage, "Lobby Connection Error");
		}
	}

	private void method_15()
	{
		if (UserState != 0)
		{
			if (UserState == 3 && PendingOpponentID != 0)
			{
				method_31(PendingOpponentID);
			}
			if (!ContinueConnection && IsRTMPHostRunning())
			{
				KillRTMPHost();
			}
			HostedScenarioName = "";
			HostedScenarioDesc = "";
			HostedScenarioFilePath = "";
			Button_Host.Text = "Host";
			Button_Host.Enabled = true;
			Button_Join.Enabled = true;
			((GroupBox)HostInfoGroupBox).Text = "Scenario Hosted by (No player selected)";
			((Label)Label_ScenarioName).Text = "";
			((TextBox)Text_ScenarioDesc).Text = "";
			UserState = 0;
			method_24();
		}
		else
		{
			Button_Host.Enabled = false;
			((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Initializing hosted game...";
			((Form)MyProject.Forms.RealtimeLobbyLoginWait).Show((IWin32Window)(object)this);
			int_0 = 4;
			thread_0 = new Thread(method_14);
			thread_0.Start();
		}
	}

	private void method_16(Scenario scenario_0, string string_0)
	{
		try
		{
			if (scenario_0 == null)
			{
				return;
			}
			HostedScenarioName = scenario_0.Title;
			HostedScenarioFilePath = string_0;
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			text2 = scenario_0.Duration.TotalMinutes.ToString(CultureInfo.InvariantCulture);
			text3 = scenario_0.GetTotalUnitCount().ToString();
			Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (!side.IsAIOnly && !side.IsNature)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += "#";
					}
					text = text + side.Name + "#" + side.GetControllableUnitCount();
				}
			}
			if (scenario_0.DeclaredFeatures.Count > 0)
			{
				List<Scenario.ScenarioFeatureOption> list = scenario_0.DeclaredFeatures.ToList();
				foreach (Scenario.ScenarioFeatureOption item in list)
				{
					if (!string.IsNullOrEmpty(text4))
					{
						text4 += ",";
					}
					string text5 = text4;
					int num = (int)item;
					text4 = text5 + num;
				}
			}
			HostedScenarioDesc = text2 + "|" + text3 + "|" + text + "|" + text4;
			if (HostedScenarioDesc.Length >= 1956)
			{
				HostedScenarioDesc = HostedScenarioDesc.Substring(0, 1955);
			}
			method_15();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			HostedScenarioName = "";
			HostedScenarioFilePath = "";
			HostedScenarioDesc = "";
			ProjectData.ClearProjectError();
		}
		finally
		{
			MyProject.Forms.LoadScenario.OnLoadScenarioComplete -= method_16;
			MyProject.Forms.ResumeFromSave.OnLoadScenarioComplete -= method_16;
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		if (UserState == 0)
		{
			HostedScenarioName = "";
			HostedScenarioDesc = "";
			HostedScenarioFilePath = "";
			MyProject.Forms.LoadScenario.OnLoadScenarioComplete += method_16;
			MyProject.Forms.ResumeFromSave.OnLoadScenarioComplete += method_16;
			MyProject.Forms.LoadScenario.RaiseEventMode = true;
			((Control)MyProject.Forms.LoadScenario).Show();
		}
		else if (method_2())
		{
			method_15();
			method_3();
		}
	}

	private void method_18(object sender, EventArgs e)
	{
		if (UserState == 0 && PendingOpponentID == 0)
		{
			PlayerInfoStruct playerInfoStruct = method_22();
			if (playerInfoStruct.ID != 0 && playerInfoStruct.ID != UserID && playerInfoStruct.State == 1)
			{
				PendingOpponentID = playerInfoStruct.ID;
				UserState = 2;
				Button_Join.Enabled = false;
				method_29(PendingOpponentID);
				int_0 = 2;
				((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = "Awaiting host player response...";
				((Form)MyProject.Forms.RealtimeLobbyLoginWait).Show((IWin32Window)(object)this);
			}
		}
	}

	private void method_19()
	{
		if (int_0 != 999)
		{
			method_20();
		}
	}

	private void method_20()
	{
		PingTimer.Enabled = false;
		int_0 = 999;
		method_5();
		if (Client.RunningInSteamMode)
		{
			method_6();
		}
		if (socket_0 != null && socket_0.Connected)
		{
			socket_0.Close();
			socket_0 = null;
		}
		Connected = false;
		if (method_2())
		{
			method_15();
		}
		((DataGridView)PlayerGridView).Rows.Clear();
		ArrayExtensions.Clear(ref playerInfoStruct_0);
		PendingOpponentID = 0;
		UserState = 0;
		SlitherineLobby.OnPlayerInfoRequest -= HandleRoutingServerPlayerInfoRequest;
		SlitherineLobby.OnPlayerInfoUpdated -= HandleRoutingServerPlayerInfoUpdate;
		SlitherineLobby.OnPlayerJoinRequest -= HandleRoutingServerPlayerJoinRequest;
		SlitherineLobby.OnPlayerJoinAccept -= HandleRoutingServerPlayerJoinAccept;
		SlitherineLobby.OnPlayerJoinDecline -= HandleRoutingServerPlayerJoinDecline;
		SlitherineLobby.OnRoutingServerError -= HandleRoutingServerError;
		MyProject.Forms.LoadScenario.OnLoadScenarioComplete -= method_16;
		MyProject.Forms.ResumeFromSave.OnLoadScenarioComplete -= method_16;
		((Form)this).Close();
	}

	private PlayerInfoStruct method_21(int int_3)
	{
		PlayerInfoStruct[] array = playerInfoStruct_0;
		int num = 0;
		PlayerInfoStruct result;
		PlayerInfoStruct result2 = default(PlayerInfoStruct);
		while (true)
		{
			if (num < array.Length)
			{
				result = array[num];
				if (result.ID == int_3)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return result2;
		}
		return result;
	}

	private PlayerInfoStruct method_22()
	{
		if (((BaseCollection)((DataGridView)PlayerGridView).SelectedRows).Count > 0)
		{
			DataGridViewCell val = ((DataGridView)PlayerGridView).SelectedRows[0].Cells["PlayerID"];
			if (val != null && val.Value != null)
			{
				int int_ = Conversions.ToInteger(val.Value);
				return method_21(int_);
			}
		}
		PlayerInfoStruct result = default(PlayerInfoStruct);
		return result;
	}

	private void method_23()
	{
		if (UserState == 1)
		{
			return;
		}
		((GroupBox)HostInfoGroupBox).Text = "Scenario hosted by (no player selected)";
		((Label)Label_ScenarioName).Text = "";
		((TextBox)Text_ScenarioDesc).Text = "";
		Button_Join.Enabled = false;
		PlayerInfoStruct playerInfoStruct = method_22();
		if (playerInfoStruct.ID <= 0)
		{
			return;
		}
		if (playerInfoStruct.State == 1)
		{
			((Label)Label_ScenarioName).Text = playerInfoStruct.HostedScenarioName;
			((TextBox)Text_ScenarioDesc).Text = method_12(playerInfoStruct.HostedScenarioDescription);
			if (playerInfoStruct.ID == UserID)
			{
				((GroupBox)HostInfoGroupBox).Text = "YOU ARE HOSTING";
				return;
			}
			((GroupBox)HostInfoGroupBox).Text = "Scenario hosted by " + playerInfoStruct.Name;
			Button_Join.Enabled = true;
		}
		else if (playerInfoStruct.ID == UserID)
		{
			((GroupBox)HostInfoGroupBox).Text = "You are not hosting a scenario";
		}
		else
		{
			((GroupBox)HostInfoGroupBox).Text = "Player " + playerInfoStruct.Name + " is not hosting a scenario";
		}
	}

	private void method_24()
	{
		PlayerInfoStruct[] theArray = new PlayerInfoStruct[0];
		int num = playerInfoStruct_0.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			if (playerInfoStruct_0[i].ID == UserID)
			{
				playerInfoStruct_0[i].Name = UserName;
				playerInfoStruct_0[i].State = UserState;
				playerInfoStruct_0[i].HostedScenarioName = HostedScenarioName;
				playerInfoStruct_0[i].HostedScenarioDescription = HostedScenarioDesc;
			}
			else if ((DateTime.Now - playerInfoStruct_0[i].LastUpdate).TotalSeconds > 120.0)
			{
				ArrayExtensions.Add(ref theArray, playerInfoStruct_0[i]);
			}
		}
		playerInfoStruct_0 = playerInfoStruct_0.Except(theArray).ToArray();
		method_25();
	}

	private void method_25()
	{
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		int num = 0;
		if (((BaseCollection)((DataGridView)PlayerGridView).SelectedRows).Count > 0)
		{
			num = Conversions.ToInteger(((DataGridView)PlayerGridView).SelectedRows[0].Cells["PlayerID"].Value);
		}
		((DataGridView)PlayerGridView).Rows.Clear();
		PlayerInfoStruct[] array = playerInfoStruct_0;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			PlayerInfoStruct playerInfoStruct = array[i];
			int num2 = ((DataGridView)PlayerGridView).Rows.Add();
			DataGridViewRow val = ((DataGridView)PlayerGridView).Rows[num2];
			val.Cells["PlayerID"].Value = playerInfoStruct.ID;
			val.Cells["PlayerName"].Value = playerInfoStruct.Name;
			if (playerInfoStruct.State == 1)
			{
				val.Cells["Status"].Value = "[Hosting]";
			}
			else
			{
				val.Cells["Status"].Value = "";
			}
		}
		if (num > 0)
		{
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)PlayerGridView).Rows)
			{
				DataGridViewRow val2 = item;
				if (Conversions.ToInteger(val2.Cells["PlayerID"].Value) == num)
				{
					val2.Selected = true;
					break;
				}
			}
		}
		method_23();
	}

	private void method_26()
	{
		try
		{
			ArrayExtensions.Clear(ref playerInfoStruct_0);
			if (SlitherineLobby.UserLoginInfo != null)
			{
				ArrayExtensions.Add(theAC: new PlayerInfoStruct
				{
					Name = SlitherineLobby.UserLoginInfo.Username,
					ID = SlitherineLobby.UserLoginInfo.UserID,
					State = 0,
					LastUpdate = DateTime.Now
				}, theArray: ref playerInfoStruct_0);
			}
			method_25();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error in L0004", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static bool IsRTMPHostRunning()
	{
		try
		{
			return Process.GetProcessesByName("CommandHost").Length > 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public static void KillRTMPHost(bool WaitForExit = false)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("CommandHost");
			if (processesByName.Length > 0)
			{
				processesByName[0].Kill();
				if (WaitForExit)
				{
					processesByName[0].WaitForExit(5000);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int IsWindowVisible(IntPtr hWnd);

	private bool method_27(string string_0, string string_1, int int_3, int int_4)
	{
		try
		{
			if (IsRTMPHostRunning())
			{
				KillRTMPHost(WaitForExit: true);
			}
			string fileName = Path.Combine(Application.StartupPath, "CommandHost.exe");
			int commandHostUserID = SlitherineLobby.GetCommandHostUserID(int_3);
			string arguments = "-network_id=" + string_0 + " -invite_code=" + string_1 + " -user_id=" + commandHostUserID + " -remote_user_id=" + int_4 + " -scenario=\"" + HostedScenarioFilePath + "\"";
			Process process = Process.Start(fileName, arguments);
			if (process != null)
			{
				try
				{
					process.WaitForInputIdle();
					EventWaitHandle eventWaitHandle = new EventWaitHandle(initialState: false, EventResetMode.ManualReset, "CommandHostInitComplete");
					int result;
					if (eventWaitHandle == null)
					{
						result = 1;
					}
					else
					{
						eventWaitHandle.WaitOne(60000);
						result = 1;
					}
					return (byte)result != 0;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error in L0008A", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error in L0008", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private void method_28()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			socket_0 = SlitherineLobby.ConnectToRoutingServer();
			if (socket_0 != null && socket_0.Connected)
			{
				SlitherineLobby.SendRoutingServerConnectMessage(UserID, socket_0);
				int_2 = 0;
				dateTime_0 = DateTime.Now;
				PingTimer.Enabled = true;
			}
			else
			{
				DarkMessageBox.ShowError("Unable to connect to the lobby server socket.", "Lobby Connection Error");
				method_20();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			DarkMessageBox.ShowError(ex2.Message, "Lobby Connection Error");
			method_20();
			ProjectData.ClearProjectError();
		}
	}

	private void method_29(int int_3)
	{
		if (UserState != 1 && socket_0 != null && socket_0.Connected)
		{
			SlitherineLobby.SendRoutingServerJoinRequestMessage(int_3, socket_0);
		}
	}

	private void method_30(int int_3)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		if (UserState == 3 && socket_0 != null && socket_0.Connected)
		{
			string serializedNetworkDescriptor = PlayFabClientWrapper.GetSerializedNetworkDescriptor();
			string inviteCode = PlayFabClientWrapper.GetInviteCode();
			bool flag;
			if (!(flag = IsRTMPHostRunning()))
			{
				flag = method_27(serializedNetworkDescriptor, inviteCode, UserID, PendingOpponentID);
			}
			if (!flag)
			{
				SlitherineLobby.SendRoutingServerJoinDeclineMessage(int_3, socket_0);
				DarkMessageBox.ShowError("Unable to start CommandHost", "Hosting Error");
			}
			else
			{
				SlitherineLobby.SendRoutingServerJoinAcceptMessage(int_3, serializedNetworkDescriptor, inviteCode, socket_0);
				ContinueToPostLobbyConnection(serializedNetworkDescriptor, inviteCode);
			}
		}
	}

	private void method_31(int int_3)
	{
		if (UserState == 3)
		{
			UserState = 1;
		}
		PendingOpponentID = 0;
		int_0 = 0;
		if (socket_0 != null && socket_0.Connected)
		{
			SlitherineLobby.SendRoutingServerJoinDeclineMessage(int_3, socket_0);
		}
	}

	public void ContinueToPostLobbyConnection(string networkID, string inviteCode)
	{
		ContinueConnection = true;
		PlayFabNetworkId = networkID;
		PlayFabInviteCode = inviteCode;
		if (method_2())
		{
			CommandHostUserID = SlitherineLobby.GetCommandHostUserID(UserID);
		}
		else
		{
			CommandHostUserID = SlitherineLobby.GetCommandHostUserID(PendingOpponentID);
		}
		method_20();
	}

	public void HandleRoutingServerPlayerInfoUpdate(int PlayerID, string PlayerName, int PlayerState, string HostedScenarioName, string HostedScenarioBrief)
	{
		int num = playerInfoStruct_0.Count() - 1;
		for (int i = 0; i <= num; i++)
		{
			if (playerInfoStruct_0[i].ID == PlayerID)
			{
				playerInfoStruct_0[i].Name = PlayerName;
				playerInfoStruct_0[i].State = PlayerState;
				playerInfoStruct_0[i].HostedScenarioName = HostedScenarioName;
				playerInfoStruct_0[i].HostedScenarioDescription = HostedScenarioBrief;
				playerInfoStruct_0[i].LastUpdate = DateTime.Now;
				method_25();
				return;
			}
		}
		ArrayExtensions.Add(theAC: new PlayerInfoStruct
		{
			ID = PlayerID,
			Name = PlayerName,
			State = PlayerState,
			HostedScenarioName = HostedScenarioName,
			HostedScenarioDescription = HostedScenarioBrief,
			LastUpdate = DateTime.Now
		}, theArray: ref playerInfoStruct_0);
		method_25();
	}

	public void HandleRoutingServerPlayerInfoRequest(int RequesterID)
	{
		if (socket_0 != null && socket_0.Connected)
		{
			SlitherineLobby.SendRoutingServerUserInfoMessage(UserID, UserName, UserState, HostedScenarioName, HostedScenarioDesc, socket_0);
		}
	}

	public void HandleRoutingServerPlayerJoinRequest(int RequesterID)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		if (UserState == 1 && PendingOpponentID == 0)
		{
			UserState = 3;
			PendingOpponentID = RequesterID;
			PlayerInfoStruct playerInfoStruct = method_21(PendingOpponentID);
			int_0 = 3;
			((Label)MyProject.Forms.RealtimeLobbyLoginWait.Label_WaitStatus).Text = playerInfoStruct.Name + " has requested to join your game. Accept and connect?";
			MyProject.Forms.RealtimeLobbyLoginWait.SetupOkCancelTimeout(30);
			if ((int)((Form)MyProject.Forms.RealtimeLobbyLoginWait).ShowDialog((IWin32Window)(object)this) == 1)
			{
				method_30(RequesterID);
			}
			else
			{
				method_31(RequesterID);
			}
		}
		else
		{
			method_31(RequesterID);
		}
	}

	public void HandleRoutingServerPlayerJoinAccept(int HostID, string ServerName, string InviteCode)
	{
		if (HostID == PendingOpponentID)
		{
			if (((Control)MyProject.Forms.RealtimeLobbyLoginWait).Visible)
			{
				((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
			}
			ContinueToPostLobbyConnection(ServerName, InviteCode);
		}
	}

	public void HandleRoutingServerPlayerJoinDecline(int HostID)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		if (HostID == PendingOpponentID)
		{
			PendingOpponentID = 0;
			UserState = 0;
			Button_Join.Enabled = true;
			if (((Control)MyProject.Forms.RealtimeLobbyLoginWait).Visible)
			{
				((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
			}
			DarkMessageBox.ShowInformation("The host player declined your offer.", "Join Offer Response");
		}
	}

	public void HandleRoutingServerPlayerDisconnect(int PlayerID)
	{
		PlayerInfoStruct[] array = playerInfoStruct_0;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			PlayerInfoStruct value = array[i];
			if (value.ID != PlayerID)
			{
				continue;
			}
			ArrayExtensions.Remove(ref playerInfoStruct_0, value);
			if (PendingOpponentID == PlayerID)
			{
				PendingOpponentID = 0;
				if (method_2())
				{
					UserState = 1;
				}
				else
				{
					UserState = 0;
				}
				if (((Control)MyProject.Forms.RealtimeLobbyLoginWait).Visible)
				{
					((Form)MyProject.Forms.RealtimeLobbyLoginWait).Close();
				}
			}
			method_25();
			break;
		}
	}

	public void HandleRoutingServerError(int DestinationPlayerID, int ErrorCode)
	{
	}

	static RealtimeLobby()
	{
		Class72.smethod_20();
	}
}
