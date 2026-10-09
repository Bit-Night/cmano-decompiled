using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotObfuscate]
[DoNotPruneType]
[DoNotPrune]
public sealed class AircraftFuelViewModel : PlatFormViewModel
{
	private double double_0;

	private string string_1;

	private StringBuilder stringBuilder_0;

	public double Percentage
	{
		get
		{
			return double_0;
		}
		set
		{
			SetProperty(ref double_0, value, "Percentage");
		}
	}

	public string Text
	{
		get
		{
			return string_1;
		}
		set
		{
			SetProperty(ref string_1, value, "Text");
		}
	}

	[Obsolete("Used for design time only", true)]
	public AircraftFuelViewModel()
	{
		stringBuilder_0 = new StringBuilder();
	}

	[DoNotPrune]
	[DoNotObfuscate]
	public void Refresh()
	{
		try
		{
			base.UnitName = theUnit.Name;
			stringBuilder_0.Clear();
			Aircraft aircraft = (Aircraft)theUnit;
			Aircraft_AirOps airOps = aircraft.AirOps;
			ActiveUnit._ActiveUnitFuelState isBingoOrJoker = theUnit.IsBingoOrJoker;
			ActiveUnit activeUnit = theUnit;
			double TotalMax = 0.0;
			double TotalCurrent = default(double);
			Percentage = (int)Math.Round(activeUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0);
			float num = aircraft.FuelConsumption(theUnit.ThrottleSetting, null, (int)Math.Round(theUnit.DesiredSpeed), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCheck: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			long num2 = ((theUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop) ? aircraft.get_FuelEndurance(theUnit.ThrottleSetting, (AltBand)null, (float?)theUnit.CurrentSpeed, (float?)theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) : (theUnit.Kinematics.GetCurrentAltBand(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ValidateAndFixAltitude: false).Speed_Full.HasValue ? aircraft.get_FuelEndurance(ActiveUnit.Throttle.Full, (AltBand)null, (float?)theUnit.CurrentSpeed, (float?)theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) : 0L));
			long num3 = ((num == 0f) ? long.MaxValue : ((!(float.IsInfinity(aircraft.FuelState_RemainingFuelToBingo) | float.IsNaN(aircraft.FuelState_RemainingFuelToBingo))) ? ((long)Math.Round(aircraft.FuelState_RemainingFuelToBingo / num)) : long.MaxValue));
			long num4 = ((num == 0f) ? long.MaxValue : ((!(float.IsInfinity(aircraft.FuelState_RemainingFuelToJoker) | float.IsNaN(aircraft.FuelState_RemainingFuelToBingo))) ? ((long)Math.Round(aircraft.FuelState_RemainingFuelToJoker / num)) : long.MaxValue));
			double num5 = Conversions.ToDouble(string.Format("{0:0.0}", TotalCurrent - (double)theUnit.Kinematics.ReserveFuel, 0));
			string text = "kg";
			bool flag;
			if (flag = aircraft.isUAVSizeClass1AndHasDBProvidedEndurance())
			{
				text = Aircraft.UAVSizeClass1FuelUnitOfMeasurementString;
			}
			string text2 = "";
			if (num2 > 0L)
			{
				if (!flag)
				{
					text2 = string.Format("{0:0.0}", TotalCurrent, 0) + " " + text + ", ";
				}
				text2 += Misc.TimeString(num2, 0, ReturnNo: true);
				if (theUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop)
				{
					text2 = text2 + ", " + string.Format("{0:0.0}", (float)num2 * theUnit.CurrentSpeed / 3600f, 0) + " nm";
				}
			}
			else
			{
				text2 = string.Format("{0:0.0}", TotalCurrent, 0) + " " + text + " total fuel";
			}
			string value = ((!(num5 > 0.0)) ? "No mission fuel remaining, using reserve." : (Conversions.ToString(num5) + " " + text + " mission fuel, " + string.Format("{0:0.0}", theUnit.Kinematics.ReserveFuel, 0) + " " + text + " reserve"));
			string value2 = string.Format("{0:0.00}", num * 60f, 1) + " " + text + " / minute fuel burn rate";
			Doctrine._FuelState? bingoJoker = aircraft.Doctrine.BingoJoker;
			string text3 = "";
			if (airOps.get_AssignedHostUnit(PickNewAssignedHost: false) == null)
			{
				text3 = "Aircraft has no home base selected!";
			}
			else
			{
				byte? b = (byte?)bingoJoker;
				bool? flag3;
				bool? flag2 = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)));
				bool? flag4 = ((flag2.HasValue && flag3 != true) ? new bool?(false) : ((isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo) ? flag3 : new bool?(false)));
				if ((flag4 ?? true) && num3 > 0L && flag4.HasValue)
				{
					int num6;
					if (!flag)
					{
						text3 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + " " + text + ", ";
						num6 = 5;
					}
					else
					{
						num6 = 5;
					}
					string[] array = new string[num6];
					array[0] = text3;
					array[1] = Misc.TimeString(num3, 0, ReturnNo: false, ReturnZero: true);
					array[2] = ", ";
					array[3] = string.Format("{0:0.0}", (float)num3 * theUnit.CurrentSpeed / 3600f, 0);
					array[4] = " nm to Bingo fuel";
					text3 = string.Concat(array);
				}
				else if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker && num4 > 0L)
				{
					int num7;
					if (flag)
					{
						num7 = 5;
					}
					else
					{
						text3 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToJoker, 0) + " " + text + ", ";
						num7 = 5;
					}
					string[] array2 = new string[num7];
					array2[0] = text3;
					array2[1] = Misc.TimeString(num4, 0, ReturnNo: false, ReturnZero: true);
					array2[2] = ", ";
					array2[3] = string.Format("{0:0.0}", (float)num4 * theUnit.CurrentSpeed / 3600f, 0);
					array2[4] = " nm to Joker fuel";
					text3 = string.Concat(array2);
				}
				else
				{
					b = (byte?)bingoJoker;
					text3 = ((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) != true) ? ("Has reached JOKER FUEL! " + string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + " " + text + " to Bingo") : "Has reached BINGO FUEL!");
				}
			}
			string value3 = "";
			if (airOps.get_AssignedHostUnit(PickNewAssignedHost: false) != null)
			{
				if (airOps.A2AR_Destination != null)
				{
					value3 = string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + airOps.A2AR_Destination.Name;
				}
				else if (!aircraft.IsGroupWingman())
				{
					value3 = ((aircraft.FuelState_Destination == null) ? "No Bingo fuel destination selected." : (aircraft.FuelState_Destination.IsAircraft ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to base: " + aircraft.FuelState_Destination.Name)));
				}
				else if (((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead != null)
				{
					Aircraft_AirOps airOps2 = ((Aircraft)((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead).AirOps;
					value3 = ((airOps2.A2AR_Destination != null) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + airOps2.A2AR_Destination.Name) : ((aircraft.FuelState_Destination == null) ? "No Bingo fuel destination selected." : ((!aircraft.FuelState_Destination.IsAircraft) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to base: " + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + aircraft.FuelState_Destination.Name))));
				}
			}
			else
			{
				value3 = "";
			}
			List<(string, int, float)> fuelByTank = aircraft.FuelByTank;
			string text4 = "";
			if (fuelByTank.Count > 0)
			{
				int num8 = 1;
				foreach (var item in fuelByTank)
				{
					text4 = text4 + "\r\nTank #" + num8 + ": " + string.Format("{0:0}", (int)Math.Round(item.Item3), 0) + " " + text + " remaining fuel";
					num8++;
				}
			}
			stringBuilder_0.Append(text2).Append("\r\n").Append(value)
				.Append("\r\n");
			if (!flag)
			{
				stringBuilder_0.Append(value2).Append("\r\n");
			}
			stringBuilder_0.Append(text3).Append("\r\n").Append(value3)
				.Append("\r\n")
				.Append(text4);
			Text = stringBuilder_0.ToString();
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

	public AircraftFuelViewModel(Aircraft theUnit)
	{
		stringBuilder_0 = new StringBuilder();
		base.theUnit = theUnit;
		Refresh();
	}

	static AircraftFuelViewModel()
	{
		Class72.smethod_20();
	}
}
