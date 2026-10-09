using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanel_Submarine : DarkUserControl
{
	private IContainer icontainer_1;

	private int ActualWidth;

	private FuelRec._FuelType _FuelType_0;

	private FuelRec._FuelType _FuelType_1;

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	[field: AccessedThroughProperty("Label_AIP")]
	internal virtual DarkLabel Label_AIP { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual DarkLabel Label2 { get; set; }

	[field: AccessedThroughProperty("Label_Endurance")]
	internal virtual DarkLabel Label_Endurance { get; set; }

	[field: AccessedThroughProperty("PB_Diesel")]
	internal virtual DarkUIProgressBar PB_Diesel { get; set; }

	[field: AccessedThroughProperty("PB_Battery")]
	internal virtual DarkUIProgressBar PB_Battery { get; set; }

	[field: AccessedThroughProperty("PB_AIP")]
	internal virtual DarkUIProgressBar PB_AIP { get; set; }

	public FuelPanel_Submarine()
	{
		((UserControl)this).Load += FuelPanel_Submarine_Load;
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
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		Label_Endurance = new DarkLabel();
		Label_AIP = new DarkLabel();
		Label2 = new DarkLabel();
		Label1 = new DarkLabel();
		PB_Diesel = new DarkUIProgressBar();
		PB_Battery = new DarkUIProgressBar();
		PB_AIP = new DarkUIProgressBar();
		((Control)this).SuspendLayout();
		Label_Endurance.AutoSize = true;
		((Control)Label_Endurance).BackColor = Color.Transparent;
		((Control)Label_Endurance).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label_Endurance).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_Endurance).Location = new Point(3, 61);
		((Control)Label_Endurance).Name = "Label_Endurance";
		((Control)Label_Endurance).Size = new Size(62, 13);
		((Control)Label_Endurance).TabIndex = 8;
		((Label)Label_Endurance).Text = "Endurance:";
		Label_AIP.AutoSize = true;
		((Control)Label_AIP).BackColor = Color.Transparent;
		((Control)Label_AIP).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label_AIP).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label_AIP).Location = new Point(3, 42);
		((Control)Label_AIP).Name = "Label_AIP";
		((Control)Label_AIP).Size = new Size(27, 13);
		((Control)Label_AIP).TabIndex = 6;
		((Label)Label_AIP).Text = "AIP:";
		Label2.AutoSize = true;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label2).Location = new Point(3, 23);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(43, 13);
		((Control)Label2).TabIndex = 4;
		((Label)Label2).Text = "Battery:";
		Label1.AutoSize = true;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font(Client.CommandDefaultFont.FontFamily, 8.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(3, 2);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(39, 13);
		((Control)Label1).TabIndex = 2;
		((Label)Label1).Text = "Diesel:";
		((Control)PB_Diesel).BackColor = Color.Transparent;
		((Control)PB_Diesel).Font = new Font(Client.CommandDefaultFont.FontFamily, 9f);
		((Control)PB_Diesel).Location = new Point(51, 0);
		PB_Diesel.Maximum = 100;
		((Control)PB_Diesel).Name = "PB_Diesel";
		PB_Diesel.ShowProgressLines = true;
		PB_Diesel.ShowProgressValue = true;
		((Control)PB_Diesel).Size = new Size(180, 18);
		((Control)PB_Diesel).TabIndex = 9;
		PB_Diesel.Value = 0;
		((Control)PB_Battery).BackColor = Color.Transparent;
		((Control)PB_Battery).Font = new Font(Client.CommandDefaultFont.FontFamily, 9f);
		((Control)PB_Battery).Location = new Point(51, 20);
		PB_Battery.Maximum = 100;
		((Control)PB_Battery).Name = "PB_Battery";
		PB_Battery.ShowProgressLines = true;
		PB_Battery.ShowProgressValue = true;
		((Control)PB_Battery).Size = new Size(180, 18);
		((Control)PB_Battery).TabIndex = 10;
		PB_Battery.Value = 0;
		((Control)PB_AIP).BackColor = Color.Transparent;
		((Control)PB_AIP).Font = new Font(Client.CommandDefaultFont.FontFamily, 9f);
		((Control)PB_AIP).Location = new Point(51, 40);
		PB_AIP.Maximum = 100;
		((Control)PB_AIP).Name = "PB_AIP";
		PB_AIP.ShowProgressLines = true;
		PB_AIP.ShowProgressValue = true;
		((Control)PB_AIP).Size = new Size(180, 18);
		((Control)PB_AIP).TabIndex = 11;
		PB_AIP.Value = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).Controls.Add((Control)(object)PB_AIP);
		((Control)this).Controls.Add((Control)(object)PB_Battery);
		((Control)this).Controls.Add((Control)(object)PB_Diesel);
		((Control)this).Controls.Add((Control)(object)Label_Endurance);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label_AIP);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Margin = new Padding(0);
		((Control)this).Name = "FuelPanel_Submarine";
		((Control)this).Size = new Size(232, 102);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public void RefreshPanel(ActiveUnit theUnit)
	{
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		if (theUnit.Fuel_ReadOnly.Count == 0)
		{
			return;
		}
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
		FuelRec fuelRec = theUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.DieselFuel).ElementAtOrDefault(0);
		if (!Information.IsNothing((object)fuelRec))
		{
			PB_Diesel.Value = (int)Math.Round(fuelRec.PercentFull * 100f);
			((Control)PB_Diesel).Text = string.Format("{0:0.0}", fuelRec.CurrentQuantity, 0) + " fuel units remaining";
		}
		FuelRec fuelRec2 = theUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.Battery).ElementAtOrDefault(0);
		if (!Information.IsNothing((object)fuelRec2))
		{
			PB_Battery.Value = (int)Math.Round(fuelRec2.PercentFull * 100f);
			((Control)PB_Battery).Text = string.Format("{0:0.0}", fuelRec2.CurrentQuantity, 0) + " fuel units remaining";
		}
		Submarine submarine = (Submarine)theUnit;
		if (submarine.IsAIP)
		{
			((Control)Label_AIP).Visible = true;
			((Control)PB_AIP).Visible = true;
			FuelRec fuelRec3 = theUnit.Fuel_ReadOnly.Where([SpecialName] (FuelRec theRec) => theRec.FuelType == FuelRec._FuelType.AirIndepedent).ElementAtOrDefault(0);
			PB_AIP.Value = (int)Math.Round(fuelRec3.PercentFull * 100f);
			((Control)PB_AIP).Text = string.Format("{0:0.0}", fuelRec3.CurrentQuantity, 0) + " fuel units remaining";
		}
		else
		{
			((Control)Label_AIP).Visible = false;
			((Control)PB_AIP).Visible = false;
		}
		_FuelType_1 = submarine.AI.SelectFuelTypeToConsume(submarine.PrimaryEngine);
		if (_FuelType_1 != _FuelType_0)
		{
			((Control)Label1).Font = new Font(((Control)Label1).Font, (FontStyle)0);
			((Control)Label2).Font = new Font(((Control)Label2).Font, (FontStyle)0);
			((Control)Label_AIP).Font = new Font(((Control)Label_AIP).Font, (FontStyle)0);
			switch (_FuelType_1)
			{
			case FuelRec._FuelType.AirIndepedent:
				((Control)Label_AIP).Font = new Font(((Control)Label_AIP).Font, (FontStyle)1);
				break;
			case FuelRec._FuelType.Battery:
				((Control)Label2).Font = new Font(((Control)Label2).Font, (FontStyle)1);
				break;
			case FuelRec._FuelType.DieselFuel:
				((Control)Label1).Font = new Font(((Control)Label1).Font, (FontStyle)1);
				break;
			}
			_FuelType_0 = _FuelType_1;
		}
		long num = submarine.get_FuelEndurance(theUnit.ThrottleSetting, (AltBand)null, (float?)(int)Math.Round(theUnit.DesiredSpeed), (float?)theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), submarine.PrimaryEngine, submarine.PrimaryEngineNo);
		string text = ((theUnit.ThrottleSetting != ActiveUnit.Throttle.FullStop) ? (Misc.TimeString(num, 0, ReturnNo: false, ReturnZero: true) + ", " + string.Format("{0:0.0}", (float)num * theUnit.CurrentSpeed / 3600f, 0) + " nm") : "Unit is at full stop");
		((Label)Label_Endurance).Text = "Endurance: " + text;
	}

	private void FuelPanel_Submarine_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static FuelPanel_Submarine()
	{
		Class72.smethod_20();
	}
}
