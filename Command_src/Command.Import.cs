using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
public sealed class Import
{
	private static List<string> list_0;

	private static List<string> list_1;

	private static List<string> list_2;

	private static List<string> list_3;

	private static List<string> list_4;

	private static List<string> list_5;

	private static List<string> list_6;

	private static List<string> list_7;

	private static List<string> list_8;

	private static List<string> list_9;

	private static List<string> list_10;

	private static List<string> list_11;

	private static List<string> list_12;

	private static List<string> list_13;

	private static List<string> list_14;

	private static List<string> GnovUomjss;

	private static List<string> list_15;

	private static List<string> list_16;

	private static List<string> uTcvzyrlk6;

	private static List<List<string>> list_17;

	private static List<List<string>> list_18;

	static Import()
	{
		Class72.smethod_20();
		list_0 = new List<string>(new string[11]
		{
			"DataSensor", "DataSensorCapabilities", "DataSensorCodes", "DataSensorFrequencyIlluminate", "DataSensorFrequencySearchAndTrack", "DataSensorSensorGroups", "MiscSensor", "MiscSensorDefault", "MiscSensorRangeCalculated", "MiscSensorStatStatus",
			"TextSensor"
		});
		list_1 = new List<string>(new string[5] { "DataPropulsion", "DataPropulsionPerformance", "MiscPropulsion", "MiscPropulsionPerformance", "TextPropulsion" });
		list_2 = new List<string>(new string[3] { "DataFuel", "MiscFuel", "TextFuel" });
		list_3 = new List<string>(new string[3] { "DataAircraftFacility", "MiscAircraftFacility", "TextAircraftFacility" });
		list_4 = new List<string>(new string[3] { "DataDockingFacility", "MiscDockingFacility", "TextDockingFacility" });
		list_5 = new List<string>(new string[3] { "DataWarhead", "MiscWarhead", "TextWarhead" });
		list_6 = new List<string>(new string[5] { "DataComm", "DataCommCapabilities", "DataCommDirectors", "MiscComm", "TextComm" });
		list_7 = new List<string>(new string[16]
		{
			"DataWeapon", "DataWeaponCodes", "DataWeaponComms", "DataWeaponDirectors", "DataWeaponFuel", "DataWeaponPropulsion", "DataWeaponSensors", "DataWeaponSignatures", "DataWeaponTargets", "DataWeaponWarheads",
			"DataWeaponWRA", "MiscWeapon", "TextWeapon", "DataWeaponRecord", "MiscWeaponRecord", "TextWeaponRecord"
		});
		list_8 = new List<string>(new string[3] { "DataWeaponRecord", "MiscWeaponRecord", "TextWeaponRecord" });
		list_9 = new List<string>(new string[9] { "DataMount", "DataMountComms", "DataMountDirectors", "DataMountMagazineWeapons", "DataMountSensors", "DataMountWeapons", "MiscMount", "MiscMountDefault", "TextMount" });
		list_10 = new List<string>(new string[4] { "DataMagazine", "DataMagazineWeapons", "MiscMagazine", "TextMagazine" });
		list_11 = new List<string>(new string[4] { "DataLoadout", "DataLoadoutWeapons", "MiscLoadout", "TextLoadout" });
		list_12 = new List<string>(new string[11]
		{
			"DataAircraft", "DataAircraftCodes", "DataAircraftComms", "DataAircraftFuel", "DataAircraftLoadouts", "DataAircraftMounts", "DataAircraftPropulsion", "DataAircraftSensors", "DataAircraftSignatures", "MiscAircraft",
			"TextAircraft"
		});
		list_13 = new List<string>(new string[11]
		{
			"DataFacility", "DataFacilityAircraftFacilities", "DataFacilityComms", "DataFacilityDockingFacilities", "DataFacilityFuel", "DataFacilityMagazines", "DataFacilityMounts", "DataFacilitySensors", "DataFacilitySignatures", "MiscFacility",
			"TextFacility"
		});
		list_14 = new List<string>(new string[13]
		{
			"DataGroundUnit", "DataGroundUnitAircraftFacilities", "DataGroundUnitComms", "DataGroundUnitCodes", "DataGroundUnitDockingFacilities", "DataGroundUnitFuel", "DataGroundUnitMagazines", "DataGroundUnitMounts", "DataGroundUnitPropulsion", "DataGroundUnitSensors",
			"DataGroundUnitSignatures", "MiscGroundUnit", "TextGroundUnit"
		});
		GnovUomjss = new List<string>(new string[13]
		{
			"DataShip", "DataShipAircraftFacilities", "DataShipCodes", "DataShipComms", "DataShipDockingFacilities", "DataShipFuel", "DataShipMagazines", "DataShipMounts", "DataShipPropulsion", "DataShipSensors",
			"DataShipSignatures", "MiscShip", "TextShip"
		});
		list_15 = new List<string>(new string[13]
		{
			"DataSubmarine", "DataSubmarineAircraftFacilities", "DataSubmarineCodes", "DataSubmarineComms", "DataSubmarineDockingFacilities", "DataSubmarineFuel", "DataSubmarineMagazines", "DataSubmarineMounts", "DataSubmarinePropulsion", "DataSubmarineSensors",
			"DataSubmarineSignatures", "MiscSubmarine", "TextSubmarine"
		});
		list_16 = new List<string>(new string[9] { "DataSatellite", "DataSatelliteCodes", "DataSatelliteComms", "DataSatelliteMounts", "DataSatelliteOrbits", "DataSatelliteSensors", "DataSatelliteSignatures", "MiscSatellite", "TextSatellite" });
		uTcvzyrlk6 = new List<string>(new string[3] { "DataContainer", "MiscContainer", "TextContainer" });
		list_17 = new List<List<string>>
		{
			list_0, list_1, list_2, list_3, list_4, list_5, list_6, list_7, list_8, list_9,
			list_10, list_11
		};
		list_18 = new List<List<string>> { list_12, list_13, list_14, GnovUomjss, list_15, list_16, uTcvzyrlk6 };
	}

	public static void DeleteAllDataTableContent(ref Database theDatabase, MSAccessHelper theMSAccessHelper)
	{
		foreach (TableDef tableDef in theDatabase.TableDefs)
		{
			if ((Operators.CompareString(Strings.Left(tableDef.Name, 4), "Data", true) == 0) | (Operators.CompareString(Strings.Left(tableDef.Name, 4), "Misc", true) == 0) | (Operators.CompareString(Strings.Left(tableDef.Name, 4), "Text", true) == 0))
			{
				Common.DeleteTableContent(theMSAccessHelper, tableDef.Name);
			}
		}
	}

	private static void smethod_0()
	{
		List<string> list = new List<string>(new string[6] { "DataAircraft", "DataFacility", "DataSatellite", "DataShip", "DataSubmarine", "DataWeapon" });
		List<string> list2 = new List<string>(new string[2] { "3DMesh", "SymbolMesh" });
		foreach (string item in list)
		{
			foreach (string item2 in list2)
			{
				if (Common.DoesTableColumnExist(ref Common.theSourceDB, item, item2))
				{
					Common.mySourceDB_Helper.ExecuteNonQuery("ALTER TABLE [" + Common.theSourceMsAccessFileName + "]." + item + " DROP COLUMN " + item2 + ";");
				}
			}
		}
	}

	private static void smethod_1(List<string> list_19)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		foreach (string item in list_19)
		{
			try
			{
				Common.myTargetDB_Helper.ExecuteNonQuery("Insert into " + item + " SELECT * From [" + Common.theSourceMsAccessFileName + "]." + item);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				Interaction.MsgBox((object)("There is a problem with " + item + ":\\n\\n" + ex2.Message), (MsgBoxStyle)0, (object)null);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void DoImportDatabase()
	{
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		DeleteAllDataTableContent(ref Common.theTargetDB, Common.myTargetDB_Helper);
		if (Conversions.ToInteger(Common.get_Capabilities(Common.mySourceDB_Helper).Select("ID = Max(ID)")[0]["ID"]) >= 5L)
		{
			smethod_0();
			Common.theSourceDB.TableDefs.Refresh();
			Common.RemoveAllNulls(ref Common.theSourceDB, Common.mySourceDB_Helper);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			foreach (List<string> item in list_17)
			{
				foreach (string item2 in item)
				{
					if (!dictionary.ContainsKey(item2))
					{
						dictionary.Add(item2, item2);
					}
				}
			}
			foreach (List<string> item3 in list_18)
			{
				foreach (string item4 in item3)
				{
					if (!dictionary.ContainsKey(item4))
					{
						dictionary2.Add(item4, item4);
					}
				}
			}
			smethod_1(dictionary.Keys.ToList());
			smethod_1(dictionary2.Keys.ToList());
			string text = "Description";
			string text2 = "Description";
			string text3 = "EnumCommType";
			if (Common.DoesTableExist(ref Common.theSourceDB, "DataCommType"))
			{
				text3 = "DataCommType";
				text = "Name";
			}
			string text4 = "EnumCommType";
			if (Common.DoesTableExist(ref Common.theTargetDB, "DataCommType"))
			{
				text4 = "DataCommType";
				text2 = "Name";
			}
			Common.DeleteTableContent(Common.myTargetDB_Helper, text4);
			DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable("SELECT ID," + text + " FROM " + text3);
			if (Operators.CompareString(text3, text4, true) != 0)
			{
				foreach (object row in dataTable.Rows)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(row);
					Common.myTargetDB_Helper.ExecuteNonQuery(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + text4 + " (ID," + text2 + ") VALUES ("), NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)), Operators.AddObject(Operators.AddObject((object)",'", NewLateBinding.LateIndexGet(objectValue, new object[1] { text }, (string[])null)), (object)"')"))));
				}
			}
			else
			{
				try
				{
					Common.myTargetDB_Helper.ExecuteNonQuery("Insert into " + text4 + " SELECT * From [" + Common.theSourceMsAccessFileName + "]." + text3);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ErrorManagement.EnqueueErrorMessage(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					Interaction.MsgBox((object)("There is a problem with " + text4 + " :\\n\\n" + ex2.Message), (MsgBoxStyle)0, (object)null);
					ProjectData.ClearProjectError();
				}
			}
			if (Operators.CompareString(text4, "DataCommType", true) != 0)
			{
				return;
			}
			Common.DeleteTableContent(Common.myTargetDB_Helper, "MiscCommType");
			Common.DeleteTableContent(Common.myTargetDB_Helper, "TextCommType");
			{
				foreach (object row2 in dataTable.Rows)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(row2);
					Common.myTargetDB_Helper.ExecuteNonQuery(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO MiscCommType (ID,FullName) VALUES (", NewLateBinding.LateIndexGet(objectValue2, new object[1] { "ID" }, (string[])null)), Operators.AddObject(Operators.AddObject((object)",'", NewLateBinding.LateIndexGet(objectValue2, new object[1] { text }, (string[])null)), (object)"')"))));
					Common.myTargetDB_Helper.ExecuteNonQuery(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TextCommType (ID) VALUES (", NewLateBinding.LateIndexGet(objectValue2, new object[1] { "ID" }, (string[])null)), (object)")")));
				}
				return;
			}
		}
		Interaction.MsgBox((object)"The source database is too old! Aborting...", (MsgBoxStyle)0, (object)null);
	}
}
