using System.Windows.Forms;
using DarkUI.Renderers;

namespace DarkUI.Controls;

public sealed class DarkContextMenu : ContextMenuStrip
{
	public DarkContextMenu()
	{
		((ToolStrip)this).Renderer = (ToolStripRenderer)(object)new DarkMenuRenderer();
	}

	static DarkContextMenu()
	{
		Class72.smethod_20();
	}
}
