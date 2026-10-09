using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct SurfacePlatformAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes characteristics of mobility kills")]
	public enum MobilityValue : uint
	{
		NoMobilityKill,
		MobilityKill
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

	[Description("Describes the size of the wake trailing effect for the entity.")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes whether Running Lights are on or off.")]
	public enum RunningLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are rising from an entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the frozen status of a Surface platform")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of platform")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a Surface platform")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether Spot Lights are on or off.")]
	public enum SpotLightsValue : uint
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

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private RunningLightsValue runningLightsValue_0;

	private FlamingValue flamingValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private SpotLightsValue spotLightsValue_0;

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

	public RunningLightsValue RunningLights
	{
		get
		{
			return runningLightsValue_0;
		}
		set
		{
			runningLightsValue_0 = value;
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

	public SpotLightsValue SpotLights
	{
		get
		{
			return spotLightsValue_0;
		}
		set
		{
			spotLightsValue_0 = value;
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

	public static bool operator !=(SurfacePlatformAppearance left, SurfacePlatformAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(SurfacePlatformAppearance left, SurfacePlatformAppearance right)
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

	public static explicit operator uint(SurfacePlatformAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator SurfacePlatformAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static SurfacePlatformAppearance FromByteArray(byte[] array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0 || index > array.Length - 1 || index + 4 > array.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(array, index));
	}

	public static SurfacePlatformAppearance smethod_0(uint value)
	{
		SurfacePlatformAppearance result = default(SurfacePlatformAppearance);
		uint paintScheme = (value & 1) >> 0;
		result.PaintScheme = (PaintSchemeValue)paintScheme;
		uint mobility = (value & 2) >> 1;
		result.Mobility = (MobilityValue)mobility;
		uint damage = (value & 0x18) >> 3;
		result.Damage = (DamageValue)damage;
		uint smoke = (value & 0x60) >> 5;
		result.Smoke = (SmokeValue)smoke;
		uint trailingEffects = (value & 0x180) >> 7;
		result.TrailingEffects = (TrailingEffectsValue)trailingEffects;
		uint runningLights = (value & 0x1000) >> 12;
		result.RunningLights = (RunningLightsValue)runningLights;
		uint flaming = (value & 0x8000) >> 15;
		result.Flaming = (FlamingValue)flaming;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
		uint powerPlantStatus = (value & 0x400000) >> 22;
		result.PowerPlantStatus = (PowerPlantStatusValue)powerPlantStatus;
		uint state = (value & 0x800000) >> 23;
		result.State = (StateValue)state;
		uint spotLights = (value & 0x10000000) >> 28;
		result.SpotLights = (SpotLightsValue)spotLights;
		uint interiorLights = (value & 0x20000000) >> 29;
		result.InteriorLights = (InteriorLightsValue)interiorLights;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is SurfacePlatformAppearance)
		{
			return Equals((SurfacePlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(SurfacePlatformAppearance other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (PaintScheme == other.PaintScheme && Mobility == other.Mobility && Damage == other.Damage && Smoke == other.Smoke && TrailingEffects == other.TrailingEffects && RunningLights == other.RunningLights && Flaming == other.Flaming && FrozenStatus == other.FrozenStatus && PowerPlantStatus == other.PowerPlantStatus && State == other.State && SpotLights == other.SpotLights)
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
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)RunningLights << 12) | ((uint)Flaming << 15) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)SpotLights << 28) | ((uint)InteriorLights << 29);
	}

	public override int GetHashCode()
	{
		return (((((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + RunningLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + SpotLights.GetHashCode()) * 29 + InteriorLights.GetHashCode();
	}

	static SurfacePlatformAppearance()
	{
		Class72.smethod_20();
	}
}
