using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Canal_Suez : FixedGeoPolygon
{
	private List<Geopoint_Struct> list_0;

	public override List<Geopoint_Struct> Area
	{
		get
		{
			if (Information.IsNothing((object)list_0))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>();
				list.Add(new Geopoint_Struct(32.25, 31.3));
				list.Add(new Geopoint_Struct(32.25, 30.3));
				list.Add(new Geopoint_Struct(32.3, 30.25));
				list.Add(new Geopoint_Struct(32.35, 30.2));
				list.Add(new Geopoint_Struct(32.4, 30.15));
				list.Add(new Geopoint_Struct(32.45, 30.1));
				list.Add(new Geopoint_Struct(32.45, 29.9));
				list.Add(new Geopoint_Struct(32.6, 29.9));
				list.Add(new Geopoint_Struct(32.6, 30.25));
				list.Add(new Geopoint_Struct(32.45, 30.4));
				list.Add(new Geopoint_Struct(32.45, 31.3));
				list_0 = list;
			}
			return list_0;
		}
	}

	static Canal_Suez()
	{
		Class72.smethod_20();
	}
}
