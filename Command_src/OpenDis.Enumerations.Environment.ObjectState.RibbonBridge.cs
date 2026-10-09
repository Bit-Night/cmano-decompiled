using System;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct RibbonBridge
{
	private byte byte_0;

	public byte NumOfSegments
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

	public static bool operator !=(RibbonBridge left, RibbonBridge right)
	{
		return !(left == right);
	}

	public static bool operator ==(RibbonBridge left, RibbonBridge right)
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

	public static explicit operator uint(RibbonBridge obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator RibbonBridge(uint value)
	{
		return smethod_0(value);
	}

	public static RibbonBridge FromByteArray(byte[] array, int index)
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

	public static RibbonBridge smethod_0(uint value)
	{
		RibbonBridge result = default(RibbonBridge);
		uint num = (value & 0xFF0000) >> 16;
		result.NumOfSegments = (byte)num;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (obj is RibbonBridge)
			{
				return Equals((RibbonBridge)obj);
			}
			return false;
		}
		return false;
	}

	public bool Equals(RibbonBridge other)
	{
		if ((object)other == null)
		{
			return false;
		}
		return NumOfSegments == other.NumOfSegments;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(0 | (NumOfSegments << 16));
	}

	public override int GetHashCode()
	{
		return 493 + NumOfSegments.GetHashCode();
	}

	static RibbonBridge()
	{
		Class72.smethod_20();
	}
}
