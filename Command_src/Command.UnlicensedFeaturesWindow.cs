using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using Command.My;
using Command.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class UnlicensedFeaturesWindow : Window, IComponentConnector
{
	private bool bool_0;

	public UnlicensedFeaturesWindow()
	{
		InitializeComponent();
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		((Window)this).Close();
		((Control)MyProject.Forms.LoadScenario).Show();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/licensing/unlicensedfeatures.xaml", UriKind.Relative);
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
			((ButtonBase)(Button)target).Click += new RoutedEventHandler(method_0);
		}
		else
		{
			bool_0 = true;
		}
	}

	static UnlicensedFeaturesWindow()
	{
		Class72.smethod_20();
	}
}
