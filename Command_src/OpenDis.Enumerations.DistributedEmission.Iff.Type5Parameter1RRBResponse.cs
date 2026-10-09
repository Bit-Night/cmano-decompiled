using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type5Parameter1RRBResponse
{
	[Description("Power Reduction")]
	public enum PowerReductionValue : uint
	{
		Off,
		On
	}

	[Description("Radar Enhancement")]
	public enum RadarEnhancementValue : uint
	{
		Off,
		On
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

	private byte byte_0;

	private PowerReductionValue powerReductionValue_0;

	private RadarEnhancementValue radarEnhancementValue_0;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public byte Code
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public PowerReductionValue PowerReduction
	{
		get
		{
			return powerReductionValue_0;
		}
		set
		{
			powerReductionValue_0 = value;
		}
	}

	public RadarEnhancementValue RadarEnhancement
	{
		get
		{
			return radarEnhancementValue_0;
		}
		set
		{
			radarEnhancementValue_0 = value;
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

	public static bool operator !=(Type5Parameter1RRBResponse left, Type5Parameter1RRBResponse right)
	{
		return !(left == right);
	}

	public static bool operator ==(Type5Parameter1RRBResponse left, Type5Parameter1RRBResponse right)
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

	public static explicit operator ushort(Type5Parameter1RRBResponse obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator Type5Parameter1RRBResponse(ushort value)
	{
		return smethod_0(value);
	}

	public static Type5Parameter1RRBResponse FromByteArray(byte[] array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0 || index > array.Length - 1 || index + 2 > array.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(array, index));
	}

	public static Type5Parameter1RRBResponse smethod_0(ushort value)
	{
		Type5Parameter1RRBResponse result = default(Type5Parameter1RRBResponse);
		uint num = (uint)(value & 0x1F) >> 0;
		result.Code = (byte)num;
		uint powerReduction = (uint)(value & 0x800) >> 11;
		result.PowerReduction = (PowerReductionValue)powerReduction;
		uint radarEnhancement = (uint)(value & 0x1000) >> 12;
		result.RadarEnhancement = (RadarEnhancementValue)radarEnhancement;
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
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Type5Parameter1RRBResponse))
		{
			return false;
		}
		return Equals((Type5Parameter1RRBResponse)obj);
	}

	public bool Equals(Type5Parameter1RRBResponse other)
	{
		if ((object)other != null)
		{
			if (Code == other.Code && PowerReduction == other.PowerReduction && RadarEnhancement == other.RadarEnhancement && Status == other.Status && Damage == other.Damage)
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
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0 | Code) | (ushort)((uint)PowerReduction << 11)) | (ushort)((uint)RadarEnhancement << 12)) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return (((((493 + Code.GetHashCode()) * 29 + PowerReduction.GetHashCode()) * 29 + RadarEnhancement.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}

	static Type5Parameter1RRBResponse()
	{
		Class72.smethod_20();
	}
}
