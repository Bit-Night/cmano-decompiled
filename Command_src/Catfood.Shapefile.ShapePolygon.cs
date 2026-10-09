using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public sealed class ShapePolygon : Shape
{
	private RectangleD rectangleD_0;

	private List<PointD[]> list_0;

	public RectangleD BoundingBox => rectangleD_0;

	public List<PointD[]> Parts => list_0;

	protected internal ShapePolygon(int recordNumber, StringDictionary metadata, IDataRecord dataRecord, byte[] shapeData)
		: base(ShapeType.Polygon, recordNumber, metadata, dataRecord)
	{
		ParsePolyLineOrPolygon(shapeData, out rectangleD_0, out list_0);
	}

	static ShapePolygon()
	{
		Class72.smethod_20();
	}
}
