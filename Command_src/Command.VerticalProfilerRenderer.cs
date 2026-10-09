using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Command_Core;
using DarkUI.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class VerticalProfilerRenderer : Form
{
	private IContainer icontainer_0;

	public SensorTerrainRendererControl Renderer;

	[field: AccessedThroughProperty("ElementHost1")]
	internal virtual ElementHost ElementHost1 { get; set; }

	[field: AccessedThroughProperty("Label_TopAltitude")]
	internal virtual Label Label_TopAltitude { get; set; }

	[field: AccessedThroughProperty("Label_BottomAltitude")]
	internal virtual Label Label_BottomAltitude { get; set; }

	[field: AccessedThroughProperty("PictureSubjectA")]
	internal virtual PictureBox PictureSubjectA { get; set; }

	[field: AccessedThroughProperty("PictureBox1")]
	internal virtual PictureBox PictureBox1 { get; set; }

	public VerticalProfilerRenderer()
	{
		((Form)this).Load += VerticalProfilerRenderer_Load;
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	private void InitializeComponent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		ElementHost1 = new ElementHost();
		Label_TopAltitude = new Label();
		Label_BottomAltitude = new Label();
		PictureSubjectA = new PictureBox();
		PictureBox1 = new PictureBox();
		((ISupportInitialize)PictureSubjectA).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
		((Control)this).SuspendLayout();
		((Control)ElementHost1).Location = new Point(80, 24);
		((Control)ElementHost1).Name = "ElementHost1";
		((Control)ElementHost1).Size = new Size(1350, 800);
		((Control)ElementHost1).TabIndex = 0;
		((Control)ElementHost1).Text = "ElementHost1";
		ElementHost1.Child = null;
		Label_TopAltitude.AutoSize = true;
		((Control)Label_TopAltitude).Location = new Point(77, 9);
		((Control)Label_TopAltitude).Name = "Label_TopAltitude";
		((Control)Label_TopAltitude).Size = new Size(51, 13);
		((Control)Label_TopAltitude).TabIndex = 1;
		Label_TopAltitude.Text = "100000m";
		Label_BottomAltitude.AutoSize = true;
		((Control)Label_BottomAltitude).Location = new Point(77, 827);
		((Control)Label_BottomAltitude).Name = "Label_BottomAltitude";
		((Control)Label_BottomAltitude).Size = new Size(51, 13);
		((Control)Label_BottomAltitude).TabIndex = 2;
		Label_BottomAltitude.Text = "100000m";
		((Control)PictureSubjectA).BackgroundImageLayout = (ImageLayout)3;
		((Control)PictureSubjectA).Location = new Point(22, 24);
		((Control)PictureSubjectA).Name = "PictureSubjectA";
		((Control)PictureSubjectA).Size = new Size(32, 32);
		PictureSubjectA.SizeMode = (PictureBoxSizeMode)1;
		PictureSubjectA.TabIndex = 3;
		PictureSubjectA.TabStop = false;
		((Control)PictureBox1).BackgroundImageLayout = (ImageLayout)3;
		((Control)PictureBox1).Location = new Point(1455, 24);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(32, 32);
		PictureBox1.SizeMode = (PictureBoxSizeMode)1;
		PictureBox1.TabIndex = 4;
		PictureBox1.TabStop = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1508, 845);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)PictureSubjectA);
		((Control)this).Controls.Add((Control)(object)Label_BottomAltitude);
		((Control)this).Controls.Add((Control)(object)Label_TopAltitude);
		((Control)this).Controls.Add((Control)(object)ElementHost1);
		((Control)this).Name = "SensorTerrainRenderer";
		((Form)this).Text = "Vertical Profiler";
		((ISupportInitialize)PictureSubjectA).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public bool IsReadyToRender()
	{
		if (!Information.IsNothing((object)Renderer))
		{
			return Renderer.IsReadyToRender();
		}
		return false;
	}

	private void VerticalProfilerRenderer_Load(object sender, EventArgs e)
	{
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		Renderer = new SensorTerrainRendererControl();
		int count = Client.CurrentSide.SelectedUnits.Count;
		if (count <= 2)
		{
			if (count >= 2)
			{
				List<SensorTerrainRendererControl.Subject> list = new List<SensorTerrainRendererControl.Subject>();
				foreach (Module_Unit.Unit selectedUnit in Client.CurrentSide.SelectedUnits)
				{
					list.Add(new SensorTerrainRendererControl.Subject(selectedUnit));
				}
				ElementHost1.Child = (UIElement)(object)Renderer;
				Renderer.Refresh(list.ElementAt(0), list.ElementAt(1), this);
			}
			else
			{
				DarkMessageBox.ShowWarning("You have selected " + count + " subject, please select 2 subjects (reference point or units) ", "Not enough subjects", DarkDialogButton.Close);
			}
		}
		else
		{
			DarkMessageBox.ShowWarning("You have selected " + count + " subject, please select only 2 subjects (reference point or units) ", "Too many subjects", DarkDialogButton.Close);
		}
	}

	static VerticalProfilerRenderer()
	{
		Class72.smethod_20();
	}
}
