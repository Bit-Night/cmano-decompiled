using System.IO;

namespace ICSharpCode.SharpZipLib.Zip;

public class DynamicDiskDataSource : GInterface2
{
	public Stream GetSource(ZipEntry entry, string name)
	{
		Stream result = null;
		if (name != null)
		{
			result = File.Open(name, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
		return result;
	}

	static DynamicDiskDataSource()
	{
		Class72.smethod_20();
	}
}
