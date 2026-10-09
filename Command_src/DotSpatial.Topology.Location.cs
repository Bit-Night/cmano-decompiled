using System;

namespace DotSpatial.Topology;

public static class Location
{
	public static char ToLocationSymbol(LocationType locationValue)
	{
		return locationValue switch
		{
			LocationType.Null => '-', 
			LocationType.Interior => 'i', 
			LocationType.Boundary => 'b', 
			LocationType.Exterior => 'e', 
			_ => throw new ArgumentException("Unknown location value: " + locationValue), 
		};
	}

	static Location()
	{
		Class72.smethod_20();
	}
}
