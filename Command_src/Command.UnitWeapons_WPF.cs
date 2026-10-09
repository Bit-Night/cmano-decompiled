using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class UnitWeapons_WPF : UserControl, IComponentConnector
{
	private bool bool_0;

	public UnitWeapons_WPF()
	{
		InitializeComponent();
	}

	public void Refresh(ActiveUnit theUnit, ref bool theUnitHasWeapons, [Optional][DefaultParameterValue(false)] ref bool thePanelIsExpanded)
	{
		if (((FrameworkElement)this).DataContext == null)
		{
			((FrameworkElement)this).DataContext = new UnitWeaponViewModel(theUnit);
			theUnitHasWeapons = ((UnitWeaponViewModel)((FrameworkElement)this).DataContext).HasWeapons;
			return;
		}
		UnitWeaponViewModel unitWeaponViewModel = (UnitWeaponViewModel)((FrameworkElement)this).DataContext;
		if (theUnit != null && !theUnit.CommStuff.IsConnectedToSideNetwork && !Module1.IsSelectedForIsolatedPOV(theUnit) && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient)
		{
			((FrameworkElement)this).DataContext = new UnitWeaponViewModel(theUnit);
			theUnitHasWeapons = false;
		}
		else if (unitWeaponViewModel.theUnit == theUnit)
		{
			unitWeaponViewModel.Refresh();
			theUnitHasWeapons = unitWeaponViewModel.HasWeapons;
		}
		else if (theUnit != null)
		{
			((FrameworkElement)this).DataContext = new UnitWeaponViewModel(theUnit);
			theUnitHasWeapons = ((UnitWeaponViewModel)((FrameworkElement)this).DataContext).HasWeapons;
			if (theUnitHasWeapons && unitWeaponViewModel.Weapons_Sorted != null && unitWeaponViewModel.Weapons_Sorted.Count < ((UnitWeaponViewModel)((FrameworkElement)this).DataContext).Weapons_Sorted.Count)
			{
				thePanelIsExpanded = true;
			}
			else
			{
				thePanelIsExpanded = false;
			}
		}
		else
		{
			((FrameworkElement)this).DataContext = new UnitWeaponViewModel(theUnit);
			theUnitHasWeapons = false;
		}
	}

	private void method_0(object sender, MouseEventArgs e)
	{
		try
		{
			((UnitWeaponViewModel)((FrameworkElement)this).DataContext).mouseOverPanel = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void method_1(object sender, MouseEventArgs e)
	{
		try
		{
			((UnitWeaponViewModel)((FrameworkElement)this).DataContext).mouseOverPanel = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_0)
		{
			bool_0 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/unitweapons_wpf.xaml", UriKind.Relative);
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
			((UIElement)(UnitWeapons_WPF)target).MouseEnter += new MouseEventHandler(method_0);
			((UIElement)(UnitWeapons_WPF)target).MouseLeave += new MouseEventHandler(method_1);
		}
		else
		{
			bool_0 = true;
		}
	}

	static UnitWeapons_WPF()
	{
		Class72.smethod_20();
	}
}
