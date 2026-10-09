using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class AggregateGroundUnit_Navigator : ActiveUnit_Navigator
{
	public AggregateGroundUnit_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
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

	public new static AggregateGroundUnit_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		AggregateGroundUnit_Navigator result;
		try
		{
			AggregateGroundUnit_Navigator aggregateGroundUnit_Navigator = new AggregateGroundUnit_Navigator(ref theAU);
			aggregateGroundUnit_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "SD_M":
				{
					string[] array = val.InnerText.Split(new char[1] { '_' });
					aggregateGroundUnit_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					aggregateGroundUnit_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "PreviousWaypointType":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						aggregateGroundUnit_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					else
					{
						aggregateGroundUnit_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "SD":
					aggregateGroundUnit_Navigator.SprintDrift = true;
					break;
				case "MPO":
				case "ManualPlotOverride":
					aggregateGroundUnit_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					aggregateGroundUnit_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SD_Avg":
					aggregateGroundUnit_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "FS_BT":
					aggregateGroundUnit_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint theAC = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						ArrayExtensions.Add(ref aggregateGroundUnit_Navigator._PlottedCourse, theAC);
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					aggregateGroundUnit_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					aggregateGroundUnit_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				}
				}
			}
			result = aggregateGroundUnit_Navigator;
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
			result = new AggregateGroundUnit_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void FollowPlottedCourse(float elapsedTime)
	{
		if (myUnit.AI.HoldPosition)
		{
			return;
		}
		if (!HasRoadSystemPlottedCourse())
		{
			try
			{
				if (PlottedCourse.Length != 0)
				{
					if (myUnit.IsAttachedToDefensiveSystem)
					{
						myUnit.DetachFromRoadSystem();
					}
					if (bool_0)
					{
						Waypoint waypoint = PlottedCourse[0];
						int? elementState = myUnit.Doctrine.GetElementState(Doctrine.DoctrineItem_E.NavLand);
						if (((!elementState.HasValue) ? ((bool?)null) : new bool?(elementState.GetValueOrDefault() == 0)) == true && waypoint.Type != Waypoint.WaypointType.PathfindingPoint)
						{
							float num = Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), waypoint.Latitude, waypoint.Longitude);
							RoadSystem.Node node = null;
							bool flag;
							if ((flag = num >= AGU_CONFIG.Instance.RoadUsageDistanceThreshold_Nm) && ((AggregateGroundUnit)myUnit).HostileFrictionProportion.Count == 0)
							{
								node = myUnit.PathFindingToDestination(myUnit.ParentScen, waypoint.Latitude, waypoint.Longitude, 1f);
							}
							if (node == null && flag && !base.PathFindingInProgress)
							{
								if (!base.HasPathfindingPlottedCourse)
								{
									TriggerPathfinderThread(null, myUnit, null, theIngressPath: false, 0.15f, PlottedCourse[0].Latitude, PlottedCourse[0].Longitude, myUnit.ParentScen, ManouverTowardsTarget: false);
								}
								else if (PlottedCourse.Count() > 1 && PlottedCourse[0].Type == Waypoint.WaypointType.PathfindingPoint)
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
										if (!myUnit.IsAircraft)
										{
											if (Math2.CalcDist_Angular(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[0].Latitude, PlottedCourse[0].Longitude) < 0.05)
											{
												ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
												ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
												RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
											}
										}
										else
										{
											ApplyWaypointSpeedAltToUnit(PlottedCourse[0]);
											ApplyWaypointDoctrineToUnit(PlottedCourse[0]);
											RemoveWaypoint_Soft(PlottedCourse[0], RemoveWingmanWaypoints: false);
										}
									}
								}
							}
						}
					}
					HeadToFirstWaypoint(elapsedTime);
					bool ForceWaypointSwitch = false;
					bool ForceStationAbort = false;
					CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch, ref ForceStationAbort);
				}
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200321309452837482913", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		myUnit.AI.Common_FollowRoadNetwork(elapsedTime);
	}

	static AggregateGroundUnit_Navigator()
	{
		Class72.smethod_20();
	}
}
