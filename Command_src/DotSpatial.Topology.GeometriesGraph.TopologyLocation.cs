using System.Collections.Generic;
using System.Text;

namespace DotSpatial.Topology.GeometriesGraph;

public class TopologyLocation
{
	private LocationType[] locationType_0;

	public virtual LocationType this[PositionType posIndex]
	{
		get
		{
			return Get(posIndex);
		}
		set
		{
			SetLocation(posIndex, value);
		}
	}

	public virtual bool IsNull
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < locationType_0.Length)
				{
					if (locationType_0[num] != LocationType.Null)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	public virtual bool IsAnyNull
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < locationType_0.Length)
				{
					if (locationType_0[num] == LocationType.Null)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	public virtual bool IsArea => locationType_0.Length > 1;

	public virtual bool IsLine => locationType_0.Length == 1;

	public TopologyLocation(ICollection<LocationType> location)
	{
		method_0(location.Count);
	}

	public TopologyLocation(LocationType on, LocationType left, LocationType right)
	{
		method_0(3);
		locationType_0[0] = on;
		locationType_0[1] = left;
		locationType_0[2] = right;
	}

	public TopologyLocation(LocationType on)
	{
		method_0(1);
		locationType_0[0] = on;
	}

	public TopologyLocation(TopologyLocation gl)
	{
		if (gl != null)
		{
			method_0(gl.locationType_0.Length);
			for (int i = 0; i < locationType_0.Length; i++)
			{
				locationType_0[i] = gl.locationType_0[i];
			}
		}
	}

	private void method_0(int int_0)
	{
		locationType_0 = new LocationType[int_0];
		SetAllLocations(LocationType.Null);
	}

	public virtual LocationType Get(PositionType posIndex)
	{
		if ((int)posIndex < locationType_0.Length)
		{
			return locationType_0[(int)posIndex];
		}
		return LocationType.Null;
	}

	public virtual bool IsEqualOnSide(TopologyLocation le, int locIndex)
	{
		return locationType_0[locIndex] == le.locationType_0[locIndex];
	}

	public virtual void Flip()
	{
		if (locationType_0.Length > 1)
		{
			LocationType locationType = locationType_0[1];
			locationType_0[1] = locationType_0[2];
			locationType_0[2] = locationType;
		}
	}

	public virtual void SetAllLocations(LocationType locValue)
	{
		for (int i = 0; i < locationType_0.Length; i++)
		{
			locationType_0[i] = locValue;
		}
	}

	public virtual void SetAllLocationsIfNull(LocationType locValue)
	{
		for (int i = 0; i < locationType_0.Length; i++)
		{
			if (locationType_0[i] == LocationType.Null)
			{
				locationType_0[i] = locValue;
			}
		}
	}

	public virtual void SetLocation(PositionType locIndex, LocationType locValue)
	{
		locationType_0[(int)locIndex] = locValue;
	}

	public virtual void SetLocation(LocationType locValue)
	{
		SetLocation(PositionType.On, locValue);
	}

	public virtual LocationType[] GetLocations()
	{
		return locationType_0;
	}

	public virtual void SetLocations(LocationType on, LocationType left, LocationType right)
	{
		locationType_0[0] = on;
		locationType_0[1] = left;
		locationType_0[2] = right;
	}

	public virtual void SetLocations(TopologyLocation gl)
	{
		for (int i = 0; i < gl.locationType_0.Length; i++)
		{
			locationType_0[i] = gl.locationType_0[i];
		}
	}

	public virtual bool AllPositionsEqual(LocationType loc)
	{
		for (int i = 0; i < locationType_0.Length; i++)
		{
			if (locationType_0[i] != loc)
			{
				return false;
			}
		}
		return true;
	}

	public virtual void Merge(TopologyLocation gl)
	{
		int num;
		if (gl.locationType_0.Length <= locationType_0.Length)
		{
			num = 0;
		}
		else
		{
			locationType_0 = new LocationType[3]
			{
				locationType_0[0],
				LocationType.Null,
				LocationType.Null
			};
			num = 0;
		}
		for (int i = num; i < locationType_0.Length; i++)
		{
			if (locationType_0[i] == LocationType.Null && i < gl.locationType_0.Length)
			{
				locationType_0[i] = gl.locationType_0[i];
			}
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (locationType_0.Length > 1)
		{
			stringBuilder.Append(Location.ToLocationSymbol(locationType_0[1]));
		}
		stringBuilder.Append(Location.ToLocationSymbol(locationType_0[0]));
		if (locationType_0.Length > 1)
		{
			stringBuilder.Append(Location.ToLocationSymbol(locationType_0[2]));
		}
		return stringBuilder.ToString();
	}

	static TopologyLocation()
	{
		Class72.smethod_20();
	}
}
