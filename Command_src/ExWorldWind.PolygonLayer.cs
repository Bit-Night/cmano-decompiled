using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CSMaterial.ExWorldWind;
using DXRenderer;
using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;
using GisSharpBlog.NetTopologySuite.IO;

namespace ExWorldWind;

public class PolygonLayer
{
	public class PolygonVertexBuffer
	{
		public Vector3[] vector3s;

		public int Vertcount => vector3s.Length;

		static PolygonVertexBuffer()
		{
			Class72.smethod_20();
		}
	}

	private readonly double double_0;

	public static bool WireframeMode;

	public bool IsAllowedToRender = true;

	private string string_0;

	private readonly List<PolygonVertexBuffer> list_0 = new List<PolygonVertexBuffer>();

	private bool bool_0;

	public PolygonLayer(string shapefilePath)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		string_0 = shapefilePath;
		ShapefileReader shapefileReader = new ShapefileReader(string_0);
		if (shapefileReader.Header.ShapeType != ShapeGeometryType.Polygon)
		{
			throw new Exception("Wrong shape type in shapefile. Expecting Polygon.");
		}
		double_0 = 6378137.0;
		List<Vector3> list = new List<Vector3>();
		int num = 0;
		Vector3 item = default(Vector3);
		Vector3 item2 = default(Vector3);
		Vector3 item3 = default(Vector3);
		foreach (Polygon item4 in shapefileReader.OfType<Polygon>())
		{
			ILinearRing shell = item4.Shell;
			ICoordinateSequence coordinateSequence = shell.CoordinateSequence;
			int numPoints = shell.NumPoints;
			ICoordinate coordinate = coordinateSequence.GetCoordinate(0);
			ICoordinate coordinate2 = coordinateSequence.GetCoordinate(numPoints - 1);
			for (int i = 0; i < numPoints - 1; i++)
			{
				ICoordinate coordinate3 = coordinateSequence.GetCoordinate(i);
				ICoordinate coordinate4 = coordinateSequence.GetCoordinate(i + 1);
				Vector3 val = MathEngine.SphericalToCartesian((float)coordinate3.Y, (float)coordinate3.X + 180f, (float)double_0);
				((Vector3)(ref item))..ctor(0f - val.Y, val.Z, val.X);
				list.Add(item);
				val = MathEngine.SphericalToCartesian((float)coordinate4.Y, (float)coordinate4.X + 180f, (float)double_0);
				((Vector3)(ref item))..ctor(0f - val.Y, val.Z, val.X);
				list.Add(item);
				num++;
				if (num > 1000)
				{
					num = 0;
					method_0(list);
				}
			}
			Vector3 val2 = MathEngine.SphericalToCartesian((float)coordinate2.Y, (float)coordinate2.X + 180f, (float)double_0);
			((Vector3)(ref item2))..ctor(0f - val2.Y, val2.Z, val2.X);
			list.Add(item2);
			Vector3 val3 = MathEngine.SphericalToCartesian((float)coordinate.Y, (float)coordinate.X + 180f, (float)double_0);
			((Vector3)(ref item3))..ctor(0f - val3.Y, val3.Z, val3.X);
			list.Add(item3);
		}
		method_0(list);
	}

	private void method_0(List<Vector3> list_1)
	{
		Vector3[] vector3s = list_1.ToArray();
		list_1.Clear();
		list_0.Add(new PolygonVertexBuffer
		{
			vector3s = vector3s
		});
	}

	public void Render(float alpha, Vector4 color, bool forceRefresh)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		List<Vertex> list = new List<Vertex>();
		List<uint> list2 = new List<uint>();
		Main instance = Main.Instance;
		if (forceRefresh)
		{
			instance.RemoveDrawLineList(string_0);
			bool_0 = false;
		}
		if (!bool_0)
		{
			foreach (PolygonVertexBuffer item2 in list_0)
			{
				for (int i = 0; i < item2.Vertcount; i++)
				{
					Vertex item = new Vertex(item2.vector3s[i], color);
					list.Add(item);
					list2.Add((uint)num++);
				}
			}
			instance.DrawLineList(string_0, list.ToArray(), list2.ToArray(), alpha);
		}
		else
		{
			instance.DrawLineList(string_0, null, null, alpha);
		}
		bool_0 = true;
	}

	static PolygonLayer()
	{
		Class72.smethod_20();
	}
}
