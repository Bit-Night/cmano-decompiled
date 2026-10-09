using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;

internal class Class77
{
	private enum Enum22
	{

	}

	internal class Class78
	{
		private unsafe static uint smethod_0(void* pVoid_0, uint uint_0)
		{
			uint result = 0u;
			if (BitConverter.IsLittleEndian)
			{
				result = *(uint*)pVoid_0;
			}
			else
			{
				switch (uint_0)
				{
				case 1u:
					result = *(byte*)pVoid_0;
					break;
				case 2u:
					result = (uint)(*(byte*)pVoid_0 | (((byte*)pVoid_0)[1] << 8));
					break;
				case 3u:
					result = (uint)(*(byte*)pVoid_0 | (((byte*)pVoid_0)[1] << 8) | (((byte*)pVoid_0)[2] << 16));
					break;
				case 4u:
					result = (uint)(*(byte*)pVoid_0 | (((byte*)pVoid_0)[1] << 8) | (((byte*)pVoid_0)[2] << 16) | (((byte*)pVoid_0)[3] << 24));
					break;
				}
			}
			return result;
		}

		private unsafe static bool smethod_1(void* pVoid_0, void* pVoid_1, uint uint_0)
		{
			bool flag = true;
			uint num = 0u;
			while (flag && num < uint_0)
			{
				flag = ((byte*)pVoid_0)[num] == ((byte*)pVoid_1)[num];
				num++;
			}
			return flag;
		}

		private unsafe static void smethod_2(void* pVoid_0, byte byte_0, uint uint_0)
		{
			for (uint num = 0u; num < uint_0; num++)
			{
				((sbyte*)pVoid_0)[num] = (sbyte)byte_0;
			}
		}

		private unsafe static void smethod_3(void* pVoid_0, void* pVoid_1, uint uint_0)
		{
			for (uint num = 0u; num < uint_0; num++)
			{
				((sbyte*)pVoid_0)[num] = ((sbyte*)pVoid_1)[num];
			}
		}

		private unsafe static void smethod_4(byte* pByte_0, byte* pByte_1, uint uint_0)
		{
			if (BitConverter.IsLittleEndian)
			{
				if (uint_0 < 5)
				{
					*(int*)pByte_0 = *(int*)pByte_1;
					return;
				}
				byte* ptr = pByte_0 + uint_0;
				while (pByte_0 < ptr)
				{
					*(int*)pByte_0 = *(int*)pByte_1;
					pByte_0 += 4;
					pByte_1 += 4;
				}
			}
			else if (uint_0 > 8 && pByte_1 + uint_0 < pByte_0)
			{
				smethod_3(pByte_0, pByte_1, uint_0);
			}
			else
			{
				byte* ptr2 = pByte_0 + uint_0;
				while (pByte_0 < ptr2)
				{
					*pByte_0 = *pByte_1;
					pByte_0++;
					pByte_1++;
				}
			}
		}

		private unsafe static uint smethod_5(object object_0, uint uint_0, Enum22 enum22_0)
		{
			int result;
			fixed (byte* ptr = object_0)
			{
				result = ((int*)(ptr + uint_0))[(int)enum22_0];
			}
			return (uint)result;
		}

		private unsafe static uint smethod_6(object object_0, uint uint_0, object object_1)
		{
			fixed (byte* ptr = object_0)
			{
				fixed (byte* ptr2 = object_1)
				{
					byte* ptr3 = ptr + uint_0;
					uint num = 32u;
					byte* ptr4 = ptr3 + 32u;
					byte* ptr5 = ptr2;
					uint* ptr6 = (uint*)ptr3;
					byte* ptr7 = ptr2 + smethod_0(ptr6 + 3, 4u);
					uint num2 = 1u;
					uint[] array = new uint[16]
					{
						4u, 0u, 1u, 0u, 2u, 0u, 1u, 0u, 3u, 0u,
						1u, 0u, 2u, 0u, 1u, 0u
					};
					byte* ptr8 = ptr7 - 4;
					if (smethod_0(ptr6 + 4, 4u) != 1)
					{
						smethod_3(ptr2, ptr3 + num, smethod_0(ptr6 + 3, 4u));
						return smethod_0(ptr6 + 3, 4u);
					}
					if (ptr5 >= ptr8)
					{
						ptr4 += 4;
						while (ptr5 < ptr7)
						{
							*ptr5 = *ptr4;
							ptr5++;
							ptr4++;
						}
						return (uint)(ptr5 - ptr2);
					}
					while (true)
					{
						if (num2 == 1)
						{
							num2 = smethod_0(ptr4, 4u);
							ptr4 += 4;
						}
						uint num3 = smethod_0(ptr4, 4u);
						if ((num2 & 1) == 1)
						{
							num2 >>= 1;
							if ((num3 & 3) == 0)
							{
								uint num4 = (num3 & 0xFF) >> 2;
								smethod_4(ptr5, ptr5 - num4, 3u);
								ptr5 += 3;
								ptr4++;
							}
							else if ((num3 & 2) == 0)
							{
								uint num4 = (num3 & 0xFFFF) >> 2;
								smethod_4(ptr5, ptr5 - num4, 3u);
								ptr5 += 3;
								ptr4 += 2;
							}
							else if ((num3 & 1) == 0)
							{
								uint num4 = (num3 & 0xFFFF) >> 6;
								uint num5 = ((num3 >> 2) & 0xF) + 3;
								smethod_4(ptr5, ptr5 - num4, num5);
								ptr5 += num5;
								ptr4 += 2;
							}
							else if ((num3 & 4) == 0)
							{
								uint num4 = (num3 & 0xFFFFFF) >> 8;
								uint num5 = ((num3 >> 3) & 0x1F) + 3;
								smethod_4(ptr5, ptr5 - num4, num5);
								ptr5 += num5;
								ptr4 += 3;
							}
							else if ((num3 & 8) == 0)
							{
								uint num4 = num3 >> 15;
								uint num5 = ((num3 >> 4) & 0x7FF) + 3;
								smethod_4(ptr5, ptr5 - num4, num5);
								ptr5 += num5;
								ptr4 += 4;
							}
							else
							{
								byte byte_ = (byte)(num3 >> 16);
								uint num5 = (num3 >> 4) & 0xFFF;
								smethod_2(ptr5, byte_, num5);
								ptr5 += num5;
								ptr4 += 3;
							}
						}
						else
						{
							smethod_4(ptr5, ptr4, 4u);
							ptr5 += array[num2 & 0xF];
							ptr4 += array[num2 & 0xF];
							num2 >>= (int)(byte)array[num2 & 0xF];
							if (ptr5 >= ptr8)
							{
								break;
							}
						}
					}
					while (ptr5 < ptr7)
					{
						if (num2 == 1)
						{
							ptr4 += 4;
							num2 = 2147483648u;
						}
						*ptr5 = *ptr4;
						ptr5++;
						ptr4++;
						num2 >>= 1;
					}
					return (uint)(ptr5 - ptr2);
				}
			}
		}

		internal static object smethod_7(byte[] byte_0)
		{
			return typeof(Assembly).GetMethod("Load ".Trim(), new Type[1] { typeof(byte[]) }).Invoke(null, new object[1] { byte_0 });
		}

		public static byte[] smethod_8(byte[] byte_0, uint uint_0)
		{
			uint num = smethod_5(byte_0, uint_0, (Enum22)3);
			byte[] array = null;
			if (num != 0)
			{
				array = new byte[num];
				smethod_6(byte_0, uint_0, array);
			}
			return array;
		}

		static Class78()
		{
			Class72.smethod_20();
		}
	}

	private static string[] string_0;

	private static object object_0;

	private static bool bool_0;

	private static bool bool_1;

	private static void smethod_0()
	{
		if (bool_0)
		{
			return;
		}
		Class72.Class75 @class = new Class72.Class75(typeof(Class72).Assembly.GetManifestResourceStream("K9IevBLhjNc95jyBnV.ZtX1EByTiifiuf9Gui"));
		@class.method_0().Position = 0L;
		byte[] array = new byte[0];
		byte[] array2 = @class.method_1((int)@class.method_0().Length);
		byte[] array3 = new byte[32];
		array3[0] = 106;
		array3[0] = 163;
		array3[0] = 170;
		array3[0] = 162;
		array3[0] = 109;
		array3[0] = 125;
		array3[1] = 131;
		array3[1] = 120;
		array3[1] = 149;
		array3[1] = 107;
		array3[2] = 136;
		array3[2] = 183;
		array3[2] = 152;
		array3[2] = 86;
		array3[2] = 140;
		array3[2] = 107;
		array3[3] = 114;
		array3[3] = 90;
		array3[3] = 48;
		array3[3] = 93;
		array3[3] = 135;
		array3[3] = 235;
		array3[4] = 102;
		array3[4] = 84;
		array3[4] = 185;
		array3[5] = 98;
		array3[5] = 132;
		array3[5] = 104;
		array3[5] = 43;
		array3[6] = 90;
		array3[6] = 72;
		array3[6] = 116;
		array3[6] = 245;
		array3[7] = 164;
		array3[7] = 167;
		array3[7] = 158;
		array3[7] = 114;
		array3[7] = 59;
		array3[8] = 98;
		array3[8] = 208;
		array3[8] = 114;
		array3[8] = 109;
		array3[9] = 133;
		array3[9] = 61;
		array3[9] = 155;
		array3[9] = 26;
		array3[10] = 166;
		array3[10] = 101;
		array3[10] = 94;
		array3[10] = 43;
		array3[11] = 158;
		array3[11] = 86;
		array3[11] = 150;
		array3[11] = 139;
		array3[11] = 76;
		array3[12] = 91;
		array3[12] = 98;
		array3[12] = 204;
		array3[12] = 148;
		array3[12] = 131;
		array3[12] = 215;
		array3[13] = 128;
		array3[13] = 105;
		array3[13] = 182;
		array3[14] = 71;
		array3[14] = 69;
		array3[14] = 174;
		array3[14] = 136;
		array3[14] = 72;
		array3[15] = 162;
		array3[15] = 109;
		array3[15] = 63;
		array3[15] = 159;
		array3[15] = 24;
		array3[16] = 166;
		array3[16] = 158;
		array3[16] = 165;
		array3[16] = 23;
		array3[17] = 169;
		array3[17] = 120;
		array3[17] = 128;
		array3[17] = 109;
		array3[17] = 124;
		array3[18] = 168;
		array3[18] = 86;
		array3[18] = 116;
		array3[18] = 162;
		array3[19] = 133;
		array3[19] = 118;
		array3[19] = 114;
		array3[19] = 68;
		array3[19] = 251;
		array3[20] = 130;
		array3[20] = 122;
		array3[20] = 188;
		array3[21] = 46;
		array3[21] = 162;
		array3[21] = 146;
		array3[21] = 237;
		array3[22] = 15;
		array3[22] = 155;
		array3[22] = 70;
		array3[22] = 142;
		array3[22] = 110;
		array3[22] = 226;
		array3[23] = 101;
		array3[23] = 118;
		array3[23] = 56;
		array3[24] = 102;
		array3[24] = 113;
		array3[24] = 139;
		array3[24] = 88;
		array3[24] = 84;
		array3[24] = 177;
		array3[25] = 183;
		array3[25] = 120;
		array3[25] = 141;
		array3[25] = 152;
		array3[26] = 132;
		array3[26] = 116;
		array3[26] = 202;
		array3[27] = 77;
		array3[27] = 114;
		array3[27] = 225;
		array3[28] = 143;
		array3[28] = 188;
		array3[28] = 29;
		array3[29] = 123;
		array3[29] = 167;
		array3[29] = 175;
		array3[30] = 233;
		array3[30] = 130;
		array3[30] = 108;
		array3[30] = 132;
		array3[30] = 165;
		array3[31] = 98;
		array3[31] = 106;
		array3[31] = 86;
		array3[31] = 171;
		array3[31] = 213;
		byte[] array4 = array3;
		byte[] array5 = new byte[16];
		array5[0] = 68;
		array5[0] = 133;
		array5[0] = 87;
		array5[0] = 108;
		array5[0] = 20;
		array5[0] = 192;
		array5[1] = 176;
		array5[1] = 98;
		array5[1] = 77;
		array5[1] = 100;
		array5[1] = 143;
		array5[1] = 235;
		array5[2] = 110;
		array5[2] = 85;
		array5[2] = 144;
		array5[2] = 116;
		array5[2] = 182;
		array5[2] = 202;
		array5[3] = 107;
		array5[3] = 133;
		array5[3] = 44;
		array5[3] = 148;
		array5[4] = 169;
		array5[4] = 107;
		array5[4] = 160;
		array5[4] = 140;
		array5[4] = 184;
		array5[5] = 159;
		array5[5] = 161;
		array5[5] = 153;
		array5[6] = 55;
		array5[6] = 160;
		array5[6] = 121;
		array5[6] = 150;
		array5[6] = 180;
		array5[7] = 98;
		array5[7] = 106;
		array5[7] = 168;
		array5[7] = 191;
		array5[8] = 150;
		array5[8] = 132;
		array5[8] = 185;
		array5[9] = 126;
		array5[9] = 124;
		array5[9] = 107;
		array5[10] = 98;
		array5[10] = 146;
		array5[10] = 73;
		array5[10] = 159;
		array5[10] = 156;
		array5[10] = 93;
		array5[11] = 196;
		array5[11] = 110;
		array5[11] = 104;
		array5[11] = 62;
		array5[11] = 93;
		array5[11] = 157;
		array5[12] = 95;
		array5[12] = 226;
		array5[12] = 168;
		array5[12] = 212;
		array5[13] = 98;
		array5[13] = 180;
		array5[13] = 25;
		array5[13] = 146;
		array5[13] = 101;
		array5[13] = 140;
		array5[14] = 201;
		array5[14] = 161;
		array5[14] = 148;
		array5[14] = 81;
		array5[14] = 88;
		array5[15] = 77;
		array5[15] = 198;
		array5[15] = 155;
		array5[15] = 134;
		array5[15] = 91;
		array5[15] = 168;
		byte[] array6 = array5;
		int num = 1;
		for (int i = 0; i < array6.Length; i++)
		{
			array4[i] ^= array6[i];
		}
		byte[] array7 = array2;
		int num2 = array7.Length % 4;
		int num3 = array7.Length / 4;
		byte[] array8 = new byte[array7.Length];
		int num4 = array4.Length / 4;
		uint num5 = 0u;
		uint num6 = 0u;
		uint num7 = 0u;
		int num8;
		if (num2 > 0)
		{
			num3++;
			num8 = 0;
		}
		else
		{
			num8 = 0;
		}
		uint num9 = (uint)num8;
		for (int j = 0; j < num3; j++)
		{
			int num10 = j % num4;
			int num11 = j * 4;
			num9 = (uint)(num10 * 4);
			num6 = (uint)((array4[num9 + 3] << 24) | (array4[num9 + 2] << 16) | (array4[num9 + 1] << 8) | array4[num9]);
			uint num12 = 255u;
			int num13 = 0;
			if (j == num3 - 1 && num2 > 0)
			{
				num7 = 0u;
				num5 += num6;
				for (int k = 0; k < num2; k++)
				{
					if (k > 0)
					{
						num7 <<= 8;
					}
					num7 |= array7[^(1 + k)];
				}
			}
			else
			{
				num9 = (uint)num11;
				num5 += num6;
				num7 = (uint)((array7[num9 + 3] << 24) | (array7[num9 + 2] << 16) | (array7[num9 + 1] << 8) | array7[num9]);
			}
			uint num14 = num5;
			num5 = 255u;
			uint num15 = 541087275u;
			uint num16 = 433825123u;
			uint num17 = num14;
			uint num18 = 883990701u;
			uint num19 = 1008628113u;
			num18 = 1659101134u;
			num16 = 1205852525u;
			num17 = 38542 * num17 - 541087275;
			num18 = 874800664u;
			num16 = 1778326432u;
			num17 = 6119 * num17 + 541087275;
			if (num17 == 0)
			{
				num17--;
			}
			uint num20 = num16 / num17 + num17;
			num17 = (num16 + num16) * num20 + num16;
			num15 = 371778 * (num15 & 0x1FFF) + (num15 >> 13);
			num17 = 494986 * (num17 & 0x1FFF) - (num17 >> 13);
			num16 = 23558 * num16 - num18;
			uint num21 = ((num19 << 4) | (num19 >> 28)) ^ num16;
			uint num22 = num21 & 0xF0F0F0F;
			num21 &= 0xF0F0F0F0u;
			num19 = (num21 >> 4) | (num22 << 4);
			num17 ^= num17 << 4;
			num17 += num17;
			num17 ^= num17 << 27;
			num17 += num18;
			num17 ^= num17 >> 3;
			num17 += num19;
			num17 = (((num18 << 10) + num15) ^ num18) + num17;
			num5 = num14 + (uint)(double)num17;
			if (j == num3 - 1 && num2 > 0)
			{
				uint num23 = num5 ^ num7;
				for (int l = 0; l < num2; l++)
				{
					if (l > 0)
					{
						num12 <<= 8;
						num13 += 8;
					}
					array8[num11 + l] = (byte)((num23 & num12) >> num13);
				}
			}
			else
			{
				uint num24 = num5 ^ num7;
				array8[num11] = (byte)(num24 & 0xFF);
				array8[num11 + 1] = (byte)((num24 & 0xFF00) >> 8);
				array8[num11 + 2] = (byte)((num24 & 0xFF0000) >> 16);
				array8[num11 + 3] = (byte)((num24 & 0xFF000000u) >> 24);
			}
		}
		array = array8;
		switch (num)
		{
		default:
			object_0 = Class78.smethod_7(Class78.smethod_8(array, 0u));
			break;
		case 1:
		{
			MemoryStream memoryStream = new MemoryStream();
			using (DeflateStream deflateStream = new DeflateStream(new MemoryStream(array), CompressionMode.Decompress))
			{
				deflateStream.CopyTo(memoryStream);
			}
			object_0 = Class78.smethod_7(memoryStream.ToArray());
			memoryStream.Dispose();
			break;
		}
		case 0:
			object_0 = Class78.smethod_7(array);
			break;
		}
		string_0 = ((Assembly)object_0).GetManifestResourceNames();
		bool_0 = true;
	}

	internal static string[] smethod_1(Assembly assembly_0)
	{
		if (assembly_0 == typeof(Class77).Assembly)
		{
			if (!bool_0)
			{
				smethod_0();
			}
			List<string> list = new List<string>();
			list.AddRange(assembly_0.GetManifestResourceNames());
			list.AddRange(((Assembly)object_0).GetManifestResourceNames());
			return list.ToArray();
		}
		return assembly_0.GetManifestResourceNames();
	}

	private static Assembly smethod_2(object object_1, ResolveEventArgs resolveEventArgs_0)
	{
		if (!bool_0)
		{
			smethod_0();
		}
		string name = resolveEventArgs_0.Name;
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (string_0[num] == name)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return (Assembly)object_0;
	}

	public Class77()
	{
		AppDomain.CurrentDomain.ResourceResolve += smethod_2;
	}

	internal static void smethod_3()
	{
		if (!bool_1)
		{
			bool_1 = true;
			new Class77();
		}
	}

	static Class77()
	{
		string_0 = new string[0];
		object_0 = null;
		bool_0 = false;
		bool_1 = false;
	}

	internal static bool smethod_4()
	{
		return (object)null == null;
	}

	internal static object smethod_5()
	{
		return null;
	}
}
