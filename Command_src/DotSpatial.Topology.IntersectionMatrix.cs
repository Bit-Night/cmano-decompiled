using System;
using System.Text;

namespace DotSpatial.Topology;

public class IntersectionMatrix : GInterface7
{
	private readonly DimensionType[,] dimensionType_0;

	public DimensionType this[LocationType row, LocationType column]
	{
		get
		{
			return Get(row, column);
		}
		set
		{
			Set(row, column, value);
		}
	}

	public IntersectionMatrix()
	{
		dimensionType_0 = new DimensionType[3, 3];
		SetAll(DimensionType.False);
	}

	public IntersectionMatrix(string elements)
		: this()
	{
		Set(elements);
	}

	public IntersectionMatrix(IntersectionMatrix other)
		: this()
	{
		dimensionType_0[0, 0] = other.dimensionType_0[0, 0];
		dimensionType_0[0, 1] = other.dimensionType_0[0, 1];
		dimensionType_0[0, 2] = other.dimensionType_0[0, 2];
		dimensionType_0[1, 0] = other.dimensionType_0[1, 0];
		dimensionType_0[1, 1] = other.dimensionType_0[1, 1];
		dimensionType_0[1, 2] = other.dimensionType_0[1, 2];
		dimensionType_0[2, 0] = other.dimensionType_0[2, 0];
		dimensionType_0[2, 1] = other.dimensionType_0[2, 1];
		dimensionType_0[2, 2] = other.dimensionType_0[2, 2];
	}

	public virtual void Add(GInterface7 im)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				SetAtLeast((LocationType)i, (LocationType)j, im.Get((LocationType)i, (LocationType)j));
			}
		}
	}

	public virtual void Set(LocationType row, LocationType column, DimensionType dimensionValue)
	{
		dimensionType_0[(int)row, (int)column] = dimensionValue;
	}

	public void Set(string dimensionSymbols)
	{
		for (int i = 0; i < dimensionSymbols.Length; i++)
		{
			int num = i / 3;
			int num2 = i % 3;
			dimensionType_0[num, num2] = Dimension.ToDimensionValue(dimensionSymbols[i]);
		}
	}

	public virtual void SetAtLeast(LocationType row, LocationType column, DimensionType minimumDimensionValue)
	{
		if (dimensionType_0[(int)row, (int)column] < minimumDimensionValue)
		{
			dimensionType_0[(int)row, (int)column] = minimumDimensionValue;
		}
	}

	public virtual void SetAtLeastIfValid(LocationType row, LocationType column, DimensionType minimumDimensionValue)
	{
		if (row >= LocationType.Interior && column >= LocationType.Interior)
		{
			SetAtLeast(row, column, minimumDimensionValue);
		}
	}

	public virtual void SetAtLeast(string minimumDimensionSymbols)
	{
		for (int i = 0; i < minimumDimensionSymbols.Length; i++)
		{
			int row = i / 3;
			int column = i % 3;
			SetAtLeast((LocationType)row, (LocationType)column, Dimension.ToDimensionValue(minimumDimensionSymbols[i]));
		}
	}

	public void SetAll(DimensionType dimensionValue)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				dimensionType_0[i, j] = dimensionValue;
			}
		}
	}

	public virtual DimensionType Get(LocationType row, LocationType column)
	{
		return dimensionType_0[(int)row, (int)column];
	}

	public virtual bool IsDisjoint()
	{
		if (dimensionType_0[0, 0] == DimensionType.False && dimensionType_0[0, 1] == DimensionType.False && dimensionType_0[1, 0] == DimensionType.False)
		{
			return dimensionType_0[1, 1] == DimensionType.False;
		}
		return false;
	}

	public virtual bool IsIntersects()
	{
		return !IsDisjoint();
	}

	public virtual bool IsTouches(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB)
	{
		if (dimensionOfGeometryA <= dimensionOfGeometryB)
		{
			if ((dimensionOfGeometryA != DimensionType.Surface || dimensionOfGeometryB != DimensionType.Surface) && (dimensionOfGeometryA != DimensionType.Curve || dimensionOfGeometryB != DimensionType.Curve) && (dimensionOfGeometryA != DimensionType.Curve || dimensionOfGeometryB != DimensionType.Surface) && (dimensionOfGeometryA != DimensionType.Point || dimensionOfGeometryB != DimensionType.Surface))
			{
				int result;
				if (dimensionOfGeometryA != DimensionType.Point)
				{
					result = 0;
				}
				else
				{
					if (dimensionOfGeometryB == DimensionType.Curve)
					{
						goto IL_0030;
					}
					result = 0;
				}
				return (byte)result != 0;
			}
			goto IL_0030;
		}
		return IsTouches(dimensionOfGeometryB, dimensionOfGeometryA);
		IL_0030:
		if (dimensionType_0[0, 0] == DimensionType.False)
		{
			if (!Matches(dimensionType_0[0, 1], 'T') && !Matches(dimensionType_0[1, 0], 'T'))
			{
				return Matches(dimensionType_0[1, 1], 'T');
			}
			return true;
		}
		return false;
	}

	public virtual bool IsCrosses(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB)
	{
		if ((dimensionOfGeometryA == DimensionType.Point && dimensionOfGeometryB == DimensionType.Curve) || (dimensionOfGeometryA == DimensionType.Point && dimensionOfGeometryB == DimensionType.Surface) || (dimensionOfGeometryA == DimensionType.Curve && dimensionOfGeometryB == DimensionType.Surface))
		{
			if (Matches(dimensionType_0[0, 0], 'T'))
			{
				return Matches(dimensionType_0[0, 2], 'T');
			}
			return false;
		}
		if ((dimensionOfGeometryA == DimensionType.Curve && dimensionOfGeometryB == DimensionType.Point) || (dimensionOfGeometryA == DimensionType.Surface && dimensionOfGeometryB == DimensionType.Point) || (dimensionOfGeometryA == DimensionType.Surface && dimensionOfGeometryB == DimensionType.Curve))
		{
			if (Matches(dimensionType_0[0, 0], 'T'))
			{
				return Matches(dimensionType_0[2, 0], 'T');
			}
			return false;
		}
		if (dimensionOfGeometryA == DimensionType.Curve && dimensionOfGeometryB == DimensionType.Curve)
		{
			return dimensionType_0[0, 0] == DimensionType.Point;
		}
		return false;
	}

	public virtual bool IsWithin()
	{
		int result;
		if (Matches(dimensionType_0[0, 0], 'T'))
		{
			if (dimensionType_0[0, 2] == DimensionType.False)
			{
				return dimensionType_0[1, 2] == DimensionType.False;
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual bool IsContains()
	{
		int result;
		if (!Matches(dimensionType_0[0, 0], 'T'))
		{
			result = 0;
		}
		else
		{
			if (dimensionType_0[2, 0] == DimensionType.False)
			{
				return dimensionType_0[2, 1] == DimensionType.False;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual bool IsCovers()
	{
		if ((Matches(dimensionType_0[0, 0], 'T') || Matches(dimensionType_0[0, 1], 'T') || Matches(dimensionType_0[1, 0], 'T') || Matches(dimensionType_0[1, 1], 'T')) && dimensionType_0[2, 0] == DimensionType.False)
		{
			return dimensionType_0[2, 1] == DimensionType.False;
		}
		return false;
	}

	public virtual bool IsEquals(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB)
	{
		if (dimensionOfGeometryA != dimensionOfGeometryB)
		{
			return false;
		}
		int result;
		if (!Matches(dimensionType_0[0, 0], 'T'))
		{
			result = 0;
		}
		else
		{
			if (dimensionType_0[2, 0] == DimensionType.False && dimensionType_0[0, 2] == DimensionType.False && dimensionType_0[2, 1] == DimensionType.False)
			{
				return dimensionType_0[1, 2] == DimensionType.False;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual bool IsOverlaps(DimensionType dimensionOfGeometryA, DimensionType dimensionOfGeometryB)
	{
		if ((dimensionOfGeometryA == DimensionType.Point && dimensionOfGeometryB == DimensionType.Point) || (dimensionOfGeometryA == DimensionType.Surface && dimensionOfGeometryB == DimensionType.Surface))
		{
			if (Matches(dimensionType_0[0, 0], 'T') && Matches(dimensionType_0[0, 2], 'T'))
			{
				return Matches(dimensionType_0[2, 0], 'T');
			}
			return false;
		}
		if (dimensionOfGeometryA == DimensionType.Curve && dimensionOfGeometryB == DimensionType.Curve)
		{
			if (dimensionType_0[0, 0] == DimensionType.Curve && Matches(dimensionType_0[0, 2], 'T'))
			{
				return Matches(dimensionType_0[2, 0], 'T');
			}
			return false;
		}
		return false;
	}

	public virtual bool Matches(string requiredDimensionSymbols)
	{
		if (requiredDimensionSymbols.Length != 9)
		{
			throw new ArgumentException("Should be length 9: " + requiredDimensionSymbols);
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (!Matches(dimensionType_0[i, j], requiredDimensionSymbols[3 * i + j]))
				{
					return false;
				}
			}
		}
		return true;
	}

	public virtual GInterface7 Transpose()
	{
		DimensionType dimensionType = dimensionType_0[1, 0];
		dimensionType_0[1, 0] = dimensionType_0[0, 1];
		dimensionType_0[0, 1] = dimensionType;
		dimensionType = dimensionType_0[2, 0];
		dimensionType_0[2, 0] = dimensionType_0[0, 2];
		dimensionType_0[0, 2] = dimensionType;
		dimensionType = dimensionType_0[2, 1];
		dimensionType_0[2, 1] = dimensionType_0[1, 2];
		dimensionType_0[1, 2] = dimensionType;
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("123456789");
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				stringBuilder[3 * i + j] = Dimension.ToDimensionSymbol(dimensionType_0[i, j]);
			}
		}
		return stringBuilder.ToString();
	}

	public static bool Matches(DimensionType actualDimensionValue, char requiredDimensionSymbol)
	{
		switch (requiredDimensionSymbol)
		{
		case '*':
			return true;
		case 'T':
		{
			int result;
			if (actualDimensionValue >= DimensionType.Point)
			{
				result = 1;
			}
			else
			{
				if (actualDimensionValue != DimensionType.True)
				{
					break;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
		}
		if (requiredDimensionSymbol == 'F' && actualDimensionValue == DimensionType.False)
		{
			return true;
		}
		if (requiredDimensionSymbol == '0' && actualDimensionValue == DimensionType.Point)
		{
			return true;
		}
		if (requiredDimensionSymbol == '1' && actualDimensionValue == DimensionType.Curve)
		{
			return true;
		}
		if (requiredDimensionSymbol == '2' && actualDimensionValue == DimensionType.Surface)
		{
			return true;
		}
		return false;
	}

	public static bool Matches(string actualDimensionSymbols, string requiredDimensionSymbols)
	{
		return new IntersectionMatrix(actualDimensionSymbols).Matches(requiredDimensionSymbols);
	}

	static IntersectionMatrix()
	{
		Class72.smethod_20();
	}
}
