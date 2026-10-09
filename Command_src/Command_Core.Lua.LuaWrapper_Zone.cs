using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotPruneType]
[DoNotPrune]
[DoNotObfuscateType]
public sealed class LuaWrapper_Zone
{
	[CompilerGenerated]
	internal sealed class _Closure$__31-0
	{
		public object $VB$Local_o;

		public _Closure$__31-0(_Closure$__31-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_o = arg0.$VB$Local_o;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ReferencePoint s)
		{
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda$__1(ReferencePoint s)
		{
			if (string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
		}

		static _Closure$__31-0()
		{
			Class72.smethod_20();
		}
	}

	private Zone zone_0;

	private Scenario scenario_0;

	private Side side_0;

	public object fields
	{
		get
		{
			Type obj = GetType();
			int num = 0;
			PropertyInfo[] properties = obj.GetProperties();
			MethodInfo[] methods = obj.GetMethods();
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
				foreach (MethodInfo obj2 in array2)
				{
					string text2 = "set_" + propertyInfo.Name;
					if (Operators.CompareString(obj2.Name, text2, false) == 0)
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
			if (dictionary.Count != 0)
			{
				LuaUtility.FromDict(dictionary, luaTable);
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object __obj => zone_0;

	[DoNotPrune]
	public string type => zone_0.Type.ToString("d");

	[DoNotPrune]
	public string guid => zone_0.ObjectID;

	[DoNotPrune]
	public string objectid => guid;

	[DoNotPrune]
	public string name
	{
		get
		{
			return zone_0.Name;
		}
		set
		{
			zone_0.Name = value;
		}
	}

	[DoNotPrune]
	public string description
	{
		get
		{
			return zone_0.Description;
		}
		set
		{
			zone_0.Description = value;
		}
	}

	[DoNotPrune]
	public object isactive
	{
		get
		{
			return zone_0.IsActive;
		}
		set
		{
			try
			{
				zone_0.IsActive = Conversions.ToBoolean(value);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public object islocked
	{
		get
		{
			if (!(zone_0.GetType() == typeof(NoNavZone)) && !(zone_0.GetType() == typeof(Zone)))
			{
				return null;
			}
			return zone_0.IsLocked;
		}
		set
		{
			try
			{
				if (zone_0.GetType() == typeof(NoNavZone) || zone_0.GetType() == typeof(Zone))
				{
					zone_0.IsLocked = Conversions.ToBoolean(value);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public object markas
	{
		get
		{
			if (zone_0.GetType() == typeof(ExclusionZone))
			{
				return ((ExclusionZone)zone_0).MarkViolatorAs.ToString();
			}
			return null;
		}
		set
		{
			Misc.PostureStance markViolatorAs = Misc.PostureStance.Neutral;
			int num2;
			int num;
			switch (Conversions.ToString(value).ToLower())
			{
			case "unfriendly":
				num2 = 2;
				goto IL_00ce;
			case "2":
				num2 = 2;
				goto IL_00ce;
			case "unknown":
			case "4":
				markViolatorAs = Misc.PostureStance.Unknown;
				break;
			case "hostile":
				num = 3;
				goto IL_0151;
			case "3":
				num = 3;
				goto IL_0151;
			case "neutral":
			case "0":
				markViolatorAs = Misc.PostureStance.Neutral;
				break;
			case "friendly":
			case "1":
				{
					markViolatorAs = Misc.PostureStance.Friendly;
					break;
				}
				IL_0151:
				markViolatorAs = (Misc.PostureStance)num;
				break;
				IL_00ce:
				markViolatorAs = (Misc.PostureStance)num2;
				break;
			}
			try
			{
				if (zone_0.GetType() == typeof(ExclusionZone))
				{
					((ExclusionZone)zone_0).MarkViolatorAs = markViolatorAs;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public LuaTable area
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (ReferencePoint item in zone_0.Area)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["name"] = item.Name;
				luaTable2["guid"] = item.ObjectID;
				luaTable2["longitude"] = item.Longitude;
				luaTable2["latitude"] = item.Latitude;
				luaTable2["highlighted"] = item.IsHighlighted;
				luaTable2["visible"] = item.IsVisible;
				luaTable2["side"] = side_0.Name;
				luaTable2["locked"] = item.IsLocked;
				if (!Information.IsNothing((object)item.IsRelativeTo))
				{
					luaTable2["relativeto_type"] = item.GetType().Name;
					luaTable2["bearingtype"] = item.BearingType;
					luaTable2["relativeto"] = item.IsRelativeTo.ObjectID;
				}
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
		set
		{
			List<ReferencePoint> list = new List<ReferencePoint>();
			Side side = null;
			Module_Unit.Unit unit = null;
			bool flag = false;
			Contact contact = null;
			ReferencePoint referencePoint = null;
			ScenarioObject theRelativeObject = null;
			list.Clear();
			List<object> list2 = LuaUtility.ToArray(value.GetEnumerator());
			side = side_0;
			if (side == null)
			{
				return;
			}
			using (List<object>.Enumerator enumerator = list2.GetEnumerator())
			{
				_Closure$__31-0 closure$__31- = default(_Closure$__31-0);
				while (enumerator.MoveNext())
				{
					closure$__31- = new _Closure$__31-0(closure$__31-);
					closure$__31-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator.Current);
					ReferencePoint referencePoint2 = null;
					if (closure$__31-.$VB$Local_o.GetType() == typeof(LuaTable))
					{
						Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)closure$__31-.$VB$Local_o).GetEnumerator());
						if (unit == null && dictionary.ContainsKey("RELATIVETO"))
						{
							string text = Conversions.ToString(dictionary["RELATIVETO"]);
							unit = PrivateMethods.ValidateAUBySide(text, side_0);
							if (unit == null)
							{
								throw new LuaError("Missing unit " + text + " from relative bearing");
							}
							theRelativeObject = unit;
						}
						else if (contact == null && dictionary.ContainsKey("RELATIVETO_CONTACT"))
						{
							string text2 = Conversions.ToString(dictionary["RELATIVETO_CONTACT"]);
							contact = PrivateMethods.ValidateContactBySide(text2, 0, side_0);
							if (contact == null)
							{
								throw new LuaError("Missing contact " + text2 + " from relative bearing");
							}
							theRelativeObject = contact;
						}
						else if (referencePoint == null && dictionary.ContainsKey("RELATIVETO_RP"))
						{
							string text3 = Conversions.ToString(dictionary["RELATIVETO_RP"]);
							referencePoint = PrivateMethods.ValidateRPBySide(text3, side_0);
							if (referencePoint == null)
							{
								throw new LuaError("Missing RP " + text3 + " from relative bearing");
							}
							theRelativeObject = referencePoint;
						}
						if (!flag && dictionary.ContainsKey("HIDDEN") && LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(dictionary["HIDDEN"])) == true)
						{
							flag = true;
						}
						Scenario scenarioContext = scenario_0;
						ReferencePoint thisRP = null;
						referencePoint2 = LuaReferencePoint.ParseReferencePoint(dictionary, null, scenarioContext, ref thisRP, theRelativeObject);
						if (!Information.IsNothing((object)referencePoint2))
						{
							list.Add(referencePoint2);
						}
					}
					else
					{
						if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault(closure$__31-._Lambda$__0)))
						{
							referencePoint2 = side.RefPoints.First(closure$__31-._Lambda$__1);
						}
						if (!Information.IsNothing((object)referencePoint2))
						{
							list.Add(referencePoint2);
						}
					}
				}
			}
			zone_0.Area = new ObservableList<ReferencePoint>(list);
			foreach (ReferencePoint item in list)
			{
				item.IsVisible = !flag;
			}
		}
	}

	[DoNotPrune]
	public LuaTable affects
	{
		get
		{
			List<GlobalVariables.ActiveUnitType> list = new List<GlobalVariables.ActiveUnitType>();
			if (!(zone_0.GetType() == typeof(NoNavZone)))
			{
				if (zone_0.GetType() == typeof(ExclusionZone))
				{
					list = ((ExclusionZone)zone_0).AffectedUnitTypes.ToList();
				}
			}
			else
			{
				list = ((NoNavZone)zone_0).AffectedUnitTypes.ToList();
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			foreach (GlobalVariables.ActiveUnitType item in list)
			{
				luaTable[num] = item.ToString();
				num++;
			}
			return luaTable;
		}
		set
		{
			List<GlobalVariables.ActiveUnitType> list = new List<GlobalVariables.ActiveUnitType>();
			list.Clear();
			List<object> list2 = LuaUtility.ToArray(value.GetEnumerator());
			foreach (object item in list2)
			{
				string a = RuntimeHelpers.GetObjectValue(item).ToString();
				GlobalVariables.ActiveUnitType activeUnitType = GlobalVariables.ActiveUnitType.None;
				byte[] array = (byte[])Enum.GetValues(typeof(GlobalVariables.ActiveUnitType));
				int num = 0;
				while (num < array.Length)
				{
					byte b = array[num];
					if (!string.Equals(a, b.ToString(), StringComparison.OrdinalIgnoreCase))
					{
						GlobalVariables.ActiveUnitType activeUnitType2 = (GlobalVariables.ActiveUnitType)b;
						if (!string.Equals(a, activeUnitType2.ToString(), StringComparison.OrdinalIgnoreCase))
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
					list.Add(activeUnitType);
				}
			}
			if (!(zone_0.GetType() == typeof(NoNavZone)))
			{
				if (!(zone_0.GetType() == typeof(ExclusionZone)))
				{
					return;
				}
				ObservableList<GlobalVariables.ActiveUnitType> affectedUnitTypes = ((ExclusionZone)zone_0).AffectedUnitTypes;
				if (!Information.IsNothing((object)list))
				{
					affectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>();
					foreach (GlobalVariables.ActiveUnitType item2 in list)
					{
						affectedUnitTypes.Add(item2);
					}
				}
				else
				{
					affectedUnitTypes = new ObservableList<GlobalVariables.ActiveUnitType>
					{
						GlobalVariables.ActiveUnitType.Aircraft,
						GlobalVariables.ActiveUnitType.Ship,
						GlobalVariables.ActiveUnitType.Submarine,
						GlobalVariables.ActiveUnitType.Facility
					};
				}
				((ExclusionZone)zone_0).AffectedUnitTypes = affectedUnitTypes;
				return;
			}
			ObservableList<GlobalVariables.ActiveUnitType> affectedUnitTypes2 = ((NoNavZone)zone_0).AffectedUnitTypes;
			if (Information.IsNothing((object)list))
			{
				affectedUnitTypes2 = new ObservableList<GlobalVariables.ActiveUnitType>
				{
					GlobalVariables.ActiveUnitType.Aircraft,
					GlobalVariables.ActiveUnitType.Ship,
					GlobalVariables.ActiveUnitType.Submarine,
					GlobalVariables.ActiveUnitType.Facility
				};
			}
			else
			{
				affectedUnitTypes2 = new ObservableList<GlobalVariables.ActiveUnitType>();
				foreach (GlobalVariables.ActiveUnitType item3 in list)
				{
					affectedUnitTypes2.Add(item3);
				}
			}
			((NoNavZone)zone_0).AffectedUnitTypes = affectedUnitTypes2;
		}
	}

	[DoNotPrune]
	public string areacolor
	{
		get
		{
			return zone_0.AreaColor.ToArgb().ToString();
		}
		set
		{
			Color areaColor = Color.FromName(value);
			if (areaColor.IsKnownColor)
			{
				zone_0.AreaColor = areaColor;
				return;
			}
			try
			{
				zone_0.AreaColor = ColorTranslator.FromHtml("#" + value);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public object noFire
	{
		get
		{
			if (zone_0.GetType() == typeof(NoNavZone))
			{
				return ((NoNavZone)zone_0).NoFireZone;
			}
			return null;
		}
		set
		{
			try
			{
				if (zone_0.GetType() == typeof(NoNavZone))
				{
					((NoNavZone)zone_0).NoFireZone = Conversions.ToBoolean(value);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public object altitudeEnvelopeMin
	{
		get
		{
			return zone_0.AltitudeEnvelopeMin;
		}
		set
		{
			try
			{
				if (value != null)
				{
					zone_0.AltitudeEnvelopeMin = Conversions.ToSingle(value);
				}
				else
				{
					zone_0.AltitudeEnvelopeMin = null;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public object altitudeEnvelopeMax
	{
		get
		{
			return zone_0.AltitudeEnvelopeMax;
		}
		set
		{
			try
			{
				if (value != null)
				{
					zone_0.AltitudeEnvelopeMax = Conversions.ToSingle(value);
				}
				else
				{
					zone_0.AltitudeEnvelopeMax = null;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public int landcovertype
	{
		get
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				return (int)((CustomEnvironmentZone)zone_0).TerrainType;
			}
			return 0;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)zone_0).TerrainType = (LandCover.LandCoverType)value;
			}
		}
	}

	[DoNotPrune]
	public bool hascustomlandcoverheight
	{
		get
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)zone_0).HasCustomTerrainHeight;
			}
			return false;
		}
	}

	[DoNotPrune]
	public int landcoverheight
	{
		get
		{
			if (!(zone_0.GetType() == typeof(CustomEnvironmentZone)))
			{
				return 0;
			}
			return ((CustomEnvironmentZone)zone_0).TerrainHeight;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)zone_0).TerrainHeight = value;
			}
		}
	}

	[DoNotPrune]
	public int thermallayerceiling
	{
		get
		{
			if (!(zone_0.GetType() == typeof(CustomEnvironmentZone)))
			{
				return 0;
			}
			return ((CustomEnvironmentZone)zone_0).ThermalLayerCeiling;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)zone_0).ThermalLayerCeiling = value;
			}
		}
	}

	[DoNotPrune]
	public int thermallayerfloor
	{
		get
		{
			if (!(zone_0.GetType() == typeof(CustomEnvironmentZone)))
			{
				return 0;
			}
			return ((CustomEnvironmentZone)zone_0).ThermalLayerFloor;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)zone_0).ThermalLayerFloor = value;
			}
		}
	}

	[DoNotPrune]
	public float thermallayerstrength
	{
		get
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)zone_0).LayerStrength;
			}
			return 0f;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)zone_0).LayerStrength = value;
			}
		}
	}

	[DoNotPrune]
	public float convergencezoneinterval
	{
		get
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((CustomEnvironmentZone)zone_0).CZInterval;
			}
			return 0f;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((CustomEnvironmentZone)zone_0).CZInterval = value;
			}
		}
	}

	[DoNotPrune]
	public LuaTable weatherprofile
	{
		get
		{
			if (!(zone_0.GetType() == typeof(CustomEnvironmentZone)))
			{
				return null;
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			CustomEnvironmentZone customEnvironmentZone = (CustomEnvironmentZone)zone_0;
			luaTable["temp"] = customEnvironmentZone.Weather.AverageTemp;
			luaTable["rainfall"] = customEnvironmentZone.Weather.RainfallRate;
			luaTable["undercloud"] = customEnvironmentZone.Weather.FractionUnderRain;
			luaTable["seastate"] = customEnvironmentZone.Weather.SeaState;
			return luaTable;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				CustomEnvironmentZone customEnvironmentZone = (CustomEnvironmentZone)zone_0;
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(value.GetEnumerator());
				if (dictionary.ContainsKey("TEMP") && double.TryParse(Conversions.ToString(dictionary["TEMP"]), out var result))
				{
					customEnvironmentZone.Weather.AverageTemp = result;
				}
				if (dictionary.ContainsKey("RAINFALL") && float.TryParse(Conversions.ToString(dictionary["RAINFALL"]), out var result2))
				{
					customEnvironmentZone.Weather.RainfallRate = result2;
				}
				if (dictionary.ContainsKey("UNDERCLOUD") && float.TryParse(Conversions.ToString(dictionary["UNDERCLOUD"]), out var result3))
				{
					customEnvironmentZone.Weather.FractionUnderRain = result3;
				}
				if (dictionary.ContainsKey("SEASTATE") && int.TryParse(Conversions.ToString(dictionary["SEASTATE"]), out var result4))
				{
					customEnvironmentZone.Weather.SeaState = result4;
				}
			}
		}
	}

	[DoNotPrune]
	public int layer
	{
		get
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				return ((Zone)(CustomEnvironmentZone)zone_0).get_Layer(side_0);
			}
			return 0;
		}
		set
		{
			if (zone_0.GetType() == typeof(CustomEnvironmentZone))
			{
				((Zone)(CustomEnvironmentZone)zone_0).set_Layer(side_0, value);
			}
		}
	}

	[DoNotPrune]
	public LuaTable enablers
	{
		get
		{
			if (!(zone_0.GetType() == typeof(Zone)))
			{
				return null;
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["GNSS_BeiDou"] = zone_0.Enablers.GNSS_BeiDou;
			luaTable["GNSS_GPS"] = zone_0.Enablers.GNSS_GPS;
			luaTable["GNSS_GLONASS"] = zone_0.Enablers.GNSS_GLONASS;
			luaTable["GNSS_NavIC"] = zone_0.Enablers.GNSS_NavIC;
			return luaTable;
		}
		set
		{
			if (zone_0.GetType() == typeof(Zone))
			{
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(value.GetEnumerator());
				if (dictionary.ContainsKey("GNSS_BEIDOU") && bool.TryParse(Conversions.ToString(dictionary["GNSS_BEIDOU"]), out var result))
				{
					zone_0.Enablers.GNSS_BeiDou = result;
				}
				if (dictionary.ContainsKey("GNSS_GPS") && bool.TryParse(Conversions.ToString(dictionary["GNSS_GPS"]), out var result2))
				{
					zone_0.Enablers.GNSS_GPS = result2;
				}
				if (dictionary.ContainsKey("GNSS_GLONASS") && bool.TryParse(Conversions.ToString(dictionary["GNSS_GLONASS"]), out var result3))
				{
					zone_0.Enablers.GNSS_GLONASS = result3;
				}
				if (dictionary.ContainsKey("GNSS_NAVIC") && bool.TryParse(Conversions.ToString(dictionary["GNSS_NAVIC"]), out var result4))
				{
					zone_0.Enablers.GNSS_NavIC = result4;
				}
			}
		}
	}

	public LuaWrapper_Zone(Zone theZone, Scenario theScen, Side theSide)
	{
		zone_0 = theZone;
		scenario_0 = theScen;
		side_0 = theSide;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "zone {\r\n guid = '" + guid + "', \r\n description = '" + description + "', \r\n isactive = '" + isactive.ToString() + "', \r\n area = '" + area.ToString() + "', \r\n type = '" + zone_0.Type.ToString() + "'\r\n";
		if (zone_0.GetType() == typeof(ExclusionZone))
		{
			text = text + " altitudeEnvelopeMin = '" + ((ExclusionZone)zone_0).AltitudeEnvelopeMin + "'\r\n";
			text = text + " altitudeEnvelopeMax = '" + ((ExclusionZone)zone_0).AltitudeEnvelopeMax + "'\r\n";
		}
		if (zone_0.GetType() == typeof(NoNavZone))
		{
			text = text + " noFire = '" + ((NoNavZone)zone_0).NoFireZone + "'\r\n";
		}
		return text + "}";
	}

	static LuaWrapper_Zone()
	{
		Class72.smethod_20();
	}
}
