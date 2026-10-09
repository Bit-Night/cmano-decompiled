using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using ConcurrentObservableCollections.ConcurrentObservableDictionary;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class ActiveUnit : Module_Unit.Unit
{
	public enum TerrainFollowMode
	{
		IgnoreLandCover,
		WithinLandCover,
		AboveLandCover
	}

	public delegate void ChangedThrottleSettingEventHandler(ActiveUnit theUnit, Throttle NewThrottleSetting);

	public delegate void ParentGroupChangedEventHandler(string UnitObjectID);

	public delegate void NameChangedEventHandler(string UnitObjectID);

	public delegate void ActiveUnitMountsAddedEventHandler(string UnitObjectID, string NewMountObjectID);

	public delegate void ActiveUnitMountsRemovedEventHandler(string UnitObjectID, string RemovedMountObjectID);

	public enum TurnRate : byte
	{
		Max,
		Navigation
	}

	protected internal class UnitComponentGroups
	{
		protected internal class ComponentGroup
		{
			internal List<ComponentGroup> Neighbors;

			internal bool IsArmor;

			internal bool InsideArmor;

			internal List<ComponentDamageStatus> Components;

			internal bool AsStoredAircraft;

			internal UnitComponentGroups ContainingComponentGroups;

			internal GlobalVariables.ArmorRating ArmorThickness;

			internal string LocationTag;

			internal double GetTotalVolume
			{
				get
				{
					double num = 0.0;
					foreach (ComponentDamageStatus component in Components)
					{
						num += (double)component.Volume;
					}
					return num;
				}
			}

			internal ComponentGroup(bool IsArmor, bool InsideArmor, bool IsAirWing, UnitComponentGroups Parent, string Location, GlobalVariables.ArmorRating Armor)
			{
				Neighbors = new List<ComponentGroup>();
				this.IsArmor = IsArmor;
				this.InsideArmor = InsideArmor;
				Components = new List<ComponentDamageStatus>();
				AsStoredAircraft = IsAirWing;
				ContainingComponentGroups = Parent;
				LocationTag = Location;
				ArmorThickness = Armor;
			}

			protected internal void AddComponent(PlatformComponent thePC, bool DirectlyImpacted = false, float Volume = 1f, float Durability = 1f)
			{
				ComponentDamageStatus item = new ComponentDamageStatus(this, 0, thePC, DirectlyImpacted, Volume, Durability);
				Components.Add(item);
			}

			static ComponentGroup()
			{
				Class72.smethod_20();
			}
		}

		protected internal class UnitComponentGroupEvalState
		{
			[CompilerGenerated]
			internal sealed class _Closure$__18-0
			{
				public object $VB$Local_ArmorLevel;

				public _Closure$__18-0(_Closure$__18-0 arg0)
				{
					if (arg0 != null)
					{
						$VB$Local_ArmorLevel = arg0.$VB$Local_ArmorLevel;
					}
				}

				[SpecialName]
				internal bool _Lambda$__0(ComponentGroup groups)
				{
					return groups.ArmorThickness.Equals(RuntimeHelpers.GetObjectValue($VB$Local_ArmorLevel));
				}

				[SpecialName]
				internal bool _Lambda$__1(ComponentDamageStatus comps)
				{
					return comps.Component.GetArmor.ArmorRating.Equals(RuntimeHelpers.GetObjectValue($VB$Local_ArmorLevel));
				}

				static _Closure$__18-0()
				{
					Class72.smethod_20();
				}
			}

			private ComponentDamageStatus componentDamageStatus_0;

			private List<ComponentDamageStatus> list_0;

			private List<ComponentDamageStatus> jbuypMavrqZ;

			private List<ComponentGroup> list_1;

			private List<ComponentGroup> list_2;

			private bool bool_0;

			private bool bool_1;

			private bool bool_2;

			public ComponentDamageStatus CurrentComponent
			{
				get
				{
					bool_2 = true;
					return componentDamageStatus_0;
				}
				set
				{
					bool_2 = false;
					componentDamageStatus_0 = value;
				}
			}

			protected internal UnitComponentGroupEvalState(ComponentDamageStatus StartingComp)
			{
				list_0 = new List<ComponentDamageStatus>();
				jbuypMavrqZ = new List<ComponentDamageStatus>();
				list_1 = new List<ComponentGroup>();
				list_2 = new List<ComponentGroup>();
				bool_0 = StartingComp.Component.GetArmor.InsideArmoredStructure;
				bool_1 = true;
				CurrentComponent = StartingComp;
				foreach (ComponentDamageStatus component in StartingComp.ContainingGroup.Components)
				{
					if (component != StartingComp)
					{
						if (component.Component.GetArmor.ArmorRating == GlobalVariables.ArmorRating.None)
						{
							list_0.Insert((int)Math.Round((double)list_0.Count * GameGeneral.GlobalRNG.NextDouble()), component);
						}
						else
						{
							jbuypMavrqZ.Insert((int)Math.Round((double)jbuypMavrqZ.Count * GameGeneral.GlobalRNG.NextDouble()), component);
						}
					}
				}
				foreach (ComponentGroup neighbor in StartingComp.ContainingGroup.Neighbors)
				{
					list_1.Add(neighbor);
				}
				list_2.Add(StartingComp.ContainingGroup);
			}

			protected internal bool CurrentStale()
			{
				return bool_2;
			}

			protected internal ComponentDamageStatus Current()
			{
				return CurrentComponent;
			}

			protected internal bool MoveToNextInQueue()
			{
				if (list_0.Any())
				{
					CurrentComponent = list_0.ElementAt(0);
					list_0.RemoveAt(0);
					return true;
				}
				return false;
			}

			protected internal bool HasNextInQueue()
			{
				if (!CurrentStale())
				{
					return true;
				}
				return list_0.Any();
			}

			protected internal bool HasComponentsRemaining()
			{
				return bool_1;
			}

			protected internal bool TryAddNextGroups()
			{
				while (!list_0.Any() & bool_1)
				{
					method_0();
				}
				return bool_1;
			}

			private void method_0()
			{
				bool flag = false;
				List<ComponentGroup> list = new List<ComponentGroup>();
				list.AddRange(list_1);
				int count = list_0.Count;
				int count2 = jbuypMavrqZ.Count;
				int num = list_1.Count;
				foreach (ComponentGroup item2 in list)
				{
					if (item2.ArmorThickness == GlobalVariables.ArmorRating.None)
					{
						list_1.Remove(item2);
						num--;
						list_2.Add(item2);
						flag = true;
						method_1(item2, count, count2, num);
					}
					if (!item2.InsideArmor)
					{
						bool_0 = false;
					}
				}
				if (!bool_0)
				{
					foreach (ComponentGroup item3 in list_1)
					{
						if (item3.ArmorThickness == GlobalVariables.ArmorRating.None)
						{
							return;
						}
					}
					if (!list_0.Any())
					{
						bool_1 = false;
					}
				}
				else
				{
					if (flag)
					{
						return;
					}
					Array values = Enum.GetValues(typeof(GlobalVariables.ArmorRating));
					{
						IEnumerator enumerator3 = values.GetEnumerator();
						try
						{
							_Closure$__18-0 closure$__18- = default(_Closure$__18-0);
							IEnumerable<ComponentGroup> source;
							IEnumerable<ComponentDamageStatus> source2;
							while (true)
							{
								if (!enumerator3.MoveNext())
								{
									return;
								}
								closure$__18- = new _Closure$__18-0(closure$__18-);
								closure$__18-.$VB$Local_ArmorLevel = RuntimeHelpers.GetObjectValue(enumerator3.Current);
								if (!closure$__18-.$VB$Local_ArmorLevel.Equals(GlobalVariables.ArmorRating.None))
								{
									source = list_1.Where(closure$__18-._Lambda$__0);
									source2 = jbuypMavrqZ.Where(closure$__18-._Lambda$__1);
									if (source.Any() || source2.Any())
									{
										break;
									}
								}
							}
							int num2 = (int)Conversion.Int(GameGeneral.GlobalRNG.NextDouble() * (double)(source2.Count() + source.Count()));
							if (source2.Any() && num2 < source2.Count())
							{
								ComponentDamageStatus item = source2.ElementAt(num2);
								list_0.Add(item);
								jbuypMavrqZ.Remove(item);
							}
							else
							{
								ComponentGroup componentGroup = source.ElementAt(num2 - source2.Count());
								method_1(componentGroup, count, count2, num);
								list_2.Add(componentGroup);
								list_1.Remove(componentGroup);
							}
						}
						finally
						{
							IDisposable disposable = enumerator3 as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
				}
			}

			private void method_1(ComponentGroup componentGroup_0, int int_0, int int_1, int int_2)
			{
				foreach (ComponentDamageStatus component in componentGroup_0.Components)
				{
					if (component.Component.GetArmor.ArmorRating != GlobalVariables.ArmorRating.None && !componentGroup_0.AsStoredAircraft)
					{
						jbuypMavrqZ.Insert(method_2(int_1, jbuypMavrqZ.Count), component);
					}
					else
					{
						list_0.Insert(method_2(int_0, list_0.Count), component);
					}
				}
				foreach (ComponentGroup neighbor in componentGroup_0.Neighbors)
				{
					if (!list_2.Contains(neighbor) && !list_1.Contains(neighbor))
					{
						list_1.Insert(method_2(int_2, list_1.Count), neighbor);
					}
				}
			}

			private int method_2(int int_0, int int_1)
			{
				return (int)Math.Round((double)int_0 + (double)(int_1 - int_0) * GameGeneral.GlobalRNG.NextDouble());
			}

			static UnitComponentGroupEvalState()
			{
				Class72.smethod_20();
			}
		}

		protected internal class ComponentDamageStatus
		{
			internal ComponentGroup ContainingGroup;

			internal int AllocatedDamage;

			internal PlatformComponent Component;

			internal bool DirectlyImpacted;

			internal float Volume;

			internal float Durability;

			protected internal ComponentDamageStatus(ComponentGroup Container, int AllocatedDamage, PlatformComponent Component, bool DirectlyImpacted = false, float Volume = 1f, float Durability = 1f)
			{
				ContainingGroup = Container;
				this.AllocatedDamage = AllocatedDamage;
				this.Component = Component;
				this.DirectlyImpacted = DirectlyImpacted;
				this.Volume = Volume;
				this.Durability = Durability;
			}

			static ComponentDamageStatus()
			{
				Class72.smethod_20();
			}
		}

		internal List<ComponentGroup> Groups;

		internal ComponentGroup ArmorExterior;

		internal double GetTotalVolume
		{
			get
			{
				double num = 0.0;
				foreach (ComponentGroup group in Groups)
				{
					num += group.GetTotalVolume;
				}
				return num;
			}
		}

		internal UnitComponentGroups()
		{
			Groups = new List<ComponentGroup>();
		}

		protected internal ComponentGroup AddGroup(bool IsArmor, bool InsideArmor, bool IsAirWing = false, string Location = "", GlobalVariables.ArmorRating Armor = GlobalVariables.ArmorRating.None)
		{
			ComponentGroup componentGroup = new ComponentGroup(IsArmor, InsideArmor, IsAirWing, this, Location, Armor);
			Groups.Add(componentGroup);
			return componentGroup;
		}

		protected internal void LinkComponentGroups(ComponentGroup Group1, ComponentGroup Group2)
		{
			Group1.Neighbors.Add(Group2);
			Group2.Neighbors.Add(Group1);
		}

		protected internal void RemoveReferences(ComponentGroup theCG)
		{
			foreach (ComponentGroup group in Groups)
			{
				if (group.Neighbors.Contains(theCG))
				{
					group.Neighbors.Remove(theCG);
				}
			}
		}

		protected internal ComponentDamageStatus GetTargetedComponent(float ArmorPenetration, int ARM_TargetedRadar)
		{
			if (ARM_TargetedRadar > 0)
			{
				List<ComponentDamageStatus> list = new List<ComponentDamageStatus>();
				foreach (ComponentGroup group in Groups)
				{
					foreach (ComponentDamageStatus component in group.Components)
					{
						if (component.Component.GetType() == typeof(Sensor))
						{
							Sensor sensor = (Sensor)component.Component;
							if (sensor.IsActive() && !sensor.IsMk1Eyeball && (sensor.DBID == ARM_TargetedRadar || sensor.MasqueradeAs == ARM_TargetedRadar))
							{
								list.Add(component);
							}
						}
					}
				}
				if (list.Any())
				{
					double num = 0.0;
					foreach (ComponentDamageStatus item in list)
					{
						num += (double)item.Volume;
					}
					num *= GameGeneral.GlobalRNG.NextDouble();
					foreach (ComponentDamageStatus item2 in list)
					{
						if (num >= (double)item2.Volume)
						{
							num -= (double)item2.Volume;
							continue;
						}
						return item2;
					}
				}
			}
			return GetRandomlyHitComponent(ArmorPenetration);
		}

		protected internal ComponentDamageStatus GetRandomlyHitComponent(float ArmorPenetration)
		{
			double num = GetTotalVolume * GameGeneral.GlobalRNG.NextDouble();
			foreach (ComponentGroup group in Groups)
			{
				double getTotalVolume = group.GetTotalVolume;
				if (num < group.GetTotalVolume)
				{
					foreach (ComponentDamageStatus component in group.Components)
					{
						if (num >= (double)component.Volume)
						{
							num -= (double)component.Volume;
							continue;
						}
						if (component.ContainingGroup.InsideArmor && GameGeneral.GlobalRNG.NextDouble() > (double)ArmorPenetration)
						{
							if (ArmorExterior == null)
							{
								return null;
							}
							if (!ArmorExterior.Components.Any())
							{
								double num2 = 0.0;
								foreach (ComponentGroup neighbor in ArmorExterior.Neighbors)
								{
									num2 += neighbor.GetTotalVolume;
								}
								double num3 = num2 * GameGeneral.GlobalRNG.NextDouble();
								foreach (ComponentGroup neighbor2 in ArmorExterior.Neighbors)
								{
									foreach (ComponentDamageStatus component2 in neighbor2.Components)
									{
										if (num3 >= (double)component2.Volume)
										{
											num3 -= (double)component2.Volume;
											continue;
										}
										return component2;
									}
								}
							}
							else
							{
								double num4 = ArmorExterior.GetTotalVolume * GameGeneral.GlobalRNG.NextDouble();
								foreach (ComponentDamageStatus component3 in ArmorExterior.Components)
								{
									if (num4 >= (double)component3.Volume)
									{
										num4 -= (double)component3.Volume;
										continue;
									}
									return component3;
								}
							}
						}
						return component;
					}
				}
				num -= getTotalVolume;
			}
			return null;
		}

		static UnitComponentGroups()
		{
			Class72.smethod_20();
		}
	}

	public enum DroneAutonomyLevel
	{
		Undefined = 0,
		RemotelyPiloted = 1000,
		SelfRecovering = 1500,
		ChangeableMission = 2000,
		FaultEventAdaptive = 3000,
		MultiVehicleCoordination = 4000,
		BattlespaceCognizant = 5000,
		FullyAutonomous = 6000
	}

	public enum OpsAvailabilityStatus : byte
	{
		IsAvailable,
		IsWinchester,
		IsUnderMaintenance,
		IsReserve,
		HasNoMissionLoadout
	}

	public enum Throttle : byte
	{
		FullStop,
		Loiter,
		Cruise,
		Full,
		Flank,
		External,
		MaxPossibleThrottle,
		MinPossibleThrottle
	}

	public enum _ActiveUnitStatus : byte
	{
		Unassigned = 0,
		OnPlottedCourse = 1,
		EngagedOffensive = 2,
		EngagedDefensive = 3,
		OnAttackRun = 4,
		OnPatrol = 5,
		RTB = 6,
		Tasked = 7,
		FormingUp = 8,
		RTB_Manual = 10,
		OnSupportMission = 11,
		OnFerryMission = 12,
		HeadingToRefuelPoint = 13,
		Refuelling = 14,
		RTB_MissionOver = 15,
		GroupLead_SlowingToAllowFormUp = 16,
		RTB_Group = 19,
		RTB_CalledOff = 20,
		WaitForPathfinder = 21,
		AttemptingToReestablishComms = 22,
		AvoidingWeaponEffects = 23,
		RTB_CommsLost = 24,
		OnFireMission = 25,
		ExternalControl = 30,
		RTB_Exhaustion = 99,
		Manual_Unassigned = 98
	}

	public enum _ActiveUnitFuelState : byte
	{
		None,
		IsBingo,
		IsJoker,
		IgnoreBingoAndJoker
	}

	public enum _ActiveUnitWeaponState : sbyte
	{
		Undefined = -1,
		None,
		IsWinchester,
		IsWinchester_EngagingToO,
		IsShotgun,
		IsShotgun_EngagingToO,
		IgnoreWinchesterAndShotgun
	}

	public enum GroupMemberType : byte
	{
		None
	}

	public enum NotificationType
	{
		None,
		Baloon,
		Bark
	}

	public enum AirContrailSize : byte
	{
		NoContrail,
		VSmall,
		Small,
		Medium,
		Large,
		VLarge
	}

	public struct _UNREP_Capabilities
	{
		internal byte Refuel_Front_In;

		internal byte Refuel_Front_Out;

		internal byte Refuel_Astern_In;

		internal byte Refuel_Astern_Out;

		internal byte Refuel_Port_In;

		internal byte Refuel_Port_Out;

		internal byte Refuel_Starboard_In;

		internal byte Refuel_Starboard_Out;

		internal byte Replenish_Port_In;

		internal byte Replenish_Port_Out;

		internal byte Replenish_Starboard_In;

		internal byte Replenish_Starboard_Out;
	}

	public class ActiveUnit_Struct
	{
		public Side UnitSide;

		public string ObjectId;

		public string Name;

		public int DBID;

		private static readonly ActiveUnit_Struct activeUnit_Struct_0;

		static ActiveUnit_Struct()
		{
			Class72.smethod_20();
			activeUnit_Struct_0 = new ActiveUnit_Struct();
		}

		public ActiveUnit_Struct()
		{
		}

		public ActiveUnit_Struct(Side theSide, string objectId, string name, int _DBID)
		{
			UnitSide = theSide;
			ObjectId = objectId;
			DBID = _DBID;
			Name = name;
		}

		public bool isDefaultvalue()
		{
			return Equals(activeUnit_Struct_0);
		}

		public override bool Equals(object obj)
		{
			bool result;
			try
			{
				if ((object)obj.GetType() == typeof(ActiveUnit_Struct))
				{
					ActiveUnit_Struct activeUnit_Struct = (ActiveUnit_Struct)obj;
					result = Operators.CompareString(UnitSide?.ObjectID, activeUnit_Struct.UnitSide?.ObjectID, false) == 0 && Operators.CompareString(ObjectId, activeUnit_Struct.ObjectId, false) == 0 && Operators.CompareString(Name, activeUnit_Struct.Name, false) == 0 && DBID == activeUnit_Struct.DBID;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 6216546516351", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num = 0;
				}
				else
				{
					num = 0;
				}
				result = (byte)num != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
		{
			try
			{
				theWriter.WriteStartElement("ActiveUnit");
				theWriter.WriteElementString("ID", ObjectId);
				theWriter.WriteElementString("Name", Name);
				if (UnitSide != null)
				{
					theWriter.WriteElementString("Side", UnitSide.Name);
				}
				else
				{
					theWriter.WriteElementString("Side", "");
				}
				theWriter.WriteElementString("DBID", DBID.ToString());
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 19876590817", " ActiveUnit_Struct Name: " + Name + " DBID: " + Conversions.ToString(DBID) + " ObjectID: " + ObjectId);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static ActiveUnit_Struct FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			ActiveUnit_Struct result;
			try
			{
				ActiveUnit_Struct activeUnit_Struct = new ActiveUnit_Struct();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "ID":
						activeUnit_Struct.ObjectId = val.InnerText;
						break;
					case "DBID":
						activeUnit_Struct.DBID = int.Parse(val.InnerText);
						break;
					case "Side":
						activeUnit_Struct.UnitSide = Side.FromXML_ByName(val.InnerText, ref theDictionary, theScen);
						break;
					case "Name":
						activeUnit_Struct.Name = val.InnerText;
						break;
					}
				}
				result = activeUnit_Struct;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100865", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new ActiveUnit_Struct();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public class Str_TemporaryEmission
	{
		public enum SignatureOperator
		{
			Factor,
			Absolute
		}

		public DateTime TerminationDate;

		public float SignatureMultiplier;

		public float SignatureAbsoluteIncrease;

		public int Duration;

		public Str_TemporaryEmission(float _SignatureMultiplier, float _SignatureAbsoluteIncrease, int _DurationCountDown, ActiveUnit Unit)
		{
			SignatureMultiplier = _SignatureMultiplier;
			TerminationDate = Unit.ParentScen.Time;
			TerminationDate.AddSeconds(_DurationCountDown);
			if (SignatureMultiplier < -1f)
			{
				SignatureMultiplier = 0f;
			}
		}

		internal bool HasTimedOut(DateTime Time)
		{
			if (DateTime.Compare(TerminationDate, Time) > 0)
			{
				return true;
			}
			return false;
		}

		static Str_TemporaryEmission()
		{
			Class72.smethod_20();
		}
	}

	public ActiveUnit_DockingOps DockingOps;

	internal GlobalVariables.ActiveUnitType UnitType;

	internal bool IsDLZconstruct;

	public static float WEAPON_TOT_ACCEPTABLE_ERROR;

	public static float FP_RECALC_THREASHOLD;

	public short OODA_Targeting_Actual;

	public int DBID;

	public short IsMCMPlatform_ThisPulse;

	public short IsMineLayingPlatform_ThisPulse;

	public bool IsDecoy;

	private PooledList<string> pooledList_0;

	public bool LoiteredThisPulse;

	public bool ActualSpeedReducedByTerrain;

	public PooledList<(string, DateTime)> Kills;

	internal Mission PrivateSnapshotMission;

	internal DroneAutonomyLevel AutonomyLevel;

	internal float EngineProportionalWeight;

	internal long TimeOnLastPulse;

	private DateTime? nullable_9;

	private string string_1;

	private double? nullable_10;

	private double? nullable_11;

	private float? nullable_12;

	private float? nullable_13;

	internal double Longitude_AtStartOfPulse;

	internal double Latitude_AtStartOfPulse;

	protected float _DesiredHeading;

	protected float _DesiredSpeed;

	protected float _DesiredAltitude;

	protected float _DesiredAltitude_AGL;

	protected TurnRate _DesiredTurnRate;

	protected Waypoint.TurnRateCategory _DesiredTurnRate_Navigation;

	protected bool _TerrainFollowing;

	public float Length;

	private Geopoint_Struct? nullable_14;

	public float SettledTime;

	private float float_6;

	public ActiveUnit_DockingOps.ResupplyCapacity? _DesignatedSupplier;

	public AggregateGroundUnit aggregateGroundUnit_0;

	public TerrainFollowMode TerrainFollowingType;

	[CompilerGenerated]
	private bool bool_0;

	public int EmptyWeight;

	public int MaxWeight;

	public int MaxPayloadWeight;

	public Scenario ParentScen;

	public ActiveUnit AttachedTo;

	protected Throttle _ThrottleSetting;

	[AccessedThroughProperty("_Sensors")]
	[CompilerGenerated]
	private ObservableList<Sensor> observableList_0;

	protected CommDevice[] _Comms;

	[CompilerGenerated]
	[AccessedThroughProperty("Propulsion")]
	private ObservableList<Engine> observableList_1;

	protected PooledList<FuelRec> _Fuel;

	private XSection[] xsection_0;

	[AccessedThroughProperty("Mounts")]
	[CompilerGenerated]
	private ObservableList<Mount> observableList_2;

	public Mount[] Mounts_AsArray;

	public Cargo[] OnboardCargo;

	protected _ActiveUnitStatus _Status;

	protected _ActiveUnitFuelState _FuelState;

	protected _ActiveUnitWeaponState _WeaponState;

	private float float_7;

	protected AirFacility[] _AirFacilities;

	protected DockFacility[] _DockFacilities;

	protected Mission _AssignedMission;

	protected string _AssignedMission_ID;

	protected Mission _AssignedMissionOrPackage;

	protected string _AssignedMissionOrPackage_ID;

	protected Mission _AssignedTaskPool;

	public Dictionary<Mission, Mission> AssignedMissionsQueue;

	public List<string> _AssignedMissionsQueue_ID;

	internal bool AllowMultiMission;

	protected string _AssignedTaskPool_ID;

	internal bool IsMorituri;

	public bool IsCivilian;

	protected Group _ParentGroup;

	protected string _ParentGroup_ID;

	private bool bool_1;

	public Doctrine Doctrine;

	internal bool StateChangedOnThisPulse;

	protected string _SideName;

	public bool HasCustomOODA;

	internal short OODA_Detection;

	internal short OODA_Targeting;

	internal short OODA_Evasion;

	internal bool TargetsEvaluatedOnThisPulse;

	internal bool ThreatsEvaluatedOnThisPulse;

	private Throttle? nullable_15;

	internal _ActiveUnitStatus _Status_Oldvalue;

	internal float _OldDamagePercent;

	internal _ActiveUnitStatus _StatusBefore_NeedToRefuel;

	internal _ActiveUnitStatus _StatusBefore_EngagedDefensive;

	internal _ActiveUnitStatus _StatusBefore_EngagedOffensive;

	internal _ActiveUnitStatus _StatusBefore_WaitForPathfinder;

	internal bool _MissionPlannerOverrideCancellation;

	internal float? _MissionPlannerOverrideCancellation_DesiredSpeedOverride;

	internal bool _MissionPlannerOverrideCancellation_DesiredAltitudeOverride;

	internal float _MissionPlannerOverrideCancellation_Speed;

	internal _ActiveUnitFuelState _FuelStateBefore_NeedToRefuel;

	internal float _AltitudeBefore_NeedToRefuel;

	internal float _AltitudeBefore_NeedToRefuel_AGL;

	internal bool _TerrainFollowingBefore_NeedToRefuel;

	internal Throttle _ThrottleBefore_NeedToRefuel;

	internal float _AltitudeBefore_EngagedDefensive;

	internal float? _AltitudeBefore_EngagedDefensive_AGL;

	internal bool _TerrainFollowingBefore_EngagedDefensive;

	internal Throttle _ThrottleBefore_EngagedDefensive;

	internal float? _DesiredSpeedOverrideBefore_EngagedDefensive;

	internal float _AltitudeBefore_EngagedOffensive;

	internal float _AltitudeBefore_EngagedOffensive_AGL;

	internal bool _TerrainFollowingBefore_EngagedOffensive;

	internal Throttle _ThrottleBefore_EngagedOffensive;

	internal float _AltitudeBefore_WaitForPathfinder;

	internal float _AltitudeBefore_WaitForPathfinder_AGL;

	internal bool _TerrainFollowingBefore_WaitForPathfinder;

	internal Throttle _ThrottleBefore_WaitForPathfinder;

	public float TimeSinceLastThreatDetection_ESM;

	protected GlobalVariables.ProficiencyLevel? _Proficiency;

	private int int_1;

	public bool Hypothetical;

	private string string_2;

	public bool IsBeingDestroyed;

	public Weapon[] IncomingGuidedWeaponsList;

	public bool IsBeingPickedUp;

	public bool EligibleForSAR;

	public ActiveUnit PickUpUnit;

	private int int_2;

	public Mission.Flight.FlightElement FlightRole;

	public GroupMemberType GroupRole;

	public int ChanceOfAppearance;

	public bool IsDumbAU;

	public float TimeUnderway;

	public _UNREP_Capabilities UNREP_Capabilities;

	private ActiveUnit_Navigator activeUnit_Navigator_0;

	protected ActiveUnit_AI _AI;

	private ActiveUnit_Kinematics activeUnit_Kinematics_0;

	protected ActiveUnit_Sensory _Sensory;

	private ActiveUnit_Weaponry activeUnit_Weaponry_0;

	protected ActiveUnit_CommStuff _CommStuff;

	protected ActiveUnit_Damage _Damage;

	protected ActiveUnit_AirOps _AirOps;

	internal bool bool_2;

	internal List<string> OldIDs_AirFacilities;

	internal List<XmlNode> OldIds_Mounts;

	public List<Cargo> CargoTransferList;

	[CompilerGenerated]
	private static ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler_0;

	[CompilerGenerated]
	private static ParentGroupChangedEventHandler parentGroupChangedEventHandler_0;

	[CompilerGenerated]
	private static NameChangedEventHandler nameChangedEventHandler_0;

	[CompilerGenerated]
	private static ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler_0;

	[CompilerGenerated]
	private static ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler_0;

	protected bool _DestroyEventsChecked;

	private static Str_TemporaryEmission[] str_TemporaryEmission_0;

	public Str_TemporaryEmission[] TemporaryEmissionEM;

	public StoredCourse Journey;

	public bool IsStoringJourney;

	private int int_3;

	protected LockObject _MineCountermeasures_Lock;

	protected List<Sensor> _MineCountermeasures;

	private LockObject lockObject_0;

	private Sensor[] sensor_0;

	private int int_4;

	protected bool _IsPerformingStandoffAttack;

	[CompilerGenerated]
	private string string_3;

	public bool FollowingPCThatIsRTB
	{
		get
		{
			int result;
			if (Navigator.PlottedCourse != null)
			{
				Waypoint[] plottedCourse = Navigator.PlottedCourse;
				foreach (Waypoint waypoint in plottedCourse)
				{
					if ((waypoint.Type == Waypoint.WaypointType.Land) | (waypoint.Type == Waypoint.WaypointType.LandingMarshal))
					{
						return true;
					}
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool FollowingPCThatIsPathfinderGeneratedAndLeadsToAssignedHost
	{
		get
		{
			if (Navigator.PlottedCourse != null && Navigator.PlottedCourse.Length > 0)
			{
				Waypoint waypoint = Navigator.PlottedCourse.Last();
				if (waypoint.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					ActiveUnit activeUnit = null;
					activeUnit = (IsAircraft ? ((Aircraft)this).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) : DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false));
					if (activeUnit != null)
					{
						Geopoint_Struct landingQueueAssemblyPoint = activeUnit.AirOps.LandingQueueAssemblyPoint;
						int result;
						if (!(Math2.CalcDist(activeUnit, waypoint) < 1f))
						{
							if (!(Math2.CalcDist(landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude, waypoint.Latitude, waypoint.Longitude) < 1f))
							{
								goto IL_00c0;
							}
							result = 1;
						}
						else
						{
							result = 1;
						}
						return (byte)result != 0;
					}
				}
			}
			goto IL_00c0;
			IL_00c0:
			return false;
		}
	}

	public bool isTaggedAsDecoyByThisSide
	{
		get
		{
			if (pooledList_0.Contains(theSideID))
			{
				return true;
			}
			bool result = default(bool);
			return result;
		}
	}

	public float TemporaryBlindness
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = Math.Min(Math.Max(value, 0f), 240f);
		}
	}

	public bool LandCoverMaskingCapability
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public float MaxSpeed
	{
		get
		{
			float result;
			try
			{
				result = Kinematics.GetMaximumSpeed();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = 0f;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	protected virtual ObservableList<Sensor> _Sensors
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Sensor>> value2 = method_10;
			EventHandler<object> value3 = method_11;
			EventHandler<ObservableListModified<Sensor>> value4 = method_12;
			ObservableList<Sensor> observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsCleared -= value3;
				observableList.ItemsRemoved -= value4;
			}
			observableList_0 = value;
			observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsCleared += value3;
				observableList.ItemsRemoved += value4;
			}
		}
	}

	public virtual ObservableList<Engine> Propulsion
	{
		[CompilerGenerated]
		get
		{
			return observableList_1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Engine>> value2 = method_8;
			EventHandler<ObservableListModified<Engine>> value3 = method_9;
			ObservableList<Engine> observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsRemoved -= value3;
			}
			observableList_1 = value;
			observableList = observableList_1;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsRemoved += value3;
			}
		}
	}

	public virtual ObservableList<Mount> Mounts
	{
		[CompilerGenerated]
		get
		{
			return observableList_2;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Mount>> value2 = pIvLodjowEQ;
			EventHandler<ObservableListModified<Mount>> value3 = method_6;
			EventHandler<object> value4 = method_7;
			EventHandler<ObservableListModified<Mount>> value5 = method_13;
			EventHandler<ObservableListModified<Mount>> value6 = method_14;
			EventHandler<object> value7 = method_15;
			ObservableList<Mount> observableList = observableList_2;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsRemoved -= value3;
				observableList.ItemsCleared -= value4;
				observableList.ItemsAdded -= value5;
				observableList.ItemsRemoved -= value6;
				observableList.ItemsCleared -= value7;
			}
			observableList_2 = value;
			observableList = observableList_2;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsRemoved += value3;
				observableList.ItemsCleared += value4;
				observableList.ItemsAdded += value5;
				observableList.ItemsRemoved += value6;
				observableList.ItemsCleared += value7;
			}
		}
	}

	public virtual float MAX_Exhaustion => 100f;

	public virtual float Current_Exhaustion => 0f;

	public virtual ActiveUnit CurrentHostUnitCargoSource
	{
		get
		{
			if (IsAircraft)
			{
				return ((Aircraft)this).AirOps.CurrentHostUnit;
			}
			if ((IsShip || IsSubmarine || (IsVehicle && ((Vehicle)this).IsAmphibiousSeaworthy)) && DockingOps.CurrentHostUnit != null && DockingOps.CurrentHostUnit.IsGroupMember())
			{
				Group.GroupType? groupType = DockingOps.CurrentHostUnit.get_ParentGroup(UsingMissionPlanner: false)?.Type;
				byte? b = (byte?)groupType;
				bool? flag2;
				bool? flag = (flag2 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)));
				bool? obj;
				bool? flag3;
				if (flag.HasValue && flag2 == true)
				{
					obj = true;
				}
				else
				{
					b = (byte?)groupType;
					flag = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)));
					obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
				}
				bool? flag4 = obj;
				flag3 = obj;
				bool? obj2;
				bool? flag5;
				if (flag3.HasValue && flag4 == true)
				{
					obj2 = true;
				}
				else
				{
					b = (byte?)groupType;
					flag3 = (flag5 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 6)));
					obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
				}
				flag5 = obj2;
				if (flag5 == true)
				{
					return DockingOps.CurrentHostUnit.get_ParentGroup(UsingMissionPlanner: false);
				}
			}
			return DockingOps.CurrentHostUnit;
		}
	}

	public int OperatorCountryCode
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			if ((uint)(value - 1101) > 1u)
			{
				IsCivilian = false;
			}
			else
			{
				IsCivilian = true;
			}
		}
	}

	public virtual ActiveUnit AssignedHostUnitCargoSource
	{
		get
		{
			ActiveUnit activeUnit = DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			bool flag = false;
			if (IsAircraft)
			{
				activeUnit = ((Aircraft)this).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false);
				flag = true;
				goto IL_0057;
			}
			int num;
			if (!IsShip)
			{
				if (IsSubmarine)
				{
					num = 1;
					goto IL_0056;
				}
				if (!IsVehicle || !((Vehicle)this).IsAmphibiousSeaworthy)
				{
					goto IL_0057;
				}
			}
			num = 1;
			goto IL_0056;
			IL_0057:
			if (flag && activeUnit != null && activeUnit.IsGroupMember())
			{
				Group.GroupType? groupType = activeUnit.get_ParentGroup(UsingMissionPlanner: false)?.Type;
				byte? b = (byte?)groupType;
				bool? flag3;
				bool? flag2 = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 5)));
				bool? obj;
				bool? flag4;
				if (flag2.HasValue && flag3 == true)
				{
					obj = true;
				}
				else
				{
					b = (byte?)groupType;
					flag2 = (flag4 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)));
					obj = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag3));
				}
				bool? flag5 = obj;
				flag4 = obj;
				bool? obj2;
				bool? flag6;
				if (flag4.HasValue && flag5 == true)
				{
					obj2 = true;
				}
				else
				{
					b = (byte?)groupType;
					flag4 = (flag6 = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 6)));
					obj2 = ((!flag4.HasValue) ? ((bool?)null) : ((flag6 == true) | flag5));
				}
				flag6 = obj2;
				if (flag6 == true)
				{
					activeUnit = activeUnit.get_ParentGroup(UsingMissionPlanner: false);
				}
			}
			if (IsVehicle && activeUnit == null)
			{
				return DockingOps.OriginalCargoHostUnit;
			}
			return activeUnit;
			IL_0056:
			flag = (byte)num != 0;
			goto IL_0057;
		}
	}

	internal override string Name
	{
		get
		{
			if (!IsWeapon && IsDecoy)
			{
				if (!base.Name.Contains("[DECOY]"))
				{
					return "[DECOY] " + base.Name;
				}
				return base.Name;
			}
			return base.Name;
		}
		set
		{
			Operators.CompareString(base.Name, value, false);
			base.Name = value;
			nameChangedEventHandler_0?.Invoke(ObjectID);
		}
	}

	public DateTime? LastReportedInfo_MostRecentUpdateTime
	{
		get
		{
			if (!nullable_9.HasValue || ParentScen == null)
			{
				nullable_9 = ParentScen.Time;
			}
			return nullable_9;
		}
	}

	public string LastReportedInfo_MostRecentReportingUnitObjectID
	{
		get
		{
			if (string.IsNullOrEmpty(string_1))
			{
				string_1 = ObjectID;
			}
			return string_1;
		}
	}

	public double? Latitude_LastReported
	{
		get
		{
			if (!nullable_11.HasValue)
			{
				nullable_11 = this.get_Latitude((GlobalVariables.BooleanObject)null);
			}
			return nullable_11;
		}
	}

	public double? Longitude_LastReported
	{
		get
		{
			if (!nullable_10.HasValue)
			{
				nullable_10 = this.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			return nullable_10;
		}
	}

	public float? Altitude_LastReported
	{
		get
		{
			if (!nullable_12.HasValue)
			{
				nullable_12 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			return nullable_12;
		}
	}

	public float? Heading_LastReported
	{
		get
		{
			if (!nullable_13.HasValue)
			{
				nullable_13 = CurrentHeading;
			}
			return nullable_13;
		}
	}

	public int InitialDP
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public virtual bool IsBallisticMissile => false;

	public override float Attitude_Pitch
	{
		get
		{
			if (SupportsAttitude_Pitch)
			{
				return _Attitude_Pitch;
			}
			if (IsWeapon && ((Weapon)this).IsWeaponPallet)
			{
				return _Attitude_Pitch;
			}
			if (!IsFacility && !IsShip)
			{
				float num = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - base.Altitude_old;
				if (num == 0f)
				{
					return 0f;
				}
				double x = (double)CurrentSpeed * 0.514444 * (double)ParentScen.GameResolution;
				double num2 = Math.Atan2(Math.Abs(num), x) * 57.2957795130823;
				if (num > 0f)
				{
					return (float)num2;
				}
				return 0f - (float)num2;
			}
			return 0f;
		}
		set
		{
			base.Attitude_Pitch = value;
		}
	}

	public override double Longitude
	{
		get
		{
			if (aggregateGroundUnit_0 != null)
			{
				return ((ActiveUnit)aggregateGroundUnit_0).get_Longitude((GlobalVariables.BooleanObject)null);
			}
			if (!((_HintIsOperating == null) ? IsOperating() : (_HintIsOperating == GlobalVariables.ObjectTrue)))
			{
				ActiveUnit currentHostUnit = DockingOps.CurrentHostUnit;
				if (currentHostUnit != null)
				{
					return currentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				}
				if (!IsBeingDestroyed)
				{
					_ = Debugger.IsAttached;
				}
				return 0.0;
			}
			return _Longitude;
		}
		set
		{
			base.set_Longitude((GlobalVariables.BooleanObject)null, value);
			DockingOps.ResetPierEntranceLaneCache();
		}
	}

	public override double Latitude
	{
		get
		{
			if (aggregateGroundUnit_0 == null)
			{
				if (!((_HintIsOperating != null) ? (_HintIsOperating == GlobalVariables.ObjectTrue) : IsOperating()))
				{
					ActiveUnit currentHostUnit = DockingOps.CurrentHostUnit;
					if (currentHostUnit == null)
					{
						if (!IsBeingDestroyed)
						{
							_ = Debugger.IsAttached;
						}
						return 0.0;
					}
					return currentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				}
				return _Latitude;
			}
			return ((ActiveUnit)aggregateGroundUnit_0).get_Latitude((GlobalVariables.BooleanObject)null);
		}
		set
		{
			base.set_Latitude((GlobalVariables.BooleanObject)null, value);
			DockingOps.ResetPierEntranceLaneCache();
		}
	}

	public override float CurrentHeading
	{
		get
		{
			if (aggregateGroundUnit_0 == null)
			{
				return base.CurrentHeading;
			}
			return aggregateGroundUnit_0.CurrentHeading;
		}
		set
		{
			base.CurrentHeading = Math2.NormalizeBearing(value);
			DockingOps.ResetPierEntranceLaneCache();
		}
	}

	public virtual GlobalVariables.ProficiencyLevel? Proficiency
	{
		get
		{
			GlobalVariables.ProficiencyLevel? result;
			if (_Proficiency.HasValue)
			{
				result = _Proficiency.Value;
			}
			else if (this.get_UnitSide(SetSideOnly: false) != null)
			{
				result = this.get_UnitSide(SetSideOnly: false).Proficiency;
			}
			else
			{
				if (this is Weapon && !((Weapon)this).IsDLZconstruct && Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = GlobalVariables.ProficiencyLevel.Regular;
			}
			return result;
		}
		set
		{
			_Proficiency = value;
			int? num = (int?)value;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) != true)
			{
				num = (int?)value;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
				{
					num = (int?)value;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
					{
						OODA_Targeting_Actual = (short)Math.Round((double)OODA_Targeting * 1.2);
						return;
					}
					num = (int?)value;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
					{
						num = (int?)value;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) == true)
						{
							OODA_Targeting_Actual = (short)Math.Round((double)OODA_Targeting * 0.8);
							return;
						}
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						OODA_Targeting_Actual = 0;
					}
					else
					{
						OODA_Targeting_Actual = OODA_Targeting;
					}
				}
				else
				{
					OODA_Targeting_Actual = (short)Math.Round((double)OODA_Targeting * 1.5);
				}
			}
			else
			{
				OODA_Targeting_Actual = (short)(OODA_Targeting * 2);
			}
		}
	}

	public virtual bool HasSystemsRunning
	{
		get
		{
			if (IsOperating())
			{
				return true;
			}
			int result;
			switch (DockingOps.Condition)
			{
			case ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo:
				result = 0;
				break;
			default:
				return true;
			case ActiveUnit_DockingOps._DockingOpsCondition.Docked:
			case ActiveUnit_DockingOps._DockingOpsCondition.Readying:
				result = 0;
				break;
			}
			return (byte)result != 0;
		}
	}

	public string UnitType_String
	{
		get
		{
			if (string.IsNullOrEmpty(string_2))
			{
				if (IsGroup)
				{
					return "Group";
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					string_2 = "Aircraft";
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					string_2 = "Ship";
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					string_2 = "Submarine";
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					string_2 = "Facility";
					break;
				case GlobalVariables.ActiveUnitType.Weapon:
					string_2 = "Weapon";
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					string_2 = "Satellite";
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					string_2 = "Ground Unit";
					break;
				default:
					if (!Debugger.IsAttached)
					{
						return UnitType.ToString();
					}
					Debugger.Break();
					break;
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
					string_2 = "AggregateUnit";
					break;
				}
			}
			return string_2;
		}
	}

	public XSection[] XSections_ReadOnly
	{
		get
		{
			if (xsection_0 == null)
			{
				string key = UnitType_String + "_" + Conversions.ToString(DBID);
				if (ParentScen.Cache_XSections.ContainsKey(key))
				{
					xsection_0 = ParentScen.Cache_XSections[key];
				}
				else
				{
					xsection_0 = DBFunctions.GetXSections(this);
					ParentScen.Cache_XSections.TryAdd(key, xsection_0);
				}
			}
			return xsection_0;
		}
	}

	public int SubType
	{
		get
		{
			if (int_3 <= -1)
			{
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					int_3 = DBFunctions.GetAircraftType_Int(ref ParentScen, DBID);
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					int_3 = DBFunctions.GetShipType_Int(ref ParentScen, DBID);
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					int_3 = DBFunctions.GetSubmarineType_Int(ref ParentScen, DBID);
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					int_3 = DBFunctions.GetFacilityCategory_Int(ref ParentScen, DBID);
					break;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case GlobalVariables.ActiveUnitType.Weapon:
					int_3 = DBFunctions.GetWeaponType_Int(ref ParentScen, DBID);
					break;
				case GlobalVariables.ActiveUnitType.Satellite:
					int_3 = DBFunctions.GetSatelliteType_Int(ref ParentScen, DBID);
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					int_3 = DBFunctions.GetVehicleType_Int(ref ParentScen, DBID);
					break;
				}
				return int_3;
			}
			return int_3;
		}
	}

	public virtual string SubTypeDescription
	{
		get
		{
			string text = "";
			switch (UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				return DBFunctions.GetAircraftType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Ship:
				return DBFunctions.GetShipType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Submarine:
				return DBFunctions.GetSubmarineType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Facility:
				return DBFunctions.GetFacilityType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Weapon:
				return DBFunctions.GetWeaponType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Satellite:
				return DBFunctions.GetSatelliteType_String(ref ParentScen, DBID);
			case GlobalVariables.ActiveUnitType.Vehicle:
				return DBFunctions.GetGroundUnitType_String(ref ParentScen, DBID);
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return UnitType.ToString();
			case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
				return "Aggregate Ground Unit";
			}
		}
	}

	public override bool UseAerialUnitUI
	{
		get
		{
			if (!IsAircraft)
			{
				return false;
			}
			return true;
		}
	}

	public override bool UseSubmerisbleUnitUI
	{
		get
		{
			if (!IsSubmarine)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsAerospaceUnit
	{
		get
		{
			int result;
			int result2;
			switch (UnitType)
			{
			default:
			{
				int result3;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					result3 = 0;
				}
				else
				{
					result3 = 0;
				}
				return (byte)result3 != 0;
			}
			case GlobalVariables.ActiveUnitType.Weapon:
			{
				Weapon._WeaponType type = ((Weapon)this).Type;
				if (type <= Weapon._WeaponType.GuidedProjectile)
				{
					if ((uint)(type - 2001) > 2u)
					{
						if (type != Weapon._WeaponType.Decoy_Vehicle && type != Weapon._WeaponType.GuidedProjectile)
						{
							result = 0;
							goto IL_009e;
						}
						goto IL_00a1;
					}
					result2 = 1;
				}
				else
				{
					if (type == Weapon._WeaponType.UAV_Expendable || (uint)(type - 5000) <= 2u)
					{
						goto IL_00a1;
					}
					if (type != Weapon._WeaponType.HGV)
					{
						result = 0;
						goto IL_009e;
					}
					result2 = 1;
				}
				goto IL_00a2;
			}
			case GlobalVariables.ActiveUnitType.Aircraft:
			case GlobalVariables.ActiveUnitType.Satellite:
				return true;
			case GlobalVariables.ActiveUnitType.None:
			case GlobalVariables.ActiveUnitType.Ship:
			case GlobalVariables.ActiveUnitType.Submarine:
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
			case GlobalVariables.ActiveUnitType.Personnel:
				return false;
			case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
				{
					return false;
				}
				IL_009e:
				return (byte)result != 0;
				IL_00a1:
				result2 = 1;
				goto IL_00a2;
				IL_00a2:
				return (byte)result2 != 0;
			}
		}
	}

	public bool IsHardTarget
	{
		get
		{
			GlobalVariables.ActiveUnitType unitType = UnitType;
			if (unitType == GlobalVariables.ActiveUnitType.Facility)
			{
				Facility._FacilityCategory category = ((Facility)this).Category;
				int result;
				if (category > Facility._FacilityCategory.Building_Underground)
				{
					if (category != Facility._FacilityCategory.SurfaceAndUnderground)
					{
						if (category != Facility._FacilityCategory.AirBase)
						{
							goto IL_0050;
						}
						result = 1;
					}
					else
					{
						result = 1;
					}
				}
				else if ((uint)(category - 2001) <= 2u)
				{
					result = 1;
				}
				else
				{
					if ((uint)(category - 3003) > 1u)
					{
						goto IL_0050;
					}
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
			IL_0050:
			return false;
		}
	}

	public bool IsEligibleForAutodetection
	{
		get
		{
			if (this.get_IsAutoDetectable(DetectorSide))
			{
				return true;
			}
			return false;
		}
	}

	public bool IsOnActiveMission
	{
		get
		{
			Mission mission = ActiveMissionOrPackage();
			if (mission == null)
			{
				return false;
			}
			if (mission.IsActive)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsOnActiveStrike
	{
		get
		{
			Mission mission = ActiveMissionOrPackage();
			if (mission != null)
			{
				if (mission.IsActive)
				{
					return mission.MissionClass == Mission._MissionClass.Strike;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnActiveMiningMission
	{
		get
		{
			Mission mission = ActiveMissionOrPackage();
			if (mission != null)
			{
				if (!mission.IsActive)
				{
					return false;
				}
				return mission.MissionClass == Mission._MissionClass.Mining;
			}
			return false;
		}
	}

	public bool IsOnActiveMineClearingMission
	{
		get
		{
			Mission mission = ActiveMissionOrPackage();
			if (mission == null)
			{
				return false;
			}
			if (!mission.IsActive)
			{
				return false;
			}
			return mission.MissionClass == Mission._MissionClass.MineClearing;
		}
	}

	public bool IsOnActiveCargoMission
	{
		get
		{
			Mission mission = ActiveMissionOrPackage();
			if (mission != null)
			{
				if (!mission.IsActive)
				{
					return false;
				}
				return mission.MissionClass == Mission._MissionClass.Cargo;
			}
			return false;
		}
	}

	public bool IsOnActiveFerryMission
	{
		get
		{
			Mission mission = ActiveMissionOrPackage();
			if (mission == null)
			{
				return false;
			}
			if (!mission.IsActive)
			{
				return false;
			}
			return mission.MissionClass == Mission._MissionClass.Ferry;
		}
	}

	public virtual _ActiveUnitFuelState IsBingoOrJoker => _ActiveUnitFuelState.None;

	public virtual _ActiveUnitFuelState IsBingoTowardsThisDestination
	{
		get
		{
			_ActiveUnitFuelState result = default(_ActiveUnitFuelState);
			try
			{
				if (this.get_FuelEndurance(Throttle.Cruise, (AltBand)null, (float?)null, (float?)null) <= 900L)
				{
					result = _ActiveUnitFuelState.IsBingo;
					return result;
				}
				float num;
				if (IntermediatePoint == null)
				{
					num = RangeToUnit_Horiz_Alt(theDestination, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
				}
				else
				{
					float num2 = Module_Unit.RangeToPoint_Horiz(theDestination, IntermediatePoint);
					num = Module_Unit.RangeToPoint_Horiz(this, IntermediatePoint) + num2;
				}
				if ((double)Kinematics.MaxRange(BingoFuelCheck: true, null, null) >= (double)num * 1.1)
				{
					result = _ActiveUnitFuelState.None;
					return result;
				}
				result = _ActiveUnitFuelState.IsBingo;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101183", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public Weather.WeatherProfile WeatherAtMyLocation
	{
		get
		{
			if (ParentScen.WeatherLevel != Scenario.WeatherModellingLevel.Level0)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			}
			return Weather.get_WeatherAtThisTimeAndPlace(ParentScen, this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
		}
	}

	public virtual float DamagePts
	{
		get
		{
			return float_7;
		}
		set
		{
			try
			{
				bool flag = float_7 != value;
				float damagePercent = Damage.DamagePercent;
				float num = float_7;
				if (IsFacility && AirFacilities_ReadOnly != null && AirFacilities_ReadOnly.Where([SpecialName] (AirFacility AF) => AF.IsOpenAirFacility).Any() && 0f - value < (float)(InitialDP * 100))
				{
					value = Math.Max(1f, value);
				}
				float_7 = value;
				float damagePercent2 = Damage.DamagePercent;
				if (ScenEditAction)
				{
					return;
				}
				if (float_7 <= 0f && float_7 != num)
				{
					if (!IsShip)
					{
						ParentScen.DestroyThisUnit(this, "Unit has suffered catastrophic structural damage.", "Weapon Interaction");
					}
					else if (!IsBeingDestroyed)
					{
						((Ship)this).CommenceSinking(damagePercent);
					}
				}
				if ((IsShip && ((Ship)this).IsSinking) || (!flag && damagePercent == damagePercent2) || !(value < num))
				{
					return;
				}
				if (ParentScen.EventTriggers.Count > 0)
				{
					List<EventTrigger> list = new List<EventTrigger>();
					foreach (EventTrigger value2 in ParentScen.EventTriggers.Values)
					{
						if (value2.Type == EventTrigger.EventTriggerType.UnitDamaged && ((EventTrigger_UnitDamaged)value2).get_IsFulfilled(this, damagePercent, damagePercent2, (ActiveUnit)theWeapon))
						{
							list.Add(value2);
						}
					}
					ParentScen.FireEvents(list);
				}
				_OldDamagePercent = damagePercent2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101184", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool IsSpecificTargetForThisStrike
	{
		get
		{
			if (theStrike.TargetCount != 0)
			{
				if (!theStrike.SpecificTargets.Contains(this))
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public float CurrentAltitude_Binding
	{
		get
		{
			return this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		set
		{
			this.set_CurrentAltitude(DoSanityCheck: true, (GlobalVariables.BooleanObject)null, value);
		}
	}

	public override float CurrentAltitude
	{
		get
		{
			if (aggregateGroundUnit_0 == null)
			{
				return base.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			return ((ActiveUnit)aggregateGroundUnit_0).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		set
		{
			if (DoSanityCheck)
			{
				ActiveUnit_Kinematics kinematics = Kinematics;
				float maximumAltitude = kinematics.GetMaximumAltitude();
				float num = kinematics.GetMinimumAltitude();
				if (IsWeapon && ((Weapon)this).Type == Weapon._WeaponType.Sonobuoy)
				{
					num = base.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, ParentScen);
				}
				if (IsWeapon && ((Weapon)this).Type == Weapon._WeaponType.PalletWeapon)
				{
					base.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
					return;
				}
				if (value > maximumAltitude)
				{
					value = maximumAltitude;
				}
				if (value < num)
				{
					value = num;
				}
			}
			if (IsSubmarine && value != this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				((Submarine)this).PrimaryEngine = null;
			}
			base.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
		}
	}

	public override Side UnitSide
	{
		get
		{
			if (_UnitSide == null)
			{
				if (ParentScen == null)
				{
					return null;
				}
				Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (side != null && string.CompareOrdinal(side.Name, _SideName) == 0)
					{
						this.set_UnitSide(SetSideOnly: true, side);
						break;
					}
				}
			}
			return _UnitSide;
		}
		set
		{
			try
			{
				if (value == _UnitSide)
				{
					return;
				}
				if (!SetSideOnly)
				{
					if (_UnitSide != null)
					{
						_UnitSide.Units.Remove(this);
						if (IsGroupMember() && this.get_ParentGroup(UsingMissionPlanner: false).get_UnitSide(SetSideOnly: false) != value)
						{
							this.get_ParentGroup(UsingMissionPlanner: false).Units.Remove(ObjectID);
							this.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
						}
						if (ActiveMissionOrPackage() != null)
						{
							Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
							Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
						}
						ActiveUnit_AI aI = AI;
						ActiveUnit theAU = this;
						aI.ClearAllTargets(ref theAU);
						AI.ClearAllThreats();
					}
					if (value != null && (!IsWeapon || !((Weapon)this).IsMine))
					{
						lock (value.Units)
						{
							value.Units.Add(this);
						}
					}
				}
				_UnitSide = value;
				if (_UnitSide != null)
				{
					_SideName = _UnitSide.Name;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual Group ParentGroup
	{
		get
		{
			return _ParentGroup;
		}
		set
		{
			bool flag;
			if (value != this && (flag = value != _ParentGroup))
			{
				_ParentGroup?.Units.Remove(ObjectID);
				_ParentGroup = value;
				if (value != null && !value.Units.ContainsKey(ObjectID))
				{
					value.Units.Add(ObjectID, this);
				}
				if (value != null && value.ParentScen == null)
				{
					value.ParentScen = ParentScen;
				}
				if (!UsingMissionPlanner && flag && value != null && !IsGroupLead())
				{
					Navigator.ClearPlottedCourse();
					Navigator.CalculateFormationStationRelativeData(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), ResetValues: false);
					Navigator.ClearFlight();
				}
				if (flag)
				{
					parentGroupChangedEventHandler_0?.Invoke(ObjectID);
				}
				if (value == null)
				{
					Navigator.UnitFormationStation = null;
				}
			}
		}
	}

	public virtual PooledList<FuelRec> Fuel_ReadOnly => _Fuel;

	public override float DesiredPitch
	{
		get
		{
			return base.DesiredPitch;
		}
		set
		{
			base.DesiredPitch = value;
			AI.CalculatedDesiredPitchThisPulse = true;
		}
	}

	public virtual float DesiredHeading => _DesiredHeading;

	public virtual float DesiredHeading
	{
		set
		{
			if (float.IsNaN(value))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else
			{
				_DesiredHeading = value;
				DesiredTurnRate = theTurnRate;
			}
		}
	}

	public virtual float DesiredSpeed
	{
		get
		{
			return _DesiredSpeed;
		}
		set
		{
			ActiveUnit_Kinematics kinematics = Kinematics;
			if (value > 0f)
			{
				float num = kinematics.GetMaximumSpeed();
				if (value > num)
				{
					value = num;
				}
			}
			float minimumSpeed_Total = kinematics.GetMinimumSpeed_Total(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false);
			if (value < minimumSpeed_Total)
			{
				value = minimumSpeed_Total;
			}
			_DesiredSpeed = value;
		}
	}

	public virtual float DesiredAltitude
	{
		get
		{
			return _DesiredAltitude;
		}
		set
		{
			float maximumAltitude = Kinematics.GetMaximumAltitude();
			if (value > maximumAltitude)
			{
				value = maximumAltitude;
			}
			value = (float)Math.Round(value, 2);
			if (value != _DesiredAltitude)
			{
				_DesiredAltitude = value;
				AI.CalculatedDesiredPitchThisPulse = false;
			}
		}
	}

	public virtual float DesiredAltitude_AGL
	{
		get
		{
			return _DesiredAltitude_AGL;
		}
		set
		{
			float maximumAltitude = Kinematics.GetMaximumAltitude();
			if (value > maximumAltitude)
			{
				value = maximumAltitude;
			}
			value = (float)Math.Round(value, 2);
			_DesiredAltitude_AGL = value;
		}
	}

	public virtual bool DesiredAltitude_UseTerrainFollowing
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual TurnRate DesiredTurnRate
	{
		get
		{
			return _DesiredTurnRate;
		}
		set
		{
			_DesiredTurnRate = value;
		}
	}

	public virtual Waypoint.TurnRateCategory DesiredTurnRate_Navigation
	{
		get
		{
			return _DesiredTurnRate_Navigation;
		}
		set
		{
			_DesiredTurnRate_Navigation = value;
		}
	}

	public virtual double CornerSpeed => CurrentSpeed;

	public virtual Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (!nullable_15.HasValue)
			{
				if (Propulsion.Count == 0)
				{
					if (IsPalletWeapon)
					{
						nullable_15 = Throttle.Cruise;
					}
					nullable_15 = Throttle.FullStop;
				}
				else if (Kinematics.CanApplyFlankThrottle())
				{
					nullable_15 = Throttle.Flank;
				}
				else if (Kinematics.CanApplyFullThrottle())
				{
					nullable_15 = Throttle.Full;
				}
				else
				{
					nullable_15 = Throttle.Cruise;
				}
			}
			return nullable_15.Value;
		}
	}

	public virtual Throttle MinPossibleThrottleSetting
	{
		get
		{
			int result;
			if (IsAircraft)
			{
				if (!((Aircraft)this).IsHelicopter)
				{
					return Throttle.Loiter;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (Throttle)result;
		}
	}

	public virtual Throttle ThrottleSetting
	{
		get
		{
			return _ThrottleSetting;
		}
		set
		{
			_ThrottleSetting = value;
		}
	}

	public virtual ActiveUnit_Navigator Navigator
	{
		get
		{
			if (activeUnit_Navigator_0 == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Navigator;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Navigator;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Navigator;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Navigator;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Navigator;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Navigator;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Navigator;
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
					return ((AggregateGroundUnit)this).Navigator;
				}
				ActiveUnit theUnit = this;
				activeUnit_Navigator_0 = new ActiveUnit_Navigator(ref theUnit);
			}
			return activeUnit_Navigator_0;
		}
	}

	public virtual ActiveUnit_AI AI
	{
		get
		{
			if (_AI == null)
			{
				if (IsGroup)
				{
					return ((Group)this).AI;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).AI;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).AI;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).AI;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).AI;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).AI;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).AI;
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
					return ((AggregateGroundUnit)this).AI;
				}
				_AI = new ActiveUnit_AI(this);
			}
			return _AI;
		}
	}

	public virtual ActiveUnit_Kinematics Kinematics
	{
		get
		{
			if (activeUnit_Kinematics_0 == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Kinematics;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Satellite:
					return ((Satellite)this).Kinematics;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Kinematics;
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
					return ((AggregateGroundUnit)this).Kinematics;
				}
				ActiveUnit theUnit = this;
				activeUnit_Kinematics_0 = new ActiveUnit_Kinematics(ref theUnit);
			}
			return activeUnit_Kinematics_0;
		}
	}

	public virtual ActiveUnit_Sensory Sensory
	{
		get
		{
			if (_Sensory == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Sensory;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Sensory;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Sensory;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Sensory;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Sensory;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Sensory;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Sensory;
				}
				ActiveUnit theUnit = this;
				_Sensory = new ActiveUnit_Sensory(ref theUnit);
			}
			return _Sensory;
		}
	}

	public virtual ActiveUnit_Weaponry Weaponry
	{
		get
		{
			if (activeUnit_Weaponry_0 == null)
			{
				if (IsGroup)
				{
					activeUnit_Weaponry_0 = ((Group)this).Weaponry;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					activeUnit_Weaponry_0 = ((Aircraft)this).Weaponry;
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					activeUnit_Weaponry_0 = ((Ship)this).Weaponry;
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					activeUnit_Weaponry_0 = ((Submarine)this).Weaponry;
					break;
				case GlobalVariables.ActiveUnitType.Facility:
					activeUnit_Weaponry_0 = ((Facility)this).Weaponry;
					break;
				default:
					activeUnit_Weaponry_0 = new ActiveUnit_Weaponry(this);
					break;
				case GlobalVariables.ActiveUnitType.Vehicle:
					activeUnit_Weaponry_0 = ((Vehicle)this).Weaponry;
					break;
				}
			}
			return activeUnit_Weaponry_0;
		}
	}

	public virtual ActiveUnit_CommStuff CommStuff
	{
		get
		{
			if (_CommStuff == null)
			{
				if (IsGroup)
				{
					return ((Group)this).CommStuff;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).CommStuff;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).CommStuff;
				}
				ActiveUnit theUnit = this;
				_CommStuff = new ActiveUnit_CommStuff(ref theUnit);
			}
			return _CommStuff;
		}
	}

	public virtual ActiveUnit_Damage Damage
	{
		get
		{
			if (_Damage == null)
			{
				if (IsGroup)
				{
					return ((Group)this).Damage;
				}
				switch (UnitType)
				{
				case GlobalVariables.ActiveUnitType.Aircraft:
					return ((Aircraft)this).Damage;
				case GlobalVariables.ActiveUnitType.Ship:
					return ((Ship)this).Damage;
				case GlobalVariables.ActiveUnitType.Submarine:
					return ((Submarine)this).Damage;
				case GlobalVariables.ActiveUnitType.Facility:
					return ((Facility)this).Damage;
				case GlobalVariables.ActiveUnitType.Weapon:
					return ((Weapon)this).Damage;
				case GlobalVariables.ActiveUnitType.Satellite:
					return ((Satellite)this).Damage;
				case GlobalVariables.ActiveUnitType.Vehicle:
					return ((Vehicle)this).Damage;
				case GlobalVariables.ActiveUnitType.AggregateGroundUnit:
					return ((AggregateGroundUnit)this).Damage;
				}
				ActiveUnit theUnit = this;
				_Damage = new ActiveUnit_Damage(ref theUnit);
			}
			return _Damage;
		}
	}

	public virtual ActiveUnit_AirOps AirOps
	{
		get
		{
			if (_AirOps == null)
			{
				if (IsGroup)
				{
					return ((Group)this).AirOps;
				}
				GlobalVariables.ActiveUnitType unitType = UnitType;
				if (unitType == GlobalVariables.ActiveUnitType.Aircraft)
				{
					return ((Aircraft)this).AirOps;
				}
				ActiveUnit theUnit = this;
				_AirOps = new ActiveUnit_AirOps(ref theUnit);
			}
			return _AirOps;
		}
	}

	public virtual CommDevice[] Comms_ReadOnly
	{
		get
		{
			if (Mounts.Count > 0)
			{
				CommDevice[] theArray = null;
				int num = Mounts.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mount mount = Mounts[i];
					int num2 = mount.CommDevices.Length - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (theArray == null)
						{
							theArray = method_1();
						}
						CommDevice commDevice = mount.CommDevices[j];
						commDevice.IsCommsInMount = true;
						ArrayExtensions.Add(ref theArray, commDevice);
					}
				}
				if (theArray == null)
				{
					return _Comms;
				}
				return theArray;
			}
			return _Comms;
		}
	}

	public virtual List<Sensor> MineCountermeasures
	{
		get
		{
			if (_MineCountermeasures == null)
			{
				lock (_MineCountermeasures_Lock)
				{
					List<Sensor> list = new List<Sensor>();
					foreach (Sensor sensor in _Sensors)
					{
						if (sensor.IsMineCountermeasure)
						{
							list.Add(sensor);
						}
					}
					_MineCountermeasures = list;
				}
			}
			return _MineCountermeasures;
		}
		set
		{
			lock (_MineCountermeasures_Lock)
			{
				_MineCountermeasures = value;
			}
		}
	}

	public bool CanSweepMine
	{
		get
		{
			if (theM == null)
			{
				return false;
			}
			foreach (Sensor mineCountermeasure in MineCountermeasures)
			{
				if (!mineCountermeasure.IsActive())
				{
					continue;
				}
				int result;
				if (!mineCountermeasure.get_CanSweepThisMine(theM))
				{
					if (!mineCountermeasure.get_CanTriggerThisMine(theM))
					{
						continue;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
		}
	}

	public virtual Sensor[] Sensors_Cached
	{
		get
		{
			if (sensor_0 == null)
			{
				lock (lockObject_0)
				{
					if (sensor_0 == null)
					{
						sensor_0 = Sensors_ReadOnly();
					}
				}
			}
			return sensor_0;
		}
		set
		{
			lock (lockObject_0)
			{
				sensor_0 = value;
			}
		}
	}

	public bool HasEmittingSensors
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (Sensors_Cached.Length != 0)
				{
					Sensor[] sensors_Cached = Sensors_Cached;
					int num = 0;
					while (true)
					{
						if (num < sensors_Cached.Length)
						{
							Sensor sensor = sensors_Cached[num];
							if (sensor != null && sensor.IsActive())
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						result = false;
						return result;
					}
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasEmittingRadars
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (Sensors_Cached.Length == 0)
				{
					result = false;
					return result;
				}
				Sensor[] sensors_Cached = Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						Sensor sensor = sensors_Cached[num];
						if ((sensor.Type == Sensor.Sensor_Type.Radar) & sensor.IsActive())
						{
							break;
						}
						num = checked(num + 1);
						continue;
					}
					result = false;
					return result;
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasEmittingJammers
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (Sensors_Cached.Length != 0)
				{
					Sensor[] sensors_Cached = Sensors_Cached;
					int num = 0;
					while (true)
					{
						if (num < sensors_Cached.Length)
						{
							Sensor sensor = sensors_Cached[num];
							if ((sensor.IsOECM || sensor.IsGNSSJammer) & sensor.IsActive())
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						result = false;
						return result;
					}
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool CouldHaveEmittingRadars
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (Sensors_Cached.Length == 0)
				{
					result = false;
					return result;
				}
				Sensor[] sensors_Cached = Sensors_Cached;
				foreach (Sensor sensor in sensors_Cached)
				{
					if ((sensor.Type == Sensor.Sensor_Type.Radar) & sensor.CanBeActive)
					{
						result = true;
						return result;
					}
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool CouldHaveEmittingJammers
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (Sensors_Cached.Length != 0)
				{
					Sensor[] sensors_Cached = Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if ((sensor.IsOECM || sensor.IsGNSSJammer) && sensor.CanBeActive)
						{
							result = true;
							return result;
						}
					}
					result = false;
					return result;
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101186", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public virtual bool IsOutOfFuel
	{
		get
		{
			try
			{
				PooledList<FuelRec> fuel_ReadOnly = Fuel_ReadOnly;
				if (fuel_ReadOnly.Count == 0)
				{
					return false;
				}
				foreach (FuelRec item in fuel_ReadOnly)
				{
					if (item != null && !(item.CurrentQuantity <= 0f))
					{
						return false;
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101187", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
	}

	public virtual AirFacility[] AirFacilities_ReadOnly => _AirFacilities;

	public virtual DockFacility[] DockFacilities_ReadOnly => _DockFacilities;

	public bool HasMineDisposalCharges
	{
		get
		{
			foreach (Sensor mineCountermeasure in MineCountermeasures)
			{
				if (mineCountermeasure.IsExplosiveMineNeutralizer)
				{
					return true;
				}
			}
			return false;
		}
	}

	public virtual Mission AssignedTaskPool
	{
		get
		{
			Mission result;
			try
			{
				if (_AssignedTaskPool == null)
				{
					if (_AssignedMissionOrPackage != null && _AssignedMissionOrPackage.Category == Mission.MissionCategory.Package && !string.IsNullOrEmpty(_AssignedMissionOrPackage.get_ParentTaskPoolID(this.get_UnitSide(SetSideOnly: false))))
					{
						_AssignedTaskPool_ID = _AssignedMissionOrPackage.get_ParentTaskPoolID(this.get_UnitSide(SetSideOnly: false));
					}
					if (!string.IsNullOrEmpty(_AssignedTaskPool_ID))
					{
						ReadOnlyCollection<Mission> readOnlyCollection = this.get_UnitSide(SetSideOnly: false).get_MissionsTotal(ParentScen);
						int num = readOnlyCollection.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							Mission mission = readOnlyCollection[i];
							if (mission != null && Operators.CompareString(mission.ObjectID, _AssignedTaskPool_ID, false) == 0)
							{
								_AssignedTaskPool = mission;
								break;
							}
						}
						if (_AssignedTaskPool == null)
						{
							_AssignedTaskPool_ID = null;
						}
					}
				}
				result = _AssignedTaskPool;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200638", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
			return result;
		}
		set
		{
			try
			{
				if (value == null)
				{
					_AssignedTaskPool = null;
					_AssignedTaskPool_ID = "";
				}
				else
				{
					_AssignedTaskPool = value;
					_AssignedTaskPool_ID = value.ObjectID;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200639", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public virtual bool CanPhysicallyReplenishThisUnit => false;

	public virtual ActiveUnit_DockingOps.ResupplyCapacity DesignatedSupplier
	{
		get
		{
			if (!_DesignatedSupplier.HasValue)
			{
				return ActiveUnit_DockingOps.ResupplyCapacity.None;
			}
			return _DesignatedSupplier.Value;
		}
		set
		{
			_DesignatedSupplier = value;
		}
	}

	public virtual bool CanPhysicallyReplenishOtherUnits => false;

	public virtual bool HasEnoughFuelToReplenishThisUnit => true;

	public virtual _ActiveUnitStatus Status
	{
		get
		{
			return _Status;
		}
		set
		{
			Waypoint[] plottedCourse = Navigator.PlottedCourse;
			try
			{
				if (IsAircraft && ((value == _ActiveUnitStatus.EngagedOffensive) & (plottedCourse == null || plottedCourse.Length == 0 || (Navigator.Has_NonPathfind_NonFP_PlottedCourse() && plottedCourse[0].Type != Waypoint.WaypointType.LocalizationRun))))
				{
					Aircraft_AI aI = ((Aircraft)this).AI;
					Aircraft theAircraft = (Aircraft)this;
					Throttle throttleSetting = ThrottleSetting;
					bool MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					DesiredAltitude = aI.MostRealisticAttackAltitude(ref theAircraft, throttleSetting, LoadoutAltitudesOnly: false, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					if (plottedCourse.Length > 0 && plottedCourse[0].Type == Waypoint.WaypointType.PatrolStation)
					{
						Navigator._ResumeFlightPlanWaypoint = Navigator.PlottedCourse[0];
						Navigator.ClearPlottedCourse();
					}
				}
				StateChangedOnThisPulse = value != _Status;
				if (StateChangedOnThisPulse)
				{
					if (ActiveMissionOrPackage() != null && ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && Navigator.PlottedCourse != null && Navigator.PlottedCourse.Count() > 0)
					{
						Navigator._ResumeFlightPlanWaypoint = Navigator.PlottedCourse.FirstOrDefault();
					}
					if (((value == _ActiveUnitStatus.RTB || value == _ActiveUnitStatus.RTB_MissionOver || value == _ActiveUnitStatus.RTB_CommsLost || value == _ActiveUnitStatus.RTB_Group || value == _ActiveUnitStatus.Tasked) && _Status == _ActiveUnitStatus.Manual_Unassigned) || (IsInsideNoNavZones(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), 0f) && _Status == _ActiveUnitStatus.OnPlottedCourse))
					{
						return;
					}
					_Status_Oldvalue = _Status;
					if (((value == _ActiveUnitStatus.RTB && FuelState == _ActiveUnitFuelState.IsBingo) || value == _ActiveUnitStatus.HeadingToRefuelPoint || value == _ActiveUnitStatus.Refuelling) && (_Status_Oldvalue != _ActiveUnitStatus.RTB || FuelState != _ActiveUnitFuelState.IsBingo) && _Status_Oldvalue != _ActiveUnitStatus.HeadingToRefuelPoint && _Status_Oldvalue != _ActiveUnitStatus.Refuelling)
					{
						_StatusBefore_NeedToRefuel = _Status;
						_FuelStateBefore_NeedToRefuel = _FuelState;
						if (IsGroupWingman() && !IsGroupLead() && !Navigator.HasPlottedCourse())
						{
							if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == _ActiveUnitStatus.EngagedDefensive)
							{
								_ThrottleBefore_NeedToRefuel = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedDefensive;
							}
							else if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
							{
								_ThrottleBefore_NeedToRefuel = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedOffensive;
							}
							else if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == _ActiveUnitStatus.WaitForPathfinder)
							{
								_ThrottleBefore_NeedToRefuel = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_WaitForPathfinder;
							}
							else
							{
								_ThrottleBefore_NeedToRefuel = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting;
							}
						}
						else
						{
							_ThrottleBefore_NeedToRefuel = ThrottleSetting;
						}
						_AltitudeBefore_NeedToRefuel = DesiredAltitude;
						_AltitudeBefore_NeedToRefuel_AGL = DesiredAltitude_AGL;
						_TerrainFollowingBefore_NeedToRefuel = this.get_DesiredAltitude_UseTerrainFollowing(this);
						this.set_DesiredAltitude_UseTerrainFollowing(this, value: false);
						if (IsAircraft && Navigator.HasFlightPlan)
						{
							if (ActiveMissionOrPackage() != null && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
							{
								_MissionPlannerOverrideCancellation = true;
							}
							else
							{
								_MissionPlannerOverrideCancellation = false;
							}
						}
						if (_MissionPlannerOverrideCancellation)
						{
							_MissionPlannerOverrideCancellation_DesiredSpeedOverride = Kinematics.DesiredSpeedOverride;
							_MissionPlannerOverrideCancellation_Speed = DesiredSpeed;
							_MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Kinematics.DesiredAltitudeOverride;
							Kinematics.DesiredSpeedOverride = null;
							Kinematics.DesiredAltitudeOverride = false;
						}
					}
					else
					{
						switch (value)
						{
						case _ActiveUnitStatus.EngagedDefensive:
							_StatusBefore_EngagedDefensive = _Status;
							_DesiredSpeedOverrideBefore_EngagedDefensive = Kinematics.DesiredSpeedOverride;
							if (_Status_Oldvalue == _ActiveUnitStatus.EngagedOffensive)
							{
								_ThrottleBefore_EngagedDefensive = _ThrottleBefore_EngagedOffensive;
								_AltitudeBefore_EngagedDefensive = _AltitudeBefore_EngagedOffensive;
								_AltitudeBefore_EngagedDefensive_AGL = _AltitudeBefore_EngagedOffensive_AGL;
								_TerrainFollowingBefore_EngagedDefensive = _TerrainFollowingBefore_EngagedOffensive;
							}
							else if (_Status_Oldvalue == _ActiveUnitStatus.WaitForPathfinder)
							{
								_ThrottleBefore_EngagedDefensive = _ThrottleBefore_WaitForPathfinder;
								_AltitudeBefore_EngagedDefensive = _AltitudeBefore_WaitForPathfinder;
								_AltitudeBefore_EngagedDefensive_AGL = _AltitudeBefore_WaitForPathfinder_AGL;
								_TerrainFollowingBefore_EngagedDefensive = _TerrainFollowingBefore_WaitForPathfinder;
							}
							else if (_Status_Oldvalue != _ActiveUnitStatus.HeadingToRefuelPoint && _Status_Oldvalue != _ActiveUnitStatus.Refuelling)
							{
								if (IsGroupWingman() && !IsGroupLead() && !Navigator.HasPlottedCourse())
								{
									byte? b = (byte?)this.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead?.Status;
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 3)) != true)
									{
										b = (byte?)this.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead?.Status;
										if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 2)) != true)
										{
											b = (byte?)this.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead?.Status;
											if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 21)) != true)
											{
												if (this.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead != null)
												{
													_ThrottleBefore_EngagedDefensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting;
												}
											}
											else
											{
												_ThrottleBefore_EngagedDefensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_WaitForPathfinder;
											}
										}
										else
										{
											_ThrottleBefore_EngagedDefensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedOffensive;
										}
									}
									else
									{
										_ThrottleBefore_EngagedDefensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedDefensive;
									}
								}
								else
								{
									_ThrottleBefore_EngagedDefensive = ThrottleSetting;
								}
								_AltitudeBefore_EngagedDefensive = DesiredAltitude;
								_AltitudeBefore_EngagedDefensive_AGL = DesiredAltitude_AGL;
								_TerrainFollowingBefore_EngagedDefensive = this.get_DesiredAltitude_UseTerrainFollowing(this);
								if (IsAircraft)
								{
									if (ActiveMissionOrPackage() != null && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										_MissionPlannerOverrideCancellation = true;
									}
									else
									{
										_MissionPlannerOverrideCancellation = false;
									}
								}
								if (!_MissionPlannerOverrideCancellation)
								{
									break;
								}
								if (Navigator.NextWaypointIsManual)
								{
									byte? b = (byte?)Doctrine.get_AutoEvade(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
									{
										_MissionPlannerOverrideCancellation = false;
										break;
									}
								}
								_MissionPlannerOverrideCancellation_DesiredSpeedOverride = Kinematics.DesiredSpeedOverride;
								_MissionPlannerOverrideCancellation_Speed = DesiredSpeed;
								_MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Kinematics.DesiredAltitudeOverride;
								Kinematics.DesiredSpeedOverride = null;
								Kinematics.DesiredAltitudeOverride = false;
							}
							else
							{
								_ThrottleBefore_EngagedDefensive = _ThrottleBefore_NeedToRefuel;
								_AltitudeBefore_EngagedDefensive = _AltitudeBefore_NeedToRefuel;
								_AltitudeBefore_EngagedDefensive_AGL = _AltitudeBefore_NeedToRefuel_AGL;
								_TerrainFollowingBefore_EngagedDefensive = _TerrainFollowingBefore_NeedToRefuel;
							}
							break;
						case _ActiveUnitStatus.EngagedOffensive:
							if (IsAircraft && Navigator.IsOnAutoPlannerPlottedCourse_HoldOrAssemble)
							{
								List<Waypoint> list = new List<Waypoint>();
								if (plottedCourse.Count() > 0)
								{
									Waypoint[] array = plottedCourse;
									foreach (Waypoint waypoint in array)
									{
										if (waypoint.IsHoldOrAssembleWaypoint())
										{
											list.Add(waypoint);
											continue;
										}
										break;
									}
								}
								foreach (Waypoint item in list)
								{
									_ = item;
									ActiveUnit_Navigator navigator = Navigator;
									bool MissionProfileAttackIngressAltitudeTerrainFollowing = true;
									bool ForceStationAbort = false;
									navigator.CheckIfReachedWaypoint_AND_Apply_WP_logic(0f, ref MissionProfileAttackIngressAltitudeTerrainFollowing, ref ForceStationAbort);
								}
							}
							_StatusBefore_EngagedOffensive = _Status;
							if (_Status_Oldvalue == _ActiveUnitStatus.EngagedDefensive)
							{
								_ThrottleBefore_EngagedOffensive = _ThrottleBefore_EngagedDefensive;
								_AltitudeBefore_EngagedOffensive = _AltitudeBefore_EngagedDefensive;
								if (_AltitudeBefore_EngagedDefensive_AGL.HasValue)
								{
									_AltitudeBefore_EngagedOffensive_AGL = _AltitudeBefore_EngagedDefensive_AGL.Value;
								}
								_TerrainFollowingBefore_EngagedOffensive = _TerrainFollowingBefore_EngagedDefensive;
							}
							else if (_Status_Oldvalue == _ActiveUnitStatus.WaitForPathfinder)
							{
								_ThrottleBefore_EngagedOffensive = _ThrottleBefore_WaitForPathfinder;
								_AltitudeBefore_EngagedOffensive = _AltitudeBefore_WaitForPathfinder;
								_AltitudeBefore_EngagedOffensive_AGL = _AltitudeBefore_WaitForPathfinder_AGL;
								_TerrainFollowingBefore_EngagedOffensive = _TerrainFollowingBefore_WaitForPathfinder;
							}
							else if (_Status_Oldvalue != _ActiveUnitStatus.HeadingToRefuelPoint && _Status_Oldvalue != _ActiveUnitStatus.Refuelling)
							{
								if (IsGroupWingman() && !Information.IsNothing((object)IsGroupLead()) && !Navigator.HasPlottedCourse() && this.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
								{
									if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == _ActiveUnitStatus.EngagedDefensive)
									{
										_ThrottleBefore_EngagedOffensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedDefensive;
									}
									else if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == _ActiveUnitStatus.EngagedOffensive)
									{
										_ThrottleBefore_EngagedOffensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedOffensive;
									}
									else if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == _ActiveUnitStatus.WaitForPathfinder)
									{
										_ThrottleBefore_EngagedOffensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_WaitForPathfinder;
									}
									else
									{
										_ThrottleBefore_EngagedOffensive = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting;
									}
								}
								else
								{
									_ThrottleBefore_EngagedOffensive = ThrottleSetting;
								}
								_AltitudeBefore_EngagedOffensive = DesiredAltitude;
								_AltitudeBefore_EngagedOffensive_AGL = DesiredAltitude_AGL;
								_TerrainFollowingBefore_EngagedOffensive = this.get_DesiredAltitude_UseTerrainFollowing(this);
								if (IsAircraft)
								{
									if (!Information.IsNothing((object)ActiveMissionOrPackage()) && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										_MissionPlannerOverrideCancellation = true;
									}
									else
									{
										_MissionPlannerOverrideCancellation = false;
									}
								}
								if (!_MissionPlannerOverrideCancellation)
								{
									break;
								}
								if (Navigator.NextWaypointIsManual)
								{
									byte? b = (byte?)Doctrine.get_IgnorePlottedCourse(ParentScen, MultipleUnits: false, (bool?)false, ViaDoctrineForm: false, ViaRightColumn: false);
									if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true)
									{
										_MissionPlannerOverrideCancellation = false;
										break;
									}
								}
								_MissionPlannerOverrideCancellation_DesiredSpeedOverride = Kinematics.DesiredSpeedOverride;
								_MissionPlannerOverrideCancellation_Speed = DesiredSpeed;
								_MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Kinematics.DesiredAltitudeOverride;
								Kinematics.DesiredSpeedOverride = null;
								Kinematics.DesiredAltitudeOverride = false;
								Navigator.ClearPlottedCourse();
							}
							else
							{
								_ThrottleBefore_EngagedOffensive = _ThrottleBefore_NeedToRefuel;
								_AltitudeBefore_EngagedOffensive = _AltitudeBefore_NeedToRefuel;
								_AltitudeBefore_EngagedOffensive_AGL = _AltitudeBefore_NeedToRefuel_AGL;
								_TerrainFollowingBefore_EngagedOffensive = _TerrainFollowingBefore_NeedToRefuel;
							}
							break;
						case _ActiveUnitStatus.WaitForPathfinder:
							_StatusBefore_WaitForPathfinder = _Status;
							if (_Status_Oldvalue == _ActiveUnitStatus.EngagedOffensive)
							{
								_ThrottleBefore_WaitForPathfinder = _ThrottleBefore_EngagedOffensive;
								_AltitudeBefore_WaitForPathfinder = _AltitudeBefore_EngagedOffensive;
								_AltitudeBefore_WaitForPathfinder_AGL = _AltitudeBefore_EngagedOffensive_AGL;
								_TerrainFollowingBefore_WaitForPathfinder = _TerrainFollowingBefore_EngagedOffensive;
							}
							else if (_Status_Oldvalue == _ActiveUnitStatus.EngagedDefensive)
							{
								_ThrottleBefore_WaitForPathfinder = _ThrottleBefore_EngagedDefensive;
								_AltitudeBefore_WaitForPathfinder = _AltitudeBefore_EngagedDefensive;
								if (_AltitudeBefore_EngagedDefensive_AGL.HasValue)
								{
									_AltitudeBefore_WaitForPathfinder_AGL = _AltitudeBefore_EngagedDefensive_AGL.Value;
								}
								_TerrainFollowingBefore_WaitForPathfinder = _TerrainFollowingBefore_EngagedDefensive;
							}
							else if (_Status_Oldvalue != _ActiveUnitStatus.HeadingToRefuelPoint && _Status_Oldvalue != _ActiveUnitStatus.Refuelling)
							{
								if (IsGroupWingman() && !IsGroupLead() && !Navigator.HasPlottedCourse())
								{
									ActiveUnit groupLead = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
									if (groupLead != null && groupLead.Status == _ActiveUnitStatus.EngagedDefensive)
									{
										_ThrottleBefore_WaitForPathfinder = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedDefensive;
									}
									else
									{
										ActiveUnit groupLead2 = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
										if (groupLead2 != null && groupLead2.Status == _ActiveUnitStatus.EngagedOffensive)
										{
											_ThrottleBefore_WaitForPathfinder = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedOffensive;
										}
										else
										{
											ActiveUnit groupLead3 = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
											if (groupLead3 != null && groupLead3.Status == _ActiveUnitStatus.EngagedOffensive)
											{
												_ThrottleBefore_WaitForPathfinder = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead._ThrottleBefore_EngagedOffensive;
											}
											else if (this.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
											{
												_ThrottleBefore_WaitForPathfinder = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting;
											}
										}
									}
								}
								else
								{
									_ThrottleBefore_WaitForPathfinder = ThrottleSetting;
								}
								_AltitudeBefore_WaitForPathfinder = DesiredAltitude;
								_AltitudeBefore_WaitForPathfinder_AGL = DesiredAltitude_AGL;
								_TerrainFollowingBefore_WaitForPathfinder = this.get_DesiredAltitude_UseTerrainFollowing(this);
								if (IsAircraft)
								{
									if (!Information.IsNothing((object)ActiveMissionOrPackage()) && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										_MissionPlannerOverrideCancellation = true;
									}
									else
									{
										_MissionPlannerOverrideCancellation = false;
									}
								}
								if (_MissionPlannerOverrideCancellation)
								{
									if (!Navigator.NextWaypointIsManual)
									{
										_MissionPlannerOverrideCancellation_DesiredSpeedOverride = Kinematics.DesiredSpeedOverride;
										_MissionPlannerOverrideCancellation_Speed = DesiredSpeed;
										_MissionPlannerOverrideCancellation_DesiredAltitudeOverride = Kinematics.DesiredAltitudeOverride;
										Kinematics.DesiredSpeedOverride = null;
										Kinematics.DesiredAltitudeOverride = false;
									}
									else
									{
										_MissionPlannerOverrideCancellation = false;
									}
								}
							}
							else
							{
								_ThrottleBefore_WaitForPathfinder = _ThrottleBefore_NeedToRefuel;
								_AltitudeBefore_WaitForPathfinder = _AltitudeBefore_NeedToRefuel;
								_AltitudeBefore_WaitForPathfinder_AGL = _AltitudeBefore_NeedToRefuel_AGL;
								_TerrainFollowingBefore_WaitForPathfinder = _TerrainFollowingBefore_NeedToRefuel;
							}
							break;
						default:
							if ((_Status_Oldvalue == _ActiveUnitStatus.HeadingToRefuelPoint && value != _ActiveUnitStatus.Refuelling) || _Status_Oldvalue == _ActiveUnitStatus.Refuelling)
							{
								if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
								{
									Kinematics.DesiredSpeedOverride = _DesiredSpeedOverrideBefore_EngagedDefensive.Value;
									_DesiredSpeedOverrideBefore_EngagedDefensive = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									if (ActiveMissionOrPackage() == null)
									{
										if (IsAircraft && ThrottleSetting <= Throttle.Cruise)
										{
											_ThrottleBefore_NeedToRefuel = Throttle.Cruise;
										}
										SetThrottle(_ThrottleBefore_NeedToRefuel, Kinematics.DesiredSpeedOverride);
										DesiredAltitude = _AltitudeBefore_NeedToRefuel;
										DesiredAltitude_AGL = _AltitudeBefore_NeedToRefuel_AGL;
										this.set_DesiredAltitude_UseTerrainFollowing(this, _TerrainFollowingBefore_NeedToRefuel);
									}
									else
									{
										Mission._MissionClass missionClass = ActiveMissionOrPackage().MissionClass;
										if (missionClass == Mission._MissionClass.Patrol)
										{
											if (IsAircraft && IsOnActivePatrol())
											{
												((Aircraft_Navigator)Navigator).SetPatrolThrottle(PursueContact: false, ((Aircraft)this).AirOps.Condition);
											}
										}
										else
										{
											if (IsAircraft && ThrottleSetting <= Throttle.Cruise)
											{
												_ThrottleBefore_NeedToRefuel = Throttle.Cruise;
											}
											SetThrottle(_ThrottleBefore_NeedToRefuel, Kinematics.DesiredSpeedOverride);
										}
										DesiredAltitude = _AltitudeBefore_NeedToRefuel;
										DesiredAltitude_AGL = _AltitudeBefore_NeedToRefuel_AGL;
										this.set_DesiredAltitude_UseTerrainFollowing(this, _TerrainFollowingBefore_NeedToRefuel);
									}
								}
								if (_MissionPlannerOverrideCancellation && Navigator.HasFlightPlan && !Information.IsNothing((object)ActiveMissionOrPackage()) && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
								{
									Kinematics.DesiredSpeedOverride = _MissionPlannerOverrideCancellation_DesiredSpeedOverride;
									if (!Information.IsNothing((object)_MissionPlannerOverrideCancellation_DesiredSpeedOverride))
									{
										DesiredSpeed = _MissionPlannerOverrideCancellation_Speed;
									}
									Kinematics.DesiredAltitudeOverride = _MissionPlannerOverrideCancellation_DesiredAltitudeOverride;
								}
								_MissionPlannerOverrideCancellation = false;
							}
							else if (_Status_Oldvalue == _ActiveUnitStatus.EngagedDefensive)
							{
								if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
								{
									Kinematics.DesiredSpeedOverride = _DesiredSpeedOverrideBefore_EngagedDefensive.Value;
									_DesiredSpeedOverrideBefore_EngagedDefensive = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									SetThrottle(_ThrottleBefore_EngagedDefensive, Kinematics.DesiredSpeedOverride);
									DesiredAltitude = _AltitudeBefore_EngagedDefensive;
									if (_AltitudeBefore_EngagedDefensive_AGL.HasValue)
									{
										DesiredAltitude_AGL = _AltitudeBefore_EngagedDefensive_AGL.Value;
									}
									this.set_DesiredAltitude_UseTerrainFollowing(this, _TerrainFollowingBefore_EngagedDefensive);
								}
								if (_MissionPlannerOverrideCancellation && Navigator.HasFlightPlan && !Information.IsNothing((object)ActiveMissionOrPackage()) && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
								{
									Kinematics.DesiredSpeedOverride = _MissionPlannerOverrideCancellation_DesiredSpeedOverride;
									if (!Information.IsNothing((object)_MissionPlannerOverrideCancellation_DesiredSpeedOverride))
									{
										DesiredSpeed = _MissionPlannerOverrideCancellation_Speed;
									}
									Kinematics.DesiredAltitudeOverride = _MissionPlannerOverrideCancellation_DesiredAltitudeOverride;
								}
								_MissionPlannerOverrideCancellation = false;
							}
							else if (_Status_Oldvalue == _ActiveUnitStatus.EngagedOffensive)
							{
								if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
								{
									Kinematics.DesiredSpeedOverride = _DesiredSpeedOverrideBefore_EngagedDefensive.Value;
									_DesiredSpeedOverrideBefore_EngagedDefensive = null;
								}
								if (!IsGroupWingman() && !Navigator.HasPlottedCourse() && !Navigator.HasFlightPlan)
								{
									SetThrottle(_ThrottleBefore_EngagedOffensive, Kinematics.DesiredSpeedOverride);
									DesiredAltitude = _AltitudeBefore_EngagedOffensive;
									DesiredAltitude_AGL = _AltitudeBefore_EngagedOffensive_AGL;
									this.set_DesiredAltitude_UseTerrainFollowing(this, _TerrainFollowingBefore_EngagedOffensive);
								}
								if (_MissionPlannerOverrideCancellation && Navigator.HasFlightPlan)
								{
									if (!Information.IsNothing((object)ActiveMissionOrPackage()) && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
									{
										Kinematics.DesiredSpeedOverride = _MissionPlannerOverrideCancellation_DesiredSpeedOverride;
										if (!Information.IsNothing((object)_MissionPlannerOverrideCancellation_DesiredSpeedOverride))
										{
											DesiredSpeed = _MissionPlannerOverrideCancellation_Speed;
										}
										Kinematics.DesiredAltitudeOverride = _MissionPlannerOverrideCancellation_DesiredAltitudeOverride;
									}
									if (IsAircraft)
									{
										Aircraft aircraft = (Aircraft)this;
										Aircraft_AirOps._AirOpsCondition condition = aircraft.AirOps.Condition;
										if (condition - 19 <= Aircraft_AirOps._AirOpsCondition.TaxyingToTakeOff || condition == Aircraft_AirOps._AirOpsCondition.BVRDrag)
										{
											aircraft.AirOps.Condition = Aircraft_AirOps._AirOpsCondition.Airborne;
										}
									}
								}
								_MissionPlannerOverrideCancellation = false;
							}
							else
							{
								if (_Status_Oldvalue != _ActiveUnitStatus.WaitForPathfinder)
								{
									break;
								}
								if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
								{
									Kinematics.DesiredSpeedOverride = _DesiredSpeedOverrideBefore_EngagedDefensive.Value;
									_DesiredSpeedOverrideBefore_EngagedDefensive = null;
								}
								if (!IsGroupWingman() || Navigator.HasPlottedCourse())
								{
									SetThrottle(_ThrottleBefore_WaitForPathfinder, Kinematics.DesiredSpeedOverride);
									DesiredAltitude = _AltitudeBefore_WaitForPathfinder;
									DesiredAltitude_AGL = _AltitudeBefore_WaitForPathfinder_AGL;
									this.set_DesiredAltitude_UseTerrainFollowing(this, _TerrainFollowingBefore_WaitForPathfinder);
								}
								if (_MissionPlannerOverrideCancellation && Navigator.HasFlightPlan && !Information.IsNothing((object)ActiveMissionOrPackage()) && (ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || (ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort)))
								{
									Kinematics.DesiredSpeedOverride = _MissionPlannerOverrideCancellation_DesiredSpeedOverride;
									if (!Information.IsNothing((object)_MissionPlannerOverrideCancellation_DesiredSpeedOverride))
									{
										DesiredSpeed = _MissionPlannerOverrideCancellation_Speed;
									}
									Kinematics.DesiredAltitudeOverride = _MissionPlannerOverrideCancellation_DesiredAltitudeOverride;
								}
								_MissionPlannerOverrideCancellation = false;
							}
							break;
						}
					}
				}
				if (StateChangedOnThisPulse && (IsShip || IsSubmarine))
				{
					if (value == _ActiveUnitStatus.RTB && FuelState == _ActiveUnitFuelState.IsBingo && DockingOps.IsCurrentlyProvidingUNREP)
					{
						if (!string.IsNullOrEmpty(DockingOps.UNREP_Port_ReceiverUnitID))
						{
							ActiveUnit activeUnit = ParentScen.ActiveUnits[DockingOps.UNREP_Port_ReceiverUnitID];
							if (!Information.IsNothing((object)activeUnit) && !activeUnit.IsMorituri)
							{
								activeUnit.DockingOps.DisconnectFromSupplier();
							}
						}
						if (!string.IsNullOrEmpty(DockingOps.UNREP_Starboard_ReceiverUnitID))
						{
							ActiveUnit activeUnit2 = ParentScen.ActiveUnits[DockingOps.UNREP_Starboard_ReceiverUnitID];
							if (!Information.IsNothing((object)activeUnit2) && !activeUnit2.IsMorituri)
							{
								activeUnit2.DockingOps.DisconnectFromSupplier();
							}
						}
						if (!string.IsNullOrEmpty(DockingOps.UNREP_Astern_ReceiverUnitID))
						{
							ActiveUnit activeUnit3 = ParentScen.ActiveUnits[DockingOps.UNREP_Astern_ReceiverUnitID];
							if (!Information.IsNothing((object)activeUnit3) && !activeUnit3.IsMorituri)
							{
								activeUnit3.DockingOps.DisconnectFromSupplier();
							}
						}
					}
					switch (value)
					{
					case _ActiveUnitStatus.Unassigned:
					case _ActiveUnitStatus.RTB:
					case _ActiveUnitStatus.RTB_Manual:
					case _ActiveUnitStatus.RTB_MissionOver:
					case _ActiveUnitStatus.RTB_Group:
					case _ActiveUnitStatus.RTB_CalledOff:
					case _ActiveUnitStatus.RTB_CommsLost:
					case _ActiveUnitStatus.RTB_Exhaustion:
						if (_Status_Oldvalue == _ActiveUnitStatus.Refuelling || DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Replenishing)
						{
							DockingOps.DisconnectFromSupplier();
						}
						break;
					}
				}
				if (StateChangedOnThisPulse && _Status_Oldvalue == _ActiveUnitStatus.EngagedOffensive && (value == _ActiveUnitStatus.OnPatrol || value == _ActiveUnitStatus.OnPlottedCourse || value == _ActiveUnitStatus.Tasked || value == _ActiveUnitStatus.Unassigned || value == _ActiveUnitStatus.RTB_CalledOff) && _Status_Oldvalue == _Status && IsAircraft && (Navigator.IsOnAutoPlannerPlottedCourse_StationIngressRun || (!Information.IsNothing((object)ActiveMissionOrPackage()) && ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && AI.IsEscort && Navigator.IsOnAutoPlannerPlottedCourse)))
				{
					_Status = value;
					Aircraft_AirOps airOps = ((Aircraft)this).AirOps;
					List<Waypoint> WaypointList = plottedCourse.ToList();
					airOps.SwitchToNearestWaypoint(ref WaypointList, ForceObjectiveWaypointRemoval: false, IsBingoCheck: false);
				}
				if (StateChangedOnThisPulse)
				{
					Kinematics.ExportLocationEvent("StatusChanged");
				}
				_Status = value;
				if (this.IsRTB && !IsAircraft && IsGroupMember())
				{
					this.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
				}
				if (Navigator.HasFlightPlan && plottedCourse != null && plottedCourse.Length != 0 && (this.IsRTB || plottedCourse == null || plottedCourse.Length <= 0 || Navigator.HasPathfindingPlottedCourse || plottedCourse[0].Category != Waypoint.WaypointCategory.FlightPlan) && !Navigator.HasPathfindingPlottedCourse && !FollowingPCThatIsRTB)
				{
					Navigator.ClearPlottedCourse();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 1234546744567", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public _ActiveUnitStatus StatusBeforeNeedToRefuel => _StatusBefore_NeedToRefuel;

	public virtual _ActiveUnitFuelState FuelState
	{
		get
		{
			return _FuelState;
		}
		set
		{
			_FuelState = value;
		}
	}

	public virtual _ActiveUnitWeaponState WeaponState
	{
		get
		{
			return _WeaponState;
		}
		set
		{
			_WeaponState = value;
		}
	}

	public bool IsRTB
	{
		get
		{
			_ActiveUnitStatus status = Status;
			int result;
			int result2;
			if (status <= _ActiveUnitStatus.RTB_MissionOver)
			{
				if (status != _ActiveUnitStatus.RTB && status != _ActiveUnitStatus.RTB_Manual && status != _ActiveUnitStatus.RTB_MissionOver)
				{
					result = 0;
					goto IL_0032;
				}
			}
			else if (status - 19 > _ActiveUnitStatus.OnPlottedCourse && status != _ActiveUnitStatus.RTB_CommsLost)
			{
				if (status == _ActiveUnitStatus.RTB_Exhaustion)
				{
					result2 = 1;
					goto IL_0036;
				}
				result = 0;
				goto IL_0032;
			}
			result2 = 1;
			goto IL_0036;
			IL_0032:
			return (byte)result != 0;
			IL_0036:
			return (byte)result2 != 0;
		}
	}

	public bool IsRefuellingOrHeadingToRefuel
	{
		get
		{
			_ActiveUnitStatus status = Status;
			if (status - 13 <= _ActiveUnitStatus.OnPlottedCourse)
			{
				return true;
			}
			return false;
		}
	}

	public static bool IsRTB
	{
		get
		{
			_ActiveUnitStatus activeUnitStatus = passedStatus;
			int result;
			int result2;
			if (activeUnitStatus > _ActiveUnitStatus.RTB_MissionOver)
			{
				if (activeUnitStatus - 19 > _ActiveUnitStatus.OnPlottedCourse && activeUnitStatus != _ActiveUnitStatus.RTB_CommsLost)
				{
					if (activeUnitStatus == _ActiveUnitStatus.RTB_Exhaustion)
					{
						result = 1;
						goto IL_0031;
					}
					result2 = 0;
					goto IL_002d;
				}
			}
			else if (activeUnitStatus != _ActiveUnitStatus.RTB && activeUnitStatus != _ActiveUnitStatus.RTB_Manual && activeUnitStatus != _ActiveUnitStatus.RTB_MissionOver)
			{
				result2 = 0;
				goto IL_002d;
			}
			result = 1;
			goto IL_0031;
			IL_0031:
			return (byte)result != 0;
			IL_002d:
			return (byte)result2 != 0;
		}
	}

	public bool IsRTB_Or_CalledOff
	{
		get
		{
			_ActiveUnitStatus status = Status;
			int result;
			int result2;
			if (status > _ActiveUnitStatus.RTB_MissionOver)
			{
				if (status - 19 <= _ActiveUnitStatus.OnPlottedCourse)
				{
					result = 1;
				}
				else
				{
					if (status == _ActiveUnitStatus.RTB_CommsLost)
					{
						goto IL_0038;
					}
					if (status != _ActiveUnitStatus.RTB_Exhaustion)
					{
						result2 = 0;
						goto IL_0035;
					}
					result = 1;
				}
				goto IL_0039;
			}
			if (status != _ActiveUnitStatus.RTB && status != _ActiveUnitStatus.RTB_Manual && status != _ActiveUnitStatus.RTB_MissionOver)
			{
				result2 = 0;
				goto IL_0035;
			}
			goto IL_0038;
			IL_0039:
			return (byte)result != 0;
			IL_0035:
			return (byte)result2 != 0;
			IL_0038:
			result = 1;
			goto IL_0039;
		}
	}

	public virtual long FuelEndurance => 0L;

	public virtual int FuelCapacityMax
	{
		get
		{
			int num = 0;
			FuelRec[] array = _Fuel.InternalArray();
			int num2 = _Fuel.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				FuelRec fuelRec = array[i];
				num += fuelRec.MaxQuantity;
			}
			return num;
		}
	}

	public virtual int FuelCapacityCurrent
	{
		get
		{
			int num = 0;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				num = (int)Math.Round((float)num + item.CurrentQuantity);
			}
			return num;
		}
	}

	public bool IsMobileDecoy
	{
		get
		{
			if (!IsMobileDecoy_Air && !IsMobileDecoy_Surface)
			{
				return IsMobileDecoy_Sub;
			}
			return true;
		}
	}

	public bool IsMobileDecoy_Air
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle && weapon.Kinematics.GetMaximumAltitude() > 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsMobileDecoy_Surface
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle && weapon.Kinematics.GetMaximumAltitude() == 0f && weapon.Kinematics.GetMinimumAltitude() == 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsMobileDecoy_Sub
	{
		get
		{
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.Decoy_Vehicle && weapon.Kinematics.GetMinimumAltitude() < 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsPalletWeapon
	{
		get
		{
			if (IsWeapon)
			{
				return ((Weapon)this).Type == Weapon._WeaponType.PalletWeapon;
			}
			return false;
		}
	}

	public override bool IsPlatform => (object)GetType().BaseType == typeof(Platform);

	public bool isUAV
	{
		get
		{
			int result;
			if (IsWeapon)
			{
				Weapon weapon = (Weapon)this;
				if (weapon.Type == Weapon._WeaponType.UAV_Expendable)
				{
					return true;
				}
				if (weapon.Flags.LoiterCapability)
				{
					return true;
				}
				result = 0;
			}
			else if (!IsAircraft)
			{
				result = 0;
			}
			else
			{
				if (((Aircraft)this).Crew == 0)
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public Magazine[] TotalMagazines
	{
		get
		{
			if (Mounts == null)
			{
				return SharedMagazines;
			}
			List<Magazine> list = new List<Magazine>();
			if (SharedMagazines != null)
			{
				list.AddRange(SharedMagazines);
			}
			foreach (Mount mount in Mounts)
			{
				if (mount.MountMagazine != null)
				{
					list.Add(mount.MountMagazine);
				}
			}
			return list.ToArray();
		}
	}

	public virtual Magazine[] SharedMagazines
	{
		get
		{
			if (IsPlatform)
			{
				return ((Platform)this).Magazines;
			}
			if (IsGroup)
			{
				return ((Group)this).SharedMagazines;
			}
			return null;
		}
	}

	public bool IsAutoDetectable
	{
		get
		{
			if (IsGroup)
			{
				return false;
			}
			if (bool_1)
			{
				return true;
			}
			if (SideAttemptingDetection == null)
			{
				return false;
			}
			if (IsCivilian && SideAttemptingDetection.CanAutoTrackCivs)
			{
				return true;
			}
			Side side = this.get_UnitSide(SetSideOnly: false);
			if (SideAttemptingDetection.AwarenessLevel == Side.AwarenessLevel_Enum.Omniscient && SideAttemptingDetection != side)
			{
				Contact value = null;
				int result;
				if (SideAttemptingDetection.Contacts.TryGetValue(ObjectID, out value))
				{
					value.FullyIdentify(SideAttemptingDetection);
					result = 1;
				}
				else
				{
					value = Contact.Instantiate(this);
					value.FullyIdentify(SideAttemptingDetection);
					SideAttemptingDetection.AddContact(value);
					result = 1;
				}
				return (byte)result != 0;
			}
			int result2;
			if (side.get_ConsidersThisSideToBe(SideAttemptingDetection, ParentScen) == Misc.PostureStance.Friendly)
			{
				if (CommStuff.IsConnectedToSideNetwork)
				{
					return true;
				}
				result2 = 0;
			}
			else
			{
				result2 = 0;
			}
			return (byte)result2 != 0;
		}
		set
		{
			try
			{
				if (value)
				{
					Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						if (side != null)
						{
							ParentScen.UnitAutodetectionValidation.Add(side);
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			bool_1 = value;
		}
	}

	public bool IsPaintingATarget => Sensors_Cached.Where([SpecialName] (Sensor theS) => theS != null && (theS.TargetsTrackedForFireControl_Readonly.Count > 0 || theS.SemiActiveWeaponsGuided.Count > 0)).Count() > 0;

	public bool WillNeedToPaintATarget
	{
		get
		{
			if (ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return false;
			}
			return ParentScen.GuidedWeaponsInAir.Where([SpecialName] (Weapon theW) => theW.FiringParent == this && theW.Flags.TerminalIllumination).Count() > 0;
		}
	}

	public bool WillNeedToPaintThisTarget
	{
		get
		{
			if (ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return false;
			}
			return ParentScen.GuidedWeaponsInAir.Where([SpecialName] (Weapon theW) =>
			{
				int result;
				if (theW.FiringParent == this)
				{
					if (theW.Flags.TerminalIllumination)
					{
						return theW.AI.PrimaryTarget == theTarget;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).Count() > 0;
		}
	}

	public bool IsPaintingThisTarget => Sensors_Cached.Where([SpecialName] (Sensor theS) => theS.TargetsTrackedForFireControl_Readonly.Contains(theTarget)).Count() > 0;

	public Contact ClosestWeaponTarget
	{
		get
		{
			if (ParentScen.GuidedWeaponsInAir.Count == 0)
			{
				return null;
			}
			IEnumerable<Weapon> source = from theWeapon in Weaponry.IsGuidingWeaponsInAir_List()
				where theWeapon.AI.PrimaryTarget != null
				orderby Module_Unit.RangeToUnit_Horiz_Angular(this, theWeapon)
				select theWeapon;
			if (source.Count() > 0)
			{
				return source.ElementAtOrDefault(0).AI.PrimaryTarget;
			}
			IEnumerable<Weapon> source2 = from theWeapon in ParentScen.GuidedWeaponsInAir.Where([SpecialName] (Weapon theW) =>
				{
					int result;
					if (theW.FiringParent == this)
					{
						if (theW.Flags.TerminalIllumination || theW.Flags.IlluminateAtLaunch)
						{
							return theW.AI.PrimaryTarget != null;
						}
						result = 0;
					}
					else
					{
						result = 0;
					}
					return (byte)result != 0;
				})
				orderby Module_Unit.RangeToUnit_Horiz_Angular(this, theWeapon)
				select theWeapon;
			if (source2.Count() > 0)
			{
				return source2.ElementAtOrDefault(0).AI.PrimaryTarget;
			}
			return null;
		}
	}

	public GlobalVariables.UnitNoiseLevelClass NoiseLevelClass
	{
		get
		{
			XSection xSection = Sensor.smethod_0(this, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
			if (xSection == null)
			{
				xSection = Sensor.smethod_0(this, XSection._SignatureType.HullSonar_PassiveOnly_VLF);
			}
			if (xSection == null)
			{
				return GlobalVariables.UnitNoiseLevelClass.Quiet;
			}
			float num = xSection.get_Rear(this);
			if (num >= 100f)
			{
				if (num < 120f)
				{
					return GlobalVariables.UnitNoiseLevelClass.VQuiet;
				}
				if (num < 130f)
				{
					return GlobalVariables.UnitNoiseLevelClass.Quiet;
				}
				if (num < 140f)
				{
					return GlobalVariables.UnitNoiseLevelClass.Noisy;
				}
				return GlobalVariables.UnitNoiseLevelClass.Loud;
			}
			return GlobalVariables.UnitNoiseLevelClass.ExQuiet;
		}
	}

	public virtual GlobalVariables.TargetVisualSizeClass VisualSizeClass
	{
		get
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw new NotImplementedException();
		}
	}

	public virtual float Fuel_FreeLoad
	{
		get
		{
			float result = default(float);
			try
			{
				FuelRec fuelRec = Fuel_ReadOnly[0];
				result = (float)fuelRec.MaxQuantity - fuelRec.CurrentQuantity;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100006", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public virtual int SafeDistanceAgainstUnknownMine_meters
	{
		get
		{
			if (!UsePathfindingBufferDistance)
			{
				return method_4();
			}
			return method_4() * 3;
		}
	}

	public virtual int SafeDistanceAgainstKnownMineType_meters
	{
		get
		{
			int result;
			try
			{
				if (IsMCMPlatform_ThisPulse == -1)
				{
					Determine_IsMCMPlatform();
				}
				if (IsMineLayingPlatform_ThisPulse == -1)
				{
					Determine_IsMineLayingPlatform();
				}
				Weapon._WeaponType weaponType = theType;
				result = ((weaponType == Weapon._WeaponType.RisingMine) ? ((IsMCMPlatform_ThisPulse == 0 && IsMineLayingPlatform_ThisPulse == 0) ? ((!UsePathfindingBufferDistance) ? method_4() : Math.Max(method_4() * 3, 1000)) : ((!UsePathfindingBufferDistance) ? ((int)Math.Round((double)method_4() * 0.1)) : Math.Max((int)Math.Round((double)method_4() * 0.3), 1000))) : ((IsMCMPlatform_ThisPulse == 0 && IsMineLayingPlatform_ThisPulse == 0) ? (UsePathfindingBufferDistance ? 1000 : 400) : ((!UsePathfindingBufferDistance) ? 100 : 1000)));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100010", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				if (UsePathfindingBufferDistance)
				{
					result = 1000;
					ProjectData.ClearProjectError();
				}
				else
				{
					result = 400;
					ProjectData.ClearProjectError();
				}
			}
			return result;
		}
	}

	public bool HasRunwaysOrPads
	{
		get
		{
			AirFacility[] airFacilities_ReadOnly = AirFacilities_ReadOnly;
			for (int i = 0; i < airFacilities_ReadOnly.Length; i = checked(i + 1))
			{
				if (airFacilities_ReadOnly[i].IsRunwayOrPad())
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool HasAirFacilities
	{
		get
		{
			int result;
			if (AirFacilities_ReadOnly != null)
			{
				if (AirFacilities_ReadOnly.Length > 0)
				{
					return true;
				}
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool HasCargo => OnboardCargo.Count() != 0;

	public bool HasDockFacilities
	{
		get
		{
			int result;
			if (DockFacilities_ReadOnly == null)
			{
				result = 0;
			}
			else
			{
				if (DockFacilities_ReadOnly.Length > 0)
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public bool HasRadarSensor
	{
		get
		{
			bool result = default(bool);
			try
			{
				List<Sensor> list = new List<Sensor>(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Sensor sensor = list[i];
					if (sensor != null && sensor.Type == Sensor.Sensor_Type.Radar)
					{
						result = true;
						return result;
					}
				}
				int num3;
				if (IsWeapon)
				{
					Weapon weapon = (Weapon)this;
					Warhead[] warheads = weapon.Warheads;
					foreach (Warhead warhead in warheads)
					{
						if (warhead.Type != Warhead.WarheadType.Weapon)
						{
							continue;
						}
						Weapon weapon2 = warhead.get_CarriedWeapon(weapon.ParentScen);
						List<Sensor> list2 = new List<Sensor>(weapon2.Sensors_Cached);
						int num2 = list2.Count - 1;
						for (int k = 0; k <= num2; k++)
						{
							Sensor sensor = list2[k];
							if (sensor.Type == Sensor.Sensor_Type.Radar)
							{
								result = true;
								return result;
							}
						}
					}
					num3 = 0;
				}
				else
				{
					num3 = 0;
				}
				result = (byte)num3 != 0;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100014", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasSonarSensor
	{
		get
		{
			bool result = default(bool);
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Sensor sensor = list[i];
					if (sensor != null && sensor.IsSonar)
					{
						result = true;
						return result;
					}
				}
				if (IsWeapon)
				{
					Weapon weapon = (Weapon)this;
					Warhead[] warheads = weapon.Warheads;
					foreach (Warhead warhead in warheads)
					{
						if (warhead.Type != Warhead.WarheadType.Weapon)
						{
							continue;
						}
						Weapon weapon2 = warhead.get_CarriedWeapon(weapon.ParentScen);
						List<Sensor> list2 = new List<Sensor>();
						list2.AddRange(weapon2.Sensors_Cached);
						int num2 = list2.Count - 1;
						for (int k = 0; k <= num2; k++)
						{
							Sensor sensor = list2[k];
							if (sensor.IsSonar)
							{
								result = true;
								return result;
							}
						}
					}
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100014", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasOECMSensor
	{
		get
		{
			bool result = default(bool);
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Sensor sensor = list[i];
					if (sensor != null && sensor.IsOECM)
					{
						result = true;
						return result;
					}
				}
				int num2;
				if (!IsWeapon)
				{
					num2 = 0;
				}
				else
				{
					Weapon weapon = (Weapon)this;
					Warhead[] warheads = weapon.Warheads;
					foreach (Warhead warhead in warheads)
					{
						if (warhead.Type != Warhead.WarheadType.Weapon)
						{
							continue;
						}
						Weapon weapon2 = warhead.get_CarriedWeapon(weapon.ParentScen);
						List<Sensor> list2 = new List<Sensor>();
						list2.AddRange(weapon2.Sensors_Cached);
						int num3 = list2.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							Sensor sensor = list2[k];
							if (sensor.IsOECM)
							{
								result = true;
								return result;
							}
						}
					}
					num2 = 0;
				}
				result = (byte)num2 != 0;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100014", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasInfraredSensor
	{
		get
		{
			bool result = default(bool);
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (list[num2].Type == Sensor.Sensor_Type.Infrared)
						{
							break;
						}
						num2++;
						continue;
					}
					result = false;
					return result;
				}
				result = true;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100015", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasLaserSpotTracker
	{
		get
		{
			bool result = default(bool);
			try
			{
				List<Sensor> list = new List<Sensor>();
				list.AddRange(Sensors_Cached);
				int num = list.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list[i].Type == Sensor.Sensor_Type.LaserSpotTracker)
					{
						result = true;
						return result;
					}
				}
				result = false;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100015", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public virtual bool IsPerformingStandoffAttack
	{
		get
		{
			return _IsPerformingStandoffAttack;
		}
		set
		{
			_IsPerformingStandoffAttack = value;
		}
	}

	public string LastBarkText
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public static event ChangedThrottleSettingEventHandler ChangedThrottleSetting
	{
		[CompilerGenerated]
		add
		{
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler = changedThrottleSettingEventHandler_0;
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler2;
			do
			{
				changedThrottleSettingEventHandler2 = changedThrottleSettingEventHandler;
				ChangedThrottleSettingEventHandler value2 = (ChangedThrottleSettingEventHandler)Delegate.Combine(changedThrottleSettingEventHandler2, value);
				changedThrottleSettingEventHandler = Interlocked.CompareExchange(ref changedThrottleSettingEventHandler_0, value2, changedThrottleSettingEventHandler2);
			}
			while ((object)changedThrottleSettingEventHandler != changedThrottleSettingEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler = changedThrottleSettingEventHandler_0;
			ChangedThrottleSettingEventHandler changedThrottleSettingEventHandler2;
			do
			{
				changedThrottleSettingEventHandler2 = changedThrottleSettingEventHandler;
				ChangedThrottleSettingEventHandler value2 = (ChangedThrottleSettingEventHandler)Delegate.Remove(changedThrottleSettingEventHandler2, value);
				changedThrottleSettingEventHandler = Interlocked.CompareExchange(ref changedThrottleSettingEventHandler_0, value2, changedThrottleSettingEventHandler2);
			}
			while ((object)changedThrottleSettingEventHandler != changedThrottleSettingEventHandler2);
		}
	}

	public static event ParentGroupChangedEventHandler ParentGroupChanged
	{
		[CompilerGenerated]
		add
		{
			ParentGroupChangedEventHandler parentGroupChangedEventHandler = parentGroupChangedEventHandler_0;
			ParentGroupChangedEventHandler parentGroupChangedEventHandler2;
			do
			{
				parentGroupChangedEventHandler2 = parentGroupChangedEventHandler;
				ParentGroupChangedEventHandler value2 = (ParentGroupChangedEventHandler)Delegate.Combine(parentGroupChangedEventHandler2, value);
				parentGroupChangedEventHandler = Interlocked.CompareExchange(ref parentGroupChangedEventHandler_0, value2, parentGroupChangedEventHandler2);
			}
			while ((object)parentGroupChangedEventHandler != parentGroupChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ParentGroupChangedEventHandler parentGroupChangedEventHandler = parentGroupChangedEventHandler_0;
			ParentGroupChangedEventHandler parentGroupChangedEventHandler2;
			do
			{
				parentGroupChangedEventHandler2 = parentGroupChangedEventHandler;
				ParentGroupChangedEventHandler value2 = (ParentGroupChangedEventHandler)Delegate.Remove(parentGroupChangedEventHandler2, value);
				parentGroupChangedEventHandler = Interlocked.CompareExchange(ref parentGroupChangedEventHandler_0, value2, parentGroupChangedEventHandler2);
			}
			while ((object)parentGroupChangedEventHandler != parentGroupChangedEventHandler2);
		}
	}

	public static event NameChangedEventHandler NameChanged
	{
		[CompilerGenerated]
		add
		{
			NameChangedEventHandler nameChangedEventHandler = nameChangedEventHandler_0;
			NameChangedEventHandler nameChangedEventHandler2;
			do
			{
				nameChangedEventHandler2 = nameChangedEventHandler;
				NameChangedEventHandler value2 = (NameChangedEventHandler)Delegate.Combine(nameChangedEventHandler2, value);
				nameChangedEventHandler = Interlocked.CompareExchange(ref nameChangedEventHandler_0, value2, nameChangedEventHandler2);
			}
			while ((object)nameChangedEventHandler != nameChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NameChangedEventHandler nameChangedEventHandler = nameChangedEventHandler_0;
			NameChangedEventHandler nameChangedEventHandler2;
			do
			{
				nameChangedEventHandler2 = nameChangedEventHandler;
				NameChangedEventHandler value2 = (NameChangedEventHandler)Delegate.Remove(nameChangedEventHandler2, value);
				nameChangedEventHandler = Interlocked.CompareExchange(ref nameChangedEventHandler_0, value2, nameChangedEventHandler2);
			}
			while ((object)nameChangedEventHandler != nameChangedEventHandler2);
		}
	}

	public static event ActiveUnitMountsAddedEventHandler ActiveUnitMountsAdded
	{
		[CompilerGenerated]
		add
		{
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler = activeUnitMountsAddedEventHandler_0;
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler2;
			do
			{
				activeUnitMountsAddedEventHandler2 = activeUnitMountsAddedEventHandler;
				ActiveUnitMountsAddedEventHandler value2 = (ActiveUnitMountsAddedEventHandler)Delegate.Combine(activeUnitMountsAddedEventHandler2, value);
				activeUnitMountsAddedEventHandler = Interlocked.CompareExchange(ref activeUnitMountsAddedEventHandler_0, value2, activeUnitMountsAddedEventHandler2);
			}
			while ((object)activeUnitMountsAddedEventHandler != activeUnitMountsAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler = activeUnitMountsAddedEventHandler_0;
			ActiveUnitMountsAddedEventHandler activeUnitMountsAddedEventHandler2;
			do
			{
				activeUnitMountsAddedEventHandler2 = activeUnitMountsAddedEventHandler;
				ActiveUnitMountsAddedEventHandler value2 = (ActiveUnitMountsAddedEventHandler)Delegate.Remove(activeUnitMountsAddedEventHandler2, value);
				activeUnitMountsAddedEventHandler = Interlocked.CompareExchange(ref activeUnitMountsAddedEventHandler_0, value2, activeUnitMountsAddedEventHandler2);
			}
			while ((object)activeUnitMountsAddedEventHandler != activeUnitMountsAddedEventHandler2);
		}
	}

	public static event ActiveUnitMountsRemovedEventHandler ActiveUnitMountsRemoved
	{
		[CompilerGenerated]
		add
		{
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler = activeUnitMountsRemovedEventHandler_0;
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler2;
			do
			{
				activeUnitMountsRemovedEventHandler2 = activeUnitMountsRemovedEventHandler;
				ActiveUnitMountsRemovedEventHandler value2 = (ActiveUnitMountsRemovedEventHandler)Delegate.Combine(activeUnitMountsRemovedEventHandler2, value);
				activeUnitMountsRemovedEventHandler = Interlocked.CompareExchange(ref activeUnitMountsRemovedEventHandler_0, value2, activeUnitMountsRemovedEventHandler2);
			}
			while ((object)activeUnitMountsRemovedEventHandler != activeUnitMountsRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler = activeUnitMountsRemovedEventHandler_0;
			ActiveUnitMountsRemovedEventHandler activeUnitMountsRemovedEventHandler2;
			do
			{
				activeUnitMountsRemovedEventHandler2 = activeUnitMountsRemovedEventHandler;
				ActiveUnitMountsRemovedEventHandler value2 = (ActiveUnitMountsRemovedEventHandler)Delegate.Remove(activeUnitMountsRemovedEventHandler2, value);
				activeUnitMountsRemovedEventHandler = Interlocked.CompareExchange(ref activeUnitMountsRemovedEventHandler_0, value2, activeUnitMountsRemovedEventHandler2);
			}
			while ((object)activeUnitMountsRemovedEventHandler != activeUnitMountsRemovedEventHandler2);
		}
	}

	static ActiveUnit()
	{
		Class72.smethod_20();
		WEAPON_TOT_ACCEPTABLE_ERROR = 10f;
		FP_RECALC_THREASHOLD = 300f;
		str_TemporaryEmission_0 = new Str_TemporaryEmission[Enum.GetValues(typeof(XSection._SignatureType)).Length - 1 + 1];
	}

	~ActiveUnit()
	{
		if (pooledList_0 != null)
		{
			pooledList_0.Dispose();
		}
		if (Kills != null)
		{
			Kills.Dispose();
		}
		base.Finalize();
	}

	public void ToggleUnitAsDecoyForCurrentSide(string theSideID)
	{
		if (pooledList_0.Contains(theSideID))
		{
			pooledList_0.Remove(theSideID);
		}
		else
		{
			pooledList_0.Add(theSideID);
		}
	}

	public bool IsDrone()
	{
		if (!IsPlatform)
		{
			return false;
		}
		return ((Platform)this).Crew == 0;
	}

	public virtual float GetSpeedForETACalculation(float travelDistance_nm)
	{
		return MaxSpeed;
	}

	public virtual void ReleaseReferences()
	{
		try
		{
			ParentScen = null;
			_UnitSide = null;
			if (IsGroup)
			{
				((Group)this).Units = null;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool IsExhausted()
	{
		return false;
	}

	public void updateLastReportedInfo()
	{
		if (!CommStuff.IsConnectedToSideNetwork)
		{
			LastReportedInfoSanityCheck();
		}
		else
		{
			setLastReportedInfo(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), CurrentHeading, ObjectID);
		}
	}

	public void setLastReportedInfo(double Longitude, double Latitude, float Altitude, float Heading, string ReportingUnitObjectID)
	{
		nullable_10 = Longitude;
		nullable_11 = Latitude;
		nullable_12 = Altitude;
		nullable_13 = Heading;
		string_1 = ReportingUnitObjectID;
		if (ParentScen != null)
		{
			nullable_9 = ParentScen.Time;
		}
	}

	public void LastReportedInfoSanityCheck()
	{
		if (!Longitude_LastReported.HasValue)
		{
			nullable_10 = this.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		if (!Latitude_LastReported.HasValue)
		{
			nullable_11 = this.get_Latitude((GlobalVariables.BooleanObject)null);
		}
		if (!Altitude_LastReported.HasValue)
		{
			nullable_11 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		if (!Heading_LastReported.HasValue)
		{
			nullable_11 = CurrentHeading;
		}
		if (!nullable_9.HasValue && ParentScen != null)
		{
			nullable_9 = ParentScen.Time;
		}
		if (string.IsNullOrEmpty(LastReportedInfo_MostRecentReportingUnitObjectID))
		{
			string_1 = ObjectID;
		}
	}

	public void LastReportedInfoReinitialize()
	{
		nullable_10 = null;
		nullable_11 = null;
		nullable_12 = null;
		nullable_13 = null;
		nullable_9 = null;
		string_1 = null;
	}

	public bool isLastReportedInfoXMLField(string name)
	{
		int result;
		switch (name)
		{
		case "LatLR":
			result = 1;
			break;
		case "AltLR":
			result = 1;
			break;
		case "HeaLR":
			result = 1;
			break;
		case "LR_mrut":
			result = 1;
			break;
		default:
			return false;
		case "LonLR":
		case "LR_mrruoid":
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	public void LastReportedInfoFromXMLField(string name, string innerText)
	{
		switch (name)
		{
		case "LonLR":
			nullable_10 = XmlConvert.ToDouble(innerText.Replace(",", "."));
			break;
		case "LatLR":
			nullable_11 = XmlConvert.ToDouble(innerText.Replace(",", "."));
			break;
		case "AltLR":
			nullable_12 = XmlConvert.ToSingle(innerText.Replace(",", "."));
			break;
		case "HeaLR":
			nullable_13 = XmlConvert.ToSingle(innerText.Replace(",", "."));
			break;
		case "LR_mrut":
			nullable_9 = DateTime.FromBinary(Conversions.ToLong(innerText));
			break;
		case "LR_mrruoid":
			string_1 = innerText;
			break;
		}
	}

	public void LastReportedInfoToXML(ref XmlWriter theWriter)
	{
		if (nullable_10.HasValue)
		{
			theWriter.WriteElementString("LonLR", XmlConvert.ToString(Longitude_LastReported.Value));
		}
		if (nullable_11.HasValue)
		{
			theWriter.WriteElementString("LatLR", XmlConvert.ToString(Latitude_LastReported.Value));
		}
		if (nullable_12.HasValue)
		{
			theWriter.WriteElementString("AltLR", XmlConvert.ToString(Altitude_LastReported.Value));
		}
		if (nullable_13.HasValue)
		{
			theWriter.WriteElementString("HeaLR", XmlConvert.ToString(Heading_LastReported.Value));
		}
		if (nullable_9.HasValue)
		{
			theWriter.WriteElementString("LR_mrut", nullable_9.Value.ToBinary().ToString());
		}
		if (!string.IsNullOrEmpty(string_1))
		{
			theWriter.WriteElementString("LR_mrruoid", string_1);
		}
	}

	public void AddNewJourneyWaypoint()
	{
		if (IsStoringJourney)
		{
			Journey.AddWaypoint(new TravelWaypoint(new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), ParentScen.Time, CurrentSpeed, CurrentHeading));
		}
	}

	public virtual float Attitude_Pitch_Derived()
	{
		float num = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - base.Altitude_old;
		if (num == 0f)
		{
			return 0f;
		}
		double x = (double)Math2.CalcDist(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), Latitude_old, Longitude_old) * 1852.0;
		double num2 = Math.Atan2(Math.Abs(num), x) * 57.2957795130823;
		if (num <= 0f)
		{
			return 0f - (float)num2;
		}
		return (float)num2;
	}

	public double Latitude_KnownOperating()
	{
		return _Latitude;
	}

	public double Longitude_KnownOperating()
	{
		return _Longitude;
	}

	public bool IsWithinGroupHierarchy(Module_Unit.Unit Unit)
	{
		if (Unit != null && Unit.IsGroup)
		{
			if (this.get_ParentGroup(UsingMissionPlanner: false) == Unit)
			{
				return true;
			}
			Group obj = (Group)Unit;
			foreach (KeyValuePair<string, ActiveUnit> unit in obj.Units)
			{
				if (unit.Value != this && IsWithinGroupHierarchy(unit.Value))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public bool IsNavalUnit()
	{
		switch (UnitType)
		{
		case GlobalVariables.ActiveUnitType.Ship:
		case GlobalVariables.ActiveUnitType.Submarine:
			return true;
		default:
			return false;
		case GlobalVariables.ActiveUnitType.Weapon:
			return ((Weapon)this).IsTorpedo;
		}
	}

	public bool IsOnActivePatrol(Mission theMission)
	{
		Mission mission = ((theMission != null) ? theMission : ActiveMissionOrPackage());
		if (mission == null)
		{
			return false;
		}
		if (!mission.IsActive)
		{
			return false;
		}
		return mission.MissionClass == Mission._MissionClass.Patrol;
	}

	public bool IsOnActivePatrol()
	{
		Mission mission = ActiveMissionOrPackage();
		if (mission != null)
		{
			if (!mission.IsActive)
			{
				return false;
			}
			return mission.MissionClass == Mission._MissionClass.Patrol;
		}
		return false;
	}

	public virtual void Determine_IsMCMPlatform()
	{
		IsMCMPlatform_ThisPulse = 0;
	}

	public virtual void Determine_IsMineLayingPlatform()
	{
		IsMineLayingPlatform_ThisPulse = 0;
	}

	internal AirContrailSize ContrailSize()
	{
		if (!IsSatellite)
		{
			float num = this.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue);
			try
			{
				if (num != num)
				{
					return AirContrailSize.NoContrail;
				}
				if (num > 100000f)
				{
					return AirContrailSize.NoContrail;
				}
				if (IsAircraft && ((Aircraft)this).IsAirship)
				{
					return AirContrailSize.NoContrail;
				}
				if (Propulsion.Count == 0)
				{
					return AirContrailSize.NoContrail;
				}
				int result;
				switch (Propulsion[0].Type)
				{
				case Engine.EngineType.Electric:
					result = 0;
					break;
				default:
				{
					short num2 = WeatherAtMyLocation.ActualTempAtAltitude_CurrentScenarioTime(ParentScen, this.get_Latitude(GlobalVariables.ObjectTrue), this.get_Longitude(GlobalVariables.ObjectTrue), num);
					if (num2 > -40)
					{
						return AirContrailSize.NoContrail;
					}
					if (IsWeapon)
					{
						if (Propulsion.Count <= 0)
						{
							return AirContrailSize.NoContrail;
						}
						switch (Propulsion[0].Type)
						{
						case Engine.EngineType.Rocket_BoostCoast:
						case Engine.EngineType.Rocket_LongBurn:
						case Engine.EngineType.Ramjet:
							if (!((Weapon)this).UsesBoostCoastModel.Value)
							{
								if (((Weapon)this).TimeSinceLaunch > 5f)
								{
									return AirContrailSize.NoContrail;
								}
							}
							else if (((Weapon)this).TimeSinceLaunch > (float)((Weapon)this).TotalBurnTime)
							{
								return AirContrailSize.NoContrail;
							}
							break;
						case Engine.EngineType.None:
						case Engine.EngineType.Nuclear:
						case Engine.EngineType.Electric:
						case Engine.EngineType.WeaponCoast:
							return AirContrailSize.NoContrail;
						}
					}
					AirContrailSize airContrailSize;
					switch (VisualSizeClass)
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						throw new NotImplementedException();
					case GlobalVariables.TargetVisualSizeClass.Stealthy:
						airContrailSize = AirContrailSize.NoContrail;
						break;
					case GlobalVariables.TargetVisualSizeClass.VSmall:
						airContrailSize = AirContrailSize.VSmall;
						break;
					case GlobalVariables.TargetVisualSizeClass.Small:
						airContrailSize = AirContrailSize.Small;
						break;
					case GlobalVariables.TargetVisualSizeClass.Medium:
						airContrailSize = AirContrailSize.Medium;
						break;
					case GlobalVariables.TargetVisualSizeClass.Large:
						airContrailSize = AirContrailSize.Large;
						break;
					case GlobalVariables.TargetVisualSizeClass.VLarge:
						airContrailSize = AirContrailSize.VLarge;
						break;
					}
					if (num2 <= 233 && num2 > 223)
					{
						airContrailSize--;
					}
					return airContrailSize;
				}
				case Engine.EngineType.Nuclear:
					result = 0;
					break;
				}
				return (AirContrailSize)result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
		return AirContrailSize.NoContrail;
	}

	private CommDevice[] method_1()
	{
		CommDevice[] array = new CommDevice[_Comms.Length - 1 + 1];
		if (_Comms.Length > 0)
		{
			Array.Copy(_Comms, array, _Comms.Length);
		}
		return array;
	}

	internal virtual PooledList<Sensor> GetAllSensors()
	{
		PooledList<Sensor> pooledList = default(PooledList<Sensor>);
		foreach (Sensor sensor2 in _Sensors)
		{
			if (!sensor2.IsMineCountermeasure)
			{
				if (pooledList == null)
				{
					pooledList = new PooledList<Sensor>(_Sensors.Count, Pools<Sensor>.Local);
				}
				pooledList.Add(sensor2);
			}
		}
		int num = Mounts.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			Sensor[] sensors_ReadOnly = Mounts[i].Sensors_ReadOnly;
			foreach (Sensor sensor in sensors_ReadOnly)
			{
				if (!sensor.IsMineCountermeasure)
				{
					sensor.IsSensorInMount = true;
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>(Pools<Sensor>.Local);
					}
					pooledList.Add(sensor);
				}
			}
		}
		return pooledList;
	}

	public virtual Sensor[] Sensors_ReadOnly()
	{
		PooledList<Sensor> allSensors = default(PooledList<Sensor>);
		Sensor[] result = default(Sensor[]);
		try
		{
			allSensors = GetAllSensors();
			if (allSensors != null && allSensors.Count > 0)
			{
				Sensor[] array = allSensors.ToArray();
				Sensor[] array2 = array;
				foreach (Sensor sensor in array2)
				{
					if (sensor != null && sensor.IsOECM && sensor.ParentPlatform != null)
					{
						sensor.ParentPlatform.AttachedTo = this;
					}
				}
				result = array;
				return result;
			}
			if (allSensors == null)
			{
				result = Array.Empty<Sensor>();
				return result;
			}
			result = allSensors.ToArray();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101185", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			allSensors?.Dispose();
		}
		return result;
	}

	public virtual float FuelConsumption(Throttle theThrottleSetting, AltBand theAltBand, float? theSpeed, float? theAltitude, bool BingoFuelCheck, bool ReserveFuelQtyCalc, bool ExcludeDroppablePayload, bool ValidateThrottleSelection, bool FlightplanFuelEstimate)
	{
		return 1E-07f;
	}

	public Mission AssignedMissionOrPackage()
	{
		Side side = null;
		Mission result;
		try
		{
			if (_AssignedMissionOrPackage != null || string.IsNullOrEmpty(_AssignedMissionOrPackage_ID))
			{
				goto IL_00a1;
			}
			side = this.get_UnitSide(SetSideOnly: false);
			if (side != null)
			{
				ReadOnlyCollection<Mission> readOnlyCollection = side.get_MissionsTotal(ParentScen);
				int num = readOnlyCollection.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					Mission mission = readOnlyCollection[i];
					if (mission != null && Operators.CompareString(mission.ObjectID, _AssignedMissionOrPackage_ID, false) == 0)
					{
						_AssignedMissionOrPackage = mission;
						mission.UnitsAssignedToMission.TryAdd(this, this);
						break;
					}
				}
				if (_AssignedMissionOrPackage == null)
				{
					_AssignedMissionOrPackage_ID = null;
				}
				goto IL_00a1;
			}
			result = null;
			goto end_IL_0002;
			IL_00a1:
			Mission assignedMissionOrPackage = _AssignedMissionOrPackage;
			if (assignedMissionOrPackage != null && assignedMissionOrPackage.Category == Mission.MissionCategory.Package)
			{
				if (side == null)
				{
					side = this.get_UnitSide(SetSideOnly: false);
				}
				if (!string.IsNullOrEmpty(_AssignedMissionOrPackage.get_ParentTaskPoolID(side)))
				{
					_AssignedTaskPool_ID = _AssignedMissionOrPackage.get_ParentTaskPoolID(side);
				}
			}
			result = _AssignedMissionOrPackage;
			end_IL_0002:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101188", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual Mission ActiveMissionOrPackage()
	{
		if (PrivateSnapshotMission != null && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && IsDrone())
		{
			return PrivateSnapshotMission;
		}
		return AssignedMissionOrPackage();
	}

	public void AssignMissionInQueue(Mission _Mission)
	{
		if (_Mission == null)
		{
			return;
		}
		AllowMultiMission = true;
		if (ActiveMissionOrPackage() == _Mission)
		{
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			Set_AssignedMissionOrPackage(null, SetMissionOnly: true, IgnoreCommsState: true, ref Result);
			if (!AssignedMissionsQueue.ContainsKey(_Mission))
			{
				AssignedMissionsQueue.Add(_Mission, _Mission);
				if (!_Mission.UnitsQueuedToMission.ContainsKey(this))
				{
					_Mission.UnitsQueuedToMission.Add(this, this);
				}
			}
		}
		else if (!AssignedMissionsQueue.ContainsKey(_Mission))
		{
			AssignedMissionsQueue.Add(_Mission, _Mission);
			if (!_Mission.UnitsQueuedToMission.ContainsKey(this))
			{
				_Mission.UnitsQueuedToMission.Add(this, this);
			}
		}
	}

	public void UnassignAllMissionInQueue()
	{
		foreach (Mission item in AssignedMissionsQueue.Values.ToList())
		{
			UnassignMissionInQueue(item);
		}
	}

	public void UnassignMissionInQueue(Mission _Mission)
	{
		if (!Information.IsNothing((object)_Mission) && AssignedMissionsQueue.ContainsKey(_Mission))
		{
			AssignedMissionsQueue.Remove(_Mission);
			if (_Mission.UnitsQueuedToMission.ContainsKey(this))
			{
				_Mission.UnitsQueuedToMission.Remove(this);
			}
		}
	}

	public virtual void Set_AssignedMissionOrPackage(Mission value, bool SetMissionOnly, bool IgnoreCommsState, [Optional][DefaultParameterValue(0)] ref Mission.MissionAssignmentAttemptResult Result)
	{
		try
		{
			Mission mission = ActiveMissionOrPackage();
			if (!IgnoreCommsState && !CommStuff.IsConnectedToSideNetwork)
			{
				Result = Mission.MissionAssignmentAttemptResult.Fail_OutOfComms;
				return;
			}
			bool flag = value != _AssignedMissionOrPackage;
			if (value != null)
			{
				if (value.Category == Mission.MissionCategory.TaskPool)
				{
					_AssignedTaskPool = value;
					_AssignedTaskPool_ID = value.ObjectID;
					if (mission != null)
					{
						ConcurrentDictionary<ActiveUnit, ActiveUnit> unitsAssignedToMission = mission.UnitsAssignedToMission;
						ActiveUnit value2 = this;
						unitsAssignedToMission.TryRemove(this, out value2);
					}
					value.UnitsAssignedToMission.TryAdd(this, this);
					Result = Mission.MissionAssignmentAttemptResult.Success;
					return;
				}
				_AssignedMissionOrPackage = value;
				_AssignedMissionOrPackage_ID = value.ObjectID;
				if (mission != null)
				{
					ConcurrentDictionary<ActiveUnit, ActiveUnit> unitsAssignedToMission2 = mission.UnitsAssignedToMission;
					ActiveUnit value2 = this;
					unitsAssignedToMission2.TryRemove(this, out value2);
				}
				value.UnitsAssignedToMission.TryAdd(this, this);
				if (value != null && value.MissionClass == Mission._MissionClass.Mining)
				{
					AI.MiningInfo = null;
				}
				if (SetMissionOnly)
				{
					Result = Mission.MissionAssignmentAttemptResult.Success;
					return;
				}
				if (!GlobalVariables.AI_REWORK)
				{
					Status = _ActiveUnitStatus.Tasked;
				}
				if (this.get_UnitSide(SetSideOnly: false) != null)
				{
					this.get_UnitSide(SetSideOnly: false).Missions_Add(value);
				}
				if (Navigator.HasPlottedCourse() && flag && Navigator.PlottedCourse[0].Type != Waypoint.WaypointType.ManualPlottedCourseWaypoint)
				{
					Navigator.ClearPlottedCourse();
					if (Navigator.HasFlightPlan)
					{
						Navigator.get_Flight(HierarchySearch: true).ClearFlightPlan();
					}
				}
				if (value.MissionClass != Mission._MissionClass.Escort)
				{
					AI.EscortTargetID = null;
				}
				if (value.MissionClass == Mission._MissionClass.Ferry)
				{
					switch (((FerryMission)value).Behavior)
					{
					case FerryMission.FerryMissionBehavior.Random:
						if (!IsAircraft)
						{
							DockingOps.PickNewAssignedHost_RandomWithinRange(DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false));
						}
						else
						{
							((Aircraft)this).AirOps.PickNewAssignedHost_RandomWithinRange(((Aircraft)this).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false));
						}
						break;
					case FerryMission.FerryMissionBehavior.Cycle:
						AI.InitializeCycleFerry();
						break;
					}
				}
			}
			else
			{
				if (AI.Targets_ReadOnly.Length > 0)
				{
					bool isInsidePatrolArea_10nmBuffer = AI.IsInsidePatrolArea_10nmBuffer;
					Contact[] targets_ReadOnly = AI.Targets_ReadOnly;
					foreach (Contact contact in targets_ReadOnly)
					{
						if (AI.TargetingBehaviorForThisTarget(contact, null) == ActiveUnit_AI.TargetingEntry._TargetingBehavior.AutoTargeted)
						{
							ActiveUnit_AI aI = AI;
							Mission assignedMissionOrPackage = _AssignedMissionOrPackage;
							Doctrine._UseShootTourists? canShootTourists = Doctrine.get_ShootTourists(ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
							string Feedback = "";
							int FeedbackSeverity = 0;
							if (aI.ContactIsRelevantToFlightOrMission(contact, assignedMissionOrPackage, canShootTourists, IgnoreContacStance: false, isInsidePatrolArea_10nmBuffer, IgnoreNeutralContacts: true, null, ref Feedback, ref FeedbackSeverity))
							{
								AI.DropTarget(contact);
							}
						}
					}
				}
				if (_AssignedMissionOrPackage == null || (_AssignedMissionOrPackage != null && _AssignedMissionOrPackage.Category != Mission.MissionCategory.Package))
				{
					_AssignedTaskPool = null;
					_AssignedTaskPool_ID = "";
				}
				if (mission != null && mission.MissionClass == Mission._MissionClass.Mining)
				{
					AI.MiningInfo = null;
				}
				if (mission != null)
				{
					ConcurrentDictionary<ActiveUnit, ActiveUnit> unitsAssignedToMission3 = mission.UnitsAssignedToMission;
					ActiveUnit value2 = this;
					unitsAssignedToMission3.TryRemove(this, out value2);
				}
				_AssignedMissionOrPackage = null;
				_AssignedMissionOrPackage_ID = "";
				if (SetMissionOnly)
				{
					Result = Mission.MissionAssignmentAttemptResult.Success;
					return;
				}
				if (!this.IsRTB && !GlobalVariables.AI_REWORK)
				{
					Status = _ActiveUnitStatus.Unassigned;
				}
			}
			if (flag)
			{
				AI.IsEscort = false;
				AI.ClearMissionStateFlags();
				if (IsGroupLead())
				{
					Group obj = this.get_ParentGroup(UsingMissionPlanner: false);
					Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
					obj.Set_AssignedMissionOrPackage(value, SetMissionOnly: false, IgnoreCommsState: false, ref Result2);
				}
			}
			ParentScen.FIX_WpnReleaseAltitude(value);
			Result = Mission.MissionAssignmentAttemptResult.Success;
			if (!(GameGeneral.Beta_PlatformComms & ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)))
			{
				return;
			}
			if (value == null)
			{
				if (mission == null || this.get_UnitSide(SetSideOnly: false).CommNetworks == null)
				{
					return;
				}
				string text = null;
				foreach (KeyValuePair<string, CommNetwork> commNetwork in this.get_UnitSide(SetSideOnly: false).CommNetworks)
				{
					if (Operators.CompareString(commNetwork.Value.ReferenceObjectID, mission.ObjectID, false) == 0)
					{
						this.get_UnitSide(SetSideOnly: false).RemoveUnitFromNetwork(commNetwork.Key, this);
						if (commNetwork.Value.Members == null || commNetwork.Value.Members.Count == 0)
						{
							text = commNetwork.Key;
						}
						break;
					}
				}
				if (text != null)
				{
					this.get_UnitSide(SetSideOnly: false).RemoveCommNetwork(text);
				}
				return;
			}
			if (this.get_UnitSide(SetSideOnly: false).CommNetworks != null)
			{
				foreach (KeyValuePair<string, CommNetwork> commNetwork2 in this.get_UnitSide(SetSideOnly: false).CommNetworks)
				{
					if (Operators.CompareString(commNetwork2.Value.ReferenceObjectID, value.ObjectID, false) == 0)
					{
						this.get_UnitSide(SetSideOnly: false).AddUnitToNetwork(commNetwork2.Key, this);
						return;
					}
				}
			}
			this.get_UnitSide(SetSideOnly: false).CreateNextNetworkUnitsReason(new HashSet<Module_Unit.Unit> { this }, CommNetwork.NetworkCreationReason.Mission, value.ObjectID, value.Name);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101189", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Result = Mission.MissionAssignmentAttemptResult.Fail_Other;
			ProjectData.ClearProjectError();
		}
	}

	internal Mission.MissionAssignmentAttemptResult AssignToMission(ref Scenario theScen, ref ActiveUnit theAU, ref Mission theMission, ref bool isEscort)
	{
		Mission.MissionAssignmentAttemptResult result = default(Mission.MissionAssignmentAttemptResult);
		try
		{
			string text = "";
			if (theAU.IsAircraft && Operators.CompareString(theAU.Name, theAU.UnitClass, false) != 0)
			{
				text = " (" + theAU.UnitClass + ")";
			}
			Mission mission = null;
			if (theAU.ActiveMissionOrPackage() != null && theMission != theAU.ActiveMissionOrPackage())
			{
				mission = theAU.ActiveMissionOrPackage();
			}
			if (theMission.Category == Mission.MissionCategory.TaskPool)
			{
				Mission.MissionAssignmentAttemptResult Result = default(Mission.MissionAssignmentAttemptResult);
				theAU.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				if (Result != Mission.MissionAssignmentAttemptResult.Success)
				{
					result = Result;
					return result;
				}
				if (mission != null && theAU.Navigator.HasFlight && mission.FlightList.Contains(theAU.Navigator.get_Flight(HierarchySearch: true)))
				{
					mission.FlightList.Remove(theAU.Navigator.get_Flight(HierarchySearch: true));
				}
				if (theAU.AssignedTaskPool == null || theAU.AssignedTaskPool != theMission)
				{
					theAU.AssignedTaskPool = theMission;
					theAU.ParentScen.AddMessage(theAU.Name + text + " has been assigned to task pool: " + theMission.Name, theAU.Name + " assigned to tak pool", LoggedMessage.MessageType.UnitAI, 0, theAU.ObjectID, theAU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
					if (theAU.IsGroup)
					{
						Group obj = (Group)theAU;
						foreach (ActiveUnit value in obj.Units.Values)
						{
							if (value.IsOperating())
							{
								value.AI.EvaluateTargets(0f, IgnoreContacStance: false, Immediately: true);
							}
						}
					}
					else if (theAU.IsOperating())
					{
						theAU.AI.EvaluateTargets(0f, IgnoreContacStance: false, Immediately: true);
					}
					theAU.Doctrine.ClearCachedParentDoctrine();
				}
				result = Result;
				return result;
			}
			if (theAU.IsGroup)
			{
				_ = ((Group)theAU).GroupLead;
			}
			Mission.MissionAssignmentAttemptResult Result2 = default(Mission.MissionAssignmentAttemptResult);
			theAU.Set_AssignedMissionOrPackage(theMission, SetMissionOnly: false, IgnoreCommsState: false, ref Result2);
			if (Result2 != Mission.MissionAssignmentAttemptResult.Success)
			{
				result = Result2;
				return result;
			}
			if (mission != null && theAU.Navigator.HasFlight && mission.FlightList.Contains(theAU.Navigator.get_Flight(HierarchySearch: true)))
			{
				mission.FlightList.Remove(theAU.Navigator.get_Flight(HierarchySearch: true));
			}
			if (theAU.ActiveMissionOrPackage().Category == Mission.MissionCategory.Package)
			{
				foreach (Mission mission2 in theAU.get_UnitSide(SetSideOnly: false).Missions)
				{
					if (Operators.CompareString(mission2.ObjectID, theAU.ActiveMissionOrPackage().get_ParentTaskPoolID(theAU.get_UnitSide(SetSideOnly: false)), false) == 0)
					{
						theAU.AssignedTaskPool = mission2;
						break;
					}
				}
			}
			else
			{
				theAU.AssignedTaskPool = null;
			}
			if (theAU.IsGroup)
			{
				foreach (ActiveUnit value2 in ((Group)theAU).Units.Values)
				{
					value2.AssignedTaskPool = theAU.AssignedTaskPool;
				}
			}
			if (theAU.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && isEscort)
			{
				if (theAU.IsGroup)
				{
					foreach (ActiveUnit value3 in ((Group)theAU).Units.Values)
					{
						value3.AI.IsEscort = true;
					}
				}
				else
				{
					theAU.AI.IsEscort = true;
				}
				theScen.AddMessage(theAU.Name + text + " has been assigned as an escort to mission: " + theMission.Name, theAU.Name + " assigned as escort", LoggedMessage.MessageType.UnitAI, 0, theAU.ObjectID, theAU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				if (theAU.IsGroup)
				{
					foreach (ActiveUnit value4 in ((Group)theAU).Units.Values)
					{
						value4.AI.IsEscort = false;
					}
				}
				else
				{
					theAU.AI.IsEscort = false;
				}
				theScen.AddMessage(theAU.Name + text + " has been assigned to mission: " + theMission.Name, theAU.Name + " assigned to mission", LoggedMessage.MessageType.UnitAI, 0, theAU.ObjectID, theAU.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(theAU.get_Longitude((GlobalVariables.BooleanObject)null), theAU.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			theAU.Doctrine.ClearCachedParentDoctrine();
			theAU.Sensory.vmethod_2(theAU.Sensors_Cached);
			if (theAU.IsGroup)
			{
				Group obj2 = (Group)theAU;
				foreach (ActiveUnit value5 in obj2.Units.Values)
				{
					if (value5.IsOperating())
					{
						value5.AI.EvaluateTargets(0f, IgnoreContacStance: false, Immediately: true);
						value5.Doctrine.ClearCachedParentDoctrine();
						value5.Sensory.vmethod_2(theAU.Sensors_Cached);
					}
				}
			}
			else if (theAU.IsOperating())
			{
				theAU.AI.EvaluateTargets(0f, IgnoreContacStance: false, Immediately: true);
			}
			theAU.Doctrine.ClearCachedParentDoctrine();
			result = Result2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101189", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void FuelCapacitySet(float theQty, FuelRec._FuelType theType)
	{
		try
		{
			using PooledList<FuelRec>.Enumerator enumerator = Fuel_ReadOnly.GetEnumerator();
			FuelRec current;
			do
			{
				if (enumerator.MoveNext())
				{
					current = enumerator.Current;
					continue;
				}
				return;
			}
			while (current.FuelType != theType);
			current.CurrentQuantity = theQty;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101227", "FuelCapacitySet");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public double FuelPercent(ref double TotalCurrent, ref double TotalMax, bool MissionFuel)
	{
		PooledList<FuelRec> pooledList = null;
		double result;
		try
		{
			if (Propulsion.Count > 0 && Propulsion[0].Type == Engine.EngineType.Nuclear)
			{
				result = 1.0;
			}
			else
			{
				if (!IsSubmarine || !((Submarine)this).IsTetheredROV || Propulsion.Count <= 0 || Propulsion[0].Type != Engine.EngineType.Electric)
				{
					goto IL_0093;
				}
				pooledList = Fuel_ReadOnly;
				if (pooledList.Count != 0)
				{
					goto IL_0093;
				}
				result = 1.0;
			}
			goto end_IL_0003;
			IL_0093:
			if (pooledList == null)
			{
				pooledList = Fuel_ReadOnly;
			}
			if (pooledList.Count != 0)
			{
				foreach (FuelRec item in pooledList)
				{
					if (item != null && (Propulsion.Count <= 0 || !IsShip || Propulsion[0].CanUseThisFuelType(item.FuelType)))
					{
						TotalCurrent += item.CurrentQuantity;
						TotalMax += item.MaxQuantity;
					}
				}
				if (MissionFuel && IsAircraft)
				{
					TotalCurrent -= Kinematics.ReserveFuel;
					TotalMax -= Kinematics.ReserveFuel;
				}
				result = ((!(TotalMax <= 0.0)) ? (TotalCurrent / TotalMax) : 0.0);
			}
			else
			{
				result = 0.0;
			}
			end_IL_0003:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101346", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		finally
		{
			if (IsAircraft)
			{
				pooledList?.Dispose();
			}
		}
		return result;
	}

	private protected virtual List<PlatformComponent> ComponentList()
	{
		List<PlatformComponent> list = ((int_4 != 0) ? new List<PlatformComponent>(int_4) : new List<PlatformComponent>());
		Sensor[] sensors_Cached = Sensors_Cached;
		foreach (Sensor item in sensors_Cached)
		{
			list.Add(item);
		}
		list.AddRange(Mounts);
		CommDevice[] comms_ReadOnly = Comms_ReadOnly;
		foreach (CommDevice item2 in comms_ReadOnly)
		{
			list.Add(item2);
		}
		list.AddRange(_DockFacilities);
		list.AddRange(_AirFacilities);
		list.AddRange(OnboardCargo);
		list.AddRange(Propulsion);
		Magazine[] sharedMagazines = SharedMagazines;
		if (sharedMagazines != null)
		{
			Magazine[] array = sharedMagazines;
			foreach (Magazine item3 in array)
			{
				list.Add(item3);
			}
		}
		return list;
	}

	internal ReadOnlyCollection<PlatformComponent> Components()
	{
		List<PlatformComponent> list = ComponentList();
		int_4 = list.Count;
		return list.AsReadOnly();
	}

	protected internal bool ProportionallyScaled(PlatformComponent theC)
	{
		return theC.IsEngine;
	}

	protected internal float GetComponentVolume(PlatformComponent theComponent, float ProportionalScalingFactor, bool isProportionallyScaled)
	{
		if (theComponent.GetType() == typeof(AirFacility))
		{
			return ((AirFacility)theComponent).Capacity;
		}
		return (!isProportionallyScaled) ? 1f : ProportionalScalingFactor;
	}

	protected virtual GlobalVariables.ArmorRating GetArmorStructureValue()
	{
		return GlobalVariables.ArmorRating.None;
	}

	protected internal virtual UnitComponentGroups GetMyComponentGroups()
	{
		UnitComponentGroups unitComponentGroups = new UnitComponentGroups();
		List<UnitComponentGroups.ComponentGroup> list = new List<UnitComponentGroups.ComponentGroup>();
		List<UnitComponentGroups.ComponentGroup> list2 = new List<UnitComponentGroups.ComponentGroup>();
		UnitComponentGroups.ComponentGroup componentGroup = unitComponentGroups.AddGroup(IsArmor: false, InsideArmor: true, IsAirWing: false, "Inside Armor");
		UnitComponentGroups.ComponentGroup componentGroup2 = unitComponentGroups.AddGroup(IsArmor: false, InsideArmor: false, IsAirWing: false, "Unarmored Components");
		UnitComponentGroups.ComponentGroup componentGroup3 = (unitComponentGroups.ArmorExterior = unitComponentGroups.AddGroup(IsArmor: false, InsideArmor: false, IsAirWing: true, "Armored Structure Exterior"));
		UnitComponentGroups.ComponentGroup componentGroup4 = unitComponentGroups.AddGroup(IsArmor: true, InsideArmor: true, IsAirWing: false, "Armored Structure");
		componentGroup4.ArmorThickness = GetArmorStructureValue();
		IEnumerable<VB$AnonymousType_3<PlatformComponent.ProtectionType, bool, bool, bool, IEnumerable<VB$AnonymousType_1<PlatformComponent, bool, bool>>, int>> enumerable = (from component in Components()
			where !component.IsSensor || !((Sensor)component).IsMk1Eyeball
			select new VB$AnonymousType_0<PlatformComponent, bool>(component, ProportionallyScaled(component)) into $VB$It
			select new VB$AnonymousType_1<PlatformComponent, bool, bool>($VB$It.component, $VB$It.Proportional, $VB$It.component.GetType() == typeof(Mount)) into $VB$It
			orderby $VB$It.Proportional
			select $VB$It).GroupBy([SpecialName] (VB$AnonymousType_1<PlatformComponent, bool, bool> $VB$It) => new VB$AnonymousType_2<PlatformComponent.ProtectionType, bool, bool, bool>($VB$It.component.GetArmor.ProtectionType, $VB$It.component.GetArmor.InsideArmoredStructure, $VB$It.isMounts, $VB$It.Proportional), [SpecialName] (VB$AnonymousType_2<PlatformComponent.ProtectionType, bool, bool, bool> $VB$It, IEnumerable<VB$AnonymousType_1<PlatformComponent, bool, bool>> $VB$ItAnonymous) => new VB$AnonymousType_3<PlatformComponent.ProtectionType, bool, bool, bool, IEnumerable<VB$AnonymousType_1<PlatformComponent, bool, bool>>, int>($VB$It.ProtectionType, $VB$It.InsideArmoredStructure, $VB$It.isMounts, $VB$It.Proportional, $VB$ItAnonymous, $VB$ItAnonymous.Count()));
		int num = 0;
		int count = Propulsion.Count;
		foreach (VB$AnonymousType_3<PlatformComponent.ProtectionType, bool, bool, bool, IEnumerable<VB$AnonymousType_1<PlatformComponent, bool, bool>>, int> item in enumerable)
		{
			if (!item.Proportional)
			{
				num += item.Count;
			}
		}
		float num2 = (float)num * EngineProportionalWeight;
		if (count > 0)
		{
			num2 /= (float)count;
		}
		foreach (VB$AnonymousType_3<PlatformComponent.ProtectionType, bool, bool, bool, IEnumerable<VB$AnonymousType_1<PlatformComponent, bool, bool>>, int> item2 in enumerable)
		{
			if (item2.ProtectionType == PlatformComponent.ProtectionType.Armored)
			{
				foreach (VB$AnonymousType_1<PlatformComponent, bool, bool> item3 in item2.theComponentsByProportionalAndArmor)
				{
					UnitComponentGroups.ComponentGroup componentGroup5 = unitComponentGroups.AddGroup(IsArmor: false, item3.component.GetArmor.InsideArmoredStructure);
					float componentVolume = GetComponentVolume(item3.component, num2, item3.Proportional);
					componentGroup5.AddComponent(item3.component, DirectlyImpacted: false, componentVolume, componentVolume);
					if (item3.component.GetArmor.InsideArmoredStructure)
					{
						componentGroup5.LocationTag = "Armored Inside Armor";
						list2.Add(componentGroup5);
					}
					else
					{
						componentGroup5.LocationTag = "Armored Outside Armor";
						list.Add(componentGroup5);
					}
				}
			}
			else if (item2.ProtectionType == PlatformComponent.ProtectionType.Unarmored)
			{
				foreach (VB$AnonymousType_1<PlatformComponent, bool, bool> item4 in item2.theComponentsByProportionalAndArmor)
				{
					float componentVolume2 = GetComponentVolume(item4.component, num2, item4.Proportional);
					if (item4.component.GetArmor.InsideArmoredStructure)
					{
						componentGroup.AddComponent(item4.component, DirectlyImpacted: false, componentVolume2, componentVolume2);
					}
					else
					{
						componentGroup2.AddComponent(item4.component, DirectlyImpacted: false, componentVolume2, componentVolume2);
					}
				}
			}
			else if (item2.ProtectionType == PlatformComponent.ProtectionType.ArmoredStructure)
			{
				foreach (VB$AnonymousType_1<PlatformComponent, bool, bool> item5 in item2.theComponentsByProportionalAndArmor)
				{
					float componentVolume3 = GetComponentVolume(item5.component, num2, item5.Proportional);
					if (item5.component.IsAirFacility)
					{
						componentGroup4.AddComponent(item5.component, DirectlyImpacted: false, componentVolume3 / 2f, componentVolume3 / 2f);
						componentGroup3.AddComponent(item5.component, DirectlyImpacted: false, componentVolume3 / 2f, componentVolume3 / 2f);
					}
					else
					{
						componentGroup4.AddComponent(item5.component, DirectlyImpacted: false, componentVolume3, componentVolume3);
					}
				}
			}
			if (!item2.isMounts)
			{
				continue;
			}
			foreach (VB$AnonymousType_1<PlatformComponent, bool, bool> item6 in item2.theComponentsByProportionalAndArmor)
			{
				if (!(item6.component.GetType() == typeof(Mount)))
				{
					continue;
				}
				Magazine mountMagazine = ((Mount)item6.component).MountMagazine;
				if (mountMagazine != null && mountMagazine.Capacity > 0)
				{
					float componentVolume4 = GetComponentVolume(item6.component, num2, item6.Proportional);
					if (mountMagazine.GetArmor.ArmorRating == GlobalVariables.ArmorRating.None)
					{
						componentGroup.AddComponent(mountMagazine, DirectlyImpacted: false, componentVolume4, componentVolume4);
						continue;
					}
					UnitComponentGroups.ComponentGroup componentGroup6 = unitComponentGroups.AddGroup(IsArmor: false, InsideArmor: true);
					componentGroup6.AddComponent(mountMagazine, DirectlyImpacted: false, componentVolume4, componentVolume4);
					componentGroup6.LocationTag = "Armored Inside Armor";
					list2.Add(componentGroup6);
				}
			}
		}
		bool flag = componentGroup.Components.Any();
		int num3 = list2.Count - 1;
		for (int num4 = 0; num4 <= num3; num4++)
		{
			UnitComponentGroups.ComponentGroup componentGroup7 = list2.ElementAt(num4);
			if (flag)
			{
				unitComponentGroups.LinkComponentGroups(componentGroup, componentGroup7);
			}
			int num5 = num4 + 1;
			int num6 = list2.Count - 1;
			for (int num7 = num5; num7 <= num6; num7++)
			{
				unitComponentGroups.LinkComponentGroups(componentGroup7, list2.ElementAt(num7));
			}
			unitComponentGroups.LinkComponentGroups(componentGroup7, componentGroup4);
		}
		if (flag)
		{
			unitComponentGroups.LinkComponentGroups(componentGroup, componentGroup4);
		}
		else
		{
			unitComponentGroups.Groups.Remove(componentGroup);
		}
		bool flag2 = componentGroup2.Components.Any();
		int num8 = list.Count - 1;
		for (int num9 = 0; num9 <= num8; num9++)
		{
			UnitComponentGroups.ComponentGroup componentGroup8 = list.ElementAt(num9);
			if (flag2)
			{
				unitComponentGroups.LinkComponentGroups(componentGroup2, componentGroup8);
			}
			int num10 = num9 + 1;
			int num11 = list.Count - 1;
			for (int num12 = num10; num12 <= num11; num12++)
			{
				unitComponentGroups.LinkComponentGroups(componentGroup8, list.ElementAt(num12));
			}
			unitComponentGroups.LinkComponentGroups(componentGroup8, componentGroup3);
		}
		unitComponentGroups.LinkComponentGroups(componentGroup3, componentGroup4);
		unitComponentGroups.LinkComponentGroups(componentGroup3, componentGroup2);
		return unitComponentGroups;
	}

	internal override void ObjectID_Set(string newValue, bool NeedToCheckForSpaces = true)
	{
		if (!string.IsNullOrEmpty(newValue))
		{
			newValue = newValue.Replace("_", "");
		}
		base.ObjectID_Set(newValue, NeedToCheckForSpaces);
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		foreach (Sensor sensor in _Sensors)
		{
			sensor.ResetIDs();
		}
		CommDevice[] comms = _Comms;
		checked
		{
			for (int i = 0; i < comms.Length; i++)
			{
				comms[i].ResetIDs();
			}
			foreach (Engine item in Propulsion)
			{
				item.ResetIDs();
			}
			foreach (FuelRec item2 in _Fuel)
			{
				item2.ResetIDs();
			}
			foreach (Mount mount in Mounts)
			{
				mount.ResetIDs();
			}
			Cargo[] onboardCargo = OnboardCargo;
			for (int j = 0; j < onboardCargo.Length; j++)
			{
				onboardCargo[j].ResetIDs();
			}
			AirFacility[] airFacilities = _AirFacilities;
			for (int k = 0; k < airFacilities.Length; k++)
			{
				airFacilities[k].ResetIDs();
			}
		}
	}

	public bool IsEligibleForEyeball()
	{
		if (IsPlatform)
		{
			if (((Platform)this).Crew > 0)
			{
				return true;
			}
			return false;
		}
		if (base.IsFixedFacility)
		{
			return false;
		}
		int result;
		switch (UnitType)
		{
		default:
			result = 0;
			goto IL_009f;
		case GlobalVariables.ActiveUnitType.Aircraft:
		{
			Aircraft._AircraftType type2 = ((Aircraft)this).Type;
			if ((uint)(type2 - 8201) > 1u)
			{
				return true;
			}
			return false;
		}
		case GlobalVariables.ActiveUnitType.Ship:
			return false;
		case GlobalVariables.ActiveUnitType.Submarine:
		{
			Submarine._SubmarineType type = ((Submarine)this).Type;
			if ((uint)(type - 4001) <= 1u)
			{
				return false;
			}
			return true;
		}
		case GlobalVariables.ActiveUnitType.Facility:
		case GlobalVariables.ActiveUnitType.Aimpoint:
		case GlobalVariables.ActiveUnitType.Weapon:
			result = 0;
			goto IL_009f;
		case GlobalVariables.ActiveUnitType.Satellite:
			{
				return false;
			}
			IL_009f:
			return (byte)result != 0;
		}
	}

	public float RangeToUnit_Horiz_Alt(Module_Unit.Unit TargetUnit, GlobalVariables.BooleanObject HintmyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
	{
		if (TargetUnit == null)
		{
			return float.MaxValue;
		}
		GlobalVariables.BooleanObject booleanObject = ((HintmyUnitOperating == null) ? Misc.ToBooleanObject(IsOperating()) : HintmyUnitOperating);
		GlobalVariables.BooleanObject booleanObject2 = default(GlobalVariables.BooleanObject);
		if (TargetUnit.IsActiveUnit && !TargetUnit.IsGroup)
		{
			booleanObject2 = ((HintTargetUnitOperating == null) ? Misc.ToBooleanObject(((ActiveUnit)TargetUnit).IsOperating()) : HintTargetUnitOperating);
		}
		if (booleanObject2 == null)
		{
			booleanObject2 = HintTargetUnitOperating;
		}
		double lat;
		double lon;
		if (booleanObject == GlobalVariables.ObjectTrue && !IsGroup)
		{
			lat = _Latitude;
			lon = _Longitude;
		}
		else
		{
			lat = this.get_Latitude(booleanObject);
			lon = this.get_Longitude(booleanObject);
		}
		double lat2;
		double lon2;
		if (TargetUnit.IsActiveUnit && !TargetUnit.IsGroup && booleanObject2 == GlobalVariables.ObjectTrue)
		{
			lat2 = ((ActiveUnit)TargetUnit)._Latitude;
			lon2 = ((ActiveUnit)TargetUnit)._Longitude;
		}
		else if ((TargetUnit.get_Latitude(booleanObject2) == 0.0) & (TargetUnit.get_Longitude(booleanObject2) == 0.0) & TargetUnit.IsContact())
		{
			lat2 = ((Contact)TargetUnit).ActualUnit.get_Latitude(booleanObject2);
			lon2 = ((Contact)TargetUnit).ActualUnit.get_Longitude(booleanObject2);
		}
		else
		{
			lat2 = TargetUnit.get_Latitude(booleanObject2);
			lon2 = TargetUnit.get_Longitude(booleanObject2);
		}
		return Math2.CalcDist(lat, lon, lat2, lon2);
	}

	public override float RangeToUnit_Horiz(Module_Unit.Unit TargetUnit, GlobalVariables.BooleanObject HintmyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
	{
		if (TargetUnit != null)
		{
			if (HintmyUnitOperating == null)
			{
				HintmyUnitOperating = Misc.ToBooleanObject(IsOperating());
			}
			if (TargetUnit.IsActiveUnit && !TargetUnit.IsGroup && HintTargetUnitOperating == null)
			{
				HintTargetUnitOperating = Misc.ToBooleanObject(((ActiveUnit)TargetUnit).IsOperating());
			}
			double lat;
			double lon;
			if (HintmyUnitOperating == GlobalVariables.ObjectTrue && !IsGroup)
			{
				lat = _Latitude;
				lon = _Longitude;
			}
			else
			{
				lat = this.get_Latitude(HintmyUnitOperating);
				lon = this.get_Longitude(HintmyUnitOperating);
			}
			double lat2;
			double lon2;
			if (TargetUnit.IsActiveUnit && !TargetUnit.IsGroup && HintTargetUnitOperating == GlobalVariables.ObjectTrue)
			{
				lat2 = ((ActiveUnit)TargetUnit)._Latitude;
				lon2 = ((ActiveUnit)TargetUnit)._Longitude;
			}
			else
			{
				lat2 = TargetUnit.get_Latitude(HintTargetUnitOperating);
				lon2 = TargetUnit.get_Longitude(HintTargetUnitOperating);
			}
			return Math2.CalcDist(lat, lon, lat2, lon2);
		}
		return float.MaxValue;
	}

	public float RangeToPoint_Slant(TrajectoryPoint thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null, float HorizRange = 0f)
	{
		if (!Module_Unit.IsOrbitalCheck(thePoint.Altitude, this.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating)))
		{
			double lat;
			double lon;
			if (HintMyUnitOperating == GlobalVariables.ObjectTrue && !IsGroup)
			{
				lat = _Latitude;
				lon = _Longitude;
			}
			else
			{
				lat = this.get_Latitude(HintMyUnitOperating);
				lon = this.get_Longitude(HintMyUnitOperating);
			}
			if (HorizRange == 0f)
			{
				HorizRange = Math2.CalcDist(lat, lon, thePoint.Latitude, thePoint.Longitude);
			}
			float num = (float)((double)Math.Abs(this.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating) - thePoint.Altitude) / 1852.0);
			return (float)Math.Sqrt(HorizRange * HorizRange + num * num);
		}
		return Module_Unit.RangeToPoint_Slant_OnSphericalEarth(this, thePoint.Latitude, thePoint.Longitude, thePoint.Altitude, HintMyUnitOperating);
	}

	public float RangeToPoint_Horiz(TrajectoryPoint thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		double lat;
		double lon;
		if (IsActiveUnit && !IsGroup && HintMyUnitOperating == GlobalVariables.ObjectTrue)
		{
			lat = _Latitude;
			lon = _Longitude;
		}
		else
		{
			lat = this.get_Latitude(HintMyUnitOperating);
			lon = this.get_Longitude(HintMyUnitOperating);
		}
		return Math2.CalcDist(lat, lon, thePoint.Latitude, thePoint.Longitude);
	}

	public override void PrePulseHousekeeping(float elapsedTime, Scenario theScen)
	{
		base.PrePulseHousekeeping(elapsedTime, theScen);
		if (Status == _ActiveUnitStatus.Manual_Unassigned)
		{
			Status = _ActiveUnitStatus.Unassigned;
		}
		if (this.get_UnitSide(SetSideOnly: false).NoNavZones.Count > 0)
		{
			ActiveUnit_Navigator navigator = Navigator;
			if (navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation > 0.0)
			{
				navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation -= elapsedTime;
			}
		}
		if (IsWeapon)
		{
			((Weapon)this).Navigator.ABMInterceptPoint = null;
		}
		if (IsAircraft)
		{
			Aircraft obj = (Aircraft)this;
			obj.set_MinimumSafeHeight(bool_7: false, (float?)null);
			obj.Kinematics.ActualAgility_ThisPulse = null;
			obj.Navigator.holdTimeChangedThisPulse = false;
			if (Navigator.get_Flight(HierarchySearch: true) != null)
			{
				if (Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.Count > 0)
				{
					Navigator.get_Flight(HierarchySearch: true).Cache_ContactRelevantToFlight.Clear();
				}
				Navigator.get_Flight(HierarchySearch: true).Cache_FP_Targets = null;
			}
		}
		IsMCMPlatform_ThisPulse = -1;
		IsMineLayingPlatform_ThisPulse = -1;
		LoiteredThisPulse = false;
		AI.PrePulseHousekeeping(elapsedTime, theScen);
		Weaponry.Cache_CurrentWeaponState = _ActiveUnitWeaponState.Undefined;
		if (IsWeapon)
		{
			((Weapon)this).IsUnderGNSSDenialThisPulse = false;
		}
	}

	public override void Housekeeping_PostPulse(float elapsedTime)
	{
		if (IsAircraft && IsGroupLead() && ((Aircraft)this).Navigator.hasReachedInitialPointInThisPulse)
		{
			((Aircraft)this).Navigator.hasReachedInitialPointInThisPulse = false;
			ActiveUnit[] array = this.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToArray();
			foreach (ActiveUnit activeUnit in array)
			{
				if (!((Aircraft)activeUnit).isSuicide())
				{
					continue;
				}
				activeUnit.DetachUnit(NotifyPlayer: false, ClearPlottedCourse: false, UseFlightplan: true);
				Waypoint[] plottedCourse = activeUnit.Navigator.PlottedCourse;
				bool flag = false;
				Waypoint[] array2 = plottedCourse;
				foreach (Waypoint waypoint in array2)
				{
					if (waypoint.Type == Waypoint.WaypointType.Target)
					{
						flag = true;
						activeUnit.Navigator.PlottedCourse = new Waypoint[1] { waypoint };
						break;
					}
				}
				if (!flag && Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}
		if (!CommStuff.IsConnectedToSideNetwork)
		{
			CommStuff.TimeOffComms += elapsedTime;
		}
		else
		{
			CommStuff.TimeOffComms = 0f;
		}
	}

	internal new virtual void Reinitialize()
	{
		base.RangeSymbols.Clear();
		Message = "";
		_DesiredAltitude_AGL = 0f;
		_Proficiency = null;
		_Sensors.Clear();
		ArrayExtensions.Clear(ref _Comms);
		ArrayExtensions.Clear(ref OnboardCargo);
		ArrayExtensions.Clear(ref _AirFacilities);
		ArrayExtensions.Clear(ref _DockFacilities);
		_AssignedMissionOrPackage = null;
		_AssignedTaskPool = null;
		bool_1 = false;
		Kinematics.Reinitialize();
	}

	public override string ToString()
	{
		return Name;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("ActiveUnit");
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				theWriter.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			theWriter.WriteElementString("Name", Name);
			theWriter.WriteElementString("CurrentHeading", XmlConvert.ToString(CurrentHeading));
			theWriter.WriteElementString("CurrentSpeed", XmlConvert.ToString(CurrentSpeed));
			theWriter.WriteElementString("CurrentAltitude", XmlConvert.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Longitude", XmlConvert.ToString(this.get_Longitude((GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("Latitude", XmlConvert.ToString(this.get_Latitude((GlobalVariables.BooleanObject)null)));
			theWriter.WriteElementString("UnitClass", UnitClass);
			theWriter.WriteElementString("Side", this.get_UnitSide(SetSideOnly: false).Name);
			if (!string.IsNullOrEmpty(Message))
			{
				theWriter.WriteElementString("Message", Message);
			}
			theWriter.WriteElementString("DBID", DBID.ToString());
			theWriter.WriteElementString("DesiredHeading", XmlConvert.ToString(this.DesiredHeading));
			theWriter.WriteElementString("DesiredSpeed", XmlConvert.ToString(DesiredSpeed));
			theWriter.WriteElementString("DesiredAltitude", XmlConvert.ToString(DesiredAltitude));
			if (DesiredAltitude_AGL != 0f)
			{
				theWriter.WriteElementString("DesiredAltitude_TerrainFollowing", XmlConvert.ToString(DesiredAltitude_AGL));
			}
			theWriter.WriteElementString("DesiredTurnRate", ((byte)DesiredTurnRate).ToString());
			theWriter.WriteElementString("DesiredTurnRate_Navigation", ((byte)DesiredTurnRate_Navigation).ToString());
			if (this.get_DesiredAltitude_UseTerrainFollowing(this))
			{
				theWriter.WriteElementString("TerrainFollowing", this.get_DesiredAltitude_UseTerrainFollowing(this).ToString());
			}
			theWriter.WriteElementString("Weight", XmlConvert.ToString(EmptyWeight));
			theWriter.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
			if (_Proficiency.HasValue)
			{
				theWriter.WriteElementString("Prof", ((int)_Proficiency.Value).ToString());
			}
			theWriter.WriteStartElement("Sensors");
			foreach (Sensor sensor in _Sensors)
			{
				theWriter.WriteRaw(sensor.ToXML(ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Comms");
			CommDevice[] comms = _Comms;
			foreach (CommDevice commDevice in comms)
			{
				theWriter.WriteRaw(commDevice.ToXML(ref ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Propulsion");
			foreach (Engine item in Propulsion)
			{
				theWriter.WriteRaw(item.ToXML(ObjectsAlreadySerialized));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("XSections");
			XSection[] xSections_ReadOnly = XSections_ReadOnly;
			for (int j = 0; j < xSections_ReadOnly.Length; j = checked(j + 1))
			{
				xSections_ReadOnly[j].ToXML(ref theWriter);
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Fuel");
			foreach (FuelRec item2 in _Fuel)
			{
				theWriter.WriteRaw(item2.ToXML());
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Mounts");
			foreach (Mount mount in Mounts)
			{
				theWriter.WriteRaw(mount.ToXML(ref ObjectsAlreadySerialized, ParentScen));
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("OnboardCargo");
			Cargo[] onboardCargo = OnboardCargo;
			foreach (Cargo cargo in onboardCargo)
			{
				theWriter.WriteRaw(cargo.ToXML(ObjectsAlreadySerialized, ParentScen));
			}
			theWriter.WriteEndElement();
			XmlWriter obj = theWriter;
			byte status = (byte)_Status;
			obj.WriteElementString("Status", status.ToString());
			XmlWriter obj2 = theWriter;
			status = (byte)_FuelState;
			obj2.WriteElementString("FuelState", status.ToString());
			theWriter.WriteElementString("WeaponState", ((byte)_WeaponState).ToString());
			if (_StatusBefore_NeedToRefuel != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj3 = theWriter;
				status = (byte)_StatusBefore_NeedToRefuel;
				obj3.WriteElementString("SBR", status.ToString());
			}
			if (_StatusBefore_EngagedDefensive != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj4 = theWriter;
				status = (byte)_StatusBefore_EngagedDefensive;
				obj4.WriteElementString("SBED", status.ToString());
			}
			if (_StatusBefore_EngagedOffensive != _ActiveUnitStatus.Unassigned)
			{
				XmlWriter obj5 = theWriter;
				status = (byte)_StatusBefore_EngagedOffensive;
				obj5.WriteElementString("SBEO", status.ToString());
			}
			if (_FuelStateBefore_NeedToRefuel != _ActiveUnitFuelState.None)
			{
				XmlWriter obj6 = theWriter;
				status = (byte)_FuelStateBefore_NeedToRefuel;
				obj6.WriteElementString("FSBR", status.ToString());
			}
			if (_AltitudeBefore_NeedToRefuel != 0f)
			{
				theWriter.WriteElementString("SBR_Altitude", XmlConvert.ToString(_AltitudeBefore_NeedToRefuel));
			}
			if (_AltitudeBefore_NeedToRefuel_AGL != 0f)
			{
				theWriter.WriteElementString("SBR_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_NeedToRefuel_AGL));
			}
			theWriter.WriteElementString("SBR_TF", XmlConvert.ToString(_TerrainFollowingBefore_NeedToRefuel));
			XmlWriter obj7 = theWriter;
			status = (byte)_ThrottleBefore_NeedToRefuel;
			obj7.WriteElementString("SBR_ThrottleSetting", status.ToString());
			theWriter.WriteElementString("SBED_Altitude", XmlConvert.ToString(_AltitudeBefore_EngagedDefensive));
			if (_AltitudeBefore_EngagedDefensive_AGL.HasValue)
			{
				theWriter.WriteElementString("SBED_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_EngagedDefensive_AGL.Value));
			}
			theWriter.WriteElementString("SBED_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedDefensive));
			XmlWriter obj8 = theWriter;
			status = (byte)_ThrottleBefore_EngagedDefensive;
			obj8.WriteElementString("SBED_ThrottleSetting", status.ToString());
			if (_DesiredSpeedOverrideBefore_EngagedDefensive.HasValue)
			{
				theWriter.WriteElementString("SBED_DesiredSpeedOverride", XmlConvert.ToString(_DesiredSpeedOverrideBefore_EngagedDefensive.Value));
			}
			theWriter.WriteElementString("SBEO_Altitude", XmlConvert.ToString(_AltitudeBefore_EngagedOffensive));
			theWriter.WriteElementString("SBEO_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_EngagedOffensive_AGL));
			theWriter.WriteElementString("SBEO_TF", XmlConvert.ToString(_TerrainFollowingBefore_EngagedOffensive));
			if (_ThrottleBefore_EngagedOffensive != Throttle.FullStop)
			{
				XmlWriter obj9 = theWriter;
				status = (byte)_ThrottleBefore_EngagedOffensive;
				obj9.WriteElementString("SBEO_ThrottleSetting", status.ToString());
			}
			theWriter.WriteElementString("SBPF_Altitude", XmlConvert.ToString(_AltitudeBefore_WaitForPathfinder));
			theWriter.WriteElementString("SBPF_Altitude_TF", XmlConvert.ToString(_AltitudeBefore_WaitForPathfinder_AGL));
			theWriter.WriteElementString("SBPF_TF", XmlConvert.ToString(_TerrainFollowingBefore_WaitForPathfinder));
			if (_ThrottleBefore_WaitForPathfinder != Throttle.FullStop)
			{
				XmlWriter obj10 = theWriter;
				status = (byte)_ThrottleBefore_WaitForPathfinder;
				obj10.WriteElementString("SBPF_ThrottleSetting", status.ToString());
			}
			theWriter.WriteElementString("AMP_OC", _MissionPlannerOverrideCancellation.ToString());
			if (_MissionPlannerOverrideCancellation_DesiredSpeedOverride.HasValue)
			{
				theWriter.WriteElementString("AMP_OC_DSO", _MissionPlannerOverrideCancellation_DesiredSpeedOverride.ToString());
			}
			theWriter.WriteElementString("AMP_OC_DAO", _MissionPlannerOverrideCancellation_DesiredAltitudeOverride.ToString());
			theWriter.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(_MissionPlannerOverrideCancellation_Speed));
			theWriter.WriteElementString("DamagePts", XmlConvert.ToString(float_7));
			theWriter.WriteElementString("OldDamagePercent", XmlConvert.ToString(_OldDamagePercent));
			if (EligibleForSAR)
			{
				theWriter.WriteElementString("EFSAR", XmlConvert.ToString(EligibleForSAR));
			}
			if (IsBeingPickedUp)
			{
				theWriter.WriteElementString("IBPU", XmlConvert.ToString(IsBeingPickedUp));
			}
			if (_AirFacilities.Length > 0)
			{
				theWriter.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities = _AirFacilities;
				foreach (AirFacility airFacility in airFacilities)
				{
					theWriter.WriteRaw(airFacility.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (_DockFacilities.Count() > 0)
			{
				theWriter.WriteStartElement("DockFacilities");
				DockFacility[] dockFacilities = _DockFacilities;
				foreach (DockFacility dockFacility in dockFacilities)
				{
					theWriter.WriteRaw(dockFacility.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (ActiveMissionOrPackage() != null)
			{
				theWriter.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
			}
			if (AssignedTaskPool != null)
			{
				theWriter.WriteElementString("AssignedTaskPool", _AssignedTaskPool.ObjectID);
			}
			if (PrivateSnapshotMission != null)
			{
				theWriter.WriteStartElement("PrivateSnapshotMission");
				PrivateSnapshotMission.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref ParentScen);
				theWriter.WriteEndElement();
			}
			if (this.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				theWriter.WriteElementString("ParentGroup", _ParentGroup.ObjectID);
			}
			if (this.get_IsAutoDetectable((Side)null))
			{
				theWriter.WriteElementString("IsAD", this.get_IsAutoDetectable((Side)null).ToString());
			}
			Doctrine.ToXML(ref theWriter, ref ParentScen);
			activeUnit_Navigator_0.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteStartElement("ActiveUnit_AI");
			_AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("ActiveUnit_Kinematics");
			activeUnit_Kinematics_0.ToXML(ref theWriter);
			theWriter.WriteEndElement();
			_Sensory.ToXML(ref theWriter);
			activeUnit_Weaponry_0.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteStartElement("ActiveUnit_CommStuff");
			_CommStuff.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			_Damage.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			_AirOps.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			if (HasCustomOODA)
			{
				theWriter.WriteElementString("OODA_D", OODA_Detection.ToString());
				theWriter.WriteElementString("OODA_T", OODA_Targeting.ToString());
				theWriter.WriteElementString("OODA_E", OODA_Evasion.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100000", "Name: " + Name + " DBID: " + Conversions.ToString(DBID) + " ObjectID: " + ObjectID);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CommonFromXML(XmlNode TheNode)
	{
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Invalid comparison between Unknown and I4
		switch (TheNode.Name)
		{
		case "AltOld":
			base.Altitude_old = XmlConvert.ToSingle(TheNode.InnerText);
			break;
		case "SettledTime":
			SettledTime = XmlConvert.ToSingle(TheNode.InnerText);
			break;
		case "Decoy":
			IsDecoy = Conversions.ToBoolean(TheNode.InnerText);
			break;
		case "TemporaryBlindness":
			TemporaryBlindness = XmlConvert.ToSingle(TheNode.InnerText);
			break;
		case "DesignatedSupplier":
			if (!Versioned.IsNumeric((object)TheNode.InnerText))
			{
				_DesignatedSupplier = (ActiveUnit_DockingOps.ResupplyCapacity)Enum.Parse(typeof(ActiveUnit_DockingOps.ResupplyCapacity), TheNode.InnerText, ignoreCase: true);
			}
			else
			{
				_DesignatedSupplier = (ActiveUnit_DockingOps.ResupplyCapacity)Conversions.ToInteger(TheNode.InnerText);
			}
			break;
		case "TaggedAsDecoy":
		{
			foreach (XmlNode childNode in TheNode.ChildNodes)
			{
				XmlNode val3 = childNode;
				pooledList_0.Add(val3.InnerText);
			}
			break;
		}
		case "AllowMultiMission":
			AllowMultiMission = Conversions.ToBoolean(TheNode.InnerText);
			break;
		case "Kills":
		{
			foreach (XmlNode childNode2 in TheNode.ChildNodes)
			{
				XmlNode val2 = childNode2;
				if ((int)val2.NodeType != 1 || Operators.CompareString(val2.Name, "e", false) != 0)
				{
					continue;
				}
				string value = val2.Attributes["n"].Value;
				string[] array = val2.Attributes["d"].Value.Split(new char[1] { ',' });
				List<DateTime> list = new List<DateTime>();
				string[] array2 = array;
				foreach (string text in array2)
				{
					list.Add(XmlConvert.ToDateTime(text, (XmlDateTimeSerializationMode)0));
				}
				foreach (DateTime item in list)
				{
					Kills.Add((value, item));
				}
			}
			break;
		}
		case "AssignedMissionsQueue":
		{
			foreach (XmlNode childNode3 in TheNode.ChildNodes)
			{
				XmlNode val = childNode3;
				_AssignedMissionsQueue_ID.Add(val.InnerText);
			}
			break;
		}
		}
	}

	public void method_2(ref XmlWriter theWriter)
	{
		if (!string.IsNullOrEmpty(CustomIcon))
		{
			theWriter.WriteElementString("CustomIcon", CustomIcon);
		}
		if (AssignedMissionsQueue.Count > 0)
		{
			theWriter.WriteStartElement("AssignedMissionsQueue");
			foreach (Mission key in AssignedMissionsQueue.Keys)
			{
				theWriter.WriteElementString("Mission", key.ObjectID);
			}
			theWriter.WriteEndElement();
		}
		theWriter.WriteElementString("AllowMultiMission", AllowMultiMission.ToString());
		if (_DesignatedSupplier.HasValue)
		{
			theWriter.WriteElementString("DesignatedSupplier", ((byte)_DesignatedSupplier.Value).ToString());
		}
		if (SettledTime != 0f)
		{
			theWriter.WriteElementString("SettledTime", XmlConvert.ToString(SettledTime));
		}
		theWriter.WriteElementString("AltOld", XmlConvert.ToString(base.Altitude_old));
		if (TemporaryBlindness != 0f)
		{
			theWriter.WriteElementString("TemporaryBlindness", XmlConvert.ToString(TemporaryBlindness));
		}
		if (Kills.Count > 0)
		{
			theWriter.WriteStartElement("Kills");
			foreach (var kill in Kills)
			{
				theWriter.WriteStartElement("e");
				theWriter.WriteAttributeString("n", kill.Item1);
				theWriter.WriteAttributeString("d", XmlConvert.ToString(kill.Item2, (XmlDateTimeSerializationMode)0));
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		theWriter.WriteElementString("Decoy", IsDecoy.ToString());
		if (pooledList_0.Count <= 0)
		{
			return;
		}
		theWriter.WriteStartElement("TaggedAsDecoy");
		foreach (string item in pooledList_0)
		{
			theWriter.WriteElementString("Side", item);
		}
		theWriter.WriteEndElement();
	}

	public void PrepareForDeserializationToExistingUnit()
	{
		_ParentGroup_ID = "";
		_AssignedMissionOrPackage_ID = "";
		_AssignedTaskPool_ID = "";
	}

	public void CleanupFromDeserializationToExistingUnit()
	{
		if (string.IsNullOrEmpty(_ParentGroup_ID))
		{
			_ParentGroup = null;
		}
		_AssignedTaskPool = null;
		if (!string.IsNullOrEmpty(_AssignedTaskPool_ID))
		{
			_ = AssignedTaskPool;
		}
		_AssignedMissionOrPackage = null;
		if (!string.IsNullOrEmpty(_AssignedMissionOrPackage_ID))
		{
			ActiveMissionOrPackage();
		}
	}

	public static ActiveUnit FromXML(string theObjectID, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		ActiveUnit result;
		try
		{
			result = (theDictionary.ContainsKey(theObjectID) ? ((ActiveUnit)theDictionary[theObjectID]) : null);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100001.2.", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static ActiveUnit FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, ActiveUnit existingObject = null)
	{
		ActiveUnit result;
		try
		{
			result = theNode.Name switch
			{
				"Facility" => Facility.FromXML(ref theNode, ref theDictionary, ref theScen, (Facility)existingObject), 
				"Submarine" => Submarine.FromXML(ref theNode, ref theDictionary, ref theScen, (Submarine)existingObject), 
				"Ship" => Ship.FromXML(ref theNode, ref theDictionary, ref theScen, (Ship)existingObject), 
				"Group" => Group.FromXML(ref theNode, ref theDictionary, ref theScen, (Group)existingObject), 
				"Weapon" => Weapon.FromXML(ref theNode, ref theDictionary, ref theScen), 
				"Vehicle" => Vehicle.FromXML(ref theNode, ref theDictionary, ref theScen, (Vehicle)existingObject), 
				"Aircraft" => Aircraft.FromXML(ref theNode, ref theDictionary, ref theScen, (Aircraft)existingObject), 
				"AggregateGroundUnit" => AggregateGroundUnit.FromXML(ref theNode, ref theDictionary, ref theScen), 
				"Satellite" => Satellite.FromXML(ref theNode, ref theDictionary, ref theScen, (Satellite)existingObject), 
				_ => null, 
			};
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100001", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal void method_3(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "AirFacilities":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode val2 = childNode2;
						OldIDs_AirFacilities.Add(val2.ChildNodes[0].InnerXml);
					}
					break;
				case "Comms":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						_ = childNode3;
					}
					break;
				case "DockFacilities":
					foreach (XmlNode childNode4 in val.ChildNodes)
					{
						_ = childNode4;
					}
					break;
				case "Magazines":
					foreach (XmlNode childNode5 in val.ChildNodes)
					{
						_ = childNode5;
					}
					break;
				case "Mounts":
					foreach (XmlNode childNode6 in val.ChildNodes)
					{
						XmlNode item = childNode6;
						OldIds_Mounts.Add(item);
					}
					break;
				case "Sensors":
					foreach (XmlNode childNode7 in val.ChildNodes)
					{
						_ = childNode7;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100002", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void RestoreOldComponentIDs()
	{
		if (OldIds_Mounts == null || OldIds_Mounts.Count <= 0)
		{
			return;
		}
		foreach (Mount mount in Mounts)
		{
			foreach (XmlNode oldIds_Mount in OldIds_Mounts)
			{
				if (oldIds_Mount != null && Conversions.ToInteger(oldIds_Mount.SelectSingleNode("DBID").InnerText) == mount.DBID)
				{
					string innerText = oldIds_Mount.SelectSingleNode("ID").InnerText;
					if (innerText != null)
					{
						mount.ObjectID = innerText.ToString();
						OldIds_Mounts.Remove(oldIds_Mount);
						break;
					}
				}
			}
		}
	}

	public void PostDeserializationHousekeeping_Groupmembership(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		try
		{
			if (!string.IsNullOrEmpty(_ParentGroup_ID))
			{
				try
				{
					if (_ParentGroup == null || Operators.CompareString(_ParentGroup.ObjectID, _ParentGroup_ID, false) != 0)
					{
						ActiveUnit value = null;
						if (theScen.ActiveUnits.TryGetValue(_ParentGroup_ID, out value))
						{
							this.set_ParentGroup(UsingMissionPlanner: true, (Group)value);
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200004", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			else if (this.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				this.set_ParentGroup(UsingMissionPlanner: true, (Group)null);
			}
			if (this.get_ParentGroup(UsingMissionPlanner: false) == null)
			{
				Navigator.UnitFormationStation = null;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100003", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void PostDeserializationHousekeeping_General(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, List<ActiveUnit> DiscardList, bool GameIsRunning)
	{
		try
		{
			if (!string.IsNullOrEmpty(_SideName))
			{
				this.set_UnitSide(SetSideOnly: false, Side.FromXML_ByName(_SideName, ref theDictionary, theScen));
				AirOps.PostDeserializationHousekeeping(ref theScen, theDictionary, GameIsRunning);
				Navigator.PostDeserializationHousekeeping(ref theScen, theDictionary, GameIsRunning);
				foreach (string item in _AssignedMissionsQueue_ID)
				{
					if (theDictionary.ContainsKey(item))
					{
						Mission mission = (Mission)theDictionary[item];
						AssignedMissionsQueue.Add(mission, mission);
						if (!mission.UnitsQueuedToMission.ContainsKey(this))
						{
							mission.UnitsQueuedToMission.Add(this, this);
						}
					}
				}
				if (OnboardCargo != null)
				{
					Cargo[] onboardCargo = OnboardCargo;
					for (int i = 0; i < onboardCargo.Length; i = checked(i + 1))
					{
						onboardCargo[i].PostDeserializationHousekeeping_General(ref theScen, theDictionary, GameIsRunning);
					}
				}
			}
			else
			{
				DiscardList.Add(this);
				if (DBID != 0 && Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100004", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual bool IsParkedAndReady()
	{
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
		{
			return DockingOps.ConditionTimer == 0f;
		}
		return false;
	}

	public virtual bool IsParkedAndReadying()
	{
		if (DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.Docked)
		{
			return DockingOps.ConditionTimer > 0f;
		}
		return false;
	}

	public virtual int IsAvailableForOps(ref string ReasonForNot)
	{
		return 0;
	}

	public ActiveUnit(Scenario theScen)
	{
		ActiveUnit theUnit = this;
		DockingOps = new ActiveUnit_DockingOps(ref theUnit);
		IsDLZconstruct = false;
		IsDecoy = false;
		pooledList_0 = new PooledList<string>();
		LoiteredThisPulse = false;
		ActualSpeedReducedByTerrain = false;
		Kills = new PooledList<(string, DateTime)>();
		EngineProportionalWeight = 0.25f;
		TimeOnLastPulse = 1L;
		nullable_14 = null;
		SettledTime = 0f;
		_DesignatedSupplier = null;
		aggregateGroundUnit_0 = null;
		TerrainFollowingType = TerrainFollowMode.IgnoreLandCover;
		LandCoverMaskingCapability = false;
		_Sensors = new ObservableList<Sensor>();
		_Comms = Array.Empty<CommDevice>();
		Propulsion = new ObservableList<Engine>();
		_Fuel = new PooledList<FuelRec>(Pools<FuelRec>.Local);
		Mounts = new ObservableList<Mount>();
		Mounts_AsArray = Mounts.ToArray();
		OnboardCargo = Array.Empty<Cargo>();
		_AirFacilities = Array.Empty<AirFacility>();
		_DockFacilities = Array.Empty<DockFacility>();
		AssignedMissionsQueue = new Dictionary<Mission, Mission>();
		_AssignedMissionsQueue_ID = new List<string>();
		IsMorituri = false;
		HasCustomOODA = false;
		TimeSinceLastThreatDetection_ESM = 1801f;
		IsBeingDestroyed = false;
		IncomingGuidedWeaponsList = Array.Empty<Weapon>();
		IsBeingPickedUp = false;
		EligibleForSAR = false;
		PickUpUnit = null;
		ChanceOfAppearance = 0;
		IsDumbAU = false;
		TimeUnderway = 0f;
		UNREP_Capabilities = default(_UNREP_Capabilities);
		bool_2 = false;
		OldIDs_AirFacilities = new List<string>();
		OldIds_Mounts = new List<XmlNode>();
		CargoTransferList = null;
		_DestroyEventsChecked = false;
		Journey = new StoredCourse();
		IsStoringJourney = false;
		int_3 = -1;
		_MineCountermeasures_Lock = new LockObject();
		lockObject_0 = new LockObject();
		_IsPerformingStandoffAttack = false;
		List<ActiveUnit> DoctrineSelectedUnits = null;
		Doctrine = new Doctrine(theScen, this, ref DoctrineSelectedUnits);
		IsActiveUnit = true;
		TemporaryEmissionEM = new Str_TemporaryEmission[str_TemporaryEmission_0.Length - 1 + 1];
		Array.Copy(str_TemporaryEmission_0, TemporaryEmissionEM, str_TemporaryEmission_0.Length);
	}

	public ActiveUnit(Scenario theScen, string theGUID)
	{
		ActiveUnit theUnit = this;
		DockingOps = new ActiveUnit_DockingOps(ref theUnit);
		IsDLZconstruct = false;
		IsDecoy = false;
		pooledList_0 = new PooledList<string>();
		LoiteredThisPulse = false;
		ActualSpeedReducedByTerrain = false;
		Kills = new PooledList<(string, DateTime)>();
		EngineProportionalWeight = 0.25f;
		TimeOnLastPulse = 1L;
		nullable_14 = null;
		SettledTime = 0f;
		_DesignatedSupplier = null;
		aggregateGroundUnit_0 = null;
		TerrainFollowingType = TerrainFollowMode.IgnoreLandCover;
		LandCoverMaskingCapability = false;
		_Sensors = new ObservableList<Sensor>();
		_Comms = Array.Empty<CommDevice>();
		Propulsion = new ObservableList<Engine>();
		_Fuel = new PooledList<FuelRec>(Pools<FuelRec>.Local);
		Mounts = new ObservableList<Mount>();
		Mounts_AsArray = Mounts.ToArray();
		OnboardCargo = Array.Empty<Cargo>();
		_AirFacilities = Array.Empty<AirFacility>();
		_DockFacilities = Array.Empty<DockFacility>();
		AssignedMissionsQueue = new Dictionary<Mission, Mission>();
		_AssignedMissionsQueue_ID = new List<string>();
		IsMorituri = false;
		HasCustomOODA = false;
		TimeSinceLastThreatDetection_ESM = 1801f;
		IsBeingDestroyed = false;
		IncomingGuidedWeaponsList = Array.Empty<Weapon>();
		IsBeingPickedUp = false;
		EligibleForSAR = false;
		PickUpUnit = null;
		ChanceOfAppearance = 0;
		IsDumbAU = false;
		TimeUnderway = 0f;
		UNREP_Capabilities = default(_UNREP_Capabilities);
		bool_2 = false;
		OldIDs_AirFacilities = new List<string>();
		OldIds_Mounts = new List<XmlNode>();
		CargoTransferList = null;
		_DestroyEventsChecked = false;
		Journey = new StoredCourse();
		IsStoringJourney = false;
		int_3 = -1;
		_MineCountermeasures_Lock = new LockObject();
		lockObject_0 = new LockObject();
		_IsPerformingStandoffAttack = false;
		try
		{
			List<ActiveUnit> DoctrineSelectedUnits = null;
			Doctrine = new Doctrine(theScen, this, ref DoctrineSelectedUnits);
			IsActiveUnit = true;
			ParentScen = theScen;
			if (!string.IsNullOrEmpty(theGUID))
			{
				ObjectID_Set(theGUID);
			}
			TemporaryEmissionEM = new Str_TemporaryEmission[str_TemporaryEmission_0.Length - 1 + 1];
			Array.Copy(str_TemporaryEmission_0, TemporaryEmissionEM, str_TemporaryEmission_0.Length);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100005", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void DoTypeSpecificActions(float elapsedTime, ref LockRandom theRNG)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public virtual bool IsOperating()
	{
		int result;
		switch (DockingOps.Condition)
		{
		default:
			result = 0;
			goto IL_0056;
		case ActiveUnit_DockingOps._DockingOpsCondition.Docked:
		case ActiveUnit_DockingOps._DockingOpsCondition.DeployingUnderway:
		case ActiveUnit_DockingOps._DockingOpsCondition.Docking:
		case ActiveUnit_DockingOps._DockingOpsCondition.Readying:
		case ActiveUnit_DockingOps._DockingOpsCondition.LoadedAsCargo:
			result = 0;
			goto IL_0056;
		case ActiveUnit_DockingOps._DockingOpsCondition.Underway:
		case ActiveUnit_DockingOps._DockingOpsCondition.RTB:
		case ActiveUnit_DockingOps._DockingOpsCondition.ManoeuveringToRefuel:
		case ActiveUnit_DockingOps._DockingOpsCondition.Replenishing:
		case ActiveUnit_DockingOps._DockingOpsCondition.ProvidingUNREP:
		case ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries:
		case ActiveUnit_DockingOps._DockingOpsCondition.SettlingForCargoTransfer:
		case ActiveUnit_DockingOps._DockingOpsCondition.TransferringCargo:
		case ActiveUnit_DockingOps._DockingOpsCondition.TransferringMissionCargo:
		case ActiveUnit_DockingOps._DockingOpsCondition.HoldingPattern_CommsLost:
		case ActiveUnit_DockingOps._DockingOpsCondition.DeployingDippingSonar:
			{
				return true;
			}
			IL_0056:
			return (byte)result != 0;
		}
	}

	public virtual bool IsHostedInExposedSpace()
	{
		if (IsOperating())
		{
			return false;
		}
		if (DockingOps.HostDockFacility == null)
		{
			return false;
		}
		if (DockingOps.HostDockFacility.IsOpenDockFacility)
		{
			return true;
		}
		return false;
	}

	public void AddCommDevice(CommDevice theCommDevice)
	{
		ArrayExtensions.Add(ref _Comms, theCommDevice);
		if (IsWeapon)
		{
			((Weapon)this).DetermineGuidance();
		}
	}

	public void AddSensor(Sensor theSensor)
	{
		_Sensors.Add(theSensor);
		Sensors_Cached = null;
		MineCountermeasures = null;
	}

	public void AddAirFacility(AirFacility theAirFac)
	{
		ArrayExtensions.Add(ref _AirFacilities, theAirFac);
	}

	public void RemoveAirFacility(AirFacility theAirFac)
	{
		ArrayExtensions.Remove(ref _AirFacilities, theAirFac);
	}

	public void AddDockFacility(DockFacility theDockFac)
	{
		ArrayExtensions.Add(ref _DockFacilities, theDockFac);
	}

	public void RemoveDockFacility(DockFacility theDockFac)
	{
		ArrayExtensions.Remove(ref _DockFacilities, theDockFac);
	}

	public void AddFuelRec(FuelRec theFuelRec)
	{
		_Fuel.Add(theFuelRec);
	}

	public void RemoveFuelRec(FuelRec theFuelRec)
	{
		_Fuel.Remove(theFuelRec);
	}

	public virtual void DoWithdrawalCleanUp(ActiveUnit_AI theAI)
	{
		theAI.ClearAllThreats();
		theAI.PrimaryThreat = null;
	}

	public void NeutralizeMine(UnguidedWeapon theMine, Sensor ExplosiveChargeUsed)
	{
		try
		{
			ActiveUnit parentPlatform = ExplosiveChargeUsed.ParentPlatform;
			if ((IsAircraft || IsShip) && Operators.CompareString(Name, UnitClass, false) != 0)
			{
				_ = " (" + UnitClass + ")";
			}
			List<EventTrigger> list = new List<EventTrigger>();
			if (ExplosiveChargeUsed.ParentPlatform.get_UnitSide(SetSideOnly: false).Contacts_NonAU.Contains(theMine.ObjectID))
			{
				theMine.DestroyMe(ref ParentScen, "Mine neutralized");
			}
			else
			{
				foreach (EventTrigger value in parentPlatform.ParentScen.EventTriggers.Values)
				{
					if (value.Type == EventTrigger.EventTriggerType.UnitDetected && ((EventTrigger_UnitDetected)value).get_IsFulfilled(theMine, parentPlatform, ContactWasDetectedOnThisPulse: true, Contact_Base.IdentificationStatus.KnownClass, (Contact_Base.IdentificationStatus?)Contact_Base.IdentificationStatus.Unknown, (List<Sensor>)null))
					{
						list.Add(value);
					}
				}
				theMine.DestroyMe(ref ParentScen, "Mine neutralized");
			}
			((Module_Unit.Unit)theMine).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, -2f);
			foreach (EventTrigger value2 in ParentScen.EventTriggers.Values)
			{
				if (value2.Type == EventTrigger.EventTriggerType.UnitDestroyed && ((EventTrigger_UnitDestroyed)value2).get_IsFulfilled(theMine, ExplosiveChargeUsed.ParentPlatform))
				{
					list.Add(value2);
				}
			}
			if (list != null && list.Count > 0)
			{
				parentPlatform.ParentScen.FireEvents(list);
			}
			if (theMine.IsMine)
			{
				theMine.get_UnitSide(SetSideOnly: false).AAR.AddToLosses(theMine, TreatAsAimpoint: false);
			}
			base.EndgameReport.AddEndGameMessage(hit: true, "Has neutralized mine: " + theMine.Name + " with " + ExplosiveChargeUsed.Name);
			if (ExplosiveChargeUsed.ParentPlatform.IsShip && ExplosiveChargeUsed.Type == Sensor.Sensor_Type.MineNeutralization_DiverExplosiveCharge)
			{
				int timeToNextScan = GameGeneral.GlobalRNG.Next(600, 10000);
				ExplosiveChargeUsed.TimeToNextScan = timeToNextScan;
			}
			else if (ExplosiveChargeUsed.IsExplosiveMineNeutralizer)
			{
				ExplosiveChargeUsed.Destroy(this.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100007", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PreDestructionHousekeeping(bool ScenEditAction, bool TriggeredBySinking, float DamagePercent, bool DestroyUnitNow, bool RegisterAsLosses = true)
	{
		checked
		{
			try
			{
				if (!ScenEditAction && !_DestroyEventsChecked)
				{
					if (!IsShip || (IsShip && TriggeredBySinking) || !IsShip || !((Ship)this).IsSinking)
					{
						ParentScen?.CheckForDestroyEvents(this, DamagePercent);
					}
					_DestroyEventsChecked = true;
				}
				if (Navigator.HasFlight)
				{
					Navigator.RemoveFromFlightAndCleanUpMission();
				}
				if (AirFacilities_ReadOnly.Length > 0)
				{
					foreach (Aircraft item in AirOps.EmbarkedAircraft_ReadOnly)
					{
						item.Destroy(ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this), DestroyUnitNow, "Destroyed as the object it is landed on is being destroyed", "Host Destruction", RegisterAsLosses);
					}
				}
				if (DockFacilities_ReadOnly.Length > 0)
				{
					foreach (ActiveUnit item2 in DockingOps.EmbarkedBoats_ReadOnly)
					{
						item2.Destroy(ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this), DestroyUnitNow, "Destroyed as the object it is docked to is being destroyed", "Host Destruction", RegisterAsLosses);
					}
				}
				Cargo[] onboardCargo = OnboardCargo;
				foreach (Cargo cargo in onboardCargo)
				{
					if (cargo.CargoObjectStatus != PlatformComponent._ComponentStatus.Destroyed)
					{
						cargo.Destroy(this.get_UnitSide(SetSideOnly: false), ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this));
						if (RegisterAsLosses)
						{
							this.get_UnitSide(SetSideOnly: false).AAR.AddToLosses(cargo, TreatAsAimpoint: false);
						}
					}
				}
				foreach (PlatformComponent item3 in Components())
				{
					if (item3.Status != PlatformComponent._ComponentStatus.Destroyed)
					{
						item3.Destroy(this.get_UnitSide(SetSideOnly: false), ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this), RegisterAsLosses);
					}
				}
				if (ParentScen?.Sides_ReadOnly != null)
				{
					List<Side> list = new List<Side>(ParentScen?.Sides_ReadOnly);
					List<Mission> list2 = new List<Mission>();
					foreach (Side item4 in list)
					{
						list2.AddRange(item4?.Missions);
					}
					if (ParentScen.Sides_ReadOnly != null)
					{
						Mission[] array = ParentScen.Sides_ReadOnly.SelectMany([SpecialName] (Side s) => s.Missions).ToArray();
						foreach (Mission mission in array)
						{
							if (!(mission is Strike))
							{
								continue;
							}
							Strike strike = (Strike)mission;
							Contact[] array2 = strike.SpecificTargets.OfType<Contact>().ToArray();
							foreach (Contact contact in array2)
							{
								if (contact.ActualUnit == null)
								{
									strike.RemoveFromSpecificTargets(contact);
								}
								else if (contact.ActualUnit == this)
								{
									strike.RemoveFromSpecificTargets(contact);
								}
							}
							ActiveUnit[] array3 = strike.SpecificTargets.OfType<ActiveUnit>().ToArray();
							foreach (ActiveUnit activeUnit in array3)
							{
								if (activeUnit == this)
								{
									strike.RemoveFromSpecificTargets(activeUnit);
								}
							}
						}
					}
				}
				Cargo[] onboardCargo2 = OnboardCargo;
				foreach (Cargo cargo2 in onboardCargo2)
				{
					if (cargo2.Status != PlatformComponent._ComponentStatus.Destroyed)
					{
						cargo2.Destroy(this.get_UnitSide(SetSideOnly: false), ScenEditAction, cargo2.CurrentType == Cargo.CargoObjectType.Mount, RegisterAsLosses);
					}
				}
				List<WeaponRec> list3 = Weaponry.AllDistinctWeaponsAboard_Actual_WeaponRecs(IncludeAviationMags: true);
				foreach (WeaponRec item5 in list3)
				{
					if (item5.CurrentLoad > 0)
					{
						this.get_UnitSide(SetSideOnly: false)?.AAR.AddToWeaponsLost(item5.int_3, item5.CurrentLoad);
					}
				}
				_Sensors.Clear();
				Mounts.Clear();
				ArrayExtensions.Clear(ref _AirFacilities);
				ArrayExtensions.Clear(ref _DockFacilities);
				ArrayExtensions.Clear(ref OnboardCargo);
				if (SharedMagazines != null)
				{
					Magazine[] theArray = SharedMagazines;
					ArrayExtensions.Clear(ref theArray);
				}
				if (this.get_UnitSide(SetSideOnly: false) != null)
				{
					List<ActiveUnit> list4 = new List<ActiveUnit>();
					list4.AddRange(this.get_UnitSide(SetSideOnly: false).Units);
					List<CommLink> list5 = new List<CommLink>();
					foreach (ActiveUnit item6 in list4)
					{
						if (item6 == null)
						{
							continue;
						}
						list5.AddRange(item6.CommStuff.CommLinksEstablished_ReadOnly);
						foreach (CommLink item7 in list5)
						{
							if (item7?.CommPartner != this)
							{
								continue;
							}
							item6.CommStuff.DropCommLink(item7);
							if (item6.IsWeapon)
							{
								Weapon weapon = (Weapon)item6;
								if (weapon.DataLinkParent != null)
								{
									weapon.DataLinkParent = null;
									LockRandom theRNG = GameGeneral.GlobalRNG;
									weapon.DoTypeSpecificActions(0f, ref theRNG);
								}
							}
						}
						list5.Clear();
					}
				}
				List<ActiveUnit> list6 = new List<ActiveUnit>();
				if (ParentScen?.ActiveUnits_List != null)
				{
					try
					{
						list6.AddRange(ParentScen?.ActiveUnits_List);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						list6.AddRange(ParentScen?.ActiveUnits_List);
						ProjectData.ClearProjectError();
					}
				}
				foreach (ActiveUnit item8 in list6.Where([SpecialName] (ActiveUnit AU) => AU?.IsPlatform ?? false))
				{
					if (!item8.IsOperating())
					{
						continue;
					}
					if (!item8.IsAircraft)
					{
						if ((item8.IsShip || item8.IsSubmarine) && item8.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false) == this)
						{
							item8.DockingOps.PickNewAssignedHost_Nearest();
						}
					}
					else if (((Aircraft)item8).AirOps.get_AssignedHostUnit(PickNewAssignedHost: false) == this)
					{
						((Aircraft)item8).AirOps.PickNewAssignedHost_Nearest();
					}
				}
				if (this.get_UnitSide(SetSideOnly: false) != null)
				{
					if (IsWeapon)
					{
						this.get_UnitSide(SetSideOnly: false).RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
					}
					else
					{
						this.get_UnitSide(SetSideOnly: false).RemoveUnitFromSalvos(ref ParentScen, ObjectID);
					}
				}
				else if (!IsWeapon)
				{
					if (ParentScen != null)
					{
						Side[] array4 = ParentScen?.Sides_ReadOnly;
						for (int num5 = 0; num5 < array4.Length; num5++)
						{
							array4[num5].RemoveUnitFromSalvos(ref ParentScen, ObjectID);
						}
					}
				}
				else if (ParentScen != null)
				{
					Side[] array5 = ParentScen?.Sides_ReadOnly;
					for (int num6 = 0; num6 < array5.Length; num6++)
					{
						array5[num6].RemoveWeaponFromSalvos(ref ParentScen, ref ObjectID);
					}
				}
				if (IsGroupMember())
				{
					this.get_ParentGroup(UsingMissionPlanner: false).Units.Remove(ObjectID);
				}
				if (ScenEditAction || this.get_UnitSide(SetSideOnly: false) == null)
				{
					return;
				}
				if (!IsShip && !IsWeapon && !IsGroup)
				{
					string text = "";
					if (IsAircraft && Operators.CompareString(Name, UnitClass, false) != 0)
					{
						text = " (" + UnitClass + ")";
					}
					ParentScen?.AddMessage(Name + text + " has been destroyed!", Name + " destroyed!", LoggedMessage.MessageType.UnitLost, 0, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				if (!IsWeapon && !IsGroup && !Module_ActiveUnit.IsAimpointFacility(this) && RegisterAsLosses)
				{
					this.get_UnitSide(SetSideOnly: false).AAR.AddToLosses(this, TreatAsAimpoint: false);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100008", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private int method_4()
	{
		int result;
		try
		{
			if (!ParentScen.MaxRisingMineRange_meters.HasValue)
			{
				DataTable allWeapons = DBFunctions.GetAllWeapons(ParentScen.DBConnection);
				float num = default(float);
				foreach (DataRow row in allWeapons.Rows)
				{
					if (Conversions.ToInteger(row["Type"]) != 4008)
					{
						continue;
					}
					Weapon weapon = ParentScen.Cache_GetWeapon(Conversions.ToInteger(row["ID"])).Warheads[0].get_CarriedWeapon(ParentScen);
					if (weapon != null)
					{
						if (weapon.MaxSurfaceRange > num)
						{
							num = weapon.MaxSurfaceRange;
						}
						if (weapon.MaxSubsurfaceRange > num)
						{
							num = weapon.MaxSubsurfaceRange;
						}
					}
				}
				if (num == 0f)
				{
					num = 1.5f;
				}
				ParentScen.MaxRisingMineRange_meters = (int)Math.Round(num * 1852f);
			}
			result = ParentScen.MaxRisingMineRange_meters.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100009", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = num2;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void Destroy(bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		checked
		{
			try
			{
				IsBeingDestroyed = true;
				DockingOps.HostDockFacility = null;
				if (ParentScen == null)
				{
					return;
				}
				PreDestructionHousekeeping(ScenEditAction, TriggeredBySinking: false, Damage.DamagePercent, DestroyUnitNow);
				if (ParentScen?.Sides_ReadOnly != null)
				{
					Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
					for (int i = 0; i < sides_ReadOnly.Length; i++)
					{
						sides_ReadOnly[i].HandleUnitDestruction(this, ScenEditAction);
					}
				}
				if (ParentScen?.Sides_ReadOnly != null)
				{
					Side[] sides_ReadOnly2 = ParentScen.Sides_ReadOnly;
					for (int j = 0; j < sides_ReadOnly2.Length; j++)
					{
						sides_ReadOnly2[j].HandleUnitDestruction(this, ScenEditAction);
					}
				}
				foreach (Weapon item in ParentScen?.AllWeaponsAlive)
				{
					List<Contact> list = new List<Contact>();
					Contact[] targets_ReadOnly = ((ActiveUnit)item).AI.Targets_ReadOnly;
					foreach (Contact contact in targets_ReadOnly)
					{
						if (contact.ActualUnit == this)
						{
							list.Add(contact);
						}
					}
					foreach (Contact item2 in list)
					{
						((ActiveUnit)item).AI.DropTarget(item2);
					}
				}
				foreach (ActiveUnit item3 in DockingOps.EmbarkedBoats_ReadOnly)
				{
					item3.Destroy(ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this), DestroyUnitNow, "Destroyed as the object it is docked to is being destroyed", "Host Destruction");
				}
				foreach (Aircraft item4 in AirOps.EmbarkedAircraft_ReadOnly)
				{
					item4.Destroy(ScenEditAction, Module_ActiveUnit.IsAimpointFacility(this), DestroyUnitNow, "Destroyed as the object it is landed on is being destroyed", "Host Destruction");
				}
				if (ParentScen.UnguidedWeapons.HasElements())
				{
					IEnumerator<KeyValuePair<string, UnguidedWeapon>> enumerator5 = ParentScen.UnguidedWeapons.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						UnguidedWeapon value = enumerator5.Current.Value;
						if (value.Type == Weapon._WeaponType.AttachedMine && value?.Target?.ActualUnit == this)
						{
							value.DestroyMe(ref ParentScen, "Attached vessel is destroyed");
						}
					}
				}
				if (!ScenEditAction)
				{
					if (!DestroyUnitNow)
					{
						DeleteImmediately();
					}
					else
					{
						ParentScen.DestroyThisUnit(this, theReason, WhatCausedIt);
					}
				}
				else
				{
					DeleteImmediately();
				}
				pooledList_0.Clear();
				pooledList_0.Dispose();
				Kills.Clear();
				Kills.Dispose();
				if (!(GameGeneral.Beta_PlatformComms & ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) || CommStuff.Networks == null)
				{
					return;
				}
				foreach (CommNetwork network in CommStuff.Networks)
				{
					this.get_UnitSide(SetSideOnly: false).CommNetworks[network.ID].Members.Remove(this);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100011", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ConvertInstallationToSingleUnit(Group theGroup, Scenario theScen)
	{
		Group.GroupType type = theGroup.Type;
		if (type != Group.GroupType.AirBase)
		{
			return;
		}
		Facility facility = theScen.AddNewFacility(theGroup.get_UnitSide(SetSideOnly: false), 1877, theGroup.Name, theGroup.get_Longitude((GlobalVariables.BooleanObject)null), theGroup.get_Latitude((GlobalVariables.BooleanObject)null));
		facility._Fuel.Clear();
		facility._Sensors.Clear();
		facility.observableList_2.Clear();
		ArrayExtensions.Clear(ref facility.Magazines);
		ArrayExtensions.Clear(ref facility._Comms);
		ArrayExtensions.Clear(ref facility._AirFacilities);
		ArrayExtensions.Clear(ref facility._DockFacilities);
		PooledList<ActiveUnit> pooledList = new PooledList<ActiveUnit>();
		foreach (ActiveUnit value in theGroup.Units.Values)
		{
			foreach (FuelRec item in value._Fuel)
			{
				facility._Fuel.Add(item);
			}
			value._Fuel.Clear();
			foreach (Sensor sensor in value._Sensors)
			{
				facility._Sensors.Add(sensor);
			}
			value._Sensors.Clear();
			foreach (Mount mount in value.Mounts)
			{
				facility.Mounts.Add(mount);
			}
			value.Mounts.Clear();
			Magazine[] magazines = ((Platform)value).Magazines;
			foreach (Magazine theAC in magazines)
			{
				ArrayExtensions.Add(ref facility.Magazines, theAC);
			}
			ArrayExtensions.Clear(ref ((Platform)value).Magazines);
			CommDevice[] comms = value._Comms;
			foreach (CommDevice theAC2 in comms)
			{
				ArrayExtensions.Add(ref facility._Comms, theAC2);
			}
			ArrayExtensions.Clear(ref value._Comms);
			AirFacility[] airFacilities = value._AirFacilities;
			foreach (AirFacility theAC3 in airFacilities)
			{
				ArrayExtensions.Add(ref facility._AirFacilities, theAC3);
			}
			ArrayExtensions.Clear(ref value._AirFacilities);
			DockFacility[] dockFacilities = value._DockFacilities;
			foreach (DockFacility theAC4 in dockFacilities)
			{
				ArrayExtensions.Add(ref facility._DockFacilities, theAC4);
			}
			ArrayExtensions.Clear(ref value._DockFacilities);
			pooledList.Add(value);
		}
		foreach (ActiveUnit item2 in pooledList)
		{
			theScen.DeleteUnitImmediately(item2.ObjectID, ScenEditAction: true, "", null, RegisterAsLosses: false);
		}
	}

	protected void DeleteImmediately()
	{
		ConcurrentObservableDictionary<string, ActiveUnit> activeUnits = ParentScen.ActiveUnits;
		string objectID = ObjectID;
		ActiveUnit value = this;
		activeUnits.TryRemove(objectID, out value);
	}

	private bool method_5()
	{
		bool result = default(bool);
		try
		{
			foreach (ActiveUnit value in ParentScen.ActiveUnits.Values)
			{
				Contact[] targets_ReadOnly = value.AI.Targets_ReadOnly;
				for (int i = 0; i < targets_ReadOnly.Length; i = checked(i + 1))
				{
					if (targets_ReadOnly[i].ActualUnit == this)
					{
						result = true;
						return result;
					}
				}
				if (value.AI.PrimaryTarget != null && value.AI.PrimaryTarget.ActualUnit == this)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100012", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void SetThrottle(Throttle newThrottleSetting, float? SpecificDesiredSpeed = null)
	{
		try
		{
			if (ThrottleSetting == newThrottleSetting && !SpecificDesiredSpeed.HasValue && !ParentScen.MinuteIsChangingOnThisPulse)
			{
				return;
			}
			if (newThrottleSetting == Throttle.External)
			{
				newThrottleSetting = Throttle.External;
			}
			if ((int)newThrottleSetting > 4)
			{
				newThrottleSetting = Throttle.Flank;
			}
			if ((int)newThrottleSetting < 0)
			{
				newThrottleSetting = Throttle.FullStop;
			}
			if (newThrottleSetting > MaxPossibleThrottleSetting)
			{
				newThrottleSetting = MaxPossibleThrottleSetting;
			}
			ThrottleSetting = newThrottleSetting;
			if (!IsGroup)
			{
				if (!SpecificDesiredSpeed.HasValue & (_ThrottleSetting != Throttle.External))
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), _ThrottleSetting, ValidateAndFixAltitude: false);
				}
				else if (Kinematics.ThrottlePreset == ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					float? num = SpecificDesiredSpeed;
					float num2 = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), newThrottleSetting, ValidateAndFixAltitude: false);
					bool? flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > num2));
					bool? flag2 = (!flag) ?? flag;
					if (flag2 ?? true)
					{
						num = SpecificDesiredSpeed;
						num2 = Kinematics.GetMinimumSpeed((int)Math.Round(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), newThrottleSetting, ValidateAndFixAltitude: false);
						flag = (num.HasValue ? new bool?(num.GetValueOrDefault() < num2) : ((bool?)null));
						if (((!flag) ?? flag) == true && flag2.HasValue)
						{
							DesiredSpeed = SpecificDesiredSpeed.Value;
							goto IL_0281;
						}
					}
					if (_ThrottleSetting == Throttle.External)
					{
						DesiredSpeed = SpecificDesiredSpeed.Value;
					}
					else
					{
						ThrottleSetting = Kinematics.GetThrottleSuitableForThisSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), SpecificDesiredSpeed.Value);
						num = SpecificDesiredSpeed;
						num2 = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
						if ((num.HasValue ? new bool?(num.GetValueOrDefault() > num2) : ((bool?)null)) == true)
						{
							DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ThrottleSetting, ValidateAndFixAltitude: false);
						}
					}
				}
				else
				{
					DesiredSpeed = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (Throttle)Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
				}
			}
			goto IL_0281;
			IL_0281:
			RaiseEvent_ChangedThrottleSetting(this, ThrottleSetting);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100013", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RaiseEvent_ChangedThrottleSetting(ActiveUnit theUnit, Throttle theThrottle)
	{
		changedThrottleSettingEventHandler_0?.Invoke(theUnit, theThrottle);
	}

	public bool CanCarryCargo()
	{
		if (this is ICargoHost)
		{
			return ((ICargoHost)this).GetCargo_Type() != CargoType.NoCargo;
		}
		return false;
	}

	public virtual List<ActiveUnit> GetNearbyUnitsThatCanBeLoadedAsCargo()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<ActiveUnit> list2 = this.get_UnitSide(SetSideOnly: false).Units.ToList();
		foreach (ActiveUnit item in list2)
		{
			if (item != null && item != this && !item.IsMorituri && !(item.RangeToUnit_Horiz(this) > 2f) && item.IsOperating() && item is ICargoClient && ((ICargoClient)item).GetRequiredCargoType() > CargoType.NoCargo)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public virtual List<ActiveUnit> GetHostedUnitsThatCanBeLoadedAsCargo()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		List<AirFacility> list2 = AirFacilities_ReadOnly.ToList();
		if (list2 != null)
		{
			foreach (AirFacility item in list2)
			{
				if (!item.HasHostedAircraft())
				{
					continue;
				}
				foreach (Aircraft value in item.HostedAircraft.Values)
				{
					if (value is ICargoClient && ((ICargoClient)value).GetRequiredCargoType() != CargoType.NoCargo)
					{
						list.Add(value);
					}
				}
			}
		}
		List<DockFacility> list3 = DockFacilities_ReadOnly.ToList();
		if (list3 != null)
		{
			foreach (DockFacility item2 in list3)
			{
				if (!item2.HasHostedBoats())
				{
					continue;
				}
				foreach (ActiveUnit value2 in item2.HostedBoats.Values)
				{
					if (value2 is ICargoClient && ((ICargoClient)value2).GetRequiredCargoType() != CargoType.NoCargo)
					{
						list.Add(value2);
					}
				}
			}
		}
		return list;
	}

	public bool HasMineCountermeasures()
	{
		return MineCountermeasures.Count > 0;
	}

	public bool HasMineCounterWeapons()
	{
		int result;
		if ((object)GetType() == typeof(Aircraft))
		{
			WeaponRec[] weapons = ((Aircraft)this).Loadout.Weapons;
			foreach (WeaponRec weaponRec in weapons)
			{
				if (weaponRec.CurrentLoad > 0)
				{
					Weapon weapon = weaponRec.get_ReferenceWeapon(ParentScen);
					if (weapon.Type == Weapon._WeaponType.Torpedo && weaponRec.CurrentLoad >= 1 && weapon.ValidTargets.Mine)
					{
						return true;
					}
				}
			}
		}
		else if ((object)GetType() == typeof(Ship))
		{
			foreach (Weapon item in Weaponry.AllDistinctWeaponsAboard_Actual())
			{
				if (item.Type == Weapon._WeaponType.Torpedo && item.ValidTargets.Mine)
				{
					return true;
				}
			}
		}
		else if ((object)GetType() == typeof(Weapon))
		{
			_ = ((Weapon)this).Type;
			if (!((Weapon)this).ValidTargets.Mine)
			{
				result = 0;
				goto IL_0122;
			}
			return true;
		}
		result = 0;
		goto IL_0122;
		IL_0122:
		return (byte)result != 0;
	}

	public bool HasPassiveSensor()
	{
		return Sensors_Cached.Where([SpecialName] (Sensor theS) => !theS.CanBeActive).Count() > 0;
	}

	public bool HasActiveCapableSonarSensor()
	{
		bool result = default(bool);
		try
		{
			Sensor[] sensors_Cached = Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				if (sensor.IsSonar && sensor.CanBeActive)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100016", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsGroupMember()
	{
		if (_ParentGroup == null)
		{
			return false;
		}
		return _ParentGroup.Units.Count > 1;
	}

	public bool IsGroupWingman()
	{
		int result;
		if (!IsGroupMember())
		{
			result = 0;
		}
		else
		{
			if (!IsGroupLead())
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	internal new bool HasMoved()
	{
		GlobalVariables.BooleanObject booleanObject = Misc.ToBooleanObject(IsOperating());
		if ((Latitude_old != this.get_Latitude(booleanObject)) | (Longitude_old != this.get_Longitude(booleanObject)) | (base.Altitude_old != this.get_CurrentAltitude(DoSanityCheck: false, booleanObject)))
		{
			return true;
		}
		bool result = default(bool);
		return result;
	}

	public bool IsGroupLead()
	{
		Group parentGroup = _ParentGroup;
		if (parentGroup == null)
		{
			return false;
		}
		return parentGroup?.GroupLead == this;
	}

	public void SetFlight(Mission.Flight theFlight, int theFlightMemberNumber)
	{
		if (!IsGroupMember())
		{
			FlightRole = Mission.Flight.FlightElement.None;
		}
		else
		{
			FlightRole = RetrieveFlightRole(theFlightMemberNumber);
		}
		Navigator.set_Flight(HierarchySearch: true, theFlight);
		if (!IsAircraft)
		{
			return;
		}
		Aircraft aircraft = (Aircraft)this;
		if (aircraft.LoadoutDBID == theFlight.int_1 || (theFlight.SecondaryFlightPlans != null && theFlight.RetrieveSecondaryFP(aircraft.DBID, aircraft.LoadoutDBID) != null) || aircraft.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
		{
			return;
		}
		Strike strike = (Strike)aircraft.ActiveMissionOrPackage();
		int int32_ = aircraft.LoadoutDBID;
		if (theFlight.SecondaryFlightPlans == null)
		{
			theFlight.SecondaryFlightPlans = new List<SecondaryFlightPlan>();
		}
		List<Waypoint> list = new List<Waypoint>();
		AircraftMissionProfile theMissionProfile = aircraft.Loadout.get_MissionProfile(ParentScen);
		Weapon weapon = aircraft.Weaponry.MostSuitableWeaponForThisTarget(theFlight.PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, aircraft.Doctrine);
		List<Waypoint> list2 = new List<Waypoint>();
		int num = 0;
		Waypoint[] flightPlan = theFlight.FlightPlan;
		for (int i = 0; i < flightPlan.Length; i = checked(i + 1))
		{
			Waypoint theOriginalWaypoint = flightPlan[i];
			ref Scenario parentScen = ref ParentScen;
			Doctrine FlightLeadDoctrine = null;
			list2.Add(Waypoint.CopyWaypoint(ref parentScen, ref theOriginalWaypoint, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
			num++;
		}
		Waypoint waypoint = default(Waypoint);
		foreach (Waypoint item in list2)
		{
			Waypoint theOriginalWaypoint2 = item;
			Doctrine FlightLeadDoctrine;
			if ((theOriginalWaypoint2.Type == Waypoint.WaypointType.WeaponLaunch) | (theOriginalWaypoint2.Type == Waypoint.WaypointType.InitialPoint))
			{
				float LastKnownAltitude_TerrainFollowing = 0f;
				if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					LastKnownAltitude_TerrainFollowing = waypoint.DesiredAltitude_TerrainFollowing.Value;
				}
				float LastKnownSpeed = 0f;
				if (waypoint.DesiredSpeed.HasValue)
				{
					LastKnownSpeed = waypoint.DesiredSpeed.Value;
				}
				ref Scenario parentScen2 = ref ParentScen;
				Waypoint theExistingWaypoint = theOriginalWaypoint2;
				Mission.Flight flight;
				Waypoint[] theCourse = (flight = theFlight).FlightPlan_Pathfinder_Egress_1;
				double latitude = theOriginalWaypoint2.Latitude;
				double longitude = theOriginalWaypoint2.Longitude;
				float weaponRange = aircraft.Loadout.CombatRadius;
				Waypoint waypoint2;
				float LastKnownAltitude = (waypoint2 = waypoint).Altitude;
				Waypoint waypoint3;
				bool LastKnownTerrainFollowing = (waypoint3 = waypoint).TerrainFollowing;
				Waypoint waypoint4;
				ActiveUnit_Kinematics.UnitThrottlePreset LastKnownThrottle = (waypoint4 = waypoint).ThrottlePreset;
				Waypoint waypoint5 = MissionPlanner.AddOrUpdateWaypoint_Attack_InitialPoint_Or_WeaponReleasePoint(theExistingWaypoint, aircraft, ref theCourse, latitude, longitude, theMissionProfile, Mission._RadarBehaviour.UseMissionEMCON, weaponRange, ref LastKnownAltitude, ref LastKnownAltitude_TerrainFollowing, ref LastKnownTerrainFollowing, ref LastKnownThrottle, ref LastKnownSpeed, ref strike.AttackMethod, ref waypoint.FlightFormation, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military, weapon, theFlight.PrimaryTarget);
				waypoint4.ThrottlePreset = LastKnownThrottle;
				waypoint3.TerrainFollowing = LastKnownTerrainFollowing;
				waypoint2.Altitude = LastKnownAltitude;
				flight.FlightPlan_Pathfinder_Egress_1 = theCourse;
				Waypoint theOriginalWaypoint3 = waypoint5;
				FlightLeadDoctrine = null;
				theOriginalWaypoint2 = Waypoint.CopyWaypoint(ref parentScen2, ref theOriginalWaypoint3, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine);
				theOriginalWaypoint2.Name = int32_ + " " + theOriginalWaypoint2.Name;
				theOriginalWaypoint2.Description = "(" + int32_ + ") " + theOriginalWaypoint2.Description;
				int referenceWeapon_ID = waypoint.ReferenceWeapon_ID;
				double num2 = 0.0;
				double num3 = 0.0;
				if (weapon != null)
				{
					num3 = weapon.get_MaxRangeForThisTarget((ActiveUnit)aircraft, (Contact)strike.SpecificTargets.ElementAtOrDefault(0), CheckWRA: true, aircraft.Doctrine, ManualFire: false);
					if (referenceWeapon_ID != 0)
					{
						num2 = Weapon.GetNewWeapon(ref aircraft.ParentScen, referenceWeapon_ID, bool_5: false).get_MaxRangeForThisTarget((ActiveUnit)aircraft, (Contact)strike.SpecificTargets.ElementAtOrDefault(0), CheckWRA: true, aircraft.Doctrine, ManualFire: false);
						if (num2 > num3)
						{
							float num4 = Module_Unit.BearingToPoint_Relative(this, waypoint.Latitude, waypoint.Longitude);
							double value = num2 - num3;
							value = Math.Abs(value);
							theOriginalWaypoint2 = Waypoint.Move_Distance_NM_Bearing(theOriginalWaypoint2, value, num4);
						}
					}
				}
			}
			else if (theOriginalWaypoint2.Type == Waypoint.WaypointType.StrikeIngress)
			{
				float LastKnownAltitude_TerrainFollowing2 = 0f;
				if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					LastKnownAltitude_TerrainFollowing2 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				}
				float LastKnownSpeed2 = 0f;
				if (waypoint.DesiredSpeed.HasValue)
				{
					LastKnownSpeed2 = waypoint.DesiredSpeed.Value;
				}
				ref Scenario parentScen3 = ref ParentScen;
				Waypoint theExistingWaypoint2 = theOriginalWaypoint2;
				Mission.Flight flight;
				Waypoint[] theCourse = (flight = theFlight).FlightPlan_Pathfinder_Egress_1;
				double theLat = theOriginalWaypoint2.Latitude + 10.0;
				double theLon = theOriginalWaypoint2.Longitude + 10.0;
				Waypoint waypoint4;
				float LastKnownAltitude = (waypoint4 = waypoint).Altitude;
				Waypoint waypoint3;
				bool LastKnownTerrainFollowing = (waypoint3 = waypoint).TerrainFollowing;
				Waypoint waypoint2;
				ActiveUnit_Kinematics.UnitThrottlePreset LastKnownThrottle = (waypoint2 = waypoint).ThrottlePreset;
				Waypoint waypoint6 = MissionPlanner.AddOrUpdateWaypoint_Attack_Ingress(theExistingWaypoint2, aircraft, ref theCourse, theLat, theLon, theMissionProfile, Mission._RadarBehaviour.UseMissionEMCON, ref LastKnownAltitude, ref LastKnownAltitude_TerrainFollowing2, ref LastKnownTerrainFollowing, ref LastKnownThrottle, ref LastKnownSpeed2, ref waypoint.FlightFormation, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military, weapon, theFlight.PrimaryTarget);
				waypoint2.ThrottlePreset = LastKnownThrottle;
				waypoint3.TerrainFollowing = LastKnownTerrainFollowing;
				waypoint4.Altitude = LastKnownAltitude;
				flight.FlightPlan_Pathfinder_Egress_1 = theCourse;
				Waypoint theOriginalWaypoint3 = waypoint6;
				FlightLeadDoctrine = null;
				theOriginalWaypoint2 = Waypoint.CopyWaypoint(ref parentScen3, ref theOriginalWaypoint3, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine);
				theOriginalWaypoint2.Name = int32_ + " " + theOriginalWaypoint2.Name;
				theOriginalWaypoint2.Description = "(" + int32_ + ") " + theOriginalWaypoint2.Description;
			}
			else if (theOriginalWaypoint2.Type == Waypoint.WaypointType.StrikeEgress)
			{
				float LastKnownAltitude_TerrainFollowing3 = 0f;
				if (waypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					LastKnownAltitude_TerrainFollowing3 = waypoint.DesiredAltitude_TerrainFollowing.Value;
				}
				float LastKnownSpeed3 = 0f;
				if (waypoint.DesiredSpeed.HasValue)
				{
					LastKnownSpeed3 = waypoint.DesiredSpeed.Value;
				}
				ref Scenario parentScen4 = ref ParentScen;
				Waypoint theExistingWaypoint3 = theOriginalWaypoint2;
				Mission.Flight flight;
				Waypoint[] theCourse = (flight = theFlight).FlightPlan_Pathfinder_Egress_1;
				double theLat2 = theOriginalWaypoint2.Latitude + 10.0;
				double theLon2 = theOriginalWaypoint2.Longitude + 10.0;
				Waypoint waypoint2;
				float LastKnownAltitude = (waypoint2 = waypoint).Altitude;
				Waypoint waypoint3;
				bool LastKnownTerrainFollowing = (waypoint3 = waypoint).TerrainFollowing;
				Waypoint waypoint4;
				ActiveUnit_Kinematics.UnitThrottlePreset LastKnownThrottle = (waypoint4 = waypoint).ThrottlePreset;
				Waypoint waypoint7 = MissionPlanner.AddOrUpdateWaypoint_Attack_Egress(theExistingWaypoint3, aircraft, ref theCourse, theLat2, theLon2, theMissionProfile, ref LastKnownAltitude, ref LastKnownAltitude_TerrainFollowing3, ref LastKnownTerrainFollowing, ref LastKnownThrottle, ref LastKnownSpeed3, ref waypoint.FlightFormation, Waypoint.TurnRateCategory.DoubleStandardRateTurn, Waypoint.SpeedToT.Yes_UpOrDown_Military, weapon);
				waypoint4.ThrottlePreset = LastKnownThrottle;
				waypoint3.TerrainFollowing = LastKnownTerrainFollowing;
				waypoint2.Altitude = LastKnownAltitude;
				flight.FlightPlan_Pathfinder_Egress_1 = theCourse;
				Waypoint theOriginalWaypoint3 = waypoint7;
				FlightLeadDoctrine = null;
				theOriginalWaypoint2 = Waypoint.CopyWaypoint(ref parentScen4, ref theOriginalWaypoint3, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine);
				theOriginalWaypoint2.Name = int32_ + " " + theOriginalWaypoint2.Description;
				theOriginalWaypoint2.Description = "(" + int32_ + ") " + theOriginalWaypoint2.Description;
			}
			ref Scenario parentScen5 = ref ParentScen;
			FlightLeadDoctrine = null;
			list.Add(Waypoint.CopyWaypoint(ref parentScen5, ref theOriginalWaypoint2, CopyWingmanWaypoints: true, CopyFlightplanPointsList: true, ref FlightLeadDoctrine));
			waypoint = theOriginalWaypoint2;
		}
		foreach (Waypoint item2 in list)
		{
			if (weapon != null)
			{
				switch (item2.Type)
				{
				case Waypoint.WaypointType.InitialPoint:
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
				case Waypoint.WaypointType.StrikeEgress:
				case Waypoint.WaypointType.WeaponLaunch:
				case Waypoint.WaypointType.WeaponTarget:
					item2.ReferenceWeapon_ID = weapon.DBID;
					break;
				}
			}
		}
		string nextCallSign = SecondaryFlightPlan.GetNextCallSign(theFlight.SecondaryFlightPlans.Count);
		theFlight.SecondaryFlightPlans.Add(new SecondaryFlightPlan(aircraft.DBID, int32_, list.ToArray(), nextCallSign));
		if (FlightRole == Mission.Flight.FlightElement.None)
		{
			Navigator.PlottedCourse = list.ToArray();
		}
	}

	public static Mission.Flight.FlightElement RetrieveFlightRole(int theFlightMemberNumber)
	{
		switch (theFlightMemberNumber)
		{
		default:
		{
			int num = theFlightMemberNumber;
			while (num - 5 > 0 && num != 2 && num != 3 && num != 4 && num != 5 && num != 6)
			{
				num -= 5;
			}
			Mission.Flight.FlightElement flightElement = default(Mission.Flight.FlightElement);
			return num switch
			{
				2 => Mission.Flight.FlightElement.LeadElementWingman, 
				3 => Mission.Flight.FlightElement.SecondElement, 
				4 => Mission.Flight.FlightElement.SecondElementWingman, 
				5 => Mission.Flight.FlightElement.ThirdElement, 
				6 => Mission.Flight.FlightElement.ThirdElementWingman, 
				_ => flightElement, 
			};
		}
		case 1:
			return Mission.Flight.FlightElement.LeadElement;
		case 2:
			return Mission.Flight.FlightElement.LeadElementWingman;
		case 3:
			return Mission.Flight.FlightElement.SecondElement;
		case 4:
			return Mission.Flight.FlightElement.SecondElementWingman;
		case 5:
			return Mission.Flight.FlightElement.ThirdElement;
		case 6:
			return Mission.Flight.FlightElement.ThirdElementWingman;
		}
	}

	public void SetGroup()
	{
	}

	public void AddMessage(string MessageText, string MessageSummary, LoggedMessage.MessageType MessageType, byte MessageLevel, Geopoint_Struct theLocation = default(Geopoint_Struct), NotificationType Notification = NotificationType.None)
	{
		switch (Notification)
		{
		case NotificationType.Baloon:
			Message = MessageText;
			break;
		case NotificationType.Bark:
			Notification_Bark.Create_UnitBehaviour(this, MessageText, Color.White);
			break;
		}
		if (ParentScen != null)
		{
			ParentScen.AddMessage(MessageText, MessageSummary, MessageType, MessageLevel, ObjectID, this.get_UnitSide(SetSideOnly: false), theLocation);
		}
	}

	public void AddMessage_ToUnit(string MessageText, string MessageSummary, LoggedMessage.MessageType MessageType, byte MessageLevel, ActiveUnit theLocation, NotificationType Notification = NotificationType.None)
	{
		switch (Notification)
		{
		case NotificationType.Baloon:
			Message = MessageText;
			break;
		case NotificationType.Bark:
			Notification_Bark.Create_UnitBehaviour(theLocation, MessageText, Color.White);
			break;
		}
		if (ParentScen != null)
		{
			ParentScen.AddMessage(MessageText, MessageSummary, MessageType, MessageLevel, ObjectID, this.get_UnitSide(SetSideOnly: false), theLocation.Location);
		}
	}

	public void RemoveCommDevice(CommDevice theCommDevice)
	{
		ArrayExtensions.Remove(ref _Comms, theCommDevice);
	}

	public virtual void Fuel_Add(float theQuantity, FuelRec._FuelType theType)
	{
		try
		{
			float num = theQuantity;
			foreach (FuelRec item in Fuel_ReadOnly)
			{
				if (num == 0f)
				{
					break;
				}
				if (item.FuelType == theType)
				{
					float num2 = (float)item.MaxQuantity - item.CurrentQuantity;
					if (num2 > num)
					{
						item.AddFuel(num);
						num = 0f;
					}
					else
					{
						item.CurrentQuantity = item.MaxQuantity;
						num -= num2;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100017", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Fuel_Subtract(float theQuantity, FuelRec._FuelType theType)
	{
		try
		{
			if (theQuantity == 0f)
			{
				return;
			}
			FuelRec fuelRec = (from theFuelrec in Fuel_ReadOnly
				select (theFuelrec) into theFuelrec
				where theFuelrec.FuelType == theType
				select theFuelrec).ElementAtOrDefault(0);
			if (fuelRec.CurrentQuantity > theQuantity)
			{
				fuelRec.SubtractFuel(theQuantity);
				return;
			}
			bool num = fuelRec.CurrentQuantity > 0f;
			fuelRec.CurrentQuantity = 0f;
			SetThrottle(Throttle.FullStop);
			if (num)
			{
				AddMessage(Name + " (" + Misc.RemoveHiddenString(UnitClass) + ") has run out of fuel!", "Unit out of fuel", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100018", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void DoFuelConsumption(float elapsedTime)
	{
	}

	public virtual bool AttemptToSetNewAssignedHost(ActiveUnit DestinationUnit, bool RTBifSuccess = false, bool OutputFeedback = false)
	{
		if (DestinationUnit == this)
		{
			return false;
		}
		bool flag = !DestinationUnit.IsGroup;
		bool flag2 = false;
		bool flag3 = false;
		if (DestinationUnit.IsGroup)
		{
			if (((Group)DestinationUnit).Type == Group.GroupType.AirBase)
			{
				flag3 = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (IsDrone() && ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.DroneAutonomyLevels) && !CommStuff.IsConnectedToSideNetwork)
		{
			if (AutonomyLevel < DroneAutonomyLevel.BattlespaceCognizant)
			{
				string text = "Failed to set " + DestinationUnit.Name + " as the new base for " + Name + ". Reason: This is a disconnected drone with insufficient autonomy level.";
				if (OutputFeedback)
				{
					GameGeneral.SendMessageBoxToUI(text, this.get_UnitSide(SetSideOnly: false), "Failed to re-base " + Name, GameGeneral.MessageBoxMessageType.Warning);
				}
				ParentScen.AddMessage(text, "Failed to re-base " + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
				return false;
			}
			if (flag && !flag3 && AutonomyLevel < DroneAutonomyLevel.FullyAutonomous)
			{
				string text2 = "Failed to set " + DestinationUnit.Name + " as the new base for " + Name + ". Reason: The unit is a disconnected drone with insufficient autonomy level.";
				if (OutputFeedback)
				{
					GameGeneral.SendMessageBoxToUI(text2, this.get_UnitSide(SetSideOnly: false), "Failed to re-base " + Name, GameGeneral.MessageBoxMessageType.Warning);
				}
				ParentScen.AddMessage(text2, "Failed to re-base " + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
				return false;
			}
		}
		if (Operators.CompareString(Name, UnitClass, false) != 0)
		{
			_ = " (" + UnitClass + ")";
		}
		if (!flag && !flag3)
		{
			if (flag2)
			{
				Module_Unit.Unit unit = null;
				foreach (ActiveUnit value in ((Group)DestinationUnit).Units.Values)
				{
					if (DockingOps.ThisUnitCanHostMe(value, HumanFeedBackNeeded: false).ResponseBoolean)
					{
						DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, value);
						unit = value;
						break;
					}
				}
				if (unit == null)
				{
					ParentScen.AddMessage("Failed to set " + DestinationUnit.Name + " as the new base for " + Name, "Failed to re-base " + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
					return false;
				}
				ParentScen.AddMessage(DestinationUnit.Name + " is now the base for " + Name, Name + " has new home base", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
				return true;
			}
			return false;
		}
		(bool, string) tuple = DockingOps.ThisUnitCanHostMe(DestinationUnit, HumanFeedBackNeeded: true);
		if (!tuple.Item1)
		{
			string text3 = "Failed to set " + DestinationUnit.Name + " as the new base for " + Name + ". Reason: " + tuple.Item2;
			if (OutputFeedback)
			{
				GameGeneral.SendMessageBoxToUI(text3, this.get_UnitSide(SetSideOnly: false), "Failed to re-base " + Name, GameGeneral.MessageBoxMessageType.Warning);
			}
			ParentScen.AddMessage(text3, "Failed to re-base " + Name, LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
			return false;
		}
		DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, DestinationUnit);
		if (RTBifSuccess)
		{
			AI.ReturnToBase(1f);
		}
		ParentScen.AddMessage(DestinationUnit.Name + " is now the base for " + Name, Name + " has new home base", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
		return true;
	}

	public void GoInoperative()
	{
		try
		{
			ActiveUnit_AI aI = AI;
			ActiveUnit theAU = this;
			aI.ClearAllTargets(ref theAU);
			Side[] sides_ReadOnly = ParentScen.Sides_ReadOnly;
			for (int i = 0; i < sides_ReadOnly.Length; i = checked(i + 1))
			{
				sides_ReadOnly[i].HandleUnitGoingInoperative(this);
			}
			ActiveUnit activeUnit = (IsAircraft ? ((Aircraft)this).AirOps.CurrentHostUnit : DockingOps.CurrentHostUnit);
			if (activeUnit != null)
			{
				if (!activeUnit.CommStuff.IsConnectedToSideNetwork)
				{
					if (CommStuff.IsConnectedToSideNetwork)
					{
						ActiveUnit_CommStuff.ReasonForGoingOffGrid reasonForBeingOffGrid = activeUnit.CommStuff.ReasonForBeingOffGrid;
						activeUnit.CommStuff.set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, value: true);
						activeUnit.CommStuff.set_IsConnectedToSideNetwork(reasonForBeingOffGrid, value: false);
					}
				}
				else
				{
					CommStuff.set_IsConnectedToSideNetwork(ActiveUnit_CommStuff.ReasonForGoingOffGrid.None, value: true);
				}
			}
			CurrentSpeed = 0f;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100019", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveSensor(Sensor theS)
	{
		try
		{
			_Sensors.Remove(theS);
			foreach (Mount mount in Mounts)
			{
				mount.RemoveSensor(theS);
			}
			Sensors_Cached = null;
			MineCountermeasures = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100020", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void ClearManualOrders()
	{
		AI.ClearManualOrders();
	}

	public void DetachUnit(bool NotifyPlayer, bool ClearPlottedCourse, bool UseFlightplan)
	{
		if (IsWeapon)
		{
			return;
		}
		if (IsGroup)
		{
			((Group)this).Destroy(ScenEditAction: false, IsAimpointFacility: false, DestroyUnitNow: true, "Disbanded", null, RegisterAsLosses: false);
		}
		if (!IsGroupMember())
		{
			return;
		}
		try
		{
			if (IsGroupLead() && this.get_ParentGroup(UsingMissionPlanner: false).Units.Count > 1)
			{
				ActiveUnit activeUnit = default(ActiveUnit);
				if (IsFacility)
				{
					foreach (ActiveUnit value in this.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
					{
						if (value != this)
						{
							activeUnit = value;
						}
					}
				}
				else
				{
					double num = 0.0;
					List<ActiveUnit> list = new List<ActiveUnit>(this.get_ParentGroup(UsingMissionPlanner: false).Units.Values);
					foreach (ActiveUnit item in list)
					{
						if (item != this && item != null && (double)item.EmptyWeight > num)
						{
							activeUnit = item;
							num = item.EmptyWeight;
						}
					}
				}
				if (activeUnit != null)
				{
					this.get_ParentGroup(UsingMissionPlanner: false).SetGroupLead(activeUnit);
					activeUnit.Status = Status;
					activeUnit.Kinematics.DesiredSpeedOverride = Kinematics.DesiredSpeedOverride;
					activeUnit.Kinematics.DesiredAltitudeOverride = Kinematics.DesiredAltitudeOverride;
					activeUnit.DesiredAltitude = DesiredAltitude;
					activeUnit.DesiredAltitude_AGL = DesiredAltitude_AGL;
					activeUnit.DesiredSpeed = DesiredSpeed;
					activeUnit.set_DesiredAltitude_UseTerrainFollowing(activeUnit, this.get_DesiredAltitude_UseTerrainFollowing(this));
				}
			}
			if (NotifyPlayer)
			{
				string text = "";
				if (IsAircraft && Operators.CompareString(Name, UnitClass, false) != 0)
				{
					text = " (" + UnitClass + ")";
				}
				ParentScen.AddMessage(Name + text + " has been detached from group: " + this.get_ParentGroup(UsingMissionPlanner: false).Name, Name + " detached", LoggedMessage.MessageType.UnitAI, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			if (UseFlightplan && IsAircraft && this.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse())
			{
				Waypoint[] plottedCourse = this.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse;
				foreach (Waypoint theAC in plottedCourse)
				{
					ActiveUnit_Navigator navigator = Navigator;
					Waypoint[] theArray = navigator.PlottedCourse;
					ArrayExtensions.Add(ref theArray, theAC);
					navigator.PlottedCourse = theArray;
				}
			}
			this.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
			if (ClearPlottedCourse)
			{
				Navigator.ClearPlottedCourse();
			}
			Kinematics.DesiredSpeedOverride = null;
			Kinematics.DesiredAltitudeOverride = false;
			Doctrine.ClearCachedParentDoctrine();
			Sensory.vmethod_2(Sensors_Cached);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101262", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool IsInsideNoNavZones(double theLat, double theLon, float ProximityThreshold_Deg)
	{
		string firstZoneName = default(string);
		return IsInsideNoNavZones(theLat, theLon, ProximityThreshold_Deg, ref firstZoneName);
	}

	internal bool IsInsideNoNavZones(double theLat, double theLon, float ProximityThreshold_Deg, ref string firstZoneName)
	{
		bool result;
		try
		{
			if (this.get_UnitSide(SetSideOnly: false) == null)
			{
				result = false;
			}
			else
			{
				foreach (NoNavZone noNavZone in this.get_UnitSide(SetSideOnly: false).NoNavZones)
				{
					if (noNavZone.Area.Count == 0 || !noNavZone.IsActive || !((Zone)noNavZone).get_AffectsThisUnit(this))
					{
						continue;
					}
					if (ProximityThreshold_Deg == 0.2f)
					{
						if (noNavZone.Area_RefPoints_020deg_ChangeCheck.Count == 0 || GeoPoint.ZoneHasChanged(noNavZone.Area, noNavZone.Area_RefPoints_020deg_ChangeCheck))
						{
							noNavZone.CalculateAreaWithThresholdAdded(ProximityThreshold_Deg, ref noNavZone.Area_GeoPoints_020deg_Buffered, ref noNavZone.Area_RefPoints_020deg_ChangeCheck);
						}
						if (!GeoPoint.IsInsideThisArea(theLat, theLon, noNavZone.Area_GeoPoints_020deg_Buffered))
						{
							continue;
						}
						firstZoneName = noNavZone.Description;
						result = true;
					}
					else if (ProximityThreshold_Deg == 0.15f)
					{
						if (noNavZone.Area_RefPoints_015deg_ChangeCheck.Count == 0 || GeoPoint.ZoneHasChanged(noNavZone.Area, noNavZone.Area_RefPoints_015deg_ChangeCheck))
						{
							noNavZone.CalculateAreaWithThresholdAdded(ProximityThreshold_Deg, ref noNavZone.Area_GeoPoints_015deg_Buffered, ref noNavZone.Area_RefPoints_015deg_ChangeCheck);
						}
						if (!GeoPoint.IsInsideThisArea(theLat, theLon, noNavZone.Area_GeoPoints_015deg_Buffered))
						{
							continue;
						}
						firstZoneName = noNavZone.Description;
						result = true;
					}
					else
					{
						if (!GeoPoint.IsInsideThisArea(theLat, theLon, noNavZone.Area_AsArray))
						{
							continue;
						}
						firstZoneName = noNavZone.Description;
						result = true;
					}
					goto end_IL_0001;
				}
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101268", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (!Debugger.IsAttached)
			{
				num = 0;
			}
			else
			{
				Debugger.Break();
				num = 0;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool DistanceToNearestNoNavZone()
	{
		bool result;
		try
		{
			if (this.get_UnitSide(SetSideOnly: false).NoNavZones.Count != 0)
			{
				if (!(Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation > 0.0))
				{
					float num = float.MaxValue;
					foreach (NoNavZone noNavZone in this.get_UnitSide(SetSideOnly: false).NoNavZones)
					{
						if (noNavZone.Area.Count != 0 && ((Zone)noNavZone).get_AffectsThisUnit(this))
						{
							float num2 = noNavZone.CalculateDistanceToZone(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), ParentScen);
							if (num2 < num)
							{
								num = num2;
							}
						}
					}
					if (num < 10f)
					{
						Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 300.0;
						Navigator.CheckNoNavZones_UnitMovementOnEveryPulse = true;
					}
					else
					{
						double num3 = (num - 5f) / (float)Kinematics.GetMaximumSpeed() * 3600f;
						if (num3 > 300.0)
						{
							num3 = 300.0;
						}
						Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = num3;
						Navigator.CheckNoNavZones_UnitMovementOnEveryPulse = false;
					}
				}
				result = (Navigator.CheckNoNavZones_UnitMovementOnEveryPulse ? true : false);
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200340", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 300.0;
			Navigator.CheckNoNavZones_UnitMovementOnEveryPulse = true;
			result = true;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void pIvLodjowEQ(object object_0, ObservableListModified<Mount> observableListModified_0)
	{
		foreach (Mount item in observableListModified_0.Items)
		{
			activeUnitMountsAddedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
		}
		Mounts_AsArray = Mounts.ToArray();
		IsDumbAU = false;
	}

	private void method_6(object object_0, ObservableListModified<Mount> observableListModified_0)
	{
		foreach (Mount item in observableListModified_0.Items)
		{
			activeUnitMountsRemovedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
		}
		Mounts_AsArray = Mounts.ToArray();
		EvaluateIfDumb();
	}

	private void method_7(object object_0, object object_1)
	{
		Mounts_AsArray = Mounts.ToArray();
		EvaluateIfDumb();
	}

	public void EvaluateIfDumb()
	{
		if (IsAggregatedUnit)
		{
			IsDumbAU = false;
		}
		else if ((object)GetType() == typeof(GuidedProjectile))
		{
			IsDumbAU = false;
		}
		else if (IsPalletWeapon)
		{
			IsDumbAU = false;
		}
		else if (Mounts.Count != 0)
		{
			IsDumbAU = false;
		}
		else if (base.IsFixedFacility)
		{
			IsDumbAU = true;
		}
		else if (UnitType == GlobalVariables.ActiveUnitType.Facility && ((Facility)this).RepresentsMobileGroundUnit)
		{
			IsDumbAU = false;
		}
		else
		{
			IsDumbAU = Propulsion.Count == 0;
		}
	}

	private void method_8(object object_0, ObservableListModified<Engine> observableListModified_0)
	{
		IsDumbAU = false;
		Kinematics.ResetMaxSpeed();
		Kinematics.ResetCachedMaxMinAlt();
		nullable_15 = null;
	}

	private void method_9(object object_0, ObservableListModified<Engine> observableListModified_0)
	{
		EvaluateIfDumb();
		Kinematics.ResetMaxSpeed();
		Kinematics.ResetCachedMaxMinAlt();
		nullable_15 = null;
	}

	public void TemporarySignatureIncrease_Factor(XSection._SignatureType EmissionType, float IntensityFactor, int Duration = 1)
	{
		int signatureTypeIndex = XSection.GetSignatureTypeIndex(EmissionType);
		if (TemporaryEmissionEM[signatureTypeIndex] == null)
		{
			TemporaryEmissionEM[signatureTypeIndex] = new Str_TemporaryEmission(IntensityFactor, 0f, Duration, this);
			return;
		}
		TemporaryEmissionEM[signatureTypeIndex].SignatureAbsoluteIncrease = 0f;
		TemporaryEmissionEM[signatureTypeIndex].SignatureMultiplier = Math.Max(IntensityFactor, TemporaryEmissionEM[signatureTypeIndex].SignatureMultiplier);
		DateTime terminationDate = ParentScen.Time.AddSeconds(Duration);
		if (terminationDate.Ticks > TemporaryEmissionEM[signatureTypeIndex].TerminationDate.Ticks)
		{
			TemporaryEmissionEM[signatureTypeIndex].TerminationDate = terminationDate;
		}
	}

	public void TemporarySignatureIncrease_Absolute(XSection._SignatureType EmissionType, float Intensity, int Duration = 1)
	{
		int signatureTypeIndex = XSection.GetSignatureTypeIndex(EmissionType);
		if (TemporaryEmissionEM[signatureTypeIndex] != null)
		{
			TemporaryEmissionEM[signatureTypeIndex].SignatureMultiplier = 1f;
			TemporaryEmissionEM[signatureTypeIndex].SignatureAbsoluteIncrease = Math.Max(Intensity, TemporaryEmissionEM[signatureTypeIndex].SignatureAbsoluteIncrease);
			DateTime terminationDate = ParentScen.Time.AddSeconds(Duration);
			if (terminationDate.Ticks > TemporaryEmissionEM[signatureTypeIndex].TerminationDate.Ticks)
			{
				TemporaryEmissionEM[signatureTypeIndex].TerminationDate = terminationDate;
			}
		}
		else
		{
			TemporaryEmissionEM[signatureTypeIndex] = new Str_TemporaryEmission(1f, Intensity, Duration, this);
		}
	}

	internal bool IsSplittable()
	{
		if (IsFacility)
		{
			return Kinematics.GetMaximumSpeed() > 0;
		}
		return false;
	}

	internal float GetTemporarySignature(XSection._SignatureType EmissionType, Str_TemporaryEmission.SignatureOperator Type)
	{
		int signatureTypeIndex = XSection.GetSignatureTypeIndex(EmissionType);
		switch (Type)
		{
		case Str_TemporaryEmission.SignatureOperator.Factor:
			if (TemporaryEmissionEM[signatureTypeIndex] != null && !TemporaryEmissionEM[signatureTypeIndex].HasTimedOut(ParentScen.Time))
			{
				return TemporaryEmissionEM[signatureTypeIndex].SignatureMultiplier;
			}
			return 1f;
		case Str_TemporaryEmission.SignatureOperator.Absolute:
			if (TemporaryEmissionEM[signatureTypeIndex] != null && !TemporaryEmissionEM[signatureTypeIndex].HasTimedOut(ParentScen.Time))
			{
				return TemporaryEmissionEM[signatureTypeIndex].SignatureAbsoluteIncrease;
			}
			return 0f;
		default:
		{
			if (Debugger.IsAttached)
			{
				throw new NotImplementedException();
			}
			float result = default(float);
			return result;
		}
		}
	}

	internal void UnassignUnit()
	{
		CoreClientCode.UnassignUnit_Core(this, ParentScen, this.get_UnitSide(SetSideOnly: false));
	}

	public void UpdateSettlingOnPosition(float ElapsedTime)
	{
		if (nullable_14.HasValue)
		{
			Geopoint_Struct value = nullable_14.Value;
			if (value.Longitude == this.get_Longitude((GlobalVariables.BooleanObject)null) && value.Latitude == this.get_Latitude((GlobalVariables.BooleanObject)null) && value.Altitude == this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
			{
				SettledTime = Math.Min(SettledTime + ElapsedTime, float.MaxValue);
				return;
			}
			SettledTime = 0f;
		}
		nullable_14 = new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
	}

	public bool IsUsingDippingSonar()
	{
		if (IsAircraft && ((Aircraft)this).AirOps.Condition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
		{
			return true;
		}
		int result;
		if (!IsShip)
		{
			result = 0;
		}
		else
		{
			if (((Ship)this).DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.DeployingDippingSonar)
			{
				return true;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	internal ActiveUnit getEscortedUnitsLead()
	{
		ActiveUnit result = default(ActiveUnit);
		if (ActiveMissionOrPackage() != null)
		{
			foreach (ActiveUnit value in ActiveMissionOrPackage().UnitsAssignedToMission.Values)
			{
				bool flag = false;
				if (value.IsAircraft)
				{
					Aircraft aircraft = (Aircraft)value;
					int num;
					if (aircraft.AirOps.IsTakingOff)
					{
						num = 1;
					}
					else
					{
						if (!aircraft.Navigator.HasFlight)
						{
							goto IL_0060;
						}
						num = 1;
					}
					flag = (byte)num != 0;
				}
				goto IL_0060;
				IL_0060:
				if ((value.IsOperating() || flag) && !value.IsGroup && !value.AI.IsEscort)
				{
					if (!value.IsGroupMember())
					{
						result = value;
						return result;
					}
					result = value.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					return result;
				}
			}
		}
		return result;
	}

	private void method_10(object object_0, ObservableListModified<Sensor> observableListModified_0)
	{
		Sensors_Cached = null;
		if (IsWeapon)
		{
			((Weapon)this).Sensory.TerminalSensorMaxRange = -1f;
			((Weapon)this).CachedGuidance = null;
			((Weapon)this).DetermineGuidance();
		}
	}

	private void method_11(object object_0, object object_1)
	{
		Sensors_Cached = null;
		if (IsWeapon)
		{
			((Weapon)this).Sensory.TerminalSensorMaxRange = -1f;
			((Weapon)this).CachedGuidance = null;
			((Weapon)this).DetermineGuidance();
		}
	}

	private void method_12(object object_0, ObservableListModified<Sensor> observableListModified_0)
	{
		Sensors_Cached = null;
		if (IsWeapon)
		{
			((Weapon)this).Sensory.TerminalSensorMaxRange = -1f;
			((Weapon)this).CachedGuidance = null;
			((Weapon)this).DetermineGuidance();
		}
	}

	private void method_13(object object_0, ObservableListModified<Mount> observableListModified_0)
	{
		Sensors_Cached = null;
	}

	private void method_14(object object_0, ObservableListModified<Mount> observableListModified_0)
	{
		Sensors_Cached = null;
	}

	private void method_15(object object_0, object object_1)
	{
		Sensors_Cached = null;
	}

	internal void SetLastTransmissionTime(CommDevice commDevice, DateTime time)
	{
		CommDevice[] comms = _Comms;
		int num = 0;
		CommDevice commDevice2;
		while (true)
		{
			if (num < comms.Length)
			{
				commDevice2 = comms[num];
				if (Operators.CompareString(commDevice2.ObjectID, commDevice.ObjectID, false) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return;
		}
		commDevice2.LastTransmissionTime = time;
	}

	internal static List<GlobalVariables.TechGenerationClass> GetTechGenForYear(int Commissioned, int Decomissioned)
	{
		List<GlobalVariables.TechGenerationClass> list = new List<GlobalVariables.TechGenerationClass>();
		List<(int, int, GlobalVariables.TechGenerationClass)> list2 = new List<(int, int, GlobalVariables.TechGenerationClass)>
		{
			(1950, 1954, GlobalVariables.TechGenerationClass.const_2),
			(1955, 1959, GlobalVariables.TechGenerationClass.const_3),
			(1960, 1964, GlobalVariables.TechGenerationClass.const_4),
			(1965, 1969, GlobalVariables.TechGenerationClass.const_5),
			(1970, 1974, GlobalVariables.TechGenerationClass.const_6),
			(1975, 1979, GlobalVariables.TechGenerationClass.const_7),
			(1980, 1984, GlobalVariables.TechGenerationClass.const_8),
			(1985, 1989, GlobalVariables.TechGenerationClass.const_9),
			(1990, 1994, GlobalVariables.TechGenerationClass.const_10),
			(1995, 1999, GlobalVariables.TechGenerationClass.const_11),
			(2000, 2004, GlobalVariables.TechGenerationClass.const_12),
			(2005, 2009, GlobalVariables.TechGenerationClass.const_13),
			(2010, 2014, GlobalVariables.TechGenerationClass.const_14),
			(2015, 2019, GlobalVariables.TechGenerationClass.const_15),
			(2020, 2024, GlobalVariables.TechGenerationClass.const_16),
			(2025, 2029, GlobalVariables.TechGenerationClass.const_17)
		};
		int num = 0;
		int num2 = 0;
		num = ((Commissioned == 0) ? 1950 : Commissioned);
		num2 = ((Decomissioned != 0) ? Decomissioned : 2029);
		foreach (var item in list2)
		{
			if (num <= item.Item2 && num2 >= item.Item1)
			{
				list.Add(item.Item3);
			}
		}
		if (list.Count == 0)
		{
			list.Add(GlobalVariables.TechGenerationClass.NotApplicable);
		}
		return list;
	}

	public bool myTargetDoesNotExist()
	{
		if (AI.PrimaryTarget != null)
		{
			if (ParentScen != null)
			{
				if (AI.PrimaryTarget.ActualUnit != null && !AI.PrimaryTarget.ActualUnit.IsOperating())
				{
					return true;
				}
				if (AI.PrimaryTarget.ActualUnit != null)
				{
					if (!AI.PrimaryTarget.ActualUnit.IsMorituri)
					{
						return false;
					}
					return true;
				}
				return true;
			}
			return true;
		}
		return true;
	}
}
