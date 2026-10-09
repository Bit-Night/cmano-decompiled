using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using Command_Core;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class CargoOpsViewModel : CommandViewModel
{
	[CompilerGenerated]
	internal sealed class _Closure$__115-0
	{
		public Cargo $VB$Local_c;

		public _Closure$__115-0(_Closure$__115-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_c = arg0.$VB$Local_c;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(CargoOpsCargoItemViewModel i)
		{
			if (i.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return i.Cargo.CargoObjectDBID == $VB$Local_c.CargoObjectDBID;
			}
			return false;
		}

		static _Closure$__115-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__146-0
	{
		public CargoOpsCargoItemViewModel $VB$Local_C;

		public _Closure$__146-0(_Closure$__146-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_C = arg0.$VB$Local_C;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Cargo OC)
		{
			if (OC.CurrentType == $VB$Local_C.Cargo.CurrentType && OC.CargoObjectDBID == $VB$Local_C.Cargo.CargoObjectDBID && $VB$Local_C.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return true;
			}
			return Operators.CompareString(OC.CargoObjectID, $VB$Local_C.Cargo.CargoObjectID, true) == 0;
		}

		static _Closure$__146-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__146-1
	{
		public CargoOpsCargoItemViewModel $VB$Local_C;

		public _Closure$__146-1(_Closure$__146-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_C = arg0.$VB$Local_C;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Cargo OC)
		{
			if (OC.CurrentType == $VB$Local_C.Cargo.CurrentType && OC.CargoObjectDBID == $VB$Local_C.Cargo.CargoObjectDBID && $VB$Local_C.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return true;
			}
			return Operators.CompareString(OC.CargoObjectID, $VB$Local_C.Cargo.CargoObjectID, true) == 0;
		}

		static _Closure$__146-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__146-2
	{
		public Cargo $VB$Local_thisCargo;

		public _Closure$__146-2(_Closure$__146-2 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_thisCargo = arg0.$VB$Local_thisCargo;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Cargo oc)
		{
			if (oc.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return oc.CargoObjectDBID == $VB$Local_thisCargo.CargoObjectDBID;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda$__3(Cargo oc)
		{
			return Operators.CompareString(oc.CargoObjectID, $VB$Local_thisCargo.CargoObjectID, true) == 0;
		}

		static _Closure$__146-2()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__146-3
	{
		public CargoOpsCargoItemViewModel $VB$Local_C;

		public _Closure$__146-3(_Closure$__146-3 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_C = arg0.$VB$Local_C;
			}
		}

		[SpecialName]
		internal bool _Lambda$__4(Cargo OC)
		{
			if (OC.CurrentType == $VB$Local_C.Cargo.CurrentType && OC.CargoObjectDBID == $VB$Local_C.Cargo.CargoObjectDBID && $VB$Local_C.Cargo.CurrentType == Cargo.CargoObjectType.Mount)
			{
				return true;
			}
			return Operators.CompareString(OC.CargoObjectID, $VB$Local_C.Cargo.CargoObjectID, true) == 0;
		}

		static _Closure$__146-3()
		{
			Class72.smethod_20();
		}
	}

	private CargoOps cargoOps_0;

	private ActiveUnit activeUnit_0;

	private ActiveUnit activeUnit_1;

	private ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_0;

	private CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private CargoType cargoType_0;

	private string string_0;

	private bool bool_0;

	private Cargo[] cargo_0;

	private Collection<ActiveUnit> collection_0;

	private ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_1;

	private CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel_1;

	private double double_6;

	private double double_7;

	private double double_8;

	private double double_9;

	private double double_10;

	private double double_11;

	private CargoType cargoType_1;

	private string string_1;

	private bool bool_1;

	[CompilerGenerated]
	private DataTable dataTable_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	[CompilerGenerated]
	private RelayCommand relayCommand_2;

	[CompilerGenerated]
	private RelayCommand relayCommand_3;

	[CompilerGenerated]
	private RelayCommand relayCommand_4;

	[CompilerGenerated]
	private RelayCommand relayCommand_5;

	public CargoOps Form
	{
		get
		{
			return cargoOps_0;
		}
		set
		{
			SetProperty(ref cargoOps_0, value, "Form");
		}
	}

	public ActiveUnit Host
	{
		get
		{
			return activeUnit_0;
		}
		set
		{
			SetProperty(ref activeUnit_0, value, "Host");
		}
	}

	public ActiveUnit Target
	{
		get
		{
			return activeUnit_1;
		}
		set
		{
			SetProperty(ref activeUnit_1, value, "Target");
		}
	}

	public ObservableCollection<CargoOpsCargoItemViewModel> HostInventory
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			SetProperty(ref observableCollection_0, value, "HostInventory");
		}
	}

	public CargoOpsCargoItemViewModel HostSelectedItem
	{
		get
		{
			return cargoOpsCargoItemViewModel_0;
		}
		set
		{
			SetProperty(ref cargoOpsCargoItemViewModel_0, value, "HostSelectedItem");
			OnPropertyChanged("LoadVisibility");
			OnPropertyChanged("UnloadVisibility");
		}
	}

	public double HostRequiredMass
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "HostRequiredMass");
		}
	}

	public double HostRequiredArea
	{
		get
		{
			return double_1;
		}
		set
		{
			SetProperty(ref double_1, value, "HostRequiredArea");
		}
	}

	public double HostRequiredCrew
	{
		get
		{
			return double_2;
		}
		set
		{
			SetProperty(ref double_2, value, "HostRequiredCrew");
		}
	}

	public double HostTotalMass
	{
		get
		{
			return double_3;
		}
		set
		{
			SetProperty(ref double_3, value, "HostTotalMass");
		}
	}

	public double HostTotalArea
	{
		get
		{
			return double_4;
		}
		set
		{
			SetProperty(ref double_4, value, "HostTotalArea");
		}
	}

	public double HostTotalCrew
	{
		get
		{
			return double_5;
		}
		set
		{
			SetProperty(ref double_5, value, "HostTotalCrew");
		}
	}

	public CargoType HostType
	{
		get
		{
			return cargoType_0;
		}
		set
		{
			SetProperty(ref cargoType_0, value, "HostType");
		}
	}

	public string HostName
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "HostName");
		}
	}

	public bool HostIsGroup
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "HostIsGroup");
		}
	}

	public ObservableCollection<CargoOpsCargoItemViewModel> TargetInventory
	{
		get
		{
			return observableCollection_1;
		}
		set
		{
			SetProperty(ref observableCollection_1, value, "TargetInventory");
		}
	}

	public CargoOpsCargoItemViewModel TargetSelectedItem
	{
		get
		{
			return cargoOpsCargoItemViewModel_1;
		}
		set
		{
			SetProperty(ref cargoOpsCargoItemViewModel_1, value, "TargetSelectedItem");
			OnPropertyChanged("LoadVisibility");
			OnPropertyChanged("UnloadVisibility");
		}
	}

	public double TargetRequiredMass
	{
		get
		{
			return double_6;
		}
		set
		{
			SetProperty(ref double_6, value, "TargetRequiredMass");
		}
	}

	public double TargetRequiredArea
	{
		get
		{
			return double_7;
		}
		set
		{
			SetProperty(ref double_7, value, "TargetRequiredArea");
		}
	}

	public double TargetRequiredCrew
	{
		get
		{
			return double_8;
		}
		set
		{
			SetProperty(ref double_8, value, "TargetRequiredCrew");
		}
	}

	public double TargetTotalMass
	{
		get
		{
			return double_9;
		}
		set
		{
			SetProperty(ref double_9, value, "TargetTotalMass");
		}
	}

	public double TargetTotalArea
	{
		get
		{
			return double_10;
		}
		set
		{
			SetProperty(ref double_10, value, "TargetTotalArea");
		}
	}

	public double TargetTotalCrew
	{
		get
		{
			return double_11;
		}
		set
		{
			SetProperty(ref double_11, value, "TargetTotalCrew");
		}
	}

	public CargoType TargetType
	{
		get
		{
			return cargoType_1;
		}
		set
		{
			SetProperty(ref cargoType_1, value, "TargetType");
		}
	}

	public string TargetName
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "TargetName");
		}
	}

	public bool Exchange
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "Exchange");
			OnPropertyChanged("ExchangeVisibility");
			OnPropertyChanged("ExchangeVisibilityInverse");
			OnPropertyChanged("LoadVisibility");
			OnPropertyChanged("UnloadVisibility");
		}
	}

	public Visibility ExchangeVisibility
	{
		get
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (Exchange)
			{
				return (Visibility)0;
			}
			return (Visibility)2;
		}
	}

	public Visibility ExchangeVisibilityInverse
	{
		get
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (!Exchange)
			{
				return (Visibility)0;
			}
			return (Visibility)2;
		}
	}

	public Visibility LoadVisibility
	{
		get
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			if (TargetSelectedItem != null)
			{
				int num;
				if (TargetSelectedItem.CargoTypeLimited)
				{
					num = 2;
				}
				else
				{
					if (!TargetSelectedItem.IsUnitHeader)
					{
						goto IL_0029;
					}
					num = 2;
				}
				return (Visibility)num;
			}
			goto IL_0029;
			IL_0029:
			if (HostSelectedItem != null && HostSelectedItem.IsUnitHeader)
			{
				return (Visibility)2;
			}
			if (!Exchange)
			{
				return (Visibility)2;
			}
			return (Visibility)0;
		}
	}

	public Visibility UnloadVisibility
	{
		get
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			if (TargetSelectedItem != null)
			{
				int num;
				if (TargetSelectedItem.CargoTypeLimited)
				{
					num = 2;
				}
				else
				{
					if (!TargetSelectedItem.IsUnitHeader)
					{
						goto IL_0029;
					}
					num = 2;
				}
				return (Visibility)num;
			}
			goto IL_0029;
			IL_0029:
			if (HostSelectedItem != null && HostSelectedItem.IsUnitHeader)
			{
				return (Visibility)2;
			}
			if (!Exchange)
			{
				return (Visibility)2;
			}
			return (Visibility)0;
		}
	}

	public DataTable AllCargoItems
	{
		[CompilerGenerated]
		get
		{
			return dataTable_0;
		}
		[CompilerGenerated]
		set
		{
			dataTable_0 = value;
		}
	}

	public RelayCommand UnloadAllCommand
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

	public RelayCommand UnloadOneCommand
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

	public RelayCommand LoadOneCommand
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

	public RelayCommand LoadAllCommand
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

	public RelayCommand OKCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_4;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_4 = value;
		}
	}

	public RelayCommand CancelCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_5;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_5 = value;
		}
	}

	private void Recalculate()
	{
		HostRequiredMass = HostInventory.Select([SpecialName] (CargoOpsCargoItemViewModel C) => C.Cargo.RequiredMass * (float)C.Quantity).Sum([SpecialName] (float x) => x);
		HostRequiredArea = HostInventory.Select([SpecialName] (CargoOpsCargoItemViewModel C) => C.Cargo.RequiredArea * (float)C.Quantity).Sum([SpecialName] (float x) => x);
		HostRequiredCrew = HostInventory.Select([SpecialName] (CargoOpsCargoItemViewModel C) => C.Cargo.RequiredCrewSpace * (float)C.Quantity).Sum([SpecialName] (float x) => x);
		if (Target == null)
		{
			return;
		}
		ICargoHost obj = (ICargoHost)Target;
		float cargo_Mass = obj.GetCargo_Mass();
		float cargo_Area = obj.GetCargo_Area();
		float cargo_Crew = obj.GetCargo_Crew();
		TargetRequiredMass = TargetInventory.Select([SpecialName] (CargoOpsCargoItemViewModel C) => C.Cargo.RequiredMass * (float)C.Quantity).Sum([SpecialName] (float x) => x);
		TargetRequiredArea = TargetInventory.Select([SpecialName] (CargoOpsCargoItemViewModel C) => C.Cargo.RequiredArea * (float)C.Quantity).Sum([SpecialName] (float x) => x);
		TargetRequiredCrew = TargetInventory.Select([SpecialName] (CargoOpsCargoItemViewModel C) => C.Cargo.RequiredCrewSpace * (float)C.Quantity).Sum([SpecialName] (float x) => x);
		foreach (CargoOpsCargoItemViewModel item in TargetInventory)
		{
			if ((item.CargoType > HostType) | (item.CargoType > TargetType))
			{
				item.CargoTypeLimited = true;
			}
		}
		cargo_Mass = (float)((double)cargo_Mass - TargetRequiredMass);
		cargo_Area = (float)((double)cargo_Area - TargetRequiredArea);
		cargo_Crew = (float)((double)cargo_Crew - TargetRequiredCrew);
		foreach (CargoOpsCargoItemViewModel item2 in HostInventory)
		{
			if (!item2.CargoTypeLimited && (item2.CrewPerUnit > (double)cargo_Crew || item2.MassPerUnit > (double)cargo_Mass || item2.AreaPerUnit > (double)cargo_Area))
			{
				item2.CargoTypeLimited = true;
			}
		}
	}

	private void method_0(ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2, List<ActiveUnit> list_0)
	{
		bool flag = list_0.Count > 1;
		_Closure$__115-0 closure$__115- = default(_Closure$__115-0);
		foreach (ActiveUnit item3 in list_0)
		{
			if (item3.OnboardCargo.Count() == 0)
			{
				continue;
			}
			if (flag)
			{
				Cargo cargo = new Cargo(item3);
				cargo.Name = item3.Name;
				CargoOpsCargoItemViewModel item = new CargoOpsCargoItemViewModel
				{
					Cargo = cargo,
					Quantity = 0,
					InitialQuantity = 0,
					IsUnitHeader = true
				};
				observableCollection_2.Add(item);
			}
			Cargo[] onboardCargo = item3.OnboardCargo;
			for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
			{
				closure$__115- = new _Closure$__115-0(closure$__115-);
				closure$__115-.$VB$Local_c = onboardCargo[i];
				if (closure$__115-.$VB$Local_c.CurrentType == Cargo.CargoObjectType.Mount)
				{
					CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel = null;
					List<CargoOpsCargoItemViewModel> list = observableCollection_2.Where(closure$__115-._Lambda$__0).ToList();
					if (list.Count > 0)
					{
						cargoOpsCargoItemViewModel = list.First();
					}
					if (cargoOpsCargoItemViewModel == null)
					{
						cargoOpsCargoItemViewModel = new CargoOpsCargoItemViewModel
						{
							Cargo = closure$__115-.$VB$Local_c,
							Quantity = 1,
							InitialQuantity = 1
						};
						observableCollection_2.Add(cargoOpsCargoItemViewModel);
					}
					else
					{
						cargoOpsCargoItemViewModel.Quantity++;
						cargoOpsCargoItemViewModel.InitialQuantity++;
					}
				}
				else
				{
					CargoOpsCargoItemViewModel item2 = new CargoOpsCargoItemViewModel
					{
						Cargo = closure$__115-.$VB$Local_c,
						Quantity = 1,
						InitialQuantity = 1
					};
					observableCollection_2.Add(item2);
				}
			}
		}
	}

	public CargoOpsViewModel(CargoOps Form, ActiveUnit selectedHost, ActiveUnit selectedTarget)
	{
		observableCollection_0 = new ObservableCollection<CargoOpsCargoItemViewModel>();
		cargo_0 = new Cargo[0];
		collection_0 = new Collection<ActiveUnit>();
		observableCollection_1 = new ObservableCollection<CargoOpsCargoItemViewModel>();
		UnloadAllCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			UnloadAll();
		});
		UnloadOneCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			UnloadOne();
		});
		LoadOneCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			LoadOne();
		});
		LoadAllCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			LoadAll();
		});
		OKCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			OK();
		});
		CancelCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			Cancel();
		});
		this.Form = Form;
		SQLiteConnection sqliteConnection_ = Client.CurrentScenario.DBConnection;
		AllCargoItems = DBFunctions.GetAllCargoItems(ref sqliteConnection_);
		Host = selectedHost;
		Target = selectedTarget;
		if (Target == null)
		{
			Exchange = false;
		}
		else
		{
			Exchange = true;
		}
		if (Host == null)
		{
			if (Target is Aircraft)
			{
				Aircraft_AirOps airOps = ((Aircraft)Target).AirOps;
				Host = airOps.CurrentHostUnit;
			}
			else if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		if (!Host.IsGroup)
		{
			((Form)Form).Text = $"Cargo {Host.Name}";
		}
		else
		{
			((Form)Form).Text = $"Cargo {Host.Name} [Group]";
		}
		HostName = Host.Name;
		List<ActiveUnit> list = new List<ActiveUnit>();
		if (!(Host is Group))
		{
			ICargoHost cargoHost = (ICargoHost)Host;
			HostTotalMass = cargoHost.GetCargo_Mass();
			HostTotalArea = cargoHost.GetCargo_Area();
			HostTotalCrew = cargoHost.GetCargo_Crew();
			HostType = cargoHost.GetCargo_Type();
			cargo_0 = Host.OnboardCargo;
			list.Add(Host);
		}
		else
		{
			Group obj = (Group)Host;
			cargo_0 = new Cargo[0];
			HostTotalMass = 0.0;
			HostTotalArea = 0.0;
			HostTotalCrew = 0.0;
			HostType = CargoType.const_5;
			HostIsGroup = true;
			foreach (KeyValuePair<string, ActiveUnit> unit in obj.Units)
			{
				ICargoHost cargoHost2 = (ICargoHost)unit.Value;
				HostTotalMass += cargoHost2.GetCargo_Mass();
				HostTotalArea += cargoHost2.GetCargo_Area();
				HostTotalCrew += cargoHost2.GetCargo_Crew();
				Cargo[] onboardCargo = unit.Value.OnboardCargo;
				foreach (Cargo theAC in onboardCargo)
				{
					ArrayExtensions.Add(ref cargo_0, theAC);
				}
				collection_0.Add(unit.Value);
				list.Add(unit.Value);
			}
		}
		method_0(HostInventory, list);
		if (Target != null)
		{
			((Form)Form).Text = $"Cargo Exchange {Host.Name} <=> {Target.Name}";
			TargetName = Target.Name;
			ICargoHost cargoHost3 = (ICargoHost)Target;
			TargetTotalMass = cargoHost3.GetCargo_Mass();
			TargetTotalArea = cargoHost3.GetCargo_Area();
			TargetTotalCrew = cargoHost3.GetCargo_Crew();
			TargetType = cargoHost3.GetCargo_Type();
			list.Clear();
			list.Add(Target);
			method_0(TargetInventory, list);
		}
		Recalculate();
	}

	private void method_1(CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel_2, ActiveUnit activeUnit_2, ref ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2, ref ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_3, int int_0, double double_12, double double_13, double double_14, double double_15, double double_16, double double_17)
	{
		if (cargoOpsCargoItemViewModel_2 == null || cargoOpsCargoItemViewModel_2.IsUnitHeader || cargoOpsCargoItemViewModel_2.Quantity <= 0 || cargoOpsCargoItemViewModel_2.CargoTypeLimited)
		{
			return;
		}
		double massPerUnit = cargoOpsCargoItemViewModel_2.MassPerUnit;
		double areaPerUnit = cargoOpsCargoItemViewModel_2.AreaPerUnit;
		double crewPerUnit = cargoOpsCargoItemViewModel_2.CrewPerUnit;
		double num = (double_13 - double_12) / massPerUnit;
		double num2 = (double_15 - double_14) / areaPerUnit;
		double num3 = (double_17 - double_16) / crewPerUnit;
		CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel = observableCollection_2.First([SpecialName] (CargoOpsCargoItemViewModel I) => I.Cargo.CurrentType == cargoOpsCargoItemViewModel_2.Cargo.CurrentType && I.Cargo.CargoObjectDBID == cargoOpsCargoItemViewModel_2.Cargo.CargoObjectDBID && (cargoOpsCargoItemViewModel_2.Cargo.CurrentType == Cargo.CargoObjectType.Mount || Operators.CompareString(I.Cargo.CargoObjectID, cargoOpsCargoItemViewModel_2.Cargo.CargoObjectID, true) == 0));
		int num4 = (int)Math.Floor(new double[5] { int_0, num, num2, num3, cargoOpsCargoItemViewModel.Quantity }.Where([SpecialName] (double s) => !double.IsNaN(s)).ToArray().Min());
		if (num4 != 0)
		{
			CargoOpsCargoItemViewModel cargoOpsCargoItemViewModel2 = observableCollection_3.FirstOrDefault([SpecialName] (CargoOpsCargoItemViewModel I) => I.Cargo.CurrentType == cargoOpsCargoItemViewModel_2.Cargo.CurrentType && I.Cargo.CargoObjectDBID == cargoOpsCargoItemViewModel_2.Cargo.CargoObjectDBID && (cargoOpsCargoItemViewModel_2.Cargo.CurrentType == Cargo.CargoObjectType.Mount || Operators.CompareString(I.Cargo.CargoObjectID, cargoOpsCargoItemViewModel_2.Cargo.CargoObjectID, true) == 0));
			if (cargoOpsCargoItemViewModel2 == null)
			{
				cargoOpsCargoItemViewModel2 = new CargoOpsCargoItemViewModel
				{
					Cargo = cargoOpsCargoItemViewModel_2.Cargo,
					Quantity = 0,
					InitialQuantity = 0
				};
				observableCollection_3.Add(cargoOpsCargoItemViewModel2);
			}
			cargoOpsCargoItemViewModel2.Quantity += num4;
			cargoOpsCargoItemViewModel.Quantity -= num4;
			Recalculate();
		}
	}

	public void UnloadAll()
	{
		if (TargetSelectedItem != null)
		{
			CargoOpsCargoItemViewModel targetSelectedItem = TargetSelectedItem;
			ActiveUnit host = Host;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = TargetInventory;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = HostInventory;
			method_1(targetSelectedItem, host, ref observableCollection_, ref observableCollection_2, TargetSelectedItem.Quantity, HostRequiredMass, HostTotalMass, HostRequiredArea, HostTotalArea, HostRequiredCrew, HostTotalCrew);
			HostInventory = observableCollection_2;
			TargetInventory = observableCollection_;
		}
	}

	public void UnloadOne()
	{
		CargoOpsCargoItemViewModel targetSelectedItem = TargetSelectedItem;
		ActiveUnit host = Host;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = TargetInventory;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = HostInventory;
		method_1(targetSelectedItem, host, ref observableCollection_, ref observableCollection_2, 1, HostRequiredMass, HostTotalMass, HostRequiredArea, HostTotalArea, HostRequiredCrew, HostTotalCrew);
		HostInventory = observableCollection_2;
		TargetInventory = observableCollection_;
	}

	public void LoadOne()
	{
		CargoOpsCargoItemViewModel hostSelectedItem = HostSelectedItem;
		ActiveUnit target = Target;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = HostInventory;
		ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = TargetInventory;
		method_1(hostSelectedItem, target, ref observableCollection_, ref observableCollection_2, 1, TargetRequiredMass, TargetTotalMass, TargetRequiredArea, TargetTotalArea, TargetRequiredCrew, TargetTotalCrew);
		TargetInventory = observableCollection_2;
		HostInventory = observableCollection_;
	}

	public void LoadAll()
	{
		if (HostSelectedItem != null)
		{
			CargoOpsCargoItemViewModel hostSelectedItem = HostSelectedItem;
			ActiveUnit target = Target;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_ = HostInventory;
			ObservableCollection<CargoOpsCargoItemViewModel> observableCollection_2 = TargetInventory;
			method_1(hostSelectedItem, target, ref observableCollection_, ref observableCollection_2, HostSelectedItem.Quantity, TargetRequiredMass, TargetTotalMass, TargetRequiredArea, TargetTotalArea, TargetRequiredCrew, TargetTotalCrew);
			TargetInventory = observableCollection_2;
			HostInventory = observableCollection_;
		}
	}

	public void OK()
	{
		if (!HostIsGroup)
		{
			List<Cargo> list = new List<Cargo>();
			List<Cargo> list2 = new List<Cargo>();
			using (IEnumerator<CargoOpsCargoItemViewModel> enumerator = HostInventory.GetEnumerator())
			{
				_Closure$__146-0 closure$__146- = default(_Closure$__146-0);
				while (enumerator.MoveNext())
				{
					closure$__146- = new _Closure$__146-0(closure$__146-);
					closure$__146-.$VB$Local_C = enumerator.Current;
					if (closure$__146-.$VB$Local_C.Quantity < closure$__146-.$VB$Local_C.InitialQuantity)
					{
						int count = closure$__146-.$VB$Local_C.InitialQuantity - closure$__146-.$VB$Local_C.Quantity;
						list.AddRange(Host.OnboardCargo.Where(closure$__146-._Lambda$__0).Take(count));
					}
				}
			}
			using (IEnumerator<CargoOpsCargoItemViewModel> enumerator2 = TargetInventory.GetEnumerator())
			{
				_Closure$__146-1 closure$__146-2 = default(_Closure$__146-1);
				while (enumerator2.MoveNext())
				{
					closure$__146-2 = new _Closure$__146-1(closure$__146-2);
					closure$__146-2.$VB$Local_C = enumerator2.Current;
					if (closure$__146-2.$VB$Local_C.Quantity < closure$__146-2.$VB$Local_C.InitialQuantity)
					{
						int count2 = closure$__146-2.$VB$Local_C.InitialQuantity - closure$__146-2.$VB$Local_C.Quantity;
						list2.AddRange(Target.OnboardCargo.Where(closure$__146-2._Lambda$__1).Take(count2));
					}
				}
			}
			if (list.Count != 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Host, Target, list);
			}
			if (list2.Count != 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Target, Host, list2);
			}
			if (list.Count > 0 || list2.Count > 0)
			{
				if (!(Target is Ship))
				{
					if (!(Target is Aircraft))
					{
						if (Target is Vehicle)
						{
							Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
							Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list));
							Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list2));
						}
					}
					else
					{
						((Aircraft)Target).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
						((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list));
						((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list2));
					}
				}
				else
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list));
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list2));
				}
			}
		}
		else
		{
			Dictionary<Cargo, int> dictionary = new Dictionary<Cargo, int>();
			Dictionary<Cargo, int> dictionary2 = new Dictionary<Cargo, int>();
			foreach (CargoOpsCargoItemViewModel item in HostInventory)
			{
				if (item.Quantity < item.InitialQuantity)
				{
					int value = item.InitialQuantity - item.Quantity;
					dictionary[item.Cargo] = value;
				}
			}
			foreach (CargoOpsCargoItemViewModel item2 in TargetInventory)
			{
				if (item2.Quantity < item2.InitialQuantity)
				{
					int value2 = item2.InitialQuantity - item2.Quantity;
					dictionary2[item2.Cargo] = value2;
				}
			}
			_Closure$__146-2 closure$__146-3 = default(_Closure$__146-2);
			foreach (ActiveUnit item3 in collection_0)
			{
				List<Cargo> list3 = new List<Cargo>();
				int num = dictionary.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					closure$__146-3 = new _Closure$__146-2(closure$__146-3);
					closure$__146-3.$VB$Local_thisCargo = dictionary.Keys.ElementAtOrDefault(i);
					int num2 = dictionary.Values.ElementAtOrDefault(i);
					if (num2 > 0)
					{
						Cargo[] source = ((closure$__146-3.$VB$Local_thisCargo.CurrentType != Cargo.CargoObjectType.Mount) ? item3.OnboardCargo.Where(closure$__146-3._Lambda$__3).ToArray() : item3.OnboardCargo.Where(closure$__146-3._Lambda$__2).ToArray());
						num2 = Math.Min(num2, source.Count());
						if (num2 > 0)
						{
							list3.AddRange(source.Take(num2));
							dictionary[closure$__146-3.$VB$Local_thisCargo] = dictionary[closure$__146-3.$VB$Local_thisCargo] - num2;
						}
					}
				}
				if (list3.Count <= 0)
				{
					continue;
				}
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(item3, Target, list3);
				if (!(Target is Ship) && !(Target is Vehicle))
				{
					if (Target is Aircraft)
					{
						((Aircraft)Target).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
						((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list3));
					}
				}
				else
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToLoadCargo(Target, list3));
				}
			}
			List<Cargo> list4 = new List<Cargo>();
			ActiveUnit value3 = ((Group)Host).Units.First().Value;
			using (IEnumerator<CargoOpsCargoItemViewModel> enumerator6 = TargetInventory.GetEnumerator())
			{
				_Closure$__146-3 closure$__146-4 = default(_Closure$__146-3);
				while (enumerator6.MoveNext())
				{
					closure$__146-4 = new _Closure$__146-3(closure$__146-4);
					closure$__146-4.$VB$Local_C = enumerator6.Current;
					if (closure$__146-4.$VB$Local_C.Quantity < closure$__146-4.$VB$Local_C.InitialQuantity)
					{
						int count3 = closure$__146-4.$VB$Local_C.InitialQuantity - closure$__146-4.$VB$Local_C.Quantity;
						list4.AddRange(Target.OnboardCargo.Where(closure$__146-4._Lambda$__4).Take(count3));
					}
				}
			}
			if (list4.Count > 0)
			{
				ActiveUnit_DockingOps.PerformCargoTransferBetweenHostAndTarget(Target, value3, list4);
				if (!(Target is Ship) && !(Target is Vehicle))
				{
					if (Target is Aircraft)
					{
						((Aircraft)Target).AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Readying;
						((Aircraft)Target).AirOps.ConditionTimer = Math.Max(((Aircraft)Target).AirOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list4));
					}
				}
				else
				{
					Target.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.Readying;
					Target.DockingOps.ConditionTimer = Math.Max(Target.DockingOps.ConditionTimer, ActiveUnit_DockingOps.TimeToUnloadCargo(Target, list4));
				}
			}
		}
		AllCargoItems.Dispose();
		((Form)Form).Close();
	}

	public void Cancel()
	{
		AllCargoItems.Dispose();
		((Form)Form).Close();
	}

	static CargoOpsViewModel()
	{
		Class72.smethod_20();
	}
}
