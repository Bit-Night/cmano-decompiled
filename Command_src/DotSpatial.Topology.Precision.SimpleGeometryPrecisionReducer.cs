using System.Collections.Generic;
using System.Linq;
using DotSpatial.Topology.Utilities;

namespace DotSpatial.Topology.Precision;

public class SimpleGeometryPrecisionReducer
{
	private class Class48 : GeometryEditor.CoordinateOperation
	{
		private readonly SimpleGeometryPrecisionReducer simpleGeometryPrecisionReducer_0;

		public Class48(SimpleGeometryPrecisionReducer simpleGeometryPrecisionReducer_1)
		{
			simpleGeometryPrecisionReducer_0 = simpleGeometryPrecisionReducer_1;
		}

		public override IList<Coordinate> Edit(IList<Coordinate> coordinates, IGeometry geom)
		{
			if (coordinates.Count != 0)
			{
				Coordinate[] array = new Coordinate[coordinates.Count];
				for (int i = 0; i < coordinates.Count; i++)
				{
					Coordinate coordinate = new Coordinate(coordinates[i]);
					new PrecisionModel(simpleGeometryPrecisionReducer_0.precisionModel_0).MakePrecise(coordinate);
					array[i] = coordinate;
				}
				Coordinate[] array2 = new CoordinateList(array, allowRepeated: false).ToCoordinateArray();
				int num = 0;
				if (geom is LineString)
				{
					num = 2;
				}
				if (geom is LinearRing)
				{
					num = 4;
				}
				Coordinate[] array3 = array;
				if (simpleGeometryPrecisionReducer_0.bool_1)
				{
					array3 = null;
				}
				if (array2.Length < num)
				{
					return array3?.ToList();
				}
				return array2.ToList();
			}
			return null;
		}

		static Class48()
		{
			Class72.smethod_20();
		}
	}

	private readonly PrecisionModel precisionModel_0;

	private bool bool_0;

	private bool bool_1 = true;

	public virtual bool RemoveCollapsedComponents
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

	public virtual bool ChangePrecisionModel
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public SimpleGeometryPrecisionReducer(PrecisionModel pm)
	{
		precisionModel_0 = pm;
	}

	public virtual IGeometry Reduce(IGeometry geom)
	{
		GeometryEditor geometryEditor = ((!bool_0) ? new GeometryEditor() : new GeometryEditor(new GeometryFactory(precisionModel_0)));
		return geometryEditor.Edit(geom, new Class48(this));
	}

	static SimpleGeometryPrecisionReducer()
	{
		Class72.smethod_20();
	}
}
