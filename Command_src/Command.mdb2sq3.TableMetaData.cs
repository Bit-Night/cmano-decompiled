using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.mdb2sq3;

public class TableMetaData
{
	public string tableName;

	public List<ColumnMetaData> columns;

	public TableMetaData()
	{
		columns = new List<ColumnMetaData>();
	}

	public void AddColumn(ColumnMetaData col)
	{
		columns.Add(col);
		columns.Sort(ColumnMetaData.CompareColumnOrder);
	}

	public ColumnMetaData FindColumn(string aColumnName)
	{
		return columns.Find([SpecialName] (ColumnMetaData candidate) => Operators.CompareString(candidate.columnName, aColumnName, true) == 0);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Table: {tableName}");
		stringBuilder.AppendLine("===================================");
		foreach (ColumnMetaData column in columns)
		{
			stringBuilder.AppendLine(column.ToString());
		}
		return stringBuilder.ToString();
	}

	static TableMetaData()
	{
		Class72.smethod_20();
	}
}
