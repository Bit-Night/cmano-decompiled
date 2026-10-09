using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CommandNetcode.Merge;

public sealed class ScenarioMergeInput
{
	[CompilerGenerated]
	private List<TeamMergeInput> list_0 = new List<TeamMergeInput>();

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private Guid guid_0;

	[CompilerGenerated]
	private string string_1;

	public List<TeamMergeInput> TeamMergeInputs
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

	public string ScenarioName
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

	public Guid ScenarioGuid
	{
		[CompilerGenerated]
		get
		{
			return guid_0;
		}
		[CompilerGenerated]
		set
		{
			guid_0 = value;
		}
	}

	public string ScenXML
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

	static ScenarioMergeInput()
	{
		Class72.smethod_20();
	}
}
