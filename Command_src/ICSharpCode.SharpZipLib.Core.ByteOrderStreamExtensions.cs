using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ICSharpCode.SharpZipLib.Core;

internal static class ByteOrderStreamExtensions
{
	internal static byte[] SwappedBytes(ushort value)
	{
		return new byte[2]
		{
			(byte)value,
			(byte)(value >> 8)
		};
	}

	internal static byte[] SwappedBytes(short value)
	{
		return new byte[2]
		{
			(byte)value,
			(byte)(value >> 8)
		};
	}

	internal static byte[] SwappedBytes(uint value)
	{
		return new byte[4]
		{
			(byte)value,
			(byte)(value >> 8),
			(byte)(value >> 16),
			(byte)(value >> 24)
		};
	}

	internal static byte[] SwappedBytes(int value)
	{
		return new byte[4]
		{
			(byte)value,
			(byte)(value >> 8),
			(byte)(value >> 16),
			(byte)(value >> 24)
		};
	}

	internal static byte[] SwappedBytes(long value)
	{
		return new byte[8]
		{
			(byte)value,
			(byte)(value >> 8),
			(byte)(value >> 16),
			(byte)(value >> 24),
			(byte)(value >> 32),
			(byte)(value >> 40),
			(byte)(value >> 48),
			(byte)(value >> 56)
		};
	}

	internal static byte[] SwappedBytes(ulong value)
	{
		return new byte[8]
		{
			(byte)value,
			(byte)(value >> 8),
			(byte)(value >> 16),
			(byte)(value >> 24),
			(byte)(value >> 32),
			(byte)(value >> 40),
			(byte)(value >> 48),
			(byte)(value >> 56)
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static long smethod_0(byte[] bytes)
	{
		return (long)(bytes[0] | ((ulong)bytes[1] << 8) | ((ulong)bytes[2] << 16) | ((ulong)bytes[3] << 24) | ((ulong)bytes[4] << 32) | ((ulong)bytes[5] << 40) | ((ulong)bytes[6] << 48) | ((ulong)bytes[7] << 56));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ulong smethod_1(byte[] bytes)
	{
		return bytes[0] | ((ulong)bytes[1] << 8) | ((ulong)bytes[2] << 16) | ((ulong)bytes[3] << 24) | ((ulong)bytes[4] << 32) | ((ulong)bytes[5] << 40) | ((ulong)bytes[6] << 48) | ((ulong)bytes[7] << 56);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static int smethod_2(byte[] bytes)
	{
		return bytes[0] | (bytes[1] << 8) | (bytes[2] << 16) | (bytes[3] << 24);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static uint smethod_3(byte[] bytes)
	{
		return (uint)smethod_2(bytes);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static short smethod_4(byte[] bytes)
	{
		return (short)(bytes[0] | (bytes[1] << 8));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ushort smethod_5(byte[] bytes)
	{
		return (ushort)smethod_4(bytes);
	}

	internal static byte[] ReadBytes(this Stream stream, int count)
	{
		byte[] array = new byte[count];
		int num = count;
		while (num > 0)
		{
			int num2 = stream.Read(array, count - num, num);
			if (num2 >= 1)
			{
				num -= num2;
				continue;
			}
			throw new EndOfStreamException();
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int smethod_6(this Stream stream)
	{
		return smethod_4(ReadBytes(stream, 2));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int smethod_7(this Stream stream)
	{
		return smethod_2(ReadBytes(stream, 4));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long smethod_8(this Stream stream)
	{
		return smethod_0(ReadBytes(stream, 8));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteLEShort(this Stream stream, int value)
	{
		stream.Write(SwappedBytes(value), 0, 2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task WriteLEShortAsync(this Stream stream, int value, CancellationToken ct)
	{
		await stream.WriteAsync(SwappedBytes(value), 0, 2, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteLEUshort(this Stream stream, ushort value)
	{
		stream.Write(SwappedBytes(value), 0, 2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task smethod_9(this Stream stream, ushort value, CancellationToken ct)
	{
		await stream.WriteAsync(SwappedBytes(value), 0, 2, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void smethod_10(this Stream stream, int value)
	{
		stream.Write(SwappedBytes(value), 0, 4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task WriteLEIntAsync(this Stream stream, int value, CancellationToken ct)
	{
		await stream.WriteAsync(SwappedBytes(value), 0, 4, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void smethod_11(this Stream stream, uint value)
	{
		stream.Write(SwappedBytes(value), 0, 4);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task WriteLEUintAsync(this Stream stream, uint value, CancellationToken ct)
	{
		await stream.WriteAsync(SwappedBytes(value), 0, 4, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void smethod_12(this Stream stream, long value)
	{
		stream.Write(SwappedBytes(value), 0, 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task WriteLELongAsync(this Stream stream, long value, CancellationToken ct)
	{
		await stream.WriteAsync(SwappedBytes(value), 0, 8, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void WriteLEUlong(this Stream stream, ulong value)
	{
		stream.Write(SwappedBytes(value), 0, 8);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static async Task WriteLEUlongAsync(this Stream stream, ulong value, CancellationToken ct)
	{
		await stream.WriteAsync(SwappedBytes(value), 0, 8, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	static ByteOrderStreamExtensions()
	{
		Class72.smethod_20();
	}
}
