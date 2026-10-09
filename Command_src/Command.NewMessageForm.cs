using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class NewMessageForm : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_48_DisplayMessage : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal LoggedMessage $VB$Local_theMessage;

		internal NewMessageForm $VB$Me;

		internal string $VB$ResumableLocal_theText$0;

		internal TaskAwaiter $A0;

		internal TaskAwaiter<(string, bool)> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter awaiter;
				TaskAwaiter<(string, bool)> awaiter2;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter);
				}
				else
				{
					if (num == 1)
					{
						num = -1;
						$State = -1;
						awaiter2 = $A1;
						$A1 = default(TaskAwaiter<(string, bool)>);
						goto IL_0139;
					}
					$VB$ResumableLocal_theText$0 = $VB$Local_theMessage.Text.Replace("\ufffd", "°");
					if ($VB$Me.WebBrowser1 == null)
					{
						goto IL_00c2;
					}
					awaiter = WebBrowserHelper.InitialiseWebview2Browser($VB$Me.WebBrowser1).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				awaiter.GetResult();
				awaiter = default(TaskAwaiter);
				if ($VB$Me.WebBrowser1.CoreWebView2 != null)
				{
					goto IL_00c2;
				}
				goto end_IL_0007;
				IL_0139:
				(string, bool) result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<(string, bool)>);
				(string, bool) tuple = result;
				if ($VB$Local_theMessage.Type == LoggedMessage.MessageType.SpecialMessage && tuple.Item2)
				{
					var (source, _) = tuple;
					$VB$Local_theMessage.Summary = "Special Message - Expand to read";
					$VB$Local_theMessage.Text = StripHTML.StripTagsRegex(source);
				}
				else
				{
					$VB$Me.WebBrowser1.CoreWebView2.Settings.IsScriptEnabled = true;
					$VB$Me.WebBrowser1.WebMessageReceived -= $VB$Me.WebView_WebMessageReceived;
					$VB$Me.WebBrowser1.WebMessageReceived += $VB$Me.WebView_WebMessageReceived;
					if ($VB$ResumableLocal_theText$0.StartsWith("<!DOCTYPE"))
					{
						Module1.RenderCustomHTML($VB$Me.WebBrowser1, "", $VB$ResumableLocal_theText$0);
					}
					else
					{
						Module1.RenderCustomHTML($VB$Me.WebBrowser1, "<span style='font:Arial'>" + $VB$ResumableLocal_theText$0 + "<span>");
					}
				}
				if ($VB$Local_theMessage.Location.HasValue && (($VB$Local_theMessage.Location.Value.Latitude != 0.0) | ($VB$Local_theMessage.Location.Value.Longitude != 0.0)))
				{
					((ToolStripItem)$VB$Me.ToolStripButton1).Visible = true;
				}
				else
				{
					((ToolStripItem)$VB$Me.ToolStripButton1).Visible = false;
				}
				((ToolStripItem)$VB$Me.TSB_PrevMessage).Enabled = $VB$Me.Messages.IndexOf($VB$Me.loggedMessage_0) != 0;
				((ToolStripItem)$VB$Me.TSB_NextMessage).Enabled = $VB$Me.Messages.IndexOf($VB$Me.loggedMessage_0) != $VB$Me.Messages.Count - 1;
				((Control)$VB$Me).BringToFront();
				if ($VB$Local_theMessage.ForceMapRecentre)
				{
					MyProject.Forms.MainForm.set_MapCenter(MustRender: true, $VB$Local_theMessage.Location.Value.ToGeoPoint());
				}
				goto end_IL_0007;
				IL_00c2:
				awaiter2 = $VB$Me.method_2($VB$Me.WebBrowser1, $VB$ResumableLocal_theText$0, Path.GetDirectoryName(Client.CurrentScenarioFullFilePath)).GetAwaiter();
				if (!awaiter2.IsCompleted)
				{
					num = 1;
					$State = 1;
					$A1 = awaiter2;
					$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
				goto IL_0139;
				end_IL_0007:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
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

		static VB$StateMachine_48_DisplayMessage()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_58_WebView_WebMessageReceived : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal CoreWebView2WebMessageReceivedEventArgs $VB$Local_e;

		internal NewMessageForm $VB$Me;

		internal TaskAwaiter<object[]> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter<object[]> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<object[]>);
					goto IL_00c5;
				}
				_Closure$__58-0 CS$<>8__locals3 = new _Closure$__58-0();
				string text = "";
				text = $VB$Local_e.TryGetWebMessageAsString();
				if (text.Contains("DIALOG_OK"))
				{
					((Form)$VB$Me).DialogResult = (DialogResult)4;
				}
				CS$<>8__locals3.$VB$Local_lua = text.Replace("DIALOG_OK", "");
				if (!string.IsNullOrEmpty(CS$<>8__locals3.$VB$Local_lua))
				{
					awaiter = LuaDispatcher.EnqueueAsync([SpecialName] () => Client.CurrentScenario.Scenario_LuaSandbox.RunScript(CS$<>8__locals3.$VB$Local_lua, RunInteractively: false)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00c5;
				}
				goto end_IL_0008;
				IL_00c5:
				awaiter.GetResult();
				awaiter = default(TaskAwaiter<object[]>);
				end_IL_0008:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception exception = ex;
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

		static VB$StateMachine_58_WebView_WebMessageReceived()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__58-0
	{
		public string $VB$Local_lua;

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return Client.CurrentScenario.Scenario_LuaSandbox.RunScript($VB$Local_lua, RunInteractively: false);
		}

		static _Closure$__58-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("ToolStripButton1")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton1;

	[AccessedThroughProperty("ToolStripButton2")]
	[CompilerGenerated]
	private ToolStripButton _ToolStripButton2;

	[AccessedThroughProperty("PopupOptions")]
	[CompilerGenerated]
	private ToolStripButton _PopupOptions;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_PrevMessage")]
	private ToolStripButton _TSB_PrevMessage;

	[CompilerGenerated]
	[AccessedThroughProperty("TSB_NextMessage")]
	private ToolStripButton _TSB_NextMessage;

	[CompilerGenerated]
	[AccessedThroughProperty("WebBrowser1")]
	private WebView2 _WebBrowser1;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolStripButton4")]
	private ToolStripButton _ToolStripButton4;

	[CompilerGenerated]
	private bool bool_2;

	[AccessedThroughProperty("Messages")]
	[CompilerGenerated]
	private ObservableCollection<LoggedMessage> observableCollection_0;

	private LoggedMessage loggedMessage_0;

	[field: AccessedThroughProperty("ToolStrip1")]
	internal virtual DarkToolStrip ToolStrip1 { get; set; }

	internal virtual ToolStripButton ToolStripButton1
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			ToolStripButton val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton1 = value;
			val = _ToolStripButton1;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton2
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			ToolStripButton val = _ToolStripButton2;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton2 = value;
			val = _ToolStripButton2;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton PopupOptions
	{
		[CompilerGenerated]
		get
		{
			return _PopupOptions;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_6;
			ToolStripButton val = _PopupOptions;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_PopupOptions = value;
			val = _PopupOptions;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_PrevMessage
	{
		[CompilerGenerated]
		get
		{
			return _TSB_PrevMessage;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			ToolStripButton val = _TSB_PrevMessage;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_PrevMessage = value;
			val = _TSB_PrevMessage;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripButton TSB_NextMessage
	{
		[CompilerGenerated]
		get
		{
			return _TSB_NextMessage;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_10;
			ToolStripButton val = _TSB_NextMessage;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_TSB_NextMessage = value;
			val = _TSB_NextMessage;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual WebView2 WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return _WebBrowser1;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			PreviewKeyDownEventHandler val = new PreviewKeyDownEventHandler(method_11);
			WebView2 webView = _WebBrowser1;
			if (webView != null)
			{
				((Control)webView).PreviewKeyDown -= val;
			}
			_WebBrowser1 = value;
			webView = _WebBrowser1;
			if (webView != null)
			{
				((Control)webView).PreviewKeyDown += val;
			}
		}
	}

	internal virtual ToolStripButton ToolStripButton4
	{
		[CompilerGenerated]
		get
		{
			return _ToolStripButton4;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_7;
			ToolStripButton val = _ToolStripButton4;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ToolStripButton4 = value;
			val = _ToolStripButton4;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
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

	public virtual ObservableCollection<LoggedMessage> Messages
	{
		[CompilerGenerated]
		get
		{
			return observableCollection_0;
		}
		[CompilerGenerated]
		set
		{
			NotifyCollectionChangedEventHandler value2 = method_8;
			ObservableCollection<LoggedMessage> observableCollection = observableCollection_0;
			if (observableCollection != null)
			{
				observableCollection.CollectionChanged -= value2;
			}
			observableCollection_0 = value;
			observableCollection = observableCollection_0;
			if (observableCollection != null)
			{
				observableCollection.CollectionChanged += value2;
			}
		}
	}

	public NewMessageForm()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(NewMessageForm_FormClosing);
		((Form)this).Load += NewMessageForm_Load;
		((Control)this).KeyDown += new KeyEventHandler(NewMessageForm_KeyDown);
		RTMPEnabled = true;
		Messages = new ObservableCollection<LoggedMessage>();
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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(NewMessageForm));
		ToolStrip1 = new DarkToolStrip();
		TSB_PrevMessage = new ToolStripButton();
		TSB_NextMessage = new ToolStripButton();
		ToolStripButton1 = new ToolStripButton();
		ToolStripButton2 = new ToolStripButton();
		PopupOptions = new ToolStripButton();
		WebBrowser1 = new WebView2();
		ToolStripButton4 = new ToolStripButton();
		((Control)ToolStrip1).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)ToolStrip1).AutoSize = false;
		((ToolStrip)ToolStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)ToolStrip1).Dock = (DockStyle)2;
		((ToolStrip)ToolStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)ToolStrip1).GripStyle = (ToolStripGripStyle)0;
		((ToolStrip)ToolStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[6]
		{
			(ToolStripItem)TSB_PrevMessage,
			(ToolStripItem)TSB_NextMessage,
			(ToolStripItem)ToolStripButton1,
			(ToolStripItem)ToolStripButton2,
			(ToolStripItem)ToolStripButton4,
			(ToolStripItem)PopupOptions
		});
		((Control)ToolStrip1).Location = new Point(0, 167);
		((Control)ToolStrip1).Name = "ToolStrip1";
		((Control)ToolStrip1).Padding = new Padding(5, 0, 1, 0);
		((Control)ToolStrip1).Size = new Size(565, 25);
		((ToolStrip)ToolStrip1).Stretch = true;
		((Control)ToolStrip1).TabIndex = 4;
		((Control)ToolStrip1).Text = "ToolStrip1";
		((ToolStripItem)TSB_PrevMessage).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_PrevMessage).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_PrevMessage).Image = (Image)componentResourceManager.GetObject("TSB_PrevMessage.Image");
		((ToolStripItem)TSB_PrevMessage).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_PrevMessage).Name = "TSB_PrevMessage";
		((ToolStripItem)TSB_PrevMessage).Size = new Size(72, 22);
		((ToolStripItem)TSB_PrevMessage).Text = "Previous";
		((ToolStripItem)TSB_NextMessage).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSB_NextMessage).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSB_NextMessage).Image = (Image)componentResourceManager.GetObject("TSB_NextMessage.Image");
		((ToolStripItem)TSB_NextMessage).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)TSB_NextMessage).Name = "TSB_NextMessage";
		((ToolStripItem)TSB_NextMessage).Size = new Size(52, 22);
		((ToolStripItem)TSB_NextMessage).Text = "Next";
		((ToolStripItem)ToolStripButton1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton1).Image = (Image)componentResourceManager.GetObject("ToolStripButton1.Image");
		((ToolStripItem)ToolStripButton1).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton1).Name = "ToolStripButton1";
		((ToolStripItem)ToolStripButton1).Size = new Size(119, 22);
		((ToolStripItem)ToolStripButton1).Text = "Jump to Location";
		((ToolStripItem)ToolStripButton2).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton2).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton2).Image = (Image)componentResourceManager.GetObject("ToolStripButton2.Image");
		((ToolStripItem)ToolStripButton2).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton2).Name = "ToolStripButton2";
		((ToolStripItem)ToolStripButton2).Size = new Size(56, 22);
		((ToolStripItem)ToolStripButton2).Text = "Close";
		((ToolStripItem)PopupOptions).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)PopupOptions).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)PopupOptions).Image = (Image)componentResourceManager.GetObject("PopupOptions.Image");
		((ToolStripItem)PopupOptions).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)PopupOptions).Name = "PopupOptions";
		((ToolStripItem)PopupOptions).Size = new Size(112, 22);
		((ToolStripItem)PopupOptions).Text = "Pop-up Options";
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		((Control)WebBrowser1).Location = new Point(0, -1);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(565, 165);
		((Control)WebBrowser1).TabIndex = 16;
		((ToolStripItem)ToolStripButton4).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)ToolStripButton4).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ToolStripButton4).Image = (Image)componentResourceManager.GetObject("ToolStripButton4.Image");
		((ToolStripItem)ToolStripButton4).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)ToolStripButton4).Name = "ToolStripButton4";
		((ToolStripItem)ToolStripButton4).Size = new Size(112, 22);
		((ToolStripItem)ToolStripButton4).Text = "Close + Resume";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(565, 192);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)ToolStrip1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "NewMessageForm";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "New Message";
		((Control)ToolStrip1).ResumeLayout(false);
		((Control)ToolStrip1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void NewMessageForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			Client.OpenMessageWindows.Remove(Messages[0].Type);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200393", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void NewMessageForm_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		if (Messages.Count == 0)
		{
			((Form)this).Close();
		}
		loggedMessage_0 = Messages[0];
		method_3(loggedMessage_0);
		((ToolStripItem)TSB_PrevMessage).Enabled = false;
		((ToolStripItem)TSB_NextMessage).Enabled = Messages.Count > 1;
		((Control)this).BringToFront();
	}

	private async Task<(string, bool)> method_2(WebView2 webView2_0, string string_0, string string_1)
	{
		bool flag = false;
		string item = string.Empty;
		if (string_0.Contains("[LOADDOC"))
		{
			string pattern = "\\[LOADDOC\\](.*?)\\[/LOADDOC\\]";
			Match match = Regex.Match(string_0, pattern);
			if (!match.Success)
			{
				return (string.Empty, false);
			}
			string value = match.Groups[1].Value;
			int num = 0;
			int num2 = 0;
			string pattern2 = "SizeX=(\\d+)";
			string pattern3 = "SizeY=(\\d+)";
			Match match2 = Regex.Match(value, pattern2);
			Match match3 = Regex.Match(value, pattern3);
			if (match2.Success)
			{
				num = Conversions.ToInteger(match2.Groups[1].Value);
			}
			if (match3.Success)
			{
				num2 = Conversions.ToInteger(match3.Groups[1].Value);
			}
			if (!string.IsNullOrEmpty(GameGeneral.AttachmentRepoPath) && FileExistsNative.FileExistsFast(Path.Combine(GameGeneral.AttachmentRepoPath, value)))
			{
				webView2_0.CoreWebView2.Navigate(Path.Combine(GameGeneral.AttachmentRepoPath, value));
				flag = true;
			}
			else
			{
				string fileName = Path.GetFileName(value);
				if (!string.IsNullOrEmpty(string_1) && FileExistsNative.FileExistsFast(Path.Combine(string_1, fileName)))
				{
					webView2_0.CoreWebView2.Navigate(Path.Combine(string_1, fileName));
					item = File.ReadAllText(Path.Combine(string_1, fileName));
					flag = true;
				}
			}
			if (flag)
			{
				if (num > 0)
				{
					((Control)this).Width = num;
				}
				if (num2 > 0)
				{
					((Control)this).Height = num2;
				}
				if (num + num2 > 0)
				{
					((Form)this).CenterToScreen();
				}
			}
			else
			{
				string text = Helper.smethod_0(value);
				string scenariosRoot = Helper.FindScenariosRoot(string_1);
				string text2 = Helper.SearchFileInScenarios(text, scenariosRoot);
				if (!string.IsNullOrEmpty(text2))
				{
					webView2_0.CoreWebView2.Navigate(text2);
				}
				else
				{
					string_0 = "SCENARIO ATTACHMENT NOT FOUND: " + text;
				}
			}
		}
		return (item, flag);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_48_DisplayMessage))]
	private void method_3(LoggedMessage loggedMessage_1)
	{
		VB$StateMachine_48_DisplayMessage stateMachine = default(VB$StateMachine_48_DisplayMessage);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_theMessage = loggedMessage_1;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_4(object sender, EventArgs e)
	{
		if (loggedMessage_0.Location.HasValue && ((loggedMessage_0.Location.Value.Latitude != 0.0) | (loggedMessage_0.Location.Value.Longitude != 0.0)))
		{
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, loggedMessage_0.Location.Value.ToGeoPoint());
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void method_6(object sender, EventArgs e)
	{
		((TabControl)MyProject.Forms.Options.TabControl1).SelectTab(2);
		((Control)MyProject.Forms.Options).Show();
	}

	private void method_7(object sender, EventArgs e)
	{
		Client.CurrentGame.Run();
		((Form)this).Close();
	}

	private void method_8(object sender, NotifyCollectionChangedEventArgs e)
	{
		((Form)this).Text = Conversions.ToString(Messages.Count) + " new messages of type: " + Misc.ToEnglishString(((LoggedMessage)e.NewItems[0]).Type);
		((ToolStripItem)TSB_PrevMessage).Enabled = Messages.IndexOf(loggedMessage_0) != 0;
		((ToolStripItem)TSB_NextMessage).Enabled = Messages.IndexOf(loggedMessage_0) != Messages.Count - 1;
	}

	private void method_9(object sender, EventArgs e)
	{
		if (Messages.IndexOf(loggedMessage_0) != 0)
		{
			loggedMessage_0 = Messages[Messages.IndexOf(loggedMessage_0) - 1];
			method_3(loggedMessage_0);
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (Messages.IndexOf(loggedMessage_0) != Messages.Count - 1)
		{
			loggedMessage_0 = Messages[Messages.IndexOf(loggedMessage_0) + 1];
			method_3(loggedMessage_0);
		}
	}

	private void NewMessageForm_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			Client.CurrentGame.Run();
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 123 && ((Control)this).Visible)
		{
			((Form)this).Close();
			Client.CurrentGame.Run();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_11(object sender, PreviewKeyDownEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			Client.CurrentGame.Run();
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 123 && ((Control)this).Visible)
		{
			((Form)this).Close();
			Client.CurrentGame.Run();
		}
		else
		{
			KeyEventArgs e2 = new KeyEventArgs(e.KeyCode);
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e2);
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_58_WebView_WebMessageReceived))]
	public void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
	{
		VB$StateMachine_58_WebView_WebMessageReceived stateMachine = default(VB$StateMachine_58_WebView_WebMessageReceived);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	static NewMessageForm()
	{
		Class72.smethod_20();
	}
}
