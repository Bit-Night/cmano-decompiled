using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public sealed class LuaWrapper_Waypoint
{
	internal Waypoint myWP;

	private Scenario scenario_0;

	[DoNotPrune]
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
	public object time
	{
		get
		{
			if (myWP.Time_Zulu.HasValue)
			{
				return myWP.Time_Zulu.Value.ToString("yyyyMMddHHmmss");
			}
			return null;
		}
		set
		{
			DateTime? time_Zulu = LuaUtility.ParseDateTime_String(Conversions.ToString(value), LuaUtility.DateFormat.ISO);
			if (time_Zulu.HasValue)
			{
				myWP.Time_Zulu = time_Zulu;
			}
		}
	}

	[DoNotPrune]
	public object __obj => myWP;

	[DoNotPrune]
	public string objectid => myWP.ObjectID;

	[DoNotPrune]
	public string guid => myWP.ObjectID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return myWP.Name;
		}
		set
		{
			myWP.Name = value;
		}
	}

	[DoNotPrune]
	public double latitude
	{
		get
		{
			return myWP.Latitude;
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as latitude.");
			}
			myWP.Latitude = num.Value;
		}
	}

	[DoNotPrune]
	public double longitude
	{
		get
		{
			return myWP.Longitude;
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as longitude.");
			}
			myWP.Longitude = num.Value;
		}
	}

	[DoNotPrune]
	public float altitude
	{
		get
		{
			return myWP.Altitude;
		}
		set
		{
			myWP.Altitude = value;
		}
	}

	[DoNotPrune]
	public object type
	{
		get
		{
			return myWP.Type.ToString();
		}
		set
		{
			Waypoint.WaypointType result = Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			if (Enum.TryParse<Waypoint.WaypointType>(Conversions.ToString(value), ignoreCase: true, out result) && Enum.IsDefined(typeof(Waypoint.WaypointType), result))
			{
				myWP.Type = result;
			}
		}
	}

	[DoNotPrune]
	public float? altitudeDesired
	{
		get
		{
			float? result = null;
			result = (myWP.TerrainFollowing ? new float?((!myWP.DesiredAltitude_TerrainFollowing.HasValue) ? 0f : myWP.DesiredAltitude_TerrainFollowing.Value) : new float?((!myWP.DesiredAltitude.HasValue) ? 0f : myWP.DesiredAltitude.Value));
			return result;
		}
		set
		{
			if (!value.HasValue)
			{
				myWP.DesiredAltitude = null;
				myWP.DesiredAltitude_TerrainFollowing = null;
				myWP.DesiredAltitudeOverride = false;
				return;
			}
			object altitudeObject = value;
			ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
			float? num = LuaUtility.QueryAltitudeObject(altitudeObject, ref AltitudePreset);
			if (num.HasValue && (object)num.GetType() == typeof(float))
			{
				if (!myWP.TerrainFollowing)
				{
					myWP.DesiredAltitude = num.Value;
				}
				else
				{
					myWP.DesiredAltitude_TerrainFollowing = num.Value;
				}
				myWP.DesiredAltitudeOverride = true;
			}
		}
	}

	[DoNotPrune]
	public float? speedDesired
	{
		get
		{
			return myWP.DesiredSpeed.HasValue ? myWP.DesiredSpeed.Value : 0f;
		}
		set
		{
			if (!value.HasValue)
			{
				myWP.DesiredSpeed = null;
				myWP.DesiredSpeedOverride = null;
			}
			else
			{
				float value2 = value.Value;
				myWP.DesiredSpeed = value2;
				myWP.DesiredSpeedOverride = value2;
			}
		}
	}

	[DoNotPrune]
	public string description
	{
		get
		{
			return myWP.Description;
		}
		set
		{
			myWP.Description = value;
		}
	}

	[DoNotPrune]
	public bool TF
	{
		get
		{
			return myWP.TerrainFollowing;
		}
		set
		{
			bool terrainFollowing = myWP.TerrainFollowing;
			myWP.TerrainFollowing = value;
			if (value != terrainFollowing)
			{
				if (myWP.TerrainFollowing)
				{
					myWP.DesiredAltitude_TerrainFollowing = myWP.DesiredAltitude;
					myWP.DesiredAltitude = null;
				}
				else
				{
					myWP.DesiredAltitude = myWP.DesiredAltitude_TerrainFollowing;
					myWP.DesiredAltitude_TerrainFollowing = null;
				}
			}
		}
	}

	[DoNotPrune]
	public int TFType
	{
		get
		{
			return (int)myWP.TerrainFollowingType;
		}
		set
		{
			myWP.TerrainFollowingType = (ActiveUnit.TerrainFollowMode)value;
		}
	}

	[DoNotPrune]
	public object presetAltitude
	{
		get
		{
			if (myWP.AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
			{
				return myWP.AltitudePreset;
			}
			return null;
		}
		set
		{
			ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
			if (!LuaUtility.QueryAltitudeObject(RuntimeHelpers.GetObjectValue(value), ref AltitudePreset).HasValue)
			{
				myWP.AltitudePreset = AltitudePreset.Value;
			}
		}
	}

	[DoNotPrune]
	public object presetDepth
	{
		get
		{
			if (myWP.DepthPreset != ActiveUnit_AI.SubmarineDepthPreset.None)
			{
				return myWP.DepthPreset;
			}
			return null;
		}
		set
		{
			float? num = LuaUtility.QueryDepthObject(RuntimeHelpers.GetObjectValue(value));
			if (num.HasValue)
			{
				myWP.DepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)Math.Round(num.Value);
			}
		}
	}

	[DoNotPrune]
	public object presetThrottle
	{
		get
		{
			if (myWP.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return myWP.ThrottlePreset;
			}
			return null;
		}
		set
		{
			if (Operators.CompareString(Conversions.ToString(value), "5", false) != 0 && Operators.CompareString(Conversions.ToString(value).ToLower(), "none", false) != 0)
			{
				ActiveUnit.Throttle? throttle = LuaUtility.QueryThrottleObject(Conversions.ToString(value));
				if (throttle.HasValue)
				{
					myWP.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)throttle.Value;
				}
			}
			else
			{
				myWP.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
		}
	}

	[DoNotPrune]
	public string actionId
	{
		get
		{
			return myWP.EventActionID;
		}
		set
		{
			EventAction value2 = null;
			if (string.IsNullOrEmpty(value))
			{
				myWP.EventActionID = null;
				return;
			}
			if (!scenario_0.EventActions.TryGetValue(value, out value2))
			{
				foreach (EventAction value3 in scenario_0.EventActions.Values)
				{
					if (value3.Type == EventAction.EventActionType.LuaScript && ((EventAction_LuaScript)value3).ScriptForType == EventAction_LuaScript.EventAction_LuaScript_Type.WaypointAction && (string.Equals(value3.Description, value, StringComparison.OrdinalIgnoreCase) || string.Equals(value3.ObjectID, value, StringComparison.OrdinalIgnoreCase)))
					{
						value = value3.ObjectID;
						value2 = value3;
						break;
					}
				}
			}
			if (value2 != null && value2.Type == EventAction.EventActionType.LuaScript && ((EventAction_LuaScript)value2).ScriptForType == EventAction_LuaScript.EventAction_LuaScript_Type.WaypointAction)
			{
				myWP.EventActionID = value;
			}
		}
	}

	[DoNotPrune]
	public string actionIdDescription
	{
		get
		{
			if (string.IsNullOrEmpty(myWP.EventActionID))
			{
				return null;
			}
			EventAction value = null;
			if (scenario_0.EventActions.TryGetValue(myWP.EventActionID, out value))
			{
				return value.Description.ToString();
			}
			return "";
		}
	}

	public LuaWrapper_Waypoint(Waypoint theWaypoint, Scenario theScen)
	{
		myWP = theWaypoint;
		scenario_0 = theScen;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "waypoint {\r\n type = '" + type.ToString() + "', \r\n name = '" + name + "', \r\n description = '" + description + "', \r\n guid = '" + guid.ToString() + "', \r\n time = '" + ((time == null) ? "" : time.ToString()) + "', \r\n latitude = '" + latitude + "', \r\n longitude = '" + longitude + "', \r\n";
		if (!string.IsNullOrEmpty(actionId))
		{
			text = text + " eventAction = '" + actionId.ToString() + "', \r\n eventActionDescription = '" + actionIdDescription.ToString() + "', \r\n";
		}
		return text + "}";
	}

	[DoNotPrune]
	public static LuaTable ToTable(Waypoint theWP, Scenario ScenarioContext)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		luaTable["GUID"] = theWP.ObjectID;
		luaTable["latitude"] = theWP.Latitude;
		luaTable["longitude"] = theWP.Longitude;
		if (theWP.AltitudePreset != ActiveUnit_AI.AircraftAltitudePreset.None)
		{
			luaTable["PresetAltitude"] = theWP.AltitudePreset.ToString();
		}
		if (theWP.DepthPreset != ActiveUnit_AI.SubmarineDepthPreset.None)
		{
			luaTable["PresetDepth"] = theWP.DepthPreset.ToString();
		}
		if (theWP.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
		{
			luaTable["PresetThrottle"] = theWP.ThrottlePreset.ToString();
		}
		if (theWP.DesiredAltitude.HasValue)
		{
			luaTable["DesiredAltitude"] = theWP.DesiredAltitude.ToString();
		}
		if (theWP.DesiredAltitude_TerrainFollowing.HasValue)
		{
			luaTable["DesiredAltitudeTF"] = theWP.DesiredAltitude_TerrainFollowing.ToString();
		}
		if (theWP.DesiredSpeed.HasValue)
		{
			luaTable["DesiredSpeed"] = theWP.DesiredSpeed.ToString();
		}
		if (theWP.TerrainFollowing)
		{
			luaTable["TF"] = theWP.TerrainFollowing.ToString();
		}
		luaTable["Description"] = theWP.Description;
		luaTable["Name"] = theWP.Name;
		luaTable["Category"] = theWP.Category.ToString();
		luaTable["TypeOf"] = theWP.Type.ToString();
		if (!string.IsNullOrEmpty(theWP.EventActionID))
		{
			luaTable["EventAction"] = theWP.EventActionID.ToString();
			EventAction value = null;
			if (ScenarioContext.EventActions.TryGetValue(theWP.EventActionID, out value))
			{
				luaTable["EventActionDescription"] = value.Description.ToString();
			}
		}
		if (theWP.Category == Waypoint.WaypointCategory.FlightPlan && theWP.Time_Zulu.HasValue)
		{
			string text = theWP.Time_Zulu.Value.Year.ToString();
			text = ((theWP.Time_Zulu.Value.Month >= 10) ? (text + theWP.Time_Zulu.Value.Month) : string.Concat(text, "0" + theWP.Time_Zulu.Value.Month));
			text = ((theWP.Time_Zulu.Value.Day >= 10) ? (text + theWP.Time_Zulu.Value.Day) : string.Concat(text, "0" + theWP.Time_Zulu.Value.Day));
			text = ((theWP.Time_Zulu.Value.Hour >= 10) ? (text + theWP.Time_Zulu.Value.Hour) : string.Concat(text, "0" + theWP.Time_Zulu.Value.Hour));
			text = ((theWP.Time_Zulu.Value.Minute >= 10) ? (text + theWP.Time_Zulu.Value.Minute) : string.Concat(text, "0" + theWP.Time_Zulu.Value.Minute));
			text = ((theWP.Time_Zulu.Value.Second >= 10) ? (text + theWP.Time_Zulu.Value.Second) : (text + "0" + theWP.Time_Zulu.Value.Second));
			luaTable["Zulu"] = text.ToString();
		}
		return luaTable;
	}

	[DoNotPrune]
	public static bool FromTable(LuaTable value, Waypoint theWP, Scenario ScenarioContext)
	{
		bool result2;
		try
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(value.GetEnumerator());
			double? num = LuaUtility.QueryLongitude(dictionary);
			double? num2 = LuaUtility.QueryLatitude(dictionary);
			if (!num.HasValue | !num.HasValue)
			{
				throw new LuaError("Course object needs latitude or longitude.");
			}
			theWP.Longitude = num.Value;
			theWP.Latitude = num2.Value;
			if (dictionary.ContainsKey("TYPEOF") || dictionary.ContainsKey("TYPE"))
			{
				string value2;
				int num3;
				if (!dictionary.ContainsKey("TYPEOF"))
				{
					value2 = Conversions.ToString(dictionary["TYPE"]);
					num3 = 0;
				}
				else
				{
					value2 = Conversions.ToString(dictionary["TYPEOF"]);
					num3 = 0;
				}
				Waypoint.WaypointType result = (Waypoint.WaypointType)num3;
				if (Enum.TryParse<Waypoint.WaypointType>(value2, out result) & Enum.IsDefined(typeof(Waypoint.WaypointType), result))
				{
					theWP.Type = result;
				}
			}
			if (dictionary.ContainsKey("PRESETALTITUDE"))
			{
				string altitudeObject = Conversions.ToString(dictionary["PRESETALTITUDE"]);
				ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				if (!LuaUtility.QueryAltitudeObject(altitudeObject, ref AltitudePreset).HasValue)
				{
					theWP.AltitudePreset = AltitudePreset.Value;
				}
			}
			if (dictionary.ContainsKey("PRESETDEPTH"))
			{
				float? num4 = LuaUtility.QueryDepthObject(Conversions.ToString(dictionary["PRESETDEPTH"]));
				if (num4.HasValue)
				{
					theWP.DepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)Math.Round(num4.Value);
				}
			}
			if (dictionary.ContainsKey("PRESETTHROTTLE"))
			{
				string text = Conversions.ToString(dictionary["PRESETTHROTTLE"]);
				if (Operators.CompareString(text, "5", false) != 0 && Operators.CompareString(text.ToLower(), "none", false) != 0)
				{
					ActiveUnit.Throttle? throttle = LuaUtility.QueryThrottleObject(text);
					if (throttle.HasValue)
					{
						theWP.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)throttle.Value;
					}
				}
				else
				{
					theWP.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				}
			}
			if (dictionary.ContainsKey("TF"))
			{
				bool? flag = LuaUtility.ParseBoolean(Conversions.ToString(dictionary["TF"]));
				if (flag.HasValue)
				{
					theWP.TerrainFollowing = flag.Value;
				}
			}
			if (dictionary.ContainsKey("DESIREDALTITUDE"))
			{
				string altitudeObject2 = Conversions.ToString(dictionary["DESIREDALTITUDE"]);
				ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset2 = null;
				float? num5 = LuaUtility.QueryAltitudeObject(altitudeObject2, ref AltitudePreset2);
				if (num5.HasValue && (object)num5.GetType() == typeof(float))
				{
					theWP.DesiredAltitude = num5.Value;
					theWP.DesiredAltitudeOverride = true;
				}
			}
			if (dictionary.ContainsKey("DESIREDALTITUDETF"))
			{
				string altitudeObject3 = Conversions.ToString(dictionary["DESIREDALTITUDETF"]);
				ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset2 = null;
				float? num6 = LuaUtility.QueryAltitudeObject(altitudeObject3, ref AltitudePreset2);
				if (num6.HasValue && (object)num6.GetType() == typeof(float))
				{
					theWP.DesiredAltitude_TerrainFollowing = num6.Value;
				}
			}
			if (dictionary.ContainsKey("DESIREDSPEED"))
			{
				float value3 = Conversions.ToSingle(Conversions.ToString(dictionary["DESIREDSPEED"]));
				theWP.DesiredSpeed = value3;
				theWP.DesiredSpeedOverride = value3;
			}
			if (dictionary.ContainsKey("DESCRIPTION"))
			{
				string text2 = Conversions.ToString(dictionary["DESCRIPTION"]);
				theWP.Description = text2;
			}
			if (dictionary.ContainsKey("NAME"))
			{
				string text3 = Conversions.ToString(dictionary["NAME"]);
				theWP.Name = text3;
			}
			if (dictionary.ContainsKey("CATEGORY"))
			{
				string value4 = Conversions.ToString(dictionary["CATEGORY"]);
				theWP.Category = (Waypoint.WaypointCategory)Enum.Parse(typeof(Waypoint.WaypointCategory), value4, ignoreCase: true);
			}
			if (dictionary.ContainsKey("ZULU"))
			{
				DateTime? time_Zulu = LuaUtility.ParseDateTime_String(Conversions.ToString(dictionary["ZULU"]), LuaUtility.DateFormat.ISO);
				if (time_Zulu.HasValue)
				{
					theWP.Time_Zulu = time_Zulu;
				}
			}
			int num7;
			if (!dictionary.ContainsKey("EVENTACTION"))
			{
				num7 = 1;
			}
			else
			{
				string text4 = Conversions.ToString(dictionary["EVENTACTION"]);
				EventAction value5 = null;
				if (!ScenarioContext.EventActions.TryGetValue(text4, out value5))
				{
					foreach (EventAction value6 in ScenarioContext.EventActions.Values)
					{
						if (value6.Type == EventAction.EventActionType.LuaScript && ((EventAction_LuaScript)value6).ScriptForType == EventAction_LuaScript.EventAction_LuaScript_Type.WaypointAction && (string.Equals(value6.Description, text4, StringComparison.OrdinalIgnoreCase) || string.Equals(value6.ObjectID, text4, StringComparison.OrdinalIgnoreCase)))
						{
							text4 = value6.ObjectID;
							value5 = value6;
							break;
						}
					}
				}
				if (value5 == null)
				{
					num7 = 1;
				}
				else if (value5.Type == EventAction.EventActionType.LuaScript && ((EventAction_LuaScript)value5).ScriptForType == EventAction_LuaScript.EventAction_LuaScript_Type.WaypointAction)
				{
					theWP.EventActionID = text4;
					num7 = 1;
				}
				else
				{
					num7 = 1;
				}
			}
			result2 = (byte)num7 != 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result2 = false;
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	[DoNotPrune]
	public LuaTable ToTableWrapper()
	{
		return ToTable(myWP, scenario_0);
	}

	[DoNotPrune]
	public bool FromTableWrapper(LuaTable value, Waypoint theWP)
	{
		return FromTable(value, myWP, scenario_0);
	}

	static LuaWrapper_Waypoint()
	{
		Class72.smethod_20();
	}
}
