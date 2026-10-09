using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Tar;

public class TarEntry
{
	private string string_0;

	private TarHeader tarHeader_0;

	public TarHeader TarHeader => tarHeader_0;

	public string Name
	{
		get
		{
			return tarHeader_0.Name;
		}
		set
		{
			tarHeader_0.Name = value;
		}
	}

	public int UserId
	{
		get
		{
			return tarHeader_0.UserId;
		}
		set
		{
			tarHeader_0.UserId = value;
		}
	}

	public int GroupId
	{
		get
		{
			return tarHeader_0.GroupId;
		}
		set
		{
			tarHeader_0.GroupId = value;
		}
	}

	public string UserName
	{
		get
		{
			return tarHeader_0.UserName;
		}
		set
		{
			tarHeader_0.UserName = value;
		}
	}

	public string GroupName
	{
		get
		{
			return tarHeader_0.GroupName;
		}
		set
		{
			tarHeader_0.GroupName = value;
		}
	}

	public DateTime ModTime
	{
		get
		{
			return tarHeader_0.ModTime;
		}
		set
		{
			tarHeader_0.ModTime = value;
		}
	}

	public string File => string_0;

	public long Size
	{
		get
		{
			return tarHeader_0.Size;
		}
		set
		{
			tarHeader_0.Size = value;
		}
	}

	public bool IsDirectory
	{
		get
		{
			if (string_0 == null)
			{
				int result;
				if (tarHeader_0 == null)
				{
					result = 0;
				}
				else
				{
					if (tarHeader_0.TypeFlag == 53 || Name.EndsWith("/", StringComparison.Ordinal))
					{
						return true;
					}
					result = 0;
				}
				return (byte)result != 0;
			}
			return Directory.Exists(string_0);
		}
	}

	private TarEntry()
	{
		tarHeader_0 = new TarHeader();
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public TarEntry(byte[] headerBuffer)
		: this(headerBuffer, null)
	{
	}

	public TarEntry(byte[] headerBuffer, Encoding nameEncoding)
	{
		tarHeader_0 = new TarHeader();
		tarHeader_0.ParseBuffer(headerBuffer, nameEncoding);
	}

	public TarEntry(TarHeader header)
	{
		if (header == null)
		{
			throw new ArgumentNullException("header");
		}
		tarHeader_0 = (TarHeader)header.Clone();
	}

	public object Clone()
	{
		return new TarEntry
		{
			string_0 = string_0,
			tarHeader_0 = (TarHeader)tarHeader_0.Clone(),
			Name = Name
		};
	}

	public static TarEntry CreateTarEntry(string name)
	{
		TarEntry tarEntry = new TarEntry();
		tarEntry.NameTarHeader(name);
		return tarEntry;
	}

	public static TarEntry CreateEntryFromFile(string fileName)
	{
		TarEntry tarEntry = new TarEntry();
		tarEntry.GetFileTarHeader(tarEntry.tarHeader_0, fileName);
		return tarEntry;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TarEntry tarEntry))
		{
			return false;
		}
		return Name.Equals(tarEntry.Name);
	}

	public override int GetHashCode()
	{
		return Name.GetHashCode();
	}

	public bool IsDescendent(TarEntry toTest)
	{
		if (toTest == null)
		{
			throw new ArgumentNullException("toTest");
		}
		return toTest.Name.StartsWith(Name, StringComparison.Ordinal);
	}

	public void SetIds(int userId, int groupId)
	{
		UserId = userId;
		GroupId = groupId;
	}

	public void SetNames(string userName, string groupName)
	{
		UserName = userName;
		GroupName = groupName;
	}

	public void GetFileTarHeader(TarHeader header, string file)
	{
		if (header == null)
		{
			throw new ArgumentNullException("header");
		}
		if (file == null)
		{
			throw new ArgumentNullException("file");
		}
		string_0 = file;
		string text = file;
		if (text.IndexOf(Directory.GetCurrentDirectory(), StringComparison.Ordinal) == 0)
		{
			text = text.Substring(Directory.GetCurrentDirectory().Length);
		}
		text = TarStringExtension.ToTarArchivePath(text);
		header.LinkName = string.Empty;
		header.Name = text;
		if (!Directory.Exists(file))
		{
			header.Mode = 33216;
			header.TypeFlag = 48;
			header.Size = new FileInfo(file.Replace('/', Path.DirectorySeparatorChar)).Length;
		}
		else
		{
			header.Mode = 1003;
			header.TypeFlag = 53;
			if (header.Name.Length == 0 || header.Name[header.Name.Length - 1] != '/')
			{
				header.Name += "/";
			}
			header.Size = 0L;
		}
		header.ModTime = System.IO.File.GetLastWriteTime(file.Replace('/', Path.DirectorySeparatorChar)).ToUniversalTime();
		header.DevMajor = 0;
		header.DevMinor = 0;
	}

	public TarEntry[] GetDirectoryEntries()
	{
		if (string_0 != null && Directory.Exists(string_0))
		{
			string[] fileSystemEntries = Directory.GetFileSystemEntries(string_0);
			TarEntry[] array = new TarEntry[fileSystemEntries.Length];
			for (int i = 0; i < fileSystemEntries.Length; i++)
			{
				array[i] = CreateEntryFromFile(fileSystemEntries[i]);
			}
			return array;
		}
		return Empty.Array<TarEntry>();
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public void WriteEntryHeader(byte[] outBuffer)
	{
		WriteEntryHeader(outBuffer, null);
	}

	public void WriteEntryHeader(byte[] outBuffer, Encoding nameEncoding)
	{
		tarHeader_0.WriteHeader(outBuffer, nameEncoding);
	}

	[Obsolete("No Encoding for Name field is specified, any non-ASCII bytes will be discarded")]
	public static void AdjustEntryName(byte[] buffer, string newName)
	{
		AdjustEntryName(buffer, newName, null);
	}

	public static void AdjustEntryName(byte[] buffer, string newName, Encoding nameEncoding)
	{
		TarHeader.GetNameBytes(newName, buffer, 0, 100, nameEncoding);
	}

	public void NameTarHeader(string name)
	{
		if (name != null)
		{
			bool flag = name.EndsWith("/", StringComparison.Ordinal);
			tarHeader_0.Name = name;
			tarHeader_0.Mode = ((!flag) ? 33216 : 1003);
			tarHeader_0.UserId = 0;
			tarHeader_0.GroupId = 0;
			tarHeader_0.Size = 0L;
			tarHeader_0.ModTime = DateTime.UtcNow;
			tarHeader_0.TypeFlag = (byte)((!flag) ? 48 : 53);
			tarHeader_0.LinkName = string.Empty;
			tarHeader_0.UserName = string.Empty;
			tarHeader_0.GroupName = string.Empty;
			tarHeader_0.DevMajor = 0;
			tarHeader_0.DevMinor = 0;
			return;
		}
		throw new ArgumentNullException("name");
	}

	static TarEntry()
	{
		Class72.smethod_20();
	}
}
