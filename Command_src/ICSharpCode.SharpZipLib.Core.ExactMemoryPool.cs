using System;
using System.Buffers;

namespace ICSharpCode.SharpZipLib.Core;

internal sealed class ExactMemoryPool<T> : MemoryPool<T>
{
	private sealed class Class37 : IMemoryOwner<T>, IDisposable
	{
		private T[] gparam_0;

		private readonly int int_0;

		private static object object_0;

		public Memory<T> Memory => new Memory<T>(gparam_0 ?? throw new ObjectDisposedException("ExactMemoryPoolBuffer")).Slice(0, int_0);

		public Class37(int int_1)
		{
			int_0 = int_1;
			gparam_0 = ArrayPool<T>.Shared.Rent(int_1);
		}

		public void Dispose()
		{
			T[] array = gparam_0;
			if (array != null)
			{
				gparam_0 = null;
				ArrayPool<T>.Shared.Return(array);
			}
		}

		static Class37()
		{
			Class72.smethod_20();
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

	public new static readonly MemoryPool<T> Shared;

	private static object object_0;

	public override int MaxBufferSize => int.MaxValue;

	public override IMemoryOwner<T> Rent(int bufferSize = -1)
	{
		if ((uint)bufferSize > 2147483647u || bufferSize < 0)
		{
			throw new ArgumentOutOfRangeException("bufferSize");
		}
		return new Class37(bufferSize);
	}

	protected override void Dispose(bool disposing)
	{
	}

	static ExactMemoryPool()
	{
		Class72.smethod_20();
		Shared = new ExactMemoryPool<T>();
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
