using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public class NavalFormationEditor : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_12_NavalFormationEditor_Load : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal NavalFormationEditor $VB$Me;

		internal object[] $VB$ResumableLocal_Response$0;

		internal TaskAwaiter<object[]> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				_Closure$__12-1 $VB$NonLocal_$VB$Closure_ = default(_Closure$__12-1);
				if (num != -3 && num != 0)
				{
					$VB$NonLocal_$VB$Closure_ = new _Closure$__12-1();
					$VB$ResumableLocal_Response$0 = null;
				}
				try
				{
					if (num == -3)
					{
						num = -1;
						$State = -1;
						return;
					}
					TaskAwaiter<object[]> awaiter;
					if (num == 0)
					{
						num = -1;
						$State = -1;
						awaiter = $A0;
						$A0 = default(TaskAwaiter<object[]>);
						goto IL_00d3;
					}
					_Closure$__12-0 CS$<>8__locals6 = new _Closure$__12-0();
					CS$<>8__locals6.$VB$NonLocal_$VB$Closure_2 = $VB$NonLocal_$VB$Closure_;
					CS$<>8__locals6.$VB$NonLocal_$VB$Closure_2.$VB$Local_TheScript = GameGeneral.GetNavalFormationEditorScriptResource();
					if (!string.IsNullOrEmpty(CS$<>8__locals6.$VB$NonLocal_$VB$Closure_2.$VB$Local_TheScript))
					{
						CS$<>8__locals6.$VB$Local_theSB = Client.CurrentScenario.Scenario_LuaSandbox;
						awaiter = LuaDispatcher.EnqueueAsync([SpecialName] () => CS$<>8__locals6.$VB$Local_theSB.RunScript(CS$<>8__locals6.$VB$NonLocal_$VB$Closure_2.$VB$Local_TheScript, RunInteractively: true, "Console")).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00d3;
					}
					goto end_IL_001f;
					IL_00d3:
					object[] result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<object[]>);
					$VB$ResumableLocal_Response$0 = result;
					goto IL_0138;
					end_IL_001f:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 1128112811281128", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					goto IL_0138;
				}
				goto end_IL_0007;
				IL_0138:
				try
				{
					$VB$Me.method_2(Conversions.ToString(RuntimeHelpers.GetObjectValue($VB$ResumableLocal_Response$0.First())));
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 1138113811381138", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				end_IL_0007:;
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

		static VB$StateMachine_12_NavalFormationEditor_Load()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_13_DisplayContent : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal string $VB$Local_theContent;

		internal NavalFormationEditor $VB$Me;

		internal TaskAwaiter $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter);
				}
				else
				{
					if ($VB$Me.WebBrowser1 == null)
					{
						goto IL_00a2;
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
					goto IL_00a2;
				}
				goto end_IL_0008;
				IL_00a2:
				$VB$Me.WebBrowser1.CoreWebView2.Settings.IsScriptEnabled = true;
				$VB$Me.WebBrowser1.WebMessageReceived -= $VB$Me.WebView_WebMessageReceived;
				$VB$Me.WebBrowser1.WebMessageReceived += $VB$Me.WebView_WebMessageReceived;
				Module1.RenderCustomHTML($VB$Me.WebBrowser1, "<span style='font:Arial'>" + $VB$Local_theContent + "<span>");
				if (!GameGeneral.Beta_HTMLDebug)
				{
					$VB$Me.WebBrowser1.CoreWebView2.Settings.AreDevToolsEnabled = false;
					$VB$Me.WebBrowser1.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
					$VB$Me.WebBrowser1.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
				}
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

		static VB$StateMachine_13_DisplayContent()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_14_WebView_WebMessageReceived : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal CoreWebView2WebMessageReceivedEventArgs $VB$Local_e;

		internal NavalFormationEditor $VB$Me;

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
					goto IL_00e5;
				}
				_Closure$__14-0 CS$<>8__locals4 = new _Closure$__14-0();
				string text = "";
				text = $VB$Local_e.TryGetWebMessageAsString();
				if (text.Contains("DIALOG_OK"))
				{
					((Form)$VB$Me).DialogResult = (DialogResult)4;
				}
				CS$<>8__locals4.$VB$Local_lua = text.Replace("DIALOG_OK", "");
				if (!string.IsNullOrEmpty(CS$<>8__locals4.$VB$Local_lua))
				{
					if (!Client.Realtime || Client.RealtimeAC)
					{
						awaiter = LuaDispatcher.EnqueueAsync([SpecialName] () => Client.CurrentScenario.Scenario_LuaSandbox.RunScript(CS$<>8__locals4.$VB$Local_lua, RunInteractively: false)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00e5;
					}
					Client.RealtimeTerminal.SendSetFormation(CS$<>8__locals4.$VB$Local_lua);
				}
				goto end_IL_0007;
				IL_00e5:
				awaiter.GetResult();
				awaiter = default(TaskAwaiter<object[]>);
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

		static VB$StateMachine_14_WebView_WebMessageReceived()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-0
	{
		public LuaSandBox $VB$Local_theSB;

		public _Closure$__12-1 $VB$NonLocal_$VB$Closure_2;

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return $VB$Local_theSB.RunScript($VB$NonLocal_$VB$Closure_2.$VB$Local_TheScript, RunInteractively: true, "Console");
		}

		static _Closure$__12-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-1
	{
		public string $VB$Local_TheScript;

		static _Closure$__12-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__14-0
	{
		public string $VB$Local_lua;

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return Client.CurrentScenario.Scenario_LuaSandbox.RunScript($VB$Local_lua, RunInteractively: false);
		}

		static _Closure$__14-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

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

	public NavalFormationEditor()
	{
		((Form)this).Load += NavalFormationEditor_Load;
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
		WebBrowser1 = new WebView2();
		((ISupportInitialize)WebBrowser1).BeginInit();
		((Control)this).SuspendLayout();
		WebBrowser1.AllowExternalDrop = true;
		WebBrowser1.CreationProperties = null;
		WebBrowser1.DefaultBackgroundColor = Color.White;
		((Control)WebBrowser1).Dock = (DockStyle)5;
		((Control)WebBrowser1).Location = new Point(0, 0);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(800, 450);
		((Control)WebBrowser1).TabIndex = 24;
		WebBrowser1.ZoomFactor = 1.0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(800, 450);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Name = "NavalFormationEditor";
		((Form)this).Text = "Naval Formation Editor";
		((ISupportInitialize)WebBrowser1).EndInit();
		((Control)this).ResumeLayout(false);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_12_NavalFormationEditor_Load))]
	private void NavalFormationEditor_Load(object sender, EventArgs e)
	{
		VB$StateMachine_12_NavalFormationEditor_Load stateMachine = default(VB$StateMachine_12_NavalFormationEditor_Load);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_13_DisplayContent))]
	private void method_2(string string_0)
	{
		VB$StateMachine_13_DisplayContent stateMachine = default(VB$StateMachine_13_DisplayContent);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_theContent = string_0;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_14_WebView_WebMessageReceived))]
	public void WebView_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
	{
		VB$StateMachine_14_WebView_WebMessageReceived stateMachine = default(VB$StateMachine_14_WebView_WebMessageReceived);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	static NavalFormationEditor()
	{
		Class72.smethod_20();
	}
}
