using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using MSDN.Html.Editor;

namespace Command;

[DesignerGenerated]
public sealed class ScenarioTitle : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_40_ScenarioTitle_Load : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal ScenarioTitle $VB$Me;

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
					$VB$Me.bool_2 = Client.CurrentGame.Status == Game._GameStatus.Running;
					if ($VB$Me.bool_2)
					{
						Client.CurrentGame.Pause();
					}
					switch (Client.CurrentUserAction)
					{
					case Client.UserAction.CreatingNewScenario:
						((Form)$VB$Me).Text = "Create new scenario";
						$VB$Me.Button1.Enabled = Operators.CompareString($VB$Me.TextBox1.Text, "", true) != 0;
						((Control)$VB$Me.TextBox1).Enabled = true;
						((Control)$VB$Me.Button1).Visible = true;
						((Control)$VB$Me.Button2).Visible = true;
						((Control)$VB$Me.Button3).Visible = true;
						goto end_IL_0007;
					case Client.UserAction.EditingScenarioTitleDescription:
						if (!Information.IsNothing((object)Client.CurrentScenario.Title))
						{
							$VB$Me.TextBox1.Text = Client.CurrentScenario.Title.ToString();
						}
						if (!Information.IsNothing((object)Client.CurrentScenario.Description))
						{
							$VB$Me.Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
						}
						((Control)$VB$Me.TextBox1).Enabled = true;
						((Control)$VB$Me.Button1).Visible = true;
						((Control)$VB$Me.Button2).Visible = true;
						((Control)$VB$Me.Button3).Visible = true;
						goto end_IL_0007;
					case Client.UserAction.SavingScenario:
						((Form)$VB$Me).Text = "Save scenario";
						if (!Information.IsNothing((object)Client.CurrentScenario.Title))
						{
							$VB$Me.TextBox1.Text = Client.CurrentScenario.Title.ToString();
						}
						if (!Information.IsNothing((object)Client.CurrentScenario.Description))
						{
							$VB$Me.Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
						}
						((Control)$VB$Me.TextBox1).Enabled = true;
						((Control)$VB$Me.Button1).Visible = true;
						((Control)$VB$Me.Button2).Visible = true;
						((Control)$VB$Me.Button3).Visible = true;
						goto end_IL_0007;
					}
					if (!Information.IsNothing((object)Client.CurrentScenario.Title))
					{
						$VB$Me.TextBox1.Text = Client.CurrentScenario.Title.ToString();
					}
					if (!Information.IsNothing((object)Client.CurrentScenario.Description))
					{
						if (string.IsNullOrEmpty(Client.CurrentScenarioFullFilePath))
						{
							$VB$Me.Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
						}
						else
						{
							if (Client.CurrentGame.GameMode != Game._GameMode.ScenEdit)
							{
								awaiter = Helper.smethod_1(null, Client.CurrentScenario.Description.ToString(), Path.GetDirectoryName(Client.CurrentScenarioFullFilePath), null, null, $VB$Me.Editor1).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = 0;
									$State = 0;
									$A0 = awaiter;
									$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									return;
								}
								goto IL_037b;
							}
							$VB$Me.Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
						}
					}
					goto IL_03ab;
				}
				num = -1;
				$State = -1;
				awaiter = $A0;
				$A0 = default(TaskAwaiter<bool>);
				goto IL_037b;
				IL_037b:
				bool result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
				if (!result)
				{
					$VB$Me.Editor1.BodyHtml = Client.CurrentScenario.Description.ToString();
				}
				goto IL_03ab;
				IL_03ab:
				((Form)$VB$Me).Text = "Scenario Description";
				((Control)$VB$Me.TextBox1).Enabled = false;
				((Control)$VB$Me.Button1).Visible = false;
				((Control)$VB$Me.Button2).Visible = false;
				((Control)$VB$Me.Button3).Visible = false;
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

		static VB$StateMachine_40_ScenarioTitle_Load()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox1")]
	private DarkUITextBox _TextBox1;

	[AccessedThroughProperty("Button1")]
	[CompilerGenerated]
	private DarkUIButton _Button1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button2")]
	private DarkUIButton _Button2;

	[CompilerGenerated]
	[AccessedThroughProperty("Button3")]
	private DarkUIButton _Button3;

	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUITextBox TextBox1
	{
		[CompilerGenerated]
		get
		{
			return _TextBox1;
		}
		[CompilerGenerated]
		set
		{
			DarkUITextBox.TextChangedEventHandler value2 = method_2;
			DarkUITextBox darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged -= value2;
			}
			_TextBox1 = value;
			darkUITextBox = _TextBox1;
			if (darkUITextBox != null)
			{
				darkUITextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

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
			EventHandler eventHandler = method_4;
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

	[field: AccessedThroughProperty("Editor1")]
	private virtual HtmlEditorControl Editor1 { get; set; }

	internal virtual DarkUIButton Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkUIButton darkUIButton = _Button3;
			if (darkUIButton != null)
			{
				((Control)darkUIButton).Click -= eventHandler;
			}
			_Button3 = value;
			darkUIButton = _Button3;
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
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public ScenarioTitle()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(ScenarioTitle_FormClosing);
		((Form)this).Load += ScenarioTitle_Load;
		((Control)this).KeyDown += new KeyEventHandler(ScenarioTitle_KeyDown);
		((Form)this).Shown += ScenarioTitle_Shown;
		((Form)this).ResizeEnd += ScenarioTitle_ResizeEnd;
		RTMPEnabled = true;
		InitializeComponent_1();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent_1()
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		Label1 = new DarkLabel();
		TextBox1 = new DarkUITextBox();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		Editor1 = new HtmlEditorControl();
		Button3 = new DarkUIButton();
		((Control)this).SuspendLayout();
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(9, 13);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(30, 13);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Title:";
		((Control)TextBox1).Anchor = (AnchorStyles)13;
		TextBox1.AutoCompleteCustomSource = null;
		TextBox1.AutoCompleteMode = (AutoCompleteMode)0;
		TextBox1.AutoCompleteSource = (AutoCompleteSource)128;
		((Control)TextBox1).BackColor = Color.Transparent;
		TextBox1.Font = new Font("Segoe UI", 10f);
		((Control)TextBox1).ForeColor = Color.FromArgb(189, 189, 189);
		TextBox1.Image = null;
		TextBox1.Lines = null;
		((Control)TextBox1).Location = new Point(49, 10);
		TextBox1.MaxLength = 32767;
		TextBox1.Multiline = false;
		((Control)TextBox1).Name = "TextBox1";
		TextBox1.ReadOnly = false;
		TextBox1.ScrollBars = (ScrollBars)0;
		TextBox1.SelectionStart = 0;
		((Control)TextBox1).Size = new Size(601, 20);
		((Control)TextBox1).TabIndex = 1;
		TextBox1.TextAlign = (HorizontalAlignment)0;
		TextBox1.UseSystemPasswordChar = false;
		TextBox1.WatermarkText = "";
		TextBox1.WordWrap = false;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(9, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(78, 22);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = "Description:";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(12, 458);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(5);
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(75, 23);
		((Control)Button1).TabIndex = 4;
		Button1.Text = "OK";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(575, 458);
		((Control)Button2).Name = "Button2";
		((Control)Button2).Padding = new Padding(5);
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(75, 23);
		((Control)Button2).TabIndex = 5;
		Button2.Text = "Cancel";
		((Control)Editor1).Anchor = (AnchorStyles)15;
		Editor1.BackColor = Color.FromArgb(69, 73, 74);
		Editor1.BodyBackColor = Color.FromArgb(43, 43, 43);
		Editor1.BodyFont = new HtmlFontProperty("Segoe UI", HtmlFontSize.Medium, bold: false, italic: false, underline: false, strikeout: false, subscript: false, superscript: false);
		Editor1.BodyForeColor = Color.FromArgb(220, 220, 220);
		((Control)Editor1).Enabled = false;
		((Control)Editor1).ForeColor = Color.FromArgb(220, 220, 220);
		Editor1.InnerText = null;
		((Control)Editor1).Location = new Point(12, 65);
		((Control)Editor1).Name = "Editor1";
		((Control)Editor1).Size = new Size(638, 387);
		((Control)Editor1).TabIndex = 27;
		Editor1.ToolbarDock = (DockStyle)1;
		((Control)Button3).Anchor = (AnchorStyles)9;
		((ButtonBase)Button3).BackColor = Color.Transparent;
		((Control)Button3).Font = new Font("Segoe UI", 10f);
		((Control)Button3).ForeColor = SystemColors.Control;
		((Control)Button3).Location = new Point(550, 36);
		((Control)Button3).Name = "Button3";
		((Control)Button3).Padding = new Padding(5);
		Button3.RoundRadius = 0;
		((Control)Button3).Size = new Size(100, 23);
		((Control)Button3).TabIndex = 28;
		Button3.Text = "Edit HTML";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(662, 485);
		((Control)this).Controls.Add((Control)(object)Button3);
		((Control)this).Controls.Add((Control)(object)Editor1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)TextBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).KeyPreview = true;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ScenarioTitle";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Create a new scenario";
		((Control)this).ResumeLayout(false);
	}

	private void method_2(object object_0)
	{
		if (Client.CurrentUserAction == Client.UserAction.CreatingNewScenario)
		{
			Button1.Enabled = Operators.CompareString(TextBox1.Text, "", true) != 0;
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Invalid comparison between Unknown and I4
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Invalid comparison between Unknown and I4
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		string text = Module1.ConvertScenTitleToFileName(TextBox1.Text);
		if (Operators.CompareString(text, "", true) == 0)
		{
			DarkMessageBox.ShowError("Please use valid filename characters for the scenario name", "");
			return;
		}
		switch (Client.CurrentUserAction)
		{
		case Client.UserAction.PackingScenarioForDistribution:
			Client.CurrentScenario.Title = TextBox1.Text;
			Client.CurrentScenario.FileName = text;
			Client.CurrentScenario.Description = Editor1.BodyHtml;
			((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName = text;
			((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).AddExtension = true;
			((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).Filter = "Packaged scenario file (*.zip)|*.zip";
			if (!string.IsNullOrEmpty(((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory))
			{
				if (!Path.GetFullPath(((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory).StartsWith(GameGeneral.ScenariosRootPath))
				{
					((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory = GameGeneral.ScenariosRootPath;
				}
			}
			else
			{
				((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			if ((int)((CommonDialog)MyProject.Forms.MainForm.SaveScenarioDialog).ShowDialog() == 1)
			{
				AttachmentRepoManager.PackageScenarioForDistribution(Client.CurrentScenario, Client.CurrentSide, ((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName);
				((Control)MyProject.Forms.MainForm).Enabled = true;
				((Form)this).Close();
			}
			else
			{
				DarkMessageBox.ShowError(((Enum)((CommonDialog)MyProject.Forms.MainForm.SaveScenarioDialog).ShowDialog()/*cast due to .constrained prefix*/).ToString(), "");
			}
			Client.SaveScenarioPath = ((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName;
			break;
		case Client.UserAction.SavingScenario:
			Client.CurrentScenario.Title = TextBox1.Text;
			Client.CurrentScenario.FileName = text;
			Client.CurrentScenario.Description = Editor1.BodyHtml;
			((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName = text;
			((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).AddExtension = true;
			if (!GameGeneral.PE_SaveAsXML)
			{
				if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
				{
					((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).Filter = "Command scenario file (*.scen)|*.scen|Command saved game (*.save)|*.save|All Files (*.*)|*.*";
				}
				else
				{
					((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).Filter = "Command saved game (*.save)|*.save|Command scenario file (*.scen)|*.scen|All Files (*.*)|*.*";
				}
			}
			else
			{
				((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).Filter = "Command scenario file as XML (*.xml)|*.xml";
			}
			if (string.IsNullOrEmpty(((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory))
			{
				((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			else if (!Path.GetFullPath(((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory).StartsWith(GameGeneral.ScenariosRootPath))
			{
				((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).InitialDirectory = GameGeneral.ScenariosRootPath;
			}
			if ((int)((CommonDialog)MyProject.Forms.MainForm.SaveScenarioDialog).ShowDialog() == 1)
			{
				Client.SaveCurrentScenario(SBR: true);
				Client.AddFileNameToRecentList(((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName);
				((Control)MyProject.Forms.MainForm).Enabled = true;
				((Form)this).Close();
			}
			else
			{
				DarkMessageBox.ShowError(((Enum)((CommonDialog)MyProject.Forms.MainForm.SaveScenarioDialog).ShowDialog()/*cast due to .constrained prefix*/).ToString(), "");
			}
			Client.SaveScenarioPath = ((FileDialog)MyProject.Forms.MainForm.SaveScenarioDialog).FileName;
			Client.CurrentScenario.FileNamePath = Path.GetDirectoryName(Client.SaveScenarioPath);
			break;
		case Client.UserAction.EditingScenarioTitleDescription:
			Client.CurrentScenario.Title = TextBox1.Text;
			Client.CurrentScenario.Description = Editor1.BodyHtml.Replace("<BODY scroll=auto><P>", "").Replace("</P></BODY>", "");
			((Control)MyProject.Forms.MainForm).Enabled = true;
			((Form)this).Close();
			break;
		}
	}

	private void ScenarioTitle_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (bool_2)
		{
			Client.CurrentGame.Run();
		}
		((Control)MyProject.Forms.MainForm).Enabled = true;
		Client.CurrentUserAction = Client.UserAction.None;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	[AsyncStateMachine(typeof(VB$StateMachine_40_ScenarioTitle_Load))]
	private void ScenarioTitle_Load(object sender, EventArgs e)
	{
		VB$StateMachine_40_ScenarioTitle_Load stateMachine = default(VB$StateMachine_40_ScenarioTitle_Load);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void method_4(object sender, EventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
		((Form)this).Close();
	}

	private void ScenarioTitle_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Control)MyProject.Forms.MainForm).Enabled = true;
			((Form)this).Close();
		}
	}

	private void ScenarioTitle_Shown(object sender, EventArgs e)
	{
		if (((Control)this).Height != 510)
		{
			((Control)this).Width = ((Control)this).Width - 1;
			((Control)this).Width = ((Control)this).Width + 1;
		}
	}

	private void ScenarioTitle_ResizeEnd(object sender, EventArgs e)
	{
		((Control)this).Width = ((Control)this).Width - 1;
		((Control)this).Width = ((Control)this).Width + 1;
	}

	private void method_5(object sender, EventArgs e)
	{
		Editor1.HtmlContentsEdit();
	}

	static ScenarioTitle()
	{
		Class72.smethod_20();
	}
}
