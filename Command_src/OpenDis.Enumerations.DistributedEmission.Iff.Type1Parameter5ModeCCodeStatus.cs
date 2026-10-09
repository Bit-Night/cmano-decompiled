using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type1Parameter5ModeCCodeStatus
{
	[Description("Negative Altitude")]
	public enum NegativeAltitudeValue : uint
	{
		PositiveAltitudeAboveMeanSeaLevelIndicatorIfModeCAltitudeIsContainedInBits111,
		NegativeAltitudeBelowMeanSeaLevelIndicatorIfModeCAltitudeIsContainedInBits111OrAlternateMode5IfAltitudeBits1112047
	}

	[Description("Mode C altitude")]
	public enum GEnum3 : uint
	{
		ActualModeCAltitudeInTheRange0126000FeetIn100FootIncrementsBit0NegativePositiveIndicatorMustBeSetAppropriately = 0u,
		NotActualModeCAltitudeValueUseAlternateMode5Bits0114095IEAll1S = 2047u
	}

	[Description("Status")]
	public enum StatusValue : uint
	{
		Off,
		On
	}

	[Description("Damage")]
	public enum DamageValue : uint
	{
		NoDamage,
		Damage
	}

	[Description("Malfunction")]
	public enum MalfunctionValue : uint
	{
		NoMalfunction,
		Malfunction
	}

	private NegativeAltitudeValue negativeAltitudeValue_0;

	private GEnum3 genum3_0;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public NegativeAltitudeValue NegativeAltitude
	{
		get
		{
			return negativeAltitudeValue_0;
		}
		set
		{
			negativeAltitudeValue_0 = value;
		}
	}

	public GEnum3 ModeCAltitude
	{
		get
		{
			return genum3_0;
		}
		set
		{
			genum3_0 = value;
		}
	}

	public StatusValue Status
	{
		get
		{
			return statusValue_0;
		}
		set
		{
			statusValue_0 = value;
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

	public MalfunctionValue Malfunction
	{
		get
		{
			return malfunctionValue_0;
		}
		set
		{
			malfunctionValue_0 = value;
		}
	}

	public static bool operator !=(Type1Parameter5ModeCCodeStatus left, Type1Parameter5ModeCCodeStatus right)
	{
		return !(left == right);
	}

	public static bool operator ==(Type1Parameter5ModeCCodeStatus left, Type1Parameter5ModeCCodeStatus right)
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

	public static explicit operator ushort(Type1Parameter5ModeCCodeStatus obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator Type1Parameter5ModeCCodeStatus(ushort value)
	{
		return smethod_0(value);
	}

	public static Type1Parameter5ModeCCodeStatus FromByteArray(byte[] array, int index)
	{
		if (array != null)
		{
			if (index < 0 || index > array.Length - 1 || index + 2 > array.Length - 1)
			{
				throw new IndexOutOfRangeException();
			}
			return smethod_0(BitConverter.ToUInt16(array, index));
		}
		throw new ArgumentNullException("array");
	}

	public static Type1Parameter5ModeCCodeStatus smethod_0(ushort value)
	{
		Type1Parameter5ModeCCodeStatus result = default(Type1Parameter5ModeCCodeStatus);
		uint negativeAltitude = (uint)(value & 1) >> 0;
		result.NegativeAltitude = (NegativeAltitudeValue)negativeAltitude;
		uint modeCAltitude = (uint)(value & 0xFFE) >> 1;
		result.ModeCAltitude = (GEnum3)modeCAltitude;
		uint status = (uint)(value & 0x2000) >> 13;
		result.Status = (StatusValue)status;
		uint damage = (uint)(value & 0x4000) >> 14;
		result.Damage = (DamageValue)damage;
		uint malfunction = (uint)(value & 0x8000) >> 15;
		result.Malfunction = (MalfunctionValue)malfunction;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is Type1Parameter5ModeCCodeStatus))
			{
				return false;
			}
			return Equals((Type1Parameter5ModeCCodeStatus)obj);
		}
		return false;
	}

	public bool Equals(Type1Parameter5ModeCCodeStatus other)
	{
		if ((object)other != null)
		{
			if (NegativeAltitude == other.NegativeAltitude && ModeCAltitude == other.ModeCAltitude && Status == other.Status && Damage == other.Damage)
			{
				return Malfunction == other.Malfunction;
			}
			return false;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)(0 | (ushort)NegativeAltitude) | (ushort)((uint)ModeCAltitude << 1)) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return ((((493 + NegativeAltitude.GetHashCode()) * 29 + ModeCAltitude.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}

	static Type1Parameter5ModeCCodeStatus()
	{
		Class72.smethod_20();
	}
}
