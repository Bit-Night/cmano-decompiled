using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct LogCribAbatisVehicleDefiladeAndInfantryFightingPosition
{
	[Description("Describes the breached appearance of the object")]
	public enum BreachValue : uint
	{
		NoBreaching,
		Breached,
		Cleared,
		Unknown
	}

	private BreachValue breachValue_0;

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

	public static bool operator !=(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition left, LogCribAbatisVehicleDefiladeAndInfantryFightingPosition right)
	{
		return !(left == right);
	}

	public static bool operator ==(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition left, LogCribAbatisVehicleDefiladeAndInfantryFightingPosition right)
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

	public static explicit operator uint(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator LogCribAbatisVehicleDefiladeAndInfantryFightingPosition(uint value)
	{
		return smethod_0(value);
	}

	public static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition FromByteArray(byte[] array, int index)
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

	public static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition smethod_0(uint value)
	{
		LogCribAbatisVehicleDefiladeAndInfantryFightingPosition result = default(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition);
		uint breach = (value & 0x30000) >> 16;
		result.Breach = (BreachValue)breach;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is LogCribAbatisVehicleDefiladeAndInfantryFightingPosition))
			{
				return false;
			}
			return Equals((LogCribAbatisVehicleDefiladeAndInfantryFightingPosition)obj);
		}
		return false;
	}

	public bool Equals(LogCribAbatisVehicleDefiladeAndInfantryFightingPosition other)
	{
		if ((object)other != null)
		{
			return Breach == other.Breach;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0 | ((uint)Breach << 16);
	}

	public override int GetHashCode()
	{
		return 493 + Breach.GetHashCode();
	}

	static LogCribAbatisVehicleDefiladeAndInfantryFightingPosition()
	{
		Class72.smethod_20();
	}
}
