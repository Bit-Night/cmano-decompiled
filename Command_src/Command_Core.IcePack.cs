using System.Collections.Generic;

namespace Command_Core;

public sealed class IcePack : FixedGeoPolygon
{
	private List<Geopoint_Struct> list_0;

	public override List<Geopoint_Struct> Area => list_0;

	public IcePack(List<Geopoint_Struct> theArea)
	{
		list_0 = theArea;
	}

	static IcePack()
	{
		Class72.smethod_20();
	}
}
