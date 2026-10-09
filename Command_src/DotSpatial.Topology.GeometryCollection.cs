using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotSpatial.Topology;

[Serializable]
public class GeometryCollection : Geometry, GInterface6, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IEnumerable
{
	public class Enumerator : IEnumerator
	{
		private readonly int int_0;

		private readonly GInterface6 ginterface6_0;

		private bool bool_0;

		private int int_1;

		private Enumerator nmIevnpqwEr;

		public virtual object Current
		{
			get
			{
				if (!bool_0)
				{
					if (nmIevnpqwEr != null)
					{
						if (nmIevnpqwEr.MoveNext())
						{
							return nmIevnpqwEr.Current;
						}
						nmIevnpqwEr = null;
					}
					if (int_1 >= int_0)
					{
						throw new ArgumentOutOfRangeException();
					}
					IGeometry geometryN = ginterface6_0.GetGeometryN(int_1++);
					if (!(geometryN is GeometryCollection))
					{
						return geometryN;
					}
					nmIevnpqwEr = new Enumerator((GeometryCollection)geometryN);
					return nmIevnpqwEr.Current;
				}
				bool_0 = false;
				return ginterface6_0;
			}
		}

		internal Enumerator(GInterface6 parent)
		{
			ginterface6_0 = parent;
			bool_0 = true;
			int_1 = 0;
			int_0 = parent.NumGeometries;
		}

		public virtual bool MoveNext()
		{
			if (!bool_0)
			{
				if (nmIevnpqwEr != null)
				{
					if (nmIevnpqwEr.MoveNext())
					{
						return true;
					}
					nmIevnpqwEr = null;
				}
				if (int_1 >= int_0)
				{
					return false;
				}
				return true;
			}
			return true;
		}

		public virtual void Reset()
		{
			bool_0 = true;
			int_1 = 0;
		}

		static Enumerator()
		{
			Class72.smethod_20();
		}
	}

	public static readonly GInterface6 Empty;

	private IGeometry[] igeometry_1;

	public override Coordinate Coordinate
	{
		get
		{
			if (IsEmpty)
			{
				return null;
			}
			return igeometry_1[0].Coordinate;
		}
	}

	public override IList<Coordinate> Coordinates
	{
		get
		{
			IList<Coordinate> list = new Coordinate[NumPoints];
			int num = -1;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				IList<Coordinate> coordinates = igeometry_1[i].Coordinates;
				for (int j = 0; j < coordinates.Count; j++)
				{
					num++;
					list[num] = coordinates[j];
				}
			}
			return list;
		}
		set
		{
			if (igeometry_1.Length >= 1)
			{
				igeometry_1[0].Coordinates = value;
			}
		}
	}

	public override bool IsEmpty
	{
		get
		{
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				if (!igeometry_1[i].IsEmpty)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override DimensionType Dimension
	{
		get
		{
			DimensionType dimensionType = DimensionType.False;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				dimensionType = (DimensionType)Math.Max((int)dimensionType, (int)igeometry_1[i].Dimension);
			}
			return dimensionType;
		}
	}

	public override DimensionType BoundaryDimension
	{
		get
		{
			DimensionType dimensionType = DimensionType.False;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				dimensionType = (DimensionType)Math.Max((int)dimensionType, (int)((Geometry)igeometry_1[i]).BoundaryDimension);
			}
			return dimensionType;
		}
	}

	public override int NumGeometries => igeometry_1.Length;

	public virtual IGeometry[] Geometries
	{
		get
		{
			return igeometry_1;
		}
		set
		{
			igeometry_1 = value;
		}
	}

	public override int NumPoints
	{
		get
		{
			int num = 0;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				num += ((Geometry)igeometry_1[i]).NumPoints;
			}
			return num;
		}
	}

	public override string GeometryType => "GeometryCollection";

	public override bool IsSimple
	{
		get
		{
			CheckNotGeometryCollection(this);
			throw new ShouldNeverReachHereException();
		}
	}

	public override IGeometry Boundary
	{
		get
		{
			CheckNotGeometryCollection(this);
			throw new ShouldNeverReachHereException();
		}
	}

	public override double Area
	{
		get
		{
			double num = 0.0;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				num += igeometry_1[i].Area;
			}
			return num;
		}
	}

	public override double Length
	{
		get
		{
			double num = 0.0;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				num += igeometry_1[i].Length;
			}
			return num;
		}
	}

	public bool IsHomogeneous
	{
		get
		{
			IGeometry geometry = igeometry_1[0];
			for (int i = 1; i < igeometry_1.Length; i++)
			{
				if (geometry.GetType() != igeometry_1[i].GetType())
				{
					return false;
				}
			}
			return true;
		}
	}

	public virtual IGeometry this[int i]
	{
		get
		{
			return igeometry_1[i];
		}
		set
		{
			igeometry_1[i] = value;
		}
	}

	public virtual int Count => igeometry_1.Length;

	public new IEnvelope Envelope
	{
		get
		{
			IEnvelope envelope = new Envelope();
			for (int i = 0; i < NumGeometries; i++)
			{
				envelope.ExpandToInclude(Geometries[i].Envelope);
			}
			return envelope;
		}
	}

	public GeometryCollection(IGeometry[] inGeometries)
		: this(inGeometries, Geometry.DefaultFactory)
	{
	}

	protected GeometryCollection()
		: base(Geometry.DefaultFactory)
	{
	}

	protected GeometryCollection(IGeometryFactory factory)
		: base(factory)
	{
	}

	public GeometryCollection(IGeometry[] inGeometries, IGeometryFactory factory)
		: base(factory)
	{
		if (inGeometries == null)
		{
			inGeometries = new IGeometry[0];
		}
		if (Geometry.HasNullElements(inGeometries))
		{
			throw new ArgumentException("geometries must not contain null elements");
		}
		igeometry_1 = inGeometries;
	}

	public GeometryCollection(IBasicGeometry inGeometry, IGeometryFactory inFactory)
		: base(inFactory)
	{
		if (inGeometry != null)
		{
			if (inGeometry.GetBasicGeometryN(0) is IBasicPolygon)
			{
				igeometry_1 = new IGeometry[inGeometry.NumGeometries];
				for (int i = 0; i < inGeometry.NumGeometries; i++)
				{
					IBasicPolygon polygonBase = inGeometry.GetBasicGeometryN(i) as IBasicPolygon;
					igeometry_1[i] = new Polygon(polygonBase);
				}
			}
			else if (!(inGeometry.GetBasicGeometryN(0) is IBasicPoint))
			{
				if (inGeometry.GetBasicGeometryN(0) is IBasicLineString)
				{
					igeometry_1 = new IGeometry[inGeometry.NumGeometries];
					for (int j = 0; j < inGeometry.NumGeometries; j++)
					{
						IBasicLineString lineStringBase = inGeometry.GetBasicGeometryN(j) as IBasicLineString;
						igeometry_1[j] = new LineString(lineStringBase);
					}
				}
			}
			else
			{
				igeometry_1 = new IGeometry[inGeometry.NumGeometries];
				for (int k = 0; k < inGeometry.NumGeometries; k++)
				{
					IBasicPoint coordinate = inGeometry.GetBasicGeometryN(k) as IBasicPoint;
					igeometry_1[k] = new Point(coordinate);
				}
			}
		}
		else
		{
			igeometry_1 = new IGeometry[0];
		}
	}

	public GeometryCollection(IEnumerable<IBasicGeometry> baseGeometries, IGeometryFactory factory)
		: base(factory)
	{
		if (baseGeometries == null)
		{
			return;
		}
		int num = baseGeometries.Count();
		if (igeometry_1 == null)
		{
			igeometry_1 = new IGeometry[num];
		}
		if (Geometry.HasNullElements(baseGeometries))
		{
			throw new ArgumentException("geometries must not contain null elements");
		}
		int num2 = 0;
		foreach (IBasicGeometry baseGeometry in baseGeometries)
		{
			igeometry_1[num2] = Geometry.FromBasicGeometry(baseGeometry);
			num2++;
		}
	}

	public override Coordinate ClosestPoint(Coordinate testPoint)
	{
		Coordinate result = null;
		double num = double.MaxValue;
		IGeometry[] geometries = Geometries;
		for (int i = 0; i < geometries.Length; i++)
		{
			Coordinate coordinate = geometries[i].ClosestPoint(testPoint);
			double num2 = testPoint.Distance(coordinate);
			if (!(num2 >= num))
			{
				num = num2;
				result = coordinate;
			}
		}
		return result;
	}

	public override IGeometry GetGeometryN(int n)
	{
		return igeometry_1[n];
	}

	public override IBasicGeometry GetBasicGeometryN(int index)
	{
		return igeometry_1[index];
	}

	public override bool EqualsExact(IGeometry other, double tolerance)
	{
		if (IsEquivalentClass(other))
		{
			GeometryCollection geometryCollection = (GeometryCollection)other;
			if (igeometry_1.Length != geometryCollection.Geometries.Length)
			{
				return false;
			}
			int num = 0;
			while (true)
			{
				if (num < igeometry_1.Length)
				{
					if (!((Geometry)igeometry_1[num]).EqualsExact(geometryCollection.Geometries[num], tolerance))
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
		return false;
	}

	public override void Apply(ICoordinateFilter filter)
	{
		for (int i = 0; i < igeometry_1.Length; i++)
		{
			igeometry_1[i].Apply(filter);
		}
	}

	public override void Apply(IGeometryFilter filter)
	{
		filter.Filter(this);
		for (int i = 0; i < igeometry_1.Length; i++)
		{
			igeometry_1[i].Apply(filter);
		}
	}

	public override void Apply(IGeometryComponentFilter filter)
	{
		filter.Filter(this);
		for (int i = 0; i < igeometry_1.Length; i++)
		{
			igeometry_1[i].Apply(filter);
		}
	}

	public override void Normalize()
	{
		for (int i = 0; i < igeometry_1.Length; i++)
		{
			igeometry_1[i].Normalize();
		}
		Array.Sort(igeometry_1);
	}

	public override int CompareToSameClass(object o)
	{
		ArrayList a = new ArrayList(igeometry_1);
		ArrayList b = new ArrayList(((GeometryCollection)o).igeometry_1);
		return Compare(a, b);
	}

	public IEnumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	protected override void OnCopy(Geometry copy)
	{
		if (copy is GeometryCollection geometryCollection)
		{
			IGeometry[] array = new Geometry[igeometry_1.Length];
			geometryCollection.igeometry_1 = array;
			for (int i = 0; i < igeometry_1.Length; i++)
			{
				geometryCollection.igeometry_1[i] = (Geometry)igeometry_1[i].Clone();
			}
		}
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		Envelope envelope = new Envelope();
		for (int i = 0; i < igeometry_1.Length; i++)
		{
			envelope.ExpandToInclude(igeometry_1[i].EnvelopeInternal);
		}
		return envelope;
	}

	public override void Rotate(Coordinate Origin, double radAngle)
	{
		IGeometry[] geometries = Geometries;
		foreach (IGeometry geometry in geometries)
		{
			if (!(geometry is IPolygon polygon))
			{
				if (!(geometry is ILineString lineString))
				{
					if (geometry is IPoint point)
					{
						point.Rotate(Origin, radAngle);
					}
				}
				else
				{
					lineString.Rotate(Origin, radAngle);
				}
			}
			else
			{
				polygon.Rotate(Origin, radAngle);
			}
		}
	}

	static GeometryCollection()
	{
		Class72.smethod_20();
		Empty = new GeometryFactory().CreateGeometryCollection(null);
	}
}
