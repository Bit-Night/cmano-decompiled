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
internal sealed class DataValidateMagazine
{
	public static void CheckMagazinesAreNotOverFilled()
	{
		try
		{
			string name = "SELECT ID, Capacity, ROF FROM DataMagazine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num2 = Conversions.ToLong(recordset2.Fields["Capacity"].Value);
				long num3 = Conversions.ToLong(recordset2.Fields["ROF"].Value);
				double num4 = 0.0;
				DataRow[] array = Common.get_DataMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					double num5 = Conversions.ToDouble(array[i]["ComponentID"]);
					DataRow? dataRow = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num5);
					double num6 = Conversions.ToDouble(dataRow["DefaultLoad"]);
					double num7 = Conversions.ToDouble(dataRow["MaxLoad"]);
					double num8 = Conversions.ToDouble(dataRow["Multiple"]);
					double num9 = Conversions.ToDouble(dataRow["ROF"]);
					num6 /= num8;
					num7 /= num8;
					if (num6 > (double)num2)
					{
						string text = "Weapon record " + Conversions.ToString(num5) + " is armed with more weapons than the Magazines max capacity.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 > (double)num2)
					{
						string text = "Weapon record " + Conversions.ToString(num5) + " has more weapon space than the Magazines max capacity.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 != (double)num3)
					{
						string text = "Weapon record " + Conversions.ToString(num5) + " ROF does not match the Magazines ROF.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					num4 += num6;
				}
				if (num4 > (double)num2)
				{
					string text = "This Magazine is overloaded! Check the amount of ammo vs total capacity.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200057", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMagazineNames()
	{
		try
		{
			string name = "SELECT ID FROM DataMagazine";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow? dataRow = Common.get_DataMagazine(Common.mySourceDB_Helper).Rows.Find(num);
				string text = Conversions.ToString(0);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 > 0 && num2 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 > 0 && num5 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num14 = 1;
				}
				if (Strings.InStr(num14, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num15 = 1;
				}
				int num16;
				if (Strings.InStr(num15, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				else
				{
					num16 = 1;
				}
				int num17;
				if ((Strings.InStr(num16, text2, "KT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "KT)", (CompareMethod)0) > 0))
				{
					string text3 = "Kiloton should say \"kT\" and not \"KT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				else
				{
					num17 = 1;
				}
				int num18;
				if ((Strings.InStr(num17, text2, "kt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "kt)", (CompareMethod)0) > 0))
				{
					string text3 = "Kiloton should say \"kT\" and not \"kt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				else
				{
					num18 = 1;
				}
				int num19;
				if ((Strings.InStr(num18, text2, "MT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MT)", (CompareMethod)0) > 0))
				{
					string text3 = "Megaton should say \"mT\" and not \"MT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if ((Strings.InStr(num20, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				else
				{
					num21 = 1;
				}
				int num22;
				if ((Strings.InStr(num21, text2, "MK ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num24 = 1;
				}
				int num25;
				if (Strings.InStr(num24, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num25 = 1;
				}
				else
				{
					num25 = 1;
				}
				int num26;
				if (Strings.InStr(num25, text2, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num26 = 1;
				}
				else
				{
					num26 = 1;
				}
				int num27;
				if (Strings.InStr(num26, text, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num27 = 1;
				}
				else
				{
					num27 = 1;
				}
				if (Strings.InStr(num27, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Magazine" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
			ex2.Data.Add("Error at Validation 200058", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateMagazine()
	{
		Class72.smethod_20();
	}
}
