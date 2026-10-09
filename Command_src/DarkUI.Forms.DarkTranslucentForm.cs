using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Forms;

internal class DarkTranslucentForm : Form
{
	protected override bool ShowWithoutActivation => true;

	public DarkTranslucentForm(Color backColor, double opacity = 0.6)
	{
		((Form)this).StartPosition = (FormStartPosition)0;
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Size = new Size(1, 1);
		((Form)this).ShowInTaskbar = false;
		((Form)this).AllowTransparency = true;
		((Form)this).Opacity = opacity;
		((Control)this).BackColor = backColor;
	}

	static DarkTranslucentForm()
	{
		Class72.smethod_20();
	}
}
