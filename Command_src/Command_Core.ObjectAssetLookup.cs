using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ObjectAssetLookup
{
	private Dictionary<string, DataTable> dictionary_0;

	private bool bool_0;

	private Dictionary<string, DataTable> dictionary_1;

	private bool bool_1;

	private Dictionary<string, Dictionary<int, string>> dictionary_2;

	public ObjectAssetLookup()
	{
		dictionary_0 = new Dictionary<string, DataTable>();
		bool_0 = false;
		dictionary_1 = new Dictionary<string, DataTable>();
		bool_1 = false;
		dictionary_2 = new Dictionary<string, Dictionary<int, string>>();
		method_0();
	}

	private void method_0()
	{
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!bool_0 && FileExistsNative.FileExistsFast(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"))
			{
				dictionary_0.Add("Aircraft", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"));
				dictionary_0.Add("Ship", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 1));
				dictionary_0.Add("Submarine", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 2));
				dictionary_0.Add("Facility", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 3));
				dictionary_0.Add("Weapon", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 4));
				bool_0 = true;
			}
			if (!bool_1 && FileExistsNative.FileExistsFast(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls"))
			{
				dictionary_1.Add("Aircraft", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls"));
				dictionary_1.Add("Ship", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 1));
				dictionary_1.Add("Submarine", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 2));
				dictionary_1.Add("Facility", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 3));
				dictionary_1.Add("Weapon", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 4));
				bool_1 = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			MessageBox.Show(string.Format("Unable to read {0}", GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"));
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public string GetObjectMeshString(ActiveUnit theAU, Scenario theScen)
	{
		string value = "";
		Dictionary<int, string> value2 = null;
		bool flag = false;
		if (dictionary_2.TryGetValue(theScen.DBUsed, out value2))
		{
			flag = true;
			if (value2.TryGetValue(theAU.DBID, out value))
			{
				return value;
			}
		}
		string dBUsed = theScen.DBUsed;
		DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
		DBRecord dBRecordByHash = DBOps.GetDBRecordByHash(dBUsed, ref theResult, CheckLocalFileExists: false, CheckForTampering: false);
		try
		{
			switch (dBRecordByHash.DBID)
			{
			case 2:
			{
				DataTable dataTable2 = null;
				switch (theAU.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					dataTable2 = dictionary_1["Aircraft"];
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					dataTable2 = dictionary_1["Ship"];
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					dataTable2 = dictionary_1["Submarine"];
					break;
				case GlobalVariables.ActiveUnitType.Weapon:
					dataTable2 = dictionary_1["Weapon"];
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					value = "Spacecraft.Satellite.obj";
					break;
				case GlobalVariables.ActiveUnitType.Facility:
				case GlobalVariables.ActiveUnitType.Vehicle:
					dataTable2 = dictionary_1["Facility"];
					break;
				}
				if (theAU.IsSatellite || dataTable2 == null)
				{
					break;
				}
				string text2 = theAU.DBID.ToString();
				foreach (DataRow row in dataTable2.Rows)
				{
					if (Operators.CompareString(Conversions.ToString(row["DBID"]), text2, false) == 0)
					{
						value = Conversions.ToString(row["Mesh"]);
						break;
					}
				}
				break;
			}
			case 1:
			{
				DataTable dataTable = null;
				switch (theAU.UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					dataTable = dictionary_0["Aircraft"];
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					dataTable = dictionary_0["Ship"];
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					dataTable = dictionary_0["Submarine"];
					break;
				case GlobalVariables.ActiveUnitType.Weapon:
					dataTable = dictionary_0["Weapon"];
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					value = "Spacecraft.Satellite.obj";
					break;
				case GlobalVariables.ActiveUnitType.Facility:
				case GlobalVariables.ActiveUnitType.Vehicle:
					dataTable = dictionary_0["Facility"];
					break;
				}
				if (theAU.IsSatellite || dataTable == null)
				{
					break;
				}
				string text = theAU.DBID.ToString();
				foreach (DataRow row2 in dataTable.Rows)
				{
					if (Operators.CompareString(Conversions.ToString(row2["DBID"]), text, false) == 0)
					{
						value = Conversions.ToString(row2["Mesh"]);
						break;
					}
				}
				break;
			}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			value = "";
			ProjectData.ClearProjectError();
		}
		if (!flag)
		{
			value2 = new Dictionary<int, string>();
			dictionary_2.Add(theScen.DBUsed, value2);
		}
		value2.Add(theAU.DBID, value);
		return value;
	}

	static ObjectAssetLookup()
	{
		Class72.smethod_20();
	}
}
