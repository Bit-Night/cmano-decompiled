using System.Globalization;
using System.IO;
using System.Text;

namespace DotSpatial.Topology.Utilities;

public class WktWriter
{
	private NumberFormatInfo numberFormatInfo_0;

	private bool bool_0;

	public static string ToPoint(Coordinate p0)
	{
		return "POINT ( " + p0.X + " " + p0.Y + " )";
	}

	public static string ToLineString(GInterface5 seq)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("LINESTRING ");
		if (seq.Count == 0)
		{
			stringBuilder.Append(" EMPTY");
		}
		else
		{
			stringBuilder.Append("(");
			for (int i = 0; i < seq.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(seq[i].X + " " + seq[i].Y);
			}
			stringBuilder.Append(")");
		}
		return stringBuilder.ToString();
	}

	public static string ToLineString(Coordinate p0, Coordinate p1)
	{
		return "LINESTRING ( " + p0.X + " " + p0.Y + ", " + p1.X + " " + p1.Y + " )";
	}

	private static NumberFormatInfo smethod_0(PrecisionModel precisionModel_0)
	{
		int maximumSignificantDigits = precisionModel_0.MaximumSignificantDigits;
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
		numberFormatInfo.NumberDecimalSeparator = ".";
		numberFormatInfo.NumberDecimalDigits = maximumSignificantDigits;
		numberFormatInfo.NumberGroupSeparator = string.Empty;
		numberFormatInfo.NumberGroupSizes = new int[0];
		return numberFormatInfo;
	}

	public static string StringOfChar(char ch, int count)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < count; i++)
		{
			stringBuilder.Append(ch);
		}
		return stringBuilder.ToString();
	}

	public virtual string Write(Geometry geometry)
	{
		TextWriter textWriter = new StringWriter();
		method_0(geometry, bool_1: false, textWriter);
		return textWriter.ToString();
	}

	public virtual void Write(Geometry geometry, TextWriter writer)
	{
		method_0(geometry, bool_1: false, writer);
	}

	public virtual string WriteFormatted(Geometry geometry)
	{
		TextWriter textWriter = new StringWriter();
		method_0(geometry, bool_1: true, textWriter);
		return textWriter.ToString();
	}

	public virtual void WriteFormatted(Geometry geometry, TextWriter writer)
	{
		method_0(geometry, bool_1: true, writer);
	}

	private void method_0(IGeometry igeometry_0, bool bool_1, TextWriter textWriter_0)
	{
		bool_0 = bool_1;
		numberFormatInfo_0 = smethod_0(new PrecisionModel(igeometry_0.PrecisionModel));
		method_1(igeometry_0, 0, textWriter_0);
	}

	private void method_1(IGeometry igeometry_0, int int_0, TextWriter textWriter_0)
	{
		Indent(int_0, textWriter_0);
		if (igeometry_0 is Point)
		{
			Point point = (Point)igeometry_0;
			method_2(point.Coordinate, textWriter_0);
		}
		else if (igeometry_0 is ILinearRing)
		{
			method_4((ILinearRing)igeometry_0, int_0, textWriter_0);
		}
		else if (!(igeometry_0 is ILineString))
		{
			if (!(igeometry_0 is IPolygon))
			{
				if (!(igeometry_0 is IMultiPoint))
				{
					if (igeometry_0 is IMultiLineString)
					{
						method_7((IMultiLineString)igeometry_0, int_0, textWriter_0);
						return;
					}
					if (igeometry_0 is IMultiPolygon)
					{
						method_8((IMultiPolygon)igeometry_0, int_0, textWriter_0);
						return;
					}
					if (!(igeometry_0 is GInterface6))
					{
						throw new UnsupportedGeometryException();
					}
					method_9((GInterface6)igeometry_0, int_0, textWriter_0);
				}
				else
				{
					method_6((IMultiPoint)igeometry_0, textWriter_0);
				}
			}
			else
			{
				method_5((IPolygon)igeometry_0, int_0, textWriter_0);
			}
		}
		else
		{
			method_3((ILineString)igeometry_0, int_0, textWriter_0);
		}
	}

	private void method_2(Coordinate coordinate_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("POINT ");
		method_10(coordinate_0, textWriter_0);
	}

	private void method_3(IBasicLineString ibasicLineString_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("LINESTRING ");
		method_13(ibasicLineString_0, int_0, bool_1: false, textWriter_0);
	}

	private void method_4(ILinearRing ilinearRing_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("LINEARRING ");
		method_13(ilinearRing_0, int_0, bool_1: false, textWriter_0);
	}

	private void method_5(IPolygon ipolygon_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("POLYGON ");
		method_14(ipolygon_0, int_0, bool_1: false, textWriter_0);
	}

	private void method_6(IMultiPoint imultiPoint_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("MULTIPOINT ");
		method_15(imultiPoint_0, textWriter_0);
	}

	private void method_7(IMultiLineString imultiLineString_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("MULTILINESTRING ");
		method_16(imultiLineString_0, int_0, bool_1: false, textWriter_0);
	}

	private void method_8(IMultiPolygon imultiPolygon_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("MULTIPOLYGON ");
		method_17(imultiPolygon_0, int_0, textWriter_0);
	}

	private void method_9(GInterface6 ginterface6_0, int int_0, TextWriter textWriter_0)
	{
		textWriter_0.Write("GEOMETRYCOLLECTION ");
		method_18(ginterface6_0, int_0, textWriter_0);
	}

	private void method_10(Coordinate coordinate_0, TextWriter textWriter_0)
	{
		if (!(coordinate_0 == null))
		{
			textWriter_0.Write("(");
			method_11(coordinate_0, textWriter_0);
			textWriter_0.Write(")");
		}
		else
		{
			textWriter_0.Write("EMPTY");
		}
	}

	private void method_11(Coordinate coordinate_0, TextWriter textWriter_0)
	{
		textWriter_0.Write(method_12(coordinate_0.X) + " " + method_12(coordinate_0.Y));
	}

	private string method_12(double double_0)
	{
		return double_0.ToString("N", numberFormatInfo_0);
	}

	private void method_13(IBasicLineString ibasicLineString_0, int int_0, bool bool_1, TextWriter textWriter_0)
	{
		if (ibasicLineString_0.Coordinates.Count != 0)
		{
			if (bool_1)
			{
				Indent(int_0, textWriter_0);
			}
			textWriter_0.Write("(");
			for (int i = 0; i < ibasicLineString_0.NumPoints; i++)
			{
				if (i > 0)
				{
					textWriter_0.Write(", ");
					if (i % 10 == 0)
					{
						Indent(int_0 + 2, textWriter_0);
					}
				}
				method_11(ibasicLineString_0.Coordinates[i], textWriter_0);
			}
			textWriter_0.Write(")");
		}
		else
		{
			textWriter_0.Write("EMPTY");
		}
	}

	private void method_14(IPolygon ipolygon_0, int int_0, bool bool_1, TextWriter textWriter_0)
	{
		if (!ipolygon_0.IsEmpty)
		{
			if (bool_1)
			{
				Indent(int_0, textWriter_0);
			}
			textWriter_0.Write("(");
			method_13(ipolygon_0.Shell, int_0, bool_1: false, textWriter_0);
			for (int i = 0; i < ipolygon_0.NumHoles; i++)
			{
				textWriter_0.Write(", ");
				method_13(ipolygon_0.GetInteriorRingN(i), int_0 + 1, bool_1: true, textWriter_0);
			}
			textWriter_0.Write(")");
		}
		else
		{
			textWriter_0.Write("EMPTY");
		}
	}

	private void method_15(IGeometry igeometry_0, TextWriter textWriter_0)
	{
		if (!igeometry_0.IsEmpty)
		{
			textWriter_0.Write("(");
			for (int i = 0; i < igeometry_0.NumGeometries; i++)
			{
				if (i > 0)
				{
					textWriter_0.Write(", ");
				}
				method_11(((Point)igeometry_0.GetGeometryN(i)).Coordinate, textWriter_0);
			}
			textWriter_0.Write(")");
		}
		else
		{
			textWriter_0.Write("EMPTY");
		}
	}

	private void method_16(IMultiLineString imultiLineString_0, int int_0, bool bool_1, TextWriter textWriter_0)
	{
		if (!imultiLineString_0.IsEmpty)
		{
			int int_1 = int_0;
			bool bool_2 = bool_1;
			textWriter_0.Write("(");
			for (int i = 0; i < imultiLineString_0.NumGeometries; i++)
			{
				if (i > 0)
				{
					textWriter_0.Write(", ");
					int_1 = int_0 + 1;
					bool_2 = true;
				}
				method_13((LineString)imultiLineString_0.GetGeometryN(i), int_1, bool_2, textWriter_0);
			}
			textWriter_0.Write(")");
		}
		else
		{
			textWriter_0.Write("EMPTY");
		}
	}

	private void method_17(IMultiPolygon imultiPolygon_0, int int_0, TextWriter textWriter_0)
	{
		if (imultiPolygon_0.IsEmpty)
		{
			textWriter_0.Write("EMPTY");
			return;
		}
		int int_1 = int_0;
		bool bool_ = false;
		textWriter_0.Write("(");
		for (int i = 0; i < imultiPolygon_0.NumGeometries; i++)
		{
			if (i > 0)
			{
				textWriter_0.Write(", ");
				int_1 = int_0 + 1;
				bool_ = true;
			}
			method_14((Polygon)imultiPolygon_0.GetGeometryN(i), int_1, bool_, textWriter_0);
		}
		textWriter_0.Write(")");
	}

	private void method_18(GInterface6 ginterface6_0, int int_0, TextWriter textWriter_0)
	{
		if (!ginterface6_0.IsEmpty)
		{
			int int_1 = int_0;
			textWriter_0.Write("(");
			for (int i = 0; i < ginterface6_0.NumGeometries; i++)
			{
				if (i > 0)
				{
					textWriter_0.Write(", ");
					int_1 = int_0 + 1;
				}
				method_1(ginterface6_0.GetGeometryN(i), int_1, textWriter_0);
			}
			textWriter_0.Write(")");
		}
		else
		{
			textWriter_0.Write("EMPTY");
		}
	}

	private void Indent(int level, TextWriter writer)
	{
		if (bool_0 && level > 0)
		{
			writer.Write("\n");
			writer.Write(StringOfChar(' ', 2 * level));
		}
	}

	static WktWriter()
	{
		Class72.smethod_20();
	}
}
