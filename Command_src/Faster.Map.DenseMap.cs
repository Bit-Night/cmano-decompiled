using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Faster.Map.Core;

namespace Faster.Map;

public class DenseMap<TKey, TValue>
{
	[CompilerGenerated]
	private int int_0;

	private InfoByte[] infoByte_0;

	private Entry<TKey, TValue>[] entry_0;

	private uint uint_0;

	private readonly double double_0;

	private int int_1 = 32;

	private byte byte_0;

	private byte byte_1;

	private readonly IEqualityComparer<TKey> iequalityComparer_0;

	private int int_2;

	internal static object object_0;

	public int Count
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public uint Size => (uint)entry_0.Length;

	public IEnumerable<KeyValuePair<TKey, TValue>> Entries
	{
		get
		{
			int i = infoByte_0.Length - 1;
			while (i >= 0)
			{
				if (!infoByte_0[i].IsEmpty())
				{
					Entry<TKey, TValue> entry = entry_0[i];
					yield return new KeyValuePair<TKey, TValue>(entry.Key, entry.Value);
				}
				int num = i - 1;
				i = num;
			}
		}
	}

	public IEnumerable<TKey> Keys
	{
		get
		{
			int i = infoByte_0.Length - 1;
			while (i >= 0)
			{
				if (!infoByte_0[i].IsEmpty())
				{
					yield return entry_0[i].Key;
				}
				int num = i - 1;
				i = num;
			}
		}
	}

	public IEnumerable<TValue> Values
	{
		get
		{
			int i = infoByte_0.Length - 1;
			while (i >= 0)
			{
				if (!infoByte_0[i].IsEmpty())
				{
					yield return entry_0[i].Value;
				}
				int num = i - 1;
				i = num;
			}
		}
	}

	public TValue this[TKey key]
	{
		get
		{
			if (!Get(key, out var value))
			{
				throw new KeyNotFoundException($"Unable to find entry - {key.GetType().FullName} key - {key.GetHashCode()}");
			}
			return value;
		}
		set
		{
			if (!Update(key, value))
			{
				throw new KeyNotFoundException($"Unable to find entry - {key.GetType().FullName} key - {key.GetHashCode()}");
			}
		}
	}

	public DenseMap()
		: this(8u, 0.5, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
	{
	}

	public DenseMap(uint length)
		: this(length, 0.5, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
	{
	}

	public DenseMap(uint length, double loadFactor)
		: this(length, loadFactor, (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default)
	{
	}

	public DenseMap(uint length, double loadFactor, IEqualityComparer<TKey> keyComparer)
	{
		uint_0 = length;
		double_0 = loadFactor;
		uint num = smethod_0(uint_0);
		byte_0 = ((loadFactor <= 0.5) ? smethod_1(num) : method_5(num));
		int_2 = (int)((double)num * loadFactor);
		iequalityComparer_0 = keyComparer ?? EqualityComparer<TKey>.Default;
		int_1 = int_1 - smethod_1(uint_0) + 1;
		entry_0 = new Entry<TKey, TValue>[num + byte_0 + 1];
		infoByte_0 = new InfoByte[num + byte_0 + 1];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Emplace(TKey key, TValue value)
	{
		if (Count >= int_2)
		{
			Resize();
		}
		int int_ = key.GetHashCode();
		uint num = (uint)(int_ * -1640531527) >> int_1;
		if (method_0(ref int_, num, key))
		{
			return false;
		}
		Entry<TKey, TValue> entry_ = new Entry<TKey, TValue>
		{
			Value = value,
			Key = key,
			Hashcode = int_
		};
		InfoByte infoByte_ = new InfoByte
		{
			Psl = 0
		};
		ref InfoByte reference = ref infoByte_0[num];
		int count;
		while (true)
		{
			if (byte_1 < infoByte_.Psl)
			{
				byte_1 = infoByte_.Psl;
			}
			if (reference.IsEmpty())
			{
				break;
			}
			if (infoByte_.Psl > reference.Psl)
			{
				method_3(ref entry_, ref entry_0[num]);
				method_4(ref infoByte_, ref reference);
				continue;
			}
			if (infoByte_.Psl != byte_0)
			{
				reference = ref infoByte_0[++num];
				byte psl = (byte)(infoByte_.Psl + 1);
				infoByte_.Psl = psl;
				continue;
			}
			count = Count + 1;
			Count = count;
			Resize();
			method_1(entry_, infoByte_);
			return true;
		}
		entry_0[num] = entry_;
		reference = infoByte_;
		count = Count + 1;
		Count = count;
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Get(TKey key, out TValue value)
	{
		int hashCode = key.GetHashCode();
		uint num = (uint)(hashCode * -1640531527) >> int_1;
		uint num2 = num + byte_1;
		do
		{
			ref Entry<TKey, TValue> reference = ref entry_0[num];
			if (hashCode != reference.Hashcode || !iequalityComparer_0.Equals(key, reference.Key))
			{
				num++;
				continue;
			}
			value = reference.Value;
			return true;
		}
		while (num <= num2);
		value = default(TValue);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Update(TKey key, TValue value)
	{
		int hashCode = key.GetHashCode();
		uint num = (uint)(hashCode * -1640531527) >> int_1;
		uint num2 = num + byte_1;
		do
		{
			ref Entry<TKey, TValue> reference = ref entry_0[num];
			if (hashCode != reference.Hashcode || !iequalityComparer_0.Equals(key, reference.Key))
			{
				num++;
				continue;
			}
			reference.Value = value;
			return true;
		}
		while (num <= num2);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Remove(TKey key)
	{
		int hashCode = key.GetHashCode();
		uint num = (uint)(hashCode * -1640531527) >> int_1;
		uint num2 = num + byte_1;
		do
		{
			ref Entry<TKey, TValue> reference = ref entry_0[num];
			if (hashCode != reference.Hashcode || !iequalityComparer_0.Equals(key, reference.Key))
			{
				num++;
				continue;
			}
			reference = default(Entry<TKey, TValue>);
			infoByte_0[num] = default(InfoByte);
			int count = Count - 1;
			Count = count;
			method_2(num);
			return true;
		}
		while (num <= num2);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Contains(TKey key)
	{
		int hashCode = key.GetHashCode();
		uint num = (uint)(hashCode * -1640531527) >> int_1;
		InfoByte infoByte = infoByte_0[num];
		if (infoByte.IsEmpty())
		{
			return false;
		}
		uint num2 = num + byte_1;
		do
		{
			Entry<TKey, TValue> entry = entry_0[num];
			if (hashCode != entry.Hashcode || !iequalityComparer_0.Equals(key, entry.Key))
			{
				entry = entry_0[++num];
				if (hashCode == entry.Hashcode && iequalityComparer_0.Equals(key, entry.Key))
				{
					return true;
				}
				continue;
			}
			return true;
		}
		while (++num <= num2);
		return false;
	}

	public void Copy(DenseMap<TKey, TValue> denseMap)
	{
		for (int i = 0; i < denseMap.entry_0.Length; i++)
		{
			InfoByte infoByte = denseMap.infoByte_0[i];
			if (!infoByte.IsEmpty())
			{
				Entry<TKey, TValue> entry = denseMap.entry_0[i];
				Emplace(entry.Key, entry.Value);
			}
		}
	}

	public void Clear()
	{
		for (int i = 0; i < entry_0.Length; i++)
		{
			entry_0[i] = default(Entry<TKey, TValue>);
			infoByte_0[i] = default(InfoByte);
		}
		Count = 0;
	}

	public int IndexOf(TKey key)
	{
		int num = 0;
		while (true)
		{
			if (num < entry_0.Length)
			{
				InfoByte infoByte = infoByte_0[num];
				if (!infoByte.IsEmpty())
				{
					Entry<TKey, TValue> entry = entry_0[num];
					if (entry.Hashcode == key.GetHashCode() && iequalityComparer_0.Equals(key, entry.Key))
					{
						break;
					}
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool method_0(ref int int_3, uint uint_1, TKey gparam_0)
	{
		uint num = uint_1 + byte_1;
		do
		{
			ref Entry<TKey, TValue> reference = ref entry_0[uint_1];
			if (int_3 != reference.Hashcode || !iequalityComparer_0.Equals(gparam_0, reference.Key))
			{
				uint_1++;
				continue;
			}
			return true;
		}
		while (uint_1 <= num);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void method_1(Entry<TKey, TValue> entry_1, InfoByte infoByte_1)
	{
		uint num = (uint)(entry_1.Hashcode * -1640531527) >> int_1;
		infoByte_1.Psl = 0;
		ref InfoByte reference = ref infoByte_0[num];
		while (true)
		{
			if (byte_1 < infoByte_1.Psl)
			{
				byte_1 = infoByte_1.Psl;
			}
			if (reference.IsEmpty())
			{
				break;
			}
			if (infoByte_1.Psl <= reference.Psl)
			{
				if (infoByte_1.Psl == byte_0)
				{
					Resize();
					method_1(entry_1, infoByte_1);
					return;
				}
				reference = ref infoByte_0[++num];
				byte psl = (byte)(infoByte_1.Psl + 1);
				infoByte_1.Psl = psl;
			}
			else
			{
				method_3(ref entry_1, ref entry_0[num]);
				method_4(ref infoByte_1, ref reference);
			}
		}
		entry_0[num] = entry_1;
		reference = infoByte_1;
	}

	private void method_2(uint uint_1)
	{
		ref InfoByte reference = ref infoByte_0[++uint_1];
		while (!reference.IsEmpty() && reference.Psl != 0)
		{
			reference.Psl--;
			method_4(ref reference, ref infoByte_0[uint_1 - 1]);
			method_3(ref entry_0[uint_1], ref entry_0[uint_1 - 1]);
			reference = ref infoByte_0[++uint_1];
		}
	}

	private void method_3(ref Entry<TKey, TValue> entry_1, ref Entry<TKey, TValue> entry_2)
	{
		Entry<TKey, TValue> entry = entry_1;
		entry_1 = entry_2;
		entry_2 = entry;
	}

	private void method_4(ref InfoByte infoByte_1, ref InfoByte infoByte_2)
	{
		InfoByte infoByte = infoByte_1;
		infoByte_1 = infoByte_2;
		infoByte_2 = infoByte;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private byte method_5(uint uint_1)
	{
		int result;
		if (uint_1 <= 65536)
		{
			if (uint_1 <= 512)
			{
				if (uint_1 <= 64)
				{
					switch (uint_1)
					{
					case 64u:
						return 12;
					case 32u:
						return 8;
					case 16u:
						return 6;
					}
					result = 10;
				}
				else
				{
					switch (uint_1)
					{
					case 512u:
						return 24;
					case 256u:
						return 20;
					case 128u:
						return 16;
					}
					result = 10;
				}
			}
			else if (uint_1 > 4096)
			{
				if (uint_1 <= 16384)
				{
					switch (uint_1)
					{
					case 16384u:
						return 60;
					case 8192u:
						return 50;
					}
					result = 10;
				}
				else
				{
					switch (uint_1)
					{
					case 65536u:
						return 70;
					case 32768u:
						return 65;
					}
					result = 10;
				}
			}
			else
			{
				switch (uint_1)
				{
				case 4096u:
					return 40;
				case 2048u:
					return 36;
				case 1024u:
					return 32;
				}
				result = 10;
			}
		}
		else if (uint_1 <= 4194304)
		{
			if (uint_1 <= 524288)
			{
				switch (uint_1)
				{
				case 524288u:
					return 85;
				case 262144u:
					return 80;
				case 131072u:
					return 75;
				}
				result = 10;
			}
			else
			{
				switch (uint_1)
				{
				case 4194304u:
					return 98;
				case 2097152u:
					return 94;
				case 1048576u:
					return 90;
				}
				result = 10;
			}
		}
		else if (uint_1 <= 33554432)
		{
			switch (uint_1)
			{
			case 33554432u:
				return 108;
			case 16777216u:
				return 104;
			case 8388608u:
				return 102;
			}
			result = 10;
		}
		else if (uint_1 > 134217728)
		{
			switch (uint_1)
			{
			case 536870912u:
				return 124;
			case 268435456u:
				return 120;
			}
			result = 10;
		}
		else
		{
			if (uint_1 == 67108864)
			{
				return 112;
			}
			if (uint_1 == 134217728)
			{
				return 116;
			}
			result = 10;
		}
		return (byte)result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Resize()
	{
		int_1--;
		uint_0 = smethod_0(uint_0 + 1);
		byte_0 = ((double_0 <= 0.5) ? smethod_1(uint_0) : method_5(uint_0));
		int_2 = (int)((double)uint_0 * double_0);
		byte_1 = 0;
		Entry<TKey, TValue>[] array = new Entry<TKey, TValue>[entry_0.Length];
		Array.Copy(entry_0, array, entry_0.Length);
		InfoByte[] array2 = new InfoByte[entry_0.Length];
		Array.Copy(infoByte_0, array2, infoByte_0.Length);
		entry_0 = new Entry<TKey, TValue>[uint_0 + byte_0 + 1];
		infoByte_0 = new InfoByte[uint_0 + byte_0 + 1];
		for (int i = 0; i < array.Length; i++)
		{
			InfoByte infoByte_ = array2[i];
			if (!infoByte_.IsEmpty())
			{
				Entry<TKey, TValue> entry_ = array[i];
				method_1(entry_, infoByte_);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static uint smethod_0(uint uint_1)
	{
		uint_1--;
		uint_1 |= uint_1 >> 1;
		uint_1 |= uint_1 >> 2;
		uint_1 |= uint_1 >> 4;
		uint_1 |= uint_1 >> 8;
		uint_1 |= uint_1 >> 16;
		return ++uint_1;
	}

	private static byte smethod_1(uint uint_1)
	{
		byte b = 0;
		while (uint_1 != 0)
		{
			b++;
			uint_1 >>= 1;
		}
		return b;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal InfoByte Get(TKey key)
	{
		uint num = (uint)(key.GetHashCode() * -1640531527) >> int_1;
		InfoByte result = infoByte_0[num];
		if (result.IsEmpty())
		{
			return default(InfoByte);
		}
		return result;
	}

	static DenseMap()
	{
		Class72.smethod_20();
	}

	internal static bool smethod_2()
	{
		return object_0 == null;
	}

	internal static object smethod_3()
	{
		return object_0;
	}
}
