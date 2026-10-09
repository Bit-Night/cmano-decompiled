using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;

namespace Catfood.Shapefile;

public class ShapePolyLine : Shape
{
	internal RectangleD _boundingBox;

	internal List<PointD[]> _parts;

	public RectangleD BoundingBox => _boundingBox;

	public List<PointD[]> Parts => _parts;

	protected internal ShapePolyLine(int recordNumber, StringDictionary metadata, IDataRecord dataRecord)
		: base(ShapeType.PolyLine, recordNumber, metadata, dataRecord)
	{
	}

	protected internal ShapePolyLine(int recordNumber, StringDictionary metadata, IDataRecord dataRecord, byte[] shapeData)
		: base(ShapeType.PolyLine, recordNumber, metadata, dataRecord)
	{
		ParsePolyLineOrPolygon(shapeData, out _boundingBox, out _parts);
	}

	static ShapePolyLine()
	{
		Class72.smethod_20();
	}
}
