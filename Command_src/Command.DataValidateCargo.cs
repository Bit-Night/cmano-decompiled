using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DataValidateCargo
{
	public static void ValidateCargoMandatoryValues()
	{
		try
		{
			foreach (DataRow row in Common.get_DataLoadout(Common.mySourceDB_Helper).Rows)
			{
				int num = Conversions.ToInteger(row["ID"]);
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Cargo_Type"])))
				{
					switch (Conversions.ToInteger(row["Cargo_Type"]))
					{
					default:
					{
						string text = "Cargo_type field must have a valid value (0, 1000, 2000, 3000, 4000 or 5000)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						break;
					}
					case 0:
					case 1000:
					case 2000:
					case 3000:
					case 4000:
					case 5000:
						break;
					}
				}
				else
				{
					string text = "Cargo_type field must have a valid value (0, 1000, 2000, 3000, 4000 or 5000)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Cargo_Mass"])))
				{
					string text = "Cargo_Mass field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Cargo_Area"])))
				{
					string text = "Cargo_Area field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Cargo_Crew"])))
				{
					string text = "Cargo_type field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
			foreach (DataRow row2 in Common.get_DataMount(Common.mySourceDB_Helper).Rows)
			{
				int num = Conversions.ToInteger(row2["ID"]);
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["Cargo_Type"])))
				{
					string text = "Cargo_type field must have a valid value (0, 1000, 2000, 3000, 4000 or 5000)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				else
				{
					switch (Conversions.ToInteger(row2["Cargo_Type"]))
					{
					default:
					{
						string text = "Cargo_type field must have a valid value (0, 1000, 2000, 3000, 4000 or 5000)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						break;
					}
					case 0:
					case 1000:
					case 2000:
					case 3000:
					case 4000:
					case 5000:
						break;
					}
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["Cargo_Mass"])))
				{
					string text = "Cargo_Mass field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["Cargo_Area"])))
				{
					string text = "Cargo_Area field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row2["Cargo_Crew"])))
				{
					string text = "Cargo_type field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
			}
			foreach (DataRow row3 in Common.get_DataShip(Common.mySourceDB_Helper).Rows)
			{
				int num = Conversions.ToInteger(row3["ID"]);
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["Cargo_Type"])))
				{
					string text = "Cargo_type field must have a valid value (0, 1000, 2000, 3000, 4000 or 5000)";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				else
				{
					switch (Conversions.ToInteger(row3["Cargo_Type"]))
					{
					default:
					{
						string text = "Cargo_type field must have a valid value (0, 1000, 2000, 3000, 4000 or 5000)";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
						break;
					}
					case 0:
					case 1000:
					case 2000:
					case 3000:
					case 4000:
					case 5000:
						break;
					}
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["Cargo_Mass"])))
				{
					string text = "Cargo_Mass field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["Cargo_Area"])))
				{
					string text = "Cargo_Area field must have a valid value.";
					string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_);
				}
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(row3["Cargo_Crew"])))
				{
					string text = "Cargo_type field must have a valid value.";
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
			ex2.Data.Add("Error at Validation 200018", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateLoadoutCargoValues()
	{
		try
		{
			DataRow[] array = Common.get_DataLoadout(Common.mySourceDB_Helper).Select("ID > 4");
			foreach (DataRow obj in array)
			{
				int num2 = Conversions.ToInteger(obj["ID"]);
				Common.StatusString = "ValidateLoadoutCargoValues - Loadout #" + Conversions.ToString(num2);
				int num3 = Conversions.ToInteger(obj["LoadoutRole"]);
				int num4 = Conversions.ToInteger(obj["DefaultMissionProfile"]);
				int num5 = Conversions.ToInteger(obj["Cargo_Type"]);
				double num6 = Conversions.ToDouble(obj["Cargo_Mass"]);
				double num7 = Conversions.ToDouble(obj["Cargo_Area"]);
				int num8 = Conversions.ToInteger(obj["Cargo_Crew"]);
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				int num9;
				if (num3 != 7101 && num3 != 7102)
				{
					if (num3 != 7201)
					{
						goto IL_00db;
					}
					num9 = 1;
				}
				else
				{
					num9 = 1;
				}
				flag = (byte)num9 != 0;
				goto IL_00db;
				IL_00db:
				if (num4 > 8000 && num4 < 8100)
				{
					flag2 = true;
				}
				if (num3 == 3401 && num8 != 0)
				{
					flag3 = true;
				}
				if (!(num7 == 0.0 && num8 == 0 && num6 == 0.0 && num5 == 0 && !flag2 && !flag))
				{
					if (flag2 && !flag)
					{
						string text = "Loadout Profile is cargo or passenger, Loadout Role doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (flag && !flag2)
					{
						string text = "Loadout Role is cargo or passenger, Loadout Profile doesnt match!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag2 || flag) && num7 == 0.0 && num8 == 0)
					{
						string text = "Non-passenger cargo loadout with Cargo_Area of 0, not logical!!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag2 || flag) && num6 == 0.0 && num8 == 0)
					{
						string text = "Non-passenger cargo loadout with Cargo_Mass of 0, not logical!!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((flag2 || flag) && num8 == 0 && !smethod_0(num2))
					{
						string text = "Cargo loadout with Cargo_Crew of 0; manned aircraft should have room for crew associated with their cargo.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num8 != 0 && !(flag2 || flag || flag3))
					{
						string text = "Loadout has Cargo_Crew capacity but is not a cargo, passenger or combat transport loadout!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 != 0.0 && !(flag2 || flag || flag3))
					{
						string text = "Loadout has Cargo_Mass capacity but is not a cargo, passenger or combat transport loadout!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 != 0.0 && !(flag2 || flag || flag3))
					{
						string text = "Loadout has Cargo_Area capacity but is not a cargo, passenger or combat transport loadout!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 != 0.0 && num6 == 0.0)
					{
						string text = "Loadout has Cargo_Area capacity but no Cargo_Mass capacity, not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 != 0.0 && num7 == 0.0)
					{
						string text = "Loadout has Cargo_Mass capacity but no Cargo_Area capacity, not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Loadout" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200020", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private static bool smethod_0(int int_0)
	{
		try
		{
			DataRow[] array = Common.get_DataAircraftLoadouts(Common.mySourceDB_Helper).Select("ComponentID = " + Conversions.ToString(int_0));
			foreach (DataRow dataRow in array)
			{
				DataRow[] array2 = Common.get_DataAircraft(Common.mySourceDB_Helper).Select("ID = " + Conversions.ToString(Conversions.ToInteger(dataRow["ID"])));
				for (int j = 0; j < array2.Length; j = checked(j + 1))
				{
					if (Conversions.ToInteger(array2[j]["Crew"]) != 0)
					{
						return false;
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ErrorManagement.EnqueueErrorMessage(ex2);
			ex2.Data.Add("Error at Validation 200025", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateShipCargoValues()
	{
		try
		{
			foreach (DataRow row in Common.get_DataShip(Common.mySourceDB_Helper).Rows)
			{
				int num = Conversions.ToInteger(row["ID"]);
				Common.StatusString = "ValidateShipCargoValues - Ship #" + Conversions.ToString(num);
				double num2 = Conversions.ToDouble(row["CargoCapacity"]);
				double num3 = Conversions.ToDouble(row["TroopCapacity"]);
				double num4 = Conversions.ToDouble(row["Cargo_Mass"]);
				double num5 = Conversions.ToDouble(row["Cargo_Area"]);
				long num6 = Conversions.ToLong(row["Cargo_Crew"]);
				double num7 = Conversions.ToDouble(row["Cargo_Type"]);
				if (!(num2 == 0.0 && num3 == 0.0 && num4 == 0.0 && num5 == 0.0 && num6 == 0L && num7 == 0.0))
				{
					if (num7 == 0.0 && (num4 != 0.0 || (ulong)num6 > 0uL || num5 != 0.0))
					{
						string text = "Ship has specified cargo values but no cargo type.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num7 != 0.0 && (num4 == 0.0 || num6 == 0L || num5 == 0.0))
					{
						string text = "Ship has specified cargo type but a value of zero for either area, mass or crew / troops. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 != 0.0 && num4 == 0.0)
					{
						string text = "Ship has Cargo Capacity of " + Conversions.ToString(num2) + " (mT) and a Cargo Mass value of 0! Should be: " + Conversions.ToString(num2) + " (mT) ";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num4 != 0.0 && num2 == 0.0)
					{
						string text = "Ship has Cargo Mass of  " + Conversions.ToString(num4) + " (mT) and a Cargo Capacity value of 0! Should be: " + Conversions.ToString(num4) + " (mT) ";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Ship" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 != num4)
					{
						string text = "Ship specified Cargo Capacity " + Conversions.ToString(num2) + " (mT) is not equal to Cargo Mass " + Conversions.ToString(num4) + " (mT).";
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
			ex2.Data.Add("Error at Validation 200022", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void ValidateMountCargoValues()
	{
		try
		{
			foreach (DataRow row in Common.get_DataMount(Common.mySourceDB_Helper).Rows)
			{
				int num = Conversions.ToInteger(row["ID"]);
				Common.StatusString = "ValidateMountCargoValues - Mount #" + Conversions.ToString(num);
				double num2 = Conversions.ToDouble(row["MobileUnitCategory"]);
				double num3 = Conversions.ToDouble(row["Cargo_Mass"]);
				double num4 = Conversions.ToDouble(row["Cargo_Area"]);
				long num5 = Conversions.ToLong(row["Cargo_Crew"]);
				double num6 = Conversions.ToDouble(row["Cargo_Type"]);
				if (!(num2 == 0.0 && num3 == 0.0 && num4 == 0.0 && num5 == 0L && num6 == 0.0))
				{
					if (num6 == 0.0 && (num3 != 0.0 || (ulong)num5 > 0uL || num4 != 0.0))
					{
						string text = "Mount has specified cargo values but no cargo type.";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 == 1000.0 && num5 == 0L)
					{
						string text = "Mount is Personnel Cargo Type but has a value of zero for crew / troops. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num2 == 1000.0 && num5 == 0L)
					{
						string text = "Mount is Infantry Mobile Unit Type but has a value of zero for crew / troops. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if (num6 == 1000.0 && num2 != 1000.0 && num2 != 4000.0 && num2 != 6000.0 && num2 != 7000.0 && num2 != 8000.0 && num2 != 9000.0 && num2 != 10000.0)
					{
						string text = "Mount is Personnel Cargo Type but has an inconsistent Mobile Unit Type. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
						Common.mySourceDB_Helper.ExecuteNonQuery(string_);
					}
					if ((num4 != 0.0 && num3 == 0.0) || (num4 == 0.0 && num3 != 0.0))
					{
						string text = "Mount has Cargo Mass but not Cargo Area, or Cargo Area but not Cargo Mass. Not logical!";
						string string_ = "INSERT INTO Validation ( ComponentID, SourceAnnex, ErrorText ) VALUES (" + Conversions.ToString(num) + ", " + Conversions.ToString(Convert.ToChar(34)) + "Mount" + Conversions.ToString(Convert.ToChar(34)) + ", '" + text + "');";
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
			ex2.Data.Add("Error at Validation 200024", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	static DataValidateCargo()
	{
		Class72.smethod_20();
	}
}
