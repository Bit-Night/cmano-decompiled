using System.Windows.Forms;

namespace Command;

public sealed class MaintainScrollPosition
{
	private static int int_0;

	private static int int_1;

	public void method_0(DataGridView dg)
	{
		int_0 = dg.FirstDisplayedScrollingRowIndex;
	}

	public void method_1(DataGridView dg)
	{
		dg.FirstDisplayedScrollingRowIndex = int_0;
	}

	public void method_2(DataGridView dg)
	{
		int_1 = dg.FirstDisplayedScrollingColumnIndex;
	}

	public void method_3(DataGridView dg)
	{
		dg.FirstDisplayedScrollingColumnIndex = int_1;
	}

	static MaintainScrollPosition()
	{
		Class72.smethod_20();
	}
}
