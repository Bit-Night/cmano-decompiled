using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Command.WinFormControls;

public sealed class TextProgressBar : ProgressBar
{
	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = ((ProgressBar)this).CreateParams;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6)
			{
				createParams.ExStyle |= 0x2000000;
			}
			return createParams;
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public override string Text
	{
		get
		{
			return ((ProgressBar)this).Text;
		}
		set
		{
			((ProgressBar)this).Text = value;
			((Control)this).Refresh();
		}
	}

	protected override void WndProc(ref Message m)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		((Control)this).WndProc(ref m);
		if (((Message)(ref m)).Msg != 15)
		{
			return;
		}
		Graphics val = ((Control)this).CreateGraphics();
		try
		{
			SolidBrush val2 = new SolidBrush(((Control)this).ForeColor);
			try
			{
				SizeF sizeF = val.MeasureString(Text, SystemFonts.DefaultFont);
				val.DrawString(Text, SystemFonts.DefaultFont, (Brush)(object)val2, ((float)((Control)this).Width - sizeF.Width) / 2f, ((float)((Control)this).Height - sizeF.Height) / 2f);
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	static TextProgressBar()
	{
		Class72.smethod_20();
	}
}
