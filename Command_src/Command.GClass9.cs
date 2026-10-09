using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Controls;

namespace Command;

public sealed class GClass9 : DarkNumericUpDown
{
	[Category("Custom")]
	[Description("Gets or sets a value indicating whether the control can Rounded in corners.")]
	public override Color BackColor
	{
		get
		{
			return ((UpDownBase)this).BackColor;
		}
		set
		{
			if (value.A == byte.MaxValue)
			{
				((UpDownBase)this).BackColor = value;
			}
		}
	}

	public GClass9()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((Control)this).Font = new Font("Segoe UI", 12f);
	}

	static GClass9()
	{
		Class72.smethod_20();
	}
}
