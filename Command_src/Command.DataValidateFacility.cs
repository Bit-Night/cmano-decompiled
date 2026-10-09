using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateFacility
{
	[CompilerGenerated]
	internal sealed class _Closure$__5-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__5-0(_Closure$__5-0 arg0)
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
			Common.StatusString = "ValidateFacilityDirectorsAndIlluminatorsHaveCorrespondingWeapons - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__5-0()
		{
			Class72.smethod_20();
		}
	}

	public static void ValidateFacilityStatsAndFlags()
	{
		try
		{
			DataTable dataTable = Common.get_DataFacility(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = 0L;
				long num2 = 0L;
				bool flag = false;
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateFacilityStatsAndFlags - Facility #" + Conversions.ToString(num3);
				long num4 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Category" }, (string[])null));
				Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "DamagePoints" }, (string[])null));
				long num5 = Conversions.ToLong((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODADetectionCycle" }, (string[])null)))) ? NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODADetectionCycle" }, (string[])null) : ((object)0));
				num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODATargetingCycle" }, (string[])null));
				num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODAEvasiveCycle" }, (string[])null));
				DataRow? dataRow = Common.get_MiscFacility(Common.mySourceDB_Helper).Rows.Find(num3);
				long num6 = Conversions.ToLong(dataRow["ModifierRadar"]);
				long num7 = Conversions.ToLong(dataRow["ModifierIR"]);
				long num8 = Conversions.ToLong(dataRow["ModifierVisual"]);
				if (num4 == 1001L)
				{
					string text = "This facility does not have a valid facility category.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 == 1001L)
				{
					string text = "This facility does not have a valid Radar Modifier.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 == 1001L)
				{
					string text = "This facility does not have a valid Visual Modifier.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 == 1001L)
				{
					string text = "This facility does not have a valid IR Modifier.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 2001L && num4 <= 3999L && num4 != 3004L && (num6 < 2001L || num6 > 2999L) && num6 != 9001L)
				{
					string text = "This is a building/structure, and radar signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 2001L && num4 <= 3999L && num4 != 3004L && (num8 < 2001L || num8 > 2999L) && num8 != 9001L)
				{
					string text = "This is a building/structure, and visual signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 2001L && num4 <= 3999L && num4 != 3004L && (num7 < 2001L || num7 > 2999L) && num7 != 9001L)
				{
					string text = "This is a building/structure, and IR signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 6001L && num4 <= 6999L && (num6 < 2001L || num6 > 2999L))
				{
					string text = "This is a building/structure, and radar signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 6001L && num4 <= 6999L && (num8 < 2001L || num8 > 2999L))
				{
					string text = "This is a building/structure, and visual signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 6001L && num4 <= 6999L && (num7 < 2001L || num7 > 2999L))
				{
					string text = "This is a building/structure, and IR signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 5001L && (num6 < 3001L || num6 > 3999L))
				{
					string text = "This is a vehicle, and radar signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 5001L && (num8 < 3001L || num8 > 3999L))
				{
					string text = "This is a vehicle, and visual signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 5001L && (num7 < 3001L || num7 > 3999L))
				{
					string text = "This is a vehicle, and IR signature modifier makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 5002L && num6 != 9001L)
				{
					string text = "This unit is personnel, radar signature modifier must be Not Detectable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 5002L && num8 != 4001L && num8 != 4002L && num8 != 4003L && num8 != 4004L && num8 != 9001L)
				{
					string text = "This unit is personnel, visual signature is not correct!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 5002L && num7 != 4001L && num7 != 4002L && num7 != 4003L && num7 != 4004L && num7 != 9001L)
				{
					string text = "This unit is personnel, IR signature is not correct!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 4001L && num6 != 9001L)
				{
					string text = "This is an underwater facility, and radar signature modifier must be Not Detectable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 3004L && num8 != 9001L && num8 != 2001L)
				{
					string text = "This is an underground facility or missile silo, and visual signature modifier must be Not Detectable or Very Small Signature!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 == 3004L && num7 != 9001L && num8 != 2001L)
				{
					string text = "This is an underground facility or missile silo, and IR signature modifier must be Not Detectable or Very Small Signature!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				DataRow[] array = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				checked
				{
					for (int i = 0; i < array.Length; i++)
					{
						long num9 = Conversions.ToLong(array[i]["ComponentID"]);
						DataRow[] array2 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num9));
						for (int j = 0; j < array2.Length; j++)
						{
							long num10 = Conversions.ToLong(array2[j]["ComponentID"]);
							DataRow[] array3 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
							for (int k = 0; k < array3.Length; k++)
							{
								long num11 = Conversions.ToLong(array3[k]["ComponentID"]);
								long num12 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num11)["Type"]);
								if (unchecked(num12 == 2001L || num12 == 2002L || num12 == 2003L || num12 == 2009L || num12 == 2004L || num12 == 4001L || num12 == 4002L || num12 == 4004L || num12 == 4005L || num12 == 4006L || num12 == 4007L || num12 == 6001L || num12 == 8001L))
								{
									flag = true;
								}
							}
						}
					}
					if (num5 == 0L)
					{
						string text = "Unit has an OODA Detection Cycle of 0 (or blank).";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num == 0L && flag)
				{
					string text = "Unit carries weapons but has an OODA Targeting Cycle of 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num > 0L && !flag)
				{
					string text = "Unit has an OODA Targeting Cycle but carries no weapons.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 0L)
				{
					string text = "Enter a valid OODA Evasive Cycle.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200040", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityMagazineWeaponsExistsOnMounts()
	{
		try
		{
			DataTable dataTable = Common.get_DataFacility(Common.mySourceDB_Helper);
			long num5 = default(long);
			bool flag = default(bool);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateFacilityMagazineWeaponsExistsOnMounts - Facility #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				DataRow[] array3 = array;
				DataTable dataTable2;
				checked
				{
					for (int i = 0; i < array3.Length; i++)
					{
						long num3 = Conversions.ToLong(array3[i]["ComponentID"]);
						DataRow[] array4 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int j = 0; j < array4.Length; j++)
						{
							long num4 = Conversions.ToLong(array4[j]["ComponentID"]);
							DataRow[] array5 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
							for (int k = 0; k < array5.Length; k++)
							{
								num5 = Conversions.ToLong(array5[k]["ComponentID"]);
								unchecked
								{
									num2++;
									array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
									array2[(int)(num2 - 1L)] = num5;
								}
							}
						}
					}
					string string_ = "SELECT DISTINCT DataFacilityMagazines.ComponentID FROM DataFacilityMagazines WHERE DataFacilityMagazines.ID = " + Conversions.ToString(num) + " AND DataFacilityMagazines.ComponentID IN (SELECT DataMagazine.ID FROM DataMagazine WHERE DataMagazine.AviationMagazine = 0)";
					dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				}
				foreach (object row2 in dataTable2.Rows)
				{
					long num6 = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row2), new object[1] { "ComponentID" }, (string[])null));
					DataRow[] array6 = Common.get_DataMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
					for (int l = 0; l < array6.Length; l = checked(l + 1))
					{
						long num4 = Conversions.ToLong(array6[l]["ComponentID"]);
						DataRow[] array7 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
						for (int m = 0; m < array7.Length; m = checked(m + 1))
						{
							num5 = Conversions.ToLong(array7[m]["ComponentID"]);
							long num7 = num2 - 1L;
							for (long num8 = 0L; num8 <= num7; num8++)
							{
								if (num5 == array2[(int)num8])
								{
									flag = true;
								}
							}
						}
						int num9;
						if (!flag)
						{
							string text = "Weapon " + Conversions.ToString(num5) + " in Magazine " + Conversions.ToString(num6) + " does exist on any mounts.";
							string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200041", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilitiesHaveIlluminatorsForWeapons()
	{
		checked
		{
			try
			{
				DataTable dataTable = Common.get_DataFacility(Common.mySourceDB_Helper);
				long num7 = default(long);
				long num13 = default(long);
				bool flag = default(bool);
				bool flag2 = default(bool);
				foreach (object row in dataTable.Rows)
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
					Common.StatusString = "ValidateFacilitiesHaveIlluminatorsForWeapons - Facility #" + Conversions.ToString(num);
					DataRow[] array = Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					List<int> list = new List<int>();
					DataRow[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						long num2 = Conversions.ToLong(array2[i]["ComponentID"]);
						list.Add(unchecked((int)num2));
					}
					DataRow[] array3 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int j = 0; j < array3.Length; j++)
					{
						long num3 = Conversions.ToLong(array3[j]["ComponentID"]);
						DataRow dataRow = Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num3);
						if (!Information.IsNothing((object)dataRow) && Conversions.ToLong(dataRow["LocalControl"]) == 0L)
						{
							DataRow[] array4 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
							for (int k = 0; k < array4.Length; k++)
							{
								long num4 = Conversions.ToLong(array4[k]["ComponentID"]);
								list.Add(unchecked((int)num4));
							}
						}
					}
					DataRow[] array5 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					DataRow[] array6 = array5;
					for (int l = 0; l < array6.Length; l++)
					{
						long num5 = Conversions.ToLong(array6[l]["ComponentID"]);
						DataRow[] array7 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num5));
						if (!Information.IsNothing((object)array7))
						{
							DataRow[] array8 = array7;
							for (int m = 0; m < array8.Length; m++)
							{
								long num6 = Conversions.ToLong(array8[m]["ComponentID"]);
								list.Add(unchecked((int)num6));
							}
						}
					}
					List<int> list2 = new List<int>();
					foreach (int item in list)
					{
						try
						{
							num7 = Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(item)["Type"]);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception theExc = ex;
							ErrorManagement.EnqueueErrorMessage(theExc);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						if (num7 == 9001L)
						{
							DataRow[] array9 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(item));
							for (int n = 0; n < array9.Length; n++)
							{
								long num8 = Conversions.ToLong(array9[n]["ComponentID"]);
								list2.Add(unchecked((int)num8));
							}
						}
					}
					list.AddRange(list2);
					DataRow[] array10 = array5;
					for (int num9 = 0; num9 < array10.Length; num9++)
					{
						long num5 = Conversions.ToLong(array10[num9]["ComponentID"]);
						DataRow[] array11 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num5));
						for (int num10 = 0; num10 < array11.Length; num10++)
						{
							long num11 = Conversions.ToLong(array11[num10]["ComponentID"]);
							long num12 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num11)["ComponentID"]);
							DataRow[] array12 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num13));
							for (int num14 = 0; num14 < array12.Length; num14++)
							{
								num13 = Conversions.ToLong(array12[num14]["ComponentID"]);
								flag = true;
								flag2 = list.Contains(unchecked((int)num13));
							}
							unchecked
							{
								int num15;
								if (!flag2 && flag)
								{
									string text = "Weapon " + Conversions.ToString(num12) + " in Mount " + Conversions.ToString(num5) + " has no illuminator.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									num15 = 0;
								}
								else
								{
									num15 = 0;
								}
								flag2 = (byte)num15 != 0;
								flag = false;
							}
						}
					}
				}
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				Exception ex3 = ex2;
				ErrorManagement.EnqueueErrorMessage(ex3);
				ex3.Data.Add("Error at Validation 200042", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static void ValidateFacilitiesHaveDirectorsForMounts()
	{
		try
		{
			DataTable dataTable = Common.get_DataFacility(Common.mySourceDB_Helper);
			object obj2 = default(object);
			object obj3 = default(object);
			bool flag2 = default(bool);
			bool flag3 = default(bool);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateFacilitiesHaveDirectorsForMounts - Facility #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				DataRow[] array3 = array;
				for (int i = 0; i < array3.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array3[i]["ComponentID"]);
					num2++;
					array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
					array2[(int)(num2 - 1L)] = num3;
				}
				DataRow[] array4 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				DataRow[] array5 = array4;
				for (int j = 0; j < array5.Length; j = checked(j + 1))
				{
					long num4 = Conversions.ToLong(array5[j]["ComponentID"]);
					DataRow[] array6 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
					for (int k = 0; k < array6.Length; k = checked(k + 1))
					{
						long num5 = Conversions.ToLong(array6[k]["ComponentID"]);
						num2++;
						array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
						array2[(int)(num2 - 1L)] = num5;
					}
				}
				object obj = num2;
				if (ForLoopControl.ForLoopInitObj(obj2, (object)0, Operators.SubtractObject(obj, (object)1), (object)1, ref obj3, ref obj2))
				{
					do
					{
						if (Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(array2[Conversions.ToInteger(obj2)])["Type"]) == 9001L)
						{
							DataRow[] array7 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(array2[Conversions.ToInteger(obj2)]));
							for (int l = 0; l < array7.Length; l = checked(l + 1))
							{
								long num6 = Conversions.ToLong(array7[l]["ComponentID"]);
								num2++;
								array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
								array2[(int)(num2 - 1L)] = num6;
							}
						}
					}
					while (ForLoopControl.ForNextCheckObj(obj2, obj3, ref obj2));
				}
				DataRow[] array8 = array4;
				for (int m = 0; m < array8.Length; m = checked(m + 1))
				{
					long num4 = Conversions.ToLong(array8[m]["ComponentID"]);
					bool flag = false;
					DataRow dataRow = Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num4);
					int num7;
					if (!Information.IsNothing((object)dataRow))
					{
						flag = Conversions.ToBoolean(dataRow["LocalControl"]);
						DataRow[] array9 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
						for (int n = 0; n < array9.Length; n = checked(n + 1))
						{
							long value = Conversions.ToLong(array9[n]["ComponentID"]);
							flag2 = true;
							if (array2.Contains(value))
							{
								flag3 = true;
								break;
							}
						}
						if (!(!flag3 && flag2 && !flag))
						{
							num7 = 0;
						}
						else
						{
							string text = "Mount " + Conversions.ToString(num4) + " has no director!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							num7 = 0;
						}
					}
					else
					{
						num7 = 0;
					}
					flag3 = (byte)num7 != 0;
					flag2 = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200043", "");
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
			bool flag = false;
			long[] array = new long[0];
			long num = 0L;
			DataRow[] array2 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(int_0));
			checked
			{
				long num10 = default(long);
				for (int i = 0; i < array2.Length; i++)
				{
					long num2 = Conversions.ToLong(array2[i]["ComponentID"]);
					DataRow[] array3 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
					for (int j = 0; j < array3.Length; j++)
					{
						long num3 = Conversions.ToLong(array3[j]["ComponentID"]);
						long num4 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num3)["ComponentID"]);
						if (Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]) == 2004L)
						{
							flag = true;
						}
						DataRow[] array4 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
						for (int k = 0; k < array4.Length; k++)
						{
							long num5 = Conversions.ToLong(array4[k]["ComponentID"]);
							bool flag2 = false;
							unchecked
							{
								if (array.Count() > 0)
								{
									long num6 = num - 1L;
									for (long num7 = 0L; num7 <= num6; num7++)
									{
										if (array[(int)num7] == num5)
										{
											flag2 = true;
											break;
										}
									}
								}
								if (!flag2)
								{
									num++;
									array = (long[])Utils.CopyArray((Array)array, (Array)new long[(int)(num - 1L) + 1]);
									array[(int)(num - 1L)] = num5;
								}
							}
						}
					}
					DataRow[] array5 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
					for (int l = 0; l < array5.Length; l++)
					{
						long num8 = Conversions.ToLong(array5[l]["ComponentID"]);
						bool flag3 = false;
						unchecked
						{
							long num9 = 0 - ((num10 == num) ? 1 : 0);
							for (num10 = 0L; num10 <= num9; num10++)
							{
								if (array[(int)num10] == num8)
								{
									flag3 = true;
								}
							}
							if (!flag3)
							{
								num++;
								array = (long[])Utils.CopyArray((Array)array, (Array)new long[(int)(num - 1L) + 1]);
								array[(int)(num - 1L)] = num8;
							}
						}
					}
				}
				DataRow[] array6 = Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(int_0));
				for (int m = 0; m < array6.Length; m++)
				{
					double num11 = Conversions.ToDouble(array6[m]["ComponentID"]);
					DataRow? dataRow = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num11);
					double num12 = Conversions.ToDouble(dataRow["Type"]);
					double num13 = Conversions.ToDouble(dataRow["Role"]);
					unchecked
					{
						bool flag4;
						if (num12 == 9001.0)
						{
							DataRow[] array7 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num11));
							for (int n = 0; n < array7.Length; n = checked(n + 1))
							{
								long num14 = Conversions.ToLong(array7[n]["ComponentID"]);
								DataRow? dataRow2 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num14);
								Conversions.ToDouble(dataRow2["Type"]);
								double num15 = Conversions.ToDouble(dataRow2["Role"]);
								flag4 = false;
								if (!(num15 == 2191.0 || (num15 >= 2200.0 && num15 <= 2207.0) || num15 == 2041.0 || num15 == 2681.0 || num15 == 2682.0 || num15 == 2781.0 || num15 == 2782.0 || num15 == 2881.0 || num15 == 2882.0 || num15 == 6081.0 || num15 == 6082.0))
								{
									continue;
								}
								long num16 = num - 1L;
								for (long num17 = 0L; num17 <= num16; num17++)
								{
									if (num14 == array[(int)num17])
									{
										flag4 = true;
									}
								}
								if ((!flag4 && flag) || (!flag4 && !flag && num15 != 2682.0 && num15 != 2782.0 && num15 != 2882.0 && num15 != 6082.0))
								{
									string text = "Sensor " + Conversions.ToString(num14) + " in Sensor Group " + Conversions.ToString(num11) + " is a weapon director but is not required by any weapons or mounts!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							continue;
						}
						flag4 = false;
						if (!(num13 == 2191.0 || (num13 >= 2200.0 && num13 <= 2207.0) || num13 == 2041.0 || num13 == 2681.0 || num13 == 2682.0 || num13 == 2781.0 || num13 == 2782.0 || num13 == 2881.0 || num13 == 2882.0 || num13 == 6081.0 || num13 == 6082.0))
						{
							continue;
						}
						long num18 = num - 1L;
						for (long num19 = 0L; num19 <= num18; num19++)
						{
							if (num11 == (double)array[(int)num19])
							{
								flag4 = true;
							}
						}
						if ((!flag4 && flag) || (!flag4 && !flag && num13 != 2682.0 && num13 != 2782.0 && num13 != 2882.0 && num13 != 6082.0))
						{
							string text = "Sensor " + Conversions.ToString(num11) + " is a weapon director but is not required by any weapons or mounts!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				DataRow[] array8 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(int_0));
				for (int num20 = 0; num20 < array8.Length; num20++)
				{
					long num21 = Conversions.ToLong(array8[num20]["ComponentID"]);
					DataRow[] array9 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num21));
					for (int num22 = 0; num22 < array9.Length; num22++)
					{
						long num23 = Conversions.ToLong(array9[num22]["ComponentID"]);
						DataRow? dataRow3 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num23);
						Conversions.ToDouble(dataRow3["Type"]);
						double num24 = Conversions.ToDouble(dataRow3["Role"]);
						bool flag4 = false;
						unchecked
						{
							if (!(num24 == 2191.0 || (num24 >= 2200.0 && num24 <= 2007.0) || num24 == 2041.0 || num24 == 2681.0 || num24 == 2682.0 || num24 == 2781.0 || num24 == 2782.0 || num24 == 2881.0 || num24 == 2882.0 || num24 == 6081.0 || num24 == 6082.0))
							{
								continue;
							}
							long num25 = num - 1L;
							for (long num26 = 0L; num26 <= num25; num26++)
							{
								if (num23 == array[(int)num26])
								{
									flag4 = true;
								}
							}
							if ((!flag4 && flag) || (!flag4 && !flag && num24 != 2682.0 && num24 != 2782.0 && num24 != 2882.0 && num24 != 6082.0))
							{
								string text = "Sensor " + Conversions.ToString(num23) + " on Mount " + Conversions.ToString(num21) + " is a weapon director but is not required by any weapons or mounts!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
				}
			}
			int_1++;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200044", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityDirectorsAndIlluminatorsHaveCorrespondingWeapons()
	{
		try
		{
			_Closure$__5-0 arg = default(_Closure$__5-0);
			_Closure$__5-0 CS$<>8__locals7 = new _Closure$__5-0(arg);
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataFacility(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				smethod_0(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "ValidateFacilityDirectorsAndIlluminatorsHaveCorrespondingWeapons - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200045", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityNames()
	{
		try
		{
			string name = "SELECT ID FROM DataFacility";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				Common.StatusString = "ValidateFacilityNames - Facility #" + Conversions.ToString(num);
				DataRow? dataRow = Common.get_DataFacility(Common.mySourceDB_Helper).Rows.Find(num);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num16;
				if (!(num9 > 0 && num8 == 0))
				{
					num16 = 1;
				}
				else
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				if (Strings.InStr(num16, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should be none.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 > 0 && num12 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 > 0 && num15 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				int num18;
				if (Strings.InStr(num17, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should be none.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				else
				{
					num18 = 1;
				}
				int num19;
				if ((Strings.InStr(num18, text2, "KT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "KT)", (CompareMethod)0) > 0))
				{
					string text3 = "Kiloton should say \"kT\" and not \"KT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				else
				{
					num19 = 1;
				}
				int num20;
				if (!((Strings.InStr(num19, text2, "kt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "kt)", (CompareMethod)0) > 0)))
				{
					num20 = 1;
				}
				else
				{
					string text3 = "Kiloton should say \"kT\" and not \"kt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if (!((Strings.InStr(num20, text2, "mt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mt)", (CompareMethod)0) > 0)))
				{
					num21 = 1;
				}
				else
				{
					string text3 = "Megaton should say \"mT\" and not \"mt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				int num22;
				if ((Strings.InStr(num21, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num22 = 1;
				}
				else
				{
					num22 = 1;
				}
				int num23;
				if (!((Strings.InStr(num22, text2, "MK ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "MK1", (CompareMethod)0) > 0)))
				{
					num23 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num23 = 1;
				}
				int num24;
				if ((Strings.InStr(num23, text2, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num24 = 1;
				}
				else
				{
					num24 = 1;
				}
				int num25;
				if ((Strings.InStr(num24, text2, "AGM ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "AIM ", (CompareMethod)0) > 0))
				{
					string text3 = "AGM/AIM designations should use dashes \"-\" in the name, not spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num25 = 1;
				}
				else
				{
					num25 = 1;
				}
				int num26;
				if (Strings.InStr(num25, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num26 = 1;
				}
				else
				{
					num26 = 1;
				}
				int num27;
				if (Strings.InStr(num26, text2, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num27 = 1;
				}
				else
				{
					num27 = 1;
				}
				int num28;
				if (Strings.InStr(num27, text, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num28 = 1;
				}
				else
				{
					num28 = 1;
				}
				int num29;
				if (Strings.InStr(num28, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num29 = 1;
				}
				else
				{
					num29 = 1;
				}
				int num30 = Strings.InStr(num29, text2, "(", (CompareMethod)1);
				if (num30 > 0 && Operators.CompareString(Strings.Mid(text2, num30 - 1, 1), " ", true) != 0)
				{
					string text3 = "All brackets should have a space before them.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 > num3 && num3 != 0.0)
				{
					string text3 = "Unit decomissioned before it commissioned? Unlikely. Check years!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
			ex2.Data.Add("Error at Validation 200046", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilitiesHaveDatalinksForWeapons()
	{
		try
		{
			string name = "SELECT ID FROM DataFacility";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			bool flag = false;
			bool flag2 = false;
			Recordset recordset2 = recordset;
			long num5 = default(long);
			long num14 = default(long);
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				Common.StatusString = "ValidateFacilitiesHaveDatalinksForWeapons - Facility #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataFacilityComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				long[] array3 = new long[0];
				long num3 = 0L;
				DataRow[] array4 = array;
				for (int i = 0; i < array4.Length; i = checked(i + 1))
				{
					long num4 = Conversions.ToLong(array4[i]["ComponentID"]);
					num5 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]);
					if (num5 > 9999L)
					{
						num2++;
						array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
						array2[(int)(num2 - 1L)] = num5;
					}
				}
				DataRow[] array5 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				checked
				{
					if (!Information.IsNothing((object)array5))
					{
						DataRow[] array6 = array5;
						for (int j = 0; j < array6.Length; j++)
						{
							long num6 = Conversions.ToLong(array6[j]["ComponentID"]);
							if (Conversions.ToLong(Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num6)["LocalControl"]) != 0L)
							{
								continue;
							}
							DataRow[] array7 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
							for (int k = 0; k < array7.Length; k++)
							{
								long num7 = Conversions.ToLong(array7[k]["ComponentID"]);
								Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num7)["Type"]);
								unchecked
								{
									if (num5 > 9999L)
									{
										num2++;
										array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
										array2[(int)(num2 - 1L)] = num5;
									}
								}
							}
						}
					}
					DataRow[] array8 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					if (!Information.IsNothing((object)array5))
					{
						DataRow[] array9 = array8;
						for (int l = 0; l < array9.Length; l++)
						{
							long num8 = Conversions.ToLong(array9[l]["ComponentID"]);
							DataRow[] array10 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num8));
							if (Information.IsNothing((object)array10))
							{
								continue;
							}
							DataRow[] array11 = array10;
							for (int m = 0; m < array11.Length; m++)
							{
								long num9 = Conversions.ToLong(array11[m]["ComponentID"]);
								long num10 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num9)["Type"]);
								unchecked
								{
									if (num10 > 9999L)
									{
										num2++;
										array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
										array2[(int)(num2 - 1L)] = num10;
									}
								}
							}
						}
						DataRow[] array12 = array8;
						for (int n = 0; n < array12.Length; n++)
						{
							long num8 = Conversions.ToLong(array12[n]["ComponentID"]);
							DataRow[] array13 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num8));
							if (Information.IsNothing((object)array13))
							{
								continue;
							}
							DataRow[] array14 = array13;
							for (int num11 = 0; num11 < array14.Length; num11++)
							{
								long num12 = Conversions.ToLong(array14[num11]["ComponentID"]);
								DataRow[] array15 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num12));
								for (int num13 = 0; num13 < array15.Length; num13++)
								{
									num14 = Conversions.ToLong(array15[num13]["ComponentID"]);
									DataRow[] array16 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num14));
									for (int num15 = 0; num15 < array16.Length; num15++)
									{
										long num16 = Conversions.ToLong(array16[num15]["ComponentID"]);
										long num17 = 0L;
										long num18 = 0L;
										DataRow? dataRow = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num16);
										num17 = Conversions.ToLong(dataRow["IsOptional"]);
										num18 = Conversions.ToLong(dataRow["Type"]);
										if (num17 == 0L)
										{
											flag = true;
										}
										unchecked
										{
											num3++;
											array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
											array3[(int)(num3 - 1L)] = num18;
											long num19 = num2 - 1L;
											for (long num20 = 0L; num20 <= num19; num20++)
											{
												if (num18 == array2[(int)num20])
												{
													flag2 = true;
												}
											}
										}
									}
								}
								unchecked
								{
									int num21;
									if (!(!flag2 && flag))
									{
										num21 = 0;
									}
									else
									{
										string text = "Weapon " + Conversions.ToString(num14) + " in Mount " + Conversions.ToString(num8) + " has no datalink.";
										string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
										Common.mySourceDB_Helper.ExecuteNonQuery(string_);
										num21 = 0;
									}
									flag2 = (byte)num21 != 0;
									flag = false;
								}
							}
						}
					}
				}
				long num22 = num2 - 1L;
				for (long num23 = 0L; num23 <= num22; num23++)
				{
					bool flag3 = false;
					long num24 = num3 - 1L;
					for (long num25 = 0L; num25 <= num24; num25++)
					{
						if (array2[(int)num23] == array3[(int)num25])
						{
							flag3 = true;
						}
					}
					if (!flag3)
					{
						string text2 = "<Error fetching name!>";
						string name2 = "SELECT Description FROM EnumCommType WHERE ID = " + Conversions.ToString(array2[(int)num23]);
						Recordset recordset3 = Common.theSourceDB.OpenRecordset(name2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						Recordset recordset4 = recordset3;
						while (!recordset4.EOF)
						{
							text2 = Conversions.ToString(recordset4.Fields["Description"].Value);
							recordset4.MoveNext();
						}
						recordset4 = null;
						recordset3.Close();
						string text = "Weapon datalink " + text2 + " is not used by any weapons on the Facility.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200047", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityMountsAreAimpoints()
	{
		try
		{
			string name = "SELECT ID, MountsAreAimpoints, Radius, Length, Width, DamagePoints FROM DataFacility";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				Common.StatusString = "ValidateFacilityMountsAreAimpoints - Facility #" + Conversions.ToString(num);
				long num2 = Conversions.ToLong(recordset2.Fields["MountsAreAimpoints"].Value);
				long num3 = Conversions.ToLong(recordset2.Fields["Radius"].Value);
				long num4 = Conversions.ToLong(recordset2.Fields["Width"].Value);
				long num5 = Conversions.ToLong(recordset2.Fields["Length"].Value);
				double num6 = Conversions.ToDouble(recordset2.Fields["DamagePoints"].Value);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				DataRow[] array = Common.get_DataFacilityComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					long num7 = Conversions.ToLong(array[i]["ComponentID"]);
					if (Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num7)["Type"]) >= 10000L)
					{
						flag = true;
					}
				}
				flag2 = Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 0;
				DataRow[] array2 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int j = 0; j < array2.Length; j = checked(j + 1))
				{
					long num8 = Conversions.ToLong(array2[j]["ComponentID"]);
					if (num8 > 0L)
					{
						flag3 = true;
					}
					double num9 = Conversions.ToDouble(Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num8)["DamagePoints"]);
					if ((num3 > 0L || num2 == -1L) && num9 <= 0.0)
					{
						string text = "The Mounts Are Aimpoints flag is set, and Mount " + Conversions.ToString(num8) + " need damage points set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == -1L && num3 <= 0L)
				{
					string text = "The Mounts Are Aimpoints flag is but unit has no Dispersal Radius.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 > 0L && num2 == 0L)
				{
					string text = "The Dispersal Radius is but unit has no Mounts Are Aimpoints flag.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num3 > 0L || num2 == -1L) && num6 > 0.0)
				{
					string text = "The Mounts Are Aimpoints flag is set, so the unit should not have damage points.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num3 > 0L || num2 == -1L) && !flag3)
				{
					string text = "The Mounts Are Aimpoints flag is set, but the facility has no Mounts!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num3 > 0L || num2 == -1L) && flag2)
				{
					string text = "The Mounts Are Aimpoints flag is set, and the facility should not have Sensors!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num3 > 0L || num2 == -1L) && flag)
				{
					string text = "The Mounts Are Aimpoints flag is set, and the facility should not have Weapon Datalinks!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 <= 0L && num2 == 0L && num6 <= 0.0)
				{
					string text = "This facility should NOT have 0 damage points.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == -1L && ((ulong)num5 > 0uL || (ulong)num4 > 0uL))
				{
					string text = "The Mounts Are Aimpoints flag is but unit has length and width set. Not logical. Use dispersal radius.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 0L && (num5 <= 0L || num4 <= 0L))
				{
					string text = "Fixed facilities must have length and width set.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200048", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityHaveCorrectOperatorServiceAndYear()
	{
		try
		{
			string name = "SELECT ID, OperatorCountry, OperatorService, YearCommissioned, YearDecommissioned FROM DataFacility";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = 0L;
				long num2 = 0L;
				long num3 = Conversions.ToLong(recordset2.Fields["ID"].Value);
				Common.StatusString = "ValidateFacilityHaveCorrectOperatorServiceAndYear - Facility #" + Conversions.ToString(num3);
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
					string text = "Facility entered service before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 < num6 && (ulong)num2 > 0uL)
				{
					string text = "Facility decommissioned before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 > num7 && (ulong)num7 > 0uL)
				{
					string text = "Facility decommissioned after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num > num7 && (ulong)num7 > 0uL)
				{
					string text = "Facility entered service after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2100.0 && num5 != 2101.0 && num5 != 2102.0 && num5 != 2003.0 && num5 != 2104.0)
				{
					string text = "Operator is United Kingdom. Service should be a Royal-type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2079.0 && num5 != 2001.0 && num5 != 2002.0 && num5 != 2003.0 && num5 != 2005.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 1003.0)
				{
					string text = "Operator is Russia. Service should be a vanilla type, not Red Star type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2088.0 && num5 != 2201.0 && num5 != 2202.0 && num5 != 2203.0 && num5 != 2204.0 && num5 != 2205.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 2208.0 && num5 != 2209.0 && num5 != 1003.0)
				{
					string text = "Operator is Soviet Union. Service should be one of the Cold War operators!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200049", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityAircraftFacilities()
	{
		try
		{
			string name = "SELECT ID FROM DataFacility";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				Common.StatusString = "ValidateFacilityAircraftFacilities - Facility #" + Conversions.ToString(num);
				long num2 = 9999L;
				long num3 = 0L;
				long num4 = 9999L;
				long num5 = 0L;
				long num6 = 9999L;
				long num7 = 0L;
				long num8 = 9999L;
				long num9 = 0L;
				long num10 = 9999L;
				long num11 = 0L;
				long num12 = 9999L;
				long num13 = 0L;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				DataRow[] array = Common.get_DataFacilityAircraftFacilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					double num14 = Conversions.ToDouble(array[i]["ComponentID"]);
					DataRow? dataRow = Common.get_DataAircraftFacility(Common.mySourceDB_Helper).Rows.Find(num14);
					double num15 = Conversions.ToDouble(dataRow["Type"]);
					double num16 = Conversions.ToDouble(dataRow["PhysicalSize"]);
					double num17 = Conversions.ToDouble(dataRow["Capacity"]);
					Conversions.ToDouble(dataRow["RunwayLength"]);
					if (num15 == 3001.0)
					{
						if ((double)num2 > num16)
						{
							num2 = (long)Math.Round(num16);
						}
						if ((double)num3 < num16)
						{
							num3 = (long)Math.Round(num16);
						}
					}
					if (num15 == 4002.0)
					{
						flag = true;
						if ((double)num4 > num16)
						{
							num4 = (long)Math.Round(num16);
						}
						if ((double)num5 < num16)
						{
							num5 = (long)Math.Round(num16);
						}
					}
					if (num15 == 4001.0)
					{
						flag2 = true;
						if ((double)num6 > num16)
						{
							num6 = (long)Math.Round(num16);
						}
						if ((double)num7 < num16)
						{
							num7 = (long)Math.Round(num16);
						}
						if ((double)num8 > num17)
						{
							num8 = (long)Math.Round(num17);
						}
						if ((double)num9 < num17)
						{
							num9 = (long)Math.Round(num17);
						}
					}
					if (num15 == 2004.0)
					{
						flag3 = true;
						if ((double)num10 > num16)
						{
							num10 = (long)Math.Round(num16);
						}
						if ((double)num11 < num16)
						{
							num11 = (long)Math.Round(num16);
						}
					}
					if (num15 == 4003.0)
					{
						string text = "Aircraft Facility " + Conversions.ToString(num14) + " is an elevator, and should not be used on Ships!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num15 == 2005.0 || num15 == 2006.0 || num15 == 2007.0 || num15 == 3002.0)
					{
						string text = "Aircraft Facility " + Conversions.ToString(num14) + " is a land type, and should not be used on Ships!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num15 == 2001.0 || num15 == 2002.0 || num15 == 2003.0)
					{
						flag4 = true;
						if ((double)num12 > num16)
						{
							num12 = (long)Math.Round(num16);
						}
						if ((double)num13 < num16)
						{
							num13 = (long)Math.Round(num16);
						}
					}
				}
				if (flag3 && flag4 && !flag2 && !flag)
				{
					string text = "Facility has runway and runway access points, but no storage facilities.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag5 || (flag7 && flag6)) && num11 > num13 && flag3)
				{
					string text = "Elevator on aircraft carrier is larger than the runway facilities.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 != num7 && flag2)
				{
					string text = "All hangars on a Facility should be of the same aircraft size!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200050", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateFacilityHaveDatalinkDirectors()
	{
		checked
		{
			try
			{
				DataTable dataTable = Common.get_DataFacility(Common.mySourceDB_Helper);
				foreach (object row in dataTable.Rows)
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
					Common.StatusString = "ValidateFacilityHaveDatalinkDirectors - Facility #" + Conversions.ToString(num);
					DataRow[] array = Common.get_DataFacilityComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					List<int> list = new List<int>();
					List<int> list2 = new List<int>();
					List<int> list3 = new List<int>();
					List<int> list4 = new List<int>();
					bool flag = false;
					bool flag2 = false;
					DataRow[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						long num2 = Conversions.ToLong(array2[i]["ComponentID"]);
						DataRow? dataRow = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num2);
						long num3 = Conversions.ToLong(dataRow["Type"]);
						if (Conversions.ToBoolean(dataRow["WeaponLinkRequiresSensor"]) && num3 > 9000L)
						{
							flag = true;
							DataRow[] array3 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
							for (int j = 0; j < array3.Length; j++)
							{
								long num4 = Conversions.ToLong(array3[j]["ComponentID"]);
								list.Add(unchecked((int)num4));
							}
						}
					}
					DataRow[] array4 = Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int k = 0; k < array4.Length; k++)
					{
						long num5 = Conversions.ToLong(array4[k]["ComponentID"]);
						list2.Add(unchecked((int)num5));
					}
					DataRow[] array5 = Common.get_DataFacilityMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int l = 0; l < array5.Length; l++)
					{
						long num6 = Conversions.ToLong(array5[l]["ComponentID"]);
						DataRow[] array6 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
						for (int m = 0; m < array6.Length; m++)
						{
							long num7 = Conversions.ToLong(array6[m]["ComponentID"]);
							list4.Add(unchecked((int)num7));
						}
						DataRow[] array7 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
						for (int n = 0; n < array7.Length; n++)
						{
							long num8 = Conversions.ToLong(array7[n]["ComponentID"]);
							DataRow? dataRow2 = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num8);
							long num9 = Conversions.ToLong(dataRow2["Type"]);
							if (Conversions.ToBoolean(dataRow2["WeaponLinkRequiresSensor"]) && num9 > 9001L)
							{
								flag2 = true;
								DataRow[] array8 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num8));
								for (int num10 = 0; num10 < array8.Length; num10++)
								{
									long num11 = Conversions.ToLong(array8[num10]["ComponentID"]);
									list3.Add(unchecked((int)num11));
								}
							}
						}
						bool flag3 = false;
						foreach (int item in list)
						{
							foreach (int item2 in list2)
							{
								if (item == item2)
								{
									flag3 = true;
									break;
								}
							}
							foreach (int item3 in list4)
							{
								if (item == item3)
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
						foreach (int item4 in list3)
						{
							foreach (int item5 in list2)
							{
								if (item4 == item5)
								{
									flag3 = true;
									break;
								}
							}
							foreach (int item6 in list4)
							{
								if (item4 == item6)
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
						if (flag2 && !flag3)
						{
							string text = "Weapon datalink on mount " + Conversions.ToString(num6) + " requires a director (sensor) in order to send target updates to weapon.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					bool flag4 = false;
					foreach (int item7 in list)
					{
						foreach (int item8 in list2)
						{
							if (item7 == item8)
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Validation 200051", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	static DataValidateFacility()
	{
		Class72.smethod_20();
	}
}
