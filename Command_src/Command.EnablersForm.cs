using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class EnablersForm : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_GPS")]
	private DarkCheckBox _CB_GPS;

	[AccessedThroughProperty("CB_GLONASS")]
	[CompilerGenerated]
	private DarkCheckBox _CB_GLONASS;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_BeiDou")]
	private DarkCheckBox _CB_BeiDou;

	[AccessedThroughProperty("CB_NavIC")]
	[CompilerGenerated]
	private DarkCheckBox _CB_NavIC;

	public Side SelectedSide;

	public Zone SelectedZone;

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	internal virtual DarkCheckBox CB_GPS
	{
		[CompilerGenerated]
		get
		{
			return _CB_GPS;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			DarkCheckBox darkCheckBox = _CB_GPS;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_GPS = value;
			darkCheckBox = _CB_GPS;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_GLONASS
	{
		[CompilerGenerated]
		get
		{
			return _CB_GLONASS;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			DarkCheckBox darkCheckBox = _CB_GLONASS;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_GLONASS = value;
			darkCheckBox = _CB_GLONASS;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("CB_BLOS_LEO")]
	internal virtual DarkCheckBox CB_BLOS_LEO { get; set; }

	[field: AccessedThroughProperty("CB_BLOS_MEO")]
	internal virtual DarkCheckBox CB_BLOS_MEO { get; set; }

	[field: AccessedThroughProperty("CB_BLOS_GEOHEO")]
	internal virtual DarkCheckBox CB_BLOS_GEOHEO { get; set; }

	[field: AccessedThroughProperty("CB_BLOS_Cell_G5")]
	internal virtual DarkCheckBox CB_BLOS_Cell_G5 { get; set; }

	[field: AccessedThroughProperty("DarkCheckBox2")]
	internal virtual DarkCheckBox DarkCheckBox2 { get; set; }

	internal virtual DarkCheckBox CB_BeiDou
	{
		[CompilerGenerated]
		get
		{
			return _CB_BeiDou;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_4;
			DarkCheckBox darkCheckBox = _CB_BeiDou;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_BeiDou = value;
			darkCheckBox = _CB_BeiDou;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual DarkCheckBox CB_NavIC
	{
		[CompilerGenerated]
		get
		{
			return _CB_NavIC;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_5;
			DarkCheckBox darkCheckBox = _CB_NavIC;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_NavIC = value;
			darkCheckBox = _CB_NavIC;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	public EnablersForm()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Shown += EnablersForm_Shown;
		((Form)this).FormClosing += new FormClosingEventHandler(EnablersForm_FormClosing);
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
		DarkLabel1 = new DarkLabel();
		CB_GPS = new DarkCheckBox();
		CB_GLONASS = new DarkCheckBox();
		CB_BLOS_LEO = new DarkCheckBox();
		CB_BLOS_MEO = new DarkCheckBox();
		CB_BLOS_GEOHEO = new DarkCheckBox();
		CB_BLOS_Cell_G5 = new DarkCheckBox();
		DarkCheckBox2 = new DarkCheckBox();
		CB_BeiDou = new DarkCheckBox();
		CB_NavIC = new DarkCheckBox();
		((Control)this).SuspendLayout();
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(5, 5);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(239, 15);
		((Control)DarkLabel1).TabIndex = 0;
		((Label)DarkLabel1).Text = "Side has access to the following capabilities:";
		((ButtonBase)CB_GPS).AutoSize = true;
		((Control)CB_GPS).Location = new Point(8, 34);
		((Control)CB_GPS).Name = "CB_GPS";
		((Control)CB_GPS).Size = new Size(47, 19);
		((Control)CB_GPS).TabIndex = 1;
		((ButtonBase)CB_GPS).Text = "GPS";
		((ButtonBase)CB_GLONASS).AutoSize = true;
		((Control)CB_GLONASS).Location = new Point(8, 59);
		((Control)CB_GLONASS).Name = "CB_GLONASS";
		((Control)CB_GLONASS).Size = new Size(78, 19);
		((Control)CB_GLONASS).TabIndex = 2;
		((ButtonBase)CB_GLONASS).Text = "GLONASS";
		((ButtonBase)CB_BLOS_LEO).AutoSize = true;
		((CheckBox)CB_BLOS_LEO).Checked = true;
		((CheckBox)CB_BLOS_LEO).CheckState = (CheckState)1;
		((Control)CB_BLOS_LEO).Enabled = false;
		((Control)CB_BLOS_LEO).Location = new Point(8, 134);
		((Control)CB_BLOS_LEO).Name = "CB_BLOS_LEO";
		((Control)CB_BLOS_LEO).Size = new Size(144, 19);
		((Control)CB_BLOS_LEO).TabIndex = 3;
		((ButtonBase)CB_BLOS_LEO).Text = "BLOS (SATCOM) - LEO";
		((ButtonBase)CB_BLOS_MEO).AutoSize = true;
		((CheckBox)CB_BLOS_MEO).Checked = true;
		((CheckBox)CB_BLOS_MEO).CheckState = (CheckState)1;
		((Control)CB_BLOS_MEO).Enabled = false;
		((Control)CB_BLOS_MEO).Location = new Point(8, 159);
		((Control)CB_BLOS_MEO).Name = "CB_BLOS_MEO";
		((Control)CB_BLOS_MEO).Size = new Size(149, 19);
		((Control)CB_BLOS_MEO).TabIndex = 4;
		((ButtonBase)CB_BLOS_MEO).Text = "BLOS (SATCOM) - MEO";
		((ButtonBase)CB_BLOS_GEOHEO).AutoSize = true;
		((CheckBox)CB_BLOS_GEOHEO).Checked = true;
		((CheckBox)CB_BLOS_GEOHEO).CheckState = (CheckState)1;
		((Control)CB_BLOS_GEOHEO).Enabled = false;
		((Control)CB_BLOS_GEOHEO).Location = new Point(8, 184);
		((Control)CB_BLOS_GEOHEO).Name = "CB_BLOS_GEOHEO";
		((Control)CB_BLOS_GEOHEO).Size = new Size(175, 19);
		((Control)CB_BLOS_GEOHEO).TabIndex = 5;
		((ButtonBase)CB_BLOS_GEOHEO).Text = "BLOS (SATCOM) - GEO/HEO";
		((ButtonBase)CB_BLOS_Cell_G5).AutoSize = true;
		((CheckBox)CB_BLOS_Cell_G5).Checked = true;
		((CheckBox)CB_BLOS_Cell_G5).CheckState = (CheckState)1;
		((Control)CB_BLOS_Cell_G5).Enabled = false;
		((Control)CB_BLOS_Cell_G5).Location = new Point(8, 209);
		((Control)CB_BLOS_Cell_G5).Name = "CB_BLOS_Cell_G5";
		((Control)CB_BLOS_Cell_G5).Size = new Size(130, 19);
		((Control)CB_BLOS_Cell_G5).TabIndex = 6;
		((ButtonBase)CB_BLOS_Cell_G5).Text = "BLOS (Cellular - 5G)";
		((ButtonBase)DarkCheckBox2).AutoSize = true;
		((CheckBox)DarkCheckBox2).Checked = true;
		((CheckBox)DarkCheckBox2).CheckState = (CheckState)1;
		((Control)DarkCheckBox2).Enabled = false;
		((Control)DarkCheckBox2).Location = new Point(8, 234);
		((Control)DarkCheckBox2).Name = "DarkCheckBox2";
		((Control)DarkCheckBox2).Size = new Size(130, 19);
		((Control)DarkCheckBox2).TabIndex = 7;
		((ButtonBase)DarkCheckBox2).Text = "BLOS (Cellular - 4G)";
		((ButtonBase)CB_BeiDou).AutoSize = true;
		((Control)CB_BeiDou).Location = new Point(8, 84);
		((Control)CB_BeiDou).Name = "CB_BeiDou";
		((Control)CB_BeiDou).Size = new Size(123, 19);
		((Control)CB_BeiDou).TabIndex = 8;
		((ButtonBase)CB_BeiDou).Text = "BeiDou/COMPASS";
		((ButtonBase)CB_NavIC).AutoSize = true;
		((Control)CB_NavIC).Location = new Point(8, 109);
		((Control)CB_NavIC).Name = "CB_NavIC";
		((Control)CB_NavIC).Size = new Size(94, 19);
		((Control)CB_NavIC).TabIndex = 9;
		((ButtonBase)CB_NavIC).Text = "NavIC/IRNSS";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(7f, 15f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(290, 296);
		((Control)this).Controls.Add((Control)(object)CB_NavIC);
		((Control)this).Controls.Add((Control)(object)CB_BeiDou);
		((Control)this).Controls.Add((Control)(object)DarkCheckBox2);
		((Control)this).Controls.Add((Control)(object)CB_BLOS_Cell_G5);
		((Control)this).Controls.Add((Control)(object)CB_BLOS_GEOHEO);
		((Control)this).Controls.Add((Control)(object)CB_BLOS_MEO);
		((Control)this).Controls.Add((Control)(object)CB_BLOS_LEO);
		((Control)this).Controls.Add((Control)(object)CB_GLONASS);
		((Control)this).Controls.Add((Control)(object)CB_GPS);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).Location = new Point(0, 0);
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "EnablersForm";
		((Form)this).ShowIcon = false;
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Side Enablers";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EnablersForm_Shown(object sender, EventArgs e)
	{
		if (SelectedZone != null)
		{
			((Form)this).Text = "Zone: " + SelectedZone.Name + " allows the following enablers:";
			((CheckBox)CB_GPS).Checked = SelectedZone.Enablers.GNSS_GPS;
			((ButtonBase)CB_GPS).Text = "GPS (Side: " + Conversions.ToString(SelectedSide.Enablers.GNSS_GPS) + ")";
			((CheckBox)CB_GLONASS).Checked = SelectedZone.Enablers.GNSS_GLONASS;
			((ButtonBase)CB_GLONASS).Text = "GLONASS (Side: " + Conversions.ToString(SelectedSide.Enablers.GNSS_GLONASS) + ")";
			((CheckBox)CB_BeiDou).Checked = SelectedZone.Enablers.GNSS_BeiDou;
			((ButtonBase)CB_BeiDou).Text = "BeiDou (Side: " + Conversions.ToString(SelectedSide.Enablers.GNSS_BeiDou) + ")";
			((CheckBox)CB_NavIC).Checked = SelectedZone.Enablers.GNSS_NavIC;
			((ButtonBase)CB_NavIC).Text = "NavIC (Side: " + Conversions.ToString(SelectedSide.Enablers.GNSS_NavIC) + ")";
		}
		else
		{
			((Form)this).Text = "Side: " + SelectedSide.Name + " has access to following enablers:";
			((CheckBox)CB_GPS).Checked = SelectedSide.Enablers.GNSS_GPS;
			((ButtonBase)CB_GPS).Text = "GPS";
			((CheckBox)CB_GLONASS).Checked = SelectedSide.Enablers.GNSS_GLONASS;
			((ButtonBase)CB_GLONASS).Text = "GLONASS";
			((CheckBox)CB_BeiDou).Checked = SelectedSide.Enablers.GNSS_BeiDou;
			((ButtonBase)CB_BeiDou).Text = "BeiDou";
			((CheckBox)CB_NavIC).Checked = SelectedSide.Enablers.GNSS_NavIC;
			((ButtonBase)CB_NavIC).Text = "NavIC";
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		if (SelectedZone != null)
		{
			SelectedZone.Enablers.GNSS_GPS = ((CheckBox)CB_GPS).Checked;
		}
		else
		{
			SelectedSide.Enablers.GNSS_GPS = ((CheckBox)CB_GPS).Checked;
		}
	}

	private void method_3(object sender, EventArgs e)
	{
		if (SelectedZone != null)
		{
			SelectedZone.Enablers.GNSS_GLONASS = ((CheckBox)CB_GLONASS).Checked;
		}
		else
		{
			SelectedSide.Enablers.GNSS_GLONASS = ((CheckBox)CB_GLONASS).Checked;
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (SelectedZone == null)
		{
			SelectedSide.Enablers.GNSS_BeiDou = ((CheckBox)CB_BeiDou).Checked;
		}
		else
		{
			SelectedZone.Enablers.GNSS_BeiDou = ((CheckBox)CB_BeiDou).Checked;
		}
	}

	private void method_5(object sender, EventArgs e)
	{
		if (SelectedZone != null)
		{
			SelectedZone.Enablers.GNSS_NavIC = ((CheckBox)CB_NavIC).Checked;
		}
		else
		{
			SelectedSide.Enablers.GNSS_NavIC = ((CheckBox)CB_NavIC).Checked;
		}
	}

	private void EnablersForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		SelectedSide = null;
		SelectedZone = null;
	}

	static EnablersForm()
	{
		Class72.smethod_20();
	}
}
