using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace DotSpatial.Topology.Utilities;

public class GmlWriter
{
	protected virtual NumberFormatInfo NumberFormatter => Global.GetNfi();

	public virtual XmlReader Write(IGeometry geometry)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		byte[] bytes = GetBytes(geometry);
		using (Stream stream = new MemoryTributary(bytes))
		{
			Write(geometry, stream);
		}
		return (XmlReader)new XmlTextReader((Stream)new MemoryTributary(bytes));
	}

	public virtual void Write(IGeometry geometry, Stream stream)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		XmlTextWriter val = new XmlTextWriter(stream, (Encoding)null);
		val.Formatting = (Formatting)1;
		Write(geometry, val);
		((XmlWriter)val).Close();
	}

	protected void Write(Coordinate coordinate, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("coord");
		((XmlWriter)writer).WriteElementString("X", coordinate.X.ToString("g", NumberFormatter));
		((XmlWriter)writer).WriteElementString("Y", coordinate.Y.ToString("g", NumberFormatter));
		((XmlWriter)writer).WriteEndElement();
	}

	protected void Write(IList<Coordinate> coordinates, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteRaw("<coordinates>");
		foreach (Coordinate coordinate in coordinates)
		{
			((XmlWriter)writer).WriteRaw(coordinate.X.ToString("g", NumberFormatter) + " ");
			((XmlWriter)writer).WriteRaw(coordinate.Y.ToString("g", NumberFormatter) + " ");
		}
		((XmlWriter)writer).WriteRaw("</coordinates>");
	}

	protected virtual void Write(IGeometry geometry, XmlTextWriter writer)
	{
		if (!(geometry is Point))
		{
			if (!(geometry is LineString))
			{
				if (geometry is Polygon)
				{
					Write(geometry as Polygon, writer);
					return;
				}
				if (geometry is MultiPoint)
				{
					Write(geometry as MultiPoint, writer);
					return;
				}
				if (geometry is MultiLineString)
				{
					Write(geometry as MultiLineString, writer);
					return;
				}
				if (geometry is MultiPolygon)
				{
					Write(geometry as MultiPolygon, writer);
					return;
				}
				if (!(geometry is GeometryCollection))
				{
					throw new ArgumentException("Geometry not recognized: " + geometry.ToString());
				}
				Write(geometry as GeometryCollection, writer);
			}
			else
			{
				Write(geometry as LineString, writer);
			}
		}
		else
		{
			Write(geometry as Point, writer);
		}
	}

	protected virtual void Write(IPoint point, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("Point");
		Write(point.Coordinate, writer);
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(LineString lineString, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("LineString");
		Write(lineString.Coordinates, writer);
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(LinearRing linearRing, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("LinearRing");
		Write(linearRing.Coordinates, writer);
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(Polygon polygon, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("Polygon");
		((XmlWriter)writer).WriteStartElement("outerBoundaryIs");
		Write(polygon.ExteriorRing as LinearRing, writer);
		((XmlWriter)writer).WriteEndElement();
		for (int i = 0; i < polygon.NumHoles; i++)
		{
			((XmlWriter)writer).WriteStartElement("innerBoundaryIs");
			Write(polygon.Holes[i] as LinearRing, writer);
			((XmlWriter)writer).WriteEndElement();
		}
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(MultiPoint multiPoint, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("MultiPoint");
		for (int i = 0; i < multiPoint.NumGeometries; i++)
		{
			((XmlWriter)writer).WriteStartElement("pointMember");
			Write(multiPoint.Geometries[i] as Point, writer);
			((XmlWriter)writer).WriteEndElement();
		}
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(MultiLineString multiLineString, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("MultiLineString");
		for (int i = 0; i < multiLineString.NumGeometries; i++)
		{
			((XmlWriter)writer).WriteStartElement("lineStringMember");
			Write(multiLineString.Geometries[i] as LineString, writer);
			((XmlWriter)writer).WriteEndElement();
		}
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(MultiPolygon multiPolygon, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("MultiPolygon");
		for (int i = 0; i < multiPolygon.NumGeometries; i++)
		{
			((XmlWriter)writer).WriteStartElement("polygonMember");
			Write(multiPolygon.Geometries[i] as Polygon, writer);
			((XmlWriter)writer).WriteEndElement();
		}
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual void Write(GeometryCollection geometryCollection, XmlTextWriter writer)
	{
		((XmlWriter)writer).WriteStartElement("MultiGeometry");
		for (int i = 0; i < geometryCollection.NumGeometries; i++)
		{
			((XmlWriter)writer).WriteStartElement("geometryMember");
			Write(geometryCollection.Geometries[i] as Geometry, writer);
			((XmlWriter)writer).WriteEndElement();
		}
		((XmlWriter)writer).WriteEndElement();
	}

	protected virtual byte[] GetBytes(IGeometry geometry)
	{
		if (!(geometry is IPoint))
		{
			if (geometry is ILineString)
			{
				return new byte[SetByteStreamLength(geometry as LineString)];
			}
			if (!(geometry is IPolygon))
			{
				if (geometry is IMultiPoint)
				{
					return new byte[SetByteStreamLength(geometry as MultiPoint)];
				}
				if (geometry is IMultiLineString)
				{
					return new byte[SetByteStreamLength(geometry as MultiLineString)];
				}
				if (geometry is IMultiPolygon)
				{
					return new byte[SetByteStreamLength(geometry as MultiPolygon)];
				}
				if (geometry is GInterface6)
				{
					return new byte[SetByteStreamLength(geometry as GeometryCollection)];
				}
				throw new ArgumentException("ShouldNeverReachHere");
			}
			return new byte[SetByteStreamLength(geometry as Polygon)];
		}
		return new byte[SetByteStreamLength(geometry as Point)];
	}

	protected virtual int SetByteStreamLength(Geometry geometry)
	{
		if (!(geometry is Point))
		{
			if (!(geometry is LineString))
			{
				if (geometry is Polygon)
				{
					return SetByteStreamLength(geometry as Polygon);
				}
				if (!(geometry is MultiPoint))
				{
					if (!(geometry is MultiLineString))
					{
						if (!(geometry is MultiPolygon))
						{
							if (!(geometry is GeometryCollection))
							{
								throw new ArgumentException("ShouldNeverReachHere");
							}
							return SetByteStreamLength(geometry as GeometryCollection);
						}
						return SetByteStreamLength(geometry as MultiPolygon);
					}
					return SetByteStreamLength(geometry as MultiLineString);
				}
				return SetByteStreamLength(geometry as MultiPoint);
			}
			return SetByteStreamLength(geometry as LineString);
		}
		return SetByteStreamLength(geometry as Point);
	}

	protected virtual int SetByteStreamLength(GeometryCollection geometryCollection)
	{
		int num = 100;
		IGeometry[] geometries = geometryCollection.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Geometry byteStreamLength = (Geometry)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(MultiPolygon multiPolygon)
	{
		int num = 100;
		IGeometry[] geometries = multiPolygon.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Polygon byteStreamLength = (Polygon)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(MultiLineString multiLineString)
	{
		int num = 100;
		IGeometry[] geometries = multiLineString.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			LineString byteStreamLength = (LineString)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(MultiPoint multiPoint)
	{
		int num = 100;
		IGeometry[] geometries = multiPoint.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Point byteStreamLength = (Point)geometries[i];
			num += SetByteStreamLength(byteStreamLength);
		}
		return num;
	}

	protected virtual int SetByteStreamLength(Polygon polygon)
	{
		return 100 + polygon.NumPoints * 100;
	}

	protected virtual int SetByteStreamLength(LineString lineString)
	{
		return 100 + lineString.NumPoints * 100;
	}

	protected virtual int SetByteStreamLength(Point point)
	{
		return 200;
	}

	static GmlWriter()
	{
		Class72.smethod_20();
	}
}
