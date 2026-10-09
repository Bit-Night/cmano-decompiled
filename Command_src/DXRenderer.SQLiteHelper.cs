using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using System.Text;

namespace DXRenderer;

public sealed class SQLiteHelper
{
	public SQLiteConnection theConnection;

	private static Dictionary<Type, string> dictionary_0;

	public SQLiteHelper(SQLiteConnection theConn)
	{
		theConnection = theConn;
	}

	public void ExecuteNonQuery(string string_0, bool CloseConnectionOnFinish = true)
	{
		OpenConnection();
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

	public SQLiteDataReader ExecuteReader(string string_0)
	{
		OpenConnection();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return (SQLiteDataReader)dbCommand.ExecuteReader();
	}

	public DataTable ExecuteDataTable(string string_0)
	{
		OpenConnection();
		DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		SQLiteDataReader sQLiteDataReader = (SQLiteDataReader)dbCommand.ExecuteReader();
		DataTable dataTable = new DataTable();
		int fieldCount = sQLiteDataReader.FieldCount;
		int i = 0;
		for (int num = fieldCount - 1; i <= num; i++)
		{
			dataTable.Columns.Add(sQLiteDataReader.GetName(i), sQLiteDataReader.GetFieldType(i));
		}
		while (sQLiteDataReader.Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int j = 0;
			for (int num2 = fieldCount - 1; j <= num2; j++)
			{
				dataRow[j] = sQLiteDataReader[j];
			}
			dataTable.Rows.Add(dataRow);
		}
		dbCommand.Cancel();
		dbCommand.Dispose();
		sQLiteDataReader.Close();
		sQLiteDataReader = null;
		return dataTable;
	}

	public string ExecuteScalar(string string_0, bool closeConnection)
	{
		OpenConnection();
		string result;
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			result = dbCommand.ExecuteScalar().ToString();
		}
		if (closeConnection)
		{
			CloseConnection();
		}
		return result;
	}

	public void ExecuteCommand(SQLiteCommand theCommand)
	{
		OpenConnection();
		theCommand.Connection = theConnection;
		theCommand.ExecuteNonQuery();
		CloseConnection();
	}

	public void OpenConnection()
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

	public static string TimeToString(DateTime theTime)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(theTime.Year);
		stringBuilder.Append("-");
		stringBuilder.Append(smethod_0(theTime.Month.ToString()));
		stringBuilder.Append("-");
		stringBuilder.Append(smethod_0(theTime.Day.ToString()));
		stringBuilder.Append(" ");
		stringBuilder.Append(smethod_0(theTime.Hour.ToString()));
		stringBuilder.Append(":");
		stringBuilder.Append(smethod_0(theTime.Minute.ToString()));
		stringBuilder.Append(":");
		stringBuilder.Append(smethod_0(theTime.Second.ToString()));
		return stringBuilder.ToString();
	}

	private static string smethod_0(string string_0)
	{
		if (string_0.Length == 1)
		{
			return "0" + string_0;
		}
		return string_0;
	}

	[SpecialName]
	private static Dictionary<Type, string> smethod_1()
	{
		if (dictionary_0 == null)
		{
			dictionary_0 = new Dictionary<Type, string>();
			dictionary_0.Add(typeof(int), "INTEGER");
			dictionary_0.Add(typeof(string), "TEXT");
			dictionary_0.Add(typeof(bool), "INTEGER");
			dictionary_0.Add(typeof(DateTime), "DATETIME");
			dictionary_0.Add(typeof(float), "DOUBLE");
			dictionary_0.Add(typeof(double), "DOUBLE");
			dictionary_0.Add(typeof(decimal), "DOUBLE");
			dictionary_0.Add(typeof(TimeSpan), "TEXT");
		}
		return dictionary_0;
	}

	static SQLiteHelper()
	{
		Class72.smethod_20();
	}
}
