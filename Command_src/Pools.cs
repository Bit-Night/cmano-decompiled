public sealed class Pools<T>
{
	public static readonly ThreadLocalArrayPool<T> Local;

	private static object object_0;

	static Pools()
	{
		Class72.smethod_20();
		Local = new ThreadLocalArrayPool<T>();
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
