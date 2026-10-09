namespace ICSharpCode.SharpZipLib.Zip.Compression;

internal sealed class PooledInflater : Inflater
{
	public PooledInflater(bool noHeader)
		: base(noHeader)
	{
	}

	static PooledInflater()
	{
		Class72.smethod_20();
	}
}
