using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateShip
{
	public static void ValidateShipStatsAndFlags()
	{
		DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
		try
		{
			int num21 = default(int);
			int num22 = default(int);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = 0L;
				long num2 = 0L;
				bool flag = false;
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipStatsAndFlags - Ship #" + Conversions.ToString(num3);
				int num4 = Conversions.ToInteger((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODADetectionCycle" }, (string[])null)))) ? NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODADetectionCycle" }, (string[])null) : ((object)0));
				num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODATargetingCycle" }, (string[])null));
				num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODAEvasiveCycle" }, (string[])null));
				long num5 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Category" }, (string[])null));
				long num6 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				int num10 = 0;
				DataRow[] array = Common.get_DataShipPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				DataRow? dataRow = Common.get_MiscShip(Common.mySourceDB_Helper).Rows.Find(num3);
				int num11 = Conversions.ToInteger(dataRow["DefaultCruiseSpeed"]);
				int num12 = Conversions.ToInteger(dataRow["DefaultCruiseRange"]);
				int num13 = Conversions.ToInteger(dataRow["DefaultFullSpeed"]);
				Conversions.ToInteger(dataRow["DefaultFullRange"]);
				int num14 = Conversions.ToInteger(dataRow["DefaultFlankSpeed"]);
				Conversions.ToInteger(dataRow["DefaultFlankRange"]);
				int num15 = Conversions.ToInteger(dataRow["PrimaryFuelQty"]);
				Conversions.ToInteger(dataRow["SecondaryFuelQty"]);
				DB_Enums.ModifierShipPassiveSonar modifierShipPassiveSonar = (DB_Enums.ModifierShipPassiveSonar)Conversions.ToInteger(dataRow["ModifierPassiveSonar"]);
				Conversions.ToLong(dataRow["ModifierActiveSonar"]);
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					int num16 = Conversions.ToInteger(array2[i]["ComponentID"]);
					DataRow dataRow2 = Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num16);
					if (dataRow2 != null)
					{
						int num17 = Conversions.ToInteger(dataRow2["Type"]);
						if (num17 == 3001)
						{
							flag2 = true;
						}
						if (num17 == 3004)
						{
							flag3 = true;
						}
						if (num17 == 3002)
						{
							flag4 = true;
						}
						int num18;
						if (num17 == 3003)
						{
							flag5 = true;
							num18 = 0;
						}
						else
						{
							num18 = 0;
						}
						long num19 = num18;
						DataRow[] array3 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
						foreach (DataRow obj in array3)
						{
							num19 = Conversions.ToLong(obj["Speed"]);
							long num20 = Conversions.ToLong(obj["Throttle"]);
							if (num20 == 2L)
							{
								num10 = (int)num19;
							}
							if (num20 == 3L)
							{
								num21 = (int)num19;
							}
							if (num20 == 4L)
							{
								num22 = (int)num19;
							}
						}
						continue;
					}
					throw new Exception("The ship #" + Conversions.ToString(num3) + " claims to have an engine #" + Conversions.ToString(num16) + ", but no such engine appears to be in the Propulsion annex.");
				}
				DataRow[] array4 = Common.get_DataShipFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int k = 0; k < array4.Length; k = checked(k + 1))
				{
					long num23 = Conversions.ToLong(array4[k]["ComponentID"]);
					DataRow dataRow3 = Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num23);
					long num24 = Conversions.ToLong(dataRow3["Type"]);
					long num25 = Conversions.ToLong(dataRow3["Capacity"]);
					if (num24 == 3001L)
					{
						num7 = (int)num25;
					}
					if (num24 == 3002L)
					{
						num8 = (int)num25;
					}
					if (num24 == 3003L)
					{
						num9 = (int)num25;
					}
				}
				if (num10 != num11 && (flag2 || flag4 || flag5) && num11 != 0)
				{
					string text = "Ship specified Cruise Speed (kt) is different from the engine stats! " + Conversions.ToString(num10) + "kt vs " + Conversions.ToString(num11) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num21 != num13 && (flag2 || flag4 || flag5) && num13 != 0)
				{
					string text = "Ship specified Full Speed (kt) is different from the engine stats! " + Conversions.ToString(num21) + "kt vs " + Conversions.ToString(num13) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num26;
				if (num22 != num14 && (flag2 || flag4 || flag5) && num14 != 0)
				{
					string text = "Ship specified Flank Speed (kt) is different from the engine stats! " + Conversions.ToString(num22) + "kt vs " + Conversions.ToString(num14) + "kt";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num26 = 0;
				}
				else
				{
					num26 = 0;
				}
				long num27 = num26;
				if (num11 > 0)
				{
					num27 = (long)Math.Round((double)num12 / (double)num11 * 60.0);
				}
				if (num7 != num27 && flag2 && num11 != 0 && num15 == 0)
				{
					string text = "Diesel fuel qty should be " + Conversions.ToString(num27) + ".";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 != 0 && num7 != num15 && flag2)
				{
					string text = "Diesel fuel qty should be " + Conversions.ToString(num15) + ".";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 != num27 && flag4 && num11 != 0 && num15 == 0)
				{
					string text = "Oil fuel qty should be " + Conversions.ToString(num27) + ".";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 != 0 && num8 != num15 && flag4)
				{
					string text = "Oil fuel qty should be " + Conversions.ToString(num15) + ".";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 != num27 && flag5 && num11 != 0 && num15 == 0)
				{
					string text = "Gas fuel qty should be " + Conversions.ToString(num27) + ".";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 != 0 && num9 != num15 && flag5)
				{
					string text = "Gas fuel qty should be " + Conversions.ToString(num15) + ".";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 <= 0 && (flag2 || flag4 || flag5))
				{
					string text = "Propulsion Default Cruise Speed must be entered for non-nuclear powered ships!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag3 && (num7 != 0 || num8 != 0 || num9 != 0))
				{
					string text = "Ship is nuclear powered but carries conventional fuel. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 <= 0 && (flag2 || flag4 || flag5))
				{
					string text = "Diesel Propulsion Default Cruise Range must be entered!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 != 0 && flag3)
				{
					string text = "Default Cruise Speed must be 0 for nuclear-powered Ships!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 != 0 && flag3)
				{
					string text = "Disel Propulsion Default Cruise Range must be 0 for nuclear-powered Ships!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				DataRow[] array5 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int l = 0; l < array5.Length; l = checked(l + 1))
				{
					long num28 = Conversions.ToLong(array5[l]["ComponentID"]);
					DataRow[] array6 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num28));
					for (int m = 0; m < array6.Length; m = checked(m + 1))
					{
						long num29 = Conversions.ToLong(array6[m]["ComponentID"]);
						long num30 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num29)["ComponentID"]);
						long num31 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num30)["Type"]);
						if (num31 == 2001L || num31 == 2002L || num31 == 2003L || num31 == 2004L || num31 == 2009L || num31 == 4001L || num31 == 4002L || num31 == 4004L || num31 == 4005L || num31 == 4006L || num31 == 4007L || num31 == 6001L)
						{
							flag = true;
						}
					}
				}
				if (num4 == 0)
				{
					string text = "Unit but has an OODA Detection Cycle of 0 (or blank).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num == 0L && flag)
				{
					string text = "Unit carries weapons but has an OODA Targeting Cycle of 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num > 0L && !flag)
				{
					string text = "Unit has an OODA Targeting Cycle but carries no weapons.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num32;
				if (num2 == 0L)
				{
					string text = "Enter a valid OODA Evasive Cycle.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num32 = 0;
				}
				else
				{
					num32 = 0;
				}
				bool flag6 = (byte)num32 != 0;
				bool flag7 = false;
				bool flag8 = false;
				DataRow[] array7 = Common.get_DataShipAircraftFacilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int n = 0; n < array7.Length; n = checked(n + 1))
				{
					long num33 = Conversions.ToLong(array7[n]["ComponentID"]);
					long num34 = Conversions.ToLong(Common.get_DataAircraftFacility(Common.mySourceDB_Helper).Rows.Find(num33)["Type"]);
					int num35;
					if (!(num34 == 4001L || num34 == 4002L))
					{
						num35 = 1;
					}
					else
					{
						flag6 = true;
						num35 = 1;
					}
					flag7 = (byte)num35 != 0;
					if (num34 == 4003L)
					{
						flag8 = true;
					}
				}
				if (num5 == 2001L && !flag8)
				{
					string text = "Ship is carrier/aviation unit but has no transit facilities (elevators)!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num42;
				if ((num5 == 2001L || num5 == 2002L || num5 == 2003L) && flag6)
				{
					bool flag9 = false;
					DataRow[] array8 = Common.get_DataShipMagazines(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					checked
					{
						for (int num36 = 0; num36 < array8.Length; num36++)
						{
							long num37 = Conversions.ToLong(array8[num36]["ComponentID"]);
							if (Conversions.ToBoolean(Common.get_DataMagazine(Common.mySourceDB_Helper).Rows.Find(num37)["AviationMagazine"]))
							{
								flag9 = true;
							}
							DataRow[] array9 = Common.get_DataMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num37));
							for (int num38 = 0; num38 < array9.Length; num38++)
							{
								long num39 = Conversions.ToLong(array9[num38]["ComponentID"]);
								long num40 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num39)["ComponentID"]);
								if (Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num40)["Type"]) == 4001L)
								{
									DataRow[] array10 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num40));
									for (int num41 = 0; num41 < array10.Length; num41++)
									{
										Conversions.ToLong(array10[num41]["CodeID"]);
									}
								}
							}
						}
						if (!flag9)
						{
							string text = "Ship is a warship with aviation facilities but no dedicated aviation magazine (Helicopter/Carrier Magazine).";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag9 && !flag6)
					{
						string text = "Ship has Aviation Magazine but no Aircraft Facilities!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num42 = 0;
						goto IL_146c;
					}
				}
				num42 = 0;
				goto IL_146c;
				IL_146c:
				bool flag10 = (byte)num42 != 0;
				bool flag11 = false;
				bool flag12 = false;
				bool flag13 = false;
				bool flag14 = false;
				bool flag15 = false;
				bool flag16 = false;
				double num43 = 0.0;
				DataRow[] array11 = Common.get_DataShipCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				for (int num44 = 0; num44 < array11.Length; num44 = checked(num44 + 1))
				{
					double num45 = Conversions.ToDouble(array11[num44]["CodeID"]);
					if (num45 == 1002.0 || num45 == 1011.0)
					{
						continue;
					}
					if (num45 == 2001.0)
					{
						flag16 = true;
					}
					else
					{
						if (num45 == 3001.0 || num45 == 3002.0 || num45 == 4001.0 || num45 == 4002.0 || num45 == 4003.0)
						{
							continue;
						}
						if (num45 == 4007.0)
						{
							flag10 = true;
						}
						else if (num45 == 4006.0)
						{
							flag11 = true;
						}
						else if (num45 != 4011.0 && num45 != 4012.0 && num45 != 4020.0 && num45 != 4022.0)
						{
							if (num45 == 6001.0)
							{
								num43 += 1.0;
								flag12 = true;
							}
							else if (num45 == 6002.0)
							{
								num43 += 1.0;
								flag13 = true;
							}
							else if (num45 == 6003.0)
							{
								num43 += 1.0;
								flag14 = true;
							}
							else if (num45 == 6004.0)
							{
								num43 += 1.0;
								flag15 = true;
							}
						}
					}
				}
				if (!flag7 && flag16)
				{
					string text = "Ship has Helo In-Flight Refuel Capable flag but has no Aircraft Facilities!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag15 && !flag10)
				{
					string text = "Ship is minesweeper with Glass Reinforced Polyester (GRP) hull but lacks Glass Reinforced Polyester (GRP) Construction flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag14 && !flag11)
				{
					string text = "Ship is minesweeper with wooden hull but lacks Wooden Hull Construction flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num6 == 6001L || num6 == 6002L || num6 == 6003L || num6 == 6004L) && !flag12 && !flag13 && !flag14 && !flag15)
				{
					string text = "Ship is minesweeper and needs an influence mine countermeasure flag set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 9000L && num43 > 0.0)
				{
					string text = "Ship is civilian and cannot have a influence mine countermeasure flag set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num46;
				if (num43 > 1.0)
				{
					string text = "Ship has more than one influence mine countermeasure flag set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num46 = 0;
				}
				else
				{
					num46 = 0;
				}
				bool flag17 = (byte)num46 != 0;
				switch (modifierShipPassiveSonar)
				{
				case DB_Enums.ModifierShipPassiveSonar.Mod_1501_to_5000T_Steam_Turbines_PM_FF:
					flag17 = true;
					break;
				case DB_Enums.ModifierShipPassiveSonar.Mod_1501_to_5000T_Diesel_PM_FF:
					flag17 = true;
					break;
				case DB_Enums.ModifierShipPassiveSonar.Mod_1501_to_5000T_Gas_Turbines_PM_FF:
					flag17 = true;
					break;
				case DB_Enums.ModifierShipPassiveSonar.Mod_5001_to_10000T_Diesel_PM_DD:
					flag17 = true;
					break;
				case DB_Enums.ModifierShipPassiveSonar.Mod_5001_to_10000T_Gas_Turbines_PM_DD:
					flag17 = true;
					break;
				case DB_Enums.ModifierShipPassiveSonar.Mod_10001_to_25000T_Diesel_PM_CG:
					flag17 = true;
					break;
				case DB_Enums.ModifierShipPassiveSonar.Mod_10001_to_25000T_Gas_Turbines_PM_CG:
					flag17 = true;
					break;
				}
				if (flag17)
				{
					string text = "Warning: Ship has deprecated Prairie Masker sonar modifier. Remove modifier and add Prairie Masker flag to match DB conventions.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200088", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipsHaveOnlyOnePropulsionAndFuelRecord()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipsHaveOnlyOnePropulsionAndFuelRecord - Ship #" + Conversions.ToString(num);
				if (Common.get_DataShipPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 1)
				{
					string text = "The unit has more than one propulsion system! Only one propulsion system is allowed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200089", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipMagazineWeaponsExistsOnMounts()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			bool flag = default(bool);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipMagazineWeaponsExistsOnMounts - Ship #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				string string_ = "SELECT DISTINCT DataShipMagazines.ComponentID FROM DataShipMagazines WHERE DataShipMagazines.ID = " + Conversions.ToString(num) + " AND DataShipMagazines.ComponentID IN (SELECT DataMagazine.ID FROM DataMagazine WHERE DataMagazine.AviationMagazine = 0)";
				DataTable dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				foreach (object row2 in dataTable2.Rows)
				{
					long num6 = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row2), new object[1] { "ComponentID" }, (string[])null));
					DataRow[] array5 = Common.get_DataMagazineWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
					for (int k = 0; k < array5.Length; k = checked(k + 1))
					{
						long num4 = Conversions.ToLong(array5[k]["ComponentID"]);
						long num5 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num4)["ComponentID"]);
						if (array2.Count() > 0)
						{
							long num7 = num2 - 1L;
							for (long num8 = 0L; num8 <= num7; num8++)
							{
								if (num5 == array2[(int)num8])
								{
									flag = true;
									break;
								}
							}
						}
						int num9;
						if (!flag)
						{
							string text = "Weapon " + Conversions.ToString(num5) + " in Magazine " + Conversions.ToString(num6) + " does exist on any mounts.";
							string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200090", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipsHaveIlluminatorsForWeapons()
	{
		checked
		{
			try
			{
				DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
				bool flag = default(bool);
				bool flag2 = default(bool);
				foreach (object row in dataTable.Rows)
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
					Common.StatusString = "ValidateShipsHaveIlluminatorsForWeapons - Ship #" + Conversions.ToString(num);
					DataRow[] array = Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					HashSet<int> hashSet = new HashSet<int>();
					DataRow[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						long num2 = Conversions.ToLong(array2[i]["ComponentID"]);
						hashSet.Add(unchecked((int)num2));
					}
					DataRow[] array3 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					DataRow[] array4 = array3;
					for (int j = 0; j < array4.Length; j++)
					{
						long num3 = Conversions.ToLong(array4[j]["ComponentID"]);
						DataRow[] array5 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int k = 0; k < array5.Length; k++)
						{
							long num4 = Conversions.ToLong(array5[k]["ComponentID"]);
							hashSet.Add(unchecked((int)num4));
						}
					}
					List<int> list = hashSet.ToList();
					foreach (int item in list)
					{
						if (Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(item)["Type"]) == 9001L)
						{
							DataRow[] array6 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(item));
							for (int l = 0; l < array6.Length; l++)
							{
								long num5 = Conversions.ToLong(array6[l]["ComponentID"]);
								hashSet.Add(unchecked((int)num5));
							}
						}
					}
					DataRow[] array7 = array3;
					for (int m = 0; m < array7.Length; m++)
					{
						long num3 = Conversions.ToLong(array7[m]["ComponentID"]);
						DataRow[] array8 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int n = 0; n < array8.Length; n++)
						{
							long num6 = Conversions.ToLong(array8[n]["ComponentID"]);
							long num7 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num6)["ComponentID"]);
							DataRow[] array9 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num7));
							for (int num8 = 0; num8 < array9.Length; num8++)
							{
								long num9 = Conversions.ToLong(array9[num8]["ComponentID"]);
								flag = true;
								if (hashSet.Contains(unchecked((int)num9)))
								{
									flag2 = true;
								}
							}
							unchecked
							{
								int num10;
								if (!flag2 && flag)
								{
									string text = "Weapon " + Conversions.ToString(num7) + " in Mount " + Conversions.ToString(num3) + " has no illuminator / director.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									num10 = 0;
								}
								else
								{
									num10 = 0;
								}
								flag2 = (byte)num10 != 0;
								flag = false;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Validation 200092", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static void ValidateShipsHaveDirectorsForMounts()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipsHaveDirectorsForMounts - Ship #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				HashSet<int> hashSet = new HashSet<int>();
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num2 = Conversions.ToLong(array2[i]["ComponentID"]);
					hashSet.Add((int)num2);
				}
				DataRow[] array3 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				DataRow[] array4 = array3;
				for (int j = 0; j < array4.Length; j = checked(j + 1))
				{
					long num3 = Conversions.ToLong(array4[j]["ComponentID"]);
					DataRow[] array5 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					for (int k = 0; k < array5.Length; k = checked(k + 1))
					{
						long num4 = Conversions.ToLong(array5[k]["ComponentID"]);
						hashSet.Add((int)num4);
					}
				}
				List<int> list = hashSet.ToList();
				foreach (int item in list)
				{
					if (Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(item)["Type"]) == 9001L)
					{
						DataRow[] array6 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(item));
						for (int l = 0; l < array6.Length; l = checked(l + 1))
						{
							long num5 = Conversions.ToLong(array6[l]["ComponentID"]);
							hashSet.Add((int)num5);
						}
					}
				}
				DataRow[] array7 = array3;
				for (int m = 0; m < array7.Length; m = checked(m + 1))
				{
					long num3 = Conversions.ToLong(array7[m]["ComponentID"]);
					bool flag = false;
					flag = Conversions.ToBoolean(Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num3)["LocalControl"]);
					DataRow[] array8 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					bool flag2 = false;
					bool flag3 = false;
					DataRow[] array9 = array8;
					for (int n = 0; n < array9.Length; n = checked(n + 1))
					{
						long num6 = Conversions.ToLong(array9[n]["ComponentID"]);
						flag2 = true;
						if (hashSet.Contains((int)num6))
						{
							flag3 = true;
						}
					}
					int num7;
					if (!(!flag3 && flag2 && !flag))
					{
						num7 = 0;
					}
					else
					{
						string text = "Mount " + Conversions.ToString(num3) + " has no director!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
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
			ex2.Data.Add("Error at Validation 200093", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipsDirectorsAndIlluminatorsHaveCorrespondingWeapons()
	{
		checked
		{
			try
			{
				DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
				long num11 = default(long);
				foreach (object row in dataTable.Rows)
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
					Common.StatusString = "ValidateShipsDirectorsAndIlluminatorsHaveCorrespondingWeapons - Ship #" + Conversions.ToString(num);
					bool flag = false;
					long[] array = new long[0];
					long num2 = 0L;
					DataRow[] array2 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int i = 0; i < array2.Length; i++)
					{
						long num3 = Conversions.ToLong(array2[i]["ComponentID"]);
						DataRow[] array3 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int j = 0; j < array3.Length; j++)
						{
							int num4 = Conversions.ToInteger(array3[j]["ComponentID"]);
							long num5 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num4)["ComponentID"]);
							if (Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num5)["Type"]) == 2004L)
							{
								flag = true;
							}
							DataRow[] array4 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num5));
							for (int k = 0; k < array4.Length; k++)
							{
								long num6 = Conversions.ToLong(array4[k]["ComponentID"]);
								bool flag2 = false;
								unchecked
								{
									if (array.Count() > 0)
									{
										long num7 = num2 - 1L;
										for (long num8 = 0L; num8 <= num7; num8++)
										{
											if (array[(int)num8] == num6)
											{
												flag2 = true;
											}
										}
									}
									if (!flag2)
									{
										num2++;
										array = (long[])Utils.CopyArray((Array)array, (Array)new long[(int)(num2 - 1L) + 1]);
										array[(int)(num2 - 1L)] = num6;
									}
								}
							}
						}
						DataRow[] array5 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int l = 0; l < array5.Length; l++)
						{
							long num9 = Conversions.ToLong(array5[l]["ComponentID"]);
							bool flag3 = false;
							unchecked
							{
								if (num2 > 0L)
								{
									long num10 = 0 - ((num11 == num2) ? 1 : 0);
									for (num11 = 0L; num11 <= num10; num11++)
									{
										if (array[(int)num11] == num9)
										{
											flag3 = true;
										}
									}
								}
								if (!flag3)
								{
									num2++;
									array = (long[])Utils.CopyArray((Array)array, (Array)new long[(int)(num2 - 1L) + 1]);
									array[(int)(num2 - 1L)] = num9;
								}
							}
						}
					}
					DataRow[] array6 = Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int m = 0; m < array6.Length; m++)
					{
						double num12 = Conversions.ToDouble(array6[m]["ComponentID"]);
						DataRow? dataRow = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num12);
						double num13 = Conversions.ToDouble(dataRow["Type"]);
						double num14 = Conversions.ToDouble(dataRow["Role"]);
						unchecked
						{
							bool flag4;
							if (num13 == 9001.0)
							{
								DataRow[] array7 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num12));
								for (int n = 0; n < array7.Length; n = checked(n + 1))
								{
									long num15 = Conversions.ToLong(array7[n]["ComponentID"]);
									DataRow? dataRow2 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num15);
									Conversions.ToDouble(dataRow2["Type"]);
									double num16 = Conversions.ToDouble(dataRow2["Role"]);
									flag4 = false;
									if (!(num16 == 2191.0 || (num16 >= 2200.0 && num16 <= 2207.0) || num16 == 2041.0 || num16 == 2681.0 || num16 == 2682.0 || num16 == 2683.0 || num16 == 2684.0 || num16 == 2781.0 || num16 == 2782.0 || num16 == 2783.0 || num16 == 2784.0 || num16 == 2881.0 || num16 == 2882.0 || num16 == 2883.0 || num16 == 2884.0 || num16 == 2885.0 || num16 == 2886.0 || num16 == 2887.0 || num16 == 2888.0 || num16 == 6081.0 || num16 == 6082.0))
									{
										continue;
									}
									if (array.Count() > 0)
									{
										long num17 = num2 - 1L;
										for (long num18 = 0L; num18 <= num17; num18++)
										{
											if (num15 == array[(int)num18])
											{
												flag4 = true;
												break;
											}
										}
									}
									if ((!flag4 && flag) || (!flag4 && !flag && num16 != 2682.0 && num16 != 2782.0 && num16 != 2882.0 && num16 != 6082.0))
									{
										string text = "Sensor " + Conversions.ToString(num15) + " in Sensor Group " + Conversions.ToString(num12) + " is a weapon director but is not required by any weapons or mounts!";
										string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
										Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									}
								}
								continue;
							}
							flag4 = false;
							if (!(num14 == 2191.0 || (num14 >= 2200.0 && num14 <= 2207.0) || num14 == 2041.0 || num14 == 2681.0 || num14 == 2682.0 || num14 == 2781.0 || num14 == 2782.0 || num14 == 2881.0 || num14 == 2882.0 || num14 == 6081.0 || num14 == 6082.0))
							{
								continue;
							}
							if (array.Count() > 0)
							{
								long num19 = num2 - 1L;
								for (long num20 = 0L; num20 <= num19; num20++)
								{
									if (num12 == (double)array[(int)num20])
									{
										flag4 = true;
										break;
									}
								}
							}
							if ((!flag4 && flag) || (!flag4 && !flag && num14 != 2682.0 && num14 != 2782.0 && num14 != 2882.0 && num14 != 6082.0))
							{
								string text = "Sensor " + Conversions.ToString(num12) + " is a weapon director but is not required by any weapons or mounts!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
					DataRow[] array8 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int num21 = 0; num21 < array8.Length; num21++)
					{
						long num22 = Conversions.ToLong(array8[num21]["ComponentID"]);
						DataRow[] array9 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num22));
						for (int num23 = 0; num23 < array9.Length; num23++)
						{
							long num24 = Conversions.ToLong(array9[num23]["ComponentID"]);
							DataRow? dataRow3 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num24);
							Conversions.ToDouble(dataRow3["Type"]);
							double num25 = Conversions.ToDouble(dataRow3["Role"]);
							bool flag4 = false;
							unchecked
							{
								if (!(num25 == 2191.0 || (num25 >= 2200.0 && num25 <= 2207.0) || num25 == 2041.0 || num25 == 2681.0 || num25 == 2682.0 || num25 == 2781.0 || num25 == 2782.0 || num25 == 2881.0 || num25 == 2882.0 || num25 == 6081.0 || num25 == 6082.0))
								{
									continue;
								}
								if (array.Count() > 0)
								{
									long num26 = num2 - 1L;
									for (long num27 = 0L; num27 <= num26; num27++)
									{
										if (num24 == array[(int)num27])
										{
											flag4 = true;
											break;
										}
									}
								}
								if ((!flag4 && flag) || (!flag4 && !flag && num25 != 2682.0 && num25 != 2782.0 && num25 != 2882.0 && num25 != 6082.0))
								{
									string text = "Sensor " + Conversions.ToString(num24) + " on Mount " + Conversions.ToString(num22) + " is a weapon director but is not required by any weapons or mounts!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ErrorManagement.EnqueueErrorMessage(ex2);
				ex2.Data.Add("Error at Validation 200094", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static void ValidateShipNames()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipNames - Ship #" + Conversions.ToString(num);
				DataRow? dataRow = Common.get_DataShip(Common.mySourceDB_Helper).Rows.Find(num);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				if (Strings.InStr(num16, text2, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the name, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 > 0 && num12 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 > 0 && num15 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num17;
				if (num15 > 0 && num14 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				else
				{
					num17 = 1;
				}
				int num18;
				if (Strings.InStr(num17, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should not be any.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				else
				{
					num18 = 1;
				}
				int num19;
				if ((Strings.InStr(num18, text2, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "mk1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				else
				{
					num19 = 1;
				}
				int num20;
				if (!((Strings.InStr(num19, text2, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) > 0)))
				{
					num20 = 1;
				}
				else
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if (Strings.InStr(num20, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				else
				{
					num21 = 1;
				}
				int num22;
				if (Strings.InStr(num21, text2, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num22 = 1;
				}
				else
				{
					num22 = 1;
				}
				int num23;
				if (Strings.InStr(num22, text, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num23 = 1;
				}
				else
				{
					num23 = 1;
				}
				if (Strings.InStr(num23, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 > num3 && num3 != 0.0)
				{
					string text3 = "Unit decomissioned before it commissioned? Unlikely. Check years!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200095", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipsPropulsion()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipsPropulsion - Ship #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataShipPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					long num2 = Conversions.ToLong(array[i]["ComponentID"]);
					DataRow[] array2 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
					foreach (DataRow obj in array2)
					{
						long num3 = Conversions.ToLong(obj["AltitudeMax"]);
						long num4 = Conversions.ToLong(obj["AltitudeMin"]);
						long num5 = Conversions.ToLong(obj["Speed"]);
						if (num3 != 0L)
						{
							string text = "Propulsion " + Conversions.ToString(num2) + " should have max altitude AltitudeBand of 0 meter.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num4 != 0L)
						{
							string text = "Propulsion " + Conversions.ToString(num2) + " should have minimum depth AltitudeBand of 0 meter.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num5 > 100L)
						{
							string text = "Propulsion " + Conversions.ToString(num2) + " has a max speed of 80 knots?!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200096", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipsHaveDatalinksForWeapons()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			bool flag = false;
			bool flag2 = false;
			long num10 = default(long);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipsHaveDatalinksForWeapons - Ship #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataShipComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long[] array2 = new long[0];
				long num2 = 0L;
				long[] array3 = new long[0];
				long num3 = 0L;
				DataRow[] array4 = array;
				for (int i = 0; i < array4.Length; i = checked(i + 1))
				{
					long num4 = Conversions.ToLong(array4[i]["ComponentID"]);
					long num5 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]);
					if (num5 > 7999L)
					{
						num2++;
						array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
						array2[(int)(num2 - 1L)] = num5;
					}
				}
				DataRow[] array5 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
								if (num8 > 7999L)
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
							DataRow[] array10 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num9));
							for (int n = 0; n < array10.Length; n++)
							{
								num10 = Conversions.ToLong(array10[n]["ComponentID"]);
								DataRow[] array11 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
								for (int num11 = 0; num11 < array11.Length; num11++)
								{
									long num12 = Conversions.ToLong(array11[num11]["ComponentID"]);
									long num13 = 0L;
									long num14 = 0L;
									DataRow? dataRow = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num12);
									num13 = Conversions.ToLong(dataRow["IsOptional"]);
									num14 = Conversions.ToLong(dataRow["Type"]);
									if (num13 == 0L)
									{
										flag = true;
									}
									unchecked
									{
										num3++;
										array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
										array3[(int)(num3 - 1L)] = num14;
										if (array2.Count() <= 0)
										{
											continue;
										}
										long num15 = num2 - 1L;
										for (long num16 = 0L; num16 <= num15; num16++)
										{
											if (num14 == array2[(int)num16])
											{
												flag2 = true;
											}
										}
									}
								}
							}
							unchecked
							{
								int num17;
								if (!(!flag2 && flag))
								{
									num17 = 0;
								}
								else
								{
									string text = "Weapon " + Conversions.ToString(num10) + " in Mount " + Conversions.ToString(num6) + " has no datalink.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
									num17 = 0;
								}
								flag2 = (byte)num17 != 0;
								flag = false;
							}
						}
					}
				}
				long num18 = num2 - 1L;
				for (long num19 = 0L; num19 <= num18; num19++)
				{
					bool flag3 = false;
					if (array2.Count() > 0 && array3.Count() > 0)
					{
						long num20 = num3 - 1L;
						for (long num21 = 0L; num21 <= num20; num21++)
						{
							if (array2[(int)num19] == array3[(int)num21])
							{
								flag3 = true;
							}
						}
					}
					if (!flag3)
					{
						string text2 = "<Error fetching name!>";
						string name = "SELECT Description FROM EnumCommType WHERE ID = " + Conversions.ToString(array2[(int)num19]);
						Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						Recordset recordset2 = recordset;
						while (!recordset2.EOF)
						{
							text2 = Conversions.ToString(recordset2.Fields["Description"].Value);
							recordset2.MoveNext();
						}
						recordset2 = null;
						recordset.Close();
						recordset = null;
						string text = "Weapon datalink " + text2 + " is not used by any weapons on the ship.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200097", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipHaveCorrectOperatorServiceAndYear()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = 0L;
				long num2 = 0L;
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipHaveCorrectOperatorServiceAndYear - Ship #" + Conversions.ToString(num3);
				num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "YearCommissioned" }, (string[])null));
				num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "YearDecommissioned" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OperatorCountry" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OperatorService" }, (string[])null));
				string string_ = "SELECT YearStart, YearEnd FROM EnumOperatorCountry WHERE ID = " + Conversions.ToString(num4);
				DataTable dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable(string_);
				long num6 = 0L;
				long num7 = 0L;
				if (dataTable2.Rows.Count > 0)
				{
					num6 = Conversions.ToLong(dataTable2.Rows[0]["YearStart"]);
					num7 = Conversions.ToLong(dataTable2.Rows[0]["YearEnd"]);
				}
				if (num < num6 && (ulong)num > 0uL)
				{
					string text = "Ship entered service before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 < num6 && (ulong)num2 > 0uL)
				{
					string text = "Ship decommissioned before the country was formed? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num2 > num7 && (ulong)num7 > 0uL)
				{
					string text = "Ship decommissioned after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num > num7 && (ulong)num7 > 0uL)
				{
					string text = "Ship entered service after the country disintegrated? Unlikely!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2100.0 && num5 != 2101.0 && num5 != 2102.0 && num5 != 2103.0 && num5 != 2104.0)
				{
					string text = "Operator is United Kingdom. Service should be a Royal-type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2079.0 && num5 != 2001.0 && num5 != 2002.0 && num5 != 2003.0 && num5 != 2005.0 && num5 != 2206.0 && num5 != 2207.0)
				{
					string text = "Operator is Russia. Service should be a vanilla type, not Red Star type!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
				if (num4 == 2088.0 && num5 != 2201.0 && num5 != 2202.0 && num5 != 2203.0 && num5 != 2204.0 && num5 != 2205.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 2208.0 && num5 != 2209.0 && num5 != 1003.0)
				{
					string text = "Operator is Soviet Union. Service should be one of the Cold War operators!";
					string string_2 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_2);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200098", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipSonarSignatureModifierMatchesPropulsionTypeAndTonnage()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			double num7 = default(double);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipSonarSignatureModifierMatchesPropulsionTypeAndTonnage - Ship #" + Conversions.ToString(num);
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "DisplacementStandard" }, (string[])null));
				DataRow? dataRow = Common.get_MiscShip(Common.mySourceDB_Helper).Rows.Find(num);
				double num4 = Conversions.ToDouble(dataRow["ModifierPassiveSonar"]);
				double num5 = Conversions.ToDouble(dataRow["ModifierActiveSonar"]);
				DataRow[] array = Common.get_DataShipPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					long num6 = Conversions.ToLong(array[i]["ComponentID"]);
					num7 = Conversions.ToDouble(Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num6)["Type"]);
				}
				if (num5 == 1001.0)
				{
					string text = "Active Sonar modifier is None which is not a legal option.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 != 4002L)
				{
					if (num5 == 2001.0 && (num3 < 0L || num3 > 500L))
					{
						string text = "Active Sonar Modifier says 0-500t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2002.0 && (num3 < 501L || num3 > 1500L))
					{
						string text = "Active Sonar Modifier says 501-1500t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2003.0 && (num3 < 1501L || num3 > 5000L))
					{
						string text = "Active Sonar Modifier says 1501-5000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2004.0 && (num3 < 5001L || num3 > 10000L))
					{
						string text = "Active Sonar Modifier says 5001-10000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2005.0 && (num3 < 10001L || num3 > 25000L))
					{
						string text = "Active Sonar Modifier says 10001-25000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2006.0 && (num3 < 25001L || num3 > 45000L))
					{
						string text = "Active Sonar Modifier says 25001-45000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2007.0 && (num3 < 45001L || num3 > 95000L))
					{
						string text = "Active Sonar Modifier says 45001-95000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 == 2008.0 && num3 < 95001L)
					{
						string text = "Active Sonar Modifier says 95001t+ Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 1001.0)
					{
						string text = "Passive Sonar modifier is None which is not a legal option.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 2001.0 || num4 == 2002.0) && (num3 < 0L || num3 > 500L))
					{
						string text = "Passive Sonar Modifier says 0-500t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 2001.0 || num4 == 2002.0) && num7 != 3001.0 && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 2003.0 || num4 == 2004.0 || num4 == 2005.0) && (num3 < 501L || num3 > 1500L))
					{
						string text = "Passive Sonar Modifier says 501-1500t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 2003.0 || num4 == 2005.0) && num7 != 3001.0 && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 2004.0 && num7 != 3002.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 >= 3001.0 && num4 <= 4000.0 && (num3 < 1501L || num3 > 5000L))
					{
						string text = "Passive Sonar Modifier says 1501-5000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 3001.0 || num4 == 3002.0) && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Gas Turbine propulsion, but ship does not have gas turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 3003.0 || num4 == 3004.0) && num7 != 3001.0 && num4 != 2001.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 3005.0 || num4 == 3006.0) && num7 != 3002.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 >= 4001.0 && num4 <= 5000.0 && (num3 < 5001L || num3 > 10000L))
					{
						string text = "Passive Sonar Modifier says 5001-10000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 4001.0 || num4 == 4002.0) && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Gas Turbine propulsion, but ship does not have gas turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 4003.0 || num4 == 4004.0) && num7 != 3001.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 4005.0 && num7 != 3002.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 4006.0 && num7 != 3004.0)
					{
						string text = "Passive Sonar Modifier says Nuclear propulsion, but ship does not have nuclear as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 >= 5001.0 && num4 <= 6000.0 && (num3 < 10001L || num3 > 25000L))
					{
						string text = "Passive Sonar Modifier says 10001-25000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 5001.0 || num4 == 5002.0) && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Gas Turbine propulsion, but ship does not have gas turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 == 5003.0 || num4 == 5004.0) && num7 != 3001.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 5005.0 && num7 != 3002.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 5006.0 && num7 != 3004.0)
					{
						string text = "Passive Sonar Modifier says Nuclear propulsion, but ship does not have nuclear as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 >= 6001.0 && num4 <= 7000.0 && (num3 < 25001L || num3 > 45000L))
					{
						string text = "Passive Sonar Modifier says 25001-45000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 6002.0 && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Gas Turbine propulsion, but ship does not have gas turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 6003.0 && num7 != 3001.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 6004.0 && num7 != 3002.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 >= 7001.0 && num4 <= 8000.0 && (num3 < 45001L || num3 > 95000L))
					{
						string text = "Passive Sonar Modifier says 45001-95000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 7002.0 && num7 != 3003.0)
					{
						string text = "Passive Sonar Modifier says Gas Turbines propulsion, but ship does not have gas turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 7003.0 && num7 != 3001.0)
					{
						string text = "Passive Sonar Modifier says Diesel propulsion, but ship does not have diesels as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 7004.0 && num7 != 3002.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 7005.0 && num7 != 3004.0)
					{
						string text = "Passive Sonar Modifier says Steam propulsion, but ship does not have steam turbines as main propulsion!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8001.0 && (num3 < 0L || num3 > 500L))
					{
						string text = "Passive Sonar Modifier says 0-500t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8002.0 && (num3 < 501L || num3 > 1500L))
					{
						string text = "Passive Sonar Modifier says 501-1500t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8003.0 && (num3 < 1501L || num3 > 5000L))
					{
						string text = "Passive Sonar Modifier says 1501-5000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8004.0 && (num3 < 5001L || num3 > 10000L))
					{
						string text = "Passive Sonar Modifier says 5001-10000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8005.0 && (num3 < 10001L || num3 > 25000L))
					{
						string text = "Passive Sonar Modifier says 10001-25000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8006.0 && (num3 < 25001L || num3 > 45000L))
					{
						string text = "Passive Sonar Modifier says 25001-45000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8007.0 && (num3 < 45001L || num3 > 95000L))
					{
						string text = "Passive Sonar Modifier says 45001-95000t Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 == 8008.0 && num3 < 95001L)
					{
						string text = "Passive Sonar Modifier says 95001t+ Displacement, but ship std displacement is " + Conversions.ToString(num3) + "t!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else
				{
					if (num4 != 8901.0)
					{
						string text = "Ship is Air Cushion Landing Craft, please select relevant Passive Sonar Modifier.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 != 8901.0)
					{
						string text = "Ship is Air Cushion Landing Craft, please select relevant Active Sonar Modifier.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200099", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipAircraftFacilities()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipAircraftFacilities - Ship #" + Conversions.ToString(num);
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Category" }, (string[])null));
				long num3 = 9999L;
				long num4 = 0L;
				long num5 = 9999L;
				long num6 = 0L;
				long num7 = 9999L;
				long num8 = 0L;
				long num9 = 9999L;
				long num10 = 0L;
				long num11 = 9999L;
				long num12 = 0L;
				long num13 = 9999L;
				long num14 = 0L;
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				bool flag8 = false;
				DataRow[] array = Common.get_DataShipAircraftFacilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					double num15 = Conversions.ToDouble(array[i]["ComponentID"]);
					DataRow? dataRow = Common.get_DataAircraftFacility(Common.mySourceDB_Helper).Rows.Find(num15);
					double num16 = Conversions.ToDouble(dataRow["Type"]);
					double num17 = Conversions.ToDouble(dataRow["PhysicalSize"]);
					double num18 = Conversions.ToDouble(dataRow["Capacity"]);
					Conversions.ToDouble(dataRow["RunwayLength"]);
					if (num16 == 3001.0 || num16 == 3002.0)
					{
						flag = true;
						if ((double)num3 > num17)
						{
							num3 = (long)Math.Round(num17);
						}
						if ((double)num4 < num17)
						{
							num4 = (long)Math.Round(num17);
						}
					}
					if (num16 == 4002.0)
					{
						flag2 = true;
						if ((double)num5 > num17)
						{
							num5 = (long)Math.Round(num17);
						}
						if ((double)num6 < num17)
						{
							num6 = (long)Math.Round(num17);
						}
					}
					if (num16 == 4001.0)
					{
						flag3 = true;
						if ((double)num7 > num17)
						{
							num7 = (long)Math.Round(num17);
						}
						if ((double)num8 < num17)
						{
							num8 = (long)Math.Round(num17);
						}
						if ((double)num9 > num18)
						{
							num9 = (long)Math.Round(num18);
						}
						if ((double)num10 < num18)
						{
							num10 = (long)Math.Round(num18);
						}
					}
					if (num16 == 4003.0)
					{
						flag4 = true;
						if ((double)num11 > num17)
						{
							num11 = (long)Math.Round(num17);
						}
						if ((double)num12 < num17)
						{
							num12 = (long)Math.Round(num17);
						}
					}
					if (num16 == 2002.0 || num16 == 2003.0 || num16 == 2004.0)
					{
						string text = "Aircraft Facility " + Conversions.ToString(num15) + " is a land type, and should not be used on ships!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num16 == 2001.0 || num16 == 2005.0 || num16 == 2006.0 || num16 == 2007.0)
					{
						flag5 = true;
						if ((double)num13 > num17)
						{
							num13 = (long)Math.Round(num17);
						}
						if ((double)num14 < num17)
						{
							num14 = (long)Math.Round(num17);
						}
					}
					if (num16 == 2005.0)
					{
						flag6 = true;
					}
					if (num16 == 2007.0)
					{
						flag7 = true;
					}
					if (num16 == 2006.0)
					{
						flag8 = true;
					}
				}
				if (flag && !flag2 && !flag3)
				{
					string text = "Ship has helo pad but no parking space (Open Parking or Hangar).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag4 && !flag3)
				{
					string text = "Ship has transit facility (Elevator) but no Hangar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && !flag2 && !flag3)
				{
					string text = "Ship has catapult but no parking space (Open Parking or Hangar).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag7 && !flag2 && !flag3)
				{
					string text = "Ship has arrester gear but no parking space (Open Parking or Hangar).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag8 && !flag2 && !flag3)
				{
					string text = "Ship has ski jump but no parking space (Open Parking or Hangar).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 5L && !flag4)
				{
					string text = "Ship has large hangar (qty > 5) but no transit facility (Elevator).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag4 && !flag3)
				{
					string text = "Unit has an elevator but no hangar. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!(flag6 || (flag8 && flag7)))
				{
					if (flag8 && !flag7)
					{
						if (num12 > num14 && num12 > num4 && flag4)
						{
							string text = "Elevator on jump jet carrier is larger than the runway facilities.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					else if (num12 > num4 && flag4)
					{
						string text = "Elevator on helicopter carrier is larger than the helicopter pads.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else if (num12 > num14 && flag4)
				{
					string text = "Elevator on aircraft carrier is larger than the runway facilities.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 != num14 && flag5)
				{
					string text = "Catapults and Arrester Gear must be of same aircraft size!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 != num8 && flag3)
				{
					string text = "All hangars on a ship should be of the same aircraft size!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 != num12 && flag4)
				{
					string text = "All elevators on a ship should be of the same size!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 != num11 && flag3 && flag4)
				{
					string text = "Hangars and elevators must be of same aircraft size!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && !flag7)
				{
					string text = "Aircraft carrier with catapults must also have arrester gear!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag6 && !flag8 && flag7)
				{
					string text = "Aircraft carrier with arrester gear must also have catapults or ski jump!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag8 && !flag && !flag7)
				{
					string text = "Aircraft carrier with ski jump but no pad!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > num4 && flag3 && flag)
				{
					string text = "Hangars may not be larger than the helicopter pads!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag3 || flag2) && !flag && !flag5)
				{
					string text = "Ship has parking facilities for aircraft but no take-off facilities!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag4 && num2 == 2001L && num2 != 2007L && num2 != 2008L)
				{
					string text = "Ship is carrier (aviation ship) but has no transit facilities (elevators)!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag4 && num2 != 2001L && num2 != 2007L && num2 != 2008L)
				{
					string text = "Ship has transit facilities (elevators) but is not an aviation ship!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200100", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipHaveDatalinkDirectors()
	{
		try
		{
			DataTable dataTable = Common.get_DataShip(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				Common.StatusString = "ValidateShipHaveDatalinkDirectors - Ship #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataShipComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				bool flag4;
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
							DataRow[] array7 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(num6));
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
					DataRow[] array8 = Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int k = 0; k < array8.Length; k++)
					{
						long num9 = Conversions.ToLong(array8[k]["ComponentID"]);
						DataRow[] array9 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num9));
						unchecked
						{
							if (array9.Length > 0)
							{
								DataRow[] array10 = array9;
								for (int l = 0; l < array10.Length; l = checked(l + 1))
								{
									double a = Conversions.ToDouble(array10[l]["ComponentID"]);
									num3++;
									array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
									array3[(int)(num3 - 1L)] = (long)Math.Round(a);
								}
							}
							else
							{
								num3++;
								array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
								array3[(int)(num3 - 1L)] = num9;
							}
						}
					}
					DataRow[] array11 = Common.get_DataShipMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int m = 0; m < array11.Length; m++)
					{
						long num10 = Conversions.ToLong(array11[m]["ComponentID"]);
						DataRow[] array12 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
						for (int n = 0; n < array12.Length; n++)
						{
							long num11 = Conversions.ToLong(array12[n]["ComponentID"]);
							unchecked
							{
								num5++;
								array5 = (long[])Utils.CopyArray((Array)array5, (Array)new long[(int)(num5 - 1L) + 1]);
								array5[(int)(num5 - 1L)] = num11;
							}
						}
						DataRow[] array13 = Common.get_DataMountComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
						for (int num12 = 0; num12 < array13.Length; num12++)
						{
							long num13 = Conversions.ToLong(array13[num12]["ComponentID"]);
							DataRow? dataRow2 = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num13);
							long num14 = Conversions.ToLong(dataRow2["Type"]);
							if (Conversions.ToLong(dataRow2["WeaponLinkRequiresSensor"]) == -1L && num14 > 9001L)
							{
								flag2 = true;
								DataRow[] array14 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num13));
								for (int num15 = 0; num15 < array14.Length; num15++)
								{
									long num16 = Conversions.ToLong(array14[num15]["ComponentID"]);
									unchecked
									{
										num4++;
										array4 = (long[])Utils.CopyArray((Array)array4, (Array)new long[(int)(num4 - 1L) + 1]);
										array4[(int)(num4 - 1L)] = num16;
									}
								}
							}
						}
						bool flag3 = false;
						unchecked
						{
							if (num2 > 0L)
							{
								long num17 = num2 - 1L;
								for (long num18 = 0L; num18 <= num17; num18++)
								{
									if (num3 > 0L)
									{
										long num19 = num3 - 1L;
										for (long num20 = 0L; num20 <= num19; num20++)
										{
											if (array2[(int)num18] == array3[(int)num20])
											{
												flag3 = true;
												break;
											}
										}
									}
									if (num5 > 0L)
									{
										long num21 = num5 - 1L;
										for (long num22 = 0L; num22 <= num21; num22++)
										{
											if (array2[(int)num18] == array5[(int)num22])
											{
												flag3 = true;
												break;
											}
										}
									}
									if (flag3)
									{
										break;
									}
								}
							}
							if (num4 > 0L)
							{
								long num23 = num4 - 1L;
								for (long num24 = 0L; num24 <= num23; num24++)
								{
									if (num3 > 0L)
									{
										long num25 = num3 - 1L;
										for (long num26 = 0L; num26 <= num25; num26++)
										{
											if (array4[(int)num24] == array3[(int)num26])
											{
												flag3 = true;
												break;
											}
										}
									}
									if (num5 > 0L)
									{
										long num27 = num5 - 1L;
										for (long num28 = 0L; num28 <= num27; num28++)
										{
											if (array4[(int)num24] == array5[(int)num28])
											{
												flag3 = true;
												break;
											}
										}
									}
									if (flag3)
									{
										break;
									}
								}
							}
							if (flag2 && !flag3)
							{
								string text = "Weapon datalink on mount " + Conversions.ToString(num10) + " requires a director (sensor) in order to send target updates to weapon.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
					flag4 = false;
				}
				if (num2 > 0L)
				{
					long num29 = num2 - 1L;
					for (long num30 = 0L; num30 <= num29; num30++)
					{
						if (num3 > 0L)
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
						}
						if (flag4)
						{
							break;
						}
					}
				}
				if (flag && !flag4)
				{
					string text = "Weapon datalink requires a director (sensor) in order to send target updates to weapon.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200101", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateShip()
	{
		Class72.smethod_20();
	}
}
