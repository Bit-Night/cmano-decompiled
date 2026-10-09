using System.Net;

namespace SRTM.Sources.NASA;

public sealed class NASASource : ISRTMSource
{
	private NetworkCredential networkCredential_0;

	public const string SOURCE = "https://e4ftl01.cr.usgs.gov/MEASURES/SRTMGL1.003/2000.02.11/";

	public NASASource(NetworkCredential credentials)
	{
		networkCredential_0 = credentials;
	}

	public bool GetMissingCell(string path, string name)
	{
		return false;
	}

	static NASASource()
	{
		Class72.smethod_20();
	}
}
