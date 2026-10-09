using System.IO;

namespace ICSharpCode.SharpZipLib.Core;

public class PathFilter : IScanFilter
{
	private readonly NameFilter nameFilter_0;

	public PathFilter(string filter)
	{
		nameFilter_0 = new NameFilter(filter);
	}

	public virtual bool IsMatch(string name)
	{
		bool result = false;
		if (name != null)
		{
			string name2 = ((name.Length <= 0) ? "" : Path.GetFullPath(name));
			result = nameFilter_0.IsMatch(name2);
		}
		return result;
	}

	static PathFilter()
	{
		Class72.smethod_20();
	}
}
