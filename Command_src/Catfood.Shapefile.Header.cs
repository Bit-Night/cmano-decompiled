using System;

namespace Catfood.Shapefile;

internal class Header
{
	public const int HeaderLength = 100;

	private int int_0;

	private int int_1;

	private int int_2;

	private ShapeType shapeType_0;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	public int FileCode => int_0;

	public int FileLength => int_1;

	public int Version => int_2;

	public ShapeType ShapeType => shapeType_0;

	public double XMin => double_0;

	public double YMin => double_1;

	public double XMax => double_2;

	public double YMax => double_3;

	public double ZMin => double_4;

	public double ZMax => double_5;

	public double MMin => double_6;

	public double MMax => double_7;

	public Header(byte[] headerBytes)
	{
		if (headerBytes != null)
		{
			if (headerBytes.Length != 100)
			{
				throw new InvalidOperationException($"headerBytes must be {100} bytes long");
			}
			int_0 = EndianBitConverter.ToInt32(headerBytes, 0, ProvidedOrder.Big);
			if (int_0 != 9994)
			{
				throw new InvalidOperationException($"Header File code is {int_0}, expected {9994}");
			}
			int_2 = EndianBitConverter.ToInt32(headerBytes, 28, ProvidedOrder.Little);
			if (int_2 != 1000)
			{
				throw new InvalidOperationException($"Header version is {int_2}, expected {1000}");
			}
			int_1 = EndianBitConverter.ToInt32(headerBytes, 24, ProvidedOrder.Big);
			shapeType_0 = (ShapeType)EndianBitConverter.ToInt32(headerBytes, 32, ProvidedOrder.Little);
			double_0 = EndianBitConverter.ToDouble(headerBytes, 36, ProvidedOrder.Little);
			double_1 = EndianBitConverter.ToDouble(headerBytes, 44, ProvidedOrder.Little);
			double_2 = EndianBitConverter.ToDouble(headerBytes, 52, ProvidedOrder.Little);
			double_3 = EndianBitConverter.ToDouble(headerBytes, 60, ProvidedOrder.Little);
			double_4 = EndianBitConverter.ToDouble(headerBytes, 68, ProvidedOrder.Little);
			double_5 = EndianBitConverter.ToDouble(headerBytes, 76, ProvidedOrder.Little);
			double_6 = EndianBitConverter.ToDouble(headerBytes, 84, ProvidedOrder.Little);
			double_7 = EndianBitConverter.ToDouble(headerBytes, 92, ProvidedOrder.Little);
			return;
		}
		throw new ArgumentNullException("headerBytes");
	}

	static Header()
	{
		Class72.smethod_20();
	}
}
