using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSMaterial;

public struct Pos : IEquatable<Pos>
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private int int_1;

	public int X
	{
		[CompilerGenerated]
		readonly get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public int Y
	{
		[CompilerGenerated]
		readonly get
		{
			return int_1;
		}
		[CompilerGenerated]
		private set
		{
			int_1 = value;
		}
	}

	public Pos(int x, int y)
	{
		X = x;
		Y = y;
	}

	public bool Equals(Pos other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Pos))
		{
			return false;
		}
		return Equals((Pos)obj);
	}

	public override int GetHashCode()
	{
		return (X * 397) ^ Y;
	}

	public string GetHashCodeString(StringBuilder theBuilder)
	{
		theBuilder.Append(X.ToString()).Append("_").Append(Y.ToString());
		return theBuilder.ToString();
	}

	public static bool operator ==(Pos left, Pos right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(Pos left, Pos right)
	{
		return !left.Equals(right);
	}

	static Pos()
	{
		Class72.smethod_20();
	}
}
