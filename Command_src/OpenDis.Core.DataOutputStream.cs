using System;
using OpenDis.Dis1998;

namespace OpenDis.Core;

public class DataOutputStream
{
	private DataStream dataStream_0;

	public DataStream DS => dataStream_0;

	public Endian Endian
	{
		get
		{
			return DS.Endian;
		}
		set
		{
			DS.Endian = value;
		}
	}

	public DataOutputStream(DataStream ds, Endian endian)
	{
		dataStream_0 = ds;
		Endian = endian;
	}

	public DataOutputStream()
		: this(Endian.Little)
	{
	}

	public DataOutputStream(Endian endian)
	{
		dataStream_0 = new DataStream();
		Endian = endian;
	}

	public byte[] ConvertToBytes(Pdu thePDU)
	{
		byte[] array = new byte[thePDU.Length];
		byte[] array2 = DS.ConvertToBytes();
		for (int i = 0; i < array2.Length; i++)
		{
			array[i] = array2[i];
		}
		return array;
	}

	public void WriteByte(byte data)
	{
		method_0(data);
	}

	public void WriteByte(byte[] data)
	{
		method_1(data);
	}

	public void WriteDouble(double data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteFloat(float data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteInt(int data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteLong(long data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteShort(short data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteUnsignedByte(byte data)
	{
		method_0(data);
	}

	public void WriteUnsignedByte(byte[] data)
	{
		method_1(data);
	}

	public void WriteUnsignedInt(uint data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteUnsignedLong(ulong data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	public void WriteUnsignedShort(ushort data)
	{
		byte[] bytes = BitConverter.GetBytes(data);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)bytes);
		}
		method_1(bytes);
	}

	private void method_0(byte byte_0)
	{
		dataStream_0.Append(byte_0);
		dataStream_0.StreamCounter++;
	}

	private void method_1(byte[] byte_0)
	{
		dataStream_0.Append(byte_0);
		dataStream_0.StreamCounter += byte_0.Length;
	}

	static DataOutputStream()
	{
		Class72.smethod_20();
	}
}
