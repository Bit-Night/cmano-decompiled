using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Command_Core;
using Command.My;
using DarkUI.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FixedFacilityOrientation : DarkSecondaryFormBase
{
	private IContainer icontainer_1;

	[CompilerGenerated]
	[AccessedThroughProperty("TrackBar1")]
	private TrackBar _TrackBar1;

	[AccessedThroughProperty("TrackBarPierSize")]
	[CompilerGenerated]
	private TrackBar _TrackBarPierSize;

	public ActiveUnit SelectedUnit;

	internal virtual TrackBar TrackBar1
	{
		[CompilerGenerated]
		get
		{
			return _TrackBar1;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_2;
			TrackBar val = _TrackBar1;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_TrackBar1 = value;
			val = _TrackBar1;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual DarkLabel Label1 { get; set; }

	internal virtual TrackBar TrackBarPierSize
	{
		[CompilerGenerated]
		get
		{
			return _TrackBarPierSize;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_3;
			TrackBar val = _TrackBarPierSize;
			if (val != null)
			{
				val.ValueChanged -= eventHandler;
			}
			_TrackBarPierSize = value;
			val = _TrackBarPierSize;
			if (val != null)
			{
				val.ValueChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("DarkLabel2")]
	internal virtual DarkLabel DarkLabel2 { get; set; }

	[field: AccessedThroughProperty("DarkLabel1")]
	internal virtual DarkLabel DarkLabel1 { get; set; }

	[field: AccessedThroughProperty("PierSizeLabel")]
	internal virtual DarkLabel PierSizeLabel { get; set; }

	public FixedFacilityOrientation()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Form)this).Load += FixedFacilityOrientation_Load;
		((Control)this).KeyDown += new KeyEventHandler(FixedFacilityOrientation_KeyDown);
		((Form)this).FormClosing += new FormClosingEventHandler(FixedFacilityOrientation_FormClosing);
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
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		TrackBar1 = new TrackBar();
		Label1 = new DarkLabel();
		TrackBarPierSize = new TrackBar();
		DarkLabel2 = new DarkLabel();
		DarkLabel1 = new DarkLabel();
		PierSizeLabel = new DarkLabel();
		((ISupportInitialize)TrackBar1).BeginInit();
		((ISupportInitialize)TrackBarPierSize).BeginInit();
		((Control)this).SuspendLayout();
		((Control)TrackBar1).Location = new Point(7, 31);
		TrackBar1.Maximum = 359;
		((Control)TrackBar1).Name = "TrackBar1";
		((Control)TrackBar1).Size = new Size(210, 45);
		((Control)TrackBar1).TabIndex = 0;
		Label1.AutoSize = true;
		((Control)Label1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)Label1).Location = new Point(223, 31);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(50, 15);
		((Control)Label1).TabIndex = 1;
		((Label)Label1).Text = "Current:";
		((Control)TrackBarPierSize).Location = new Point(7, 97);
		TrackBarPierSize.Maximum = 150;
		TrackBarPierSize.Minimum = 1;
		((Control)TrackBarPierSize).Name = "TrackBarPierSize";
		((Control)TrackBarPierSize).Size = new Size(210, 45);
		((Control)TrackBarPierSize).TabIndex = 2;
		TrackBarPierSize.Value = 1;
		DarkLabel2.AutoSize = true;
		((Control)DarkLabel2).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel2).Location = new Point(8, 79);
		((Control)DarkLabel2).Name = "DarkLabel2";
		((Control)DarkLabel2).Size = new Size(206, 15);
		((Control)DarkLabel2).TabIndex = 4;
		((Label)DarkLabel2).Text = "Pier size (Zone unrestricted by terrain)";
		DarkLabel1.AutoSize = true;
		((Control)DarkLabel1).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)DarkLabel1).Location = new Point(8, 13);
		((Control)DarkLabel1).Name = "DarkLabel1";
		((Control)DarkLabel1).Size = new Size(67, 15);
		((Control)DarkLabel1).TabIndex = 5;
		((Label)DarkLabel1).Text = "Orientation";
		PierSizeLabel.AutoSize = true;
		((Control)PierSizeLabel).ForeColor = Color.FromArgb(220, 220, 220);
		((Control)PierSizeLabel).Location = new Point(223, 97);
		((Control)PierSizeLabel).Name = "PierSizeLabel";
		((Control)PierSizeLabel).Size = new Size(50, 15);
		((Control)PierSizeLabel).TabIndex = 6;
		((Label)PierSizeLabel).Text = "Current:";
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		((Form)this).ClientSize = new Size(304, 140);
		((Control)this).Controls.Add((Control)(object)PierSizeLabel);
		((Control)this).Controls.Add((Control)(object)DarkLabel1);
		((Control)this).Controls.Add((Control)(object)DarkLabel2);
		((Control)this).Controls.Add((Control)(object)TrackBarPierSize);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TrackBar1);
		((Form)this).FormBorderStyle = (FormBorderStyle)5;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MaximumSize = new Size(320, 179);
		((Form)this).MinimizeBox = false;
		((Form)this).MinimumSize = new Size(320, 179);
		((Control)this).Name = "FixedFacilityOrientation";
		((Form)this).ShowIcon = false;
		((Form)this).SizeGripStyle = (SizeGripStyle)2;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Set orientation & pier size for unit";
		((ISupportInitialize)TrackBar1).EndInit();
		((ISupportInitialize)TrackBarPierSize).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void FixedFacilityOrientation_Load(object sender, EventArgs e)
	{
		if (Client.DPI_scale == 1f)
		{
			((ContainerControl)this).AutoScaleMode = (AutoScaleMode)0;
		}
		TrackBar1.Value = (int)Math.Round(SelectedUnit.CurrentHeading);
		if (!SelectedUnit.HasDockFacilities)
		{
			((Form)this).Text = "Set orientation for unit";
			((Control)TrackBarPierSize).Visible = false;
			((Control)PierSizeLabel).Visible = false;
		}
		else
		{
			((Form)this).Text = "Set orientation & pier size for unit";
			TrackBarPierSize.Value = (int)Math.Round(SelectedUnit.DockingOps.PierLaneLength * 10f);
			((Control)TrackBarPierSize).Visible = true;
			((Control)PierSizeLabel).Visible = true;
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		SelectedUnit.CurrentHeading = TrackBar1.Value;
		SelectedUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)TrackBar1.Value);
		((Label)Label1).Text = "Current: " + Conversions.ToString(TrackBar1.Value);
		Client.MustRefreshMainForm = true;
	}

	private void FixedFacilityOrientation_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && ((Control)this).Visible)
		{
			((Form)this).Close();
		}
		else
		{
			MyProject.Forms.MainForm.Main_KeyDown(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void FixedFacilityOrientation_FormClosing(object sender, FormClosingEventArgs e)
	{
		((Control)MyProject.Forms.MainForm).BringToFront();
	}

	private void method_3(object sender, EventArgs e)
	{
		SelectedUnit.CurrentHeading = TrackBar1.Value;
		SelectedUnit.set_DesiredHeading(ActiveUnit.TurnRate.Max, (float)TrackBar1.Value);
		SelectedUnit.DockingOps.PierLaneLength = (float)TrackBarPierSize.Value / 10f;
		((Label)PierSizeLabel).Text = SelectedUnit.DockingOps.PierLaneLength + " nm";
		Client.MustRefreshMainForm = true;
	}

	static FixedFacilityOrientation()
	{
		Class72.smethod_20();
	}
}
