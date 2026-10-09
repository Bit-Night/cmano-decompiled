using System.Collections;

namespace DotSpatial.Topology.Planargraph;

public class NodeMap
{
	private readonly IDictionary idictionary_0 = new SortedList();

	public virtual ICollection Values => idictionary_0.Values;

	public virtual Node Add(Node n)
	{
		Coordinate coordinate = n.Coordinate;
		if (!idictionary_0.Contains(coordinate))
		{
			idictionary_0.Add(coordinate, n);
		}
		return n;
	}

	public virtual Node Remove(Coordinate pt)
	{
		Node result = (Node)idictionary_0[pt];
		idictionary_0.Remove(pt);
		return result;
	}

	public virtual Node Find(Coordinate coord)
	{
		return (Node)idictionary_0[coord];
	}

	public virtual IEnumerator GetEnumerator()
	{
		return idictionary_0.Values.GetEnumerator();
	}

	static NodeMap()
	{
		Class72.smethod_20();
	}
}
