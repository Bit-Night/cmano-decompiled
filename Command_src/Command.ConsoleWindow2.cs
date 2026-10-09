using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Command_Core;
using Command_Core.Lua;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua.Exceptions;
using ScintillaNET;
using ScintillaNET.Demo.Utils;

namespace Command;

[DesignerGenerated]
public sealed class ConsoleWindow2 : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_258_ConsoleWindow2_Load : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal ConsoleWindow2 $VB$Me;

		internal TaskAwaiter<string> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					$VB$Me.TextArea = new Scintilla();
					((Control)$VB$Me.TextPanel).Controls.Add((Control)(object)$VB$Me.TextArea);
					((Control)$VB$Me.TextArea).Dock = (DockStyle)5;
					$VB$Me.TextArea.WrapMode = WrapMode.None;
					$VB$Me.TextArea.IndentationGuides = IndentView.LookBoth;
					$VB$Me.TcfHuNlljb2();
					$VB$Me.method_5();
					$VB$Me.method_7();
					$VB$Me.method_8();
					$VB$Me.method_9();
					$VB$Me.InitDragDropFile();
					$VB$Me.method_4();
					((Control)$VB$Me.GB_LuaHooks).Visible = false;
					$VB$Me.int_0 = 3;
					$VB$Me.int_1 = 3;
					$VB$Me.int_3 = 30;
					((Label)$VB$Me.Label_CooldownTimer).Text = "";
					$VB$Me.bool_2 = false;
					((Control)$VB$Me.GB_ConsumerRateNotification).Visible = false;
					$VB$Me.luaSandBox_0 = Client.CurrentScenario.Scenario_LuaSandbox;
					awaiter = LuaDispatcher.RunLuaAndReturnString("_VERSION").GetAwaiter();
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
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				string text = result;
				((TextBoxBase)$VB$Me.TextBox1).AppendText("Lua version: " + text + "\r\n");
				((ComboBox)$VB$Me.ComboBox1).Items.AddRange((object[])LuaSandBox.LuaMethods.OrderBy([SpecialName] (string s) => s).ToArray());
				((ComboBox)$VB$Me.ComboBox1).SelectedIndex = 0;
				$VB$Me.luaSandBox_0.LuaPrint += $VB$Me.method_3;
				Client.ScenarioChanging += $VB$Me.method_2;
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

		static VB$StateMachine_258_ConsoleWindow2_Load()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_342_Button_Run_Click : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal ConsoleWindow2 $VB$Me;

		internal StringBuilder $VB$ResumableLocal_luaString$0;

		internal object[] $VB$ResumableLocal_Response$1;

		internal TaskAwaiter<object[]> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				if (num == -3 || num == 0)
				{
					goto IL_0177;
				}
				if ($VB$Me.int_0 >= 1)
				{
					if (!Client.CurrentScenario.Scenario_LuaSandbox.Equals($VB$Me.luaSandBox_0))
					{
						$VB$Me.luaSandBox_0.LuaPrint -= $VB$Me.method_3;
						$VB$Me.luaSandBox_0 = Client.CurrentScenario.Scenario_LuaSandbox;
						$VB$Me.luaSandBox_0.LuaPrint += $VB$Me.method_3;
					}
					if (Operators.CompareString($VB$Me.TextArea.Text.ToString(), "", true) != 0)
					{
						if (((CheckBox)$VB$Me.CB_EchoInput).Checked)
						{
							DarkTextBox textBox;
							((TextBox)(textBox = $VB$Me.TextBox1)).Text = ((TextBox)textBox).Text + "\r\n>> " + $VB$Me.TextArea.Text;
						}
						$VB$ResumableLocal_luaString$0 = new StringBuilder();
						if ($VB$Me.TextArea.Text.Length > 0)
						{
							$VB$ResumableLocal_luaString$0.Append($VB$Me.TextArea.Text);
							string InfoText = "Console: ";
							object debugTextObject = $VB$ResumableLocal_luaString$0.ToString();
							LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject, includeHeader: true);
							$VB$ResumableLocal_luaString$0.Clear();
						}
						$VB$ResumableLocal_Response$1 = null;
						goto IL_0177;
					}
				}
				goto end_IL_0008;
				IL_0177:
				try
				{
					if (num == -3)
					{
						num = -1;
						$State = -1;
						return;
					}
					TaskAwaiter<object[]> awaiter;
					if (num != 0)
					{
						awaiter = LuaDispatcher.EnqueueAsync((Func<object[]>)new _Closure$__342-0
						{
							$VB$Me = $VB$Me,
							$VB$Local_TextToExecute = $VB$Me.TextArea.Text
						}._Lambda$__0).GetAwaiter();
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
						$A0 = default(TaskAwaiter<object[]>);
					}
					object[] result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<object[]>);
					$VB$ResumableLocal_Response$1 = result;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					((TextBoxBase)$VB$Me.TextBox1).AppendText("\r\nInternal ERROR: " + ex2.Message);
					$VB$ResumableLocal_luaString$0.Append("Internal ERROR: " + ex2.Message).Append("\r\n");
					ProjectData.ClearProjectError();
				}
				if (!Information.IsNothing((object)$VB$ResumableLocal_Response$1))
				{
					if ($VB$ResumableLocal_Response$1.Count() > 0)
					{
						if ($VB$ResumableLocal_Response$1[0] != null)
						{
							if ((object)$VB$ResumableLocal_Response$1[0].GetType() == typeof(LuaScriptException))
							{
								if (!Information.IsNothing((object)((LuaScriptException)$VB$ResumableLocal_Response$1[0]).InnerException))
								{
									((TextBoxBase)$VB$Me.TextBox1).AppendText("\r\nERROR: " + ((LuaScriptException)$VB$ResumableLocal_Response$1[0]).InnerException.Message);
									$VB$ResumableLocal_luaString$0.Append("ERROR: " + ((LuaScriptException)$VB$ResumableLocal_Response$1[0]).InnerException.Message).Append("\r\n");
								}
								else
								{
									((TextBoxBase)$VB$Me.TextBox1).AppendText("\r\nERROR: " + ((LuaScriptException)$VB$ResumableLocal_Response$1[0]).Source + " " + ((LuaScriptException)$VB$ResumableLocal_Response$1[0]).Message);
									$VB$ResumableLocal_luaString$0.Append("ERROR: " + ((LuaScriptException)$VB$ResumableLocal_Response$1[0]).Source + " " + ((LuaScriptException)$VB$ResumableLocal_Response$1[0]).Message).Append("\r\n");
								}
							}
							else
							{
								((TextBoxBase)$VB$Me.TextBox1).AppendText("\r\n" + LuaUtility.LuaInterpret($VB$ResumableLocal_Response$1));
								$VB$ResumableLocal_luaString$0.Append(LuaUtility.LuaInterpret($VB$ResumableLocal_Response$1));
							}
						}
					}
					else
					{
						$VB$Me.int_0--;
						if (!$VB$Me.CooldownTimer.Enabled)
						{
							$VB$Me.int_2 = $VB$Me.int_3;
							$VB$Me.CooldownTimer.Enabled = true;
							((Label)$VB$Me.Label_CooldownTimer).Text = ":" + $VB$Me.int_2.ToString("00") + " until next script activation";
						}
						if ($VB$Me.int_0 == 0)
						{
							((Control)$VB$Me.Button_Run).ForeColor = Color.DarkGray;
							$VB$Me.bool_2 = true;
							((Control)$VB$Me.GB_ConsumerRateNotification).Visible = true;
						}
						if ($VB$Me.bool_2)
						{
							$VB$Me.Button_Run.Text = "RUN - (" + Conversions.ToString($VB$Me.int_0) + "/" + Conversions.ToString($VB$Me.int_1) + ")";
						}
					}
				}
				((TextBoxBase)$VB$Me.TextBox1).Select(((TextBoxBase)$VB$Me.TextBox1).TextLength, 0);
				((TextBoxBase)$VB$Me.TextBox1).ScrollToCaret();
				Client.MustRefreshMainForm = true;
				if ($VB$ResumableLocal_luaString$0 != null)
				{
					if ($VB$ResumableLocal_luaString$0.Length > 0)
					{
						string InfoText = "";
						object debugTextObject = $VB$ResumableLocal_luaString$0.ToString();
						LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
					}
					else
					{
						string InfoText = "...";
						object debugTextObject = "";
						LuaUtility.AddToLuaHistoryFile(ref InfoText, ref debugTextObject);
					}
				}
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

		static VB$StateMachine_342_Button_Run_Click()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__342-0
	{
		public string $VB$Local_TextToExecute;

		public ConsoleWindow2 $VB$Me;

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return $VB$Me.luaSandBox_0.RunScript($VB$Local_TextToExecute, RunInteractively: true, "Console");
		}

		static _Closure$__342-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("OpenFileDialog1")]
	private OpenFileDialog openFileDialog_0;

	[AccessedThroughProperty("Button_InsertScript")]
	[CompilerGenerated]
	private DarkUIButton _Button_InsertScript;

	[CompilerGenerated]
	[AccessedThroughProperty("Button_Run")]
	private DarkUIButton _Button_Run;

	[CompilerGenerated]
	[AccessedThroughProperty("openToolStripMenuItem")]
	private DarkToolStripMenuItem _openToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("cutToolStripMenuItem")]
	private DarkToolStripMenuItem _cutToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("copyToolStripMenuItem")]
	private DarkToolStripMenuItem _copyToolStripMenuItem;

	[AccessedThroughProperty("pasteToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _pasteToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("selectLineToolStripMenuItem")]
	private DarkToolStripMenuItem _selectLineToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("selectAllToolStripMenuItem")]
	private DarkToolStripMenuItem _selectAllToolStripMenuItem;

	[AccessedThroughProperty("clearSelectionToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _clearSelectionToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("indentSelectionToolStripMenuItem")]
	private DarkToolStripMenuItem _indentSelectionToolStripMenuItem;

	[AccessedThroughProperty("outdentSelectionToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _outdentSelectionToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("uppercaseSelectionToolStripMenuItem")]
	private DarkToolStripMenuItem _uppercaseSelectionToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("lowercaseSelectionToolStripMenuItem")]
	private DarkToolStripMenuItem _lowercaseSelectionToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("findDialogToolStripMenuItem")]
	private DarkToolStripMenuItem UiwHnzcraDt;

	[AccessedThroughProperty("wordWrapItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _wordWrapItem;

	[CompilerGenerated]
	[AccessedThroughProperty("indentGuidesItem")]
	private DarkToolStripMenuItem _indentGuidesItem;

	[AccessedThroughProperty("hiddenCharactersItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _hiddenCharactersItem;

	[AccessedThroughProperty("zoomInToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _zoomInToolStripMenuItem;

	[AccessedThroughProperty("zoomOutToolStripMenuItem")]
	[CompilerGenerated]
	private DarkToolStripMenuItem _zoomOutToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("zoom100ToolStripMenuItem")]
	private DarkToolStripMenuItem _zoom100ToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("collapseAllToolStripMenuItem")]
	private DarkToolStripMenuItem _collapseAllToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("expandAllToolStripMenuItem")]
	private DarkToolStripMenuItem _expandAllToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_EncloseInQuotes")]
	private DarkToolStripMenuItem _TSMI_EncloseInQuotes;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_EncloseInParentheses")]
	private DarkToolStripMenuItem _TSMI_EncloseInParentheses;

	[CompilerGenerated]
	[AccessedThroughProperty("TSMI_EncloseInBrackets")]
	private DarkToolStripMenuItem _TSMI_EncloseInBrackets;

	[AccessedThroughProperty("CommandLuaDocsToolStripMenuItem")]
	[CompilerGenerated]
	private ToolStripMenuItem _CommandLuaDocsToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("SearchSelectedCommandInTheDocsToolStripMenuItem")]
	private ToolStripMenuItem _SearchSelectedCommandInTheDocsToolStripMenuItem;

	[CompilerGenerated]
	[AccessedThroughProperty("WeaponsReleaseScriptRepositoryToolStripMenuItem")]
	private ToolStripMenuItem _WeaponsReleaseScriptRepositoryToolStripMenuItem;

	[AccessedThroughProperty("CooldownTimer")]
	[CompilerGenerated]
	private Timer timer_0;

	[AccessedThroughProperty("TextArea")]
	[CompilerGenerated]
	private Scintilla scintilla_0;

	private LuaSandBox luaSandBox_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private bool bool_2;

	private bool bool_3;

	[field: AccessedThroughProperty("menuStrip1")]
	private virtual DarkMenuStrip menuStrip1 { get; set; }

	[field: AccessedThroughProperty("toolStripSeparator1")]
	private virtual ToolStripSeparator toolStripSeparator1 { get; set; }

	[field: AccessedThroughProperty("toolStripSeparator2")]
	private virtual ToolStripSeparator toolStripSeparator2 { get; set; }

	[field: AccessedThroughProperty("toolStripSeparator3")]
	private virtual ToolStripSeparator toolStripSeparator3 { get; set; }

	[field: AccessedThroughProperty("toolStripSeparator7")]
	private virtual ToolStripSeparator toolStripSeparator7 { get; set; }

	[field: AccessedThroughProperty("toolStripSeparator4")]
	private virtual ToolStripSeparator toolStripSeparator4 { get; set; }

	[field: AccessedThroughProperty("toolStripSeparator5")]
	private virtual ToolStripSeparator toolStripSeparator5 { get; set; }

	[field: AccessedThroughProperty("TextPanel")]
	private virtual Panel TextPanel { get; set; }

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

	[field: AccessedThroughProperty("TextBox1")]
	internal virtual DarkTextBox TextBox1 { get; set; }

	internal virtual DarkUIButton Button_InsertScript
	{
		[CompilerGenerated]
		get
		{
			return _Button_InsertScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_67;
			DarkUIButton darkUIButton = _Button_InsertScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_InsertScript = value;
			darkUIButton = _Button_InsertScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ComboBox1")]
	internal virtual DarkUIComboBox ComboBox1 { get; set; }

	internal virtual DarkUIButton Button_Run
	{
		[CompilerGenerated]
		get
		{
			return _Button_Run;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_66;
			DarkUIButton darkUIButton = _Button_Run;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_Run = value;
			darkUIButton = _Button_Run;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_EchoInput")]
	internal virtual DarkCheckBox CB_EchoInput { get; set; }

	[field: AccessedThroughProperty("fileToolStripMenuItem")]
	private virtual DarkToolStripMenuItem fileToolStripMenuItem { get; set; }

	private virtual DarkToolStripMenuItem openToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _openToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_47;
			DarkToolStripMenuItem darkToolStripMenuItem = _openToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_openToolStripMenuItem = value;
			darkToolStripMenuItem = _openToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("editToolStripMenuItem")]
	private virtual DarkToolStripMenuItem editToolStripMenuItem { get; set; }

	private virtual DarkToolStripMenuItem cutToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _cutToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_48;
			DarkToolStripMenuItem darkToolStripMenuItem = _cutToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_cutToolStripMenuItem = value;
			darkToolStripMenuItem = _cutToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem copyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _copyToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_49;
			DarkToolStripMenuItem darkToolStripMenuItem = _copyToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_copyToolStripMenuItem = value;
			darkToolStripMenuItem = _copyToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem pasteToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _pasteToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_50;
			DarkToolStripMenuItem darkToolStripMenuItem = _pasteToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_pasteToolStripMenuItem = value;
			darkToolStripMenuItem = _pasteToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem selectLineToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _selectLineToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_51;
			DarkToolStripMenuItem darkToolStripMenuItem = _selectLineToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_selectLineToolStripMenuItem = value;
			darkToolStripMenuItem = _selectLineToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem selectAllToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _selectAllToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_52;
			DarkToolStripMenuItem darkToolStripMenuItem = _selectAllToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_selectAllToolStripMenuItem = value;
			darkToolStripMenuItem = _selectAllToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem clearSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _clearSelectionToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = YjtHnexmicN;
			DarkToolStripMenuItem darkToolStripMenuItem = _clearSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_clearSelectionToolStripMenuItem = value;
			darkToolStripMenuItem = _clearSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem indentSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _indentSelectionToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_53;
			DarkToolStripMenuItem darkToolStripMenuItem = _indentSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_indentSelectionToolStripMenuItem = value;
			darkToolStripMenuItem = _indentSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem outdentSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _outdentSelectionToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_54;
			DarkToolStripMenuItem darkToolStripMenuItem = _outdentSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_outdentSelectionToolStripMenuItem = value;
			darkToolStripMenuItem = _outdentSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem uppercaseSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _uppercaseSelectionToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_55;
			DarkToolStripMenuItem darkToolStripMenuItem = _uppercaseSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_uppercaseSelectionToolStripMenuItem = value;
			darkToolStripMenuItem = _uppercaseSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem lowercaseSelectionToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _lowercaseSelectionToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_56;
			DarkToolStripMenuItem darkToolStripMenuItem = _lowercaseSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_lowercaseSelectionToolStripMenuItem = value;
			darkToolStripMenuItem = _lowercaseSelectionToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("searchToolStripMenuItem")]
	private virtual DarkToolStripMenuItem searchToolStripMenuItem { get; set; }

	[field: AccessedThroughProperty("findToolStripMenuItem")]
	private virtual DarkToolStripMenuItem findToolStripMenuItem { get; set; }

	private virtual DarkToolStripMenuItem findDialogToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return UiwHnzcraDt;
		}
		[CompilerGenerated]
		set
		{
			UiwHnzcraDt = value;
		}
	}

	[field: AccessedThroughProperty("findAndReplaceToolStripMenuItem")]
	private virtual DarkToolStripMenuItem findAndReplaceToolStripMenuItem { get; set; }

	[field: AccessedThroughProperty("goToLineToolStripMenuItem")]
	private virtual DarkToolStripMenuItem goToLineToolStripMenuItem { get; set; }

	[field: AccessedThroughProperty("viewToolStripMenuItem")]
	private virtual DarkToolStripMenuItem viewToolStripMenuItem { get; set; }

	private virtual DarkToolStripMenuItem wordWrapItem
	{
		[CompilerGenerated]
		get
		{
			return _wordWrapItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_57;
			DarkToolStripMenuItem darkToolStripMenuItem = _wordWrapItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_wordWrapItem = value;
			darkToolStripMenuItem = _wordWrapItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem indentGuidesItem
	{
		[CompilerGenerated]
		get
		{
			return _indentGuidesItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_58;
			DarkToolStripMenuItem darkToolStripMenuItem = _indentGuidesItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_indentGuidesItem = value;
			darkToolStripMenuItem = _indentGuidesItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem hiddenCharactersItem
	{
		[CompilerGenerated]
		get
		{
			return _hiddenCharactersItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_59;
			DarkToolStripMenuItem darkToolStripMenuItem = _hiddenCharactersItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_hiddenCharactersItem = value;
			darkToolStripMenuItem = _hiddenCharactersItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem zoomInToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _zoomInToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_60;
			DarkToolStripMenuItem darkToolStripMenuItem = _zoomInToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_zoomInToolStripMenuItem = value;
			darkToolStripMenuItem = _zoomInToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem zoomOutToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _zoomOutToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_61;
			DarkToolStripMenuItem darkToolStripMenuItem = _zoomOutToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_zoomOutToolStripMenuItem = value;
			darkToolStripMenuItem = _zoomOutToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem zoom100ToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _zoom100ToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_62;
			DarkToolStripMenuItem darkToolStripMenuItem = _zoom100ToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_zoom100ToolStripMenuItem = value;
			darkToolStripMenuItem = _zoom100ToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem collapseAllToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _collapseAllToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_63;
			DarkToolStripMenuItem darkToolStripMenuItem = _collapseAllToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_collapseAllToolStripMenuItem = value;
			darkToolStripMenuItem = _collapseAllToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	private virtual DarkToolStripMenuItem expandAllToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _expandAllToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_64;
			DarkToolStripMenuItem darkToolStripMenuItem = _expandAllToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_expandAllToolStripMenuItem = value;
			darkToolStripMenuItem = _expandAllToolStripMenuItem;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("EncloseSelectionInToolStripMenuItem")]
	internal virtual DarkToolStripMenuItem EncloseSelectionInToolStripMenuItem { get; set; }

	internal virtual DarkToolStripMenuItem TSMI_EncloseInQuotes
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_EncloseInQuotes;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_68;
			DarkToolStripMenuItem darkToolStripMenuItem = _TSMI_EncloseInQuotes;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_TSMI_EncloseInQuotes = value;
			darkToolStripMenuItem = _TSMI_EncloseInQuotes;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem TSMI_EncloseInParentheses
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_EncloseInParentheses;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_70;
			DarkToolStripMenuItem darkToolStripMenuItem = _TSMI_EncloseInParentheses;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_TSMI_EncloseInParentheses = value;
			darkToolStripMenuItem = _TSMI_EncloseInParentheses;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	internal virtual DarkToolStripMenuItem TSMI_EncloseInBrackets
	{
		[CompilerGenerated]
		get
		{
			return _TSMI_EncloseInBrackets;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_71;
			DarkToolStripMenuItem darkToolStripMenuItem = _TSMI_EncloseInBrackets;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click -= eventHandler;
			}
			_TSMI_EncloseInBrackets = value;
			darkToolStripMenuItem = _TSMI_EncloseInBrackets;
			if (darkToolStripMenuItem != null)
			{
				((ToolStripItem)darkToolStripMenuItem).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("ExternalLinksToolStripMenuItem")]
	internal virtual ToolStripMenuItem ExternalLinksToolStripMenuItem { get; set; }

	internal virtual ToolStripMenuItem CommandLuaDocsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _CommandLuaDocsToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_72;
			ToolStripMenuItem val = _CommandLuaDocsToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_CommandLuaDocsToolStripMenuItem = value;
			val = _CommandLuaDocsToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem SearchSelectedCommandInTheDocsToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _SearchSelectedCommandInTheDocsToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_75;
			ToolStripMenuItem val = _SearchSelectedCommandInTheDocsToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_SearchSelectedCommandInTheDocsToolStripMenuItem = value;
			val = _SearchSelectedCommandInTheDocsToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem WeaponsReleaseScriptRepositoryToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _WeaponsReleaseScriptRepositoryToolStripMenuItem;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_76;
			ToolStripMenuItem val = _WeaponsReleaseScriptRepositoryToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_WeaponsReleaseScriptRepositoryToolStripMenuItem = value;
			val = _WeaponsReleaseScriptRepositoryToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

	[field: AccessedThroughProperty("SplitContainer2")]
	internal virtual SplitContainer SplitContainer2 { get; set; }

	[field: AccessedThroughProperty("GB_LuaMethods")]
	internal virtual DarkGroupBox GB_LuaMethods { get; set; }

	[field: AccessedThroughProperty("GB_LuaHooks")]
	internal virtual DarkGroupBox GB_LuaHooks { get; set; }

	[field: AccessedThroughProperty("Button_UnhookSelected")]
	internal virtual DarkUIButton Button_UnhookSelected { get; set; }

	[field: AccessedThroughProperty("Label_CurrentHooks")]
	internal virtual DarkLabel Label_CurrentHooks { get; set; }

	[field: AccessedThroughProperty("Button_InsertHook")]
	internal virtual DarkUIButton Button_InsertHook { get; set; }

	[field: AccessedThroughProperty("Combo_LuaHooksSelection")]
	internal virtual DarkUIComboBox Combo_LuaHooksSelection { get; set; }

	[field: AccessedThroughProperty("GB_ConsumerRateNotification")]
	internal virtual DarkGroupBox GB_ConsumerRateNotification { get; set; }

	[field: AccessedThroughProperty("Label_CooldownTimer")]
	internal virtual DarkLabel Label_CooldownTimer { get; set; }

	[field: AccessedThroughProperty("Label_CooldownNotice")]
	internal virtual DarkLabel Label_CooldownNotice { get; set; }

	internal virtual Timer CooldownTimer
	{
		[CompilerGenerated]
		get
		{
			return timer_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_65;
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

	private virtual Scintilla TextArea
	{
		[CompilerGenerated]
		get
		{
			return scintilla_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DragEventHandler val = new DragEventHandler(method_20);
			DragEventHandler val2 = new DragEventHandler(method_21);
			Scintilla scintilla = scintilla_0;
			if (scintilla != null)
			{
				((Control)scintilla).DragEnter -= val;
				((Control)scintilla).DragDrop -= val2;
			}
			scintilla_0 = value;
			scintilla = scintilla_0;
			if (scintilla != null)
			{
				((Control)scintilla).DragEnter += val;
				((Control)scintilla).DragDrop += val2;
			}
		}
	}

	public ConsoleWindow2()
	{
		((Form)this).Load += ConsoleWindow2_Load;
		((Form)this).Closing += ConsoleWindow2_Closing;
		bool_3 = false;
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
		//IL_0063: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_128f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1472: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d8: Expected O, but got Unknown
		//IL_1912: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b2: Expected O, but got Unknown
		//IL_1a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a43: Expected O, but got Unknown
		//IL_1a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_2096: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a0: Expected O, but got Unknown
		//IL_20db: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d1: Expected O, but got Unknown
		//IL_220b: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b8: Expected O, but got Unknown
		icontainer_1 = new Container();
		menuStrip1 = new DarkMenuStrip();
		fileToolStripMenuItem = new DarkToolStripMenuItem();
		openToolStripMenuItem = new DarkToolStripMenuItem();
		editToolStripMenuItem = new DarkToolStripMenuItem();
		cutToolStripMenuItem = new DarkToolStripMenuItem();
		copyToolStripMenuItem = new DarkToolStripMenuItem();
		pasteToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator1 = new ToolStripSeparator();
		selectLineToolStripMenuItem = new DarkToolStripMenuItem();
		selectAllToolStripMenuItem = new DarkToolStripMenuItem();
		clearSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator2 = new ToolStripSeparator();
		indentSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		outdentSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator3 = new ToolStripSeparator();
		uppercaseSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		lowercaseSelectionToolStripMenuItem = new DarkToolStripMenuItem();
		EncloseSelectionInToolStripMenuItem = new DarkToolStripMenuItem();
		TSMI_EncloseInQuotes = new DarkToolStripMenuItem();
		TSMI_EncloseInParentheses = new DarkToolStripMenuItem();
		TSMI_EncloseInBrackets = new DarkToolStripMenuItem();
		searchToolStripMenuItem = new DarkToolStripMenuItem();
		findToolStripMenuItem = new DarkToolStripMenuItem();
		findDialogToolStripMenuItem = new DarkToolStripMenuItem();
		findAndReplaceToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator7 = new ToolStripSeparator();
		goToLineToolStripMenuItem = new DarkToolStripMenuItem();
		viewToolStripMenuItem = new DarkToolStripMenuItem();
		wordWrapItem = new DarkToolStripMenuItem();
		indentGuidesItem = new DarkToolStripMenuItem();
		hiddenCharactersItem = new DarkToolStripMenuItem();
		toolStripSeparator4 = new ToolStripSeparator();
		zoomInToolStripMenuItem = new DarkToolStripMenuItem();
		zoomOutToolStripMenuItem = new DarkToolStripMenuItem();
		zoom100ToolStripMenuItem = new DarkToolStripMenuItem();
		toolStripSeparator5 = new ToolStripSeparator();
		collapseAllToolStripMenuItem = new DarkToolStripMenuItem();
		expandAllToolStripMenuItem = new DarkToolStripMenuItem();
		ExternalLinksToolStripMenuItem = new ToolStripMenuItem();
		CommandLuaDocsToolStripMenuItem = new ToolStripMenuItem();
		SearchSelectedCommandInTheDocsToolStripMenuItem = new ToolStripMenuItem();
		WeaponsReleaseScriptRepositoryToolStripMenuItem = new ToolStripMenuItem();
		TextPanel = new Panel();
		OpenFileDialog1 = new OpenFileDialog();
		TextBox1 = new DarkTextBox();
		Button_InsertScript = new DarkUIButton();
		ComboBox1 = new DarkUIComboBox();
		Button_Run = new DarkUIButton();
		CB_EchoInput = new DarkCheckBox();
		SplitContainer1 = new SplitContainer();
		SplitContainer2 = new SplitContainer();
		GB_ConsumerRateNotification = new DarkGroupBox();
		Label_CooldownNotice = new DarkLabel();
		Label_CooldownTimer = new DarkLabel();
		GB_LuaMethods = new DarkGroupBox();
		GB_LuaHooks = new DarkGroupBox();
		Button_UnhookSelected = new DarkUIButton();
		Label_CurrentHooks = new DarkLabel();
		Button_InsertHook = new DarkUIButton();
		Combo_LuaHooksSelection = new DarkUIComboBox();
		CooldownTimer = new Timer(icontainer_1);
		((Control)menuStrip1).SuspendLayout();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1.Panel2).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((ISupportInitialize)SplitContainer2).BeginInit();
		((Control)SplitContainer2.Panel1).SuspendLayout();
		((Control)SplitContainer2.Panel2).SuspendLayout();
		((Control)SplitContainer2).SuspendLayout();
		((Control)GB_ConsumerRateNotification).SuspendLayout();
		((Control)GB_LuaMethods).SuspendLayout();
		((Control)GB_LuaHooks).SuspendLayout();
		((Control)this).SuspendLayout();
		((ToolStrip)menuStrip1).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStrip)menuStrip1).Font = new Font("Segoe UI", 10.2f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ToolStrip)menuStrip1).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStrip)menuStrip1).Items.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
		{
			(ToolStripItem)fileToolStripMenuItem,
			(ToolStripItem)editToolStripMenuItem,
			(ToolStripItem)searchToolStripMenuItem,
			(ToolStripItem)viewToolStripMenuItem,
			(ToolStripItem)ExternalLinksToolStripMenuItem
		});
		((Control)menuStrip1).Location = new Point(0, 0);
		((Control)menuStrip1).Name = "menuStrip1";
		((Control)menuStrip1).Padding = new Padding(3, 2, 0, 2);
		((Control)menuStrip1).Size = new Size(883, 27);
		((Control)menuStrip1).TabIndex = 3;
		((Control)menuStrip1).Text = "menuStrip1";
		((ToolStripItem)fileToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)fileToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[1] { (ToolStripItem)openToolStripMenuItem });
		((ToolStripItem)fileToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)fileToolStripMenuItem).Name = "fileToolStripMenuItem";
		((ToolStripItem)fileToolStripMenuItem).Size = new Size(41, 23);
		((ToolStripItem)fileToolStripMenuItem).Text = "File";
		((ToolStripItem)openToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)openToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)openToolStripMenuItem).Name = "openToolStripMenuItem";
		((ToolStripItem)openToolStripMenuItem).Size = new Size(121, 24);
		((ToolStripItem)openToolStripMenuItem).Text = "Open...";
		((ToolStripItem)editToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)editToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[14]
		{
			(ToolStripItem)cutToolStripMenuItem,
			(ToolStripItem)copyToolStripMenuItem,
			(ToolStripItem)pasteToolStripMenuItem,
			(ToolStripItem)toolStripSeparator1,
			(ToolStripItem)selectLineToolStripMenuItem,
			(ToolStripItem)selectAllToolStripMenuItem,
			(ToolStripItem)clearSelectionToolStripMenuItem,
			(ToolStripItem)toolStripSeparator2,
			(ToolStripItem)indentSelectionToolStripMenuItem,
			(ToolStripItem)outdentSelectionToolStripMenuItem,
			(ToolStripItem)toolStripSeparator3,
			(ToolStripItem)uppercaseSelectionToolStripMenuItem,
			(ToolStripItem)lowercaseSelectionToolStripMenuItem,
			(ToolStripItem)EncloseSelectionInToolStripMenuItem
		});
		((ToolStripItem)editToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)editToolStripMenuItem).Name = "editToolStripMenuItem";
		((ToolStripItem)editToolStripMenuItem).Size = new Size(44, 23);
		((ToolStripItem)editToolStripMenuItem).Text = "Edit";
		((ToolStripItem)cutToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)cutToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)cutToolStripMenuItem).Name = "cutToolStripMenuItem";
		((ToolStripMenuItem)cutToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+X";
		((ToolStripItem)cutToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)cutToolStripMenuItem).Text = "Cut";
		((ToolStripItem)copyToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)copyToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)copyToolStripMenuItem).Name = "copyToolStripMenuItem";
		((ToolStripMenuItem)copyToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+C";
		((ToolStripItem)copyToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)copyToolStripMenuItem).Text = "Copy";
		((ToolStripItem)pasteToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)pasteToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)pasteToolStripMenuItem).Name = "pasteToolStripMenuItem";
		((ToolStripMenuItem)pasteToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+V";
		((ToolStripItem)pasteToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)pasteToolStripMenuItem).Text = "Paste";
		((ToolStripItem)toolStripSeparator1).Name = "toolStripSeparator1";
		((ToolStripItem)toolStripSeparator1).Size = new Size(201, 6);
		((ToolStripItem)selectLineToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)selectLineToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)selectLineToolStripMenuItem).Name = "selectLineToolStripMenuItem";
		((ToolStripItem)selectLineToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)selectLineToolStripMenuItem).Text = "Select Line";
		((ToolStripItem)selectAllToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)selectAllToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)selectAllToolStripMenuItem).Name = "selectAllToolStripMenuItem";
		((ToolStripMenuItem)selectAllToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+A";
		((ToolStripItem)selectAllToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)selectAllToolStripMenuItem).Text = "Select All";
		((ToolStripItem)clearSelectionToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)clearSelectionToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)clearSelectionToolStripMenuItem).Name = "clearSelectionToolStripMenuItem";
		((ToolStripItem)clearSelectionToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)clearSelectionToolStripMenuItem).Text = "Clear Selection";
		((ToolStripItem)toolStripSeparator2).Name = "toolStripSeparator2";
		((ToolStripItem)toolStripSeparator2).Size = new Size(201, 6);
		((ToolStripItem)indentSelectionToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)indentSelectionToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)indentSelectionToolStripMenuItem).Name = "indentSelectionToolStripMenuItem";
		((ToolStripMenuItem)indentSelectionToolStripMenuItem).ShortcutKeyDisplayString = "Tab";
		((ToolStripItem)indentSelectionToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)indentSelectionToolStripMenuItem).Text = "Indent";
		((ToolStripItem)outdentSelectionToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)outdentSelectionToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)outdentSelectionToolStripMenuItem).Name = "outdentSelectionToolStripMenuItem";
		((ToolStripMenuItem)outdentSelectionToolStripMenuItem).ShortcutKeyDisplayString = "Shift+Tab";
		((ToolStripItem)outdentSelectionToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)outdentSelectionToolStripMenuItem).Text = "Outdent";
		((ToolStripItem)toolStripSeparator3).Name = "toolStripSeparator3";
		((ToolStripItem)toolStripSeparator3).Size = new Size(201, 6);
		((ToolStripItem)uppercaseSelectionToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)uppercaseSelectionToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)uppercaseSelectionToolStripMenuItem).Name = "uppercaseSelectionToolStripMenuItem";
		((ToolStripMenuItem)uppercaseSelectionToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+U";
		((ToolStripItem)uppercaseSelectionToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)uppercaseSelectionToolStripMenuItem).Text = "Uppercase";
		((ToolStripItem)lowercaseSelectionToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)lowercaseSelectionToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)lowercaseSelectionToolStripMenuItem).Name = "lowercaseSelectionToolStripMenuItem";
		((ToolStripMenuItem)lowercaseSelectionToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+L";
		((ToolStripItem)lowercaseSelectionToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)lowercaseSelectionToolStripMenuItem).Text = "Lowercase";
		((ToolStripItem)EncloseSelectionInToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)EncloseSelectionInToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[3]
		{
			(ToolStripItem)TSMI_EncloseInQuotes,
			(ToolStripItem)TSMI_EncloseInParentheses,
			(ToolStripItem)TSMI_EncloseInBrackets
		});
		((ToolStripItem)EncloseSelectionInToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)EncloseSelectionInToolStripMenuItem).Name = "EncloseSelectionInToolStripMenuItem";
		((ToolStripItem)EncloseSelectionInToolStripMenuItem).Size = new Size(204, 24);
		((ToolStripItem)EncloseSelectionInToolStripMenuItem).Text = "Enclose selection in...";
		((ToolStripItem)TSMI_EncloseInQuotes).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_EncloseInQuotes).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_EncloseInQuotes).Name = "TSMI_EncloseInQuotes";
		((ToolStripItem)TSMI_EncloseInQuotes).Size = new Size(195, 24);
		((ToolStripItem)TSMI_EncloseInQuotes).Text = "Quotes  - \"abc\"";
		((ToolStripItem)TSMI_EncloseInParentheses).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_EncloseInParentheses).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_EncloseInParentheses).Name = "TSMI_EncloseInParentheses";
		((ToolStripItem)TSMI_EncloseInParentheses).Size = new Size(195, 24);
		((ToolStripItem)TSMI_EncloseInParentheses).Text = "Parentheses - (abc)";
		((ToolStripItem)TSMI_EncloseInBrackets).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)TSMI_EncloseInBrackets).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)TSMI_EncloseInBrackets).Name = "TSMI_EncloseInBrackets";
		((ToolStripItem)TSMI_EncloseInBrackets).Size = new Size(195, 24);
		((ToolStripItem)TSMI_EncloseInBrackets).Text = "Brackets - {abc}";
		((ToolStripItem)searchToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)searchToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[5]
		{
			(ToolStripItem)findToolStripMenuItem,
			(ToolStripItem)findDialogToolStripMenuItem,
			(ToolStripItem)findAndReplaceToolStripMenuItem,
			(ToolStripItem)toolStripSeparator7,
			(ToolStripItem)goToLineToolStripMenuItem
		});
		((ToolStripMenuItem)searchToolStripMenuItem).Enabled = false;
		((ToolStripItem)searchToolStripMenuItem).ForeColor = Color.FromArgb(153, 153, 153);
		((ToolStripItem)searchToolStripMenuItem).Name = "searchToolStripMenuItem";
		((ToolStripItem)searchToolStripMenuItem).Size = new Size(61, 23);
		((ToolStripItem)searchToolStripMenuItem).Text = "Search";
		((ToolStripItem)findToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)findToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)findToolStripMenuItem).Name = "findToolStripMenuItem";
		((ToolStripMenuItem)findToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+F";
		((ToolStripItem)findToolStripMenuItem).Size = new Size(241, 24);
		((ToolStripItem)findToolStripMenuItem).Text = "Quick Find...";
		((ToolStripItem)findDialogToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)findDialogToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)findDialogToolStripMenuItem).Name = "findDialogToolStripMenuItem";
		((ToolStripMenuItem)findDialogToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+Alt+F";
		((ToolStripItem)findDialogToolStripMenuItem).Size = new Size(241, 24);
		((ToolStripItem)findDialogToolStripMenuItem).Text = "Find...";
		((ToolStripItem)findAndReplaceToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)findAndReplaceToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)findAndReplaceToolStripMenuItem).Name = "findAndReplaceToolStripMenuItem";
		((ToolStripMenuItem)findAndReplaceToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+H";
		((ToolStripItem)findAndReplaceToolStripMenuItem).Size = new Size(241, 24);
		((ToolStripItem)findAndReplaceToolStripMenuItem).Text = "Find and Replace...";
		((ToolStripItem)toolStripSeparator7).Name = "toolStripSeparator7";
		((ToolStripItem)toolStripSeparator7).Size = new Size(238, 6);
		((ToolStripItem)goToLineToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)goToLineToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)goToLineToolStripMenuItem).Name = "goToLineToolStripMenuItem";
		((ToolStripMenuItem)goToLineToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+G";
		((ToolStripItem)goToLineToolStripMenuItem).Size = new Size(241, 24);
		((ToolStripItem)goToLineToolStripMenuItem).Text = "Go To Line...";
		((ToolStripItem)viewToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)viewToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[10]
		{
			(ToolStripItem)wordWrapItem,
			(ToolStripItem)indentGuidesItem,
			(ToolStripItem)hiddenCharactersItem,
			(ToolStripItem)toolStripSeparator4,
			(ToolStripItem)zoomInToolStripMenuItem,
			(ToolStripItem)zoomOutToolStripMenuItem,
			(ToolStripItem)zoom100ToolStripMenuItem,
			(ToolStripItem)toolStripSeparator5,
			(ToolStripItem)collapseAllToolStripMenuItem,
			(ToolStripItem)expandAllToolStripMenuItem
		});
		((ToolStripItem)viewToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)viewToolStripMenuItem).Name = "viewToolStripMenuItem";
		((ToolStripItem)viewToolStripMenuItem).Size = new Size(50, 23);
		((ToolStripItem)viewToolStripMenuItem).Text = "View";
		((ToolStripItem)wordWrapItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)wordWrapItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)wordWrapItem).Name = "wordWrapItem";
		((ToolStripItem)wordWrapItem).Size = new Size(221, 24);
		((ToolStripItem)wordWrapItem).Text = "Word Wrap";
		((ToolStripItem)indentGuidesItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripMenuItem)indentGuidesItem).Checked = true;
		((ToolStripMenuItem)indentGuidesItem).CheckState = (CheckState)1;
		((ToolStripItem)indentGuidesItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)indentGuidesItem).Name = "indentGuidesItem";
		((ToolStripItem)indentGuidesItem).Size = new Size(221, 24);
		((ToolStripItem)indentGuidesItem).Text = "Show Indent Guides";
		((ToolStripItem)hiddenCharactersItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)hiddenCharactersItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)hiddenCharactersItem).Name = "hiddenCharactersItem";
		((ToolStripItem)hiddenCharactersItem).Size = new Size(221, 24);
		((ToolStripItem)hiddenCharactersItem).Text = "Show Whitespace";
		((ToolStripItem)toolStripSeparator4).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)toolStripSeparator4).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)toolStripSeparator4).Margin = new Padding(0, 0, 0, 1);
		((ToolStripItem)toolStripSeparator4).Name = "toolStripSeparator4";
		((ToolStripItem)toolStripSeparator4).Size = new Size(218, 6);
		((ToolStripItem)zoomInToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)zoomInToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)zoomInToolStripMenuItem).Name = "zoomInToolStripMenuItem";
		((ToolStripMenuItem)zoomInToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+Plus";
		((ToolStripItem)zoomInToolStripMenuItem).Size = new Size(221, 24);
		((ToolStripItem)zoomInToolStripMenuItem).Text = "Zoom In";
		((ToolStripItem)zoomOutToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)zoomOutToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)zoomOutToolStripMenuItem).Name = "zoomOutToolStripMenuItem";
		((ToolStripMenuItem)zoomOutToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+Minus";
		((ToolStripItem)zoomOutToolStripMenuItem).Size = new Size(221, 24);
		((ToolStripItem)zoomOutToolStripMenuItem).Text = "Zoom Out";
		((ToolStripItem)zoom100ToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)zoom100ToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)zoom100ToolStripMenuItem).Name = "zoom100ToolStripMenuItem";
		((ToolStripMenuItem)zoom100ToolStripMenuItem).ShortcutKeyDisplayString = "Ctrl+0";
		((ToolStripItem)zoom100ToolStripMenuItem).Size = new Size(221, 24);
		((ToolStripItem)zoom100ToolStripMenuItem).Text = "Zoom 100%";
		((ToolStripItem)toolStripSeparator5).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)toolStripSeparator5).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)toolStripSeparator5).Margin = new Padding(0, 0, 0, 1);
		((ToolStripItem)toolStripSeparator5).Name = "toolStripSeparator5";
		((ToolStripItem)toolStripSeparator5).Size = new Size(218, 6);
		((ToolStripItem)collapseAllToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)collapseAllToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)collapseAllToolStripMenuItem).Name = "collapseAllToolStripMenuItem";
		((ToolStripItem)collapseAllToolStripMenuItem).Size = new Size(221, 24);
		((ToolStripItem)collapseAllToolStripMenuItem).Text = "Collapse All";
		((ToolStripItem)expandAllToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)expandAllToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)expandAllToolStripMenuItem).Name = "expandAllToolStripMenuItem";
		((ToolStripItem)expandAllToolStripMenuItem).Size = new Size(221, 24);
		((ToolStripItem)expandAllToolStripMenuItem).Text = "Expand All";
		((ToolStripItem)ExternalLinksToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripDropDownItem)ExternalLinksToolStripMenuItem).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[3]
		{
			(ToolStripItem)CommandLuaDocsToolStripMenuItem,
			(ToolStripItem)SearchSelectedCommandInTheDocsToolStripMenuItem,
			(ToolStripItem)WeaponsReleaseScriptRepositoryToolStripMenuItem
		});
		((ToolStripItem)ExternalLinksToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)ExternalLinksToolStripMenuItem).Name = "ExternalLinksToolStripMenuItem";
		((ToolStripItem)ExternalLinksToolStripMenuItem).Size = new Size(104, 23);
		((ToolStripItem)ExternalLinksToolStripMenuItem).Text = "External Links";
		((ToolStripItem)CommandLuaDocsToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)CommandLuaDocsToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)CommandLuaDocsToolStripMenuItem).Name = "CommandLuaDocsToolStripMenuItem";
		((ToolStripItem)CommandLuaDocsToolStripMenuItem).Size = new Size(359, 24);
		((ToolStripItem)CommandLuaDocsToolStripMenuItem).Text = "Command Lua Docs";
		((ToolStripItem)SearchSelectedCommandInTheDocsToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)SearchSelectedCommandInTheDocsToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)SearchSelectedCommandInTheDocsToolStripMenuItem).Name = "SearchSelectedCommandInTheDocsToolStripMenuItem";
		((ToolStripItem)SearchSelectedCommandInTheDocsToolStripMenuItem).Size = new Size(359, 24);
		((ToolStripItem)SearchSelectedCommandInTheDocsToolStripMenuItem).Text = "Search Selected Instruction in the Online Docs";
		((ToolStripItem)WeaponsReleaseScriptRepositoryToolStripMenuItem).BackColor = Color.FromArgb(60, 63, 65);
		((ToolStripItem)WeaponsReleaseScriptRepositoryToolStripMenuItem).ForeColor = Color.FromArgb(220, 220, 220);
		((ToolStripItem)WeaponsReleaseScriptRepositoryToolStripMenuItem).Name = "WeaponsReleaseScriptRepositoryToolStripMenuItem";
		((ToolStripItem)WeaponsReleaseScriptRepositoryToolStripMenuItem).Size = new Size(359, 24);
		((ToolStripItem)WeaponsReleaseScriptRepositoryToolStripMenuItem).Text = "Weapons Release Script Repository";
		((Control)TextPanel).BackColor = Color.FromArgb(60, 63, 65);
		TextPanel.BorderStyle = (BorderStyle)2;
		((Control)TextPanel).Dock = (DockStyle)5;
		((Control)TextPanel).Location = new Point(0, 0);
		((Control)TextPanel).Margin = new Padding(3, 4, 3, 4);
		((Control)TextPanel).Name = "TextPanel";
		((Control)TextPanel).Size = new Size(883, 234);
		((Control)TextPanel).TabIndex = 11;
		((FileDialog)OpenFileDialog1).FileName = "OpenFileDialog1";
		((TextBoxBase)TextBox1).BackColor = Color.FromArgb(69, 73, 74);
		((TextBoxBase)TextBox1).BorderStyle = (BorderStyle)1;
		((Control)TextBox1).Dock = (DockStyle)5;
		((TextBoxBase)TextBox1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TextBox1).Location = new Point(0, 0);
		((TextBox)TextBox1).Multiline = true;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.PlaceholderText = "";
		((TextBox)TextBox1).ScrollBars = (ScrollBars)2;
		((Control)TextBox1).Size = new Size(873, 121);
		((Control)TextBox1).TabIndex = 12;
		((ButtonBase)Button_InsertScript).BackColor = Color.Transparent;
		((Control)Button_InsertScript).Font = new Font("Segoe UI", 10f);
		((Control)Button_InsertScript).ForeColor = SystemColors.Control;
		((Control)Button_InsertScript).Location = new Point(7, 45);
		((Control)Button_InsertScript).Name = "Button_InsertScript";
		((Control)Button_InsertScript).Padding = new Padding(5);
		Button_InsertScript.RoundRadius = 0;
		((Control)Button_InsertScript).Size = new Size(359, 23);
		((Control)Button_InsertScript).TabIndex = 14;
		Button_InsertScript.Text = "Insert";
		((Control)ComboBox1).Anchor = (AnchorStyles)12;
		((ComboBox)ComboBox1).BackColor = Color.Transparent;
		((ComboBox)ComboBox1).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox1).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox1).Font = new Font("Lucida Console", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox1).FormattingEnabled = true;
		((Control)ComboBox1).Location = new Point(7, 17);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(359, 19);
		((Control)ComboBox1).TabIndex = 13;
		((Control)Button_Run).Anchor = (AnchorStyles)9;
		((ButtonBase)Button_Run).BackColor = Color.Transparent;
		((Control)Button_Run).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)161);
		((Control)Button_Run).ForeColor = Color.LightGreen;
		((Control)Button_Run).Location = new Point(681, 11);
		((Control)Button_Run).Name = "Button_Run";
		((Control)Button_Run).Padding = new Padding(5);
		Button_Run.RoundRadius = 0;
		((Control)Button_Run).Size = new Size(180, 36);
		((Control)Button_Run).TabIndex = 15;
		Button_Run.Text = "RUN";
		((Control)CB_EchoInput).Anchor = (AnchorStyles)9;
		((ButtonBase)CB_EchoInput).AutoSize = true;
		((CheckBox)CB_EchoInput).Checked = true;
		((CheckBox)CB_EchoInput).CheckState = (CheckState)1;
		((Control)CB_EchoInput).Location = new Point(681, 54);
		((Control)CB_EchoInput).Name = "CB_EchoInput";
		((Control)CB_EchoInput).Size = new Size(189, 19);
		((Control)CB_EchoInput).TabIndex = 16;
		((ButtonBase)CB_EchoInput).Text = "Echo input script on result text ";
		SplitContainer1.Dock = (DockStyle)5;
		((Control)SplitContainer1).Location = new Point(0, 0);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)SplitContainer2);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)TextPanel);
		((Control)SplitContainer1).Size = new Size(883, 472);
		SplitContainer1.SplitterDistance = 234;
		((Control)SplitContainer1).TabIndex = 14;
		((Control)SplitContainer2).Anchor = (AnchorStyles)15;
		((Control)SplitContainer2).Location = new Point(3, 29);
		((Control)SplitContainer2).Margin = new Padding(3, 20, 3, 3);
		((Control)SplitContainer2).Name = "SplitContainer2";
		SplitContainer2.Orientation = (Orientation)0;
		((Control)SplitContainer2.Panel1).Controls.Add((Control)(object)TextBox1);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)GB_ConsumerRateNotification);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)GB_LuaMethods);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)GB_LuaHooks);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)Button_Run);
		((Control)SplitContainer2.Panel2).Controls.Add((Control)(object)CB_EchoInput);
		SplitContainer2.Panel2MinSize = 80;
		((Control)SplitContainer2).Size = new Size(873, 205);
		SplitContainer2.SplitterDistance = 121;
		((Control)SplitContainer2).TabIndex = 0;
		((Control)GB_ConsumerRateNotification).Controls.Add((Control)(object)Label_CooldownNotice);
		((Control)GB_ConsumerRateNotification).Controls.Add((Control)(object)Label_CooldownTimer);
		((Control)GB_ConsumerRateNotification).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_ConsumerRateNotification).Location = new Point(386, 3);
		((Control)GB_ConsumerRateNotification).Name = "GB_ConsumerRateNotification";
		((Control)GB_ConsumerRateNotification).Size = new Size(282, 76);
		((Control)GB_ConsumerRateNotification).TabIndex = 20;
		((GroupBox)GB_ConsumerRateNotification).TabStop = false;
		Label_CooldownNotice.AutoSize = true;
		((Control)Label_CooldownNotice).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_CooldownNotice).Location = new Point(6, 19);
		((Control)Label_CooldownNotice).MaximumSize = new Size(270, 0);
		((Control)Label_CooldownNotice).Name = "Label_CooldownNotice";
		((Control)Label_CooldownNotice).Size = new Size(270, 45);
		((Control)Label_CooldownNotice).TabIndex = 19;
		((Label)Label_CooldownNotice).Text = "Unlimited Lua scripting is a feature limited to Professional Edition. The recreational console will run scripts of any length every thirty seconds.\r\n";
		Label_CooldownTimer.AutoSize = true;
		((Control)Label_CooldownTimer).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_CooldownTimer).Location = new Point(120, 2);
		((Control)Label_CooldownTimer).Name = "Label_CooldownTimer";
		((Control)Label_CooldownTimer).Size = new Size(161, 15);
		((Control)Label_CooldownTimer).TabIndex = 18;
		((Label)Label_CooldownTimer).Text = ":00 until next script activation";
		((Control)GB_LuaMethods).Controls.Add((Control)(object)Button_InsertScript);
		((Control)GB_LuaMethods).Controls.Add((Control)(object)ComboBox1);
		((Control)GB_LuaMethods).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_LuaMethods).Location = new Point(3, 3);
		((Control)GB_LuaMethods).Name = "GB_LuaMethods";
		((Control)GB_LuaMethods).Size = new Size(377, 76);
		((Control)GB_LuaMethods).TabIndex = 19;
		((GroupBox)GB_LuaMethods).TabStop = false;
		((GroupBox)GB_LuaMethods).Text = "Methods";
		((Control)GB_LuaHooks).Controls.Add((Control)(object)Button_UnhookSelected);
		((Control)GB_LuaHooks).Controls.Add((Control)(object)Label_CurrentHooks);
		((Control)GB_LuaHooks).Controls.Add((Control)(object)Button_InsertHook);
		((Control)GB_LuaHooks).Controls.Add((Control)(object)Combo_LuaHooksSelection);
		((Control)GB_LuaHooks).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)GB_LuaHooks).Location = new Point(386, 3);
		((Control)GB_LuaHooks).Name = "GB_LuaHooks";
		((Control)GB_LuaHooks).Size = new Size(282, 76);
		((Control)GB_LuaHooks).TabIndex = 18;
		((GroupBox)GB_LuaHooks).TabStop = false;
		((GroupBox)GB_LuaHooks).Text = "Hooks";
		((ButtonBase)Button_UnhookSelected).BackColor = Color.Transparent;
		((Control)Button_UnhookSelected).Font = new Font("Segoe UI", 10f);
		((Control)Button_UnhookSelected).ForeColor = SystemColors.Control;
		((Control)Button_UnhookSelected).Location = new Point(120, 44);
		((Control)Button_UnhookSelected).Name = "Button_UnhookSelected";
		((Control)Button_UnhookSelected).Padding = new Padding(5);
		Button_UnhookSelected.RoundRadius = 0;
		((Control)Button_UnhookSelected).Size = new Size(156, 23);
		((Control)Button_UnhookSelected).TabIndex = 19;
		Button_UnhookSelected.Text = "Unhook selected";
		Label_CurrentHooks.AutoSize = true;
		((Control)Label_CurrentHooks).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_CurrentHooks).Location = new Point(191, 2);
		((Control)Label_CurrentHooks).Name = "Label_CurrentHooks";
		((Control)Label_CurrentHooks).Size = new Size(81, 15);
		((Control)Label_CurrentHooks).TabIndex = 18;
		((Label)Label_CurrentHooks).Text = "x active hooks";
		((ButtonBase)Button_InsertHook).BackColor = Color.Transparent;
		((Control)Button_InsertHook).Font = new Font("Segoe UI", 10f);
		((Control)Button_InsertHook).ForeColor = SystemColors.Control;
		((Control)Button_InsertHook).Location = new Point(6, 45);
		((Control)Button_InsertHook).Name = "Button_InsertHook";
		((Control)Button_InsertHook).Padding = new Padding(5);
		Button_InsertHook.RoundRadius = 0;
		((Control)Button_InsertHook).Size = new Size(108, 23);
		((Control)Button_InsertHook).TabIndex = 15;
		Button_InsertHook.Text = "Insert";
		((Control)Combo_LuaHooksSelection).Anchor = (AnchorStyles)12;
		((ComboBox)Combo_LuaHooksSelection).BackColor = Color.Transparent;
		((ListControl)Combo_LuaHooksSelection).DisplayMember = "Name";
		((ComboBox)Combo_LuaHooksSelection).DrawMode = (DrawMode)1;
		((ComboBox)Combo_LuaHooksSelection).DropDownStyle = (ComboBoxStyle)2;
		((Control)Combo_LuaHooksSelection).Font = new Font("Lucida Console", 8f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)Combo_LuaHooksSelection).FormattingEnabled = true;
		((Control)Combo_LuaHooksSelection).Location = new Point(6, 19);
		((Control)Combo_LuaHooksSelection).Name = "Combo_LuaHooksSelection";
		((Control)Combo_LuaHooksSelection).Size = new Size(270, 19);
		((Control)Combo_LuaHooksSelection).TabIndex = 17;
		CooldownTimer.Interval = 1000;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(883, 472);
		((Control)this).Controls.Add((Control)(object)menuStrip1);
		((Control)this).Controls.Add((Control)(object)SplitContainer1);
		((Form)this).MinimumSize = new Size(899, 511);
		((Control)this).Name = "ConsoleWindow2";
		((Form)this).Text = "Lua Console v2";
		((Control)menuStrip1).ResumeLayout(false);
		((Control)menuStrip1).PerformLayout();
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).ResumeLayout(false);
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((Control)SplitContainer2.Panel1).ResumeLayout(false);
		((Control)SplitContainer2.Panel1).PerformLayout();
		((Control)SplitContainer2.Panel2).ResumeLayout(false);
		((Control)SplitContainer2.Panel2).PerformLayout();
		((ISupportInitialize)SplitContainer2).EndInit();
		((Control)SplitContainer2).ResumeLayout(false);
		((Control)GB_ConsumerRateNotification).ResumeLayout(false);
		((Control)GB_ConsumerRateNotification).PerformLayout();
		((Control)GB_LuaMethods).ResumeLayout(false);
		((Control)GB_LuaHooks).ResumeLayout(false);
		((Control)GB_LuaHooks).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[AsyncStateMachine(typeof(VB$StateMachine_258_ConsoleWindow2_Load))]
	private void ConsoleWindow2_Load(object sender, EventArgs e)
	{
		VB$StateMachine_258_ConsoleWindow2_Load stateMachine = default(VB$StateMachine_258_ConsoleWindow2_Load);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_2()
	{
		((Form)this).Close();
	}

	private void method_3(object object_0)
	{
		((Control)this).Invoke((Delegate)(VB$AnonymousDelegate_0)([SpecialName] () =>
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(object_0)));
			if (luaSandBox_0.RunInteractive)
			{
				try
				{
					((TextBoxBase)TextBox1).AppendText("\r\n" + stringBuilder.ToString());
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}));
	}

	private void TcfHuNlljb2()
	{
		TextArea.SetSelectionBackColor(use: true, IntToColor(1133980));
	}

	private void method_4()
	{
		HotKeyManager.AddHotKey((Form)(object)this, method_11, (Keys)70, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_18, (Keys)70, ctrl: true, shift: false, alt: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_19, (Keys)82, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_19, (Keys)72, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, Uppercase, (Keys)85, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, Lowercase, (Keys)76, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_44, (Keys)187, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_45, (Keys)189, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_46, (Keys)48, ctrl: true);
		HotKeyManager.AddHotKey((Form)(object)this, method_12, (Keys)27);
		TextArea.ClearCmdKey((Keys)131142);
		TextArea.ClearCmdKey((Keys)131154);
		TextArea.ClearCmdKey((Keys)131144);
		TextArea.ClearCmdKey((Keys)131148);
		TextArea.ClearCmdKey((Keys)131157);
	}

	private void method_5()
	{
		string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text2 = "0123456789";
		string text3 = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
		TextArea.StyleResetDefault();
		TextArea.Styles[32].Font = "Consolas";
		TextArea.Styles[32].Size = 10;
		TextArea.StyleClearAll();
		TextArea.Styles[0].ForeColor = Color.Silver;
		TextArea.Styles[1].ForeColor = Color.LightGreen;
		TextArea.Styles[2].ForeColor = Color.DarkSlateGray;
		TextArea.Styles[4].ForeColor = Color.Olive;
		TextArea.Styles[5].ForeColor = Color.Blue;
		TextArea.Styles[13].ForeColor = Color.BlueViolet;
		TextArea.Styles[14].ForeColor = Color.DarkSlateBlue;
		TextArea.Styles[15].ForeColor = Color.DarkSlateBlue;
		TextArea.Styles[16].ForeColor = Color.DarkGoldenrod;
		TextArea.Styles[6].ForeColor = Color.Red;
		TextArea.Styles[7].ForeColor = Color.Red;
		TextArea.Styles[8].ForeColor = Color.Red;
		TextArea.Styles[12].BackColor = Color.Pink;
		TextArea.Styles[10].ForeColor = Color.Purple;
		TextArea.Styles[9].ForeColor = Color.Maroon;
		TextArea.Lexer = Lexer.Lua;
		TextArea.WordChars = text + text2 + text3;
		TextArea.SetKeywords(0, "and break do else elseif end for function if in local nil not or repeat return then until while false true goto");
		TextArea.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV");
		TextArea.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
		TextArea.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath require package.cpath package.loaded package.loadlib package.path package.preload");
		TextArea.SetProperty("fold", "1");
		TextArea.SetProperty("fold.compact", "1");
		TextArea.Margins[2].Type = MarginType.Symbol;
		TextArea.Margins[2].Mask = 4261412864u;
		TextArea.Margins[2].Sensitive = true;
		TextArea.Margins[2].Width = 20;
		int num = 25;
		do
		{
			TextArea.Markers[num].SetForeColor(SystemColors.ControlLightLight);
			TextArea.Markers[num].SetBackColor(SystemColors.ControlDark);
			num++;
		}
		while (num <= 31);
		TextArea.Markers[30].Symbol = MarkerSymbol.BoxPlus;
		TextArea.Markers[31].Symbol = MarkerSymbol.BoxMinus;
		TextArea.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
		TextArea.Markers[27].Symbol = MarkerSymbol.TCorner;
		TextArea.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
		TextArea.Markers[29].Symbol = MarkerSymbol.VLine;
		TextArea.Markers[28].Symbol = MarkerSymbol.LCorner;
		TextArea.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
		string[] array = LuaSandBox.LuaMethods.OrderBy([SpecialName] (string s) => s).ToArray();
		string text4 = "";
		char c = '(';
		string[] array2 = array;
		foreach (string text5 in array2)
		{
			text4 = text4 + text5.Split(new char[1] { c })[0] + " ";
		}
		TextArea.SetKeywords(4, text4);
	}

	private void method_6(object sender, EventArgs e)
	{
	}

	private void method_7()
	{
		TextArea.Styles[33].BackColor = IntToColor(2760988);
		TextArea.Styles[33].ForeColor = IntToColor(12040119);
		TextArea.Styles[37].ForeColor = IntToColor(12040119);
		TextArea.Styles[37].BackColor = IntToColor(2760988);
		Margin margin = TextArea.Margins[1];
		margin.Width = 30;
		margin.Type = MarginType.Number;
		margin.Sensitive = true;
		margin.Mask = 0u;
		TextArea.MarginClick += method_10;
	}

	private void method_8()
	{
		Margin margin = TextArea.Margins[2];
		margin.Width = 20;
		margin.Sensitive = true;
		margin.Type = MarginType.Symbol;
		margin.Mask = 4u;
		Marker marker = TextArea.Markers[2];
		marker.Symbol = MarkerSymbol.Circle;
		marker.SetBackColor(IntToColor(16711739));
		marker.SetForeColor(IntToColor(0));
		marker.SetAlpha(100);
	}

	private void method_9()
	{
		TextArea.SetFoldMarginColor(use: true, IntToColor(2760988));
		TextArea.SetFoldMarginHighlightColor(use: true, IntToColor(2760988));
		TextArea.SetProperty("fold", "1");
		TextArea.SetProperty("fold.compact", "1");
		TextArea.Margins[3].Type = MarginType.Symbol;
		TextArea.Margins[3].Mask = 4261412864u;
		TextArea.Margins[3].Sensitive = true;
		TextArea.Margins[3].Width = 20;
		int num = 25;
		do
		{
			TextArea.Markers[num].SetForeColor(IntToColor(2760988));
			TextArea.Markers[num].SetBackColor(IntToColor(12040119));
			num++;
		}
		while (num <= 31);
		TextArea.Markers[30].Symbol = MarkerSymbol.CirclePlus;
		TextArea.Markers[31].Symbol = MarkerSymbol.CircleMinus;
		TextArea.Markers[25].Symbol = MarkerSymbol.CirclePlusConnected;
		TextArea.Markers[27].Symbol = MarkerSymbol.TCorner;
		TextArea.Markers[26].Symbol = MarkerSymbol.CircleMinusConnected;
		TextArea.Markers[29].Symbol = MarkerSymbol.VLine;
		TextArea.Markers[28].Symbol = MarkerSymbol.LCorner;
		TextArea.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;
	}

	private void method_10(object sender, MarginClickEventArgs e)
	{
		if (e.Margin == 2)
		{
			Line line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
			if ((long)(line.MarkerGet() & 4) <= 0L)
			{
				line.MarkerAdd(2);
			}
			else
			{
				line.MarkerDelete(2);
			}
		}
	}

	private void method_11()
	{
	}

	private void method_12()
	{
	}

	private void method_13(object sender, EventArgs e)
	{
		method_12();
	}

	private void method_14(object sender, EventArgs e)
	{
	}

	private void method_15(object sender, EventArgs e)
	{
	}

	private void method_16(object sender, EventArgs e)
	{
	}

	private void method_17(object sender, KeyEventArgs e)
	{
	}

	private void method_18()
	{
	}

	private void method_19()
	{
	}

	public void InitDragDropFile()
	{
		((Control)TextArea).AllowDrop = true;
	}

	private void method_20(object sender, DragEventArgs e)
	{
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = (DragDropEffects)0;
		}
		else
		{
			e.Effect = (DragDropEffects)1;
		}
	}

	private void method_21(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
			if (array != null)
			{
				string string_ = array.GetValue(0).ToString();
				method_22(string_);
			}
		}
	}

	private void method_22(string string_0)
	{
		if (FileExistsNative.FileExistsFast(string_0))
		{
			TextArea.Text = File.ReadAllText(string_0);
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			method_22(((FileDialog)OpenFileDialog1).FileName);
		}
	}

	private void method_24(object sender, EventArgs e)
	{
	}

	private void method_25(object sender, EventArgs e)
	{
	}

	private void DtbHuZlcYfl(object sender, EventArgs e)
	{
	}

	private void method_26(object sender, EventArgs e)
	{
		TextArea.Cut();
	}

	private void method_27(object sender, EventArgs e)
	{
		TextArea.Copy();
	}

	private void method_28(object sender, EventArgs e)
	{
		TextArea.Paste();
	}

	private void method_29(object sender, EventArgs e)
	{
		TextArea.SelectAll();
	}

	private void method_30(object sender, EventArgs e)
	{
		Line line = TextArea.Lines[TextArea.CurrentLine];
		TextArea.SetSelection(line.Position + line.Length, line.Position);
	}

	private void method_31(object sender, EventArgs e)
	{
		TextArea.SetEmptySelection(0);
	}

	private void method_32(object sender, EventArgs e)
	{
		Indent();
	}

	private void method_33(object sender, EventArgs e)
	{
		Outdent();
	}

	private void method_34(object sender, EventArgs e)
	{
		Uppercase();
	}

	private void method_35(object sender, EventArgs e)
	{
		Lowercase();
	}

	private void method_36(object sender, EventArgs e)
	{
		((ToolStripMenuItem)wordWrapItem).Checked = !((ToolStripMenuItem)wordWrapItem).Checked;
		TextArea.WrapMode = (((ToolStripMenuItem)wordWrapItem).Checked ? WrapMode.Word : WrapMode.None);
	}

	private void method_37(object sender, EventArgs e)
	{
		((ToolStripMenuItem)indentGuidesItem).Checked = !((ToolStripMenuItem)indentGuidesItem).Checked;
		TextArea.IndentationGuides = (((ToolStripMenuItem)indentGuidesItem).Checked ? IndentView.LookBoth : IndentView.None);
	}

	private void method_38(object sender, EventArgs e)
	{
		((ToolStripMenuItem)hiddenCharactersItem).Checked = !((ToolStripMenuItem)hiddenCharactersItem).Checked;
		TextArea.ViewWhitespace = (((ToolStripMenuItem)hiddenCharactersItem).Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible);
	}

	private void method_39(object sender, EventArgs e)
	{
		method_44();
	}

	private void method_40(object sender, EventArgs e)
	{
		method_45();
	}

	private void DiqHuxxThSM(object sender, EventArgs e)
	{
		method_46();
	}

	private void method_41(object sender, EventArgs e)
	{
		TextArea.FoldAll(FoldAction.Contract);
	}

	private void method_42(object sender, EventArgs e)
	{
		TextArea.FoldAll(FoldAction.Expand);
	}

	private void Lowercase()
	{
		int selectionStart = TextArea.SelectionStart;
		int selectionEnd = TextArea.SelectionEnd;
		TextArea.ReplaceSelection(TextArea.GetTextRange(selectionStart, selectionEnd - selectionStart).ToLower());
		TextArea.SetSelection(selectionStart, selectionEnd);
	}

	private void Uppercase()
	{
		int selectionStart = TextArea.SelectionStart;
		int selectionEnd = TextArea.SelectionEnd;
		TextArea.ReplaceSelection(TextArea.GetTextRange(selectionStart, selectionEnd - selectionStart).ToUpperInvariant());
		TextArea.SetSelection(selectionStart, selectionEnd);
	}

	private void Indent()
	{
		method_43("{TAB}");
	}

	private void Outdent()
	{
		method_43("+{TAB}");
	}

	private void method_43(string string_0)
	{
		HotKeyManager.Enable = false;
		((Control)TextArea).Focus();
		SendKeys.Send(string_0);
		HotKeyManager.Enable = true;
	}

	private void method_44()
	{
		TextArea.ZoomIn();
	}

	private void method_45()
	{
		TextArea.ZoomOut();
	}

	private void method_46()
	{
		TextArea.Zoom = 0;
	}

	private void method_47(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if ((int)((CommonDialog)OpenFileDialog1).ShowDialog() == 1)
		{
			method_22(((FileDialog)OpenFileDialog1).FileName);
		}
	}

	public static Color IntToColor(int rgb)
	{
		return Color.FromArgb(rgb);
	}

	public void InvokeIfNeeded(Action action)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).BeginInvoke((Delegate)action);
		}
		else
		{
			action();
		}
	}

	private void method_48(object sender, EventArgs e)
	{
		TextArea.Cut();
	}

	private void method_49(object sender, EventArgs e)
	{
		TextArea.Copy();
	}

	private void method_50(object sender, EventArgs e)
	{
		TextArea.Paste();
	}

	private void method_51(object sender, EventArgs e)
	{
		Line line = TextArea.Lines[TextArea.CurrentLine];
		TextArea.SetSelection(line.Position + line.Length, line.Position);
	}

	private void method_52(object sender, EventArgs e)
	{
		TextArea.SelectAll();
	}

	private void YjtHnexmicN(object sender, EventArgs e)
	{
		TextArea.SetEmptySelection(0);
	}

	private void method_53(object sender, EventArgs e)
	{
		Indent();
	}

	private void method_54(object sender, EventArgs e)
	{
		Outdent();
	}

	private void method_55(object sender, EventArgs e)
	{
		Uppercase();
	}

	private void method_56(object sender, EventArgs e)
	{
		Lowercase();
	}

	private void method_57(object sender, EventArgs e)
	{
		((ToolStripMenuItem)wordWrapItem).Checked = !((ToolStripMenuItem)wordWrapItem).Checked;
		TextArea.WrapMode = (((ToolStripMenuItem)wordWrapItem).Checked ? WrapMode.Word : WrapMode.None);
	}

	private void method_58(object sender, EventArgs e)
	{
		((ToolStripMenuItem)indentGuidesItem).Checked = !((ToolStripMenuItem)indentGuidesItem).Checked;
		TextArea.IndentationGuides = (((ToolStripMenuItem)indentGuidesItem).Checked ? IndentView.LookBoth : IndentView.None);
	}

	private void method_59(object sender, EventArgs e)
	{
		((ToolStripMenuItem)hiddenCharactersItem).Checked = !((ToolStripMenuItem)hiddenCharactersItem).Checked;
		TextArea.ViewWhitespace = (((ToolStripMenuItem)hiddenCharactersItem).Checked ? WhitespaceMode.VisibleAlways : WhitespaceMode.Invisible);
	}

	private void method_60(object sender, EventArgs e)
	{
		method_44();
	}

	private void method_61(object sender, EventArgs e)
	{
		method_45();
	}

	private void method_62(object sender, EventArgs e)
	{
		method_46();
	}

	private void method_63(object sender, EventArgs e)
	{
		TextArea.FoldAll(FoldAction.Contract);
	}

	private void method_64(object sender, EventArgs e)
	{
		TextArea.FoldAll(FoldAction.Expand);
	}

	private void method_65(object sender, EventArgs e)
	{
		int_2--;
		if (bool_2)
		{
			((Label)Label_CooldownTimer).Text = ":" + int_2.ToString("00") + " until next script activation";
		}
		if (int_2 >= 1)
		{
			return;
		}
		if (int_0 == 0)
		{
			((Control)Button_Run).ForeColor = Color.LightGreen;
		}
		int_0++;
		if (bool_2)
		{
			Button_Run.Text = "RUN - (" + Conversions.ToString(int_0) + "/" + Conversions.ToString(int_1) + ")";
		}
		if (int_0 == int_1)
		{
			CooldownTimer.Stop();
			if (bool_2)
			{
				((Label)Label_CooldownTimer).Text = "";
			}
		}
		else
		{
			int_2 = int_3;
		}
	}

	[AsyncStateMachine(typeof(VB$StateMachine_342_Button_Run_Click))]
	private void method_66(object sender, EventArgs e)
	{
		VB$StateMachine_342_Button_Run_Click stateMachine = default(VB$StateMachine_342_Button_Run_Click);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_67(object sender, EventArgs e)
	{
		TextArea.ReplaceSelection(Conversions.ToString(((ComboBox)ComboBox1).SelectedItem));
	}

	private void method_68(object sender, EventArgs e)
	{
		method_69("\"", "\"");
	}

	private void method_69(string string_0, string string_1)
	{
		int selectionStart = TextArea.SelectionStart;
		int selectionEnd = TextArea.SelectionEnd;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string_0);
		stringBuilder.Append(TextArea.GetTextRange(selectionStart, selectionEnd - selectionStart));
		stringBuilder.Append(string_1);
		TextArea.ReplaceSelection(stringBuilder.ToString());
	}

	private void method_70(object sender, EventArgs e)
	{
		method_69("(", ")");
	}

	private void method_71(object sender, EventArgs e)
	{
		method_69("{", "}");
	}

	private void ConsoleWindow2_Closing(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		((Control)this).Hide();
	}

	private void method_72(object sender, EventArgs e)
	{
		method_73();
	}

	private void method_73(string string_0 = "")
	{
		Process.Start("https://commandlua.github.io/index2.html" + string_0);
	}

	private void method_74(string string_0 = "")
	{
		Process.Start("https://commandlua.github.io/" + string_0);
	}

	private void method_75(object sender, EventArgs e)
	{
		string text = "";
		if (Operators.CompareString(((ComboBox)ComboBox1).Text, "", true) != 0 && ((ComboBox)ComboBox1).Text.Contains("("))
		{
			text = ((ComboBox)ComboBox1).Text.Substring(0, ((ComboBox)ComboBox1).Text.LastIndexOf("("));
			if (Operators.CompareString(text, "", true) != 0)
			{
				text = "assets/Function_" + text + ".html";
			}
		}
		method_74(text);
	}

	private void method_76(object sender, EventArgs e)
	{
		Process.Start("https://wiki.weaponsrelease.com/index.php/Script_Repository");
	}

	static ConsoleWindow2()
	{
		Class72.smethod_20();
	}
}
