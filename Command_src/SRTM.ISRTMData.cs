namespace SRTM;

public interface ISRTMData
{
	void Unload();

	int? GetElevation(double latitude, double longitude);

	double? GetElevationBilinear(double latitude, double longitude);
}
