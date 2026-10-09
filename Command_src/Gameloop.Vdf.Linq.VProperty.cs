using System;
using System.Runtime.CompilerServices;

namespace Gameloop.Vdf.Linq;

public sealed class VProperty : VToken
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private VToken vtoken_2;

	public string Key
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

	public new VToken Value
	{
		[CompilerGenerated]
		get
		{
			return vtoken_2;
		}
		[CompilerGenerated]
		set
		{
			vtoken_2 = value;
		}
	}

	public VProperty()
	{
	}

	public VProperty(string key, VToken value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		Key = key;
		Value = value;
	}

	public override void WriteTo(VdfWriter writer)
	{
		writer.WriteKey(Key);
		Value.WriteTo(writer);
	}

	static VProperty()
	{
		Class72.smethod_20();
	}
}
