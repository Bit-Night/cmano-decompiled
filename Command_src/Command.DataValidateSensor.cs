using System;
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
internal sealed class DataValidateSensor
{
	public static void ValidateSensorStats()
	{
		try
		{
			string name = "SELECT ID, Name, Type, Role, Generation FROM DataSensor";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			bool flag63 = default(bool);
			bool flag64 = default(bool);
			bool flag66 = default(bool);
			Recordset recordset2;
			for (recordset2 = recordset; !recordset2.EOF; recordset2.MoveNext())
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				long num2 = Conversions.ToLong(recordset2.Fields["Type"].Value);
				long num3 = Conversions.ToLong(recordset2.Fields["Generation"].Value);
				Conversions.ToString(recordset2.Fields["Name"].Value);
				string text = Conversions.ToString(recordset2.Fields["Role"].Value);
				DataRow? dataRow = Common.get_MiscSensor(Common.mySourceDB_Helper).Rows.Find(num);
				bool flag = Conversions.ToBoolean(dataRow["ConfOverall"]);
				bool flag2 = Conversions.ToBoolean(dataRow["Used"]);
				bool flag3 = Conversions.ToBoolean(dataRow["CopyOverSource"]);
				bool flag4 = Conversions.ToBoolean(dataRow["CopyOverTarget"]);
				if ((flag || flag2 || flag3 || flag4) && num3 == 1001L && num2 != 9001L)
				{
					string text2 = "Sensor is to Completed but does not have a Tech Generation set.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 1001L)
				{
					string text2 = "Sensor is to Completed but is of type None.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 2001L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All radars need a valid tech generation!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 2002L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All SARH seekers need a valid tech generation!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 2005L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All TVM seekers need a valid tech generation!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag)
				{
					goto IL_04b0;
				}
				int num4;
				if (flag2)
				{
					num4 = 1;
				}
				else
				{
					if (flag3)
					{
						goto IL_04b0;
					}
					num4 = (flag4 ? 1 : 0);
				}
				goto IL_04b1;
				IL_04b0:
				num4 = 1;
				goto IL_04b1;
				IL_0709:
				int num5 = 1;
				goto IL_070a;
				IL_2e75:
				bool flag5;
				if (!flag5)
				{
					int num6;
					if (Conversions.ToDouble(text) != 2511.0 && Conversions.ToDouble(text) != 2516.0 && Conversions.ToDouble(text) != 2671.0 && Conversions.ToDouble(text) != 2672.0 && Conversions.ToDouble(text) != 2681.0 && Conversions.ToDouble(text) != 2682.0)
					{
						if (Conversions.ToDouble(text) != 2683.0)
						{
							goto IL_2f00;
						}
						num6 = 1;
					}
					else
					{
						num6 = 1;
					}
					flag5 = (byte)num6 != 0;
				}
				goto IL_2f00;
				IL_4aa9:
				double num7;
				double num8;
				double num9;
				double num10;
				double num11;
				double num12;
				double num13;
				double num14;
				double num15;
				double num16;
				int num17;
				if (!(num7 > 0.0) && !(num8 > 0.0) && !(num9 > 0.0) && !(num10 > 0.0) && !(num11 > 0.0) && !(num12 > 0.0) && !(num13 > 0.0) && !(num14 > 0.0) && !(num15 > 0.0))
				{
					if (!(num16 > 0.0))
					{
						goto IL_4b31;
					}
					num17 = 1;
				}
				else
				{
					num17 = 1;
				}
				bool flag6 = (byte)num17 != 0;
				goto IL_4b31;
				IL_2f00:
				if (!flag5)
				{
					int num18;
					if (Conversions.ToDouble(text) != 2771.0 && Conversions.ToDouble(text) != 2772.0 && Conversions.ToDouble(text) != 2781.0 && Conversions.ToDouble(text) != 2782.0)
					{
						if (Conversions.ToDouble(text) != 2783.0)
						{
							goto IL_2f64;
						}
						num18 = 1;
					}
					else
					{
						num18 = 1;
					}
					flag5 = (byte)num18 != 0;
				}
				goto IL_2f64;
				IL_302e:
				if (!flag5)
				{
					int num19;
					if (Conversions.ToDouble(text) != 6081.0 && Conversions.ToDouble(text) != 6082.0)
					{
						if (Conversions.ToDouble(text) != 6092.0)
						{
							goto IL_306e;
						}
						num19 = 1;
					}
					else
					{
						num19 = 1;
					}
					flag5 = (byte)num19 != 0;
				}
				goto IL_306e;
				IL_04b1:
				if (((uint)num4 & ((num2 == 2004L && (num3 < 2800L || num3 > 3999L)) ? 1u : 0u) & ((Conversions.ToDouble(text) != 2891.0) ? 1u : 0u) & ((Conversions.ToDouble(text) != 2890.0) ? 1u : 0u)) != 0)
				{
					string text2 = "All IR sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) & (Conversions.ToDouble(text) == 2891.0 && (num3 < 2000L || num3 > 2999L)))
				{
					string text2 = "Missile Aproach Warning Systems sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 3001L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All ESM sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag)
				{
					goto IL_0709;
				}
				if (flag2)
				{
					num5 = 1;
				}
				else
				{
					if (flag3)
					{
						goto IL_0709;
					}
					num5 = (flag4 ? 1 : 0);
				}
				goto IL_070a;
				IL_306e:
				if (!flag5 && Common.get_DataMountDirectors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length > 0)
				{
					flag5 = true;
				}
				bool flag7;
				bool flag8;
				bool flag9;
				bool flag10;
				bool flag11;
				int num20;
				bool flag12;
				bool flag13;
				bool flag14;
				bool flag15;
				bool flag16;
				bool flag17;
				bool flag18;
				bool flag19;
				bool flag20;
				bool flag21;
				bool flag22;
				bool flag23;
				double num21;
				double num22;
				double num23;
				double num24;
				double num25;
				double num26;
				double num27;
				double num28;
				double num29;
				double num30;
				double num31;
				double num32;
				double num33;
				double num34;
				double num35;
				double num36;
				double num37;
				double num38;
				double num39;
				double num40;
				double num41;
				double num42;
				bool flag24;
				bool flag25;
				bool flag26;
				bool flag27;
				bool flag28;
				bool flag29;
				bool flag30;
				bool flag31;
				bool flag32;
				bool flag33;
				bool flag34;
				bool flag35;
				bool flag36;
				bool flag37;
				bool flag38;
				bool flag39;
				bool flag40;
				bool flag41;
				bool flag42;
				bool flag43;
				bool flag44;
				bool flag45;
				bool flag46;
				bool flag47;
				bool flag48;
				bool flag49;
				bool flag50;
				bool flag51;
				bool flag52;
				bool flag53;
				bool flag54;
				bool flag55;
				bool flag56;
				bool flag57;
				bool flag58;
				bool flag59;
				bool flag60;
				bool flag61;
				bool flag62;
				double num44;
				double num45;
				double num46;
				double num47;
				double num48;
				double num49;
				double num50;
				if (num2 == 2001L)
				{
					if (!flag7 && flag8)
					{
						string text2 = "Radars with Speed Information Capabilty must also have Heading Information.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && !flag8)
					{
						string text2 = "Radars with Heading Information Capabilty must also have Speed Information.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9)
					{
						string text2 = "Radar systems may not use the Sub Search Capable flag.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag10 && !flag11 && num20 > 0)
					{
						string text2 = "Radars has no Periscope Search capability but has Periscope Search Tech set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag10 && num20 == 0)
					{
						string text2 = "Radars has Periscope Search capability but lacks Periscope Search Tech.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num20 > 1)
					{
						string text2 = "Radar can only have one Periscope-Surface Search Tech.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12 && (flag13 || flag14))
					{
						string text2 = "Space search radar systems can not detect land units.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 && (flag12 || flag13 || flag14 || flag16 || flag11 || flag17))
					{
						string text2 = "Navigation-Only radars can not detect aircraft, ships, land units orelse space objects.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 && (flag18 || flag19 || flag7 || flag8))
					{
						string text2 = "Navigation-Only radars can not have Altitude, Range, Heading orelse Speed Information Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag20 && (flag12 || flag13 || flag14 || flag16 || flag11 || flag17))
					{
						string text2 = "Weather-Only radars can not detect aircraft, ships, land units orelse space objects.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag20 && (flag18 || flag19 || flag7 || flag8))
					{
						string text2 = "Weather-Only radars can not have Altitude, Range, Heading orelse Speed Information Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag21 && (flag12 || flag13 || flag14 || flag16 || flag11 || flag17))
					{
						string text2 = "Navigation and Weather radars can not detect aircraft, ships, land units orelse space objects.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag21 && (flag18 || flag19 || flag7 || flag8))
					{
						string text2 = "Navigation and Weather radars can not have Altitude, Range, Heading orelse Speed Information Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag22 && (flag12 || flag13 || flag14 || flag16 || flag11 || flag17))
					{
						string text2 = "Terrain Avoidance/Following-Only radars can not detect aircraft, ships, land units orelse space objects.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag22 && (flag18 || flag19 || flag7 || flag8))
					{
						string text2 = "Terrain Avoidance/Following-Only radars can not have Altitude, Range, Heading orelse Speed Information Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag23 && (flag12 || flag13 || flag14 || flag16 || flag11))
					{
						string text2 = "Ground Mapping-Only radars can not detect aircraft, ships, land units orelse space objects.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag23 && (flag18 || flag19 || flag7 || flag8))
					{
						string text2 = "Ground Mapping-Only radars can not have Altitude, Range, Heading orelse Speed Information Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num21 > 0.0 && !flag16 && !flag12 && !flag17)
					{
						string text2 = "Max Air Contacts field has been filled in, but the sensor has no Air Search Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num22 > 0.0 && !flag11 && !flag10)
					{
						string text2 = "Max Surface Contacts field has been filled in, but the sensor has no Surface Search Capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num23 > 1.0)
					{
						string text2 = "Sensor has both Pulse-Only and Pulse Doppler flags. Choose one orelse the other.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num23 == 0.0)
					{
						string text2 = "Sensor has no Pulse-Only and Pulse Doppler flag. All radars must have one orelse the other.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num24 > 1.0)
					{
						string text2 = "Sensor has both CW and ICW flags. Choose one orelse the other.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num25 >= num26)
					{
						string text2 = "Sensor min range is greater orelse equal to max range. Not logical.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num27 >= num28 && num27 != 0.0)
					{
						string text2 = "Sensor min altitude is greater orelse equal to max altitude. Not logical.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num29 <= 0.0)
					{
						string text2 = "Scan Interval must be 1 orelse greater for radars.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num30 - num31 >= num32)
					{
						string text2 = "Sensor is a radar with gaps in the Search Bands. This is not possible.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 > 2.0)
					{
						string text2 = "Sensor is a radar with more than two Search Bands. Reduce the number to only two.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 == 0.0 && num33 != 0.0)
					{
						string text2 = "Sensor is a radar with no valid Search/Track Bands. It must have at least one.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num34 - num35 >= num36)
					{
						string text2 = "Sensor is a radar with gaps in the Illuminator Bands. This is not possible.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 > 2.0)
					{
						string text2 = "Sensor is a radar with more than two Illuminator Bands. Reduce the number to only two.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 == 0.0 && num16 != 0.0)
					{
						string text2 = "Sensor is an illuminator radar with no valid Illumiantor Bands. It must have at least one.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > num38 && num37 != 0.0)
					{
						string text2 = "Sensors Upper Search Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 < num40 && num39 != 0.0)
					{
						string text2 = "Sensors Lower Search Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 > num41 && num8 != 0.0)
					{
						string text2 = "Sensors Upper Illuminator Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 < num42 && num9 != 0.0)
					{
						string text2 = "Sensors Lower Illuminator Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 > num37)
					{
						string text2 = "Sensors Lower Frequency is higher than the Upper Frequency.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > 0.0 && num39 == 0.0)
					{
						string text2 = "Only the Upper Frequency is filled in. Lower Frequency is also required.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag24)
					{
						string text2 = "Radar can not operate in the Visual Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag25 || flag26)
					{
						string text2 = "Radar can not operate in the IR Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag27)
					{
						string text2 = "Radar can not operate in the Laser Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag28 || flag29 || flag30 || flag31 || flag32 || flag33 || flag34 || flag35 || flag36 || flag37 || flag38)
					{
						string text2 = "Radar can not operate in the Radio Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag39 || flag40 || flag41 || flag42)
					{
						string text2 = "Radar can not operate in the Sonar Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag43)
					{
						string text2 = "Radar can not operate in the Visual Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag44 || flag45)
					{
						string text2 = "Radar can not operate in the IR Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag46)
					{
						string text2 = "Radar can not operate in the Laser Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag47 || flag48 || flag49 || flag50 || flag51 || flag52 || flag53 || flag54 || flag55 || flag56 || flag57)
					{
						string text2 = "Radar can not operate in the Radio Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					int num43;
					if (!flag58 && !flag59 && !flag60 && !flag61)
					{
						num43 = 0;
					}
					else
					{
						string text2 = "Radar can not operate in the Sonar Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num43 = 0;
					}
					flag62 = (byte)num43 != 0;
					flag6 = false;
					if (num24 > 0.0)
					{
						flag6 = true;
					}
					if (num36 > 0.0)
					{
						flag6 = true;
					}
					if (num32 > 0.0)
					{
						flag62 = true;
					}
					int num51;
					if (!(num44 > 0.0) && !(num45 > 0.0) && !(num46 > 0.0) && !(num47 > 0.0) && !(num48 > 0.0) && !(num49 > 0.0) && !(num50 > 0.0) && !(num33 > 0.0) && !(num39 > 0.0))
					{
						if (!(num37 > 0.0))
						{
							goto IL_4aa9;
						}
						num51 = 1;
					}
					else
					{
						num51 = 1;
					}
					flag62 = (byte)num51 != 0;
					goto IL_4aa9;
				}
				goto IL_8f28;
				IL_90b5:
				int num52;
				if (Conversions.ToDouble(text) != 2771.0 && Conversions.ToDouble(text) != 2772.0 && Conversions.ToDouble(text) != 2773.0 && Conversions.ToDouble(text) != 2781.0 && Conversions.ToDouble(text) != 2782.0 && Conversions.ToDouble(text) != 2783.0)
				{
					if (Conversions.ToDouble(text) != 2784.0)
					{
						goto IL_9139;
					}
					num52 = 1;
				}
				else
				{
					num52 = 1;
				}
				flag5 = (byte)num52 != 0;
				goto IL_9139;
				IL_2f64:
				if (!flag5)
				{
					int num53;
					if (Conversions.ToDouble(text) != 2871.0 && Conversions.ToDouble(text) != 2872.0 && Conversions.ToDouble(text) != 2873.0 && Conversions.ToDouble(text) != 2874.0 && Conversions.ToDouble(text) != 2881.0 && Conversions.ToDouble(text) != 2882.0 && Conversions.ToDouble(text) != 2883.0 && Conversions.ToDouble(text) != 2884.0 && Conversions.ToDouble(text) != 2885.0)
					{
						if (Conversions.ToDouble(text) != 2886.0)
						{
							goto IL_302e;
						}
						num53 = 1;
					}
					else
					{
						num53 = 1;
					}
					flag5 = (byte)num53 != 0;
				}
				goto IL_302e;
				IL_8f28:
				DataRow[] array = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				double num54 = 0.0;
				DataRow[] array2 = array;
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					double num55 = Conversions.ToDouble(array2[i]["ComponentID"]);
					if (num55 > 0.0)
					{
						num54 += 1.0;
						DataRow? dataRow2 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num55);
						flag63 = false;
						flag64 = false;
						double num56 = Conversions.ToDouble(dataRow2["Type"]);
						if (num56 == 9001.0)
						{
							flag64 = true;
						}
						if (num56 >= 5001.0 && num56 <= 6999.0)
						{
							flag63 = true;
						}
					}
				}
				int num57;
				if (Conversions.ToDouble(text) != 2511.0 && Conversions.ToDouble(text) != 2516.0 && Conversions.ToDouble(text) != 2671.0 && Conversions.ToDouble(text) != 2672.0 && Conversions.ToDouble(text) != 2673.0 && Conversions.ToDouble(text) != 2681.0 && Conversions.ToDouble(text) != 2682.0 && Conversions.ToDouble(text) != 2683.0)
				{
					if (Conversions.ToDouble(text) != 2684.0)
					{
						goto IL_90b5;
					}
					num57 = 1;
				}
				else
				{
					num57 = 1;
				}
				flag5 = (byte)num57 != 0;
				goto IL_90b5;
				IL_070a:
				if (((uint)num5 & ((num2 == 3002L) ? 1u : 0u) & ((Conversions.ToDouble(text) != 4041.0) ? 1u : 0u) & ((num3 < 2000L || num3 > 2999L) ? 1u : 0u)) != 0)
				{
					string text2 = "All ECM sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((((flag || flag2 || flag3 || flag4) && num2 == 3002L) & (Conversions.ToDouble(text) == 4041.0)) && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All IRCM sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 4001L && num3 != 1002L)
				{
					string text2 = "All Laser Designator must use the Not Applicable tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 4002L && num3 != 1002L)
				{
					string text2 = "All Laser Spot Tracker sets must use the Not Applicable tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 4003L && num3 != 1002L)
				{
					string text2 = "All Laser Rangefinder sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 >= 5001L && num2 <= 5099L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All sonar sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 5101L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All MAD sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 5901L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All Ping Intercept sets need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 == 6001L && num3 != 1002L)
				{
					string text2 = "All mechanical mine sweep gear need a valid tech gen (N/A)!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 >= 6002L && num2 <= 6019L && (num3 < 2000L || num3 > 2999L))
				{
					string text2 = "All influence mine sweep gear need a valid tech gen!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag || flag2 || flag3 || flag4) && num2 >= 6020L && num2 <= 6099L && num3 != 1002L)
				{
					string text2 = "All mine neutralization gear need a valid tech gen (N/A)!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag && !flag2 && !flag3 && !flag4)
				{
					continue;
				}
				DataRow[] array3 = Common.get_MiscSensorDefault(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				bool flag65 = false;
				if (array3.Length > 0)
				{
					flag65 = true;
				}
				if (Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
				{
					flag66 = true;
				}
				DataRow[] array4 = Common.get_DataWeaponDirectors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num));
				bool flag67 = false;
				if (array4.Length > 0)
				{
					flag67 = true;
				}
				DataRow[] array5 = Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num));
				bool flag68 = false;
				bool flag69 = false;
				bool flag70 = false;
				bool flag71 = false;
				bool flag72 = false;
				bool flag73 = false;
				bool flag74 = false;
				if (array5.Length > 0)
				{
					if (Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag69 = true;
					}
					if (Common.get_DataSubmarineSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag70 = true;
					}
					if (Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag71 = true;
					}
					if (Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag72 = true;
					}
					if (Common.get_DataSatelliteSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag73 = true;
					}
					if (Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag74 = true;
					}
					if (!flag69 && !flag70 && !flag71 && !flag72 && !flag73 && !flag74)
					{
						flag68 = true;
					}
				}
				DataRow dataRow3 = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num);
				num16 = Conversions.ToDouble(dataRow3["RadarHorizontalBeamwidthIlluminate"]);
				num15 = Conversions.ToDouble(dataRow3["RadarVerticalBeamwidthIlluminate"]);
				num14 = Conversions.ToDouble(dataRow3["RadarSystemNoiseLevelIlluminate"]);
				num13 = Conversions.ToDouble(dataRow3["RadarProcessingGainLossIlluminate"]);
				num12 = Conversions.ToDouble(dataRow3["RadarPeakPowerIlluminate"]);
				num11 = Conversions.ToDouble(dataRow3["RadarPulseWidthIlluminate"]);
				num10 = Conversions.ToDouble(dataRow3["RadarPRFIlluminate"]);
				num25 = Conversions.ToDouble(dataRow3["RangeMin"]);
				num26 = Conversions.ToDouble(dataRow3["RangeMax"]);
				num27 = Conversions.ToDouble(dataRow3["AltitudeMin"]);
				num28 = Conversions.ToDouble(dataRow3["AltitudeMax"]);
				double num58 = Conversions.ToDouble(dataRow3["ResolutionRange"]);
				double num59 = Conversions.ToDouble(dataRow3["ResolutionHeight"]);
				double num60 = Conversions.ToDouble(dataRow3["ResolutionAngle"]);
				num21 = Conversions.ToDouble(dataRow3["MaxContactsAir"]);
				num22 = Conversions.ToDouble(dataRow3["MaxContactsSurface"]);
				double num61 = Conversions.ToDouble(dataRow3["MaxContactsSubmarine"]);
				double num62 = Conversions.ToDouble(dataRow3["MaxContactsIlluminate"]);
				num37 = Conversions.ToDouble(dataRow3["FrequencyUpper"]);
				num39 = Conversions.ToDouble(dataRow3["FrequencyLower"]);
				num9 = Conversions.ToDouble(dataRow3["FrequencyLowerIlluminate"]);
				num8 = Conversions.ToDouble(dataRow3["FrequencyUpperIlluminate"]);
				num33 = Conversions.ToDouble(dataRow3["RadarHorizontalBeamwidth"]);
				num50 = Conversions.ToDouble(dataRow3["RadarVerticalBeamwidth"]);
				num49 = Conversions.ToDouble(dataRow3["RadarSystemNoiseLevel"]);
				num48 = Conversions.ToDouble(dataRow3["RadarProcessingGainLoss"]);
				num47 = Conversions.ToDouble(dataRow3["RadarPeakPower"]);
				num46 = Conversions.ToDouble(dataRow3["RadarPulseWidth"]);
				num45 = Conversions.ToDouble(dataRow3["RadarPRF"]);
				num44 = Conversions.ToDouble(dataRow3["RadarBlindTime"]);
				num7 = Conversions.ToDouble(dataRow3["RadarBlindTimeIlluminate"]);
				double num63 = Conversions.ToDouble(dataRow3["Role"]);
				double num64 = Conversions.ToDouble(dataRow3["MasqueradeAs"]);
				num29 = Conversions.ToDouble(dataRow3["ScanInterval"]);
				double num65 = Conversions.ToDouble(dataRow3["DirectionFindingAccuracy"]);
				double num66 = Conversions.ToDouble(dataRow3["ESMSensitivity"]);
				double num67 = Conversions.ToDouble(dataRow3["ESMSystemLoss"]);
				double num68 = Conversions.ToDouble(dataRow3["ESMNumberOfChannels"]);
				bool flag75 = Conversions.ToBoolean(dataRow3["ESMPreciseEmitterID"]);
				double num69 = Conversions.ToDouble(dataRow3["ECMGain"]);
				double num70 = Conversions.ToDouble(dataRow3["ECMPeakPower"]);
				double num71 = Conversions.ToDouble(dataRow3["ECMBandwidth"]);
				double num72 = Conversions.ToDouble(dataRow3["ECMPoKReduction"]);
				double num73 = Conversions.ToDouble(dataRow3["ECMNumberOfTargets"]);
				Conversions.ToDouble(dataRow3["SonarSourceLevel"]);
				Conversions.ToDouble(dataRow3["SonarPulseLength"]);
				Conversions.ToDouble(dataRow3["SonarDirectivityIndex"]);
				Conversions.ToDouble(dataRow3["SonarRecognitionDifferentialActive"]);
				Conversions.ToDouble(dataRow3["SonarRecognitionDifferentialPassive"]);
				Conversions.ToDouble(dataRow3["SonarSensorToMachineryDistance"]);
				Conversions.ToDouble(dataRow3["SonarTowLength"]);
				double num74 = Conversions.ToDouble(dataRow3["SonarMinimumDeploymentDepth"]);
				double num75 = Conversions.ToDouble(dataRow3["SonarMaximumDeploymentDepth"]);
				double num76 = Conversions.ToDouble(dataRow3["SonarCZNumber"]);
				double num77 = Conversions.ToDouble(dataRow3["MineSweepWidth"]);
				double num78 = Conversions.ToDouble(dataRow3["MineSweepMinimumDepth"]);
				double num79 = Conversions.ToDouble(dataRow3["MineSweepMaximumDepth"]);
				double num80 = Conversions.ToDouble(dataRow3["MineSweepMaximumSpeed"]);
				double num81;
				double num82;
				double num83;
				double num84;
				double num85;
				try
				{
					num81 = Conversions.ToDouble(dataRow3["VisualDetectionZoomLevel"]);
					num82 = Conversions.ToDouble(dataRow3["VisualClassificationZoomLevel"]);
					num83 = Conversions.ToDouble(dataRow3["IRDetectionZoomLevel"]);
					num84 = Conversions.ToDouble(dataRow3["IRClassificationZoomLevel"]);
					Conversions.ToDouble(dataRow3["AltitudeMin_ASL"]);
					num85 = Conversions.ToDouble(dataRow3["AltitudeMax_ASL"]);
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
					throw;
				}
				DataRow[] array6 = Common.get_DataSensorFrequencySearchAndTrack(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				flag24 = false;
				flag25 = false;
				flag26 = false;
				flag27 = false;
				flag38 = false;
				flag37 = false;
				flag36 = false;
				flag35 = false;
				flag34 = false;
				flag33 = false;
				flag32 = false;
				flag31 = false;
				flag30 = false;
				flag29 = false;
				flag28 = false;
				flag42 = false;
				flag41 = false;
				flag40 = false;
				flag39 = false;
				double num86 = 0.0;
				num32 = 0.0;
				double num87 = 0.0;
				double num88 = 0.0;
				double num89 = 0.0;
				double num90 = 0.0;
				double num91 = 0.0;
				num31 = 9999.0;
				num30 = 0.0;
				num40 = 999999999999.0;
				num38 = 0.0;
				double num92 = 9999.0;
				double num93 = 0.0;
				double num94 = 999999999999.0;
				double num95 = 0.0;
				DataRow[] array7 = array6;
				double num97;
				double num98;
				double num99;
				double num100;
				double num101;
				bool flag76;
				bool flag77;
				bool flag78;
				bool flag79;
				bool flag80;
				double num103;
				DataRow[] array11;
				checked
				{
					for (int j = 0; j < array7.Length; j++)
					{
						double num96 = Conversions.ToDouble(array7[j]["Frequency"]);
						if (num96 == 1001.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 3000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 250000000.0;
							}
						}
						else if (num96 == 1002.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 250000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 500000000.0;
							}
						}
						else if (num96 == 1003.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 500000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 1000000000.0;
							}
						}
						else if (num96 == 1004.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 1000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 2000000000.0;
							}
						}
						else if (num96 == 1005.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 2000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 3000000000.0;
							}
						}
						else if (num96 == 1006.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 3000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 4000000000.0;
							}
						}
						else if (num96 == 1007.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 4000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 6000000000.0;
							}
						}
						else if (num96 == 1008.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 6000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 8000000000.0;
							}
						}
						else if (num96 == 1009.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 8000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 10000000000.0;
							}
						}
						else if (num96 == 1010.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 10000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 20000000000.0;
							}
						}
						else if (num96 == 1011.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 20000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 40000000000.0;
							}
						}
						else if (num96 == 1012.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 40000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 60000000000.0;
							}
						}
						else if (num96 == 1013.0)
						{
							num86 += 1.0;
							num32 += 1.0;
							if (num31 > num96)
							{
								num31 = num96;
								num40 = 60000000000.0;
							}
							if (num30 < num96)
							{
								num30 = num96;
								num38 = 100000000000.0;
							}
						}
						else if (num96 == 2001.0)
						{
							flag24 = true;
							num88 += 1.0;
						}
						else if (num96 == 2002.0)
						{
							flag25 = true;
							num89 += 1.0;
						}
						else if (num96 == 2003.0)
						{
							flag26 = true;
							num89 += 1.0;
						}
						else if (num96 == 2004.0)
						{
							flag27 = true;
							num90 += 1.0;
						}
						else if (num96 == 3001.0)
						{
							flag38 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 3.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 30.0;
							}
						}
						else if (num96 == 3002.0)
						{
							flag28 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 30.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 300.0;
							}
						}
						else if (num96 == 3003.0)
						{
							flag29 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 300.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 3000.0;
							}
						}
						else if (num96 == 3004.0)
						{
							flag37 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 3000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 30000.0;
							}
						}
						else if (num96 == 3005.0)
						{
							flag36 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 30000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 300000.0;
							}
						}
						else if (num96 == 3006.0)
						{
							flag35 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 300000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 3000000.0;
							}
						}
						else if (num96 == 3007.0)
						{
							flag34 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 3000000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 30000000.0;
							}
						}
						else if (num96 == 3008.0)
						{
							flag33 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 30000000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 300000000.0;
							}
						}
						else if (num96 == 3009.0)
						{
							flag32 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 300000000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 3000000000.0;
							}
						}
						else if (num96 == 3010.0)
						{
							flag31 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 3000000000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 30000000000.0;
							}
						}
						else if (num96 == 3011.0)
						{
							flag30 = true;
							num87 += 1.0;
							if (num92 > num96)
							{
								num92 = num96;
								num94 = 30000000000.0;
							}
							if (num93 < num96)
							{
								num93 = num96;
								num95 = 300000000000.0;
							}
						}
						else if (num96 == 4001.0)
						{
							flag42 = true;
							num91 += 1.0;
						}
						else if (num96 == 4002.0)
						{
							flag41 = true;
							num91 += 1.0;
						}
						else if (num96 == 4003.0)
						{
							flag40 = true;
							num91 += 1.0;
						}
						else if (num96 == 4004.0)
						{
							flag39 = true;
							num91 += 1.0;
						}
					}
					DataRow[] array8 = Common.get_DataSensorFrequencyIlluminate(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag43 = false;
					flag44 = false;
					flag45 = false;
					flag46 = false;
					flag57 = false;
					flag56 = false;
					flag55 = false;
					flag54 = false;
					flag53 = false;
					flag52 = false;
					flag51 = false;
					flag50 = false;
					flag49 = false;
					flag48 = false;
					flag47 = false;
					flag61 = false;
					flag60 = false;
					flag59 = false;
					flag58 = false;
					num36 = 0.0;
					num97 = 0.0;
					num98 = 0.0;
					num99 = 0.0;
					num100 = 0.0;
					num101 = 0.0;
					num35 = 9999.0;
					num34 = 0.0;
					num42 = 999999999999.0;
					num41 = 0.0;
					DataRow[] array9 = array8;
					for (int k = 0; k < array9.Length; k++)
					{
						double num102 = Conversions.ToDouble(array9[k]["Frequency"]);
						if (num102 == 1001.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 3000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 250000000.0;
							}
						}
						else if (num102 == 1002.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 250000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 500000000.0;
							}
						}
						else if (num102 == 1003.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 500000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 1000000000.0;
							}
						}
						else if (num102 == 1004.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 1000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 2000000000.0;
							}
						}
						else if (num102 == 1005.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 2000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 3000000000.0;
							}
						}
						else if (num102 == 1006.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 3000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 4000000000.0;
							}
						}
						else if (num102 == 1007.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 4000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 6000000000.0;
							}
						}
						else if (num102 == 1008.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 6000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 8000000000.0;
							}
						}
						else if (num102 == 1009.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 8000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 10000000000.0;
							}
						}
						else if (num102 == 1010.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 10000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 20000000000.0;
							}
						}
						else if (num102 == 1011.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 20000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 40000000000.0;
							}
						}
						else if (num102 == 1012.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 40000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 60000000000.0;
							}
						}
						else if (num102 == 1013.0)
						{
							num36 += 1.0;
							if (num35 > num102)
							{
								num35 = num102;
								num42 = 60000000000.0;
							}
							if (num34 < num102)
							{
								num34 = num102;
								num41 = 100000000000.0;
							}
						}
						else if (num102 == 2001.0)
						{
							flag43 = true;
							num98 += 1.0;
						}
						else if (num102 == 2002.0)
						{
							flag44 = true;
							num99 += 1.0;
						}
						else if (num102 == 2003.0)
						{
							flag45 = true;
							num99 += 1.0;
						}
						else if (num102 == 2004.0)
						{
							flag46 = true;
							num100 += 1.0;
						}
						else if (num102 == 3001.0)
						{
							flag57 = true;
							num97 += 1.0;
						}
						else if (num102 == 3002.0)
						{
							flag56 = true;
							num97 += 1.0;
						}
						else if (num102 == 3003.0)
						{
							flag55 = true;
							num97 += 1.0;
						}
						else if (num102 == 3004.0)
						{
							flag54 = true;
							num97 += 1.0;
						}
						else if (num102 == 3005.0)
						{
							flag53 = true;
							num97 += 1.0;
						}
						else if (num102 == 3006.0)
						{
							flag52 = true;
							num97 += 1.0;
						}
						else if (num102 == 3007.0)
						{
							flag51 = true;
							num97 += 1.0;
						}
						else if (num102 == 3008.0)
						{
							flag50 = true;
							num97 += 1.0;
						}
						else if (num102 == 3009.0)
						{
							flag49 = true;
							num97 += 1.0;
						}
						else if (num102 == 3010.0)
						{
							flag48 = true;
							num97 += 1.0;
						}
						else if (num102 == 3011.0)
						{
							flag47 = true;
							num97 += 1.0;
						}
						else if (num102 == 4001.0)
						{
							flag61 = true;
							num101 += 1.0;
						}
						else if (num102 == 4002.0)
						{
							flag60 = true;
							num101 += 1.0;
						}
						else if (num102 == 4003.0)
						{
							flag59 = true;
							num101 += 1.0;
						}
						else if (num102 == 4004.0)
						{
							flag58 = true;
							num101 += 1.0;
						}
					}
					DataRow[] array10 = Common.get_DataSensorCodes(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					flag76 = false;
					flag77 = false;
					flag78 = false;
					flag79 = false;
					flag80 = false;
					num23 = 0.0;
					num24 = 0.0;
					num103 = 0.0;
					num20 = 0;
					array11 = array10;
				}
				for (int l = 0; l < array11.Length; l = checked(l + 1))
				{
					double num104 = Conversions.ToDouble(array11[l]["CodeID"]);
					if (num104 == 3001.0)
					{
						num23 += 1.0;
						num103 += 1.0;
					}
					else if (num104 == 3002.0)
					{
						num23 += 1.0;
						num103 += 1.0;
					}
					else if (num104 == 3003.0)
					{
						num23 += 1.0;
						num103 += 1.0;
					}
					else if (num104 == 1011.0)
					{
						num103 += 1.0;
					}
					else if (num104 == 2001.0)
					{
						num103 += 1.0;
					}
					else if (num104 == 2701.0)
					{
						flag76 = true;
						num103 += 1.0;
					}
					else if (num104 == 4001.0)
					{
						num24 += 1.0;
						num103 += 1.0;
					}
					else if (num104 == 4002.0)
					{
						num24 += 1.0;
						num103 += 1.0;
					}
					else if (num104 == 4003.0)
					{
						num24 += 1.0;
						num103 += 1.0;
					}
					else if (num104 == 4003.0)
					{
						flag76 = true;
					}
					else if (num104 == 1001.0)
					{
						flag77 = true;
						num103 += 1.0;
					}
					else if (num104 == 1002.0)
					{
						flag78 = true;
						num103 += 1.0;
					}
					else if (num104 == 2001.0)
					{
						num103 += 1.0;
					}
					else if (num104 == 2002.0)
					{
						num103 += 1.0;
					}
					else if (num104 == 1031.0)
					{
						num20++;
					}
					else if (num104 == 1032.0)
					{
						num20++;
					}
					else if (num104 == 1033.0)
					{
						num20++;
					}
					else if (num104 == 9101.0)
					{
						flag79 = true;
						num103 += 1.0;
					}
					else if (num104 == 9102.0)
					{
						flag80 = true;
						num103 += 1.0;
					}
				}
				DataRow[] array12;
				if (DataValidateAircraft.Cache_SensorCapabilities.ContainsKey((int)num))
				{
					array12 = DataValidateAircraft.Cache_SensorCapabilities[(int)num];
				}
				else
				{
					array12 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
					DataValidateAircraft.Cache_SensorCapabilities.TryAdd((int)num, array12);
				}
				double num105 = 0.0;
				flag8 = false;
				flag7 = false;
				flag19 = false;
				flag18 = false;
				flag15 = false;
				flag21 = false;
				flag20 = false;
				flag23 = false;
				flag22 = false;
				flag16 = false;
				flag11 = false;
				flag9 = false;
				flag14 = false;
				flag13 = false;
				flag10 = false;
				flag12 = false;
				bool flag81 = false;
				bool flag82 = false;
				flag17 = false;
				bool flag83 = false;
				bool flag84 = false;
				DataRow[] array13 = array12;
				for (int m = 0; m < array13.Length; m = checked(m + 1))
				{
					double num106 = Conversions.ToDouble(array13[m]["CodeID"]);
					if (num106 == 2003.0)
					{
						flag8 = true;
						num105 += 1.0;
					}
					else if (num106 == 2004.0)
					{
						flag7 = true;
						num105 += 1.0;
					}
					else if (num106 == 2001.0)
					{
						flag19 = true;
						num105 += 1.0;
					}
					else if (num106 == 2002.0)
					{
						flag18 = true;
						num105 += 1.0;
					}
					else if (num106 == 4001.0)
					{
						flag15 = true;
						num105 += 1.0;
					}
					else if (num106 == 4002.0)
					{
						flag23 = true;
						num105 += 1.0;
					}
					else if (num106 == 4003.0)
					{
						flag22 = true;
						num105 += 1.0;
					}
					else if (num106 == 4004.0)
					{
						flag20 = true;
						num105 += 1.0;
					}
					else if (num106 == 4005.0)
					{
						flag21 = true;
						num105 += 1.0;
					}
					else if (num106 == 1001.0)
					{
						flag16 = true;
						num105 += 1.0;
					}
					else if (num106 == 1002.0)
					{
						flag11 = true;
						num105 += 1.0;
					}
					else if (num106 == 1003.0)
					{
						flag9 = true;
						num105 += 1.0;
					}
					else if (num106 == 1004.0)
					{
						flag14 = true;
						num105 += 1.0;
					}
					else if (num106 == 1005.0)
					{
						flag13 = true;
						num105 += 1.0;
					}
					else if (num106 == 1006.0)
					{
						flag10 = true;
						num105 += 1.0;
					}
					else if (num106 == 1007.0)
					{
						flag17 = true;
						num105 += 1.0;
					}
					else if (num106 == 1011.0)
					{
						flag12 = true;
						num105 += 1.0;
					}
					else if (num106 == 1021.0)
					{
						flag83 = true;
					}
					else if (num106 == 1022.0)
					{
						num105 += 1.0;
						flag84 = true;
					}
					else if (num106 == 9001.0)
					{
						flag81 = true;
					}
					else if (num106 == 9002.0)
					{
						flag82 = true;
					}
				}
				flag5 = false;
				if (Conversions.ToDouble(text) == 2191.0)
				{
					flag5 = true;
				}
				if (!flag5)
				{
					int num107;
					if (Conversions.ToDouble(text) != 2201.0 && Conversions.ToDouble(text) != 2202.0)
					{
						if (Conversions.ToDouble(text) != 2203.0)
						{
							goto IL_2e75;
						}
						num107 = 1;
					}
					else
					{
						num107 = 1;
					}
					flag5 = (byte)num107 != 0;
				}
				goto IL_2e75;
				IL_9250:
				int num108;
				if (Conversions.ToDouble(text) != 6081.0 && Conversions.ToDouble(text) != 6082.0)
				{
					if (Conversions.ToDouble(text) != 6092.0)
					{
						goto IL_928c;
					}
					num108 = 1;
				}
				else
				{
					num108 = 1;
				}
				flag5 = (byte)num108 != 0;
				goto IL_928c;
				IL_928c:
				if (num2 == 2003L)
				{
					if (flag5 && num62 == 0.0)
					{
						string text2 = "Sensor appears to be a visual Gun/Missile Director but Max Contacts Illumination is 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag5 && num62 > 0.0)
					{
						string text2 = "Sensor is not a visual Gun/Missile Director. Max Contacts Illumination to 0";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 < 2500.0 || num63 > 2799.0)
					{
						string text2 = "The Visual Sensor role is invalid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 > 2700.0 && num63 < 2799.0 && !flag76)
					{
						string text2 = "Role says LLTV but the Night Capable flag in the sensor Code table is not set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 < 2700.0 || num63 >= 2799.0) && flag76 && num63 != 2521.0)
					{
						string text2 = "Night Capable flag in the sensor Code table is but sensor Role is not LLTV nor a Searchlight!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 == 2521.0 && !flag76)
					{
						string text2 = "Role says Searchlight but the Night Capable flag in the sensor Code table is not set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 > 2500.0 && num63 <= 2799.0 && !flag78)
					{
						string text2 = "Visual sensor must have Classification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 > 2500.0 && num63 <= 2799.0 && num63 != 2691.0 && !flag77)
					{
						string text2 = "Visual sensor must have Identification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 > 2500.0 && num63 <= 2799.0 && num82 <= 0.0)
					{
						string text2 = "Visual sensor must have the Classification Zoom Level set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2516.0 || num63 == 2606.0 || num63 == 2641.0 || num63 == 2671.0 || num63 == 2681.0 || num63 == 2682.0 || num63 == 2771.0 || num63 == 2781.0 || num63 == 2782.0) && num81 > 0.0)
					{
						string text2 = "Visual sensor Role says the sensor is not search capable, Visual Classification Zoom to 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2501.0 || num63 == 2605.0 || num63 == 2503.0 || num63 == 2511.0 || num63 == 2512.0 || num63 == 2515.0 || num63 == 2521.0 || num63 == 2601.0 || num63 == 2602.0 || num63 == 2709.0 || num63 == 2611.0 || num63 == 2621.0 || num63 == 2630.0 || num63 == 2631.0 || num63 == 2672.0 || num63 == 2683.0 || num63 == 2684.0 || num63 == 2691.0 || num63 == 2701.0 || num63 == 2702.0 || num63 == 2703.0 || num63 == 2711.0 || num63 == 2721.0 || num63 == 2730.0 || num63 == 2731.0 || num63 == 2772.0 || num63 == 2783.0 || num63 == 2784.0 || num63 == 2791.0) && num81 <= 0.0)
					{
						string text2 = "Visual sensor Role says the sensor is search capable, enter a Visual Detection Zoom Level!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num29 < 1.0)
					{
						string text2 = "Visual scan interval should be minimum 1 second!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num81 > 0.0 && num82 > 0.0 && num82 < num81)
					{
						string text2 = "Detection Zoom Level may not be larger than Classification Zoom Level!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8)
					{
						string text2 = "Visual sensors can not give speed information!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag19)
					{
						string text2 = "Visual sensors can not give range information!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 || flag21 || flag20 || flag23 || flag22 || flag81 || flag82)
					{
						string text2 = "Illegal Capability flag for Visual sensor!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 > 0.0 || num98 > 0.0 || num99 > 0.0 || num100 > 0.0 || num97 > 0.0 || num101 > 0.0)
					{
						string text2 = "Visual sensor can not have Illuminator bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 > 0.0 || num91 > 0.0 || num87 > 0.0 || num90 > 0.0 || num89 > 0.0)
					{
						string text2 = "Visual sensor has illegal bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num88 == 0.0)
					{
						string text2 = "Visual sensors must have the Visual band selected!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 2004L)
				{
					if (flag5 && num62 == 0.0)
					{
						string text2 = "Sensor appears to be an IR Gun Director but Max Contacts Illumination is 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag5 && num62 > 0.0)
					{
						string text2 = "Sensor is not an IR Gun Director. Max Contacts Illumination to 0";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 < 2800.0 || num63 > 2899.0)
					{
						string text2 = "The IR Sensor role is invalid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 != 2814.0 && num63 != 2851.0 && num63 != 2890.0 && num63 != 2891.0 && num63 != 2892.0 && num63 != 2893.0 && num63 != 2894.0 && !flag77)
					{
						string text2 = "Imaging IR sensor must have the Identification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 != 2814.0 && num63 != 2851.0 && num63 != 2890.0 && num63 != 2891.0 && num63 != 2892.0 && num63 != 2893.0 && !flag78)
					{
						string text2 = "Imaging IR sensor must have the Classification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2814.0 || num63 == 2851.0 || num63 == 2891.0 || num63 == 2892.0 || num63 == 2893.0) && flag78)
					{
						string text2 = "Non-Imaging IR sensor must NOT have the Classification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2814.0 || num63 == 2851.0 || num63 == 2891.0 || num63 == 2892.0 || num63 == 2893.0) && flag77)
					{
						string text2 = "Non-Imaging IR sensor must NOT have the Identification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2814.0 || num63 == 2891.0 || num63 == 2892.0 || num63 == 2893.0) && num84 != 0.0)
					{
						string text2 = "The IR Classification Zoom level must be 0 for non-imaging sensors!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2814.0 || num63 == 2851.0 || num63 == 2891.0 || num63 == 2892.0 || num63 == 2893.0) && num83 <= 0.0)
					{
						string text2 = "The IR Detection Zoom level must be entered for non-imaging sensors!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2801.0 || num63 == 2802.0 || num63 == 2803.0 || num63 == 2804.0 || num63 == 2811.0 || num63 == 2814.0 || num63 == 2821.0 || num63 == 2822.0 || num63 == 2831.0 || num63 == 2832.0 || num63 == 2833.0 || num63 == 2834.0 || num63 == 2873.0 || num63 == 2874.0 || num63 == 2875.0 || num63 == 2876.0 || num63 == 2885.0 || num63 == 2886.0 || num63 == 2887.0 || num63 == 2888.0 || num63 == 2852.0 || num63 == 2894.0 || num63 == 2899.0) && num83 == 0.0)
					{
						string text2 = "This is a imaging IR sensor and must have the Detection Zoom Level set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2806.0 || num63 == 2871.0 || num63 == 2872.0 || num63 == 2881.0 || num63 == 2882.0 || num63 == 2883.0 || num63 == 2884.0) && num83 != 0.0)
					{
						string text2 = "This is a NON-imaging IR sensor and must NOT have the Detection Zoom Level set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num29 < 1.0)
					{
						string text2 = "Infrared scan interval should be minimum 1 second!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 2892.0 || num63 == 2893.0 || num63 == 2894.0) && num3 != 3001L && num3 != 3002L && num3 != 3003L)
					{
						string text2 = "Sensor role says IR seeker but generation makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num3 == 3001L || num3 == 3002L || num3 == 3003L) && num63 != 2892.0 && num63 != 2893.0 && num63 != 2894.0)
					{
						string text2 = "Sensor Generation says IR seeker but role makes no sense!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num83 > 0.0 && num84 > 0.0 && num84 < num83)
					{
						string text2 = "Detection Zoom Level may not be larger than Classification Zoom Level!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8)
					{
						string text2 = "Infrared sensors can not give speed information!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && (num63 == 2814.0 || num63 == 2851.0 || num63 == 2891.0 || num63 == 2892.0 || num63 == 2893.0))
					{
						string text2 = "Infrared Linescanners can not give heading information!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag19)
					{
						string text2 = "Visual sensors can not give range information!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15 || flag21 || flag20 || flag23 || flag22 || flag81 || flag82)
					{
						string text2 = "Illegal Capability flag for Visual sensor!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 > 0.0 || num98 > 0.0 || num98 > 0.0 || num100 > 0.0 || num97 > 0.0 || num101 > 0.0)
					{
						string text2 = "Infrared sensor can not have Illuminator bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 > 0.0 || num91 > 0.0 || num87 > 0.0 || num90 > 0.0 || num88 > 0.0)
					{
						string text2 = "Infrared sensor has illegal bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num89 == 0.0)
					{
						string text2 = "Infrared sensor must have the Infrared band selected!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 4003L)
				{
					if (flag5 && num62 == 0.0)
					{
						string text2 = "Sensor appears to be a laser rangefinder for a Gun Director but Max Contacts Illumination is 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag5 && num62 > 0.0)
					{
						string text2 = "Sensor is not a laser rangefinder for a Gun Director. Max Contacts Illumination to 0";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6091.0) | (Conversions.ToDouble(text) == 6092.0))
					{
						string text2 = "Sensor type is Laser Rangefinder but sensor role is Laser Target Designator! Set Role to rangefinder if not intended to guide weapons, else set type to laser designator.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 9001L)
				{
					if (num54 <= 0.0)
					{
						string text2 = "A Sensor Group requires at least one valid sensor.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num45 != 0.0 || num46 != 0.0 || num47 != 0.0 || num48 != 0.0 || num49 != 0.0 || num50 != 0.0 || num33 != 0.0 || num8 != 0.0 || num9 != 0.0 || num39 != 0.0 || num37 != 0.0 || num62 != 0.0 || num61 != 0.0 || num22 != 0.0 || num21 != 0.0 || num60 != 0.0 || num59 != 0.0 || num58 != 0.0 || num28 != 0.0 || num27 != 0.0 || num26 != 0.0 || num25 != 0.0 || num10 != 0.0 || num11 != 0.0 || num12 != 0.0 || num13 != 0.0 || num14 != 0.0 || num15 != 0.0 || num16 != 0.0)
					{
						string text2 = "Clear all data in this Sensor Group except the Sensor Group List!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag64)
					{
						string text2 = "A Sensor Group may NOT contain another Sensor Group!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag63)
					{
						string text2 = "A Sensor Group may NOT contain sonars, MAD orelse mine-countermeasure gear!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 > 0.0 || num90 > 0.0 || num89 > 0.0 || num88 > 0.0 || num87 > 0.0 || num32 > 0.0)
					{
						string text2 = "A Sensor Group may NOT have Search Bands! Remove all of these.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num101 > 0.0 || num100 > 0.0 || num99 > 0.0 || num98 > 0.0 || num97 > 0.0 || num36 > 0.0)
					{
						string text2 = "A Sensor Group may NOT have Illuminator Bands! Remove all of these.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num103 > 0.0)
					{
						string text2 = "A Sensor Group may NOT have Sensor Flags! Remove all of these.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num105 > 0.0)
					{
						string text2 = "A Sensor Group may NOT have Sensor Capabilities! Remove all of these.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else if (num54 != 0.0)
				{
					string text2 = "Remove all sensors from the Sensor Group list. Only Sensor Groups may have sensors in this list.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num64 == (double)num && num != 1001L)
				{
					string text2 = "A sensor can not masquerade as itself. Please Mask As to None.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num64 != 1001.0 && Conversions.ToDouble(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num64)["Type"]) != (double)num2)
				{
					string text2 = "A sensor can only masquerade as an identical sensor type. E.g. radar can not pretend to be an IR system.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 >= 5001L && num2 <= 6999L)
				{
					if (num36 > 0.0)
					{
						string text2 = "Sonar can not have illuminator frequency bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag77)
					{
						string text2 = "Sonars may not have the Identification flag set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag19 & (Conversions.ToDouble(text) == 5011.0 || Conversions.ToDouble(text) == 5902.0 || num2 == 5002L || num2 == 5003L || num2 == 5012L || num2 == 5013L || num2 == 5022L || num2 == 5023L || num2 == 5032L || num2 == 5033L))
					{
						string text2 = "Range Information capability must be for active sonar and passive ranging (flank array) sonar sets!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag19 & (((Conversions.ToDouble(text) != 5791.0) & (Conversions.ToDouble(text) != 5011.0) & (Conversions.ToDouble(text) != 5902.0)) && num2 != 5002L && num2 != 5003L && num2 != 5012L && num2 != 5013L && num2 != 5022L && num2 != 5023L && num2 != 5032L && num2 != 5033L))
					{
						string text2 = "Passive-only sensors (except passive ranging) sonar sets can not give Range Information";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 && (num2 == 5511L || num2 == 5521L || num2 == 5522L || num2 == 5523L))
					{
						string text2 = "Range-Only sonar can not have Speed Information capability";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && (num2 == 5511L || num2 == 5521L || num2 == 5522L || num2 == 5523L))
					{
						string text2 = "Range-Only sonar can not have Heading Information capability!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8 & (Conversions.ToDouble(text) != 5791.0 && num2 != 5002L && num2 != 5003L && num2 != 5012L && num2 != 5013L && num2 != 5022L && num2 != 5023L && num2 != 5032L && num2 != 5033L))
					{
						string text2 = "Passive-only sensors sonar sets can not give Speed Information";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag7 && flag8 && (num2 == 5002L || num2 == 5003L || num2 == 5012L || num2 == 5013L || num2 == 5022L || num2 == 5023L || num2 == 5032L || num2 == 5033L))
					{
						string text2 = "Speed Information capability is set, add Heading Information capability as well!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 && !flag8 && (num2 == 5002L || num2 == 5003L || num2 == 5012L || num2 == 5013L || num2 == 5022L || num2 == 5023L || num2 == 5032L || num2 == 5033L))
					{
						string text2 = "Heading Information capability is set, add Speed Information capability as well!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag7 & (Conversions.ToDouble(text) != 5791.0 && num2 != 5002L && num2 != 5003L && num2 != 5012L && num2 != 5013L && num2 != 5022L && num2 != 5023L && num2 != 5032L && num2 != 5033L))
					{
						string text2 = "Passive-only sonars can not give Heading Information";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag18 & (Conversions.ToDouble(text) != 5701.0) & (Conversions.ToDouble(text) != 5702.0) & (Conversions.ToDouble(text) != 5791.0)) && num2 != 5002L && num2 != 5003L && num2 != 5012L && num2 != 5013L && num2 != 5022L && num2 != 5023L && num2 != 5032L && num2 != 5033L)
					{
						string text2 = "Passive-only sensors sonar sets can not give Altitude (depth) Information";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag84 & (Conversions.ToDouble(text) == 5021.0 || Conversions.ToDouble(text) == 5111.0 || Conversions.ToDouble(text) == 5911.0))
					{
						string text2 = "Sensor role says Torpedo Warning but the sensor does not have Torpedo Warning Capability!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag83 & (Conversions.ToDouble(text) != 5091.0) & (Conversions.ToDouble(text) != 5092.0) & (Conversions.ToDouble(text) != 5093.0) & (Conversions.ToDouble(text) != 5094.0) & (Conversions.ToDouble(text) != 5095.0) & (Conversions.ToDouble(text) != 5097.0) & (Conversions.ToDouble(text) != 5098.0) & (Conversions.ToDouble(text) != 5099.0) & (Conversions.ToDouble(text) != 5271.0) & (Conversions.ToDouble(text) != 5272.0) & (Conversions.ToDouble(text) != 5273.0) & (Conversions.ToDouble(text) != 5274.0) & (Conversions.ToDouble(text) != 5391.0) & (Conversions.ToDouble(text) != 2791.0))
					{
						string text2 = "Sensor Capability says Mine and Obstacle Search but sensor role doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag83 & (Conversions.ToDouble(text) == 5091.0 || Conversions.ToDouble(text) == 5092.0 || Conversions.ToDouble(text) == 5093.0 || Conversions.ToDouble(text) == 5094.0 || Conversions.ToDouble(text) == 5095.0 || Conversions.ToDouble(text) == 5097.0 || Conversions.ToDouble(text) == 5098.0 || Conversions.ToDouble(text) == 5099.0 || Conversions.ToDouble(text) == 5271.0 || Conversions.ToDouble(text) == 5272.0 || Conversions.ToDouble(text) == 5273.0 || Conversions.ToDouble(text) == 5274.0 || Conversions.ToDouble(text) == 5391.0 || Conversions.ToDouble(text) == 2791.0))
					{
						string text2 = "Sensor Role says Mine and Obstacle Search but Mine and Obstacle Search Capability is not selected!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag83 && num26 > 1.0)
					{
						string text2 = "Mine avoidance, minehunter and obstacle avoidance sonar has a 1.0nm max range!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag83 && num76 != 0.0)
					{
						string text2 = "Mine avoidance, minehunter and obstacle avoidance sonar can not make CZ detections!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag83 && !flag19)
					{
						string text2 = "Mine avoidance, minehunter and obstacle avoidance sonar must have Range Information capability flag!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 2791.0 && num26 > 0.02)
					{
						string text2 = "Minehunter LLTV max range can not be greater than 0.02nm!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 2791.0 && num25 != 0.0)
					{
						string text2 = "Minehunter LLTV min range must be 0nm!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag78 && flag80)
					{
						string text2 = "Sensor Code says sensor is Classification capable but Shallow Water Capable (Full) code is not set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag78 & (Conversions.ToDouble(text) == 5094.0 || Conversions.ToDouble(text) == 5098.0 || Conversions.ToDouble(text) == 5099.0 || Conversions.ToDouble(text) == 5272.0 || Conversions.ToDouble(text) == 5273.0 || Conversions.ToDouble(text) == 5274.0 || Conversions.ToDouble(text) == 5332.0))
					{
						string text2 = "Sensor Role says Classification capable but Classification Code is not selected!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag78 & ((Conversions.ToDouble(text) != 5094.0) & (Conversions.ToDouble(text) != 5098.0) & (Conversions.ToDouble(text) != 5099.0) & (Conversions.ToDouble(text) != 5272.0) & (Conversions.ToDouble(text) != 5273.0) & (Conversions.ToDouble(text) != 5274.0) & (Conversions.ToDouble(text) != 5332.0)))
					{
						string text2 = "Sensor has Classification Code but sonar role is not Classification capable!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((!flag79 && !flag80) & (Conversions.ToDouble(text) == 5093.0 || Conversions.ToDouble(text) == 5094.0 || Conversions.ToDouble(text) == 5098.0 || Conversions.ToDouble(text) == 5099.0 || Conversions.ToDouble(text) == 5272.0 || Conversions.ToDouble(text) == 5273.0 || Conversions.ToDouble(text) == 5274.0 || Conversions.ToDouble(text) == 5332.0 || Conversions.ToDouble(text) == 5702.0 || Conversions.ToDouble(text) == 5712.0 || Conversions.ToDouble(text) == 5714.0 || Conversions.ToDouble(text) == 5722.0))
					{
						string text2 = "Sensor Role says Shallow Water capable but Shallow Water Capable code is not selected!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag79 || flag80) & ((Conversions.ToDouble(text) != 5093.0) & (Conversions.ToDouble(text) != 5094.0) & (Conversions.ToDouble(text) != 5098.0) & (Conversions.ToDouble(text) != 5099.0) & (Conversions.ToDouble(text) != 5272.0) & (Conversions.ToDouble(text) != 5273.0) & (Conversions.ToDouble(text) != 5274.0) & (Conversions.ToDouble(text) != 5332.0) & (Conversions.ToDouble(text) != 5702.0) & (Conversions.ToDouble(text) != 5712.0) & (Conversions.ToDouble(text) != 5714.0) & (Conversions.ToDouble(text) != 5722.0)))
					{
						string text2 = "Sensor code says Shallow Water capable but sonar role doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag79 && flag80)
					{
						string text2 = "Sonar can only have one Shallow Water code!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 != 0.0 && num2 == 5101L)
					{
						string text2 = "MAD systems can not have sonar search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 != 0.0 && num2 >= 6001L && num2 < 6999L)
					{
						string text2 = "Mine sweep systems can not have search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 != 1.0 && num2 != 5901L && num2 != 5101L && num2 < 6001L)
					{
						string text2 = "Sonar shall have one frequency seach band!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num87 != 0.0)
					{
						string text2 = "Sonar may not have Radio-frequency search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num90 != 0.0)
					{
						string text2 = "Sonar may not have Laser-frequency search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num88 != 0.0)
					{
						string text2 = "Sonar may not have Visual search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num89 != 0.0)
					{
						string text2 = "Sonar may not have Infrared search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num86 != 0.0)
					{
						string text2 = "Sonar may not have Radar frequency search bands!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 == 0.0 && num2 != 5101L && num2 < 6001L)
					{
						string text2 = "Sonar must have a Sonar search band!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 >= 5001L && num2 <= 5009L) & (Conversions.ToDouble(text) < 5001.0 || Conversions.ToDouble(text) > 5799.0) & ((Conversions.ToDouble(text) > 5099.0) & (Conversions.ToDouble(text) <= 5401.0)))
					{
						string text2 = "Sonar type says Hull Sonar, sonar role must be Hull Sonar orelse Sonobuoy!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5001L) & ((Conversions.ToDouble(text) != 5791.0) & (Conversions.ToDouble(text) != 5001.0) & (Conversions.ToDouble(text) != 5002.0) & (Conversions.ToDouble(text) != 5011.0) & (Conversions.ToDouble(text) != 5021.0) & (Conversions.ToDouble(text) != 5501.0) & (Conversions.ToDouble(text) != 5502.0) & (Conversions.ToDouble(text) != 5507.0) & (Conversions.ToDouble(text) != 5508.0) & (Conversions.ToDouble(text) != 5509.0) & (Conversions.ToDouble(text) != 5701.0) & (Conversions.ToDouble(text) != 5702.0) & (Conversions.ToDouble(text) != 5402.0)))
					{
						string text2 = "Sonar type says Passive-Only Hull Sonar, sonar role must match (Hull, Sonobuoy orelse Torpedo roles)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5002L) & ((Conversions.ToDouble(text) != 5031.0) & (Conversions.ToDouble(text) != 5032.0) & (Conversions.ToDouble(text) != 5033.0) & (Conversions.ToDouble(text) != 5034.0) & (Conversions.ToDouble(text) != 5041.0) & (Conversions.ToDouble(text) != 5511.0) & (Conversions.ToDouble(text) != 5512.0) & (Conversions.ToDouble(text) != 5711.0) & (Conversions.ToDouble(text) != 5712.0) & (Conversions.ToDouble(text) != 5713.0) & (Conversions.ToDouble(text) != 5714.0)))
					{
						string text2 = "Sonar type says Active / Passive Hull Sonar, sonar role must match (Hull, Sonobuoy orelse Torpedo roles)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5003L) & ((Conversions.ToDouble(text) != 5061.0) & (Conversions.ToDouble(text) != 5062.0) & (Conversions.ToDouble(text) != 5063.0) & (Conversions.ToDouble(text) != 5064.0) & (Conversions.ToDouble(text) != 5071.0) & (Conversions.ToDouble(text) != 5072.0) & (Conversions.ToDouble(text) != 5081.0) & (Conversions.ToDouble(text) != 5082.0) & (Conversions.ToDouble(text) != 5083.0) & (Conversions.ToDouble(text) != 5091.0) & (Conversions.ToDouble(text) != 5092.0) & (Conversions.ToDouble(text) != 5093.0) & (Conversions.ToDouble(text) != 5094.0) & (Conversions.ToDouble(text) != 5095.0) & (Conversions.ToDouble(text) != 5096.0) & (Conversions.ToDouble(text) != 5097.0) & (Conversions.ToDouble(text) != 5098.0) & (Conversions.ToDouble(text) != 5099.0) & (Conversions.ToDouble(text) != 5521.0) & (Conversions.ToDouble(text) != 5522.0) & (Conversions.ToDouble(text) != 5523.0) & (Conversions.ToDouble(text) != 5527.0) & (Conversions.ToDouble(text) != 5528.0) & (Conversions.ToDouble(text) != 5529.0) & (Conversions.ToDouble(text) != 5721.0) & (Conversions.ToDouble(text) != 5722.0)))
					{
						string text2 = "Sonar type says Active-Only Hull Sonar, sonar role must match (Hull, Sonobuoy orelse Torpedo roles)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5501.0) & (Conversions.ToDouble(text) <= 5599.0)) && (num2 < 5001L || num2 > 5009L))
					{
						string text2 = "Sonar role says Sonobuoy, sensor type must also be Hull Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5001.0) & (Conversions.ToDouble(text) <= 5099.0)) && (num2 < 5001L || num2 > 5009L))
					{
						string text2 = "Sonar role says Hull Sonar, sensor type must also be Hull Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5402.0 && (num2 < 5001L || num2 > 5009L))
					{
						string text2 = "Sonar role says Moored Sonobuoy, sensor type must also be Hull Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5701.0) & (Conversions.ToDouble(text) <= 5799.0)) && (num2 < 5001L || num2 > 5009L))
					{
						string text2 = "Sonar role says Moored Sonobuoy, sensor type must also be Hull Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5401.0 && num2 != 5041L)
					{
						string text2 = "Sonar role says SOSUS, sensor type must be Bottom Fixed Sonar, Passive-Only!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) != 5401.0 && num2 == 5041L)
					{
						string text2 = "Sonar type says Bottom Fixed Sonar, sonar role should be SOSUS!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 >= 5011L && num2 <= 5019L) & (Conversions.ToDouble(text) < 5101.0 || Conversions.ToDouble(text) > 5199.0))
					{
						string text2 = "Sonar type says TASS Sonar, sonar role must be a TASS!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5011L) & ((Conversions.ToDouble(text) != 5101.0) & (Conversions.ToDouble(text) != 5102.0) & (Conversions.ToDouble(text) != 5103.0) & (Conversions.ToDouble(text) != 5104.0) & (Conversions.ToDouble(text) != 5111.0) & (Conversions.ToDouble(text) != 5191.0)))
					{
						string text2 = "Sonar type says Passive-Only Towed Array Sonar, sonar role must match (TASS, SURTASS)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5012L) & ((Conversions.ToDouble(text) != 5131.0) & (Conversions.ToDouble(text) != 5132.0) & (Conversions.ToDouble(text) != 5192.0)))
					{
						string text2 = "Sonar type says Active / Passive Towed Array Sonar, sonar role must match (TASS, SURTASS)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5013L) & ((Conversions.ToDouble(text) != 5161.0) & (Conversions.ToDouble(text) != 5193.0)))
					{
						string text2 = "Sonar type says Active-Only Towed Array Sonar, sonar role must match (TASS, SURTASS)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5101.0) & (Conversions.ToDouble(text) <= 5199.0)) && (num2 < 5011L || num2 > 5019L))
					{
						string text2 = "Sonar role says TASS, sensor type must be a TASS!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 >= 5021L && num2 <= 5029L) & (Conversions.ToDouble(text) < 5201.0 || Conversions.ToDouble(text) > 5299.0))
					{
						string text2 = "Sonar type says VDS Sonar, sonar role must be a VDS!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5201.0) & (Conversions.ToDouble(text) <= 5299.0)) && (num2 < 5021L || num2 > 5029L))
					{
						string text2 = "Sonar role says VDS Sonar, sensor type must be a VDS!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5021L) & (Conversions.ToDouble(text) != 5201.0))
					{
						string text2 = "Sonar type says Passive-Only VDS, sonar role must match (VDS)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5022L) & (Conversions.ToDouble(text) != 5231.0))
					{
						string text2 = "Sonar type says Active / Passive VDS, sonar role must match (VDS)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5023L) & ((Conversions.ToDouble(text) != 5261.0) & (Conversions.ToDouble(text) != 5271.0) & (Conversions.ToDouble(text) != 5272.0) & (Conversions.ToDouble(text) != 5273.0) & (Conversions.ToDouble(text) != 5274.0)))
					{
						string text2 = "Sonar type says Active-Only, sonar role must match (VDS)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 >= 5031L && num2 <= 5039L) & (Conversions.ToDouble(text) < 5301.0 || Conversions.ToDouble(text) > 5399.0))
					{
						string text2 = "Sonar type says Dipping Sonar, sonar role must be a Dipping Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5301.0) & (Conversions.ToDouble(text) <= 5399.0)) && (num2 < 5031L || num2 > 5039L))
					{
						string text2 = "Sonar role says Dipping Sonar, sensor type must be a Dipping Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5031L) & (Conversions.ToDouble(text) != 5301.0))
					{
						string text2 = "Sonar type says Passive-only Dipping Sonar, sonar role must match (Dipping Sonar)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5032L) & ((Conversions.ToDouble(text) != 5331.0) & (Conversions.ToDouble(text) != 5332.0)))
					{
						string text2 = "Sonar type says Active / Passive-only Dipping Sonar, sonar role must match (Dipping Sonar)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5033L) & ((Conversions.ToDouble(text) != 5361.0) & (Conversions.ToDouble(text) != 5391.0)))
					{
						string text2 = "Sonar type says Active-only Dipping Sonar, sonar role must match (Dipping Sonar)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5801.0 && num2 != 5101L)
					{
						string text2 = "Sonar role says MAD, sensor type must be MAD!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) != 5801.0 && num2 == 5101L)
					{
						string text2 = "Sonar type says MAD, sensor role should be MAD!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 5901L) & (Conversions.ToDouble(text) < 5901.0 || Conversions.ToDouble(text) > 5999.0))
					{
						string text2 = "Sonar type says Ping Intercept, sensor role must be a Ping Intercept!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 5901.0) & (Conversions.ToDouble(text) <= 5999.0)) && num2 != 5901L)
					{
						string text2 = "Sonar role says Ping Intercept, sensor type must be a Ping Intercept!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6001.0 || Conversions.ToDouble(text) == 6011.0) && num2 != 6001L)
					{
						string text2 = "Sonar role says Mechanical Cable Cutter, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6001L) & ((Conversions.ToDouble(text) != 6001.0) & (Conversions.ToDouble(text) != 6011.0)))
					{
						string text2 = "Sonar role says Mechanical Cable Cutter, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6002.0 || Conversions.ToDouble(text) == 6012.0) && num2 != 6002L)
					{
						string text2 = "Sonar role says Magnetic Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6002L) & ((Conversions.ToDouble(text) != 6002.0) & (Conversions.ToDouble(text) != 6012.0)))
					{
						string text2 = "Sonar role says Magnetic Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6003.0 || Conversions.ToDouble(text) == 6013.0) && num2 != 6003L)
					{
						string text2 = "Sonar role says Acoustic Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6003L) & ((Conversions.ToDouble(text) != 6003.0) & (Conversions.ToDouble(text) != 6013.0)))
					{
						string text2 = "Sonar role says Acoustic Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6004.0 || Conversions.ToDouble(text) == 6014.0) && num2 != 6004L)
					{
						string text2 = "Sonar role says Multi-Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6004L) & ((Conversions.ToDouble(text) != 6004.0) & (Conversions.ToDouble(text) != 6014.0)))
					{
						string text2 = "Sonar role says Multi-Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 6009.0 && num2 != 6009L)
					{
						string text2 = "Sonar role says Two-Ship Magnetic Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6009L) & (Conversions.ToDouble(text) != 6009.0))
					{
						string text2 = "Sonar role says Two-Ship Magnetic Influence Sweep, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 6021.0 && num2 != 6021L)
					{
						string text2 = "Sonar role says Moored Mine Cable Cutter, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6021L) & (Conversions.ToDouble(text) != 6021.0))
					{
						string text2 = "Sonar role says Moored Mine Cable Cutter, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 6022.0 && num2 != 6022L)
					{
						string text2 = "Sonar role says Moored Mine Cable Cutter, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6022L) & (Conversions.ToDouble(text) != 6022.0))
					{
						string text2 = "Sonar role says Moored Mine Cable Cutter, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 6022.0 && num2 != 6022L)
					{
						string text2 = "Sonar role says Diver-deployed Explosive Charge, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num2 == 6022L) & (Conversions.ToDouble(text) != 6022.0))
					{
						string text2 = "Sonar role says Diver-deployed Explosive Charge, sensor type must match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 6001.0) & (Conversions.ToDouble(text) <= 6019.0)) && num77 <= 0.0)
					{
						string text2 = "Sweep Gear need Sweep Width set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) < 6001.0 || Conversions.ToDouble(text) > 6019.0) && num77 > 0.0)
					{
						string text2 = "Mine Sweep Width can only be for mine sweep gear!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6001.0 || Conversions.ToDouble(text) == 6011.0) && num78 >= 0.0)
					{
						string text2 = "Mechanical cable cutters need Minimum Sweep Depth (negative value)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) != 6001.0) & (Conversions.ToDouble(text) != 6011.0)) && num78 != 0.0)
					{
						string text2 = "Mine Sweep Minimum Depth can only be for mechanical cable cutters!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6001.0 || Conversions.ToDouble(text) == 6011.0) && num79 >= 0.0)
					{
						string text2 = "Mechanical cable cutters need Sweep Minimum Sweep Depth (negative value)!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) != 6001.0) & (Conversions.ToDouble(text) != 6011.0)) && num79 != 0.0)
					{
						string text2 = "Mine Sweep Maximum Depth can only be for mechanical cable cutters!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((Conversions.ToDouble(text) >= 6001.0) & (Conversions.ToDouble(text) <= 6019.0)) && num80 <= 0.0)
					{
						string text2 = "Sweep Gear need Maximum Sweep Speed set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) < 6001.0 || Conversions.ToDouble(text) > 6019.0) && num80 > 0.0)
					{
						string text2 = "Mine Sweep Maximum Speed can only be for mine sweep gear!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((Conversions.ToDouble(text) == 6001.0 || Conversions.ToDouble(text) == 6011.0) && num78 >= num79)
					{
						string text2 = "Mine Sweep Max Depth can not be greater than Min Depth!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num60 != 180.0 && (num2 == 5511L || num2 == 5521L || num2 == 5522L || num2 == 5523L))
					{
						string text2 = "Range-Only sonar must have an Angle Resolution of 180 deg";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num60 <= 0.0 && ((num2 > 5000L && num2 <= 5099L) || num2 == 5901L))
					{
						string text2 = "All sonar sets needs Angle Resolution set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((num2 == 5901L) & (Conversions.ToDouble(text) != 5902.0) & (Conversions.ToDouble(text) != 5911.0)) && num105 != 0.0)
					{
						string text2 = "Ping Intercept systems can not have any Capabilities set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5902.0 && num105 != 1.0)
					{
						string text2 = "Ranging Ping Intercept systems can not have any Capabilities except Range Information set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5911.0 && num105 != 1.0)
					{
						string text2 = "Ping Intercept And Torpedo Warning systems can not have any Capabilities except Torpedo Warning set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5902.0 && !flag19)
					{
						string text2 = "Ranging Ping Intercept systems must have Range Information set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (Conversions.ToDouble(text) == 5911.0 && !flag84)
					{
						string text2 = "Ping Intercept And Torpedo Warning systems must have Torpedo Warning set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num74 >= 0.0 && num2 >= 5011L && num2 <= 5099L)
					{
						string text2 = "TASS, VDS, SOSUS and Dipping Sonars need a Minimum Deployment Depth";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num75 >= 0.0 && num2 >= 5011L && num2 <= 5099L)
					{
						string text2 = "TASS, VDS, SOSUS and Dipping Sonars need a Maximum Deployment Depth";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num74 >= 0.0) & ((Conversions.ToDouble(text) >= 5501.0) & (Conversions.ToDouble(text) <= 5599.0)))
					{
						string text2 = "Sonobuoys need a Minimum Deployment Depth.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num75 >= 0.0) & ((Conversions.ToDouble(text) >= 5501.0) & (Conversions.ToDouble(text) <= 5599.0)))
					{
						string text2 = "Sonobuoys need a Maximum Deployment Depth.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num74 > num75 && (num74 != 0.0 || num75 != 0.0))
					{
						string text2 = "Minimum Deployment Depth can not be greater than Maximum Deployment Depth";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((num75 != 0.0) & (Conversions.ToDouble(text) < 5301.0 && num2 > 5399L)) && num2 < 5011L && num2 > 5099L)
					{
						string text2 = "Hull sonars must have Maximum Deployment Depth to 0";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((num74 != 0.0) & (Conversions.ToDouble(text) < 5301.0 && num2 > 5399L)) && num2 < 5011L && num2 > 5099L)
					{
						string text2 = "Hull sonars must have Minimum Deployment Depth to 0";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num60 != 180.0) & (Conversions.ToDouble(text) == 5501.0 || Conversions.ToDouble(text) == 5511.0 || Conversions.ToDouble(text) == 5521.0 || Conversions.ToDouble(text) == 5522.0 || Conversions.ToDouble(text) == 5523.0))
					{
						string text2 = "Role says omni-directional sonobuoy. Angle Resolution to 180 deg.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num29 <= 0.0 && ((num2 > 5000L && num2 <= 5099L) || num2 == 5901L))
					{
						string text2 = "All sonars need the Scan Interval set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					int num109;
					if (num65 != 0.0)
					{
						string text2 = "Do not use DF Accuracy for sonars, use Resolution Angle instead!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						num109 = 0;
					}
					else
					{
						num109 = 0;
					}
					bool flag85 = (byte)num109 != 0;
					bool flag86 = false;
					bool flag87 = false;
					bool flag88 = false;
					if (Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag85 = true;
					}
					if (Common.get_DataSubmarineSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag86 = true;
					}
					if (Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag87 = true;
					}
					if (Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num)).Length != 0)
					{
						flag88 = true;
					}
					if ((!flag9 & (Conversions.ToDouble(text) != 5021.0) & (Conversions.ToDouble(text) != 5901.0) & (Conversions.ToDouble(text) != 5902.0) & (Conversions.ToDouble(text) != 5903.0) & (Conversions.ToDouble(text) != 5911.0)) && ((Conversions.ToDouble(text) < 6001.0) & (Conversions.ToDouble(text) > 6099.0)))
					{
						string text2 = "Sonar needs Submarine Search capability.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 & (Conversions.ToDouble(text) == 5034.0 || Conversions.ToDouble(text) == 5064.0 || Conversions.ToDouble(text) == 5072.0 || Conversions.ToDouble(text) == 5081.0 || Conversions.ToDouble(text) == 5082.0 || Conversions.ToDouble(text) == 5801.0))
					{
						string text2 = "Sonar role says sensor shall not be Surface Search capable.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11 && flag85)
					{
						string text2 = "Ship-based sonar can not be Surface Search Capable.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag86 && !flag11 && num2 != 5901L && num2 < 6001L) & ((Conversions.ToDouble(text) != 5081.0) & (Conversions.ToDouble(text) != 5082.0) & (Conversions.ToDouble(text) != 5083.0) & (Conversions.ToDouble(text) != 5091.0) & (Conversions.ToDouble(text) != 5092.0) & (Conversions.ToDouble(text) != 5093.0) & (Conversions.ToDouble(text) != 5094.0) & (Conversions.ToDouble(text) != 5095.0) & (Conversions.ToDouble(text) != 5096.0) & (Conversions.ToDouble(text) != 5097.0) & (Conversions.ToDouble(text) != 5098.0) & (Conversions.ToDouble(text) != 5099.0) & (Conversions.ToDouble(text) != 5271.0)))
					{
						string text2 = "Sonar should be Surface Search capable!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag85 && flag86 && num2 != 5901L && num2 < 6001L)
					{
						string text2 = "Sonar is used by both ships and subs, pretty weird!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag85 && flag87)
					{
						string text2 = "Sonar is used by both ships and aircraft, pretty weird!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag85 && flag88)
					{
						string text2 = "Sonar is used by both ships and weapons (torpedoes orelse sonobuoys), pretty weird!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag86 && flag87)
					{
						string text2 = "Sonar is used by both submarines and aircraft, pretty weird!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag86 && flag88) & (Conversions.ToDouble(text) != 5098.0))
					{
						string text2 = "Sonar is used by both submarines and weapons (torpedoes orelse sonobuoys), pretty weird!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag87 && flag88 && num2 != 5101L)
					{
						string text2 = "Sonar is used by both aircraft and weapons (torpedoes orelse sonobuoys), pretty weird!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag87 && num2 != 5031L && num2 != 5032L && num2 != 5033L && num2 != 5101L)
					{
						string text2 = "Helicopters can only carry sonars for type Dipping Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag85 && (num2 == 5031L || num2 == 5032L || num2 == 5033L))
					{
						string text2 = "Ships can not carry sonars ot type Dipping Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag86 && num2 == 5101L)
					{
						string text2 = "Ships can not carry MAD!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag86 && (num2 == 5031L || num2 == 5032L || num2 == 5033L))
					{
						string text2 = "Submarines can not carry sonars ot type Dipping Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag86 && num2 == 5101L)
					{
						string text2 = "Submarines can not carry MAD!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag86 && (num2 == 5021L || num2 == 5022L || num2 == 5023L)) & (Conversions.ToDouble(text) != 5271.0))
					{
						string text2 = "Submarines can not carry sonars ot type VDS!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (((flag88 && num2 != 5001L && num2 != 5002L && num2 != 5003L && num2 != 5101L) & (Conversions.ToDouble(text) != 5391.0)) && num2 < 6001L)
					{
						string text2 = "Weapons can only carry sonars for type Hull Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag40 & (((Conversions.ToDouble(text) >= 5091.0) & (Conversions.ToDouble(text) <= 5099.0)) || ((Conversions.ToDouble(text) >= 5271.0) & (Conversions.ToDouble(text) <= 5274.0)) || Conversions.ToDouble(text) == 5391.0))
					{
						string text2 = "Mine avoidance/hunting sonar must have the HF band set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag42 || flag41 || flag39) & (((Conversions.ToDouble(text) >= 5091.0) & (Conversions.ToDouble(text) <= 5099.0)) || ((Conversions.ToDouble(text) >= 5271.0) & (Conversions.ToDouble(text) <= 5274.0)) || Conversions.ToDouble(text) == 5391.0))
					{
						string text2 = "Mine avoidance/hunting sonar can only have the HF band set!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num76 != 0.0 && num26 < 30.0)
					{
						string text2 = "Sonar range is less than 30nm, so the CZ Number should be 0!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num76 != 1.0 && num26 >= 30.0 && num26 < 70.0)
					{
						string text2 = "Sonar range 30-70nm, so the CZ Number should be 1!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num76 != 2.0 && num26 >= 70.0 && num26 < 100.0)
					{
						string text2 = "Sonar range 70-100nm, so the CZ Number should be 2!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num76 != 3.0 && num26 >= 100.0 && num26 < 130.0)
					{
						string text2 = "Sonar range 100-130nm, so the CZ Number should be 3!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num76 < 4.0 && num26 >= 130.0)
					{
						string text2 = "Sonar range is greater than 130nm, so the CZ Number should be greater than 4!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag39 && num39 < 500.0 && num39 != 0.0)
					{
						string text2 = "Lowest frequency is less than 500kHz, the frequency band should VLF Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag42 && num39 < 5000.0 && num39 >= 500.0 && num39 != 0.0)
					{
						string text2 = "Lowest frequency is less than 5kHz, the frequency band should LF Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (!flag41 && num39 < 10000.0 && num39 >= 5000.0 && num39 != 0.0)
					{
						string text2 = "Lowest frequency is less than 10kHz, the frequency band should MF Sonar!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (!flag65 && !flag66 && !flag68)
				{
					string text2 = "Completed sensors need standard arcs set!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num2 == 3001L)
				{
					if (flag7)
					{
						string text2 = "ESM can not have the Heading Information Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag18)
					{
						string text2 = "ESM can not have the Altitude Information Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8)
					{
						string text2 = "ESM can not have the Speed Information Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15)
					{
						string text2 = "ESM can not have the Navigation Only Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag21)
					{
						string text2 = "ESM can not have the Navigation And Weather Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag20)
					{
						string text2 = "ESM can not have the Weather Only Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag23)
					{
						string text2 = "ESM can not have the Ground Mapping Only Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag22)
					{
						string text2 = "ESM can not have the Terrain Avoidance orelse Following Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag16)
					{
						string text2 = "ESM can not have the Air Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11)
					{
						string text2 = "ESM can not have the Surface Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9)
					{
						string text2 = "ESM can not have the Sub Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag14)
					{
						string text2 = "ESM can not have the Land Search - Fixed Failicty Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13)
					{
						string text2 = "ESM can not have the Land Search - Mobile Unit Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12)
					{
						string text2 = "ESM can not have the Space Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num21 > 0.0 || num22 > 0.0 || num22 > 0.0)
					{
						string text2 = "Air, Surface and Sub Max Contacts must be 0 for ESM. Use Number Of Channels field instead.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num23 > 0.0)
					{
						string text2 = "ESM can not have Radar flags.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num24 > 0.0)
					{
						string text2 = "ESM can not have Radar flags.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num25 >= num26)
					{
						string text2 = "Sensor min range is greater orelse equal to max range. Not logical.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num27 >= num28 && num27 != 0.0)
					{
						string text2 = "Sensor min altitude is greater orelse equal to max altitude. Not logical.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num29 <= 0.0)
					{
						string text2 = "Scan Interval must be 1 orelse greater for ESM systems - 1-2 sec for RWR and 10-15 sec for ESM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num30 - num31 > num32 && num32 > 0.0)
					{
						string text2 = "Sensor is ESM with gaps in the Search Bands. This is not possible.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num93 - num92 > num87 && num87 > 0.0)
					{
						string text2 = "Sensor is COMINT with gaps in the Radio Bands. This is not possible.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 == 0.0 && num87 == 0.0 && num90 == 0.0)
					{
						string text2 = "Sensor is ESM with no valid Search/Track Bands. It must have at least one.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 > 0.0)
					{
						string text2 = "Sensor is ESM with Illuminator Bands. Remove all Illumnator Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num88 > 0.0)
					{
						string text2 = "Sensor is ESM with Visual Bands. Remove all Visual Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num89 > 0.0)
					{
						string text2 = "Sensor is ESM with IR Bands. Remove all IR Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 > 0.0)
					{
						string text2 = "Sensor is ESM with Sonar Bands. Remove all Sonar Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > num38 && num37 != 0.0 && num32 > 0.0)
					{
						string text2 = "Sensors Upper Search Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 < num40 && num39 != 0.0 && num32 > 0.0)
					{
						string text2 = "Sensors Lower Search Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > num95 && num37 != 0.0 && num87 > 0.0)
					{
						string text2 = "Sensors Upper Radio Frequency is outside the radio Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 < num94 && num39 != 0.0 && num87 > 0.0)
					{
						string text2 = "Sensors Lower Radio Frequency is outside the radio Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 > num41 && num8 != 0.0)
					{
						string text2 = "Sensors Upper Illuminator Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num9 < num42 && num9 != 0.0)
					{
						string text2 = "Sensors Lower Illuminator Frequency is outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 > num37)
					{
						string text2 = "Sensors Lower Frequency is higher than the Upper Frequency.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > 0.0 && num39 == 0.0)
					{
						string text2 = "Only the Upper Frequency is filled in. Lower Frequency is also required.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag24)
					{
						string text2 = "ESM can not operate in the Visual Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag25 || flag26)
					{
						string text2 = "ESM can not operate in the IR Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag39 || flag40 || flag41 || flag42)
					{
						string text2 = "ESM can not operate in the Sonar Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag43)
					{
						string text2 = "ESM can not operate in the Visual Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag44 || flag45)
					{
						string text2 = "ESM can not operate in the IR Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag46)
					{
						string text2 = "ESM can not operate in the Laser Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag58 || flag59 || flag60 || flag61)
					{
						string text2 = "ESM can not operate in the Sonar Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num44 != 0.0)
					{
						string text2 = "The Search/Track Blind Time for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 0.0)
					{
						string text2 = "Search/Track Horizontal Beamwidth for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num50 != 0.0)
					{
						string text2 = "Search/Track Horizontal Beamwidth for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num49 != 0.0)
					{
						string text2 = "Search/Track System Noise Level for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num48 != 0.0)
					{
						string text2 = "Search/Track Processing Gain/Loss Level for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num47 != 0.0)
					{
						string text2 = "Search/Track Peak Power for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num46 != 0.0)
					{
						string text2 = "Search/Track Pulse Length for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num45 != 0.0)
					{
						string text2 = "Search/Track PRF for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 != 0.0)
					{
						string text2 = "Search/Track Blind Time for ESM must be 0..";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num16 != 0.0)
					{
						string text2 = "Illumnator Horizontal Beamwidth for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num15 != 0.0)
					{
						string text2 = "Illumnator Horizontal Beamwidth for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num62 != 0.0)
					{
						string text2 = "Max Contacts Illumination for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num14 != 0.0)
					{
						string text2 = "System Noise Level for ESM must be 0..";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num13 != 0.0)
					{
						string text2 = "Illumnator Processing Gain/Loss Level for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 != 0.0)
					{
						string text2 = "Illumnator Peak Power for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 != 0.0)
					{
						string text2 = "Illumnator Pulse Length for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 != 0.0)
					{
						string text2 = "Illumnator PRF for ESM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num65 <= 0.0)
					{
						string text2 = "Direction Finding Accuracy for ESM must be greater than 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num66 > -30.0 && num32 > 0.0 && num87 > 0.0)
					{
						string text2 = "ESM Sensitivity must be greater than -30.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num67 <= 0.0 && num32 > 0.0 && num87 > 0.0)
					{
						string text2 = "ESM System Loss must be greater than 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num68 < 0.0)
					{
						string text2 = "ESM Number Of Channels cannot be a negative number.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num73 != 0.0)
					{
						string text2 = "ECM Number Of Targets must be 0 for ESM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num69 != 0.0)
					{
						string text2 = "ECM Gain must be 0 for ESM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num70 != 0.0)
					{
						string text2 = "ECM Peak Power must be 0 for ESM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num71 != 0.0)
					{
						string text2 = "ECM Bandwidth must be 0 for ESM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num72 != 0.0)
					{
						string text2 = "ECM PoK Reduction must be 0 for ESM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 == 1001.0)
					{
						string text2 = "ESM must have a role.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 < 3000.0 || num63 > 3999.0)
					{
						string text2 = "The ESM role is invalid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num65 > 3.0 && (num63 == 3012.0 || num63 == 3032.0))
					{
						string text2 = "Role says ELINT w/ OTH targeting but DF Accuracy is greater than 3 deg. Makes no sense.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num26 > 200.0 && num63 == 3001.0)
					{
						string text2 = "RWRs should have a max range of 200nm.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num26 < 100.0 && (num63 == 3011.0 || num63 == 3012.0 || num63 == 3032.0 || num63 == 3021.0 || num63 == 3031.0 || num63 == 3041.0))
					{
						string text2 = "SIGINT systems should have a range between 150nm and 800nm.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num26 > 800.0 && num63 == 3101.0)
					{
						string text2 = "Radio Direction Finder should have a range of max 800nm.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num63 == 3012.0 || num63 == 3032.0) && !flag81 && !flag82)
					{
						string text2 = "ELINT systems with OTH Targeting capability should have Backscatter orelse Surface Wave flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 < 2000L || num3 >= 2099L)
					{
						string text2 = "The ESM Generation is invalid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				if (num2 == 3002L)
				{
					if (flag7)
					{
						string text2 = "ECM can not have the Heading Information Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag18)
					{
						string text2 = "ECM can not have the Altitude Information Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag8)
					{
						string text2 = "ECM can not have the Speed Information Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag15)
					{
						string text2 = "ECM can not have the Navigation Only Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag21)
					{
						string text2 = "ECM can not have the Navigation And Weather Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag20)
					{
						string text2 = "ECM can not have the Weather Only Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag23)
					{
						string text2 = "ECM can not have the Ground Mapping Only Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag22)
					{
						string text2 = "ECM can not have the Terrain Avoidance orelse Following Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag16)
					{
						string text2 = "ECM can not have the Air Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag11)
					{
						string text2 = "ECM can not have the Surface Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag9)
					{
						string text2 = "ECM can not have the Sub Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag14)
					{
						string text2 = "ECM can not have the Land Search - Fixed Failicty Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag13)
					{
						string text2 = "ECM can not have the Land Search - Mobile Unit Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag12)
					{
						string text2 = "ECM can not have the Space Search Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag81)
					{
						string text2 = "ECM can not have the Backscatter Capability flag set.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num21 > 0.0 || num22 > 0.0 || num22 > 0.0)
					{
						string text2 = "Air, Surface and Sub Max Contacts must be 0 for ECM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num23 > 0.0)
					{
						string text2 = "ECM can not have Radar flags.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num24 > 0.0)
					{
						string text2 = "ECM can not have Radar flags.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num25 != 0.0)
					{
						string text2 = "Minimum sensor range for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num26 != 0.0)
					{
						string text2 = "Maximum sensor range for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num27 != 0.0)
					{
						string text2 = "Maximum sensor altitude for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num28 != 0.0)
					{
						string text2 = "Maximum sensor altitude for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num29 != 0.0)
					{
						string text2 = "Scan Interval must be 0 for ECM systems.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num30 - num31 >= num32 && num32 > 0.0)
					{
						string text2 = "Sensor is ECM with gaps in the Radar Search Bands. This is not possible.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num93 - num92 >= num87 && num87 > 0.0)
					{
						string text2 = "Sensor is ECM / COMINT jammer with gaps in the Radio Bands. This is not possible.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num32 == 0.0 && num87 == 0.0 && num63 != 4041.0)
					{
						string text2 = "Sensor is ECM with no valid Search/Track Bands. It must have at least one.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num36 > 0.0)
					{
						string text2 = "Sensor is ECM with Illuminator Bands. Remove all Illumnator Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num88 > 0.0)
					{
						string text2 = "Sensor is ECM with Visual Bands. Remove all Visual Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num89 > 0.0 && num63 != 4041.0)
					{
						string text2 = "Sensor is a non-IRCM ECM system with IR Bands. Remove all IR Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num89 == 0.0 && num63 == 4041.0)
					{
						string text2 = "Sensor is a IRCM ECM system with NO IR Bands. Add IR Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num91 > 0.0)
					{
						string text2 = "Sensor is ECM with Sonar Bands. Remove all Sonar Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > num38 && num37 != 0.0 && num32 > 0.0)
					{
						string text2 = "Sensor is ECM with Upper Search Frequency outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 < num40 && num39 != 0.0 && num32 > 0.0)
					{
						string text2 = "Sensor is ECM with Lower Search Frequency outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > num95 && num37 != 0.0 && num87 > 0.0)
					{
						string text2 = "Sensor is ECM with Upper Radio Frequency outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 < num94 && num39 != 0.0 && num87 > 0.0)
					{
						string text2 = "Sensor is ECM with Lower Radio Frequency outside the sensors Bands.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num39 > num37)
					{
						string text2 = "Sensors Lower Frequency is higher than the Upper Frequency.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num37 > 0.0 && num39 == 0.0)
					{
						string text2 = "Only the Upper Frequency is filled in. Lower Frequency is also required.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag24)
					{
						string text2 = "ECM can not operate in the Visual Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag27)
					{
						string text2 = "ECM can not operate in the Laser Search/Track Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag43)
					{
						string text2 = "ECM can not operate in the Visual Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag44 || flag45)
					{
						string text2 = "ECM can not operate in the IR Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag46)
					{
						string text2 = "ECM can not operate in the Laser Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag58 || flag59 || flag60 || flag61)
					{
						string text2 = "ECM can not operate in the Sonar Illuminator Band.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num44 != 0.0)
					{
						string text2 = "The Search/Track Blind Time for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num33 != 0.0)
					{
						string text2 = "Search/Track Horizontal Beamwidth for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num50 != 0.0)
					{
						string text2 = "Search/Track Horizontal Beamwidth for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num49 != 0.0)
					{
						string text2 = "Search/Track System Noise Level for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num48 != 0.0)
					{
						string text2 = "Search/Track Processing Gain/Loss Level for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num47 != 0.0)
					{
						string text2 = "Search/Track Peak Power for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num46 != 0.0)
					{
						string text2 = "Search/Track Pulse Length for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num45 != 0.0)
					{
						string text2 = "Search/Track PRF for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 != 0.0)
					{
						string text2 = "Search/Track Blind Time for ECM must be 0..";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num16 != 0.0)
					{
						string text2 = "Illumnator Horizontal Beamwidth for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num15 != 0.0)
					{
						string text2 = "Illumnator Horizontal Beamwidth for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num62 != 0.0)
					{
						string text2 = "Max Contacts Illumination for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num14 != 0.0)
					{
						string text2 = "Illuminator System Noise Level for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num13 != 0.0)
					{
						string text2 = "Illumnator Processing Gain/Loss Level for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num12 != 0.0)
					{
						string text2 = "Illumnator Peak Power for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num11 != 0.0)
					{
						string text2 = "Illumnator Pulse Length for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num10 != 0.0)
					{
						string text2 = "Illumnator PRF for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num65 != 0.0)
					{
						string text2 = "Direction Finding Accuracy for ECM must be 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (0u - (flag75 ? 1u : 0u) != 0)
					{
						string text2 = "ESM Precise Emitter ID must be 0 for ECM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num67 != 0.0)
					{
						string text2 = "ESM System Loss must be 0 for ECM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num67 != 0.0)
					{
						string text2 = "ESM System Loss must be 0 for ECM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num68 != 0.0)
					{
						string text2 = "ESM Number Of Channels cannot must be 0 for ECM.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num69 <= 8.0 && (num63 == 4001.0 || num63 == 4021.0 || num63 == 4031.0 || num63 == 4091.0))
					{
						string text2 = "ECM Gain must be greater than 8 for OECM systems.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num73 <= 0.0 && (num63 == 4001.0 || num63 == 4021.0 || num63 == 4031.0 || num63 == 4091.0))
					{
						string text2 = "ECM Number Of Targets must be greater than 1 for OECM and COMINT jamming systems.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num73 != 0.0 && (num63 == 4011.0 || num63 == 4901.0 || num63 == 4902.0))
					{
						string text2 = "ECM Number Of Targets must be 0 for DECM systems orelse acoustic jammers.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num69 != 0.0 && (num63 == 4011.0 || num63 == 4901.0 || num63 == 4902.0))
					{
						string text2 = "ECM Gain must be 0 for DECM systems orelse acoustic jammers.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num70 < 1.0 && (num63 == 4001.0 || num63 == 4021.0 || num63 == 4031.0 || num63 == 4091.0))
					{
						string text2 = "ECM Peak Power must be minimum 1 Watt.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num70 != 0.0 && (num63 == 4011.0 || num63 == 4901.0 || num63 == 4902.0))
					{
						string text2 = "ECM Gain must be 0 for DECM systems orelse acoustic jammers.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num70 > 250000.0 && (num63 == 4001.0 || num63 == 4021.0 || num63 == 4031.0 || num63 == 4091.0))
					{
						string text2 = "ECM Peak Power can not be greater than 250 000 Watt.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num71 <= 0.0 && (num63 == 4001.0 || num63 == 4021.0 || num63 == 4031.0 || num63 == 4091.0))
					{
						string text2 = "ECM Bandwidth must be greater than 0.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num71 != 0.0 && (num63 == 4011.0 || num63 == 4901.0 || num63 == 4902.0))
					{
						string text2 = "ECM Gain must be 0 for DECM systems orelse acoustic jammers.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num72 < 0.0 && (num63 == 4011.0 || num63 == 4021.0))
					{
						string text2 = "ECM PoK Reduction can not be negative.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num72 > 40.0 && (num63 == 4011.0 || num63 == 4021.0))
					{
						string text2 = "ECM PoK Reduction can not be greater than 40.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num72 != 0.0 && (num63 == 4001.0 || num63 == 4031.0 || num63 == 4091.0 || num63 == 4901.0 || num63 == 4902.0))
					{
						string text2 = "ECM Gain must be 0 for DECM systems orelse acoustic jammers.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 == 1001.0)
					{
						string text2 = "ECM must have a role.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num63 < 4000.0 || num63 > 4999.0)
					{
						string text2 = "The ECM role is invalid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num3 < 2000L || num3 >= 2099L)
					{
						string text2 = "The ECM Generation is invalid!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				continue;
				IL_9139:
				int num110;
				if (Conversions.ToDouble(text) != 2871.0 && Conversions.ToDouble(text) != 2872.0 && Conversions.ToDouble(text) != 2873.0 && Conversions.ToDouble(text) != 2874.0 && Conversions.ToDouble(text) != 2875.0 && Conversions.ToDouble(text) != 2876.0 && Conversions.ToDouble(text) != 2881.0 && Conversions.ToDouble(text) != 2882.0 && Conversions.ToDouble(text) != 2883.0 && Conversions.ToDouble(text) != 2884.0 && Conversions.ToDouble(text) != 2885.0 && Conversions.ToDouble(text) != 2886.0 && Conversions.ToDouble(text) != 2887.0)
				{
					if (Conversions.ToDouble(text) != 2888.0)
					{
						goto IL_9250;
					}
					num110 = 1;
				}
				else
				{
					num110 = 1;
				}
				flag5 = (byte)num110 != 0;
				goto IL_9250;
				IL_4b31:
				if (flag62 && num44 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track Blind Time.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num44 > 400.0 && num44 != 1000.0)
				{
					string text2 = "The Search/Track Blind Time field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num44 < num46)
				{
					string text2 = "Sensor Search/Track Blind Time is shorter than Pulse Width, this makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num33 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track Horizontal Beamwidth.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num33 < 0.0 || num33 > 60.0)
				{
					string text2 = "The Search/Track Horizontal Beamwidth field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num50 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track Horizontal Beamwidth.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num50 < 0.0 || num50 > 75.0)
				{
					string text2 = "The Search/Track Vertical Beamwidth field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num49 < -20.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track System Noise Level.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num49 < 0.0 || num49 > 30.0)
				{
					string text2 = "The Search/Track System Noise Level field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num48 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track Processing Gain/Loss Level.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && (num48 < -20.0 || num48 > 70.0))
				{
					string text2 = "The Search/Track Processing Gain/Loss field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num47 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track Peak Power";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num47 < 0.0 || num47 > 60000000.0)
				{
					string text2 = "The Search/Track Peak Power field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num46 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track Pulse Length";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && (num46 < 0.0 || num46 > 160.0) && num46 != 1000.0)
				{
					string text2 = "The Search/Track Pulse Length field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && num45 == 0.0)
				{
					string text2 = "Sensor appears to be a search radar but has no Search/Track PRF";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag62 && (num45 < 0.0 || num45 > 26000.0))
				{
					string text2 = "The Search/Track PRF field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag6 && flag67)
				{
					string text2 = "This sensor can illuminate targets for weapons but has no illumination stats and flags.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				double num111 = Math.Round(161874.97732181425 / (2.0 * num45), 0);
				if ((flag62 && num26 > num111) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensors range is greater than Theoretical Instrumented Range (based on the sensors PRF).";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 && num7 == 0.0) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Search/Track Blind Time.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && num7 > 200.0)
				{
					string text2 = "The Illuminate Blind Time field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && num7 < num11 && num11 != 1000.0)
				{
					string text2 = "Sensor Search/Track Blind Time is shorter than Pulse Width, this makes no sense!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 && num16 == 0.0) & (Conversions.ToDouble(text) != 2191.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator Horizontal Beamwidth.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && (num16 < 0.0 || num16 > 60.0))
				{
					string text2 = "The Illumnator Horizontal Beamwidth field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num36 == 0.0 && flag6) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator Vertical Beamwidth.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 < 0.0 || num15 > 60.0)
				{
					string text2 = "The Illumnator Vertical Beamwidth field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((num36 == 0.0 && flag6) & (Conversions.ToDouble(text) != 2191.0))
				{
					string text2 = "Sensor appears to be an Illuminator/FCR radar with no valid Illuminator Bands. It must have at least one.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && num24 == 0.0)
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Weapon FCR, CW Illumination orelse ICW Illumination.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag6 && num24 != 0.0)
				{
					string text2 = "Sensor has CW / ICW flags but Max Contacts Illumination is to 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 || flag5) && num62 == 0.0)
				{
					string text2 = "Sensor appears to be an Illumnator, Gun/Missile Director or FCR radar but Max Contacts Illumination is 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag6 && !flag5 && num62 > 0.0)
				{
					string text2 = "Sensor is not an Illumnator, Gun/Missile Director or FCR radar. Set max Contacts Illumination to 0";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num62 < 0.0 || num62 > 24.0)
				{
					string text2 = "The Max Contact Illumination field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag6 && num14 < -20.0)
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator System Noise Level.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num14 < 0.0 || num14 > 30.0)
				{
					string text2 = "The Illumnator System Noise Level field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 && num13 == 0.0) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator Processing Gain/Loss Level.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num13 < -20.0 || num13 > 40.0)
				{
					string text2 = "The Illumnator Processing Gain/Loss field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 && num12 == 0.0) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator Peak Power";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 < 0.0 || num12 > 5000000.0)
				{
					string text2 = "The Illumnator Peak Power field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 && num11 == 0.0) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator Pulse Length";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 < 0.0 || (num11 > 160.0 && num11 != 1000.0))
				{
					string text2 = "The Illumnator Pulse Length field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if ((flag6 && num10 == 0.0) & (Conversions.ToDouble(text) != 2191.0) & (Conversions.ToDouble(text) != 2049.0))
				{
					string text2 = "Sensor appears to be an Illumnator/FCR radar but has no Illumnator PRF";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 < 0.0 || num10 > 26000.0)
				{
					string text2 = "The Illumnator PRF field has an illegal value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num65 != 0.0)
				{
					string text2 = "Direction Finding Accuracy for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num66 != 0.0)
				{
					string text2 = "ESM Sensitivity  for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num67 != 0.0)
				{
					string text2 = "ESM System Loss for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num68 != 0.0)
				{
					string text2 = "ESM Number Of Channels for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (0u - (flag75 ? 1u : 0u) != 0)
				{
					string text2 = "ESM Precise Emitter ID for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num69 != 0.0)
				{
					string text2 = "ECM Gain for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num70 != 0.0)
				{
					string text2 = "ECM Peak Power for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num71 != 0.0)
				{
					string text2 = "ECM Bandwidth for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num72 != 0.0)
				{
					string text2 = "ECM PoK Reduction for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num73 != 0.0)
				{
					string text2 = "ECM Number of Targets for radar must be 0.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num63 == 1001.0)
				{
					string text2 = "Radars must have a role.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num50 > 7.0 && (num63 == 2002.0 || num63 == 2004.0 || num63 == 2006.0 || num63 == 2012.0 || num63 == 2014.0 || num63 == 2016.0 || num63 == 2102.0 || num63 == 2104.0))
				{
					string text2 = "Role says 3D radar but vertical beamwidth is greater than 7 deg. Makes no sense.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num50 < 7.0 && (num63 == 2001.0 || num63 == 2003.0 || num63 == 2005.0 || num63 == 2011.0 || num63 == 2013.0 || num63 == 2015.0 || num63 == 2101.0 || num63 == 2103.0))
				{
					string text2 = "Role says 2D radar but vertical beamwidth is 7 deg orelse less. Makes no sense.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 >= 6.0 && (num63 == 2002.0 || num63 == 2004.0 || num63 == 2006.0 || num63 == 2012.0 || num63 == 2014.0 || num63 == 2016.0 || num63 == 2102.0 || num63 == 2104.0))
				{
					string text2 = "Role says 3D radar but illuminate vertical beamwidth is 6 deg orelse greater. Makes no sense.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num15 >= 6.0 && (num63 == 2002.0 || num63 == 2004.0 || num63 == 2006.0 || num63 == 2012.0 || num63 == 2014.0 || num63 == 2016.0 || num63 == 2102.0 || num63 == 2104.0))
				{
					string text2 = "Role says 2D radar but illuminate vertical beamwidth is less than 6 deg. Makes no sense.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num26 >= 160.0 && (num63 == 2003.0 || num63 == 2004.0 || num63 == 2005.0 || num63 == 2006.0 || num63 == 2013.0 || num63 == 2014.0 || num63 == 2015.0 || num63 == 2016.0 || num63 == 2018.0 || num63 == 2019.0 || num63 == 2022.0 || num63 == 2023.0 || num63 == 2112.0 || num63 == 2113.0 || num63 == 2122.0 || num63 == 2123.0 || num63 == 2125.0 || num63 == 2126.0 || num63 == 2132.0 || num63 == 2133.0 || num63 == 2142.0 || num63 == 2143.0))
				{
					string text2 = "The radar range is greater than 160nm and does not match the radars role.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num26 <= 159.0 && num26 >= 60.0 && (num63 == 2001.0 || num63 == 2002.0 || num63 == 2005.0 || num63 == 2006.0 || num63 == 2011.0 || num63 == 2012.0 || num63 == 2015.0 || num63 == 2016.0 || num63 == 2017.0 || num63 == 2019.0 || num63 == 2021.0 || num63 == 2023.0 || num63 == 2111.0 || num63 == 2113.0 || num63 == 2121.0 || num63 == 2123.0 || num63 == 2124.0 || num63 == 2126.0 || num63 == 2131.0 || num63 == 2133.0 || num63 == 2141.0 || num63 == 2143.0))
				{
					string text2 = "The radar range is 60-159nm and does not match the radars role.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num26 <= 59.0 && (num63 == 2003.0 || num63 == 2004.0 || num63 == 2001.0 || num63 == 2002.0 || num63 == 2013.0 || num63 == 2014.0 || num63 == 2011.0 || num63 == 2012.0 || num63 == 2018.0 || num63 == 2017.0 || num63 == 2022.0 || num63 == 2027.0 || num63 == 2112.0 || num63 == 2117.0 || num63 == 2122.0 || num63 == 2121.0 || num63 == 2125.0 || num63 == 2124.0 || num63 == 2132.0 || num63 == 2131.0 || num63 == 2142.0 || num63 == 2141.0))
				{
					string text2 = "The radar range is shorter than 59nm and does not match the radars role.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag18 && (num63 == 2001.0 || num63 == 2003.0 || num63 == 2005.0 || num63 == 2011.0 || num63 == 2013.0 || num63 == 2015.0 || num63 == 2101.0 || num63 == 2103.0))
				{
					string text2 = "The Altitude Information flag is but the role says it is a 2D radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag18 && (num63 == 2002.0 || num63 == 2004.0 || num63 == 2006.0 || num63 == 2012.0 || num63 == 2014.0 || num63 == 2016.0 || num63 == 2102.0 || num63 == 2104.0))
				{
					string text2 = "The Altitude Information flag is NOT but the role says it is a 3D radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag18 && (num63 == 2017.0 || num63 == 2018.0 || num63 == 2019.0))
				{
					string text2 = "The Altitude Information flag is NOT but the role says it is a Height Finding radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag16 && (num63 == 2001.0 || num63 == 2002.0 || num63 == 2003.0 || num63 == 2004.0 || num63 == 2005.0 || num63 == 2006.0 || num63 == 2011.0 || num63 == 2012.0 || num63 == 2013.0 || num63 == 2014.0 || num63 == 2015.0 || num63 == 2016.0 || num63 == 2017.0 || num63 == 2018.0 || num63 == 2019.0 || num63 == 2101.0 || num63 == 2102.0 || num63 == 2103.0 || num63 == 2104.0 || num63 == 2111.0 || num63 == 2112.0 || num63 == 2113.0 || num63 == 2121.0 || num63 == 2122.0 || num63 == 2123.0 || num63 == 2131.0 || num63 == 2132.0 || num63 == 2133.0 || num63 == 2141.0 || num63 == 2142.0 || num63 == 2143.0 || num63 == 2201.0 || num63 == 2202.0 || num63 == 2203.0 || num63 == 2311.0 || num63 == 2312.0))
				{
					string text2 = "The Air Search Capability flag is NOT but the role says air search capable radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag16 && (num63 == 2021.0 || num63 == 2022.0 || num63 == 2023.0 || num63 == 2027.0 || num63 == 2028.0 || num63 == 2105.0 || num63 == 2151.0 || num63 == 2152.0))
				{
					string text2 = "The Air Search Capability flag is but the role says it is not an air search capable radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag12 && (num63 == 2401.0 || num63 == 2402.0 || num63 == 2403.0 || num63 == 2404.0))
				{
					string text2 = "The Space Search Capability flag is NOT but the role says space search capable radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag11 && (num63 == 2011.0 || num63 == 2012.0 || num63 == 2013.0 || num63 == 2014.0 || num63 == 2015.0 || num63 == 2016.0 || num63 == 2021.0 || num63 == 2022.0 || num63 == 2023.0 || num63 == 2027.0 || num63 == 2028.0 || num63 == 2103.0 || num63 == 2104.0 || num63 == 2105.0 || num63 == 2141.0 || num63 == 2142.0 || num63 == 2143.0 || num63 == 2151.0 || num63 == 2152.0 || num63 == 2161.0))
				{
					string text2 = "The Surface Search Capability flag is NOT but the role says surface search capable radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag11 && (num63 == 2001.0 || num63 == 2002.0 || num63 == 2003.0 || num63 == 2004.0 || num63 == 2005.0 || num63 == 2006.0 || num63 == 2017.0 || num63 == 2018.0 || num63 == 2019.0 || num63 == 2101.0 || num63 == 2102.0 || num63 == 2111.0 || num63 == 2112.0 || num63 == 2113.0 || num63 == 2311.0 || num63 == 2312.0 || num63 == 2401.0 || num63 == 2402.0 || num63 == 2403.0 || num63 == 2404.0))
				{
					string text2 = "The Surface Search Capability flag is but the role says it is not an surface search capable radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag19 && num63 == 2301.0)
				{
					string text2 = "The Range Information Capabilty flag is NOT but the role says Range-Only radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag19 && (num63 == 2017.0 || num63 == 2018.0 || num63 == 2019.0))
				{
					string text2 = "The Range Information Capabilty flag is NOT but the role says Height-Finding radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag19 && num63 == 2191.0)
				{
					string text2 = "The role says Gun FCR but the radar has no Range Information Capability. Pretty strange.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag19 && (num63 == 2001.0 || num63 == 2002.0 || num63 == 2003.0 || num63 == 2004.0 || num63 == 2005.0 || num63 == 2006.0 || num63 == 2011.0 || num63 == 2012.0 || num63 == 2013.0 || num63 == 2014.0 || num63 == 2015.0 || num63 == 2016.0 || num63 == 2101.0 || num63 == 2102.0 || num63 == 2103.0 || num63 == 2104.0))
				{
					string text2 = "The Range Information flag is NOT but the role says it is a 2D orelse 3D radar.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag15 && num63 == 2031.0)
				{
					string text2 = "The sensor role says Navigation Radar but the sensor capabilities do not include this capability.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag15 && num63 != 2031.0)
				{
					string text2 = "The sensor capabilities says Navigation Radar but the sensor role is not.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag23 && num63 == 2032.0)
				{
					string text2 = "The sensor role says Ground Mapping Radar but the sensor capabilities do not include this capability.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag23 && num63 != 2032.0)
				{
					string text2 = "The sensor capabilities says Ground Mapping Radar but the sensor role is not.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag22 && num63 == 2033.0)
				{
					string text2 = "The sensor role says Terrain Avoidance / Following Radar but the sensor capabilities do not include this capability.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag22 && num63 != 2033.0)
				{
					string text2 = "The sensor capabilities says Terrain Avoidance / Following Radar but the sensor role is not.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag23 && num63 == 2032.0)
				{
					string text2 = "The sensor role says Ground Mapping Radar but the sensor capabilities do not include this capability.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag23 && num63 != 2032.0)
				{
					string text2 = "The sensor capabilities says Ground Mapping Radar but the sensor role is not.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag21 && num63 == 2035.0)
				{
					string text2 = "The sensor role says Ground Mapping Radar but the sensor capabilities do not include this capability.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag21 && num63 != 2035.0)
				{
					string text2 = "The sensor capabilities says Ground Mapping Radar but the sensor role is not.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (!flag20 && num63 == 2034.0)
				{
					string text2 = "The sensor role says Navigation And Weather Radar but the sensor capabilities do not include this capability.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (flag20 && num63 != 2034.0)
				{
					string text2 = "The sensor capabilities says Navigation And Weather Radar but the sensor role is not.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num63 <= 2000.0 || num63 >= 3000.0)
				{
					string text2 = "The Sensor Role is invalid for radar!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 < 2000L || num3 >= 2099L)
				{
					string text2 = "The Radar Generation is invalid!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				float num112 = ((!(num28 > num85)) ? ((float)num85) : ((float)num28));
				if (!flag16 && !flag12 && !flag17)
				{
					if (num112 > 0f)
					{
						string text2 = "The sensor has a max altitude setting, but is not air search orelse space search capable.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
				}
				else
				{
					float num113 = num112 / 1852f;
					float num114 = (float)Conversion.Int(num26 * 1852.0 / 0.3048);
					if (num28 <= 0.0 && num85 <= 0.0)
					{
						string text2 = "The radar needs max altitude stat! Max altitude should be up to " + Conversions.ToString(num114) + " ft.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num28 > 0.0 && num85 > 0.0)
					{
						string text2 = "The radar must not have max altitude stats for both AGL and ASL! Use one orelse the other.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag69 || flag70 || flag72 || flag68)
					{
						if (flag12)
						{
							if (num28 != 0.0)
							{
								string text2 = "The radar is space search capable. Use Altitude ASL, not AGL!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num85 != 1005840.0)
							{
								string text2 = "The radar is space search capable. Use a max altitude setting of 3300000 ft";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else if ((double)num113 > num26)
						{
							string text2 = "The sensor max altitude is higher than the radar max range. Max altitude should be up to " + Conversions.ToString(num114) + " ft.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (flag71 || flag74 || flag73)
					{
						if (num28 != 0.0)
						{
							string text2 = "Air search radars on aircraft must not use Altitude AGL. Instead use Altitude ASL.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (num85 == 0.0)
						{
							string text2 = "Air search radars on aircraft must have Altitude ASL stats.";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag12)
						{
							if ((double)num113 > num26 + 7.406047516198704)
							{
								string text2 = "The sensor max altitude is unrealistically high. Max altitude should be less than " + Conversions.ToString(Conversion.Int((num26 * 1852.0 + 13716.0) * 0.3048)) + " ft.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num113 == 0f)
							{
								string text2 = "The sensor max altitude is 0 ft. Max altitude should be up to " + Conversions.ToString((double)num114 + 2.2573632829373653) + " ft.";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
						else
						{
							if (num28 != 0.0)
							{
								string text2 = "The radar is space search capable. Use Altitude AGL, not ASL!";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
							if (num85 != 1005840.0)
							{
								string text2 = "The radar is space search capable. Use a max altitude setting of 3300000 ft";
								string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text2 + "');";
								Common.mySourceDB_Helper.ExecuteNonQuery(string_);
							}
						}
					}
				}
				goto IL_8f28;
			}
			recordset2 = null;
			recordset.Close();
		}
		catch (Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			Exception ex3 = ex2;
			ErrorManagement.EnqueueErrorMessage(ex3);
			ex3.Data.Add("Error at Validation 200086", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSensorNumberOfArrays()
	{
		try
		{
			DataTable dataTable = Common.get_DataSensor(Common.mySourceDB_Helper);
			double num8 = default(double);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null));
				Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Generation" }, (string[])null));
				Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Name" }, (string[])null));
				Conversions.ToString(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Role" }, (string[])null));
				DataRow? dataRow = Common.get_MiscSensor(Common.mySourceDB_Helper).Rows.Find(num);
				Conversions.ToBoolean(dataRow["ConfOverall"]);
				long num2 = Conversions.ToLong(dataRow["NumberOfArrayFaces"]);
				if (num2 <= 0L)
				{
					continue;
				}
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				DataRow[] array = (from theS in Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num7 = 0; num7 < array.Length; num7 = checked(num7 + 1))
				{
					num8 = Conversions.ToDouble(array[num7]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Ship " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Ship " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				num6 = 0.0;
				DataRow[] array2 = (from theS in Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num9 = 0; num9 < array2.Length; num9 = checked(num9 + 1))
				{
					num8 = Conversions.ToDouble(array2[num9]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Aircraft " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Aircraft " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				num6 = 0.0;
				DataRow[] array3 = (from theS in Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num10 = 0; num10 < array3.Length; num10 = checked(num10 + 1))
				{
					num8 = Conversions.ToDouble(array3[num10]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Facility " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Facility " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				num6 = 0.0;
				DataRow[] array4 = (from theS in Common.get_DataSubmarineSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num11 = 0; num11 < array4.Length; num11 = checked(num11 + 1))
				{
					num8 = Conversions.ToDouble(array4[num11]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Submarine " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Submarine " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				num6 = 0.0;
				DataRow[] array5 = (from theS in Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num12 = 0; num12 < array5.Length; num12 = checked(num12 + 1))
				{
					num8 = Conversions.ToDouble(array5[num12]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Weapon " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Weapon " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				num6 = 0.0;
				DataRow[] array6 = (from theS in Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num13 = 0; num13 < array6.Length; num13 = checked(num13 + 1))
				{
					num8 = Conversions.ToDouble(array6[num13]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Sensor Group " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Sensor Group " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				num3 = 0.0;
				num4 = 0.0;
				num5 = 0.0;
				num6 = 0.0;
				DataRow[] array7 = (from theS in Common.get_DataMountSensors(Common.mySourceDB_Helper).Select("ComponentID=" + Conversions.ToString(num))
					orderby theS["ID"]
					select theS).ToArray();
				for (int num14 = 0; num14 < array7.Length; num14 = checked(num14 + 1))
				{
					num8 = Conversions.ToDouble(array7[num14]["ID"]);
					if (num3 != num8)
					{
						if ((double)num2 != num4 && num3 != 0.0)
						{
							string text = "Mount " + Conversions.ToString(num3) + " should have " + Conversions.ToString(num5) + " entries of sensor " + Conversions.ToString(num6);
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						num4 = 1.0;
					}
					else
					{
						num4 += 1.0;
					}
					num3 = num8;
					num5 = num2;
					num6 = num;
				}
				if ((double)num2 != num4 && num3 != 0.0)
				{
					string text = "Mount " + Conversions.ToString(num8) + " should have " + Conversions.ToString(num2) + " entries of sensor " + Conversions.ToString(num);
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200085", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSensorNames()
	{
		try
		{
			string name = "SELECT ID FROM DataSensor";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow? dataRow = Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num);
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num3 > 0 && num2 == 0)
				{
					string text3 = "Found a right \")\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num4 > 0 && num5 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num5 > 0 && num4 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num6 > 0 && num7 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the name but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				int num14;
				if (num7 > 0 && num6 == 0)
				{
					string text3 = "Found a right \"}\" bracket in the name but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num8 > 0 && num9 == 0)
				{
					string text3 = "Found a left \"(\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num9 > 0 && num8 == 0)
				{
					string text3 = "Found a right \")\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num10 > 0 && num11 == 0)
				{
					string text3 = "Found a left \"[\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num11 > 0 && num10 == 0)
				{
					string text3 = "Found a right \"]\" bracket in the comments field but no left bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num12 > 0 && num13 == 0)
				{
					string text3 = "Found a left \"{\" bracket in the comments field but no right bracket.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num16 = 1;
				}
				int num17;
				if (Strings.InStr(num16, text2, "KT ", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "KT)", (CompareMethod)0) <= 0)
				{
					num17 = 1;
				}
				else
				{
					string text3 = "Kiloton should say \"kT\" and not \"KT\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num17 = 1;
				}
				int num18;
				if (Strings.InStr(num17, text2, "kt ", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "kt)", (CompareMethod)0) <= 0)
				{
					num18 = 1;
				}
				else
				{
					string text3 = "Kiloton should say \"kT\" and not \"kt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num18 = 1;
				}
				int num19;
				if (Strings.InStr(num18, text2, "mt ", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mt)", (CompareMethod)0) <= 0)
				{
					num19 = 1;
				}
				else
				{
					string text3 = "Megaton should say \"mT\" and not \"mt\" in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num19 = 1;
				}
				int num20;
				if (Strings.InStr(num19, text2, "mk ", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mk8", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mk5", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mk4", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mk3", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mk2", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "mk1", (CompareMethod)0) <= 0)
				{
					num20 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"mk\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num20 = 1;
				}
				int num21;
				if (Strings.InStr(num20, text2, "MK8", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "MK5", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "MK4", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "MK3", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "MK2", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "MK1", (CompareMethod)0) <= 0)
				{
					num21 = 1;
				}
				else
				{
					string text3 = "Mark (\"Mk\") should say \"Mk\" and not \"MK\" in the name, with no spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num21 = 1;
				}
				int num22;
				if (Strings.InStr(num21, text2, "Mk 8", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "Mk 5", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "Mk 4", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "Mk 3", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "Mk 2", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "Mk 1", (CompareMethod)0) <= 0)
				{
					num22 = 1;
				}
				else
				{
					string text3 = "Mark numbers (e.g. \"Mk80\") should not have spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num22 = 1;
				}
				int num23;
				if (Strings.InStr(num22, text2, "AGM ", (CompareMethod)0) <= 0 && Strings.InStr(1, text2, "AIM ", (CompareMethod)0) <= 0)
				{
					num23 = 1;
				}
				else
				{
					string text3 = "AGM/AIM designations should use dashes \"-\" in the name, not spaces.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num23 = 1;
				}
				int num24;
				if (Strings.InStr(num23, text2, "  ", (CompareMethod)1) <= 0)
				{
					num24 = 1;
				}
				else
				{
					string text3 = "Found double spaces in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num24 = 1;
				}
				int num25;
				if (Strings.InStr(num24, text2, "//", (CompareMethod)1) <= 0)
				{
					num25 = 1;
				}
				else
				{
					string text3 = "Found double slashes in the name.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num25 = 1;
				}
				int num26;
				if (Strings.InStr(num25, text, "  ", (CompareMethod)1) <= 0)
				{
					num26 = 1;
				}
				else
				{
					string text3 = "Found double spaces in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					num26 = 1;
				}
				if (Strings.InStr(num26, text, "//", (CompareMethod)1) > 0)
				{
					string text3 = "Found double slashes in the comments field.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text3 + "');";
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
			ex2.Data.Add("Error at Validation 200084", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static void smethod_0(int int_0, DataRow[] dataRow_0, object object_0)
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
				double num19 = Conversions.ToDouble(obj["SB1Max"]);
				double num20 = Conversions.ToDouble(obj["SB2Max"]);
				double num21 = Conversions.ToDouble(obj["SMF1Max"]);
				double num22 = Conversions.ToDouble(obj["SMF2Max"]);
				double num23 = Conversions.ToDouble(obj["SMA1Max"]);
				double num24 = Conversions.ToDouble(obj["SMA2Max"]);
				double num25 = Conversions.ToDouble(obj["SS1Max"]);
				double num26 = Conversions.ToDouble(obj["SS2Max"]);
				double num27 = Conversions.ToDouble(obj["PB1Max"]);
				double num28 = Conversions.ToDouble(obj["PB2Max"]);
				double num29 = Conversions.ToDouble(obj["PMF1Max"]);
				double num30 = Conversions.ToDouble(obj["PMF2Max"]);
				double num31 = Conversions.ToDouble(obj["PMA1Max"]);
				double num32 = Conversions.ToDouble(obj["PMA2Max"]);
				double num33 = Conversions.ToDouble(obj["PS1Max"]);
				double num34 = Conversions.ToDouble(obj["PS2Max"]);
				if (num3 == 0.0 && num4 == 0.0 && num5 == 0.0 && num6 == 0.0 && num7 == 0.0 && num8 == 0.0 && num9 == 0.0 && num10 == 0.0 && num11 == 0.0 && num12 == 0.0 && num13 == 0.0 && num14 == 0.0 && num15 == 0.0 && num16 == 0.0 && num17 == 0.0 && num18 == 0.0)
				{
					string text = "Sensor " + Conversions.ToString(num) + " with ID " + Conversions.ToString(num2) + " does not have a Search arc!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + (string)object_0 + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (num19 == 0.0 && num20 == 0.0 && num21 == 0.0 && num22 == 0.0 && num23 == 0.0 && num24 == 0.0 && num25 == 0.0 && num26 == 0.0 && num27 == 0.0 && num28 == 0.0 && num29 == 0.0 && num30 == 0.0 && num31 == 0.0 && num32 == 0.0 && num33 == 0.0 && num34 == 0.0)
				{
					string text = "Sensor " + Conversions.ToString(num) + " with ID " + Conversions.ToString(num2) + " does not have a Max arc!";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(int_0) + ", " + Conversions.ToString(Convert.ToChar(34)) + (string)object_0 + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				DataRow[] array = Common.get_MiscSensorDefault(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
				bool flag = false;
				bool flag2 = false;
				DataRow[] array2 = array;
				foreach (DataRow obj2 in array2)
				{
					double num35 = Conversions.ToDouble(obj2["SB1"]);
					double num36 = Conversions.ToDouble(obj2["SB2"]);
					double num37 = Conversions.ToDouble(obj2["SMF1"]);
					double num38 = Conversions.ToDouble(obj2["SMF2"]);
					double num39 = Conversions.ToDouble(obj2["SMA1"]);
					double num40 = Conversions.ToDouble(obj2["SMA2"]);
					double num41 = Conversions.ToDouble(obj2["SS1"]);
					double num42 = Conversions.ToDouble(obj2["SS2"]);
					double num43 = Conversions.ToDouble(obj2["PB1"]);
					double num44 = Conversions.ToDouble(obj2["PB2"]);
					double num45 = Conversions.ToDouble(obj2["PMF1"]);
					double num46 = Conversions.ToDouble(obj2["PMF2"]);
					double num47 = Conversions.ToDouble(obj2["PMA1"]);
					double num48 = Conversions.ToDouble(obj2["PMA2"]);
					double num49 = Conversions.ToDouble(obj2["PS1"]);
					double num50 = Conversions.ToDouble(obj2["PS2"]);
					double num51 = Conversions.ToDouble(obj2["SB1Max"]);
					double num52 = Conversions.ToDouble(obj2["SB2Max"]);
					double num53 = Conversions.ToDouble(obj2["SMF1Max"]);
					double num54 = Conversions.ToDouble(obj2["SMF2Max"]);
					double num55 = Conversions.ToDouble(obj2["SMA1Max"]);
					double num56 = Conversions.ToDouble(obj2["SMA2Max"]);
					double num57 = Conversions.ToDouble(obj2["SS1Max"]);
					double num58 = Conversions.ToDouble(obj2["SS2Max"]);
					double num59 = Conversions.ToDouble(obj2["PB1Max"]);
					double num60 = Conversions.ToDouble(obj2["PB2Max"]);
					double num61 = Conversions.ToDouble(obj2["PMF1Max"]);
					double num62 = Conversions.ToDouble(obj2["PMF2Max"]);
					double num63 = Conversions.ToDouble(obj2["PMA1Max"]);
					double num64 = Conversions.ToDouble(obj2["PMA2Max"]);
					double num65 = Conversions.ToDouble(obj2["PS1Max"]);
					double num66 = Conversions.ToDouble(obj2["PS2Max"]);
					flag2 = true;
					if (num3 == num35 && num4 == num36 && num5 == num37 && num6 == num38 && num7 == num39 && num8 == num40 && num9 == num41 && num10 == num42 && num11 == num43 && num12 == num44 && num13 == num45 && num14 == num46 && num15 == num47 && num16 == num48 && num17 == num49 && num18 == num50 && num19 == num51 && num20 == num52 && num21 == num53 && num22 == num54 && num23 == num55 && num24 == num56 && num25 == num57 && num26 == num58 && num27 == num59 && num28 == num60 && num29 == num61 && num30 == num62 && num31 == num63 && num32 == num64 && num33 == num65 && num34 == num66)
					{
						flag = true;
						break;
					}
				}
				if (!flag && flag2)
				{
					string text = "Sensor " + Conversions.ToString(num) + " with ID " + Conversions.ToString(num2) + " does not have a legal arc!";
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
			ex2.Data.Add("Error at Validation 200083", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateSensorDefaultArcs()
	{
		try
		{
			string name = "SELECT ID FROM DataAircraft";
			Recordset recordset = Common.theSourceDB.OpenRecordset(name, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset2 = recordset;
			while (!recordset2.EOF)
			{
				long num = Conversions.ToLong(recordset2.Fields["ID"].Value);
				DataRow[] dataRow_ = Common.get_DataAircraftSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
				smethod_0((int)num, dataRow_, "Aircraft");
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
				DataRow[] dataRow_2 = Common.get_DataShipSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
				smethod_0((int)num2, dataRow_2, "Ship");
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
				DataRow[] dataRow_3 = Common.get_DataSubmarineSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num3));
				smethod_0((int)num3, dataRow_3, "Submarine");
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
				DataRow[] dataRow_4 = Common.get_DataFacilitySensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num4));
				smethod_0((int)num4, dataRow_4, "Facility");
				recordset8.MoveNext();
			}
			recordset8 = null;
			recordset7.Close();
			string name5 = "SELECT ID FROM DataWeapon";
			Recordset recordset9 = Common.theSourceDB.OpenRecordset(name5, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
			Recordset recordset10 = recordset9;
			while (!recordset10.EOF)
			{
				long num5 = Conversions.ToLong(recordset10.Fields["ID"].Value);
				DataRow[] dataRow_5 = Common.get_DataWeaponSensors(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num5));
				smethod_0((int)num5, dataRow_5, "Weapon");
				recordset10.MoveNext();
			}
			recordset10 = null;
			recordset9.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200082", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateAllSensorsInGroupAreCapableVsSameTargets()
	{
		try
		{
			DataTable dataTable = Common.get_DataSensor(Common.mySourceDB_Helper);
			foreach (object row in dataTable.Rows)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(row);
				long num = Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "ID" }, (string[])null));
				if (Conversions.ToLong(NewLateBinding.LateIndexGet(objectValue, new object[1] { "Type" }, (string[])null)) != 9001L)
				{
					continue;
				}
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
				DataRow[] array = Common.get_DataSensorSensorGroups(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num));
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
					long num3 = Conversions.ToLong(Common.get_DataSensor(Common.mySourceDB_Helper).Rows.Find(num2)["Type"]);
					DataRow[] array3 = Common.get_DataSensorCapabilities(Common.mySourceDB_Helper).Select("ID=" + Conversions.ToString(num2));
					for (int j = 0; j < array3.Length; j = checked(j + 1))
					{
						long num4 = Conversions.ToLong(array3[j]["CodeID"]);
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
							if (num4 == 2002L)
							{
								flag15 = true;
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
							if (num4 == 2002L)
							{
								flag34 = true;
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
					if (!flag18 && (num3 == 2003L || num3 == 2004L || num3 == 4001L || num3 == 4002L || num3 == 4003L))
					{
						if (flag20 && !flag)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Air Search capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag20 && flag)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Air Search capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag21 && !flag2)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Surface Search capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag21 && flag2)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Surface Search capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag22 && !flag3)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Submarine Search capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag22 && flag3)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Submarine Search capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag23 && !flag4)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Land Search - Fixed Facility capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag23 && flag4)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Land Search - Fixed Facility capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag24 && !flag5)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Land Search - Mobile Unit capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag24 && flag5)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Land Search - Mobile Unit capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag25 && !flag6)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Range Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag25 && flag6)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Range Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag26 && !flag7)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Altitude Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag26 && flag7)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Altitude Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag27 && !flag8)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Speed Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag27 && flag8)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Speed Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag28 && !flag9)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Heading Information capability while other IR/Visual/Laser sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag28 && flag9)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Heading Information capability while other IR/Visual/Laser sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
					}
					if (!flag19 && num3 == 2001L)
					{
						if (flag29 && !flag10)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Air Search capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag29 && flag10)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Air Search capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag30 && !flag11)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Surface Search capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag30 && flag11)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Surface Search capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag31 && !flag12)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Land Search - Fixed Facility capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag31 && flag12)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Land Search - Fixed Facility capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag32 && !flag13)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Land Search - Mobile Unit capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag32 && flag13)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Land Search - Mobile Unit capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag33 && !flag14)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Range Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag33 && flag14)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Range Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag34 && !flag15)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Altitude Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag35 && flag16)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Speed Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (flag36 && !flag17)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " has Heading Information capability while other radar sensors in the group do not. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
							Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						}
						if (!flag36 && flag17)
						{
							string text = "Grouped Sensor " + Conversions.ToString(num2) + " lacks Heading Information capability while other radar sensors in the group are capable. Not logical!";
							string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Sensor" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && !flag10)
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
			ex2.Data.Add("Error at Validation 200081", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateSensor()
	{
		Class72.smethod_20();
	}
}
