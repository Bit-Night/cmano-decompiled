namespace DotSpatial.Topology.GeometriesGraph;

public class Depth
{
	private readonly int[,] int_0 = new int[2, 3];

	public virtual int this[int geomIndex, PositionType posIndex]
	{
		get
		{
			return GetDepth(geomIndex, posIndex);
		}
		set
		{
			SetDepth(geomIndex, posIndex, value);
		}
	}

	public Depth()
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				int_0[i, j] = -1;
			}
		}
	}

	public static int DepthAtLocation(LocationType location)
	{
		return location switch
		{
			LocationType.Exterior => 0, 
			LocationType.Interior => 1, 
			_ => -1, 
		};
	}

	public virtual int GetDepth(int geomIndex, PositionType posIndex)
	{
		return int_0[geomIndex, (int)posIndex];
	}

	public virtual void SetDepth(int geomIndex, PositionType posIndex, int depthValue)
	{
		int_0[geomIndex, (int)posIndex] = depthValue;
	}

	public virtual LocationType GetLocation(int geomIndex, PositionType posIndex)
	{
		if (int_0[geomIndex, (int)posIndex] > 0)
		{
			return LocationType.Interior;
		}
		return LocationType.Exterior;
	}

	public virtual void Add(int geomIndex, PositionType posIndex, LocationType location)
	{
		if (location == LocationType.Interior)
		{
			int_0[geomIndex, (int)posIndex]++;
		}
	}

	public virtual bool IsNull()
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (int_0[i, j] != -1)
				{
					return false;
				}
			}
		}
		return true;
	}

	public virtual bool IsNull(int geomIndex)
	{
		return int_0[geomIndex, 1] == -1;
	}

	public virtual bool IsNull(int geomIndex, PositionType posIndex)
	{
		return int_0[geomIndex, (int)posIndex] == -1;
	}

	public virtual void Add(Label lbl)
	{
		for (int i = 0; i < 2; i++)
		{
			for (int j = 1; j < 3; j++)
			{
				LocationType location = lbl.GetLocation(i, (PositionType)j);
				if (location == LocationType.Exterior || location == LocationType.Interior)
				{
					if (!IsNull(i, (PositionType)j))
					{
						int_0[i, j] += DepthAtLocation(location);
					}
					else
					{
						int_0[i, j] = DepthAtLocation(location);
					}
				}
			}
		}
	}

	public virtual int GetDelta(int geomIndex)
	{
		return int_0[geomIndex, 2] - int_0[geomIndex, 1];
	}

	public virtual void Normalize()
	{
		for (int i = 0; i < 2; i++)
		{
			if (IsNull(i))
			{
				continue;
			}
			int num = int_0[i, 1];
			if (int_0[i, 2] < num)
			{
				num = int_0[i, 2];
			}
			int num2;
			if (num >= 0)
			{
				num2 = 1;
			}
			else
			{
				num = 0;
				num2 = 1;
			}
			for (int j = num2; j < 3; j++)
			{
				int num3 = 0;
				if (int_0[i, j] > num)
				{
					num3 = 1;
				}
				int_0[i, j] = num3;
			}
		}
	}

	public override string ToString()
	{
		return "A: " + int_0[0, 1] + ", " + int_0[0, 2] + " B: " + int_0[1, 1] + ", " + int_0[1, 2];
	}

	static Depth()
	{
		Class72.smethod_20();
	}
}
