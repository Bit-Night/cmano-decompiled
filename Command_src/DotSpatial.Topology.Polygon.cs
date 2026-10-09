using System;
using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Algorithm;

namespace DotSpatial.Topology;

[Serializable]
public class Polygon : Geometry, IPolygon, IGeometry, IComparable, IRelate, IOverlay, IBasicGeometry, ICloneable, IBasicPolygon
{
	private ILinearRing[] ilinearRing_0;

	private ILinearRing ilinearRing_1;

	public static readonly IPolygon Empty;

	public virtual IBasicLineString ExteriorRing => ilinearRing_1;

	public override double Area
	{
		get
		{
			double num = 0.0;
			num += Math.Abs(CgAlgorithms.SignedArea(ilinearRing_1.Coordinates));
			for (int i = 0; i < ilinearRing_0.Length; i++)
			{
				num -= Math.Abs(CgAlgorithms.SignedArea(ilinearRing_0[i].Coordinates));
			}
			return num;
		}
	}

	public override IGeometry Boundary
	{
		get
		{
			if (!IsEmpty)
			{
				ILinearRing[] array = new ILinearRing[ilinearRing_0.Length + 1];
				array[0] = ilinearRing_1;
				for (int i = 0; i < ilinearRing_0.Length; i++)
				{
					array[i + 1] = ilinearRing_0[i];
				}
				if (array.Length <= 1)
				{
					return base.Factory.CreateLinearRing(array[0].Coordinates);
				}
				IGeometryFactory factory = base.Factory;
				IBasicLineString[] lineStrings = array;
				return factory.CreateMultiLineString(lineStrings);
			}
			return base.Factory.CreateGeometryCollection(null);
		}
	}

	public override DimensionType BoundaryDimension => DimensionType.Curve;

	public override Coordinate Coordinate => ilinearRing_1.Coordinate;

	public override IList<Coordinate> Coordinates
	{
		get
		{
			if (IsEmpty)
			{
				return new Coordinate[0];
			}
			List<Coordinate> list = new List<Coordinate>();
			list.AddRange(Shell.Coordinates);
			ILinearRing[] holes = Holes;
			foreach (ILinearRing linearRing in holes)
			{
				list.AddRange(linearRing.Coordinates);
			}
			return list;
		}
		set
		{
			Shell.Coordinates = value;
		}
	}

	public override DimensionType Dimension => DimensionType.Surface;

	public override FeatureType FeatureType => FeatureType.Polygon;

	public override string GeometryType => "Polygon";

	public ILinearRing[] Holes
	{
		get
		{
			return ilinearRing_0;
		}
		set
		{
			ilinearRing_0 = value;
		}
	}

	ICollection<IBasicLineString> IBasicPolygon.Holes
	{
		get
		{
			return ilinearRing_0;
		}
		set
		{
			method_1(value);
		}
	}

	public override bool IsEmpty => ilinearRing_1.IsEmpty;

	public override bool IsRectangle
	{
		get
		{
			if (NumHoles != 0)
			{
				return false;
			}
			if (ilinearRing_1 != null)
			{
				if (ilinearRing_1.NumPoints != 5)
				{
					return false;
				}
				IList<Coordinate> coordinates = ilinearRing_1.Coordinates;
				IEnvelope envelopeInternal = EnvelopeInternal;
				int num = 0;
				while (true)
				{
					if (num < 5)
					{
						Coordinate coordinate = coordinates[num];
						double x = coordinate.X;
						if (x == envelopeInternal.Minimum.X || x == envelopeInternal.Maximum.X)
						{
							double y = coordinate.Y;
							if (y != envelopeInternal.Minimum.Y && y != envelopeInternal.Maximum.Y)
							{
								break;
							}
							num++;
							continue;
						}
						return false;
					}
					double num2 = coordinates[0].X;
					double num3 = coordinates[0].Y;
					int num4 = 1;
					while (true)
					{
						if (num4 <= 4)
						{
							double x2 = coordinates[num4].X;
							double y2 = coordinates[num4].Y;
							if (x2 != num2 == (y2 != num3))
							{
								break;
							}
							num2 = x2;
							num3 = y2;
							num4++;
							continue;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}
	}

	public override bool IsSimple => true;

	public override double Length
	{
		get
		{
			double num = 0.0;
			num += ilinearRing_1.Length;
			ILinearRing[] holes = Holes;
			foreach (ILinearRing linearRing in holes)
			{
				num += linearRing.Length;
			}
			return num;
		}
	}

	public virtual int NumHoles => ilinearRing_0.Length;

	public override int NumPoints
	{
		get
		{
			int num = ilinearRing_1.NumPoints;
			for (int i = 0; i < ilinearRing_0.Length; i++)
			{
				num += ilinearRing_0[i].NumPoints;
			}
			return num;
		}
	}

	public virtual ILinearRing Shell
	{
		get
		{
			return ilinearRing_1;
		}
		set
		{
			ilinearRing_1 = value;
		}
	}

	IBasicLineString IBasicPolygon.Shell
	{
		get
		{
			return ilinearRing_1;
		}
		set
		{
			method_2(value);
		}
	}

	public Polygon(ILinearRing shell, IGeometryFactory factory)
		: this(shell, null, factory)
	{
	}

	public Polygon(ILinearRing shell)
		: this(shell, null, Geometry.DefaultFactory)
	{
	}

	public Polygon(IEnumerable<Coordinate> shell)
		: this(new LinearRing(shell))
	{
	}

	public Polygon(ILinearRing shell, ILinearRing[] holes)
		: this(shell, holes, Geometry.DefaultFactory)
	{
	}

	public Polygon(ILinearRing inShell, ILinearRing[] inHoles, IGeometryFactory factory)
		: base(factory)
	{
		if (inShell == null)
		{
			inShell = base.Factory.CreateLinearRing(null);
		}
		if (inHoles == null)
		{
			ILinearRing[] array = new LinearRing[0];
			inHoles = array;
		}
		if (Geometry.HasNullElements(inHoles))
		{
			throw new PolygonException(TopologyText.PolygonException_HoleElementNull);
		}
		if (inShell.IsEmpty)
		{
			IGeometry[] geometries = inHoles;
			if (Geometry.HasNonEmptyElements(geometries))
			{
				throw new PolygonException(TopologyText.PolygonException_ShellEmptyButHolesNot);
			}
		}
		ilinearRing_1 = inShell;
		ilinearRing_0 = inHoles;
	}

	public Polygon(IBasicPolygon polygonBase)
		: base(Geometry.DefaultFactory)
	{
		method_1(polygonBase.Holes);
		LinearRing linearRing = new LinearRing(polygonBase.Shell);
		if (Geometry.HasNullElements(ilinearRing_0))
		{
			throw new PolygonException(TopologyText.PolygonException_HoleElementNull);
		}
		if (linearRing.IsEmpty)
		{
			IGeometry[] geometries = ilinearRing_0;
			if (Geometry.HasNonEmptyElements(geometries))
			{
				throw new PolygonException(TopologyText.PolygonException_ShellEmptyButHolesNot);
			}
		}
		ilinearRing_1 = linearRing;
	}

	public override void Apply(ICoordinateFilter filter)
	{
		ilinearRing_1.Apply(filter);
		for (int i = 0; i < ilinearRing_0.Length; i++)
		{
			ilinearRing_0[i].Apply(filter);
		}
	}

	public override void Apply(IGeometryFilter filter)
	{
		filter.Filter(this);
	}

	public override void Apply(IGeometryComponentFilter filter)
	{
		filter.Filter(this);
		ilinearRing_1.Apply(filter);
		for (int i = 0; i < ilinearRing_0.Length; i++)
		{
			ilinearRing_0[i].Apply(filter);
		}
	}

	public override int CompareToSameClass(object o)
	{
		ILinearRing linearRing = ilinearRing_1;
		ILinearRing shell = ((IPolygon)o).Shell;
		return linearRing.CompareToSameClass(shell);
	}

	public override void ClearEnvelope()
	{
		ilinearRing_1.ClearEnvelope();
		ILinearRing[] holes = Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			holes[i].ClearEnvelope();
		}
	}

	public override IGeometry ConvexHull()
	{
		return ilinearRing_1.ConvexHull();
	}

	public override bool EqualsExact(IGeometry other, double tolerance)
	{
		if (IsEquivalentClass(other))
		{
			Polygon polygon = (Polygon)other;
			ILinearRing linearRing = ilinearRing_1;
			IGeometry shell = polygon.Shell;
			if (linearRing.EqualsExact(shell, tolerance))
			{
				if (ilinearRing_0.Length != polygon.Holes.Length)
				{
					return false;
				}
				if (ilinearRing_0.Length != polygon.Holes.Length)
				{
					return false;
				}
				int num = 0;
				while (true)
				{
					if (num < ilinearRing_0.Length)
					{
						if (!ilinearRing_0[num].EqualsExact(polygon.Holes[num], tolerance))
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
		return false;
	}

	public override Coordinate ClosestPoint(Coordinate testPoint)
	{
		if (Intersects(new Point(testPoint)))
		{
			Coordinate coordinate = ilinearRing_1.ClosestPoint(testPoint);
			double num = testPoint.Distance(coordinate);
			ILinearRing[] holes = Holes;
			for (int i = 0; i < holes.Length; i++)
			{
				Coordinate coordinate2 = holes[i].ClosestPoint(testPoint);
				double num2 = testPoint.Distance(coordinate2);
				if (!(num2 >= num))
				{
					num = num2;
					coordinate = coordinate2;
				}
			}
			return coordinate;
		}
		return ilinearRing_1.ClosestPoint(testPoint);
	}

	public virtual ILineString GetInteriorRingN(int n)
	{
		return ilinearRing_0[n];
	}

	public override void Normalize()
	{
		smethod_1(ilinearRing_1, bool_0: true);
		ILinearRing[] array = ilinearRing_0;
		for (int i = 0; i < array.Length; i++)
		{
			smethod_1((LinearRing)array[i], bool_0: false);
		}
		Array.Sort(Holes);
	}

	protected override void OnCopy(Geometry copy)
	{
		base.OnCopy(copy);
		if (copy is Polygon polygon)
		{
			polygon.Shell = CloneableEM.Copy(ilinearRing_1);
			polygon.Holes = new ILinearRing[ilinearRing_0.Length];
			for (int i = 0; i < ilinearRing_0.Length; i++)
			{
				polygon.Holes[i] = CloneableEM.Copy(Holes[i]);
			}
		}
	}

	protected override IEnvelope ComputeEnvelopeInternal()
	{
		return ilinearRing_1.EnvelopeInternal;
	}

	public override void Rotate(Coordinate Origin, double radAngle)
	{
		ilinearRing_1.Rotate(Origin, radAngle);
		ILinearRing[] holes = Holes;
		for (int i = 0; i < holes.Length; i++)
		{
			holes[i].Rotate(Origin, radAngle);
		}
	}

	private static void smethod_1(object object_1, bool bool_0)
	{
		if (!((IGeometry)object_1).IsEmpty)
		{
			Coordinate[] array = new Coordinate[((IBasicGeometry)object_1).Coordinates.Count - 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((IBasicGeometry)object_1).Coordinates[i];
			}
			Coordinate firstCoordinate = CoordinateArrays.MinCoordinate(array);
			CoordinateArrays.Scroll(array, firstCoordinate);
			List<Coordinate> list = new List<Coordinate>();
			for (int j = 0; j < array.Length; j++)
			{
				list.Add(array[j]);
			}
			list.Add(CloneableEM.Copy(array[0]));
			((IBasicGeometry)object_1).Coordinates = list;
			if (CgAlgorithms.IsCounterClockwise(((IBasicGeometry)object_1).Coordinates) == bool_0)
			{
				((IBasicGeometry)object_1).Coordinates = ((IBasicGeometry)object_1).Coordinates.Reverse().ToList();
			}
		}
	}

	private void method_1(ICollection<IBasicLineString> icollection_0)
	{
		if (icollection_0 != null && icollection_0.Count != 0)
		{
			ilinearRing_0 = icollection_0 as ILinearRing[];
			if (ilinearRing_0 != null)
			{
				return;
			}
			List<ILinearRing> list = new List<ILinearRing>();
			foreach (IBasicLineString item in icollection_0)
			{
				list.Add(new LinearRing(Geometry.FromBasicGeometry(item) as ILineString));
			}
			ilinearRing_0 = list.ToArray();
		}
		else
		{
			ilinearRing_0 = new ILinearRing[0];
		}
	}

	private void method_2(IBasicLineString ibasicLineString_0)
	{
		if (ibasicLineString_0 == null)
		{
			ilinearRing_1 = null;
		}
		else if (!(ibasicLineString_0 is ILinearRing))
		{
			ilinearRing_1 = new LinearRing(ibasicLineString_0);
		}
	}

	static Polygon()
	{
		Class72.smethod_20();
		Empty = new GeometryFactory().CreatePolygon(null, null);
	}
}
