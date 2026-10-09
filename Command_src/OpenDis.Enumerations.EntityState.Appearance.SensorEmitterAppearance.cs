using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct SensorEmitterAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes characteristics of mobility kill")]
	public enum MobilityValue : uint
	{
		NoMobilityKill,
		MobilityKill
	}

	[Description("Describes characteristics of mission kill (e.g. damaged antenna)")]
	public enum MissionValue : uint
	{
		NoMissionKill,
		MissionKill
	}

	[Description("Describes the damaged appearance of an entity")]
	public enum DamageValue : uint
	{
		NoDamage,
		SlightDamage,
		ModerateDamage,
		Destroyed
	}

	[Description("Describes status or location of smoke emanating from an entity")]
	public enum SmokeValue : uint
	{
		NotSmoking,
		SmokePlumeRisingFromTheEntity,
		EntityIsEmittingEngineSmoke,
		EntityIsEmittingEngineSmokeAndSmokePlumeIsRisingFromTheEntity
	}

	[Description("Describes the size of the dust cloud trailing effect for the Sensor/Emitter entity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes the status of lights on the sensor")]
	public enum LightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are rising from the entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the elevated status of the sensor's antenna")]
	public enum AntennaValue : uint
	{
		NotRaised,
		Raised
	}

	[Description("Describes the type of camouflage")]
	public enum CamouflageTypeValue : uint
	{
		DesertCamouflage,
		WinterCamouflage,
		ForestCamouflage,
		Unknown
	}

	[Description("Describes the type of concealment")]
	public enum ConcealedValue : uint
	{
		NotConcealed,
		EntityInAPreparedConcealedPositionWithNettingEtc
	}

	[Description("Describes the frozen status of an entity")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of the sensor")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of an entity")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes the status of a tent extension")]
	public enum TentValue : uint
	{
		NotExtended,
		Extended
	}

	[Description("Describes whether Blackout Lights are on or off.")]
	public enum BlackoutLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Interior Lights are on or off.")]
	public enum InteriorLightsValue : uint
	{
		Off,
		On
	}

	private PaintSchemeValue paintSchemeValue_0;

	private MobilityValue mobilityValue_0;

	private MissionValue missionValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private LightsValue lightsValue_0;

	private FlamingValue flamingValue_0;

	private AntennaValue antennaValue_0;

	private CamouflageTypeValue camouflageTypeValue_0;

	private ConcealedValue concealedValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private TentValue tentValue_0;

	private BlackoutLightsValue blackoutLightsValue_0;

	private InteriorLightsValue interiorLightsValue_0;

	public PaintSchemeValue PaintScheme
	{
		get
		{
			return paintSchemeValue_0;
		}
		set
		{
			paintSchemeValue_0 = value;
		}
	}

	public MobilityValue Mobility
	{
		get
		{
			return mobilityValue_0;
		}
		set
		{
			mobilityValue_0 = value;
		}
	}

	public MissionValue Mission
	{
		get
		{
			return missionValue_0;
		}
		set
		{
			missionValue_0 = value;
		}
	}

	public DamageValue Damage
	{
		get
		{
			return damageValue_0;
		}
		set
		{
			damageValue_0 = value;
		}
	}

	public SmokeValue Smoke
	{
		get
		{
			return smokeValue_0;
		}
		set
		{
			smokeValue_0 = value;
		}
	}

	public TrailingEffectsValue TrailingEffects
	{
		get
		{
			return trailingEffectsValue_0;
		}
		set
		{
			trailingEffectsValue_0 = value;
		}
	}

	public LightsValue Lights
	{
		get
		{
			return lightsValue_0;
		}
		set
		{
			lightsValue_0 = value;
		}
	}

	public FlamingValue Flaming
	{
		get
		{
			return flamingValue_0;
		}
		set
		{
			flamingValue_0 = value;
		}
	}

	public AntennaValue Antenna
	{
		get
		{
			return antennaValue_0;
		}
		set
		{
			antennaValue_0 = value;
		}
	}

	public CamouflageTypeValue CamouflageType
	{
		get
		{
			return camouflageTypeValue_0;
		}
		set
		{
			camouflageTypeValue_0 = value;
		}
	}

	public ConcealedValue Concealed
	{
		get
		{
			return concealedValue_0;
		}
		set
		{
			concealedValue_0 = value;
		}
	}

	public FrozenStatusValue FrozenStatus
	{
		get
		{
			return frozenStatusValue_0;
		}
		set
		{
			frozenStatusValue_0 = value;
		}
	}

	public PowerPlantStatusValue PowerPlantStatus
	{
		get
		{
			return powerPlantStatusValue_0;
		}
		set
		{
			powerPlantStatusValue_0 = value;
		}
	}

	public StateValue State
	{
		get
		{
			return stateValue_0;
		}
		set
		{
			stateValue_0 = value;
		}
	}

	public TentValue Tent
	{
		get
		{
			return tentValue_0;
		}
		set
		{
			tentValue_0 = value;
		}
	}

	public BlackoutLightsValue BlackoutLights
	{
		get
		{
			return blackoutLightsValue_0;
		}
		set
		{
			blackoutLightsValue_0 = value;
		}
	}

	public InteriorLightsValue InteriorLights
	{
		get
		{
			return interiorLightsValue_0;
		}
		set
		{
			interiorLightsValue_0 = value;
		}
	}

	public static bool operator !=(SensorEmitterAppearance left, SensorEmitterAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(SensorEmitterAppearance left, SensorEmitterAppearance right)
	{
		if ((object)left == (object)right)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public static explicit operator uint(SensorEmitterAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator SensorEmitterAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static SensorEmitterAppearance FromByteArray(byte[] array, int index)
	{
		if (array != null)
		{
			if (index < 0 || index > array.Length - 1 || index + 4 > array.Length - 1)
			{
				throw new IndexOutOfRangeException();
			}
			return smethod_0(BitConverter.ToUInt32(array, index));
		}
		throw new ArgumentNullException("array");
	}

	public static SensorEmitterAppearance smethod_0(uint value)
	{
		SensorEmitterAppearance result = default(SensorEmitterAppearance);
		uint paintScheme = (value & 1) >> 0;
		result.PaintScheme = (PaintSchemeValue)paintScheme;
		uint mobility = (value & 2) >> 1;
		result.Mobility = (MobilityValue)mobility;
		uint mission = (value & 4) >> 2;
		result.Mission = (MissionValue)mission;
		uint damage = (value & 0x18) >> 3;
		result.Damage = (DamageValue)damage;
		uint smoke = (value & 0x60) >> 5;
		result.Smoke = (SmokeValue)smoke;
		uint trailingEffects = (value & 0x180) >> 7;
		result.TrailingEffects = (TrailingEffectsValue)trailingEffects;
		uint lights = (value & 0x1000) >> 12;
		result.Lights = (LightsValue)lights;
		uint flaming = (value & 0x8000) >> 15;
		result.Flaming = (FlamingValue)flaming;
		uint antenna = (value & 0x10000) >> 16;
		result.Antenna = (AntennaValue)antenna;
		uint camouflageType = (value & 0x60000) >> 17;
		result.CamouflageType = (CamouflageTypeValue)camouflageType;
		uint concealed = (value & 0x80000) >> 19;
		result.Concealed = (ConcealedValue)concealed;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
		uint powerPlantStatus = (value & 0x400000) >> 22;
		result.PowerPlantStatus = (PowerPlantStatusValue)powerPlantStatus;
		uint state = (value & 0x800000) >> 23;
		result.State = (StateValue)state;
		uint tent = (value & 0x1000000) >> 24;
		result.Tent = (TentValue)tent;
		uint blackoutLights = (value & 0x4000000) >> 26;
		result.BlackoutLights = (BlackoutLightsValue)blackoutLights;
		uint interiorLights = (value & 0x20000000) >> 29;
		result.InteriorLights = (InteriorLightsValue)interiorLights;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is SensorEmitterAppearance))
			{
				return false;
			}
			return Equals((SensorEmitterAppearance)obj);
		}
		return false;
	}

	public bool Equals(SensorEmitterAppearance other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (PaintScheme == other.PaintScheme && Mobility == other.Mobility && Mission == other.Mission && Damage == other.Damage && Smoke == other.Smoke && TrailingEffects == other.TrailingEffects && Lights == other.Lights && Flaming == other.Flaming && Antenna == other.Antenna && CamouflageType == other.CamouflageType && Concealed == other.Concealed && FrozenStatus == other.FrozenStatus && PowerPlantStatus == other.PowerPlantStatus && State == other.State && Tent == other.Tent && BlackoutLights == other.BlackoutLights)
		{
			return InteriorLights == other.InteriorLights;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)Mission << 2) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Lights << 12) | ((uint)Flaming << 15) | ((uint)Antenna << 16) | ((uint)CamouflageType << 17) | ((uint)Concealed << 19) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)Tent << 24) | ((uint)BlackoutLights << 26) | ((uint)InteriorLights << 29);
	}

	public override int GetHashCode()
	{
		return ((((((((((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + Mission.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Lights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + Antenna.GetHashCode()) * 29 + CamouflageType.GetHashCode()) * 29 + Concealed.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Tent.GetHashCode()) * 29 + BlackoutLights.GetHashCode()) * 29 + InteriorLights.GetHashCode();
	}

	static SensorEmitterAppearance()
	{
		Class72.smethod_20();
	}
}
