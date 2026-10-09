namespace DotSpatial.Topology.Utilities;

public abstract class ShortCircuitedGeometryVisitor
{
	private bool bool_0;

	public void ApplyTo(IGeometry geom)
	{
		for (int i = 0; i < geom.NumGeometries; i++)
		{
			if (bool_0)
			{
				break;
			}
			IGeometry geometryN = geom.GetGeometryN(i);
			if (!(geometryN is GeometryCollection))
			{
				Visit(geometryN);
				if (IsDone())
				{
					bool_0 = true;
					break;
				}
			}
			else
			{
				ApplyTo(geometryN);
			}
		}
	}

	protected abstract void Visit(IGeometry element);

	protected abstract bool IsDone();

	static ShortCircuitedGeometryVisitor()
	{
		Class72.smethod_20();
	}
}
