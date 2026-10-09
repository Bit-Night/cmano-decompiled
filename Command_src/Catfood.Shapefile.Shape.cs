using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public class Shape
{
	internal ShapeType _type;

	private int int_0;

	private StringDictionary stringDictionary_0;

	private IDataRecord idataRecord_0;

	public IDataRecord DataRecord => idataRecord_0;

	public int RecordNumber => int_0;

	public ShapeType Type => _type;

	protected internal Shape(ShapeType shapeType, int recordNumber, StringDictionary metadata, IDataRecord dataRecord)
	{
		_type = shapeType;
		stringDictionary_0 = metadata;
		int_0 = recordNumber;
		idataRecord_0 = dataRecord;
	}

	public string GetMetadata(string name)
	{
		if (stringDictionary_0 != null && stringDictionary_0.ContainsKey(name))
		{
			return stringDictionary_0[name];
		}
		return null;
	}

	public string[] GetMetadataNames()
	{
		if (stringDictionary_0 != null && stringDictionary_0.Keys.Count > 0)
		{
			List<string> list = new List<string>(stringDictionary_0.Keys.Count);
			foreach (string key in stringDictionary_0.Keys)
			{
				list.Add(key);
			}
			return list.ToArray();
		}
		return null;
	}

	protected RectangleD ParseBoundingBox(byte[] value, int startIndex, ProvidedOrder order)
	{
		return new RectangleD(EndianBitConverter.ToDouble(value, startIndex, order), EndianBitConverter.ToDouble(value, startIndex + 8, order), EndianBitConverter.ToDouble(value, startIndex + 16, order), EndianBitConverter.ToDouble(value, startIndex + 24, order));
	}

	protected void ParsePolyLineOrPolygon(byte[] shapeData, out RectangleD boundingBox, out List<PointD[]> parts)
	{
		boundingBox = default(RectangleD);
		parts = null;
		if (shapeData != null)
		{
			if (shapeData.Length < 44)
			{
				throw new InvalidOperationException("Invalid shape data");
			}
			boundingBox = ParseBoundingBox(shapeData, 12, ProvidedOrder.Little);
			int num = EndianBitConverter.ToInt32(shapeData, 44, ProvidedOrder.Little);
			int num2 = EndianBitConverter.ToInt32(shapeData, 48, ProvidedOrder.Little);
			if (shapeData.Length != 52 + 4 * num + 16 * num2)
			{
				throw new InvalidOperationException("Invalid shape data");
			}
			int num3 = 52 + 4 * num;
			parts = new List<PointD[]>(num);
			for (int i = 0; i < num; i++)
			{
				int num4 = EndianBitConverter.ToInt32(shapeData, 52 + 4 * i, ProvidedOrder.Little) * 16 + num3;
				int num5 = ((i != num - 1) ? (EndianBitConverter.ToInt32(shapeData, 52 + 4 * (i + 1), ProvidedOrder.Little) * 16 + num3 - num4) : (shapeData.Length - num4));
				int num6 = num5 / 16;
				PointD[] array = new PointD[num6];
				for (int j = 0; j < num6; j++)
				{
					array[j] = new PointD(EndianBitConverter.ToDouble(shapeData, num4 + 16 * j, ProvidedOrder.Little), EndianBitConverter.ToDouble(shapeData, num4 + 8 + 16 * j, ProvidedOrder.Little));
				}
				parts.Add(array);
			}
			return;
		}
		throw new ArgumentNullException("shapeData");
	}

	static Shape()
	{
		Class72.smethod_20();
	}
}
