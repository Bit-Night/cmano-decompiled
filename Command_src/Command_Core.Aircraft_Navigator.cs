using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using CSMaterial.ExWorldWind;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Aircraft_Navigator : ActiveUnit_Navigator
{
	[CompilerGenerated]
	internal sealed class _Closure$__23-0
	{
		public Aircraft $VB$Local_theAC;

		public _Closure$__23-0(_Closure$__23-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theAC = arg0.$VB$Local_theAC;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(float _elapsedTime)
		{
			$VB$Local_theAC.AI.ReturnToBase(_elapsedTime);
		}

		static _Closure$__23-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__39-0
	{
		public Waypoint[] $VB$Local_myPlottedCourse;

		public _Closure$__39-0(_Closure$__39-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_myPlottedCourse = arg0.$VB$Local_myPlottedCourse;
			}
		}

		[SpecialName]
		internal bool _Lambda$__1(Waypoint theFP)
		{
			return Operators.CompareString(theFP.ObjectID, $VB$Local_myPlottedCourse[0].ObjectID, false) == 0;
		}

		static _Closure$__39-0()
		{
			Class72.smethod_20();
		}
	}

	private Aircraft aircraft_0;

	public const float WINGMEN_SEPARATION_NO_MISSION = 4f;

	public const float WINGMEN_REJOIN_SPEED_VARIATION_COEFFICIENT = 0.2f;

	public bool hasReachedInitialPointInThisPulse;

	public bool holdTimeChangedThisPulse;

	public bool PathfindingPlottedCourseLeadsToA2ARDestination
	{
		get
		{
			Aircraft a2AR_Destination = method_10().AirOps.A2AR_Destination;
			if (a2AR_Destination == null)
			{
				return false;
			}
			if (!base.HasPathfindingPlottedCourse)
			{
				return false;
			}
			Waypoint waypoint = PlottedCourse.Last();
			if (waypoint != null && Math2.CalcDist(a2AR_Destination, waypoint) < 20f)
			{
				return true;
			}
			Mission mission = a2AR_Destination.AssignedMissionOrPackage();
			int result;
			if (mission == null)
			{
				result = 0;
			}
			else
			{
				if (mission.MissionClass == Mission._MissionClass.Support)
				{
					List<ReferencePoint> navigationCourse = ((SupportMission)mission).NavigationCourse;
					foreach (ReferencePoint item in navigationCourse)
					{
						if (!(Math2.CalcDist(item, waypoint) >= 10f))
						{
							return true;
						}
					}
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	[SpecialName]
	private Aircraft method_10()
	{
		if (aircraft_0 == null)
		{
			aircraft_0 = (Aircraft)myUnit;
		}
		return aircraft_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Navigator");
			if (PlottedCourse.Count() > 0)
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
			if (base.PlottedCourse_PrePlanned.Count() > 0)
			{
				theWriter.WriteStartElement("PC_PP");
				List<Waypoint> list2 = new List<Waypoint>();
				list2.AddRange(base.PlottedCourse_PrePlanned);
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
			if (base.TankerFollowsMe_NumberOfWaypoints != 0)
			{
				theWriter.WriteElementString("TankerFollowsMe_NumberOfWaypoints", base.TankerFollowsMe_NumberOfWaypoints.ToString());
			}
			if (method_10().IsGroupMember())
			{
				theWriter.WriteElementString("FS_B", XmlConvert.ToString(base.UnitFormationStation.Bearing));
				theWriter.WriteElementString("FS_D", XmlConvert.ToString(base.UnitFormationStation.Distance));
				theWriter.WriteElementString("FS_BT", XmlConvert.ToString((byte)base.UnitFormationStation.BearingType));
			}
			if (SupportMission_NextRefPoint != null)
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
			if (PreviousWaypoint != null)
			{
				PreviousWaypoint.ToXML(ref theWriter, ref ObjectsAlreadySerialized, "PreviousWaypoint");
			}
			if (_ResumeFlightPlanWaypoint != null)
			{
				theWriter.WriteStartElement("RFPWP");
				theWriter.WriteString(_ResumeFlightPlanWaypoint.ObjectID);
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100459", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Aircraft_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected O, but got Unknown
		Aircraft_Navigator result;
		try
		{
			Aircraft_Navigator aircraft_Navigator = new Aircraft_Navigator(ref theAU);
			aircraft_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "RFPWP":
					if (theDictionary.ContainsKey(theNode2.InnerText))
					{
						ScenarioObject scenarioObject = theDictionary[theNode2.InnerText];
						if (scenarioObject.IsWaypoint)
						{
							aircraft_Navigator._ResumeFlightPlanWaypoint = (Waypoint)scenarioObject;
						}
					}
					break;
				case "TankerFollowsMe_NumberOfWaypoints":
					aircraft_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "PreviousWaypoint":
					aircraft_Navigator.PreviousWaypoint = Waypoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					aircraft_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "Flight":
					aircraft_Navigator._Flight_ID = theNode2.InnerText;
					break;
				case "PreviousWaypointType":
					if (Versioned.IsNumeric((object)theNode2.InnerText))
					{
						aircraft_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(theNode2.InnerText);
						break;
					}
					try
					{
						aircraft_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), theNode2.InnerText, ignoreCase: true);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 30651954651", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode5 = childNode2;
						Waypoint waypoint = Waypoint.FromXML(ref theNode5, ref theDictionary, theAU.ParentScen);
						if (waypoint.Latitude != 0.0 || waypoint.Longitude != 0.0)
						{
							ArrayExtensions.Add(ref aircraft_Navigator._PlottedCourse, waypoint);
						}
					}
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					aircraft_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(theNode2.InnerText);
					break;
				case "MPO":
				case "ManualPlotOverride":
					aircraft_Navigator.ManualPlotOverride = Misc.ParseBool(theNode2.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode4 = theNode2.ChildNodes[0];
					aircraft_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode4, ref theDictionary, theAU.ParentScen);
					break;
				}
				case "FS_BT":
					aircraft_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(theNode2.InnerText);
					break;
				case "PC_PP":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						Waypoint theAC = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						ArrayExtensions.Add(ref aircraft_Navigator._PlottedCourse_PrePlanned, theAC);
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					aircraft_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(theNode2.InnerText);
					break;
				case "TankerFollowsMe":
					aircraft_Navigator.TankerFollowsMe = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = aircraft_Navigator;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100460", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Aircraft_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void CalculateFormationStationRelativeData()
	{
		try
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null && !myUnit.IsGroupLead())
			{
				ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
				float currentHeading = groupLead.CurrentHeading;
				int seed = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToList().IndexOf(method_10());
				LockRandom lockRandom = new LockRandom(seed);
				float num = ((!(lockRandom.NextDouble() > 0.5)) ? Math2.NormalizeBearing(currentHeading - 90f) : Math2.NormalizeBearing(currentHeading + 90f));
				if (base.UnitFormationStation.BearingType == ReferencePoint.OrientationType.Rotating)
				{
					base.UnitFormationStation.Bearing = MathFunctions.AngularDifference(groupLead.CurrentHeading, num);
				}
				else
				{
					base.UnitFormationStation.Bearing = num;
				}
				base.UnitFormationStation.Distance = (float)(lockRandom.NextDouble() * 1.5);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1021341908598432694685438", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool HaveReachedFormationStation()
	{
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
			{
				var (lat, lon) = base.UnitFormationStation.get_LatitudeAndLongitude(myUnit, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
				if (Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), lat, lon) < 1f)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public Aircraft_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		hasReachedInitialPointInThisPulse = false;
		holdTimeChangedThisPulse = false;
		NavigationBufferTolerance_Narrow_meters = 100;
		NavigationBufferTolerance_Wide_meters = 1000;
	}

	public override void AddWaypoint(double Latitude, double Longitude, float Altitude, Waypoint.WaypointType theWaypointType, Waypoint.WaypointCreator theCreator, Waypoint.WaypointCategory theCategory, bool _overshoot = true)
	{
		if (!CanAutonomouslyPlotAndFollowCourse())
		{
			Notification_Bark.Create_UnitBehaviour(myUnit, myUnit.Name + " cannot autonomously plot and follow a course");
			return;
		}
		try
		{
			base.AddWaypoint(Latitude, Longitude, Altitude, theWaypointType, theCreator, theCategory, _overshoot);
			if (PlottedCourse.Count() == 1)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
			if (theWaypointType == Waypoint.WaypointType.ManualPlottedCourseWaypoint && myUnit.IsRTB)
			{
				myUnit.AddMessage("You'd better know what you're doing! I was on RTB!", myUnit.Name + " was on RTB", LoggedMessage.MessageType.UI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), ActiveUnit.NotificationType.Bark);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100461", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void PlotCourseToStationArea(float elapsedTime, bool AddWaypointToExistingPlottedCourse)
	{
		try
		{
			base.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse);
			if (!myUnit.Navigator.HasFlightPlan)
			{
				Aircraft_AirOps airOps = method_10().AirOps;
				if (myUnit.ActiveMissionOrPackage() != null && myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					SetPatrolThrottle(PursueContact: false, airOps.Condition);
					SetPatrolAltitude(PursueContact: false, airOps.Condition);
				}
				else if (myUnit.ActiveMissionOrPackage() != null)
				{
					_ = myUnit.ActiveMissionOrPackage().MissionClass;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100462", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void HeadToFormationStationOrFollowSecondaryFlightPlan(float elapsedtime)
	{
		if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive)
		{
			_ = Debugger.IsAttached;
			return;
		}
		if (method_10().IsGroupWingman())
		{
			bool flag = false;
			ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			if (groupLead == null)
			{
				return;
			}
			if (myUnit.RangeToUnit_Horiz(groupLead) < 4f)
			{
				myUnit.AI.HasCaughtUpWithGroup = true;
			}
			if (method_10().AssignedMissionOrPackage() != null && method_10().AssignedMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				Strike strike = (Strike)method_10().AssignedMissionOrPackage();
				if (strike.AttackMethod != Mission._AttackMethod.None && strike.AttackMethod != Mission._AttackMethod.Formation_SingleAim && PlottedCourse != null && PlottedCourse.Count() > 0)
				{
					Waypoint waypoint = PlottedCourse.FirstOrDefault();
					if ((waypoint != null && waypoint.Type == Waypoint.WaypointType.WeaponLaunch) || (waypoint != null && waypoint.Type == Waypoint.WaypointType.Target) || (waypoint != null && waypoint.IsSplitWaypoint()))
					{
						FollowPlottedCourse(elapsedtime);
						if (!myUnit.AI.HasCaughtUpWithGroup || !groupLead.Navigator.HasPlottedCourse() || groupLead.Navigator.PlottedCourse[0] != waypoint)
						{
							return;
						}
						flag = true;
					}
				}
			}
			if (!myUnit.Kinematics.DesiredAltitudeOverride)
			{
				if (groupLead.get_DesiredAltitude_UseTerrainFollowing(groupLead) && groupLead.DesiredAltitude_AGL > 0f && Math.Abs(groupLead.CurrentAltitude_AGL - groupLead.DesiredAltitude_AGL) < 100f)
				{
					myUnit.DesiredAltitude_AGL = groupLead.DesiredAltitude_AGL;
				}
				else
				{
					myUnit.DesiredAltitude = groupLead.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					myUnit.DesiredAltitude_AGL = 0f;
				}
			}
			if (flag)
			{
				return;
			}
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(groupLead.get_Longitude((GlobalVariables.BooleanObject)null), groupLead.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, base.UnitFormationStation.Distance, base.UnitFormationStation.get_ResultantBearing(myUnit));
			if (base.HasPathfindingPlottedCourse)
			{
				FollowPlottedCourse(elapsedtime);
				return;
			}
			if (HaveReachedFormationStation())
			{
				float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon));
				if (relativeBearing > 30f && relativeBearing < 330f)
				{
					IsManouveringToFormationStation = true;
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, groupLead.DesiredHeading);
					myUnit.DesiredSpeed = groupLead.CurrentSpeed - Module_Unit.RangeToPoint_Horiz(myUnit, out_lat, out_lon, GlobalVariables.ObjectTrue) * 10f;
				}
				else
				{
					myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon));
					myUnit.DesiredSpeed = groupLead.DesiredSpeed;
				}
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
				return;
			}
			IsManouveringToFormationStation = true;
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), out_lat, out_lon));
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None && !IsManouveringToFormationStation)
				{
					myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
				}
				else
				{
					myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
				}
			}
			else
			{
				myUnit.DesiredSpeed = groupLead.DesiredSpeed;
				if (groupLead.ThrottleSetting == ActiveUnit.Throttle.Flank)
				{
					myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed();
				}
				else if (Module_Unit.RangeToPoint_Horiz(myUnit, out_lat, out_lon) <= 4f)
				{
					myUnit.DesiredSpeed = groupLead.DesiredSpeed * 1.2f;
				}
				else
				{
					myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), groupLead.ThrottleSetting + 1, ValidateAndFixAltitude: false);
				}
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.DesiredSpeed));
			}
			if ((myUnit.Kinematics.DesiredSpeedOverride.HasValue || myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None) && groupLead.DesiredSpeed >= myUnit.DesiredSpeed && Math.Abs(MathFunctions.AngularDifference(groupLead.DesiredHeading, groupLead.CurrentHeading)) < 5f && Math.Abs(MathFunctions.AngularDifference(myUnit.DesiredHeading, groupLead.DesiredHeading)) < 45f)
			{
				myUnit.Kinematics.DesiredSpeedOverride = null;
				myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
			}
		}
		if (method_10().Navigator.HasPlottedCourse() & (PlottedCourse.Count() > 0))
		{
			Waypoint waypoint2 = PlottedCourse[0];
			if (HaveReachedPoint(waypoint2, elapsedtime, waypoint2.OvershootWaypoint, simplify_calc_for_ACs: true) && !(waypoint2.Hold_Time > 0f))
			{
				RemoveWaypoint_Soft(waypoint2, RemoveWingmanWaypoints: false);
			}
		}
	}

	private void method_11(Aircraft aircraft_1, ActiveUnit activeUnit_0)
	{
		int num = myUnit.Navigator.PlottedCourse.Length;
		int? num2 = activeUnit_0.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead?.Navigator.PlottedCourse.Length;
		if (((!num2.HasValue) ? ((bool?)null) : new bool?(num < num2.GetValueOrDefault())) == true)
		{
			myUnit.AI.HasCaughtUpWithGroup = true;
			return;
		}
		if ((activeUnit_0.Navigator.PlottedCourse != null) & (activeUnit_0.Navigator.PlottedCourse.Count() > 1))
		{
			Waypoint point = activeUnit_0.Navigator.PlottedCourse[0];
			Waypoint point2 = activeUnit_0.Navigator.PlottedCourse[1];
			if (Math2.CalcDist(aircraft_1, point2, true) < Math2.CalcDist(aircraft_1, point, true))
			{
				aircraft_1.AI.HasCaughtUpWithGroup = true;
			}
		}
		if (myUnit.RangeToUnit_Horiz(activeUnit_0) < 4f)
		{
			aircraft_1.AI.HasCaughtUpWithGroup = true;
		}
	}

	public void HandleReachedInitialPoint()
	{
		hasReachedInitialPointInThisPulse = true;
		myUnit.Kinematics.DesiredAltitudeOverride = false;
		byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
		bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
		if (((!flag) ?? flag) == true)
		{
			myUnit.Doctrine.set_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
		}
		if (!myUnit.IsGroupLead())
		{
			return;
		}
		ActiveUnit[] array = myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values.ToArray();
		foreach (ActiveUnit activeUnit in array)
		{
			if (activeUnit != myUnit && !activeUnit.Navigator.HasPlottedCourse())
			{
				activeUnit.Kinematics.DesiredSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
				activeUnit.Kinematics.ThrottlePreset = myUnit.Kinematics.ThrottlePreset;
				activeUnit.Kinematics.DesiredAltitudeOverride = false;
				b = (byte?)activeUnit.Doctrine.get_IgnorePlottedCourse(activeUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
				flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b == 1));
				if (((!flag) ?? flag) == true)
				{
					activeUnit.Doctrine.set_IgnorePlottedCourse(activeUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.Yes);
				}
			}
		}
	}

	internal bool IsFlightFormingUp()
	{
		if (myUnit.IsGroupLead())
		{
			foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
			{
				if (value.IsOperating())
				{
					if (!value.IsGroupLead())
					{
						method_11((Aircraft)value, value.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
						if (!value.AI.HasCaughtUpWithGroup)
						{
							return true;
						}
					}
					continue;
				}
				return true;
			}
		}
		return false;
	}

	protected override void HeadToFirstWaypoint(float elapsedTime)
	{
		try
		{
			Waypoint[] theArray = PlottedCourse;
			if (!method_10().IsWeapon && theArray != null && theArray.Count() > 0 && theArray[0].Type == Waypoint.WaypointType.WeaponTarget)
			{
				ArrayExtensions.Remove(ref theArray, theArray.ElementAt(0));
			}
			if (myUnit.IsGroupWingman() && myUnit.AI.GetMissionStateFlag(1u) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.Count() < theArray.Count() && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse != null && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse.Count() > 0 && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse[0].Waypoint_LeadElementWingman == null && ((Aircraft)myUnit).AI.CheckSeparationAndRejoin(elapsedTime))
			{
				return;
			}
			if (theArray.Length > 0 && theArray[0].Type == Waypoint.WaypointType.TakeOff)
			{
				ArrayExtensions.Remove(ref theArray, theArray.ElementAt(0));
			}
			Waypoint TargetWaypoint;
			bool flag;
			if (theArray.Length > 0)
			{
				TargetWaypoint = theArray.FirstOrDefault();
				while (TargetWaypoint.Type == Waypoint.WaypointType.WeaponTarget && theArray.Count() > 1)
				{
					ArrayExtensions.Remove(ref theArray, TargetWaypoint);
					TargetWaypoint = theArray.FirstOrDefault();
				}
				if (myUnit.Navigator.HasFlightPlan && myUnit.Navigator.HasPlottedCourse())
				{
					flag = true;
					int num;
					if (TargetWaypoint.Type != Waypoint.WaypointType.StationStart_FigureEight)
					{
						if (PreviousWaypoint == null || PreviousWaypoint.Type != Waypoint.WaypointType.StationStart_FigureEight)
						{
							goto IL_01b8;
						}
						num = 0;
					}
					else
					{
						num = 0;
					}
					flag = (byte)num != 0;
					goto IL_01b8;
				}
				goto IL_0284;
			}
			ManualPlotOverride = false;
			return;
			IL_0284:
			float num2 = Module_Unit.RangeToPoint_Horiz(myUnit, TargetWaypoint);
			ActiveUnit.TurnRate theTurnRate = ((TargetWaypoint.Type != Waypoint.WaypointType.TakeOff) ? ((TargetWaypoint.Type != Waypoint.WaypointType.LandingMarshal || !(num2 < 1f)) ? ActiveUnit.TurnRate.Navigation : ActiveUnit.TurnRate.Max) : ActiveUnit.TurnRate.Max);
			float num3 = 0f;
			bool flag2 = false;
			if (method_10().isSuicide() && TargetWaypoint.Type == Waypoint.WaypointType.Target)
			{
				Contact primaryTarget = method_10().AI.PrimaryTarget;
				Mission.TargeteeringEntry targeteeringEntry = TargetWaypoint.TargeteeringList.FirstOrDefault();
				if (primaryTarget != null && targeteeringEntry != null && Operators.CompareString(primaryTarget.ObjectID, targeteeringEntry.Target_ContactObjectID, false) == 0 && primaryTarget.AltitudeIsKnown)
				{
					num3 = ((Module_Unit.Unit)primaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					myUnit.set_DesiredHeading(theTurnRate, Module_Unit.BearingToPoint_True(myUnit, ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
					flag2 = true;
				}
			}
			if (!flag2)
			{
				myUnit.set_DesiredHeading(theTurnRate, Module_Unit.BearingToPoint_True(myUnit, TargetWaypoint.Latitude, TargetWaypoint.Longitude));
				if (TargetWaypoint.TerrainFollowing && TargetWaypoint.DesiredAltitude_TerrainFollowing.HasValue)
				{
					num3 = TargetWaypoint.DesiredAltitude_TerrainFollowing.Value + (float)Math.Max(0, (int)Terrain.GetElevation(TargetWaypoint.Latitude, TargetWaypoint.Longitude, RequestIsFromGUI: false, myUnit.ParentScen));
				}
				else if (TargetWaypoint.DesiredAltitude.HasValue)
				{
					num3 = TargetWaypoint.DesiredAltitude.Value;
				}
			}
			if (num3 > 0f)
			{
				float num4 = myUnit.Kinematics.HorizDistranceRequiredToReachDesiredAltitude(myUnit, num3);
				if ((double)num2 < (double)num4 * 1.1)
				{
					if (myUnit.get_DesiredAltitude_UseTerrainFollowing(myUnit))
					{
						if (TargetWaypoint.TerrainFollowing)
						{
							myUnit.DesiredAltitude_AGL = TargetWaypoint.DesiredAltitude_TerrainFollowing.Value;
						}
						else
						{
							myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value: false);
							myUnit.DesiredAltitude = num3;
						}
					}
					else
					{
						myUnit.DesiredAltitude = num3;
					}
				}
			}
			ExtendIfNecessary(theTurnRate: (method_10().DesiredTurnRate != ActiveUnit.TurnRate.Navigation || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive || myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedDefensive) ? myUnit.Kinematics.TurnRate() : ((myUnit.Navigator.get_Flight(HierarchySearch: true) != null) ? ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(myUnit.DesiredTurnRate_Navigation, myUnit.CurrentSpeed) : myUnit.Kinematics.TurnRate()), elapsedTime: elapsedTime, theWaypoint: ref TargetWaypoint, TargetLat: TargetWaypoint.Latitude, TargetLon: TargetWaypoint.Longitude, Buffer_Seconds: 0f, Buffer_Distance_nm: 0f);
			return;
			IL_01b8:
			if (TargetWaypoint.SpacingManeuver_Time > 0f)
			{
				if (myUnit.AI.ManouverForSpace(TargetWaypoint.Time_Zulu, ref TargetWaypoint, LoiterAtWaypoint: false))
				{
					return;
				}
			}
			else if (flag && TargetWaypoint.Hold_Time > 0f && TargetWaypoint.IsHoldEndWaypoint())
			{
				if (TargetWaypoint.RaceTrackHelperPoint != null && theArray.Length > 1)
				{
					if (method_10().AI.ManouverRaceTrack(ref myUnit.ParentScen, ref TargetWaypoint))
					{
						return;
					}
				}
				else if (method_10().AI.ManouverForSpace(TargetWaypoint.Time_Zulu, ref TargetWaypoint, LoiterAtWaypoint: false))
				{
					return;
				}
			}
			else if (flag && TargetWaypoint.Hold_Time > 0f && method_10().AI.ManouverForSpace(TargetWaypoint.Time_Zulu, ref TargetWaypoint, LoiterAtWaypoint: false))
			{
				return;
			}
			goto IL_0284;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10023296543967976", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void CleanPlottedCourse(ref Waypoint[] localPlottedCourse)
	{
		try
		{
			if (localPlottedCourse == null || localPlottedCourse.Length == 0)
			{
				return;
			}
			Waypoint waypoint = localPlottedCourse.FirstOrDefault();
			if (waypoint == null)
			{
				return;
			}
			if (waypoint.Type == Waypoint.WaypointType.TakeOff)
			{
				RemoveWaypoint_Soft(waypoint, RemoveWingmanWaypoints: false);
				localPlottedCourse = PlottedCourse;
				waypoint = localPlottedCourse.FirstOrDefault();
				if (waypoint == null)
				{
					return;
				}
			}
			while (waypoint.Type == Waypoint.WaypointType.WeaponTarget)
			{
				ArrayExtensions.Remove(ref localPlottedCourse, waypoint);
				waypoint = localPlottedCourse.FirstOrDefault();
				if (waypoint == null)
				{
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100463_813", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void CheckIfReachedWaypoint_AND_Apply_WP_logic(float elapsedTime, ref bool ForceWaypointSwitch, ref bool ForceStationAbort)
	{
		ForceWaypointSwitch = false;
		float value = 0.1f;
		Waypoint[] localPlottedCourse = default(Waypoint[]);
		Waypoint waypoint_ = default(Waypoint);
		try
		{
			localPlottedCourse = PlottedCourse;
			CleanPlottedCourse(ref localPlottedCourse);
			waypoint_ = localPlottedCourse?.FirstOrDefault();
			if (localPlottedCourse == null || localPlottedCourse.Length == 0 || waypoint_ == null)
			{
				return;
			}
			if (waypoint_.Type == Waypoint.WaypointType.StrikeEgress)
			{
				value = 1f;
			}
			else if (method_10().IsHelicopter)
			{
				value = 0.01f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100463_0", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		bool? flag = null;
		try
		{
			Scenario parentScen = myUnit.ParentScen;
			if (DateTime.Compare(WP_reach_cache_memory.theTime, parentScen.Time) != 0)
			{
				if (((waypoint_.Latitude == WP_reach_cache_memory.theWaypoint.Latitude) & (waypoint_.Longitude == WP_reach_cache_memory.theWaypoint.Longitude)) && myUnit.Location == WP_reach_cache_memory.UnitLocation)
				{
					flag = WP_reach_cache_memory.theResult;
				}
			}
			else
			{
				if (parentScen.GameContext.GameMode != Game._GameMode.ScenEdit)
				{
					return;
				}
				if (myUnit.Location == WP_reach_cache_memory.UnitLocation)
				{
					flag = WP_reach_cache_memory.theResult;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100463_1", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (waypoint_.Hold_Time > 0f && !holdTimeChangedThisPulse)
			{
				holdTimeChangedThisPulse = true;
				if (!waypoint_.Time_Zulu.HasValue)
				{
					waypoint_.Hold_Time = Math.Max(0f, waypoint_.Hold_Time - elapsedTime);
				}
				else
				{
					waypoint_.Hold_Time = Math.Max(0f, (float)(waypoint_.Time_Zulu.Value - method_10().ParentScen.Time).TotalSeconds);
				}
			}
			if ((!ForceWaypointSwitch && (waypoint_.Type == Waypoint.WaypointType.Assemble || waypoint_.Type == Waypoint.WaypointType.HoldEnd) && myUnit.IsGroupLead() && (Information.IsNothing((object)waypoint_.Time_Zulu) || !(waypoint_.Hold_Time > 0f)) && IsFlightFormingUp()) || (!ForceWaypointSwitch && waypoint_.Hold_Time > 0f))
			{
				return;
			}
			Waypoint waypoint = default(Waypoint);
			if (waypoint_.Type == Waypoint.WaypointType.StationEnd)
			{
				waypoint = waypoint_;
			}
			else
			{
				int? num = (int?)PreviousWaypointType;
				bool? flag3;
				bool? flag2 = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 24)));
				bool? flag4;
				flag3 = (flag4 = ((flag2.HasValue && flag3 != true) ? new bool?(false) : ((localPlottedCourse.Length > 1) & flag3)));
				bool? flag5 = ((flag3.HasValue && flag4 != true) ? new bool?(false) : ((localPlottedCourse[1].Type == Waypoint.WaypointType.StationEnd) & flag4));
				if ((flag5 ?? true) && localPlottedCourse[1].Station_Time > 0f && flag5.HasValue)
				{
					waypoint = localPlottedCourse[1];
				}
			}
			if (waypoint != null)
			{
				if (((ActiveUnit)method_10()).IsRTB)
				{
					ForceStationAbort = true;
				}
				else if (!Information.IsNothing((object)waypoint.Time_Zulu) && waypoint_.Station_Time > 0f)
				{
					DateTime? time_Zulu = waypoint.Time_Zulu;
					DateTime time = myUnit.ParentScen.Time;
					if ((time_Zulu.HasValue ? new bool?(DateTime.Compare(time_Zulu.GetValueOrDefault(), time) <= 0) : ((bool?)null)) == true)
					{
						ForceStationAbort = true;
						if (myUnit.IsGroupMember())
						{
							myUnit.AddMessage(myUnit.get_ParentGroup(UsingMissionPlanner: false).Name + "  has completed the station time and is heading to next waypoint.", myUnit.Name + " moving on", LoggedMessage.MessageType.UI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), ActiveUnit.NotificationType.Bark);
						}
						else
						{
							myUnit.AddMessage(myUnit.Name + " has completed the station time and is heading to next waypoint.", myUnit.Name + " moving on", LoggedMessage.MessageType.UI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), ActiveUnit.NotificationType.Bark);
						}
					}
				}
			}
			if (PreviousWaypoint != null && ((PreviousWaypoint.Type == Waypoint.WaypointType.StrikeIngress) & (waypoint_.Type == Waypoint.WaypointType.StrikeEgress)))
			{
				PreviousWaypoint = null;
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100463_2", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (((ActiveUnit)method_10()).IsRTB && method_10().IsOnActiveStrike && !method_10().AI.IsEscort && !method_10().IsGroupWingman() && FollowingRTB_FlightPlan() && method_10().Navigator.IsOnAutoPlannerPlottedCourse_CruiseAndAttackIngressRun)
			{
				EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 100463_2_5", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			bool? flag4;
			bool? flag3 = (flag4 = flag ?? new bool?(false));
			bool? flag5 = ((flag3.HasValue && flag4 != true) ? new bool?(false) : ((waypoint_.Latitude == WP_reach_cache_memory.theWaypoint.Latitude) & flag4));
			if ((!(flag5 ?? true) || waypoint_.Longitude != WP_reach_cache_memory.theWaypoint.Longitude || !flag5.HasValue) && !HaveReachedPoint(waypoint_, elapsedTime, waypoint_.OvershootWaypoint, simplify_calc_for_ACs: true, value) && !ForceWaypointSwitch)
			{
				return;
			}
			if ((waypoint_.Type == Waypoint.WaypointType.Assemble || waypoint_.Type == Waypoint.WaypointType.HoldEnd) && myUnit.IsGroupLead())
			{
				if (myUnit.IsGroupMember())
				{
					myUnit.AddMessage(myUnit.get_ParentGroup(UsingMissionPlanner: false).Name + " has finished assembling and is heading to next waypoint.", myUnit.get_ParentGroup(UsingMissionPlanner: false).Name + " moving out", LoggedMessage.MessageType.UI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), ActiveUnit.NotificationType.Bark);
				}
				else
				{
					myUnit.AddMessage(myUnit.Name + " has finished assembling and is heading to next waypoint.", myUnit.Name + " moving out", LoggedMessage.MessageType.UI, 1, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)), ActiveUnit.NotificationType.Bark);
				}
			}
			if (method_10().isSuicide() && waypoint_.Type == Waypoint.WaypointType.Target && !method_10().myTargetDoesNotExist())
			{
				return;
			}
			PreviousWaypoint = waypoint_;
			myUnit.AI.SetMissionStateFlag(1u, theValue: false);
			if (method_13(elapsedTime, ref waypoint_, ref ForceStationAbort))
			{
				return;
			}
			ApplyWaypointSpeedAltToUnit(waypoint_);
			ApplyWaypointDoctrineToUnit(waypoint_);
			ApplyWaypointActionToUnit(waypoint_);
			RemoveWaypoint_Soft(waypoint_, RemoveWingmanWaypoints: false);
			if (waypoint_.Type != Waypoint.WaypointType.InitialPoint && waypoint_.Type != Waypoint.WaypointType.WeaponLaunch)
			{
				if ((waypoint_.Type == Waypoint.WaypointType.Refuel) & (method_10().Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse))
				{
					method_12(elapsedTime, waypoint_, method_10());
				}
			}
			else
			{
				HandleReachedInitialPoint();
			}
			if ((waypoint_.Type == Waypoint.WaypointType.LandingMarshal) | (waypoint_.Type == Waypoint.WaypointType.Land))
			{
				if (myUnit.IsGroupLead())
				{
					List<ActiveUnit> list = new List<ActiveUnit>();
					lock (myUnit.get_ParentGroup(UsingMissionPlanner: false).Units)
					{
						list = new List<ActiveUnit>(myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values);
					}
					list.Remove(myUnit);
					using List<ActiveUnit>.Enumerator enumerator = list.GetEnumerator();
					_Closure$__23-0 closure$__23- = default(_Closure$__23-0);
					while (enumerator.MoveNext())
					{
						closure$__23- = new _Closure$__23-0(closure$__23-);
						closure$__23-.$VB$Local_theAC = (Aircraft)enumerator.Current;
						if (closure$__23-.$VB$Local_theAC != null)
						{
							if (!GlobalVariables.AI_REWORK)
							{
								closure$__23-.$VB$Local_theAC.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
								closure$__23-.$VB$Local_theAC.AI.ReturnToBase(elapsedTime);
							}
							else
							{
								closure$__23-.$VB$Local_theAC.AI.StatusRelatedEvents.method_1(ActiveUnit._ActiveUnitStatus.RTB_MissionOver, closure$__23-._Lambda$__0);
							}
						}
					}
				}
				if (!GlobalVariables.AI_REWORK)
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_MissionOver;
					method_10().AI.ReturnToBase(elapsedTime);
				}
				else
				{
					method_10().AI.StatusRelatedEvents.method_1(ActiveUnit._ActiveUnitStatus.RTB_MissionOver, [SpecialName] (float _elapsedTime) =>
					{
						method_10().AI.ReturnToBase(_elapsedTime);
					});
				}
			}
			if ((!Information.IsNothing((object)method_10().ActiveMissionOrPackage()) && method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol && ((Patrol)method_10().ActiveMissionOrPackage()).Type == GlobalVariables.PatrolType.ASW && method_10().Sensory.HasAvailableDippingSonar && method_10().AirOps.HoverForDippingSonar()) || (waypoint_.Type == Waypoint.WaypointType.LocalizationRun && method_10().Sensory.HasAvailableDippingSonar && myUnit.AI.PrimaryTarget != null && method_10().AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine && (method_10().Weaponry.HaveSuitableWeaponForAmbigousTarget(myUnit.AI.PrimaryTarget, CheckCanShootRightNow: false) || method_10().AirOps.HoverForDippingSonar())) || ((waypoint_.Type == Waypoint.WaypointType.PickupPoint || waypoint_.Type == Waypoint.WaypointType.DropOffPoint) && method_10().AirOps.SettleForCargoTransfer()))
			{
				return;
			}
			if (base.TankerFollowsMe_NumberOfWaypoints != 0 && !myUnit.AI.RaceTrackPoint.HasValue)
			{
				bool? obj3;
				if (waypoint_.IsStationEndWaypoint())
				{
					int? num = (int?)PreviousWaypointType;
					bool? flag7;
					bool? flag6 = (flag7 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 22)));
					bool? obj;
					bool? flag8;
					if (flag6.HasValue && flag7 == true)
					{
						obj = true;
					}
					else
					{
						num = (int?)PreviousWaypointType;
						flag6 = (flag8 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 21)));
						obj = ((!flag6.HasValue) ? ((bool?)null) : ((flag8 == true) | flag7));
					}
					bool? flag2 = obj;
					flag8 = obj;
					bool? obj2;
					bool? flag9;
					if (flag8.HasValue && flag2 == true)
					{
						obj2 = true;
					}
					else
					{
						num = (int?)PreviousWaypointType;
						flag8 = (flag9 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 20)));
						obj2 = ((!flag8.HasValue) ? ((bool?)null) : ((flag9 == true) | flag2));
					}
					flag4 = obj2;
					flag9 = obj2;
					if (flag9.HasValue && flag4 == true)
					{
						obj3 = true;
					}
					else
					{
						num = (int?)PreviousWaypointType;
						flag9 = (flag3 = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 23)));
						obj3 = ((!flag9.HasValue) ? ((bool?)null) : ((flag3 == true) | flag4));
					}
				}
				else
				{
					obj3 = false;
				}
				flag5 = obj3;
				if (((!flag5) ?? flag5) == true)
				{
					AdjustTankerMustFollowMe_NumberOfWaypoints(ref waypoint_);
				}
			}
			if (myUnit.Navigator.IsOnAutoPlannerPlottedCourse && localPlottedCourse.Count() > 0 && base.TankerFollowsMe_NumberOfWaypoints == 0)
			{
				byte? b = (byte?)myUnit.Doctrine.get_UseReplenishment(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					if (myUnit.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
					{
						TankerFollowsMe = null;
						method_10().AirOps.DisconnectFromTanker();
						string text = "";
						if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
						{
							text = " (" + myUnit.UnitClass + ")";
						}
						Aircraft aircraft = method_10();
						double TotalCurrent = 0.0;
						double TotalMax = 0.0;
						if (aircraft.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) < 0.99)
						{
							myUnit.AddMessage(myUnit.Name + text + " has reached a waypoint where air refuelling Is no longer allowed. Disconnecting from tanker even though the aircraft isn't fully refuelled.", myUnit.Name + " disconnecting", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
						else
						{
							myUnit.AddMessage(myUnit.Name + text + " has reached a waypoint where air refuelling Is no longer allowed. Disconnecting from tanker.", myUnit.Name + " disconnecting", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
						}
					}
					if (myUnit.IsGroupLead())
					{
						foreach (ActiveUnit value2 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
						{
							if (value2 != myUnit && !value2.Navigator.HasPlottedCourse() && value2.Status == ActiveUnit._ActiveUnitStatus.Refuelling)
							{
								TankerFollowsMe = null;
								((Aircraft)value2).AirOps.DisconnectFromTanker();
								string text2 = "";
								if (value2.IsAircraft && Operators.CompareString(value2.Name, value2.UnitClass, false) != 0)
								{
									text2 = " (" + value2.UnitClass + ")";
								}
								Aircraft aircraft2 = method_10();
								double TotalMax = 0.0;
								double TotalCurrent = 0.0;
								if (aircraft2.FuelPercent(ref TotalMax, ref TotalCurrent, MissionFuel: false) < 0.99)
								{
									value2.AddMessage(value2.Name + text2 + " has reached a waypoint where air refuelling is no longer allowed. Disconnecting from tanker even though the aircraft isn't fully refuelled.", value2.Name + " disconnecting A2AR", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(value2.get_Longitude((GlobalVariables.BooleanObject)null), value2.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
								else
								{
									value2.AddMessage(value2.Name + text2 + " has reached a waypoint where air refuelling is no longer allowed. Disconnecting from tanker.", value2.Name + " disconnecting A2AR", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(value2.get_Longitude((GlobalVariables.BooleanObject)null), value2.get_Latitude((GlobalVariables.BooleanObject)null)));
								}
							}
						}
					}
				}
			}
			if (waypoint_.Type == Waypoint.WaypointType.Assemble)
			{
				if (localPlottedCourse.Count() > 0)
				{
					myUnit.CurrentHeading = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), localPlottedCourse[0].Latitude, localPlottedCourse[0].Longitude);
				}
				if (myUnit.IsGroupLead())
				{
					foreach (ActiveUnit value3 in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
					{
						if (!value3.IsGroupLead() && value3.IsOperating())
						{
							value3.CurrentHeading = myUnit.CurrentHeading;
						}
					}
				}
			}
			myUnit.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
			myUnit.Navigator.PreviousWaypointLatitude = waypoint_.Latitude;
			myUnit.Navigator.PreviousWaypointLongitude = waypoint_.Longitude;
			myUnit.Navigator.PreviousWaypointType = waypoint_.Type;
			if (localPlottedCourse.Count() > 0)
			{
				ExtendTimer = 0.0;
				if ((waypoint_.Category == Waypoint.WaypointCategory.FlightPlan) & (myUnit.Status == ActiveUnit._ActiveUnitStatus.OnPlottedCourse))
				{
					if (PlottedCourse.Count() > 0 && PlottedCourse.Contains(waypoint_))
					{
						Waypoint[] theArray = PlottedCourse;
						ArrayExtensions.Remove(ref theArray, waypoint_);
						PlottedCourse = theArray;
					}
					localPlottedCourse = PlottedCourse;
				}
				if ((waypoint_.Type == Waypoint.WaypointType.Refuel) & !myUnit.AI.GetMissionStateFlag(1u))
				{
					method_12(elapsedTime, waypoint_, myUnit);
				}
				else
				{
					HeadToFirstWaypoint(elapsedTime);
					ExtendTimer = 0.0;
				}
				method_14(elapsedTime, ref waypoint_);
			}
			if (base.IsOnAutoPlannerPlottedCourse && localPlottedCourse[0].Type != Waypoint.WaypointType.Target && localPlottedCourse[0].Type != Waypoint.WaypointType.WeaponTarget && localPlottedCourse[0].Type != Waypoint.WaypointType.InitialPoint && localPlottedCourse[0].Type != Waypoint.WaypointType.WeaponLaunch && myUnit.Navigator.NeedToExtend(localPlottedCourse[0].Latitude, localPlottedCourse[0].Longitude, 0f, 0f, ActiveUnit_Kinematics.TurnRateCategoryToActualTurnRate(myUnit.DesiredTurnRate_Navigation, myUnit.CurrentSpeed)) && Math2.CalcDist(myUnit, localPlottedCourse[0]) < 10f)
			{
				bool ForceWaypointSwitch2 = true;
				bool ForceStationAbort2 = false;
				CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch2, ref ForceStationAbort2);
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 100463_3", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_12(float float_0, Waypoint waypoint_0, ActiveUnit activeUnit_0)
	{
		if (waypoint_0.Type == Waypoint.WaypointType.Refuel && method_10().AirOps.A2AR_Destination == null)
		{
			GeoPoint intermediateTargetPoint = method_10().AI.IntermediateTargetPointForRefuelCalcs();
			List<Mission> theSelectedMissions = null;
			int num;
			if (waypoint_0.TankerUsage == Mission.TankerMethod.Mission)
			{
				theSelectedMissions = waypoint_0.TankerMissions;
				num = 0;
			}
			else
			{
				num = 0;
			}
			bool MissionPlanner_PostponedRefuelling = (byte)num != 0;
			Doctrine._UnderwayRefuelAndReplenishmentSelection? underwayRefuelAndReplenishmentSelection = waypoint_0.GetDoctrine(method_10().ParentScen).get_ReplenishmentSelection(method_10().ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false, viaFlightPlanEditor: false);
			if (!underwayRefuelAndReplenishmentSelection.HasValue)
			{
				underwayRefuelAndReplenishmentSelection = Doctrine._UnderwayRefuelAndReplenishmentSelection.TankersBetweenUsAndObjectiveButAllowEmergencyTurnaround;
			}
			Aircraft_AirOps airOps = method_10().AirOps;
			Doctrine._UnderwayRefuelAndReplenishmentSelection value = underwayRefuelAndReplenishmentSelection.Value;
			bool IsManual = false;
			ActiveUnit theSelectedTanker = null;
			string UserFeedback = "";
			bool IsRTB = ((ActiveUnit)method_10()).IsRTB;
			bool flag = airOps.AttemptToScheduleRefuel(intermediateTargetPoint, value, ref IsManual, IsForced: true, ref theSelectedTanker, ref theSelectedMissions, ref UserFeedback, ref IsRTB, ref MissionPlanner_PostponedRefuelling, Aircraft_AirOps.RefuelScheduleReason.FlightPlanMandatedRefuel);
			if (waypoint_0.TankerFollowsReceivers)
			{
				TankerFollowsMe = true;
				base.TankerFollowsMe_NumberOfWaypoints = waypoint_0.TankerFollowsReceivers_NumberOfWaypoints;
				string text = "";
				if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, false) != 0)
				{
					text = " (" + activeUnit_0.UnitClass + ")";
				}
				if (base.TankerFollowsMe_NumberOfWaypoints > 0)
				{
					activeUnit_0.AddMessage(activeUnit_0.Name + text + " has reached a Refuelling waypoint and will now attempt to hook up with a tanker. The tanker will provide enroute refuelling and will stay with the aircraft for " + Conversions.ToString(base.TankerFollowsMe_NumberOfWaypoints) + " waypoints to ensure the tanks are full at that point, then disconnect, and proceed with the mission.", activeUnit_0.Name + " to attempt tanker hookup", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (base.TankerFollowsMe_NumberOfWaypoints == -98)
				{
					activeUnit_0.AddMessage(activeUnit_0.Name + text + " has reached a Refuelling waypoint and will now attempt to hook up with a tanker. The tanker will provide enroute refuelling and will stay with the aircraft until the next Station waypoint ensure the tanks are full at that point, then disconnect, and proceed with the mission.", activeUnit_0.Name + " to attempt tanker hookup", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (base.TankerFollowsMe_NumberOfWaypoints == -97)
				{
					activeUnit_0.AddMessage(activeUnit_0.Name + text + " has reached a Refuelling waypoint and will now attempt to hook up with a tanker. The tanker will provide enroute refuelling and will stay with the aircraft until the next Hold End waypoint to ensure the tanks are full at that point, then disconnect, and proceed with the mission.", activeUnit_0.Name + " to attempt tanker hookup", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else if (base.TankerFollowsMe_NumberOfWaypoints == -99)
				{
					activeUnit_0.AddMessage(activeUnit_0.Name + text + " has reached a Refuelling waypoint and will now attempt to hook up with a tanker. The tanker will provide enroute refuelling and will stay with the aircraft until the Landing Marshal waypoint, then disconnect, and proceed with the mission.", activeUnit_0.Name + " to attempt tanker hookup", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					activeUnit_0.AddMessage(activeUnit_0.Name + text + " has reached a Refuelling waypoint and will now attempt to hook up with a tanker. The tanker will provide enroute refuelling, and the aircraft will disconnect and proceed with the mission when full.", activeUnit_0.Name + " to attempt tanker hookup", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				TankerFollowsMe = false;
				base.TankerFollowsMe_NumberOfWaypoints = 0;
				string text2 = "";
				if (activeUnit_0.IsAircraft && Operators.CompareString(activeUnit_0.Name, activeUnit_0.UnitClass, false) != 0)
				{
					text2 = " (" + activeUnit_0.UnitClass + ")";
				}
				activeUnit_0.AddMessage(activeUnit_0.Name + text2 + " has reached a Refuelling waypoint and will now attempt to hook up With a tanker To refuel. The aircraft will disconnect and proceed With the mission when full.", activeUnit_0.Name + " to attempt tanker hookup", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			if (activeUnit_0.IsGroupLead())
			{
				foreach (ActiveUnit value2 in activeUnit_0.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
				{
					if (value2 != activeUnit_0 && !value2.Navigator.HasPlottedCourse())
					{
						value2.Navigator.TankerFollowsMe_NumberOfWaypoints = base.TankerFollowsMe_NumberOfWaypoints;
					}
				}
			}
			if (flag && !MissionPlanner_PostponedRefuelling)
			{
				method_10().AI.PerformScheduledRefuel(float_0);
			}
		}
		else if (activeUnit_0.Status != ActiveUnit._ActiveUnitStatus.Refuelling)
		{
			TankerFollowsMe = null;
			base.TankerFollowsMe_NumberOfWaypoints = 0;
		}
	}

	private bool method_13(float float_0, ref Waypoint waypoint_0, ref bool bool_4)
	{
		bool result;
		try
		{
			if (myUnit.Navigator.HasFlightPlan)
			{
				if (!bool_4)
				{
					if (!waypoint_0.IsStationEndWaypoint())
					{
						result = false;
					}
					else
					{
						int num = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan.Count() - 1;
						Waypoint waypoint = default(Waypoint);
						for (int i = 1; i <= num; i++)
						{
							if (myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i] == waypoint_0)
							{
								waypoint = myUnit.Navigator.get_Flight(HierarchySearch: true).FlightPlan[i - 1];
								break;
							}
						}
						if (Information.IsNothing((object)waypoint))
						{
							result = false;
						}
						else if (waypoint.IsStationStartWaypoint())
						{
							bool flag = false;
							if (waypoint.IsStationStartWaypoint())
							{
								myUnit.Navigator.ClearPathfindingWaypoints();
								ActiveUnit_Navigator navigator = myUnit.Navigator;
								Waypoint[] theFlightPlan = navigator.PlottedCourse;
								ActiveUnit_Navigator.AddWaypoint(ref theFlightPlan, 0, waypoint);
								navigator.PlottedCourse = theFlightPlan;
								if (waypoint.Type == Waypoint.WaypointType.StationStart_RaceTrackRandom && GameGeneral.GlobalRNG.Next(1, 100) <= 33)
								{
									myUnit.Navigator.PlotCourseToStationArea(float_0, AddWaypointToExistingPlottedCourse: true);
									flag = true;
								}
							}
							if (!flag)
							{
								ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
								ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
								ApplyWaypointActionToUnit(PlottedCourse[0]);
								myUnit.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
								myUnit.Navigator.PreviousWaypointLatitude = waypoint_0.Latitude;
								myUnit.Navigator.PreviousWaypointLongitude = waypoint_0.Longitude;
								myUnit.Navigator.PreviousWaypointType = waypoint_0.Type;
							}
							ExtendTimer = 0.0;
							HeadToFirstWaypoint(float_0);
							ExtendTimer = 0.0;
							result = true;
						}
						else
						{
							result = false;
						}
					}
				}
				else if (!waypoint_0.IsStationEndWaypoint())
				{
					int num2;
					if (waypoint_0.IsStationStartWaypoint())
					{
						ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
						ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
						ApplyWaypointActionToUnit(PlottedCourse[0]);
						RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
						myUnit.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
						myUnit.Navigator.PreviousWaypointLatitude = waypoint_0.Latitude;
						myUnit.Navigator.PreviousWaypointLongitude = waypoint_0.Longitude;
						myUnit.Navigator.PreviousWaypointType = waypoint_0.Type;
						waypoint_0 = PlottedCourse[0];
						num2 = 0;
					}
					else
					{
						num2 = 0;
					}
					result = (byte)num2 != 0;
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
			ex2?.Data.Add("Error at 525424524524444", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_14(float float_0, ref Waypoint waypoint_0)
	{
		try
		{
			if (PlottedCourse.Count() <= 0 || !myUnit.IsGroupLead() || waypoint_0.FlightFormation == Waypoint.Formation.Split || PlottedCourse[0].FlightFormation != Waypoint.Formation.Split)
			{
				return;
			}
			foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
			{
				if (value.FlightRole == Mission.Flight.FlightElement.LeadElement || !value.IsOperating())
				{
					continue;
				}
				Waypoint[] theArray = new Waypoint[0];
				value.Navigator.ApplyWaypointSpeedAltToUnit(waypoint_0);
				value.Navigator.ApplyWaypointDoctrineToUnit(waypoint_0);
				value.Navigator.PreviousWaypointTime = myUnit.ParentScen.Time;
				value.Navigator.PreviousWaypointLatitude = waypoint_0.Latitude;
				value.Navigator.PreviousWaypointLongitude = waypoint_0.Longitude;
				value.Navigator.PreviousWaypointType = waypoint_0.Type;
				Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
				foreach (Waypoint waypoint in plottedCourse)
				{
					if (value.FlightRole == Mission.Flight.FlightElement.LeadElementWingman)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman))
							{
								ArrayExtensions.Add(ref theArray, waypoint.Waypoint_LeadElementWingman);
							}
							break;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_LeadElementWingman))
						{
							ArrayExtensions.Add(ref theArray, waypoint.Waypoint_LeadElementWingman);
						}
					}
					else if (value.FlightRole == Mission.Flight.FlightElement.SecondElement)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing((object)waypoint.Waypoint_SecondElement))
							{
								ArrayExtensions.Add(ref theArray, waypoint.Waypoint_SecondElement);
							}
							break;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_SecondElement))
						{
							ArrayExtensions.Add(ref theArray, waypoint.Waypoint_SecondElement);
						}
					}
					else if (value.FlightRole == Mission.Flight.FlightElement.SecondElementWingman)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman))
							{
								ArrayExtensions.Add(ref theArray, waypoint.Waypoint_SecondElementWingman);
							}
							break;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_SecondElementWingman))
						{
							ArrayExtensions.Add(ref theArray, waypoint.Waypoint_SecondElementWingman);
						}
					}
					else if (value.FlightRole == Mission.Flight.FlightElement.ThirdElement)
					{
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElement))
							{
								ArrayExtensions.Add(ref theArray, waypoint.Waypoint_ThirdElement);
							}
							break;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElement))
						{
							ArrayExtensions.Add(ref theArray, waypoint.Waypoint_ThirdElement);
						}
					}
					else
					{
						if (value.FlightRole != Mission.Flight.FlightElement.ThirdElementWingman)
						{
							continue;
						}
						if (waypoint.FlightFormation != Waypoint.Formation.Split)
						{
							if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman))
							{
								ArrayExtensions.Add(ref theArray, waypoint.Waypoint_ThirdElementWingman);
							}
							break;
						}
						if (!Information.IsNothing((object)waypoint.Waypoint_ThirdElementWingman))
						{
							ArrayExtensions.Add(ref theArray, waypoint.Waypoint_ThirdElementWingman);
						}
					}
				}
				if (theArray.Count() > 0)
				{
					value.Navigator.PlottedCourse = theArray;
					ExtendTimer = 0.0;
					((Aircraft)value).Navigator.HeadToFirstWaypoint(float_0);
					ExtendTimer = 0.0;
				}
				value.AI.EvaluateUnitStatus(0f, ForceFuelStateCheck: false, ForceWeaponStateCheck: false);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 967453452432", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetStrikeMissionOrUnassignedThrottle()
	{
		try
		{
			if (Information.IsNothing((object)method_10().ActiveMissionOrPackage()))
			{
				return;
			}
			ActiveUnit.Throttle throttle = default(ActiveUnit.Throttle);
			if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
			{
				_ = (Strike)myUnit.ActiveMissionOrPackage();
				if (Information.IsNothing((object)method_10().Loadout))
				{
					throttle = ActiveUnit.Throttle.Cruise;
				}
				else
				{
					throttle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationThrottleSetting;
					if (throttle == ActiveUnit.Throttle.FullStop)
					{
						throttle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress;
					}
				}
			}
			method_10().SetThrottle(throttle);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 75753222227785989", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetStrikeMissionOrUnassignedAltitude()
	{
		try
		{
			float num = default(float);
			bool MissionProfileAttackIngressAltitudeTerrainFollowing = default(bool);
			if (!Information.IsNothing((object)method_10().ActiveMissionOrPackage()))
			{
				if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike)
				{
					_ = (Strike)myUnit.ActiveMissionOrPackage();
					if (Information.IsNothing((object)method_10().Loadout))
					{
						if (((Strike)myUnit.ActiveMissionOrPackage()).Type == Strike.StrikeType.Sub_Strike)
						{
							num = 304.80002f;
							MissionProfileAttackIngressAltitudeTerrainFollowing = false;
						}
						else
						{
							Aircraft theAircraft = method_10();
							num = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
						}
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						Aircraft theAircraft = method_10();
						num = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					else
					{
						Aircraft_AI aI = method_10().AI;
						Aircraft theAircraft = method_10();
						num = aI.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
				}
			}
			else if (method_10().AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
			{
				num = 304.80002f;
				MissionProfileAttackIngressAltitudeTerrainFollowing = false;
			}
			myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, MissionProfileAttackIngressAltitudeTerrainFollowing);
			if (!MissionProfileAttackIngressAltitudeTerrainFollowing)
			{
				myUnit.DesiredAltitude = num;
			}
			else
			{
				myUnit.DesiredAltitude_AGL = num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1231231231233", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetPatrolAltitude(bool PursueContact, Aircraft_AirOps._AirOpsCondition theAirOpsCondition)
	{
		try
		{
			if (myUnit.Kinematics.DesiredAltitudeOverride || theAirOpsCondition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				return;
			}
			float theLoadoutMissionAltitude = default(float);
			bool MissionProfileAttackIngressAltitudeTerrainFollowing = default(bool);
			float? theMissionAltitudeOverride = default(float?);
			bool theMissionAltitudeOverride_TerrainFollowing = default(bool);
			Aircraft theAircraft;
			if (Information.IsNothing((object)method_10().ActiveMissionOrPackage()))
			{
				if (Information.IsNothing((object)method_10().Loadout))
				{
					theLoadoutMissionAltitude = 0f;
					MissionProfileAttackIngressAltitudeTerrainFollowing = false;
				}
				else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude > 0f)
				{
					theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude;
					MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
				}
				else if (!method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
				{
					Aircraft_AI aI = method_10().AI;
					theAircraft = method_10();
					theLoadoutMissionAltitude = aI.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
				}
				else
				{
					theAircraft = method_10();
					theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
				}
				theMissionAltitudeOverride = null;
				theMissionAltitudeOverride_TerrainFollowing = false;
			}
			else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				if (method_10().IsOnActivePatrol() && (myUnit.Navigator.IsInsidePatrolArea || PursueContact))
				{
					if (!Information.IsNothing((object)method_10().Loadout))
					{
						if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude > 0f)
						{
							theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude;
							MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
						}
						else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
						{
							theAircraft = method_10();
							theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
						}
						else
						{
							Aircraft_AI aI2 = method_10().AI;
							theAircraft = method_10();
							theLoadoutMissionAltitude = aI2.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
						}
					}
					else
					{
						theLoadoutMissionAltitude = 0f;
						MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					}
					theMissionAltitudeOverride = patrol.StationAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = patrol.StationTerrainFollowing_Aircraft;
				}
				else
				{
					if (Information.IsNothing((object)method_10().Loadout))
					{
						theLoadoutMissionAltitude = 0f;
						MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress > 0f)
					{
						theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						theAircraft = method_10();
						theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					else
					{
						theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					theMissionAltitudeOverride = patrol.TransitAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = patrol.TransitTerrainFollowing_Aircraft;
				}
			}
			else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
			{
				MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
				if (method_10().IsOnActiveMiningMission && (IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_5nm_Buffered, ref miningMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) || PursueContact))
				{
					if (!Information.IsNothing((object)method_10().Loadout))
					{
						if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
						{
							theAircraft = method_10();
							theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
						}
						else
						{
							Aircraft_AI aI3 = method_10().AI;
							theAircraft = method_10();
							theLoadoutMissionAltitude = aI3.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
						}
					}
					else
					{
						theLoadoutMissionAltitude = 0f;
						MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					}
					float? num = myUnit.AI.AdjustAltitudeForMinelaying(theLoadoutMissionAltitude);
					if (num.HasValue)
					{
						float? num2 = num;
						if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() > theLoadoutMissionAltitude) : ((bool?)null)) == true)
						{
							theLoadoutMissionAltitude = num.Value;
						}
					}
					theMissionAltitudeOverride = miningMission.StationAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = miningMission.StationTerrainFollowing_Aircraft;
				}
				else
				{
					if (Information.IsNothing((object)method_10().Loadout))
					{
						theLoadoutMissionAltitude = 0f;
						MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						theAircraft = method_10();
						theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					else
					{
						theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					theMissionAltitudeOverride = miningMission.TransitAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = miningMission.TransitTerrainFollowing_Aircraft;
				}
			}
			else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
				if (method_10().IsOnActiveMineClearingMission && (IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) || PursueContact))
				{
					if (Information.IsNothing((object)method_10().Loadout))
					{
						theLoadoutMissionAltitude = 0f;
						MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude > 0f)
					{
						theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude;
						MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
					}
					else if (!method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						Aircraft_AI aI4 = method_10().AI;
						theAircraft = method_10();
						theLoadoutMissionAltitude = aI4.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					else
					{
						theAircraft = method_10();
						theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					theMissionAltitudeOverride = mineClearingMission.StationAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = mineClearingMission.StationTerrainFollowing_Aircraft;
				}
				else
				{
					if (Information.IsNothing((object)method_10().Loadout))
					{
						theLoadoutMissionAltitude = 0f;
						MissionProfileAttackIngressAltitudeTerrainFollowing = false;
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress > 0f)
					{
						theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
						MissionProfileAttackIngressAltitudeTerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
					}
					else if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						theAircraft = method_10();
						theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					else
					{
						Aircraft_AI aI5 = method_10().AI;
						theAircraft = method_10();
						theLoadoutMissionAltitude = aI5.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref MissionProfileAttackIngressAltitudeTerrainFollowing);
					}
					theMissionAltitudeOverride = mineClearingMission.TransitAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = mineClearingMission.TransitTerrainFollowing_Aircraft;
				}
			}
			theAircraft = method_10();
			SetMissionAltitude(ref theLoadoutMissionAltitude, ref MissionProfileAttackIngressAltitudeTerrainFollowing, ref theMissionAltitudeOverride, ref theMissionAltitudeOverride_TerrainFollowing, ref theAircraft);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 435465666666642314", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetPatrolThrottle(bool PursueContact, Aircraft_AirOps._AirOpsCondition theAirOpsCondition)
	{
		try
		{
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue || theAirOpsCondition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || theAirOpsCondition == Aircraft_AirOps._AirOpsCondition.TransferringCargo)
				{
					return;
				}
				ActiveUnit.Throttle theLoadoutMissionThrottle = default(ActiveUnit.Throttle);
				ActiveUnit.Throttle? theMissionThrottleSetting = default(ActiveUnit.Throttle?);
				if (Information.IsNothing((object)method_10().ActiveMissionOrPackage()))
				{
					if (!Information.IsNothing((object)method_10().Loadout))
					{
						theLoadoutMissionThrottle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationThrottleSetting;
						if (theLoadoutMissionThrottle == ActiveUnit.Throttle.FullStop)
						{
							theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
						}
					}
					else
					{
						theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
					}
					theMissionThrottleSetting = null;
				}
				else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
					if (method_10().IsOnActivePatrol() && (myUnit.Navigator.IsInsidePatrolArea || PursueContact))
					{
						if (Information.IsNothing((object)method_10().Loadout))
						{
							theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
						}
						else
						{
							theLoadoutMissionThrottle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationThrottleSetting;
							if (theLoadoutMissionThrottle == ActiveUnit.Throttle.FullStop)
							{
								theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
							}
						}
						theMissionThrottleSetting = patrol.StationThrottle_Aircraft;
					}
					else
					{
						theLoadoutMissionThrottle = (Information.IsNothing((object)method_10().Loadout) ? ActiveUnit.Throttle.Cruise : method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
						theMissionThrottleSetting = patrol.TransitThrottle_Aircraft;
					}
				}
				else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Mining)
				{
					MiningMission miningMission = (MiningMission)myUnit.ActiveMissionOrPackage();
					if (method_10().IsOnActiveMiningMission && (IsInsideMissionArea(ref miningMission.Area, ref miningMission.Area_5nm_Buffered, ref miningMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) || PursueContact))
					{
						if (!Information.IsNothing((object)method_10().Loadout))
						{
							theLoadoutMissionThrottle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationThrottleSetting;
							if (theLoadoutMissionThrottle == ActiveUnit.Throttle.FullStop)
							{
								theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
							}
						}
						else
						{
							theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
						}
						theMissionThrottleSetting = miningMission.StationThrottle_Aircraft;
					}
					else
					{
						theLoadoutMissionThrottle = (Information.IsNothing((object)method_10().Loadout) ? ActiveUnit.Throttle.Cruise : method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
						theMissionThrottleSetting = miningMission.TransitThrottle_Aircraft;
					}
				}
				else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.MineClearing)
				{
					MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
					if (method_10().IsOnActiveMineClearingMission && (IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) || PursueContact))
					{
						if (Information.IsNothing((object)method_10().Loadout))
						{
							theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
						}
						else
						{
							theLoadoutMissionThrottle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationThrottleSetting;
							if (theLoadoutMissionThrottle == ActiveUnit.Throttle.FullStop)
							{
								theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
							}
						}
						theMissionThrottleSetting = mineClearingMission.StationThrottle_Aircraft;
					}
					else
					{
						theLoadoutMissionThrottle = ((!Information.IsNothing((object)method_10().Loadout)) ? method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress : ActiveUnit.Throttle.Cruise);
						theMissionThrottleSetting = mineClearingMission.TransitThrottle_Aircraft;
					}
				}
				else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support)
				{
					SupportMission obj = (SupportMission)myUnit.ActiveMissionOrPackage();
					theLoadoutMissionThrottle = (Information.IsNothing((object)method_10().Loadout) ? ActiveUnit.Throttle.Cruise : method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
					theMissionThrottleSetting = obj.TransitThrottle_Aircraft;
				}
				else if (method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Cargo)
				{
					CargoMission cargoMission = (CargoMission)myUnit.ActiveMissionOrPackage();
					theMissionThrottleSetting = ((!method_10().IsOnActiveCargoMission || cargoMission.Area.Count <= 0 || (!IsInsideMissionArea(ref cargoMission.Area, ref cargoMission.Area_1nm_Buffered, ref cargoMission.Area_1nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false) && !PursueContact)) ? new ActiveUnit.Throttle?(cargoMission.TransitThrottle_Aircraft) : new ActiveUnit.Throttle?(cargoMission.StationThrottle_Aircraft));
				}
				Aircraft theAircraft = method_10();
				SetMissionThrottle(ref theLoadoutMissionThrottle, ref theMissionThrottleSetting, ref theAircraft);
			}
			else if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
			{
				myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.DesiredSpeed));
			}
			else
			{
				myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value)), myUnit.Kinematics.DesiredSpeedOverride);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 65416541232132", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetInterceptAltitude(Aircraft_AirOps._AirOpsCondition theAirOpsCondition)
	{
		try
		{
			if ((myUnit.Kinematics.DesiredAltitudeOverride && (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) || (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol && (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || !myUnit.AI.IsEscort)) || (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse && (!myUnit.IsGroupWingman() || Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse)))) || theAirOpsCondition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
			{
				return;
			}
			Aircraft_AirOps._AirOpsCondition airOpsCondition = theAirOpsCondition;
			if (airOpsCondition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar || airOpsCondition == Aircraft_AirOps._AirOpsCondition.const_19 || airOpsCondition == Aircraft_AirOps._AirOpsCondition.Dogfight)
			{
				return;
			}
			float theLoadoutMissionAltitude;
			bool Return_theAltitude_TerrainFollowing = default(bool);
			Aircraft theAircraft;
			if (Information.IsNothing((object)method_10().Loadout))
			{
				theLoadoutMissionAltitude = 0f;
			}
			else if (!method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
			{
				theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitude;
				Return_theAltitude_TerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationAltitudeTerrainFollowing;
				if (theLoadoutMissionAltitude == 0f)
				{
					theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).AttackAltitudeIngress;
					Return_theAltitude_TerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).AttackAltitudeIngressTerrainFollowing;
				}
				if (theLoadoutMissionAltitude == 0f)
				{
					theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
					Return_theAltitude_TerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
				}
			}
			else
			{
				theAircraft = method_10();
				theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref Return_theAltitude_TerrainFollowing);
			}
			float? theMissionAltitudeOverride = default(float?);
			bool theMissionAltitudeOverride_TerrainFollowing = default(bool);
			if (!Information.IsNothing((object)method_10().ActiveMissionOrPackage()) && method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
			{
				Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				float? num = null;
				float num2;
				if (!Information.IsNothing((object)method_10().AI.PrimaryTarget))
				{
					Weapon weapon = null;
					Doctrine doctrine = myUnit.Doctrine;
					weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(method_10().AI.PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, doctrine);
					num2 = ((!Information.IsNothing((object)weapon)) ? weapon.get_MaxRangeForThisTarget(myUnit, method_10().AI.PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false) : 0f);
				}
				else
				{
					num2 = 0f;
				}
				patrol = (Patrol)myUnit.ActiveMissionOrPackage();
				num = patrol.AttackDistance_Aircraft;
				float num3 = ((!Information.IsNothing((object)num)) ? (num + num2).Value : ((float)Math.Max(10f + num2, (double)num2 * 1.2)));
				if (myUnit.RangeToUnit_Horiz(method_10().AI.PrimaryTarget) > num3)
				{
					theMissionAltitudeOverride = patrol.TransitAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = patrol.TransitTerrainFollowing_Aircraft;
				}
				else
				{
					theMissionAltitudeOverride = patrol.AttackAltitude_Aircraft;
					theMissionAltitudeOverride_TerrainFollowing = patrol.AttackTerrainFollowing_Aircraft;
				}
			}
			theAircraft = method_10();
			SetMissionAltitude(ref theLoadoutMissionAltitude, ref Return_theAltitude_TerrainFollowing, ref theMissionAltitudeOverride, ref theMissionAltitudeOverride_TerrainFollowing, ref theAircraft);
			if (myUnit.AI.PrimaryTarget.IsAir_Missile_Orbital_Contact && myUnit.AI.PrimaryTarget.AltitudeIsKnown && ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > myUnit.DesiredAltitude)
			{
				if (((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= myUnit.Kinematics.GetMaximumAltitude())
				{
					myUnit.DesiredAltitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
				else
				{
					myUnit.DesiredAltitude = myUnit.Kinematics.GetMaximumAltitude() * 0.9f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 2314352524624", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetInterceptThrottle(float theAltitude, float? theSpeed, bool CanUseAfterburner, Aircraft_AirOps._AirOpsCondition theAirOpsCondition)
	{
		try
		{
			if (myUnit.Kinematics.DesiredSpeedOverride.HasValue && (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()) || (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol && (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike || !myUnit.AI.IsEscort)) || (!myUnit.Navigator.IsOnAutoPlannerPlottedCourse && (!myUnit.IsGroupWingman() || Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || !myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.IsOnAutoPlannerPlottedCourse))))
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
			else
			{
				if (theAirOpsCondition == Aircraft_AirOps._AirOpsCondition.DeployingDippingSonar)
				{
					return;
				}
				if (!Information.IsNothing((object)method_10().ActiveMissionOrPackage()) && method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
				{
					Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
					bool? obj;
					if (Information.IsNothing((object)patrol.AttackThrottle_Aircraft))
					{
						obj = false;
					}
					else
					{
						byte? b = (byte?)patrol.AttackThrottle_Aircraft;
						obj = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0));
					}
					bool? flag = obj;
					if ((flag ?? true) && !Information.IsNothing((object)patrol.AttackDistance_Aircraft) && flag.HasValue)
					{
						float? num = null;
						float num2;
						if (!Information.IsNothing((object)method_10().AI.PrimaryTarget))
						{
							Weapon weapon = null;
							Doctrine doctrine = myUnit.Doctrine;
							weapon = myUnit.Weaponry.MostSuitableWeaponForThisTarget(method_10().AI.PrimaryTarget, CheckIfWithinRange: false, CheckIfWithinAltitude: false, CheckWRA: true, doctrine);
							num2 = ((!Information.IsNothing((object)weapon)) ? weapon.get_MaxRangeForThisTarget(myUnit, method_10().AI.PrimaryTarget, CheckWRA: true, doctrine, ManualFire: false) : 0f);
						}
						else
						{
							num2 = 0f;
						}
						patrol = (Patrol)myUnit.ActiveMissionOrPackage();
						num = patrol.AttackDistance_Aircraft;
						float num3 = (Information.IsNothing((object)num) ? ((float)Math.Max(10f + num2, (double)num2 * 1.2)) : (num + num2).Value);
						if (!(myUnit.RangeToUnit_Horiz(method_10().AI.PrimaryTarget) > num3))
						{
							myUnit.SetThrottle(patrol.AttackThrottle_Aircraft.Value);
							return;
						}
						if (!Information.IsNothing((object)patrol.TransitThrottle_Aircraft))
						{
							byte? b = (byte?)patrol.TransitThrottle_Aircraft;
							if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() != 0)) == true)
							{
								myUnit.SetThrottle(patrol.TransitThrottle_Aircraft.Value);
								return;
							}
						}
					}
				}
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue || (myUnit.IsGroupWingman() && myUnit.get_ParentGroup(UsingMissionPlanner: false).Kinematics.DesiredSpeedOverride.HasValue))
				{
					return;
				}
				bool BingoFuelEndurance;
				if (CanUseAfterburner && myUnit.Kinematics.CanApplyFlankThrottle())
				{
					Aircraft_AI aI = method_10().AI;
					Contact primaryTarget = myUnit.AI.PrimaryTarget;
					float theAltitude2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					float currentHeading = myUnit.CurrentHeading;
					float? safetyMargin = 0f;
					BingoFuelEndurance = true;
					if (aI.CanInterceptTarget(primaryTarget, null, theAltitude2, null, currentHeading, ActiveUnit.Throttle.Flank, safetyMargin, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
						return;
					}
				}
				Aircraft_AI aI2 = method_10().AI;
				Contact primaryTarget2 = myUnit.AI.PrimaryTarget;
				float theAltitude3 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				float currentHeading2 = myUnit.CurrentHeading;
				float? safetyMargin2 = 0f;
				BingoFuelEndurance = true;
				if (aI2.CanInterceptTarget(primaryTarget2, null, theAltitude3, null, currentHeading2, ActiveUnit.Throttle.Full, safetyMargin2, IgnoreMotionVectors: false, TotalRemainingEndurance: false, ref BingoFuelEndurance))
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100390", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal ActiveUnit.Throttle GetBingoFuelThrottle()
	{
		ActiveUnit.Throttle result;
		try
		{
			ActiveUnit.Throttle? throttle = default(ActiveUnit.Throttle?);
			if (!Information.IsNothing((object)method_10().ActiveMissionOrPackage()))
			{
				Mission mission = method_10().ActiveMissionOrPackage();
				Aircraft theAircraft = method_10();
				throttle = mission.DetermineMissionEgressThrottle(ref theAircraft);
			}
			byte? b;
			if (!Information.IsNothing((object)method_10().Loadout))
			{
				if (!Information.IsNothing((object)throttle))
				{
					b = (byte?)throttle;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
					{
						goto IL_0135;
					}
				}
				throttle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingEgress;
			}
			else
			{
				int value;
				if (Information.IsNothing((object)throttle))
				{
					value = 2;
				}
				else
				{
					b = (byte?)throttle;
					if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
					{
						goto IL_0135;
					}
					value = 2;
				}
				throttle = (ActiveUnit.Throttle)value;
			}
			goto IL_0135;
			IL_0135:
			if (Information.IsNothing((object)throttle))
			{
				throttle = ActiveUnit.Throttle.Cruise;
			}
			b = (byte?)throttle;
			byte maxPossibleThrottleSetting = (byte)method_10().MaxPossibleThrottleSetting;
			if (((!b.HasValue) ? ((bool?)null) : new bool?((uint)b.GetValueOrDefault() > (uint)maxPossibleThrottleSetting)) == true)
			{
				throttle = method_10().MaxPossibleThrottleSetting;
			}
			result = throttle.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101376", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num = 2;
			}
			else
			{
				num = 2;
			}
			result = (ActiveUnit.Throttle)num;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float GetBingoFuelAltitude(ref bool theAltitude_TerrainFollowing)
	{
		float result;
		try
		{
			float? num = default(float?);
			if (method_10().ActiveMissionOrPackage() != null)
			{
				Mission mission = method_10().ActiveMissionOrPackage();
				Aircraft theAircraft = method_10();
				num = mission.DetermineMissionEgressAltitude(ref theAircraft, ref theAltitude_TerrainFollowing);
			}
			if (method_10().Loadout != null && method_10().Loadout.get_MissionProfile(method_10().ParentScen) != null)
			{
				if (!num.HasValue)
				{
					if (method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
					{
						Aircraft theAircraft = method_10();
						num = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref theAltitude_TerrainFollowing);
					}
					else
					{
						num = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeEgress;
						theAltitude_TerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeEgressTerrainFollowing;
					}
				}
				if (!num.HasValue)
				{
					Aircraft theAircraft = method_10();
					num = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref theAltitude_TerrainFollowing);
				}
			}
			else if (!num.HasValue)
			{
				Aircraft theAircraft = method_10();
				num = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref theAltitude_TerrainFollowing);
			}
			float maximumAltitude = method_10().Kinematics.GetMaximumAltitude();
			if (num.HasValue && num.Value > maximumAltitude)
			{
				num = maximumAltitude;
			}
			result = num.Value;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101377", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void FollowSupportMissionCourse(float elapsedTime, bool IsInTransit)
	{
		try
		{
			if (myUnit.ActiveMissionOrPackage() == null || myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Support)
			{
				return;
			}
			base.FollowSupportMissionCourse(elapsedTime, IsInTransit);
			SupportMission supportMission = (SupportMission)myUnit.ActiveMissionOrPackage();
			Aircraft theAircraft;
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
			{
				ActiveUnit.Throttle theLoadoutMissionThrottle;
				ActiveUnit.Throttle? theMissionThrottleSetting;
				if (!IsInTransit)
				{
					if (method_10().Loadout == null)
					{
						theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
					}
					else
					{
						theLoadoutMissionThrottle = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).StationThrottleSetting;
						if (theLoadoutMissionThrottle == ActiveUnit.Throttle.FullStop)
						{
							theLoadoutMissionThrottle = ActiveUnit.Throttle.Loiter;
						}
					}
					theMissionThrottleSetting = supportMission.StationThrottle_Aircraft;
				}
				else
				{
					theLoadoutMissionThrottle = ((method_10().Loadout == null) ? ActiveUnit.Throttle.Cruise : method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseThrottleSettingIngress);
					theMissionThrottleSetting = supportMission.TransitThrottle_Aircraft;
				}
				theAircraft = method_10();
				SetMissionThrottle(ref theLoadoutMissionThrottle, ref theMissionThrottleSetting, ref theAircraft);
			}
			if (myUnit.Kinematics.DesiredAltitudeOverride)
			{
				return;
			}
			float theLoadoutMissionAltitude;
			bool Return_theAltitude_TerrainFollowing = default(bool);
			float? theMissionAltitudeOverride;
			bool theMissionAltitudeOverride_TerrainFollowing;
			if (IsInTransit)
			{
				if (method_10().Loadout == null)
				{
					theLoadoutMissionAltitude = 0f;
					Return_theAltitude_TerrainFollowing = false;
				}
				else if (!method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
				{
					theLoadoutMissionAltitude = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngress;
					Return_theAltitude_TerrainFollowing = method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAltitudeIngressTerrainFollowing;
				}
				else
				{
					theAircraft = method_10();
					theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, ref Return_theAltitude_TerrainFollowing);
				}
				theMissionAltitudeOverride = supportMission.TransitAltitude_Aircraft;
				theMissionAltitudeOverride_TerrainFollowing = supportMission.TransitTerrainFollowing_Aircraft;
			}
			else
			{
				if (method_10().Loadout == null)
				{
					theLoadoutMissionAltitude = 0f;
					Return_theAltitude_TerrainFollowing = false;
				}
				else if (!method_10().Loadout.get_MissionProfile(myUnit.ParentScen).CruiseAtOptimumAltitude)
				{
					Aircraft_AI aI = method_10().AI;
					theAircraft = method_10();
					theLoadoutMissionAltitude = aI.MostRealisticAttackAltitude(ref theAircraft, ActiveUnit.Throttle.Cruise, LoadoutAltitudesOnly: true, ref Return_theAltitude_TerrainFollowing);
				}
				else
				{
					theAircraft = method_10();
					theLoadoutMissionAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft, ActiveUnit.Throttle.Loiter, ref Return_theAltitude_TerrainFollowing);
				}
				theMissionAltitudeOverride = supportMission.StationAltitude_Aircraft;
				theMissionAltitudeOverride_TerrainFollowing = supportMission.StationTerrainFollowing_Aircraft;
			}
			theAircraft = method_10();
			SetMissionAltitude(ref theLoadoutMissionAltitude, ref Return_theAltitude_TerrainFollowing, ref theMissionAltitudeOverride, ref theMissionAltitudeOverride_TerrainFollowing, ref theAircraft);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101378", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetMissionAltitude(ref float theLoadoutMissionAltitude, ref bool theLoadoutMissionAltitude_TerrainFollowing, ref float? theMissionAltitudeOverride, ref bool theMissionAltitudeOverride_TerrainFollowing, ref Aircraft theAircraft)
	{
		try
		{
			if (myUnit.Kinematics.DesiredAltitudeOverride || theAircraft.IsUsingDippingSonar())
			{
				return;
			}
			if (!theMissionAltitudeOverride.HasValue)
			{
				if (Information.IsNothing((object)theAircraft.Loadout))
				{
					ActiveUnit activeUnit = myUnit;
					Aircraft theAircraft2 = method_10();
					ActiveUnit.Throttle throttleSetting = myUnit.ThrottleSetting;
					ActiveUnit activeUnit2;
					ActiveUnit theAU;
					bool Return_theAltitude_TerrainFollowing = (activeUnit2 = myUnit).get_DesiredAltitude_UseTerrainFollowing(theAU = myUnit);
					float desiredAltitude = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft2, throttleSetting, ref Return_theAltitude_TerrainFollowing);
					activeUnit2.set_DesiredAltitude_UseTerrainFollowing(theAU, Return_theAltitude_TerrainFollowing);
					activeUnit.DesiredAltitude = desiredAltitude;
				}
				else if (theLoadoutMissionAltitude > 0f)
				{
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, theLoadoutMissionAltitude_TerrainFollowing);
					if (!theLoadoutMissionAltitude_TerrainFollowing)
					{
						theAircraft.DesiredAltitude = theLoadoutMissionAltitude;
					}
					else
					{
						theAircraft.DesiredAltitude_AGL = theLoadoutMissionAltitude;
					}
				}
				else
				{
					Aircraft obj = theAircraft;
					Aircraft theAircraft2 = method_10();
					ActiveUnit.Throttle throttleSetting2 = myUnit.ThrottleSetting;
					ActiveUnit theAU;
					ActiveUnit activeUnit2;
					bool Return_theAltitude_TerrainFollowing = (theAU = myUnit).get_DesiredAltitude_UseTerrainFollowing(activeUnit2 = myUnit);
					float desiredAltitude2 = Aircraft_AI.MostRealisticOptimumAltitude(ref theAircraft2, throttleSetting2, ref Return_theAltitude_TerrainFollowing);
					theAU.set_DesiredAltitude_UseTerrainFollowing(activeUnit2, Return_theAltitude_TerrainFollowing);
					obj.DesiredAltitude = desiredAltitude2;
				}
			}
			else
			{
				myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, theMissionAltitudeOverride_TerrainFollowing);
				if (!theMissionAltitudeOverride_TerrainFollowing)
				{
					myUnit.DesiredAltitude = theMissionAltitudeOverride.Value;
				}
				else
				{
					myUnit.DesiredAltitude_AGL = theMissionAltitudeOverride.Value;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101379", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void SetMissionThrottle(ref ActiveUnit.Throttle theLoadoutMissionThrottle, ref ActiveUnit.Throttle? theMissionThrottleSetting, ref Aircraft theAircraft)
	{
		try
		{
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
			else
			{
				if (myUnit.Kinematics.DesiredSpeedOverride.HasValue || theAircraft.IsUsingDippingSonar())
				{
					return;
				}
				if (theMissionThrottleSetting.HasValue)
				{
					theAircraft.SetThrottle(theMissionThrottleSetting.Value);
				}
				else if (theAircraft.Loadout == null)
				{
					if (myUnit.ThrottleSetting < ActiveUnit.Throttle.Cruise)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
					}
					float num = theAircraft.Kinematics.GetMaximumSpeed(theAircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theAircraft.ThrottleSetting, ValidateAndFixAltitude: false);
					if (myUnit.CurrentSpeed < num)
					{
						myUnit.DesiredSpeed = num;
					}
				}
				else
				{
					theAircraft.SetThrottle(theLoadoutMissionThrottle);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101380", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool CurrentFlightHasStandoffWeaponFiringPoint()
	{
		if (!base.HasFlightPlan)
		{
			return false;
		}
		return base.get_Flight(HierarchySearch: true).FlightPlan.Where([SpecialName] (Waypoint theFP) => theFP.Type == Waypoint.WaypointType.WeaponLaunch).FirstOrDefault() != null;
	}

	public bool HasReachedWeaponReleasePoint(bool fromUI)
	{
		_Closure$__39-0 arg = default(_Closure$__39-0);
		_Closure$__39-0 CS$<>8__locals15 = new _Closure$__39-0(arg);
		bool result;
		if (base.HasFlightPlan)
		{
			if (fromUI)
			{
				result = DistanceFromStandioffWeaponFiringPoint() < 6.0;
			}
			else
			{
				if (method_10().IsGroupWingman())
				{
					if (myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos != null)
					{
						List<WeaponSalvo> list = new List<WeaponSalvo>(myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvos);
						foreach (WeaponSalvo item in list)
						{
							if (item == null)
							{
								continue;
							}
							WeaponSalvo.Shooter[] shootersList = item.ShootersList;
							for (int i = 0; i < shootersList.Length; i = checked(i + 1))
							{
								if (Operators.CompareString(shootersList[i]?.ShooterObjectID, myUnit.get_ParentGroup(UsingMissionPlanner: false)?.GroupLead?.ObjectID, false) != 0)
								{
									continue;
								}
								if (((Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).Navigator.CurrentFlightHasStandoffWeaponFiringPoint())
								{
									if (!(((Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).Navigator.DistanceFromStandioffWeaponFiringPoint() < 3.0) || !(DistanceFromStandioffWeaponFiringPoint() < 6.0))
									{
										continue;
									}
									result = true;
								}
								else
								{
									if (!(((Aircraft)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead).Navigator.DistanceFromIPWeaponFiringPoint() < 3.0) || DistanceFromStandioffWeaponFiringPoint() >= 6.0)
									{
										continue;
									}
									result = true;
								}
								goto IL_05f3;
							}
						}
					}
					if (myUnit.IsOnActiveStrike)
					{
						Strike strike = (Strike)myUnit.AssignedMissionOrPackage();
						if ((strike.AttackMethod == Mission._AttackMethod.None || strike.AttackMethod == Mission._AttackMethod.Formation_SingleAim) && ((Aircraft)((ActiveUnit)method_10()).get_ParentGroup(UsingMissionPlanner: false).GroupLead).Navigator.HasReachedWeaponReleasePoint(fromUI: false) && !method_10().AI.CheckSeparationAndRejoin(method_10().ParentScen.GameResolution))
						{
							result = true;
							goto IL_05f3;
						}
					}
				}
				CS$<>8__locals15.$VB$Local_myPlottedCourse = PlottedCourse;
				if (DistanceFromStandioffWeaponFiringPoint() < 3.0 && HasPlottedCourse() && CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Type == Waypoint.WaypointType.WeaponLaunch)
				{
					int num;
					if (!CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Time_Zulu.HasValue)
					{
						num = 1;
					}
					else
					{
						if (PreviousWaypoint != null && (PreviousWaypoint.Time_Zulu.Value - myUnit.ParentScen.Time).TotalSeconds > 0.0)
						{
							int num2;
							if (myUnit.get_UnitSide(SetSideOnly: false) != null)
							{
								if (!myUnit.get_UnitSide(SetSideOnly: false).IsHumanControlled)
								{
									num2 = 0;
								}
								else
								{
									Notification_Bark.Create_UnitBehaviour(myUnit, "reached weapon release point too early");
									num2 = 0;
								}
							}
							else
							{
								num2 = 0;
							}
							result = (byte)num2 != 0;
							goto IL_05f3;
						}
						num = 1;
					}
					result = (byte)num != 0;
				}
				else
				{
					if (CS$<>8__locals15.$VB$Local_myPlottedCourse == null)
					{
						goto IL_05eb;
					}
					try
					{
						Waypoint waypoint;
						if (CS$<>8__locals15.$VB$Local_myPlottedCourse.Length > 0 && CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Type == Waypoint.WaypointType.Target)
						{
							result = true;
						}
						else
						{
							waypoint = null;
							if (CS$<>8__locals15.$VB$Local_myPlottedCourse == null || (CS$<>8__locals15.$VB$Local_myPlottedCourse.Count() == 0 && myUnit.IsGroupMember()))
							{
								Waypoint[] plottedCourse = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Navigator.PlottedCourse;
								if (plottedCourse != null && plottedCourse.Count() > 0)
								{
									waypoint = base.get_Flight(HierarchySearch: true).FlightPlan.Where([SpecialName] (Waypoint theFP) =>
									{
										string objectID = theFP.ObjectID;
										Group obj = myUnit.get_ParentGroup(UsingMissionPlanner: false);
										return Operators.CompareString(objectID, (obj == null) ? null : obj.GroupLead.Navigator.PlottedCourse[0].ObjectID, false) == 0;
									}).FirstOrDefault();
								}
								goto IL_0414;
							}
							if (CS$<>8__locals15.$VB$Local_myPlottedCourse.Count() > 0)
							{
								waypoint = base.get_Flight(HierarchySearch: true).FlightPlan.Where([SpecialName] (Waypoint theFP) => Operators.CompareString(theFP.ObjectID, CS$<>8__locals15.$VB$Local_myPlottedCourse[0].ObjectID, false) == 0).FirstOrDefault();
								goto IL_0414;
							}
							result = false;
						}
						goto end_IL_0340;
						IL_05d3:
						result = false;
						goto end_IL_0340;
						IL_0414:
						Waypoint[] flightPlan = base.get_Flight(HierarchySearch: true).FlightPlan;
						Waypoint waypoint3 = default(Waypoint);
						foreach (Waypoint waypoint2 in flightPlan)
						{
							if (waypoint2.Type == Waypoint.WaypointType.WeaponLaunch || waypoint2.Type == Waypoint.WaypointType.Target)
							{
								waypoint3 = waypoint2;
								break;
							}
						}
						Contact primaryTarget = myUnit.AI.PrimaryTarget;
						if (waypoint3 == null || CS$<>8__locals15.$VB$Local_myPlottedCourse.Length <= 0 || CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Type != Waypoint.WaypointType.WeaponLaunch)
						{
							goto IL_04c8;
						}
						if (primaryTarget != null)
						{
							Geopoint_Struct Point = myUnit.Location;
							Geopoint_Struct Point2 = waypoint3.ToGeopoint_Struct();
							if (!(Math2.CalcDist(ref Point, ref Point2) < 3f))
							{
								goto IL_04c8;
							}
							result = true;
						}
						else
						{
							result = false;
						}
						goto end_IL_0340;
						IL_04c8:
						if (waypoint == null || waypoint3 == null)
						{
							goto IL_05eb;
						}
						int num4 = Array.IndexOf(base.get_Flight(HierarchySearch: true).FlightPlan, waypoint3);
						int num5 = Array.IndexOf(base.get_Flight(HierarchySearch: true).FlightPlan, waypoint);
						if (primaryTarget == null)
						{
							result = false;
						}
						else
						{
							if (num5 <= num4 && (num5 != num4 || CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Type != Waypoint.WaypointType.WeaponLaunch))
							{
								goto IL_05eb;
							}
							float num6 = Math2.CalcDist(waypoint3.Latitude, waypoint3.Longitude, ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
							if (!(Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) < num6))
							{
								goto IL_05d3;
							}
							if (num5 == num4)
							{
								float num7 = Module_Unit.BearingToPoint_Relative(myUnit, CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Latitude, CS$<>8__locals15.$VB$Local_myPlottedCourse[0].Longitude, GlobalVariables.ObjectTrue);
								if (!(num7 > 150f) || !(num7 < 240f))
								{
									goto IL_05d3;
								}
								result = true;
							}
							else
							{
								result = true;
							}
						}
						end_IL_0340:;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						result = false;
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		else
		{
			result = false;
		}
		goto IL_05f3;
		IL_05eb:
		result = false;
		goto IL_05f3;
		IL_05f3:
		return result;
	}

	public double DistanceFromStandioffWeaponFiringPoint()
	{
		Waypoint waypoint = base.get_Flight(HierarchySearch: true).RetrieveWaypointBasedOnACRole(myUnit.FlightRole, Waypoint.WaypointType.WeaponLaunch);
		if (waypoint == null)
		{
			return double.MaxValue;
		}
		return Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude);
	}

	public double DistanceFromIPWeaponFiringPoint()
	{
		Waypoint waypoint = base.get_Flight(HierarchySearch: true)?.RetrieveWaypointBasedOnACRole(myUnit.FlightRole, Waypoint.WaypointType.InitialPoint);
		if (waypoint != null)
		{
			return Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude);
		}
		return double.MaxValue;
	}

	public bool HasReachedLandingAssemblyPoint(ActiveUnit LandingDestination)
	{
		Waypoint[] localPlottedCourse = PlottedCourse;
		CleanPlottedCourse(ref localPlottedCourse);
		bool? flag2;
		bool? flag = (flag2 = ((localPlottedCourse != null) ? new bool?(localPlottedCourse.Count() > 0) : ((bool?)null)));
		bool? obj;
		if (flag.HasValue && flag2 != true)
		{
			obj = false;
		}
		else
		{
			Waypoint? waypoint = localPlottedCourse.FirstOrDefault();
			bool? flag3;
			flag = (flag3 = ((waypoint != null) ? new bool?(waypoint.Category == Waypoint.WaypointCategory.FlightPlan) : ((bool?)null)));
			obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) & flag2));
		}
		bool? flag4 = obj;
		if (flag4 ?? true)
		{
			Waypoint? waypoint2 = localPlottedCourse.FirstOrDefault();
			if (waypoint2 != null && waypoint2.Type != Waypoint.WaypointType.LandingMarshal && flag4.HasValue)
			{
				return false;
			}
		}
		if (LandingDestination != null)
		{
			return DistanceFromLandingAssemblyPoint(LandingDestination) < 3.0;
		}
		return false;
	}

	public double DistanceFromLandingAssemblyPoint(ActiveUnit LandingDestination)
	{
		if (method_10().CanLandVertically)
		{
			return Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), LandingDestination.get_Latitude((GlobalVariables.BooleanObject)null), LandingDestination.get_Longitude((GlobalVariables.BooleanObject)null));
		}
		Geopoint_Struct landingQueueAssemblyPoint = LandingDestination.AirOps.LandingQueueAssemblyPoint;
		return Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
	}

	public bool HeadToDesiredPoint_AccountForPathfinderIfInGroup(float elapsedTime, double DesiredLat, double DesiredLon)
	{
		Aircraft aircraft = method_10();
		bool flag;
		if (flag = myUnit.IsGroupWingman())
		{
			aircraft = (Aircraft)((ActiveUnit)method_10()).get_ParentGroup(UsingMissionPlanner: false).GroupLead;
		}
		if (!aircraft.Navigator.PathFindingInProgress)
		{
			Aircraft theUnit = aircraft;
			Exception ThrownError = null;
			if (!Pathfinding.UnitOrFlightPlanHasPFRequestInQueue(theUnit, null, ref ThrownError))
			{
				if (!aircraft.Navigator.HasPathfindingPlottedCourse)
				{
					if (aircraft.Navigator.bool_0 && !myUnit.IsGroupWingman())
					{
						bool num = ((ActiveUnit)aircraft).IsRTB || aircraft.AirOps.Condition == Aircraft_AirOps._AirOpsCondition.RTB;
						float num2 = 0f;
						float num3 = 0.15f;
						bool flag2 = false;
						float? num4 = null;
						if (num)
						{
							num2 = num3;
							flag2 = true;
							num4 = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
						}
						ActiveUnit_Navigator navigator = myUnit.Navigator;
						double startLat = method_10().get_Latitude((GlobalVariables.BooleanObject)null);
						double startLon = method_10().get_Longitude((GlobalVariables.BooleanObject)null);
						float proximityThreshold_Deg = num2;
						bool usePathfindingBufferDistance = flag2;
						float? samplingInterval_Deg = num4;
						int ReasonForInterrupt = 0;
						GeoPoint InterruptLocation = null;
						if (navigator.PathLineIsInterrupted(startLat, startLon, DesiredLat, DesiredLon, RunInParallel: true, proximityThreshold_Deg, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, usePathfindingBufferDistance, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
						{
							myUnit.Navigator.TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, num3, DesiredLat, DesiredLon, myUnit.ParentScen, ManouverTowardsTarget: false);
							return true;
						}
					}
					bool result = default(bool);
					return result;
				}
				int result2;
				if (!flag)
				{
					result2 = 1;
				}
				else
				{
					method_10().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
					result2 = 1;
				}
				return (byte)result2 != 0;
			}
		}
		int result3;
		if (flag)
		{
			method_10().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
			result3 = 1;
		}
		else
		{
			result3 = 1;
		}
		return (byte)result3 != 0;
	}

	public void HeadToLandingAssemblyPoint(float elapsedTime, ActiveUnit LandingDestination, float theSpeed, float theAltitude, ref bool useTerrainFollowing)
	{
		if (LandingDestination == null || LandingDestination.AirOps == null)
		{
			return;
		}
		try
		{
			Geopoint_Struct landingQueueAssemblyPoint = default(Geopoint_Struct);
			if (HasPlottedCourse() && method_10().AI.FollowingRTB_PlottedCourse() && ((PlottedCourse[0].Type != Waypoint.WaypointType.LandingMarshal) & (PlottedCourse[0].Type != Waypoint.WaypointType.Land)))
			{
				landingQueueAssemblyPoint.Latitude = PlottedCourse[0].Latitude;
				landingQueueAssemblyPoint.Longitude = PlottedCourse[0].Longitude;
				FollowPlottedCourse(elapsedTime);
			}
			else if (!method_10().CanLandVertically)
			{
				landingQueueAssemblyPoint = LandingDestination.AirOps.LandingQueueAssemblyPoint;
			}
			else
			{
				landingQueueAssemblyPoint.Latitude = LandingDestination.get_Latitude((GlobalVariables.BooleanObject)null);
				landingQueueAssemblyPoint.Longitude = LandingDestination.get_Longitude((GlobalVariables.BooleanObject)null);
			}
			myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude));
			Waypoint theWaypoint = null;
			ExtendIfNecessary(elapsedTime, ref theWaypoint, landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude, 0f, 0f, myUnit.Kinematics.TurnRate());
			HeadToDesiredPoint_AccountForPathfinderIfInGroup(elapsedTime, landingQueueAssemblyPoint.Latitude, landingQueueAssemblyPoint.Longitude);
			myUnit.DesiredSpeed = theSpeed;
			myUnit.SetThrottle(myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)));
			myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, useTerrainFollowing);
			if (useTerrainFollowing)
			{
				myUnit.DesiredAltitude_AGL = theAltitude;
			}
			else
			{
				myUnit.DesiredAltitude = theAltitude;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100464", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void EgressToRejoinPoint(float elapsedTime, bool ForceObjectiveWaypointRemoval)
	{
		try
		{
			if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				return;
			}
			if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !myUnit.AI.IsEscort)
			{
				byte? b = (byte?)myUnit.Doctrine.get_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false);
				bool? flag = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0));
				if (((!flag) ?? flag) == true)
				{
					myUnit.Doctrine.set_IgnorePlottedCourse(myUnit.ParentScen, MultipleUnits: false, (bool?)null, ViaDoctrineForm: false, ViaRightColumn: false, (Doctrine._UseIgnorePlottedCourse?)Doctrine._UseIgnorePlottedCourse.No);
				}
			}
			if (method_10().IsGroupWingman() && (!method_10().IsGroupWingman() || !method_10().Navigator.HasPlottedCourse()))
			{
				if (!method_10().Navigator.HasPlottedCourse())
				{
					method_10().Navigator.HeadToFormationStationOrFollowSecondaryFlightPlan(elapsedTime);
				}
				return;
			}
			List<Waypoint> WaypointList = PlottedCourse.ToList();
			EgressToRejoinPoint_RemoveWaypoints(ref WaypointList, ForceObjectiveWaypointRemoval, IsBingoCheck: false);
			method_10().AirOps.SwitchToNearestWaypoint(ref WaypointList, ForceObjectiveWaypointRemoval, IsBingoCheck: false);
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
			ex2?.Data.Add("Error at 100465", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void EgressToRejoinPoint_RemoveWaypoints(ref List<Waypoint> WaypointList, bool ForceObjectiveWaypointRemoval, bool IsBingoCheck)
	{
		try
		{
			List<Waypoint> list = new List<Waypoint>();
			if (Information.IsNothing((object)WaypointList) || WaypointList.Count <= 1)
			{
				return;
			}
			if (method_10().Navigator.IsOnAutoPlannerPlottedCourse_HasObjectiveWaypoints)
			{
				int num = WaypointList.Count - 1;
				Contact primaryTarget = default(Contact);
				for (int i = 0; i <= num; i++)
				{
					Waypoint theWaypoint = WaypointList[i];
					if (theWaypoint.Type == Waypoint.WaypointType.PathfindingPoint)
					{
						list.Add(theWaypoint);
						continue;
					}
					if (theWaypoint.Type == Waypoint.WaypointType.PatrolStation)
					{
						list.Add(theWaypoint);
						continue;
					}
					if (theWaypoint.Type != Waypoint.WaypointType.Split && theWaypoint.Type != Waypoint.WaypointType.InitialPoint && theWaypoint.Type != Waypoint.WaypointType.WeaponLaunch && theWaypoint.Type != Waypoint.WaypointType.Target && theWaypoint.Type != Waypoint.WaypointType.WeaponTarget && theWaypoint.Type != Waypoint.WaypointType.StrikeIngress && theWaypoint.Type != Waypoint.WaypointType.TurningPoint && theWaypoint.Type != Waypoint.WaypointType.Refuel && !theWaypoint.IsStationWaypoint() && !theWaypoint.IsHoldOrAssembleWaypoint())
					{
						if (ForceObjectiveWaypointRemoval)
						{
							if (!IsBingoCheck)
							{
								ApplyWaypointSpeedAltToUnit(theWaypoint);
								ApplyWaypointDoctrineToUnit(theWaypoint);
								AdjustTankerMustFollowMe_NumberOfWaypoints(ref theWaypoint);
							}
							if (!list.Contains(theWaypoint))
							{
								list.Add(theWaypoint);
							}
						}
					}
					else
					{
						if (!IsBingoCheck)
						{
							ApplyWaypointSpeedAltToUnit(theWaypoint);
							ApplyWaypointDoctrineToUnit(theWaypoint);
							AdjustTankerMustFollowMe_NumberOfWaypoints(ref theWaypoint);
						}
						if (!list.Contains(theWaypoint))
						{
							list.Add(theWaypoint);
						}
					}
					if (theWaypoint.IsStationEndWaypoint())
					{
						Mission mission = method_10().AssignedMissionOrPackage();
						if (mission != null && mission.MissionClass == Mission._MissionClass.Patrol)
						{
							break;
						}
					}
					if (theWaypoint.Type != Waypoint.WaypointType.Target && theWaypoint.Type != Waypoint.WaypointType.WeaponTarget)
					{
						continue;
					}
					float num2 = 0f;
					float num3 = ((!Information.IsNothing((object)method_10().AI.PrimaryTarget)) ? Math2.CalcDist(method_10().get_Latitude((GlobalVariables.BooleanObject)null), method_10().get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)method_10().AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)method_10().AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) : Math2.CalcDist(method_10().get_Latitude((GlobalVariables.BooleanObject)null), method_10().get_Longitude((GlobalVariables.BooleanObject)null), theWaypoint.Latitude, theWaypoint.Longitude));
					if (!IsBingoCheck)
					{
						foreach (ActiveUnit value in method_10().ParentScen.ActiveUnits.Values)
						{
							if (value == null || !value.IsWeapon)
							{
								continue;
							}
							Weapon weapon = (Weapon)value;
							if (weapon.FiringParent == method_10() && !Information.IsNothing((object)weapon.AI.PrimaryTarget) && (weapon.AI.PrimaryTarget.IsShipContact || weapon.AI.PrimaryTarget.IsGroundContact))
							{
								float num4 = Math2.CalcDist(method_10().get_Latitude((GlobalVariables.BooleanObject)null), method_10().get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)weapon.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
								if (!(num4 <= num2))
								{
									num2 = num4;
									primaryTarget = weapon.AI.PrimaryTarget;
									break;
								}
							}
						}
					}
					else
					{
						num2 = num3;
					}
					if ((!(num2 > 0f) || Information.IsNothing((object)primaryTarget)) && !IsBingoCheck)
					{
						break;
					}
					ActiveUnit actualDestinationHost = method_10().AirOps.ActualDestinationHost;
					float num5 = ((!Information.IsNothing((object)actualDestinationHost)) ? Math2.CalcDist(method_10().get_Latitude((GlobalVariables.BooleanObject)null), method_10().get_Longitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null)) : 0f);
					int num6 = WaypointList.Count - 1;
					for (int j = 0; j <= num6; j++)
					{
						Waypoint theWaypoint2 = WaypointList[j];
						if (list.Contains(theWaypoint2) || (theWaypoint2.Type != Waypoint.WaypointType.StrikeEgress && theWaypoint2.Type != Waypoint.WaypointType.TurningPoint && theWaypoint2.Type != Waypoint.WaypointType.Refuel))
						{
							continue;
						}
						float num7 = Math2.CalcDist(method_10().get_Latitude((GlobalVariables.BooleanObject)null), method_10().get_Longitude((GlobalVariables.BooleanObject)null), theWaypoint2.Latitude, theWaypoint2.Longitude);
						float num8 = (Information.IsNothing((object)primaryTarget) ? Math2.CalcDist(theWaypoint2.Latitude, theWaypoint2.Longitude, theWaypoint.Latitude, theWaypoint.Longitude) : Math2.CalcDist(theWaypoint2.Latitude, theWaypoint2.Longitude, ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
						if (num8 < num2 && num7 < num2 + 10f)
						{
							if (!IsBingoCheck)
							{
								ApplyWaypointSpeedAltToUnit(theWaypoint2);
								ApplyWaypointDoctrineToUnit(theWaypoint2);
								AdjustTankerMustFollowMe_NumberOfWaypoints(ref theWaypoint2);
							}
							if (!list.Contains(theWaypoint2))
							{
								list.Add(theWaypoint2);
							}
							continue;
						}
						float num9 = ((!Information.IsNothing((object)myUnit.AI.PrimaryTarget)) ? Math2.CalcDist(theWaypoint2.Latitude, theWaypoint2.Longitude, ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) : 0f);
						if (num9 < num3 && num7 < num3 + 10f)
						{
							if (!IsBingoCheck)
							{
								ApplyWaypointSpeedAltToUnit(theWaypoint2);
								ApplyWaypointDoctrineToUnit(theWaypoint2);
								AdjustTankerMustFollowMe_NumberOfWaypoints(ref theWaypoint2);
							}
							if (!list.Contains(theWaypoint2))
							{
								list.Add(theWaypoint2);
							}
							continue;
						}
						if (IsBingoCheck || Information.IsNothing((object)actualDestinationHost))
						{
							break;
						}
						float num10 = Math2.CalcDist(theWaypoint2.Latitude, theWaypoint2.Longitude, actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null));
						if (!(num7 < num10) || !(num5 < num10 + 10f))
						{
							break;
						}
						if (!IsBingoCheck)
						{
							ApplyWaypointSpeedAltToUnit(theWaypoint2);
							ApplyWaypointDoctrineToUnit(theWaypoint2);
							AdjustTankerMustFollowMe_NumberOfWaypoints(ref theWaypoint2);
						}
						if (!list.Contains(theWaypoint2))
						{
							list.Add(theWaypoint2);
						}
					}
					break;
				}
				if (!IsBingoCheck)
				{
					{
						foreach (Waypoint item in list)
						{
							WaypointList.Remove(item);
							ApplyWaypointSpeedAltToUnit(item);
							ApplyWaypointDoctrineToUnit(item);
							RemoveWaypoint_Soft(item, RemoveWingmanWaypoints: false);
						}
						return;
					}
				}
				{
					foreach (Waypoint item2 in list)
					{
						WaypointList.Remove(item2);
					}
					return;
				}
			}
			if (!method_10().Navigator.IsOnAutoPlannerPlottedCourse || (!Information.IsNothing((object)method_10().ActiveMissionOrPackage()) && method_10().ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Strike && !method_10().AI.IsEscort))
			{
				return;
			}
			Waypoint waypoint = null;
			Waypoint waypoint2 = null;
			float num11 = 0f;
			float num12 = 0f;
			int count = WaypointList.Count;
			Waypoint waypoint3 = WaypointList[count - 1];
			for (int k = count - 1; k >= 0; k += -1)
			{
				Waypoint theWaypoint = WaypointList[k];
				if (theWaypoint.Type == Waypoint.WaypointType.PathfindingPoint)
				{
					list.Add(theWaypoint);
					continue;
				}
				if (theWaypoint.Type == Waypoint.WaypointType.Land)
				{
					waypoint = theWaypoint;
					continue;
				}
				if (theWaypoint.Type == Waypoint.WaypointType.LandingMarshal)
				{
					waypoint = theWaypoint;
					waypoint3 = theWaypoint;
					continue;
				}
				waypoint2 = ((k <= 0) ? new Waypoint(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.MissionPlanner, Waypoint.WaypointCategory.FlightPlan) : WaypointList[k - 1]);
				num12 = ((num12 != 0f) ? num11 : Math2.CalcDist(theWaypoint.Latitude, theWaypoint.Longitude, waypoint3.Latitude, waypoint3.Longitude));
				num11 = Math2.CalcDist(waypoint2.Latitude, waypoint2.Longitude, waypoint3.Latitude, waypoint3.Longitude);
				if (!(num12 < num11))
				{
					break;
				}
				waypoint = theWaypoint;
			}
			if (Information.IsNothing((object)waypoint))
			{
				return;
			}
			List<Waypoint> list2 = new List<Waypoint>();
			foreach (Waypoint Waypoint in WaypointList)
			{
				if (waypoint != Waypoint)
				{
					list2.Add(Waypoint);
					continue;
				}
				break;
			}
			if (!IsBingoCheck)
			{
				{
					foreach (Waypoint item3 in list2)
					{
						WaypointList.Remove(item3);
						ApplyWaypointSpeedAltToUnit(item3);
						ApplyWaypointDoctrineToUnit(item3);
						RemoveWaypoint_Soft(item3, RemoveWingmanWaypoints: false);
					}
					return;
				}
			}
			foreach (Waypoint item4 in list2)
			{
				WaypointList.Remove(item4);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 475475345345", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override bool EgressToRejoinPoint_CallOff(float elapsedTime)
	{
		bool result;
		try
		{
			bool flag;
			ActiveUnit groupLead = default(ActiveUnit);
			if (myUnit.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
			{
				result = false;
			}
			else if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
			{
				result = false;
			}
			else if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Strike)
			{
				result = false;
			}
			else
			{
				flag = false;
				if (myUnit.IsGroupMember())
				{
					foreach (ActiveUnit value in myUnit.get_ParentGroup(UsingMissionPlanner: false).Units.Values)
					{
						if (value != myUnit && value.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					goto IL_013f;
				}
				if (!myUnit.IsGroupWingman() || (myUnit.IsGroupWingman() && myUnit.Navigator.HasPlottedCourse()))
				{
					groupLead = myUnit;
					goto IL_013f;
				}
				if (!Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
				{
					if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.RTB_CalledOff)
					{
						flag = true;
					}
					else
					{
						groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					}
					goto IL_013f;
				}
				result = false;
			}
			goto end_IL_0001;
			IL_013f:
			if (flag)
			{
				goto IL_02e6;
			}
			if (groupLead != null)
			{
				if (!groupLead.Navigator.HasPlottedCourse())
				{
					result = false;
				}
				else
				{
					Waypoint waypoint = groupLead.Navigator.PlottedCourse[0];
					if (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget && waypoint.Type != Waypoint.WaypointType.InitialPoint && waypoint.Type != Waypoint.WaypointType.WeaponLaunch)
					{
						result = false;
					}
					else
					{
						DateTime? previousWaypointTime = groupLead.Navigator.PreviousWaypointTime;
						if (Information.IsNothing((object)previousWaypointTime))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							groupLead.Navigator.PreviousWaypointTime = groupLead.ParentScen.Time;
							goto IL_02e6;
						}
						DateTime? dateTime = default(DateTime?);
						if (!Information.IsNothing((object)previousWaypointTime))
						{
							dateTime = previousWaypointTime.Value.AddSeconds(waypoint.Leg_Time_Straight + waypoint.Leg_Time_Turn + waypoint.Hold_Time + waypoint.Station_Time + waypoint.SpacingManeuver_Time);
						}
						else if (!Information.IsNothing((object)waypoint.Time_Zulu))
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							dateTime = waypoint.Time_Zulu;
						}
						if (!Information.IsNothing((object)dateTime))
						{
							dateTime = dateTime.Value.AddSeconds(120.0);
							DateTime time = groupLead.ParentScen.Time;
							if (((!dateTime.HasValue) ? ((bool?)null) : new bool?(DateTime.Compare(time, dateTime.GetValueOrDefault()) >= 0)) == true)
							{
								flag = true;
							}
							goto IL_02e6;
						}
						result = false;
					}
				}
			}
			else
			{
				result = false;
			}
			goto end_IL_0001;
			IL_02e6:
			if (!flag)
			{
				result = false;
			}
			else
			{
				string text = "";
				if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
				{
					text = " (" + myUnit.UnitClass + ")";
				}
				myUnit.AddMessage(myUnit.Name + text + " has not completed its attack but is getting dangerously low on fuel. Calling off and returning to base at optimum altitude and speed.", myUnit.Name + " aborting", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
				if (GlobalVariables.AI_REWORK)
				{
					method_10().AI.StatusRelatedEvents.method_1(ActiveUnit._ActiveUnitStatus.RTB_CalledOff);
				}
				else
				{
					myUnit.Status = ActiveUnit._ActiveUnitStatus.RTB_CalledOff;
				}
				if (!Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
				{
					Strike strike = (Strike)method_10().ActiveMissionOrPackage();
					if (strike.BingoFuel != Mission._BingoFuelSetting.UseLoadoutSetting)
					{
						if (strike.BingoFuel == Mission._BingoFuelSetting.ExpendJettison)
						{
							myUnit.AddMessage(myUnit.Name + text + " had to jettison its air-to-ground ordnance or else it would not have enough fuel to get back to base due to the increased fuel burn rate caused by the payload weight and drag. To avoid this situation, change the mission 'Fuel/Ordnance' setting to 'Bring A/G ordnance back to base if target cannot be struck'. The extra payload weight and drag on the return leg will then be taken into account when estimating Bingo Fuel. Note that this will reduce the maximum strike radius, since the flightplan generator will take the increased fuel burn rate on the return leg into account.", myUnit.Name + " jettisoned A2G", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
							method_10().Weaponry.JettisonOrdnance(ExecuteImmediately: false, JettisonDropTanks: false, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
						}
					}
					else if (!Information.IsNothing((object)method_10().Loadout) && method_10().Loadout.get_MissionProfile(method_10().ParentScen).DropBombsAtMaxRange)
					{
						method_10().Weaponry.JettisonOrdnance(ExecuteImmediately: true, JettisonDropTanks: false, JettisonUnguidedAG: true, JettisonGuidedAG: true, bool_12: false, JettisonPod: false, JettisonInternalWeapons: false);
						myUnit.AddMessage(myUnit.Name + text + " had to jettison its air-to-ground ordnance or else it would not have enough fuel to get back to base due to the increased fuel burn rate caused by the payload weight and drag. To avoid this situation, change the mission 'Fuel/Ordnance' setting to 'Bring A/G ordnance back to base if target cannot be struck'. The extra payload weight and drag on the return leg will then be taken into account when estimating Bingo Fuel. Note that this will reduce the maximum strike radius, since the flightplan generator will take the increased fuel burn rate on the return leg into account.", myUnit.Name + " jettisoned A2G", LoggedMessage.MessageType.AirOps, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				if (!myUnit.Navigator.HasPlottedCourse())
				{
					if (!Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride))
					{
						myUnit.Kinematics.DesiredSpeedOverride = null;
					}
					if (myUnit.Kinematics.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
					{
						myUnit.Kinematics.ThrottlePreset = ActiveUnit_Kinematics.UnitThrottlePreset.None;
					}
					myUnit.Kinematics.DesiredAltitudeOverride = false;
					myUnit.set_DesiredAltitude_UseTerrainFollowing(myUnit, value: false);
				}
				else
				{
					ActiveUnit.Throttle bingoFuelThrottle = method_10().Navigator.GetBingoFuelThrottle();
					Aircraft_Navigator navigator = method_10().Navigator;
					bool theAltitude_TerrainFollowing = false;
					float num = navigator.GetBingoFuelAltitude(ref theAltitude_TerrainFollowing);
					float maximumAltitude = myUnit.Kinematics.GetMaximumAltitude();
					if (num > maximumAltitude)
					{
						num = maximumAltitude;
					}
					int maximumSpeed = myUnit.Kinematics.GetMaximumSpeed(num, bingoFuelThrottle, ValidateAndFixAltitude: false);
					Waypoint[] plottedCourse = myUnit.Navigator.PlottedCourse;
					foreach (Waypoint waypoint2 in plottedCourse)
					{
						if (waypoint2.ThrottlePreset != ActiveUnit_Kinematics.UnitThrottlePreset.None)
						{
							waypoint2.ThrottlePreset = (ActiveUnit_Kinematics.UnitThrottlePreset)bingoFuelThrottle;
						}
						waypoint2.DesiredSpeed = maximumSpeed;
						waypoint2.DesiredSpeedOverride = maximumSpeed;
						waypoint2.TerrainFollowing = false;
						waypoint2.DesiredAltitudeOverride = true;
						waypoint2.DesiredAltitude = num;
						waypoint2.DesiredAltitude_TerrainFollowing = null;
						waypoint2.AltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
					}
				}
				myUnit.Navigator.EgressToRejoinPoint(elapsedTime, ForceObjectiveWaypointRemoval: false);
				result = true;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101381", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 0;
			}
			else
			{
				Debugger.Break();
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void GlideToHomeBase(float elapsedTime)
	{
		try
		{
			ActiveUnit actualDestinationHost = method_10().AirOps.ActualDestinationHost;
			if (actualDestinationHost != null)
			{
				double num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null));
				double num2 = actualDestinationHost.CurrentSpeed;
				if (method_10().IsHelicopter)
				{
					double num3 = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Full, ValidateAndFixAltitude: false);
					double val = num3 / 3.0;
					double val2 = Math.Max(val, num2 + 30.0);
					myUnit.DesiredSpeed = (float)Math.Min(Math.Max(val2, num3 * num), num3);
				}
				else
				{
					double num3 = myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false);
					double val = num3 * 0.7;
					myUnit.DesiredSpeed = (float)(val + num);
				}
				method_10().SetThrottle(method_10().Kinematics.GetThrottleSuitableForThisSpeed(method_10().get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(method_10().DesiredSpeed)));
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Navigation, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null)));
				if (!method_10().IsHelicopter)
				{
					Waypoint theWaypoint = null;
					ExtendIfNecessary(elapsedTime, ref theWaypoint, actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null), 0f, 0f, myUnit.Kinematics.TurnRate());
				}
				float num4 = (float)((double)actualDestinationHost.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + 100.0 * num);
				if (!(myUnit.DesiredAltitude < num4))
				{
					myUnit.DesiredAltitude = num4;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100466", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool AboutToLand(float elapsedTime)
	{
		double num = 0.02;
		if (elapsedTime == 1f)
		{
			num = 0.03;
		}
		else if (elapsedTime == 5f)
		{
			num = 0.05;
		}
		bool result;
		try
		{
			ActiveUnit actualDestinationHost = method_10().AirOps.ActualDestinationHost;
			if (!Information.IsNothing((object)actualDestinationHost))
			{
				double num2 = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Latitude((GlobalVariables.BooleanObject)null), actualDestinationHost.get_Longitude((GlobalVariables.BooleanObject)null));
				result = num2 < num || (double)(2f * myUnit.CurrentSpeed * elapsedTime / 3600f) > num2;
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
			ex2?.Data.Add("Error at 100467", "");
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
		return result;
	}

	public override bool PathLineIsInterrupted(double StartLat, double StartLon, double DestLat, double DestLon, bool RunInParallel, float ProximityThreshold_Deg, bool CheckIfCurrentlyInsideIllegalArea, int? BufferTolerance_meters, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, float? SamplingInterval_Deg, [Optional][DefaultParameterValue(0)] ref int ReasonForInterrupt, [Optional][DefaultParameterValue(null)] ref GeoPoint InterruptLocation)
	{
		bool result;
		try
		{
			bool CheckForMines = false;
			bool CheckNoNavZones = false;
			if (!CheckIfCurrentlyInsideIllegalArea)
			{
				goto IL_0079;
			}
			ActiveUnit activeUnit = myUnit;
			double theLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			double theLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
			int MovementCost = 0;
			bool CheckNoNavZones2 = false;
			bool CheckForMines2 = false;
			float? distanceFromUnit = 0f;
			List<ActiveUnit> ProvidedPiers = null;
			string UserFeedback = "";
			bool AllowBounce = false;
			if (activeUnit.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs, ref CheckNoNavZones2, CheckForIcepack: false, ref CheckForMines2, distanceFromUnit, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
			{
				goto IL_0079;
			}
			result = false;
			goto end_IL_0001;
			IL_0329:
			int num;
			result = (byte)num != 0;
			goto end_IL_0001;
			IL_0079:
			if (PlottedCourse.Length <= 0)
			{
				goto IL_00bb;
			}
			Waypoint waypoint = PlottedCourse.FirstOrDefault();
			if (waypoint == null || (waypoint.Type != Waypoint.WaypointType.Target && waypoint.Type != Waypoint.WaypointType.WeaponTarget) || waypoint.Creator != Waypoint.WaypointCreator.Pathfinder)
			{
				goto IL_00bb;
			}
			result = false;
			goto end_IL_0001;
			IL_00bb:
			if (!myUnit.IsGroupWingman() || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
			{
				goto IL_02f8;
			}
			ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
			bool? obj;
			if (groupLead.Navigator.PlottedCourse.Count() <= 0)
			{
				obj = false;
			}
			else
			{
				Waypoint? waypoint2 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
				bool? flag2;
				bool? flag = (flag2 = ((waypoint2 != null) ? new bool?(waypoint2.Type == Waypoint.WaypointType.Target) : ((bool?)null)));
				bool? obj2;
				bool? flag3;
				if (flag.HasValue && flag2 == true)
				{
					obj2 = true;
				}
				else
				{
					Waypoint? waypoint3 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
					flag = (flag3 = ((waypoint3 != null) ? new bool?(waypoint3.Type == Waypoint.WaypointType.WeaponTarget) : ((bool?)null)));
					obj2 = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
				}
				bool? flag4 = obj2;
				flag3 = obj2;
				bool? obj3;
				bool? flag5;
				if (flag3.HasValue && flag4 == true)
				{
					obj3 = true;
				}
				else
				{
					Waypoint? waypoint4 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
					flag3 = (flag5 = ((waypoint4 == null) ? ((bool?)null) : new bool?(waypoint4.Type == Waypoint.WaypointType.StrikeEgress)));
					obj3 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
				}
				bool? flag6 = obj3;
				flag5 = obj3;
				if (flag5.HasValue && flag6 == true)
				{
					obj = true;
				}
				else
				{
					Waypoint? waypoint5 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
					bool? flag7;
					flag5 = (flag7 = ((waypoint5 != null) ? new bool?(waypoint5.Type == Waypoint.WaypointType.Formate) : ((bool?)null)));
					obj = ((!flag5.HasValue) ? ((bool?)null) : ((flag7 == true) | flag6));
				}
			}
			bool? flag8 = obj;
			if ((!flag8) ?? false)
			{
				goto IL_02f8;
			}
			Waypoint? waypoint6 = groupLead.Navigator.PlottedCourse.FirstOrDefault();
			if (waypoint6 == null || waypoint6.Creator != Waypoint.WaypointCreator.Pathfinder || !flag8.HasValue)
			{
				goto IL_02f8;
			}
			result = false;
			goto end_IL_0001;
			IL_02f8:
			if (!Geo_PathLineIsInterrupted_NoNavZones(StartLat, StartLon, DestLat, DestLon, ProximityThreshold_Deg))
			{
				float num2 = Math2.CalcDist(StartLat, StartLon, DestLat, DestLon);
				if (float.IsNaN(num2))
				{
					num = 0;
					goto IL_0329;
				}
				if (num2 == 0f)
				{
					num = 0;
					goto IL_0329;
				}
				if (!SamplingInterval_Deg.HasValue)
				{
					SamplingInterval_Deg = (myUnit.IsAircraft ? new float?(Pathfinding.PathFinderSettlersEngine.DegreeInterval_Coarse) : ((!(num2 < myUnit.ParentScen.Navigation_FinegrainedMaxDistance)) ? new float?(Pathfinding.PathFinderSettlersEngine.DegreeInterval_Coarse) : new float?(Pathfinding.PathFinderSettlersEngine.DegreeInterval_Finegrained)));
				}
				if (!SamplingInterval_Deg.HasValue)
				{
					int num3;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
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
					bool flag9 = false;
					Angle angle = new Angle
					{
						Degrees = StartLon
					};
					Angle angle2 = new Angle
					{
						Degrees = StartLat
					};
					Angle angle3 = new Angle
					{
						Degrees = DestLon
					};
					Angle angle4 = new Angle
					{
						Degrees = DestLat
					};
					Angle d = World.ApproxAngularDistance(angle2, angle, angle4, angle3);
					float num4 = (float)d.Degrees;
					float num5 = num4;
					float? num6 = SamplingInterval_Deg * 2f;
					if (((!num6.HasValue) ? ((bool?)null) : new bool?(num5 < num6.GetValueOrDefault())) == true)
					{
						result = false;
					}
					else
					{
						int num7 = (int)Math.Round((num4 / SamplingInterval_Deg).Value);
						Angle lon = default(Angle);
						Angle lat = default(Angle);
						MovementCost = num7;
						for (int i = 1; i <= MovementCost; i++)
						{
							World.smethod_0(SamplingInterval_Deg.Value * (float)i / num4, angle2, angle, angle4, angle3, d, out lat, out lon);
							double degrees = lat.Degrees;
							double degrees2 = lon.Degrees;
							ActiveUnit activeUnit2 = myUnit;
							int MovementCost2 = 0;
							float? distanceFromUnit2 = BufferTolerance_meters;
							ProvidedPiers = null;
							UserFeedback = "";
							AllowBounce = false;
							if (!activeUnit2.CanMoveToThisLocation(degrees, degrees2, ref MovementCost2, IsPathfindingQuery, UsePathfindingBufferDistance, IgnoreMinesBehindUs, ref CheckNoNavZones, CheckForIcepack: false, ref CheckForMines, distanceFromUnit2, null, ref ProvidedPiers, ProximityThreshold_Deg, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
							{
								if (CheckForMines)
								{
									ReasonForInterrupt++;
								}
								int num8;
								if (CheckNoNavZones)
								{
									ReasonForInterrupt += 2;
									num8 = 1;
								}
								else
								{
									num8 = 1;
								}
								flag9 = (byte)num8 != 0;
								break;
							}
						}
						result = flag9;
					}
				}
			}
			else
			{
				result = true;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100468", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num9;
			if (!Debugger.IsAttached)
			{
				num9 = 1;
			}
			else
			{
				Debugger.Break();
				num9 = 1;
			}
			result = (byte)num9 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal bool FollowingRTB_FlightPlan()
	{
		int result;
		int result2;
		if (!HasPlottedCourse())
		{
			result = 0;
		}
		else
		{
			Waypoint? waypoint = PlottedCourse.FirstOrDefault();
			if (waypoint != null && waypoint.Type == Waypoint.WaypointType.WeaponLaunch)
			{
				return false;
			}
			Waypoint? waypoint2 = PlottedCourse.LastOrDefault();
			if (waypoint2 != null && waypoint2.Type == Waypoint.WaypointType.Land)
			{
				result2 = 1;
				goto IL_0068;
			}
			Waypoint? waypoint3 = PlottedCourse.LastOrDefault();
			if (waypoint3 == null)
			{
				result = 0;
			}
			else
			{
				if (waypoint3.Type == Waypoint.WaypointType.LandingMarshal)
				{
					result2 = 1;
					goto IL_0068;
				}
				result = 0;
			}
		}
		return (byte)result != 0;
		IL_0068:
		return (byte)result2 != 0;
	}

	static Aircraft_Navigator()
	{
		Class72.smethod_20();
	}
}
