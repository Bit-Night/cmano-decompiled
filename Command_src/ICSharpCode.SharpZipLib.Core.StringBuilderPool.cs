using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Text;

namespace ICSharpCode.SharpZipLib.Core;

internal class StringBuilderPool
{
	[CompilerGenerated]
	private static readonly StringBuilderPool stringBuilderPool_0;

	private readonly ConcurrentQueue<StringBuilder> concurrentQueue_0 = new ConcurrentQueue<StringBuilder>();

	public static StringBuilderPool Instance
	{
		[CompilerGenerated]
		get
		{
			return stringBuilderPool_0;
		}
	}

	public StringBuilder Rent()
	{
		if (!concurrentQueue_0.TryDequeue(out var result))
		{
			return new StringBuilder();
		}
		return result;
	}

	public void Return(StringBuilder builder)
	{
		builder.Clear();
		concurrentQueue_0.Enqueue(builder);
	}

	static StringBuilderPool()
	{
		Class72.smethod_20();
		stringBuilderPool_0 = new StringBuilderPool();
	}
}
