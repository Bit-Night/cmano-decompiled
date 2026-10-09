using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateAircraft
{
	[CompilerGenerated]
	internal sealed class _Closure$__13-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__13-0(_Closure$__13-0 arg0)
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
			Common.StatusString = "ValidateAircraftHaveDatalinksForWeapons - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__13-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__16-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__16-0(_Closure$__16-0 arg0)
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
			smethod_2(theInt, ref $VB$Local_TasksFinished);
			Common.StatusString = "ValidateAircraftHaveDatalinkDirectors - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__16-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__3-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__3-0(_Closure$__3-0 arg0)
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
			Common.StatusString = "ValidateLoadoutCapabilities - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__3-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__7-0
	{
		public int $VB$Local_TasksFinished;

		public List<int> $VB$Local_theList;

		public _Closure$__7-0(_Closure$__7-0 arg0)
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
			ValidateAircraftHaveIlluminatorsForWeapons_PerAircraft(theInt, ref $VB$Local_TasksFinished);
			Common.StatusString = "ValidateAircraftHaveIlluminatorsForWeapons - " + Conversions.ToString((int)Math.Round(100.0 * ((double)$VB$Local_TasksFinished / (double)$VB$Local_theList.Count))) + "%";
		}

		static _Closure$__7-0()
		{
			Class72.smethod_20();
		}
	}

	public static ConcurrentDictionary<int, DataRow[]> Cache_SensorCapabilities;

	public static void ValidateAircraftStatsAndFlags()
	{
		try
		{
			Common.StatusString = "Validating Aircraft stats & flags";
			DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
			long num9 = default(long);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				int num = 0;
				int num2 = 0;
				long num3 = 0L;
				Common.StatusString = Conversions.ToString(Operators.ConcatenateObject((object)"Validating stats & flags for Aircraft #", NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
				long num4 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				int num5 = Conversions.ToInteger(Information.IsDBNull(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODADetectionCycle" }, (string[])null))) ? ((object)0) : NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODADetectionCycle" }, (string[])null));
				num = Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODATargetingCycle" }, (string[])null));
				num2 = Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OODAEvasiveCycle" }, (string[])null));
				num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "RunwayLengthCode" }, (string[])null));
				bool flag = false;
				DataRow[] array = Common.get_DataAircraftMounts(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(num4));
				long num14;
				long num15;
				long num16;
				checked
				{
					for (int i = 0; i < array.Length; i++)
					{
						long num6 = Conversions.ToLong(array[i]["ComponentID"]);
						DataRow[] array2 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(num6));
						for (int j = 0; j < array2.Length; j++)
						{
							long num7 = Conversions.ToLong(array2[j]["ComponentID"]);
							long num8 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num7)["ComponentID"]);
							num9 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num8)["Type"]);
							if (unchecked(num9 == 2001L || num9 == 2002L || num9 == 2003L || num9 == 2004L || num9 == 2009L || num9 == 4001L || num9 == 4002L || num9 == 4004L || num9 == 4005L || num9 == 4006L || num9 == 4007L || num9 == 6001L))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (!flag)
					{
						DataRow[] array3 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(num4));
						for (int k = 0; k < array3.Length; k++)
						{
							long num10 = Conversions.ToLong(array3[k]["ComponentID"]);
							DataRow[] array4 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(num10));
							for (int l = 0; l < array4.Length; l++)
							{
								long num11 = Conversions.ToLong(array4[l]["ComponentID"]);
								long num12 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num11)["ComponentID"]);
								long num13 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num12)["Type"]);
								if (!unchecked(num13 == 2001L || num13 == 2002L || num13 == 2003L || num13 == 2004L || num9 == 2009L || num13 == 4001L || num13 == 4002L || num13 == 4004L || num13 == 4005L || num13 == 4006L || num13 == 4007L || num13 == 6001L))
								{
									if (flag)
									{
										break;
									}
									continue;
								}
								flag = true;
								break;
							}
							if (flag)
							{
								break;
							}
						}
					}
					DataRow? dataRow = Common.get_MiscAircraft(Common.mySourceDB_Helper).Rows.Find(num4);
					num14 = 0L;
					num15 = 0L;
					num14 = Conversions.ToLong(dataRow["RunwayTakeOffDistance"]);
					num15 = Conversions.ToLong(dataRow["RunwayLandingDistance"]);
					num16 = ((num14 >= num15) ? num14 : num15);
					if (num3 == 1001L)
					{
						string text = "Aircraft has no Runway Size specified.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num14 < 0L)
					{
						string text = "Aircraft has no Take Off Distance figure.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num15 < 0L)
					{
						string text = "Aircraft has no Landing Distance figure.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num3 == 2001L && ((ulong)num14 > 0uL || (ulong)num15 > 0uL))
				{
					string text = "Runway Length should be 0m (VTOL) TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 == 2002L && (num16 < 1L || num16 > 450L))
				{
					string text = "Runway Length should be 1-450m TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 == 2003L && (num16 < 451L || num16 > 900L))
				{
					string text = "Runway Length should be 451-900m TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 == 2004L && (num16 < 901L || num16 > 1400L))
				{
					string text = "Runway Length should be 901-1400m TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 == 2005L && (num16 < 1401L || num16 > 2000L))
				{
					string text = "Runway Length should be 1401-2000m TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 == 2006L && (num16 < 2001L || num16 > 2600L))
				{
					string text = "Runway Length should be 2001-2600m TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 == 2007L && num16 < 2601L)
				{
					string text = "Runway Length should be 2601-3200m TOD/LAD";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 == 0 && flag)
				{
					string text = "Unit has an OODA Detection Cycle of 0 (or blank).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num == 0 && flag)
				{
					string text = "Unit carries weapons but has an OODA Targeting Cycle of 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num > 0 && !flag)
				{
					string text = "Unit has an OODA Targeting Cycle but carries no weapons.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 0)
				{
					string text = "Enter a valid OODA Evasive Cycle.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!Common.get_DataAircraft(Common.mySourceDB_Helper).Columns.Contains("Visibility"))
				{
					continue;
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Visibility" }, (string[])null))))
				{
					string text = "Aircraft has no Visibility values";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					continue;
				}
				string text2 = Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Visibility" }, (string[])null));
				if (!text2.Contains(","))
				{
					string text = "Visibility value must be in the format: [A/B/C],[A/B/C],[A/B/C]";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				else if (text2.Split(new char[1] { ',' }).Length != 3)
				{
					string text = "Visibility value must be in the format: [A/B/C],[A/B/C],[A/B/C]";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num4) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200000", "");
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
			DataRow? dataRow = Common.get_DataAircraft(Common.mySourceDB_Helper).Rows.Find(int_0);
			long num = int_0;
			long num2 = Conversions.ToLong(dataRow["Category"]);
			long num3 = Conversions.ToLong(dataRow["Type"]);
			string text = Conversions.ToString(dataRow["Name"]);
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
			DataRow[] array = Common.get_DataAircraftCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				long num4 = Conversions.ToLong(array[i]["CodeID"]);
				if (num4 == 7001L || num4 == 7002L || num4 == 7003L || num4 == 7004L)
				{
					flag = true;
				}
				if (num4 == 6011L)
				{
					flag2 = true;
				}
				if (num4 == 6012L)
				{
					flag3 = true;
				}
				if (num4 == 6002L)
				{
					flag6 = true;
				}
				if (num4 == 6001L)
				{
					flag7 = true;
				}
			}
			DataRow[] array2 = Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			for (int j = 0; j < array2.Length; j = checked(j + 1))
			{
				long num5 = Conversions.ToLong(array2[j]["ComponentID"]);
				DataRow? dataRow2 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num5);
				long num6 = Conversions.ToLong(dataRow2["ID"]);
				long num7 = Conversions.ToLong(dataRow2["Type"]);
				DataRow[] array3;
				if (!Cache_SensorCapabilities.ContainsKey((int)num6))
				{
					array3 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num6));
					Cache_SensorCapabilities.TryAdd((int)num6, array3);
				}
				else
				{
					array3 = Cache_SensorCapabilities[(int)num6];
				}
				DataRow[] array4 = array3;
				for (int k = 0; k < array4.Length; k = checked(k + 1))
				{
					long num8 = Conversions.ToLong(array4[k]["CodeID"]);
					if (num7 == 2004L && (num8 == 1002L || num8 == 1004L || num8 == 1005L))
					{
						flag5 = true;
					}
					if (num7 == 2001L && num8 == 1001L)
					{
						flag4 = true;
					}
				}
			}
			DataRow[] array5 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			for (int l = 0; l < array5.Length; l = checked(l + 1))
			{
				long num9 = Conversions.ToLong(array5[l]["ComponentID"]);
				if (!Information.IsNothing((object)Common.get_DataLoadout(Common.mySourceDB_Helper).Rows.Find(num9)))
				{
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
					bool flag42 = false;
					bool flag43 = false;
					bool flag44 = false;
					bool flag45 = false;
					bool flag46 = false;
					bool flag47 = false;
					bool flag48 = false;
					bool flag49 = false;
					bool flag50 = false;
					bool flag51 = false;
					bool flag52 = false;
					bool flag53 = false;
					bool flag54 = false;
					bool flag55 = false;
					bool flag56 = false;
					bool flag57 = false;
					bool flag58 = false;
					bool flag59 = false;
					bool flag60 = false;
					bool flag61 = false;
					bool flag62 = false;
					bool flag63 = false;
					bool flag64 = false;
					bool flag65 = false;
					bool flag66 = false;
					bool flag67 = false;
					bool flag68 = false;
					bool flag69 = false;
					DataRow? dataRow3 = Common.get_DataLoadout(Common.mySourceDB_Helper).Rows.Find(num9);
					long num10 = Conversions.ToLong(dataRow3["LoadoutRole"]);
					long num11 = Conversions.ToLong(dataRow3["TimeofDay"]);
					long num12 = Conversions.ToLong(dataRow3["Weather"]);
					int num13 = Conversions.ToInteger(dataRow3["WinchesterShotgun"]);
					bool flag70 = Conversions.ToBoolean(dataRow3["RequiresBuddyIllumination"]);
					if (num10 == 9002L)
					{
						flag8 = true;
					}
					if (num10 == 9001L)
					{
						flag9 = true;
					}
					if (num10 >= 1000L && num10 <= 9000L)
					{
						flag10 = true;
					}
					if (num10 == 3501L)
					{
						flag31 = true;
					}
					DataRow[] array6 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num9));
					bool flag86;
					checked
					{
						for (int m = 0; m < array6.Length; m++)
						{
							long num14 = Conversions.ToLong(array6[m]["ComponentID"]);
							DataRow[] array7 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num14));
							for (int n = 0; n < array7.Length; n++)
							{
								long num15 = Conversions.ToLong(array7[n]["ComponentID"]);
								DataRow? dataRow4 = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num15);
								long num16 = Conversions.ToLong(dataRow4["ID"]);
								long num17 = Conversions.ToLong(dataRow4["Type"]);
								double num18 = Conversions.ToDouble(dataRow4["SurfaceRangeMax"]);
								double num19 = Conversions.ToDouble(dataRow4["LandRangeMax"]);
								double num20 = Conversions.ToDouble(dataRow4["AirRangeMax"]);
								bool flag71 = false;
								bool flag72 = false;
								bool flag73 = false;
								bool flag74 = false;
								bool flag75 = false;
								bool flag76 = false;
								bool flag77 = false;
								bool flag78 = false;
								bool flag79 = false;
								bool flag80 = false;
								bool flag81 = false;
								bool flag82 = false;
								bool flag83 = true;
								bool flag84 = false;
								bool flag85 = false;
								unchecked
								{
									if (num17 == 2002L || num17 == 2003L || num17 == 2009L)
									{
										flag11 = true;
									}
									if (num17 == 2007L)
									{
										flag15 = true;
									}
									if (num17 == 3002L || num17 == 3004L)
									{
										flag34 = true;
									}
									if (num17 == 4004L || num17 == 4005L || num17 == 4006L || num17 == 4007L || num17 == 4008L || num17 == 4009L || num17 == 4010L || num17 == 4011L)
									{
										flag28 = true;
										flag13 = true;
									}
									if (num17 == 2003L)
									{
										flag29 = true;
									}
									if (num17 == 4101L)
									{
										flag30 = true;
									}
									if (num17 == 2004L)
									{
										flag25 = true;
									}
									if (num17 == 9002L)
									{
										flag19 = true;
									}
									if (num17 == 9003L)
									{
										flag20 = true;
									}
									if (num17 == 9001L)
									{
										flag21 = true;
									}
									if (num17 == 3003L)
									{
										flag22 = true;
									}
									DataRow[] array8;
									if (DataValidateWeapon.Cache_CommsPerWeapon.ContainsKey((int)num16))
									{
										array8 = DataValidateWeapon.Cache_CommsPerWeapon[(int)num16];
									}
									else
									{
										array8 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
										DataValidateWeapon.Cache_CommsPerWeapon.TryAdd((int)num16, array8);
									}
									DataRow[] array9 = array8;
									for (int num21 = 0; num21 < array9.Length; num21 = checked(num21 + 1))
									{
										long num22 = Conversions.ToLong(array9[num21]["ComponentID"]);
										long num23 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num22)["Type"]);
										if (num23 > 10000L && num23 < 11000L)
										{
											flag82 = true;
										}
									}
									DataRow[] array10;
									if (!DataValidateWeapon.Cache_WarheadsPerWeapon.ContainsKey((int)num16))
									{
										array10 = Common.get_DataWeaponWarheads(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
										DataValidateWeapon.Cache_WarheadsPerWeapon.TryAdd((int)num16, array10);
									}
									else
									{
										array10 = DataValidateWeapon.Cache_WarheadsPerWeapon[(int)num16];
									}
									DataRow[] array11 = array10;
									for (int num24 = 0; num24 < array11.Length; num24 = checked(num24 + 1))
									{
										long num25 = Conversions.ToLong(array11[num24]["ComponentID"]);
										long num26 = Conversions.ToLong(Common.get_DataWarhead(Common.mySourceDB_Helper).Rows.Find(num25)["Type"]);
										if (num17 == 2003L && (num26 == 4001L || num26 == 4002L || num26 == 4003L))
										{
											flag32 = true;
										}
									}
									DataRow[] array12;
									if (!DataValidateWeapon.Cache_CodesPerWeapon.ContainsKey((int)num16))
									{
										array12 = Common.get_DataWeaponCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
										DataValidateWeapon.Cache_CodesPerWeapon.TryAdd((int)num16, array12);
									}
									else
									{
										array12 = DataValidateWeapon.Cache_CodesPerWeapon[(int)num16];
									}
									DataRow[] array13 = array12;
									for (int num27 = 0; num27 < array13.Length; num27 = checked(num27 + 1))
									{
										long num28 = Conversions.ToLong(array13[num27]["CodeID"]);
										if (num28 == 6011L && num17 == 3001L)
										{
											flag49 = true;
										}
										if (num28 == 6012L && num17 == 3001L)
										{
											flag50 = true;
										}
										if (num28 == 6021L && num17 == 3001L)
										{
											flag52 = true;
											flag16 = true;
										}
										if (num28 == 6022L && num17 == 3001L)
										{
											flag51 = true;
											flag16 = true;
										}
										if (num28 == 1001L)
										{
											flag84 = true;
										}
										if (num28 == 1002L)
										{
											flag85 = true;
										}
										if (num28 == 6102L)
										{
											flag80 = true;
										}
										if (num28 == 6101L || num28 == 6103L)
										{
											flag81 = true;
										}
									}
									DataRow[] array14;
									if (!DataValidateWeapon.Cache_TargetsPerWeapon.ContainsKey((int)num16))
									{
										array14 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
										DataValidateWeapon.Cache_TargetsPerWeapon.TryAdd((int)num16, array14);
									}
									else
									{
										array14 = DataValidateWeapon.Cache_TargetsPerWeapon[(int)num16];
									}
									DataRow[] array15 = array14;
									foreach (DataRow obj in array15)
									{
										Conversions.ToLong(obj["ID"]);
										long num30 = Conversions.ToLong(obj["CodeID"]);
										if (num17 == 2001L || num17 == 2002L || num17 == 2003L || num17 == 2009L)
										{
											if (num30 == 2001L)
											{
												flag83 = true;
											}
											if (num30 == 3001L || num30 == 3002L || num30 == 3003L || num30 == 4001L || num30 == 4002L)
											{
											}
											if (num19 < 6.0 && (num30 == 3001L || num30 == 3002L || num30 == 4001L || num30 == 4002L || num30 == 3003L))
											{
												flag35 = true;
												flag13 = true;
												flag71 = true;
											}
											if (num19 >= 6.0 && (num30 == 3001L || num30 == 3002L || num30 == 4001L || num30 == 4002L || num30 == 3003L))
											{
												flag36 = true;
												flag13 = true;
												flag71 = true;
											}
											if (num18 < 6.0 && num30 == 2001L)
											{
												flag37 = true;
												flag13 = true;
												flag71 = true;
											}
											if (num18 >= 6.0 && num30 == 2001L)
											{
												flag38 = true;
												flag13 = true;
												flag71 = true;
											}
											if (num30 == 3004L)
											{
												flag39 = true;
												flag13 = true;
												flag71 = true;
											}
										}
										if (!flag83)
										{
											flag46 = true;
										}
										if (num30 == 1001L || num30 == 1002L || num30 == 1003L)
										{
											flag33 = true;
										}
										if (num20 > 15.0 && (num30 == 1001L || num30 == 1002L || num30 == 1003L))
										{
											flag40 = true;
										}
										if (num20 <= 15.0 && (num30 == 1001L || num30 == 1002L || num30 == 1003L))
										{
											flag41 = true;
										}
										if (num17 == 2004L && (num30 == 1001L || num30 == 1002L || num30 == 1003L))
										{
											flag42 = true;
										}
										if (num17 == 2002L && (num30 == 1001L || num30 == 1002L || num30 == 1003L))
										{
											flag43 = true;
										}
										if (num30 == 2002L && (num17 == 4001L || num17 == 4002L))
										{
											flag17 = true;
											flag69 = true;
										}
										if (num30 == 2001L && (num17 == 4001L || num17 == 4002L))
										{
											flag24 = true;
										}
										if (num30 == 1004L)
										{
											flag26 = true;
										}
									}
									DataRow[] array16;
									if (!DataValidateWeapon.Cache_SensorsPerWeapon.ContainsKey((int)num16))
									{
										array16 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
										DataValidateWeapon.Cache_SensorsPerWeapon.TryAdd((int)num16, array16);
									}
									else
									{
										array16 = DataValidateWeapon.Cache_SensorsPerWeapon[(int)num16];
									}
									DataRow[] array17 = array16;
									for (int num31 = 0; num31 < array17.Length; num31 = checked(num31 + 1))
									{
										long num32 = Conversions.ToLong(array17[num31]["ComponentID"]);
										DataRow? dataRow5 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num32);
										long num33 = Conversions.ToLong(dataRow5["ID"]);
										long num34 = Conversions.ToLong(dataRow5["Type"]);
										if (num34 == 3002L && num17 == 3001L && !flag31)
										{
											flag23 = true;
										}
										if (num17 == 3001L && num34 == 2004L)
										{
											flag48 = true;
										}
										if (num17 == 3001L && num34 == 2003L)
										{
											flag47 = true;
										}
										if (num17 == 3001L && num34 == 3001L)
										{
											flag27 = true;
										}
										if (num34 == 4002L)
										{
											flag76 = true;
										}
										if (!flag71 || !(num17 == 2001L || num17 == 2002L || num17 == 2003L || num17 == 2009L))
										{
											continue;
										}
										switch (num34)
										{
										case 2003L:
											flag68 = true;
											if (flag80)
											{
												if (flag80)
												{
													flag57 = true;
													flag75 = true;
												}
											}
											else
											{
												flag56 = true;
												flag74 = true;
											}
											continue;
										case 2004L:
											flag68 = true;
											if (flag80)
											{
												if (flag80)
												{
													flag54 = true;
													flag73 = true;
												}
											}
											else
											{
												flag53 = true;
												flag72 = true;
											}
											continue;
										}
										if (num34 == 2002L || num34 == 4002L)
										{
											DataRow[] array18 = Common.get_DataSensorFrequencySearchAndTrack(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num33));
											for (int num35 = 0; num35 < array18.Length; num35 = checked(num35 + 1))
											{
												long num36 = Conversions.ToLong(array18[num35]["Frequency"]);
												if (num36 == 2004L)
												{
													flag76 = true;
												}
												if (num36 > 1000L && num36 < 2000L)
												{
													flag62 = true;
													flag78 = true;
												}
											}
											if (flag76 && flag84)
											{
												flag58 = true;
											}
											if (flag76 && flag85)
											{
												flag59 = true;
											}
											if (flag76 && flag80)
											{
												flag60 = true;
											}
										}
										else
										{
											switch (num34)
											{
											case 2001L:
												flag61 = true;
												flag77 = true;
												break;
											case 3001L:
												flag63 = true;
												flag79 = true;
												break;
											}
										}
									}
									if (flag71 && (num17 == 2001L || num17 == 2002L || num17 == 2003L || num17 == 2009L))
									{
										if (flag82 && !flag81 && !flag80 && !flag74 && !flag75 && !flag72 && !flag73 && !flag76 && !flag77 && !flag78 && !flag79)
										{
											flag66 = true;
										}
										if (flag81 && !flag82 && !flag80 && !flag74 && !flag75 && !flag72 && !flag73 && !flag76 && !flag77 && !flag78 && !flag79)
										{
											flag65 = true;
										}
										if (flag80 && !flag81 && !flag82 && !flag74 && !flag75 && !flag72 && !flag73 && !flag76 && !flag77 && !flag78 && !flag79)
										{
											flag64 = true;
										}
										if (!flag81 && !flag82 && !flag80 && !flag74 && !flag75 && !flag72 && !flag73 && !flag76 && !flag77 && !flag78 && !flag79)
										{
											flag67 = true;
										}
									}
									if (flag83 && flag72 && flag77)
									{
										flag55 = true;
									}
								}
							}
						}
						DataRow[] array19 = Common.get_DataAircraftMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
						for (int num37 = 0; num37 < array19.Length; num37++)
						{
							int num38 = Conversions.ToInteger(array19[num37]["ComponentID"]);
							DataRow[] array20 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num38));
							for (int num39 = 0; num39 < array20.Length; num39++)
							{
								long num40 = Conversions.ToLong(array20[num39]["ComponentID"]);
								long num41 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num40)["ComponentID"]);
								DataRow dataRow6 = Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num41);
								long num42 = Conversions.ToLong(dataRow6["Type"]);
								float num43 = Conversions.ToSingle(dataRow6["AirRangeMax"]);
								if (num42 == 2004L && num43 > 0f)
								{
									flag44 = true;
								}
								if (num42 == 2002L && num43 > 0f)
								{
									flag45 = true;
								}
							}
						}
						flag86 = false;
					}
					int num44;
					if (flag42 || flag44)
					{
						flag86 = true;
						num44 = 0;
					}
					else
					{
						num44 = 0;
					}
					bool flag87 = (byte)num44 != 0;
					if (flag43 || flag45)
					{
						flag87 = true;
					}
					if (num9 != 19999L && (num9 < 10000L || num9 > 10003L) && num9 > 4L)
					{
						if (num13 == 2002 && !flag86)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of air-to-air gun against opportunity targets, but no air-to-air gun is carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num13 == 3003 && !flag86 && !flag87 && Strings.InStr(1, text, "ATARS", (CompareMethod)0) == 0)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of air-to-air gun, but no air-to-air gun is carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num13 == 5003 && !flag86 && !flag87 && Strings.InStr(1, text, "ATARS", (CompareMethod)0) == 0)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of air-to-air gun, but no air-to-air gun is carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num13 == 5006 && !flag86 && !flag87 && Strings.InStr(1, text, "ATARS", (CompareMethod)0) == 0)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of air-to-air gun, but no air-to-air gun is carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num13 == 5012 && !flag86 && !flag87 && Strings.InStr(1, text, "ATARS", (CompareMethod)0) == 0)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of air-to-air gun, but no air-to-air gun is carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num13 == 5021 && !flag86 && !flag87 && Strings.InStr(1, text, "ATARS", (CompareMethod)0) == 0)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of air-to-air gun, but no air-to-air gun is carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((num13 == 3001 || num13 == 3002 || num13 == 3003 || num13 == 5001 || num13 == 5002 || num13 == 5003 || num13 == 5005 || num13 == 5006) && !flag40 && !flag36 && !flag38 && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of BVR or Stand-Off weapons, but no such weapons are carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if ((num13 == 3002 || num13 == 3003 || num13 == 5002 || num13 == 5003 || num13 == 5005 || num13 == 5006 || num13 == 5011 || num13 == 5012) && !flag41 && !flag35 && !flag37)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " Weapon State (Winchester/Shotgun) assumes use of WVR or short-range weapons, but no such weapons are carried";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag33 && !flag26 && !flag19 && !flag20 && !flag21 && !flag22 && !flag13 && !flag15 && !flag16 && !flag17 && !flag24 && !flag28 && !flag31 && num10 != 8101L && num10 != 8102L && num10 != 8103L && num10 != 7001L)
					{
						flag14 = true;
					}
					if (flag25 && !flag26 && !flag19 && !flag20 && !flag21 && !flag22 && !flag23 && !flag17 && !flag24 && !flag14 && !flag13 && !flag15 && !flag16)
					{
						flag25 = true;
					}
					if (flag34 && !flag26 && !flag25 && !flag19 && !flag20 && !flag21 && !flag22 && !flag23 && !flag17 && !flag24 && !flag14 && !flag13 && !flag15 && !flag16 && !flag28 && !flag30 && num10 != 8101L && num10 != 8102L)
					{
						flag18 = true;
					}
					if (!flag14 && !flag26 && !flag25 && !flag19 && !flag20 && !flag21 && !flag22 && !flag23 && !flag17 && !flag24 && !flag18 && !flag13 && !flag15 && !flag16)
					{
						flag12 = true;
					}
					if (flag27 && !flag13)
					{
						flag51 = true;
						flag16 = true;
					}
					if (num9 == 19999L || !(num9 < 10000L || num9 > 10003L))
					{
						continue;
					}
					if (flag13 && !flag16 && !flag17)
					{
						if (flag46 && !flag35 && flag36 && !flag37 && flag38 && num10 != 3002L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses stand-off A/G + Anti-Ship weapons. Change role to Land/Naval Standoff (> 6nm) or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && flag36 && !flag37 && !flag38 && num10 != 3102L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses stand-off A/G weapons. Change role to Land-only Standoff (> 6nm) or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && !flag36 && !flag37 && flag38 && num10 != 3202L && num10 != 6001L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses Anti-Ship weapons. Change role to Naval-only Standoff (> 6nm)";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag35 && !flag36 && flag37 && !flag38 && num10 != 3001L && num10 != 3401L && num10 != 7003L && num10 != 4102L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses A/G + Anti-Ship weapons. Change role to Land/Naval Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag46 && flag35 && flag36 && flag37 && flag38 && num10 != 3001L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off A/G + Anti-Ship weapons. Change role to Land/Naval Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag46 && flag35 && flag36 && !flag37 && flag38 && num10 != 3001L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off A/G + Anti-Ship weapons. Change role to Land/Naval Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag46 && !flag35 && flag36 && flag37 && flag38 && num10 != 3001L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off A/G + Anti-Ship weapons. Change role to Land/Naval Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag35 && !flag36 && !flag37 && !flag38 && num10 != 3101L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses land-only weapons. Change role to Land-only Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag35 && flag36 && !flag37 && !flag38 && num10 != 3101L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off A/G weapons. Change role to Land-only Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag46 && flag35 && flag36 && flag37 && !flag38 && num10 != 3101L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off A/G + Anti-Ship weapons. Change role to Land-only Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag46 && flag35 && flag36 && !flag37 && flag38 && num10 != 3101L && num10 != 3401L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off A/G + Anti-Ship weapons. Change role to Land-only Strike or BAI/CAS";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && !flag36 && flag37 && !flag38 && num10 != 3201L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses naval-only weapons. Change role to Naval-only Strike";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && !flag36 && flag37 && flag38 && num10 != 3201L && !flag39)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " uses combined short-range and stand-off Anti-Ship weapons. Change role to Naval-only Strike";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag39)
						{
							if (num10 != 3003L && num10 != 3103L && num10 != 3203L && !flag35 && !flag36 && !flag37 && !flag38)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has anti-radar weapons. Change role to SEAD";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num10 != 3005L && num10 != 3105L && num10 != 3205L && (flag35 || flag36 || flag37 || flag38))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has both anti-radar and anti-surface weapons. Change role to DEAD";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
					if (flag14 && (num10 < 2001L || num10 > 2006L) && num10 != 2007L && num10 != 9004L && num10 != 4001L && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L && num10 != 7005L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " contains only air-to-air weapons. Change role to Intercept/Air Superiority/Point-Defence";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag28 && num10 != 4301L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " contains naval mines. Change role to Naval Mine Laying";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag30 && num10 != 4201L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " contains helicopter mine sweep package. Change role to Mine Sweeping (MCM)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag40 && (num10 == 2001L || num10 == 2003L || num10 == 2003L))
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " carries only WVR AAMs. Change role to WVR Intercept/Air Superiority/Point-Defence.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag40 && (num10 == 2002L || num10 == 2004L || num10 == 2006L))
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " carries BVR AAMs. Change role to BVR Intercept/Air Superiority/Point-Defence.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 && !flag13 && num10 != 3004L && num10 != 3104L && num10 != 3204L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " contains air launched decoys. Change role to TALD";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag16 && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L && num10 != 4001L && num10 != 4002L && num10 != 3201L && num10 != 3101L && num10 != 3001L && num10 != 3202L && num10 != 3102L && num10 != 3002L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is a recon loadout. Change role to Recon, Surveilance, or FO";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag18 && !flag22 && !flag23 && !flag29 && num10 != 2007L && num10 != 4001L && num10 != 4002L && num10 != 8001L && num10 != 7005L && num10 != 9001L && num10 != 3501L && num10 != 8101L && (num10 < 2001L || num10 > 2006L) && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L && num10 != 4101L && num10 != 4102L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is a ferry loadout. Change role to Ferry.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag17 && num10 != 6001L && num10 != 6002L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is an ASW loadout. Change role to ASW.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag24 && !flag17 && num10 != 3201L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is an anti-ship torpedo loadout. Change role to Naval-Only Strike";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag19 && !flag13 && num10 != 7102L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is a troop transport loadout. Change role to Troop Transport";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag20 && !flag13 && num10 != 7101L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is a paratroop loadout. Change role to Paratroops";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag21 && !flag13 && num10 != 7201L && !flag20 && !flag19)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is a cargo loadout. Change role to Cargo";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag22 && num10 != 8001L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is a tanker (buddy pod) loadout. Change role to Air Refueling";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag23 && !flag15 && !flag14 && !flag18 && !flag16 && !flag13 && num10 != 4001L && num10 != 9001L && num10 != 8001L && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " has OECM pods. Change role to OECM";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!(flag3 || flag50 || flag2 || flag49))
					{
						if (!flag3 && !flag50 && !flag2 && !flag49)
						{
							switch (num12)
							{
							case 2003L:
								if (flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " cannot use unguided weapons in bad weather. Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag56 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO seeker. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag57 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and EO seeker. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag53 && !flag55 && !flag67 && !flag58)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag54 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and IR seeker. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag59 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with limited all-weather laser seeker. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag60 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and laser seeker. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag64 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if ((flag61 || flag62) && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with active radar or SARH guidance. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag63 && !flag56 && !flag57 && !flag53 && !flag54 && !flag59 && !flag60 && !flag64 && !flag67 && !flag61 && !flag62)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with passive radar guidance. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag66)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has command-guided weapon. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag65)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has INS-guided weapon. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag69)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has ASW weapons. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag24 && !flag69)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has anti-ship torpedoes. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapons with no guidance. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag22)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " is a tanker (buddy pod). Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag23 && !flag13 && !flag14)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " is OECM or Recon. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag19 && !flag13)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " is troop transport. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag20 && !flag13)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " is paratroopers. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag21 && !flag13)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " is cargo. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag28)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " contains naval mines. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								break;
							case 2002L:
								if (flag58 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with clear-weather laser seeker. Change weather to Clear Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								break;
							case 2001L:
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is not bad-weather capable. Change weather to Limited All-Weather or Clear Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								break;
							}
							}
						}
					}
					else
					{
						switch (num12)
						{
						case 2003L:
							if (flag56 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO seeker. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag57 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and EO seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag53 && !flag55 && !flag67 && !flag58)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag54 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and IR seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag28)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " contains naval mines. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag59 && !flag67 && !flag58)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with limited all-weather laser seeker. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag60 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and laser seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag64 && !flag67 && !flag58 && !flag59)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if ((flag61 || flag62) && !flag67 && !flag59 && !flag58)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with active radar or SARH seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag63 && !flag56 && !flag57 && !flag53 && !flag54 && !flag59 && !flag58 && !flag60 && !flag64 && !flag67 && !flag61 && !flag62)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with passive radar guidance. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag69 && !flag66 && !flag67 && !flag56 && !flag53)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has ASW weapons. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag24 && !flag69 && !flag66 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has anti-ship torpedoes. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag66 && !flag67)
							{
								if (!flag3 && !flag50)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has command-guided weapon. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								else
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has command-guided weapon. Change weather to All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							if (flag65 && flag67 && !flag68)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has INS-guided weapon. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag67 && !flag58 && (flag3 || flag50))
							{
								if (flag53)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapons with no guidance. Change weather to Limited All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								else
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapons with no guidance. Change weather to All-Weather";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							if (flag22)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is a tanker (buddy pod). Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag23 && !flag13 && !flag14 && !flag16)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is OECM. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag19 && !flag13)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is troop transport. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag20 && !flag13)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is paratroopers. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag21 && !flag13)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is cargo. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							break;
						case 2002L:
							if (flag58 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with clear-weather laser seeker. Change weather to Clear Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag32 && flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has nuclear bombs. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag57 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and EO seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag54 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and IR seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag60 && !flag67 && !flag59 && !flag53)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance and laser seeker. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag64 && !flag67 && !flag59 && !flag56 && !flag53)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if ((flag61 || flag62) && !flag67 && !flag59 && !flag58)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with active radar or SARH guidance. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag63 && !flag56 && !flag57 && !flag53 && !flag54 && !flag59 && !flag60 && !flag64 && !flag67 && !flag61 && !flag62)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with passive radar guidance. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag66 && !flag67 && !flag59 && (flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has command-guided weapon. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag65 && flag67 && !flag68)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has INS-guided weapon. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag67 && !flag58 && !flag59 && !flag53 && (flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapons with no guidance. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag69 && !flag66 && !flag67 && !flag56 && !flag53)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has ASW weapons. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag24 && !flag69 && !flag66 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has anti-ship torpedoes. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag22)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is a tanker (buddy pod). Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag23 && !flag13 && !flag14 && !flag16)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is OECM. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag19 && !flag13)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is troop transport. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag20 && !flag13)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is paratroopers. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag21 && !flag13)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is cargo. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag28)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " contains naval mines. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							break;
						case 2001L:
							if (flag58 && !flag67)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with clear-weather laser seeker. Change weather to Clear Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag56)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO seeker. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag53 && !flag55)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag59)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with limited all-weather laser seeker. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag66 && !flag3 && !flag50)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with command guidance. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (flag67 && !flag32 && !flag3 && !flag50)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has weapons with no guidance. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							break;
						}
					}
					if (num10 == 3501L && num12 != 2003L && num12 != 2002L && num12 == 2001L)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is for Buddly Illumination and is limited to Clear Weather or Limited All Weather.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag14 && !flag16 && !flag31)
					{
						if (num12 == 2001L)
						{
							if (!flag4 || (!flag2 && !flag49 && !flag3 && !flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " can NOT perform air-to-air ops in any kind of weather. Change weather to Limited All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if ((num12 == 2002L || num12 == 2003L) && flag4 && (flag2 || flag49 || flag3 || flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " can do air-to-air ops in any kind of weather. Change weather to All-Weather";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag12)
					{
						if (!(num12 == 2001L && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L))
						{
							if ((num12 == 2002L || num12 == 2003L) && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is empty and can be used in any kind of weather. Change weather to All-Weather";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is empty and cannot be used in any kind of weather. Change weather to Limited All-Weather";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag16 && num12 == 2001L && ((flag52 && !flag51) || (!flag2 && !flag49 && !flag3 && !flag50)))
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " can NOT perform recon flights in any kind of weather. Change weather to Limited All-Weather";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 == 3501L)
					{
						if (num11 == 2003L)
						{
							if (!flag47)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " has buddy illumination pod with no EO sensor. Change Time-of-day to Day & Night";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if ((num11 == 2001L || num11 == 2002L) && flag47 && !flag48)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " has buddy illumination pod with EO sensor. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag13 && !flag16)
					{
						if (flag3 || flag50)
						{
							if (num11 == 2003L)
							{
								if (flag53 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag54 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker and GPS. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag58 && !flag67 && (flag5 || flag48) && !flag47)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with laser seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag59 && !flag67 && (flag5 || flag48) && !flag47)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with laser seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag60 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with laser seeker and GPS. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if ((flag61 || flag62) && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with active radar or SARH seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag63 && !flag56 && !flag57 && !flag53 && !flag54 && !flag59 && !flag60 && !flag64 && !flag67 && !flag61 && !flag62)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with passive radar seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag64)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag65 && !flag56 && !flag57)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon INS guidance. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag32 && flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has nuclear bombs. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag67 && !flag58 && (flag3 || flag50))
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapons with no guidance. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							else if (num11 == 2001L || num11 == 2002L)
							{
								if (flag56)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO sensor. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag57)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO sensor and GPS. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag58 && !flag67 && flag47 && !flag48)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has nav/attack pod with EO sensor. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag59 && !flag67 && flag47 && !flag48)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has nav/attack pod with EO sensor. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
						if (!flag3 && !flag50)
						{
							if (!(flag2 || flag49))
							{
								if (!flag2 && !flag49 && (num11 == 2001L || num11 == 2002L))
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " cannot be used at night. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							else if (num11 == 2001L || num11 == 2002L)
							{
								if (flag56)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO seeker. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag57)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with EO seeker and GPS. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag67 && !flag32)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " cannot use unguided weapons at night. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag66)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " cannot use command-guided weapons at night. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag58 && !flag67 && !flag70)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with laser seeker. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag59 && !flag67 && !flag70)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with laser seeker. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag60 && !flag67 && !flag70)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with laser seeker and GPS. Change Time-of-day to Day Only";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							else if (num11 == 2003L)
							{
								if (flag53 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag54 && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with IR seeker and GPS. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag32)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has nuclear bombs. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if ((flag61 || flag62) && !flag67)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with active radar or SARH seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag63 && !flag56 && !flag57 && !flag53 && !flag54 && !flag59 && !flag60 && !flag64 && !flag67 && !flag61 && !flag62)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with passive radar seeker. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag64)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon with GPS guidance. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag65 && !flag56 && !flag57)
								{
									string text2 = "Loadout " + Conversions.ToString(num9) + " has weapon INS guidance. Change Time-of-day to Day & Night";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
					}
					if (flag14 && !flag16 && !flag31)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && flag4 && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " can do Air-to-air ops night. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag4 || (!flag2 && !flag49 && !flag3 && !flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " can NOT perform Air-to-air ops night. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag15)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " can do ops night. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " can NOT perform ops night. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag16)
					{
						if (num11 == 2001L || num11 == 2002L)
						{
							if ((flag52 && !flag51) || (!flag2 && !flag49 && !flag3 && !flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " can NOT perform recon flights at night. Change Time-of-day to Day Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (num11 == 2003L && flag51 && (flag2 || flag49 || flag3 || flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " can perform recon flights at night. Change Time-of-day to Day/Night or Night Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag18 && !flag22 && !flag23 && (num10 < 2001L || num10 > 2006L) && num10 != 2007L && num10 != 3501L && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is a Ferry loadout and can be used at night. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is a Ferry loadout and cannot be used at night. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag17 && !flag13)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is a ASW loadout and can be used at night. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is a ASW loadout and cannot be used at night. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag24 && !flag17 && !flag13)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && (flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is an anti-ship torpedo loadout and can be used at night. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is an anti-ship torpedo loadout and cannot be used at night. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag12)
					{
						if ((num11 == 2001L || num11 == 2002L) && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L)
						{
							if (!flag2 && !flag49 && !flag3 && !flag50)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is empty and cannot be used at night. Change Time-of-day to Day Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (num11 == 2003L && num10 != 7001L && num10 != 7002L && num10 != 7003L && num10 != 7004L && num10 != 7005L && (flag2 || flag49 || flag3 || flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is empty and can be used at night. Change Time-of-day to Day/Night or Night Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag22)
					{
						if (num11 == 2001L || num11 == 2002L)
						{
							if (!flag2 && !flag49 && !flag3 && !flag50)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is a tanker (buddy pod). Change Time-of-day to Day Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is a tanker (buddy pod). Change Time-of-day to Day/Night or Night Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag23 && !flag13 && !flag14 && !flag16)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is OECM or Recon. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is OECM or Recon. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag19 && !flag13)
					{
						if (!(num11 == 2001L || num11 == 2002L))
						{
							if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is troop transport. Change Time-of-day to Day/Night or Night Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (!flag2 && !flag49 && !flag3 && !flag50)
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is troop transport. Change Time-of-day to Day Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag20 && !flag13)
					{
						if (num11 == 2001L || num11 == 2002L)
						{
							if (!flag2 && !flag49 && !flag3 && !flag50)
							{
								string text2 = "Loadout " + Conversions.ToString(num9) + " is paradrop. Change Time-of-day to Day Only";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is paradrop. Change Time-of-day to Day/Night or Night Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (!(flag21 && !flag13))
					{
						continue;
					}
					if (!(num11 == 2001L || num11 == 2002L))
					{
						if (num11 == 2003L && (flag2 || flag49 || flag3 || flag50))
						{
							string text2 = "Loadout " + Conversions.ToString(num9) + " is cargo. Change Time-of-day to Day/Night or Night Only";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					else if (!flag2 && !flag49 && !flag3 && !flag50)
					{
						string text2 = "Loadout " + Conversions.ToString(num9) + " is cargo. Change Time-of-day to Day Only";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else
				{
					string text2 = "Loadout " + Conversions.ToString(num9) + " does not exist in the database. Please remove from aircraft.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", 'Aircraft', '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
			if (!flag8 && num2 != 2005L)
			{
				string text2 = "Aircraft has no Maintenance loadout!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (!flag9 && num2 != 2005L && num3 != 8902L)
			{
				string text2 = "Aircraft has no Ferry loadout!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (flag9 && num3 == 8902L)
			{
				string text2 = "Aerostats shall not have a Ferry loadout!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (!flag10 && num2 != 2005L)
			{
				string text2 = "Aircraft has no Mission loadout!";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (flag6 && num2 != 2001L && num2 != 2002L)
			{
				string text2 = "Unit is a helicopter, remove Terrain Following Flag";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (flag7 && num2 != 2001L && num2 != 2002L)
			{
				string text2 = "Unit is a helicopter, remove Terrain Avoidance Flag";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (flag11 && !flag)
			{
				string text2 = "Aircraft carries bombs and/or rockets, but has NO bombsight";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			if (!flag11 && flag)
			{
				string text2 = "Aircraft does NOT carry bombs and/or rockets, but has a bombsight";
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			int_1++;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200001", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateLoadoutCapabilities()
	{
		try
		{
			_Closure$__3-0 arg = default(_Closure$__3-0);
			_Closure$__3-0 CS$<>8__locals7 = new _Closure$__3-0(arg);
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataAircraft(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				smethod_0(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "ValidateLoadoutCapabilities - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200002", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveCorrectFlags()
	{
		try
		{
			DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
			foreach (DataRow row in dataTable.Rows)
			{
				long num = Conversions.ToLong(row["ID"]);
				Common.StatusString = "ValidateAircraftHaveCorrectFlags - Aircraft #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataAircraftCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					double num5 = Conversions.ToDouble(array2[i]["CodeID"]);
					if (num5 == 6001.0 || num5 == 6002.0)
					{
						num2 += 1.0;
					}
					if (num5 == 7001.0 || num5 == 7002.0 || num5 == 7003.0 || num5 == 7004.0)
					{
						num3 += 1.0;
					}
					if (num5 == 6011.0 || num5 == 6012.0)
					{
						num4 += 1.0;
					}
				}
				if (num2 >= 2.0)
				{
					string text = "Both the Terrain Following and Terrain Avoidance flag have been selected. Only one flag is permitted.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 >= 2.0)
				{
					string text = "Two or more Bombsight flags have been selected. Only one Flag is permitted.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 >= 2.0)
				{
					string text = "Both Night Nav and Night Nav + Attack have been selected. Only one Flag is permitted.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200003", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveOnlyOnePropulsionAndFuelRecord()
	{
		try
		{
			DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
			foreach (DataRow row in dataTable.Rows)
			{
				long num = Conversions.ToLong(row["ID"]);
				Common.StatusString = "ValidateAircraftHaveOnlyOnePropulsionAndFuelRecord - Aircraft #" + Conversions.ToString(num);
				if (Common.get_DataAircraftPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 1)
				{
					string text = "The unit has more than one propulsion system! Only one propulsion system is allowed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Common.get_DataAircraftFuel(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num)).Length > 1)
				{
					string text = "The unit has more than one fuel record! Only one fuel record is allowed!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200004", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveIlluminatorsForWeapons_PerAircraft(int AircraftID, ref int TasksFinished)
	{
		try
		{
			long num = AircraftID;
			DataRow[] array = Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			List<int> list = new List<int>();
			DataRow[] array2 = array;
			for (int i = 0; i < array2.Length; i = checked(i + 1))
			{
				int item = Conversions.ToInteger(array2[i]["ComponentID"]);
				list.Add(item);
			}
			int count = list.Count;
			DataRow[] array3 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			int num2 = count - 1;
			for (int j = 0; j <= num2; j++)
			{
				try
				{
					if (Conversions.ToInteger(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(list[j])["Type"]) == 9001)
					{
						DataRow[] array4 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(list[j]));
						for (int k = 0; k < array4.Length; k = checked(k + 1))
						{
							int item2 = Conversions.ToInteger(array4[k]["ComponentID"]);
							list.Add(item2);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ErrorManagement.EnqueueErrorMessage(ex2);
					ex2.Data.Add("Error at Validation 999999", "");
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			count = list.Count;
			DataRow[] array5 = array3;
			int[] array6 = default(int[]);
			foreach (DataRow dataRow in array5)
			{
				try
				{
					int num3 = Conversions.ToInteger(dataRow["ComponentID"]);
					if (!Information.IsNothing((object)Common.get_DataLoadout(Common.mySourceDB_Helper).Rows.Find(num3)))
					{
						array6 = (int[])Utils.CopyArray((Array)array6, (Array)new int[count - 1 + 1]);
						int num4 = count;
						int num5 = num4 - 1;
						for (int m = 0; m <= num5; m++)
						{
							try
							{
								array6[m] = list[m];
							}
							catch (Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								Exception ex4 = ex3;
								ErrorManagement.EnqueueErrorMessage(ex4);
								ex4.Data.Add("Error at Validation 999999", "");
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						DataRow[] array7 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						foreach (DataRow dataRow2 in array7)
						{
							try
							{
								int num6 = Conversions.ToInteger(dataRow2["ComponentID"]);
								int num7 = Conversions.ToInteger(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num6)["ComponentID"]);
								long num8 = Conversions.ToInteger(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num7)["ID"]);
								DataRow[] array8;
								if (DataValidateWeapon.Cache_SensorsPerWeapon.ContainsKey((int)num8))
								{
									array8 = DataValidateWeapon.Cache_SensorsPerWeapon[(int)num8];
								}
								else
								{
									array8 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num8));
									DataValidateWeapon.Cache_SensorsPerWeapon.TryAdd((int)num8, array8);
								}
								DataRow[] array9 = array8;
								foreach (DataRow dataRow3 in array9)
								{
									try
									{
										int num10 = Conversions.ToInteger(dataRow3["ComponentID"]);
										num4++;
										array6 = (int[])Utils.CopyArray((Array)array6, (Array)new int[num4 - 1 + 1]);
										array6[num4 - 1] = num10;
									}
									catch (Exception ex5)
									{
										ProjectData.SetProjectError(ex5);
										Exception ex6 = ex5;
										ErrorManagement.EnqueueErrorMessage(ex6);
										ex6.Data.Add("Error at Validation 999999", "");
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
							}
							catch (Exception ex7)
							{
								ProjectData.SetProjectError(ex7);
								Exception ex8 = ex7;
								ErrorManagement.EnqueueErrorMessage(ex8);
								ex8.Data.Add("Error at Validation 999999", "");
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
						bool flag = Conversions.ToBoolean(Common.get_DataLoadout(Common.mySourceDB_Helper).Rows.Find(num3)["RequiresBuddyIllumination"]);
						DataRow[] array10 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						foreach (DataRow dataRow4 in array10)
						{
							try
							{
								int num6 = Conversions.ToInteger(dataRow4["ComponentID"]);
								bool flag2 = false;
								bool flag3 = false;
								DataRow? dataRow5 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num6);
								long num12 = 0L;
								int num7 = Conversions.ToInteger(dataRow5["ComponentID"]);
								DataRow[] array11 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num7));
								foreach (DataRow dataRow6 in array11)
								{
									try
									{
										int num14 = Conversions.ToInteger(dataRow6["ComponentID"]);
										flag3 = true;
										if (num4 <= 0)
										{
											continue;
										}
										int num15 = num4 - 1;
										for (int num16 = 0; num16 <= num15; num16++)
										{
											try
											{
												if (num14 == array6[num16])
												{
													flag2 = true;
													num12++;
													break;
												}
											}
											catch (Exception ex9)
											{
												ProjectData.SetProjectError(ex9);
												Exception ex10 = ex9;
												ErrorManagement.EnqueueErrorMessage(ex10);
												ex10.Data.Add("Error at Validation 999999", "");
												if (Debugger.IsAttached)
												{
													Debugger.Break();
												}
												ProjectData.ClearProjectError();
											}
										}
									}
									catch (Exception ex11)
									{
										ProjectData.SetProjectError(ex11);
										Exception ex12 = ex11;
										ErrorManagement.EnqueueErrorMessage(ex12);
										ex12.Data.Add("Error at Validation 999999", "");
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
								bool flag4 = false;
								DataRow[] array12;
								if (DataValidateWeapon.Cache_TargetsPerWeapon.ContainsKey(num7))
								{
									array12 = DataValidateWeapon.Cache_TargetsPerWeapon[num7];
								}
								else
								{
									array12 = Common.get_DataWeaponTargets(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num7));
									DataValidateWeapon.Cache_TargetsPerWeapon.TryAdd(num7, array12);
								}
								DataRow[] array13 = array12;
								foreach (DataRow dataRow7 in array13)
								{
									try
									{
										if (Conversions.ToInteger(dataRow7["CodeID"]) > 2000L)
										{
											flag4 = true;
										}
									}
									catch (Exception ex13)
									{
										ProjectData.SetProjectError(ex13);
										Exception ex14 = ex13;
										ErrorManagement.EnqueueErrorMessage(ex14);
										ex14.Data.Add("Error at Validation 999999", "");
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
								if (!flag && !flag2 && flag3)
								{
									string text = "Weapon " + Conversions.ToString(num7) + " in loadout " + Conversions.ToString(num3) + " has no illuminator.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", 'Aircraft', '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
								if (flag && flag4 && flag2 && flag3)
								{
									string text = "Weapon " + Conversions.ToString(num7) + " in loadout " + Conversions.ToString(num3) + " has illuminator so remove loadouts Requires Buddy Illuminator flag";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", 'Aircraft', '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
							catch (Exception ex15)
							{
								ProjectData.SetProjectError(ex15);
								Exception ex16 = ex15;
								ErrorManagement.EnqueueErrorMessage(ex16);
								ex16.Data.Add("Error at Validation 999999", "");
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								ProjectData.ClearProjectError();
							}
						}
					}
					else
					{
						string text = "Loadout " + Conversions.ToString(num3) + " does not exist in the database. Please remove from aircraft.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", 'Aircraft', '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				catch (Exception ex17)
				{
					ProjectData.SetProjectError(ex17);
					Exception ex18 = ex17;
					ErrorManagement.EnqueueErrorMessage(ex18);
					ex18.Data.Add("Error at Validation 999999", "");
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			TasksFinished++;
		}
		catch (Exception ex19)
		{
			ProjectData.SetProjectError(ex19);
			Exception ex20 = ex19;
			ErrorManagement.EnqueueErrorMessage(ex20);
			ex20.Data.Add("Error at Validation 200005", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveIlluminatorsForWeapons()
	{
		try
		{
			_Closure$__7-0 arg = default(_Closure$__7-0);
			_Closure$__7-0 CS$<>8__locals7 = new _Closure$__7-0(arg);
			Common.StatusString = "Validating Aircraft have illuminators for weapons";
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataAircraft(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				ValidateAircraftHaveIlluminatorsForWeapons_PerAircraft(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "ValidateAircraftHaveIlluminatorsForWeapons - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200006", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveDirectorsForMounts()
	{
		try
		{
			DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
			object obj2 = default(object);
			object obj3 = default(object);
			bool flag2 = default(bool);
			bool flag3 = default(bool);
			foreach (DataRow row in dataTable.Rows)
			{
				long num = Conversions.ToLong(row["ID"]);
				Common.StatusString = "ValidateAircraftHaveDirectorsForMounts - Aircraft #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				DataRow[] array4 = Common.get_DataAircraftMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int j = 0; j < array4.Length; j = checked(j + 1))
				{
					long num4 = Conversions.ToLong(array4[j]["ComponentID"]);
					DataRow[] array5 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
					for (int k = 0; k < array5.Length; k = checked(k + 1))
					{
						long num5 = Conversions.ToLong(array5[k]["ComponentID"]);
						num2++;
						array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
						array2[(int)(num2 - 1L)] = num5;
					}
					object obj = num2;
					int num6;
					if (!ForLoopControl.ForLoopInitObj(obj2, (object)0, Operators.SubtractObject(obj, (object)1), (object)1, ref obj3, ref obj2))
					{
						num6 = 0;
					}
					else
					{
						do
						{
							if (Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(array2[Conversions.ToInteger(obj2)])["Type"]) == 9001L)
							{
								DataRow[] array6 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(array2[Conversions.ToInteger(obj2)]));
								for (int l = 0; l < array6.Length; l = checked(l + 1))
								{
									long num7 = Conversions.ToLong(array6[l]["ComponentID"]);
									num2++;
									array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
									array2[(int)(num2 - 1L)] = num7;
								}
							}
						}
						while (ForLoopControl.ForNextCheckObj(obj2, obj3, ref obj2));
						num6 = 0;
					}
					bool flag = (byte)num6 != 0;
					flag = Conversions.ToBoolean(Common.get_DataMount(Common.mySourceDB_Helper).Rows.Find(num4)["LocalControl"]);
					DataRow[] array7 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
					for (int m = 0; m < array7.Length; m = checked(m + 1))
					{
						long value = Conversions.ToLong(array7[m]["ComponentID"]);
						flag2 = true;
						if (array2.Contains(value))
						{
							flag3 = true;
							break;
						}
					}
					int num8;
					if (!flag3 && flag2 && !flag)
					{
						string text = "Mount " + Conversions.ToString(num4) + " has no director!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num8 = 0;
					}
					else
					{
						num8 = 0;
					}
					flag3 = (byte)num8 != 0;
					flag2 = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200007", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftDirectorsAndIlluminatorsHaveCorrespondingWeapons()
	{
		checked
		{
			try
			{
				DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
				long num5 = default(long);
				long num11 = default(long);
				foreach (DataRow row in dataTable.Rows)
				{
					long num = Conversions.ToLong(row["ID"]);
					Common.StatusString = "ValidateAircraftDirectorsAndIlluminatorsHaveCorrespondingWeapons - Aircraft #" + Conversions.ToString(num);
					bool flag = false;
					long[] array = new long[0];
					long num2 = 0L;
					DataRow[] array2 = Common.get_DataAircraftMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int i = 0; i < array2.Length; i++)
					{
						long num3 = Conversions.ToLong(array2[i]["ComponentID"]);
						DataRow[] array3 = Common.get_DataMountWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int j = 0; j < array3.Length; j++)
						{
							long num4 = Conversions.ToLong(array3[j]["ComponentID"]);
							DataRow[] array4 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
							for (int k = 0; k < array4.Length; k++)
							{
								num5 = Conversions.ToLong(array4[k]["ComponentID"]);
							}
							if (Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num5)["Type"]) == 2004L)
							{
								flag = true;
							}
							DataRow[] array5 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num5));
							for (int l = 0; l < array5.Length; l++)
							{
								long num6 = Conversions.ToLong(array5[l]["ComponentID"]);
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
												break;
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
						DataRow[] array6 = Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
						for (int m = 0; m < array6.Length; m++)
						{
							long num9 = Conversions.ToLong(array6[m]["ComponentID"]);
							bool flag3 = false;
							unchecked
							{
								if (num2 > 0L)
								{
									long num10 = 0 - ((num11 == num2 - 1L) ? 1 : 0);
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
					DataRow[] array7 = Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int n = 0; n < array7.Length; n++)
					{
						double num12 = Conversions.ToDouble(array7[n]["ComponentID"]);
						DataRow? dataRow = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num12);
						double num13 = Conversions.ToDouble(dataRow["Type"]);
						double num14 = Conversions.ToDouble(dataRow["Role"]);
						unchecked
						{
							bool flag4;
							if (num13 == 9001.0)
							{
								DataRow[] array8 = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num12));
								for (int num15 = 0; num15 < array8.Length; num15 = checked(num15 + 1))
								{
									long num16 = Conversions.ToLong(array8[num15]["ComponentID"]);
									DataRow? dataRow2 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num16);
									Conversions.ToDouble(dataRow2["Type"]);
									double num17 = Conversions.ToDouble(dataRow2["Role"]);
									flag4 = false;
									if (!(num17 == 2191.0 || (num17 >= 2200.0 && num17 <= 2207.0) || num17 == 2041.0 || num17 == 2681.0 || num17 == 2682.0 || num17 == 2781.0 || num17 == 2782.0 || num17 == 2881.0 || num17 == 2882.0 || num17 == 6081.0 || num17 == 6082.0))
									{
										continue;
									}
									if (num2 > 0L)
									{
										long num18 = num2 - 1L;
										for (long num19 = 0L; num19 <= num18; num19++)
										{
											if (num16 == array[(int)num19])
											{
												flag4 = true;
												break;
											}
										}
									}
									if ((!flag4 && flag) || (!flag4 && !flag && num17 != 2682.0 && num17 != 2782.0 && num17 != 2882.0 && num17 != 6082.0))
									{
										string text = "Sensor " + Conversions.ToString(num16) + " in Sensor Group " + Conversions.ToString(num12) + " is a weapon director but is not required by any weapons or mounts!";
										string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
							if (num2 > 0L)
							{
								long num20 = num2 - 1L;
								for (long num21 = 0L; num21 <= num20; num21++)
								{
									if (num12 == (double)array[(int)num21])
									{
										flag4 = true;
										break;
									}
								}
							}
							if ((!flag4 && flag) || (!flag4 && !flag && num14 != 2682.0 && num14 != 2782.0 && num14 != 2882.0 && num14 != 6082.0))
							{
								string text = "Sensor " + Conversions.ToString(num12) + " is a weapon director but is not required by any weapons or mounts!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
					DataRow[] array9 = Common.get_DataAircraftMounts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					for (int num22 = 0; num22 < array9.Length; num22++)
					{
						long num23 = Conversions.ToLong(array9[num22]["ComponentID"]);
						DataRow[] array10 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num23));
						for (int num24 = 0; num24 < array10.Length; num24++)
						{
							long num25 = Conversions.ToLong(array10[num24]["ComponentID"]);
							DataRow? dataRow3 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num25);
							Conversions.ToDouble(dataRow3["Type"]);
							double num26 = Conversions.ToDouble(dataRow3["Role"]);
							bool flag4 = false;
							unchecked
							{
								if (!(num26 == 2191.0 || (num26 >= 2200.0 && num26 <= 2007.0) || num26 == 2041.0 || num26 == 2681.0 || num26 == 2682.0 || num26 == 2781.0 || num26 == 2782.0 || num26 == 2881.0 || num26 == 2882.0 || num26 == 6081.0 || num26 == 6082.0))
								{
									continue;
								}
								if (num2 > 0L)
								{
									long num27 = num2 - 1L;
									for (long num28 = 0L; num28 <= num27; num28++)
									{
										if (num25 == array[(int)num28])
										{
											flag4 = true;
											break;
										}
									}
								}
								if ((!flag4 && flag) || (!flag4 && !flag && num26 != 2682.0 && num26 != 2782.0 && num26 != 2882.0 && num26 != 6082.0))
								{
									string text = "Sensor " + Conversions.ToString(num25) + " on Mount " + Conversions.ToString(num23) + " is a weapon director but is not required by any weapons or mounts!";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
				ex2.Data.Add("Error at Validation 200008", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public static void ValidateAircraftNames()
	{
		try
		{
			Common.StatusString = "Validating Aircraft names";
			foreach (DataRow row in Common.get_DataAircraft(Common.mySourceDB_Helper).Rows)
			{
				long num = Conversions.ToLong(row["ID"]);
				string text = "";
				double num2 = 0.0;
				double num3 = 0.0;
				string text2 = Conversions.ToString(row["Name"]);
				text = Conversions.ToString(row["Comments"]);
				num2 = Conversions.ToDouble(row["YearCommissioned"]);
				num3 = Conversions.ToDouble(row["YearDecommissioned"]);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num16;
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"(\" bracket in comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 > 0 && num12 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 > 0 && num15 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				int num18;
				if (Strings.InStr(num17, text, "|", (CompareMethod)1) > 0)
				{
					string text3 = "Found pipe \"|\" character in the comments field, there should be none.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				else
				{
					num19 = 1;
				}
				int num20;
				if ((Strings.InStr(num19, text2, "Mk 8", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) > 0) | (Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) > 0))
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				else
				{
					num20 = 1;
				}
				int num21;
				if (Strings.InStr(num20, text2, "  ", (CompareMethod)1) > 0)
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 > num3 && num3 != 0.0)
				{
					string text3 = "Unit decomissioned before it commissioned? Unlikely. Check years!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200009", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftPropulsion()
	{
		try
		{
			DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
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
			double num8 = default(double);
			double num9 = default(double);
			double num10 = default(double);
			double num11 = default(double);
			double num12 = default(double);
			double num13 = default(double);
			double num14 = default(double);
			double num15 = default(double);
			double num16 = default(double);
			double num17 = default(double);
			double num18 = default(double);
			double num19 = default(double);
			double num20 = default(double);
			double num21 = default(double);
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
			foreach (DataRow row in dataTable.Rows)
			{
				long num = Conversions.ToLong(row["ID"]);
				long num2 = Conversions.ToLong(row["Category"]);
				string text = Conversions.ToString(row["Name"]);
				Common.StatusString = "ValidateAircraftPropulsion - Aircraft #" + Conversions.ToString(num);
				DataRow[] array = Common.get_DataAircraftPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array[i]["ComponentID"]);
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
					DataRow[] array2 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					foreach (DataRow obj2 in array2)
					{
						double num4 = Conversions.ToDouble(obj2["AltitudeMax"]);
						double num5 = Conversions.ToDouble(obj2["AltitudeMin"]);
						Conversions.ToDouble(obj2["Speed"]);
						double num6 = Conversions.ToDouble(obj2["AltitudeBand"]);
						double num7 = Conversions.ToDouble(obj2["Throttle"]);
						if (num6 == 1.0)
						{
							if (num7 == 1.0)
							{
								num8 = num5;
								num9 = num4;
								flag = true;
							}
							else if (num7 == 2.0)
							{
								num10 = num5;
								num11 = num4;
								flag2 = true;
							}
							else if (num7 == 3.0)
							{
								num12 = num5;
								num13 = num4;
								flag3 = true;
							}
							else if (num7 == 4.0)
							{
								num14 = num5;
								num15 = num4;
								flag4 = true;
							}
						}
						else if (num6 == 2.0)
						{
							if (num7 == 1.0)
							{
								num16 = num5;
								num17 = num4;
								flag5 = true;
							}
							else if (num7 == 2.0)
							{
								num18 = num5;
								num19 = num4;
								flag6 = true;
							}
							else if (num7 == 3.0)
							{
								num20 = num5;
								num21 = num4;
								flag7 = true;
							}
							else if (num7 == 4.0)
							{
								num22 = num5;
								num23 = num4;
								flag8 = true;
							}
						}
						else if (num6 == 3.0)
						{
							if (num7 == 1.0)
							{
								num24 = num5;
								num25 = num4;
								flag9 = true;
							}
							else if (num7 == 2.0)
							{
								num26 = num5;
								num27 = num4;
								flag10 = true;
							}
							else if (num7 == 3.0)
							{
								num28 = num5;
								num29 = num4;
								flag11 = true;
							}
							else if (num7 == 4.0)
							{
								num30 = num5;
								num31 = num4;
								flag12 = true;
							}
						}
						else if (num6 == 4.0)
						{
							if (num7 == 1.0)
							{
								num32 = num5;
								flag13 = true;
							}
							else if (num7 == 2.0)
							{
								num33 = num5;
								flag14 = true;
							}
							else if (num7 == 3.0)
							{
								num34 = num5;
								flag15 = true;
							}
							else if (num7 == 4.0)
							{
								num35 = num5;
								flag16 = true;
							}
						}
					}
				}
				if (num2 != 2005L)
				{
					if (flag && num8 != 0.0)
					{
						string text2 = "AltitudeBand1 Loiter Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && flag5 && num9 != 3657.6)
					{
						string text2 = "AltitudeBand1 Loiter Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && num9 > 3657.6)
					{
						string text2 = "AltitudeBand1 Loiter Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag2 && num10 != 0.0)
					{
						string text2 = "AltitudeBand1 Cruise Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag2 && flag6 && num11 != 3657.6)
					{
						string text2 = "AltitudeBand1 Cruise Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag2 && num11 > 3657.6)
					{
						string text2 = "AltitudeBand1 Cruise Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && num12 != 0.0)
					{
						string text2 = "AltitudeBand1 Full Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && flag7 && num13 != 3657.6)
					{
						string text2 = "AltitudeBand1 Full Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag3 && num13 > 3657.6)
					{
						string text2 = "AltitudeBand1 Full Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && num14 != 0.0)
					{
						string text2 = "AltitudeBand1 Reheat Speed Minimum Altitude has to be 0 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && flag8 && num13 != 3657.6)
					{
						string text2 = "AltitudeBand2 Reheat Speed Maximum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag4 && num15 > 3657.6)
					{
						string text2 = "AltitudeBand1 Reheat Speed Maximum Altitude can not be greater than 12000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && num16 != 3657.6)
					{
						string text2 = "AltitudeBand2 Loiter Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && flag9 && num17 != 7315.2)
					{
						string text2 = "AltitudeBand2 Loiter Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag5 && num17 > 7315.2)
					{
						string text2 = "AltitudeBand2 Loiter Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && num18 != 3657.6)
					{
						string text2 = "AltitudeBand2 Cruise Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && flag10 && num19 != 7315.2)
					{
						string text2 = "AltitudeBand2 Cruise Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag6 && num19 > 7315.2)
					{
						string text2 = "AltitudeBand2 Cruise Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && num20 != 3657.6)
					{
						string text2 = "AltitudeBand2 Full Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && flag11 && num21 != 7315.2)
					{
						string text2 = "AltitudeBand2 Full Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && num21 > 7315.2)
					{
						string text2 = "AltitudeBand2 Full Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && num22 != 3657.6)
					{
						string text2 = "AltitudeBand2 Reheat Speed Minimum Altitude has to be 12000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && flag12 && num21 != 7315.2)
					{
						string text2 = "AltitudeBand2 Reheat Speed Maximum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && num23 > 7315.2)
					{
						string text2 = "AltitudeBand2 Reheat Speed Maximum Altitude can not be greater than 24000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && num24 != 7315.2)
					{
						string text2 = "AltitudeBand3 Loiter Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && flag13 && num25 != 10972.8)
					{
						string text2 = "AltitudeBand3 Loiter Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9 && num25 > 10972.8)
					{
						string text2 = "AltitudeBand3 Loiter Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && num26 != 7315.2)
					{
						string text2 = "AltitudeBand3 Cruise Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && flag14 && num27 != 10972.8)
					{
						string text2 = "AltitudeBand3 Cruise Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && num27 > 10972.8)
					{
						string text2 = "AltitudeBand3 Cruise Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num28 != 7315.2)
					{
						string text2 = "AltitudeBand3 Full Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && flag15 && num29 != 10972.8)
					{
						string text2 = "AltitudeBand3 Full Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && num29 > 10972.8)
					{
						string text2 = "AltitudeBand3 Full Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num30 != 7315.2)
					{
						string text2 = "AltitudeBand3 Reheat Speed Minimum Altitude has to be 24000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && flag16 && num31 != 10972.8)
					{
						string text2 = "AltitudeBand3 Reheat Speed Maximum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && num31 > 10972.8)
					{
						string text2 = "AltitudeBand3 Reheat Speed Maximum Altitude can not be greater than 36000 feet. Create new AltitudeBand for altitude > 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13 && num32 != 10972.8)
					{
						string text2 = "AltitudeBand4 Loiter Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag14 && num33 != 10972.8)
					{
						string text2 = "AltitudeBand4 Cruise Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 && num34 != 10972.8)
					{
						string text2 = "AltitudeBand4 Full Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag16 && num35 != 10972.8)
					{
						string text2 = "AltitudeBand4 Reheat Speed Minimum Altitude has to be 36000 feet";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((flag || flag2 || flag3) && (!flag || !flag2 || !flag3)) & (Strings.InStr(1, text, "Tu-123", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AS-2", (CompareMethod)0) == 0))
					{
						string text2 = "Propulsion AltitudeBand1 needs Loiter, Cruise and Full speed settings";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((flag5 || flag6 || flag7) && (!flag5 || !flag6 || !flag7)) & (Strings.InStr(1, text, "Tu-123", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AS-2", (CompareMethod)0) == 0))
					{
						string text2 = "Propulsion AltitudeBand2 needs Loiter, Cruise and Full speed settings";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((flag9 || flag10 || flag11) && (!flag9 || !flag10 || !flag11)) & (Strings.InStr(1, text, "Tu-123", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AS-2", (CompareMethod)0) == 0))
					{
						string text2 = "Propulsion AltitudeBand3 needs Loiter, Cruise and Full speed settings";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((flag13 || flag14 || flag15) && (!flag13 || !flag14 || !flag15)) & (Strings.InStr(1, text, "Tu-123", (CompareMethod)0) == 0) & (Strings.InStr(1, text, "AS-2", (CompareMethod)0) == 0))
					{
						string text2 = "Propulsion AltitudeBand4 needs Loiter, Cruise and Full speed settings";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
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
			ex2.Data.Add("Error at Validation 200010", "");
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
			bool flag = false;
			bool flag2 = false;
			long num = int_0;
			DataRow[] array = Common.get_DataAircraftComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			long[] array2 = new long[0];
			long num2 = 0L;
			long[] array3 = new long[0];
			long num3 = 0L;
			DataRow[] array4 = array;
			for (int i = 0; i < array4.Length; i = checked(i + 1))
			{
				long num4 = Conversions.ToLong(array4[i]["ComponentID"]);
				long num5 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num4)["Type"]);
				long num6 = 0L;
				num6 = Conversions.ToLong(Common.get_MiscComm(Common.mySourceDB_Helper).Rows.Find(num4)["OffboardMissileDatalink"]);
				if (num5 > 9000L && num6 == 0L)
				{
					num2++;
					array2 = (long[])Utils.CopyArray((Array)array2, (Array)new long[(int)(num2 - 1L) + 1]);
					array2[(int)(num2 - 1L)] = num5;
				}
			}
			DataRow[] array5 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
			long[] array6 = new long[0];
			DataRow[] array7 = array5;
			long num8 = default(long);
			for (int j = 0; j < array7.Length; j = checked(j + 1))
			{
				long num7 = Conversions.ToLong(array7[j]["ComponentID"]);
				array6 = (long[])Utils.CopyArray((Array)array6, (Array)new long[(int)(num2 - 1L) + 1]);
				num8 = num2;
				long num9 = num8 - 1L;
				for (long num10 = 0L; num10 <= num9; num10++)
				{
					array6[(int)num10] = array2[(int)num10];
				}
				DataRow[] array8 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num7));
				checked
				{
					for (int k = 0; k < array8.Length; k++)
					{
						long num11 = Conversions.ToLong(array8[k]["ComponentID"]);
						long num12 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num11)["ComponentID"]);
						DataRow[] array9 = Common.get_DataWeapon(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(num12) + " And Type = 3001");
						for (int l = 0; l < array9.Length; l++)
						{
							long num13 = Conversions.ToLong(array9[l]["ID"]);
							DataRow[] array10 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num13));
							for (int m = 0; m < array10.Length; m++)
							{
								long num14 = Conversions.ToLong(array10[m]["ComponentID"]);
								long num15 = Conversions.ToLong(Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num14)["Type"]);
								unchecked
								{
									if (num15 > 9001L)
									{
										num8++;
										array6 = (long[])Utils.CopyArray((Array)array6, (Array)new long[(int)(num8 - 1L) + 1]);
										array6[(int)(num8 - 1L)] = num15;
									}
								}
							}
						}
					}
					DataRow[] array11 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num7));
					for (int n = 0; n < array11.Length; n++)
					{
						long num11 = Conversions.ToLong(array11[n]["ComponentID"]);
						long num12 = Conversions.ToLong(Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Rows.Find(num11)["ComponentID"]);
						if (Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num12)["Type"]) == 3001L)
						{
							continue;
						}
						DataRow[] array12 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num12));
						for (int num16 = 0; num16 < array12.Length; num16++)
						{
							long num17 = Conversions.ToLong(array12[num16]["ComponentID"]);
							flag = false;
							flag2 = false;
							long num18 = 0L;
							long num19 = 0L;
							DataRow? dataRow = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num17);
							num18 = Conversions.ToLong(dataRow["IsOptional"]);
							num19 = Conversions.ToLong(dataRow["Type"]);
							unchecked
							{
								if (num19 > 7999L)
								{
									if (num18 == 0L)
									{
										flag = true;
									}
									num3++;
									array3 = (long[])Utils.CopyArray((Array)array3, (Array)new long[(int)(num3 - 1L) + 1]);
									array3[(int)(num3 - 1L)] = num19;
								}
								if (num8 > 0L)
								{
									long num20 = num8 - 1L;
									for (long num21 = 0L; num21 <= num20; num21++)
									{
										if (num19 == array6[(int)num21])
										{
											flag2 = true;
										}
									}
								}
								if (!flag2 && flag)
								{
									string text = "Weapon " + Conversions.ToString(num12) + " In Loadout " + Conversions.ToString(num7) + " has no datalink.";
									string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
									Common.mySourceDB_Helper.ExecuteNonQuery(string_);
								}
							}
						}
					}
				}
			}
			long num22 = num8 - 1L;
			for (long num23 = 0L; num23 <= num22; num23++)
			{
				bool flag3 = false;
				if (num3 > 0L)
				{
					long num24 = num3 - 1L;
					for (long num25 = 0L; num25 <= num24; num25++)
					{
						if (array6[(int)num23] == array3[(int)num25])
						{
							flag3 = true;
							break;
						}
					}
				}
				if (!flag3)
				{
					string text2 = "<Error fetching name!>";
					string string_2 = "SELECT Description FROM EnumCommType WHERE ID = " + Conversions.ToString(array6[(int)num23]);
					DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_2);
					if (dataTable.Rows.Count > 0)
					{
						text2 = Conversions.ToString(dataTable.Rows[0]["Description"]);
					}
					string text = "Weapon datalink " + text2 + " is not used by any weapons on the Aircraft.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
			int_1++;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200011", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveDatalinksForWeapons()
	{
		try
		{
			_Closure$__13-0 arg = default(_Closure$__13-0);
			_Closure$__13-0 CS$<>8__locals7 = new _Closure$__13-0(arg);
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataAircraft(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				smethod_1(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "ValidateAircraftHaveDatalinksForWeapons - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200012", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveCorrectOperatorServiceAndYear()
	{
		try
		{
			string string_ = "SELECT ID, OperatorCountry, OperatorService, YearCommissioned, YearDecommissioned FROM DataAircraft";
			DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable(string_);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = 0L;
				long num2 = 0L;
				long num3 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "YearCommissioned" }, (string[])null));
				num2 = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "YearDecommissioned" }, (string[])null));
				double num4 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OperatorCountry" }, (string[])null));
				double num5 = Conversions.ToDouble(NewLateBinding.LateIndexGet(objectValue, new object[1] { "OperatorService" }, (string[])null));
				string string_2 = "SELECT YearStart, YearEnd FROM EnumOperatorCountry WHERE ID = " + Conversions.ToString(num4);
				DataTable dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable(string_2);
				long num6 = 0L;
				long num7 = 0L;
				if (dataTable2.Rows.Count > 0)
				{
					num6 = Conversions.ToLong(dataTable2.Rows[0]["YearStart"]);
					num7 = Conversions.ToLong(dataTable2.Rows[0]["YearEnd"]);
				}
				if (num < num6 && (ulong)num > 0uL)
				{
					string text = "Aircraft entered service before the country was formed? Unlikely!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				if (num2 < num6 && (ulong)num2 > 0uL)
				{
					string text = "Aircraft decommissioned before the country was formed? Unlikely!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				if (num2 > num7 && (ulong)num7 > 0uL)
				{
					string text = "Aircraft decommissioned after the country disintegrated? Unlikely!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				if (num > num7 && (ulong)num7 > 0uL)
				{
					string text = "Aircraft entered service after the country disintegrated? Unlikely!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				if (num4 == 2100.0 && num5 != 2101.0 && num5 != 2102.0 && num5 != 2003.0 && num5 != 2104.0)
				{
					string text = "Operator is United Kingdom. Service should be a Royal-type!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Facility" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				if (num4 == 2079.0 && num5 != 2001.0 && num5 != 2002.0 && num5 != 2003.0 && num5 != 2005.0 && num5 != 2206.0 && num5 != 2207.0)
				{
					string text = "Operator is Russia. Service should be a vanilla type, not Red Star type!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				if (num4 == 2088.0 && num5 != 2201.0 && num5 != 2202.0 && num5 != 2203.0 && num5 != 2204.0 && num5 != 2205.0 && num5 != 2206.0 && num5 != 2207.0 && num5 != 2208.0 && num5 != 2209.0 && num5 != 1003.0)
				{
					string text = "Operator is Soviet Union. Service should be one of the Cold War operators!";
					string string_3 = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num3) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200013", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_2(int int_0, ref int int_1)
	{
		try
		{
			long num = int_0;
			DataRow[] array = Common.get_DataAircraftComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				DataRow[] array8 = Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
				DataRow[] array11 = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				for (int m = 0; m < array11.Length; m++)
				{
					long num10 = Conversions.ToLong(array11[m]["ComponentID"]);
					DataRow[] array12 = Common.get_DataLoadoutWeapons(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num10));
					for (int n = 0; n < array12.Length; n++)
					{
						long num11 = Conversions.ToLong(array12[n]["ComponentID"]);
						_ = "SELECT DISTINCT ComponentID FROM DataWeaponRecord WHERE ID = " + Conversions.ToString(num11);
						DataRow[] array13 = Common.get_DataWeaponRecord(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num11));
						for (int num12 = 0; num12 < array13.Length; num12++)
						{
							long num13 = Conversions.ToLong(array13[num12]["ComponentID"]);
							long num14 = Conversions.ToLong(Common.get_DataWeapon(Common.mySourceDB_Helper).Rows.Find(num13)["ID"]);
							DataRow[] array14 = Common.get_DataWeaponComms(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num14));
							for (int num15 = 0; num15 < array14.Length; num15++)
							{
								long num16 = Conversions.ToLong(array14[num15]["ComponentID"]);
								DataRow? dataRow2 = Common.get_DataComm(Common.mySourceDB_Helper).Rows.Find(num16);
								long num17 = Conversions.ToLong(dataRow2["Type"]);
								if (Conversions.ToLong(dataRow2["WeaponLinkRequiresSensor"]) == -1L && num17 > 9001L)
								{
									flag2 = true;
									DataRow[] array15 = Common.get_DataCommDirectors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num16));
									for (int num18 = 0; num18 < array15.Length; num18++)
									{
										long num19 = Conversions.ToLong(array15[num18]["ComponentID"]);
										unchecked
										{
											num4++;
											array4 = (long[])Utils.CopyArray((Array)array4, (Array)new long[(int)(num4 - 1L) + 1]);
											array4[(int)(num4 - 1L)] = num19;
										}
									}
								}
							}
							DataRow[] array16 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num14));
							for (int num20 = 0; num20 < array16.Length; num20++)
							{
								long num21 = Conversions.ToLong(array16[num20]["ComponentID"]);
								unchecked
								{
									num5++;
									array5 = (long[])Utils.CopyArray((Array)array5, (Array)new long[(int)(num5 - 1L) + 1]);
									array5[(int)(num5 - 1L)] = num21;
								}
							}
						}
					}
					bool flag3 = false;
					unchecked
					{
						if (num2 > 0L)
						{
							long num22 = num2 - 1L;
							for (long num23 = 0L; num23 <= num22; num23++)
							{
								if (num3 > 0L)
								{
									long num24 = num3 - 1L;
									for (long num25 = 0L; num25 <= num24; num25++)
									{
										if (array2[(int)num23] == array3[(int)num25])
										{
											flag3 = true;
											break;
										}
									}
								}
								if (num5 > 0L)
								{
									long num26 = num5 - 1L;
									for (long num27 = 0L; num27 <= num26; num27++)
									{
										if (array2[(int)num23] == array5[(int)num27])
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
							long num28 = num4 - 1L;
							for (long num29 = 0L; num29 <= num28; num29++)
							{
								if (num3 > 0L)
								{
									long num30 = num3 - 1L;
									for (long num31 = 0L; num31 <= num30; num31++)
									{
										if (array4[(int)num29] == array3[(int)num31])
										{
											flag3 = true;
											break;
										}
									}
								}
								if (num5 > 0L)
								{
									long num32 = num5 - 1L;
									for (long num33 = 0L; num33 <= num32; num33++)
									{
										if (array4[(int)num29] == array5[(int)num33])
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
							string text = "Weapon datalink in loadout " + Conversions.ToString(num10) + " requires a director (sensor) in order to send target updates to weapon.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
				}
				flag4 = false;
			}
			long num34 = num2 - 1L;
			for (long num35 = 0L; num35 <= num34; num35++)
			{
				long num36 = num3 - 1L;
				for (long num37 = 0L; num37 <= num36; num37++)
				{
					if (array2[(int)num35] == array3[(int)num37])
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
				string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_);
			}
			int_1++;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200015", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftHaveDatalinkDirectors()
	{
		try
		{
			_Closure$__16-0 arg = default(_Closure$__16-0);
			_Closure$__16-0 CS$<>8__locals7 = new _Closure$__16-0(arg);
			CS$<>8__locals7.$VB$Local_theList = new List<int>();
			foreach (object row in Common.get_DataAircraft(Common.mySourceDB_Helper).Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				CS$<>8__locals7.$VB$Local_theList.Add(Conversions.ToInteger(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null)));
			}
			CS$<>8__locals7.$VB$Local_TasksFinished = 0;
			Parallel.ForEach(CS$<>8__locals7.$VB$Local_theList, [SpecialName] (int theInt) =>
			{
				smethod_2(theInt, ref CS$<>8__locals7.$VB$Local_TasksFinished);
				Common.StatusString = "ValidateAircraftHaveDatalinkDirectors - " + Conversions.ToString((int)Math.Round(100.0 * ((double)CS$<>8__locals7.$VB$Local_TasksFinished / (double)CS$<>8__locals7.$VB$Local_theList.Count))) + "%";
			});
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200014", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateDP(string AnnexName, string SourceTable)
	{
		try
		{
			string text = "INSERT INTO Validation ( ComponentID,  SourceAnnex, ErrorText ) SELECT " + SourceTable + ".ID, " + Conversions.ToString(Convert.ToChar(34)) + AnnexName + Conversions.ToString(Convert.ToChar(34)) + " AS Dingdong, ";
			text = text + Conversions.ToString(Convert.ToChar(34)) + "Damage points value is " + Conversions.ToString(Convert.ToChar(34)) + " & Format$([DamagePoints]) & " + Conversions.ToString(Convert.ToChar(34)) + "." + Conversions.ToString(Convert.ToChar(34)) + " AS Dongdingign ";
			text = text + "FROM " + SourceTable + " WHERE (((" + SourceTable + ".DamagePoints)<=0));";
			Common.mySourceDB_Helper.ExecuteNonQuery(text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200016", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAircraftPropulsion2()
	{
		try
		{
			DataTable dataTable = Common.get_DataAircraft(Common.mySourceDB_Helper);
			double num5 = default(double);
			foreach (object row in dataTable.Rows)
			{
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(RuntimeHelpers.GetObjectValue(row), new object[1] { "ID" }, (string[])null));
				DataRow[] array = Common.get_DataAircraftPropulsion(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				double num2 = Conversions.ToDouble(Common.get_MiscAircraft(Common.mySourceDB_Helper).Rows.Find(num)["DefaultCruiseSpeed"]);
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					long num3 = Conversions.ToLong(array2[i]["ComponentID"]);
					DataRow[] array3 = Common.get_DataPropulsionPerformance(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
					double num4 = 0.0;
					num5 = 0.0;
					DataRow[] array4 = array3;
					foreach (DataRow obj in array4)
					{
						double num6 = Conversions.ToDouble(obj["Speed"]);
						double num7 = Conversions.ToDouble(obj["AltitudeBand"]);
						double num8 = Conversions.ToDouble(obj["Throttle"]);
						if (num7 == 1.0)
						{
							if (num8 == 2.0 && num4 < 1.0)
							{
								num5 = num6;
								num4 = num7;
							}
						}
						else if (num7 == 2.0)
						{
							if (num8 == 2.0 && num4 < 2.0)
							{
								num5 = num6;
								num4 = num7;
							}
						}
						else if (num7 == 3.0)
						{
							if (num8 == 2.0 && num4 < 3.0)
							{
								num5 = num6;
								num4 = num7;
							}
						}
						else if (num7 == 4.0 && num8 == 2.0 && num4 < 4.0)
						{
							num5 = num6;
							num4 = num7;
						}
					}
				}
				if (num5 != num2)
				{
					string text = "The optimum cruise speed in the Propulsion annex is different from the Default Cruise Speed in the Aircraft annex!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Aircraft" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200017", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateAircraft()
	{
		Class72.smethod_20();
	}
}
