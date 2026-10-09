using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace QLicense;

public sealed class HardwareInfo
{
	private static string smethod_0()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ManagementObject val = new ManagementObject("Win32_LogicalDisk.deviceid=\"c:\"");
			val.Get();
			return ((ManagementBaseObject)val)["VolumeSerialNumber"].ToString();
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string smethod_1()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ManagementObjectCollection obj = new ManagementObjectSearcher("Select ProcessorId From Win32_processor").Get();
			string result = string.Empty;
			ManagementObjectEnumerator enumerator = obj.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					result = ((ManagementBaseObject)(ManagementObject)enumerator.Current)["ProcessorId"].ToString();
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			return result;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static string smethod_2()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ManagementObjectCollection obj = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard").Get();
			string result = string.Empty;
			ManagementObjectEnumerator enumerator = obj.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					result = ((ManagementBaseObject)(ManagementObject)enumerator.Current)["SerialNumber"].ToString();
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			return result;
		}
		catch
		{
			return string.Empty;
		}
	}

	private static IEnumerable<string> smethod_3(string string_0, int int_0)
	{
		if (string_0 == null)
		{
			throw new ArgumentNullException("input");
		}
		if (int_0 > 0)
		{
			for (int i = 0; i < string_0.Length; i += int_0)
			{
				yield return string_0.Substring(i, Math.Min(int_0, string_0.Length - i));
			}
			yield break;
		}
		throw new ArgumentException("Part length has to be positive.", "partLength");
	}

	public static string smethod_4(string appName)
	{
		string s = appName + smethod_1() + smethod_2() + smethod_0();
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		byte[] value = new MD5CryptoServiceProvider().ComputeHash(bytes);
		string text = BASE36.Encode(BitConverter.ToUInt32(value, 0));
		string text2 = BASE36.Encode(BitConverter.ToUInt32(value, 4));
		string text3 = BASE36.Encode(BitConverter.ToUInt32(value, 8));
		string text4 = BASE36.Encode(BitConverter.ToUInt32(value, 12));
		return $"{text}-{text2}-{text3}-{text4}";
	}

	public static byte[] GetUIDInBytes(string UID)
	{
		string[] array = UID.Split(new char[1] { '-' });
		if (array.Length != 4)
		{
			throw new ArgumentException("Wrong UID");
		}
		byte[] array2 = new byte[16];
		Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(array[0])), 0, array2, 0, 8);
		Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(array[1])), 0, array2, 8, 8);
		Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(array[2])), 0, array2, 16, 8);
		Buffer.BlockCopy(BitConverter.GetBytes(BASE36.Decode(array[3])), 0, array2, 24, 8);
		return array2;
	}

	public static bool ValidateUIDFormat(string UID)
	{
		if (string.IsNullOrWhiteSpace(UID))
		{
			return false;
		}
		return UID.Split(new char[1] { '-' }).Length == 4;
	}

	static HardwareInfo()
	{
		Class72.smethod_20();
	}
}
