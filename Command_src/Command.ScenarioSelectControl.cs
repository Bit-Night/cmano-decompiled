using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DesignerGenerated]
[DoNotPruneType]
[DoNotPrune]
public sealed class ScenarioSelectControl : UserControl, IComponentConnector
{
	private bool bool_0;

	public ScenarioSelectControlViewModel VM => (ScenarioSelectControlViewModel)((FrameworkElement)this).DataContext;

	public ScenarioSelectControl()
	{
		InitializeComponent();
		((FrameworkElement)this).DataContext = new ScenarioSelectControlViewModel();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		VM.Update();
	}

	private void method_1(object sender, SelectionChangedEventArgs e)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(e.AddedItems[0]);
		if (objectValue != null)
		{
			((SteamScenarioViewModel)objectValue).SelectSubroutine();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/scenario/scenarioselectcontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(ScenarioSelectControl)target).Loaded += new RoutedEventHandler(method_0);
			break;
		case 2:
			((Selector)(ListBox)target).SelectionChanged += new SelectionChangedEventHandler(method_1);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static ScenarioSelectControl()
	{
		Class72.smethod_20();
	}
}
