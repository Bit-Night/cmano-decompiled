using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public sealed class LuaWrapper_Side
{
	[CompilerGenerated]
	internal sealed class _Closure$__21-0
	{
		public object $VB$Local_o;

		public _Closure$__21-0(_Closure$__21-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			return Operators.CompareString(s.Name, $VB$Local_o.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__2(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__3(ReferencePoint s)
		{
			return string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__4(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__5(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__6(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		[SpecialName]
		internal bool _Lambda$__7(ReferencePoint s)
		{
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__21-0()
		{
			Class72.smethod_20();
		}
	}

	private Side side_0;

	private Scenario scenario_0;

	public object fields
	{
		get
		{
			Type type = GetType();
			int num = 0;
			PropertyInfo[] properties = type.GetProperties();
			MethodInfo[] methods = type.GetMethods();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				if (propertyInfo.Name.StartsWith("__") || propertyInfo.Name.StartsWith("fields"))
				{
					continue;
				}
				string text = "";
				bool flag = false;
				if (propertyInfo.MemberType == MemberTypes.Method)
				{
					text = ":";
				}
				else if (propertyInfo.MemberType == MemberTypes.Property)
				{
					text = ".";
				}
				MethodInfo[] array2 = methods;
				foreach (MethodInfo obj in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj.Name, text2, false) == 0)
					{
						flag = true;
					}
				}
				num++;
				dictionary.Add("property_" + num, text + propertyInfo.Name + " , " + propertyInfo.PropertyType.Name + " , " + flag + " , " + propertyInfo.CanRead);
			}
			num = 0;
			MethodInfo[] array3 = methods;
			foreach (MethodInfo methodInfo in array3)
			{
				if (!methodInfo.Name.StartsWith("get_") && !methodInfo.Name.StartsWith("set_") && !methodInfo.Name.StartsWith("ToString") && !methodInfo.IsHideBySig)
				{
					string text3 = "";
					if (methodInfo.MemberType == MemberTypes.Method)
					{
						text3 = ":";
					}
					else if (methodInfo.MemberType == MemberTypes.Property)
					{
						text3 = ".";
					}
					num++;
					dictionary.Add("method_" + num, text3 + methodInfo.Name + " , " + methodInfo.ReturnType.ToString());
				}
			}
			if (dictionary.Count == 0)
			{
				return null;
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public object __obj => side_0;

	[DoNotPrune]
	public string guid => side_0.ObjectID;

	[DoNotPrune]
	public string ObjectID => guid;

	[DoNotPrune]
	public string name
	{
		get
		{
			return side_0.Name;
		}
		set
		{
			side_0.Name = value;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (side_0.Doctrine == null)
			{
				return null;
			}
			return new LuaWrapper_Doctrine(side_0.Doctrine, scenario_0);
		}
	}

	[DoNotPrune]
	public LuaTable enablers
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["GNSS_BeiDou"] = side_0.Enablers.GNSS_BeiDou;
			luaTable["GNSS_GPS"] = side_0.Enablers.GNSS_GPS;
			luaTable["GNSS_GLONASS"] = side_0.Enablers.GNSS_GLONASS;
			luaTable["GNSS_NavIC"] = side_0.Enablers.GNSS_NavIC;
			return luaTable;
		}
		set
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(value.GetEnumerator());
			if (dictionary.ContainsKey("GNSS_BEIDOU") && bool.TryParse(Conversions.ToString(dictionary["GNSS_BEIDOU"]), out var result))
			{
				side_0.Enablers.GNSS_BeiDou = result;
			}
			if (dictionary.ContainsKey("GNSS_GPS") && bool.TryParse(Conversions.ToString(dictionary["GNSS_GPS"]), out var result2))
			{
				side_0.Enablers.GNSS_GPS = result2;
			}
			if (dictionary.ContainsKey("GNSS_GLONASS") && bool.TryParse(Conversions.ToString(dictionary["GNSS_GLONASS"]), out var result3))
			{
				side_0.Enablers.GNSS_GLONASS = result3;
			}
			if (dictionary.ContainsKey("GNSS_NAVIC") && bool.TryParse(Conversions.ToString(dictionary["GNSS_NAVIC"]), out var result4))
			{
				side_0.Enablers.GNSS_NavIC = result4;
			}
		}
	}

	[DoNotPrune]
	public LuaTable units
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ActiveUnit unit in side_0.Units)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				if (unit != null && !unit.IsMorituri)
				{
					luaTable2["guid"] = unit.ObjectID;
					luaTable2["name"] = unit.Name;
					luaTable[num] = luaTable2;
					num++;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable contacts
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (Contact contacts_ in side_0.Contacts_List)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = contacts_.ObjectID;
				luaTable2["name"] = contacts_.Name;
				luaTable[num] = luaTable2;
				num++;
			}
			foreach (string key in side_0.NewContactsQueue.Keys)
			{
				if (!side_0.Contacts_List.Contains(side_0.NewContactsQueue[key]))
				{
					LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
					luaTable3["guid"] = side_0.NewContactsQueue[key].ObjectID;
					luaTable3["name"] = side_0.NewContactsQueue[key].Name;
					luaTable[num] = luaTable3;
					num++;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable exclusionzones
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ExclusionZone exclusionZone in side_0.ExclusionZones)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = exclusionZone.ObjectID;
				luaTable2["name"] = exclusionZone.Name;
				luaTable2["description"] = exclusionZone.Description;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable nonavzones
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (NoNavZone noNavZone in side_0.NoNavZones)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = noNavZone.ObjectID;
				luaTable2["name"] = noNavZone.Name;
				luaTable2["description"] = noNavZone.Description;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable standardzones
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (Zone standardZone in side_0.StandardZones)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = standardZone.ObjectID;
				luaTable2["name"] = standardZone.Name;
				luaTable2["description"] = standardZone.Description;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable customenvironmentzones
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			CustomEnvironmentZone[] customEnvironmentZones = side_0.CustomEnvironmentZones;
			foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = customEnvironmentZone.ObjectID;
				luaTable2["name"] = customEnvironmentZone.Name;
				luaTable2["description"] = customEnvironmentZone.Description;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable rps
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ReferencePoint refPoint in side_0.RefPoints)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = refPoint.ObjectID;
				luaTable2["name"] = refPoint.Name;
				luaTable2["longitude"] = refPoint.Longitude;
				luaTable2["latitude"] = refPoint.Latitude;
				luaTable2["side"] = side_0.Name;
				luaTable2["highlighted"] = refPoint.IsHighlighted;
				luaTable2["locked"] = refPoint.IsLocked;
				if (!Information.IsNothing((object)refPoint.IsRelativeTo))
				{
					luaTable2["bearingtype"] = refPoint.BearingType;
					luaTable2["relativeto"] = refPoint.IsRelativeTo.ObjectID;
				}
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public object collectiveResponsibility
	{
		get
		{
			return side_0.AssignsCollectiveResponsibility;
		}
		set
		{
			bool? flag = null;
			flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
			if (flag.HasValue)
			{
				side_0.AssignsCollectiveResponsibility = flag.Value;
			}
		}
	}

	[DoNotPrune]
	public object canAutoTrackCivillians
	{
		get
		{
			return side_0.CanAutoTrackCivs;
		}
		set
		{
			bool? flag = null;
			flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
			if (flag.HasValue)
			{
				side_0.CanAutoTrackCivs = flag.Value;
			}
		}
	}

	[DoNotPrune]
	public object computerControlledOnly
	{
		get
		{
			return side_0.IsAIOnly;
		}
		set
		{
			bool? flag = null;
			flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
			if (flag.HasValue)
			{
				side_0.IsAIOnly = flag.Value;
			}
		}
	}

	[DoNotPrune]
	public Side.AwarenessLevel_Enum awareness
	{
		get
		{
			return side_0.AwarenessLevel;
		}
		set
		{
			side_0.AwarenessLevel = value;
		}
	}

	[DoNotPrune]
	public GlobalVariables.ProficiencyLevel proficiency
	{
		get
		{
			return side_0.Proficiency;
		}
		set
		{
			side_0.Proficiency = value;
		}
	}

	[DoNotPrune]
	public bool hasmines
	{
		get
		{
			foreach (UnguidedWeapon value in scenario_0.UnguidedWeapons.Values)
			{
				if (value.IsMine && value.get_UnitSide(SetSideOnly: false) == side_0)
				{
					return true;
				}
			}
			return false;
		}
	}

	[DoNotPrune]
	public LuaTable missions
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Mission mission in side_0.Missions)
			{
				luaTable[luaTable.Keys.Count + 1] = new LuaWrapper_Mission(mission, scenario_0);
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaWrapper_Operation Operation => new LuaWrapper_Operation(scenario_0, side_0.Operation, side_0);

	[DoNotPrune]
	public LuaTable Chalks
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Chalk chalk in side_0.Chalks)
			{
				luaTable[luaTable.Keys.Count + 1] = new LuaWrapper_Serial(scenario_0, chalk);
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable losses
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (KeyValuePair<string, HashSet<string>> loss in side_0.AAR.Losses)
			{
				if (loss.Value.Count != 0)
				{
					string[] array = loss.Key.ToString().Split(new char[1] { '_' });
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["type"] = array[0].ToString();
					luaTable2["dbid"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(array[0], "Custom", false) == 0, (object)0, (object)array[1]));
					luaTable2["name"] = Side._AAR.GetLossUnitName(scenario_0, loss);
					luaTable2["count"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(array[0], "Custom", false) == 0, (object)loss.Value.ElementAtOrDefault(0), (object)loss.Value.Count));
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable expenditures
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (KeyValuePair<int, int> expenditure in side_0.AAR.Expenditures)
			{
				scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(expenditure.Key));
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["type"] = "Weapon";
				luaTable2["dbid"] = expenditure.Key;
				luaTable2["name"] = side_0.AAR.GetWeaponItemName(scenario_0, expenditure);
				luaTable2["count"] = expenditure.Value;
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	public LuaWrapper_Side(Side theSide, Scenario theScen)
	{
		side_0 = theSide;
		scenario_0 = theScen;
	}

	[DoNotPrune]
	public LuaTable unitsInArea(LuaTable criteria)
	{
		UnitFilterObject unitFilterObject = null;
		List<ReferencePoint> list = new List<ReferencePoint>();
		Dictionary<string, object> dictionary_ = LuaUtility.ToDictUpper(criteria.GetEnumerator());
		_Closure$__21-0 closure$__21- = default(_Closure$__21-0);
		foreach (string key in dictionary_.Keys)
		{
			if (Operators.CompareString(key, "TARGETFILTER", false) != 0)
			{
				if (Operators.CompareString(key, "AREA", false) != 0)
				{
					continue;
				}
				list.Clear();
				List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary_["AREA"]).GetEnumerator());
				using List<object>.Enumerator enumerator2 = list2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					closure$__21- = new _Closure$__21-0(closure$__21-);
					closure$__21-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator2.Current);
					ReferencePoint referencePoint = null;
					if (Information.IsNothing((object)side_0.RefPoints.FirstOrDefault(closure$__21-._Lambda$__0)))
					{
						if (!Information.IsNothing((object)side_0.RefPoints.FirstOrDefault(closure$__21-._Lambda$__2)))
						{
							referencePoint = side_0.RefPoints.First(closure$__21-._Lambda$__3);
						}
						else if (!Information.IsNothing((object)side_0.RefPoints.FirstOrDefault(closure$__21-._Lambda$__4)))
						{
							referencePoint = side_0.RefPoints.First(closure$__21-._Lambda$__5);
						}
						else if (!Information.IsNothing((object)side_0.RefPoints.FirstOrDefault(closure$__21-._Lambda$__6)))
						{
							referencePoint = side_0.RefPoints.First(closure$__21-._Lambda$__7);
						}
					}
					else
					{
						referencePoint = side_0.RefPoints.First(closure$__21-._Lambda$__1);
					}
					if (!Information.IsNothing((object)referencePoint))
					{
						list.Add(referencePoint);
					}
				}
			}
			else
			{
				unitFilterObject = method_0(ref dictionary_, scenario_0);
				unitFilterObject.TargetSide = side_0.ObjectID;
			}
		}
		if (list.Count != 0)
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit unit in side_0.Units)
			{
				if (unit != null && !unit.IsMorituri && (unitFilterObject == null || unitFilterObject.MatchesThisUnit(unit)) && ((Module_Unit.Unit)unit).get_IsInsideThisArea(list, scenario_0, UseCache: false))
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["guid"] = unit.ObjectID;
					luaTable2["name"] = unit.Name;
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
		return null;
	}

	[DoNotPrune]
	public LuaTable unitsBy(string theUnitType, int? theCategory = 0, int? theSubType = 0)
	{
		GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
		if (theUnitType != null)
		{
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
			int num = 0;
			while (num < array.Length)
			{
				byte b = array[num];
				if (!string.Equals(theUnitType, b.ToString(), StringComparison.OrdinalIgnoreCase))
				{
					GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
					if (!string.Equals(theUnitType, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						num = checked(num + 1);
						continue;
					}
				}
				activeUnitType = (GlobalVariables.ActiveUnitType)b;
				break;
			}
			if (activeUnitType != GlobalVariables.ActiveUnitType.None)
			{
				if (!theCategory.HasValue)
				{
					theCategory = 0;
				}
				if (!theSubType.HasValue)
				{
					theSubType = 0;
				}
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				int num2 = 1;
				List<ActiveUnit> list = new List<ActiveUnit>(side_0.Units);
				foreach (ActiveUnit item in list)
				{
					if (item == null || item.IsMorituri)
					{
						continue;
					}
					byte b2 = (byte)activeUnitType;
					byte? b3 = (byte?)item?.UnitType;
					if (((!b3.HasValue) ? ((bool?)null) : new bool?(b2 == b3.GetValueOrDefault())) != true)
					{
						continue;
					}
					int? num3 = theCategory;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : ((bool?)null)) != true)
					{
						num3 = theSubType;
						if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : ((bool?)null)) != true)
						{
							goto IL_02ed;
						}
					}
					num3 = theCategory;
					if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() != 0) : ((bool?)null)) == true)
					{
						switch (item.UnitType)
						{
						case GlobalVariables.ActiveUnitType.Aircraft:
							if ((int)((Aircraft)item).Category != theCategory.Value)
							{
								continue;
							}
							break;
						case GlobalVariables.ActiveUnitType.Ship:
							if (((Ship)item).Category != (Ship._ShipCategory)theCategory.Value)
							{
								continue;
							}
							break;
						case GlobalVariables.ActiveUnitType.Submarine:
							if (((Submarine)item).Category != (Submarine._SubmarineCategory)theCategory.Value)
							{
								continue;
							}
							break;
						case GlobalVariables.ActiveUnitType.Facility:
							if (!item.IsFixedFacility)
							{
								if (((Facility)item).MobileUnitCategory() != (IMobileGroundUnit._MobileUnitCategory)theCategory.Value)
								{
									continue;
								}
							}
							else if ((int)((Facility)item).Category != theCategory.Value)
							{
								continue;
							}
							break;
						case GlobalVariables.ActiveUnitType.Satellite:
							if (((Satellite)item).Category != (Satellite._SatelliteCategory)theCategory.Value)
							{
								continue;
							}
							break;
						}
					}
					num3 = theSubType;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() != 0)) == true && item.SubType != theSubType.Value)
					{
						continue;
					}
					goto IL_02ed;
					IL_02ed:
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["guid"] = item.ObjectID;
					luaTable2["name"] = item.Name;
					luaTable[num2] = luaTable2;
					num2++;
				}
				if (luaTable.Keys.Count > 0)
				{
					return luaTable;
				}
				return null;
			}
			return null;
		}
		return units;
	}

	[DoNotPrune]
	public LuaTable contactsBy(string theUnitType)
	{
		GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
		if (theUnitType != null)
		{
			byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
			int num = 0;
			while (num < array.Length)
			{
				byte b = array[num];
				if (!string.Equals(theUnitType, b.ToString(), StringComparison.OrdinalIgnoreCase))
				{
					GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
					if (!string.Equals(theUnitType, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						num = checked(num + 1);
						continue;
					}
				}
				activeUnitType = (GlobalVariables.ActiveUnitType)b;
				break;
			}
			if (activeUnitType == GlobalVariables.ActiveUnitType.None)
			{
				return null;
			}
		}
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		int num2 = 1;
		foreach (Contact contacts_ in side_0.Contacts_List)
		{
			if (activeUnitType == GlobalVariables.ActiveUnitType.None || activeUnitType == contacts_.ActualUnit.UnitType)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["guid"] = contacts_.ObjectID;
				luaTable2["name"] = contacts_.Name;
				luaTable[num2] = luaTable2;
				num2++;
			}
		}
		foreach (string key in side_0.NewContactsQueue.Keys)
		{
			if (!side_0.Contacts_List.Contains(side_0.NewContactsQueue[key]) && (activeUnitType == GlobalVariables.ActiveUnitType.None || activeUnitType == side_0.NewContactsQueue[key].ActualUnit.UnitType))
			{
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				luaTable3["guid"] = side_0.NewContactsQueue[key].ObjectID;
				luaTable3["name"] = side_0.NewContactsQueue[key].Name;
				luaTable[num2] = luaTable3;
				num2++;
			}
		}
		if (luaTable.Keys.Count > 0)
		{
			return luaTable;
		}
		return null;
	}

	[DoNotPrune]
	public LuaWrapper_Zone getexclusionzone(string ZoneIDorNameOrDescription)
	{
		Zone zone = null;
		foreach (ExclusionZone exclusionZone in side_0.ExclusionZones)
		{
			if (Operators.CompareString(exclusionZone.ObjectID, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(exclusionZone.Name, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(exclusionZone.Description, ZoneIDorNameOrDescription, false) == 0)
			{
				zone = exclusionZone;
				break;
			}
		}
		if (Information.IsNothing((object)zone))
		{
			throw new LuaError("No exclusion zone exists with this name or ID.");
		}
		return new LuaWrapper_Zone(zone, scenario_0, side_0);
	}

	[DoNotPrune]
	public LuaWrapper_Zone getnonavzone(string ZoneIDorNameOrDescription)
	{
		Zone zone = null;
		foreach (NoNavZone noNavZone in side_0.NoNavZones)
		{
			if (Operators.CompareString(noNavZone.ObjectID, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(noNavZone.Name, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(noNavZone.Description, ZoneIDorNameOrDescription, false) == 0)
			{
				zone = noNavZone;
				break;
			}
		}
		if (Information.IsNothing((object)zone))
		{
			throw new LuaError("No no-navigation zone exists with this name or ID.");
		}
		return new LuaWrapper_Zone(zone, scenario_0, side_0);
	}

	[DoNotPrune]
	public LuaWrapper_Zone getstandardzone(string ZoneIDorNameOrDescription)
	{
		Zone zone = null;
		foreach (Zone standardZone in side_0.StandardZones)
		{
			if (Operators.CompareString(standardZone.ObjectID, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(standardZone.Name, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(standardZone.Description, ZoneIDorNameOrDescription, false) == 0)
			{
				zone = standardZone;
				break;
			}
		}
		if (Information.IsNothing((object)zone))
		{
			throw new LuaError("No no-navigation zone exists with this name or ID.");
		}
		return new LuaWrapper_Zone(zone, scenario_0, side_0);
	}

	[DoNotPrune]
	public LuaWrapper_Zone getcustomenvironmentzone(string ZoneIDorNameOrDescription)
	{
		if (side_0 != scenario_0.GetNatureSide())
		{
			throw new LuaError("Only the scenario-designated 'nature' side may have custom environment zones.");
		}
		Zone zone = null;
		CustomEnvironmentZone[] customEnvironmentZones = side_0.CustomEnvironmentZones;
		foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
		{
			if (Operators.CompareString(customEnvironmentZone.ObjectID, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(customEnvironmentZone.Name, ZoneIDorNameOrDescription, false) == 0 || Operators.CompareString(customEnvironmentZone.Description, ZoneIDorNameOrDescription, false) == 0)
			{
				zone = customEnvironmentZone;
				break;
			}
		}
		if (Information.IsNothing((object)zone))
		{
			throw new LuaError("No custom environment zone exists with this name or ID.");
		}
		return new LuaWrapper_Zone(zone, scenario_0, side_0);
	}

	[DoNotPrune]
	public LuaWrapper_Contact AddOrUpdateContact(LuaTable ContactData)
	{
		return LuaSide.AddOrUpdateContact(side_0, scenario_0, ContactData);
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("side {\r\n guid = '" + guid + "', \r\n name = '" + name + "', \r\n units = '" + units.ToString() + "', \r\n contacts = '" + contacts.ToString() + "', \r\n Chalks = '" + Chalks.ToString() + "', \r\n", "}");
	}

	private UnitFilterObject method_0(ref Dictionary<string, object> dictionary_0, Scenario scenario_1)
	{
		UnitFilterObject unitFilterObject = new UnitFilterObject();
		Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)dictionary_0["TARGETFILTER"]).GetEnumerator());
		foreach (string key in dictionary.Keys)
		{
			string text = dictionary[key].ToString();
			switch (key.ToUpperInvariant())
			{
			case "TARGETTYPE":
			{
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(text, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(text, activeUnitType.ToString(), StringComparison.OrdinalIgnoreCase))
						{
							num = checked(num + 1);
							continue;
						}
					}
					unitFilterObject.TargetType = (GlobalVariables.ActiveUnitType)b;
					break;
				}
				if (unitFilterObject.TargetType == GlobalVariables.ActiveUnitType.None)
				{
					throw new LuaError("Error in TargetFilter.Type!");
				}
				break;
			}
			case "TARGETSUBTYPE":
				unitFilterObject.TargetSubType = Conversions.ToInteger(text);
				break;
			case "SPECIFICUNITCLASS":
				unitFilterObject.SpecificUnitClass = Conversions.ToInteger(text);
				break;
			}
		}
		return unitFilterObject;
	}

	static LuaWrapper_Side()
	{
		Class72.smethod_20();
	}
}
