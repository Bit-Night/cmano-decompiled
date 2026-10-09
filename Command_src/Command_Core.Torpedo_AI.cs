using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Torpedo_AI : Weapon_AI
{
	public override Contact PrimaryTarget
	{
		get
		{
			return _PrimaryTarget;
		}
		set
		{
			try
			{
				Contact primaryTarget = _PrimaryTarget;
				if (value != _PrimaryTarget)
				{
					if (_PrimaryTarget != null && value == null)
					{
						_LastKnownTargetLocation = new GeoPoint(((Module_Unit.Unit)_PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)_PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					}
					if (primaryTarget != null)
					{
						primaryTarget.IncomingGuidedWeapons = null;
					}
					if (value != null)
					{
						value.IncomingGuidedWeapons = null;
					}
				}
				_PrimaryTarget = value;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100965", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public Torpedo_AI(Weapon theUnit)
		: base(theUnit)
	{
	}

	public override void DetermineDesiredAttitudeAndThrottle(float elapsedTime, bool RecalculatePlottedCourse = true)
	{
		Weapon theWeapon = (Weapon)myUnit;
		try
		{
			if (theWeapon.BlindTime > 0f || theWeapon.TimeToReseek > 0f)
			{
				return;
			}
			if (!PrimaryTargetLocated(ref theWeapon))
			{
				if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					myUnit.Navigator.FollowPlottedCourse(elapsedTime);
					DetermineDesiredAltitude(elapsedTime);
				}
				else
				{
					if (theWeapon.Guidance == Weapon.WeaponGuidanceType.Inertial)
					{
						return;
					}
					if (!theWeapon.Flags.SearchPattern)
					{
						if (!Information.IsNothing((object)PrimaryTarget))
						{
							if (Information.IsNothing((object)PrimaryTarget.ActualUnit))
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
							}
							else if (theWeapon.ImpactsOnThisPulse_ActualUnit)
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
							}
							else
							{
								myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_NextSecond(PrimaryTarget.ActualUnit));
							}
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
						}
					}
					else if (PrimaryTarget != null && PrimaryTarget.ActualUnit != null && !PrimaryTarget.ActualUnit.IsFixedFacility)
					{
						if (theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
						{
							CircleSearch(elapsedTime);
						}
						else if (theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Snake)
						{
							SnakeSearch();
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
						}
					}
					else if (!theWeapon.ValidTargets.Mine)
					{
						if (!theWeapon.Navigator.HasPlottedCourse() && theWeapon.Flags.SearchPattern && theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
						{
							CircleSearch(elapsedTime);
						}
						else if (!theWeapon.Navigator.HasPlottedCourse() && theWeapon.Flags.SearchPattern && theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Snake)
						{
							SnakeSearch();
						}
						else if (!Information.IsNothing((object)PrimaryTarget) && !Information.IsNothing((object)PrimaryTarget.ActualUnit) && PrimaryTarget.ActualUnit.IsFixedFacility)
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, BearingToUnit_True(PrimaryTarget));
						}
						else
						{
							myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, myUnit.CurrentHeading);
						}
					}
					else
					{
						SnakeSearch();
					}
					DetermineDesiredAltitude(elapsedTime);
				}
				return;
			}
			DetermineDesiredAltitude(elapsedTime);
			if (PrimaryTarget != null && PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint && PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint)
			{
				PrimaryTarget_LastKnown_Lat = ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null);
				PrimaryTarget_LastKnown_Lon = ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null);
				PrimaryTarget_LastKnown_Altitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			if (myUnit.Navigator.Has_NonPathfind_NonFP_PlottedCourse() && !Information.IsNothing((object)theWeapon.DataLinkParent))
			{
				if (PrimaryTarget.SpeedIsKnown && PrimaryTarget.CurrentSpeed > 0f)
				{
					switch (theWeapon.Guidance)
					{
					case Weapon.WeaponGuidanceType.Datalink_Plus_SemiActive:
					case Weapon.WeaponGuidanceType.DataLink_Plus_Passive:
					case Weapon.WeaponGuidanceType.Datalink_Plus_Active:
					case Weapon.WeaponGuidanceType.SemiActive_Plus_Active:
						((Weapon_Navigator)myUnit.Navigator).ComputeTerminalPoint(myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.MaxPossibleThrottleSetting, ValidateAndFixAltitude: false), !Information.IsNothing((object)theWeapon.DataLinkParent) && theWeapon.DataLinkParent.IsAircraft);
						break;
					}
				}
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
				if (theWeapon.RangeToUnit_Horiz(PrimaryTarget.ActualUnit) < 2f)
				{
					method_18();
				}
			}
			else if (myUnit.Navigator.HasPlottedCourse())
			{
				myUnit.Navigator.FollowPlottedCourse(elapsedTime);
			}
			else
			{
				if (!Information.IsNothing((object)PrimaryTarget) && PrimaryTarget.Type == Contact_Base.ContactType.ActivationPoint)
				{
					return;
				}
				if (theWeapon.Guidance != Weapon.WeaponGuidanceType.Inertial)
				{
					ManouverTowardsTarget(elapsedTime);
					if (theWeapon.RangeToUnit_Horiz(PrimaryTarget.ActualUnit) < 2f)
					{
						method_18();
					}
				}
				else if (!Information.IsNothing((object)PrimaryTarget))
				{
					theWeapon.Navigator.AddWaypoint(new Waypoint(((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), 0f, Waypoint.WaypointType.TerminalPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse));
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 10398777441", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool GuidanceLogic_DestroyedOrVanishedPrimaryTarget(float elapsedTime)
	{
		Weapon weapon = (Weapon)myUnit;
		bool result;
		try
		{
			if (!weapon.myTargetDoesNotExist() && !PrimaryTarget.get_IsDestroyed(weapon.ParentScen))
			{
				if (PrimaryTarget.Age > 30f && PrimaryTarget.IsAir_Missile_Orbital_Contact && !weapon.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
				{
					int num;
					if (weapon.HasGoneAutonomous)
					{
						num = 1;
					}
					else
					{
						weapon.GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
						weapon.AddMessage("Weapon: " + weapon.Name + " is not receiving firm target updates from parent unit... Going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(weapon.get_Longitude((GlobalVariables.BooleanObject)null), weapon.get_Latitude((GlobalVariables.BooleanObject)null)));
						num = 1;
					}
					result = (byte)num != 0;
				}
				else if (PrimaryTarget.Age > 1200f && !weapon.Navigator.Has_NonPathfind_NonFP_PlottedCourse() && !weapon.HasGoneAutonomous)
				{
					weapon.GoAutonomous(clearPrimaryTarget: true, clearDatalink: true);
					weapon.AddMessage("Weapon: " + weapon.Name + " is not receiving firm target updates from parent unit... Going autonomous.", "Weapon issue", LoggedMessage.MessageType.WeaponLogic, 10, new Geopoint_Struct(weapon.get_Longitude((GlobalVariables.BooleanObject)null), weapon.get_Latitude((GlobalVariables.BooleanObject)null)));
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else if (!weapon.Navigator.Has_NonPathfind_NonFP_PlottedCourse())
			{
				float overshootThreshold_deg = 60f;
				if (weapon.DataLinkParent != null)
				{
					overshootThreshold_deg = 180f;
				}
				weapon.AttemptRetargeting_Datalink(elapsedTime, overshootThreshold_deg);
				result = true;
			}
			else
			{
				weapon.DatalinkRetargetTime = 0f;
				result = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100935", "");
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

	private void method_18()
	{
		try
		{
			if (myUnit.MaxPossibleThrottleSetting <= ActiveUnit.Throttle.Cruise || myUnit.ThrottleSetting >= ActiveUnit.Throttle.Full)
			{
				return;
			}
			float num = myUnit.FuelConsumption(ActiveUnit.Throttle.Cruise, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			if (num <= 0f)
			{
				num = 1f;
			}
			float num2 = myUnit.FuelConsumption(ActiveUnit.Throttle.Full, null, null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			if (num2 <= 0f)
			{
				num2 = 1f;
			}
			float num3 = default(float);
			foreach (FuelRec item in myUnit.Fuel_ReadOnly)
			{
				num3 += item.CurrentQuantity;
			}
			float num4 = 0.75f;
			num3 = num3 * (num / num2) * num4;
			if (myUnit.ETA_To_Location(Module_Unit.ClosureSpeed(myUnit, PrimaryTarget, myUnit.Kinematics.GetMaximumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Full, ValidateAndFixAltitude: false), myUnit.CurrentHeading), myUnit.RangeToUnit_Horiz(PrimaryTarget)) < num3)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.Full);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100972", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void SnakeSearch()
	{
		Weapon weapon = (Weapon)myUnit;
		try
		{
			MaxSnakeAngle = 15;
			if (!SnakeAxis.HasValue)
			{
				if (Information.IsNothing((object)PrimaryTarget))
				{
					SnakeAxis = myUnit.CurrentHeading;
				}
				else
				{
					SnakeAxis = Math2.CalcAzimuth(weapon.get_Latitude((GlobalVariables.BooleanObject)null), weapon.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null));
				}
			}
			if (!SnakeDirection.HasValue)
			{
				SnakeDirection = (_SnakeDirection)GameGeneral.GlobalRNG.Next(0, 1);
			}
			float value = Math2.NormalizeBearing(SnakeAxis.Value - (float)MaxSnakeAngle);
			float value2 = Math2.NormalizeBearing(SnakeAxis.Value + (float)MaxSnakeAngle);
			_SnakeDirection? snakeDirection = SnakeDirection;
			byte? b = (byte?)snakeDirection;
			if (((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true)
			{
				b = (byte?)snakeDirection;
				if (((!b.HasValue) ? ((bool?)null) : new bool?(b == 1)) == true)
				{
					if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, SnakeAxis.Value)) >= (float)MaxSnakeAngle)
					{
						SnakeDirection = _SnakeDirection.Left;
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
					}
					else
					{
						myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value2);
					}
				}
			}
			else if (Math.Abs(MathFunctions.AngularDifference(myUnit.CurrentHeading, SnakeAxis.Value)) >= (float)MaxSnakeAngle)
			{
				SnakeDirection = _SnakeDirection.Right;
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value2);
			}
			else
			{
				myUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100968", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void DetermineDesiredAltitude(float elapsedTime)
	{
		Weapon theWeapon = (Weapon)myUnit;
		try
		{
			if (!theWeapon.Navigator.HasPlottedCourse())
			{
				if (!Information.IsNothing((object)PrimaryTarget))
				{
					if (!PrimaryTargetLocated(ref theWeapon) && theWeapon.Flags.SearchPattern && theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
					{
						if (PrimaryTarget.AltitudeIsKnown && (double)theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > (double)((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) * 0.7)
						{
							theWeapon.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						}
						else if (!PrimaryTarget.AltitudeIsKnown && theWeapon.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > -40f)
						{
							theWeapon.DesiredAltitude = -40f;
						}
						else
						{
							theWeapon.DesiredAltitude += -2f * elapsedTime;
						}
					}
					else if (PrimaryTarget.AltitudeIsKnown)
					{
						if (Information.IsNothing((object)PrimaryTarget))
						{
							return;
						}
						float num;
						Geopoint_Struct thePoint = default(Geopoint_Struct);
						if (PrimaryTarget.CurrentSpeed == 0f)
						{
							num = myUnit.RangeToUnit_Horiz(PrimaryTarget);
						}
						else
						{
							float mySpeed = (theWeapon.SupportsAttitude_Pitch ? ((float)((double)theWeapon.Kinematics.GetMaximumSpeed() * 0.5)) : ((float)theWeapon.Kinematics.GetMaximumSpeed()));
							thePoint = theWeapon.Navigator.ComputeInterceptPoint_BruteForce(mySpeed, PrimaryTarget);
							num = ((!thePoint.HasZeroCoords) ? Module_Unit.RangeToPoint_Horiz(theWeapon, thePoint) : myUnit.RangeToUnit_Horiz(PrimaryTarget));
						}
						if (!theWeapon.SupportsAttitude_Pitch)
						{
							float num2 = myUnit.CurrentSpeed * elapsedTime / 3600f;
							float num3 = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							if (num3 < 0f)
							{
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - num2 * Math.Abs(num3) / num;
							}
							else
							{
								myUnit.DesiredAltitude = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + num2 * Math.Abs(num3) / num;
							}
						}
						else
						{
							theWeapon.DesiredAltitude = ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
							if (!thePoint.HasZeroCoords)
							{
								Calculate_And_Set_DesiredPitch(thePoint.Latitude, thePoint.Longitude, thePoint.Altitude);
							}
							else
							{
								Calculate_And_Set_DesiredPitch(((Module_Unit.Unit)PrimaryTarget).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)PrimaryTarget).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
							}
						}
					}
				}
				else if (theWeapon.Flags.SearchPattern && theWeapon.SearchPatternType == Weapon.WeaponSearchPatternType.Circle)
				{
					theWeapon.DesiredAltitude += -2f * elapsedTime;
				}
			}
			if (myUnit.DesiredAltitude > -10f)
			{
				theWeapon.DesiredAltitude = -10f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 999999", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	internal override bool PrimaryTargetLocated(ref Weapon theWeapon)
	{
		if (PrimaryTarget != null)
		{
			if (!PrimaryTarget.get_IsDestroyed(myUnit.ParentScen))
			{
				if (!theWeapon.HasGoneAutonomous && !theWeapon.IsFullyAutonomous)
				{
					return base.PrimaryTargetLocated(ref theWeapon);
				}
				Contact[] targets_ReadOnly = base.Targets_ReadOnly;
				int num = 0;
				while (true)
				{
					if (num < targets_ReadOnly.Length)
					{
						Contact contact = targets_ReadOnly[num];
						if (contact != null && contact.ActualUnit != null && PrimaryTarget != null && ActiveUnit_Sensory.ContactsAreOfSameActualUnit(PrimaryTarget, contact))
						{
							break;
						}
						num = checked(num + 1);
						continue;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	static Torpedo_AI()
	{
		Class72.smethod_20();
	}
}
