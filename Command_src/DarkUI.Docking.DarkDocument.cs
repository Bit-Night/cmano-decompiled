using System.ComponentModel;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Docking;

[ToolboxItem(false)]
public sealed class DarkDocument : DarkDockContent
{
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DarkDockArea DefaultDockArea => base.DefaultDockArea;

	public DarkDocument()
	{
		((Control)this).BackColor = Colors.GreyBackground;
		base.DefaultDockArea = DarkDockArea.Document;
	}

	static DarkDocument()
	{
		Class72.smethod_20();
	}
}
