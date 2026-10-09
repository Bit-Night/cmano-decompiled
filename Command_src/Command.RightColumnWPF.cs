using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using Command_Core;
using Command.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Odyssey.Controls;

namespace Command;

[DesignerGenerated]
public sealed class RightColumnWPF : UserControl, IComponentConnector
{
	private bool bool_0;

	public bool Refreshing;

	private bool bool_1;

	[CompilerGenerated]
	[AccessedThroughProperty("MyScrollViewer")]
	private ScrollViewer scrollViewer_0;

	[AccessedThroughProperty("MyGrid")]
	[CompilerGenerated]
	private Grid grid_0;

	[AccessedThroughProperty("RowDefinition_UsedSpace")]
	[CompilerGenerated]
	private RowDefinition rowDefinition_0;

	[AccessedThroughProperty("RowDefinition_ExtraSpace")]
	[CompilerGenerated]
	private RowDefinition rowDefinition_1;

	[AccessedThroughProperty("ColumnDefinition_UsedSpace")]
	[CompilerGenerated]
	private ColumnDefinition columnDefinition_0;

	[AccessedThroughProperty("StackPanel_Main")]
	[CompilerGenerated]
	private StackPanel stackPanel_0;

	[AccessedThroughProperty("lblNoUnitSelected")]
	[CompilerGenerated]
	private TextBlock textBlock_0;

	[AccessedThroughProperty("Expander_UnitStatus")]
	[CompilerGenerated]
	private OdcExpander odcExpander_0;

	[CompilerGenerated]
	[AccessedThroughProperty("WPFControl_UnitStatus")]
	private UnitStatus_WPF unitStatus_WPF_0;

	[AccessedThroughProperty("Expander_AltSpeed")]
	[CompilerGenerated]
	private OdcExpander odcExpander_1;

	[AccessedThroughProperty("WPFControl_AltSpeed")]
	[CompilerGenerated]
	private UnitSpeedAlt unitSpeedAlt_0;

	[AccessedThroughProperty("Expander_ContactLastDetections")]
	[CompilerGenerated]
	private OdcExpander odcExpander_2;

	[CompilerGenerated]
	[AccessedThroughProperty("WPFControl_RecentDetections")]
	private RecentDetections_WPF recentDetections_WPF_0;

	[AccessedThroughProperty("Expander_UnitWeapons")]
	[CompilerGenerated]
	private OdcExpander odcExpander_3;

	[AccessedThroughProperty("WPFControl_UnitWeapons")]
	[CompilerGenerated]
	private UnitWeapons_WPF unitWeapons_WPF_0;

	[AccessedThroughProperty("Expander_UnitFuel")]
	[CompilerGenerated]
	private OdcExpander odcExpander_4;

	[AccessedThroughProperty("WPFControl_FuelPanel")]
	[CompilerGenerated]
	private FuelPanel_WPF fuelPanel_WPF_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Expander_UnitEMCON")]
	private OdcExpander odcExpander_5;

	[CompilerGenerated]
	[AccessedThroughProperty("WPFControl_UnitEMCON")]
	private UnitEMCON_WPF unitEMCON_WPF_0;

	[AccessedThroughProperty("DoctrineButton")]
	[CompilerGenerated]
	private Button button_0;

	[CompilerGenerated]
	[AccessedThroughProperty("DoctrineWarningsHost")]
	private StackPanel stackPanel_1;

	private bool bool_2;

	internal virtual ScrollViewer MyScrollViewer
	{
		[CompilerGenerated]
		get
		{
			return scrollViewer_0;
		}
		[CompilerGenerated]
		set
		{
			scrollViewer_0 = value;
		}
	}

	internal virtual Grid MyGrid
	{
		[CompilerGenerated]
		get
		{
			return grid_0;
		}
		[CompilerGenerated]
		set
		{
			grid_0 = value;
		}
	}

	internal virtual RowDefinition RowDefinition_UsedSpace
	{
		[CompilerGenerated]
		get
		{
			return rowDefinition_0;
		}
		[CompilerGenerated]
		set
		{
			rowDefinition_0 = value;
		}
	}

	internal virtual RowDefinition RowDefinition_ExtraSpace
	{
		[CompilerGenerated]
		get
		{
			return rowDefinition_1;
		}
		[CompilerGenerated]
		set
		{
			rowDefinition_1 = value;
		}
	}

	internal virtual ColumnDefinition ColumnDefinition_UsedSpace
	{
		[CompilerGenerated]
		get
		{
			return columnDefinition_0;
		}
		[CompilerGenerated]
		set
		{
			columnDefinition_0 = value;
		}
	}

	internal virtual StackPanel StackPanel_Main
	{
		[CompilerGenerated]
		get
		{
			return stackPanel_0;
		}
		[CompilerGenerated]
		set
		{
			stackPanel_0 = value;
		}
	}

	internal virtual TextBlock lblNoUnitSelected
	{
		[CompilerGenerated]
		get
		{
			return textBlock_0;
		}
		[CompilerGenerated]
		set
		{
			textBlock_0 = value;
		}
	}

	internal virtual OdcExpander Expander_UnitStatus
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			RoutedEventHandler value2 = new RoutedEventHandler(method_1);
			RoutedEventHandler value3 = new RoutedEventHandler(method_2);
			OdcExpander odcExpander = odcExpander_0;
			if (odcExpander != null)
			{
				odcExpander.Expanded -= value2;
				odcExpander.Collapsed -= value3;
			}
			odcExpander_0 = value;
			odcExpander = odcExpander_0;
			if (odcExpander != null)
			{
				odcExpander.Expanded += value2;
				odcExpander.Collapsed += value3;
			}
		}
	}

	internal virtual UnitStatus_WPF WPFControl_UnitStatus
	{
		[CompilerGenerated]
		get
		{
			return unitStatus_WPF_0;
		}
		[CompilerGenerated]
		set
		{
			unitStatus_WPF_0 = value;
		}
	}

	internal virtual OdcExpander Expander_AltSpeed
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_1;
		}
		[CompilerGenerated]
		set
		{
			odcExpander_1 = value;
		}
	}

	internal virtual UnitSpeedAlt WPFControl_AltSpeed
	{
		[CompilerGenerated]
		get
		{
			return unitSpeedAlt_0;
		}
		[CompilerGenerated]
		set
		{
			unitSpeedAlt_0 = value;
		}
	}

	internal virtual OdcExpander Expander_ContactLastDetections
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_2;
		}
		[CompilerGenerated]
		set
		{
			odcExpander_2 = value;
		}
	}

	internal virtual RecentDetections_WPF WPFControl_RecentDetections
	{
		[CompilerGenerated]
		get
		{
			return recentDetections_WPF_0;
		}
		[CompilerGenerated]
		set
		{
			recentDetections_WPF_0 = value;
		}
	}

	internal virtual OdcExpander Expander_UnitWeapons
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_3;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler value2 = new RoutedEventHandler(method_3);
			OdcExpander odcExpander = odcExpander_3;
			if (odcExpander != null)
			{
				odcExpander.Expanded -= value2;
			}
			odcExpander_3 = value;
			odcExpander = odcExpander_3;
			if (odcExpander != null)
			{
				odcExpander.Expanded += value2;
			}
		}
	}

	internal virtual UnitWeapons_WPF WPFControl_UnitWeapons
	{
		[CompilerGenerated]
		get
		{
			return unitWeapons_WPF_0;
		}
		[CompilerGenerated]
		set
		{
			unitWeapons_WPF_0 = value;
		}
	}

	internal virtual OdcExpander Expander_UnitFuel
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_4;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler value2 = new RoutedEventHandler(method_4);
			OdcExpander odcExpander = odcExpander_4;
			if (odcExpander != null)
			{
				odcExpander.Expanded -= value2;
			}
			odcExpander_4 = value;
			odcExpander = odcExpander_4;
			if (odcExpander != null)
			{
				odcExpander.Expanded += value2;
			}
		}
	}

	internal virtual FuelPanel_WPF WPFControl_FuelPanel
	{
		[CompilerGenerated]
		get
		{
			return fuelPanel_WPF_0;
		}
		[CompilerGenerated]
		set
		{
			fuelPanel_WPF_0 = value;
		}
	}

	internal virtual OdcExpander Expander_UnitEMCON
	{
		[CompilerGenerated]
		get
		{
			return odcExpander_5;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler value2 = new RoutedEventHandler(method_5);
			OdcExpander odcExpander = odcExpander_5;
			if (odcExpander != null)
			{
				odcExpander.Expanded -= value2;
			}
			odcExpander_5 = value;
			odcExpander = odcExpander_5;
			if (odcExpander != null)
			{
				odcExpander.Expanded += value2;
			}
		}
	}

	internal virtual UnitEMCON_WPF WPFControl_UnitEMCON
	{
		[CompilerGenerated]
		get
		{
			return unitEMCON_WPF_0;
		}
		[CompilerGenerated]
		set
		{
			unitEMCON_WPF_0 = value;
		}
	}

	internal virtual Button DoctrineButton
	{
		[CompilerGenerated]
		get
		{
			return button_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = new RoutedEventHandler(method_6);
			Button val2 = button_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click -= val;
			}
			button_0 = value;
			val2 = button_0;
			if (val2 != null)
			{
				((ButtonBase)val2).Click += val;
			}
		}
	}

	internal virtual StackPanel DoctrineWarningsHost
	{
		[CompilerGenerated]
		get
		{
			return stackPanel_1;
		}
		[CompilerGenerated]
		set
		{
			stackPanel_1 = value;
		}
	}

	public RightColumnWPF()
	{
		bool_0 = true;
		Refreshing = false;
		bool_1 = false;
		InitializeComponent();
	}

	public void SuspendRefresh()
	{
		bool_0 = false;
	}

	public void ResumeRefresh()
	{
		bool_0 = true;
		RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
	}

	public void ReleaseReferences()
	{
		try
		{
			((UIElement)Expander_UnitWeapons).Visibility = (Visibility)2;
			((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
			((UIElement)Expander_UnitEMCON).Visibility = (Visibility)2;
			((UIElement)Expander_ContactLastDetections).Visibility = (Visibility)2;
			WPFControl_UnitStatus.ReleaseReferences();
			WPFControl_FuelPanel.Refresh(null);
			UnitWeapons_WPF wPFControl_UnitWeapons = WPFControl_UnitWeapons;
			bool theUnitHasWeapons = false;
			bool thePanelIsExpanded = false;
			wPFControl_UnitWeapons.Refresh(null, ref theUnitHasWeapons, ref thePanelIsExpanded);
			WPFControl_UnitEMCON.Refresh(null);
			WPFControl_RecentDetections.RefreshPanel(null, null);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void RefreshPanels(Scenario theScen, Side theSide, Module_Unit.Unit theUnit, bool IsCyclicRefresh = false)
	{
		if (!bool_0)
		{
			return;
		}
		if (Client.SelectedUnit == null)
		{
			theUnit = null;
		}
		bool thePanelIsExpanded2;
		if (Client.CurrentSide != null && theUnit != null)
		{
			((UIElement)lblNoUnitSelected).Visibility = (Visibility)2;
			((UIElement)Expander_UnitStatus).Visibility = (Visibility)0;
			try
			{
				Refreshing = true;
				((UIElement)Expander_UnitStatus).IsEnabled = theUnit != null;
				if (theScen == null || theSide == null || theUnit == null)
				{
					return;
				}
				bool theUnitHasWeapons = default(bool);
				if (theUnit.IsActiveUnit && (theUnit.get_UnitSide(SetSideOnly: false) == Client.CurrentSide || Client.CurrentMapProfile.GodsEye || Client.CurrentSide.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient))
				{
					((UIElement)DoctrineButton).Visibility = (Visibility)0;
					if (!theUnit.IsGroup)
					{
						((HeaderedContentControl)Expander_UnitStatus).Header = "UNIT STATUS";
						((HeaderedContentControl)Expander_AltSpeed).Header = "UNIT ALT / SPEED";
						((HeaderedContentControl)Expander_UnitWeapons).Header = "UNIT WEAPONS";
						((HeaderedContentControl)Expander_UnitFuel).Header = "UNIT FUEL";
						((HeaderedContentControl)Expander_UnitEMCON).Header = "UNIT EMCON";
					}
					else
					{
						((HeaderedContentControl)Expander_UnitStatus).Header = "GROUP STATUS";
						((HeaderedContentControl)Expander_AltSpeed).Header = "GROUP ALT / SPEED";
						((HeaderedContentControl)Expander_UnitWeapons).Header = "GROUP WEAPONS";
						((HeaderedContentControl)Expander_UnitFuel).Header = "GROUP FUEL";
						((HeaderedContentControl)Expander_UnitEMCON).Header = "GROUP EMCON";
					}
					bool thePanelIsExpanded = Expander_UnitWeapons.IsExpanded;
					WPFControl_UnitWeapons.Refresh((ActiveUnit)theUnit, ref theUnitHasWeapons, ref thePanelIsExpanded);
					if (Expander_UnitWeapons.IsExpanded != thePanelIsExpanded && thePanelIsExpanded)
					{
						Expander_UnitWeapons.IsExpanded = true;
						Expander_UnitWeapons.IsExpanded = false;
					}
					((UIElement)Expander_AltSpeed).Visibility = (Visibility)0;
					if (theUnit.IsAggregatedUnit)
					{
						((UIElement)Expander_UnitEMCON).Visibility = (Visibility)2;
					}
					else
					{
						((UIElement)Expander_UnitEMCON).Visibility = (Visibility)0;
					}
					if (theUnit.IsAggregatedUnit)
					{
						((UIElement)Expander_UnitWeapons).Visibility = (Visibility)2;
					}
					else if (!theUnitHasWeapons)
					{
						((UIElement)Expander_UnitWeapons).Visibility = (Visibility)2;
					}
					else
					{
						((UIElement)Expander_UnitWeapons).Visibility = (Visibility)0;
					}
					if (theUnit.IsGroup)
					{
						Group obj = (Group)theUnit;
						if (obj.Type == Group.GroupType.NavalBase || obj.Type == Group.GroupType.AirBase)
						{
							((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
						}
					}
					WPFControl_UnitEMCON.Refresh((ActiveUnit)theUnit);
					WPFControl_AltSpeed.Refresh(TriggeredBySpeedAltForm: true);
					if (theUnit.IsShip && ((Ship)theUnit).IsNuke)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
					}
					else if (theUnit.IsSubmarine && (((Submarine)theUnit).IsNuke || ((Submarine)theUnit).Fuel_ReadOnly.Count == 0))
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
					}
					else if (theUnit.IsFacility && ((ActiveUnit)theUnit).Fuel_ReadOnly.Count < 1)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
						((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
					}
					else if (theUnit.IsWeapon)
					{
						WPFControl_FuelPanel.Refresh(null);
						((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
						((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
					}
					else if (!theUnit.IsAggregatedUnit)
					{
						if (!theUnit.IsSatellite)
						{
							WPFControl_FuelPanel.Refresh((ActiveUnit)theUnit);
							((UIElement)Expander_UnitFuel).Visibility = (Visibility)0;
						}
						else
						{
							WPFControl_FuelPanel.Refresh(null);
							((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
							((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
						}
					}
					else
					{
						((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
						((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
					}
					if (!Expander_UnitFuel.IsExpanded)
					{
						Expander_UnitFuel.IsExpanded = true;
						Expander_UnitFuel.IsExpanded = false;
					}
					else
					{
						Expander_UnitFuel.IsExpanded = false;
						Expander_UnitFuel.IsExpanded = true;
					}
					if (Expander_AltSpeed.IsExpanded)
					{
						Expander_AltSpeed.IsExpanded = false;
						Expander_AltSpeed.IsExpanded = true;
					}
					else
					{
						Expander_AltSpeed.IsExpanded = true;
						Expander_AltSpeed.IsExpanded = false;
					}
					if (!((ActiveUnit)Client.SelectedUnit).CommStuff.IsConnectedToSideNetwork && Client.CurrentSide.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.RealisticSubComms) && ((ActiveUnit)Client.SelectedUnit).UnitType == GlobalVariables.ActiveUnitType.Submarine)
					{
						((UIElement)DoctrineButton).Visibility = (Visibility)1;
					}
				}
				else if (theUnit.IsContact())
				{
					((UIElement)DoctrineButton).Visibility = (Visibility)1;
					((HeaderedContentControl)Expander_UnitStatus).Header = "Contact Status";
					((UIElement)Expander_UnitWeapons).Visibility = (Visibility)2;
					((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
					((UIElement)Expander_UnitEMCON).Visibility = (Visibility)2;
					((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
					WPFControl_FuelPanel.Refresh(null);
					UnitWeapons_WPF wPFControl_UnitWeapons = WPFControl_UnitWeapons;
					thePanelIsExpanded2 = false;
					wPFControl_UnitWeapons.Refresh(null, ref theUnitHasWeapons, ref thePanelIsExpanded2);
					WPFControl_UnitEMCON.Refresh(null);
				}
				else
				{
					((UIElement)DoctrineButton).Visibility = (Visibility)1;
					((UIElement)Expander_UnitWeapons).Visibility = (Visibility)2;
					((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
					((UIElement)Expander_UnitEMCON).Visibility = (Visibility)2;
					((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
					WPFControl_FuelPanel.Refresh(null);
					UnitWeapons_WPF wPFControl_UnitWeapons2 = WPFControl_UnitWeapons;
					thePanelIsExpanded2 = false;
					wPFControl_UnitWeapons2.Refresh(null, ref theUnitHasWeapons, ref thePanelIsExpanded2);
					WPFControl_UnitEMCON.Refresh(null);
				}
				RefreshDoctrineWarning();
				if (theUnit.IsContact())
				{
					((UIElement)Expander_ContactLastDetections).Visibility = (Visibility)0;
					((UIElement)WPFControl_RecentDetections).Visibility = (Visibility)0;
					((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
					if (Expander_ContactLastDetections.IsExpanded)
					{
						WPFControl_RecentDetections.RefreshPanel((Contact)theUnit, theScen);
					}
				}
				else
				{
					((UIElement)Expander_ContactLastDetections).Visibility = (Visibility)2;
					((UIElement)WPFControl_RecentDetections).Visibility = (Visibility)2;
				}
				if (Expander_UnitStatus.IsExpanded)
				{
					((UIElement)WPFControl_UnitStatus).Visibility = (Visibility)0;
					WPFControl_UnitStatus.RefreshPanel(theScen, theSide, theUnit);
				}
				else
				{
					((UIElement)WPFControl_UnitStatus).Visibility = (Visibility)2;
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 999999", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
				Refreshing = false;
			}
		}
		((UIElement)lblNoUnitSelected).Visibility = (Visibility)0;
		((UIElement)Expander_UnitStatus).Visibility = (Visibility)2;
		((UIElement)Expander_AltSpeed).Visibility = (Visibility)2;
		((UIElement)Expander_UnitWeapons).Visibility = (Visibility)2;
		((UIElement)Expander_UnitFuel).Visibility = (Visibility)2;
		((UIElement)Expander_UnitEMCON).Visibility = (Visibility)2;
		((UIElement)Expander_ContactLastDetections).Visibility = (Visibility)2;
		((UIElement)DoctrineButton).Visibility = (Visibility)2;
		WPFControl_UnitStatus.RefreshPanel(theScen, theSide, null);
		WPFControl_FuelPanel.Refresh(null);
		UnitWeapons_WPF wPFControl_UnitWeapons3 = WPFControl_UnitWeapons;
		bool theUnitHasWeapons2 = false;
		thePanelIsExpanded2 = false;
		wPFControl_UnitWeapons3.Refresh(null, ref theUnitHasWeapons2, ref thePanelIsExpanded2);
		WPFControl_UnitEMCON.Refresh(null);
		WPFControl_RecentDetections.RefreshPanel(null, theScen);
	}

	public void RefreshDoctrineWarning()
	{
		((Panel)DoctrineWarningsHost).Children.Clear();
		Module_Unit.Unit selectedUnit = Client.SelectedUnit;
		if (Information.IsNothing((object)selectedUnit) || !selectedUnit.IsActiveUnit || (selectedUnit.get_UnitSide(SetSideOnly: false) != Client.CurrentSide && !Client.CurrentMapProfile.GodsEye && Client.CurrentSide.AwarenessLevel != Side.AwarenessLevel_Enum.Omniscient))
		{
			return;
		}
		ActiveUnit activeUnit = (ActiveUnit)selectedUnit;
		foreach (var warning in activeUnit.Doctrine.GetWarnings())
		{
			DoctrineWarning doctrineWarning = new DoctrineWarning(this, warning);
			((Panel)DoctrineWarningsHost).Children.Add((UIElement)(object)doctrineWarning);
		}
	}

	public double GetElementPixelSize(UIElement element)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		PresentationSource val = PresentationSource.FromVisual((Visual)(object)element);
		Matrix transformToDevice;
		if (val == null)
		{
			HwndSource val2 = new HwndSource(default(HwndSourceParameters));
			try
			{
				transformToDevice = val2.CompositionTarget.TransformToDevice;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		else
		{
			transformToDevice = val.CompositionTarget.TransformToDevice;
		}
		return ((Matrix)(ref transformToDevice)).M11;
	}

	public void PositionCorrectlyWithinMainform(MainForm MainFormRef)
	{
		if (Client.theElementHostRightColumn != null)
		{
			double elementPixelSize = GetElementPixelSize((UIElement)(object)this);
			((FrameworkElement)MyScrollViewer).MaxHeight = (double)(((Control)MainFormRef.WorldWindow1).Height + 110) / elementPixelSize;
			if (!bool_1)
			{
				bool_1 = true;
				((Control)Client.theElementHostRightColumn).Width = (int)Math.Round(270.0 * elementPixelSize);
			}
			MainForm mainForm = (MainForm)(object)((Control)Client.theElementHostRightColumn).Parent;
			if (mainForm != null)
			{
				_ = ((Form)mainForm).Size.Width;
				_ = ((Control)Client.theElementHostRightColumn).Width;
				((Control)Client.theElementHostRightColumn).Top = ((Control)mainForm.MenuStrip1).Top;
			}
		}
	}

	private void method_0(object sender, EventArgs e)
	{
		if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
		{
			return;
		}
		double actualHeight = ((FrameworkElement)StackPanel_Main).ActualHeight;
		if (Client.theElementHostRightColumn != null)
		{
			if (actualHeight > (double)(((Control)MyProject.Forms.MainForm.WorldWindow1).Height - 75))
			{
				MyScrollViewer.VerticalScrollBarVisibility = (ScrollBarVisibility)3;
			}
			if (actualHeight < (double)(((Control)MyProject.Forms.MainForm.WorldWindow1).Height - 75) * 0.9)
			{
				MyScrollViewer.VerticalScrollBarVisibility = (ScrollBarVisibility)0;
			}
		}
	}

	private void method_1(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void method_2(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void method_3(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void method_4(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void method_5(object sender, RoutedEventArgs e)
	{
		if (!Refreshing)
		{
			RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit);
		}
	}

	private void method_6(object sender, RoutedEventArgs e)
	{
		if (!Information.IsNothing((object)Client.SelectedUnit))
		{
			((Control)new DoctrineForm
			{
				Subject = Client.SelectedUnit
			}).Show();
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		if (!bool_2)
		{
			bool_2 = true;
			Uri uri = new Uri("/Command;component/customcontrols/rightcolumn/rightcolumnwpf.xaml", UriKind.Relative);
			Application.LoadComponent((object)this, uri);
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void System_Windows_Markup_IComponentConnector_Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			MyScrollViewer = (ScrollViewer)target;
			break;
		case 2:
			MyGrid = (Grid)target;
			break;
		case 3:
			RowDefinition_UsedSpace = (RowDefinition)target;
			break;
		case 4:
			RowDefinition_ExtraSpace = (RowDefinition)target;
			break;
		case 5:
			ColumnDefinition_UsedSpace = (ColumnDefinition)target;
			break;
		case 6:
			StackPanel_Main = (StackPanel)target;
			((UIElement)StackPanel_Main).LayoutUpdated += method_0;
			break;
		case 7:
			lblNoUnitSelected = (TextBlock)target;
			break;
		case 8:
			Expander_UnitStatus = (OdcExpander)target;
			break;
		case 9:
			WPFControl_UnitStatus = (UnitStatus_WPF)target;
			break;
		case 10:
			Expander_AltSpeed = (OdcExpander)target;
			break;
		case 11:
			WPFControl_AltSpeed = (UnitSpeedAlt)target;
			break;
		case 12:
			Expander_ContactLastDetections = (OdcExpander)target;
			break;
		case 13:
			WPFControl_RecentDetections = (RecentDetections_WPF)target;
			break;
		case 14:
			Expander_UnitWeapons = (OdcExpander)target;
			break;
		case 15:
			WPFControl_UnitWeapons = (UnitWeapons_WPF)target;
			break;
		case 16:
			Expander_UnitFuel = (OdcExpander)target;
			break;
		case 17:
			WPFControl_FuelPanel = (FuelPanel_WPF)target;
			break;
		case 18:
			Expander_UnitEMCON = (OdcExpander)target;
			break;
		case 19:
			WPFControl_UnitEMCON = (UnitEMCON_WPF)target;
			break;
		case 20:
			DoctrineButton = (Button)target;
			break;
		case 21:
			DoctrineWarningsHost = (StackPanel)target;
			break;
		default:
			bool_2 = true;
			break;
		}
	}

	static RightColumnWPF()
	{
		Class72.smethod_20();
	}
}
