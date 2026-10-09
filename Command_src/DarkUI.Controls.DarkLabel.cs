using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkLabel : Label
{
	private bool bool_0;

	private bool bool_1;

	[Category("Layout")]
	[Description("Enables automatic height sizing based on the contents of the label.")]
	[DefaultValue(false)]
	public bool AutoUpdateHeight
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			if (bool_0)
			{
				AutoSize = false;
				method_0();
			}
		}
	}

	public bool AutoSize
	{
		get
		{
			return ((Label)this).AutoSize;
		}
		set
		{
			((Label)this).AutoSize = value;
			if (AutoSize)
			{
				AutoUpdateHeight = false;
			}
		}
	}

	public DarkLabel()
	{
		((Control)this).ForeColor = Colors.LightText;
	}

	private void method_0()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (bool_0 && !bool_1)
		{
			try
			{
				bool_1 = true;
				Size size = new Size(((Control)this).Width, int.MaxValue);
				size = TextRenderer.MeasureText(((Control)this).Text, ((Control)this).Font, size, (TextFormatFlags)16);
				int height = size.Height;
				Padding padding = ((Control)this).Padding;
				((Control)this).Height = height + ((Padding)(ref padding)).Vertical;
			}
			finally
			{
				bool_1 = false;
			}
		}
	}

	protected override void OnTextChanged(EventArgs e)
	{
		((Label)this).OnTextChanged(e);
		method_0();
	}

	protected override void OnFontChanged(EventArgs e)
	{
		((Label)this).OnFontChanged(e);
		method_0();
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		((Control)this).OnSizeChanged(e);
		method_0();
	}

	static DarkLabel()
	{
		Class72.smethod_20();
	}
}
