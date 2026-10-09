using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Simplify;

public class TopologyPreservingSimplifier
{
	private class Class51 : IGeometryComponentFilter
	{
		private readonly TopologyPreservingSimplifier topologyPreservingSimplifier_0;

		public Class51(TopologyPreservingSimplifier topologyPreservingSimplifier_1)
		{
			topologyPreservingSimplifier_0 = topologyPreservingSimplifier_1;
		}

		public void Filter(IGeometry geom)
		{
			if (geom is LinearRing)
			{
				TaggedLineString value = new TaggedLineString((LineString)geom, 4);
				topologyPreservingSimplifier_0.idictionary_0.Add(geom, value);
			}
			else if (geom is LineString)
			{
				TaggedLineString value2 = new TaggedLineString((LineString)geom, 2);
				topologyPreservingSimplifier_0.idictionary_0.Add(geom, value2);
			}
		}

		static Class51()
		{
			Class72.smethod_20();
		}
	}

	private class Class50 : GeometryTransformer
	{
		private readonly TopologyPreservingSimplifier topologyPreservingSimplifier_0;

		public Class50(TopologyPreservingSimplifier topologyPreservingSimplifier_1)
		{
			topologyPreservingSimplifier_0 = topologyPreservingSimplifier_1;
		}

		protected override IList<Coordinate> TransformCoordinates(IList<Coordinate> coords, IGeometry parent)
		{
			if (!(parent is LineString))
			{
				return base.TransformCoordinates(coords, parent);
			}
			return ((TaggedLineString)topologyPreservingSimplifier_0.idictionary_0[parent]).ResultCoordinates;
		}

		static Class50()
		{
			Class72.smethod_20();
		}
	}

	private readonly IGeometry PkkeGbRuxwl;

	private readonly TaggedLinesSimplifier taggedLinesSimplifier_0 = new TaggedLinesSimplifier();

	private IDictionary idictionary_0;

	public virtual double DistanceTolerance
	{
		get
		{
			return taggedLinesSimplifier_0.DistanceTolerance;
		}
		set
		{
			taggedLinesSimplifier_0.DistanceTolerance = value;
		}
	}

	public TopologyPreservingSimplifier(IGeometry inputGeom)
	{
		PkkeGbRuxwl = inputGeom;
	}

	public static IGeometry Simplify(IGeometry geom, double distanceTolerance)
	{
		return new TopologyPreservingSimplifier(geom)
		{
			DistanceTolerance = distanceTolerance
		}.GetResultGeometry();
	}

	public virtual IGeometry GetResultGeometry()
	{
		idictionary_0 = new Hashtable();
		PkkeGbRuxwl.Apply(new Class51(this));
		taggedLinesSimplifier_0.Simplify(new ArrayList(idictionary_0.Values));
		return new Class50(this).Transform(PkkeGbRuxwl);
	}

	static TopologyPreservingSimplifier()
	{
		Class72.smethod_20();
	}
}
