using System;
using System.Security.Cryptography;
using System.Text;

namespace CommandNetcode;

public sealed class PasswordHash
{
	public const int SALT_BYTES = 256;

	public const int HASH_BYTES = 256;

	public const int PBKDF2_ITERATIONS = 100000;

	public const int ITERATION_INDEX = 1;

	public const int SALT_INDEX = 2;

	public const int PBKDF2_INDEX = 3;

	public static string SaltHashPassword(string password)
	{
		return smethod_0(HashPassword(password));
	}

	public static string HashPassword(string password)
	{
		password = Convert.ToBase64String(SHA512.Create().ComputeHash(Encoding.Unicode.GetBytes(password)));
		return password;
	}

	private static string smethod_0(string string_0)
	{
		RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		byte[] array = new byte[256];
		rNGCryptoServiceProvider.GetBytes(array);
		byte[] inArray = smethod_2(string_0, array, 100000, 256);
		return "sha512:" + 100000 + ":" + Convert.ToBase64String(array) + ":" + Convert.ToBase64String(inArray);
	}

	public static bool ValidatePassword(string KnownPasswordHash, string PossiblyIncorrectPasswordSaltedHash)
	{
		char[] separator = new char[1] { ':' };
		string[] array = PossiblyIncorrectPasswordSaltedHash.Split(separator);
		int int_ = int.Parse(array[1]);
		byte[] byte_ = Convert.FromBase64String(array[2]);
		byte[] array2 = Convert.FromBase64String(array[3]);
		byte[] object_ = smethod_2(KnownPasswordHash, byte_, int_, array2.Length);
		return smethod_1(array2, object_);
	}

	private static bool smethod_1(object object_0, object object_1)
	{
		uint num = (uint)(((Array)object_0).Length ^ ((Array)object_1).Length);
		for (int i = 0; i < ((Array)object_0).Length && i < ((Array)object_1).Length; i++)
		{
			num |= (uint)(((byte[])object_0)[i] ^ ((byte[])object_1)[i]);
		}
		return num == 0;
	}

	private static byte[] smethod_2(string string_0, byte[] byte_0, int int_0, int int_1)
	{
		return new Rfc2898DeriveBytes(string_0, byte_0)
		{
			IterationCount = int_0
		}.GetBytes(int_1);
	}

	static PasswordHash()
	{
		Class72.smethod_20();
	}
}
