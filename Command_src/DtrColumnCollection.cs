using System;
using System.Collections.Generic;
using System.Data;

public sealed class DtrColumnCollection
{
	private readonly Dictionary<string, int> dictionary_0;

	private readonly Dictionary<string, Type> dictionary_1;

	public int Count => dictionary_0.Count;

	public DtrColumnCollection()
	{
		dictionary_0 = new Dictionary<string, int>();
		dictionary_1 = new Dictionary<string, Type>();
	}

	public Dictionary<string, int> GetColumnsIndexes()
	{
		return dictionary_0;
	}

	public bool Contains(string columnName)
	{
		return dictionary_0.ContainsKey(columnName);
	}

	public void Add(string columnName, Type columnType)
	{
		int count = dictionary_0.Count;
		if (!dictionary_0.ContainsKey(columnName))
		{
			dictionary_0.Add(columnName, count);
			dictionary_1.Add(columnName, columnType);
		}
	}

	public int GetIndex(string columnName)
	{
		return dictionary_0[columnName];
	}

	public void CreateColumns(DataTable dt)
	{
		foreach (KeyValuePair<string, Type> item in dictionary_1)
		{
			dt.Columns.Add(item.Key, item.Value);
		}
	}

	private static void smethod_0()
	{
		smethod_1(bool_0: false);
		smethod_1(bool_0: true);
		smethod_2();
		Console.ReadKey();
	}

	private static void smethod_1(bool bool_0)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("cInt", typeof(int));
		dataTable.Columns.Add("cString", typeof(string));
		dataTable.Columns.Add("cBool", typeof(bool));
		dataTable.Columns.Add("cDateTime", typeof(DateTime));
		int num;
		if (!bool_0)
		{
			num = 0;
		}
		else
		{
			dataTable.BeginLoadData();
			num = 0;
		}
		for (int i = num; i < 100000; i++)
		{
			dataTable.Rows.Add(dataTable.NewRow());
		}
		DateTime now = DateTime.Now;
		for (int j = 0; j < 100000; j++)
		{
			dataTable.Rows[j]["cInt"] = 1;
			dataTable.Rows[j]["cString"] = "Some string";
			dataTable.Rows[j]["cBool"] = true;
			dataTable.Rows[j]["cDateTime"] = now;
		}
		if (bool_0)
		{
			dataTable.EndLoadData();
		}
		Console.WriteLine("Filling DataTable" + ((!bool_0) ? "" : " with BeginLoadData/EndLoadData") + ": " + (DateTime.Now - now).TotalMilliseconds);
	}

	private static void smethod_2()
	{
		DataTableTyped dataTableTyped = new DataTableTyped();
		dataTableTyped.Columns.Add("cInt", typeof(int));
		dataTableTyped.Columns.Add("cString", typeof(string));
		dataTableTyped.Columns.Add("cBool", typeof(bool));
		dataTableTyped.Columns.Add("cDateTime", typeof(DateTime));
		for (int i = 0; i < 100000; i++)
		{
			dataTableTyped.Rows.Add(dataTableTyped.NewRow());
		}
		DateTime now = DateTime.Now;
		for (int j = 0; j < 100000; j++)
		{
			dataTableTyped.Rows[j]["cInt"] = 1;
			dataTableTyped.Rows[j]["cString"] = "Some string";
			dataTableTyped.Rows[j]["cBool"] = true;
			dataTableTyped.Rows[j]["cDateTime"] = now;
		}
		double totalMilliseconds = (DateTime.Now - now).TotalMilliseconds;
		Console.WriteLine("Filling DataTableTyped: " + totalMilliseconds);
		now = DateTime.Now;
		dataTableTyped.ToDataTable();
		double totalMilliseconds2 = (DateTime.Now - now).TotalMilliseconds;
		Console.WriteLine("Transforming DataTableTyped to DataTable: " + totalMilliseconds2);
		Console.WriteLine("Total filling and transforming: " + (totalMilliseconds + totalMilliseconds2));
	}

	static DtrColumnCollection()
	{
		Class72.smethod_20();
	}
}
