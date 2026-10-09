using System;
using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateLoadout
{
	public static void ValidateLoadoutStats()
	{
		try
		{
			DataTable dataTable = Common.get_DataLoadout(Common.mySourceDB_Helper);
			foreach (DataRow row in dataTable.Rows)
			{
				int num = Conversions.ToInteger(row["ID"]);
				Common.StatusString = "ValidateLoadoutStats - Loadout #" + Conversions.ToString(num);
				bool flag = Conversions.ToBoolean(row["QuickTurnaround"]);
				int num2 = Conversions.ToInteger(row["QuickTurnaround_ReadyTime"]);
				int num3 = Conversions.ToInteger(row["QuickTurnaround_MaxSorties"]);
				int num4 = Conversions.ToInteger(row["QuickTurnaround_AdditionalTimePenalty"]);
				int num5 = Conversions.ToInteger(row["QuickTurnaround_AirborneTime"]);
				int num6 = Conversions.ToInteger(row["QuickTurnaround_TimeofDay"]);
				if (flag && (num2 == 0 || num3 == 0 || num5 == 0 || num6 == 1001))
				{
					string text = "Quick Turnaround has been enabled but one of the associated stats is 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 != 0 && (!flag || num3 == 0 || num5 == 0 || num6 == 1001))
				{
					string text = "Quick Turnaround Ready Time has been entered but one of the associated stats is missing.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 != 0 && (num2 == 0 || !flag || num5 == 0 || num6 == 1001))
				{
					string text = "Quick Turnaround Max Sorties has been entered but one of the associated stats is missing.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 != 0 && (num2 == 0 || num3 == 0 || !flag || num6 == 1001))
				{
					string text = "Quick Turnaround Airborne Time has been entered but one of the associated stats is missing.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 != 0 && (num5 == 0 || num2 == 0 || num3 == 0 || !flag))
				{
					string text = "Quick Turnaround Additional Time Penalty has been entered but one of the associated stats is missing.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 != 1001 && (num5 == 0 || num2 == 0 || num3 == 0 || !flag))
				{
					string text = "Quick Turnaround Time-of-Day has been entered but one of the associated stats is missing.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200052", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateLoadoutNames()
	{
		try
		{
			foreach (DataRow row in Common.get_DataLoadout(Common.mySourceDB_Helper).Rows)
			{
				int num = Conversions.ToInteger(row["ID"]);
				Common.StatusString = "ValidateLoadoutNames - Loadout #" + Conversions.ToString(num);
				DataRow? dataRow = Common.get_DataLoadout(Common.mySourceDB_Helper).Rows.Find(num);
				string text = "";
				string text2 = Conversions.ToString(dataRow["Name"]);
				text = Conversions.ToString(dataRow["Comments"]);
				int num2 = Strings.InStr(1, text2, "(", (CompareMethod)1);
				int num3 = Strings.InStr(1, text2, ")", (CompareMethod)1);
				int num4 = Strings.InStr(1, text2, "[", (CompareMethod)1);
				int num5 = Strings.InStr(1, text2, "]", (CompareMethod)1);
				int num6 = Strings.InStr(1, text2, "{", (CompareMethod)1);
				int num7 = Strings.InStr(1, text2, "}", (CompareMethod)1);
				int num8 = Strings.InStr(1, text, "(", (CompareMethod)1);
				int num9 = Strings.InStr(1, text, ")", (CompareMethod)1);
				int num10 = Strings.InStr(1, text, "[", (CompareMethod)1);
				int num11 = Strings.InStr(1, text, "]", (CompareMethod)1);
				int num12 = Strings.InStr(1, text, "{", (CompareMethod)1);
				int num13 = Strings.InStr(1, text, "}", (CompareMethod)1);
				if (num2 > 0 && num3 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 > 0 && num2 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 > 0 && num5 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num14;
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num14 = 1;
				}
				else
				{
					num14 = 1;
				}
				if (Strings.InStr(num14, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num15;
				if (!(num13 > 0 && num12 == 0))
				{
					num15 = 1;
				}
				else
				{
					string text3 = "Found a right \"}\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num15 = 1;
				}
				int num16;
				if (Strings.InStr(num15, text, "|", (CompareMethod)1) <= 0)
				{
					num16 = 1;
				}
				else
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				int num17;
				if (!((Strings.InStr(num16, text2, "KT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "KT)", (CompareMethod)0) > 0)))
				{
					num17 = 1;
				}
				else
				{
					string text3 = "Kiloton should say \"kT\" and not \"KT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				int num18;
				if (!((Strings.InStr(num17, text2, "kt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "kt)", (CompareMethod)0) > 0)))
				{
					num18 = 1;
				}
				else
				{
					string text3 = "Kiloton should say \"kT\" and not \"kt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				int num19;
				if ((Strings.InStr(num18, text2, "MT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MT)", (CompareMethod)0) > 0))
				{
					string text3 = "Megaton should say \"mT\" and not \"MT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				else
				{
					num19 = 1;
				}
				int num20;
				if (!((Strings.InStr(num19, text2, "mt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mt)", (CompareMethod)0) > 0)))
				{
					num20 = 1;
				}
				else
				{
					string text3 = "Megaton should say \"mT\" and not \"mt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if (!((Strings.InStr(num20, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0)))
				{
					num21 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				int num22;
				if ((Strings.InStr(num21, text2, "MK ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num22 = 1;
				}
				else
				{
					num22 = 1;
				}
				int num23;
				if (!((Strings.InStr(num22, text2, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) > 0)))
				{
					num23 = 1;
				}
				else
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num23 = 1;
				}
				int num24;
				if (!((Strings.InStr(num23, text2, "AGM ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "AIM ", (CompareMethod)0) > 0)))
				{
					num24 = 1;
				}
				else
				{
					string text3 = "AGM/AIM designations should use dashes \"-\" in the name, not spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num24 = 1;
				}
				int num25;
				if (Strings.InStr(num24, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num25 = 1;
				}
				else
				{
					num25 = 1;
				}
				int num26;
				if (Strings.InStr(num25, text2, "//", (CompareMethod)1) <= 0)
				{
					num26 = 1;
				}
				else
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num26 = 1;
				}
				int num27;
				if (Strings.InStr(num26, text, "  ", (CompareMethod)1) <= 0)
				{
					num27 = 1;
				}
				else
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num27 = 1;
				}
				if (Strings.InStr(num27, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200053", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateLoadoutRoleVsProfile()
	{
		try
		{
			DataRow[] array = Common.get_DataLoadout(Common.mySourceDB_Helper).Select("ID > 4");
			int num17 = default(int);
			int num24 = default(int);
			double num29 = default(double);
			double num23 = default(double);
			foreach (DataRow obj in array)
			{
				int num = Conversions.ToInteger(obj["ID"]);
				Common.StatusString = "ValidateLoadoutRoleVsProfile - Loadout #" + Conversions.ToString(num);
				int num2 = Conversions.ToInteger(obj["LoadoutRole"]);
				int num3 = Conversions.ToInteger(obj["DefaultMissionProfile"]);
				Conversions.ToInteger(obj["DefaultTimeOnStation"]);
				Conversions.ToInteger(obj["DefaultCombatRadius"]);
				double num4 = Conversions.ToDouble(obj["PayloadWeightDragModifier"]);
				DataRow dataRow = Common.get_EnumLoadoutMissionProfile(Common.mySourceDB_Helper).Rows.Find(num3);
				if (!Information.IsNothing((object)dataRow))
				{
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					bool flag = false;
					num5 = Conversions.ToDouble(dataRow["CruiseAltitudeIngress"]);
					num6 = Conversions.ToDouble(dataRow["CruiseAltitudeEgress"]);
					num7 = Conversions.ToDouble(dataRow["CruiseThrottleSettingIngress"]);
					num8 = Conversions.ToDouble(dataRow["CruiseThrottleSettingEgress"]);
					bool num15 = Conversions.ToBoolean(dataRow["CruiseAtOptimumAltitude"]);
					num9 = Conversions.ToDouble(dataRow["AttackAltitudeEgress"]);
					num10 = Conversions.ToDouble(dataRow["AttackAltitudeIngress"]);
					num11 = Conversions.ToDouble(dataRow["AttackThrottleSetting"]);
					num12 = Conversions.ToDouble(dataRow["StationAltitude"]);
					Conversions.ToDouble(dataRow["StationThrottleSetting"]);
					num13 = Conversions.ToDouble(dataRow["CombatAltitude"]);
					num14 = Conversions.ToDouble(dataRow["CombatThrottleSetting"]);
					double num32;
					checked
					{
						if (!num15)
						{
							DataRow[] array2 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ComponentID =" + Conversions.ToString(num));
							int num16 = 0;
							num17 = 0;
							int num18 = 0;
							int num19 = 0;
							bool flag2 = true;
							bool flag3 = true;
							if (array2.Length > 0)
							{
								flag = true;
							}
							DataRow[] array3 = array2;
							for (int j = 0; j < array3.Length; j++)
							{
								int num20 = Conversions.ToInteger(array3[j]["ID"]);
								if (num16 == 0)
								{
									num16 = num20;
								}
								DataRow[] array4 = Common.get_DataAircraftPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num20));
								for (int k = 0; k < array4.Length; k++)
								{
									int num21 = Conversions.ToInteger(array4[k]["ComponentID"]);
									if (flag3)
									{
										num17 = num21;
										flag3 = false;
										DataRow[] array5 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num21));
										double num22 = 0.0;
										num23 = 0.0;
										num24 = 0;
										DataRow[] array6 = array5;
										foreach (DataRow obj2 in array6)
										{
											_ = (double)Conversions.ToInteger(obj2["Speed"]);
											double num25 = Conversions.ToDouble(obj2["AltitudeBand"]);
											double num26 = Conversions.ToDouble(obj2["Throttle"]);
											Conversions.ToDouble(obj2["Consumption"]);
											double num27 = Conversions.ToDouble(obj2["AltitudeMin"]);
											double num28 = Conversions.ToDouble(obj2["AltitudeMax"]);
											if (num25 == 1.0)
											{
												if (num26 == 1.0)
												{
													continue;
												}
												if (num26 == 2.0)
												{
													if (num24 < 2)
													{
														num24 = 2;
													}
												}
												else if (num26 == 3.0)
												{
													if (num22 < 1.0)
													{
														num22 = 1.0;
														num29 = num27;
														num23 = num28;
													}
													if (num24 < 3)
													{
														num24 = 3;
													}
												}
												else if (num26 == 4.0 && num24 < 4)
												{
													num24 = 4;
												}
											}
											else if (num25 == 2.0)
											{
												if (num26 == 1.0)
												{
													continue;
												}
												if (num26 == 2.0)
												{
													if (num22 < 2.0)
													{
														num22 = 2.0;
														num29 = num27;
														num23 = num28;
													}
													if (num24 < 2)
													{
														num24 = 2;
													}
												}
												else if (num26 == 3.0)
												{
													if (num24 < 3)
													{
														num24 = 3;
													}
												}
												else if (num26 == 4.0 && num24 < 4)
												{
													num24 = 4;
												}
											}
											else if (num25 == 3.0)
											{
												if (num26 == 1.0)
												{
													continue;
												}
												if (num26 == 2.0)
												{
													if (num22 < 3.0)
													{
														num22 = 3.0;
														num29 = num27;
														num23 = num28;
													}
													if (num24 < 2)
													{
														num24 = 2;
													}
												}
												else if (num26 == 3.0)
												{
													if (num24 < 3)
													{
														num24 = 3;
													}
												}
												else if (num26 == 4.0 && num24 < 4)
												{
													num24 = 4;
												}
											}
											else
											{
												if (num25 != 4.0 || num26 == 1.0)
												{
													continue;
												}
												if (num26 == 2.0)
												{
													if (num22 < 4.0)
													{
														num22 = 4.0;
														num29 = num27;
														num23 = num28;
													}
													if (num24 < 2)
													{
														num24 = 2;
													}
												}
												else if (num26 == 3.0)
												{
													if (num24 < 3)
													{
														num24 = 3;
													}
												}
												else if (num26 == 4.0 && num24 < 4)
												{
													num24 = 4;
												}
											}
										}
										num29 /= 0.3048;
										num23 /= 0.3048;
										num29 = 0.0 - Conversion.Int(0.0 - num29);
										num23 = 0.0 - Conversion.Int(0.0 - num23);
									}
									if (num17 != num21)
									{
										string text = "Loadout users have different engines! Aircraft " + Conversions.ToString(num16) + " uses engine " + Conversions.ToString(num17) + " while aircraft " + Conversions.ToString(num20) + " uses engine " + Conversions.ToString(num21) + "! This will cause problems for the fuel consumption auto-calculator!";
										string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
										Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									}
								}
								DataRow[] array7 = Common.get_DataAircraftFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num20));
								for (int m = 0; m < array7.Length; m++)
								{
									int num30 = Conversions.ToInteger(array7[m]["ComponentID"]);
									int num31 = Conversions.ToInteger(Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num30)["Capacity"]);
									if (flag2)
									{
										num19 = num31;
										num18 = num30;
										flag2 = false;
									}
									if (num31 != num19)
									{
										string text = "Loadout users have different fuel capacity! Aircraft " + Conversions.ToString(num16) + " uses fuel entry " + Conversions.ToString(num18) + " (" + Conversions.ToString(num19) + "kg) while aircraft " + Conversions.ToString(num20) + " uses fuel entry " + Conversions.ToString(num30) + " (" + Conversions.ToString(num31) + "kg)! This will cause problems for the fuel consumption auto-calculator!";
										string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
										Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									}
								}
							}
						}
						DataRow[] array8 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
						num32 = 0.0;
						DataRow[] array9 = array8;
						for (int n = 0; n < array9.Length; n++)
						{
							int num33 = Conversions.ToInteger(array9[n]["ComponentID"]);
							DataRow[] array10 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num33));
							for (int num34 = 0; num34 < array10.Length; num34++)
							{
								int num35 = Conversions.ToInteger(array10[num34]["ComponentID"]);
								double num36 = Conversions.ToDouble(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num35)["Weight"]);
								num32 += num36;
							}
						}
					}
					if (num4 <= 0.0 && num32 > 0.0 && num2 != 9004)
					{
						string text = "Payload/Drag modifier is 0 while Payload is > 0kg. This makes no sense, something is wrong with the profile or payload.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num5) + "ft Cruise Altitude (Ingress) while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num6) + " ft Cruise Altitude (Egress) while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num10) + " ft Attack Altitude (Ingress) while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num9) + " ft Attack Altitude (Egress) while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num12) + " ft Station Altitude while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num12) + " ft Station Altitude while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num13 > num23 && flag)
					{
						string text = "The Loadout Profile has a " + Conversions.ToString(num13) + " ft Combat Altitude while engine " + Conversions.ToString(num17) + " has a max altitude of " + Conversions.ToString(num23) + "ft !";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 > (double)num24 && flag)
					{
						string text = "The Loadout Profile has higher Cruise Throttle (Ingress) setting than engine " + Conversions.ToString(num17) + "!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 > (double)num24 && flag)
					{
						string text = "The Loadout Profile has higher Cruise Throttle (Egress) setting than engine " + Conversions.ToString(num17) + "!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 > (double)num24 && flag)
					{
						string text = "The Loadout Profile has higher Attack Throttle setting than engine " + Conversions.ToString(num17) + "!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num14 > (double)num24 && flag)
					{
						string text = "The Loadout Profile has higher Combat Throttle setting than engine " + Conversions.ToString(num17) + "!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 2001 && num2 <= 2999 && (num3 < 2001 || num3 > 2999) && num3 != 8901)
					{
						string text = "Loadout Role says Air Intercept. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((num2 >= 3001 && num2 <= 3399) || num2 == 7003) && (num3 < 3001 || num3 > 3399) && num3 != 4301 && num3 != 7001 && num3 != 7002 && num3 != 7003 && num3 != 7004 && num3 != 7005)
					{
						string text = "Loadout Role says Strike. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 3401 && num2 <= 3499 && (num3 < 3001 || num3 > 3499))
					{
						string text = "Loadout Role says BAI/CAS. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4001 && (num3 < 4001 || num3 > 4005))
					{
						string text = "Loadout Role says Offensive ECM. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4004 && (num3 < 4006 || num3 > 4010))
					{
						string text = "Loadout Role says Chaff Dispenser. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4002 && (num3 < 4011 || num3 > 4016))
					{
						string text = "Loadout Role says Airborne Early Warning. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4003 && (num3 < 4016 || num3 > 4020))
					{
						string text = "Loadout Role says Airborne Command Post. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4101 && (num3 < 6201 || num3 > 6206))
					{
						string text = "Loadout Role says Search And Rescue. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4102 && (num3 < 6201 || num3 > 6206))
					{
						string text = "Loadout Role says Combat Search And Rescue. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4201 && (num3 < 4201 || num3 > 4206))
					{
						string text = "Loadout Role says Mine Sweep. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4202 && (num3 < 4201 || num3 > 4206))
					{
						string text = "Loadout Role says Mine Reconnaissance. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 6001 && num2 <= 6099 && (num3 < 6001 || num3 > 6099))
					{
						string text = "Loadout Role says ASW. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 7001 && num2 <= 7099 && num2 != 7003 && num2 != 7005 && (num3 < 7101 || num3 > 7299))
					{
						string text = "Loadout Role says Recon. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 7005 && (num3 < 6101 || num3 > 6199))
					{
						string text = "Loadout Role says Maritime Surveillance. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 7101 && num2 <= 7299 && (num3 < 8001 || num3 > 8099))
					{
						string text = "Loadout Role says Transport. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 8001 && (num3 < 8101 || num3 > 8106))
					{
						string text = "Loadout Role says Air Refueling. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 8101 && (num3 < 8201 || num3 > 8206))
					{
						string text = "Loadout Role says Training. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 8102 && (num3 < 8301 || num3 > 8305))
					{
						string text = "Loadout Role says Target Tow. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 8103 && (num3 < 8306 || num3 > 8310))
					{
						string text = "Loadout Role says Target Drone. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 9001 && (num3 < 9001 || num3 > 9005))
					{
						string text = "Loadout Role says Ferry. Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else
				{
					string text = "Unable to find mission profile with ID: " + Conversions.ToString(num3);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200055", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateLoadout()
	{
		Class72.smethod_20();
	}
}
