using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkTextBox : TextBox
{
	private string string_0 = string.Empty;

	public Color PlaceholderColor = Color.FromArgb(100, 100, 100);

	public string PlaceholderText
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			((Control)this).Invalidate();
		}
	}

	public DarkTextBox()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		((Control)this).BackColor = Colors.MediumBackground;
		((Control)this).ForeColor = Colors.LightText;
		((TextBoxBase)this).Padding = new Padding(2, 2, 2, 2);
		((TextBoxBase)this).BorderStyle = (BorderStyle)1;
		((Control)this).TextChanged += delegate
		{
			((Control)this).Invalidate();
		};
	}

	protected override void WndProc(ref Message m)
	{
		((TextBox)this).WndProc(ref m);
		if (((Message)(ref m)).Msg == 15 && string.IsNullOrEmpty(((Control)this).Text))
		{
			Graphics val = ((Control)this).CreateGraphics();
			try
			{
				Rectangle clientRectangle = ((Control)this).ClientRectangle;
				clientRectangle.Offset(2, 0);
				TextRenderer.DrawText((IDeviceContext)(object)val, string_0, ((Control)this).Font, clientRectangle, PlaceholderColor, (TextFormatFlags)268435460);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	protected override void OnGotFocus(EventArgs e)
	{
		((TextBox)this).OnGotFocus(e);
		((Control)this).Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		((Control)this).OnLostFocus(e);
		((Control)this).Invalidate();
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if ((int)keyData == 32)
		{
			return false;
		}
		return ((TextBox)this).ProcessCmdKey(ref msg, keyData);
	}

	[CompilerGenerated]
	private void DarkTextBox_TextChanged(object sender, EventArgs e)
	{
		((Control)this).Invalidate();
	}

	static DarkTextBox()
	{
		Class72.smethod_20();
	}
}
