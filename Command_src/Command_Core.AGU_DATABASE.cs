using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class AGU_DATABASE
{
	public static Dictionary<string, AggregateUnitTemplate> DB;

	public static DataTable DataTable;

	static AGU_DATABASE()
	{
		Class72.smethod_20();
		DB = new Dictionary<string, AggregateUnitTemplate>();
	}

	public static void smethod_0()
	{
		if (AGU_CONFIG.Instance.Enabled)
		{
			DB = new Dictionary<string, AggregateUnitTemplate>();
			string[] array = AggregateUnitTemplate.FetchAllTemplateFiles();
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(array[i]);
				DB.Add(fileNameWithoutExtension, AggregateUnitTemplate.LoadFromFile(fileNameWithoutExtension));
			}
		}
		smethod_1();
	}

	private static void smethod_1()
	{
		DataTable = new DataTable();
		DataTable.Columns.Add("ID");
		DataTable.Columns.Add("Name");
		DataTable.Columns.Add("type");
		DataTable.Columns.Add("category");
		DataTable.Columns.Add("LongName");
		DataTable.Columns.Add("OperatorCountry");
		DataTable.Columns.Add("Hypothetical");
		foreach (AggregateUnitTemplate value in DB.Values)
		{
			DataRow dataRow = DataTable.NewRow();
			dataRow["ID"] = value.NameAndID;
			dataRow["Name"] = value.NameAndID;
			dataRow["type"] = "AGU";
			dataRow["category"] = "";
			dataRow["LongName"] = value.NameAndID;
			dataRow["OperatorCountry"] = 0;
			dataRow["Hypothetical"] = false;
			DataTable.Rows.Add(dataRow);
		}
	}

	public static AggregateUnitTemplate GetTemplateByID(string ID)
	{
		AggregateUnitTemplate value = null;
		DB.TryGetValue(ID, out value);
		return value;
	}

	public static void AddToDatabase(AggregateUnitTemplate Template)
	{
		if (DB.ContainsKey(Template.NameAndID))
		{
			GameGeneral.WriteExceptionsToLog(new Exception("Template" + Template.NameAndID + " already exists in database"));
		}
		else
		{
			DB.Add(Template.NameAndID, Template);
		}
	}

	public static void AddToDatabase(AggregateGroundUnit AGU)
	{
		AddToDatabase(new AggregateUnitTemplate(AGU));
	}

	public static void RemoveFromDatabase(string ID)
	{
		if (DB.ContainsKey(ID))
		{
			DB.Remove(ID);
		}
		else
		{
			GameGeneral.WriteExceptionsToLog(new Exception("Template" + ID + " does not exist in database"));
		}
	}
}
