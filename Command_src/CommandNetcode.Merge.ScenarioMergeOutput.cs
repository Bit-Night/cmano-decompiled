using System.Runtime.CompilerServices;

namespace CommandNetcode.Merge;

public sealed class ScenarioMergeOutput
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	public string ScenXML
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

	public string Messages
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

	static ScenarioMergeOutput()
	{
		Class72.smethod_20();
	}
}
