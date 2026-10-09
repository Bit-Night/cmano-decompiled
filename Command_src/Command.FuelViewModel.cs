using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class FuelViewModel : CommandViewModel
{
	private ObservableCollection<PlatFormViewModel> observableCollection_0;

	private object object_0;

	public ActiveUnit theUnit;

	public ObservableCollection<PlatFormViewModel> Items
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Items");
		}
	}

	public object SelectedItem
	{
		get
		{
			return object_0;
		}
		set
		{
			SetProperty(ref object_0, RuntimeHelpers.GetObjectValue(value), "SelectedItem");
		}
	}

	[Obsolete("Used for design time only", true)]
	public FuelViewModel()
	{
		observableCollection_0 = new ObservableCollection<PlatFormViewModel>();
		AircraftFuelViewModel item = new AircraftFuelViewModel
		{
			Percentage = 50.0,
			Text = "Test Text",
			UnitName = "Aircraft Unit"
		};
		Items.Add(item);
		ShipFuelViewModel item2 = new ShipFuelViewModel
		{
			Percentage = 25.0,
			Text = "Test Text",
			UnitName = "Ship Unit"
		};
		Items.Add(item2);
		SubmarineFuelViewModel item3 = new SubmarineFuelViewModel
		{
			Percentage = 50.0,
			EnduranceText = "Test Text",
			UnitName = "Submarine Unit"
		};
		Items.Add(item3);
		GroundUnitFuelViewModel item4 = new GroundUnitFuelViewModel
		{
			Percentage = 25.0,
			Text = "Test Text",
			UnitName = "Ground Unit"
		};
		Items.Add(item4);
		SupplyFacilityUnitFuelViewModel item5 = new SupplyFacilityUnitFuelViewModel
		{
			Percentage = 25.0,
			Text = "Test Text",
			UnitName = "Supply Facility"
		};
		Items.Add(item5);
		SelectedItem = Items.First();
	}

	private void method_0(ActiveUnit activeUnit_0)
	{
		try
		{
			PlatFormViewModel platFormViewModel = Items.FirstOrDefault([SpecialName] (PlatFormViewModel s) => s != null && s.theUnit == activeUnit_0);
			if (platFormViewModel != null)
			{
				if (platFormViewModel is AircraftFuelViewModel)
				{
					((AircraftFuelViewModel)platFormViewModel).Refresh();
				}
				else if (!(platFormViewModel is SubmarineFuelViewModel))
				{
					if (!(platFormViewModel is ShipFuelViewModel))
					{
						if (platFormViewModel is GroundUnitFuelViewModel)
						{
							((GroundUnitFuelViewModel)platFormViewModel).Refresh();
						}
						else if (platFormViewModel is SupplyFacilityUnitFuelViewModel)
						{
							((SupplyFacilityUnitFuelViewModel)platFormViewModel).Refresh();
						}
					}
					else
					{
						((ShipFuelViewModel)platFormViewModel).Refresh();
					}
				}
				else
				{
					((SubmarineFuelViewModel)platFormViewModel).Refresh();
				}
			}
			else if (!(activeUnit_0 is Aircraft))
			{
				if (!(activeUnit_0 is Submarine))
				{
					if (!(activeUnit_0 is Ship))
					{
						if (!(activeUnit_0 is Vehicle))
						{
							if (activeUnit_0 is Facility && activeUnit_0.Fuel_ReadOnly.Count > 0)
							{
								platFormViewModel = new SupplyFacilityUnitFuelViewModel((Facility)activeUnit_0);
								Items.Add(platFormViewModel);
							}
						}
						else
						{
							platFormViewModel = new GroundUnitFuelViewModel((Vehicle)activeUnit_0);
							Items.Add(platFormViewModel);
						}
					}
					else
					{
						platFormViewModel = new ShipFuelViewModel((Ship)activeUnit_0);
						Items.Add(platFormViewModel);
					}
				}
				else
				{
					platFormViewModel = new SubmarineFuelViewModel((Submarine)activeUnit_0);
					Items.Add(platFormViewModel);
				}
			}
			else
			{
				platFormViewModel = new AircraftFuelViewModel((Aircraft)activeUnit_0);
				Items.Add(platFormViewModel);
			}
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
		}
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void Refresh()
	{
		try
		{
			if (theUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)theUnit).Units)
				{
					method_0(unit.Value);
				}
			}
			else
			{
				method_0(theUnit);
			}
			if ((SelectedItem == null) & (Items.Count != 0))
			{
				SelectedItem = Items.First();
			}
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
		}
	}

	public FuelViewModel(ActiveUnit theUnit)
	{
		observableCollection_0 = new ObservableCollection<PlatFormViewModel>();
		this.theUnit = theUnit;
		Refresh();
	}

	static FuelViewModel()
	{
		Class72.smethod_20();
	}
}
