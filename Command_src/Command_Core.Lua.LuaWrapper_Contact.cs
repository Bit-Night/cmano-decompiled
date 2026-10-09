using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core.DAL;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core.Lua;

[DoNotObfuscateType]
[DoNotPrune]
[DoNotPruneType]
public sealed class LuaWrapper_Contact
{
	[CompilerGenerated]
	internal sealed class _Closure$__79-0
	{
		public object $VB$Local_o;

		public Func<ReferencePoint, bool> $I0;

		public Func<ReferencePoint, bool> $I1;

		public _Closure$__79-0(_Closure$__79-0 arg0)
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

		static _Closure$__79-0()
		{
			Class72.smethod_20();
		}
	}

	private Contact contact_0;

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
	public object __obj => contact_0;

	[DoNotPrune]
	public string objectid => guid;

	[DoNotPrune]
	public string guid => contact_0.ObjectID;

	[DoNotPrune]
	public int tracknumber => contact_0.AutoIncrement;

	[DoNotPrune]
	public string name
	{
		get
		{
			return contact_0.Name;
		}
		set
		{
			contact_0.Name = value;
		}
	}

	[DoNotPrune]
	public string actualunitid
	{
		get
		{
			if (Information.IsNothing((object)contact_0.ActualUnit))
			{
				return "";
			}
			return contact_0.ActualUnit.ObjectID;
		}
	}

	[DoNotPrune]
	public double latitude => ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null);

	[DoNotPrune]
	public double longitude => ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null);

	[DoNotPrune]
	public object speed
	{
		get
		{
			if (contact_0.SpeedIsKnown)
			{
				return contact_0.CurrentSpeed;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object heading
	{
		get
		{
			if (!contact_0.HeadingIsKnown)
			{
				return null;
			}
			return contact_0.CurrentHeading;
		}
	}

	[DoNotPrune]
	public object altitude
	{
		get
		{
			if (!contact_0.AltitudeIsKnown)
			{
				return null;
			}
			return ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
	}

	[DoNotPrune]
	public string posture
	{
		get
		{
			if (contact_0.SideIsKnown)
			{
				return contact_0.get_Stance(side_0) switch
				{
					Misc.PostureStance.Neutral => "N", 
					Misc.PostureStance.Friendly => "F", 
					Misc.PostureStance.Unfriendly => "U", 
					Misc.PostureStance.Hostile => "H", 
					Misc.PostureStance.Unknown => "X", 
					_ => "X", 
				};
			}
			return contact_0.get_Stance(side_0) switch
			{
				Misc.PostureStance.Neutral => "N", 
				Misc.PostureStance.Friendly => "F", 
				Misc.PostureStance.Unfriendly => "U", 
				Misc.PostureStance.Hostile => "H", 
				Misc.PostureStance.Unknown => "X", 
				_ => "X", 
			};
		}
		set
		{
			if (contact_0.SideIsKnown)
			{
				switch (value)
				{
				case "N":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Neutral);
					break;
				case "X":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Unknown);
					break;
				default:
					throw new LuaError("Invalid posture code: " + value);
				case "U":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Unfriendly);
					break;
				case "H":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Hostile);
					break;
				case "F":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Friendly);
					break;
				}
			}
			else
			{
				switch (value)
				{
				case "F":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Friendly);
					break;
				case "N":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Neutral);
					break;
				case "U":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Unfriendly);
					break;
				case "X":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Unknown);
					break;
				default:
					throw new LuaError("Invalid posture code: " + value);
				case "H":
					contact_0.set_Stance(side_0, MarkManually: false, Misc.PostureStance.Hostile);
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public Side observer
	{
		get
		{
			if (contact_0.OriginalDetectorSide != null && Operators.CompareString(contact_0.OriginalDetectorSide.ObjectID, side_0.ObjectID, false) != 0)
			{
				return contact_0.OriginalDetectorSide;
			}
			return null;
		}
	}

	[DoNotPrune]
	public string observer_posture
	{
		get
		{
			if (!contact_0.SideIsKnown)
			{
				return contact_0.get_Stance(contact_0.OriginalDetectorSide) switch
				{
					Misc.PostureStance.Neutral => "N", 
					Misc.PostureStance.Friendly => "F", 
					Misc.PostureStance.Unfriendly => "U", 
					Misc.PostureStance.Hostile => "H", 
					Misc.PostureStance.Unknown => "X", 
					_ => "X", 
				};
			}
			return contact_0.get_Stance(contact_0.OriginalDetectorSide) switch
			{
				Misc.PostureStance.Neutral => "N", 
				Misc.PostureStance.Friendly => "F", 
				Misc.PostureStance.Unfriendly => "U", 
				Misc.PostureStance.Hostile => "H", 
				Misc.PostureStance.Unknown => "X", 
				_ => "X", 
			};
		}
		set
		{
			if (!contact_0.SideIsKnown)
			{
				switch (value)
				{
				case "N":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Neutral);
					break;
				case "U":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Unfriendly);
					break;
				case "X":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Unknown);
					break;
				default:
					throw new LuaError("Invalid posture code: " + value);
				case "H":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Hostile);
					break;
				case "F":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Friendly);
					break;
				}
			}
			else
			{
				switch (value)
				{
				case "F":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Friendly);
					break;
				case "N":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Neutral);
					break;
				case "U":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Unfriendly);
					break;
				default:
					throw new LuaError("Invalid posture code: " + value);
				case "X":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Unknown);
					break;
				case "H":
					contact_0.set_Stance(contact_0.OriginalDetectorSide, MarkManually: false, Misc.PostureStance.Hostile);
					break;
				}
			}
		}
	}

	[DoNotPrune]
	public LuaTable areaofuncertainty
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			int num = 1;
			if (!Information.IsNothing((object)contact_0.UncertaintyArea))
			{
				foreach (Geopoint_Struct item in contact_0.UncertaintyArea)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					luaTable2["longitude"] = item.Longitude;
					luaTable2["latitude"] = item.Latitude;
					luaTable[num] = luaTable2;
					num++;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public string type => contact_0.ContactType_String;

	[DoNotPrune]
	public int typed => (int)contact_0.Type;

	[DoNotPrune]
	public string type_description => contact_0.DescriptionString;

	[DoNotPrune]
	public int actualunitdbid
	{
		get
		{
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass && !Information.IsNothing((object)contact_0.ActualUnit))
			{
				return contact_0.ActualUnit.DBID;
			}
			return 0;
		}
	}

	[DoNotPrune]
	public int classificationlevel => (int)contact_0.IDStatus;

	[DoNotPrune]
	public LuaTable potentialmatches
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			DataRow[] array = null;
			foreach (int possibleMatchesBasedOnEmission in contact_0.PossibleMatchesBasedOnEmissions)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["DBID"] = possibleMatchesBasedOnEmission;
				switch (contact_0.Type)
				{
				case Contact_Base.ContactType.Air:
					array = scenario_0.Cache_Aircraft_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Aircraft theAircraft = new Aircraft(ref scenario_0);
						DBFunctions.GetAircraft(ref scenario_0, ref theAircraft, possibleMatchesBasedOnEmission, LoadComponents: false);
						luaTable2["TYPE"] = theAircraft.Type;
						luaTable2["SUBTYPE"] = theAircraft.SubType;
						luaTable2["CATEGORY"] = theAircraft.Category;
					}
					break;
				case Contact_Base.ContactType.Surface:
					array = scenario_0.Cache_Ships_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Ship theShip = new Ship(ref scenario_0);
						DBFunctions.GetShip(ref scenario_0, ref theShip, possibleMatchesBasedOnEmission, LoadComponents: false);
						luaTable2["TYPE"] = theShip.Type;
						luaTable2["SUBTYPE"] = theShip.SubType;
						luaTable2["CATEGORY"] = theShip.Category;
						luaTable2["MISSILE_DEFENCE"] = theShip.MissileDefense;
					}
					break;
				case Contact_Base.ContactType.Submarine:
					array = scenario_0.Cache_Subs_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Submarine theSub = new Submarine(ref scenario_0);
						DBFunctions.GetSubmarine(ref scenario_0, ref theSub, possibleMatchesBasedOnEmission, LoadComponents: false);
						luaTable2["TYPE"] = theSub.Type;
						luaTable2["SUBTYPE"] = theSub.SubType;
						luaTable2["CATEGORY"] = theSub.Category;
					}
					break;
				case Contact_Base.ContactType.Orbital:
					array = scenario_0.Cache_Satellites_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Satellite theSatellite = new Satellite(ref scenario_0);
						DBFunctions.GetSatellite(ref scenario_0, ref theSatellite, possibleMatchesBasedOnEmission);
						luaTable2["TYPE"] = theSatellite.Type;
						luaTable2["SUBTYPE"] = theSatellite.SubType;
						luaTable2["CATEGORY"] = theSatellite.Category;
					}
					break;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.AggregateGroundUnit:
					array = scenario_0.Cache_Facilities_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Facility theFac = new Facility(ref scenario_0);
						DBFunctions.GetFacility(ref scenario_0, ref theFac, possibleMatchesBasedOnEmission, LoadComponents: false);
						luaTable2["SUBTYPE"] = theFac.SubType;
						luaTable2["CATEGORY"] = theFac.Category;
						luaTable2["MISSILE_DEFENCE"] = theFac.MissileDefense;
					}
					break;
				case Contact_Base.ContactType.Missile:
				case Contact_Base.ContactType.Torpedo:
					array = scenario_0.Cache_Weapons_DT.Select("ID=" + Conversions.ToString(possibleMatchesBasedOnEmission));
					if (array != null && array.Count() > 0)
					{
						Weapon newWeapon = Weapon.GetNewWeapon(ref scenario_0, 0, bool_5: true);
						DBFunctions.GetWeapon(scenario_0.DBConnection, newWeapon, possibleMatchesBasedOnEmission, scenario_0);
						luaTable2["TYPE"] = newWeapon.Type;
						luaTable2["SUBTYPE"] = newWeapon.SubType;
					}
					break;
				}
				if (array != null && array.Count() > 0)
				{
					luaTable2["NAME"] = Misc.RemoveHiddenString(array[0]["Name"].ToString());
				}
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public object side
	{
		get
		{
			if (contact_0.SideIsKnown)
			{
				return new LuaWrapper_Side(contact_0.get_UnitSide(SetSideOnly: false), scenario_0);
			}
			return null;
		}
	}

	[DoNotPrune]
	public object fromside
	{
		get
		{
			if (side_0 == null)
			{
				return null;
			}
			return new LuaWrapper_Side(side_0, scenario_0);
		}
	}

	[DoNotPrune]
	public object detectedBySide => new LuaWrapper_Side(contact_0.OriginalDetectorSide, scenario_0);

	[DoNotPrune]
	public int missile_defence
	{
		get
		{
			int result;
			if (contact_0.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
			{
				result = 0;
			}
			else
			{
				if (!Information.IsNothing((object)contact_0.ActualUnit))
				{
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Facility_Mobile:
						return ((Facility)contact_0.ActualUnit).MissileDefense;
					default:
						return -1;
					case Contact_Base.ContactType.AggregateGroundUnit:
						return 0;
					case Contact_Base.ContactType.Surface:
						return ((Ship)contact_0.ActualUnit).MissileDefense;
					}
				}
				result = 0;
			}
			return result;
		}
	}

	[DoNotPrune]
	public float age => contact_0.TimeSinceDetection;

	[DoNotPrune]
	public object BDA
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (!Information.IsNothing((object)contact_0.BDA_FloodLevel))
			{
				luaTable["FLOOD"] = Misc.ToEnglishString(contact_0.BDA_FloodLevel);
			}
			if (!Information.IsNothing((object)contact_0.BDA_FireLevel))
			{
				luaTable["FIRES"] = Misc.ToEnglishString(contact_0.BDA_FireLevel);
			}
			if (!Information.IsNothing((object)contact_0.BDA_StructuralIntegrity))
			{
				luaTable["STRUCTURAL"] = Misc.ToEnglishString(contact_0.BDA_StructuralIntegrity);
			}
			if (luaTable.Keys.Count != 0)
			{
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object emissions
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (!contact_0.HasDetectedEmissions)
			{
				return null;
			}
			List<int> list = contact_0.DetectedEmissions.Keys.ToList();
			if (contact_0.DetectedEmissions.Count != 0)
			{
				foreach (int item in list)
				{
					LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
					EmissionContainer emissionContainer = contact_0.DetectedEmissions[item];
					string value = emissionContainer.get_ID_Description(item, scenario_0);
					float num = emissionContainer.Age;
					bool preciseID = emissionContainer.PreciseID;
					luaTable2["Name"] = value;
					luaTable2["Age"] = num;
					luaTable2["Solid"] = preciseID;
					luaTable2["name"] = value;
					luaTable2["age"] = num;
					luaTable2["solid"] = preciseID;
					SQLiteConnection sqliteConnection_ = scenario_0.DBConnection;
					Sensor sensor = DBFunctions.GetSensor(item, ref sqliteConnection_);
					luaTable2["sensor_dbid"] = sensor.DBID;
					luaTable2["sensor_name"] = sensor.Name;
					luaTable2["sensor_type"] = (short)sensor.Type;
					luaTable2["sensor_role"] = (long)sensor.Role;
					luaTable2["sensor_maxrange"] = sensor.maxRange;
					luaTable[luaTable.Keys.Count + 1] = luaTable2;
				}
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public object detectionBy
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (!Information.IsNothing((object)contact_0.TimeSinceDetection_Radar))
			{
				luaTable["Radar"] = contact_0.TimeSinceDetection_Radar;
			}
			if (!Information.IsNothing((object)contact_0.TimeSinceDetection_ESM))
			{
				luaTable["ESM"] = contact_0.TimeSinceDetection_ESM;
			}
			if (!Information.IsNothing((object)contact_0.TimeSinceDetection_Visual))
			{
				luaTable["Visual"] = contact_0.TimeSinceDetection_Visual;
			}
			if (!Information.IsNothing((object)contact_0.TimeSinceDetection_Infrared))
			{
				luaTable["Infrared"] = contact_0.TimeSinceDetection_Infrared;
			}
			if (!Information.IsNothing((object)contact_0.TimeSinceDetection_SonarActive))
			{
				luaTable["SonarActive"] = contact_0.TimeSinceDetection_SonarActive;
			}
			if (!Information.IsNothing((object)contact_0.TimeSinceDetection_SonarPassive))
			{
				luaTable["SonarPassive"] = contact_0.TimeSinceDetection_SonarPassive;
			}
			if (luaTable.Keys.Count != 0)
			{
				return luaTable;
			}
			return null;
		}
	}

	[DoNotPrune]
	public object targetedBy
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
			{
				Contact[] targets_ReadOnly = value.AI.Targets_ReadOnly;
				for (int i = 0; i < targets_ReadOnly.Length; i = checked(i + 1))
				{
					if (targets_ReadOnly[i].ActualUnit == contact_0.ActualUnit && !dictionary.ContainsValue(value.ObjectID))
					{
						dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
					}
				}
				if (!Information.IsNothing((object)value.AI.PrimaryTarget) && value.AI.PrimaryTarget.ActualUnit == contact_0.ActualUnit && !dictionary.ContainsValue(value.ObjectID))
				{
					dictionary.Add(dictionary.Count.ToString(), value.ObjectID);
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
	public object firingAt
	{
		get
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
			{
				if (value.IsWeapon)
				{
					Weapon obj = (Weapon)value;
					_ = obj.DBID;
					ActiveUnit firingParent = obj.FiringParent;
					Contact primaryTarget = obj.AI.PrimaryTarget;
					if (!Information.IsNothing((object)primaryTarget) && contact_0.ActualUnit == firingParent && !dictionary.ContainsValue(primaryTarget.ObjectID))
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
			foreach (ActiveUnit value in scenario_0.ActiveUnits.Values)
			{
				if (value.IsWeapon)
				{
					Weapon obj = (Weapon)value;
					_ = obj.DBID;
					ActiveUnit firingParent = obj.FiringParent;
					Contact primaryTarget = obj.AI.PrimaryTarget;
					if (!Information.IsNothing((object)primaryTarget) && (object)contact_0 == primaryTarget.ActualUnit && !dictionary.ContainsValue(firingParent.ObjectID))
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
	public object FilterOut
	{
		get
		{
			return contact_0.IsFilteredOut;
		}
		set
		{
			bool? flag = LuaUtility.ParseBoolean(RuntimeHelpers.GetObjectValue(value));
			if (flag.HasValue)
			{
				contact_0.IsFilteredOut = flag.Value;
			}
		}
	}

	[DoNotPrune]
	public LuaTable weather
	{
		get
		{
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			if (Information.IsNothing((object)longitude) & Information.IsNothing((object)longitude))
			{
				return null;
			}
			float num = 0f;
			if (contact_0.AltitudeIsKnown)
			{
				num = ((Module_Unit.Unit)contact_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			Weather.WeatherProfile weatherProfile = Weather.get_WeatherAtThisTimeAndPlace(scenario_0, latitude, longitude, (int)Math.Round(num));
			luaTable["temp"] = weatherProfile.get_ActualTempAtSL(Weather.TTimeOfDayType.tod_Day);
			luaTable["rainfall"] = weatherProfile.RainfallRate;
			luaTable["undercloud"] = weatherProfile.FractionUnderRain;
			luaTable["seastate"] = weatherProfile.SeaState;
			return luaTable;
		}
	}

	[DoNotPrune]
	public object lastDetections
	{
		get
		{
			if (contact_0.LastDetections.Count == 0)
			{
				return null;
			}
			List<Contact.Detection_Struct> source = new List<Contact.Detection_Struct>(contact_0.LastDetections);
			source = source.OrderByDescending([SpecialName] (Contact.Detection_Struct theRec) => theRec.theTime).ToList();
			LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
			foreach (Contact.Detection_Struct item in source)
			{
				LuaTable luaTable2 = LuaSandBox.Singleton().CreateTable();
				luaTable2["detector_guid"] = item.DetectorUnitID + ((!scenario_0.ActiveUnits.ContainsKey(item.DetectorUnitID)) ? "?" : "");
				luaTable2["detect_sensor_guid"] = item.DetectingSensorID;
				luaTable2["range"] = item.RangeEstimate;
				luaTable2["special_mode"] = item.theDetectionMode;
				luaTable2["age"] = (long)Math.Round((scenario_0.Time - item.theTime).TotalSeconds);
				luaTable[luaTable.Keys.Count + 1] = luaTable2;
			}
			return luaTable;
		}
	}

	[DoNotPrune]
	public bool markedAsDecoy
	{
		get
		{
			return contact_0.ActualUnit.get_isTaggedAsDecoyByThisSide(side_0.ObjectID);
		}
		set
		{
			bool flag = contact_0.ActualUnit.get_isTaggedAsDecoyByThisSide(side_0.ObjectID);
			if (value)
			{
				if (!flag)
				{
					contact_0.ActualUnit.ToggleUnitAsDecoyForCurrentSide(side_0.ObjectID);
				}
			}
			else if (flag)
			{
				contact_0.ActualUnit.ToggleUnitAsDecoyForCurrentSide(side_0.ObjectID);
			}
		}
	}

	public LuaWrapper_Contact(Contact theContact, Scenario theScen, Side fromSide)
	{
		contact_0 = theContact;
		scenario_0 = theScen;
		side_0 = fromSide;
	}

	[DoNotPrune]
	public object DropContact()
	{
		side_0.DropContact(contact_0, ref scenario_0, LogMessage: true);
		return "ok";
	}

	[DoNotPrune]
	public bool inArea(LuaTable zone)
	{
		List<ReferencePoint> list = new List<ReferencePoint>();
		contact_0.get_UnitSide(SetSideOnly: false);
		list.Clear();
		List<object> list2 = LuaUtility.ToArray(zone.GetEnumerator());
		using (List<object>.Enumerator enumerator = list2.GetEnumerator())
		{
			_Closure$__79-0 closure$__79- = default(_Closure$__79-0);
			while (enumerator.MoveNext())
			{
				closure$__79- = new _Closure$__79-0(closure$__79-);
				closure$__79-.$VB$Local_o = RuntimeHelpers.GetObjectValue(enumerator.Current);
				ReferencePoint referencePoint = null;
				Side[] sides_ReadOnly = scenario_0.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (!Information.IsNothing((object)side.RefPoints.FirstOrDefault((closure$__79-.$I0 != null) ? closure$__79-.$I0 : (closure$__79-.$I0 = closure$__79-._Lambda$__0))))
					{
						referencePoint = side.RefPoints.First((closure$__79-.$I1 != null) ? closure$__79-.$I1 : (closure$__79-.$I1 = closure$__79-._Lambda$__1));
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
		return ((Module_Unit.Unit)contact_0).get_IsInsideThisArea(list, scenario_0, UseCache: false);
	}

	[DoNotPrune]
	public override string ToString()
	{
		return string.Concat("contact {\r\n guid = '" + guid + "', \r\n tracknumber = '" + tracknumber + "', \r\n name = '" + name + "', \r\n type = '" + type.ToString() + "', \r\n", "}");
	}

	[DoNotPrune]
	public LuaTable ToLuaTable()
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		if (contact_0.LastDetections.Count > 0)
		{
			Contact.Detection_Struct detection_Struct = contact_0.LastDetections.ElementAt(contact_0.LastDetections.Count - 1);
			luaTable["DATE"] = detection_Struct.theTime.ToString("dd:MM:yyyy");
			luaTable["TIME"] = detection_Struct.theTime.ToString("HH:mm:ss");
			luaTable["RANGE"] = detection_Struct.RangeEstimate.ToString();
			luaTable["SENSORPARENTID"] = detection_Struct.DetectorUnitID;
			luaTable["SENSORID"] = detection_Struct.DetectingSensorID;
			luaTable["TARGETID"] = contact_0.ActualUnit.ObjectID;
			luaTable["NAME"] = contact_0.Name;
			luaTable["POSTURE"] = posture;
			if (contact_0.UncertaintyArea != null)
			{
				List<string> list = new List<string>();
				foreach (Geopoint_Struct item in contact_0.UncertaintyArea)
				{
					list.Add(item.Longitude + ";" + item.Latitude);
				}
				if (list.Count > 2)
				{
					luaTable["UNCERTAINITYAREA"] = string.Join("|", list);
				}
			}
		}
		else
		{
			luaTable["DATE"] = scenario_0.Time.ToString("dd:MM:yyyy");
			luaTable["TIME"] = scenario_0.Time.ToString("HH:mm:ss");
			luaTable["RANGE"] = "-1";
			luaTable["SENSORPARENTID"] = "-1";
			luaTable["SENSORID"] = "-1";
			luaTable["TARGETID"] = "-1";
			luaTable["NAME"] = "Generated Contact";
			luaTable["UNCERTAINITYAREA"] = "";
			luaTable["POSTURE"] = "X";
		}
		return luaTable;
	}

	[DoNotPrune]
	public LuaTable FromLuaTable()
	{
		LuaTable luaTable = LuaSandBox.Singleton().CreateTable();
		luaTable["TEST"] = "A";
		return luaTable;
	}

	static LuaWrapper_Contact()
	{
		Class72.smethod_20();
	}
}
