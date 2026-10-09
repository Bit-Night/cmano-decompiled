using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class RelateNodeGraph
{
	private readonly NodeMap nodeMap_0 = new NodeMap(new RelateNodeFactory());

	public virtual IEnumerator GetNodeEnumerator()
	{
		return nodeMap_0.GetEnumerator();
	}

	public virtual void Build(GeometryGraph geomGraph)
	{
		ComputeIntersectionNodes(geomGraph, 0);
		CopyNodesAndLabels(geomGraph, 0);
		IList ee = new EdgeEndBuilder().ComputeEdgeEnds(geomGraph.GetEdgeEnumerator());
		InsertEdgeEnds(ee);
	}

	public virtual void ComputeIntersectionNodes(GeometryGraph geomGraph, int argIndex)
	{
		IEnumerator edgeEnumerator = geomGraph.GetEdgeEnumerator();
		while (edgeEnumerator.MoveNext())
		{
			Edge obj = (Edge)edgeEnumerator.Current;
			LocationType location = obj.Label.GetLocation(argIndex);
			IEnumerator enumerator = obj.EdgeIntersectionList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				EdgeIntersection edgeIntersection = (EdgeIntersection)enumerator.Current;
				RelateNode relateNode = (RelateNode)nodeMap_0.AddNode(edgeIntersection.Coordinate);
				if (location == LocationType.Boundary)
				{
					relateNode.SetLabelBoundary(argIndex);
				}
				else if (relateNode.Label.IsNull(argIndex))
				{
					relateNode.SetLabel(argIndex, LocationType.Interior);
				}
			}
		}
	}

	public virtual void CopyNodesAndLabels(GeometryGraph geomGraph, int argIndex)
	{
		IEnumerator nodeEnumerator = geomGraph.GetNodeEnumerator();
		while (nodeEnumerator.MoveNext())
		{
			Node node = (Node)nodeEnumerator.Current;
			nodeMap_0.AddNode(node.Coordinate).SetLabel(argIndex, node.Label.GetLocation(argIndex));
		}
	}

	public virtual void InsertEdgeEnds(IList ee)
	{
		IEnumerator enumerator = ee.GetEnumerator();
		while (enumerator.MoveNext())
		{
			EdgeEnd e = (EdgeEnd)enumerator.Current;
			nodeMap_0.Add(e);
		}
	}

	static RelateNodeGraph()
	{
		Class72.smethod_20();
	}
}
