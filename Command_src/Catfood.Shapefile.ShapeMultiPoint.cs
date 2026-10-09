using System;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public sealed class ShapeMultiPoint : Shape
{
	private RectangleD rectangleD_0;

	private PointD[] pointD_0;

	public RectangleD BoundingBox => rectangleD_0;

	public PointD[] Points => pointD_0;

	protected internal ShapeMultiPoint(int recordNumber, StringDictionary metadata, IDataRecord dataRecord, byte[] shapeData)
		: base(ShapeType.MultiPoint, recordNumber, metadata, dataRecord)
	{
		if (shapeData == null)
		{
			throw new ArgumentNullException("shapeData");
		}
		if (shapeData.Length < 48)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		rectangleD_0 = ParseBoundingBox(shapeData, 12, ProvidedOrder.Little);
		int num = EndianBitConverter.ToInt32(shapeData, 44, ProvidedOrder.Little);
		if (shapeData.Length != 48 + 16 * num)
		{
			throw new InvalidOperationException("Invalid shape data");
		}
		pointD_0 = new PointD[num];
		for (int i = 0; i < num; i++)
		{
			pointD_0[i] = new PointD(EndianBitConverter.ToDouble(shapeData, 48 + 16 * i, ProvidedOrder.Little), EndianBitConverter.ToDouble(shapeData, 56 + 16 * i, ProvidedOrder.Little));
		}
	}

	static ShapeMultiPoint()
	{
		Class72.smethod_20();
	}
}
