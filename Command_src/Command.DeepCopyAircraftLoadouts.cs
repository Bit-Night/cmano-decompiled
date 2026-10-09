using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[StandardModule]
internal sealed class DeepCopyAircraftLoadouts
{
	private struct Struct3
	{
		public int ID;

		public string Name;

		public string string_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public int int_5;

		public int int_6;

		public float float_0;

		public int int_7;

		public int int_8;

		public int int_9;

		public bool bool_0;

		public bool bool_1;

		public bool bool_2;

		public int int_10;

		public int int_11;

		public int int_12;

		public int int_13;

		public int int_14;

		public int int_15;

		public int int_16;

		public int int_17;

		public int int_18;

		public int int_19;

		public bool bool_3;

		public int int_20;

		public List<Struct4> list_0;
	}

	private struct Struct4
	{
		public int ID;

		public int int_0;

		public int int_1;

		public bool bool_0;

		public bool bool_1;
	}

	private struct Struct5
	{
		public int ID;

		public string string_0;

		public string string_1;

		public string string_2;
	}

	private static short short_0;

	private static short short_1;

	static DeepCopyAircraftLoadouts()
	{
		Class72.smethod_20();
		short_0 = 4;
		short_1 = 3;
	}

	public static void PerformDeepCopy(int SourceAircraftID, int TargetAircraftID, bool RemoveExistingTargetLoadouts)
	{
		//IL_0dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df0: Unknown result type (might be due to invalid IL or missing references)
		DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable("SELECT Name, Comments, Description, YearCommissioned FROM DataAircraft, EnumOperatorCountry where EnumOperatorCountry.ID = DataAircraft.OperatorCountry AND DataAircraft.ID=" + Conversions.ToString(TargetAircraftID));
		if (dataTable.Rows.Count != 0)
		{
			string string_ = Conversions.ToString(Operators.ConcatenateObject((object)("Aircraft ID: " + Conversions.ToString(TargetAircraftID) + ", Name: "), dataTable.Rows[0]["Name"]));
			Conversions.ToString(dataTable.Rows[0]["Comments"]);
			Conversions.ToString(dataTable.Rows[0]["Description"]);
			string string_2 = ((!Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["YearCommissioned"], (object)0, true)) ? Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[0]["Name"], (object)", "), dataTable.Rows[0]["Description"]), (object)", "), dataTable.Rows[0]["YearCommissioned"])) : Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[0]["Name"], (object)", "), dataTable.Rows[0]["Description"])));
			if (RemoveExistingTargetLoadouts)
			{
				Common.mySourceDB_Helper.ExecuteNonQuery("DELETE FROM DataAircraftLoadouts WHERE ComponentID NOT IN (" + Conversions.ToString((int)short_0) + "," + Conversions.ToString((int)short_1) + ") AND ID=" + Conversions.ToString(TargetAircraftID));
			}
			List<int> list = new List<int>();
			DataTable dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable("SELECT * FROM DataLoadout WHERE ID IN (SELECT ComponentID FROM DataAircraftLoadouts WHERE ID=" + Conversions.ToString(SourceAircraftID) + ")");
			foreach (DataRow row in dataTable2.Rows)
			{
				Struct3 @struct = new Struct3
				{
					ID = Conversions.ToInteger(row["ID"])
				};
				if (@struct.ID == short_0 || @struct.ID == short_1)
				{
					continue;
				}
				@struct.Name = Conversions.ToString(row["Name"]);
				@struct.string_0 = Conversions.ToString(row["Comments"]);
				@struct.int_0 = Conversions.ToInteger(row["ROF"]);
				@struct.int_1 = Conversions.ToInteger(row["Capacity"]);
				@struct.int_2 = Conversions.ToInteger(row["ReadyTime"]);
				@struct.int_3 = Conversions.ToInteger(row["ReadyTime_Sustained"]);
				@struct.int_4 = Conversions.ToInteger(row["LoadoutRole"]);
				@struct.int_5 = Conversions.ToInteger(row["TimeOfDay"]);
				@struct.int_6 = Conversions.ToInteger(row["Weather"]);
				@struct.float_0 = Conversions.ToSingle(row["PayloadWeightDragModifier"]);
				@struct.int_7 = Conversions.ToInteger(row["DefaultCombatRadius"]);
				@struct.int_8 = Conversions.ToInteger(row["DefaultTimeOnStation"]);
				@struct.int_9 = Conversions.ToInteger(row["DefaultMissionProfile"]);
				@struct.bool_0 = Conversions.ToBoolean(row["RequiresBuddyIllumination"]);
				@struct.bool_1 = Conversions.ToBoolean(row["Hypothetical"]);
				@struct.bool_2 = Conversions.ToBoolean(row["QuickTurnaround"]);
				@struct.int_10 = Conversions.ToInteger(row["QuickTurnaround_ReadyTime"]);
				@struct.int_11 = Conversions.ToInteger(row["QuickTurnaround_MaxSorties"]);
				@struct.int_12 = Conversions.ToInteger(row["QuickTurnaround_AdditionalTimePenalty"]);
				@struct.int_13 = Conversions.ToInteger(row["QuickTurnaround_AirborneTime"]);
				@struct.int_14 = Conversions.ToInteger(row["QuickTurnaround_TimeOfDay"]);
				@struct.int_15 = Conversions.ToInteger(row["WinchesterShotgun"]);
				@struct.int_16 = Conversions.ToInteger(row["Cargo_Type"]);
				@struct.int_17 = Conversions.ToInteger(row["Cargo_Mass"]);
				@struct.int_18 = Conversions.ToInteger(row["Cargo_Area"]);
				@struct.int_19 = Conversions.ToInteger(row["Cargo_Crew"]);
				@struct.bool_3 = Conversions.ToBoolean(row["Cargo_ParadropCapable"]);
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Cargo_Volume"])))
				{
					@struct.int_20 = Conversions.ToInteger(row["Cargo_Volume"]);
				}
				DataTable dataTable3 = Common.mySourceDB_Helper.ExecuteDataTable("SELECT * FROM DataLoadoutWeapons WHERE ID=" + Conversions.ToString(@struct.ID));
				@struct.list_0 = new List<Struct4>();
				Struct5 struct2 = default(Struct5);
				struct2.ID = @struct.ID;
				struct2.string_2 = string_;
				struct2.string_1 = string_2;
				struct2.string_0 = struct2.string_1 + ": " + @struct.Name + ", " + @struct.string_0;
				foreach (DataRow row2 in dataTable3.Rows)
				{
					Struct4 item = new Struct4
					{
						ID = @struct.ID,
						int_0 = Conversions.ToInteger(row2["ComponentNumber"]),
						int_1 = Conversions.ToInteger(row2["ComponentID"]),
						bool_0 = Conversions.ToBoolean(row2["Optional"]),
						bool_1 = Conversions.ToBoolean(row2["Internal"])
					};
					@struct.list_0.Add(item);
				}
				int num = Conversions.ToInteger(Common.mySourceDB_Helper.ExecuteScalar("SELECT TOP 1 ID from DataLoadout order by ID DESC")) + 1;
				string string_3 = "INSERT INTO DataLoadout (ID, Name, Comments) VALUES (" + Conversions.ToString(num) + ", '" + @struct.Name + "', '" + @struct.string_0 + "')";
				int num2 = num;
				Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET ROF=" + Conversions.ToString(@struct.int_0) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Capacity=" + Conversions.ToString(@struct.int_1) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET ReadyTime=" + Conversions.ToString(@struct.int_2) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET ReadyTime_Sustained=" + Conversions.ToString(@struct.int_3) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET LoadoutRole=" + Conversions.ToString(@struct.int_4) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET TimeOfDay=" + Conversions.ToString(@struct.int_5) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Weather=" + Conversions.ToString(@struct.int_6) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET PayloadWeightDragModifier=" + Conversions.ToString(@struct.float_0) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET DefaultCombatRadius=" + Conversions.ToString(@struct.int_7) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET DefaultTimeOnStation=" + Conversions.ToString(@struct.int_8) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET DefaultMissionProfile=" + Conversions.ToString(@struct.int_9) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET RequiresBuddyIllumination=" + Conversions.ToString(0 - (@struct.bool_0 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Hypothetical=" + Conversions.ToString(0 - (@struct.bool_1 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround=" + Conversions.ToString(0 - (@struct.bool_2 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_ReadyTime=" + Conversions.ToString(@struct.int_10) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_MaxSorties=" + Conversions.ToString(@struct.int_11) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_AdditionalTimePenalty=" + Conversions.ToString(@struct.int_12) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_AirborneTime=" + Conversions.ToString(@struct.int_13) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_TimeOfDay=" + Conversions.ToString(@struct.int_14) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET WinchesterShotgun=" + Conversions.ToString(@struct.int_15) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Type=" + Conversions.ToString(@struct.int_16) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Mass=" + Conversions.ToString(@struct.int_17) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Area=" + Conversions.ToString(@struct.int_18) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Crew=" + Conversions.ToString(@struct.int_19) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_ParadropCapable=" + Conversions.ToString(0 - (@struct.bool_3 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Volume=" + Conversions.ToString(@struct.int_20) + " WHERE ID=" + Conversions.ToString(num2));
				string_3 = "INSERT INTO MiscLoadout (ID) VALUES (" + Conversions.ToString(num2) + ")";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE MiscLoadout SET FullName='" + struct2.string_0 + "' WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE MiscLoadout SET LoadoutUser='" + struct2.string_1 + "' WHERE ID=" + Conversions.ToString(num2));
				Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE MiscLoadout SET ProfileSummary='" + struct2.string_1 + "' WHERE ID=" + Conversions.ToString(num2));
				foreach (Struct4 item2 in @struct.list_0)
				{
					string_3 = "INSERT INTO DataLoadoutWeapons (ID, ComponentNumber, ComponentID, Optional, Internal) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(item2.int_0) + ", " + Conversions.ToString(item2.int_1) + ", " + Conversions.ToString(0 - (item2.bool_0 ? 1 : 0)) + ", " + Conversions.ToString(0 - (item2.bool_1 ? 1 : 0)) + ")";
					Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
				}
				list.Add(num2);
			}
			foreach (int item3 in list)
			{
				string string_3 = "INSERT INTO DataAircraftLoadouts (ID, ComponentID) VALUES (" + Conversions.ToString(TargetAircraftID) + ", " + Conversions.ToString(item3) + ")";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
			}
			Interaction.MsgBox((object)("Done! " + Conversions.ToString(list.Count) + " loadouts were deep-copied and referenced by the target aircraft.\r\n\r\n***WARNING***: The clone loadouts retain the properties of their originals, such as fuel consumption etc., which may no longer be accurate for the clones. PLEASE re-calculate/re-populate values as necessary!"), (MsgBoxStyle)0, (object)null);
		}
		else
		{
			Interaction.MsgBox((object)"No target aircraft with this ID is present! Aborting...", (MsgBoxStyle)0, (object)null);
		}
	}

	public static void PerformLoadoutDuplication(int SourceLoadoutID, int TargetAircraftID)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		DataTable dataTable = Common.mySourceDB_Helper.ExecuteDataTable("SELECT Name, Comments, Description, YearCommissioned FROM DataAircraft, EnumOperatorCountry where EnumOperatorCountry.ID = DataAircraft.OperatorCountry AND DataAircraft.ID=" + Conversions.ToString(TargetAircraftID));
		if (dataTable.Rows.Count == 0)
		{
			Interaction.MsgBox((object)("No target aircraft with ID " + Conversions.ToString(TargetAircraftID) + " is present in the selected DB!"), (MsgBoxStyle)0, (object)null);
			return;
		}
		string string_ = Conversions.ToString(Operators.ConcatenateObject((object)("Aircraft ID: " + Conversions.ToString(TargetAircraftID) + ", Name: "), dataTable.Rows[0]["Name"]));
		Conversions.ToString(dataTable.Rows[0]["Comments"]);
		Conversions.ToString(dataTable.Rows[0]["Description"]);
		string string_2 = (Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["YearCommissioned"], (object)0, true) ? Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[0]["Name"], (object)", "), dataTable.Rows[0]["Description"])) : Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[0]["Name"], (object)", "), dataTable.Rows[0]["Description"]), (object)", "), dataTable.Rows[0]["YearCommissioned"])));
		List<int> list = new List<int>();
		DataTable dataTable2 = Common.mySourceDB_Helper.ExecuteDataTable("SELECT * FROM DataLoadout WHERE ID =" + Conversions.ToString(SourceLoadoutID));
		foreach (DataRow row in dataTable2.Rows)
		{
			Struct3 @struct = new Struct3
			{
				ID = Conversions.ToInteger(row["ID"])
			};
			if (@struct.ID == 3 || @struct.ID == 4)
			{
				continue;
			}
			@struct.Name = Conversions.ToString(row["Name"]);
			@struct.string_0 = Conversions.ToString(row["Comments"]);
			@struct.int_0 = Conversions.ToInteger(row["ROF"]);
			@struct.int_1 = Conversions.ToInteger(row["Capacity"]);
			@struct.int_2 = Conversions.ToInteger(row["ReadyTime"]);
			@struct.int_3 = Conversions.ToInteger(row["ReadyTime_Sustained"]);
			@struct.int_4 = Conversions.ToInteger(row["LoadoutRole"]);
			@struct.int_5 = Conversions.ToInteger(row["TimeOfDay"]);
			@struct.int_6 = Conversions.ToInteger(row["Weather"]);
			@struct.float_0 = Conversions.ToSingle(row["PayloadWeightDragModifier"]);
			@struct.int_7 = Conversions.ToInteger(row["DefaultCombatRadius"]);
			@struct.int_8 = Conversions.ToInteger(row["DefaultTimeOnStation"]);
			@struct.int_9 = Conversions.ToInteger(row["DefaultMissionProfile"]);
			@struct.bool_0 = Conversions.ToBoolean(row["RequiresBuddyIllumination"]);
			@struct.bool_1 = Conversions.ToBoolean(row["Hypothetical"]);
			@struct.bool_2 = Conversions.ToBoolean(row["QuickTurnaround"]);
			@struct.int_10 = Conversions.ToInteger(row["QuickTurnaround_ReadyTime"]);
			@struct.int_11 = Conversions.ToInteger(row["QuickTurnaround_MaxSorties"]);
			@struct.int_12 = Conversions.ToInteger(row["QuickTurnaround_AdditionalTimePenalty"]);
			@struct.int_13 = Conversions.ToInteger(row["QuickTurnaround_AirborneTime"]);
			@struct.int_14 = Conversions.ToInteger(row["QuickTurnaround_TimeOfDay"]);
			@struct.int_15 = Conversions.ToInteger(row["WinchesterShotgun"]);
			@struct.int_16 = Conversions.ToInteger(row["Cargo_Type"]);
			@struct.int_17 = Conversions.ToInteger(row["Cargo_Mass"]);
			@struct.int_18 = Conversions.ToInteger(row["Cargo_Area"]);
			@struct.int_19 = Conversions.ToInteger(row["Cargo_Crew"]);
			@struct.bool_3 = Conversions.ToBoolean(row["Cargo_ParadropCapable"]);
			if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(row["Cargo_Volume"])))
			{
				@struct.int_20 = Conversions.ToInteger(row["Cargo_Volume"]);
			}
			DataTable dataTable3 = Common.mySourceDB_Helper.ExecuteDataTable("SELECT * FROM DataLoadoutWeapons WHERE ID=" + Conversions.ToString(@struct.ID));
			@struct.list_0 = new List<Struct4>();
			Struct5 struct2 = default(Struct5);
			struct2.ID = @struct.ID;
			struct2.string_2 = string_;
			struct2.string_1 = string_2;
			struct2.string_0 = struct2.string_1 + ": " + @struct.Name + ", " + @struct.string_0;
			foreach (DataRow row2 in dataTable3.Rows)
			{
				Struct4 item = new Struct4
				{
					ID = @struct.ID,
					int_0 = Conversions.ToInteger(row2["ComponentNumber"]),
					int_1 = Conversions.ToInteger(row2["ComponentID"]),
					bool_0 = Conversions.ToBoolean(row2["Optional"]),
					bool_1 = Conversions.ToBoolean(row2["Internal"])
				};
				@struct.list_0.Add(item);
			}
			int num = Conversions.ToInteger(Common.mySourceDB_Helper.ExecuteScalar("SELECT TOP 1 ID from DataLoadout order by ID DESC")) + 1;
			string string_3 = "INSERT INTO DataLoadout (ID, Name, Comments) VALUES (" + Conversions.ToString(num) + ", '" + @struct.Name + "', '" + @struct.string_0 + "')";
			int num2 = num;
			Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET ROF=" + Conversions.ToString(@struct.int_0) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Capacity=" + Conversions.ToString(@struct.int_1) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET ReadyTime=" + Conversions.ToString(@struct.int_2) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET ReadyTime_Sustained=" + Conversions.ToString(@struct.int_3) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET LoadoutRole=" + Conversions.ToString(@struct.int_4) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET TimeOfDay=" + Conversions.ToString(@struct.int_5) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Weather=" + Conversions.ToString(@struct.int_6) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET PayloadWeightDragModifier=" + Conversions.ToString(@struct.float_0) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET DefaultCombatRadius=" + Conversions.ToString(@struct.int_7) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET DefaultTimeOnStation=" + Conversions.ToString(@struct.int_8) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET DefaultMissionProfile=" + Conversions.ToString(@struct.int_9) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET RequiresBuddyIllumination=" + Conversions.ToString(0 - (@struct.bool_0 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Hypothetical=" + Conversions.ToString(0 - (@struct.bool_1 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround=" + Conversions.ToString(0 - (@struct.bool_2 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_ReadyTime=" + Conversions.ToString(@struct.int_10) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_MaxSorties=" + Conversions.ToString(@struct.int_11) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_AdditionalTimePenalty=" + Conversions.ToString(@struct.int_12) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_AirborneTime=" + Conversions.ToString(@struct.int_13) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET QuickTurnaround_TimeOfDay=" + Conversions.ToString(@struct.int_14) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET WinchesterShotgun=" + Conversions.ToString(@struct.int_15) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Type=" + Conversions.ToString(@struct.int_16) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Mass=" + Conversions.ToString(@struct.int_17) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Area=" + Conversions.ToString(@struct.int_18) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Crew=" + Conversions.ToString(@struct.int_19) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_ParadropCapable=" + Conversions.ToString(0 - (@struct.bool_3 ? 1 : 0)) + " WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE DataLoadout SET Cargo_Volume=" + Conversions.ToString(@struct.int_20) + " WHERE ID=" + Conversions.ToString(num2));
			string_3 = "INSERT INTO MiscLoadout (ID) VALUES (" + Conversions.ToString(num2) + ")";
			Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE MiscLoadout SET FullName='" + struct2.string_0 + "' WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE MiscLoadout SET LoadoutUser='" + struct2.string_1 + "' WHERE ID=" + Conversions.ToString(num2));
			Common.mySourceDB_Helper.ExecuteNonQuery("UPDATE MiscLoadout SET ProfileSummary='" + struct2.string_1 + "' WHERE ID=" + Conversions.ToString(num2));
			foreach (Struct4 item2 in @struct.list_0)
			{
				string_3 = "INSERT INTO DataLoadoutWeapons (ID, ComponentNumber, ComponentID, Optional, Internal) VALUES (" + Conversions.ToString(num2) + ", " + Conversions.ToString(item2.int_0) + ", " + Conversions.ToString(item2.int_1) + ", " + Conversions.ToString(0 - (item2.bool_0 ? 1 : 0)) + ", " + Conversions.ToString(0 - (item2.bool_1 ? 1 : 0)) + ")";
				Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
			}
			list.Add(num2);
		}
		Common.mySourceDB_Helper.ExecuteNonQuery("DELETE FROM DataAircraftLoadouts WHERE ComponentID = " + Conversions.ToString(SourceLoadoutID) + " AND ID = " + Conversions.ToString(TargetAircraftID));
		foreach (int item3 in list)
		{
			string string_3 = "INSERT INTO DataAircraftLoadouts (ID, ComponentID) VALUES (" + Conversions.ToString(TargetAircraftID) + ", " + Conversions.ToString(item3) + ")";
			Common.mySourceDB_Helper.ExecuteNonQuery(string_3);
		}
	}
}
