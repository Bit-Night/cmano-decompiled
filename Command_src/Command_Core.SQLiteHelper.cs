using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class SQLiteHelper
{
	[CompilerGenerated]
	internal sealed class _Closure$__8-0
	{
		public SQLiteDataReader $VB$Local_theReader;

		public _Closure$__8-0(_Closure$__8-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theReader = arg0.$VB$Local_theReader;
			}
		}

		[SpecialName]
		internal void _Lambda$__0()
		{
			$VB$Local_theReader.Close();
			$VB$Local_theReader = null;
		}

		static _Closure$__8-0()
		{
			Class72.smethod_20();
		}
	}

	public SQLiteConnection theConnection;

	private static TDictionary<string, bool> tdictionary_0;

	private static Dictionary<Type, string> dictionary_0;

	static SQLiteHelper()
	{
		Class72.smethod_20();
		tdictionary_0 = new TDictionary<string, bool>();
	}

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

	internal string ExecuteInsertScalar(string theInsertCommand)
	{
		OpenConnection();
		string text;
		string result;
		using (SQLiteCommand sQLiteCommand = new SQLiteCommand(theConnection))
		{
			using SQLiteTransaction sQLiteTransaction = theConnection.BeginTransaction();
			sQLiteCommand.CommandText = theInsertCommand + "; Select last_insert_rowid()";
			try
			{
				text = Conversions.ToString(sQLiteCommand.ExecuteScalar());
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = string.Empty;
				ProjectData.ClearProjectError();
				goto end_IL_001f;
			}
			sQLiteTransaction.Commit();
			goto IL_007f;
			end_IL_001f:;
		}
		goto IL_0082;
		IL_007f:
		result = text;
		goto IL_0082;
		IL_0082:
		return result;
	}

	internal bool ExecuteNonQuery_Transaction(List<string> ListOfCommands)
	{
		OpenConnection();
		bool result;
		using (SQLiteCommand sQLiteCommand = new SQLiteCommand(theConnection))
		{
			using SQLiteTransaction sQLiteTransaction = theConnection.BeginTransaction();
			foreach (string ListOfCommand in ListOfCommands)
			{
				sQLiteCommand.CommandText = ListOfCommand;
				try
				{
					sQLiteCommand.ExecuteNonQuery();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					int num;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num = 0;
					}
					else
					{
						num = 0;
					}
					result = (byte)num != 0;
					ProjectData.ClearProjectError();
					goto end_IL_0020;
				}
			}
			sQLiteTransaction.Commit();
			goto IL_009f;
			end_IL_0020:;
		}
		goto IL_00a1;
		IL_009f:
		result = true;
		goto IL_00a1;
		IL_00a1:
		return result;
	}

	internal SQLiteDataReader ExecuteReader(string string_0)
	{
		OpenConnection();
		using DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		return (SQLiteDataReader)dbCommand.ExecuteReader();
	}

	internal DataTable ExecuteDataTable(string string_0)
	{
		OpenConnection();
		DbCommand dbCommand = theConnection.CreateCommand();
		dbCommand.CommandText = string_0;
		SQLiteDataReader sQLiteDataReader = (SQLiteDataReader)dbCommand.ExecuteReader();
		DataTable dataTable = new DataTable();
		int fieldCount = sQLiteDataReader.FieldCount;
		int num = fieldCount - 1;
		for (int i = 0; i <= num; i++)
		{
			dataTable.Columns.Add(sQLiteDataReader.GetName(i), sQLiteDataReader.GetFieldType(i));
		}
		while (sQLiteDataReader.Read())
		{
			DataRow dataRow = dataTable.NewRow();
			int num2 = fieldCount - 1;
			for (int j = 0; j <= num2; j++)
			{
				dataRow[j] = RuntimeHelpers.GetObjectValue(sQLiteDataReader[j]);
			}
			dataTable.Rows.Add(dataRow);
		}
		dbCommand.Cancel();
		dbCommand.Dispose();
		sQLiteDataReader.Close();
		sQLiteDataReader = null;
		return dataTable;
	}

	internal DataTableTyped ExecuteDataTableTyped(string string_0)
	{
		DataTableTyped result = default(DataTableTyped);
		try
		{
			_Closure$__8-0 arg = default(_Closure$__8-0);
			_Closure$__8-0 CS$<>8__locals8 = new _Closure$__8-0(arg);
			OpenConnection();
			DbCommand dbCommand = theConnection.CreateCommand();
			dbCommand.CommandText = string_0;
			CS$<>8__locals8.$VB$Local_theReader = (SQLiteDataReader)dbCommand.ExecuteReader();
			DataTableTyped dataTableTyped = new DataTableTyped();
			int fieldCount = CS$<>8__locals8.$VB$Local_theReader.FieldCount;
			int num = fieldCount - 1;
			for (int i = 0; i <= num; i++)
			{
				dataTableTyped.Columns.Add(CS$<>8__locals8.$VB$Local_theReader.GetName(i), CS$<>8__locals8.$VB$Local_theReader.GetFieldType(i));
			}
			object[] array = new object[fieldCount - 1 + 1];
			while (CS$<>8__locals8.$VB$Local_theReader.Read())
			{
				CS$<>8__locals8.$VB$Local_theReader.GetValues(array);
				DtrRow dtrRow = dataTableTyped.NewRow();
				int num2 = fieldCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					dtrRow[j] = RuntimeHelpers.GetObjectValue(array[j]);
				}
				dataTableTyped.Rows.Add(dtrRow);
			}
			dbCommand.Cancel();
			dbCommand.Dispose();
			Task.Factory.StartNew([SpecialName] () =>
			{
				CS$<>8__locals8.$VB$Local_theReader.Close();
				CS$<>8__locals8.$VB$Local_theReader = null;
			});
			result = dataTableTyped;
			return result;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal string ExecuteScalar(string string_0, bool CloseConnectionAtEnd = false)
	{
		OpenConnection();
		string result;
		using (DbCommand dbCommand = theConnection.CreateCommand())
		{
			dbCommand.CommandText = string_0;
			result = Conversions.ToString(dbCommand.ExecuteScalar());
		}
		if (CloseConnectionAtEnd)
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
			using DbCommand dbCommand = theConnection.CreateCommand();
			dbCommand.CommandText = "PRAGMA temp_store=MEMORY;";
			dbCommand.ExecuteNonQuery();
			dbCommand.CommandText = "PRAGMA cache_size=-64000;";
			dbCommand.ExecuteNonQuery();
			dbCommand.CommandText = "PRAGMA synchronous=OFF;";
			dbCommand.ExecuteNonQuery();
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
		stringBuilder.Append(smethod_0(Conversions.ToString(theTime.Month)));
		stringBuilder.Append("-");
		stringBuilder.Append(smethod_0(Conversions.ToString(theTime.Day)));
		stringBuilder.Append(" ");
		stringBuilder.Append(smethod_0(Conversions.ToString(theTime.Hour)));
		stringBuilder.Append(":");
		stringBuilder.Append(smethod_0(Conversions.ToString(theTime.Minute)));
		stringBuilder.Append(":");
		stringBuilder.Append(smethod_0(Conversions.ToString(theTime.Second)));
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

	internal void ResetTableCheckCache()
	{
		tdictionary_0.Clear();
	}

	internal bool CheckTableExists(StringBuilder theBuilder, string TableName)
	{
		string key = theConnection.ConnectionString + TableName;
		if (!tdictionary_0.TryGetValue(key, out var value))
		{
			if (theBuilder == null)
			{
				theBuilder = new StringBuilder();
			}
			else
			{
				theBuilder.Clear();
			}
			theBuilder.Append("SELECT count(*) FROM sqlite_master WHERE type='table' AND name='").Append(TableName).Append("'");
			string string_ = theBuilder.ToString();
			value = ((Conversions.ToInteger(ExecuteScalar(string_)) != 0) ? true : false);
			tdictionary_0.AddIfNotExists(key, value);
			return value;
		}
		return value;
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
}
