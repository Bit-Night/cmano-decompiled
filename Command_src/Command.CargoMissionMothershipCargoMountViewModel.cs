using System.Data.SQLite;
using Command_Core;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class CargoMissionMothershipCargoMountViewModel : CommandViewModel
{
	private string string_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private bool vaHjuqunek;

	private Cargo.CargoObjectType cargoObjectType_0;

	public string Status => Name + " " + Conversions.ToString(ToUnload) + " / " + Conversions.ToString(Available);

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Name");
		}
	}

	public int Available
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "Available");
		}
	}

	public int ToUnload
	{
		get
		{
			return int_1;
		}
		set
		{
			SetProperty(ref int_1, value, "ToUnload");
		}
	}

	public int DBID
	{
		get
		{
			return int_2;
		}
		set
		{
			SetProperty(ref int_2, value, "DBID");
		}
	}

	public bool canMove
	{
		get
		{
			return vaHjuqunek;
		}
		set
		{
			SetProperty(ref vaHjuqunek, value, "canMove");
		}
	}

	public Cargo.CargoObjectType ObjectType
	{
		get
		{
			return cargoObjectType_0;
		}
		set
		{
			SetProperty(ref cargoObjectType_0, value, "ObjectType");
		}
	}

	public CargoMissionMothershipCargoMountViewModel(Cargo.CargoObjectType theType, int theDBID)
	{
		switch (theType)
		{
		case Cargo.CargoObjectType.Mount:
		{
			Scenario theScen = Client.CurrentScenario;
			Name = DBFunctions.GetMountName(theDBID, ref theScen);
			break;
		}
		case Cargo.CargoObjectType.Vehicle:
		{
			SQLiteConnection theConn = Client.CurrentScenario.DBConnection;
			Name = DBFunctions.GetVehicleName(theDBID, ref theConn);
			break;
		}
		case Cargo.CargoObjectType.Facility:
		{
			SQLiteConnection theConn = Client.CurrentScenario.DBConnection;
			Name = DBFunctions.GetFacilityName(theDBID, ref theConn);
			break;
		}
		}
		ObjectType = theType;
		DBID = theDBID;
	}

	static CargoMissionMothershipCargoMountViewModel()
	{
		Class72.smethod_20();
	}
}
