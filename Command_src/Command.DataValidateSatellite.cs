using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateSatellite
{
	public static void ValidateSatelliteStatsAndFlags()
	{
		try
		{
			string name = "SELECT ID, OODATargetingCycle, OODAEvasiveCycle FROM DataSatellite";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				int num = 0;
				int num2 = 0;
				long num3 = Conversions.ToLong(recordset2.Fields["ID"].Value);
				num = Conversions.ToInteger(recordset2.Fields["OODATargetingCycle"].Value);
				num2 = Conversions.ToInteger(recordset2.Fields["OODAEvasiveCycle"].Value);
				bool flag = false;
				string string_ = "SELECT ComponentID FROM DataSatelliteMounts WHERE ID = " + Conversions.ToString(num3);
				DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				foreach (object row in dataTable.Rows)
				{
					long num4 = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ComponentID" }, (string[])null));
					string name2 = "SELECT ComponentID FROM DataMountWeapons WHERE ID = " + Conversions.ToString(num4);
					Recordset recordset3 = Common.theSourceDB.OpenRecordset(name2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
					Recordset recordset4 = recordset3;
					while (!recordset4.EOF)
					{
						long num5 = Conversions.ToLong(recordset4.Fields["ComponentID"].Value);
						string name3 = "SELECT ComponentID FROM DataWeaponRecord WHERE ID = " + Conversions.ToString(num5);
						Recordset recordset5 = Common.theSourceDB.OpenRecordset(name3, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						Recordset recordset6 = recordset5;
						while (!recordset6.EOF)
						{
							long num6 = Conversions.ToLong(recordset6.Fields["ComponentID"].Value);
							string name4 = "SELECT Type FROM DataWeapon WHERE ID = " + Conversions.ToString(num6);
							Recordset recordset7 = Common.theSourceDB.OpenRecordset(name4, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
							Recordset recordset8 = recordset7;
							while (!recordset8.EOF)
							{
								long num7 = Conversions.ToLong(recordset8.Fields["Type"].Value);
								if (num7 == 2001L || num7 == 2002L || num7 == 2003L || num7 == 2004L || num7 == 4001L || num7 == 4002L || num7 == 4004L || num7 == 4005L || num7 == 4006L || num7 == 4007L || num7 == 6001L)
								{
									flag = true;
								}
								recordset8.MoveNext();
							}
							recordset8 = null;
							recordset7.Close();
							recordset6.MoveNext();
						}
						recordset6 = null;
						recordset5.Close();
						recordset4.MoveNext();
					}
					recordset4 = null;
					recordset3.Close();
				}
				if (num == 0 && flag)
				{
					string text = "Unit carries weapons but has an OODA Targeting Cycle of 0.";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num > 0 && !flag)
				{
					string text = "Unit has an OODA Targeting Cycle but carries no weapons.";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 == 0)
				{
					string text = "Enter a valid OODA Evasive Cycle.";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				recordset2.MoveNext();
			}
			recordset2 = null;
			recordset.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200077", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSatelliteNames()
	{
		try
		{
			string name = "SELECT ID FROM DataSatellite";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				string name2 = "SELECT Name, Comments, YearCommissioned, YearDecommissioned FROM DataSatellite WHERE ID = " + Conversions.ToString(num);
				Recordset recordset3 = Common.theSourceDB.OpenRecordset(name2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				string text = "";
				double num2 = 0.0;
				double num3 = 0.0;
				string text2 = Conversions.ToString(recordset3.Fields["Name"].Value);
				text = Conversions.ToString(recordset3.Fields["Comments"].Value);
				num2 = Conversions.ToDouble(recordset3.Fields["YearCommissioned"].Value);
				num3 = Conversions.ToDouble(recordset3.Fields["YearDecommissioned"].Value);
				recordset3.Close();
				int num4 = Strings.InStr(1, text2, "(", (CompareMethod)1);
				int num5 = Strings.InStr(1, text2, ")", (CompareMethod)1);
				int num6 = Strings.InStr(1, text2, "[", (CompareMethod)1);
				int num7 = Strings.InStr(1, text2, "]", (CompareMethod)1);
				int num8 = Strings.InStr(1, text2, "{", (CompareMethod)1);
				int num9 = Strings.InStr(1, text2, "}", (CompareMethod)1);
				int num10 = Strings.InStr(1, text, "(", (CompareMethod)1);
				int num11 = Strings.InStr(1, text, ")", (CompareMethod)1);
				int num12 = Strings.InStr(1, text, "[", (CompareMethod)1);
				int num13 = Strings.InStr(1, text, "]", (CompareMethod)1);
				int num14 = Strings.InStr(1, text, "{", (CompareMethod)1);
				int num15 = Strings.InStr(1, text, "}", (CompareMethod)1);
				if (num4 > 0 && num5 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num16;
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				else
				{
					num16 = 1;
				}
				if (Strings.InStr(num16, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should be none.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"(\" bracket in comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 > 0 && num12 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 > 0 && num15 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num17;
				if (!(num15 > 0 && num14 == 0))
				{
					num17 = 1;
				}
				else
				{
					string text3 = "Found a right \"}\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				int num18;
				if (Strings.InStr(num17, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should be none.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				else
				{
					num18 = 1;
				}
				int num19;
				if (Strings.InStr(num18, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				else
				{
					num19 = 1;
				}
				int num20;
				if (Strings.InStr(num19, text2, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				else
				{
					num20 = 1;
				}
				int num21;
				if (Strings.InStr(num20, text, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				else
				{
					num21 = 1;
				}
				if (Strings.InStr(num21, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 > num3 && num3 != 0.0)
				{
					string text3 = "Unit decomissioned before it commissioned? Unlikely. Check years!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				recordset2.MoveNext();
			}
			recordset2 = null;
			recordset.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200078", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateGeostationnarySatelliteHaveCorrectSensor()
	{
		try
		{
			string name = "SELECT ID, Category FROM DataSatellite";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				if (Convert.ToInt32(Conversions.ToString(recordset2.Fields["Category"].Value)) != 2001)
				{
					recordset2.MoveNext();
					continue;
				}
				string string_ = "SELECT ComponentID FROM DataSatelliteSensors WHERE ID = " + Conversions.ToString(num);
				DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				if (dataTable.Rows.Count != 0)
				{
					string text = Conversions.ToString(dataTable.Rows[0]["ComponentID"]);
					string string_2 = "SELECT RangeMax FROM DataSensor WHERE ID = " + text;
					DataTable dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable(string_2);
					if (dataTable2.Rows.Count != 0)
					{
						if (Convert.ToDouble(Conversions.ToString(dataTable2.Rows[0]["RangeMax"])) < 19500.0)
						{
							string text2 = "The geostationary satellite does not have any sensor capable of detecting targets on earth surface. Make sure its sensor has a range > 36 000 Km.";
							string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
							recordset2.MoveNext();
						}
						else
						{
							recordset2.MoveNext();
						}
					}
					else
					{
						string text2 = "The geostationary satellite have an invalid sensor ID";
						string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						recordset2.MoveNext();
					}
				}
				else
				{
					string text2 = "The geostationary satellite does not have any sensor.";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					recordset2.MoveNext();
				}
			}
			recordset2 = null;
			recordset.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200079", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSatelliteHaveCorrectOperatorServiceAndYear()
	{
		try
		{
			string name = "SELECT ID, OperatorCountry, OperatorService, YearCommissioned, YearDecommissioned FROM DataSatellite";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = 0L;
				long num2 = 0L;
				long num3 = Conversions.ToLong(recordset2.Fields["ID"].Value);
				num = Conversions.ToLong(recordset2.Fields["YearCommissioned"].Value);
				num2 = Conversions.ToLong(recordset2.Fields["YearDecommissioned"].Value);
				double num4 = Conversions.ToDouble(recordset2.Fields["OperatorCountry"].Value);
				double num5 = Conversions.ToDouble(recordset2.Fields["OperatorService"].Value);
				string string_ = "SELECT YearStart, YearEnd FROM EnumOperatorCountry WHERE ID = " + Conversions.ToString(num4);
				DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				long num6 = 0L;
				long num7 = 0L;
				if (dataTable.Rows.Count > 0)
				{
					num6 = Conversions.ToLong(dataTable.Rows[0]["YearStart"]);
					num7 = Conversions.ToLong(dataTable.Rows[0]["YearEnd"]);
				}
				if (num < num6 && (ulong)num > 0uL)
				{
					string text = "Satellite entered service before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 < num6 && (ulong)num2 > 0uL)
				{
					string text = "Satellite decommissioned before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 > num7 && (ulong)num7 > 0uL)
				{
					string text = "Satellite decommissioned after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num > num7 && (ulong)num7 > 0uL)
				{
					string text = "Satellite entered service after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2100.0 && num5 != 2101.0 && num5 != 2102.0 && num5 != 2103.0 && num5 != 2104.0)
				{
					string text = "Operator is United Kingdom. Service should be a Royal-type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2079.0 && num5 != 2001.0 && num5 != 2002.0 && num5 != 2003.0 && num5 != 2005.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 1003.0)
				{
					string text = "Operator is Russia. Service should be a vanilla type, not Red Star type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2088.0 && num5 != 2201.0 && num5 != 2202.0 && num5 != 2203.0 && num5 != 2204.0 && num5 != 2205.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 2208.0 && num5 != 2209.0 && num5 != 1003.0)
				{
					string text = "Operator is Soviet Union. Service should be one of the Cold War operators!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				recordset2.MoveNext();
			}
			recordset2 = null;
			recordset.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200079", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSatelliteOrbitsAndDates()
	{
		try
		{
			DataTable dataTable = Common.get_DataSatellite(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = 0L;
				long num2 = 0L;
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "YearCommissioned" }, (string[])null));
				num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "YearDecommissioned" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OperatorCountry" }, (string[])null));
				DataRow[] array = Common.get_DataSatelliteOrbits(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				string value = null;
				double num5 = 9999.0;
				double num6 = 0.0;
				bool flag = false;
				long num7 = 0L;
				DataRow[] array2 = array;
				foreach (DataRow dataRow in array2)
				{
					double num8 = Conversions.ToDouble(dataRow["ComponentNumber"]);
					bool flag2 = Conversions.ToBoolean(dataRow["Operational"]);
					Conversions.ToString((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["MissonID"]))) ? dataRow["MissonID"] : "");
					Conversions.ToString(dataRow["MissonName"]);
					double num9 = Conversions.ToDouble(dataRow["Perigee"]);
					double num10 = Conversions.ToDouble(dataRow["Apogee"]);
					double? num11 = (double?)dataRow["Inclination"];
					double num12 = Conversions.ToDouble(dataRow["OrbitalPeriod"]);
					Conversions.ToDouble(dataRow["Plane"]);
					Conversions.ToDate(dataRow["LaunchDate"]);
					Conversions.ToDate(dataRow["CommissioningDate"]);
					Conversions.ToDate(dataRow["DecommissioningDate"]);
					Conversions.ToDate(dataRow["DeOrbitingDate"]);
					if (!flag2)
					{
						continue;
					}
					if (string.IsNullOrEmpty(value))
					{
						if (num9 <= 0.0)
						{
							string text = "Satellite orbit (" + Conversions.ToString(num8) + ") is marked Operational but Perigee has not been entered!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num10 <= 0.0)
						{
							string text = "Satellite orbit (" + Conversions.ToString(num8) + ") is marked Operational but Apogee has not been entered!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!num11.HasValue)
						{
							string text = "Satellite orbit (" + Conversions.ToString(num8) + ") is marked Operational but Inclination has not been entered!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num12 <= 0.0)
						{
							string text = "Satellite orbit (" + Conversions.ToString(num8) + ") is marked Operational but Orbital Period has not been entered!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					num7++;
					DataRow[] array3 = Common.get_EnumOperatorCountry(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
					foreach (DataRow dataRow2 in array3)
					{
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow2["YearStart"])))
						{
							Conversions.ToLong(dataRow2["YearStart"]);
						}
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow2["YearEnd"])))
						{
							Conversions.ToLong(dataRow2["YearEnd"]);
						}
					}
					if (num9 > num10)
					{
						string text = "Satellite orbit (" + Conversions.ToString(num8) + ") has Perigee that is greater than the Apogee!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num7 <= 0L && num3 > 2L)
				{
					string text = "Satellite has no orbits entered!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 != (double)num && num3 > 2L && num5 != 9999.0)
				{
					string text = "Satellite on-unit in-service year (" + Conversions.ToString(num) + ") does not match first orbit year (" + Conversions.ToString(num5) + ")!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 != (double)num2 && flag && num3 > 2L && (ulong)num2 > 0uL)
				{
					string text = "Satellite on-unit out-of-service year  (" + Conversions.ToString(num2) + ") does not match last orbit year (" + Conversions.ToString(num6) + ")!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Satellite" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200080", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateSatellite()
	{
		Class72.smethod_20();
	}
}
