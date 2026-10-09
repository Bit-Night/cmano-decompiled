using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class MessageLogOuterControl : UserControl, IComponentConnector
{
	private bool bool_0;

	public MessageLogControlViewModel VM => (MessageLogControlViewModel)((FrameworkElement)this).DataContext;

	public MessageLogOuterControl()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((UIElement)this).KeyDown += new KeyEventHandler(MessageLogOuterControl_KeyDown);
		InitializeComponent();
	}

	public void MessageLogExpandCollapseButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (VM != null)
		{
			if (!VM.LogCollapsed)
			{
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).MaximumSize = new Size(VM.MainFormLogWidth, 30);
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).MinimumSize = new Size(VM.MainFormLogWidth, 30);
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Location = new Point(((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Location.X, ((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Location.Y + 370);
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Height = 30;
				VM.LogCollapsed = true;
				VM.LogCollapseButtonRotation = 180.0;
			}
			else
			{
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).MaximumSize = new Size(VM.MainFormLogWidth, 400);
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).MinimumSize = new Size(VM.MainFormLogWidth, 400);
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Location = new Point(((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Location.X, ((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Location.Y - 370);
				((Control)MyProject.Forms.MainForm.MessageLogControlElementHost1).Height = 400;
				VM.LogCollapsed = false;
				VM.LogCollapseButtonRotation = 0.0;
			}
		}
	}

	private void MessageLogOuterControl_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Invalid comparison between Unknown and I4
		if ((int)e.Key == 56 && (int)((KeyboardEventArgs)e).KeyboardDevice.Modifiers == 2 && (int)((KeyboardEventArgs)e).KeyboardDevice.Modifiers == 4)
		{
			MyProject.Forms.MainForm.ToggleMessageLogInSeparateWindow();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/messagelog/messagelogoutercontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (connectionId == 1)
		{
			((ButtonBase)(Button)target).Click += new RoutedEventHandler(MessageLogExpandCollapseButton_OnClick);
		}
		else
		{
			bool_0 = true;
		}
	}

	static MessageLogOuterControl()
	{
		Class72.smethod_20();
	}
}
