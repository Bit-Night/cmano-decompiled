using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct Minefield
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

	private int int_0;

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

	public int MineCount
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public static bool operator !=(Minefield left, Minefield right)
	{
		return !(left == right);
	}

	public static bool operator ==(Minefield left, Minefield right)
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

	public static explicit operator uint(Minefield obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator Minefield(uint value)
	{
		return smethod_0(value);
	}

	public static Minefield FromByteArray(byte[] array, int index)
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

	public static Minefield smethod_0(uint value)
	{
		Minefield result = default(Minefield);
		uint breach = (value & 0x30000) >> 16;
		result.Breach = (BreachValue)breach;
		uint mineCount = (value & 0x80000000u) >> 31;
		result.MineCount = (int)mineCount;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Minefield))
		{
			return false;
		}
		return Equals((Minefield)obj);
	}

	public bool Equals(Minefield other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (Breach == other.Breach)
		{
			return MineCount == other.MineCount;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0 | ((uint)Breach << 16) | (uint)(MineCount << 31);
	}

	public override int GetHashCode()
	{
		return (493 + Breach.GetHashCode()) * 29 + MineCount.GetHashCode();
	}

	static Minefield()
	{
		Class72.smethod_20();
	}
}
