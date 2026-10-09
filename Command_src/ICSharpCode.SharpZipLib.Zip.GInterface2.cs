using System.IO;

namespace ICSharpCode.SharpZipLib.Zip;

public interface GInterface2
{
	Stream GetSource(ZipEntry entry, string name);
}
