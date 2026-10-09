using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class CampaignEnd : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_17_CampaignEnd_Shown : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal CampaignEnd $VB$Me;

		internal TaskAwaiter<bool> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num != 0)
				{
					awaiter = Helper.smethod_1($VB$Me.WebBrowser1, $VB$Me.theCampaign.EndingText, $VB$Me.theCampaign.FolderPath).GetAwaiter();
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
					$A0 = default(TaskAwaiter<bool>);
				}
				bool result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
				if (!result)
				{
					Module1.RenderCustomHTML($VB$Me.WebBrowser1, $VB$Me.theCampaign.EndingText);
				}
				$VB$Me.method_2();
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

		static VB$StateMachine_17_CampaignEnd_Shown()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebView2 _WebBrowser1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	public Campaign theCampaign;

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
			PreviewKeyDownEventHandler val = new PreviewKeyDownEventHandler(method_3);
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
			EventHandler eventHandler = method_4;
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

	public CampaignEnd()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Shown += CampaignEnd_Shown;
		((Control)this).KeyDown += new KeyEventHandler(CampaignEnd_KeyDown);
		((Form)this).Load += CampaignEnd_Load;
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
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		WebBrowser1 = new WebView2();
		Label1 = new DarkLabel();
		Button1 = new DarkUIButton();
		((ISupportInitialize)WebBrowser1).BeginInit();
		((Control)this).SuspendLayout();
		WebBrowser1.AllowExternalDrop = true;
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		WebBrowser1.CreationProperties = null;
		WebBrowser1.DefaultBackgroundColor = Color.White;
		((Control)WebBrowser1).Location = new Point(2, 2);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(1080, 606);
		((Control)WebBrowser1).TabIndex = 20;
		WebBrowser1.ZoomFactor = 1.0;
		((Control)Label1).Anchor = (AnchorStyles)2;
		Label1.AutoSize = true;
		((Control)Label1).Font = new Font("Segoe UI", 8.25f, (FontStyle)2, (GraphicsUnit)3, (byte)161);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(479, 614);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(129, 13);
		((Control)Label1).TabIndex = 19;
		((Label)Label1).Text = "Press any key to continue";
		((Control)Button1).Anchor = (AnchorStyles)2;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(479, 614);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(129, 27);
		((Control)Button1).TabIndex = 19;
		Button1.Text = "Exit";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1085, 653);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "CampaignEnd";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "CampaignEnd";
		((ISupportInitialize)WebBrowser1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_17_CampaignEnd_Shown))]
	private void CampaignEnd_Shown(object sender, EventArgs e)
	{
		VB$StateMachine_17_CampaignEnd_Shown stateMachine = default(VB$StateMachine_17_CampaignEnd_Shown);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_2()
	{
		((Form)this).TopMost = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).WindowState = (FormWindowState)2;
	}

	private void CampaignEnd_KeyDown(object sender, KeyEventArgs e)
	{
		method_5();
	}

	private void method_3(object sender, PreviewKeyDownEventArgs e)
	{
		method_5();
	}

	private void method_4(object sender, EventArgs e)
	{
		method_5();
	}

	private void method_5()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		foreach (Form item in (ReadOnlyCollectionBase)(object)Application.OpenForms)
		{
			Form val = item;
			if ((object)val != this && (object)val != MyProject.Forms.m_MainForm && ((Control)val).Visible)
			{
				((Control)val).Hide();
			}
		}
		StartGameMenuWindow.ShowStartWindow();
		((Form)this).Close();
	}

	private void CampaignEnd_Load(object sender, EventArgs e)
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

	static CampaignEnd()
	{
		Class72.smethod_20();
	}
}
