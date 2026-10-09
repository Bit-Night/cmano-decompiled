using System;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.mdb2sq3;

public class SQLiteBackend : IDBBackEnd
{
	private string string_0;

	public SQLiteBackend()
	{
		string_0 = null;
		string location = Assembly.GetCallingAssembly().Location;
		string_0 = $"Data Source={Path.GetDirectoryName(location)}/converted.db";
	}

	public SQLiteBackend(string sourceDB)
	{
		string_0 = null;
		string_0 = $"Data Source={sourceDB}";
	}

	public override void CloneSchema(SchemaTablesMetaData schema)
	{
		try
		{
			using SQLiteConnection sQLiteConnection = new SQLiteConnection(string_0);
			sQLiteConnection.Open();
			foreach (TableMetaData table in schema.tables)
			{
				using SQLiteCommand sQLiteCommand = new SQLiteCommand();
				sQLiteCommand.CommandText = method_2(table);
				if (CommandLineParametersHelper.verbose)
				{
					Console.Out.WriteLine("{0}", sQLiteCommand.CommandText);
				}
				sQLiteCommand.Connection = sQLiteConnection;
				sQLiteCommand.ExecuteNonQuery();
			}
			sQLiteConnection.Close();
		}
		catch (SQLiteException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			SQLiteException ex2 = ex;
			Console.Out.WriteLine("Exception cloning schema: {0}", ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private bool method_0(ColumnMetaData columnMetaData_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Invalid comparison between Unknown and I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		OleDbType columnType = columnMetaData_0.columnType;
		int result;
		int result2;
		if ((int)columnType <= 72)
		{
			if (columnType - 7 <= 1)
			{
				result = 1;
				goto IL_0048;
			}
			if ((int)columnType != 11 && (int)columnType != 72)
			{
				result2 = 0;
				goto IL_0044;
			}
		}
		else if (columnType - 128 > 2)
		{
			if (columnType - 133 <= 2)
			{
				result = 1;
				goto IL_0048;
			}
			if (columnType - 200 > 5)
			{
				result2 = 0;
				goto IL_0044;
			}
		}
		result = 1;
		goto IL_0048;
		IL_0044:
		return (byte)result2 != 0;
		IL_0048:
		return (byte)result != 0;
	}

	private string method_1(ColumnMetaData columnMetaData_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected I4, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected I4, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		OleDbType columnType = columnMetaData_0.columnType;
		if ((int)columnType <= 72)
		{
			switch (columnType - 2)
			{
			default:
				if ((int)columnType == 64)
				{
					goto case 0;
				}
				if ((int)columnType == 72)
				{
					break;
				}
				goto IL_00ef;
			case 9:
				return "BOOLEAN";
			case 0:
			case 1:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
				return "INTEGER";
			case 6:
				break;
			case 5:
				goto IL_00e7;
			case 7:
			case 8:
			case 10:
			case 11:
			case 13:
				goto IL_00ef;
			case 2:
			case 3:
			case 4:
			case 12:
				goto IL_010c;
			}
		}
		else
		{
			switch (columnType - 128)
			{
			default:
				if (columnType - 200 <= 3)
				{
					break;
				}
				if (columnType - 204 <= 1)
				{
					goto case 0;
				}
				goto IL_00ef;
			case 0:
				return "BLOB";
			case 1:
			case 2:
				break;
			case 5:
			case 6:
			case 7:
				goto IL_00e7;
			case 4:
			case 8:
			case 9:
			case 10:
				goto IL_00ef;
			case 3:
			case 11:
				goto IL_010c;
			}
		}
		return "TEXT";
		IL_00e7:
		return "DATETIME";
		IL_00ef:
		throw new Exception(Conversions.ToString(Conversions.ToDouble("Unhandled MS Acess datatype: ") + (double)columnMetaData_0.columnType));
		IL_010c:
		return "DOUBLE";
	}

	private string method_2(TableMetaData tableMetaData_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = string.Empty;
		stringBuilder.Append("CREATE TABLE " + SchemaTablesMetaData.EscapeIdentifier(tableMetaData_0.tableName) + " (");
		int num = tableMetaData_0.columns.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			ColumnMetaData columnMetaData = tableMetaData_0.columns[i];
			stringBuilder.Append(SchemaTablesMetaData.EscapeIdentifier(columnMetaData.columnName));
			stringBuilder.Append(" ");
			stringBuilder.Append(method_1(columnMetaData));
			if (!columnMetaData.isNullable)
			{
				stringBuilder.Append(" NOT NULL");
			}
			if (columnMetaData.hasDefault)
			{
				stringBuilder.Append(" DEFAULT ");
				if (!method_0(columnMetaData))
				{
					stringBuilder.Append(columnMetaData.defaultValue);
				}
				else
				{
					stringBuilder.Append(SchemaTablesMetaData.EscapeIdentifier(columnMetaData.defaultValue));
				}
			}
			if (columnMetaData.hasForeignKey)
			{
				stringBuilder.Append($" REFERENCES {SchemaTablesMetaData.EscapeIdentifier(columnMetaData.fkTable)} ({SchemaTablesMetaData.EscapeIdentifier(columnMetaData.fkColumn)})");
			}
			if (columnMetaData.isPrimaryKey)
			{
				text = ((!string.IsNullOrEmpty(text)) ? $"{text},{SchemaTablesMetaData.EscapeIdentifier(columnMetaData.columnName)}" : SchemaTablesMetaData.EscapeIdentifier(columnMetaData.columnName));
			}
			if (i + 1 < tableMetaData_0.columns.Count || !string.IsNullOrEmpty(text))
			{
				stringBuilder.Append(", ");
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			stringBuilder.Append($"PRIMARY KEY({text})");
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	private void method_3(TableMetaData tableMetaData_0, SQLiteCommand sqliteCommand_0)
	{
		sqliteCommand_0.Parameters.Clear();
		foreach (ColumnMetaData column in tableMetaData_0.columns)
		{
			sqliteCommand_0.Parameters.Add(new SQLiteParameter($"@{SchemaTablesMetaData.HexString(column.columnName)}"));
		}
	}

	private void method_4(ColumnMetaData columnMetaData_0, SQLiteCommand sqliteCommand_0, DbDataReader dbDataReader_0)
	{
		string parameterName = $"@{SchemaTablesMetaData.HexString(columnMetaData_0.columnName)}";
		sqliteCommand_0.Parameters[parameterName].Value = RuntimeHelpers.GetObjectValue(dbDataReader_0[columnMetaData_0.columnName]);
	}

	private string method_5(TableMetaData tableMetaData_0)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		foreach (ColumnMetaData column in tableMetaData_0.columns)
		{
			text = $"{text}{SchemaTablesMetaData.EscapeIdentifier(column.columnName)},";
			text2 = $"{text2}@{SchemaTablesMetaData.HexString(column.columnName)},";
		}
		return $"INSERT INTO {SchemaTablesMetaData.EscapeIdentifier(tableMetaData_0.tableName)} ({text.Remove(text.Length - 1)}) VALUES ({text2.Remove(text2.Length - 1)})";
	}

	public override void DumpTable(TableMetaData table, DbDataReader reader)
	{
		SQLiteTransaction sQLiteTransaction = null;
		string arg = string.Empty;
		try
		{
			using SQLiteConnection sQLiteConnection = new SQLiteConnection(string_0);
			sQLiteConnection.Open();
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand())
			{
				sQLiteCommand.CommandText = method_5(table);
				sQLiteCommand.Connection = sQLiteConnection;
				method_3(table, sQLiteCommand);
				int location = 0;
				sQLiteTransaction = sQLiteConnection.BeginTransaction();
				while (reader.Read())
				{
					foreach (ColumnMetaData column in table.columns)
					{
						method_4(column, sQLiteCommand, reader);
					}
					arg = sQLiteCommand.CommandText;
					sQLiteCommand.ExecuteNonQuery();
					if (Math.Max(Interlocked.Increment(ref location), location - 1) % 100 == 0)
					{
						Console.Out.Write(".");
					}
				}
				sQLiteTransaction.Commit();
				Console.Out.WriteLine("done");
				Console.Out.WriteLine("Table dump complete, {0} records copied.", location);
			}
			sQLiteConnection.Close();
		}
		catch (SQLiteException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			SQLiteException ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			try
			{
				sQLiteTransaction?.Rollback();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			Console.Out.WriteLine("SQLite Exception dumping table {0} : {1}\n{2}", table.tableName, ex2.Message, arg);
			if (ex2 != null && ex2.Message != null)
			{
				throw ex2;
			}
			ProjectData.ClearProjectError();
		}
	}

	public override SchemaTablesMetaData QuerySchemaDefinition(string schema)
	{
		throw new NotImplementedException();
	}

	public override void QueryTableDefinition(TableMetaData table)
	{
		throw new NotImplementedException();
	}

	public override void DumpTableContents(TableMetaData table, IDBBackEnd target)
	{
		throw new NotImplementedException();
	}

	static SQLiteBackend()
	{
		Class72.smethod_20();
	}
}
