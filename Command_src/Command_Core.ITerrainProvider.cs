namespace Command_Core;

public interface ITerrainProvider
{
	string TerrainFilesPath { get; set; }

	string Description { get; }

	bool Initialize();

	short GetElevation(double theLat, double theLon, bool RequestIsFromGUI, bool UseCaching = true);

	void ClearCache();

	void DisposeResources();

	(bool IsOverland, short? RetrievedElevation) PointIsOverland(double theLat, double theLon);

	bool TerrainBlocksLOS(float theDist, double Distance_Cartesian, double X_S, double Y_S, double Z_S, double deltaX, double deltaY, double deltaZ, float Alt_Src, float Alt_Dest, bool LandMassCheck, bool IgnoreRadarHorizon, Scenario CurrentScen, Side NatureSide);

	float LandPercentageInThisSquare(double theLat, double theLon, float Radius_nm);

	bool GeopointsAreOnSameOrAdjacentCell(double GP1_Lat, double GP1_Lon, double GP2_Lat, double GP2_Lon);

	Terrain.TerrainRasterCell[] GetAllCellsInThisRadius(double theLat, double theLon, float Radius_nm, bool IncludeElevations);

	Terrain.TerrainRasterCell GetSingleRasterCell(double theLat, double theLon);

	short GetMaxForThisDegCell(double theLat, double theLon);

	short GetMinForThisDegCell(double theLat, double theLon);
}
