using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class RealtimeRibbonControl : UserControl, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("ContentControl")]
	private ContentControl contentControl_0;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadingLabel")]
	private Label label_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DetachButton")]
	private Button button_0;

	private bool bool_0;

	internal virtual ContentControl ContentControl
	{
		[CompilerGenerated]
		get
		{
			return contentControl_0;
		}
		[CompilerGenerated]
		set
		{
			contentControl_0 = value;
		}
	}

	internal virtual Label LoadingLabel
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

	internal virtual Button DetachButton
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

	public RealtimeRibbonControl()
	{
		InitializeComponent();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/forms/multiplayer/rtmp/realtimeribboncontrol.xaml", UriKind.Relative);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			ContentControl = (ContentControl)target;
			break;
		case 2:
			LoadingLabel = (Label)target;
			break;
		case 3:
			DetachButton = (Button)target;
			break;
		default:
			bool_0 = true;
			break;
		}
	}

	static RealtimeRibbonControl()
	{
		Class72.smethod_20();
	}
}
