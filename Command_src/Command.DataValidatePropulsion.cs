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
internal sealed class DataValidatePropulsion
{
	public static void ValidatePropulsionNames()
	{
		try
		{
			string name = "SELECT ID FROM DataPropulsion";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow? dataRow = Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 > 0 && num2 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 > 0 && num5 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num14;
				if (!(num7 > 0 && num6 == 0))
				{
					num14 = 1;
				}
				else
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num14 = 1;
				}
				if (Strings.InStr(num14, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num15 = 1;
				}
				int num16;
				if (Strings.InStr(num15, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				else
				{
					num16 = 1;
				}
				int num17;
				if ((Strings.InStr(num16, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				else
				{
					num17 = 1;
				}
				int num18;
				if (!((Strings.InStr(num17, text2, "MK ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK1", (CompareMethod)0) > 0)))
				{
					num18 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				int num19;
				if (!((Strings.InStr(num18, text2, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) > 0)))
				{
					num19 = 1;
				}
				else
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				int num20;
				if (Strings.InStr(num19, text2, "  ", (CompareMethod)1) <= 0)
				{
					num20 = 1;
				}
				else
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if (Strings.InStr(num20, text2, "//", (CompareMethod)1) <= 0)
				{
					num21 = 1;
				}
				else
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				int num22;
				if (Strings.InStr(num21, text, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
			ex2.Data.Add("Error at Validation 200072", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidatePropulsionStats()
	{
		try
		{
			string name = "SELECT ID, Type, Name FROM DataPropulsion";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num2 = Conversions.ToLong(recordset2.Fields["Type"].Value);
				double num3 = 0.0;
				double num4 = 0.0;
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
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = 0.0;
				double num20 = 0.0;
				double num21 = 0.0;
				double num22 = 0.0;
				double num23 = 0.0;
				double num24 = 0.0;
				double num25 = 0.0;
				double num26 = 0.0;
				double num27 = 0.0;
				double num28 = 0.0;
				double num29 = 0.0;
				double num30 = 0.0;
				double num31 = 0.0;
				double num32 = 0.0;
				double num33 = 0.0;
				double num34 = 0.0;
				double num35 = 0.0;
				double num36 = 0.0;
				double num37 = 0.0;
				double num38 = 0.0;
				double num39 = 0.0;
				double num40 = 0.0;
				double num41 = 0.0;
				double num42 = 0.0;
				double num43 = 0.0;
				double num44 = 0.0;
				double num45 = 0.0;
				double num46 = 0.0;
				double num47 = 0.0;
				double num48 = 0.0;
				double num49 = 0.0;
				double num50 = 0.0;
				double num51 = 0.0;
				double num52 = 0.0;
				double num53 = 0.0;
				double num54 = 0.0;
				double num55 = 0.0;
				double num56 = 0.0;
				double num57 = 0.0;
				double num58 = 0.0;
				double num59 = 0.0;
				double num60 = 0.0;
				double num61 = 0.0;
				double num62 = 0.0;
				double num63 = 0.0;
				double num64 = 0.0;
				double num65 = 0.0;
				double num66 = 0.0;
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
				bool flag15 = false;
				bool flag16 = false;
				bool flag17 = false;
				bool flag18 = false;
				DataRow[] array = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long num67 = 0L;
				DataRow[] array2 = array;
				foreach (DataRow obj in array2)
				{
					double num68 = Conversions.ToDouble(obj["AltitudeMax"]);
					double num69 = Conversions.ToDouble(obj["AltitudeMin"]);
					double num70 = Conversions.ToDouble(obj["Speed"]);
					double num71 = Conversions.ToDouble(obj["AltitudeBand"]);
					double num72 = Conversions.ToDouble(obj["Throttle"]);
					double num73 = Conversions.ToDouble(obj["Consumption"]);
					if (num71 == 1.0)
					{
						if ((double)num67 < num71)
						{
							num67 = (long)Math.Round(num71);
						}
						if (num72 == 1.0)
						{
							num3 = num70;
							num19 = num69;
							num35 = num68;
							num51 = num73;
							flag = true;
						}
						else if (num72 == 2.0)
						{
							num4 = num70;
							num20 = num69;
							num36 = num68;
							num52 = num73;
							flag2 = true;
						}
						else if (num72 == 3.0)
						{
							num5 = num70;
							num21 = num69;
							num37 = num68;
							flag3 = true;
							num53 = num73;
						}
						else if (num72 == 4.0)
						{
							num6 = num70;
							num22 = num69;
							num38 = num68;
							num54 = num73;
							flag4 = true;
						}
					}
					else if (num71 == 2.0)
					{
						if ((double)num67 < num71)
						{
							num67 = (long)Math.Round(num71);
						}
						if (num72 == 1.0)
						{
							num7 = num70;
							num23 = num69;
							num39 = num68;
							flag5 = true;
							num55 = num73;
						}
						else if (num72 == 2.0)
						{
							num8 = num70;
							num24 = num69;
							num40 = num68;
							flag6 = true;
							num56 = num73;
						}
						else if (num72 == 3.0)
						{
							num9 = num70;
							num25 = num69;
							num41 = num68;
							flag7 = true;
							num57 = num73;
						}
						else if (num72 == 4.0)
						{
							num10 = num70;
							num26 = num69;
							num42 = num68;
							num58 = num73;
							flag8 = true;
						}
					}
					else if (num71 == 3.0)
					{
						if ((double)num67 < num71)
						{
							num67 = (long)Math.Round(num71);
						}
						if (num72 == 1.0)
						{
							num11 = num70;
							num27 = num69;
							num43 = num68;
							flag9 = true;
							num59 = num73;
						}
						else if (num72 == 2.0)
						{
							num12 = num70;
							num28 = num69;
							num44 = num68;
							flag10 = true;
							num60 = num73;
						}
						else if (num72 == 3.0)
						{
							num13 = num70;
							num29 = num69;
							num45 = num68;
							flag11 = true;
							num61 = num73;
						}
						else if (num72 == 4.0)
						{
							num14 = num70;
							num30 = num69;
							num46 = num68;
							num62 = num73;
							flag12 = true;
						}
					}
					else if (num71 == 4.0)
					{
						if ((double)num67 < num71)
						{
							num67 = (long)Math.Round(num71);
						}
						if (num72 == 1.0)
						{
							num15 = num70;
							num31 = num69;
							num47 = num68;
							flag13 = true;
							num63 = num73;
						}
						else if (num72 == 2.0)
						{
							num16 = num70;
							num32 = num69;
							num48 = num68;
							num64 = num73;
							flag14 = true;
						}
						else if (num72 == 3.0)
						{
							num17 = num70;
							num33 = num69;
							num49 = num68;
							num65 = num73;
							flag15 = true;
						}
						else if (num72 == 4.0)
						{
							num18 = num70;
							num34 = num69;
							num50 = num68;
							num66 = num73;
							flag16 = true;
						}
					}
				}
				if (flag)
				{
					if (num3 > num4 && flag2)
					{
						string text = "AltitudeBand1 Loiter Speed is higher than AltitudeBand1 Cruise Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num19 > num35)
					{
						string text = "AltitudeBand1 Loiter Speed Minimum Altitude is greater than AltitudeBand1 Loiter Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 > num23 && flag6)
					{
						string text = "AltitudeBand1 Loiter Speed Maxium Altitude is greater than AltitudeBand2 Loiter Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num51 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand1 Loiter Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag2)
				{
					if (num4 > num5 && flag3)
					{
						string text = "AltitudeBand1 Cruise Speed is higher than AltitudeBand1 Full Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num20 > num36)
					{
						string text = "AltitudeBand1 Cruise Speed Minimum Altitude is greater than AltitudeBand1 Cruise Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 > num24 && flag6)
					{
						string text = "AltitudeBand1 Cruise Speed Maximum Altitude is greater than AltitudeBand2 Cruise Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num52 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand1 Cruise Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag3)
				{
					if (num5 > num6 && flag4)
					{
						string text = "AltitudeBand1 Full Speed is higher than AltitudeBand1 Flank/Reheat Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num21 > num37)
					{
						string text = "AltitudeBand1 Full Speed Minimum Altitude is greater than AltitudeBand1 Full Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > num25 && flag7)
					{
						string text = "AltitudeBand1 Full Speed Maximum Altitude is greater than AltitudeBand2 Full Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num53 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand1 Full Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag4)
				{
					if (num22 > num38)
					{
						string text = "AltitudeBand1 Flank Speed Minimum Altitude is greater than AltitudeBand1 Flank Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num54 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand1 Flank/Reheat Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num53 > num54)
					{
						string text = "AltitudeBand1 Full/Military fuel consumption is higher than Flank/Reheat fuel consumption ";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag5)
				{
					if (num7 > num8 && flag6)
					{
						string text = "AltitudeBand2 Loiter Speed is higher than AltitudeBand2 Cruise Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num23 > num39)
					{
						string text = "AltitudeBand2 Loiter Speed Minimum Altitude is greater than AltitudeBand2 Loiter Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 > num27 && flag9)
					{
						string text = "AltitudeBand2 Loiter Speed Maxium Altitude is greater than AltitudeBand3 Loiter Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num55 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand2 Loiter Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag6)
				{
					if (num8 > num9 && flag7)
					{
						string text = "AltitudeBand2 Cruise Speed is higher than AltitudeBand2 Full Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num24 > num40)
					{
						string text = "AltitudeBand2 Cruise Speed Minimum Altitude is greater than AltitudeBand2 Cruise Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num40 > num28 && flag10)
					{
						string text = "AltitudeBand2 Cruise Speed Maximum Altitude is greater than AltitudeBand3 Cruise Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num56 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand2 Cruise Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag7)
				{
					if (num9 > num10 && flag8)
					{
						string text = "AltitudeBand2 Full Speed is higher than AltitudeBand2 Flank/Reheat Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num25 > num41)
					{
						string text = "AltitudeBand2 Full Speed Minimum Altitude is greater than AltitudeBand2 Full Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num41 > num29 && flag11)
					{
						string text = "AltitudeBand2 Full Speed Maximum Altitude is greater than AltitudeBand2 Full Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num57 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand2 Full Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag8)
				{
					if (num26 > num42)
					{
						string text = "AltitudeBand2 Flank Speed Minimum Altitude is greater than AltitudeBand2 Flank Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num58 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand2 Flank/Reheat Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num57 >= num58)
					{
						string text = "AltitudeBand2 Full/Military fuel consumption is higher than Flank/Reheat fuel consumption ";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag9)
				{
					if (num11 > num12 && flag10)
					{
						string text = "AltitudeBand3 Loiter Speed is higher than AltitudeBand3 Cruise Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num27 > num43)
					{
						string text = "AltitudeBand3 Loiter Speed Minimum Altitude is greater than AltitudeBand3 Loiter Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num43 > num31 && flag13)
					{
						string text = "AltitudeBand3 Loiter Speed Maxium Altitude is greater than AltitudeBand4 Loiter Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num59 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand3 Loiter Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag10)
				{
					if (num12 > num13 && flag11)
					{
						string text = "AltitudeBand3 Cruise Speed is higher than AltitudeBand3 Full Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num28 > num44)
					{
						string text = "AltitudeBand3 Cruise Speed Minimum Altitude is greater than AltitudeBand3 Cruise Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num44 > num32 && flag14)
					{
						string text = "AltitudeBand3 Cruise Speed Maximum Altitude is greater than AltitudeBand4 Cruise Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num60 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand3 Cruise Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag11)
				{
					if (num13 > num14 && flag12)
					{
						string text = "AltitudeBand3 Full Speed is higher than AltitudeBand3 Flank/Reheat Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num13 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num29 > num45)
					{
						string text = "AltitudeBand3 Full Speed Minimum Altitude is greater than AltitudeBand3 Full Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num45 > num33 && flag15)
					{
						string text = "AltitudeBand2 Full Speed Maximum Altitude is greater than AltitudeBand2 Full Speed Minimum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num61 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand3 Full Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag12)
				{
					if (num30 > num46)
					{
						string text = "AltitudeBand3 Flank Speed Minimum Altitude is greater than AltitudeBand3 Flank Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num14 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num62 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand3 Flank/Reheat Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num61 >= num62)
					{
						string text = "AltitudeBand3 Full/Military fuel consumption is higher than Flank/Reheat fuel consumption ";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag13)
				{
					if (num15 > num16 && flag14)
					{
						string text = "AltitudeBand4 Loiter Speed is higher than AltitudeBand4 Cruise Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num15 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num31 > num47)
					{
						string text = "AltitudeBand4 Loiter Speed Minimum Altitude is greater than AltitudeBand4 Loiter Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand4 Loiter Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag14)
				{
					if (num16 > num17 && flag15)
					{
						string text = "AltitudeBand4 Cruise Speed is higher than AltitudeBand4 Full Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num16 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num32 > num48)
					{
						string text = "AltitudeBand4 Cruise Speed Minimum Altitude is greater than AltitudeBand4 Cruise Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num64 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand4 Cruise Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag15)
				{
					if (num17 > num18 && flag16)
					{
						string text = "AltitudeBand4 Full Speed is higher than AltitudeBand4 Flank/Reheat Speed";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num17 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num33 > num49)
					{
						string text = "AltitudeBand4 Full Speed Minimum Altitude is greater than AltitudeBand4 Full Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num65 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand4 Full Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag16)
				{
					if (num34 > num50)
					{
						string text = "AltitudeBand4 Flank Speed Minimum Altitude is greater than AltitudeBand4 Flank Speed Maximum Altitude";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num18 == 0.0)
					{
						flag17 = true;
					}
					else
					{
						flag18 = true;
					}
					if (num66 <= 0.0 && num2 != 3004L && num2 != 9001L)
					{
						string text = "AltitudeBand4 Flank/Reheat Speed is in use but has no fuel consumption";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num65 >= num66)
					{
						string text = "AltitudeBand4 Full/Military fuel consumption is higher than Flank/Reheat fuel consumption ";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (flag17 && flag18)
				{
					string text = "Speed is 0 for one altitude band but greater than 0 for others. This makes no sense.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2001L || num2 == 2002L || num2 == 2003L || num2 == 2005L || num2 == 2004L)
				{
					bool flag19 = false;
					bool flag20 = true;
					bool flag21 = false;
					bool flag22 = false;
					bool flag23 = false;
					bool flag24 = false;
					bool flag25 = false;
					bool flag26 = false;
					DataRow[] array3 = Common.get_DataAircraftPropulsion(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num));
					long num74 = 0L;
					bool flag27 = false;
					bool flag28 = false;
					bool flag29 = false;
					long num75 = 0L;
					long num76 = 0L;
					string text2 = "";
					long num77 = 0L;
					long num78 = 0L;
					long num79 = 0L;
					bool flag30 = false;
					if (array3.Length > 0)
					{
						DataRow[] array4 = array3;
						for (int j = 0; j < array4.Length; j = checked(j + 1))
						{
							num74 = Conversions.ToLong(array4[j]["ID"]);
							num76 = 0L;
							num77 = 0L;
							num79 = -1L;
							flag29 = true;
							flag27 = false;
							text2 = "";
							flag28 = false;
							num75 = 0L;
							bool flag31 = false;
							DataRow? dataRow = Common.get_MiscAircraft(Common.mySourceDB_Helper).Rows.Find(num74);
							flag27 = Conversions.ToBoolean(dataRow["Supercruise"]);
							text2 = Conversions.ToString(dataRow["FullName"]);
							if (Strings.InStr(1, text2, "AS-2", (CompareMethod)1) == 0)
							{
								if (flag29)
								{
									flag29 = false;
									num75 = num74;
									flag28 = flag27;
								}
								if (flag27)
								{
									flag19 = true;
								}
								if (flag27 != flag28)
								{
									string text = "The supercruise flag is only for some of the engine users. Aircraft " + Conversions.ToString(num74) + " has the super cruise flag to " + Conversions.ToString(flag27) + " while aircraft " + Conversions.ToString(num75) + " has the flag to " + Conversions.ToString(flag28);
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								DataRow[] array5 = Common.get_DataAircraftCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num74));
								for (int k = 0; k < array5.Length; k = checked(k + 1))
								{
									num76 = Conversions.ToLong(array5[k]["CodeID"]);
									if (num76 == 9121L || num76 == 9122L || num76 == 9123L || num76 == 9124L)
									{
										flag22 = true;
									}
									if (num76 > 9100L && num76 < 9200L && num79 == 0L)
									{
										num78 = num76;
									}
									if (num76 > 9100L && num76 < 9200L && num79 == -1L)
									{
										num79 = 0L;
										num77 = num76;
									}
									if (num76 == 9186L)
									{
										flag24 = true;
									}
									if (num76 == 9185L)
									{
										flag25 = true;
									}
									if (num76 == 9101L || num76 == 9102L || num76 == 9103L || num76 == 9104L || num76 == 9111L || num76 == 9112L || num76 == 9113L || num76 == 9114L)
									{
										flag20 = false;
									}
									if (num76 == 9191L || num76 == 9192L)
									{
										flag31 = true;
									}
									if (num76 == 9124L)
									{
										flag22 = true;
									}
								}
								if (num78 != num77 && num74 != num75)
								{
									string text = "The Fuselage Structure flag is NOT identical for all engine users. Aircraft " + Conversions.ToString(num74) + " has flag " + Conversions.ToString(num78) + " while aircraft " + Conversions.ToString(num75) + " has flag " + Conversions.ToString(num77);
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								DataRow? dataRow2 = Common.get_DataAircraft(Common.mySourceDB_Helper).Rows.Find(num74);
								long num80 = Conversions.ToLong(dataRow2["Type"]);
								long num81 = Conversions.ToLong(dataRow2["Category"]);
								if (!flag21 && (num80 == 2001L || num80 == 2002L || num80 == 2101L || num80 == 3001L || num80 == 3002L || num80 == 3401L || num80 == 4001L || num80 == 8101L || num80 == 8202L || num80 == 8103L))
								{
									flag20 = false;
								}
								if (flag21 || num80 == 7101L || num80 == 4002L || num80 == 4003L || num80 == 6002L || num80 == 6001L || num80 == 7201L || num80 == 7301L || num80 == 7302L || num80 == 7401L || num80 == 7402L)
								{
									flag21 = true;
									flag20 = true;
								}
								if (num80 == 3101L && !flag31)
								{
									flag22 = true;
								}
								if (num80 == 7301L || num80 == 7302L)
								{
									flag23 = true;
								}
								if (num81 == 2004L)
								{
									flag26 = true;
								}
							}
							else
							{
								flag30 = true;
							}
						}
					}
					if ((!flag22 && flag23 && num4 > 250.0) & (array3.Length != 0))
					{
						string text = "Wack value: No civilian or commercial aircraft have a cruise speed exceeding 250kt at low level!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((!flag22 && flag23 && num4 > 290.0) & (array3.Length != 0))
					{
						string text = "Wack value: No civilian or commercial aircraft have a full speed exceeding 290kt at low level!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((num2 != 2005L && num2 != 2004L) & (array3.Length != 0)) && !flag26)
					{
						if (flag16 || flag19)
						{
							if (num17 != num13 - 30.0 && !flag19 && num18 > 700.0)
							{
								string text = "Engine for high-performance supersonic aircraft. Military speed at Altitude Band 3 must be 30kt higher than Military speed at Altitude Band 4!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 != num13 - 20.0 && !flag19 && num18 <= 700.0)
							{
								string text = "Engine for low-performance supersonic aircraft. Military speed at Altitude Band 3 must be 20kt higher than Military speed at Altitude Band 4!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 < num13 + 50.0 && flag19)
							{
								string text = "Engine for SUPERCRUISING aircraft. Military speed at Altitude Band 4 must be minimum 50kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 < 600.0 && flag19)
							{
								string text = "Aircraft using this engine can supercruise, the speed at Altitude Band 4 must be minimum 600kt!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 > 590.0 && !flag19)
							{
								string text = "Aircraft using this engine can NOT supercruise, the speed at Altitude Band 4 must be less than 590kt!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num12)
							{
								string text = "Engine for fast aircraft. Use same cruise speed across all altitude bands, this is fairly realistic and eases strike planning!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num11)
							{
								string text = "Engine for fast aircraft. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag16)
							{
								if (num18 != num14 + 120.0 && !flag19 && num18 >= 920.0 && num18 < 1350.0 && num18 != 1150.0 && num18 != 1160.0 && num6 + 120.0 != num18)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 920kt+. Afterburner speed at Altitude Band 4 must be 120kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num18 != num14 + 130.0 && !flag19 && num18 == 1150.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 1150kt. Afterburner speed at Altitude Band 4 must be 130kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num18 != num14 + 40.0 && !flag19 && num18 >= 920.0 && num18 < 1350.0 && (num6 + 80.0 == num18 || num6 + 120.0 == num18))
								{
									string text = "Engine for high-performance supersonic aircraft with high-speed low-altitude penetration capabilities, max speed 920kt+. Afterburner speed at Altitude Band 4 must be 40kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num18 < num14 + 400.0 && !flag19 && num18 >= 1350.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 1350kt+. Afterburner speed at Altitude Band 4 must be minimum 400kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num18 != num14 + 50.0 && !flag19 && num18 > 700.0 && num18 < 920.0 && num6 + 80.0 != num18)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 700-920kt. Afterburner speed at Altitude Band 4 must be 50kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num18 != num14 + 30.0 && !flag19 && num18 <= 700.0 && num18 > 590.0)
								{
									string text = "Engine for low-performance supersonic aircraft, max speed 700kt. Afterburner speed at Altitude Band 4 must be 30kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num18 != num14 - 30.0 && !flag19 && num18 <= 590.0)
								{
									string text = "Engine for very low-performance supersonic aircraft. Afterburner speed at Altitude Band 3 must be 30kt higher than Afterburner speed at Altitude Band 4!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
						if (flag12 || flag19)
						{
							if (num13 != num9 - 20.0 && !flag19 && num18 > 700.0)
							{
								string text = "Engine for high-performance supersonic aircraft. Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 - 10.0 && !flag19 && num18 <= 700.0)
							{
								string text = "Engine for low-performance supersonic aircraft. Military speed at Altitude Band 2 must be 10kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 < num9 + 50.0 && flag19)
							{
								string text = "Engine for SUPERCRUISING aircraft. Military speed at Altitude Band 3 must be minimum 50kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num8)
							{
								string text = "Engine for fast aircraft. Use same cruise speed across all altitude bands, this is fairly realistic and eases strike planning!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num7)
							{
								string text = "Engine for fast aircraft. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag12)
							{
								if (num14 != num10 + 100.0 && !flag19 && num18 >= 920.0 && num18 < 1350.0 && num18 != 1150.0 && num18 != 1160.0 && num6 + 120.0 != num18)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 920kt+. Afterburner speed at Altitude Band 3 must be 150kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num14 != num10 + 320.0 && !flag19 && num18 == 1150.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 1150kt. Afterburner speed at Altitude Band 3 must be 320kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num14 != num10 + 30.0 && !flag19 && num18 >= 920.0 && num18 < 920.0 && (num6 + 80.0 == num18 || num6 + 120.0 == num18))
								{
									string text = "Engine for high-performance supersonic aircraft with high-speed low-altitude penetration capabilities, max speed 920kt+. Afterburner speed at Altitude Band 3 must be 30kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num14 != num10 + 200.0 && !flag19 && num18 >= 1350.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 1350kt+. Afterburner speed at Altitude Band 3 must be 200kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num14 != num10 + 50.0 && !flag19 && num18 > 700.0 && num18 < 920.0 && num6 + 80.0 != num18)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 700-920kt. Afterburner speed at Altitude Band 3 must be 50kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num14 != num10 + 30.0 && !flag19 && num18 <= 700.0 && num18 > 590.0)
								{
									string text = "Engine for low-performance supersonic aircraft, max speed 700kt. Afterburner speed at Altitude Band 3 must be 30kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num14 != num10 - 20.0 && !flag19 && num18 <= 590.0)
								{
									string text = "Engine for very low-performance supersonic aircraft. Afterburner speed at Altitude Band 2 must be 20kt higher than Afterburner speed at Altitude Band 3!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
						if (flag8 || flag19)
						{
							if (num9 != num5 - 10.0 && !flag19 && num18 > 700.0)
							{
								string text = "Engine for high-performance supersonic aircraft. Military speed at Altitude Band 1 must be 10kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && !flag19 && num18 <= 700.0)
							{
								string text = "Engine for low-performance supersonic aircraft. Military speed at Altitude Band 2 must be identical to Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 < num5 + 30.0 && flag19)
							{
								string text = "Engine for SUPERCRUISING aircraft. Military speed at Altitude Band 2 must be minimum 30kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num4)
							{
								string text = "Engine for fast aircraft. Use same cruise speed across all altitude bands, this is fairly realistic and eases strike planning!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num3)
							{
								string text = "Engine for fast aircraft. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag8)
							{
								if (num10 != num6 + 50.0 && !flag19 && num18 >= 920.0 && num18 < 1350.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 920kt+. Afterburner speed at Altitude Band 2 must be 50kt higher than Afterburner speed at Altitude Band 1!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num10 != num6 + 100.0 && !flag19 && num18 >= 1350.0 && num18 < 1350.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 1350kt+. Afterburner speed at Altitude Band 2 must be 100kt higher than Afterburner speed at Altitude Band 1!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num10 != num6 + 30.0 && !flag19 && num18 > 700.0 && num18 < 920.0)
								{
									string text = "Engine for high-performance supersonic aircraft, max speed 700-920kt. Afterburner speed at Altitude Band 2 must be 30kt higher than Afterburner speed at Altitude Band 1!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num10 != num6 + 20.0 && !flag19 && num18 <= 700.0 && num18 > 590.0)
								{
									string text = "Engine for low-performance supersonic aircraft, max speed 700kt. Afterburner speed at Altitude Band 2 must be 20kt higher than Afterburner speed at Altitude Band 1!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (num10 != num6 - 10.0 && !flag19 && num18 <= 590.0)
								{
									string text = "Engine for very low-performance supersonic aircraft. Afterburner speed at Altitude Band 1 must be 10kt higher than Afterburner speed at Altitude Band 2!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
						if (!flag16 && flag15 && !flag19 && !flag24 && !flag25 && !flag26)
						{
							if (num17 < num13 + 80.0 && num17 > 390.0 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations. Military speed at Altitude Band 4 must be minimum 80kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 < num13 + 40.0 && flag22)
							{
								string text = "Engine for subsonic bomber with low-altitude structural speed limitations. Military speed at Altitude Band 4 must be minimum 40kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 < num13 + 80.0 && num17 <= 390.0 && num17 > 250.0 && flag20 && !flag30)
							{
								string text = "Engine for low-speed subsonic aircraft with low-altitude structural speed limitations. Military speed at Altitude Band 4 must be minimum 80kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 < num13 + 10.0 && num17 <= 250.0 && num17 > 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations. Military speed at Altitude Band 4 must be minimum 10kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 != num13 && num17 <= 150.0 && flag20)
							{
								string text = "Engine for ultra low speed subsonic aircraft with low-altitude structural speed limitations. Military speed at Altitude Band 4 must be equal to Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num17 != num13 - 30.0 && !flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations. Military speed at Altitude Band 4 must be 30kt lower than the Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 < num12 + 80.0 && num17 > 390.0 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations. Cruise speed at Altitude Band 4 must be minimum 80kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 < num12 + 40.0 && flag22)
							{
								string text = "Engine for subsonic bomber with low-altitude structural speed limitations. Cruise speed at Altitude Band 4 must be minimum 40kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 < num12 + 80.0 && num17 <= 390.0 && num17 > 250.0 && flag20 && !flag30)
							{
								string text = "Engine for low-speed subsonic aircraft with low-altitude structural speed limitations. Cruise speed at Altitude Band 4 must be minimum 80kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num12 && num17 <= 250.0 && num17 > 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations. Cruise speed at Altitude Band 4 must be equal to the Cruise speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num12 && num17 <= 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations. Cruise speed at Altitude Band 4 must be equal to the Cruise speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num4 && !flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations. Use same cruise speed across all altitude bands, this is fairly realistic and eases strike planning!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num3)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (!flag12 && flag11 && !flag19 && !flag24 && !flag25)
						{
							if (num13 != num9 + 50.0 && num17 > 390.0 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 3 must be 50kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 < num9 + 50.0 && num13 > 390.0 && !flag15 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Military speed at Altitude Band 3 must be minimum 50kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 + 40.0 && flag22)
							{
								string text = "Engine for subsonic bomber with low-altitude structural speed limitations. Military speed at Altitude Band 3 must be 40kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 + 50.0 && num17 <= 390.0 && num17 > 250.0 && flag15 && flag20 && !flag30)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 3 must be 50kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 < num9 + 70.0 && num13 <= 390.0 && num13 > 250.0 && !flag15 && flag20 && num45 > 9144.0)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Military speed at Altitude Band 3 must be minimum 70kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 + 50.0 && num17 <= 390.0 && num17 > 250.0 && !flag15 && flag20 && num45 <= 9144.0)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 3 must be 50kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 + 10.0 && num17 <= 250.0 && num17 > 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 3 must be 10kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 < num9 + 10.0 && num13 <= 250.0 && num13 > 150.0 && !flag15 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Military speed at Altitude Band 3 must be minimum 10kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 && num13 <= 150.0 && flag20)
							{
								string text = "Engine for ultra low speed subsonic aircraft with low-altitude structural speed limitations. Military speed at Altitude Band 3 must be equal to Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 - 20.0 && !flag20 && flag15 && !flag22 && num17 > 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is greater than 300kt (four altitude bands). Military speed at Altitude Band 3 must be 20kt lower than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 - 20.0 && !flag20 && !flag15 && !flag22 && num13 > 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is greater than 300kt (three altitude bands). Military speed at Altitude Band 3 must be 20kt lower than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 - 10.0 && !flag20 && flag15 && !flag22 && num17 <= 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is less than 300kt (four altitude bands). Military speed at Altitude Band 3 must be 10kt lower than Military speed at Altitude Band 2";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 - 10.0 && !flag20 && !flag15 && !flag22 && num13 <= 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is less than 300kt (three altitude bands). Military speed at Altitude Band 3 must be 10kt lower than Military speed at Altitude Band 2";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 + 50.0 && num17 > 390.0 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Cruise speed at Altitude Band 3 must be 50kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 < num8 + 50.0 && num13 > 390.0 && !flag15 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 3 must be minimum 50kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 + 20.0 && flag22)
							{
								string text = "Engine for subsonic bomber with low-altitude structural speed limitations. Cruise speed at Altitude Band 3 must be 20kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 + 50.0 && num17 <= 390.0 && num17 > 250.0 && flag15 && flag20 && !flag30)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Cruise speed at Altitude Band 3 must be 50kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 < num8 + 70.0 && num13 <= 390.0 && num13 > 250.0 && !flag15 && flag20 && num45 > 9144.0)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 3 must be minimum 70kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 < num8 + 50.0 && num13 <= 390.0 && num13 > 300.0 && !flag15 && flag20 && num45 <= 9144.0)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 3 must be minimum 50kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 && num17 <= 300.0 && num17 > 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Cruise speed at Altitude Band 3 must be equal to the Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 && num13 <= 250.0 && num13 > 150.0 && !flag15 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 3 must be equal to the Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 && num9 <= 250.0 && num9 > 150.0 && !flag11 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Cruise speed at Altitude Band 3 must be equal to the Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 && num13 <= 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations. Cruise speed at Altitude Band 3 must be equal to the Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num4 && !flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations. Use same cruise speed across all altitude bands, this is fairly realistic and eases strike planning!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num11 != num3)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (!flag8 && flag7 && !flag19 && !flag24 && !flag25)
						{
							if (num9 != num5 + 20.0 && num17 > 390.0 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && num13 > 390.0 && !flag15 && flag20 && !flag22 && !flag30)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && num9 > 390.0 && !flag11 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && flag22)
							{
								string text = "Engine for subsonic bomber with low-altitude structural speed limitations. Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && num17 <= 390.0 && num17 > 250.0 && flag20)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && num13 <= 390.0 && num13 > 250.0 && !flag15 && flag20)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && num9 <= 390.0 && num9 > 250.0 && !flag11 && flag20)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && num17 <= 250.0 && num17 > 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Military speed at Altitude Band 2 must be equal to the Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && num13 <= 250.0 && num13 > 150.0 && !flag15 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Military speed at Altitude Band 2 must be equal to the Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && num9 <= 250.0 && num9 > 150.0 && !flag11 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Military speed at Altitude Band 2 must be equal to the Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && num9 <= 150.0 && flag20)
							{
								string text = "Engine for ultra low speed subsonic aircraft with low-altitude structural speed limitations. Military speed at Altitude Band 2 must be equal to Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && !flag20 && !flag22 && num17 > 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is greater than 300kt (four altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && !flag20 && !flag15 && !flag22 && num13 > 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is greater than 300kt (three altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0 && !flag20 && !flag11 && !flag22 && num9 > 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is greater than 300kt (two altitude bands). Military speed at Altitude Band 2 must be 20kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && !flag20 && !flag22 && num17 <= 300.0 && flag15)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is less than 300kt (four altitude bands). Military speed at Altitude Band 2 must be equal to Military speed at Altitude Band 1";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && !flag20 && !flag15 && flag11 && !flag22 && num13 <= 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is less than 300kt (three altitude bands). Military speed at Altitude Band 2 must be equal to Military speed at Altitude Band 1";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 && !flag20 && !flag11 && flag7 && !flag22 && num9 <= 300.0)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations, max speed is less than 300kt (two altitude bands). Military speed at Altitude Band 2 must be equal to Military speed at Altitude Band 1";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0 && num17 > 390.0 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0 && num13 > 390.0 && !flag15 && flag20 && !flag22 && !flag30)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0 && num9 > 390.0 && !flag11 && flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0 && num17 <= 390.0 && num17 > 250.0 && flag20 && !flag22 && !flag30)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0 && num13 <= 390.0 && num13 > 250.0 && !flag15 && flag20 && !flag22)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0 && num9 <= 390.0 && num9 > 250.0 && !flag11 && flag20 && !flag22)
							{
								string text = "Engine for slow-speed subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 10.0 && flag22)
							{
								string text = "Engine for subsonic bomber with low-altitude structural speed limitations. Cruise speed at Altitude Band 2 must be 10kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 && num17 <= 250.0 && num17 > 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (four altitude bands). Cruise speed at Altitude Band 2 must be equal to the Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 && num13 <= 250.0 && num13 > 150.0 && !flag15 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (three altitude bands). Cruise speed at Altitude Band 2 must be equal to the Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 && num9 <= 250.0 && num9 > 150.0 && !flag11 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations (two altitude bands). Cruise speed at Altitude Band 2 must be equal to the Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 && num9 <= 150.0 && flag20)
							{
								string text = "Engine for very low speed subsonic aircraft with low-altitude structural speed limitations. Cruise speed at Altitude Band 2 must be equal to the Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 && !flag20 && !flag22)
							{
								string text = "Engine for subsonic aircraft without low-altitude structural speed limitations. Use same cruise speed across all altitude bands, this is fairly realistic and eases strike planning!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num7 != num3)
							{
								string text = "Engine for subsonic aircraft with low-altitude structural speed limitations. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (flag24)
						{
							if (num17 < num13 + 1000.0)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Military speed at Altitude Band 4 must be minimum 1000kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 + 150.0)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Military speed at Altitude Band 4 must be 150kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 70.0)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Military speed at Altitude Band 4 must be 70kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num4)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Cruise speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num4)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Cruise speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Cruise speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num3)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Loiter speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num11 != num3)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Loiter speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num7 != num3)
							{
								string text = "Engine for high-speed high-altitude recon aircraft! Loiter speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (flag25)
						{
							if (num17 < num13 + 100.0)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Military speed at Altitude Band 4 must be minimum 100kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num13 != num9 + 50.0)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Military speed at Altitude Band 4 must be 50kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num9 != num5 + 20.0)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Military speed at Altitude Band 4 must be 20kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 < num12 + 100.0)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Cruise speed at Altitude Band 4 must be minimum 100kt higher than Cruise speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 + 50.0)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Cruise speed at Altitude Band 3 must be 50kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 20.0)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Cruise speed at Altitude Band 2 must be 20kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num3)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Loiter speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num11 != num3)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Loiter speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num7 != num3)
							{
								string text = "Engine for low-speed high-altitude recon aircraft! Loiter speed must be equal across all Altitude Bands.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (flag15 && num17 >= 500.0 && num17 < num16 + 30.0)
						{
							string text = "Engine for fast aircraft. Military speed at Altitude Band 4 must be minimum 30kt higher than Cruise speed at Altitude Band 4!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num17 >= 500.0 && num13 < num12 + 30.0)
						{
							string text = "Engine for fast aircraft. Military speed at Altitude Band 3 must be minimum 30kt higher than Cruise speed at Altitude Band 3!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num17 >= 500.0 && num9 < num8 + 30.0)
						{
							string text = "Engine for fast aircraft. Military speed at Altitude Band 2 must be minimum 30kt higher than Cruise speed at Altitude Band 1!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num17 >= 500.0 && num5 < num4 + 30.0)
						{
							string text = "Engine for fast aircraft. Military speed at Altitude Band 1 must be minimum 30kt higher than Cruise speed at Altitude Band 1!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (((num2 == 2005L || num2 == 2004L) & (array3.Length != 0)) && !flag26)
					{
						if (flag13)
						{
							if (num17 != num13 + 40.0)
							{
								string text = "Helicopter or Piston engine. Military speed for Altitude Band 4 must be 40kt lower than Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num4)
							{
								string text = "Helicopter or Piston engine. Cruise speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num3)
							{
								string text = "Helicopter or Piston engine. Loiter speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (!flag12 && flag11)
						{
							if (num13 != num9 - 10.0)
							{
								string text = "Helicopter or Piston engine. Military speed for Altitude Band 3 must be 10kt lower than Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num4)
							{
								string text = "Helicopter or Piston engine. Cruise speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num11 != num3)
							{
								string text = "Helicopter or Piston engine. Loiter speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (!flag8 && flag7)
						{
							if (num9 != num5)
							{
								string text = "Helicopter or Piston engine. Military speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4)
							{
								string text = "Helicopter or Piston engine. Cruise speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num7 != num3)
							{
								string text = "Helicopter or Piston engine. Loiter speed for all altitude bands must be identical!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
					if (array3.Length != 0 && flag26)
					{
						if (flag15)
						{
							if (num17 != num13 + 30.0)
							{
								string text = "Engine for tiltrotor aircraft. Military speed at Altitude Band 4 must be 30kt higher than the Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num16 != num12 + 30.0)
							{
								string text = "Engine for tiltrotor aircraft. Cruise speed at Altitude Band 4 must be minimum 30kt higher than Military speed at Altitude Band 3!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num15 != num3)
							{
								string text = "Engine for tiltrotor aircraft. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (flag7)
						{
							if (num13 != num9 + 20.0)
							{
								string text = "Engine for tiltrotor aircraft. Military speed at Altitude Band 3 must be 20kt higher than Military speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num12 != num8 + 30.0)
							{
								string text = "Engine for tiltrotor aircraft. Cruise speed at Altitude Band 3 must be 30kt higher than Cruise speed at Altitude Band 2!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num11 != num3)
							{
								string text = "Engine for tiltrotor aircraft. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (flag7)
						{
							if (num9 != num5 + 10.0)
							{
								string text = "Engine for tiltrotor aircraft. Military speed at Altitude Band 2 must be 10kt higher than Military speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num8 != num4 + 10.0)
							{
								string text = "Engine for tiltrotor aircraft. Cruise speed at Altitude Band 2 must be 10kt higher than Cruise speed at Altitude Band 1!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num7 != num3)
							{
								string text = "Engine for tiltrotor aircraft. Use same loiter speed across all altitude bands";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
					if ((num2 == 2001L || num2 == 2002L) && !flag19 && !flag30)
					{
						if (flag3 && num52 * 1.2 > num53)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 1 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num52 * 1.9 < num53 && num5 - num4 <= 50.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 1 is more than 90 percent higher than fuel consumption at cruise. Speed difference is <= 50kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num52 * 2.25 < num53 && num5 - num4 > 50.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 1 is more than 125 percent higher than fuel consumption at cruise. Speed difference is > 50kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 1.2 > num57)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 2 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 1.9 < num57 && num9 - num8 <= 130.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 2 is more than 90 percent higher than fuel consumption at cruise. Speed difference is <= 130kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 2.25 < num57 && num9 - num8 > 130.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 2 is more than 125 percent higher than fuel consumption at cruise. Speed difference is > 130kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 1.2 > num61)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 3 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 1.9 < num61 && num13 - num12 <= 110.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 3 is more than 90 percent higher than fuel consumption at cruise. Speed difference is <= 110kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 2.25 < num61 && num13 - num12 > 110.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 3 is more than 125 percent higher than fuel consumption at cruise. Speed difference is > 110kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 1.2 > num65)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 4 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 1.9 < num65 && num17 - num16 <= 80.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 4 is more than 90 percent higher than fuel consumption at cruise. Speed difference is <= 80kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 2.25 < num65 && num17 - num16 > 80.0)
						{
							string text = "Turbojet / Turbofan engine. Fuel consumption at military speed at Altitude Band 4 is more than 125 percent higher than fuel consumption at cruise. Speed difference is > 80kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (num2 == 2003L)
					{
						if (flag3 && num52 * 1.2 > num53)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 1 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num52 * 2.25 < num53 && num5 - num4 <= 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 1 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num52 * 2.75 < num53 && num5 - num4 > 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 1 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 1.2 > num57)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 2 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 2.25 < num57 && num9 - num8 <= 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 2 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 2.75 < num57 && num9 - num8 > 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 2 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 1.2 > num61)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 3 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 2.25 < num61 && num13 - num12 <= 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 3 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 2.75 < num61 && num13 - num12 > 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 3 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 1.2 > num65)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 4 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 2.25 < num65 && num17 - num16 <= 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 4 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 2.75 < num65 && num17 - num16 > 60.0)
						{
							string text = "Turboprop engine. Fuel consumption at military speed at Altitude Band 4 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 60kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (num2 == 2004L || num2 == 2005L)
					{
						if (flag3 && num52 * 1.2 > num53)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 1 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num52 * 2.25 < num53 && num5 - num4 <= 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 1 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag3 && num52 * 2.75 < num53 && num5 - num4 > 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 1 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 1.2 > num57)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 2 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 2.25 < num57 && num9 - num8 <= 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 2 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag7 && num56 * 2.75 < num57 && num9 - num8 > 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 2 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 1.2 > num61)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 3 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 2.25 < num61 && num13 - num12 <= 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 3 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && num60 * 2.75 < num61 && num13 - num12 > 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 3 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 1.2 > num65)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 4 is less than 20 percent higher than fuel consumption at cruise. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 2.25 < num65 && num17 - num16 <= 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 4 is more than 125 percent higher than fuel consumption at cruise. Speed difference is <= 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag15 && num64 * 2.7 < num65 && num17 - num16 > 15.0)
						{
							string text = "Piston / Helicopter engine. Fuel consumption at military speed at Altitude Band 4 is more than 175 percent higher than fuel consumption at cruise. Speed difference is > 15kt. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (num13 >= 500.0 && !flag15 && !flag30)
					{
						string text = "500kt aircraft should have a Altitude Band 4 entered";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
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
			ex2.Data.Add("Error at Validation 200073", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidatePropulsionUsersFuelQty()
	{
		checked
		{
			try
			{
				string name = "SELECT ID, Type FROM DataPropulsion";
				Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Recordset recordset2 = recordset;
				long num8 = default(long);
				while (!recordset2.EOF)
				{
					long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
					long num2 = Conversions.ToLong(recordset2.Fields["Type"].Value);
					long num3 = 0L;
					long num4 = 0L;
					DataRow[] array = Common.get_DataAircraftPropulsion(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num));
					if (array.Length > 0)
					{
						bool flag = true;
						long num5 = 0L;
						DataRow[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							long num6 = Conversions.ToLong(array2[i]["ID"]);
							int num7;
							if (!flag)
							{
								num7 = 0;
							}
							else
							{
								num8 = num6;
								num7 = 0;
							}
							long num9 = num7;
							long num10 = 0L;
							DataRow[] array3 = Common.get_DataAircraftFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
							for (int j = 0; j < array3.Length; j++)
							{
								num5 = Conversions.ToLong(array3[j]["ComponentID"]);
								DataRow dataRow = Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num5);
								long num11 = Conversions.ToLong(dataRow["Capacity"]);
								long num12 = Conversions.ToLong(dataRow["Type"]);
								num5 = Conversions.ToLong(dataRow["ID"]);
								bool flag2 = false;
								unchecked
								{
									if (num12 == 2001L && (num2 == 2001L || num2 == 2002L || num2 == 2003L || num2 == 2004L || num2 == 2005L))
									{
										flag2 = true;
									}
									if (num12 == 3001L && num2 == 3001L)
									{
										flag2 = true;
									}
									if (num12 == 3002L && num2 == 3002L)
									{
										flag2 = true;
									}
									if (num12 == 3003L && num2 == 3003L)
									{
										flag2 = true;
									}
									if (num12 == 4001L && num2 == 4001L)
									{
										flag2 = true;
									}
									if (num12 == 4002L && num2 == 4002L)
									{
										flag2 = true;
									}
									if (num12 == 5001L && num2 == 5001L)
									{
										flag2 = true;
									}
									if (num12 == 5002L && num2 == 5002L)
									{
										flag2 = true;
									}
									if (num12 == 5003L && num2 == 5003L)
									{
										flag2 = true;
									}
									if (flag2)
									{
										if (!flag)
										{
											num10 = num11;
										}
										else
										{
											num4 = num11;
										}
									}
								}
							}
							DataRow[] array4 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
							for (int k = 0; k < array4.Length; k++)
							{
								long num13 = Conversions.ToLong(array4[k]["ComponentID"]);
								DataRow dataRow2 = Common.get_DataLoadout(Common.mySourceDB_Helper).Rows.Find(num13);
								if (!Information.IsNothing((object)dataRow2))
								{
									if (Conversions.ToDouble(dataRow2["LoadoutRole"]) != 9001.0)
									{
										continue;
									}
									DataRow[] array5 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num13));
									for (int l = 0; l < array5.Length; l++)
									{
										long num14 = Conversions.ToLong(array5[l]["ComponentID"]);
										DataRow? dataRow3 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num14);
										long num15 = Conversions.ToLong(dataRow3["ComponentID"]);
										long num16 = Conversions.ToLong(dataRow3["DefaultLoad"]);
										long num17 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num15)["Type"]);
										if (unchecked(num17 == 3002L || num17 == 3004L))
										{
											DataRow[] array6 = Common.get_DataWeaponFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num15));
											for (int m = 0; m < array6.Length; m++)
											{
												long num18 = Conversions.ToLong(array6[m]["ComponentID"]);
												long num19 = Conversions.ToLong(Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num18)["Capacity"]);
												num9 = unchecked(num9 + num19 * num16);
											}
											if (flag)
											{
												num3 = num9;
											}
										}
									}
								}
								else
								{
									string text = "Loadout " + Conversions.ToString(num13) + " does not exist in the database. Please remove from aircraft.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num6) + ", 'Aircraft', '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							if (!flag)
							{
								if (Conversion.Int(num10) != Conversion.Int(num4))
								{
									string text = "Engine has users with different internal fuel quantities: User with ID# " + Conversions.ToString(num8) + " has an internal qty of " + Conversions.ToString(num4) + " while user with ID# " + Conversions.ToString(num6) + " has an internal qty of " + Conversions.ToString(num10);
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (Conversion.Int(num3) != Conversion.Int(num9))
								{
									string text = "Engine has users with different external fuel quantities in the Ferry loadout: User with ID# " + Conversions.ToString(num8) + " has an external qty of " + Conversions.ToString(num3) + " while user with ID# " + Conversions.ToString(num6) + " has an external qty of " + Conversions.ToString(num9);
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Propulsion" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							else
							{
								flag = false;
							}
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
				ex2.Data.Add("Error at Validation 200074", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	static DataValidatePropulsion()
	{
		Class72.smethod_20();
	}
}
