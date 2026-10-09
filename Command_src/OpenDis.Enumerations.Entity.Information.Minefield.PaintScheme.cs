using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct PaintScheme
{
	[Description("Identifies the algae build-up on the mine")]
	public enum AlgaeValue : uint
	{
		None,
		Light,
		Moderate,
		Heavy
	}

	[Description("Identifies the paint scheme of the mine")]
	public enum PaintSchemeValue : uint
	{
		Other,
		Standard,
		CamouflageDesert,
		CamouflageJungle,
		CamouflageSnow,
		CamouflageGravel,
		CamouflagePavement,
		CamouflageSand,
		NaturalWood,
		Clear,
		Red,
		Blue,
		Green,
		Olive,
		White,
		Tan,
		Black,
		Yellow,
		Brown
	}

	private AlgaeValue algaeValue_0;

	private PaintSchemeValue paintSchemeValue_0;

	public AlgaeValue Algae
	{
		get
		{
			return algaeValue_0;
		}
		set
		{
			algaeValue_0 = value;
		}
	}

	public PaintSchemeValue Value
	{
		get
		{
			return paintSchemeValue_0;
		}
		set
		{
			paintSchemeValue_0 = value;
		}
	}

	public static bool operator !=(PaintScheme left, PaintScheme right)
	{
		return !(left == right);
	}

	public static bool operator ==(PaintScheme left, PaintScheme right)
	{
		if ((object)left == (object)right)
		{
			return true;
		}
		int result;
		if ((object)left != null)
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public static explicit operator byte(PaintScheme obj)
	{
		return obj.ToByte();
	}

	public static explicit operator PaintScheme(byte value)
	{
		return FromByte(value);
	}

	public static PaintScheme FromByteArray(byte[] array, int index)
	{
		if (array != null)
		{
			if (index < 0 || index > array.Length - 1 || index + 1 > array.Length - 1)
			{
				throw new IndexOutOfRangeException();
			}
			return FromByte(array[index]);
		}
		throw new ArgumentNullException("array");
	}

	public static PaintScheme FromByte(byte value)
	{
		PaintScheme result = default(PaintScheme);
		uint algae = (uint)(value & 3) >> 0;
		result.Algae = (AlgaeValue)algae;
		uint value2 = (uint)(value & 0xFC) >> 2;
		result.Value = (PaintSchemeValue)value2;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is PaintScheme))
		{
			return false;
		}
		return Equals((PaintScheme)obj);
	}

	public bool Equals(PaintScheme other)
	{
		if ((object)other != null)
		{
			if (Algae == other.Algae)
			{
				return Value == other.Value;
			}
			return false;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes((short)ToByte());
	}

	public byte ToByte()
	{
		return (byte)((byte)(0 | (byte)Algae) | (byte)((uint)Value << 2));
	}

	public override int GetHashCode()
	{
		return (493 + Algae.GetHashCode()) * 29 + Value.GetHashCode();
	}

	static PaintScheme()
	{
		Class72.smethod_20();
	}
}
