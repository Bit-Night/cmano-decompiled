using System.Collections;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology.Noding;

public class IteratedNoder : INoder
{
	public const int MAX_ITERATIONS = 5;

	private readonly LineIntersector lineIntersector_0;

	private int int_0 = 5;

	private IList ilist_0;

	public int MaximumIterations
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

	public IteratedNoder(PrecisionModel pm)
	{
		lineIntersector_0 = new RobustLineIntersector();
		lineIntersector_0.PrecisionModel = pm;
	}

	public IList GetNodedSubstrings()
	{
		return ilist_0;
	}

	public void ComputeNodes(IList segStrings)
	{
		int[] array = new int[1];
		ilist_0 = segStrings;
		int num = 0;
		int num2 = -1;
		while (true)
		{
			Node(ilist_0, array);
			num++;
			int num3 = array[0];
			if (num2 > 0 && num3 >= num2 && num > int_0)
			{
				break;
			}
			num2 = num3;
			if (num2 <= 0)
			{
				return;
			}
		}
		throw new TopologyException("Iterated noding failed to converge after " + num + " iterations");
	}

	private void Node(IList segStrings, int[] numInteriorIntersections)
	{
		IntersectionAdder intersectionAdder = new IntersectionAdder(lineIntersector_0);
		McIndexNoder mcIndexNoder = new McIndexNoder(intersectionAdder);
		mcIndexNoder.ComputeNodes(segStrings);
		ilist_0 = mcIndexNoder.GetNodedSubstrings();
		numInteriorIntersections[0] = intersectionAdder.NumInteriorIntersections;
	}

	static IteratedNoder()
	{
		Class72.smethod_20();
	}
}
