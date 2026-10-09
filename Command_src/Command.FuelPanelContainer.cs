using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Command_Core;
using DarkUI.Controls;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FuelPanelContainer : DarkUserControl
{
	private IContainer icontainer_1;

	private int ActualWidth;

	public FuelPanelContainer()
	{
		((UserControl)this).Load += FuelPanelContainer_Load;
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
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).SuspendLayout();
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Control)this).BackColor = SystemColors.Control;
		((Control)this).DoubleBuffered = true;
		((Control)this).ForeColor = SystemColors.ButtonShadow;
		((Control)this).Margin = new Padding(0);
		((Control)this).Name = "FuelPanelContainer";
		((Control)this).Size = new Size(232, 20);
		((Control)this).ResumeLayout(false);
	}

	public void RefreshPanel(ActiveUnit theUnit)
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
		((Control)this).Enabled = !Information.IsNothing((object)theUnit);
		if (Information.IsNothing((object)theUnit))
		{
			return;
		}
		CheckForCorrectPanelType(theUnit);
		if (((ArrangedElementCollection)((Control)this).Controls).Count > 0)
		{
			switch (theUnit.UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				((FuelPanel_Aircraft)(object)((Control)this).Controls[0]).RefreshPanel(theUnit);
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				((FuelPanel_Ship)(object)((Control)this).Controls[0]).RefreshPanel(theUnit);
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				((FuelPanel_Submarine)(object)((Control)this).Controls[0]).RefreshPanel(theUnit);
				break;
			}
		}
	}

	public void CheckForCorrectPanelType(ActiveUnit theUnit)
	{
		if (((ArrangedElementCollection)((Control)this).Controls).Count == 0)
		{
			return;
		}
		switch (theUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			if ((object)((object)((Control)this).Controls[0]).GetType() != typeof(FuelPanel_Aircraft))
			{
				((Control)this).Controls.Clear();
				FuelPanel_Aircraft fuelPanel_Aircraft = new FuelPanel_Aircraft();
				((Control)this).Controls.Add((Control)(object)fuelPanel_Aircraft);
				((Control)fuelPanel_Aircraft).Enabled = true;
			}
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			if ((object)((object)((Control)this).Controls[0]).GetType() != typeof(FuelPanel_Ship))
			{
				((Control)this).Controls.Clear();
				FuelPanel_Ship fuelPanel_Ship = new FuelPanel_Ship();
				((Control)this).Controls.Add((Control)(object)fuelPanel_Ship);
				((Control)fuelPanel_Ship).Enabled = true;
			}
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			if ((object)((object)((Control)this).Controls[0]).GetType() != typeof(FuelPanel_Submarine))
			{
				((Control)this).Controls.Clear();
				FuelPanel_Submarine fuelPanel_Submarine = new FuelPanel_Submarine();
				((Control)this).Controls.Add((Control)(object)fuelPanel_Submarine);
				((Control)fuelPanel_Submarine).Enabled = true;
			}
			break;
		}
	}

	public void AdjustToSelectionChange(Module_Unit.Unit theUnit, ref bool previousUnitHasFuel)
	{
		((Control)this).Controls.Clear();
		if (!theUnit.IsActiveUnit)
		{
			((Control)this).Visible = false;
			((Control)this).Height = 0;
			previousUnitHasFuel = false;
		}
		else
		{
			((Control)this).Visible = true;
			if (theUnit.IsAircraft)
			{
				FuelPanel_Aircraft fuelPanel_Aircraft = new FuelPanel_Aircraft();
				((Control)this).Controls.Add((Control)(object)fuelPanel_Aircraft);
				((Control)fuelPanel_Aircraft).Enabled = true;
				previousUnitHasFuel = true;
			}
			else if (theUnit.IsShip && !((Ship)theUnit).IsNuke)
			{
				FuelPanel_Ship fuelPanel_Ship = new FuelPanel_Ship();
				((Control)this).Controls.Add((Control)(object)fuelPanel_Ship);
				((Control)fuelPanel_Ship).Enabled = true;
				previousUnitHasFuel = true;
			}
			else if (theUnit.IsSubmarine && (!((Submarine)theUnit).IsNuke || ((Submarine)theUnit).Fuel_ReadOnly.Count != 0))
			{
				FuelPanel_Submarine fuelPanel_Submarine = new FuelPanel_Submarine();
				((Control)this).Controls.Add((Control)(object)fuelPanel_Submarine);
				((Control)fuelPanel_Submarine).Enabled = true;
				previousUnitHasFuel = true;
			}
			else
			{
				((Control)this).Visible = false;
				((Control)this).Height = 0;
				previousUnitHasFuel = false;
			}
		}
		if (((ArrangedElementCollection)((Control)this).Controls).Count > 0)
		{
			((Control)this).Height = ((Control)this).Controls[0].Height;
		}
	}

	private void FuelPanelContainer_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
	}

	static FuelPanelContainer()
	{
		Class72.smethod_20();
	}
}
