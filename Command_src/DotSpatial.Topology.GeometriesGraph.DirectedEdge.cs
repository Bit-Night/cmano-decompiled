using System.IO;

namespace DotSpatial.Topology.GeometriesGraph;

public class DirectedEdge : EdgeEnd
{
	private readonly int[] int_1 = new int[3] { 0, -999, -999 };

	private EdgeRing edgeRing_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private EdgeRing edgeRing_1;

	private DirectedEdge SgfekGnPheR;

	private DirectedEdge directedEdge_0;

	private DirectedEdge directedEdge_1;

	public virtual int DepthDelta
	{
		get
		{
			int num = Edge.DepthDelta;
			if (!bool_0)
			{
				num = -num;
			}
			return num;
		}
	}

	public virtual EdgeRing EdgeRing
	{
		get
		{
			return edgeRing_0;
		}
		set
		{
			edgeRing_0 = value;
		}
	}

	public virtual bool IsForward
	{
		get
		{
			return bool_0;
		}
		protected set
		{
			bool_0 = value;
		}
	}

	public virtual bool IsInResult
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public virtual bool IsInteriorAreaEdge
	{
		get
		{
			bool result = true;
			for (int i = 0; i < 2; i++)
			{
				int num;
				if (!Label.IsArea(i))
				{
					num = 0;
				}
				else
				{
					if (Label.GetLocation(i, PositionType.Left) == LocationType.Interior && Label.GetLocation(i, PositionType.Right) == LocationType.Interior)
					{
						continue;
					}
					num = 0;
				}
				result = (byte)num != 0;
			}
			return result;
		}
	}

	public virtual bool IsLineEdge
	{
		get
		{
			bool num = Label.IsLine(0) || Label.IsLine(1);
			bool flag = !Label.IsArea(0) || Label.AllPositionsEqual(0, LocationType.Exterior);
			bool flag2 = !Label.IsArea(1) || Label.AllPositionsEqual(1, LocationType.Exterior);
			return num && flag && flag2;
		}
	}

	public virtual bool IsVisited
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public virtual EdgeRing MinEdgeRing
	{
		get
		{
			return edgeRing_1;
		}
		set
		{
			edgeRing_1 = value;
		}
	}

	public virtual DirectedEdge Next
	{
		get
		{
			return SgfekGnPheR;
		}
		set
		{
			SgfekGnPheR = value;
		}
	}

	public virtual DirectedEdge NextMin
	{
		get
		{
			return directedEdge_0;
		}
		set
		{
			directedEdge_0 = value;
		}
	}

	public virtual DirectedEdge Sym
	{
		get
		{
			return directedEdge_1;
		}
		set
		{
			directedEdge_1 = value;
		}
	}

	public virtual bool VisitedEdge
	{
		get
		{
			if (bool_2)
			{
				return directedEdge_1.IsVisited;
			}
			return false;
		}
		set
		{
			bool_2 = value;
			directedEdge_1.IsVisited = value;
		}
	}

	public DirectedEdge(Edge inEdge, bool inIsForward)
		: base(inEdge)
	{
		bool_0 = inIsForward;
		if (!bool_0)
		{
			int num = inEdge.NumPoints - 1;
			base.Init(inEdge.GetCoordinate(num), inEdge.GetCoordinate(num - 1));
		}
		else
		{
			base.Init(inEdge.GetCoordinate(0), inEdge.GetCoordinate(1));
		}
		vePekHnBmts();
	}

	private void vePekHnBmts()
	{
		Label = new Label(Edge.Label);
		if (!bool_0)
		{
			Label.Flip();
		}
	}

	public virtual int GetDepth(PositionType position)
	{
		return int_1[(int)position];
	}

	public virtual void SetDepth(PositionType position, int depthVal)
	{
		if (int_1[(int)position] != -999 && int_1[(int)position] != depthVal)
		{
			throw new TopologyException("Assigned depths do not match", Coordinate);
		}
		int_1[(int)position] = depthVal;
	}

	public virtual void SetEdgeDepths(PositionType position, int depth)
	{
		int num = Edge.DepthDelta;
		int num2;
		if (!bool_0)
		{
			num = -num;
			num2 = 1;
		}
		else
		{
			num2 = 1;
		}
		int num3 = num2;
		if (position == PositionType.Left)
		{
			num3 = -1;
		}
		PositionType position2 = Position.Opposite(position);
		int num4 = num * num3;
		int depthVal = depth + num4;
		SetDepth(position, depth);
		SetDepth(position2, depthVal);
	}

	public override void Write(StreamWriter outstream)
	{
		base.Write(outstream);
		outstream.Write(" " + int_1[1] + "/" + int_1[2]);
		outstream.Write(" (" + DepthDelta + ")");
		if (bool_1)
		{
			outstream.Write(" inResult");
		}
	}

	public virtual void WriteEdge(StreamWriter outstream)
	{
		Write(outstream);
		outstream.Write(" ");
		if (bool_0)
		{
			Edge.Write(outstream);
		}
		else
		{
			Edge.WriteReverse(outstream);
		}
	}

	public static int DepthFactor(LocationType currLocation, LocationType nextLocation)
	{
		if (currLocation == LocationType.Exterior && nextLocation == LocationType.Interior)
		{
			return 1;
		}
		if (currLocation == LocationType.Interior && nextLocation == LocationType.Exterior)
		{
			return -1;
		}
		return 0;
	}

	static DirectedEdge()
	{
		Class72.smethod_20();
	}
}
