using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_Aircraft : DarkUserControl
{
	private IContainer icontainer_1;

	private int ActualWidth;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("ProgressBar1")]
	internal virtual DarkUIProgressBar ProgressBar1 { get; set; }

	[field: AccessedThroughProperty("Splitter1")]
	internal virtual Splitter Splitter1 { get; set; }

	[field: AccessedThroughProperty("LblAirborneTime")]
	internal virtual DarkLabel LblAirborneTime { get; set; }

	public FuelPanel_Aircraft()
	{
		((UserControl)this).Load += FuelPanel_Aircraft_Load;
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_1 != null)
			{
				icontainer_1.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		Label1 = new DarkLabel();
		ProgressBar1 = new DarkUIProgressBar();
		Splitter1 = new Splitter();
		LblAirborneTime = new DarkLabel();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 26);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(39, 13);
		((Control)Label1).TabIndex = 2;
		((Label)Label1).Text = "Label1";
		((Control)ProgressBar1).BackColor = Color.Transparent;
		ProgressBar1.CustomForeColor = Color.Transparent;
		((Control)ProgressBar1).Location = new Point(0, 0);
		ProgressBar1.Maximum = 100;
		((Control)ProgressBar1).Name = "ProgressBar1";
		ProgressBar1.ShowProgressLines = true;
		ProgressBar1.ShowProgressValue = true;
		ProgressBar1.ShowText = false;
		((Control)ProgressBar1).Size = new Size(231, 23);
		((Control)ProgressBar1).TabIndex = 1;
		ProgressBar1.Value = 0;
		Splitter1.Dock = (DockStyle)2;
		((Control)Splitter1).Location = new Point(0, 100);
		((Control)Splitter1).Name = "Splitter1";
		((Control)Splitter1).Size = new Size(232, 25);
		((Control)Splitter1).TabIndex = 3;
		Splitter1.TabStop = false;
		LblAirborneTime.AutoSize = true;
		((Control)LblAirborneTime).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)LblAirborneTime).Location = new Point(3, 107);
		((Control)LblAirborneTime).Name = "LblAirborneTime";
		((Control)LblAirborneTime).Size = new Size(62, 13);
		((Control)LblAirborneTime).TabIndex = 4;
		((Label)LblAirborneTime).Text = "DarkLabel1";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)LblAirborneTime);
		((Control)this).Controls.Add((Control)(object)Splitter1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Margin = new Padding(0);
		((Control)this).Name = "FuelPanel_Aircraft";
		((Control)this).Size = new Size(232, 125);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void RefreshPanel(ActiveUnit theUnit)
	{
		try
		{
			if (Client.DPI_scale != 1f)
			{
				if (ActualWidth == 0)
				{
					ActualWidth = ((Control)this).Width;
				}
				if (ActualWidth == ((Control)this).Width)
				{
					((Control)this).Width = (int)Math.Round((float)((Control)this).Width * Client.DPI_scale);
				}
			}
			if (!theUnit.IsAircraft)
			{
				return;
			}
			Aircraft aircraft = (Aircraft)theUnit;
			Aircraft_AirOps airOps = aircraft.AirOps;
			ActiveUnit._ActiveUnitFuelState isBingoOrJoker = theUnit.IsBingoOrJoker;
			DarkUIProgressBar progressBar = ProgressBar1;
			double TotalMax = 0.0;
			double TotalCurrent = default(double);
			progressBar.Value = (int)Math.Round(theUnit.FuelPercent(ref TotalCurrent, ref TotalMax, MissionFuel: false) * 100.0);
			ActiveUnit.Throttle theThrottle = ((!aircraft.get_CanHover(bool_7: false) || !(theUnit.DesiredSpeed < (float)theUnit.Kinematics.GetMaximumSpeed(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: false))) ? theUnit.ThrottleSetting : ((!theUnit.Kinematics.CanApplyFlankThrottle()) ? ActiveUnit.Throttle.Full : ActiveUnit.Throttle.Flank));
			float num = aircraft.FuelConsumption(theUnit.ThrottleSetting, null, (int)Math.Round(theUnit.DesiredSpeed), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), BingoFuelCheck: false, ReserveFuelQtyCalc: false, CombatRadiusCheck: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
			long num2 = aircraft.get_FuelEndurance(theThrottle, (AltBand)null, (float?)theUnit.CurrentSpeed, (float?)theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
			long num3 = ((num != 0f) ? ((long)Math.Round(aircraft.FuelState_RemainingFuelToBingo / num)) : long.MaxValue);
			long num4 = ((num != 0f) ? ((long)Math.Round(aircraft.FuelState_RemainingFuelToJoker / num)) : long.MaxValue);
			double num5 = TotalCurrent - (double)theUnit.Kinematics.ReserveFuel;
			string text = "kg";
			bool flag;
			if (flag = aircraft.isUAVSizeClass1AndHasDBProvidedEndurance())
			{
				text = Aircraft.UAVSizeClass1FuelUnitOfMeasurementString;
			}
			string text2 = "";
			int num6;
			if (!flag)
			{
				text2 = string.Format("{0:0.0}", TotalCurrent, 0) + " " + text + " total fuel, ";
				num6 = 5;
			}
			else
			{
				num6 = 5;
			}
			string[] array = new string[num6];
			array[0] = text2;
			array[1] = Misc.TimeString(num2, 0, ReturnNo: true);
			array[2] = ", ";
			array[3] = string.Format("{0:0.0}", (float)num2 * theUnit.CurrentSpeed / 3600f, 0);
			array[4] = " nm";
			text2 = string.Concat(array);
			string text3 = ((!(num5 > 0.0)) ? "No mission fuel remaining, using reserve." : ($"{num5:1} " + text + " mission fuel, " + string.Format("{0:0.0}", theUnit.Kinematics.ReserveFuel, 0) + " " + text + " reserve"));
			string text4 = "";
			if (!flag)
			{
				text4 = string.Format("{0:0.00}", num * 60f, 1) + " " + text + " / minute fuel burn rate";
			}
			Doctrine._FuelState? bingoJoker = aircraft.Doctrine.BingoJoker;
			string text5 = "";
			if (!Information.IsNothing((object)airOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
			{
				byte? b = (byte?)bingoJoker;
				bool? flag3;
				bool? flag2 = (flag3 = ((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)));
				bool? flag4 = ((flag2.HasValue && flag3 != true) ? new bool?(false) : ((isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo) ? flag3 : new bool?(false)));
				if ((flag4 ?? true) && num3 > 0L && flag4.HasValue)
				{
					int num7;
					if (flag)
					{
						num7 = 5;
					}
					else
					{
						text5 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + " " + text + ", ";
						num7 = 5;
					}
					string[] array2 = new string[num7];
					array2[0] = text5;
					array2[1] = Misc.TimeString(num3, 0, ReturnNo: false, ReturnZero: true);
					array2[2] = ", ";
					array2[3] = string.Format("{0:0.0}", (float)num3 * theUnit.CurrentSpeed / 3600f, 0);
					array2[4] = " nm to Bingo fuel";
					text5 = string.Concat(array2);
				}
				else if (isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsBingo && isBingoOrJoker != ActiveUnit._ActiveUnitFuelState.IsJoker && num4 > 0L)
				{
					int num8;
					if (flag)
					{
						num8 = 5;
					}
					else
					{
						text5 = string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToJoker, 0) + " " + text + ", ";
						num8 = 5;
					}
					string[] array3 = new string[num8];
					array3[0] = text5;
					array3[1] = Misc.TimeString(num4, 0, ReturnNo: false, ReturnZero: true);
					array3[2] = ", ";
					array3[3] = string.Format("{0:0.0}", (float)num4 * theUnit.CurrentSpeed / 3600f, 0);
					array3[4] = " nm to Joker fuel";
					text5 = string.Concat(array3);
				}
				else
				{
					b = (byte?)bingoJoker;
					text5 = ((((!b.HasValue) ? ((bool?)null) : new bool?(b.GetValueOrDefault() == 0)) == true) ? "Has reached BINGO FUEL!" : ("Has reached JOKER FUEL! " + string.Format("{0:0.0}", aircraft.FuelState_RemainingFuelToBingo, 0) + " " + text + " to Bingo"));
				}
			}
			else
			{
				text5 = "Aircraft has no home base selected!";
			}
			string text6 = default(string);
			if (Information.IsNothing((object)airOps.get_AssignedHostUnit(PickNewAssignedHost: false)))
			{
				text6 = "";
			}
			else if (!Information.IsNothing((object)airOps.A2AR_Destination))
			{
				text6 = string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + airOps.A2AR_Destination.Name;
			}
			else if (!aircraft.IsGroupWingman())
			{
				text6 = (Information.IsNothing((object)aircraft.FuelState_Destination) ? "No Bingo fuel destination selected." : ((!aircraft.FuelState_Destination.IsAircraft) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to base: " + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + aircraft.FuelState_Destination.Name)));
			}
			else if (!Information.IsNothing((object)((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead))
			{
				Aircraft_AirOps airOps2 = ((Aircraft)((ActiveUnit)aircraft).get_ParentGroup(UsingMissionPlanner: false).GroupLead).AirOps;
				text6 = ((!Information.IsNothing((object)airOps2.A2AR_Destination)) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + airOps2.A2AR_Destination.Name) : (Information.IsNothing((object)aircraft.FuelState_Destination) ? "No Bingo fuel destination selected." : ((!aircraft.FuelState_Destination.IsAircraft) ? (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to base: " + aircraft.FuelState_Destination.Name) : (string.Format("{0:0.0}", aircraft.FuelState_DistanceToBase, 0) + " nm to tanker: " + aircraft.FuelState_Destination.Name))));
			}
			if (aircraft.AirborneTime <= 0f)
			{
				string text7 = "";
				((Control)LblAirborneTime).Visible = false;
			}
			else
			{
				((Control)LblAirborneTime).Visible = true;
				string text7 = Misc.TimeString((long)Math.Round(aircraft.AirborneTime), 0, ReturnNo: false, ReturnZero: true);
				if (aircraft.MAX_Exhaustion != float.MaxValue)
				{
					float current_Exhaustion = ((Aircraft)theUnit).Current_Exhaustion;
					float mAX_Exhaustion = ((Aircraft)theUnit).MAX_Exhaustion;
					float num9 = current_Exhaustion * 100f / mAX_Exhaustion;
					if (num9 >= 0.7f && num9 <= 1f)
					{
						((Control)LblAirborneTime).ForeColor = Color.LightGreen;
					}
					else if (num9 >= 0.5f && num9 <= 0.7f)
					{
						((Control)LblAirborneTime).ForeColor = Color.Lime;
					}
					else if (num9 >= 0.3f && num9 <= 0.5f)
					{
						((Control)LblAirborneTime).ForeColor = Color.Yellow;
					}
					else if (num9 >= 0.1f && num9 <= 0.3f)
					{
						((Control)LblAirborneTime).ForeColor = Color.Orange;
					}
					else if (num9 >= 0f && num9 <= 0.1f)
					{
						((Control)LblAirborneTime).ForeColor = Color.Red;
					}
					((Label)LblAirborneTime).Text = "Flying Time:" + text7 + " / " + Misc.TimeString((long)Math.Round(mAX_Exhaustion));
				}
				else
				{
					((Control)LblAirborneTime).ForeColor = Color.White;
					((Label)LblAirborneTime).Text = text7 + " Flying time";
				}
			}
			_ = aircraft.FuelByTank;
			((Label)Label1).Text = text2 + "\r\n" + text3 + "\r\n";
			DarkLabel label;
			if (!flag)
			{
				((Label)(label = Label1)).Text = ((Label)label).Text + text4 + "\r\n";
			}
			((Label)(label = Label1)).Text = ((Label)label).Text + text5 + "\r\n" + text6;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200118", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void FuelPanel_Aircraft_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static FuelPanel_Aircraft()
	{
		Class72.smethod_20();
	}
}
