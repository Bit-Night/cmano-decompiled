using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Ship_Navigator : ActiveUnit_Navigator
{
	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Ship_Navigator");
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
			ex2?.Data.Add("Error at 100791", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public new static Ship_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected O, but got Unknown
		Ship_Navigator result;
		try
		{
			Ship_Navigator ship_Navigator = new Ship_Navigator(ref theAU);
			ship_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "TankerFollowsMe_NumberOfWaypoints":
					ship_Navigator.TankerFollowsMe_NumberOfWaypoints = Conversions.ToInteger(val.InnerText);
					break;
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					ship_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "SD":
					ship_Navigator.SprintDrift = true;
					break;
				case "AvCav":
					ship_Navigator.AvoidCavitation = Misc.ParseBool(val.InnerText);
					break;
				case "SD_M":
				{
					string[] array = val.InnerText.Split(new char[1] { '_' });
					ship_Navigator.SprintDrift_Marker = new GeoPoint(XmlConvert.ToDouble(array[0]), XmlConvert.ToDouble(array[1]));
					break;
				}
				case "PreviousWaypointType":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						ship_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					else
					{
						ship_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					break;
				case "FS_B":
				case "FormationStation_Bearing":
					ship_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SD_Avg":
					ship_Navigator.SprintDrift_AverageSpeed = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MPO":
				case "ManualPlotOverride":
					ship_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "FS_BT":
					ship_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint waypoint = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						if (waypoint.Latitude != 0.0 || waypoint.Longitude != 0.0)
						{
							ArrayExtensions.Add(ref ship_Navigator._PlottedCourse, waypoint);
						}
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					ship_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "TankerFollowsMe":
					ship_Navigator.TankerFollowsMe = Misc.ParseBool(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					ship_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				}
				}
			}
			result = ship_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100792", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Ship_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Ship_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		NavigationBufferTolerance_Narrow_meters = (int)Math.Round(Math.Min(((Ship)myUnit).Length, 100f) * 2f);
		NavigationBufferTolerance_Wide_meters = 1000;
	}

	public override void PlotCourseToStationArea(float elapsedTime, bool AddWaypointToExistingPlottedCourse)
	{
		base.PlotCourseToStationArea(elapsedTime, AddWaypointToExistingPlottedCourse);
		if (Information.IsNothing((object)myUnit.Kinematics.DesiredSpeedOverride))
		{
			myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
		}
	}

	public override bool HaveReachedPoint(GeoPoint theGeoPoint, float elapsedTime, bool Overshoot = true, bool simplify_calc_for_ACs = false, float? distanceThreshold_nm = null, double SimulationTime = 0.0)
	{
		bool result;
		try
		{
			double latitude = theGeoPoint.Latitude;
			double longitude = theGeoPoint.Longitude;
			float num = Math2.CalcDist(latitude, longitude, myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			int num5;
			if (num > 3f)
			{
				result = false;
			}
			else
			{
				if (myUnit.IsMCMPlatform_ThisPulse == -1)
				{
					myUnit.Determine_IsMCMPlatform();
				}
				if (myUnit.IsMineLayingPlatform_ThisPulse == -1)
				{
					myUnit.Determine_IsMineLayingPlatform();
				}
				double num2 = default(double);
				if (myUnit.IsMCMPlatform_ThisPulse == 0 && myUnit.IsMineLayingPlatform_ThisPulse == 0)
				{
					if (Overshoot)
					{
						num2 = 0.2;
					}
					else
					{
						double num3 = myUnit.CurrentSpeed;
						while (num3 > 0.1)
						{
							double num4 = myUnit.Kinematics.GetDecelerationCapacity(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (float)num3, 0.1f) * 1.333;
							num2 += num3 / 36000.0;
							num3 -= num4;
						}
					}
				}
				else
				{
					num2 = 0.05;
				}
				if ((double)num < num2)
				{
					if (Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
					{
						num5 = 1;
					}
					else
					{
						if (myUnit.ActiveMissionOrPackage().MissionClass != Mission._MissionClass.Patrol || myUnit.IsUsingDippingSonar())
						{
							goto IL_018b;
						}
						if (((Patrol)myUnit.ActiveMissionOrPackage()).Type != GlobalVariables.PatrolType.ASW)
						{
							num5 = 1;
						}
						else
						{
							if (!myUnit.Sensory.HasAvailableDippingSonar)
							{
								goto IL_018b;
							}
							myUnit.DockingOps.AttemptDippingSonar();
							num5 = 1;
						}
					}
					goto IL_018c;
				}
				result = false;
			}
			goto end_IL_0001;
			IL_018b:
			num5 = 1;
			goto IL_018c;
			IL_018c:
			result = (byte)num5 != 0;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100793", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num6;
			if (!Debugger.IsAttached)
			{
				num6 = 0;
			}
			else
			{
				Debugger.Break();
				num6 = 0;
			}
			result = (byte)num6 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Ship_Navigator()
	{
		Class72.smethod_20();
	}
}
