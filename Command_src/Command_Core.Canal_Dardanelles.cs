using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Command_Core;

public sealed class Canal_Dardanelles : FixedGeoPolygon
{
	private List<Geopoint_Struct> list_0;

	public override List<Geopoint_Struct> Area
	{
		get
		{
			if (Information.IsNothing((object)list_0))
			{
				List<Geopoint_Struct> list = new List<Geopoint_Struct>(8);
				list.Add(new Geopoint_Struct(26.16, 40.08));
				list.Add(new Geopoint_Struct(26.24, 40.08));
				list.Add(new Geopoint_Struct(26.66, 40.5));
				list.Add(new Geopoint_Struct(26.75, 40.5));
				list.Add(new Geopoint_Struct(26.75, 40.33));
				list.Add(new Geopoint_Struct(26.66, 40.33));
				list.Add(new Geopoint_Struct(26.25, 39.91));
				list.Add(new Geopoint_Struct(26.16, 39.91));
				list_0 = list;
			}
			return list_0;
		}
	}

	static Canal_Dardanelles()
	{
		Class72.smethod_20();
	}
}
