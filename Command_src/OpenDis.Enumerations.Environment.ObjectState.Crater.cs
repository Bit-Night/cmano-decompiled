using System;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct Crater
{
	private byte byte_0;

	public byte Size
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

	public static bool operator !=(Crater left, Crater right)
	{
		return !(left == right);
	}

	public static bool operator ==(Crater left, Crater right)
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

	public static explicit operator uint(Crater obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator Crater(uint value)
	{
		return smethod_0(value);
	}

	public static Crater FromByteArray(byte[] array, int index)
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

	public static Crater smethod_0(uint value)
	{
		Crater result = default(Crater);
		uint num = (value & 0xFF0000) >> 16;
		result.Size = (byte)num;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is Crater)
		{
			return Equals((Crater)obj);
		}
		return false;
	}

	public bool Equals(Crater other)
	{
		if ((object)other == null)
		{
			return false;
		}
		return Size == other.Size;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(0 | (Size << 16));
	}

	public override int GetHashCode()
	{
		return 493 + Size.GetHashCode();
	}

	static Crater()
	{
		Class72.smethod_20();
	}
}
