using System;
using DotSpatial.Topology.Precision;

namespace DotSpatial.Topology.Operation.Buffer;

public class BufferOp
{
	private readonly IGeometry igeometry_0;

	private double double_0;

	private BufferStyle bufferStyle_0 = BufferStyle.CapRound;

	private int int_0 = 8;

	private IGeometry igeometry_1;

	private TopologyException topologyException_0;

	public virtual BufferStyle EndCapStyle
	{
		get
		{
			return bufferStyle_0;
		}
		set
		{
			bufferStyle_0 = value;
		}
	}

	public virtual int QuadrantSegments
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public BufferOp(IGeometry g)
	{
		igeometry_0 = g;
	}

	private static double smethod_0(IGeometry igeometry_2, double double_1, int int_1)
	{
		IEnvelope envelopeInternal = igeometry_2.EnvelopeInternal;
		double num = Math.Max(envelopeInternal.Height, envelopeInternal.Width);
		double num2 = ((double_1 > 0.0) ? double_1 : 0.0);
		int num3 = (int)(Math.Log(num + 2.0 * num2) / Math.Log(10.0) + 1.0) - int_1;
		return Math.Pow(10.0, -num3);
	}

	public static IGeometry Buffer(IGeometry g, double distance)
	{
		return new BufferOp(g).GetResultGeometry(distance);
	}

	public static IGeometry Buffer(Geometry g, double distance, BufferStyle endCapStyle)
	{
		return new BufferOp(g)
		{
			EndCapStyle = endCapStyle
		}.GetResultGeometry(distance);
	}

	public static IGeometry Buffer(Geometry g, double distance, int quadrantSegments)
	{
		return new BufferOp(g)
		{
			QuadrantSegments = quadrantSegments
		}.GetResultGeometry(distance);
	}

	public static IGeometry Buffer(IGeometry g, double distance, int quadrantSegments, BufferStyle endCapStyle)
	{
		return new BufferOp(g)
		{
			EndCapStyle = endCapStyle,
			QuadrantSegments = quadrantSegments
		}.GetResultGeometry(distance);
	}

	public virtual IGeometry GetResultGeometry(double distance)
	{
		double_0 = distance;
		method_0();
		return igeometry_1;
	}

	public virtual IGeometry GetResultGeometry(double distance, int quadrantSegments)
	{
		double_0 = distance;
		QuadrantSegments = quadrantSegments;
		method_0();
		return igeometry_1;
	}

	private void method_0()
	{
		method_1();
		if (igeometry_1 != null)
		{
			return;
		}
		int num = 12;
		while (true)
		{
			if (num >= 0)
			{
				try
				{
					method_2(num);
				}
				catch (TopologyException ex)
				{
					topologyException_0 = ex;
				}
				if (igeometry_1 == null)
				{
					num--;
					continue;
				}
				break;
			}
			throw topologyException_0;
		}
	}

	private void method_1()
	{
		try
		{
			BufferBuilder bufferBuilder = new BufferBuilder();
			bufferBuilder.QuadrantSegments = int_0;
			bufferBuilder.EndCapStyle = bufferStyle_0;
			igeometry_1 = bufferBuilder.Buffer(igeometry_0, double_0);
		}
		catch (TopologyException ex)
		{
			topologyException_0 = ex;
		}
	}

	private void method_2(int int_1)
	{
		PrecisionModel precisionModel = new PrecisionModel(smethod_0(igeometry_0, double_0, int_1));
		IGeometry g = new SimpleGeometryPrecisionReducer(precisionModel).Reduce(igeometry_0);
		BufferBuilder bufferBuilder = new BufferBuilder();
		bufferBuilder.WorkingPrecisionModel = precisionModel;
		bufferBuilder.QuadrantSegments = int_0;
		igeometry_1 = bufferBuilder.Buffer(g, double_0);
	}

	static BufferOp()
	{
		Class72.smethod_20();
	}
}
