using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct Fusing
{
	[Description("Identifies the type of the primary fuse")]
	public enum PrimaryValue : uint
	{
		NoFuse,
		Other,
		Pressure,
		Magnetic,
		TiltRod,
		Command,
		TripWire
	}

	[Description("Identifies the type of the secondary fuse")]
	public enum SecondaryValue : uint
	{
		NoFuse,
		Other,
		Pressure,
		Magnetic,
		TiltRod,
		Command,
		TripWire
	}

	[Description("Describes the anti-handling device status of the mine")]
	public enum AHDValue : uint
	{
		NoAntiHandlingDevice,
		AntiHandlingDevice
	}

	private PrimaryValue primaryValue_0;

	private SecondaryValue secondaryValue_0;

	private AHDValue ahdvalue_0;

	public PrimaryValue Primary
	{
		get
		{
			return primaryValue_0;
		}
		set
		{
			primaryValue_0 = value;
		}
	}

	public SecondaryValue Secondary
	{
		get
		{
			return secondaryValue_0;
		}
		set
		{
			secondaryValue_0 = value;
		}
	}

	public AHDValue AHD
	{
		get
		{
			return ahdvalue_0;
		}
		set
		{
			ahdvalue_0 = value;
		}
	}

	public static bool operator !=(Fusing left, Fusing right)
	{
		return !(left == right);
	}

	public static bool operator ==(Fusing left, Fusing right)
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

	public static explicit operator ushort(Fusing obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator Fusing(ushort value)
	{
		return smethod_0(value);
	}

	public static Fusing FromByteArray(byte[] array, int index)
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

	public static Fusing smethod_0(ushort value)
	{
		Fusing result = default(Fusing);
		uint primary = (uint)(value & 0x7F) >> 0;
		result.Primary = (PrimaryValue)primary;
		uint secondary = (uint)(value & 0x3F80) >> 7;
		result.Secondary = (SecondaryValue)secondary;
		uint aHD = (uint)(value & 0x10) >> 4;
		result.AHD = (AHDValue)aHD;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is Fusing))
			{
				return false;
			}
			return Equals((Fusing)obj);
		}
		return false;
	}

	public bool Equals(Fusing other)
	{
		if ((object)other != null)
		{
			if (Primary == other.Primary && Secondary == other.Secondary)
			{
				return AHD == other.AHD;
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
		return (ushort)((ushort)((ushort)(0 | (ushort)Primary) | (ushort)((uint)Secondary << 7)) | (ushort)((uint)AHD << 4));
	}

	public override int GetHashCode()
	{
		return ((493 + Primary.GetHashCode()) * 29 + Secondary.GetHashCode()) * 29 + AHD.GetHashCode();
	}

	static Fusing()
	{
		Class72.smethod_20();
	}
}
