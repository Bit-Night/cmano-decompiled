using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.GZip;

public class GZipOutputStream : DeflaterOutputStream
{
	private enum Enum16
	{
		Header
	}

	protected Crc32 crc = new Crc32();

	private Enum16 enum16_0;

	private string string_0;

	private GZipFlags gzipFlags_0;

	[CompilerGenerated]
	private DateTime? nullable_0;

	public string FileName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = smethod_0(value);
			if (string.IsNullOrEmpty(string_0))
			{
				gzipFlags_0 &= ~GZipFlags.FNAME;
			}
			else
			{
				gzipFlags_0 |= GZipFlags.FNAME;
			}
		}
	}

	public DateTime? ModifiedTime
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public GZipOutputStream(Stream baseOutputStream)
		: this(baseOutputStream, 4096)
	{
	}

	public GZipOutputStream(Stream baseOutputStream, int size)
		: base(baseOutputStream, new Deflater(-1, noZlibHeaderOrFooter: true), size)
	{
	}

	public void SetLevel(int level)
	{
		if (level < 0 || level > 9)
		{
			throw new ArgumentOutOfRangeException("level", "Compression level must be 0-9");
		}
		deflater_.SetLevel(level);
	}

	public int GetLevel()
	{
		return deflater_.GetLevel();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		method_1(buffer, offset, count, null).GetAwaiter().GetResult();
	}

	private async Task method_1(byte[] byte_2, int int_0, int int_1, CancellationToken? nullable_1)
	{
		if (enum16_0 == Enum16.Header)
		{
			if (nullable_1.HasValue)
			{
				await method_5(nullable_1.Value).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				method_4();
			}
		}
		if (enum16_0 != (Enum16)1)
		{
			throw new InvalidOperationException("Write not permitted in current state");
		}
		crc.Update(new ArraySegment<byte>(byte_2, int_0, int_1));
		if (!nullable_1.HasValue)
		{
			base.Write(byte_2, int_0, int_1);
		}
		else
		{
			await base.WriteAsync(byte_2, int_0, int_1, nullable_1.Value).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken ct)
	{
		await method_1(buffer, offset, count, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			Finish();
		}
		finally
		{
			if (enum16_0 != (Enum16)3)
			{
				enum16_0 = (Enum16)3;
				if (base.IsStreamOwner)
				{
					baseOutputStream_.Dispose();
				}
			}
		}
	}

	public override void Flush()
	{
		if (enum16_0 == Enum16.Header)
		{
			method_4();
		}
		base.Flush();
	}

	public override async Task FlushAsync(CancellationToken ct)
	{
		if (enum16_0 == Enum16.Header)
		{
			await method_5(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		await base.FlushAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public override void Finish()
	{
		if (enum16_0 == Enum16.Header)
		{
			method_4();
		}
		if (enum16_0 == (Enum16)1)
		{
			enum16_0 = (Enum16)2;
			base.Finish();
			byte[] array = method_2();
			baseOutputStream_.Write(array, 0, array.Length);
		}
	}

	public override async Task FinishAsync(CancellationToken ct)
	{
		if (enum16_0 == Enum16.Header)
		{
			await method_5(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (enum16_0 == (Enum16)1)
		{
			enum16_0 = (Enum16)2;
			await base.FinishAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			byte[] array = method_2();
			await baseOutputStream_.WriteAsync(array, 0, array.Length, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	private byte[] method_2()
	{
		uint num = (uint)(deflater_.TotalIn & 0xFFFFFFFFL);
		uint num2 = (uint)(crc.Value & 0xFFFFFFFFL);
		return new byte[8]
		{
			(byte)num2,
			(byte)(num2 >> 8),
			(byte)(num2 >> 16),
			(byte)(num2 >> 24),
			(byte)num,
			(byte)(num >> 8),
			(byte)(num >> 16),
			(byte)(num >> 24)
		};
	}

	private byte[] method_3()
	{
		int num = (int)(((ModifiedTime?.ToUniversalTime() ?? DateTime.UtcNow) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks / 10000000L);
		byte[] obj = new byte[10] { 31, 139, 8, 0, 0, 0, 0, 0, 0, 255 };
		obj[3] = (byte)gzipFlags_0;
		obj[4] = (byte)num;
		obj[5] = (byte)(num >> 8);
		obj[6] = (byte)(num >> 16);
		obj[7] = (byte)(num >> 24);
		byte[] array = obj;
		if (gzipFlags_0.HasFlag(GZipFlags.FNAME))
		{
			return array.Concat(GZipConstants.Encoding.GetBytes(string_0)).Concat(new byte[1]).ToArray();
		}
		return array;
	}

	private static string smethod_0(string string_1)
	{
		return string_1.Substring(string_1.LastIndexOf('/') + 1);
	}

	private void method_4()
	{
		if (enum16_0 == Enum16.Header)
		{
			enum16_0 = (Enum16)1;
			byte[] array = method_3();
			baseOutputStream_.Write(array, 0, array.Length);
		}
	}

	private async Task method_5(CancellationToken cancellationToken_0)
	{
		if (enum16_0 == Enum16.Header)
		{
			enum16_0 = (Enum16)1;
			byte[] array = method_3();
			await baseOutputStream_.WriteAsync(array, 0, array.Length, cancellationToken_0).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[CompilerGenerated]
	private Task method_6(byte[] byte_2, int int_0, int int_1, CancellationToken cancellationToken_0)
	{
		return base.WriteAsync(byte_2, int_0, int_1, cancellationToken_0);
	}

	[CompilerGenerated]
	private void uimyrbKksgr(byte[] byte_2, int int_0, int int_1)
	{
		base.Write(byte_2, int_0, int_1);
	}

	[CompilerGenerated]
	private Task method_7(CancellationToken cancellationToken_0)
	{
		return base.FlushAsync(cancellationToken_0);
	}

	[CompilerGenerated]
	private Task method_8(CancellationToken cancellationToken_0)
	{
		return base.FinishAsync(cancellationToken_0);
	}

	static GZipOutputStream()
	{
		Class72.smethod_20();
	}
}
