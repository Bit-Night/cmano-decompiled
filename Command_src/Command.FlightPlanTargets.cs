using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanTargets : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[field: AccessedThroughProperty("TabControl1")]
	internal virtual TabControl TabControl1 { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	[field: AccessedThroughProperty("RadioButton_MissionTargets")]
	internal virtual DarkRadioButton RadioButton_MissionTargets { get; set; }

	[field: AccessedThroughProperty("RadioButton_FlightTargets")]
	internal virtual DarkRadioButton RadioButton_FlightTargets { get; set; }

	[field: AccessedThroughProperty("RadioButton_AircraftTargets")]
	internal virtual DarkRadioButton RadioButton_AircraftTargets { get; set; }

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2 { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3 { get; set; }

	public FlightPlanTargets()
	{
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
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		TabControl1 = (TabControl)(object)new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		RadioButton_MissionTargets = new DarkRadioButton();
		RadioButton_FlightTargets = new DarkRadioButton();
		RadioButton_AircraftTargets = new DarkRadioButton();
		Label1 = (Label)(object)new DarkLabel();
		Label2 = (Label)(object)new DarkLabel();
		Label3 = (Label)(object)new DarkLabel();
		((Control)TabControl1).SuspendLayout();
		((Control)TabPage1).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TabControl1).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl1).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl1).Location = new Point(75, 78);
		((Control)TabControl1).Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		((Control)TabControl1).Size = new Size(765, 256);
		((Control)TabControl1).TabIndex = 0;
		((Control)TabPage1).Controls.Add((Control)(object)Label2);
		((Control)TabPage1).Controls.Add((Control)(object)Label1);
		TabPage1.Location = new Point(4, 22);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(757, 230);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Use mission targets";
		TabPage1.UseVisualStyleBackColor = true;
		TabPage2.Location = new Point(4, 22);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(757, 230);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Flight targets";
		TabPage2.UseVisualStyleBackColor = true;
		TabPage3.Location = new Point(4, 22);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(757, 230);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Aircraft targets";
		TabPage3.UseVisualStyleBackColor = true;
		((ButtonBase)RadioButton_MissionTargets).AutoSize = true;
		((Control)RadioButton_MissionTargets).Location = new Point(12, 12);
		((Control)RadioButton_MissionTargets).Name = "RadioButton_MissionTargets";
		((Control)RadioButton_MissionTargets).Size = new Size(148, 17);
		((Control)RadioButton_MissionTargets).TabIndex = 1;
		((RadioButton)RadioButton_MissionTargets).TabStop = true;
		((ButtonBase)RadioButton_MissionTargets).Text = "Mission / package targets";
		((ButtonBase)RadioButton_FlightTargets).AutoSize = true;
		((Control)RadioButton_FlightTargets).Location = new Point(12, 35);
		((Control)RadioButton_FlightTargets).Name = "RadioButton_FlightTargets";
		((Control)RadioButton_FlightTargets).Size = new Size(85, 17);
		((Control)RadioButton_FlightTargets).TabIndex = 2;
		((RadioButton)RadioButton_FlightTargets).TabStop = true;
		((ButtonBase)RadioButton_FlightTargets).Text = "Flight targets";
		((ButtonBase)RadioButton_AircraftTargets).AutoSize = true;
		((Control)RadioButton_AircraftTargets).Location = new Point(12, 55);
		((Control)RadioButton_AircraftTargets).Name = "RadioButton_AircraftTargets";
		((Control)RadioButton_AircraftTargets).Size = new Size(111, 17);
		((Control)RadioButton_AircraftTargets).TabIndex = 2;
		((RadioButton)RadioButton_AircraftTargets).TabStop = true;
		((ButtonBase)RadioButton_AircraftTargets).Text = "Per-aircraft targets";
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(13, 20);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(377, 13);
		((Control)Label1).TabIndex = 0;
		Label1.Text = "The flight will attack targets given in the Target List of the mission or package. ";
		Label2.AutoSize = true;
		((Control)Label2).Location = new Point(13, 49);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(566, 13);
		((Control)Label2).TabIndex = 0;
		Label2.Text = "Weapon allocation will be per Weapon Release Authorization (WRA) setting for each weapon/target type combination.";
		Label3.AutoSize = true;
		((Control)Label3).Location = new Point(228, 27);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(244, 13);
		((Control)Label3).TabIndex = 3;
		Label3.Text = "Options: Drop ordnance, bring back home, jettison";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(1008, 691);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)RadioButton_AircraftTargets);
		((Control)this).Controls.Add((Control)(object)RadioButton_FlightTargets);
		((Control)this).Controls.Add((Control)(object)RadioButton_MissionTargets);
		((Control)this).Controls.Add((Control)(object)TabControl1);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(1024, 730);
		((Control)this).Name = "FlightPlanTargets";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Select targets for flight <Flight> or its individual aircraft";
		((Control)TabControl1).ResumeLayout(false);
		((Control)TabPage1).ResumeLayout(false);
		((Control)TabPage1).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static FlightPlanTargets()
	{
		Class72.smethod_20();
	}
}
