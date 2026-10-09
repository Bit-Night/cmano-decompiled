using System;
using System.Runtime.CompilerServices;

namespace DiskQueue.Implementation;

public sealed class Entry : IEquatable<Entry>
{
	[CompilerGenerated]
	private byte[] byte_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	[CompilerGenerated]
	private int int_2;

	public byte[] Data
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}

	public int FileNumber
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int Length
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public Entry(int fileNumber, int start, int length)
	{
		FileNumber = fileNumber;
		Start = start;
		Length = length;
	}

	public Entry(Operation operation)
		: this(operation.FileNumber, operation.Start, operation.Length)
	{
	}

	public bool Equals(Entry obj)
	{
		if ((object)obj != null)
		{
			if ((object)this == obj)
			{
				return true;
			}
			if (obj.FileNumber == FileNumber && obj.Start == Start)
			{
				return obj.Length == Length;
			}
			return false;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as Entry);
	}

	public override int GetHashCode()
	{
		return (((FileNumber * 397) ^ Start) * 397) ^ Length;
	}

	public static bool operator ==(Entry left, Entry right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Entry left, Entry right)
	{
		return !object.Equals(left, right);
	}

	static Entry()
	{
		Class72.smethod_20();
	}
}
