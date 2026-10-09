using System.Globalization;
using System.Runtime.CompilerServices;

namespace Magic.Samples.DisplaySettings;

public struct DisplaySettings
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	[CompilerGenerated]
	private Orientation orientation_0;

	[CompilerGenerated]
	private int int_3;

	[CompilerGenerated]
	private int int_4;

	public int Index
	{
		[CompilerGenerated]
		readonly get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int Width
	{
		[CompilerGenerated]
		readonly get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int Height
	{
		[CompilerGenerated]
		readonly get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public Orientation Orientation
	{
		[CompilerGenerated]
		readonly get
		{
			return orientation_0;
		}
		[CompilerGenerated]
		set
		{
			orientation_0 = value;
		}
	}

	public int BitCount
	{
		[CompilerGenerated]
		readonly get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int Frequency
	{
		[CompilerGenerated]
		readonly get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0} by {1}, {2}, {3} Bit, {4} Hertz", Width, Height, (int)Orientation, BitCount, Frequency);
	}

	static DisplaySettings()
	{
		Class72.smethod_20();
	}
}
