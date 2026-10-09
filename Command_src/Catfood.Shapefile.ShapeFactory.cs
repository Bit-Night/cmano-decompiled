using System;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

internal static class ShapeFactory
{
	public static Shape ParseShape(byte[] shapeData, StringDictionary metadata, IDataRecord dataRecord)
	{
		if (shapeData != null)
		{
			if (shapeData.Length >= 12)
			{
				int recordNumber = EndianBitConverter.ToInt32(shapeData, 0, ProvidedOrder.Big);
				int num = EndianBitConverter.ToInt32(shapeData, 4, ProvidedOrder.Big);
				ShapeType shapeType = (ShapeType)EndianBitConverter.ToInt32(shapeData, 8, ProvidedOrder.Little);
				if (shapeData.Length != num * 2 + 8)
				{
					throw new InvalidOperationException("Shape data length does not match shape header length");
				}
				Shape shape = null;
				return shapeType switch
				{
					ShapeType.PolyLineM => new ShapePolyLineM(recordNumber, metadata, dataRecord, shapeData), 
					ShapeType.Null => new Shape(shapeType, recordNumber, metadata, dataRecord), 
					ShapeType.Point => new ShapePoint(recordNumber, metadata, dataRecord, shapeData), 
					ShapeType.PolyLine => new ShapePolyLine(recordNumber, metadata, dataRecord, shapeData), 
					ShapeType.Polygon => new ShapePolygon(recordNumber, metadata, dataRecord, shapeData), 
					ShapeType.MultiPoint => new ShapeMultiPoint(recordNumber, metadata, dataRecord, shapeData), 
					_ => throw new NotImplementedException($"Shapetype {shapeType} is not implemented"), 
				};
			}
			throw new ArgumentException("shapeData must be at least 12 bytes long");
		}
		throw new ArgumentNullException("shapeData");
	}

	static ShapeFactory()
	{
		Class72.smethod_20();
	}
}
