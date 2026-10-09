using System;
using System.IO;

namespace DotSpatial.Topology.Utilities;

public class WkbWriter
{
	protected const int INIT_COUNT = 5;

	private readonly ByteOrder byteOrder_0;

	public WkbWriter()
		: this(ByteOrder.LittleEndian)
	{
	}

	public WkbWriter(ByteOrder encodingType)
	{
		byteOrder_0 = encodingType;
	}

	public virtual byte[] Write(IGeometry geometry)
	{
		byte[] bytes = GetBytes(geometry);
		Write(geometry, new MemoryTributary(bytes));
		return bytes;
	}

	public virtual void Write(IGeometry geometry, Stream stream)
	{
		BinaryWriter binaryWriter = null;
		try
		{
			binaryWriter = ((byteOrder_0 != ByteOrder.LittleEndian) ? new BeBinaryWriter(stream) : new BinaryWriter(stream));
			Write(geometry, binaryWriter);
		}
		finally
		{
			binaryWriter?.Close();
		}
	}

	protected virtual void Write(IGeometry geometry, BinaryWriter writer)
	{
		if (!(geometry is IPoint))
		{
			if (geometry is ILineString)
			{
				Write(geometry as ILineString, writer);
			}
			else if (geometry is IPolygon)
			{
				Write(geometry as IPolygon, writer);
			}
			else if (!(geometry is IMultiPoint))
			{
				if (geometry is IMultiLineString)
				{
					Write(geometry as IMultiLineString, writer);
					return;
				}
				if (geometry is IMultiPolygon)
				{
					Write(geometry as IMultiPolygon, writer);
					return;
				}
				if (!(geometry is GInterface6))
				{
					throw new ArgumentException("Geometry not recognized: " + geometry.ToString());
				}
				Write(geometry as GInterface6, writer);
			}
			else
			{
				Write(geometry as IMultiPoint, writer);
			}
		}
		else
		{
			Write(geometry as IPoint, writer);
		}
	}

	protected virtual void WriteByteOrder(BinaryWriter writer)
	{
		writer.Write((byte)byteOrder_0);
	}

	protected virtual void Write(IPoint point, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(1);
		Write(point.Coordinate, writer);
	}

	protected virtual void Write(ILineString lineString, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(2);
		writer.Write(lineString.NumPoints);
		for (int i = 0; i < lineString.Coordinates.Count; i++)
		{
			Write(lineString.Coordinates[i], writer);
		}
	}

	protected virtual void Write(IPolygon polygon, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(3);
		writer.Write(polygon.NumHoles + 1);
		Write(polygon.Shell, writer);
		for (int i = 0; i < polygon.NumHoles; i++)
		{
			Write(polygon.Holes[i], writer);
		}
	}

	protected virtual void Write(IMultiPoint multiPoint, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(4);
		writer.Write(multiPoint.NumGeometries);
		for (int i = 0; i < multiPoint.NumGeometries; i++)
		{
			Write(multiPoint.Geometries[i] as Point, writer);
		}
	}

	protected virtual void Write(IMultiLineString multiLineString, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(5);
		writer.Write(multiLineString.NumGeometries);
		for (int i = 0; i < multiLineString.NumGeometries; i++)
		{
			Write(multiLineString.Geometries[i] as LineString, writer);
		}
	}

	protected virtual void Write(IMultiPolygon multiPolygon, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(6);
		writer.Write(multiPolygon.NumGeometries);
		for (int i = 0; i < multiPolygon.NumGeometries; i++)
		{
			Write(multiPolygon.Geometries[i] as Polygon, writer);
		}
	}

	protected virtual void Write(GInterface6 geomCollection, BinaryWriter writer)
	{
		WriteByteOrder(writer);
		writer.Write(7);
		writer.Write(geomCollection.NumGeometries);
		for (int i = 0; i < geomCollection.NumGeometries; i++)
		{
			Write(geomCollection.Geometries[i], writer);
		}
	}

	protected virtual void Write(Coordinate coordinate, BinaryWriter writer)
	{
		writer.Write(coordinate.X);
		writer.Write(coordinate.Y);
	}

	protected virtual void Write(ILinearRing ring, BinaryWriter writer)
	{
		writer.Write(ring.NumPoints);
		for (int i = 0; i < ring.Coordinates.Count; i++)
		{
			Write(ring.Coordinates[i], writer);
		}
	}

	protected virtual byte[] GetBytes(IGeometry geometry)
	{
		if (!(geometry is IPoint))
		{
			if (geometry is ILineString)
			{
				return new byte[SetByteStream(geometry as ILineString)];
			}
			if (geometry is IPolygon)
			{
				return new byte[SetByteStream(geometry as IPolygon)];
			}
			if (!(geometry is IMultiPoint))
			{
				if (geometry is IMultiLineString)
				{
					return new byte[SetByteStream(geometry as IMultiLineString)];
				}
				if (geometry is IMultiPolygon)
				{
					return new byte[SetByteStream(geometry as IMultiPolygon)];
				}
				if (geometry is GInterface6)
				{
					return new byte[SetByteStream(geometry as GInterface6)];
				}
				throw new ArgumentException("ShouldNeverReachHere");
			}
			return new byte[SetByteStream(geometry as IMultiPoint)];
		}
		return new byte[SetByteStream(geometry as IPoint)];
	}

	protected virtual int SetByteStream(IGeometry geometry)
	{
		if (!(geometry is Point))
		{
			if (geometry is LineString)
			{
				return SetByteStream(geometry as LineString);
			}
			if (geometry is Polygon)
			{
				return SetByteStream(geometry as Polygon);
			}
			if (geometry is MultiPoint)
			{
				return SetByteStream(geometry as MultiPoint);
			}
			if (geometry is MultiLineString)
			{
				return SetByteStream(geometry as MultiLineString);
			}
			if (geometry is MultiPolygon)
			{
				return SetByteStream(geometry as MultiPolygon);
			}
			if (!(geometry is GeometryCollection))
			{
				throw new ArgumentException("ShouldNeverReachHere");
			}
			return SetByteStream(geometry as GeometryCollection);
		}
		return SetByteStream(geometry as Point);
	}

	protected virtual int SetByteStream(GInterface6 geometry)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = geometry.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Geometry byteStream = (Geometry)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IMultiPolygon geometry)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = geometry.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Polygon byteStream = (Polygon)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IMultiLineString geometry)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = geometry.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			LineString byteStream = (LineString)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IMultiPoint geometry)
	{
		int num = 5;
		num = 9;
		IGeometry[] geometries = geometry.Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Point byteStream = (Point)geometries[i];
			num += SetByteStream(byteStream);
		}
		return num;
	}

	protected virtual int SetByteStream(IPolygon geometry)
	{
		return 13 + 4 * (geometry.NumHoles + 1) + geometry.NumPoints * 16;
	}

	protected virtual int SetByteStream(ILineString geometry)
	{
		int numPoints = geometry.NumPoints;
		return 9 + 16 * numPoints;
	}

	protected virtual int SetByteStream(IPoint geometry)
	{
		return 21;
	}

	static WkbWriter()
	{
		Class72.smethod_20();
	}
}
