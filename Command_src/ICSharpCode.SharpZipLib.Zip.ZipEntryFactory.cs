using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZipEntryFactory : IEntryFactory
{
	public enum TimeSetting
	{
		LastWriteTime,
		LastWriteTimeUtc,
		CreateTime,
		CreateTimeUtc,
		LastAccessTime,
		LastAccessTimeUtc,
		Fixed
	}

	private INameTransform inameTransform_0;

	private DateTime dateTime_0 = DateTime.Now;

	private TimeSetting timeSetting_0;

	private bool bool_0;

	private int int_0 = -1;

	private int int_1;

	public INameTransform NameTransform
	{
		get
		{
			return inameTransform_0;
		}
		set
		{
			if (value != null)
			{
				inameTransform_0 = value;
			}
			else
			{
				inameTransform_0 = new ZipNameTransform();
			}
		}
	}

	public TimeSetting Setting
	{
		get
		{
			return timeSetting_0;
		}
		set
		{
			timeSetting_0 = value;
		}
	}

	public DateTime FixedDateTime
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			if (value.Year < 1970)
			{
				throw new ArgumentException("Value is too old to be valid", "value");
			}
			dateTime_0 = value;
		}
	}

	public int GetAttributes
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int SetAttributes
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool IsUnicodeText
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ZipEntryFactory()
	{
		inameTransform_0 = new ZipNameTransform();
		bool_0 = true;
	}

	public ZipEntryFactory(TimeSetting timeSetting)
		: this()
	{
		timeSetting_0 = timeSetting;
	}

	public ZipEntryFactory(DateTime time)
		: this()
	{
		timeSetting_0 = TimeSetting.Fixed;
		FixedDateTime = time;
	}

	public ZipEntry MakeFileEntry(string fileName)
	{
		return MakeFileEntry(fileName, null, useFileSystem: true);
	}

	public ZipEntry MakeFileEntry(string fileName, bool useFileSystem)
	{
		return MakeFileEntry(fileName, null, useFileSystem);
	}

	public ZipEntry MakeFileEntry(string fileName, string entryName, bool useFileSystem)
	{
		ZipEntry zipEntry = new ZipEntry(inameTransform_0.TransformFile(string.IsNullOrEmpty(entryName) ? fileName : entryName));
		zipEntry.IsUnicodeText = bool_0;
		int num = 0;
		bool flag = int_1 != 0;
		FileInfo fileInfo = null;
		if (useFileSystem)
		{
			fileInfo = new FileInfo(fileName);
		}
		if (fileInfo != null && fileInfo.Exists)
		{
			switch (timeSetting_0)
			{
			default:
				throw new ZipException("Unhandled time setting in MakeFileEntry");
			case TimeSetting.LastWriteTime:
				zipEntry.DateTime = fileInfo.LastWriteTime;
				break;
			case TimeSetting.LastWriteTimeUtc:
				zipEntry.DateTime = fileInfo.LastWriteTimeUtc;
				break;
			case TimeSetting.CreateTime:
				zipEntry.DateTime = fileInfo.CreationTime;
				break;
			case TimeSetting.CreateTimeUtc:
				zipEntry.DateTime = fileInfo.CreationTimeUtc;
				break;
			case TimeSetting.LastAccessTime:
				zipEntry.DateTime = fileInfo.LastAccessTime;
				break;
			case TimeSetting.LastAccessTimeUtc:
				zipEntry.DateTime = fileInfo.LastAccessTimeUtc;
				break;
			case TimeSetting.Fixed:
				zipEntry.DateTime = dateTime_0;
				break;
			}
			zipEntry.Size = fileInfo.Length;
			flag = true;
			num = (int)fileInfo.Attributes & int_0;
		}
		else if (timeSetting_0 == TimeSetting.Fixed)
		{
			zipEntry.DateTime = dateTime_0;
		}
		if (flag)
		{
			num |= int_1;
			zipEntry.ExternalFileAttributes = num;
		}
		return zipEntry;
	}

	public ZipEntry MakeDirectoryEntry(string directoryName)
	{
		return MakeDirectoryEntry(directoryName, useFileSystem: true);
	}

	public ZipEntry MakeDirectoryEntry(string directoryName, bool useFileSystem)
	{
		ZipEntry zipEntry = new ZipEntry(inameTransform_0.TransformDirectory(directoryName));
		zipEntry.IsUnicodeText = bool_0;
		zipEntry.Size = 0L;
		int num = 0;
		DirectoryInfo directoryInfo = null;
		if (useFileSystem)
		{
			directoryInfo = new DirectoryInfo(directoryName);
		}
		if (directoryInfo != null && directoryInfo.Exists)
		{
			switch (timeSetting_0)
			{
			default:
				throw new ZipException("Unhandled time setting in MakeDirectoryEntry");
			case TimeSetting.LastWriteTime:
				zipEntry.DateTime = directoryInfo.LastWriteTime;
				break;
			case TimeSetting.LastWriteTimeUtc:
				zipEntry.DateTime = directoryInfo.LastWriteTimeUtc;
				break;
			case TimeSetting.CreateTime:
				zipEntry.DateTime = directoryInfo.CreationTime;
				break;
			case TimeSetting.CreateTimeUtc:
				zipEntry.DateTime = directoryInfo.CreationTimeUtc;
				break;
			case TimeSetting.LastAccessTime:
				zipEntry.DateTime = directoryInfo.LastAccessTime;
				break;
			case TimeSetting.LastAccessTimeUtc:
				zipEntry.DateTime = directoryInfo.LastAccessTimeUtc;
				break;
			case TimeSetting.Fixed:
				zipEntry.DateTime = dateTime_0;
				break;
			}
			num = (int)directoryInfo.Attributes & int_0;
		}
		else if (timeSetting_0 == TimeSetting.Fixed)
		{
			zipEntry.DateTime = dateTime_0;
		}
		num |= int_1 | 0x10;
		zipEntry.ExternalFileAttributes = num;
		return zipEntry;
	}

	static ZipEntryFactory()
	{
		Class72.smethod_20();
	}
}
