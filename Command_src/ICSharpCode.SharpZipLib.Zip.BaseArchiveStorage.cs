using System.IO;

namespace ICSharpCode.SharpZipLib.Zip;

public abstract class BaseArchiveStorage : IArchiveStorage
{
	private readonly FileUpdateMode fileUpdateMode_0;

	public FileUpdateMode UpdateMode => fileUpdateMode_0;

	protected BaseArchiveStorage(FileUpdateMode updateMode)
	{
		fileUpdateMode_0 = updateMode;
	}

	public abstract Stream GetTemporaryOutput();

	public abstract Stream ConvertTemporaryToFinal();

	public abstract Stream MakeTemporaryCopy(Stream stream);

	public abstract Stream OpenForDirectUpdate(Stream stream);

	public abstract void Dispose();

	static BaseArchiveStorage()
	{
		Class72.smethod_20();
	}
}
