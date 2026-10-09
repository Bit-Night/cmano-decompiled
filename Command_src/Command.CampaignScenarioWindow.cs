using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class CampaignScenarioWindow : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_44_CampaignScenario_Shown : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal CampaignScenarioWindow $VB$Me;

		internal TaskAwaiter<bool> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			int num = $State;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<bool>);
					goto IL_016c;
				}
				try
				{
					$VB$Me.scenContainer_0 = ScenContainer.LoadFromFile($VB$Me.ScenFileName);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					DarkMessageBox.ShowError(ex2.Message, "Issue encountered while loading scenario.");
					((Form)$VB$Me).Close();
					ProjectData.ClearProjectError();
					goto end_IL_0008;
				}
				$VB$Me.Timer1.Start();
				$VB$Me.Button1.Enabled = false;
				((Control)$VB$Me.Label_Loading).Visible = true;
				((Control)$VB$Me.PB_PercentComplete).Visible = true;
				string theContentTag = Scenario.QueryScenario_ScenXML($VB$Me.scenContainer_0.GetScenarioObject_AsXML(), "ContentTag");
				if (Licensing.IsUserLicensedForThisContent(theContentTag))
				{
					$VB$Me.vmethod_0().RunWorkerAsync();
					((Control)$VB$Me.WebBrowser1).Visible = true;
					awaiter = Helper.smethod_1($VB$Me.WebBrowser1, $VB$Me.scenContainer_0.ScenDescription, Path.GetDirectoryName($VB$Me.ScenFileName)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_016c;
				}
				MyProject.Forms.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(theContentTag) };
				((Control)MyProject.Forms.InsufficientLicenseWindow).Show();
				((Form)$VB$Me).Close();
				goto end_IL_0008;
				IL_016c:
				bool result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
				if (!result)
				{
					Module1.RenderCustomHTML($VB$Me.WebBrowser1, $VB$Me.scenContainer_0.ScenDescription);
				}
				((Label)$VB$Me.Label1).Text = $VB$Me.scenContainer_0.ScenTitle;
				end_IL_0008:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception exception = ex3;
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

		static VB$StateMachine_44_CampaignScenario_Shown()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Timer1")]
	private Timer timer_0;

	public Campaign SelectedCampaign;

	public string ScenFileName;

	public string CampaignSessionID;

	public int CampaignScore;

	public string LuaXml;

	private Scenario scenario_0;

	[AccessedThroughProperty("theBW")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_0;

	private double double_0;

	private ScenContainer scenContainer_0;

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

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
			EventHandler eventHandler = method_6;
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
			EventHandler eventHandler = method_5;
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

	[field: AccessedThroughProperty("PB_PercentComplete")]
	internal virtual DarkUIProgressBar PB_PercentComplete { get; set; }

	[field: AccessedThroughProperty("Label_Loading")]
	internal virtual DarkLabel Label_Loading { get; set; }

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			Timer val = timer_0;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			timer_0 = value;
			val = timer_0;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	public CampaignScenarioWindow()
	{
		((Form)this).Shown += CampaignScenarioWindow_Shown;
		((Form)this).Load += CampaignScenarioWindow_Load;
		vmethod_1(new BackgroundWorker());
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		icontainer_1 = new Container();
		Timer1 = new Timer(icontainer_1);
		PB_PercentComplete = new DarkUIProgressBar();
		Label_Loading = new DarkLabel();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		Label1 = new DarkLabel();
		WebBrowser1 = new WebView2();
		((Control)this).SuspendLayout();
		Timer1.Interval = 50;
		((Control)PB_PercentComplete).Anchor = (AnchorStyles)2;
		((Control)PB_PercentComplete).BackColor = Color.Transparent;
		PB_PercentComplete.CustomForeColor = Color.Transparent;
		((Control)PB_PercentComplete).Font = new Font("Segoe UI", 9f);
		((Control)PB_PercentComplete).Location = new Point(309, 605);
		PB_PercentComplete.Maximum = 100;
		((Control)PB_PercentComplete).Name = "PB_PercentComplete";
		PB_PercentComplete.ShowProgressLines = true;
		PB_PercentComplete.ShowProgressValue = false;
		PB_PercentComplete.ShowText = false;
		((Control)PB_PercentComplete).Size = new Size(359, 12);
		((Control)PB_PercentComplete).TabIndex = 21;
		PB_PercentComplete.Value = 0;
		((Control)Label_Loading).Anchor = (AnchorStyles)2;
		((Control)Label_Loading).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Loading).Location = new Point(461, 588);
		((Control)Label_Loading).Name = "Label_Loading";
		((Control)Label_Loading).Size = new Size(54, 13);
		((Control)Label_Loading).TabIndex = 22;
		((Label)Label_Loading).Text = "Loading...";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(735, 588);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(249, 29);
		((Control)Button2).TabIndex = 20;
		Button2.Text = "Cancel (return to Campaigns)";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(1, 588);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(249, 29);
		((Control)Button1).TabIndex = 19;
		Button1.Text = "Start Scenario";
		Label1.AutoSize = true;
		((Control)Label1).Cursor = Cursors.Arrow;
		((Control)Label1).Font = new Font("Arial", 36f);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 3);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(312, 55);
		((Control)Label1).TabIndex = 18;
		((Label)Label1).Text = "Scenario Title";
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		((Control)WebBrowser1).Location = new Point(1, 61);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(983, 507);
		((Control)WebBrowser1).TabIndex = 17;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(985, 618);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)PB_PercentComplete);
		((Control)this).Controls.Add((Control)(object)Label_Loading);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "CampaignScenarioWindow";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Campaign Scenario";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_0()
	{
		return backgroundWorker_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(BackgroundWorker WithEventsValue)
	{
		DoWorkEventHandler value = method_2;
		RunWorkerCompletedEventHandler value2 = method_3;
		BackgroundWorker backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		backgroundWorker_0 = WithEventsValue;
		backgroundWorker = backgroundWorker_0;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_44_CampaignScenario_Shown))]
	private void CampaignScenarioWindow_Shown(object sender, EventArgs e)
	{
		VB$StateMachine_44_CampaignScenario_Shown stateMachine = default(VB$StateMachine_44_CampaignScenario_Shown);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_2(object sender, DoWorkEventArgs e)
	{
		scenario_0 = scenContainer_0.GetScenarioObject(ref Client.ScenLoadErrorFeedback, [SpecialName] (double d) =>
		{
			double_0 = d;
		}, ForceDeepRebuild: false);
		if (scenario_0.ScenAttachments.Count > 0)
		{
			AttachmentRepoManager.MoveAttachmentsToLocalRepo(scenario_0, ScenFileName);
		}
	}

	private void method_3(object sender, RunWorkerCompletedEventArgs e)
	{
		((Control)Label_Loading).Visible = false;
		((Control)PB_PercentComplete).Visible = false;
		Button1.Enabled = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		PB_PercentComplete.Value = (int)Math.Round(double_0 * 100.0);
	}

	private void method_5(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.CampaignPlayWindow).Show();
		((Form)this).Close();
	}

	private void method_6(object sender, EventArgs e)
	{
		scenario_0.CampaignSessionID = CampaignSessionID;
		scenario_0.CampaignID = SelectedCampaign.ID;
		scenario_0.CampaignScore = CampaignScore;
		scenario_0.LuaXmlPassed = LuaXml;
		Client.SetCurrentScenario(scenario_0, bool_10: false);
		Client.HandleScenarioLoaded(Client.CurrentScenario, ScenFileName);
		if (Client.CurrentGame.GameMode != Game._GameMode.SinglePlayer)
		{
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
		}
		List<string> list = new List<string>();
		Campaign.GetCampaignsInFolder(GameGeneral.ScenariosRootPath, list);
		string customFileName = default(string);
		foreach (string item in list)
		{
			Campaign campaign = Campaign.ReadFromFile(item);
			if (Operators.CompareString(campaign.ID, Client.CurrentScenario.CampaignID, true) == 0)
			{
				customFileName = Path.Combine(Path.GetDirectoryName(item), Guid.NewGuid().ToString() + ".save");
				break;
			}
		}
		Client.SaveCurrentScenario(SBR: false, customFileName, MarkAsCampaignCheckpoint: true);
		((Form)this).Close();
	}

	private void CampaignScenarioWindow_Load(object sender, EventArgs e)
	{
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		if (WebBrowser1.CoreWebView2 != null)
		{
			WebBrowser1.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
		}
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static CampaignScenarioWindow()
	{
		Class72.smethod_20();
	}
}
