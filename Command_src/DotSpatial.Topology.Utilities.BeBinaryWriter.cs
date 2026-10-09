using System;
using System.IO;
using System.Text;

namespace DotSpatial.Topology.Utilities;

public class BeBinaryWriter : BinaryWriter
{
	public BeBinaryWriter()
	{
	}

	public BeBinaryWriter(Stream output)
		: base(output)
	{
	}

	public BeBinaryWriter(Stream output, Encoding encoding)
		: base(output, encoding)
	{
	}

	public override void Write(short value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse((Array)bytes, 0, 2);
		Write(bytes);
	}

	public override void Write(int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse((Array)bytes, 0, 4);
		Write(bytes);
	}

	public override void Write(long value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse((Array)bytes, 0, 8);
		Write(bytes);
	}

	public override void Write(float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse((Array)bytes, 0, 4);
		Write(bytes);
	}

	public override void Write(double value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		Array.Reverse((Array)bytes, 0, 8);
		Write(bytes);
	}

	public override void Write(string value)
	{
		throw new NotImplementedException();
	}

	public override void Write(decimal value)
	{
		throw new NotImplementedException();
	}

	static BeBinaryWriter()
	{
		Class72.smethod_20();
	}
}
