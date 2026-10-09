namespace ICSharpCode.SharpZipLib.Zip.Compression;

public class DeflaterPending : PendingBuffer
{
	public DeflaterPending()
		: base(65536)
	{
	}

	static DeflaterPending()
	{
		Class72.smethod_20();
	}
}
