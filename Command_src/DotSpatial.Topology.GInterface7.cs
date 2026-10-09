namespace DotSpatial.Topology;

public interface GInterface7
{
	void Add(GInterface7 im);

	void Set(LocationType row, LocationType column, DimensionType dimensionValue);

	void Set(string dimensionSymbols);

	void SetAtLeast(LocationType row, LocationType column, DimensionType minimumDimensionValue);

	void SetAtLeastIfValid(LocationType row, LocationType column, DimensionType minimumDimensionValue);

	void SetAtLeast(string minimumDimensionSymbols);

	void SetAll(DimensionType dimensionValue);

	DimensionType Get(LocationType row, LocationType column);

	bool IsDisjoint();

	bool IsIntersects();

	bool IsTouches(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB);

	bool IsCrosses(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB);

	bool IsWithin();

	bool IsContains();

	bool IsCovers();

	bool IsEquals(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB);

	bool IsOverlaps(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB);

	bool Matches(string requiredDimensionSymbols);

	GInterface7 Transpose();

	new string ToString();
}
