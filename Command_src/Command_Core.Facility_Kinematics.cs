using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Facility_Kinematics : ActiveUnit_Kinematics
{
	private Facility facility_0;

	[SpecialName]
	private Facility method_2()
	{
		if (facility_0 == null)
		{
			facility_0 = (Facility)myUnit;
		}
		return facility_0;
	}

	public Facility_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override ActiveUnit.Throttle GetThrottleSuitableForThisSpeed(float Altitude, float theSpeed)
	{
		if (theSpeed == 0f)
		{
			return ActiveUnit.Throttle.FullStop;
		}
		if (theSpeed <= 3f)
		{
			return ActiveUnit.Throttle.Loiter;
		}
		if (theSpeed <= 10f)
		{
			return ActiveUnit.Throttle.Cruise;
		}
		if (theSpeed <= 20f)
		{
			return ActiveUnit.Throttle.Full;
		}
		return ActiveUnit.Throttle.Flank;
	}

	public override float MaxRange(bool BingoFuelCheck, float? theSpeed, float? theAltitude)
	{
		return float.MaxValue;
	}

	public override float TurnRate()
	{
		return 45f;
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle theThrottle, float theAltitude)
	{
		return 2f;
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float theSpeed)
	{
		return 2f;
	}

	public override bool CanApplyFlankThrottle()
	{
		return true;
	}

	public override int GetMaximumSpeed()
	{
		if (method_2().MobileUnitCategory() == IMobileGroundUnit._MobileUnitCategory.Infantry)
		{
			return 5;
		}
		return 30;
	}

	public int GetMaximumSpeedAtThisLocation(double theLat, double theLon, bool MinimumBounceSpeed = true)
	{
		int result;
		try
		{
			if (!myUnit.IsFixedFacility)
			{
				float num = GetMaximumSpeed();
				float maxSlope = Terrain.GetMaxSlope(theLat, theLon, RequestIsFromGUI: false, myUnit.ParentScen);
				Facility facility = (Facility)myUnit;
				float num2 = 1f;
				switch (facility.Category)
				{
				case Facility._FacilityCategory.Mobile_Vehicle:
					num2 = 1f;
					break;
				case Facility._FacilityCategory.Mobile_Personnel:
					num2 = 0.75f;
					break;
				case Facility._FacilityCategory.Mobile_Vehicules_Tracked:
					num2 = 2f;
					break;
				case Facility._FacilityCategory.Mobile_Vehicules_HalfTrack:
					num2 = 1.5f;
					break;
				case Facility._FacilityCategory.Mobile_Vehicule_Wheeled:
					num2 = 0.4f;
					break;
				}
				num /= 1f + maxSlope;
				num /= (float)Math.Pow(1f + maxSlope, 2.0);
				if (method_2().ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
				{
					switch (LandCover.GetLandCoverAtThisPoint(theLat, theLon, method_2().ParentScen))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						num = 0f;
						break;
					case LandCover.LandCoverType.Water:
						num = 0.01f;
						break;
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num = ((facility.Category != Facility._FacilityCategory.Mobile_Personnel) ? ((float)(int)Math.Round((double)num * 0.3 * (double)((num2 + 1f) / 2f))) : ((float)(int)Math.Round((double)num * 0.7)));
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num = ((facility.Category != Facility._FacilityCategory.Mobile_Personnel) ? ((float)(int)Math.Round((double)num * 0.5 * (double)((num2 + 1f) / 2f))) : ((float)(int)Math.Round((double)num * 0.6)));
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						if (facility.Category != Facility._FacilityCategory.Mobile_Personnel)
						{
							num = (int)Math.Round((double)num * 0.7);
						}
						break;
					case LandCover.LandCoverType.Permanent_wetlands:
						num = (int)Math.Round((double)num * 0.1 * (double)num2);
						break;
					case LandCover.LandCoverType.UrbanAndBuiltUp:
					case LandCover.LandCoverType.Urban_CloseInnerCity:
					case LandCover.LandCoverType.Urban_SpacedHighRise:
					case LandCover.LandCoverType.Urban_AttachedHouses:
					case LandCover.LandCoverType.Urban_CloseIndustrial:
					case LandCover.LandCoverType.Urban_SpacedApartments:
					case LandCover.LandCoverType.Urban_DetachedHouses:
					case LandCover.LandCoverType.Urban_SpacedIndustrial:
					case LandCover.LandCoverType.Urban_ShantyTown:
						switch (facility.Category)
						{
						case Facility._FacilityCategory.Mobile_Personnel:
							num = (int)Math.Round((double)num * 1.05);
							break;
						case Facility._FacilityCategory.Mobile_Vehicules_Tracked:
							num = (int)Math.Round(num * 1f);
							break;
						case Facility._FacilityCategory.Mobile_Vehicules_HalfTrack:
							num = (int)Math.Round((double)num * 1.1);
							break;
						case Facility._FacilityCategory.Mobile_Vehicule_Wheeled:
							num = (int)Math.Round((double)num * 1.4);
							break;
						}
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num = ((facility.Category != Facility._FacilityCategory.Mobile_Personnel) ? ((float)(int)Math.Round((double)num * 0.7 * (double)((num2 + 1f) / 2f))) : ((float)(int)Math.Round((double)num * 0.85)));
						break;
					case LandCover.LandCoverType.SnowAndIce:
						num = (int)Math.Round((double)num * 0.2 * (double)num2);
						break;
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						break;
					}
				}
				if (MinimumBounceSpeed && num < 1f && num > 0f)
				{
					num = 1f;
				}
				result = (int)Math.Round(num);
			}
			else
			{
				result = 0;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100559", "");
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
			result = num3;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		return (int)Math.Round((float)base.GetMaximumSpeed(Altitude, ThrottleSetting, ValidateAndFixAltitude: false));
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			if (!myUnit.IsFixedFacility)
			{
				myUnit.UpdateSettlingOnPosition(elapsedTime);
				try
				{
					if (myUnit.AI.HoldPosition)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
					}
					else if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
					{
						if (!myUnit.ActualSpeedReducedByTerrain)
						{
							myUnit.DesiredSpeed = Math.Min(myUnit.DesiredSpeed, myUnit.Kinematics.GetMaximumSpeed(0f, myUnit.ThrottleSetting, ValidateAndFixAltitude: false));
						}
					}
					else if (myUnit.Kinematics.ThrottlePreset != UnitThrottlePreset.None && !myUnit.Navigator.IsManouveringToFormationStation)
					{
						if (myUnit.Status != ActiveUnit._ActiveUnitStatus.Unassigned && myUnit.Status != ActiveUnit._ActiveUnitStatus.HeadingToRefuelPoint)
						{
							myUnit.SetThrottle((ActiveUnit.Throttle)myUnit.Kinematics.ThrottlePreset, (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
						}
					}
					else
					{
						myUnit.SetThrottle(GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), (int)Math.Round(myUnit.DesiredSpeed)), (int)Math.Round(myUnit.Kinematics.DesiredSpeedOverride.Value));
					}
					float num = GetMaximumSpeedAtThisLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
					if ((myUnit.IsShip || myUnit.IsSubmarine) && GeoPoint.get_IsInCanal(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)))
					{
						num = 8f;
					}
					if (myUnit.IsOutOfFuel)
					{
						if (myUnit.IsWeapon && myUnit.SupportsAttitude_Pitch)
						{
							if (!(myUnit.Attitude_Pitch <= ((Weapon)myUnit).InfiniteGlideAngle))
							{
								num = 0f;
							}
						}
						else
						{
							num = 0f;
						}
					}
					double num2 = myUnit.CurrentHeading;
					if (myUnit.CurrentHeading != myUnit.DesiredHeading)
					{
						TurnToDesiredHeading(elapsedTime);
					}
					else
					{
						ActualMovementVector = myUnit.CurrentHeading;
					}
					if (myUnit.CurrentSpeed != 0f)
					{
						myUnit.ActualHorizMovement(elapsedTime, SimplifiedCalcs_DLZ);
					}
					double num3 = (double)Math.Abs(MathFunctions.AngularDifference((float)num2, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
					CalcTurnDeceleration(num3, elapsedTime);
					bool flag = false;
					if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)) || myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead == null || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
					{
						int num5;
						if (myUnit.Navigator.PreviousWaypointType.HasValue)
						{
							int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
							bool? flag2 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 15));
							if (((!flag2) ?? flag2) != true)
							{
								goto IL_0421;
							}
							num5 = 1;
						}
						else
						{
							num5 = 1;
						}
						flag = (byte)num5 != 0;
					}
					goto IL_0421;
					IL_0421:
					if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
					{
						GoToDesiredSpeed(elapsedTime, (float)num3);
					}
					myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen));
					if (myUnit.CurrentSpeed > num)
					{
						myUnit.ActualSpeedReducedByTerrain = true;
						myUnit.CurrentSpeed = num;
					}
					else
					{
						myUnit.ActualSpeedReducedByTerrain = false;
					}
					if (!SimplifiedCalcs_DLZ)
					{
						myUnit.Kinematics.ExportLocationEvent();
					}
					Module_Unit.ComputeCurrentSpeed_Vertical(myUnit, elapsedTime);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100197", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				myUnit.updateLastReportedInfo();
			}
			else
			{
				myUnit.Kinematics.ExportLocationEvent();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100560", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static Facility_Kinematics()
	{
		Class72.smethod_20();
	}
}
