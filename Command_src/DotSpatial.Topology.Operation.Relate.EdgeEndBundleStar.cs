using System.Collections;
using DotSpatial.Topology.GeometriesGraph;

namespace DotSpatial.Topology.Operation.Relate;

public class EdgeEndBundleStar : EdgeEndStar
{
	public override void Insert(EdgeEnd e)
	{
		EdgeEndBundle edgeEndBundle = (EdgeEndBundle)base.EdgeMap[e];
		if (edgeEndBundle == null)
		{
			edgeEndBundle = new EdgeEndBundle(e);
			InsertEdgeEnd(e, edgeEndBundle);
		}
		else
		{
			edgeEndBundle.Insert(e);
		}
	}

	public virtual void UpdateIm(IntersectionMatrix im)
	{
		IEnumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			((EdgeEndBundle)enumerator.Current).UpdateIm(im);
		}
	}

	static EdgeEndBundleStar()
	{
		Class72.smethod_20();
	}
}
