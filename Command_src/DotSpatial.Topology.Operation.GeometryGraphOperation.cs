using System.Runtime.CompilerServices;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation;

public class GeometryGraphOperation
{
	protected readonly GeometryGraph[] Arg;

	private LineIntersector lineIntersector_0 = new RobustLineIntersector();

	[CompilerGenerated]
	private PrecisionModel precisionModel_0;

	protected LineIntersector LineIntersector
	{
		get
		{
			return lineIntersector_0;
		}
		set
		{
			lineIntersector_0 = value;
		}
	}

	protected PrecisionModel ResultPrecisionModel
	{
		[CompilerGenerated]
		get
		{
			return precisionModel_0;
		}
		[CompilerGenerated]
		set
		{
			precisionModel_0 = value;
		}
	}

	protected PrecisionModel ComputationPrecision
	{
		get
		{
			return ResultPrecisionModel;
		}
		set
		{
			ResultPrecisionModel = value;
			LineIntersector.PrecisionModel = ResultPrecisionModel;
		}
	}

	public GeometryGraphOperation(IGeometry g0, IGeometry g1)
	{
		ComputationPrecision = ((g0.PrecisionModel.CompareTo(g1.PrecisionModel) < 0) ? new PrecisionModel(g1.PrecisionModel) : new PrecisionModel(g0.PrecisionModel));
		Arg = new GeometryGraph[2];
		Arg[0] = new GeometryGraph(0, g0);
		Arg[1] = new GeometryGraph(1, g1);
	}

	public GeometryGraphOperation(IGeometry g0)
	{
		ComputationPrecision = new PrecisionModel(g0.PrecisionModel);
		Arg = new GeometryGraph[1];
		Arg[0] = new GeometryGraph(0, g0);
	}

	public IGeometry GetArgGeometry(int i)
	{
		return Arg[i].Geometry;
	}

	static GeometryGraphOperation()
	{
		Class72.smethod_20();
	}
}
