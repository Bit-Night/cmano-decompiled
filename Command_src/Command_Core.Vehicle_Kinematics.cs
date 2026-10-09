using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Vehicle_Kinematics : ActiveUnit_Kinematics
{
	private Vehicle vehicle_0;

	public Engine ActiveEngine
	{
		get
		{
			Engine result = null;
			if (myUnit.Propulsion.Count > 0)
			{
				result = ((!method_2().IsAmphibiousSeaworthy || (Module_Unit.IsOverLand(method_2()) && myUnit.IsOperating())) ? myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOverland()).ElementAtOrDefault(0) : myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0));
			}
			return result;
		}
	}

	private Vehicle method_2()
	{
		if (vehicle_0 == null)
		{
			vehicle_0 = (Vehicle)myUnit;
		}
		return vehicle_0;
	}

	public Vehicle_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
	}

	public override ActiveUnit.Throttle GetThrottleSuitableForThisSpeed(float Altitude, float theSpeed)
	{
		ActiveUnit.Throttle result;
		try
		{
			if (myUnit.Propulsion.Count == 0)
			{
				result = ActiveUnit.Throttle.FullStop;
			}
			else
			{
				AltBand currentAltBand_CurrentAltitude = GetCurrentAltBand_CurrentAltitude(Altitude, method_2().PrimaryEngine, ValidateAndFixAltitude: false);
				if (currentAltBand_CurrentAltitude == null)
				{
					result = ActiveUnit.Throttle.FullStop;
				}
				else
				{
					_ = method_2().PrimaryEngine.AltBands;
					int speed_Loiter = currentAltBand_CurrentAltitude.Speed_Loiter;
					int speed_Cruise = currentAltBand_CurrentAltitude.Speed_Cruise;
					int value = default(int);
					if (currentAltBand_CurrentAltitude.Consumption_Full.HasValue)
					{
						value = currentAltBand_CurrentAltitude.Speed_Full.Value;
					}
					if (currentAltBand_CurrentAltitude.Consumption_Flank.HasValue)
					{
						_ = currentAltBand_CurrentAltitude.Speed_Flank.Value;
					}
					result = ((theSpeed != 0f) ? ((theSpeed <= (float)speed_Loiter) ? ActiveUnit.Throttle.Loiter : ((theSpeed <= (float)speed_Cruise) ? ActiveUnit.Throttle.Cruise : ((theSpeed <= (float)value) ? (currentAltBand_CurrentAltitude.Consumption_Full.HasValue ? ActiveUnit.Throttle.Full : ActiveUnit.Throttle.Cruise) : ((!currentAltBand_CurrentAltitude.Consumption_Flank.HasValue) ? ActiveUnit.Throttle.Full : ActiveUnit.Throttle.Flank)))) : ActiveUnit.Throttle.FullStop);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 102435304958349056", "");
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

	public override float TacticalRadius()
	{
		if (_TacticalRadius > 0f)
		{
			return _TacticalRadius;
		}
		float num = MaxRange(BingoFuelCheck: true, null, null);
		_TacticalRadius = num / 2f;
		return _TacticalRadius;
	}

	public override float MaxRange(bool BingoFuelCheck, float? theSpeed, float? theAltitude)
	{
		float result;
		try
		{
			if (myUnit.Propulsion.Count > 0)
			{
				Engine activeEngine = ActiveEngine;
				if (activeEngine != null && activeEngine.AltBands.Length > 0)
				{
					ActiveUnit.Throttle throttle = ActiveUnit.Throttle.Cruise;
					float num;
					if (theSpeed.HasValue)
					{
						num = theSpeed.Value;
						throttle = GetThrottleSuitableForThisSpeed(0f, theSpeed.Value);
					}
					else
					{
						num = GetMaximumSpeed(0f, throttle, ValidateAndFixAltitude: false);
					}
					double num2 = 0.0;
					float num3 = 0f;
					foreach (FuelRec item in myUnit.Fuel_ReadOnly)
					{
						if (activeEngine.CanUseThisFuelType(item.FuelType))
						{
							num3 = throttle switch
							{
								ActiveUnit.Throttle.Cruise => activeEngine.AltBands[0].Consumption_Cruise, 
								ActiveUnit.Throttle.Full => (!activeEngine.AltBands[0].Consumption_Full.HasValue) ? activeEngine.AltBands[0].Consumption_Cruise : activeEngine.AltBands[0].Consumption_Full.Value, 
								ActiveUnit.Throttle.Flank => (!activeEngine.AltBands[0].Consumption_Flank.HasValue) ? (activeEngine.AltBands[0].Consumption_Full.HasValue ? activeEngine.AltBands[0].Consumption_Full.Value : activeEngine.AltBands[0].Consumption_Cruise) : activeEngine.AltBands[0].Consumption_Flank.Value, 
								_ => activeEngine.AltBands[0].Consumption_Loiter, 
							};
							num2 += (double)(item.CurrentQuantity / num3);
						}
					}
					result = (float)(num2 * (double)num / 60.0);
					goto IL_0222;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100788B", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = float.MaxValue;
			ProjectData.ClearProjectError();
			goto IL_0222;
		}
		result = float.MaxValue;
		goto IL_0222;
		IL_0222:
		return result;
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

	public override int GetMaximumSpeed_Total()
	{
		int result;
		try
		{
			result = base.GetMaximumSpeed_Total();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 103240694", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			result = 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal float GetMaximumSpeed_AtLocation(double theLat, double theLon, bool MinimumBounceSpeed = true)
	{
		if (myUnit.Propulsion.Count == 0)
		{
			return 0f;
		}
		Engine engine;
		if (!myUnit.IsOperating())
		{
			engine = myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOverland()).ElementAtOrDefault(0);
			return engine.MaxSpeed();
		}
		short elevation = Terrain.GetElevation(theLat, theLon, RequestIsFromGUI: false, myUnit.ParentScen);
		bool flag = elevation > 0;
		int num = -415;
		if (!flag)
		{
			bool flag2;
			if (!(flag2 = !Information.IsNothing((object)method_2().Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0))))
			{
				if (elevation > num && LandCover.GetLandCoverAtThisPoint(theLat, theLon, myUnit.ParentScen) != LandCover.LandCoverType.Water)
				{
					flag = true;
				}
			}
			else
			{
				flag = flag2;
			}
		}
		float num2;
		if (!flag)
		{
			engine = myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0);
			if (!Information.IsNothing((object)engine))
			{
				num2 = engine.AltBands[1].MaxSpeed.Value;
				if (Weather.get_WeatherAtThisTimeAndPlace(method_2().ParentScen, theLat, theLon, 0).SeaState >= method_2().MaxSeaState)
				{
					num2 = (int)Math.Round((double)num2 * 0.5);
				}
				return num2;
			}
			float result = default(float);
			return result;
		}
		engine = myUnit.Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOverland()).ElementAtOrDefault(0);
		num2 = engine.MaxSpeed();
		float num3 = GetMaximumSpeed();
		float maxSlope = Terrain.GetMaxSlope(theLat, theLon, RequestIsFromGUI: false, myUnit.ParentScen);
		Vehicle vehicle = method_2();
		float num4 = 1f;
		switch (method_2().TractionMode)
		{
		case Vehicle.TractionType.Undefined:
			num4 = 1f;
			break;
		case Vehicle.TractionType.Wheeled:
			num4 = 0.4f;
			break;
		case Vehicle.TractionType.HalfTrack:
			num4 = 1.5f;
			break;
		case Vehicle.TractionType.Tracked:
			num4 = 2f;
			break;
		case Vehicle.TractionType.Legged:
			num4 = 0.75f;
			break;
		}
		num3 /= 1f + maxSlope;
		num3 /= (float)Math.Pow(1f + maxSlope, 2.0);
		if (myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects))
		{
			switch (LandCover.GetLandCoverAtThisPoint(theLat, theLon, vehicle.ParentScen))
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				num3 = 0f;
				break;
			case LandCover.LandCoverType.Water:
				num3 = ((!method_2().IsAmphibious) ? 0.01f : (num3 * 0.2f));
				break;
			case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
			case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
			case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
			case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
			case LandCover.LandCoverType.Mixed_forest:
				num3 = ((vehicle.TractionMode != Vehicle.TractionType.Legged) ? (num3 * 0.3f * ((num4 + 1f) / 2f)) : (num3 * 0.7f));
				break;
			case LandCover.LandCoverType.Closed_shrublands:
			case LandCover.LandCoverType.Open_shrublands:
				num3 = ((vehicle.TractionMode != Vehicle.TractionType.Legged) ? (num3 * 0.5f * ((num4 + 1f) / 2f)) : (num3 * 0.6f));
				break;
			case LandCover.LandCoverType.Woody_savannas:
			case LandCover.LandCoverType.Savannas:
				if (vehicle.TractionMode == Vehicle.TractionType.Legged)
				{
					num3 *= 0.7f;
				}
				break;
			case LandCover.LandCoverType.Permanent_wetlands:
				num3 = num3 * 0.1f * num4;
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
				switch (vehicle.TractionMode)
				{
				case Vehicle.TractionType.Wheeled:
					num3 *= 1.4f;
					break;
				case Vehicle.TractionType.HalfTrack:
					num3 *= 1.1f;
					break;
				case Vehicle.TractionType.Tracked:
					num3 *= 1f;
					break;
				case Vehicle.TractionType.Undefined:
				case Vehicle.TractionType.Legged:
					num3 *= 1.05f;
					break;
				}
				break;
			case LandCover.LandCoverType.Croplands:
			case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
				num3 = ((vehicle.TractionMode != Vehicle.TractionType.Legged) ? (num3 * 0.7f * ((num4 + 1f) / 2f)) : (num3 * 0.85f));
				break;
			case LandCover.LandCoverType.SnowAndIce:
				num3 = num3 * 0.2f * num4;
				break;
			case LandCover.LandCoverType.Grasslands:
			case LandCover.LandCoverType.BarrenOrSparselyVegetated:
				break;
			}
		}
		if (MinimumBounceSpeed && num3 < 1f && num3 > 0f)
		{
			num3 = 1f;
		}
		return num3;
	}

	public override AltBand GetCurrentAltBand(float Altitude, bool ValidateAndFixAltitude)
	{
		Engine activeEngine = ActiveEngine;
		if (activeEngine != null && activeEngine.AltBands.Count() > 0)
		{
			return activeEngine.AltBands[0];
		}
		return null;
	}

	public AltBand GetCurrentAltBand_CurrentAltitude_Vehicle(Engine theEngine)
	{
		AltBand result;
		try
		{
			if (theEngine == null)
			{
				theEngine = ActiveEngine;
			}
			if (theEngine != null && theEngine.AltBands.Count() != 0)
			{
				result = theEngine.AltBands[0];
			}
			else
			{
				if (Debugger.IsAttached && !method_2().IsTowable())
				{
					Debugger.Break();
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100188", "");
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

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			myUnit.UpdateSettlingOnPosition(elapsedTime);
			if (myUnit.AI.HoldPosition)
			{
				myUnit.SetThrottle(ActiveUnit.Throttle.FullStop, 0f);
			}
			try
			{
				if (!myUnit.Kinematics.DesiredSpeedOverride.HasValue)
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
				float num = GetMaximumSpeed_AtLocation(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
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
				if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)) || Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num2) != (int)Math.Round(myUnit.CurrentHeading))
				{
					int num4;
					if (Information.IsNothing((object)myUnit.Navigator.PreviousWaypointType))
					{
						num4 = 1;
					}
					else
					{
						int? num5 = (int?)myUnit.Navigator.PreviousWaypointType;
						bool? flag2 = ((!num5.HasValue) ? ((bool?)null) : new bool?(num5 == 15));
						if (((!flag2) ?? flag2) != true)
						{
							goto IL_03d9;
						}
						num4 = 1;
					}
					flag = (byte)num4 != 0;
				}
				goto IL_03d9;
				IL_03d9:
				if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
				{
					GoToDesiredSpeed(elapsedTime, (float)num3);
				}
				if (myUnit.CurrentSpeed > num)
				{
					myUnit.ActualSpeedReducedByTerrain = true;
					myUnit.CurrentSpeed = num;
					myUnit.ThrottleSetting = GetThrottleSuitableForThisSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myUnit.CurrentSpeed);
				}
				else
				{
					myUnit.ActualSpeedReducedByTerrain = false;
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
			myUnit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)((Module_Unit.Unit)myUnit).get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, myUnit.ParentScen));
			if (!SimplifiedCalcs_DLZ)
			{
				myUnit.Kinematics.ExportLocationEvent();
			}
			myUnit.updateLastReportedInfo();
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

	static Vehicle_Kinematics()
	{
		Class72.smethod_20();
	}
}
