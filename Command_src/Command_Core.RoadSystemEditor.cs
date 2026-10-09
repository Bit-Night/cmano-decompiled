using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class RoadSystemEditor
{
	public enum BrushType
	{
		None,
		Selection,
		DrawSegment,
		RemoveNode
	}

	public static bool NodeSnapping;

	private static bool bool_0;

	public static SortedDictionary<RoadSystem.Segment, float> FloodfillResult;

	public static RoadSystem.SegmentEnum CurrentRoadType;

	public static float BrushSize;

	public static RoadSystem.Node GoalPF;

	public static HashSet<RoadSystem.Node> SelectedRoadNodes;

	public static HashSet<RoadSystem.Segment> SelectedRoadSegments;

	public static (Geopoint_Struct?, RoadSystem.Node)? SegmentStartingPoint;

	private static RoadSystem.Node node_0;

	public static bool Enabled;

	private static List<IObserver_UI> list_0;

	public static RoadSystem RoadSystem => RoadSystem.Instance;

	public static bool DrawSegmentMode
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			NotifyObservers();
		}
	}

	public static bool IsDrawingSegment => SegmentStartingPoint.HasValue;

	public static RoadSystem.Node NodeCurrentlySnapped
	{
		get
		{
			return node_0;
		}
		set
		{
			if (node_0 != value)
			{
				node_0 = value;
				NotifyObservers();
			}
		}
	}

	static RoadSystemEditor()
	{
		Class72.smethod_20();
		NodeSnapping = true;
		FloodfillResult = new SortedDictionary<RoadSystem.Segment, float>();
		SelectedRoadNodes = new HashSet<RoadSystem.Node>();
		SelectedRoadSegments = new HashSet<RoadSystem.Segment>();
		Enabled = false;
		list_0 = new List<IObserver_UI>();
	}

	public static void NotifyObservers()
	{
		foreach (IObserver_UI item in list_0)
		{
			if (item != null && !item.IsDisposed)
			{
				item.Refresh_FromEvent();
			}
		}
	}

	public static void AddUIObserver(IObserver_UI obs)
	{
		if (!list_0.Contains(obs))
		{
			list_0.Add(obs);
		}
	}

	public static RoadSystem.Node GetClosestNodeFromPoint(Geopoint_Struct MapHoverWorldPoint, float MaxDistance = float.MaxValue)
	{
		float num = float.MaxValue;
		RoadSystem.Node node = null;
		foreach (RoadSystem.Node node2 in RoadSystem.Instance.Nodes)
		{
			float num2 = Math2.CalcDist(MapHoverWorldPoint.Latitude, MapHoverWorldPoint.Longitude, node2.Coordinates.Latitude, node2.Coordinates.Longitude);
			if (num2 < num && num2 < MaxDistance)
			{
				node = node2;
				num = num2;
			}
		}
		NodeCurrentlySnapped = node;
		return node;
	}

	public static void SelectedSegment_ReplaceType(RoadSystem.SegmentEnum? type = null)
	{
		if (!type.HasValue)
		{
			type = CurrentRoadType;
		}
		foreach (RoadSystem.Segment item in SelectedRoadSegments.ToList())
		{
			RoadSystem.Instance.ReplaceSegmentType(item, type.Value);
		}
	}

	public static void SelectedSegment_Delete()
	{
		foreach (RoadSystem.Segment item in SelectedRoadSegments.ToList())
		{
			RoadSystem.Instance.RemoveSegment(item);
		}
	}
}
