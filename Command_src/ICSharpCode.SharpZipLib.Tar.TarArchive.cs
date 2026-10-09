using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarArchive : IDisposable
{
	[CompilerGenerated]
	private ProgressMessageHandler progressMessageHandler_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private string string_0 = string.Empty;

	private int int_1;

	private string string_1 = string.Empty;

	private string string_2;

	private string string_3;

	private bool bool_2;

	private TarInputStream tarInputStream_0;

	private TarOutputStream tarOutputStream_0;

	private bool bool_3;

	public bool AsciiTranslate
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return bool_1;
		}
		set
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			bool_1 = value;
		}
	}

	public string PathPrefix
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_3;
		}
		set
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			string_3 = value;
		}
	}

	public string RootPath
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_2;
		}
		set
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			string_2 = TarStringExtension.ToTarArchivePath(value).TrimEnd(new char[1] { '/' });
		}
	}

	public bool ApplyUserInfoOverrides
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return bool_2;
		}
		set
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			bool_2 = value;
		}
	}

	public int UserId
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return int_0;
		}
	}

	public string UserName
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_0;
		}
	}

	public int GroupId
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return int_1;
		}
	}

	public string GroupName
	{
		get
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			return string_1;
		}
	}

	public int RecordSize
	{
		get
		{
			if (!bool_3)
			{
				if (tarInputStream_0 == null)
				{
					if (tarOutputStream_0 == null)
					{
						return 10240;
					}
					return tarOutputStream_0.RecordSize;
				}
				return tarInputStream_0.RecordSize;
			}
			throw new ObjectDisposedException("TarArchive");
		}
	}

	public bool IsStreamOwner
	{
		set
		{
			if (tarInputStream_0 != null)
			{
				tarInputStream_0.IsStreamOwner = value;
			}
			else
			{
				tarOutputStream_0.IsStreamOwner = value;
			}
		}
	}

	public event ProgressMessageHandler ProgressMessageEvent
	{
		[CompilerGenerated]
		add
		{
			ProgressMessageHandler progressMessageHandler = progressMessageHandler_0;
			ProgressMessageHandler progressMessageHandler2;
			do
			{
				progressMessageHandler2 = progressMessageHandler;
				ProgressMessageHandler value2 = (ProgressMessageHandler)Delegate.Combine(progressMessageHandler2, value);
				progressMessageHandler = Interlocked.CompareExchange(ref progressMessageHandler_0, value2, progressMessageHandler2);
			}
			while ((object)progressMessageHandler != progressMessageHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ProgressMessageHandler progressMessageHandler = progressMessageHandler_0;
			ProgressMessageHandler progressMessageHandler2;
			do
			{
				progressMessageHandler2 = progressMessageHandler;
				ProgressMessageHandler value2 = (ProgressMessageHandler)Delegate.Remove(progressMessageHandler2, value);
				progressMessageHandler = Interlocked.CompareExchange(ref progressMessageHandler_0, value2, progressMessageHandler2);
			}
			while ((object)progressMessageHandler != progressMessageHandler2);
		}
	}

	protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
	{
		progressMessageHandler_0?.Invoke(this, entry, message);
	}

	protected TarArchive()
	{
	}

	protected TarArchive(TarInputStream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		tarInputStream_0 = stream;
	}

	protected TarArchive(TarOutputStream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		tarOutputStream_0 = stream;
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static TarArchive CreateInputTarArchive(Stream inputStream)
	{
		return CreateInputTarArchive(inputStream, null);
	}

	public static TarArchive CreateInputTarArchive(Stream inputStream, Encoding nameEncoding)
	{
		if (inputStream == null)
		{
			throw new ArgumentNullException("inputStream");
		}
		if (inputStream is TarInputStream stream)
		{
			return new TarArchive(stream);
		}
		return CreateInputTarArchive(inputStream, 20, nameEncoding);
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
	{
		return CreateInputTarArchive(inputStream, blockFactor, null);
	}

	public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor, Encoding nameEncoding)
	{
		if (inputStream == null)
		{
			throw new ArgumentNullException("inputStream");
		}
		if (inputStream is TarInputStream)
		{
			throw new ArgumentException("TarInputStream not valid");
		}
		return new TarArchive(new TarInputStream(inputStream, blockFactor, nameEncoding));
	}

	public static TarArchive CreateOutputTarArchive(Stream outputStream, Encoding nameEncoding)
	{
		if (outputStream == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		if (!(outputStream is TarOutputStream stream))
		{
			return CreateOutputTarArchive(outputStream, 20, nameEncoding);
		}
		return new TarArchive(stream);
	}

	public static TarArchive CreateOutputTarArchive(Stream outputStream)
	{
		return CreateOutputTarArchive(outputStream, null);
	}

	public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
	{
		return CreateOutputTarArchive(outputStream, blockFactor, null);
	}

	public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor, Encoding nameEncoding)
	{
		if (outputStream == null)
		{
			throw new ArgumentNullException("outputStream");
		}
		if (outputStream is TarOutputStream)
		{
			throw new ArgumentException("TarOutputStream is not valid");
		}
		return new TarArchive(new TarOutputStream(outputStream, blockFactor, nameEncoding));
	}

	public void SetKeepOldFiles(bool keepExistingFiles)
	{
		if (bool_3)
		{
			throw new ObjectDisposedException("TarArchive");
		}
		bool_0 = keepExistingFiles;
	}

	[Obsolete("Use the AsciiTranslate property")]
	public void SetAsciiTranslation(bool translateAsciiFiles)
	{
		if (bool_3)
		{
			throw new ObjectDisposedException("TarArchive");
		}
		bool_1 = translateAsciiFiles;
	}

	public void SetUserInfo(int userId, string userName, int groupId, string groupName)
	{
		if (bool_3)
		{
			throw new ObjectDisposedException("TarArchive");
		}
		int_0 = userId;
		string_0 = userName;
		int_1 = groupId;
		string_1 = groupName;
		bool_2 = true;
	}

	[Obsolete("Use Close instead")]
	public void CloseArchive()
	{
		Close();
	}

	public void ListContents()
	{
		if (bool_3)
		{
			throw new ObjectDisposedException("TarArchive");
		}
		while (true)
		{
			TarEntry nextEntry = tarInputStream_0.GetNextEntry();
			if (nextEntry != null)
			{
				OnProgressMessageEvent(nextEntry, null);
				continue;
			}
			break;
		}
	}

	public void ExtractContents(string destinationDirectory)
	{
		ExtractContents(destinationDirectory, allowParentTraversal: false);
	}

	public void ExtractContents(string destinationDirectory, bool allowParentTraversal)
	{
		if (bool_3)
		{
			throw new ObjectDisposedException("TarArchive");
		}
		string string_ = Path.GetFullPath(destinationDirectory).TrimEnd('/', '\\');
		while (true)
		{
			TarEntry nextEntry = tarInputStream_0.GetNextEntry();
			if (nextEntry != null)
			{
				if (nextEntry.TarHeader.TypeFlag != 49 && nextEntry.TarHeader.TypeFlag != 50)
				{
					method_0(string_, nextEntry, allowParentTraversal);
				}
				continue;
			}
			break;
		}
	}

	private void method_0(string string_4, TarEntry tarEntry_0, bool bool_4)
	{
		OnProgressMessageEvent(tarEntry_0, null);
		string text = tarEntry_0.Name;
		if (Path.IsPathRooted(text))
		{
			text = text.Substring(Path.GetPathRoot(text).Length);
		}
		text = text.Replace('/', Path.DirectorySeparatorChar);
		string text2 = Path.Combine(string_4, text);
		string text3 = Path.GetDirectoryName(Path.GetFullPath(text2)) ?? "";
		bool flag = tarEntry_0.IsDirectory && tarEntry_0.Name == "";
		if (!bool_4 && !flag && !text3.StartsWith(string_4, StringComparison.InvariantCultureIgnoreCase))
		{
			throw new InvalidNameException("Parent traversal in paths is not allowed");
		}
		if (tarEntry_0.IsDirectory)
		{
			smethod_0(text2);
			return;
		}
		smethod_0(Path.GetDirectoryName(text2));
		bool flag2 = true;
		FileInfo fileInfo = new FileInfo(text2);
		if (fileInfo.Exists)
		{
			if (bool_0)
			{
				OnProgressMessageEvent(tarEntry_0, "Destination file already exists");
				flag2 = false;
			}
			else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != FileAttributes.None)
			{
				OnProgressMessageEvent(tarEntry_0, "Destination file already exists, and is read-only");
				flag2 = false;
			}
		}
		if (!flag2)
		{
			return;
		}
		using FileStream fileStream = File.Create(text2);
		if (bool_1)
		{
			method_1(text2, fileStream);
		}
		else
		{
			tarInputStream_0.CopyEntryContents(fileStream);
		}
	}

	private void method_1(string string_4, Stream stream_0)
	{
		if (!smethod_1(string_4))
		{
			using (StreamWriter streamWriter = new StreamWriter(stream_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), 1024, leaveOpen: true))
			{
				byte[] array = new byte[32768];
				while (true)
				{
					int num = tarInputStream_0.Read(array, 0, array.Length);
					if (num <= 0)
					{
						break;
					}
					int num2 = 0;
					for (int i = 0; i < num; i++)
					{
						if (array[i] == 10)
						{
							string value = Encoding.ASCII.GetString(array, num2, i - num2);
							streamWriter.WriteLine(value);
							num2 = i + 1;
						}
					}
				}
				return;
			}
		}
		tarInputStream_0.CopyEntryContents(stream_0);
	}

	public void WriteEntry(TarEntry sourceEntry, bool recurse)
	{
		if (sourceEntry != null)
		{
			if (bool_3)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			try
			{
				if (recurse)
				{
					TarHeader.SetValueDefaults(sourceEntry.UserId, sourceEntry.UserName, sourceEntry.GroupId, sourceEntry.GroupName);
				}
				method_2(sourceEntry, recurse);
				return;
			}
			finally
			{
				if (recurse)
				{
					TarHeader.RestoreSetValues();
				}
			}
		}
		throw new ArgumentNullException("sourceEntry");
	}

	private void method_2(TarEntry tarEntry_0, bool bool_4)
	{
		string text = null;
		string text2 = tarEntry_0.File;
		TarEntry tarEntry = (TarEntry)tarEntry_0.Clone();
		if (bool_2)
		{
			tarEntry.GroupId = int_1;
			tarEntry.GroupName = string_1;
			tarEntry.UserId = int_0;
			tarEntry.UserName = string_0;
		}
		OnProgressMessageEvent(tarEntry, null);
		if (bool_1 && !tarEntry.IsDirectory && !smethod_1(text2))
		{
			text = PathUtils.GetTempFileName();
			using (StreamReader streamReader = File.OpenText(text2))
			{
				using Stream stream = File.Create(text);
				while (true)
				{
					string text3 = streamReader.ReadLine();
					if (text3 == null)
					{
						break;
					}
					byte[] bytes = Encoding.ASCII.GetBytes(text3);
					stream.Write(bytes, 0, bytes.Length);
					stream.WriteByte(10);
				}
				stream.Flush();
			}
			tarEntry.Size = new FileInfo(text).Length;
			text2 = text;
		}
		string text4 = null;
		if (!string.IsNullOrEmpty(string_2) && tarEntry.Name.StartsWith(string_2, StringComparison.OrdinalIgnoreCase))
		{
			text4 = tarEntry.Name.Substring(string_2.Length + 1);
		}
		if (string_3 != null)
		{
			text4 = ((text4 == null) ? (string_3 + "/" + tarEntry.Name) : (string_3 + "/" + text4));
		}
		if (text4 != null)
		{
			tarEntry.Name = text4;
		}
		tarOutputStream_0.PutNextEntry(tarEntry);
		if (tarEntry.IsDirectory)
		{
			if (bool_4)
			{
				TarEntry[] directoryEntries = tarEntry.GetDirectoryEntries();
				for (int i = 0; i < directoryEntries.Length; i++)
				{
					method_2(directoryEntries[i], bool_4);
				}
			}
			return;
		}
		using (Stream stream2 = File.OpenRead(text2))
		{
			byte[] array = new byte[32768];
			while (true)
			{
				int num = stream2.Read(array, 0, array.Length);
				if (num > 0)
				{
					tarOutputStream_0.Write(array, 0, num);
					continue;
				}
				break;
			}
		}
		if (!string.IsNullOrEmpty(text))
		{
			File.Delete(text);
		}
		tarOutputStream_0.CloseEntry();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (bool_3)
		{
			return;
		}
		bool_3 = true;
		if (disposing)
		{
			if (tarOutputStream_0 != null)
			{
				tarOutputStream_0.Flush();
				tarOutputStream_0.Dispose();
			}
			if (tarInputStream_0 != null)
			{
				tarInputStream_0.Dispose();
			}
		}
	}

	public virtual void Close()
	{
		Dispose(disposing: true);
	}

	~TarArchive()
	{
		Dispose(disposing: false);
	}

	private static void smethod_0(string string_4)
	{
		if (!Directory.Exists(string_4))
		{
			try
			{
				Directory.CreateDirectory(string_4);
			}
			catch (Exception ex)
			{
				throw new TarException("Exception creating directory '" + string_4 + "', " + ex.Message, ex);
			}
		}
	}

	private static bool smethod_1(string string_4)
	{
		using (FileStream fileStream = File.OpenRead(string_4))
		{
			int num = Math.Min(4096, (int)fileStream.Length);
			byte[] array = new byte[num];
			int num2 = fileStream.Read(array, 0, num);
			int num3 = 0;
			while (num3 < num2)
			{
				byte b = array[num3];
				int result;
				if (b >= 8 && (b <= 13 || b >= 32))
				{
					if (b != byte.MaxValue)
					{
						num3++;
						continue;
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
		}
		return false;
	}

	static TarArchive()
	{
		Class72.smethod_20();
	}
}
