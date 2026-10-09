using System;
using System.Collections.Generic;

namespace MapReduce.NET;

public abstract class Reducer<REDUCEKEY, REDUCEVALUE, REDUCEDNEWVALUE> : MapReduceBase
{
	private static object object_0;

	public virtual void Merge(REDUCEDNEWVALUE to, REDUCEDNEWVALUE from)
	{
		throw new NotImplementedException("The result of Reduce is not auto-mergable! Override Reducer.Merge.");
	}

	public virtual void BeforeSave(IDictionary<REDUCEKEY, REDUCEDNEWVALUE> dict)
	{
	}

	public abstract REDUCEDNEWVALUE Reduce(REDUCEKEY key, REDUCEVALUE value, REDUCEDNEWVALUE result);

	static Reducer()
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
