using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public sealed class FlightPlanEditorTargetsArea : CommandSecondaryFormBase
{
	private IContainer icontainer_0;

	[field: AccessedThroughProperty("AreaEditor_PatrolArea")]
	internal virtual AreaEditor AreaEditor_PatrolArea { get; set; }

	public FlightPlanEditorTargetsArea()
	{
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
		AreaEditor_PatrolArea = new AreaEditor();
		((Control)this).SuspendLayout();
		((Control)AreaEditor_PatrolArea).Location = new Point(28, 40);
		((Control)AreaEditor_PatrolArea).Name = "AreaEditor_PatrolArea";
		((Control)AreaEditor_PatrolArea).Size = new Size(351, 124);
		((Control)AreaEditor_PatrolArea).TabIndex = 4;
		AreaEditor_PatrolArea.Title = null;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(832, 442);
		((Control)this).Controls.Add((Control)(object)AreaEditor_PatrolArea);
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "FlightPlanEditorTargetsArea";
		((Form)this).ShowIcon = false;
		((Form)this).Text = "FlightPlanEditorTargetsArea";
		((Control)this).ResumeLayout(false);
	}

	static FlightPlanEditorTargetsArea()
	{
		Class72.smethod_20();
	}
}
