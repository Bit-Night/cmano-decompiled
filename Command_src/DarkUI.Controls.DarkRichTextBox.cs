using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkRichTextBox : RichTextBox
{
	public DarkRichTextBox()
	{
		((Control)this).ForeColor = Colors.LightText;
		((Control)this).BackColor = Colors.MediumBackground;
	}

	static DarkRichTextBox()
	{
		Class72.smethod_20();
	}
}
