using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscate]
public sealed class HoverInfoTemplateSelector : DataTemplateSelector, INotifyPropertyChanged
{
	[CompilerGenerated]
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private DataTemplate dataTemplate_0;

	private DataTemplate dataTemplate_1;

	private DataTemplate dataTemplate_2;

	private DataTemplate dataTemplate_3;

	private DataTemplate dataTemplate_4;

	private DataTemplate dataTemplate_5;

	private DataTemplate dataTemplate_6;

	private DataTemplate dataTemplate_7;

	private DataTemplate dataTemplate_8;

	private DataTemplate dataTemplate_9;

	private DataTemplate dataTemplate_10;

	private DataTemplate dataTemplate_11;

	public DataTemplate ShipTemplate
	{
		get
		{
			return dataTemplate_0;
		}
		set
		{
			SetProperty(ref dataTemplate_0, value, "ShipTemplate");
		}
	}

	public DataTemplate SubTemplate
	{
		get
		{
			return dataTemplate_1;
		}
		set
		{
			SetProperty(ref dataTemplate_1, value, "SubTemplate");
		}
	}

	public DataTemplate AircraftTemplate
	{
		get
		{
			return dataTemplate_2;
		}
		set
		{
			SetProperty(ref dataTemplate_2, value, "AircraftTemplate");
		}
	}

	public DataTemplate GroundUnitTemplate
	{
		get
		{
			return dataTemplate_3;
		}
		set
		{
			SetProperty(ref dataTemplate_3, value, "GroundUnitTemplate");
		}
	}

	public DataTemplate SatelliteTemplate
	{
		get
		{
			return dataTemplate_4;
		}
		set
		{
			SetProperty(ref dataTemplate_4, value, "SatelliteTemplate");
		}
	}

	public DataTemplate WeaponTemplate
	{
		get
		{
			return dataTemplate_5;
		}
		set
		{
			SetProperty(ref dataTemplate_5, value, "WeaponTemplate");
		}
	}

	public DataTemplate AirbaseTemplate
	{
		get
		{
			return dataTemplate_6;
		}
		set
		{
			SetProperty(ref dataTemplate_6, value, "AirbaseTemplate");
		}
	}

	public DataTemplate GroundGroupTemplate
	{
		get
		{
			return dataTemplate_7;
		}
		set
		{
			SetProperty(ref dataTemplate_7, value, "GroundGroupTemplate");
		}
	}

	public DataTemplate NavalGroupTemplate
	{
		get
		{
			return dataTemplate_8;
		}
		set
		{
			SetProperty(ref dataTemplate_8, value, "NavalGroupTemplate");
		}
	}

	public DataTemplate AirGroupTemplate
	{
		get
		{
			return dataTemplate_9;
		}
		set
		{
			SetProperty(ref dataTemplate_9, value, "AirGroupTemplate");
		}
	}

	public DataTemplate ContactTemplate
	{
		get
		{
			return dataTemplate_10;
		}
		set
		{
			SetProperty(ref dataTemplate_10, value, "ContactTemplate");
		}
	}

	public DataTemplate FallbackTemplate
	{
		get
		{
			return dataTemplate_11;
		}
		set
		{
			SetProperty(ref dataTemplate_11, value, "FallbackTemplate");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, value))
		{
			return false;
		}
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	public override DataTemplate SelectTemplate(object item, DependencyObject container)
	{
		if (item == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return null;
		}
		HoverInfoViewModel hoverInfoViewModel = (HoverInfoViewModel)item;
		if (!(hoverInfoViewModel.Unit is Contact))
		{
			if (!(hoverInfoViewModel.Unit is Weapon))
			{
				if (hoverInfoViewModel.Unit is Group)
				{
					Group obj = (Group)hoverInfoViewModel.Unit;
					if (obj.Units.Values.Any([SpecialName] (ActiveUnit F) => F.UnitType == GlobalVariables.ActiveUnitType.Facility))
					{
						if (!obj.Units.Values.Any([SpecialName] (ActiveUnit F) => F.AirFacilities_ReadOnly.Any([SpecialName] (AirFacility O) => O.AirFacType != AirFacility._AirFacType.None)))
						{
							if (obj.Units.Values.Any([SpecialName] (ActiveUnit F) => F.DockFacilities_ReadOnly.Any([SpecialName] (DockFacility O) => O.Type != DockFacility.DockFacilityType.None)))
							{
								return AirbaseTemplate;
							}
							return GroundGroupTemplate;
						}
						return AirbaseTemplate;
					}
					if (obj.Units.Values.Any([SpecialName] (ActiveUnit F) => (F.UnitType == GlobalVariables.ActiveUnitType.Ship) | (F.UnitType == GlobalVariables.ActiveUnitType.Submarine)))
					{
						return NavalGroupTemplate;
					}
					if (obj.Units.Values.Any([SpecialName] (ActiveUnit F) => F.UnitType == GlobalVariables.ActiveUnitType.Aircraft))
					{
						return AirGroupTemplate;
					}
				}
				if (hoverInfoViewModel.Unit is ActiveUnit)
				{
					ActiveUnit activeUnit = (ActiveUnit)hoverInfoViewModel.Unit;
					if (activeUnit is Ship)
					{
						return ShipTemplate;
					}
					if (activeUnit is Aircraft)
					{
						return AircraftTemplate;
					}
					if (activeUnit is Submarine)
					{
						return SubTemplate;
					}
					if (activeUnit is Facility)
					{
						return GroundUnitTemplate;
					}
					if (activeUnit is Satellite)
					{
						return SatelliteTemplate;
					}
				}
				return FallbackTemplate;
			}
			return WeaponTemplate;
		}
		return ContactTemplate;
	}

	static HoverInfoTemplateSelector()
	{
		Class72.smethod_20();
	}
}
