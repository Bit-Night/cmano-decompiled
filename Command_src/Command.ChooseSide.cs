using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.WinForms;

namespace Command;

[DesignerGenerated]
public sealed class ChooseSide : DarkSecondaryFormBase
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_38_ComboBox1_SelectionChangeCommitted : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal ChooseSide $VB$Me;

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
					awaiter = $VB$Me.method_5().GetAwaiter();
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

		static VB$StateMachine_38_ComboBox1_SelectionChangeCommitted()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_39_RefreshWebBrowser : IAsyncStateMachine
	{
		public int $State;

		public AsyncTaskMethodBuilder $Builder;

		internal ChooseSide $VB$Me;

		internal Side $VB$ResumableLocal_theSelectedSide$0;

		internal TaskAwaiter<bool> $A0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			int num = $State;
			try
			{
				TaskAwaiter<bool> awaiter;
				if (num == 0)
				{
					num = -1;
					$State = -1;
					awaiter = $A0;
					$A0 = default(TaskAwaiter<bool>);
					goto IL_00f1;
				}
				$VB$ResumableLocal_theSelectedSide$0 = $VB$Me.list_0[((ComboBox)$VB$Me.ComboBox1).SelectedIndex];
				if (!string.IsNullOrEmpty($VB$ResumableLocal_theSelectedSide$0.Briefing))
				{
					awaiter = Helper.smethod_1($VB$Me.WebBrowser1, $VB$ResumableLocal_theSelectedSide$0.Briefing.ToString(), Path.GetDirectoryName($VB$Me.selectedScenarioFile), $VB$Me.theSelectedScenario).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 0;
						$State = 0;
						$A0 = awaiter;
						$Builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00f1;
				}
				Module1.RenderCustomHTML($VB$Me.WebBrowser1, "No briefing currently provided for this side.");
				goto end_IL_0008;
				IL_00f1:
				bool result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<bool>);
				if (!result)
				{
					string text = $VB$ResumableLocal_theSelectedSide$0.Briefing.ToString();
					if (string.IsNullOrEmpty(text))
					{
						Module1.RenderCustomHTML($VB$Me.WebBrowser1, "No briefing currently provided for this side.");
					}
					else
					{
						Module1.RenderCustomHTML($VB$Me.WebBrowser1, text);
					}
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

		static VB$StateMachine_39_RefreshWebBrowser()
		{
			Class72.smethod_20();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct VB$StateMachine_43_ChooseSide_Shown : IAsyncStateMachine
	{
		public int $State;

		public AsyncVoidMethodBuilder $Builder;

		internal object $VB$Local_sender;

		internal EventArgs $VB$Local_e;

		internal ChooseSide $VB$Me;

		internal List<Side>.Enumerator $S0;

		[CompilerGenerated]
		internal void MoveNext()
		{
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			int num = $State;
			try
			{
				if (Client.DPI_scale == 1f)
				{
					((ContainerControl)$VB$Me).AutoScaleMode = (AutoScaleMode)0;
				}
				Side side = null;
				((Control)MyProject.Forms.MainForm).Enabled = false;
				$VB$Me.list_0 = $VB$Me.theSelectedScenario.Sides_ReadOnly.Where([SpecialName] (Side theSide) => !theSide.IsAIOnly).ToList();
				if ($VB$Me.list_0.Count == 0)
				{
					$VB$Me.theSelectedScenario.Sides_ReadOnly[0].IsAIOnly = false;
					$VB$Me.list_0.Add($VB$Me.theSelectedScenario.Sides_ReadOnly[0]);
					if (Client.CurrentGame.GameMode == Game._GameMode.ScenEdit)
					{
						DarkMessageBox.ShowWarning("WARNING - The scenario has no player-selectable sides. Avoiding this by making side: " + $VB$Me.theSelectedScenario.Sides_ReadOnly[0].Name + " player-selectable. Please review the AI-only status of sides!", "");
					}
				}
				if ($VB$Me.list_0.Count == 1)
				{
					side = $VB$Me.list_0[0];
					((Control)$VB$Me.ComboBox1).Enabled = false;
					((ComboBox)$VB$Me.ComboBox1).Items.Add((object)$VB$Me.list_0[0].Name);
					((ComboBox)$VB$Me.ComboBox1).SelectedIndex = 0;
					((Control)$VB$Me.ComboBox1).Size = new Size(556, 21);
					((Control)$VB$Me.lblSideNumber).Visible = false;
				}
				else
				{
					((Control)$VB$Me.ComboBox1).Size = new Size(452, 21);
					((Label)$VB$Me.lblSideNumber).Text = $VB$Me.list_0.Count + " selectable sides";
					((Control)$VB$Me.ComboBox1).Visible = true;
					((ComboBox)$VB$Me.ComboBox1).BeginUpdate();
					try
					{
						$S0 = $VB$Me.list_0.GetEnumerator();
						while ($S0.MoveNext())
						{
							Side current = $S0.Current;
							((ComboBox)$VB$Me.ComboBox1).Items.Add((object)current.Name);
						}
					}
					finally
					{
						if (num < 0)
						{
							((IDisposable)$S0/*cast due to .constrained prefix*/).Dispose();
						}
					}
					((ComboBox)$VB$Me.ComboBox1).EndUpdate();
					if (((ComboBox)$VB$Me.ComboBox1).Items.Count > 0)
					{
						((ComboBox)$VB$Me.ComboBox1).SelectedIndex = 0;
					}
					Side[] sides_ReadOnly = $VB$Me.theSelectedScenario.Sides_ReadOnly;
					foreach (Side side2 in sides_ReadOnly)
					{
						if (Operators.CompareString(side2.Name, ((ComboBox)$VB$Me.ComboBox1).SelectedItem.ToString(), true) == 0)
						{
							side = side2;
							break;
						}
					}
				}
				Side[] sides_ReadOnly2 = $VB$Me.theSelectedScenario.Sides_ReadOnly;
				foreach (Side side3 in sides_ReadOnly2)
				{
					if (Operators.CompareString(side3.Name, ((ComboBox)$VB$Me.ComboBox1).SelectedItem.ToString(), true) == 0)
					{
						side = side3;
						break;
					}
				}
				if (!Information.IsNothing((object)side))
				{
					$VB$Me.method_5();
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

		static VB$StateMachine_43_ChooseSide_Shown()
		{
			Class72.smethod_20();
		}
	}

	private IContainer icontainer_1;

	[AccessedThroughProperty("ComboBox1")]
	[CompilerGenerated]
	private DarkUIComboBox _ComboBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("Button1")]
	private DarkUIButton _Button1;

	[AccessedThroughProperty("Button2")]
	[CompilerGenerated]
	private DarkUIButton _Button2;

	public Scenario theSelectedScenario;

	public string selectedScenarioFile;

	private List<Side> list_0;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual DarkUIComboBox ComboBox1
	{
		[CompilerGenerated]
		get
		{
			return _ComboBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkUIComboBox darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_ComboBox1 = value;
			darkUIComboBox = _ComboBox1;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
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
			EventHandler eventHandler = method_2;
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
			EventHandler eventHandler = method_6;
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

	[field: AccessedThroughProperty("WebBrowser1")]
	internal virtual WebView2 WebBrowser1 { get; set; }

	[field: AccessedThroughProperty("lblSideNumber")]
	internal virtual DarkLabel lblSideNumber { get; set; }

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
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		Label1 = new DarkLabel();
		ComboBox1 = new DarkUIComboBox();
		Label2 = new DarkLabel();
		Button1 = new DarkUIButton();
		Button2 = new DarkUIButton();
		WebBrowser1 = new WebView2();
		lblSideNumber = new DarkLabel();
		((Control)this).SuspendLayout();
		((Control)Label1).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(9, 15);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(98, 13);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Available Sides:";
		((Control)ComboBox1).Anchor = (AnchorStyles)15;
		((ComboBox)ComboBox1).BackColor = Color.Transparent;
		((ComboBox)ComboBox1).DrawMode = (DrawMode)1;
		((ComboBox)ComboBox1).DropDownStyle = (ComboBoxStyle)2;
		((Control)ComboBox1).Font = new Font("Segoe UI", 7f);
		((ListControl)ComboBox1).FormattingEnabled = true;
		((Control)ComboBox1).Location = new Point(117, 10);
		((Control)ComboBox1).Name = "ComboBox1";
		((Control)ComboBox1).Size = new Size(452, 21);
		((Control)ComboBox1).TabIndex = 1;
		((Control)Label2).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(9, 48);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(152, 13);
		((Control)Label2).TabIndex = 2;
		((Label)Label2).Text = "Briefing for selected side:";
		((Control)Button1).Anchor = (AnchorStyles)6;
		((ButtonBase)Button1).BackColor = Color.Transparent;
		((Button)Button1).DialogResult = (DialogResult)0;
		((Control)Button1).Font = new Font("Segoe UI", 10f);
		((Control)Button1).ForeColor = SystemColors.Control;
		((Control)Button1).Location = new Point(12, 433);
		((Control)Button1).Name = "Button1";
		Button1.RoundRadius = 0;
		((Control)Button1).Size = new Size(169, 27);
		((Control)Button1).TabIndex = 4;
		Button1.Text = "Enter scenario";
		((Control)Button2).Anchor = (AnchorStyles)10;
		((ButtonBase)Button2).BackColor = Color.Transparent;
		((Button)Button2).DialogResult = (DialogResult)0;
		((Control)Button2).Font = new Font("Segoe UI", 10f);
		((Control)Button2).ForeColor = SystemColors.Control;
		((Control)Button2).Location = new Point(482, 433);
		((Control)Button2).Name = "Button2";
		Button2.RoundRadius = 0;
		((Control)Button2).Size = new Size(191, 27);
		((Control)Button2).TabIndex = 5;
		Button2.Text = "Cancel (return to main menu)";
		((Control)WebBrowser1).Anchor = (AnchorStyles)15;
		((Control)WebBrowser1).Location = new Point(12, 64);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(661, 363);
		((Control)WebBrowser1).TabIndex = 16;
		((Control)lblSideNumber).Font = new Font("Segoe UI", 8.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblSideNumber).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)lblSideNumber).Location = new Point(575, 15);
		((Control)lblSideNumber).Name = "lblSideNumber";
		((Control)lblSideNumber).Size = new Size(98, 13);
		((Control)lblSideNumber).TabIndex = 17;
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(685, 472);
		((Control)this).Controls.Add((Control)(object)lblSideNumber);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)Button2);
		((Control)this).Controls.Add((Control)(object)Button1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)ComboBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "ChooseSide";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Side selection and briefing";
		((Control)this).ResumeLayout(false);
	}

	public ChooseSide()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosing += new FormClosingEventHandler(ChooseSide_FormClosing);
		((Control)this).KeyDown += new KeyEventHandler(ChooseSide_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(ChooseSide_FormClosed);
		((Form)this).Shown += ChooseSide_Shown;
		((Form)this).Load += ChooseSide_Load;
		list_0 = new List<Side>();
		InitializeComponent_1();
		ApplyStoredPositionSettings = false;
		ApplyStoredSizeSettings = false;
		int width = (int)Math.Round((double)Screen.PrimaryScreen.Bounds.Width * 0.8);
		int num = (int)Math.Round((double)Screen.PrimaryScreen.Bounds.Height * 0.8);
		((Form)this).Size = new Size(width, num - 50);
	}

	private void method_2(object sender, EventArgs e)
	{
		try
		{
			method_3();
			StartGameMenuWindow.HideStartWindow();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			StartGameMenuWindow.ShowStartWindow();
			((Form)this).Close();
			ProjectData.ClearProjectError();
		}
	}

	private void method_3()
	{
		Client.CurrentGame.Pause();
		Button1.Enabled = false;
		Side[] sides_ReadOnly = theSelectedScenario.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (Operators.CompareString(side.Name, ((ComboBox)ComboBox1).SelectedItem.ToString(), true) == 0)
			{
				theSelectedScenario.SetCurrentSide(side);
				break;
			}
		}
		Client.SetCurrentScenario(theSelectedScenario, bool_10: false);
		int mustRefreshMainForm;
		if (Information.IsNothing((object)Client.CurrentSide))
		{
			MyProject.Forms.MainForm.CameraAltitude = 3000000;
			mustRefreshMainForm = 1;
		}
		else
		{
			MyProject.Forms.MainForm.set_MapCenter(MustRender: true, Client.CurrentSide.MapCenter);
			MyProject.Forms.MainForm.CameraAltitude = (int)Math.Round(Client.CurrentSide.CameraAlt);
			mustRefreshMainForm = 1;
		}
		Client.MustRefreshMainForm = (byte)mustRefreshMainForm != 0;
		MyProject.Forms.MainForm.RefreshCaption();
		MyProject.Forms.MainForm.HandleTimeCompressionChanged();
		((Control)MyProject.Forms.MainForm).Enabled = true;
		MyProject.Forms.MainForm.MapRender_Geo();
		if (Client.CurrentScenario.LastSavedInScenEdit && Client.CurrentGame.GameMode == Game._GameMode.SinglePlayer)
		{
			((Window)new RealismDialog2()).Show();
		}
		((Form)this).Close();
	}

	private void ChooseSide_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).Enabled = true;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_38_ComboBox1_SelectionChangeCommitted))]
	private void method_4(object sender, EventArgs e)
	{
		VB$StateMachine_38_ComboBox1_SelectionChangeCommitted stateMachine = default(VB$StateMachine_38_ComboBox1_SelectionChangeCommitted);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	[AsyncStateMachine(typeof(VB$StateMachine_39_RefreshWebBrowser))]
	private Task method_5()
	{
		VB$StateMachine_39_RefreshWebBrowser stateMachine = default(VB$StateMachine_39_RefreshWebBrowser);
		stateMachine.$VB$Me = this;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncTaskMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
		return stateMachine.$Builder.Task;
	}

	private void method_6(object sender, EventArgs e)
	{
		StartGameMenuWindow.ShowStartWindow();
		((Form)this).Close();
	}

	private void ChooseSide_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Control)MyProject.Forms.MainForm).Enabled = true;
			((Form)this).Close();
		}
	}

	private void ChooseSide_FormClosed(object sender, FormClosedEventArgs e)
	{
		((ComboBox)ComboBox1).Items.Clear();
		theSelectedScenario = null;
		list_0 = null;
	}

	[AsyncStateMachine(typeof(VB$StateMachine_43_ChooseSide_Shown))]
	private void ChooseSide_Shown(object sender, EventArgs e)
	{
		VB$StateMachine_43_ChooseSide_Shown stateMachine = default(VB$StateMachine_43_ChooseSide_Shown);
		stateMachine.$VB$Me = this;
		stateMachine.$VB$Local_sender = sender;
		stateMachine.$VB$Local_e = e;
		stateMachine.$State = -1;
		stateMachine.$Builder = AsyncVoidMethodBuilder.Create();
		stateMachine.$Builder.Start(ref stateMachine);
	}

	private void ChooseSide_Load(object sender, EventArgs e)
	{
		WebBrowserHelper.InitialiseWebview2Browser(WebBrowser1);
		((Control)Label1).ForeColor = Color.Gainsboro;
	}

	static ChooseSide()
	{
		Class72.smethod_20();
	}
}
