using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using DarkUI.Config;

namespace DarkUI.Controls;

public sealed class DarkListItem
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private FontStyle fontStyle_0;

	[CompilerGenerated]
	private Bitmap bitmap_0;

	[CompilerGenerated]
	private object object_0;

	public string ToolTipText
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string Text
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
	}

	public Rectangle Area
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		set
		{
			rectangle_0 = value;
		}
	}

	public Color TextColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public FontStyle FontStyle
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return fontStyle_0;
		}
		[CompilerGenerated]
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			fontStyle_0 = value;
		}
	}

	public Bitmap Icon
	{
		[CompilerGenerated]
		get
		{
			return bitmap_0;
		}
		[CompilerGenerated]
		set
		{
			bitmap_0 = value;
		}
	}

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public event EventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public DarkListItem()
	{
		TextColor = Colors.LightText;
		FontStyle = (FontStyle)0;
	}

	public DarkListItem(string text)
		: this()
	{
		Text = text;
	}

	public override string ToString()
	{
		return Text;
	}

	static DarkListItem()
	{
		Class72.smethod_20();
	}
}
