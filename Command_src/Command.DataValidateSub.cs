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
internal sealed class DataValidateSub
{
	public static void ValidateSubmarineStatsAndFlags()
	{
		try
		{
			string name = "SELECT * FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			long num14 = default(long);
			long num15 = default(long);
			long num16 = default(long);
			long num17 = default(long);
			long num18 = default(long);
			long num19 = default(long);
			long num20 = default(long);
			long num21 = default(long);
			long num22 = default(long);
			long num23 = default(long);
			long num29 = default(long);
			long num30 = default(long);
			long num31 = default(long);
			long num32 = default(long);
			long num33 = default(long);
			long num34 = default(long);
			double num36 = default(double);
			double num37 = default(double);
			while (!recordset2.EOF)
			{
				long num = 0L;
				long num2 = 0L;
				bool flag = false;
				long num3 = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num4 = Conversions.ToLong(recordset2.Fields["Type"].Value);
				long num5 = Conversions.ToLong(recordset2.Fields["MaxDepth"].Value);
				long num6 = Conversions.ToLong((!Information.IsDBNull((object)recordset2.Fields["OODADetectionCycle"])) ? recordset2.Fields["OODADetectionCycle"].Value : ((object)0));
				num = Conversions.ToLong(recordset2.Fields["OODATargetingCycle"].Value);
				num2 = Conversions.ToLong(recordset2.Fields["OODAEvasiveCycle"].Value);
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				long num7 = 0L;
				long num8 = 0L;
				long num9 = 0L;
				long num10 = 0L;
				long num11 = 0L;
				long num12 = 0L;
				DataRow[] array = Common.get_DataSubmarinePropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					long num13 = Conversions.ToLong(array[i]["ComponentID"]);
					DataRow? dataRow = Common.get_MiscSubmarine(Common.mySourceDB_Helper).Rows.Find(num3);
					num14 = Conversions.ToLong(dataRow["DefaultCruiseSpeedPeriscopeDepth"]);
					num15 = Conversions.ToLong(dataRow["DefaultCruiseRangePeriscopeDepth"]);
					num16 = Conversions.ToLong(dataRow["DefaultCreepSpeedSubmerged"]);
					num17 = Conversions.ToLong(dataRow["DefaultCreepRangeSubmerged"]);
					num12 = Conversions.ToLong(dataRow["DefaultCreepRangeAIP"]);
					num18 = Conversions.ToLong(dataRow["DefaultFullSpeedPeriscopeDepth"]);
					Conversions.ToLong(dataRow["DefaultFullRangePeriscopeDepth"]);
					num19 = Conversions.ToLong(dataRow["DefaultFlankSpeedPeriscopeDepth"]);
					Conversions.ToLong(dataRow["DefaultFlankRangePeriscopeDepth"]);
					num20 = Conversions.ToLong(dataRow["DefaultCruiseSpeedSubmerged"]);
					Conversions.ToLong(dataRow["DefaultCruiseRangeSubmerged"]);
					num21 = Conversions.ToLong(dataRow["DefaultFullSpeedSubmerged"]);
					Conversions.ToLong(dataRow["DefaultFullRangeSubmerged"]);
					num22 = Conversions.ToLong(dataRow["DefaultFlankSpeedSubmerged"]);
					Conversions.ToLong(dataRow["DefaultFlankRangeSubmerged"]);
					num23 = Conversions.ToLong(dataRow["PrimaryFuelQty"]);
					double num24 = Conversions.ToDouble(Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num13)["Type"]);
					if (num24 == 3001.0)
					{
						flag2 = true;
					}
					if (num24 == 3004.0)
					{
						flag3 = true;
					}
					if (num24 == 4001.0)
					{
						flag4 = true;
					}
					if (num24 == 4002.0)
					{
						flag5 = true;
					}
					double num25 = 0.0;
					long num26 = 0L;
					long num27 = 0L;
					DataRow[] array2 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num13));
					foreach (DataRow dataRow2 in array2)
					{
						double num28 = Conversions.ToDouble(dataRow2["AltitudeBand"]);
						num26 = Conversions.ToLong(dataRow2["Speed"]);
						num27 = Conversions.ToLong(dataRow2["Throttle"]);
						if (num24 == 3001.0 && num27 == 2L)
						{
							num10 = num26;
						}
						if (num24 == 3001.0 && num27 == 3L)
						{
							num29 = num26;
						}
						if (num24 == 3001.0 && num27 == 4L)
						{
							num30 = num26;
						}
						if ((num24 == 4001.0 || num24 == 4002.0) && num27 == 1L)
						{
							num11 = num26;
						}
						if ((num24 == 4001.0 || num24 == 4002.0) && num27 == 2L)
						{
							num31 = num26;
						}
						if ((num24 == 4001.0 || num24 == 4002.0) && num27 == 3L && num28 == 1.0)
						{
							num32 = num26;
						}
						if ((num24 == 4001.0 || num24 == 4002.0) && num27 == 3L && num28 != 1.0)
						{
							num33 = num26;
						}
						if ((num24 == 4001.0 || num24 == 4002.0) && num27 == 4L)
						{
							num34 = num26;
						}
						if ((num24 == 3004.0 || num24 == 4001.0 || num24 == 4002.0 || num24 == 9001.0) && num28 == 1.0)
						{
							double num35 = Conversions.ToDouble(dataRow2["AltitudeMin"]);
							if (num25 != 0.0 && num25 != num35)
							{
								string text = "Submarine propulsion have different depths for different speeds! Makes no sense";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							num25 = num35;
						}
						if (num24 == 3001.0 && num28 == 1.0)
						{
							num36 = Conversions.ToDouble(dataRow2["AltitudeMin"]);
							if (num37 != 0.0 && num37 != num36)
							{
								string text = "Submarine propulsion have different depths for different speeds! Makes no sense";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							num37 = num36;
						}
					}
				}
				DataRow[] array3 = Common.get_DataSubmarineFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int k = 0; k < array3.Length; k = checked(k + 1))
				{
					long num38 = Conversions.ToLong(array3[k]["ComponentID"]);
					DataRow dataRow3 = Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num38);
					long num39 = Conversions.ToLong(dataRow3["Type"]);
					long num40 = Conversions.ToLong(dataRow3["Capacity"]);
					if (num39 == 3001L)
					{
						flag2 = true;
						num7 = num40;
					}
					if (num39 == 4001L)
					{
						flag6 = true;
						num8 = num40;
					}
					if (num39 == 4002L)
					{
						flag7 = true;
						num9 = num40;
					}
				}
				if (flag2 && num14 > 0L)
				{
					long num41 = (long)Math.Round((double)num15 / (double)num14 * 60.0);
					if (num7 != num41 && num23 == 0L)
					{
						string text = "Diesel fuel qty should be " + Conversions.ToString(num41) + ".";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 != num23 && (ulong)num23 > 0uL)
					{
						string text = "Diesel fuel qty should be " + Conversions.ToString(num23) + ".";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 != num14)
					{
						string text = "Submarine specified Cruise Speed (kt) Diesel is different from the engine stats! " + Conversions.ToString(num10) + "kt vs " + Conversions.ToString(num14) + "kt";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag2 && num18 > 0L && num29 != num18)
				{
					string text = "Submarine specified Full Speed (kt) Diesel is different from the engine stats! " + Conversions.ToString(num29) + "kt vs " + Conversions.ToString(num18) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag2 && num19 > 0L && num30 != num19)
				{
					string text = "Submarine specified Full Speed (kt) Diesel is different from the engine stats! " + Conversions.ToString(num30) + "kt vs " + Conversions.ToString(num19) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag4 || flag5) && num16 > 0L)
				{
					long num42 = (long)Math.Round((double)num17 / (double)num16 * 60.0);
					if (num8 != num42)
					{
						string text = "Electric fuel qty should be " + Conversions.ToString(num42) + ".";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 != num16)
					{
						string text = "Submarine specified Creep Speed (kt) Electric is different from the engine stats! " + Conversions.ToString(num11) + "kt vs " + Conversions.ToString(num16) + "kt";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if ((flag4 || flag5) && num20 > 0L && num31 != num20)
				{
					string text = "Submarine specified Cruise Speed (kt) Electric is different from the engine stats! " + Conversions.ToString(num31) + "kt vs " + Conversions.ToString(num20) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag4 || flag5) && num21 > 0L && num32 != num21)
				{
					string text = "Submarine specified Full Speed (kt) Electric (Dived) is different from the engine stats! " + Conversions.ToString(num32) + "kt vs " + Conversions.ToString(num21) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag4 || flag5) && num21 > 0L && num33 > num32)
				{
					string text = "Electric motor Full Speed at periscope or surface can not be greater than Full Speed dived!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag4 || flag5) && num22 > 0L && num34 != num22)
				{
					string text = "Submarine specified Flank Speed (kt) Electric is different from the engine stats! " + Conversions.ToString(num34) + "kt vs " + Conversions.ToString(num22) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag5 && num16 > 0L)
				{
					long num43 = (long)Math.Round((double)num12 / (double)num16 * 60.0);
					if (num9 != num43)
					{
						string text = "AIP fuel qty should be " + Conversions.ToString(num43) + ".";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if ((flag5 || num12 > 0L) && num10 <= 1L)
				{
					string text = "Submarine has AIP fuel and/or AIP engine, but no battery cruise range. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag2 && !flag6 && !flag7)
				{
					if (num36 != (double)num5)
					{
						string text = "Submarine uses diesel only, max depth is different from the engine max depth!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else if (num14 <= 0L && flag2)
				{
					string text = "Diesel Propulsion Default Cruise Speed must be entered!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag3 && ((ulong)num7 > 0uL || (ulong)num8 > 0uL || (ulong)num9 > 0uL))
				{
					string text = "Submarine is nuclear powered but carries conventional fuel. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 <= 0L && flag2)
				{
					string text = "Disel Propulsion Default Cruise Range must be entered!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num16 <= 0L && (flag4 || flag5) && num4 != 4001L)
				{
					string text = "Electric Propulsion Default Creep Speed must be entered!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num17 <= 0L && (flag4 || flag5) && num4 != 4001L)
				{
					string text = "Electric Propulsion Default Creep Range must be entered!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((ulong)num14 > 0uL && flag3)
				{
					string text = "Diesel Propulsion Default Cruise Speed must be 0 for nuclear-powered submarines!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((ulong)num15 > 0uL && flag3)
				{
					string text = "Disel Propulsion Default Cruise Range must be 0 for nuclear-powered submarines!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((ulong)num16 > 0uL && flag3)
				{
					string text = "Electric Propulsion Default Creep Speed must be 0 for nuclear-powered submarines!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((ulong)num17 > 0uL && flag3)
				{
					string text = "Electric Propulsion Default Creep Range must be 0 for nuclear-powered submarines!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				DataRow[] array4 = Common.get_DataSubmarineMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int l = 0; l < array4.Length; l = checked(l + 1))
				{
					long num44 = Conversions.ToLong(array4[l]["ComponentID"]);
					DataRow[] array5 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num44));
					for (int m = 0; m < array5.Length; m = checked(m + 1))
					{
						long num45 = Conversions.ToLong(array5[m]["ComponentID"]);
						long num46 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num45)["ComponentID"]);
						long num47 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num46)["Type"]);
						if (num47 == 2001L || num47 == 2002L || num47 == 2003L || num47 == 2004L || num47 == 2009L || num47 == 4001L || num47 == 4002L || num47 == 4004L || num47 == 4005L || num47 == 4006L || num47 == 4007L || num47 == 6001L)
						{
							flag = true;
						}
					}
				}
				if (num6 == 0L)
				{
					string text = "Unit has an OODA Detection Cycle of 0 (or blank).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num == 0L && flag)
				{
					string text = "Unit carries weapons but has an OODA Targeting Cycle of 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num > 0L && !flag)
				{
					string text = "Unit has an OODA Targeting Cycle but carries no weapons.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 0L)
				{
					string text = "Enter a valid OODA Evasive Cycle.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200102", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubsHaveOnlyOnePropulsionAndFuelRecord()
	{
		try
		{
			string name = "SELECT ID FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				bool flag = false;
				bool flag2 = false;
				long num2 = 0L;
				string name2 = "SELECT DataSubmarinePropulsion(mySourceDB_Helper).ComponentID FROM DataSubmarinePropulsion WHERE DataSubmarinePropulsion(mySourceDB_Helper).ID = " + Conversions.ToString(num) + " AND DataSubmarinePropulsion(mySourceDB_Helper).ComponentID IN (SELECT DataPropulsion(mySourceDB_Helper).ID FROM DataPropulsion);";
				Recordset recordset3 = Common.theSourceDB.OpenRecordset(name2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Recordset recordset4 = recordset3;
				while (!recordset4.EOF)
				{
					Conversions.ToLong(recordset4.Fields["ComponentID"].Value);
					num2++;
					recordset4.MoveNext();
				}
				recordset4 = null;
				recordset3.Close();
				if (num2 > 2L)
				{
					string text = "Submarines with Diesel-Electric or AIP propulsion can only have two Propulsion!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 1L)
				{
					string text = "Submarines with Diesel-Electric or AIP propulsion will need two Propulsion, not just one!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				string name3 = "SELECT ComponentID FROM DataSubmarinePropulsion WHERE ID = " + Conversions.ToString(num) + " AND ComponentID NOT IN (SELECT DataPropulsion(mySourceDB_Helper).ID FROM DataPropulsion WHERE DataPropulsion(mySourceDB_Helper).Type = 3001 AND DataPropulsion(mySourceDB_Helper).Type = 4001 AND DataPropulsion(mySourceDB_Helper).Type = 4002)";
				Recordset recordset5 = Common.theSourceDB.OpenRecordset(name3, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Recordset recordset6 = recordset5;
				while (!recordset6.EOF)
				{
					Conversions.ToLong(recordset6.Fields["ComponentID"].Value);
					int num3;
					if (!flag)
					{
						num3 = 1;
					}
					else
					{
						flag2 = true;
						num3 = 1;
					}
					flag = (byte)num3 != 0;
					recordset6.MoveNext();
				}
				recordset6 = null;
				recordset5.Close();
				if (flag2)
				{
					string text = "The unit has more than one propulsion system! Only one propulsion system is allowed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200103", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubMagazineWeaponsExistsOnMounts()
	{
		try
		{
			string name = "SELECT ID FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			bool flag = default(bool);
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow[] array = Common.get_DataSubmarineMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				DataRow[] array3 = array;
				for (int i = 0; i < array3.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array3[i]["ComponentID"]);
					DataRow[] array4 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					for (int j = 0; j < array4.Length; j = checked(j + 1))
					{
						long num4 = Conversions.ToLong(array4[j]["ComponentID"]);
						long num5 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num4)["ComponentID"]);
						num2++;
						array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
						array2[(int)(num2 - 1L)] = num5;
					}
				}
				string string_ = "SELECT DISTINCT DataSubmarineMagazines.ComponentID FROM DataSubmarineMagazines WHERE DataSubmarineMagazines.ID = " + Conversions.ToString(num) + " AND DataSubmarineMagazines.ComponentID IN (SELECT DataMagazine.ID FROM DataMagazine WHERE DataMagazine.AviationMagazine = 0)";
				DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				foreach (object row in dataTable.Rows)
				{
					long num6 = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ComponentID" }, (string[])null));
					DataRow[] array5 = Common.get_DataMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
					for (int k = 0; k < array5.Length; k = checked(k + 1))
					{
						long num4 = Conversions.ToLong(array5[k]["ComponentID"]);
						long num5 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num4)["ComponentID"]);
						long num7 = num2 - 1L;
						for (long num8 = 0L; num8 <= num7; num8++)
						{
							if (num5 == array2[(int)num8])
							{
								flag = true;
							}
						}
						int num9;
						if (!flag)
						{
							string text = "Weapon " + Conversions.ToString(num5) + " in Magazine " + Conversions.ToString(num6) + " does exist on any mounts.";
							string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
							num9 = 0;
						}
						else
						{
							num9 = 0;
						}
						flag = (byte)num9 != 0;
					}
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
			ex2.Data.Add("Error at Validation 200104", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubNames()
	{
		try
		{
			DataTable dataTable = Common.get_DataSubmarine(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				DataRow? dataRow = Common.get_DataSubmarine(Common.mySourceDB_Helper).Rows.Find(num);
				string text = "";
				double num2 = 0.0;
				double num3 = 0.0;
				string text2 = Conversions.ToString(dataRow["Name"]);
				text = Conversions.ToString(dataRow["Comments"]);
				num2 = Conversions.ToDouble(dataRow["YearCommissioned"]);
				num3 = Conversions.ToDouble(dataRow["YearDecommissioned"]);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num16;
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				else
				{
					num16 = 1;
				}
				if (Strings.InStr(num16, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 > 0 && num12 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 > 0 && num15 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				int num18;
				if (Strings.InStr(num17, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				else
				{
					num18 = 1;
				}
				int num19;
				if (!((Strings.InStr(num18, text2, "AGM ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "AIM ", (CompareMethod)0) > 0)))
				{
					num19 = 1;
				}
				else
				{
					string text3 = "AGM/AIM designations should use dashes \"-\" in the name, not spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				int num20;
				if (Strings.InStr(num19, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				else
				{
					num20 = 1;
				}
				int num21;
				if (Strings.InStr(num20, text2, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				else
				{
					num21 = 1;
				}
				int num22;
				if (Strings.InStr(num21, text, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num22 = 1;
				}
				else
				{
					num22 = 1;
				}
				if (Strings.InStr(num22, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 > num3 && num3 != 0.0)
				{
					string text3 = "Unit decomissioned before it commissioned? Unlikely. Check years!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200105", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubPropulsion()
	{
		try
		{
			string name = "SELECT ID, Type FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num2 = Conversions.ToLong(recordset2.Fields["Type"].Value);
				DataRow[] array = Common.get_DataSubmarinePropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long num3 = 0L;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool flag8 = false;
				bool flag9 = false;
				bool flag10 = false;
				bool flag11 = false;
				bool flag12 = false;
				bool flag13 = false;
				bool flag14 = false;
				long num4 = 0L;
				long num5 = 0L;
				long num6 = 0L;
				long num7 = 0L;
				long num8 = 0L;
				long num9 = 0L;
				long num10 = 0L;
				long num11 = 0L;
				long num12 = 0L;
				long num13 = 0L;
				long num14 = 0L;
				long num15 = 0L;
				long num16 = 0L;
				long num17 = 0L;
				long num18 = 0L;
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num19 = Conversions.ToLong(array2[i]["ComponentID"]);
					long num20 = 0L;
					num3++;
					num20 = Conversions.ToLong(Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num19)["Type"]);
					if (num20 == 3001L)
					{
						flag12 = true;
					}
					if (num20 == 4001L || num20 == 4002L)
					{
						flag13 = true;
					}
					if (num20 == 3004L)
					{
						flag14 = true;
					}
					DataRow[] array3 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num19));
					foreach (DataRow obj in array3)
					{
						double num21 = Conversions.ToDouble(obj["AltitudeMax"]);
						double num22 = Conversions.ToDouble(obj["AltitudeMin"]);
						double num23 = Conversions.ToDouble(obj["Speed"]);
						Conversions.ToDouble(obj["AltitudeBand"]);
						double num24 = Conversions.ToDouble(obj["Throttle"]);
						if (num21 == 0.0 && num22 == -4.0)
						{
							if (num20 == 3001L)
							{
								flag = true;
								if (num24 == 1.0)
								{
									num4 = (long)Math.Round(num23);
								}
								else if (num24 == 2.0)
								{
									num5 = (long)Math.Round(num23);
								}
								else if (num24 == 3.0)
								{
									num6 = (long)Math.Round(num23);
								}
							}
							if (num20 == 4001L || num20 == 4002L)
							{
								flag3 = true;
								if (num24 == 1.0)
								{
									num10 = (long)Math.Round(num23);
								}
								else if (num24 == 2.0)
								{
									num11 = (long)Math.Round(num23);
								}
								else if (num24 == 3.0)
								{
									num12 = (long)Math.Round(num23);
								}
							}
							if (num20 == 3004L)
							{
								flag6 = true;
								if (num24 == 1.0)
								{
									_ = (long)Math.Round(num23);
								}
								else if (num24 == 2.0)
								{
									_ = (long)Math.Round(num23);
								}
								else if (num24 == 3.0)
								{
									_ = (long)Math.Round(num23);
								}
							}
							if (num24 == 4.0)
							{
								flag11 = true;
							}
						}
						if (num21 == -4.0 && num22 >= -20.0 && num22 <= -6.0)
						{
							if (num20 == 3001L)
							{
								flag2 = true;
								if (num24 == 1.0)
								{
									num7 = (long)Math.Round(num23);
								}
								else if (num24 == 2.0)
								{
									num8 = (long)Math.Round(num23);
								}
								else if (num24 == 3.0)
								{
									num9 = (long)Math.Round(num23);
								}
							}
							if (num20 == 4001L || num20 == 4002L)
							{
								flag4 = true;
								if (num24 == 1.0)
								{
									num13 = (long)Math.Round(num23);
								}
								else if (num24 == 2.0)
								{
									num14 = (long)Math.Round(num23);
								}
								else if (num24 == 3.0)
								{
									num15 = (long)Math.Round(num23);
								}
							}
							if (num20 == 3004L)
							{
								flag7 = true;
								if (num24 == 1.0)
								{
									_ = (long)Math.Round(num23);
								}
								else if (num24 == 2.0)
								{
									_ = (long)Math.Round(num23);
								}
								else if (num24 == 3.0)
								{
									_ = (long)Math.Round(num23);
								}
							}
							if (num23 > 12.0)
							{
								flag10 = true;
							}
							if (num24 == 4.0)
							{
								flag9 = true;
							}
						}
						if (!(num21 == -20.0 && num22 < -20.0))
						{
							continue;
						}
						if (num20 == 4001L || num20 == 4002L)
						{
							flag5 = true;
							if (num24 == 1.0)
							{
								num16 = (long)Math.Round(num23);
							}
							else if (num24 == 2.0)
							{
								num17 = (long)Math.Round(num23);
							}
							else if (num24 == 3.0)
							{
								num18 = (long)Math.Round(num23);
							}
							else if (num24 == 4.0)
							{
								_ = (long)Math.Round(num23);
							}
						}
						if (num20 == 3004L)
						{
							flag8 = true;
							if (num24 == 1.0)
							{
								_ = (long)Math.Round(num23);
							}
							else if (num24 == 2.0)
							{
								_ = (long)Math.Round(num23);
							}
							else if (num24 == 3.0)
							{
								_ = (long)Math.Round(num23);
							}
							else if (num24 == 4.0)
							{
								_ = (long)Math.Round(num23);
							}
						}
					}
				}
				if (flag12)
				{
					if (!flag && num2 != 3001L)
					{
						string text = "Submarine does not have valid Diesel propulsion AltitudeBand for surface use (-4 to 0 meters)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag2 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Diesel propulsion AltitudeBand for periscope depth (-4 to -20 meters)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag13)
				{
					if (!flag3 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Electric propulsion AltitudeBand for surface use (-4 to 0 meters)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag4 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Electric propulsion AltitudeBand for periscope depth (-4 to -20 meters)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag5 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Electric propulsion AltitudeBand for deep diving (-20 meters and deeper)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag14)
				{
					if (!flag6 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Nuclear propulsion AltitudeBand for surface use (-4 to 0 meters)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag7 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Nuclear propulsion AltitudeBand for periscope depth (-4 to -20 meters)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag8 && num2 != 3001L)
					{
						string text = "Submarine does not have valid Nuclear propulsion AltitudeBand for deep diving (-20 meters and deeper)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag9 && num2 != 3001L)
				{
					string text = "Submarines may not use Flank speed at periscope depth (-10 to -20 meters)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag11 && num2 != 3001L)
				{
					string text = "Submarines may not use Flank speed on the surface (0 to -9 meters)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag10 && num2 != 4001L && num2 != 4002L)
				{
					string text = "Submarines may not travel faster than 12 kts at periscope depth (-10 to -20 meters)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 != num7 && num2 != 3001L)
				{
					string text = "Surface and Periscope Creep Speed for Diesel engine do not match!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 != num8)
				{
					string text = "Surface and Periscope Cruise Speed for Diesel engine do not match!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 > num6)
				{
					string text = "Diesel engine Full Speed is greater at Periscope than at Surface. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 != num13 && num2 != 3001L)
				{
					string text = "Surface and Periscope Creep Speed for Electric engine do not match!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 != num14)
				{
					string text = "Surface and Periscope Cruise Speed for Electric engine do not match!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 > num12)
				{
					string text = "Electric engine Full Speed is greater at Periscope than at Surface. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num16 != num13 && (ulong)num16 > 0uL)
				{
					string text = "Deep and Periscope Creep Speed for Electric engine do not match!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num17 != num14 && (ulong)num17 > 0uL)
				{
					string text = "Deep and Periscope Cruise Speed for Electric engine do not match!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 > num18)
				{
					string text = "Electric engine Full Speed is greater at Periscope than at Deep. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > num18)
				{
					string text = "Electric engine Full Speed is greater at Surface than at Deep. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200107", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubsHaveDatalinksForWeapons()
	{
		bool flag = false;
		bool flag2 = false;
		try
		{
			string name = "SELECT ID FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow[] array = Common.get_DataSubmarineComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				long[] array3 = new long[0];
				long num3 = 0L;
				DataRow[] array4 = array;
				for (int i = 0; i < array4.Length; i = checked(i + 1))
				{
					long num4 = Conversions.ToLong(array4[i]["ComponentID"]);
					long num5 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]);
					if (num5 > 9999L || (num5 > 8000L && num5 < 9000L))
					{
						num2++;
						array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
						array2[(int)(num2 - 1L)] = num5;
					}
				}
				DataRow[] array5 = Common.get_DataSubmarineMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				DataRow[] array6 = array5;
				checked
				{
					for (int j = 0; j < array6.Length; j++)
					{
						long num6 = Conversions.ToLong(array6[j]["ComponentID"]);
						DataRow[] array7 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
						for (int k = 0; k < array7.Length; k++)
						{
							long num7 = Conversions.ToLong(array7[k]["ComponentID"]);
							long num8 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num7)["Type"]);
							unchecked
							{
								if (num8 > 9999L || (num8 > 8000L && num8 < 9000L))
								{
									num2++;
									array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
									array2[(int)(num2 - 1L)] = num8;
								}
							}
						}
					}
					DataRow[] array8 = array5;
					for (int l = 0; l < array8.Length; l++)
					{
						long num6 = Conversions.ToLong(array8[l]["ComponentID"]);
						DataRow[] array9 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
						for (int m = 0; m < array9.Length; m++)
						{
							long num9 = Conversions.ToLong(array9[m]["ComponentID"]);
							long num10 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num9)["ComponentID"]);
							DataRow[] array10 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
							unchecked
							{
								for (int n = 0; n < array10.Length; n = checked(n + 1))
								{
									long num11 = Conversions.ToLong(array10[n]["ComponentID"]);
									long num12 = 0L;
									long num13 = 0L;
									DataRow? dataRow = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num11);
									num12 = Conversions.ToLong(dataRow["IsOptional"]);
									num13 = Conversions.ToLong(dataRow["Type"]);
									if (num12 == 0L)
									{
										flag = true;
									}
									num3++;
									array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
									array3[(int)(num3 - 1L)] = num13;
									long num14 = num2 - 1L;
									for (long num15 = 0L; num15 <= num14; num15++)
									{
										if (num13 == array2[(int)num15])
										{
											flag2 = true;
										}
									}
								}
								int num16;
								if (!(!flag2 && flag))
								{
									num16 = 0;
								}
								else
								{
									string text = "Weapon " + Conversions.ToString(num10) + " in Mount " + Conversions.ToString(num6) + " has no datalink.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									num16 = 0;
								}
								flag2 = (byte)num16 != 0;
								flag = false;
							}
						}
					}
				}
				long num17 = num2 - 1L;
				for (long num18 = 0L; num18 <= num17; num18++)
				{
					bool flag3 = false;
					long num19 = num3 - 1L;
					for (long num20 = 0L; num20 <= num19; num20++)
					{
						if (array2[(int)num18] == array3[(int)num20])
						{
							flag3 = true;
						}
					}
					if (flag3)
					{
						continue;
					}
					DataTable dataTable = null;
					string text2 = "<Error fetching name!>";
					string string_2 = "SELECT Description FROM EnumCommType WHERE ID = " + Conversions.ToString(array2[(int)num18]);
					dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_2);
					foreach (object row in dataTable.Rows)
					{
						text2 = Conversions.ToString(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "Description" }, (string[])null));
					}
					string text = "Weapon datalink " + text2 + " is not used by any weapons on the Sub.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200108", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubmarineHaveCorrectOperatorServiceAndYear()
	{
		try
		{
			string name = "SELECT ID, OperatorCountry, OperatorService, YearCommissioned, YearDecommissioned FROM DataSubmarine";
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
					string text = "Submarine entered service before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 < num6 && (ulong)num2 > 0uL)
				{
					string text = "Submarine decommissioned before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 > num7 && (ulong)num7 > 0uL)
				{
					string text = "Submarine decommissioned after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num > num7 && (ulong)num7 > 0uL)
				{
					string text = "Submarine entered service after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2100.0 && num5 != 2101.0 && num5 != 2102.0 && num5 != 2103.0 && num5 != 2104.0)
				{
					string text = "Operator is United Kingdom. Service should be a Royal-type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2079.0 && num5 != 2001.0 && num5 != 2002.0 && num5 != 2003.0 && num5 != 2005.0 && num5 != 2206.0 && num5 != 2207.0)
				{
					string text = "Operator is Russia. Service should be a vanilla type, not Red Star type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2088.0 && num5 != 2201.0 && num5 != 2202.0 && num5 != 2203.0 && num5 != 2204.0 && num5 != 2205.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 2208.0 && num5 != 2209.0 && num5 != 1003.0)
				{
					string text = "Operator is Soviet Union. Service should be one of the Cold War operators!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200109", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubmarineSonarSignatureModifierMatchesPropulsionTypeAndTonnage()
	{
		try
		{
			string name = "SELECT ID, Type, DisplacementStandard FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num2 = Conversions.ToLong(recordset2.Fields["DisplacementStandard"].Value);
				long num3 = Conversions.ToLong(recordset2.Fields["Type"].Value);
				DataRow? dataRow = Common.get_MiscSubmarine(Common.mySourceDB_Helper).Rows.Find(num);
				double num4 = Conversions.ToDouble(dataRow["ModifierPassiveSonar"]);
				double num5 = Conversions.ToDouble(dataRow["ModifierActiveSonar"]);
				DataRow[] array = Common.get_DataSubmarinePropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num6 = Conversions.ToLong(array2[i]["ComponentID"]);
					double num7 = Conversions.ToDouble(Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num6)["Type"]);
					if (num7 == 3001.0)
					{
						flag2 = true;
					}
					else if (num7 == 4001.0)
					{
						flag = true;
					}
					else if (num7 == 4002.0)
					{
						flag3 = true;
					}
					else if (num7 == 3004.0)
					{
						flag4 = true;
					}
					else if (num7 == 9001.0)
					{
						flag5 = true;
					}
				}
				if (num5 == 1001.0)
				{
					string text = "Active Sonar modifier is None which is not a legal option.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num5 == 2001.0 || num5 == 3001.0 || num5 == 4001.0) && (num2 < 0L || num2 > 500L))
				{
					string text = "Active Sonar Modifier says 0-500t Displacement, but Submarine std displacement is " + Conversions.ToString(num2) + "t!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num5 == 2002.0 || num5 == 3002.0 || num5 == 4002.0) && (num2 < 501L || num2 > 1500L))
				{
					string text = "Active Sonar Modifier says 501-1500t Displacement, but Submarine std displacement is " + Conversions.ToString(num2) + "t!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num5 == 2003.0 || num5 == 3003.0 || num5 == 4003.0) && (num2 < 1501L || num2 > 5000L))
				{
					string text = "Active Sonar Modifier says 1501-5000t Displacement, but Submarine std displacement is " + Conversions.ToString(num2) + "t!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num5 == 2004.0 || num5 == 3004.0 || num5 == 4004.0) && (num2 < 5001L || num2 > 10000L))
				{
					string text = "Active Sonar Modifier says 5001-10000t Displacement, but Submarine std displacement is " + Conversions.ToString(num2) + "t!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num5 == 2005.0 || num5 == 3005.0 || num5 == 4005.0) && (num2 < 10001L || num2 > 25000L))
				{
					string text = "Active Sonar Modifier says 10001-25000t Displacement, but Submarine std displacement is " + Conversions.ToString(num2) + "t!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 1001.0)
				{
					string text = "Passive Sonar modifier is None which is not a legal option.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 2001.0 && num4 < 3001.0 && !flag4)
				{
					string text = "Passive Sonar Modifier implies Nuclear Propulsion, but Submarine has no nuclear propulsion system!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 3001.0 && num4 < 4001.0 && !flag && !flag3 && num3 != 3001L)
				{
					string text;
					int num8;
					if (!flag)
					{
						text = "Passive Sonar Modifier implies Electric Propulsion, but Submarine has no electric propulsion system!";
						num8 = 9;
					}
					else
					{
						text = "Passive Sonar Modifier implies AIP Propulsion, but Submarine has no AIP propulsion system!";
						num8 = 9;
					}
					string[] array3 = new string[num8];
					array3[0] = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (";
					array3[1] = Conversions.ToString(num);
					array3[2] = ", ";
					array3[3] = Conversions.ToString(Convert.ToChar(34));
					array3[4] = "Submarine";
					array3[5] = Conversions.ToString(Convert.ToChar(34));
					array3[6] = ", '";
					array3[7] = text;
					array3[8] = "');";
					string string_ = string.Concat(array3);
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 3001.0 && num4 < 4001.0 && !flag2 && num3 != 3001L && num3 != 4001L && num3 != 4002L)
				{
					string text = "Passive Sonar Modifier implies Diesel Propulsion, but Submarine has no diesel propulsion system!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 8001.0 && num4 < 9001.0 && !flag5)
				{
					string text = "Passive Sonar Modifier implies Static Propulsion (False Trgt, Biologic), but Submarine has no static propulsion system!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200110", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubmarineHaveDatalinkDirectors()
	{
		try
		{
			string name = "SELECT ID FROM DataSubmarine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			long num10 = default(long);
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow[] array = Common.get_DataSubmarineComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				long[] array3 = new long[0];
				long num3 = 0L;
				long[] array4 = new long[0];
				long num4 = 0L;
				long[] array5 = new long[0];
				long num5 = 0L;
				bool flag = false;
				bool flag2 = false;
				DataRow[] array6 = array;
				bool flag3;
				checked
				{
					for (int i = 0; i < array6.Length; i++)
					{
						long num6 = Conversions.ToLong(array6[i]["ComponentID"]);
						DataRow? dataRow = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num6);
						long num7 = Conversions.ToLong(dataRow["Type"]);
						if (Conversions.ToBoolean(dataRow["WeaponLinkRequiresSensor"]) && num7 > 9000L)
						{
							flag = true;
							DataRow[] array7 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
							for (int j = 0; j < array7.Length; j++)
							{
								long num8 = Conversions.ToLong(array7[j]["ComponentID"]);
								unchecked
								{
									num2++;
									array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
									array2[(int)(num2 - 1L)] = num8;
								}
							}
						}
					}
					DataRow[] array8 = Common.get_DataSubmarineSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int k = 0; k < array8.Length; k++)
					{
						long num9 = Conversions.ToLong(array8[k]["ComponentID"]);
						unchecked
						{
							num3++;
							array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
							array3[(int)(num3 - 1L)] = num9;
						}
					}
					DataRow[] array9 = Common.get_DataSubmarineMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int l = 0; l < array9.Length; l++)
					{
						num10 = Conversions.ToLong(array9[l]["ComponentID"]);
						DataRow[] array10 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
						for (int m = 0; m < array10.Length; m++)
						{
							long num11 = Conversions.ToLong(array10[m]["ComponentID"]);
							unchecked
							{
								num5++;
								array5 = (long[])Utils.CopyArray((Array)array5, (Array)new long[(int)(num5 - 1L) + 1]);
								array5[(int)(num5 - 1L)] = num11;
							}
						}
						DataRow[] array11 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
						for (int n = 0; n < array11.Length; n++)
						{
							long num12 = Conversions.ToLong(array11[n]["ComponentID"]);
							DataRow? dataRow2 = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num12);
							long num13 = Conversions.ToLong(dataRow2["Type"]);
							if (Conversions.ToLong(dataRow2["WeaponLinkRequiresSensor"]) == -1L && num13 > 9001L)
							{
								flag2 = true;
								DataRow[] array12 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num12));
								for (int num14 = 0; num14 < array12.Length; num14++)
								{
									long num15 = Conversions.ToLong(array12[num14]["ComponentID"]);
									unchecked
									{
										num4++;
										array4 = (long[])Utils.CopyArray((Array)array4, (Array)new long[(int)(num4 - 1L) + 1]);
										array4[(int)(num4 - 1L)] = num15;
									}
								}
							}
						}
					}
					flag3 = false;
				}
				long num16 = num2 - 1L;
				for (long num17 = 0L; num17 <= num16; num17++)
				{
					long num18 = num3 - 1L;
					for (long num19 = 0L; num19 <= num18; num19++)
					{
						if (array2[(int)num17] == array3[(int)num19])
						{
							flag3 = true;
							break;
						}
					}
					long num20 = num5 - 1L;
					for (long num21 = 0L; num21 <= num20; num21++)
					{
						if (array2[(int)num17] == array5[(int)num21])
						{
							flag3 = true;
							recordset2.MoveNext();
							break;
						}
					}
					if (flag3)
					{
						break;
					}
				}
				long num22 = num4 - 1L;
				for (long num23 = 0L; num23 <= num22; num23++)
				{
					long num24 = num3 - 1L;
					for (long num25 = 0L; num25 <= num24; num25++)
					{
						if (array4[(int)num23] == array3[(int)num25])
						{
							flag3 = true;
							break;
						}
					}
					long num26 = num5 - 1L;
					for (long num27 = 0L; num27 <= num26; num27++)
					{
						if (array4[(int)num23] == array5[(int)num27])
						{
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						break;
					}
				}
				int num28;
				if (!flag2)
				{
					num28 = 0;
				}
				else if (!flag3)
				{
					string text = "Weapon datalink on mount " + Conversions.ToString(num10) + " requires a director (sensor) in order to send target updates to weapon.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num28 = 0;
				}
				else
				{
					num28 = 0;
				}
				bool flag4 = (byte)num28 != 0;
				long num29 = num2 - 1L;
				for (long num30 = 0L; num30 <= num29; num30++)
				{
					long num31 = num3 - 1L;
					for (long num32 = 0L; num32 <= num31; num32++)
					{
						if (array2[(int)num30] == array3[(int)num32])
						{
							flag4 = true;
							break;
						}
					}
					if (flag4)
					{
						break;
					}
				}
				if (flag && !flag4)
				{
					string text = "Weapon datalink requires a director (sensor) in order to send target updates to weapon.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200111", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSubmarineAircraftFacilities()
	{
		try
		{
			DataTable dataTable = Common.get_DataSubmarine(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				long num2 = 9999L;
				long num3 = 0L;
				long num4 = 9999L;
				long num5 = 0L;
				long num6 = 9999L;
				long num7 = 0L;
				bool flag = false;
				bool flag2 = false;
				DataRow[] array = Common.get_DataSubmarineAircraftFacilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					double num8 = Conversions.ToDouble(array[i]["ComponentID"]);
					DataRow? dataRow = Common.get_DataAircraftFacility(Common.mySourceDB_Helper).Rows.Find(num8);
					double num9 = Conversions.ToDouble(dataRow["Type"]);
					double num10 = Conversions.ToDouble(dataRow["PhysicalSize"]);
					double num11 = Conversions.ToDouble(dataRow["Capacity"]);
					Conversions.ToDouble(dataRow["RunwayLength"]);
					if (num9 == 3001.0 || num9 == 3002.0)
					{
						flag = true;
						if ((double)num2 > num10)
						{
							num2 = (long)Math.Round(num10);
						}
						if ((double)num3 < num10)
						{
							num3 = (long)Math.Round(num10);
						}
					}
					if (num9 == 4001.0)
					{
						flag2 = true;
						if ((double)num4 > num10)
						{
							num4 = (long)Math.Round(num10);
						}
						if ((double)num5 < num10)
						{
							num5 = (long)Math.Round(num10);
						}
						if ((double)num6 > num11)
						{
							num6 = (long)Math.Round(num11);
						}
						if ((double)num7 < num11)
						{
							num7 = (long)Math.Round(num11);
						}
					}
					if (num9 == 2001.0 || num9 == 2002.0 || num9 == 2003.0 || num9 == 2004.0 || num9 == 2005.0 || num9 == 2006.0 || num9 == 2007.0 || num9 == 4002.0 || num9 == 4003.0)
					{
						string text = "Aircraft Facility " + Conversions.ToString(num8) + " Is a land Or ship type, And should Not be used On Submarines!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag && !flag2)
				{
					string text = "Submarine has helo pad but no parking space (Open Parking or Hangar).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 != num5 && flag2)
				{
					string text = "All hangars on a Submarine should be of the same aircraft size!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > num3 && flag2 && flag)
				{
					string text = "Hangars may not be larger than the helicopter pads!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag2 && !flag)
				{
					string text = "Submarine has parking facilities for aircraft but no take-off facilities!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Submarine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200112", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateSub()
	{
		Class72.smethod_20();
	}
}
