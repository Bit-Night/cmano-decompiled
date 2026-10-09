using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[StandardModule]
public sealed class LuaDoctrine
{
	[CompilerGenerated]
	internal sealed class _Closure$__11-0
	{
		public string $VB$Local_Name;

		public _Closure$__11-0(_Closure$__11-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			return string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__11-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__11-1
	{
		public string $VB$Local_MissionString;

		public _Closure$__11-1(_Closure$__11-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionString = arg0.$VB$Local_MissionString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Mission s)
		{
			if (!string.Equals(s.Name, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__11-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-0
	{
		public string $VB$Local_Name;

		public _Closure$__12-0(_Closure$__12-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_Name = arg0.$VB$Local_Name;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_Name, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_Name, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__12-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__12-1
	{
		public string $VB$Local_MissionString;

		public _Closure$__12-1(_Closure$__12-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionString = arg0.$VB$Local_MissionString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__2(Mission s)
		{
			if (string.Equals(s.Name, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__12-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__13-0
	{
		public string $VB$Local_NameString;

		public _Closure$__13-0(_Closure$__13-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NameString = arg0.$VB$Local_NameString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_NameString, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_NameString, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__13-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__13-1
	{
		public string $VB$Local_MissionString;

		public _Closure$__13-1(_Closure$__13-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionString = arg0.$VB$Local_MissionString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Mission s)
		{
			if (!string.Equals(s.Name, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__13-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__14-0
	{
		public string $VB$Local_NameString;

		public _Closure$__14-0(_Closure$__14-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_NameString = arg0.$VB$Local_NameString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit s)
		{
			if (!string.Equals(s.Name, $VB$Local_NameString, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_NameString, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__14-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__14-1
	{
		public string $VB$Local_MissionString;

		public _Closure$__14-1(_Closure$__14-1 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_MissionString = arg0.$VB$Local_MissionString;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Mission s)
		{
			if (!string.Equals(s.Name, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_MissionString, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__14-1()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__20-0
	{
		public Side $VB$Local_mySide;

		public Func<ActiveUnit, bool> $I0;

		public _Closure$__20-0(_Closure$__20-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_mySide = arg0.$VB$Local_mySide;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit AU)
		{
			return AU.get_UnitSide(SetSideOnly: false) == $VB$Local_mySide;
		}

		static _Closure$__20-0()
		{
			Class72.smethod_20();
		}
	}

	private static Dictionary<int, Doctrine.WRA_Weapon> dictionary_0;

	private static Dictionary<string, string> dictionary_1;

	private static Dictionary<string, string> dictionary_2;

	static LuaDoctrine()
	{
		Class72.smethod_20();
		dictionary_1 = new Dictionary<string, string>();
		dictionary_2 = new Dictionary<string, string>();
	}

	private static void smethod_0()
	{
		if (dictionary_1.Count > 0)
		{
			return;
		}
		foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition in Doctrine.DoctrineDefinitions)
		{
			string text = "Values are: ";
			foreach (KeyValuePair<int, string> state in doctrineDefinition.Value.States)
			{
				text = text + state.Value + " = " + state.Key + " ";
			}
			dictionary_1.Add(doctrineDefinition.Value.ID, doctrineDefinition.Value.LuaID);
			dictionary_2.Add(doctrineDefinition.Value.ID, text);
		}
	}

	public static void AUTOTEST()
	{
		string text = "BLUE";
		string text2 = text2 + "Tool_BuildBlankScenario()" + Environment.NewLine;
		text2 = text2 + "ScenEdit_AddSide({side = \"" + text + "\"})" + Environment.NewLine;
		foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition in Doctrine.DoctrineDefinitions)
		{
			foreach (KeyValuePair<int, string> state in doctrineDefinition.Value.States)
			{
				text2 = text2 + "ScenEdit_SetDoctrine({side =\"" + text + "\"},{" + doctrineDefinition.Value.LuaID + " = \"" + state.Value + "\"})" + Environment.NewLine;
			}
		}
		foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition2 in Doctrine.DoctrineDefinitions)
		{
			foreach (KeyValuePair<int, string> state2 in doctrineDefinition2.Value.States)
			{
				text2 = text2 + "ScenEdit_SetDoctrine({side =\"" + text + "\"},{" + doctrineDefinition2.Value.LuaID + " = " + state2.Key + "})" + Environment.NewLine;
			}
		}
		foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition3 in Doctrine.DoctrineDefinitions)
		{
			text2 = text2 + "print(ScenEdit_GetDoctrine({side=\"" + text + "\"})." + doctrineDefinition3.Value.LuaID + ")" + Environment.NewLine;
		}
	}

	public static LuaTable ScenEdit_SetDoctrine(LuaTable table, LuaTable d, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		Doctrine doctrine = null;
		Side side = null;
		if (!dictionary.ContainsKey("GUID"))
		{
			if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
			{
				if (dictionary.ContainsKey("MISSION"))
				{
					_Closure$__11-1 arg = default(_Closure$__11-1);
					_Closure$__11-1 CS$<>8__locals10 = new _Closure$__11-1(arg);
					CS$<>8__locals10.$VB$Local_MissionString = Conversions.ToString(dictionary["MISSION"]);
					if (!dictionary.ContainsKey("SIDE"))
					{
						throw new LuaError("To select a mission you need to define a side.");
					}
					string text = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("Can't find Side '" + text + "'");
					}
					try
					{
						Mission mission = side.Missions.FirstOrDefault([SpecialName] (Mission s) => string.Equals(s.Name, CS$<>8__locals10.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals10.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase));
						doctrine = ((!(dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike))) ? mission.Doctrine : ((Strike)mission).Doctrine_Escorts);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Can't find Mission '" + CS$<>8__locals10.$VB$Local_MissionString + "'");
					}
				}
				else if (dictionary.ContainsKey("SIDE"))
				{
					string text2 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
						doctrine = side.Doctrine;
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Can't find Side '" + text2 + "'");
					}
				}
			}
			else
			{
				_Closure$__11-0 arg2 = default(_Closure$__11-0);
				_Closure$__11-0 CS$<>8__locals12 = new _Closure$__11-0(arg2);
				CS$<>8__locals12.$VB$Local_Name = null;
				if (!dictionary.ContainsKey("NAME"))
				{
					if (dictionary.ContainsKey("UNITNAME"))
					{
						CS$<>8__locals12.$VB$Local_Name = Conversions.ToString(dictionary["UNITNAME"]);
					}
				}
				else
				{
					CS$<>8__locals12.$VB$Local_Name = Conversions.ToString(dictionary["NAME"]);
				}
				if (dictionary.ContainsKey("SIDE"))
				{
					string text3 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Can't find Side '" + text3 + "'");
					}
					try
					{
						doctrine = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals12.$VB$Local_Name, StringComparison.OrdinalIgnoreCase)).Doctrine;
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Can't find Unit '" + CS$<>8__locals12.$VB$Local_Name + "' on Side '" + text3 + "'");
					}
				}
				else
				{
					try
					{
						doctrine = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals12.$VB$Local_Name, StringComparison.OrdinalIgnoreCase)).Doctrine;
					}
					catch (Exception projectError6)
					{
						ProjectData.SetProjectError(projectError6);
						throw new LuaError("Can't find Unit '" + CS$<>8__locals12.$VB$Local_Name + "'");
					}
				}
			}
		}
		else
		{
			string text4 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doctrine = ScenarioContext.ActiveUnits[text4].Doctrine;
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("Can't find guid '" + text4 + "'");
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("Need to define a guid, or a name, or a side and name, or a side and mission, or just a side.");
		}
		dictionary = LuaUtility.ToDictLower(d.GetEnumerator());
		if (dictionary.Count == 0)
		{
			doctrine.InheritDoctrine(ref doctrine.SubjectType);
		}
		if (dictionary.ContainsKey("1") && string.Equals(Conversions.ToString(dictionary["1"]), "inherit", StringComparison.OrdinalIgnoreCase))
		{
			doctrine.InheritDoctrine(ref doctrine.SubjectType);
		}
		foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition in Doctrine.DoctrineDefinitions)
		{
			if (dictionary.ContainsKey(doctrineDefinition.Value.LuaID))
			{
				if (Operators.CompareString(Conversions.ToString(dictionary[doctrineDefinition.Value.LuaID]).ToLower(), "inherit", false) == 0)
				{
					doctrine.GetElement(doctrineDefinition.Value).set_CurrentState(ConsiderInheritance: false, (int?)null);
				}
				else
				{
					string text5 = Conversions.ToString(dictionary[doctrineDefinition.Value.LuaID]);
					bool result = false;
					Doctrine.DoctrineItem element = doctrine.GetElement(doctrineDefinition.Value);
					int result2 = 0;
					if (bool.TryParse(text5, out result))
					{
						doctrine.SetElementState(element.Definifition.EnumLink, Convert.ToInt32(result));
					}
					else if (!int.TryParse(text5, out result2))
					{
						result2 = 0;
						if (element.Definifition.GetState(text5).HasValue)
						{
							doctrine.SetElementState(element.Definifition.EnumLink, element.Definifition.GetState(text5));
						}
					}
					else
					{
						doctrine.SetElementState(element.Definifition.EnumLink, result2);
					}
				}
			}
			if (dictionary.ContainsKey(doctrineDefinition.Value.LuaID + "_player_editable"))
			{
				doctrine.GetElement(doctrineDefinition.Value).PlayerEditable = Conversions.ToBoolean(dictionary[doctrineDefinition.Value.LuaID + "_player_editable"]);
			}
		}
		d = ScenEdit_GetDoctrine(table, ScenarioContext);
		return d;
	}

	public static LuaTable ScenEdit_GetDoctrine(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		Doctrine doctrine = null;
		Side side = null;
		if (!dictionary.ContainsKey("GUID"))
		{
			if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
			{
				if (dictionary.ContainsKey("MISSION"))
				{
					_Closure$__12-1 arg = default(_Closure$__12-1);
					_Closure$__12-1 CS$<>8__locals10 = new _Closure$__12-1(arg);
					CS$<>8__locals10.$VB$Local_MissionString = Conversions.ToString(dictionary["MISSION"]);
					if (!dictionary.ContainsKey("SIDE"))
					{
						throw new LuaError("To select a mission you need to define a side.");
					}
					string text = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("Can't find Side '" + text + "'");
					}
					try
					{
						Mission mission = side.Missions.FirstOrDefault([SpecialName] (Mission s) => string.Equals(s.Name, CS$<>8__locals10.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals10.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase));
						doctrine = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Can't find Mission '" + CS$<>8__locals10.$VB$Local_MissionString + "'");
					}
				}
				else if (dictionary.ContainsKey("SIDE"))
				{
					string text2 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
						doctrine = side.Doctrine;
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Can't find Side '" + text2 + "'");
					}
				}
			}
			else
			{
				_Closure$__12-0 arg2 = default(_Closure$__12-0);
				_Closure$__12-0 CS$<>8__locals14 = new _Closure$__12-0(arg2);
				CS$<>8__locals14.$VB$Local_Name = null;
				if (!dictionary.ContainsKey("NAME"))
				{
					if (dictionary.ContainsKey("UNITNAME"))
					{
						CS$<>8__locals14.$VB$Local_Name = Conversions.ToString(dictionary["UNITNAME"]);
					}
				}
				else
				{
					CS$<>8__locals14.$VB$Local_Name = Conversions.ToString(dictionary["NAME"]);
				}
				if (!dictionary.ContainsKey("SIDE"))
				{
					try
					{
						doctrine = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals14.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals14.$VB$Local_Name, StringComparison.OrdinalIgnoreCase)).Doctrine;
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Can't find Unit '" + CS$<>8__locals14.$VB$Local_Name + "'");
					}
				}
				else
				{
					string text3 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Can't find Side '" + text3 + "'");
					}
					try
					{
						doctrine = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals14.$VB$Local_Name, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals14.$VB$Local_Name, StringComparison.OrdinalIgnoreCase)).Doctrine;
					}
					catch (Exception projectError6)
					{
						ProjectData.SetProjectError(projectError6);
						throw new LuaError("Can't find Unit '" + CS$<>8__locals14.$VB$Local_Name + "' on Side '" + text3 + "'");
					}
				}
			}
		}
		else
		{
			string text4 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doctrine = ScenarioContext.ActiveUnits[text4].Doctrine;
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("Can't find guid '" + text4 + "'");
			}
		}
		if (doctrine != null)
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			bool flag = false;
			bool flag2 = false;
			if (dictionary.ContainsKey("ACTUAL"))
			{
				flag2 = true;
			}
			if (dictionary.ContainsKey("PLAYER_EDITABLE"))
			{
				flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["PLAYER_EDITABLE"])).Value;
			}
			foreach (KeyValuePair<string, Doctrine.DoctrineDefinition> doctrineDefinition in Doctrine.DoctrineDefinitions)
			{
				Doctrine.DoctrineItem element = doctrine.GetElement(doctrineDefinition.Value);
				if (!element.IsInheriting || (element.IsInheriting && flag2))
				{
					luaTable[doctrineDefinition.Value.LuaID] = Conversions.ToInteger(element.get_CurrentState(ConsiderInheritance: true).ToString());
				}
				if (!element.IsInheriting && flag)
				{
					luaTable[doctrineDefinition.Value.LuaID + "_player_editable"] = (byte)(0u - (element.PlayerEditable ? 1u : 0u));
				}
			}
			if (!doctrine.EMCON_Inherits || (doctrine.EMCON_Inherits && flag2))
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["oecm"] = ((int)doctrine.EMCON(ScenarioContext).OECM()).ToString();
				luaTable2["radar"] = ((int)doctrine.EMCON(ScenarioContext).Radar()).ToString();
				luaTable2["sonar"] = ((int)doctrine.EMCON(ScenarioContext).Sonar()).ToString();
				luaTable["emcon"] = luaTable2;
			}
			return luaTable;
		}
		throw new LuaError("Need to define a guid, or a name, or a side and name, or a side and mission, or just a side.");
	}

	public static LuaTable ScenEdit_GetDoctrineWRA(LuaTable table, Scenario ScenarioContext)
	{
		_Closure$__13-0 arg = default(_Closure$__13-0);
		_Closure$__13-0 CS$<>8__locals12 = new _Closure$__13-0(arg);
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		ActiveUnit activeUnit = null;
		Doctrine doctrine = null;
		Side side = null;
		Contact theTarget = null;
		Weapon value = null;
		int num = -1;
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine._WRA_WeaponTargetType.None;
		string value2 = null;
		bool flag = false;
		LuaUtility.ParseUnitDict(ref dict);
		CS$<>8__locals12.$VB$Local_NameString = null;
		string text = null;
		if (dict.ContainsKey("GUID"))
		{
			string text2 = Conversions.ToString(dict["GUID"]);
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text2];
				side = activeUnit.get_UnitSide(SetSideOnly: false);
				doctrine = activeUnit.Doctrine;
				value2 = "UNIT";
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Can't find attacker '" + text2 + "'");
			}
		}
		else if (!dict.ContainsKey("NAME") && !dict.ContainsKey("UNITNAME"))
		{
			if (dict.ContainsKey("MISSION"))
			{
				_Closure$__13-1 arg2 = default(_Closure$__13-1);
				_Closure$__13-1 CS$<>8__locals10 = new _Closure$__13-1(arg2);
				CS$<>8__locals10.$VB$Local_MissionString = Conversions.ToString(dict["MISSION"]);
				if (!dict.ContainsKey("SIDE"))
				{
					throw new LuaError("To select a mission you need to define a side.");
				}
				text = Conversions.ToString(dict["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					throw new LuaError("Can't find Side '" + text + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault([SpecialName] (Mission s) => string.Equals(s.Name, CS$<>8__locals10.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals10.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase));
					doctrine = ((!(dict.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike))) ? mission.Doctrine : ((Strike)mission).Doctrine_Escorts);
					value2 = "MISSION";
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("Can't find Mission '" + CS$<>8__locals10.$VB$Local_MissionString + "'");
				}
			}
			else if (dict.ContainsKey("SIDE"))
			{
				text = Conversions.ToString(dict["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
					doctrine = side.Doctrine;
					value2 = "SIDE";
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
		}
		else
		{
			if (dict.ContainsKey("SIDE"))
			{
				text = Conversions.ToString(dict["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dict, ScenarioContext);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("Can't find Side '" + text + "'");
				}
			}
			if (dict.ContainsKey("NAME"))
			{
				CS$<>8__locals12.$VB$Local_NameString = Conversions.ToString(dict["NAME"]);
			}
			if (dict.ContainsKey("UNITNAME"))
			{
				CS$<>8__locals12.$VB$Local_NameString = Conversions.ToString(dict["UNITNAME"]);
			}
			if (side == null)
			{
				foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
				{
					if (string.Equals(activeUnits_.Name, CS$<>8__locals12.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, CS$<>8__locals12.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase))
					{
						activeUnit = activeUnits_;
						side = activeUnit.get_UnitSide(SetSideOnly: false);
						doctrine = activeUnit.Doctrine;
						break;
					}
				}
			}
			else
			{
				activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals12.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals12.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase));
				doctrine = activeUnit.Doctrine;
			}
			value2 = "UNIT";
		}
		if (dict.ContainsKey("CONTACT_ID"))
		{
			string text3 = Conversions.ToString(dict["CONTACT_ID"]);
			try
			{
				Scenario scenarioContext = ScenarioContext;
				Side Side = null;
				theTarget = LuaUtility.ValidAsContact(text3, scenarioContext, ref Side);
			}
			catch (Exception projectError6)
			{
				ProjectData.SetProjectError(projectError6);
				throw new LuaError("Can't find contact '" + text3 + "'");
			}
		}
		else if (dict.ContainsKey("TARGET_TYPE"))
		{
			string text4 = Conversions.ToString(dict["TARGET_TYPE"]);
			try
			{
				if (!(Enum.TryParse<Doctrine._WRA_WeaponTargetType>(text4, ignoreCase: true, out var result) & Enum.IsDefined(typeof(Doctrine._WRA_WeaponTargetType), result)))
				{
					throw new LuaError("Can't find target type '" + text4 + "'");
				}
				wRA_WeaponTargetType = result;
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("Can't find target type '" + text4 + "'");
			}
		}
		if (!dict.ContainsKey("WEAPON_ID") && !dict.ContainsKey("WEAPON_DBID"))
		{
			if (dict.ContainsKey("WEAPON_TYPE"))
			{
				try
				{
					Weapon._WeaponType weaponType = Weapon._WeaponType.None;
					if (dict.ContainsKey("WEAPON_TYPE"))
					{
						weaponType = (Weapon._WeaponType)Conversions.ToShort(dict["WEAPON_TYPE"]);
					}
					if (activeUnit != null)
					{
						foreach (Mount mount in activeUnit.Mounts)
						{
							if (mount.Status == PlatformComponent._ComponentStatus.Destroyed)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon in mount.MountWeapons)
							{
								if (mountWeapon.StoreType(ScenarioContext) == weaponType)
								{
									num = mountWeapon.int_3;
									value = mountWeapon.get_ReferenceWeapon(ScenarioContext);
									break;
								}
							}
							if (num != -1)
							{
								break;
							}
						}
						if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
						{
							WeaponRec[] weapons = ((Aircraft)activeUnit).Loadout.Weapons;
							foreach (WeaponRec weaponRec in weapons)
							{
								if (weaponRec.StoreType(ScenarioContext) == weaponType)
								{
									num = weaponRec.int_3;
									value = weaponRec.get_ReferenceWeapon(ScenarioContext);
									break;
								}
							}
						}
					}
				}
				catch (Exception projectError8)
				{
					ProjectData.SetProjectError(projectError8);
					throw new LuaError("Can't find weapon");
				}
			}
		}
		else
		{
			try
			{
				int num3 = 0;
				if (dict.ContainsKey("WEAPON_ID"))
				{
					num3 = Conversions.ToInteger(dict["WEAPON_ID"]);
				}
				if (dict.ContainsKey("WEAPON_DBID"))
				{
					num3 = Conversions.ToInteger(dict["WEAPON_DBID"]);
				}
				if (activeUnit == null)
				{
					num = num3;
					if (!ScenarioContext.Cache_Weapons.TryGetValue(num, out value))
					{
						DataRow[] array = null;
						Weapon newWeapon = Weapon.GetNewWeapon(ref ScenarioContext, num, bool_5: false);
						array = ScenarioContext.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(num));
						int num4;
						if (array == null)
						{
							num4 = -1;
						}
						else
						{
							if (array.Count() > 0)
							{
								DBFunctions.GetWeapon(ScenarioContext.DBConnection, newWeapon, num, ScenarioContext);
								value = newWeapon;
								goto IL_0769;
							}
							num4 = -1;
						}
						num = num4;
					}
					goto IL_0769;
				}
				foreach (Mount mount2 in activeUnit.Mounts)
				{
					if (mount2.Status == PlatformComponent._ComponentStatus.Destroyed)
					{
						continue;
					}
					foreach (WeaponRec mountWeapon2 in mount2.MountWeapons)
					{
						if (mountWeapon2.int_3 == num3)
						{
							num = num3;
							value = mountWeapon2.get_ReferenceWeapon(ScenarioContext);
							break;
						}
					}
					if (num != -1)
					{
						break;
					}
				}
				if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
				{
					WeaponRec[] weapons2 = ((Aircraft)activeUnit).Loadout.Weapons;
					foreach (WeaponRec weaponRec2 in weapons2)
					{
						if (weaponRec2.int_3 == num3)
						{
							num = num3;
							value = weaponRec2.get_ReferenceWeapon(ScenarioContext);
							break;
						}
					}
				}
				goto end_IL_05ae;
				IL_0769:
				if (num == -1)
				{
					throw new LuaError("No matching weapon " + Conversions.ToString(num3));
				}
				end_IL_05ae:;
			}
			catch (Exception projectError9)
			{
				ProjectData.SetProjectError(projectError9);
				throw new LuaError("Can't find weapon");
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("No doctrine set for unit.");
		}
		if (dict.ContainsKey("FULL_WRA"))
		{
			flag = true;
		}
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		if (!(!flag && wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && theTarget == null))
		{
			if (wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && theTarget != null)
			{
				GlobalVariables.BooleanObject EmitterClassificable = null;
				Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, value, ref EmitterClassificable);
				wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref value, ref theTarget, ref theTargetType, side.ObjectID);
			}
			if (!wRA_WeaponTargetType.Equals(Doctrine._WRA_WeaponTargetType.None))
			{
				if (value != null)
				{
					if (doctrine.WRA_RelevantWeapon(ref value))
					{
						int? num6 = Doctrine.WRA_WeaponQty_CurrentTargetType(doctrine, value.ParentScen, value, wRA_WeaponTargetType);
						int? num7 = Doctrine.WRA_ShooterQty_CurrentTargetType(doctrine, value.ParentScen, value, wRA_WeaponTargetType);
						float? num8 = doctrine.WRA_FiringRange_CurrentTargetType(doctrine, value.ParentScen, value.DBID, wRA_WeaponTargetType);
						float? num9 = Doctrine.WRA_SelfDefenceRange_CurrentTargetType(doctrine, value.ParentScen, value, wRA_WeaponTargetType);
						luaTable["WEAPON_DBID"] = value.DBID;
						luaTable["WEAPON_NAME"] = value.Name;
						luaTable["TARGET_TYPE"] = wRA_WeaponTargetType;
						luaTable["LEVEL"] = value2;
						LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
						if (num6.HasValue)
						{
							int? num10 = num6;
							if ((num10.HasValue ? new bool?(num10.GetValueOrDefault() == 0) : ((bool?)null)) == true)
							{
								luaTable2["QTY_SALVO"] = "DoNotUse";
							}
							else
							{
								num10 = num6;
								if (((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == -99)) != true)
								{
									luaTable2["QTY_SALVO"] = num6;
								}
								else
								{
									luaTable2["QTY_SALVO"] = "Max";
								}
							}
						}
						if (num7.HasValue)
						{
							int? num10 = num7;
							if (((!num10.HasValue) ? ((bool?)null) : new bool?(num10 == -99)) == true)
							{
								luaTable2["SHOOTER_SALVO"] = "Max";
							}
							else
							{
								luaTable2["SHOOTER_SALVO"] = num7;
							}
						}
						if (num7.HasValue & num6.HasValue)
						{
							if (!num8.HasValue)
							{
								if (Doctrine.WRA_FiringRange_GetDefaultFiringRange(value.ParentScen, value.DBID, wRA_WeaponTargetType) == Doctrine._WRA_FiringRange.NoEscapeZone)
								{
									luaTable2["FIRING_RANGE"] = "NEZ";
								}
								else
								{
									luaTable2["FIRING_RANGE"] = "Max";
								}
							}
							else
							{
								float? num11 = num8;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -99f) : ((bool?)null)) == true)
								{
									luaTable2["FIRING_RANGE"] = "Max";
								}
								else
								{
									num11 = num8;
									if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 0f) : ((bool?)null)) != true)
									{
										num11 = num8;
										if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -95f) : ((bool?)null)) != true)
										{
											num11 = num8;
											if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == -96f)) == true)
											{
												luaTable2["FIRING_RANGE"] = "50OfMax";
											}
											else
											{
												num11 = num8;
												if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -97f) : ((bool?)null)) != true)
												{
													num11 = num8;
													if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == -102f)) != true)
													{
														luaTable2["FIRING_RANGE"] = num8;
													}
													else
													{
														luaTable2["FIRING_RANGE"] = "NEZ";
													}
												}
												else
												{
													luaTable2["FIRING_RANGE"] = "75OfMax";
												}
											}
										}
										else
										{
											luaTable2["FIRING_RANGE"] = "25OfMax";
										}
									}
									else
									{
										luaTable2["FIRING_RANGE"] = "DoNotUse";
									}
								}
							}
						}
						if (num9.HasValue)
						{
							float? num11 = num9;
							if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == 0f)) != true)
							{
								num11 = num9;
								if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == -99f)) == true)
								{
									luaTable2["SELF_DEFENCE"] = "Max";
								}
								else
								{
									luaTable2["SELF_DEFENCE"] = num9;
								}
							}
							else
							{
								luaTable2["SELF_DEFENCE"] = "DoNotUse";
							}
						}
						if (luaTable2.Keys.Count > 0)
						{
							luaTable["WRA"] = luaTable2;
						}
					}
				}
				else
				{
					Dictionary<int, Weapon> dictionary = new Dictionary<int, Weapon>();
					if (activeUnit != null)
					{
						foreach (Mount mount3 in activeUnit.Mounts)
						{
							if (mount3.Status == PlatformComponent._ComponentStatus.Destroyed)
							{
								continue;
							}
							foreach (WeaponRec mountWeapon3 in mount3.MountWeapons)
							{
								value = mountWeapon3.get_ReferenceWeapon(ScenarioContext);
								if (!dictionary.ContainsKey(value.DBID))
								{
									dictionary.Add(value.DBID, value);
								}
							}
						}
						int num12;
						if (!activeUnit.IsAircraft)
						{
							num12 = 1;
						}
						else if (((Aircraft)activeUnit).Loadout == null)
						{
							num12 = 1;
						}
						else
						{
							WeaponRec[] weapons3 = ((Aircraft)activeUnit).Loadout.Weapons;
							for (int num13 = 0; num13 < weapons3.Length; num13 = checked(num13 + 1))
							{
								value = weapons3[num13].get_ReferenceWeapon(ScenarioContext);
								if (!dictionary.ContainsKey(value.DBID))
								{
									dictionary.Add(value.DBID, value);
								}
							}
							num12 = 1;
						}
						int num14 = num12;
						foreach (KeyValuePair<int, Weapon> item in dictionary)
						{
							Weapon theWeapon = item.Value;
							if (!doctrine.WRA_RelevantWeapon(ref theWeapon))
							{
								continue;
							}
							int? num15 = Doctrine.WRA_WeaponQty_CurrentTargetType(doctrine, theWeapon.ParentScen, theWeapon, wRA_WeaponTargetType);
							int? num16 = Doctrine.WRA_ShooterQty_CurrentTargetType(doctrine, theWeapon.ParentScen, theWeapon, wRA_WeaponTargetType);
							float? num17 = doctrine.WRA_FiringRange_CurrentTargetType(doctrine, theWeapon.ParentScen, theWeapon.DBID, wRA_WeaponTargetType);
							float? num18 = Doctrine.WRA_SelfDefenceRange_CurrentTargetType(doctrine, theWeapon.ParentScen, theWeapon, wRA_WeaponTargetType);
							if (!num15.HasValue && !num16.HasValue && !num17.HasValue && !num18.HasValue)
							{
								continue;
							}
							LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
							if (num15.HasValue)
							{
								int? num10 = num15;
								if (((!num10.HasValue) ? ((bool?)null) : new bool?(num10.GetValueOrDefault() == 0)) == true)
								{
									luaTable3["QTY_SALVO"] = "DoNotUse";
								}
								else
								{
									num10 = num15;
									if ((num10.HasValue ? new bool?(num10 == -99) : ((bool?)null)) != true)
									{
										luaTable3["QTY_SALVO"] = num15;
									}
									else
									{
										luaTable3["QTY_SALVO"] = "Max";
									}
								}
							}
							if (num16.HasValue)
							{
								int? num10 = num16;
								if ((num10.HasValue ? new bool?(num10 == -99) : ((bool?)null)) == true)
								{
									luaTable3["SHOOTER_SALVO"] = "Max";
								}
								else
								{
									luaTable3["SHOOTER_SALVO"] = num16;
								}
							}
							if (num16.HasValue & num15.HasValue)
							{
								if (num17.HasValue)
								{
									float? num11 = num17;
									if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == -99f)) != true)
									{
										num11 = num17;
										if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 0f) : ((bool?)null)) != true)
										{
											num11 = num17;
											if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -95f) : ((bool?)null)) == true)
											{
												luaTable3["FIRING_RANGE"] = "25OfMax";
											}
											else
											{
												num11 = num17;
												if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == -96f)) != true)
												{
													num11 = num17;
													if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -97f) : ((bool?)null)) != true)
													{
														num11 = num17;
														if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == -102f) : ((bool?)null)) == true)
														{
															luaTable3["FIRING_RANGE"] = "NEZ";
														}
														else
														{
															luaTable3["FIRING_RANGE"] = num17;
														}
													}
													else
													{
														luaTable3["FIRING_RANGE"] = "75OfMax";
													}
												}
												else
												{
													luaTable3["FIRING_RANGE"] = "50OfMax";
												}
											}
										}
										else
										{
											luaTable3["FIRING_RANGE"] = "DoNotUse";
										}
									}
									else
									{
										luaTable3["FIRING_RANGE"] = "Max";
									}
								}
								else if (Doctrine.WRA_FiringRange_GetDefaultFiringRange(theWeapon.ParentScen, theWeapon.DBID, wRA_WeaponTargetType) == Doctrine._WRA_FiringRange.NoEscapeZone)
								{
									luaTable3["FIRING_RANGE"] = "NEZ";
								}
								else
								{
									luaTable3["FIRING_RANGE"] = "Max";
								}
							}
							if (num18.HasValue)
							{
								float? num11 = num18;
								if ((num11.HasValue ? new bool?(num11.GetValueOrDefault() == 0f) : ((bool?)null)) != true)
								{
									num11 = num18;
									if (((!num11.HasValue) ? ((bool?)null) : new bool?(num11.GetValueOrDefault() == -99f)) == true)
									{
										luaTable3["SELF_DEFENCE"] = "Max";
									}
									else
									{
										luaTable3["SELF_DEFENCE"] = num18;
									}
								}
								else
								{
									luaTable3["SELF_DEFENCE"] = "DoNotUse";
								}
							}
							if (luaTable3.Keys.Count > 0)
							{
								luaTable3["WEAPON_DBID"] = theWeapon.DBID;
								luaTable3["WEAPON_NAME"] = theWeapon.Name;
								luaTable["TARGET_TYPE"] = wRA_WeaponTargetType;
								luaTable["LEVEL"] = value2;
								luaTable["WRA_" + Conversions.ToString(num14)] = luaTable3;
								num14++;
							}
						}
					}
				}
			}
			return luaTable;
		}
		return null;
	}

	public static LuaTable ScenEdit_SetDoctrineWRA(LuaTable table, LuaTable options, Scenario ScenarioContext)
	{
		_Closure$__14-0 arg = default(_Closure$__14-0);
		_Closure$__14-0 CS$<>8__locals13 = new _Closure$__14-0(arg);
		Dictionary<string, object> dict = LuaUtility.ToDictUpper(table.GetEnumerator());
		Doctrine doctrine = null;
		ActiveUnit activeUnit = null;
		Mission mission = null;
		Side side = null;
		Contact theTarget = null;
		Weapon theW = null;
		int num = -1;
		Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = Doctrine._WRA_WeaponTargetType.None;
		bool flag = false;
		string text = "SIDE";
		LuaUtility.ParseUnitDict(ref dict);
		CS$<>8__locals13.$VB$Local_NameString = null;
		string text2 = null;
		if (!dict.ContainsKey("GUID"))
		{
			if (!dict.ContainsKey("NAME") && !dict.ContainsKey("UNITNAME"))
			{
				if (dict.ContainsKey("MISSION"))
				{
					_Closure$__14-1 arg2 = default(_Closure$__14-1);
					_Closure$__14-1 CS$<>8__locals11 = new _Closure$__14-1(arg2);
					CS$<>8__locals11.$VB$Local_MissionString = Conversions.ToString(dict["MISSION"]);
					if (!dict.ContainsKey("SIDE"))
					{
						throw new LuaError("To select a mission you need to define a side.");
					}
					text2 = Conversions.ToString(dict["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dict, ScenarioContext);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("Can't find Side '" + text2 + "'");
					}
					try
					{
						mission = side.Missions.FirstOrDefault([SpecialName] (Mission s) => string.Equals(s.Name, CS$<>8__locals11.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals11.$VB$Local_MissionString, StringComparison.OrdinalIgnoreCase));
						doctrine = ((dict.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
						text = "MISSION";
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Can't find Mission '" + CS$<>8__locals11.$VB$Local_MissionString + "'");
					}
				}
				else if (dict.ContainsKey("SIDE"))
				{
					text2 = Conversions.ToString(dict["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dict, ScenarioContext);
						doctrine = side.Doctrine;
						text = "SIDE";
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Can't find Side '" + text2 + "'");
					}
					flag = true;
				}
			}
			else
			{
				if (dict.ContainsKey("SIDE"))
				{
					text2 = Conversions.ToString(dict["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dict, ScenarioContext);
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Can't find Side '" + text2 + "'");
					}
				}
				if (dict.ContainsKey("NAME"))
				{
					CS$<>8__locals13.$VB$Local_NameString = Conversions.ToString(dict["NAME"]);
				}
				if (dict.ContainsKey("UNITNAME"))
				{
					CS$<>8__locals13.$VB$Local_NameString = Conversions.ToString(dict["UNITNAME"]);
				}
				if (side == null)
				{
					foreach (ActiveUnit activeUnits_ in ScenarioContext.ActiveUnits_List)
					{
						if (string.Equals(activeUnits_.Name, CS$<>8__locals13.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(activeUnits_.ObjectID, CS$<>8__locals13.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase))
						{
							activeUnit = activeUnits_;
							side = activeUnit.get_UnitSide(SetSideOnly: false);
							doctrine = activeUnit.Doctrine;
							break;
						}
					}
				}
				else
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, CS$<>8__locals13.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, CS$<>8__locals13.$VB$Local_NameString, StringComparison.OrdinalIgnoreCase));
					doctrine = activeUnit.Doctrine;
				}
				if (activeUnit == null)
				{
					throw new LuaError("Can't find unit '" + CS$<>8__locals13.$VB$Local_NameString + "'");
				}
				text = "UNIT";
			}
		}
		else
		{
			string text3 = Conversions.ToString(dict["GUID"]);
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text3];
				side = activeUnit.get_UnitSide(SetSideOnly: false);
				doctrine = activeUnit.Doctrine;
				text = "UNIT";
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				throw new LuaError("Can't find unit '" + text3 + "'");
			}
		}
		dict["LEVEL"] = text;
		if (dict.ContainsKey("CONTACT_ID"))
		{
			string text4 = Conversions.ToString(dict["CONTACT_ID"]);
			try
			{
				Scenario scenarioContext = ScenarioContext;
				Side Side = null;
				theTarget = LuaUtility.ValidAsContact(text4, scenarioContext, ref Side);
			}
			catch (Exception projectError6)
			{
				ProjectData.SetProjectError(projectError6);
				throw new LuaError("Can't find contact '" + text4 + "'");
			}
		}
		else if (dict.ContainsKey("TARGET_TYPE"))
		{
			string text5 = Conversions.ToString(dict["TARGET_TYPE"]);
			try
			{
				if (!(Enum.TryParse<Doctrine._WRA_WeaponTargetType>(text5, ignoreCase: true, out var result) & Enum.IsDefined(typeof(Doctrine._WRA_WeaponTargetType), result)))
				{
					throw new LuaError("Can't find target type '" + text5 + "'");
				}
				wRA_WeaponTargetType = result;
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("Can't find target type '" + text5 + "'");
			}
		}
		if (dict.ContainsKey("WEAPON_ID") || dict.ContainsKey("WEAPON_DBID"))
		{
			try
			{
				int num2 = 0;
				if (dict.ContainsKey("WEAPON_ID"))
				{
					num2 = Conversions.ToInteger(dict["WEAPON_ID"]);
				}
				if (dict.ContainsKey("WEAPON_DBID"))
				{
					num2 = Conversions.ToInteger(dict["WEAPON_DBID"]);
				}
				if (Operators.CompareString(text, "UNIT", false) == 0)
				{
					foreach (Mount mount in activeUnit.Mounts)
					{
						if (mount.Status == PlatformComponent._ComponentStatus.Destroyed)
						{
							continue;
						}
						foreach (WeaponRec mountWeapon in mount.MountWeapons)
						{
							if (mountWeapon.int_3 == num2)
							{
								num = num2;
								theW = mountWeapon.get_ReferenceWeapon(ScenarioContext);
								break;
							}
						}
						if (num != -1)
						{
							break;
						}
					}
					if (activeUnit.IsAircraft && ((Aircraft)activeUnit).Loadout != null)
					{
						WeaponRec[] weapons = ((Aircraft)activeUnit).Loadout.Weapons;
						foreach (WeaponRec weaponRec in weapons)
						{
							if (weaponRec.int_3 == num2)
							{
								num = num2;
								theW = weaponRec.get_ReferenceWeapon(ScenarioContext);
								break;
							}
						}
					}
				}
				else
				{
					num = num2;
					if (theW == null)
					{
						theW = new Weapon(ScenarioContext);
						DBFunctions.GetWeapon(ScenarioContext.DBConnection, theW, num, ScenarioContext);
						if (theW.DBID == -1)
						{
							num = -1;
						}
					}
				}
				if (num == -1)
				{
					throw new LuaError("No matching weapon " + Conversions.ToString(num2));
				}
			}
			catch (Exception projectError8)
			{
				ProjectData.SetProjectError(projectError8);
				throw new LuaError("Can't find weapon");
			}
		}
		if (doctrine == null)
		{
			throw new LuaError("No doctrine set for unit.");
		}
		if (!(wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && theTarget == null))
		{
			GlobalVariables.BooleanObject EmitterClassificable = null;
			if (wRA_WeaponTargetType == Doctrine._WRA_WeaponTargetType.None && theTarget != null)
			{
				Doctrine._WRA_WeaponTargetType theTargetType = Contact.WRA_DetermineTargetType(ref theTarget, theW, ref EmitterClassificable);
				wRA_WeaponTargetType = Doctrine.WRA_ConvertWeaponTargetTypeToWRA_TargetType(ref theW, ref theTarget, ref theTargetType, side.ObjectID);
			}
			ConcurrentPagedArray<Doctrine.WRA_Weapon> concurrentPagedArray = doctrine.WRA;
			Dictionary<string, object> dictionary = LuaUtility.ToDictLower(options.GetEnumerator());
			if (dictionary.Count != 4)
			{
				throw new LuaError("Require 4 values in order: weapons per salvo, shooters per salvo, firing range, self-defence range");
			}
			string text6;
			string text7;
			string text8;
			string text9;
			try
			{
				text6 = Conversions.ToString(dictionary["1"]);
				text7 = Conversions.ToString(dictionary["2"]);
				text8 = Conversions.ToString(dictionary["3"]);
				text9 = Conversions.ToString(dictionary["4"]);
			}
			catch (Exception projectError9)
			{
				ProjectData.SetProjectError(projectError9);
				throw new LuaError("Invalid WRA table entries");
			}
			LuaSandBox.Singleton().CreateTable();
			Collection<Doctrine.WRA_FiringDoctrineEntry> collection = new Collection<Doctrine.WRA_FiringDoctrineEntry>();
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon();
			if (concurrentPagedArray == null)
			{
				concurrentPagedArray = new ConcurrentPagedArray<Doctrine.WRA_Weapon>();
			}
			if (!concurrentPagedArray.TryGetValue(num, out value))
			{
				concurrentPagedArray[num] = null;
			}
			concurrentPagedArray.TryGetValue(num, out value);
			if (value == null)
			{
				value = new Doctrine.WRA_Weapon();
				if (concurrentPagedArray.ContainsKey(num))
				{
					concurrentPagedArray[num] = value;
				}
			}
			if (theW == null)
			{
				theW = Weapon.GetNewWeapon(ref ScenarioContext, num, bool_5: false);
			}
			Doctrine.WRA_FiringDoctrineEntry value2 = null;
			value.WRA_WeaponTargets.TryGetValue((int)wRA_WeaponTargetType, ref value2);
			if (value2 == null)
			{
				value2 = value.AddTo_WRAWeaponTargets(wRA_WeaponTargetType);
			}
			int? weaponQty = default(int?);
			int? shooterQty = default(int?);
			float? firingRange = default(float?);
			float? selfDefenceRange = default(float?);
			try
			{
				if (value.WRA_WeaponTargets != null && value2 != null)
				{
					if (Operators.CompareString(text6.ToLower(), "inherit", false) == 0 && Operators.CompareString(text7.ToLower(), "inherit", false) == 0 && Operators.CompareString(text8.ToLower(), "inherit", false) == 0 && Operators.CompareString(text9.ToLower(), "inherit", false) == 0)
					{
						collection.Add(value2);
					}
					else
					{
						if (Operators.CompareString(text6.ToLower(), "inherit", false) == 0)
						{
							value2.WeaponQty = null;
						}
						else if (Operators.CompareString(text6.ToLower(), "system", false) != 0)
						{
							if (Operators.CompareString(text6.ToLower(), "max", false) != 0)
							{
								int result2;
								if (Operators.CompareString(text6.ToLower(), "none", false) == 0)
								{
									value2.WeaponQty = 0;
								}
								else if (int.TryParse(text6, out result2))
								{
									value2.WeaponQty = result2;
								}
							}
							else
							{
								value2.WeaponQty = -99;
							}
						}
						else
						{
							value2.WeaponQty = -1;
						}
						weaponQty = value2.WeaponQty;
						int result3;
						if (Operators.CompareString(text7.ToLower(), "inherit", false) == 0)
						{
							value2.ShooterQty = null;
						}
						else if (Operators.CompareString(text7.ToLower(), "system", false) == 0)
						{
							value2.ShooterQty = -1;
						}
						else if (Operators.CompareString(text7.ToLower(), "max", false) == 0)
						{
							value2.ShooterQty = -99;
						}
						else if (int.TryParse(text7, out result3))
						{
							int value3 = validatShooterPerSalvo(result3, doctrine);
							value2.ShooterQty = value3;
						}
						shooterQty = value2.ShooterQty;
						if (Operators.CompareString(text8.ToLower(), "inherit", false) == 0)
						{
							value2.FiringRange = null;
						}
						else if (Operators.CompareString(text8.ToLower(), "max", false) == 0)
						{
							value2.FiringRange = -99f;
						}
						else if (Operators.CompareString(text8.ToLower(), "25ofmax", false) == 0)
						{
							value2.FiringRange = -95f;
						}
						else if (Operators.CompareString(text8.ToLower(), "50ofmax", false) != 0)
						{
							if (Operators.CompareString(text8.ToLower(), "75ofmax", false) != 0)
							{
								if (Operators.CompareString(text8.ToLower(), "nez", false) == 0)
								{
									value2.FiringRange = -102f;
								}
								else if (Operators.CompareString(text8.ToLower(), "none", false) != 0)
								{
									if (float.TryParse(text8, out var result4))
									{
										float maxRange_NoTargetType = theW.MaxRange_NoTargetType;
										if (result4 < maxRange_NoTargetType)
										{
											float value4 = validateFiringRange(result4, doctrine);
											value2.FiringRange = value4;
										}
										else
										{
											value2.FiringRange = -99f;
										}
									}
								}
								else
								{
									value2.FiringRange = 0f;
								}
							}
							else
							{
								value2.FiringRange = -97f;
							}
						}
						else
						{
							value2.FiringRange = -96f;
						}
						firingRange = value2.FiringRange;
						if (Operators.CompareString(text9.ToLower(), "inherit", false) == 0)
						{
							value2.SelfDefenceRange = null;
						}
						else if (Operators.CompareString(text9.ToLower(), "system", false) == 0)
						{
							value2.SelfDefenceRange = -1f;
						}
						else if (Operators.CompareString(text9.ToLower(), "max", false) != 0)
						{
							if (Operators.CompareString(text9.ToLower(), "none", false) != 0)
							{
								if (float.TryParse(text9, out var result5))
								{
									float num4 = 15f;
									if (result5 < num4)
									{
										value2.SelfDefenceRange = result5;
									}
									else
									{
										value2.SelfDefenceRange = -99f;
									}
								}
							}
							else
							{
								value2.SelfDefenceRange = 0f;
							}
						}
						else
						{
							value2.SelfDefenceRange = -99f;
						}
						selfDefenceRange = value2.SelfDefenceRange;
					}
				}
			}
			catch (Exception projectError10)
			{
				ProjectData.SetProjectError(projectError10);
				throw new LuaError("Invalid WRA values");
			}
			if (collection.Count > 0)
			{
				foreach (Doctrine.WRA_FiringDoctrineEntry item in collection)
				{
					value.WRA_WeaponTargets.Remove((int)item.TargetType);
				}
			}
			if (value.WRA_WeaponTargets.Count == 0)
			{
				value.WRA_WeaponTargets = null;
			}
			if (value.WRA_WeaponTargets == null)
			{
				concurrentPagedArray.Remove(num);
			}
			if (concurrentPagedArray == null || concurrentPagedArray.Count == 0)
			{
				concurrentPagedArray = null;
			}
			doctrine.WRA = concurrentPagedArray;
			LuaTable table2 = LuaSandBox.Singleton().CreateTable();
			LuaUtility.FromDict(dict, table2);
			string text10 = "";
			Side theSide = null;
			if (activeUnit != null)
			{
				text10 = "Unit " + activeUnit.Name;
				theSide = activeUnit.get_UnitSide(SetSideOnly: false);
			}
			else if (mission == null)
			{
				if (side != null)
				{
					text10 = "Side " + side.Name;
					theSide = side;
				}
			}
			else
			{
				text10 = "Mission " + mission.Name;
				theSide = side;
			}
			text10 = text10 + " Doctrine/ROE Change: WRA for weapon #" + Conversions.ToString(num);
			if (theW != null)
			{
				text10 = text10 + " (" + theW.Name + ")";
			}
			if (theTarget != null)
			{
				text10 = text10 + " vs " + Doctrine.WRA_TargetType_String(theTarget, Contact.WRA_DetermineTargetType(ref theTarget, null, ref EmitterClassificable), EmitterClassificable.ToBoolean()) + " is now set to";
			}
			if (concurrentPagedArray == null)
			{
				text10 = (flag ? (text10 + " default for all fields.") : (text10 + " inherit for all fields."));
			}
			else
			{
				string text11 = "'inherit'";
				if (flag)
				{
					text11 = "'default'";
				}
				text10 += ": Weapons per Salvo = ";
				text10 = (weaponQty.HasValue ? (text10 + Doctrine.WRA_WeaponQty_String(weaponQty, activeUnit, theTarget, theW)) : (text10 + text11));
				text10 += ", Shooters per Salvo = ";
				text10 = ((!shooterQty.HasValue) ? (text10 + text11) : (text10 + Doctrine.WRA_ShooterQtyString(shooterQty, TargetTypeUnspecified: false)));
				text10 += ", Automatic Firing Range = ";
				text10 = (firingRange.HasValue ? (text10 + doctrine.WRA_FiringRangeString(firingRange, TargetTypeUnspecified: false)) : (text10 + text11));
				text10 += ", Self Defence Range = ";
				text10 = (selfDefenceRange.HasValue ? (text10 + doctrine.WRA_SelfDefenceRangeString(selfDefenceRange, TargetTypeUnspecified: false)) : (text10 + text11));
			}
			Geopoint_Struct theLocation = default(Geopoint_Struct);
			if (activeUnit != null)
			{
				theLocation = new Geopoint_Struct(activeUnit.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			}
			ScenarioContext.AddMessage(text10, "Doctrine/ROE changed", LoggedMessage.MessageType.const_23, 0, null, theSide, theLocation);
			return ScenEdit_GetDoctrineWRA(table, ScenarioContext);
		}
		return null;
	}

	public static float validateFiringRange(float FiringRange, Doctrine doc)
	{
		float result = 0f;
		if (FiringRange > 0f && FiringRange <= 2000f)
		{
			result = FiringRange;
		}
		return result;
	}

	public static int validatShooterPerSalvo(int ShootersPerSalvoValue, Doctrine doc)
	{
		int result = 0;
		switch (ShootersPerSalvoValue)
		{
		case 1:
			return 1;
		case 2:
		case 3:
			return 2;
		default:
			if (ShootersPerSalvoValue == 4)
			{
				return 4;
			}
			if (ShootersPerSalvoValue > 4)
			{
				return -99;
			}
			return result;
		}
	}

	public static string ScenEdit_ExportDoctrineToXML(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		Doctrine doc = null;
		Side side = null;
		string text = "SideDoctrine";
		if (!dictionary.ContainsKey("SIDE") && !dictionary.ContainsKey("GUID") && !dictionary.ContainsKey("MISSION"))
		{
			dictionary.Add("SIDE", "playerside");
		}
		if (dictionary.ContainsKey("FILENAME"))
		{
			text = Conversions.ToString(dictionary["FILENAME"]);
		}
		if (dictionary.ContainsKey("GUID"))
		{
			string text2 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doc = ScenarioContext.ActiveUnits[text2].Doctrine;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Can't find guid '" + text2 + "'");
			}
		}
		else if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
		{
			if (!dictionary.ContainsKey("MISSION"))
			{
				if (dictionary.ContainsKey("SIDE"))
				{
					string text3 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
						doc = side.Doctrine;
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Can't find Side '" + text3 + "'");
					}
				}
			}
			else
			{
				string text4 = Conversions.ToString(dictionary["MISSION"]);
				if (!dictionary.ContainsKey("SIDE"))
				{
					throw new LuaError("To select a mission you need to define a side.");
				}
				string text5 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, ScenarioContext);
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					throw new LuaError("Can't find Side '" + text5 + "'");
				}
				try
				{
					Mission mission = side.Missions.FirstOrDefault([SpecialName] (Mission s) => string.Equals(s.Name, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text4, StringComparison.OrdinalIgnoreCase));
					doc = ((!(dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike))) ? mission.Doctrine : ((Strike)mission).Doctrine_Escorts);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("Can't find Mission '" + text4 + "'");
				}
			}
		}
		else
		{
			string text6 = null;
			if (dictionary.ContainsKey("NAME"))
			{
				text6 = Conversions.ToString(dictionary["NAME"]);
			}
			else if (dictionary.ContainsKey("UNITNAME"))
			{
				text6 = Conversions.ToString(dictionary["UNITNAME"]);
			}
			if (!dictionary.ContainsKey("SIDE"))
			{
				try
				{
					doc = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text6, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					throw new LuaError("Can't find Unit '" + text6 + "'");
				}
			}
			else
			{
				string text7 = Conversions.ToString(dictionary["SIDE"]);
				try
				{
					side = LuaUtility.QuerySide(dictionary, ScenarioContext);
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					throw new LuaError("Can't find Side '" + text7 + "'");
				}
				try
				{
					doc = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text6, StringComparison.OrdinalIgnoreCase)).Doctrine;
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					throw new LuaError("Can't find Unit '" + text6 + "' on Side '" + text7 + "'");
				}
			}
		}
		if (doc == null)
		{
			throw new LuaError("Need to define a guid, or a name, or a side and name, or a side and mission, or just a side.");
		}
		int num;
		if (Directory.Exists(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults"))
		{
			num = 6;
		}
		else
		{
			Directory.CreateDirectory(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults");
			num = 6;
		}
		string[] array = new string[num];
		array[0] = GameGeneral.TopLevelWritablePath;
		array[1] = Conversions.ToString(Path.DirectorySeparatorChar);
		array[2] = "Defaults";
		array[3] = Conversions.ToString(Path.DirectorySeparatorChar);
		array[4] = text;
		array[5] = ".xml";
		FileStream fileStream = File.Create(string.Concat(array));
		using MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream();
		MemoryStream theStream = memoryStream;
		string result = ToXML_Private(ref doc, ref theStream, ref ScenarioContext);
		if (memoryStream.Position > 0L)
		{
			fileStream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Position);
		}
		fileStream.Close();
		return result;
	}

	public static string ScenEdit_ImportDoctrineFromXML(LuaTable table, Scenario ScenarioContext)
	{
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(table.GetEnumerator());
		Doctrine doc = null;
		Side side = null;
		string text = "SideDoctrine";
		if (!dictionary.ContainsKey("SIDE") && !dictionary.ContainsKey("GUID") && !dictionary.ContainsKey("MISSION"))
		{
			dictionary.Add("SIDE", "playerside");
		}
		if (dictionary.ContainsKey("FILENAME"))
		{
			text = Conversions.ToString(dictionary["FILENAME"]);
		}
		if (!dictionary.ContainsKey("GUID"))
		{
			if (!dictionary.ContainsKey("NAME") && !dictionary.ContainsKey("UNITNAME"))
			{
				if (dictionary.ContainsKey("MISSION"))
				{
					string text2 = Conversions.ToString(dictionary["MISSION"]);
					if (!dictionary.ContainsKey("SIDE"))
					{
						throw new LuaError("To select a mission you need to define a side.");
					}
					string text3 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						throw new LuaError("Can't find Side '" + text3 + "'");
					}
					try
					{
						Mission mission = side.Missions.FirstOrDefault([SpecialName] (Mission s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
						doc = ((dictionary.ContainsKey("ESCORT") & (mission.MissionClass == Mission._MissionClass.Strike)) ? ((Strike)mission).Doctrine_Escorts : mission.Doctrine);
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						throw new LuaError("Can't find Mission '" + text2 + "'");
					}
				}
				else if (dictionary.ContainsKey("SIDE"))
				{
					string text4 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
						doc = side.Doctrine;
					}
					catch (Exception projectError3)
					{
						ProjectData.SetProjectError(projectError3);
						throw new LuaError("Can't find Side '" + text4 + "'");
					}
				}
			}
			else
			{
				string text5 = null;
				if (dictionary.ContainsKey("NAME"))
				{
					text5 = Conversions.ToString(dictionary["NAME"]);
				}
				else if (dictionary.ContainsKey("UNITNAME"))
				{
					text5 = Conversions.ToString(dictionary["UNITNAME"]);
				}
				if (dictionary.ContainsKey("SIDE"))
				{
					string text6 = Conversions.ToString(dictionary["SIDE"]);
					try
					{
						side = LuaUtility.QuerySide(dictionary, ScenarioContext);
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						throw new LuaError("Can't find Side '" + text6 + "'");
					}
					try
					{
						doc = side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text5, StringComparison.OrdinalIgnoreCase)).Doctrine;
					}
					catch (Exception projectError5)
					{
						ProjectData.SetProjectError(projectError5);
						throw new LuaError("Can't find Unit '" + text5 + "' on Side '" + text6 + "'");
					}
				}
				else
				{
					try
					{
						doc = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text5, StringComparison.OrdinalIgnoreCase)).Doctrine;
					}
					catch (Exception projectError6)
					{
						ProjectData.SetProjectError(projectError6);
						throw new LuaError("Can't find Unit '" + text5 + "'");
					}
				}
			}
		}
		else
		{
			string text7 = Conversions.ToString(dictionary["GUID"]);
			try
			{
				doc = ScenarioContext.ActiveUnits[text7].Doctrine;
			}
			catch (Exception projectError7)
			{
				ProjectData.SetProjectError(projectError7);
				throw new LuaError("Can't find guid '" + text7 + "'");
			}
		}
		if (doc == null)
		{
			throw new LuaError("Need to define a guid, or a name, or a side and name, or a side and mission, or just a side.");
		}
		if (!Directory.Exists(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults"))
		{
			Directory.CreateDirectory(GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults");
		}
		object parentObject = doc.Subject;
		string doctrineFileName = GameGeneral.TopLevelWritablePath + Conversions.ToString(Path.DirectorySeparatorChar) + "Defaults" + Conversions.ToString(Path.DirectorySeparatorChar) + text + ".xml";
		return FromXML_Private(ref parentObject, ref doctrineFileName, ref doc, ref ScenarioContext);
	}

	public static string ToXML_Private(ref Doctrine doc, ref MemoryStream theStream, ref Scenario scenariocontext)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		XmlWriter theWriter = XmlWriter.Create((Stream)theStream, val);
		doc.ToXML(ref theWriter, ref scenariocontext);
		theWriter.Flush();
		string text = Misc.ConvertToString(theStream);
		XmlDocument val2 = new XmlDocument();
		val2.LoadXml(text);
		List<XmlNode> list = new List<XmlNode>();
		((XmlNode)val2).SelectSingleNode("/Doctrine");
		XmlAttribute val3 = val2.CreateAttribute("type");
		val3.Value = doc.SubjectType.Name.ToString();
		val2.DocumentElement.SetAttributeNode(val3);
		smethod_0();
		foreach (XmlNode childNode in ((XmlNode)val2).ChildNodes)
		{
			XmlNode val4 = childNode;
			string localName = val4.LocalName;
			if (Operators.CompareString(localName, "Doctrine", false) != 0)
			{
				continue;
			}
			foreach (XmlNode childNode2 in val4.ChildNodes)
			{
				XmlNode val5 = childNode2;
				if (!val5.Name.EndsWith("_Player"))
				{
					if (!dictionary_1.ContainsKey(val5.Name))
					{
						string name = val5.Name;
						if (Operators.CompareString(name, "WRA", false) != 0)
						{
							continue;
						}
						foreach (XmlNode childNode3 in val5.ChildNodes)
						{
							XmlNode val6 = childNode3;
							if (!val6.Name.StartsWith("Weapon_"))
							{
								continue;
							}
							int int_ = Conversions.ToInteger(val6.Name.Split(new char[1] { '_' })[1]);
							Weapon weapon = new Weapon(scenariocontext);
							DBFunctions.GetWeapon(scenariocontext.DBConnection, weapon, int_, scenariocontext, LoadComponents: false);
							XmlComment val7 = val2.CreateComment(weapon.Name);
							val5.InsertBefore((XmlNode)(object)val7, val6);
							foreach (XmlNode childNode4 in val6.ChildNodes)
							{
								XmlNode val8 = childNode4;
								if (val8.Name.StartsWith("WeaponTarget_"))
								{
									int_ = Conversions.ToInteger(val8.Name.Split(new char[1] { '_' })[1]);
									Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = (Doctrine._WRA_WeaponTargetType)int_;
									val7 = val2.CreateComment(wRA_WeaponTargetType.ToString());
									val6.InsertBefore((XmlNode)(object)val7, val8);
								}
							}
						}
					}
					else
					{
						string text2 = dictionary_1[val5.Name];
						string text3 = dictionary_2[val5.Name];
						if (text3.Length > 0)
						{
							XmlComment val9 = val2.CreateComment(" " + text3 + " ");
							val4.InsertBefore((XmlNode)(object)val9, val5);
						}
						XmlElement val10 = val2.CreateElement(text2);
						val10.InnerXml = val5.InnerXml;
						((XmlNode)val2.DocumentElement).InsertBefore((XmlNode)(object)val10, val5);
						list.Add(val5);
					}
				}
				else
				{
					list.Add(val5);
				}
			}
		}
		if (list.Count > 0)
		{
			XmlNode val11 = ((XmlNode)val2).SelectSingleNode("/Doctrine");
			foreach (XmlNode item in list)
			{
				val11.RemoveChild(item);
			}
		}
		theStream.Position = 0L;
		theWriter.Close();
		theWriter = XmlWriter.Create((Stream)theStream, val);
		val2.WriteTo(theWriter);
		theWriter.Flush();
		return val2.InnerXml.ToString();
	}

	public static string FromXML_Private(ref object parentObject, ref string doctrineFileName, ref Doctrine doc, ref Scenario scenariocontext)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_0910: Expected O, but got Unknown
		//IL_0997: Unknown result type (might be due to invalid IL or missing references)
		//IL_099e: Expected O, but got Unknown
		string text = "";
		List<XmlNode> list = new List<XmlNode>();
		XmlWriterSettings val = new XmlWriterSettings();
		val.Indent = true;
		using (MemoryStream memoryStream = RCMS.recyclableMemoryStreamManager_0.GetStream())
		{
			XmlWriter theWriter = XmlWriter.Create((Stream)memoryStream, val);
			doc.ToXML(ref theWriter, ref scenariocontext);
			theWriter.Flush();
			text = Misc.ConvertToString(memoryStream);
		}
		XmlDocument val2 = new XmlDocument();
		val2.LoadXml(text);
		XmlNode val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine");
		XmlAttribute val4 = val2.CreateAttribute("type");
		val4.Value = doc.SubjectType.Name.ToString();
		val2.DocumentElement.SetAttributeNode(val4);
		text = val2.InnerXml.ToString();
		XmlDocument val5 = new XmlDocument();
		val5.Load(doctrineFileName);
		text = val5.InnerXml.ToString();
		bool flag = false;
		smethod_0();
		foreach (XmlNode childNode in ((XmlNode)val5).ChildNodes)
		{
			XmlNode val6 = childNode;
			string localName = val6.LocalName;
			if (Operators.CompareString(localName, "Doctrine", false) != 0)
			{
				continue;
			}
			if (val6.Attributes != null)
			{
				foreach (XmlAttribute item in (XmlNamedNodeMap)val6.Attributes)
				{
					XmlAttribute val7 = item;
					if (Operators.CompareString(val7.Name, "inherit", false) != 0 || (Operators.CompareString(val7.Value, "yes", false) != 0 && Operators.CompareString(val7.Value, "true", false) != 0) || (object)doc.SubjectType == typeof(Side) || (object)doc.SubjectType == typeof(Waypoint))
					{
						continue;
					}
					val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine");
					int num = 0;
					while (true)
					{
						flag = (byte)num != 0;
						foreach (XmlNode childNode2 in val3.ChildNodes)
						{
							XmlNode val8 = childNode2;
							string name = val8.Name;
							if (Operators.CompareString(name, "WRA", false) != 0 && Operators.CompareString(name, "#comment", false) != 0)
							{
								val3.RemoveChild(val8);
								flag = true;
								break;
							}
						}
						if (flag)
						{
							num = 0;
							continue;
						}
						break;
					}
				}
			}
			foreach (XmlNode childNode3 in val6.ChildNodes)
			{
				XmlNode val9 = childNode3;
				string name2 = val9.Name;
				if (Operators.CompareString(name2, "WRA", false) == 0)
				{
					if (val9.Attributes != null)
					{
						foreach (XmlAttribute item2 in (XmlNamedNodeMap)val9.Attributes)
						{
							XmlAttribute val10 = item2;
							if (Operators.CompareString(val10.Name, "inherit", false) == 0 && (Operators.CompareString(val10.Value, "yes", false) == 0 || Operators.CompareString(val10.Value, "true", false) == 0) && (object)doc.SubjectType != typeof(Side) && (object)doc.SubjectType != typeof(Waypoint))
							{
								val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA");
								if (val3 != null)
								{
									val3.RemoveAll();
								}
							}
						}
					}
					if (!val9.HasChildNodes)
					{
						continue;
					}
					foreach (XmlNode childNode4 in val9.ChildNodes)
					{
						XmlNode val11 = childNode4;
						string name3 = val11.Name;
						if (Operators.CompareString(name3, "#comment", false) == 0)
						{
							continue;
						}
						if (Operators.CompareString(name3, "Weapon_All", false) == 0)
						{
							list.Add(val11);
							continue;
						}
						val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA/" + val11.LocalName);
						if (val3 == null)
						{
							val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA");
							if (val3 == null)
							{
								XmlElement val12 = val2.CreateElement("WRA");
								((XmlNode)val2.DocumentElement).AppendChild((XmlNode)(object)val12);
								val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA");
							}
							if (val3 != null)
							{
								XmlNode val13 = val2.ImportNode(val11, true);
								val3.AppendChild(val13);
							}
						}
						else if (val3.LocalName.Equals(val11.LocalName) && !val3.InnerXml.Equals(val11.InnerXml))
						{
							val3.InnerXml = val11.InnerXml;
						}
					}
				}
				else
				{
					if (Operators.CompareString(name2, "#comment", false) == 0)
					{
						continue;
					}
					string text2 = val9.Name;
					if (dictionary_1.ContainsValue(text2))
					{
						foreach (KeyValuePair<string, string> item3 in dictionary_1)
						{
							if (Operators.CompareString(item3.Value, text2, false) == 0)
							{
								text2 = item3.Key;
								break;
							}
						}
					}
					val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/" + text2);
					if (val3 == null)
					{
						val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine");
						if (val3 != null)
						{
							XmlElement val14 = val2.CreateElement(text2);
							val14.InnerXml = val9.InnerXml;
							val3.AppendChild((XmlNode)(object)val14);
						}
					}
					else if (val3.Name.Equals(text2) && !val3.InnerText.Equals(val9.InnerText))
					{
						val3.InnerText = val9.InnerText;
					}
				}
			}
		}
		if (list.Count > 0)
		{
			val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA");
			if (val3 == null)
			{
				XmlElement val15 = val2.CreateElement("WRA");
				((XmlNode)val2.DocumentElement).AppendChild((XmlNode)(object)val15);
				val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA");
			}
			dictionary_0 = new Dictionary<int, Doctrine.WRA_Weapon>();
			switch (doc.SubjectType.Name)
			{
			case "Side":
			{
				_Closure$__20-0 arg = default(_Closure$__20-0);
				_Closure$__20-0 CS$<>8__locals2 = new _Closure$__20-0(arg);
				CS$<>8__locals2.$VB$Local_mySide = (Side)parentObject;
				foreach (ActiveUnit item4 in scenariocontext.ActiveUnits_List.Where([SpecialName] (ActiveUnit AU) => AU.get_UnitSide(SetSideOnly: false) == CS$<>8__locals2.$VB$Local_mySide))
				{
					if (!item4.IsWeapon)
					{
						if (item4.IsAircraft)
						{
							WRA_RetreiveMountWeapons(item4, ref doc, ref scenariocontext);
							WRA_RetreiveLoadoutWeapons(item4, ref doc, ref scenariocontext);
						}
						else if (item4.IsShip || item4.IsSubmarine || item4.IsFacility)
						{
							WRA_RetreiveMountWeapons(item4, ref doc, ref scenariocontext);
							WRA_RetreiveMagazineWeapons(item4, ref doc, ref scenariocontext);
						}
					}
				}
				break;
			}
			case "Ship":
			case "Submarine":
			case "Aircraft":
			case "Facility":
			{
				ActiveUnit activeUnit = (ActiveUnit)parentObject;
				if (!activeUnit.IsAircraft)
				{
					if (activeUnit.IsShip || activeUnit.IsSubmarine || activeUnit.IsFacility)
					{
						WRA_RetreiveMountWeapons(activeUnit, ref doc, ref scenariocontext);
						WRA_RetreiveMagazineWeapons(activeUnit, ref doc, ref scenariocontext);
					}
				}
				else
				{
					WRA_RetreiveMountWeapons(activeUnit, ref doc, ref scenariocontext);
					WRA_RetreiveLoadoutWeapons(activeUnit, ref doc, ref scenariocontext);
				}
				break;
			}
			}
			foreach (XmlNode item5 in list)
			{
				if (Operators.CompareString(item5.Name, "Weapon_All", false) != 0)
				{
					continue;
				}
				foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item6 in dictionary_0)
				{
					int key = item6.Key;
					Weapon weapon = item6.Value.ReferenceWeapon(scenariocontext, key);
					if (Information.IsNothing((object)weapon.Doctrine.WRA))
					{
						continue;
					}
					foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item7 in weapon.Doctrine.WRA)
					{
						foreach (Doctrine.WRA_FiringDoctrineEntry value2 in item7.Value.WRA_WeaponTargets.Values)
						{
							Doctrine.WRA_FiringDoctrineEntry value = null;
							if (item6.Value.WRA_WeaponTargets.TryGetValue((int)value2.TargetType, ref value))
							{
								value.WeaponQty = -1;
								value.ShooterQty = -1;
								value.SelfDefenceRange = -1f;
							}
						}
					}
				}
				foreach (XmlNode childNode5 in item5.ChildNodes)
				{
					XmlNode val16 = childNode5;
					if (Operators.CompareString(val16.Name, "#comment", false) == 0 || !val16.Name.StartsWith("WeaponTarget_"))
					{
						continue;
					}
					Doctrine._WRA_WeaponTargetType wRA_WeaponTargetType = (Doctrine._WRA_WeaponTargetType)Conversions.ToInteger(val16.Name.Split(new char[1] { '_' })[1]);
					int? weaponQty = null;
					int? shooterQty = null;
					int? num2 = null;
					int? num3 = null;
					foreach (XmlNode childNode6 in val16.ChildNodes)
					{
						XmlNode val17 = childNode6;
						switch (val17.Name)
						{
						case "WeaponQty":
							weaponQty = Conversions.ToInteger(val17.InnerText);
							break;
						case "ShooterQty":
							shooterQty = Conversions.ToInteger(val17.InnerText);
							break;
						case "SelfDefenceRange":
							num2 = Conversions.ToInteger(val17.InnerText);
							break;
						case "FiringRange":
							num3 = Conversions.ToInteger(val17.InnerText);
							break;
						}
					}
					foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item8 in dictionary_0)
					{
						int key2 = item8.Key;
						Weapon weapon2 = item8.Value.ReferenceWeapon(scenariocontext, key2);
						string text3 = "/Doctrine/WRA/Weapon_" + key2;
						XmlNode val18 = ((XmlNode)val2).SelectSingleNode(text3);
						if (Information.IsNothing((object)weapon2.Doctrine.WRA))
						{
							continue;
						}
						foreach (KeyValuePair<int, Doctrine.WRA_Weapon> item9 in weapon2.Doctrine.WRA)
						{
							_ = item9;
							foreach (Doctrine.WRA_FiringDoctrineEntry value3 in item8.Value.WRA_WeaponTargets.Values)
							{
								if (value3.TargetType != wRA_WeaponTargetType)
								{
									continue;
								}
								if (weaponQty.HasValue)
								{
									value3.WeaponQty = weaponQty;
								}
								if (shooterQty.HasValue)
								{
									value3.ShooterQty = shooterQty;
								}
								if (num2.HasValue)
								{
									value3.SelfDefenceRange = num2;
								}
								if (num3.HasValue)
								{
									value3.FiringRange = num3;
								}
								StringBuilder stringBuilder = new StringBuilder();
								int num4 = (int)wRA_WeaponTargetType;
								XmlNode val19 = ((XmlNode)val2).SelectSingleNode(text3 + "/WeaponTarget_" + num4);
								if (val19 != null)
								{
									if (weaponQty.HasValue && val19.SelectSingleNode("WeaponQty") != null)
									{
										val19.SelectSingleNode("WeaponQty").InnerText = weaponQty.ToString();
									}
									else if (weaponQty.HasValue)
									{
										stringBuilder.Append("<WeaponQty>" + weaponQty + "</WeaponQty>");
									}
									if (shooterQty.HasValue && val19.SelectSingleNode("ShooterQty") != null)
									{
										val19.SelectSingleNode("WeaponQty").InnerText = shooterQty.ToString();
									}
									else if (shooterQty.HasValue)
									{
										stringBuilder.Append("<ShooterQty>" + shooterQty + "</ShooterQty>");
									}
									if (num2.HasValue && val19.SelectSingleNode("SelfDefenceRange") != null)
									{
										val19.SelectSingleNode("SelfDefenceRange").InnerText = num2.ToString();
									}
									else if (num2.HasValue)
									{
										stringBuilder.Append("<SelfDefenceRange>" + num2 + "</SelfDefenceRange>");
									}
									if (num3.HasValue && val19.SelectSingleNode("FiringRange") != null)
									{
										val19.SelectSingleNode("FiringRange").InnerText = num3.ToString();
									}
									else if (num3.HasValue)
									{
										stringBuilder.Append("<FiringRange>" + num3 + "</FiringRange>");
									}
									if (stringBuilder.Length > 0)
									{
										XmlDocumentFragment val20 = val2.CreateDocumentFragment();
										val20.InnerXml = stringBuilder.ToString();
										val19.AppendChild((XmlNode)(object)val20);
									}
								}
								else
								{
									num4 = (int)wRA_WeaponTargetType;
									stringBuilder.Append("<WeaponTarget_" + num4 + ">");
									if (weaponQty.HasValue)
									{
										stringBuilder.Append("<WeaponQty>" + weaponQty + "</WeaponQty>");
									}
									if (shooterQty.HasValue)
									{
										stringBuilder.Append("<ShooterQty>" + shooterQty + "</ShooterQty>");
									}
									if (num2.HasValue)
									{
										stringBuilder.Append("<SelfDefenceRange>" + num2 + "</SelfDefenceRange>");
									}
									if (num3.HasValue)
									{
										stringBuilder.Append("<FiringRange>" + num3 + "</FiringRange>");
									}
									num4 = (int)wRA_WeaponTargetType;
									stringBuilder.Append("</WeaponTarget_" + num4 + ">");
									if (val18 == null)
									{
										XmlElement val21 = val2.CreateElement("Weapon_" + key2);
										val3.AppendChild((XmlNode)(object)val21);
										val18 = ((XmlNode)val2).SelectSingleNode("/Doctrine/WRA/Weapon_" + key2);
									}
									XmlDocumentFragment val22 = val2.CreateDocumentFragment();
									val22.InnerXml = stringBuilder.ToString();
									val18.AppendChild((XmlNode)(object)val22);
								}
								break;
							}
						}
					}
				}
			}
		}
		val3 = ((XmlNode)val2).SelectSingleNode("/Doctrine");
		switch (doc.SubjectType.Name)
		{
		case "Facility":
		{
			Facility facility = (Facility)doc.Subject;
			facility.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, facility);
			break;
		}
		default:
			if (doc.Subject.IsMission)
			{
				Mission mission = (Mission)doc.Subject;
				mission.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, mission);
			}
			break;
		case "Group":
		{
			Group obj = (Group)doc.Subject;
			obj.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, obj);
			break;
		}
		case "Aircraft":
		{
			Aircraft aircraft = (Aircraft)doc.Subject;
			aircraft.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, aircraft);
			break;
		}
		case "Submarine":
		{
			Submarine submarine = (Submarine)doc.Subject;
			submarine.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, submarine);
			break;
		}
		case "Ship":
		{
			Ship ship = (Ship)doc.Subject;
			ship.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, ship);
			break;
		}
		case "Side":
		{
			Side side = (Side)doc.Subject;
			side.Doctrine = Doctrine.FromXML(scenariocontext, ref val3, side);
			break;
		}
		}
		return text;
	}

	public static void WRA_RetreiveLoadoutWeapons(ActiveUnit theUnit, ref Doctrine theDoc, ref Scenario CurrentScenario)
	{
		if (Information.IsNothing((object)((Aircraft)theUnit).Loadout))
		{
			return;
		}
		WeaponRec[] weapons = ((Aircraft)theUnit).Loadout.Weapons;
		for (int i = 0; i < weapons.Length; i = checked(i + 1))
		{
			Weapon theWeapon = weapons[i].get_ReferenceWeapon(CurrentScenario);
			if (theDoc.WRA_RelevantWeapon(ref theWeapon))
			{
				WRA_AddWeapon(ref theWeapon, ref CurrentScenario);
			}
		}
	}

	public static void WRA_RetreiveMagazineWeapons(ActiveUnit theUnit, ref Doctrine theDoc, ref Scenario CurrentScenario)
	{
		IEnumerable<Magazine> enumerable = theUnit.SharedMagazines.OrderBy([SpecialName] (Magazine theM) => theM.Name);
		foreach (Magazine item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec weapon in item.Weapons)
			{
				Weapon theWeapon = weapon.get_ReferenceWeapon(CurrentScenario);
				if (theDoc.WRA_RelevantWeapon(ref theWeapon))
				{
					WRA_AddWeapon(ref theWeapon, ref CurrentScenario);
				}
			}
		}
	}

	public static void WRA_RetreiveMountWeapons(ActiveUnit theUnit, ref Doctrine theDoc, ref Scenario CurrentScenario)
	{
		IEnumerable<Mount> enumerable = theUnit.Mounts.OrderBy([SpecialName] (Mount theM) => theM.Name);
		foreach (Mount item in enumerable)
		{
			if (item.Status != PlatformComponent._ComponentStatus.Operational)
			{
				continue;
			}
			foreach (WeaponRec mountWeapon in item.MountWeapons)
			{
				Weapon theWeapon = mountWeapon.get_ReferenceWeapon(CurrentScenario);
				if (theDoc.WRA_RelevantWeapon(ref theWeapon))
				{
					WRA_AddWeapon(ref theWeapon, ref CurrentScenario);
				}
			}
		}
	}

	public static void WRA_AddWeapon(ref Weapon theWeapon, ref Scenario CurrentScenario)
	{
		if (!dictionary_0.ContainsKey(theWeapon.DBID))
		{
			Doctrine.WRA_Weapon value = new Doctrine.WRA_Weapon(ref theWeapon, CurrentScenario);
			dictionary_0.Add(theWeapon.DBID, value);
		}
	}
}
