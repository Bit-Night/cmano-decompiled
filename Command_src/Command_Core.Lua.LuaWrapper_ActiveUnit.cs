using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;
using ThreadSafeCollections;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPruneType]
[DoNotPrune]
public class LuaWrapper_ActiveUnit
{
	[CompilerGenerated]
	internal sealed class _Closure$__163-0
	{
		public Cargo $VB$Local_theM;

		public _Closure$__163-0(_Closure$__163-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theM = arg0.$VB$Local_theM;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0((int, Cargo) x)
		{
			if (x.Item2.CargoObjectDBID == $VB$Local_theM.CargoObjectDBID)
			{
				return $VB$Local_theM.CurrentType == Cargo.CargoObjectType.Mount;
			}
			return false;
		}

		static _Closure$__163-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__216-0
	{
		public object $VB$Local_o;

		public Func<ReferencePoint, bool> $I0;

		public Func<ReferencePoint, bool> $I1;

		public _Closure$__216-0(_Closure$__216-0 arg0)
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
			if (!string.Equals(s.Name, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(s.ObjectID, $VB$Local_o.ToString(), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}

		static _Closure$__216-0()
		{
			Class72.smethod_20();
		}
	}

	internal ActiveUnit au;

	protected Scenario ScenarioContext;

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
	public LuaWrapper_Doctrine doctrine
	{
		get
		{
			if (au.Doctrine != null)
			{
				return new LuaWrapper_Doctrine(au.Doctrine, ScenarioContext);
			}
			return null;
		}
	}

	[DoNotPrune]
	public bool AllowMultiMission
	{
		get
		{
			return au.AllowMultiMission;
		}
		set
		{
			au.AllowMultiMission = value;
		}
	}

	[DoNotPrune]
	public bool UseCustomIntermittentEmissionOnly
	{
		get
		{
			return au.Sensory.GetIntermittentEmission().UseCustomPresetOnly;
		}
		set
		{
			au.Sensory.GetIntermittentEmission().UseCustomPresetOnly = value;
		}
	}

	[DoNotPrune]
	public LuaTable AssignedMissionsQueue
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<Mission> list = new List<Mission>();
			list = au.AssignedMissionsQueue.Values.ToList();
			int num = 1;
			foreach (Mission item in list)
			{
				luaTable[num] = item.ObjectID;
				num++;
			}
			return luaTable;
		}
		set
		{
			List<object> list = LuaUtility.ToArray(value.GetEnumerator());
			foreach (object item in list)
			{
				string text = Conversions.ToString(RuntimeHelpers.GetObjectValue(item));
				Mission mission = LuaMission.ValidateMissionBySceanrio(text, ScenarioContext);
				if (mission != null && Operators.CompareString(mission.ObjectID, text, false) == 0)
				{
					au.AssignMissionInQueue(mission);
				}
			}
		}
	}

	[DoNotPrune]
	public object __obj => au;

	[DoNotPrune]
	public bool IsMine
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsMine;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsUnguidedBallisticWeapon
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsUnguidedBallisticWeapon;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsBallisticMissile
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsBallisticMissile;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsDecoy
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsDecoy;
			}
			return au.IsDecoy;
		}
	}

	[DoNotPrune]
	public bool IsNuke
	{
		get
		{
			if (au.IsWeapon)
			{
				return ((Weapon)au).IsNuke.Value;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsSinking
	{
		get
		{
			bool result = default(bool);
			if (au.IsShip && ((Ship)au).IsSinking)
			{
				return result;
			}
			return false;
		}
	}

	[DoNotPrune]
	public bool IsDestroyed => false;

	[DoNotPrune]
	public bool WasPickedUp
	{
		get
		{
			if (au.IsActiveUnit)
			{
				return au.IsBeingPickedUp;
			}
			return false;
		}
	}

	[DoNotPrune]
	public string pickedUpBy
	{
		get
		{
			if (au.PickUpUnit == null)
			{
				return null;
			}
			return au.PickUpUnit.ObjectID;
		}
	}

	[DoNotPrune]
	public string subtype
	{
		get
		{
			if ((int)au.UnitType > 0)
			{
				return au.SubType.ToString();
			}
			return "None";
		}
	}

	[DoNotPrune]
	public string type
	{
		get
		{
			if ((int)au.UnitType <= 0)
			{
				if (!au.IsGroup)
				{
					return "None";
				}
				return "Group";
			}
			return au.UnitType.ToString();
		}
	}

	[DoNotPrune]
	public int typeN
	{
		get
		{
			if ((int)au.UnitType > 0)
			{
				return (int)au.UnitType;
			}
			return 0;
		}
	}

	[DoNotPrune]
	public int SubTypeN
	{
		get
		{
			if (au.SubType > 0)
			{
				return au.SubType;
			}
			return 0;
		}
	}

	public string category
	{
		get
		{
			switch (type)
			{
			case "Submarine":
				return ((Submarine)au).Category.ToString("d");
			case "Satellite":
				return ((Satellite)au).Category.ToString("d");
			default:
				if (au.IsGroup)
				{
					return "Group";
				}
				return null;
			case "Facility":
				if (!au.IsFixedFacility)
				{
					return ((Facility)au).MobileUnitCategory().ToString("d");
				}
				return ((Facility)au).Category.ToString("d");
			case "Aircraft":
				return ((Aircraft)au).Category.ToString("d");
			case "Ship":
				return ((Ship)au).Category.ToString("d");
			}
		}
	}

	[DoNotPrune]
	public int dbid => au.DBID;

	[DoNotPrune]
	public string name
	{
		get
		{
			return au.Name;
		}
		set
		{
			au.Name = value;
		}
	}

	[DoNotPrune]
	public virtual double latitude
	{
		get
		{
			return au.get_Latitude((GlobalVariables.BooleanObject)null);
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual double longitude
	{
		get
		{
			return au.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual double SettledTime
	{
		get
		{
			return au.SettledTime;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual bool autodetectable
	{
		get
		{
			return au.get_IsAutoDetectable((Side)null);
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public string guid => au.ObjectID;

	[DoNotPrune]
	public string side
	{
		get
		{
			if (au.IsWeapon)
			{
				if (((Weapon)au).FiringParent == null)
				{
					return null;
				}
				return ((Weapon)au).FiringParent.get_UnitSide(SetSideOnly: false).Name;
			}
			return au.get_UnitSide(SetSideOnly: false).Name;
		}
	}

	[DoNotPrune]
	public object mission
	{
		get
		{
			if (au.ActiveMissionOrPackage() != null)
			{
				Mission theMission = au.ActiveMissionOrPackage();
				return new LuaWrapper_Mission(theMission, ScenarioContext);
			}
			return null;
		}
		set
		{
			if (!(value is string))
			{
				throw new LuaError("Please provide the mission's name.");
			}
			PrivateMethods.ScenEdit_AssignUnitToMission(au.ObjectID, Conversions.ToString(value), ScenarioContext, null, Escort: false, MissionPlanner: false);
		}
	}

	[DoNotPrune]
	public bool holdposition
	{
		get
		{
			return au.AI.HoldPosition;
		}
		set
		{
			au.AI.HoldPosition = value;
		}
	}

	[DoNotPrune]
	public object holdfire
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Doctrine doctrine = au.Doctrine;
			if (!doctrine.WeaponControlStatus_Air_Inherits())
			{
				luaTable["Air"] = ((byte)doctrine.get_WeaponControlStatus_Air(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false).Value).ToString();
			}
			else
			{
				luaTable["Air"] = "Inherit";
			}
			if (!doctrine.WeaponControlStatus_Surface_Inherits())
			{
				luaTable["Surface"] = ((byte)doctrine.get_WeaponControlStatus_Surface(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false).Value).ToString();
			}
			else
			{
				luaTable["Surface"] = "Inherit";
			}
			if (!doctrine.WeaponControlStatus_Submarine_Inherits())
			{
				luaTable["Subsurface"] = ((byte)doctrine.get_WeaponControlStatus_Submarine(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false).Value).ToString();
			}
			else
			{
				luaTable["SubSurface"] = "Inherit";
			}
			if (doctrine.WeaponControlStatus_Land_Inherits())
			{
				luaTable["Land"] = "Inherit";
			}
			else
			{
				luaTable["Land"] = ((byte)doctrine.get_WeaponControlStatus_Land(ScenarioContext, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false).Value).ToString();
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("This is a Doctrine property for a normal active unit. Please use SetDoctrine instead.");
		}
	}

	[DoNotPrune]
	public virtual object group
	{
		get
		{
			if ((au.get_ParentGroup(UsingMissionPlanner: false) != null) | au.IsGroup)
			{
				if (au.get_ParentGroup(UsingMissionPlanner: false) == null)
				{
					return new LuaWrapper_Group((Group)au, ScenarioContext);
				}
				return new LuaWrapper_Group(au.get_ParentGroup(UsingMissionPlanner: false), ScenarioContext);
			}
			return null;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual object altitude
	{
		get
		{
			return au.get_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null);
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public object airbornetime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return Misc.TimeString((long)Math.Round(((Aircraft)au).AirborneTime), 0, ReturnNo: false, ReturnZero: true);
			}
			return null;
		}
	}

	[DoNotPrune]
	public object airbornetime_v
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return (long)Math.Round(((Aircraft)au).AirborneTime);
			}
			return null;
		}
	}

	public object timeunderway
	{
		get
		{
			object result;
			try
			{
				result = (((object)au.GetType() != typeof(Aircraft)) ? Misc.TimeString((long)Math.Round(au.TimeUnderway), 0, ReturnNo: false, ReturnZero: true) : Misc.TimeString((long)Math.Round(((Aircraft)au).AirborneTime), 0, ReturnNo: false, ReturnZero: true));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	[DoNotPrune]
	public object timeunderway_v
	{
		get
		{
			object result;
			try
			{
				result = (((object)au.GetType() != typeof(Aircraft)) ? ((object)(long)Math.Round(au.TimeUnderway)) : ((object)(long)Math.Round(((Aircraft)au).AirborneTime)));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	[DoNotPrune]
	public object readytime
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				return Misc.TimeString((long)Math.Round(((Aircraft)au).AirOps.ConditionTimer), 0, ReturnNo: false, ReturnZero: true);
			}
			if (!Information.IsNothing((object)au.DockingOps))
			{
				return Misc.TimeString((long)Math.Round(au.DockingOps.ConditionTimer), 0, ReturnNo: false, ReturnZero: true);
			}
			return null;
		}
	}

	[DoNotPrune]
	public object loadoutdbid
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (Information.IsNothing((object)((Aircraft)au).Loadout))
				{
					return 0;
				}
				return ((Aircraft)au).Loadout.DBID;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object loadout
	{
		get
		{
			if ((object)au.GetType() == typeof(Aircraft))
			{
				if (!Information.IsNothing((object)((Aircraft)au).Loadout))
				{
					return new LuaWrapper_Loadout(((Aircraft)au).Loadout, ScenarioContext);
				}
				return null;
			}
			return null;
		}
	}

	[DoNotPrune]
	public virtual object speed
	{
		get
		{
			return au.CurrentSpeed;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual object throttle
	{
		get
		{
			return au.ThrottleSetting;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaTable damage
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			ActiveUnit_Damage activeUnit_Damage = au.Damage;
			float damagePercent = au.Damage.DamagePercent;
			LuaUtility.FromDict(new Dictionary<string, object>
			{
				{
					"DP",
					au.get_DamagePts(ScenEditAction: false, (Weapon)null)
				},
				{
					"FLOOD",
					activeUnit_Damage.FloodIntensity.ToString()
				},
				{
					"FIRES",
					activeUnit_Damage.FireIntensity.ToString()
				},
				{
					"STARTDP",
					au.InitialDP.ToString()
				},
				{
					"DP_PERCENT",
					au._OldDamagePercent.ToString()
				},
				{
					"DP_PERCENT_NOW",
					damagePercent.ToString()
				}
			}, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable ascontact
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Side[] sides_ReadOnly = au.ParentScen.Sides_ReadOnly;
			foreach (Side side in sides_ReadOnly)
			{
				if (!Information.IsNothing((object)side) && (object)side != this.side)
				{
					foreach (Contact contacts_ in side.Contacts_List)
					{
						if (Operators.CompareString(contacts_.ActualUnit.ObjectID, au.ObjectID, false) == 0)
						{
							LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
							luaTable2["side"] = side.ObjectID;
							luaTable2["guid"] = contacts_.ObjectID;
							luaTable2["name"] = contacts_.Name;
							luaTable[luaTable.Keys.Count + 1] = luaTable2;
						}
					}
				}
				foreach (string key in side.NewContactsQueue.Keys)
				{
					if (!side.Contacts_List.Contains(side.NewContactsQueue[key]))
					{
						Contact contact = side.NewContactsQueue[key];
						LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
						luaTable3["side"] = side.ObjectID;
						luaTable3["guid"] = contact.ObjectID;
						luaTable3["name"] = contact.Name;
						luaTable[luaTable.Keys.Count + 1] = luaTable3;
					}
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public virtual object desiredHeading
	{
		get
		{
			return au.DesiredHeading;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.set_DesiredHeading(ActiveUnit.TurnRate.Max, result);
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
	public virtual object desiredAltitude
	{
		get
		{
			return au.DesiredAltitude;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.DesiredAltitude = result;
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
	public virtual object desiredSpeed
	{
		get
		{
			return au.DesiredSpeed;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.DesiredSpeed = result;
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
	public float desiredRoll
	{
		get
		{
			return au.DesiredRoll;
		}
		set
		{
			float result = 0f;
			try
			{
				if (float.TryParse(Conversions.ToString(value), out result))
				{
					au.DesiredRoll = result;
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
	public float desiredPitch
	{
		get
		{
			if (au.SupportsAttitude_Pitch)
			{
				return au.DesiredPitch;
			}
			return 0f;
		}
		set
		{
			float result = 0f;
			try
			{
				if (au.SupportsAttitude_Pitch && float.TryParse(Conversions.ToString(value), out result))
				{
					au.DesiredPitch = result;
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
	public virtual object heading
	{
		get
		{
			return au.CurrentHeading;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaTable weather
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Weather.WeatherProfile weatherAtMyLocation = au.WeatherAtMyLocation;
			luaTable["temp"] = weatherAtMyLocation.get_ActualTempAtSL(Weather.TTimeOfDayType.tod_Day);
			luaTable["rainfall"] = weatherAtMyLocation.RainfallRate;
			luaTable["undercloud"] = weatherAtMyLocation.FractionUnderRain;
			luaTable["seastate"] = weatherAtMyLocation.SeaState;
			return luaTable;
		}
	}

	[DoNotPrune]
	public virtual string proficiency
	{
		get
		{
			string result = null;
			if (au.IsWeapon)
			{
				return null;
			}
			GlobalVariables.ProficiencyLevel? proficiencyLevel = au.Proficiency;
			int? num = (int?)proficiencyLevel;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) != true)
			{
				num = (int?)proficiencyLevel;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
				{
					num = (int?)proficiencyLevel;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
					{
						num = (int?)proficiencyLevel;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
						{
							num = (int?)proficiencyLevel;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
							{
								result = "Ace";
							}
						}
						else
						{
							result = "Veteran";
						}
					}
					else
					{
						result = "Regular";
					}
				}
				else
				{
					result = "Cadet";
				}
			}
			else
			{
				result = "Novice";
			}
			return result;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable course
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			Waypoint[] plottedCourse = au.Navigator.PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["latitude"] = waypoint.Latitude;
				luaTable2["longitude"] = waypoint.Longitude;
				luaTable[num] = luaTable2;
				num++;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public object course_distance
	{
		get
		{
			if (au.Navigator.HasPlottedCourse())
			{
				return au.Navigator.GetPlottedCourseDistance(au.Navigator.PlottedCourse);
			}
			return null;
		}
	}

	[DoNotPrune]
	public virtual LuaTable fuel
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
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaTable fuels
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (FuelRec item in au.Fuel_ReadOnly)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["current"] = item.CurrentQuantity;
				luaTable2["max"] = item.MaxQuantity;
				luaTable2["name"] = item.FuelType.ToString();
				luaTable2["type"] = Convert.ToInt32((short)item.FuelType);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public virtual LuaTable formation
	{
		get
		{
			if (!Information.IsNothing((object)au.get_ParentGroup(UsingMissionPlanner: false)))
			{
				ActiveUnit groupLead = au.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				ActiveUnit_Navigator.FormationStation unitFormationStation = au.Navigator.UnitFormationStation;
				luaTable["guid"] = au.ObjectID;
				luaTable["bearing"] = unitFormationStation.Bearing;
				luaTable["type"] = unitFormationStation.BearingType.ToString();
				luaTable["distance"] = unitFormationStation.Distance;
				luaTable["sprint"] = au.Navigator.SprintDrift.ToString();
				(double, double) tuple = unitFormationStation.get_LatitudeAndLongitude(au, groupLead);
				luaTable["latitude"] = tuple.Item1;
				luaTable["longitude"] = tuple.Item2;
				return luaTable;
			}
			if (!au.IsGroup)
			{
				return null;
			}
			Group obj = (Group)au;
			ActiveUnit groupLead2 = obj.GroupLead;
			LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
			luaTable2["lead"] = groupLead2.ObjectID;
			luaTable2["name"] = obj.LastFormationSet;
			luaTable2["spacing"] = obj.LastFormationSpacing;
			luaTable2["spacing_unit"] = obj.LastFormationSpacingUnits;
			return luaTable2;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable magazines
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			Magazine[] totalMagazines = au.TotalMagazines;
			foreach (Magazine magazine in totalMagazines)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				if (magazine.DBID == 0)
				{
					luaTable2["mag_capacity"] = magazine.Capacity;
					luaTable2["mag_dbid"] = magazine.DBID;
					luaTable2["mag_guid"] = magazine.ObjectID;
					luaTable2["mag_name"] = magazine.Name;
					foreach (WeaponRec weapon in magazine.Weapons)
					{
						LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
						luaTable4["wpn_guid"] = weapon.ObjectID;
						luaTable4["wpn_current"] = weapon.CurrentLoad;
						luaTable4["wpn_maxcap"] = weapon.MaxLoad;
						luaTable4["wpn_default"] = weapon.DefaultLoad;
						luaTable4["wpn_dbid"] = weapon.int_3;
						luaTable4["wpn_name"] = weapon.get_ReferenceWeapon(ScenarioContext).Name;
						luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
					}
					luaTable2["mag_weapons"] = luaTable3;
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
					continue;
				}
				luaTable2["mag_capacity"] = magazine.Capacity;
				luaTable2["mag_dbid"] = magazine.DBID;
				luaTable2["mag_guid"] = magazine.ObjectID;
				luaTable2["mag_name"] = magazine.Name;
				foreach (WeaponRec weapon2 in magazine.Weapons)
				{
					LuaTable luaTable5 = LuaSandBox.Singleton().CreateTable();
					luaTable5["wpn_guid"] = weapon2.ObjectID;
					luaTable5["wpn_current"] = weapon2.CurrentLoad;
					luaTable5["wpn_maxcap"] = weapon2.MaxLoad;
					luaTable5["wpn_default"] = weapon2.DefaultLoad;
					luaTable5["wpn_dbid"] = weapon2.int_3;
					luaTable5["wpn_name"] = weapon2.get_ReferenceWeapon(ScenarioContext).Name;
					luaTable3[luaTable3.Keys.Count + 1] = luaTable5;
				}
				luaTable2["mag_weapons"] = luaTable3;
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable mounts
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Mount mount in au.Mounts)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
				if (mount.DBID == 0)
				{
					continue;
				}
				luaTable2["mount_dbid"] = mount.DBID;
				luaTable2["mount_guid"] = mount.ObjectID;
				luaTable2["mount_name"] = mount.Name;
				luaTable2["mount_status"] = mount.Status.ToString();
				if (mount.Status != PlatformComponent._ComponentStatus.Operational)
				{
					luaTable2["mount_statusR"] = mount.ReasonForInoperative;
					luaTable2["mount_damage"] = mount.DamageSeverity.ToString();
				}
				foreach (WeaponRec mountWeapon in mount.MountWeapons)
				{
					LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
					luaTable4["wpn_guid"] = mountWeapon.ObjectID;
					luaTable4["wpn_current"] = mountWeapon.CurrentLoad;
					luaTable4["wpn_maxcap"] = mountWeapon.MaxLoad;
					luaTable4["wpn_default"] = mountWeapon.DefaultLoad;
					luaTable4["wpn_dbid"] = mountWeapon.int_3;
					luaTable4["wpn_name"] = mountWeapon.get_ReferenceWeapon(ScenarioContext).Name;
					luaTable4["wpn_type"] = (int)DBFunctions.GetWeaponType(mountWeapon.int_3, ScenarioContext);
					luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
				}
				luaTable2["mount_weapons"] = luaTable3;
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable sensors
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
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead.");
		}
	}

	[DoNotPrune]
	public virtual LuaTable airFacilities
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (au.AirFacilities_ReadOnly.Count() == 0)
			{
				return null;
			}
			AirFacility[] airFacilities_ReadOnly = au.AirFacilities_ReadOnly;
			foreach (AirFacility airFacility in airFacilities_ReadOnly)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["air_capacity"] = airFacility.Capacity;
				luaTable2["air_dbid"] = airFacility.DBID;
				luaTable2["air_guid"] = airFacility.ObjectID;
				luaTable2["air_name"] = airFacility.Name;
				luaTable2["air_facility"] = new LuaWrapper_Facility(airFacility, ScenarioContext);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable dockFacilities
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (au.DockFacilities_ReadOnly.Count() == 0)
			{
				return null;
			}
			DockFacility[] dockFacilities_ReadOnly = au.DockFacilities_ReadOnly;
			foreach (DockFacility dockFacility in dockFacilities_ReadOnly)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["dock_capacity"] = (int)dockFacility.Capacity;
				luaTable2["dock_dbid"] = dockFacility.DBID;
				luaTable2["dock_guid"] = dockFacility.ObjectID;
				luaTable2["dock_name"] = dockFacility.Name;
				luaTable2["dock_facility"] = new LuaWrapper_Facility(dockFacility, ScenarioContext);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual LuaTable components
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			PlatformComponent platformComponent = null;
			if (au.Components().Count > 0)
			{
				foreach (PlatformComponent item in au.Components())
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["comp_guid"] = item.ObjectID;
					luaTable2["comp_dbid"] = item.DBID;
					luaTable2["comp_name"] = item.Name;
					luaTable2["comp_type"] = item.GetType().Name;
					luaTable2["comp_status"] = item.Status.ToString();
					if (item.Status != PlatformComponent._ComponentStatus.Operational)
					{
						luaTable2["comp_damage"] = item.DamageSeverity.ToString();
						luaTable2["comp_statusR"] = item.ReasonForInoperative;
					}
					if (item.GetType() == typeof(Cargo))
					{
						luaTable2["comp_name"] = ((Cargo)item).CargoObjectName;
						luaTable2["comp_type"] = (int)((Cargo)item).CurrentType;
						luaTable2["comp_dbid"] = ((Cargo)item).CargoObjectDBID;
						luaTable2["comp_guid"] = ((Cargo)item).CargoObjectID;
					}
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead.");
		}
	}

	[DoNotPrune]
	public LuaTable cargo
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<ActiveUnit> list = new List<ActiveUnit>();
			if (au is Group)
			{
				foreach (ActiveUnit value in ((Group)au).Units.Values)
				{
					if (value.OnboardCargo.Count() > 0)
					{
						list.Add(value);
					}
				}
			}
			else if (au.OnboardCargo.Count() > 0)
			{
				list.Add(au);
			}
			if (list.Count > 0)
			{
				_Closure$__163-0 closure$__163- = default(_Closure$__163-0);
				foreach (ActiveUnit item2 in list)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["name"] = item2.Name;
					luaTable2["guid"] = item2.ObjectID;
					if (item2.OnboardCargo.Count() > 0)
					{
						LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
						List<(int, Cargo)> list2 = new List<(int, Cargo)>();
						Cargo[] onboardCargo = item2.OnboardCargo;
						for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
						{
							closure$__163- = new _Closure$__163-0(closure$__163-);
							closure$__163-.$VB$Local_theM = onboardCargo[i];
							int num = list2.FindIndex(closure$__163-._Lambda$__0);
							if (num == -1)
							{
								list2.Add((1, closure$__163-.$VB$Local_theM));
								continue;
							}
							int item = list2[num].Item1 + 1;
							list2[num] = (item, closure$__163-.$VB$Local_theM);
						}
						foreach (var item3 in list2)
						{
							LuaTable luaTable4 = LuaSandBox.Singleton().CreateTable();
							luaTable4["name"] = item3.Item2.CargoObjectName;
							luaTable4["Type"] = (int)item3.Item2.CurrentType;
							luaTable4["dbid"] = item3.Item2.CargoObjectDBID;
							luaTable4["guid"] = item3.Item2.CargoObjectID;
							luaTable4["status"] = item3.Item2.CargoObjectStatus.ToString();
							luaTable4["area"] = item3.Item2.RequiredArea;
							luaTable4["crew"] = item3.Item2.RequiredCrewSpace;
							luaTable4["mass"] = item3.Item2.RequiredMass;
							luaTable4["quantity"] = item3.Item1;
							if (item3.Item2.CargoObjectStatus != PlatformComponent._ComponentStatus.Operational)
							{
								luaTable4["damage"] = item3.Item2.CargoObjectDamageSeverity.ToString();
								luaTable4["statusR"] = item3.Item2.CargoObjectReasonForInoperative;
							}
							luaTable3[luaTable3.Keys.Count + 1] = luaTable4;
						}
						luaTable2["cargo"] = luaTable3;
					}
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public string old_condition
	{
		get
		{
			switch (type)
			{
			case "Aircraft":
				if (au.AirOps != null)
				{
					return ((Aircraft_AirOps)au.AirOps).OldCondition.ToString();
				}
				break;
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					return au.DockingOps.OldCondition.ToString();
				}
				break;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string condition
	{
		get
		{
			switch (type)
			{
			case "Aircraft":
				if (au.AirOps != null)
				{
					return ((Aircraft_AirOps)au.AirOps).ConditionString;
				}
				break;
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					return au.DockingOps.ConditionString;
				}
				break;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string condition_v
	{
		get
		{
			switch (type)
			{
			case "Aircraft":
				if (au.AirOps != null)
				{
					return ((Aircraft_AirOps)au.AirOps).Condition.ToString();
				}
				break;
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					return au.DockingOps.Condition.ToString();
				}
				break;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string unitstate => au.Status.ToString();

	[DoNotPrune]
	public string fuelstate => au.FuelState.ToString();

	[DoNotPrune]
	public string weaponstate => au.WeaponState.ToString();

	[DoNotPrune]
	public virtual object manualSpeed
	{
		get
		{
			return au.Kinematics.DesiredSpeedOverride;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead.");
		}
	}

	[DoNotPrune]
	public virtual LuaTable OODA
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			luaTable["detection"] = au.OODA_Detection;
			luaTable["targeting"] = au.OODA_Targeting;
			luaTable["evasion"] = au.OODA_Evasion;
			return luaTable;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public virtual object manualAltitude
	{
		get
		{
			return au.Kinematics.DesiredAltitudeOverride;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead.");
		}
	}

	[DoNotPrune]
	public object weapon
	{
		get
		{
			if (au.IsWeapon)
			{
				LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
				Weapon obj = (Weapon)au;
				ActiveUnit firingParent = obj.FiringParent;
				Contact primaryTarget = obj.AI.PrimaryTarget;
				bool detonationOccurs = obj.DetonationOccurs;
				if (firingParent != null)
				{
					luaTable["shooter"] = new LuaWrapper_ActiveUnit(firingParent, ScenarioContext);
				}
				if (primaryTarget != null)
				{
					luaTable["contact"] = new LuaWrapper_Contact(primaryTarget, ScenarioContext, au.get_UnitSide(SetSideOnly: false));
				}
				if (detonationOccurs)
				{
					luaTable["detonated"] = detonationOccurs.ToString();
				}
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public virtual LuaWrapper_ActiveUnit @base
	{
		get
		{
			LuaWrapper_ActiveUnit result = null;
			switch (type)
			{
			case "Aircraft":
			{
				if (au.AirOps == null)
				{
					break;
				}
				Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
				if (aircraft_AirOps.CurrentHostUnit == null)
				{
					if (aircraft_AirOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(aircraft_AirOps.ActualDestinationHost, ScenarioContext);
					}
				}
				else
				{
					result = new LuaWrapper_ActiveUnit(aircraft_AirOps.CurrentHostUnit, ScenarioContext);
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
				if (dockingOps.CurrentHostUnit == null)
				{
					if (dockingOps.ActualDestinationHost != null)
					{
						result = new LuaWrapper_ActiveUnit(dockingOps.ActualDestinationHost, ScenarioContext);
					}
				}
				else
				{
					result = new LuaWrapper_ActiveUnit(dockingOps.CurrentHostUnit, ScenarioContext);
				}
				break;
			}
			}
			return result;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_GetUnit/SetUnit).");
		}
	}

	[DoNotPrune]
	public LuaWrapper_Facility hostFacility
	{
		get
		{
			LuaWrapper_Facility result = null;
			switch (type)
			{
			case "Aircraft":
				if (au.AirOps != null)
				{
					Aircraft_AirOps aircraft_AirOps = (Aircraft_AirOps)au.AirOps;
					if (aircraft_AirOps.HostAirFacility != null)
					{
						result = new LuaWrapper_Facility(aircraft_AirOps.HostAirFacility, ScenarioContext);
					}
				}
				break;
			case "Ship":
			case "Submarine":
				if (au.DockingOps != null)
				{
					ActiveUnit_DockingOps dockingOps = au.DockingOps;
					if (dockingOps.HostDockFacility != null)
					{
						result = new LuaWrapper_Facility(dockingOps.HostDockFacility, ScenarioContext);
					}
				}
				break;
			}
			return result;
		}
	}

	[DoNotPrune]
	public LuaTable areaTriggersFired
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			List<string> activeEnterAreaTriggers = au.ActiveEnterAreaTriggers;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 1;
			if (activeEnterAreaTriggers.Count > 0)
			{
				foreach (string item in activeEnterAreaTriggers)
				{
					dictionary.Add(num.ToString(), item);
					num++;
				}
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable areaRemainInTriggersFired
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			TDictionary<string, DateTime> activeRemainAreaTriggers = au.ActiveRemainAreaTriggers;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 1;
			if (activeRemainAreaTriggers.Count > 0)
			{
				foreach (KeyValuePair<string, DateTime> item in activeRemainAreaTriggers)
				{
					dictionary.Add(num.ToString(), item);
					num++;
				}
			}
			LuaUtility.FromDict(dictionary, luaTable);
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable hostedUnits => embarkedUnits;

	[DoNotPrune]
	public LuaTable embarkedUnits
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			if (au.DockingOps != null)
			{
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (dockingOps.EmbarkedBoats_ReadOnly.Count <= 0)
				{
					luaTable["Boats"] = LuaSandBox.Singleton().CreateTable();
				}
				else
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					foreach (ActiveUnit item in dockingOps.EmbarkedBoats_ReadOnly)
					{
						luaTable2[num.ToString()] = item.ObjectID;
						luaTable2[num] = item.ObjectID;
						num++;
					}
					luaTable["Boats"] = luaTable2;
				}
			}
			if (au.AirOps != null)
			{
				num = 1;
				ActiveUnit_AirOps airOps = au.AirOps;
				if (airOps.EmbarkedAircraft_ReadOnly.Count <= 0)
				{
					luaTable["Aircraft"] = LuaSandBox.Singleton().CreateTable();
				}
				else
				{
					LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
					foreach (Aircraft item2 in airOps.EmbarkedAircraft_ReadOnly)
					{
						luaTable3[num.ToString()] = item2.ObjectID;
						luaTable3[num] = item2.ObjectID;
						num++;
					}
					luaTable["Aircraft"] = luaTable3;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public LuaTable assignedUnits
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			if (au.DockingOps != null)
			{
				ActiveUnit_DockingOps dockingOps = au.DockingOps;
				if (dockingOps.AssignedBoats.Count > 0)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					foreach (ActiveUnit assignedBoat in dockingOps.AssignedBoats)
					{
						luaTable2[num] = assignedBoat.ObjectID;
						num++;
					}
					luaTable["Boats"] = luaTable2;
				}
				else
				{
					luaTable["Boats"] = LuaSandBox.Singleton().CreateTable();
				}
			}
			if (au.AirOps != null)
			{
				num = 1;
				ActiveUnit_AirOps airOps = au.AirOps;
				if (airOps.AssignedAircraft.Count > 0)
				{
					LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
					foreach (Aircraft item in airOps.AssignedAircraft)
					{
						luaTable3[num] = item.ObjectID;
						num++;
					}
					luaTable["Aircraft"] = luaTable3;
				}
				else
				{
					luaTable["Aircraft"] = LuaSandBox.Singleton().CreateTable();
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public object targetedBy
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
			{
				Contact[] targets_ReadOnly = value.AI.Targets_ReadOnly;
				for (int i = 0; i < targets_ReadOnly.Length; i = checked(i + 1))
				{
					if (targets_ReadOnly[i].ActualUnit == au && !dictionary.ContainsValue(value.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
					}
				}
				if (!Information.IsNothing((object)value.AI.PrimaryTarget) && value.AI.PrimaryTarget.ActualUnit == au && !dictionary.ContainsValue(value.ObjectID))
				{
					dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
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
	public object firingAt
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
			{
				if (value.IsWeapon)
				{
					Weapon obj = (Weapon)value;
					_ = obj.DBID;
					ActiveUnit firingParent = obj.FiringParent;
					Contact primaryTarget = obj.AI.PrimaryTarget;
					if (!Information.IsNothing((object)primaryTarget) && au == firingParent && !dictionary.ContainsValue(primaryTarget.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), primaryTarget.ObjectID);
					}
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
	public object firedOn
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in ScenarioContext.ActiveUnits.Values)
			{
				if (value.IsWeapon)
				{
					Weapon obj = (Weapon)value;
					_ = obj.DBID;
					ActiveUnit firingParent = obj.FiringParent;
					Contact primaryTarget = obj.AI.PrimaryTarget;
					if (!Information.IsNothing((object)primaryTarget) && au == primaryTarget.ActualUnit && !dictionary.ContainsValue(firingParent.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), firingParent.ObjectID);
					}
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
	public bool isOperating => au.IsOperating();

	[DoNotPrune]
	public bool isEscort => au.AI.IsEscort;

	[DoNotPrune]
	public bool IsLoadedAsCargo => au.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo;

	[DoNotPrune]
	public virtual bool sprintDrift
	{
		get
		{
			if (Information.IsNothing((object)au.Navigator))
			{
				return false;
			}
			return au.Navigator.SprintDrift;
		}
		set
		{
			throw new LuaError("Cannot set this property on a normal active unit. Please use an ActiveUnit_SE entity instead (via ScenEdit_SetUnit).");
		}
	}

	[DoNotPrune]
	public string classname
	{
		get
		{
			if (au.UnitClass == null)
			{
				return "None";
			}
			return au.UnitClass;
		}
	}

	[DoNotPrune]
	public bool outOfComms => !au.CommStuff.IsConnectedToSideNetwork;

	[DoNotPrune]
	public bool jammed
	{
		get
		{
			int result;
			if (au.Sensory.JammerUnitsAreAffectingMe)
			{
				result = 1;
			}
			else
			{
				if (!au.CommStuff.CommJamUnitsAreAffectingMe)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	[DoNotPrune]
	public bool jammer
	{
		get
		{
			if (!ActiveUnit_Sensory.smethod_0(au))
			{
				return false;
			}
			return true;
		}
	}

	[DoNotPrune]
	public float groundSpeed
	{
		get
		{
			if ((au.IsAircraft || au.IsMissile) && au.SupportsAttitude_Pitch)
			{
				return (float)((double)au.CurrentSpeed * Math2.Cosd(au.Attitude_Pitch));
			}
			return 0f;
		}
	}

	[DoNotPrune]
	public float pitch
	{
		get
		{
			if (!au.SupportsAttitude_Pitch)
			{
				return 0f;
			}
			return au.Attitude_Pitch;
		}
	}

	[DoNotPrune]
	public float roll => au.Attitude_Roll;

	[DoNotPrune]
	public int crew
	{
		get
		{
			Type type = au.GetType();
			if (type == typeof(Submarine))
			{
				return ((Submarine)au).Crew;
			}
			if (!(type == typeof(Ship)))
			{
				if (type == typeof(Aircraft))
				{
					return ((Aircraft)au).Crew;
				}
				if (type == typeof(Facility))
				{
					return ((Facility)au).Crew;
				}
				return 0;
			}
			return ((Ship)au).Crew;
		}
	}

	[DoNotPrune]
	public float currentExhaustion => au.Current_Exhaustion;

	[DoNotPrune]
	public float maxExhaustion => au.MAX_Exhaustion;

	[DoNotPrune]
	public LuaTable signature
	{
		get
		{
			if (au.IsWeapon)
			{
				switch (((Weapon)au).Type)
				{
				case Weapon._WeaponType.None:
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.IronBomb:
				case Weapon._WeaponType.Gun:
				case Weapon._WeaponType.TrainingRound:
				case Weapon._WeaponType.Dispenser:
				case Weapon._WeaponType.SensorPod:
				case Weapon._WeaponType.DropTank:
				case Weapon._WeaponType.BuddyStore:
				case Weapon._WeaponType.FerryTank:
				case Weapon._WeaponType.DepthCharge:
				case Weapon._WeaponType.Sonobuoy:
				case Weapon._WeaponType.HeliTowedPackage:
				case Weapon._WeaponType.Laser:
				case Weapon._WeaponType.Microwave:
				case Weapon._WeaponType.Cargo:
				case Weapon._WeaponType.Troops:
				case Weapon._WeaponType.Paratroops:
					return null;
				}
			}
			Loadout loadout = null;
			if (au.IsAircraft)
			{
				loadout = ((Aircraft)au).Loadout;
			}
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (loadout != null)
			{
				luaTable["loadout"] = loadout.DBID;
			}
			try
			{
				XSection[] xSections_ReadOnly = au.XSections_ReadOnly;
				foreach (XSection xSection in xSections_ReadOnly)
				{
					if ((xSection.get_Front(au) == 0f && xSection.get_Side(au) == 0f && xSection.get_Rear(au) == 0f) || xSection.get_Front(au) == -10000f || xSection.get_Side(au) == -10000f || xSection.get_Rear(au) == -10000f)
					{
						continue;
					}
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					LuaTable luaTable3 = LuaSandBox.Singleton().CreateTable();
					luaTable2["type"] = xSection.SignatureType.ToString();
					luaTable2["typeN"] = (int)xSection.SignatureType;
					string value;
					string value2;
					string value3;
					if (xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_VLF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_LF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_MF && xSection.SignatureType != XSection._SignatureType.HullSonar_PassiveOnly_HF && xSection.SignatureType != XSection._SignatureType.ActiveSonar)
					{
						if (xSection.SignatureType != XSection._SignatureType.Visual_Detect && xSection.SignatureType != XSection._SignatureType.Visual_ID && xSection.SignatureType != XSection._SignatureType.IR_Detect && xSection.SignatureType != XSection._SignatureType.IR_ID)
						{
							if (xSection.SignatureType != XSection._SignatureType.Radar_A_D && xSection.SignatureType != XSection._SignatureType.Radar_E_M)
							{
								luaTable2["type"] = null;
								value = "";
								value2 = "";
								value3 = "";
							}
							else
							{
								double num = Math.Pow(10.0, xSection.get_Front(au) / 10f);
								double num2 = Math.Pow(10.0, xSection.get_Front(au) / 10f);
								double num3 = Math.Pow(10.0, xSection.get_Side(au) / 10f);
								double num4 = Math.Pow(10.0, xSection.get_Rear(au) / 10f);
								if (!(num < 1.0 && num >= 0.1))
								{
									if (num < 0.1 && num >= 0.01)
									{
										value = $"{xSection.get_Front(au):0.00}" + " dBsm, " + $"{num2:0.000}" + " sq.m.";
										value2 = $"{xSection.get_Side(au):0.00}" + " dBsm, " + $"{num3:0.000}" + " sq.m.";
										value3 = $"{xSection.get_Rear(au):0.00}" + " dBsm, " + $"{num4:0.000}" + " sq.m.";
									}
									else if (!(num < 0.01 && num >= 0.001))
									{
										if (num < 0.001 && num >= 0.0001)
										{
											value = $"{xSection.get_Front(au):0.00}" + " dBsm, " + $"{num2:0.00000}" + " sq.m.";
											value2 = $"{xSection.get_Side(au):0.00}" + " dBsm, " + $"{num3:0.00000}" + " sq.m.";
											value3 = $"{xSection.get_Rear(au):0.00}" + " dBsm, " + $"{num4:0.00000}" + " sq.m.";
										}
										else if (num < 0.0001 && num >= 1E-05)
										{
											value = $"{xSection.get_Front(au):0.00}" + " dBsm, " + $"{num2:0.000000}" + " sq.m.";
											value2 = $"{xSection.get_Side(au):0.00}" + " dBsm, " + $"{num3:0.000000}" + " sq.m.";
											value3 = $"{xSection.get_Rear(au):0.00}" + " dBsm, " + $"{num4:0.000000}" + " sq.m.";
										}
										else
										{
											value = $"{xSection.get_Front(au):0.00}" + " dBsm, " + $"{num2:0.0}" + " sq.m.";
											value2 = $"{xSection.get_Side(au):0.00}" + " dBsm, " + $"{num3:0.0}" + " sq.m.";
											value3 = $"{xSection.get_Rear(au):0.00}" + " dBsm, " + $"{num4:0.0}" + " sq.m.";
										}
									}
									else
									{
										value = $"{xSection.get_Front(au):0.00}" + " dBsm, " + $"{num2:0.0000}" + " sq.m.";
										value2 = $"{xSection.get_Side(au):0.00}" + " dBsm, " + $"{num3:0.0000}" + " sq.m.";
										value3 = $"{xSection.get_Rear(au):0.00}" + " dBsm, " + $"{num4:0.0000}" + " sq.m.";
									}
								}
								else
								{
									value = $"{xSection.get_Front(au):0.00}" + " dBsm, " + $"{num2:0.00}" + " sq.m.";
									value2 = $"{xSection.get_Side(au):0.00}" + " dBsm, " + $"{num3:0.00}" + " sq.m.";
									value3 = $"{xSection.get_Rear(au):0.00}" + " dBsm, " + $"{num4:0.00}" + " sq.m.";
								}
								luaTable3["front"] = Math.Round(num2, 6);
								luaTable3["side"] = Math.Round(num3, 6);
								luaTable3["rear"] = Math.Round(num4, 6);
								luaTable2["sqm"] = luaTable3;
							}
						}
						else
						{
							value = $"{xSection.get_Front(au):0.00}" + " nm";
							value2 = $"{xSection.get_Side(au):0.00}" + " nm";
							value3 = $"{xSection.get_Rear(au):0.00}" + " nm";
						}
					}
					else
					{
						value = $"{xSection.get_Front(au):0.00}" + " dB";
						value2 = $"{xSection.get_Side(au):0.00}" + " dB";
						value3 = $"{xSection.get_Rear(au):0.00}" + " dB";
					}
					luaTable3 = LuaSandBox.Singleton().CreateTable();
					luaTable3["front"] = Math.Round(xSection.get_Front(au), 5);
					luaTable3["side"] = Math.Round(xSection.get_Side(au), 5);
					luaTable3["rear"] = Math.Round(xSection.get_Rear(au), 5);
					luaTable2["rcs"] = luaTable3;
					luaTable3 = LuaSandBox.Singleton().CreateTable();
					luaTable3["front"] = value;
					luaTable3["side"] = value2;
					luaTable3["rear"] = value3;
					luaTable2["text"] = luaTable3;
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
				return luaTable;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[DoNotPrune]
	public LuaTable noiseLevel
	{
		get
		{
			try
			{
				if (au.IsBoat)
				{
					LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
					List<(float, float, float)> source = new List<(float, float, float)>
					{
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.VLF_Sonar),
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.LF_Sonar),
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.MF_Sonar),
						Sensor.NavalUnitNoiseInDecibels(au, Sensor.FrequencyBand.HF_Sonar)
					};
					luaTable["front"] = Math.Round(source.Select<(float, float, float), float>([SpecialName] ((float FrontValue, float SideValue, float RearValue) theTuple) => theTuple.FrontValue).Max(), 2);
					luaTable["side"] = Math.Round(source.Select<(float, float, float), float>([SpecialName] ((float FrontValue, float SideValue, float RearValue) theTuple) => theTuple.SideValue).Max(), 2);
					luaTable["rear"] = Math.Round(source.Select<(float, float, float), float>([SpecialName] ((float FrontValue, float SideValue, float RearValue) theTuple) => theTuple.RearValue).Max(), 2);
					return luaTable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[DoNotPrune]
	public bool TF
	{
		get
		{
			return au.get_DesiredAltitude_UseTerrainFollowing(au);
		}
		set
		{
			au.set_DesiredAltitude_UseTerrainFollowing(au, value);
		}
	}

	[DoNotPrune]
	public int TFType
	{
		get
		{
			return (int)au.TerrainFollowingType;
		}
		set
		{
			au.TerrainFollowingType = (ActiveUnit.TerrainFollowMode)value;
		}
	}

	[DoNotPrune]
	public LuaTable SatelliteData
	{
		get
		{
			try
			{
				if (au.IsSatellite)
				{
					LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
					Satellite satellite = (Satellite)au;
					luaTable["launchDate"] = satellite.LaunchDate.ToString("yyyy-MM-dd");
					if (satellite.DeOrbitDate.Year > 1900)
					{
						luaTable["deorbitDate"] = satellite.DeOrbitDate.ToString("yyyy-MM-dd");
					}
					luaTable["spacecraft"] = satellite.SpacecraftID.ToString();
					return luaTable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	public LuaWrapper_ActiveUnit(ActiveUnit a, Scenario s)
	{
		au = a;
		ScenarioContext = s;
	}

	public LuaWrapper_ActiveUnit(UnguidedWeapon a, Scenario s)
	{
		au = new Weapon(s);
		ScenarioContext = s;
		au.ObjectID = a.ObjectID;
		au.UnitClass = a.UnitClass;
		au.set_UnitSide(SetSideOnly: false, a.get_UnitSide(SetSideOnly: false));
		((Weapon)au).Type = a.Type;
		au.DBID = Conversions.ToInteger(Strings.Split(a.AnnexAndDBID, "_", -1, (CompareMethod)0)[1]);
		au.Name = a.Name;
		au.set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)a).get_Latitude((GlobalVariables.BooleanObject)null));
		au.set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)a).get_Longitude((GlobalVariables.BooleanObject)null));
		au.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)a).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		((Weapon)au).FiringParent = a.FiringParent;
	}

	[DoNotPrune]
	public LuaWrapper_Waypoint getwaypoint(LuaTable theTable)
	{
		if (theTable is LuaTable)
		{
			Dictionary<string, object> dictionary = LuaUtility.ToDictUpper(theTable.GetEnumerator());
			if (dictionary.ContainsKey("GUID"))
			{
				string text = Conversions.ToString(dictionary["GUID"]);
				Waypoint[] plottedCourse = au.Navigator.PlottedCourse;
				foreach (Waypoint waypoint in plottedCourse)
				{
					if (Operators.CompareString(waypoint.ObjectID, text, false) == 0)
					{
						return new LuaWrapper_Waypoint(waypoint, ScenarioContext);
					}
				}
			}
			return null;
		}
		throw new LuaError("Provided parameter is not a valid Lua table!");
	}

	[DoNotPrune]
	public LuaTable filterOnComponent(string type, int dbid = 0)
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		PlatformComponent platformComponent = null;
		if (au.Components().Count > 0)
		{
			foreach (PlatformComponent item in au.Components())
			{
				if ((!string.Equals(item.GetType().Name, type, StringComparison.OrdinalIgnoreCase) && Operators.CompareString(type, "", false) != 0) || (dbid != 0 && dbid != item.DBID))
				{
					continue;
				}
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["comp_guid"] = item.ObjectID;
				luaTable2["comp_dbid"] = item.DBID;
				luaTable2["comp_name"] = item.Name;
				luaTable2["comp_type"] = item.GetType().Name;
				luaTable2["comp_status"] = item.Status.ToString();
				if (item.Status != PlatformComponent._ComponentStatus.Operational)
				{
					luaTable2["comp_damage"] = item.DamageSeverity.ToString();
					luaTable2["comp_statusR"] = item.ReasonForInoperative;
				}
				if (item.GetType() == typeof(Cargo))
				{
					luaTable2["comp_name"] = ((Cargo)item).CargoObjectName;
					luaTable2["comp_type"] = (int)((Cargo)item).CurrentType;
					luaTable2["comp_dbid"] = ((Cargo)item).CargoObjectDBID;
					luaTable2["comp_guid"] = ((Cargo)item).CargoObjectID;
				}
				if (!(item.GetType() == typeof(CommDevice)))
				{
					if (item.GetType() == typeof(Sensor))
					{
						luaTable2["comp_sensor_jammed"] = ((Sensor)item).IsNeutralized;
					}
				}
				else
				{
					luaTable2["comp_comms_jammed"] = ((CommDevice)item).IsJammed;
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

	[DoNotPrune]
	public float rangetotarget(string contactId)
	{
		Contact contact = PrivateMethods.ValidateContactBySceanrio(contactId, ScenarioContext);
		float result = 0f;
		if (contact != null)
		{
			Module_Unit.RangeToUnit_Horiz_Angular(au, contact);
			float num = au.RangeToUnit_Horiz(contact);
			result = ((num != float.MaxValue) ? num : 0f);
		}
		return result;
	}

	[DoNotPrune]
	public bool inArea(LuaTable zone)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		au.get_UnitSide(SetSideOnly: false);
		list.Clear();
		List<object> list2 = LuaUtility.ToArray(zone.GetEnumerator());
		using (List<object>.Enumerator enumerator = list2.GetEnumerator())
		{
			_Closure$__216-0 closure$__216- = default(_Closure$__216-0);
			while (enumerator.MoveNext())
			{
				closure$__216- = new _Closure$__216-0(closure$__216-);
				closure$__216-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator.Current);
				ReferencePoint referencePoint = null;
				Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault((closure$__216-.$I0 != null) ? closure$__216-.$I0 : (closure$__216-.$I0 = closure$__216-._Lambda$__0))))
					{
						referencePoint = side.RefPoints.First(closure$__216-._Lambda$__1);
						break;
					}
				}
				if (!Information.IsNothing((object)referencePoint))
				{
					list.Add(referencePoint);
				}
			}
		}
		if (list == null)
		{
			throw new LuaError("Error in RP!");
		}
		return ((Module_Unit.Unit)au).get_IsInsideThisArea(list, ScenarioContext, UseCache: false);
	}

	[DoNotPrune]
	public override string ToString()
	{
		string text = "unit {\r\n type = '" + type + "', \r\n subtype = '" + subtype + "', \r\n name = '" + name + "', \r\n side = '" + side + "', \r\n guid = '" + guid.ToString() + "', \r\n class = '" + classname.ToString() + "', \r\n proficiency = '" + proficiency + "', \r\n latitude = '" + latitude + "', \r\n longitude = '" + longitude + "', \r\n altitude = '" + altitude.ToString() + "', \r\n heading = '" + heading.ToString() + "', \r\n speed = '" + speed.ToString() + "', \r\n throttle = '" + ((ActiveUnit.Throttle)Conversions.ToByte(throttle)/*cast due to .constrained prefix*/).ToString() + "', \r\n autodetectable = '" + autodetectable + "', \r\n";
		if (@base != null)
		{
			text = text + " base = '" + @base.name + "', \r\n";
		}
		if (((group != null) | au.IsGroup) && group != null)
		{
			LuaWrapper_Group luaWrapper_Group = (LuaWrapper_Group)group;
			text = text + " group = '" + luaWrapper_Group.name + "', \r\n";
		}
		if (mission != null)
		{
			LuaWrapper_Mission luaWrapper_Mission = (LuaWrapper_Mission)mission;
			text = text + " mission = '" + luaWrapper_Mission.name + "', \r\n";
		}
		if (Operators.CompareString(type, "None", false) != 0)
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
		text = text + " AssignedMissionsQueue = '" + AssignedMissionsQueue.ToString() + "', \r\n";
		text = text + " Decoy = '" + au.IsDecoy + "', \r\n";
		return text + "}";
	}

	[DoNotPrune]
	public float angleOnBowToUnit(string ObserverUnitID)
	{
		if (!string.IsNullOrEmpty(ObserverUnitID))
		{
			ActiveUnit value = null;
			if (ScenarioContext.ActiveUnits.TryGetValue(ObserverUnitID, out value))
			{
				ActiveUnit myUnit = value;
				ActiveUnit observerUnit = au;
				string feedbackMessage = "";
				return Module_Unit.AngleOffThisUnitsBoresight(myUnit, observerUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage);
			}
		}
		return 0f;
	}

	[DoNotPrune]
	public LuaWrapper_Device_Magazine getUnitMagazine(string mag_guid)
	{
		Magazine[] totalMagazines = au.TotalMagazines;
		foreach (Magazine magazine in totalMagazines)
		{
			if (Operators.CompareString(magazine.ObjectID, mag_guid, false) == 0)
			{
				return new LuaWrapper_Device_Magazine(magazine, ScenarioContext);
			}
		}
		return null;
	}

	public LuaWrapper_Device_Mount getUnitMount(string mount_guid)
	{
		foreach (Mount mount in au.Mounts)
		{
			if (Operators.CompareString(mount.ObjectID, mount_guid, false) == 0)
			{
				return new LuaWrapper_Device_Mount(mount, ScenarioContext);
			}
		}
		return null;
	}

	public LuaWrapper_Device_Magazine getUnitMountMagazine(string mount_guid)
	{
		foreach (Mount mount in au.Mounts)
		{
			if (Operators.CompareString(mount.ObjectID, mount_guid, false) == 0)
			{
				return new LuaWrapper_Device_Magazine(mount.MountMagazine, ScenarioContext);
			}
		}
		return null;
	}

	public LuaWrapper_Cargo getUnitCargo(string cargo_guid)
	{
		Cargo[] onboardCargo = au.OnboardCargo;
		int num = 0;
		Cargo cargo;
		while (true)
		{
			if (num < onboardCargo.Length)
			{
				cargo = onboardCargo[num];
				if (Operators.CompareString(cargo.CargoObjectID, cargo_guid, false) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return null;
		}
		return new LuaWrapper_Cargo(cargo, ScenarioContext);
	}

	[DoNotPrune]
	public bool deployDippingSonar(bool theDownState)
	{
		if (au.IsAircraft)
		{
			if (!theDownState)
			{
				return false;
			}
			CoreClientCode.DeployDippingSonar_Core(au);
			return true;
		}
		return false;
	}

	[DoNotPrune]
	public bool dropSonobuoy(bool ActiveSonobuoy, bool ShallowSonobuoy)
	{
		if (au.IsAircraft)
		{
			bool flag = false;
			List<Weapon> list = au.Weaponry.AllDistinctWeaponsAboard_Actual();
			foreach (Weapon item in list)
			{
				if (item.Type == Weapon._WeaponType.Sonobuoy && au.Weaponry.TotalAvailableInventoryForThisWeapon(item.DBID, IncludeNonOperationalMountsAndMags: false) > 0)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				CoreClientCode.DropSonobuoy_Core(ScenarioContext, au, ActiveSonobuoy, ShallowSonobuoy, IsManual: true);
				return true;
			}
			return false;
		}
		return false;
	}

	[DoNotPrune]
	public LuaTable flightRange(ActiveUnit.Throttle? theThrottle, float? theSpeed, float? theAltitude)
	{
		if (!au.IsAircraft)
		{
			return null;
		}
		Aircraft obj = (Aircraft)au;
		float num = obj.CurrentSpeed;
		ActiveUnit.Throttle result = obj.ThrottleSetting;
		float value = obj.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		if (theThrottle.HasValue)
		{
			Enum.TryParse<ActiveUnit.Throttle>(Conversions.ToString((byte)theThrottle.Value), ignoreCase: true, out result);
		}
		if (theSpeed.HasValue)
		{
			num = theSpeed.Value;
		}
		if (theAltitude.HasValue)
		{
			value = theAltitude.Value;
		}
		long num2 = obj.get_FuelEndurance(result, (AltBand)null, (float?)num, (float?)value);
		float num3 = (float)((double)num2 / 3600.0 * (double)num);
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		luaTable["range"] = num3;
		luaTable["endurance"] = num2;
		return luaTable;
	}

	static LuaWrapper_ActiveUnit()
	{
		Class72.smethod_20();
	}
}
