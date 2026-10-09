using System;

namespace DotSpatial.Topology.Precision;

public class EnhancedPrecisionOp
{
	private EnhancedPrecisionOp()
	{
	}

	public static IGeometry Intersection(IGeometry geom0, IGeometry geom1)
	{
		ApplicationException ex2;
		try
		{
			return geom0.Intersection(geom1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(returnToOriginalPrecision: true).Intersection(geom0, geom1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	public static IGeometry Union(IGeometry geom0, IGeometry geom1)
	{
		ApplicationException ex2;
		try
		{
			return geom0.Union(geom1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(returnToOriginalPrecision: true).Union(geom0, geom1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	public static IGeometry Difference(IGeometry geom0, IGeometry geom1)
	{
		ApplicationException ex2;
		try
		{
			return geom0.Difference(geom1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(returnToOriginalPrecision: true).Difference(geom0, geom1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	public static IGeometry SymDifference(IGeometry geom0, IGeometry geom1)
	{
		ApplicationException ex2;
		try
		{
			return geom0.SymmetricDifference(geom1);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(returnToOriginalPrecision: true).SymDifference(geom0, geom1);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	[Obsolete("This method should no longer be necessary, since the buffer algorithm now is highly robust.")]
	public static IGeometry Buffer(Geometry geom, double distance)
	{
		ApplicationException ex2;
		try
		{
			return (Geometry)geom.Buffer(distance);
		}
		catch (ApplicationException ex)
		{
			ex2 = ex;
		}
		try
		{
			IGeometry geometry = new CommonBitsOp(returnToOriginalPrecision: true).Buffer(geom, distance);
			if (!geometry.IsValid)
			{
				throw ex2;
			}
			return geometry;
		}
		catch (ApplicationException)
		{
			throw ex2;
		}
	}

	static EnhancedPrecisionOp()
	{
		Class72.smethod_20();
	}
}
