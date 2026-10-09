using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip;

public class ZipOutputStream : DeflaterOutputStream
{
	[CompilerGenerated]
	private INameTransform inameTransform_0 = new PathTransformer();

	private List<ZipEntry> list_0 = new List<ZipEntry>();

	private Crc32 crc32_0 = new Crc32();

	private ZipEntry zipEntry_0;

	private bool bool_2;

	private int int_0 = -1;

	private CompressionMethod compressionMethod_0 = CompressionMethod.Deflated;

	private long long_0;

	private long long_1;

	private byte[] byte_2 = Empty.Array<byte>();

	private bool bool_3;

	private ICSharpCode.SharpZipLib.Zip.EntryPatchData entryPatchData_0;

	private UseZip64 useZip64_0 = UseZip64.Dynamic;

	private string string_0;

	private static RandomNumberGenerator randomNumberGenerator_0;

	public bool IsFinished => list_0 == null;

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

	public INameTransform NameTransform
	{
		[CompilerGenerated]
		get
		{
			return inameTransform_0;
		}
		[CompilerGenerated]
		set
		{
			inameTransform_0 = value;
		}
	}

	public string Password
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value != null && value.Length == 0)
			{
				string_0 = null;
			}
			else
			{
				string_0 = value;
			}
		}
	}

	public ZipOutputStream(Stream baseOutputStream)
		: base(baseOutputStream, new Deflater(-1, noZlibHeaderOrFooter: true))
	{
	}

	public ZipOutputStream(Stream baseOutputStream, int bufferSize)
		: base(baseOutputStream, new Deflater(-1, noZlibHeaderOrFooter: true), bufferSize)
	{
	}

	public ZipOutputStream(Stream baseOutputStream, StringCodec stringCodec)
		: this(baseOutputStream)
	{
		_stringCodec = stringCodec;
	}

	public void SetComment(string comment)
	{
		byte[] bytes = _stringCodec.ZipArchiveCommentEncoding.GetBytes(comment);
		if (bytes.Length > 65535)
		{
			throw new ArgumentOutOfRangeException("comment");
		}
		byte_2 = bytes;
	}

	public void SetLevel(int level)
	{
		deflater_.SetLevel(level);
		int_0 = level;
	}

	public int GetLevel()
	{
		return deflater_.GetLevel();
	}

	private void method_1(int int_1)
	{
		baseOutputStream_.WriteByte((byte)(int_1 & 0xFF));
		baseOutputStream_.WriteByte((byte)((int_1 >> 8) & 0xFF));
	}

	private void method_2(int int_1)
	{
		method_1(int_1);
		method_1(int_1 >> 16);
	}

	private void method_3(long long_2)
	{
		method_2((int)long_2);
		method_2((int)(long_2 >> 32));
	}

	private void method_4(ZipEntry zipEntry_1)
	{
		if (NameTransform != null)
		{
			zipEntry_1.Name = (zipEntry_1.IsDirectory ? NameTransform.TransformDirectory(zipEntry_1.Name) : NameTransform.TransformFile(zipEntry_1.Name));
		}
	}

	public void PutNextEntry(ZipEntry entry)
	{
		if (zipEntry_0 != null)
		{
			CloseEntry();
		}
		PutNextEntry(baseOutputStream_, entry);
		if (entry.IsCrypted)
		{
			method_5(method_7(entry));
		}
	}

	public void PutNextPassthroughEntry(ZipEntry entry)
	{
		if (zipEntry_0 != null)
		{
			CloseEntry();
		}
		if (entry.Crc < 0L)
		{
			throw new ZipException("Crc must be set for passthrough entry");
		}
		if (entry.Size < 0L)
		{
			throw new ZipException("Size must be set for passthrough entry");
		}
		if (entry.CompressedSize < 0L)
		{
			throw new ZipException("CompressedSize must be set for passthrough entry");
		}
		if (entry.CompressionMethod != CompressionMethod.Deflated)
		{
			throw new NotImplementedException("Only Deflated entries are supported for passthrough");
		}
		if (!string.IsNullOrEmpty(Password))
		{
			throw new NotImplementedException("Encrypted passthrough entries are not supported");
		}
		PutNextEntry(baseOutputStream_, entry, 0L, passthroughEntry: true);
	}

	private void method_5(byte[] byte_3)
	{
		baseOutputStream_.Write(byte_3, 0, byte_3.Length);
	}

	private Task method_6(byte[] byte_3)
	{
		return baseOutputStream_.WriteAsync(byte_3, 0, byte_3.Length);
	}

	private byte[] method_7(ZipEntry zipEntry_1)
	{
		if (zipEntry_1.AESKeySize <= 0)
		{
			return method_9((zipEntry_1.Crc < 0L) ? (zipEntry_1.DosTime << 16) : zipEntry_1.Crc);
		}
		return InitializeAESPassword(zipEntry_1, Password);
	}

	internal void PutNextEntry(Stream stream, ZipEntry entry, long streamOffset = 0L, bool passthroughEntry = false)
	{
		if (entry == null)
		{
			throw new ArgumentNullException("entry");
		}
		if (list_0 != null)
		{
			if (list_0.Count == int.MaxValue)
			{
				throw new ZipException("Too many entries for Zip file");
			}
			CompressionMethod compressionMethod = entry.CompressionMethod;
			if (compressionMethod != CompressionMethod.Deflated && compressionMethod != CompressionMethod.Stored)
			{
				throw new NotImplementedException("Compression method not supported");
			}
			if (entry.AESKeySize > 0 && string.IsNullOrEmpty(Password))
			{
				throw new InvalidOperationException("The Password property must be set before AES encrypted entries can be added");
			}
			bool_2 = passthroughEntry;
			int level = int_0;
			entry.Flags &= 2048;
			bool_3 = false;
			bool flag;
			if (entry.Size == 0L && !bool_2)
			{
				entry.CompressedSize = entry.Size;
				entry.Crc = 0L;
				compressionMethod = CompressionMethod.Stored;
				flag = true;
			}
			else
			{
				flag = entry.Size >= 0L && entry.HasCrc && entry.CompressedSize >= 0L;
				if (compressionMethod == CompressionMethod.Stored)
				{
					if (flag)
					{
						entry.CompressedSize = entry.Size;
						flag = entry.HasCrc;
					}
					else if (!base.CanPatchEntries)
					{
						compressionMethod = CompressionMethod.Deflated;
						level = 0;
					}
				}
			}
			if (!flag)
			{
				if (!base.CanPatchEntries)
				{
					entry.Flags |= 8;
				}
				else
				{
					bool_3 = true;
				}
			}
			if (Password != null)
			{
				entry.IsCrypted = true;
				if (entry.Crc < 0L)
				{
					entry.Flags |= 8;
				}
			}
			entry.Offset = long_1;
			entry.CompressionMethod = compressionMethod;
			compressionMethod_0 = compressionMethod;
			if (useZip64_0 == UseZip64.On || (entry.Size < 0L && useZip64_0 == UseZip64.Dynamic))
			{
				entry.method_1();
			}
			method_4(entry);
			long_1 += ZipFormat.WriteLocalHeader(stream, entry, out var patchData, flag, bool_3, streamOffset, _stringCodec);
			entryPatchData_0 = patchData;
			if (entry.AESKeySize > 0)
			{
				long_1 += entry.AESOverheadSize;
			}
			zipEntry_0 = entry;
			long_0 = 0L;
			if (!bool_2)
			{
				crc32_0.Reset();
				if (compressionMethod == CompressionMethod.Deflated)
				{
					deflater_.Reset();
					deflater_.SetLevel(level);
				}
			}
			return;
		}
		throw new InvalidOperationException("ZipOutputStream was finished");
	}

	public async Task PutNextEntryAsync(ZipEntry entry, CancellationToken ct = default(CancellationToken))
	{
		if (zipEntry_0 != null)
		{
			await CloseEntryAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		long long_0 = (base.CanPatchEntries ? baseOutputStream_.Position : (-1L));
		await StreamUtils.WriteProcToStreamAsync(baseOutputStream_, delegate(Stream s)
		{
			PutNextEntry(s, entry, long_0);
		}, ct).ConfigureAwait(continueOnCapturedContext: false);
		if (entry.IsCrypted)
		{
			await method_6(method_7(entry)).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public void CloseEntry()
	{
		method_8(null).GetAwaiter().GetResult();
		WriteEntryFooter(baseOutputStream_);
		if (bool_3)
		{
			bool_3 = false;
			ZipFormat.PatchLocalHeaderSync(baseOutputStream_, zipEntry_0, entryPatchData_0);
		}
		list_0.Add(zipEntry_0);
		zipEntry_0 = null;
	}

	private async Task method_8(CancellationToken? nullable_0)
	{
		if (bool_2)
		{
			return;
		}
		if (compressionMethod_0 == CompressionMethod.Deflated)
		{
			if (long_0 < 0L)
			{
				deflater_.Reset();
			}
			else if (nullable_0.HasValue)
			{
				await base.FinishAsync(nullable_0.Value).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				base.Finish();
			}
		}
		if (compressionMethod_0 == CompressionMethod.Stored)
		{
			GetAuthCodeIfAES();
		}
	}

	public async Task CloseEntryAsync(CancellationToken ct)
	{
		await method_8(ct).ConfigureAwait(continueOnCapturedContext: false);
		await StreamUtils.WriteProcToStreamAsync(baseOutputStream_, WriteEntryFooter, ct).ConfigureAwait(continueOnCapturedContext: false);
		if (bool_3)
		{
			bool_3 = false;
			await ZipFormat.PatchLocalHeaderAsync(baseOutputStream_, zipEntry_0, entryPatchData_0, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		list_0.Add(zipEntry_0);
		zipEntry_0 = null;
	}

	internal void WriteEntryFooter(Stream stream)
	{
		if (zipEntry_0 == null)
		{
			throw new InvalidOperationException("No open entry");
		}
		if (!bool_2)
		{
			long totalOut = long_0;
			if (compressionMethod_0 == CompressionMethod.Deflated && long_0 >= 0L)
			{
				totalOut = deflater_.TotalOut;
			}
			if (zipEntry_0.AESKeySize <= 0)
			{
				if (zipEntry_0.Crc >= 0L)
				{
					if (zipEntry_0.Crc != crc32_0.Value)
					{
						throw new ZipException($"crc was {crc32_0.Value}, but {zipEntry_0.Crc} was expected");
					}
				}
				else
				{
					zipEntry_0.Crc = crc32_0.Value;
				}
			}
			else
			{
				stream.Write(byte_0, 0, 10);
				zipEntry_0.Crc = 0L;
			}
			if (zipEntry_0.Size < 0L)
			{
				zipEntry_0.Size = long_0;
			}
			else if (zipEntry_0.Size != long_0)
			{
				throw new ZipException($"size was {long_0}, but {zipEntry_0.Size} was expected");
			}
			if (zipEntry_0.CompressedSize < 0L)
			{
				zipEntry_0.CompressedSize = totalOut;
			}
			else if (zipEntry_0.CompressedSize != totalOut)
			{
				throw new ZipException($"compressed size was {totalOut}, but {zipEntry_0.CompressedSize} expected");
			}
			long_1 += totalOut;
			if (zipEntry_0.IsCrypted)
			{
				zipEntry_0.CompressedSize += zipEntry_0.EncryptionOverheadSize;
			}
			if ((zipEntry_0.Flags & 8) != 0)
			{
				stream.smethod_10(134695760);
				stream.smethod_10((int)zipEntry_0.Crc);
				if (!zipEntry_0.LocalHeaderRequiresZip64)
				{
					stream.smethod_10((int)zipEntry_0.CompressedSize);
					stream.smethod_10((int)zipEntry_0.Size);
					long_1 += 16L;
				}
				else
				{
					stream.smethod_12(zipEntry_0.CompressedSize);
					stream.smethod_12(zipEntry_0.Size);
					long_1 += 24L;
				}
			}
		}
		else
		{
			if (zipEntry_0.CompressedSize != long_0)
			{
				throw new ZipException($"compressed size was {long_0}, but {zipEntry_0.CompressedSize} expected");
			}
			long_1 += long_0;
		}
	}

	protected byte[] InitializeAESPassword(ZipEntry entry, string rawPassword)
	{
		byte[] array = new byte[entry.AESSaltLen];
		if (randomNumberGenerator_0 == null)
		{
			randomNumberGenerator_0 = RandomNumberGenerator.Create();
		}
		randomNumberGenerator_0.GetBytes(array);
		int blockSize = entry.AESKeySize / 8;
		cryptoTransform_ = new ICSharpCode.SharpZipLib.Encryption.ZipAESTransform(rawPassword, array, blockSize, writeMode: true);
		byte[] array2 = new byte[array.Length + 2];
		Array.Copy(array, array2, array.Length);
		Array.Copy(((ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)cryptoTransform_).PwdVerifier, 0, array2, array2.Length - 2, 2);
		return array2;
	}

	private byte[] method_9(long long_2)
	{
		long_1 += 12L;
		method_10(Password);
		byte[] array = new byte[12];
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			randomNumberGenerator.GetBytes(array);
		}
		array[11] = (byte)(long_2 >> 24);
		EncryptBlock(array, 0, array.Length);
		return array;
	}

	private void method_10(string string_1)
	{
		PkzipClassicManaged pkzipClassicManaged = new PkzipClassicManaged();
		byte[] rgbKey = PkzipClassic.GenerateKeys(base.ZipCryptoEncoding.GetBytes(string_1));
		cryptoTransform_ = pkzipClassicManaged.CreateEncryptor(rgbKey, null);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		method_11(buffer, offset, count, null).GetAwaiter().GetResult();
	}

	public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken ct)
	{
		await method_11(buffer, offset, count, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task method_11(byte[] byte_3, int int_1, int int_2, CancellationToken? nullable_0)
	{
		if (zipEntry_0 != null)
		{
			if (byte_3 != null)
			{
				if (int_1 >= 0)
				{
					if (int_2 < 0)
					{
						throw new ArgumentOutOfRangeException("count", "Cannot be negative");
					}
					if (byte_3.Length - int_1 < int_2)
					{
						throw new ArgumentException("Invalid offset/count combination");
					}
					if (zipEntry_0.AESKeySize == 0 && !bool_2)
					{
						crc32_0.Update(new ArraySegment<byte>(byte_3, int_1, int_2));
					}
					long_0 += int_2;
					if (compressionMethod_0 != CompressionMethod.Stored && !bool_2)
					{
						if (nullable_0.HasValue)
						{
							await base.WriteAsync(byte_3, int_1, int_2, nullable_0.Value).ConfigureAwait(continueOnCapturedContext: false);
						}
						else
						{
							base.Write(byte_3, int_1, int_2);
						}
					}
					else if (Password == null)
					{
						if (nullable_0.HasValue)
						{
							await baseOutputStream_.WriteAsync(byte_3, int_1, int_2, nullable_0.Value).ConfigureAwait(continueOnCapturedContext: false);
						}
						else
						{
							baseOutputStream_.Write(byte_3, int_1, int_2);
						}
					}
					else
					{
						method_12(byte_3, int_1, int_2);
					}
					return;
				}
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			throw new ArgumentNullException("buffer");
		}
		throw new InvalidOperationException("No open entry.");
	}

	private void method_12(byte[] byte_3, int int_1, int int_2)
	{
		byte[] array = new byte[4096];
		while (int_2 > 0)
		{
			int num = ((int_2 < 4096) ? int_2 : 4096);
			Array.Copy(byte_3, int_1, array, 0, num);
			EncryptBlock(array, 0, num);
			baseOutputStream_.Write(array, 0, num);
			int_2 -= num;
			int_1 += num;
		}
	}

	public override void Finish()
	{
		if (list_0 == null)
		{
			return;
		}
		if (zipEntry_0 != null)
		{
			CloseEntry();
		}
		long noOfEntries = list_0.Count;
		long num = 0L;
		foreach (ZipEntry item in list_0)
		{
			num += ZipFormat.WriteEndEntry(baseOutputStream_, item, _stringCodec);
		}
		ZipFormat.WriteEndOfCentralDirectory(baseOutputStream_, noOfEntries, num, long_1, byte_2);
		list_0 = null;
	}

	public override async Task FinishAsync(CancellationToken ct)
	{
		using MemoryStream ms = new MemoryStream();
		if (list_0 == null)
		{
			return;
		}
		if (this.zipEntry_0 != null)
		{
			await CloseEntryAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		long long_1 = list_0.Count;
		long long_2 = 0L;
		foreach (ZipEntry zipEntry_0 in list_0)
		{
			await StreamUtils.WriteProcToStreamAsync(baseOutputStream_, ms, delegate(Stream s)
			{
				long_2 += ZipFormat.WriteEndEntry(s, zipEntry_0, _stringCodec);
			}, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		await StreamUtils.WriteProcToStreamAsync(baseOutputStream_, ms, delegate(Stream s)
		{
			ZipFormat.WriteEndOfCentralDirectory(s, long_1, long_2, this.long_1, byte_2);
		}, ct).ConfigureAwait(continueOnCapturedContext: false);
		list_0 = null;
	}

	public override void Flush()
	{
		if (compressionMethod_0 == CompressionMethod.Stored)
		{
			baseOutputStream_.Flush();
		}
		else
		{
			base.Flush();
		}
	}

	static ZipOutputStream()
	{
		Class72.smethod_20();
		randomNumberGenerator_0 = RandomNumberGenerator.Create();
	}

	[CompilerGenerated]
	private Task method_13(CancellationToken cancellationToken_0)
	{
		return base.FinishAsync(cancellationToken_0);
	}

	[CompilerGenerated]
	private void method_14()
	{
		base.Finish();
	}

	[CompilerGenerated]
	private Task method_15(byte[] byte_3, int int_1, int int_2, CancellationToken cancellationToken_0)
	{
		return base.WriteAsync(byte_3, int_1, int_2, cancellationToken_0);
	}

	[CompilerGenerated]
	private void method_16(byte[] byte_3, int int_1, int int_2)
	{
		base.Write(byte_3, int_1, int_2);
	}
}
