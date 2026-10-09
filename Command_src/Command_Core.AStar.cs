using System.Collections.Generic;
using System.Linq;
using Algorithms;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class AStar
{
	public class SegmentComparer : IComparer<RoadSystem.Segment>
	{
		public float Heuristic(RoadSystem.Node a, RoadSystem.Node b)
		{
			return 0f;
		}

		public int Compare(RoadSystem.Segment x, RoadSystem.Segment y)
		{
			if (x.CurrentWeight > x.CurrentWeight)
			{
				return 1;
			}
			if (x.CurrentWeight < x.CurrentWeight)
			{
				return -1;
			}
			return 0;
		}

		static SegmentComparer()
		{
			Class72.smethod_20();
		}
	}

	public static List<RoadSystem.Node> Search_Nodes(RoadSystem ParentSystem, RoadSystem.Node startNode, RoadSystem.Node goal, HashSet<RoadSystem.MoverType> PossibleTerrain, float MaxRange = float.MaxValue)
	{
		Dictionary<RoadSystem.Node, RoadSystem.Node> dictionary = new Dictionary<RoadSystem.Node, RoadSystem.Node>();
		Dictionary<RoadSystem.Node, float> dictionary2 = new Dictionary<RoadSystem.Node, float>();
		PriorityQueueB<RoadSystem.Node> priorityQueueB = new PriorityQueueB<RoadSystem.Node>();
		startNode.CurrentWeight = 0f;
		priorityQueueB.Push(startNode);
		dictionary[startNode] = null;
		dictionary2[startNode] = 0f;
		RoadSystem.Node node;
		while (true)
		{
			if (priorityQueueB.Count > 0)
			{
				node = priorityQueueB.Pop();
				if (node == goal)
				{
					break;
				}
				foreach (RoadSystem.Segment connectedSegment in node.ConnectedSegments)
				{
					if (connectedSegment.Type.IsMoverAllowed(PossibleTerrain))
					{
						RoadSystem.Node node2 = ((connectedSegment.NodeA == node) ? connectedSegment.NodeB : connectedSegment.NodeA);
						float num = dictionary2[node] + connectedSegment.PathFindingCost;
						if ((!dictionary2.ContainsKey(node2) || num < dictionary2[node2]) && num < MaxRange)
						{
							dictionary2[node2] = num;
							dictionary[node2] = node;
							double num2 = Math2.CalcDist_Angular(node2.Coordinates.Latitude, node2.Coordinates.Longitude, goal.Coordinates.Latitude, goal.Coordinates.Longitude);
							node2.CurrentWeight = num + (float)num2;
							priorityQueueB.Push(node2);
						}
					}
				}
				continue;
			}
			return new List<RoadSystem.Node>();
		}
		List<RoadSystem.Node> list = new List<RoadSystem.Node>();
		while (node != null)
		{
			list.Add(node);
			node = dictionary[node];
		}
		list.Reverse();
		return list;
	}

	public static List<RoadSystem.Segment> Search(RoadSystem ParentSystem, RoadSystem.Node startNode, RoadSystem.Node goal, HashSet<RoadSystem.MoverType> PossibleTerrain, float MaxRange = float.MaxValue)
	{
		Dictionary<RoadSystem.Segment, RoadSystem.Segment> dictionary = new Dictionary<RoadSystem.Segment, RoadSystem.Segment>();
		Dictionary<RoadSystem.Segment, float> dictionary2 = new Dictionary<RoadSystem.Segment, float>();
		List<RoadSystem.Segment> list = new List<RoadSystem.Segment>();
		RoadSystem.Segment segment = startNode.ConnectedSegments.ElementAt(0);
		PriorityQueueB<RoadSystem.Segment> priorityQueueB = new PriorityQueueB<RoadSystem.Segment>();
		priorityQueueB.Push(segment);
		dictionary.Add(segment, segment);
		dictionary2.Add(segment, 0f);
		RoadSystem.Segment segment2 = segment;
		List<RoadSystem.Segment> result = new List<RoadSystem.Segment>();
		while (true)
		{
			if (priorityQueueB.Count > 0)
			{
				segment2 = priorityQueueB.Pop();
				if (segment2.NodeA == goal || segment2.NodeB == goal)
				{
					break;
				}
				foreach (RoadSystem.Segment neighborSegment in segment2.GetNeighborSegments())
				{
					if (neighborSegment.Type.IsMoverAllowed(PossibleTerrain))
					{
						float num = (neighborSegment.CurrentWeight = dictionary2[segment2] + neighborSegment.PathFindingCost);
						if (!dictionary2.ContainsKey(neighborSegment) && num < MaxRange)
						{
							dictionary2[neighborSegment] = num;
							dictionary[neighborSegment] = segment2;
							priorityQueueB.Push(neighborSegment);
						}
					}
				}
				continue;
			}
			return result;
		}
		while (segment2 != segment)
		{
			list.Add(segment2);
			segment2 = dictionary[segment2];
		}
		list.Reverse();
		return list;
	}

	public static SortedDictionary<RoadSystem.Segment, float> Search(RoadSystem ParentSystem, RoadSystem.Node startNode, HashSet<RoadSystem.MoverType> PossibleTerrain, float MaxRange = float.MaxValue)
	{
		Dictionary<RoadSystem.Segment, RoadSystem.Segment> dictionary = new Dictionary<RoadSystem.Segment, RoadSystem.Segment>();
		Dictionary<RoadSystem.Segment, float> dictionary2 = new Dictionary<RoadSystem.Segment, float>();
		new List<RoadSystem.Node>();
		RoadSystem.Segment segment = startNode.ConnectedSegments.ElementAt(0);
		PriorityQueueB<RoadSystem.Segment> priorityQueueB = new PriorityQueueB<RoadSystem.Segment>();
		priorityQueueB.Push(segment);
		dictionary.Add(segment, segment);
		dictionary2.Add(segment, 0f);
		RoadSystem.Segment segment2 = segment;
		SortedDictionary<RoadSystem.Segment, float> sortedDictionary = new SortedDictionary<RoadSystem.Segment, float>();
		while (priorityQueueB.Count > 0)
		{
			segment2 = priorityQueueB.Pop();
			foreach (RoadSystem.Segment neighborSegment in segment2.GetNeighborSegments())
			{
				if (!neighborSegment.Type.IsMoverAllowed(PossibleTerrain))
				{
					continue;
				}
				float num = (neighborSegment.CurrentWeight = dictionary2[segment2] + neighborSegment.PathFindingCost);
				if (!dictionary2.ContainsKey(neighborSegment) && num < MaxRange)
				{
					dictionary2[neighborSegment] = num;
					dictionary[neighborSegment] = segment2;
					priorityQueueB.Push(neighborSegment);
					if (sortedDictionary.ContainsKey(neighborSegment))
					{
						sortedDictionary[neighborSegment] = num;
					}
					else
					{
						sortedDictionary.Add(neighborSegment, num);
					}
				}
			}
		}
		return sortedDictionary;
	}

	static AStar()
	{
		Class72.smethod_20();
	}
}
