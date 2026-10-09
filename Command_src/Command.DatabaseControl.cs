using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
[DesignerGenerated]
public sealed class DatabaseControl : UserControl, IComponentConnector
{
	[AccessedThroughProperty("WebBrowser1")]
	[CompilerGenerated]
	private WebBrowser webBrowser_0;

	private bool bool_0;

	public virtual WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return webBrowser_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			NavigatedEventHandler val = new NavigatedEventHandler(method_0);
			NavigatingCancelEventHandler val2 = new NavigatingCancelEventHandler(method_1);
			WebBrowser val3 = webBrowser_0;
			if (val3 != null)
			{
				val3.Navigated -= val;
				val3.Navigating -= val2;
			}
			webBrowser_0 = value;
			val3 = webBrowser_0;
			if (val3 != null)
			{
				val3.Navigated += val;
				val3.Navigating += val2;
			}
		}
	}

	public DatabaseControl()
	{
		InitializeComponent();
	}

	private void method_0(object sender, NavigationEventArgs e)
	{
	}

	private void method_1(object sender, NavigatingCancelEventArgs e)
	{
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/dbviewer/databasecontrol.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		if (connectionId == 1)
		{
			WebBrowser1 = (WebBrowser)target;
		}
		else
		{
			bool_0 = true;
		}
	}

	static DatabaseControl()
	{
		Class72.smethod_20();
	}
}
