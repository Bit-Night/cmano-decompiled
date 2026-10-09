using System;
using System.Numerics;
using System.Threading.Tasks;

namespace HPCsharp.ParallelAlgorithms;

public static class ZeroDetect
{
	private static bool smethod_0(this object object_0, int int_0, int int_1)
	{
		Vector<byte> vector = new Vector<byte>(0);
		Vector<byte> right = new Vector<byte>(0);
		int num = int_0 + (int_1 - int_0 + 1) / Vector<byte>.Count * Vector<byte>.Count;
		int i = int_0;
		while (true)
		{
			if (i < num)
			{
				Vector<byte> vector2 = new Vector<byte>((byte[])object_0, i);
				vector |= vector2;
				if (!Vector.EqualsAll(vector2, right))
				{
					break;
				}
				i += Vector<byte>.Count;
				continue;
			}
			byte b = 0;
			for (; i <= int_1; i++)
			{
				b |= ((byte[])object_0)[i];
			}
			for (i = 0; i < Vector<byte>.Count; i++)
			{
				b |= vector[i];
			}
			return b == 0;
		}
		return false;
	}

	public static bool ZeroDetectSse(this byte[] arrayToDetect)
	{
		return arrayToDetect.smethod_0(0, arrayToDetect.Length - 1);
	}

	private static bool smethod_1(this object object_0, int int_0, int int_1)
	{
		Vector<byte> vector = new Vector<byte>(0);
		Vector<byte> vector2 = new Vector<byte>(0);
		int num = 4;
		int count = Vector<byte>.Count;
		int num2 = Vector<byte>.Count * 2;
		int num3 = Vector<byte>.Count * 3;
		int num4 = 512 * Vector<byte>.Count;
		int num5 = int_0 + (int_1 - int_0 + 1) / num4 * num4;
		int i = int_0;
		while (true)
		{
			if (i < num5)
			{
				int num6 = i + num4;
				int num7 = Vector<byte>.Count * num;
				for (int j = i; j < num6; j += num7)
				{
					vector |= new Vector<byte>((byte[])object_0, j);
					vector |= new Vector<byte>((byte[])object_0, j + count);
					vector |= new Vector<byte>((byte[])object_0, j + num2);
					vector |= new Vector<byte>((byte[])object_0, j + num3);
				}
				if (vector != vector2)
				{
					break;
				}
				i += num4;
				continue;
			}
			byte b = 0;
			for (; i <= int_1; i++)
			{
				b |= ((byte[])object_0)[i];
			}
			for (i = 0; i < Vector<byte>.Count; i++)
			{
				b |= vector[i];
			}
			return b == 0;
		}
		return false;
	}

	private static bool smethod_2(this object object_0)
	{
		return object_0.smethod_1(0, ((Array)object_0).Length - 1);
	}

	private static bool smethod_3(this object object_0, int int_0, int int_1)
	{
		Vector<byte> right = new Vector<byte>(0);
		int num = int_0 + (int_1 - int_0 + 1) / (Vector<byte>.Count * 4) * (Vector<byte>.Count * 4);
		int count = Vector<byte>.Count;
		int num2 = Vector<byte>.Count * 2;
		int num3 = Vector<byte>.Count * 3;
		int num4 = Vector<byte>.Count * 4;
		int i = int_0;
		while (true)
		{
			if (i < num)
			{
				if (!Vector.EqualsAll(new Vector<byte>((byte[])object_0, i) | new Vector<byte>((byte[])object_0, i + count) | new Vector<byte>((byte[])object_0, i + num2) | new Vector<byte>((byte[])object_0, i + num3), right))
				{
					break;
				}
				i += num4;
				continue;
			}
			byte b = 0;
			for (; i <= int_1; i++)
			{
				b |= ((byte[])object_0)[i];
			}
			return b == 0;
		}
		return false;
	}

	public static bool ZeroDetectSseUnrolled(this byte[] arrayToDetect)
	{
		return arrayToDetect.smethod_3(0, arrayToDetect.Length - 1);
	}

	public static bool ZeroDetectSseUnrolled(this byte[] arrayToProcess, int start, int length)
	{
		return arrayToProcess.smethod_3(start, start + length - 1);
	}

	private static bool smethod_4(this object object_0, int int_0, int int_1, byte byte_0)
	{
		Vector<byte> right = new Vector<byte>(byte_0);
		int num = int_0 + (int_1 - int_0 + 1) / (Vector<byte>.Count * 4) * (Vector<byte>.Count * 4);
		_ = Vector<byte>.Count;
		_ = Vector<byte>.Count;
		_ = Vector<byte>.Count;
		int num2 = Vector<byte>.Count * 4;
		int i = int_0;
		int result;
		while (true)
		{
			if (i < num)
			{
				if (Vector.EqualsAll(new Vector<byte>((byte[])object_0, i), right))
				{
					if (Vector.EqualsAll(new Vector<byte>((byte[])object_0, i), right))
					{
						if (Vector.EqualsAll(new Vector<byte>((byte[])object_0, i), right))
						{
							if (Vector.EqualsAll(new Vector<byte>((byte[])object_0, i), right))
							{
								i += num2;
								continue;
							}
							result = 0;
							break;
						}
						result = 0;
						break;
					}
					result = 0;
					break;
				}
				result = 0;
				break;
			}
			bool flag = true;
			for (; i <= int_1; i++)
			{
				flag = flag && ((byte[])object_0)[i] == byte_0;
			}
			return flag;
		}
		return (byte)result != 0;
	}

	public static bool ValueDetectSseUnrolled(this byte[] arrayToDetect, byte value)
	{
		return arrayToDetect.smethod_4(0, arrayToDetect.Length - 1, value);
	}

	public static bool ValueDetectSseUnrolled(this byte[] arrayToProcess, int start, int length, byte value)
	{
		return arrayToProcess.smethod_4(start, start + length - 1, value);
	}

	private static bool eJuewYbfikJ(this object object_0, int int_0, int int_1)
	{
		Vector<byte> vector = new Vector<byte>(0);
		Vector<byte> vector2 = new Vector<byte>(0);
		Vector<byte> vector3 = new Vector<byte>(0);
		Vector<byte> vector4 = new Vector<byte>(0);
		int num = int_0 + (int_1 - int_0 + 1) / (Vector<byte>.Count * 4) * (Vector<byte>.Count * 4);
		int count = Vector<byte>.Count;
		int num2 = Vector<byte>.Count * 2;
		int num3 = Vector<byte>.Count * 3;
		int num4 = Vector<byte>.Count * 4;
		int i;
		for (i = int_0; i < num; i += num4)
		{
			vector |= new Vector<byte>((byte[])object_0, i);
			vector2 |= new Vector<byte>((byte[])object_0, i + count);
			vector3 |= new Vector<byte>((byte[])object_0, i + num2);
			vector4 |= new Vector<byte>((byte[])object_0, i + num3);
		}
		byte b = 0;
		for (; i <= int_1; i++)
		{
			b |= ((byte[])object_0)[i];
		}
		vector |= vector2;
		vector |= vector3;
		vector |= vector4;
		for (i = 0; i < Vector<byte>.Count; i++)
		{
			b |= vector[i];
		}
		return b == 0;
	}

	private static bool smethod_5(this object object_0)
	{
		return object_0.eJuewYbfikJ(0, ((Array)object_0).Length - 1);
	}

	private static bool smethod_6(this byte[] byte_0, int int_0, int int_1, int int_2 = 4096, int int_3 = 2)
	{
		bool bool_0 = false;
		if (int_0 > int_1)
		{
			return bool_0;
		}
		if (int_1 - int_0 + 1 <= int_2)
		{
			return byte_0.smethod_3(int_0, int_1 - int_0 + 1);
		}
		int int_4 = (int_1 + int_0) / 2;
		bool bool_1 = false;
		Parallel.Invoke(new ParallelOptions
		{
			MaxDegreeOfParallelism = int_3
		}, delegate
		{
			bool_0 = byte_0.smethod_6(int_0, int_4);
		}, delegate
		{
			bool_1 = byte_0.smethod_6(int_4 + 1, int_1);
		});
		return bool_0 && bool_1;
	}

	public static bool ZeroDetectSseUnrolledPar(this byte[] arrayToProcess, int thresholdParallel = 4096, int parallelism = 2)
	{
		return arrayToProcess.smethod_6(0, arrayToProcess.Length - 1, thresholdParallel, parallelism);
	}

	public static bool ZeroDetectSseUnrolledPar(this byte[] arrayToProcess, int start, int length, int thresholdParallel = 4096, int parallelism = 2)
	{
		return arrayToProcess.smethod_6(start, start + length - 1, thresholdParallel, parallelism);
	}

	private static bool smethod_7(this byte[] byte_0, int int_0, int int_1, int int_2 = 4096, int int_3 = 2)
	{
		bool bool_0 = false;
		if (int_0 <= int_1)
		{
			if (int_1 - int_0 + 1 > int_2)
			{
				int int_4 = (int_1 + int_0) / 2;
				bool bool_1 = false;
				Parallel.Invoke(new ParallelOptions
				{
					MaxDegreeOfParallelism = int_3
				}, delegate
				{
					bool_0 = byte_0.smethod_7(int_0, int_4);
				}, delegate
				{
					bool_1 = byte_0.smethod_7(int_4 + 1, int_1);
				});
				return bool_0 && bool_1;
			}
			return byte_0.smethod_0(int_0, int_1 - int_0 + 1);
		}
		return bool_0;
	}

	public static bool ZeroDetectSsePar(this byte[] arrayToProcess, int thresholdParallel = 4096, int parallelism = 2)
	{
		return arrayToProcess.smethod_7(0, arrayToProcess.Length - 1, thresholdParallel, parallelism);
	}

	public static bool ZeroDetectSsePar(this byte[] arrayToProcess, int start, int length, int thresholdParallel = 4096, int parallelism = 2)
	{
		return arrayToProcess.smethod_7(start, start + length - 1, thresholdParallel, parallelism);
	}

	private static bool smethod_8(this byte[] byte_0, int int_0, int int_1, int int_2 = 4096, int int_3 = 2)
	{
		bool bool_0 = false;
		if (int_0 > int_1)
		{
			return bool_0;
		}
		if (int_1 - int_0 + 1 > int_2)
		{
			int int_4 = (int_1 + int_0) / 2;
			bool bool_1 = false;
			Parallel.Invoke(new ParallelOptions
			{
				MaxDegreeOfParallelism = int_3
			}, delegate
			{
				bool_0 = byte_0.smethod_6(int_0, int_4);
			}, delegate
			{
				bool_1 = byte_0.smethod_6(int_4 + 1, int_1);
			});
			return bool_0 && bool_1;
		}
		return HPCsharp.ZeroDetect.ByFixedLongUnrolled(byte_0, int_0, int_1 - int_0 + 1);
	}

	public static bool ZeroDetectUnrolledPar(this byte[] arrayToProcess, int thresholdParallel = 4096, int parallelism = 2)
	{
		return arrayToProcess.smethod_8(0, arrayToProcess.Length - 1, thresholdParallel, parallelism);
	}

	public static bool ZeroDetectUnrolledPar(this byte[] arrayToProcess, int start, int length, int thresholdParallel = 4096, int parallelism = 2)
	{
		return arrayToProcess.smethod_8(start, start + length - 1, thresholdParallel, parallelism);
	}

	static ZeroDetect()
	{
		Class72.smethod_20();
	}
}
