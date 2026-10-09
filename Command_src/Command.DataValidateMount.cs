using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateMount
{
	[CompilerGenerated]
	internal sealed class _Closure$__2-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__2-0(_Closure$__2-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TasksFinished = arg0.$VB$Local_TasksFinished;
				$VB$Local_theList = arg0.$VB$Local_theList;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(int theInt)
		{
			smethod_0(theInt, ref $VB$Local_TasksFinished);
			Common.StatusString = "CheckMountsAreNotOverFilled - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__2-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__6-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__6-0(_Closure$__6-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TasksFinished = arg0.$VB$Local_TasksFinished;
				$VB$Local_theList = arg0.$VB$Local_theList;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(int theInt)
		{
			smethod_1(theInt, ref $VB$Local_TasksFinished);
			Common.StatusString = "ValidateLoadoutCapabilities - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__6-0()
		{
			Class72.smethod_20();
		}
	}

	public static void ValidateMountStats()
	{
		try
		{
			DataTable dataTable = Common.get_DataMount(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Name" }, (string[])null));
				DataRow[] array = Common.get_MiscMountDefault(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag = false;
				if (array.Length != 0)
				{
					flag = true;
				}
				if (!flag)
				{
					string text = "Completed mounts need standard arcs set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200059", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_0(int int_0, ref int int_1)
	{
		try
		{
			DataRow? dataRow = Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(int_0);
			long num = Conversions.ToLong(dataRow["Capacity"]);
			long num2 = Conversions.ToLong(dataRow["ROF"]);
			string text = Conversions.ToString(dataRow["Name"]);
			long num3 = Conversions.ToLong(dataRow["MagazineCapacity"]);
			long num4 = Conversions.ToLong(dataRow["MagazineROF"]);
			int num5 = Conversions.ToInteger(dataRow["Cargo_Type"]);
			double num6 = 0.0;
			bool flag = false;
			bool flag2 = false;
			int num7 = 0;
			bool flag3 = ((num5 != 0) ? true : false);
			DataRow[] array = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(int_0));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				double num8 = Conversions.ToDouble(array[i]["ComponentID"]);
				DataRow? dataRow2 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num8);
				double num9 = Conversions.ToDouble(dataRow2["ComponentID"]);
				double num10 = Conversions.ToDouble(dataRow2["DefaultLoad"]);
				double num11 = Conversions.ToDouble(dataRow2["MaxLoad"]);
				double num12 = Conversions.ToDouble(dataRow2["Multiple"]);
				double num13 = Conversions.ToDouble(dataRow2["ROF"]);
				num10 /= num12;
				num11 /= num12;
				if (num10 > (double)num)
				{
					string text2 = "Weapon record " + Conversions.ToString(num8) + " (" + text + ") is armed with more weapons than the mounts max capacity.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > (double)num)
				{
					string text2 = "Weapon record " + Conversions.ToString(num8) + " (" + text + ")  has more weapon space than the mounts max capacity.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num14;
				if (!((num13 != (double)num2) & (((Strings.InStr(1, text, "Tank", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Bradley", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Avenger", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "SPAAG", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "ADATS", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "LAV-", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PL-8H", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "CADS-N-1", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "APC", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AUF", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "G6", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "MSTA-S", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Type 66", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Akatsiya", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Wrobel-II", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "BMP", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Spike", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "CV 90", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "BMD", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "WZ501", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "WZ50", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Centauro", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PLZ-45", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "VCC-80", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Freccia", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Palmaria", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "ZBD", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Stryker", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PLZ-05", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PzH", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AAV", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Atilgan", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "M1114", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "QW-1", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PLZ-07", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AMX", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "SAGAIE", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Machbet", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "BMR", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "IFV", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AGS", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "ASLAV", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "LAV-25", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "ZOM", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Scorpion", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "FH-77", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "VBCI", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PT-90", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Pindad", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "ZUR-23-2", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "715II", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Katran-M", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Shturm", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Iskander-M/K", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "D-56TS", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PLL-09", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "SA-N-22", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "PCL-09", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "BTR", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Piranha", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "Koalitsiya", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "M113-F4", (CompareMethod)0) == 0)) && !flag3)))
				{
					num14 = 1;
				}
				else
				{
					string text2 = "Weapon record " + Conversions.ToString(num8) + " (" + text + ") ROF does not match the mounts ROF.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num14 = 1;
				}
				int num15;
				if (!(Strings.InStr(num14, text, "Rail", (CompareMethod)0) > 0 && num11 != (double)num))
				{
					num15 = 1;
				}
				else
				{
					string text2 = "Rail Launcher! Mount Weapon Record max qty does not match Mount max qty.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num15 = 1;
				}
				if (Strings.InStr(num15, text, "Rail", (CompareMethod)0) > 0 && Conversions.ToDouble(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num9)["Type"]) == 2008.0)
				{
					int num16;
					if (!(!flag && num10 > 0.0))
					{
						num16 = 1;
					}
					else
					{
						string text2 = "Rail Launcher! These mounts shall not be loaded with GMTRs by default!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num16 = 1;
					}
					flag = (byte)num16 != 0;
				}
				num6 += num10;
			}
			int num17;
			if (num6 > (double)num)
			{
				string text2 = "This mount is overloaded! Check the amount of ammo vs total capacity.";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num17 = 1;
			}
			else
			{
				num17 = 1;
			}
			if (Strings.InStr(num17, text, "Rail", (CompareMethod)0) > 0 && num6 < (double)num)
			{
				string text2 = "Rail Launcher! Mount is not fully loaded! Rails: " + Conversions.ToString(num) + " Loaded wpn: " + Conversions.ToString(num6);
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			double num18 = 0.0;
			double num19 = 0.0;
			DataRow[] array2 = Common.get_DataMountMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(int_0));
			for (int j = 0; j < array2.Length; j = checked(j + 1))
			{
				double num20 = Conversions.ToDouble(array2[j]["ComponentID"]);
				num19 += 1.0;
				DataRow? dataRow3 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num20);
				double num21 = Conversions.ToDouble(dataRow3["ComponentID"]);
				double num22 = Conversions.ToDouble(dataRow3["DefaultLoad"]);
				double num23 = Conversions.ToDouble(dataRow3["MaxLoad"]);
				double num24 = Conversions.ToDouble(dataRow3["Multiple"]);
				Conversions.ToDouble(dataRow3["ROF"]);
				num22 /= num24;
				num23 /= num24;
				int num25;
				if (!(Strings.InStr(1, text, "Rail", (CompareMethod)0) > 0 && num23 != (double)num3))
				{
					num25 = 1;
				}
				else
				{
					string text2 = "Rail Launcher! Mount Mag Weapon Record max qty does not match Mount Mag max qty.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num25 = 1;
				}
				if (Strings.InStr(num25, text, "Rail", (CompareMethod)0) > 0 && Conversions.ToDouble(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num21)["Type"]) == 2008.0)
				{
					int num26;
					if (!(!flag2 && num22 != (double)num))
					{
						num26 = 1;
					}
					else
					{
						string text2 = "Rail Launcher! Mount Magazine needs one GMTR per rail, number of rails is: " + Conversions.ToString(num);
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num26 = 1;
					}
					flag2 = (byte)num26 != 0;
					num7 = (int)Math.Round((double)num7 + num22);
				}
				num18 += num22;
			}
			if (((num7 <= num) & (Strings.InStr(1, text, "Rail", (CompareMethod)0) > 0)) && num18 < (double)(num3 - num) && num19 > 0.0)
			{
				string text2 = "Rail Launcher! Mount Magazine not fully loaded! Total Mount Mag wpn qty should be: " + Conversions.ToString(num3 - num);
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			int num27;
			if (((num7 > num && num > 1L) & (Strings.InStr(1, text, "Rail", (CompareMethod)0) > 0)) && num18 < (double)(num3 - num7) && num19 > 0.0)
			{
				string text2 = "Rail Launcher! Mount Magazine not fully loaded! Total Mount Mag wpn qty should be: " + Conversions.ToString(num3 - num7);
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num27 = 1;
			}
			else
			{
				num27 = 1;
			}
			int num28;
			if (Strings.InStr(num27, text, "Rail", (CompareMethod)0) > 0 && num18 > (double)(num3 - num) && num19 > 0.0)
			{
				string text2 = "Rail Launcher! Mount Magazine overloaded! Total Mount Mag wpn qty should be: " + Conversions.ToString(num3 - num);
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num28 = 1;
			}
			else
			{
				num28 = 1;
			}
			int num29;
			if (Strings.InStr(num28, text, "Rail", (CompareMethod)0) > 0 && !flag && num19 > 0.0)
			{
				string text2 = "Rail Launcher! Mount lacks a GMTR record!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num29 = 1;
			}
			else
			{
				num29 = 1;
			}
			int num30;
			if (Strings.InStr(num29, text, "Rail", (CompareMethod)0) > 0 && !flag2 && num19 > 0.0)
			{
				string text2 = "Rail Launcher! Mount Magazine lacks a GTMR record!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num30 = 1;
			}
			else
			{
				num30 = 1;
			}
			int num31;
			if (!(Strings.InStr(num30, text, "Twin Rail", (CompareMethod)0) > 0 && num2 < 2L))
			{
				num31 = 1;
			}
			else
			{
				string text2 = "Twin Rail Launcher! Mount ROF must be 2 or greater!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num31 = 1;
			}
			int num32;
			if (!(Strings.InStr(num31, text, "Single Rail", (CompareMethod)0) > 0 && num2 != 1L && num19 > 0.0))
			{
				num32 = 1;
			}
			else
			{
				string text2 = "Single Rail Launcher with mount magazine! Mount ROF must be 1!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				num32 = 1;
			}
			if (Strings.InStr(num32, text, "Rail", (CompareMethod)0) > 0 && num4 < 2L && num19 > 0.0)
			{
				string text2 = "Rail Launcher! Mount Magazine ROF must be 2 or greater!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			int_1++;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200060", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void CheckMountsAreNotOverFilled()
	{
		try
		{
			_Closure$__2-0 arg = default(_Closure$__2-0);
			_Closure$__2-0 CS$<>8__locals7 = new _Closure$__2-0(arg);
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataMount(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				smethod_0(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "CheckMountsAreNotOverFilled - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200061", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void CheckMountUnguidedRocketLaunchers()
	{
		string name = "select datamount.ID, datamount.name from datamount, datamountweapons, DataWeaponRecord where datamountweapons.id = datamount.ID and dataweaponrecord.ID = datamountweapons.componentid and dataweaponrecord.componentid in (SELECT id from DataWeapon where Type = 2002)";
		Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
		Dictionary<long, long> dictionary = new Dictionary<long, long>();
		Dictionary<long, long> dictionary2 = new Dictionary<long, long>();
		Dictionary<long, Dictionary<long, long>> dictionary3 = new Dictionary<long, Dictionary<long, long>>();
		DataRow[] array = Common.get_DataWeapon(Common.mySourceDB_Helper).Select("Type = 2002");
		DataRow[] array2 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select();
		DataRow[] array3 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select();
		DataRow[] array4 = array;
		foreach (DataRow dataRow in array4)
		{
			if (!dictionary.ContainsKey(Conversions.ToLong(dataRow["ID"])))
			{
				dictionary.Add(Conversions.ToLong(dataRow["ID"]), Conversions.ToLong(dataRow["ID"]));
			}
		}
		DataRow[] array5 = array3;
		foreach (DataRow dataRow2 in array5)
		{
			if (dictionary.ContainsKey(Conversions.ToLong(dataRow2["ComponentID"])) && !dictionary2.ContainsKey(Conversions.ToLong(dataRow2["ID"])))
			{
				dictionary2.Add(Conversions.ToLong(dataRow2["ID"]), Conversions.ToLong(dataRow2["ComponentID"]));
			}
		}
		DataRow[] array6 = array2;
		foreach (DataRow dataRow3 in array6)
		{
			if (dictionary2.ContainsKey(Conversions.ToLong(dataRow3["ComponentID"])) && !dictionary3.ContainsKey(Conversions.ToLong(dataRow3["ID"])))
			{
				dictionary3.Add(Conversions.ToLong(dataRow3["ID"]), new Dictionary<long, long>());
				dictionary3[Conversions.ToLong(dataRow3["ID"])].Add(Conversions.ToLong(dataRow3["ComponentID"]), Conversions.ToLong(dataRow3["ComponentNumber"]));
			}
		}
		foreach (KeyValuePair<long, Dictionary<long, long>> item in dictionary3)
		{
			short num = 0;
			foreach (KeyValuePair<long, long> item2 in item.Value)
			{
				num = (short)(num + item2.Value);
			}
			if (num > 1)
			{
				string text = "Warning : This mount contains " + num + " records of unguided weapon, make sure this is not a single fire launcher";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(item.Key) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
		}
	}

	public static void CheckMountMagazinesAreNotOverFilled()
	{
		try
		{
			string name = "SELECT ID, Name, MagazineCapacity, MagazineROF FROM DataMount";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num2 = Conversions.ToLong(recordset2.Fields["MagazineCapacity"].Value);
				long num3 = Conversions.ToLong(recordset2.Fields["MagazineROF"].Value);
				string text = Conversions.ToString(recordset2.Fields["Name"].Value);
				double num4 = 0.0;
				DataRow[] array = Common.get_DataMountMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
						string text2 = "Mount magazine weapon record " + Conversions.ToString(num5) + " is armed with more weapons than the mounts max capacity.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 > (double)num2)
					{
						string text2 = "Mount magazine weapon record " + Conversions.ToString(num5) + " has more weapon space than the mounts max capacity.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 != (double)num3)
					{
						string text2 = "Mount magazine weapon record " + Conversions.ToString(num5) + " ROF does not match the mounts ROF.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					num4 += num6;
				}
				if (num4 > (double)num2)
				{
					string text2 = "This mounts magazine is overloaded! Check the amount of ammo vs total capacity.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num4 < (double)num2) & (Strings.InStr(1, text, "Rail", (CompareMethod)0) < 1))
				{
					string text2 = "This mounts magazine is underloaded! Check the amount of ammo vs total capacity.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
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
			ex2.Data.Add("Error at Validation 200062", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMountNames()
	{
		try
		{
			string name = "SELECT ID FROM DataMount";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow? dataRow = Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 > 0 && num2 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 > 0 && num5 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num14;
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				int num17;
				if ((Strings.InStr(num16, text2, "KT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "KT)", (CompareMethod)0) > 0))
				{
					string text3 = "Kiloton should say \"kT\" and not \"KT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				else
				{
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				int num19;
				if (!((Strings.InStr(num18, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0)))
				{
					num19 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				int num20;
				if (!((Strings.InStr(num19, text2, "MK ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK1", (CompareMethod)0) > 0)))
				{
					num20 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if (!((Strings.InStr(num20, text2, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) > 0)))
				{
					num21 = 1;
				}
				else
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				int num22;
				if ((Strings.InStr(num21, text2, "AGM ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "AIM ", (CompareMethod)0) > 0))
				{
					string text3 = "AGM/AIM designations should use dashes \"-\" in the name, not spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num22 = 1;
				}
				else
				{
					num22 = 1;
				}
				int num23;
				if (Strings.InStr(num22, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num23 = 1;
				}
				else
				{
					num23 = 1;
				}
				int num24;
				if (Strings.InStr(num23, text2, "//", (CompareMethod)1) <= 0)
				{
					num24 = 1;
				}
				else
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num24 = 1;
				}
				int num25;
				if (Strings.InStr(num24, text, "  ", (CompareMethod)1) <= 0)
				{
					num25 = 1;
				}
				else
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num25 = 1;
				}
				if (Strings.InStr(num25, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
			ex2.Data.Add("Error at Validation 200063", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMountsHaveCorrectCommGear()
	{
		try
		{
			_Closure$__6-0 arg = default(_Closure$__6-0);
			_Closure$__6-0 CS$<>8__locals7 = new _Closure$__6-0(arg);
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataMount(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Cargo_Type" }, (string[])null), (object)0, true))
				{
					CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
				}
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				smethod_1(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "ValidateLoadoutCapabilities - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200064", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_1(int int_0, ref int int_1)
	{
		try
		{
			long num = int_0;
			bool flag = false;
			long[] array = new long[0];
			long num2 = 0L;
			DataRow[] array2 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			for (int i = 0; i < array2.Length; i = checked(i + 1))
			{
				long num3 = Conversions.ToLong(array2[i]["ComponentID"]);
				long num4 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num3)["ComponentID"]);
				flag = true;
				DataRow[] array3 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
				for (int j = 0; j < array3.Length; j = checked(j + 1))
				{
					long num5 = Conversions.ToLong(array3[j]["ComponentID"]);
					long num6 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num5)["Type"]);
					num2++;
					array = (long[])Utils.CopyArray((Array)array, (Array)new long[(int)(num2 - 1L) + 1]);
					array[(int)(num2 - 1L)] = num6;
				}
			}
			DataRow[] array4 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			for (int k = 0; k < array4.Length; k = checked(k + 1))
			{
				long num7 = Conversions.ToLong(array4[k]["ComponentID"]);
				long num8 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num7)["Type"]);
				bool flag2 = false;
				long num9 = num2 - 1L;
				for (long num10 = 0L; num10 <= num9; num10++)
				{
					if (num8 == array[(int)num10])
					{
						flag2 = true;
					}
				}
				if (!flag2 && flag)
				{
					string text = "Comm gear " + Conversions.ToString(num7) + " is not used by any weapons.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 < 10000L)
				{
					string text = "Mounts may only use weapon datalinks.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200065", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMountMagazinesHaveCorrectAmmo()
	{
		try
		{
			string name = "SELECT ID FROM DataMount";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long[] array = new long[0];
				long num2 = 0L;
				DataRow[] array2 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array2[i]["ComponentID"]);
					long num4 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num3)["ComponentID"]);
					num2++;
					array = (long[])Utils.CopyArray((Array)array, (Array)new long[(int)(num2 - 1L) + 1]);
					array[(int)(num2 - 1L)] = num4;
				}
				DataRow[] array3 = Common.get_DataMountMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int j = 0; j < array3.Length; j = checked(j + 1))
				{
					long num5 = Conversions.ToLong(array3[j]["ComponentID"]);
					long num6 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num5)["ComponentID"]);
					bool flag = false;
					long num7 = num2 - 1L;
					for (long num8 = 0L; num8 <= num7; num8++)
					{
						if (num6 == array[(int)num8])
						{
							flag = true;
						}
					}
					if (!flag)
					{
						string text = "Mount magazine weapon record " + Conversions.ToString(num5) + " has weapons that are not present on the mount.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200066", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void CheckNonLocalControlMountsHaveMountDirectorsOrWeaponDirectorsOrDatalinks()
	{
		try
		{
			string name = "SELECT ID, LocalControl FROM DataMount";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			double num4 = default(double);
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				bool num2 = Conversions.ToBoolean(recordset2.Fields["LocalControl"].Value);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				if (!num2)
				{
					flag = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 0;
					DataRow[] array = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int i = 0; i < array.Length; i = checked(i + 1))
					{
						double num3 = Conversions.ToDouble(array[i]["ComponentID"]);
						num4 = Conversions.ToDouble(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num3)["ComponentID"]);
						int num5 = Conversions.ToInteger(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]);
						if (!(num5 == 2001 || num5 == 2002 || num5 == 2004))
						{
							continue;
						}
						flag6 = true;
						flag2 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4)).Length > 0;
						flag3 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4)).Length > 0;
						flag4 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4)).Length > 0;
						DataRow[] array2 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
						for (int j = 0; j < array2.Length; j = checked(j + 1))
						{
							double num6 = Conversions.ToDouble(array2[j]["CodeID"]);
							if (num6 == 6101.0 || num6 == 6102.0 || num6 == 6103.0 || num6 == 9001.0)
							{
								flag5 = true;
							}
						}
					}
					if (flag6 && !flag && !flag2 && !flag3 && !flag4 && !flag5)
					{
						string text = "Mount is not Local Control, has no director, and Weapon " + Conversions.ToString(num4) + " has no direcor, no DL, no sensors, no INS/TERCOM/GPS guidance. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200067", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_2(int int_0, DataRow[] dataRow_0, object object_0)
	{
		try
		{
			foreach (DataRow obj in dataRow_0)
			{
				double num = Conversions.ToDouble(obj["ComponentNumber"]);
				double num2 = Conversions.ToDouble(obj["ComponentID"]);
				double num3 = Conversions.ToDouble(obj["SB1"]);
				double num4 = Conversions.ToDouble(obj["SB2"]);
				double num5 = Conversions.ToDouble(obj["SMF1"]);
				double num6 = Conversions.ToDouble(obj["SMF2"]);
				double num7 = Conversions.ToDouble(obj["SMA1"]);
				double num8 = Conversions.ToDouble(obj["SMA2"]);
				double num9 = Conversions.ToDouble(obj["SS1"]);
				double num10 = Conversions.ToDouble(obj["SS2"]);
				double num11 = Conversions.ToDouble(obj["PB1"]);
				double num12 = Conversions.ToDouble(obj["PB2"]);
				double num13 = Conversions.ToDouble(obj["PMF1"]);
				double num14 = Conversions.ToDouble(obj["PMF2"]);
				double num15 = Conversions.ToDouble(obj["PMA1"]);
				double num16 = Conversions.ToDouble(obj["PMA2"]);
				double num17 = Conversions.ToDouble(obj["PS1"]);
				double num18 = Conversions.ToDouble(obj["PS2"]);
				bool flag = false;
				if (num3 == 0.0 && num4 == 0.0 && num5 == 0.0 && num6 == 0.0 && num7 == 0.0 && num8 == 0.0 && num9 == 0.0 && num10 == 0.0 && num11 == 0.0 && num12 == 0.0 && num13 == 0.0 && num14 == 0.0 && num15 == 0.0 && num16 == 0.0 && num17 == 0.0 && num18 == 0.0)
				{
					string text = "Mount " + Conversions.ToString(num) + " with ID " + Conversions.ToString(num2) + " does not have an arc defined!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + (string)object_0 + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					flag = true;
				}
				DataRow[] array = Common.get_MiscMountDefault(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
				bool flag2 = false;
				bool flag3 = false;
				DataRow[] array2 = array;
				foreach (DataRow obj2 in array2)
				{
					double num19 = Conversions.ToDouble(obj2["SB1"]);
					double num20 = Conversions.ToDouble(obj2["SB2"]);
					double num21 = Conversions.ToDouble(obj2["SMF1"]);
					double num22 = Conversions.ToDouble(obj2["SMF2"]);
					double num23 = Conversions.ToDouble(obj2["SMA1"]);
					double num24 = Conversions.ToDouble(obj2["SMA2"]);
					double num25 = Conversions.ToDouble(obj2["SS1"]);
					double num26 = Conversions.ToDouble(obj2["SS2"]);
					double num27 = Conversions.ToDouble(obj2["PB1"]);
					double num28 = Conversions.ToDouble(obj2["PB2"]);
					double num29 = Conversions.ToDouble(obj2["PMF1"]);
					double num30 = Conversions.ToDouble(obj2["PMF2"]);
					double num31 = Conversions.ToDouble(obj2["PMA1"]);
					double num32 = Conversions.ToDouble(obj2["PMA2"]);
					double num33 = Conversions.ToDouble(obj2["PS1"]);
					double num34 = Conversions.ToDouble(obj2["PS2"]);
					flag3 = true;
					if (num3 == num19 && num4 == num20 && num5 == num21 && num6 == num22 && num7 == num23 && num8 == num24 && num9 == num25 && num10 == num26 && num11 == num27 && num12 == num28 && num13 == num29 && num14 == num30 && num15 == num31 && num16 == num32 && num17 == num33 && num18 == num34)
					{
						flag2 = true;
					}
				}
				if (!flag2 && flag3 && !flag)
				{
					string text = "Mount " + Conversions.ToString(num) + " with ID " + Conversions.ToString(num2) + " does not have a legal arc!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + (string)object_0 + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200068", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMountDefaultArcs()
	{
		try
		{
			string name = "SELECT ID FROM DataAircraft";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow[] dataRow_ = Common.get_DataAircraftMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				smethod_2((int)num, dataRow_, "Aircraft");
				recordset2.MoveNext();
			}
			recordset2 = null;
			recordset.Close();
			string name2 = "SELECT ID FROM DataShip";
			Recordset recordset3 = Common.theSourceDB.OpenRecordset(name2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset4 = recordset3;
			while (!recordset4.EOF)
			{
				long num2 = Conversions.ToLong(recordset4.Fields["ID"].Value);
				DataRow[] dataRow_2 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
				smethod_2((int)num2, dataRow_2, "Ship");
				recordset4.MoveNext();
			}
			recordset4 = null;
			recordset3.Close();
			string name3 = "SELECT ID FROM DataSubmarine";
			Recordset recordset5 = Common.theSourceDB.OpenRecordset(name3, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset6 = recordset5;
			while (!recordset6.EOF)
			{
				long num3 = Conversions.ToLong(recordset6.Fields["ID"].Value);
				DataRow[] dataRow_3 = Common.get_DataSubmarineMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				smethod_2((int)num3, dataRow_3, "Submarine");
				recordset6.MoveNext();
			}
			recordset6 = null;
			recordset5.Close();
			string name4 = "SELECT ID FROM DataFacility";
			Recordset recordset7 = Common.theSourceDB.OpenRecordset(name4, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset8 = recordset7;
			while (!recordset8.EOF)
			{
				long num4 = Conversions.ToLong(recordset8.Fields["ID"].Value);
				DataRow[] dataRow_4 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
				smethod_2((int)num4, dataRow_4, "Facility");
				recordset8.MoveNext();
			}
			recordset8 = null;
			recordset7.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200070", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponsLegalTargetsVsMountDirectorCapabilities()
	{
		try
		{
			string name = "SELECT ID, Name FROM DataMount";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				string text = Conversions.ToString(recordset2.Fields["Name"].Value);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				DataRow[] array = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag6;
				bool flag7;
				bool flag8;
				bool flag9;
				DataRow[] array4;
				checked
				{
					for (int i = 0; i < array.Length; i++)
					{
						double num2 = Conversions.ToDouble(array[i]["ComponentID"]);
						double num3 = Conversions.ToDouble(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num2)["ComponentID"]);
						DataRow[] array2 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int j = 0; j < array2.Length; j++)
						{
							long num4 = Conversions.ToLong(array2[j]["CodeID"]);
							if (num4 == 1001L)
							{
								flag = true;
							}
							if (num4 == 1002L)
							{
								flag2 = true;
							}
							if (num4 == 1003L)
							{
								flag3 = true;
							}
							if (num4 == 2001L)
							{
								flag4 = true;
							}
							if (num4 == 2002L)
							{
								flag5 = true;
							}
						}
					}
					DataRow[] array3 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag6 = false;
					flag7 = false;
					flag8 = false;
					flag9 = false;
					array4 = array3;
				}
				for (int num5 = 0; num5 < array4.Length; num5 = checked(num5 + 1))
				{
					double num6 = Conversions.ToDouble(array4[num5]["ComponentID"]);
					long num7 = Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num6)["Type"]);
					if (num7 == 9001L)
					{
						string text2 = "Mount Director " + Conversions.ToString(num6) + " may not be of type Sensor Group. Add each individual sensor in the group!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					DataRow[] array5 = Common.get_DataSensorFrequencySearchAndTrack(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
					bool flag10 = false;
					DataRow[] array6 = array5;
					for (int k = 0; k < array6.Length; k = checked(k + 1))
					{
						if (Conversions.ToLong(array6[k]["Frequency"]) > 0L)
						{
							flag10 = true;
						}
					}
					if (!flag10 && num7 != 4001L && num7 != 4002L && num7 != 4003L)
					{
						string text2 = "Mount Director " + Conversions.ToString(num6) + " has no Search Band! Gun directors need search band, not illuminator band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					DataRow[] array7;
					if (DataValidateAircraft.Cache_SensorCapabilities.ContainsKey((int)Math.Round(num6)))
					{
						array7 = DataValidateAircraft.Cache_SensorCapabilities[(int)Math.Round(num6)];
					}
					else
					{
						array7 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
						DataValidateAircraft.Cache_SensorCapabilities.TryAdd((int)Math.Round(num6), array7);
					}
					DataRow[] array8 = array7;
					for (int l = 0; l < array8.Length; l = checked(l + 1))
					{
						long num8 = Conversions.ToLong(array8[l]["CodeID"]);
						if (num8 == 1001L)
						{
							flag6 = true;
						}
						if (num8 == 1002L)
						{
							flag7 = true;
						}
						if (num8 == 1003L)
						{
							flag8 = true;
						}
						if (num8 == 1011L)
						{
							flag9 = true;
						}
					}
					bool flag11 = false;
					int num9;
					if (!(flag & (Strings.InStr(1, text, "127mm", (CompareMethod)0) == 0)))
					{
						num9 = 0;
					}
					else
					{
						flag11 = true;
						num9 = 0;
					}
					bool flag12 = (byte)num9 != 0;
					int num10;
					if (Strings.InStr(1, text, "Merkava Mk.4M", (CompareMethod)0) <= 0 && Strings.InStr(1, text, "Namer", (CompareMethod)0) <= 0)
					{
						if (Strings.InStr(1, text, "Armata", (CompareMethod)0) <= 0)
						{
							goto IL_04e2;
						}
						num10 = 1;
					}
					else
					{
						num10 = 1;
					}
					flag12 = (byte)num10 != 0;
					goto IL_04e2;
					IL_04e2:
					if (!flag12 && num7 != 4001L && num7 != 4002L && num7 != 4003L && (flag || flag2 || flag3) && !flag6 && !flag9)
					{
						string text2 = "Weapon is capable against air targets but Mount Director " + Conversions.ToString(num6) + " is not Air Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag12 && !flag11 && flag4 && !flag7)
					{
						string text2 = "Weapon is capable against ship targets but Mount Director " + Conversions.ToString(num6) + " is not Surface Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag12 && flag5 && !flag8)
					{
						string text2 = "Weapon is capable against submarine targets but Mount Director " + Conversions.ToString(num6) + " is not Submarine Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
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
			ex2.Data.Add("Error at Validation 200069", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAllSensorsOnMountsAreCapableVsSameTargets()
	{
		try
		{
			string name = "SELECT ID FROM DataMount";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
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
				DataRow[] array = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag18 = true;
				bool flag19 = true;
				DataRow[] array2 = array;
				foreach (DataRow obj in array2)
				{
					long num2 = Conversions.ToLong(obj["ComponentID"]);
					Conversions.ToLong(obj["ComponentNumber"]);
					bool flag20 = false;
					bool flag21 = false;
					bool flag22 = false;
					bool flag23 = false;
					bool flag24 = false;
					bool flag25 = false;
					bool flag26 = false;
					bool flag27 = false;
					bool flag28 = false;
					bool flag29 = false;
					bool flag30 = false;
					bool flag31 = false;
					bool flag32 = false;
					bool flag33 = false;
					bool flag34 = false;
					bool flag35 = false;
					bool flag36 = false;
					DataRow? dataRow = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num2);
					long num3 = Conversions.ToLong(dataRow["Type"]);
					if (Conversions.ToLong(dataRow["Role"]) != 2049L)
					{
						if (num3 == 9001L)
						{
							string text = "Mounts may not have sensor groups as on-mount sensors! (Sensor ID: " + Conversions.ToString(num2) + ")";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						DataRow[] array3;
						if (DataValidateAircraft.Cache_SensorCapabilities.ContainsKey((int)num2))
						{
							array3 = DataValidateAircraft.Cache_SensorCapabilities[(int)num2];
						}
						else
						{
							array3 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
							DataValidateAircraft.Cache_SensorCapabilities.TryAdd((int)num2, array3);
						}
						DataRow[] array4 = array3;
						for (int j = 0; j < array4.Length; j = checked(j + 1))
						{
							long num4 = Conversions.ToLong(array4[j]["CodeID"]);
							if (flag18 && (num3 == 2003L || num3 == 2004L || num3 == 4001L || num3 == 4002L || num3 == 4003L))
							{
								if (num4 == 1001L)
								{
									flag = true;
								}
								if (num4 == 1002L)
								{
									flag2 = true;
								}
								if (num4 == 1003L)
								{
									flag3 = true;
								}
								if (num4 == 1004L)
								{
									flag4 = true;
								}
								if (num4 == 1005L)
								{
									flag5 = true;
								}
								if (num4 == 2002L)
								{
									flag7 = true;
								}
								if (num4 == 2003L)
								{
									flag8 = true;
								}
							}
							if (!flag18 && (num3 == 2003L || num3 == 2004L || num3 == 4001L || num3 == 4002L || num3 == 4003L))
							{
								if (num4 == 1001L)
								{
									flag20 = true;
								}
								if (num4 == 1002L)
								{
									flag21 = true;
								}
								if (num4 == 1003L)
								{
									flag22 = true;
								}
								if (num4 == 1004L)
								{
									flag23 = true;
								}
								if (num4 == 1005L)
								{
									flag24 = true;
								}
								if (num4 == 2002L)
								{
									flag26 = true;
								}
								if (num4 == 2003L)
								{
									flag27 = true;
								}
							}
							if (flag19 && num3 == 2001L)
							{
								if (num4 == 1001L)
								{
									flag10 = true;
								}
								if (num4 == 1002L)
								{
									flag11 = true;
								}
								if (num4 == 1004L)
								{
									flag12 = true;
								}
								if (num4 == 1005L)
								{
									flag13 = true;
								}
								if (num4 == 2001L)
								{
									flag14 = true;
								}
								if (num4 == 2003L)
								{
									flag16 = true;
								}
								if (num4 == 2004L)
								{
									flag17 = true;
								}
							}
							if (!flag19 && num3 == 2001L)
							{
								if (num4 == 1001L)
								{
									flag29 = true;
								}
								if (num4 == 1002L)
								{
									flag30 = true;
								}
								if (num4 == 1004L)
								{
									flag31 = true;
								}
								if (num4 == 1005L)
								{
									flag32 = true;
								}
								if (num4 == 2001L)
								{
									flag33 = true;
								}
								if (num4 == 2003L)
								{
									flag35 = true;
								}
								if (num4 == 2004L)
								{
									flag36 = true;
								}
							}
						}
					}
					if (!flag18 && (num3 == 2003L || num3 == 2004L || num3 == 4001L || num3 == 4002L || num3 == 4003L))
					{
						if (flag20 && !flag)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Air Search capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag20 && flag)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Air Search capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag21 && !flag2)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Surface Search capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag21 && flag2)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Surface Search capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag22 && !flag3)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Submarine Search capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag22 && flag3)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Submarine Search capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag23 && !flag4)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Land Search - Fixed Facility capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag23 && flag4)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Land Search - Fixed Facility capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag24 && !flag5)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Land Search - Mobile Unit capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag24 && flag5)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Land Search - Mobile Unit capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag25 && !flag6)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Range Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag25 && flag6)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Range Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag26 && !flag7)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Altitude Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag26 && flag7)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Altitude Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag27 && !flag8)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Speed Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag27 && flag8)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Speed Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag28 && !flag9)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Heading Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag28 && flag9)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Heading Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (!flag19 && num3 == 2001L)
					{
						if (flag29 && !flag10)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Air Search capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag29 && flag10)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Air Search capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag30 && !flag11)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Surface Search capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag30 && flag11)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Surface Search capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag31 && !flag12)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Land Search - Fixed Facility capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag31 && flag12)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Land Search - Fixed Facility capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag32 && !flag13)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Land Search - Mobile Unit capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag32 && flag13)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Land Search - Mobile Unit capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag33 && !flag14)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Range Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag33 && flag14)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Range Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag34 && !flag15)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Altitude Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && flag16)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Speed Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag36 && !flag17)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " has Heading Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag36 && flag17)
						{
							string text = "Mount Sensor " + Conversions.ToString(num2) + " lacks Heading Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag18 && (num3 == 2003L || num3 == 2004L || num3 == 4001L || num3 == 4002L || num3 == 4003L))
					{
						flag18 = false;
					}
					if (flag19 && num3 == 2001L)
					{
						flag19 = false;
					}
				}
				if (!flag19 && !flag18)
				{
					if (!flag && flag10)
					{
						string text = "Grouped IR/Visual/Laser Sensor lacks Air Search capability while other radar sensors in the group are capable. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && !flag10)
					{
						string text = "Grouped IR/Visual/Laser Sensor has Air Search capability while a radar in the group is not. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200071", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateMount()
	{
		Class72.smethod_20();
	}
}
