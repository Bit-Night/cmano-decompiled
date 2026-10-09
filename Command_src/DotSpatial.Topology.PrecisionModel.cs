using System;

namespace DotSpatial.Topology;

[Serializable]
public class PrecisionModel : IComparable
{
	public const double MAXIMUM_PRECISE_VALUE = 9007199254740992.0;

	private readonly PrecisionModelType precisionModelType_0;

	private double double_0;

	public virtual bool IsFloating
	{
		get
		{
			if (precisionModelType_0 != PrecisionModelType.Floating)
			{
				return precisionModelType_0 == PrecisionModelType.FloatingSingle;
			}
			return true;
		}
	}

	public virtual int MaximumSignificantDigits => precisionModelType_0 switch
	{
		PrecisionModelType.Floating => 16, 
		PrecisionModelType.FloatingSingle => 6, 
		PrecisionModelType.Fixed => 1 + (int)Math.Ceiling(Math.Log(Scale) / Math.Log(10.0)), 
		_ => throw new ArgumentOutOfRangeException(precisionModelType_0.ToString()), 
	};

	public virtual double Scale
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = Math.Abs(value);
		}
	}

	[Obsolete("Offsets are no longer used")]
	public virtual double OffsetX => 0.0;

	[Obsolete("Offsets are no longer used")]
	public virtual double OffsetY => 0.0;

	public PrecisionModel()
	{
		precisionModelType_0 = PrecisionModelType.Floating;
	}

	public PrecisionModel(PrecisionModelType modelType)
	{
		precisionModelType_0 = modelType;
		if (modelType == PrecisionModelType.Fixed)
		{
			double_0 = 1.0;
		}
	}

	public PrecisionModel(double scale)
	{
		precisionModelType_0 = PrecisionModelType.Fixed;
		double_0 = scale;
	}

	public PrecisionModel(PrecisionModel pm)
	{
		precisionModelType_0 = pm.precisionModelType_0;
		double_0 = pm.double_0;
	}

	public virtual int CompareTo(object o)
	{
		PrecisionModel obj = (PrecisionModel)o;
		int maximumSignificantDigits = MaximumSignificantDigits;
		int maximumSignificantDigits2 = obj.MaximumSignificantDigits;
		return maximumSignificantDigits.CompareTo(maximumSignificantDigits2);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual PrecisionModelType GetPrecisionModelType()
	{
		return precisionModelType_0;
	}

	[Obsolete("Use MakePrecise instead")]
	public virtual void ToInternal(Coordinate cexternal, Coordinate cinternal)
	{
		if (!IsFloating)
		{
			cinternal.X = MakePrecise(cexternal.X);
			cinternal.Y = MakePrecise(cexternal.Y);
		}
		else
		{
			cinternal.X = cexternal.X;
			cinternal.Y = cexternal.Y;
		}
		cinternal.Z = cexternal.Z;
	}

	[Obsolete("Use MakePrecise instead")]
	public virtual Coordinate ToInternal(Coordinate cexternal)
	{
		Coordinate coordinate = new Coordinate(cexternal);
		MakePrecise(coordinate);
		return coordinate;
	}

	[Obsolete("No longer needed, since internal representation is same as external representation")]
	public virtual Coordinate ToExternal(Coordinate cinternal)
	{
		return new Coordinate(cinternal);
	}

	[Obsolete("No longer needed, since internal representation is same as external representation")]
	public virtual void ToExternal(Coordinate cinternal, Coordinate cexternal)
	{
		cexternal.X = cinternal.X;
		cexternal.Y = cinternal.Y;
	}

	public virtual double MakePrecise(double val)
	{
		if (precisionModelType_0 == PrecisionModelType.FloatingSingle)
		{
			return (float)val;
		}
		if (precisionModelType_0 == PrecisionModelType.Fixed)
		{
			return Math.Floor(val * double_0 + 0.5) / double_0;
		}
		return val;
	}

	public virtual void MakePrecise(Coordinate coord)
	{
		if (precisionModelType_0 != PrecisionModelType.Floating)
		{
			coord.X = MakePrecise(coord.X);
			coord.Y = MakePrecise(coord.Y);
		}
	}

	public override string ToString()
	{
		string result = "UNKNOWN";
		if (precisionModelType_0 == PrecisionModelType.Floating)
		{
			result = "Floating";
		}
		else if (precisionModelType_0 == PrecisionModelType.FloatingSingle)
		{
			result = "Floating-Single";
		}
		else if (precisionModelType_0 == PrecisionModelType.Fixed)
		{
			result = "Fixed (Scale=" + Scale + ")";
		}
		return result;
	}

	public override bool Equals(object other)
	{
		if (other != null)
		{
			if (other is PrecisionModel)
			{
				PrecisionModel precisionModel = (PrecisionModel)other;
				if (precisionModelType_0 == precisionModel.precisionModelType_0)
				{
					return double_0 == precisionModel.double_0;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool operator ==(PrecisionModel obj1, PrecisionModel obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(PrecisionModel obj1, PrecisionModel obj2)
	{
		return !(obj1 == obj2);
	}

	static PrecisionModel()
	{
		Class72.smethod_20();
	}
}
