using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct AirBurstAndGroundBurst
{
	[Description("Describes the chemical content of the smoke")]
	public enum ChemicalValue : uint
	{
		Other,
		Hydrochloric,
		WhitePhosphorous,
		RedPhosphorous
	}

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

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

	public byte Size
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public byte Height
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public byte NumOfBursts
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
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

	public static bool operator !=(AirBurstAndGroundBurst left, AirBurstAndGroundBurst right)
	{
		return !(left == right);
	}

	public static bool operator ==(AirBurstAndGroundBurst left, AirBurstAndGroundBurst right)
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

	public static explicit operator uint(AirBurstAndGroundBurst obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator AirBurstAndGroundBurst(uint value)
	{
		return smethod_0(value);
	}

	public static AirBurstAndGroundBurst FromByteArray(byte[] array, int index)
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

	public static AirBurstAndGroundBurst smethod_0(uint value)
	{
		AirBurstAndGroundBurst result = default(AirBurstAndGroundBurst);
		uint num = (value & 0xFF0000) >> 16;
		result.Opacity = (byte)num;
		uint num2 = (value & 0xFF000000u) >> 24;
		result.Size = (byte)num2;
		uint num3 = (value & 0xFF) >> 0;
		result.Height = (byte)num3;
		uint num4 = (value & 0x3F00) >> 8;
		result.NumOfBursts = (byte)num4;
		uint chemical = (value & 0xC000) >> 14;
		result.Chemical = (ChemicalValue)chemical;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is AirBurstAndGroundBurst)
		{
			return Equals((AirBurstAndGroundBurst)obj);
		}
		return false;
	}

	public bool Equals(AirBurstAndGroundBurst other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (Opacity == other.Opacity && Size == other.Size && Height == other.Height && NumOfBursts == other.NumOfBursts)
		{
			return Chemical == other.Chemical;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(0 | (Opacity << 16) | (Size << 24) | Height | (NumOfBursts << 8)) | ((uint)Chemical << 14);
	}

	public override int GetHashCode()
	{
		return ((((493 + Opacity.GetHashCode()) * 29 + Size.GetHashCode()) * 29 + Height.GetHashCode()) * 29 + NumOfBursts.GetHashCode()) * 29 + Chemical.GetHashCode();
	}

	static AirBurstAndGroundBurst()
	{
		Class72.smethod_20();
	}
}
