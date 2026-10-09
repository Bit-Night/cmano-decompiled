using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class Form_SetFuelAndAirborneTime : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private DarkLabel qkpLekFpgop;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_RemainingFuel")]
	private TextBox _TB_RemainingFuel;

	[AccessedThroughProperty("TB_AirborneTime")]
	[CompilerGenerated]
	private MaskedTextBox _TB_AirborneTime;

	[AccessedThroughProperty("TB_AltitudeDepth")]
	[CompilerGenerated]
	private TextBox _TB_AltitudeDepth;

	[AccessedThroughProperty("CheckBox1")]
	[CompilerGenerated]
	private DarkCheckBox _CheckBox1;

	[CompilerGenerated]
	[AccessedThroughProperty("FuelTypeCombo")]
	private DarkUIComboBox _FuelTypeCombo;

	private bool bool_2;

	private ActiveUnit activeUnit_0;

	private decimal bZeLeRkjww5;

	private FuelRec fuelRec_0;

	private List<FuelRec> list_0;

	internal virtual DarkLabel Label1
	{
		[CompilerGenerated]
		get
		{
			return qkpLekFpgop;
		}
		[CompilerGenerated]
		set
		{
			qkpLekFpgop = value;
		}
	}

	internal virtual TextBox TB_RemainingFuel
	{
		[CompilerGenerated]
		get
		{
			return _TB_RemainingFuel;
		}
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = method_8;
			EventHandler eventHandler2 = method_10;
			KeyEventHandler val = new KeyEventHandler(method_11);
			TextBox val2 = _TB_RemainingFuel;
			if (val2 != null)
			{
				((Control)val2).Enter -= eventHandler;
				((Control)val2).Validated -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_TB_RemainingFuel = value;
			val2 = _TB_RemainingFuel;
			if (val2 != null)
			{
				((Control)val2).Enter += eventHandler;
				((Control)val2).Validated += eventHandler2;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox TB_AirborneTime
	{
		[CompilerGenerated]
		get
		{
			return _TB_AirborneTime;
		}
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = method_12;
			KeyEventHandler val = new KeyEventHandler(method_13);
			MaskedTextBox val2 = _TB_AirborneTime;
			if (val2 != null)
			{
				((Control)val2).Validated -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TB_AirborneTime = value;
			val2 = _TB_AirborneTime;
			if (val2 != null)
			{
				((Control)val2).Validated += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox TB_AltitudeDepth
	{
		[CompilerGenerated]
		get
		{
			return _TB_AltitudeDepth;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_14;
			TextBox val = _TB_AltitudeDepth;
			if (val != null)
			{
				((Control)val).Validated -= eventHandler;
			}
			_TB_AltitudeDepth = value;
			val = _TB_AltitudeDepth;
			if (val != null)
			{
				((Control)val).Validated += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	internal virtual DarkCheckBox CheckBox1
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkCheckBox darkCheckBox = _CheckBox1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CheckBox1 = value;
			darkCheckBox = _CheckBox1;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkUIComboBox FuelTypeCombo
	{
		[CompilerGenerated]
		get
		{
			return _FuelTypeCombo;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_9;
			DarkUIComboBox darkUIComboBox = _FuelTypeCombo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted -= eventHandler;
			}
			_FuelTypeCombo = value;
			darkUIComboBox = _FuelTypeCombo;
			if (darkUIComboBox != null)
			{
				((ComboBox)darkUIComboBox).SelectionChangeCommitted += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_AltitudeDepthLabel")]
	internal virtual DarkLabel TB_AltitudeDepthLabel { get; set; }

	public Form_SetFuelAndAirborneTime()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += Form_SetFuelAndAirborneTime_Load;
		((Control)this).KeyDown += new KeyEventHandler(Form_SetFuelAndAirborneTime_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(Form_SetFuelAndAirborneTime_FormClosing);
		list_0 = new List<FuelRec>();
		InitializeComponent_1();
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

	private void InitializeComponent_1()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		Label1 = new DarkLabel();
		TB_RemainingFuel = new TextBox();
		TB_AirborneTime = new MaskedTextBox();
		TB_AltitudeDepth = new TextBox();
		Label2 = new DarkLabel();
		CheckBox1 = new DarkCheckBox();
		FuelTypeCombo = new DarkUIComboBox();
		TB_AltitudeDepthLabel = new DarkLabel();
		((Control)this).SuspendLayout();
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(17, 51);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(157, 20);
		((Control)Label1).TabIndex = 0;
		((Label)Label1).Text = "Remaining fuel (units):";
		((TextBoxBase)TB_RemainingFuel).BackColor = Color.Black;
		((TextBoxBase)TB_RemainingFuel).ForeColor = Color.LightGray;
		((Control)TB_RemainingFuel).Location = new Point(180, 51);
		((Control)TB_RemainingFuel).Name = "TB_RemainingFuel";
		((Control)TB_RemainingFuel).Size = new Size(112, 27);
		((Control)TB_RemainingFuel).TabIndex = 1;
		((TextBoxBase)TB_AirborneTime).BackColor = Color.Black;
		((TextBoxBase)TB_AirborneTime).ForeColor = Color.LightGray;
		((Control)TB_AirborneTime).Location = new Point(215, 7);
		TB_AirborneTime.Mask = "00:00:00";
		((Control)TB_AirborneTime).Name = "TB_AirborneTime";
		((Control)TB_AirborneTime).Size = new Size(77, 27);
		((Control)TB_AirborneTime).TabIndex = 2;
		((TextBoxBase)TB_AltitudeDepth).BackColor = Color.Black;
		((TextBoxBase)TB_AltitudeDepth).ForeColor = Color.LightGray;
		((Control)TB_AltitudeDepth).Location = new Point(215, 84);
		((Control)TB_AltitudeDepth).Name = "TB_AltitudeDepth";
		((Control)TB_AltitudeDepth).Size = new Size(77, 27);
		((Control)TB_AltitudeDepth).TabIndex = 2;
		Label2.AutoSize = true;
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(10, 14);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(199, 20);
		((Control)Label2).TabIndex = 3;
		((Label)Label2).Text = "Airborne time (hr : min : sec):";
		((Control)CheckBox1).Location = new Point(316, 7);
		((Control)CheckBox1).Name = "CheckBox1";
		((Control)CheckBox1).Size = new Size(210, 37);
		((Control)CheckBox1).TabIndex = 4;
		((ButtonBase)CheckBox1).Text = "Automatically adjust fuel (optimum altitude + 10%)";
		((ComboBox)FuelTypeCombo).BackColor = Color.Transparent;
		((ComboBox)FuelTypeCombo).DrawMode = (DrawMode)1;
		((ComboBox)FuelTypeCombo).DropDownStyle = (ComboBoxStyle)2;
		((Control)FuelTypeCombo).Font = new Font("Segoe UI", 7f, (FontStyle)0, (GraphicsUnit)3, (byte)161);
		((ListControl)FuelTypeCombo).FormattingEnabled = true;
		((Control)FuelTypeCombo).Location = new Point(316, 54);
		((Control)FuelTypeCombo).Name = "FuelTypeCombo";
		((Control)FuelTypeCombo).Size = new Size(134, 24);
		((Control)FuelTypeCombo).TabIndex = 5;
		((Control)FuelTypeCombo).Visible = false;
		TB_AltitudeDepthLabel.AutoSize = true;
		((Control)TB_AltitudeDepthLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)TB_AltitudeDepthLabel).Location = new Point(17, 82);
		((Control)TB_AltitudeDepthLabel).Name = "TB_AltitudeDepthLabel";
		((Control)TB_AltitudeDepthLabel).Size = new Size(65, 20);
		((Control)TB_AltitudeDepthLabel).TabIndex = 3;
		((Label)TB_AltitudeDepthLabel).Text = "Altitude:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).AutoSize = true;
		((Form)this).ClientSize = new Size(581, 172);
		((Control)this).Controls.Add((Control)(object)FuelTypeCombo);
		((Control)this).Controls.Add((Control)(object)CheckBox1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)TB_AirborneTime);
		((Control)this).Controls.Add((Control)(object)TB_RemainingFuel);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TB_AltitudeDepth);
		((Control)this).Controls.Add((Control)(object)TB_AltitudeDepthLabel);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "Form_SetFuelAndAirborneTime";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Set unit properties for";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_2(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)activeUnit_0) && activeUnit_0.IsAircraft && ((CheckBox)CheckBox1).Checked)
		{
			method_3();
		}
	}

	private void method_3()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		float num = activeUnit_0.FuelConsumption(ActiveUnit.Throttle.Cruise, activeUnit_0.Propulsion[0].get_OptimumAltBandForThisThrottle(ActiveUnit.Throttle.Cruise), null, null, BingoFuelCheck: false, ReserveFuelQtyCalc: false, ExcludeDroppablePayload: false, ValidateThrottleSelection: false, FlightplanFuelEstimate: false);
		float airborneTime = ((Aircraft)activeUnit_0).AirborneTime;
		float num2 = (float)((double)num * 1.1 * (double)airborneTime);
		Aircraft aircraft = (Aircraft)activeUnit_0;
		float num3 = (float)aircraft.FuelCapacityMax - num2;
		if (num3 <= 0f)
		{
			DarkMessageBox.ShowWarning("Fuel quantity will be zero or negative. Skipping auto-calculating fuel quantity.", "");
			return;
		}
		aircraft.FuelCapacitySet(num3);
		bool_2 = false;
		TB_RemainingFuel.Text = Conversions.ToString(num3);
		bool_2 = true;
	}

	private void method_4(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)activeUnit_0) && bool_2 && Versioned.IsNumeric((object)TB_RemainingFuel.Text))
		{
			float fuel = Conversions.ToSingle(TB_RemainingFuel.Text);
			SetFuel(fuel);
		}
	}

	private void method_5()
	{
		list_0.Clear();
		if (activeUnit_0 == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		foreach (object value in Enum.GetValues(typeof(FuelRec._FuelType)))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(value);
			FuelRec._FuelType fuelType = (FuelRec._FuelType)Conversions.ToShort(objectValue);
			num = 0;
			num2 = 0;
			foreach (FuelRec item in activeUnit_0.Fuel_ReadOnly)
			{
				if ((int)item.FuelType == Conversions.ToShort(objectValue))
				{
					num = item.MaxQuantity;
					num2 = (int)Math.Round(item.CurrentQuantity);
				}
			}
			if (num > 0 || (activeUnit_0.IsFixedFacility && fuelType >= FuelRec._FuelType.AviationFuel && fuelType <= FuelRec._FuelType.Gasoline))
			{
				FuelRec fuelRec = new FuelRec(num, Conversions.ToShort(objectValue));
				fuelRec.CurrentQuantity = num2;
				list_0.Add(fuelRec);
			}
		}
	}

	private void Form_SetFuelAndAirborneTime_Load(object sender, EventArgs e)
	{
		DataTable theComboBoxDataSource = new DataTable();
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		bool_2 = false;
		if (Client.SelectedUnit == null || Client.SelectedUnit.IsGroup)
		{
			return;
		}
		((Form)this).Text = ((Form)this).Text + " " + Client.SelectedUnit.Name;
		((Control)TB_RemainingFuel).Enabled = true;
		if (Information.IsNothing((object)Client.SelectedUnit))
		{
			return;
		}
		activeUnit_0 = (ActiveUnit)Client.SelectedUnit;
		method_5();
		if (!Client.SelectedUnit.IsAircraft)
		{
			if (Client.SelectedUnit.IsBoat)
			{
				((Label)Label2).Text = "Time at sea (days: hr : min : sec):";
				TB_AirborneTime.Mask = "00:00:00:00";
				TB_AirborneTime.Text = method_6((int)Math.Round(activeUnit_0.TimeUnderway));
				if (!Client.SelectedUnit.IsSubmarine)
				{
					((Control)TB_AltitudeDepthLabel).Enabled = false;
					((Control)TB_AltitudeDepthLabel).Visible = false;
					((Control)TB_AltitudeDepth).Enabled = false;
					((Control)TB_AltitudeDepth).Visible = false;
				}
				else
				{
					((Label)TB_AltitudeDepthLabel).Text = "Current Depth " + ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? "(M):" : "(FT):");
					TB_AltitudeDepth.Text = Conversions.ToString((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : (3.28084f * Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				}
			}
			else
			{
				((Control)TB_AirborneTime).Enabled = false;
				((Control)TB_AirborneTime).Visible = false;
				((Control)Label2).Enabled = false;
				((Control)Label2).Visible = false;
				((Control)TB_AltitudeDepthLabel).Enabled = false;
				((Control)TB_AltitudeDepthLabel).Visible = false;
				((Control)TB_AltitudeDepth).Enabled = false;
				((Control)TB_AltitudeDepth).Visible = false;
			}
		}
		else
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			((Label)Label2).Text = "Airborne time (hr : min : sec):";
			TB_AirborneTime.Mask = "00:00:00";
			TB_AirborneTime.Text = method_7((int)Math.Round(aircraft.AirborneTime));
			((Label)TB_AltitudeDepthLabel).Text = "Current Altitude " + ((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? "(M):" : "(FT):");
			TB_AltitudeDepth.Text = Conversions.ToString((!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : (3.28084f * Client.SelectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
		}
		if (Client.SelectedUnit.IsActiveUnit)
		{
			if (!Client.SelectedUnit.IsAircraft)
			{
				if (list_0.Count != 0)
				{
					((Control)CheckBox1).Enabled = false;
					((Control)CheckBox1).Visible = false;
					((Control)FuelTypeCombo).Visible = true;
					DarkUIComboBox combobox = FuelTypeCombo;
					BindCombobox_FuelType(ref combobox, ref theComboBoxDataSource, 0);
					FuelTypeCombo = combobox;
					if (activeUnit_0.IsAircraft)
					{
						fuelRec_0 = activeUnit_0.Fuel_ReadOnly[0];
						TB_RemainingFuel.Text = Conversions.ToString(new decimal(activeUnit_0.Fuel_ReadOnly[0].CurrentQuantity));
						if (activeUnit_0.Fuel_ReadOnly.Count == 1)
						{
							((Control)FuelTypeCombo).Enabled = false;
						}
					}
					else
					{
						fuelRec_0 = list_0[0];
						TB_RemainingFuel.Text = Conversions.ToString(new decimal(list_0[0].CurrentQuantity));
						if (list_0.Count == 1)
						{
							((Control)FuelTypeCombo).Enabled = false;
						}
					}
					bZeLeRkjww5 = Conversions.ToDecimal(TB_RemainingFuel.Text);
				}
				else
				{
					((Control)TB_RemainingFuel).Enabled = false;
				}
			}
			else
			{
				Aircraft aircraft2 = (Aircraft)activeUnit_0;
				TB_RemainingFuel.Text = Conversions.ToString(aircraft2.FuelCapacityCurrent);
			}
		}
		bool_2 = true;
	}

	private string method_6(int int_0)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds((double)int_0);
		if (timeSpan.Days > 0)
		{
			return Interaction.IIf(timeSpan.Days < 10, (object)"0", (object)"").ToString() + timeSpan.Days + ":" + Interaction.IIf(timeSpan.Hours < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Hours) + ":" + Interaction.IIf(timeSpan.Minutes == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Minutes < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Minutes))).ToString() + ":" + Interaction.IIf(timeSpan.Seconds == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds))).ToString();
		}
		if (timeSpan.Hours > 0)
		{
			return "00:" + Interaction.IIf(timeSpan.Hours < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Hours) + ":" + Interaction.IIf(timeSpan.Minutes == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Minutes < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Minutes))).ToString() + ":" + Interaction.IIf(timeSpan.Seconds == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds))).ToString();
		}
		if (timeSpan.Minutes > 0)
		{
			return "00:00:" + Interaction.IIf(timeSpan.Minutes < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Minutes) + ":" + Interaction.IIf(timeSpan.Seconds == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds))).ToString();
		}
		if (timeSpan.Seconds > 0)
		{
			return "00:00:00:" + Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds);
		}
		return "00:00:00:00";
	}

	private string method_7(int int_0)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds((double)int_0);
		if (timeSpan.Hours <= 0)
		{
			if (timeSpan.Minutes > 0)
			{
				return "00:" + Interaction.IIf(timeSpan.Minutes < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Minutes) + ":" + Interaction.IIf(timeSpan.Seconds == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds))).ToString();
			}
			if (timeSpan.Seconds > 0)
			{
				return "00:00:" + Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds);
			}
			return "00:00:00";
		}
		return Interaction.IIf(timeSpan.Hours < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Hours) + ":" + Interaction.IIf(timeSpan.Minutes == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Minutes < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Minutes))).ToString() + ":" + Interaction.IIf(timeSpan.Seconds == 0, (object)"00", (object)(Interaction.IIf(timeSpan.Seconds < 10, (object)"0", (object)"").ToString() + Conversions.ToString(timeSpan.Seconds))).ToString();
	}

	private void Form_SetFuelAndAirborneTime_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if (((int)e.KeyCode != 13 || !((Control)this).Visible) && ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123))
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void method_8(object sender, EventArgs e)
	{
		if (Versioned.IsNumeric((object)TB_RemainingFuel.Text))
		{
			bZeLeRkjww5 = Conversions.ToDecimal(TB_RemainingFuel.Text);
		}
	}

	private void Form_SetFuelAndAirborneTime_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (activeUnit_0 != null && !activeUnit_0.IsAircraft)
		{
			FuelRec fuelRec = null;
			foreach (FuelRec item in list_0)
			{
				fuelRec = null;
				foreach (FuelRec item2 in activeUnit_0.Fuel_ReadOnly)
				{
					if (item2.FuelType == item.FuelType)
					{
						fuelRec = item2;
						break;
					}
				}
				if (fuelRec != null)
				{
					fuelRec.MaxQuantity = item.MaxQuantity;
					fuelRec.CurrentQuantity = item.CurrentQuantity;
				}
				else if (item.CurrentQuantity > 0f)
				{
					activeUnit_0.AddFuelRec(item);
				}
			}
		}
		((Control)MyProject.Forms.MainForm).Enabled = true;
		Client.MustRefreshMainForm = true;
		if (Client.CurrentGame.Status == Game._GameStatus.Paused)
		{
			MyProject.Forms.MainForm.RightColumn1.RefreshPanels(Client.CurrentScenario, Client.CurrentSide, Client.SelectedUnit, v: false);
		}
	}

	public void BindCombobox_FuelType(ref DarkUIComboBox combobox, ref DataTable theComboBoxDataSource, short index)
	{
		if (!theComboBoxDataSource.Columns.Contains("ID"))
		{
			theComboBoxDataSource.Columns.Add("ID", typeof(int));
		}
		int num;
		if (!theComboBoxDataSource.Columns.Contains("Description"))
		{
			theComboBoxDataSource.Columns.Add("Description", typeof(string));
			num = 0;
		}
		else
		{
			num = 0;
		}
		int num2 = num;
		foreach (FuelRec item in list_0)
		{
			theComboBoxDataSource.Rows.Add(num2, item.FuelType.ToString());
			if (num2 == index)
			{
				fuelRec_0 = item;
			}
			num2++;
		}
		DarkUIComboBox obj = combobox;
		((ComboBox)obj).DataSource = theComboBoxDataSource;
		((ListControl)obj).DisplayMember = "Description";
		((ListControl)obj).ValueMember = "ID";
		((ComboBox)obj).SelectedIndex = index;
	}

	private void SetFuel(float theFuel)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		if (Client.SelectedUnit == null)
		{
			return;
		}
		if (!(theFuel > 0f) && (activeUnit_0.IsAircraft || theFuel != 0f))
		{
			TB_RemainingFuel.Text = Conversions.ToString(bZeLeRkjww5);
			if (activeUnit_0.IsAircraft)
			{
				DarkMessageBox.ShowError("Fuel quantity cannot be zero or negative.", "");
			}
			else
			{
				DarkMessageBox.ShowError("Fuel quantity cannot be negative.", "");
			}
			return;
		}
		if (activeUnit_0.IsAircraft)
		{
			Aircraft aircraft = (Aircraft)activeUnit_0;
			aircraft.FuelCapacitySet(Conversions.ToSingle(TB_RemainingFuel.Text));
			TB_RemainingFuel.Text = Conversions.ToString(aircraft.FuelCapacityCurrent);
			return;
		}
		if (theFuel > (float)fuelRec_0.MaxQuantity)
		{
			if (activeUnit_0.IsFixedFacility)
			{
				fuelRec_0.MaxQuantity = (int)Math.Ceiling(theFuel);
			}
			else
			{
				theFuel = fuelRec_0.MaxQuantity;
				TB_RemainingFuel.Text = Conversions.ToString(new decimal(theFuel));
			}
		}
		fuelRec_0.CurrentQuantity = theFuel;
	}

	private void method_9(object sender, EventArgs e)
	{
		if (activeUnit_0.IsAircraft)
		{
			fuelRec_0 = activeUnit_0.Fuel_ReadOnly[((ComboBox)FuelTypeCombo).SelectedIndex];
		}
		else
		{
			fuelRec_0 = list_0[((ComboBox)FuelTypeCombo).SelectedIndex];
		}
		TB_RemainingFuel.Text = Conversions.ToString(new decimal(fuelRec_0.CurrentQuantity));
		bZeLeRkjww5 = Conversions.ToDecimal(TB_RemainingFuel.Text);
	}

	private void method_10(object sender, EventArgs e)
	{
		if (!Information.IsNothing((object)activeUnit_0) && bool_2 && Versioned.IsNumeric((object)TB_RemainingFuel.Text))
		{
			float fuel = Conversions.ToSingle(TB_RemainingFuel.Text);
			SetFuel(fuel);
		}
	}

	private void method_11(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			e.SuppressKeyPress = true;
			method_10(RuntimeHelpers.GetObjectValue(sender), (EventArgs)(object)e);
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		List<string> list = TB_AirborneTime.Text.Replace(".", ":").Split(new char[1] { ':' }).ToList();
		if (list.Count == 3)
		{
			if (!(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2])))
			{
				return;
			}
		}
		else if (list.Count != 4 || !(Versioned.IsNumeric((object)list[0]) & Versioned.IsNumeric((object)list[1]) & Versioned.IsNumeric((object)list[2]) & Versioned.IsNumeric((object)list[3])))
		{
			return;
		}
		TimeSpan timeSpan = default(TimeSpan);
		if (list.Count == 3)
		{
			timeSpan = new TimeSpan(Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]));
		}
		if (list.Count == 4)
		{
			timeSpan = new TimeSpan(Conversions.ToInteger(list[0]), Conversions.ToInteger(list[1]), Conversions.ToInteger(list[2]), Conversions.ToInteger(list[3]));
		}
		if (!activeUnit_0.IsAircraft)
		{
			if (activeUnit_0.IsBoat)
			{
				activeUnit_0.TimeUnderway = (float)timeSpan.TotalSeconds;
			}
		}
		else
		{
			((Aircraft)activeUnit_0).AirborneTime = (float)timeSpan.TotalSeconds;
		}
		if (((CheckBox)CheckBox1).Checked)
		{
			method_3();
		}
	}

	private void method_13(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			e.SuppressKeyPress = true;
			method_12(RuntimeHelpers.GetObjectValue(sender), (EventArgs)(object)e);
		}
	}

	private void method_14(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(TB_AltitudeDepth.Text))
		{
			return;
		}
		if (!activeUnit_0.IsAircraft)
		{
			if (activeUnit_0.IsSubmarine && !(Conversions.ToSingle(TB_AltitudeDepth.Text) > 0f))
			{
				activeUnit_0.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? Conversions.ToSingle(TB_AltitudeDepth.Text) : (Conversions.ToSingle(TB_AltitudeDepth.Text) / 3.28084f));
				activeUnit_0.DesiredAltitude = activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
		}
		else if (!(Conversions.ToSingle(TB_AltitudeDepth.Text) < 0f))
		{
			activeUnit_0.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet) ? Conversions.ToSingle(TB_AltitudeDepth.Text) : (Conversions.ToSingle(TB_AltitudeDepth.Text) / 3.28084f));
			activeUnit_0.DesiredAltitude = activeUnit_0.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		}
	}

	static Form_SetFuelAndAirborneTime()
	{
		Class72.smethod_20();
	}
}
