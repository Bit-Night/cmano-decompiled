using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Command_Core;

public sealed class DictionaryFactory
{
	private static ConcurrentQueue<Dictionary<string, IEventExporter.EventNotificationParameter>> concurrentQueue_0;

	private static bool bool_0;

	static DictionaryFactory()
	{
		Class72.smethod_20();
		concurrentQueue_0 = new ConcurrentQueue<Dictionary<string, IEventExporter.EventNotificationParameter>>();
	}

	public static Dictionary<string, IEventExporter.EventNotificationParameter> CreateDictionary()
	{
		if (!concurrentQueue_0.TryDequeue(out var result))
		{
			int capacity;
			if (bool_0)
			{
				capacity = 30;
			}
			else
			{
				bool_0 = true;
				Task.Factory.StartNew(smethod_0);
				capacity = 30;
			}
			return new Dictionary<string, IEventExporter.EventNotificationParameter>(capacity);
		}
		return result;
	}

	private static void smethod_0()
	{
		if (concurrentQueue_0.Count <= 2000)
		{
			bool_0 = true;
			int num = 1;
			int capacity = 30;
			while (true)
			{
				Dictionary<string, IEventExporter.EventNotificationParameter> item = new Dictionary<string, IEventExporter.EventNotificationParameter>(capacity);
				concurrentQueue_0.Enqueue(item);
				num++;
				if (num > 1000)
				{
					break;
				}
				capacity = 30;
			}
			bool_0 = false;
		}
		else
		{
			bool_0 = false;
		}
	}
}
