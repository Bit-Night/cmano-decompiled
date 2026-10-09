using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Encryption;

namespace ICSharpCode.SharpZipLib.Zip.Compression.Streams;

public class DeflaterOutputStream : Stream
{
	[CompilerGenerated]
	private bool bool_0 = true;

	protected ICryptoTransform cryptoTransform_;

	protected byte[] byte_0;

	private byte[] byte_1;

	protected Deflater deflater_;

	protected Stream baseOutputStream_;

	private bool bool_1;

	protected StringCodec _stringCodec = ZipStrings.GetStringCodec();

	public bool IsStreamOwner
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool CanPatchEntries => baseOutputStream_.CanSeek;

	public Encoding ZipCryptoEncoding
	{
		get
		{
			return _stringCodec.ZipCryptoEncoding;
		}
		set
		{
			_stringCodec = _stringCodec.WithZipCryptoEncoding(value);
		}
	}

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => baseOutputStream_.CanWrite;

	public override long Length => baseOutputStream_.Length;

	public override long Position
	{
		get
		{
			return baseOutputStream_.Position;
		}
		set
		{
			throw new NotSupportedException("Position property not supported");
		}
	}

	public DeflaterOutputStream(Stream baseOutputStream)
		: this(baseOutputStream, new Deflater(), 512)
	{
	}

	public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater)
		: this(baseOutputStream, deflater, 512)
	{
	}

	public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufferSize)
	{
		if (baseOutputStream == null)
		{
			throw new ArgumentNullException("baseOutputStream");
		}
		if (!baseOutputStream.CanWrite)
		{
			throw new ArgumentException("Must support writing", "baseOutputStream");
		}
		if (bufferSize >= 512)
		{
			baseOutputStream_ = baseOutputStream;
			byte_1 = new byte[bufferSize];
			deflater_ = deflater ?? throw new ArgumentNullException("deflater");
			return;
		}
		throw new ArgumentOutOfRangeException("bufferSize");
	}

	public virtual void Finish()
	{
		deflater_.Finish();
		while (!deflater_.IsFinished)
		{
			int num = deflater_.Deflate(byte_1, 0, byte_1.Length);
			if (num <= 0)
			{
				break;
			}
			EncryptBlock(byte_1, 0, num);
			baseOutputStream_.Write(byte_1, 0, num);
		}
		if (!deflater_.IsFinished)
		{
			throw new SharpZipBaseException("Can't deflate all input?");
		}
		baseOutputStream_.Flush();
		if (cryptoTransform_ != null)
		{
			if (cryptoTransform_ is ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)
			{
				byte_0 = ((ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)cryptoTransform_).GetAuthCode();
			}
			cryptoTransform_.Dispose();
			cryptoTransform_ = null;
		}
	}

	public virtual async Task FinishAsync(CancellationToken ct)
	{
		deflater_.Finish();
		while (!deflater_.IsFinished)
		{
			int num = deflater_.Deflate(byte_1, 0, byte_1.Length);
			if (num <= 0)
			{
				break;
			}
			EncryptBlock(byte_1, 0, num);
			await baseOutputStream_.WriteAsync(byte_1, 0, num, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		if (!deflater_.IsFinished)
		{
			throw new SharpZipBaseException("Can't deflate all input?");
		}
		await baseOutputStream_.FlushAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		if (cryptoTransform_ != null)
		{
			if (cryptoTransform_ is ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)
			{
				byte_0 = ((ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)cryptoTransform_).GetAuthCode();
			}
			cryptoTransform_.Dispose();
			cryptoTransform_ = null;
		}
	}

	protected void EncryptBlock(byte[] buffer, int offset, int length)
	{
		if (cryptoTransform_ != null)
		{
			cryptoTransform_.TransformBlock(buffer, 0, length, buffer, 0);
		}
	}

	protected void Deflate()
	{
		method_0(bool_2: false, null).GetAwaiter().GetResult();
	}

	private async Task method_0(bool bool_2, CancellationToken? nullable_0)
	{
		while (bool_2 || !deflater_.IsNeedingInput)
		{
			int num = deflater_.Deflate(byte_1, 0, byte_1.Length);
			if (num <= 0)
			{
				break;
			}
			EncryptBlock(byte_1, 0, num);
			if (!nullable_0.HasValue)
			{
				baseOutputStream_.Write(byte_1, 0, num);
			}
			else
			{
				await baseOutputStream_.WriteAsync(byte_1, 0, num, nullable_0.Value).ConfigureAwait(continueOnCapturedContext: false);
			}
		}
		if (!deflater_.IsNeedingInput)
		{
			throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
		}
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException("DeflaterOutputStream Seek not supported");
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
	}

	public override int ReadByte()
	{
		throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException("DeflaterOutputStream Read not supported");
	}

	public override void Flush()
	{
		deflater_.Flush();
		method_0(bool_2: true, null).GetAwaiter().GetResult();
		baseOutputStream_.Flush();
	}

	public override async Task FlushAsync(CancellationToken cancellationToken)
	{
		deflater_.Flush();
		await method_0(bool_2: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await baseOutputStream_.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (bool_1)
		{
			return;
		}
		bool_1 = true;
		try
		{
			Finish();
			if (cryptoTransform_ != null)
			{
				GetAuthCodeIfAES();
				cryptoTransform_.Dispose();
				cryptoTransform_ = null;
			}
		}
		finally
		{
			if (IsStreamOwner)
			{
				baseOutputStream_.Dispose();
			}
		}
	}

	protected void GetAuthCodeIfAES()
	{
		if (cryptoTransform_ is ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)
		{
			byte_0 = ((ICSharpCode.SharpZipLib.Encryption.ZipAESTransform)cryptoTransform_).GetAuthCode();
		}
	}

	public override void WriteByte(byte value)
	{
		Write(new byte[1] { value }, 0, 1);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		deflater_.SetInput(buffer, offset, count);
		Deflate();
	}

	public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken ct)
	{
		deflater_.SetInput(buffer, offset, count);
		await method_0(bool_2: false, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	static DeflaterOutputStream()
	{
		Class72.smethod_20();
	}
}
