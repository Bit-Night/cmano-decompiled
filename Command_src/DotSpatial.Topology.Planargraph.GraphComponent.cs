using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public abstract class GraphComponent
{
	private bool bool_0;

	private bool bool_1;

	public virtual bool IsVisited
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = true;
		}
	}

	public virtual bool IsMarked
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = true;
		}
	}

	public abstract bool IsRemoved { get; }

	public static void SetVisited(IEnumerator i, bool visited)
	{
		while (i.MoveNext())
		{
			((GraphComponent)i.Current).IsVisited = visited;
		}
	}

	public static void SetMarked(IEnumerator i, bool marked)
	{
		while (i.MoveNext())
		{
			((GraphComponent)i.Current).IsMarked = marked;
		}
	}

	public static GraphComponent GetComponentWithVisitedState(IEnumerator i, bool visitedState)
	{
		while (i.MoveNext())
		{
			GraphComponent graphComponent = (GraphComponent)i.Current;
			if (graphComponent.IsVisited == visitedState)
			{
				return graphComponent;
			}
		}
		return null;
	}

	static GraphComponent()
	{
		Class72.smethod_20();
	}
}
