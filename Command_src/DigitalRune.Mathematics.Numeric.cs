using System;
using System.Runtime.InteropServices;

namespace DigitalRune.Mathematics;

public static class Numeric
{
	[StructLayout(LayoutKind.Explicit)]
	private struct Struct50
	{
		[FieldOffset(0)]
		internal float float_0;

		[FieldOffset(0)]
		internal uint uint_0;
	}

	[StructLayout(LayoutKind.Explicit)]
	private struct Struct51
	{
		[FieldOffset(0)]
		internal double double_0;

		[FieldOffset(0)]
		internal ulong ulong_0;
	}

	private static float float_0;

	private static float mvreWlxpisK;

	private static double double_0;

	private static double double_1;

	public static float EpsilonF
	{
		get
		{
			return float_0;
		}
		set
		{
			if (value <= 0f)
			{
				throw new ArgumentOutOfRangeException("value", "The tolerance value must be greater than 0.");
			}
			float_0 = value;
			mvreWlxpisK = value * value;
		}
	}

	public static float EpsilonFSquared => mvreWlxpisK;

	public static double EpsilonD
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", "The epsilon tolerance value must be greater than 0.");
			}
			double_0 = value;
			double_1 = value * value;
		}
	}

	public static double EpsilonDSquared => double_1;

	public static bool AreEqual(float value1, float value2)
	{
		if (value1 == value2)
		{
			return true;
		}
		float num = float_0 * (Math.Abs(value1) + Math.Abs(value2) + 1f);
		float num2 = value1 - value2;
		if (0f - num >= num2)
		{
			return false;
		}
		return num2 < num;
	}

	public static bool AreEqual(double value1, double value2)
	{
		if (value1 == value2)
		{
			return true;
		}
		double num = double_0 * (Math.Abs(value1) + Math.Abs(value2) + 1.0);
		double num2 = value1 - value2;
		if (0.0 - num >= num2)
		{
			return false;
		}
		return num2 < num;
	}

	public static bool AreEqual(float value1, float value2, float epsilon)
	{
		if (epsilon > 0f)
		{
			if (value1 == value2)
			{
				return true;
			}
			float num = value1 - value2;
			if (0f - epsilon >= num)
			{
				return false;
			}
			return num < epsilon;
		}
		throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
	}

	public static bool AreEqual(double value1, double value2, double epsilon)
	{
		if (epsilon <= 0.0)
		{
			throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
		}
		if (value1 == value2)
		{
			return true;
		}
		double num = value1 - value2;
		if (0.0 - epsilon >= num)
		{
			return false;
		}
		return num < epsilon;
	}

	public static bool IsLess(float value1, float value2)
	{
		if (value1 >= value2)
		{
			return false;
		}
		return !AreEqual(value1, value2);
	}

	public static bool IsLess(float value1, float value2, float epsilon)
	{
		if (value1 >= value2)
		{
			return false;
		}
		return !AreEqual(value1, value2, epsilon);
	}

	public static bool IsLess(double value1, double value2)
	{
		if (value1 < value2)
		{
			return !AreEqual(value1, value2);
		}
		return false;
	}

	public static bool IsLess(double value1, double value2, double epsilon)
	{
		if (value1 >= value2)
		{
			return false;
		}
		return !AreEqual(value1, value2, epsilon);
	}

	public static bool IsLessOrEqual(float value1, float value2)
	{
		if (!(value1 < value2))
		{
			return AreEqual(value1, value2);
		}
		return true;
	}

	public static bool IsLessOrEqual(float value1, float value2, float epsilon)
	{
		if (!(value1 >= value2))
		{
			return true;
		}
		return AreEqual(value1, value2, epsilon);
	}

	public static bool IsLessOrEqual(double value1, double value2)
	{
		if (!(value1 < value2))
		{
			return AreEqual(value1, value2);
		}
		return true;
	}

	public static bool IsLessOrEqual(double value1, double value2, double epsilon)
	{
		if (!(value1 < value2))
		{
			return AreEqual(value1, value2, epsilon);
		}
		return true;
	}

	public static bool IsGreater(float value1, float value2)
	{
		if (value1 > value2)
		{
			return !AreEqual(value1, value2);
		}
		return false;
	}

	public static bool IsGreater(float value1, float value2, float epsilon)
	{
		if (value1 <= value2)
		{
			return false;
		}
		return !AreEqual(value1, value2, epsilon);
	}

	public static bool IsGreater(double value1, double value2)
	{
		if (value1 <= value2)
		{
			return false;
		}
		return !AreEqual(value1, value2);
	}

	public static bool IsGreater(double value1, double value2, double epsilon)
	{
		if (value1 <= value2)
		{
			return false;
		}
		return !AreEqual(value1, value2, epsilon);
	}

	public static bool IsGreaterOrEqual(float value1, float value2)
	{
		if (!(value1 <= value2))
		{
			return true;
		}
		return AreEqual(value1, value2);
	}

	public static bool IsGreaterOrEqual(float value1, float value2, float epsilon)
	{
		if (!(value1 > value2))
		{
			return AreEqual(value1, value2, epsilon);
		}
		return true;
	}

	public static bool IsGreaterOrEqual(double value1, double value2)
	{
		if (!(value1 > value2))
		{
			return AreEqual(value1, value2);
		}
		return true;
	}

	public static bool IsGreaterOrEqual(double value1, double value2, double epsilon)
	{
		if (!(value1 <= value2))
		{
			return true;
		}
		return AreEqual(value1, value2, epsilon);
	}

	public static float ClampToZero(float value)
	{
		if (IsZero(value))
		{
			return 0f;
		}
		return value;
	}

	public static float ClampToZero(float value, float epsilon)
	{
		if (!IsZero(value, epsilon))
		{
			return value;
		}
		return 0f;
	}

	public static double ClampToZero(double value)
	{
		if (IsZero(value))
		{
			return 0.0;
		}
		return value;
	}

	public static double ClampToZero(double value, double epsilon)
	{
		if (!IsZero(value, epsilon))
		{
			return value;
		}
		return 0.0;
	}

	public static bool IsZero(float value)
	{
		if (0f - float_0 >= value)
		{
			return false;
		}
		return value < float_0;
	}

	public static bool IsZero(double value)
	{
		if (0.0 - double_0 < value)
		{
			return value < double_0;
		}
		return false;
	}

	public static bool IsZero(float value, float epsilon)
	{
		if (epsilon > 0f)
		{
			if (0f - epsilon < value)
			{
				return value < epsilon;
			}
			return false;
		}
		throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
	}

	public static bool IsZero(double value, double epsilon)
	{
		if (epsilon <= 0.0)
		{
			throw new ArgumentOutOfRangeException("epsilon", "Epsilon value must be greater than 0.");
		}
		if (0.0 - epsilon < value)
		{
			return value < epsilon;
		}
		return false;
	}

	public static int Compare(float value1, float value2)
	{
		if (AreEqual(value1, value2))
		{
			return 0;
		}
		if (!(value1 < value2))
		{
			return 1;
		}
		return -1;
	}

	public static int Compare(double value1, double value2)
	{
		if (AreEqual(value1, value2))
		{
			return 0;
		}
		if (!(value1 >= value2))
		{
			return -1;
		}
		return 1;
	}

	public static int Compare(float value1, float value2, float epsilon)
	{
		if (!AreEqual(value1, value2, epsilon))
		{
			if (!(value1 < value2))
			{
				return 1;
			}
			return -1;
		}
		return 0;
	}

	public static int Compare(double value1, double value2, double epsilon)
	{
		if (AreEqual(value1, value2, epsilon))
		{
			return 0;
		}
		if (!(value1 < value2))
		{
			return 1;
		}
		return -1;
	}

	public static bool IsFiniteOrNaN(float value)
	{
		return !float.IsInfinity(value);
	}

	public static bool IsFiniteOrNaN(double value)
	{
		return !double.IsInfinity(value);
	}

	public static bool IsFinite(float value)
	{
		if (!IsNaN(value))
		{
			return !float.IsInfinity(value);
		}
		return false;
	}

	public static bool IsFinite(double value)
	{
		if (IsNaN(value))
		{
			return false;
		}
		return !double.IsInfinity(value);
	}

	public static bool IsPositive(float value)
	{
		return 0f < value;
	}

	public static bool IsPositive(double value)
	{
		return 0.0 < value;
	}

	public static bool IsNegative(float value)
	{
		return value < 0f;
	}

	public static bool IsNegative(double value)
	{
		return value < 0.0;
	}

	public static bool IsPositiveFinite(float value)
	{
		if (0f < value)
		{
			return !float.IsPositiveInfinity(value);
		}
		return false;
	}

	public static bool IsPositiveFinite(double value)
	{
		if (0.0 >= value)
		{
			return false;
		}
		return !double.IsPositiveInfinity(value);
	}

	public static bool IsNegativeFinite(float value)
	{
		if (value < 0f)
		{
			return !float.IsNegativeInfinity(value);
		}
		return false;
	}

	public static bool IsNegativeFinite(double value)
	{
		if (value < 0.0)
		{
			return !double.IsNegativeInfinity(value);
		}
		return false;
	}

	public static bool IsZeroOrPositiveFinite(float value)
	{
		if (0f <= value)
		{
			return !float.IsPositiveInfinity(value);
		}
		return false;
	}

	public static bool IsZeroOrPositiveFinite(double value)
	{
		if (0.0 > value)
		{
			return false;
		}
		return !double.IsPositiveInfinity(value);
	}

	public static bool IsZeroOrNegativeFinite(float value)
	{
		if (value <= 0f)
		{
			return !float.IsNegativeInfinity(value);
		}
		return false;
	}

	public static bool IsZeroOrNegativeFinite(double value)
	{
		if (value <= 0.0)
		{
			return !double.IsNegativeInfinity(value);
		}
		return false;
	}

	public static bool IsNaN(float value)
	{
		Struct50 obj = new Struct50
		{
			float_0 = value
		};
		uint num = obj.uint_0 & 0x7F800000;
		uint num2 = obj.uint_0 & 0x7FFFFF;
		if (num == 2139095040)
		{
			return num2 != 0;
		}
		return false;
	}

	public static bool IsNaN(double value)
	{
		Struct51 obj = new Struct51
		{
			double_0 = value
		};
		ulong num = obj.ulong_0 & 0x7FF0000000000000L;
		ulong num2 = obj.ulong_0 & 0xFFFFFFFFFFFFFL;
		if (num == 9218868437227405312L)
		{
			return num2 > 0L;
		}
		return false;
	}

	[CLSCompliant(false)]
	public static uint GetSignificantBitsUnsigned(float value, int n)
	{
		Struct50 @struct = new Struct50
		{
			float_0 = value
		};
		return @struct.uint_0 >> 31 - n;
	}

	[CLSCompliant(false)]
	public static uint GetSignificantBitsSigned(float value, int n)
	{
		Struct50 @struct = new Struct50
		{
			float_0 = value
		};
		@struct.uint_0 = smethod_0(@struct.uint_0);
		return @struct.uint_0 >> 32 - n;
	}

	private static uint smethod_0(uint uint_0)
	{
		uint num = (0 - (uint_0 >> 31)) | 0x80000000u;
		return uint_0 ^ num;
	}

	static Numeric()
	{
		Class72.smethod_20();
		float_0 = 1E-05f;
		mvreWlxpisK = 9.9999994E-11f;
		double_0 = 1E-12;
		double_1 = 1E-24;
	}
}
