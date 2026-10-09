using System.Windows.Forms;

namespace Command;

public sealed class DoubleBufferedDataGridView : DataGridView
{
	public DoubleBufferedDataGridView()
	{
		((Control)this).DoubleBuffered = true;
		((Control)this).SetStyle((ControlStyles)139266, true);
	}

	static DoubleBufferedDataGridView()
	{
		Class72.smethod_20();
	}
}
