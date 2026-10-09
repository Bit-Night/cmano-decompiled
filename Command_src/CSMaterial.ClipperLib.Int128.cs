namespace CSMaterial.ClipperLib;

internal struct Int128
{
	private long long_0;

	private ulong ulong_0;

	public Int128(long _lo)
	{
		ulong_0 = (ulong)_lo;
		if (_lo >= 0L)
		{
			long_0 = 0L;
		}
		else
		{
			long_0 = -1L;
		}
	}

	public Int128(long _hi, ulong _lo)
	{
		ulong_0 = _lo;
		long_0 = _hi;
	}

	public Int128(Int128 val)
	{
		long_0 = val.long_0;
		ulong_0 = val.ulong_0;
	}

	public bool IsNegative()
	{
		return long_0 < 0L;
	}

	public static bool operator ==(Int128 val1, Int128 val2)
	{
		if ((object)val1 == (object)val2)
		{
			return true;
		}
		if ((object)val1 != null && (object)val2 != null)
		{
			if (val1.long_0 == val2.long_0)
			{
				return val1.ulong_0 == val2.ulong_0;
			}
			return false;
		}
		return false;
	}

	public static bool operator !=(Int128 val1, Int128 val2)
	{
		return !(val1 == val2);
	}

	public override bool Equals(object obj)
	{
		int result;
		if (obj != null)
		{
			if (obj is Int128 @int)
			{
				if (@int.long_0 == long_0)
				{
					return @int.ulong_0 == ulong_0;
				}
				return false;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public override int GetHashCode()
	{
		return long_0.GetHashCode() ^ ulong_0.GetHashCode();
	}

	public static bool operator >(Int128 val1, Int128 val2)
	{
		if (val1.long_0 != val2.long_0)
		{
			return val1.long_0 > val2.long_0;
		}
		return val1.ulong_0 > val2.ulong_0;
	}

	public static bool operator <(Int128 val1, Int128 val2)
	{
		if (val1.long_0 != val2.long_0)
		{
			return val1.long_0 < val2.long_0;
		}
		return val1.ulong_0 < val2.ulong_0;
	}

	public static Int128 operator +(Int128 lhs, Int128 rhs)
	{
		lhs.long_0 += rhs.long_0;
		lhs.ulong_0 += rhs.ulong_0;
		if (lhs.ulong_0 < rhs.ulong_0)
		{
			lhs.long_0++;
		}
		return lhs;
	}

	public static Int128 operator -(Int128 lhs, Int128 rhs)
	{
		return lhs + -rhs;
	}

	public static Int128 operator -(Int128 val)
	{
		if (val.ulong_0 == 0L)
		{
			return new Int128(-val.long_0, 0uL);
		}
		return new Int128(~val.long_0, ~val.ulong_0 + 1L);
	}

	public static Int128 smethod_0(long lhs, long rhs)
	{
		bool num = lhs < 0L != rhs < 0L;
		if (lhs < 0L)
		{
			lhs = -lhs;
		}
		if (rhs < 0L)
		{
			rhs = -rhs;
		}
		long num2 = lhs >>> 32;
		ulong num3 = (ulong)(lhs & 0xFFFFFFFFL);
		ulong num4 = (ulong)rhs >> 32;
		ulong num5 = (ulong)(rhs & 0xFFFFFFFFL);
		ulong num6 = (ulong)num2 * num4;
		ulong num7 = num3 * num5;
		ulong num8 = (ulong)(num2 * (long)num5) + num3 * num4;
		long num9 = (long)(num6 + (num8 >> 32));
		ulong num10 = (num8 << 32) + num7;
		if (num10 < num7)
		{
			num9++;
		}
		Int128 @int = new Int128(num9, num10);
		if (!num)
		{
			return @int;
		}
		return -@int;
	}

	public static Int128 operator /(Int128 lhs, Int128 rhs)
	{
		if (rhs.ulong_0 == 0L && rhs.long_0 == 0L)
		{
			throw new ClipperException("Int128: divide by zero");
		}
		bool flag = rhs.long_0 < 0L != lhs.long_0 < 0L;
		if (lhs.long_0 < 0L)
		{
			lhs = -lhs;
		}
		if (rhs.long_0 < 0L)
		{
			rhs = -rhs;
		}
		if (!(rhs < lhs))
		{
			if (!(rhs == lhs))
			{
				return new Int128(0L);
			}
			return new Int128((!flag) ? 1 : (-1));
		}
		Int128 @int = new Int128(0L);
		Int128 int2 = new Int128(1L);
		while (rhs.long_0 >= 0L && !(rhs > lhs))
		{
			rhs.long_0 <<= 1;
			if ((long)rhs.ulong_0 < 0L)
			{
				rhs.long_0++;
			}
			rhs.ulong_0 <<= 1;
			int2.long_0 <<= 1;
			if ((long)int2.ulong_0 < 0L)
			{
				int2.long_0++;
			}
			int2.ulong_0 <<= 1;
		}
		rhs.ulong_0 >>= 1;
		if ((rhs.long_0 & 1L) == 1L)
		{
			rhs.ulong_0 |= 9223372036854775808uL;
		}
		rhs.long_0 >>>= 1;
		int2.ulong_0 >>= 1;
		if ((int2.long_0 & 1L) == 1L)
		{
			int2.ulong_0 |= 9223372036854775808uL;
		}
		int2.long_0 >>= 1;
		while (int2.long_0 != 0L || int2.ulong_0 != 0L)
		{
			if (!(lhs < rhs))
			{
				lhs -= rhs;
				@int.long_0 |= int2.long_0;
				@int.ulong_0 |= int2.ulong_0;
			}
			rhs.ulong_0 >>= 1;
			if ((rhs.long_0 & 1L) == 1L)
			{
				rhs.ulong_0 |= 9223372036854775808uL;
			}
			rhs.long_0 >>= 1;
			int2.ulong_0 >>= 1;
			if ((int2.long_0 & 1L) == 1L)
			{
				int2.ulong_0 |= 9223372036854775808uL;
			}
			int2.long_0 >>= 1;
		}
		if (flag)
		{
			return -@int;
		}
		return @int;
	}

	public double ToDouble()
	{
		if (long_0 < 0L)
		{
			ulong num = ~ulong_0 + 1L;
			if (num != 0L)
			{
				return 0.0 - ((double)num + (double)(~long_0) * 1.8446744073709552E+19);
			}
			return (double)long_0 * 1.8446744073709552E+19;
		}
		return (double)ulong_0 + (double)long_0 * 1.8446744073709552E+19;
	}

	static Int128()
	{
		Class72.smethod_20();
	}
}
