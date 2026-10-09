using System.Runtime.CompilerServices;

namespace HPCsharp;

public static class ZeroDetect
{
	public static bool ByFor(byte[] data)
	{
		int num = data.Length;
		int num2 = 0;
		while (true)
		{
			if (num2 < num)
			{
				if (data[num2] != 0)
				{
					break;
				}
				num2++;
				continue;
			}
			return true;
		}
		return false;
	}

	public static bool ByForUnrolled(byte[] data)
	{
		int num = data.Length / 16 * 16;
		int num2 = num % 128;
		int num3 = 0;
		while (true)
		{
			if (num3 < num)
			{
				if ((data[num3] | data[num3 + 1] | data[num3 + 2] | data[num3 + 3] | data[num3 + 4] | data[num3 + 5] | data[num3 + 6] | data[num3 + 7] | data[num3 + 8] | data[num3 + 9] | data[num3 + 10] | data[num3 + 11] | data[num3 + 12] | data[num3 + 13] | data[num3 + 14] | data[num3 + 15]) != 0)
				{
					break;
				}
				num3 += 16;
				continue;
			}
			for (int i = 0; i < num2; i++)
			{
				if (data[num - 1 - i] != 0)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public unsafe static bool ByFixedLongUnrolled(byte[] data)
	{
		fixed (byte[] array = data)
		{
			byte* ptr;
			int num;
			if (data != null)
			{
				if (array.Length != 0)
				{
					ptr = (byte*)Unsafe.AsPointer(ref array[0]);
					goto IL_001b;
				}
				num = 0;
			}
			else
			{
				num = 0;
			}
			ptr = (byte*)(uint)num;
			goto IL_001b;
			IL_001b:
			int num2 = data.Length;
			int num3 = num2 % 128;
			long* ptr2 = (long*)ptr;
			long* ptr3 = (long*)(ptr + num2 - num3);
			while (true)
			{
				if (ptr2 < ptr3)
				{
					if ((*ptr2 | ptr2[1] | ptr2[2] | ptr2[3] | ptr2[4] | ptr2[5] | ptr2[6] | ptr2[7] | ptr2[8] | ptr2[9] | ptr2[10] | ptr2[11] | ptr2[12] | ptr2[13] | ptr2[14] | ptr2[15]) != 0L)
					{
						break;
					}
					ptr2 += 16;
					continue;
				}
				for (int i = 0; i < num3; i++)
				{
					if (data[num2 - 1 - i] != 0)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}

	public unsafe static bool ByFixedLongUnrolled(byte[] data, int l, int r)
	{
		fixed (byte[] array = data)
		{
			byte* ptr;
			int num;
			if (data != null)
			{
				if (array.Length != 0)
				{
					ptr = (byte*)Unsafe.AsPointer(ref array[0]);
					goto IL_001b;
				}
				num = 0;
			}
			else
			{
				num = 0;
			}
			ptr = (byte*)(uint)num;
			goto IL_001b;
			IL_001b:
			int num2 = r - l + 1;
			int num3 = num2 % 128;
			long* ptr2 = (long*)(ptr + l);
			long* ptr3 = (long*)(ptr + l + num2 - num3);
			while (true)
			{
				if (ptr2 < ptr3)
				{
					if ((*ptr2 | ptr2[1] | ptr2[2] | ptr2[3] | ptr2[4] | ptr2[5] | ptr2[6] | ptr2[7] | ptr2[8] | ptr2[9] | ptr2[10] | ptr2[11] | ptr2[12] | ptr2[13] | ptr2[14] | ptr2[15]) != 0L)
					{
						break;
					}
					ptr2 += 16;
					continue;
				}
				for (int i = 0; i < num3; i++)
				{
					if (data[num2 - 1 - i] != 0)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}

	static ZeroDetect()
	{
		Class72.smethod_20();
	}
}
