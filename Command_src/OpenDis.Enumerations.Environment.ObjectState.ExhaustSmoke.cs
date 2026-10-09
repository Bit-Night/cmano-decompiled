using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct ExhaustSmoke
{
	[Description("Describes whether the smoke is attached to the vehicle")]
	public enum AttachedValue : uint
	{
		NotAttached,
		Attached
	}

	[Description("Describes the chemical content of the smoke")]
	public enum ChemicalValue : uint
	{
		Other,
		Hydrochloric,
		WhitePhosphorous,
		RedPhosphorous
	}

	private byte byte_0;

	private AttachedValue attachedValue_0;

	private ChemicalValue chemicalValue_0;

	public byte Opacity
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

	public AttachedValue Attached
	{
		get
		{
			return attachedValue_0;
		}
		set
		{
			attachedValue_0 = value;
		}
	}

	public ChemicalValue Chemical
	{
		get
		{
			return chemicalValue_0;
		}
		set
		{
			chemicalValue_0 = value;
		}
	}

	public static bool operator !=(ExhaustSmoke left, ExhaustSmoke right)
	{
		return !(left == right);
	}

	public static bool operator ==(ExhaustSmoke left, ExhaustSmoke right)
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

	public static explicit operator uint(ExhaustSmoke obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator ExhaustSmoke(uint value)
	{
		return smethod_0(value);
	}

	public static ExhaustSmoke FromByteArray(byte[] array, int index)
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

	public static ExhaustSmoke smethod_0(uint value)
	{
		ExhaustSmoke result = default(ExhaustSmoke);
		uint num = (value & 0xFF0000) >> 16;
		result.Opacity = (byte)num;
		uint attached = (value & 0x1000000) >> 24;
		result.Attached = (AttachedValue)attached;
		uint chemical = (value & 0x6000000) >> 25;
		result.Chemical = (ChemicalValue)chemical;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (obj is ExhaustSmoke)
			{
				return Equals((ExhaustSmoke)obj);
			}
			return false;
		}
		return false;
	}

	public bool Equals(ExhaustSmoke other)
	{
		if ((object)other != null)
		{
			if (Opacity == other.Opacity && Attached == other.Attached)
			{
				return Chemical == other.Chemical;
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
		return (uint)(0 | (Opacity << 16)) | ((uint)Attached << 24) | ((uint)Chemical << 25);
	}

	public override int GetHashCode()
	{
		return ((493 + Opacity.GetHashCode()) * 29 + Attached.GetHashCode()) * 29 + Chemical.GetHashCode();
	}

	static ExhaustSmoke()
	{
		Class72.smethod_20();
	}
}
