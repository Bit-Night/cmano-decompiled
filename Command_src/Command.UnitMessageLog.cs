using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class UnitMessageLog : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[AccessedThroughProperty("TSTB_Filter")]
	[CompilerGenerated]
	private ToolStripTextBox _TSTB_Filter;

	[AccessedThroughProperty("DarkUITabControl1")]
	[CompilerGenerated]
	private DarkUITabControl _DarkUITabControl1;

	[CompilerGenerated]
	private bool bool_2;

	private long long_0;

	private bool bool_3;

	public string SelectedUnitID;

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	[field: AccessedThroughProperty("ToolStripLabel1")]
	internal virtual ToolStripLabel ToolStripLabel1 { get; set; }

	internal virtual ToolStripTextBox TSTB_Filter
	{
		[CompilerGenerated]
		get
		{
			return _TSTB_Filter;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			EventHandler eventHandler2 = method_4;
			EventHandler eventHandler3 = method_5;
			ToolStripTextBox val = _TSTB_Filter;
			if (val != null)
			{
				((ToolStripItem)val).TextChanged -= eventHandler;
				((ToolStripControlHost)val).Enter -= eventHandler2;
				((ToolStripControlHost)val).Leave -= eventHandler3;
			}
			_TSTB_Filter = value;
			val = _TSTB_Filter;
			if (val != null)
			{
				((ToolStripItem)val).TextChanged += eventHandler;
				((ToolStripControlHost)val).Enter += eventHandler2;
				((ToolStripControlHost)val).Leave += eventHandler3;
			}
		}
	}

	internal virtual DarkUITabControl DarkUITabControl1
	{
		[CompilerGenerated]
		get
		{
			return _DarkUITabControl1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			DarkUITabControl darkUITabControl = _DarkUITabControl1;
			if (darkUITabControl != null)
			{
				((TabControl)darkUITabControl).SelectedIndexChanged -= eventHandler;
			}
			_DarkUITabControl1 = value;
			darkUITabControl = _DarkUITabControl1;
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

	[field: AccessedThroughProperty("TabPage5")]
	internal virtual TabPage TabPage5 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	[field: AccessedThroughProperty("TabPage4")]
	internal virtual TabPage TabPage4 { get; set; }

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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
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
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		WebBrowser1 = new WebView2();
		ToolStrip1 = new DarkToolStrip();
		ToolStripLabel1 = new ToolStripLabel();
		TSTB_Filter = new ToolStripTextBox();
		DarkUITabControl1 = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage5 = new TabPage();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		TabPage4 = new TabPage();
		((Control)ToolStrip1).SuspendLayout();
		((Control)DarkUITabControl1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		((Control)WebBrowser1).Location = new Point(0, 55);
		((Control)WebBrowser1).Margin = new Padding(0);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(643, 295);
		((Control)WebBrowser1).TabIndex = 24;
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[2]
		{
			(ToolStripItem)ToolStripLabel1,
			(ToolStripItem)TSTB_Filter
		});
		((Control)ToolStrip1).Location = new Point(0, 0);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(643, 25);
		((Control)ToolStrip1).TabIndex = 25;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)ToolStripLabel1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(36, 22);
		((ToolStripItem)ToolStripLabel1).Text = "Filter:";
		((ToolStripControlHost)TSTB_Filter).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripControlHost)TSTB_Filter).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSTB_Filter).Name = "TSTB_Filter";
		((ToolStripControlHost)TSTB_Filter).Size = new Size(500, 25);
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage5);
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)DarkUITabControl1).Controls.Add((Control)(object)TabPage4);
		((Control)DarkUITabControl1).Cursor = Cursors.Hand;
		((Control)DarkUITabControl1).Font = new Font("Segoe UI", 8f);
		((TabControl)DarkUITabControl1).ItemSize = new Size(80, 20);
		((Control)DarkUITabControl1).Location = new Point(0, 27);
		((Control)DarkUITabControl1).Name = "DarkUITabControl1";
		((TabControl)DarkUITabControl1).SelectedIndex = 0;
		((Control)DarkUITabControl1).Size = new Size(1040, 25);
		((Control)DarkUITabControl1).TabIndex = 26;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(1032, 0);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Sensory & Contacts";
		TabPage5.BackColor = Color.FromArgb(60, 63, 65);
		TabPage5.Location = new Point(4, 24);
		((Control)TabPage5).Name = "TabPage5";
		((Control)TabPage5).Size = new Size(1032, 0);
		TabPage5.TabIndex = 4;
		TabPage5.Text = "Weaponry";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(1032, 0);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Crew AI";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Size = new Size(1032, 0);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Damage";
		TabPage4.BackColor = Color.FromArgb(60, 63, 65);
		TabPage4.Location = new Point(4, 24);
		((Control)TabPage4).Name = "ComNetworkLog";
		((Control)TabPage4).Size = new Size(1032, 0);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "Air/Docking Ops";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(643, 345);
		((Control)this).Controls.Add((Control)(object)DarkUITabControl1);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "UnitMessageLog";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Unit Message Log";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)DarkUITabControl1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void UnitMessageLog_Resize(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SetActiveWindow(IntPtr intptr_0);

	public UnitMessageLog()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((Control)this).Resize += UnitMessageLog_Resize;
		((Form)this).FormClosing += new FormClosingEventHandler(UnitMessageLog_FormClosing);
		((Form)this).Load += UnitMessageLog_Load;
		((Control)this).Resize += UnitMessageLog_Resize_1;
		((Form)this).Shown += UnitMessageLog_Shown;
		((Control)this).KeyDown += new KeyEventHandler(UnitMessageLog_KeyDown);
		RTMPEnabled = true;
		InitializeComponent_1();
		((Control)this).SetStyle((ControlStyles)512, false);
	}

	private void UnitMessageLog_FormClosing(object sender, FormClosingEventArgs e)
	{
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void UnitMessageLog_Load(object sender, EventArgs e)
	{
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	private void UnitMessageLog_Resize_1(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
	}

	private void UnitMessageLog_Shown(object sender, EventArgs e)
	{
		Client.MustRefreshMainForm = true;
		ActiveUnit activeUnit = Client.CurrentScenario.ActiveUnits[SelectedUnitID];
		if (activeUnit != null)
		{
			((Form)this).Text = "Personal message log for: " + activeUnit.Name;
		}
		RefreshWindow(OnlyIfNewMessages: false);
	}

	public void UnitMessageLogClear()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(((Control)WebBrowser1).Height) + ";background-color:black;font-size:9pt;'></div>");
		string theHTML = stringBuilder.ToString();
		Module1.RenderCustomHTML(WebBrowser1, theHTML);
	}

	private bool method_2(LoggedMessage.MessageType messageType_0)
	{
		switch (messageType_0)
		{
		case LoggedMessage.MessageType.None:
			return false;
		case LoggedMessage.MessageType.UnitLost:
		case LoggedMessage.MessageType.UnitDamage:
			return ((TabControl)DarkUITabControl1).SelectedIndex == 3;
		case LoggedMessage.MessageType.UI:
			return false;
		case LoggedMessage.MessageType.EventEngine:
			return false;
		case LoggedMessage.MessageType.AirOps:
		case LoggedMessage.MessageType.DockingOps:
			return ((TabControl)DarkUITabControl1).SelectedIndex == 4;
		case LoggedMessage.MessageType.SpecialMessage:
			return false;
		case LoggedMessage.MessageType.WeaponEndgame:
		case LoggedMessage.MessageType.WeaponDamage:
		case LoggedMessage.MessageType.PointDefence:
		case LoggedMessage.MessageType.WeaponLogic:
		case LoggedMessage.MessageType.UnguidedWeaponModifiers:
			return ((TabControl)DarkUITabControl1).SelectedIndex == 1;
		default:
		{
			int result;
			if (!Debugger.IsAttached)
			{
				result = 0;
			}
			else
			{
				Debugger.Break();
				result = 0;
			}
			return (byte)result != 0;
		}
		case LoggedMessage.MessageType.UnitAI:
		case LoggedMessage.MessageType.UnitAIEmergency:
			return ((TabControl)DarkUITabControl1).SelectedIndex == 2;
		case LoggedMessage.MessageType.NewContact:
		case LoggedMessage.MessageType.ContactChange:
		case LoggedMessage.MessageType.NewWeaponContact:
		case LoggedMessage.MessageType.NewMineContact:
		case LoggedMessage.MessageType.CommsIsolatedMessage:
		case LoggedMessage.MessageType.NewAirContact:
		case LoggedMessage.MessageType.NewSurfaceContact:
		case LoggedMessage.MessageType.NewUnderwaterContact:
		case LoggedMessage.MessageType.NewGroundContact:
		case LoggedMessage.MessageType.CommsRelatedMessage:
			return ((TabControl)DarkUITabControl1).SelectedIndex == 0;
		}
	}

	public void RefreshWindow(bool OnlyIfNewMessages, bool TriggeredByMainform = false)
	{
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Invalid comparison between Unknown and I4
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Invalid comparison between Unknown and I4
		if (!((Control)this).Visible)
		{
			return;
		}
		if (Client.CurrentSide != null)
		{
			List<LoggedMessage> list = (from theM in Client.CurrentSide.get_MessageLog_Hybrid(Client.CurrentScenario)
				where Operators.CompareString(theM.ReporterID, SelectedUnitID, true) == 0 && method_2(theM.Type)
				orderby theM.Timestamp descending, theM.Increment descending
				select theM).ToList();
			if (OnlyIfNewMessages)
			{
				if (list.Count <= 0 || long_0 == list[0].Increment)
				{
					return;
				}
				long_0 = list[0].Increment;
			}
			if (!string.IsNullOrEmpty(((ToolStripControlHost)TSTB_Filter).Text))
			{
				list = list.Where([SpecialName] (LoggedMessage theM) => theM.Text.ToLower().Contains(((ToolStripControlHost)TSTB_Filter).Text.ToLower())).ToList();
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(((Control)WebBrowser1).Height) + ";background-color:black;font-size:9pt;'>");
			foreach (LoggedMessage item in list)
			{
				string text = "";
				if (item.Side != null)
				{
					text = item.Side.ObjectID;
				}
				string value = ((string.IsNullOrEmpty(text) || Operators.CompareString(text, Client.CurrentSide.ObjectID, true) == 0) ? (item.Timestamp.ToLongTimeString() + " - " + StripHTML.StripTagsRegexCompiled(item.Text)) : (item.Timestamp.ToLongTimeString() + " - [" + item.Side.Name + "] " + StripHTML.StripTagsRegexCompiled(item.Text)));
				Color messageColor = item.MessageColor;
				if ((int)item.get_MessageFont(((Control)this).Font).Style == 2)
				{
					stringBuilder.Append("<i>");
				}
				stringBuilder.Append("<div style='color:#" + messageColor.R.ToString("X2") + messageColor.G.ToString("X2") + messageColor.B.ToString("X2") + "'>");
				stringBuilder.Append(value);
				stringBuilder.Append("</div>");
				if ((int)item.get_MessageFont(((Control)this).Font).Style == 2)
				{
					stringBuilder.Append("</i>");
				}
				stringBuilder.Append("<br/>");
			}
			stringBuilder.Append("</div>");
			string theHTML = stringBuilder.ToString();
			Module1.RenderCustomHTML(WebBrowser1, theHTML);
			if (!bool_3)
			{
				((Control)ToolStrip1).Select();
			}
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(((Control)WebBrowser1).Height) + ";background-color:black;font-size:9pt;'>");
			stringBuilder.Append("</div>");
			string theHTML = stringBuilder.ToString();
			Module1.RenderCustomHTML(WebBrowser1, theHTML);
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
	}

	private void UnitMessageLog_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Invalid comparison between Unknown and I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Invalid comparison between Unknown and I4
		if (bool_3)
		{
			if ((e.KeyValue == 13 || e.KeyValue == 27) && ((Control)this).Visible)
			{
				((Control)ToolStrip1).Select();
			}
			if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
		if (!bool_3)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		bool_3 = true;
	}

	private void method_5(object sender, EventArgs e)
	{
		bool_3 = false;
		((Control)ToolStrip1).Select();
	}

	private void method_6(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
	}

	static UnitMessageLog()
	{
		Class72.smethod_20();
	}
}
