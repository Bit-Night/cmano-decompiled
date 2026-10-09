using System;
using Command_Core.SmartAssembly.Attributes;

namespace Command;

[DoNotPruneType]
[DoNotObfuscate]
[DoNotPrune]
public sealed class ScoringDatapointViewModel : CommandViewModel
{
	private int int_0;

	private DateTime dateTime_0;

	private string string_0;

	public int ScoreValue
	{
		get
		{
			return int_0;
		}
		set
		{
			SetProperty(ref int_0, value, "ScoreValue");
		}
	}

	public DateTime DateTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			SetProperty(ref dateTime_0, value, "DateTime");
		}
	}

	public string Reason
	{
		get
		{
			return string_0;
		}
		set
		{
			SetProperty(ref string_0, value, "Reason");
		}
	}

	static ScoringDatapointViewModel()
	{
		Class72.smethod_20();
	}
}
