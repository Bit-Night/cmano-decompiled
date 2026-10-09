using System.Windows;
using System.Windows.Media;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class CargoOpsCargoItemViewModel : CommandViewModel
{
	private Cargo cargo_0;

	private int int_0;

	private int int_1;

	private bool bool_0;

	private bool bool_1;

	public Cargo Cargo
	{
		get
		{
			return cargo_0;
		}
		set
		{
			SetProperty(ref cargo_0, value, "Cargo");
		}
	}

	public int Quantity
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "Quantity");
		}
	}

	public int InitialQuantity
	{
		get
		{
			return int_1;
		}
		set
		{
			SetProperty(ref int_1, value, "InitialQuantity");
		}
	}

	public bool CargoTypeLimited
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "CargoTypeLimited");
		}
	}

	public bool IsUnitHeader
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "IsUnitHeader");
		}
	}

	public Visibility DetailsVisibility
	{
		get
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (IsUnitHeader)
			{
				return (Visibility)1;
			}
			return (Visibility)0;
		}
	}

	public SolidColorBrush CargoTypeLimitedBrush
	{
		get
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			if (IsUnitHeader)
			{
				return new SolidColorBrush(Colors.White);
			}
			if (CargoTypeLimited)
			{
				return new SolidColorBrush(Colors.IndianRed);
			}
			return new SolidColorBrush(Colors.White);
		}
	}

	public string Name
	{
		get
		{
			if (IsUnitHeader)
			{
				return "[Group Member] " + Cargo.Name;
			}
			return Conversions.ToString(Quantity) + "x " + Cargo.CargoObjectName;
		}
	}

	public CargoType CargoType => Cargo.RequiredCargoType;

	public double MassPerUnit => Cargo.RequiredMass;

	public double AreaPerUnit => Cargo.RequiredArea;

	public double CrewPerUnit => Cargo.RequiredCrewSpace;

	public string Abilities
	{
		get
		{
			if (!Cargo.isParadropCapable)
			{
				return "";
			}
			return "Paradrop Capable";
		}
	}

	static CargoOpsCargoItemViewModel()
	{
		Class72.smethod_20();
	}
}
