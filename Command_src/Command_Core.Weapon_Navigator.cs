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

public sealed class Weapon_Navigator : ActiveUnit_Navigator
{
	internal Geopoint_Struct? ABMInterceptPoint;

	private Weapon weapon_0;

	internal new FlightPlanInfo FlightInfo;

	protected Weapon myWeapon
	{
		get
		{
			if (weapon_0 == null)
			{
				weapon_0 = (Weapon)myUnit;
			}
			return weapon_0;
		}
	}

	public override Waypoint[] PlottedCourse
	{
		get
		{
			return _PlottedCourse;
		}
		set
		{
			base.PlottedCourse = value;
		}
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("Weapon_Navigator");
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
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100983", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public new static Weapon_Navigator FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		Weapon_Navigator result;
		try
		{
			Weapon_Navigator weapon_Navigator = new Weapon_Navigator(ref theAU);
			weapon_Navigator.myUnit = theAU;
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "PreviousWaypointType":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						weapon_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Enum.Parse(typeof(Waypoint.WaypointType), val.InnerText, ignoreCase: true);
					}
					else
					{
						weapon_Navigator.PreviousWaypointType = (Waypoint.WaypointType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "PreviousWaypointTime":
				{
					DateTime value = DateTime.FromBinary(Conversions.ToLong(val.InnerText));
					weapon_Navigator.PreviousWaypointTime = value;
					break;
				}
				case "FS_B":
				case "FormationStation_Bearing":
					weapon_Navigator.UnitFormationStation.Bearing = XmlConvert.ToSingle(val.InnerText);
					break;
				case "MPO":
				case "ManualPlotOverride":
					weapon_Navigator.ManualPlotOverride = Misc.ParseBool(val.InnerText);
					break;
				case "FS_BT":
					weapon_Navigator.UnitFormationStation.BearingType = (ReferencePoint.OrientationType)Conversions.ToByte(val.InnerText);
					break;
				case "PC":
				case "PlottedCourse":
					foreach (XmlNode childNode2 in val.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint waypoint = Waypoint.FromXML(ref theNode3, ref theDictionary, theAU.ParentScen);
						if (waypoint.Latitude != 0.0 || waypoint.Longitude != 0.0)
						{
							ArrayExtensions.Add(ref weapon_Navigator._PlottedCourse, waypoint);
						}
					}
					break;
				case "FS_D":
				case "FormationStation_Distance":
					weapon_Navigator.UnitFormationStation.Distance = XmlConvert.ToSingle(val.InnerText);
					break;
				case "SupportMission_NextRefPoint":
				case "SM_NRP":
				{
					XmlNode theNode2 = val.ChildNodes[0];
					weapon_Navigator.SupportMission_NextRefPoint = ReferencePoint.FromXML(ref theNode2, ref theDictionary, theAU.ParentScen);
					break;
				}
				}
			}
			result = weapon_Navigator;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100984", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Weapon_Navigator(ref theAU);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Weapon_Navigator(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override void FollowPlottedCourse(float elapsedTime)
	{
		try
		{
			bool ForceWaypointSwitch = false;
			bool ForceStationAbort = false;
			CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch, ref ForceStationAbort);
			HeadToFirstWaypoint(elapsedTime);
			if (myUnit.StateChangedOnThisPulse && myUnit.ThrottleSetting < ActiveUnit.Throttle.Cruise)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Cruise);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100985", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private float method_10(double double_0, double double_1, float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		Geopoint_Struct geopoint_Struct = new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
		Geopoint_Struct thePoint = new Geopoint_Struct(double_1, double_0, float_0);
		float num = geopoint_Struct.RangeToPoint_Slant(thePoint);
		Geodesic_EdWilliams.CalcPoint_Williams(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, float_5 / 360000f, float_4);
		geopoint_Struct.Altitude += float_6 * 1852f / 360000f;
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref thePoint.Longitude, ref thePoint.Latitude, float_2 / 360000f, float_1);
		thePoint.Altitude += float_3 * 1852f / 360000f;
		float num2 = geopoint_Struct.RangeToPoint_Slant(thePoint);
		return (num - num2) * 360000f;
	}

	public static Geopoint_Struct ComputeInterceptPoint_Theoretical(Weapon theWeapon, double launchLat, double launchLon, float launchAlt, Contact theTarget)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		try
		{
			if (theWeapon != null && theTarget != null)
			{
				double value = theWeapon.get_Latitude((GlobalVariables.BooleanObject)null);
				double value2 = theWeapon.get_Longitude((GlobalVariables.BooleanObject)null);
				float value3 = theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				float currentHeading = theWeapon.CurrentHeading;
				theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, launchLat);
				theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, launchLon);
				theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, launchAlt);
				theWeapon.CurrentHeading = Module_Unit.BearingToUnit_True(theWeapon, theTarget);
				theWeapon.Navigator.ABMInterceptPoint = null;
				if (theTarget.IsBallisticTarget())
				{
					Geopoint_Struct? aBMInterceptPoint = theWeapon.Navigator.ABMInterceptPoint;
					result = theWeapon.Navigator.ComputeInterceptPoint_ABM(theTarget);
					theWeapon.Navigator.ABMInterceptPoint = aBMInterceptPoint;
				}
				else
				{
					float num = theWeapon.Kinematics.GetMaximumSpeed(((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(theWeapon, num, theTarget);
					(result, _) = tuple;
					if (!result.HasZeroCoords && theWeapon.UsesBoostCoastModel.Value)
					{
						Weapon.RecalculateWeaponFlightEnergyIfNecessary(theWeapon, theWeapon.ParentScen, theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f, null);
						float num2 = (float)tuple.Item2.TotalSeconds;
						if (num2 > (float)theWeapon.TotalBurnTime)
						{
							float num3 = num2 - (float)theWeapon.TotalBurnTime;
							num = (num * (float)theWeapon.TotalBurnTime + num / 2f * num3) / num2;
							(result, _) = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(theWeapon, num, theTarget);
						}
					}
				}
				theWeapon.set_Latitude((GlobalVariables.BooleanObject)null, value);
				theWeapon.set_Longitude((GlobalVariables.BooleanObject)null, value2);
				theWeapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value3);
				theWeapon.CurrentHeading = currentHeading;
				return result;
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
		return result;
	}

	public Geopoint_Struct ComputeInterceptPoint_Satellite(Contact theTarget)
	{
		Geopoint_Struct result;
		if (theTarget != null && theTarget.ActualUnit != null && theTarget.ActualUnit.IsSatellite)
		{
			Satellite satellite = (Satellite)theTarget.ActualUnit;
			Weapon_Kinematics kinematics = myWeapon.Kinematics;
			try
			{
				bool isDLZconstruct = myWeapon.IsDLZconstruct;
				float num = kinematics.GetMaximumSpeed();
				bool flag = myUnit.CurrentSpeed < num && (!myWeapon.UsesBoostCoastModel.Value || myWeapon.TimeSinceLaunch <= (float)myWeapon.TotalBurnTime);
				DateTime dateTime = myWeapon.ParentScen.Time;
				if (isDLZconstruct)
				{
					dateTime = dateTime.AddSeconds(myWeapon.TimeSinceLaunch);
				}
				float num2 = Module_Unit.RangeToUnit_Slant(myUnit, theTarget);
				float float_;
				float float_2;
				if (flag)
				{
					float num3 = Math.Max(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), kinematics.GetMinimumAltitude());
					float num4 = myUnit.RangeToUnit_Horiz(theTarget) / num2;
					float num5 = (((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3) * 0.000539957f / num2;
					float maxSpeed = myWeapon.MaxSpeed;
					float_ = maxSpeed * num4;
					float_2 = maxSpeed * num5;
				}
				else
				{
					float_ = Module_Unit.CurrentSpeed_Horizontal(myWeapon);
					float_2 = myUnit.CurrentSpeed * (float)Math2.Sind(myUnit.Attitude_Pitch);
				}
				double Latitude = default(double);
				double Longitude = default(double);
				double Altitude_Km = default(double);
				double Speed_knots = default(double);
				satellite.Kinematics.PredictPosition(dateTime.AddSeconds(1.0), ref Latitude, ref Longitude, ref Altitude_Km, ref Speed_knots);
				float num6 = (float)((Altitude_Km * 1000.0 - (double)((ActiveUnit)satellite).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * 0.000539957 * 3600.0);
				float num7;
				int num8;
				if (num6 == 0f)
				{
					num7 = (float)Speed_knots;
					num8 = 0;
				}
				else
				{
					num7 = Module_Unit.RangeToPoint_Horiz(satellite, Latitude, Longitude, GlobalVariables.ObjectTrue) * 3600f;
					num8 = 0;
				}
				int num9 = num8;
				float num10 = 0f;
				float num12 = default(float);
				while (true)
				{
					num9++;
					float num11 = method_10(((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theTarget.CurrentHeading, num7, num6, myUnit.CurrentHeading, float_, float_2);
					if (!(num11 <= 0f))
					{
						num10 = num12;
						num12 = num2 / num11 * 3600f;
						if (num12 >= 1f)
						{
							if (isDLZconstruct)
							{
								int num13 = 0;
								num13 = ((!myWeapon.FlightEndurance.HasValue) ? myWeapon.FuelCapacityCurrent : myWeapon.FlightEndurance.Value);
								if (!(num12 + myWeapon.TimeSinceLaunch <= (float)num13))
								{
									result = default(Geopoint_Struct);
									break;
								}
							}
							Geopoint_Struct geopoint_Struct = new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							DateTime theTime = dateTime.AddSeconds(num12);
							satellite.Kinematics.PredictPosition(theTime, ref Latitude, ref Longitude, ref Altitude_Km, ref Speed_knots);
							float num14 = (float)Altitude_Km * 1000f;
							num6 = (num14 - geopoint_Struct.Altitude) * 0.000539957f / num12 * 3600f;
							num7 = ((num6 != 0f) ? (Math2.CalcDist(geopoint_Struct.Latitude, geopoint_Struct.Longitude, Latitude, Longitude) / num12 * 3600f) : ((float)Speed_knots));
							if (flag)
							{
								Geopoint_Struct thePoint = new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null));
								Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref thePoint.Longitude, ref thePoint.Latitude, num7 / 3600f * num12, theTarget.CurrentHeading);
								thePoint.Altitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num6 / 3600f * num12;
								float num15 = Module_Unit.RangeToPoint_Slant(myUnit, thePoint);
								float num16 = Module_Unit.RangeToPoint_Horiz(myUnit, thePoint) / num15;
								float num17 = (thePoint.Altitude - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * 0.000539957f / num15;
								float num18 = myUnit.CurrentSpeed;
								float num19 = myUnit.CurrentSpeed;
								float num20 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								float num21 = num;
								float num22 = num12;
								for (float num23 = 1f; num23 <= num22; num23 += 1f)
								{
									num20 += num19 * num17 / 3600f * 1852f;
									num21 = kinematics.GetMaximumSpeed(num20);
									if (num19 < num21)
									{
										num19 += kinematics.Acceleration_Actual(ActiveUnit.Throttle.Cruise, num20, num21);
									}
									if (num19 > num21)
									{
										num19 = num21;
									}
									num18 += num19;
								}
								num18 /= num12;
								float_ = num18 * num16;
								float_2 = num18 * num17;
							}
							if (!(Math.Abs(num10 - num12) >= 1f) || num9 >= 3)
							{
								return new Geopoint_Struct(Longitude, Latitude, num14);
							}
							continue;
						}
						return new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
					result = default(Geopoint_Struct);
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
				result = default(Geopoint_Struct);
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = default(Geopoint_Struct);
		}
		return result;
	}

	public Geopoint_Struct ComputeInterceptPoint_ABM(Contact theTarget)
	{
		if (ABMInterceptPoint.HasValue)
		{
			return ABMInterceptPoint.Value;
		}
		Weapon_Kinematics kinematics = myWeapon.Kinematics;
		Geopoint_Struct result;
		try
		{
			float num = kinematics.GetMaximumSpeed();
			bool flag = theTarget.ActualUnit.IsWeapon && ((Weapon)theTarget.ActualUnit).IsBallisticTargetManeuvering();
			bool flag2 = !(myUnit.CurrentSpeed >= num) && (!myWeapon.UsesBoostCoastModel.Value || myWeapon.TimeSinceLaunch <= (float)myWeapon.TotalBurnTime);
			DateTime dateTime = myWeapon.ParentScen.Time;
			if (myWeapon.IsDLZconstruct)
			{
				dateTime = dateTime.AddSeconds(myWeapon.TimeSinceLaunch);
			}
			float num2 = Module_Unit.RangeToUnit_Slant(myUnit, theTarget);
			float float_;
			float float_2;
			if (!flag2)
			{
				float_ = Module_Unit.CurrentSpeed_Horizontal(myWeapon);
				float_2 = myUnit.CurrentSpeed * (float)Math2.Sind(myUnit.Attitude_Pitch);
			}
			else
			{
				float num3 = Math.Max(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), kinematics.GetMinimumAltitude());
				float num4 = myUnit.RangeToUnit_Horiz(theTarget) / num2;
				float num5 = (((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num3) * 0.000539957f / num2;
				float maxSpeed = myWeapon.MaxSpeed;
				float_ = maxSpeed * num4;
				float_2 = maxSpeed * num5;
			}
			float num6 = Module_Unit.CurrentSpeed_Horizontal(theTarget.ActualUnit);
			float num7 = theTarget.ActualUnit.CurrentSpeed * (float)Math2.Sind(theTarget.ActualUnit.Attitude_Pitch);
			bool flag3 = false;
			int num8 = 0;
			float num9 = 0f;
			float num11 = default(float);
			TrajectoryPoint? trajectoryPoint = default(TrajectoryPoint?);
			while (true)
			{
				num8++;
				float num10 = method_10(((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theTarget.CurrentHeading, num6, num7, myUnit.CurrentHeading, float_, float_2);
				if (!(num10 <= 0f))
				{
					num9 = num11;
					num11 = num2 / num10 * 3600f;
					if (num11 >= 1f)
					{
						if (myWeapon.IsDLZconstruct)
						{
							int num12 = 0;
							num12 = (myWeapon.FlightEndurance.HasValue ? myWeapon.FlightEndurance.Value : myWeapon.FuelCapacityCurrent);
							if (!(num11 + myWeapon.TimeSinceLaunch <= (float)num12))
							{
								ABMInterceptPoint = null;
								result = default(Geopoint_Struct);
								break;
							}
						}
						if (!flag)
						{
							if (theTarget.FutureBallisticPath == null || theTarget.FutureBallisticPath.Count() == 0)
							{
								theTarget.FutureBallisticPath = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(theTarget, myUnit.ParentScen);
							}
							Geopoint_Struct geopoint_Struct = new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							DateTime t = dateTime.AddSeconds(num11);
							TrajectoryPoint[] futureBallisticPath = theTarget.FutureBallisticPath;
							for (int i = 0; i < futureBallisticPath.Length; i = checked(i + 1))
							{
								TrajectoryPoint value = futureBallisticPath[i];
								if (DateTime.Compare(value.TimeZulu, dateTime) > 0)
								{
									if (DateTime.Compare(value.TimeZulu, t) > 0)
									{
										break;
									}
									trajectoryPoint = value;
								}
							}
							if (trajectoryPoint.HasValue)
							{
								num6 = Math2.CalcDist(geopoint_Struct.Latitude, geopoint_Struct.Longitude, trajectoryPoint.Value.Latitude, trajectoryPoint.Value.Longitude) / num11 * 3600f;
								num7 = (trajectoryPoint.Value.Altitude - geopoint_Struct.Altitude) * 0.000539957f / num11 * 3600f;
								flag3 = true;
							}
						}
						if (flag2)
						{
							Geopoint_Struct thePoint = new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null));
							Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref thePoint.Longitude, ref thePoint.Latitude, num6 / 3600f * num11, theTarget.CurrentHeading);
							thePoint.Altitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num7 / 3600f * num11;
							float num13 = Module_Unit.RangeToPoint_Slant(myUnit, thePoint);
							float num14 = Module_Unit.RangeToPoint_Horiz(myUnit, thePoint) / num13;
							float num15 = (thePoint.Altitude - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * 0.000539957f / num13;
							float num16 = myUnit.CurrentSpeed;
							float num17 = myUnit.CurrentSpeed;
							float num18 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							float num19 = num;
							float num20 = num11;
							for (float num21 = 1f; num21 <= num20; num21 += 1f)
							{
								num18 += num17 * num15 / 3600f * 1852f;
								num19 = kinematics.GetMaximumSpeed(num18);
								if (num17 < num19)
								{
									num17 += kinematics.Acceleration_Actual(ActiveUnit.Throttle.Cruise, num18, num19);
								}
								if (num17 > num19)
								{
									num17 = num19;
								}
								num16 += num17;
							}
							num16 /= num11;
							float_ = num16 * num14;
							float_2 = num16 * num15;
							flag3 = true;
						}
						if (flag3 && Math.Abs(num9 - num11) >= 1f && num8 < 3)
						{
							continue;
						}
						if (flag)
						{
							Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
							float distance_NM = Module_Unit.CurrentSpeed_Horizontal(theTarget.ActualUnit) / 3600f * num11;
							float num22 = (float)((double)(num7 / 3600f) * 1852.0) * num11;
							Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, distance_NM, theTarget.CurrentHeading);
							geopoint_Struct2.Altitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num22;
							if (!(geopoint_Struct2.Altitude < 0f) && (!(myWeapon.MaxTargetAlt_ASL > 0f) || geopoint_Struct2.Altitude <= myWeapon.MaxTargetAlt_ASL))
							{
								ABMInterceptPoint = geopoint_Struct2;
								return geopoint_Struct2;
							}
							ABMInterceptPoint = null;
							result = default(Geopoint_Struct);
							break;
						}
						DateTime dateTime2 = dateTime.AddSeconds(num11);
						if (theTarget.FutureBallisticPath.Length == 0)
						{
							theTarget.FutureBallisticPath = BallisticMissile_Kinematics.EstimatedFuturePathOfBallisticTarget(theTarget, myWeapon.ParentScen);
						}
						if (DateTime.Compare(theTarget.FutureBallisticPath.Last().TimeZulu, dateTime2) < 0)
						{
							ABMInterceptPoint = null;
							result = default(Geopoint_Struct);
							break;
						}
						TrajectoryPoint initialPosition = new TrajectoryPoint(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), dateTime);
						TrajectoryPoint? exactPointAtTime = TrajectoryPoint.GetExactPointAtTime(theTarget.FutureBallisticPath, initialPosition, dateTime2);
						if (!exactPointAtTime.HasValue)
						{
							ABMInterceptPoint = new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						}
						else
						{
							if (exactPointAtTime.Value.Altitude > myUnit.Kinematics.GetMaximumAltitude())
							{
								ABMInterceptPoint = null;
								result = default(Geopoint_Struct);
								break;
							}
							ABMInterceptPoint = exactPointAtTime.Value.ToGeoPointStruct();
						}
						return ABMInterceptPoint.Value;
					}
					ABMInterceptPoint = null;
					return new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				}
				ABMInterceptPoint = null;
				result = default(Geopoint_Struct);
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
			ABMInterceptPoint = null;
			result = new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void ClearPlottedCourse(bool PlayerIsPlottingCourse = false, bool ClearResumeFlightPlanWaypoint = true)
	{
		ArrayExtensions.Clear(ref _PlottedCourse);
		ArrayExtensions.Clear(ref _PlottedCourse_PrePlanned);
	}

	public Geopoint_Struct ComputeIntercept_3D(Contact theTarget)
	{
		Geopoint_Struct result = default(Geopoint_Struct);
		if (theTarget != null)
		{
			float num = Module_Unit.CurrentSpeed_Horizontal(theTarget);
			float float_ = Module_Unit.CurrentSpeed_Horizontal(myUnit);
			float num2 = ((theTarget.ActualUnit == null || !theTarget.ActualUnit.SupportsAttitude_Pitch) ? ((float)((double)Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen) * 1.94384)) : ((float)((double)theTarget.CurrentSpeed * Math2.Sind(theTarget.ActualUnit.Attitude_Pitch))));
			float num3 = method_10(float_6: myUnit.SupportsAttitude_Pitch ? ((float)((double)myUnit.CurrentSpeed * Math2.Sind(myUnit.Attitude_Pitch))) : ((float)((double)Module_Unit.CurrentSpeed_Vertical(myUnit, myUnit.ParentScen) * 1.94384)), double_0: ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), double_1: ((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), float_0: ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), float_1: theTarget.CurrentHeading, float_2: num, float_3: num2, float_4: myUnit.CurrentHeading, float_5: float_);
			if (num3 > 0f)
			{
				float num4 = Module_Unit.RangeToUnit_Slant(myUnit, theTarget, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) / num3;
				float distance_NM = num4 * num;
				Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)theTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref result.Longitude, ref result.Latitude, distance_NM, theTarget.CurrentHeading);
				float num5 = (float)((double)(num4 * num2) * 1852.0);
				result.Altitude = ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num5;
			}
		}
		return result;
	}

	public Geopoint_Struct ComputeInterceptPoint_BruteForce(float mySpeed, Contact theTarget, float ClosureRate = float.MinValue, float RangeToTargetHoriz = -1f)
	{
		Geopoint_Struct result;
		try
		{
			if (theTarget.CurrentSpeed == 0f && Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen) == 0f)
			{
				return new Geopoint_Struct(((Module_Unit.Unit)theTarget).get_Longitude(GlobalVariables.ObjectTrue), ((Module_Unit.Unit)theTarget).get_Latitude(GlobalVariables.ObjectTrue), ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue));
			}
			if (ClosureRate == float.MinValue)
			{
				ClosureRate = Module_Unit.ClosureSpeed(myUnit, theTarget, mySpeed, myUnit.CurrentHeading);
			}
			if (!(ClosureRate <= 0f) && !double.IsNaN(ClosureRate))
			{
				bool num = theTarget.ActualUnit != null && theTarget.ActualUnit.SupportsAttitude_Pitch && Math.Abs(theTarget.ActualUnit.Attitude_Pitch) > 60f;
				float num2 = ((!(RangeToTargetHoriz > -1f)) ? myUnit.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue) : RangeToTargetHoriz);
				float num3 = (long)Math.Round(num2 / ClosureRate * 3600f);
				float num4 = num3 / 3600f * theTarget.CurrentSpeed;
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(distance_NM: num ? (num3 / 3600f * Module_Unit.CurrentSpeed_Horizontal(theTarget.ActualUnit)) : (num3 / 3600f * theTarget.CurrentSpeed), Lon1: ((Module_Unit.Unit)theTarget).get_Longitude(GlobalVariables.ObjectTrue), Lat1: ((Module_Unit.Unit)theTarget).get_Latitude(GlobalVariables.ObjectTrue), out_lon2: ref out_lon, out_lat2: ref out_lat, bearing: theTarget.CurrentHeading);
				float num5 = (theTarget.IsBallisticTarget() ? (((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue) + Module_Unit.CurrentSpeed_Vertical(theTarget, myUnit.ParentScen) * num3) : ((Module_Unit.Unit)theTarget).get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue));
				if (myWeapon.IsAerospaceUnit && num5 < (float)Terrain.GlobalMaxTerrainElevation)
				{
					short elevation = Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, myUnit.ParentScen);
					if (num5 < (float)elevation)
					{
						num5 = (float)((double)elevation + 0.01);
						if (num5 < 0f)
						{
							num5 = 0.01f;
						}
					}
				}
				return new Geopoint_Struct(out_lon, out_lat, num5);
			}
			result = default(Geopoint_Struct);
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
			result = default(Geopoint_Struct);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal (bool result, double ETA) PlanComplexCourse(ActiveUnit Shooter)
	{
		(bool, double) result = default((bool, double));
		try
		{
			if (!Information.IsNothing((object)myUnit.AI.PrimaryTarget))
			{
				float num = Shooter.RangeToUnit_Horiz(myUnit.AI.PrimaryTarget);
				float num2 = Module_Unit.BearingToUnit_True(Shooter, myUnit.AI.PrimaryTarget);
				float num3 = ((Weapon)myUnit).get_MaxRangeForThisTarget(myUnit, myUnit.AI.PrimaryTarget, CheckWRA: false, Shooter.Doctrine, ManualFire: false);
				List<Waypoint> list = new List<Waypoint>();
				LockRandom lockRandom_ = GameGeneral.GlobalRNG;
				if (myUnit.AI.PrimaryTarget.ActualUnit != null)
				{
					if (myUnit.AI.PrimaryTarget.isSurfaceOrLandContact && (myWeapon.IsMissile & myWeapon.SupportsWaypoints))
					{
						try
						{
							if (myUnit.Doctrine.get_Item(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value != Doctrine._UseWpMissileAgainstShips.Yes)
							{
								AddWaypoint(new Waypoint(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
							}
						}
						catch (Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							if (myWeapon.FiringParent != null && myWeapon.FiringParent.Doctrine.get_Item(myUnit.ParentScen, MultipleUnits: false, ViaDoctrineForm: false, ViaRightColumn: false).Value != Doctrine._UseWpMissileAgainstShips.Yes)
							{
								AddWaypoint(new Waypoint(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
							}
							ProjectData.ClearProjectError();
						}
					}
					if (PlottedCourse.Length > 0)
					{
						result = method_11(Shooter, myUnit.AI.PrimaryTarget);
						return result;
					}
					int num4 = 1;
					double out_lon = default(double);
					double out_lat = default(double);
					do
					{
						int num5 = (Shooter.IsAircraft ? lockRandom_.Next(-45, 46) : lockRandom_.Next(-80, 81));
						int num6 = lockRandom_.Next(1, (int)Math.Round(num / 2f));
						Geodesic_EdWilliams.CalcPoint_Williams(Shooter.get_Longitude((GlobalVariables.BooleanObject)null), Shooter.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num6, Math2.NormalizeBearing(num2 + (float)num5));
						float num7 = Module_Unit.RangeToPoint_Horiz(Shooter, out_lat, out_lon);
						float num8 = Module_Unit.RangeToPoint_Horiz(myUnit.AI.PrimaryTarget, out_lat, out_lon);
						if (num7 + num8 < num3)
						{
							list.Add(new Waypoint(out_lon, out_lat, 0f, Waypoint.WaypointType.TurningPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
						}
						num4++;
					}
					while (num4 <= 10000);
					if (list.Count == 0)
					{
						result = method_11(Shooter, myUnit.AI.PrimaryTarget);
						return result;
					}
					if (list.Count == 1)
					{
						AddWaypoint(list[0]);
					}
					else
					{
						Waypoint theWP = list[lockRandom_.Next(0, list.Count)];
						AddWaypoint(theWP);
					}
				}
				AddWaypoint(new Waypoint(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				result = method_11(Shooter, myUnit.AI.PrimaryTarget);
				return result;
			}
			result = (false, 0.0);
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 55555476865", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private (bool, double) method_11(ActiveUnit activeUnit_0, Contact contact_0)
	{
		double num = 0.0;
		int num2 = PlottedCourse.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			if (i != 0)
			{
				float num3 = Math2.CalcDist(PlottedCourse[i - 1].Latitude, PlottedCourse[i - 1].Longitude, PlottedCourse[i].Latitude, PlottedCourse[i].Longitude);
				num += (double)num3;
			}
			else
			{
				num += (double)Math2.CalcDist(activeUnit_0.get_Latitude((GlobalVariables.BooleanObject)null), activeUnit_0.get_Longitude((GlobalVariables.BooleanObject)null), PlottedCourse[i].Latitude, PlottedCourse[i].Longitude);
			}
		}
		int num4 = PlottedCourse.Length - 1;
		num += (double)Math2.CalcDist(PlottedCourse[num4].Latitude, PlottedCourse[num4].Longitude, ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null));
		float num5 = 0f;
		num5 = Module_Unit.ClosureSpeed(activeUnit_0, ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), contact_0.CurrentHeading, contact_0.CurrentSpeed, activeUnit_0.CurrentSpeed, activeUnit_0.CurrentHeading);
		double num6 = (double)(myUnit.GetSpeedForETACalculation((float)num) + num5) * 0.514444;
		if (num6 <= 0.0)
		{
			num6 *= -1.0;
		}
		double item = num * 1852.0 / num6;
		return (true, item);
	}

	private Geopoint_Struct? method_12(float float_0)
	{
		Geopoint_Struct? result;
		try
		{
			Waypoint waypoint;
			Weapon weapon;
			double num;
			double num2;
			float num3;
			double num4;
			if (myUnit.AI.PrimaryTarget == null)
			{
				result = null;
			}
			else
			{
				waypoint = new Waypoint();
				weapon = (Weapon)myUnit;
				waypoint.Type = Waypoint.WaypointType.TerminalPoint;
				if (HasPlottedCourse())
				{
					if (PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
					{
						if (PlottedCourse.Count() > 1)
						{
							num = PlottedCourse[PlottedCourse.Count() - 2].Latitude;
							num2 = PlottedCourse[PlottedCourse.Count() - 2].Longitude;
							num3 = PlottedCourse[PlottedCourse.Count() - 2].Altitude;
						}
						else
						{
							num = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							num2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
							num3 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						}
					}
					else
					{
						num = PlottedCourse[PlottedCourse.Count() - 1].Latitude;
						num2 = PlottedCourse[PlottedCourse.Count() - 1].Longitude;
						num3 = PlottedCourse[PlottedCourse.Count() - 1].Altitude;
					}
				}
				else
				{
					num = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					num2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
					num3 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
				num4 = 0.0;
				waypoint.Altitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				Weapon.WeaponGuidanceType guidance = weapon.Guidance;
				if (guidance == Weapon.WeaponGuidanceType.Inertial)
				{
					try
					{
						if (!(myUnit.AI.PrimaryTarget.CurrentSpeed > 0f))
						{
							waypoint.Latitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
							waypoint.Longitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
							goto end_IL_019d;
						}
						double? num5 = ActiveUnit_Navigator.CalculateInterceptHeading(num, num2, myUnit.CurrentHeading, myUnit.AI.PrimaryTarget, float_0);
						if (!num5.HasValue)
						{
							(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, float_0, myUnit.AI.PrimaryTarget);
							if (!tuple.Item1.HasZeroCoords)
							{
								num5 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
							}
						}
						if (num5.HasValue)
						{
							Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
							if (num5.Value < 0.0)
							{
								geopoint_Struct = ComputeInterceptPoint_BruteForce(float_0, myUnit.AI.PrimaryTarget);
								num5 = Module_Unit.BearingToPoint_True(myWeapon, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
							}
							float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, myUnit.AI.BearingToUnit_True(myUnit.AI.PrimaryTarget));
							if ((relativeBearing > 10f && relativeBearing < 350f) || (relativeBearing > 170f && relativeBearing < 190f))
							{
								geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(num2, num), num5.Value, new Geopoint_Struct(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), myUnit.AI.PrimaryTarget.CurrentHeading);
							}
							if (geopoint_Struct.HasZeroCoords)
							{
								Geopoint_Struct geopoint_Struct2 = ComputeInterceptPoint_BruteForce(float_0, myUnit.AI.PrimaryTarget);
								if (!geopoint_Struct2.HasZeroCoords)
								{
									waypoint.Latitude = geopoint_Struct2.Latitude;
									waypoint.Longitude = geopoint_Struct2.Longitude;
								}
								else
								{
									waypoint.Latitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
									waypoint.Longitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
								}
							}
							else
							{
								waypoint.Latitude = geopoint_Struct.Latitude;
								waypoint.Longitude = geopoint_Struct.Longitude;
							}
							goto end_IL_019d;
						}
						result = null;
						goto end_IL_0001;
						end_IL_019d:;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 101230", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					goto IL_0b9c;
				}
				try
				{
					double[] array = new double[myWeapon.WeaponSensors().Count + 1];
					if (myWeapon.WeaponSensors().Count == 0)
					{
						Warhead[] warheads = weapon.Warheads;
						foreach (Warhead warhead in warheads)
						{
							if (warhead.Type != Warhead.WarheadType.Weapon)
							{
								continue;
							}
							Weapon weapon2 = warhead.get_CarriedWeapon(weapon.ParentScen);
							int num6 = weapon2.WeaponSensors().Count - 1;
							for (int j = 0; j <= num6; j++)
							{
								if (weapon2.WeaponSensors()[j].Type != Sensor.Sensor_Type.ESM || weapon.ValidTargets.Radar)
								{
									array[j] = weapon2.WeaponSensors()[j].maxRange;
								}
							}
						}
						num4 = array.Max();
					}
					else
					{
						int num7 = myWeapon.WeaponSensors().Count - 1;
						for (int k = 0; k <= num7; k++)
						{
							if (myWeapon.WeaponSensors()[k].Type != Sensor.Sensor_Type.ESM || weapon.ValidTargets.Radar)
							{
								array[k] = myWeapon.WeaponSensors()[k].maxRange;
							}
						}
						num4 = array.Max();
					}
					if (((Weapon)myUnit).IsMissile && myUnit.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
					{
						num4 = 0.0;
						waypoint.Latitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
						waypoint.Longitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
						waypoint.Altitude = 0f;
					}
					float num8;
					float num10;
					double num12;
					double num13;
					double? num15;
					double num17;
					if (myUnit.AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && myUnit.AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
					{
						num8 = Math2.CalcDist(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), num, num2);
						float num9 = Module_Unit.RangeToPoint_Slant(myUnit.AI.PrimaryTarget, num, num2, num3);
						num10 = myUnit.CurrentSpeed / 3600f * 2f * myUnit.ParentScen.GameResolution;
						double num11 = num4 * 0.75;
						num12 = Module_Unit.GrazingAngleToUnit(myWeapon, myUnit.AI.PrimaryTarget);
						if (num12 < 0.0)
						{
							num12 = 90.0 - Math.Asin(num8 / num9) * 57.2957795130823;
						}
						num13 = num11 * Math2.Cosd(num12);
						double num14 = num11 * Math2.Sind(num12) * 1852.0;
						waypoint.Altitude = (float)num14;
						if (myUnit.AI.PrimaryTarget.CurrentSpeed > 0f)
						{
							num15 = ActiveUnit_Navigator.CalculateInterceptHeading(num, num2, myUnit.CurrentHeading, myUnit.AI.PrimaryTarget, float_0);
							if (num15.HasValue)
							{
								double? num16 = num15;
								if (((!num16.HasValue) ? ((bool?)null) : new bool?(num16.GetValueOrDefault() < 0.0)) != true)
								{
									goto IL_0887;
								}
							}
							(Geopoint_Struct, TimeSpan) tuple2 = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, float_0, myUnit.AI.PrimaryTarget);
							if (!tuple2.Item1.HasZeroCoords)
							{
								num15 = Module_Unit.BearingToPoint_True(myUnit, tuple2.Item1.Latitude, tuple2.Item1.Longitude);
							}
							goto IL_0887;
						}
						if ((double)num9 > num4)
						{
							num17 = (double)num8 - num13;
							if (num17 < (double)num10)
							{
								num17 = 0.0001;
							}
						}
						else
						{
							num17 = (double)num8 * 0.5;
							if (num17 < (double)num10)
							{
								num17 = 0.0001;
							}
						}
						double lon = num2;
						double lat = num;
						Waypoint waypoint2;
						double out_lon = (waypoint2 = waypoint).Longitude;
						Waypoint waypoint3;
						double out_lat = (waypoint3 = waypoint).Latitude;
						Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, (float)num17, Math2.CalcAzimuth(num, num2, ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
						waypoint3.Latitude = out_lat;
						waypoint2.Longitude = out_lon;
						goto IL_0b03;
					}
					waypoint.Latitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
					waypoint.Longitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
					goto IL_0b9c;
					IL_0887:
					if (num15.HasValue)
					{
						Geopoint_Struct geopoint_Struct3 = MathFunctions.Intersection(new Geopoint_Struct(num2, num), num15.Value, new Geopoint_Struct(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), myUnit.AI.PrimaryTarget.CurrentHeading);
						if (geopoint_Struct3.HasZeroCoords)
						{
							if ((double)num8 > num13)
							{
								num17 = num8 / 2f;
								if (num17 < (double)num10)
								{
									num17 = 0.0001;
								}
							}
							else
							{
								num17 = 0.0001;
							}
							double lon2 = num2;
							double lat2 = num;
							Waypoint waypoint2;
							double out_lon = (waypoint2 = waypoint).Longitude;
							Waypoint waypoint3;
							double out_lat = (waypoint3 = waypoint).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(lon2, lat2, ref out_lon, ref out_lat, (float)num17, (float)num15.Value);
							waypoint3.Latitude = out_lat;
							waypoint2.Longitude = out_lon;
						}
						else
						{
							float num18 = Math2.CalcDist(num, num2, geopoint_Struct3.Latitude, geopoint_Struct3.Longitude);
							if ((double)num18 < num13)
							{
								num17 = 0.0001;
							}
							else if ((double)num18 > (double)num8 - num13)
							{
								num17 = num18 - (float)((double)num18 - ((double)num8 - num13));
								if (num17 <= 0.0)
								{
									num17 = 0.0001;
								}
								if (num17 < (double)num10)
								{
									num17 = 0.0001;
								}
							}
							else
							{
								num17 = (double)num18 - num13;
								if (num17 < (double)num10)
								{
									num17 = 0.0001;
								}
							}
							double lon3 = num2;
							double lat3 = num;
							Waypoint waypoint3;
							double out_lat = (waypoint3 = waypoint).Longitude;
							Waypoint waypoint2;
							double out_lon = (waypoint2 = waypoint).Latitude;
							Geodesic_EdWilliams.CalcPoint_Williams(lon3, lat3, ref out_lat, ref out_lon, (float)num17, Math2.CalcAzimuth(num, num2, geopoint_Struct3.Latitude, geopoint_Struct3.Longitude));
							waypoint2.Latitude = out_lon;
							waypoint3.Longitude = out_lat;
						}
						goto IL_0b03;
					}
					result = null;
					goto end_IL_049c;
					IL_0b03:
					waypoint.Altitude = num3 - (float)(num17 * Math2.Sind(num12) * 1852.0);
					goto IL_0b9c;
					end_IL_049c:;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 101231", "");
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
					goto IL_0b9c;
				}
			}
			goto end_IL_0001;
			IL_0b9c:
			if (((Weapon)myUnit).Warheads.Length > 0)
			{
				if (!((Weapon)myUnit).Warheads[0].get_IsAirburst((Weapon)myUnit, myUnit.AI.PrimaryTarget.ActualUnit))
				{
					waypoint.Altitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if (weapon.HasTerminalGuidance)
					{
						double num19 = num4 * 0.75;
						double num20 = Module_Unit.GrazingAngleToUnit(myWeapon, myUnit.AI.PrimaryTarget);
						if (num20 < 0.0)
						{
							float num21 = Math2.CalcDist(((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), num, num2);
							float num22 = Module_Unit.RangeToPoint_Slant(myUnit.AI.PrimaryTarget, num, num2, num3);
							num20 = 90.0 - Math.Asin(num21 / num22) * 57.2957795130823;
						}
						double num23 = num19 * Math2.Sind(num20) * 1852.0;
						waypoint.Altitude = (float)num23;
					}
				}
				else
				{
					waypoint.Altitude = ((Module_Unit.Unit)myUnit.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Weapon)myUnit).get_OptimumBurstHeight_AGL(myUnit.AI.PrimaryTarget.ActualUnit);
				}
			}
			if (((Weapon)myUnit).Type == Weapon._WeaponType.Decoy_Expendable)
			{
				waypoint.Altitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			else if (((Weapon)myUnit).IsAAWCapable && !((Weapon)myUnit).IsASuW_Land && !((Weapon)myUnit).IsASuW_Naval)
			{
				Contact_Base.ContactType type = myUnit.AI.PrimaryTarget.Type;
				if (type == Contact_Base.ContactType.Aimpoint || type == Contact_Base.ContactType.ActivationPoint)
				{
					waypoint.Altitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
			}
			if (Has_NonPathfind_NonFP_PlottedCourse() && PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
			{
				PlottedCourse[PlottedCourse.Count() - 1].Latitude = waypoint.Latitude;
				PlottedCourse[PlottedCourse.Count() - 1].Longitude = waypoint.Longitude;
				PlottedCourse[PlottedCourse.Count() - 1].Altitude = waypoint.Altitude;
			}
			else
			{
				AddWaypoint(waypoint.Latitude, waypoint.Longitude, waypoint.Altitude, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
			}
			return new Geopoint_Struct(waypoint.Longitude, waypoint.Latitude, waypoint.Altitude);
			end_IL_0001:;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 1023402354934956349568349586123", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal void RefineTerminalPoint_BoostCoast(float WeaponNominalSpeed, bool isAirDroppedTorpedo = false)
	{
		if (weapon_0 == null)
		{
			weapon_0 = myWeapon;
		}
		if (weapon_0.CruiseAltitude_ASL > 0f && weapon_0.UsesBoostCoastModel.Value && HasPlottedCourse() && PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
		{
			Geopoint_Struct thePoint = PlottedCourse.Last().ToGeopoint_Struct();
			float num = WeaponNominalSpeed;
			float num2 = (float)((double)Math.Abs(weapon_0.CruiseAltitude_ASL - weapon_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) * 0.000539957);
			float num3 = (float)((double)Math.Abs(weapon_0.CruiseAltitude_ASL - thePoint.Altitude) * 0.000539957);
			float num4 = Module_Unit.RangeToPoint_Horiz(weapon_0, thePoint, GlobalVariables.ObjectTrue);
			float num5 = num4 / 2f;
			num5 *= num5;
			float num6 = (float)(Math.Sqrt(num5 + num2 * num2) + Math.Sqrt(num5 + num3 * num3));
			if (num == 0f)
			{
				num = weapon_0.Kinematics.GetMaximumSpeed();
			}
			num = num * num4 / num6;
			ComputeTerminalPoint(num, isAirDroppedTorpedo);
		}
	}

	internal Geopoint_Struct? ComputeTerminalPoint(float WeaponNominalSpeed, bool IsAirdroppedTorpedo)
	{
		if (myWeapon.IsReEntryVehicle && !myWeapon.IsHGV)
		{
			return method_12(WeaponNominalSpeed);
		}
		Weapon_AI aI = myWeapon.AI;
		Geopoint_Struct? result;
		try
		{
			if (aI.PrimaryTarget == null)
			{
				result = null;
			}
			else
			{
				bool flag = aI.PrimaryTarget.IsAir_Missile_Orbital_Contact && aI.PrimaryTarget.IsBallisticTarget();
				bool flag2 = false;
				Weapon weapon = (Weapon)myUnit;
				double num;
				double num2;
				Waypoint[] plottedCourse = default(Waypoint[]);
				if (!HasPlottedCourse())
				{
					num = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
					num2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
				}
				else
				{
					plottedCourse = PlottedCourse;
					if (plottedCourse[^1].Type == Waypoint.WaypointType.TerminalPoint)
					{
						flag2 = true;
						if (plottedCourse.Length > 1)
						{
							num = plottedCourse[^2].Latitude;
							num2 = plottedCourse[^2].Longitude;
						}
						else
						{
							num = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
							num2 = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
						}
					}
					else
					{
						num = plottedCourse[^1].Latitude;
						num2 = plottedCourse[^1].Longitude;
					}
				}
				double num3 = 0.0;
				if (myUnit.ParentScen != null)
				{
					float num4 = myUnit.CurrentSpeed / 3600f * 2f * myUnit.ParentScen.GameResolution;
					Weapon.WeaponGuidanceType guidance = weapon.Guidance;
					Geopoint_Struct thePoint = default(Geopoint_Struct);
					Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
					if (guidance == Weapon.WeaponGuidanceType.Inertial)
					{
						try
						{
							if (weapon.Type == Weapon._WeaponType.PalletWeapon)
							{
								thePoint.Latitude = weapon.get_Latitude((GlobalVariables.BooleanObject)null);
								thePoint.Longitude = weapon.get_Longitude((GlobalVariables.BooleanObject)null);
								thePoint.Altitude = 0f;
								goto end_IL_0179;
							}
							if (!(aI.PrimaryTarget.CurrentSpeed > 0f))
							{
								thePoint.Latitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
								thePoint.Longitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
								goto end_IL_0179;
							}
							double? num5 = ((aI.PrimaryTarget.CurrentSpeed != 0f) ? ActiveUnit_Navigator.CalculateInterceptHeading(num, num2, myUnit.CurrentHeading, aI.PrimaryTarget, WeaponNominalSpeed) : new double?(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null))));
							if (!num5.HasValue)
							{
								(Geopoint_Struct, TimeSpan) tuple = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, WeaponNominalSpeed, aI.PrimaryTarget);
								if (!tuple.Item1.HasZeroCoords)
								{
									num5 = Module_Unit.BearingToPoint_True(myUnit, tuple.Item1.Latitude, tuple.Item1.Longitude);
								}
							}
							if (num5.HasValue)
							{
								if (num5.Value < 0.0)
								{
									geopoint_Struct = ComputeInterceptPoint_BruteForce(WeaponNominalSpeed, aI.PrimaryTarget);
									num5 = Module_Unit.BearingToPoint_True(myWeapon, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
								}
								float relativeBearing = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, aI.BearingToUnit_True(aI.PrimaryTarget));
								if ((relativeBearing > 10f && relativeBearing < 350f) || (relativeBearing > 170f && relativeBearing < 190f))
								{
									geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(num2, num), num5.Value, new Geopoint_Struct(((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), aI.PrimaryTarget.CurrentHeading);
								}
								if (!geopoint_Struct.HasZeroCoords)
								{
									thePoint.Latitude = geopoint_Struct.Latitude;
									thePoint.Longitude = geopoint_Struct.Longitude;
								}
								else
								{
									Geopoint_Struct geopoint_Struct2 = ComputeInterceptPoint_BruteForce(WeaponNominalSpeed, aI.PrimaryTarget);
									if (geopoint_Struct2.HasZeroCoords)
									{
										thePoint.Latitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
										thePoint.Longitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
									}
									else
									{
										thePoint.Latitude = geopoint_Struct2.Latitude;
										thePoint.Longitude = geopoint_Struct2.Longitude;
									}
								}
								goto end_IL_0179;
							}
							result = null;
							goto end_IL_0034;
							end_IL_0179:;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 101230", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						try
						{
							num3 = myWeapon.Sensory.TerminalSensorMaxRange;
							if (num3 == -1.0)
							{
								myWeapon.Sensory.TerminalSensorMaxRange = myWeapon.Sensory.GetTerminalSensorMaxRange();
								num3 = myWeapon.Sensory.TerminalSensorMaxRange;
							}
							if (((Weapon)myUnit).IsMissile && aI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine)
							{
								num3 = 0.0;
							}
							if (IsAirdroppedTorpedo && aI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine && ((Weapon)myUnit).Flags.SearchPattern)
							{
								num3 = 0.0;
							}
							double num6 = num3 * 0.8;
							float num7;
							double? num8;
							if (aI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && aI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
							{
								num7 = Math2.CalcDist(((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), num, num2);
								if (aI.PrimaryTarget.CurrentSpeed > 0f && (!myWeapon.UsesBoostCoastModel.Value || !aI.PrimaryTarget.AppearsToBeLoitering || myWeapon.RangeToUnit_Horiz(aI.PrimaryTarget) < 5f))
								{
									num8 = ActiveUnit_Navigator.CalculateInterceptHeading(num, num2, myUnit.CurrentHeading, aI.PrimaryTarget, WeaponNominalSpeed);
									if (num8.HasValue)
									{
										double? num9 = num8;
										if ((num9.HasValue ? new bool?(num9.GetValueOrDefault() < 0.0) : ((bool?)null)) != true)
										{
											goto IL_068c;
										}
									}
									(Geopoint_Struct, TimeSpan) tuple2 = ActiveUnit_Navigator.ComputeInterceptPoint_BruteForce(myUnit, WeaponNominalSpeed, aI.PrimaryTarget);
									if (!tuple2.Item1.HasZeroCoords)
									{
										num8 = Module_Unit.BearingToPoint_True(myUnit, tuple2.Item1.Latitude, tuple2.Item1.Longitude);
									}
									goto IL_068c;
								}
								double num10;
								if ((double)num7 > num3)
								{
									num10 = (double)num7 - num6;
									if (num10 < (double)num4)
									{
										num10 = 0.0001;
									}
								}
								else
								{
									num10 = (double)num7 * 0.5;
									if (num10 < (double)num4)
									{
										num10 = 0.0001;
									}
								}
								Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref thePoint.Longitude, ref thePoint.Latitude, (float)num10, Math2.CalcAzimuth(num, num2, ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)));
							}
							else
							{
								thePoint.Latitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
								thePoint.Longitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
							}
							goto end_IL_047e;
							IL_08e2:
							float num13;
							float num14;
							if (!geopoint_Struct.HasZeroCoords)
							{
								float num11 = Math2.CalcDist(num, num2, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
								double num10;
								if (!((double)num7 < num3))
								{
									num10 = ((!(num11 < num7)) ? ((double)num7 - num6) : ((double)num11 - num6));
								}
								else if (flag2)
								{
									num10 = ((!((double)num7 < num6)) ? ((double)num7 - num6) : 0.0001);
								}
								else
								{
									num10 = ((!(num11 < num7)) ? ((double)num7 * 0.75) : ((double)num11 * 0.25));
									if (myWeapon.Flags.TerminalIllumination)
									{
										float num12 = Math.Max(num13, num14) / 3600f;
										if ((double)num7 - num10 < (double)num12)
										{
											num10 = num7 - num12;
										}
									}
								}
								if (num10 < (double)num4)
								{
									num10 = 0.0001;
								}
								Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref thePoint.Longitude, ref thePoint.Latitude, (float)num10, Math2.CalcAzimuth(num, num2, geopoint_Struct.Latitude, geopoint_Struct.Longitude));
							}
							else
							{
								double num10;
								if ((double)num7 > num6)
								{
									num10 = num7 / 2f;
									if (num10 < (double)num4)
									{
										num10 = 0.0001;
									}
								}
								else
								{
									num10 = 0.0001;
								}
								Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref thePoint.Longitude, ref thePoint.Latitude, (float)num10, (float)num8.Value);
							}
							goto end_IL_047e;
							IL_068c:
							if (!num8.HasValue && !flag)
							{
								result = null;
							}
							else
							{
								if (!aI.PrimaryTarget.IsAir_Missile_Orbital_Contact)
								{
									geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(num2, num), num8.Value, new Geopoint_Struct(((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), aI.PrimaryTarget.CurrentHeading);
									if (!Information.IsNothing((object)geopoint_Struct) && !geopoint_Struct.HasZeroCoords)
									{
										float num15 = Math2.CalcDist(num, num2, geopoint_Struct.Latitude, geopoint_Struct.Longitude);
										double num10;
										if ((double)num7 < num6)
										{
											num10 = ((!(num15 < num7)) ? ((double)num7 * 0.75) : ((double)num15 * 0.75));
										}
										else if ((double)num15 > (double)num7 - num6)
										{
											num10 = num15 - (float)((double)num15 - ((double)num7 - num6));
											if (num10 <= 0.0)
											{
												num10 = 0.0001;
											}
											if (num10 < (double)num4)
											{
												num10 = 0.0001;
											}
										}
										else
										{
											num10 = (double)num15 - num6;
											if (num10 < (double)num4)
											{
												num10 = 0.0001;
											}
										}
										Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref thePoint.Longitude, ref thePoint.Latitude, (float)num10, Math2.CalcAzimuth(num, num2, geopoint_Struct.Latitude, geopoint_Struct.Longitude));
									}
									else
									{
										double num10;
										if ((double)num7 > num6)
										{
											num10 = num7 / 2f;
											if (num10 < (double)num4)
											{
												num10 = 0.0001;
											}
										}
										else
										{
											num10 = 0.0001;
										}
										Geodesic_EdWilliams.CalcPoint_Williams(num2, num, ref thePoint.Longitude, ref thePoint.Latitude, (float)num10, (float)num8.Value);
									}
									goto end_IL_047e;
								}
								num6 = num3 * 0.75;
								num14 = WeaponNominalSpeed;
								if (weapon.UsesBoostCoastModel.Value && weapon.TimeSinceLaunch > (float)weapon.TotalBurnTime)
								{
									num14 = myWeapon.CurrentSpeed;
								}
								num13 = Module_Unit.ClosureSpeed(myUnit, aI.PrimaryTarget, num14, myUnit.CurrentHeading);
								float relativeBearing2 = MathFunctions.GetRelativeBearing(myUnit.CurrentHeading, aI.BearingToUnit_True(aI.PrimaryTarget));
								if (!aI.PrimaryTarget.IsBallisticTarget())
								{
									if (!aI.PrimaryTarget.IsOrbitalContact || aI.PrimaryTarget.ActualUnit == null || !aI.PrimaryTarget.ActualUnit.IsSatellite)
									{
										if (num13 > 0f && relativeBearing2 > 89f && relativeBearing2 < 271f && num13 < myUnit.CurrentSpeed)
										{
											num13 = -1f;
										}
										if (((relativeBearing2 > 5f && relativeBearing2 < 355f) || (relativeBearing2 > 175f && relativeBearing2 < 185f)) && (double)num13 < (double)myUnit.CurrentSpeed * 1.25)
										{
											geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(num2, num), num8.Value, new Geopoint_Struct(((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), aI.PrimaryTarget.CurrentHeading);
										}
										geopoint_Struct = ComputeInterceptPoint_BruteForce(WeaponNominalSpeed, aI.PrimaryTarget, num13, num7);
										if (geopoint_Struct.HasZeroCoords && ((relativeBearing2 > 10f && relativeBearing2 < 350f) || (relativeBearing2 > 170f && relativeBearing2 < 190f)))
										{
											geopoint_Struct = MathFunctions.Intersection(new Geopoint_Struct(num2, num), num8.Value, new Geopoint_Struct(((Module_Unit.Unit)aI.PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)aI.PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null)), aI.PrimaryTarget.CurrentHeading);
										}
										goto IL_08e2;
									}
									geopoint_Struct = ComputeInterceptPoint_Satellite(aI.PrimaryTarget);
									if (!geopoint_Struct.HasZeroCoords)
									{
										goto IL_08e2;
									}
									result = null;
								}
								else
								{
									geopoint_Struct = ComputeInterceptPoint_ABM(aI.PrimaryTarget);
									if (!geopoint_Struct.HasZeroCoords)
									{
										goto IL_08e2;
									}
									result = null;
								}
							}
							goto end_IL_0034;
							end_IL_047e:;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							ex4?.Data.Add("Error at 101231", "");
							GameGeneral.WriteExceptionsToLog(ex4);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
					thePoint.Altitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					if (myWeapon.IsAAWCapable && num3 > 0.0)
					{
						if (myWeapon.AI.PrimaryTarget != null)
						{
							if (flag && !geopoint_Struct.HasZeroCoords)
							{
								float num16 = Module_Unit.RangeToPoint_Horiz(myWeapon, geopoint_Struct, GlobalVariables.ObjectTrue);
								float num17 = Module_Unit.RangeToPoint_Horiz(myWeapon, thePoint, GlobalVariables.ObjectTrue);
								if (num17 < num4)
								{
									num17 = num16;
								}
								if (geopoint_Struct.Altitude > ((Module_Unit.Unit)myWeapon.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
								{
									float num18 = geopoint_Struct.Altitude - myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
									thePoint.Altitude = geopoint_Struct.Altitude - num18 * (1f - num17 / num16);
								}
								else
								{
									thePoint.Altitude = geopoint_Struct.Altitude * (num17 / num16);
								}
							}
							else
							{
								float num19 = myWeapon.RangeToUnit_Horiz(myWeapon.AI.PrimaryTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
								float num20 = Module_Unit.RangeToPoint_Horiz(myWeapon, thePoint, GlobalVariables.ObjectTrue);
								float num21 = ((Module_Unit.Unit)myWeapon.AI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
								float num22 = myWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num21;
								if (num19 > num20)
								{
									thePoint.Altitude = num21 + num22 * num20 / num19;
								}
								else
								{
									thePoint.Altitude = num21 + num22 * num19 / num20;
								}
							}
						}
					}
					else if (((Weapon)myUnit).Warheads.Length > 0)
					{
						if (!((Weapon)myUnit).Warheads[0].get_IsAirburst((Weapon)myUnit, aI.PrimaryTarget.ActualUnit))
						{
							thePoint.Altitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							if (weapon.HasTerminalGuidance)
							{
								if (weapon.IsBallisticMissile || weapon.IsReEntryVehicle)
								{
									if (weapon.WeaponSensors().Count > 0)
									{
										float num23 = (from theS in weapon.WeaponSensors()
											select theS.maxRange).Max();
										thePoint.Altitude = (float)((double)num23 * 1852.0 / 2.0);
									}
									else if (weapon.Warheads.Length > 0 && weapon.Warheads[0].get_CarriedWeapon(myUnit.ParentScen).WeaponSensors().Count > 0)
									{
										float num23 = (from theS in weapon.Warheads[0].get_CarriedWeapon(myUnit.ParentScen).WeaponSensors()
											select theS.maxRange).Max();
										thePoint.Altitude = (float)((double)num23 * 1852.0 / 2.0);
									}
								}
								if (weapon.ValidTargets.Radar && (aI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint || aI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint))
								{
									int num24 = (int)Math.Round(num3 * 1852.0 * Math2.Cosd(45f) * 0.9);
									thePoint.Altitude = Math.Min(num24, (((Weapon)myUnit).CruiseAltitude_AGL > 0f) ? ((Weapon)myUnit).CruiseAltitude_AGL : ((Weapon)myUnit).CruiseAltitude_ASL);
								}
							}
						}
						else
						{
							thePoint.Altitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)((Weapon)myUnit).get_OptimumBurstHeight_AGL(aI.PrimaryTarget.ActualUnit);
						}
					}
					if (((Weapon)myUnit).Type == Weapon._WeaponType.Decoy_Expendable)
					{
						thePoint.Altitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
					}
					else if (((Weapon)myUnit).IsAAWCapable && !((Weapon)myUnit).IsASuW_Land && !((Weapon)myUnit).IsASuW_Naval)
					{
						Contact_Base.ContactType type = aI.PrimaryTarget.Type;
						if (type != Contact_Base.ContactType.Aimpoint && type != Contact_Base.ContactType.ActivationPoint)
						{
							if (!aI.PrimaryTarget.IsBallisticTarget())
							{
								thePoint.Altitude = ((Module_Unit.Unit)aI.PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							}
						}
						else
						{
							thePoint.Altitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						}
					}
					if (Has_NonPathfind_NonFP_PlottedCourse() && PlottedCourse.Last().Type == Waypoint.WaypointType.TerminalPoint)
					{
						if (plottedCourse == null)
						{
							plottedCourse = PlottedCourse;
						}
						plottedCourse[plottedCourse.Count() - 1].Latitude = thePoint.Latitude;
						plottedCourse[plottedCourse.Count() - 1].Longitude = thePoint.Longitude;
						plottedCourse[plottedCourse.Count() - 1].Altitude = thePoint.Altitude;
					}
					else
					{
						AddWaypoint(thePoint.Latitude, thePoint.Longitude, thePoint.Altitude, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					}
					return new Geopoint_Struct(thePoint.Longitude, thePoint.Latitude, thePoint.Altitude);
				}
				result = null;
			}
			end_IL_0034:;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100987", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void CheckIfReachedWaypoint_AND_Apply_WP_logic(float elapsedTime, ref bool ForceWaypointSwitch, ref bool ForceStationAbort)
	{
		Weapon weapon = myWeapon;
		int num = PlottedCourse.Length;
		if ((myWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial && !weapon.IsTorpedo && weapon.Type != Weapon._WeaponType.Decoy_Vehicle && weapon.Type != Weapon._WeaponType.UAV_Expendable && num == 1) || (weapon.AI.PrimaryTarget != null && weapon.HasTorpedoPayload && (weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Submarine || weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint || weapon.AI.PrimaryTarget.Type == Contact_Base.ContactType.Aimpoint) && num == 1))
		{
			return;
		}
		if (num > 0)
		{
			Scenario parentScen = myUnit.ParentScen;
			DateTime t = parentScen.Time;
			if (myWeapon.IsDLZconstruct)
			{
				t = t.AddSeconds(myWeapon.TimeSinceLaunch);
			}
			if (!ForceWaypointSwitch)
			{
				if (DateTime.Compare(WP_reach_cache_memory.theTime, t) != 0)
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
			}
			Waypoint waypoint = PlottedCourse[0];
			if (!ForceWaypointSwitch && !HaveReachedPoint(waypoint, elapsedTime))
			{
				if (myWeapon.IsAerospaceUnit)
				{
					float num2 = myWeapon.Kinematics.TurnRate();
					float adjustedTurnRateBasedOnSpeedAndAltitude = myWeapon.Kinematics.GetAdjustedTurnRateBasedOnSpeedAndAltitude();
					if ((double)adjustedTurnRateBasedOnSpeedAndAltitude < (double)num2 * 0.85)
					{
						if (waypoint.Type == Waypoint.WaypointType.TurningPoint)
						{
							if (myUnit.Navigator.NeedToExtend(waypoint.Latitude, waypoint.Longitude, 0f, 0f, adjustedTurnRateBasedOnSpeedAndAltitude))
							{
								bool ForceWaypointSwitch2 = true;
								bool ForceStationAbort2 = false;
								CheckIfReachedWaypoint_AND_Apply_WP_logic(elapsedTime, ref ForceWaypointSwitch2, ref ForceStationAbort2);
							}
						}
						else if (waypoint.Type == Waypoint.WaypointType.TerminalPoint && myWeapon.AI.PrimaryTarget != null && myWeapon.ParentScen.FifthSecondIsChangingOnThisPulse)
						{
							Contact primaryTarget = myWeapon.AI.PrimaryTarget;
							float num3 = Module_Unit.BearingToPoint_Relative(myUnit, ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
							float num4 = Module_Unit.BearingToPoint_Relative(myUnit, waypoint.Latitude, waypoint.Longitude);
							int num5 = 15;
							if ((num3 > 15f && num3 < (float)(360 - num5)) || (num4 > (float)num5 && num4 < (float)(360 - num5)))
							{
								bool flag = num3 > 180f;
								float distance_NM = Misc.TurnRadius(myUnit.CurrentSpeed, adjustedTurnRateBasedOnSpeedAndAltitude);
								Geopoint_Struct Point = default(Geopoint_Struct);
								float bearing = Math2.NormalizeBearing(myWeapon.CurrentHeading + (float)(90 * ((!flag) ? 1 : (-1))));
								Geodesic_EdWilliams.CalcPoint_Williams(myWeapon.get_Longitude((GlobalVariables.BooleanObject)null), myWeapon.get_Latitude((GlobalVariables.BooleanObject)null), ref Point.Longitude, ref Point.Latitude, distance_NM, bearing);
								Geopoint_Struct Point2 = primaryTarget.Location;
								float num6 = Math2.CalcDist(ref Point, ref Point2);
								if (num6 < distance_NM)
								{
									flag = !flag;
									bearing = Math2.NormalizeBearing(myWeapon.CurrentHeading + (float)(90 * ((!flag) ? 1 : (-1))));
									Geodesic_EdWilliams.CalcPoint_Williams(myWeapon.get_Longitude((GlobalVariables.BooleanObject)null), myWeapon.get_Latitude((GlobalVariables.BooleanObject)null), ref Point.Longitude, ref Point.Latitude, distance_NM, bearing);
									Point2 = primaryTarget.Location;
									num6 = Math2.CalcDist(ref Point, ref Point2);
								}
								Geopoint_Struct geopoint_Struct = default(Geopoint_Struct);
								float num7 = Math2.NormalizeBearing(Math2.CalcAzimuth(Point, primaryTarget.Location));
								double num8 = 57.2957795130823 * Math.Acos(distance_NM / num6);
								double bearing2 = Math2.NormalizeBearing((double)num7 + num8 * (double)(flag ? 1 : (-1)));
								Geodesic_EdWilliams.CalcPoint_Williams(ref Point.Longitude, ref Point.Latitude, ref geopoint_Struct.Longitude, ref geopoint_Struct.Latitude, ref distance_NM, ref bearing2);
								Geopoint_Struct geopoint_Struct2 = default(Geopoint_Struct);
								float bearing3 = Math2.NormalizeBearing(Math2.CalcAzimuth(primaryTarget.Location, geopoint_Struct));
								float num9 = Math2.CalcDist(waypoint.Latitude, waypoint.Longitude, ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
								if (Math2.CalcDist(geopoint_Struct.Latitude, geopoint_Struct.Longitude, ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null)) > num9)
								{
									Geodesic_EdWilliams.CalcPoint_Williams(((Module_Unit.Unit)primaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)primaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ref geopoint_Struct2.Longitude, ref geopoint_Struct2.Latitude, num9, bearing3);
								}
								else
								{
									geopoint_Struct2 = geopoint_Struct;
								}
								waypoint.Latitude = geopoint_Struct2.Latitude;
								waypoint.Longitude = geopoint_Struct2.Longitude;
							}
						}
					}
				}
			}
			else
			{
				if (num >= 2)
				{
					ApplyWaypointSpeedAltToUnit(waypoint);
					ApplyWaypointDoctrineToUnit(waypoint);
					ApplyWaypointActionToUnit(waypoint);
				}
				else if (myWeapon.Flags.Navigation_AltitudeControl && myUnit.Kinematics.DesiredAltitudeOverride)
				{
					myUnit.Kinematics.DesiredAltitudeOverride = waypoint.DesiredAltitudeOverride;
				}
				RemoveWaypoint_Soft(waypoint, RemoveWingmanWaypoints: false);
				if (PlottedCourse.Length > 0)
				{
					HeadToFirstWaypoint(elapsedTime);
				}
			}
		}
		if (PlottedCourse.Length == 0 && (weapon.Type == Weapon._WeaponType.Decoy_Vehicle || weapon.Type == Weapon._WeaponType.UAV_Expendable))
		{
			myUnit.AI.PrimaryTarget = null;
		}
	}

	static Weapon_Navigator()
	{
		Class72.smethod_20();
	}
}
