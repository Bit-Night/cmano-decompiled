using System;

namespace OpenDis.Core;

public class DataInputStream
{
	private DataStream dataStream_0;

	public Endian Endian
	{
		get
		{
			return dataStream_0.Endian;
		}
		set
		{
			dataStream_0.Endian = value;
		}
	}

	public DataInputStream()
		: this(Endian.Little)
	{
	}

	public DataInputStream(Endian endian)
	{
		dataStream_0 = new DataStream();
		dataStream_0.StreamCounter = 0;
		Endian = endian;
	}

	public DataInputStream(byte[] ds, Endian endian)
		: this(endian)
	{
		dataStream_0.StreamByteArray = ds;
		dataStream_0.Endian = endian;
	}

	public byte ReadByte()
	{
		byte result = dataStream_0.StreamByteArray[dataStream_0.StreamCounter];
		dataStream_0.StreamCounter++;
		return result;
	}

	public byte[] ReadByteArray(int length)
	{
		byte[] result = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, length);
		dataStream_0.StreamCounter += length;
		return result;
	}

	public double ReadDouble()
	{
		int num = 8;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 8);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		double result = BitConverter.ToDouble(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public float ReadFloat()
	{
		int num = 4;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 4);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		float result = BitConverter.ToSingle(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public int ReadInt()
	{
		int num = 4;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 4);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		int result = BitConverter.ToInt32(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public long ReadLong()
	{
		int num = 8;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 8);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		long result = BitConverter.ToInt64(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public short ReadShort()
	{
		int num = 2;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 2);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		short result = BitConverter.ToInt16(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public byte ReadUnsignedByte()
	{
		return ReadByte();
	}

	public uint ReadUnsignedInt()
	{
		int num = 4;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 4);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		uint result = BitConverter.ToUInt32(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public ulong ReadUnsignedLong()
	{
		int num = 8;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 8);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		ulong result = BitConverter.ToUInt64(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	public ushort ReadUnsignedShort()
	{
		int num = 2;
		byte[] array = DataStream.ReturnByteArray(dataStream_0.StreamByteArray, dataStream_0.StreamCounter, 2);
		if (Endian == Endian.Big)
		{
			Array.Reverse((Array)array);
		}
		ushort result = BitConverter.ToUInt16(array, 0);
		dataStream_0.StreamCounter += num;
		return result;
	}

	static DataInputStream()
	{
		Class72.smethod_20();
	}
}
