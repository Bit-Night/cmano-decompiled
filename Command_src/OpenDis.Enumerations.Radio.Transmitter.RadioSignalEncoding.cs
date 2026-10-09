using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Radio.Transmitter;

[Serializable]
public struct RadioSignalEncoding
{
	[Description("Encoding type")]
	public enum EncodingTypeValue : uint
	{
		_8BitMuLaw = 1u,
		const_1,
		ADPCMPerCCITTG721,
		_16BitLinearPCM,
		_8BitLinearPCM,
		const_5
	}

	[Description("Encoding class")]
	public enum EncodingClassValue : uint
	{
		EncodedAudio,
		RawBinaryData,
		ApplicationSpecificData,
		DatabaseIndex
	}

	private EncodingTypeValue encodingTypeValue_0;

	private EncodingClassValue encodingClassValue_0;

	public EncodingTypeValue EncodingType
	{
		get
		{
			return encodingTypeValue_0;
		}
		set
		{
			encodingTypeValue_0 = value;
		}
	}

	public EncodingClassValue EncodingClass
	{
		get
		{
			return encodingClassValue_0;
		}
		set
		{
			encodingClassValue_0 = value;
		}
	}

	public static bool operator !=(RadioSignalEncoding left, RadioSignalEncoding right)
	{
		return !(left == right);
	}

	public static bool operator ==(RadioSignalEncoding left, RadioSignalEncoding right)
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

	public static explicit operator ushort(RadioSignalEncoding obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator RadioSignalEncoding(ushort value)
	{
		return smethod_0(value);
	}

	public static RadioSignalEncoding FromByteArray(byte[] array, int index)
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

	public static RadioSignalEncoding smethod_0(ushort value)
	{
		RadioSignalEncoding result = default(RadioSignalEncoding);
		uint encodingType = (uint)(value & 0x3FFF) >> 0;
		result.EncodingType = (EncodingTypeValue)encodingType;
		uint encodingClass = (uint)(value & 0xC000) >> 14;
		result.EncodingClass = (EncodingClassValue)encodingClass;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is RadioSignalEncoding))
		{
			return false;
		}
		return Equals((RadioSignalEncoding)obj);
	}

	public bool Equals(RadioSignalEncoding other)
	{
		if ((object)other != null)
		{
			if (EncodingType == other.EncodingType)
			{
				return EncodingClass == other.EncodingClass;
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
		return (ushort)((ushort)(0 | (ushort)EncodingType) | (ushort)((uint)EncodingClass << 14));
	}

	public override int GetHashCode()
	{
		return (493 + EncodingType.GetHashCode()) * 29 + EncodingClass.GetHashCode();
	}

	static RadioSignalEncoding()
	{
		Class72.smethod_20();
	}
}
