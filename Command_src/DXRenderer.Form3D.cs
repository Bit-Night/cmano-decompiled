using System.Drawing;
using System.Windows.Forms;

namespace DXRenderer;

public class Form3D : Form
{
	internal static string Version;

	public Form3D(Size size)
	{
		((Control)this).Text = "DX11 Command Render - " + Version;
		((Form)this).Size = size;
	}

	static Form3D()
	{
		Class72.smethod_20();
		Version = "3D";
	}
}
