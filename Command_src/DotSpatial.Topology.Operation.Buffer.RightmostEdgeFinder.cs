using System.Collections;
using System.Collections.Generic;
using DotSpatial.Topology.Algorithm;
using DotSpatial.Topology.GeometriesGraph;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Operation.Buffer;

public sealed class RightmostEdgeFinder
{
	private Coordinate coordinate_0;

	private DirectedEdge directedEdge_0;

	private int int_0 = -1;

	private DirectedEdge directedEdge_1;

	public DirectedEdge Edge => directedEdge_1;

	public Coordinate Coordinate => coordinate_0;

	public void FindEdge(IList dirEdgeList)
	{
		IEnumerator enumerator = dirEdgeList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			DirectedEdge directedEdge = (DirectedEdge)enumerator.Current;
			if (directedEdge.IsForward)
			{
				method_2(directedEdge);
			}
		}
		Assert.IsTrue(int_0 != 0 || coordinate_0.Equals(directedEdge_0.Coordinate), "inconsistency in rightmost processing");
		if (int_0 == 0)
		{
			method_0();
		}
		else
		{
			method_1();
		}
		directedEdge_1 = directedEdge_0;
		if (method_3(directedEdge_0, int_0) == PositionType.Left)
		{
			directedEdge_1 = directedEdge_0.Sym;
		}
	}

	private void method_0()
	{
		DirectedEdgeStar directedEdgeStar = (DirectedEdgeStar)directedEdge_0.Node.Edges;
		directedEdge_0 = directedEdgeStar.GetRightmostEdge();
		if (!directedEdge_0.IsForward)
		{
			directedEdge_0 = directedEdge_0.Sym;
			int_0 = directedEdge_0.Edge.Coordinates.Count - 1;
		}
	}

	private void method_1()
	{
		IList<Coordinate> coordinates = directedEdge_0.Edge.Coordinates;
		Assert.IsTrue(int_0 > 0 && int_0 < coordinates.Count, "rightmost point expected to be interior vertex of edge");
		Coordinate coordinate = coordinates[int_0 - 1];
		Coordinate coordinate2 = coordinates[int_0 + 1];
		int num = CgAlgorithms.ComputeOrientation(coordinate_0, coordinate2, coordinate);
		bool flag = false;
		if (coordinate.Y < coordinate_0.Y && coordinate2.Y < coordinate_0.Y && num == 1)
		{
			flag = true;
		}
		else if (coordinate.Y > coordinate_0.Y && coordinate2.Y > coordinate_0.Y && num == -1)
		{
			flag = true;
		}
		if (flag)
		{
			int_0--;
		}
	}

	private void method_2(DirectedEdge directedEdge_2)
	{
		IList<Coordinate> coordinates = directedEdge_2.Edge.Coordinates;
		for (int i = 0; i < coordinates.Count - 1; i++)
		{
			if (coordinate_0 == null || coordinates[i].X > coordinate_0.X)
			{
				directedEdge_0 = directedEdge_2;
				int_0 = i;
				coordinate_0 = coordinates[i];
			}
		}
	}

	private PositionType method_3(DirectedEdge directedEdge_2, int int_1)
	{
		PositionType positionType = smethod_0(directedEdge_2, int_1);
		if (positionType < PositionType.On)
		{
			positionType = smethod_0(directedEdge_2, int_1 - 1);
		}
		if (positionType < PositionType.On)
		{
			coordinate_0 = null;
			method_2(directedEdge_2);
		}
		return positionType;
	}

	private static PositionType smethod_0(EdgeEnd edgeEnd_0, int int_1)
	{
		IList<Coordinate> coordinates = edgeEnd_0.Edge.Coordinates;
		int result2;
		if (int_1 >= 0)
		{
			if (int_1 + 1 < coordinates.Count)
			{
				if (coordinates[int_1].Y == coordinates[int_1 + 1].Y)
				{
					return PositionType.Parallel;
				}
				PositionType result = PositionType.Left;
				if (coordinates[int_1].Y < coordinates[int_1 + 1].Y)
				{
					result = PositionType.Right;
				}
				return result;
			}
			result2 = -1;
		}
		else
		{
			result2 = -1;
		}
		return (PositionType)result2;
	}

	static RightmostEdgeFinder()
	{
		Class72.smethod_20();
	}
}
