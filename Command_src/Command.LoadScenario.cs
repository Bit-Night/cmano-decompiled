using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Xml;
using Command_Core;
using Command_Core.Lua;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class LoadScenario : DarkSecondaryFormBase
{
	public delegate void OnLoadScenarioCompleteEventHandler(Scenario theLoadedScenario, string theSelectedFileName);

	public enum DefaultAction : byte
	{
		LoadScenario,
		LoadSavedGame
	}

	[CompilerGenerated]
	internal sealed class _Closure$__159-0
	{
		public string $VB$Local_FileExtension;

		public _Closure$__159-0(_Closure$__159-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_FileExtension = arg0.$VB$Local_FileExtension;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(string theFN)
		{
			return Operators.CompareString(Path.GetExtension(theFN), $VB$Local_FileExtension, true) == 0;
		}

		static _Closure$__159-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__163-0
	{
		public string $VB$Local_FileExtension;

		public _Closure$__163-0(_Closure$__163-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_FileExtension = arg0.$VB$Local_FileExtension;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(string theFN)
		{
			return Operators.CompareString(Path.GetExtension(theFN), $VB$Local_FileExtension, true) == 0;
		}

		static _Closure$__163-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__173-0
	{
		public string $VB$Local_AutosavesPath;

		public LoadScenario $VB$Me;

		public _Closure$__173-0(_Closure$__173-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_AutosavesPath = arg0.$VB$Local_AutosavesPath;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			if (!File.Exists($VB$Local_AutosavesPath + "\\Autosave.scen"))
			{
				DarkMessageBox.ShowError("No autosave file was found at the path" + $VB$Local_AutosavesPath + "\\Autosave.scen", "No autosave found");
				return;
			}
			Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
			MyProject.Forms.ResumeFromSave.SelectedFilename = $VB$Local_AutosavesPath + "\\Autosave.scen";
			MyProject.Forms.ResumeFromSave.RaiseEventMode = $VB$Me.RaiseEventMode;
			((Control)MyProject.Forms.ResumeFromSave).Show();
			$VB$Me.RaiseEventMode = false;
			((Form)$VB$Me).Close();
		}

		static _Closure$__173-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer NexSxOuXyrK;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Scens")]
	private DarkTreeView _TV_Scens;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	private DarkUITabControl _TabControl1;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Saves")]
	private DarkTreeView _TV_Saves;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_ScenOrder")]
	private DarkUIComboBox _CB_ScenOrder;

	internal ScenarioSelectControl ScenarioSelectControl1;

	[AccessedThroughProperty("Button_BrowseScenario")]
	[CompilerGenerated]
	private DarkUIButton _Button_BrowseScenario;

	[AccessedThroughProperty("OpenFileDialog1")]
	[CompilerGenerated]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("DeleteSelected_Button")]
	[CompilerGenerated]
	private DarkUIButton _DeleteSelected_Button;

	[AccessedThroughProperty("LoadAutosaveButton")]
	[CompilerGenerated]
	private DarkUIButton _LoadAutosaveButton;

	[CompilerGenerated]
	[AccessedThroughProperty("txtScenSearch")]
	private DarkUITextBox _txtScenSearch;

	private string string_0;

	public DefaultAction myDefaultAction;

	[CompilerGenerated]
	[AccessedThroughProperty("BW_LoadScen")]
	private BackgroundWorker backgroundWorker_0;

	[AccessedThroughProperty("BW_CheckContentTag")]
	[CompilerGenerated]
	private BackgroundWorker backgroundWorker_1;

	private Scenario scenario_0;

	private bool bool_2;

	private double double_0;

	private bool bool_3;

	private string string_1;

	private FileInfo fileInfo_0;

	private ScenContainer scenContainer_0;

	private string string_2;

	private Bitmap bitmap_0;

	private List<string> list_0;

	private string string_3;

	public bool RaiseEventMode;

	[CompilerGenerated]
	private OnLoadScenarioCompleteEventHandler onLoadScenarioCompleteEventHandler_0;

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

	internal virtual DarkTreeView TV_Scens
	{
		[CompilerGenerated]
		get
		{
			return _TV_Scens;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sysSxfIfbyO;
			DarkTreeView.AfterNodeExpandDelegate value3 = method_18;
			DarkTreeView darkTreeView = _TV_Scens;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
				darkTreeView.AfterNodeExpand -= value3;
			}
			_TV_Scens = value;
			darkTreeView = _TV_Scens;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
				darkTreeView.AfterNodeExpand += value3;
			}
		}
	}

	internal virtual DarkUITabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return _TabControl1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_23;
			DarkUITabControl darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_TabControl1 = value;
			darkUITabControl = _TabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	internal virtual DarkTreeView TV_Saves
	{
		[CompilerGenerated]
		get
		{
			return _TV_Saves;
		}
		[CompilerGenerated]
		set
		{
			EventHandler value2 = method_17;
			DarkTreeView.AfterNodeExpandDelegate value3 = method_19;
			DarkTreeView darkTreeView = _TV_Saves;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
				darkTreeView.AfterNodeExpand -= value3;
			}
			_TV_Saves = value;
			darkTreeView = _TV_Saves;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
				darkTreeView.AfterNodeExpand += value3;
			}
		}
	}

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
			EventHandler eventHandler = method_10;
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

	[field: AccessedThroughProperty("Label_Title")]
	internal virtual DarkLabel Label_Title { get; set; }

	[field: AccessedThroughProperty("PB_PercentComplete")]
	internal virtual DarkUIProgressBar PB_PercentComplete { get; set; }

	[field: AccessedThroughProperty("Label_Loading")]
	internal virtual DarkLabel Label_Loading { get; set; }

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("PB_Difficulty")]
	internal virtual DarkUIProgressBar PB_Difficulty { get; set; }

	[field: AccessedThroughProperty("PB_Complexity")]
	internal virtual DarkUIProgressBar PB_Complexity { get; set; }

	[field: AccessedThroughProperty("Label4")]
	internal virtual DarkLabel Label4 { get; set; }

	[field: AccessedThroughProperty("DatabaseVersion")]
	internal virtual DarkLabel DatabaseVersion { get; set; }

	[field: AccessedThroughProperty("Label5")]
	internal virtual DarkLabel Label5 { get; set; }

	internal virtual DarkUIComboBox CB_ScenOrder
	{
		[CompilerGenerated]
		get
		{
			return _CB_ScenOrder;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			DarkUIComboBox darkUIComboBox = _CB_ScenOrder;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_CB_ScenOrder = value;
			darkUIComboBox = _CB_ScenOrder;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	[field: AccessedThroughProperty("ElementHost1")]
	internal virtual ElementHost ElementHost1 { get; set; }

	internal virtual DarkUIButton Button_BrowseScenario
	{
		[CompilerGenerated]
		get
		{
			return _Button_BrowseScenario;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_20;
			DarkUIButton darkUIButton = _Button_BrowseScenario;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_BrowseScenario = value;
			darkUIButton = _Button_BrowseScenario;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	internal virtual OpenFileDialog OpenFileDialog1
	{
		[CompilerGenerated]
		get
		{
			return openFileDialog_0;
		}
		[CompilerGenerated]
		set
		{
			openFileDialog_0 = value;
		}
	}

	internal virtual DarkUIButton DeleteSelected_Button
	{
		[CompilerGenerated]
		get
		{
			return _DeleteSelected_Button;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _DeleteSelected_Button;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DeleteSelected_Button = value;
			darkUIButton = _DeleteSelected_Button;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Deleteselected")]
	internal virtual DarkUIButton Deleteselected { get; set; }

	internal virtual DarkUIButton LoadAutosaveButton
	{
		[CompilerGenerated]
		get
		{
			return _LoadAutosaveButton;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_21;
			DarkUIButton darkUIButton = _LoadAutosaveButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_LoadAutosaveButton = value;
			darkUIButton = _LoadAutosaveButton;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("LblScenSearch")]
	internal virtual DarkLabel LblScenSearch { get; set; }

	internal virtual DarkUITextBox txtScenSearch
	{
		[CompilerGenerated]
		get
		{
			return _txtScenSearch;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_22;
			DarkUITextBox darkUITextBox = _txtScenSearch;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_txtScenSearch = value;
			darkUITextBox = _txtScenSearch;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	public string SearchString
	{
		get
		{
			return string_3;
		}
		set
		{
			if (value != null)
			{
				string_3 = value;
				method_5();
				method_7();
			}
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

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && NexSxOuXyrK != null)
			{
				NexSxOuXyrK.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent_1()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0760: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Expected O, but got Unknown
		//IL_082b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Expected O, but got Unknown
		//IL_0b39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Expected O, but got Unknown
		//IL_0c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c22: Expected O, but got Unknown
		//IL_0e7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e86: Expected O, but got Unknown
		//IL_0f53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5d: Expected O, but got Unknown
		//IL_0f9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_102b: Expected O, but got Unknown
		//IL_106c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e9: Expected O, but got Unknown
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11aa: Expected O, but got Unknown
		//IL_11eb: Unknown result type (might be due to invalid IL or missing references)
		Button2 = new DarkUIButton();
		TV_Scens = new DarkTreeView();
		TabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		TV_Saves = new DarkTreeView();
		TabPage3 = new TabPage();
		ElementHost1 = new ElementHost();
		ScenarioSelectControl1 = new ScenarioSelectControl();
		Button1 = new DarkUIButton();
		Label_Title = new DarkLabel();
		PB_PercentComplete = new DarkUIProgressBar();
		Label_Loading = new DarkLabel();
		WebBrowser1 = new WebView2();
		Label1 = new DarkLabel();
		Label2 = new DarkLabel();
		PB_Difficulty = new DarkUIProgressBar();
		PB_Complexity = new DarkUIProgressBar();
		Label4 = new DarkLabel();
		DatabaseVersion = new DarkLabel();
		Label5 = new DarkLabel();
		CB_ScenOrder = new DarkUIComboBox();
		Button_BrowseScenario = new DarkUIButton();
		OpenFileDialog1 = new OpenFileDialog();
		DeleteSelected_Button = new DarkUIButton();
		Deleteselected = new DarkUIButton();
		LoadAutosaveButton = new DarkUIButton();
		LblScenSearch = new DarkLabel();
		txtScenSearch = new DarkUITextBox();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)TabPage2).SuspendLayout();
		((Control)TabPage3).SuspendLayout();
		((ISupportInitialize)WebBrowser1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)Button2).Anchor = (AnchorStyles)6;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(420, 566);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(104, 23);
		((Control)Button2).TabIndex = 2;
		Button2.Text = "Load selected";
		((Control)TV_Scens).Dock = (DockStyle)5;
		((Control)TV_Scens).Font = new Font("Segoe UI", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TV_Scens).Location = new Point(3, 3);
		TV_Scens.MaxDragChange = 20;
		TV_Scens.MouseWheelStep = 30;
		((Control)TV_Scens).Name = "TV_Scens";
		((Control)TV_Scens).Size = new Size(388, 490);
		((Control)TV_Scens).TabIndex = 5;
		((Control)TabControl1).Anchor = (AnchorStyles)7;
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1).Cursor = Cursors.Hand;
		((Control)TabControl1).Font = new Font("Segoe UI", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((TabControl)TabControl1).ItemSize = new Size(80, 20);
		((Control)TabControl1).Location = new Point(12, 65);
		((Control)TabControl1).Name = "TabControl1";
		((TabControl)TabControl1).SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(402, 524);
		((Control)TabControl1).TabIndex = 6;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage1).Controls.Add((Control)(object)TV_Scens);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(394, 496);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Scenarios";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage2).Controls.Add((Control)(object)TV_Saves);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(394, 496);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Saved games";
		((Control)TV_Saves).Dock = (DockStyle)5;
		((Control)TV_Saves).Font = new Font("Segoe UI", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((Control)TV_Saves).Location = new Point(3, 3);
		TV_Saves.MaxDragChange = 20;
		TV_Saves.MouseWheelStep = 30;
		((Control)TV_Saves).Name = "TV_Saves";
		((Control)TV_Saves).Size = new Size(388, 490);
		((Control)TV_Saves).TabIndex = 6;
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		((Control)TabPage3).Controls.Add((Control)(object)ElementHost1);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(394, 496);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Steam Workshop";
		((Control)ElementHost1).Dock = (DockStyle)5;
		((Control)ElementHost1).Location = new Point(3, 3);
		((Control)ElementHost1).Name = "ElementHost1";
		((Control)ElementHost1).Size = new Size(388, 490);
		((Control)ElementHost1).TabIndex = 0;
		((Control)ElementHost1).Text = "ElementHost1";
		ElementHost1.Child = (UIElement)(object)ScenarioSelectControl1;
		((Control)Button1).Anchor = (AnchorStyles)10;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(914, 566);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(82, 23);
		((Control)Button1).TabIndex = 9;
		Button1.Text = "Cancel";
		((Control)Label_Title).Anchor = (AnchorStyles)15;
		Label_Title.AutoSize = true;
		((Control)Label_Title).Font = new Font("Arial", 12f, (FontStyle)1);
		((Control)Label_Title).ForeColor = Color.Gainsboro;
		((Control)Label_Title).Location = new Point(419, 12);
		((Control)Label_Title).Name = "Label_Title";
		((Control)Label_Title).Size = new Size(140, 24);
		((Control)Label_Title).TabIndex = 10;
		((Label)Label_Title).Text = "Scenario Title";
		((Label)Label_Title).TextAlign = (ContentAlignment)32;
		((Control)Label_Title).Visible = false;
		((Control)PB_PercentComplete).Anchor = (AnchorStyles)14;
		((Control)PB_PercentComplete).BackColor = Color.Transparent;
		PB_PercentComplete.CustomForeColor = Color.Transparent;
		((Control)PB_PercentComplete).Font = new Font("Segoe UI", 9f);
		((Control)PB_PercentComplete).Location = new Point(480, 546);
		PB_PercentComplete.Maximum = 100;
		((Control)PB_PercentComplete).Name = "PB_PercentComplete";
		PB_PercentComplete.ShowProgressLines = true;
		PB_PercentComplete.ShowProgressValue = false;
		PB_PercentComplete.ShowText = false;
		((Control)PB_PercentComplete).Size = new Size(516, 12);
		((Control)PB_PercentComplete).TabIndex = 13;
		PB_PercentComplete.Value = 0;
		((Control)Label_Loading).Anchor = (AnchorStyles)6;
		Label_Loading.AutoSize = true;
		((Control)Label_Loading).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Loading).Location = new Point(420, 545);
		((Control)Label_Loading).Name = "Label_Loading";
		((Control)Label_Loading).Size = new Size(72, 20);
		((Control)Label_Loading).TabIndex = 14;
		((Label)Label_Loading).Text = "Loading...";
		WebBrowser1.AllowExternalDrop = true;
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		WebBrowser1.CreationProperties = null;
		WebBrowser1.DefaultBackgroundColor = Color.White;
		((Control)WebBrowser1).Location = new Point(423, 89);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(573, 450);
		((Control)WebBrowser1).TabIndex = 15;
		((Control)WebBrowser1).Visible = false;
		WebBrowser1.ZoomFactor = 1.0;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.Gainsboro;
		((Control)Label1).Location = new Point(420, 45);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(72, 20);
		((Control)Label1).TabIndex = 16;
		((Label)Label1).Text = "Difficulty:";
		((Control)Label1).Visible = false;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.Gainsboro;
		((Control)Label2).Location = new Point(637, 45);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(87, 20);
		((Control)Label2).TabIndex = 17;
		((Label)Label2).Text = "Complexity:";
		((Control)Label2).Visible = false;
		((Control)PB_Difficulty).BackColor = Color.Transparent;
		PB_Difficulty.CustomForeColor = Color.Transparent;
		((Control)PB_Difficulty).Font = new Font("Segoe UI", 9f);
		((Control)PB_Difficulty).ForeColor = Color.FromArgb(0, 0, 0, 0);
		((Control)PB_Difficulty).Location = new Point(504, 45);
		PB_Difficulty.Maximum = 100;
		((Control)PB_Difficulty).Name = "PB_Difficulty";
		PB_Difficulty.ShowProgressLines = true;
		PB_Difficulty.ShowProgressValue = false;
		PB_Difficulty.ShowText = false;
		((Control)PB_Difficulty).Size = new Size(100, 16);
		((Control)PB_Difficulty).TabIndex = 19;
		PB_Difficulty.Value = 0;
		((Control)PB_Difficulty).Visible = false;
		((Control)PB_Complexity).BackColor = Color.Transparent;
		PB_Complexity.CustomForeColor = Color.Transparent;
		((Control)PB_Complexity).Font = new Font("Segoe UI", 9f);
		((Control)PB_Complexity).ForeColor = Color.FromArgb(0, 0, 0, 0);
		((Control)PB_Complexity).Location = new Point(713, 45);
		PB_Complexity.Maximum = 100;
		((Control)PB_Complexity).Name = "PB_Complexity";
		PB_Complexity.ShowProgressLines = true;
		PB_Complexity.ShowProgressValue = false;
		PB_Complexity.ShowText = false;
		((Control)PB_Complexity).Size = new Size(100, 16);
		((Control)PB_Complexity).TabIndex = 20;
		PB_Complexity.Value = 0;
		((Control)PB_Complexity).Visible = false;
		Label4.AutoSize = true;
		((Control)Label4).ForeColor = Color.Gainsboro;
		((Control)Label4).Location = new Point(420, 65);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(130, 20);
		((Control)Label4).TabIndex = 21;
		((Label)Label4).Text = "Location / Setting:";
		((Control)Label4).Visible = false;
		DatabaseVersion.AutoSize = true;
		((Control)DatabaseVersion).ForeColor = Color.Gainsboro;
		((Control)DatabaseVersion).Location = new Point(828, 45);
		((Control)DatabaseVersion).Name = "DatabaseVersion";
		((Control)DatabaseVersion).Size = new Size(168, 20);
		((Control)DatabaseVersion).TabIndex = 21;
		((Label)DatabaseVersion).Text = "Saved Database Version";
		Label5.AutoSize = true;
		((Control)Label5).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label5).Location = new Point(12, 17);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(135, 20);
		((Control)Label5).TabIndex = 23;
		((Label)Label5).Text = "Order scenarios by:";
		((ComboBox)CB_ScenOrder).BackColor = Color.Transparent;
		((ComboBox)CB_ScenOrder).DrawMode = (DrawMode)1;
		((ComboBox)CB_ScenOrder).DropDownStyle = (ComboBoxStyle)2;
		((Control)CB_ScenOrder).Font = new Font("Segoe UI", 7f);
		((ListControl)CB_ScenOrder).FormattingEnabled = true;
		((ComboBox)CB_ScenOrder).Items.AddRange(new object[5] { "Name", "Date", "Difficulty", "Complexity", "Date Modified (Save files only)" });
		((Control)CB_ScenOrder).Location = new Point(130, 12);
		((Control)CB_ScenOrder).Name = "CB_ScenOrder";
		((Control)CB_ScenOrder).Size = new Size(201, 24);
		((Control)CB_ScenOrder).TabIndex = 24;
		((Control)Button_BrowseScenario).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_BrowseScenario).BackColor = Color.Transparent;
		((Button)Button_BrowseScenario).DialogResult = (DialogResult)2;
		((Control)Button_BrowseScenario).Font = new Font("Segoe UI", 10f);
		((Control)Button_BrowseScenario).ForeColor = SystemColors.Control;
		((Control)Button_BrowseScenario).Location = new Point(815, 566);
		((Control)Button_BrowseScenario).Name = "Button_BrowseScenario";
		((Control)Button_BrowseScenario).Padding = new Padding(5);
		Button_BrowseScenario.RoundRadius = 0;
		((Control)Button_BrowseScenario).Size = new Size(93, 23);
		((Control)Button_BrowseScenario).TabIndex = 25;
		Button_BrowseScenario.Text = "Browse...";
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog1";
		((Control)DeleteSelected_Button).Anchor = (AnchorStyles)6;
		((ButtonBase)DeleteSelected_Button).BackColor = Color.Transparent;
		((Control)DeleteSelected_Button).Font = new Font("Segoe UI", 10f);
		((Control)DeleteSelected_Button).ForeColor = SystemColors.Control;
		((Control)DeleteSelected_Button).Location = new Point(696, 566);
		((Control)DeleteSelected_Button).Name = "DeleteSelected_Button";
		((Control)DeleteSelected_Button).Padding = new Padding(5);
		DeleteSelected_Button.RoundRadius = 0;
		((Control)DeleteSelected_Button).Size = new Size(113, 23);
		((Control)DeleteSelected_Button).TabIndex = 26;
		DeleteSelected_Button.Text = "Delete selected";
		((Control)Deleteselected).Anchor = (AnchorStyles)6;
		((ButtonBase)Deleteselected).BackColor = Color.Transparent;
		((Control)Deleteselected).Font = new Font("Segoe UI", 10f);
		((Control)Deleteselected).ForeColor = SystemColors.Control;
		((Control)Deleteselected).Location = new Point(610, 566);
		((Control)Deleteselected).Name = "Deleteselected";
		((Control)Deleteselected).Padding = new Padding(5);
		Deleteselected.RoundRadius = 0;
		((Control)Deleteselected).Size = new Size(135, 23);
		((Control)Deleteselected).TabIndex = 26;
		Deleteselected.Text = "Delete selected";
		((Control)LoadAutosaveButton).Anchor = (AnchorStyles)6;
		((ButtonBase)LoadAutosaveButton).BackColor = Color.Transparent;
		((Control)LoadAutosaveButton).Font = new Font("Segoe UI", 10f);
		((Control)LoadAutosaveButton).ForeColor = SystemColors.Control;
		((Control)LoadAutosaveButton).Location = new Point(530, 566);
		((Control)LoadAutosaveButton).Name = "LoadAutosaveButton";
		((Control)LoadAutosaveButton).Padding = new Padding(5);
		LoadAutosaveButton.RoundRadius = 0;
		((Control)LoadAutosaveButton).Size = new Size(135, 23);
		((Control)LoadAutosaveButton).TabIndex = 27;
		LoadAutosaveButton.Text = "Select autosave";
		LblScenSearch.AutoSize = true;
		((Control)LblScenSearch).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LblScenSearch).Location = new Point(13, 39);
		((Control)LblScenSearch).Name = "LblScenSearch";
		((Control)LblScenSearch).Size = new Size(115, 20);
		((Control)LblScenSearch).TabIndex = 28;
		((Label)LblScenSearch).Text = "Search scenario:";
		txtScenSearch.AutoCompleteCustomSource = null;
		txtScenSearch.AutoCompleteMode = (AutoCompleteMode)0;
		txtScenSearch.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)txtScenSearch).BackColor = Color.Transparent;
		((Control)txtScenSearch).ForeColor = Color.FromArgb(189, 189, 189);
		txtScenSearch.Image = null;
		txtScenSearch.Lines = null;
		((Control)txtScenSearch).Location = new Point(130, 40);
		txtScenSearch.MaxLength = 32767;
		txtScenSearch.Multiline = false;
		((Control)txtScenSearch).Name = "txtScenSearch";
		txtScenSearch.ReadOnly = false;
		txtScenSearch.ScrollBars = (ScrollBars)0;
		txtScenSearch.SelectionStart = 0;
		((Control)txtScenSearch).Size = new Size(284, 19);
		((Control)txtScenSearch).TabIndex = 29;
		txtScenSearch.TextAlign = (HorizontalAlignment)0;
		txtScenSearch.UseSystemPasswordChar = false;
		txtScenSearch.WatermarkText = "";
		txtScenSearch.WordWrap = false;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1008, 601);
		((Control)this).Controls.Add((Control)(object)txtScenSearch);
		((Control)this).Controls.Add((Control)(object)LblScenSearch);
		((Control)this).Controls.Add((Control)(object)LoadAutosaveButton);
		((Control)this).Controls.Add((Control)(object)DeleteSelected_Button);
		((Control)this).Controls.Add((Control)(object)Button_BrowseScenario);
		((Control)this).Controls.Add((Control)(object)PB_Complexity);
		((Control)this).Controls.Add((Control)(object)PB_Difficulty);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)DatabaseVersion);
		((Control)this).Controls.Add((Control)(object)CB_ScenOrder);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)Label_Loading);
		((Control)this).Controls.Add((Control)(object)PB_PercentComplete);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Label_Title);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "LoadScenario";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Load Scenario";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage2).ResumeLayout(false);
		((Control)TabPage3).ResumeLayout(false);
		((ISupportInitialize)WebBrowser1).EndInit();
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
		DoWorkEventHandler value = method_12;
		RunWorkerCompletedEventHandler value2 = method_13;
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

	[SpecialName]
	[CompilerGenerated]
	private virtual BackgroundWorker vmethod_2()
	{
		return backgroundWorker_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_3(BackgroundWorker WithEventsValue)
	{
		DoWorkEventHandler value = method_15;
		RunWorkerCompletedEventHandler value2 = method_16;
		BackgroundWorker backgroundWorker = backgroundWorker_1;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork -= value;
			backgroundWorker.RunWorkerCompleted -= value2;
		}
		backgroundWorker_1 = WithEventsValue;
		backgroundWorker = backgroundWorker_1;
		if (backgroundWorker != null)
		{
			backgroundWorker.DoWork += value;
			backgroundWorker.RunWorkerCompleted += value2;
		}
	}

	public LoadScenario()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(LoadScenario_FormClosing);
		((Form)this).Load += LoadScenario_Load;
		((Control)this).KeyDown += new KeyEventHandler(LoadScenario_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(LoadScenario_FormClosed);
		((Form)this).Closed += LoadScenario_Closed;
		vmethod_1(new BackgroundWorker());
		vmethod_3(new BackgroundWorker());
		string_3 = "";
		RaiseEventMode = false;
		InitializeComponent_1();
		ApplyStoredPositionSettings = false;
		ApplyStoredSizeSettings = true;
		ScenarioSelectControl1.VM.LoadScenarioForm = this;
	}

	private void method_2(object sender, EventArgs e)
	{
		MainForm.KillAllRendering = true;
		if (scenContainer_0 == null)
		{
			return;
		}
		Button2.Enabled = false;
		if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			Client.CurrentGame.Pause();
		}
		bool_2 = false;
		scenario_0 = null;
		MyProject.Forms.ORBAT?.ReleaseReferences();
		vmethod_0().RunWorkerAsync();
		((Control)Label_Loading).Visible = true;
		((Control)PB_PercentComplete).Visible = true;
		while (vmethod_0().IsBusy)
		{
			Application.DoEvents();
			PB_PercentComplete.Value = (int)Math.Round(double_0 * 100.0);
			Thread.Sleep(50);
		}
		if (scenario_0 != null)
		{
			if (RaiseEventMode)
			{
				onLoadScenarioCompleteEventHandler_0?.Invoke(scenario_0, string_0);
			}
			else
			{
				Client.HandleScenarioLoaded(scenario_0, string_0);
			}
			RaiseEventMode = false;
			((Form)this).Close();
		}
		Button2.Enabled = true;
		((Control)Label_Loading).Visible = false;
		((Control)PB_PercentComplete).Visible = false;
		MainForm.KillAllRendering = false;
	}

	private void method_3(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			string extension = Path.GetExtension(string_0);
			if (Operators.CompareString(extension, ".save", true) == 0)
			{
				File.Delete(string_0);
				string_0 = null;
				method_7();
			}
			else if (Operators.CompareString(extension, ".scen", true) == 0)
			{
				File.Delete(string_0);
				string_0 = null;
				((Control)DeleteSelected_Button).Visible = false;
				method_5();
			}
		}
	}

	private List<string> method_4(IEnumerable<string> ienumerable_0)
	{
		int num = 10;
		while (true)
		{
			List<string> result = new List<string>();
			while (true)
			{
				int selectedIndex = ((ComboBox)CB_ScenOrder).SelectedIndex;
				num = 19;
				while (true)
				{
					if (num != 19)
					{
						if (num != 1000)
						{
							goto IL_0165;
						}
						switch (num)
						{
						case 9:
							goto end_IL_004d;
						case 10:
							goto end_IL_0055;
						case 1:
							goto IL_008e;
						case 7:
							goto IL_00c8;
						case 2:
							goto IL_00fa;
						case 0:
							goto IL_012c;
						case 5:
							goto IL_015e;
						case 3:
						case 4:
						case 6:
						case 8:
						case 11:
						case 12:
							goto IL_0165;
						}
						continue;
					}
					switch (selectedIndex)
					{
					case 0:
						break;
					case 1:
						goto IL_00c8;
					case 2:
						goto IL_00fa;
					case 3:
						goto IL_012c;
					case 4:
						goto IL_015e;
					default:
						goto IL_0165;
					}
					goto IL_008e;
					IL_0165:
					return result;
					IL_00fa:
					result = ienumerable_0.OrderBy([SpecialName] (string theKey) => ScenContainer.QueryScenContainer(theKey, "Difficulty")).ToList();
					goto IL_0165;
					IL_00c8:
					result = ienumerable_0.OrderBy([SpecialName] (string theKey) => ScenContainer.QueryScenContainer(theKey, "ScenDate")).ToList();
					goto IL_0165;
					IL_015e:
					result = list_0;
					goto IL_0165;
					IL_012c:
					result = ienumerable_0.OrderBy([SpecialName] (string theKey) => ScenContainer.QueryScenContainer(theKey, "Complexity")).ToList();
					goto IL_0165;
					IL_008e:
					result = ienumerable_0.OrderBy([SpecialName] (string theKey) => theKey, new nvSorter()).ToList();
					goto IL_0165;
					continue;
					end_IL_004d:
					break;
				}
				continue;
				end_IL_0055:
				break;
			}
		}
	}

	private void method_5()
	{
		TV_Scens.Nodes.Clear();
		TV_Scens.ShowIcons = false;
		List<string> list = Directory.GetDirectories(GameGeneral.ScenariosRootPath).ToList();
		string text = string.Empty;
		if (Licensing.get_ModuleIsLicensed(Licensing.ModuleLicense.CommandFullVersion))
		{
			foreach (string item in list)
			{
				if (item.EndsWith("Standalone Scenarios"))
				{
					text = item;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				list.Remove(text);
				list.Insert(0, text);
			}
		}
		text = string.Empty;
		foreach (string item2 in list)
		{
			if (item2.EndsWith("Tutorials"))
			{
				text = item2;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			list.Remove(text);
			list.Insert(0, text);
		}
		foreach (string item3 in list)
		{
			if (method_8(item3, ".scen"))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileName(item3));
				TV_Scens.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item3;
				if ((Directory.GetDirectories(item3).Count() > 0) | (Directory.GetFiles(item3).Count() > 0))
				{
					darkTreeNode.Nodes.Add(new DarkTreeNode("virtual"));
				}
				string text2 = method_9(item3);
				if (!string.IsNullOrEmpty(text2) && !Licensing.IsUserLicensedForThisContent(Licensing.GetContentTagFromCampaignID(text2)))
				{
					TV_Scens.ShowIcons = true;
					darkTreeNode.Icon = bitmap_0;
				}
			}
		}
		List<string> ienumerable_ = method_4(from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), ".scen", true) == 0
			select theFN);
		List<string> list2 = method_4(ienumerable_);
		foreach (string item4 in list2)
		{
			if (method_6(item4))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileNameWithoutExtension(item4));
				TV_Scens.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item4;
			}
		}
	}

	private bool method_6(string string_4)
	{
		return string_4.ToUpperInvariant().TrimStart(new char[0]).TrimEnd(new char[0])
			.Replace(" ", "")
			.Contains(SearchString.ToUpperInvariant().TrimStart(new char[0]).TrimEnd(new char[0])
				.Replace(" ", ""));
	}

	private void method_7()
	{
		TV_Saves.Nodes.Clear();
		TV_Saves.ShowIcons = false;
		string[] directories = Directory.GetDirectories(GameGeneral.ScenariosRootPath);
		foreach (string text in directories)
		{
			if (method_8(text, ".save"))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileName(text));
				TV_Saves.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = text;
				if ((Directory.GetDirectories(text).Count() > 0) | (Directory.GetFiles(text).Count() > 0))
				{
					darkTreeNode.Nodes.Add(new DarkTreeNode("virtual"));
				}
				string text2 = method_9(text);
				if (!string.IsNullOrEmpty(text2) && !Licensing.IsUserLicensedForThisContent(Licensing.GetContentTagFromCampaignID(text2)))
				{
					TV_Saves.ShowIcons = true;
					darkTreeNode.Icon = bitmap_0;
				}
			}
		}
		Dictionary<string, DateTime> dictionary = new Dictionary<string, DateTime>();
		foreach (string item in from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), ".save", true) == 0
			select theFN)
		{
			dictionary.Add(item, FileSystem.FileDateTime(item));
		}
		list_0 = (from tPair in dictionary
			orderby tPair.Value descending
			select tPair.Key).ToList();
		List<string> list = method_4(from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
			where Operators.CompareString(Path.GetExtension(theFN), ".save", true) == 0
			select theFN);
		foreach (string item2 in list)
		{
			if (method_6(item2))
			{
				string_1 = Path.GetFileName(item2);
				fileInfo_0 = new FileInfo(item2);
				string_1 = "[" + fileInfo_0.LastWriteTime.ToShortDateString() + " " + fileInfo_0.LastWriteTime.ToShortTimeString() + "] " + string_1;
				DarkTreeNode darkTreeNode = new DarkTreeNode(string_1);
				TV_Saves.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item2;
			}
		}
	}

	private bool method_8(string string_4, string string_5)
	{
		string[] files = Directory.GetFiles(string_4);
		int num = 0;
		while (true)
		{
			string text;
			if (num < files.Length)
			{
				text = files[num];
				if (!method_6(text))
				{
					goto IL_0079;
				}
				if (Operators.CompareString(string_5, "Both", true) == 0)
				{
					int result;
					if (!text.EndsWith(".scen"))
					{
						if (!text.EndsWith(".save"))
						{
							goto IL_0043;
						}
						result = 1;
					}
					else
					{
						result = 1;
					}
					return (byte)result != 0;
				}
				goto IL_0043;
			}
			string[] directories = Directory.GetDirectories(string_4);
			int num2 = 0;
			while (true)
			{
				if (num2 < directories.Length)
				{
					string string_6 = directories[num2];
					if (method_8(string_6, string_5))
					{
						break;
					}
					num2 = checked(num2 + 1);
					continue;
				}
				return false;
			}
			return true;
			IL_0079:
			num = checked(num + 1);
			continue;
			IL_0043:
			if (Operators.CompareString(string_5, ".save", true) != 0 || !text.EndsWith(".save"))
			{
				if (Operators.CompareString(string_5, ".scen", true) == 0 && text.EndsWith(".scen"))
				{
					break;
				}
				goto IL_0079;
			}
			return true;
		}
		return true;
	}

	private string method_9(string string_4)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		string[] files = Directory.GetFiles(string_4);
		int num = 0;
		string text;
		while (true)
		{
			if (num < files.Length)
			{
				text = files[num];
				if (text.EndsWith(".campaign"))
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return null;
		}
		XmlDocument val = new XmlDocument();
		val.Load(text);
		return ((XmlNode)val).ChildNodes[1].ChildNodes[0].InnerText;
	}

	private void LoadScenario_FormClosing(object sender, FormClosingEventArgs e)
	{
		scenario_0 = null;
		scenContainer_0 = null;
		RaiseEventMode = false;
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void LoadScenario_Load(object sender, EventArgs e)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		((Control)Label_Title).ForeColor = Color.Gainsboro;
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		((Control)MyProject.Forms.MainForm).Enabled = false;
		((ComboBox)CB_ScenOrder).SelectedIndex = 0;
		((Control)Label_Loading).Visible = false;
		((Control)PB_PercentComplete).Visible = false;
		((TabControl)TabControl1).SelectedIndex = (int)myDefaultAction;
		((Control)WebBrowser1).Visible = false;
		bitmap_0 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Symbols\\Lock.png"));
		method_5();
		method_7();
	}

	private void method_10(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		RaiseEventMode = false;
		((Form)this).Close();
	}

	private void method_11(DarkTreeNode darkTreeNode_0)
	{
		_Closure$__159-0 arg = default(_Closure$__159-0);
		_Closure$__159-0 CS$<>8__locals6 = new _Closure$__159-0(arg);
		darkTreeNode_0.Nodes.Clear();
		string path = darkTreeNode_0.Tag.ToString();
		CS$<>8__locals6.$VB$Local_FileExtension = "";
		switch (((TabControl)TabControl1).SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			break;
		case 1:
			CS$<>8__locals6.$VB$Local_FileExtension = ".save";
			break;
		case 0:
			CS$<>8__locals6.$VB$Local_FileExtension = ".scen";
			break;
		}
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		List<string> list2 = Directory.GetDirectories(path).OrderBy([SpecialName] (string theFN) => theFN, new nvSorter()).ToList();
		foreach (string item in list2)
		{
			if (method_8(item, CS$<>8__locals6.$VB$Local_FileExtension))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileName(item));
				list.Add(darkTreeNode);
				darkTreeNode.Tag = item;
				if ((Directory.GetDirectories(item).Length > 0) | (Directory.GetFiles(item).Length > 0))
				{
					darkTreeNode.Nodes.Add(new DarkTreeNode("virtual"));
				}
			}
		}
		List<string> list3 = method_4(from theFN in Directory.GetFiles(path)
			where Operators.CompareString(Path.GetExtension(theFN), CS$<>8__locals6.$VB$Local_FileExtension, true) == 0
			select theFN);
		foreach (string item2 in list3)
		{
			if (method_6(item2))
			{
				string_1 = Path.GetFileNameWithoutExtension(item2);
				if (Operators.CompareString(CS$<>8__locals6.$VB$Local_FileExtension, ".save", true) == 0)
				{
					fileInfo_0 = new FileInfo(item2);
					string_1 = "[" + fileInfo_0.LastWriteTime.ToShortDateString() + " " + fileInfo_0.LastWriteTime.ToShortTimeString() + "] " + string_1 + ".save";
				}
				DarkTreeNode darkTreeNode = new DarkTreeNode(string_1);
				list.Add(darkTreeNode);
				darkTreeNode.Tag = item2;
			}
		}
		darkTreeNode_0.Nodes.AddRange(list);
	}

	private void method_12(object sender, DoWorkEventArgs e)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string scenarioObject_AsXML = scenContainer_0.GetScenarioObject_AsXML();
			CMANO.HandleScenarioChanging();
			string_2 = Scenario.QueryScenario_ScenXML(scenarioObject_AsXML, "ContentTag");
			if (string.IsNullOrEmpty(string_2))
			{
				string_2 = "";
			}
			if (!Licensing.IsUserLicensedForThisContent(string_2))
			{
				bool_3 = false;
				return;
			}
			bool_3 = true;
			Scenario theScen = Scenario.FromXmlText(scenarioObject_AsXML, ref Client.ScenLoadErrorFeedback, [SpecialName] (double d) =>
			{
				double_0 = d;
			});
			if (Information.IsNothing((object)theScen))
			{
				bool_3 = true;
				return;
			}
			Client.ConfigureCommandCoreSettings(ref theScen);
			if (theScen.ScenAttachments.Count > 0)
			{
				AttachmentRepoManager.MoveAttachmentsToLocalRepo(theScen, string_0);
			}
			if (!Path.GetFileName(string_0).StartsWith("Autosave"))
			{
				theScen.FileName = Path.GetFileName(string_0);
				theScen.FileNamePath = Path.GetDirectoryName(string_0);
			}
			scenario_0 = theScen;
		}
		catch (DBFileNotFoundException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			DBFileNotFoundException ex2 = ex;
			DarkMessageBox.ShowError(ex2.Message + " " + Client.ScenLoadErrorFeedback, "Error");
			bool_3 = true;
			ProjectData.ClearProjectError();
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			DarkMessageBox.ShowError(ex4.Message + " " + Client.ScenLoadErrorFeedback, "Error");
			ex4?.Data.Add("Error at 101159", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			bool_3 = true;
			throw;
		}
	}

	private void method_13(object sender, RunWorkerCompletedEventArgs e)
	{
		if (bool_3)
		{
			bool_2 = true;
			return;
		}
		MyProject.Forms.InsufficientLicenseWindow.theNeededModules = new List<Licensing.ModuleLicense> { Licensing.ModuleEnablingThisContent(string_2) };
		((Control)MyProject.Forms.InsufficientLicenseWindow).Show();
	}

	private void LoadScenario_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			RaiseEventMode = false;
			((Form)this).Close();
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		_Closure$__163-0 arg = default(_Closure$__163-0);
		_Closure$__163-0 CS$<>8__locals5 = new _Closure$__163-0(arg);
		List<DarkTreeNode> list = new List<DarkTreeNode>();
		CS$<>8__locals5.$VB$Local_FileExtension = "";
		DarkTreeView darkTreeView = null;
		List<DarkTreeNode> list2;
		List<string> list3;
		switch (((TabControl)TabControl1).SelectedIndex)
		{
		default:
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			goto IL_006e;
		case 0:
			darkTreeView = TV_Scens;
			CS$<>8__locals5.$VB$Local_FileExtension = ".scen";
			goto IL_006e;
		case 1:
			darkTreeView = TV_Saves;
			CS$<>8__locals5.$VB$Local_FileExtension = ".save";
			goto IL_006e;
		case 2:
			{
				ScenarioSelectControl1.VM.OrderingChange(((ComboBox)CB_ScenOrder).SelectedIndex);
				break;
			}
			IL_006e:
			list = Module1.AllNodes(darkTreeView).ToList();
			foreach (DarkTreeNode item in list)
			{
				if (item.Expanded)
				{
					method_11(item);
				}
			}
			list2 = new List<DarkTreeNode>();
			foreach (DarkTreeNode node in darkTreeView.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					list2.Add(node);
				}
			}
			foreach (DarkTreeNode item2 in list2)
			{
				darkTreeView.Nodes.Remove(item2);
			}
			list3 = method_4(from theFN in Directory.GetFiles(GameGeneral.ScenariosRootPath)
				where Operators.CompareString(Path.GetExtension(theFN), CS$<>8__locals5.$VB$Local_FileExtension, true) == 0
				select theFN);
			foreach (string item3 in list3)
			{
				string_1 = Path.GetFileName(item3);
				if (Operators.CompareString(CS$<>8__locals5.$VB$Local_FileExtension, ".save", true) == 0)
				{
					fileInfo_0 = new FileInfo(item3);
					string_1 = "[" + fileInfo_0.LastWriteTime.ToShortDateString() + " " + fileInfo_0.LastWriteTime.ToShortTimeString() + "] " + string_1;
				}
				DarkTreeNode darkTreeNode = new DarkTreeNode(string_1);
				darkTreeView.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = item3;
			}
			break;
		}
	}

	private void LoadScenario_FormClosed(object sender, FormClosedEventArgs e)
	{
		scenario_0 = null;
	}

	private void method_15(object sender, DoWorkEventArgs e)
	{
		if (!Information.IsNothing((object)scenContainer_0))
		{
			string_2 = Scenario.QueryScenario_ScenXML(scenContainer_0.GetScenarioObject_AsXML(), "ContentTag");
		}
	}

	private void method_16(object sender, RunWorkerCompletedEventArgs e)
	{
		if (!Licensing.IsUserLicensedForThisContent(string_2))
		{
			((Label)Label_Title).Text = "[NOT LICENSED] " + scenContainer_0.ScenTitle;
			((Control)Label_Title).ForeColor = Color.IndianRed;
		}
	}

	private void method_17(object sender, EventArgs e)
	{
		if (TV_Saves.SelectedNodes.Count == 0)
		{
			return;
		}
		string text = TV_Saves.SelectedNodes[0].Tag.ToString();
		if (!Directory.Exists(text))
		{
			if (FileExistsNative.FileExistsFast(text))
			{
				((Control)Label_Title).Visible = true;
				((Control)Label1).Visible = true;
				((Control)PB_Difficulty).Visible = true;
				((Control)Label2).Visible = true;
				((Control)PB_Complexity).Visible = true;
				((Control)Label4).Visible = true;
				((Control)DeleteSelected_Button).Visible = true;
				LoadFromPath(text, TV_Saves.SelectedNodes[0].Tag.ToString());
			}
		}
		else
		{
			((Control)Label_Title).Visible = false;
			((Control)Label1).Visible = false;
			((Control)PB_Difficulty).Visible = false;
			((Control)Label2).Visible = false;
			((Control)PB_Complexity).Visible = false;
			((Control)Label4).Visible = false;
			((Control)WebBrowser1).Visible = false;
			((Control)DeleteSelected_Button).Visible = false;
		}
	}

	private void sysSxfIfbyO(object sender, EventArgs e)
	{
		if (TV_Scens.SelectedNodes.Count == 0)
		{
			return;
		}
		string text = TV_Scens.SelectedNodes[0].Tag.ToString();
		if (!Directory.Exists(text))
		{
			if (FileExistsNative.FileExistsFast(text))
			{
				((Control)Label_Title).Visible = true;
				((Control)Label1).Visible = true;
				((Control)PB_Difficulty).Visible = true;
				((Control)Label2).Visible = true;
				((Control)PB_Complexity).Visible = true;
				((Control)Label4).Visible = true;
				((Control)WebBrowser1).Visible = true;
				((Control)DeleteSelected_Button).Visible = false;
				LoadFromPath(text, TV_Scens.SelectedNodes[0].Tag.ToString());
			}
		}
		else
		{
			((Control)Label_Title).Visible = false;
			((Control)Label1).Visible = false;
			((Control)PB_Difficulty).Visible = false;
			((Control)Label2).Visible = false;
			((Control)PB_Complexity).Visible = false;
			((Control)Label4).Visible = false;
			((Control)WebBrowser1).Visible = false;
			((Control)DeleteSelected_Button).Visible = false;
		}
	}

	public void LoadFromPath(string thePath, string selFilename)
	{
		try
		{
			try
			{
				scenContainer_0 = ScenContainer.LoadFromFile(thePath);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Module1.IsValidXml(thePath))
				{
					string ErrorFeedback = null;
					Scenario theScen = Scenario.smethod_0(thePath, ref ErrorFeedback, null);
					scenContainer_0 = new ScenContainer(theScen);
				}
				ProjectData.ClearProjectError();
			}
			string_0 = selFilename;
			if (!Helper.smethod_1(WebBrowser1, scenContainer_0.ScenDescription, Path.GetDirectoryName(string_0)).Result)
			{
				Module1.RenderCustomHTML(WebBrowser1, scenContainer_0.ScenDescription);
				((Control)WebBrowser1).Visible = true;
			}
			((Label)Label_Title).Text = scenContainer_0.ScenTitle;
			((Control)Label_Title).ForeColor = Color.Gainsboro;
			((Label)DatabaseVersion).Text = "";
			if (!vmethod_2().IsBusy)
			{
				vmethod_2().RunWorkerAsync();
			}
			PB_Difficulty.Value = 20 * scenContainer_0.Difficulty;
			PB_Complexity.Value = 20 * scenContainer_0.Complexity;
			switch (scenContainer_0.Difficulty)
			{
			case 1:
				PB_Difficulty.CustomForeColor = Color.Green;
				break;
			case 2:
				PB_Difficulty.CustomForeColor = Color.LimeGreen;
				break;
			case 3:
				PB_Difficulty.CustomForeColor = Color.Yellow;
				break;
			case 4:
				PB_Difficulty.CustomForeColor = Color.Orange;
				break;
			case 5:
				PB_Difficulty.CustomForeColor = Color.Red;
				break;
			}
			switch (scenContainer_0.Complexity)
			{
			case 1:
				PB_Complexity.CustomForeColor = Color.Green;
				break;
			case 2:
				PB_Complexity.CustomForeColor = Color.LimeGreen;
				break;
			case 3:
				PB_Complexity.CustomForeColor = Color.Yellow;
				break;
			case 4:
				PB_Complexity.CustomForeColor = Color.Orange;
				break;
			case 5:
				PB_Complexity.CustomForeColor = Color.Red;
				break;
			}
			((Label)Label4).Text = "";
			if (!string.IsNullOrEmpty(scenContainer_0.ScenSetting))
			{
				((Label)Label4).Text = "Location: " + scenContainer_0.ScenSetting;
			}
			if (!string.IsNullOrEmpty(scenContainer_0.ScenSetting))
			{
				((Label)Label4).Text = ((Label)Label4).Text + "  --  ";
			}
			((Label)Label4).Text = ((Label)Label4).Text + "Year: " + Conversions.ToString((int)scenContainer_0.ScenDate);
			((Label)DatabaseVersion).Text = "Uses: " + scenContainer_0.string_0.Split(new char[1] { '.' })[0];
			if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
			{
				Client.SaveScenarioPath = thePath;
			}
			else
			{
				Client.SaveScenarioPath = null;
			}
			string text = scenContainer_0.ScenTitle;
			if (!string.IsNullOrEmpty(text))
			{
				char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
				foreach (char c in invalidFileNameChars)
				{
					text = text.Replace(Conversions.ToString(c), "");
				}
			}
			string text2 = GameGeneral.ScenariosRootPath + "\\Autosaves\\" + text;
			((Control)LoadAutosaveButton).Visible = File.Exists(text2 + "\\Autosave.scen");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			((Control)DeleteSelected_Button).Visible = true;
			((Control)Label_Title).ForeColor = Color.IndianRed;
			((Label)Label_Title).Text = "Error!";
			Module1.RenderCustomHTML(WebBrowser1, "ERROR - Unable to load scenario \"" + Path.GetFileName(thePath) + "\"!<br/>Please copy this entire text and submit it to the dev team for investigation.<br/> Exception: " + ex2.Message + "<br/>Exception source: " + ex2.Source + "<br/>Stack Trace:" + ex2.StackTrace + "<br/>" + ((scenContainer_0 == null) ? "" : ("Compression Mode: " + Conversions.ToString(scenContainer_0.CompressVersion))));
			ProjectData.ClearProjectError();
		}
	}

	private void method_18(DarkTreeView darkTreeView_0, DarkTreeNode darkTreeNode_0)
	{
		method_11(darkTreeNode_0);
	}

	private void method_19(DarkTreeView darkTreeView_0, DarkTreeNode darkTreeNode_0)
	{
		method_11(darkTreeNode_0);
	}

	private void method_20(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		((FileDialog)OpenFileDialog1).DefaultExt = "*.scen;*.save";
		((FileDialog)OpenFileDialog1).FileName = "*.scen;*.save";
		((FileDialog)OpenFileDialog1).Filter = "Scenario files (.scen)|*.scen|Save files (.save)|*.save";
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			MyProject.Forms.ResumeFromSave.SelectedFilename = ((FileDialog)OpenFileDialog1).FileName;
			MyProject.Forms.ResumeFromSave.RaiseEventMode = RaiseEventMode;
			((Control)MyProject.Forms.ResumeFromSave).Show();
			if (((Control)MyProject.Forms.StartGame).Visible)
			{
				((Form)MyProject.Forms.StartGame).Close();
			}
			RaiseEventMode = false;
			((Form)this).Close();
		}
	}

	private void method_21(object sender, EventArgs e)
	{
		_Closure$__173-0 arg = default(_Closure$__173-0);
		_Closure$__173-0 CS$<>8__locals8 = new _Closure$__173-0(arg);
		CS$<>8__locals8.$VB$Me = this;
		if (scenContainer_0 == null)
		{
			return;
		}
		string text = scenContainer_0.ScenTitle;
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		foreach (char c in invalidFileNameChars)
		{
			text = text.Replace(Conversions.ToString(c), "");
		}
		CS$<>8__locals8.$VB$Local_AutosavesPath = GameGeneral.ScenariosRootPath + "\\Autosaves\\" + text;
		MainForm.KillAllRendering = true;
		if (Information.IsNothing((object)scenContainer_0))
		{
			return;
		}
		LoadAutosaveButton.Enabled = false;
		if (Client.CurrentGame.Status == Game._GameStatus.Running)
		{
			Client.CurrentGame.Pause();
		}
		Client.MainThreadDispatcher.InvokeAsync((Action)([SpecialName] () =>
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			if (!File.Exists(CS$<>8__locals8.$VB$Local_AutosavesPath + "\\Autosave.scen"))
			{
				DarkMessageBox.ShowError("No autosave file was found at the path" + CS$<>8__locals8.$VB$Local_AutosavesPath + "\\Autosave.scen", "No autosave found");
			}
			else
			{
				Client.CurrentGame.GameMode = Game._GameMode.SinglePlayer;
				MyProject.Forms.ResumeFromSave.SelectedFilename = CS$<>8__locals8.$VB$Local_AutosavesPath + "\\Autosave.scen";
				MyProject.Forms.ResumeFromSave.RaiseEventMode = CS$<>8__locals8.$VB$Me.RaiseEventMode;
				((Control)MyProject.Forms.ResumeFromSave).Show();
				CS$<>8__locals8.$VB$Me.RaiseEventMode = false;
				((Form)CS$<>8__locals8.$VB$Me).Close();
			}
		}));
	}

	private void method_22(object object_0)
	{
		if (txtScenSearch.Text != null)
		{
			SearchString = txtScenSearch.Text;
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		if (((TabControl)TabControl1).SelectedIndex == 2)
		{
			if (!MyProject.Forms.MainForm.Timer_SteamWorkshop.Enabled)
			{
				MyProject.Forms.MainForm.Timer_SteamWorkshop.Interval = 30000;
				MyProject.Forms.MainForm.Timer_SteamWorkshop.Start();
			}
			SteamWorkshop.UpdateSubscribedItems();
		}
	}

	private void LoadScenario_Closed(object sender, EventArgs e)
	{
		if (MyProject.Forms.MainForm.Timer_SteamWorkshop.Enabled && (MyProject.Forms.m_SteamPublishScenarioForm == null || !((Control)MyProject.Forms.SteamPublishScenarioForm).Visible) && (MyProject.Forms.m_SteamUpdateScenarioForm == null || !((Control)MyProject.Forms.SteamUpdateScenarioForm).Visible))
		{
			MyProject.Forms.MainForm.Timer_SteamWorkshop.Stop();
		}
	}

	static LoadScenario()
	{
		Class72.smethod_20();
	}
}
