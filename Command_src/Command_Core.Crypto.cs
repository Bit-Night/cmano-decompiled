using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Crypto
{
	private static byte[] byte_0;

	private static string string_0;

	public static string string_1;

	private static LockObject lockObject_0;

	private MD5 md5_0;

	static Crypto()
	{
		Class72.smethod_20();
		byte_0 = Encoding.ASCII.GetBytes("o6806642kbM7c5");
		string_0 = "6b887c5ac993e7ae98c4c08e19f56429fdeb440755a4701b-7e80-4e57-9b96-3e9bee544da1942448a6-3112-4975-a68c-68782c80c0af";
		string_1 = "EBA66B7C-B09A-4EE0E860AE-410C-410D-8E7E-0AC92423D79F8F-8CD3-4BC7C54842BD8CC4DF32-BAAC-4C5F-8120-FD02B6131532";
		lockObject_0 = new LockObject();
	}

	internal static string EncryptStringAES(string plainText, string sharedKey = "")
	{
		if (!string.IsNullOrEmpty(plainText))
		{
			if (string.IsNullOrEmpty(sharedKey))
			{
				sharedKey = string_0;
			}
			string text = null;
			RijndaelManaged rijndaelManaged = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(sharedKey, byte_0);
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
				ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using MemoryTributary memoryTributary = new MemoryTributary();
				memoryTributary.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
				memoryTributary.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
				using (CryptoStream stream = new CryptoStream(memoryTributary, transform, CryptoStreamMode.Write))
				{
					using StreamWriter streamWriter = new StreamWriter(stream);
					streamWriter.Write(plainText);
				}
				return Convert.ToBase64String(memoryTributary.ToArray());
			}
			finally
			{
				rijndaelManaged?.Clear();
			}
		}
		throw new ArgumentNullException("plainText");
	}

	internal static string DecryptStringAES(string cipherText, string sharedKey = "")
	{
		if (!string.IsNullOrEmpty(cipherText))
		{
			if (string.IsNullOrEmpty(sharedKey) && string.IsNullOrEmpty(sharedKey))
			{
				sharedKey = string_0;
			}
			RijndaelManaged rijndaelManaged = null;
			string result = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(sharedKey, byte_0);
				byte[] source = Convert.FromBase64String(cipherText);
				using MemoryTributary memoryTributary = new MemoryTributary(source);
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes((int)Math.Round((double)rijndaelManaged.KeySize / 8.0));
				rijndaelManaged.IV = smethod_0(memoryTributary);
				ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using CryptoStream stream = new CryptoStream(memoryTributary, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream);
				result = streamReader.ReadToEnd();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				_ = Debugger.IsAttached;
				ProjectData.ClearProjectError();
			}
			finally
			{
				rijndaelManaged?.Clear();
			}
			return result;
		}
		throw new ArgumentNullException("cipherText");
	}

	private static byte[] smethod_0(Stream stream_0)
	{
		byte[] array = new byte[4];
		if (stream_0.Read(array, 0, array.Length) != array.Length)
		{
			throw new SystemException("Stream did not contain properly formatted byte array");
		}
		byte[] array2 = new byte[BitConverter.ToInt32(array, 0) - 1 + 1];
		if (stream_0.Read(array2, 0, array2.Length) != array2.Length)
		{
			throw new SystemException("Did not read byte array properly");
		}
		return array2;
	}

	public static string GetFileHashFromFilename(string theFileName)
	{
		lock (lockObject_0)
		{
			using FileStream inputStream = new FileStream(theFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			using SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			return Misc.ByteArrayToHexString(sHA1CryptoServiceProvider.ComputeHash(inputStream));
		}
	}

	public static string GetFileHashViaTempCopy(string theFileName)
	{
		string tempFileName = Path.GetTempFileName();
		try
		{
			File.Copy(theFileName, tempFileName, overwrite: true);
			using FileStream inputStream = new FileStream(tempFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
			using SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			return Misc.ByteArrayToHexString(sHA1CryptoServiceProvider.ComputeHash(inputStream));
		}
		finally
		{
			if (File.Exists(tempFileName))
			{
				try
				{
					File.Delete(tempFileName);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	internal string method_0(string inputString)
	{
		if (Information.IsNothing((object)md5_0))
		{
			md5_0 = MD5.Create();
		}
		byte[] bytes = Encoding.UTF8.GetBytes(inputString);
		return Convert.ToBase64String(md5_0.ComputeHash(bytes));
	}
}
