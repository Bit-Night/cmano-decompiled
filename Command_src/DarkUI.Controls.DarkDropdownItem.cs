using System.Drawing;
using System.Runtime.CompilerServices;

namespace DarkUI.Controls;

public sealed class DarkDropdownItem
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private Bitmap bitmap_0;

	public string Text
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string Value
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

	public DarkDropdownItem()
	{
	}

	public DarkDropdownItem(string text)
	{
		Text = text;
	}

	public DarkDropdownItem(string text, string value)
	{
		Text = text;
		Value = value;
	}

	public DarkDropdownItem(string text, Bitmap icon)
		: this(text)
	{
		Icon = icon;
	}

	static DarkDropdownItem()
	{
		Class72.smethod_20();
	}
}
