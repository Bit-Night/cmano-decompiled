using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using Collections.Pooled;
using Command_Core.Mercator_OSM;
using CSMaterial;
using CSMaterial.ClipperLib;
using CSMaterial.ExWorldWind;
using DotSpatial.Topology;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class ActiveUnit_Navigator
{
	public class FormationStation
	{
		public float Bearing;

		public float Distance;

		public ReferencePoint.OrientationType BearingType;

		public double Latitude
		{
			get
			{
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(GroupLead.get_Longitude((GlobalVariables.BooleanObject)null), GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, Distance, this.get_ResultantBearing(myUnit));
				return out_lat;
			}
		}

		public double Longitude
		{
			get
			{
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(GroupLead.get_Longitude((GlobalVariables.BooleanObject)null), GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, Distance, this.get_ResultantBearing(myUnit));
				return out_lon;
			}
		}

		public (double, double) LatitudeAndLongitude
		{
			get
			{
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(GroupLead.get_Longitude((GlobalVariables.BooleanObject)null), GroupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, Distance, this.get_ResultantBearing(myUnit));
				return (out_lat, out_lon);
			}
		}

		public float ResultantBearing
		{
			get
			{
				switch (BearingType)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return 0f;
				case ReferencePoint.OrientationType.Rotating:
					return Math2.NormalizeBearing(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentHeading + Bearing);
				case ReferencePoint.OrientationType.Fixed:
					return Bearing;
				}
			}
		}

		public (double, double) ValidatedLatitudeAndLongitude
		{
			get
			{
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(GroupLead.get_Longitude(GlobalVariables.ObjectTrue), GroupLead.get_Latitude(GlobalVariables.ObjectTrue), ref out_lon, ref out_lat, Distance, this.get_ResultantBearing(myUnit));
				double theLat = out_lat;
				double theLon = out_lon;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				List<ActiveUnit> ProvidedPiers = null;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (!myUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					ActiveUnit_Navigator navigator = myUnit.Navigator;
					double startLat = GroupLead.get_Latitude((GlobalVariables.BooleanObject)null);
					double startLon = GroupLead.get_Longitude((GlobalVariables.BooleanObject)null);
					double destLat = out_lat;
					double destLon = out_lon;
					ProvidedPiers = null;
					GeoPoint geoPoint = navigator.LastAccessiblePointOnPath(startLat, startLon, destLat, destLon, 0f, null, 0f, ref ProvidedPiers);
					if (geoPoint != null)
					{
						out_lat = geoPoint.Latitude;
						out_lon = geoPoint.Longitude;
					}
				}
				return (out_lat, out_lon);
			}
		}

		static FormationStation()
		{
			Class72.smethod_20();
		}
	}

	public class WP_reach_cache
	{
		public Geopoint_Struct theWaypoint;

		public DateTime theTime;

		public bool theResult;

		public double theDistance;

		public Geopoint_Struct UnitLocation;

		public WP_reach_cache()
		{
		}

		public void Clear()
		{
			theWaypoint = default(Geopoint_Struct);
			theTime = DateTime.MinValue;
			theResult = false;
			theDistance = 0.0;
			UnitLocation = default(Geopoint_Struct);
		}

		public void Update(Geopoint_Struct theWaypoint, DateTime theTime, bool theResult, double theDistance, Geopoint_Struct unitLocation)
		{
			this.theWaypoint = theWaypoint;
			this.theTime = theTime;
			this.theResult = theResult;
			this.theDistance = theDistance;
			UnitLocation = unitLocation;
		}

		public WP_reach_cache(Geopoint_Struct theWaypoint, DateTime theTime, bool theResult, double theDistance, Geopoint_Struct UnitLocation)
		{
			this.theWaypoint = theWaypoint;
			this.theTime = theTime;
			this.theResult = theResult;
			this.theDistance = theDistance;
			this.UnitLocation = UnitLocation;
		}

		public WP_reach_cache(double Latitude, double Longitude, DateTime theTime, bool theResult, double theDistance, Geopoint_Struct UnitLocation)
		{
			theWaypoint = new Geopoint_Struct(Longitude, Latitude);
			this.theTime = theTime;
			this.theResult = theResult;
			this.theDistance = theDistance;
			this.UnitLocation = UnitLocation;
		}

		static WP_reach_cache()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__195-0
	{
		public double $VB$Local_TakeOffPoint_Lat;

		public double $VB$Local_TakeOffPoint_Lon;

		public _Closure$__195-0(_Closure$__195-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_TakeOffPoint_Lat = arg0.$VB$Local_TakeOffPoint_Lat;
				$VB$Local_TakeOffPoint_Lon = arg0.$VB$Local_TakeOffPoint_Lon;
			}
		}

		[SpecialName]
		internal float _Lambda$__0(ReferencePoint theP)
		{
			return Math2.CalcDist(theP.Latitude, theP.Longitude, $VB$Local_TakeOffPoint_Lat, $VB$Local_TakeOffPoint_Lon);
		}

		static _Closure$__195-0()
		{
			Class72.smethod_20();
		}
	}

	protected ActiveUnit myUnit;

	protected Waypoint[] _PlottedCourse;

	protected Waypoint[] _PlottedCourse_PrePlanned;

	protected Mission.Flight _Flight;

	protected string _Flight_ID;

	public bool ManualPlotOverride;

	private FormationStation formationStation_0;

	public ReferencePoint SupportMission_NextRefPoint;

	public ReferencePoint PatrolLoop_NextRefPoint;

	public bool bool_0;

	public float TimeToNextPathfinderCheck;

	[CompilerGenerated]
	private bool bciLhEoqoLV;

	public float Pathfinding_PercentComplete;

	public bool PathFindingAbortNextPath;

	public bool TankerIsBlockedByNoNavZone;

	public bool? TankerFollowsMe;

	private int int_0;

	internal int NavigationBufferTolerance_Narrow_meters;

	internal int NavigationBufferTolerance_Wide_meters;

	protected List<Waypoint> PF_GeneratedCourse;

	public double TimeToNextIsInsideMissionAreaEvaluation_NoBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer;

	public double TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer;

	public double TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer;

	public double TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer;

	public bool InsideMissionArea_NoBuffer;

	public bool InsideMissionArea_1nmBuffer;

	public bool InsideMissionArea_2nmBuffer;

	public bool InsideMissionArea_5nmBuffer;

	public bool InsideMissionArea_10nmBuffer;

	public bool InsideMissionArea_30nmBuffer;

	public bool InsideProsecutionArea_NoBuffer;

	public bool InsideProsecutionArea_5nmBuffer;

	public double TimeToNextPlottedCourseLeadsToMissionAreaEvaluation;

	public bool CourseLeadsToMissionArea;

	public double TimeToNextUnitDistanceToNearestNoNavZoneEvaluation;

	public bool CheckNoNavZones_UnitMovementOnEveryPulse;

	public float? GetNearestAccessibleSpotHeading;

	public DateTime? PreviousWaypointTime;

	public double? PreviousWaypointLatitude;

	public double? PreviousWaypointLongitude;

	public Waypoint.WaypointType? PreviousWaypointType;

	public double ExtendTimer;

	private bool bool_1;

	private float? AsfLhVtqiWa;

	private GeoPoint geoPoint_0;

	public bool AvoidCavitation;

	private bool? nullable_0;

	internal bool IsManouveringToFormationStation;

	internal const float SprintDriftDistance = 6f;

	public Waypoint PreviousWaypoint;

	private bool bool_2;

	public WP_reach_cache WP_reach_cache_memory;

	private float? nullable_1;

	public Waypoint _ResumeFlightPlanWaypoint;

	private bool bool_3;

	[CompilerGenerated]
	private FlightPlanInfo flightPlanInfo_0;

	public bool PathFindingInProgress
	{
		get
		{
			return method_0();
		}
		set
		{
			method_1(value);
		}
	}

	public int TankerFollowsMe_NumberOfWaypoints
	{
		get
		{
			int_0 = method_2(int_0);
			return int_0;
		}
		set
		{
			int_0 = method_2(value);
		}
	}

	public float ALTTITUTE_THREASHOLD
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				float gameResolution = myUnit.ParentScen.GameResolution;
				if (gameResolution == 0.1f)
				{
					return 10f;
				}
				if (gameResolution == 1f)
				{
					return 10f;
				}
				if (gameResolution == 5f)
				{
					return 50f;
				}
				if (myUnit.ParentScen.GameResolution > 1f)
				{
					return 50f;
				}
				return 10f;
			}
			return nullable_1.Value;
		}
	}

	public virtual bool SprintDrift
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool num = value != bool_1;
			bool_1 = value;
			if (num)
			{
				if (!bool_1)
				{
					SprintDrift_AverageSpeed = null;
				}
				else
				{
					SetSprintDriftMarker(ResetAverageSpeed: true);
				}
			}
		}
	}

	public virtual float? SprintDrift_AverageSpeed
	{
		get
		{
			return AsfLhVtqiWa;
		}
		set
		{
			bool flag = default(bool);
			if (Information.IsNothing((object)value) && !Information.IsNothing((object)AsfLhVtqiWa))
			{
				flag = true;
			}
			if (!flag && !Information.IsNothing((object)value) && Information.IsNothing((object)AsfLhVtqiWa))
			{
				flag = true;
			}
			if (!flag)
			{
				float? num = value;
				float? asfLhVtqiWa = AsfLhVtqiWa;
				if (((num.HasValue & asfLhVtqiWa.HasValue) ? new bool?(num.GetValueOrDefault() != asfLhVtqiWa.GetValueOrDefault()) : ((bool?)null)) == true)
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
				{
					value = ((!myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.SprintDrift) ? new float?(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredSpeed) : myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.SprintDrift_AverageSpeed);
				}
				AsfLhVtqiWa = value;
			}
		}
	}

	public virtual GeoPoint SprintDrift_Marker
	{
		get
		{
			return geoPoint_0;
		}
		set
		{
			geoPoint_0 = value;
		}
	}

	public FormationStation UnitFormationStation
	{
		get
		{
			if (formationStation_0 == null)
			{
				formationStation_0 = new FormationStation();
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
				{
					formationStation_0.BearingType = ReferencePoint.OrientationType.Rotating;
					CalculateFormationStationRelativeData();
				}
			}
			return formationStation_0;
		}
		set
		{
			formationStation_0 = value;
		}
	}

	public virtual Waypoint[] PlottedCourse
	{
		get
		{
			Waypoint[] theArray;
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				if (!myUnit.IsAircraft || !myUnit.Navigator.HasFlightPlan)
				{
					theArray = ((!myUnit.IsGroupLead()) ? _PlottedCourse : ((!myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.HasPlottedCourse()) ? _PlottedCourse : myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse));
				}
				else
				{
					theArray = (myUnit.IsGroupLead() ? ((!((myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse.Count() != 0) & (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null))) ? _PlottedCourse : myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse) : ((!((_PlottedCourse.Count() == 0) & (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null))) ? _PlottedCourse : (_PlottedCourse = myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse)));
					if (theArray != null && theArray.Length > 0)
					{
						while (theArray[0].Type == Waypoint.WaypointType.WeaponTarget && !myUnit.IsWeapon)
						{
							ArrayExtensions.Remove(ref theArray, theArray[0]);
							if (theArray.Length == 0)
							{
								break;
							}
						}
					}
				}
			}
			else
			{
				theArray = _PlottedCourse;
			}
			if (theArray == null)
			{
				theArray = new Waypoint[0];
			}
			return theArray;
		}
		set
		{
			if (_PlottedCourse.Count() > 0)
			{
				Waypoint? waypoint = _PlottedCourse.FirstOrDefault();
				if (waypoint != null && waypoint.Category == Waypoint.WaypointCategory.FlightPlan)
				{
					if (value.Count() > 0 && value[0].Category != Waypoint.WaypointCategory.FlightPlan)
					{
						_ResumeFlightPlanWaypoint = _PlottedCourse[0];
					}
					else
					{
						_ResumeFlightPlanWaypoint = null;
					}
					goto IL_005d;
				}
			}
			_ResumeFlightPlanWaypoint = null;
			goto IL_005d;
			IL_005d:
			_PlottedCourse = value;
			if (myUnit.IsGroupLead())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse = value;
			}
			TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
	}

	public Waypoint[] PlottedCourse_PrePlanned
	{
		get
		{
			if (myUnit.IsGroupLead())
			{
				return myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse_PrePlanned;
			}
			return _PlottedCourse_PrePlanned;
		}
		set
		{
			_PlottedCourse_PrePlanned = value;
			if (myUnit.IsGroupLead())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.PlottedCourse_PrePlanned = value;
			}
		}
	}

	public Mission.Flight Flight
	{
		get
		{
			if (HierarchySearch)
			{
				if (myUnit.IsGroupLead())
				{
					return myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.get_Flight(HierarchySearch: true);
				}
				return _Flight;
			}
			return _Flight;
		}
		set
		{
			_Flight = value;
			if (myUnit.IsGroupLead())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.set_Flight(HierarchySearch: true, value);
			}
		}
	}

	public Mission.Flight Flight_C_Sharp
	{
		get
		{
			if (!myUnit.IsGroupLead())
			{
				return _Flight;
			}
			return myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.get_Flight(HierarchySearch: true);
		}
		set
		{
			_Flight = value;
			if (myUnit.IsGroupLead())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.set_Flight(HierarchySearch: true, value);
			}
		}
	}

	public bool IsInSupportTransit
	{
		get
		{
			if (myUnit.ActiveMissionOrPackage() == null)
			{
				return false;
			}
			if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Support)
			{
				return false;
			}
			bool flag = false;
			SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
			if (Information.IsNothing((object)supportMission.NavigationCourse))
			{
				return false;
			}
			if (supportMission.NavigationCourse.Count != 0)
			{
				flag = ((!myUnit.IsAircraft) ? (!IsInsideMissionArea(ref supportMission.NavigationCourse, ref supportMission.NavigationCourse_2nm_Buffered, ref supportMission.NavigationCourse_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false)) : (!IsInsideMissionArea(ref supportMission.NavigationCourse, ref supportMission.NavigationCourse_10nm_Buffered, ref supportMission.NavigationCourse_10nm_ChangeCheck, 10, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false)));
				if (myUnit.IsRTB)
				{
					flag = true;
				}
				return flag;
			}
			return false;
		}
	}

	public bool IsInsideMiningArea
	{
		get
		{
			bool result;
			try
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					result = false;
				}
				else if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Mining)
				{
					result = false;
				}
				else
				{
					MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
					result = (myUnit.IsAircraft ? IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_10nm_Buffered, ref miningMission.Area_10nm_ChangeCheck, 10, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) : IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_2nm_Buffered, ref miningMission.Area_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 09348758921370213894", "");
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

	public bool IsInsidePatrolArea
	{
		get
		{
			bool result;
			try
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					result = false;
				}
				else if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol)
				{
					result = false;
				}
				else
				{
					Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
					result = (myUnit.IsAircraft ? IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_10nm_Buffered, ref patrol.PatrolArea_10nm_ChangeCheck, 10, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) : IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false));
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100211", "");
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

	public bool IsOnAutoPlannerPlottedCourse_AttackIngressRun
	{
		get
		{
			if (!HasPlottedCourse())
			{
				return false;
			}
			int result;
			int result2;
			int result3;
			if (!myUnit.AI.IsEscort)
			{
				Waypoint waypoint = PlottedCourse.FirstOrDefault();
				if (waypoint != null)
				{
					Waypoint.WaypointType type = waypoint.Type;
					if (type <= Waypoint.WaypointType.Refuel)
					{
						switch (type)
						{
						case Waypoint.WaypointType.PathfindingPoint:
						case Waypoint.WaypointType.TurningPoint:
						case Waypoint.WaypointType.Refuel:
							goto IL_0074;
						case Waypoint.WaypointType.Assemble:
						case Waypoint.WaypointType.Split:
						case Waypoint.WaypointType.Formate:
							goto IL_00f9;
						case Waypoint.WaypointType.InitialPoint:
						case Waypoint.WaypointType.Target:
							goto IL_00fd;
						}
						result = 0;
						goto IL_00fa;
					}
					if (type == Waypoint.WaypointType.WeaponLaunch)
					{
						goto IL_00fd;
					}
					if (type != Waypoint.WaypointType.WeaponTarget)
					{
						goto IL_00f9;
					}
					result2 = 1;
					goto IL_00fe;
				}
				result3 = 0;
				goto IL_0102;
			}
			return false;
			IL_0102:
			return (byte)result3 != 0;
			IL_00f9:
			result = 0;
			goto IL_00fa;
			IL_0074:
			Waypoint[] plottedCourse = PlottedCourse;
			int num = 0;
			while (num < plottedCourse.Length)
			{
				Waypoint waypoint2 = plottedCourse[num];
				if (waypoint2.Type == Waypoint.WaypointType.TurningPoint || waypoint2.Type == Waypoint.WaypointType.Refuel || waypoint2.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					num = checked(num + 1);
					continue;
				}
				Waypoint.WaypointType type2 = waypoint2.Type;
				int result4;
				int result5;
				if (type2 <= Waypoint.WaypointType.Target)
				{
					if (type2 != Waypoint.WaypointType.InitialPoint && type2 != Waypoint.WaypointType.Target)
					{
						result4 = 0;
						goto IL_00e5;
					}
				}
				else if (type2 != Waypoint.WaypointType.WeaponLaunch)
				{
					if (type2 == Waypoint.WaypointType.WeaponTarget)
					{
						result5 = 1;
						goto IL_00e9;
					}
					result4 = 0;
					goto IL_00e5;
				}
				result5 = 1;
				goto IL_00e9;
				IL_00e5:
				return (byte)result4 != 0;
				IL_00e9:
				return (byte)result5 != 0;
			}
			result3 = 0;
			goto IL_0102;
			IL_00fe:
			return (byte)result2 != 0;
			IL_00fd:
			result2 = 1;
			goto IL_00fe;
			IL_00fa:
			return (byte)result != 0;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun
	{
		get
		{
			int result;
			int result2;
			if (HasPlottedCourse())
			{
				if (!myUnit.AI.IsEscort)
				{
					Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
					int? num = (int?)waypointType;
					bool? flag2;
					bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 5)));
					bool? obj;
					bool? flag3;
					if (flag.HasValue && flag2 == true)
					{
						obj = true;
					}
					else
					{
						num = (int?)waypointType;
						flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 26)));
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
						num = (int?)waypointType;
						flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 27)));
						obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
					}
					bool? flag6 = obj2;
					flag5 = obj2;
					bool? obj3;
					bool? flag7;
					if (flag5.HasValue && flag6 == true)
					{
						obj3 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag5 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 8)));
						obj3 = ((!flag5.HasValue) ? ((bool?)null) : ((flag7 == true) | flag6));
					}
					bool? flag8 = obj3;
					flag7 = obj3;
					bool? obj4;
					bool? flag9;
					if (flag7.HasValue && flag8 == true)
					{
						obj4 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag7 = (flag9 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 7)));
						obj4 = ((!flag7.HasValue) ? ((bool?)null) : ((flag9 == true) | flag8));
					}
					bool? flag10 = obj4;
					flag9 = obj4;
					bool? obj5;
					bool? flag11;
					if (flag9.HasValue && flag10 == true)
					{
						obj5 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag9 = (flag11 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 17)));
						obj5 = ((!flag9.HasValue) ? ((bool?)null) : ((flag11 == true) | flag10));
					}
					bool? flag12 = obj5;
					flag11 = obj5;
					bool? obj6;
					bool? flag13;
					if (flag11.HasValue && flag12 == true)
					{
						obj6 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag11 = (flag13 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 10)));
						obj6 = ((!flag11.HasValue) ? ((bool?)null) : ((flag13 == true) | flag12));
					}
					bool? flag14 = obj6;
					flag13 = obj6;
					bool? obj7;
					bool? flag15;
					if (flag13.HasValue && flag14 == true)
					{
						obj7 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag13 = (flag15 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 19)));
						obj7 = ((!flag13.HasValue) ? ((bool?)null) : ((flag15 == true) | flag14));
					}
					bool? flag16 = obj7;
					flag15 = obj7;
					bool? obj8;
					bool? flag17;
					if (flag15.HasValue && flag16 == true)
					{
						obj8 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag15 = (flag17 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 12)));
						obj8 = ((!flag15.HasValue) ? ((bool?)null) : ((flag17 == true) | flag16));
					}
					flag17 = obj8;
					if (flag17 != true)
					{
						num = (int?)waypointType;
						flag13 = (flag15 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)));
						bool? obj9;
						if (flag13.HasValue && flag15 == true)
						{
							obj9 = true;
						}
						else
						{
							num = (int?)waypointType;
							flag13 = (flag14 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 14)));
							obj9 = ((!flag13.HasValue) ? ((bool?)null) : ((flag14 == true) | flag15));
						}
						flag17 = obj9;
						flag14 = obj9;
						bool? obj10;
						if (flag14.HasValue && flag17 == true)
						{
							obj10 = true;
						}
						else
						{
							num = (int?)waypointType;
							flag14 = (flag16 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)));
							obj10 = ((!flag14.HasValue) ? ((bool?)null) : ((flag16 == true) | flag17));
						}
						flag16 = obj10;
						if (flag16 != true)
						{
							return false;
						}
						Waypoint[] plottedCourse = PlottedCourse;
						int num2 = 0;
						Waypoint waypoint;
						while (true)
						{
							if (num2 < plottedCourse.Length)
							{
								waypoint = plottedCourse[num2];
								if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
								{
									break;
								}
								num2 = checked(num2 + 1);
								continue;
							}
							return false;
						}
						Waypoint.WaypointType type = waypoint.Type;
						if (type <= Waypoint.WaypointType.WeaponLaunch)
						{
							switch (type)
							{
							case Waypoint.WaypointType.TurningPoint:
							case Waypoint.WaypointType.Formate:
							case Waypoint.WaypointType.LandingMarshal:
								goto IL_074e;
							case Waypoint.WaypointType.Assemble:
							case Waypoint.WaypointType.InitialPoint:
							case Waypoint.WaypointType.Split:
							case Waypoint.WaypointType.Target:
							case Waypoint.WaypointType.StrikeIngress:
							case Waypoint.WaypointType.WeaponLaunch:
								goto IL_0752;
							}
							result = 0;
							goto IL_074f;
						}
						if (type == Waypoint.WaypointType.WeaponTarget)
						{
							goto IL_0752;
						}
						if ((uint)(type - 26) > 1u)
						{
							goto IL_074e;
						}
						result2 = 1;
						goto IL_0753;
					}
					return true;
				}
				return false;
			}
			return false;
			IL_074e:
			result = 0;
			goto IL_074f;
			IL_0752:
			result2 = 1;
			goto IL_0753;
			IL_0753:
			return (byte)result2 != 0;
			IL_074f:
			return (byte)result != 0;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_FinalTargetRun
	{
		get
		{
			if (!HasPlottedCourse())
			{
				return false;
			}
			int result;
			if (!myUnit.AI.IsEscort)
			{
				Waypoint.WaypointType type = PlottedCourse[0].Type;
				if (type <= Waypoint.WaypointType.TurningPoint)
				{
					if (type != Waypoint.WaypointType.PathfindingPoint && type != Waypoint.WaypointType.TurningPoint)
					{
						result = 0;
						goto IL_005b;
					}
					goto IL_005e;
				}
				int result2;
				if (type != Waypoint.WaypointType.Target)
				{
					if (type == Waypoint.WaypointType.Refuel)
					{
						goto IL_005e;
					}
					if (type != Waypoint.WaypointType.WeaponTarget)
					{
						result = 0;
						goto IL_005b;
					}
					result2 = 1;
				}
				else
				{
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
			return false;
			IL_005b:
			return (byte)result != 0;
			IL_005e:
			Waypoint[] plottedCourse = PlottedCourse;
			int num = 0;
			Waypoint waypoint;
			while (true)
			{
				if (num < plottedCourse.Length)
				{
					waypoint = plottedCourse[num];
					if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return false;
			}
			int result3;
			switch (waypoint.Type)
			{
			case Waypoint.WaypointType.WeaponTarget:
				result3 = 1;
				break;
			default:
				return false;
			case Waypoint.WaypointType.Target:
				result3 = 1;
				break;
			}
			return (byte)result3 != 0;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseAndAttackEgressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				if (!myUnit.AI.IsEscort)
				{
					Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
					int? num = (int?)waypointType;
					bool? flag2;
					bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 13)));
					bool? obj;
					bool? flag3;
					if (flag.HasValue && flag2 == true)
					{
						obj = true;
					}
					else
					{
						num = (int?)waypointType;
						flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 9)));
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
						num = (int?)waypointType;
						flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 11)));
						obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
					}
					flag5 = obj2;
					if (flag5 != true)
					{
						num = (int?)waypointType;
						flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)));
						bool? obj3;
						if (flag.HasValue && flag3 == true)
						{
							obj3 = true;
						}
						else
						{
							num = (int?)waypointType;
							flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 14)));
							obj3 = ((!flag.HasValue) ? ((bool?)null) : ((flag2 == true) | flag3));
						}
						flag5 = obj3;
						flag2 = obj3;
						bool? obj4;
						if (flag2.HasValue && flag5 == true)
						{
							obj4 = true;
						}
						else
						{
							num = (int?)waypointType;
							flag2 = (flag4 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)));
							obj4 = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag5));
						}
						flag4 = obj4;
						if (flag4 == true)
						{
							Waypoint[] plottedCourse = PlottedCourse;
							foreach (Waypoint waypoint in plottedCourse)
							{
								int result;
								if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
								{
									switch (waypoint.Type)
									{
									default:
										result = 0;
										goto IL_03aa;
									case Waypoint.WaypointType.Target:
									case Waypoint.WaypointType.StrikeIngress:
										result = 0;
										goto IL_03aa;
									case Waypoint.WaypointType.Formate:
									case Waypoint.WaypointType.LandingMarshal:
									case Waypoint.WaypointType.StrikeEgress:
										{
											return true;
										}
										IL_03aa:
										return (byte)result != 0;
									}
								}
							}
							return false;
						}
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_CruiseEgressRun
	{
		get
		{
			if (!HasPlottedCourse())
			{
				return false;
			}
			if (myUnit.AI.IsEscort)
			{
				return false;
			}
			Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
			int? num = (int?)waypointType;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 11)) != true)
			{
				num = (int?)waypointType;
				bool? flag2;
				bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)));
				bool? obj;
				bool? flag3;
				if (flag.HasValue && flag2 == true)
				{
					obj = true;
				}
				else
				{
					num = (int?)waypointType;
					flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 14)));
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
					num = (int?)waypointType;
					flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)));
					obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
				}
				flag5 = obj2;
				if (flag5 == true)
				{
					Waypoint[] plottedCourse = PlottedCourse;
					int num2 = 0;
					Waypoint waypoint;
					while (true)
					{
						if (num2 < plottedCourse.Length)
						{
							waypoint = plottedCourse[num2];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num2 = checked(num2 + 1);
							continue;
						}
						return false;
					}
					Waypoint.WaypointType type = waypoint.Type;
					if (type == Waypoint.WaypointType.LandingMarshal)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_StationIngressRun
	{
		get
		{
			if (!HasPlottedCourse() | (PlottedCourse.Count() == 0))
			{
				return false;
			}
			Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
			int? num = (int?)waypointType;
			bool? flag2;
			bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 20)));
			bool? obj;
			bool? flag3;
			if (flag.HasValue && flag2 == true)
			{
				obj = true;
			}
			else
			{
				num = (int?)waypointType;
				flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 21)));
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
				num = (int?)waypointType;
				flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 22)));
				obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
			}
			bool? flag6 = obj2;
			flag5 = obj2;
			bool? obj3;
			bool? flag7;
			if (flag5.HasValue && flag6 == true)
			{
				obj3 = true;
			}
			else
			{
				num = (int?)waypointType;
				flag5 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 23)));
				obj3 = ((!flag5.HasValue) ? ((bool?)null) : ((flag7 == true) | flag6));
			}
			bool? flag8 = obj3;
			flag7 = obj3;
			bool? obj4;
			bool? flag9;
			if (flag7.HasValue && flag8 == true)
			{
				obj4 = true;
			}
			else
			{
				num = (int?)waypointType;
				flag7 = (flag9 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 24)));
				obj4 = ((!flag7.HasValue) ? ((bool?)null) : ((flag9 == true) | flag8));
			}
			flag9 = obj4;
			if (flag9 != true)
			{
				num = (int?)waypointType;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 11)) == true)
				{
					return false;
				}
				num = (int?)waypointType;
				flag5 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)));
				bool? obj5;
				if (flag5.HasValue && flag7 == true)
				{
					obj5 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag5 = (flag6 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 14)));
					obj5 = ((!flag5.HasValue) ? ((bool?)null) : ((flag6 == true) | flag7));
				}
				flag9 = obj5;
				flag6 = obj5;
				bool? obj6;
				if (flag6.HasValue && flag9 == true)
				{
					obj6 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag6 = (flag8 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)));
					obj6 = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag9));
				}
				flag8 = obj6;
				if (flag8 == true)
				{
					Waypoint[] plottedCourse = PlottedCourse;
					foreach (Waypoint waypoint in plottedCourse)
					{
						if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							switch (waypoint.Type)
							{
							case Waypoint.WaypointType.StationStart_Racetrack:
							case Waypoint.WaypointType.StationStart_FigureEight:
							case Waypoint.WaypointType.StationStart_Area:
							case Waypoint.WaypointType.StationStart_RaceTrackRandom:
							case Waypoint.WaypointType.StationEnd:
								return true;
							default:
								return false;
							case Waypoint.WaypointType.LandingMarshal:
								return false;
							}
						}
					}
					return false;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_HoldOrAssemble
	{
		get
		{
			if (!HasPlottedCourse() | (PlottedCourse.Count() == 0))
			{
				return false;
			}
			int result;
			switch (PlottedCourse[0].Type)
			{
			case Waypoint.WaypointType.HoldStart:
			case Waypoint.WaypointType.HoldEnd:
				result = 1;
				break;
			default:
				return false;
			case Waypoint.WaypointType.Assemble:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_StationEgressRun
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint.WaypointType? waypointType = PlottedCourse.FirstOrDefault()?.Type;
				int? num = (int?)waypointType;
				bool? flag2;
				bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 20)));
				bool? obj;
				bool? flag3;
				if (flag.HasValue && flag2 == true)
				{
					obj = true;
				}
				else
				{
					num = (int?)waypointType;
					flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 21)));
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
					num = (int?)waypointType;
					flag3 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 22)));
					obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
				}
				bool? flag6 = obj2;
				flag5 = obj2;
				bool? obj3;
				bool? flag7;
				if (flag5.HasValue && flag6 == true)
				{
					obj3 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag5 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 23)));
					obj3 = ((!flag5.HasValue) ? ((bool?)null) : ((flag7 == true) | flag6));
				}
				bool? flag8 = obj3;
				flag7 = obj3;
				bool? obj4;
				bool? flag9;
				if (flag7.HasValue && flag8 == true)
				{
					obj4 = true;
				}
				else
				{
					num = (int?)waypointType;
					flag7 = (flag9 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 24)));
					obj4 = ((!flag7.HasValue) ? ((bool?)null) : ((flag9 == true) | flag8));
				}
				flag9 = obj4;
				if (flag9 != true)
				{
					num = (int?)waypointType;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 11)) == true)
					{
						return true;
					}
					num = (int?)waypointType;
					flag5 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)));
					bool? obj5;
					if (flag5.HasValue && flag7 == true)
					{
						obj5 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag5 = (flag6 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 14)));
						obj5 = ((!flag5.HasValue) ? ((bool?)null) : ((flag6 == true) | flag7));
					}
					flag9 = obj5;
					flag6 = obj5;
					bool? obj6;
					if (flag6.HasValue && flag9 == true)
					{
						obj6 = true;
					}
					else
					{
						num = (int?)waypointType;
						flag6 = (flag8 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)));
						obj6 = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag9));
					}
					flag8 = obj6;
					if (flag8 == true)
					{
						Waypoint[] plottedCourse = PlottedCourse;
						int num2 = 0;
						Waypoint waypoint;
						while (true)
						{
							if (num2 < plottedCourse.Length)
							{
								waypoint = plottedCourse[num2];
								if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
								{
									break;
								}
								num2 = checked(num2 + 1);
								continue;
							}
							return false;
						}
						Waypoint.WaypointType type = waypoint.Type;
						if (type != Waypoint.WaypointType.LandingMarshal)
						{
							return false;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_OnStation
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint.WaypointType type = PlottedCourse[0].Type;
				if ((uint)(type - 20) > 4u)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_AttackEgressRun
	{
		get
		{
			int result;
			if (HasPlottedCourse())
			{
				if (!myUnit.AI.IsEscort)
				{
					Waypoint.WaypointType type = PlottedCourse[0].Type;
					if (type > Waypoint.WaypointType.TurningPoint)
					{
						if (type == Waypoint.WaypointType.Formate || type == Waypoint.WaypointType.StrikeEgress)
						{
							return true;
						}
						if (type != Waypoint.WaypointType.Refuel)
						{
							result = 0;
							goto IL_0051;
						}
					}
					else if (type != Waypoint.WaypointType.PathfindingPoint && type != Waypoint.WaypointType.TurningPoint)
					{
						result = 0;
						goto IL_0051;
					}
					Waypoint[] plottedCourse = PlottedCourse;
					int num = 0;
					Waypoint waypoint;
					while (true)
					{
						if (num < plottedCourse.Length)
						{
							waypoint = plottedCourse[num];
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								break;
							}
							num = checked(num + 1);
							continue;
						}
						return false;
					}
					int result2;
					switch (waypoint.Type)
					{
					case Waypoint.WaypointType.StrikeEgress:
						result2 = 1;
						break;
					default:
						return false;
					case Waypoint.WaypointType.Formate:
						result2 = 1;
						break;
					}
					return (byte)result2 != 0;
				}
				return false;
			}
			return false;
			IL_0051:
			return (byte)result != 0;
		}
	}

	public bool IsOnReturningLegFlightPlan
	{
		get
		{
			bool result = default(bool);
			try
			{
				if (myUnit.AI.IsEscort)
				{
					result = false;
					return result;
				}
				if (!myUnit.Navigator.HasFlightPlan)
				{
					result = false;
					return result;
				}
				int num = 0;
				Waypoint[] flightPlan = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
				ActiveUnit groupLead = default(ActiveUnit);
				foreach (Waypoint waypoint in flightPlan)
				{
					if (waypoint.Type != Waypoint.WaypointType.WeaponLaunch)
					{
						num++;
						continue;
					}
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && !myUnit.IsGroupLead())
					{
						if (myUnit.IsGroupMember())
						{
							groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
						}
					}
					else
					{
						groupLead = myUnit;
					}
					if (groupLead.Navigator.PlottedCourse.Count() > 0 && groupLead.Navigator.PlottedCourse[0].Category == Waypoint.WaypointCategory.FlightPlan)
					{
						if (groupLead.Navigator.PlottedCourse.Count() < myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Length - num)
						{
							bool flag = false;
							if (myUnit.AI.PrimaryTarget != null)
							{
								float num2 = Module_Unit.BearingToUnit_Relative(myUnit, myUnit.AI.PrimaryTarget);
								int num3 = 1;
								Waypoint waypoint2 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num + 1];
								while (waypoint2.Type == Waypoint.WaypointType.WeaponTarget)
								{
									waypoint2 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num + num3];
									num3++;
								}
								float num4 = Module_Unit.BearingToPoint_Relative(myUnit, waypoint2.Latitude, myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num].Longitude);
								if (GetMinimumBearing(num2, num4) == (double)num4)
								{
									flag = true;
								}
							}
							if (!(Module_Unit.RangeToPoint_Horiz(myUnit, myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num + 1]) < Module_Unit.RangeToPoint_Horiz(myUnit, myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num]) || flag))
							{
								result = false;
								return result;
							}
							result = true;
							return result;
						}
						result = false;
						return result;
					}
					if (myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Count() <= num + 1 && Module_Unit.RangeToPoint_Horiz(myUnit, waypoint) > 20f)
					{
						result = true;
						return result;
					}
					if (Module_Unit.RangeToPoint_Horiz(myUnit, myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num + 1]) < Module_Unit.RangeToPoint_Horiz(myUnit, myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[num]))
					{
						result = true;
						return result;
					}
					result = false;
					return result;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if ((object)ex2.GetType() == typeof(IndexOutOfRangeException))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					ex2?.Data.Add("Error at 321654321684", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_HasLeftTargetArea
	{
		get
		{
			if (!HasPlottedCourse())
			{
				return false;
			}
			if (Information.IsNothing((object)PreviousWaypointType))
			{
				return false;
			}
			if (!myUnit.AI.IsEscort)
			{
				Waypoint.WaypointType? previousWaypointType = PreviousWaypointType;
				int? num = (int?)previousWaypointType;
				bool? flag2;
				bool? flag = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 13)));
				bool? obj;
				bool? flag3;
				if (flag.HasValue && flag2 == true)
				{
					obj = true;
				}
				else
				{
					num = (int?)previousWaypointType;
					flag = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 9)));
					obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
				}
				flag3 = obj;
				if (flag3 == true)
				{
					return true;
				}
				num = (int?)previousWaypointType;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 11)) == true)
				{
					return true;
				}
				num = (int?)previousWaypointType;
				bool? flag4 = (flag = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 6)));
				bool? obj2;
				bool? flag5;
				if (flag4.HasValue && flag == true)
				{
					obj2 = true;
				}
				else
				{
					num = (int?)previousWaypointType;
					flag4 = (flag5 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 14)));
					obj2 = ((!flag4.HasValue) ? ((bool?)null) : ((flag5 == true) | flag));
				}
				flag3 = obj2;
				flag5 = obj2;
				bool? obj3;
				if (flag5.HasValue && flag3 == true)
				{
					obj3 = true;
				}
				else
				{
					num = (int?)previousWaypointType;
					flag5 = (flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)));
					obj3 = ((!flag5.HasValue) ? ((bool?)null) : ((flag2 == true) | flag3));
				}
				flag2 = obj3;
				if (flag2 != true)
				{
					return false;
				}
				Waypoint[] plottedCourse = PlottedCourse;
				int num2 = 0;
				Waypoint waypoint;
				while (true)
				{
					if (num2 < plottedCourse.Length)
					{
						waypoint = plottedCourse[num2];
						if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							break;
						}
						num2 = checked(num2 + 1);
						continue;
					}
					return false;
				}
				int result;
				switch (waypoint.Type)
				{
				default:
					result = 0;
					goto IL_0379;
				case Waypoint.WaypointType.LandingMarshal:
					return true;
				case Waypoint.WaypointType.Target:
				case Waypoint.WaypointType.StrikeIngress:
					result = 0;
					goto IL_0379;
				case Waypoint.WaypointType.Formate:
				case Waypoint.WaypointType.StrikeEgress:
					{
						return true;
					}
					IL_0379:
					return (byte)result != 0;
				}
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse_HasObjectiveWaypoints
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint[] plottedCourse = PlottedCourse;
				for (int i = 0; i < plottedCourse.Length; i = checked(i + 1))
				{
					switch (plottedCourse[i].Type)
					{
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
						return true;
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnAutoPlannerPlottedCourse
	{
		get
		{
			if (HasPlottedCourse())
			{
				Waypoint[] plottedCourse = PlottedCourse;
				for (int i = 0; i < plottedCourse.Length; i = checked(i + 1))
				{
					switch (plottedCourse[i].Type)
					{
					case Waypoint.WaypointType.PathfindingPoint:
					case Waypoint.WaypointType.TurningPoint:
					case Waypoint.WaypointType.Refuel:
					{
						Waypoint[] plottedCourse2 = PlottedCourse;
						foreach (Waypoint waypoint in plottedCourse2)
						{
							int result;
							if (waypoint.Type != Waypoint.WaypointType.TurningPoint && waypoint.Type != Waypoint.WaypointType.Refuel && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
							{
								switch (waypoint.Type)
								{
								default:
									result = 0;
									goto IL_015c;
								case Waypoint.WaypointType.StationStart_Racetrack:
								case Waypoint.WaypointType.StationStart_FigureEight:
								case Waypoint.WaypointType.StationStart_Area:
								case Waypoint.WaypointType.StationStart_RaceTrackRandom:
								case Waypoint.WaypointType.StationEnd:
									return true;
								case Waypoint.WaypointType.TurningPoint:
								case Waypoint.WaypointType.Refuel:
								case Waypoint.WaypointType.TakeOff:
								case Waypoint.WaypointType.Marshal:
								case Waypoint.WaypointType.Land:
								case Waypoint.WaypointType.PickupPoint:
									result = 0;
									goto IL_015c;
								case Waypoint.WaypointType.Assemble:
								case Waypoint.WaypointType.InitialPoint:
								case Waypoint.WaypointType.Split:
								case Waypoint.WaypointType.Formate:
								case Waypoint.WaypointType.Target:
								case Waypoint.WaypointType.LandingMarshal:
								case Waypoint.WaypointType.StrikeIngress:
								case Waypoint.WaypointType.StrikeEgress:
								case Waypoint.WaypointType.WeaponLaunch:
								case Waypoint.WaypointType.WeaponTarget:
								case Waypoint.WaypointType.HoldStart:
								case Waypoint.WaypointType.HoldEnd:
									{
										return true;
									}
									IL_015c:
									return (byte)result != 0;
								}
							}
						}
						break;
					}
					case Waypoint.WaypointType.StationStart_Racetrack:
					case Waypoint.WaypointType.StationStart_FigureEight:
					case Waypoint.WaypointType.StationStart_Area:
					case Waypoint.WaypointType.StationStart_RaceTrackRandom:
					case Waypoint.WaypointType.StationEnd:
						return true;
					case Waypoint.WaypointType.Assemble:
					case Waypoint.WaypointType.InitialPoint:
					case Waypoint.WaypointType.Split:
					case Waypoint.WaypointType.Formate:
					case Waypoint.WaypointType.Target:
					case Waypoint.WaypointType.LandingMarshal:
					case Waypoint.WaypointType.StrikeIngress:
					case Waypoint.WaypointType.StrikeEgress:
					case Waypoint.WaypointType.WeaponLaunch:
					case Waypoint.WaypointType.WeaponTarget:
					case Waypoint.WaypointType.HoldStart:
					case Waypoint.WaypointType.HoldEnd:
						return true;
					}
				}
				return false;
			}
			return false;
		}
	}

	public bool IsOnLocalizationRun
	{
		get
		{
			if (PlottedCourse.Count() > 0)
			{
				return PlottedCourse[0].Type == Waypoint.WaypointType.LocalizationRun;
			}
			return false;
		}
	}

	public bool HasPathfindingPlottedCourse
	{
		get
		{
			Waypoint[] plottedCourse = PlottedCourse;
			bool result;
			try
			{
				result = plottedCourse != null && plottedCourse.Length != 0 && plottedCourse[0] != null && plottedCourse[0].Type == Waypoint.WaypointType.PathfindingPoint;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool NextWaypointIsManual
	{
		get
		{
			if (!HasPlottedCourse())
			{
				return false;
			}
			return PlottedCourse[0].Type == Waypoint.WaypointType.ManualPlottedCourseWaypoint;
		}
	}

	public bool HasFlight => !Information.IsNothing((object)this.get_Flight(HierarchySearch: true));

	public bool HasFlightPlan
	{
		get
		{
			bool result = default(bool);
			try
			{
				Waypoint[] array = this.get_Flight(HierarchySearch: true)?.FlightPlan;
				if (array == null)
				{
					result = false;
					return result;
				}
				result = array.Length > 0;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101249", "");
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

	public virtual bool UseCostBasedPathfinder
	{
		get
		{
			if (Information.IsNothing((object)nullable_0))
			{
				if (myUnit.IsAircraft)
				{
					nullable_0 = false;
				}
				else
				{
					nullable_0 = true;
				}
			}
			return nullable_0.Value;
		}
	}

	public FlightPlanInfo FlightInfo
	{
		[CompilerGenerated]
		get
		{
			return flightPlanInfo_0;
		}
		[CompilerGenerated]
		set
		{
			flightPlanInfo_0 = value;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private bool method_0()
	{
		return bciLhEoqoLV;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(bool bool_4)
	{
		bciLhEoqoLV = bool_4;
	}

	private int method_2(int int_1)
	{
		if (int_1 < 0 && int_1 != -97 && int_1 != -98 && int_1 != -99)
		{
			int_1 = 0;
		}
		return int_1;
	}

	public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("ActiveUnit_Navigator");
			if (!myUnit.IsGroupLead() && PlottedCourse.Count() > 0)
			{
				theWriter.WriteStartElement("PC");
				List<Waypoint> list = new List<Waypoint>();
				list.AddRange(PlottedCourse);
				foreach (Waypoint item in list)
				{
					if (!Information.IsNothing((object)item))
					{
						item.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
					}
				}
				theWriter.WriteEndElement();
			}
			if (PlottedCourse_PrePlanned.Count() > 0)
			{
				theWriter.WriteStartElement("PC_PP");
				List<Waypoint> list2 = new List<Waypoint>();
				list2.AddRange(PlottedCourse_PrePlanned);
				foreach (Waypoint item2 in list2)
				{
					if (!Information.IsNothing((object)item2))
					{
						item2.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)_Flight))
			{
				theWriter.WriteElementString("Flight", _Flight.ObjectID);
			}
			theWriter.WriteElementString("MPO", ManualPlotOverride.ToString());
			if (!Information.IsNothing((object)TankerFollowsMe))
			{
				theWriter.WriteElementString("TankerFollowsMe", TankerFollowsMe.Value.ToString());
			}
			if (TankerFollowsMe_NumberOfWaypoints != 0)
			{
				theWriter.WriteElementString("TankerFollowsMe_NumberOfWaypoints", TankerFollowsMe_NumberOfWaypoints.ToString());
			}
			if (myUnit.IsGroupMember())
			{
				if (UnitFormationStation.Bearing != 0f)
				{
					theWriter.WriteElementString("FS_B", XmlConvert.ToString(UnitFormationStation.Bearing));
				}
				if (UnitFormationStation.Distance != 0f)
				{
					theWriter.WriteElementString("FS_D", XmlConvert.ToString(UnitFormationStation.Distance));
				}
				theWriter.WriteElementString("FS_BT", XmlConvert.ToString((byte)UnitFormationStation.BearingType));
			}
			if (!Information.IsNothing((object)SupportMission_NextRefPoint))
			{
				theWriter.WriteStartElement("SM_NRP");
				theWriter.WriteRaw(SupportMission_NextRefPoint.ToXML(ref ObjectsAlreadySerialized));
				theWriter.WriteEndElement();
			}
			if (PreviousWaypointTime.HasValue)
			{
				theWriter.WriteElementString("PreviousWaypointTime", PreviousWaypointTime.Value.ToBinary().ToString());
			}
			if (PreviousWaypointType.HasValue)
			{
				theWriter.WriteElementString("PreviousWaypointType", PreviousWaypointType.Value.ToString());
			}
			theWriter.WriteElementString("TTNPC", ManualPlotOverride.ToString());
			if (SprintDrift)
			{
				theWriter.WriteElementString("SD", "True");
				theWriter.WriteElementString("SD_Avg", XmlConvert.ToString(SprintDrift_AverageSpeed.Value));
				theWriter.WriteElementString("SD_M", XmlConvert.ToString(SprintDrift_Marker.Longitude) + "_" + XmlConvert.ToString(SprintDrift_Marker.Latitude));
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100199", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static ActiveUnit_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected O, but got Unknown
		ActiveUnit_Navigator result;
		try
		{
			ActiveUnit_Navigator activeUnit_Navigator = new ActiveUnit_Navigator(ref theAU);
			activeUnit_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "TankerFollowsMe_NumberOfWaypoints":
					activeUnit_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(val.InnerText);
					break;
				case "SD_M":
				{
					string[] array = val.InnerText.Split(new char[1] { '_' });
					activeUnit_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					activeUnit_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "Flight":
					activeUnit_Navigator._Flight_ID = val.InnerText;
					break;
				case "PreviousWaypointType":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						activeUnit_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					else
					{
						activeUnit_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "SD":
					activeUnit_Navigator.SprintDrift = true;
					break;
				case "SD_Avg":
					activeUnit_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MPO":
				case "ManualPlotOverride":
					activeUnit_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "TimeToNextPathfinderCheck":
				case "TTNPC":
					activeUnit_Navigator.TimeToNextPathfinderCheck = Conversions.ToSingle(val.InnerText);
					if (activeUnit_Navigator.TimeToNextPathfinderCheck > 15f)
					{
						activeUnit_Navigator.TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(2, 15);
					}
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					activeUnit_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode4 = val.ChildNodes[0];
					activeUnit_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode4, ref theDictionary, theAU.ParentScen);
					break;
				}
				case "FS_BT":
					activeUnit_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint theAC2 = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						ArrayExtensions.Add(ref activeUnit_Navigator._PlottedCourse, theAC2);
					}
					break;
				case "PC_PP":
					foreach (XmlNode childNode3 in val.ChildNodes)
					{
						XmlNode theNode2 = childNode3;
						Waypoint theAC = Waypoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
						ArrayExtensions.Add(ref activeUnit_Navigator._PlottedCourse_PrePlanned, theAC);
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					activeUnit_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "TankerFollowsMe":
					activeUnit_Navigator.TankerFollowsMe = Misc.ParseBool(val.InnerText);
					break;
				}
			}
			result = activeUnit_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100200", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void PostDeserializationHousekeeping(ref Scenario theScen, ConcurrentDictionary<string, ScenarioObject> theDictionary, bool GameIsRunning)
	{
		if (!myUnit.IsAircraft)
		{
			return;
		}
		bool flag = false;
		if (myUnit.get_UnitSide(SetSideOnly: false) == null)
		{
			return;
		}
		foreach (Mission mission in myUnit.get_UnitSide(SetSideOnly: false).Missions)
		{
			if (myUnit.ActiveMissionOrPackage() != mission || !mission.HasFlights())
			{
				continue;
			}
			foreach (Mission.Flight flight in mission.FlightList)
			{
				if (!Information.IsNothing((object)flight.ObjectID) && Operators.CompareString(flight.ObjectID, _Flight_ID, false) == 0)
				{
					this.set_Flight(HierarchySearch: true, flight);
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

	public virtual void ResetTimeToNextPathfinderCheck()
	{
		if (TimeToNextPathfinderCheck > 2f)
		{
			TimeToNextPathfinderCheck = 2f;
		}
	}

	internal float GetSprintDriftDistance()
	{
		float num = 0f;
		float num2 = 0f;
		if (!myUnit.IsGroupWingman())
		{
			if (PlottedCourse.Length > 0 && !Information.IsNothing((object)PlottedCourse.First()))
			{
				num2 = Module_Unit.RangeToPoint_Horiz(myUnit, PlottedCourse.First().Latitude, PlottedCourse.First().Longitude);
			}
			num = num2;
			if (!Information.IsNothing((object)SprintDrift_Marker) && !Information.IsNothing((object)SprintDrift_AverageSpeed) && myUnit.DesiredSpeed > 0f)
			{
				float num3 = Module_Unit.RangeToPoint_Horiz(myUnit, SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude);
				switch (myUnit.Kinematics.SprintAndDriftCadence)
				{
				case ActiveUnit_Kinematics._SprintAndDriftCadence.Drift:
				{
					float desiredSpeed = myUnit.DesiredSpeed;
					float? sprintDrift_AverageSpeed = SprintDrift_AverageSpeed;
					if (((!sprintDrift_AverageSpeed.HasValue) ? ((bool?)null) : new bool?(desiredSpeed < sprintDrift_AverageSpeed.GetValueOrDefault())) == true)
					{
						num = (6f - num3) / (SprintDrift_AverageSpeed.Value - myUnit.DesiredSpeed) * myUnit.DesiredSpeed;
					}
					break;
				}
				case ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint:
				{
					float desiredSpeed = myUnit.DesiredSpeed;
					float? sprintDrift_AverageSpeed = SprintDrift_AverageSpeed;
					if (((!sprintDrift_AverageSpeed.HasValue) ? ((bool?)null) : new bool?(desiredSpeed > sprintDrift_AverageSpeed.GetValueOrDefault())) == true)
					{
						num = num3 / (myUnit.DesiredSpeed - SprintDrift_AverageSpeed.Value) * myUnit.DesiredSpeed;
					}
					break;
				}
				}
			}
			if (num > num2)
			{
				num = num2;
			}
			return num;
		}
		return 0f;
	}

	public void SetSprintDriftMarker(bool ResetAverageSpeed)
	{
		SprintDrift_Marker = new GeoPoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null));
		if (ResetAverageSpeed)
		{
			SprintDrift_AverageSpeed = myUnit.DesiredSpeed;
		}
		myUnit.Kinematics.DesiredSpeedOverride = null;
	}

	public void PerformSprintDrift(float elapsedTime)
	{
		try
		{
			if (Debugger.IsAttached && !myUnit.ParentScen.SecondIsChangingOnThisPulse)
			{
				Debugger.Break();
			}
			float num = Math.Max(1f, elapsedTime);
			if (SprintDrift_Marker == null)
			{
				SprintDrift_Marker = new GeoPoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			}
			if (!SprintDrift_AverageSpeed.HasValue)
			{
				SprintDrift_AverageSpeed = myUnit.DesiredSpeed;
			}
			float? sprintDrift_AverageSpeed = SprintDrift_AverageSpeed;
			if ((sprintDrift_AverageSpeed.HasValue ? new bool?(sprintDrift_AverageSpeed.GetValueOrDefault() <= 0f) : ((bool?)null)) == true && !myUnit.IsGroupWingman())
			{
				myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
				SprintDrift_AverageSpeed = myUnit.DesiredSpeed;
			}
			float bearing;
			if (!myUnit.IsGroupWingman())
			{
				if (!SprintDrift_AverageSpeed.HasValue)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				if (PlottedCourse.Length == 0)
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					SetSprintDriftMarker(ResetAverageSpeed: false);
					return;
				}
				if (Math.Abs(MathFunctions.AngularDifference(Module_Unit.BearingToPoint_True(myUnit, PlottedCourse.First().Latitude, PlottedCourse.First().Longitude), myUnit.CurrentHeading)) > 2f)
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Module_Unit.BearingToPoint_True(myUnit, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude));
					SetSprintDriftMarker(ResetAverageSpeed: false);
					return;
				}
				double distance_NM = SprintDrift_AverageSpeed.Value * (num / 3600f);
				GeoPoint geoPoint = PlottedCourse.First();
				bearing = Math2.CalcAzimuth(SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude, geoPoint.Latitude, geoPoint.Longitude);
				double longitude = SprintDrift_Marker.Longitude;
				double latitude = SprintDrift_Marker.Latitude;
				GeoPoint sprintDrift_Marker;
				double out_lon = (sprintDrift_Marker = SprintDrift_Marker).Longitude;
				GeoPoint sprintDrift_Marker2;
				double out_lat = (sprintDrift_Marker2 = SprintDrift_Marker).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams_NoRef(longitude, latitude, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
				sprintDrift_Marker2.Latitude = out_lat;
				sprintDrift_Marker.Longitude = out_lon;
			}
			else
			{
				ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				if (groupLead == null)
				{
					return;
				}
				double lon = groupLead.get_Longitude((GlobalVariables.BooleanObject)null);
				double lat = groupLead.get_Latitude((GlobalVariables.BooleanObject)null);
				GeoPoint sprintDrift_Marker2;
				double out_lat = (sprintDrift_Marker2 = SprintDrift_Marker).Longitude;
				GeoPoint sprintDrift_Marker;
				double out_lon = (sprintDrift_Marker = SprintDrift_Marker).Latitude;
				Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lat, ref out_lon, UnitFormationStation.Distance, UnitFormationStation.get_ResultantBearing(myUnit));
				sprintDrift_Marker.Latitude = out_lon;
				sprintDrift_Marker2.Longitude = out_lat;
				bearing = groupLead.CurrentHeading;
				if (groupLead.Navigator.SprintDrift)
				{
					SprintDrift_AverageSpeed = groupLead.Navigator.SprintDrift_AverageSpeed;
				}
				else
				{
					SprintDrift_AverageSpeed = groupLead.DesiredSpeed;
				}
			}
			switch (myUnit.Kinematics.SprintAndDriftCadence)
			{
			case ActiveUnit_Kinematics._SprintAndDriftCadence.Drift:
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, bearing);
				myUnit.DesiredSpeed = Math.Max(2f, Math.Min(myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false), SprintDrift_AverageSpeed.Value - 1f));
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				if (Module_Unit.RangeToPoint_Horiz(myUnit, SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude) > 6f)
				{
					myUnit.Kinematics.SprintAndDriftCadence = ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint;
				}
				break;
			case ActiveUnit_Kinematics._SprintAndDriftCadence.Sprint:
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), SprintDrift_Marker.Latitude, SprintDrift_Marker.Longitude));
				myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				if (myUnit.Navigator.AvoidCavitation)
				{
					myUnit.Kinematics.AdjustSpeedForCavitation();
				}
				ActiveUnit.Throttle throttleSuitableForThisSpeed = myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.DesiredSpeed);
				if (throttleSuitableForThisSpeed > ActiveUnit.Throttle.Cruise && myUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries && Operators.CompareString(myUnit.ParentScen.GetCurrentSide().ObjectID, myUnit.get_UnitSide(SetSideOnly: false).ObjectID, false) != 0)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					SetSprintDriftMarker(ResetAverageSpeed: false);
				}
				else
				{
					myUnit.SetThrottle(throttleSuitableForThisSpeed);
				}
				if (HaveReachedPoint(SprintDrift_Marker, elapsedTime))
				{
					myUnit.Kinematics.SprintAndDriftCadence = ActiveUnit_Kinematics._SprintAndDriftCadence.Drift;
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101419", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_3(Waypoint waypoint_0)
	{
		if (waypoint_0 == null)
		{
			return false;
		}
		List<Waypoint> list = new List<Waypoint>();
		Waypoint[] plottedCourse = PlottedCourse;
		foreach (Waypoint waypoint in plottedCourse)
		{
			if (waypoint == waypoint_0)
			{
				break;
			}
			list.Add(waypoint);
		}
		PlottedCourse = PlottedCourse.Except(list).ToArray();
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && myUnit.IsGroupLead())
		{
			int num = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Count - 1;
			for (int j = 0; j <= num; j++)
			{
				ActiveUnit activeUnit = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ElementAtOrDefault(j);
				if (activeUnit != myUnit && activeUnit.Navigator._ResumeFlightPlanWaypoint == null)
				{
					if (_ResumeFlightPlanWaypoint != null)
					{
						activeUnit.Navigator._ResumeFlightPlanWaypoint = _ResumeFlightPlanWaypoint;
					}
					else
					{
						activeUnit.Navigator._ResumeFlightPlanWaypoint = PlottedCourse.FirstOrDefault();
					}
					activeUnit.Navigator.method_3(activeUnit.Navigator._ResumeFlightPlanWaypoint);
				}
			}
		}
		_ResumeFlightPlanWaypoint = null;
		return true;
	}

	private Waypoint[] method_4(Waypoint[] waypoint_0)
	{
		Waypoint waypoint = default(Waypoint);
		foreach (Waypoint item in waypoint_0.OrderBy([SpecialName] (Waypoint theP) => Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theP.Latitude, theP.Longitude)).ToList())
		{
			if ((Math.Abs(Module_Unit.BearingToPoint_Relative(myUnit, item.Latitude, item.Longitude)) < 30f) | (Math.Abs(Module_Unit.BearingToPoint_Relative(myUnit, item.Latitude, item.Longitude)) > 330f))
			{
				waypoint = item;
				break;
			}
		}
		if (waypoint == null)
		{
			waypoint = waypoint_0.OrderBy([SpecialName] (Waypoint theP) => Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theP.Latitude, theP.Longitude)).FirstOrDefault();
		}
		if (waypoint != null)
		{
			List<Waypoint> list = new List<Waypoint>();
			Waypoint[] array = waypoint_0;
			foreach (Waypoint waypoint2 in array)
			{
				if (Operators.CompareString(waypoint2.ObjectID, waypoint.ObjectID, false) == 0)
				{
					break;
				}
				list.Add(waypoint2);
			}
			foreach (Waypoint item2 in list)
			{
				ArrayExtensions.Remove(ref waypoint_0, item2);
			}
		}
		return waypoint_0;
	}

	public ActiveUnit_Navigator(ref ActiveUnit theUnit)
	{
		_PlottedCourse = new Waypoint[0];
		_PlottedCourse_PrePlanned = new Waypoint[0];
		TankerIsBlockedByNoNavZone = false;
		TankerFollowsMe = null;
		int_0 = 0;
		TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 0.0;
		CheckNoNavZones_UnitMovementOnEveryPulse = true;
		bool_2 = false;
		WP_reach_cache_memory = new WP_reach_cache();
		nullable_1 = null;
		_ResumeFlightPlanWaypoint = null;
		bool_3 = false;
		myUnit = theUnit;
	}

	public virtual void ClearPlottedCourse(bool PlayerIsPlottingCourse = false, bool ClearResumeFlightPlanWaypoint = true)
	{
		myUnit.DetachFromRoadSystem();
		if (myUnit.IsGroupLead())
		{
			myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.ClearPlottedCourse(PlayerIsPlottingCourse, ClearResumeFlightPlanWaypoint);
		}
		if (PlayerIsPlottingCourse)
		{
			if (!myUnit.IsGroup)
			{
				if (_PlottedCourse.Count() > 0 && _PlottedCourse[0].Category == Waypoint.WaypointCategory.FlightPlan)
				{
					_ResumeFlightPlanWaypoint = _PlottedCourse[0];
				}
			}
			else
			{
				ActiveUnit groupLead = ((Group)myUnit).GroupLead;
				if (groupLead != null && groupLead.Navigator.PlottedCourse.Count() > 0 && groupLead.Navigator.PlottedCourse[0].Category == Waypoint.WaypointCategory.FlightPlan)
				{
					groupLead.Navigator._ResumeFlightPlanWaypoint = groupLead.Navigator.PlottedCourse[0];
					_ResumeFlightPlanWaypoint = groupLead.Navigator._ResumeFlightPlanWaypoint;
				}
			}
		}
		else if (ClearResumeFlightPlanWaypoint)
		{
			_ResumeFlightPlanWaypoint = null;
		}
		ArrayExtensions.Clear(ref _PlottedCourse);
		ArrayExtensions.Clear(ref _PlottedCourse_PrePlanned);
		if (!myUnit.IsGroup)
		{
			Pathfinding.CancelPathfindRequests(myUnit, null);
			PathFindingInProgress = false;
		}
	}

	public virtual void ClearFlight()
	{
		if (myUnit.IsGroupLead())
		{
			myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.ClearFlight();
		}
		else
		{
			this.set_Flight(HierarchySearch: true, (Mission.Flight)null);
		}
	}

	public Waypoint GetNearestAccessibleSpot(double StartLat, double StartLon, ref List<ActiveUnit> ProvidedPiers)
	{
		Waypoint waypoint = null;
		int distance_NM = 1;
		int num = 0;
		double out_lon = default(double);
		double out_lat = default(double);
		while (true)
		{
			int bearing = num;
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ref StartLon, ref StartLat, ref out_lon, ref out_lat, ref distance_NM, ref bearing);
				ActiveUnit activeUnit = myUnit;
				double theLat = out_lat;
				double theLon = out_lon;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (!activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					bearing++;
					continue;
				}
				waypoint = new Waypoint(out_lon, out_lat, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				break;
			}
			while (bearing <= 359);
			if (!Information.IsNothing((object)waypoint))
			{
				break;
			}
			distance_NM++;
			if (distance_NM > 10000)
			{
				break;
			}
			num = 0;
		}
		return waypoint;
	}

	public bool GetNearestAccessibleSpot(double StartLat, double StartLon, ref double DestLat, ref double DestLon, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, bool ManouverTowardsTarget)
	{
		int distance_NM = 1;
		int num = 0;
		while (true)
		{
			int bearing = num;
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ref StartLon, ref StartLat, ref DestLon, ref DestLat, ref distance_NM, ref bearing);
				ActiveUnit activeUnit = myUnit;
				double theLat = DestLat;
				double theLon = DestLon;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (!activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, ProximityThreshold_Deg, ManouverTowardsTarget, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					bearing++;
					continue;
				}
				return true;
			}
			while (bearing <= 359);
			distance_NM++;
			if (distance_NM > 10000)
			{
				break;
			}
			num = 0;
		}
		return false;
	}

	public void Housekeeping(float elapsedTime)
	{
		try
		{
			if (!myUnit.IsFixedFacility)
			{
				TimeToNextPathfinderCheck -= elapsedTime;
				if (TimeToNextPathfinderCheck <= 0f && myUnit.ParentScen.SecondIsChangingOnThisPulse)
				{
					ActiveUnit theUnit = myUnit;
					Exception ThrownError = null;
					if (!Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
					{
						bool_0 = true;
					}
					if (myUnit.IsAircraft)
					{
						TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(30, 61);
					}
					else if (!myUnit.IsFixedFacility)
					{
						if (!myUnit.IsFacility)
						{
							TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(360, 721);
						}
						else
						{
							TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(180, 361);
						}
					}
					else
					{
						TimeToNextPathfinderCheck = float.MaxValue;
					}
					if (myUnit.IsMCMPlatform_ThisPulse == -1)
					{
						myUnit.Determine_IsMCMPlatform();
					}
					if (myUnit.IsMineLayingPlatform_ThisPulse == -1)
					{
						myUnit.Determine_IsMineLayingPlatform();
					}
					if (myUnit.IsMCMPlatform_ThisPulse != 0 && (myUnit.IsShip || myUnit.IsSubmarine))
					{
						Mission mission = myUnit.ActiveMissionOrPackage();
						if (mission != null && mission.MissionClass == Mission._MissionClass.MineClearing)
						{
							MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
							if (mineClearingMission != null && myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(10, 16);
							}
						}
					}
					else
					{
						if (myUnit.IsMineLayingPlatform_ThisPulse == 0 || (!myUnit.IsShip && !myUnit.IsSubmarine))
						{
							return;
						}
						Mission mission2 = myUnit.ActiveMissionOrPackage();
						if (mission2 != null && mission2.MissionClass == Mission._MissionClass.Mining)
						{
							MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
							if (miningMission != null && myUnit.Navigator.IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_5nm_Buffered, ref miningMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
							{
								TimeToNextPathfinderCheck = GameGeneral.GlobalRNG.Next(10, 16);
							}
						}
					}
				}
				else
				{
					bool_0 = false;
				}
			}
			else
			{
				bool_0 = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100201", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool NeedToExtend(double TargetLat, double TargetLon, float Buffer_Seconds, float Buffer_Distance_nm, float theTurnRate, Misc.ExtendPhase Phase = Misc.ExtendPhase.Standard, bool BufferActAsMinimalLineUpRange = false)
	{
		bool result;
		try
		{
			if (Phase != Misc.ExtendPhase.LiningUp && Phase != Misc.ExtendPhase.FinalApproach)
			{
				if (myUnit.CurrentSpeed == 0f)
				{
					result = false;
				}
				else
				{
					float newBearing = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), TargetLat, TargetLon);
					if ((double)Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, newBearing)) >= 0.5)
					{
						float num = Module_Unit.RangeToPoint_Horiz(myUnit, TargetLat, TargetLon);
						float num2;
						if (myUnit.IsWeapon)
						{
							Buffer_Seconds = 0f;
							num2 = 0f;
						}
						else
						{
							num2 = Math.Min(myUnit.CurrentSpeed / (3600f / Buffer_Seconds), Buffer_Distance_nm * 2f);
						}
						float num3 = Misc.TurnRadius(myUnit.CurrentSpeed, theTurnRate);
						float num4 = num2 + Buffer_Distance_nm;
						if (!BufferActAsMinimalLineUpRange && num > num3 * 2f && Phase == Misc.ExtendPhase.Standard)
						{
							result = false;
						}
						else if (Buffer_Distance_nm > 0f && num < num4)
						{
							result = true;
						}
						else
						{
							if (Phase != Misc.ExtendPhase.Extending && Phase != Misc.ExtendPhase.Standard)
							{
								goto IL_0204;
							}
							float bearing;
							float bearing2;
							if (!myUnit.IsWeapon)
							{
								bearing = Math2.NormalizeBearing(myUnit.CurrentHeading - 90f);
								bearing2 = Math2.NormalizeBearing(myUnit.CurrentHeading + 90f);
							}
							else
							{
								bearing = Math2.NormalizeBearing(myUnit.CurrentHeading - 135f);
								bearing2 = Math2.NormalizeBearing(myUnit.CurrentHeading + 135f);
							}
							double out_lon = default(double);
							double out_lat = default(double);
							Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num3 + num4, bearing);
							if (Math2.CalcDist(out_lat, out_lon, TargetLat, TargetLon) < num3 + num4)
							{
								result = true;
							}
							else
							{
								double out_lon2 = default(double);
								double out_lat2 = default(double);
								Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, num3 + num4, bearing2);
								if (!(Math2.CalcDist(out_lat2, out_lon2, TargetLat, TargetLon) < num3 + num4))
								{
									goto IL_0204;
								}
								result = true;
							}
						}
					}
					else
					{
						result = false;
					}
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_0204:
			result = false;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101258", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num5;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num5 = 0;
			}
			else
			{
				num5 = 0;
			}
			result = (byte)num5 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual bool ExtendIfNecessary(float elapsedTime, ref Waypoint theWaypoint, double TargetLat, double TargetLon, float Buffer_Seconds, float Buffer_Distance_nm, float theTurnRate, Misc.ExtendPhase Phase = Misc.ExtendPhase.Standard)
	{
		bool result = default(bool);
		try
		{
			bool flag;
			if (ExtendTimer > 0.0)
			{
				flag = true;
			}
			else if (flag = NeedToExtend(TargetLat, TargetLon, Buffer_Seconds, Buffer_Distance_nm, theTurnRate, Phase, BufferActAsMinimalLineUpRange: true))
			{
				ExtendTimer = 5.0;
			}
			if (flag && !bool_3)
			{
				if (myUnit.IsAircraft && IsOnAutoPlannerPlottedCourse && theWaypoint != null && !theWaypoint.IsStationWaypoint() && !theWaypoint.IsHoldOrAssembleWaypoint() && ((theWaypoint.Type != Waypoint.WaypointType.Target && theWaypoint.Type != Waypoint.WaypointType.WeaponTarget) || myUnit.WeaponState != ActiveUnit._ActiveUnitWeaponState.None))
				{
					bool_3 = true;
					try
					{
						bool ForceWaypointSwitch = true;
						bool ForceStationAbort = false;
						CheckIfReachedWaypoint_AND_Apply_WP_logic(1f, ref ForceWaypointSwitch, ref ForceStationAbort);
					}
					finally
					{
						bool_3 = false;
					}
					ExtendTimer = 0.0;
					result = flag;
					return result;
				}
				if (theWaypoint != null && theWaypoint.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					bool_3 = true;
					try
					{
						bool ForceStationAbort = true;
						bool ForceWaypointSwitch = false;
						CheckIfReachedWaypoint_AND_Apply_WP_logic(1f, ref ForceStationAbort, ref ForceWaypointSwitch);
					}
					finally
					{
						bool_3 = false;
					}
					ExtendTimer = 0.0;
					result = flag;
					return result;
				}
				float value = Math2.CalcAzimuth(TargetLat, TargetLon, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
				ExtendTimer -= elapsedTime;
			}
			result = flag;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100202", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsFinishingSupportMissionCourse(float elapsedTime)
	{
		bool result;
		try
		{
			SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
			if (supportMission.NavigationLoopType != SupportMission.SupportMissionNavigationLoopType.ContinousLoop)
			{
				if (Information.IsNothing((object)SupportMission_NextRefPoint))
				{
					result = false;
				}
				else if (HaveReachedPoint(SupportMission_NextRefPoint, elapsedTime))
				{
					if (supportMission.NavigationCourse.IndexOf(SupportMission_NextRefPoint) == supportMission.NavigationCourse.Count - 1)
					{
						SupportMission_NextRefPoint = null;
						result = true;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
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
			ex2?.Data.Add("Error at 100203", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 1;
			}
			else
			{
				num = 1;
			}
			result = (byte)num != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual void EgressToRejoinPoint(float elapsedTime, bool ForceObjectiveWaypointRemoval)
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
			{
				byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
				bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
				if (((!flag) ?? flag) == true)
				{
					myUnit.Doctrine.set_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.No);
				}
			}
			List<Waypoint> list = PlottedCourse.ToList();
			List<Waypoint> list2 = new List<Waypoint>();
			foreach (Waypoint item in list)
			{
				Waypoint theWaypoint = item;
				if (theWaypoint.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					list2.Add(theWaypoint);
				}
				else if (theWaypoint.Type == Waypoint.WaypointType.InitialPoint || theWaypoint.Type == Waypoint.WaypointType.WeaponLaunch || theWaypoint.Type == Waypoint.WaypointType.Target || theWaypoint.Type == Waypoint.WaypointType.WeaponTarget || theWaypoint.Type == Waypoint.WaypointType.StrikeIngress)
				{
					ApplyWaypointSpeedAltToUnit(theWaypoint);
					ApplyWaypointDoctrineToUnit(theWaypoint);
					list2.Add(theWaypoint);
					AdjustTankerMustFollowMe_NumberOfWaypoints(ref theWaypoint);
				}
			}
			foreach (Waypoint item2 in list2)
			{
				ApplyWaypointSpeedAltToUnit(item2);
				ApplyWaypointDoctrineToUnit(item2);
				RemoveWaypoint_Soft(item2, RemoveWingmanWaypoints: false);
			}
			if (myUnit.Navigator.HasFlight)
			{
				myUnit.Navigator.get_Flight(HierarchySearch: true).set_Status(myUnit.ParentScen, Mission._FlightStatus.Airborne_EgressLeg);
			}
			HeadToFirstWaypoint(elapsedTime);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101371", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AdjustTankerMustFollowMe_NumberOfWaypoints(ref Waypoint theWaypoint)
	{
		if (!Information.IsNothing((object)TankerFollowsMe))
		{
			if (TankerFollowsMe_NumberOfWaypoints == -98)
			{
				if (theWaypoint.IsStationWaypoint())
				{
					TankerFollowsMe = null;
					TankerFollowsMe_NumberOfWaypoints = 0;
				}
			}
			else if (TankerFollowsMe_NumberOfWaypoints == -97)
			{
				if (theWaypoint.IsHoldEndWaypoint())
				{
					TankerFollowsMe = null;
					TankerFollowsMe_NumberOfWaypoints = 0;
				}
			}
			else if (TankerFollowsMe_NumberOfWaypoints == -99)
			{
				if (theWaypoint.Type == Waypoint.WaypointType.LandingMarshal || theWaypoint.Type == Waypoint.WaypointType.Land)
				{
					TankerFollowsMe = null;
					TankerFollowsMe_NumberOfWaypoints = 0;
				}
			}
			else if (PlottedCourse.Count() > 0)
			{
				TankerFollowsMe_NumberOfWaypoints--;
			}
			else
			{
				TankerFollowsMe_NumberOfWaypoints = 0;
			}
			if (!myUnit.IsGroupLead())
			{
				return;
			}
			{
				foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
				{
					if (value != myUnit && !value.Navigator.HasPlottedCourse())
					{
						value.Navigator.TankerFollowsMe = TankerFollowsMe;
						value.Navigator.TankerFollowsMe_NumberOfWaypoints = TankerFollowsMe_NumberOfWaypoints;
					}
				}
				return;
			}
		}
		TankerFollowsMe_NumberOfWaypoints = 0;
	}

	public virtual bool EgressToRejoinPoint_CallOff(float elapsedTime)
	{
		bool result;
		try
		{
			result = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101372", "");
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

	internal void CheckSupportMissionCourseRefPointReached(SupportMission myMission, float elapsedTime)
	{
		if (SupportMission_NextRefPoint == null && myMission.NavigationCourse.Count > 0)
		{
			SupportMission_NextRefPoint = myMission.NavigationCourse[0];
		}
		else if (!myMission.NavigationCourse.Contains(SupportMission_NextRefPoint) && myMission.NavigationCourse.Count > 0)
		{
			SupportMission_NextRefPoint = myMission.NavigationCourse[0];
		}
		if (SupportMission_NextRefPoint == null || !HaveReachedPoint(SupportMission_NextRefPoint, elapsedTime))
		{
			return;
		}
		if (myMission.NavigationCourse.IndexOf(SupportMission_NextRefPoint) == myMission.NavigationCourse.Count - 1)
		{
			if (myMission.NavigationLoopType != SupportMission.SupportMissionNavigationLoopType.ContinousLoop)
			{
				if (myMission.NavigationLoopType != SupportMission.SupportMissionNavigationLoopType.SingleLoop)
				{
					return;
				}
				if (myMission.MarkAsSatisfiedUponReachingDestination)
				{
					((Mission)myMission).set_Phase(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), MissionPhase.Completed);
				}
				SupportMission_NextRefPoint = null;
				if (!myMission.RTBUponCompletion)
				{
					ActiveUnit activeUnit = myUnit;
					Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
					activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				}
				else if (myUnit.IsAircraft)
				{
					if (!GlobalVariables.AI_REWORK)
					{
						myUnit.AirOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true);
					}
					else
					{
						((Aircraft)myUnit).AI.StatusRelatedEvents.method_0(manuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, groupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, detachFromGroup: false, clearPlottedCourse: true);
					}
				}
				else
				{
					myUnit.DockingOps.AttemptToRTB(ManuallyOrdered: false, ActiveUnit._ActiveUnitStatus.RTB_MissionOver, GroupMembersRTB: true, ActiveUnit._ActiveUnitStatus.RTB_Group, DetachFromGroup: false, ClearPlottedCourse: true);
				}
			}
			else
			{
				SupportMission_NextRefPoint = myMission.NavigationCourse[0];
				if (myMission.MarkAsSatisfiedUponReachingDestination)
				{
					((Mission)myMission).set_Phase(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), MissionPhase.Completed);
				}
			}
		}
		else
		{
			SupportMission_NextRefPoint = myMission.NavigationCourse[myMission.NavigationCourse.IndexOf(SupportMission_NextRefPoint) + 1];
		}
	}

	public virtual void FollowSupportMissionCourse(float elapsedTime, bool IsInTransit)
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null || myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Support)
			{
				return;
			}
			SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
			if (supportMission == null || supportMission.NavigationCourse == null || supportMission.NavigationCourse.Count == 0)
			{
				return;
			}
			CheckSupportMissionCourseRefPointReached(supportMission, elapsedTime);
			if (!HasPlottedCourse())
			{
				if (SupportMission_NextRefPoint != null)
				{
					HeadToPoint(SupportMission_NextRefPoint);
					Waypoint theWaypoint = null;
					ExtendIfNecessary(elapsedTime, ref theWaypoint, SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
				}
			}
			else
			{
				FollowPlottedCourse(elapsedTime);
			}
			if (!myUnit.IsAircraft && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (IsInTransit)
				{
					if (!myUnit.IsSubmarine)
					{
						if (myUnit.IsShip)
						{
							myUnit.SetThrottle(supportMission.TransitThrottle_Ship);
						}
						else if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
						}
						else
						{
							myUnit.SetThrottle(supportMission.TransitThrottle_Facility);
						}
					}
					else
					{
						myUnit.SetThrottle(supportMission.TransitThrottle_Submarine);
					}
				}
				else if (myUnit.IsSubmarine)
				{
					if (Information.IsNothing((object)supportMission.StationThrottle_Submarine))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(supportMission.StationThrottle_Submarine);
					}
				}
				else if (myUnit.IsShip)
				{
					if (Information.IsNothing((object)supportMission.StationThrottle_Ship))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(supportMission.StationThrottle_Ship);
					}
				}
				else if (!myUnit.IsFacility && !myUnit.IsMobileGroundUnit)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				else if (Information.IsNothing((object)supportMission.StationThrottle_Facility))
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				else
				{
					myUnit.SetThrottle(supportMission.StationThrottle_Facility);
				}
			}
			if (!myUnit.IsSubmarine)
			{
				return;
			}
			int value = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			Submarine_AI aI = ((Submarine)myUnit).AI;
			if (aI.RiseToPeriscopeDepthForRechargeIfNecessary(value, UseAIPifAvailable: false, IsAttackRechargeSetting: false) || myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			if (IsInTransit)
			{
				if (supportMission.TransitDepth_Submarine.HasValue)
				{
					float value2 = supportMission.TransitDepth_Submarine.Value;
					if (Math.Round(value2) >= -20.0 && !aI.IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
					{
						myUnit.DesiredAltitude = -40f;
					}
					else
					{
						myUnit.DesiredAltitude = value2;
					}
				}
			}
			else if (supportMission.StationDepth_Submarine.HasValue)
			{
				float value3 = supportMission.StationDepth_Submarine.Value;
				if (Math.Round(value3) >= -20.0 && !aI.IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = value3;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100204", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FollowPatrolRepeatableLoopCourse(float elapsedTime, bool IsInTransit)
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null)
			{
				return;
			}
			myUnit.ActiveMissionOrPackage();
			List<ReferencePoint> list;
			float? num;
			float? num2;
			float? transitDepth_Submarine;
			float? stationDepth_Submarine;
			float? num3;
			float? num4;
			float? num5;
			float? num6;
			float? transitAltitude_Aircraft;
			float? stationAltitude_Aircraft;
			switch (myUnit.ActiveMissionOrPackage().MissionClass)
			{
			default:
				return;
			case Mission._MissionClass.Mining:
			{
				MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
				list = miningMission.Area;
				num = (int)miningMission.TransitThrottle_Submarine;
				num2 = (int)miningMission.StationThrottle_Submarine;
				transitDepth_Submarine = miningMission.TransitDepth_Submarine;
				stationDepth_Submarine = miningMission.StationDepth_Submarine;
				num3 = (int)miningMission.TransitThrottle_Ship;
				num4 = (int)miningMission.StationThrottle_Ship;
				num5 = (int?)miningMission.TransitThrottle_Aircraft;
				num6 = (int?)miningMission.StationThrottle_Aircraft;
				transitAltitude_Aircraft = miningMission.TransitAltitude_Aircraft;
				stationAltitude_Aircraft = miningMission.StationAltitude_Aircraft;
				break;
			}
			case Mission._MissionClass.Patrol:
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				list = patrol.PatrolArea;
				num = (int)patrol.TransitThrottle_Submarine;
				num2 = (int)patrol.StationThrottle_Submarine;
				transitDepth_Submarine = patrol.TransitDepth_Submarine;
				stationDepth_Submarine = patrol.StationDepth_Submarine;
				num3 = (int)patrol.TransitThrottle_Ship;
				num4 = (int)patrol.StationThrottle_Ship;
				num5 = (int?)patrol.TransitThrottle_Aircraft;
				num6 = (int?)patrol.StationThrottle_Aircraft;
				transitAltitude_Aircraft = patrol.TransitAltitude_Aircraft;
				stationAltitude_Aircraft = patrol.StationAltitude_Aircraft;
				break;
			}
			}
			if (list.Count == 0)
			{
				return;
			}
			if (SupportMission_NextRefPoint == null)
			{
				SupportMission_NextRefPoint = list[0];
			}
			else if (!list.Contains(SupportMission_NextRefPoint))
			{
				SupportMission_NextRefPoint = list[0];
			}
			if (HaveReachedPoint(SupportMission_NextRefPoint, elapsedTime))
			{
				if (list.IndexOf(SupportMission_NextRefPoint) == list.Count - 1)
				{
					SupportMission_NextRefPoint = list[0];
				}
				else
				{
					SupportMission_NextRefPoint = list[list.IndexOf(SupportMission_NextRefPoint) + 1];
				}
			}
			if (HasPlottedCourse())
			{
				FollowPlottedCourse(elapsedTime);
			}
			else if (SupportMission_NextRefPoint != null)
			{
				HeadToPoint(SupportMission_NextRefPoint);
				Waypoint theWaypoint = null;
				ExtendIfNecessary(elapsedTime, ref theWaypoint, SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
			if (myUnit.IsGroup)
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue || !IsInTransit)
				{
					return;
				}
				ActiveUnit groupLead = ((Group)myUnit).GroupLead;
				if (groupLead != null)
				{
					if (groupLead.IsAircraft)
					{
						Aircraft obj = (Aircraft)groupLead;
						Aircraft_AirOps airOps = obj.AirOps;
						Aircraft_Navigator navigator = obj.Navigator;
						navigator.SetPatrolThrottle(PursueContact: false, airOps.Condition);
						navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
					}
					else if (groupLead.IsSubmarine)
					{
						groupLead.SetThrottle((ActiveUnit.Throttle)Math.Round(num.Value));
					}
					else if (!groupLead.IsShip)
					{
						groupLead.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					else
					{
						groupLead.SetThrottle((ActiveUnit.Throttle)Math.Round(num3.Value));
					}
				}
				return;
			}
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (!IsInTransit)
				{
					if (myUnit.IsSubmarine)
					{
						myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num2.Value));
					}
					else if (myUnit.IsShip)
					{
						myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num4.Value));
					}
					else if (!myUnit.IsAircraft)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num6.Value));
					}
				}
				else if (myUnit.IsSubmarine)
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num.Value));
				}
				else if (!myUnit.IsShip)
				{
					if (myUnit.IsAircraft)
					{
						myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num5.Value));
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
				else
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num3.Value));
				}
			}
			if (myUnit.IsAircraft && !myUnit.Kinematics.DesiredAltitudeOverride)
			{
				if (!IsInTransit)
				{
					if (stationAltitude_Aircraft.HasValue)
					{
						myUnit.DesiredAltitude = stationAltitude_Aircraft.Value;
					}
				}
				else if (transitAltitude_Aircraft.HasValue)
				{
					myUnit.DesiredAltitude = transitAltitude_Aircraft.Value;
				}
			}
			if (!myUnit.IsSubmarine)
			{
				return;
			}
			int value = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			Submarine_AI aI = ((Submarine)myUnit).AI;
			if (aI.RiseToPeriscopeDepthForRechargeIfNecessary(value, UseAIPifAvailable: false, IsAttackRechargeSetting: false) || myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			if (IsInTransit)
			{
				if (transitDepth_Submarine.HasValue)
				{
					float value2 = transitDepth_Submarine.Value;
					if (Math.Round(value2) >= -20.0 && !aI.IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
					{
						myUnit.DesiredAltitude = -40f;
					}
					else
					{
						myUnit.DesiredAltitude = value2;
					}
				}
			}
			else if (stationDepth_Submarine.HasValue)
			{
				float value3 = stationDepth_Submarine.Value;
				if (Math.Round(value3) >= -20.0 && !aI.IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = value3;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10324509326043132845904329", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void FollowPatrolChainsawMovementPattern(float elapsedTime, bool IsInTransit)
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null || (myUnit.IsGroup && ((Group)myUnit).Type != Group.GroupType.AirGroup) || (!myUnit.IsGroup && !myUnit.IsAircraft))
			{
				return;
			}
			Mission mission = myUnit.ActiveMissionOrPackage();
			if (mission.MissionClass != Mission._MissionClass.Patrol)
			{
				return;
			}
			Patrol obj = (Patrol)mission;
			List<ReferencePoint> patrolArea = obj.PatrolArea;
			float? num = (int?)obj.TransitThrottle_Aircraft;
			float? num2 = (int?)obj.StationThrottle_Aircraft;
			if (patrolArea.Count == 0)
			{
				return;
			}
			if (PatrolLoop_NextRefPoint == null || mission.CheckIfStillInSync(myUnit))
			{
				List<ActiveUnit> list = new List<ActiveUnit>();
				foreach (ActiveUnit item in Misc.Values_ToList(mission.UnitsAssignedToMission))
				{
					if (item.IsGroup)
					{
						list.Add(item);
					}
				}
				list.OrderBy([SpecialName] (ActiveUnit t) => t.TimeUnderway).ToList();
				int chainsawStartingPoint = mission.GetChainsawStartingPoint(myUnit);
				if (PatrolLoop_NextRefPoint == null)
				{
					PatrolLoop_NextRefPoint = patrolArea[chainsawStartingPoint];
				}
				else if (!patrolArea.Contains(PatrolLoop_NextRefPoint))
				{
					PatrolLoop_NextRefPoint = patrolArea[chainsawStartingPoint];
				}
			}
			if (PatrolLoop_NextRefPoint != null && HaveReachedPoint(PatrolLoop_NextRefPoint, elapsedTime))
			{
				if (patrolArea.IndexOf(PatrolLoop_NextRefPoint) == patrolArea.Count - 1)
				{
					PatrolLoop_NextRefPoint = patrolArea[0];
				}
				else
				{
					PatrolLoop_NextRefPoint = patrolArea[patrolArea.IndexOf(PatrolLoop_NextRefPoint) + 1];
				}
			}
			if (PatrolLoop_NextRefPoint != null)
			{
				if (mission.CheckIfStillInSync(myUnit))
				{
					float chainsawSpeedOverwirte = mission.GetChainsawSpeedOverwirte(myUnit);
					myUnit.Kinematics.DesiredSpeedOverride = chainsawSpeedOverwirte;
				}
				HeadToPoint(PatrolLoop_NextRefPoint);
				Waypoint theWaypoint = null;
				ExtendIfNecessary(elapsedTime, ref theWaypoint, PatrolLoop_NextRefPoint.Latitude, PatrolLoop_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
			if (myUnit.IsGroup)
			{
				if (!IsInTransit)
				{
					return;
				}
				ActiveUnit groupLead = ((Group)myUnit).GroupLead;
				if (groupLead != null)
				{
					if (groupLead.IsAircraft)
					{
						Aircraft obj2 = (Aircraft)groupLead;
						Aircraft_AirOps airOps = obj2.AirOps;
						Aircraft_Navigator navigator = obj2.Navigator;
						navigator.SetPatrolThrottle(PursueContact: false, airOps.Condition);
						navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
					}
					else
					{
						groupLead.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
				}
			}
			else if (!IsInTransit)
			{
				if (!myUnit.IsAircraft)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
				}
				else
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num2.Value));
				}
			}
			else if (myUnit.IsAircraft)
			{
				myUnit.SetThrottle((ActiveUnit.Throttle)Math.Round(num.Value));
			}
			else
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10324509326043132845904329", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void FollowMineClearingMissionCourse(float elapsedTime, bool IsInTransit)
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null || myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.MineClearing)
			{
				return;
			}
			MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
			if (mineClearingMission == null || mineClearingMission.Area == null || mineClearingMission.Area.Count == 0)
			{
				return;
			}
			if (SupportMission_NextRefPoint != null)
			{
				if (!mineClearingMission.Area.Contains(SupportMission_NextRefPoint))
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[0];
				}
			}
			else
			{
				ReferencePoint referencePoint = null;
				double num = 0.0;
				foreach (ReferencePoint item in mineClearingMission.Area)
				{
					double num2 = Math2.CalcDist_Angular(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), item.Latitude, item.Longitude);
					if (referencePoint != null)
					{
						if (num2 < num)
						{
							referencePoint = item;
							num = num2;
						}
					}
					else
					{
						referencePoint = item;
						num = num2;
					}
				}
				int num3;
				if (referencePoint == null)
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[0];
					num3 = 1;
				}
				else
				{
					SupportMission_NextRefPoint = referencePoint;
					num3 = 1;
				}
				IsInTransit = (byte)num3 != 0;
			}
			if (HaveReachedPoint(SupportMission_NextRefPoint, elapsedTime))
			{
				if (mineClearingMission.Area.IndexOf(SupportMission_NextRefPoint) == mineClearingMission.Area.Count - 1)
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[0];
				}
				else
				{
					SupportMission_NextRefPoint = mineClearingMission.Area[mineClearingMission.Area.IndexOf(SupportMission_NextRefPoint) + 1];
				}
			}
			if (HasPlottedCourse())
			{
				FollowPlottedCourse(elapsedTime);
			}
			else if (SupportMission_NextRefPoint != null)
			{
				HeadToPoint(SupportMission_NextRefPoint);
				Waypoint theWaypoint = null;
				ExtendIfNecessary(elapsedTime, ref theWaypoint, SupportMission_NextRefPoint.Latitude, SupportMission_NextRefPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			}
			if (!myUnit.IsAircraft && !myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (!IsInTransit)
				{
					if (myUnit.IsSubmarine)
					{
						if (Information.IsNothing((object)mineClearingMission.StationThrottle_Submarine))
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
						}
						else
						{
							myUnit.SetThrottle(mineClearingMission.StationThrottle_Submarine);
						}
					}
					else if (!myUnit.IsShip)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else if (Information.IsNothing((object)mineClearingMission.StationThrottle_Ship))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Loiter);
					}
					else
					{
						myUnit.SetThrottle(mineClearingMission.StationThrottle_Ship);
					}
				}
				else if (!myUnit.IsSubmarine)
				{
					if (!myUnit.IsShip)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					else
					{
						myUnit.SetThrottle(mineClearingMission.TransitThrottle_Ship);
					}
				}
				else
				{
					myUnit.SetThrottle(mineClearingMission.TransitThrottle_Submarine);
				}
			}
			if (!myUnit.IsSubmarine)
			{
				return;
			}
			int value = (int)myUnit.Doctrine.get_RechargePercentagePatrol(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value;
			Submarine_AI aI = ((Submarine)myUnit).AI;
			if (aI.RiseToPeriscopeDepthForRechargeIfNecessary(value, UseAIPifAvailable: false, IsAttackRechargeSetting: false) || myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			if (!IsInTransit)
			{
				if (mineClearingMission.StationDepth_Submarine.HasValue)
				{
					float value2 = mineClearingMission.StationDepth_Submarine.Value;
					if (Math.Round(value2) >= -20.0 && !aI.IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
					{
						myUnit.DesiredAltitude = -40f;
					}
					else
					{
						myUnit.DesiredAltitude = value2;
					}
				}
			}
			else if (mineClearingMission.TransitDepth_Submarine.HasValue)
			{
				float value3 = mineClearingMission.TransitDepth_Submarine.Value;
				if (Math.Round(value3) >= -20.0 && !aI.IsBatteryRechargePossible(IsAttackRechargeSetting: false, null))
				{
					myUnit.DesiredAltitude = -40f;
				}
				else
				{
					myUnit.DesiredAltitude = value3;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100204", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void TriggerPathfinderThread(Waypoint StartWP, ActiveUnit theUnit, Mission.Flight theFlightPlan, bool theIngressPath, float ProximityThreshold_Deg, double DestLat, double DestLon, Scenario theScen, bool ManouverTowardsTarget)
	{
		_ = Debugger.IsAttached;
		try
		{
			if ((theUnit != null && theUnit.ThrottleSetting == ActiveUnit.Throttle.FullStop && theUnit.CurrentSpeed == 0f) || (theUnit == null && theFlightPlan == null) || (!bool_0 && theFlightPlan == null) || PathFindingInProgress)
			{
				return;
			}
			Exception ThrownError = null;
			if (!Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, theFlightPlan, ref ThrownError) && Information.IsNothing((object)ThrownError))
			{
				PathFindingInProgress = true;
				PathfindRequest pathfindRequest = new PathfindRequest();
				pathfindRequest.theUnit = theUnit;
				pathfindRequest.theScenario = theScen;
				pathfindRequest.theFlightPlan = theFlightPlan;
				pathfindRequest.theFlightPlanIngressPath = theIngressPath;
				pathfindRequest.StartWP = StartWP;
				pathfindRequest.ProximityThreshold_Deg = ProximityThreshold_Deg;
				pathfindRequest.DestLat = DestLat;
				pathfindRequest.DestLon = DestLon;
				pathfindRequest.Age = 0;
				if (myUnit.IsAircraft)
				{
					pathfindRequest.Distance = 0;
				}
				else
				{
					pathfindRequest.Distance = (int)Math.Round(Module_Unit.RangeToPoint_Horiz(myUnit, DestLat, DestLon));
				}
				pathfindRequest.ManouverTowardsTarget = ManouverTowardsTarget;
				Pathfinding.SubmitPathfindRequest(pathfindRequest, theScen);
				theScen.AddMessage("The unit " + myUnit.Name + " will wait until path evaluation terminates", "Evaluating Path for " + myUnit.Name, LoggedMessage.MessageType.UnitAI, 1, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100205", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void StartPathfinding(Waypoint PF_StartWP, ActiveUnit theUnit, Mission.Flight theFlightPlan, bool theFlightPlanIngressPath, float ProximityThreshold_Deg, double DestLat, double DestLon, Scenario theScen, bool ManouverTowardsTarget)
	{
		PathFindingInProgress = true;
		try
		{
			if (PathFindingAbortNextPath)
			{
				PathFindingAbortNextPath = false;
				PathFindingInProgress = false;
				return;
			}
			PerformPathfinding(PF_StartWP, theUnit, theFlightPlan, theFlightPlanIngressPath, ProximityThreshold_Deg, DestLat, DestLon, ManouverTowardsTarget);
			if (PathFindingAbortNextPath)
			{
				PathFindingAbortNextPath = false;
				PF_GeneratedCourse = null;
				PathFindingInProgress = false;
				return;
			}
			if (PF_GeneratedCourse != null && !UseCostBasedPathfinder)
			{
				bool bool_ = false;
				bool bool_2 = theFlightPlan != null;
				while (!bool_)
				{
					if (!theScen.ThreadedOpsMustStop)
					{
						method_8(PF_GeneratedCourse, bool_2, ProximityThreshold_Deg, ref bool_, ref theFlightPlan, ref theFlightPlanIngressPath);
						continue;
					}
					PathFindingInProgress = false;
					return;
				}
			}
			if (!Information.IsNothing((object)PF_GeneratedCourse))
			{
				int count = PF_GeneratedCourse.Count;
				if (!Information.IsNothing((object)PF_StartWP))
				{
					if (Information.IsNothing((object)theFlightPlan))
					{
						int num = Array.IndexOf(PlottedCourse, PF_StartWP);
						int num2 = count - 1;
						for (int i = 0; i <= num2; i++)
						{
							AddWaypoint(num + 1 + i, PF_GeneratedCourse[i]);
						}
					}
					else if (!theFlightPlanIngressPath)
					{
						int num3 = count - 1;
						for (int j = 0; j <= num3; j++)
						{
							Mission.Flight flight = theFlightPlan;
							Waypoint[] theFlightPlan2 = flight.FlightPlan_Pathfinder_Egress_1;
							AddWaypoint(ref theFlightPlan2, j, PF_GeneratedCourse[j]);
							flight.FlightPlan_Pathfinder_Egress_1 = theFlightPlan2;
						}
						theFlightPlan.Pathfinder_Egress_RequestBeingProcessed = false;
						theFlightPlan.PathfinderRequestCompleteAndAwaitingUse = true;
					}
				}
				else if (!Information.IsNothing((object)theFlightPlan))
				{
					if (theFlightPlanIngressPath)
					{
						int num4 = count - 1;
						for (int k = 0; k <= num4; k++)
						{
							Mission.Flight flight2 = theFlightPlan;
							Waypoint[] theFlightPlan2 = flight2.FlightPlan_Pathfinder_Ingress_1;
							AddWaypoint(ref theFlightPlan2, k, PF_GeneratedCourse[k]);
							flight2.FlightPlan_Pathfinder_Ingress_1 = theFlightPlan2;
						}
						theFlightPlan.Pathfinder_Ingress_RequestBeingProcessed = false;
					}
					else
					{
						int num5 = count - 1;
						for (int l = 0; l <= num5; l++)
						{
							Mission.Flight flight3 = theFlightPlan;
							Waypoint[] theFlightPlan2 = flight3.FlightPlan_Pathfinder_Egress_1;
							AddWaypoint(ref theFlightPlan2, l, PF_GeneratedCourse[l]);
							flight3.FlightPlan_Pathfinder_Egress_1 = theFlightPlan2;
						}
						theFlightPlan.Pathfinder_Egress_RequestBeingProcessed = false;
					}
					theFlightPlan.PathfinderRequestCompleteAndAwaitingUse = true;
				}
				else
				{
					int num6 = count - 1;
					for (int m = 0; m <= num6; m++)
					{
						AddWaypoint(m, PF_GeneratedCourse[m]);
					}
				}
			}
			if (Information.IsNothing((object)PF_GeneratedCourse) && Information.IsNothing((object)theFlightPlan) && ManouverTowardsTarget)
			{
				string text = "";
				if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
				{
					text = " (" + myUnit.UnitClass + ")";
				}
				string text2 = "";
				if (!Information.IsNothing((object)myUnit.AI.PrimaryTarget))
				{
					text2 = " (" + myUnit.AI.PrimaryTarget.Name + ")";
				}
				myUnit.AddMessage(myUnit.Name + text + " Is dropping all targets from its target list (Reason: The navigator failed to plot a course to the primary target" + text2 + " , which means it is inaccessible. The unit will now re-build its target list based on current target availability and accessability).", myUnit.Name + " dropping all targets", LoggedMessage.MessageType.UnitAI, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				myUnit.AI.ClearAllTargets(ref myUnit);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200330", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		PathFindingInProgress = false;
		if (TimeToNextPathfinderCheck < 300f)
		{
			TimeToNextPathfinderCheck = 300f;
		}
	}

	public void HeadToRoadSystemDestination(float elapsedTime)
	{
		if (myUnit.DestinationNode != null)
		{
			Geopoint_Struct coordinates = myUnit.DestinationNode.Coordinates;
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, coordinates.Latitude, coordinates.Longitude));
		}
	}

	public virtual void FollowPlottedCourse(float elapsedTime)
	{
		if (myUnit.AI.HoldPosition)
		{
			return;
		}
		if (HasFlightPlan)
		{
			try
			{
				if (HasPlottedCourse() && !myUnit.IsRTB)
				{
					Waypoint? waypoint = PlottedCourse.FirstOrDefault();
					bool? flag = ((waypoint != null) ? new bool?(waypoint.Category != Waypoint.WaypointCategory.FlightPlan) : ((bool?)null));
					if (flag ?? true)
					{
						Waypoint? waypoint2 = PlottedCourse.FirstOrDefault();
						if (waypoint2 != null && waypoint2.Type != Waypoint.WaypointType.PathfindingPoint && flag.HasValue)
						{
							ClearPlottedCourse(PlayerIsPlottingCourse: false, ClearResumeFlightPlanWaypoint: false);
						}
					}
				}
				if (!HasPlottedCourse())
				{
					if (_ResumeFlightPlanWaypoint == null && myUnit.AssignedMissionOrPackage() != null)
					{
						if ((myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike) & (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive))
						{
							Waypoint[] flightPlan = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
							Waypoint waypoint4 = default(Waypoint);
							foreach (Waypoint waypoint3 in flightPlan)
							{
								if (waypoint4 == null || !(((waypoint3.Type != Waypoint.WaypointType.Target) | (waypoint3.Type != Waypoint.WaypointType.WeaponTarget)) & ((waypoint4.Type == Waypoint.WaypointType.Target) | (waypoint4.Type == Waypoint.WaypointType.WeaponTarget))))
								{
									waypoint4 = waypoint3;
									continue;
								}
								_ResumeFlightPlanWaypoint = waypoint3;
								break;
							}
						}
						else if (myUnit.AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
						{
							float num = float.MaxValue;
							Waypoint resumeFlightPlanWaypoint = default(Waypoint);
							if (!myUnit.IsRTB)
							{
								bool flag2 = false;
								Waypoint[] flightPlan2 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
								foreach (Waypoint waypoint5 in flightPlan2)
								{
									if (waypoint5.IsStationStartWaypoint())
									{
										flag2 = true;
									}
									if (flag2)
									{
										float num2 = Math2.CalcDist(myUnit, waypoint5);
										if (num2 < num)
										{
											num = num2;
											resumeFlightPlanWaypoint = waypoint5;
										}
									}
									if (waypoint5.IsStationEndWaypoint())
									{
										break;
									}
								}
								_ResumeFlightPlanWaypoint = resumeFlightPlanWaypoint;
							}
							else
							{
								bool flag3 = false;
								Waypoint[] flightPlan3 = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan;
								foreach (Waypoint waypoint6 in flightPlan3)
								{
									if (flag3)
									{
										float num3 = Math2.CalcDist(myUnit, waypoint6);
										if (num3 < num)
										{
											num = num3;
											resumeFlightPlanWaypoint = waypoint6;
										}
									}
									if (waypoint6.IsStationEndWaypoint())
									{
										flag3 = true;
									}
								}
								_ResumeFlightPlanWaypoint = resumeFlightPlanWaypoint;
							}
						}
					}
					Waypoint resumeFlightPlanWaypoint2 = _ResumeFlightPlanWaypoint;
					PlottedCourse = this.get_Flight(HierarchySearch: true).FlightPlan;
					if (resumeFlightPlanWaypoint2 != null)
					{
						method_3(resumeFlightPlanWaypoint2);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 32154111", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		Waypoint[] array = PlottedCourse;
		try
		{
			if ((array.Length == 0) & HasFlightPlan)
			{
				array = ((!myUnit.IsGroupWingman()) ? this.get_Flight(HierarchySearch: true).FlightPlan : myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse);
			}
			int num4;
			if (array.Length != 0)
			{
				if (array.Length != 1)
				{
					goto IL_0405;
				}
				if (!((array[0].Latitude == 0.0) & (array[0].Longitude == 0.0)))
				{
					num4 = 0;
				}
				else
				{
					if (!myUnit.IsGroupMember() || myUnit.IsGroupLead())
					{
						ClearPlottedCourse();
						return;
					}
					Waypoint[] plottedCourse = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse;
					if (plottedCourse == null || plottedCourse.Length <= 0 || plottedCourse[0].Latitude == 0.0 || plottedCourse[0].Longitude == 0.0)
					{
						goto IL_0405;
					}
					PlottedCourse = plottedCourse;
					num4 = 0;
				}
				goto IL_0406;
			}
			if (GlobalVariables.AI_REWORK && myUnit.IsAircraft)
			{
				((Aircraft)myUnit).AI.StatusRelatedEvents.triedFollowingPlottedCourseButHadNone = true;
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					if (myUnit.IsAircraft)
					{
						((Aircraft)myUnit).Kinematics.Loiter(elapsedTime);
					}
					else
					{
						myUnit.DesiredSpeed = 0f;
					}
				}
			}
			else if (myUnit.ActiveMissionOrPackage() != null)
			{
				if (myUnit.AI.PrimaryTarget != null)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.EngagedOffensive;
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.Tasked;
				}
			}
			else
			{
				myUnit.Status = ActiveUnit._ActiveUnitStatus.Unassigned;
				if (!myUnit.IsAircraft)
				{
					myUnit.DesiredSpeed = 0f;
				}
				else
				{
					((Aircraft)myUnit).Kinematics.Loiter(elapsedTime);
				}
			}
			return;
			IL_0406:
			int ReasonForInterrupt = num4;
			GeoPoint InterruptLocation = new GeoPoint();
			if (bool_0 && !PathFindingInProgress)
			{
				if (HasPathfindingPlottedCourse)
				{
					if (array.Length > 1 && array[0].Type == Waypoint.WaypointType.PathfindingPoint)
					{
						double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						double latitude = array[0].Latitude;
						double longitude = array[0].Longitude;
						float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
						GeoPoint InterruptLocation2 = null;
						if (PathLineIsInterrupted(startLat, startLon, latitude, longitude, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation2))
						{
							TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, array[0].Latitude, array[0].Longitude, myUnit.ParentScen, ManouverTowardsTarget: false);
						}
						if (!myUnit.IsAircraft)
						{
							double startLat2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							double startLon2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							double latitude2 = array[1].Latitude;
							double longitude2 = array[1].Longitude;
							float? samplingInterval_Deg2 = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
							InterruptLocation2 = null;
							if (!PathLineIsInterrupted(startLat2, startLon2, latitude2, longitude2, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, samplingInterval_Deg2, ref ReasonForInterrupt, ref InterruptLocation2) && Math2.CalcDist_Angular(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), array[0].Latitude, array[0].Longitude) < 0.05)
							{
								ApplyWaypointSpeedAltToUnit(array[0]);
								ApplyWaypointDoctrineToUnit(array[0]);
								RemoveWaypoint_Soft(array[0], RemoveWingmanWaypoints: false);
							}
						}
					}
				}
				else if (PathLineIsInterrupted(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), array[0].Latitude, array[0].Longitude, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained, ref ReasonForInterrupt, ref InterruptLocation))
				{
					if (myUnit.IsMCMPlatform_ThisPulse == -1)
					{
						myUnit.Determine_IsMCMPlatform();
					}
					if (myUnit.IsMCMPlatform_ThisPulse != 0 && myUnit.IsOnActiveMineClearingMission && (ReasonForInterrupt & 1) == 1)
					{
						GeoPoint geoPoint = new GeoPoint();
						Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), InterruptLocation.Latitude, InterruptLocation.Longitude);
						float num5 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), InterruptLocation.Latitude, InterruptLocation.Longitude);
						if (num5 > 1f)
						{
							double lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							double lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							GeoPoint InterruptLocation2;
							double out_lon = (InterruptLocation2 = geoPoint).Longitude;
							GeoPoint geoPoint2;
							double out_lat = (geoPoint2 = geoPoint).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, Math.Max(1f, 2f * num5 / 3f), Math2.NormalizeBearing(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), InterruptLocation.Latitude, InterruptLocation.Longitude)));
							geoPoint2.Latitude = out_lat;
							InterruptLocation2.Longitude = out_lon;
							RemoveWaypoint_Soft(array[0], RemoveWingmanWaypoints: false);
							AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
						else
						{
							double lon2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							double lat2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							GeoPoint geoPoint2;
							double out_lat = (geoPoint2 = geoPoint).Longitude;
							GeoPoint InterruptLocation2;
							double out_lon = (InterruptLocation2 = geoPoint).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(lon2, lat2, ref out_lat, ref out_lon, 0.5, Math2.NormalizeBearing(180f + Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), array[0].Latitude, array[0].Longitude)));
							InterruptLocation2.Latitude = out_lon;
							geoPoint2.Longitude = out_lat;
							RemoveWaypoint_Soft(array[0], RemoveWingmanWaypoints: false);
							AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geoPoint.Latitude, geoPoint.Longitude));
						}
					}
					else
					{
						TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, array[0].Latitude, array[0].Longitude, myUnit.ParentScen, ManouverTowardsTarget: false);
					}
				}
			}
			HeadToFirstWaypoint(elapsedTime);
			bool ForceWaypointSwitch = false;
			bool ForceStationAbort = false;
			CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch, ref ForceStationAbort);
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				return;
			}
			if (myUnit.IsAircraft && myUnit.ThrottleSetting <= ActiveUnit.Throttle.Cruise)
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (myUnit.IsAircraft && myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				myUnit.SetThrottle(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting);
			}
			else if (myUnit.IsSubmarine && myUnit.ThrottleSetting <= ActiveUnit.Throttle.Cruise && ((Submarine)myUnit).DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (myUnit.IsShip && myUnit.ThrottleSetting <= ActiveUnit.Throttle.Cruise)
			{
				if (myUnit.ActiveMissionOrPackage() == null)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
				}
			}
			else if (myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				myUnit.SetThrottle(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting);
			}
			return;
			IL_0405:
			num4 = 0;
			goto IL_0406;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 200321", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float GetPlottedCourseDistance(Waypoint[] myPlottedCourse)
	{
		float num = 0f;
		try
		{
			if (myPlottedCourse == null || myPlottedCourse.Count() == 0)
			{
				num = ((myUnit.AI.PrimaryTarget == null) ? 0f : Math2.CalcDist(myUnit, myUnit.AI.PrimaryTarget));
			}
			else
			{
				int num2 = myPlottedCourse.Count() - 2;
				for (int i = 0; i <= num2; i++)
				{
					num += Math2.CalcDist(myPlottedCourse[i], myPlottedCourse[i + 1]);
				}
				num += Math2.CalcDist(myUnit, myPlottedCourse[0]);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 654684352", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return num;
	}

	public void ClearPathfindingWaypoints()
	{
		try
		{
			List<Waypoint> list = new List<Waypoint>();
			Waypoint[] plottedCourse = PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				if (waypoint.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					list.Add(waypoint);
				}
			}
			foreach (Waypoint item in list)
			{
				RemoveWaypoint_Soft(item, RemoveWingmanWaypoints: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100208", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HeadToPoint(GeoPoint thePoint)
	{
		try
		{
			if (HasPathfindingPlottedCourse || PathFindingInProgress || PathFindingInProgress)
			{
				return;
			}
			int ReasonForInterrupt = 0;
			GeoPoint InterruptLocation = new GeoPoint();
			if (myUnit.Navigator.bool_0 && PathLineIsInterrupted(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), thePoint.Latitude, thePoint.Longitude, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained, ref ReasonForInterrupt, ref InterruptLocation))
			{
				if (myUnit.IsMCMPlatform_ThisPulse == -1)
				{
					myUnit.Determine_IsMCMPlatform();
				}
				if (myUnit.IsMCMPlatform_ThisPulse != 0 && myUnit.IsOnActiveMineClearingMission && (ReasonForInterrupt & 1) == 1)
				{
					GeoPoint geoPoint = new GeoPoint();
					Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), InterruptLocation.Latitude, InterruptLocation.Longitude);
					float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), InterruptLocation.Latitude, InterruptLocation.Longitude);
					if (num > 1f)
					{
						double lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						double lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						GeoPoint geoPoint2;
						double out_lon = (geoPoint2 = geoPoint).Longitude;
						GeoPoint geoPoint3;
						double out_lat = (geoPoint3 = geoPoint).Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, Math.Max(1f, 2f * num / 3f), Math2.NormalizeBearing(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), InterruptLocation.Latitude, InterruptLocation.Longitude)));
						geoPoint3.Latitude = out_lat;
						geoPoint2.Longitude = out_lon;
						RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
						AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
					}
					else
					{
						double lon2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						double lat2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						GeoPoint geoPoint3;
						double out_lat = (geoPoint3 = geoPoint).Longitude;
						GeoPoint geoPoint2;
						double out_lon = (geoPoint2 = geoPoint).Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(lon2, lat2, ref out_lat, ref out_lon, 0.5, Math2.NormalizeBearing(180f + Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude)));
						geoPoint2.Latitude = out_lon;
						geoPoint3.Longitude = out_lat;
						RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
						AddWaypoint(0, new Waypoint(geoPoint.Longitude, geoPoint.Latitude, 0f, Waypoint.WaypointType.ManualPlottedCourseWaypoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), geoPoint.Latitude, geoPoint.Longitude));
					}
				}
				else
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), thePoint.Latitude, thePoint.Longitude));
					TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, thePoint.Latitude, thePoint.Longitude, myUnit.ParentScen, ManouverTowardsTarget: false);
				}
			}
			else if (!HasPathfindingPlottedCourse)
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), thePoint.Latitude, thePoint.Longitude));
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100209", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected virtual void HeadToFirstWaypoint(float elapsedTime)
	{
		try
		{
			if (!myUnit.Navigator.SprintDrift)
			{
				Waypoint[] plottedCourse = PlottedCourse;
				if (plottedCourse.Length > 0)
				{
					Waypoint theWaypoint = plottedCourse[0];
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Module_Unit.BearingToPoint_True(myUnit, theWaypoint.Latitude, theWaypoint.Longitude, GlobalVariables.ObjectTrue));
					ExtendIfNecessary(elapsedTime, ref theWaypoint, theWaypoint.Latitude, theWaypoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
				}
				else
				{
					ManualPlotOverride = false;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100210", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsAutoPlannerPlottedCourse_CruiseIngressRun(List<Waypoint> PlottedCourse)
	{
		if (HasPlottedCourse())
		{
			if (!myUnit.AI.IsEscort)
			{
				foreach (Waypoint item in PlottedCourse)
				{
					if (!item.IsExclusivelyStrikeIngressWaypoint())
					{
						int result;
						if (!item.IsExclusivelyStrikeTargetWaypoint())
						{
							if (!item.IsExclusivelyStrikeEgressWaypoint())
							{
								continue;
							}
							result = 0;
						}
						else
						{
							result = 0;
						}
						return (byte)result != 0;
					}
					return true;
				}
				int result2;
				if (!Debugger.IsAttached)
				{
					result2 = 0;
				}
				else
				{
					Debugger.Break();
					result2 = 0;
				}
				return (byte)result2 != 0;
			}
			return false;
		}
		return false;
	}

	public double GetMinimumBearing(double bearing1, double bearing2)
	{
		bearing1 %= 360.0;
		bearing2 %= 360.0;
		double num = Math.Abs(bearing1 - bearing2);
		double num2 = 360.0 - num;
		if (num <= num2)
		{
			if (bearing1 < bearing2)
			{
				return bearing1;
			}
			return bearing2;
		}
		if (bearing1 > bearing2)
		{
			return bearing1;
		}
		return bearing2;
	}

	public virtual (bool, double) HaveReachedPoint_Internal(GeoPoint thePoint, float elapsedTime, bool Overshoot = true, bool simplify_calc_for_ACs = false, float? distanceThreshold_nm = null, double simulationTimeIncrease = 0.0)
	{
		(bool, double) result;
		try
		{
			if (thePoint == null)
			{
				return (false, double.MaxValue);
			}
			double theLat = thePoint.Latitude;
			double theLon = thePoint.Longitude;
			if (theLat == 0.0)
			{
			}
			if (!thePoint.IsWaypoint)
			{
			}
			double num = Math2.CalcDist(theLat, theLon, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			if (num > 10.0)
			{
				return (false, num);
			}
			double num2 = num;
			double? num3 = distanceThreshold_nm;
			if (((!num3.HasValue) ? ((bool?)null) : new bool?(num2 < num3.GetValueOrDefault())) != true)
			{
				if (thePoint.IsWaypoint)
				{
					Waypoint waypoint = (Waypoint)thePoint;
					if (waypoint.Type == Waypoint.WaypointType.HoldEnd && waypoint.Time_Zulu.HasValue)
					{
						DateTime? time_Zulu = waypoint.Time_Zulu;
						DateTime time = myUnit.ParentScen.Time;
						if (((!time_Zulu.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(time_Zulu.GetValueOrDefault(), time) <= 0)) == true)
						{
							return (true, num);
						}
					}
					if (simplify_calc_for_ACs)
					{
						float num4 = Math2.CalcDist(theLat, theLon, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
						float val = 0.1f;
						if ((myUnit.IsAircraft && ((Aircraft)myUnit).IsHelicopter) & (myUnit.ParentScen.TimeCompression < Scenario.enumTimeCompression.Coarse_FiveSecSlice))
						{
							val = 0.001f;
						}
						float num5 = myUnit.CurrentSpeed / 3600f * 2f * elapsedTime;
						if (myUnit.IsAircraft)
						{
							if (((Aircraft)myUnit).IsHelicopter)
							{
								num5 *= 0.1f;
							}
							if ((double)num4 < (double)Math.Max(num5, val) * 1.5)
							{
								if (!method_5(thePoint, elapsedTime))
								{
									return (false, num);
								}
								return (true, num);
							}
						}
					}
				}
				if (Module_Unit.RangeToPoint_Horiz_Angular(myUnit, ref theLat, ref theLon) > Misc.AngularDistance_5nm)
				{
					return (false, num);
				}
				if (thePoint.IsWaypoint && myUnit.CurrentSpeed == 0f && myUnit.DesiredSpeed == 0f && num < 0.01)
				{
					if (!method_5(thePoint, elapsedTime))
					{
						return (false, num);
					}
					return (true, num);
				}
				double num7 = default(double);
				if (!Overshoot)
				{
					double num6 = myUnit.CurrentSpeed;
					while (num6 > 0.1)
					{
						double decelerationCapacity = myUnit.Kinematics.GetDecelerationCapacity(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (float)num6, 1f);
						num7 += num6 / 3600.0;
						num6 -= decelerationCapacity;
					}
				}
				else
				{
					num7 = Math.Max(myUnit.CurrentSpeed / 3600f * 2f * elapsedTime, 0.01f);
				}
				return (num < num7, num);
			}
			return (true, num);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100212", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = (false, double.MaxValue);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public virtual bool HaveReachedPoint(GeoPoint thePoint, float elapsedTime, bool Overshoot = true, bool simplify_calc_for_ACs = false, float? distanceThreshold_nm = null, double simulationTimeIncrease = 0.0)
	{
		bool result;
		try
		{
			(bool, double) tuple = HaveReachedPoint_Internal(thePoint, elapsedTime, Overshoot, simplify_calc_for_ACs, distanceThreshold_nm, simulationTimeIncrease);
			if (tuple.Item2 == double.MaxValue)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
			else if (thePoint.IsWaypoint)
			{
				WP_reach_cache_memory.Update(new Geopoint_Struct(thePoint.Longitude, thePoint.Latitude), myUnit.ParentScen.Time, tuple.Item1, tuple.Item2, myUnit.Location);
			}
			(result, _) = tuple;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100212", "");
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

	private bool method_5(GeoPoint geoPoint_1, float float_0)
	{
		if (geoPoint_1.IsWaypoint)
		{
			Waypoint waypoint = (Waypoint)geoPoint_1;
			if (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponLaunch && waypoint.Type != Waypoint.WaypointType.LandingMarshal)
			{
				return true;
			}
			if ((waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponLaunch) || !myUnit.IsAircraft)
			{
				_ = waypoint.Latitude;
				_ = waypoint.Longitude;
				int result;
				if (!waypoint.DesiredAltitude.HasValue)
				{
					result = 1;
				}
				else
				{
					bool flag = true;
					if (myUnit.IsAircraft)
					{
						float value = waypoint.DesiredAltitude.Value;
						float? num = ((Aircraft)myUnit).get_MinimumSafeHeight(bool_7: false);
						bool? flag2 = ((!num.HasValue) ? ((bool?)null) : new bool?(value < num.GetValueOrDefault()));
						if (((waypoint.DesiredAltitude.Value <= ((Aircraft)myUnit).Kinematics.GetMaximumAltitude()) ? flag2 : new bool?(true)) == true)
						{
							flag = false;
						}
					}
					if (!flag)
					{
						result = 1;
					}
					else
					{
						if (Math.Abs(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - waypoint.DesiredAltitude.Value) > ALTTITUTE_THREASHOLD)
						{
							int result2;
							if (!myUnit.IsGroupWingman())
							{
								result2 = 0;
							}
							else
							{
								if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.method_5(waypoint, float_0))
								{
									return true;
								}
								result2 = 0;
							}
							return (byte)result2 != 0;
						}
						result = 1;
					}
				}
				return (byte)result != 0;
			}
			return true;
		}
		return true;
	}

	public virtual void CheckIfReachedWaypoint_AND_Apply_WP_logic(float elapsedTime, ref bool ForceWaypointSwitch, ref bool ForceStationAbort)
	{
		float? distanceThreshold_nm = null;
		Waypoint waypoint = default(Waypoint);
		try
		{
			if (PlottedCourse.Count() == 0)
			{
				return;
			}
			Scenario parentScen = myUnit.ParentScen;
			if (DateTime.Compare(WP_reach_cache_memory.theTime, parentScen.Time) != 0)
			{
				if (((PlottedCourse[0].Latitude == WP_reach_cache_memory.theWaypoint.Latitude) & (PlottedCourse[0].Longitude == WP_reach_cache_memory.theWaypoint.Longitude)) && myUnit.Location == WP_reach_cache_memory.UnitLocation)
				{
					return;
				}
			}
			else if (parentScen.GameContext.GameMode != Game._GameMode.ScenEdit || myUnit.Location == WP_reach_cache_memory.UnitLocation)
			{
				return;
			}
			waypoint = PlottedCourse[0];
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100213", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (!HaveReachedPoint(waypoint, elapsedTime, waypoint.OvershootWaypoint, simplify_calc_for_ACs: false, distanceThreshold_nm))
			{
				return;
			}
			ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
			ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
			ApplyWaypointActionToUnit(PlottedCourse[0]);
			PreviousWaypointTime = myUnit.ParentScen.Time;
			PreviousWaypointLatitude = waypoint.Latitude;
			PreviousWaypointLongitude = waypoint.Longitude;
			PreviousWaypointType = waypoint.Type;
			RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
			if (PlottedCourse.Count() > 0 && ((waypoint.Type != Waypoint.WaypointType.PickupPoint && waypoint.Type != Waypoint.WaypointType.DropOffPoint) || !myUnit.DockingOps.SettleForCargoTransfer()))
			{
				if (myUnit.IsAggregatedUnit && Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude) >= AGU_CONFIG.Instance.RoadUsageDistanceThreshold_Nm)
				{
					myUnit.PathFindingToDestination(myUnit.ParentScen, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, 1f);
				}
				HeadToFirstWaypoint(elapsedTime);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100214", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyWaypointActionToUnit(Waypoint myWaypoint)
	{
		if (myUnit != null && myWaypoint != null && !string.IsNullOrEmpty(myWaypoint.EventActionID))
		{
			Scenario parentScen = myUnit.ParentScen;
			EventAction value = null;
			EventAction eventAction = null;
			if (parentScen.EventActions.TryGetValue(myWaypoint.EventActionID, out value))
			{
				eventAction = ((EventAction_LuaScript)value).Clone();
				string scriptText = ((EventAction_LuaScript)eventAction).ScriptText;
				((EventAction_LuaScript)eventAction).ScriptText = "local wpAction = {unit = '" + myUnit.ObjectID + "', wp = '" + myWaypoint.ObjectID + "'}\r\n" + scriptText;
				parentScen.Scenario_LuaSandbox.UnitX = myUnit;
				eventAction.Execute(parentScen);
				eventAction = null;
			}
		}
	}

	public void ApplyWaypointSpeedAltToUnit(Waypoint myWaypoint)
	{
		if (myUnit == null || myWaypoint == null)
		{
			return;
		}
		try
		{
			bool flag = myUnit.IsAircraft || (myUnit.IsWeapon && myUnit.SupportsAltitude_Control && myUnit.Kinematics.GetMaximumAltitude() > 0f);
			bool flag2 = myUnit.IsSubmarine || (myUnit.IsWeapon && myUnit.SupportsAltitude_Control && myUnit.Kinematics.GetMinimumAltitude() < 0f);
			myUnit.AI.TimeToNextSpeedAdjustmentForToTEvaluation = null;
			myUnit.AI.IsPerformingSpeedAdjustmentToT = false;
			if (myUnit.IsAircraft && myUnit.IsGroupWingman() && myUnit.Navigator.PlottedCourse.Count() == 1)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.DesiredAltitudeOverride = false;
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
			else
			{
				if (myWaypoint.DesiredSpeedOverride.HasValue && myWaypoint.DesiredSpeed.HasValue)
				{
					myUnit.DesiredSpeed = myWaypoint.DesiredSpeed.Value;
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
					myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
				}
				else if (myWaypoint.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
				{
					myUnit.Kinematics.ThrottlePreset = myWaypoint.ThrottlePreset;
					myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, ValidateAndFixAltitude: false);
					myUnit.Kinematics.DesiredSpeedOverride = myUnit.DesiredSpeed;
				}
				if (!myWaypoint.DesiredAltitudeOverride)
				{
					myUnit.Kinematics.DesiredAltitudeOverride = false;
				}
				else
				{
					if (myUnit.IsSubmarine)
					{
						((Submarine)myUnit).AI.DepthPreset = myWaypoint.DepthPreset;
					}
					if (myUnit.IsAircraft)
					{
						((Aircraft)myUnit).AI.AltitudePreset = myWaypoint.AltitudePreset;
					}
					if (flag || flag2)
					{
						if (myWaypoint.DesiredAltitude_TerrainFollowing.HasValue && myWaypoint.TerrainFollowing)
						{
							myUnit.DesiredAltitude_AGL = myWaypoint.DesiredAltitude_TerrainFollowing.Value;
							myUnit.DesiredAltitude = 0f;
							myUnit.AI.PerformTerrainFollowingIfNecessary();
						}
						else if (myWaypoint.DesiredAltitude.HasValue)
						{
							myUnit.DesiredAltitude = myWaypoint.DesiredAltitude.Value;
							float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
							float minimumAltitude = myUnit.Kinematics.GetMinimumAltitude();
							if (myUnit.DesiredAltitude > maximumAltitude)
							{
								myUnit.DesiredAltitude = maximumAltitude;
							}
							else if (myUnit.DesiredAltitude < minimumAltitude)
							{
								myUnit.DesiredAltitude = minimumAltitude;
							}
						}
						if (myUnit.IsWeapon && ((Weapon)myUnit).Flags.Navigation_AltitudeControl)
						{
							myUnit.Kinematics.DesiredAltitudeOverride = true;
						}
					}
					if (myUnit.IsAircraft)
					{
						if (!myWaypoint.DesiredAltitude_TerrainFollowing.HasValue)
						{
							myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value: false);
						}
						else
						{
							myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, myWaypoint.TerrainFollowing);
							myUnit.TerrainFollowingType = myWaypoint.TerrainFollowingType;
							myUnit.AI.PerformTerrainFollowingIfNecessary();
						}
					}
				}
			}
			myUnit.DesiredTurnRate = ActiveUnit.TurnRate.Navigation;
			if (!Information.IsNothing((object)myUnit.Navigator.get_Flight(HierarchySearch: true)) && myUnit.Navigator.PlottedCourse.Count() > 1)
			{
				myUnit.DesiredTurnRate_Navigation = myWaypoint.TurnRate_Navigation;
			}
			else
			{
				myUnit.DesiredTurnRate_Navigation = Waypoint.TurnRateCategory.DoubleStandardRateTurn;
			}
			if (!Information.IsNothing((object)myWaypoint.SprintDrift))
			{
				myUnit.Navigator.SprintDrift = myWaypoint.SprintDrift.Value;
				bool? sprintDrift = myWaypoint.SprintDrift;
				if (((!sprintDrift) ?? sprintDrift) != true)
				{
					sprintDrift = myWaypoint.SprintDrift;
					if ((sprintDrift ?? true) && !Information.IsNothing((object)myWaypoint.SprintDrift_AverageSpeed) && sprintDrift.HasValue)
					{
						myUnit.Navigator.SprintDrift_AverageSpeed = myWaypoint.SprintDrift_AverageSpeed;
					}
				}
				else
				{
					myUnit.Navigator.SprintDrift_AverageSpeed = null;
				}
			}
			if (!Information.IsNothing((object)myWaypoint.AvoidCavitation))
			{
				myUnit.Navigator.AvoidCavitation = myWaypoint.AvoidCavitation.Value;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100216", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyWaypointDoctrineToUnit(Waypoint myWaypoint)
	{
		if (myUnit == null)
		{
			return;
		}
		try
		{
			if (myUnit.IsGroupLead())
			{
				List<ActiveUnit> list = new List<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values);
				{
					foreach (ActiveUnit item in list)
					{
						if (item != null)
						{
							if (item == myUnit)
							{
								method_6(item, myWaypoint);
							}
							else if (!item.Navigator.HasPlottedCourse())
							{
								method_6(item, myWaypoint);
							}
						}
					}
					return;
				}
			}
			ActiveUnit current = myUnit;
			method_6(current, myWaypoint);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 101305", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_6(ActiveUnit activeUnit_0, Waypoint waypoint_0)
	{
		if (!waypoint_0.HasDoctrine)
		{
			return;
		}
		try
		{
			Doctrine doctrine = waypoint_0.GetDoctrine(activeUnit_0.ParentScen);
			activeUnit_0.Doctrine.SuspendDoctrineChangeEvents();
			Doctrine.DoctrineItem[] doctrineItems = doctrine.DoctrineItems;
			foreach (Doctrine.DoctrineItem doctrineItem in doctrineItems)
			{
				if (doctrineItem != null)
				{
					if (doctrineItem.IsInheriting)
					{
						activeUnit_0.Doctrine.SetElementState(doctrineItem.Definifition, null);
					}
					else if (Operators.CompareString(doctrineItem.GetStateReadableString(), "Not Configured", false) != 0)
					{
						activeUnit_0.Doctrine.SetElementState(doctrineItem.Definifition, doctrine.GetElementState(doctrineItem.Definifition));
					}
				}
			}
			if (doctrine.EMCON_Inherits)
			{
				return;
			}
			if (doctrine.EMCON(activeUnit_0.ParentScen).Radar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && doctrine.EMCON(activeUnit_0.ParentScen).Sonar() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured && doctrine.EMCON(activeUnit_0.ParentScen).OECM() == Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
			{
				activeUnit_0.Doctrine.EMCON_Inherits = true;
			}
			else
			{
				if (doctrine.EMCON(activeUnit_0.ParentScen).Radar() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					activeUnit_0.Doctrine.EMCON_Inherits = false;
					activeUnit_0.Doctrine.SetEMCON_Radar(doctrine.EMCON(activeUnit_0.ParentScen).Radar(), activeUnit_0.ParentScen);
				}
				if (doctrine.EMCON(activeUnit_0.ParentScen).Sonar() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					activeUnit_0.Doctrine.EMCON_Inherits = false;
					activeUnit_0.Doctrine.SetEMCON_Sonar(doctrine.EMCON(activeUnit_0.ParentScen).Sonar(), activeUnit_0.ParentScen);
				}
				if (doctrine.EMCON(activeUnit_0.ParentScen).OECM() != Doctrine.EMCONSettings._EMCONSetting.NotConfigured)
				{
					activeUnit_0.Doctrine.EMCON_Inherits = false;
					activeUnit_0.Doctrine.SetEMCON_OECM(doctrine.EMCON(activeUnit_0.ParentScen).OECM(), activeUnit_0.ParentScen);
				}
			}
			activeUnit_0.Sensory.vmethod_2(activeUnit_0.Sensors_Cached);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 101304", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			activeUnit_0.Doctrine.ResumeDoctrineChangeEvents(false, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
		}
	}

	public bool HaveReachedPatrolStation()
	{
		return DistanceFromPatrolStation() < 0.5;
	}

	public virtual bool HaveReachedFormationStation()
	{
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
			{
				return false;
			}
			var (num, num2) = UnitFormationStation.get_LatitudeAndLongitude(myUnit, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
			if ((double)Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2) < 0.25)
			{
				return true;
			}
			if ((double)Math.Abs(new Geopoint_Struct(num2, num).AngleOffThisUnitsBoresight(myUnit)) > 90.0 && Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentHeading)) < 20f)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public double DistanceFromPatrolStation()
	{
		if (Has_NonPathfind_NonFP_PlottedCourse())
		{
			return Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[PlottedCourse.Count() - 1].Latitude, PlottedCourse[PlottedCourse.Count() - 1].Longitude);
		}
		return 0.0;
	}

	public virtual void HeadToFormationStationOrFollowSecondaryFlightPlan(float elapsedtime)
	{
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).DesignateGroupLead_Auto();
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
				{
					return;
				}
			}
			if (myUnit.IsGroupMember() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null && (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DockingOps.UNREP_Destination == myUnit)
			{
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.HasPlottedCourse())
				{
					Waypoint waypoint = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0];
					myUnit.set_DesiredHeading(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude));
					Waypoint theWaypoint = null;
					ExtendIfNecessary(elapsedtime, ref theWaypoint, waypoint.Latitude, waypoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
				}
			}
			else
			{
				if (myUnit.IsGroupLead())
				{
					return;
				}
				if (HasPathfindingPlottedCourse)
				{
					FollowPlottedCourse(elapsedtime);
					return;
				}
				ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				if (groupLead == null)
				{
					return;
				}
				var (num, num2) = UnitFormationStation.get_ValidatedLatitudeAndLongitude(myUnit, groupLead);
				if (SprintDrift)
				{
					PerformSprintDrift(elapsedtime);
				}
				else
				{
					if (HaveReachedPoint(new GeoPoint(num2, num), elapsedtime))
					{
						float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
						if (relativeBearing > 30f && relativeBearing < 330f)
						{
							myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredHeading);
							myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed - 1f;
						}
						else
						{
							myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
							myUnit.DesiredSpeed = myUnit.get_ParentGroup(UsingMissionPlanner: false).DesiredSpeed;
						}
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
						return;
					}
					IsManouveringToFormationStation = true;
					myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
					if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
						}
						else
						{
							myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
						}
					}
					else if (myUnit.IsGroupMember())
					{
						if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting > ActiveUnit.Throttle.Full)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						}
						else
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
						}
					}
					else
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Full);
					}
				}
				if (groupLead.CurrentSpeed > 0f)
				{
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref out_lon, ref out_lat, UnitFormationStation.Distance, groupLead.CurrentHeading);
					ActiveUnit activeUnit = myUnit;
					double theLat = out_lat;
					double theLon = out_lon;
					int MovementCost = 0;
					bool CheckNoNavZones = true;
					bool CheckForMines = true;
					List<ActiveUnit> ProvidedPiers = null;
					string UserFeedback = "";
					bool AllowBounce = false;
					if (!activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
					{
						num = groupLead.get_Latitude((GlobalVariables.BooleanObject)null);
						num2 = groupLead.get_Longitude((GlobalVariables.BooleanObject)null);
					}
				}
				myUnit.AI.NavDestination = new Geopoint_Struct(num2, num);
				if (HasPathfindingPlottedCourse || PathFindingInProgress)
				{
					return;
				}
				if (myUnit.Navigator.bool_0)
				{
					double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					double destLat = num;
					double destLon = num2;
					float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
					int MovementCost = 0;
					GeoPoint InterruptLocation = null;
					if (PathLineIsInterrupted(startLat, startLon, destLat, destLon, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, samplingInterval_Deg, ref MovementCost, ref InterruptLocation))
					{
						TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, num, num2, myUnit.ParentScen, ManouverTowardsTarget: false);
						return;
					}
				}
				if (!SprintDrift)
				{
					float relativeBearing2 = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
					if (relativeBearing2 > 90f && relativeBearing2 < 270f && Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.get_ParentGroup(UsingMissionPlanner: false).CurrentHeading)) <= 30f)
					{
						myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, myUnit.get_ParentGroup(UsingMissionPlanner: false).CurrentHeading);
						myUnit.DesiredSpeed = (float)((double)myUnit.get_ParentGroup(UsingMissionPlanner: false).CurrentSpeed * 0.2);
						myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
					}
					else
					{
						myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100217", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool PlottedCourseLeadsToMissionArea(ref List<ReferencePoint> theArea, ref List<ReferencePoint> theArea_Buffer, ref List<ReferencePoint> theArea_ChangeCheck, float DistanceSlack, bool IgnoreTimeToNextEvaluation)
	{
		bool result;
		if (PlottedCourse == null)
		{
			result = false;
		}
		else if (PlottedCourse.Count() == 0)
		{
			result = false;
		}
		else if (theArea.Count == 0)
		{
			result = false;
		}
		else
		{
			Waypoint waypoint = PlottedCourse[PlottedCourse.Count() - 1];
			if (waypoint != null)
			{
				try
				{
					bool flag = GeoPoint.AreaHasChanged(theArea, theArea_ChangeCheck);
					if (IgnoreTimeToNextEvaluation || flag)
					{
						goto IL_008e;
					}
					if (!(TimeToNextPlottedCourseLeadsToMissionAreaEvaluation > 0.0))
					{
						TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 60.0;
						goto IL_008e;
					}
					result = CourseLeadsToMissionArea;
					goto end_IL_0051;
					IL_008e:
					if (theArea_Buffer != null && (theArea_Buffer.Count == 0 || flag))
					{
						CalculateAreaWithThresholdAdded_NM(DistanceSlack, ref theArea, ref theArea_Buffer, ref theArea_ChangeCheck);
					}
					int num = theArea.Count - 1;
					int num2 = 0;
					while (true)
					{
						if (num2 <= num)
						{
							try
							{
								ReferencePoint referencePoint = theArea[num2];
								if (referencePoint.Latitude == waypoint.Latitude && referencePoint.Longitude == waypoint.Longitude)
								{
									CourseLeadsToMissionArea = true;
									result = CourseLeadsToMissionArea;
									break;
								}
								if (DistanceSlack > 0f && Math2.CalcDist(waypoint.Latitude, waypoint.Longitude, referencePoint.Latitude, referencePoint.Longitude) <= DistanceSlack * 2f)
								{
									CourseLeadsToMissionArea = true;
									result = CourseLeadsToMissionArea;
									break;
								}
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								ProjectData.ClearProjectError();
							}
							num2++;
							continue;
						}
						if (theArea.Count == 1)
						{
							CourseLeadsToMissionArea = Math2.CalcDist(waypoint.Latitude, waypoint.Longitude, theArea[0].Latitude, theArea[0].Longitude) <= DistanceSlack;
						}
						else if (theArea.Count > 1)
						{
							if (theArea_Buffer != null && theArea_Buffer.Count != 0 && theArea_ChangeCheck != null && DistanceSlack != 0f)
							{
								CourseLeadsToMissionArea = GeoPoint.IsInsideThisArea(waypoint.Latitude, waypoint.Longitude, theArea_Buffer.ToList());
							}
							else
							{
								CourseLeadsToMissionArea = GeoPoint.IsInsideThisArea(waypoint.Latitude, waypoint.Longitude, theArea);
							}
						}
						result = CourseLeadsToMissionArea;
						break;
					}
					end_IL_0051:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200341", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					int num3;
					if (!Debugger.IsAttached)
					{
						num3 = 0;
					}
					else
					{
						Debugger.Break();
						num3 = 0;
					}
					result = (byte)num3 != 0;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	internal bool AreaHasChanged(List<GeoPoint> theArea, List<GeoPoint> BufferedArea)
	{
		bool result;
		try
		{
			if (Information.IsNothing((object)BufferedArea))
			{
				result = true;
			}
			else if (theArea.Count != BufferedArea.Count)
			{
				result = true;
			}
			else
			{
				int num = theArea.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						int num3;
						if (theArea[num2].Latitude == BufferedArea[num2].Latitude)
						{
							if (theArea[num2].Longitude == BufferedArea[num2].Longitude)
							{
								num2++;
								continue;
							}
							num3 = 1;
						}
						else
						{
							num3 = 1;
						}
						result = (byte)num3 != 0;
					}
					else
					{
						result = false;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200566", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (!Debugger.IsAttached)
			{
				num4 = 0;
			}
			else
			{
				Debugger.Break();
				num4 = 0;
			}
			result = (byte)num4 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool IsInsideMissionArea(ref List<ReferencePoint> theArea, ref List<ReferencePoint> theArea_Buffer, ref List<ReferencePoint> theArea_ChangeCheck, int DistanceSlack, bool IgnoreTimeToNextEvaluation, bool IsProsecutionArea)
	{
		bool result;
		try
		{
			int num;
			if (theArea == null)
			{
				num = 0;
				goto IL_05f5;
			}
			if (theArea.Count == 0)
			{
				num = 0;
				goto IL_05f5;
			}
			bool flag = GeoPoint.AreaHasChanged(theArea, theArea_ChangeCheck);
			if (IgnoreTimeToNextEvaluation || flag)
			{
				goto IL_01dd;
			}
			if (theArea_Buffer != null && theArea_ChangeCheck != null && DistanceSlack != 0)
			{
				switch (DistanceSlack)
				{
				case 1:
					if (!(TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer > 0.0))
					{
						TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer = 60.0;
						break;
					}
					result = InsideMissionArea_1nmBuffer;
					goto end_IL_0001;
				case 2:
					if (!(TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer > 0.0))
					{
						TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer = 60.0;
						break;
					}
					result = InsideMissionArea_2nmBuffer;
					goto end_IL_0001;
				case 5:
					if (!IsProsecutionArea)
					{
						if (!(TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer > 0.0))
						{
							TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer = 60.0;
							break;
						}
						result = InsideMissionArea_5nmBuffer;
					}
					else
					{
						if (!(TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer > 0.0))
						{
							TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer = 60.0;
							break;
						}
						result = InsideProsecutionArea_5nmBuffer;
					}
					goto end_IL_0001;
				case 10:
					if (!(TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer > 0.0))
					{
						TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer = 60.0;
						break;
					}
					result = InsideMissionArea_10nmBuffer;
					goto end_IL_0001;
				default:
					if (!(TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer > 0.0))
					{
						TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer = 60.0;
						break;
					}
					result = InsideMissionArea_30nmBuffer;
					goto end_IL_0001;
				}
				goto IL_01dd;
			}
			if (IsProsecutionArea)
			{
				if (!(TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer > 0.0))
				{
					TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer = 60.0;
					goto IL_01dd;
				}
				result = InsideProsecutionArea_NoBuffer;
			}
			else
			{
				if (!(TimeToNextIsInsideMissionAreaEvaluation_NoBuffer > 0.0))
				{
					TimeToNextIsInsideMissionAreaEvaluation_NoBuffer = 60.0;
					goto IL_01dd;
				}
				result = InsideMissionArea_NoBuffer;
			}
			goto end_IL_0001;
			IL_05f5:
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_01dd:
			if ((theArea.Count > 1 && theArea_Buffer != null && theArea_Buffer.Count == 0) || flag)
			{
				CalculateAreaWithThresholdAdded_NM(DistanceSlack, ref theArea, ref theArea_Buffer, ref theArea_ChangeCheck);
			}
			if (theArea.Count == 1)
			{
				switch (DistanceSlack)
				{
				case 1:
					InsideMissionArea_1nmBuffer = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theArea[0].Latitude, theArea[0].Longitude) <= (float)DistanceSlack;
					result = InsideMissionArea_1nmBuffer;
					break;
				case 2:
					InsideMissionArea_2nmBuffer = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theArea[0].Latitude, theArea[0].Longitude) <= (float)DistanceSlack;
					result = InsideMissionArea_2nmBuffer;
					break;
				case 5:
					if (IsProsecutionArea)
					{
						InsideProsecutionArea_5nmBuffer = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theArea[0].Latitude, theArea[0].Longitude) <= (float)DistanceSlack;
						result = InsideProsecutionArea_5nmBuffer;
					}
					else
					{
						InsideMissionArea_5nmBuffer = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theArea[0].Latitude, theArea[0].Longitude) <= (float)DistanceSlack;
						result = InsideMissionArea_5nmBuffer;
					}
					break;
				case 10:
					InsideMissionArea_10nmBuffer = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theArea[0].Latitude, theArea[0].Longitude) <= (float)DistanceSlack;
					result = InsideMissionArea_10nmBuffer;
					break;
				default:
					InsideMissionArea_30nmBuffer = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theArea[0].Latitude, theArea[0].Longitude) <= (float)DistanceSlack;
					result = InsideMissionArea_30nmBuffer;
					break;
				case 0:
					InsideMissionArea_NoBuffer = false;
					InsideProsecutionArea_NoBuffer = false;
					result = false;
					break;
				}
			}
			else if (theArea.Count > 1)
			{
				if (!Information.IsNothing((object)theArea_Buffer) && !Information.IsNothing((object)theArea_ChangeCheck))
				{
					switch (DistanceSlack)
					{
					case 1:
						InsideMissionArea_1nmBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea_Buffer.ToList(), myUnit.ParentScen, UseCache: false);
						result = InsideMissionArea_1nmBuffer;
						goto end_IL_0001;
					case 2:
						InsideMissionArea_2nmBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea_Buffer.ToList(), myUnit.ParentScen, UseCache: false);
						result = InsideMissionArea_2nmBuffer;
						goto end_IL_0001;
					case 5:
						if (IsProsecutionArea)
						{
							InsideProsecutionArea_5nmBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea_Buffer.ToList(), myUnit.ParentScen, UseCache: false);
							result = InsideProsecutionArea_5nmBuffer;
						}
						else
						{
							InsideMissionArea_5nmBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea_Buffer.ToList(), myUnit.ParentScen, UseCache: false);
							result = InsideMissionArea_5nmBuffer;
						}
						goto end_IL_0001;
					case 10:
						InsideMissionArea_10nmBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea_Buffer.ToList(), myUnit.ParentScen, UseCache: false);
						result = InsideMissionArea_10nmBuffer;
						goto end_IL_0001;
					default:
						InsideMissionArea_30nmBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea_Buffer.ToList(), myUnit.ParentScen, UseCache: false);
						result = InsideMissionArea_30nmBuffer;
						goto end_IL_0001;
					case 0:
						break;
					}
				}
				if (IsProsecutionArea)
				{
					InsideProsecutionArea_NoBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea.ToList(), myUnit.ParentScen, UseCache: false);
					result = InsideProsecutionArea_NoBuffer;
				}
				else
				{
					InsideMissionArea_NoBuffer = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea.ToList(), myUnit.ParentScen, UseCache: false);
					result = InsideMissionArea_NoBuffer;
				}
			}
			else
			{
				result = false;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200319", ex2.Message);
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
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool IsInsideUncertaintryArea(ref List<GeoPoint> theArea, float DistanceSlack)
	{
		bool result;
		if (theArea.Count == 0)
		{
			result = false;
		}
		else
		{
			try
			{
				if (DistanceSlack == 0f)
				{
					result = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea, myUnit.ParentScen, UseCache: true);
				}
				else
				{
					List<Geopoint_Struct> BufferedArea_GeoPoints = new List<Geopoint_Struct>();
					CalculateAreaWithThresholdAdded_NM(DistanceSlack, ref theArea, ref BufferedArea_GeoPoints);
					result = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(BufferedArea_GeoPoints, myUnit.ParentScen, UseCache: true);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101261", "");
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
		}
		return result;
	}

	public bool IsInsideUncertaintryArea(ref PooledList<Geopoint_Struct> theArea, float DistanceSlack)
	{
		bool result;
		if (theArea.Count != 0)
		{
			try
			{
				if (DistanceSlack == 0f)
				{
					result = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea, myUnit.ParentScen, UseCache: true);
				}
				else
				{
					List<Geopoint_Struct> BufferedArea_GeoPoints = new List<Geopoint_Struct>();
					CalculateAreaWithThresholdAdded_NM(DistanceSlack, ref theArea, ref BufferedArea_GeoPoints);
					result = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(BufferedArea_GeoPoints, myUnit.ParentScen, UseCache: true);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 3095732967", "");
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
		}
		else
		{
			result = false;
		}
		return result;
	}

	public bool IsInsideUncertaintryArea(ref List<Geopoint_Struct> theArea, float DistanceSlack)
	{
		bool result;
		if (theArea.Count != 0)
		{
			try
			{
				if (DistanceSlack == 0f)
				{
					result = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(theArea, myUnit.ParentScen, UseCache: true);
				}
				else
				{
					List<Geopoint_Struct> BufferedArea_GeoPoints = new List<Geopoint_Struct>();
					CalculateAreaWithThresholdAdded_NM(DistanceSlack, ref theArea, ref BufferedArea_GeoPoints);
					result = ((Module_Unit.Unit)myUnit).get_IsInsideThisArea(BufferedArea_GeoPoints, myUnit.ParentScen, UseCache: true);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 3095732967", "");
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
		}
		else
		{
			result = false;
		}
		return result;
	}

	public static void CalculateAreaWithThresholdAdded_NM(float ProximityThreshold_nm, ref List<ReferencePoint> theArea, ref List<ReferencePoint> BufferedArea_RefPoints, ref List<ReferencePoint> ChangeCheck_RefPoints)
	{
		try
		{
			int count = theArea.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			int index;
			if (ChangeCheck_RefPoints != null)
			{
				ChangeCheck_RefPoints.Clear();
				List<ReferencePoint> list = new List<ReferencePoint>();
				int num2 = count - 1;
				for (int i = 0; i <= num2; i++)
				{
					List<ReferencePoint> list2;
					ReferencePoint theOriginalRefPoint = (list2 = theArea)[index = i];
					ReferencePoint item = ReferencePoint.CopyRefPoint(ref theOriginalRefPoint);
					list2[index] = theOriginalRefPoint;
					list.Add(item);
				}
				ChangeCheck_RefPoints = list;
				if (ProximityThreshold_nm == 0f)
				{
					return;
				}
			}
			if (count == 0)
			{
				return;
			}
			float num3 = ProximityThreshold_nm * 1852f;
			Coordinate[] array = new Coordinate[num + 1];
			index = count - 1;
			for (int j = 0; j <= index; j++)
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[j].Longitude, theArea[j].Latitude);
				array[j] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
			}
			if (count > 2)
			{
				array[count] = array[0];
			}
			BufferedArea_RefPoints.Clear();
			List<ReferencePoint> list3 = new List<ReferencePoint>();
			IGeometry geometry = default(IGeometry);
			if (count > 2)
			{
				List<IntPoint> list4 = new List<IntPoint>();
				Coordinate[] array2 = array;
				foreach (Coordinate coordinate in array2)
				{
					list4.Add(new IntPoint(coordinate.X, coordinate.Y));
				}
				ClipperOffset clipperOffset = new ClipperOffset();
				clipperOffset.AddPath(list4, JoinType.jtSquare, EndType.etClosedPolygon);
				List<List<IntPoint>> solution = new List<List<IntPoint>>();
				try
				{
					clipperOffset.Execute(ref solution, num3);
					List<Coordinate> list5 = new List<Coordinate>();
					foreach (IntPoint item2 in solution[0])
					{
						list5.Add(new Coordinate(item2.X, item2.Y));
					}
					geometry = new Polygon(list5);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200304", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			else
			{
				switch (count)
				{
				case 2:
				{
					LineString lineString = new LineString(array);
					try
					{
						geometry = lineString.Buffer(num3, 3);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 200309", ex6.Message);
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				case 1:
				{
					Point point = new Point(array[0]);
					try
					{
						geometry = point.Buffer(num3, 3);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200310", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				}
			}
			IList<Coordinate> list6 = geometry?.Coordinates;
			if (Debugger.IsAttached && (geometry == null || list6.Count == 0))
			{
				Debugger.Break();
			}
			if (geometry != null)
			{
				int num4 = list6.Count - 2;
				for (int l = 0; l <= num4; l++)
				{
					MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(list6[l].X, list6[l].Y);
					list3.Add(new ReferencePoint(tCoord.Lon, tCoord.Lat, AssignObjectID: false));
				}
				BufferedArea_RefPoints = list3;
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 200303", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float ProximityThreshold_nm, ref List<ReferencePoint> theArea, ref List<Geopoint_Struct> BufferedArea_GeoPoints, ref List<ReferencePoint> ChangeCheck_RefPoints)
	{
		PooledList<Coordinate> pooledList = default(PooledList<Coordinate>);
		try
		{
			int count = theArea.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			int index;
			if (ChangeCheck_RefPoints != null)
			{
				ChangeCheck_RefPoints.Clear();
				ReferencePoint[] array = new ReferencePoint[count - 1 + 1];
				int num2 = count - 1;
				for (int i = 0; i <= num2; i++)
				{
					int num3 = i;
					List<ReferencePoint> list;
					ReferencePoint theOriginalRefPoint = (list = theArea)[index = i];
					ReferencePoint referencePoint = ReferencePoint.CopyRefPoint(ref theOriginalRefPoint);
					list[index] = theOriginalRefPoint;
					array[num3] = referencePoint;
				}
				ChangeCheck_RefPoints = Misc.ToList_NoLINQ(array);
				if (ProximityThreshold_nm == 0f)
				{
					return;
				}
			}
			if (count == 0)
			{
				return;
			}
			float num4 = ProximityThreshold_nm * 1852f;
			Coordinate[] array2 = new Coordinate[num + 1];
			index = count - 1;
			for (int j = 0; j <= index; j++)
			{
				MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theArea[j].Longitude, theArea[j].Latitude);
				array2[j] = new Coordinate(mercatorPixel.x, mercatorPixel.y);
			}
			if (count > 2)
			{
				array2[count] = array2[0];
			}
			BufferedArea_GeoPoints.Clear();
			IGeometry geometry = default(IGeometry);
			if (count > 2)
			{
				IntPoint[] array3 = new IntPoint[array2.Length - 1 + 1];
				int num5 = array2.Length - 1;
				for (int k = 0; k <= num5; k++)
				{
					Coordinate coordinate = array2[k];
					array3[k] = new IntPoint(coordinate.X, coordinate.Y);
				}
				ClipperOffset clipperOffset = new ClipperOffset();
				clipperOffset.AddPath(array3, JoinType.jtSquare, EndType.etClosedPolygon);
				List<List<IntPoint>> solution = new List<List<IntPoint>>();
				try
				{
					clipperOffset.Execute(ref solution, num4);
					pooledList = new PooledList<Coordinate>(solution[0].Count);
					foreach (IntPoint item in solution[0])
					{
						pooledList.Add(new Coordinate(item.X, item.Y));
					}
					geometry = new Polygon(pooledList);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200304", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			else
			{
				switch (count)
				{
				case 2:
				{
					LineString lineString = new LineString(array2);
					try
					{
						geometry = lineString.Buffer(num4, 3);
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 200309", ex6.Message);
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				case 1:
				{
					Point point = new Point(array2[0]);
					try
					{
						geometry = point.Buffer(num4, 3);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200310", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
					break;
				}
				}
			}
			IList<Coordinate> list2 = geometry?.Coordinates;
			if (Debugger.IsAttached && (geometry == null || list2.Count == 0))
			{
				Debugger.Break();
			}
			if (geometry != null)
			{
				List<Geopoint_Struct> list3 = new List<Geopoint_Struct>(list2.Count);
				int num6 = list2.Count - 2;
				for (int l = 0; l <= num6; l++)
				{
					MercatorProjection.TCoord tCoord = MercatorProjection.toGeoCoord(list2[l].X, list2[l].Y);
					list3.Add(new Geopoint_Struct(tCoord.Lon, tCoord.Lat, 0f));
				}
				BufferedArea_GeoPoints = list3;
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 200303", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			pooledList?.Dispose();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float ProximityThreshold_nm, ref PooledList<Geopoint_Struct> theArea, ref List<Geopoint_Struct> BufferedArea_GeoPoints)
	{
		try
		{
			int count = theArea.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			if (ProximityThreshold_nm == 0f)
			{
				return;
			}
			float num2 = ProximityThreshold_nm * 1852f;
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(theArea[0].Latitude, theArea[0].Longitude);
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			int num3 = count - 1;
			int num4 = 0;
			double X = default(double);
			double Y = default(double);
			IGeometry geometry = default(IGeometry);
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			while (true)
			{
				if (num4 <= num3)
				{
					if (!tLocalTM.method_0(theArea[num4].Latitude, theArea[num4].Longitude, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
					{
						break;
					}
					array[num4] = new Coordinate(X, Y);
					num4++;
					continue;
				}
				if (count > 2)
				{
					array[count] = array[0];
				}
				BufferedArea_GeoPoints.Clear();
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				if (count > 2)
				{
					List<IntPoint> list2 = new List<IntPoint>();
					double num5 = 10000.0;
					Coordinate[] array2 = array;
					foreach (Coordinate coordinate in array2)
					{
						list2.Add(new IntPoint(coordinate.X * num5, coordinate.Y * num5));
					}
					ClipperOffset clipperOffset = new ClipperOffset();
					clipperOffset.AddPath(list2, JoinType.jtSquare, EndType.etClosedPolygon);
					List<List<IntPoint>> solution = new List<List<IntPoint>>();
					try
					{
						clipperOffset.Execute(ref solution, (double)num2 * num5);
						if (solution.Count > 0)
						{
							List<Coordinate> list3 = new List<Coordinate>();
							foreach (IntPoint item in solution[0])
							{
								list3.Add(new Coordinate((double)item.X / num5, (double)item.Y / num5));
							}
							geometry = new Polygon(list3);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200305", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
				}
				else
				{
					switch (count)
					{
					case 2:
					{
						LineString lineString = new LineString(array);
						try
						{
							geometry = lineString.Buffer(num2, 3);
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 200317", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					case 1:
					{
						Point point = new Point(array[0]);
						try
						{
							geometry = point.Buffer(num2, 3);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200318", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					}
				}
				if (geometry == null)
				{
					return;
				}
				IList<Coordinate> coordinates = geometry.Coordinates;
				int num6 = coordinates.Count - 2;
				for (int j = 0; j <= num6; j++)
				{
					Coordinate coordinate2 = coordinates[j];
					tLocalTM.method_1(coordinate2.X, coordinate2.Y, ref LatitudeD, ref LongitudeD);
					if (LongitudeD > 180.0)
					{
						LongitudeD = 180.0;
					}
					else if (LongitudeD < -180.0)
					{
						LongitudeD = -180.0;
					}
					if (LatitudeD > 90.0)
					{
						LatitudeD = 90.0;
					}
					else if (LatitudeD < -90.0)
					{
						LatitudeD = -90.0;
					}
					list.Add(new Geopoint_Struct(LongitudeD, LatitudeD));
				}
				BufferedArea_GeoPoints = list;
				return;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 200306", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float ProximityThreshold_nm, ref List<Geopoint_Struct> theArea, ref List<Geopoint_Struct> BufferedArea_GeoPoints)
	{
		try
		{
			int count = theArea.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			if (ProximityThreshold_nm == 0f)
			{
				return;
			}
			float num2 = ProximityThreshold_nm * 1852f;
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(theArea[0].Latitude, theArea[0].Longitude);
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			int num3 = count - 1;
			int num4 = 0;
			double X = default(double);
			double Y = default(double);
			IGeometry geometry = default(IGeometry);
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			while (true)
			{
				if (num4 <= num3)
				{
					if (!tLocalTM.method_0(theArea[num4].Latitude, theArea[num4].Longitude, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
					{
						break;
					}
					array[num4] = new Coordinate(X, Y);
					num4++;
					continue;
				}
				if (count > 2)
				{
					array[count] = array[0];
				}
				BufferedArea_GeoPoints.Clear();
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				if (count > 2)
				{
					double num5 = 10000.0;
					IntPoint[] array2 = new IntPoint[array.Length - 1 + 1];
					int num6 = array.Length - 1;
					for (int i = 0; i <= num6; i++)
					{
						Coordinate coordinate = array[i];
						array2[i] = new IntPoint(coordinate.X * num5, coordinate.Y * num5);
					}
					ClipperOffset clipperOffset = new ClipperOffset();
					clipperOffset.AddPath(array2, JoinType.jtSquare, EndType.etClosedPolygon);
					List<List<IntPoint>> solution = new List<List<IntPoint>>();
					try
					{
						clipperOffset.Execute(ref solution, (double)num2 * num5);
						if (solution.Count > 0)
						{
							List<Coordinate> list2 = new List<Coordinate>();
							foreach (IntPoint item in solution[0])
							{
								list2.Add(new Coordinate((double)item.X / num5, (double)item.Y / num5));
							}
							geometry = new Polygon(list2);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200305", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
				}
				else
				{
					switch (count)
					{
					case 2:
					{
						LineString lineString = new LineString(array);
						try
						{
							geometry = lineString.Buffer(num2, 3);
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 200317", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					case 1:
					{
						Point point = new Point(array[0]);
						try
						{
							geometry = point.Buffer(num2, 3);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200318", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					}
				}
				if (geometry == null)
				{
					return;
				}
				IList<Coordinate> coordinates = geometry.Coordinates;
				int num7 = coordinates.Count - 2;
				for (int j = 0; j <= num7; j++)
				{
					Coordinate coordinate2 = coordinates[j];
					tLocalTM.method_1(coordinate2.X, coordinate2.Y, ref LatitudeD, ref LongitudeD);
					if (LongitudeD > 180.0)
					{
						LongitudeD = 180.0;
					}
					else if (LongitudeD < -180.0)
					{
						LongitudeD = -180.0;
					}
					if (LatitudeD > 90.0)
					{
						LatitudeD = 90.0;
					}
					else if (LatitudeD < -90.0)
					{
						LatitudeD = -90.0;
					}
					list.Add(new Geopoint_Struct(LongitudeD, LatitudeD));
				}
				BufferedArea_GeoPoints = list;
				return;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 200306", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float ProximityThreshold_nm, ref List<GeoPoint> theArea, ref List<Geopoint_Struct> BufferedArea_GeoPoints)
	{
		try
		{
			int count = theArea.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			if (ProximityThreshold_nm == 0f)
			{
				return;
			}
			float num2 = ProximityThreshold_nm * 1852f;
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(theArea[0].Latitude, theArea[0].Longitude);
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			int num3 = count - 1;
			int num4 = 0;
			double X = default(double);
			double Y = default(double);
			IGeometry geometry = default(IGeometry);
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			while (true)
			{
				if (num4 <= num3)
				{
					if (!tLocalTM.method_0(theArea[num4].Latitude, theArea[num4].Longitude, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
					{
						break;
					}
					array[num4] = new Coordinate(X, Y);
					num4++;
					continue;
				}
				if (count > 2)
				{
					array[count] = array[0];
				}
				BufferedArea_GeoPoints.Clear();
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				if (count > 2)
				{
					double num5 = 10000.0;
					IntPoint[] array2 = new IntPoint[array.Length - 1 + 1];
					int num6 = array.Length - 1;
					for (int i = 0; i <= num6; i++)
					{
						Coordinate coordinate = array[i];
						array2[i] = new IntPoint(coordinate.X * num5, coordinate.Y * num5);
					}
					ClipperOffset clipperOffset = new ClipperOffset();
					clipperOffset.AddPath(array2, JoinType.jtSquare, EndType.etClosedPolygon);
					List<List<IntPoint>> solution = new List<List<IntPoint>>();
					try
					{
						clipperOffset.Execute(ref solution, (double)num2 * num5);
						if (solution.Count > 0)
						{
							List<Coordinate> list2 = new List<Coordinate>();
							foreach (IntPoint item in solution[0])
							{
								list2.Add(new Coordinate((double)item.X / num5, (double)item.Y / num5));
							}
							geometry = new Polygon(list2);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200305", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
				}
				else
				{
					switch (count)
					{
					case 2:
					{
						LineString lineString = new LineString(array);
						try
						{
							geometry = lineString.Buffer(num2, 3);
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 200317", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					case 1:
					{
						Point point = new Point(array[0]);
						try
						{
							geometry = point.Buffer(num2, 3);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200318", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					}
				}
				if (geometry == null)
				{
					return;
				}
				IList<Coordinate> coordinates = geometry.Coordinates;
				int num7 = coordinates.Count - 2;
				for (int j = 0; j <= num7; j++)
				{
					Coordinate coordinate2 = coordinates[j];
					tLocalTM.method_1(coordinate2.X, coordinate2.Y, ref LatitudeD, ref LongitudeD);
					if (LongitudeD > 180.0)
					{
						LongitudeD = 180.0;
					}
					else if (LongitudeD < -180.0)
					{
						LongitudeD = -180.0;
					}
					if (LatitudeD > 90.0)
					{
						LatitudeD = 90.0;
					}
					else if (LatitudeD < -90.0)
					{
						LatitudeD = -90.0;
					}
					list.Add(new Geopoint_Struct(LongitudeD, LatitudeD));
				}
				BufferedArea_GeoPoints = list;
				return;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 200306", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void CalculateAreaWithThresholdAdded_NM(float ProximityThreshold_nm, ref List<Geopoint_Struct> theArea, ref List<GeoPoint> BufferedArea_GeoPoints)
	{
		try
		{
			int count = theArea.Count;
			int num = ((count <= 2) ? (count - 1) : count);
			if (ProximityThreshold_nm == 0f)
			{
				return;
			}
			float num2 = ProximityThreshold_nm * 1852f;
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(theArea[0].Latitude, theArea[0].Longitude);
			if (count == 0)
			{
				return;
			}
			Coordinate[] array = new Coordinate[num + 1];
			int num3 = count - 1;
			int num4 = 0;
			double X = default(double);
			double Y = default(double);
			IGeometry geometry = default(IGeometry);
			double LatitudeD = default(double);
			double LongitudeD = default(double);
			while (true)
			{
				if (num4 <= num3)
				{
					if (!tLocalTM.method_0(theArea[num4].Latitude, theArea[num4].Longitude, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: false))
					{
						break;
					}
					array[num4] = new Coordinate(X, Y);
					num4++;
					continue;
				}
				if (count > 2)
				{
					array[count] = array[0];
				}
				BufferedArea_GeoPoints.Clear();
				List<GeoPoint> list = new List<GeoPoint>();
				if (count > 2)
				{
					double num5 = 10000.0;
					IntPoint[] array2 = new IntPoint[array.Length - 1 + 1];
					int num6 = array.Length - 1;
					for (int i = 0; i <= num6; i++)
					{
						Coordinate coordinate = array[i];
						array2[i] = new IntPoint(coordinate.X * num5, coordinate.Y * num5);
					}
					ClipperOffset clipperOffset = new ClipperOffset();
					clipperOffset.AddPath(array2, JoinType.jtSquare, EndType.etClosedPolygon);
					List<List<IntPoint>> solution = new List<List<IntPoint>>();
					try
					{
						clipperOffset.Execute(ref solution, (double)num2 * num5);
						if (solution.Count > 0)
						{
							List<Coordinate> list2 = new List<Coordinate>();
							foreach (IntPoint item in solution[0])
							{
								list2.Add(new Coordinate((double)item.X / num5, (double)item.Y / num5));
							}
							geometry = new Polygon(list2);
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200305", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						return;
					}
				}
				else
				{
					switch (count)
					{
					case 2:
					{
						LineString lineString = new LineString(array);
						try
						{
							geometry = lineString.Buffer(num2, 3);
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							ex6?.Data.Add("Error at 200317", ex6.Message);
							GameGeneral.WriteExceptionsToLog(ex6);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					case 1:
					{
						Point point = new Point(array[0]);
						try
						{
							geometry = point.Buffer(num2, 3);
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 200318", ex4.Message);
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
							return;
						}
						break;
					}
					}
				}
				if (geometry == null)
				{
					return;
				}
				IList<Coordinate> coordinates = geometry.Coordinates;
				int num7 = coordinates.Count - 2;
				for (int j = 0; j <= num7; j++)
				{
					tLocalTM.method_1(coordinates[j].X, coordinates[j].Y, ref LatitudeD, ref LongitudeD);
					if (LongitudeD > 180.0)
					{
						LongitudeD = 180.0;
					}
					else if (LongitudeD < -180.0)
					{
						LongitudeD = -180.0;
					}
					if (LatitudeD > 90.0)
					{
						LatitudeD = 90.0;
					}
					else if (LatitudeD < -90.0)
					{
						LatitudeD = -90.0;
					}
					list.Add(new GeoPoint(LongitudeD, LatitudeD));
				}
				BufferedArea_GeoPoints = list;
				return;
			}
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 34573409587239867345", ex8.Message);
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void PlotCourseToCargoDestination(ActiveUnit DestinationUnit)
	{
		try
		{
			ClearPlottedCourse();
			if (DestinationUnit != null)
			{
				AddWaypoint(DestinationUnit.get_Latitude((GlobalVariables.BooleanObject)null), DestinationUnit.get_Longitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
				if (PlottedCourse.Count() > 0)
				{
					PlottedCourse[0].Description = "Cargo delivery destination";
				}
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), DestinationUnit.get_Latitude((GlobalVariables.BooleanObject)null), DestinationUnit.get_Longitude((GlobalVariables.BooleanObject)null)));
				ResetTimeToNextPathfinderCheck();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at KJHKJHLHJBSSGZ", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void PlotCourseToArea(List<ReferencePoint> theArea, bool OvershootDestination = false, Waypoint.WaypointType WaypointType = Waypoint.WaypointType.PatrolStation)
	{
		try
		{
			double latitude = default(double);
			double longitude = default(double);
			switch (theArea.Count)
			{
			default:
			{
				bool flag = false;
				int num = 0;
				while (!flag)
				{
					Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(theArea);
					if (!geopoint_Struct.HasZeroCoords)
					{
						ActiveUnit activeUnit2 = myUnit;
						double latitude2 = geopoint_Struct.Latitude;
						double longitude2 = geopoint_Struct.Longitude;
						int MovementCost = 0;
						bool CheckNoNavZones = true;
						bool CheckForMines = true;
						List<ActiveUnit> ProvidedPiers = null;
						string UserFeedback = "";
						bool AllowBounce = false;
						if (activeUnit2.CanMoveToThisLocation(latitude2, longitude2, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
						{
							flag = true;
							latitude = geopoint_Struct.Latitude;
							longitude = geopoint_Struct.Longitude;
						}
						num++;
						if (num >= 32767)
						{
							return;
						}
						continue;
					}
					myUnit.AddMessage(myUnit.Name + " is unable to pick a suitable point inside area defined by Ref. Points: " + string.Join(" - ", theArea.Select([SpecialName] (ReferencePoint theP) => theP.Name)), "Unable to pick a point", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					return;
				}
				break;
			}
			case 0:
			{
				ActiveUnit activeUnit = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: true, ref Result);
				ClearPlottedCourse();
				return;
			}
			case 1:
				latitude = theArea[0].Latitude;
				longitude = theArea[0].Longitude;
				break;
			case 2:
			{
				List<ReferencePoint> list = theArea.OrderByDescending([SpecialName] (ReferencePoint theP) => Module_Unit.RangeToPoint_Horiz(myUnit, theP.Latitude, theP.Longitude)).ToList();
				longitude = list[0].Longitude;
				latitude = list[0].Latitude;
				break;
			}
			}
			ClearPlottedCourse();
			AddWaypoint(latitude, longitude, 0f, WaypointType, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, OvershootDestination);
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), latitude, longitude));
			ResetTimeToNextPathfinderCheck();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at KJHKJHLHJBSSGY", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PlotCourseToPickupPoint()
	{
		if (Information.IsNothing((object)myUnit.AI.PrimaryPickupTarget))
		{
			return;
		}
		ClearPlottedCourse();
		double latitude = myUnit.AI.PrimaryPickupTarget.get_Latitude((GlobalVariables.BooleanObject)null);
		double longitude = myUnit.AI.PrimaryPickupTarget.get_Longitude((GlobalVariables.BooleanObject)null);
		if (!myUnit.IsAircraft)
		{
			List<GeoPoint> list = myUnit.DockingOps.FindPossiblePickupLocations(myUnit, myUnit.AI.PrimaryPickupTarget);
			if (list == null || list.Count <= 0)
			{
				return;
			}
			latitude = list.First().Latitude;
			longitude = list.First().Longitude;
		}
		AddWaypoint(latitude, longitude, 0f, Waypoint.WaypointType.PickupPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse, _Overshoot: false);
	}

	public virtual void PlotCourseToStationArea(float elapsedTime, bool AddWaypointToExistingPlottedCourse)
	{
		try
		{
			if (Module_ActiveUnit.PlayerIsPlottingCourseForThisUnit(myUnit))
			{
				return;
			}
			if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				if (((Patrol)myUnit.ActiveMissionOrPackage()).MovementStyle == Patrol.PatrolMovementStyle.RepeatableLoop)
				{
					FollowPatrolRepeatableLoopCourse(elapsedTime, !IsInsidePatrolArea);
					return;
				}
				if (((Patrol)myUnit.ActiveMissionOrPackage()).MovementStyle == Patrol.PatrolMovementStyle.ChainsawLoop)
				{
					FollowPatrolChainsawMovementPattern(elapsedTime, !IsInsidePatrolArea);
					return;
				}
				Aircraft aircraft = default(Aircraft);
				if (myUnit.IsAircraft)
				{
					aircraft = (Aircraft)myUnit;
				}
				if (myUnit.IsGroup)
				{
					ActiveUnit groupLead = ((Group)myUnit).GroupLead;
					if (groupLead.IsAircraft)
					{
						aircraft = (Aircraft)groupLead;
					}
				}
				if (aircraft != null)
				{
					Aircraft_AirOps airOps = aircraft.AirOps;
					Aircraft_Navigator navigator = aircraft.Navigator;
					navigator.SetPatrolThrottle(PursueContact: false, airOps.Condition);
					navigator.SetPatrolAltitude(PursueContact: false, airOps.Condition);
				}
			}
			else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
				bool flag = myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false);
				if (((MineClearingMission)myUnit.ActiveMissionOrPackage()).MovementStyle == Mission.MissionMovementStyle.RepeatableLoop)
				{
					FollowMineClearingMissionCourse(elapsedTime, !flag);
				}
				else
				{
					PlotCourseToArea(mineClearingMission.Area);
				}
				return;
			}
			if (myUnit.ActiveMissionOrPackage() == null)
			{
				return;
			}
			List<ReferencePoint> list;
			if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				if (patrol == null || patrol.PatrolArea == null)
				{
					return;
				}
				list = patrol.PatrolArea;
			}
			else
			{
				if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Support)
				{
					return;
				}
				SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
				if (supportMission == null || supportMission.NavigationCourse == null)
				{
					return;
				}
				list = supportMission.NavigationCourse;
			}
			double? num2 = default(double?);
			double? num = default(double?);
			switch (list.Count)
			{
			default:
			{
				int num3;
				if (!Information.IsNothing((object)PlottedCourse) && PlottedCourse.Count() != 0)
				{
					if (!AddWaypointToExistingPlottedCourse)
					{
						break;
					}
					num3 = 0;
				}
				else
				{
					num3 = 0;
				}
				bool flag2 = (byte)num3 != 0;
				int num4 = 0;
				while (!flag2)
				{
					num4++;
					Geopoint_Struct geopoint_Struct = Math2.RandomPointWithinThisArea(list);
					if (!Information.IsNothing((object)geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
					{
						ActiveUnit activeUnit2 = myUnit;
						double latitude = geopoint_Struct.Latitude;
						double longitude = geopoint_Struct.Longitude;
						int MovementCost = 0;
						bool CheckNoNavZones = true;
						bool CheckForMines = true;
						List<ActiveUnit> ProvidedPiers = null;
						string UserFeedback = "";
						bool AllowBounce = false;
						if (!activeUnit2.CanMoveToThisLocation(latitude, longitude, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
						{
							if (num4 > 1000)
							{
								myUnit.AddMessage(myUnit.Name + " is unable to pick a suitable point inside station area defined by Ref. Points: " + string.Join(" - ", list.Select([SpecialName] (ReferencePoint theP) => theP.Name)), "Unable to pick a point", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								return;
							}
							continue;
						}
						flag2 = true;
						num2 = geopoint_Struct.Latitude;
						num = geopoint_Struct.Longitude;
						break;
					}
					myUnit.AddMessage(myUnit.Name + " is unable to pick a suitable point inside station area defined by Ref. Points: " + string.Join(" - ", list.Select([SpecialName] (ReferencePoint theP) => theP.Name)), "Unable to pick a point", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					return;
				}
				break;
			}
			case 0:
				if (!HasFlightPlan)
				{
					if (Information.IsNothing((object)PlottedCourse) || PlottedCourse.Count() == 0)
					{
						myUnit.AddMessage(myUnit.Name + " has been removed from mission: " + myUnit.ActiveMissionOrPackage().Name + " (station area not defined!)", myUnit.Name + " taken off mission", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						ActiveUnit activeUnit = myUnit;
						Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
						activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
					}
					break;
				}
				return;
			case 1:
				if (Information.IsNothing((object)PlottedCourse) || PlottedCourse.Count() == 0 || AddWaypointToExistingPlottedCourse)
				{
					num2 = list[0].Latitude;
					num = list[0].Longitude;
				}
				break;
			case 2:
				if (Information.IsNothing((object)PlottedCourse) || PlottedCourse.Count() == 0 || AddWaypointToExistingPlottedCourse)
				{
					ReferencePoint referencePoint = null;
					referencePoint = list.OrderByDescending([SpecialName] (ReferencePoint theP) =>
					{
						ActiveUnit activeUnit3 = myUnit;
						ReferencePoint referencePoint2;
						double theLat = (referencePoint2 = theP).Latitude;
						ReferencePoint referencePoint3;
						double theLon = (referencePoint3 = theP).Longitude;
						double result = Module_Unit.RangeToPoint_Horiz_Angular(activeUnit3, ref theLat, ref theLon);
						referencePoint3.Longitude = theLon;
						referencePoint2.Latitude = theLat;
						return result;
					}).ElementAtOrDefault(0);
					num = referencePoint.Longitude;
					num2 = referencePoint.Latitude;
				}
				break;
			}
			if (num2.HasValue && num.HasValue)
			{
				if (AddWaypointToExistingPlottedCourse && myUnit.Navigator.PlottedCourse.Count() > 0)
				{
					myUnit.Navigator.ClearPathfindingWaypoints();
					Waypoint theWP = new Waypoint(num.Value, num2.Value, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					ActiveUnit_Navigator navigator2 = myUnit.Navigator;
					Waypoint[] theFlightPlan = navigator2.PlottedCourse;
					AddWaypoint(ref theFlightPlan, 0, theWP);
					navigator2.PlottedCourse = theFlightPlan;
				}
				else if (myUnit.AI.PrimaryTarget == null)
				{
					ClearPlottedCourse();
					AddWaypoint(num2.Value, num.Value, 0f, Waypoint.WaypointType.PatrolStation, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
				}
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num2.Value, num.Value));
			}
			ResetTimeToNextPathfinderCheck();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100221", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal bool PlotCourseToStationArea_FlightplanGenerator(ref double StationStart_Lat, ref double StationStart_Lon, ref double StationEnd_Lat, ref double StationEnd_Lon, ref float StationLength_nm)
	{
		bool result;
		try
		{
			_Closure$__195-0 arg = default(_Closure$__195-0);
			_Closure$__195-0 CS$<>8__locals12 = new _Closure$__195-0(arg);
			Mission mission;
			List<ReferencePoint> list;
			if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				mission = myUnit.ActiveMissionOrPackage();
				if (mission.MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
					if (!Information.IsNothing((object)patrol))
					{
						if (!Information.IsNothing((object)patrol.PatrolArea))
						{
							list = patrol.PatrolArea;
							goto IL_00ba;
						}
						result = false;
					}
					else
					{
						result = false;
					}
				}
				else if (mission.MissionClass == Mission._MissionClass.Support)
				{
					SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
					if (Information.IsNothing((object)supportMission))
					{
						result = false;
					}
					else
					{
						if (!Information.IsNothing((object)supportMission.NavigationCourse))
						{
							list = supportMission.NavigationCourse;
							goto IL_00ba;
						}
						result = false;
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_00ba:
			if (!myUnit.IsAircraft)
			{
				CS$<>8__locals12.$VB$Local_TakeOffPoint_Lat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				CS$<>8__locals12.$VB$Local_TakeOffPoint_Lon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			else
			{
				Aircraft aircraft = (Aircraft)myUnit;
				if (Information.IsNothing((object)aircraft.AirOps.CurrentHostUnit))
				{
					if (Information.IsNothing((object)aircraft.AirOps.HostAirFacility))
					{
						CS$<>8__locals12.$VB$Local_TakeOffPoint_Lat = aircraft.get_Latitude((GlobalVariables.BooleanObject)null);
						CS$<>8__locals12.$VB$Local_TakeOffPoint_Lon = aircraft.get_Longitude((GlobalVariables.BooleanObject)null);
					}
					else
					{
						CS$<>8__locals12.$VB$Local_TakeOffPoint_Lat = aircraft.AirOps.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null);
						CS$<>8__locals12.$VB$Local_TakeOffPoint_Lon = aircraft.AirOps.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					}
				}
				else
				{
					CS$<>8__locals12.$VB$Local_TakeOffPoint_Lat = aircraft.AirOps.CurrentHostUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					CS$<>8__locals12.$VB$Local_TakeOffPoint_Lon = aircraft.AirOps.CurrentHostUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				}
			}
			switch (list.Count)
			{
			default:
			{
				bool flag = false;
				int num5 = 0;
				while (true)
				{
					if (!flag)
					{
						num5++;
						(Geopoint_Struct, Geopoint_Struct) tuple = Math2.MostDistantPointsWithinArea(list);
						float num6 = Math.Min(Math2.CalcDist(tuple.Item1.Latitude, tuple.Item1.Longitude, tuple.Item2.Latitude, tuple.Item2.Longitude), 10f);
						var (geopoint_Struct, geopoint_Struct2) = Math2.RandomPointsWithinAreaWithMinDistance(list, num6);
						if (!geopoint_Struct.HasZeroCoords && !geopoint_Struct2.HasZeroCoords)
						{
							ActiveUnit activeUnit = myUnit;
							double latitude = geopoint_Struct.Latitude;
							double longitude = geopoint_Struct.Longitude;
							int MovementCost = 0;
							bool CheckNoNavZones = true;
							bool CheckForMines = true;
							List<ActiveUnit> ProvidedPiers = null;
							string UserFeedback = "";
							bool AllowBounce = false;
							if (activeUnit.CanMoveToThisLocation(latitude, longitude, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
							{
								ActiveUnit activeUnit2 = myUnit;
								double latitude2 = geopoint_Struct2.Latitude;
								double longitude2 = geopoint_Struct2.Longitude;
								MovementCost = 0;
								AllowBounce = true;
								CheckForMines = true;
								ProvidedPiers = null;
								UserFeedback = "";
								CheckNoNavZones = false;
								if (activeUnit2.CanMoveToThisLocation(latitude2, longitude2, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref AllowBounce, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref CheckNoNavZones))
								{
									flag = true;
									StationStart_Lat = geopoint_Struct.Latitude;
									StationStart_Lon = geopoint_Struct.Longitude;
									StationEnd_Lat = geopoint_Struct2.Latitude;
									StationEnd_Lon = geopoint_Struct2.Longitude;
									result = true;
									break;
								}
							}
							if (num5 > 1000)
							{
								myUnit.AddMessage("Flightplan generator for mission " + mission.Name + " is unable to pick two suitable points inside station area defined by Ref. Points: " + string.Join(" - ", list.Select([SpecialName] (ReferencePoint theP) => theP.Name)), "Flightplan problem", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
								result = false;
								break;
							}
							continue;
						}
						myUnit.AddMessage("Flightplan generator for mission " + mission.Name + " is unable to pick two suitable points inside station area defined by Ref. Points: " + string.Join(" - ", list.Select([SpecialName] (ReferencePoint theP) => theP.Name)), "Flightplan problem", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						result = false;
						break;
					}
					myUnit.AddMessage("Flightplan generator for mission " + mission.Name + " is unable to pick two suitable points inside station area defined by Ref. Points: " + string.Join(" - ", list.Select([SpecialName] (ReferencePoint theP) => theP.Name)), "Flightplan problem", LoggedMessage.MessageType.UnitAI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					result = false;
					break;
				}
				break;
			}
			case 0:
			{
				myUnit.AddMessage("Mission " + mission.Name + " has no station area defined!", "Mission has no station area!", LoggedMessage.MessageType.UnitAI, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				ActiveUnit activeUnit3 = myUnit;
				Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
				activeUnit3.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
				result = false;
				break;
			}
			case 1:
			{
				StationStart_Lat = list[0].Latitude;
				StationStart_Lon = list[0].Longitude;
				float num7 = Math2.CalcAzimuth(CS$<>8__locals12.$VB$Local_TakeOffPoint_Lat, CS$<>8__locals12.$VB$Local_TakeOffPoint_Lon, StationStart_Lat, StationStart_Lon);
				num7 += (float)GameGeneral.GlobalRNG.Next(-60, 60);
				Geodesic_EdWilliams.CalcPoint_Williams(StationStart_Lon, StationStart_Lat, ref StationEnd_Lon, ref StationEnd_Lat, StationLength_nm, num7);
				result = true;
				break;
			}
			case 2:
			{
				List<ReferencePoint> list2 = list.OrderByDescending([SpecialName] (ReferencePoint theP) => Math2.CalcDist(theP.Latitude, theP.Longitude, CS$<>8__locals12.$VB$Local_TakeOffPoint_Lat, CS$<>8__locals12.$VB$Local_TakeOffPoint_Lon)).ToList();
				StationStart_Lon = list2[0].Longitude;
				StationStart_Lat = list2[0].Latitude;
				StationEnd_Lon = list2[1].Longitude;
				StationEnd_Lat = list2[1].Latitude;
				float num = Math2.CalcDist(StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon);
				int num3;
				if (num > StationLength_nm)
				{
					float num2 = Math2.CalcAzimuth(StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon);
					float distance_NM = (num - StationLength_nm) / 2f;
					Geodesic_EdWilliams.CalcPoint_Williams(StationStart_Lon, StationStart_Lat, ref StationStart_Lon, ref StationStart_Lat, distance_NM, num2);
					Geodesic_EdWilliams.CalcPoint_Williams(StationEnd_Lon, StationEnd_Lat, ref StationEnd_Lon, ref StationEnd_Lat, distance_NM, Math2.NormalizeBearing(num2 + 180f));
					num3 = 1;
				}
				else if (num < StationLength_nm)
				{
					StationLength_nm = num;
					float num4 = Math2.CalcAzimuth(StationStart_Lat, StationStart_Lon, StationEnd_Lat, StationEnd_Lon);
					float distance_NM2 = (StationLength_nm - num) / 2f;
					Geodesic_EdWilliams.CalcPoint_Williams(StationStart_Lon, StationStart_Lat, ref StationStart_Lon, ref StationStart_Lat, distance_NM2, Math2.NormalizeBearing(num4 + 180f));
					Geodesic_EdWilliams.CalcPoint_Williams(StationEnd_Lon, StationEnd_Lat, ref StationEnd_Lon, ref StationEnd_Lat, distance_NM2, num4);
					num3 = 1;
				}
				else
				{
					num3 = 1;
				}
				result = (byte)num3 != 0;
				break;
			}
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 375382142424", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num8;
			if (!Debugger.IsAttached)
			{
				num8 = 0;
			}
			else
			{
				Debugger.Break();
				num8 = 0;
			}
			result = (byte)num8 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool HasRoadSystemPlottedCourse()
	{
		return myUnit.RoadNetworkPath.Count > 0;
	}

	public bool Has_NonPathfind_NonFP_PlottedCourse(bool IncludeRoadSystemPaths = false)
	{
		Waypoint[] plottedCourse = PlottedCourse;
		int num = plottedCourse.Length;
		if (num != 0)
		{
			try
			{
				int num2 = num - 1;
				int num3 = 0;
				while (true)
				{
					if (num3 <= num2)
					{
						Waypoint waypoint;
						try
						{
							waypoint = plottedCourse[num3];
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
							goto IL_0053;
						}
						if ((waypoint.Type != Waypoint.WaypointType.PathfindingPoint) & (waypoint.Category != Waypoint.WaypointCategory.FlightPlan))
						{
							break;
						}
						goto IL_0053;
					}
					return false;
					IL_0053:
					num3++;
				}
				return true;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200008", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return false;
		}
		return false;
	}

	public bool HasPlottedCourse()
	{
		return PlottedCourse.Length > 0;
	}

	public void RemoveFromFlightAndCleanUpMission()
	{
		if (!myUnit.Navigator.HasFlight)
		{
			return;
		}
		Mission.Flight flight = myUnit.Navigator.get_Flight(HierarchySearch: true);
		Mission mission = myUnit.ActiveMissionOrPackage();
		if (flight == null || mission == null)
		{
			return;
		}
		flight.set_Status(myUnit.ParentScen, Mission._FlightStatus.Completed);
		myUnit.Navigator.ClearFlight();
		bool flag = false;
		foreach (ActiveUnit unit in myUnit.get_UnitSide(SetSideOnly: false).Units)
		{
			if (unit != null && unit != myUnit && unit.Navigator.HasFlight && unit.Navigator.get_Flight(HierarchySearch: true) == flight)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			if (mission.EmptySlotsList != null && mission.EmptySlotsList.Count > 0)
			{
				foreach (Mission.EmptyAircraftSlot emptySlots in mission.EmptySlotsList)
				{
					if (emptySlots.get_MissionFlight(myUnit.ParentScen) == flight)
					{
						emptySlots.set_MissionFlight(myUnit.ParentScen, (Mission.Flight)null);
					}
				}
			}
			mission.RemoveFlight(flight);
		}
		if (mission.UseFlightplans && mission.Category == Mission.MissionCategory.Package)
		{
			ActiveUnit activeUnit = myUnit;
			Mission.MissionAssignmentAttemptResult Result = Mission.MissionAssignmentAttemptResult.None;
			activeUnit.Set_AssignedMissionOrPackage(null, SetMissionOnly: false, IgnoreCommsState: false, ref Result);
			if (!mission.HasFlights())
			{
				myUnit.get_UnitSide(SetSideOnly: false).Missions_Remove(mission);
			}
		}
	}

	public bool CanAutonomouslyPlotAndFollowCourse()
	{
		int result;
		if (!myUnit.IsDrone())
		{
			result = 1;
		}
		else if (myUnit.AutonomyLevel >= ActiveUnit.DroneAutonomyLevel.BattlespaceCognizant)
		{
			result = 1;
		}
		else if (!myUnit.IsGroupMember())
		{
			result = 1;
		}
		else if (myUnit.IsGroupLead())
		{
			result = 1;
		}
		else
		{
			if (!myUnit.CommStuff.IsConnectedToSideNetwork)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	public virtual void AddWaypoint(double Latitude, double Longitude, float Altitude, Waypoint.WaypointType theWaypointType, Waypoint.WaypointCreator theCreator, Waypoint.WaypointCategory theCategory, bool _Overshoot = true)
	{
		if (!CanAutonomouslyPlotAndFollowCourse())
		{
			Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " cannot autonomously plot and follow a course");
			return;
		}
		try
		{
			if (theCreator == Waypoint.WaypointCreator.Manual && HasFlightPlan && HasPlottedCourse() && PlottedCourse[0].Category == Waypoint.WaypointCategory.FlightPlan)
			{
				ClearPlottedCourse(PlayerIsPlottingCourse: true);
			}
			if (myUnit.IsGroupLead())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.AddWaypoint(new Waypoint(Longitude, Latitude, Altitude, theWaypointType, theCreator, theCategory));
			}
			else
			{
				ArrayExtensions.Add(ref _PlottedCourse, new Waypoint(Longitude, Latitude, Altitude, theWaypointType, theCreator, theCategory, _Overshoot));
			}
			ManualPlotOverride = theWaypointType == Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100222", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AddWaypoint(Waypoint theWP)
	{
		_ = Debugger.IsAttached;
		if (!CanAutonomouslyPlotAndFollowCourse())
		{
			Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " cannot autonomously plot and follow a course");
		}
		else if (!myUnit.IsGroupLead())
		{
			ArrayExtensions.Add(ref _PlottedCourse, theWP);
		}
		else
		{
			myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.AddWaypoint(theWP);
		}
	}

	public void AddWaypoint(int IndexToInsert, Waypoint theWP)
	{
		_ = Debugger.IsAttached;
		if (CanAutonomouslyPlotAndFollowCourse())
		{
			if (myUnit.IsGroupLead())
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.AddWaypoint(IndexToInsert, theWP);
				return;
			}
			List<Waypoint> list = _PlottedCourse.ToList();
			list.Insert(IndexToInsert, theWP);
			_PlottedCourse = list.ToArray();
		}
		else
		{
			Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " cannot autonomously plot and follow a course");
		}
	}

	public static void AddWaypoint(ref Waypoint[] theFlightPlan, int IndexToInsert, Waypoint theWP)
	{
		_ = Debugger.IsAttached;
		ArrayExtensions.Insert(ref theFlightPlan, IndexToInsert, theWP);
	}

	public static PooledList<Geopoint_Struct> IntersectAreas(PooledList<Geopoint_Struct> UncertaintyArea, List<ReferencePoint> patrolArea)
	{
		Coordinate[] array = new Coordinate[UncertaintyArea.Count + 1];
		PooledList<Geopoint_Struct> result;
		try
		{
			int num = UncertaintyArea.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Coordinate(UncertaintyArea[i].Longitude, UncertaintyArea[i].Latitude, 0.0);
			}
			array[UncertaintyArea.Count] = array[0];
			Polygon polygon = new Polygon(new LinearRing(array));
			Coordinate[] array2 = new Coordinate[patrolArea.Count + 1];
			int num2 = patrolArea.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array2[j] = new Coordinate(patrolArea[j].Longitude, patrolArea[j].Latitude, 0.0);
			}
			array2[patrolArea.Count] = array2[0];
			Polygon other = new Polygon(new LinearRing(array2));
			try
			{
				Geometry geometry = (Geometry)polygon.Intersection(other);
				if (geometry.Coordinates.Count > 0)
				{
					PooledList<Geopoint_Struct> pooledList = new PooledList<Geopoint_Struct>();
					int num3 = geometry.Coordinates.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						Coordinate coordinate = geometry.Coordinates[k];
						pooledList.Add(new Geopoint_Struct(coordinate.X, coordinate.Y));
					}
					result = pooledList;
				}
				else
				{
					result = null;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 1005586", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 1005596", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static List<Geopoint_Struct> IntersectAreas(List<Geopoint_Struct> UncertaintyArea, List<ReferencePoint> patrolArea)
	{
		Coordinate[] array = new Coordinate[UncertaintyArea.Count + 1];
		List<Geopoint_Struct> result;
		try
		{
			int num = UncertaintyArea.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Coordinate(UncertaintyArea[i].Longitude, UncertaintyArea[i].Latitude, 0.0);
			}
			array[UncertaintyArea.Count] = array[0];
			Polygon polygon = new Polygon(new LinearRing(array));
			Coordinate[] array2 = new Coordinate[patrolArea.Count + 1];
			int num2 = patrolArea.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array2[j] = new Coordinate(patrolArea[j].Longitude, patrolArea[j].Latitude, 0.0);
			}
			array2[patrolArea.Count] = array2[0];
			Polygon other = new Polygon(new LinearRing(array2));
			try
			{
				Geometry geometry = (Geometry)polygon.Intersection(other);
				if (geometry.Coordinates.Count > 0)
				{
					List<Geopoint_Struct> list = new List<Geopoint_Struct>();
					int num3 = geometry.Coordinates.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						Coordinate coordinate = geometry.Coordinates[k];
						list.Add(new Geopoint_Struct(coordinate.X, coordinate.Y));
					}
					result = list;
				}
				else
				{
					result = null;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 1005586", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 1005596", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void PlotLocalizationCourse()
	{
		try
		{
			if (Module_ActiveUnit.PlayerIsPlottingCourseForThisUnit(myUnit) || myUnit.AI.PrimaryTarget == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				if (!GeoPoint.IsInsideThisArea(myUnit.Navigator.PlottedCourse[0].Latitude, myUnit.Navigator.PlottedCourse[0].Longitude, myUnit.AI.PrimaryTarget.UncertaintyArea))
				{
					ClearPlottedCourse();
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			Geopoint_Struct geopoint_Struct = new Geopoint_Struct(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null));
			List<Geopoint_Struct> list = myUnit.AI.PrimaryTarget.UncertaintyArea;
			if (myUnit.IsOnActivePatrol())
			{
				Patrol patrol = (Patrol)myUnit.AssignedMissionOrPackage();
				list = IntersectAreas(myUnit.AI.PrimaryTarget.UncertaintyArea, patrol.PatrolArea);
				if (list == null)
				{
					List<ReferencePoint> prosecutionArea = patrol.ProsecutionArea;
					if (prosecutionArea != null && prosecutionArea.Count > 0)
					{
						list = IntersectAreas(myUnit.AI.PrimaryTarget.UncertaintyArea, patrol.ProsecutionArea);
					}
				}
				if (list == null)
				{
					geopoint_Struct = Math2.FindClosestPoint(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), patrol.PatrolArea);
				}
			}
			GeoPoint.IsInsideThisArea(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), list);
			int num = 0;
			double DestLat = default(double);
			double DestLon = default(double);
			do
			{
				if (list != null)
				{
					geopoint_Struct = Math2.RandomCornerWithinThisArea(list, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), BiasTowardsFarCorners: true);
				}
				else
				{
					num = 10;
				}
				ActiveUnit activeUnit = myUnit;
				double latitude = geopoint_Struct.Latitude;
				double longitude = geopoint_Struct.Longitude;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				List<ActiveUnit> ProvidedPiers = null;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (!activeUnit.CanMoveToThisLocation(latitude, longitude, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: true, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					string text = "";
					if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					if (flag2)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + text + " is trying to plot a localization course to pinpoint contact " + myUnit.AI.PrimaryTarget.Name + ", however the target is a naval type and the search area is overland! The built-in navigator could not find a suitable spot to start searching.", myUnit.Name + " unable to plot localization", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						return;
					}
					if (flag3)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + text + " is trying to plot a localization course to pinpoint contact " + myUnit.AI.PrimaryTarget.Name + ", however the target is a ground (facility) type and the search area is at sea! The built-in navigator could not find a suitable spot to start searching.", myUnit.Name + " unable to plot localization", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						return;
					}
					if (flag4)
					{
						myUnit.ParentScen.AddMessage(myUnit.Name + text + " is trying to plot a localization course to pinpoint contact " + myUnit.AI.PrimaryTarget.Name + ", however the target is a sub-surface (submarine) type and the search area is under the ice! The built-in navigator could not find a suitable spot to start searching.", myUnit.Name + " unable to plot localization", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						return;
					}
					if (num == 10)
					{
						ActiveUnit_Navigator navigator = myUnit.Navigator;
						double latitude2 = geopoint_Struct.Latitude;
						double longitude2 = geopoint_Struct.Longitude;
						ProvidedPiers = null;
						if (!navigator.GetNearestAccessibleSpot(latitude2, longitude2, ref DestLat, ref DestLon, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: true))
						{
							myUnit.ParentScen.AddMessage("Aircraft " + myUnit.Name + text + " is trying to plot a localization course to pinpoint contact " + myUnit.AI.PrimaryTarget.Name + ", however the uncertainty area is in a No-Navigation Zone or some other location where the aircraft is not allowed to go! The built-in navigator could not find a suitable spot to start searching.", myUnit.Name + " unable to plot exact localization", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							return;
						}
						geopoint_Struct.Latitude = DestLat;
						geopoint_Struct.Longitude = DestLon;
						myUnit.ParentScen.AddMessage("Aircraft " + myUnit.Name + text + " is trying to plot a localization course to pinpoint contact " + myUnit.AI.PrimaryTarget.Name + ", however the uncertainty area is in a No-Navigation Zone or some other location where the aircraft is not allowed to go! A new course has been plotted as close as the built-in navigator can take the aircraft.", myUnit.Name + " unable to plot exact localization", LoggedMessage.MessageType.AirOps, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						break;
					}
				}
				else
				{
					if (myUnit.AI.PrimaryTarget == null)
					{
						break;
					}
					if (!myUnit.AI.PrimaryTarget.IsSubmergedContact && !myUnit.AI.PrimaryTarget.isSurfaceOrLandContact)
					{
						if (!myUnit.AI.PrimaryTarget.IsGroundContact || !geopoint_Struct.IsAtSea(myUnit.ParentScen))
						{
							break;
						}
						flag3 = true;
					}
					else if (!geopoint_Struct.IsOverLand(myUnit.ParentScen))
					{
						if (!myUnit.IsAircraft || !myUnit.AI.PrimaryTarget.IsSubmergedContact || !SeaIceProvider.PointIsUnderIce(geopoint_Struct.Longitude, geopoint_Struct.Latitude))
						{
							break;
						}
						flag4 = true;
					}
					else
					{
						flag2 = true;
					}
				}
				num++;
			}
			while (num <= 10);
			Waypoint theWP = new Waypoint(geopoint_Struct.Longitude, geopoint_Struct.Latitude, myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.LocalizationRun, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
			myUnit.Navigator.AddWaypoint(theWP);
			geopoint_Struct = default(Geopoint_Struct);
			byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
			{
				myUnit.Doctrine.set_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.No);
				string text2 = "";
				if (Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
				{
					text2 = " (" + myUnit.UnitClass + ")";
				}
				myUnit.AddMessage(myUnit.Name + text2 + " changed its 'Ignore Plotted Course' doctrine setting from 'Yes' to 'No' (Reason: Need to follow localization course when trying to locate target).", myUnit.Name + " - plotted course setting changed", LoggedMessage.MessageType.UnitAI, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100394", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void RemoveWaypoint_Soft(Waypoint theWP, bool RemoveWingmanWaypoints)
	{
		if (myUnit.IsGroupLead() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.HasPlottedCourse())
		{
			myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.RemoveWaypoint_Soft(theWP, RemoveWingmanWaypoints);
			ArrayExtensions.Remove(ref _PlottedCourse, theWP);
			return;
		}
		if (RemoveWingmanWaypoints)
		{
			smethod_0(ref theWP);
		}
		ArrayExtensions.Remove(ref _PlottedCourse, theWP);
	}

	public static void RemoveWaypoint_Hard(Scenario theScen, Mission theMission, Mission.Flight theFlight, Waypoint theWP)
	{
		smethod_0(ref theWP);
		Waypoint[] theArray = theFlight.FlightPlan;
		ArrayExtensions.Remove(ref theArray, theWP);
		theFlight.FlightPlan = theArray;
		ActiveUnit theAU = theFlight.get_ReferenceUnit(theScen);
		Mission.Flight flight;
		theArray = (flight = theFlight).FlightPlan;
		float NecessaryFuel = 0f;
		float MissionFuel = 0f;
		MissionPlanner.CalculateFuelQtyAndTimes_And_CheckIfEnoughFuelForFlightPlan(theScen, theMission, theAU, theFlight, ref theArray, ref NecessaryFuel, ref MissionFuel, RangeCheck: false, RunValidation: true, RunFreeSpeedChecks: true, SetWaypointTimes: true, NewFlightPlan: false, EditLeadWaypoints: true, EditWingmanWaypoints: true, 0f, 0f, Misc.TurnDirection.TurnLeft, null, AircraftIsAirborne: false, BananaSplitRedSection: false, theMission.TakeOffTime, theMission.TimeOnTarget, IsMFP: false);
		flight.FlightPlan = theArray;
	}

	private static void smethod_0(ref Waypoint waypoint_0)
	{
		if (!Information.IsNothing((object)waypoint_0.Waypoint_LeadElementWingman))
		{
			waypoint_0.Waypoint_LeadElementWingman = null;
		}
		if (!Information.IsNothing((object)waypoint_0.Waypoint_SecondElement))
		{
			waypoint_0.Waypoint_SecondElement = null;
		}
		if (!Information.IsNothing((object)waypoint_0.Waypoint_SecondElementWingman))
		{
			waypoint_0.Waypoint_SecondElementWingman = null;
		}
		if (!Information.IsNothing((object)waypoint_0.Waypoint_ThirdElement))
		{
			waypoint_0.Waypoint_ThirdElement = null;
		}
		if (!Information.IsNothing((object)waypoint_0.Waypoint_ThirdElementWingman))
		{
			waypoint_0.Waypoint_ThirdElementWingman = null;
		}
	}

	public virtual void CalculateFormationStationRelativeData()
	{
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && !myUnit.IsGroupLead())
			{
				ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				float num = Math2.CalcAzimuth(groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				if (UnitFormationStation.BearingType == ReferencePoint.OrientationType.Rotating)
				{
					UnitFormationStation.Bearing = MathFunctions.AngularDifference(groupLead.CurrentHeading, num);
				}
				else
				{
					UnitFormationStation.Bearing = num;
				}
				UnitFormationStation.Distance = myUnit.RangeToUnit_Horiz(groupLead);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100223", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CalculateFormationStationRelativeData(double StationLon, double StationLat, bool ResetValues)
	{
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) == null || myUnit.IsGroupLead())
			{
				return;
			}
			ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			if (!Information.IsNothing((object)groupLead) && (ResetValues || (UnitFormationStation.Bearing == 0f && UnitFormationStation.Distance == 0f)))
			{
				float num = Math2.CalcAzimuth(groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null), StationLat, StationLon);
				if (UnitFormationStation.BearingType == ReferencePoint.OrientationType.Rotating)
				{
					UnitFormationStation.Bearing = MathFunctions.AngularDifference(groupLead.CurrentHeading, num);
				}
				else
				{
					UnitFormationStation.Bearing = num;
				}
				UnitFormationStation.Distance = Math2.CalcDist(groupLead.get_Latitude((GlobalVariables.BooleanObject)null), groupLead.get_Longitude((GlobalVariables.BooleanObject)null), StationLat, StationLon);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100224", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static (Geopoint_Struct InterceptPoint, TimeSpan ETA) ComputeInterceptPoint_BruteForce(Module_Unit.Unit InterceptorUnit, float InterceptSpeed, Module_Unit.Unit theTarget)
	{
		(Geopoint_Struct, TimeSpan) result;
		try
		{
			float num = Module_Unit.ClosureSpeed(InterceptorUnit, theTarget, InterceptSpeed, InterceptorUnit.CurrentHeading);
			if (!(num <= 0f) && !double.IsNaN(num))
			{
				float num2 = (long)Math.Round(InterceptorUnit.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) / num * 3600f);
				if (theTarget.CurrentSpeed == 0f)
				{
					return (InterceptPoint: new Geopoint_Struct(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null)), ETA: TimeSpan.FromSeconds(num2));
				}
				float distance_NM = num2 / 3600f * theTarget.CurrentSpeed;
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, distance_NM, theTarget.CurrentHeading);
				return (InterceptPoint: new Geopoint_Struct(out_lon, out_lat), ETA: TimeSpan.FromSeconds(num2));
			}
			return (InterceptPoint: default(Geopoint_Struct), ETA: default(TimeSpan));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100986", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = default((Geopoint_Struct, TimeSpan));
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static double? CalculateInterceptHeading(double theLat, double theLon, double theHeading, Module_Unit.Unit theTarget, float InterceptVelocity, float ResolutionThreshold = 1f)
	{
		double? result;
		try
		{
			if (theTarget == null)
			{
				result = null;
			}
			else
			{
				if (!double.IsInfinity(theTarget.get_Latitude((GlobalVariables.BooleanObject)null)) && !double.IsInfinity(theTarget.get_Longitude((GlobalVariables.BooleanObject)null)))
				{
					if (theTarget.CurrentSpeed == 0f)
					{
						return Math2.CalcAzimuth(theLat, theLon, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
					}
					float num = Math2.CalcDist(theLat, theLon, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null));
					if (Math.Max(InterceptVelocity, 1f) * num * ResolutionThreshold > 50000f)
					{
						double? num2 = SphereIntercept.InterceptHeading_deg(theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), num, theTarget.CurrentHeading, theTarget.CurrentSpeed, theLat, theLon, InterceptVelocity);
						if (num2.HasValue && num2.Value != double.MaxValue)
						{
							return Math2.NormalizeBearing(num2.Value);
						}
					}
					MercatorProjection.MercatorPixel mercatorPixel = new MercatorProjection.MercatorPixel(theLon, theLat);
					MercatorProjection.MercatorPixel mercatorPixel2 = new MercatorProjection.MercatorPixel(theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.get_Latitude((GlobalVariables.BooleanObject)null));
					double? result2 = smethod_1(mercatorPixel.x, mercatorPixel.y, theHeading, mercatorPixel2.x, mercatorPixel2.y, theTarget.CurrentHeading, theTarget.CurrentSpeed, InterceptVelocity);
					if (result2.HasValue)
					{
						return Math2.NormalizeBearing(result2.Value);
					}
					return result2;
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100225", "");
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

	private static double? smethod_1(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6, double double_7, bool bool_4 = true)
	{
		double? result2;
		try
		{
			if (bool_4)
			{
				double_2 *= CSMath.PI_dividedBy_180;
				double_5 *= CSMath.PI_dividedBy_180;
			}
			double num = Math.Atan2(double_3 - double_0, double_4 - double_1);
			double num2 = double_2 - num;
			double num3 = double_5 - num;
			double num4 = 1.0 * Math.Sin(num2);
			double num5 = 1.0 * Math.Cos(num2);
			double num6 = double_6 * Math.Sin(num3);
			double num7 = double_6 * Math.Cos(num3);
			double num8 = Math.Asin((num6 - num4) / double_7);
			double num9 = Math.Cos(num8) * double_7;
			if (!double.IsNaN(num8) && num7 - num5 < num9)
			{
				return Math2.NormalizeBearing(new double?(bool_4 ? ((num8 + num) * 180.0 / 3.14159265358979) : (num8 + num)).Value);
			}
			double? result = default(double?);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100226", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result2 = null;
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	private bool method_7(double double_0, double double_1, double double_2, double double_3)
	{
		bool result = default(bool);
		try
		{
			result = Terrain.GeopointsAreOnSameOrAdjacentCell(double_0, double_1, double_2, double_3);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100227", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_8(List<Waypoint> list_0, bool bool_4, float float_0, ref bool bool_5, ref Mission.Flight flight_0, ref bool bool_6)
	{
		if (Information.IsNothing((object)list_0))
		{
			return;
		}
		int count = list_0.Count;
		if (list_0.Count <= 2)
		{
			bool_5 = true;
			return;
		}
		float proximityThreshold_Deg = ((!(float_0 > 0f)) ? 0f : 0.15f);
		double num;
		double num2;
		if (!Information.IsNothing((object)flight_0) && !bool_6 && !Information.IsNothing((object)flight_0.PrimaryTarget))
		{
			num = ((Module_Unit.Unit)flight_0.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
			num2 = ((Module_Unit.Unit)flight_0.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			num = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			num2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		try
		{
			while (!bool_5)
			{
				bool_5 = true;
				Waypoint waypoint = null;
				count = list_0.Count;
				int navigationBufferTolerance_Wide_meters = myUnit.Navigator.NavigationBufferTolerance_Wide_meters;
				int num3 = count - 1;
				for (int i = 0; i <= num3; i++)
				{
					Waypoint waypoint2;
					try
					{
						waypoint2 = list_0[i];
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200427", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
						continue;
					}
					if (waypoint2.Type != Waypoint.WaypointType.PathfindingPoint)
					{
						continue;
					}
					int num4 = list_0.IndexOf(waypoint2);
					if (num4 >= count - 1)
					{
						continue;
					}
					Waypoint waypoint3 = list_0[num4 + 1];
					if (num4 != 0)
					{
						Waypoint waypoint4 = list_0[num4 - 1];
						if (method_7(waypoint4.Latitude, waypoint4.Longitude, waypoint3.Latitude, waypoint3.Longitude))
						{
							waypoint = waypoint2;
							break;
						}
						double latitude = waypoint4.Latitude;
						double longitude = waypoint4.Longitude;
						double latitude2 = waypoint3.Latitude;
						double longitude2 = waypoint3.Longitude;
						int? bufferTolerance_meters = navigationBufferTolerance_Wide_meters;
						int ReasonForInterrupt = 0;
						GeoPoint InterruptLocation = null;
						if (!PathLineIsInterrupted(latitude, longitude, latitude2, longitude2, RunInParallel: true, proximityThreshold_Deg, CheckIfCurrentlyInsideIllegalArea: false, bufferTolerance_meters, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, null, ref ReasonForInterrupt, ref InterruptLocation))
						{
							waypoint = waypoint2;
							break;
						}
					}
					else
					{
						if (method_7(num, num2, waypoint3.Latitude, waypoint3.Longitude))
						{
							waypoint = waypoint2;
							break;
						}
						double startLat = num;
						double startLon = num2;
						double latitude3 = waypoint3.Latitude;
						double longitude3 = waypoint3.Longitude;
						int? bufferTolerance_meters2 = navigationBufferTolerance_Wide_meters;
						int ReasonForInterrupt = 0;
						GeoPoint InterruptLocation = null;
						if (!PathLineIsInterrupted(startLat, startLon, latitude3, longitude3, RunInParallel: true, proximityThreshold_Deg, CheckIfCurrentlyInsideIllegalArea: false, bufferTolerance_meters2, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, null, ref ReasonForInterrupt, ref InterruptLocation))
						{
							waypoint = waypoint2;
							break;
						}
					}
				}
				if (!Information.IsNothing((object)waypoint))
				{
					list_0.Remove(waypoint);
					bool_5 = false;
				}
			}
			if (!bool_4)
			{
				return;
			}
			bool_5 = false;
			while (!bool_5)
			{
				bool_5 = true;
				Waypoint waypoint5 = null;
				count = list_0.Count;
				int navigationBufferTolerance_Wide_meters2 = myUnit.Navigator.NavigationBufferTolerance_Wide_meters;
				for (int j = count - 1; j >= 0; j += -1)
				{
					Waypoint waypoint2 = list_0[j];
					if (waypoint2.Type != Waypoint.WaypointType.PathfindingPoint)
					{
						continue;
					}
					int num5 = list_0.IndexOf(waypoint2);
					if (num5 >= count - 1)
					{
						continue;
					}
					Waypoint waypoint6 = list_0[num5 + 1];
					if (num5 != 0)
					{
						Waypoint waypoint7 = list_0[num5 - 1];
						if (method_7(waypoint6.Latitude, waypoint6.Longitude, waypoint7.Latitude, waypoint7.Longitude))
						{
							waypoint5 = waypoint2;
							break;
						}
						double latitude4 = waypoint6.Latitude;
						double longitude4 = waypoint6.Longitude;
						double latitude5 = waypoint7.Latitude;
						double longitude5 = waypoint7.Longitude;
						int? bufferTolerance_meters3 = navigationBufferTolerance_Wide_meters2;
						int ReasonForInterrupt = 0;
						GeoPoint InterruptLocation = null;
						if (!PathLineIsInterrupted(latitude4, longitude4, latitude5, longitude5, RunInParallel: true, proximityThreshold_Deg, CheckIfCurrentlyInsideIllegalArea: false, bufferTolerance_meters3, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, null, ref ReasonForInterrupt, ref InterruptLocation))
						{
							waypoint5 = waypoint2;
							break;
						}
					}
					else
					{
						if (method_7(num, num2, waypoint6.Latitude, waypoint6.Longitude))
						{
							waypoint5 = waypoint2;
							break;
						}
						double startLat2 = num;
						double startLon2 = num2;
						double latitude6 = waypoint6.Latitude;
						double longitude6 = waypoint6.Longitude;
						int? bufferTolerance_meters4 = navigationBufferTolerance_Wide_meters2;
						int ReasonForInterrupt = 0;
						GeoPoint InterruptLocation = null;
						if (!PathLineIsInterrupted(startLat2, startLon2, latitude6, longitude6, RunInParallel: true, proximityThreshold_Deg, CheckIfCurrentlyInsideIllegalArea: false, bufferTolerance_meters4, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, null, ref ReasonForInterrupt, ref InterruptLocation))
						{
							waypoint5 = waypoint2;
							break;
						}
					}
				}
				if (!Information.IsNothing((object)waypoint5))
				{
					list_0.Remove(waypoint5);
					bool_5 = false;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100228", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void GenerateAttackRoute(Contact theContact, Waypoint[] myPlottedCourse, Weapon thePassedWeapon = null, int? thePassedWpnQuantityToFire = null)
	{
		Weapon weapon = ((thePassedWeapon == null) ? myUnit.Weaponry.MostSuitableWeaponForThisTarget(theContact, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, myUnit.Doctrine) : thePassedWeapon);
		if (weapon == null)
		{
			return;
		}
		float val = weapon.get_MaxRangeForThisTarget(myUnit, theContact, CheckWRA: true, myUnit.Doctrine, ManualFire: false);
		Geopoint_Struct Point = myUnit.Location;
		Geopoint_Struct Point2 = theContact.Location;
		float num = Math.Min(val, Math2.CalcDist(ref Point, ref Point2));
		float num2 = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null));
		float bearing = Math2.CalcAzimuth(((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
		double out_lon = default(double);
		double out_lat = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(distance_NM: Math.Min((double)num * 0.8, ((!myUnit.IsAircraft || !weapon.IsUnguidedBallisticWeapon) ? ((double)weapon.MaxLandRange) : ((double)weapon.get_MaxDownRange(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentAltitude_AGL, Contact_Base.ContactType.Facility_Fixed))) * 0.9), Lon1: ((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), Lat1: ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), out_lon2: ref out_lon, out_lat2: ref out_lat, bearing: bearing);
		Waypoint waypoint = new Waypoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
		Waypoint waypoint2 = new Waypoint(out_lon, out_lat, ((Module_Unit.Unit)theContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.WeaponLaunch, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
		if (!myUnit.IsAerospaceUnit && !myUnit.CanPlotCourseToThisLocation(waypoint2.Latitude, waypoint2.Longitude) && Debugger.IsAttached)
		{
			Debugger.Break();
			return;
		}
		float value = (myUnit.IsAerospaceUnit ? (MissionPlanner.getBestWeaponAltitudeReleaseForThisPoint((Aircraft)myUnit, waypoint.Latitude, waypoint.Longitude, weapon, theContact, waypoint) + (float)(int)LandCover.GetLandCoverAtThisPoint(waypoint2.Latitude, waypoint2.Longitude, myUnit.ParentScen)) : 0f);
		waypoint.DesiredAltitude = value;
		waypoint2.DesiredAltitude = value;
		myUnit.Navigator.AddTargeteeringEntryToWP(theContact, waypoint2);
		waypoint2.ReferenceWeapon_ID = weapon.DBID;
		Waypoint waypoint3 = new Waypoint(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.WeaponTarget, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
		myUnit.Navigator.AddTargeteeringEntryToWP(theContact, waypoint3);
		waypoint3.ReferenceWeapon_ID = weapon.DBID;
		float num3 = 6f;
		double Lon = default(double);
		double Lat = default(double);
		if (weapon.MaxRange_NoTargetType < num3)
		{
			Math2.CalcPoint_Vincenty(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), ref Lon, ref Lat, num3, num2);
		}
		else
		{
			Lat = out_lat;
			Lon = out_lon;
		}
		Waypoint waypoint4 = new Waypoint(Lon, Lat, ((Module_Unit.Unit)theContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.StrikeEgress, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
		waypoint4.ReferenceWeapon_ID = weapon.DBID;
		waypoint4.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		ActiveUnit_Navigator navigator = myUnit.Navigator;
		Waypoint[] theArray = navigator.PlottedCourse;
		ArrayExtensions.Clear(ref theArray);
		navigator.PlottedCourse = theArray;
		ActiveUnit_Navigator navigator2 = myUnit.Navigator;
		theArray = navigator2.PlottedCourse;
		ArrayExtensions.Add(ref theArray, waypoint);
		navigator2.PlottedCourse = theArray;
		ActiveUnit_Navigator navigator3 = myUnit.Navigator;
		theArray = navigator3.PlottedCourse;
		ArrayExtensions.Add(ref theArray, waypoint2);
		navigator3.PlottedCourse = theArray;
		ActiveUnit_Navigator navigator4 = myUnit.Navigator;
		theArray = navigator4.PlottedCourse;
		ArrayExtensions.Add(ref theArray, waypoint3);
		navigator4.PlottedCourse = theArray;
		ActiveUnit_Navigator navigator5 = myUnit.Navigator;
		theArray = navigator5.PlottedCourse;
		ArrayExtensions.Add(ref theArray, waypoint4);
		navigator5.PlottedCourse = theArray;
		if (!myUnit.IsAerospaceUnit)
		{
			myUnit.ThrottleSetting = ActiveUnit.Throttle.Cruise;
			myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.Cruise;
			myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
			myUnit.CurrentSpeed = myUnit.DesiredSpeed;
		}
		if (GlobalVariables.AI_REWORK && myUnit.IsAircraft)
		{
			((Aircraft)myUnit).AI.StatusRelatedEvents.GeneratedAttackRoute = true;
		}
		else
		{
			myUnit.Status = ActiveUnit._ActiveUnitStatus.OnPlottedCourse;
		}
	}

	protected virtual List<Waypoint> PathfindingCourse(double StartLat, double StartLon, double DestLat, double DestLon, float CurrentHeading, bool AttemptToShrinkPFArea, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, bool IsMissionPlannerRequest)
	{
		List<Waypoint> list = new List<Waypoint>();
		List<Waypoint> result = default(List<Waypoint>);
		try
		{
			if (!UseCostBasedPathfinder && AttemptToShrinkPFArea)
			{
				float standOffSlack_nm = ((!(ProximityThreshold_Deg > 0f)) ? 5f : 15f);
				GeoPoint geoPoint = LastAccessiblePointOnPath(StartLat, StartLon, DestLat, DestLon, standOffSlack_nm, null, ProximityThreshold_Deg, ref ProvidedPiers);
				GeoPoint geoPoint2 = LastAccessiblePointOnPath(DestLat, DestLon, StartLat, StartLon, standOffSlack_nm, null, ProximityThreshold_Deg, ref ProvidedPiers);
				if (!Information.IsNothing((object)geoPoint) && !Information.IsNothing((object)geoPoint2))
				{
					list = PathfindingCourse(geoPoint.Latitude, geoPoint.Longitude, geoPoint2.Latitude, geoPoint2.Longitude, CurrentHeading, AttemptToShrinkPFArea: false, ProximityThreshold_Deg, ref ProvidedPiers, IsMissionPlannerRequest);
					if (!Information.IsNothing((object)list))
					{
						list.Insert(0, new Waypoint(StartLon, StartLat, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
						if (!myUnit.IsAircraft)
						{
							ActiveUnit activeUnit = myUnit;
							int MovementCost = 0;
							bool CheckNoNavZones = true;
							bool CheckForMines = true;
							string UserFeedback = "";
							bool AllowBounce = false;
							if (activeUnit.CanMoveToThisLocation(DestLat, DestLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, ProximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
							{
								ActiveUnit_Navigator navigator = myUnit.Navigator;
								double latitude = list[list.Count - 1].Latitude;
								double longitude = list[list.Count - 1].Longitude;
								float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
								MovementCost = 0;
								GeoPoint InterruptLocation = null;
								if (!navigator.PathLineIsInterrupted(DestLat, DestLon, latitude, longitude, RunInParallel: false, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref MovementCost, ref InterruptLocation))
								{
									list.Add(new Waypoint(DestLon, DestLat, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
								}
							}
						}
						else
						{
							list.Add(new Waypoint(DestLon, DestLat, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Pathfinder, Waypoint.WaypointCategory.PlottedCourse));
						}
					}
					result = list;
					return result;
				}
				result = list;
				return result;
			}
			if (!myUnit.IsAircraft)
			{
				if (Math2.CalcDist(StartLat, StartLon, DestLat, DestLon) < myUnit.ParentScen.Navigation_FinegrainedMaxDistance)
				{
					if (myUnit.ParentScen.ThreadedOpsMustStop)
					{
						PathFindingInProgress = false;
						result = null;
						return result;
					}
					list = (UseCostBasedPathfinder ? Pathfinding.PathFinderCostBasedEngine.SolvePF_Finegrained(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, myUnit.ParentScen.Navigation_FinegrainedThresholdDistance, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest) : Pathfinding.PathFinderSettlersEngine.SolvePF_Finegrained(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, myUnit.ParentScen.Navigation_FinegrainedThresholdDistance, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest));
				}
				else
				{
					float degreeBuffer = 20f;
					list = (UseCostBasedPathfinder ? Pathfinding.PathFinderCostBasedEngine.SolvePF_Coarse(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, degreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: true) : Pathfinding.PathFinderSettlersEngine.SolvePF_Coarse(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, degreeBuffer, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: false));
				}
			}
			else if (!UseCostBasedPathfinder)
			{
				list = Pathfinding.PathFinderSettlersEngine.SolvePF_Coarse(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: false);
				if (list == null)
				{
					list = Pathfinding.PathFinderSettlersEngine.SolvePF_Coarse(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, 20f, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: false);
				}
			}
			else
			{
				list = Pathfinding.PathFinderCostBasedEngine.SolvePF_Coarse(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: true);
				if (list == null)
				{
					list = Pathfinding.PathFinderCostBasedEngine.SolvePF_Coarse(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, 20f, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest, AllowFineGrainedNav: true);
				}
			}
			result = list;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100229", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static float NearestDistanceToLand(double theLat, double theLon, Scenario theScen)
	{
		if (Terrain.GetElevation(theLat, theLon, RequestIsFromGUI: false, theScen) >= 0)
		{
			return 0f;
		}
		float num = 0.5f;
		int num2 = 0;
		double out_lon = default(double);
		double out_lat = default(double);
		while (true)
		{
			int num3 = num2;
			do
			{
				Geodesic_EdWilliams.CalcPoint_Williams(theLon, theLat, ref out_lon, ref out_lat, num, num3);
				if (Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, theScen) < 0)
				{
					num3++;
					continue;
				}
				return num;
			}
			while (num3 <= 359);
			num += 0.5f;
			if (num > float.MaxValue)
			{
				break;
			}
			num2 = 0;
		}
		return float.MaxValue;
	}

	private List<Geopoint_Struct> method_9(double double_0, double double_1, double double_2, double double_3, double double_4, float float_0, float float_1, ref List<ActiveUnit> list_0)
	{
		List<Geopoint_Struct> result = default(List<Geopoint_Struct>);
		try
		{
			List<Geopoint_Struct> list = new List<Geopoint_Struct>();
			float num;
			float val = (num = (float)(double_4 / 100.0));
			float num2 = (float)double_4;
			float num3 = Math.Max(val, 1f);
			bool flag = num3 >= 0f;
			float num4 = num;
			double out_lon = default(double);
			double out_lat = default(double);
			while (true)
			{
				IL_0169:
				if ((!flag) ? (num4 >= num2) : (num4 <= num2))
				{
					short num5 = 180;
					while (!myUnit.ParentScen.ThreadedOpsMustStop)
					{
						Geodesic_EdWilliams.CalcPoint_Williams(double_2, double_3, ref out_lon, ref out_lat, num4, float_0 + (float)num5);
						ActiveUnit activeUnit = myUnit;
						double theLat = out_lon;
						double theLon = out_lat;
						int MovementCost = 0;
						bool CheckNoNavZones = true;
						bool CheckForMines = true;
						string UserFeedback = "";
						bool AllowBounce = false;
						if (activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref list_0, float_1, CheckIfTargetIsOutsideProsecutionArea: true, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
						{
							list.Add(new Geopoint_Struct(out_lat, out_lon));
						}
						Geodesic_EdWilliams.CalcPoint_Williams(double_2, double_3, ref out_lon, ref out_lat, num4, float_0 - (float)num5);
						ActiveUnit activeUnit2 = myUnit;
						double theLat2 = out_lon;
						double theLon2 = out_lat;
						MovementCost = 0;
						AllowBounce = true;
						CheckForMines = true;
						UserFeedback = "";
						CheckNoNavZones = false;
						if (activeUnit2.CanMoveToThisLocation(theLat2, theLon2, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref AllowBounce, CheckForIcepack: true, ref CheckForMines, null, null, ref list_0, float_1, CheckIfTargetIsOutsideProsecutionArea: true, CheckDistanceToNoNavZones: false, ref UserFeedback, ref CheckNoNavZones))
						{
							list.Add(new Geopoint_Struct(out_lat, out_lon));
						}
						num5 += -1;
						if (num5 >= 0)
						{
							continue;
						}
						num4 += num3;
						goto IL_0169;
					}
					break;
				}
				result = list;
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100230", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	protected virtual void PerformPathfinding(Waypoint StartWP, ActiveUnit theUnit, Mission.Flight theFlightPlan, bool theFlightPlanIngressPath, float ProximityThreshold_Deg, double DestLat, double DestLon, bool ManouverTowardsTarget)
	{
		try
		{
			bool isMissionPlannerRequest = false;
			double DestLat2 = default(double);
			double DestLon2 = default(double);
			float num = default(float);
			if (!Information.IsNothing((object)StartWP))
			{
				DestLat2 = StartWP.Latitude;
				DestLon2 = StartWP.Longitude;
				num = Math2.CalcAzimuth(DestLat2, DestLon2, DestLat, DestLon);
			}
			else if (!Information.IsNothing((object)theUnit))
			{
				DestLat2 = theUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				DestLon2 = theUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				num = theUnit.CurrentHeading;
			}
			else if (!Information.IsNothing((object)theFlightPlan))
			{
				isMissionPlannerRequest = true;
				if (!theFlightPlanIngressPath)
				{
					if (!Information.IsNothing((object)theFlightPlan.PrimaryTarget))
					{
						DestLat2 = ((Module_Unit.Unit)theFlightPlan.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
						DestLon2 = ((Module_Unit.Unit)theFlightPlan.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
						num = Math2.CalcAzimuth(DestLat2, DestLon2, DestLat, DestLon);
					}
					else
					{
						DestLat2 = theFlightPlan.get_ReferenceUnit((Scenario)null).get_Latitude((GlobalVariables.BooleanObject)null);
						DestLon2 = theFlightPlan.get_ReferenceUnit((Scenario)null).get_Longitude((GlobalVariables.BooleanObject)null);
						num = theFlightPlan.get_ReferenceUnit((Scenario)null).CurrentHeading;
					}
				}
				else
				{
					DestLat2 = theFlightPlan.get_ReferenceUnit((Scenario)null).get_Latitude((GlobalVariables.BooleanObject)null);
					DestLon2 = theFlightPlan.get_ReferenceUnit((Scenario)null).get_Longitude((GlobalVariables.BooleanObject)null);
					num = theFlightPlan.get_ReferenceUnit((Scenario)null).CurrentHeading;
				}
			}
			List<Waypoint> list = null;
			List<ActiveUnit> ProvidedPiers = myUnit.DockingOps.GetDestinationPierList();
			if (!Information.IsNothing((object)theUnit) && ProximityThreshold_Deg == 0.15f)
			{
				ActiveUnit activeUnit = myUnit;
				double theLat = DestLat2;
				double theLon = DestLon2;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				float? distanceFromUnit = 0f;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (!activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, distanceFromUnit, null, ref ProvidedPiers, ProximityThreshold_Deg, ManouverTowardsTarget, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce) && !GetNearestAccessibleSpot(DestLat2, DestLon2, ref DestLat2, ref DestLon2, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ProximityThreshold_Deg, ref ProvidedPiers, ManouverTowardsTarget))
				{
					return;
				}
				ActiveUnit activeUnit2 = myUnit;
				double theLat2 = DestLat;
				double theLon2 = DestLon;
				MovementCost = 0;
				AllowBounce = true;
				CheckForMines = true;
				float? distanceFromUnit2 = 0f;
				UserFeedback = "";
				CheckNoNavZones = false;
				if (!activeUnit2.CanMoveToThisLocation(theLat2, theLon2, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref AllowBounce, CheckForIcepack: true, ref CheckForMines, distanceFromUnit2, null, ref ProvidedPiers, ProximityThreshold_Deg, ManouverTowardsTarget, CheckDistanceToNoNavZones: false, ref UserFeedback, ref CheckNoNavZones) && !GetNearestAccessibleSpot(DestLat, DestLon, ref DestLat, ref DestLon, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ProximityThreshold_Deg, ref ProvidedPiers, ManouverTowardsTarget))
				{
					return;
				}
			}
			if (!Information.IsNothing((object)theUnit))
			{
				double theLat3 = DestLat;
				double theLon3 = DestLon;
				int MovementCost = 0;
				bool CheckNoNavZones = true;
				bool CheckForMines = true;
				string UserFeedback = "";
				bool AllowBounce = false;
				if (theUnit.CanMoveToThisLocation(theLat3, theLon3, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, ProximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
				{
					theUnit.AI.NavDestination = new Geopoint_Struct(DestLon, DestLat);
					list = PathfindingCourse(DestLat2, DestLon2, DestLat, DestLon, num, AttemptToShrinkPFArea: true, ProximityThreshold_Deg, ref ProvidedPiers, isMissionPlannerRequest);
					if (Information.IsNothing((object)list) || list.Count != 0)
					{
						PF_GeneratedCourse = list;
					}
					return;
				}
			}
			if (!Information.IsNothing((object)theFlightPlan) && !Information.IsNothing((object)theFlightPlan.get_ReferenceUnit((Scenario)null)))
			{
				ActiveUnit activeUnit3 = theFlightPlan.get_ReferenceUnit((Scenario)null);
				double theLat4 = DestLat;
				double theLon4 = DestLon;
				int MovementCost = 0;
				bool AllowBounce = true;
				bool CheckForMines = true;
				string UserFeedback = "";
				bool CheckNoNavZones = false;
				if (activeUnit3.CanMoveToThisLocation(theLat4, theLon4, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref AllowBounce, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, ProximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref CheckNoNavZones))
				{
					list = theFlightPlan.get_ReferenceUnit((Scenario)null).Navigator.PathfindingCourse(DestLat2, DestLon2, DestLat, DestLon, num, AttemptToShrinkPFArea: true, ProximityThreshold_Deg, ref ProvidedPiers, isMissionPlannerRequest);
					if (Information.IsNothing((object)list) || list.Count != 0)
					{
						PF_GeneratedCourse = list;
					}
					return;
				}
			}
			try
			{
				double num2 = 0.0;
				double num3 = 0.0;
				num2 = Math2.CalcDist(DestLat2, DestLon2, DestLat, DestLon);
				num3 = Math2.CalcDist_Angular(DestLat2, DestLon2, DestLat, DestLon);
				if (!(num2 > 0.0))
				{
					return;
				}
				List<Geopoint_Struct> list2 = method_9(DestLat2, DestLon2, DestLat, DestLon, num2, num, ProximityThreshold_Deg, ref ProvidedPiers);
				using List<Geopoint_Struct>.Enumerator enumerator = list2.GetEnumerator();
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						return;
					}
					Geopoint_Struct current = enumerator.Current;
					if (!(GeoPoint.RangeToPoint_Horiz_Angular(current.Longitude, current.Latitude, DestLon, DestLat) > num3))
					{
						if (!Information.IsNothing((object)theUnit))
						{
							theUnit.AI.NavDestination = current;
						}
						list = PathfindingCourse(DestLat2, DestLon2, current.Latitude, current.Longitude, num, AttemptToShrinkPFArea: true, ProximityThreshold_Deg, ref ProvidedPiers, isMissionPlannerRequest);
						if (!Information.IsNothing((object)list))
						{
							break;
						}
					}
				}
				PF_GeneratedCourse = list;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200010", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100231", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public GeoPoint LastAccessiblePointOnPath(double StartLat, double StartLon, double DestLat, double DestLon, float StandOffSlack_nm, int? BufferTolerance_meters, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers)
	{
		GeoPoint result = default(GeoPoint);
		try
		{
			double lat = StartLat;
			double lon = StartLon;
			float num = Math2.CalcDist(StartLat, StartLon, DestLat, DestLon);
			if (!float.IsNaN(num) && num != 0f)
			{
				float num2 = (myUnit.IsAircraft ? ((!UseCostBasedPathfinder) ? Pathfinding.PathFinderSettlersEngine.DegreeInterval_Coarse : Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Coarse) : ((num < myUnit.ParentScen.Navigation_FinegrainedMaxDistance) ? (UseCostBasedPathfinder ? Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained : Pathfinding.PathFinderSettlersEngine.DegreeInterval_Finegrained) : (UseCostBasedPathfinder ? Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Coarse : Pathfinding.PathFinderSettlersEngine.DegreeInterval_Coarse)));
				CSMaterial.ExWorldWind.Angle angle = new CSMaterial.ExWorldWind.Angle
				{
					Degrees = StartLon
				};
				CSMaterial.ExWorldWind.Angle angle2 = new CSMaterial.ExWorldWind.Angle
				{
					Degrees = StartLat
				};
				CSMaterial.ExWorldWind.Angle angle3 = new CSMaterial.ExWorldWind.Angle
				{
					Degrees = DestLon
				};
				CSMaterial.ExWorldWind.Angle angle4 = new CSMaterial.ExWorldWind.Angle
				{
					Degrees = DestLat
				};
				CSMaterial.ExWorldWind.Angle lon2 = default(CSMaterial.ExWorldWind.Angle);
				CSMaterial.ExWorldWind.Angle lat2 = default(CSMaterial.ExWorldWind.Angle);
				CSMaterial.ExWorldWind.Angle d = World.ApproxAngularDistance(angle2, angle, angle4, angle3);
				float num3 = (float)d.Degrees;
				if (num3 < num2 * 2f)
				{
					result = null;
					return result;
				}
				int num4 = (int)Math.Round(num3 / num2);
				for (int i = 1; i <= num4; i++)
				{
					World.smethod_0(num2 * (float)i / num3, angle2, angle, angle4, angle3, d, out lat2, out lon2);
					double degrees = lat2.Degrees;
					double degrees2 = lon2.Degrees;
					_ = Debugger.IsAttached;
					ActiveUnit activeUnit = myUnit;
					int MovementCost = 0;
					bool CheckNoNavZones = true;
					bool CheckForMines = true;
					float? distanceFromUnit = BufferTolerance_meters;
					string UserFeedback = "";
					bool AllowBounce = false;
					if (!activeUnit.CanMoveToThisLocation(degrees, degrees2, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, distanceFromUnit, null, ref ProvidedPiers, ProximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
					{
						break;
					}
					lat = degrees;
					lon = degrees2;
				}
				float num5 = Math2.CalcDist(StartLat, StartLon, lat, lon);
				float distance_NM = ((!(num5 > StandOffSlack_nm)) ? ((float)((double)num5 * 0.2)) : (num5 - StandOffSlack_nm));
				float bearing = Math2.CalcAzimuth(StartLat, StartLon, DestLat, DestLon);
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(StartLon, StartLat, ref out_lon, ref out_lat, distance_NM, bearing);
				result = new GeoPoint(out_lon, out_lat);
				return result;
			}
			result = null;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100232", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool Geo_PathLineIsInterrupted_NoNavZones(double StartLat, double StartLon, double DestLat, double DestLon, float ProximityThreshold_Deg)
	{
		(double, double) latLon1Start = (MathFunctions.DegreesToRadians(StartLat), MathFunctions.DegreesToRadians(StartLon));
		(double, double) valueTuple_ = (MathFunctions.DegreesToRadians(DestLat), MathFunctions.DegreesToRadians(DestLon));
		double num = Math.Min(MathFunctions.DegreesToRadians(StartLat), MathFunctions.DegreesToRadians(DestLat));
		double num2 = Math.Max(MathFunctions.DegreesToRadians(StartLat), MathFunctions.DegreesToRadians(DestLat));
		double num3 = Math.Min(MathFunctions.DegreesToRadians(StartLon), MathFunctions.DegreesToRadians(DestLon));
		double num4 = Math.Max(MathFunctions.DegreesToRadians(StartLon), MathFunctions.DegreesToRadians(DestLon));
		int result;
		if (myUnit != null)
		{
			if (myUnit.get_UnitSide(SetSideOnly: false) != null)
			{
				foreach (NoNavZone noNavZone in myUnit.get_UnitSide(SetSideOnly: false).NoNavZones)
				{
					if (noNavZone.Area.Count == 0 || !((Zone)noNavZone).get_AffectsThisUnit(myUnit))
					{
						continue;
					}
					List<((double, double), (double, double))> list;
					if (ProximityThreshold_Deg == 0.2f)
					{
						if (noNavZone.Area_GeoPoints_020deg_Buffered.Count == 0 || GeoPoint.ZoneHasChanged(noNavZone.Area, noNavZone.Area_RefPoints_020deg_ChangeCheck))
						{
							noNavZone.CalculateAreaWithThresholdAdded(ProximityThreshold_Deg, ref noNavZone.Area_GeoPoints_020deg_Buffered, ref noNavZone.Area_RefPoints_020deg_ChangeCheck);
						}
						list = noNavZone.Area_GeoPoints_020deg_Buffered.Take(noNavZone.Area_GeoPoints_020deg_Buffered.Count - 1).Zip(noNavZone.Area_GeoPoints_020deg_Buffered.Skip(1), [SpecialName] (Geopoint_Struct a, Geopoint_Struct b) => ((MathFunctions.DegreesToRadians(a.Latitude), MathFunctions.DegreesToRadians(a.Longitude)), (MathFunctions.DegreesToRadians(b.Latitude), MathFunctions.DegreesToRadians(b.Longitude)))).ToList();
						if (list.Count > 0)
						{
							list.Add((list.Last().Item2, list.First().Item1));
						}
					}
					else if (ProximityThreshold_Deg == 0.15f)
					{
						if (noNavZone.Area_GeoPoints_015deg_Buffered.Count == 0 || GeoPoint.ZoneHasChanged(noNavZone.Area, noNavZone.Area_RefPoints_015deg_ChangeCheck))
						{
							noNavZone.CalculateAreaWithThresholdAdded(ProximityThreshold_Deg, ref noNavZone.Area_GeoPoints_015deg_Buffered, ref noNavZone.Area_RefPoints_015deg_ChangeCheck);
						}
						list = noNavZone.Area_GeoPoints_015deg_Buffered.Take(noNavZone.Area_GeoPoints_015deg_Buffered.Count - 1).Zip(noNavZone.Area_GeoPoints_015deg_Buffered.Skip(1), [SpecialName] (Geopoint_Struct a, Geopoint_Struct b) => ((MathFunctions.DegreesToRadians(a.Latitude), MathFunctions.DegreesToRadians(a.Longitude)), (MathFunctions.DegreesToRadians(b.Latitude), MathFunctions.DegreesToRadians(b.Longitude)))).ToList();
						if (list.Count > 0)
						{
							list.Add((list.Last().Item2, list.First().Item1));
						}
					}
					else
					{
						list = new List<((double, double), (double, double))>();
						int num5 = noNavZone.Area.Count - 2;
						for (int num6 = 0; num6 <= num5; num6++)
						{
							ReferencePoint referencePoint = noNavZone.Area[num6];
							ReferencePoint referencePoint2 = noNavZone.Area[num6 + 1];
							list.Add(((MathFunctions.DegreesToRadians(referencePoint.Latitude), MathFunctions.DegreesToRadians(referencePoint.Longitude)), (MathFunctions.DegreesToRadians(referencePoint2.Latitude), MathFunctions.DegreesToRadians(referencePoint2.Longitude))));
						}
						list.Add((list.Last().Item2, list.First().Item1));
					}
					foreach (var item in list)
					{
						(double, double) tuple = Math2.Geo_Intercept(latLon1Start, valueTuple_, item.Item1, item.Item2);
						if (!Information.IsNothing((object)tuple))
						{
							double num7 = Math.Min(item.Item1.Item1, item.Item2.Item1);
							double num8 = Math.Max(item.Item1.Item1, item.Item2.Item1);
							double num9 = Math.Min(item.Item1.Item2, item.Item2.Item2);
							double num10 = Math.Max(item.Item1.Item2, item.Item2.Item2);
							if (tuple.Item1 < num2 && tuple.Item1 > num && tuple.Item2 < num4 && tuple.Item2 > num3 && tuple.Item1 < num8 && tuple.Item1 > num7 && tuple.Item2 < num10 && !(tuple.Item2 <= num9))
							{
								return true;
							}
						}
					}
				}
				return false;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual bool PathLineIsInterrupted(double StartLat, double StartLon, double DestLat, double DestLon, bool RunInParallel, float ProximityThreshold_Deg, bool CheckIfCurrentlyInsideIllegalArea, int? BufferTolerance_meters, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, float? SamplingInterval_Deg, [Optional][DefaultParameterValue(0)] ref int ReasonForInterrupt, [Optional][DefaultParameterValue(null)] ref GeoPoint InterruptLocation)
	{
		bool result;
		try
		{
			bool CheckForMines = false;
			bool CheckNoNavZones = false;
			if (!CheckIfCurrentlyInsideIllegalArea)
			{
				goto IL_00b9;
			}
			ActiveUnit activeUnit = myUnit;
			double theLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			double theLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			int MovementCost = 0;
			bool CheckNoNavZones2 = false;
			float? distanceFromUnit = 0f;
			List<ActiveUnit> ProvidedPiers = null;
			string UserFeedback = "";
			bool AllowBounce = false;
			if (!activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs: false, ref CheckNoNavZones2, CheckForIcepack: true, ref CheckForMines, distanceFromUnit, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce) && !CheckForMines)
			{
				result = false;
			}
			else
			{
				if (!CheckForMines)
				{
					goto IL_00b9;
				}
				ReasonForInterrupt = 1;
				int num;
				if (InterruptLocation != null)
				{
					InterruptLocation.Latitude = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					InterruptLocation.Longitude = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					num = 1;
				}
				else
				{
					num = 1;
				}
				result = (byte)num != 0;
			}
			goto end_IL_0001;
			IL_00b9:
			int num3;
			if (Geo_PathLineIsInterrupted_NoNavZones(StartLat, StartLon, DestLat, DestLon, ProximityThreshold_Deg))
			{
				result = true;
			}
			else
			{
				float num2 = Math2.CalcDist(StartLat, StartLon, DestLat, DestLon);
				if (float.IsNaN(num2))
				{
					num3 = 0;
					goto IL_00ee;
				}
				if (num2 == 0f)
				{
					num3 = 0;
					goto IL_00ee;
				}
				if (Information.IsNothing((object)SamplingInterval_Deg))
				{
					SamplingInterval_Deg = ((!myUnit.IsAircraft) ? ((num2 < myUnit.ParentScen.Navigation_FinegrainedMaxDistance) ? (UseCostBasedPathfinder ? new float?(Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained) : new float?(Pathfinding.PathFinderSettlersEngine.DegreeInterval_Finegrained)) : ((!UseCostBasedPathfinder) ? new float?(Pathfinding.PathFinderSettlersEngine.DegreeInterval_Coarse) : new float?(Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Coarse))) : (UseCostBasedPathfinder ? new float?(Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Coarse) : new float?(Pathfinding.PathFinderSettlersEngine.DegreeInterval_Coarse)));
				}
				if (Information.IsNothing((object)SamplingInterval_Deg))
				{
					int num4;
					if (!Debugger.IsAttached)
					{
						num4 = 1;
					}
					else
					{
						Debugger.Break();
						num4 = 1;
					}
					result = (byte)num4 != 0;
				}
				else
				{
					bool flag = false;
					CSMaterial.ExWorldWind.Angle angle = new CSMaterial.ExWorldWind.Angle
					{
						Degrees = StartLon
					};
					CSMaterial.ExWorldWind.Angle angle2 = new CSMaterial.ExWorldWind.Angle
					{
						Degrees = StartLat
					};
					CSMaterial.ExWorldWind.Angle angle3 = new CSMaterial.ExWorldWind.Angle
					{
						Degrees = DestLon
					};
					CSMaterial.ExWorldWind.Angle angle4 = new CSMaterial.ExWorldWind.Angle
					{
						Degrees = DestLat
					};
					CSMaterial.ExWorldWind.Angle d = World.ApproxAngularDistance(angle2, angle, angle4, angle3);
					float num5 = (float)d.Degrees;
					float num6 = num5;
					float? num7 = SamplingInterval_Deg * 2f;
					if (((!num7.HasValue) ? ((bool?)null) : new bool?(num6 < num7.GetValueOrDefault())) == true)
					{
						result = false;
					}
					else
					{
						int num8 = (int)Math.Round((num5 / SamplingInterval_Deg).Value);
						List<ActiveUnit> ProvidedPiers2 = myUnit.DockingOps.GetDestinationPierList();
						bool checkForIcepack = (myUnit.IsShip && !((Ship)myUnit).IsIcebreaker) || (myUnit.IsSubmarine && !((Submarine)myUnit).IsNuke);
						CSMaterial.ExWorldWind.Angle lon = default(CSMaterial.ExWorldWind.Angle);
						CSMaterial.ExWorldWind.Angle lat = default(CSMaterial.ExWorldWind.Angle);
						MovementCost = num8;
						for (int i = 1; i <= MovementCost; i++)
						{
							World.smethod_0(SamplingInterval_Deg.Value * (float)i / num5, angle2, angle, angle4, angle3, d, out lat, out lon);
							double degrees = lat.Degrees;
							double degrees2 = lon.Degrees;
							ActiveUnit activeUnit2 = myUnit;
							int MovementCost2 = 0;
							float? distanceFromUnit2 = BufferTolerance_meters;
							UserFeedback = "";
							AllowBounce = false;
							if (!activeUnit2.CanMoveToThisLocation(degrees, degrees2, ref MovementCost2, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs, ref CheckNoNavZones, checkForIcepack, ref CheckForMines, distanceFromUnit2, null, ref ProvidedPiers2, ProximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
							{
								if (CheckForMines)
								{
									ReasonForInterrupt++;
								}
								if (CheckNoNavZones)
								{
									ReasonForInterrupt += 2;
								}
								int num9;
								if (InterruptLocation != null)
								{
									InterruptLocation.Latitude = degrees;
									InterruptLocation.Longitude = degrees2;
									num9 = 1;
								}
								else
								{
									num9 = 1;
								}
								flag = (byte)num9 != 0;
								break;
							}
						}
						result = flag;
					}
				}
			}
			goto end_IL_0001;
			IL_00ee:
			result = (byte)num3 != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100233", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num10;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num10 = 0;
			}
			else
			{
				num10 = 0;
			}
			result = (byte)num10 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool AddUnitToTargeteeringList(Strike myStrike, Waypoint theWp)
	{
		if (myStrike.SpecificTargets != null && myStrike.SpecificTargets.Count > 0)
		{
			double num = 0.5;
			int num2 = myStrike.SpecificTargets.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				Module_Unit.Unit unit = myStrike.SpecificTargets.ElementAtOrDefault(i);
				if (unit.get_Latitude((GlobalVariables.BooleanObject)null) > theWp.Latitude - num && unit.get_Latitude((GlobalVariables.BooleanObject)null) < theWp.Latitude + num && unit.get_Longitude((GlobalVariables.BooleanObject)null) > theWp.Longitude - num && !(unit.get_Longitude((GlobalVariables.BooleanObject)null) >= theWp.Longitude + num))
				{
					myUnit.Navigator.AddTargeteeringEntryToWP(unit, theWp);
					return true;
				}
			}
		}
		bool result = default(bool);
		return result;
	}

	public void AddTargeteeringEntryToWP(Module_Unit.Unit theTarget, Waypoint thePoint)
	{
		string text = "";
		if (theTarget == null)
		{
			return;
		}
		if (!theTarget.IsContact())
		{
			if (theTarget.IsActiveUnit)
			{
				ActiveUnit activeUnit = (ActiveUnit)theTarget;
				text = theTarget.Name;
				if (text == null)
				{
					text = activeUnit.Name;
				}
				if (text == null)
				{
					text = activeUnit.SubTypeDescription;
				}
				Mission.TargeteeringEntry targeteeringEntry = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, text, theTarget.ObjectID, activeUnit.ObjectID, activeUnit.DBID, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
				targeteeringEntry.Target_Description = theTarget.Name;
				targeteeringEntry.Target_ContactObjectID = theTarget.ObjectID;
				targeteeringEntry.Target_Latitude = theTarget.get_Latitude((GlobalVariables.BooleanObject)null);
				targeteeringEntry.Target_Longitude = theTarget.get_Longitude((GlobalVariables.BooleanObject)null);
				if (thePoint.TargeteeringList == null)
				{
					thePoint.TargeteeringList = new WriteLockedList<Mission.TargeteeringEntry>();
				}
				thePoint.TargeteeringList.Add(targeteeringEntry);
			}
		}
		else
		{
			Contact contact = (Contact)theTarget;
			text = theTarget.Name;
			if (text == null)
			{
				text = contact.DescriptionString;
			}
			if (text == null)
			{
				text = contact.Type.ToString();
			}
			Mission.TargeteeringEntry targeteeringEntry2 = new Mission.TargeteeringEntry(Guid.NewGuid().ToString(), 0, text, theTarget.ObjectID, contact.ActualUnit.ObjectID, contact.ActualUnit.DBID, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), null, null, null);
			targeteeringEntry2.Target_Description = theTarget.Name;
			targeteeringEntry2.Target_ContactObjectID = theTarget.ObjectID;
			targeteeringEntry2.Target_Latitude = theTarget.get_Latitude((GlobalVariables.BooleanObject)null);
			targeteeringEntry2.Target_Longitude = theTarget.get_Longitude((GlobalVariables.BooleanObject)null);
			if (thePoint.TargeteeringList == null)
			{
				thePoint.TargeteeringList = new WriteLockedList<Mission.TargeteeringEntry>();
			}
			thePoint.TargeteeringList.Add(targeteeringEntry2);
		}
	}

	public static bool ValidateArea(List<ReferencePoint> theArea, ref string UserFeedback, Side theSide, Scenario theScen, string AreaName)
	{
		bool result;
		try
		{
			if (theScen != null)
			{
				foreach (AreaValidatedObjects item in theScen.AreaAlreadyValidated)
				{
					if (Operators.CompareString(item.Name, AreaName, false) != 0)
					{
						continue;
					}
					if (!((theSide == null) & Information.IsNothing((object)item.Side)))
					{
						if (theSide == null || item.Side == null || Operators.CompareString(theSide.Name, item.Side.Name, false) != 0)
						{
							continue;
						}
						result = item.ValidationResult;
					}
					else
					{
						result = item.ValidationResult;
					}
					goto end_IL_0001;
				}
			}
			int num;
			if (theArea == null)
			{
				num = 1;
				goto IL_041c;
			}
			if (theArea.Count < 3)
			{
				num = 1;
				goto IL_041c;
			}
			int count = theArea.Count;
			string text = ((theSide == null) ? "" : theSide.Name);
			Geodesic_Vincenty.TLocalTM tLocalTM = new Geodesic_Vincenty.TLocalTM(theArea[0].Latitude, theArea[0].Longitude);
			Coordinate[] array = new Coordinate[count + 1];
			bool flag = false;
			int num2 = count - 1;
			double X = default(double);
			double Y = default(double);
			for (int i = 0; i <= num2; i++)
			{
				if (tLocalTM.method_0(theArea[i].Latitude, theArea[i].Longitude, ref X, ref Y, Allow_DEG_MAX_DELTA_LONG: true))
				{
					array[i] = new Coordinate(X, Y);
					continue;
				}
				flag = true;
				break;
			}
			if (flag)
			{
				if (!GeoPoint.PolygonCrossesAntimeridian(theArea))
				{
					int num3 = count - 1;
					for (int j = 0; j <= num3; j++)
					{
						X = Command_Core.Mercator_OSM.Mercator_OSM.lonToX(theArea[j].Longitude);
						Y = Command_Core.Mercator_OSM.Mercator_OSM.latToY(theArea[j].Latitude);
						array[j] = new Coordinate(X, Y);
					}
				}
				else
				{
					int num4 = count - 1;
					for (int k = 0; k <= num4; k++)
					{
						array[k] = new Coordinate(Math2.NormalizeLongitude(theArea[k].Longitude + 180.0), theArea[k].Latitude);
					}
				}
			}
			array[count] = array[0];
			bool flag2 = true;
			Coordinate[] array2 = array;
			for (int l = 0; l < array2.Length; l = checked(l + 1))
			{
				if (array2[l] != array[0])
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				UserFeedback = AreaName + " The coordinates of all the points are the same";
				int num5;
				if (theScen == null)
				{
					num5 = 0;
				}
				else
				{
					theScen.AreaAlreadyValidated.Add(new AreaValidatedObjects(AreaName, theSide, theArea, validationResult: false, UserFeedback));
					num5 = 0;
				}
				result = (byte)num5 != 0;
			}
			else
			{
				Polygon polygon = new Polygon(new LinearRing(array));
				try
				{
					if (!polygon.IsValid)
					{
						if (string.IsNullOrEmpty(AreaName) && string.IsNullOrEmpty(text))
						{
							UserFeedback = AreaName + " WARNING! Area validation has FAILED! The polygon that makes up the area crosses itself which means it is INVALID! This will cause problems for the AI navigator. Please check the shape of the area, and make sure that it doesn't cross itself at any point!";
						}
						else if (!string.IsNullOrEmpty(text))
						{
							UserFeedback = AreaName + " WARNING! Area validation for " + AreaName + " belonging to side " + text + " has FAILED! The polygon that makes up the area crosses itself which means it is INVALID! This will cause problems for the AI navigator. Please check the shape of the area, and make sure that it doesn't cross itself at any point!";
						}
						else
						{
							UserFeedback = AreaName + " WARNING! Area validation for " + AreaName + " has FAILED! The polygon that makes up the area crosses itself which means it is INVALID! This will cause problems for the AI navigator. Please check the shape of the area, and make sure that it doesn't cross itself at any point!";
						}
						int num6;
						if (theScen != null)
						{
							theScen.AreaAlreadyValidated.Add(new AreaValidatedObjects(AreaName, theSide, theArea, validationResult: false, UserFeedback));
							num6 = 0;
						}
						else
						{
							num6 = 0;
						}
						result = (byte)num6 != 0;
					}
					else
					{
						UserFeedback = AreaName + " ";
						int num7;
						if (theScen != null)
						{
							theScen.AreaAlreadyValidated.Add(new AreaValidatedObjects(AreaName, theSide, theArea, validationResult: true, UserFeedback));
							num7 = 1;
						}
						else
						{
							num7 = 1;
						}
						result = (byte)num7 != 0;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200324", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if (string.IsNullOrEmpty(AreaName) && string.IsNullOrEmpty(theSide.Name))
					{
						UserFeedback = AreaName + " WARNING! Area validation has FAILED! This will cause problems for the AI navigator. Please check the shape of the area and make sure it makes sense.";
					}
					else if (string.IsNullOrEmpty(theSide.Name))
					{
						UserFeedback = AreaName + " WARNING! Area validation for " + AreaName + " has FAILED! This will cause problems for the AI navigator. Please check the shape of the area and make sure it makes sense.";
					}
					else
					{
						UserFeedback = AreaName + " WARNING! Area validation for " + AreaName + " belonging to side " + text + " has FAILED! This will cause problems for the AI navigator. Please check the shape of the area and make sure it makes sense.";
					}
					int num8;
					if (theScen == null)
					{
						num8 = 0;
					}
					else
					{
						theScen.AreaAlreadyValidated.Add(new AreaValidatedObjects(AreaName, theSide, theArea, validationResult: false, UserFeedback));
						num8 = 0;
					}
					result = (byte)num8 != 0;
					ProjectData.ClearProjectError();
				}
			}
			goto end_IL_0001;
			IL_041c:
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 101270", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			int num9;
			if (theScen != null)
			{
				theScen.AreaAlreadyValidated.Add(new AreaValidatedObjects(AreaName, theSide, theArea, validationResult: false, null));
				num9 = 0;
			}
			else
			{
				num9 = 0;
			}
			result = (byte)num9 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static List<Geopoint_Struct> GetSamplePoints(Waypoint[] thePlottedCourse, double interval_nm)
	{
		List<Geopoint_Struct> list = new List<Geopoint_Struct>();
		if (thePlottedCourse.Length < 2)
		{
			return list;
		}
		double num = 0.0;
		Waypoint waypoint = thePlottedCourse[0];
		list.Add(new Geopoint_Struct(waypoint.Longitude, waypoint.Latitude));
		int num2 = thePlottedCourse.Length - 1;
		for (int i = 1; i <= num2; i++)
		{
			Waypoint waypoint2 = thePlottedCourse[i];
			double num3 = waypoint.RangeToPoint_Horiz(waypoint2);
			for (num += num3; num >= interval_nm; num -= interval_nm)
			{
				double ratio = (num - interval_nm) / num3;
				double theLat = Interpolate(waypoint.Latitude, waypoint2.Latitude, ratio);
				double theLon = Interpolate(waypoint.Longitude, waypoint2.Longitude, ratio);
				Geopoint_Struct item = new Geopoint_Struct(theLon, theLat);
				list.Add(item);
			}
			waypoint = waypoint2;
		}
		return list;
	}

	private static double Interpolate(double value1, double value2, double ratio)
	{
		return value1 + (value2 - value1) * ratio;
	}

	static ActiveUnit_Navigator()
	{
		Class72.smethod_20();
	}
}
