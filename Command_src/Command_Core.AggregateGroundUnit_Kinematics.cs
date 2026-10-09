using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class AggregateGroundUnit_Kinematics : ActiveUnit_Kinematics
{
	private AggregateGroundUnit aggregateGroundUnit_0;

	protected new UnitThrottlePreset _ThrottlePreset;

	[SpecialName]
	private AggregateGroundUnit method_2()
	{
		if (aggregateGroundUnit_0 == null)
		{
			aggregateGroundUnit_0 = (AggregateGroundUnit)myUnit;
		}
		return aggregateGroundUnit_0;
	}

	public AggregateGroundUnit_Kinematics(ref ActiveUnit theUnit)
		: base(ref theUnit)
	{
		_ThrottlePreset = UnitThrottlePreset.Flank;
	}

	public override int GetMaximumSpeed(float Altitude, ActiveUnit.Throttle ThrottleSetting, bool ValidateAndFixAltitude, bool ConsiderDamage = true)
	{
		return (int)Math.Round(Math.Max(Group.GetMaximumCohesiveSpeed(method_2().FetchAllActualActiveUnits(), Altitude, ConsiderDamage, ActiveUnit.Throttle.Flank, ConsiderTerrainAltModifier: false), 1f) * method_2().GetSpeedModifier() * Math.Max(AGU_CONFIG.Instance.AGUSpeedModifier * method_2().CurrentTactic.SpeedModifier, 1f) * (1f - method_2().TotalFriction * AGU_CONFIG.Instance.FrictionSpeedModifier));
	}

	public override int GetMaximumSpeed()
	{
		return GetMaximumSpeed(((ActiveUnit)method_2()).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.MaxPossibleThrottle, ValidateAndFixAltitude: false);
	}

	public override float Acceleration_Actual(ActiveUnit.Throttle theThrottle, float theAltitude, float theSpeed)
	{
		return Math.Max((float)GetMaximumSpeed() * 0.1f, 1f);
	}

	public override float Acceleration_Nominal(ActiveUnit.Throttle theThrottle, float theAltitude)
	{
		return Math.Max((float)GetMaximumSpeed() * 0.1f, 1f);
	}

	public override float TurnRate()
	{
		return 0.5f * AGU_CONFIG.Instance.BaseAGUTurnrate / method_2().GetInfluenceRadius();
	}

	public override void Move(float elapsedTime, bool CheckForMinimumSafeHeight, bool SimplifiedCalcs_DLZ, DateTime ExplicitDateTime, bool GhostMovement = false)
	{
		try
		{
			myUnit.UpdateSettlingOnPosition(elapsedTime * (1f - method_2().Suppression));
			try
			{
				if (myUnit.IsAttachedToRoadSystem)
				{
					if (!method_2().CurrentTactic.IsFullyPrepared)
					{
						myUnit.SetThrottle(ActiveUnit.Throttle.FullStop);
						myUnit.DesiredSpeed = 0f;
						return;
					}
				}
				else if (method_2().Navigator.PlottedCourse.Length == 0)
				{
					myUnit.DesiredSpeed = 0f;
				}
				else if (method_2().HostileFrictionProportion.Count != 0 && method_2().CurrentTactic.ManoeuverOnClash == ClashManoeuverBehaviour.StopMovement)
				{
					myUnit.DesiredSpeed = 0f;
				}
				else
				{
					myUnit.DesiredSpeed = GetMaximumSpeed();
				}
				double num = myUnit.CurrentHeading;
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
				double num2 = (double)Math.Abs(MathFunctions.AngularDifference((float)num, myUnit.CurrentHeading)) * (double)(1f / elapsedTime);
				CalcTurnDeceleration(num2, elapsedTime);
				bool flag = false;
				if (myUnit.DesiredTurnRate == ActiveUnit.TurnRate.Navigation && myUnit.Navigator.HasFlightPlan && (!(myUnit.IsGroupWingman() & (myUnit.get_ParentGroup(UsingMissionPlanner: false) != null)) || Information.IsNothing((object)myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead) || (int)Math.Round(myUnit.CurrentSpeed) == (int)Math.Round(myUnit.get_ParentGroup(UsingMissionPlanner: false).GroupLead.CurrentSpeed)) && (int)Math.Round(num) != (int)Math.Round(myUnit.CurrentHeading))
				{
					int num3;
					if (Information.IsNothing((object)myUnit.Navigator.PreviousWaypointType))
					{
						num3 = 1;
					}
					else
					{
						int? num4 = (int?)myUnit.Navigator.PreviousWaypointType;
						bool? flag2 = ((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 15));
						if (((!flag2) ?? flag2) != true)
						{
							goto IL_02bd;
						}
						num3 = 1;
					}
					flag = (byte)num3 != 0;
				}
				goto IL_02bd;
				IL_02bd:
				if (!flag && myUnit.CurrentSpeed != myUnit.DesiredSpeed)
				{
					GoToDesiredSpeed(elapsedTime, (float)num2);
				}
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

	static AggregateGroundUnit_Kinematics()
	{
		Class72.smethod_20();
	}
}
