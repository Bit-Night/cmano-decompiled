using System;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Serialization;

namespace DotSpatial.Topology;

public class CoordinateList : BaseList<Coordinate>, ICloneable
{
	public CoordinateList()
	{
		base.InnerList = new List<Coordinate>();
	}

	public CoordinateList(IEnumerable<Coordinate> coords)
	{
		base.InnerList = coords.ToList();
	}

	public CoordinateList(IEnumerable<Coordinate> coords, bool allowRepeated)
	{
		if (allowRepeated)
		{
			base.InnerList = coords.ToList();
			return;
		}
		List<Coordinate> list = new List<Coordinate>();
		Coordinate coordinate = null;
		foreach (Coordinate coord in coords)
		{
			if (!(null != coordinate) || !coordinate.Equals2D(coord))
			{
				list.Add(coord);
				coordinate = coord;
			}
		}
		base.InnerList = list;
	}

	public object Clone()
	{
		CoordinateList coordinateList = new CoordinateList();
		using IEnumerator<Coordinate> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			Coordinate current = enumerator.Current;
			coordinateList.Add(CloneableEM.Copy(current));
		}
		return coordinateList;
	}

	public virtual void Add(IEnumerable<Coordinate> coords, bool allowRepeated, bool direction)
	{
		if (!direction)
		{
			coords = coords.Reverse();
		}
		DoAddRange(coords, allowRepeated);
	}

	public virtual void Add(IEnumerable<Coordinate> coord, bool allowRepeated)
	{
		Add(coord, allowRepeated, direction: true);
	}

	public virtual void Add(Coordinate coord, bool allowRepeated)
	{
		DoAdd(coord, allowRepeated);
	}

	protected void DoAdd(Coordinate coord, bool allowRepeated)
	{
		if (allowRepeated || base.Count < 1 || !base[base.Count - 1].Equals2D(coord))
		{
			Add(coord);
		}
	}

	protected void DoAddRange(IEnumerable<Coordinate> coords, bool allowRepeated)
	{
		foreach (Coordinate coord in coords)
		{
			DoAdd(coord, allowRepeated);
		}
	}

	public virtual void CloseRing()
	{
		if (base.Count > 0)
		{
			Add(base[0], allowRepeated: false);
		}
	}

	public virtual Coordinate[] ToCoordinateArray()
	{
		return base.InnerList.ToArray();
	}

	static CoordinateList()
	{
		Class72.smethod_20();
	}
}
