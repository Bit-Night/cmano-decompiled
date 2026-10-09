namespace ICSharpCode.SharpZipLib.Core;

public class DirectoryEventArgs : ScanEventArgs
{
	private readonly bool bool_1;

	public bool HasMatchingFiles => bool_1;

	public DirectoryEventArgs(string name, bool hasMatchingFiles)
		: base(name)
	{
		bool_1 = hasMatchingFiles;
	}

	static DirectoryEventArgs()
	{
		Class72.smethod_20();
	}
}
