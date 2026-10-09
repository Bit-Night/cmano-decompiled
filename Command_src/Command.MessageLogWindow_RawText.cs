using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class MessageLogWindow_RawText : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TSTB_Filter")]
	private DarkUITextBox _TSTB_Filter;

	[CompilerGenerated]
	[AccessedThroughProperty("DarkUIButton1")]
	private DarkUIButton _DarkUIButton1;

	private long long_0;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	internal virtual DarkUITextBox TSTB_Filter
	{
		[CompilerGenerated]
		get
		{
			return _TSTB_Filter;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_2;
			EventHandler eventHandler = method_3;
			EventHandler eventHandler2 = method_4;
			DarkUITextBox darkUITextBox = _TSTB_Filter;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
				((Control)darkUITextBox).Enter -= eventHandler;
				((Control)darkUITextBox).Leave -= eventHandler2;
			}
			_TSTB_Filter = value;
			darkUITextBox = _TSTB_Filter;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
				((Control)darkUITextBox).Enter += eventHandler;
				((Control)darkUITextBox).Leave += eventHandler2;
			}
		}
	}

	internal virtual DarkUIButton DarkUIButton1
	{
		[CompilerGenerated]
		get
		{
			return _DarkUIButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _DarkUIButton1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_DarkUIButton1 = value;
			darkUIButton = _DarkUIButton1;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	protected override bool RTMPEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public MessageLogWindow_RawText()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(MessageLogWindow_RawText_FormClosing);
		((Form)this).Load += MessageLogWindow_RawText_Load;
		((Control)this).Resize += MessageLogWindow_RawText_Resize;
		((Form)this).Shown += MessageLogWindow_RawText_Shown;
		((Control)this).KeyDown += new KeyEventHandler(MessageLogWindow_RawText_KeyDown);
		bool_2 = true;
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		WebBrowser1 = new WebView2();
		TSTB_Filter = new DarkUITextBox();
		DarkUIButton1 = new DarkUIButton();
		DarkLabel1 = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		((Control)WebBrowser1).Location = new Point(0, 32);
		((Control)WebBrowser1).Margin = new Padding(0);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(1040, 700);
		((Control)WebBrowser1).TabIndex = 24;
		((Control)TSTB_Filter).Anchor = (AnchorStyles)13;
		TSTB_Filter.AutoCompleteCustomSource = null;
		TSTB_Filter.AutoCompleteMode = (AutoCompleteMode)0;
		TSTB_Filter.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TSTB_Filter).BackColor = Color.Transparent;
		((Control)TSTB_Filter).ForeColor = Color.FromArgb(189, 189, 189);
		TSTB_Filter.Image = null;
		TSTB_Filter.Lines = null;
		((Control)TSTB_Filter).Location = new Point(47, 5);
		TSTB_Filter.MaxLength = 32767;
		TSTB_Filter.Multiline = false;
		((Control)TSTB_Filter).Name = "TSTB_Filter";
		TSTB_Filter.ReadOnly = false;
		TSTB_Filter.ScrollBars = (ScrollBars)0;
		TSTB_Filter.SelectionStart = 0;
		((Control)TSTB_Filter).Size = new Size(813, 24);
		((Control)TSTB_Filter).TabIndex = 26;
		TSTB_Filter.TextAlign = (HorizontalAlignment)0;
		TSTB_Filter.UseSystemPasswordChar = false;
		TSTB_Filter.WatermarkText = "";
		((Control)DarkUIButton1).Anchor = (AnchorStyles)9;
		((ButtonBase)DarkUIButton1).BackColor = Color.Transparent;
		((Button)DarkUIButton1).DialogResult = (DialogResult)0;
		((Control)DarkUIButton1).ForeColor = SystemColors.Control;
		((Control)DarkUIButton1).Location = new Point(871, 5);
		((Control)DarkUIButton1).Name = "DarkUIButton1";
		DarkUIButton1.RoundRadius = 0;
		((Control)DarkUIButton1).Size = new Size(162, 23);
		((Control)DarkUIButton1).TabIndex = 27;
		DarkUIButton1.Text = "Switch to Interactive view";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(5, 9);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(36, 15);
		((Control)DarkLabel1).TabIndex = 28;
		((Label)DarkLabel1).Text = "Filter:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1040, 732);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)DarkUIButton1);
		((Control)this).Controls.Add((Control)(object)TSTB_Filter);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MessageLogWindow";
		((Form)this).MinimumSize = new Size(200, 200);
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Message Log - Raw text view";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MessageLogWindow_RawText_FormClosing(object sender, FormClosingEventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		int mustRefreshMainForm;
		if (MyProject.Forms.MainForm.gclass1_0 != null)
		{
			mustRefreshMainForm = 1;
		}
		else if (!(((int)e.CloseReason == 3) & !Client.ShutdownInitiated))
		{
			mustRefreshMainForm = 1;
		}
		else
		{
			MyProject.Forms.MainForm.MessageLogControlViewModel.LogCollapsed = true;
			MyProject.Forms.MainForm.ShowEmbeddedMessageLog();
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void MessageLogWindow_RawText_Load(object sender, EventArgs e)
	{
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		bool_2 = true;
	}

	private void MessageLogWindow_RawText_Resize(object sender, EventArgs e)
	{
		RefreshWindow(OnlyIfNewMessages: false);
	}

	private void MessageLogWindow_RawText_Shown(object sender, EventArgs e)
	{
		Client.MustRefreshMainForm = true;
		RefreshWindow(OnlyIfNewMessages: false);
	}

	public void MessageLogWindowClear()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(((Control)WebBrowser1).Height) + ";background-color:black;font-size:9pt;'></div>");
		string theHTML = stringBuilder.ToString();
		Module1.RenderCustomHTML(WebBrowser1, theHTML);
	}

	public void RefreshWindow(bool OnlyIfNewMessages)
	{
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Invalid comparison between Unknown and I4
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Invalid comparison between Unknown and I4
		if (!Information.IsNothing((object)Client.CurrentSide))
		{
			List<LoggedMessage> list = (from theM in Client.CurrentSide.get_MessageLog_Hybrid(Client.CurrentScenario)
				orderby theM.Timestamp descending, theM.Increment descending
				select theM).ToList();
			if (OnlyIfNewMessages && list.Count > 0)
			{
				if (long_0 == list[0].Increment)
				{
					return;
				}
				long_0 = list[0].Increment;
			}
			if (!string.IsNullOrEmpty(TSTB_Filter.Text))
			{
				list = list.Where([SpecialName] (LoggedMessage theM) => theM.Text.ToLower().Contains(TSTB_Filter.Text.ToLower())).ToList();
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(((Control)WebBrowser1).Height) + ";background-color:#333333;font-size:9pt;'>");
			foreach (LoggedMessage item in list)
			{
				string text = "";
				if (item.Side != null)
				{
					text = item.Side.ObjectID;
				}
				Color messageColor = item.MessageColor;
				if ((int)item.get_MessageFont(((Control)this).Font).Style == 2)
				{
					stringBuilder.Append("<i>");
				}
				stringBuilder.Append("<div style='color:#" + messageColor.R.ToString("X2") + messageColor.G.ToString("X2") + messageColor.B.ToString("X2") + "'>");
				stringBuilder.Append(item.Timestamp.ToLongTimeString());
				if (!string.IsNullOrEmpty(text) && Operators.CompareString(text, Client.CurrentSide.ObjectID, true) != 0)
				{
					stringBuilder.Append(" - [").Append(item.Side.Name).Append("] ")
						.Append(item.Text);
				}
				else
				{
					stringBuilder.Append(" - ").Append(item.Text);
				}
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
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<div style='margin:-20 -10 -10 -10; padding:10 5 5 5;font-family:Verdana;height:" + Conversions.ToString(((Control)WebBrowser1).Height) + ";background-color:#333333;font-size:9pt;'>");
			stringBuilder.Append("</div>");
			string theHTML = stringBuilder.ToString();
			Module1.RenderCustomHTML(WebBrowser1, theHTML);
		}
	}

	private void method_2(object object_0)
	{
		RefreshWindow(OnlyIfNewMessages: false);
	}

	private void MessageLogWindow_RawText_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Invalid comparison between Unknown and I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		if (bool_2)
		{
			if ((e.KeyValue == 13 || e.KeyValue == 27) && ((Control)this).Visible)
			{
				((Control)this).Select();
			}
			if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
			{
				MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		bool_2 = false;
	}

	private void method_4(object sender, EventArgs e)
	{
		bool_2 = true;
		((Control)this).Select();
	}

	private void method_5(object sender, EventArgs e)
	{
		MyProject.Forms.MainForm.OpenMessageLogWindowWPF(((Control)this).Left, ((Control)this).Top, ((Control)this).Width, ((Control)this).Height);
		((Control)this).Hide();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (!bool_2)
		{
			return ((Form)this).ProcessCmdKey(ref msg, keyData);
		}
		Client.HandleGlobalHotkeys(keyData);
		return true;
	}

	static MessageLogWindow_RawText()
	{
		Class72.smethod_20();
	}
}
