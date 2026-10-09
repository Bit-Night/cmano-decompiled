using System.Collections.Generic;

namespace Command_Core;

public sealed class Canal_Panama : FixedGeoPolygon
{
	private List<Geopoint_Struct> list_0;

	public override List<Geopoint_Struct> Area
	{
		get
		{
			if (list_0 == null)
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				list.Add(new Geopoint_Struct(-79.9, 9.45));
				list.Add(new Geopoint_Struct(-79.95, 9.4));
				list.Add(new Geopoint_Struct(-79.95, 9.4));
				list.Add(new Geopoint_Struct(-79.95, 9.35));
				list.Add(new Geopoint_Struct(-79.95, 9.3));
				list.Add(new Geopoint_Struct(-79.95, 9.25));
				list.Add(new Geopoint_Struct(-79.9, 9.2));
				list.Add(new Geopoint_Struct(-79.85, 9.15));
				list.Add(new Geopoint_Struct(-79.8, 9.1));
				list.Add(new Geopoint_Struct(-79.75, 9.05));
				list.Add(new Geopoint_Struct(-79.7, 9.0));
				list.Add(new Geopoint_Struct(-79.65, 8.95));
				list.Add(new Geopoint_Struct(-79.6, 8.9));
				list.Add(new Geopoint_Struct(-79.55, 8.85));
				list.Add(new Geopoint_Struct(-79.48, 8.92));
				list.Add(new Geopoint_Struct(-79.55, 9.0));
				list.Add(new Geopoint_Struct(-79.6, 9.05));
				list.Add(new Geopoint_Struct(-79.65, 9.1));
				list.Add(new Geopoint_Struct(-79.7, 9.15));
				list.Add(new Geopoint_Struct(-79.75, 9.2));
				list.Add(new Geopoint_Struct(-79.8, 9.25));
				list.Add(new Geopoint_Struct(-79.85, 9.3));
				list.Add(new Geopoint_Struct(-79.85, 9.35));
				list.Add(new Geopoint_Struct(-79.85, 9.4));
				list_0 = list;
			}
			return list_0;
		}
	}

	static Canal_Panama()
	{
		Class72.smethod_20();
	}
}
