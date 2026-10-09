using System;
using System.Security.Cryptography;

namespace ICSharpCode.SharpZipLib.Encryption;

public sealed class PkzipClassicManaged : PkzipClassic
{
	private byte[] byte_0;

	public override int BlockSize
	{
		get
		{
			return 8;
		}
		set
		{
			if (value != 8)
			{
				throw new CryptographicException("Block size is invalid");
			}
		}
	}

	public override KeySizes[] LegalKeySizes => new KeySizes[1]
	{
		new KeySizes(96, 96, 0)
	};

	public override KeySizes[] LegalBlockSizes => new KeySizes[1]
	{
		new KeySizes(8, 8, 0)
	};

	public override byte[] Key
	{
		get
		{
			if (byte_0 == null)
			{
				GenerateKey();
			}
			return (byte[])byte_0.Clone();
		}
		set
		{
			if (value != null)
			{
				if (value.Length != 12)
				{
					throw new CryptographicException("Key size is illegal");
				}
				byte_0 = (byte[])value.Clone();
				return;
			}
			throw new ArgumentNullException("value");
		}
	}

	public override void GenerateIV()
	{
	}

	public override void GenerateKey()
	{
		byte_0 = new byte[12];
		using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
		randomNumberGenerator.GetBytes(byte_0);
	}

	public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
	{
		byte_0 = rgbKey;
		return new ICSharpCode.SharpZipLib.Encryption.PkzipClassicEncryptCryptoTransform(Key);
	}

	public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
	{
		byte_0 = rgbKey;
		return new ICSharpCode.SharpZipLib.Encryption.PkzipClassicDecryptCryptoTransform(Key);
	}

	static PkzipClassicManaged()
	{
		Class72.smethod_20();
	}
}
