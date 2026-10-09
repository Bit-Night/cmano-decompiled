namespace SRTM.Sources.USGS;

public sealed class USGSSource : ISRTMSource
{
	public const string SOURCE = "https://dds.cr.usgs.gov/srtm/version2_1/SRTM3/";

	public static string[] CONTINENTS;

	public bool GetMissingCell(string path, string name)
	{
		return false;
	}

	static USGSSource()
	{
		Class72.smethod_20();
		CONTINENTS = new string[6] { "Africa", "Australia", "Eurasia", "Islands", "North_America", "South_America" };
	}
}
