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
public class DebugTool : CommandFormParent
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB_DetailedSensorReport")]
	private DarkCheckBox _CB_DetailedSensorReport;

	internal virtual DarkCheckBox CB_DetailedSensorReport
	{
		[CompilerGenerated]
		get
		{
			return _CB_DetailedSensorReport;
		}
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = method_0;
			DarkCheckBox darkCheckBox = _CB_DetailedSensorReport;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged -= eventHandler;
			}
			_CB_DetailedSensorReport = value;
			darkCheckBox = _CB_DetailedSensorReport;
			if (darkCheckBox != null)
			{
				((CheckBox)darkCheckBox).CheckedChanged += eventHandler;
			}
		}
	}

	[field: AccessedThroughProperty("TB_DetailedSensorReport")]
	internal virtual RichTextBox TB_DetailedSensorReport { get; set; }

	public DebugTool()
	{
		((Form)this).Load += DebugTool_Load;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DebugTool));
		TB_DetailedSensorReport = new RichTextBox();
		CB_DetailedSensorReport = new DarkCheckBox();
		((Control)this).SuspendLayout();
		((TextBoxBase)TB_DetailedSensorReport).BackColor = SystemColors.ControlDarkDark;
		TB_DetailedSensorReport.ForeColor = SystemColors.Info;
		((Control)TB_DetailedSensorReport).Location = new Point(12, 35);
		((Control)TB_DetailedSensorReport).Name = "TB_DetailedSensorReport";
		((TextBoxBase)TB_DetailedSensorReport).ReadOnly = true;
		((Control)TB_DetailedSensorReport).Size = new Size(328, 102);
		((Control)TB_DetailedSensorReport).TabIndex = 1;
		TB_DetailedSensorReport.Text = componentResourceManager.GetString("TB_DetailedSensorReport.Text");
		((ButtonBase)CB_DetailedSensorReport).AutoSize = true;
		((Control)CB_DetailedSensorReport).Location = new Point(12, 12);
		((Control)CB_DetailedSensorReport).Name = "CB_DetailedSensorReport";
		((Control)CB_DetailedSensorReport).Size = new Size(129, 17);
		((Control)CB_DetailedSensorReport).TabIndex = 0;
		((ButtonBase)CB_DetailedSensorReport).Text = "Detailed sensor report";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(60, 63, 65);
		((Form)this).ClientSize = new Size(352, 149);
		((Control)this).Controls.Add((Control)(object)TB_DetailedSensorReport);
		((Control)this).Controls.Add((Control)(object)CB_DetailedSensorReport);
		((Control)this).Name = "DebugTool";
		((Form)this).Text = "DebugTool";
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void method_0(object sender, EventArgs e)
	{
		GameGeneral.ReportCompleteSensorDetectionAttempt = ((CheckBox)CB_DetailedSensorReport).Checked;
	}

	private void DebugTool_Load(object sender, EventArgs e)
	{
		((Control)CB_DetailedSensorReport).Visible = false;
		((Control)TB_DetailedSensorReport).Visible = false;
	}

	static DebugTool()
	{
		Class72.smethod_20();
	}
}
