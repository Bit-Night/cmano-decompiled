using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic.CompilerServices;
using NLua.Exceptions;

namespace Command;

[DesignerGenerated]
public class LuaEditorOperationPlanner : DarkSecondaryFormBase
{
	[DoNotPruneType]
	[DoNotPrune]
	[DoNotObfuscateType]
	private class LuaTemplateItem
	{
		public string string_0;

		public string string_1;

		public string Label => string_1;

		public string Content => string_0;

		public LuaTemplateItem(string string_2, string string_3)
		{
			string_0 = string_2;
			string_1 = string_3;
		}

		static LuaTemplateItem()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_51_ButtonConfirmScript_Click : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal LuaEditorOperationPlanner $VB$Me;

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
					$VB$Me.TheDescription = $VB$Me.TBDescription.Text;
					$VB$Me.TheScript = $VB$Me.TBScriptPanel.Text;
					awaiter = $VB$Me.CheckLuaScriptForErrors().GetAwaiter();
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
					((Form)$VB$Me).DialogResult = (DialogResult)1;
				}
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

		static VB$StateMachine_51_ButtonConfirmScript_Click()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_52_CheckLuaScriptForErrors : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder<bool> $Builder;

		internal LuaEditorOperationPlanner $VB$Me;

		internal TaskAwaiter<object[]> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			bool result2;
			try
			{
				TaskAwaiter<object[]> awaiter;
				if (num != 0)
				{
					$VB$Me.Errors = new List<string>();
					if (string.IsNullOrEmpty($VB$Me.TBDescription.Text))
					{
						$VB$Me.Errors.Add("Your script has no description.");
					}
					if (string.IsNullOrEmpty($VB$Me.TBScriptPanel.Text))
					{
						$VB$Me.Errors.Add("Your script is empty");
						goto IL_0177;
					}
					awaiter = LuaDispatcher.EnqueueAsync((Func<object[]>)new _Closure$__52-0
					{
						$VB$Local_luastr = $VB$Me.TBScriptPanel.Text
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
				object[] array = result;
				if (array != null && array[0] != null)
				{
					if ((object)array[0].GetType() == typeof(LuaScriptException))
					{
						$VB$Me.Errors.Add("ERROR: " + ((LuaScriptException)array[0]).Message);
					}
					else if ((object)array[0].GetType() != typeof(bool))
					{
						$VB$Me.Errors.Add("ERROR: the script in mission start trigger MUST return a boolean");
					}
				}
				goto IL_0177;
				IL_0177:
				$VB$Me.DisplayLuaScriptErrors();
				result2 = $VB$Me.Errors.Count > 0;
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
			$Builder.SetResult(result2);
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

		static VB$StateMachine_52_CheckLuaScriptForErrors()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__52-0
	{
		public string $VB$Local_luastr;

		[SpecialName]
		internal object[] _Lambda$__0()
		{
			return Client.CurrentScenario.Scenario_LuaSandbox.RunScript($VB$Local_luastr, RunInteractively: true);
		}

		static _Closure$__52-0()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("ButtonConfirmScript")]
	private DarkUIButton _ButtonConfirmScript;

	[AccessedThroughProperty("ButtonDeleteScript")]
	[CompilerGenerated]
	private DarkUIButton _ButtonDeleteScript;

	[AccessedThroughProperty("ComboBox_LuaTemplate")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox_LuaTemplate;

	public List<string> Errors;

	public string TheScript;

	public string TheDescription;

	[field: AccessedThroughProperty("RichTextBox1")]
	internal virtual RichTextBox RichTextBox1 { get; set; }

	[field: AccessedThroughProperty("TBScriptPanel")]
	internal virtual RichTextBox TBScriptPanel { get; set; }

	internal virtual DarkUIButton ButtonConfirmScript
	{
		[CompilerGenerated]
		get
		{
			return _ButtonConfirmScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkUIButton darkUIButton = _ButtonConfirmScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonConfirmScript = value;
			darkUIButton = _ButtonConfirmScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TBDescription")]
	internal virtual DarkUITextBox TBDescription { get; set; }

	[field: AccessedThroughProperty("TBError")]
	internal virtual RichTextBox TBError { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel3")]
	internal virtual DarkLabel DarkLabel3 { get; set; }

	internal virtual DarkUIButton ButtonDeleteScript
	{
		[CompilerGenerated]
		get
		{
			return _ButtonDeleteScript;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkUIButton darkUIButton = _ButtonDeleteScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_ButtonDeleteScript = value;
			darkUIButton = _ButtonDeleteScript;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel4")]
	internal virtual DarkLabel DarkLabel4 { get; set; }

	internal virtual DarkUIComboBox ComboBox_LuaTemplate
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox_LuaTemplate;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIComboBox darkUIComboBox = _ComboBox_LuaTemplate;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged -= eventHandler;
			}
			_ComboBox_LuaTemplate = value;
			darkUIComboBox = _ComboBox_LuaTemplate;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectedIndexChanged += eventHandler;
			}
		}
	}

	public LuaEditorOperationPlanner()
	{
		((Form)this).Load += LuaEditorOperationPlanner_Load;
		Errors = new List<string>();
		TheScript = "";
		TheDescription = "";
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_0733: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LuaEditorOperationPlanner));
		RichTextBox1 = new RichTextBox();
		TBScriptPanel = new RichTextBox();
		TBError = new RichTextBox();
		DarkLabel1 = new DarkLabel();
		DarkLabel2 = new DarkLabel();
		DarkLabel3 = new DarkLabel();
		TBDescription = new DarkUITextBox();
		ButtonConfirmScript = new DarkUIButton();
		ButtonDeleteScript = new DarkUIButton();
		DarkLabel4 = new DarkLabel();
		ComboBox_LuaTemplate = new DarkUIComboBox();
		((Control)this).SuspendLayout();
		((TextBoxBase)RichTextBox1).BackColor = Color.FromArgb(40, 40, 40);
		RichTextBox1.ForeColor = SystemColors.Info;
		((Control)RichTextBox1).Location = new Point(12, 28);
		((Control)RichTextBox1).Name = "RichTextBox1";
		((TextBoxBase)RichTextBox1).ReadOnly = true;
		((Control)RichTextBox1).Size = new Size(323, 143);
		((Control)RichTextBox1).TabIndex = 0;
		RichTextBox1.Text = componentResourceManager.GetString("RichTextBox1.Text");
		((Control)TBScriptPanel).Anchor = (AnchorStyles)15;
		((TextBoxBase)TBScriptPanel).BackColor = Color.FromArgb(80, 83, 85);
		TBScriptPanel.ForeColor = SystemColors.Menu;
		((Control)TBScriptPanel).Location = new Point(12, 201);
		((Control)TBScriptPanel).Name = "TBScriptPanel";
		((Control)TBScriptPanel).Size = new Size(629, 258);
		((Control)TBScriptPanel).TabIndex = 1;
		TBScriptPanel.Text = "";
		((Control)TBError).Anchor = (AnchorStyles)13;
		((TextBoxBase)TBError).BackColor = Color.FromArgb(40, 40, 40);
		TBError.ForeColor = Color.FromArgb(255, 128, 128);
		((Control)TBError).Location = new Point(341, 28);
		((Control)TBError).Name = "TBError";
		((TextBoxBase)TBError).ReadOnly = true;
		((Control)TBError).Size = new Size(300, 167);
		((Control)TBError).TabIndex = 41;
		TBError.Text = "";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(12, 9);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(72, 13);
		((Control)DarkLabel1).TabIndex = 42;
		((Label)DarkLabel1).Text = "GUIDELINES";
		((Control)DarkLabel2).Anchor = (AnchorStyles)13;
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(338, 9);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(53, 13);
		((Control)DarkLabel2).TabIndex = 43;
		((Label)DarkLabel2).Text = "ERRORS";
		((Control)DarkLabel3).Anchor = (AnchorStyles)6;
		DarkLabel3.AutoSize = true;
		((Control)DarkLabel3).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel3).Location = new Point(12, 469);
		((Control)DarkLabel3).Name = "DarkLabel3";
		((Control)DarkLabel3).Size = new Size(66, 13);
		((Control)DarkLabel3).TabIndex = 44;
		((Label)DarkLabel3).Text = "Description :";
		((Control)TBDescription).Anchor = (AnchorStyles)6;
		TBDescription.AutoCompleteCustomSource = null;
		TBDescription.AutoCompleteMode = (AutoCompleteMode)0;
		TBDescription.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TBDescription).BackColor = Color.Transparent;
		((Control)TBDescription).ForeColor = Color.FromArgb(189, 189, 189);
		TBDescription.Image = null;
		TBDescription.Lines = null;
		((Control)TBDescription).Location = new Point(84, 465);
		TBDescription.MaxLength = 25;
		TBDescription.Multiline = false;
		((Control)TBDescription).Name = "TBDescription";
		TBDescription.ReadOnly = false;
		TBDescription.ScrollBars = (ScrollBars)0;
		TBDescription.SelectionStart = 0;
		((Control)TBDescription).Size = new Size(267, 24);
		((Control)TBDescription).TabIndex = 40;
		TBDescription.TextAlign = (HorizontalAlignment)0;
		TBDescription.UseSystemPasswordChar = false;
		TBDescription.WatermarkText = "Enter a short description of your script (25 char MAX)";
		((Control)ButtonConfirmScript).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonConfirmScript).BackColor = Color.Transparent;
		((Button)ButtonConfirmScript).DialogResult = (DialogResult)0;
		((Control)ButtonConfirmScript).ForeColor = SystemColors.Control;
		((Control)ButtonConfirmScript).Location = new Point(520, 465);
		((Control)ButtonConfirmScript).Name = "ButtonConfirmScript";
		ButtonConfirmScript.RoundRadius = 0;
		((Control)ButtonConfirmScript).Size = new Size(120, 24);
		((Control)ButtonConfirmScript).TabIndex = 39;
		ButtonConfirmScript.Text = "Confirm Script";
		((Control)ButtonDeleteScript).Anchor = (AnchorStyles)10;
		((ButtonBase)ButtonDeleteScript).BackColor = Color.Transparent;
		((Button)ButtonDeleteScript).DialogResult = (DialogResult)0;
		((Control)ButtonDeleteScript).ForeColor = SystemColors.Control;
		((Control)ButtonDeleteScript).Location = new Point(394, 465);
		((Control)ButtonDeleteScript).Name = "ButtonDeleteScript";
		ButtonDeleteScript.RoundRadius = 0;
		((Control)ButtonDeleteScript).Size = new Size(120, 24);
		((Control)ButtonDeleteScript).TabIndex = 45;
		ButtonDeleteScript.Text = "Delete Script";
		DarkLabel4.AutoSize = true;
		((Control)DarkLabel4).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel4).Location = new Point(12, 180);
		((Control)DarkLabel4).Name = "DarkLabel4";
		((Control)DarkLabel4).Size = new Size(65, 13);
		((Control)DarkLabel4).TabIndex = 46;
		((Label)DarkLabel4).Text = "Templates : ";
		((ComboBox)ComboBox_LuaTemplate).BackColor = Color.Transparent;
		((ComboBox)ComboBox_LuaTemplate).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox_LuaTemplate).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox_LuaTemplate).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)ComboBox_LuaTemplate).FormattingEnabled = true;
		((Control)ComboBox_LuaTemplate).Location = new Point(83, 176);
		((Control)ComboBox_LuaTemplate).Name = "ComboBox_LuaTemplate";
		((Control)ComboBox_LuaTemplate).Size = new Size(251, 21);
		((Control)ComboBox_LuaTemplate).TabIndex = 47;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(653, 498);
		((Control)this).Controls.Add((Control)(object)ComboBox_LuaTemplate);
		((Control)this).Controls.Add((Control)(object)DarkLabel4);
		((Control)this).Controls.Add((Control)(object)ButtonDeleteScript);
		((Control)this).Controls.Add((Control)(object)DarkLabel3);
		((Control)this).Controls.Add((Control)(object)DarkLabel2);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)TBError);
		((Control)this).Controls.Add((Control)(object)TBDescription);
		((Control)this).Controls.Add((Control)(object)ButtonConfirmScript);
		((Control)this).Controls.Add((Control)(object)TBScriptPanel);
		((Control)this).Controls.Add((Control)(object)RichTextBox1);
		((Form)this).MinimumSize = new Size(560, 400);
		((Control)this).Name = "LuaEditorOperationPlanner";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "Lua editor";
		((Form)this).TopMost = true;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	[AsyncStateMachine(typeof(VB$StateMachine_51_ButtonConfirmScript_Click))]
	private void method_2(object sender, EventArgs e)
	{
		VB$StateMachine_51_ButtonConfirmScript_Click stateMachine = default(VB$StateMachine_51_ButtonConfirmScript_Click);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_52_CheckLuaScriptForErrors))]
	public Task<bool> CheckLuaScriptForErrors()
	{
		VB$StateMachine_52_CheckLuaScriptForErrors stateMachine = default(VB$StateMachine_52_CheckLuaScriptForErrors);
		stateMachine.$VB$Me = this;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder<bool>.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	public void DisplayLuaScriptErrors()
	{
		TBError.Text = "";
		foreach (string error in Errors)
		{
			RichTextBox tBError;
			(tBError = TBError).Text = tBError.Text + error;
			((TextBoxBase)TBError).AppendText(Environment.NewLine);
		}
	}

	private void LuaEditorOperationPlanner_Load(object sender, EventArgs e)
	{
		TBDescription.Text = TheDescription;
		TBScriptPanel.Text = TheScript;
		((ListControl)ComboBox_LuaTemplate).ValueMember = "Content";
		((ListControl)ComboBox_LuaTemplate).DisplayMember = "Label";
		List<LuaTemplateItem> list = new List<LuaTemplateItem>();
		list.Add(new LuaTemplateItem("", "None"));
		list.Add(new LuaTemplateItem("--TEXT BETWEEN # SHOULD BE REPLACED WITH PROPER VALUES " + Environment.NewLine + "    return(ScenEdit_GetMission('#SIDE NAME OR ID#', '#MISSION NAME OR ID#').cargomission.IsFulfilled)", "Cargo Mission Fulfilled"));
		list.Add(new LuaTemplateItem("--TEXT BETWEEN # SHOULD BE REPLACED WITH PROPER VALUES " + Environment.NewLine + "local Unit = ScenEdit_GetUnit({ guid= '#UNIT'S GUID#'})" + Environment.NewLine + "-- or use :  local Unit = ScenEdit_GetUnit({ side='#UNIT'S SIDE#', unitname='#UNIT'S NAME#'})" + Environment.NewLine + "return (Unit == nil or Unit.IsDestroyed)", "Unit(s) destroyed"));
		list.Add(new LuaTemplateItem("--TEXT BETWEEN # SHOULD BE REPLACED WITH PROPER VALUES " + Environment.NewLine + "return ScenEdit_IsUnitInZone('#UNIT NAME OR GUID#','#ZONE NAME OR GUID#','#SIDE NAME OR GUID#')", "Unit in Zone"));
		((ComboBox)ComboBox_LuaTemplate).Items.Clear();
		((ComboBox)ComboBox_LuaTemplate).BeginUpdate();
		foreach (LuaTemplateItem item in list)
		{
			((ComboBox)ComboBox_LuaTemplate).Items.Add((object)item);
		}
		((ComboBox)ComboBox_LuaTemplate).EndUpdate();
		((ComboBox)ComboBox_LuaTemplate).SelectedIndexChanged -= method_4;
		((ComboBox)ComboBox_LuaTemplate).SelectedIndex = 0;
		((ComboBox)ComboBox_LuaTemplate).SelectedIndexChanged += method_4;
	}

	private void method_3(object sender, EventArgs e)
	{
		TheDescription = "";
		TheScript = "";
		((Form)this).DialogResult = (DialogResult)1;
	}

	private void method_4(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		if ((int)DarkMessageBox.ShowInformation("Do you want to replace the current script with a template ?", "Lua Template", DarkDialogButton.YesNo) == 6 || Operators.CompareString(TBScriptPanel.Text, "", true) == 0)
		{
			TBScriptPanel.Text = ((LuaTemplateItem)((ComboBox)ComboBox_LuaTemplate).SelectedItem).Content;
		}
		((Control)TBScriptPanel).Refresh();
	}

	static LuaEditorOperationPlanner()
	{
		Class72.smethod_20();
	}
}
