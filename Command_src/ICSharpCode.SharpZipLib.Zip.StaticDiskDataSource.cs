using System.IO;

namespace ICSharpCode.SharpZipLib.Zip;

public class StaticDiskDataSource : IStaticDataSource
{
	private readonly string string_0;

	public StaticDiskDataSource(string fileName)
	{
		string_0 = fileName;
	}

	public Stream GetSource()
	{
		return File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
	}

	static StaticDiskDataSource()
	{
		Class72.smethod_20();
	}
}
