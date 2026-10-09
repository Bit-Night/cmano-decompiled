using System.Runtime.CompilerServices;

namespace Gameloop.Vdf.Linq;

public sealed class VValue : VToken
{
	[CompilerGenerated]
	private object object_0;

	public new object Value
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

	public VValue(object value)
	{
		Value = value;
	}

	public override void WriteTo(VdfWriter writer)
	{
		writer.WriteValue(this);
	}

	public override string ToString()
	{
		object value = Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_001b;
			}
		}
		obj = string.Empty;
		goto IL_001b;
		IL_001b:
		return (string)obj;
	}

	static VValue()
	{
		Class72.smethod_20();
	}
}
