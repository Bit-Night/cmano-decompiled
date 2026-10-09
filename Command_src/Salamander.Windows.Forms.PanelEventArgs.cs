using System;

namespace Salamander.Windows.Forms;

public sealed class PanelEventArgs : EventArgs
{
	private CollapsiblePanel collapsiblePanel_0;

	public CollapsiblePanel CollapsiblePanel => collapsiblePanel_0;

	public PanelState PanelState => collapsiblePanel_0.PanelState;

	public PanelEventArgs(CollapsiblePanel sender)
	{
		collapsiblePanel_0 = sender;
	}

	static PanelEventArgs()
	{
		Class72.smethod_20();
	}
}
