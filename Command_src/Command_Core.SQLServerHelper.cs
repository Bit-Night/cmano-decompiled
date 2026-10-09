using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public sealed class SQLServerHelper
{
	public SqlConnection theConnection;

	public SQLServerHelper(SqlConnection theConn)
	{
		theConnection = theConn;
	}

	public void ExecuteNonQuery(string string_0, bool CloseConnectionOnFinish = true)
	{
		method_0();
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			dbCommand.ExecuteNonQuery();
		}
		if (CloseConnectionOnFinish)
		{
			CloseConnection();
		}
	}

	internal SqlDataReader ExecuteReader(string string_0)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		method_0();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return (SqlDataReader)dbCommand.ExecuteReader();
	}

	internal DataTable ExecuteDataTable(string string_0)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		method_0();
		SqlDataReader val;
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			val = (SqlDataReader)dbCommand.ExecuteReader();
		}
		DataTable dataTable = new DataTable();
		int fieldCount = val.FieldCount;
		int num = fieldCount - 1;
		for (int i = 0; i <= num; i++)
		{
			dataTable.Columns.Add(val.GetName(i), val.GetFieldType(i));
		}
		while (val.Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int num2 = fieldCount - 1;
			for (int j = 0; j <= num2; j++)
			{
				dataRow[j] = RuntimeHelpers.GetObjectValue(val[j]);
			}
			dataTable.Rows.Add(dataRow);
		}
		val.Close();
		val = null;
		return dataTable;
	}

	internal string ExecuteScalar(string string_0)
	{
		method_0();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return Conversions.ToString(dbCommand.ExecuteScalar());
	}

	public void ExecuteCommand(SqlCommand theCommand)
	{
		method_0();
		theCommand.Connection = theConnection;
		theCommand.ExecuteNonQuery();
		CloseConnection();
	}

	public void ExecuteBulkCopy(DataTable theDT, string TableName)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		SqlBulkCopy val = new SqlBulkCopy(theConnection);
		try
		{
			val.DestinationTableName = TableName;
			try
			{
				val.WriteToServer(theDT);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				foreach (DataRow row in theDT.Rows)
				{
					InsertRowIntoSqlServerTable(row, TableName, theConnection);
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public void InsertRowIntoSqlServerTable(DataRow row, string tableName, SqlConnection connection)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		string text = $"INSERT INTO {tableName} VALUES (";
		int num = -1;
		foreach (DataColumn column in row.Table.Columns)
		{
			num++;
			if (num > 0)
			{
				text += $"'{RuntimeHelpers.GetObjectValue(row[column.ColumnName])}',";
			}
		}
		text = text.TrimEnd(new char[1] { ',' }) + ")";
		SqlCommand val = new SqlCommand(text, connection);
		try
		{
			val.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ex2.Data.Add("SQL-Insert command", val.CommandText);
			GameGeneral.WriteExceptionsToLog(ex2);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void method_0()
	{
		if (theConnection.State == ConnectionState.Closed)
		{
			theConnection.Open();
		}
	}

	public void CloseConnection()
	{
		if (theConnection.State == ConnectionState.Open)
		{
			theConnection.Close();
		}
	}

	public static string SQLSafeString(string myString)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		stringBuilder.Clear();
		stringBuilder.Append(myString);
		string result = stringBuilder.Replace("'", "''").Replace("`", "''").ToString();
		StringBuilderCache.Free(stringBuilder);
		return result;
	}

	public static string MakeSQLDateString_YYYYMMDD(DateTime theDate)
	{
		return string.Concat(str2: (Strings.Len(theDate.Day.ToString()) != 1) ? theDate.Day.ToString() : ("0" + theDate.Day), str1: (Strings.Len(theDate.Month.ToString()) != 1) ? theDate.Month.ToString() : ("0" + theDate.Month), str0: Conversions.ToString(theDate.Year));
	}

	public static string MakeSQLDateString_DDMMYYYY(DateTime theDate)
	{
		string text = ((Strings.Len(theDate.Day.ToString()) != 1) ? theDate.Day.ToString() : ("0" + theDate.Day));
		string text2;
		int num;
		if (Strings.Len(theDate.Month.ToString()) == 1)
		{
			text2 = "0" + theDate.Month;
			num = 5;
		}
		else
		{
			text2 = theDate.Month.ToString();
			num = 5;
		}
		string[] array = new string[num];
		array[0] = text;
		array[1] = "/";
		array[2] = text2;
		array[3] = "/";
		array[4] = Conversions.ToString(theDate.Year);
		return string.Concat(array);
	}

	static SQLServerHelper()
	{
		Class72.smethod_20();
	}
}
