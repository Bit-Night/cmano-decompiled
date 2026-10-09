using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.mdb2sq3;

public class SchemaTablesMetaData
{
	public string schemaName;

	public List<TableMetaData> tables;

	public SchemaTablesMetaData()
	{
		tables = new List<TableMetaData>();
	}

	public void AddTable(TableMetaData table)
	{
		tables.Add(table);
	}

	public TableMetaData FindTable(string aTableName)
	{
		return method_0(aTableName, tables);
	}

	private TableMetaData method_0(string string_0, List<TableMetaData> list_0)
	{
		return list_0.Find([SpecialName] (TableMetaData candidate) => Operators.CompareString(candidate.tableName, string_0, true) == 0);
	}

	public static string EscapeIdentifier(string identifier)
	{
		return "'" + identifier.Replace("'", "''") + "'";
	}

	public static string HexString(string identifier)
	{
		string text = string.Empty;
		foreach (char c in identifier)
		{
			text = string.Format("{1}{0:x4}", c, text);
		}
		return text;
	}

	public void SortTablesByDependencies()
	{
		List<TableMetaData> list = new List<TableMetaData>();
		int num = 0;
		int num2 = -1;
		while (num != num2 && list.Count != tables.Count)
		{
			num2 = num;
			foreach (TableMetaData table in tables)
			{
				if (list.Contains(table))
				{
					continue;
				}
				bool flag = true;
				foreach (ColumnMetaData column in table.columns)
				{
					if (column.hasForeignKey && method_0(column.fkTable, list) == null)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(table);
				}
			}
			num = list.Count;
			Console.Out.WriteLine("Sort loop: candidates added: {0}", num - num2);
		}
		tables = list;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Schema: {schemaName}");
		stringBuilder.AppendLine("-----------------------------------");
		foreach (TableMetaData table in tables)
		{
			stringBuilder.AppendLine(table.ToString());
		}
		return stringBuilder.ToString();
	}

	static SchemaTablesMetaData()
	{
		Class72.smethod_20();
	}
}
