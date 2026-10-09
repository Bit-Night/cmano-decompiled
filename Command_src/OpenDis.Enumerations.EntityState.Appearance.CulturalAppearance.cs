using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct CulturalAppearance
{
	[Description("Describes the damaged appearance of an entity")]
	public enum DamageValue : uint
	{
		NoDamage,
		SlightDamage,
		ModerateDamage,
		Destroyed
	}

	[Description("Describes status of smoke emanating from a Cultural Features object")]
	public enum SmokeValue : uint
	{
		NotSmoking,
		SmokePlumeRisingFromTheEntity,
		Unknown
	}

	[Description("Describes whether flames are rising from a Cultural Features object")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	[Description("Describes the frozen status of a Cultural Features object")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIEShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonZeroVelocityAccelerationOrRotationDataReceivedFromTheFrozenEntity
	}

	[Description("Describes the Internal-Heat status")]
	public enum InternalHeatStatusValue : uint
	{
		InternalHeatOff,
		InternalHeatOn
	}

	[Description("Describes the state of a Cultural object")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether Exterior Lights are on or off.")]
	public enum ExteriorLightsValue : uint
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

	[Description("Describes if the entity is Masked / Cloaked or Not")]
	public enum MaskedCloakedValue : uint
	{
		NotMaskedNotCloaked,
		MaskedCloaked
	}

	private DamageValue damageValue_0;

	private SmokeValue smokeValue_0;

	private FlamingValue flamingValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private InternalHeatStatusValue internalHeatStatusValue_0;

	private StateValue stateValue_0;

	private ExteriorLightsValue exteriorLightsValue_0;

	private InteriorLightsValue interiorLightsValue_0;

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

	public InternalHeatStatusValue InternalHeatStatus
	{
		get
		{
			return internalHeatStatusValue_0;
		}
		set
		{
			internalHeatStatusValue_0 = value;
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

	public ExteriorLightsValue ExteriorLights
	{
		get
		{
			return exteriorLightsValue_0;
		}
		set
		{
			exteriorLightsValue_0 = value;
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

	public static bool operator !=(CulturalAppearance left, CulturalAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(CulturalAppearance left, CulturalAppearance right)
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

	public static explicit operator uint(CulturalAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator CulturalAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static CulturalAppearance FromByteArray(byte[] array, int index)
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

	public static CulturalAppearance smethod_0(uint value)
	{
		CulturalAppearance result = default(CulturalAppearance);
		uint damage = (value & 0x18) >> 3;
		result.Damage = (DamageValue)damage;
		uint smoke = (value & 0x60) >> 5;
		result.Smoke = (SmokeValue)smoke;
		uint flaming = (value & 0x8000) >> 15;
		result.Flaming = (FlamingValue)flaming;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
		uint internalHeatStatus = (value & 0x400000) >> 22;
		result.InternalHeatStatus = (InternalHeatStatusValue)internalHeatStatus;
		uint state = (value & 0x800000) >> 23;
		result.State = (StateValue)state;
		uint exteriorLights = (value & 0x10000000) >> 28;
		result.ExteriorLights = (ExteriorLightsValue)exteriorLights;
		uint interiorLights = (value & 0x20000000) >> 29;
		result.InteriorLights = (InteriorLightsValue)interiorLights;
		uint maskedCloaked = (value & 0x80000000u) >> 31;
		result.MaskedCloaked = (MaskedCloakedValue)maskedCloaked;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (obj is CulturalAppearance)
			{
				return Equals((CulturalAppearance)obj);
			}
			return false;
		}
		return false;
	}

	public bool Equals(CulturalAppearance other)
	{
		if ((object)other != null)
		{
			if (Damage == other.Damage && Smoke == other.Smoke && Flaming == other.Flaming && FrozenStatus == other.FrozenStatus && InternalHeatStatus == other.InternalHeatStatus && State == other.State && ExteriorLights == other.ExteriorLights && InteriorLights == other.InteriorLights)
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
		return 0 | ((uint)Damage << 3) | ((uint)Smoke << 5) | ((uint)Flaming << 15) | ((uint)FrozenStatus << 21) | ((uint)InternalHeatStatus << 22) | ((uint)State << 23) | ((uint)ExteriorLights << 28) | ((uint)InteriorLights << 29) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return ((((((((493 + Damage.GetHashCode()) * 29 + Smoke.GetHashCode()) * 29 + Flaming.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + InternalHeatStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + ExteriorLights.GetHashCode()) * 29 + InteriorLights.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}

	static CulturalAppearance()
	{
		Class72.smethod_20();
	}
}
