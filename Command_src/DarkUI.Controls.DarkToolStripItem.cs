using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkToolStripItem : ToolStripItem
{
	public DarkToolStripItem()
	{
		((ToolStripItem)this).BackColor = Colors.GreyBackground;
		((ToolStripItem)this).ForeColor = Colors.LightText;
	}

	static DarkToolStripItem()
	{
		Class72.smethod_20();
	}
}
