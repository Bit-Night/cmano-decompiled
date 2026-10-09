using System.Collections;
using DotSpatial.Topology.Planargraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Linemerge;

public class LineMerger
{
	private class Class53 : IGeometryComponentFilter
	{
		private readonly LineMerger haweIefLdc0;

		public Class53(LineMerger lineMerger_0)
		{
			haweIefLdc0 = lineMerger_0;
		}

		public void Filter(IGeometry component)
		{
			if (component is LineString)
			{
				haweIefLdc0.Add((LineString)component);
			}
		}

		static Class53()
		{
			Class72.smethod_20();
		}
	}

	private readonly LineMergeGraph lineMergeGraph_0 = new LineMergeGraph();

	private IList ilist_0;

	private IGeometryFactory igeometryFactory_0;

	private IList ilist_1;

	public virtual IList MergedLineStrings
	{
		get
		{
			Merge();
			return ilist_1;
		}
	}

	public virtual void Add(IList geometries)
	{
		IEnumerator enumerator = geometries.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Geometry geometry = (Geometry)enumerator.Current;
			Add(geometry);
		}
	}

	public virtual void Add(Geometry geometry)
	{
		geometry.Apply(new Class53(this));
	}

	private void Add(LineString lineString)
	{
		if (igeometryFactory_0 == null)
		{
			igeometryFactory_0 = lineString.Factory;
		}
		lineMergeGraph_0.AddEdge(lineString);
	}

	private void Merge()
	{
		if (ilist_1 == null)
		{
			ilist_0 = new ArrayList();
			HyBePfgSsfP();
			method_0();
			ilist_1 = new ArrayList();
			IEnumerator enumerator = ilist_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeString edgeString = (EdgeString)enumerator.Current;
				ilist_1.Add(edgeString.ToLineString());
			}
		}
	}

	private void HyBePfgSsfP()
	{
		method_2();
	}

	private void method_0()
	{
		method_1();
	}

	private void method_1()
	{
		IEnumerator enumerator = lineMergeGraph_0.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (!node.IsMarked)
			{
				Assert.IsTrue(node.Degree == 2);
				method_3(node);
				node.IsMarked = true;
			}
		}
	}

	private void method_2()
	{
		IEnumerator enumerator = lineMergeGraph_0.Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node node = (Node)enumerator.Current;
			if (node.Degree != 2)
			{
				method_3(node);
				node.IsMarked = true;
			}
		}
	}

	private void method_3(Node node_0)
	{
		IEnumerator enumerator = node_0.OutEdges.GetEnumerator();
		while (enumerator.MoveNext())
		{
			LineMergeDirectedEdge lineMergeDirectedEdge = (LineMergeDirectedEdge)enumerator.Current;
			if (!lineMergeDirectedEdge.Edge.IsMarked)
			{
				ilist_0.Add(method_4(lineMergeDirectedEdge));
			}
		}
	}

	private EdgeString method_4(LineMergeDirectedEdge lineMergeDirectedEdge_0)
	{
		EdgeString edgeString = new EdgeString(igeometryFactory_0);
		LineMergeDirectedEdge lineMergeDirectedEdge = lineMergeDirectedEdge_0;
		do
		{
			edgeString.Add(lineMergeDirectedEdge);
			lineMergeDirectedEdge.Edge.IsMarked = true;
			lineMergeDirectedEdge = lineMergeDirectedEdge.Next;
		}
		while (lineMergeDirectedEdge != null && lineMergeDirectedEdge != lineMergeDirectedEdge_0);
		return edgeString;
	}

	static LineMerger()
	{
		Class72.smethod_20();
	}
}
