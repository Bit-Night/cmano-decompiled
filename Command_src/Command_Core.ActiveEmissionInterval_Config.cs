using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class ActiveEmissionInterval_Config
{
	public Alertlevels Defcon;

	public bool UseEmissionInterval;

	public bool WakeWhenDetectingThreat;

	public float SleepModeDelay;

	public float EmissionInterval;

	public float EmissionIntervalVariation;

	public float EmissionDuration;

	public bool FollowWRAforWakeBehavior;

	public Dictionary<Misc.PostureStance, bool> Wake_IncludesContactStance;

	public Dictionary<Contact_Base.IdentificationStatus, bool> Wake_IncludesContactID;

	private static Array array_0;

	static ActiveEmissionInterval_Config()
	{
		Class72.smethod_20();
		array_0 = Enum.GetValues(typeof(Misc.PostureStance));
	}

	public ActiveEmissionInterval_Config(Alertlevels _Defcon, bool WithDefaultValues = true)
	{
		Wake_IncludesContactStance = new Dictionary<Misc.PostureStance, bool>();
		Wake_IncludesContactID = new Dictionary<Contact_Base.IdentificationStatus, bool>();
		Defcon = _Defcon;
		UseEmissionInterval = false;
		WakeWhenDetectingThreat = true;
		SleepModeDelay = 0f;
		EmissionInterval = 0f;
		EmissionDuration = 0f;
		EmissionIntervalVariation = 0f;
		Initialise(WithDefaultValues);
	}

	public ActiveEmissionInterval_Config(bool _UseEmissionInterval, bool _EmissionIntervalIsAwake, bool _WakeWhenDetectingThreat, float _SleepModeDelay, float _EmissionInterval, float _EmissionIntervalVariation)
	{
		Wake_IncludesContactStance = new Dictionary<Misc.PostureStance, bool>();
		Wake_IncludesContactID = new Dictionary<Contact_Base.IdentificationStatus, bool>();
		UseEmissionInterval = _UseEmissionInterval;
		WakeWhenDetectingThreat = _WakeWhenDetectingThreat;
		SleepModeDelay = _SleepModeDelay;
		EmissionInterval = _EmissionInterval;
		EmissionIntervalVariation = _EmissionIntervalVariation;
		Initialise();
	}

	public void Initialise(bool WithDefaultValues = true)
	{
		foreach (object item in array_0)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(item);
			Wake_IncludesContactStance.Add((Misc.PostureStance)Conversions.ToByte(objectValue), value: false);
		}
		foreach (object item2 in array_0)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(item2);
			Wake_IncludesContactID.Add((Contact_Base.IdentificationStatus)Conversions.ToShort(objectValue2), value: false);
		}
		EmissionInterval = 30f;
		EmissionDuration = 30f;
		if (WithDefaultValues)
		{
			Wake_IncludesContactStance[Misc.PostureStance.Hostile] = true;
			Wake_IncludesContactStance[Misc.PostureStance.Neutral] = true;
			Wake_IncludesContactStance[Misc.PostureStance.Unfriendly] = true;
			Wake_IncludesContactStance[Misc.PostureStance.Unknown] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownClass] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownDomain] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.KnownType] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.PreciseID] = true;
			Wake_IncludesContactID[Contact_Base.IdentificationStatus.Unknown] = true;
		}
	}
}
