using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DotSpatial.Topology;

[Serializable]
public class CoordinateArraySequence : GInterface5, ICollection<Coordinate>, IEnumerable<Coordinate>, IEnumerable, ICloneable
{
	public class Enumerator : IEnumerator<Coordinate>, IDisposable, IEnumerator
	{
		private readonly IEnumerator fvYevriOmHQ;

		public Coordinate Current => fvYevriOmHQ.Current as Coordinate;

		object IEnumerator.Current => fvYevriOmHQ.Current;

		public Enumerator(IEnumerator inBaseEnumerator)
		{
			fvYevriOmHQ = inBaseEnumerator;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return fvYevriOmHQ.MoveNext();
		}

		public void Reset()
		{
			fvYevriOmHQ.Reset();
		}

		static Enumerator()
		{
			Class72.smethod_20();
		}
	}

	private Coordinate[] coordinate_0;

	private int int_0;

	public virtual int Count => coordinate_0.Length;

	public virtual int Dimension => 3;

	public virtual bool IsReadOnly => false;

	public virtual Coordinate this[int index]
	{
		get
		{
			return coordinate_0[index];
		}
		set
		{
			coordinate_0[index] = value;
			method_0();
		}
	}

	public int VersionID => int_0;

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

	public CoordinateArraySequence()
	{
		Configure(new Coordinate[1]
		{
			new Coordinate()
		});
	}

	public CoordinateArraySequence(Coordinate coordinate)
	{
		Configure(new Coordinate[1] { coordinate });
	}

	public CoordinateArraySequence(IEnumerable<Coordinate> coordinates)
	{
		List<Coordinate> list = new List<Coordinate>();
		foreach (Coordinate coordinate in coordinates)
		{
			list.Add(coordinate);
		}
		Coordinate[] inCoords = list.ToArray();
		Configure(inCoords);
	}

	public CoordinateArraySequence(Coordinate[] coordinates)
	{
		Coordinate[] inCoords = coordinates;
		if (coordinates == null)
		{
			inCoords = new Coordinate[1]
			{
				new Coordinate()
			};
		}
		Configure(inCoords);
	}

	public CoordinateArraySequence(int size)
	{
		Coordinate[] array = new Coordinate[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = new Coordinate();
		}
		Configure(array);
	}

	public CoordinateArraySequence(GInterface5 coordSeq)
	{
		Coordinate[] array = ((coordSeq != null) ? new Coordinate[coordSeq.Count] : new Coordinate[0]);
		for (int i = 0; i < array.Length; i++)
		{
			if (coordSeq != null)
			{
				array[i] = coordSeq[i].Clone() as Coordinate;
			}
		}
		Configure(array);
	}

	private void Configure(Coordinate[] inCoords)
	{
		coordinate_0 = inCoords;
		int_0 = 0;
	}

	public virtual void Add(Coordinate item)
	{
		Coordinate[] array = new Coordinate[coordinate_0.Length + 1];
		coordinate_0.CopyTo(array, 0);
		array[coordinate_0.Length] = item;
		method_0();
	}

	public virtual void Clear()
	{
		coordinate_0 = new Coordinate[1];
		coordinate_0[0] = new Coordinate();
		method_0();
	}

	public virtual bool Contains(Coordinate item)
	{
		Coordinate[] array = coordinate_0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == item)
			{
				return true;
			}
		}
		return false;
	}

	public virtual object Clone()
	{
		Coordinate[] array = new Coordinate[Count];
		for (int i = 0; i < coordinate_0.Length; i++)
		{
			array[i] = new Coordinate(coordinate_0[i]);
		}
		return new CoordinateArraySequence(array);
	}

	public virtual void CopyTo(Coordinate[] array, int arrayIndex)
	{
		coordinate_0.CopyTo(array, arrayIndex);
	}

	public virtual IEnvelope ExpandEnvelope(IEnvelope env)
	{
		IEnvelope envelope = env.Copy();
		for (int i = 0; i < coordinate_0.Length; i++)
		{
			envelope.ExpandToInclude(coordinate_0[i]);
		}
		return envelope;
	}

	public virtual IEnumerator<Coordinate> GetEnumerator()
	{
		return new Enumerator(coordinate_0.GetEnumerator());
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return coordinate_0.GetEnumerator();
	}

	public virtual double GetOrdinate(int index, Ordinate ordinate)
	{
		return ordinate switch
		{
			Ordinate.X => coordinate_0[index].X, 
			Ordinate.Y => coordinate_0[index].Y, 
			Ordinate.Z => coordinate_0[index].Z, 
			_ => double.NaN, 
		};
	}

	public virtual bool Remove(Coordinate item)
	{
		Coordinate[] array = new Coordinate[coordinate_0.Length - 1];
		bool flag = false;
		for (int i = 0; i < coordinate_0.Length; i++)
		{
			if (item == coordinate_0[i] && !flag)
			{
				flag = true;
			}
			else if (!flag)
			{
				array[i] = coordinate_0[i];
			}
			else
			{
				array[i - 1] = coordinate_0[i];
			}
		}
		if (flag)
		{
			coordinate_0 = array;
		}
		return flag;
	}

	public virtual void SetOrdinate(int index, Ordinate ordinate, double value)
	{
		switch (ordinate)
		{
		default:
			throw new ArgumentException("invalid ordinate index: " + ordinate);
		case Ordinate.X:
			coordinate_0[index].X = value;
			break;
		case Ordinate.Y:
			coordinate_0[index].Y = value;
			break;
		case Ordinate.Z:
			coordinate_0[index].Z = value;
			break;
		case Ordinate.M:
			coordinate_0[index].M = value;
			break;
		}
		method_0();
	}

	public virtual Coordinate[] ToCoordinateArray()
	{
		return coordinate_0;
	}

	public override string ToString()
	{
		if (coordinate_0.Length != 0)
		{
			StringBuilder stringBuilder = new StringBuilder(17 * coordinate_0.Length);
			stringBuilder.Append('(');
			stringBuilder.Append(coordinate_0[0]);
			for (int i = 1; i < coordinate_0.Length; i++)
			{
				stringBuilder.Append(", ");
				stringBuilder.Append(coordinate_0[i]);
			}
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}
		return "()";
	}

	static CoordinateArraySequence()
	{
		Class72.smethod_20();
	}
}
