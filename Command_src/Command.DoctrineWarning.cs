using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DoctrineWarning : UserControl, IComponentConnector
{
	private readonly Delegate delegate_0;

	private RightColumnWPF rightColumnWPF_0;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_Text")]
	private Label label_0;

	[CompilerGenerated]
	[AccessedThroughProperty("btnFix")]
	private Button button_0;

	private bool bool_0;

	internal virtual Label TB_Text
	{
		[CompilerGenerated]
		get
		{
			return label_0;
		}
		[CompilerGenerated]
		set
		{
			label_0 = value;
		}
	}

	internal virtual Button btnFix
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			button_0 = value;
		}
	}

	public DoctrineWarning(RightColumnWPF _ParentControl, (string, string, Delegate, string) Warning)
	{
		InitializeComponent();
		((ContentControl)TB_Text).Content = Warning.Item1;
		((FrameworkElement)TB_Text).ToolTip = Warning.Item2;
		delegate_0 = Warning.Item3;
		if ((object)delegate_0 != null)
		{
			((UIElement)btnFix).Visibility = (Visibility)0;
			if (!string.IsNullOrEmpty(Warning.Item4))
			{
				((ContentControl)btnFix).Content = Warning.Item4;
			}
			else
			{
				((ContentControl)btnFix).Content = "Fix";
			}
		}
		else
		{
			((UIElement)btnFix).Visibility = (Visibility)1;
		}
		rightColumnWPF_0 = _ParentControl;
	}

	private void method_0(object sender, RoutedEventArgs e)
	{
		if ((object)delegate_0 != null)
		{
			delegate_0.DynamicInvoke();
		}
		rightColumnWPF_0.RefreshDoctrineWarning();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/doctrine/doctrinewarning.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			TB_Text = (Label)target;
			break;
		case 2:
			btnFix = (Button)target;
			((ButtonBase)btnFix).Click += new RoutedEventHandler(method_0);
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static DoctrineWarning()
	{
		Class72.smethod_20();
	}
}
