using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Text;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public class MSAccessHelper
{
	public OleDbConnection theConnection;

	public MSAccessHelper(OleDbConnection theConn)
	{
		theConnection = theConn;
	}

	public bool ExecuteNonQuery(string string_0, bool CloseConnectionWhenDone = false, bool LogQuery = false)
	{
		bool result;
		try
		{
			OpenConnection();
			OleDbCommand val = theConnection.CreateCommand();
			try
			{
				val.CommandText = string_0;
				val.ExecuteNonQuery();
				int num;
				if (LogQuery)
				{
					MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.SQL, string_0);
					num = 1;
				}
				else
				{
					num = 1;
				}
				result = (byte)num != 0;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public OleDbDataReader ExecuteReader(string string_0, bool CloseConnectionWhenDone = false)
	{
		OpenConnection();
		OleDbCommand val = theConnection.CreateCommand();
		try
		{
			val.CommandText = string_0;
			return val.ExecuteReader();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public DataTable ExecuteDataTable(string string_0, bool CloseConnectionWhenDone = false, bool LogQuery = false)
	{
		DataTable result = default(DataTable);
		try
		{
			OpenConnection();
			OleDbCommand val = theConnection.CreateCommand();
			OleDbDataReader val2;
			try
			{
				val.CommandText = string_0;
				val2 = val.ExecuteReader();
				if (LogQuery)
				{
					MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.SQL, string_0);
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			DataTable dataTable = new DataTable();
			int fieldCount = val2.FieldCount;
			int num = fieldCount - 1;
			for (int i = 0; i <= num; i++)
			{
				dataTable.Columns.Add(val2.GetName(i), val2.GetFieldType(i));
			}
			while (val2.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				int num2 = fieldCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					dataRow[j] = RuntimeHelpers.GetObjectValue(val2[j]);
				}
				dataTable.Rows.Add(dataRow);
			}
			val2.Close();
			val2 = null;
			if (CloseConnectionWhenDone)
			{
				CloseConnection();
			}
			result = dataTable;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception theExc = ex;
			ErrorManagement.EnqueueErrorMessage(theExc);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string ExecuteScalar(string string_0, bool CloseConnectionWhenDone = false, bool LogQuery = false)
	{
		OpenConnection();
		OleDbCommand val = theConnection.CreateCommand();
		string result;
		try
		{
			val.CommandText = string_0;
			result = Conversions.ToString(val.ExecuteScalar());
			if (LogQuery)
			{
				MyProject.Forms.DBToolsForm.AddToOperationStack(DBToolsForm.OperationFilterType.SQL, string_0);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (CloseConnectionWhenDone)
		{
			CloseConnection();
		}
		return result;
	}

	public int ExecuteInsertAndGetNewAutonumber(string string_0, bool CloseConnectionWhenDone = false)
	{
		OpenConnection();
		OleDbCommand val = theConnection.CreateCommand();
		int result;
		try
		{
			val.CommandText = string_0;
			val.ExecuteNonQuery();
			val.CommandText = "SELECT @@IDENTITY";
			result = Conversions.ToInteger(val.ExecuteScalar());
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (CloseConnectionWhenDone)
		{
			CloseConnection();
		}
		return result;
	}

	public void ExecuteCommand(OleDbCommand theCommand, bool CloseConnectionWhenDone = false)
	{
		OpenConnection();
		theCommand.Connection = theConnection;
		theCommand.ExecuteNonQuery();
		if (CloseConnectionWhenDone)
		{
			CloseConnection();
		}
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

	static MSAccessHelper()
	{
		Class72.smethod_20();
	}
}
