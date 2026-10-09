using System.Runtime.CompilerServices;

namespace Command_Core;

public class JammingInfo
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private int int_0;

	public bool isJammed
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public int JammingStrenght
	{
		get
		{
			return method_0();
		}
		set
		{
			if (value < 0)
			{
				value = 0;
			}
			if (value > 100)
			{
				value = 100;
			}
			method_1(value);
		}
	}

	public JammingInfo()
	{
		isJammed = false;
		JammingStrenght = 0;
	}

	[SpecialName]
	[CompilerGenerated]
	private int method_0()
	{
		return int_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(int int_1)
	{
		int_0 = int_1;
	}

	static JammingInfo()
	{
		Class72.smethod_20();
	}
}
