using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

internal class Class72
{
	private delegate void Delegate7(object o);

	internal class Attribute0 : Attribute
	{
		internal class Class73<T>
		{
			internal static object object_0;

			static Class73()
			{
				smethod_20();
			}

			internal static bool smethod_0()
			{
				return object_0 == null;
			}

			internal static object smethod_1()
			{
				return object_0;
			}
		}

		public Attribute0(object object_0)
		{
		}
	}

	internal class Class74
	{
		internal static string smethod_0(string string_0, string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] key = new byte[32]
			{
				82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
				51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
				34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
				1, 88
			};
			byte[] iV = smethod_9(Encoding.Unicode.GetBytes(string_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = smethod_7();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iV;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Delegate8(IntPtr classthis, IntPtr comp, IntPtr info, uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate9();

	internal struct Struct73
	{
		internal bool bool_0;

		internal byte[] byte_0;
	}

	internal class Class75
	{
		private BinaryReader binaryReader_0;

		public Class75(Stream stream_0)
		{
			binaryReader_0 = new BinaryReader(stream_0);
		}

		[SpecialName]
		internal Stream method_0()
		{
			return binaryReader_0.BaseStream;
		}

		internal byte[] method_1(int int_0)
		{
			return binaryReader_0.ReadBytes(int_0);
		}

		internal int method_2(byte[] byte_0, int int_0, int int_1)
		{
			return binaryReader_0.Read(byte_0, int_0, int_1);
		}

		internal int method_3()
		{
			return binaryReader_0.ReadInt32();
		}

		internal void method_4()
		{
			binaryReader_0.Close();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private delegate IntPtr Delegate10(IntPtr hModule, string lpName, uint lpType);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate11(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate12(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate13(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate14(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate15(IntPtr ptr);

	[Flags]
	private enum Enum21
	{

	}

	private static IntPtr intptr_0;

	private static long long_0;

	private static Delegate12 delegate12_0;

	private static Delegate14 delegate14_0;

	private static string[] string_0;

	private static Dictionary<int, int> dictionary_0;

	private static bool bool_0;

	private static uint[] uint_0;

	private static byte[] byte_0;

	private static long long_1;

	private static IntPtr intptr_1;

	private static int int_0;

	private static List<string> list_0;

	private static int[] int_1;

	private static Delegate13 delegate13_0;

	private static Delegate15 delegate15_0;

	private static IntPtr intptr_2;

	private static int int_2;

	private static int int_3;

	private static byte[] byte_1;

	private static bool bool_1;

	private static object object_0;

	private static bool bool_2;

	internal static Assembly assembly_0;

	[Attribute0(typeof(Attribute0.Class73<object>[]))]
	private static bool bool_3;

	private static Delegate11 delegate11_0;

	private static IntPtr intptr_3;

	private static object object_1;

	private static int int_4;

	private static Delegate10 delegate10_0;

	private static bool bool_4;

	internal static Delegate8 delegate8_0;

	private static List<int> list_1;

	private static bool bool_5;

	internal static RSACryptoServiceProvider rsacryptoServiceProvider_0;

	private static bool bool_6;

	private static int int_5;

	private static SortedList sortedList_0;

	internal static Delegate8 delegate8_1;

	internal static Hashtable hashtable_0;

	static Class72()
	{
		bool_4 = false;
		assembly_0 = typeof(Class72).Assembly;
		uint_0 = new uint[64]
		{
			3614090360u, 3905402710u, 606105819u, 3250441966u, 4118548399u, 1200080426u, 2821735955u, 4249261313u, 1770035416u, 2336552879u,
			4294925233u, 2304563134u, 1804603682u, 4254626195u, 2792965006u, 1236535329u, 4129170786u, 3225465664u, 643717713u, 3921069994u,
			3593408605u, 38016083u, 3634488961u, 3889429448u, 568446438u, 3275163606u, 4107603335u, 1163531501u, 2850285829u, 4243563512u,
			1735328473u, 2368359562u, 4294588738u, 2272392833u, 1839030562u, 4259657740u, 2763975236u, 1272893353u, 4139469664u, 3200236656u,
			681279174u, 3936430074u, 3572445317u, 76029189u, 3654602809u, 3873151461u, 530742520u, 3299628645u, 4096336452u, 1126891415u,
			2878612391u, 4237533241u, 1700485571u, 2399980690u, 4293915773u, 2240044497u, 1873313359u, 4264355552u, 2734768916u, 1309151649u,
			4149444226u, 3174756917u, 718787259u, 3951481745u
		};
		bool_1 = false;
		bool_2 = false;
		rsacryptoServiceProvider_0 = null;
		dictionary_0 = null;
		object_1 = new object();
		int_0 = 0;
		object_0 = new object();
		list_0 = null;
		list_1 = null;
		byte_0 = new byte[0];
		byte_1 = new byte[0];
		intptr_0 = IntPtr.Zero;
		intptr_3 = IntPtr.Zero;
		string_0 = new string[0];
		int_1 = new int[0];
		int_4 = 1;
		bool_6 = false;
		sortedList_0 = new SortedList();
		int_2 = 0;
		long_1 = 0L;
		delegate8_0 = null;
		delegate8_1 = null;
		long_0 = 0L;
		int_3 = 0;
		bool_0 = false;
		bool_5 = false;
		int_5 = 0;
		intptr_1 = IntPtr.Zero;
		bool_3 = false;
		hashtable_0 = new Hashtable();
		delegate10_0 = null;
		delegate11_0 = null;
		delegate12_0 = null;
		delegate13_0 = null;
		delegate14_0 = null;
		delegate15_0 = null;
		intptr_2 = IntPtr.Zero;
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private void method_0()
	{
	}

	internal static byte[] smethod_0(byte[] byte_2)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - byte_2.Length * 8 % 512 + 512) % 512);
		if (num == 0)
		{
			num = 512u;
		}
		uint num2 = (uint)(byte_2.Length + num / 8 + 8L);
		ulong num3 = (ulong)(byte_2.Length * 8L);
		byte[] array2 = new byte[num2];
		for (int i = 0; i < byte_2.Length; i++)
		{
			array2[i] = byte_2[i];
		}
		array2[byte_2.Length] |= 128;
		for (int num4 = 8; num4 > 0; num4--)
		{
			array2[num2 - num4] = (byte)((num3 >> (8 - num4) * 8) & 0xFFL);
		}
		uint num5 = (uint)(array2.Length * 8) / 32u;
		uint uint_ = 1732584193u;
		uint uint_2 = 4023233417u;
		uint uint_3 = 2562383102u;
		uint uint_4 = 271733878u;
		for (uint num6 = 0u; num6 < num5 / 16; num6++)
		{
			uint num7 = num6 << 6;
			for (uint num8 = 0u; num8 < 61; num8 += 4)
			{
				array[num8 >> 2] = (uint)((array2[num7 + (num8 + 3)] << 24) | (array2[num7 + (num8 + 2)] << 16) | (array2[num7 + (num8 + 1)] << 8) | array2[num7 + num8]);
			}
			uint num9 = uint_;
			uint num10 = uint_2;
			uint num11 = uint_3;
			uint num12 = uint_4;
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 0u, 7, 1u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 1u, 12, 2u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 2u, 17, 3u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 3u, 22, 4u, array);
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 4u, 7, 5u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 5u, 12, 6u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 6u, 17, 7u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 7u, 22, 8u, array);
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 8u, 7, 9u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 9u, 12, 10u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 10u, 17, 11u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 11u, 22, 12u, array);
			smethod_1(ref uint_, uint_2, uint_3, uint_4, 12u, 7, 13u, array);
			smethod_1(ref uint_4, uint_, uint_2, uint_3, 13u, 12, 14u, array);
			smethod_1(ref uint_3, uint_4, uint_, uint_2, 14u, 17, 15u, array);
			smethod_1(ref uint_2, uint_3, uint_4, uint_, 15u, 22, 16u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 1u, 5, 17u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 6u, 9, 18u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 11u, 14, 19u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 0u, 20, 20u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 5u, 5, 21u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 10u, 9, 22u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 15u, 14, 23u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 4u, 20, 24u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 9u, 5, 25u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 14u, 9, 26u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 3u, 14, 27u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 8u, 20, 28u, array);
			smethod_2(ref uint_, uint_2, uint_3, uint_4, 13u, 5, 29u, array);
			smethod_2(ref uint_4, uint_, uint_2, uint_3, 2u, 9, 30u, array);
			smethod_2(ref uint_3, uint_4, uint_, uint_2, 7u, 14, 31u, array);
			smethod_2(ref uint_2, uint_3, uint_4, uint_, 12u, 20, 32u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 5u, 4, 33u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 8u, 11, 34u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 11u, 16, 35u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 14u, 23, 36u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 1u, 4, 37u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 4u, 11, 38u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 7u, 16, 39u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 10u, 23, 40u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 13u, 4, 41u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 0u, 11, 42u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 3u, 16, 43u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 6u, 23, 44u, array);
			smethod_3(ref uint_, uint_2, uint_3, uint_4, 9u, 4, 45u, array);
			smethod_3(ref uint_4, uint_, uint_2, uint_3, 12u, 11, 46u, array);
			smethod_3(ref uint_3, uint_4, uint_, uint_2, 15u, 16, 47u, array);
			smethod_3(ref uint_2, uint_3, uint_4, uint_, 2u, 23, 48u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 0u, 6, 49u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 7u, 10, 50u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 14u, 15, 51u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 5u, 21, 52u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 12u, 6, 53u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 3u, 10, 54u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 10u, 15, 55u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 1u, 21, 56u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 8u, 6, 57u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 15u, 10, 58u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 6u, 15, 59u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 13u, 21, 60u, array);
			smethod_4(ref uint_, uint_2, uint_3, uint_4, 4u, 6, 61u, array);
			smethod_4(ref uint_4, uint_, uint_2, uint_3, 11u, 10, 62u, array);
			smethod_4(ref uint_3, uint_4, uint_, uint_2, 2u, 15, 63u, array);
			smethod_4(ref uint_2, uint_3, uint_4, uint_, 9u, 21, 64u, array);
			uint_ += num9;
			uint_2 += num10;
			uint_3 += num11;
			uint_4 += num12;
		}
		byte[] array3 = new byte[16];
		Array.Copy(BitConverter.GetBytes(uint_), 0, array3, 0, 4);
		Array.Copy(BitConverter.GetBytes(uint_2), 0, array3, 4, 4);
		Array.Copy(BitConverter.GetBytes(uint_3), 0, array3, 8, 4);
		Array.Copy(BitConverter.GetBytes(uint_4), 0, array3, 12, 4);
		return array3;
	}

	private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + ((uint[])object_2)[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + ((uint[])object_2)[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + ((uint[])object_2)[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, object object_2)
	{
		uint_1 = uint_2 + smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + ((uint[])object_2)[uint_5] + uint_0[uint_6 - 1], ushort_0);
	}

	private static uint smethod_5(uint uint_1, ushort ushort_0)
	{
		return (uint_1 >> 32 - ushort_0) | (uint_1 << (int)ushort_0);
	}

	internal static bool smethod_6()
	{
		if (!bool_1)
		{
			smethod_8();
			bool_1 = true;
		}
		return bool_2;
	}

	internal Class72()
	{
	}

	private void method_1(byte[] byte_2, byte[] byte_3, byte[] byte_4)
	{
		int num = byte_4.Length % 4;
		int num2 = byte_4.Length / 4;
		byte[] array = new byte[byte_4.Length];
		int num3 = byte_2.Length / 4;
		uint num4 = 0u;
		uint num5 = 0u;
		uint num6 = 0u;
		if (num > 0)
		{
			num2++;
		}
		uint num7 = 0u;
		for (int i = 0; i < num2; i++)
		{
			int num8 = i % num3;
			int num9 = i * 4;
			num7 = (uint)(num8 * 4);
			num5 = (uint)((byte_2[num7 + 3] << 24) | (byte_2[num7 + 2] << 16) | (byte_2[num7 + 1] << 8) | byte_2[num7]);
			uint num10 = 255u;
			int num11 = 0;
			if (i == num2 - 1 && num > 0)
			{
				num6 = 0u;
				num4 += num5;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num6 <<= 8;
					}
					num6 |= byte_4[^(1 + j)];
				}
			}
			else
			{
				num4 += num5;
				num7 = (uint)num9;
				num6 = (uint)((byte_4[num7 + 3] << 24) | (byte_4[num7 + 2] << 16) | (byte_4[num7 + 1] << 8) | byte_4[num7]);
			}
			uint num12 = num4;
			num4 = 0u;
			uint num13 = 541087275u;
			uint num14 = 433825123u;
			uint num15 = num12;
			uint num16 = 883990701u;
			uint num17 = 1008628113u;
			num16 = 1659101134u;
			num14 = 1205852525u;
			num15 = 38542 * num15 - 541087275;
			num16 = 874800664u;
			num14 = 1778326432u;
			num15 = 6119 * num15 + 541087275;
			if (num15 == 0)
			{
				num15--;
			}
			uint num18 = num14 / num15 + num15;
			num15 = (num14 + num14) * num18 + num14;
			num13 = 371778 * (num13 & 0x1FFF) + (num13 >> 13);
			num15 = 494986 * (num15 & 0x1FFF) - (num15 >> 13);
			num14 = 23558 * num14 - num16;
			uint num19 = ((num17 << 4) | (num17 >> 28)) ^ num14;
			uint num20 = num19 & 0xF0F0F0F;
			num19 &= 0xF0F0F0F0u;
			num17 = (num19 >> 4) | (num20 << 4);
			num15 ^= num15 << 4;
			num15 += num15;
			num15 ^= num15 << 27;
			num15 += num16;
			num15 ^= num15 >> 3;
			num15 += num17;
			num15 = (((num16 << 10) + num13) ^ num16) + num15;
			num4 = num12 + (uint)(double)num15;
			if (i == num2 - 1 && num > 0)
			{
				uint num21 = num4 ^ num6;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num10 <<= 8;
						num11 += 8;
					}
					array[num9 + k] = (byte)((num21 & num10) >> num11);
				}
			}
			else
			{
				uint num22 = num4 ^ num6;
				array[num9] = (byte)(num22 & 0xFF);
				array[num9 + 1] = (byte)((num22 & 0xFF00) >> 8);
				array[num9 + 2] = (byte)((num22 & 0xFF0000) >> 16);
				array[num9 + 3] = (byte)((num22 & 0xFF000000u) >> 24);
			}
		}
		byte_0 = array;
	}

	internal static SymmetricAlgorithm smethod_7()
	{
		SymmetricAlgorithm symmetricAlgorithm = null;
		if (smethod_6())
		{
			return new AesCryptoServiceProvider();
		}
		try
		{
			return new RijndaelManaged();
		}
		catch
		{
			try
			{
				return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
			}
			catch
			{
				return (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
			}
		}
	}

	internal static void smethod_8()
	{
		try
		{
			new MD5CryptoServiceProvider();
		}
		catch
		{
			bool_2 = true;
			return;
		}
		try
		{
			bool_2 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	internal static byte[] smethod_9(byte[] byte_2)
	{
		if (!smethod_6())
		{
			return new MD5CryptoServiceProvider().ComputeHash(byte_2);
		}
		return smethod_0(byte_2);
	}

	internal static void smethod_10(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_1, byte[] byte_2)
	{
		while (uint_1 != 0)
		{
			int num = ((uint_1 > (uint)byte_2.Length) ? byte_2.Length : ((int)uint_1));
			stream_0.Read(byte_2, 0, num);
			smethod_11(hashAlgorithm_0, byte_2, 0, num);
			uint_1 -= (uint)num;
		}
	}

	internal static void smethod_11(HashAlgorithm hashAlgorithm_0, byte[] byte_2, int int_6, int int_7)
	{
		hashAlgorithm_0.TransformBlock(byte_2, int_6, int_7, byte_2, int_6);
	}

	internal static uint smethod_12(uint uint_1, int int_6, long long_2, BinaryReader binaryReader_0)
	{
		int num = 0;
		uint num3;
		uint num4;
		while (true)
		{
			if (num < int_6)
			{
				binaryReader_0.BaseStream.Position = long_2 + (num * 40 + 8);
				uint num2 = binaryReader_0.ReadUInt32();
				num3 = binaryReader_0.ReadUInt32();
				binaryReader_0.ReadUInt32();
				num4 = binaryReader_0.ReadUInt32();
				if (num3 <= uint_1 && uint_1 < num3 + num2)
				{
					break;
				}
				num++;
				continue;
			}
			return 0u;
		}
		return num4 + uint_1 - num3;
	}

	private static void smethod_13(object object_2, int int_6)
	{
		Class79.smethod_16(0, new object[2] { object_2, int_6 }, null);
	}

	internal static string smethod_14(int int_6)
	{
		if (byte_0.Length == 0)
		{
			list_0 = new List<string>();
			list_1 = new List<int>();
			smethod_13(assembly_0.GetManifestResourceStream("PA2iNsH3lphr1No6Cl.KrCx4hSs0A2VhYW5j0"), int_6);
		}
		if (int_0 < 75)
		{
			MethodBase method = new StackFrame(1).GetMethod();
			if (assembly_0 != method.DeclaringType.Assembly)
			{
				bool flag = false;
				string name = method.DeclaringType.Assembly.GetName().Name;
				AssemblyName[] referencedAssemblies = assembly_0.GetReferencedAssemblies();
				foreach (AssemblyName assemblyName in referencedAssemblies)
				{
					if (name == assemblyName.Name)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					throw new Exception();
				}
			}
			int_0++;
		}
		lock (object_0)
		{
			int num = BitConverter.ToInt32(byte_0, int_6);
			if (num < list_1.Count && list_1[num] == int_6)
			{
				return list_0[num];
			}
			try
			{
				byte[] array = new byte[num];
				Array.Copy(byte_0, int_6 + 4, array, 0, num);
				string text = Encoding.Unicode.GetString(array, 0, array.Length);
				list_0.Add(text);
				list_1.Add(int_6);
				Array.Copy(BitConverter.GetBytes(list_0.Count - 1), 0, byte_0, int_6, 4);
				return text;
			}
			catch
			{
			}
		}
		return "";
	}

	internal static string smethod_15(string string_1)
	{
		"u5pNVEp6z3OcAkaKBw5GPa".Trim();
		byte[] array = Convert.FromBase64String(string_1);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	internal static uint smethod_16(IntPtr intptr_4, IntPtr intptr_5, IntPtr intptr_6, uint uint_1, IntPtr intptr_7, ref uint uint_2)
	{
		IntPtr ptr = intptr_6;
		if (bool_4)
		{
			ptr = intptr_5;
		}
		long num = 0L;
		num = ((IntPtr.Size != 4) ? Marshal.ReadInt64(ptr, IntPtr.Size * 2) : Marshal.ReadInt32(ptr, IntPtr.Size * 2));
		object obj = hashtable_0[num];
		if (obj != null)
		{
			Struct73 @struct = (Struct73)obj;
			IntPtr intPtr = Marshal.AllocCoTaskMem(@struct.byte_0.Length);
			Marshal.Copy(@struct.byte_0, 0, intPtr, @struct.byte_0.Length);
			if (@struct.bool_0)
			{
				intptr_7 = intPtr;
				uint_2 = (uint)@struct.byte_0.Length;
				smethod_25(intptr_7, @struct.byte_0.Length, 64, ref int_5);
				return 0u;
			}
			Marshal.WriteIntPtr(ptr, IntPtr.Size * 2, intPtr);
			Marshal.WriteInt32(ptr, IntPtr.Size * 3, @struct.byte_0.Length);
			uint result = 0u;
			if (uint_1 == 216669565 && !bool_3)
			{
				bool_3 = true;
			}
			else
			{
				result = delegate8_0(intptr_4, intptr_5, intptr_6, uint_1, intptr_7, ref uint_2);
				Marshal.WriteIntPtr(ptr, IntPtr.Size * 2, IntPtr.Zero);
			}
			return result;
		}
		return delegate8_0(intptr_4, intptr_5, intptr_6, uint_1, intptr_7, ref uint_2);
	}

	private static int smethod_17()
	{
		return 5;
	}

	private static void smethod_18()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	private static Delegate smethod_19(IntPtr intptr_4, Type type_0)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[2]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[2] { intptr_4, type_0 });
	}

	internal unsafe static void smethod_20()
	{
		if (bool_6)
		{
			return;
		}
		bool_6 = true;
		long num = 0L;
		Marshal.ReadIntPtr(new IntPtr(&num), 0);
		Marshal.ReadInt32(new IntPtr(&num), 0);
		Marshal.ReadInt64(new IntPtr(&num), 0);
		Marshal.WriteIntPtr(new IntPtr(&num), 0, IntPtr.Zero);
		Marshal.WriteInt32(new IntPtr(&num), 0, 0);
		Marshal.WriteInt64(new IntPtr(&num), 0, 0L);
		Marshal.Copy(new byte[1], 0, Marshal.AllocCoTaskMem(8), 1);
		smethod_18();
		if (IntPtr.Size == 4 && Type.GetType("System.Reflection.ReflectionContext", throwOnError: false) != null)
		{
			foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
			{
				if (module.ModuleName.ToLower() == "clrjit.dll")
				{
					Version version = new Version(module.FileVersionInfo.ProductMajorPart, module.FileVersionInfo.ProductMinorPart, module.FileVersionInfo.ProductBuildPart, module.FileVersionInfo.ProductPrivatePart);
					Version version2 = new Version(4, 0, 30319, 17020);
					Version version3 = new Version(4, 0, 30319, 17921);
					if (version >= version2 && version < version3)
					{
						bool_4 = true;
						break;
					}
				}
			}
		}
		Class75 @class = new Class75(assembly_0.GetManifestResourceStream("yEoUnl5K4XI1suQ9du.pOYrUEGJPSQNUMJKvd"));
		@class.method_0().Position = 0L;
		byte[] array = @class.method_1((int)@class.method_0().Length);
		byte[] array2 = new byte[32];
		array2[0] = 150;
		array2[0] = 98;
		array2[0] = 113;
		array2[0] = 101;
		array2[0] = 169;
		array2[0] = 95;
		array2[1] = 38;
		array2[1] = 84;
		array2[1] = 98;
		array2[2] = 94;
		array2[2] = 149;
		array2[2] = 43;
		array2[2] = 11;
		array2[3] = 119;
		array2[3] = 39;
		array2[3] = 103;
		array2[3] = 162;
		array2[3] = 150;
		array2[4] = 82;
		array2[4] = 39;
		array2[4] = 108;
		array2[4] = 107;
		array2[4] = 164;
		array2[5] = 106;
		array2[5] = 158;
		array2[5] = 107;
		array2[5] = 216;
		array2[6] = 55;
		array2[6] = 110;
		array2[6] = 130;
		array2[6] = 158;
		array2[6] = 94;
		array2[7] = 28;
		array2[7] = 116;
		array2[7] = 160;
		array2[7] = 131;
		array2[7] = 191;
		array2[7] = 220;
		array2[8] = 134;
		array2[8] = 105;
		array2[8] = 125;
		array2[8] = 24;
		array2[9] = 86;
		array2[9] = 69;
		array2[9] = 164;
		array2[10] = 153;
		array2[10] = 94;
		array2[10] = 29;
		array2[10] = 134;
		array2[10] = 90;
		array2[10] = 157;
		array2[11] = 162;
		array2[11] = 155;
		array2[11] = 216;
		array2[12] = 89;
		array2[12] = 166;
		array2[12] = 149;
		array2[12] = 188;
		array2[13] = 125;
		array2[13] = 159;
		array2[13] = 113;
		array2[13] = 160;
		array2[13] = 106;
		array2[13] = 242;
		array2[14] = 73;
		array2[14] = 134;
		array2[14] = 132;
		array2[14] = 161;
		array2[14] = 146;
		array2[15] = 132;
		array2[15] = 54;
		array2[15] = 150;
		array2[15] = 174;
		array2[16] = 132;
		array2[16] = 222;
		array2[16] = 108;
		array2[16] = 51;
		array2[17] = 164;
		array2[17] = 147;
		array2[17] = 125;
		array2[17] = 118;
		array2[17] = 183;
		array2[18] = 211;
		array2[18] = 165;
		array2[18] = 74;
		array2[18] = 138;
		array2[18] = 163;
		array2[18] = 73;
		array2[19] = 49;
		array2[19] = 110;
		array2[19] = 109;
		array2[19] = 94;
		array2[19] = 120;
		array2[19] = 166;
		array2[20] = 89;
		array2[20] = 105;
		array2[20] = 147;
		array2[20] = 119;
		array2[20] = 79;
		array2[20] = 20;
		array2[21] = 132;
		array2[21] = 226;
		array2[21] = 148;
		array2[21] = 73;
		array2[21] = 144;
		array2[21] = 21;
		array2[22] = 143;
		array2[22] = 86;
		array2[22] = 203;
		array2[23] = 165;
		array2[23] = 100;
		array2[23] = 100;
		array2[23] = 143;
		array2[23] = 165;
		array2[23] = 185;
		array2[24] = 140;
		array2[24] = 83;
		array2[24] = 16;
		array2[25] = 90;
		array2[25] = 87;
		array2[25] = 244;
		array2[26] = 93;
		array2[26] = 167;
		array2[26] = 117;
		array2[26] = 121;
		array2[26] = 169;
		array2[26] = 130;
		array2[27] = 79;
		array2[27] = 117;
		array2[27] = 181;
		array2[27] = 59;
		array2[27] = 245;
		array2[28] = 209;
		array2[28] = 140;
		array2[28] = 81;
		array2[29] = 104;
		array2[29] = 109;
		array2[29] = 138;
		array2[29] = 152;
		array2[29] = 8;
		array2[30] = 103;
		array2[30] = 134;
		array2[30] = 103;
		array2[30] = 132;
		array2[30] = 93;
		array2[30] = 90;
		array2[31] = 102;
		array2[31] = 159;
		array2[31] = 116;
		array2[31] = 87;
		array2[31] = 165;
		array2[31] = 104;
		byte[] array3 = array2;
		byte[] array4 = new byte[16];
		array4[0] = 69;
		array4[0] = 117;
		array4[0] = 137;
		array4[1] = 125;
		array4[1] = 169;
		array4[1] = 225;
		array4[2] = 57;
		array4[2] = 97;
		array4[2] = 174;
		array4[2] = 167;
		array4[2] = 93;
		array4[3] = 145;
		array4[3] = 104;
		array4[3] = 88;
		array4[3] = 162;
		array4[3] = 239;
		array4[4] = 84;
		array4[4] = 152;
		array4[4] = 90;
		array4[4] = 156;
		array4[5] = 105;
		array4[5] = 139;
		array4[5] = 129;
		array4[5] = 141;
		array4[5] = 121;
		array4[6] = 156;
		array4[6] = 151;
		array4[6] = 162;
		array4[6] = 109;
		array4[6] = 228;
		array4[7] = 164;
		array4[7] = 130;
		array4[7] = 86;
		array4[8] = 21;
		array4[8] = 141;
		array4[8] = 195;
		array4[8] = 150;
		array4[8] = 216;
		array4[9] = 144;
		array4[9] = 127;
		array4[9] = 122;
		array4[9] = 174;
		array4[9] = 249;
		array4[10] = 116;
		array4[10] = 112;
		array4[10] = 96;
		array4[11] = 194;
		array4[11] = 143;
		array4[11] = 162;
		array4[11] = 169;
		array4[11] = 84;
		array4[11] = 198;
		array4[12] = 99;
		array4[12] = 106;
		array4[12] = 110;
		array4[12] = 158;
		array4[12] = 56;
		array4[12] = 164;
		array4[13] = 152;
		array4[13] = 134;
		array4[13] = 197;
		array4[13] = 92;
		array4[13] = 124;
		array4[13] = 212;
		array4[14] = 150;
		array4[14] = 144;
		array4[14] = 158;
		array4[14] = 129;
		array4[14] = 2;
		array4[15] = 134;
		array4[15] = 142;
		array4[15] = 237;
		byte[] array5 = array4;
		Array.Reverse((Array)array5);
		byte[] publicKeyToken = assembly_0.GetName().GetPublicKeyToken();
		int num2;
		if (publicKeyToken != null)
		{
			if (publicKeyToken.Length != 0)
			{
				array5[1] = publicKeyToken[0];
				array5[3] = publicKeyToken[1];
				array5[5] = publicKeyToken[2];
				array5[7] = publicKeyToken[3];
				array5[9] = publicKeyToken[4];
				array5[11] = publicKeyToken[5];
				array5[13] = publicKeyToken[6];
				array5[15] = publicKeyToken[7];
				Array.Clear(publicKeyToken, 0, publicKeyToken.Length);
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
		}
		else
		{
			num2 = 0;
		}
		for (int i = num2; i < array5.Length; i++)
		{
			array3[i] ^= array5[i];
		}
		byte[] array6 = array;
		int num3 = array6.Length % 4;
		int num4 = array6.Length / 4;
		byte[] array7 = new byte[array6.Length];
		int num5 = array3.Length / 4;
		uint num6 = 0u;
		uint num7 = 0u;
		uint num8 = 0u;
		int num9;
		if (num3 <= 0)
		{
			num9 = 0;
		}
		else
		{
			num4++;
			num9 = 0;
		}
		uint num10 = (uint)num9;
		for (int j = 0; j < num4; j++)
		{
			int num11 = j % num5;
			int num12 = j * 4;
			num10 = (uint)(num11 * 4);
			num7 = (uint)((array3[num10 + 3] << 24) | (array3[num10 + 2] << 16) | (array3[num10 + 1] << 8) | array3[num10]);
			uint num13 = 255u;
			int num14 = 0;
			if (j == num4 - 1 && num3 > 0)
			{
				num6 += num7;
				num8 = 0u;
				for (int k = 0; k < num3; k++)
				{
					if (k > 0)
					{
						num8 <<= 8;
					}
					num8 |= array6[^(1 + k)];
				}
			}
			else
			{
				num10 = (uint)num12;
				num6 += num7;
				num8 = (uint)((array6[num10 + 3] << 24) | (array6[num10 + 2] << 16) | (array6[num10 + 1] << 8) | array6[num10]);
			}
			num6 = num6;
			uint num15 = num6;
			uint num16 = num6;
			uint num17 = 541087275u;
			uint num18 = 433825123u;
			uint num19 = num16;
			uint num20 = 883990701u;
			uint num21 = 1008628113u;
			num20 = 1659101134u;
			num18 = 1205852525u;
			num19 = 38542 * num19 - 541087275;
			num20 = 874800664u;
			num18 = 1778326432u;
			num19 = 6119 * num19 + 541087275;
			if (num19 == 0)
			{
				num19--;
			}
			uint num22 = num18 / num19 + num19;
			num19 = (num18 + num18) * num22 + num18;
			num17 = 371778 * (num17 & 0x1FFF) + (num17 >> 13);
			num19 = 494986 * (num19 & 0x1FFF) - (num19 >> 13);
			num18 = 23558 * num18 - num20;
			uint num23 = ((num21 << 4) | (num21 >> 28)) ^ num18;
			uint num24 = num23 & 0xF0F0F0F;
			num23 &= 0xF0F0F0F0u;
			num21 = (num23 >> 4) | (num24 << 4);
			num19 ^= num19 << 4;
			num19 += num19;
			num19 ^= num19 << 27;
			num19 += num20;
			num19 ^= num19 >> 3;
			num19 += num21;
			num19 = (((num20 << 10) + num17) ^ num20) + num19;
			num6 = num15 + (uint)(double)num19;
			if (j == num4 - 1 && num3 > 0)
			{
				uint num25 = num6 ^ num8;
				for (int l = 0; l < num3; l++)
				{
					if (l > 0)
					{
						num13 <<= 8;
						num14 += 8;
					}
					array7[num12 + l] = (byte)((num25 & num13) >> num14);
				}
			}
			else
			{
				uint num26 = num6 ^ num8;
				array7[num12] = (byte)(num26 & 0xFF);
				array7[num12 + 1] = (byte)((num26 & 0xFF00) >> 8);
				array7[num12 + 2] = (byte)((num26 & 0xFF0000) >> 16);
				array7[num12 + 3] = (byte)((num26 & 0xFF000000u) >> 24);
			}
		}
		byte[] array8 = array7;
		int num27 = array8.Length / 8;
		byte[] array9 = array8;
		fixed (byte[] array10 = array9)
		{
			byte* ptr;
			int num28;
			if (array9 != null && array10.Length != 0)
			{
				ptr = (byte*)Unsafe.AsPointer(ref array10[0]);
				num28 = 0;
			}
			else
			{
				ptr = null;
				num28 = 0;
			}
			for (int m = num28; m < num27; m++)
			{
				*(long*)(ptr + m * 8) ^= 1254230196L;
			}
		}
		@class = new Class75(new MemoryStream(array8));
		@class.method_0().Position = 0L;
		long num29 = Marshal.GetHINSTANCE(assembly_0.GetModules()[0]).ToInt64();
		int int_ = 0;
		int num30 = 0;
		if (assembly_0.Location == null || assembly_0.Location.Length == 0)
		{
			num30 = 7680;
		}
		@class.method_3();
		@class.method_3();
		@class.method_3();
		@class.method_3();
		int num31 = @class.method_3();
		int num32 = @class.method_3();
		if (num32 == 4)
		{
			SymmetricAlgorithm symmetricAlgorithm = smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
			Array.Clear(array3, 0, array3.Length);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			array8 = memoryStream.ToArray();
			Array.Clear(array5, 0, array5.Length);
			memoryStream.Close();
			cryptoStream.Close();
			@class.method_4();
			num31 = @class.method_3();
			num32 = @class.method_3();
		}
		if (num32 == 1)
		{
			IntPtr zero = IntPtr.Zero;
			zero = smethod_26(56u, 1, (uint)Process.GetCurrentProcess().Id);
			if (IntPtr.Size == 4)
			{
				Class72.int_2 = Marshal.GetHINSTANCE(assembly_0.GetModules()[0]).ToInt32();
			}
			long_1 = Marshal.GetHINSTANCE(assembly_0.GetModules()[0]).ToInt64();
			IntPtr intptr_ = IntPtr.Zero;
			for (int n = 0; n < num31; n++)
			{
				IntPtr intPtr = new IntPtr(long_1 + @class.method_3() - num30);
				if (smethod_25(intPtr, 4, 4, ref int_) == 0)
				{
					smethod_25(intPtr, 4, 8, ref int_);
				}
				if (IntPtr.Size == 4)
				{
					smethod_24(zero, intPtr, BitConverter.GetBytes(@class.method_3()), 4u, out intptr_);
				}
				else
				{
					smethod_24(zero, intPtr, BitConverter.GetBytes(@class.method_3()), 4u, out intptr_);
				}
				smethod_25(intPtr, 4, int_, ref int_);
			}
			while (@class.method_0().Position < @class.method_0().Length - 1L)
			{
				int num33 = @class.method_3();
				IntPtr intptr_2 = new IntPtr(long_1 + num33 - num30);
				int num34 = @class.method_3();
				int num35;
				if (smethod_25(intptr_2, num34 * 4, 4, ref int_) != 0)
				{
					num35 = 0;
				}
				else
				{
					smethod_25(intptr_2, num34 * 4, 8, ref int_);
					num35 = 0;
				}
				for (int num36 = num35; num36 < num34; num36++)
				{
					Marshal.WriteInt32(new IntPtr(intptr_2.ToInt64() + num36 * 4), @class.method_3());
				}
				smethod_25(intptr_2, num34 * 4, int_, ref int_);
			}
			smethod_27(zero);
			return;
		}
		for (int num37 = 0; num37 < num31; num37++)
		{
			IntPtr intPtr2 = new IntPtr(num29 + @class.method_3() - num30);
			if (smethod_25(intPtr2, 4, 4, ref int_) == 0)
			{
				smethod_25(intPtr2, 4, 8, ref int_);
			}
			Marshal.WriteInt32(intPtr2, @class.method_3());
			smethod_25(intPtr2, 4, int_, ref int_);
		}
		hashtable_0 = new Hashtable(@class.method_3() + 1);
		Struct73 @struct = new Struct73
		{
			byte_0 = new byte[1] { 42 },
			bool_0 = false
		};
		hashtable_0.Add(0L, @struct);
		bool flag = false;
		while (@class.method_0().Position < @class.method_0().Length - 1L)
		{
			int num38 = @class.method_3() - num30;
			int num39 = @class.method_3();
			flag = false;
			if (num39 >= 1879048192)
			{
				flag = true;
			}
			int num40 = @class.method_3();
			byte[] array11 = @class.method_1(num40);
			Struct73 struct2 = new Struct73
			{
				byte_0 = array11,
				bool_0 = flag
			};
			hashtable_0.Add(num29 + num38, struct2);
		}
		long_0 = Marshal.GetHINSTANCE(typeof(Class72).Assembly.GetModules()[0]).ToInt64();
		int num41;
		if (IntPtr.Size == 4)
		{
			int_3 = Convert.ToInt32(long_0);
			num41 = 12;
		}
		else
		{
			num41 = 12;
		}
		byte[] array12 = new byte[num41];
		array12[0] = 109;
		array12[1] = 115;
		array12[2] = 99;
		array12[3] = 111;
		array12[4] = 114;
		array12[5] = 106;
		array12[6] = 105;
		array12[7] = 116;
		array12[8] = 46;
		array12[9] = 100;
		array12[10] = 108;
		array12[11] = 108;
		string text = Encoding.UTF8.GetString(array12);
		IntPtr intPtr3 = IntPtr.Zero;
		int num42;
		if (!(intPtr3 == IntPtr.Zero))
		{
			num42 = 6;
		}
		else
		{
			array12 = new byte[10] { 99, 108, 114, 106, 105, 116, 46, 100, 108, 108 };
			text = Encoding.UTF8.GetString(array12);
			intPtr3 = LoadLibrary(text);
			num42 = 6;
		}
		byte[] array13 = new byte[num42];
		array13[0] = 103;
		array13[1] = 101;
		array13[2] = 116;
		array13[3] = 74;
		array13[4] = 105;
		array13[5] = 116;
		string string_ = Encoding.UTF8.GetString(array13);
		IntPtr ptr2 = ((Delegate9)smethod_19(GetProcAddress(intPtr3, string_), typeof(Delegate9)))();
		long num43 = 0L;
		num43 = ((IntPtr.Size != 4) ? Marshal.ReadInt64(ptr2) : Marshal.ReadInt32(ptr2));
		Marshal.ReadIntPtr(ptr2, 0);
		delegate8_1 = smethod_16;
		IntPtr zero2 = IntPtr.Zero;
		zero2 = Marshal.GetFunctionPointerForDelegate((Delegate)delegate8_1);
		long num44 = 0L;
		num44 = ((IntPtr.Size != 4) ? Marshal.ReadInt64(new IntPtr(num43)) : Marshal.ReadInt32(new IntPtr(num43)));
		Process currentProcess = Process.GetCurrentProcess();
		try
		{
			foreach (ProcessModule module2 in currentProcess.Modules)
			{
				if (module2.ModuleName == text && (num44 < module2.BaseAddress.ToInt64() || num44 > module2.BaseAddress.ToInt64() + module2.ModuleMemorySize) && typeof(Class72).Assembly.EntryPoint != null)
				{
					return;
				}
			}
		}
		catch
		{
		}
		try
		{
			foreach (ProcessModule module3 in currentProcess.Modules)
			{
				if (module3.BaseAddress.ToInt64() == long_0)
				{
					num30 = 0;
					break;
				}
			}
		}
		catch
		{
		}
		delegate8_0 = null;
		try
		{
			delegate8_0 = (Delegate8)smethod_19(new IntPtr(num44), typeof(Delegate8));
		}
		catch
		{
			try
			{
				Delegate obj4 = smethod_19(new IntPtr(num44), typeof(Delegate8));
				delegate8_0 = (Delegate8)Delegate.CreateDelegate(typeof(Delegate8), obj4.Method);
			}
			catch
			{
			}
		}
		int int_2 = 0;
		if (typeof(Class72).Assembly.EntryPoint != null && typeof(Class72).Assembly.EntryPoint.GetParameters().Length == 2 && typeof(Class72).Assembly.Location != null && typeof(Class72).Assembly.Location.Length > 0)
		{
			return;
		}
		try
		{
			object value = typeof(Class72).Assembly.ManifestModule.ModuleHandle.GetType().GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(typeof(Class72).Assembly.ManifestModule.ModuleHandle);
			if (value is IntPtr)
			{
				intptr_1 = (IntPtr)value;
			}
			if (value.GetType().ToString() == "System.Reflection.RuntimeModule")
			{
				intptr_1 = (IntPtr)value.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(value);
			}
			MemoryStream memoryStream2 = new MemoryStream();
			memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
			if (IntPtr.Size == 4)
			{
				memoryStream2.Write(BitConverter.GetBytes(intptr_1.ToInt32()), 0, 4);
			}
			else
			{
				memoryStream2.Write(BitConverter.GetBytes(intptr_1.ToInt64()), 0, 8);
			}
			memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
			memoryStream2.Write(new byte[IntPtr.Size], 0, IntPtr.Size);
			memoryStream2.Position = 0L;
			byte[] array14 = memoryStream2.ToArray();
			memoryStream2.Close();
			uint nativeSizeOfCode = 0u;
			try
			{
				fixed (byte* value2 = array14)
				{
					delegate8_1(new IntPtr(value2), new IntPtr(value2), new IntPtr(value2), 216669565u, new IntPtr(value2), ref nativeSizeOfCode);
				}
			}
			finally
			{
				array10 = null;
			}
		}
		catch
		{
		}
		RuntimeHelpers.PrepareDelegate(delegate8_0);
		RuntimeHelpers.PrepareMethod(delegate8_0.Method.MethodHandle);
		RuntimeHelpers.PrepareDelegate(delegate8_1);
		RuntimeHelpers.PrepareMethod(delegate8_1.Method.MethodHandle);
		byte[] array15 = null;
		array15 = ((IntPtr.Size == 4) ? new byte[30]
		{
			85, 139, 236, 139, 69, 16, 129, 120, 4, 125,
			29, 234, 12, 116, 7, 184, 182, 177, 74, 6,
			235, 5, 184, 182, 146, 64, 12, 93, 255, 224
		} : new byte[40]
		{
			72, 184, 0, 0, 0, 0, 0, 0, 0, 0,
			73, 57, 64, 8, 116, 12, 72, 184, 0, 0,
			0, 0, 0, 0, 0, 0, 255, 224, 72, 184,
			0, 0, 0, 0, 0, 0, 0, 0, 255, 224
		});
		IntPtr intPtr4 = smethod_23(IntPtr.Zero, (uint)array15.Length, 4096u, 64u);
		byte[] array16 = array15;
		byte[] array17 = null;
		byte[] array18 = null;
		byte[] array19 = null;
		if (IntPtr.Size == 4)
		{
			array19 = BitConverter.GetBytes(intptr_1.ToInt32());
			array17 = BitConverter.GetBytes(zero2.ToInt32());
			array18 = BitConverter.GetBytes(Convert.ToInt32(num44));
		}
		else
		{
			array19 = BitConverter.GetBytes(intptr_1.ToInt64());
			array17 = BitConverter.GetBytes(zero2.ToInt64());
			array18 = BitConverter.GetBytes(num44);
		}
		if (IntPtr.Size == 4)
		{
			array16[9] = array19[0];
			array16[10] = array19[1];
			array16[11] = array19[2];
			array16[12] = array19[3];
			array16[16] = array18[0];
			array16[17] = array18[1];
			array16[18] = array18[2];
			array16[19] = array18[3];
			array16[23] = array17[0];
			array16[24] = array17[1];
			array16[25] = array17[2];
			array16[26] = array17[3];
		}
		else
		{
			array16[2] = array19[0];
			array16[3] = array19[1];
			array16[4] = array19[2];
			array16[5] = array19[3];
			array16[6] = array19[4];
			array16[7] = array19[5];
			array16[8] = array19[6];
			array16[9] = array19[7];
			array16[18] = array18[0];
			array16[19] = array18[1];
			array16[20] = array18[2];
			array16[21] = array18[3];
			array16[22] = array18[4];
			array16[23] = array18[5];
			array16[24] = array18[6];
			array16[25] = array18[7];
			array16[30] = array17[0];
			array16[31] = array17[1];
			array16[32] = array17[2];
			array16[33] = array17[3];
			array16[34] = array17[4];
			array16[35] = array17[5];
			array16[36] = array17[6];
			array16[37] = array17[7];
		}
		Marshal.Copy(array16, 0, intPtr4, array16.Length);
		bool_0 = false;
		smethod_25(new IntPtr(num43), IntPtr.Size, 64, ref int_2);
		Marshal.WriteIntPtr(new IntPtr(num43), intPtr4);
		smethod_25(new IntPtr(num43), IntPtr.Size, int_2, ref int_2);
	}

	internal static object smethod_21(Assembly assembly_1)
	{
		try
		{
			if (File.Exists(assembly_1.Location))
			{
				return assembly_1.Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return assembly_1.GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
				.ToString()))
			{
				return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0])
					.ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	[DllImport("kernel32")]
	public static extern IntPtr LoadLibrary(string string_1);

	[DllImport("kernel32", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_4, string string_1);

	private static IntPtr smethod_22(IntPtr intptr_4, string string_1, uint uint_1)
	{
		if (delegate10_0 == null)
		{
			delegate10_0 = (Delegate10)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_28(), "Find ".Trim() + "ResourceA"), typeof(Delegate10));
		}
		return delegate10_0(intptr_4, string_1, uint_1);
	}

	private static IntPtr smethod_23(IntPtr intptr_4, uint uint_1, uint uint_2, uint uint_3)
	{
		if (delegate11_0 == null)
		{
			delegate11_0 = (Delegate11)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_28(), "Virtual ".Trim() + "Alloc"), typeof(Delegate11));
		}
		return delegate11_0(intptr_4, uint_1, uint_2, uint_3);
	}

	private static int smethod_24(IntPtr intptr_4, IntPtr intptr_5, [In][Out] byte[] byte_2, uint uint_1, out IntPtr intptr_6)
	{
		if (delegate12_0 == null)
		{
			delegate12_0 = (Delegate12)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_28(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Delegate12));
		}
		return delegate12_0(intptr_4, intptr_5, byte_2, uint_1, out intptr_6);
	}

	private static int smethod_25(IntPtr intptr_4, int int_6, int int_7, ref int int_8)
	{
		if (delegate13_0 == null)
		{
			delegate13_0 = (Delegate13)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_28(), "Virtual ".Trim() + "Protect"), typeof(Delegate13));
		}
		return delegate13_0(intptr_4, int_6, int_7, ref int_8);
	}

	private static IntPtr smethod_26(uint uint_1, int int_6, uint uint_2)
	{
		if (delegate14_0 == null)
		{
			delegate14_0 = (Delegate14)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_28(), "Open ".Trim() + "Process"), typeof(Delegate14));
		}
		return delegate14_0(uint_1, int_6, uint_2);
	}

	private static int smethod_27(IntPtr intptr_4)
	{
		if (delegate15_0 == null)
		{
			delegate15_0 = (Delegate15)Marshal.GetDelegateForFunctionPointer(GetProcAddress(smethod_28(), "Close ".Trim() + "Handle"), typeof(Delegate15));
		}
		return delegate15_0(intptr_4);
	}

	[SpecialName]
	private static IntPtr smethod_28()
	{
		if (intptr_2 == IntPtr.Zero)
		{
			intptr_2 = LoadLibrary("kernel ".Trim() + "32.dll");
		}
		return intptr_2;
	}

	private static byte[] smethod_29(string string_1)
	{
		using FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read);
		int num = 0;
		int num2 = (int)fileStream.Length;
		byte[] array = new byte[num2];
		while (num2 > 0)
		{
			int num3 = fileStream.Read(array, num, num2);
			num += num3;
			num2 -= num3;
		}
		return array;
	}

	internal static byte[] smethod_30(Stream stream_0)
	{
		return ((MemoryStream)stream_0).ToArray();
	}

	private static byte[] smethod_31(byte[] byte_2)
	{
		Stream stream = new MemoryStream();
		SymmetricAlgorithm symmetricAlgorithm = smethod_7();
		symmetricAlgorithm.Key = new byte[32]
		{
			58, 51, 247, 233, 3, 226, 41, 43, 61, 23,
			7, 174, 11, 24, 26, 141, 16, 159, 157, 72,
			182, 182, 162, 164, 244, 168, 111, 25, 243, 149,
			201, 128
		};
		symmetricAlgorithm.IV = new byte[16]
		{
			123, 133, 38, 50, 33, 145, 110, 183, 222, 7,
			146, 213, 218, 170, 149, 43
		};
		CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_2, 0, byte_2.Length);
		cryptoStream.Close();
		return smethod_30(stream);
	}

	private byte[] method_2()
	{
		return null;
	}

	private byte[] method_3()
	{
		return null;
	}

	private byte[] method_4()
	{
		return null;
	}

	private byte[] method_5()
	{
		return null;
	}

	private byte[] method_6()
	{
		return null;
	}

	private byte[] method_7()
	{
		return null;
	}

	internal byte[] method_8()
	{
		_ = "gzercaSSTZO2r7PivXKNaj".Length;
		return new byte[2] { 1, 2 };
	}

	internal byte[] CwbpIqebp()
	{
		_ = "VK7QLwKAa5zQgfmVqIqNSn".Length;
		return new byte[2] { 1, 2 };
	}

	internal byte[] method_9()
	{
		return null;
	}

	internal byte[] method_10()
	{
		return null;
	}

	internal static object smethod_32(Class75 class75_0)
	{
		return class75_0.method_0();
	}

	internal static void smethod_33(Stream stream_0, long long_2)
	{
		stream_0.Position = long_2;
	}

	internal static long smethod_34(Stream stream_0)
	{
		return stream_0.Length;
	}

	internal static object smethod_35(Class75 class75_0, int int_6)
	{
		return class75_0.method_1(int_6);
	}

	internal static void smethod_36(Class75 class75_0)
	{
		class75_0.method_4();
	}

	internal static void smethod_37(Array array_0)
	{
		Array.Reverse(array_0);
	}

	internal static object smethod_38(Assembly assembly_1)
	{
		return assembly_1.GetName();
	}

	internal static object smethod_39(AssemblyName assemblyName_0)
	{
		return assemblyName_0.GetPublicKeyToken();
	}

	internal static object smethod_40()
	{
		return smethod_7();
	}

	internal static void smethod_41(SymmetricAlgorithm symmetricAlgorithm_0, CipherMode cipherMode_0)
	{
		symmetricAlgorithm_0.Mode = cipherMode_0;
	}

	internal static object smethod_42(SymmetricAlgorithm symmetricAlgorithm_0, byte[] byte_2, byte[] byte_3)
	{
		return symmetricAlgorithm_0.CreateDecryptor(byte_2, byte_3);
	}

	internal static object smethod_43()
	{
		return new MemoryStream();
	}

	internal static void smethod_44(Stream stream_0, byte[] byte_2, int int_6, int int_7)
	{
		stream_0.Write(byte_2, int_6, int_7);
	}

	internal static void smethod_45(CryptoStream cryptoStream_0)
	{
		cryptoStream_0.FlushFinalBlock();
	}

	internal static object smethod_46(Stream stream_0)
	{
		return smethod_30(stream_0);
	}

	internal static void smethod_47(Stream stream_0)
	{
		stream_0.Close();
	}

	internal static object smethod_48(Assembly assembly_1)
	{
		return assembly_1.EntryPoint;
	}

	internal static bool smethod_49(MethodInfo methodInfo_0, MethodInfo methodInfo_1)
	{
		return methodInfo_0 == methodInfo_1;
	}

	internal static bool smethod_50()
	{
		return (object)null == null;
	}

	internal static object smethod_51()
	{
		return null;
	}

	internal static bool smethod_52()
	{
		return (object)null == null;
	}

	internal static object smethod_53()
	{
		return null;
	}

	static int smethod_54()
	{
		return 1;
	}

	internal static bool smethod_55()
	{
		return (object)null == null;
	}

	internal static object smethod_56()
	{
		return null;
	}
}
