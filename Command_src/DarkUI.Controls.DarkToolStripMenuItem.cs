using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkToolStripMenuItem : ToolStripMenuItem
{
	public DarkToolStripMenuItem()
	{
		((ToolStripItem)this).BackColor = Colors.GreyBackground;
		((ToolStripItem)this).ForeColor = Colors.LightText;
	}

	public DarkToolStripMenuItem(Color theForeColor)
	{
		((ToolStripItem)this).BackColor = Colors.GreyBackground;
		((ToolStripItem)this).ForeColor = theForeColor;
	}

	static DarkToolStripMenuItem()
	{
		Class72.smethod_20();
	}
}
