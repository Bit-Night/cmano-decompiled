using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Zeptomoby.OrbitTools;

[Serializable]
public sealed class DecayException : PropagationException
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private string string_0;

	public DateTime DecayTime
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		private set
		{
			dateTime_0 = value;
		}
	}

	public string SatelliteName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public DecayException()
	{
	}

	public DecayException(string message)
		: base(message)
	{
	}

	public DecayException(string message, Exception inner)
		: base(message, inner)
	{
	}

	public DecayException(Julian decayTime, string satelliteName)
		: this(decayTime.ToTime(), satelliteName)
	{
	}

	public DecayException(DateTime decayTime, string satelliteName)
	{
		DecayTime = decayTime;
		SatelliteName = satelliteName;
	}

	private DecayException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	static DecayException()
	{
		Class72.smethod_20();
	}
}
