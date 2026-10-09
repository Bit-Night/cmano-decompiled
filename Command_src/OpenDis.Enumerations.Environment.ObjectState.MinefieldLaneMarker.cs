using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct MinefieldLaneMarker
{
	[Description("Describes the side of the lane marker which is visible.")]
	public enum VisibleSideValue : uint
	{
		LeftSideIsVisible,
		RightSideIsVisible,
		BothSidesAreVisible,
		Unknown
	}

	private VisibleSideValue visibleSideValue_0;

	public VisibleSideValue VisibleSide
	{
		get
		{
			return visibleSideValue_0;
		}
		set
		{
			visibleSideValue_0 = value;
		}
	}

	public static bool operator !=(MinefieldLaneMarker left, MinefieldLaneMarker right)
	{
		return !(left == right);
	}

	public static bool operator ==(MinefieldLaneMarker left, MinefieldLaneMarker right)
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

	public static explicit operator uint(MinefieldLaneMarker obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator MinefieldLaneMarker(uint value)
	{
		return smethod_0(value);
	}

	public static MinefieldLaneMarker FromByteArray(byte[] array, int index)
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

	public static MinefieldLaneMarker smethod_0(uint value)
	{
		MinefieldLaneMarker result = default(MinefieldLaneMarker);
		uint visibleSide = (value & 0x30000) >> 16;
		result.VisibleSide = (VisibleSideValue)visibleSide;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (obj is MinefieldLaneMarker)
			{
				return Equals((MinefieldLaneMarker)obj);
			}
			return false;
		}
		return false;
	}

	public bool Equals(MinefieldLaneMarker other)
	{
		if ((object)other != null)
		{
			return VisibleSide == other.VisibleSide;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return 0 | ((uint)VisibleSide << 16);
	}

	public override int GetHashCode()
	{
		return 493 + VisibleSide.GetHashCode();
	}

	static MinefieldLaneMarker()
	{
		Class72.smethod_20();
	}
}
