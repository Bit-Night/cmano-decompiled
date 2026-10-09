using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;

namespace PlaneDisaster.Dba;

public abstract class dba : IDisposable
{
	private DbConnection dbConnection_0;

	public bool Connected
	{
		get
		{
			if (Cn != null)
			{
				return Cn.State == ConnectionState.Open;
			}
			return false;
		}
	}

	protected virtual DbConnection Cn
	{
		get
		{
			return dbConnection_0;
		}
		set
		{
			dbConnection_0 = value;
		}
	}

	public string ConnectionString => Cn.ConnectionString;

	public abstract bool IsAccessDatabase { get; }

	public abstract bool SupportsProcedures { get; }

	public abstract bool SupportsViews { get; }

	protected abstract DataAdapter CreateDataAdapter(DbCommand cmd);

	public void CreateProcedure(string Name, string SQL)
	{
		CreateProcedure(Name, SQL, ReplaceQuery: true);
	}

	public void CreateProcedure(string Name, string SQL, bool ReplaceQuery)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		if (ReplaceQuery)
		{
			try
			{
				dbCommand.CommandText = $"DROP PROCEDURE {Name}";
				dbCommand.ExecuteNonQuery();
			}
			catch (DbException)
			{
			}
		}
		dbCommand.CommandText = $"CREATE PROCEDURE {Name} AS {SQL}";
		dbCommand.ExecuteNonQuery();
	}

	public void CreateView(string Name, string SQL)
	{
		CreateView(Name, SQL, ReplaceQuery: true);
	}

	public void CreateView(string Name, string SQL, bool ReplaceQuery)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		if (ReplaceQuery)
		{
			try
			{
				dbCommand.CommandText = $"DROP VIEW {Name}";
				dbCommand.ExecuteNonQuery();
			}
			catch (DbException)
			{
			}
		}
		dbCommand.CommandText = $"CREATE VIEW {Name} AS {SQL}";
		dbCommand.ExecuteNonQuery();
	}

	public void DropProcedure(string Name)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		dbCommand.CommandText = $"DROP PROCEDURE {Name}";
		dbCommand.ExecuteNonQuery();
	}

	public void DropTable(string Name)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		dbCommand.CommandText = $"DROP TABLE {Name}";
		dbCommand.ExecuteNonQuery();
	}

	public void DropView(string Name)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		dbCommand.CommandText = $"DROP VIEW {Name}";
		dbCommand.ExecuteNonQuery();
	}

	public void Disconnect()
	{
		Cn.Close();
	}

	public void Dispose()
	{
		Cn.Dispose();
	}

	public DataTable ExecuteScript(string SQL)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		SQL = SQL.Trim();
		SQL = SQL.TrimEnd(new char[1] { ';' });
		string[] array = rcleaHfhew3(SQL);
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (array[i] != "")
			{
				dbCommand.CommandText = array[i];
				dbCommand.ExecuteNonQuery();
			}
		}
		dbCommand.Dispose();
		return GetSqlAsDataTable(array[^1]);
	}

	public void ExecuteSqlCommand(string SQL)
	{
		using DbCommand dbCommand = Cn.CreateCommand();
		dbCommand.CommandText = SQL;
		dbCommand.ExecuteNonQuery();
	}

	public virtual void ExecuteSqlCommand(string SQL, DbParameter[] parameters)
	{
		using DbCommand dbCommand = Cn.CreateCommand();
		dbCommand.CommandText = SQL;
		dbCommand.Parameters.AddRange(parameters);
		dbCommand.ExecuteNonQuery();
	}

	public DataTable ExecuteSqlFile(string Script)
	{
		return ExecuteScript(File.ReadAllText(Script));
	}

	public virtual string[] GetColumnAsStringArray(string Table, string Col, bool Distinct)
	{
		ArrayList arrayList = new ArrayList();
		DbCommand dbCommand;
		using (dbCommand = Cn.CreateCommand())
		{
			arrayList = new ArrayList();
			string commandText = (Distinct ? string.Format("SELECT DISTINCT [{1}] FROM [{0}]", Table, Col) : string.Format("SELECT [{1}] FROM [{0}]", Table, Col));
			dbCommand.CommandText = commandText;
			DbDataReader dbDataReader = dbCommand.ExecuteReader();
			while (dbDataReader.Read())
			{
				arrayList.Add(dbDataReader[Col].ToString());
			}
			dbDataReader.Close();
			dbDataReader.Dispose();
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	public string[] GetColumnAsStringArray(string Table, string Col)
	{
		return GetColumnAsStringArray(Table, Col, Distinct: false);
	}

	public abstract string[] GetColumnNames(string Table);

	public DataTable GetColumnSchema(string Object)
	{
		string[] restrictionValues = new string[4] { null, null, Object, null };
		return Cn.GetSchema("Columns", restrictionValues);
	}

	public virtual string[] GetProcedures()
	{
		int num = 0;
		DataTable dataTable = null;
		dataTable = Cn.GetSchema("procedures");
		int count = dataTable.Rows.Count;
		string[] array = new string[count];
		for (num = 0; num < count; num++)
		{
			array[num] = (string)dataTable.Rows[num]["PROCEDURE_NAME"];
		}
		return array;
	}

	public virtual string GetProcedureSQL(string Procedure)
	{
		return (string)Cn.GetSchema("Procedures", new string[4] { null, null, Procedure, null }).Rows[0]["PROCEDURE_DEFINITION"];
	}

	public virtual DataTable GetSchema()
	{
		return Cn.GetSchema();
	}

	public virtual DataTable GetSchema(string Collection)
	{
		return Cn.GetSchema(Collection);
	}

	public string method_0(string SQL)
	{
		return method_1(SQL, ",");
	}

	public string method_1(string SQL, string Seperator)
	{
		DbCommand dbCommand = Cn.CreateCommand();
		dbCommand.CommandText = SQL;
		StringBuilder stringBuilder = new StringBuilder();
		DbDataReader dbDataReader = dbCommand.ExecuteReader();
		int fieldCount = dbDataReader.FieldCount;
		string[] array = new string[fieldCount];
		for (int i = 0; i < fieldCount; i++)
		{
			array[i] = dbDataReader.GetName(i);
			stringBuilder.AppendFormat("{0}{1}", array[i], Seperator);
		}
		stringBuilder.AppendLine();
		while (dbDataReader.Read())
		{
			string[] array2 = array;
			foreach (string name in array2)
			{
				stringBuilder.AppendFormat("{0}{1}", dbDataReader[name], Seperator);
			}
			stringBuilder.AppendLine();
		}
		dbDataReader.Close();
		return stringBuilder.ToString();
	}

	public DbDataReader GetSqlAsDataReader(string SQL)
	{
		DbCommand dbCommand;
		using (dbCommand = Cn.CreateCommand())
		{
			dbCommand.CommandText = SQL;
			return dbCommand.ExecuteReader();
		}
	}

	public virtual DataTable GetSqlAsDataTable(string SQL)
	{
		DataSet dataSet = new DataSet();
		DbCommand dbCommand;
		using (dbCommand = Cn.CreateCommand())
		{
			dbCommand.CommandText = SQL;
			CreateDataAdapter(dbCommand).Fill(dataSet);
		}
		if (dataSet.Tables.Count != 0)
		{
			return dataSet.Tables[0];
		}
		return null;
	}

	public DataTable GetSqlAsDataTable(string SQL, string TableName)
	{
		DataTable sqlAsDataTable = GetSqlAsDataTable(SQL);
		sqlAsDataTable.TableName = TableName;
		return sqlAsDataTable;
	}

	public virtual DataTable GetSqlAsDataTable(string SQL, DbParameter[] Parameters)
	{
		DataSet dataSet = new DataSet();
		DbCommand dbCommand;
		using (dbCommand = Cn.CreateCommand())
		{
			dbCommand.CommandText = SQL;
			dbCommand.Parameters.AddRange(Parameters);
			CreateDataAdapter(dbCommand).Fill(dataSet);
		}
		return dataSet.Tables[0];
	}

	public string GetStatus()
	{
		return Cn.ConnectionString + "\n" + Cn.State;
	}

	public string GetTableAsCSV(string Table)
	{
		return method_0($"SELECT * FROM [{Table}]");
	}

	public virtual DataTable GetTableAsDataTable(string Table)
	{
		return GetSqlAsDataTable($"SELECT * FROM [{Table}]");
	}

	public virtual int GetTableRowCount(string Table)
	{
		IDbCommand dbCommand;
		using (dbCommand = Cn.CreateCommand())
		{
			dbCommand.CommandText = $"SELECT COUNT(*) FROM [{Table}]";
			IDataReader dataReader = dbCommand.ExecuteReader();
			dataReader.Read();
			int result;
			try
			{
				result = (int)dataReader[0];
			}
			catch (InvalidCastException)
			{
				result = int.Parse(dataReader[0].ToString());
			}
			dataReader.Close();
			return result;
		}
	}

	public virtual string[] GetTables()
	{
		int num = 0;
		DataTable dataTable = null;
		dataTable = Cn.GetSchema("tables");
		int count = dataTable.Rows.Count;
		string[] array = new string[count];
		for (num = 0; num < count; num++)
		{
			array[num] = (string)dataTable.Rows[num]["TABLE_NAME"];
		}
		return array;
	}

	public string[] GetViews()
	{
		int num = 0;
		DataTable dataTable = null;
		dataTable = Cn.GetSchema("views");
		int count = dataTable.Rows.Count;
		string[] array = new string[count];
		for (num = 0; num < count; num++)
		{
			array[num] = (string)dataTable.Rows[num]["TABLE_NAME"];
		}
		return array;
	}

	public virtual string vmethod_0(string View)
	{
		return (string)Cn.GetSchema("Views", new string[3] { null, null, View }).Rows[0]["VIEW_DEFINITION"];
	}

	public string SerializeQuery(string SQL)
	{
		return GetSqlAsDataTable(SQL).DataSet.GetXml();
	}

	public void SerializeQuery(string SQL, string File)
	{
		GetSqlAsDataTable(SQL).DataSet.WriteXml(File, XmlWriteMode.WriteSchema);
	}

	public string SerializeTable(string Table)
	{
		string sQL = "SELECT * FROM " + Table;
		return SerializeQuery(sQL);
	}

	public void SerializeTable(string Table, string File)
	{
		string sQL = "SELECT * FROM " + Table;
		SerializeQuery(sQL, File);
	}

	private string[] rcleaHfhew3(string string_0)
	{
		string_0 = string_0.TrimEnd(new char[1] { ';' });
		return string_0.Split(new char[1] { ';' });
	}

	public static string DataTable2CSV(DataTable dt)
	{
		return DataTable2CSV(dt, ",");
	}

	public static string DataTable2CSV(DataTable dt, string Seperator)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int count = dt.Columns.Count;
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = dt.Columns[i].ColumnName;
			stringBuilder.AppendFormat("{0}{1}", array[i], Seperator);
		}
		stringBuilder.AppendLine();
		foreach (DataRow row in dt.Rows)
		{
			string[] array2 = array;
			foreach (string columnName in array2)
			{
				stringBuilder.AppendFormat("{0}{1}", row[columnName], Seperator);
			}
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public static string DataTable2DML(DataTable dt)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		int count = dt.Columns.Count;
		string[] array = new string[count];
		string[] array2 = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = dt.Columns[i].ColumnName;
		}
		stringBuilder2.AppendFormat("INSERT INTO [{0}] ([{1}]) VALUES(", dt.TableName, string.Join("], [", array));
		for (int j = 0; j < count - 1; j++)
		{
			stringBuilder2.AppendFormat("'{{{0}}}', ", j);
		}
		stringBuilder2.AppendFormat("'{{{0}}}');", count - 1);
		foreach (DataRow row in dt.Rows)
		{
			for (int k = 0; k < count; k++)
			{
				array2[k] = row[array[k]].ToString();
			}
			string format = stringBuilder2.ToString();
			object[] args = array2;
			stringBuilder.AppendFormat(format, args);
			stringBuilder.AppendLine();
		}
		return stringBuilder.ToString();
	}

	public static string[] GetColumnAsStringArray(DataTable Table, string Column)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DataRow row in Table.Rows)
		{
			arrayList.Add(row[Column].ToString());
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	public static string[] GetColumnAsStringArray(DataTable Table, string Column, bool Distinct)
	{
		if (!Distinct)
		{
			return GetColumnAsStringArray(Table, Column);
		}
		List<string> list = new List<string>();
		foreach (DataRow row in Table.Rows)
		{
			string item = (string)row[Column];
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}
		list.Sort();
		return list.ToArray();
	}

	static dba()
	{
		Class72.smethod_20();
	}
}
