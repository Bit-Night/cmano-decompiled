using System.Windows.Forms;
using DarkUI.Renderers;

namespace DarkUI.Controls;

public sealed class DarkMenuStrip : MenuStrip
{
	public DarkMenuStrip()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		((ToolStrip)this).Renderer = (ToolStripRenderer)(object)new DarkMenuRenderer();
		((Control)this).Padding = new Padding(3, 2, 0, 2);
	}

	static DarkMenuStrip()
	{
		Class72.smethod_20();
	}
}
