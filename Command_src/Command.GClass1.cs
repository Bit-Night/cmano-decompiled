using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Markup;
using Command.My;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[DoNotPrune]
[DoNotObfuscate]
[DoNotPruneType]
public sealed class GClass1 : Window, IComponentConnector
{
	private bool bool_0;

	public GClass1()
	{
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		new WindowInteropHelper((Window)(object)this).Owner = ((Control)MyProject.Forms.MainForm).Handle;
	}

	private void method_1(object sender, EventArgs e)
	{
		if (!((Control)MyProject.Forms.MessageLogWindow_RawText).Visible && !Client.ShutdownInitiated)
		{
			MyProject.Forms.MainForm.MessageLogControlViewModel.LogCollapsed = true;
			MyProject.Forms.MainForm.ShowEmbeddedMessageLog();
		}
		MyProject.Forms.MainForm.gclass1_0 = null;
		Client.MustRefreshMainForm = true;
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		((Control)MyProject.Forms.MessageLogWindow_RawText).Show();
		((Control)MyProject.Forms.MessageLogWindow_RawText).Left = (int)Math.Round(((Window)this).Left);
		((Control)MyProject.Forms.MessageLogWindow_RawText).Top = (int)Math.Round(((Window)this).Top);
		((Control)MyProject.Forms.MessageLogWindow_RawText).Width = (int)Math.Round(((FrameworkElement)this).Width);
		((Control)MyProject.Forms.MessageLogWindow_RawText).Height = (int)Math.Round(((FrameworkElement)this).Height);
		((Form)MyProject.Forms.MessageLogWindow_RawText).MinimumSize = new Size(200, 200);
		MyProject.Forms.MainForm.CloseMessageLogWindowWPF(ShowEmbeddedLog: false);
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/messagelog/messagelogwpfwindow.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (connectionId == 1)
		{
			((FrameworkElement)(GClass1)target).Loaded += new RoutedEventHandler(method_0);
			((Window)(GClass1)target).Closed += method_1;
		}
		else
		{
			bool_0 = true;
		}
	}

	static GClass1()
	{
		Class72.smethod_20();
	}
}
