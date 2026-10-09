using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_Navigator : ActiveUnit_Navigator
{
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
			if (ManualPlotOverride)
			{
				theWriter.WriteElementString("MPO", "True");
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
			ex2?.Data.Add("Error at 100561", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Facility_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		Facility_Navigator result;
		try
		{
			Facility_Navigator facility_Navigator = new Facility_Navigator(ref theAU);
			facility_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "SD_M":
				{
					string[] array = val.InnerText.Split(new char[1] { '_' });
					facility_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					facility_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "PreviousWaypointType":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						facility_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					else
					{
						facility_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "SD":
					facility_Navigator.SprintDrift = true;
					break;
				case "MPO":
				case "ManualPlotOverride":
					facility_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					facility_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SD_Avg":
					facility_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "FS_BT":
					facility_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint waypoint = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						if (waypoint.Latitude != 0.0 || waypoint.Longitude != 0.0)
						{
							ArrayExtensions.Add(ref facility_Navigator._PlottedCourse, waypoint);
						}
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					facility_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					facility_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				}
				}
			}
			result = facility_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100562", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Facility_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Facility_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		try
		{
			NavigationBufferTolerance_Narrow_meters = (int)Math.Round(Math.Min(Math.Sqrt(((Facility)myUnit).Area), 10.0) * 2.0);
			NavigationBufferTolerance_Wide_meters = 2000;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100563", "");
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
		base.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse);
		try
		{
			float? desiredSpeedOverride = myUnit.Kinematics.DesiredSpeedOverride;
			long? num = (desiredSpeedOverride.HasValue ? new long?((long)Math.Round(desiredSpeedOverride.GetValueOrDefault())) : ((long?)null));
			long? num2 = (~num) ?? num;
			if (((!num2.HasValue) ? ((bool?)null) : new bool?((ulong)num2.GetValueOrDefault() > 0uL)) != true)
			{
				return;
			}
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
			{
				if (myUnit.get_ParentGroup(UsingMissionPlanner: false).ThrottleSetting == ActiveUnit.Throttle.Flank)
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Flank);
				}
				else
				{
					myUnit.SetThrottle(ActiveUnit.Throttle.Full);
				}
			}
			myUnit.DesiredSpeed = myUnit.Kinematics.GetMaximumSpeed(0f, myUnit.ThrottleSetting, ValidateAndFixAltitude: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100564", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override void PerformPathfinding(Waypoint StartWP, ActiveUnit theUnit, Mission.Flight theFlightPlan, bool theFlightPlanIngressPath, float ProximityThreshold_Deg, double DestLat, double DestLon, bool ManouverTowardsTarget)
	{
		try
		{
			bool isMissionPlannerRequest = false;
			double num;
			double num2;
			float num3;
			if (StartWP != null)
			{
				num = StartWP.Latitude;
				num2 = StartWP.Longitude;
				num3 = Math2.CalcAzimuth(num, num2, DestLat, DestLon);
			}
			else
			{
				num = theUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				num2 = theUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				num3 = theUnit.CurrentHeading;
			}
			List<Waypoint> list = null;
			int MovementCost = 0;
			bool CheckNoNavZones = true;
			bool CheckForMines = true;
			List<ActiveUnit> ProvidedPiers = null;
			string UserFeedback = "";
			bool AllowBounce = false;
			if (theUnit.CanMoveToThisLocation(DestLat, DestLon, ref MovementCost, IsPathfindingQuery: true, UsePathfindingBufferDistance: true, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, ProximityThreshold_Deg, ManouverTowardsTarget, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
			{
				theUnit.AI.NavDestination = new Geopoint_Struct(DestLon, DestLat);
				double startLat = num;
				double startLon = num2;
				float currentHeading = num3;
				ProvidedPiers = new List<ActiveUnit>();
				list = PathfindingCourse(startLat, startLon, DestLat, DestLon, currentHeading, AttemptToShrinkPFArea: true, ProximityThreshold_Deg, ref ProvidedPiers, isMissionPlannerRequest);
				PF_GeneratedCourse = list;
				if (PF_GeneratedCourse == null)
				{
					myUnit.AddMessage(myUnit.Name + " has cleared its plotted course (Reason: The destination is unreachable or the destination is beyond the navigator's maximum distance.)", myUnit.Name + " clearing plotted course.", LoggedMessage.MessageType.UnitAI, 5, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
					ClearPlottedCourse();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100565", "");
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
		if (myUnit.AI.HoldPosition)
		{
			return;
		}
		try
		{
			if (PlottedCourse.Count() == 0)
			{
				return;
			}
			if (bool_0)
			{
				Waypoint waypoint = PlottedCourse[0];
				byte? b = (byte?)myUnit.Doctrine.get_LandNavigation(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false);
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
				{
					float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude);
					if (num >= AGU_CONFIG.Instance.RoadUsageDistanceThreshold_Nm)
					{
						myUnit.PathFindingToDestination(myUnit.ParentScen, waypoint.Latitude, waypoint.Longitude, 1f);
					}
					if (!HasRoadSystemPlottedCourse())
					{
						if (num > Pathfinding.GroundCostBasedEngine.DegreeInterval_Finegrained * 5f && !base.PathFindingInProgress)
						{
							if (base.HasPathfindingPlottedCourse)
							{
								if (PlottedCourse.Count() > 1 && PlottedCourse[0].Type == Waypoint.WaypointType.PathfindingPoint)
								{
									double startLat = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
									double startLon = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
									double latitude = PlottedCourse[0].Latitude;
									double longitude = PlottedCourse[0].Longitude;
									float? samplingInterval_Deg = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
									int ReasonForInterrupt = 0;
									GeoPoint InterruptLocation = null;
									if (PathLineIsInterrupted(startLat, startLon, latitude, longitude, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: true, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, samplingInterval_Deg, ref ReasonForInterrupt, ref InterruptLocation))
									{
										TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, myUnit.ParentScen, ManouverTowardsTarget: false);
									}
									double startLat2 = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
									double startLon2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
									double latitude2 = PlottedCourse[1].Latitude;
									double longitude2 = PlottedCourse[1].Longitude;
									float? samplingInterval_Deg2 = Pathfinding.PathFinderCostBasedEngine.DegreeInterval_Finegrained;
									ReasonForInterrupt = 0;
									InterruptLocation = null;
									if (!PathLineIsInterrupted(startLat2, startLon2, latitude2, longitude2, RunInParallel: true, 0f, CheckIfCurrentlyInsideIllegalArea: false, null, IsPathfindingQuery: true, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, samplingInterval_Deg2, ref ReasonForInterrupt, ref InterruptLocation))
									{
										if (myUnit.IsAircraft)
										{
											ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
											ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
											RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
										}
										else if (Math2.CalcDist_Angular(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude) < 0.05)
										{
											ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
											ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
											RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
										}
									}
								}
							}
							else
							{
								TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, myUnit.ParentScen, ManouverTowardsTarget: false);
							}
						}
					}
					else
					{
						Waypoint[] theArray = PlottedCourse;
						ArrayExtensions.Clear(ref theArray);
						PlottedCourse = theArray;
					}
				}
			}
			HeadToFirstWaypoint(elapsedTime);
			bool ForceWaypointSwitch = false;
			bool ForceStationAbort = false;
			CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch, ref ForceStationAbort);
			if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue && myUnit.IsGroupWingman() && !Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				myUnit.SetThrottle(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.ThrottleSetting);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 20032130942583209452837482913", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	protected override List<Waypoint> PathfindingCourse(double StartLat, double StartLon, double DestLat, double DestLon, float CurrentHeading, bool AttemptToShrinkPFArea, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, bool IsMissionPlannerRequest)
	{
		List<Waypoint> list = new List<Waypoint>();
		List<Waypoint> result;
		try
		{
			if (!myUnit.ParentScen.ThreadedOpsMustStop)
			{
				list = Pathfinding.GroundCostBasedEngine.SolvePF_Finegrained(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest);
				result = list;
			}
			else
			{
				base.PathFindingInProgress = false;
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10022324059230495134123498", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = list;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override bool HaveReachedFormationStation()
	{
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
		{
			if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null)
			{
				return false;
			}
			(double, double) tuple = base.UnitFormationStation.get_LatitudeAndLongitude(myUnit, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead);
			double item = tuple.Item1;
			double item2 = tuple.Item2;
			double num = 0.02;
			if (IsManouveringToFormationStation)
			{
				num = 0.01;
			}
			if ((double)Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), item, item2) < num)
			{
				return true;
			}
			if ((double)Math.Abs(new Geopoint_Struct(item2, item).AngleOffThisUnitsBoresight(myUnit)) > 90.0 && Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentHeading)) < 20f)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	static Facility_Navigator()
	{
		Class72.smethod_20();
	}
}
