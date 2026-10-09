using System;
using System.IO;

namespace DotSpatial.Topology.Utilities;

public class WkbReader
{
	private IGeometryFactory igeometryFactory_0;

	protected virtual IGeometryFactory Factory => igeometryFactory_0;

	public WkbReader()
		: this(new GeometryFactory())
	{
	}

	public WkbReader(IGeometryFactory factory)
	{
		igeometryFactory_0 = factory;
	}

	public virtual IGeometry Read(byte[] data)
	{
		using Stream stream = new MemoryTributary(data);
		return Read(stream);
	}

	public virtual IGeometry Read(Stream stream)
	{
		BinaryReader binaryReader = null;
		ByteOrder byteOrder = (ByteOrder)stream.ReadByte();
		try
		{
			binaryReader = ((byteOrder != ByteOrder.BigEndian) ? new BinaryReader(stream) : new BeBinaryReader(stream));
			return Read(binaryReader);
		}
		finally
		{
			binaryReader?.Close();
		}
	}

	protected virtual IGeometry Read(BinaryReader reader)
	{
		WkbGeometryType wkbGeometryType = (WkbGeometryType)reader.ReadInt32();
		return wkbGeometryType switch
		{
			WkbGeometryType.Point => ReadPoint(reader), 
			WkbGeometryType.LineString => ReadLineString(reader), 
			WkbGeometryType.Polygon => ReadPolygon(reader), 
			WkbGeometryType.MultiPoint => ReadMultiPoint(reader), 
			WkbGeometryType.MultiLineString => ReadMultiLineString(reader), 
			WkbGeometryType.MultiPolygon => ReadMultiPolygon(reader), 
			WkbGeometryType.GeometryCollection => ReadGeometryCollection(reader), 
			_ => throw new ArgumentException("Geometry type not recognized. GeometryCode: " + wkbGeometryType), 
		};
	}

	protected virtual ByteOrder ReadByteOrder(BinaryReader reader)
	{
		return (ByteOrder)reader.ReadByte();
	}

	protected virtual Coordinate ReadCoordinate(BinaryReader reader)
	{
		return new Coordinate(reader.ReadDouble(), reader.ReadDouble());
	}

	protected virtual ILinearRing ReadRing(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		Coordinate[] array = new Coordinate[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = ReadCoordinate(reader);
		}
		return Factory.CreateLinearRing(array);
	}

	protected virtual IGeometry ReadPoint(BinaryReader reader)
	{
		return Factory.CreatePoint(ReadCoordinate(reader));
	}

	protected virtual IGeometry ReadLineString(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		Coordinate[] array = new Coordinate[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = ReadCoordinate(reader);
		}
		return Factory.CreateLineString(array);
	}

	protected virtual IGeometry ReadPolygon(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		ILinearRing shell = ReadRing(reader);
		ILinearRing[] array = new LinearRing[num - 1];
		ILinearRing[] array2 = array;
		for (int i = 0; i < num - 1; i++)
		{
			array2[i] = ReadRing(reader);
		}
		return Factory.CreatePolygon(shell, array2);
	}

	protected virtual IGeometry ReadMultiPoint(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		Point[] array = new Point[num];
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(reader);
			if (reader.ReadInt32() == 1)
			{
				array[i] = ReadPoint(reader) as Point;
				continue;
			}
			throw new ArgumentException("Point feature expected");
		}
		return Factory.CreateMultiPoint(array);
	}

	protected virtual IGeometry ReadMultiLineString(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		LineString[] array = new LineString[num];
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(reader);
			if (reader.ReadInt32() == 2)
			{
				array[i] = ReadLineString(reader) as LineString;
				continue;
			}
			throw new ArgumentException("LineString feature expected");
		}
		IGeometryFactory factory = Factory;
		IBasicLineString[] lineStrings = array;
		return factory.CreateMultiLineString(lineStrings);
	}

	protected virtual IGeometry ReadMultiPolygon(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		Polygon[] array = new Polygon[num];
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(reader);
			if (reader.ReadInt32() == 3)
			{
				array[i] = ReadPolygon(reader) as Polygon;
				continue;
			}
			throw new ArgumentException("Polygon feature expected");
		}
		IGeometryFactory factory = Factory;
		IPolygon[] polygons = array;
		return factory.CreateMultiPolygon(polygons);
	}

	protected virtual IGeometry ReadGeometryCollection(BinaryReader reader)
	{
		int num = reader.ReadInt32();
		IGeometry[] array = new Geometry[num];
		IGeometry[] array2 = array;
		for (int i = 0; i < num; i++)
		{
			ReadByteOrder(reader);
			switch ((WkbGeometryType)reader.ReadInt32())
			{
			case WkbGeometryType.Point:
				array2[i] = ReadPoint(reader);
				break;
			case WkbGeometryType.LineString:
				array2[i] = ReadLineString(reader);
				break;
			case WkbGeometryType.Polygon:
				array2[i] = ReadPolygon(reader);
				break;
			case WkbGeometryType.MultiPoint:
				array2[i] = ReadMultiPoint(reader);
				break;
			case WkbGeometryType.MultiLineString:
				array2[i] = ReadMultiLineString(reader);
				break;
			case WkbGeometryType.MultiPolygon:
				array2[i] = ReadMultiPolygon(reader);
				break;
			case WkbGeometryType.GeometryCollection:
				array2[i] = ReadGeometryCollection(reader);
				break;
			default:
				throw new ArgumentException("Should never reach here!");
			}
		}
		return Factory.CreateGeometryCollection(array2);
	}

	static WkbReader()
	{
		Class72.smethod_20();
	}
}
