using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace ICSharpCode.SharpZipLib.Zip;

public class FastZip
{
	public enum Overwrite
	{
		Prompt,
		Never,
		Always
	}

	public delegate bool ConfirmOverwriteDelegate(string fileName);

	[CompilerGenerated]
	private ZipEncryptionMethod zipEncryptionMethod_0 = ZipEncryptionMethod.ZipCrypto;

	private bool bool_0;

	private byte[] byte_0;

	private ZipOutputStream zipOutputStream_0;

	private ZipFile zipFile_0;

	private string string_0;

	private NameFilter nameFilter_0;

	private NameFilter nameFilter_1;

	private Overwrite overwrite_0;

	private ConfirmOverwriteDelegate confirmOverwriteDelegate_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private FastZipEvents fastZipEvents_0;

	private IEntryFactory ientryFactory_0 = new ZipEntryFactory();

	private INameTransform inameTransform_0;

	private UseZip64 useZip64_0 = UseZip64.Dynamic;

	private Deflater.CompressionLevel compressionLevel_0 = Deflater.CompressionLevel.DEFAULT_COMPRESSION;

	private StringCodec stringCodec_0 = ZipStrings.GetStringCodec();

	private string string_1;

	public bool CreateEmptyDirectories
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public string Password
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public ZipEncryptionMethod EntryEncryptionMethod
	{
		[CompilerGenerated]
		get
		{
			return zipEncryptionMethod_0;
		}
		[CompilerGenerated]
		set
		{
			zipEncryptionMethod_0 = value;
		}
	}

	public INameTransform NameTransform
	{
		get
		{
			return ientryFactory_0.NameTransform;
		}
		set
		{
			ientryFactory_0.NameTransform = value;
		}
	}

	public IEntryFactory EntryFactory
	{
		get
		{
			return ientryFactory_0;
		}
		set
		{
			if (value != null)
			{
				ientryFactory_0 = value;
			}
			else
			{
				ientryFactory_0 = new ZipEntryFactory();
			}
		}
	}

	public UseZip64 UseZip64
	{
		get
		{
			return useZip64_0;
		}
		set
		{
			useZip64_0 = value;
		}
	}

	public bool RestoreDateTimeOnExtract
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool RestoreAttributesOnExtract
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public Deflater.CompressionLevel CompressionLevel
	{
		get
		{
			return compressionLevel_0;
		}
		set
		{
			compressionLevel_0 = value;
		}
	}

	public bool UseUnicode
	{
		get
		{
			return !stringCodec_0.ForceZipLegacyEncoding;
		}
		set
		{
			stringCodec_0.ForceZipLegacyEncoding = !value;
		}
	}

	public int LegacyCodePage
	{
		get
		{
			return stringCodec_0.CodePage;
		}
		set
		{
			stringCodec_0 = StringCodec.FromCodePage(value);
		}
	}

	public StringCodec StringCodec
	{
		get
		{
			return stringCodec_0;
		}
		set
		{
			stringCodec_0 = value;
		}
	}

	public FastZip()
	{
	}

	public FastZip(ZipEntryFactory.TimeSetting timeSetting)
	{
		ientryFactory_0 = new ZipEntryFactory(timeSetting);
		bool_1 = true;
	}

	public FastZip(DateTime time)
	{
		ientryFactory_0 = new ZipEntryFactory(time);
		bool_1 = true;
	}

	public FastZip(FastZipEvents events)
	{
		fastZipEvents_0 = events;
	}

	public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
	{
		CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, directoryFilter);
	}

	public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, string fileFilter)
	{
		CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, null);
	}

	public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter)
	{
		CreateZip(outputStream, sourceDirectory, recurse, fileFilter, directoryFilter, leaveOpen: false);
	}

	public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, string fileFilter, string directoryFilter, bool leaveOpen)
	{
		FileSystemScanner fileSystemScanner_ = new FileSystemScanner(fileFilter, directoryFilter);
		method_0(outputStream, sourceDirectory, recurse, fileSystemScanner_, leaveOpen);
	}

	public void CreateZip(string zipFileName, string sourceDirectory, bool recurse, IScanFilter fileFilter, IScanFilter directoryFilter)
	{
		CreateZip(File.Create(zipFileName), sourceDirectory, recurse, fileFilter, directoryFilter);
	}

	public void CreateZip(Stream outputStream, string sourceDirectory, bool recurse, IScanFilter fileFilter, IScanFilter directoryFilter, bool leaveOpen = false)
	{
		FileSystemScanner fileSystemScanner_ = new FileSystemScanner(fileFilter, directoryFilter);
		method_0(outputStream, sourceDirectory, recurse, fileSystemScanner_, leaveOpen);
	}

	private void method_0(Stream stream_0, string string_2, bool bool_4, FileSystemScanner fileSystemScanner_0, bool bool_5)
	{
		NameTransform = new ZipNameTransform(string_2);
		string_0 = string_2;
		using (zipOutputStream_0 = new ZipOutputStream(stream_0, stringCodec_0))
		{
			zipOutputStream_0.SetLevel((int)CompressionLevel);
			zipOutputStream_0.IsStreamOwner = !bool_5;
			zipOutputStream_0.NameTransform = null;
			if (!string.IsNullOrEmpty(string_1) && EntryEncryptionMethod != ZipEncryptionMethod.None)
			{
				zipOutputStream_0.Password = string_1;
			}
			zipOutputStream_0.UseZip64 = UseZip64;
			fileSystemScanner_0.ProcessFile = (ProcessFileHandler)Delegate.Combine(fileSystemScanner_0.ProcessFile, new ProcessFileHandler(method_2));
			if (CreateEmptyDirectories)
			{
				fileSystemScanner_0.ProcessDirectory += method_1;
			}
			if (fastZipEvents_0 != null)
			{
				if (fastZipEvents_0.FileFailure != null)
				{
					fileSystemScanner_0.FileFailure = (FileFailureHandler)Delegate.Combine(fileSystemScanner_0.FileFailure, fastZipEvents_0.FileFailure);
				}
				if (fastZipEvents_0.DirectoryFailure != null)
				{
					fileSystemScanner_0.DirectoryFailure = (DirectoryFailureHandler)Delegate.Combine(fileSystemScanner_0.DirectoryFailure, fastZipEvents_0.DirectoryFailure);
				}
			}
			fileSystemScanner_0.Scan(string_2, bool_4);
		}
	}

	public void ExtractZip(string zipFileName, string targetDirectory, string fileFilter)
	{
		ExtractZip(zipFileName, targetDirectory, Overwrite.Always, null, fileFilter, null, bool_1);
	}

	public void ExtractZip(string zipFileName, string targetDirectory, Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate, string fileFilter, string directoryFilter, bool restoreDateTime, bool allowParentTraversal = false)
	{
		Stream inputStream = File.Open(zipFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
		ExtractZip(inputStream, targetDirectory, overwrite, confirmDelegate, fileFilter, directoryFilter, restoreDateTime, isStreamOwner: true, allowParentTraversal);
	}

	public void ExtractZip(Stream inputStream, string targetDirectory, Overwrite overwrite, ConfirmOverwriteDelegate confirmDelegate, string fileFilter, string directoryFilter, bool restoreDateTime, bool isStreamOwner, bool allowParentTraversal = false)
	{
		if (overwrite == Overwrite.Prompt && confirmDelegate == null)
		{
			throw new ArgumentNullException("confirmDelegate");
		}
		bool_0 = true;
		overwrite_0 = overwrite;
		confirmOverwriteDelegate_0 = confirmDelegate;
		inameTransform_0 = new WindowsNameTransform(targetDirectory, allowParentTraversal);
		nameFilter_0 = new NameFilter(fileFilter);
		nameFilter_1 = new NameFilter(directoryFilter);
		bool_1 = restoreDateTime;
		using (zipFile_0 = new ZipFile(inputStream, !isStreamOwner, stringCodec_0))
		{
			if (string_1 != null)
			{
				zipFile_0.Password = string_1;
			}
			IEnumerator enumerator = zipFile_0.GetEnumerator();
			while (bool_0 && enumerator.MoveNext())
			{
				ZipEntry zipEntry = (ZipEntry)enumerator.Current;
				if (!zipEntry.IsFile)
				{
					if (zipEntry.IsDirectory && nameFilter_1.IsMatch(zipEntry.Name) && CreateEmptyDirectories)
					{
						method_6(zipEntry);
					}
				}
				else if (nameFilter_1.IsMatch(Path.GetDirectoryName(zipEntry.Name)) && nameFilter_0.IsMatch(zipEntry.Name))
				{
					method_6(zipEntry);
				}
			}
		}
	}

	private void method_1(object sender, DirectoryEventArgs e)
	{
		if (!e.HasMatchingFiles && CreateEmptyDirectories)
		{
			if (fastZipEvents_0 != null)
			{
				fastZipEvents_0.OnProcessDirectory(e.Name, e.HasMatchingFiles);
			}
			if (e.ContinueRunning && e.Name != string_0)
			{
				ZipEntry entry = ientryFactory_0.MakeDirectoryEntry(e.Name);
				zipOutputStream_0.PutNextEntry(entry);
			}
		}
	}

	private void method_2(object sender, ScanEventArgs e)
	{
		if (fastZipEvents_0 != null && fastZipEvents_0.ProcessFile != null)
		{
			fastZipEvents_0.ProcessFile(sender, e);
		}
		if (!e.ContinueRunning)
		{
			return;
		}
		try
		{
			using FileStream stream_ = File.Open(e.Name, FileMode.Open, FileAccess.Read, FileShare.Read);
			ZipEntry zipEntry = ientryFactory_0.MakeFileEntry(e.Name);
			if (stringCodec_0.ForceZipLegacyEncoding)
			{
				zipEntry.IsUnicodeText = false;
			}
			method_3(zipEntry);
			zipOutputStream_0.PutNextEntry(zipEntry);
			method_4(e.Name, stream_);
		}
		catch (Exception e2)
		{
			if (fastZipEvents_0 == null)
			{
				bool_0 = false;
				throw;
			}
			bool_0 = fastZipEvents_0.OnFileFailure(e.Name, e2);
		}
	}

	private void method_3(ZipEntry zipEntry_0)
	{
		if (!string.IsNullOrEmpty(Password) && zipEntry_0.AESEncryptionStrength == 0)
		{
			switch (EntryEncryptionMethod)
			{
			case ZipEncryptionMethod.AES256:
				zipEntry_0.AESKeySize = 256;
				break;
			case ZipEncryptionMethod.AES128:
				zipEntry_0.AESKeySize = 128;
				break;
			}
		}
	}

	private void method_4(string string_2, Stream stream_0)
	{
		if (stream_0 != null)
		{
			if (byte_0 == null)
			{
				byte_0 = new byte[4096];
			}
			if (fastZipEvents_0 != null && fastZipEvents_0.Progress != null)
			{
				StreamUtils.Copy(stream_0, zipOutputStream_0, byte_0, fastZipEvents_0.Progress, fastZipEvents_0.ProgressInterval, this, string_2);
			}
			else
			{
				StreamUtils.Copy(stream_0, zipOutputStream_0, byte_0);
			}
			if (fastZipEvents_0 != null)
			{
				bool_0 = fastZipEvents_0.OnCompletedFile(string_2);
			}
			return;
		}
		throw new ArgumentNullException("stream");
	}

	private void method_5(ZipEntry zipEntry_0, string string_2)
	{
		bool flag = true;
		if (overwrite_0 != Overwrite.Always && File.Exists(string_2))
		{
			int num;
			if (overwrite_0 != Overwrite.Prompt)
			{
				num = 0;
			}
			else
			{
				if (confirmOverwriteDelegate_0 != null)
				{
					flag = confirmOverwriteDelegate_0(string_2);
					goto IL_0037;
				}
				num = 0;
			}
			flag = (byte)num != 0;
		}
		goto IL_0037;
		IL_0037:
		if (!flag)
		{
			return;
		}
		if (fastZipEvents_0 != null)
		{
			bool_0 = fastZipEvents_0.OnProcessFile(zipEntry_0.Name);
		}
		if (!bool_0)
		{
			return;
		}
		try
		{
			using (FileStream destination = File.Create(string_2))
			{
				if (byte_0 == null)
				{
					byte_0 = new byte[4096];
				}
				using (Stream source = zipFile_0.GetInputStream(zipEntry_0))
				{
					if (fastZipEvents_0 != null && fastZipEvents_0.Progress != null)
					{
						StreamUtils.Copy(source, destination, byte_0, fastZipEvents_0.Progress, fastZipEvents_0.ProgressInterval, this, zipEntry_0.Name, zipEntry_0.Size);
					}
					else
					{
						StreamUtils.Copy(source, destination, byte_0);
					}
				}
				if (fastZipEvents_0 != null)
				{
					bool_0 = fastZipEvents_0.OnCompletedFile(zipEntry_0.Name);
				}
			}
			if (bool_1)
			{
				switch (ientryFactory_0.Setting)
				{
				default:
					throw new ZipException("Unhandled time setting in ExtractFileEntry");
				case ZipEntryFactory.TimeSetting.LastWriteTime:
					File.SetLastWriteTime(string_2, zipEntry_0.DateTime);
					break;
				case ZipEntryFactory.TimeSetting.LastWriteTimeUtc:
					File.SetLastWriteTimeUtc(string_2, zipEntry_0.DateTime);
					break;
				case ZipEntryFactory.TimeSetting.CreateTime:
					File.SetCreationTime(string_2, zipEntry_0.DateTime);
					break;
				case ZipEntryFactory.TimeSetting.CreateTimeUtc:
					File.SetCreationTimeUtc(string_2, zipEntry_0.DateTime);
					break;
				case ZipEntryFactory.TimeSetting.LastAccessTime:
					File.SetLastAccessTime(string_2, zipEntry_0.DateTime);
					break;
				case ZipEntryFactory.TimeSetting.LastAccessTimeUtc:
					File.SetLastAccessTimeUtc(string_2, zipEntry_0.DateTime);
					break;
				case ZipEntryFactory.TimeSetting.Fixed:
					File.SetLastWriteTime(string_2, ientryFactory_0.FixedDateTime);
					break;
				}
			}
			if (RestoreAttributesOnExtract && zipEntry_0.IsDOSEntry && zipEntry_0.ExternalFileAttributes != -1)
			{
				FileAttributes externalFileAttributes = (FileAttributes)zipEntry_0.ExternalFileAttributes;
				externalFileAttributes &= FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.Archive | FileAttributes.Normal;
				File.SetAttributes(string_2, externalFileAttributes);
			}
		}
		catch (Exception e)
		{
			if (fastZipEvents_0 == null)
			{
				bool_0 = false;
				throw;
			}
			bool_0 = fastZipEvents_0.OnFileFailure(string_2, e);
		}
	}

	private void method_6(ZipEntry zipEntry_0)
	{
		bool flag = zipEntry_0.IsCompressionMethodSupported();
		string text = zipEntry_0.Name;
		if (flag)
		{
			if (zipEntry_0.IsFile)
			{
				text = inameTransform_0.TransformFile(text);
			}
			else if (zipEntry_0.IsDirectory)
			{
				text = inameTransform_0.TransformDirectory(text);
			}
			flag = !string.IsNullOrEmpty(text);
		}
		string text2 = string.Empty;
		if (flag)
		{
			text2 = ((!zipEntry_0.IsDirectory) ? Path.GetDirectoryName(Path.GetFullPath(text)) : text);
		}
		if (flag && !Directory.Exists(text2) && (!zipEntry_0.IsDirectory || CreateEmptyDirectories))
		{
			try
			{
				bool_0 = fastZipEvents_0?.OnProcessDirectory(text2, hasMatchingFiles: true) ?? true;
				if (bool_0)
				{
					Directory.CreateDirectory(text2);
					if (zipEntry_0.IsDirectory && bool_1)
					{
						switch (ientryFactory_0.Setting)
						{
						default:
							throw new ZipException("Unhandled time setting in ExtractEntry");
						case ZipEntryFactory.TimeSetting.LastWriteTime:
							Directory.SetLastWriteTime(text2, zipEntry_0.DateTime);
							break;
						case ZipEntryFactory.TimeSetting.LastWriteTimeUtc:
							Directory.SetLastWriteTimeUtc(text2, zipEntry_0.DateTime);
							break;
						case ZipEntryFactory.TimeSetting.CreateTime:
							Directory.SetCreationTime(text2, zipEntry_0.DateTime);
							break;
						case ZipEntryFactory.TimeSetting.CreateTimeUtc:
							Directory.SetCreationTimeUtc(text2, zipEntry_0.DateTime);
							break;
						case ZipEntryFactory.TimeSetting.LastAccessTime:
							Directory.SetLastAccessTime(text2, zipEntry_0.DateTime);
							break;
						case ZipEntryFactory.TimeSetting.LastAccessTimeUtc:
							Directory.SetLastAccessTimeUtc(text2, zipEntry_0.DateTime);
							break;
						case ZipEntryFactory.TimeSetting.Fixed:
							Directory.SetLastWriteTime(text2, ientryFactory_0.FixedDateTime);
							break;
						}
					}
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception e)
			{
				flag = false;
				if (fastZipEvents_0 == null)
				{
					bool_0 = false;
					throw;
				}
				if (!zipEntry_0.IsDirectory)
				{
					bool_0 = fastZipEvents_0.OnFileFailure(text, e);
				}
				else
				{
					bool_0 = fastZipEvents_0.OnDirectoryFailure(text, e);
				}
			}
		}
		if (flag && zipEntry_0.IsFile)
		{
			method_5(zipEntry_0, text);
		}
	}

	private static int smethod_0(FileSystemInfo fileSystemInfo_0)
	{
		return (int)fileSystemInfo_0.Attributes;
	}

	private static bool smethod_1(string string_2)
	{
		if (string.IsNullOrEmpty(string_2))
		{
			return false;
		}
		return string_2.IndexOfAny(Path.GetInvalidPathChars()) < 0;
	}

	static FastZip()
	{
		Class72.smethod_20();
	}
}
