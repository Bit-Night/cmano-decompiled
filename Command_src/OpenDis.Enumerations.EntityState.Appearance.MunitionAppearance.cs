using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct MunitionAppearance
{
	[Description("Describes the damaged appearance of an entity")]
	public enum DamageValue : uint
	{
		NoDamage,
		SlightDamage,
		ModerateDamage,
		Destroyed
	}

	[Description("Describes status or location of smoke and vapor emanating from an entity")]
	public enum SmokeValue : uint
	{
		NotSmoking,
		SmokeOrVaporIsEmanatingFromTheEntity,
		EntityIsEmittingMotorSmoke,
		EntityIsEmittingMotorSmokeAndSmokeOrVaporIsEmanatingFromTheEntity
	}

	[Description("Describes the size of the vapor trail trailing effect for the effectsentity")]
	public enum TrailingEffectsValue : uint
	{
		None,
		Small,
		Medium,
		Large
	}

	[Description("Describes whether flames are rising from an entity")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the presence of a guided munition's launch flash")]
	public enum LaunchFlashValue : uint
	{
		NoLaunchFlashPresent,
		LaunchFlashPresent
	}

	[Description("Describes the frozen status of a guided munition")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the power-plant status of a guided munition")]
	public enum PowerPlantStatusValue : uint
	{
		PowerPlantOff,
		PowerPlantOn
	}

	[Description("Describes the state of a guided munition")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes if the entity is Masked / Cloaked or Not")]
	public enum MaskedCloakedValue : uint
	{
		NotMaskedNotCloaked,
		MaskedCloaked
	}

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private TrailingEffectsValue trailingEffectsValue_0;

	private FlamingValue flamingValue_0;

	private LaunchFlashValue launchFlashValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private PowerPlantStatusValue powerPlantStatusValue_0;

	private StateValue stateValue_0;

	private MaskedCloakedValue maskedCloakedValue_0;

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

	public LaunchFlashValue LaunchFlash
	{
		get
		{
			return launchFlashValue_0;
		}
		set
		{
			launchFlashValue_0 = value;
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

	public static bool operator !=(MunitionAppearance left, MunitionAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(MunitionAppearance left, MunitionAppearance right)
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

	public static explicit operator uint(MunitionAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator MunitionAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static MunitionAppearance FromByteArray(byte[] array, int index)
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

	public static MunitionAppearance smethod_0(uint value)
	{
		MunitionAppearance result = default(MunitionAppearance);
		uint damage = (value & 0x18) >> 3;
		result.Damage = (DamageValue)damage;
		uint smoke = (value & 0x60) >> 5;
		result.Smoke = (SmokeValue)smoke;
		uint trailingEffects = (value & 0x180) >> 7;
		result.TrailingEffects = (TrailingEffectsValue)trailingEffects;
		uint flaming = (value & 0x8000) >> 15;
		result.Flaming = (FlamingValue)flaming;
		uint launchFlash = (value & 0x10000) >> 16;
		result.LaunchFlash = (LaunchFlashValue)launchFlash;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
		uint powerPlantStatus = (value & 0x400000) >> 22;
		result.PowerPlantStatus = (PowerPlantStatusValue)powerPlantStatus;
		uint state = (value & 0x800000) >> 23;
		result.State = (StateValue)state;
		uint maskedCloaked = (value & 0x80000000u) >> 31;
		result.MaskedCloaked = (MaskedCloakedValue)maskedCloaked;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is MunitionAppearance)
		{
			return Equals((MunitionAppearance)obj);
		}
		return false;
	}

	public bool Equals(MunitionAppearance other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (Damage == other.Damage && Smoke == other.Smoke && TrailingEffects == other.TrailingEffects && Flaming == other.Flaming && LaunchFlash == other.LaunchFlash && FrozenStatus == other.FrozenStatus && PowerPlantStatus == other.PowerPlantStatus && State == other.State)
		{
			return MaskedCloaked == other.MaskedCloaked;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0 | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)TrailingEffects << 7) | ((uint)Flaming << 15) | ((uint)LaunchFlash << 16) | ((uint)FrozenStatus << 21) | ((uint)PowerPlantStatus << 22) | ((uint)State << 23) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return ((((((((493 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + TrailingEffects.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + LaunchFlash.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + PowerPlantStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}

	static MunitionAppearance()
	{
		Class72.smethod_20();
	}
}
