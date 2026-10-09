using System;
using System.Collections.Generic;
using System.Threading;

namespace Command_Core;

public sealed class JaggedConcurrentMap<TValue>
{
	private sealed class Row
	{
		public readonly ScenarioObject scenarioObject_0;

		public readonly Dictionary<int, TValue> wqqymMdtaLa;

		private static object object_0;

		public Row()
		{
			scenarioObject_0 = new ScenarioObject();
			wqqymMdtaLa = new Dictionary<int, TValue>();
		}

		static Row()
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

	private readonly Row[] row_0;

	internal static object object_0;

	public TValue this[int firstKey, int secondKey]
	{
		get
		{
			TValue value = default(TValue);
			if (!TryGetValue(firstKey, secondKey, ref value))
			{
				throw new KeyNotFoundException();
			}
			return value;
		}
		set
		{
			Row row = method_1(firstKey);
			lock (row.scenarioObject_0)
			{
				row.wqqymMdtaLa[secondKey] = value;
			}
		}
	}

	public JaggedConcurrentMap(int maxFirstKey)
	{
		if (maxFirstKey < 0)
		{
			throw new ArgumentOutOfRangeException("maxFirstKey");
		}
		row_0 = new Row[maxFirstKey + 1];
	}

	public bool TryGetValue(int firstKey, int secondKey, ref TValue value)
	{
		Row row = method_0(firstKey);
		if (row == null)
		{
			value = default(TValue);
			return false;
		}
		return row.wqqymMdtaLa.TryGetValue(secondKey, out value);
	}

	public void Add(int firstKey, int secondKey, TValue value)
	{
		Row row = method_1(firstKey);
		lock (row.scenarioObject_0)
		{
			row.wqqymMdtaLa.Add(secondKey, value);
		}
	}

	public bool TryAdd(int firstKey, int secondKey, TValue value)
	{
		Row row = method_1(firstKey);
		lock (row.scenarioObject_0)
		{
			if (row.wqqymMdtaLa.ContainsKey(secondKey))
			{
				return false;
			}
			row.wqqymMdtaLa.Add(secondKey, value);
			return true;
		}
	}

	public bool ContainsKey(int firstKey, int secondKey)
	{
		return method_0(firstKey)?.wqqymMdtaLa.ContainsKey(secondKey) ?? false;
	}

	public bool Remove(int firstKey, int secondKey)
	{
		Row row = method_0(firstKey);
		if (row != null)
		{
			lock (row.scenarioObject_0)
			{
				return row.wqqymMdtaLa.Remove(secondKey);
			}
		}
		return false;
	}

	public void Clear()
	{
		int num = row_0.Length - 1;
		for (int i = 0; i <= num; i++)
		{
			Row row = row_0[i];
			if (row != null)
			{
				lock (row.scenarioObject_0)
				{
					row.wqqymMdtaLa.Clear();
				}
			}
		}
	}

	private Row method_0(int int_0)
	{
		if (int_0 < 0 || int_0 >= row_0.Length)
		{
			throw new ArgumentOutOfRangeException("firstKey");
		}
		return Volatile.Read(in row_0[int_0]);
	}

	private Row method_1(int int_0)
	{
		if (int_0 >= 0 && int_0 < row_0.Length)
		{
			Row row = Volatile.Read(in row_0[int_0]);
			if (row != null)
			{
				return row;
			}
			Row row2 = new Row();
			Row row3 = Interlocked.CompareExchange(ref row_0[int_0], row2, null);
			if (row3 == null)
			{
				return row2;
			}
			return row3;
		}
		throw new ArgumentOutOfRangeException("firstKey");
	}

	static JaggedConcurrentMap()
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
