using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DeltaCopyOverElement : UserControl
{
	private IContainer icontainer_0;

	[field: AccessedThroughProperty("TB_Name")]
	internal virtual TextBox TB_Name { get; set; }

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1 { get; set; }

	[field: AccessedThroughProperty("TB_SourceValue")]
	internal virtual TextBox TB_SourceValue { get; set; }

	[field: AccessedThroughProperty("TB_TargetValue")]
	internal virtual TextBox TB_TargetValue { get; set; }

	[field: AccessedThroughProperty("CB")]
	internal virtual CheckBox CB { get; set; }

	public DeltaCopyOverElement()
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
			((ContainerControl)this).Dispose(disposing);
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
		TB_Name = new TextBox();
		Label1 = new Label();
		TB_SourceValue = new TextBox();
		TB_TargetValue = new TextBox();
		CB = new CheckBox();
		((Control)this).SuspendLayout();
		((Control)TB_Name).Location = new Point(22, 2);
		((Control)TB_Name).Name = "TB_Name";
		((TextBoxBase)TB_Name).ReadOnly = true;
		((Control)TB_Name).Size = new Size(142, 20);
		((Control)TB_Name).TabIndex = 24;
		TB_Name.Text = "RangeMax";
		TB_Name.TextAlign = (HorizontalAlignment)2;
		Label1.AutoSize = true;
		((Control)Label1).Location = new Point(456, 5);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(52, 13);
		((Control)Label1).TabIndex = 23;
		Label1.Text = "------------->";
		((Control)TB_SourceValue).Location = new Point(170, 1);
		((Control)TB_SourceValue).Name = "TB_SourceValue";
		((TextBoxBase)TB_SourceValue).ReadOnly = true;
		((Control)TB_SourceValue).Size = new Size(275, 20);
		((Control)TB_SourceValue).TabIndex = 22;
		TB_SourceValue.Text = "50";
		TB_SourceValue.TextAlign = (HorizontalAlignment)2;
		((Control)TB_TargetValue).Location = new Point(516, 1);
		((Control)TB_TargetValue).Name = "TB_TargetValue";
		((Control)TB_TargetValue).Size = new Size(275, 20);
		((Control)TB_TargetValue).TabIndex = 21;
		TB_TargetValue.Text = "75";
		TB_TargetValue.TextAlign = (HorizontalAlignment)2;
		((ButtonBase)CB).AutoSize = true;
		((Control)CB).Location = new Point(5, 5);
		((Control)CB).Name = "CB";
		((Control)CB).Size = new Size(15, 14);
		((Control)CB).TabIndex = 20;
		((ButtonBase)CB).UseVisualStyleBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)TB_Name);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)TB_SourceValue);
		((Control)this).Controls.Add((Control)(object)TB_TargetValue);
		((Control)this).Controls.Add((Control)(object)CB);
		((Control)this).Name = "DeltaCopyOverElement";
		((Control)this).Size = new Size(794, 23);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static DeltaCopyOverElement()
	{
		Class72.smethod_20();
	}
}
