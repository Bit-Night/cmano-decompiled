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
internal sealed class DataValidateWarhead
{
	public static void ValidateWarheadNames()
	{
		try
		{
			DataTable dataTable = Common.get_DataWarhead(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (!DataValidateAllInOne.DeprecationImplemented || !Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
					DataRow? dataRow = Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num);
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 > 0 && num2 == 0)
					{
						string text3 = "Found a right \")\" bracket in the name but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 > 0 && num5 == 0)
					{
						string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 > 0 && num4 == 0)
					{
						string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 > 0 && num7 == 0)
					{
						string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num14 = 1;
					}
					if (Strings.InStr(num14, text2, "|", (CompareMethod)1) > 0)
					{
						string text3 = "Found pipe \"|\" character in the name, there should not be any.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 > 0 && num9 == 0)
					{
						string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 > 0 && num8 == 0)
					{
						string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 > 0 && num11 == 0)
					{
						string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 > 0 && num10 == 0)
					{
						string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 > 0 && num13 == 0)
					{
						string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num18 = 1;
					}
					int num19;
					if ((Strings.InStr(num18, text2, "MT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MT)", (CompareMethod)0) > 0))
					{
						string text3 = "Megaton should say \"mT\" and not \"MT\" in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num20 = 1;
					}
					int num21;
					if ((Strings.InStr(num20, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0))
					{
						string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num24 = 1;
					}
					int num25;
					if (Strings.InStr(num24, text2, "  ", (CompareMethod)1) > 0)
					{
						string text3 = "Found double spaces in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num26 = 1;
					}
					int num27;
					if (Strings.InStr(num26, text, "  ", (CompareMethod)1) > 0)
					{
						string text3 = "Found double spaces in the comments field.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200113", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWarheadTypeAndExplosives()
	{
		try
		{
			string name = "SELECT ID FROM DataWarhead";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow? dataRow = Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num);
				double num2 = Conversions.ToDouble(dataRow["Type"]);
				Conversions.ToDouble(dataRow["ProjectileCaliber"]);
				double num3 = Conversions.ToDouble(dataRow["ExplosivesType"]);
				double num4 = Conversions.ToDouble(dataRow["ExplosivesWeight"]);
				Conversions.ToDouble(dataRow["DamagePoints"]);
				long num5 = Conversions.ToLong(dataRow["NumberOfWarheads"]);
				long num6 = Conversions.ToLong(dataRow["ClusterBombDispersionAreaLength"]);
				long num7 = Conversions.ToLong(dataRow["ClusterBombDispersionAreaWidth"]);
				if (num2 > 6000.0 && num2 < 6999.0 && num5 <= 1L)
				{
					string text = "Warhead type says Cluster Munition however the warhead has only a single submunition!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 < 6000.0 || num2 > 6999.0) && num2 != 2011.0 && num5 > 1L)
				{
					string text = "Warhead has multiple submunitions but is not a cluster munition!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 1L && num6 <= 0L)
				{
					string text = "Warhead has multiple submunitions but no Dispersion Area Length!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 1L && num7 <= 0L)
				{
					string text = "Warhead has multiple submunitions but no Dispersion Area Width!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 < 1.0 && num4 > 10000.0)
				{
					string text = "Warhead explosives weight should be between 1 and 10000 kg.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2001.0)
				{
					if (num3 >= 2001.0 && num3 < 2099.0)
					{
						if (num4 < 1.0 && num4 > 10000.0)
						{
							string text = "Warhead explosives weight should be between 1 and 10000 kg.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					else
					{
						string text = "Warhead Type does not match Explosives";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2002.0 && !((num3 >= 2001.0 && num3 < 2099.0) || num3 == 9801.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2003.0 && !(num3 >= 2201.0 && num3 < 2299.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2004.0 && !(num3 == 2101.0 || num3 == 2102.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2005.0 && num3 != 2301.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2006.0 && !(num3 >= 2001.0 && num3 < 2099.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2007.0 && !(num3 >= 2001.0 && num3 < 2099.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2008.0 && num3 != 2401.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2009.0 && !(num3 >= 2001.0 && num3 < 2099.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2010.0 && num3 != 2103.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 3001.0 && !(num3 >= 2001.0 && num3 < 2099.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 3002.0 && !(num3 >= 2001.0 && num3 < 2099.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001.0 || num2 == 4002.0 || num2 == 4003.0) && num3 != 4001.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4011.0 && num3 != 4011.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4021.0 && num3 != 4012.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 6001.0 && num3 != 6001.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 6002.0 || num2 == 6002.0) && !(num3 == 6002.0 || num3 == 6003.0 || num3 == 6004.0 || num3 == 6005.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 6003.0 && num3 != 6011.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 7001.0 && num3 != 7011.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 7002.0 && !(num3 == 7012.0 || num3 == 7013.0 || num3 == 7014.0 || num3 == 7015.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 8001.0 && !(num3 >= 8001.0 && num3 < 8099.0))
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 9001.0 && num3 != 9001.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 9002.0 && num3 != 9002.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 9101.0 && num3 != 9101.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 9801.0 && num3 != 9801.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 5002.0 && num3 != 9998.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 9801.0 && num3 != 9801.0)
				{
					string text = "Warhead Type does not match Explosives";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Warhead" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200114", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateWarhead()
	{
		Class72.smethod_20();
	}
}
