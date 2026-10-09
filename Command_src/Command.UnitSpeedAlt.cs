using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Command_Core.SmartAssembly.Attributes;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotObfuscate]
[DesignerGenerated]
[DoNotPruneType]
public sealed class UnitSpeedAlt : UserControl, IComponentConnector
{
	private bool bool_0;

	public UnitSpeedAlt()
	{
		InitializeComponent();
	}

	public void Hide()
	{
		if (((FrameworkElement)this).DataContext != null)
		{
			((UnitSpeedAltViewModel)((FrameworkElement)this).DataContext).Visible = (Visibility)2;
			return;
		}
		((FrameworkElement)this).DataContext = new UnitSpeedAltViewModel(TriggeredBySpeedAltForm: true);
		((UnitSpeedAltViewModel)((FrameworkElement)this).DataContext).Visible = (Visibility)2;
	}

	public void Refresh(bool TriggeredBySpeedAltForm)
	{
		if (((FrameworkElement)this).DataContext == null)
		{
			UnitSpeedAltViewModel unitSpeedAltViewModel = new UnitSpeedAltViewModel(TriggeredBySpeedAltForm);
			unitSpeedAltViewModel.Refresh(TriggeredBySpeedAltForm);
			((FrameworkElement)this).DataContext = unitSpeedAltViewModel;
		}
		else
		{
			UnitSpeedAltViewModel unitSpeedAltViewModel = (UnitSpeedAltViewModel)((FrameworkElement)this).DataContext;
			unitSpeedAltViewModel.Refresh(TriggeredBySpeedAltForm);
		}
		if (!MyProject.Forms.MainForm.RightColumnWPF1.Expander_AltSpeed.IsExpanded)
		{
			MyProject.Forms.MainForm.RightColumnWPF1.Expander_AltSpeed.IsExpanded = true;
			MyProject.Forms.MainForm.RightColumnWPF1.Expander_AltSpeed.IsExpanded = false;
		}
		else
		{
			MyProject.Forms.MainForm.RightColumnWPF1.Expander_AltSpeed.IsExpanded = false;
			MyProject.Forms.MainForm.RightColumnWPF1.Expander_AltSpeed.IsExpanded = true;
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/unitspeedalt.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		bool_0 = true;
	}

	static UnitSpeedAlt()
	{
		Class72.smethod_20();
	}
}
