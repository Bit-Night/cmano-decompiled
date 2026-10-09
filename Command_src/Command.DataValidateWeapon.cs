using System;
using System.Collections.Concurrent;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateWeapon
{
	public static ConcurrentDictionary<int, DataRow[]> Cache_CommsPerWeapon;

	public static ConcurrentDictionary<int, DataRow[]> Cache_WarheadsPerWeapon;

	public static ConcurrentDictionary<int, DataRow[]> Cache_CodesPerWeapon;

	public static ConcurrentDictionary<int, DataRow[]> Cache_TargetsPerWeapon;

	public static ConcurrentDictionary<int, DataRow[]> Cache_SensorsPerWeapon;

	public static void ValidateWeaponStats()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			bool flag = false;
			bool flag11 = default(bool);
			bool flag12 = default(bool);
			bool flag13 = default(bool);
			bool flag14 = default(bool);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Name" }, (string[])null));
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ClimbRate" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Length" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Span" }, (string[])null));
				double num6 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Diameter" }, (string[])null));
				double num7 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Weight" }, (string[])null));
				double num8 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CEP" }, (string[])null));
				double num9 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CEPSurface" }, (string[])null));
				double num10 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude" }, (string[])null));
				double num11 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude_ASL" }, (string[])null));
				double num12 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SurfaceRangeMax" }, (string[])null));
				Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SurfaceRangeMin" }, (string[])null));
				double num13 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LandRangeMax" }, (string[])null));
				Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LandRangeMin" }, (string[])null));
				double num14 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SubsurfaceRangeMax" }, (string[])null));
				Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SubsurfaceRangeMin" }, (string[])null));
				double num15 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SurfacePoK" }, (string[])null));
				double num16 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LandPoK" }, (string[])null));
				double num17 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "DetonationDelay" }, (string[])null));
				double num18 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Generation" }, (string[])null));
				double num19 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMin" }, (string[])null));
				double num20 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMax" }, (string[])null));
				double num21 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMax" }, (string[])null));
				double num22 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMin" }, (string[])null));
				Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMin_ASL" }, (string[])null));
				double num23 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMax_ASL" }, (string[])null));
				double num24 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMax_ASL" }, (string[])null));
				double num25 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMin_ASL" }, (string[])null));
				double num26 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoSpeedCruise" }, (string[])null));
				double num27 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoRangeCruise" }, (string[])null));
				double num28 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoSpeedFull" }, (string[])null));
				double num29 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoRangeFull" }, (string[])null));
				bool flag2 = false;
				DataRow[] array = Common.get_DataWeaponPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				string text = "";
				long num30 = 0L;
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num31 = Conversions.ToLong(array2[i]["ComponentID"]);
					DataRow? dataRow = Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num31);
					text = Conversions.ToString(dataRow["Name"]);
					num30 = Conversions.ToLong(dataRow["Type"]);
				}
				if (num30 == 3004L)
				{
					flag2 = true;
				}
				DataRow? dataRow2 = Common.get_MiscWeapon(Common.mySourceDB_Helper).Rows.Find(num);
				long num32 = Conversions.ToLong(dataRow2["ModifierPassiveSonar"]);
				long num33 = Conversions.ToLong(dataRow2["ModifierActiveSonar"]);
				long num34 = Conversions.ToLong(dataRow2["ModifierVisual"]);
				long num35 = Conversions.ToLong(dataRow2["ModifierIR"]);
				long num36 = Conversions.ToLong(dataRow2["ModifierRadar"]);
				DataRow[] array3 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				long num37 = 0L;
				bool flag7 = false;
				bool flag8 = false;
				long num38 = 0L;
				bool flag9 = false;
				bool flag10 = false;
				DataRow[] array4 = array3;
				for (int j = 0; j < array4.Length; j = checked(j + 1))
				{
					long num39 = Conversions.ToLong(array4[j]["CodeID"]);
					num38++;
					if (num39 == 7001L)
					{
						flag3 = true;
						num37++;
					}
					if (num39 == 7002L)
					{
						flag4 = true;
						num37++;
					}
					if (num39 == 7003L)
					{
						flag5 = true;
						num37++;
					}
					if (num39 == 4010L)
					{
						flag6 = true;
					}
					if (num39 == 9999L)
					{
						flag7 = true;
					}
					if (num39 == 2011L)
					{
						flag8 = true;
					}
				}
				if (num2 == 5001L)
				{
					flag10 = true;
				}
				if (flag10 && text.ToLower().Contains("boost"))
				{
					string text2 = "Weapon engine has a name that implies incorrect propulsion. MIRVs/MRVs/RVs should not have booster propulsion; should have re-entry propulsion.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 != 0.0 && !flag8)
				{
					string text2 = "Weapon has Cruise Altitude AGL, but has no Terrain Following flag.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 == 0.0 && flag8)
				{
					string text2 = "Weapon has Terrain Following flag set, but has no Cruise Altitude AGL set.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 < 0.0)
				{
					string text2 = "Weapon has negative Cruise Altitude AGL! Use Cruise Altitude ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 != 0.0 && num11 != 0.0)
				{
					string text2 = "Weapon has Cruise Altitude AGL and ASL set. Use one or the other.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num19 < 0.0)
				{
					string text2 = "Weapon has negative Minimum Launch Altitude AGL! Use ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num20 < 0.0)
				{
					string text2 = "Weapon has negative Maximum Launch Altitude AGL! Use ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num22 < 0.0)
				{
					string text2 = "Weapon has negative Minimum Target Altitude AGL! Use ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num21 < 0.0)
				{
					string text2 = "Weapon has negative Maximum Target Altitude AGL! Use ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num20 > num23 && num23 > 0.0)
				{
					string text2 = "Weapon has negative Cruise Altitude AGL! Use Cruise Altitude ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num21 > num24 && num24 > 0.0)
				{
					string text2 = "Weapon has negative Cruise Altitude AGL! Use Cruise Altitude ASL instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2001L && flag7 && num10 == 0.0 && num11 == 0.0)
				{
					string text2 = "Weapon has Level Cruise Flight flag but cruise Altitude is 0!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2001L && num3 < 1L)
				{
					string text2 = "This guided weapon has no climb rate!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L) && num26 < 1.0 && !flag2)
				{
					string text2 = "This Torpedo has no default cruise speed on the weapon itself!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L) && num27 < 1.0 && num27 > 0.5)
				{
					string text2 = "This Torpedo has no default cruise range on the weapon itself!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L || num2 == 4008L) && num26 > num28 && num28 != 0.0)
				{
					string text2 = "Torpedo on-weapon Cruise Speed is higher than Full Speed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L || num2 == 4008L) && num27 < num29 && num29 != 0.0)
				{
					string text2 = "Torpedo on-weapon Cruise Range is shorter than Full Range!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L || num2 == 4008L) && num27 < num12 && num12 > 0.5)
				{
					string text2 = "Torpedo anti-ship firing range is greater than kinematic cruise range!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L) && num27 < num14 && num14 != 0.0)
				{
					string text2 = "Torpedo anti-submarine firing range is greater than kinematic cruise range!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L || num2 == 4008L) && num28 == 0.0 && num29 != 0.0)
				{
					string text2 = "Torpedo kinematic full range has been entered, but no full speed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num2 == 4001L || num2 == 4007L || num2 == 4008L) && num28 != 0.0 && num29 == 0.0)
				{
					string text2 = "Torpedo kinematic full speed has been entered, but no full range!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2001L)
				{
					if (num4 <= 0.0)
					{
						string text2 = "Guided Weapons need Lenght stat!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 <= 0.0)
					{
						string text2 = "Guided Weapons need Span stat!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 <= 0.0)
					{
						string text2 = "Guided Weapons need Diameter stat!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 <= 0.0)
					{
						flag = true;
						string text2 = "Guided Weapons need Weight stat!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num34 < 1001L || num34 > 2999L) && num35 != 9001L)
					{
						string text2 = "Weapon is a Guided weapon, Visual Signature Modifier is not a legal for this weapon type!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num35 < 1001L || num35 > 2999L) && num35 != 9001L)
					{
						string text2 = "Weapon is a Guided weapon, IR Signature Modifier is not a legal for this weapon type!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num36 < 1001L || num36 > 3999L) && num35 != 9001L)
					{
						string text2 = "Weapon is a Guided weapon, Radar Signature Modifier is not a legal for this weapon type!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 1001L)
					{
						string text2 = "Weapon is a Guided Weapon, Passive Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 1001L)
					{
						string text2 = "Weapon is a Guided Weapon, Active Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2002L)
				{
					if (num34 != 1001L)
					{
						string text2 = "Weapon is a Rocket, Visual Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 != 1001L)
					{
						string text2 = "Weapon is a Rocket, IR Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 != 1001L)
					{
						string text2 = "Weapon is a Rocket, Radar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 1001L)
					{
						string text2 = "Weapon is a Rocket, Passive Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 1001L)
					{
						string text2 = "Weapon is a Rocket, Active Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2003L || num2 == 2009L)
				{
					if (num34 != 1001L)
					{
						string text2 = "Weapon is a Bomb, Visual Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 != 1001L)
					{
						string text2 = "Weapon is a Bomb, IR Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 != 1001L)
					{
						string text2 = "Weapon is a Bomb, Radar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 1001L)
					{
						string text2 = "Weapon is a Bomb, Passive Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 1001L)
					{
						string text2 = "Weapon is a Bomb, Active Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2004L)
				{
					if (num34 != 1001L)
					{
						string text2 = "Weapon is a Gun Shell, Visual Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 != 1001L)
					{
						string text2 = "Weapon is a Gun Shell, IR Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 != 1001L)
					{
						string text2 = "Weapon is a Gun Shell, Radar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 1001L)
					{
						string text2 = "Weapon is a Gun Shell, Passive Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 1001L)
					{
						string text2 = "Weapon is a Gun Shell, Active Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 5001L)
				{
					if (num34 != 4001L)
					{
						string text2 = "Weapon is a MIRV, Visual Signature Modifier must be set to MIRV!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 != 4001L)
					{
						string text2 = "Weapon is a MIRV, IR Signature Modifier must be set to MIRV!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 != 4001L)
					{
						string text2 = "Weapon is a MIRV, Radar Signature Modifier must be set to MIRV!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 1001L)
					{
						string text2 = "Weapon is a MIRV, Passive Sonar Signature Modifier must set be to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 1001L)
					{
						string text2 = "Weapon is a MIRV, Active Sonar Signature Modifier must be set to No Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 >= 2008L && num2 < 9999L && num2 != 5001L && num2 != 4001L && num2 != 4004L && num2 != 4005L && num2 != 4006L && num2 != 4007L && num2 != 4008L && num2 != 4009L && num2 != 4011L && num2 != 8001L)
				{
					if (num34 != 1001L)
					{
						string text2 = "Weapon must have Visual Signature Modifier set to No Weapon Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 != 1001L)
					{
						string text2 = "Weapon must have IR Signature Modifier set to No Weapon Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 != 1001L)
					{
						string text2 = "Weapon must have Radar Signature Modifier set to No Weapon Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 1001L)
					{
						string text2 = "Weapon must have Passive Sonar Signature Modifier set to No Weapon Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 1001L)
					{
						string text2 = "Weapon must have Active Sonar Signature Modifier set to No Weapon Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2005L || num2 == 2006L || num2 == 2007L)
				{
					DataRow[] array5 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag11 = false;
					flag12 = false;
					flag13 = false;
					flag14 = false;
					bool flag15 = false;
					long num40 = 0L;
					DataRow[] array6 = array5;
					for (int k = 0; k < array6.Length; k = checked(k + 1))
					{
						switch (Conversions.ToLong(array6[k]["CodeID"]))
						{
						case 1001L:
							flag12 = true;
							flag14 = true;
							break;
						case 2001L:
							flag11 = true;
							break;
						case 2002L:
							flag13 = true;
							break;
						default:
							flag15 = true;
							break;
						}
						num40++;
					}
					if (num40 > 1L)
					{
						string text2 = "Decoys may only immitate one target type: Aircraft, Ship or Submarine!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num40 == 0L)
					{
						string text2 = "Decoys must immitate one target type: Aircraft, Ship or Submarine!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15)
					{
						string text2 = "Decoy may only have Aircraft, Ship or Submarine as legal target!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2005L)
				{
					if (flag12 && num34 != 5001L && num34 != 9001L)
					{
						string text2 = "Expendable decoy immitates an aircraft. Visual Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num34 != 5002L && num34 != 5003L && num34 != 9001L)
					{
						string text2 = "Expendable decoy immitates a ship. Visual Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num34 != 9001L)
					{
						string text2 = "Expendable decoy immitates a submarine. Visual Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num35 != 5001L && num35 != 9001L)
					{
						string text2 = "Expendable decoy immitates an aircraft. IR Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num35 != 5002L && num35 != 5003L && num35 != 9001L)
					{
						string text2 = "Expendable decoy immitates a ship. IR Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num35 != 9001L)
					{
						string text2 = "Expendable decoy immitates a submarine. IR Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num36 != 5001L && num36 != 5003L && num36 != 9001L)
					{
						string text2 = "Expendable decoy immitates an aircraft. Radar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num36 != 5002L && num36 != 5004L && num36 != 5005L && num36 != 9001L)
					{
						string text2 = "Expendable decoy immitates a ship. Radar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num36 != 9001L)
					{
						string text2 = "Expendable decoy immitates a submarine. Radar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num32 != 9001L)
					{
						string text2 = "Expendable decoy immitates an aircraft. Passive Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num32 != 4002L && num32 != 4001L && num32 != 9001L)
					{
						string text2 = "Expendable decoy immitates a ship. Passive Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num32 != 4002L && num32 != 4001L && num32 != 9001L)
					{
						string text2 = "Expendable decoy immitates a submarine. Passive Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num33 != 9001L)
					{
						string text2 = "Expendable decoy immitates an aircraft. Active Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num33 != 4002L && num33 != 4001L && num33 != 9001L)
					{
						string text2 = "Expendable decoy immitates a ship. Active Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num33 != 4002L && num33 != 4001L && num33 != 9001L)
					{
						string text2 = "Expendable decoy immitates a submarine. Active Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num34 == 5001L || num34 == 5002L || num34 == 5003L) && num35 != 5001L && num35 != 5002L && num35 != 5003L)
					{
						string text2 = "Please correct Visual and IR Signature Modifiers. Expendable IR decoys must be visible in both IR and Visual bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num35 == 5001L || num35 == 5002L || num35 == 5003L) && num34 != 5001L && num34 != 5002L && num34 != 5003L)
					{
						string text2 = "Please correct Visual and IR Signature Modifiers. Expendable IR decoys must be visible in both IR and Visual bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2005L && (num18 < 3000.0 || num18 > 3999.0) && (num35 == 5001L || num35 == 5002L || num35 == 5003L))
				{
					string text2 = "This decoy is a flare, Generation to Single or Dual Spectral Flare!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2005L && num18 != 1002.0 && (num34 == 5004L || num34 == 5005L))
				{
					string text2 = "This round is a flare or smoke grenade! Generation to Not Applicable.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2005L && num18 != 1002.0 && (num36 == 5001L || num36 == 5002L || num36 == 5005L) && num35 != 5001L && num35 != 5002L && num35 != 5003L)
				{
					string text2 = "This decoy is a chaff round! Generation to Not Applicable.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2005L && (num18 < 2000.0 || num18 > 2999.0) && (num36 == 5003L || num36 == 5004L))
				{
					string text2 = "This decoy is a Active RF round! valid Generation (year).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2006L && flag12 && (num18 < 2000.0 || num18 > 2999.0) && num36 == 5006L)
				{
					string text2 = "This decoy is a airborne Towed Decoy! valid Generation (year).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 2006L)
				{
					if (flag12 && num34 != 9001L)
					{
						string text2 = "Towed Decoy immitates an aircraft. Visual Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num34 != 9001L)
					{
						string text2 = "Towed Decoy immitates a ship. Visual Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num34 != 9001L)
					{
						string text2 = "Towed Decoy immitates a submarine. Visual Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num35 != 9001L)
					{
						string text2 = "Towed Decoy immitates an aircraft. IR Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num35 != 9001L)
					{
						string text2 = "Towed Decoy immitates a ship. IR Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num35 != 9001L)
					{
						string text2 = "Towed Decoy immitates a submarine. IR Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num36 != 5006L)
					{
						string text2 = "Towed Decoy immitates an aircraft. Radar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num36 != 9001L)
					{
						string text2 = "Towed Decoy immitates a ship. Radar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num36 != 9001L)
					{
						string text2 = "Towed Decoy immitates a submarine. Radar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num32 != 9001L)
					{
						string text2 = "Towed Decoy immitates an aircraft. Passive Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num32 != 4001L && num32 != 4002L && num32 != 9001L)
					{
						string text2 = "Towed Decoy immitates a ship. Passive Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num32 != 4001L && num32 != 4002L && num32 != 9001L)
					{
						string text2 = "Towed Decoy immitates a submarine. Passive Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num33 != 9001L)
					{
						string text2 = "Towed Decoy immitates an aircraft. Active Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num33 != 4001L && num32 != 4002L)
					{
						string text2 = "Towed Decoy immitates a ship. Active Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num33 != 4001L && num32 != 4002L)
					{
						string text2 = "Towed Decoy immitates a submarine. Active Sonar Signature Modifier is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2007L)
				{
					if (flag11 || flag13)
					{
						string text2 = "Decoy Vehicles may only be used against radar. Remove illegal targets from Legal Targets list!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag14)
					{
						string text2 = "Decoy Vehicles may only be used against radar. Use Radar as Legal Target!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num34 != 1001L)
					{
						string text2 = "Decoy Vehicle has an invalid Visual Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num35 != 1001L)
					{
						string text2 = "Decoy Vehicle has an invalid IR Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 != 1001L && num36 != 5007L)
					{
						string text2 = "Decoy Vehicle has an invalid Radar Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 != 9001L)
					{
						string text2 = "Decoy Vehicle has an invalid Passive Sonar Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 9001L)
					{
						string text2 = "Decoy Vehicle has an invalid Active Sonar Signature Modifier!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2001L || num2 == 2002L || num2 == 2003L || num2 == 2004L || num2 == 2009L || num2 == 5001L)
				{
					DataRow[] array7 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					bool flag16 = false;
					bool flag17 = false;
					DataRow[] array8 = array7;
					for (int l = 0; l < array8.Length; l = checked(l + 1))
					{
						long num41 = Conversions.ToLong(array8[l]["CodeID"]);
						if (num41 >= 2001L && num41 <= 2999L)
						{
							flag17 = true;
						}
						if (num41 >= 3001L)
						{
							flag16 = true;
						}
						if (num41 == 3004L)
						{
							flag17 = true;
							flag16 = true;
						}
					}
					if (num8 <= 0.0 && flag16)
					{
						string text2 = "Anti-land weapons need a Land CEP value!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 <= 0.0 && flag17)
					{
						string text2 = "Anti-ship and Subroc/Asroc weapons need a Surface CEP value!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 != 0.0 && !flag16)
					{
						string text2 = "Weapon is not an anti-land capable weapon, but has Land CEP. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 != 0.0 && !flag17)
					{
						string text2 = "Weapon is not an anti-surface capable weapon, not Subroc/Asroc, but has Surface CEP. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (!(num2 == 2003L || num2 == 2009L || num2 == 4002L))
				{
					if (num17 != 0.0)
					{
						string text2 = "This is not a nuclear bomb, Detonation Delay to 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else
				{
					DataRow[] array9 = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int m = 0; m < array9.Length; m = checked(m + 1))
					{
						long num42 = Conversions.ToLong(array9[m]["ComponentID"]);
						DataRow? dataRow3 = Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num42);
						Conversions.ToLong(dataRow3["ID"]);
						long num43 = Conversions.ToLong(dataRow3["Type"]);
						Conversions.ToLong(dataRow3["DamagePoints"]);
						if (num43 == 4001L && num17 < 25.0)
						{
							string text2 = "Warhead is Nuclear, Detonation delay must be minimum 25 seconds!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num43 == 4001L && num17 > 190.0)
						{
							string text2 = "Warhead is Nuclear, Detonation delay can not be greater than 190 seconds!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				if (num2 == 2001L && num11 > 60960.0)
				{
					DataRow[] array10 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					long num44 = 0L;
					bool flag18 = false;
					bool flag19 = false;
					DataRow[] array11 = array10;
					for (int n = 0; n < array11.Length; n = checked(n + 1))
					{
						long num45 = Conversions.ToLong(array11[n]["CodeID"]);
						num44++;
						if (num45 == 1003L)
						{
							flag18 = true;
						}
						if (num45 == 1004L)
						{
							flag19 = true;
						}
					}
					DataRow[] array12 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int num46 = 0; num46 < array12.Length; num46 = checked(num46 + 1))
					{
						if (Conversions.ToLong(array12[num46]["CodeID"]) == 4010L)
						{
							flag6 = true;
						}
					}
					if (!flag6 && num11 > 60000.0 && !flag18 && !flag19)
					{
						string text2 = "Weapon is a ballistic missile but had no Ballistic Missile flag is on the weapon!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					DataRow[] array13 = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					long num47 = 0L;
					DataRow[] array14 = array13;
					for (int num48 = 0; num48 < array14.Length; num48 = checked(num48 + 1))
					{
						num47++;
					}
					DataRow[] array15 = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int num49 = 0; num49 < array15.Length; num49 = checked(num49 + 1))
					{
						long num50 = Conversions.ToLong(array15[num49]["ComponentID"]);
						DataRow? dataRow4 = Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num50);
						Conversions.ToLong(dataRow4["ID"]);
						long num51 = Conversions.ToLong(dataRow4["Type"]);
						long num52 = Conversions.ToLong(dataRow4["DamagePoints"]);
						if (num51 != 5002L && !flag18 && !flag19)
						{
							string text2 = "Ballistic missiles need to carry a RV / MRV / MIRV, which must be a separate weapon entry!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num51 != 5002L)
						{
							continue;
						}
						DataRow? dataRow5 = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num52);
						long num53 = Conversions.ToLong(dataRow5["Type"]);
						double num54 = Conversions.ToLong(dataRow5["ClimbRate"]);
						long num55 = Conversions.ToLong(dataRow5["CEP"]);
						long num56 = Conversions.ToLong(dataRow5["CEPSurface"]);
						double num57 = Conversions.ToDouble(dataRow5["SurfaceRangeMax"]);
						double num58 = Conversions.ToDouble(dataRow5["SurfaceRangeMin"]);
						double num59 = Conversions.ToDouble(dataRow5["LandRangeMax"]);
						double num60 = Conversions.ToDouble(dataRow5["LandRangeMin"]);
						long num61 = Conversions.ToLong(dataRow5["SurfacePoK"]);
						long num62 = Conversions.ToLong(dataRow5["LandPoK"]);
						double num63 = Conversions.ToDouble(dataRow5["CruiseAltitude_ASL"]);
						double num64 = Conversions.ToDouble(dataRow5["CruiseAltitude"]);
						bool flag20 = false;
						if (num53 == 8001L)
						{
							flag20 = true;
						}
						if (!(num53 == 5001L || num53 == 8001L))
						{
							string text2 = "ICBM / IRBM warhead weapons must be of type RV / MRV / MIRV or HGV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num64 != 0.0)
						{
							string text2 = "ICBM / IRBM must use ASL not AGL cruise altitude!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num54 != 3000.0 && num11 >= 800000.0 && num11 <= 1200000.0)
						{
							string text2 = "For ICBMs, (Cruise Alt 800 - 12000km), RV/MRV/MIRV decent rate must be 3000m/s (= 6000m/s dive rate)!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num3 != 1750L && num11 >= 800000.0 && num11 <= 1200000.0)
						{
							string text2 = "For ICBMs, (Cruise Alt 800 - 12000km), missile climb rate must be 1750m/s!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num54 != 2500.0 && num11 >= 250001.0 && num11 <= 550000.0)
						{
							string text2 = "For IRBMs, (Cruise Alt 250 - 550km), RV/MRV/MIRV decent rate must be 2500m/s (= 5000m/s dive rate)!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num3 != 1500L && num11 >= 250001.0 && num11 <= 550000.0)
						{
							string text2 = "For IRBMs, (Cruise Alt 250 - 550km), missile climb rate must be 1500m/s!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num54 != 1500.0 && num11 >= 12000.0 && num11 <= 250000.0 && flag6 && !flag20)
						{
							string text2 = "For SRBM, (Cruise Alt 120 - 200km), RV decent rate must be 1500m/s (= 3000m/s dive rate)!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num3 != 1500L && num11 >= 12000.0 && num11 <= 250000.0 && flag6 && !flag20)
						{
							string text2 = "For SRBM, (Cruise Alt 120 - 200km), missile climb rate must be 1500m/s!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((double)num55 != num8)
						{
							string text2 = "ICBM / IRBM must have the same Land CEP as their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((double)num56 != num9)
						{
							string text2 = "ICBM / IRBM must have the same Surface CEP as their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num57 != num12)
						{
							string text2 = "ICBM / IRBM must have the same Max Surface Range as their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num59 != num13)
						{
							string text2 = "ICBM / IRBM must have the same Max Land Range as their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num58 != 0.0)
						{
							string text2 = "RV / MIRV must have a 0nm minimum surface range!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num60 != 0.0)
						{
							string text2 = "RV / MIRV must have a 0nm minimum land range!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((double)num61 != num15)
						{
							string text2 = "ICBM / IRBM must have the same Surface PoK as their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((double)num62 != num16)
						{
							string text2 = "ICBM / IRBM must have the same Land PoK as their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num63 != num11 && !flag20)
						{
							string text2 = "ICBM / IRBM must have the same Cruise Altitude their RV / MIRV!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						DataRow[] array16 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num52));
						long num65 = 0L;
						DataRow[] array17 = array16;
						for (int num66 = 0; num66 < array17.Length; num66 = checked(num66 + 1))
						{
							long num67 = Conversions.ToLong(array17[num66]["CodeID"]);
							num65++;
							bool flag21 = false;
							DataRow[] array18 = array10;
							for (int num68 = 0; num68 < array18.Length; num68 = checked(num68 + 1))
							{
								if (Conversions.ToLong(array18[num68]["CodeID"]) == num67)
								{
									flag21 = true;
								}
							}
							if (!flag21)
							{
								string text2 = "Re-entry vehicle and parent missile need to be capable against the same types of targets!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						if (num65 != num44)
						{
							string text2 = "Re-entry vehicle and parent missile need to be capable against the same types of targets!!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						DataRow[] array19 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num52));
						num65 = 0L;
						long num69 = 0L;
						DataRow[] array20 = array19;
						for (int num70 = 0; num70 < array20.Length; num70 = checked(num70 + 1))
						{
							long num71 = Conversions.ToLong(array20[num70]["CodeID"]);
							num69++;
							bool flag22 = false;
							DataRow[] array21 = array3;
							for (int num72 = 0; num72 < array21.Length; num72 = checked(num72 + 1))
							{
								if (Conversions.ToLong(array21[num72]["CodeID"]) == num71)
								{
									flag22 = true;
								}
							}
							if (!flag22 && !flag20)
							{
								string text2 = "Re-entry vehicle and parent missile must have identical weapon codes!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								break;
							}
						}
						if (num69 != num38 && !flag20)
						{
							string text2 = "Re-entry vehicle and parent missile must have identical weapon codes!!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (num37 != 1L && !flag18 && !flag19 && !flag9)
					{
						string text2 = "Ballistic missiles need one warhead flag!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && num47 != 1L)
					{
						string text2 = "Warhead flag says Single RV but the number of warheads on the weapon does not reflect this";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && num47 <= 1L)
					{
						string text2 = "Warhead flag says MRV but the missile carriers only one or none warheads.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && num47 <= 1L)
					{
						string text2 = "Warhead flag says MIRV but the missile carriers only one or none warheads.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num30 == 5001L && num34 != 2001L && num34 != 2002L && (num2 == 2001L || num2 == 2008L))
				{
					string text2 = "Weapon uses rocket propulsion but the Visual Modifer does not have the rocket smoke plume set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num30 == 5001L && num35 != 2001L && num35 != 2002L && (num2 == 2001L || num2 == 2008L))
				{
					string text2 = "Weapon uses rocket propulsion but the IR Modifer does not have the rocket smoke plume set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num30 != 5001L && (num35 == 2001L || num35 == 2002L) && (num2 == 2001L || num2 == 2008L))
				{
					string text2 = "Weapon does NOT use rocket propulsion but the IR Modifer has a rocket smoke plume set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num30 != 5001L && (num34 == 2001L || num34 == 2002L) && (num2 == 2001L || num2 == 2008L))
				{
					string text2 = "Weapon does NOT use rocket propulsion but the Visual Modifer has a rocket smoke plume set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4004L || num2 == 4005L || num2 == 4007L || num2 == 4008L || num2 == 4011L)
				{
					if (num24 >= 0.0)
					{
						string text2 = "All mines except Drifting Mines must have a Minimum Target Depth (i.e. a negative number)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num24 >= 0.0)
					{
						string text2 = "All mines except Drifting Mines must have a Maximum Target Depth (i.e. a negative number)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num25 > num24)
					{
						string text2 = "For mines, minimum target depth (i.e. deployment depth) can not be greater than max target depth.!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 4006L || num2 == 4009L)
				{
					if (num25 != 0.0)
					{
						string text2 = "Drifting and Floating Mines must have Minimum Target Depth to 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num24 != 0.0)
					{
						string text2 = "Drifting and Floating Mines must have Maximum Target Depth to 0";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 4004L || num2 == 4005L || num2 == 4006L || num2 == 4007L || num2 == 4008L || num2 == 4009L || num2 == 4011L)
				{
					if ((ulong)num3 > 0uL && num2 != 4008L)
					{
						string text2 = "Climb rate for mines shall be 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 <= 0L && num2 == 4008L)
					{
						string text2 = "Climb rate for rising mines must be greater than 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 != 0.0 && num2 != 4007L)
					{
						string text2 = "Cruise altitude for mines shall be 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				DataRow[] array22 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long num73 = 0L;
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
				DataRow[] array23 = array22;
				for (int num74 = 0; num74 < array23.Length; num74 = checked(num74 + 1))
				{
					long num75 = Conversions.ToLong(array23[num74]["CodeID"]);
					if (num75 == 6301L)
					{
						num73++;
						flag23 = true;
					}
					if (num75 == 6311L)
					{
						num73++;
						flag24 = true;
					}
					if (num75 == 6312L)
					{
						num73++;
						flag25 = true;
					}
					if (num75 == 6321L)
					{
						num73++;
						flag26 = true;
					}
					if (num75 == 6322L)
					{
						num73++;
						flag27 = true;
					}
					if (num75 == 6331L)
					{
						num73++;
						flag28 = true;
					}
					if (num75 == 6341L)
					{
						num73++;
						flag29 = true;
					}
					if (num75 == 6401L)
					{
						flag30 = true;
					}
					if (num75 == 6402L)
					{
						flag31 = true;
					}
					if (num75 == 6501L)
					{
						flag32 = true;
					}
					if (num75 == 6511L)
					{
						flag33 = true;
					}
				}
				if (num73 == 0L && (num2 == 4004L || num2 == 4005L || num2 == 4006L || num2 == 4007L || num2 == 4009L))
				{
					string text2 = "All mines need minimum one fuze type!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag24 && flag25)
				{
					string text2 = "Two Magnetic Fuze codes have been selected, use only one!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag26 && flag27)
				{
					string text2 = "Two Acoustic Fuze codes have been selected, use only one!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag33 || flag32 || flag31 || flag30 || flag29 || flag28 || flag27 || flag26 || flag25 || flag24 || flag23) && num2 != 4004L && num2 != 4005L && num2 != 4006L && num2 != 4007L && num2 != 4008L && num2 != 4009L)
				{
					string text2 = "Mine codes shall only be used for mines!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4004L && flag23)
				{
					string text2 = "Bottom mines can not have Contact Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4005L && flag29)
				{
					string text2 = "Moored mines can not have Seismic Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4005L && flag33)
				{
					string text2 = "Moored mines can not be remote controlled!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4006L && !flag23)
				{
					string text2 = "Floating mines need Contact Fuze!";
					string string_ = "Floating INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4006L && flag33)
				{
					string text2 = "Floating mines can not be remote controlled!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4006L && flag29)
				{
					string text2 = "Floating mines can not have Seismic Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4006L && flag29)
				{
					string text2 = "Floating mines can not have Seismic Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4007L && flag23)
				{
					string text2 = "Moving mines can not have Contact Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4007L && flag33)
				{
					string text2 = "Moving mines can not be remote controlled!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4008L && flag23)
				{
					string text2 = "Rising mines can not have Contact Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4009L && !flag23)
				{
					string text2 = "Drifting mines need Contact Fuze!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4009L && flag33)
				{
					string text2 = "Drifting mines can not be remote controlled!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 4011L && (ulong)num73 > 0uL)
				{
					string text2 = "Dummy mines mines can not have fuzes!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 <= 0.0 && !flag)
				{
					string text2 = "Warning : Weight is missing for this weapon (Highly recommended for proper replenishment rate) ";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200115", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponsHaveOnlyOnePropulsionAndFuelRecord()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (!DataValidateAllInOne.DeprecationImplemented || !Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
					if (Common.get_DataWeaponPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 1)
					{
						string text = "The unit has more than one propulsion system! Only one propulsion system is allowed!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Common.get_DataWeaponFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 1)
					{
						string text = "The unit has more than one fuel record! Only one fuel record is allowed!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200116", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponsCorrectFuelLoad()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			long num33 = default(long);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				double num2 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude" }, (string[])null));
				double num3 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude_ASL" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "AirRangeMax" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SurfaceRangeMax" }, (string[])null));
				double num6 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LandRangeMax" }, (string[])null));
				double num7 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SubsurfaceRangeMax" }, (string[])null));
				long num8 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				long num9 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ClimbRate" }, (string[])null));
				double num10 = 0.0;
				double num11;
				int num12;
				if (num2 != 0.0)
				{
					num11 = num2;
					num12 = 0;
				}
				else if (num3 != 0.0)
				{
					num11 = num3;
					num12 = 0;
				}
				else
				{
					num11 = 0.0;
					num12 = 0;
				}
				bool flag = (byte)num12 != 0;
				if (num8 == 2001L || num8 == 2007L)
				{
					if (num4 <= 0.0 && num5 <= 0.0 && num6 <= 0.0 && num7 <= 0.0)
					{
						string text = "Weapons Air, Surface, Land and Subsurface Max Range is 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 > num10)
					{
						num10 = num4;
					}
					if (num5 > num10)
					{
						num10 = num5;
					}
					if (num6 > num10)
					{
						num10 = num6;
					}
					int num13;
					if (num7 > num10)
					{
						num10 = num7;
						num13 = 0;
					}
					else
					{
						num13 = 0;
					}
					long num14 = num13;
					DataRow[] array = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					double num17;
					double num18;
					double num19;
					double num20;
					double num21;
					double num22;
					double num23;
					double num24;
					bool flag2;
					bool flag3;
					bool flag4;
					checked
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (Conversions.ToLong(array[i]["CodeID"]) == 4010L)
							{
								flag = true;
							}
						}
						DataRow[] array2 = Common.get_DataWeaponFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
						DataRow[] array3 = array2;
						for (int j = 0; j < array3.Length; j++)
						{
							long num15 = Conversions.ToLong(array3[j]["ComponentID"]);
							DataRow dataRow = Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num15);
							if (!Information.IsNothing((object)dataRow))
							{
								Conversions.ToLong(dataRow["Type"]);
								num14 = Conversions.ToLong(dataRow["Capacity"]);
								continue;
							}
							string text = "Fuel record with ID #" + Conversions.ToString(num15) + " (referenced by Weapon #" + Conversions.ToString(num) + ") does not exist.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						long num16 = 0L;
						num17 = 0.0;
						num18 = 0.0;
						num19 = 0.0;
						num20 = 0.0;
						num21 = 0.0;
						num22 = 0.0;
						num23 = 0.0;
						num24 = 0.0;
						flag2 = false;
						flag3 = false;
						flag4 = false;
						DataRow[] array4 = Common.get_DataWeaponPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
						for (int k = 0; k < array4.Length; k++)
						{
							num16 = Conversions.ToLong(array4[k]["ComponentID"]);
							long num25 = 0L;
							DataRow[] array5 = Common.get_DataPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
							for (int l = 0; l < array5.Length; l++)
							{
								num25 = Conversions.ToLong(array5[l]["Type"]);
							}
							if (num25 == 3004L)
							{
								if (array2.Count() > 0)
								{
									string text = "Weapon is nuclear-powered, remove fuel entry.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								continue;
							}
							DataRow[] array6 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
							unchecked
							{
								foreach (DataRow obj in array6)
								{
									double num26 = Conversions.ToDouble(obj["Speed"]);
									double num27 = Conversions.ToDouble(obj["AltitudeBand"]);
									double num28 = Conversions.ToDouble(obj["Throttle"]);
									double num29 = Conversions.ToDouble(obj["AltitudeMin"]);
									double num30 = Conversions.ToDouble(obj["AltitudeMax"]);
									if (num27 == 1.0)
									{
										if (num28 != 2.0)
										{
											continue;
										}
										num21 = num26;
										if (num2 != 0.0)
										{
											if (num2 >= num29 && num2 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num3 != 0.0)
										{
											if (num3 >= num29 && num3 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num17 <= num26)
										{
											num17 = num26;
										}
										if (!(num2 >= num29 && num2 <= num30))
										{
											if (num3 >= num29 && num3 <= num30)
											{
												num20 = 1.0;
											}
										}
										else
										{
											num20 = 1.0;
										}
										num19 += 1.0;
									}
									else if (num27 == 2.0)
									{
										if (num28 != 2.0)
										{
											continue;
										}
										num22 = num26;
										flag2 = true;
										if (num2 != 0.0)
										{
											if (num2 >= num29 && num2 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num3 != 0.0)
										{
											if (num3 >= num29 && num3 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num17 <= num26)
										{
											num17 = num26;
										}
										if (num11 >= num29 && num11 <= num30)
										{
											num20 = 2.0;
										}
										else if (num3 >= num29 && num3 <= num30)
										{
											num20 = 2.0;
										}
										num19 += 1.0;
									}
									else if (num27 == 3.0)
									{
										if (num28 != 2.0)
										{
											continue;
										}
										num23 = num26;
										flag3 = true;
										if (num2 != 0.0)
										{
											if (num2 >= num29 && num2 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num3 != 0.0)
										{
											if (num3 >= num29 && num3 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num17 <= num26)
										{
											num17 = num26;
										}
										num19 += 1.0;
										if (num2 >= num29 && num2 <= num30)
										{
											num20 = 3.0;
										}
										else if (num3 >= num29 && num3 <= num30)
										{
											num20 = 3.0;
										}
									}
									else
									{
										if (num27 != 4.0 || num28 != 2.0)
										{
											continue;
										}
										num24 = num26;
										flag4 = true;
										if (num2 != 0.0)
										{
											if (num2 >= num29 && num2 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num3 != 0.0)
										{
											if (num3 >= num29 && num3 <= num30)
											{
												num17 = num26;
											}
										}
										else if (num17 <= num26)
										{
											num17 = num26;
										}
										num19 += 1.0;
										if (num2 >= num29 && num2 <= num30)
										{
											num20 = 4.0;
										}
										else if (num3 >= num29 && num3 <= num30)
										{
											num20 = 4.0;
										}
									}
								}
							}
						}
					}
					if (num11 == 0.0 && num3 != 0.0)
					{
						num11 = num3;
					}
					if (num19 > 1.0)
					{
						if (num20 == 1.0 && flag2)
						{
							num18 = num21 - (num21 - num22) / 12000.0 * num11;
						}
						else if (num20 == 1.0)
						{
							num18 = num21;
						}
						if (num20 == 2.0 && flag3)
						{
							num18 = num22 - (num22 - num23) / 7315.2 * num11;
						}
						else if (num20 == 2.0)
						{
							num18 = num22;
						}
						if (!(num20 == 3.0 && flag4))
						{
							if (num20 == 3.0)
							{
								num18 = num23;
							}
						}
						else
						{
							num18 = num23 - (num23 - num24) / 10972.8 * num11;
						}
						if (num20 == 4.0)
						{
							num18 = num24;
						}
					}
					else
					{
						num18 = num17;
					}
					if (num17 <= 0.0 && (num8 == 2001L || num8 == 4001L || num8 == 4008L))
					{
						string text = "Weapons Air, Surface and Subsurface Max Speed is 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num17 == 0.0 && num11 != 0.0)
					{
						string text = "Something is wrong, it could be the cruise altitude is higher than the engine max altitude.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num17 == 0.0)
					{
						continue;
					}
					long num31 = 0L;
					if (num8 == 2001L)
					{
						if (num5 > 0.0 || num7 > 0.0 || num6 > 0.0)
						{
							try
							{
								num31 = ((!(num11 > 0.0) || !(num18 > 0.0) || flag) ? ((long)Math.Round(num10 * 3600.0 / num17 * 1.1)) : ((long)Math.Round(num10 * 3600.0 / num18 * 1.1)));
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
							if (flag)
							{
								if (num9 != 0L)
								{
									try
									{
										num31 = (long)Math.Round((double)num31 + num11 / (double)num9 * 2.0);
									}
									catch (Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										throw;
									}
								}
								else
								{
									string text = "Weapon #" + Conversions.ToString(num) + " has no climb rate but is ballistic missile!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
						if (num4 > 0.0)
						{
							num31 = (long)Math.Round(0.0 - Conversion.Int((0.0 - num10 * 3600.0) / num17));
						}
						num31 += 3L;
						if (num31 != num14 && num31 + 1L != num14 && num31 - 1L != num14)
						{
							string text = "Guided weapon fuel load is incorrect, it should be: " + Conversions.ToString(num31);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (num8 == 2007L && num10 > 0.0)
					{
						num31 = (long)Math.Round(0.0 - Conversion.Int((0.0 - num10 * 3600.0) / num17));
						num31 += 3L;
						if (num31 != num14)
						{
							string text = "Decoy fuel load is incorrect, it should be: " + Conversions.ToString(num31);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				if (!(num8 == 4001L || num8 == 4007L || num8 == 4008L))
				{
					continue;
				}
				DataRow[] array7 = Common.get_DataWeaponFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int n = 0; n < array7.Length; n = checked(n + 1))
				{
					int num32 = Conversions.ToInteger(array7[n]["ComponentID"]);
					DataRow? dataRow2 = Common.get_DataFuel(Common.mySourceDB_Helper).Rows.Find(num32);
					Conversions.ToLong(dataRow2["Type"]);
					num33 = Conversions.ToLong(dataRow2["Capacity"]);
				}
				DataRow? dataRow3 = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num);
				double num34 = Conversions.ToDouble(dataRow3["TorpedoSpeedCruise"]);
				double num35 = Conversions.ToDouble(dataRow3["TorpedoRangeCruise"]);
				Conversions.ToDouble(dataRow3["TorpedoSpeedFull"]);
				Conversions.ToDouble(dataRow3["TorpedoRangeFull"]);
				if (num34 != 0.0 || num35 != 0.0)
				{
					double num36 = 0.0 - Conversion.Int((0.0 - num35 * 3600.0) / num34);
					if (num36 != (double)num33)
					{
						string text = "Torpedo fuel load should be: " + Conversions.ToString(num36);
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception ex3 = ex2;
			ErrorManagement.EnqueueErrorMessage(ex3);
			ex3.Data.Add("Error at Validation 200117", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAntiAirMissilesRequiredHaveFlags()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				double num2 = Conversions.ToDouble(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num)["Type"]);
				DataRow[] array = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				long num3 = 0L;
				if (num2 == 2001.0)
				{
					DataRow[] array2 = array;
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						double num4 = Conversions.ToDouble(array2[i]["CodeID"]);
						DataRow[] array3 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
						if (num4 >= 2001.0 && num4 <= 2005.0)
						{
							num3++;
						}
						DataRow[] array4 = array3;
						for (int j = 0; j < array4.Length; j = checked(j + 1))
						{
							double num5 = Conversions.ToDouble(array4[j]["CodeID"]);
							if (num5 == 1001.0 || num5 == 1002.0 || num5 == 1003.0 || num5 == 1004.0)
							{
								flag3 = true;
							}
							if (!flag2 && (num5 != 1001.0 || num5 != 1002.0 || num5 != 1003.0 || num5 == 1004.0))
							{
								flag2 = true;
							}
							if (!flag4 && (num4 == 2001.0 || num4 == 2002.0 || num4 == 2003.0 || num4 == 2004.0 || num4 == 2005.0))
							{
								flag4 = true;
							}
						}
					}
					if (num3 >= 2L)
					{
						string text = "This missile has two Anti-Air flags. It should only have one! (In the Code field)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && !flag4)
					{
						string text = "This missile is anti-air capable but does not have an Anti-Air flag!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag3 && flag4)
					{
						string text = "This missile is not anti-air capable but has an Anti-Air flag!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					continue;
				}
				flag = false;
				DataRow[] array5 = array;
				for (int k = 0; k < array5.Length; k = checked(k + 1))
				{
					double num4 = Conversions.ToDouble(array5[k]["CodeID"]);
					if ((num4 == 2001.0 || num4 == 2002.0 || num4 == 2003.0 || num4 == 2004.0 || num4 == 2005.0) && !flag)
					{
						flag = true;
					}
				}
				if (flag)
				{
					string text = "This weapon should not have an Anti-Air flag! (In the Code field)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200118", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponPokVsRangeVsTargettype()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				DataRow? dataRow = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num);
				double num2 = Conversions.ToDouble(dataRow["Type"]);
				double num3 = Conversions.ToDouble(dataRow["AirPoK"]);
				double num4 = Conversions.ToDouble(dataRow["AirRangeMin"]);
				double num5 = Conversions.ToDouble(dataRow["AirRangeMax"]);
				double num6 = Conversions.ToDouble(dataRow["SurfacePoK"]);
				double num7 = Conversions.ToDouble(dataRow["SurfaceRangeMin"]);
				double num8 = Conversions.ToDouble(dataRow["SurfaceRangeMax"]);
				double num9 = Conversions.ToDouble(dataRow["LandPoK"]);
				double num10 = Conversions.ToDouble(dataRow["LandRangeMin"]);
				double num11 = Conversions.ToDouble(dataRow["LandRangeMax"]);
				double num12 = Conversions.ToDouble(dataRow["SubsurfacePoK"]);
				double num13 = Conversions.ToDouble(dataRow["SubsurfaceRangeMin"]);
				double num14 = Conversions.ToDouble(dataRow["SubsurfaceRangeMax"]);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				if (num3 > 95.0)
				{
					string text = "Air PoK is greater than 95%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num6 > 99.0)
				{
					string text = "Surface PoK is greater than 99%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num9 > 99.0)
				{
					string text = "Land PoK is greater than 99%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num12 > 99.0)
				{
					string text = "Subsurface PoK is greater than 95%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				DataRow[] array = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					double num15 = Conversions.ToDouble(array[i]["CodeID"]);
					if (!flag3 && (num15 == 1001.0 || num15 == 1002.0 || num15 == 1003.0 || num15 == 1004.0))
					{
						flag3 = true;
						if (num3 <= 0.0)
						{
							string text = "Capable vs Air targets but the PoK is 0%";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
						if (num4 <= 0.0 && num2 == 2001.0)
						{
							string text = "Capable vs Air targets but the minimum Air range is 0nm";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
						if (num5 <= 0.0)
						{
							string text = "Capable vs Air targets but the maximum Air range is 0nm";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
					}
					else if (!(!flag4 && num15 == 2001.0))
					{
						if (!flag5 && (num15 == 3001.0 || num15 == 3002.0 || num15 == 3003.0 || num15 == 4001.0 || num15 == 4002.0))
						{
							flag5 = true;
							if (num9 <= 0.0)
							{
								string text = "Capable vs Land targets but the PoK is 0%";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num10 <= 0.0 && num2 == 2001.0)
							{
								string text = "Capable vs Land targets but the minimum Land range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num10 > 0.0 && (num2 == 4004.0 || num2 == 4005.0 || num2 == 4006.0 || num2 == 4009.0 || num2 == 4011.0))
							{
								string text = "Minimum Land range should be 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num11 <= 0.0 && num2 != 4004.0 && num2 != 4005.0 && num2 != 4006.0 && num2 != 4009.0 && num2 != 4011.0)
							{
								string text = "Capable vs Land targets but the maximum Land range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
						}
						else if (!flag5 && num15 == 3004.0)
						{
							flag6 = true;
							if (num9 <= 0.0)
							{
								string text = "Anti-radiation missile but Land PoK is 0%";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num6 <= 0.0)
							{
								string text = "Anti-radiation missile but Surface PoK is 0%";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num10 <= 0.0 && num2 == 2001.0)
							{
								string text = "Anti-radiation missile but the minimum Land range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num7 <= 0.0 && num2 == 2001.0)
							{
								string text = "Anti-radiation missile but the minimum Surface range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num10 > 0.0 && (num2 == 4004.0 || num2 == 4005.0 || num2 == 4006.0 || num2 == 4009.0 || num2 == 4011.0))
							{
								string text = "Minimum Land range should be 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num7 > 0.0 && (num2 == 4004.0 || num2 == 4005.0 || num2 == 4006.0 || num2 == 4009.0 || num2 == 4011.0))
							{
								string text = "Minimum Surface range should be 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num11 <= 0.0 && num2 != 4004.0 && num2 != 4005.0 && num2 != 4006.0 && num2 != 4009.0 && num2 != 4011.0)
							{
								string text = "Anti-radiation missile but the maximum Land range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num8 <= 0.0 && num2 != 4004.0 && num2 != 4005.0 && num2 != 4006.0 && num2 != 4009.0 && num2 != 4011.0)
							{
								string text = "Anti-radiation missile but the maximum Surface range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
						}
						else if (!flag7 && (num15 == 2002.0 || num15 == 2003.0 || num15 == 2004.0) && num2 != 4011.0 && num2 != 4101.0)
						{
							flag7 = true;
							if (num12 <= 0.0)
							{
								string text = "Capable vs Subsurface targets but the PoK is 0%";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num13 <= 0.0 && num2 == 2001.0)
							{
								string text = "Capable vs Subsurface targets but the minimum Subsurface range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num13 > 0.0 && (num2 == 4004.0 || num2 == 4005.0 || num2 == 4006.0 || num2 == 4009.0 || num2 == 4011.0))
							{
								string text = "Minimum Surface range should be 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							if (num14 <= 0.0 && num2 != 4004.0 && num2 != 4005.0 && num2 != 4006.0 && num2 != 4009.0 && num2 != 4011.0 && num2 != 4101.0 && num2 != 2006.0 && num2 != 2005.0)
							{
								string text = "Capable vs Subsurface targets but the maximum Subsurface range is 0nm";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
						}
					}
					else
					{
						flag4 = true;
						if (num6 <= 0.0)
						{
							string text = "Capable vs Surface targets but the PoK is 0%";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
						if (num7 <= 0.0 && num2 == 2001.0)
						{
							string text = "Capable vs Surface targets but the minimum Surface range is 0nm";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
						if (num7 > 0.0 && (num2 == 4004.0 || num2 == 4005.0 || num2 == 4006.0 || num2 == 4009.0 || num2 == 4011.0))
						{
							string text = "Minimum Surface range should be 0nm";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
						if (num8 <= 0.0 && num2 != 4004.0 && num2 != 4005.0 && num2 != 4006.0 && num2 != 4009.0 && num2 != 4011.0)
						{
							string text = "Capable vs Surface targets but the maximum Surface range is 0nm";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
					}
					if (num15 == 1001.0)
					{
						flag2 = true;
					}
					if (num15 == 1002.0)
					{
						flag = true;
					}
				}
				if (num2 == 2004.0 && flag2 && !flag)
				{
					string text = "Guns that are capable against aircraft should also be capable against helicopters.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num2 == 2004.0 && !flag2 && flag)
				{
					string text = "Guns that are capable against helicopters should also be capable against aircraft.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag3 && num3 > 0.0)
				{
					string text = "Weapon has Air PoK but is not capable against air targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag3 && num5 > 0.0)
				{
					string text = "Weapon has Air Max range but is not capable against air targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag3 && num4 > 0.0)
				{
					string text = "Weapon has Air Min range but is not capable against air targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag4 && !flag6 && num6 > 0.0 && num2 != 2004.0 && num2 != 2005.0)
				{
					string text = "Weapon has Surface PoK but is not capable against surface targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag4 && !flag6 && num8 > 0.0)
				{
					string text = "Weapon has Surface Max range but is not capable against surface targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag4 && !flag6 && num7 > 0.0)
				{
					string text = "Weapon has Surface Min range but is not capable against surface targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag5 && !flag6 && num9 > 0.0 && num2 != 2004.0 && num2 != 2005.0)
				{
					string text = "Weapon has Land PoK but is not capable against Land targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag5 && !flag6 && num11 > 0.0)
				{
					string text = "Weapon has Land Max range but is not capable against Land targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag5 && !flag6 && num10 > 0.0)
				{
					string text = "Weapon has Land Min range but is not capable against Land targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag7 && num12 > 0.0)
				{
					string text = "Weapon has Subsurface PoK but is not capable against subsurface targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag7 && num14 > 0.0)
				{
					string text = "Weapon has Subsurface Max range but is not capable against subsurface targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag7 && num13 > 0.0)
				{
					string text = "Weapon has Subsurface Min range but is not capable against subsurface targets";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num3 > 0.0 && num5 <= 0.0)
				{
					string text = "The weapon has a Air PoK while the max range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num3 > 0.0 && num4 <= 0.0 && num2 == 2001.0)
				{
					string text = "The weapon has a Air PoK while the min range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num6 > 0.0 && num8 <= 0.0 && num2 == 4007.0 && num2 == 4008.0)
				{
					string text = "The weapon has a Surface PoK while the max range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num6 > 0.0 && num7 <= 0.0 && num2 == 2001.0)
				{
					string text = "The weapon has a Surface PoK while the min range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num9 > 0.0 && num11 <= 0.0 && num2 == 4007.0 && num2 == 4008.0)
				{
					string text = "The weapon has a Land PoK while the max range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num9 > 0.0 && num10 <= 0.0 && num2 == 2001.0)
				{
					string text = "The weapon has a Land PoK while the min range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num12 > 0.0 && num14 <= 0.0 && num2 == 4007.0 && num2 == 4008.0)
				{
					string text = "The weapon has a Subsurface PoK while the max Range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num12 > 0.0 && num13 <= 0.0 && num2 == 2001.0)
				{
					string text = "The weapon has a Subsurface PoK while the min range is 0nm ";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num3 <= 0.0 && num5 > 0.0)
				{
					string text = "The weapon has Air Max Range while the PoK is 0%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num6 <= 0.0 && num8 > 0.0)
				{
					string text = "The weapon has Surface Max Range while the PoK is 0%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num9 <= 0.0 && num11 > 0.0)
				{
					string text = "The weapon has Land Max Range while the PoK is 0%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				int num16;
				if (!(num12 <= 0.0 && num14 > 0.0))
				{
					num16 = 0;
				}
				else
				{
					string text = "The weapon has Subsurface Max Range while the PoK is 0%";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					num16 = 0;
				}
				bool flag8 = (byte)num16 != 0;
				bool flag9 = false;
				bool flag10 = false;
				bool flag11 = false;
				if (num2 != 2004.0)
				{
					continue;
				}
				DataRow[] array2 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int j = 0; j < array2.Length; j = checked(j + 1))
				{
					double num15 = Conversions.ToDouble(array2[j]["CodeID"]);
					if (num15 == 3001.0)
					{
						flag8 = true;
					}
					if (num15 == 3002.0)
					{
						flag9 = true;
					}
					if (num15 == 4001.0)
					{
						flag10 = true;
					}
					if (num15 == 4002.0)
					{
						flag11 = true;
					}
				}
				if (flag8 && !flag10)
				{
					string text = "This gun is capable against static soft targets but not mobile ones. Not logical.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag8 && flag10)
				{
					string text = "This gun is capable against mobile soft targets but not static ones. Not logical.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (flag9 && !flag11)
				{
					string text = "This gun is capable against static hardened targets but not mobile ones. Not logical.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (!flag9 && flag11)
				{
					string text = "This gun is capable against mobile hardened targets but not static ones. Not logical.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200119", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateTargetTypesForWeapons()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "IlluminationTime" }, (string[])null));
				DataRow? dataRow = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num);
				bool flag = false;
				bool flag2 = false;
				double num3 = Conversions.ToDouble(dataRow["Type"]);
				Conversions.ToDouble(dataRow["SurfacePoK"]);
				Conversions.ToDouble(dataRow["SurfaceRangeMin"]);
				double num4 = Conversions.ToDouble(dataRow["SurfaceRangeMax"]);
				Conversions.ToDouble(dataRow["LandPoK"]);
				Conversions.ToDouble(dataRow["LandRangeMin"]);
				Conversions.ToDouble(dataRow["LandRangeMax"]);
				bool flag3;
				if (num3 != 2001.0 && num3 != 2002.0 && num3 != 2003.0 && num3 != 2004.0 && num3 != 2005.0 && num3 != 2006.0 && num3 != 2007.0 && num3 != 2008.0 && num3 != 2009.0 && num3 != 2010.0 && num3 != 2011.0 && num3 != 2012.0 && num3 != 4001.0 && num3 != 4002.0 && num3 != 4004.0 && num3 != 4005.0 && num3 != 4006.0 && num3 != 4007.0 && num3 != 4008.0 && num3 != 4009.0 && num3 != 4010.0 && num3 != 4011.0 && num3 != 4101.0 && num3 != 5001.0 && num3 != 6001.0 && num3 != 6003.0 && num3 != 8001.0)
				{
					DataRow[] array = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag3 = false;
					DataRow[] array2 = array;
					for (int i = 0; i < array2.Length; i = checked(i + 1))
					{
						if (Conversions.ToDouble(array2[i]["CodeID"]) > 0.0 && !flag3)
						{
							flag3 = true;
							string text = "Target type is not valid for this weapon.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				DataRow[] array3 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				flag3 = false;
				DataRow[] array4 = array3;
				checked
				{
					for (int j = 0; j < array4.Length; j++)
					{
						Conversions.ToDouble(array4[j]["ComponentID"]);
					}
					DataRow[] array5 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag3 = false;
					DataRow[] array6 = array5;
					for (int k = 0; k < array6.Length; k++)
					{
						double num5 = Conversions.ToDouble(array6[k]["CodeID"]);
						if (num5 == 1001.0)
						{
							flag = true;
						}
						if (num5 == 1002.0)
						{
							flag2 = true;
						}
					}
				}
				if ((flag || flag2) && num4 > 25.0)
				{
					string text = "This is a SARH weapon and it has an anti-surface range greater than 25nm. Not logical.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag2 && num2 <= 0L)
				{
					string text = "This weapon uses Terminal Illumination but has no Illumination Time set.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag2 && num2 > 0L)
				{
					string text = "This weapon has the Illumination Time but does not use Terminal Illumination.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200120", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponNames()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (!DataValidateAllInOne.DeprecationImplemented || !Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
					DataRow? dataRow = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num);
					string text = "";
					text = Conversions.ToString(dataRow["Name"]);
					string text2 = Conversions.ToString(dataRow["Comments"]);
					int num2 = Strings.InStr(1, text, "(", (CompareMethod)1);
					int num3 = Strings.InStr(1, text, ")", (CompareMethod)1);
					int num4 = Strings.InStr(1, text, "[", (CompareMethod)1);
					int num5 = Strings.InStr(1, text, "]", (CompareMethod)1);
					int num6 = Strings.InStr(1, text, "{", (CompareMethod)1);
					int num7 = Strings.InStr(1, text, "}", (CompareMethod)1);
					int num8 = Strings.InStr(1, text2, "(", (CompareMethod)1);
					int num9 = Strings.InStr(1, text2, ")", (CompareMethod)1);
					int num10 = Strings.InStr(1, text2, "[", (CompareMethod)1);
					int num11 = Strings.InStr(1, text2, "]", (CompareMethod)1);
					int num12 = Strings.InStr(1, text2, "{", (CompareMethod)1);
					int num13 = Strings.InStr(1, text2, "}", (CompareMethod)1);
					if (num2 > 0 && num3 == 0)
					{
						string text3 = "Found a left \"(\" bracket in the name but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 > 0 && num2 == 0)
					{
						string text3 = "Found a right \")\" bracket in the name but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 > 0 && num5 == 0)
					{
						string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 > 0 && num4 == 0)
					{
						string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 > 0 && num7 == 0)
					{
						string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num14 = 1;
					}
					if (Strings.InStr(num14, text, "|", (CompareMethod)1) > 0)
					{
						string text3 = "Found pipe \"|\" character in the name, there should not be any.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 > 0 && num9 == 0)
					{
						string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 > 0 && num8 == 0)
					{
						string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 > 0 && num11 == 0)
					{
						string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 > 0 && num10 == 0)
					{
						string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 > 0 && num13 == 0)
					{
						string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num15 = 1;
					}
					int num16;
					if (Strings.InStr(num15, text2, "|", (CompareMethod)1) > 0)
					{
						string text3 = "Found pipe \"|\" character in the comments field, there should not be any.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num16 = 1;
					}
					else
					{
						num16 = 1;
					}
					int num17;
					if (!((Strings.InStr(num16, text, "KT ", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "KT)", (CompareMethod)0) > 0)))
					{
						num17 = 1;
					}
					else
					{
						string text3 = "Kiloton should say \"kT\" and not \"KT\" in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num17 = 1;
					}
					int num18;
					if ((Strings.InStr(num17, text, "kt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "kt)", (CompareMethod)0) > 0))
					{
						string text3 = "Kiloton should say \"kT\" and not \"kt\" in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num18 = 1;
					}
					else
					{
						num18 = 1;
					}
					int num19;
					if ((Strings.InStr(num18, text, "mt ", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mt)", (CompareMethod)0) > 0))
					{
						string text3 = "Megaton should say \"mT\" and not \"mt\" in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num19 = 1;
					}
					else
					{
						num19 = 1;
					}
					int num20;
					if ((Strings.InStr(num19, text, "RGB-16MK", (CompareMethod)0) == 0) & ((Strings.InStr(1, text, "mk ", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mk8", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mk5", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mk4", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mk3", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mk2", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "mk1", (CompareMethod)0) > 0)))
					{
						string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num20 = 1;
					}
					else
					{
						num20 = 1;
					}
					int num21;
					if (!((Strings.InStr(num20, text, "RGB-16MK", (CompareMethod)0) == 0) & ((Strings.InStr(1, text, "MK ", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "MK8", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "MK5", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "MK4", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "MK3", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "MK2", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "MK1", (CompareMethod)0) > 0))))
					{
						num21 = 1;
					}
					else
					{
						string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num21 = 1;
					}
					int num22;
					if (!((Strings.InStr(num21, text, "RGB-16MK", (CompareMethod)0) == 0) & ((Strings.InStr(1, text, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "Mk 1", (CompareMethod)0) > 0))))
					{
						num22 = 1;
					}
					else
					{
						string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num22 = 1;
					}
					int num23;
					if (!((Strings.InStr(num22, text, "AGM ", (CompareMethod)0) > 0) | (Strings.InStr(1, text, "AIM ", (CompareMethod)0) > 0)))
					{
						num23 = 1;
					}
					else
					{
						string text3 = "AGM/AIM names should use dashes \"-\" in the name, not spaces.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num23 = 1;
					}
					int num24;
					if (Strings.InStr(num23, text, "  ", (CompareMethod)1) <= 0)
					{
						num24 = 1;
					}
					else
					{
						string text3 = "Found double spaces in the name.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num24 = 1;
					}
					if (Strings.InStr(num24, text2, "  ", (CompareMethod)1) > 0)
					{
						string text3 = "Found double spaces in the comments field.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
			ex2.Data.Add("Error at Validation 200121", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponPropulsion()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			double num14 = default(double);
			bool flag = default(bool);
			bool flag2 = default(bool);
			bool flag3 = default(bool);
			bool flag4 = default(bool);
			bool flag5 = default(bool);
			bool flag6 = default(bool);
			bool flag7 = default(bool);
			bool flag8 = default(bool);
			bool flag9 = default(bool);
			bool flag10 = default(bool);
			bool flag11 = default(bool);
			bool flag12 = default(bool);
			bool flag13 = default(bool);
			bool flag14 = default(bool);
			bool flag15 = default(bool);
			bool flag16 = default(bool);
			double num15 = default(double);
			double num16 = default(double);
			long num17 = default(long);
			double num18 = default(double);
			double num19 = default(double);
			double num22 = default(double);
			double num23 = default(double);
			double num24 = default(double);
			double num25 = default(double);
			double num26 = default(double);
			double num27 = default(double);
			double num28 = default(double);
			double num29 = default(double);
			double num30 = default(double);
			double num31 = default(double);
			double num32 = default(double);
			double num33 = default(double);
			double num34 = default(double);
			double num35 = default(double);
			double num36 = default(double);
			double num37 = default(double);
			double num38 = default(double);
			double num39 = default(double);
			double num40 = default(double);
			double num41 = default(double);
			double num42 = default(double);
			double num43 = default(double);
			double num44 = default(double);
			double num45 = default(double);
			double num46 = default(double);
			double num47 = default(double);
			double num48 = default(double);
			double num49 = default(double);
			double num51 = default(double);
			double num52 = default(double);
			double num53 = default(double);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				double num = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				double num3 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMax" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMin" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude" }, (string[])null));
				double num6 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMax" }, (string[])null));
				double num7 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMin" }, (string[])null));
				double num8 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMax_ASL" }, (string[])null));
				Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMin_ASL" }, (string[])null));
				double num9 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude_ASL" }, (string[])null));
				double num10 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMax_ASL" }, (string[])null));
				Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMin_ASL" }, (string[])null));
				double num11 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "AirPoK" }, (string[])null));
				double num12 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetSpeedMax" }, (string[])null));
				double num13 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetSpeedMin" }, (string[])null));
				DataRow[] array = Common.get_DataWeaponPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					num14 = Conversions.ToDouble(array[i]["ComponentID"]);
					flag = false;
					flag2 = false;
					flag3 = false;
					flag4 = false;
					flag5 = false;
					flag6 = false;
					flag7 = false;
					flag8 = false;
					flag9 = false;
					flag10 = false;
					flag11 = false;
					flag12 = false;
					flag13 = false;
					flag14 = false;
					flag15 = false;
					flag16 = false;
					num15 = 0.0;
					num16 = 0.0;
					num17 = 0L;
					DataRow[] array2 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num14));
					foreach (DataRow obj in array2)
					{
						num18 = Conversions.ToDouble(obj["AltitudeMax"]);
						num19 = Conversions.ToDouble(obj["AltitudeMin"]);
						Conversions.ToDouble(obj["Speed"]);
						double num20 = Conversions.ToDouble(obj["AltitudeBand"]);
						double num21 = Conversions.ToDouble(obj["Throttle"]);
						if (num15 > num19)
						{
							num15 = num19;
						}
						if (num16 < num18)
						{
							num16 = num18;
						}
						if (num20 == 1.0)
						{
							num17++;
							if (num21 == 1.0)
							{
								num22 = num19;
								num23 = num18;
								flag = true;
							}
							else if (num21 == 2.0)
							{
								num24 = num19;
								num25 = num18;
								flag2 = true;
							}
							else if (num21 == 3.0)
							{
								num26 = num19;
								num27 = num18;
								flag3 = true;
							}
							else if (num21 == 4.0)
							{
								num28 = num19;
								num29 = num18;
								flag4 = true;
							}
						}
						else if (num20 == 2.0)
						{
							num17++;
							if (num21 == 1.0)
							{
								num30 = num19;
								num31 = num18;
								flag5 = true;
							}
							else if (num21 == 2.0)
							{
								num32 = num19;
								num33 = num18;
								flag6 = true;
							}
							else if (num21 == 3.0)
							{
								num34 = num19;
								num35 = num18;
								flag7 = true;
							}
							else if (num21 == 4.0)
							{
								num36 = num19;
								num37 = num18;
								flag8 = true;
							}
						}
						else if (num20 == 3.0)
						{
							num17++;
							if (num21 == 1.0)
							{
								num38 = num19;
								num39 = num18;
								flag9 = true;
							}
							else if (num21 == 2.0)
							{
								num40 = num19;
								num41 = num18;
								flag10 = true;
							}
							else if (num21 == 3.0)
							{
								num42 = num19;
								num43 = num18;
								flag11 = true;
							}
							else if (num21 == 4.0)
							{
								num44 = num19;
								num45 = num18;
								flag12 = true;
							}
						}
						else if (num20 == 4.0)
						{
							num17++;
							if (num21 == 1.0)
							{
								num46 = num19;
								flag13 = true;
							}
							else if (num21 == 2.0)
							{
								num47 = num19;
								flag14 = true;
							}
							else if (num21 == 3.0)
							{
								num48 = num19;
								flag15 = true;
							}
							else if (num21 == 4.0)
							{
								num49 = num19;
								flag16 = true;
							}
						}
					}
				}
				if (num2 == 2001L && num18 < 40000.0)
				{
					if (flag && num22 != 0.0)
					{
						string text = "AltitudeBand1 Loiter Speed Minimum Altitude has To be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && flag5 && num23 != 3657.6)
					{
						string text = "AltitudeBand1 Loiter Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && num17 > 1L && num23 > 3657.6)
					{
						string text = "AltitudeBand1 Loiter Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag2 && num24 != 0.0)
					{
						string text = Conversions.ToString(num14) + "AltitudeBand1 Cruise Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag2 && flag6 && num25 != 3657.6)
					{
						string text = "AltitudeBand1 Cruise Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag2 && num17 > 1L && num25 > 3657.6)
					{
						string text = "AltitudeBand1 Cruise Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && num26 != 0.0)
					{
						string text = "AltitudeBand1 Full Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && flag7 && num27 != 3657.6)
					{
						string text = "AltitudeBand1 Full Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && num17 > 1L && num27 > 3657.6)
					{
						string text = "AltitudeBand1 Full Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && num28 != 0.0)
					{
						string text = "AltitudeBand1 Reheat Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && flag8 && num29 != 3657.6)
					{
						string text = "AltitudeBand1 Reheat Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && num17 > 1L && num29 > 3657.6)
					{
						string text = "AltitudeBand1 Flank Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && num30 != 3657.6)
					{
						string text = "AltitudeBand2 Loiter Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && flag9 && num31 != 7315.2)
					{
						string text = "AltitudeBand2 Loiter Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && num17 > 2L && num31 > 7315.2)
					{
						string text = "AltitudeBand2 Loiter Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && num32 != 3657.6)
					{
						string text = "AltitudeBand2 Cruise Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && flag10 && num33 != 7315.2)
					{
						string text = "AltitudeBand2 Cruise Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && num17 > 2L && num33 > 7315.2)
					{
						string text = "AltitudeBand2 Cruise Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && num34 != 3657.6)
					{
						string text = "AltitudeBand2 Full Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && flag11 && num35 != 7315.2)
					{
						string text = "AltitudeBand2 Full Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && num17 > 2L && num35 > 7315.2)
					{
						string text = "AltitudeBand2 Full Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && num36 != 3657.6)
					{
						string text = "AltitudeBand2 Reheat Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && flag12 && num35 != 7315.2)
					{
						string text = "AltitudeBand2 Reheat Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && num17 > 2L && num37 > 7315.2)
					{
						string text = "AltitudeBand4 Flank Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && num38 != 7315.2)
					{
						string text = "AltitudeBand3 Loiter Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && flag13 && num39 != 10972.8)
					{
						string text = "AltitudeBand3 Loiter Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && num17 > 3L && num39 > 10972.8)
					{
						string text = "AltitudeBand3 Loiter Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && num40 != 7315.2)
					{
						string text = "AltitudeBand3 Cruise Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && flag14 && num41 != 10972.8)
					{
						string text = "AltitudeBand3 Cruise Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && num17 > 3L && num41 > 10972.8)
					{
						string text = "AltitudeBand3 Cruise Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num42 != 7315.2)
					{
						string text = "AltitudeBand3 Full Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && flag15 && num43 != 10972.8)
					{
						string text = "AltitudeBand3 Full Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num17 > 3L && num43 > 10972.8)
					{
						string text = "AltitudeBand3 Full Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num44 != 7315.2)
					{
						string text = "AltitudeBand3 Reheat Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && flag16 && num43 != 10972.8)
					{
						string text = "AltitudeBand3 Reheat Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num17 > 3L && num45 > 10972.8)
					{
						string text = "AltitudeBand4 Flank Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num46 != 10972.8)
					{
						string text = "AltitudeBand4 Loiter Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag14 && num47 != 10972.8)
					{
						string text = "AltitudeBand4 Cruise Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 && num48 != 10972.8)
					{
						string text = "AltitudeBand4 Full Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag16 && num49 != 10972.8)
					{
						string text = "AltitudeBand4 Reheat Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 < 0.0)
					{
						num4 = 0.0;
					}
					if (num4 < num15)
					{
						string text = "The weapons minimum launch altitude (" + Conversions.ToString(num4) + "m AGL) is lower than the propulsion systems altitude (" + Conversions.ToString(num15) + "m) AltitudeBands";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 > num16)
					{
						string text = "The weapons maximum launch altitude (" + Conversions.ToString(num3) + "m AGL) is higher than the propulsion systems altitude (" + Conversions.ToString(num16) + "m) AltitudeBands";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 > num16)
					{
						string text = "The weapons maximum launch altitude (" + Conversions.ToString(num8) + "m ASL) is higher than the propulsion systems altitude (" + Conversions.ToString(num16) + "m) AltitudeBands";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 > num16)
					{
						string text = "The weapons cruise altitude (" + Conversions.ToString(num5) + "m AGL) is outside the propulsion systems maximum altitude (" + Conversions.ToString(num16) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num5 < num15)
					{
						string text = "The weapons cruise altitude (" + Conversions.ToString(num5) + "m AGL) is outside the propulsion systems minimum altitude (" + Conversions.ToString(num15) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 > num16)
					{
						string text = "The weapons cruise altitude (" + Conversions.ToString(num9) + "m ASL) is outside the propulsion systems maximum altitude (" + Conversions.ToString(num16) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 < num15)
					{
						string text = "The weapons cruise altitude (" + Conversions.ToString(num9) + "m ASL) is outside the propulsion systems minimum altitude (" + Conversions.ToString(num15) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 > num16)
					{
						string text = "The weapons maximum target altitude (" + Conversions.ToString(num5) + "m AGL) is outside the propulsion systems maximum altitude (" + Conversions.ToString(num16) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 < num15)
					{
						string text = "The weapons minimum target altitude (" + Conversions.ToString(num5) + "m AGL) is outside the propulsion systems minimum altitude (" + Conversions.ToString(num15) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 > num16)
					{
						string text = "The weapons maximum target altitude (" + Conversions.ToString(num10) + "m ASL) is outside the propulsion systems maximum altitude (" + Conversions.ToString(num16) + "m) AltitudeBand";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					double num50 = ((!(num6 > num5)) ? num5 : num6);
					if (num50 < num10)
					{
						num50 = num10;
					}
					if (num50 < num9)
					{
						num50 = num9;
					}
					if (num11 > 0.0)
					{
						if (num18 != num50)
						{
							string text = "Engine Max Altitude is different from Max Weapon Altitude (i.e. Cruise altitude or Target altitude)";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num18 < num3)
						{
							string text = "Engine Max Altitude is lower than Max Launch Altitude";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num13 >= num12 && num12 != 0.0)
						{
							string text = "Target Min Speed cannot be greater or equal to target max speed";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num12 <= 0.0)
						{
							string text = "Target Max Speed must be entered!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if ((num51 > 0.0 || num52 > 0.0) && num11 == 0.0 && num53 == 0.0)
					{
						if (num19 != 0.0)
						{
							string text = "Min Target Aaltitude must be 0 meter for anti-ship/land weapons.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num18 != 0.0)
						{
							string text = "Max Target Aaltitude must be 0 meter for anti-ship/land weapons.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if ((num51 > 0.0 || num52 > 0.0) && num11 > 0.0 && num19 != 0.0)
					{
						string text = "Min Target Aaltitude must be 0 meter for anti-ship/land and anti-air capable weapons.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 4001L || num2 == 4007L || num2 == 4008L)
				{
					if (num7 < num24)
					{
						string text = "Max target depth is deeper than engine depth!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 < num24)
					{
						string text = "Torpedo firing depth may not be deeper that the engine depth!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num24 != num26 && flag3)
					{
						string text = "Torpedo engine minimum depth must be equal for cruise and full throttle!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 < num24)
					{
						string text = "Torpedo engine minimum launch depth is deeper than the torpedo max depth!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 < num24)
					{
						string text = "Torpedo engine minimum target depth is deeper than the torpedo max depth!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 || flag9 || flag13)
					{
						string text = "Torpedo shall one use AltitudeBand 1 only!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 || flag10 || flag14)
					{
						string text = "Torpedo shall one use AltitudeBand 1 only!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 || flag11 || flag15)
					{
						string text = "Torpedo shall one use AltitudeBand 1 only!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 || flag12 || flag16)
					{
						string text = "Torpedo shall one use AltitudeBand 1 only!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4)
					{
						string text = "Torpedo engine may not use Flank speed setting!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200122", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponsHaveCorrectCommGear()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				string text = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Name" }, (string[])null));
				DataRow[] array = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array[i]["ComponentID"]);
					long num4 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num3)["Type"]);
					if (num2 == 2001L && num4 < 10000L)
					{
						string text2 = "Guided Weapons may only have weapon datalink comm types";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 2002L && num2 <= 2999L && num2 != 2012L && num2 != 2007L)
					{
						string text2 = "Unguided weapons, decoys, and training rounds may not have datalinks";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 3001L && num4 < 10000L && Strings.InStr(1, text, "Talon", (CompareMethod)0) == 0)
					{
						string text2 = "Datalink pods may only have weapon datalink comm types";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 3002L && num2 <= 3999L)
					{
						string text2 = "Drop tanks, buddy stores and ferry tanks may not have datalinks";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4001L && (num4 < 8000L || num4 > 8999L))
					{
						string text2 = "Torpedoes may only use wire comm types";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4002L)
					{
						string text2 = "Depth Charges may not have datalinks";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 4003L && (num4 < 9001L || num4 > 9999L))
					{
						string text2 = "Sonobuoys may only sonobuoy comm types";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 >= 4004L)
					{
						string text2 = "Store does not have valid datalink";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
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
			ex2.Data.Add("Error at Validation 20012300003", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateGunCaliberVsAltitudeStats()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				double num2 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				double num3 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SnapUpDownAltitude" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "AirRangeMax" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SurfaceRangeMax" }, (string[])null));
				double num6 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LandRangeMax" }, (string[])null));
				string text = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Name" }, (string[])null));
				string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Comments" }, (string[])null));
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				DataRow[] array = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					double num7 = Conversions.ToDouble(array[i]["CodeID"]);
					if (num7 == 1001.0 || num7 == 1002.0 || num7 == 1003.0 || num7 == 1004.0)
					{
						flag3 = true;
					}
					if (num7 == 3001.0 || num7 == 3002.0 || num7 == 3003.0 || num7 == 3004.0 || num7 == 4001.0 || num7 == 4002.0)
					{
						flag2 = true;
					}
					if (num7 == 2001.0)
					{
						flag = true;
					}
				}
				if (num2 == 2001.0 && flag3 && num3 == 0.0)
				{
					string text3 = "All anti-air missiles need a Snap-Up / Down Altitude.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num2 != 2004.0)
				{
					continue;
				}
				bool flag4 = false;
				DataRow[] array2 = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int j = 0; j < array2.Length; j = checked(j + 1))
				{
					long num8 = Conversions.ToLong(array2[j]["ComponentID"]);
					DataRow? dataRow = Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num8);
					long num9 = Conversions.ToLong(dataRow["ProjectileCaliber"]);
					int num10 = Conversions.ToInteger(dataRow["Type"]);
					bool flag5 = false;
					bool flag6 = false;
					if (num10 == 3002)
					{
						flag6 = true;
					}
					if (num10 == 5002)
					{
						flag5 = true;
					}
					if (flag3 && num9 == 2001L && num3 > 1000.0)
					{
						string text3 = "Gun is 6-15mm, Snap Up Down Altitude should be 1000m or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (!((num9 == 2001L && num4 > 0.2) & (Strings.InStr(1, text, "7.62mm", (CompareMethod)0) > 0)))
					{
						if (num9 == 2001L && num4 > 0.5)
						{
							string text3 = "Gun is 6-15mm, Max Air Range should be 0.5nm or less.";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
					}
					else
					{
						string text3 = "Gun is 7.62mm, Max Air Range should be 0.2nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (!((num9 == 2001L && num5 > 0.6) & (Strings.InStr(1, text, "7.62mm", (CompareMethod)0) > 0) & (Strings.InStr(1, text2, "Gunship", (CompareMethod)0) < 1)))
					{
						if ((num9 == 2001L && num5 > 1.0) & (Strings.InStr(1, text2, "Gunship", (CompareMethod)0) < 1))
						{
							string text3 = "Gun is 6-15mm, Max Surface Range should be 1nm or less.";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
					}
					else
					{
						string text3 = "Gun is 7.62mm, Max Surface Range should be 0.6nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if ((num9 == 2001L && num6 > 0.6) & (Strings.InStr(1, text, "7.62mm", (CompareMethod)0) > 0) & (Strings.InStr(1, text2, "Gunship", (CompareMethod)0) < 1))
					{
						string text3 = "Gun is 7.62mm, Max Land Range should be 0.6nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					else if ((num9 == 2001L && num6 > 1.0) & (Strings.InStr(1, text2, "Gunship", (CompareMethod)0) < 1))
					{
						string text3 = "Gun is 6-15mm, Max Land Range should be 1nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2002L && num3 > 1500.0)
					{
						string text3 = "Gun is 16-24mm, Snap Up Down Altitude should be 1500m or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 2002L && num4 > 0.8)
					{
						string text3 = "Gun is 16-24mm, Max Air Range should be 0.8nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2003L && num3 > 2500.0)
					{
						string text3 = "Gun is 25-60mm, Snap Up Down Altitude should be 2500m or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (!((num9 == 2003L && num4 > 0.8) & (Strings.InStr(1, text, "25mm", (CompareMethod)0) > 0)))
					{
						if ((num9 == 2003L && num4 > 0.8) & (Strings.InStr(1, text, "27mm", (CompareMethod)0) > 0))
						{
							string text3 = "Gun is 27mm, Max Air Range should be 0.8nm or less.";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
						else if (!((num9 == 2003L && num4 > 1.0) & (Strings.InStr(1, text, "30mm", (CompareMethod)0) > 0)))
						{
							if ((num9 == 2003L && num4 > 1.0) & (Strings.InStr(1, text, "35mm", (CompareMethod)0) > 0))
							{
								string text3 = "Gun is 35mm, Max Air Range should be 1.0nm or less.";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
							else if (num9 == 2003L && num4 > 1.2)
							{
								string text3 = "Gun is 25-60mm, Max Air Range should be 1.2nm or less.";
								object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
							}
						}
						else
						{
							string text3 = "Gun is 30mm, Max Air Range should be 0.8nm or less.";
							object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						}
					}
					else
					{
						string text3 = "Gun is 25mm, Max Air Range should be 0.8nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2004L && num3 > 3000.0)
					{
						string text3 = "Gun is 61-80mm, Snap Up Down Altitude should be 3000m or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 2004L && num4 > 1.5)
					{
						string text3 = "Gun is 61-80mm, Max Air Range should be 1.5nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2005L && num3 > 3000.0)
					{
						string text3 = "Gun is 81-150mm, Snap Up Down Altitude should be 3000m or less";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 2005L && num4 > 1.8)
					{
						string text3 = "Gun is 81-150mm, Max Air Range should be 1.8nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2006L && num3 > 3000.0)
					{
						string text3 = "Gun is 151-200mm, Snap Up Down Altitude should be 3000m or less";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 2006L && num4 > 1.5)
					{
						string text3 = "Gun is 151-200mm, Max Air Range should be 1.5nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2007L && num3 > 3000.0)
					{
						string text3 = "Gun is 201-350mm, Snap Up Down Altitude should be 3000m or less";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 2007L && num4 > 1.5)
					{
						string text3 = "Gun is 201-350mm, Max Air Range should be 1.5nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (flag3 && num9 == 2008L && num3 > 3000.0)
					{
						string text3 = "Gun is 351-450mm, Snap Up Down Altitude should be 3000m or less";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 2008L && num4 > 1.5)
					{
						string text3 = "Gun is 351-450mm, Max Air Range should be 1.5nm or less.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 == 1001L && !flag6 && !flag5)
					{
						string text3 = "Weapon is a gun but no Gun Caliber is for the warhead.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					if (num9 > 3000L)
					{
						string text3 = "Weapon is a gun, however a Rocket Caliber is for the warhead. Makes no sense.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
					}
					int num11;
					if (!flag4)
					{
						num11 = 1;
					}
					else
					{
						string text3 = "Guns should NOT have more than one warhead.";
						object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
						num11 = 1;
					}
					flag4 = (byte)num11 != 0;
				}
				if (!flag3 && num3 != 0.0)
				{
					string text3 = "Only anti-air capable weapons may have Snap-Up/Down value set!";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num5 < num4 && flag && flag3)
				{
					string text3 = "Gun anti-air range is greater or equal to anti-surface range, which makes no sense.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
				if (num6 < num4 && flag2 && flag3)
				{
					string text3 = "Gun anti-air range is greater or equal to anti-Land range, which makes no sense.";
					object obj = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(Conversions.ToString(obj));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200124", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponsLegalTargetsVsSensorAndIlluminatorCapabilities()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			bool flag24 = default(bool);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				if (!(num2 == 2001L || num2 == 2002L || num2 == 2003L || num2 == 2004L || num2 == 4001L || num2 == 5001L))
				{
					continue;
				}
				DataRow[] array = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				DataRow[] array2 = array;
				bool flag14;
				bool flag15;
				bool flag16;
				long num5;
				DataRow[] array6;
				checked
				{
					for (int i = 0; i < array2.Length; i++)
					{
						long num3 = Conversions.ToLong(array2[i]["CodeID"]);
						if (num3 == 1001L)
						{
							flag = true;
						}
						if (num3 == 1002L)
						{
							flag2 = true;
						}
						if (num3 == 1003L)
						{
							flag3 = true;
						}
						if (num3 == 1004L)
						{
							flag4 = true;
						}
						if (num3 == 2001L)
						{
							flag5 = true;
						}
						if (num3 == 2002L)
						{
							flag6 = true;
						}
						if (num3 == 2004L)
						{
							flag13 = true;
						}
						if (num3 == 3001L)
						{
							flag7 = true;
						}
						if (num3 == 3002L)
						{
							flag8 = true;
						}
						if (num3 == 3003L)
						{
							flag9 = true;
						}
						if (num3 == 3004L)
						{
							flag10 = true;
						}
						if (num3 == 4001L)
						{
							flag11 = true;
						}
						if (num3 == 4002L)
						{
							flag12 = true;
						}
					}
					DataRow[] array3 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag14 = false;
					flag15 = false;
					flag16 = false;
					DataRow[] array4 = array3;
					for (int j = 0; j < array4.Length; j++)
					{
						long num4 = Conversions.ToLong(array4[j]["CodeID"]);
						if (num4 == 6101L)
						{
							flag15 = true;
						}
						if (num4 == 6102L)
						{
							flag14 = true;
						}
						if (num4 == 6103L)
						{
							flag16 = true;
						}
					}
					DataRow[] array5 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					bool flag17 = false;
					num5 = 0L;
					array6 = array5;
				}
				for (int k = 0; k < array6.Length; k = checked(k + 1))
				{
					double num6 = Conversions.ToDouble(array6[k]["ComponentID"]);
					bool flag18 = false;
					bool flag19 = false;
					bool flag20 = false;
					bool flag21 = false;
					bool flag22 = false;
					bool flag23 = false;
					flag24 = false;
					bool flag25 = false;
					long num7 = Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num6)["Type"]);
					if (num7 == 3001L)
					{
						flag24 = true;
					}
					if (num7 == 3002L)
					{
						flag25 = true;
					}
					if (num7 == 9001L)
					{
						string text = "Weapons may NOT have sensor groups as seekers! (Sensor ID: " + Conversions.ToString(num6) + ")";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag25)
					{
						continue;
					}
					bool flag17 = true;
					num5++;
					DataRow[] array7 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
					for (int l = 0; l < array7.Length; l = checked(l + 1))
					{
						long num8 = Conversions.ToLong(array7[l]["CodeID"]);
						if (num8 == 1001L)
						{
							flag18 = true;
						}
						if (num8 == 1002L)
						{
							flag19 = true;
						}
						if (num8 == 1003L)
						{
							flag20 = true;
						}
						if (num8 == 1004L)
						{
							flag21 = true;
						}
						if (num8 == 1005L)
						{
							flag22 = true;
						}
						if (num8 == 1011L)
						{
							flag23 = true;
						}
					}
					if (!flag24)
					{
						if ((flag || flag2 || flag3 || flag4) && !flag18 && !flag23 && flag17 && !flag24)
						{
							string text = "Weapon is capable against air targets but seeker " + Conversions.ToString(num6) + " is not Air Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag && !flag2 && !flag3 && !flag4 && (flag18 || flag23) && flag17)
						{
							string text = "Weapon is not capable against air targets but seeker " + Conversions.ToString(num6) + " is Air Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag5 && !flag19 && flag17 && !flag24 && !flag25 && !(flag && flag5 && num7 == 2004L))
						{
							string text = "Weapon is capable against ship targets but seeker " + Conversions.ToString(num6) + " is not Surface Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag5 && flag19 && flag17)
						{
							string text = "Weapon is not capable against ship targets but seeker " + Conversions.ToString(num6) + " is Surface Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num2 != 2001L && flag6 && !flag13 && !flag20 && flag17)
						{
							string text = "Weapon is capable against submarine targets but seeker " + Conversions.ToString(num6) + " is not Submarine Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag6 && flag20 && flag17)
						{
							string text = "Weapon is not capable against submarine targets but seeker " + Conversions.ToString(num6) + " is Submarine Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((flag7 || flag8) && !flag21 && !flag14 && !flag15 && !flag16 && flag17)
						{
							string text = "Weapon is capable against land structures but seeker " + Conversions.ToString(num6) + " is not Land Search - Fixed Facility Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag7 && !flag8 && flag21 && !flag14 && !flag15 && !flag16 && flag17)
						{
							string text = "Weapon is not capable against land structures but seeker " + Conversions.ToString(num6) + " is Land Search - Fixed Facility Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((flag11 || flag12) && !flag22 && flag17 && !flag24 && !flag25)
						{
							string text = "Weapon is capable against land structures but seeker " + Conversions.ToString(num6) + " is not Land Search - Mobile Unit Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag11 && !flag12 && flag22 && flag17)
						{
							string text = "Weapon is not capable against land structures but seeker " + Conversions.ToString(num6) + " is Land Search - Mobile Unit Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag9 && !flag21 && flag17 && !flag14)
						{
							string text = "Weapon is capable against runways but seeker " + Conversions.ToString(num6) + " is not Land Search - Fixed Facility Search Capable. Makes no sense!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				if (flag10 && !flag24)
				{
					string text = "Weapon is capable against radars but there is no ESM seeker present. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag10 && !flag && flag24 && num5 == 1L)
				{
					string text = "Weapon is not capable against radars but primary sensor is ESM. Makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				DataRow[] array8 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag26 = false;
				bool flag27 = false;
				bool flag28 = false;
				bool flag29 = false;
				bool flag30 = false;
				bool flag31 = false;
				bool flag32 = false;
				DataRow[] array9 = array8;
				for (int m = 0; m < array9.Length; m = checked(m + 1))
				{
					int num9 = Conversions.ToInteger(array9[m]["ComponentID"]);
					flag26 = true;
					DataRow[] array10 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num9));
					for (int n = 0; n < array10.Length; n = checked(n + 1))
					{
						long num10 = Conversions.ToLong(array10[n]["CodeID"]);
						if (num10 == 1001L)
						{
							flag27 = true;
						}
						if (num10 == 1002L)
						{
							flag28 = true;
						}
						if (num10 == 1003L)
						{
							flag29 = true;
						}
						if (num10 == 1004L)
						{
							flag30 = true;
						}
						if (num10 == 1005L)
						{
							flag31 = true;
						}
						if (num10 == 1011L)
						{
							flag32 = true;
						}
					}
					if (Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num9)["Type"]) == 9001L)
					{
						string text = "Weapons may NOT have sensor groups as illuminators! (Sensor ID: " + Conversions.ToString(num9) + ")";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 != 4001L && (flag || flag2 || flag3) && !flag27 && !flag32 && flag26)
					{
						string text = "Weapon is capable against air targets but Illuminator " + Conversions.ToString(num9) + " is not Air Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && !flag28 && flag26 && num2 != 2004L)
					{
						string text = "Weapon is capable against ship targets but Illuminator " + Conversions.ToString(num9) + " is not Surface Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && !flag29 && flag26)
					{
						string text = "Weapon is capable against submarine targets but Illuminator " + Conversions.ToString(num9) + " is not Submarine Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag7 || flag8) && !flag30 && flag26 && num2 != 2004L)
					{
						string text = "Weapon is capable against land structures but Illuminator " + Conversions.ToString(num9) + " is not Land Search - Fixed Facility Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag11 || flag12) && !flag31 && flag26 && num2 != 2004L)
					{
						string text = "Weapon is capable against land structures but Illuminator " + Conversions.ToString(num9) + " is not Land Search - Mobile Unit Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && !flag30 && flag26 && num2 != 2004L)
					{
						string text = "Weapon is capable against runways but Illuminator " + Conversions.ToString(num9) + " is not Land Search - Fixed Facility Search Capable. Makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 != 2001L && flag26)
				{
					string text = "Only weapons of type Guided Weapon may have Illuminators!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200125", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateWeaponsLegalTargetsVsWarheadCapabilities()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				DataRow[] array = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array2[i]["CodeID"]);
					flag14 = true;
					if (num3 == 1001L)
					{
						flag = true;
					}
					if (num3 == 1002L)
					{
						flag2 = true;
					}
					if (num3 == 1003L)
					{
						flag3 = true;
					}
					if (num3 == 1004L)
					{
						flag4 = true;
					}
					if (num3 == 2001L)
					{
						flag5 = true;
					}
					if (num3 == 2002L || num3 == 2004L)
					{
						flag6 = true;
					}
					if (num3 == 3001L)
					{
						flag7 = true;
					}
					if (num3 == 3002L)
					{
						flag8 = true;
					}
					if (num3 == 3003L)
					{
						flag9 = true;
					}
					if (num3 == 3004L)
					{
						flag10 = true;
					}
					if (num3 == 4001L)
					{
						flag11 = true;
					}
					if (num3 == 4002L)
					{
						flag12 = true;
					}
				}
				bool flag15 = false;
				bool flag16 = false;
				bool flag17 = false;
				bool flag18 = false;
				bool flag19 = false;
				bool flag20 = false;
				bool flag21 = false;
				bool flag22 = false;
				bool flag23 = false;
				bool flag24 = false;
				DataRow[] array3 = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int j = 0; j < array3.Length; j = checked(j + 1))
				{
					long num4 = Conversions.ToLong(array3[j]["ComponentID"]);
					flag13 = true;
					long num5 = Conversions.ToLong(Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]);
					if (num5 == 2001L)
					{
						flag16 = true;
						flag15 = true;
						flag18 = true;
						flag20 = true;
						flag22 = true;
						flag21 = true;
						flag17 = true;
					}
					if (num5 == 2002L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag18 = true;
						flag24 = true;
						flag19 = true;
					}
					if (num5 == 2003L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag18 = true;
					}
					if (num5 == 2004L)
					{
						flag16 = true;
						flag20 = true;
					}
					if (num5 == 2005L)
					{
						flag16 = true;
						flag18 = true;
						flag24 = true;
						flag20 = true;
						flag22 = true;
					}
					if (num5 == 2006L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag22 = true;
						flag17 = true;
					}
					if (num5 == 2007L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
					}
					if (num5 == 2008L || num5 == 2012L)
					{
						flag18 = true;
						flag24 = true;
						flag20 = true;
					}
					if (num5 == 2009L)
					{
						flag17 = true;
						flag16 = true;
						flag15 = true;
						flag20 = true;
					}
					if (num5 == 2010L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag22 = true;
					}
					if (num5 == 2011L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag22 = true;
					}
					if (num5 == 2012L)
					{
						flag16 = true;
						flag18 = true;
						flag24 = true;
						flag19 = true;
						flag22 = true;
					}
					if (num5 == 3001L)
					{
						flag20 = true;
						flag21 = true;
					}
					if (num5 == 3002L)
					{
						flag21 = true;
					}
					if (num5 == 4001L)
					{
						flag16 = true;
						flag15 = true;
						flag19 = true;
						flag20 = true;
						flag22 = true;
						flag18 = true;
						flag24 = true;
						flag21 = true;
						flag17 = true;
					}
					if (num5 == 4011L)
					{
						flag16 = true;
						flag20 = true;
					}
					if (num5 == 4021L)
					{
						flag16 = true;
						flag20 = true;
					}
					if (num5 == 5002L)
					{
						flag23 = true;
					}
					if (num5 == 6001L)
					{
						flag15 = true;
						flag16 = true;
						flag17 = true;
						flag18 = true;
						flag19 = true;
						flag20 = true;
						flag21 = true;
						flag22 = true;
					}
					if (num5 == 6001L)
					{
						flag16 = true;
						flag20 = true;
					}
					if (num5 == 6002L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag22 = true;
					}
					if (num5 == 6003L)
					{
						flag17 = true;
						flag20 = true;
						flag22 = true;
						flag15 = true;
						flag16 = true;
					}
					if (num5 == 6012L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag22 = true;
					}
					if (num5 == 7001L)
					{
						flag16 = true;
						flag20 = true;
					}
					if (num5 == 7002L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag22 = true;
					}
					if (num5 == 8001L)
					{
						flag18 = true;
						flag16 = true;
						flag15 = true;
						flag20 = true;
					}
					if (num5 == 9001L)
					{
						flag16 = true;
					}
					if (num5 == 9002L)
					{
						flag16 = true;
						flag15 = true;
					}
					if (num5 == 9101L || num5 == 9102L || num5 == 9103L || num5 == 9104L)
					{
						flag18 = true;
						flag20 = true;
					}
					if (num5 == 9201L || num5 == 9202L)
					{
						flag16 = true;
						flag15 = true;
						flag20 = true;
						flag17 = true;
					}
				}
				if (!flag23)
				{
					if (num2 == 2001L && (flag || flag2 || flag3) && !flag24)
					{
						string text = "Weapon is anti-air and should use Continous Rod or Frag warhead to be considered High-Grade AAW weapons in sim!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag13 && flag14 && num2 != 2005L && num2 != 2006L && num2 != 2007L && num2 != 4101L)
					{
						string text = "Weapon has no warhead but lists target types!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && !flag14)
					{
						string text = "Weapon has warhead but no legal targets!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag || flag2 || flag3) && !flag18 && flag13 && flag14)
					{
						string text = "Weapon is capable against air targets but warhead type is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && !flag19 && flag13 && flag14)
					{
						string text = "Weapon is capable against satellite targets but warhead type is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && !flag20 && flag13 && flag14)
					{
						string text = "Weapon is capable against ship targets but warhead type is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && !flag21 && flag13 && flag14)
					{
						string text = "Weapon is capable against submarine targets but warhead type is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && !flag17 && flag13 && flag14)
					{
						string text = "Weapon is capable against runway targets but warhead type is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && !flag22 && flag13 && flag14)
					{
						string text = "Weapon is capable against radar targets but warhead type is not valid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 || flag8 || flag11 || flag12)
					{
						if (flag7 && !flag16 && flag13 && flag14)
						{
							string text = "Weapon is capable against soft land structures but warhead type is not valid!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag11 && !flag16 && flag13 && flag14)
						{
							string text = "Weapon is capable against soft mobile targets but warhead type is not valid!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag8 && !flag15 && flag13 && flag14)
						{
							string text = "Weapon is capable against hardened land structures but warhead type is not valid!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag12 && !flag15 && flag13 && flag14)
						{
							string text = "Weapon is capable against hardened mobile targets but warhead type is not valid!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				if (!flag13 && (num2 == 2001L || num2 == 2002L || num2 == 2003L || num2 == 2004L || num2 == 2009L || num2 == 4001L || num2 == 4002L || num2 == 4004L || num2 == 4005L || num2 == 4006L || num2 == 4007L || num2 == 4008L || num2 == 4009L || num2 == 5001L || num2 == 6001L))
				{
					string text = "Weapon must have a warhead!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag13 && (num2 == 1001L || num2 == 2005L || num2 == 2006L || num2 == 2007L || num2 == 3002L || num2 == 3003L || num2 == 3004L || num2 == 4003L || num2 == 9001L || num2 == 9002L || num2 == 9003L))
				{
					string text = "Weapon must not have a warhead!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200127", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAllSensorsonWeaponsAreCapableVsSameTargets()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
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
				bool flag19 = false;
				DataRow[] array = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag20 = true;
				bool flag21 = true;
				DataRow[] array2 = array;
				foreach (DataRow obj in array2)
				{
					long num3 = Conversions.ToLong(obj["ComponentID"]);
					Conversions.ToLong(obj["ComponentNumber"]);
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
					bool flag37 = false;
					bool flag38 = false;
					bool flag39 = false;
					bool flag40 = false;
					long num4 = Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num3)["Type"]);
					DataRow[] array3 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					for (int j = 0; j < array3.Length; j = checked(j + 1))
					{
						long num5 = Conversions.ToLong(array3[j]["CodeID"]);
						if (flag20 && (num4 == 2003L || num4 == 2004L || num4 == 4001L || num4 == 4002L || num4 == 4003L))
						{
							if (num5 == 1001L)
							{
								flag = true;
							}
							if (num5 == 1002L)
							{
								flag2 = true;
							}
							if (num5 == 1003L)
							{
								flag3 = true;
							}
							if (num5 == 1004L)
							{
								flag4 = true;
							}
							if (num5 == 1005L)
							{
								flag5 = true;
							}
							if (num5 == 1011L)
							{
								flag6 = true;
							}
							if (num5 == 1021L)
							{
								flag7 = true;
							}
							if (num5 == 2002L)
							{
								flag9 = true;
							}
							if (num5 == 2003L)
							{
								flag10 = true;
							}
						}
						if (!flag20 && (num4 == 2003L || num4 == 2004L || num4 == 4001L || num4 == 4002L || num4 == 4003L))
						{
							if (num5 == 1001L)
							{
								flag22 = true;
							}
							if (num5 == 1002L)
							{
								flag23 = true;
							}
							if (num5 == 1003L)
							{
								flag24 = true;
							}
							if (num5 == 1004L)
							{
								flag25 = true;
							}
							if (num5 == 1005L)
							{
								flag26 = true;
							}
							if (num5 == 1011L)
							{
								flag27 = true;
							}
							if (num5 == 1021L)
							{
								flag28 = true;
							}
							if (num5 == 2002L)
							{
								flag30 = true;
							}
							if (num5 == 2003L)
							{
								flag31 = true;
							}
						}
						if (flag21 && num4 == 2001L)
						{
							if (num5 == 1001L)
							{
								flag12 = true;
							}
							if (num5 == 1002L)
							{
								flag13 = true;
							}
							if (num5 == 1004L)
							{
								flag14 = true;
							}
							if (num5 == 1005L)
							{
								flag15 = true;
							}
							if (num5 == 2001L)
							{
								flag16 = true;
							}
							if (num5 == 2002L)
							{
								flag17 = true;
							}
							if (num5 == 2003L)
							{
								flag18 = true;
							}
							if (num5 == 2004L)
							{
								flag19 = true;
							}
						}
						if (!flag21 && num4 == 2001L)
						{
							if (num5 == 1001L)
							{
								flag33 = true;
							}
							if (num5 == 1002L)
							{
								flag34 = true;
							}
							if (num5 == 1004L)
							{
								flag35 = true;
							}
							if (num5 == 1005L)
							{
								flag36 = true;
							}
							if (num5 == 2001L)
							{
								flag37 = true;
							}
							if (num5 == 2002L)
							{
								flag38 = true;
							}
							if (num5 == 2003L)
							{
								flag39 = true;
							}
							if (num5 == 2004L)
							{
								flag40 = true;
							}
						}
					}
					bool flag41 = false;
					bool flag42 = false;
					bool flag43 = false;
					if (flag22 && !flag23 && !flag24 && !flag25 && !flag26 && !flag27 && !flag28)
					{
						flag42 = true;
					}
					if (flag && !flag2 && !flag3 && !flag4 && !flag5 && !flag6 && !flag7)
					{
						flag41 = true;
					}
					if ((flag42 || flag41) && num2 == 3001L)
					{
						flag43 = true;
					}
					if (!flag20 && (num4 == 2003L || num4 == 2004L || num4 == 4001L || num4 == 4002L || num4 == 4003L))
					{
						if (flag22 && !flag && !flag43)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Air Search capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag22 && flag)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Air Search capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag23 && !flag2)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Surface Search capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag23 && flag2 && !flag43)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Surface Search capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag24 && !flag3)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Submarine Search capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag24 && flag3)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Submarine Search capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag25 && !flag4)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Land Search - Fixed Facility capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag25 && flag4 && !flag43)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Land Search - Fixed Facility capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag26 && !flag5)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Land Search - Mobile Unit capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag26 && flag5 && !flag43)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Land Search - Mobile Unit capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag29 && !flag8)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Range Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag29 && flag8)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Range Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag30 && !flag9)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Altitude Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag30 && flag9)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Altitude Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag31 && !flag10)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Speed Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag31 && flag10)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Speed Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag32 && !flag11)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Heading Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag32 && flag11)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Heading Information capability while other IR/Visual/Laser sensors on the weapon or sensor pod are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (!flag21 && num4 == 2001L)
					{
						if (flag33 && !flag12)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Air Search capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag33 && flag12)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Air Search capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag34 && !flag13)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Surface Search capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag34 && flag13)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Surface Search capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag35 && !flag14)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Land Search - Fixed Facility capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && flag14)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Land Search - Fixed Facility capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag36 && !flag15)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Land Search - Mobile Unit capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag36 && flag15)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Land Search - Mobile Unit capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag37 && !flag16)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Range Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag37 && flag16)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Range Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag38 && !flag17)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Altitude Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag39 && flag18)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Speed Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag40 && !flag19)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " has Heading Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag40 && flag19)
						{
							string text = "Weapon Sensor " + Conversions.ToString(num3) + " lacks Heading Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag20 && (num4 == 2003L || num4 == 2004L || num4 == 4001L || num4 == 4002L || num4 == 4003L))
					{
						flag20 = false;
					}
					if (flag21 && num4 == 2001L)
					{
						flag21 = false;
					}
				}
				if (!flag21 && !flag20)
				{
					if (!flag && flag12)
					{
						string text = "Grouped IR/Visual/Laser Sensor lacks Air Search capability while other radar sensors in the group are capable. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && !flag12)
					{
						string text = "Grouped IR/Visual/Laser Sensor has Air Search capability while a radar in the group is not. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200128", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSpecialTorpedoStats()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			double num32 = default(double);
			double num33 = default(double);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				double num3 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMax" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMin" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMax" }, (string[])null));
				double num6 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMin" }, (string[])null));
				double num7 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude" }, (string[])null));
				double num8 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMax_ASL" }, (string[])null));
				double num9 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LaunchAltitudeMin_ASL" }, (string[])null));
				double num10 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMax_ASL" }, (string[])null));
				double num11 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TargetAltitudeMin_ASL" }, (string[])null));
				double num12 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "CruiseAltitude_ASL" }, (string[])null));
				double num13 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoSpeedCruise" }, (string[])null));
				double num14 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoRangeCruise" }, (string[])null));
				double num15 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoSpeedFull" }, (string[])null));
				double num16 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "TorpedoRangeFull" }, (string[])null));
				if (!(num2 == 4001L || num2 == 4007L))
				{
					continue;
				}
				double num17 = ((num3 == 0.0 && num8 == 0.0) ? 0.0 : ((num3 != 0.0 && num8 == 0.0) ? num3 : ((num3 == 0.0 && num8 != 0.0) ? num8 : ((!(num3 > num8)) ? num8 : num3))));
				double num18 = ((num4 == 0.0 && num9 == 0.0) ? 0.0 : ((num4 != 0.0 && num9 == 0.0) ? num4 : ((num4 == 0.0 && num9 != 0.0) ? num9 : ((!(num4 > num9)) ? num9 : num4))));
				double num19 = ((num5 == 0.0 && num10 == 0.0) ? 0.0 : ((num5 != 0.0 && num10 == 0.0) ? num5 : ((num5 == 0.0 && num10 != 0.0) ? num10 : ((!(num5 > num10)) ? num10 : num5))));
				double num20 = ((num6 == 0.0 && num11 == 0.0) ? 0.0 : ((num6 != 0.0 && num11 == 0.0) ? num6 : ((num6 == 0.0 && num11 != 0.0) ? num11 : ((!(num6 > num11)) ? num11 : num6))));
				if ((num7 == 0.0 && num12 == 0.0) || (num7 != 0.0 && num12 == 0.0) || !(num7 == 0.0 && num12 != 0.0))
				{
				}
				DataRow? dataRow = Common.get_MiscWeapon(Common.mySourceDB_Helper).Rows.Find(num);
				double num21 = Conversions.ToDouble(dataRow["LaunchAltitudeMaxFeet"]);
				double num22 = Conversions.ToDouble(dataRow["LaunchAltitudeMinFeet"]);
				double num23 = Conversions.ToDouble(dataRow["TargetAltitudeMaxFeet"]);
				double num24 = Conversions.ToDouble(dataRow["TargetAltitudeMinFeet"]);
				double num25 = Conversions.ToDouble(dataRow["CruiseAltitudeFeet"]);
				long num26 = Conversions.ToLong(Common.get_DataWeaponPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num))[0]["ComponentID"]);
				bool flag = false;
				DataRow[] array = Common.get_DataWeaponPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				long num27 = 0L;
				DataRow[] array2 = array;
				bool flag2;
				bool flag3;
				bool flag4;
				bool flag5;
				checked
				{
					for (int i = 0; i < array2.Length; i++)
					{
						long num28 = Conversions.ToLong(array2[i]["ComponentID"]);
						num27 = Conversions.ToLong(Common.get_DataPropulsion(Common.mySourceDB_Helper).Rows.Find(num28)["Type"]);
					}
					if (num27 == 3004L)
					{
						flag = true;
					}
					DataRow[] array3 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num26));
					flag2 = false;
					flag3 = false;
					DataRow[] array4 = array3;
					foreach (DataRow obj in array4)
					{
						double num29 = Conversions.ToDouble(obj["Speed"]);
						double num30 = Conversions.ToDouble(obj["AltitudeBand"]);
						double num31 = Conversions.ToDouble(obj["Throttle"]);
						if (num30 == 1.0)
						{
							if (num31 == 2.0)
							{
								num32 = num29;
								flag2 = true;
							}
							else if (num31 == 3.0)
							{
								num33 = num29;
								flag3 = true;
							}
						}
					}
					DataRow[] array5 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag4 = false;
					flag5 = false;
					DataRow[] array6 = array5;
					for (int k = 0; k < array6.Length; k++)
					{
						long num34 = Conversions.ToLong(array6[k]["CodeID"]);
						if (num34 == 2001L)
						{
							flag4 = true;
						}
						if (num34 == 2002L)
						{
							flag5 = true;
						}
					}
					if (num32 != num13 && !flag)
					{
						string text = "Torpedo on-weapon Cruise Speed is different from the engine cruise speed!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num33 != num15 && flag3)
				{
					string text = "Torpedo on-weapon Full Speed is different from the engine full speed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 != 0.0 && !flag3)
				{
					string text = "Torpedo engine has Full Speed setting but no Full Speed value given on the weapon!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 == 0.0 && flag3)
				{
					string text = "Torpedo engine has Full Speed setting on engine but no Full Speed value given on the weapon!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag2)
				{
					string text = "Torpedo has no Cruise speed on the engine!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 == 0.0 && !flag)
				{
					string text = "Torpedo has no default cruise range specified on the weapon itself!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 == 0.0 && !flag)
				{
					string text = "Torpedo has no default cruise speed specified on the weapon itself!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 != 0.0 && num16 == 0.0)
				{
					string text = "Torpedo has default Full speed but no default cruise range!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 == 0.0 && num16 != 0.0)
				{
					string text = "Torpedo has default Full range but no default cruise speed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num21 < 0.0)
				{
					string text = "Torpedo max launch depth in FEET must be to 0! User METER field instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num25 != 0.0)
				{
					string text = "Torpedo Cruise Altitude in FEET must be to 0! User METER field instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num22 < 0.0)
				{
					string text = "Torpedo min launch depth in FEET must be to 0! User METER field instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num23 != 0.0)
				{
					string text = "Torpedo max target altitude in FEET must be to 0! User METER field instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num24 != 0.0)
				{
					string text = "Torpedo min target altitude in FEET must be to 0! User METER field instead.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num18 > num17 && flag5)
				{
					string text = "Minimum launch depth can not be greater or equal to Maximum launch depth!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num20 > num19 && flag5)
				{
					string text = "Minimum target depth can not be greater or equal to Maximum target depth!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag4 && !flag5 && num20 != 0.0)
				{
					string text = "Torpedo is pure anti-ship, Minimum Target Depth must be 0!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag4 && !flag5 && num19 != 0.0)
				{
					string text = "Torpedo is pure anti-ship, Maximum Target Depth must be 0!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag5 && num20 >= 0.0)
				{
					string text = "Torpedo is anti-submarine, Minimum Target Depth must be less than 0!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag4 && flag5 && num10 >= 0.0)
				{
					string text = "Torpedo is pure anti-submarine, Maximum Target Depth must be less than 0!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200129", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void smethod_0()
	{
		try
		{
			DataTable dataTable = Common.get_DataWeapon(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				if (DataValidateAllInOne.DeprecationImplemented && Conversions.ToBoolean(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Deprecated" }, (string[])null)))
				{
					continue;
				}
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				long num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				double num3 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "AirRangeMax" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SurfaceRangeMax" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "LandRangeMax" }, (string[])null));
				double num6 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "SubsurfaceRangeMax" }, (string[])null));
				bool flag = false;
				DataRow[] array = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					if (Conversions.ToInteger(array[i]["CodeID"]) == 6111)
					{
						flag = true;
					}
				}
				if (num2 >= 2001L && num2 <= 2012L && num2 != 4001L && num2 != 4002L && num2 >= 4004L && num2 <= 4011L && num2 != 4101L && num2 != 5001L && num2 != 6001L && num2 != 6003L && num2 != 8001L)
				{
					DataRow[] array2 = Common.get_DataWeaponWRA(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					bool flag2 = false;
					DataRow[] array3 = array2;
					for (int j = 0; j < array3.Length; j = checked(j + 1))
					{
						if (Conversions.ToDouble(array3[j]["CodeID"]) > 0.0 && !flag2)
						{
							flag2 = true;
							string text = "Commanders Guidance Target type is not valid for this weapon.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				if (!(num2 != 4004L && num2 != 4005L && num2 != 4006L && num2 != 4007L && num2 != 4008L && num2 != 4009L && num2 != 4010L && num2 != 4011L))
				{
					continue;
				}
				DataRow[] array4 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				bool flag19 = false;
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
				bool flag37 = false;
				bool flag38 = false;
				bool flag39 = false;
				bool flag40 = false;
				bool flag41 = false;
				DataRow[] array5 = array4;
				for (int k = 0; k < array5.Length; k = checked(k + 1))
				{
					long num7 = Conversions.ToLong(array5[k]["CodeID"]);
					if (num7 == 1001L)
					{
						flag3 = true;
					}
					if (num7 == 1002L)
					{
						flag4 = true;
					}
					if (num7 == 1003L)
					{
						flag5 = true;
					}
					if (num7 == 1004L)
					{
						flag6 = true;
					}
					if (num7 == 1005L)
					{
						flag7 = true;
					}
					if (num7 == 2001L)
					{
						flag8 = true;
					}
					if (num7 == 2002L)
					{
						flag9 = true;
					}
					if (num7 == 3001L)
					{
						flag10 = true;
					}
					if (num7 == 3002L)
					{
						flag11 = true;
					}
					if (num7 == 3003L)
					{
						flag12 = true;
					}
					if (num7 == 3004L)
					{
						flag13 = true;
					}
					if (num7 == 4001L)
					{
						flag14 = true;
					}
					if (num7 == 4002L)
					{
						flag15 = true;
					}
				}
				DataRow[] array6 = Common.get_DataWeaponWRA(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				foreach (DataRow obj in array6)
				{
					long num8 = Conversions.ToLong(obj["CodeID"]);
					long num9 = Conversions.ToLong(obj["WeaponQty"]);
					double num10 = Conversions.ToDouble(obj["SelfDefenceRange"]);
					if ((num2 != 2005L && num2 != 2006L) || num2 != 2007L)
					{
						if ((num8 < 3000L || (num8 >= 4000L && num8 <= 4999L) || num8 >= 6000L) && num9 <= -2L && num9 >= -6L)
						{
							string text = "An entry in Commanders Guidance uses Missile Defence Weapon Qty for a non-ship or non-facility target type.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num8 < 3000L && num10 > num3)
						{
							string text = "An entry in Commanders Guidance has Self Defence Range greater than the anti-air range.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num8 >= 3000L && num8 <= 3999L && num10 > num4)
						{
							string text = "An entry in Commanders Guidance has Self Defence Range greater than the anti-ship range.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num8 >= 4000L && num8 <= 4999L && num10 > num5)
						{
							string text = "An entry in Commanders Guidance has Self Defence Range greater than the anti-submarine range.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num8 >= 5000L && num8 <= 5999L && num10 > num6)
						{
							string text = "An entry in Commanders Guidance has Self Defence Range greater than the anti-submarine range.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((num8 == 1999L || num8 == 2999L || num8 == 3999L || num8 == 4999L) && num9 <= -2L && num9 >= -6L)
						{
							string text = "An Commanders Guidance Unknown Target Type cannot use Missile Defence value for Weapon Qty";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (num8 == 1999L)
					{
						flag16 = true;
					}
					if (num8 == 2999L)
					{
						flag17 = true;
					}
					if (num8 == 3999L)
					{
						flag18 = true;
					}
					if (num8 == 4999L)
					{
						flag19 = true;
					}
					if (num8 == 3501L)
					{
						flag26 = true;
					}
					if (num8 == 2000L)
					{
						flag20 = true;
					}
					if (num8 >= 2000L && num8 <= 2099L)
					{
						flag34 = true;
					}
					if (num8 == 2100L)
					{
						flag21 = true;
					}
					if (num8 >= 2100L && num8 <= 2199L)
					{
						flag35 = true;
					}
					if (num8 == 2200L)
					{
						flag22 = true;
					}
					if (num8 >= 2200L && num8 <= 2299L)
					{
						flag36 = true;
					}
					if (num8 == 2300L)
					{
						flag23 = true;
					}
					if (num8 == 2400L)
					{
						flag24 = true;
					}
					if (num8 >= 2300L && num8 <= 2399L)
					{
						flag37 = true;
					}
					if (num8 == 3000L)
					{
						flag25 = true;
					}
					if (num8 >= 3000L && num8 <= 3998L)
					{
						flag38 = true;
					}
					if (num8 == 4000L)
					{
						flag27 = true;
					}
					if (num8 >= 4000L && num8 <= 4998L)
					{
						flag39 = true;
					}
					if (num8 == 5000L)
					{
						flag28 = true;
					}
					if (num8 == 5100L)
					{
						flag29 = true;
					}
					if (num8 == 5200L)
					{
						flag30 = true;
					}
					if (num8 >= 5200L && num8 <= 5299L)
					{
						flag40 = true;
					}
					if (num8 == 5300L)
					{
						flag31 = true;
					}
					if (num8 >= 5300L && num8 <= 5399L)
					{
						flag41 = true;
					}
					if (num8 == 5400L)
					{
						flag32 = true;
					}
					if (num8 == 5500L)
					{
						flag33 = true;
					}
				}
				if (!(num2 != 2005L && num2 != 2006L && num2 != 2007L))
				{
					continue;
				}
				if ((flag3 || flag4 || flag5 || flag6) && !flag16)
				{
					string text = "Weapon is anti-aircraft capable, but lacks the Commanders Guidance Air Contact Unknown flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag8 && !flag17)
				{
					string text = "Weapon is anti-surface capable, but lacks the Commanders Guidance Surface Contact Uknown flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag9 && !flag18)
				{
					string text = "Weapon is anti-submarine capable, but lacks the Commanders Guidance Sub-Surface Unknown flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag14 || flag15 || flag10 || flag11 || flag12) && !flag19)
				{
					string text = "Weapon is Land Target capable, but lacks the Commanders Guidance Land Contact Unknown flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag3 && !flag20)
				{
					string text = "Weapon is Land Target capable, but lacks the Commanders Guidance Aircraft Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag3 && flag20)
				{
					string text = "Weapon has Commanders Guidance Aircraft Unspecified flag but is not anti-aircraft capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag3 && flag34)
				{
					string text = "Weapon is not anti-aircraft capable but has a Commanders Guidance anti-aircraft flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag4 && !flag21)
				{
					string text = "Weapon is anti-helicopter capable, but lacks the Commanders Guidance Helicopter Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag4 && flag21)
				{
					string text = "Weapon has Commanders Guidance Helicopter Unspecified flag but is not anti-helicopter capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag4 && flag35)
				{
					string text = "Weapon is not anti-helicopter capable but has a Commanders Guidance anti-helicopter flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag5 && !flag22)
				{
					string text = "Weapon is anti-missile capable, but lacks the Commanders Guidance Guided Weapon Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag5 && flag22)
				{
					string text = "Weapon has Commanders Guidance Guided Weapon Unspecified flag but is not anti-missile capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag5 && flag36)
				{
					string text = "Weapon is not anti-missile capable but has a Commanders Guidance anti-missile flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && !flag23)
				{
					string text = "Weapon is anti-satellite capable, but lacks the Commanders Guidance Satellite Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag6 && flag23)
				{
					string text = "Weapon has Commanders Guidance Satellite Unspecified flag but is not anti-satellite capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag6 && flag37)
				{
					string text = "Weapon is not anti-satellite capable but has a Commanders Guidance anti-satellite flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag7 && !flag24)
				{
					string text = "Weapon is CRAM capable, but lacks the Commanders Guidance CRAM Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag7 && flag24)
				{
					string text = "Weapon has Commanders Guidance CRAM flag but is not CRAM capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag8 && !flag25)
				{
					string text = "Weapon is anti-ship capable, but lacks the Commanders Guidance Ship Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag8 && flag25)
				{
					string text = "Weapon has Commanders Guidance Ship Unspecified flag but is not anti-ship capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag8 && flag38)
				{
					string text = "Weapon is not anti-ship capable but has a Commanders Guidance anti-ship flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag8 && !flag26)
				{
					string text = "Weapon is anti-ship capable, but lacks the Commanders Guidance Surfaced Submarine flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag8 && flag26)
				{
					string text = "Weapon is not anti-ship capable, but has a Commanders Guidance Surfaced Submarine flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag9 && !flag27)
				{
					string text = "Weapon is anti-submarine capable, but lacks the Commanders Guidance Submarine Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag9 && flag27)
				{
					string text = "Weapon has Commanders Guidance Submarine Unspecified flag but is not anti-submarine capable!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag9 && flag39)
				{
					string text = "Weapon is not anti-submarine capable but has a Commanders Guidance anti-submarine flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag10 && !flag28)
				{
					string text = "Weapon is capable against Land Structure - Soft but lacks the Commanders Guidance Land Structure - Soft - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag10 && !flag29)
				{
					string text = "Weapon is capable against Land Structure - Soft but lacks the Commanders Guidance Land Structure - Hard - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag11 && !flag28)
				{
					string text = "Weapon is capable against Land Structure - Hardened but lacks the Commanders Guidance Land Structure - Soft - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag11 && !flag29)
				{
					string text = "Weapon is capable against Land Structure - Hardened but lacks the Commanders Guidance Land Structure - Hardened - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag12 && !flag30)
				{
					string text = "Weapon is capable against Runway but lacks the Commanders Guidance Runway Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag12 && flag30)
				{
					string text = "Weapon has Commanders Guidance Runway Unspecified flag but is not capable against Runway!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag12 && flag40)
				{
					string text = "Weapon is not capable against Runway but has a Commanders Guidance Runway flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag13 && !flag31)
				{
					string text = "Weapon is capable against Radar but lacks the Commanders Guidance Radar Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag13 && flag31)
				{
					string text = "Weapon has Commanders Guidance Radar Unspecified flag but is not capable against Radar!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag13 && flag41)
				{
					string text = "Weapon is not capable against Radar but has a Commanders Guidance Radar flag set";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag14 && !flag32)
				{
					string text = "Weapon is capable against Mobile Target - Soft but lacks the Commanders Guidance Mobile Target - Soft - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag14 && !flag33)
				{
					string text = "Weapon is capable against Mobile Target - Soft but lacks the Commanders Guidance Mobile Target - Hardened - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag15 && !flag33)
				{
					string text = "Weapon is capable against Mobile Target - Hardened but lacks the Commanders Guidance Mobile Target - Hardened - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag15 && !flag32)
				{
					string text = "Weapon is capable against Mobile Target - Hardened but lacks the Commanders Guidance Mobile Target - Soft - Unspecified flag!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 != 4001L && num2 != 4003L)
				{
					if (!flag && flag10 && !flag32)
					{
						string text = "Weapon is capable against fixed targets but must also be capable against parked mobile vehicles. Add Mobile Target - Soft - Unspecified flag to Commanders Guidance!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag && flag11 && !flag33)
					{
						string text = "Weapon is capable against fixed targets but must also be capable against parked mobile vehicles. Add Mobile Target - Hardened - Unspecified flag to Commanders Guidance!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Weapon" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200130", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateWeapon()
	{
		Class72.smethod_20();
	}
}
