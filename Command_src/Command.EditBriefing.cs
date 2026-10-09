using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;
using MSDN.Html.Editor;

namespace Command;

[DesignerGenerated]
public sealed class EditBriefing : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_32_EditBriefing_Load : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal EditBriefing $VB$Me;

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
					if (Client.DPI_scale == 1f)
					{
						((ContainerControl)$VB$Me).AutoScaleMode = (AutoScaleMode)0;
					}
					if (!Client.AllowEditModeActions)
					{
						((Form)$VB$Me).Text = "Side Briefing";
						((Control)$VB$Me.Button2).Visible = false;
						((Control)$VB$Me.Button_EditHTML).Visible = false;
					}
					else
					{
						if (Client.Realtime & !Client.RealtimeAC)
						{
							Client.ShowACRequiredWarning();
							((Form)$VB$Me).Close();
						}
						((Form)$VB$Me).Text = "Edit Briefing for side: " + $VB$Me.theSelectedSide.Name;
						((Control)$VB$Me.Button2).Visible = true;
						((Control)$VB$Me.Button_EditHTML).Visible = true;
					}
					if (!string.IsNullOrEmpty($VB$Me.theSelectedSide.Briefing))
					{
						if (string.IsNullOrEmpty(Client.CurrentScenarioFullFilePath))
						{
							$VB$Me.Editor1.BodyHtml = $VB$Me.theSelectedSide.Briefing.ToString();
						}
						else
						{
							if (!Client.AllowEditModeActions)
							{
								awaiter = Helper.smethod_1(null, $VB$Me.theSelectedSide.Briefing.ToString(), Path.GetDirectoryName(Client.CurrentScenarioFullFilePath), null, null, $VB$Me.Editor1).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = 0;
									$State = 0;
									$A0 = awaiter;
									$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									return;
								}
								goto IL_01c5;
							}
							$VB$Me.Editor1.BodyHtml = $VB$Me.theSelectedSide.Briefing.ToString();
						}
					}
					goto IL_01fb;
				}
				num = -1;
				$State = -1;
				awaiter = $A0;
				$A0 = default(TaskAwaiter<bool>);
				goto IL_01c5;
				IL_01fb:
				$VB$Me.Editor1.ToolbarVisible = true;
				goto end_IL_0007;
				IL_01c5:
				bool result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
				if (!result)
				{
					$VB$Me.Editor1.BodyHtml = $VB$Me.theSelectedSide.Briefing.ToString();
				}
				goto IL_01fb;
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

		static VB$StateMachine_32_EditBriefing_Load()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button_EditHTML")]
	[CompilerGenerated]
	private DarkUIButton _Button_EditHTML;

	public Side theSelectedSide;

	private Keys[] keys_0;

	[CompilerGenerated]
	private bool bool_2;

	[field: AccessedThroughProperty("SplitContainer1")]
	internal virtual SplitContainer SplitContainer1 { get; set; }

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
			EventHandler eventHandler = method_3;
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

	[field: AccessedThroughProperty("Editor1")]
	private virtual HtmlEditorControl Editor1 { get; set; }

	internal virtual DarkUIButton Button_EditHTML
	{
		[CompilerGenerated]
		get
		{
			return _Button_EditHTML;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIButton darkUIButton = _Button_EditHTML;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button_EditHTML = value;
			darkUIButton = _Button_EditHTML;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click += eventHandler;
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

	public EditBriefing()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((Form)this).Load += EditBriefing_Load;
		((Form)this).Shown += EditBriefing_Shown;
		((Form)this).ResizeEnd += EditBriefing_ResizeEnd;
		((Form)this).FormClosing += new FormClosingEventHandler(EditBriefing_FormClosing);
		keys_0 = (Keys[])(object)new Keys[1] { (Keys)27 };
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		SplitContainer1 = new SplitContainer();
		Editor1 = new HtmlEditorControl();
		Button_EditHTML = new DarkUIButton();
		Button2 = new DarkUIButton();
		Button1 = new DarkUIButton();
		((ISupportInitialize)SplitContainer1).BeginInit();
		((Control)SplitContainer1.Panel1).SuspendLayout();
		((Control)SplitContainer1.Panel2).SuspendLayout();
		((Control)SplitContainer1).SuspendLayout();
		((Control)this).SuspendLayout();
		SplitContainer1.Dock = (DockStyle)5;
		SplitContainer1.FixedPanel = (FixedPanel)2;
		((Control)SplitContainer1).Location = new Point(0, 0);
		((Control)SplitContainer1).Name = "SplitContainer1";
		SplitContainer1.Orientation = (Orientation)0;
		((Control)SplitContainer1.Panel1).Controls.Add((Control)(object)Editor1);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Button_EditHTML);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Button2);
		((Control)SplitContainer1.Panel2).Controls.Add((Control)(object)Button1);
		((Control)SplitContainer1).Size = new Size(709, 516);
		SplitContainer1.SplitterDistance = 476;
		((Control)SplitContainer1).TabIndex = 0;
		((Control)Editor1).Anchor = (AnchorStyles)15;
		Editor1.BackColor = Color.FromArgb(69, 73, 74);
		Editor1.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor1.BodyFont = new HtmlFontProperty("Segoe UI", HtmlFontSize.Medium, bold: false, italic: false, underline: false, strikeout: false, subscript: false, superscript: false);
		Editor1.BodyForeColor = Color.FromArgb(220, 220, 220);
		((Control)Editor1).Enabled = false;
		((Control)Editor1).ForeColor = Color.FromArgb(220, 220, 220);
		Editor1.InnerText = null;
		((Control)Editor1).Location = new Point(0, 0);
		((Control)Editor1).Name = "Editor1";
		((Control)Editor1).Size = new Size(709, 476);
		((Control)Editor1).TabIndex = 28;
		Editor1.ToolbarDock = (DockStyle)1;
		((Control)Button_EditHTML).Anchor = (AnchorStyles)14;
		((Control)Button_EditHTML).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button_EditHTML).Location = new Point(278, 7);
		((Control)Button_EditHTML).Name = "Button_EditHTML";
		((Control)Button_EditHTML).Padding = new Padding(5);
		Button_EditHTML.RoundRadius = 0;
		((Control)Button_EditHTML).Size = new Size(144, 23);
		((Control)Button_EditHTML).TabIndex = 2;
		Button_EditHTML.Text = "Edit HTML";
		((Control)Button2).Anchor = (AnchorStyles)11;
		((Button)Button2).DialogResult = (DialogResult)2;
		((Control)Button2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button2).Location = new Point(629, 7);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 1;
		Button2.Text = "Cancel";
		((Control)Button1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Button1).Location = new Point(9, 7);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 0;
		Button1.Text = "OK";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).CancelButton = (IButtonControl)(object)Button2;
		((Form)this).ClientSize = new Size(709, 516);
		((Control)this).Controls.Add((Control)(object)SplitContainer1);
		((Form)this).FormBorderStyle = (FormBorderStyle)6;
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EditBriefing";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Briefing";
		((Control)SplitContainer1.Panel1).ResumeLayout(false);
		((Control)SplitContainer1.Panel2).ResumeLayout(false);
		((ISupportInitialize)SplitContainer1).EndInit();
		((Control)SplitContainer1).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Keys[] array = keys_0;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Keys val = array[num];
				if (keyData == val)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		int result;
		if (((Control)this).Visible)
		{
			((Form)this).Close();
			result = 1;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	private void method_2(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	[AsyncStateMachine(typeof(VB$StateMachine_32_EditBriefing_Load))]
	private void EditBriefing_Load(object sender, EventArgs e)
	{
		VB$StateMachine_32_EditBriefing_Load stateMachine = default(VB$StateMachine_32_EditBriefing_Load);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_3(object sender, EventArgs e)
	{
		if (Client.AllowEditModeActions)
		{
			theSelectedSide.Briefing = Editor1.BodyHtml.Replace("<BODY scroll=auto><P>", "").Replace("</P></BODY>", "");
		}
		((Form)this).Close();
	}

	private void EditBriefing_Shown(object sender, EventArgs e)
	{
		if (((Control)this).Height != 510)
		{
			((Control)this).Width = ((Control)this).Width - 1;
			((Control)this).Width = ((Control)this).Width + 1;
		}
	}

	private void EditBriefing_ResizeEnd(object sender, EventArgs e)
	{
		((Control)this).Width = ((Control)this).Width - 1;
		((Control)this).Width = ((Control)this).Width + 1;
	}

	private void EditBriefing_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_4(object sender, EventArgs e)
	{
		Editor1.HtmlContentsEdit();
	}

	static EditBriefing()
	{
		Class72.smethod_20();
	}
}
