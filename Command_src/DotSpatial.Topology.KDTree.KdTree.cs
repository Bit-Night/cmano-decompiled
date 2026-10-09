using System.Collections.Generic;

namespace DotSpatial.Topology.KDTree;

public class KdTree
{
	private readonly int int_0;

	private int int_1;

	private KdNode kdNode_0;

	public int Count => int_1;

	public int K => int_0;

	public KdTree(int k)
	{
		if (k < 0)
		{
			throw new NegativeArgumentException("k");
		}
		int_0 = k;
		kdNode_0 = null;
	}

	public void Insert(double[] key, object value)
	{
		if (key.Length != int_0)
		{
			throw new KeySizeException();
		}
		kdNode_0 = KdNode.Insert(new HPoint(key), value, kdNode_0, 0, int_0);
		int_1++;
	}

	public object Search(double[] key)
	{
		if (key.Length != int_0)
		{
			throw new KeySizeException();
		}
		return KdNode.Search(new HPoint(key), kdNode_0, int_0)?.V;
	}

	public void Delete(double[] key)
	{
		if (key.Length != int_0)
		{
			throw new KeySizeException();
		}
		(KdNode.Search(new HPoint(key), kdNode_0, int_0) ?? throw new KeyMissingException()).IsDeleted = true;
		int_1--;
	}

	public object Nearest(double[] key)
	{
		return Nearest(key, 1)[0];
	}

	public object[] Nearest(double[] key, int numNeighbors)
	{
		if (numNeighbors >= 0 && numNeighbors <= int_1)
		{
			if (key.Length != int_0)
			{
				throw new KeySizeException();
			}
			object[] array = new object[numNeighbors];
			NearestNeighborList nearestNeighborList = new NearestNeighborList(numNeighbors);
			HRect hr = HRect.InfiniteHRect(key.Length);
			HPoint target = new HPoint(key);
			KdNode.Nnbr(kdNode_0, target, hr, 1.79769E+30, 0, int_0, nearestNeighborList);
			for (int i = 0; i < numNeighbors; i++)
			{
				KdNode kdNode = (KdNode)nearestNeighborList.RemoveHighest();
				array[numNeighbors - i - 1] = kdNode.V;
			}
			return array;
		}
		throw new NeighborsOutOfRangeException();
	}

	public object Farthest(double[] key)
	{
		return Farthest(key, 1)[0];
	}

	public object[] Farthest(double[] key, int numNeighbors)
	{
		if (numNeighbors >= 0 && numNeighbors <= int_1)
		{
			if (key.Length != int_0)
			{
				throw new KeySizeException();
			}
			object[] array = new object[numNeighbors];
			FarthestNeighborList farthestNeighborList = new FarthestNeighborList(numNeighbors);
			HRect hr = HRect.InfiniteHRect(key.Length);
			HPoint target = new HPoint(key);
			KdNode.FarthestNeighbor(kdNode_0, target, hr, 0.0, 0, int_0, farthestNeighborList);
			for (int i = 0; i < numNeighbors; i++)
			{
				KdNode kdNode = (KdNode)farthestNeighborList.RemoveFarthest();
				array[numNeighbors - i - 1] = kdNode.V;
			}
			return array;
		}
		throw new NeighborsOutOfRangeException();
	}

	public object[] SearchRange(double[] lowKey, double[] highKey)
	{
		if (lowKey.Length != highKey.Length)
		{
			throw new KeySizeException();
		}
		if (lowKey.Length != int_0)
		{
			throw new KeySizeException();
		}
		List<KdNode> list = new List<KdNode>();
		KdNode.SearchRange(new HPoint(lowKey), new HPoint(highKey), kdNode_0, 0, int_0, list);
		object[] array = new object[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			KdNode kdNode = list[i];
			array[i] = kdNode.V;
		}
		return array;
	}

	public override string ToString()
	{
		return kdNode_0.ToString(0);
	}

	static KdTree()
	{
		Class72.smethod_20();
	}
}
