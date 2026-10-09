using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class RoadSystem
{
	public class Node : IComparable
	{
		public long ID;

		public Geopoint_Struct Coordinates;

		public HashSet<Segment> ConnectedSegments;

		public int Network;

		public float CurrentWeight;

		public Node(float longitude, float Latitutde, float altitude)
		{
			ConnectedSegments = new HashSet<Segment>();
			Network = -1;
			Coordinates = new Geopoint_Struct(longitude, Latitutde, altitude);
		}

		public Node(Geopoint_Struct _Coordinates)
		{
			ConnectedSegments = new HashSet<Segment>();
			Network = -1;
			Coordinates = _Coordinates;
		}

		public Node()
		{
			ConnectedSegments = new HashSet<Segment>();
			Network = -1;
		}

		public string ToXML()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("<Node>");
			stringBuilder.AppendLine($"  <ID>{ID}</ID>");
			stringBuilder.AppendLine("  <Lon>" + XmlConvert.ToString(Coordinates.Longitude) + "</Lon>");
			stringBuilder.AppendLine("  <Lat>" + XmlConvert.ToString(Coordinates.Latitude) + "</Lat>");
			stringBuilder.AppendLine("  <Alt>" + XmlConvert.ToString(Coordinates.Altitude) + "</Alt>");
			stringBuilder.AppendLine($"  <Net>{Network}</Net>");
			stringBuilder.AppendLine("</Node>");
			return stringBuilder.ToString();
		}

		public List<Node> GetNeighborNode()
		{
			List<Node> list = new List<Node>();
			foreach (Segment connectedSegment in ConnectedSegments)
			{
				if (connectedSegment.NodeA != this)
				{
					list.Add(connectedSegment.NodeA);
				}
				if (connectedSegment.NodeB != this)
				{
					list.Add(connectedSegment.NodeB);
				}
			}
			return list;
		}

		public void AttributeID(RoadSystem ParentSystem, long NewID = -1L)
		{
			if (NewID == -1L)
			{
				long iD = 0L;
				if (ParentSystem.NodesByID.Count > 0)
				{
					for (iD = ParentSystem.NodesByID.ElementAt(ParentSystem.NodesByID.Count - 1).Value.ID + 1L; ParentSystem.NodesByID.ContainsKey(iD); iD++)
					{
					}
					ID = iD;
				}
				else
				{
					ID = iD;
				}
				ParentSystem.NodesByID.Add(ID, this);
			}
			else
			{
				ID = NewID;
				ParentSystem.NodesByID.Add(NewID, this);
			}
		}

		public void CheckIntegrity(RoadSystem ParentSystem)
		{
			if (ConnectedSegments.Count == 0)
			{
				ParentSystem.Nodes.Remove(this);
				ParentSystem.NodesByID.Remove(ID);
			}
		}

		public void ResolveDamage(float DamageRatio)
		{
			foreach (Segment connectedSegment in ConnectedSegments)
			{
				connectedSegment.TakeDamage(DamageRatio);
			}
		}

		public int CompareTo(object obj)
		{
			Node node = (Node)obj;
			if (CurrentWeight > node.CurrentWeight)
			{
				return 1;
			}
			if (CurrentWeight < node.CurrentWeight)
			{
				return -1;
			}
			return 0;
		}

		static Node()
		{
			Class72.smethod_20();
		}
	}

	public class Segment : IComparable
	{
		private Node node_0;

		private Node node_1;

		public float Length;

		public bool PreventSanityDestruction;

		public float PathFindingCost;

		[CompilerGenerated]
		private float float_0;

		public float CurrentWeight;

		public long Id;

		public SegmentEnum Type_Enum;

		public float Health
		{
			get
			{
				return method_0();
			}
			set
			{
				method_1(Math.Max(Math.Min(value, 1f), 0f));
				ComputePathFindingCost();
			}
		}

		public Node NodeA => node_0;

		public Node NodeB => node_1;

		public SegmentTypeData Type => TypeOfSegment[Type_Enum];

		[SpecialName]
		[CompilerGenerated]
		private float method_0()
		{
			return float_0;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_1(float float_1)
		{
			float_0 = float_1;
		}

		private void method_2(RoadSystem roadSystem_0, Node node_2, Node node_3)
		{
			if (node_3 == null)
			{
				if (node_2 != null && node_2.ConnectedSegments.Contains(this))
				{
					node_2.ConnectedSegments.Remove(this);
					CheckIntergrity(roadSystem_0, DestroyIfOrphan: true);
				}
			}
			else if (node_3 != node_2)
			{
				if (node_2 != null && node_2.ConnectedSegments.Contains(this))
				{
					node_2.ConnectedSegments.Remove(this);
				}
				if (!node_3.ConnectedSegments.Contains(this))
				{
					node_3.ConnectedSegments.Add(this);
				}
			}
			node_2 = node_3;
			ComputeLengthAndPathFindingCost(roadSystem_0);
		}

		public void SetNodeA(RoadSystem ParentSystem, Node Value)
		{
			method_2(ParentSystem, node_0, Value);
			node_0 = Value;
		}

		public void SetNodeB(RoadSystem ParentSystem, Node Value)
		{
			method_2(ParentSystem, node_1, Value);
			node_1 = Value;
		}

		public static Geopoint_Struct GetGeoCoordinate(Node _NodeA, Node _NodeB, float _Progess)
		{
			return MathFunctions.GetIntermediatePoint_Progress(_NodeA.Coordinates.Latitude, _NodeA.Coordinates.Longitude, _NodeB.Coordinates.Latitude, _NodeB.Coordinates.Longitude, _Progess);
		}

		public Geopoint_Struct GetGeoCoordinate(float _Progess)
		{
			return MathFunctions.GetIntermediatePoint_Progress(NodeA.Coordinates.Latitude, NodeA.Coordinates.Longitude, NodeB.Coordinates.Latitude, NodeB.Coordinates.Longitude, _Progess);
		}

		public void TakeDamage(float DamageRatio)
		{
			Health -= DamageRatio;
		}

		public static float GetLengthNm(Node _NodeA, Node _NodeB)
		{
			return Math2.CalcDist(ref _NodeA.Coordinates, ref _NodeB.Coordinates);
		}

		public float GetLengthNm()
		{
			return Math2.CalcDist(ref NodeA.Coordinates, ref NodeB.Coordinates);
		}

		public List<Segment> GetNeighborSegments()
		{
			List<Segment> list = new List<Segment>();
			foreach (Segment connectedSegment in NodeA.ConnectedSegments)
			{
				if (connectedSegment != this && !list.Contains(connectedSegment))
				{
					list.Add(connectedSegment);
				}
			}
			foreach (Segment connectedSegment2 in NodeB.ConnectedSegments)
			{
				if (connectedSegment2 != this && !list.Contains(connectedSegment2))
				{
					list.Add(connectedSegment2);
				}
			}
			return list;
		}

		public static Segment GetAssociatedSegment(Node Node1, Node Node2)
		{
			Segment result = null;
			foreach (Segment connectedSegment in Node1.ConnectedSegments)
			{
				if ((Node1 == connectedSegment.NodeA || Node1 == connectedSegment.NodeB) && (Node2 == connectedSegment.NodeA || Node2 == connectedSegment.NodeB))
				{
					result = connectedSegment;
					break;
				}
			}
			return result;
		}

		public Segment(RoadSystem ParentSystem, Node _NodeA, Node _NodeB, SegmentEnum _Type)
		{
			PreventSanityDestruction = false;
			PathFindingCost = 0f;
			method_1(1f);
			SetNodeA(ParentSystem, _NodeA);
			SetNodeB(ParentSystem, _NodeB);
			Type_Enum = _Type;
		}

		public void ComputeLengthAndPathFindingCost(RoadSystem ParentSystem)
		{
			if (CheckIntergrity(ParentSystem))
			{
				Length = Math2.CalcDist(ref NodeA.Coordinates, ref NodeB.Coordinates);
				ComputePathFindingCost();
			}
		}

		public void ComputePathFindingCost()
		{
			PathFindingCost = Length * Type.PathCostFactor * (0.2f + Health * 0.8f);
		}

		public bool CheckIntergrity(RoadSystem ParentSystem, bool DestroyIfOrphan = false)
		{
			if (node_0 != null && node_1 != null)
			{
				return true;
			}
			int result;
			if (DestroyIfOrphan && !PreventSanityDestruction)
			{
				ParentSystem.RemoveSegment(this);
				result = 0;
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}

		public void AttributeID(RoadSystem ParentSystem, long _ID = -1L)
		{
			if (_ID == -1L)
			{
				long id = 0L;
				if (ParentSystem.SegmentsByID.Count > 0)
				{
					for (id = ParentSystem.SegmentsByID.ElementAt(ParentSystem.SegmentsByID.Count - 1).Value.Id + 1L; ParentSystem.SegmentsByID.ContainsKey(id); id++)
					{
					}
					Id = id;
				}
				else
				{
					Id = id;
				}
			}
			else
			{
				Id = _ID;
			}
			ParentSystem.SegmentsByID.Add(Id, this);
		}

		public int CompareTo(object obj)
		{
			Segment segment = (Segment)obj;
			if (CurrentWeight > segment.CurrentWeight)
			{
				return 1;
			}
			if (CurrentWeight < segment.CurrentWeight)
			{
				return -1;
			}
			return 0;
		}

		static Segment()
		{
			Class72.smethod_20();
		}
	}

	[Flags]
	public enum SegmentEnum
	{
		None = 0,
		DirtRoad = 1,
		DirtPath = 2,
		ConreteRoad = 4,
		HighWay = 8,
		Railway = 0x10,
		SmallCanal = 0x20,
		Fortifications = 0x40,
		Any = 0x7F,
		AnyRoad = 0xF
	}

	public enum MoverType
	{
		RailVehicules,
		GroundVehicules,
		FootUnit,
		Surface,
		Submarine
	}

	public enum DrawingStyle
	{
		Line,
		Crenelated
	}

	public class SegmentTypeData
	{
		public SegmentEnum Type;

		public float Render_ZoomThreshold;

		private HashSet<MoverType> hashSet_0;

		public float PathCostFactor;

		public string Name;

		public Color Color;

		public int Size;

		public DrawingStyle DrawingStyle;

		public SegmentTypeData(SegmentEnum _Type, float _PathWeight, string _Name, Color _color, int _Size = 1)
		{
			hashSet_0 = new HashSet<MoverType>();
			PathCostFactor = 1f;
			Size = 1;
			Type = _Type;
			PathCostFactor = _PathWeight;
			Name = _Name;
			Color = _color;
			Size = _Size;
		}

		public void AddAllowedMover(MoverType type)
		{
			if (!hashSet_0.Contains(type))
			{
				hashSet_0.Add(type);
			}
		}

		public bool IsMoverAllowed(MoverType type)
		{
			return hashSet_0.Contains(type);
		}

		public bool IsMoverAllowed(HashSet<MoverType> type)
		{
			if (type == null)
			{
				return true;
			}
			foreach (MoverType item in type)
			{
				if (IsMoverAllowed(item))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsUnitAllowed(ActiveUnit unit)
		{
			if (!unit.IsAircraft)
			{
				if (unit.IsSubmarine && IsMoverAllowed(MoverType.Submarine))
				{
					return true;
				}
				int result;
				if (unit.IsMobileGroundUnit)
				{
					result = 1;
				}
				else
				{
					if (!unit.IsFacility)
					{
						goto IL_0049;
					}
					if (!IsMoverAllowed(MoverType.GroundVehicules))
					{
						if (!IsMoverAllowed(MoverType.FootUnit))
						{
							goto IL_0049;
						}
						result = 1;
					}
					else
					{
						result = 1;
					}
				}
				return (byte)result != 0;
			}
			return false;
			IL_0049:
			int result2;
			if (!unit.IsShip)
			{
				result2 = 0;
			}
			else
			{
				if (IsMoverAllowed(MoverType.Surface))
				{
					return true;
				}
				result2 = 0;
			}
			return (byte)result2 != 0;
		}

		static SegmentTypeData()
		{
			Class72.smethod_20();
		}
	}

	public static RoadSystem Instance;

	public HashSet<Node> Nodes;

	public HashSet<Segment> Segments;

	public Dictionary<long, Node> NodesByID;

	public Dictionary<long, Segment> SegmentsByID;

	public static Dictionary<SegmentEnum, SegmentTypeData> TypeOfSegment;

	static RoadSystem()
	{
		Class72.smethod_20();
		TypeOfSegment = new Dictionary<SegmentEnum, SegmentTypeData>();
	}

	public void InitialiseData()
	{
		if (TypeOfSegment.Count <= 0)
		{
			SegmentTypeData segmentTypeData = new SegmentTypeData(SegmentEnum.DirtRoad, 0.7f, "Dirt road", Color.Brown, 2);
			segmentTypeData.AddAllowedMover(MoverType.FootUnit);
			segmentTypeData.AddAllowedMover(MoverType.GroundVehicules);
			segmentTypeData.Render_ZoomThreshold = 2000f;
			TypeOfSegment.Add(segmentTypeData.Type, segmentTypeData);
			SegmentTypeData segmentTypeData2 = new SegmentTypeData(SegmentEnum.DirtPath, 1f, "Dirt path", Color.SaddleBrown);
			segmentTypeData2.AddAllowedMover(MoverType.FootUnit);
			segmentTypeData2.Render_ZoomThreshold = 1000f;
			TypeOfSegment.Add(segmentTypeData2.Type, segmentTypeData2);
			SegmentTypeData segmentTypeData3 = new SegmentTypeData(SegmentEnum.ConreteRoad, 0.4f, "Small concrete road", Color.LightGray, 3);
			segmentTypeData3.AddAllowedMover(MoverType.FootUnit);
			segmentTypeData3.AddAllowedMover(MoverType.GroundVehicules);
			segmentTypeData3.Render_ZoomThreshold = 5000f;
			TypeOfSegment.Add(segmentTypeData3.Type, segmentTypeData3);
			SegmentTypeData segmentTypeData4 = new SegmentTypeData(SegmentEnum.HighWay, 0.3f, "Highway", Color.LightGray, 8);
			segmentTypeData4.AddAllowedMover(MoverType.FootUnit);
			segmentTypeData4.AddAllowedMover(MoverType.GroundVehicules);
			segmentTypeData4.Render_ZoomThreshold = 20000f;
			TypeOfSegment.Add(segmentTypeData4.Type, segmentTypeData4);
			SegmentTypeData segmentTypeData5 = new SegmentTypeData(SegmentEnum.SmallCanal, 1f, "Small canal", Color.Blue, 5);
			segmentTypeData5.AddAllowedMover(MoverType.Surface);
			segmentTypeData5.Render_ZoomThreshold = 20000f;
			TypeOfSegment.Add(segmentTypeData5.Type, segmentTypeData5);
			SegmentTypeData segmentTypeData6 = new SegmentTypeData(SegmentEnum.Railway, 1f, "Railway", Color.DarkGray, 5);
			segmentTypeData6.AddAllowedMover(MoverType.RailVehicules);
			segmentTypeData6.Render_ZoomThreshold = 20000f;
			TypeOfSegment.Add(segmentTypeData6.Type, segmentTypeData6);
			SegmentTypeData segmentTypeData7 = new SegmentTypeData(SegmentEnum.Fortifications, 1f, "Fortifications", Color.White, 4);
			segmentTypeData7.DrawingStyle = DrawingStyle.Crenelated;
			segmentTypeData7.Render_ZoomThreshold = 100000f;
			TypeOfSegment.Add(segmentTypeData7.Type, segmentTypeData7);
		}
	}

	public RoadSystem(bool GlobalInstance = false)
	{
		Nodes = new HashSet<Node>();
		Segments = new HashSet<Segment>();
		NodesByID = new Dictionary<long, Node>();
		SegmentsByID = new Dictionary<long, Segment>();
		InitialiseData();
		if (GlobalInstance)
		{
			Instance = this;
		}
	}

	public RoadSystem(string XMLstr, bool GlobalInstance = false)
	{
		Nodes = new HashSet<Node>();
		Segments = new HashSet<Segment>();
		NodesByID = new Dictionary<long, Node>();
		SegmentsByID = new Dictionary<long, Segment>();
		InitialiseData();
		FromXML(XMLstr);
		if (GlobalInstance)
		{
			Instance = this;
		}
	}

	public void Reset()
	{
		Nodes.Clear();
		Segments.Clear();
		NodesByID.Clear();
		SegmentsByID.Clear();
	}

	public Segment GetSegmentByID(int ID)
	{
		if (SegmentsByID.ContainsKey(ID))
		{
			return SegmentsByID[ID];
		}
		return null;
	}

	public Node GetNodeByID(long ID)
	{
		if (NodesByID.ContainsKey(ID))
		{
			return NodesByID[ID];
		}
		return null;
	}

	public string ToXML()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("<Network>");
		stringBuilder.AppendLine("<Nodes>");
		foreach (Node node in Nodes)
		{
			stringBuilder.AppendLine(node.ToXML());
		}
		stringBuilder.AppendLine("</Nodes>");
		stringBuilder.AppendLine("<Segments>");
		foreach (Segment segment in Segments)
		{
			stringBuilder.AppendLine("<Segments>");
			stringBuilder.Append("<ID>").Append(XmlConvert.ToString(segment.Id)).Append("</ID>");
			stringBuilder.Append("<NodeA>").Append(XmlConvert.ToString(segment.NodeA.ID)).Append("</NodeA>");
			stringBuilder.Append("<NodeB>").Append(XmlConvert.ToString(segment.NodeB.ID)).Append("</NodeB>");
			int type = (int)segment.Type.Type;
			stringBuilder.Append("<Type>" + type + "</Type>");
			stringBuilder.AppendLine("</Segments>");
		}
		stringBuilder.AppendLine("</Segments>");
		stringBuilder.AppendLine("</Network>");
		return stringBuilder.ToString();
	}

	public void FromXML(string XMLstr)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		try
		{
			Reset();
			XmlDocument val = new XmlDocument();
			val.LoadXml(XMLstr);
			XmlNode val2 = ((XmlNode)val).SelectSingleNode("/Network/Nodes");
			XmlNode val3 = ((XmlNode)val).SelectSingleNode("/Network/Segments");
			XmlNodeList val4 = null;
			XmlNodeList val5 = null;
			if (val2 != null)
			{
				val4 = val2.ChildNodes;
			}
			if (val3 != null)
			{
				val5 = val3.ChildNodes;
			}
			if (val4 == null || val5 == null)
			{
				return;
			}
			long id = default(long);
			foreach (XmlNode item in val4)
			{
				XmlNode val6 = item;
				GeoPoint geoPoint = new GeoPoint();
				int network = -1;
				foreach (XmlNode childNode in val6.ChildNodes)
				{
					XmlNode val7 = childNode;
					switch (val7.Name)
					{
					case "ID":
						id = XmlConvert.ToInt64(val7.InnerText);
						break;
					case "Lon":
						geoPoint.Longitude = XmlConvert.ToDouble(val7.InnerText);
						break;
					case "Lat":
						geoPoint.Latitude = XmlConvert.ToDouble(val7.InnerText);
						break;
					case "Alt":
						geoPoint.Altitude = XmlConvert.ToSingle(val7.InnerText);
						break;
					case "Net":
						network = XmlConvert.ToInt16(val7.InnerText);
						break;
					}
				}
				AddNode(geoPoint, id, network);
			}
			long iD = default(long);
			SegmentEnum type = default(SegmentEnum);
			foreach (XmlNode item2 in val5)
			{
				XmlNode val8 = item2;
				long nodeIDA = -1L;
				long nodeIDB = -1L;
				foreach (XmlNode childNode2 in val8.ChildNodes)
				{
					XmlNode val7 = childNode2;
					switch (val7.Name)
					{
					case "ID":
						iD = XmlConvert.ToInt64(val7.InnerText);
						break;
					case "NodeB":
						nodeIDB = XmlConvert.ToInt64(val7.InnerText);
						break;
					case "Type":
						type = (SegmentEnum)XmlConvert.ToInt32(val7.InnerText);
						break;
					case "NodeA":
						nodeIDA = XmlConvert.ToInt64(val7.InnerText);
						break;
					}
				}
				AddSegment(nodeIDA, nodeIDB, type, iD);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at Road system 001", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}

	public void LoadRoadsFromFile(string Path)
	{
		string xMLstr = File.ReadAllText(Path);
		FromXML(xMLstr);
	}

	public void SimplifyPath_Fundamental(Segment SegmentA, Segment SegmentB)
	{
		Node commonNode = GetCommonNode(SegmentA, SegmentB);
		if (commonNode == null)
		{
			return;
		}
		RemoveNode(commonNode, CheckSegmentIntegrity: false);
		Node value = ((SegmentB.NodeA == null) ? SegmentB.NodeB : SegmentB.NodeA);
		RemoveSegment(SegmentB, CheckSegmentIntegrity: false);
		if (SegmentA.NodeB != null)
		{
			if (SegmentA.NodeA == null)
			{
				SegmentA.SetNodeA(this, value);
			}
		}
		else
		{
			SegmentA.SetNodeB(this, value);
		}
	}

	public Node GetCommonNode(Segment SegmentA, Segment SegmentB)
	{
		if (SegmentA.NodeA != SegmentB.NodeB && SegmentA.NodeA != SegmentB.NodeA)
		{
			if (SegmentA.NodeB == SegmentB.NodeB || SegmentA.NodeB == SegmentB.NodeA)
			{
				return SegmentA.NodeB;
			}
			Node result = default(Node);
			return result;
		}
		return SegmentA.NodeA;
	}

	public Node GetClosestNode(double Latitude, double Longitude, float MaxDistance = -1f, int EligibleNetwork = -1, SegmentEnum segmentType = SegmentEnum.Any)
	{
		float num = float.MaxValue;
		Node node = null;
		HashSet<Node>.Enumerator enumerator = Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Node current = enumerator.Current;
			switch (segmentType)
			{
			case SegmentEnum.Any:
				if (current.ConnectedSegments.Count == 0)
				{
					continue;
				}
				break;
			case SegmentEnum.None:
				if (current.ConnectedSegments.Count > 0)
				{
					continue;
				}
				break;
			default:
				if (current.ConnectedSegments.Count == 0 || (segmentType & current.ConnectedSegments.ElementAtOrDefault(0).Type.Type) == 0)
				{
					continue;
				}
				break;
			}
			float num2 = Math2.CalcDist(Latitude, Longitude, current.Coordinates.Latitude, current.Coordinates.Longitude);
			if (num2 < num && (EligibleNetwork == -1 || EligibleNetwork == current.Network))
			{
				num = num2;
				node = current;
			}
		}
		if (node != null && (MaxDistance == -1f || MaxDistance > num))
		{
			return node;
		}
		return null;
	}

	public Node AddNode(ReferencePoint Coordinate, long Id = -1L, int Network = -1)
	{
		return AddNode(new GeoPoint(Coordinate.Longitude, Coordinate.Latitude, Coordinate.Altitude), Id, Network);
	}

	public Node AddNode(Node node, long Id = -1L, int Network = -1)
	{
		if (!Nodes.Contains(node))
		{
			Nodes.Add(node);
			node.AttributeID(this, Id);
			node.Network = Network;
		}
		return node;
	}

	public Node AddNode(GeoPoint Coordinate, long Id = -1L, int Network = -1)
	{
		return AddNode(new Node(new Geopoint_Struct(Coordinate.Longitude, Coordinate.Latitude)), Id, Network);
	}

	public Node AddNode(Geopoint_Struct Coordinate, long Id = -1L, int Network = -1)
	{
		return AddNode(new Node(Coordinate), Id, Network);
	}

	public Node AddNode(float longitude, float Latitude, float altitude, long Id = -1L, int Network = -1)
	{
		return AddNode(new GeoPoint(longitude, Latitude, altitude), Id, Network);
	}

	public void RemoveNode(Node Node, bool CheckSegmentIntegrity = true)
	{
		if (CheckSegmentIntegrity)
		{
			foreach (Segment segment in Segments)
			{
				if (segment.NodeA == Node || segment.NodeB == Node)
				{
					RemoveSegment(segment);
				}
			}
		}
		Nodes.Remove(Node);
		NodesByID.Remove(Node.ID);
	}

	public void RemoveSegment(Segment Segment, bool CheckSegmentIntegrity = true)
	{
		Node nodeA = Segment.NodeA;
		Segment.SetNodeA(this, null);
		Node nodeB = Segment.NodeB;
		Segment.SetNodeB(this, null);
		if (CheckSegmentIntegrity)
		{
			nodeA?.CheckIntegrity(this);
			nodeB?.CheckIntegrity(this);
		}
		Segments.Remove(Segment);
		SegmentsByID.Remove(Segment.Id);
		Segments.Remove(Segment);
	}

	public void ReplaceSegmentType(Segment Segment, SegmentEnum Type)
	{
		Segment.Type_Enum = Type;
	}

	public Segment AddSegment(GeoPoint CoordinateA, GeoPoint CoordinateB, SegmentEnum _Type, long _ID = -1L)
	{
		return AddSegment(AddNode(CoordinateA), AddNode(CoordinateB), _Type, _ID);
	}

	public Segment AddSegment(long NodeIDA, long NodeIDB, SegmentEnum _Type, long _ID = -1L)
	{
		return AddSegment(GetNodeByID(NodeIDA), GetNodeByID(NodeIDB), _Type, _ID);
	}

	public Segment AddSegment(GeoPoint CoordinateA, Node CoordinateB, SegmentEnum _Type, long _ID = -1L)
	{
		return AddSegment(AddNode(CoordinateA), CoordinateB, _Type, _ID);
	}

	public Segment AddSegment(Node CoordinateA, Node CoordinateB, SegmentEnum _Type, long _ID = -1L)
	{
		if (CoordinateA != null && CoordinateB != null)
		{
			Segment segment = new Segment(this, CoordinateA, CoordinateB, _Type);
			Segments.Add(segment);
			segment.AttributeID(this, _ID);
			return segment;
		}
		return null;
	}

	public void RenderRoads()
	{
	}

	public void ConvertFromStreetMap(RoadSystem ParentSystem)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		XmlDocument val = new XmlDocument();
		string text = File.ReadAllText("StreetMap.xml");
		try
		{
			val.LoadXml(text);
			XmlNode val2 = ((XmlNode)val).SelectSingleNode("/osm");
			foreach (XmlNode childNode in val2.ChildNodes)
			{
				XmlNode val3 = childNode;
				string name = val3.Name;
				if (Operators.CompareString(name, "node", false) != 0)
				{
					if (Operators.CompareString(name, "way", false) != 0)
					{
						continue;
					}
					List<long> list = new List<long>();
					foreach (XmlNode childNode2 in val3.ChildNodes)
					{
						XmlNode val4 = childNode2;
						string name2 = val4.Name;
						if (Operators.CompareString(name2, "nd", false) != 0)
						{
							continue;
						}
						foreach (XmlNode item in (XmlNamedNodeMap)val4.Attributes)
						{
							XmlNode val5 = item;
							string name3 = val5.Name;
							if (Operators.CompareString(name3, "id", false) == 0)
							{
								list.Add(XmlConvert.ToInt64(val5.Value));
							}
						}
					}
					if (list.Count > 1)
					{
						int num = list.Count - 2;
						for (int i = 0; i <= num; i++)
						{
							ParentSystem.AddSegment(list.ElementAt(i), list.ElementAt(i + 1), SegmentEnum.ConreteRoad);
						}
					}
					continue;
				}
				long num2 = 0L;
				float longitude = 0f;
				float latitude = 0f;
				foreach (XmlNode item2 in (XmlNamedNodeMap)val3.Attributes)
				{
					XmlNode val6 = item2;
					switch (val6.Name)
					{
					case "lat":
						longitude = XmlConvert.ToSingle(val6.Value);
						break;
					case "lon":
						latitude = XmlConvert.ToSingle(val6.Value);
						break;
					case "id":
						num2 = XmlConvert.ToInt64(val6.Value);
						break;
					}
				}
				ParentSystem.AddNode(longitude, latitude, num2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at Road system 001", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			_ = Debugger.IsAttached;
			ProjectData.ClearProjectError();
		}
	}
}
