using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public sealed class Group : ActiveUnit
{
	public delegate void UnitAddedEventHandler(Group theGroup, ActiveUnit theUnit);

	public delegate void UnitRemovedEventHandler(Group theGroup, ActiveUnit theUnit);

	public enum GroupType : byte
	{
		AirGroup,
		SurfaceGroup,
		SubGroup,
		Installation,
		MobileGroup,
		AirBase,
		NavalBase,
		Mixed,
		ParentGroup
	}

	public enum E_CompositionType
	{
		Homogenous_DBIDandLoadout,
		Homogenous_DBID,
		Homogenous_Type,
		Mixed
	}

	public enum Domain
	{
		None,
		Maritime,
		Air,
		Land,
		Space,
		Cyberspace
	}

	[CompilerGenerated]
	internal sealed class _Closure$__154-0
	{
		public KeyValuePair<string, CommNetwork> $VB$Local_theCC;

		public _Closure$__154-0(_Closure$__154-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theCC = arg0.$VB$Local_theCC;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theU)
		{
			return $VB$Local_theCC.Value.Members.Contains(theU);
		}

		static _Closure$__154-0()
		{
			Class72.smethod_20();
		}
	}

	private GroupType? nullable_16;

	public bool IsParentGroup;

	public GeoPoint Center;

	private ActiveUnit activeUnit_0;

	[AccessedThroughProperty("Patrols")]
	[CompilerGenerated]
	private ObservableList<Patrol> BahLnElkwbi;

	private Group_Navigator group_Navigator_0;

	private Group_AI group_AI_0;

	private Group_Kinematics group_Kinematics_0;

	private Group_Sensory group_Sensory_0;

	private Group_Weaponry group_Weaponry_0;

	private Group_CommStuff group_CommStuff_0;

	private Group_AirOps group_AirOps_0;

	[CompilerGenerated]
	[AccessedThroughProperty("Units")]
	private TObservableDictionary<string, ActiveUnit> tobservableDictionary_0;

	internal bool DeserializationInProgress;

	public string LastFormationSet;

	public float LastFormationSpacing;

	public byte LastFormationSpacingUnits;

	public bool ReservedSupply;

	public bool MembersInheritIcon;

	[CompilerGenerated]
	private static UnitAddedEventHandler unitAddedEventHandler_0;

	[CompilerGenerated]
	private static UnitRemovedEventHandler unitRemovedEventHandler_0;

	public E_CompositionType CompositionType;

	public bool IsLandInstallation;

	public virtual ObservableList<Patrol> Patrols
	{
		[CompilerGenerated]
		get
		{
			return BahLnElkwbi;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<Patrol>> value2 = method_22;
			EventHandler<ObservableListModified<Patrol>> value3 = method_23;
			ObservableList<Patrol> observableList = BahLnElkwbi;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsRemoved -= value3;
			}
			BahLnElkwbi = value;
			observableList = BahLnElkwbi;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsRemoved += value3;
			}
		}
	}

	public virtual TObservableDictionary<string, ActiveUnit> Units
	{
		[CompilerGenerated]
		get
		{
			return tobservableDictionary_0;
		}
		[CompilerGenerated]
		set
		{
			NotifyCollectionChangedEventHandler value2 = method_24;
			TObservableDictionary<string, ActiveUnit> tObservableDictionary = tobservableDictionary_0;
			if (tObservableDictionary != null)
			{
				tObservableDictionary.CollectionChanged -= value2;
			}
			tobservableDictionary_0 = value;
			tObservableDictionary = tobservableDictionary_0;
			if (tObservableDictionary != null)
			{
				tObservableDictionary.CollectionChanged += value2;
			}
		}
	}

	public override GlobalVariables.ProficiencyLevel? Proficiency
	{
		get
		{
			return base.Proficiency;
		}
		set
		{
			foreach (ActiveUnit value2 in Units.Values)
			{
				value2.Proficiency = value;
			}
		}
	}

	public override _ActiveUnitStatus Status
	{
		get
		{
			if (GroupLead == null)
			{
				return _ActiveUnitStatus.Unassigned;
			}
			if (GroupLead != null)
			{
				_Status = GroupLead.Status;
			}
			return _Status;
		}
		set
		{
			if (GroupLead != null)
			{
				GroupLead.Status = value;
				_Status = GroupLead.Status;
			}
		}
	}

	public override string SubTypeDescription => TypeDescription;

	public override double Longitude
	{
		get
		{
			if (GroupLead == null)
			{
				return base.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			return GroupLead.get_Longitude(GlobalVariables.ObjectTrue);
		}
		set
		{
			if (GroupLead != null)
			{
				GroupLead.set_Longitude((GlobalVariables.BooleanObject)null, value);
			}
			else
			{
				base.set_Longitude((GlobalVariables.BooleanObject)null, value);
			}
		}
	}

	public override double Latitude
	{
		get
		{
			if (GroupLead != null)
			{
				return GroupLead.get_Latitude(GlobalVariables.ObjectTrue);
			}
			return base.get_Latitude((GlobalVariables.BooleanObject)null);
		}
		set
		{
			if (GroupLead == null)
			{
				base.set_Latitude((GlobalVariables.BooleanObject)null, value);
			}
			else
			{
				GroupLead.set_Latitude((GlobalVariables.BooleanObject)null, value);
			}
		}
	}

	public override float CurrentAltitude
	{
		get
		{
			if (GroupLead != null)
			{
				return GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			return base.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
		set
		{
			if (GroupLead != null)
			{
				GroupLead.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
			}
			else
			{
				base.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value);
			}
		}
	}

	public override float CurrentAltitude_AGL
	{
		get
		{
			if (GroupLead != null)
			{
				return GroupLead.CurrentAltitude_AGL;
			}
			return base.CurrentAltitude_AGL;
		}
	}

	public override Side UnitSide
	{
		get
		{
			if (Units != null)
			{
				if (_UnitSide == null && Units.Count > 0)
				{
					_UnitSide = Units.Values.ElementAtOrDefault(0).get_UnitSide(SetSideOnly: false);
				}
				return _UnitSide;
			}
			return null;
		}
		set
		{
			bool num = value != _UnitSide;
			base.set_UnitSide(SetSideOnly, value);
			if (!num || value == null)
			{
				return;
			}
			List<ActiveUnit> list = Units.Values.ToList();
			foreach (ActiveUnit item in list)
			{
				item.set_UnitSide(SetSideOnly, value);
			}
		}
	}

	public override float CurrentHeading
	{
		get
		{
			if (GroupLead != null)
			{
				return GroupLead.CurrentHeading;
			}
			return base.CurrentHeading;
		}
		set
		{
			if (GroupLead != null)
			{
				GroupLead.CurrentHeading = value;
			}
			else
			{
				base.CurrentHeading = value;
			}
		}
	}

	public override float CurrentSpeed
	{
		get
		{
			if (GroupLead != null)
			{
				return GroupLead.CurrentSpeed;
			}
			return base.CurrentSpeed;
		}
		set
		{
			if (GroupLead == null)
			{
				base.CurrentSpeed = value;
			}
			else
			{
				GroupLead.CurrentSpeed = value;
			}
		}
	}

	public GroupType Type
	{
		get
		{
			if (!nullable_16.HasValue)
			{
				nullable_16 = method_18();
				if (!nullable_16.HasValue)
				{
					return GroupType.SurfaceGroup;
				}
				return nullable_16.Value;
			}
			return nullable_16.Value;
		}
	}

	public string TypeDescription
	{
		get
		{
			switch (Type)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return Type.ToString();
			case GroupType.AirGroup:
				return "Air Group";
			case GroupType.SurfaceGroup:
				return "Surface Group";
			case GroupType.SubGroup:
				return "Underwater Group";
			case GroupType.Installation:
				return "Land Installation";
			case GroupType.MobileGroup:
				return "Mobile Group";
			case GroupType.AirBase:
				return "Airfield";
			case GroupType.NavalBase:
				return "Naval Base";
			case GroupType.Mixed:
				return "Mixed";
			case GroupType.ParentGroup:
				return "Parent Group";
			}
		}
	}

	public override Mission AssignedTaskPool
	{
		get
		{
			if (GroupLead == null)
			{
				return null;
			}
			return GroupLead.AssignedTaskPool;
		}
		set
		{
			foreach (ActiveUnit value2 in Units.Values)
			{
				value2.AssignedTaskPool = value;
			}
		}
	}

	public override ActiveUnit_Navigator Navigator => group_Navigator_0;

	public override ActiveUnit_AI AI => group_AI_0;

	public new Group_Kinematics Kinematics => group_Kinematics_0;

	public override ActiveUnit_Sensory Sensory => group_Sensory_0;

	public override ActiveUnit_Weaponry Weaponry => group_Weaponry_0;

	public override ActiveUnit_CommStuff CommStuff => group_CommStuff_0;

	public override ActiveUnit_AirOps AirOps => group_AirOps_0;

	public new ActiveUnit_Damage Damage
	{
		get
		{
			if (_Damage == null)
			{
				ActiveUnit theUnit = this;
				_Damage = new ActiveUnit_Damage(ref theUnit);
			}
			return _Damage;
		}
	}

	public ActiveUnit GroupLead
	{
		get
		{
			if (activeUnit_0 == null)
			{
				DesignateGroupLead_Auto();
			}
			return activeUnit_0;
		}
	}

	public override float DesiredHeading
	{
		get
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				return GroupLead.DesiredHeading;
			}
			return 0f;
		}
	}

	public override float DesiredHeading
	{
		set
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				GroupLead.set_DesiredHeading(theTurnRate, value);
			}
		}
	}

	public override float DesiredAltitude
	{
		get
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				return GroupLead.DesiredAltitude;
			}
			return 0f;
		}
		set
		{
			try
			{
				if (GroupLead == null)
				{
					DesignateGroupLead_Auto();
				}
				if (GroupLead != null)
				{
					GroupLead.DesiredAltitude = value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100591", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override float DesiredAltitude_AGL
	{
		get
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead == null)
			{
				return 0f;
			}
			return GroupLead.DesiredAltitude_AGL;
		}
		set
		{
			try
			{
				if (GroupLead == null)
				{
					DesignateGroupLead_Auto();
				}
				if (GroupLead != null)
				{
					GroupLead.DesiredAltitude_AGL = value;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101257", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public override bool DesiredAltitude_UseTerrainFollowing
	{
		get
		{
			if (Type == GroupType.AirGroup && GroupLead != null)
			{
				return GroupLead.get_DesiredAltitude_UseTerrainFollowing(GroupLead);
			}
			return false;
		}
		set
		{
			if (Type == GroupType.AirGroup && GroupLead != null)
			{
				GroupLead.set_DesiredAltitude_UseTerrainFollowing(GroupLead, value);
			}
		}
	}

	public override float DesiredSpeed
	{
		get
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				return GroupLead.DesiredSpeed;
			}
			return 0f;
		}
		set
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				GroupLead.DesiredSpeed = value;
			}
		}
	}

	public override TurnRate DesiredTurnRate
	{
		get
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				return GroupLead.DesiredTurnRate;
			}
			return TurnRate.Max;
		}
		set
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				GroupLead.DesiredTurnRate = value;
			}
		}
	}

	public override Waypoint.TurnRateCategory DesiredTurnRate_Navigation
	{
		get
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				return GroupLead.DesiredTurnRate_Navigation;
			}
			return Waypoint.TurnRateCategory.StandardRateTurn;
		}
		set
		{
			if (GroupLead == null)
			{
				DesignateGroupLead_Auto();
			}
			if (GroupLead != null)
			{
				GroupLead.DesiredTurnRate_Navigation = value;
			}
		}
	}

	public override AirFacility[] AirFacilities_ReadOnly
	{
		get
		{
			PooledList<AirFacility> pooledList = new PooledList<AirFacility>();
			AirFacility[] result;
			try
			{
				IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = Units.GetEnumerator();
				while (enumerator.MoveNext())
				{
					AirFacility[] airFacilities_ReadOnly = enumerator.Current.Value.AirFacilities_ReadOnly;
					foreach (AirFacility item in airFacilities_ReadOnly)
					{
						pooledList.Add(item);
					}
				}
				result = pooledList.ToArray();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100592", "");
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
				result = new AirFacility[num];
				ProjectData.ClearProjectError();
			}
			finally
			{
				pooledList.Dispose();
			}
			return result;
		}
	}

	public override DockFacility[] DockFacilities_ReadOnly
	{
		get
		{
			PooledList<DockFacility> pooledList = new PooledList<DockFacility>();
			DockFacility[] result;
			try
			{
				foreach (ActiveUnit value in Units.Values)
				{
					DockFacility[] dockFacilities_ReadOnly = value.DockFacilities_ReadOnly;
					foreach (DockFacility item in dockFacilities_ReadOnly)
					{
						pooledList.Add(item);
					}
				}
				result = pooledList.ToArray();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100593", "");
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
				result = new DockFacility[num];
				ProjectData.ClearProjectError();
			}
			finally
			{
				pooledList.Dispose();
			}
			return result;
		}
	}

	public override Magazine[] SharedMagazines
	{
		get
		{
			Magazine[] result;
			try
			{
				GroupType type = Type;
				if (type != GroupType.Installation && type - 5 > GroupType.SurfaceGroup)
				{
					result = null;
				}
				else
				{
					List<Magazine> list = new List<Magazine>();
					foreach (Platform value in Units.Values)
					{
						Magazine[] magazines = value.Magazines;
						foreach (Magazine item in magazines)
						{
							list.Add(item);
						}
					}
					result = list.ToArray();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100594", "");
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
	}

	public override Sensor[] Sensors_Cached
	{
		get
		{
			return Sensors_ReadOnly();
		}
		set
		{
		}
	}

	public override Throttle ThrottleSetting
	{
		get
		{
			if (Type == GroupType.AirGroup)
			{
				if (base.ThrottleSetting == Throttle.FullStop)
				{
					SetThrottle(Throttle.Cruise);
				}
				return base.ThrottleSetting;
			}
			return base.ThrottleSetting;
		}
		set
		{
			base.ThrottleSetting = value;
		}
	}

	public bool IsFormingUp
	{
		get
		{
			bool result;
			try
			{
				bool flag = default(bool);
				if (Type != GroupType.AirBase || Type == GroupType.Installation)
				{
					if (Type == GroupType.SurfaceGroup || Type == GroupType.MobileGroup)
					{
						foreach (ActiveUnit value in Units.Values)
						{
							if (!value.IsAircraft && !value.IsOperating())
							{
								flag = true;
								break;
							}
						}
					}
					if (Type == GroupType.AirGroup)
					{
						List<ActiveUnit> list = new List<ActiveUnit>(Units.Values);
						foreach (ActiveUnit item in list)
						{
							if (item != null && !item.IsOperating())
							{
								flag = true;
								break;
							}
						}
					}
				}
				result = flag;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100599", "");
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
	}

	public override bool UseAerialUnitUI
	{
		get
		{
			int result;
			if (nullable_16.HasValue)
			{
				if (nullable_16.Value == GroupType.AirGroup)
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

	public override bool UseSubmerisbleUnitUI
	{
		get
		{
			if (nullable_16.HasValue && nullable_16.Value == GroupType.SubGroup)
			{
				return true;
			}
			return false;
		}
	}

	public override bool SupportsAltitude_Control
	{
		get
		{
			if (nullable_16.HasValue)
			{
				return nullable_16.Value == GroupType.AirGroup || nullable_16.Value == GroupType.SubGroup;
			}
			return false;
		}
	}

	public override Throttle MaxPossibleThrottleSetting
	{
		get
		{
			if (GroupLead != null)
			{
				return GroupLead.Kinematics.GetThrottleSuitableForThisSpeed(GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), GetMaximumCohesiveSpeed(Throttle.MaxPossibleThrottle, GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), EvaluateDamages: true));
			}
			return Throttle.FullStop;
		}
	}

	public override Throttle MinPossibleThrottleSetting
	{
		get
		{
			if (GroupLead == null)
			{
				return Throttle.FullStop;
			}
			return GroupLead.Kinematics.GetThrottleSuitableForThisSpeed(GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), GetMinimumCohesiveSpeed(Throttle.MinPossibleThrottle, GroupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
		}
	}

	public static event UnitAddedEventHandler UnitAdded
	{
		[CompilerGenerated]
		add
		{
			UnitAddedEventHandler unitAddedEventHandler = unitAddedEventHandler_0;
			UnitAddedEventHandler unitAddedEventHandler2;
			do
			{
				unitAddedEventHandler2 = unitAddedEventHandler;
				UnitAddedEventHandler value2 = (UnitAddedEventHandler)Delegate.Combine(unitAddedEventHandler2, value);
				unitAddedEventHandler = Interlocked.CompareExchange(ref unitAddedEventHandler_0, value2, unitAddedEventHandler2);
			}
			while ((object)unitAddedEventHandler != unitAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitAddedEventHandler unitAddedEventHandler = unitAddedEventHandler_0;
			UnitAddedEventHandler unitAddedEventHandler2;
			do
			{
				unitAddedEventHandler2 = unitAddedEventHandler;
				UnitAddedEventHandler value2 = (UnitAddedEventHandler)Delegate.Remove(unitAddedEventHandler2, value);
				unitAddedEventHandler = Interlocked.CompareExchange(ref unitAddedEventHandler_0, value2, unitAddedEventHandler2);
			}
			while ((object)unitAddedEventHandler != unitAddedEventHandler2);
		}
	}

	public static event UnitRemovedEventHandler UnitRemoved
	{
		[CompilerGenerated]
		add
		{
			UnitRemovedEventHandler unitRemovedEventHandler = unitRemovedEventHandler_0;
			UnitRemovedEventHandler unitRemovedEventHandler2;
			do
			{
				unitRemovedEventHandler2 = unitRemovedEventHandler;
				UnitRemovedEventHandler value2 = (UnitRemovedEventHandler)Delegate.Combine(unitRemovedEventHandler2, value);
				unitRemovedEventHandler = Interlocked.CompareExchange(ref unitRemovedEventHandler_0, value2, unitRemovedEventHandler2);
			}
			while ((object)unitRemovedEventHandler != unitRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UnitRemovedEventHandler unitRemovedEventHandler = unitRemovedEventHandler_0;
			UnitRemovedEventHandler unitRemovedEventHandler2;
			do
			{
				unitRemovedEventHandler2 = unitRemovedEventHandler;
				UnitRemovedEventHandler value2 = (UnitRemovedEventHandler)Delegate.Remove(unitRemovedEventHandler2, value);
				unitRemovedEventHandler = Interlocked.CompareExchange(ref unitRemovedEventHandler_0, value2, unitRemovedEventHandler2);
			}
			while ((object)unitRemovedEventHandler != unitRemovedEventHandler2);
		}
	}

	public override void PrePulseHousekeeping(float elapsedTime, Scenario theScen)
	{
		base.PrePulseHousekeeping(elapsedTime, theScen);
		_IsPerformingStandoffAttack = false;
		IEnumerator<KeyValuePair<string, ActiveUnit>> enumerator = Units.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ActiveUnit value = enumerator.Current.Value;
			if (value != null && value.IsAircraft && value.IsPerformingStandoffAttack)
			{
				_IsPerformingStandoffAttack = true;
			}
		}
	}

	internal bool CanHostCargo()
	{
		foreach (ActiveUnit value in Units.Values)
		{
			if (value is ICargoHost)
			{
				return true;
			}
		}
		return false;
	}

	public override List<ActiveUnit> GetHostedUnitsThatCanBeLoadedAsCargo()
	{
		List<ActiveUnit> list = new List<ActiveUnit>();
		foreach (ActiveUnit value in Units.Values)
		{
			if (value is ICargoHost && value.IsFixedFacility)
			{
				list.AddRange(value.GetHostedUnitsThatCanBeLoadedAsCargo());
			}
		}
		return list;
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		nullable_16 = null;
		activeUnit_0 = null;
		Patrols.Clear();
		LastFormationSet = "";
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Group");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				if (GroupLead != null)
				{
					theWriter.WriteStartElement("GroupLead");
					GroupLead.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
					theWriter.WriteEndElement();
					_Status = GroupLead.Status;
				}
				method_2(ref theWriter);
				theWriter.WriteElementString("Name", Name);
				if (!Information.IsNothing((object)nullable_16))
				{
					theWriter.WriteElementString("Type", ((int)nullable_16.Value).ToString());
				}
				theWriter.WriteElementString("CurrentHeading", XmlConvert.ToString(CurrentHeading));
				theWriter.WriteElementString("CurrentSpeed", XmlConvert.ToString(CurrentSpeed));
				theWriter.WriteElementString("CurrentAltitude", XmlConvert.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("Longitude", XmlConvert.ToString(this.get_Longitude((GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("Latitude", XmlConvert.ToString(this.get_Latitude((GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("UnitClass", UnitClass);
				theWriter.WriteElementString("Side", this.get_UnitSide(SetSideOnly: false).Name);
				theWriter.WriteElementString("Message", Message);
				if (Longitude__UnitEntersAreaCheck.HasValue)
				{
					theWriter.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
				}
				if (Latitude__UnitEntersAreaCheck.HasValue)
				{
					theWriter.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
				}
				if (ActiveEnterAreaTriggers.Count > 0)
				{
					theWriter.WriteStartElement("ActiveEnterAreaTriggers");
					foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
					{
						theWriter.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
					}
					theWriter.WriteEndElement();
				}
				if (ActiveRemainAreaTriggers.Count > 0)
				{
					theWriter.WriteStartElement("ActiveRemainAreaTriggers");
					foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
					{
						theWriter.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
						theWriter.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteElementString("DBID", DBID.ToString());
				theWriter.WriteElementString("DesiredHeading", XmlConvert.ToString(this.DesiredHeading));
				theWriter.WriteElementString("DesiredSpeed", XmlConvert.ToString(DesiredSpeed));
				theWriter.WriteElementString("DesiredAltitude", XmlConvert.ToString(DesiredAltitude));
				theWriter.WriteElementString("DesiredTurnRate", ((byte)DesiredTurnRate).ToString());
				theWriter.WriteElementString("DesiredTurnRate_Navigation", ((byte)DesiredTurnRate_Navigation).ToString());
				theWriter.WriteElementString("Weight", XmlConvert.ToString(EmptyWeight));
				theWriter.WriteElementString("ThrottleSetting", ((byte)ThrottleSetting).ToString());
				Doctrine.ToXML(ref theWriter, ref ParentScen);
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
				theWriter.WriteStartElement("Mounts");
				foreach (Mount mount in Mounts)
				{
					if (Information.IsNothing((object)mount.ParentPlatform))
					{
						mount.ParentPlatform = this;
					}
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
				XmlWriter obj10 = theWriter;
				status = (byte)_ThrottleBefore_WaitForPathfinder;
				obj10.WriteElementString("SBPF_ThrottleSetting", status.ToString());
				theWriter.WriteElementString("AMP_OC", _MissionPlannerOverrideCancellation.ToString());
				if (!Information.IsNothing((object)_MissionPlannerOverrideCancellation_DesiredSpeedOverride))
				{
					theWriter.WriteElementString("AMP_OC_DSO", _MissionPlannerOverrideCancellation_DesiredSpeedOverride.ToString());
				}
				theWriter.WriteElementString("AMP_OC_DAO", _MissionPlannerOverrideCancellation_DesiredAltitudeOverride.ToString());
				theWriter.WriteElementString("AMP_OC_Speed", XmlConvert.ToString(_MissionPlannerOverrideCancellation_Speed));
				theWriter.WriteElementString("DamagePts", XmlConvert.ToString(((ActiveUnit)this).get_DamagePts(ScenEditAction: false, (Weapon)null)));
				theWriter.WriteElementString("ReservedSupply", XmlConvert.ToString(ReservedSupply));
				theWriter.WriteElementString("MembersInheritIcon", XmlConvert.ToString(MembersInheritIcon));
				theWriter.WriteStartElement("AirFacilities");
				AirFacility[] airFacilities = _AirFacilities;
				foreach (AirFacility airFacility in airFacilities)
				{
					theWriter.WriteRaw(airFacility.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
				Navigator.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteStartElement("Group_AI");
				AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
				theWriter.WriteStartElement("Group_Kinematics");
				Kinematics.ToXML(ref theWriter);
				theWriter.WriteEndElement();
				Sensory.ToXML(ref theWriter);
				Weaponry.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteStartElement("Group_CommStuff");
				CommStuff.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteEndElement();
				AirOps.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				theWriter.WriteElementString("Type", ((int)Type).ToString());
				theWriter.WriteStartElement("Center");
				theWriter.WriteRaw(Center.ToXML(ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
				theWriter.WriteStartElement("Patrols");
				foreach (Patrol patrol in Patrols)
				{
					patrol.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref ParentScen);
				}
				theWriter.WriteEndElement();
				if (!string.IsNullOrEmpty(LastFormationSet))
				{
					theWriter.WriteElementString("LastFormationSet", LastFormationSet);
					theWriter.WriteElementString("LastFormationSpacing", XmlConvert.ToString(LastFormationSpacing));
					theWriter.WriteElementString("LastFormationSpacingUnits", XmlConvert.ToString(LastFormationSpacingUnits));
				}
				theWriter.WriteEndElement();
			}
			else
			{
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100589", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Group(Scenario Scen)
		: base(Scen)
	{
		IsParentGroup = false;
		Center = new GeoPoint();
		Patrols = new ObservableList<Patrol>();
		ActiveUnit theUnit = this;
		group_Navigator_0 = new Group_Navigator(ref theUnit);
		theUnit = this;
		group_AI_0 = new Group_AI(ref theUnit);
		theUnit = this;
		group_Kinematics_0 = new Group_Kinematics(ref theUnit);
		theUnit = this;
		group_Sensory_0 = new Group_Sensory(ref theUnit);
		theUnit = this;
		group_Weaponry_0 = new Group_Weaponry(ref theUnit);
		theUnit = this;
		group_CommStuff_0 = new Group_CommStuff(ref theUnit);
		theUnit = this;
		group_AirOps_0 = new Group_AirOps(ref theUnit);
		Units = new TObservableDictionary<string, ActiveUnit>();
		ReservedSupply = false;
		MembersInheritIcon = false;
		CompositionType = E_CompositionType.Mixed;
		IsGroup = true;
	}

	public static Group FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Group existingObject = null)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_0fd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Expected O, but got Unknown
		//IL_0e56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5d: Expected O, but got Unknown
		//IL_0a78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Expected O, but got Unknown
		//IL_0985: Unknown result type (might be due to invalid IL or missing references)
		//IL_098c: Expected O, but got Unknown
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1075: Unknown result type (might be due to invalid IL or missing references)
		//IL_107c: Expected O, but got Unknown
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Expected O, but got Unknown
		Group result3;
		try
		{
			bool flag;
			Group obj;
			if (!(flag = existingObject != null))
			{
				obj = new Group(theScen);
			}
			else
			{
				obj = existingObject;
				obj.Reinitialize();
			}
			obj.ParentScen = theScen;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(innerText, ' '))
			{
				innerText = innerText.Replace(" ", "-");
			}
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				obj.CommonFromXML(theNode2);
				string innerText2 = theNode2.InnerText;
				switch (theNode2.Name)
				{
				case "LastFormationSet":
					obj.LastFormationSet = innerText2;
					break;
				case "Group_Kinematics":
				{
					Group obj8 = obj;
					ActiveUnit theAU = obj;
					obj8.group_Kinematics_0 = Group_Kinematics.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "Status":
					if (Versioned.IsNumeric((object)innerText2))
					{
						obj.Status = (_ActiveUnitStatus)Conversions.ToByte(innerText2);
					}
					else
					{
						obj.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), innerText2, ignoreCase: true);
					}
					break;
				case "CurrentAltitude":
					obj.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(innerText2.Replace(",", ".")));
					break;
				case "DesiredTurnRate_Navigation":
					obj.DesiredTurnRate_Navigation = (Waypoint.TurnRateCategory)Conversions.ToByte(innerText2);
					break;
				case "Name":
					obj.Name = innerText2;
					break;
				case "DesiredHeading":
					obj._DesiredHeading = XmlConvert.ToSingle(innerText2);
					break;
				case "DamagePts":
					((ActiveUnit)obj).set_DamagePts(ScenEditAction: false, (Weapon)null, XmlConvert.ToSingle(innerText2));
					break;
				case "FuelState":
					obj._FuelState = (_ActiveUnitFuelState)Conversions.ToByte(innerText2);
					break;
				case "Center":
				{
					Group obj10 = obj;
					XmlNode theNode5 = theNode2.ChildNodes[0];
					obj10.Center = GeoPoint.FromXML(ref theNode5, ref theDictionary);
					break;
				}
				case "ThrottleSetting":
					switch (innerText2)
					{
					case "Loiter":
						obj.ThrottleSetting = Throttle.Loiter;
						break;
					case "Full":
						obj.ThrottleSetting = Throttle.Full;
						break;
					default:
						obj.ThrottleSetting = (Throttle)Conversions.ToByte(innerText2);
						break;
					case "Flank":
						obj.ThrottleSetting = Throttle.Flank;
						break;
					case "Cruise":
						obj.ThrottleSetting = Throttle.Cruise;
						break;
					case "FullStop":
						obj.ThrottleSetting = Throttle.FullStop;
						break;
					}
					break;
				case "LastFormationSpacing":
					obj.LastFormationSpacing = XmlConvert.ToSingle(innerText2);
					break;
				case "Doctrine":
					if (!flag)
					{
						obj.Doctrine = Doctrine.FromXML(theScen, ref theNode2, obj);
					}
					else
					{
						obj.Doctrine = Doctrine.FromXML(theScen, ref theNode2, obj, obj.Doctrine);
					}
					break;
				case "ActiveEnterAreaTriggers":
					if (flag)
					{
						obj.ActiveEnterAreaTriggers.Clear();
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						string innerText3 = childNode2.InnerText;
						obj.ActiveEnterAreaTriggers.Add(innerText3);
					}
					break;
				case "OnboardCargo":
					if (flag)
					{
						ArrayExtensions.Clear(ref obj.OnboardCargo);
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode6 = childNode3;
						Cargo cargo = Cargo.FromXML(ref theNode6, ref theDictionary, theScen, obj);
						ArrayExtensions.Add(ref obj.OnboardCargo, cargo);
						cargo.ParentPlatform = obj;
					}
					break;
				case "Longitude":
					obj.set_Longitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(innerText2.Replace(",", ".")));
					break;
				case "WeaponState":
					obj._WeaponState = (_ActiveUnitWeaponState)Conversions.ToSByte(innerText2);
					break;
				case "ID":
				{
					if (!theDictionary.TryGetValue(innerText2, out var value))
					{
						obj.ObjectID_Set(innerText2);
						if (theNode.ChildNodes.Count != 1)
						{
							theDictionary.TryAdd(obj.ObjectID, obj);
							break;
						}
						theScen.UnitsForLateInstantiation.Add(theNode);
						result3 = obj;
					}
					else
					{
						result3 = (Group)value;
					}
					goto end_IL_0001;
				}
				case "Group_AirOps":
				{
					Group obj9 = obj;
					ActiveUnit theAU = obj;
					obj9.group_AirOps_0 = Group_AirOps.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "UnitClass":
					obj.UnitClass = innerText2;
					break;
				case "Latitude":
					obj.set_Latitude((GlobalVariables.BooleanObject)null, XmlConvert.ToDouble(innerText2.Replace(",", ".")));
					break;
				case "DesiredAltitude":
					obj._DesiredAltitude = XmlConvert.ToSingle(innerText2);
					break;
				case "Comms":
					if (flag)
					{
						ArrayExtensions.Clear(ref obj._Comms);
					}
					foreach (XmlNode childNode4 in theNode2.ChildNodes)
					{
						XmlNode theNode9 = childNode4;
						CommDevice commDevice = CommDevice.FromXML(ref theNode9, ref theDictionary, obj);
						obj.AddCommDevice(commDevice);
						commDevice.ParentPlatform = obj;
					}
					break;
				case "Latitude_UnitEntersAreaCheck":
					obj.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(innerText2);
					break;
				case "Propulsion":
					if (flag)
					{
						obj.Propulsion.Clear();
					}
					foreach (XmlNode childNode5 in theNode2.ChildNodes)
					{
						XmlNode theNode8 = childNode5;
						ActiveUnit theAU = obj;
						Engine engine = Engine.FromXML(ref theNode8, ref theDictionary, ref theAU);
						obj.Propulsion.Add(engine);
						engine.ParentPlatform = obj;
					}
					break;
				case "DBID":
					obj.DBID = Conversions.ToInteger(innerText2);
					break;
				case "LastFormationSpacingUnits":
					obj.LastFormationSpacingUnits = XmlConvert.ToByte(innerText2);
					break;
				case "ActiveRemainAreaTriggers":
				{
					string key = null;
					DateTime result = DateTime.MinValue;
					foreach (XmlNode childNode6 in theNode2.ChildNodes)
					{
						XmlNode val = childNode6;
						if (Operators.CompareString(val.Name, "RemainAreaTrigger", false) == 0)
						{
							key = val.InnerText;
							result = DateTime.MinValue;
						}
						else if (!DateTime.TryParse(val.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
						{
							string innerText4 = val.InnerText;
							long result2 = default(long);
							if (long.TryParse(innerText4, out result2))
							{
								result = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
								obj.ActiveRemainAreaTriggers.Add(key, result);
							}
						}
						else
						{
							obj.ActiveRemainAreaTriggers.Add(key, result);
						}
					}
					break;
				}
				case "Sensors":
					if (flag)
					{
						obj._Sensors.Clear();
					}
					foreach (XmlNode childNode7 in theNode2.ChildNodes)
					{
						Sensor sensor = Sensor.FromXML(childNode7, theDictionary, obj);
						obj._Sensors.Add(sensor);
						sensor.ParentPlatform = obj;
					}
					break;
				case "Sensory":
				{
					Group obj7 = obj;
					ActiveUnit theAU = obj;
					obj7.group_Sensory_0 = Group_Sensory.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "Group_CommStuff":
				{
					Group obj6 = obj;
					ActiveUnit theAU = obj;
					obj6.group_CommStuff_0 = Group_CommStuff.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "Side":
				{
					obj._SideName = innerText2;
					Side[] sides_ReadOnly = theScen.Sides_ReadOnly;
					foreach (Side side in sides_ReadOnly)
					{
						if (Operators.CompareString(side.Name, obj._SideName, false) == 0)
						{
							obj.set_UnitSide(SetSideOnly: false, side);
						}
					}
					break;
				}
				case "Weight":
					obj.EmptyWeight = XmlConvert.ToInt32(innerText2);
					break;
				case "ReservedSupply":
					obj.ReservedSupply = Convert.ToBoolean(innerText2);
					break;
				case "Message":
					obj.Message = innerText2;
					break;
				case "DesiredSpeed":
					obj._DesiredSpeed = XmlConvert.ToSingle(innerText2);
					break;
				case "DesiredTurnRate":
					obj.DesiredTurnRate = (TurnRate)Conversions.ToByte(innerText2);
					break;
				case "Group_Navigator":
				{
					Group obj5 = obj;
					ActiveUnit theAU = obj;
					obj5.group_Navigator_0 = Group_Navigator.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "CurrentSpeed":
					obj.CurrentSpeed = XmlConvert.ToSingle(innerText2.Replace(",", "."));
					break;
				case "Group_Weaponry":
				{
					Group obj4 = obj;
					ActiveUnit theAU = obj;
					obj4.group_Weaponry_0 = Group_Weaponry.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "Type":
					obj.nullable_16 = (GroupType)Conversions.ToByte(innerText2);
					break;
				case "Group_AI":
				{
					Group obj3 = obj;
					ActiveUnit theAU = obj;
					obj3.group_AI_0 = Group_AI.FromXML(ref theNode2, ref theDictionary, ref theAU);
					break;
				}
				case "Longitude_UnitEntersAreaCheck":
					obj.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(innerText2);
					break;
				case "Mounts":
					if (flag)
					{
						obj.Mounts.Clear();
					}
					foreach (XmlNode childNode8 in theNode2.ChildNodes)
					{
						XmlNode theNode7 = childNode8;
						Mount mount = Mount.FromXML(ref theNode7, ref theDictionary, obj);
						obj.Mounts.Add(mount);
						mount.ParentPlatform = obj;
					}
					break;
				case "MembersInheritIcon":
					obj.MembersInheritIcon = Convert.ToBoolean(innerText2);
					break;
				case "GroupLead":
				{
					if (!theNode2.HasChildNodes)
					{
						break;
					}
					Group obj2 = obj;
					XmlNode theNode5 = theNode2.ChildNodes[0];
					obj2.activeUnit_0 = ActiveUnit.FromXML(ref theNode5, ref theDictionary, ref theScen);
					if (obj.activeUnit_0 == null)
					{
						break;
					}
					lock (theScen.ActiveUnitsSyncLock)
					{
						if (!theScen.ActiveUnits.ContainsKey(obj.activeUnit_0.ObjectID))
						{
							theScen.ActiveUnits.TryAdd(obj.activeUnit_0.ObjectID, obj.activeUnit_0);
						}
					}
					break;
				}
				case "AirFacilities":
					if (flag)
					{
						ArrayExtensions.Clear(ref obj._AirFacilities);
					}
					foreach (XmlNode childNode9 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode9;
						AirFacility airFacility = AirFacility.FromXML(ref theNode4, ref theDictionary, ref theScen);
						obj.AddAirFacility(airFacility);
						airFacility.ParentPlatform = obj;
					}
					break;
				case "Patrols":
					if (flag)
					{
						obj.Patrols.Clear();
					}
					foreach (XmlNode childNode10 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode10;
						Patrol item = Patrol.FromXML(ref theNode3, ref theDictionary, ref theScen);
						obj.Patrols.Add(item);
					}
					break;
				case "CurrentHeading":
					obj.CurrentHeading = XmlConvert.ToSingle(innerText2.Replace(",", "."));
					break;
				}
			}
			if (obj.Type == GroupType.AirGroup && obj.ThrottleSetting == Throttle.FullStop)
			{
				obj.ThrottleSetting = Throttle.Cruise;
			}
			result3 = obj;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100590", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result3 = new Group(theScen);
			ProjectData.ClearProjectError();
		}
		return result3;
	}

	[SpecialName]
	private bool method_16()
	{
		List<ActiveUnit> list = new List<ActiveUnit>(Units.Values);
		foreach (ActiveUnit item in list)
		{
			if (item?.AirFacilities_ReadOnly == null)
			{
				continue;
			}
			AirFacility[] airFacilities_ReadOnly = item.AirFacilities_ReadOnly;
			for (int i = 0; i < airFacilities_ReadOnly.Length; i = checked(i + 1))
			{
				if (airFacilities_ReadOnly[i].AirFacType == AirFacility._AirFacType.Runway && item.IsFixedFacility)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	private bool method_17()
	{
		foreach (ActiveUnit value in Units.Values)
		{
			if (value?.DockFacilities_ReadOnly != null && value.IsFixedFacility && value.DockFacilities_ReadOnly.Length > 0)
			{
				return true;
			}
		}
		return false;
	}

	public override Mission ActiveMissionOrPackage()
	{
		if (GroupLead != null)
		{
			return GroupLead.ActiveMissionOrPackage();
		}
		return null;
	}

	public override void Set_AssignedMissionOrPackage(Mission value, bool SetMissionOnly, bool IgnoreCommsState, [Optional][DefaultParameterValue(0)] ref Mission.MissionAssignmentAttemptResult Result)
	{
		foreach (ActiveUnit value2 in Units.Values)
		{
			Mission.MissionAssignmentAttemptResult Result2 = Mission.MissionAssignmentAttemptResult.None;
			value2.Set_AssignedMissionOrPackage(value, SetMissionOnly, IgnoreCommsState, ref Result2);
		}
		if (GroupLead != null && GroupLead.ActiveMissionOrPackage() == value)
		{
			Result = Mission.MissionAssignmentAttemptResult.Success;
		}
		else
		{
			Result = Mission.MissionAssignmentAttemptResult.Fail_Other;
		}
	}

	public override Sensor[] Sensors_ReadOnly()
	{
		Sensor[] array = Array.Empty<Sensor>();
		PooledList<ActiveUnit> pooledList = default(PooledList<ActiveUnit>);
		PooledList<Sensor> pooledList2 = default(PooledList<Sensor>);
		Sensor[] result;
		try
		{
			pooledList = new PooledList<ActiveUnit>(Units.Values, Pools<ActiveUnit>.Local);
			pooledList2 = new PooledList<Sensor>(Pools<Sensor>.Local);
			foreach (ActiveUnit item in pooledList)
			{
				if (item != null)
				{
					Sensor[] sensors_Cached = item.Sensors_Cached;
					if (sensors_Cached != null)
					{
						pooledList2.AddRange(sensors_Cached);
					}
				}
			}
			result = pooledList2.ToArray();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100595", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = array;
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
			pooledList2?.Dispose();
		}
		return result;
	}

	private GroupType method_18()
	{
		GroupType result;
		try
		{
			if (IsParentGroup)
			{
				result = GroupType.ParentGroup;
			}
			else if (Units != null)
			{
				if (Units.Count != 0)
				{
					List<ActiveUnit> list;
					lock (Units)
					{
						list = new List<ActiveUnit>(Units.Values);
					}
					if (CompositionType == E_CompositionType.Mixed)
					{
						result = GroupType.Mixed;
					}
					else if (IsLandInstallation && method_17())
					{
						result = GroupType.NavalBase;
					}
					else if (!method_16())
					{
						if (!IsLandInstallation)
						{
							int num = list.Count - 1;
							while (true)
							{
								if (num >= 0)
								{
									ActiveUnit activeUnit = list[num];
									if (activeUnit == null || !activeUnit.IsShip)
									{
										num += -1;
										continue;
									}
									result = GroupType.SurfaceGroup;
									break;
								}
								int num2 = list.Count - 1;
								while (true)
								{
									if (num2 >= 0)
									{
										ActiveUnit activeUnit = list[num2];
										if (activeUnit == null || !activeUnit.IsSubmarine)
										{
											num2 += -1;
											continue;
										}
										result = GroupType.SubGroup;
										break;
									}
									int num3 = list.Count - 1;
									while (true)
									{
										if (num3 >= 0)
										{
											ActiveUnit activeUnit = list[num3];
											if (activeUnit == null || !activeUnit.IsAircraft)
											{
												num3 += -1;
												continue;
											}
											result = GroupType.AirGroup;
											break;
										}
										result = GroupType.MobileGroup;
										break;
									}
									break;
								}
								break;
							}
						}
						else
						{
							result = GroupType.Installation;
						}
					}
					else
					{
						result = GroupType.AirBase;
					}
				}
				else
				{
					result = GroupType.AirGroup;
				}
			}
			else
			{
				result = GroupType.AirGroup;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100596", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 1;
			}
			else
			{
				num4 = 1;
			}
			result = (GroupType)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Group(ref Scenario theScen, ref Side theSide, List<ActiveUnit> SelectedUnits, bool UsingMissionPlanner = false, string theGUID = null, Mission theMission = null)
		: base(theScen, theGUID)
	{
		IsParentGroup = false;
		Center = new GeoPoint();
		Patrols = new ObservableList<Patrol>();
		ActiveUnit theUnit = this;
		group_Navigator_0 = new Group_Navigator(ref theUnit);
		theUnit = this;
		group_AI_0 = new Group_AI(ref theUnit);
		theUnit = this;
		group_Kinematics_0 = new Group_Kinematics(ref theUnit);
		theUnit = this;
		group_Sensory_0 = new Group_Sensory(ref theUnit);
		theUnit = this;
		group_Weaponry_0 = new Group_Weaponry(ref theUnit);
		theUnit = this;
		group_CommStuff_0 = new Group_CommStuff(ref theUnit);
		theUnit = this;
		group_AirOps_0 = new Group_AirOps(ref theUnit);
		Units = new TObservableDictionary<string, ActiveUnit>();
		ReservedSupply = false;
		MembersInheritIcon = false;
		CompositionType = E_CompositionType.Mixed;
		IsGroup = true;
		try
		{
			ParentScen = theScen;
			Interlocked.Increment(ref theScen.UnitsAutoIncrement);
			this.set_UnitSide(SetSideOnly: false, theSide);
			Name = $"TemporaryGroupName{Guid.NewGuid().ToString()}";
			if (!Information.IsNothing((object)SelectedUnits))
			{
				foreach (ActiveUnit SelectedUnit in SelectedUnits)
				{
					if (!SelectedUnit.IsShip || !((Ship)SelectedUnit).IsSinking)
					{
						SelectedUnit.set_ParentGroup(UsingMissionPlanner, this);
					}
				}
			}
			DesignateGroupLead_Auto();
			Kinematics.UpdateGroupCenter();
			if (GroupLead != null)
			{
				DesiredSpeed = GroupLead.DesiredSpeed;
				this.set_DesiredHeading(GroupLead.DesiredTurnRate, GroupLead.DesiredHeading);
				DesiredAltitude = GroupLead.DesiredAltitude;
				SetThrottle(GroupLead.ThrottleSetting);
				Kinematics.DesiredSpeedOverride = null;
			}
			HashSet<Mission> hashSet = new HashSet<Mission>();
			HashSet<Mission.Flight> hashSet2 = new HashSet<Mission.Flight>();
			foreach (ActiveUnit value2 in Units.Values)
			{
				if (!Information.IsNothing((object)value2.ActiveMissionOrPackage()))
				{
					hashSet.Add(value2.ActiveMissionOrPackage());
					if (!Information.IsNothing((object)value2.Navigator.get_Flight(HierarchySearch: true)))
					{
						hashSet2.Add(value2.Navigator.get_Flight(HierarchySearch: true));
					}
				}
			}
			bool flag = false;
			if (hashSet.Count == 1)
			{
				Mission? value = hashSet.ElementAtOrDefault(0);
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				Set_AssignedMissionOrPackage(value, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				if (hashSet2.Count > 0 && hashSet.ElementAtOrDefault(0).HasFlights())
				{
					foreach (Mission.Flight flight in hashSet.ElementAtOrDefault(0).FlightList)
					{
						foreach (Mission.Flight item in hashSet2)
						{
							if (flight == item)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
			}
			if (!flag)
			{
				foreach (ActiveUnit value3 in Units.Values)
				{
					value3.Navigator.ClearFlight();
				}
			}
			foreach (ActiveUnit value4 in Units.Values)
			{
				if (!Information.IsNothing((object)value4.ActiveMissionOrPackage()))
				{
					hashSet.Add(value4.ActiveMissionOrPackage());
				}
			}
			bool flag2 = false;
			string text = null;
			if (SelectedUnits != null)
			{
				foreach (ActiveUnit SelectedUnit2 in SelectedUnits)
				{
					if (SelectedUnit2.IsAircraft && string.IsNullOrEmpty(text))
					{
						flag2 = true;
						if (SelectedUnit2.Navigator.HasFlight)
						{
							text = SelectedUnit2.Navigator.get_Flight(HierarchySearch: true).Callsign;
						}
					}
				}
			}
			if (!flag2)
			{
				Name = "Group " + Conversions.ToString(theScen.UnitsAutoIncrement);
			}
			else if (string.IsNullOrEmpty(text))
			{
				Name = "Flight " + Conversions.ToString(theScen.UnitsAutoIncrement);
			}
			else
			{
				Name = "Flight " + text;
			}
			theUnit = this;
			GameGeneral.AddUnitToCollections(ref theUnit, ref theScen);
			theScen.Groups.Add(this);
			if (GameGeneral.Beta_PlatformComms & theScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
			{
				theSide.CreateGroupCommNetwork(this);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100597", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal void DesignateGroupLead_Auto()
	{
		try
		{
			if (Units == null)
			{
				return;
			}
			nullable_16 = method_18();
			if (Units.Count == 1)
			{
				SetGroupLead(Units.Values.FirstOrDefault());
			}
			else if (Type != GroupType.AirBase && Type != GroupType.Installation && Type != GroupType.MobileGroup && Type != GroupType.NavalBase)
			{
				double num = 0.0;
				if (Type == GroupType.ParentGroup)
				{
					if (Units == null)
					{
						return;
					}
					ActiveUnit activeUnit = default(ActiveUnit);
					foreach (ActiveUnit value in Units.Values)
					{
						if (value != null && value.IsGroup && (double)((Group)value).Units.Count > num)
						{
							activeUnit = value;
							num = value.EmptyWeight;
						}
					}
					if (activeUnit != null)
					{
						SetGroupLead(activeUnit);
					}
				}
				else
				{
					ActiveUnit activeUnit2 = method_19(bool_3: true);
					if (activeUnit2 == null)
					{
						activeUnit2 = method_19(bool_3: false);
					}
					SetGroupLead(activeUnit2);
				}
			}
			else
			{
				SetGroupLead(Units.Values.FirstOrDefault());
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100598", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private ActiveUnit method_19(bool bool_3)
	{
		double num = 0.0;
		List<ActiveUnit> list = new List<ActiveUnit>(Units.Values);
		ActiveUnit activeUnit = default(ActiveUnit);
		foreach (ActiveUnit item in list)
		{
			bool flag = true;
			if (bool_3)
			{
				flag = (item.IsAircraft & (item.Navigator.get_Flight(HierarchySearch: false) != null)) && item.Navigator.get_Flight(HierarchySearch: false).FlightPlan != null && item.Navigator.get_Flight(HierarchySearch: false).FlightPlan.Count() > 0;
			}
			if (!(((activeUnit == null) | ((double)item.EmptyWeight > num)) && flag))
			{
				continue;
			}
			activeUnit = item;
			num = item.EmptyWeight;
			try
			{
				if (bool_3)
				{
					activeUnit.set_DesiredHeading(activeUnit.DesiredTurnRate, Module_Unit.BearingToPoint_True(this, activeUnit.Navigator.get_Flight(HierarchySearch: false).FlightPlan[0].Latitude, activeUnit.Navigator.get_Flight(HierarchySearch: false).FlightPlan[0].Longitude));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100599", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		return activeUnit;
	}

	internal void DesignateGroupLead_Manual(ActiveUnit theUnit)
	{
		SetGroupLead(theUnit);
	}

	public bool IsSurfaceGroup()
	{
		return Type == GroupType.SurfaceGroup;
	}

	public override bool AttemptToSetNewAssignedHost(ActiveUnit DestinationUnit, bool ForceRTB = false, bool OutputFeedback = false)
	{
		bool num = !DestinationUnit.IsGroup;
		bool flag = false;
		bool flag2 = false;
		if (DestinationUnit.IsGroup)
		{
			if (((Group)DestinationUnit).Type == GroupType.AirBase)
			{
				flag2 = true;
			}
			else
			{
				flag = true;
			}
		}
		if (!num && !flag2)
		{
			if (flag)
			{
				short num2 = (short)Units.Count;
				short num3 = 0;
				foreach (ActiveUnit value in Units.Values)
				{
					foreach (ActiveUnit value2 in ((Group)DestinationUnit).Units.Values)
					{
						bool item;
						if (!value.IsAircraft)
						{
							if (item = value.DockingOps.ThisUnitCanHostMe(value2, HumanFeedBackNeeded: false).ResponseBoolean)
							{
								value.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, value2);
							}
						}
						else if (item = ((Aircraft)value).AirOps.ThisUnitCanHostMe(value2, HumanFeedbackNeeded: false).ResponseBoolean)
						{
							((Aircraft)value).AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, value2);
						}
						if (item)
						{
							num3++;
						}
					}
				}
				if (Type == GroupType.AirGroup)
				{
					if (num3 == num2)
					{
						ParentScen.AddMessage("All units in group now have " + DestinationUnit.Name + " as their home base.", Name + " now wholly re-based", LoggedMessage.MessageType.AirOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
						return true;
					}
					if (num3 == 0)
					{
						ParentScen.AddMessage("No units in group have switched to " + DestinationUnit.Name + " as their home base.", "No units of " + Name + " changed base", LoggedMessage.MessageType.AirOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
						return false;
					}
					ParentScen.AddMessage("Partial success: Only " + Conversions.ToString((int)num3) + " out of " + Conversions.ToString((int)num2) + " units in this group have switched to  units in group: " + DestinationUnit.Name + " as their home base.", Name + " partially re-based", LoggedMessage.MessageType.AirOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
					return false;
				}
				if (num3 == num2)
				{
					ParentScen.AddMessage("All units in group now have various units in group " + DestinationUnit.Name + " as their home base.", Name + " now wholly re-based", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
					return true;
				}
				if (num3 == 0)
				{
					ParentScen.AddMessage("No units in group have switched to " + DestinationUnit.Name + " as their home base.", "No units of " + Name + " changed base", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
					return false;
				}
				ParentScen.AddMessage("Partial success: Only " + Conversions.ToString((int)num3) + " out of " + Conversions.ToString((int)num2) + " units in this group have switched to units in group: " + DestinationUnit.Name + " as their home base.", Name + " partially re-based", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false));
				return false;
			}
			bool result = default(bool);
			return result;
		}
		short num4 = (short)Units.Count;
		short num5 = 0;
		foreach (ActiveUnit value3 in Units.Values)
		{
			bool item2;
			if (!value3.IsAircraft)
			{
				if (item2 = value3.DockingOps.ThisUnitCanHostMe(DestinationUnit, HumanFeedBackNeeded: false).ResponseBoolean)
				{
					value3.DockingOps.set_AssignedHostUnit(PickNewAssignedHost: false, DestinationUnit);
				}
			}
			else if (item2 = ((Aircraft)value3).AirOps.ThisUnitCanHostMe(DestinationUnit, HumanFeedbackNeeded: false).ResponseBoolean)
			{
				((Aircraft)value3).AirOps.set_AssignedHostUnit(PickNewAssignedHost: false, DestinationUnit);
			}
			if (item2)
			{
				num5++;
			}
		}
		if (Type == GroupType.AirGroup)
		{
			if (num5 == num4)
			{
				ParentScen.AddMessage("All units in group now have " + DestinationUnit.Name + " as their home base.", Name + " now wholly re-based", LoggedMessage.MessageType.AirOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				return true;
			}
			if (num5 == 0)
			{
				ParentScen.AddMessage("No units in group have switched to " + DestinationUnit.Name + " as their home base.", "No units of " + Name + " changed base", LoggedMessage.MessageType.AirOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
				return false;
			}
			ParentScen.AddMessage("Partial success: Only " + Conversions.ToString((int)num5) + " out of " + Conversions.ToString((int)num4) + " units in this group have switched to " + DestinationUnit.Name + " as their home base.", Name + " partially re-based", LoggedMessage.MessageType.AirOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			return false;
		}
		if (num5 == num4)
		{
			ParentScen.AddMessage("All units in group now have " + DestinationUnit.Name + " as their home base.", Name + " now wholly re-based", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			return true;
		}
		if (num5 != 0)
		{
			ParentScen.AddMessage("Partial success: Only " + Conversions.ToString((int)num5) + " out of " + Conversions.ToString((int)num4) + " units in this group have switched to " + DestinationUnit.Name + " as their home base.", Name + " partially re-based", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
			return false;
		}
		ParentScen.AddMessage("No units in group have switched to " + DestinationUnit.Name + " as their home base.", "No units of " + Name + " changed base", LoggedMessage.MessageType.DockingOps, 5, ObjectID, this.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null)));
		return false;
	}

	public override bool IsOperating()
	{
		GroupType type = Type;
		if (type > GroupType.SubGroup && type != GroupType.MobileGroup)
		{
			return true;
		}
		if (GroupLead != null)
		{
			return GroupLead.IsOperating();
		}
		return false;
	}

	public override void SetThrottle(Throttle theThrottleSetting, float? SpecificDesiredSpeed = null)
	{
		if (GroupLead != null)
		{
			if (!SpecificDesiredSpeed.HasValue)
			{
				GroupLead.DesiredSpeed = Kinematics.GroupMaxSpeedForThisThrottleSetting(theThrottleSetting);
			}
			else
			{
				GroupLead.DesiredSpeed = SpecificDesiredSpeed.Value;
			}
			ThrottleSetting = theThrottleSetting;
			GroupLead.SetThrottle(theThrottleSetting, SpecificDesiredSpeed);
			GroupLead.Kinematics.DesiredSpeedOverride = Kinematics.GetMaximumSpeed(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), GroupLead.ThrottleSetting, ValidateAndFixAltitude: false);
		}
	}

	public List<Module_Unit.Unit> ToList()
	{
		return ((IEnumerable<ActiveUnit>)Units.Values).Select((Func<ActiveUnit, Module_Unit.Unit>)([SpecialName] (ActiveUnit theAU) => theAU)).ToList();
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		try
		{
			GroupLead.Teleport(ref theScen, Destination_Lon, Destination_Lat);
			if (Navigator.HasPlottedCourse())
			{
				CurrentHeading = Module_Unit.BearingToPoint_True(this, Navigator.PlottedCourse[0].Latitude, Navigator.PlottedCourse[0].Longitude);
			}
			foreach (ActiveUnit value in Units.Values)
			{
				if (!value.IsGroupLead())
				{
					(double, double) tuple = value.Navigator.UnitFormationStation.get_LatitudeAndLongitude(value, GroupLead);
					value.set_Latitude((GlobalVariables.BooleanObject)null, tuple.Item1);
					value.set_Longitude((GlobalVariables.BooleanObject)null, tuple.Item2);
					value.CurrentHeading = CurrentHeading;
				}
			}
			this.set_Latitude((GlobalVariables.BooleanObject)null, Destination_Lat);
			this.set_Longitude((GlobalVariables.BooleanObject)null, Destination_Lon);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100600", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetGroupLead(ActiveUnit theUnit)
	{
		activeUnit_0 = theUnit;
		if (activeUnit_0 != null)
		{
			this.set_Latitude((GlobalVariables.BooleanObject)null, activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null));
			this.set_Longitude((GlobalVariables.BooleanObject)null, activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null));
		}
	}

	public override void Destroy(bool ScenEditAction, bool IsAimpointFacility, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		try
		{
			try
			{
				ParentScen.Groups.Remove(this);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ParentScen.Groups.Remove(this);
				ProjectData.ClearProjectError();
			}
			List<ActiveUnit> list = new List<ActiveUnit>();
			list.AddRange(Units.Values);
			foreach (ActiveUnit item in list)
			{
				if (item != null)
				{
					item.set_ParentGroup(UsingMissionPlanner: false, (Group)null);
					item.Navigator.ClearPlottedCourse();
					Waypoint[] plottedCourse = Navigator.PlottedCourse;
					foreach (Waypoint theWP in plottedCourse)
					{
						item.Navigator.AddWaypoint(theWP);
					}
				}
			}
			base.Destroy(ScenEditAction, IsAimpointFacility, DestroyUnitNow, theReason, WhatCausedIt, RegisterAsLosses: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100601", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(ActiveUnit activeUnit_1)
	{
		nullable_16 = null;
		if (!DeserializationInProgress)
		{
			DesignateGroupLead_Auto();
		}
		if (activeUnit_1.IsFixedFacility)
		{
			IsLandInstallation = true;
		}
		if ((GameGeneral.Beta_PlatformComms & activeUnit_1.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm)) && !IsLandInstallation && (activeUnit_1.CommStuff.Networks == null || activeUnit_1.CommStuff.Networks.Count == 0))
		{
			bool flag = false;
			if (Units.Values.Except(new ActiveUnit[1] { activeUnit_1 }).Count() != 0)
			{
				using IEnumerator<KeyValuePair<string, CommNetwork>> enumerator = this.get_UnitSide(SetSideOnly: false).CommNetworks.GetEnumerator();
				_Closure$__154-0 closure$__154- = default(_Closure$__154-0);
				while (enumerator.MoveNext())
				{
					closure$__154- = new _Closure$__154-0(closure$__154-);
					closure$__154-.$VB$Local_theCC = enumerator.Current;
					if (flag = Units.Values.Except(new ActiveUnit[1] { activeUnit_1 }).All(closure$__154-._Lambda$__0))
					{
						this.get_UnitSide(SetSideOnly: false).AddUnitToNetwork(closure$__154-.$VB$Local_theCC.Key, activeUnit_1);
						break;
					}
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				this.get_UnitSide(SetSideOnly: false).CreateNextNetworkUnitsReason(Units.Values.Cast<Module_Unit.Unit>().ToHashSet(), CommNetwork.NetworkCreationReason.Generic);
			}
		}
		DetermineCompositionType();
		unitAddedEventHandler_0?.Invoke(this, activeUnit_1);
	}

	private void method_21(ActiveUnit activeUnit_1)
	{
		nullable_16 = null;
		try
		{
			if (!DeserializationInProgress && GroupLead == activeUnit_1)
			{
				DesignateGroupLead_Auto();
			}
			if (Units.Count <= 1)
			{
				if (Units.Count == 1 && Navigator.PlottedCourse != null && Navigator.PlottedCourse.Count() > 0)
				{
					activeUnit_1.Navigator.PlottedCourse = Navigator.PlottedCourse;
				}
				ParentScen.DestroyThisUnit(this, "Group dissolving");
				if (!string.IsNullOrEmpty(Name))
				{
					AddMessage(Name + " has no units left; dissolving...", "Grouping", LoggedMessage.MessageType.UI, 5, new Geopoint_Struct(0.0, 0.0), NotificationType.Bark);
				}
				ParentScen.DeleteUnitImmediately(ObjectID, ScenEditAction: true, "Group dissolving", null, RegisterAsLosses: false);
			}
			else
			{
				DetermineCompositionType();
				if (Type == GroupType.AirGroup && activeUnit_1 != null && activeUnit_1.FlightRole == Mission.Flight.FlightElement.LeadElement && ((Aircraft)activeUnit_1).Navigator.HasFlightPlan)
				{
					if (GroupLead.Navigator.get_Flight(HierarchySearch: true) != null)
					{
						GroupLead.Navigator.get_Flight(HierarchySearch: true).FlightPlan = ((ActiveUnit_Navigator)((Aircraft)activeUnit_1).Navigator).get_Flight(HierarchySearch: true).FlightPlan;
					}
					ActiveUnit groupLead = GroupLead;
					if (groupLead != null)
					{
						groupLead.FlightRole = Mission.Flight.FlightElement.LeadElement;
					}
				}
			}
			IsLandInstallation = false;
			foreach (ActiveUnit value in Units.Values)
			{
				if (value != null && value.IsFixedFacility)
				{
					IsLandInstallation = true;
					break;
				}
			}
			unitRemovedEventHandler_0?.Invoke(this, activeUnit_1);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100602", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool CanMoveToThisLocation(double theLat, double theLon, ref int MovementCost, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, ref bool CheckNoNavZones, bool CheckForIcepack, ref bool CheckForMines, float? DistanceFromUnit, short? ProvidedElevation, ref List<ActiveUnit> ProvidedPiers, float proximityThreshold_Deg, bool CheckIfTargetIsOutsideProsecutionArea, bool CheckDistanceToNoNavZones, ref string UserFeedback, ref bool AllowBounce)
	{
		int result;
		if (GroupLead == null)
		{
			result = 0;
		}
		else
		{
			if (GroupLead.IsActiveUnit)
			{
				return GroupLead.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs, ref CheckNoNavZones, CheckForIcepack, ref CheckForMines, DistanceFromUnit, ProvidedElevation, ref ProvidedPiers, proximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea, CheckDistanceToNoNavZones, ref UserFeedback, ref AllowBounce);
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	private void method_22(object object_0, ObservableListModified<Patrol> observableListModified_0)
	{
		this.get_UnitSide(SetSideOnly: false).MissionsTotal_Reset();
	}

	private void method_23(object object_0, ObservableListModified<Patrol> observableListModified_0)
	{
		this.get_UnitSide(SetSideOnly: false).MissionsTotal_Reset();
	}

	public (float, float) GetSpeedRange(bool EvaluateDamages = false)
	{
		return GetSpeedRange(Units.Values.ToList(), EvaluateDamages);
	}

	public float GetMaximumCohesiveSpeed(Throttle throttle = Throttle.MaxPossibleThrottle, float Altitude = 0f, bool EvaluateDamages = false)
	{
		return GetMaximumCohesiveSpeed(Units.Values.ToList(), Altitude, EvaluateDamages, throttle);
	}

	public float GetMinimumCohesiveSpeed(Throttle throttle = Throttle.MinPossibleThrottle, float Altitude = 0f)
	{
		if (Units.Count <= 0)
		{
			return 0f;
		}
		return GetMinimumCohesiveSpeed(Units.Values.ToList(), Altitude, throttle);
	}

	public HashSet<Throttle> GetThrottleRange()
	{
		if (GroupLead == null)
		{
			return new HashSet<Throttle>();
		}
		GroupLead.Kinematics.GetThrottleRange(GetSpeedRange());
		HashSet<Throttle> result = default(HashSet<Throttle>);
		return result;
	}

	public static (float, float) GetSpeedRange(List<ActiveUnit> Units, bool EvaluateDamages = false)
	{
		float num = float.MinValue;
		float num2 = float.MaxValue;
		foreach (ActiveUnit Unit in Units)
		{
			int maximumSpeed = Unit.Kinematics.GetMaximumSpeed();
			if ((float)maximumSpeed < num)
			{
				num = maximumSpeed;
			}
			if ((float)maximumSpeed > num2)
			{
				num2 = maximumSpeed;
			}
		}
		return (num2, num);
	}

	public static float GetMaximumCohesiveSpeed(List<ActiveUnit> Units, float Altitude = 0f, bool EvaluateDamages = false, Throttle throttle = Throttle.MaxPossibleThrottle, bool ConsiderTerrainAltModifier = true)
	{
		if (Units.Count != 0)
		{
			float num = float.MaxValue;
			Throttle throttleSetting = throttle;
			foreach (ActiveUnit Unit in Units)
			{
				int num2;
				if (throttle == Throttle.MaxPossibleThrottle)
				{
					throttleSetting = Unit.MaxPossibleThrottleSetting;
					num2 = 0;
				}
				else
				{
					num2 = 0;
				}
				int num3 = num2;
				num3 = (ConsiderTerrainAltModifier ? Unit.Kinematics.GetMaximumSpeed(Altitude, throttleSetting, ValidateAndFixAltitude: false, EvaluateDamages) : Unit.Kinematics.GetMaximumSpeed());
				if ((float)num3 < num)
				{
					num = num3;
				}
			}
			return num;
		}
		return 0f;
	}

	public static float GetMinimumCohesiveSpeed(List<ActiveUnit> Units, float Altitude = 0f, Throttle throttle = Throttle.MinPossibleThrottle)
	{
		float num = float.MinValue;
		Throttle throttleSetting = throttle;
		foreach (ActiveUnit Unit in Units)
		{
			if (throttle == Throttle.MinPossibleThrottle)
			{
				throttleSetting = Unit.MinPossibleThrottleSetting;
			}
			int minimumSpeed = Unit.Kinematics.GetMinimumSpeed(Altitude, throttleSetting, ValidateAndFixAltitude: false);
			if ((float)minimumSpeed > num)
			{
				num = minimumSpeed;
			}
		}
		return num;
	}

	public E_CompositionType DetermineCompositionType()
	{
		try
		{
			List<ActiveUnit> unitsToSort;
			lock (Units.Values)
			{
				unitsToSort = new List<ActiveUnit>(Units.Values);
			}
			CompositionType = DetermineCompositionType(unitsToSort);
			return CompositionType;
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

	public static E_CompositionType DetermineCompositionType(List<ActiveUnit> UnitsToSort)
	{
		Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> dictionary = FetchUnitsByCompositionDenominator(UnitsToSort, E_CompositionType.Homogenous_DBIDandLoadout);
		if (dictionary.Count <= 1)
		{
			return E_CompositionType.Homogenous_DBIDandLoadout;
		}
		HashSet<int> hashSet = new HashSet<int>();
		HashSet<int> hashSet2 = new HashSet<int>();
		HashSet<GlobalVariables.ActiveUnitType> hashSet3 = new HashSet<GlobalVariables.ActiveUnitType>();
		foreach (KeyValuePair<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> item in dictionary)
		{
			if (!hashSet.Contains(item.Key.Item3))
			{
				hashSet.Add((int)item.Key.Item1);
			}
			if (!hashSet2.Contains(item.Key.Item2))
			{
				hashSet2.Add(item.Key.Item2);
			}
			if (!hashSet3.Contains(item.Key.Item1))
			{
				hashSet3.Add(item.Key.Item1);
			}
		}
		if (hashSet3.Count > 1)
		{
			return E_CompositionType.Mixed;
		}
		if (hashSet2.Count > 1)
		{
			return E_CompositionType.Homogenous_Type;
		}
		if (hashSet.Count > 1)
		{
			return E_CompositionType.Homogenous_DBID;
		}
		return E_CompositionType.Homogenous_DBIDandLoadout;
	}

	public Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> FetchUnitsByCompositionDenominator(E_CompositionType TheDenominator)
	{
		return FetchUnitsByCompositionDenominator(Units.Values.ToList(), TheDenominator);
	}

	public static Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> FetchUnitsByCompositionDenominator(List<ActiveUnit> UnitsToSort, E_CompositionType TheDenominator)
	{
		Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> dictionary = new Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>>();
		if (TheDenominator == E_CompositionType.Mixed)
		{
			dictionary.Add((GlobalVariables.ActiveUnitType.None, -99, -99), UnitsToSort);
			return dictionary;
		}
		(GlobalVariables.ActiveUnitType, int, int) key = default((GlobalVariables.ActiveUnitType, int, int));
		foreach (ActiveUnit item2 in UnitsToSort)
		{
			if (item2 == null)
			{
				continue;
			}
			switch (TheDenominator)
			{
			case E_CompositionType.Homogenous_DBIDandLoadout:
			{
				int item = -99;
				if (item2.IsAircraft)
				{
					item = ((Aircraft)item2).Loadout.DBID;
				}
				key = (item2.UnitType, item2.DBID, item);
				break;
			}
			case E_CompositionType.Homogenous_DBID:
				key = (item2.UnitType, item2.DBID, -99);
				break;
			case E_CompositionType.Homogenous_Type:
				key = (item2.UnitType, -99, -99);
				break;
			}
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, new List<ActiveUnit>());
			}
			dictionary[key].Add(item2);
		}
		return dictionary;
	}

	public static List<ActiveUnit> GetUnitsWithCommonComposition(List<ActiveUnit> UnitsToSort, GlobalVariables.ActiveUnitType unitType, int DBID = -99, int LoadoutID = -99)
	{
		List<ActiveUnit> result = new List<ActiveUnit>();
		Dictionary<(GlobalVariables.ActiveUnitType, int, int), List<ActiveUnit>> dictionary = FetchUnitsByCompositionDenominator(UnitsToSort, E_CompositionType.Homogenous_DBID);
		if (dictionary.ContainsKey((unitType, DBID, LoadoutID)))
		{
			return dictionary[(unitType, DBID, LoadoutID)];
		}
		return result;
	}

	public static GroupType DetermineUnitDestinationGroupType(ActiveUnit theUnit)
	{
		if (!theUnit.IsGroup)
		{
			if (!Information.IsNothing((object)theUnit.DockFacilities_ReadOnly) && theUnit.IsFixedFacility && theUnit.DockFacilities_ReadOnly.Length > 0)
			{
				return GroupType.NavalBase;
			}
			if (!Information.IsNothing((object)theUnit.AirFacilities_ReadOnly))
			{
				AirFacility[] airFacilities_ReadOnly = theUnit.AirFacilities_ReadOnly;
				for (int i = 0; i < airFacilities_ReadOnly.Length; i = checked(i + 1))
				{
					if (airFacilities_ReadOnly[i].AirFacType == AirFacility._AirFacType.Runway && theUnit.IsFixedFacility)
					{
						return GroupType.AirBase;
					}
				}
			}
			if (!theUnit.IsFixedFacility)
			{
				if (theUnit.IsShip)
				{
					return GroupType.SurfaceGroup;
				}
				if (theUnit.IsSubmarine)
				{
					return GroupType.SubGroup;
				}
				if (!theUnit.IsAircraft)
				{
					if (!theUnit.IsMobileGroundUnit)
					{
						throw new NotImplementedException();
					}
					return GroupType.MobileGroup;
				}
				return GroupType.AirGroup;
			}
			return GroupType.Installation;
		}
		return GroupType.ParentGroup;
	}

	public static Domain DetermineUnitDomain(ActiveUnit theUnit)
	{
		if (!theUnit.IsGroup)
		{
			if (theUnit.IsFixedFacility)
			{
				return Domain.Land;
			}
			if (theUnit.IsShip)
			{
				return Domain.Maritime;
			}
			if (!theUnit.IsSubmarine)
			{
				if (theUnit.IsAircraft)
				{
					return Domain.Air;
				}
				if (theUnit.IsMobileGroundUnit)
				{
					return Domain.Land;
				}
				throw new NotImplementedException();
			}
			return Domain.Maritime;
		}
		return Domain.None;
	}

	public static Dictionary<GroupType, List<ActiveUnit>> SortUnitsByIdealGroupType(List<ActiveUnit> Units)
	{
		Dictionary<GroupType, List<ActiveUnit>> dictionary = new Dictionary<GroupType, List<ActiveUnit>>();
		foreach (ActiveUnit Unit in Units)
		{
			GroupType key = DetermineUnitDestinationGroupType(Unit);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, new List<ActiveUnit>());
			}
			dictionary[key].Add(Unit);
		}
		return dictionary;
	}

	public static int SortUnitsByDomain(List<ActiveUnit> Units, ref List<ActiveUnit>[] Domains)
	{
		int length = Enum.GetValues(typeof(Domain)).Length;
		if (Domains != null && Domains.Length == length)
		{
			int num = Domains.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				Domains[i]?.Clear();
			}
		}
		else
		{
			Domains = new List<ActiveUnit>[length - 1 + 1];
		}
		if (Units != null && Units.Count != 0)
		{
			int num2 = 0;
			int num3 = Units.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				ActiveUnit activeUnit = Units[j];
				if (activeUnit == null)
				{
					continue;
				}
				int num4 = (int)DetermineUnitDomain(activeUnit);
				if (num4 >= 0 && num4 < Domains.Length)
				{
					List<ActiveUnit> list = Domains[num4];
					if (list == null)
					{
						num2++;
						list = new List<ActiveUnit>();
						Domains[num4] = list;
					}
					list.Add(activeUnit);
				}
			}
			return num2;
		}
		return 0;
	}

	public bool IsGroupableUnit(ActiveUnit theAU)
	{
		int result;
		if (Type != GroupType.AirGroup)
		{
			if (Type == GroupType.SurfaceGroup)
			{
				if (!theAU.IsShip)
				{
					return false;
				}
				result = 1;
			}
			else
			{
				if (Type == GroupType.SubGroup)
				{
					if (!theAU.IsSubmarine)
					{
						return false;
					}
					goto IL_00be;
				}
				if (Type != GroupType.AirBase && Type != GroupType.Installation && Type != GroupType.MobileGroup && Type != GroupType.NavalBase)
				{
					if (Type != GroupType.ParentGroup)
					{
						goto IL_00be;
					}
					if (!theAU.IsGroup)
					{
						return false;
					}
					result = 1;
				}
				else
				{
					if (!theAU.IsFacility)
					{
						return false;
					}
					result = 1;
				}
			}
			goto IL_00bf;
		}
		if (theAU.IsAircraft)
		{
			if (Operators.CompareString(GroupLead?.UnitClass, theAU.UnitClass, false) == 0)
			{
				return false;
			}
			goto IL_00be;
		}
		return false;
		IL_00bf:
		return (byte)result != 0;
		IL_00be:
		result = 1;
		goto IL_00bf;
	}

	private void method_24(object sender, NotifyCollectionChangedEventArgs e)
	{
		try
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				method_20(((KeyValuePair<string, ActiveUnit>)e.NewItems[0]).Value);
				break;
			case NotifyCollectionChangedAction.Remove:
				method_21(((KeyValuePair<string, ActiveUnit>)e.OldItems[0]).Value);
				break;
			case NotifyCollectionChangedAction.Replace:
				break;
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

	static Group()
	{
		Class72.smethod_20();
	}
}
