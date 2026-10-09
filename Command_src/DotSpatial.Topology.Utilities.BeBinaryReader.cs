using System;
using System.IO;
using System.Text;

namespace DotSpatial.Topology.Utilities;

public class BeBinaryReader : BinaryReader
{
	public BeBinaryReader(Stream stream)
		: base(stream)
	{
	}

	public BeBinaryReader(Stream input, Encoding encoding)
		: base(input, encoding)
	{
	}

	public override short ReadInt16()
	{
		byte[] array = new byte[2];
		Read(array, 0, 2);
		Array.Reverse((Array)array);
		return BitConverter.ToInt16(array, 0);
	}

	public override int ReadInt32()
	{
		byte[] array = new byte[4];
		Read(array, 0, 4);
		Array.Reverse((Array)array);
		return BitConverter.ToInt32(array, 0);
	}

	public override long ReadInt64()
	{
		byte[] array = new byte[8];
		Read(array, 0, 8);
		Array.Reverse((Array)array);
		return BitConverter.ToInt64(array, 0);
	}

	public override float ReadSingle()
	{
		byte[] array = new byte[4];
		Read(array, 0, 4);
		Array.Reverse((Array)array);
		return BitConverter.ToSingle(array, 0);
	}

	public override double ReadDouble()
	{
		byte[] array = new byte[8];
		Read(array, 0, 8);
		Array.Reverse((Array)array);
		return BitConverter.ToDouble(array, 0);
	}

	public override decimal ReadDecimal()
	{
		byte[] array = new byte[16];
		Read(array, 0, 16);
		Array.Reverse((Array)array);
		return new BinaryReader(new MemoryTributary(array)).ReadDecimal();
	}

	static BeBinaryReader()
	{
		Class72.smethod_20();
	}
}
