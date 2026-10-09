using MapReduce.NET.Collections;

namespace MapReduce.NET;

public abstract class Mapper<KEY, VALUE, REDUCEKEY, REDUCEVALUE> : MapReduceBase
{
	private MapReduceContext mapReduceContext_0 = new MapReduceContext();

	private static object object_0;

	public MapReduceContext Context
	{
		get
		{
			return mapReduceContext_0;
		}
		set
		{
			mapReduceContext_0 = value;
		}
	}

	public abstract void Map(KEY key, VALUE value, IQueue<REDUCEKEY, REDUCEVALUE> result);

	static Mapper()
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
