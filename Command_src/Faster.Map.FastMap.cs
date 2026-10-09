using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Faster.Map.Core;

namespace Faster.Map;

public class FastMap<TKey, TValue> where TKey : unmanaged
{
	[CompilerGenerated]
	private int int_0;

	private InfoByte[] infoByte_0;

	private FastEntry<TKey, TValue>[] fastEntry_0;

	private uint AevewUatKtc;

	private readonly double double_0;

	private int int_1 = 32;

	private uint uint_0;

	private byte byte_0;

	private uint MhveoHlyXjb;

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

	public uint Size => (uint)fastEntry_0.Length;

	public IEnumerable<KeyValuePair<TKey, TValue>> Entries
	{
		get
		{
			int i = infoByte_0.Length - 1;
			while (i >= 0)
			{
				if (!infoByte_0[i].IsEmpty())
				{
					FastEntry<TKey, TValue> fastEntry = fastEntry_0[i];
					yield return new KeyValuePair<TKey, TValue>(fastEntry.Key, fastEntry.Value);
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
					yield return fastEntry_0[i].Key;
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
					yield return fastEntry_0[i].Value;
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

	public FastMap()
		: this(8u, 0.5)
	{
	}

	public FastMap(uint length)
		: this(length, 0.5)
	{
	}

	public FastMap(uint length, double loadFactor)
	{
		AevewUatKtc = ((length == 0) ? 8u : length);
		double_0 = loadFactor;
		uint num = smethod_0(AevewUatKtc);
		uint_0 = ((double_0 <= 0.5) ? smethod_1(AevewUatKtc) : method_4(AevewUatKtc));
		MhveoHlyXjb = (uint)((double)num * loadFactor);
		int_1 = int_1 - smethod_1(AevewUatKtc) + 1;
		fastEntry_0 = new FastEntry<TKey, TValue>[num + uint_0 + 1];
		infoByte_0 = new InfoByte[num + uint_0 + 1];
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Emplace(TKey key, TValue value)
	{
		if (Count >= MhveoHlyXjb)
		{
			Resize();
		}
		int int_ = key.GetHashCode();
		uint num = (uint)(int_ * -1640531527) >> int_1;
		if (method_5(ref int_, num))
		{
			return false;
		}
		FastEntry<TKey, TValue> fastEntry_ = new FastEntry<TKey, TValue>
		{
			Value = value,
			Key = key
		};
		InfoByte infoByte_ = new InfoByte
		{
			Psl = 0
		};
		ref InfoByte reference = ref infoByte_0[num];
		int count;
		while (true)
		{
			if (byte_0 < infoByte_.Psl)
			{
				byte_0 = infoByte_.Psl;
			}
			if (reference.IsEmpty())
			{
				break;
			}
			if (infoByte_.Psl > reference.Psl)
			{
				method_2(ref fastEntry_, ref fastEntry_0[num]);
				method_3(ref infoByte_, ref reference);
				continue;
			}
			if (infoByte_.Psl != uint_0)
			{
				reference = ref infoByte_0[++num];
				byte psl = (byte)(infoByte_.Psl + 1);
				infoByte_.Psl = psl;
				continue;
			}
			count = Count + 1;
			Count = count;
			Resize();
			method_1(ref fastEntry_, ref infoByte_);
			return true;
		}
		fastEntry_0[num] = fastEntry_;
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
		uint num2 = num + byte_0;
		do
		{
			ref FastEntry<TKey, TValue> reference = ref fastEntry_0[num];
			if (hashCode != reference.Key.GetHashCode())
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
		uint num2 = num + byte_0;
		do
		{
			if (hashCode == fastEntry_0[num].Key.GetHashCode())
			{
				fastEntry_0[num].Value = value;
				return true;
			}
		}
		while (++num <= num2);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Remove(TKey key)
	{
		int hashCode = key.GetHashCode();
		uint uint_ = (uint)(hashCode * -1640531527) >> int_1;
		uint num = uint_ + byte_0;
		do
		{
			ref FastEntry<TKey, TValue> reference = ref fastEntry_0[uint_];
			if (hashCode == reference.Key.GetHashCode())
			{
				reference = default(FastEntry<TKey, TValue>);
				infoByte_0[uint_] = default(InfoByte);
				int count = Count - 1;
				Count = count;
				method_0(ref uint_);
				return true;
			}
		}
		while (++uint_ <= num);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Contains(TKey key)
	{
		int hashCode = key.GetHashCode();
		uint num = (uint)(hashCode * -1640531527) >> int_1;
		uint num2 = num + byte_0;
		do
		{
			if (hashCode == fastEntry_0[num].Key.GetHashCode())
			{
				return true;
			}
		}
		while (++num <= num2);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Copy(FastMap<TKey, TValue> fastMap)
	{
		for (int i = 0; i < fastMap.fastEntry_0.Length; i++)
		{
			InfoByte infoByte = fastMap.infoByte_0[i];
			if (!infoByte.IsEmpty())
			{
				FastEntry<TKey, TValue> fastEntry = fastMap.fastEntry_0[i];
				Emplace(fastEntry.Key, fastEntry.Value);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int IndexOf(TKey key)
	{
		int hashCode = key.GetHashCode();
		int num = 0;
		while (true)
		{
			if (num < fastEntry_0.Length)
			{
				InfoByte infoByte = infoByte_0[num];
				if (!infoByte.IsEmpty() && fastEntry_0[num].Key.GetHashCode() == hashCode)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public void Clear()
	{
		for (int i = 0; i < fastEntry_0.Length; i++)
		{
			infoByte_0[i] = default(InfoByte);
			fastEntry_0[i] = default(FastEntry<TKey, TValue>);
		}
		Count = 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void method_0(ref uint uint_1)
	{
		ref InfoByte reference = ref infoByte_0[++uint_1];
		while (!reference.IsEmpty() && reference.Psl != 0)
		{
			reference.Psl--;
			method_3(ref reference, ref infoByte_0[uint_1 - 1]);
			method_2(ref fastEntry_0[uint_1], ref fastEntry_0[uint_1 - 1]);
			reference = ref infoByte_0[++uint_1];
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void method_1(ref FastEntry<TKey, TValue> fastEntry_1, ref InfoByte infoByte_1)
	{
		uint num = (uint)(fastEntry_1.Key.GetHashCode() * -1640531527) >> int_1;
		infoByte_1.Psl = 0;
		ref InfoByte reference = ref infoByte_0[num];
		while (true)
		{
			if (byte_0 < infoByte_1.Psl)
			{
				byte_0 = infoByte_1.Psl;
			}
			if (reference.IsEmpty())
			{
				break;
			}
			if (infoByte_1.Psl <= reference.Psl)
			{
				reference = ref infoByte_0[++num];
				byte psl = (byte)(infoByte_1.Psl + 1);
				infoByte_1.Psl = psl;
			}
			else
			{
				method_2(ref fastEntry_1, ref fastEntry_0[num]);
				method_3(ref infoByte_1, ref infoByte_0[num]);
			}
		}
		fastEntry_0[num] = fastEntry_1;
		reference = infoByte_1;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void method_2(ref FastEntry<TKey, TValue> fastEntry_1, ref FastEntry<TKey, TValue> fastEntry_2)
	{
		FastEntry<TKey, TValue> fastEntry = fastEntry_1;
		fastEntry_1 = fastEntry_2;
		fastEntry_2 = fastEntry;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void method_3(ref InfoByte infoByte_1, ref InfoByte infoByte_2)
	{
		InfoByte infoByte = infoByte_1;
		infoByte_1 = infoByte_2;
		infoByte_2 = infoByte;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private uint method_4(uint uint_1)
	{
		int result;
		if (uint_1 > 65536)
		{
			if (uint_1 <= 4194304)
			{
				if (uint_1 > 524288)
				{
					switch (uint_1)
					{
					case 4194304u:
						return 70u;
					case 2097152u:
						return 65u;
					case 1048576u:
						return 60u;
					}
					result = 10;
				}
				else
				{
					switch (uint_1)
					{
					case 524288u:
						return 55u;
					case 262144u:
						return 50u;
					case 131072u:
						return 45u;
					}
					result = 10;
				}
			}
			else if (uint_1 > 33554432)
			{
				if (uint_1 > 134217728)
				{
					switch (uint_1)
					{
					case 536870912u:
						return 105u;
					case 268435456u:
						return 100u;
					}
					result = 10;
				}
				else
				{
					switch (uint_1)
					{
					case 134217728u:
						return 95u;
					case 67108864u:
						return 90u;
					}
					result = 10;
				}
			}
			else
			{
				switch (uint_1)
				{
				case 33554432u:
					return 85u;
				case 16777216u:
					return 80u;
				case 8388608u:
					return 75u;
				}
				result = 10;
			}
		}
		else if (uint_1 > 512)
		{
			if (uint_1 <= 4096)
			{
				switch (uint_1)
				{
				case 4096u:
					return 20u;
				case 2048u:
					return 15u;
				case 1024u:
					return 12u;
				}
				result = 10;
			}
			else if (uint_1 <= 16384)
			{
				switch (uint_1)
				{
				case 16384u:
					return 30u;
				case 8192u:
					return 25u;
				}
				result = 10;
			}
			else
			{
				switch (uint_1)
				{
				case 65536u:
					return 40u;
				case 32768u:
					return 35u;
				}
				result = 10;
			}
		}
		else if (uint_1 > 64)
		{
			switch (uint_1)
			{
			case 512u:
				return 9u;
			case 256u:
				return 8u;
			case 128u:
				return 7u;
			}
			result = 10;
		}
		else
		{
			if (uint_1 == 16)
			{
				return 4u;
			}
			if (uint_1 == 32)
			{
				return 5u;
			}
			if (uint_1 == 64)
			{
				return 6u;
			}
			result = 10;
		}
		return (uint)result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool method_5(ref int int_2, uint uint_1)
	{
		uint num = uint_1 + byte_0;
		do
		{
			ref FastEntry<TKey, TValue> reference = ref fastEntry_0[uint_1];
			if (int_2 == reference.Key.GetHashCode())
			{
				return true;
			}
		}
		while (++uint_1 <= num);
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Resize()
	{
		int_1--;
		AevewUatKtc = smethod_0(AevewUatKtc + 1);
		uint_0 = ((double_0 <= 0.5) ? smethod_1(AevewUatKtc) : method_4(AevewUatKtc));
		MhveoHlyXjb = (uint)((double)AevewUatKtc * double_0);
		FastEntry<TKey, TValue>[] array = new FastEntry<TKey, TValue>[fastEntry_0.Length];
		Array.Copy(fastEntry_0, array, fastEntry_0.Length);
		byte_0 = 0;
		InfoByte[] array2 = new InfoByte[infoByte_0.Length];
		Array.Copy(infoByte_0, array2, infoByte_0.Length);
		fastEntry_0 = new FastEntry<TKey, TValue>[AevewUatKtc + uint_0 + 1];
		infoByte_0 = new InfoByte[AevewUatKtc + uint_0 + 1];
		for (int i = 0; i < array.Length; i++)
		{
			InfoByte infoByte_ = array2[i];
			if (!infoByte_.IsEmpty())
			{
				FastEntry<TKey, TValue> fastEntry_ = array[i];
				method_1(ref fastEntry_, ref infoByte_);
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

	static FastMap()
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
