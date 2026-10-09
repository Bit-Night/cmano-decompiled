using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CommandNetcode.Merge;

public sealed class TeamMergeInput
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private List<PlayerMergeInput> list_0 = new List<PlayerMergeInput>();

	public string SideGuid
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

	public string SideName
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

	public List<PlayerMergeInput> PlayerMergeInputs
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	static TeamMergeInput()
	{
		Class72.smethod_20();
	}
}
