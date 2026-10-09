using System;

namespace Aced.Compression;

public sealed class AcedInflator
{
	private static AcedInflator hQpyJoqTuqY;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private unsafe byte* pByte_0;

	private unsafe byte* pByte_1;

	private unsafe int* pInt_0;

	private unsafe int* pInt_1;

	private unsafe int* pInt_2;

	private unsafe int* pInt_3;

	private unsafe int* pInt_4;

	private unsafe int* pInt_5;

	private int[] int_10;

	private int[] int_11;

	private int[] int_12;

	private int[] int_13;

	private int[] int_14;

	private int[] int_15;

	private unsafe int* pInt_6;

	private unsafe int* pInt_7;

	private unsafe int* pInt_8;

	private unsafe int* pInt_9;

	public static AcedInflator Instance
	{
		get
		{
			if (hQpyJoqTuqY != null)
			{
				return hQpyJoqTuqY;
			}
			hQpyJoqTuqY = new AcedInflator();
			return hQpyJoqTuqY;
		}
	}

	public AcedInflator()
	{
		int_10 = new int[640];
		int_11 = new int[128];
		int_12 = new int[40];
		int_13 = new int[320];
		int_14 = new int[15];
		int_15 = new int[15];
	}

	private unsafe int method_0(int int_16)
	{
		int num = int_3;
		int num2 = int_4;
		while (num2 < int_16)
		{
			if (num2 < 8 && int_0 < int_1)
			{
				int_0 += 3;
				num |= (*pByte_0 | (pByte_0[1] << 8) | (pByte_0[2] << 16)) << num2;
				pByte_0 += 3;
				num2 += 24;
			}
			else if (int_0 < int_2)
			{
				int_0++;
				num |= *pByte_0 << num2;
				pByte_0++;
				num2 += 8;
			}
			else
			{
				AcedMCException.ThrowReadBeyondTheEndException();
			}
		}
		int_3 = num >> int_16;
		int_4 = num2 - int_16;
		return num & ((1 << int_16) - 1);
	}

	private unsafe int method_1()
	{
		uint num = (uint)int_3;
		int num2 = int_4;
		if (num2 == 0)
		{
			if (int_0 < int_1)
			{
				int_0 += 4;
				num = *(uint*)pByte_0;
				pByte_0 += 4;
				num2 = 31;
			}
			else if (int_0 < int_2)
			{
				int_0++;
				num = *pByte_0;
				pByte_0++;
				num2 = 7;
			}
			else
			{
				AcedMCException.ThrowReadBeyondTheEndException();
			}
		}
		else
		{
			num2--;
		}
		int_3 = (int)(num >> 1);
		int_4 = num2;
		return (int)(num & 1);
	}

	private unsafe int method_2(int* pInt_10)
	{
		int num = 1;
		int num2 = int_3;
		while (true)
		{
			if (int_4 == 0)
			{
				if (int_0 >= int_1)
				{
					if (int_0 >= int_2)
					{
						AcedMCException.ThrowReadBeyondTheEndException();
					}
					else
					{
						int_0++;
						num2 = *pByte_0;
						pByte_0++;
						num = pInt_10[num + (num2 & 1)];
						num2 >>= 1;
						int_4 = 7;
					}
				}
				else
				{
					int_0 += 4;
					num2 = *(int*)pByte_0;
					pByte_0 += 4;
					num = pInt_10[num + (num2 & 1)];
					num2 >>>= 1;
					int_4 = 31;
				}
				if (num <= 0)
				{
					break;
				}
			}
			else
			{
				num = pInt_10[num + (num2 & 1)];
				num2 >>= 1;
				int_4--;
				if (num <= 0)
				{
					break;
				}
			}
		}
		int_3 = num2;
		return -num;
	}

	private unsafe void method_3()
	{
		AcedUtils.Fill(0, pInt_4, 8);
		int num;
		for (int i = 0; i < 20; i++)
		{
			num = method_0(3);
			pInt_3[i] = num;
			pInt_4[num]++;
		}
		AcedUtils.Fill(0, pInt_2, 40);
		pInt_5[1] = 0;
		num = (pInt_5[2] = pInt_4[1] << 1);
		num = (pInt_5[3] = num + pInt_4[2] << 1);
		num = (pInt_5[4] = num + pInt_4[3] << 1);
		num = (pInt_5[5] = num + pInt_4[4] << 1);
		num = (pInt_5[6] = num + pInt_4[5] << 1);
		num = (pInt_5[7] = num + pInt_4[6] << 1);
		int num2 = 2;
		for (int i = 0; i < 20; i++)
		{
			num = pInt_3[i];
			if (num == 0)
			{
				continue;
			}
			int num3 = pInt_5[num];
			int num4 = (int)AcedUtils.ReverseBits((uint)num3, num);
			pInt_5[num] = num3 + 1;
			int num5 = 1;
			while (true)
			{
				num5 += num4 & 1;
				num4 >>= 1;
				num--;
				if (num == 0)
				{
					break;
				}
				num3 = num5;
				num5 = pInt_2[num5];
				if (num5 == 0)
				{
					num5 = num2 + 1;
					num2 = num5 + 1;
					pInt_2[num3] = num5;
				}
			}
			pInt_2[num5] = -i;
		}
	}

	private unsafe void method_4(int int_16)
	{
		int num = 0;
		int* ptr = pInt_3;
		AcedUtils.Fill(0, pInt_4, 15);
		while (int_16 > 0)
		{
			int num2 = method_2(pInt_2);
			if (num2 < 15)
			{
				*ptr = num2;
				pInt_4[num2]++;
				ptr++;
				num = num2;
				int_16--;
				continue;
			}
			num2 = ((num2 >= 17) ? (num2 switch
			{
				17 => method_0(2) + 5, 
				18 => method_0(3) + 9, 
				_ => method_0(7) + 17, 
			}) : ((num2 != 15) ? (method_1() + 3) : 2));
			int_16 -= num2;
			pInt_4[num] += num2;
			do
			{
				num2--;
				*ptr = num;
				ptr++;
			}
			while (num2 != 0);
		}
	}

	private unsafe void method_5()
	{
		AcedUtils.Fill(0, pInt_3, 320);
		method_4(method_0(6) + 257);
		AcedUtils.Fill(0, pInt_0, 640);
		pInt_5[1] = 0;
		int num = (pInt_5[2] = pInt_4[1] << 1);
		num = (pInt_5[3] = num + pInt_4[2] << 1);
		num = (pInt_5[4] = num + pInt_4[3] << 1);
		num = (pInt_5[5] = num + pInt_4[4] << 1);
		num = (pInt_5[6] = num + pInt_4[5] << 1);
		num = (pInt_5[7] = num + pInt_4[6] << 1);
		num = (pInt_5[8] = num + pInt_4[7] << 1);
		num = (pInt_5[9] = num + pInt_4[8] << 1);
		num = (pInt_5[10] = num + pInt_4[9] << 1);
		num = (pInt_5[11] = num + pInt_4[10] << 1);
		num = (pInt_5[12] = num + pInt_4[11] << 1);
		num = (pInt_5[13] = num + pInt_4[12] << 1);
		num = (pInt_5[14] = num + pInt_4[13] << 1);
		int num2 = 2;
		for (int i = 0; i < 320; i++)
		{
			num = pInt_3[i];
			if (num == 0)
			{
				continue;
			}
			int num3 = pInt_5[num];
			int num4 = (int)AcedUtils.ReverseBits((uint)num3, num);
			pInt_5[num] = num3 + 1;
			int num5 = 1;
			while (true)
			{
				num5 += num4 & 1;
				num4 >>= 1;
				num--;
				if (num == 0)
				{
					break;
				}
				num3 = num5;
				num5 = pInt_0[num5];
				if (num5 == 0)
				{
					num5 = num2 + 1;
					num2 = num5 + 1;
					pInt_0[num3] = num5;
				}
			}
			pInt_0[num5] = -i;
		}
	}

	private unsafe void method_6()
	{
		AcedUtils.Fill(0, pInt_3, 64);
		method_4(method_0(6) + 1);
		AcedUtils.Fill(0, pInt_1, 128);
		pInt_5[1] = 0;
		int num = (pInt_5[2] = pInt_4[1] << 1);
		num = (pInt_5[3] = num + pInt_4[2] << 1);
		num = (pInt_5[4] = num + pInt_4[3] << 1);
		num = (pInt_5[5] = num + pInt_4[4] << 1);
		num = (pInt_5[6] = num + pInt_4[5] << 1);
		num = (pInt_5[7] = num + pInt_4[6] << 1);
		num = (pInt_5[8] = num + pInt_4[7] << 1);
		num = (pInt_5[9] = num + pInt_4[8] << 1);
		num = (pInt_5[10] = num + pInt_4[9] << 1);
		num = (pInt_5[11] = num + pInt_4[10] << 1);
		num = (pInt_5[12] = num + pInt_4[11] << 1);
		num = (pInt_5[13] = num + pInt_4[12] << 1);
		num = (pInt_5[14] = num + pInt_4[13] << 1);
		int num2 = 2;
		for (int i = 0; i < 64; i++)
		{
			num = pInt_3[i];
			if (num == 0)
			{
				continue;
			}
			int num3 = pInt_5[num];
			int num4 = (int)AcedUtils.ReverseBits((uint)num3, num);
			pInt_5[num] = num3 + 1;
			int num5 = 1;
			while (true)
			{
				num5 += num4 & 1;
				num4 >>= 1;
				num--;
				if (num == 0)
				{
					break;
				}
				num3 = num5;
				num5 = pInt_1[num5];
				if (num5 == 0)
				{
					num5 = num2 + 1;
					num2 = num5 + 1;
					pInt_1[num3] = num5;
				}
			}
			pInt_1[num5] = -i;
		}
	}

	private void method_7()
	{
		int_6 = 8192;
		if (method_1() == 0)
		{
			method_8();
			return;
		}
		method_3();
		method_5();
		method_6();
	}

	private unsafe void method_8()
	{
		int_6 += method_0(8);
		int num = int_4;
		while (int_6 > 0 && int_5 > 0)
		{
			int num2 = int_3;
			if (num < 8)
			{
				if (int_0 < int_1)
				{
					int_0 += 3;
					num2 |= (*pByte_0 | (pByte_0[1] << 8) | (pByte_0[2] << 16)) << num;
					pByte_0 += 3;
					num += 24;
				}
				else if (int_0 < int_2)
				{
					int_0++;
					num2 |= *pByte_0 << num;
					pByte_0++;
					num += 8;
				}
				else
				{
					AcedMCException.ThrowReadBeyondTheEndException();
				}
			}
			int_3 = num2 >> 8;
			num -= 8;
			*pByte_1 = (byte)num2;
			int_6--;
			int_5--;
			pByte_1++;
		}
		int_4 = num;
	}

	public unsafe static int GetDecompressedLength(byte[] sourceBytes, int sourceIndex)
	{
		if (sourceBytes == null)
		{
			AcedMCException.ThrowArgumentNullException("sourceBytes");
		}
		fixed (byte* ptr = &sourceBytes[sourceIndex])
		{
			int num = *(int*)ptr;
			if (num < 0)
			{
				return -num;
			}
			return num;
		}
	}

	public unsafe byte[] Decompress(byte[] sourceBytes, int sourceIndex, int beforeGap, int afterGap)
	{
		if (sourceBytes == null)
		{
			AcedMCException.ThrowArgumentNullException("sourceBytes");
		}
		int num;
		fixed (byte* ptr = &sourceBytes[sourceIndex])
		{
			num = *(int*)ptr;
		}
		if (num < 0)
		{
			num = -num;
		}
		byte[] array = new byte[num + beforeGap + afterGap];
		if (num != 0)
		{
			Decompress(sourceBytes, sourceIndex, array, beforeGap);
		}
		return array;
	}

	public unsafe int Decompress(byte[] sourceBytes, int sourceIndex, byte[] destinationBytes, int destinationIndex)
	{
		if (sourceBytes == null)
		{
			AcedMCException.ThrowArgumentNullException("sourceBytes");
		}
		if (destinationBytes != null)
		{
			fixed (byte* ptr = &sourceBytes[sourceIndex])
			{
				fixed (byte* ptr2 = &destinationBytes[destinationIndex])
				{
					pByte_0 = ptr;
					pByte_1 = ptr2;
					int num = *(int*)pByte_0;
					if (num <= 0)
					{
						num = -num;
						if (destinationBytes.Length - destinationIndex < num)
						{
							AcedMCException.ThrowNoPlaceToStoreDecompressedDataException();
						}
						if (num > 0)
						{
							Buffer.BlockCopy(sourceBytes, sourceIndex + 4, destinationBytes, destinationIndex, num);
						}
						return num;
					}
					if (destinationBytes.Length - destinationIndex < num)
					{
						AcedMCException.ThrowNoPlaceToStoreDecompressedDataException();
					}
					fixed (int* ptr3 = &int_10[0])
					{
						fixed (int* ptr4 = &int_11[0])
						{
							fixed (int* ptr5 = &int_12[0])
							{
								fixed (int* ptr6 = &int_13[0])
								{
									fixed (int* ptr7 = &int_14[0])
									{
										fixed (int* ptr8 = &int_15[0])
										{
											fixed (int* ptr9 = &AcedConsts.CharExBitLength[0])
											{
												fixed (int* ptr10 = &AcedConsts.CharExBitBase[0])
												{
													fixed (int* ptr11 = &AcedConsts.DistExBitLength[0])
													{
														fixed (int* ptr12 = &AcedConsts.DistExBitBase[0])
														{
															pInt_0 = ptr3;
															pInt_1 = ptr4;
															pInt_2 = ptr5;
															pInt_3 = ptr6;
															pInt_4 = ptr7;
															pInt_5 = ptr8;
															pInt_6 = ptr9;
															pInt_7 = ptr10;
															pInt_8 = ptr11;
															pInt_9 = ptr12;
															int_4 = 0;
															int_3 = 0;
															int_0 = sourceIndex + 4;
															pByte_0 += 4;
															int_2 = sourceBytes.Length;
															int_1 = int_2 - 3;
															int_5 = num;
															while (int_5 > 0)
															{
																method_7();
																while (int_6 > 0 && int_5 > 0)
																{
																	int num2 = method_2(pInt_0);
																	int_6--;
																	if (num2 < 256)
																	{
																		*pByte_1 = (byte)num2;
																		int_5--;
																		pByte_1++;
																	}
																	else
																	{
																		num2 -= 272;
																		int num3 = ((num2 >= 0) ? (method_0(pInt_6[num2]) + pInt_7[num2]) : (num2 + 19));
																		num2 = method_2(pInt_1);
																		int num4;
																		if (num2 >= 3)
																		{
																			num4 = pInt_9[num2];
																			if (num2 >= 5)
																			{
																				num4 += method_0(pInt_8[num2]);
																				int_9 = int_8;
																				int_8 = int_7;
																				int_7 = num4;
																			}
																		}
																		else
																		{
																			switch (num2)
																			{
																			case 0:
																				num4 = int_7;
																				break;
																			case 1:
																				num4 = int_8;
																				int_8 = int_7;
																				int_7 = num4;
																				break;
																			default:
																				num4 = int_9;
																				int_9 = int_7;
																				int_7 = num4;
																				break;
																			}
																		}
																		AcedUtils.CopyBytes(pByte_1 - num4, pByte_1, num3);
																		int_5 -= num3;
																		pByte_1 += num3;
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
					return num;
				}
			}
		}
		return GetDecompressedLength(sourceBytes, sourceIndex);
	}

	public static void Release()
	{
		hQpyJoqTuqY = null;
	}

	static AcedInflator()
	{
		Class72.smethod_20();
	}
}
