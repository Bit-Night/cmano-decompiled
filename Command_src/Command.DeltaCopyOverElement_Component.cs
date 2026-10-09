using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
public class DeltaCopyOverElement_Component : UserControl
{
	private IContainer icontainer_0;

	[CompilerGenerated]
	[AccessedThroughProperty("CB")]
	private CheckBox foFvVelTmd;

	[field: AccessedThroughProperty("TB_Table")]
	internal virtual TextBox TB_Table { get; set; }

	[field: AccessedThroughProperty("TB_Method")]
	internal virtual TextBox TB_Method { get; set; }

	internal virtual CheckBox CB
	{
		[CompilerGenerated]
		get
		{
			return foFvVelTmd;
		}
		[CompilerGenerated]
		set
		{
			foFvVelTmd = value;
		}
	}

	[field: AccessedThroughProperty("TB_ActualName")]
	internal virtual TextBox TB_ActualName { get; set; }

	public DeltaCopyOverElement_Component()
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
		TB_Table = new TextBox();
		TB_Method = new TextBox();
		CB = new CheckBox();
		TB_ActualName = new TextBox();
		((Control)this).SuspendLayout();
		((Control)TB_Table).Location = new Point(20, 3);
		((Control)TB_Table).Name = "TB_Table";
		((TextBoxBase)TB_Table).ReadOnly = true;
		((Control)TB_Table).Size = new Size(182, 20);
		((Control)TB_Table).TabIndex = 29;
		TB_Table.Text = "Table";
		TB_Table.TextAlign = (HorizontalAlignment)2;
		((Control)TB_Method).Location = new Point(415, 3);
		((Control)TB_Method).Name = "TB_Method";
		((TextBoxBase)TB_Method).ReadOnly = true;
		((Control)TB_Method).Size = new Size(113, 20);
		((Control)TB_Method).TabIndex = 26;
		TB_Method.Text = "Method";
		TB_Method.TextAlign = (HorizontalAlignment)2;
		((ButtonBase)CB).AutoSize = true;
		((Control)CB).Location = new Point(3, 6);
		((Control)CB).Name = "CB";
		((Control)CB).Size = new Size(15, 14);
		((Control)CB).TabIndex = 25;
		((ButtonBase)CB).UseVisualStyleBackColor = true;
		((Control)TB_ActualName).Location = new Point(208, 3);
		((Control)TB_ActualName).Name = "TB_ActualName";
		((TextBoxBase)TB_ActualName).ReadOnly = true;
		((Control)TB_ActualName).Size = new Size(201, 20);
		((Control)TB_ActualName).TabIndex = 30;
		TB_ActualName.Text = "Component actual name / ID";
		TB_ActualName.TextAlign = (HorizontalAlignment)2;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).Controls.Add((Control)(object)TB_ActualName);
		((Control)this).Controls.Add((Control)(object)TB_Table);
		((Control)this).Controls.Add((Control)(object)TB_Method);
		((Control)this).Controls.Add((Control)(object)CB);
		((Control)this).Name = "DeltaCopyOverElement_Component";
		((Control)this).Size = new Size(532, 26);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	static DeltaCopyOverElement_Component()
	{
		Class72.smethod_20();
	}
}
