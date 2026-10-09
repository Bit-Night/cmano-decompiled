using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.Iff;

[Serializable]
public struct Type1Parameter4Mode4CodeStatus
{
	[Description("Code element 1")]
	public enum CodeElement1Value : uint
	{
		PseudoCryptoValue = 0u,
		NoPseudoCryptoValueUseAlternateMode4Value = 4095u
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

	private CodeElement1Value codeElement1Value_0;

	private StatusValue statusValue_0;

	private DamageValue damageValue_0;

	private MalfunctionValue malfunctionValue_0;

	public CodeElement1Value CodeElement1
	{
		get
		{
			return codeElement1Value_0;
		}
		set
		{
			codeElement1Value_0 = value;
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

	public static bool operator !=(Type1Parameter4Mode4CodeStatus left, Type1Parameter4Mode4CodeStatus right)
	{
		return !(left == right);
	}

	public static bool operator ==(Type1Parameter4Mode4CodeStatus left, Type1Parameter4Mode4CodeStatus right)
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

	public static explicit operator ushort(Type1Parameter4Mode4CodeStatus obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator Type1Parameter4Mode4CodeStatus(ushort value)
	{
		return smethod_0(value);
	}

	public static Type1Parameter4Mode4CodeStatus FromByteArray(byte[] array, int index)
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

	public static Type1Parameter4Mode4CodeStatus smethod_0(ushort value)
	{
		Type1Parameter4Mode4CodeStatus result = default(Type1Parameter4Mode4CodeStatus);
		uint codeElement = (uint)(value & 0xFFF) >> 0;
		result.CodeElement1 = (CodeElement1Value)codeElement;
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
			if (!(obj is Type1Parameter4Mode4CodeStatus))
			{
				return false;
			}
			return Equals((Type1Parameter4Mode4CodeStatus)obj);
		}
		return false;
	}

	public bool Equals(Type1Parameter4Mode4CodeStatus other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (CodeElement1 == other.CodeElement1 && Status == other.Status && Damage == other.Damage)
		{
			return Malfunction == other.Malfunction;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)(0 | (ushort)CodeElement1) | (ushort)((uint)Status << 13)) | (ushort)((uint)Damage << 14)) | (ushort)((uint)Malfunction << 15));
	}

	public override int GetHashCode()
	{
		return (((493 + CodeElement1.GetHashCode()) * 29 + Status.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Malfunction.GetHashCode();
	}

	static Type1Parameter4Mode4CodeStatus()
	{
		Class72.smethod_20();
	}
}
