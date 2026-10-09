using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class UnitWeaponViewModel : CommandViewModel
{
	public bool mouseOverPanel;

	[ThreadStatic]
	private StringBuilder stringBuilder_0;

	private List<UnitWeaponElementViewModel> list_0;

	private bool bool_0;

	private List<UnitWeaponElementViewModel> list_1;

	private ObservableCollection<UnitWeaponElementViewModel> observableCollection_0;

	public ActiveUnit theUnit;

	public ActiveUnit Last_theUnit;

	private List<UnitWeaponElementViewModel> Weapons
	{
		get
		{
			return list_0;
		}
		set
		{
			SetProperty(ref list_0, value, "Weapons");
		}
	}

	public bool HasWeapons
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "HasWeapons");
		}
	}

	public List<UnitWeaponElementViewModel> Weapons_Sorted
	{
		get
		{
			return list_1;
		}
		set
		{
			SetProperty(ref list_1, value, "Weapons_Sorted");
		}
	}

	public ObservableCollection<UnitWeaponElementViewModel> WeaponsCollection_Sorted
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "WeaponsCollection_Sorted");
		}
	}

	private void method_0(Weapon weapon_0, int int_0)
	{
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		UnitWeaponElementViewModel unitWeaponElementViewModel = Weapons.FirstOrDefault([SpecialName] (UnitWeaponElementViewModel s) => s.WeaponDBID == weapon_0.DBID);
		if (unitWeaponElementViewModel == null)
		{
			stringBuilder_0.Clear();
			List<string> validTargets_Description = weapon_0.ValidTargets_Description;
			string value = ((validTargets_Description.Count > 0) ? string.Join(", ", validTargets_Description) : "");
			string value2 = ((weapon_0.MaxAirRange <= 0f) ? "" : ("Air: " + Conversions.ToString(weapon_0.MaxAirRange))) + ((weapon_0.MaxSurfaceRange > 0f) ? (" Surface: " + Conversions.ToString(weapon_0.MaxSurfaceRange)) : "") + ((weapon_0.MaxSubsurfaceRange > 0f) ? (" Subsurface: " + Conversions.ToString(weapon_0.MaxSubsurfaceRange)) : "") + ((weapon_0.MaxLandRange > 0f) ? (" Land: " + Conversions.ToString(weapon_0.MaxLandRange)) : "");
			stringBuilder_0.Append(weapon_0.Name).Append("\r\nType: ").Append(weapon_0.Type_Description)
				.Append("\r\nMax NM range: ")
				.Append(value2)
				.Append("\r\nTargets: ")
				.Append(value);
			unitWeaponElementViewModel = new UnitWeaponElementViewModel();
			unitWeaponElementViewModel.WeaponDBID = weapon_0.DBID;
			unitWeaponElementViewModel.Name = weapon_0.Name;
			unitWeaponElementViewModel.Type = (int)weapon_0.Type;
			unitWeaponElementViewModel.Details = stringBuilder_0.ToString();
			if (!weapon_0.IsDecoy)
			{
				if (weapon_0.MaxAirRange != 0f)
				{
					unitWeaponElementViewModel.TypeColor = new SolidColorBrush(Color.FromRgb(Client.CurrentMapProfile.RangeSymbol_Colors.AAWeapon.R, Client.CurrentMapProfile.RangeSymbol_Colors.AAWeapon.G, Client.CurrentMapProfile.RangeSymbol_Colors.AAWeapon.B));
				}
				if (weapon_0.MaxSurfaceRange != 0f)
				{
					unitWeaponElementViewModel.Type2Color = new SolidColorBrush(Color.FromRgb(Client.CurrentMapProfile.RangeSymbol_Colors.ASWeapon.R, Client.CurrentMapProfile.RangeSymbol_Colors.ASWeapon.G, Client.CurrentMapProfile.RangeSymbol_Colors.ASWeapon.B));
				}
				if (weapon_0.MaxSubsurfaceRange != 0f)
				{
					unitWeaponElementViewModel.Type3Color = new SolidColorBrush(Color.FromRgb(Client.CurrentMapProfile.RangeSymbol_Colors.color_1.R, byte.MaxValue, Client.CurrentMapProfile.RangeSymbol_Colors.color_1.B));
				}
				if (weapon_0.MaxLandRange != 0f)
				{
					unitWeaponElementViewModel.Type4Color = new SolidColorBrush(Color.FromRgb(Client.CurrentMapProfile.RangeSymbol_Colors.AGWeapon.R, Client.CurrentMapProfile.RangeSymbol_Colors.AGWeapon.G, Client.CurrentMapProfile.RangeSymbol_Colors.AGWeapon.B));
				}
			}
			Weapons.Add(unitWeaponElementViewModel);
			stringBuilder_0.Clear();
		}
		if (int_0 > 0)
		{
			unitWeaponElementViewModel.Qty += int_0;
		}
	}

	public void AddLoadoutWeapons(ActiveUnit theUnit)
	{
		if (((Aircraft)theUnit).Loadout == null)
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)theUnit).Loadout.Weapons;
		foreach (WeaponRec weaponRec in weapons)
		{
			if (weaponRec.CurrentLoad <= 0)
			{
				continue;
			}
			Weapon weapon = weaponRec.get_ReferenceWeapon(Client.CurrentScenario);
			switch (weapon.Type)
			{
			case Weapon._WeaponType.SensorPod:
				foreach (WeaponRec weaponWeapon in weapon.WeaponWeapons)
				{
					if (weaponWeapon.CurrentLoad > 0)
					{
						Weapon weapon_ = weaponWeapon.get_ReferenceWeapon(Client.CurrentScenario);
						method_0(weapon_, weaponWeapon.CurrentLoad);
					}
				}
				break;
			default:
				method_0(weapon, weaponRec.CurrentLoad);
				break;
			case Weapon._WeaponType.TrainingRound:
			case Weapon._WeaponType.DropTank:
			case Weapon._WeaponType.BuddyStore:
			case Weapon._WeaponType.FerryTank:
			case Weapon._WeaponType.HeliTowedPackage:
				break;
			}
		}
	}

	private void method_1(ActiveUnit activeUnit_0)
	{
		if (activeUnit_0.SharedMagazines == null)
		{
			return;
		}
		IEnumerable<Magazine> enumerable = activeUnit_0.SharedMagazines.OrderBy([SpecialName] (Magazine theM) => theM.Name);
		foreach (Magazine item in enumerable)
		{
			if (item.IsAviationMag || item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec weapon2 in item.Weapons)
			{
				if (weapon2.CurrentLoad > 0)
				{
					Weapon weapon = weapon2.get_ReferenceWeapon(Client.CurrentScenario);
					if (weapon.Type != Weapon._WeaponType.TrainingRound)
					{
						int currentLoad = weapon2.CurrentLoad;
						method_0(weapon, currentLoad);
					}
				}
			}
		}
	}

	private void method_2(ActiveUnit activeUnit_0)
	{
		IEnumerable<Mount> enumerable = activeUnit_0.Mounts.OrderBy([SpecialName] (Mount theM) => theM.Name);
		foreach (Mount item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon weapon = mountWeapon.get_ReferenceWeapon(Client.CurrentScenario);
				if (weapon.Type != Weapon._WeaponType.TrainingRound)
				{
					int num = activeUnit_0.Weaponry.HowManyOfThisWeaponOnMountMagazine(item, mountWeapon.int_3);
					int currentLoad = mountWeapon.CurrentLoad;
					if (num > 0 || currentLoad > 0)
					{
						method_0(weapon, currentLoad + num);
					}
				}
			}
		}
	}

	public UnitWeaponViewModel(ActiveUnit theUnit)
	{
		mouseOverPanel = false;
		stringBuilder_0 = new StringBuilder();
		list_0 = new List<UnitWeaponElementViewModel>();
		bool_0 = false;
		observableCollection_0 = new ObservableCollection<UnitWeaponElementViewModel>();
		this.theUnit = theUnit;
		Refresh();
	}

	public void Refresh()
	{
		if (mouseOverPanel || theUnit == null || (theUnit.IsShip && ((Ship)theUnit).IsSinking))
		{
			return;
		}
		if (theUnit.IsActiveUnit)
		{
			if (!theUnit.IsAircraft && !theUnit.IsShip && !theUnit.IsSubmarine && !theUnit.IsFacility && !theUnit.IsSingleUnitAirbase && !theUnit.IsGroup && !theUnit.IsVehicle)
			{
				Weapons.Clear();
				if (Weapons_Sorted != null)
				{
					Weapons_Sorted.Clear();
				}
				WeaponsCollection_Sorted.Clear();
			}
			else
			{
				if (theUnit == Last_theUnit)
				{
					foreach (UnitWeaponElementViewModel weapon in Weapons)
					{
						weapon.Qty = 0;
					}
				}
				else
				{
					Weapons.Clear();
					WeaponsCollection_Sorted.Clear();
				}
				if (!theUnit.IsAircraft)
				{
					if (!theUnit.IsShip && !theUnit.IsSubmarine && !theUnit.IsFacility && !theUnit.IsVehicle)
					{
						if (theUnit.IsGroup && ((Group)theUnit).Type == Group.GroupType.AirGroup)
						{
							foreach (ActiveUnit value in ((Group)theUnit).Units.Values)
							{
								method_2(value);
								AddLoadoutWeapons(value);
							}
						}
						else if (theUnit.IsGroup)
						{
							foreach (ActiveUnit value2 in ((Group)theUnit).Units.Values)
							{
								method_2(value2);
								method_1(value2);
							}
						}
					}
					else
					{
						method_2(theUnit);
						method_1(theUnit);
					}
				}
				else
				{
					method_2(theUnit);
					AddLoadoutWeapons(theUnit);
				}
				WeaponsCollection_Sorted.Clear();
				Weapons_Sorted = (from theRec in Weapons
					orderby theRec.Type, theRec.Name
					select theRec).ToList();
				foreach (UnitWeaponElementViewModel item in Weapons_Sorted)
				{
					WeaponsCollection_Sorted.Add(item);
				}
			}
		}
		if (Weapons.Count > 0)
		{
			HasWeapons = true;
		}
		else
		{
			HasWeapons = false;
		}
		Last_theUnit = theUnit;
	}

	static UnitWeaponViewModel()
	{
		Class72.smethod_20();
	}
}
