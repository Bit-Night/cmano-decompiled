using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct LandPlatformAppearance
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

	[Description("Describes characteristics of fire-power kill")]
	public enum FirePowerValue : uint
	{
		NoFirePowerKill,
		FirePowerKill
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

	[Description("Describes the size of the dust cloud trailing effect for the Effects entity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes the state of the primary hatch")]
	public enum HatchValue : uint
	{
		NotApplicable,
		PrimaryHatchIsClosed,
		PrimaryHatchIsPopped,
		PrimaryHatchIsPoppedAndAPersonIsVisibleUnderHatch,
		PrimaryHatchIsOpen,
		PrimaryHatchIsOpenAndPersonIsVisible,
		Unknown
	}

	[Description("Describes whether Head Lights are on or off.")]
	public enum HeadLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Tail Lights are on or off.")]
	public enum TailLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Brake Lights are on or off.")]
	public enum BrakeLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are rising from an entity")]
	public enum FlamingValue : uint
	{
		Off,
		On
	}

	[Description("Describes the elevated status of the platform's primary launcher")]
	public enum LauncherValue : uint
	{
		Off,
		On
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

	[Description("Describes the frozen status of a Land Entity")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIEShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonZeroVelocityAccelerationOrRotationDataReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of platform")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a Land Entity")]
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

	[Description("Describes the status of a ramp")]
	public enum RampValue : uint
	{
		Up,
		Down
	}

	[Description("Describes whether Blackout Lights are on or off.")]
	public enum BlackoutLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Blackout Brake Lights are on or off.")]
	public enum BlackoutBrakeLightsValue : uint
	{
		Off,
		On
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

	[Description("Describes the surrender state of the vehicle occupants")]
	public enum SurrenderStateValue : uint
	{
		NotSurrendered,
		Surrender
	}

	[Description("Describes if the entity is Masked / Cloaked or Not")]
	public enum MaskedCloakedValue : uint
	{
		NotMaskedNotCloaked,
		MaskedCloaked
	}

	private PaintSchemeValue paintSchemeValue_0;

	private MobilityValue mobilityValue_0;

	private FirePowerValue firePowerValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private HatchValue hatchValue_0;

	private HeadLightsValue headLightsValue_0;

	private TailLightsValue tailLightsValue_0;

	private BrakeLightsValue brakeLightsValue_0;

	private FlamingValue flamingValue_0;

	private LauncherValue launcherValue_0;

	private CamouflageTypeValue camouflageTypeValue_0;

	private ConcealedValue concealedValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private TentValue tentValue_0;

	private RampValue rampValue_0;

	private BlackoutLightsValue blackoutLightsValue_0;

	private BlackoutBrakeLightsValue blackoutBrakeLightsValue_0;

	private SpotLightsValue spotLightsValue_0;

	private InteriorLightsValue interiorLightsValue_0;

	private SurrenderStateValue surrenderStateValue_0;

	private MaskedCloakedValue maskedCloakedValue_0;

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

	public FirePowerValue FirePower
	{
		get
		{
			return firePowerValue_0;
		}
		set
		{
			firePowerValue_0 = value;
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

	public HatchValue Hatch
	{
		get
		{
			return hatchValue_0;
		}
		set
		{
			hatchValue_0 = value;
		}
	}

	public HeadLightsValue HeadLights
	{
		get
		{
			return headLightsValue_0;
		}
		set
		{
			headLightsValue_0 = value;
		}
	}

	public TailLightsValue TailLights
	{
		get
		{
			return tailLightsValue_0;
		}
		set
		{
			tailLightsValue_0 = value;
		}
	}

	public BrakeLightsValue BrakeLights
	{
		get
		{
			return brakeLightsValue_0;
		}
		set
		{
			brakeLightsValue_0 = value;
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

	public LauncherValue Launcher
	{
		get
		{
			return launcherValue_0;
		}
		set
		{
			launcherValue_0 = value;
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

	public RampValue Ramp
	{
		get
		{
			return rampValue_0;
		}
		set
		{
			rampValue_0 = value;
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

	public BlackoutBrakeLightsValue BlackoutBrakeLights
	{
		get
		{
			return blackoutBrakeLightsValue_0;
		}
		set
		{
			blackoutBrakeLightsValue_0 = value;
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

	public SurrenderStateValue SurrenderState
	{
		get
		{
			return surrenderStateValue_0;
		}
		set
		{
			surrenderStateValue_0 = value;
		}
	}

	public MaskedCloakedValue MaskedCloaked
	{
		get
		{
			return maskedCloakedValue_0;
		}
		set
		{
			maskedCloakedValue_0 = value;
		}
	}

	public static bool operator !=(LandPlatformAppearance left, LandPlatformAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(LandPlatformAppearance left, LandPlatformAppearance right)
	{
		if ((object)left == (object)right)
		{
			return true;
		}
		int result;
		if ((object)left != null)
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static explicit operator uint(LandPlatformAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator LandPlatformAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static LandPlatformAppearance FromByteArray(byte[] array, int index)
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

	public static LandPlatformAppearance smethod_0(uint value)
	{
		LandPlatformAppearance result = default(LandPlatformAppearance);
		uint paintScheme = (value & 1) >> 0;
		result.PaintScheme = (PaintSchemeValue)paintScheme;
		uint mobility = (value & 2) >> 1;
		result.Mobility = (MobilityValue)mobility;
		uint firePower = (value & 4) >> 2;
		result.FirePower = (FirePowerValue)firePower;
		uint damage = (value & 0x18) >> 3;
		result.Damage = (DamageValue)damage;
		uint smoke = (value & 0x60) >> 5;
		result.Smoke = (SmokeValue)smoke;
		uint trailingEffects = (value & 0x180) >> 7;
		result.TrailingEffects = (TrailingEffectsValue)trailingEffects;
		uint hatch = (value & 0xE00) >> 9;
		result.Hatch = (HatchValue)hatch;
		uint headLights = (value & 0x1000) >> 12;
		result.HeadLights = (HeadLightsValue)headLights;
		uint tailLights = (value & 0x2000) >> 13;
		result.TailLights = (TailLightsValue)tailLights;
		uint brakeLights = (value & 0x4000) >> 14;
		result.BrakeLights = (BrakeLightsValue)brakeLights;
		uint flaming = (value & 0x8000) >> 15;
		result.Flaming = (FlamingValue)flaming;
		uint launcher = (value & 0x10000) >> 16;
		result.Launcher = (LauncherValue)launcher;
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
		uint ramp = (value & 0x2000000) >> 25;
		result.Ramp = (RampValue)ramp;
		uint blackoutLights = (value & 0x4000000) >> 26;
		result.BlackoutLights = (BlackoutLightsValue)blackoutLights;
		uint blackoutBrakeLights = (value & 0x8000000) >> 27;
		result.BlackoutBrakeLights = (BlackoutBrakeLightsValue)blackoutBrakeLights;
		uint spotLights = (value & 0x10000000) >> 28;
		result.SpotLights = (SpotLightsValue)spotLights;
		uint interiorLights = (value & 0x20000000) >> 29;
		result.InteriorLights = (InteriorLightsValue)interiorLights;
		uint surrenderState = (value & 0x40000000) >> 30;
		result.SurrenderState = (SurrenderStateValue)surrenderState;
		uint maskedCloaked = (value & 0x80000000u) >> 31;
		result.MaskedCloaked = (MaskedCloakedValue)maskedCloaked;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is LandPlatformAppearance))
			{
				return false;
			}
			return Equals((LandPlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(LandPlatformAppearance other)
	{
		if ((object)other != null)
		{
			if (PaintScheme == other.PaintScheme && Mobility == other.Mobility && FirePower == other.FirePower && Damage == other.Damage && Smoke == other.Smoke && TrailingEffects == other.TrailingEffects && Hatch == other.Hatch && HeadLights == other.HeadLights && TailLights == other.TailLights && BrakeLights == other.BrakeLights && Flaming == other.Flaming && Launcher == other.Launcher && CamouflageType == other.CamouflageType && Concealed == other.Concealed && FrozenStatus == other.FrozenStatus && PowerPlantStatus == other.PowerPlantStatus && State == other.State && Tent == other.Tent && Ramp == other.Ramp && BlackoutLights == other.BlackoutLights && BlackoutBrakeLights == other.BlackoutBrakeLights && SpotLights == other.SpotLights && InteriorLights == other.InteriorLights && SurrenderState == other.SurrenderState)
			{
				return MaskedCloaked == other.MaskedCloaked;
			}
			return false;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Mobility << 1) | ((uint)FirePower << 2) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Hatch << 9) | ((uint)HeadLights << 12) | ((uint)TailLights << 13) | ((uint)BrakeLights << 14) | ((uint)Flaming << 15) | ((uint)Launcher << 16) | ((uint)CamouflageType << 17) | ((uint)Concealed << 19) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)Tent << 24) | ((uint)Ramp << 25) | ((uint)BlackoutLights << 26) | ((uint)BlackoutBrakeLights << 27) | ((uint)SpotLights << 28) | ((uint)InteriorLights << 29) | ((uint)SurrenderState << 30) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return ((((((((((((((((((((((((493 + PaintScheme.GetHashCode()) * 29 + Mobility.GetHashCode()) * 29 + FirePower.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Hatch.GetHashCode()) * 29 + HeadLights.GetHashCode()) * 29 + TailLights.GetHashCode()) * 29 + BrakeLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + Launcher.GetHashCode()) * 29 + CamouflageType.GetHashCode()) * 29 + Concealed.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Tent.GetHashCode()) * 29 + Ramp.GetHashCode()) * 29 + BlackoutLights.GetHashCode()) * 29 + BlackoutBrakeLights.GetHashCode()) * 29 + SpotLights.GetHashCode()) * 29 + InteriorLights.GetHashCode()) * 29 + SurrenderState.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}

	static LandPlatformAppearance()
	{
		Class72.smethod_20();
	}
}
