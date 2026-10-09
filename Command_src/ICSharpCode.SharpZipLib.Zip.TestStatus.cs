namespace ICSharpCode.SharpZipLib.Zip;

public class TestStatus
{
	private readonly ZipFile zipFile_0;

	private ZipEntry zipEntry_0;

	private bool bool_0;

	private int int_0;

	private long long_0;

	private TestOperation testOperation_0;

	public TestOperation Operation => testOperation_0;

	public ZipFile File => zipFile_0;

	public ZipEntry Entry => zipEntry_0;

	public int ErrorCount => int_0;

	public long BytesTested => long_0;

	public bool EntryValid => bool_0;

	public TestStatus(ZipFile file)
	{
		zipFile_0 = file;
	}

	internal void AddError()
	{
		int_0++;
		bool_0 = false;
	}

	internal void SetOperation(TestOperation operation)
	{
		testOperation_0 = operation;
	}

	internal void SetEntry(ZipEntry entry)
	{
		zipEntry_0 = entry;
		bool_0 = true;
		long_0 = 0L;
	}

	internal void SetBytesTested(long value)
	{
		long_0 = value;
	}

	static TestStatus()
	{
		Class72.smethod_20();
	}
}
