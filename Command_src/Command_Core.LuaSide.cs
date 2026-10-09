using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core;

[StandardModule]
internal sealed class LuaSide
{
	public static LuaWrapper_Side ScenEdit_AddSide(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		string text = null;
		Side side = null;
		LuaUtility.ParseSideDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			try
			{
				text = Conversions.ToString(dict["SIDE"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM148", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Side must be a string");
			}
			try
			{
				side = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM149", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		if (side != null)
		{
			throw new LuaError("Side " + text + " already exists");
		}
		if (dict.ContainsKey("NAME"))
		{
			try
			{
				text = Conversions.ToString(dict["NAME"]);
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at PM150", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Side must be a string");
			}
		}
		if (Information.IsNothing((object)text))
		{
			throw new LuaError("side or name must be declared");
		}
		try
		{
			side = LuaUtility.QuerySide(dict, ScenarioContext);
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at PM151", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (side != null)
		{
			throw new LuaError("Side " + text + " already exists");
		}
		Side theSide = new Side(text, ref ScenarioContext);
		ScenarioContext.AddSide(theSide);
		return new LuaWrapper_Side(theSide, ScenarioContext);
	}

	public static LuaWrapper_Side ScenEdit_RemoveSide(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		Side side = null;
		LuaUtility.ParseSideDict(ref dict);
		if (dict.ContainsKey("SIDE"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["SIDE"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM152", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("side must be a string");
			}
			try
			{
				side = LuaUtility.QuerySide(dict, ScenarioContext);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM153", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("Can't find Side '" + text + "'");
			}
		}
		LuaWrapper_Side result = new LuaWrapper_Side(side, ScenarioContext);
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
		{
			if (activeUnits_ == null || !activeUnits_.get_UnitSide(SetSideOnly: false).Equals(side))
			{
				continue;
			}
			activeUnit = activeUnits_;
			if (!activeUnit.IsGroup)
			{
				if (!ScenarioContext.ExecutionInProgress)
				{
					ScenarioContext.DeleteUnitImmediately(activeUnit.ObjectID, ScenEditAction: true, "Deleted via Lua command.", null, RegisterAsLosses: false);
				}
				else
				{
					ScenarioContext.DeleteThisUnit(activeUnit);
				}
			}
			else
			{
				list.Add(activeUnit);
			}
		}
		if (list.Count > 0)
		{
			foreach (ActiveUnit item in list)
			{
				if (item != null)
				{
					activeUnit = item;
					if (ScenarioContext.ExecutionInProgress)
					{
						ScenarioContext.DeleteThisUnit(activeUnit);
					}
					else
					{
						ScenarioContext.DeleteUnitImmediately(activeUnit.ObjectID, ScenEditAction: true, "Deleted via Lua command.", null, RegisterAsLosses: false);
					}
				}
			}
		}
		List<string> list2 = new List<string>();
		foreach (KeyValuePair<string, UnguidedWeapon> unguidedWeapon in ScenarioContext.UnguidedWeapons)
		{
			if (unguidedWeapon.Value.get_UnitSide(SetSideOnly: false) == side)
			{
				list2.Add(unguidedWeapon.Key);
			}
		}
		UnguidedWeapon value = null;
		foreach (string item2 in list2)
		{
			string theWeapon_ObjectID = item2;
			ScenarioContext.UnguidedWeapons.TryRemove(theWeapon_ObjectID, out value);
			side.RemoveWeaponFromSalvos(ref ScenarioContext, ref theWeapon_ObjectID);
		}
		ScenarioContext.RemoveSide(side);
		return result;
	}

	public static LuaTable ScenEdit_SetSideOptions(LuaTable table, Scenario ScenarioContext)
	{
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
			Side side = null;
			if (dictionary.ContainsKey("SIDE"))
			{
				string text = null;
				try
				{
					text = Conversions.ToString(dictionary["SIDE"]);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at PM13", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					throw new LuaError("side must be a string");
				}
				try
				{
					side = LuaUtility.QuerySide(dictionary, ScenarioContext);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at PM14", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
			if (side == null)
			{
				return null;
			}
			if (dictionary.ContainsKey("AWARENESS"))
			{
				int num4;
				int num2;
				int num3;
				int num;
				Side.AwarenessLevel_Enum awarenessLevel;
				switch (Conversions.ToString(dictionary["AWARENESS"]).ToUpperInvariant())
				{
				case "0":
					num4 = 0;
					goto IL_01b8;
				case "1":
					num2 = 1;
					goto IL_0297;
				case "NORMAL":
					num4 = 0;
					goto IL_01b8;
				case "2":
					num3 = 2;
					goto IL_023e;
				case "AUTOUNIT":
					num3 = 2;
					goto IL_023e;
				case "AUTOSIDEANDUNITID":
					num3 = 2;
					goto IL_023e;
				case "AUTOSIDEID":
					num2 = 1;
					goto IL_0297;
				case "OMNISCIENT":
					num = 3;
					goto IL_02e0;
				case "AUTOSIDE":
					num2 = 1;
					goto IL_0297;
				case "-1":
				case "BLIND":
					awarenessLevel = Side.AwarenessLevel_Enum.Blind;
					break;
				default:
					throw new LuaError("Invalid awareness code! (Valid codes: -1 ... 3)");
				case "3":
				case "OMNI":
					{
						num = 3;
						goto IL_02e0;
					}
					IL_02e0:
					awarenessLevel = (Side.AwarenessLevel_Enum)num;
					break;
					IL_023e:
					awarenessLevel = (Side.AwarenessLevel_Enum)num3;
					break;
					IL_0297:
					awarenessLevel = (Side.AwarenessLevel_Enum)num2;
					break;
					IL_01b8:
					awarenessLevel = (Side.AwarenessLevel_Enum)num4;
					break;
				}
				side.AwarenessLevel = awarenessLevel;
			}
			if (dictionary.ContainsKey("PROFICIENCY"))
			{
				int num7;
				int num8;
				int num9;
				int num6;
				int num5;
				GlobalVariables.ProficiencyLevel proficiency;
				switch (Conversions.ToString(dictionary["PROFICIENCY"]).ToUpperInvariant())
				{
				case "ACE":
					num7 = 4;
					goto IL_043a;
				case "VETERAN":
					num8 = 3;
					goto IL_03d8;
				case "REGULAR":
					num9 = 2;
					goto IL_03be;
				case "2":
					num9 = 2;
					goto IL_03be;
				case "3":
					num8 = 3;
					goto IL_03d8;
				case "0":
					num6 = 0;
					goto IL_0463;
				case "1":
					num5 = 1;
					goto IL_0483;
				case "4":
					num7 = 4;
					goto IL_043a;
				case "NOVICE":
					num6 = 0;
					goto IL_0463;
				default:
					throw new LuaError("Invalid proficiency code! (Valid codes: 0 ... 4)");
				case "CADET":
					{
						num5 = 1;
						goto IL_0483;
					}
					IL_0483:
					proficiency = (GlobalVariables.ProficiencyLevel)num5;
					break;
					IL_0463:
					proficiency = (GlobalVariables.ProficiencyLevel)num6;
					break;
					IL_03be:
					proficiency = (GlobalVariables.ProficiencyLevel)num9;
					break;
					IL_03d8:
					proficiency = (GlobalVariables.ProficiencyLevel)num8;
					break;
					IL_043a:
					proficiency = (GlobalVariables.ProficiencyLevel)num7;
					break;
				}
				side.Proficiency = proficiency;
			}
			if (dictionary.ContainsKey("SWITCHTO"))
			{
				bool? flag = LuaUtility.ParseBoolean(dictionary["SWITCHTO"].ToString());
				if (flag.HasValue)
				{
					bool? flag2 = flag;
					flag2 = flag2;
					if (flag2 == true)
					{
						ScenarioContext.SetCurrentSide(side);
					}
				}
			}
			if (dictionary.ContainsKey("AUTOTRACKCIVILLIANS"))
			{
				string value = Conversions.ToString(dictionary["AUTOTRACKCIVILLIANS"]).ToUpperInvariant();
				bool? flag3 = null;
				flag3 = LuaUtility.ParseBoolean(value);
				if (flag3.HasValue)
				{
					side.CanAutoTrackCivs = flag3.Value;
				}
			}
			if (dictionary.ContainsKey("COMPUTERCONTROLLEDONLY"))
			{
				string value2 = Conversions.ToString(dictionary["COMPUTERCONTROLLEDONLY"]).ToUpperInvariant();
				bool? flag4 = null;
				flag4 = LuaUtility.ParseBoolean(value2);
				if (flag4.HasValue)
				{
					side.IsAIOnly = flag4.Value;
				}
			}
			if (dictionary.ContainsKey("COLLECTIVERESPONSIBILITY"))
			{
				string value3 = Conversions.ToString(dictionary["COLLECTIVERESPONSIBILITY"]).ToUpperInvariant();
				bool? flag5 = null;
				flag5 = LuaUtility.ParseBoolean(value3);
				if (flag5.HasValue)
				{
					side.AssignsCollectiveResponsibility = flag5.Value;
				}
			}
			return PrivateMethods.ScenEdit_GetSideOptions(table, ScenarioContext);
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at PM15", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ScenEdit_GetSideIsHuman(string SideANameOrID, Scenario ScenarioContext)
	{
		try
		{
			Side side = null;
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				side = sides_ReadOnly[i];
				if (string.Equals(side.Name, SideANameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, SideANameOrID, StringComparison.OrdinalIgnoreCase))
				{
					side = side;
					break;
				}
			}
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to identify side!");
			}
			return side.IsHumanControlled;
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

	public static bool ScenEdit_GetSideIsPlayer(string SideANameOrID, Scenario ScenarioContext)
	{
		try
		{
			Side side = null;
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				side = sides_ReadOnly[i];
				if (string.Equals(side.Name, SideANameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, SideANameOrID, StringComparison.OrdinalIgnoreCase))
				{
					side = side;
					break;
				}
			}
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to identify side!");
			}
			return side.IsPlayerControlled;
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

	public static Side ValidateSide(string SideName, Scenario theScen)
	{
		Side result = null;
		Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (string.Equals(side.Name, SideName, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, SideName, StringComparison.OrdinalIgnoreCase))
			{
				result = side;
				break;
			}
		}
		return result;
	}

	public static LuaWrapper_Side VP_GetSide(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		Side side = null;
		LuaUtility.ParseSideDict(ref dict);
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at PM189", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("guid must be a string");
			}
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side2 in sides_ReadOnly)
			{
				if (string.Equals(side2.ObjectID, text, StringComparison.OrdinalIgnoreCase))
				{
					side = side2;
					break;
				}
			}
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to find side matching guid:  " + text);
			}
		}
		else if (dict.ContainsKey("SIDE"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dict["SIDE"]);
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at PM190", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new LuaError("name must be a string");
			}
			side = LuaUtility.QuerySide(dict, ScenarioContext);
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to find side matching name: " + text2);
			}
		}
		if (Information.IsNothing((object)side))
		{
			throw new LuaError("Unable to find side");
		}
		return new LuaWrapper_Side(side, ScenarioContext);
	}

	public static LuaTable VP_GetSides(Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
		foreach (Side theSide in sides_ReadOnly)
		{
			luaTable[luaTable.Keys.Count + 1] = new LuaWrapper_Side(theSide, ScenarioContext);
		}
		return luaTable;
	}

	public static bool ScenEdit_SetSidePosture(string SideANameOrID, string SideBNameOrID, string PostureCode, Scenario ScenarioContext)
	{
		try
		{
			Side side = null;
			Side side2 = null;
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			foreach (Side side3 in sides_ReadOnly)
			{
				if (string.Equals(side3.ObjectID, SideANameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, SideANameOrID, StringComparison.OrdinalIgnoreCase))
				{
					side = side3;
				}
				if (string.Equals(side3.ObjectID, SideBNameOrID, StringComparison.OrdinalIgnoreCase) || string.Equals(side3.Name, SideBNameOrID, StringComparison.OrdinalIgnoreCase))
				{
					side2 = side3;
				}
			}
			if (Information.IsNothing((object)side))
			{
				throw new LuaError("Unable to identify Side-A!");
			}
			if (Information.IsNothing((object)side2))
			{
				throw new LuaError("Unable to identify Side-B!");
			}
			side.set_ConsidersThisSideToBe(side2, (Scenario)null, PostureCode switch
			{
				"F" => Misc.PostureStance.Friendly, 
				"H" => Misc.PostureStance.Hostile, 
				"N" => Misc.PostureStance.Neutral, 
				"U" => Misc.PostureStance.Unfriendly, 
				_ => throw new LuaError("Invalid posture code! (Valid codes: F, H, N, U)"), 
			});
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at PM12", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static LuaWrapper_Contact AddOrUpdateContact(Side TargetSide, Scenario theScen, LuaTable ContactData)
	{
		if (TargetSide.Units.Count != 0)
		{
			ActiveUnit value = null;
			ActiveUnit value2 = null;
			Contact value3 = null;
			Sensor sensor = null;
			DateTime minValue = DateTime.MinValue;
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(ContactData.GetEnumerator());
			if (dictionary.ContainsKey("DATE"))
			{
				(bool, int, int, int) tuple = LuaUtility.ParseDate_String(Conversions.ToString(dictionary["DATE"]), LuaUtility.DateFormat.DDMMYYYY);
				if (dictionary.ContainsKey("TIME"))
				{
					(bool, int, int, int) tuple2 = LuaUtility.ParseTime_String(Conversions.ToString(dictionary["TIME"]));
					minValue = new DateTime(tuple.Item4, tuple.Item3, tuple.Item2, tuple2.Item2, tuple2.Item3, tuple2.Item4);
					if (dictionary.ContainsKey("RANGE"))
					{
						float item = Convert.ToSingle(Conversions.ToString(dictionary["RANGE"]), CultureInfo.InvariantCulture);
						if (!dictionary.ContainsKey("SENSORPARENTID"))
						{
							throw new LuaError("Mandatory value SensorParentID is missing!");
						}
						string key = Conversions.ToString(dictionary["SENSORPARENTID"]);
						if (!theScen.ActiveUnits.TryGetValue(key, out value))
						{
							throw new LuaError("Value SensorParentID does not match the ID of any active unit in this scenario!");
						}
						if (dictionary.ContainsKey("SENSORID"))
						{
							string b = Conversions.ToString(dictionary["SENSORID"]);
							Sensor[] sensors_Cached = value.Sensors_Cached;
							foreach (Sensor sensor2 in sensors_Cached)
							{
								if (string.Equals(sensor2.ObjectID, b, StringComparison.OrdinalIgnoreCase))
								{
									sensor = sensor2;
									break;
								}
							}
							if (sensor == null)
							{
								throw new LuaError("Value SensorID does not match the ID of any sensor in the specified sensor parent!");
							}
							List<Geopoint_Struct> list = new List<Geopoint_Struct>();
							if (dictionary.ContainsKey("UNCERTAINITYAREA"))
							{
								string[] array = dictionary["UNCERTAINITYAREA"].ToString().Split(new char[1] { '|' });
								for (int j = 0; j < array.Length; j = checked(j + 1))
								{
									string[] source = array[j].Split(new char[1] { ';' });
									if (source.Count() == 2)
									{
										double theLon = Conversions.ToDouble(source.ElementAt(0));
										double theLat = Conversions.ToDouble(source.ElementAt(1));
										list.Add(new Geopoint_Struct(theLon, theLat));
									}
								}
							}
							if (list.Count < 3)
							{
								list.Clear();
							}
							if (!dictionary.ContainsKey("TARGETID"))
							{
								throw new LuaError("Mandatory value TargetID is missing!");
							}
							string key2 = Conversions.ToString(dictionary["TARGETID"]);
							if (!theScen.ActiveUnits.TryGetValue(key2, out value2))
							{
								throw new LuaError("Value TargetID does not match the ID of any active unit in this scenario!");
							}
							if (!value.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(value2.ObjectID, out value3))
							{
								value3 = Contact.Instantiate(value2);
							}
							(Contact, ActiveUnit, List<Sensor>, float, ActiveUnit_Sensory.SpecialDetectionMode, DateTime, List<Geopoint_Struct>) theDetectionRecord = (value3, value2, new List<Sensor>(new Sensor[1] { sensor }), item, ActiveUnit_Sensory.SpecialDetectionMode.LuaScript, minValue, list);
							TargetSide.Units[0].Sensory.HandleDetectedContact_OnGrid(value, TargetSide, theDetectionRecord, IgnoreLuaHook: true);
							TargetSide.ProcessContactListChanges(theScen);
							TargetSide.ProcessBaseContactListChanges(theScen);
							Contact value4 = null;
							if (!TargetSide.Contacts.TryGetValue(value2.ObjectID, out value4))
							{
								throw new LuaError("An unknwon error has occured! No contact matching the provided Target-unit ID can be located on the target side of the operation.");
							}
							if (dictionary.ContainsKey("NAME"))
							{
								value4.Name = Conversions.ToString(dictionary["NAME"]);
							}
							if (dictionary.ContainsKey("POSTURE"))
							{
								switch (Conversions.ToString(dictionary["POSTURE"]).ToUpperInvariant())
								{
								case "H":
									value4.set_Stance(TargetSide, MarkManually: false, Misc.PostureStance.Hostile);
									break;
								case "X":
									value4.set_Stance(TargetSide, MarkManually: false, Misc.PostureStance.Unknown);
									break;
								case "U":
									value4.set_Stance(TargetSide, MarkManually: false, Misc.PostureStance.Unfriendly);
									break;
								case "N":
									value4.set_Stance(TargetSide, MarkManually: false, Misc.PostureStance.Neutral);
									break;
								case "F":
									value4.set_Stance(TargetSide, MarkManually: false, Misc.PostureStance.Friendly);
									break;
								}
							}
							return new LuaWrapper_Contact(value4, theScen, TargetSide);
						}
						throw new LuaError("Mandatory value SensorID is missing!");
					}
					throw new LuaError("Mandatory value Range is missing!");
				}
				throw new LuaError("Mandatory value Time is missing!");
			}
			throw new LuaError("Mandatory value Date is missing!");
		}
		throw new LuaError("Target side must have at least one active unit!");
	}

	static LuaSide()
	{
		Class72.smethod_20();
	}
}
