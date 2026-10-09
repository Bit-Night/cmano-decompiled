using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct ProtocolMode
{
	[Description("Protocol Mode")]
	public enum ProtocolModeValue : uint
	{
		HeartbeatMode,
		QRPMode,
		Unknown
	}

	private ProtocolModeValue protocolModeValue_0;

	public ProtocolModeValue Value
	{
		get
		{
			return protocolModeValue_0;
		}
		set
		{
			protocolModeValue_0 = value;
		}
	}

	public static bool operator !=(ProtocolMode left, ProtocolMode right)
	{
		return !(left == right);
	}

	public static bool operator ==(ProtocolMode left, ProtocolMode right)
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

	public static explicit operator uint(ProtocolMode obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator ProtocolMode(uint value)
	{
		return smethod_0(value);
	}

	public static ProtocolMode FromByteArray(byte[] array, int index)
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

	public static ProtocolMode smethod_0(uint value)
	{
		ProtocolMode result = default(ProtocolMode);
		uint value2 = (value & 3) >> 0;
		result.Value = (ProtocolModeValue)value2;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is ProtocolMode))
		{
			return false;
		}
		return Equals((ProtocolMode)obj);
	}

	public bool Equals(ProtocolMode other)
	{
		if ((object)other != null)
		{
			return Value == other.Value;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(ProtocolModeValue.HeartbeatMode | Value);
	}

	public override int GetHashCode()
	{
		return 493 + Value.GetHashCode();
	}

	static ProtocolMode()
	{
		Class72.smethod_20();
	}
}
