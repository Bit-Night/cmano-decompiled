using System;
using ICSharpCode.SharpZipLib.Checksum;

namespace ICSharpCode.SharpZipLib.Encryption;

internal class PkzipClassicCryptoBase
{
	private uint[] uint_0;

	protected byte TransformByte()
	{
		uint num = (uint_0[2] & 0xFFFF) | 2;
		return (byte)(num * (num ^ 1) >> 8);
	}

	protected void SetKeys(byte[] keyData)
	{
		if (keyData == null)
		{
			throw new ArgumentNullException("keyData");
		}
		if (keyData.Length != 12)
		{
			throw new InvalidOperationException("Key length is not valid");
		}
		uint_0 = new uint[3];
		uint_0[0] = (uint)((keyData[3] << 24) | (keyData[2] << 16) | (keyData[1] << 8) | keyData[0]);
		uint_0[1] = (uint)((keyData[7] << 24) | (keyData[6] << 16) | (keyData[5] << 8) | keyData[4]);
		uint_0[2] = (uint)((keyData[11] << 24) | (keyData[10] << 16) | (keyData[9] << 8) | keyData[8]);
	}

	protected void UpdateKeys(byte ch)
	{
		uint_0[0] = Crc32.ComputeCrc32(uint_0[0], ch);
		uint_0[1] = uint_0[1] + (byte)uint_0[0];
		uint_0[1] = uint_0[1] * 134775813 + 1;
		uint_0[2] = Crc32.ComputeCrc32(uint_0[2], (byte)(uint_0[1] >> 24));
	}

	protected void Reset()
	{
		uint_0[0] = 0u;
		uint_0[1] = 0u;
		uint_0[2] = 0u;
	}

	static PkzipClassicCryptoBase()
	{
		Class72.smethod_20();
	}
}
