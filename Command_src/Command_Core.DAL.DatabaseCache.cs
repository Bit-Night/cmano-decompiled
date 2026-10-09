using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core.DAL;

public class DatabaseCache
{
	public DataTable Cache_Aircraft_DT;

	public DataTable Cache_Ships_DT;

	public DataTable Cache_Subs_DT;

	public DataTable Cache_Facilities_DT;

	public DataTable Cache_GroundUnits_DT;

	public DataTable Cache_Satellites_DT;

	public DataTable Cache_Weapons_DT;

	public DataTable Cache_OperatorCountries_DT;

	public string CacheVersion_DT;

	public ConcurrentDictionary<string, HashSet<int>> Cache_AllPossibleEmissionsPerUnit;

	public ConcurrentDictionary<int, int> Cache_WeaponBurnoutWeight;

	public DatabaseCache()
	{
		Cache_Aircraft_DT = new DataTable();
		Cache_Ships_DT = new DataTable();
		Cache_Subs_DT = new DataTable();
		Cache_Facilities_DT = new DataTable();
		Cache_GroundUnits_DT = new DataTable();
		Cache_Satellites_DT = new DataTable();
		Cache_Weapons_DT = new DataTable();
		Cache_OperatorCountries_DT = new DataTable();
		Cache_AllPossibleEmissionsPerUnit = new ConcurrentDictionary<string, HashSet<int>>();
		Cache_WeaponBurnoutWeight = new ConcurrentDictionary<int, int>();
	}

	public void BuildCache(string DB, SQLiteConnection dBConnection = null)
	{
		if (string.IsNullOrEmpty(DB) || (Operators.CompareString(DB, CacheVersion_DT, false) == 0 && Cache_Aircraft_DT.Rows.Count > 0))
		{
			return;
		}
		try
		{
			if (dBConnection == null)
			{
				dBConnection = new SQLiteConnection(DBOps.smethod_4(Application.StartupPath, DB));
			}
			CacheVersion_DT = DB;
			new List<int>();
			DataTable dataTable = null;
			List<int> list = new List<int>();
			Cache_AllPossibleEmissionsPerUnit.Clear();
			Cache_WeaponBurnoutWeight.Clear();
			DBFunctions.Comms_State_Cached = false;
			DBFunctions.GetPlatformLists(ref Cache_Aircraft_DT, ref Cache_Ships_DT, ref Cache_Subs_DT, ref Cache_Facilities_DT, ref Cache_GroundUnits_DT, ref Cache_Satellites_DT, ref Cache_Weapons_DT, ref dBConnection);
			Cache_OperatorCountries_DT = DBFunctions.GetAllCountries(ref dBConnection, IncludeDeprecated: true);
			int num = 1;
			list.Clear();
			while (true)
			{
				GlobalVariables.ActiveUnitType unitType = GlobalVariables.ActiveUnitType.Aircraft;
				dataTable = Cache_Aircraft_DT;
				while (true)
				{
					if (dataTable != null)
					{
						foreach (DataRow row in dataTable.Rows)
						{
							list.Add(Conversions.ToInteger(row["ID"]));
						}
						DBFunctions.EW_GetAllPossibleEmissionsForUnits(unitType, list, dBConnection);
					}
					num++;
					if (num <= 7)
					{
						list.Clear();
						switch (num)
						{
						case 2:
							unitType = GlobalVariables.ActiveUnitType.Weapon;
							dataTable = Cache_Weapons_DT;
							continue;
						case 3:
							unitType = GlobalVariables.ActiveUnitType.Ship;
							dataTable = Cache_Ships_DT;
							continue;
						case 4:
							unitType = GlobalVariables.ActiveUnitType.Submarine;
							dataTable = Cache_Subs_DT;
							continue;
						case 5:
							unitType = GlobalVariables.ActiveUnitType.Facility;
							dataTable = Cache_Facilities_DT;
							continue;
						case 6:
							unitType = GlobalVariables.ActiveUnitType.Satellite;
							dataTable = Cache_Satellites_DT;
							continue;
						case 7:
							unitType = GlobalVariables.ActiveUnitType.Vehicle;
							dataTable = Cache_GroundUnits_DT;
							continue;
						default:
							continue;
						case 1:
							break;
						}
						break;
					}
					return;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	static DatabaseCache()
	{
		Class72.smethod_20();
	}
}
