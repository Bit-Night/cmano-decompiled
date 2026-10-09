using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkGroupBox : GroupBox
{
	public DarkGroupBox()
	{
		((Control)this).ForeColor = Colors.LightText;
	}

	static DarkGroupBox()
	{
		Class72.smethod_20();
	}
}
