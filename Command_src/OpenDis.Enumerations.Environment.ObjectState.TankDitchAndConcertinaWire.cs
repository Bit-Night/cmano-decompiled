using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct TankDitchAndConcertinaWire
{
	[Description("Describes the breached appearance of the object")]
	public enum BreachValue : uint
	{
		NoBreaching,
		SlightBreaching,
		ModerateBreached,
		Cleared
	}

	[Description("Each bit indicates whether its associated segment is breached or not. Bit 40+i indicates whether the portion of the segment beginning at the segment origin + (i*Breach Length) and extending i* Breach Length meters is breached or not. For each bit:")]
	public enum BreachLocationValue : uint
	{
		AssociatedPortionOfSegmentIsNotBreached,
		AssociatedPortionOfSegmentIsBreached
	}

	private BreachValue breachValue_0;

	private byte byte_0;

	private BreachLocationValue breachLocationValue_0;

	public BreachValue Breach
	{
		get
		{
			return breachValue_0;
		}
		set
		{
			breachValue_0 = value;
		}
	}

	public byte BreachLength
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

	public BreachLocationValue BreachLocation
	{
		get
		{
			return breachLocationValue_0;
		}
		set
		{
			breachLocationValue_0 = value;
		}
	}

	public static bool operator !=(TankDitchAndConcertinaWire left, TankDitchAndConcertinaWire right)
	{
		return !(left == right);
	}

	public static bool operator ==(TankDitchAndConcertinaWire left, TankDitchAndConcertinaWire right)
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

	public static explicit operator uint(TankDitchAndConcertinaWire obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator TankDitchAndConcertinaWire(uint value)
	{
		return smethod_0(value);
	}

	public static TankDitchAndConcertinaWire FromByteArray(byte[] array, int index)
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

	public static TankDitchAndConcertinaWire smethod_0(uint value)
	{
		TankDitchAndConcertinaWire result = default(TankDitchAndConcertinaWire);
		uint breach = (value & 0x30000) >> 16;
		result.Breach = (BreachValue)breach;
		uint num = (value & 0xFF) >> 0;
		result.BreachLength = (byte)num;
		uint breachLocation = (value & 0xFF00) >> 8;
		result.BreachLocation = (BreachLocationValue)breachLocation;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (obj is TankDitchAndConcertinaWire)
			{
				return Equals((TankDitchAndConcertinaWire)obj);
			}
			return false;
		}
		return false;
	}

	public bool Equals(TankDitchAndConcertinaWire other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (Breach == other.Breach && BreachLength == other.BreachLength)
		{
			return BreachLocation == other.BreachLocation;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0 | ((uint)Breach << 16) | BreachLength | ((uint)BreachLocation << 8);
	}

	public override int GetHashCode()
	{
		return ((493 + Breach.GetHashCode()) * 29 + BreachLength.GetHashCode()) * 29 + BreachLocation.GetHashCode();
	}

	static TankDitchAndConcertinaWire()
	{
		Class72.smethod_20();
	}
}
