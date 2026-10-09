using System;
using System.Buffers;

public sealed class PooledStringBuilder : IDisposable
{
	private char[] char_0;

	private int int_0;

	private bool bool_0;

	public int Length
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value < 0 || value > char_0.Length)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			int_0 = value;
		}
	}

	public int Capacity
	{
		get
		{
			char[] array = char_0;
			if (array != null)
			{
				return array.Length;
			}
			return 0;
		}
	}

	public PooledStringBuilder(int initialCapacity = 256)
	{
		char_0 = ArrayPool<char>.Shared.Rent(initialCapacity);
		int_0 = 0;
		bool_0 = false;
	}

	public void Append(char c)
	{
		method_0(1);
		char_0[int_0++] = c;
	}

	public void Append(string s)
	{
		if (!string.IsNullOrEmpty(s))
		{
			method_0(s.Length);
			s.CopyTo(0, char_0, int_0, s.Length);
			int_0 += s.Length;
		}
	}

	public void Append(char[] chars)
	{
		if (chars != null && chars.Length != 0)
		{
			method_0(chars.Length);
			Array.Copy(chars, 0, char_0, int_0, chars.Length);
			int_0 += chars.Length;
		}
	}

	public void Append(char[] chars, int startIndex, int count)
	{
		if (chars != null && count != 0)
		{
			method_0(count);
			Array.Copy(chars, startIndex, char_0, int_0, count);
			int_0 += count;
		}
	}

	public void Append(ReadOnlySpan<char> chars)
	{
		if (chars.Length != 0)
		{
			method_0(chars.Length);
			chars.CopyTo(new Span<char>(char_0, int_0, chars.Length));
			int_0 += chars.Length;
		}
	}

	public void AppendLine()
	{
		Append(Environment.NewLine);
	}

	public void AppendLine(string s)
	{
		Append(s);
		AppendLine();
	}

	public void Clear()
	{
		int_0 = 0;
	}

	public ReadOnlySpan<char> AsSpan()
	{
		return new ReadOnlySpan<char>(char_0, 0, int_0);
	}

	public override string ToString()
	{
		return new string(char_0, 0, int_0);
	}

	public string ToStringAndDispose()
	{
		string result = ToString();
		Dispose();
		return result;
	}

	private void method_0(int int_1)
	{
		if (int_0 + int_1 > char_0.Length)
		{
			method_1(int_1);
		}
	}

	private void method_1(int int_1)
	{
		int minimumLength = Math.Max(int_0 + int_1, char_0.Length * 2);
		char[] destinationArray = ArrayPool<char>.Shared.Rent(minimumLength);
		Array.Copy(char_0, 0, destinationArray, 0, int_0);
		ArrayPool<char>.Shared.Return(char_0);
		char_0 = destinationArray;
	}

	public void Dispose()
	{
		if (!bool_0)
		{
			if (char_0 != null)
			{
				ArrayPool<char>.Shared.Return(char_0);
				char_0 = null;
			}
			bool_0 = true;
		}
	}

	static PooledStringBuilder()
	{
		Class72.smethod_20();
	}
}
