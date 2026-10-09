using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_Navigator : ActiveUnit_Navigator
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

	public new static Vehicle_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		Vehicle_Navigator result;
		try
		{
			Vehicle_Navigator vehicle_Navigator = new Vehicle_Navigator(ref theAU);
			vehicle_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "SD_M":
				{
					string[] array = val.InnerText.Split(new char[1] { '_' });
					vehicle_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					vehicle_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "PreviousWaypointType":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						vehicle_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					else
					{
						vehicle_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "SD":
					vehicle_Navigator.SprintDrift = true;
					break;
				case "MPO":
				case "ManualPlotOverride":
					vehicle_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					vehicle_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SD_Avg":
					vehicle_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "FS_BT":
					vehicle_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint waypoint = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						if (waypoint.Latitude != 0.0 || waypoint.Longitude != 0.0)
						{
							ArrayExtensions.Add(ref vehicle_Navigator._PlottedCourse, waypoint);
						}
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					vehicle_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					vehicle_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				}
				}
			}
			result = vehicle_Navigator;
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
			result = new Vehicle_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Vehicle_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		try
		{
			NavigationBufferTolerance_Narrow_meters = (int)Math.Round(Math.Min(Math.Sqrt(((Vehicle)myUnit).Area), 10.0) * 2.0);
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
			long? num = ((!desiredSpeedOverride.HasValue) ? ((long?)null) : new long?((long)Math.Round(desiredSpeedOverride.GetValueOrDefault())));
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

	public override bool HaveReachedFormationStation()
	{
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false) == null)
		{
			return false;
		}
		if (myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
		{
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

	protected override void PerformPathfinding(Waypoint StartWP, ActiveUnit theUnit, Mission.Flight theFlightPlan, bool theFlightPlanIngressPath, float ProximityThreshold_Deg, double DestLat, double DestLon, bool ManouverTowardsTarget)
	{
		try
		{
			bool isMissionPlannerRequest = false;
			double num;
			double num2;
			float num3;
			if (StartWP == null)
			{
				num = theUnit.get_Latitude((GlobalVariables.BooleanObject)null);
				num2 = theUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				num3 = theUnit.CurrentHeading;
			}
			else
			{
				num = StartWP.Latitude;
				num2 = StartWP.Longitude;
				num3 = Math2.CalcAzimuth(num, num2, DestLat, DestLon);
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

	protected override List<Waypoint> PathfindingCourse(double StartLat, double StartLon, double DestLat, double DestLon, float CurrentHeading, bool AttemptToShrinkPFArea, float ProximityThreshold_Deg, ref List<ActiveUnit> ProvidedPiers, bool IsMissionPlannerRequest)
	{
		List<Waypoint> list = new List<Waypoint>();
		List<Waypoint> result;
		try
		{
			if (myUnit.ParentScen.ThreadedOpsMustStop)
			{
				base.PathFindingInProgress = false;
				result = null;
			}
			else
			{
				list = Pathfinding.GroundCostBasedEngine.SolvePF_Finegrained(myUnit, StartLat, StartLon, DestLat, DestLon, CurrentHeading, 2f, ProximityThreshold_Deg, ref ProvidedPiers, ref Pathfinding_PercentComplete, IsMissionPlannerRequest);
				result = list;
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

	static Vehicle_Navigator()
	{
		Class72.smethod_20();
	}
}
