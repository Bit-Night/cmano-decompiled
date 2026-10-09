using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class CargoMissionViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__42-0
	{
		public ActiveUnit $VB$Local_m;

		public _Closure$__42-0(_Closure$__42-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_m = arg0.$VB$Local_m;
			}
		}

		[SpecialName]
		internal bool _Lambda$__8(CargoMissionMothershipUnitViewModel s)
		{
			return s.theUnit == $VB$Local_m;
		}

		static _Closure$__42-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__42-1
	{
		public ActiveUnit $VB$Local_m;

		public _Closure$__42-1(_Closure$__42-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_m = arg0.$VB$Local_m;
			}
		}

		[SpecialName]
		internal bool _Lambda$__11(CargoMissionMothershipUnitViewModel s)
		{
			return s.theUnit == $VB$Local_m;
		}

		static _Closure$__42-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__42-2
	{
		public ActiveUnit $VB$Local_m;

		public _Closure$__42-2(_Closure$__42-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_m = arg0.$VB$Local_m;
			}
		}

		[SpecialName]
		internal bool _Lambda$__14(CargoMissionMothershipUnitViewModel s)
		{
			return s.theUnit == $VB$Local_m;
		}

		static _Closure$__42-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__42-3
	{
		public Cargo $VB$Local_m_cargo;

		public Func<Ship, bool> $I17;

		public Func<Aircraft, bool> $I19;

		public Func<Vehicle, bool> $I21;

		public _Closure$__42-3(_Closure$__42-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_m_cargo = arg0.$VB$Local_m_cargo;
			}
		}

		[SpecialName]
		internal bool _Lambda$__15(CargoMissionMothershipCargoMountViewModel s)
		{
			if (s.ObjectType == $VB$Local_m_cargo.CurrentType)
			{
				return s.DBID == $VB$Local_m_cargo.CargoObjectDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__17(Ship s)
		{
			return s.Cargo_Type >= $VB$Local_m_cargo.RequiredCargoType;
		}

		[SpecialName]
		internal bool _Lambda$__19(Aircraft s)
		{
			return s.Loadout.Cargo_Type >= $VB$Local_m_cargo.RequiredCargoType;
		}

		[SpecialName]
		internal bool _Lambda$__21(Vehicle s)
		{
			return s.Cargo_Type >= $VB$Local_m_cargo.RequiredCargoType;
		}

		static _Closure$__42-3()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__42-4
	{
		public Cargo $VB$Local_m_cargo;

		public Func<Ship, bool> $I24;

		public Func<Aircraft, bool> $I26;

		public Func<Vehicle, bool> $I28;

		public _Closure$__42-4(_Closure$__42-4 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_m_cargo = arg0.$VB$Local_m_cargo;
			}
		}

		[SpecialName]
		internal bool _Lambda$__22(CargoMissionMothershipCargoMountViewModel s)
		{
			if (s.ObjectType == $VB$Local_m_cargo.CurrentType)
			{
				return s.DBID == $VB$Local_m_cargo.CargoObjectDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__24(Ship s)
		{
			return s.Cargo_Type >= $VB$Local_m_cargo.RequiredCargoType;
		}

		[SpecialName]
		internal bool _Lambda$__26(Aircraft s)
		{
			return s.Loadout.Cargo_Type >= $VB$Local_m_cargo.RequiredCargoType;
		}

		[SpecialName]
		internal bool _Lambda$__28(Vehicle s)
		{
			return s.Cargo_Type >= $VB$Local_m_cargo.RequiredCargoType;
		}

		static _Closure$__42-4()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__42-5
	{
		public Ship $VB$Local_unit;

		public _Closure$__42-5(_Closure$__42-5 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_unit = arg0.$VB$Local_unit;
			}
		}

		[SpecialName]
		internal float _Lambda$__30(ReferencePoint s)
		{
			return s.RangeToPoint_Horiz($VB$Local_unit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false).get_Longitude((GlobalVariables.BooleanObject)null), $VB$Local_unit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false).get_Latitude((GlobalVariables.BooleanObject)null));
		}

		static _Closure$__42-5()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__43-0
	{
		public ActiveUnit $VB$Local_theUnit;

		public Func<CargoMissionAssignedUnitViewModel, bool> $I0;

		public _Closure$__43-0(_Closure$__43-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theUnit = arg0.$VB$Local_theUnit;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(CargoMissionAssignedUnitViewModel s)
		{
			return s.theUnit == $VB$Local_theUnit;
		}

		static _Closure$__43-0()
		{
			Class72.smethod_20();
		}
	}

	public CargoMission theMission;

	private ObservableCollection<CargoMissionAssignedUnitViewModel> PcqjIhisSh;

	private ObservableCollection<CargoMissionMothershipUnitViewModel> observableCollection_0;

	private ObservableCollection<string> observableCollection_1;

	private ObservableCollection<CargoMissionMothershipCargoMountViewModel> observableCollection_2;

	private CargoMissionMothershipCargoMountViewModel cargoMissionMothershipCargoMountViewModel_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	[CompilerGenerated]
	private RelayCommand relayCommand_2;

	[CompilerGenerated]
	private RelayCommand relayCommand_3;

	public ObservableCollection<CargoMissionAssignedUnitViewModel> AssignedUnits
	{
		get
		{
			return PcqjIhisSh;
		}
		set
		{
			SetProperty(ref PcqjIhisSh, value, "AssignedUnits");
		}
	}

	public ObservableCollection<CargoMissionMothershipUnitViewModel> Motherships
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "Motherships");
		}
	}

	public ObservableCollection<string> Issues
	{
		get
		{
			return observableCollection_1;
		}
		set
		{
			SetProperty(ref observableCollection_1, value, "Issues");
		}
	}

	public ObservableCollection<CargoMissionMothershipCargoMountViewModel> CargoObjects
	{
		get
		{
			return observableCollection_2;
		}
		set
		{
			SetProperty(ref observableCollection_2, value, "CargoObjects");
		}
	}

	public CargoMissionMothershipCargoMountViewModel SelectedCargoObject
	{
		get
		{
			return cargoMissionMothershipCargoMountViewModel_0;
		}
		set
		{
			SetProperty(ref cargoMissionMothershipCargoMountViewModel_0, value, "SelectedCargoObject");
		}
	}

	public string Units
	{
		get
		{
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				return "ft";
			}
			return "m";
		}
	}

	public float TransitAltitude_Aircraft
	{
		get
		{
			if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				return 3.28084f * theMission.TransitAltitude_Aircraft;
			}
			return theMission.TransitAltitude_Aircraft;
		}
		set
		{
			theMission.TransitAltitude_Aircraft = (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet ? (value / 3.28084f) : value);
		}
	}

	public float StationAltitude_Aircraft
	{
		get
		{
			if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				return theMission.StationAltitude_Aircraft;
			}
			return 3.28084f * theMission.StationAltitude_Aircraft;
		}
		set
		{
			theMission.StationAltitude_Aircraft = ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? value : (value / 3.28084f));
		}
	}

	public int TransitThrottle_Aircraft
	{
		get
		{
			return (int)(theMission.TransitThrottle_Aircraft - 1);
		}
		set
		{
			theMission.TransitThrottle_Aircraft = (ActiveUnit.Throttle)(value + 1);
		}
	}

	public int StationThrottle_Aircraft
	{
		get
		{
			return (int)(theMission.StationThrottle_Aircraft - 1);
		}
		set
		{
			theMission.StationThrottle_Aircraft = (ActiveUnit.Throttle)(value + 1);
		}
	}

	public int TransitThrottle_Ship
	{
		get
		{
			return (int)(theMission.TransitThrottle_Ship - 1);
		}
		set
		{
			theMission.TransitThrottle_Ship = (ActiveUnit.Throttle)(value + 1);
		}
	}

	public int StationThrottle_Ship
	{
		get
		{
			return (int)(theMission.StationThrottle_Ship - 1);
		}
		set
		{
			theMission.StationThrottle_Ship = (ActiveUnit.Throttle)(value + 1);
		}
	}

	public RelayCommand MountUnloadAllCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	public RelayCommand MountUnloadOneCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_1;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_1 = value;
		}
	}

	public RelayCommand MountLoadOneCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_2;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_2 = value;
		}
	}

	public RelayCommand MountLoadAllCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_3;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_3 = value;
		}
	}

	public CargoMissionViewModel(CargoMission theMission)
	{
		PcqjIhisSh = new ObservableCollection<CargoMissionAssignedUnitViewModel>();
		observableCollection_0 = new ObservableCollection<CargoMissionMothershipUnitViewModel>();
		observableCollection_1 = new ObservableCollection<string>();
		observableCollection_2 = new ObservableCollection<CargoMissionMothershipCargoMountViewModel>();
		MountUnloadAllCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			MountUnloadAll();
		});
		MountUnloadOneCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			MountUnloadOne();
		});
		MountLoadOneCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			MountLoadOne();
		});
		MountLoadAllCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			MountLoadAll();
		});
		this.theMission = theMission;
		foreach (CargoManifestItem item2 in theMission.CargoToUnload)
		{
			CargoMissionMothershipCargoMountViewModel item = new CargoMissionMothershipCargoMountViewModel(item2.objectType, item2.DBID)
			{
				ToUnload = item2.quantity
			};
			CargoObjects.Add(item);
		}
		foreach (ActiveUnit item3 in Module_Mission.UnitsAssignedToMissionOrPackage(theMission, Client.CurrentScenario))
		{
			Add(item3);
		}
		method_0();
	}

	private void method_0()
	{
		Issues.Clear();
		if (AssignedUnits.Count == 0)
		{
			Issues.Add("Zero units in mission");
		}
		if (AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>().Any([SpecialName] (Ship s) => s.Cargo_Type == CargoType.NoCargo))
		{
			Issues.Add("A ship has been added that is unable to take cargo. Please only add cargo carrying ships to this mission.");
		}
		if (AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>().Any([SpecialName] (Aircraft s) => s.Loadout.Cargo_Type == CargoType.NoCargo))
		{
			Issues.Add("An aircraft has been added that is unable to take cargo with its current loadout.");
		}
		if (AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>().Any([SpecialName] (Vehicle s) => s.Cargo_Type == CargoType.NoCargo))
		{
			Issues.Add("A ground unit has been added that is unable to take cargo. Please only add cargo carrying vehicles to this mission.");
		}
		if (!theMission.IsActive)
		{
			Issues.Add("The mission is currently inactive.");
		}
		Motherships.Clear();
		_Closure$__42-0 closure$__42- = default(_Closure$__42-0);
		foreach (Ship item in from s in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>()
			where s.Cargo_Type != CargoType.NoCargo
			select s)
		{
			closure$__42- = new _Closure$__42-0(closure$__42-);
			closure$__42-.$VB$Local_m = item.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			if (closure$__42-.$VB$Local_m != null && !Motherships.Any(closure$__42-._Lambda$__8))
			{
				Motherships.Add(new CargoMissionMothershipUnitViewModel(closure$__42-.$VB$Local_m));
			}
		}
		_Closure$__42-1 closure$__42-2 = default(_Closure$__42-1);
		foreach (Aircraft item2 in from s in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>()
			where s.Loadout.Cargo_Type != CargoType.NoCargo
			select s)
		{
			closure$__42-2 = new _Closure$__42-1(closure$__42-2);
			closure$__42-2.$VB$Local_m = item2.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			if (closure$__42-2.$VB$Local_m != null && !Motherships.Any(closure$__42-2._Lambda$__11))
			{
				Motherships.Add(new CargoMissionMothershipUnitViewModel(closure$__42-2.$VB$Local_m));
			}
		}
		_Closure$__42-2 closure$__42-3 = default(_Closure$__42-2);
		foreach (Vehicle item3 in from s in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>()
			where s.Cargo_Type != CargoType.NoCargo
			select s)
		{
			closure$__42-3 = new _Closure$__42-2(closure$__42-3);
			closure$__42-3.$VB$Local_m = item3.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			if (closure$__42-3.$VB$Local_m != null && !Motherships.Any(closure$__42-3._Lambda$__14))
			{
				Motherships.Add(new CargoMissionMothershipUnitViewModel(closure$__42-3.$VB$Local_m));
			}
		}
		foreach (CargoMissionMothershipCargoMountViewModel cargoObject in CargoObjects)
		{
			cargoObject.Available = 0;
		}
		_Closure$__42-3 closure$__42-4 = default(_Closure$__42-3);
		_Closure$__42-4 closure$__42-5 = default(_Closure$__42-4);
		foreach (CargoMissionMothershipUnitViewModel mothership in Motherships)
		{
			if (mothership.theUnit is Group)
			{
				foreach (KeyValuePair<string, ActiveUnit> unit in ((Group)mothership.theUnit).Units)
				{
					Cargo[] onboardCargo = unit.Value.OnboardCargo;
					for (int num = 0; num < onboardCargo.Length; num = checked(num + 1))
					{
						closure$__42-4 = new _Closure$__42-3(closure$__42-4);
						closure$__42-4.$VB$Local_m_cargo = onboardCargo[num];
						CargoMissionMothershipCargoMountViewModel cargoMissionMothershipCargoMountViewModel = CargoObjects.FirstOrDefault(closure$__42-4._Lambda$__15);
						if (cargoMissionMothershipCargoMountViewModel == null)
						{
							cargoMissionMothershipCargoMountViewModel = new CargoMissionMothershipCargoMountViewModel(closure$__42-4.$VB$Local_m_cargo.CurrentType, closure$__42-4.$VB$Local_m_cargo.CargoObjectDBID);
							CargoObjects.Add(cargoMissionMothershipCargoMountViewModel);
						}
						cargoMissionMothershipCargoMountViewModel.Available++;
						if (cargoMissionMothershipCargoMountViewModel.Available <= 0)
						{
							continue;
						}
						bool flag = false;
						foreach (Ship item4 in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>().Where(closure$__42-4._Lambda$__17))
						{
							_ = item4;
							flag = true;
						}
						foreach (Aircraft item5 in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>().Where(closure$__42-4._Lambda$__19))
						{
							_ = item5;
							flag = true;
						}
						foreach (Vehicle item6 in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>().Where((closure$__42-4.$I21 != null) ? closure$__42-4.$I21 : (closure$__42-4.$I21 = closure$__42-4._Lambda$__21)))
						{
							_ = item6;
							flag = true;
						}
						if (!flag)
						{
							cargoMissionMothershipCargoMountViewModel.canMove = false;
						}
						else
						{
							cargoMissionMothershipCargoMountViewModel.canMove = true;
						}
					}
				}
				continue;
			}
			Cargo[] onboardCargo2 = mothership.theUnit.OnboardCargo;
			for (int num2 = 0; num2 < onboardCargo2.Length; num2 = checked(num2 + 1))
			{
				closure$__42-5 = new _Closure$__42-4(closure$__42-5);
				closure$__42-5.$VB$Local_m_cargo = onboardCargo2[num2];
				CargoMissionMothershipCargoMountViewModel cargoMissionMothershipCargoMountViewModel2 = CargoObjects.FirstOrDefault(closure$__42-5._Lambda$__22);
				if (cargoMissionMothershipCargoMountViewModel2 == null)
				{
					cargoMissionMothershipCargoMountViewModel2 = new CargoMissionMothershipCargoMountViewModel(closure$__42-5.$VB$Local_m_cargo.CurrentType, closure$__42-5.$VB$Local_m_cargo.CargoObjectDBID);
					CargoObjects.Add(cargoMissionMothershipCargoMountViewModel2);
				}
				cargoMissionMothershipCargoMountViewModel2.Available++;
				if (cargoMissionMothershipCargoMountViewModel2.Available <= 0)
				{
					continue;
				}
				bool flag2 = false;
				foreach (Ship item7 in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>().Where(closure$__42-5._Lambda$__24))
				{
					_ = item7;
					flag2 = true;
				}
				foreach (Aircraft item8 in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Aircraft>().Where((closure$__42-5.$I26 != null) ? closure$__42-5.$I26 : (closure$__42-5.$I26 = closure$__42-5._Lambda$__26)))
				{
					_ = item8;
					flag2 = true;
				}
				foreach (Vehicle item9 in AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Vehicle>().Where(closure$__42-5._Lambda$__28))
				{
					_ = item9;
					flag2 = true;
				}
				if (!flag2)
				{
					cargoMissionMothershipCargoMountViewModel2.canMove = false;
				}
				else
				{
					cargoMissionMothershipCargoMountViewModel2.canMove = true;
				}
			}
		}
		using (IEnumerator<Ship> enumerator13 = AssignedUnits.Select([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit).OfType<Ship>().GetEnumerator())
		{
			_Closure$__42-5 closure$__42-6 = default(_Closure$__42-5);
			while (enumerator13.MoveNext())
			{
				closure$__42-6 = new _Closure$__42-5(closure$__42-6);
				closure$__42-6.$VB$Local_unit = enumerator13.Current;
				if (closure$__42-6.$VB$Local_unit.OnboardCargo.Count() > 0 && closure$__42-6.$VB$Local_unit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null)
				{
					float num3 = closure$__42-6.$VB$Local_unit.Kinematics.TacticalRadius() / 2f;
					CargoMission cargoMission = (CargoMission)closure$__42-6.$VB$Local_unit.ActiveMissionOrPackage();
					float num4 = 0f;
					num4 = ((cargoMission.DestinationUnit == null) ? cargoMission.Area.Select(closure$__42-6._Lambda$__30).Average() : cargoMission.DestinationUnit.RangeToUnit_Horiz(closure$__42-6.$VB$Local_unit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false)));
					if ((double)num4 >= (double)num3 * 0.75)
					{
						Issues.Add("Unit " + closure$__42-6.$VB$Local_unit.Name + " too far from destination area by " + $"{Math.Abs((double)num3 * 0.75 - (double)num4):0.0}" + "NM  to launch.");
					}
				}
			}
		}
		foreach (CargoMissionMothershipCargoMountViewModel cargoObject2 in CargoObjects)
		{
			if (cargoObject2.Available > 0 && !cargoObject2.canMove)
			{
				Issues.Add("No assigned unit can carry " + cargoObject2.Name + ".");
			}
		}
	}

	public void Remove(ActiveUnit theUnit)
	{
		_Closure$__43-0 arg = default(_Closure$__43-0);
		_Closure$__43-0 CS$<>8__locals5 = new _Closure$__43-0(arg);
		CS$<>8__locals5.$VB$Local_theUnit = theUnit;
		bool flag = false;
		CargoMissionAssignedUnitViewModel[] array = AssignedUnits.Where((CS$<>8__locals5.$I0 != null) ? CS$<>8__locals5.$I0 : (CS$<>8__locals5.$I0 = [SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit == CS$<>8__locals5.$VB$Local_theUnit)).ToArray();
		foreach (CargoMissionAssignedUnitViewModel item in array)
		{
			AssignedUnits.Remove(item);
			flag = true;
		}
		if (flag)
		{
			method_0();
		}
	}

	public void Add(ActiveUnit theUnit)
	{
		bool flag = false;
		if (!AssignedUnits.Any([SpecialName] (CargoMissionAssignedUnitViewModel s) => s.theUnit == theUnit))
		{
			AssignedUnits.Add(new CargoMissionAssignedUnitViewModel(theUnit));
			flag = true;
		}
		if (flag)
		{
			method_0();
		}
	}

	public void MountUnloadAll()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload = 0;
			method_1();
		}
	}

	public void MountUnloadOne()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload--;
			if (SelectedCargoObject.ToUnload < 0)
			{
				SelectedCargoObject.ToUnload = 0;
			}
			method_1();
		}
	}

	public void MountLoadOne()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload++;
			if (SelectedCargoObject.ToUnload > SelectedCargoObject.Available)
			{
				SelectedCargoObject.ToUnload = SelectedCargoObject.Available;
			}
			method_1();
		}
	}

	public void MountLoadAll()
	{
		if (SelectedCargoObject != null)
		{
			SelectedCargoObject.ToUnload = SelectedCargoObject.Available;
			method_1();
		}
	}

	private void method_1()
	{
		theMission.CargoToUnload.Clear();
		foreach (CargoMissionMothershipCargoMountViewModel cargoObject in CargoObjects)
		{
			CargoManifestItem cargoManifestItem = new CargoManifestItem(cargoObject.ObjectType, cargoObject.DBID);
			cargoManifestItem.quantity = cargoObject.ToUnload;
			theMission.CargoToUnload.Add(cargoManifestItem);
		}
	}

	static CargoMissionViewModel()
	{
		Class72.smethod_20();
	}
}
