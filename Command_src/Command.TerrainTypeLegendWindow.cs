using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class TerrainTypeLegendWindow : Window, IComponentConnector
{
	private bool bool_0;

	public TerrainTypeLegendWindow()
	{
		InitializeComponent();
	}

	private void method_0(object sender, MouseButtonEventArgs e)
	{
		((UIElement)this).OnMouseLeftButtonDown(e);
		((Window)this).DragMove();
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		new WindowInteropHelper((Window)(object)this).Owner = ((Control)MyProject.Forms.MainForm).Handle;
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/scenario/terraintypelegendwindow.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		if (connectionId == 1)
		{
			((UIElement)(TerrainTypeLegendWindow)target).MouseLeftButtonDown += new MouseButtonEventHandler(method_0);
			((FrameworkElement)(TerrainTypeLegendWindow)target).Loaded += new RoutedEventHandler(method_1);
		}
		else
		{
			bool_0 = true;
		}
	}

	static TerrainTypeLegendWindow()
	{
		Class72.smethod_20();
	}
}
