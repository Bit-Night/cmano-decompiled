using System;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public sealed class ShapePoint : Shape
{
	private PointD pointD_0;

	public PointD Point => pointD_0;

	protected internal ShapePoint(int recordNumber, StringDictionary metadata, IDataRecord dataRecord, byte[] shapeData)
		: base(ShapeType.Point, recordNumber, metadata, dataRecord)
	{
		if (shapeData != null)
		{
			if (shapeData.Length != 28)
			{
				throw new InvalidOperationException("Invalid shape data");
			}
			pointD_0 = new PointD(EndianBitConverter.ToDouble(shapeData, 12, ProvidedOrder.Little), EndianBitConverter.ToDouble(shapeData, 20, ProvidedOrder.Little));
			return;
		}
		throw new ArgumentNullException("shapeData");
	}

	static ShapePoint()
	{
		Class72.smethod_20();
	}
}
