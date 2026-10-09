using System.Collections.Generic;

namespace MapReduce.NET;

public abstract class MapReduceBase
{
	private IDictionary<string, string> idictionary_0;

	internal IDictionary<string, string> Parameters
	{
		get
		{
			return idictionary_0;
		}
		set
		{
			idictionary_0 = value;
			TypeFinder.MapDictionary(this, idictionary_0);
		}
	}

	static MapReduceBase()
	{
		Class72.smethod_20();
	}
}
