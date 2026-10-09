using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class QuickBattle : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_22_Button_Start_Click : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal QuickBattle $VB$Me;

		internal Dictionary<string, string>.Enumerator $S0;

		internal TaskAwaiter<Dictionary<string, string>> $A0;

		internal TaskAwaiter<object[]> $A1;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			int num = $State;
			try
			{
				if ((uint)(num - -4) > 1u)
				{
				}
				try
				{
					Dictionary<string, string> result;
					TaskAwaiter<Dictionary<string, string>> awaiter;
					Dictionary<string, string> dictionary = default(Dictionary<string, string>);
					string text;
					switch (num)
					{
					case -3:
						num = -1;
						$State = -1;
						return;
					default:
						awaiter = WebBrowserHelper.smethod_0($VB$Me.theBrowser).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							$State = 0;
							$A0 = awaiter;
							$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00a5;
					case 0:
						num = -1;
						$State = -1;
						awaiter = $A0;
						$A0 = default(TaskAwaiter<Dictionary<string, string>>);
						goto IL_00a5;
					case -4:
					case 1:
						break;
						IL_00a5:
						result = awaiter.GetResult();
						awaiter = default(TaskAwaiter<Dictionary<string, string>>);
						dictionary = result;
						if (!dictionary.ContainsKey("DB"))
						{
							Client.SwitchDB(Conversions.ToString(1));
							goto IL_0125;
						}
						text = dictionary["DB"];
						if (Operators.CompareString(text, "'DB3000'", true) == 0)
						{
							Client.SwitchDB(Conversions.ToString(1));
							goto IL_0125;
						}
						if (Operators.CompareString(text, "'CWDB'", true) == 0)
						{
							Client.SwitchDB(Conversions.ToString(2));
							goto IL_0125;
						}
						DarkMessageBox.ShowError("The provided value for element 'DB' is not a valid value. ABorting...", "Invalid DB value!");
						goto end_IL_0012;
						IL_0125:
						Client.CreateNewScenario();
						break;
					}
					try
					{
						TaskAwaiter<object[]> awaiter2;
						if (num != -4)
						{
							if (num != 1)
							{
								$S0 = dictionary.GetEnumerator();
								goto IL_0166;
							}
							num = -1;
							$State = -1;
							awaiter2 = $A1;
							$A1 = default(TaskAwaiter<object[]>);
							goto IL_01b0;
						}
						num = -1;
						$State = -1;
						return;
						IL_0166:
						if ($S0.MoveNext())
						{
							_Closure$__22-0 closure$__22- = new _Closure$__22-0(closure$__22-)
							{
								$VB$Local_theKVP = $S0.Current
							};
							awaiter2 = LuaDispatcher.EnqueueAsync((Func<object[]>)closure$__22-._Lambda$__0).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = 1;
								$State = 1;
								$A1 = awaiter2;
								$Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
								return;
							}
							goto IL_01b0;
						}
						goto end_IL_012d;
						IL_01b0:
						awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<object[]>);
						goto IL_0166;
						end_IL_012d:;
					}
					finally
					{
						if (num < 0)
						{
							((IDisposable)$S0/*cast due to .constrained prefix*/).Dispose();
						}
					}
					$VB$Me.method_5();
					while (Client.CurrentScenario.Sides_ReadOnly.Length == 0)
					{
						Thread.Sleep(100);
					}
					if (Client.CurrentSide == null && Client.CurrentScenario.Sides_ReadOnly.Length > 0)
					{
						Client.CurrentSide = Client.CurrentScenario.Sides_ReadOnly[0];
					}
					if (Client.CurrentSide != null)
					{
						MyProject.Forms.MainForm.set_MapCenter(MustRender: true, Client.CurrentSide.MapCenter);
					}
					((Form)$VB$Me).Close();
					end_IL_0012:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					DarkMessageBox.ShowError("Error: " + ex2.Message, "Error");
					ProjectData.ClearProjectError();
				}
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

		static VB$StateMachine_22_Button_Start_Click()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_23_RunScript : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal QuickBattle $VB$Me;

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
				}
				else
				{
					_Closure$__23-0 closure$__23- = new _Closure$__23-0();
					string path = Conversions.ToString(RuntimeHelpers.GetObjectValue($VB$Me.TV_Scens.SelectedNodes[0].Tag));
					closure$__23-.$VB$Local_FileName = Path.Combine(path, "Script.lua");
					closure$__23-.$VB$Local_ScriptText = File.ReadAllText(closure$__23-.$VB$Local_FileName);
					awaiter = LuaDispatcher.EnqueueAsync([SpecialName] () => Client.CurrentScenario.Scenario_LuaSandbox.RunScript(closure$__23-.$VB$Local_ScriptText, RunInteractively: false, "QuickBattleInit", closure$__23-.$VB$Local_FileName)).GetAwaiter();
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
				awaiter = default(TaskAwaiter<object[]>);
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

		static VB$StateMachine_23_RunScript()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__22-0
	{
		public KeyValuePair<string, string> $VB$Local_theKVP;

		public _Closure$__22-0(_Closure$__22-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theKVP = arg0.$VB$Local_theKVP;
			}
		}

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return Client.CurrentScenario.Scenario_LuaSandbox.RunScript($VB$Local_theKVP.Key + " = " + $VB$Local_theKVP.Value, RunInteractively: false);
		}

		static _Closure$__22-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__23-0
	{
		public string $VB$Local_ScriptText;

		public string $VB$Local_FileName;

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return Client.CurrentScenario.Scenario_LuaSandbox.RunScript($VB$Local_ScriptText, RunInteractively: false, "QuickBattleInit", $VB$Local_FileName);
		}

		static _Closure$__23-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TV_Scens")]
	private DarkTreeView _TV_Scens;

	[AccessedThroughProperty("Button_Start")]
	[CompilerGenerated]
	private DarkUIButton _Button_Start;

	private Dictionary<string, string> dictionary_0;

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
			EventHandler value2 = method_6;
			DarkTreeView darkTreeView = _TV_Scens;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged -= value2;
			}
			_TV_Scens = value;
			darkTreeView = _TV_Scens;
			if (darkTreeView != null)
			{
				darkTreeView.SelectedNodesChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("theBrowser")]
	internal virtual WebView2 theBrowser { get; set; }

	internal virtual DarkUIButton Button_Start
	{
		[CompilerGenerated]
		get
		{
			return _Button_Start;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_Start;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Start = value;
			darkUIButton = _Button_Start;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	public string QuickBattlesRootPath => "QuickBattle";

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
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(QuickBattle));
		TV_Scens = new DarkTreeView();
		theBrowser = new WebView2();
		Button_Start = new DarkUIButton();
		((ISupportInitialize)theBrowser).BeginInit();
		((Control)this).SuspendLayout();
		((Control)TV_Scens).Anchor = (AnchorStyles)7;
		((Control)TV_Scens).Location = new Point(7, 5);
		TV_Scens.MaxDragChange = 20;
		((Control)TV_Scens).Name = "TV_Scens";
		((Control)TV_Scens).Size = new Size(209, 479);
		((Control)TV_Scens).TabIndex = 6;
		theBrowser.AllowExternalDrop = true;
		((Control)theBrowser).Anchor = (AnchorStyles)15;
		theBrowser.CreationProperties = null;
		theBrowser.DefaultBackgroundColor = Color.White;
		((Control)theBrowser).Location = new Point(222, 0);
		((Control)theBrowser).MinimumSize = new Size(20, 20);
		((Control)theBrowser).Name = "theBrowser";
		((Control)theBrowser).Size = new Size(629, 529);
		((Control)theBrowser).TabIndex = 16;
		((Control)theBrowser).Visible = false;
		theBrowser.ZoomFactor = 1.0;
		((Control)Button_Start).Anchor = (AnchorStyles)6;
		((ButtonBase)Button_Start).BackColor = Color.Transparent;
		((Button)Button_Start).DialogResult = (DialogResult)0;
		((Control)Button_Start).Font = new Font("Segoe UI", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_Start).ForeColor = SystemColors.Control;
		((Control)Button_Start).Location = new Point(66, 490);
		((Control)Button_Start).Name = "Button_Start";
		Button_Start.RoundRadius = 0;
		((Control)Button_Start).Size = new Size(79, 29);
		((Control)Button_Start).TabIndex = 17;
		Button_Start.Text = "START";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(850, 530);
		((Control)this).Controls.Add((Control)(object)Button_Start);
		((Control)this).Controls.Add((Control)(object)theBrowser);
		((Control)this).Controls.Add((Control)(object)TV_Scens);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).Location = new Point(0, 0);
		((Control)this).Name = "QuickBattle";
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Quick Battle Generator";
		((ISupportInitialize)theBrowser).EndInit();
		((Control)this).ResumeLayout(false);
	}

	public QuickBattle()
	{
		((Form)this).Shown += QuickBattle_Shown;
		dictionary_0 = new Dictionary<string, string>();
		InitializeComponent_1();
		ApplyStoredPositionSettings = false;
		ApplyStoredSizeSettings = false;
		int width = (int)Math.Round((double)Screen.PrimaryScreen.Bounds.Width * 0.8);
		int num = (int)Math.Round((double)Screen.PrimaryScreen.Bounds.Height * 0.8);
		((Form)this).Size = new Size(width, num - 50);
	}

	private void QuickBattle_Shown(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_2()
	{
		TV_Scens.Nodes.Clear();
		if (!Directory.Exists(QuickBattlesRootPath))
		{
			Directory.CreateDirectory(QuickBattlesRootPath);
		}
		string[] directories = Directory.GetDirectories(QuickBattlesRootPath);
		foreach (string text in directories)
		{
			if (method_3(text))
			{
				DarkTreeNode darkTreeNode = new DarkTreeNode(Path.GetFileName(text));
				TV_Scens.Nodes.Add(darkTreeNode);
				darkTreeNode.Tag = text;
			}
		}
		if (TV_Scens.Nodes.Count > 0)
		{
			TV_Scens.SelectNode(TV_Scens.Nodes[0]);
		}
	}

	private bool method_3(string string_0)
	{
		int result;
		if (Directory.GetFiles(string_0).Count() > 0)
		{
			string[] files = Directory.GetFiles(string_0);
			for (int i = 0; i < files.Length; i = checked(i + 1))
			{
				if (files[i].EndsWith(".html"))
				{
					return true;
				}
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_22_Button_Start_Click))]
	private void method_4(object sender, EventArgs e)
	{
		VB$StateMachine_22_Button_Start_Click stateMachine = default(VB$StateMachine_22_Button_Start_Click);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_23_RunScript))]
	private void method_5()
	{
		VB$StateMachine_23_RunScript stateMachine = default(VB$StateMachine_23_RunScript);
		stateMachine.$VB$Me = this;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_6(object sender, EventArgs e)
	{
		if (TV_Scens.SelectedNodes.Count > 0)
		{
			string path = Path.Combine(Conversions.ToString(TV_Scens.SelectedNodes[0].Tag), "Form.html");
			Module1.RenderCustomHTML(theBrowser, File.ReadAllText(path));
			((Control)theBrowser).Visible = true;
		}
	}

	static QuickBattle()
	{
		Class72.smethod_20();
	}
}
