namespace SRTM;

public interface ISRTMSource
{
	bool GetMissingCell(string path, string name);
}
