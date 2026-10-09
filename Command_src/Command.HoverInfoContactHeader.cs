using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
[DesignerGenerated]
public sealed class HoverInfoContactHeader : UserControl, IComponentConnector
{
	private bool KxxziAkfen;

	public HoverInfoContactHeader()
	{
		InitializeComponent();
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!KxxziAkfen)
		{
			KxxziAkfen = true;
			Uri uri = new Uri("/Command;component/forms/hoverinfo/hoverinfocontactheader.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		KxxziAkfen = true;
	}

	static HoverInfoContactHeader()
	{
		Class72.smethod_20();
	}
}
