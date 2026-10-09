using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using Xceed.Wpf.Toolkit.PropertyGrid;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DesignerGenerated]
[DoNotPrune]
public sealed class HoverInfoOptions : UserControl, IComponentConnector
{
	private bool bool_0;

	public HoverInfoOptions()
	{
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		if (((FrameworkElement)this).DataContext == null)
		{
			((FrameworkElement)this).DataContext = HoverInfoOptionsViewModel.Singleton;
		}
	}

	private void method_1(object sender, PropertyChangedEventArgs e)
	{
		if (((FrameworkElement)this).DataContext != null)
		{
			((HoverInfoOptionsViewModel)((FrameworkElement)this).DataContext).Save();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/hoverinfo/hoverinfooptions.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(HoverInfoOptions)target).Loaded += new RoutedEventHandler(method_0);
			break;
		case 2:
			((PropertyGrid)target).PropertyChanged += method_1;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static HoverInfoOptions()
	{
		Class72.smethod_20();
	}
}
