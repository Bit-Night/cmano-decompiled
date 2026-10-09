using System;
using System.Collections;
using System.Collections.Generic;

namespace DotSpatial.Topology;

public class CoordinateListSequence : GInterface5, ICollection<Coordinate>, IEnumerable<Coordinate>, IEnumerable, ICloneable
{
	private List<Coordinate> list_0;

	private int int_0;

	public int Count => list_0.Count;

	public int Dimension => 0;

	public bool IsReadOnly => false;

	public virtual Coordinate this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
			method_0();
		}
	}

	public int VersionID => int_0;

	public CoordinateListSequence(Coordinate coordinate)
	{
		Configure(new List<Coordinate> { coordinate });
	}

	public CoordinateListSequence()
	{
		Configure(new List<Coordinate>());
	}

	public CoordinateListSequence(IEnumerable<Coordinate> coordinates)
	{
		List<Coordinate> list = coordinates as List<Coordinate>;
		if (list == null)
		{
			list = new List<Coordinate>();
			foreach (Coordinate coordinate in coordinates)
			{
				list.Add(coordinate);
			}
		}
		Configure(list);
	}

	public CoordinateListSequence(GInterface5 sequence)
	{
		List<Coordinate> list = new List<Coordinate>();
		for (int i = 0; i <= sequence.Count; i++)
		{
			list.Add(sequence[i].Clone() as Coordinate);
		}
		Configure(list);
	}

	private void Configure(List<Coordinate> inCoords)
	{
		list_0 = inCoords;
		int_0 = 0;
	}

	public void Add(Coordinate item)
	{
		list_0.Add(item);
		method_0();
	}

	public void Clear()
	{
		list_0 = new List<Coordinate>();
		method_0();
	}

	public object Clone()
	{
		return new CoordinateListSequence(list_0);
	}

	public bool Contains(Coordinate item)
	{
		return list_0.Contains(item);
	}

	public void CopyTo(Coordinate[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public IEnvelope ExpandEnvelope(IEnvelope env)
	{
		IEnvelope envelope = env.Copy();
		foreach (Coordinate item in list_0)
		{
			envelope.ExpandToInclude(item);
		}
		return envelope;
	}

	public IEnumerator<Coordinate> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public double GetOrdinate(int index, Ordinate ordinate)
	{
		return list_0[index].Z;
	}

	public bool Remove(Coordinate item)
	{
		method_0();
		return list_0.Remove(item);
	}

	public void SetOrdinate(int index, Ordinate ordinate, double value)
	{
		switch (ordinate)
		{
		case Ordinate.X:
			list_0[index].X = value;
			break;
		case Ordinate.Y:
			list_0[index].Y = value;
			break;
		case Ordinate.Z:
			list_0[index].Z = value;
			break;
		case Ordinate.M:
			list_0[index].M = value;
			break;
		}
		method_0();
	}

	public Coordinate[] ToCoordinateArray()
	{
		return list_0.ToArray();
	}

	private void method_0()
	{
		if (int_0 == int.MaxValue)
		{
			int_0 = int.MinValue;
		}
		else
		{
			int_0++;
		}
	}

	static CoordinateListSequence()
	{
		Class72.smethod_20();
	}
}
