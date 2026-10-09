using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct AirPlatformAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes characteristics of Propulsion kill")]
	public enum PropulsionValue : uint
	{
		NoPropulsionKill,
		PropulsionKill
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

	[Description("Describes the size of the contrails or ionization trailing effects from an entity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes the state of the canopy")]
	public enum CanopyValue : uint
	{
		NotApplicable = 0u,
		CanopyIsClosed = 1u,
		Unknown = 2u,
		CanopyIsOpen = 4u,
		Unknown2 = 5u
	}

	[Description("Describes whether Landing Lights are on or off.")]
	public enum LandingLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Navigation Lights are on or off.")]
	public enum NavigationLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether Anti-Collision Lights are on or off.")]
	public enum AntiCollisionLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes whether flames are trailing from an entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the status of an air platform's afterburner")]
	public enum AfterburnerValue : uint
	{
		AfterburnerNotOn,
		AfterburnerOn
	}

	[Description("Describes the frozen status of a air platform")]
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

	[Description("Describes the state of a air platform")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether Formation Lights are on or off.")]
	public enum FormationLightsValue : uint
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

	private PaintSchemeValue paintSchemeValue_0;

	private PropulsionValue propulsionValue_0;

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private CanopyValue canopyValue_0;

	private LandingLightsValue landingLightsValue_0;

	private NavigationLightsValue navigationLightsValue_0;

	private AntiCollisionLightsValue antiCollisionLightsValue_0;

	private FlamingValue flamingValue_0;

	private AfterburnerValue afterburnerValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private FormationLightsValue formationLightsValue_0;

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

	public PropulsionValue Propulsion
	{
		get
		{
			return propulsionValue_0;
		}
		set
		{
			propulsionValue_0 = value;
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

	public CanopyValue Canopy
	{
		get
		{
			return canopyValue_0;
		}
		set
		{
			canopyValue_0 = value;
		}
	}

	public LandingLightsValue LandingLights
	{
		get
		{
			return landingLightsValue_0;
		}
		set
		{
			landingLightsValue_0 = value;
		}
	}

	public NavigationLightsValue NavigationLights
	{
		get
		{
			return navigationLightsValue_0;
		}
		set
		{
			navigationLightsValue_0 = value;
		}
	}

	public AntiCollisionLightsValue AntiCollisionLights
	{
		get
		{
			return antiCollisionLightsValue_0;
		}
		set
		{
			antiCollisionLightsValue_0 = value;
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

	public AfterburnerValue Afterburner
	{
		get
		{
			return afterburnerValue_0;
		}
		set
		{
			afterburnerValue_0 = value;
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

	public FormationLightsValue FormationLights
	{
		get
		{
			return formationLightsValue_0;
		}
		set
		{
			formationLightsValue_0 = value;
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

	public static bool operator !=(AirPlatformAppearance left, AirPlatformAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(AirPlatformAppearance left, AirPlatformAppearance right)
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

	public static explicit operator uint(AirPlatformAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator AirPlatformAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static AirPlatformAppearance FromByteArray(byte[] array, int index)
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

	public static AirPlatformAppearance smethod_0(uint value)
	{
		AirPlatformAppearance result = default(AirPlatformAppearance);
		uint paintScheme = (value & 1) >> 0;
		result.PaintScheme = (PaintSchemeValue)paintScheme;
		uint propulsion = (value & 2) >> 1;
		result.Propulsion = (PropulsionValue)propulsion;
		uint damage = (value & 0x18) >> 3;
		result.Damage = (DamageValue)damage;
		uint smoke = (value & 0x60) >> 5;
		result.Smoke = (SmokeValue)smoke;
		uint trailingEffects = (value & 0x180) >> 7;
		result.TrailingEffects = (TrailingEffectsValue)trailingEffects;
		uint canopy = (value & 0xE00) >> 9;
		result.Canopy = (CanopyValue)canopy;
		uint landingLights = (value & 0x1000) >> 12;
		result.LandingLights = (LandingLightsValue)landingLights;
		uint navigationLights = (value & 0x2000) >> 13;
		result.NavigationLights = (NavigationLightsValue)navigationLights;
		uint antiCollisionLights = (value & 0x4000) >> 14;
		result.AntiCollisionLights = (AntiCollisionLightsValue)antiCollisionLights;
		uint flaming = (value & 0x8000) >> 15;
		result.Flaming = (FlamingValue)flaming;
		uint afterburner = (value & 0x10000) >> 16;
		result.Afterburner = (AfterburnerValue)afterburner;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
		uint powerPlantStatus = (value & 0x400000) >> 22;
		result.PowerPlantStatus = (PowerPlantStatusValue)powerPlantStatus;
		uint state = (value & 0x800000) >> 23;
		result.State = (StateValue)state;
		uint formationLights = (value & 0x1000000) >> 24;
		result.FormationLights = (FormationLightsValue)formationLights;
		uint spotLights = (value & 0x10000000) >> 28;
		result.SpotLights = (SpotLightsValue)spotLights;
		uint interiorLights = (value & 0x20000000) >> 29;
		result.InteriorLights = (InteriorLightsValue)interiorLights;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is AirPlatformAppearance))
			{
				return false;
			}
			return Equals((AirPlatformAppearance)obj);
		}
		return false;
	}

	public bool Equals(AirPlatformAppearance other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (PaintScheme == other.PaintScheme && Propulsion == other.Propulsion && Damage == other.Damage && Smoke == other.Smoke && TrailingEffects == other.TrailingEffects && Canopy == other.Canopy && LandingLights == other.LandingLights && NavigationLights == other.NavigationLights && AntiCollisionLights == other.AntiCollisionLights && Flaming == other.Flaming && Afterburner == other.Afterburner && FrozenStatus == other.FrozenStatus && PowerPlantStatus == other.PowerPlantStatus && State == other.State && FormationLights == other.FormationLights && SpotLights == other.SpotLights)
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
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Propulsion << 1) | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Canopy << 9) | ((uint)LandingLights << 12) | ((uint)NavigationLights << 13) | ((uint)AntiCollisionLights << 14) | ((uint)Flaming << 15) | ((uint)Afterburner << 16) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)FormationLights << 24) | ((uint)SpotLights << 28) | ((uint)InteriorLights << 29);
	}

	public override int GetHashCode()
	{
		return ((((((((((((((((493 + PaintScheme.GetHashCode()) * 29 + Propulsion.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Canopy.GetHashCode()) * 29 + LandingLights.GetHashCode()) * 29 + NavigationLights.GetHashCode()) * 29 + AntiCollisionLights.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + Afterburner.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + FormationLights.GetHashCode()) * 29 + SpotLights.GetHashCode()) * 29 + InteriorLights.GetHashCode();
	}

	static AirPlatformAppearance()
	{
		Class72.smethod_20();
	}
}
