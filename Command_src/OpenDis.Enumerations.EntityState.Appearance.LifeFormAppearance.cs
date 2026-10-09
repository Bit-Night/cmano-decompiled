using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct LifeFormAppearance
{
	[Description("Describes the paint scheme of an entity")]
	public enum PaintSchemeValue : uint
	{
		UniformColor,
		Camouflage
	}

	[Description("Describes the damaged visual appearance of an entity")]
	public enum HealthValue : uint
	{
		NoInjury,
		SlightInjury,
		ModerateInjury,
		FatalInjury
	}

	[Description("Describes compliance of life form")]
	public enum ComplianceValue : uint
	{
		Unknown,
		Detained,
		Surrender,
		UsingFists,
		VerbalAbuseLevel1,
		VerbalAbuseLevel2,
		VerbalAbuseLevel3,
		PassiveResistanceLevel1,
		PassiveResistanceLevel2,
		PassiveResistanceLevel3,
		UsingNonLethalWeapon1,
		UsingNonLethalWeapon2,
		UsingNonLethalWeapon3,
		UsingNonLethalWeapon4,
		UsingNonLethalWeapon5,
		UsingNonLethalWeapon6
	}

	[Description("Describes whether Flash Lights are on or off.")]
	public enum FlashLightsValue : uint
	{
		Off,
		On
	}

	[Description("Describes the state of the life form")]
	public enum LifeFormStateValue : uint
	{
		Unknown,
		UprightStandingStill,
		UprightWalking,
		UprightRunning,
		Kneeling,
		Prone,
		Crawling,
		Swimming,
		Parachuting,
		Jumping,
		Sitting,
		Squatting,
		Crouching,
		Wading,
		Surrender,
		Detained
	}

	[Description("Describes the frozen status of a life form")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the state of a life form")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes the position of the life form's primary weapon")]
	public enum Weapon1Value : uint
	{
		NoPrimaryWeaponPresent,
		PrimaryWeaponIsStowed,
		PrimaryWeaponIsDeployed,
		PrimaryWeaponIsInFiringPosition
	}

	[Description("Describes the position of the life form's secondary weapon")]
	public enum Weapon2Value : uint
	{
		NoSecondaryWeaponPresent,
		SecondaryWeaponIsStowed,
		SecondaryWeaponIsDeployed,
		SecondaryWeaponIsInFiringPosition
	}

	[Description("Describes the type of camouflage")]
	public enum CamouflageTypeValue : uint
	{
		DesertCamouflage,
		WinterCamouflage,
		ForestCamouflage,
		Unknown
	}

	[Description("Describes the type of stationary concealment")]
	public enum ConcealedStationaryValue : uint
	{
		NotConcealed,
		EntityInAPreparedConcealedPosition
	}

	[Description("Describes the type of concealed movement")]
	public enum ConcealedMovementValue : uint
	{
		OpenMovement,
		RushesBetweenCoveredPositions
	}

	private PaintSchemeValue paintSchemeValue_0;

	private HealthValue healthValue_0;

	private ComplianceValue complianceValue_0;

	private FlashLightsValue flashLightsValue_0;

	private LifeFormStateValue lifeFormStateValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private StateValue stateValue_0;

	private Weapon1Value weapon1Value_0;

	private Weapon2Value weapon2Value_0;

	private CamouflageTypeValue camouflageTypeValue_0;

	private ConcealedStationaryValue concealedStationaryValue_0;

	private ConcealedMovementValue concealedMovementValue_0;

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

	public HealthValue Health
	{
		get
		{
			return healthValue_0;
		}
		set
		{
			healthValue_0 = value;
		}
	}

	public ComplianceValue Compliance
	{
		get
		{
			return complianceValue_0;
		}
		set
		{
			complianceValue_0 = value;
		}
	}

	public FlashLightsValue FlashLights
	{
		get
		{
			return flashLightsValue_0;
		}
		set
		{
			flashLightsValue_0 = value;
		}
	}

	public LifeFormStateValue LifeFormState
	{
		get
		{
			return lifeFormStateValue_0;
		}
		set
		{
			lifeFormStateValue_0 = value;
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

	public Weapon1Value Weapon1
	{
		get
		{
			return weapon1Value_0;
		}
		set
		{
			weapon1Value_0 = value;
		}
	}

	public Weapon2Value Weapon2
	{
		get
		{
			return weapon2Value_0;
		}
		set
		{
			weapon2Value_0 = value;
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

	public ConcealedStationaryValue ConcealedStationary
	{
		get
		{
			return concealedStationaryValue_0;
		}
		set
		{
			concealedStationaryValue_0 = value;
		}
	}

	public ConcealedMovementValue ConcealedMovement
	{
		get
		{
			return concealedMovementValue_0;
		}
		set
		{
			concealedMovementValue_0 = value;
		}
	}

	public static bool operator !=(LifeFormAppearance left, LifeFormAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(LifeFormAppearance left, LifeFormAppearance right)
	{
		if ((object)left == (object)right)
		{
			return true;
		}
		int result;
		if ((object)left == null)
		{
			result = 0;
		}
		else
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static explicit operator uint(LifeFormAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator LifeFormAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static LifeFormAppearance FromByteArray(byte[] array, int index)
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

	public static LifeFormAppearance smethod_0(uint value)
	{
		LifeFormAppearance result = default(LifeFormAppearance);
		uint paintScheme = (value & 1) >> 0;
		result.PaintScheme = (PaintSchemeValue)paintScheme;
		uint health = (value & 0x18) >> 3;
		result.Health = (HealthValue)health;
		uint compliance = (value & 0x1E0) >> 5;
		result.Compliance = (ComplianceValue)compliance;
		uint flashLights = (value & 0x1000) >> 12;
		result.FlashLights = (FlashLightsValue)flashLights;
		uint lifeFormState = (value & 0xF0000) >> 16;
		result.LifeFormState = (LifeFormStateValue)lifeFormState;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
		uint state = (value & 0x800000) >> 23;
		result.State = (StateValue)state;
		uint weapon = (value & 0x3000000) >> 24;
		result.Weapon1 = (Weapon1Value)weapon;
		uint weapon2 = (value & 0xC000000) >> 26;
		result.Weapon2 = (Weapon2Value)weapon2;
		uint camouflageType = (value & 0x30000000) >> 28;
		result.CamouflageType = (CamouflageTypeValue)camouflageType;
		uint concealedStationary = (value & 0x40000000) >> 30;
		result.ConcealedStationary = (ConcealedStationaryValue)concealedStationary;
		uint concealedMovement = (value & 0x80000000u) >> 31;
		result.ConcealedMovement = (ConcealedMovementValue)concealedMovement;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is LifeFormAppearance))
			{
				return false;
			}
			return Equals((LifeFormAppearance)obj);
		}
		return false;
	}

	public bool Equals(LifeFormAppearance other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (PaintScheme == other.PaintScheme && Health == other.Health && Compliance == other.Compliance && FlashLights == other.FlashLights && LifeFormState == other.LifeFormState && FrozenStatus == other.FrozenStatus && State == other.State && Weapon1 == other.Weapon1 && Weapon2 == other.Weapon2 && CamouflageType == other.CamouflageType && ConcealedStationary == other.ConcealedStationary)
		{
			return ConcealedMovement == other.ConcealedMovement;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(PaintSchemeValue.UniformColor | PaintScheme) | ((uint)Health << 3) | ((uint)Compliance << 5) | ((uint)FlashLights << 12) | ((uint)LifeFormState << 16) | ((uint)FrozenStatus << 21) | ((uint)State << 23) | ((uint)Weapon1 << 24) | ((uint)Weapon2 << 26) | ((uint)CamouflageType << 28) | ((uint)ConcealedStationary << 30) | ((uint)ConcealedMovement << 31);
	}

	public override int GetHashCode()
	{
		return (((((((((((493 + PaintScheme.GetHashCode()) * 29 + Health.GetHashCode()) * 29 + Compliance.GetHashCode()) * 29 + FlashLights.GetHashCode()) * 29 + LifeFormState.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Weapon1.GetHashCode()) * 29 + Weapon2.GetHashCode()) * 29 + CamouflageType.GetHashCode()) * 29 + ConcealedStationary.GetHashCode()) * 29 + ConcealedMovement.GetHashCode();
	}

	static LifeFormAppearance()
	{
		Class72.smethod_20();
	}
}
