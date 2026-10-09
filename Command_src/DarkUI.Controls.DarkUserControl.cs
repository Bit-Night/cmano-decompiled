using System.ComponentModel;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public class DarkUserControl : UserControl
{
	private IContainer icontainer_0;

	public DarkUserControl()
	{
		method_0();
		((Control)this).BackColor = Colors.GreyBackground;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		((ContainerControl)this).Dispose(disposing);
	}

	private void method_0()
	{
		icontainer_0 = new Container();
	}

	static DarkUserControl()
	{
		Class72.smethod_20();
	}
}
