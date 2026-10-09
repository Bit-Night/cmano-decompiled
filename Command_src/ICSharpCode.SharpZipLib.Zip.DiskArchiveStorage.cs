using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class DiskArchiveStorage : BaseArchiveStorage
{
	private Stream stream_0;

	private readonly string string_0;

	private string string_1;

	public DiskArchiveStorage(ZipFile file, FileUpdateMode updateMode)
		: base(updateMode)
	{
		if (file.Name == null)
		{
			throw new ZipException("Cant handle non file archives");
		}
		string_0 = file.Name;
	}

	public DiskArchiveStorage(ZipFile file)
		: this(file, FileUpdateMode.Safe)
	{
	}

	public override Stream GetTemporaryOutput()
	{
		string_1 = PathUtils.GetTempFileName(string_1);
		stream_0 = File.Open(string_1, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
		return stream_0;
	}

	public override Stream ConvertTemporaryToFinal()
	{
		if (stream_0 != null)
		{
			Stream stream = null;
			string tempFileName = PathUtils.GetTempFileName(string_0);
			bool flag = false;
			try
			{
				stream_0.Dispose();
				File.Move(string_0, tempFileName);
				File.Move(string_1, string_0);
				flag = true;
				File.Delete(tempFileName);
				return File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.Read);
			}
			catch (Exception)
			{
				stream = null;
				if (!flag)
				{
					File.Move(tempFileName, string_0);
					File.Delete(string_1);
				}
				throw;
			}
		}
		throw new ZipException("No temporary stream has been created");
	}

	public override Stream MakeTemporaryCopy(Stream stream)
	{
		stream.Dispose();
		string_1 = PathUtils.GetTempFileName(string_0);
		File.Copy(string_0, string_1, overwrite: true);
		stream_0 = new FileStream(string_1, FileMode.Open, FileAccess.ReadWrite);
		return stream_0;
	}

	public override Stream OpenForDirectUpdate(Stream stream)
	{
		if (stream != null && stream.CanWrite)
		{
			return stream;
		}
		stream?.Dispose();
		return new FileStream(string_0, FileMode.Open, FileAccess.ReadWrite);
	}

	public override void Dispose()
	{
		if (stream_0 != null)
		{
			stream_0.Dispose();
		}
	}

	static DiskArchiveStorage()
	{
		Class72.smethod_20();
	}
}
