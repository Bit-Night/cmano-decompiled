using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;
using NLua.Exceptions;

namespace Command_Core.Lua;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscateType]
public sealed class LuaWrapper_ActiveUnit_SE : LuaWrapper_ActiveUnit
{
	[DoNotPrune]
	public override double latitude
	{
		get
		{
			return au.get_Latitude((GlobalVariables.BooleanObject)null);
		}
		set
		{
			double? num = LuaUtility.QueryLatitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as latitude.");
			}
			au.Teleport(ref au.ParentScen, au.get_Longitude((GlobalVariables.BooleanObject)null), num.Value);
		}
	}

	[DoNotPrune]
	public override double longitude
	{
		get
		{
			return au.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		set
		{
			double? num = LuaUtility.QueryLongitudeObject(value);
			if (!num.HasValue)
			{
				throw new LuaError("Can't pass nil in as longitude.");
			}
			au.Teleport(ref au.ParentScen, num.Value, au.get_Latitude((GlobalVariables.BooleanObject)null));
		}
	}

	[DoNotPrune]
	public override bool autodetectable
	{
		get
		{
			return au.get_IsAutoDetectable((Side)null);
		}
		set
		{
			au.set_IsAutoDetectable((Side)null, value);
			if (value)
			{
				au.get_UnitSide(SetSideOnly: false).ProcessAutoDetectableUnits(ScenarioContext, ScenarioContext.GameResolution);
			}
		}
	}

	[DoNotPrune]
	public override object altitude
	{
		get
		{
			return au.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null);
		}
		set
		{
			object? objectValue = RuntimeHelpers.GetObjectValue(value);
			ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
			float? num = LuaUtility.QueryAltitudeObject(objectValue, ref AltitudePreset);
			if (num.HasValue && (object)num.GetType() == typeof(float))
			{
				ActiveUnit activeUnit = au;
				object? objectValue2 = RuntimeHelpers.GetObjectValue(value);
				AltitudePreset = null;
				activeUnit.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, LuaUtility.QueryAltitudeObject(objectValue2, ref AltitudePreset).Value);
			}
		}
	}

	[DoNotPrune]
	public object autonomylevel
	{
		get
		{
			if (au.IsAircraft)
			{
				return ((Aircraft)au).AutonomyLevel;
			}
			return ActiveUnit.DroneAutonomyLevel.Undefined;
		}
		set
		{
			try
			{
				ActiveUnit.DroneAutonomyLevel autonomyLevel = (ActiveUnit.DroneAutonomyLevel)Conversions.ToInteger(value);
				if (au.IsAircraft)
				{
					((Aircraft)au).AutonomyLevel = autonomyLevel;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaException(ex2.Message);
			}
		}
	}

	[DoNotPrune]
	public override object speed
	{
		get
		{
			return au.CurrentSpeed;
		}
		set
		{
			float num = Conversions.ToSingle(value);
			if (num > (float)au.Kinematics.GetMaximumSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), au.ThrottleSetting, ValidateAndFixAltitude: false))
			{
				num = au.Kinematics.GetMaximumSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), au.ThrottleSetting, ValidateAndFixAltitude: false);
			}
			au.CurrentSpeed = num;
		}
	}

	[DoNotPrune]
	public override object manualAltitude
	{
		get
		{
			if (au.Kinematics.DesiredAltitudeOverride)
			{
				return au.DesiredAltitude;
			}
			return null;
		}
		set
		{
			switch (Conversions.ToString(value).ToUpperInvariant())
			{
			case "OFF":
				au.Kinematics.DesiredAltitudeOverride = false;
				return;
			case "DESIRED":
				_ = au.DesiredAltitude;
				au.Kinematics.DesiredAltitudeOverride = true;
				return;
			case "CURRENT":
				au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				au.Kinematics.DesiredAltitudeOverride = true;
				return;
			}
			if (au.IsSubmarine)
			{
				ActiveUnit_AI.SubmarineDepthPreset? submarineDepthPreset = LuaUtility.QueryDepthPresetObject(Conversions.ToString(value));
				if (!submarineDepthPreset.HasValue)
				{
					float? num = LuaUtility.QueryDepthObject(Conversions.ToString(value));
					au.DesiredAltitude = num.Value;
					((Submarine)au).AI.DepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
					au.Kinematics.DesiredAltitudeOverride = true;
				}
				else
				{
					((Submarine)au).AI.DepthPreset = submarineDepthPreset.Value;
					((Submarine)au).AI.FollowDepthPreset(CheckThreats: false);
					au.Kinematics.DesiredAltitudeOverride = true;
				}
				return;
			}
			if (!au.IsAircraft)
			{
				string altitudeObject = Conversions.ToString(value);
				ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
				float? num2 = LuaUtility.QueryAltitudeObject(altitudeObject, ref AltitudePreset);
				if (num2.HasValue && (object)num2.GetType() == typeof(float))
				{
					au.DesiredAltitude = num2.Value;
					au.Kinematics.DesiredAltitudeOverride = true;
				}
				return;
			}
			ActiveUnit_AI.AircraftAltitudePreset? aircraftAltitudePreset = LuaUtility.QueryAltitudePresetObject(Conversions.ToString(value));
			if (!aircraftAltitudePreset.HasValue)
			{
				string altitudeObject2 = Conversions.ToString(value);
				ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
				float? num3 = LuaUtility.QueryAltitudeObject(altitudeObject2, ref AltitudePreset);
				if (num3.HasValue && (object)num3.GetType() == typeof(float))
				{
					au.DesiredAltitude = num3.Value;
					((Aircraft)au).AI.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					au.Kinematics.DesiredAltitudeOverride = true;
				}
			}
			else
			{
				((Aircraft)au).AI.AltitudePreset = aircraftAltitudePreset.Value;
				((Aircraft)au).AI.FollowAltitudePreset();
				au.Kinematics.DesiredAltitudeOverride = true;
			}
		}
	}

	[DoNotPrune]
	public override object manualSpeed
	{
		get
		{
			if (au.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return au.Kinematics.DesiredSpeedOverride;
			}
			return au.DesiredSpeed;
		}
		set
		{
			float num = 0f;
			switch (Conversions.ToString(value).ToUpperInvariant())
			{
			case "DESIRED":
				num = au.DesiredSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				break;
			default:
			{
				float? num2 = null;
				try
				{
					num2 = float.Parse(Conversions.ToString(value));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				if (num2.HasValue)
				{
					au.Kinematics.DesiredSpeedOverride = num2.Value;
					au.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				}
				break;
			}
			case "OFF":
				au.Kinematics.DesiredSpeedOverride = null;
				break;
			case "CURRENT":
				num = au.CurrentSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				break;
			}
			float? desiredSpeedOverride = au.Kinematics.DesiredSpeedOverride;
			if (!desiredSpeedOverride.HasValue)
			{
				return;
			}
			if (au.IsGroup && ((Group)au).GroupLead != null)
			{
				ActiveUnit activeUnit = ((Group)au).GroupLead;
				activeUnit.SetThrottle(activeUnit.Kinematics.GetThrottleSuitableForThisSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), desiredSpeedOverride.Value));
				au.ThrottleSetting = activeUnit.ThrottleSetting;
				float? num3 = desiredSpeedOverride;
				float num4 = activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), activeUnit.ThrottleSetting, ValidateAndFixAltitude: false);
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() > num4) : ((bool?)null)) == true)
				{
					au.Kinematics.DesiredSpeedOverride = activeUnit.Kinematics.GetMaximumSpeed(activeUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), activeUnit.ThrottleSetting, ValidateAndFixAltitude: false);
				}
			}
			else
			{
				au.SetThrottle(au.Kinematics.GetThrottleSuitableForThisSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), desiredSpeedOverride.Value));
				float? num3 = desiredSpeedOverride;
				float num4 = au.Kinematics.GetMaximumSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), au.ThrottleSetting, ValidateAndFixAltitude: false);
				if ((num3.HasValue ? new bool?(num3.GetValueOrDefault() > num4) : ((bool?)null)) == true)
				{
					au.Kinematics.DesiredSpeedOverride = au.Kinematics.GetMaximumSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), au.ThrottleSetting, ValidateAndFixAltitude: false);
				}
			}
		}
	}

	[DoNotPrune]
	public object manualThrottle
	{
		get
		{
			if (au.Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				return au.Kinematics.DesiredSpeedOverride;
			}
			return au.Kinematics.ThrottlePreset;
		}
		set
		{
			float num = 0f;
			switch (Conversions.ToString(value).ToUpperInvariant())
			{
			case "OFF":
				au.Kinematics.DesiredSpeedOverride = null;
				return;
			case "DESIRED":
				num = au.DesiredSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				return;
			case "CURRENT":
				num = au.CurrentSpeed;
				au.Kinematics.DesiredSpeedOverride = num;
				return;
			}
			if (Enum.TryParse<ActiveUnit_Kinematics.UnitThrottlePreset>(Conversions.ToString(value), ignoreCase: true, out var result) && Enum.IsDefined(typeof(ActiveUnit_Kinematics.UnitThrottlePreset), result))
			{
				au.Kinematics.ThrottlePreset = result;
				if (au.IsGroup && ((Group)au).GroupLead != null)
				{
					ActiveUnit activeUnit = ((Group)au).GroupLead;
					au.Kinematics.DesiredSpeedOverride = activeUnit.Kinematics.GetMaximumSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (ActiveUnit.Throttle)au.Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
				}
				else
				{
					au.Kinematics.DesiredSpeedOverride = au.Kinematics.GetMaximumSpeed(au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (ActiveUnit.Throttle)au.Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
				}
			}
		}
	}

	[DoNotPrune]
	public override object throttle
	{
		get
		{
			return au.ThrottleSetting;
		}
		set
		{
			au.SetThrottle(LuaUtility.QueryThrottleObject(Conversions.ToString(value)).Value);
		}
	}

	[DoNotPrune]
	public override LuaTable course
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			Waypoint[] plottedCourse = au.Navigator.PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2 = LuaWrapper_Waypoint.ToTable(waypoint, ScenarioContext);
				LuaWrapper_Waypoint value = new LuaWrapper_Waypoint(waypoint, ScenarioContext);
				luaTable2["WayPoint"] = value;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
		set
		{
			if (value != null)
			{
				au.Navigator.ClearPlottedCourse();
				List<object> list = LuaUtility.ToArray(value.GetEnumerator());
				using List<object>.Enumerator enumerator = list.GetEnumerator();
				object objectValue;
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
					if (!(objectValue is LuaTable))
					{
						break;
					}
					Waypoint waypoint = new Waypoint(0.0, 0.0, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Manual, Waypoint.WaypointCategory.PlottedCourse);
					if (!LuaWrapper_Waypoint.FromTable((LuaTable)objectValue, waypoint, ScenarioContext))
					{
						continue;
					}
					Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)objectValue).GetEnumerator());
					double? num = LuaUtility.QueryLongitude(dictionary);
					LuaUtility.QueryLatitude(dictionary);
					if (!(!num.HasValue | !num.HasValue))
					{
						if (dictionary.ContainsKey("DESIREDSPEED"))
						{
							float num2 = Conversions.ToSingle(Conversions.ToString(dictionary["DESIREDSPEED"]));
							int maximumSpeed = au.Kinematics.GetMaximumSpeed();
							if ((maximumSpeed == 0) & au.IsGroup)
							{
								maximumSpeed = ((Group)au).Kinematics.GetMaximumSpeed(waypoint.Altitude);
							}
							if (num2 > (float)maximumSpeed)
							{
								num2 = maximumSpeed;
							}
							waypoint.DesiredSpeed = num2;
							waypoint.DesiredSpeedOverride = num2;
						}
						if (!dictionary.ContainsKey("WAYPOINT"))
						{
							au.Navigator.AddWaypoint(waypoint);
						}
						continue;
					}
					throw new LuaError("Course object " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)) + " needs latitude or longitude.");
				}
				throw new LuaError("Error at " + LuaUtility.LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue)));
			}
			au.Navigator.ClearPlottedCourse();
		}
	}

	[DoNotPrune]
	public override LuaTable fuel
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (FuelRec item in au.Fuel_ReadOnly)
			{
				if (luaTable[Convert.ToInt32((short)item.FuelType)] != null)
				{
					LuaTable luaTable2 = (LuaTable)luaTable[Convert.ToInt32((short)item.FuelType)];
					luaTable2["current"] = Conversions.ToSingle(luaTable2["current"]) + item.CurrentQuantity;
					luaTable2["max"] = Conversions.ToSingle(luaTable2["max"]) + (float)item.MaxQuantity;
					continue;
				}
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				luaTable3["current"] = item.CurrentQuantity;
				luaTable3["max"] = item.MaxQuantity;
				luaTable3["name"] = item.FuelType.ToString();
				luaTable3["type"] = Convert.ToInt32((short)item.FuelType);
				luaTable[Convert.ToInt32((short)item.FuelType)] = luaTable3;
			}
			return luaTable;
		}
		set
		{
			try
			{
				foreach (object key in value.Keys)
				{
					double num = Conversions.ToDouble(key);
					float num2 = Conversions.ToSingle(((LuaTable)value[num])["current"]);
					if (!au.IsAircraft)
					{
						foreach (FuelRec item in au.Fuel_ReadOnly)
						{
							if ((double)item.FuelType == num)
							{
								float val = Math.Min(item.MaxQuantity, num2);
								val = (item.CurrentQuantity = Math.Max(0f, val));
								num2 -= val;
							}
						}
					}
					else
					{
						((Aircraft)au).FuelCapacitySet(num2);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting fuel.");
			}
		}
	}

	[DoNotPrune]
	public override object group
	{
		get
		{
			if ((au.get_ParentGroup(UsingMissionPlanner: false) != null) | au.IsGroup)
			{
				if (au.get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					return new LuaWrapper_Group(au.get_ParentGroup(UsingMissionPlanner: false), ScenarioContext);
				}
				return new LuaWrapper_Group((Group)au, ScenarioContext);
			}
			return null;
		}
		set
		{
			try
			{
				if (au.UnitType != GlobalVariables.ActiveUnitType.None)
				{
					if (Operators.CompareString(Conversions.ToString(value).ToLower(), "none", false) != 0)
					{
						Group obj = LuaUtility.QueryGroupObject(RuntimeHelpers.GetObjectValue(value), au.get_UnitSide(SetSideOnly: false), ScenarioContext);
						if (obj == null)
						{
							List<ActiveUnit> list = new List<ActiveUnit>();
							list.Add(au);
							ref Scenario scenarioContext = ref ScenarioContext;
							ActiveUnit activeUnit;
							Side theSide = (activeUnit = au).get_UnitSide(SetSideOnly: false);
							Group obj2 = new Group(ref scenarioContext, ref theSide, list);
							activeUnit.set_UnitSide(SetSideOnly: false, theSide);
							Group obj3 = obj2;
							obj3.Name = Conversions.ToString(value);
							au.set_ParentGroup(UsingMissionPlanner: false, obj3);
						}
						else
						{
							au.set_ParentGroup(UsingMissionPlanner: false, obj);
						}
					}
					else
					{
						au.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					}
					return;
				}
				throw new LuaError("Can't change group on a group.");
			}
			catch (LuaError projectError)
			{
				ProjectData.SetProjectError((Exception)projectError);
				throw;
			}
		}
	}

	[DoNotPrune]
	public object groupLead
	{
		get
		{
			if ((au.get_ParentGroup(UsingMissionPlanner: false) != null) | au.IsGroup)
			{
				if (au.get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					return new LuaWrapper_ActiveUnit_SE(au, ScenarioContext);
				}
				return new LuaWrapper_ActiveUnit_SE(au.get_ParentGroup(UsingMissionPlanner: false).GroupLead, ScenarioContext);
			}
			return null;
		}
		set
		{
			try
			{
				if ((au.get_ParentGroup(UsingMissionPlanner: false) != null) | au.IsGroup)
				{
					ActiveUnit activeUnit = PrivateMethods.smethod_1(Conversions.ToString(value), ScenarioContext);
					if (activeUnit == null)
					{
						throw new LuaError("Invalid group lead.");
					}
					if (au.get_ParentGroup(UsingMissionPlanner: false) != null)
					{
						au.get_ParentGroup(UsingMissionPlanner: false).SetGroupLead(activeUnit);
					}
					else
					{
						((Group)au).SetGroupLead(activeUnit);
					}
				}
			}
			catch (LuaError projectError)
			{
				ProjectData.SetProjectError((Exception)projectError);
				throw;
			}
		}
	}

	[DoNotPrune]
	public override LuaTable formation
	{
		get
		{
			if (au.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				ActiveUnit activeUnit = au.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				ActiveUnit_Navigator.FormationStation unitFormationStation = au.Navigator.UnitFormationStation;
				luaTable["guid"] = au.ObjectID;
				luaTable["bearing"] = unitFormationStation.Bearing;
				luaTable["type"] = unitFormationStation.BearingType.ToString();
				luaTable["distance"] = unitFormationStation.Distance;
				luaTable["sprint"] = au.Navigator.SprintDrift.ToString();
				(double, double) tuple = unitFormationStation.get_LatitudeAndLongitude(au, activeUnit);
				luaTable["latitude"] = tuple.Item1;
				luaTable["longitude"] = tuple.Item2;
				return luaTable;
			}
			if (!au.IsGroup)
			{
				return null;
			}
			Group obj = (Group)au;
			ActiveUnit activeUnit2 = obj.GroupLead;
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["lead"] = activeUnit2.ObjectID;
			luaTable2["name"] = obj.LastFormationSet;
			luaTable2["spacing"] = obj.LastFormationSpacing;
			luaTable2["spacing_unit"] = obj.LastFormationSpacingUnits;
			return luaTable2;
		}
		set
		{
			try
			{
				if (au.get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					if (!au.IsGroup)
					{
						return;
					}
					Group obj = (Group)au;
					ActiveUnit activeUnit = obj.GroupLead;
					float num = obj.LastFormationSpacing;
					float baseHeading = activeUnit.DesiredHeading;
					string formationName = "";
					byte spacingUnit = obj.LastFormationSpacingUnits;
					bool teleportToStations = false;
					foreach (object key in value.Keys)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(key);
						switch (objectValue.ToString().ToLower())
						{
						case "name":
							formationName = Conversions.ToString(value[RuntimeHelpers.GetObjectValue(objectValue)]);
							break;
						case "spacing_unit":
							spacingUnit = Conversions.ToByte(value[RuntimeHelpers.GetObjectValue(objectValue)]);
							break;
						case "bearing":
							baseHeading = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue)]);
							break;
						case "transpose":
							if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[RuntimeHelpers.GetObjectValue(objectValue)])).HasValue)
							{
								teleportToStations = Conversions.ToBoolean(value[RuntimeHelpers.GetObjectValue(objectValue)]);
							}
							break;
						case "spacing":
							num = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue)]);
							break;
						}
					}
					if (num == 0f)
					{
						num = 1f;
					}
					StandardFormation.SetFormation(au, formationName, baseHeading, num, spacingUnit, teleportToStations);
					return;
				}
				ActiveUnit activeUnit2 = au.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				ActiveUnit_Navigator.FormationStation unitFormationStation = au.Navigator.UnitFormationStation;
				bool flag = false;
				foreach (object key2 in value.Keys)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(key2);
					switch (objectValue2.ToString().ToLower())
					{
					case "bearing":
					{
						float num2 = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue2)]);
						if (num2 >= 0f && num2 < 360f)
						{
							unitFormationStation.Bearing = num2;
						}
						break;
					}
					case "type":
					{
						ReferencePoint.OrientationType result = ReferencePoint.OrientationType.Fixed;
						if (Enum.TryParse<ReferencePoint.OrientationType>(Conversions.ToString(value[RuntimeHelpers.GetObjectValue(objectValue2)]), ignoreCase: true, out result) && Enum.IsDefined(typeof(ReferencePoint.OrientationType), result))
						{
							unitFormationStation.BearingType = result;
						}
						break;
					}
					case "distance":
					{
						float num3 = Conversions.ToSingle(value[RuntimeHelpers.GetObjectValue(objectValue2)]);
						if (num3 > 0f)
						{
							unitFormationStation.Distance = num3;
						}
						break;
					}
					case "transpose":
						if (LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[RuntimeHelpers.GetObjectValue(objectValue2)])).HasValue)
						{
							flag = Conversions.ToBoolean(value[RuntimeHelpers.GetObjectValue(objectValue2)]);
						}
						break;
					case "sprint":
					{
						bool? flag2 = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[RuntimeHelpers.GetObjectValue(objectValue2)]));
						if (flag2.HasValue)
						{
							au.Navigator.SprintDrift = flag2.Value;
						}
						break;
					}
					}
				}
				if (unitFormationStation != null)
				{
					Geodesic_Vincenty.TCoord Pt = new Geodesic_Vincenty.TCoord(activeUnit2.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit2.get_Longitude((GlobalVariables.BooleanObject)null));
					Geodesic_Vincenty.TCoord Ret = default(Geodesic_Vincenty.TCoord);
					Geodesic_Vincenty.fw_vincenty_wgs84(ref Pt, ref Ret, unitFormationStation.Bearing, unitFormationStation.Distance);
					double lat = Ret.Lat;
					double lon = Ret.Lon;
					if (!flag)
					{
						au.Navigator.ClearPlottedCourse();
						au.Navigator.CalculateFormationStationRelativeData(lon, lat, ResetValues: true);
					}
					else
					{
						(double, double) tuple = au.Navigator.UnitFormationStation.get_ValidatedLatitudeAndLongitude(au, activeUnit2);
						au.Teleport(ref au.ParentScen, tuple.Item2, tuple.Item1);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting formation.");
			}
		}
	}

	[DoNotPrune]
	public override object heading
	{
		get
		{
			return au.CurrentHeading;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.CurrentHeading = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public override LuaTable OODA
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["detection"] = au.OODA_Detection;
			luaTable["targeting"] = au.OODA_Targeting;
			if (au.OODA_Targeting_Actual == 0)
			{
				au.Proficiency = au.Proficiency;
			}
			luaTable["[R]targeting_actual"] = au.OODA_Targeting_Actual;
			luaTable["evasion"] = au.OODA_Evasion;
			return luaTable;
		}
		set
		{
			try
			{
				foreach (object key in value.Keys)
				{
					string text = Conversions.ToString(key);
					short num = Conversions.ToShort(value[text]);
					au.HasCustomOODA = true;
					switch (text)
					{
					case "targeting":
						au.OODA_Targeting = num;
						break;
					case "evasion":
						au.OODA_Evasion = num;
						break;
					case "detection":
						au.OODA_Detection = num;
						break;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting OODA.");
			}
		}
	}

	[DoNotPrune]
	public override LuaWrapper_ActiveUnit @base
	{
		get
		{
			LuaWrapper_ActiveUnit result = null;
			switch (base.type)
			{
			case "Aircraft":
				if (au.AirOps != null)
				{
					Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
					if (aircraft_AirOps.CurrentHostUnit != null)
					{
						result = new LuaWrapper_ActiveUnit(aircraft_AirOps.CurrentHostUnit, ScenarioContext);
					}
					else if (aircraft_AirOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(aircraft_AirOps.ActualDestinationHost, ScenarioContext);
					}
				}
				break;
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps = au.DockingOps;
					if (dockingOps.CurrentHostUnit != null)
					{
						result = new LuaWrapper_ActiveUnit(dockingOps.CurrentHostUnit, ScenarioContext);
					}
					else if (dockingOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(dockingOps.ActualDestinationHost, ScenarioContext);
					}
				}
				break;
			}
			return result;
		}
		set
		{
			switch (base.type)
			{
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
				if (value != null)
				{
					ActiveUnit activeUnit2 = PrivateMethods.smethod_1(value.guid, ScenarioContext);
					if (aircraft_AirOps.ThisUnitCanHostMe(activeUnit2, HumanFeedbackNeeded: false).ResponseBoolean)
					{
						aircraft_AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, activeUnit2);
					}
				}
				else
				{
					aircraft_AirOps.PickNewAssignedHost_Nearest();
				}
				break;
			}
			case "Ship":
			case "Submarine":
			{
				if (au.DockingOps == null)
				{
					break;
				}
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (value != null)
				{
					ActiveUnit activeUnit = PrivateMethods.smethod_1(value.guid, ScenarioContext);
					if (dockingOps.ThisUnitCanHostMe(activeUnit, HumanFeedBackNeeded: false).ResponseBoolean)
					{
						dockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, activeUnit);
					}
				}
				else
				{
					dockingOps.PickNewAssignedHost_Nearest();
				}
				break;
			}
			}
		}
	}

	[DoNotPrune]
	public override bool sprintDrift
	{
		get
		{
			if (au.Navigator == null)
			{
				return false;
			}
			return au.Navigator.SprintDrift;
		}
		set
		{
			if (au.Navigator != null)
			{
				au.Navigator.SprintDrift = value;
			}
		}
	}

	[DoNotPrune]
	public bool avoidCavitation
	{
		get
		{
			if (au.Navigator != null)
			{
				return au.Navigator.AvoidCavitation;
			}
			return false;
		}
		set
		{
			if (au.Navigator == null)
			{
				return;
			}
			if (au.IsGroup && ((Group)au).Units.Count > 0)
			{
				foreach (ActiveUnit value2 in ((Group)au).Units.Values)
				{
					value2.Navigator.AvoidCavitation = value;
				}
			}
			au.Navigator.AvoidCavitation = value;
		}
	}

	[DoNotPrune]
	public bool AI_EvaluateTargets_enabled
	{
		get
		{
			return au.AI.EvaluateTargets_Enabled;
		}
		set
		{
			au.AI.EvaluateTargets_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool AI_DeterminePrimaryTarget_enabled
	{
		get
		{
			return au.AI.DeterminePrimaryTarget_Enabled;
		}
		set
		{
			au.AI.DeterminePrimaryTarget_Enabled = value;
		}
	}

	[DoNotPrune]
	public bool obeyEMCON
	{
		get
		{
			return au.Sensory.ObeysEMCON;
		}
		set
		{
			au.Sensory.ObeysEMCON = value;
		}
	}

	[DoNotPrune]
	public override LuaTable sensors
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Sensor[] sensors_Cached = au.Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["sensor_dbid"] = sensor.DBID;
				luaTable2["sensor_guid"] = sensor.ObjectID;
				luaTable2["sensor_name"] = sensor.Name;
				luaTable2["sensor_type"] = (short)sensor.Type;
				luaTable2["sensor_role"] = (long)sensor.Role;
				luaTable2["sensor_maxrange"] = sensor.maxRange;
				luaTable2["sensor_status"] = sensor.Status.ToString();
				luaTable2["sensor_isactive"] = sensor.IsActive();
				if (sensor.Status != PlatformComponent._ComponentStatus.Operational)
				{
					luaTable2["sensor_statusR"] = sensor.ReasonForInoperative;
					luaTable2["sensor_damage"] = sensor.DamageSeverity.ToString();
				}
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
		set
		{
			string b = null;
			PlatformComponent._ComponentStatus? componentStatus = null;
			bool? flag = null;
			try
			{
				foreach (object key in value.Keys)
				{
					string text = Conversions.ToString(key);
					switch (text)
					{
					case "sensor_guid":
						b = Conversions.ToString(value[text]);
						break;
					case "sensor_status":
					{
						_ = Enum.TryParse<PlatformComponent._ComponentStatus>(Conversions.ToString(value[text]), out var result) & Enum.IsDefined(typeof(PlatformComponent._ComponentStatus), result);
						componentStatus = result;
						break;
					}
					case "sensor_isactive":
						flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value[text]));
						break;
					}
				}
				Sensor[] sensors_Cached = au.Sensors_Cached;
				int num = 0;
				Sensor sensor;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						sensor = sensors_Cached[num];
						if (string.Equals(sensor.ObjectID, b, StringComparison.OrdinalIgnoreCase))
						{
							break;
						}
						num = checked(num + 1);
						continue;
					}
					return;
				}
				if (flag.HasValue)
				{
					if (flag != true)
					{
						sensor.GoPassive();
					}
					else
					{
						sensor.GoActive();
					}
				}
				if (componentStatus.HasValue)
				{
					byte? b2 = (byte?)componentStatus;
					if (((!b2.HasValue) ? ((bool?)null) : new bool?(b2.GetValueOrDefault() == 0)) == true)
					{
						sensor.MakeOperational(GiveUserFeedback: false);
					}
					b2 = (byte?)componentStatus;
					if (((!b2.HasValue) ? ((bool?)null) : new bool?(b2 == 2)) == true)
					{
						sensor.Destroy(au.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
					}
					b2 = (byte?)componentStatus;
					if (((!b2.HasValue) ? ((bool?)null) : new bool?(b2 == 1)) == true)
					{
						sensor.Damage(PlatformComponent._DamageSeverityFactor.Light);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting sensor.");
			}
		}
	}

	[DoNotPrune]
	public override LuaTable components
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PlatformComponent platformComponent = null;
			if (au.Components().Count > 0)
			{
				foreach (PlatformComponent item in au.Components())
				{
					platformComponent = item;
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["comp_guid"] = platformComponent.ObjectID;
					luaTable2["comp_dbid"] = platformComponent.DBID;
					luaTable2["comp_name"] = platformComponent.Name;
					luaTable2["comp_type"] = platformComponent.GetType().Name;
					luaTable2["comp_status"] = platformComponent.Status.ToString();
					if (platformComponent.Status != PlatformComponent._ComponentStatus.Operational)
					{
						luaTable2["comp_damage"] = platformComponent.DamageSeverity.ToString();
						luaTable2["comp_statusR"] = platformComponent.ReasonForInoperative;
					}
					if (platformComponent.GetType() == typeof(Cargo))
					{
						luaTable2["comp_name"] = ((Cargo)platformComponent).CargoObjectName;
						luaTable2["comp_type"] = (int)((Cargo)platformComponent).CurrentType;
						luaTable2["comp_dbid"] = ((Cargo)platformComponent).CargoObjectDBID;
						luaTable2["comp_guid"] = ((Cargo)platformComponent).CargoObjectID;
					}
					if (!(platformComponent.GetType() == typeof(CommDevice)))
					{
						if (platformComponent.GetType() == typeof(Sensor))
						{
							Sensor sensor = (Sensor)platformComponent;
							luaTable2["comp_sensor_jammed"] = sensor.IsNeutralized;
							if (sensor.Coverage != null && sensor.Coverage.HasDefinedArcs)
							{
								List<string> theArcList = new List<string>();
								sensor.Coverage.ComponentArcString(ref platformComponent, ref theArcList);
								if (theArcList.Count > 0)
								{
									luaTable2["comp_sensor_detect"] = string.Join(", ", theArcList);
								}
							}
							if (sensor.Coverage != null && sensor.Coverage.HasDefinedArcs)
							{
								List<string> theArcList2 = new List<string>();
								sensor.Coverage.ComponentArcString(ref platformComponent, ref theArcList2);
								if (theArcList2.Count > 0)
								{
									luaTable2["comp_sensor_track"] = string.Join(", ", theArcList2);
								}
							}
						}
						else if (platformComponent.GetType() == typeof(Mount))
						{
							Mount mount = (Mount)platformComponent;
							if (mount.Coverage != null && mount.Coverage.HasDefinedArcs)
							{
								List<string> theArcList3 = new List<string>();
								mount.Coverage.ComponentArcString(ref platformComponent, ref theArcList3);
								if (theArcList3.Count > 0)
								{
									luaTable2["comp_mount_arc"] = string.Join(", ", theArcList3);
								}
							}
						}
					}
					else
					{
						luaTable2["comp_comms_jammed"] = ((CommDevice)platformComponent).IsJammed;
						if (au.IsWeapon && ((Weapon)au).DataLinkParent != null)
						{
							luaTable2["comp_comms_datalink_parent"] = new LuaWrapper_ActiveUnit(((Weapon)au).DataLinkParent, ScenarioContext);
						}
					}
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
		set
		{
			string b = null;
			PlatformComponent._ComponentStatus? componentStatus = null;
			bool? flag = null;
			bool? isNeutralized = null;
			bool? flag2 = null;
			try
			{
				foreach (object key in value.Keys)
				{
					string text = Conversions.ToString(key);
					switch (text)
					{
					case "comp_guid":
						b = Conversions.ToString(value[text]);
						break;
					case "comp_sensor_jammed":
						isNeutralized = LuaUtility.ParseBoolean(Conversions.ToString(value[text]));
						break;
					case "comp_comms_jammed":
						flag2 = LuaUtility.ParseBoolean(Conversions.ToString(value[text]));
						break;
					case "comp_status":
					{
						if (Enum.TryParse<PlatformComponent._ComponentStatus>(Conversions.ToString(value[text]), out var result) & Enum.IsDefined(typeof(PlatformComponent._ComponentStatus), result))
						{
							componentStatus = result;
						}
						break;
					}
					}
				}
				Sensor[] sensors_Cached = au.Sensors_Cached;
				int num = 0;
				Sensor sensor;
				while (true)
				{
					if (num >= sensors_Cached.Length)
					{
						foreach (PlatformComponent item in au.Components())
						{
							if (string.Equals(item.ObjectID, b, StringComparison.OrdinalIgnoreCase) && flag2.HasValue && item.GetType() == typeof(CommDevice))
							{
								((CommDevice)item).IsJammed = flag2.Value;
							}
						}
						return;
					}
					sensor = sensors_Cached[num];
					if (string.Equals(sensor.ObjectID, b, StringComparison.OrdinalIgnoreCase))
					{
						break;
					}
					num = checked(num + 1);
				}
				if (flag.HasValue)
				{
					if (flag == true)
					{
						sensor.GoActive();
					}
					else
					{
						sensor.GoPassive();
					}
				}
				if (componentStatus.HasValue)
				{
					byte? b2 = (byte?)componentStatus;
					if (((!b2.HasValue) ? ((bool?)null) : new bool?(b2.GetValueOrDefault() == 0)) == true)
					{
						sensor.MakeOperational(GiveUserFeedback: false);
					}
					b2 = (byte?)componentStatus;
					if (((!b2.HasValue) ? ((bool?)null) : new bool?(b2 == 2)) == true)
					{
						sensor.Destroy(au.get_UnitSide(SetSideOnly: false), ScenEditAction: true, IsAimpointFacility: false);
					}
					b2 = (byte?)componentStatus;
					if (((!b2.HasValue) ? ((bool?)null) : new bool?(b2 == 1)) == true)
					{
						sensor.Damage(PlatformComponent._DamageSeverityFactor.Light);
					}
				}
				if (isNeutralized.HasValue)
				{
					sensor.IsNeutralized = isNeutralized;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Error setting component.");
			}
		}
	}

	[DoNotPrune]
	public bool SAR_enabled
	{
		get
		{
			return au.EligibleForSAR;
		}
		set
		{
			au.EligibleForSAR = value;
		}
	}

	[DoNotPrune]
	public bool beingPickedUp
	{
		get
		{
			return au.IsBeingPickedUp;
		}
		set
		{
			au.IsBeingPickedUp = value;
		}
	}

	[DoNotPrune]
	public LuaWrapper_ActiveUnit pickUpTarget
	{
		get
		{
			LuaWrapper_ActiveUnit result = null;
			if (au.AI != null && au.AI.PrimaryPickupTarget != null)
			{
				return new LuaWrapper_ActiveUnit(au.AI.PrimaryPickupTarget, ScenarioContext);
			}
			return result;
		}
		set
		{
			if (value != null)
			{
				ActiveUnit activeUnit = PrivateMethods.smethod_1(value.guid, ScenarioContext);
				if (activeUnit != null)
				{
					au.AI.PrimaryPickupTarget = activeUnit;
				}
			}
			else
			{
				au.AI.ClearManualOrders();
			}
			au.Navigator.PlotCourseToPickupPoint();
		}
	}

	[DoNotPrune]
	public new object readytime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return Misc.TimeString((long)Math.Round(((Aircraft)au).AirOps.ConditionTimer), 0, ReturnNo: false, ReturnZero: true);
			}
			if (au.DockingOps != null)
			{
				return Misc.TimeString((long)Math.Round(au.DockingOps.ConditionTimer), 0, ReturnNo: false, ReturnZero: true);
			}
			return null;
		}
		set
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (((Aircraft)au).IsParked() | (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
				{
					((Aircraft)au).AirOps.ConditionTimer = Conversions.ToLong(value);
					if (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)
					{
						((Aircraft)au).AirOps.OverrideConditionTimer = Conversions.ToLong(value);
					}
				}
			}
			else if (au.DockingOps != null)
			{
				au.DockingOps.ConditionTimer = Conversions.ToLong(value);
			}
		}
	}

	[DoNotPrune]
	public object loadoutreadytime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft) && ((Aircraft)au).Loadout != null)
			{
				return Misc.TimeString(((Aircraft)au).Loadout.ReadyTime, 0, ReturnNo: false, ReturnZero: true);
			}
			return null;
		}
		set
		{
			if ((object)au.GetType() == typeof(Aircraft) && (((Aircraft)au).IsParked() | (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying)))
			{
				((Aircraft)au).Loadout.ReadyTime = Conversions.ToInteger(value);
			}
		}
	}

	[DoNotPrune]
	public object readytime_v
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return (long)Math.Round(((Aircraft)au).AirOps.ConditionTimer);
			}
			if (au.DockingOps == null)
			{
				return null;
			}
			return (long)Math.Round(au.DockingOps.ConditionTimer);
		}
		set
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (((Aircraft)au).IsParked() | (((Aircraft)au).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.Readying))
				{
					((Aircraft)au).AirOps.ConditionTimer = Conversions.ToLong(value);
				}
			}
			else if (au.DockingOps != null)
			{
				au.DockingOps.ConditionTimer = Conversions.ToLong(value);
			}
		}
	}

	[DoNotPrune]
	public bool unassign
	{
		set
		{
			if (value)
			{
				ActiveUnit activeUnit = au;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			}
		}
	}

	[DoNotPrune]
	public float oldDamagePercent
	{
		set
		{
			if (value > 100f)
			{
				value = 100f;
			}
			if (value < 0f)
			{
				value = 0f;
			}
			if (value >= 0f && value <= 100f)
			{
				au._OldDamagePercent = value;
			}
		}
	}

	[DoNotPrune]
	public new float roll
	{
		get
		{
			return au.Attitude_Roll;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.Attitude_Roll = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public new float pitch
	{
		get
		{
			if (!au.SupportsAttitude_Pitch)
			{
				return 0f;
			}
			return au.Attitude_Pitch;
		}
		set
		{
			float result = 0f;
			try
			{
				if (au.SupportsAttitude_Pitch && float.TryParse(Conversions.ToString(value), out result))
				{
					au.Attitude_Pitch = result;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	[DoNotPrune]
	public object target
	{
		get
		{
			if (au.AI.PrimaryTarget != null)
			{
				return new LuaWrapper_Contact(au.AI.PrimaryTarget, ScenarioContext, au.get_UnitSide(SetSideOnly: false));
			}
			return null;
		}
		set
		{
			string text = null;
			Contact contact = null;
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)value).GetEnumerator());
			if (dictionary.ContainsKey("GUID"))
			{
				try
				{
					text = Conversions.ToString(dictionary["GUID"]);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw new LuaError("guid must be a string");
				}
			}
			if (Operators.CompareString(text.ToLower(), "none", false) != 0)
			{
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				contact = PrivateMethods.ValidateContactBySceanrio(text, ScenarioContext);
				if (contact == null)
				{
					ActiveUnit activeUnit = PrivateMethods.smethod_1(text, ScenarioContext);
					if (activeUnit != null)
					{
						Side side = au.get_UnitSide(SetSideOnly: false);
						foreach (Contact contacts_ in side.Contacts_List)
						{
							if (Operators.CompareString(contacts_.ActualUnit.ObjectID, activeUnit.ObjectID, false) == 0)
							{
								contact = contacts_;
								break;
							}
						}
						foreach (string key in side.NewContactsQueue.Keys)
						{
							if (Operators.CompareString(key, activeUnit.ObjectID, false) == 0 && !side.Contacts_List.Contains(side.NewContactsQueue[key]))
							{
								contact = side.NewContactsQueue[key];
								break;
							}
						}
					}
				}
				if (contact == null)
				{
					double num = 0.0;
					new List<Waypoint>();
					if (Operators.CompareString(text.ToUpper(), "BOL", false) == 0)
					{
						string latitudeString = null;
						if (dictionary.ContainsKey("LATITUDE"))
						{
							latitudeString = Conversions.ToString(dictionary["LATITUDE"]);
						}
						double lat = LuaUtility.ParseLatitudeString(latitudeString);
						latitudeString = "";
						if (dictionary.ContainsKey("LONGITUDE"))
						{
							latitudeString = Conversions.ToString(dictionary["LONGITUDE"]);
						}
						num = LuaUtility.ParseLongitudeString(latitudeString);
						contact = new ActivationPointContact(lat, num);
					}
				}
				if (contact != null)
				{
					au.AI.PrimaryTarget = contact;
					if (contact.Type != Contact_Base.ContactType.ActivationPoint)
					{
						au.AI.DeterminePrimaryTarget_Enabled = false;
					}
				}
			}
			else
			{
				au.AI.DropTarget(au.AI.PrimaryTarget);
				au.AI.DeterminePrimaryTarget_Enabled = true;
			}
		}
	}

	[DoNotPrune]
	public object quickTurnaround
	{
		get
		{
			if ((object)au.GetType() != typeof(Aircraft))
			{
				return null;
			}
			if (((Aircraft)au).Loadout != null)
			{
				_ = ((Aircraft)au).Loadout;
				Aircraft_AirOps airOps = ((Aircraft)au).AirOps;
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				luaTable["state"] = airOps.QuickTurnaround_Enabled;
				if (airOps.QuickTurnaround_Enabled)
				{
					luaTable["sorties"] = airOps.QuickTurnaround_SortiesFlown;
					luaTable["extratime"] = airOps.QuickTurnaround_TimePentalty;
					luaTable["airborne"] = airOps.QuickTurnaround_AirborneTime_Flown;
					luaTable["totalsorties"] = airOps.QuickTurnaround_SortiesTotal;
					luaTable["avgsortietime"] = airOps.QuickTurnaround_AirborneTime_SortieAverage;
				}
				return luaTable;
			}
			return null;
		}
		set
		{
			try
			{
				if ((object)au.GetType() != typeof(Aircraft) || ((Aircraft)au).Loadout == null)
				{
					return;
				}
				_ = ((Aircraft)au).Loadout;
				Aircraft_AirOps theAO = ((Aircraft)au).AirOps;
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)value).GetEnumerator());
				foreach (string key in dictionary.Keys)
				{
					switch (key)
					{
					case "TOTALSORTIES":
						theAO.QuickTurnaround_SortiesTotal = Conversions.ToInteger(dictionary[key]);
						break;
					case "AVGSORTIETIME":
						theAO.QuickTurnaround_AirborneTime_SortieAverage = Conversions.ToSingle(dictionary[key]);
						break;
					case "RESET":
						theAO.QuickTurnaround_SortiesFlown = 0;
						theAO.QuickTurnaround_TimePentalty = 0;
						theAO.QuickTurnaround_AirborneTime_Flown = 0f;
						theAO.QuickTurnaround_AirborneTime_SortieAverage = 0f;
						break;
					case "AIRBORNE":
						theAO.QuickTurnaround_AirborneTime_Flown = Conversions.ToSingle(dictionary[key]);
						break;
					case "EXTRATIME":
						theAO.QuickTurnaround_TimePentalty = Conversions.ToInteger(dictionary[key]);
						break;
					case "SORTIES":
						theAO.QuickTurnaround_SortiesFlown = Conversions.ToInteger(dictionary[key]);
						break;
					case "STATE":
						if (theAO.QuickTurnaround_Enabled && !Conversions.ToBoolean(dictionary[key]) && theAO.QuickTurnaround_SortiesFlown > 0)
						{
							Aircraft_AirOps aircraft_AirOps = theAO;
							Aircraft theAC = (Aircraft)au;
							aircraft_AirOps.UpdateQuickTurnaroundSettings_StepDown(ref theAO, ref theAC);
						}
						theAO.QuickTurnaround_Enabled = Conversions.ToBoolean(dictionary[key]);
						break;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public LuaWrapper_ActiveUnit_SE(ActiveUnit a, Scenario s)
		: base(a, s)
	{
	}

	public LuaWrapper_ActiveUnit_SE(UnguidedWeapon a, Scenario s)
		: base(a, s)
	{
	}

	[DoNotPrune]
	public void updateorbit(LuaTable theTable)
	{
		if (au.IsSatellite)
		{
			Dictionary<string, object> dict = LuaUtility.ToDictUpper(theTable.GetEnumerator());
			LuaUtility.ParseUnitDict(ref dict);
			if (dict.ContainsKey("TLE"))
			{
				string text = Conversions.ToString(dict["TLE"]);
				try
				{
					string[] orbit_OT = text.Split(new char[1] { '\n' });
					((Satellite)au).Kinematics.SetOrbit_OT(orbit_OT);
					return;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					throw new LuaError(ex2.Message);
				}
			}
			return;
		}
		throw new LuaError("Unit: " + au.Name + " is not a satellite!");
	}

	[DoNotPrune]
	public void delete()
	{
		if (ScenarioContext.ActiveUnits[au.ObjectID] == null && ScenarioContext.UnguidedWeapons[au.ObjectID] == null)
		{
			ScenarioContext.DeleteThisUnit(au, "Deleted via Lua command.");
		}
		else
		{
			ScenarioContext.DeleteUnitImmediately(au.ObjectID, ScenEditAction: true, "Deleted via Lua command.", null, RegisterAsLosses: false);
		}
	}

	[DoNotPrune]
	public bool RTB(bool value)
	{
		bool result = false;
		if (!value)
		{
			switch (base.type)
			{
			case "Aircraft":
				au.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				break;
			case "Ship":
			case "Submarine":
				au.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				break;
			}
		}
		else
		{
			switch (base.type)
			{
			case "Aircraft":
				if (au.AirOps != null)
				{
					result = ((Aircraft)au).AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
				}
				break;
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					result = au.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_Manual, GroupMembersRTB: false, ActiveUnit._ActiveUnitStatus.Unassigned, DetachFromGroup: true, ClearPlottedCourse: true);
				}
				break;
			}
		}
		return result;
	}

	[DoNotPrune]
	public bool Launch(bool value)
	{
		bool result = false;
		if (!value)
		{
			switch (base.type)
			{
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft aircraft = (Aircraft)au;
				if (aircraft.AirOps.IsTakingOff)
				{
					aircraft.AirOps.AttemptToPark(NormalLandingSequence: true, RearmRefuel: false, AbortLaunch: true);
					int num;
					if (aircraft.Navigator.HasFlight)
					{
						((ActiveUnit_Navigator)aircraft.Navigator).get_Flight(HierarchySearch: true).set_Status(ScenarioContext, Mission._FlightStatus.None);
						num = 1;
					}
					else
					{
						num = 1;
					}
					result = (byte)num != 0;
				}
				break;
			}
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null && au.DockingOps.IsDeploying)
				{
					au.DockingOps.AttemptToStartDocking(au.DockingOps.CurrentHostUnit, CancelDeployment: true);
					result = true;
				}
				break;
			}
			if (au.IsGroupMember())
			{
				au.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
			}
		}
		else
		{
			switch (base.type)
			{
			case "Aircraft":
			{
				Aircraft aircraft2 = (Aircraft)au;
				if (au.AirOps != null && aircraft2.IsReadyForTakeOff())
				{
					aircraft2.AirOps.AttemptToMoveToRunway(ActualAirlaunchPreparation: true);
					result = true;
				}
				break;
			}
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null && au.IsParkedAndReady())
				{
					au.DockingOps.Condition = ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway;
					result = true;
				}
				break;
			}
		}
		return result;
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "unit {\r\n type = '" + base.type + "', \r\n subtype = '" + base.subtype + "', \r\n name = '" + base.name + "', \r\n side = '" + base.side + "', \r\n guid = '" + base.guid.ToString() + "', \r\n class = '" + base.classname.ToString() + "', \r\n proficiency = '" + proficiency + "', \r\n latitude = '" + latitude + "', \r\n longitude = '" + longitude + "', \r\n altitude = '" + altitude.ToString() + "', \r\n heading = '" + heading.ToString() + "', \r\n speed = '" + speed.ToString() + "', \r\n throttle = '" + ((ActiveUnit.Throttle)Conversions.ToByte(throttle)/*cast due to .constrained prefix*/).ToString() + "', \r\n autodetectable = '" + autodetectable + "', \r\n";
		if (@base != null)
		{
			text = text + " base = '" + @base.name + "', \r\n";
		}
		if ((group != null) & !au.IsGroup)
		{
			LuaWrapper_Group luaWrapper_Group = (LuaWrapper_Group)group;
			text = text + " group = '" + luaWrapper_Group.name + "', \r\n";
		}
		if (base.mission != null)
		{
			LuaWrapper_Mission luaWrapper_Mission = (LuaWrapper_Mission)base.mission;
			text = text + " mission = '" + luaWrapper_Mission.name + "', \r\n";
		}
		if (Operators.CompareString(base.type, "None", false) != 0)
		{
			try
			{
				if (au.Mounts != null)
				{
					text = text + " mounts = '" + au.Mounts.Count + "', \r\n";
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			try
			{
				if (au.TotalMagazines != null)
				{
					text = text + " magazines = '" + au.TotalMagazines.Count() + "', \r\n";
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		text = text + " unitstate = '" + au.Status.ToString() + "', \r\n";
		text = text + " fuelstate = '" + au.FuelState.ToString() + "', \r\n";
		text = text + " weaponstate = '" + au.WeaponState.ToString() + "', \r\n";
		text = text + " AllowMultiMission = '" + au.AllowMultiMission + "', \r\n";
		text = text + " AssignedMissionsQueue = '" + base.AssignedMissionsQueue.ToString() + "', \r\n";
		text = text + " Decoy = '" + au.IsDecoy + "', \r\n";
		if (au.IsSatellite)
		{
			text = text + " Launch date = '" + (string)base.SatelliteData["launchDate"] + "', \r\n";
			if (((Satellite)au).DeOrbitDate.Year > 1900)
			{
				text = text + " De-orbit date = '" + (string)base.SatelliteData["deorbitDate"] + "', \r\n";
			}
			text = text + " Spacecraft = '" + (string)base.SatelliteData["spacecraft"] + "', \r\n";
		}
		return text + "}";
	}

	public LuaWrapper_Cargo createUnitCargo(int CargoType, int int_0, string customName = "")
	{
		bool flag = !string.IsNullOrEmpty(customName);
		string text = customName;
		ICargoHost cargoHost = (ICargoHost)au;
		Cargo cargo = null;
		if (cargoHost == null)
		{
			return null;
		}
		switch (CargoType)
		{
		case 1:
		{
			Mount mount = DBFunctions.GetMount(int_0, ref ScenarioContext);
			if (cargoHost.CanLoad(mount))
			{
				cargo = new Cargo(au, mount);
				cargoHost.Add(cargo);
			}
			goto default;
		}
		case 2:
		{
			Vehicle vehicle = null;
			if (flag)
			{
				vehicle = ScenarioContext.AddNewVehicle(au.get_UnitSide(SetSideOnly: false), int_0, customName, au.get_Longitude((GlobalVariables.BooleanObject)null), au.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
			}
			else
			{
				SQLiteConnection theConn = ScenarioContext.DBConnection;
				text = DBFunctions.GetVehicleName(int_0, ref theConn);
				text = text + " #" + Conversions.ToString(ScenarioContext.UnitsAutoIncrement);
				vehicle = ScenarioContext.AddNewVehicle(au.get_UnitSide(SetSideOnly: false), int_0, text, au.get_Longitude((GlobalVariables.BooleanObject)null), au.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
			}
			if (vehicle != null)
			{
				bool num = cargoHost.CanLoad(vehicle);
				bool flag2 = cargoHost.CanTow(vehicle);
				if (!num && !flag2)
				{
					ScenarioContext.DeleteUnitImmediately(vehicle.ObjectID, ScenEditAction: true, "Failed to load into cargo.", null, RegisterAsLosses: false);
				}
				else
				{
					cargo = new Cargo(au, vehicle);
					if (flag2)
					{
						cargo.StorageType = Cargo.CargoStorageType.TowedExternal;
					}
					vehicle.DockingOps.LoadIntoCargo(au);
					cargoHost.Add(cargo);
				}
				goto default;
			}
			return null;
		}
		case 3:
		{
			Facility facility = null;
			if (flag)
			{
				facility = ScenarioContext.AddNewFacility(au.get_UnitSide(SetSideOnly: false), int_0, customName, au.get_Longitude((GlobalVariables.BooleanObject)null), au.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
			}
			else
			{
				SQLiteConnection theConn = ScenarioContext.DBConnection;
				text = DBFunctions.GetFacilityName(int_0, ref theConn);
				text = text + " #" + Conversions.ToString(ScenarioContext.UnitsAutoIncrement);
				facility = ScenarioContext.AddNewFacility(au.get_UnitSide(SetSideOnly: false), int_0, text, au.get_Longitude((GlobalVariables.BooleanObject)null), au.get_Latitude((GlobalVariables.BooleanObject)null), IgnoreElevationCheck: true);
			}
			if (facility == null)
			{
				return null;
			}
			if (cargoHost.CanLoad(facility))
			{
				cargo = new Cargo(au, facility);
				facility.DockingOps.LoadIntoCargo(au);
				cargoHost.Add(cargo);
			}
			else
			{
				ScenarioContext.DeleteUnitImmediately(facility.ObjectID, ScenEditAction: true, "Failed to load into cargo.", null, RegisterAsLosses: false);
			}
			goto default;
		}
		case 4:
		{
			CargoContainer cargoContainer = DBFunctions.GetCargoContainer(int_0, ref ScenarioContext);
			if (cargoHost.CanLoad(cargoContainer))
			{
				cargo = new Cargo(au, cargoContainer, cargoHost);
				cargoHost.Add(cargo);
			}
			goto default;
		}
		case 6:
		{
			Aircraft aircraft = null;
			if (!flag)
			{
				SQLiteConnection theConn = ScenarioContext.DBConnection;
				text = DBFunctions.GetFacilityName(int_0, ref theConn);
				text = text + " #" + Conversions.ToString(ScenarioContext.UnitsAutoIncrement);
				aircraft = ScenarioContext.AddNewAircraft(au.get_UnitSide(SetSideOnly: false), text, au.get_Longitude((GlobalVariables.BooleanObject)null), au.get_Latitude((GlobalVariables.BooleanObject)null), int_0, 0, au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, null, IgnoreOperationalCeiling: true);
			}
			else
			{
				aircraft = ScenarioContext.AddNewAircraft(au.get_UnitSide(SetSideOnly: false), customName, au.get_Longitude((GlobalVariables.BooleanObject)null), au.get_Latitude((GlobalVariables.BooleanObject)null), int_0, 0, au.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Module_Unit.Unit.RemoteSimEntityTypeEnum.Local, null, IgnoreOperationalCeiling: true);
			}
			if (aircraft != null)
			{
				if (cargoHost.CanLoad(aircraft))
				{
					cargo = new Cargo(au, aircraft);
					aircraft.DockingOps.LoadIntoCargo(au);
					cargoHost.Add(cargo);
				}
				else
				{
					ScenarioContext.DeleteUnitImmediately(aircraft.ObjectID, ScenEditAction: true, "Failed to load into cargo.", null, RegisterAsLosses: false);
				}
				goto default;
			}
			return null;
		}
		default:
			if (cargo == null)
			{
				return null;
			}
			return new LuaWrapper_Cargo(cargo, ScenarioContext);
		}
	}

	public bool deleteUnitCargo(string cargoGuid)
	{
		Cargo[] onboardCargo = au.OnboardCargo;
		int num = 0;
		Cargo cargo;
		while (true)
		{
			if (num < onboardCargo.Length)
			{
				cargo = onboardCargo[num];
				if (Operators.CompareString(cargo.CargoObjectID, cargoGuid, false) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		ArrayExtensions.Remove(ref au.OnboardCargo, cargo);
		ActiveUnit cargoObjectActiveUnit = cargo.CargoObjectActiveUnit;
		int result;
		if (cargoObjectActiveUnit != null)
		{
			ScenarioContext.DeleteUnitImmediately(cargoObjectActiveUnit.ObjectID, ScenEditAction: true, "Unit was deleted while editing cargo.", null, RegisterAsLosses: false);
			result = 1;
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}

	public LuaWrapper_Device_Sensor GetSensor(string theSensorID)
	{
		Sensor[] sensors_Cached = au.Sensors_Cached;
		int num = 0;
		Sensor sensor;
		while (true)
		{
			if (num < sensors_Cached.Length)
			{
				sensor = sensors_Cached[num];
				if (Operators.CompareString(sensor.ObjectID, theSensorID, false) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return null;
		}
		return new LuaWrapper_Device_Sensor(sensor, ScenarioContext);
	}

	[DoNotPrune]
	public LuaTable ReplenishUnit(object method = null)
	{
		string Results = "";
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		ActiveUnit activeUnit = null;
		List<Mission> list = null;
		bool flag = false;
		try
		{
			if (method == null)
			{
				if (au.IsActiveUnit && (object)au.GetType() != typeof(Weapon))
				{
					Scenario scenarioContext = ScenarioContext;
					ActiveUnit theU = au;
					string ResultCategory = null;
					CoreClientCode.RefuelIfPossible_Core(scenarioContext, (Module_Unit.Unit)theU, (ActiveUnit)null, (List<Mission>)null, ref Results, ref ResultCategory);
					flag = string.IsNullOrEmpty(Results);
				}
			}
			else if (method is LuaTable)
			{
				Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(((LuaTable)method).GetEnumerator());
				if (dictionary.ContainsKey("TANKER"))
				{
					activeUnit = PrivateMethods.smethod_1(Conversions.ToString(dictionary["TANKER"]), ScenarioContext);
				}
				if (dictionary.ContainsKey("MISSIONS"))
				{
					list = new List<Mission>();
					List<object> list2 = LuaUtility.ToArray(((LuaTable)dictionary["MISSIONS"]).GetEnumerator());
					foreach (object item in list2)
					{
						Mission mission = LuaMission.ValidateMissionBySceanrio(Conversions.ToString(RuntimeHelpers.GetObjectValue(item)), ScenarioContext);
						if (mission != null)
						{
							list.Add(mission);
						}
					}
				}
				if (au.IsActiveUnit && (object)au.GetType() != typeof(Weapon))
				{
					Scenario scenarioContext2 = ScenarioContext;
					ActiveUnit theU2 = au;
					ActiveUnit theSelectedTanker = activeUnit;
					List<Mission> theSelectedMissions = list;
					string ResultCategory = null;
					CoreClientCode.RefuelIfPossible_Core(scenarioContext2, theU2, theSelectedTanker, theSelectedMissions, ref Results, ref ResultCategory);
					flag = string.IsNullOrEmpty(Results);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		if (au.IsActiveUnit && (object)au.GetType() == typeof(Weapon))
		{
			Results = "Active unit is a weapon and does not replenish.";
		}
		luaTable["success"] = flag;
		luaTable["reason"] = Results;
		return luaTable;
	}

	[DoNotPrune]
	public bool InterceptContact(string theContactID)
	{
		try
		{
			Contact contact = PrivateMethods.ValidateContactBySceanrio(theContactID, ScenarioContext);
			Side side = au.get_UnitSide(SetSideOnly: false);
			bool result = false;
			if (contact != null && side != null)
			{
				if ((object)contact.GetType() == typeof(Contact))
				{
					if (contact.Type != Contact_Base.ContactType.AirBase && contact.Type != Contact_Base.ContactType.Installation && contact.Type != Contact_Base.ContactType.NavalBase && contact.Type != Contact_Base.ContactType.MobileGroup)
					{
						Module_Unit.Unit unit = au;
						string ReasonWhyNot = null;
						if (GameGeneral.CanIssueOrdersToThisUnit(side, unit, IncludeSonobuoys: false, ref ReasonWhyNot, ""))
						{
							ActiveUnit theAU = au;
							ActiveUnit_AI aI = theAU.AI;
							float theAltitude = theAU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							float currentHeading = theAU.CurrentHeading;
							float? safetyMargin = 0f;
							bool BingoFuelEndurance = true;
							if (aI.CanInterceptTarget(contact, null, theAltitude, null, currentHeading, ActiveUnit.Throttle.Full, safetyMargin, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
							{
								theAU.AI.ClearAllTargets(ref theAU);
								theAU.Navigator.ClearPlottedCourse();
								theAU.AI.TargetThisContact(contact, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted);
								result = true;
							}
						}
						else if (unit != null && unit.IsActiveUnit)
						{
							((ActiveUnit)unit).AddMessage(unit.Name + " cannot intercept (unable to issue orders to unit)", "Cannot order unit", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(unit.get_Longitude((GlobalVariables.BooleanObject)null), unit.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					else if (!Information.IsNothing((object)contact.ActualUnit))
					{
						for (int i = side.Contacts_List.Count - 1; i >= 0; i += -1)
						{
							Contact contact2 = side.Contacts_List[i];
							if (Information.IsNothing((object)contact2.ActualUnit) || contact2.ActualUnit.IsGroup || contact2.ActualUnit.get_ParentGroup(UsingMissionPlanner: false) != contact.ActualUnit)
							{
								continue;
							}
							Module_Unit.Unit unit2 = au;
							string ReasonWhyNot = null;
							if (GameGeneral.CanIssueOrdersToThisUnit(side, unit2, IncludeSonobuoys: false, ref ReasonWhyNot, ""))
							{
								ActiveUnit theAU2 = au;
								ActiveUnit_AI aI2 = theAU2.AI;
								float theAltitude2 = theAU2.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								float currentHeading2 = theAU2.CurrentHeading;
								float? safetyMargin2 = 0f;
								bool BingoFuelEndurance = true;
								if (aI2.CanInterceptTarget(contact, null, theAltitude2, null, currentHeading2, ActiveUnit.Throttle.Full, safetyMargin2, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
								{
									theAU2.AI.ClearAllTargets(ref theAU2);
									theAU2.Navigator.ClearPlottedCourse();
									theAU2.AI.TargetThisContact(contact2, AddedManually: false, PriorityTarget: false, ActiveUnit_AI.TargetingEntry._TargetingBehavior.ManualTargeted);
									result = true;
								}
							}
							else
							{
								((ActiveUnit)unit2).AddMessage(unit2.Name + " cannot intercept (unable to issue orders to unit)", "Cannot order unit", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(unit2.get_Longitude((GlobalVariables.BooleanObject)null), unit2.get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
					}
				}
				return result;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	static LuaWrapper_ActiveUnit_SE()
	{
		Class72.smethod_20();
	}
}
