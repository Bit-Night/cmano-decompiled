using System.Text;

namespace DotSpatial.Topology.GeometriesGraph;

public class Label
{
	private readonly TopologyLocation[] topologyLocation_0 = new TopologyLocation[2];

	public virtual int GeometryCount
	{
		get
		{
			int num = 0;
			if (!topologyLocation_0[0].IsNull)
			{
				num++;
			}
			if (!topologyLocation_0[1].IsNull)
			{
				num++;
			}
			return num;
		}
	}

	public Label(LocationType onLoc)
	{
		topologyLocation_0[0] = new TopologyLocation(onLoc);
		topologyLocation_0[1] = new TopologyLocation(onLoc);
	}

	public Label(int geomIndex, LocationType onLoc)
	{
		topologyLocation_0[0] = new TopologyLocation(LocationType.Null);
		topologyLocation_0[1] = new TopologyLocation(LocationType.Null);
		topologyLocation_0[geomIndex].SetLocation(onLoc);
	}

	public Label(LocationType onLoc, LocationType leftLoc, LocationType rightLoc)
	{
		topologyLocation_0[0] = new TopologyLocation(onLoc, leftLoc, rightLoc);
		topologyLocation_0[1] = new TopologyLocation(onLoc, leftLoc, rightLoc);
	}

	public Label(int geomIndex, LocationType onLoc, LocationType leftLoc, LocationType rightLoc)
	{
		topologyLocation_0[0] = new TopologyLocation(LocationType.Null, LocationType.Null, LocationType.Null);
		topologyLocation_0[1] = new TopologyLocation(LocationType.Null, LocationType.Null, LocationType.Null);
		topologyLocation_0[geomIndex].SetLocations(onLoc, leftLoc, rightLoc);
	}

	public Label(int geomIndex, TopologyLocation gl)
	{
		topologyLocation_0[0] = new TopologyLocation(gl.GetLocations());
		topologyLocation_0[1] = new TopologyLocation(gl.GetLocations());
		topologyLocation_0[geomIndex].SetLocations(gl);
	}

	public Label(Label lbl)
	{
		topologyLocation_0[0] = new TopologyLocation(lbl.topologyLocation_0[0]);
		topologyLocation_0[1] = new TopologyLocation(lbl.topologyLocation_0[1]);
	}

	public static Label ToLineLabel(Label label)
	{
		Label label2 = new Label(LocationType.Null);
		for (int i = 0; i < 2; i++)
		{
			label2.SetLocation(i, label.GetLocation(i));
		}
		return label2;
	}

	public virtual void Flip()
	{
		topologyLocation_0[0].Flip();
		topologyLocation_0[1].Flip();
	}

	public virtual LocationType GetLocation(int geomIndex, PositionType posIndex)
	{
		return topologyLocation_0[geomIndex].Get(posIndex);
	}

	public virtual LocationType GetLocation(int geomIndex)
	{
		return topologyLocation_0[geomIndex].Get(PositionType.On);
	}

	public virtual void SetLocation(int geomIndex, PositionType posIndex, LocationType location)
	{
		topologyLocation_0[geomIndex].SetLocation(posIndex, location);
	}

	public virtual void SetLocation(int geomIndex, LocationType location)
	{
		topologyLocation_0[geomIndex].SetLocation(PositionType.On, location);
	}

	public virtual void SetAllLocations(int geomIndex, LocationType location)
	{
		topologyLocation_0[geomIndex].SetAllLocations(location);
	}

	public virtual void SetAllLocationsIfNull(int geomIndex, LocationType location)
	{
		topologyLocation_0[geomIndex].SetAllLocationsIfNull(location);
	}

	public virtual void SetAllLocationsIfNull(LocationType location)
	{
		SetAllLocationsIfNull(0, location);
		SetAllLocationsIfNull(1, location);
	}

	public virtual void Merge(Label lbl)
	{
		for (int i = 0; i < 2; i++)
		{
			if (topologyLocation_0[i] == null && lbl.topologyLocation_0[i] != null)
			{
				topologyLocation_0[i] = new TopologyLocation(lbl.topologyLocation_0[i]);
			}
			else
			{
				topologyLocation_0[i].Merge(lbl.topologyLocation_0[i]);
			}
		}
	}

	public virtual bool IsNull(int geomIndex)
	{
		return topologyLocation_0[geomIndex].IsNull;
	}

	public virtual bool IsAnyNull(int geomIndex)
	{
		return topologyLocation_0[geomIndex].IsAnyNull;
	}

	public virtual bool IsArea()
	{
		if (topologyLocation_0[0].IsArea)
		{
			return true;
		}
		return topologyLocation_0[1].IsArea;
	}

	public virtual bool IsArea(int geomIndex)
	{
		return topologyLocation_0[geomIndex].IsArea;
	}

	public virtual bool IsLine(int geomIndex)
	{
		return topologyLocation_0[geomIndex].IsLine;
	}

	public virtual bool IsEqualOnSide(Label lbl, int side)
	{
		if (topologyLocation_0[0].IsEqualOnSide(lbl.topologyLocation_0[0], side))
		{
			return topologyLocation_0[1].IsEqualOnSide(lbl.topologyLocation_0[1], side);
		}
		return false;
	}

	public virtual bool AllPositionsEqual(int geomIndex, LocationType loc)
	{
		return topologyLocation_0[geomIndex].AllPositionsEqual(loc);
	}

	public virtual void ToLine(int geomIndex)
	{
		if (topologyLocation_0[geomIndex].IsArea)
		{
			topologyLocation_0[geomIndex] = new TopologyLocation(topologyLocation_0[geomIndex].GetLocations()[0]);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (topologyLocation_0[0] != null)
		{
			stringBuilder.Append("a:");
			stringBuilder.Append(topologyLocation_0[0].ToString());
		}
		if (topologyLocation_0[1] != null)
		{
			stringBuilder.Append(" b:");
			stringBuilder.Append(topologyLocation_0[1].ToString());
		}
		return stringBuilder.ToString();
	}

	static Label()
	{
		Class72.smethod_20();
	}
}
