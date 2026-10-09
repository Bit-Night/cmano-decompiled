using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class ResumeFromSave : DarkSecondaryFormBase
{
	public delegate void OnLoadScenarioCompleteEventHandler(Scenario theLoadedScenario, string theSelectedFileName);

	private IContainer icontainer_1;

	private ScenContainer scenContainer_0;

	private string string_0;

	public string CampaignSessionID;

	private string string_1;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_LoadScen")]
	private BackgroundWorker backgroundWorker_0;

	private Scenario scenario_0;

	private bool bool_2;

	private double double_0;

	private string string_2;

	public bool RaiseEventMode;

	[CompilerGenerated]
	private OnLoadScenarioCompleteEventHandler onLoadScenarioCompleteEventHandler_0;

	[field: AccessedThroughProperty("PB_PercentComplete")]
	internal virtual DarkUIProgressBar PB_PercentComplete { get; set; }

	public string SelectedFilename
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public event OnLoadScenarioCompleteEventHandler OnLoadScenarioComplete
	{
		[CompilerGenerated]
		add
		{
			OnLoadScenarioCompleteEventHandler onLoadScenarioCompleteEventHandler = onLoadScenarioCompleteEventHandler_0;
			OnLoadScenarioCompleteEventHandler onLoadScenarioCompleteEventHandler2;
			do
			{
				onLoadScenarioCompleteEventHandler2 = onLoadScenarioCompleteEventHandler;
				OnLoadScenarioCompleteEventHandler value2 = (OnLoadScenarioCompleteEventHandler)Delegate.Combine(onLoadScenarioCompleteEventHandler2, value);
				onLoadScenarioCompleteEventHandler = Interlocked.CompareExchange(ref onLoadScenarioCompleteEventHandler_0, value2, onLoadScenarioCompleteEventHandler2);
			}
			while ((object)onLoadScenarioCompleteEventHandler != onLoadScenarioCompleteEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OnLoadScenarioCompleteEventHandler onLoadScenarioCompleteEventHandler = onLoadScenarioCompleteEventHandler_0;
			OnLoadScenarioCompleteEventHandler onLoadScenarioCompleteEventHandler2;
			do
			{
				onLoadScenarioCompleteEventHandler2 = onLoadScenarioCompleteEventHandler;
				OnLoadScenarioCompleteEventHandler value2 = (OnLoadScenarioCompleteEventHandler)Delegate.Remove(onLoadScenarioCompleteEventHandler2, value);
				onLoadScenarioCompleteEventHandler = Interlocked.CompareExchange(ref onLoadScenarioCompleteEventHandler_0, value2, onLoadScenarioCompleteEventHandler2);
			}
			while ((object)onLoadScenarioCompleteEventHandler != onLoadScenarioCompleteEventHandler2);
		}
	}

	public ResumeFromSave()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Shown += ResumeFromSave_Shown;
		((Form)this).FormClosing += new FormClosingEventHandler(ResumeFromSave_FormClosing);
		vmethod_1(new BackgroundWorker());
		RaiseEventMode = false;
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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		PB_PercentComplete = new DarkUIProgressBar();
		((Control)this).SuspendLayout();
		((Control)PB_PercentComplete).BackColor = Color.Transparent;
		((Control)PB_PercentComplete).Dock = (DockStyle)5;
		((Control)PB_PercentComplete).Font = new Font("Segoe UI", 9f);
		((Control)PB_PercentComplete).Location = new Point(0, 0);
		PB_PercentComplete.Maximum = 100;
		((Control)PB_PercentComplete).Name = "PB_PercentComplete";
		PB_PercentComplete.ShowProgressLines = true;
		PB_PercentComplete.ShowProgressValue = false;
		((Control)PB_PercentComplete).Size = new Size(298, 65);
		((Control)PB_PercentComplete).TabIndex = 0;
		PB_PercentComplete.Value = 0;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(298, 65);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)PB_PercentComplete);
		((Control)this).DoubleBuffered = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ResumeFromSave";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Loading....";
		((Control)this).ResumeLayout(false);
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

	private void ResumeFromSave_Shown(object sender, EventArgs e)
	{
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		MainForm.KillAllRendering = true;
		if (!string.IsNullOrEmpty(CampaignSessionID))
		{
			string_1 = CampaignSessionID;
			CampaignSessionID = null;
		}
		else
		{
			string_1 = null;
		}
		try
		{
			string scenXML = default(string);
			try
			{
				scenContainer_0 = ScenContainer.LoadFromFile(SelectedFilename);
				scenXML = scenContainer_0.GetScenarioObject_AsXML();
			}
			catch (UnauthorizedAccessException ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				UnauthorizedAccessException ex2 = ex;
				throw ex2;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Module1.IsValidXml(SelectedFilename))
				{
					string selectedFilename = SelectedFilename;
					string ErrorFeedback = null;
					Scenario theScen = Scenario.smethod_0(selectedFilename, ref ErrorFeedback, null);
					scenContainer_0 = new ScenContainer(theScen);
					scenXML = File.ReadAllText(SelectedFilename);
				}
				ProjectData.ClearProjectError();
			}
			string_2 = Scenario.QueryScenario_ScenXML(scenXML, "ContentTag");
			if (string.IsNullOrEmpty(string_2))
			{
				string_2 = "";
			}
			if (!Licensing.IsUserLicensedForThisContent(string_2))
			{
				MyProject.Forms.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(string_2) };
				((Control)MyProject.Forms.InsufficientLicenseWindow).Show();
				RaiseEventMode = false;
				((Form)this).Close();
				return;
			}
			bool_2 = false;
			scenario_0 = null;
			MyProject.Forms.ORBAT?.ReleaseReferences();
			vmethod_0().RunWorkerAsync();
			((Control)PB_PercentComplete).Visible = true;
			MyProject.Forms.MainForm.ScenarioReferenceCleanup();
			while (!bool_2)
			{
				Application.DoEvents();
				PB_PercentComplete.Value = (int)Math.Round(double_0 * 100.0);
				Thread.Sleep(50);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			MainForm.KillAllRendering = false;
			vmethod_0().WorkerSupportsCancellation = true;
			vmethod_0().CancelAsync();
			RaiseEventMode = false;
			((Form)this).Close();
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("An error has occured: " + ex4.Message, "Error during load");
			ProjectData.ClearProjectError();
		}
		MainForm.KillAllRendering = false;
	}

	private void method_2(object sender, DoWorkEventArgs e)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Scenario scenarioObject = scenContainer_0.GetScenarioObject(ref Client.ScenLoadErrorFeedback, [SpecialName] (double d) =>
			{
				double_0 = d;
			}, ForceDeepRebuild: false);
			if (scenarioObject != null && !Path.GetFileName(SelectedFilename).StartsWith("Autosave"))
			{
				scenarioObject.FileName = Path.GetFileName(SelectedFilename);
				scenarioObject.FileNamePath = Path.GetDirectoryName(SelectedFilename);
			}
			scenario_0 = scenarioObject;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200106", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("An error has occured: " + ex2.Message, "Error during load");
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(object sender, RunWorkerCompletedEventArgs e)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (scenario_0 != null)
			{
				if (!string.IsNullOrEmpty(string_1))
				{
					scenario_0.CampaignSessionID = string_1;
					string_1 = null;
				}
				if (!RaiseEventMode)
				{
					Client.HandleScenarioLoaded(scenario_0, SelectedFilename);
				}
				else
				{
					onLoadScenarioCompleteEventHandler_0?.Invoke(scenario_0, SelectedFilename);
				}
				bool_2 = true;
				if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
				{
					Client.SaveScenarioPath = SelectedFilename;
				}
				else
				{
					Client.SaveScenarioPath = null;
				}
				RaiseEventMode = false;
				((Form)this).Close();
			}
			else
			{
				bool_2 = true;
				((Form)this).Close();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			DarkMessageBox.ShowError("An error has occured: " + ex2.Message, "Error during load");
			ProjectData.ClearProjectError();
		}
	}

	private void ResumeFromSave_FormClosing(object sender, FormClosingEventArgs e)
	{
		scenContainer_0 = null;
		scenario_0 = null;
		RaiseEventMode = false;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	static ResumeFromSave()
	{
		Class72.smethod_20();
	}
}
