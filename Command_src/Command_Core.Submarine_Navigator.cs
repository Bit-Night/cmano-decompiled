using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Submarine_Navigator : ActiveUnit_Navigator
{
	private Submarine submarine_0;

	[SpecialName]
	private Submarine method_10()
	{
		if (Information.IsNothing((object)submarine_0))
		{
			submarine_0 = (Submarine)myUnit;
		}
		return submarine_0;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Submarine_Navigator");
			if (AvoidCavitation)
			{
				theWriter.WriteElementString("AvCav", AvoidCavitation.ToString());
			}
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
			theWriter.WriteElementString("MPO", ManualPlotOverride.ToString());
			if (!Information.IsNothing((object)TankerFollowsMe))
			{
				theWriter.WriteElementString("TankerFollowsMe", TankerFollowsMe.Value.ToString());
			}
			if (base.TankerFollowsMe_NumberOfWaypoints != 0)
			{
				theWriter.WriteElementString("TankerFollowsMe_NumberOfWaypoints", base.TankerFollowsMe_NumberOfWaypoints.ToString());
			}
			if (myUnit.IsGroupMember())
			{
				theWriter.WriteElementString("FS_B", XmlConvert.ToString(base.UnitFormationStation.Bearing));
				theWriter.WriteElementString("FS_D", XmlConvert.ToString(base.UnitFormationStation.Distance));
				theWriter.WriteElementString("FS_BT", XmlConvert.ToString((byte)base.UnitFormationStation.BearingType));
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
			ex2?.Data.Add("Error at 100837", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Submarine_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		Submarine_Navigator result;
		try
		{
			Submarine_Navigator submarine_Navigator = new Submarine_Navigator(ref theAU);
			submarine_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "TankerFollowsMe_NumberOfWaypoints":
					submarine_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(val.InnerText);
					break;
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					submarine_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "SD":
					submarine_Navigator.SprintDrift = true;
					break;
				case "AvCav":
					submarine_Navigator.AvoidCavitation = Misc.ParseBool(val.InnerText);
					break;
				case "SD_M":
				{
					string[] array = val.InnerText.Split(new char[1] { '_' });
					submarine_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "PreviousWaypointType":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						submarine_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					else
					{
						submarine_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					submarine_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SD_Avg":
					submarine_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MPO":
				case "ManualPlotOverride":
					submarine_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "FS_BT":
					submarine_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint waypoint = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						if (waypoint.Latitude != 0.0 || waypoint.Longitude != 0.0)
						{
							ArrayExtensions.Add(ref submarine_Navigator._PlottedCourse, waypoint);
						}
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					submarine_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "TankerFollowsMe":
					submarine_Navigator.TankerFollowsMe = Misc.ParseBool(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					submarine_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				}
				}
			}
			result = submarine_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100838", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Submarine_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Submarine_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		NavigationBufferTolerance_Narrow_meters = (int)Math.Round(Math.Min(((Submarine)myUnit).Length, 100f) * 2f);
		NavigationBufferTolerance_Wide_meters = 500;
	}

	public override bool HaveReachedPoint(GeoPoint theGeoPoint, float elapsedTime, bool Overshoot = true, bool simplify_calc_for_ACs = false, float? distanceThreshold_nm = null, double SimulationTime = 0.0)
	{
		double latitude = theGeoPoint.Latitude;
		double longitude = theGeoPoint.Longitude;
		if (distanceThreshold_nm.HasValue)
		{
			float num = 0.25f;
			num = distanceThreshold_nm.Value;
			if (Math2.CalcDist(latitude, longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)) < num)
			{
				return true;
			}
			return false;
		}
		return base.HaveReachedPoint(theGeoPoint, elapsedTime, Overshoot, simplify_calc_for_ACs);
	}

	public override void AddWaypoint(double Latitude, double Longitude, float Altitude, Waypoint.WaypointType theWaypointType, Waypoint.WaypointCreator theCreator, Waypoint.WaypointCategory theCategory, bool _Overshoot = true)
	{
		if (!CanAutonomouslyPlotAndFollowCourse())
		{
			Notification_Bark.Create_UnitBehaviour(myUnit, " cannot autonomously plot and follow a course");
			return;
		}
		try
		{
			Waypoint waypoint;
			if (myUnit.IsGroupLead())
			{
				waypoint = new Waypoint(Longitude, Latitude, Altitude, theWaypointType, theCreator, theCategory);
				myUnit.get_ParentGroup(UsingMissionPlanner: false).Navigator.AddWaypoint(waypoint);
			}
			else
			{
				waypoint = new Waypoint(Longitude, Latitude, Altitude, theWaypointType, theCreator, theCategory);
				ArrayExtensions.Add(ref _PlottedCourse, waypoint);
			}
			waypoint.DepthPreset = method_10().AI.DepthPreset;
			ManualPlotOverride = theWaypointType == Waypoint.WaypointType.ManualPlottedCourseWaypoint;
			TimeToNextPlottedCourseLeadsToMissionAreaEvaluation = 0.0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1002299", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void FollowPlottedCourse(float elapsedTime)
	{
		if (!HasPlottedCourse())
		{
			return;
		}
		if (method_10().IsTetheredROV)
		{
			ActiveUnit activeUnit = myUnit.DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false);
			if (!Information.IsNothing((object)activeUnit) && (double)activeUnit.RangeToUnit_Horiz(method_10()) > (double)method_10().ROVControlRadius_m / 1852.0 * 1.25)
			{
				ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
				ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
				ApplyWaypointActionToUnit(PlottedCourse[0]);
				RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
				return;
			}
		}
		base.FollowPlottedCourse(elapsedTime);
	}

	public override void PlotCourseToStationArea(float elapsedTime, bool AddWaypointToExistingPlottedCourse)
	{
		if (method_10().IsOnActiveMineClearingMission && (method_10().Type == Submarine._SubmarineType.ROV || method_10().Type == Submarine._SubmarineType.UUV))
		{
			float num = (method_10().IsTetheredROV ? ((float)((double)method_10().ROVControlRadius_m / 1852.0)) : ((method_10().Sensors_Cached.Length <= 0) ? 5f : method_10().Sensors_Cached[0].maxRange));
			double lat = method_10().DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false).get_Latitude((GlobalVariables.BooleanObject)null);
			double lon = method_10().DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false).get_Longitude((GlobalVariables.BooleanObject)null);
			float currentHeading = method_10().DockingOps.get_AssignedHostUnit(PickNewAssignedHost: false).CurrentHeading;
			ReferencePoint referencePoint = new ReferencePoint();
			ReferencePoint referencePoint2 = new ReferencePoint();
			ReferencePoint referencePoint3 = new ReferencePoint();
			ReferencePoint referencePoint4 = new ReferencePoint();
			ReferencePoint referencePoint5 = new ReferencePoint();
			ReferencePoint referencePoint6 = new ReferencePoint();
			List<ReferencePoint> list = new List<ReferencePoint>(6);
			ReferencePoint referencePoint7;
			double out_lon = (referencePoint7 = referencePoint).Longitude;
			ReferencePoint referencePoint8;
			double out_lat = (referencePoint8 = referencePoint).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, (float)((double)num * 0.1), Math2.NormalizeBearing(currentHeading - 45f));
			referencePoint8.Latitude = out_lat;
			referencePoint7.Longitude = out_lon;
			list.Add(referencePoint);
			out_lat = (referencePoint8 = referencePoint2).Longitude;
			out_lon = (referencePoint7 = referencePoint2).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lat, ref out_lon, num, Math2.NormalizeBearing(currentHeading - 45f));
			referencePoint7.Latitude = out_lon;
			referencePoint8.Longitude = out_lat;
			list.Add(referencePoint2);
			out_lon = (referencePoint7 = referencePoint3).Longitude;
			out_lat = (referencePoint8 = referencePoint3).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, num, currentHeading);
			referencePoint8.Latitude = out_lat;
			referencePoint7.Longitude = out_lon;
			list.Add(referencePoint3);
			out_lat = (referencePoint8 = referencePoint4).Longitude;
			out_lon = (referencePoint7 = referencePoint4).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lat, ref out_lon, num, Math2.NormalizeBearing(currentHeading + 45f));
			referencePoint7.Latitude = out_lon;
			referencePoint8.Longitude = out_lat;
			list.Add(referencePoint4);
			out_lon = (referencePoint7 = referencePoint5).Longitude;
			out_lat = (referencePoint8 = referencePoint5).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, (float)((double)num * 0.1), Math2.NormalizeBearing(currentHeading + 45f));
			referencePoint8.Latitude = out_lat;
			referencePoint7.Longitude = out_lon;
			list.Add(referencePoint5);
			out_lat = (referencePoint8 = referencePoint6).Longitude;
			out_lon = (referencePoint7 = referencePoint6).Latitude;
			Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lat, ref out_lon, (float)((double)num * 0.1), currentHeading);
			referencePoint7.Latitude = out_lon;
			referencePoint8.Longitude = out_lat;
			list.Add(referencePoint6);
			PlotCourseToArea(list);
		}
		else
		{
			base.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse);
		}
		ResetTimeToNextPathfinderCheck();
	}

	public override void HeadToFormationStationOrFollowSecondaryFlightPlan(float elapsedtime)
	{
		try
		{
			if (Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				myUnit.get_ParentGroup(UsingMissionPlanner: false).DesignateGroupLead_Auto();
				if (Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
				{
					return;
				}
			}
			if (myUnit.IsGroupMember() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) && (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.Status == ActiveUnit._ActiveUnitStatus.Refuelling) && myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DockingOps.UNREP_Destination == myUnit)
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
				if (!base.HasPathfindingPlottedCourse)
				{
					if (myUnit.IsGroupMember() && !myUnit.Kinematics.DesiredAltitudeOverride && myUnit.DockingOps.Condition != ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
					{
						myUnit.DesiredAltitude = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude;
						myUnit.DesiredAltitude_AGL = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.DesiredAltitude_AGL;
					}
					ActiveUnit groupLead = myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead;
					if (groupLead == null)
					{
						return;
					}
					var (num, num2) = base.UnitFormationStation.get_ValidatedLatitudeAndLongitude(myUnit, groupLead);
					if (SprintDrift)
					{
						PerformSprintDrift(elapsedtime);
					}
					else
					{
						if (HaveReachedPoint(new GeoPoint(num2, num), elapsedtime))
						{
							float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
							if (relativeBearing > 90f && relativeBearing < 270f)
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
						myUnit.set_DesiredHeading(groupLead.DesiredTurnRate, Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, num2));
						if (myUnit.Kinematics.DesiredSpeedOverride.HasValue)
						{
							myUnit.DesiredSpeed = myUnit.Kinematics.DesiredSpeedOverride.Value;
							ActiveUnit activeUnit = myUnit;
							ActiveUnit.Throttle throttleSuitableForThisSpeed = myUnit.Kinematics.GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
							float? desiredSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
							activeUnit.SetThrottle(throttleSuitableForThisSpeed, desiredSpeedOverride.HasValue ? new int?((int)Math.Round(desiredSpeedOverride.GetValueOrDefault())) : ((int?)null));
						}
						else if (!myUnit.IsGroupMember())
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Full);
						}
						else if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting > ActiveUnit.Throttle.Full)
						{
							myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
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
						Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref out_lon, ref out_lat, base.UnitFormationStation.Distance, groupLead.CurrentHeading);
						ActiveUnit activeUnit2 = myUnit;
						double theLat = out_lat;
						double theLon = out_lon;
						int MovementCost = 0;
						bool CheckNoNavZones = true;
						bool CheckForMines = true;
						List<ActiveUnit> ProvidedPiers = null;
						string UserFeedback = "";
						bool AllowBounce = false;
						if (!activeUnit2.CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
						{
							num = groupLead.get_Latitude((GlobalVariables.BooleanObject)null);
							num2 = groupLead.get_Longitude((GlobalVariables.BooleanObject)null);
						}
					}
					myUnit.AI.NavDestination = new Geopoint_Struct(num2, num);
					if (base.HasPathfindingPlottedCourse || base.PathFindingInProgress)
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
				else
				{
					FollowPlottedCourse(elapsedtime);
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

	static Submarine_Navigator()
	{
		Class72.smethod_20();
	}
}
