using System;
using System.Security.Cryptography;

public static class RandomUtils
{
	private static readonly RNGCryptoServiceProvider rngcryptoServiceProvider_0;

	public static Random NewRandom()
	{
		byte[] array = new byte[4];
		rngcryptoServiceProvider_0.GetBytes(array);
		return new Random(BitConverter.ToInt32(array, 0));
	}

	static RandomUtils()
	{
		Class72.smethod_20();
		rngcryptoServiceProvider_0 = new RNGCryptoServiceProvider();
	}
}
