using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command.My;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorWaypointDetails : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[field: AccessedThroughProperty("TabControl_FlightPlanEditor_WaypointDetails")]
	internal virtual DarkUITabControl TabControl_FlightPlanEditor_WaypointDetails { get; set; }

	[field: AccessedThroughProperty("TabPage1")]
	internal virtual TabPage TabPage1 { get; set; }

	[field: AccessedThroughProperty("TabPage2")]
	internal virtual TabPage TabPage2 { get; set; }

	[field: AccessedThroughProperty("TabPage3")]
	internal virtual TabPage TabPage3 { get; set; }

	public FlightPlanEditorWaypointDetails()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).FormClosed += new FormClosedEventHandler(FlightPlanEditorWaypointDetails_FormClosed);
		((Form)this).FormClosing += new FormClosingEventHandler(FlightPlanEditorWaypointDetails_FormClosing);
		((Control)this).KeyDown += new KeyEventHandler(FlightPlanEditorWaypointDetails_KeyDown);
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
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		TabControl_FlightPlanEditor_WaypointDetails = new DarkUITabControl();
		TabPage1 = new TabPage();
		TabPage2 = new TabPage();
		TabPage3 = new TabPage();
		((Control)TabControl_FlightPlanEditor_WaypointDetails).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Controls.Add((Control)(object)TabPage1);
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Controls.Add((Control)(object)TabPage2);
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Controls.Add((Control)(object)TabPage3);
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Cursor = Cursors.Hand;
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Dock = (DockStyle)5;
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Font = new Font(Client.CommandDefaultFont.FontFamily, 8f);
		((TabControl)TabControl_FlightPlanEditor_WaypointDetails).ItemSize = new Size(80, 20);
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Location = new Point(0, 0);
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Name = "TabControl_FlightPlanEditor_WaypointDetails";
		((TabControl)TabControl_FlightPlanEditor_WaypointDetails).SelectedIndex = 0;
		((Control)TabControl_FlightPlanEditor_WaypointDetails).Size = new Size(832, 387);
		((Control)TabControl_FlightPlanEditor_WaypointDetails).TabIndex = 0;
		TabPage1.BackColor = Color.FromArgb(60, 63, 65);
		TabPage1.Location = new Point(4, 24);
		((Control)TabPage1).Name = "TabPage1";
		((Control)TabPage1).Padding = new Padding(3);
		((Control)TabPage1).Size = new Size(824, 359);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "Target";
		TabPage2.BackColor = Color.FromArgb(60, 63, 65);
		TabPage2.Location = new Point(4, 24);
		((Control)TabPage2).Name = "TabPage2";
		((Control)TabPage2).Padding = new Padding(3);
		((Control)TabPage2).Size = new Size(824, 359);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "Weapon Release";
		TabPage3.BackColor = Color.FromArgb(60, 63, 65);
		TabPage3.Location = new Point(4, 24);
		((Control)TabPage3).Name = "TabPage3";
		((Control)TabPage3).Padding = new Padding(3);
		((Control)TabPage3).Size = new Size(824, 359);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "Patrol";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(832, 387);
		((Control)this).Controls.Add((Control)(object)TabControl_FlightPlanEditor_WaypointDetails);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "FlightPlanEditorWaypointDetails";
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "FlightPlanEditorWaypointDetails";
		((Control)TabControl_FlightPlanEditor_WaypointDetails).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void FlightPlanEditorWaypointDetails_FormClosed(object sender, FormClosedEventArgs e)
	{
	}

	private void FlightPlanEditorWaypointDetails_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)this).Hide();
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void FlightPlanEditorWaypointDetails_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else if ((int)e.KeyCode == 112 || (int)e.KeyCode == 113 || (int)e.KeyCode == 114 || (int)e.KeyCode == 115 || (int)e.KeyCode == 116 || (int)e.KeyCode == 117 || (int)e.KeyCode == 118 || (int)e.KeyCode == 119 || (int)e.KeyCode == 120 || (int)e.KeyCode == 121 || (int)e.KeyCode == 122 || (int)e.KeyCode == 123)
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	static FlightPlanEditorWaypointDetails()
	{
		Class72.smethod_20();
	}
}
