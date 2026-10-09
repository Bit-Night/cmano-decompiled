using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip;

internal static class ZipFormat
{
	internal static int WriteLocalHeader(Stream stream, ZipEntry entry, out ICSharpCode.SharpZipLib.Zip.EntryPatchData patchData, bool headerInfoAvailable, bool patchEntryHeader, long streamOffset, StringCodec stringCodec)
	{
		patchData = default(ICSharpCode.SharpZipLib.Zip.EntryPatchData);
		stream.smethod_10(67324752);
		ByteOrderStreamExtensions.WriteLEShort(stream, entry.Version);
		ByteOrderStreamExtensions.WriteLEShort(stream, entry.Flags);
		ByteOrderStreamExtensions.WriteLEShort(stream, (byte)entry.CompressionMethodForHeader);
		stream.smethod_10((int)entry.DosTime);
		if (headerInfoAvailable)
		{
			stream.smethod_10((int)entry.Crc);
			if (!entry.LocalHeaderRequiresZip64)
			{
				stream.smethod_10((int)entry.CompressedSize + entry.EncryptionOverheadSize);
				stream.smethod_10((int)entry.Size);
			}
			else
			{
				stream.smethod_10(-1);
				stream.smethod_10(-1);
			}
		}
		else
		{
			if (patchEntryHeader)
			{
				patchData.CrcPatchOffset = streamOffset + stream.Position;
			}
			stream.smethod_10(0);
			if (patchEntryHeader)
			{
				patchData.SizePatchOffset = streamOffset + stream.Position;
			}
			if (entry.LocalHeaderRequiresZip64 && patchEntryHeader)
			{
				stream.smethod_10(-1);
				stream.smethod_10(-1);
			}
			else
			{
				stream.smethod_10(0);
				stream.smethod_10(0);
			}
		}
		byte[] bytes = stringCodec.ZipEncoding(entry.IsUnicodeText).GetBytes(entry.Name);
		if (bytes.Length > 65535)
		{
			throw new ZipException("Entry name too long.");
		}
		ZipExtraData zipExtraData = new ZipExtraData(entry.ExtraData);
		if (!entry.LocalHeaderRequiresZip64)
		{
			zipExtraData.Delete(1);
		}
		else
		{
			zipExtraData.StartNewEntry();
			if (headerInfoAvailable)
			{
				zipExtraData.AddLeLong(entry.Size);
				zipExtraData.AddLeLong(entry.CompressedSize + entry.EncryptionOverheadSize);
			}
			else
			{
				zipExtraData.AddLeLong(0L);
				zipExtraData.AddLeLong(0L);
			}
			zipExtraData.AddNewEntry(1);
			if (!zipExtraData.Find(1))
			{
				throw new ZipException("Internal error cant find extra data");
			}
			patchData.SizePatchOffset = zipExtraData.CurrentReadIndex;
		}
		if (entry.AESKeySize > 0)
		{
			AddExtraDataAES(entry, zipExtraData);
		}
		byte[] entryData = zipExtraData.GetEntryData();
		ByteOrderStreamExtensions.WriteLEShort(stream, bytes.Length);
		ByteOrderStreamExtensions.WriteLEShort(stream, entryData.Length);
		if (bytes.Length != 0)
		{
			stream.Write(bytes, 0, bytes.Length);
		}
		if (entry.LocalHeaderRequiresZip64 && patchEntryHeader)
		{
			patchData.SizePatchOffset += streamOffset + stream.Position;
		}
		int num;
		if (entryData.Length == 0)
		{
			num = 30;
		}
		else
		{
			stream.Write(entryData, 0, entryData.Length);
			num = 30;
		}
		return num + bytes.Length + entryData.Length;
	}

	internal static long LocateBlockWithSignature(Stream stream, int signature, long endLocation, int minimumBlockSize, int maximumVariableData)
	{
		long num = endLocation - minimumBlockSize;
		if (num < 0L)
		{
			return -1L;
		}
		long num2 = Math.Max(num - maximumVariableData, 0L);
		while (num >= num2)
		{
			stream.Seek(num--, SeekOrigin.Begin);
			if (stream.smethod_7() == signature)
			{
				return stream.Position;
			}
		}
		return -1L;
	}

	public static async Task WriteZip64EndOfCentralDirectoryAsync(Stream stream, long noOfEntries, long sizeEntries, long centralDirOffset, CancellationToken cancellationToken)
	{
		await StreamUtils.WriteProcToStreamAsync(stream, delegate(Stream s)
		{
			WriteZip64EndOfCentralDirectory(s, noOfEntries, sizeEntries, centralDirOffset);
		}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	internal static void WriteZip64EndOfCentralDirectory(Stream stream, long noOfEntries, long sizeEntries, long centralDirOffset)
	{
		long value = centralDirOffset + sizeEntries;
		stream.smethod_10(101075792);
		stream.smethod_12(44L);
		ByteOrderStreamExtensions.WriteLEShort(stream, 51);
		ByteOrderStreamExtensions.WriteLEShort(stream, 45);
		stream.smethod_10(0);
		stream.smethod_10(0);
		stream.smethod_12(noOfEntries);
		stream.smethod_12(noOfEntries);
		stream.smethod_12(sizeEntries);
		stream.smethod_12(centralDirOffset);
		stream.smethod_10(117853008);
		stream.smethod_10(0);
		stream.smethod_12(value);
		stream.smethod_10(1);
	}

	public static async Task WriteEndOfCentralDirectoryAsync(Stream stream, long noOfEntries, long sizeEntries, long start, byte[] comment, CancellationToken cancellationToken)
	{
		await StreamUtils.WriteProcToStreamAsync(stream, delegate(Stream s)
		{
			WriteEndOfCentralDirectory(s, noOfEntries, sizeEntries, start, comment);
		}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	internal static void WriteEndOfCentralDirectory(Stream stream, long noOfEntries, long sizeEntries, long start, byte[] comment)
	{
		if (noOfEntries >= 65535L || start >= 4294967295L || sizeEntries >= 4294967295L)
		{
			WriteZip64EndOfCentralDirectory(stream, noOfEntries, sizeEntries, start);
		}
		stream.smethod_10(101010256);
		ByteOrderStreamExtensions.WriteLEShort(stream, 0);
		ByteOrderStreamExtensions.WriteLEShort(stream, 0);
		if (noOfEntries < 65535L)
		{
			ByteOrderStreamExtensions.WriteLEShort(stream, (short)noOfEntries);
			ByteOrderStreamExtensions.WriteLEShort(stream, (short)noOfEntries);
		}
		else
		{
			ByteOrderStreamExtensions.WriteLEUshort(stream, ushort.MaxValue);
			ByteOrderStreamExtensions.WriteLEUshort(stream, ushort.MaxValue);
		}
		if (sizeEntries >= 4294967295L)
		{
			stream.smethod_11(uint.MaxValue);
		}
		else
		{
			stream.smethod_10((int)sizeEntries);
		}
		if (start < 4294967295L)
		{
			stream.smethod_10((int)start);
		}
		else
		{
			stream.smethod_11(uint.MaxValue);
		}
		int num = ((comment != null) ? comment.Length : 0);
		if (num > 65535)
		{
			throw new ZipException($"Comment length ({num}) is larger than 64K");
		}
		ByteOrderStreamExtensions.WriteLEShort(stream, num);
		if (num > 0)
		{
			stream.Write(comment, 0, num);
		}
	}

	internal static int WriteDataDescriptor(Stream stream, ZipEntry entry)
	{
		if (entry == null)
		{
			throw new ArgumentNullException("entry");
		}
		int num = 0;
		if ((entry.Flags & 8) != 0)
		{
			stream.smethod_10(134695760);
			stream.smethod_10((int)entry.Crc);
			num += 8;
			if (entry.LocalHeaderRequiresZip64)
			{
				stream.smethod_12(entry.CompressedSize);
				stream.smethod_12(entry.Size);
				num += 16;
			}
			else
			{
				stream.smethod_10((int)entry.CompressedSize);
				stream.smethod_10((int)entry.Size);
				num += 8;
			}
		}
		return num;
	}

	internal static void ReadDataDescriptor(Stream stream, bool zip64, DescriptorData data)
	{
		if (stream.smethod_7() != 134695760)
		{
			throw new ZipException("Data descriptor signature not found");
		}
		data.Crc = stream.smethod_7();
		if (zip64)
		{
			data.CompressedSize = stream.smethod_8();
			data.Size = stream.smethod_8();
		}
		else
		{
			data.CompressedSize = stream.smethod_7();
			data.Size = stream.smethod_7();
		}
	}

	internal static int WriteEndEntry(Stream stream, ZipEntry entry, StringCodec stringCodec)
	{
		stream.smethod_10(33639248);
		ByteOrderStreamExtensions.WriteLEShort(stream, (entry.HostSystem << 8) | entry.VersionMadeBy);
		ByteOrderStreamExtensions.WriteLEShort(stream, entry.Version);
		ByteOrderStreamExtensions.WriteLEShort(stream, entry.Flags);
		ByteOrderStreamExtensions.WriteLEShort(stream, (short)entry.CompressionMethodForHeader);
		stream.smethod_10((int)entry.DosTime);
		stream.smethod_10((int)entry.Crc);
		if (!entry.IsZip64Forced() && entry.CompressedSize < 4294967295L)
		{
			stream.smethod_10((int)entry.CompressedSize);
		}
		else
		{
			stream.smethod_10(-1);
		}
		if (!entry.IsZip64Forced() && entry.Size < 4294967295L)
		{
			stream.smethod_10((int)entry.Size);
		}
		else
		{
			stream.smethod_10(-1);
		}
		byte[] bytes = stringCodec.ZipOutputEncoding.GetBytes(entry.Name);
		if (bytes.Length <= 65535)
		{
			ZipExtraData zipExtraData = new ZipExtraData(entry.ExtraData);
			if (entry.CentralHeaderRequiresZip64)
			{
				zipExtraData.StartNewEntry();
				if (entry.IsZip64Forced() || entry.Size >= 4294967295L)
				{
					zipExtraData.AddLeLong(entry.Size);
				}
				if (entry.IsZip64Forced() || entry.CompressedSize >= 4294967295L)
				{
					zipExtraData.AddLeLong(entry.CompressedSize);
				}
				if (entry.Offset >= 4294967295L)
				{
					zipExtraData.AddLeLong(entry.Offset);
				}
				zipExtraData.AddNewEntry(1);
			}
			else
			{
				zipExtraData.Delete(1);
			}
			if (entry.AESKeySize > 0)
			{
				AddExtraDataAES(entry, zipExtraData);
			}
			byte[] entryData = zipExtraData.GetEntryData();
			byte[] array = ((entry.Comment != null) ? stringCodec.ZipOutputEncoding.GetBytes(entry.Comment) : Empty.Array<byte>());
			if (array.Length <= 65535)
			{
				ByteOrderStreamExtensions.WriteLEShort(stream, bytes.Length);
				ByteOrderStreamExtensions.WriteLEShort(stream, entryData.Length);
				ByteOrderStreamExtensions.WriteLEShort(stream, array.Length);
				ByteOrderStreamExtensions.WriteLEShort(stream, 0);
				ByteOrderStreamExtensions.WriteLEShort(stream, 0);
				if (entry.ExternalFileAttributes != -1)
				{
					stream.smethod_10(entry.ExternalFileAttributes);
				}
				else if (entry.IsDirectory)
				{
					stream.smethod_10(16);
				}
				else
				{
					stream.smethod_10(0);
				}
				if (entry.Offset < 4294967295L)
				{
					stream.smethod_10((int)entry.Offset);
				}
				else
				{
					stream.smethod_10(-1);
				}
				if (bytes.Length != 0)
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				if (entryData.Length != 0)
				{
					stream.Write(entryData, 0, entryData.Length);
				}
				int num;
				if (array.Length != 0)
				{
					stream.Write(array, 0, array.Length);
					num = 46;
				}
				else
				{
					num = 46;
				}
				return num + bytes.Length + entryData.Length + array.Length;
			}
			throw new ZipException("Comment too long.");
		}
		throw new ZipException("Name too long.");
	}

	internal static void AddExtraDataAES(ZipEntry entry, ZipExtraData extraData)
	{
		extraData.StartNewEntry();
		extraData.AddLeShort(2);
		extraData.AddLeShort(17729);
		extraData.AddData(entry.AESEncryptionStrength);
		extraData.AddLeShort((int)entry.CompressionMethod);
		extraData.AddNewEntry(39169);
	}

	internal static async Task PatchLocalHeaderAsync(Stream stream, ZipEntry entry, ICSharpCode.SharpZipLib.Zip.EntryPatchData patchData, CancellationToken ct)
	{
		long initialPos = stream.Position;
		stream.Seek(patchData.CrcPatchOffset, SeekOrigin.Begin);
		await ByteOrderStreamExtensions.WriteLEIntAsync(stream, (int)entry.Crc, ct).ConfigureAwait(continueOnCapturedContext: false);
		if (!entry.LocalHeaderRequiresZip64)
		{
			await ByteOrderStreamExtensions.WriteLEIntAsync(stream, (int)entry.CompressedSize, ct).ConfigureAwait(continueOnCapturedContext: false);
			await ByteOrderStreamExtensions.WriteLEIntAsync(stream, (int)entry.Size, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		else
		{
			if (patchData.SizePatchOffset == -1L)
			{
				throw new ZipException("Entry requires zip64 but this has been turned off");
			}
			stream.Seek(patchData.SizePatchOffset, SeekOrigin.Begin);
			await ByteOrderStreamExtensions.WriteLELongAsync(stream, entry.Size, ct).ConfigureAwait(continueOnCapturedContext: false);
			await ByteOrderStreamExtensions.WriteLELongAsync(stream, entry.CompressedSize, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		stream.Seek(initialPos, SeekOrigin.Begin);
	}

	internal static void PatchLocalHeaderSync(Stream stream, ZipEntry entry, ICSharpCode.SharpZipLib.Zip.EntryPatchData patchData)
	{
		long position = stream.Position;
		stream.Seek(patchData.CrcPatchOffset, SeekOrigin.Begin);
		stream.smethod_10((int)entry.Crc);
		if (!entry.LocalHeaderRequiresZip64)
		{
			stream.smethod_10((int)entry.CompressedSize);
			stream.smethod_10((int)entry.Size);
		}
		else
		{
			if (patchData.SizePatchOffset == -1L)
			{
				throw new ZipException("Entry requires zip64 but this has been turned off");
			}
			stream.Seek(patchData.SizePatchOffset, SeekOrigin.Begin);
			stream.smethod_12(entry.Size);
			stream.smethod_12(entry.CompressedSize);
		}
		stream.Seek(position, SeekOrigin.Begin);
	}

	static ZipFormat()
	{
		Class72.smethod_20();
	}
}
