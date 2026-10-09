using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class SchemaUpdate
{
	public static void PerformSchemaUpdate()
	{
		AddNewColumn(Common.mySourceDB_Helper, "DataAircraft", "Visibility", "TEXT(10)");
		AddNewColumn(Common.mySourceDB_Helper, "DataSatelliteOrbits", "TLE", "TEXT(255)");
		AddNewColumn(Common.mySourceDB_Helper, "DataComm", "QualityGrade", "float", "0");
		AddNewColumn(Common.mySourceDB_Helper, "DataComm", "Latency", "float", "0");
		AddNewColumn(Common.mySourceDB_Helper, "DataComm", "LatencyGrade", "float", "0");
	}

	public static void RemoveColumn(MSAccessHelper dbhelper, string TableName, string ColumnName)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (dbhelper.ExecuteDataTable("select * from " + TableName + " where ID = (SELECT FIRST(ID) from " + TableName + ")", CloseConnectionWhenDone: false, LogQuery: true).Columns.Contains(ColumnName))
			{
				dbhelper.ExecuteNonQuery("ALTER TABLE " + TableName + " DROP COLUMN " + ColumnName);
				Interaction.MsgBox((object)("Removed column: " + ColumnName + " removed successfully from table: " + TableName), (MsgBoxStyle)0, (object)null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			Interaction.MsgBox((object)("Error while attempting to remove column: " + ColumnName + " to table: " + TableName + ". Error Description: " + ex2.Message), (MsgBoxStyle)0, (object)null);
			ProjectData.ClearProjectError();
		}
		finally
		{
			dbhelper.CloseConnection();
		}
	}

	public static void AddNewColumn(MSAccessHelper dbhelper, string TableName, string ColumnName, string TypeDefinition, string DefaultValue = "")
	{
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			if (dbhelper.ExecuteDataTable("select * from " + TableName + " where ID = (SELECT FIRST(ID) from " + TableName + ")", CloseConnectionWhenDone: false, LogQuery: true).Columns.Contains(ColumnName))
			{
				flag = true;
			}
			if (flag)
			{
				Interaction.MsgBox((object)("Column: " + ColumnName + " already exists on table: " + TableName), (MsgBoxStyle)0, (object)null);
				return;
			}
			string text = "";
			if (!string.IsNullOrEmpty(DefaultValue))
			{
				text = " DEFAULT " + DefaultValue;
			}
			dbhelper.ExecuteNonQuery("ALTER TABLE " + TableName + " ADD COLUMN " + ColumnName + " " + TypeDefinition + text);
			if (!string.IsNullOrEmpty(DefaultValue))
			{
				dbhelper.ExecuteNonQuery("UPDATE " + TableName + " SET " + ColumnName + " = " + DefaultValue);
			}
			Interaction.MsgBox((object)("New column: " + ColumnName + " added successfully to table: " + TableName), (MsgBoxStyle)0, (object)null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			Interaction.MsgBox((object)("Error while attempting to add column: " + ColumnName + " to table: " + TableName + ". Error Description: " + ex2.Message), (MsgBoxStyle)0, (object)null);
			ProjectData.ClearProjectError();
		}
		finally
		{
			dbhelper.CloseConnection();
		}
	}

	static SchemaUpdate()
	{
		Class72.smethod_20();
	}
}
