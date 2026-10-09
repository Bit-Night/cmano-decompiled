using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.EntityState.Appearance;

[Serializable]
public struct EnvironmentalAppearance
{
	[Description("Describes the density of the environmentals")]
	public enum DensityValue : uint
	{
		Clear,
		Hazy,
		Dense,
		VeryDense,
		Opaque,
		Unknown
	}

	[Description("Describes the frozen status of a environmental object")]
	public enum FrozenStatusValue : uint
	{
		NotFrozen,
		FrozenFrozenEntitiesShouldNotBeDeadReckonedIETheyShouldBeDisplayedAsFixedAtTheCurrentLocationEvenIfNonzeroVelocityAccelerationOrRotationDataIsReceivedFromTheFrozenEntity
	}

	[Description("Describes the state of a environmental object")]
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

	private DensityValue densityValue_0;

	private FrozenStatusValue frozenStatusValue_0;

	private StateValue stateValue_0;

	private MaskedCloakedValue maskedCloakedValue_0;

	public DensityValue Density
	{
		get
		{
			return densityValue_0;
		}
		set
		{
			densityValue_0 = value;
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

	public static bool operator !=(EnvironmentalAppearance left, EnvironmentalAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(EnvironmentalAppearance left, EnvironmentalAppearance right)
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

	public static explicit operator uint(EnvironmentalAppearance obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator EnvironmentalAppearance(uint value)
	{
		return smethod_0(value);
	}

	public static EnvironmentalAppearance FromByteArray(byte[] array, int index)
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

	public static EnvironmentalAppearance smethod_0(uint value)
	{
		EnvironmentalAppearance result = default(EnvironmentalAppearance);
		uint density = (value & 0xF0000) >> 16;
		result.Density = (DensityValue)density;
		uint frozenStatus = (value & 0x200000) >> 21;
		result.FrozenStatus = (FrozenStatusValue)frozenStatus;
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
		if (obj is EnvironmentalAppearance)
		{
			return Equals((EnvironmentalAppearance)obj);
		}
		return false;
	}

	public bool Equals(EnvironmentalAppearance other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (Density == other.Density && FrozenStatus == other.FrozenStatus && State == other.State)
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
		return 0 | ((uint)Density << 16) | ((uint)FrozenStatus << 21) | ((uint)State << 23) | ((uint)MaskedCloaked << 31);
	}

	public override int GetHashCode()
	{
		return (((493 + Density.GetHashCode()) * 29 + FrozenStatus.GetHashCode()) * 29 + State.GetHashCode()) * 29 + MaskedCloaked.GetHashCode();
	}

	static EnvironmentalAppearance()
	{
		Class72.smethod_20();
	}
}
