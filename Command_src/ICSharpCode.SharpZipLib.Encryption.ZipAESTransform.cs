using System;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.Zip;

namespace ICSharpCode.SharpZipLib.Encryption;

internal class ZipAESTransform : ICryptoTransform, IDisposable
{
	private int hdgysLeamuJ;

	private readonly ICryptoTransform icryptoTransform_0;

	private readonly byte[] byte_0;

	private byte[] byte_1;

	private int int_0;

	private byte[] byte_2;

	private IncrementalHash incrementalHash_0;

	private byte[] byte_3;

	private bool bool_0;

	public byte[] PwdVerifier => byte_2;

	public int InputBlockSize => hdgysLeamuJ;

	public int OutputBlockSize => hdgysLeamuJ;

	public bool CanTransformMultipleBlocks => true;

	public bool CanReuseTransform => true;

	public ZipAESTransform(string key, byte[] saltBytes, int blockSize, bool writeMode)
	{
		if (blockSize != 16 && blockSize != 32)
		{
			throw new Exception("Invalid blocksize " + blockSize + ". Must be 16 or 32.");
		}
		if (saltBytes.Length != blockSize / 2)
		{
			throw new Exception("Invalid salt len. Must be " + blockSize / 2 + " for blocksize " + blockSize);
		}
		hdgysLeamuJ = blockSize;
		byte_1 = new byte[hdgysLeamuJ];
		int_0 = 16;
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, saltBytes, 1000);
		Aes aes = Aes.Create();
		aes.Mode = CipherMode.ECB;
		byte_0 = new byte[hdgysLeamuJ];
		byte[] bytes = rfc2898DeriveBytes.GetBytes(hdgysLeamuJ);
		byte[] bytes2 = rfc2898DeriveBytes.GetBytes(hdgysLeamuJ);
		icryptoTransform_0 = aes.CreateEncryptor(bytes, new byte[16]);
		byte_2 = rfc2898DeriveBytes.GetBytes(2);
		incrementalHash_0 = IncrementalHash.CreateHMAC(HashAlgorithmName.SHA1, bytes2);
		bool_0 = writeMode;
	}

	public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
	{
		int num;
		if (bool_0)
		{
			num = 0;
		}
		else
		{
			incrementalHash_0.AppendData(inputBuffer, inputOffset, inputCount);
			num = 0;
		}
		for (int i = num; i < inputCount; i++)
		{
			if (int_0 == 16)
			{
				int num2 = 0;
				while (++byte_0[num2] == 0)
				{
					num2++;
				}
				icryptoTransform_0.TransformBlock(byte_0, 0, hdgysLeamuJ, byte_1, 0);
				int_0 = 0;
			}
			outputBuffer[i + outputOffset] = (byte)(inputBuffer[i + inputOffset] ^ byte_1[int_0++]);
		}
		if (bool_0)
		{
			incrementalHash_0.AppendData(outputBuffer, outputOffset, inputCount);
		}
		return inputCount;
	}

	public byte[] GetAuthCode()
	{
		return byte_3 ?? (byte_3 = incrementalHash_0.GetHashAndReset());
	}

	public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
	{
		byte[] array = Array.Empty<byte>();
		if (inputCount != 0)
		{
			if (inputCount <= 10)
			{
				if (inputCount < 10)
				{
					throw new ZipException("Auth code missing from input stream");
				}
			}
			else
			{
				int num = inputCount - 10;
				array = new byte[num];
				TransformBlock(inputBuffer, inputOffset, num, array, 0);
			}
			byte_3 = incrementalHash_0.GetHashAndReset();
		}
		return array;
	}

	public void Dispose()
	{
		icryptoTransform_0.Dispose();
	}

	static ZipAESTransform()
	{
		Class72.smethod_20();
	}
}
