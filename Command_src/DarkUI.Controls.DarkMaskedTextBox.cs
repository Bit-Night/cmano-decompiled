using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkMaskedTextBox : MaskedTextBox
{
	public DarkMaskedTextBox()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).BackColor = Colors.MediumBackground;
		((Control)this).ForeColor = Colors.LightText;
		((TextBoxBase)this).Padding = new Padding(2, 2, 2, 2);
		((TextBoxBase)this).BorderStyle = (BorderStyle)1;
	}

	static DarkMaskedTextBox()
	{
		Class72.smethod_20();
	}
}
