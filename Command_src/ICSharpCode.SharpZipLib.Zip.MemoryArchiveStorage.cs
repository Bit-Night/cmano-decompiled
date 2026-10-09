using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class MemoryArchiveStorage : BaseArchiveStorage
{
	private MemoryStream memoryStream_0;

	private MemoryStream memoryStream_1;

	public MemoryStream FinalStream => memoryStream_1;

	public MemoryArchiveStorage()
		: base(FileUpdateMode.Direct)
	{
	}

	public MemoryArchiveStorage(FileUpdateMode updateMode)
		: base(updateMode)
	{
	}

	public override Stream GetTemporaryOutput()
	{
		memoryStream_0 = new MemoryStream();
		return memoryStream_0;
	}

	public override Stream ConvertTemporaryToFinal()
	{
		if (memoryStream_0 == null)
		{
			throw new ZipException("No temporary stream has been created");
		}
		memoryStream_1 = new MemoryStream(memoryStream_0.ToArray());
		return memoryStream_1;
	}

	public override Stream MakeTemporaryCopy(Stream stream)
	{
		memoryStream_0 = new MemoryStream();
		stream.Position = 0L;
		StreamUtils.Copy(stream, memoryStream_0, new byte[4096]);
		return memoryStream_0;
	}

	public override Stream OpenForDirectUpdate(Stream stream)
	{
		Stream stream2;
		if (stream != null && stream.CanWrite)
		{
			stream2 = stream;
		}
		else
		{
			stream2 = new MemoryStream();
			if (stream != null)
			{
				stream.Position = 0L;
				StreamUtils.Copy(stream, stream2, new byte[4096]);
				stream.Dispose();
			}
		}
		return stream2;
	}

	public override void Dispose()
	{
		if (memoryStream_0 != null)
		{
			memoryStream_0.Dispose();
		}
	}

	static MemoryArchiveStorage()
	{
		Class72.smethod_20();
	}
}
