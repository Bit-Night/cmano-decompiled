using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DesignerGenerated]
internal class TextProgressBar : UserControl
{
	private IContainer icontainer_0;

	public TextProgressBar()
	{
		method_0();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		finally
		{
			((ContainerControl)this).Dispose(disposing);
		}
	}

	private void method_0()
	{
		icontainer_0 = new Container();
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)3;
	}

	static TextProgressBar()
	{
		Class72.smethod_20();
	}
}
