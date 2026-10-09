using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

public sealed class DataTableTyped : IEnumerable<IEnumerable<object>>, IEnumerable
{
	private readonly DtrColumnCollection dtrColumnCollection_0;

	private readonly DtrRowCollection dtrRowCollection_0;

	public DtrColumnCollection Columns => dtrColumnCollection_0;

	public DtrRowCollection Rows => dtrRowCollection_0;

	public DataTableTyped()
	{
		dtrColumnCollection_0 = new DtrColumnCollection();
		dtrRowCollection_0 = new DtrRowCollection();
	}

	public DtrRow NewRow()
	{
		return new DtrRow(this);
	}

	public DataTable ToDataTable()
	{
		DataTable dataTable = new DataTable();
		dataTable.BeginLoadData();
		dtrColumnCollection_0.CreateColumns(dataTable);
		dtrRowCollection_0.CreateRows(dataTable);
		dataTable.EndLoadData();
		return dataTable;
	}

	public DtrRow[] Select(string filterExpression)
	{
		if (Rows.Count() == 0)
		{
			return Array.Empty<DtrRow>();
		}
		DataTable dataTable = new DataTable();
		dataTable.BeginLoadData();
		dataTable.Columns.Add("__RowIndex__", typeof(int));
		dtrColumnCollection_0.CreateColumns(dataTable);
		List<DtrRow> list = new List<DtrRow>(dtrRowCollection_0);
		for (int i = 0; i < list.Count; i++)
		{
			object[] array = list[i].ToArray();
			object[] array2 = new object[array.Length + 1];
			array2[0] = i;
			Array.Copy(array, 0, array2, 1, array.Length);
			dataTable.Rows.Add(array2);
		}
		dataTable.EndLoadData();
		DataRow[] array3 = dataTable.Select(filterExpression);
		DtrRow[] array4 = new DtrRow[array3.Length];
		for (int j = 0; j < array3.Length; j++)
		{
			int index = (int)array3[j]["__RowIndex__"];
			array4[j] = list[index];
		}
		return array4;
	}

	public IEnumerator<IEnumerable<object>> GetEnumerator()
	{
		foreach (DtrRow item in dtrRowCollection_0)
		{
			yield return item.ToArray();
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	static DataTableTyped()
	{
		Class72.smethod_20();
	}
}
