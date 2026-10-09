using System;

namespace Collections.Pooled;

internal ref struct BitHelper
{
	private readonly Span<int> span_0;

	internal BitHelper(Span<int> span, bool clear)
	{
		if (clear)
		{
			span.Clear();
		}
		span_0 = span;
	}

	internal void MarkBit(int bitPosition)
	{
		int num = bitPosition / 32;
		if ((uint)num < (uint)span_0.Length)
		{
			span_0[num] |= 1 << bitPosition % 32;
		}
	}

	internal bool IsMarked(int bitPosition)
	{
		int num = bitPosition / 32;
		if ((uint)num < (uint)span_0.Length)
		{
			return (span_0[num] & (1 << bitPosition % 32)) != 0;
		}
		return false;
	}

	internal int FindFirstUnmarked(int startPosition = 0)
	{
		int num = startPosition;
		int num2 = num / 32;
		while (true)
		{
			if ((uint)num2 < (uint)span_0.Length)
			{
				if ((span_0[num2] & (1 << num % 32)) == 0)
				{
					break;
				}
				num2 = ++num / 32;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal int FindFirstMarked(int startPosition = 0)
	{
		int num = startPosition;
		int num2 = num / 32;
		while (true)
		{
			if ((uint)num2 < (uint)span_0.Length)
			{
				if ((span_0[num2] & (1 << num % 32)) != 0)
				{
					break;
				}
				num2 = ++num / 32;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal static int ToIntArrayLength(int n)
	{
		if (n > 0)
		{
			return (n - 1) / 32 + 1;
		}
		return 0;
	}

	static BitHelper()
	{
		Class72.smethod_20();
	}
}
