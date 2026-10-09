using System.Drawing;
using System.Windows.Forms;
using DarkUI.Renderers;

namespace DarkUI.Controls;

public sealed class DarkToolStrip : ToolStrip
{
	public DarkToolStrip()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		((ToolStrip)this).Renderer = (ToolStripRenderer)(object)new DarkToolStripRenderer();
		((Control)this).Padding = new Padding(5, 0, 1, 0);
		((Control)this).AutoSize = false;
		((Control)this).Size = new Size(1, 28);
	}

	static DarkToolStrip()
	{
		Class72.smethod_20();
	}
}
