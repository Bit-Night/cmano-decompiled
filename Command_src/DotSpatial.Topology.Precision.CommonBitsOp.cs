namespace DotSpatial.Topology.Precision;

public class CommonBitsOp
{
	private readonly bool bool_0 = true;

	private CommonBitsRemover commonBitsRemover_0;

	public CommonBitsOp()
		: this(returnToOriginalPrecision: true)
	{
	}

	public CommonBitsOp(bool returnToOriginalPrecision)
	{
		bool_0 = returnToOriginalPrecision;
	}

	public virtual IGeometry Intersection(IGeometry geom0, IGeometry geom1)
	{
		IGeometry[] array = method_2(geom0, geom1);
		return method_0(array[0].Intersection(array[1]));
	}

	public virtual IGeometry Union(IGeometry geom0, IGeometry geom1)
	{
		IGeometry[] array = method_2(geom0, geom1);
		return method_0(array[0].Union(array[1]));
	}

	public virtual IGeometry Difference(IGeometry geom0, IGeometry geom1)
	{
		IGeometry[] array = method_2(geom0, geom1);
		return method_0(array[0].Difference(array[1]));
	}

	public virtual IGeometry SymDifference(IGeometry geom0, IGeometry geom1)
	{
		IGeometry[] array = method_2(geom0, geom1);
		return method_0(array[0].SymmetricDifference(array[1]));
	}

	public virtual IGeometry Buffer(IGeometry geom0, double distance)
	{
		IGeometry geometry = method_1(geom0);
		return method_0(geometry.Buffer(distance));
	}

	private IGeometry method_0(IGeometry igeometry_0)
	{
		if (bool_0)
		{
			commonBitsRemover_0.AddCommonBits(igeometry_0);
		}
		return igeometry_0;
	}

	private IGeometry method_1(IGeometry igeometry_0)
	{
		commonBitsRemover_0 = new CommonBitsRemover();
		commonBitsRemover_0.Add(igeometry_0);
		return commonBitsRemover_0.RemoveCommonBits((Geometry)igeometry_0.Clone());
	}

	private IGeometry[] method_2(IGeometry igeometry_0, IGeometry igeometry_1)
	{
		commonBitsRemover_0 = new CommonBitsRemover();
		commonBitsRemover_0.Add(igeometry_0);
		commonBitsRemover_0.Add(igeometry_1);
		IGeometry[] array = new Geometry[2];
		array[0] = commonBitsRemover_0.RemoveCommonBits((Geometry)igeometry_0.Clone());
		array[1] = commonBitsRemover_0.RemoveCommonBits((Geometry)igeometry_1.Clone());
		return array;
	}

	static CommonBitsOp()
	{
		Class72.smethod_20();
	}
}
