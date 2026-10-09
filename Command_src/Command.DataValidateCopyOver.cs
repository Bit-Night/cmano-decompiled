using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateCopyOver
{
	private static string string_0;

	private static long long_0;

	private static long long_1;

	private static long long_2;

	private static long long_3;

	private static long long_4;

	private static long long_5;

	private static string string_1;

	private static string string_2;

	public static void ValidateCopyOverID()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			OleDbConnection theConn = new OleDbConnection(Common.theSourceDBConnectionString);
			MSAccessHelper msaccessHelper_ = new MSAccessHelper(theConn);
			smethod_0(msaccessHelper_);
			smethod_1(msaccessHelper_);
			smethod_2(msaccessHelper_);
			smethod_3(msaccessHelper_);
			ImnTyMpZeE(msaccessHelper_);
			smethod_4(msaccessHelper_);
			smethod_5(msaccessHelper_);
			smethod_6(msaccessHelper_);
			smethod_7(msaccessHelper_);
			smethod_8(msaccessHelper_);
			smethod_9(msaccessHelper_);
			smethod_10(msaccessHelper_);
			smethod_11(msaccessHelper_);
			smethod_12(msaccessHelper_);
			smethod_13(msaccessHelper_);
			smethod_14(msaccessHelper_);
			smethod_15(msaccessHelper_);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200021", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_0(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscAircraft Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Aircraft: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Aircraft has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
						break;
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Aircraft has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Aircraft has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200022", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_1(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, Used, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscAircraftFacility Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Air-Facility: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Aircraft Facility has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
						break;
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Aircraft Facility has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Aircraft Facility has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200023", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_2(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscComm Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Comm: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Comm has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Comm" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
						break;
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Comm has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Comm" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Comm has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Comm" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200024", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_3(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscDockingFacility Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Dock-Fac: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: DockingFacility has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Docking Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
						break;
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: DockingFacility has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Docking Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: DockingFacility has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Docking Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200025", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void ImnTyMpZeE(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscFacility Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Facility: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Facility has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
						break;
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Facility has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Facility has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200026", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_4(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscFuel Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Fuel Rec: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Fuel has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Fuel" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
						break;
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Fuel has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Fuel" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Fuel has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Fuel" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200027", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_5(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscFuel Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (object row2 in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row2);
				long_0 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long_1 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CopyOverTargetID" }, (string[])null));
				long_2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CopyOverSource" }, (string[])null));
				long_3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CopyOverTarget" }, (string[])null));
				Common.StatusString = "Validating Copy-Over ID for Loadout: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Loadout has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Loadout has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Loadout has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200028", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_6(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscMagazine Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Magazine: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Magazine has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Magazine has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Magazine has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200029", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_7(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscMount Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Mount: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Mount has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Mount has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Mount has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200030", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_8(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscPropulsion Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Propulsion: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Propulsion has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Propulsion has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Propulsion has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200031", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_9(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscSatellite Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Sattelite: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Satellite has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Satellite has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Satellite has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200032", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_10(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscSensor Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Sensor: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Sensor has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Sensor has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Sensor has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200033", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_11(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscShip Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Ship: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Ship has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Ship has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Ship has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200034", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_12(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscSubmarine Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Submarine: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Submarine has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Submarine has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Submarine has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200035", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_13(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscWarhead Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Warhead: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Warhead has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Warhead has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Warhead has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200036", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_14(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscWeapon Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for Weapon: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: Weapon has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: Weapon has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: Weapon has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200037", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_15(MSAccessHelper msaccessHelper_0)
	{
		try
		{
			string text = "SELECT ID, CopyOverTargetID, CopyOverSource, CopyOverTarget FROM MiscWeaponRecord Where CopyOverTargetID > 0";
			DataTable dataTable = msaccessHelper_0.ExecuteDataTable(text);
			foreach (DataRow row2 in dataTable.Rows)
			{
				long_0 = Conversions.ToLong(row2["ID"]);
				long_1 = Conversions.ToLong(row2["CopyOverTargetID"]);
				long_2 = Conversions.ToLong(row2["CopyOverSource"]);
				long_3 = Conversions.ToLong(row2["CopyOverTarget"]);
				Common.StatusString = "Validating Copy-Over ID for WeaponRec: " + Conversions.ToString(long_0);
				DataView dataView = new DataView(dataTable);
				dataView.RowFilter = "ID <> " + Conversions.ToString(long_0);
				foreach (DataRowView item in dataView)
				{
					DataRow row = item.Row;
					long_4 = Conversions.ToLong(row["ID"]);
					long_5 = Conversions.ToLong(row["CopyOverTargetID"]);
					if (long_5 == long_1)
					{
						string_2 = "Copy-Over: WeaponRecord has the same Copy-Over ID as ID " + Conversions.ToString(long_4) + " (Copy-Over ID: " + Conversions.ToString(long_5) + " )";
						string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon Record" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
					}
				}
				if ((long_2 == 0L) & (long_3 == 0L))
				{
					string_2 = "Copy-Over: WeaponRecord has a Copy-Over ID but the Source or Target fields have not been set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon Record" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
				if (((ulong)long_2 > 0uL) & ((ulong)long_3 > 0uL))
				{
					string_2 = "Copy-Over: WeaponRecord has both the Copy-Over Source and Target fields set!";
					string_0 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(long_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon Record" + Conversions.ToString(Convert.ToChar(34)) + ", '" + string_2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_0);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200038", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateCopyOver()
	{
		Class72.smethod_20();
	}
}
