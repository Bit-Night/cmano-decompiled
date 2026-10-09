using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Collections.Extensions;

[DebuggerTypeProxy(typeof(DictionarySlimDebugView<, >))]
[DebuggerDisplay("Count = {Count}")]
public class DictionarySlim<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable where TKey : IEquatable<TKey>
{
	[DebuggerDisplay("({key}, {value})->{next}")]
	private struct Struct49
	{
		public TKey gparam_0;

		public TValue tasYympqeTT;

		public int int_0;
	}

	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IDisposable, IEnumerator
	{
		private readonly DictionarySlim<TKey, TValue> dictionarySlim_0;

		private int int_0;

		private int int_1;

		private KeyValuePair<TKey, TValue> keyValuePair_0;

		public KeyValuePair<TKey, TValue> Current => keyValuePair_0;

		object IEnumerator.Current => keyValuePair_0;

		internal Enumerator(DictionarySlim<TKey, TValue> dictionary)
		{
			dictionarySlim_0 = dictionary;
			int_0 = 0;
			int_1 = dictionarySlim_0.int_0;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
		}

		public bool MoveNext()
		{
			if (int_1 != 0)
			{
				int_1--;
				while (dictionarySlim_0.struct49_1[int_0].int_0 < -1)
				{
					int_0++;
				}
				keyValuePair_0 = new KeyValuePair<TKey, TValue>(dictionarySlim_0.struct49_1[int_0].gparam_0, dictionarySlim_0.struct49_1[int_0++].tasYympqeTT);
				return true;
			}
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
			return false;
		}

		void IEnumerator.Reset()
		{
			int_0 = 0;
			int_1 = dictionarySlim_0.int_0;
			keyValuePair_0 = default(KeyValuePair<TKey, TValue>);
		}

		public void Dispose()
		{
		}

		static Enumerator()
		{
			Class72.smethod_20();
		}

		internal static bool smethod_0()
		{
			return true;
		}

		internal static object smethod_1()
		{
			return null;
		}
	}

	private static readonly Struct49[] struct49_0;

	private int int_0;

	private int int_1 = -1;

	private int[] int_2;

	private Struct49[] struct49_1;

	internal static object object_0;

	public int Count => int_0;

	public DictionarySlim()
	{
		int_2 = HashHelpers.SizeOneIntArray;
		struct49_1 = struct49_0;
	}

	public DictionarySlim(int capacity)
	{
		if (capacity < 0)
		{
			ThrowHelper.ThrowCapacityArgumentOutOfRangeException();
		}
		if (capacity < 2)
		{
			capacity = 2;
		}
		capacity = HashHelpers.PowerOf2(capacity);
		int_2 = new int[capacity];
		struct49_1 = new Struct49[capacity];
	}

	public void Clear()
	{
		int_0 = 0;
		int_1 = -1;
		int_2 = HashHelpers.SizeOneIntArray;
		struct49_1 = struct49_0;
	}

	public bool ContainsKey(TKey key)
	{
		if (key == null)
		{
			ThrowHelper.ThrowKeyArgumentNullException();
		}
		Struct49[] array = struct49_1;
		int num = 0;
		int num2 = int_2[key.GetHashCode() & (int_2.Length - 1)] - 1;
		while (true)
		{
			if ((uint)num2 < (uint)array.Length)
			{
				if (key.Equals(array[num2].gparam_0))
				{
					break;
				}
				if (num == array.Length)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num++;
				num2 = array[num2].int_0;
				continue;
			}
			return false;
		}
		return true;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (key == null)
		{
			ThrowHelper.ThrowKeyArgumentNullException();
		}
		Struct49[] array = struct49_1;
		int num = 0;
		int num2 = int_2[key.GetHashCode() & (int_2.Length - 1)] - 1;
		while (true)
		{
			if ((uint)num2 < (uint)array.Length)
			{
				if (key.Equals(array[num2].gparam_0))
				{
					break;
				}
				if (num == array.Length)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num++;
				num2 = array[num2].int_0;
				continue;
			}
			value = default(TValue);
			return false;
		}
		value = array[num2].tasYympqeTT;
		return true;
	}

	public bool Remove(TKey key)
	{
		if (key == null)
		{
			ThrowHelper.ThrowKeyArgumentNullException();
		}
		Struct49[] array = struct49_1;
		int num = key.GetHashCode() & (int_2.Length - 1);
		int num2 = int_2[num] - 1;
		int num3 = -1;
		int num4 = 0;
		Struct49 @struct;
		while (true)
		{
			if (num2 != -1)
			{
				@struct = array[num2];
				ref TKey gparam_ = ref @struct.gparam_0;
				TKey other = key;
				if (gparam_.Equals(other))
				{
					break;
				}
				num3 = num2;
				num2 = @struct.int_0;
				if (num4 == array.Length)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num4++;
				continue;
			}
			return false;
		}
		if (num3 != -1)
		{
			array[num3].int_0 = @struct.int_0;
		}
		else
		{
			int_2[num] = @struct.int_0 + 1;
		}
		array[num2] = default(Struct49);
		array[num2].int_0 = -3 - int_1;
		int_1 = num2;
		int_0--;
		return true;
	}

	public ref TValue GetOrAddValueRef(TKey key)
	{
		if (key == null)
		{
			ThrowHelper.ThrowKeyArgumentNullException();
		}
		Struct49[] array = struct49_1;
		int num = 0;
		int num2 = key.GetHashCode() & (int_2.Length - 1);
		int num3 = int_2[num2] - 1;
		while (true)
		{
			if ((uint)num3 < (uint)array.Length)
			{
				if (key.Equals(array[num3].gparam_0))
				{
					break;
				}
				if (num == array.Length)
				{
					ThrowHelper.ThrowInvalidOperationException_ConcurrentOperationsNotSupported();
				}
				num++;
				num3 = array[num3].int_0;
				continue;
			}
			return ref method_0(key, num2);
		}
		return ref array[num3].tasYympqeTT;
	}

	private ref TValue method_0(TKey gparam_0, int int_3)
	{
		Struct49[] array = struct49_1;
		int num;
		if (int_1 != -1)
		{
			num = int_1;
			int_1 = -3 - array[int_1].int_0;
		}
		else
		{
			if (int_0 == array.Length || array.Length == 1)
			{
				array = Resize();
				int_3 = gparam_0.GetHashCode() & (int_2.Length - 1);
			}
			num = int_0;
		}
		array[num].gparam_0 = gparam_0;
		array[num].int_0 = int_2[int_3] - 1;
		int_2[int_3] = num + 1;
		int_0++;
		return ref array[num].tasYympqeTT;
	}

	private Struct49[] Resize()
	{
		int num = int_0;
		int num2 = struct49_1.Length * 2;
		if ((uint)num2 > 2147483647u)
		{
			throw new InvalidOperationException(Class72.smethod_14(1945358));
		}
		Struct49[] array = new Struct49[num2];
		Array.Copy(struct49_1, 0, array, 0, num);
		int[] array2 = new int[array.Length];
		while (num-- > 0)
		{
			int num3 = array[num].gparam_0.GetHashCode() & (array2.Length - 1);
			array[num].int_0 = array2[num3] - 1;
			array2[num3] = num + 1;
		}
		int_2 = array2;
		struct49_1 = array;
		return array;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}

	static DictionarySlim()
	{
		Class72.smethod_20();
		struct49_0 = new Struct49[1];
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
