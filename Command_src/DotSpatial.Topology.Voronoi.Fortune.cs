using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotSpatial.Topology.Voronoi;

public abstract class Fortune
{
	public static readonly Vector2 VVUnkown;

	public static readonly Vector2 vector2_0;

	public static bool DoCleanup;

	internal static double ParabolicCut(double x1, double y1, double x2, double y2, double ys)
	{
		if (x1 == x2 && y1 == y2)
		{
			throw new ArgumentException("Identical datapoints are not allowed!");
		}
		if (y1 == ys && y2 == ys)
		{
			return (x1 + x2) / 2.0;
		}
		if (y1 == ys)
		{
			return x1;
		}
		if (y2 == ys)
		{
			return x2;
		}
		double num = 1.0 / (2.0 * (y1 - ys));
		double num2 = 1.0 / (2.0 * (y2 - ys));
		if (num == num2)
		{
			return (x1 + x2) / 2.0;
		}
		double num3 = Math.Sqrt(-8.0 * num * x1 * num2 * x2 - 2.0 * num * y1 + 2.0 * num * y2 + 4.0 * num * num2 * x2 * x2 + 2.0 * num2 * y1 + 4.0 * num2 * num * x1 * x1 - 2.0 * num2 * y2);
		double num4 = 0.5 / (2.0 * num - 2.0 * num2) * (4.0 * num * x1 - 4.0 * num2 * x2 + 2.0 * num3);
		double num5 = 0.5 / (2.0 * num - 2.0 * num2) * (4.0 * num * x1 - 4.0 * num2 * x2 - 2.0 * num3);
		if (num4 > num5)
		{
			double num6 = num4;
			num4 = num5;
			num5 = num6;
		}
		if (!(y1 >= y2))
		{
			return num4;
		}
		return num5;
	}

	internal static Vector2 CircumCircleCenter(Vector2 a, Vector2 b, Vector2 c)
	{
		if (!(a == b) && !(b == c) && !(a == c))
		{
			double num = (a.X + c.X) / 2.0;
			double num2 = (a.Y + c.Y) / 2.0;
			double num3 = (b.X + c.X) / 2.0;
			double num4 = (b.Y + c.Y) / 2.0;
			double num5;
			double num6;
			if (a.X == c.X)
			{
				num5 = 1.0;
				num6 = 0.0;
			}
			else
			{
				num5 = (c.Y - a.Y) / (a.X - c.X);
				num6 = 1.0;
			}
			double num7;
			double num8;
			if (b.X == c.X)
			{
				num7 = -1.0;
				num8 = 0.0;
			}
			else
			{
				num7 = (b.Y - c.Y) / (b.X - c.X);
				num8 = -1.0;
			}
			double num9 = (num8 * (num3 - num) - num7 * (num4 - num2)) / (num5 * num8 - num7 * num6);
			return new Vector2(num + num9 * num5, num2 + num9 * num6);
		}
		throw new ArgumentException("Need three different points!");
	}

	public static VoronoiGraph ComputeVoronoiGraph(double[] vertices, double tolerance, bool cleanup)
	{
		Vector2.Tolerance = tolerance;
		DoCleanup = cleanup;
		return ComputeVoronoiGraph(vertices);
	}

	public static VoronoiGraph ComputeVoronoiGraph(double[] vertices)
	{
		SortedDictionary<VEvent, VEvent> sortedDictionary = new SortedDictionary<VEvent, VEvent>();
		Dictionary<VDataNode, VCircleEvent> dictionary = new Dictionary<VDataNode, VCircleEvent>();
		VoronoiGraph voronoiGraph = new VoronoiGraph();
		VNode root = null;
		for (int i = 0; i < vertices.Length / 2; i++)
		{
			VDataEvent vDataEvent = new VDataEvent(new Vector2(vertices, i * 2));
			if (!sortedDictionary.ContainsKey(vDataEvent))
			{
				sortedDictionary.Add(vDataEvent, vDataEvent);
			}
		}
		VEvent key;
		while (true)
		{
			if (sortedDictionary.Count > 0)
			{
				key = sortedDictionary.First().Key;
				sortedDictionary.Remove(key);
				VDataNode[] circleCheckList = new VDataNode[0];
				if (!(key is VDataEvent))
				{
					if (!(key is VCircleEvent))
					{
						if (key != null)
						{
							break;
						}
					}
					else
					{
						dictionary.Remove(((VCircleEvent)key).NodeN);
						if (!((VCircleEvent)key).Valid)
						{
							continue;
						}
						root = VNode.ProcessCircleEvent(key as VCircleEvent, root, voronoiGraph, out circleCheckList);
					}
				}
				else
				{
					root = VNode.ProcessDataEvent(key as VDataEvent, root, voronoiGraph, key.Y, out circleCheckList);
				}
				VDataNode[] array = circleCheckList;
				foreach (VDataNode vDataNode in array)
				{
					if (dictionary.ContainsKey(vDataNode))
					{
						dictionary[vDataNode].Valid = false;
						dictionary.Remove(vDataNode);
					}
					if (key != null)
					{
						VCircleEvent vCircleEvent = VNode.CircleCheckDataNode(vDataNode, key.Y);
						if (vCircleEvent != null)
						{
							sortedDictionary.Add(vCircleEvent, vCircleEvent);
							dictionary[vDataNode] = vCircleEvent;
						}
					}
				}
				if (!(key is VDataEvent))
				{
					continue;
				}
				Vector2 dataPoint = ((VDataEvent)key).DataPoint;
				foreach (VCircleEvent value in dictionary.Values)
				{
					if (MathTools.Dist(dataPoint.X, dataPoint.Y, value.Center.X, value.Center.Y) < value.Y - value.Center.Y && Math.Abs(MathTools.Dist(dataPoint.X, dataPoint.Y, value.Center.X, value.Center.Y) - (value.Y - value.Center.Y)) > 1E-10)
					{
						value.Valid = false;
					}
				}
				continue;
			}
			if (!DoCleanup)
			{
				return voronoiGraph;
			}
			VNode.CleanUpTree(root);
			foreach (VoronoiEdge edge in voronoiGraph.Edges)
			{
				if (!edge.Done && !(edge.VVertexB != VVUnkown))
				{
					edge.AddVertex(vector2_0);
					if (Math.Abs(edge.LeftData.Y - edge.RightData.Y) < 1E-10 && edge.LeftData.X < edge.RightData.X)
					{
						Vector2 leftData = edge.LeftData;
						edge.LeftData = edge.RightData;
						edge.RightData = leftData;
					}
				}
			}
			ArrayList arrayList = new ArrayList();
			foreach (VoronoiEdge edge2 in voronoiGraph.Edges)
			{
				if (edge2.IsPartlyInfinite || !edge2.VVertexA.Equals(edge2.VVertexB))
				{
					continue;
				}
				arrayList.Add(edge2);
				foreach (VoronoiEdge edge3 in voronoiGraph.Edges)
				{
					if (edge3.VVertexA.Equals(edge2.VVertexA))
					{
						edge3.VVertexA = edge2.VVertexA;
					}
					if (edge3.VVertexB.Equals(edge2.VVertexA))
					{
						edge3.VVertexB = edge2.VVertexA;
					}
				}
			}
			foreach (VoronoiEdge item in arrayList)
			{
				voronoiGraph.Edges.Remove(item);
			}
			return voronoiGraph;
		}
		throw new Exception("Got event of type " + key.GetType()?.ToString() + "!");
	}

	public static VoronoiGraph FilterVg(VoronoiGraph vg, double minLeftRightDist)
	{
		VoronoiGraph voronoiGraph = new VoronoiGraph();
		foreach (VoronoiEdge edge in vg.Edges)
		{
			if (edge.LeftData.Distance(edge.RightData) >= minLeftRightDist)
			{
				voronoiGraph.Edges.Add(edge);
			}
		}
		foreach (VoronoiEdge edge2 in voronoiGraph.Edges)
		{
			voronoiGraph.Vertices.Add(edge2.VVertexA);
			voronoiGraph.Vertices.Add(edge2.VVertexB);
		}
		return voronoiGraph;
	}

	static Fortune()
	{
		Class72.smethod_20();
		VVUnkown = new Vector2(double.NaN, double.NaN);
		vector2_0 = new Vector2(double.PositiveInfinity, double.PositiveInfinity);
	}
}
