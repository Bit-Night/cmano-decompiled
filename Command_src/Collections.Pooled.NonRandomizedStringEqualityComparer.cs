using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Collections.Pooled;

[Serializable]
public sealed class NonRandomizedStringEqualityComparer : EqualityComparer<string>, ISerializable
{
	private static readonly int int_0;

	[CompilerGenerated]
	private static readonly IEqualityComparer<string> iequalityComparer_0;

	internal new static IEqualityComparer<string> Default
	{
		[CompilerGenerated]
		get
		{
			return iequalityComparer_0;
		}
	}

	private NonRandomizedStringEqualityComparer()
	{
	}

	private NonRandomizedStringEqualityComparer(SerializationInfo information, StreamingContext context)
	{
	}

	public sealed override bool Equals(string x, string y)
	{
		return string.Equals(x, y);
	}

	public sealed override int GetHashCode(string str)
	{
		if (str != null)
		{
			if (str.Length == 0)
			{
				return int_0;
			}
			return smethod_0(str);
		}
		return 0;
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.SetType(typeof(NonRandomizedStringEqualityComparer));
	}

	private unsafe static int smethod_0(string string_0)
	{
		ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(string_0);
		fixed (char* ptr = readOnlySpan)
		{
			uint num = 352654597u;
			uint num2 = 352654597u;
			uint* ptr2 = (uint*)ptr;
			int num3 = readOnlySpan.Length;
			while (num3 > 2)
			{
				num3 -= 4;
				num = (((num << 5) | (num >> 27)) + num) ^ *ptr2;
				num2 = (((num2 << 5) | (num2 >> 27)) + num2) ^ ptr2[1];
				ptr2 += 2;
			}
			if (num3 > 0)
			{
				num2 = (((num2 << 5) | (num2 >> 27)) + num2) ^ *ptr2;
			}
			return (int)(num + num2 * 1566083941);
		}
	}

	static NonRandomizedStringEqualityComparer()
	{
		Class72.smethod_20();
		int_0 = string.Empty.GetHashCode();
		iequalityComparer_0 = new NonRandomizedStringEqualityComparer();
	}
}
