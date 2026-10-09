using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Salamander.Windows.Forms;

public sealed class CollapsiblePanelBar : Panel, ISupportInitialize
{
	private CollapsiblePanelCollection collapsiblePanelCollection_0 = new CollapsiblePanelCollection();

	private int border = 8;

	private int int_0 = 8;

	private bool bool_0;

	[Browsable(false)]
	public CollapsiblePanelCollection CollapsiblePanelCollection => collapsiblePanelCollection_0;

	public int Border
	{
		get
		{
			return border;
		}
		set
		{
			border = value;
			method_1(collapsiblePanelCollection_0.Count - 1);
		}
	}

	public int Spacing
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			method_1(collapsiblePanelCollection_0.Count - 1);
		}
	}

	public CollapsiblePanelBar()
	{
		method_0();
		((Control)this).BackColor = Color.CornflowerBlue;
	}

	private void method_0()
	{
	}

	public void BeginInit()
	{
		bool_0 = true;
	}

	public void EndInit()
	{
		bool_0 = false;
	}

	private void method_1(int int_1)
	{
		for (int num = int_1; num >= 0; num--)
		{
			if (num == collapsiblePanelCollection_0.Count - 1)
			{
				((Control)collapsiblePanelCollection_0.Item(num)).Top = border;
			}
			else
			{
				((Control)collapsiblePanelCollection_0.Item(num)).Top = ((Control)collapsiblePanelCollection_0.Item(num + 1)).Bottom + border;
			}
			((Control)collapsiblePanelCollection_0.Item(num)).Left = int_0;
			((Control)collapsiblePanelCollection_0.Item(num)).Width = ((Control)this).Width - 2 * int_0;
			if (((ScrollableControl)this).VScroll)
			{
				CollapsiblePanel collapsiblePanel = collapsiblePanelCollection_0.Item(num);
				((Control)collapsiblePanel).Width = ((Control)collapsiblePanel).Width - SystemInformation.VerticalScrollBarWidth;
			}
		}
	}

	protected override void OnControlAdded(ControlEventArgs e)
	{
		((Control)this).OnControlAdded(e);
		if (e.Control is CollapsiblePanel)
		{
			e.Control.Anchor = (AnchorStyles)13;
			if (!bool_0)
			{
				collapsiblePanelCollection_0.Insert(0, (CollapsiblePanel)(object)e.Control);
				collapsiblePanelCollection_0.Item(0).PanelStateChanged += method_2;
			}
			else
			{
				collapsiblePanelCollection_0.Add((CollapsiblePanel)(object)e.Control);
				collapsiblePanelCollection_0.Item(collapsiblePanelCollection_0.Count - 1).PanelStateChanged += method_2;
			}
			method_1(collapsiblePanelCollection_0.Count - 1);
		}
	}

	protected override void OnControlRemoved(ControlEventArgs e)
	{
		((Control)this).OnControlRemoved(e);
		if (e.Control is CollapsiblePanel)
		{
			int num = collapsiblePanelCollection_0.IndexOf((CollapsiblePanel)(object)e.Control);
			if (-1 != num)
			{
				collapsiblePanelCollection_0.Remove(num);
				method_1(collapsiblePanelCollection_0.Count - 1);
			}
		}
	}

	private void method_2(object sender, PanelEventArgs e)
	{
		int num = collapsiblePanelCollection_0.IndexOf(e.CollapsiblePanel);
		if (-1 != num)
		{
			method_1(--num);
		}
	}

	static CollapsiblePanelBar()
	{
		Class72.smethod_20();
	}
}
