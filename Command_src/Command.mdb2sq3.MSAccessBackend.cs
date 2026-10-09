using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command.mdb2sq3;

public class MSAccessBackend : IDBBackEnd
{
	private string string_0;

	public MSAccessBackend()
	{
		string location = Assembly.GetCallingAssembly().Location;
		string_0 = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.GetDirectoryName(location)}\\initial.mdb;Persist Security Info=False;";
	}

	public MSAccessBackend(string sourceDB)
	{
		string_0 = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourceDB};Persist Security Info=False;";
	}

	public override SchemaTablesMetaData QuerySchemaDefinition(string schema)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0103: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		SchemaTablesMetaData schemaTablesMetaData = new SchemaTablesMetaData();
		schemaTablesMetaData.schemaName = schema;
		try
		{
			OleDbConnection val = new OleDbConnection(string_0);
			try
			{
				val.Open();
				using (DataTable dataTable = val.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4] { null, schema, null, "TABLE" }))
				{
					foreach (DataRow row in dataTable.Rows)
					{
						TableMetaData tableMetaData = new TableMetaData();
						tableMetaData.tableName = row[2].ToString();
						if (tableMetaData.tableName.Contains("Capabilities") || tableMetaData.tableName.Contains("Data") || tableMetaData.tableName.Contains("Enum"))
						{
							schemaTablesMetaData.AddTable(tableMetaData);
						}
					}
				}
				val.Close();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			OleDbException ex2 = ex;
			Console.Out.WriteLine("Exception fetching schema metadata: {0}", ((Exception)(object)ex2).Message);
			ProjectData.ClearProjectError();
		}
		return schemaTablesMetaData;
	}

	public override void QueryTableDefinition(TableMetaData table)
	{
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_0387: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			OleDbConnection val = new OleDbConnection(string_0);
			try
			{
				val.Open();
				using (DataTable dataTable = val.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[4] { null, null, table.tableName, null }))
				{
					foreach (DataRow row in dataTable.Rows)
					{
						ColumnMetaData columnMetaData = new ColumnMetaData();
						columnMetaData.columnName = row["COLUMN_NAME"].ToString();
						columnMetaData.columnDescription = row["DESCRIPTION"].ToString();
						columnMetaData.ordinalPosition = Convert.ToInt32(row["ORDINAL_POSITION"].ToString());
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["CHARACTER_MAXIMUM_LENGTH"])))
						{
							columnMetaData.maxCharSize = Convert.ToInt32(row["CHARACTER_MAXIMUM_LENGTH"].ToString());
						}
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["NUMERIC_PRECISION"])))
						{
							columnMetaData.numericPrecision = Convert.ToInt32(row["NUMERIC_PRECISION"].ToString());
						}
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["NUMERIC_SCALE"])))
						{
							columnMetaData.numericScale = Convert.ToInt32(row["NUMERIC_SCALE"].ToString());
						}
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["DATETIME_PRECISION"])))
						{
							columnMetaData.datetimePrecision = Convert.ToInt32(row["DATETIME_PRECISION"].ToString());
						}
						columnMetaData.hasDefault = Convert.ToBoolean(row["COLUMN_HASDEFAULT"].ToString());
						columnMetaData.defaultValue = row["COLUMN_DEFAULT"].ToString();
						columnMetaData.columnType = (OleDbType)row["DATA_TYPE"];
						columnMetaData.isNullable = Convert.ToBoolean(row["IS_NULLABLE"].ToString());
						table.AddColumn(columnMetaData);
					}
				}
				using (DataTable dataTable2 = val.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, new object[3] { null, null, table.tableName }))
				{
					foreach (DataRow row2 in dataTable2.Rows)
					{
						row2["PK_NAME"].ToString();
						string aColumnName = row2["COLUMN_NAME"].ToString();
						table.FindColumn(aColumnName).isPrimaryKey = true;
					}
				}
				using (DataTable dataTable3 = val.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, new object[6] { null, null, null, null, null, table.tableName }))
				{
					foreach (DataRow row3 in dataTable3.Rows)
					{
						string aColumnName2 = row3["FK_COLUMN_NAME"].ToString();
						ColumnMetaData columnMetaData2 = table.FindColumn(aColumnName2);
						columnMetaData2.hasForeignKey = true;
						columnMetaData2.fkColumn = row3["PK_COLUMN_NAME"].ToString();
						columnMetaData2.fkTable = row3["PK_TABLE_NAME"].ToString();
					}
				}
				val.Close();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			OleDbException ex2 = ex;
			Console.Out.WriteLine("Exception fetching metadata for table {0} : {1}", table.tableName, ((Exception)(object)ex2).Message);
			ProjectData.ClearProjectError();
		}
	}

	public override void DumpTableContents(TableMetaData table, IDBBackEnd target)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0077: Expected O, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		try
		{
			OleDbConnection val = new OleDbConnection(string_0);
			try
			{
				val.Open();
				OleDbCommand val2 = val.CreateCommand();
				try
				{
					val2.CommandText = $"SELECT * FROM [{table.tableName}]";
					OleDbDataReader val3 = val2.ExecuteReader();
					try
					{
						target.DumpTable(table, (DbDataReader)(object)val3);
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				val.Close();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			OleDbException ex2 = ex;
			Console.Out.WriteLine("MSAccess Exception dumping table {0} : {1}", table.tableName, ((Exception)(object)ex2).Message);
			ProjectData.ClearProjectError();
		}
	}

	public override void CloneSchema(SchemaTablesMetaData schema)
	{
		throw new NotImplementedException();
	}

	public override void DumpTable(TableMetaData table, DbDataReader reader)
	{
		throw new NotImplementedException();
	}

	static MSAccessBackend()
	{
		Class72.smethod_20();
	}
}
