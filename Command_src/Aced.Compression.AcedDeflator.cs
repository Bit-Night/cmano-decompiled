using System;
using System.Runtime.CompilerServices;

namespace Aced.Compression;

public sealed class AcedDeflator
{
	private static AcedDeflator acedDeflator_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int DgyyAzmckeV;

	private int int_9;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private unsafe int* pInt_0;

	private unsafe int* pInt_1;

	private unsafe int* pInt_2;

	private unsafe int* pInt_3;

	private unsafe int* pInt_4;

	private unsafe int* pInt_5;

	private unsafe int* pInt_6;

	private unsafe int* pInt_7;

	private int[] int_20;

	private int[] int_21;

	private int[] int_22;

	private int[] int_23;

	private int[] int_24;

	private int[] int_25;

	private int int_26;

	private int int_27;

	private int int_28;

	private uint[] uint_0;

	private object[] object_0;

	private int int_29;

	private uint uint_1;

	private unsafe byte* pByte_0;

	private unsafe byte* pByte_1;

	private int int_30;

	private int int_31;

	private int int_32;

	private int int_33;

	private unsafe int* pInt_8;

	private unsafe int* pInt_9;

	private unsafe int* pInt_10;

	private unsafe int* pInt_11;

	private int[] int_34;

	private int[] int_35;

	private int[] int_36;

	private int[] int_37;

	private int int_38;

	private int int_39;

	private int int_40;

	private int int_41;

	private unsafe int* pInt_12;

	private unsafe int* pInt_13;

	private unsafe int* pInt_14;

	private unsafe int* pInt_15;

	private unsafe int* pInt_16;

	private unsafe int* pInt_17;

	private unsafe int* pInt_18;

	private unsafe int* pInt_19;

	private unsafe int* pInt_20;

	private unsafe int* pInt_21;

	private unsafe int* pInt_22;

	private unsafe int* pInt_23;

	private unsafe int* pInt_24;

	private int[] int_42;

	private int[] int_43;

	private int[] int_44;

	private int[] int_45;

	private int[] int_46;

	private int[] int_47;

	private int[] int_48;

	private int[] int_49;

	private int[] int_50;

	private int[] int_51;

	private int[] int_52;

	private int[] int_53;

	private int[] int_54;

	private int[] int_55;

	private unsafe int* pInt_25;

	private unsafe int* pInt_26;

	private unsafe int* pInt_27;

	private unsafe int* pInt_28;

	private unsafe int* pInt_29;

	private bool bool_0;

	private bool bool_1;

	private static byte[] byte_0;

	public static AcedDeflator Instance
	{
		get
		{
			if (acedDeflator_0 != null)
			{
				return acedDeflator_0;
			}
			acedDeflator_0 = new AcedDeflator();
			return acedDeflator_0;
		}
	}

	public AcedDeflator()
	{
		int_22 = new int[321];
		int_23 = new int[640];
		int_24 = new int[640];
		int_25 = new int[15];
		int_34 = new int[8192];
		int_35 = new int[8192];
		int_36 = new int[8192];
		int_37 = new int[8192];
		int_42 = new int[15];
		int_43 = new int[640];
		int_44 = new int[640];
		int_45 = new int[320];
		int_46 = new int[320];
		int_47 = new int[15];
		int_48 = new int[128];
		int_49 = new int[128];
		int_50 = new int[64];
		int_51 = new int[64];
		int_52 = new int[8];
		int_53 = new int[40];
		int_54 = new int[40];
		int_55 = new int[20];
		int_20 = new int[262144];
		int_21 = new int[262144];
	}

	private void method_0()
	{
		if (object_0 != null)
		{
			int num = (int_26 >> 17) - 1;
			int num2 = object_0.Length;
			if (num == num2)
			{
				object[] destinationArray = new object[num2 * 2];
				Array.Copy(object_0, 0, destinationArray, 0, num2);
				object_0 = destinationArray;
			}
			object_0[num] = uint_0;
		}
		else
		{
			object_0 = new object[16];
			object_0[0] = uint_0;
		}
		uint_0 = new uint[32768];
		int_28 = 0;
	}

	private unsafe bool method_1(int int_56)
	{
		if (int_29 == 0)
		{
			int_26 += 4;
			if (int_26 > int_27)
			{
				return false;
			}
			if (!bool_0)
			{
				if (!bool_1)
				{
					*(uint*)pByte_1 = uint_1;
					pByte_1 += 4;
				}
			}
			else
			{
				if (int_28 == 32768)
				{
					method_0();
				}
				uint_0[int_28] = uint_1;
				int_28++;
			}
			uint_1 = (uint)int_56;
			int_29 = 31;
			return true;
		}
		uint_1 |= (uint)(int_56 << 32 - int_29);
		int_29--;
		return true;
	}

	private unsafe bool method_2(int int_56, uint uint_2)
	{
		int num = int_29;
		if (num < int_56)
		{
			if (num != 0)
			{
				uint_1 |= uint_2 << 32 - num;
				uint_2 >>= num;
			}
			int_26 += 4;
			if (int_26 <= int_27)
			{
				if (!bool_0)
				{
					if (!bool_1)
					{
						*(uint*)pByte_1 = uint_1;
						pByte_1 += 4;
					}
				}
				else
				{
					if (int_28 == 32768)
					{
						method_0();
					}
					uint_0[int_28] = uint_1;
					int_28++;
				}
				uint_1 = uint_2;
				int_29 = 32 + num - int_56;
				return true;
			}
			return false;
		}
		uint_1 |= uint_2 << 32 - num;
		int_29 = num - int_56;
		return true;
	}

	private unsafe void method_3(int int_56)
	{
		int* ptr = pInt_2 + 1;
		int* ptr2 = pInt_3;
		int_13 = 0;
		int_12 = -1;
		int num = 0;
		while (num < int_56)
		{
			if (*ptr2 == 0)
			{
				pInt_4[num] = 0;
			}
			else
			{
				*ptr = num;
				int_12 = num;
				pInt_5[num] = 0;
				int_13++;
				ptr++;
			}
			num++;
			ptr2++;
		}
		if (int_13 > 1)
		{
			return;
		}
		if (int_13 > 0)
		{
			if (int_12 != 0)
			{
				num = 0;
			}
			else
			{
				num = 1;
				int_12 = 1;
			}
			*ptr = num;
			pInt_3[num] = 1;
			pInt_5[num] = 0;
		}
		else
		{
			int_12 = 1;
			*ptr = 0;
			ptr[1] = 1;
			*pInt_3 = 1;
			pInt_3[1] = 1;
			*pInt_5 = 0;
			pInt_5[1] = 0;
		}
		int_13 = 2;
	}

	private unsafe void method_4(int int_56, int int_57)
	{
		int* ptr = pInt_2;
		int* ptr2 = pInt_3;
		int num;
		do
		{
			num = int_56;
			int num2 = int_57;
			int num3 = ptr2[ptr[int_56 + int_57 >> 1]];
			while (true)
			{
				if (ptr2[ptr[num]] < num3)
				{
					num++;
					continue;
				}
				while (num3 < ptr2[ptr[num2]])
				{
					num2--;
				}
				if (num <= num2)
				{
					int num4 = ptr[num];
					ptr[num] = ptr[num2];
					ptr[num2] = num4;
					num++;
					num2--;
				}
				if (num > num2)
				{
					break;
				}
			}
			if (int_56 < num2)
			{
				method_4(int_56, num2);
			}
			int_56 = num;
		}
		while (num < int_57);
	}

	private unsafe void method_5()
	{
		int* ptr = pInt_2;
		int num = ptr[1];
		int num2 = pInt_3[num];
		int num3 = 1;
		for (int num4 = 2; num4 <= int_13; num4 <<= 1)
		{
			int num5 = ptr[num4];
			int num6 = pInt_3[num5];
			if (num4 < int_13)
			{
				int num7 = ptr[num4 + 1];
				int num8 = pInt_3[num7];
				if (num8 < num6 || (num8 == num6 && pInt_5[num7] <= pInt_5[num5]))
				{
					num4++;
					num5 = num7;
					num6 = num8;
				}
			}
			if (num2 < num6 || (num2 == num6 && pInt_5[num] <= pInt_5[num5]))
			{
				break;
			}
			ptr[num3] = ptr[num4];
			num3 = num4;
		}
		ptr[num3] = num;
	}

	private unsafe int method_6(int int_56)
	{
		int num = 0;
		int* ptr = pInt_2 + 1;
		int* ptr2 = pInt_6;
		do
		{
			int num2 = *ptr;
			*ptr = pInt_2[int_13];
			int_13--;
			method_5();
			int num3 = *ptr;
			*ptr2 = num2;
			ptr2[1] = num3;
			num += 2;
			ptr2 += 2;
			pInt_4[num2] = (pInt_4[num3] = int_56);
			pInt_3[int_56] = pInt_3[num2] + pInt_3[num3];
			num2 = pInt_5[num2];
			num3 = pInt_5[num3];
			pInt_5[int_56] = ((num2 > num3) ? num2 : num3) + 1;
			*ptr = int_56;
			int_56++;
			method_5();
		}
		while (int_13 > 1);
		pInt_4[*ptr] = 0;
		return num;
	}

	private unsafe int method_7()
	{
		pInt_3 = pInt_13;
		pInt_4 = pInt_14;
		method_3(320);
		method_4(1, int_13);
		int num = method_6(320);
		AcedUtils.Fill(0, pInt_12, 15);
		int num2 = 0;
		int num3 = 0;
		int* ptr = pInt_6 + num;
		do
		{
			ptr--;
			int num4 = *ptr;
			int num5 = pInt_14[pInt_14[num4]] + 1;
			if (num5 > 14)
			{
				num5 = 14;
				num2++;
			}
			pInt_14[num4] = num5;
			if (num4 < 320)
			{
				num3 += num5 * pInt_13[num4];
				pInt_12[num5]++;
			}
			num--;
		}
		while (num > 0);
		if (num2 != 0)
		{
			int num6 = 13;
			while (true)
			{
				num = num6;
				while (pInt_12[num] == 0)
				{
					num--;
				}
				pInt_12[num]--;
				pInt_12[num + 1] += 2;
				pInt_12[14]--;
				num2 -= 2;
				if (num2 <= 0)
				{
					break;
				}
				num6 = 13;
			}
			num2 = 14;
			do
			{
				int num4 = pInt_12[num2];
				while (num4 != 0)
				{
					int num5 = *ptr;
					ptr++;
					if (num5 < 320)
					{
						num3 += (num2 - pInt_14[num5]) * pInt_13[num5];
						pInt_14[num5] = num2;
						num4--;
					}
				}
				num2--;
			}
			while (num2 != 0);
			return num3;
		}
		return num3;
	}

	private unsafe int method_8()
	{
		pInt_3 = pInt_18;
		pInt_4 = pInt_19;
		method_3(64);
		method_4(1, int_13);
		int num = method_6(64);
		AcedUtils.Fill(0, pInt_17, 15);
		int num2 = 0;
		int num3 = 0;
		int* ptr = pInt_6 + num;
		do
		{
			ptr--;
			int num4 = *ptr;
			int num5 = pInt_19[pInt_19[num4]] + 1;
			if (num5 > 14)
			{
				num5 = 14;
				num2++;
			}
			pInt_19[num4] = num5;
			if (num4 < 64)
			{
				num3 += num5 * pInt_18[num4];
				pInt_17[num5]++;
			}
			num--;
		}
		while (num > 0);
		if (num2 == 0)
		{
			return num3;
		}
		int num6 = 13;
		while (true)
		{
			num = num6;
			while (pInt_17[num] == 0)
			{
				num--;
			}
			pInt_17[num]--;
			pInt_17[num + 1] += 2;
			pInt_17[14]--;
			num2 -= 2;
			if (num2 <= 0)
			{
				break;
			}
			num6 = 13;
		}
		num2 = 14;
		do
		{
			int num4 = pInt_17[num2];
			while (num4 != 0)
			{
				int num5 = *ptr;
				ptr++;
				if (num5 < 64)
				{
					num3 += (num2 - pInt_19[num5]) * pInt_18[num5];
					pInt_19[num5] = num2;
					num4--;
				}
			}
			num2--;
		}
		while (num2 != 0);
		return num3;
	}

	private unsafe int IwtyAoscFoD()
	{
		int* ptr = pInt_14;
		int* ptr2 = pInt_15;
		int_38 = 0;
		int num = 0;
		int i = 0;
		int value;
		if (int_12 <= 255)
		{
			int_40 = 257;
			int_12 = 256;
			value = 0;
		}
		else
		{
			int_40 = int_12 + 1;
			value = 0;
		}
		AcedUtils.Fill(value, pInt_16, int_40);
		int num2 = 0;
		do
		{
			int num3 = *ptr;
			ptr++;
			if (num3 != num || num3 != *ptr)
			{
				num = (*ptr2 = num3);
				i++;
			}
			else
			{
				int num4 = ((i + 144 <= int_12) ? (i + 144) : int_40);
				int num5 = i;
				i += 2;
				ptr++;
				for (; i < num4; i++)
				{
					if (num3 != *ptr)
					{
						break;
					}
					ptr++;
				}
				num5 = i - num5;
				if (num5 == 2)
				{
					*ptr2 = 15;
				}
				else if (num5 >= 5)
				{
					if (num5 < 9)
					{
						*ptr2 = 17;
						pInt_16[int_38] = num5 - 5;
						num2 += 2;
					}
					else if (num5 < 17)
					{
						*ptr2 = 18;
						pInt_16[int_38] = num5 - 9;
						num2 += 3;
					}
					else
					{
						*ptr2 = 19;
						pInt_16[int_38] = num5 - 17;
						num2 += 7;
					}
				}
				else
				{
					*ptr2 = 16;
					pInt_16[int_38] = num5 - 3;
					num2++;
				}
			}
			int_38++;
			ptr2++;
		}
		while (i < int_12);
		if (i == int_12)
		{
			*ptr2 = *ptr;
			int_38++;
		}
		return num2;
	}

	private unsafe int method_9()
	{
		int* ptr = pInt_19;
		int* ptr2 = pInt_20;
		int_39 = 0;
		int num = 0;
		int i = 0;
		int_41 = int_12 + 1;
		AcedUtils.Fill(0, pInt_21, int_41);
		int num2 = 0;
		do
		{
			int num3 = *ptr;
			ptr++;
			if (num3 != num || num3 != *ptr)
			{
				num = (*ptr2 = num3);
				i++;
			}
			else
			{
				int num4 = i;
				i += 2;
				ptr++;
				for (; i < int_41; i++)
				{
					if (num3 != *ptr)
					{
						break;
					}
					ptr++;
				}
				num4 = i - num4;
				if (num4 == 2)
				{
					*ptr2 = 15;
				}
				else if (num4 >= 5)
				{
					if (num4 < 9)
					{
						*ptr2 = 17;
						pInt_21[int_39] = num4 - 5;
						num2 += 2;
					}
					else if (num4 < 17)
					{
						*ptr2 = 18;
						pInt_21[int_39] = num4 - 9;
						num2 += 3;
					}
					else
					{
						*ptr2 = 19;
						pInt_21[int_39] = num4 - 17;
						num2 += 7;
					}
				}
				else
				{
					*ptr2 = 16;
					pInt_21[int_39] = num4 - 3;
					num2++;
				}
			}
			int_39++;
			ptr2++;
		}
		while (i < int_12);
		if (i == int_12)
		{
			*ptr2 = *ptr;
			int_39++;
		}
		return num2;
	}

	private unsafe void method_10()
	{
		int* ptr = pInt_23;
		AcedUtils.Fill(0, ptr, 20);
		int* ptr2 = pInt_15;
		int i;
		for (i = 7; i < int_38; i += 8)
		{
			ptr[*ptr2]++;
			ptr[ptr2[1]]++;
			ptr[ptr2[2]]++;
			ptr[ptr2[3]]++;
			ptr[ptr2[4]]++;
			ptr[ptr2[5]]++;
			ptr[ptr2[6]]++;
			ptr[ptr2[7]]++;
			ptr2 += 8;
		}
		for (i -= 7; i < int_38; i++)
		{
			ptr[*ptr2]++;
			ptr2++;
		}
		ptr2 = pInt_20;
		for (i = 7; i < int_39; i += 8)
		{
			ptr[*ptr2]++;
			ptr[ptr2[1]]++;
			ptr[ptr2[2]]++;
			ptr[ptr2[3]]++;
			ptr[ptr2[4]]++;
			ptr[ptr2[5]]++;
			ptr[ptr2[6]]++;
			ptr[ptr2[7]]++;
			ptr2 += 8;
		}
		for (i -= 7; i < int_39; i++)
		{
			ptr[*ptr2]++;
			ptr2++;
		}
	}

	private unsafe int method_11()
	{
		pInt_3 = pInt_23;
		pInt_4 = pInt_24;
		method_3(20);
		method_4(1, int_13);
		int num = method_6(20);
		AcedUtils.Fill(0, pInt_22, 8);
		int num2 = 0;
		int num3 = 0;
		int* ptr = pInt_6 + num;
		do
		{
			ptr--;
			int num4 = *ptr;
			int num5 = pInt_24[pInt_24[num4]] + 1;
			if (num5 > 7)
			{
				num5 = 7;
				num2++;
			}
			pInt_24[num4] = num5;
			if (num4 < 20)
			{
				num3 += num5 * pInt_23[num4];
				pInt_22[num5]++;
			}
			num--;
		}
		while (num > 0);
		if (num2 == 0)
		{
			return num3;
		}
		do
		{
			num = 6;
			while (pInt_22[num] == 0)
			{
				num--;
			}
			pInt_22[num]--;
			pInt_22[num + 1] += 2;
			pInt_22[7]--;
			num2 -= 2;
		}
		while (num2 > 0);
		num2 = 7;
		do
		{
			int num4 = pInt_22[num2];
			while (num4 != 0)
			{
				int num5 = *ptr;
				ptr++;
				if (num5 < 20)
				{
					num3 += (num2 - pInt_24[num5]) * pInt_23[num5];
					pInt_24[num5] = num2;
					num4--;
				}
			}
			num2--;
		}
		while (num2 != 0);
		return num3;
	}

	private unsafe bool method_12(uint uint_2, int int_56, int int_57)
	{
		if (method_1(0))
		{
			int num = int_29;
			while (true)
			{
				if (num < 8)
				{
					if (num != 0)
					{
						uint_1 |= uint_2 << 32 - num;
						uint_2 >>= num;
					}
					int_26 += 4;
					if (int_26 > int_27)
					{
						break;
					}
					if (bool_0)
					{
						if (int_28 == 32768)
						{
							method_0();
						}
						uint_0[int_28] = uint_1;
						int_28++;
					}
					else if (!bool_1)
					{
						*(uint*)pByte_1 = uint_1;
						pByte_1 += 4;
					}
					uint_1 = uint_2;
					num += 24;
				}
				else
				{
					uint_1 |= uint_2 << 32 - num;
					num -= 8;
				}
				if (int_56 < int_57)
				{
					uint_2 = pByte_0[int_56];
					int_56++;
					continue;
				}
				int_29 = num;
				return true;
			}
			return false;
		}
		return false;
	}

	private unsafe bool method_13()
	{
		int num = 0;
		while (true)
		{
			if (num < int_33)
			{
				int num2 = pInt_8[num];
				if (!method_2(pInt_14[num2], (uint)pInt_13[num2]))
				{
					break;
				}
				if (num2 >= 256)
				{
					num2 -= 272;
					if (num2 >= 0 && !method_2(pInt_25[num2], (uint)(pInt_9[num] - pInt_26[num2])))
					{
						return false;
					}
					num2 = pInt_10[num];
					int num3 = pInt_19[num2];
					if (num2 < 5)
					{
						if (!method_2(num3, (uint)pInt_18[num2]))
						{
							return false;
						}
					}
					else if (!method_2(num3 + pInt_27[num2], (uint)(pInt_18[num2] | (pInt_11[num] << num3))))
					{
						return false;
					}
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private unsafe void method_14()
	{
		int* ptr = pInt_7;
		ptr[1] = 0;
		int num = (ptr[2] = pInt_22[1] << 1);
		ptr += 3;
		int* ptr2 = pInt_22 + 2;
		for (int num2 = 5; num2 > 0; num2--)
		{
			num = (*ptr = num + *ptr2 << 1);
			ptr2++;
			ptr++;
		}
		ptr = pInt_7;
		int* ptr3 = pInt_23;
		ptr2 = pInt_24;
		for (int num2 = 20; num2 > 0; num2--)
		{
			num = *ptr2;
			if (num != 0)
			{
				int num3 = ptr[num];
				*ptr3 = (int)AcedUtils.ReverseBits((uint)num3, num);
				ptr[num] = num3 + 1;
			}
			ptr2++;
			ptr3++;
		}
		ptr = pInt_7;
		ptr[1] = 0;
		num = (ptr[2] = pInt_12[1] << 1);
		ptr += 3;
		ptr2 = pInt_12 + 2;
		for (int num2 = 12; num2 > 0; num2--)
		{
			num = (*ptr = num + *ptr2 << 1);
			ptr2++;
			ptr++;
		}
		ptr = pInt_7;
		ptr3 = pInt_13;
		ptr2 = pInt_14;
		for (int num2 = 320; num2 > 0; num2--)
		{
			num = *ptr2;
			if (num != 0)
			{
				int num3 = ptr[num];
				*ptr3 = (int)AcedUtils.ReverseBits((uint)num3, num);
				ptr[num] = num3 + 1;
			}
			ptr2++;
			ptr3++;
		}
		ptr = pInt_7;
		ptr[1] = 0;
		num = (ptr[2] = pInt_17[1] << 1);
		ptr += 3;
		ptr2 = pInt_17 + 2;
		for (int num2 = 12; num2 > 0; num2--)
		{
			num = (*ptr = num + *ptr2 << 1);
			ptr2++;
			ptr++;
		}
		ptr = pInt_7;
		ptr3 = pInt_18;
		ptr2 = pInt_19;
		for (int num2 = 64; num2 > 0; num2--)
		{
			num = *ptr2;
			if (num != 0)
			{
				int num3 = ptr[num];
				*ptr3 = (int)AcedUtils.ReverseBits((uint)num3, num);
				ptr[num] = num3 + 1;
			}
			ptr2++;
			ptr3++;
		}
	}

	private unsafe bool method_15()
	{
		method_14();
		if (method_1(1))
		{
			int num = 0;
			while (true)
			{
				if (num < 20)
				{
					if (!method_2(3, (uint)pInt_24[num]))
					{
						break;
					}
					num++;
					continue;
				}
				if (!method_2(6, (uint)(int_40 - 257)))
				{
					return false;
				}
				for (num = 0; num < int_38; num++)
				{
					int num2 = pInt_15[num];
					int num3 = pInt_24[num2];
					if (!method_2(num3 + pInt_29[num2], (uint)(pInt_23[num2] | (pInt_16[num] << num3))))
					{
						return false;
					}
				}
				if (method_2(6, (uint)(int_41 - 1)))
				{
					for (num = 0; num < int_39; num++)
					{
						int num2 = pInt_20[num];
						int num3 = pInt_24[num2];
						if (!method_2(num3 + pInt_29[num2], (uint)(pInt_23[num2] | (pInt_21[num] << num3))))
						{
							return false;
						}
					}
					return method_13();
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private unsafe bool method_16()
	{
		int num = 16;
		num = 16 + method_7();
		num += IwtyAoscFoD();
		num += method_8();
		num += method_9();
		method_10();
		num += method_11() + 60;
		num += int_30;
		int num2 = int_32 - int_31;
		int value;
		if (num2 <= 8447 && (num2 << 3) + 10 <= num)
		{
			if (!method_12((num2 >= 8192) ? ((uint)(num2 - 8192)) : 0u, int_31, int_32))
			{
				return false;
			}
			int_14 = int_17;
			int_15 = int_18;
			int_16 = int_19;
			value = 0;
		}
		else
		{
			if (!method_15())
			{
				return false;
			}
			int_17 = int_14;
			int_18 = int_15;
			int_19 = int_16;
			value = 0;
		}
		AcedUtils.Fill(value, pInt_13, 320);
		AcedUtils.Fill(0, pInt_18, 64);
		int_30 = 0;
		int_31 = int_32;
		int_33 = 0;
		return true;
	}

	private int method_17(int int_56)
	{
		if (int_56 < 19)
		{
			return int_56 + 253;
		}
		if (int_56 < 115)
		{
			if (int_56 >= 51)
			{
				int_30 += 2;
				return (int_56 - 51 >> 2) + 288;
			}
			int_30++;
			return (int_56 - 19 >> 1) + 272;
		}
		if (int_56 < 243)
		{
			if (int_56 >= 179)
			{
				int_30 += 4;
				return (int_56 - 179 >> 4) + 312;
			}
			int_30 += 3;
			return (int_56 - 115 >> 3) + 304;
		}
		if (int_56 >= 371)
		{
			if (int_56 >= 627)
			{
				int_30 += 14;
				return 319;
			}
			int_30 += 8;
			return 318;
		}
		int_30 += 6;
		return (int_56 - 243 >> 6) + 316;
	}

	private int SplitDistance(int distance)
	{
		if (distance >= 3)
		{
			if (distance == int_14)
			{
				return 0;
			}
			if (distance == int_15)
			{
				int_15 = int_14;
				int_14 = distance;
				return 1;
			}
			if (distance == int_16)
			{
				int_16 = int_14;
				int_14 = distance;
				return 2;
			}
			int_16 = int_15;
			int_15 = int_14;
			int_14 = distance;
			if (distance < 1025)
			{
				if (distance >= 65)
				{
					if (distance < 257)
					{
						if (distance < 129)
						{
							return (distance - 65 >> 4) + 20;
						}
						return (distance - 129 >> 5) + 24;
					}
					if (distance >= 513)
					{
						return (distance - 513 >> 7) + 32;
					}
					return (distance - 257 >> 6) + 28;
				}
				if (distance >= 17)
				{
					if (distance >= 33)
					{
						return (distance - 33 >> 3) + 16;
					}
					return (distance - 17 >> 2) + 12;
				}
				return (distance - 3 >> 1) + 5;
			}
			if (distance >= 16385)
			{
				if (distance >= 65537)
				{
					if (distance < 131073)
					{
						return (distance - 65537 >> 15) + 58;
					}
					if (distance >= 262145)
					{
						return (distance - 262145 >> 17) + 62;
					}
					return (distance - 131073 >> 16) + 60;
				}
				if (distance >= 32769)
				{
					return (distance - 32769 >> 14) + 56;
				}
				return (distance - 16385 >> 12) + 52;
			}
			if (distance < 4097)
			{
				if (distance < 2049)
				{
					return (distance - 1025 >> 8) + 36;
				}
				return (distance - 2049 >> 9) + 40;
			}
			if (distance >= 8193)
			{
				return (distance - 8193 >> 11) + 48;
			}
			return (distance - 4097 >> 10) + 44;
		}
		return distance + 2;
	}

	private unsafe bool method_18(int int_56)
	{
		if (int_33 == 8192 && !method_16())
		{
			return false;
		}
		pInt_13[int_56]++;
		pInt_8[int_33] = int_56;
		int_33++;
		return true;
	}

	private unsafe bool method_19()
	{
		if (int_33 == 8192 && !method_16())
		{
			return false;
		}
		int num = int_33;
		int num2 = method_17(int_1);
		pInt_13[num2]++;
		pInt_8[num] = num2;
		pInt_9[num] = int_1;
		num2 = SplitDistance(int_2);
		if (num2 >= 5)
		{
			pInt_11[num] = int_2 - pInt_28[num2];
			int_30 += pInt_27[num2];
		}
		pInt_18[num2]++;
		pInt_10[num] = num2;
		int_33 = num + 1;
		return true;
	}

	private unsafe int method_20()
	{
		fixed (int* ptr = &int_21[0])
		{
			fixed (int* ptr2 = &int_20[0])
			{
				fixed (int* ptr3 = &int_25[0])
				{
					fixed (int* ptr4 = &int_22[0])
					{
						fixed (int* ptr5 = &int_23[0])
						{
							fixed (int* ptr6 = &int_24[0])
							{
								fixed (int* ptr7 = &int_34[0])
								{
									fixed (int* ptr8 = &int_35[0])
									{
										fixed (int* ptr9 = &int_36[0])
										{
											fixed (int* ptr10 = &int_37[0])
											{
												fixed (int* ptr11 = &int_42[0])
												{
													fixed (int* ptr12 = &int_43[0])
													{
														fixed (int* ptr13 = &int_44[0])
														{
															fixed (int* ptr14 = &int_45[0])
															{
																fixed (int* ptr15 = &int_46[0])
																{
																	fixed (int* ptr16 = &int_47[0])
																	{
																		fixed (int* ptr17 = &int_48[0])
																		{
																			fixed (int* ptr18 = &int_49[0])
																			{
																				fixed (int* ptr19 = &int_50[0])
																				{
																					fixed (int* ptr20 = &int_51[0])
																					{
																						fixed (int* ptr21 = &int_52[0])
																						{
																							fixed (int* ptr22 = &int_53[0])
																							{
																								fixed (int* ptr23 = &int_54[0])
																								{
																									fixed (int* ptr24 = &AcedConsts.CharExBitLength[0])
																									{
																										fixed (int* ptr25 = &AcedConsts.CharExBitBase[0])
																										{
																											fixed (int* ptr26 = &AcedConsts.DistExBitLength[0])
																											{
																												fixed (int* ptr27 = &AcedConsts.DistExBitBase[0])
																												{
																													fixed (int* ptr28 = &AcedConsts.ChLenExBitLength[0])
																													{
																														pInt_1 = ptr;
																														pInt_0 = ptr2;
																														pInt_7 = ptr3;
																														pInt_2 = ptr4;
																														pInt_5 = ptr5;
																														pInt_6 = ptr6;
																														pInt_8 = ptr7;
																														pInt_9 = ptr8;
																														pInt_10 = ptr9;
																														pInt_11 = ptr10;
																														pInt_12 = ptr11;
																														pInt_13 = ptr12;
																														pInt_14 = ptr13;
																														pInt_15 = ptr14;
																														pInt_16 = ptr15;
																														pInt_17 = ptr16;
																														pInt_18 = ptr17;
																														pInt_19 = ptr18;
																														pInt_20 = ptr19;
																														pInt_21 = ptr20;
																														pInt_22 = ptr21;
																														pInt_23 = ptr22;
																														pInt_24 = ptr23;
																														pInt_25 = ptr24;
																														pInt_26 = ptr25;
																														pInt_27 = ptr26;
																														pInt_28 = ptr27;
																														pInt_29 = ptr28;
																														AcedUtils.Fill(-524289, pInt_0, int_6);
																														AcedUtils.Fill(0, pInt_13, 320);
																														AcedUtils.Fill(0, pInt_18, 64);
																														int_31 = 0;
																														int_33 = 0;
																														int_30 = 0;
																														int_14 = 0;
																														int_15 = 0;
																														int_16 = 0;
																														int_17 = 0;
																														int_18 = 0;
																														int_19 = 0;
																														*pInt_1 = -524289;
																														int num = ((*pByte_0 << int_5 + int_5) ^ (pByte_0[1] << int_5) ^ pByte_0[2]) & int_7;
																														pInt_0[num] = 0;
																														int_26 = 0;
																														method_18(*pByte_0);
																														int_29 = 32;
																														uint_1 = 0u;
																														int i = 1;
																														while (i < int_10 - 2)
																														{
																															num = ((num << int_5) ^ pByte_0[i + 2]) & int_7;
																															pInt_1[i & int_4] = (int_0 = pInt_0[num]);
																															pInt_0[num] = i;
																															int_32 = i;
																															int_11 = int_8;
																															DgyyAzmckeV = i - int_3;
																															if (int_0 >= (int_9 = i - 524288) && method_21(i))
																															{
																																int num2 = i + int_1;
																																if (int_0 > DgyyAzmckeV && (int_0 = pInt_1[int_0 & int_4]) >= int_9 && num2 < int_10 && int_1 < 17010)
																																{
																																	method_22(i);
																																	num2 = i + int_1;
																																}
																																while (int_1 < 32 && num2 < int_10)
																																{
																																	i++;
																																	num = ((num << int_5) ^ pByte_0[i + 2]) & int_7;
																																	pInt_1[i & int_4] = (int_0 = pInt_0[num]);
																																	pInt_0[num] = i;
																																	int_11 = int_8;
																																	DgyyAzmckeV = i - int_3;
																																	if (int_0 < (int_9 = i - 524288) || !method_22(i))
																																	{
																																		break;
																																	}
																																	if (method_18(pByte_0[i - 1]))
																																	{
																																		num2 = i + int_1;
																																		int_32 = i;
																																		continue;
																																	}
																																	return -1;
																																}
																																if (!method_19())
																																{
																																	return -1;
																																}
																																if (num2 < int_10 - 2)
																																{
																																	i++;
																																	do
																																	{
																																		num = ((num << int_5) ^ pByte_0[i + 2]) & int_7;
																																		pInt_1[i & int_4] = (int_0 = pInt_0[num]);
																																		pInt_0[num] = i;
																																		i++;
																																	}
																																	while (i < num2);
																																}
																																else
																																{
																																	i = num2;
																																}
																															}
																															else
																															{
																																if (!method_18(pByte_0[i]))
																																{
																																	return -1;
																																}
																																i++;
																															}
																														}
																														for (; i < int_10; i++)
																														{
																															int_32 = i;
																															if (!method_18(pByte_0[i]))
																															{
																																return -1;
																															}
																														}
																														int_32 = i;
																														if (!method_23())
																														{
																															return -1;
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return int_26;
	}

	private unsafe bool method_21(int int_56)
	{
		byte* ptr = pByte_0;
		uint num = (uint)(ptr[int_56] | (ptr[int_56 + 1] << 8) | (ptr[int_56 + 2] << 16));
		int num2 = int_0;
		int num3 = int_10;
		int num4 = num3 - 8;
		int num5 = int_11;
		while (true)
		{
			if ((*(uint*)(ptr + num2) & 0xFFFFFF) == num)
			{
				int num6 = num2 + 3;
				int num7 = int_56 + 3;
				if (num7 < num3 && ptr[num6] == ptr[num7])
				{
					num6++;
					num7++;
					if (num7 < num3 && ptr[num6] == ptr[num7])
					{
						while (num7 < num4 && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7] && ptr[++num6] == ptr[++num7])
						{
						}
						if (ptr[num6] == ptr[num7])
						{
							num6++;
							for (num7++; num7 < num3 && ptr[num6] == ptr[num7]; num7++)
							{
								num6++;
							}
						}
						num7 -= int_56;
						if (num7 >= 17010)
						{
							int_1 = 17010;
						}
						else
						{
							int_1 = num7;
						}
						int_2 = int_56 - num2;
						return true;
					}
					if (int_56 - num2 <= 32768)
					{
						int_1 = 4;
						int_2 = int_56 - num2;
						return true;
					}
				}
				else if (int_56 - num2 <= 4096)
				{
					int_1 = 3;
					int_2 = int_56 - num2;
					return true;
				}
			}
			if (num2 <= DgyyAzmckeV)
			{
				break;
			}
			num2 = (int_0 = pInt_1[num2 & int_4]);
			if (num2 < int_9)
			{
				return false;
			}
			num5 = (int_11 = num5 - 1);
			if (num5 != 0)
			{
				continue;
			}
			return false;
		}
		return false;
	}

	private unsafe bool method_22(int int_56)
	{
		byte* ptr = pByte_0;
		int num = int_0;
		int num2 = int_1;
		int num3 = int_10;
		int num4 = num3 - 8;
		int num5 = int_11;
		uint num6 = *(uint*)(ptr + int_56 + num2 - 3);
		bool result = false;
		do
		{
			int i;
			int num7;
			if (*(uint*)(ptr + num + num2 - 3) == num6 && ptr[int_56] == ptr[num] && ptr[int_56 + 1] == ptr[num + 1])
			{
				num7 = num + 1;
				i = int_56 + 1;
				if (num2 <= 4)
				{
					goto IL_0194;
				}
				int num8 = num2 - 1 >> 2;
				while (*(uint*)(ptr + num7 + 1) == *(uint*)(ptr + i + 1))
				{
					num7 += 4;
					i += 4;
					num8--;
					if (num8 > 0)
					{
						continue;
					}
					goto IL_0194;
				}
			}
			goto IL_003b;
			IL_003b:
			if (num <= DgyyAzmckeV)
			{
				break;
			}
			num = pInt_1[num & int_4];
			continue;
			IL_0194:
			while (i < num4 && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i] && ptr[++num7] == ptr[++i])
			{
			}
			if (ptr[num7] == ptr[i])
			{
				num7++;
				for (i++; i < num3 && ptr[num7] == ptr[i]; i++)
				{
					num7++;
				}
			}
			num7 = i - int_56;
			int_56 -= num;
			if (num7 - num2 > 2 || (num7 - num2 == 1 && (int_56 < 1025 || smethod_0(int_56, int_2))) || (num7 - num2 == 2 && (int_56 < 32769 || smethod_1(int_56, int_2))))
			{
				num2 = (int_1 = num7);
				int_2 = int_56;
				result = true;
				if (num2 >= 17010)
				{
					int_1 = 17010;
					break;
				}
				if (i == num3)
				{
					break;
				}
				num6 = *(uint*)(ptr + i - 3);
			}
			int_56 += num;
			goto IL_003b;
		}
		while (num >= int_9 && --num5 != 0);
		return result;
	}

	private static bool smethod_0(int int_56, int int_57)
	{
		int result;
		if (int_56 >= 16385)
		{
			if (int_56 < 65537)
			{
				if (int_56 < 32769)
				{
					if (int_57 < 129)
					{
						return false;
					}
					result = 1;
				}
				else
				{
					if (int_57 < 513)
					{
						return false;
					}
					result = 1;
				}
				goto IL_0097;
			}
			if (int_56 >= 131073)
			{
				if (int_56 < 262145)
				{
					if (int_57 >= 4097)
					{
						result = 1;
						goto IL_0097;
					}
					return false;
				}
				if (int_57 < 8193)
				{
					return false;
				}
			}
			else if (int_57 < 2049)
			{
				return false;
			}
		}
		else if (int_56 >= 4097)
		{
			if (int_56 < 8193)
			{
				if (int_57 < 33)
				{
					return false;
				}
			}
			else if (int_57 < 65)
			{
				return false;
			}
		}
		else if (int_56 >= 2049)
		{
			if (int_57 < 17)
			{
				return false;
			}
		}
		else if (int_57 < 3)
		{
			return false;
		}
		result = 1;
		goto IL_0097;
		IL_0097:
		return (byte)result != 0;
	}

	private static bool smethod_1(int int_56, int int_57)
	{
		if (int_56 < 131073)
		{
			if (int_56 < 65537 && int_57 < 3)
			{
				return false;
			}
			if (int_57 < 17)
			{
				return false;
			}
		}
		int result;
		if (int_56 >= 262145)
		{
			if (int_57 < 65)
			{
				return false;
			}
			result = 1;
		}
		else
		{
			if (int_57 < 33)
			{
				return false;
			}
			result = 1;
		}
		return (byte)result != 0;
	}

	private unsafe bool method_23()
	{
		int result2;
		if (method_16())
		{
			int_26 += 4 - (int_29 >> 3);
			if (int_26 <= int_27)
			{
				int result;
				if (bool_0)
				{
					if (int_28 == 32768)
					{
						method_0();
					}
					uint_0[int_28] = uint_1;
					int_28++;
					result = 1;
				}
				else if (!bool_1)
				{
					switch (int_29 >> 3)
					{
					default:
						result = 1;
						break;
					case 0:
						*(uint*)pByte_1 = uint_1;
						result = 1;
						break;
					case 1:
						*pByte_1 = (byte)uint_1;
						pByte_1[1] = (byte)(uint_1 >> 8);
						pByte_1[2] = (byte)(uint_1 >> 16);
						result = 1;
						break;
					case 2:
						*pByte_1 = (byte)uint_1;
						pByte_1[1] = (byte)(uint_1 >> 8);
						result = 1;
						break;
					case 3:
						*pByte_1 = (byte)uint_1;
						result = 1;
						break;
					}
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			result2 = 0;
		}
		else
		{
			result2 = 0;
		}
		return (byte)result2 != 0;
	}

	public unsafe byte[] Compress(byte[] sourceBytes, int sourceIndex, int sourceLength, AcedCompressionLevel compressionLevel, int beforeGap, int afterGap)
	{
		if (sourceLength == 0)
		{
			return new byte[beforeGap + afterGap + 4];
		}
		if (sourceBytes == null)
		{
			AcedMCException.ThrowArgumentNullException("sourceBytes");
		}
		bool_0 = true;
		bool_1 = false;
		object_0 = null;
		uint_0 = new uint[32768];
		int_28 = 0;
		int_27 = sourceLength;
		int_10 = sourceLength;
		pByte_1 = null;
		byte[] array;
		int num3;
		fixed (byte* ptr = &sourceBytes[sourceIndex])
		{
			pByte_0 = ptr;
			int num = -1;
			if (sourceLength > 3 && compressionLevel != AcedCompressionLevel.Store)
			{
				method_24(compressionLevel);
				num = method_20();
			}
			if (num > 0)
			{
				array = new byte[beforeGap + 4 + num + afterGap];
				fixed (byte* ptr2 = &array[beforeGap])
				{
					*(int*)ptr2 = sourceLength;
				}
				beforeGap += 4;
				num--;
				int num2 = num >> 17;
				for (int i = 0; i < num2; i++)
				{
					Buffer.BlockCopy((uint[])object_0[i], 0, array, beforeGap, 131072);
					beforeGap += 131072;
				}
				Buffer.BlockCopy(uint_0, 0, array, beforeGap, (num & 0x1FFFF) + 1);
				object_0 = null;
				uint_0 = null;
				num3 = 0;
			}
			else
			{
				object_0 = null;
				uint_0 = null;
				array = new byte[beforeGap + 4 + sourceLength + afterGap];
				fixed (byte* ptr2 = &array[beforeGap])
				{
					*(int*)ptr2 = -sourceLength;
				}
				Buffer.BlockCopy(sourceBytes, sourceIndex, array, beforeGap + 4, sourceLength);
				num3 = 0;
			}
		}
		fixed (byte* ptr3 = &Unsafe.AsRef<byte>((byte*)(uint)num3))
		{
			return array;
		}
	}

	public unsafe int Compress(byte[] sourceBytes, int sourceIndex, int sourceLength, AcedCompressionLevel compressionLevel, byte[] destinationBytes, int destinationIndex)
	{
		bool_1 = false;
		if (destinationBytes != null)
		{
			int_27 = destinationBytes.Length - destinationIndex - 4;
		}
		else
		{
			bool_1 = true;
			destinationBytes = byte_0;
			destinationIndex = 0;
			int_27 = sourceLength;
		}
		if (sourceLength != 0)
		{
			if (sourceBytes == null)
			{
				AcedMCException.ThrowArgumentNullException("sourceBytes");
			}
			bool_0 = false;
			if (sourceLength < int_27)
			{
				int_27 = sourceLength;
			}
			int_10 = sourceLength;
			fixed (byte* ptr = &sourceBytes[sourceIndex])
			{
				fixed (byte* ptr2 = &destinationBytes[destinationIndex])
				{
					pByte_0 = ptr;
					pByte_1 = ptr2;
					int num = -1;
					if (sourceLength > 3 && compressionLevel != AcedCompressionLevel.Store)
					{
						method_24(compressionLevel);
						if (!bool_1)
						{
							if (int_27 < 0)
							{
								AcedMCException.ThrowNoPlaceToStoreCompressedDataException();
							}
							*(int*)pByte_1 = sourceLength;
							pByte_1 += 4;
						}
						num = method_20();
					}
					if (num < 0)
					{
						if (!bool_1)
						{
							if (int_27 < sourceLength)
							{
								AcedMCException.ThrowNoPlaceToStoreCompressedDataException();
							}
							*(int*)ptr2 = -sourceLength;
							Buffer.BlockCopy(sourceBytes, sourceIndex, destinationBytes, destinationIndex + 4, sourceLength);
						}
						num = sourceLength;
					}
					return num + 4;
				}
			}
		}
		int result;
		if (bool_1)
		{
			result = 4;
		}
		else
		{
			if (int_27 < 0)
			{
				AcedMCException.ThrowNoPlaceToStoreCompressedDataException();
			}
			fixed (byte* ptr3 = &destinationBytes[destinationIndex])
			{
				*(int*)ptr3 = 0;
			}
			result = 4;
		}
		return result;
	}

	private void method_24(AcedCompressionLevel acedCompressionLevel_0)
	{
		switch (acedCompressionLevel_0)
		{
		case AcedCompressionLevel.Fastest:
			int_6 = 4096;
			int_7 = 4095;
			int_3 = 8192;
			int_4 = 8191;
			int_8 = 2;
			int_5 = 4;
			break;
		case AcedCompressionLevel.Fast:
			int_6 = 32768;
			int_7 = 32767;
			int_3 = 65536;
			int_4 = 65535;
			int_8 = 8;
			int_5 = 5;
			break;
		case AcedCompressionLevel.Normal:
			int_6 = 262144;
			int_7 = 262143;
			int_3 = 262144;
			int_4 = 262143;
			int_8 = 32;
			int_5 = 6;
			break;
		case AcedCompressionLevel.Maximum:
			int_6 = 262144;
			int_7 = 262143;
			int_3 = 262144;
			int_4 = 262143;
			int_8 = 96;
			int_5 = 6;
			break;
		}
	}

	public static void Release()
	{
		acedDeflator_0 = null;
	}

	static AcedDeflator()
	{
		Class72.smethod_20();
		byte_0 = new byte[1];
	}
}
