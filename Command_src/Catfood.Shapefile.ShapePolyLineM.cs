using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Runtime.CompilerServices;

namespace Catfood.Shapefile;

public sealed class ShapePolyLineM : ShapePolyLine
{
	[CompilerGenerated]
	private double double_0;

	[CompilerGenerated]
	private double double_1;

	[CompilerGenerated]
	private List<double> list_0;

	public double Mmin
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		protected set
		{
			double_0 = value;
		}
	}

	public double Mmax
	{
		[CompilerGenerated]
		get
		{
			return double_1;
		}
		[CompilerGenerated]
		protected set
		{
			double_1 = value;
		}
	}

	public List<double> M
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		protected set
		{
			list_0 = value;
		}
	}

	protected internal ShapePolyLineM(int recordNumber, StringDictionary metadata, IDataRecord dataRecord, byte[] shapeData)
		: base(recordNumber, metadata, dataRecord)
	{
		_type = ShapeType.PolyLineM;
		M = new List<double>();
		method_0(shapeData, out _boundingBox, out _parts);
	}

	private void method_0(byte[] byte_0, out RectangleD rectangleD_0, out List<PointD[]> list_1)
	{
		rectangleD_0 = default(RectangleD);
		list_1 = null;
		if (byte_0 == null)
		{
			throw new ArgumentNullException("shapeData");
		}
		if (byte_0.Length < 44)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		rectangleD_0 = ParseBoundingBox(byte_0, 12, ProvidedOrder.Little);
		int num = EndianBitConverter.ToInt32(byte_0, 44, ProvidedOrder.Little);
		int num2 = EndianBitConverter.ToInt32(byte_0, 48, ProvidedOrder.Little);
		if (byte_0.Length != 52 + 4 * num + 16 + 8 * num2 + 16 * num2)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		int num3 = 52 + 4 * num;
		list_1 = new List<PointD[]>(num);
		for (int i = 0; i < num; i++)
		{
			int num4 = EndianBitConverter.ToInt32(byte_0, 52 + 4 * i, ProvidedOrder.Little) * 16 + num3;
			int num5;
			if (i == num - 1)
			{
				num5 = byte_0.Length - num4;
				num5 -= num2 * 8 + 16;
			}
			else
			{
				num5 = EndianBitConverter.ToInt32(byte_0, 52 + 4 * (i + 1), ProvidedOrder.Little) * 16 + num3 - num4;
			}
			int num6 = num5 / 16;
			PointD[] array = new PointD[num6];
			for (int j = 0; j < num6; j++)
			{
				array[j] = new PointD(EndianBitConverter.ToDouble(byte_0, num4 + 16 * j, ProvidedOrder.Little), EndianBitConverter.ToDouble(byte_0, num4 + 8 + 16 * j, ProvidedOrder.Little));
			}
			list_1.Add(array);
		}
		Mmin = EndianBitConverter.ToDouble(byte_0, 52 + 4 * num + 16 * num2, ProvidedOrder.Little);
		Mmax = EndianBitConverter.ToDouble(byte_0, 60 + 4 * num + 16 * num2, ProvidedOrder.Little);
		M.Clear();
		for (int k = 0; k < num2; k++)
		{
			double item = EndianBitConverter.ToDouble(byte_0, 68 + 4 * num + 16 * num2 + k * 8, ProvidedOrder.Little);
			M.Add(item);
		}
	}

	static ShapePolyLineM()
	{
		Class72.smethod_20();
	}
}
