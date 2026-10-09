namespace DotSpatial.Topology;

public enum VectorGeometryType : long
{
	wkbUnknown = 0L,
	wkbPoint = 1L,
	wkbLineString = 2L,
	wkbPolygon = 3L,
	wkbMultiPoint = 4L,
	wkbMultiLineString = 5L,
	wkbMultiPolygon = 6L,
	wkbGeometryCollection = 7L,
	wkbLinearRing = 101L,
	const_9 = 2147483649L,
	wkbLineString25D = 2147483650L,
	wkbPolygon25D = 2147483651L,
	wkbMultiPoint25D = 2147483652L,
	wkbMultiLineString25D = 2147483653L,
	const_14 = 2147483654L
}
