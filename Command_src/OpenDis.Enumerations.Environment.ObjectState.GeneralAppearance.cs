using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Environment.ObjectState;

[Serializable]
public struct GeneralAppearance
{
	[Description("Describes the damaged appearance of the object")]
	public enum DamageValue : uint
	{
		NoDamage,
		Damaged,
		Destroyed,
		Unknown
	}

	[Description("Describes whether the object was predistributed")]
	public enum PredistributedValue : uint
	{
		ObjectCreatedDuringTheExercise,
		ObjectPredistributedPriorToExerciseStart
	}

	[Description("Describes the state of the object")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	[Description("Describes whether smoke is rising from an object")]
	public enum SmokingValue : uint
	{
		None,
		SmokePresent
	}

	[Description("Describes whether flames are rising from an object")]
	public enum FlamingValue : uint
	{
		None,
		FlamesPresent
	}

	private byte byte_0;

	private DamageValue damageValue_0;

	private PredistributedValue predistributedValue_0;

	private StateValue stateValue_0;

	private SmokingValue smokingValue_0;

	private FlamingValue flamingValue_0;

	public byte PercentComplete
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public DamageValue Damage
	{
		get
		{
			return damageValue_0;
		}
		set
		{
			damageValue_0 = value;
		}
	}

	public PredistributedValue Predistributed
	{
		get
		{
			return predistributedValue_0;
		}
		set
		{
			predistributedValue_0 = value;
		}
	}

	public StateValue State
	{
		get
		{
			return stateValue_0;
		}
		set
		{
			stateValue_0 = value;
		}
	}

	public SmokingValue Smoking
	{
		get
		{
			return smokingValue_0;
		}
		set
		{
			smokingValue_0 = value;
		}
	}

	public FlamingValue Flaming
	{
		get
		{
			return flamingValue_0;
		}
		set
		{
			flamingValue_0 = value;
		}
	}

	public static bool operator !=(GeneralAppearance left, GeneralAppearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(GeneralAppearance left, GeneralAppearance right)
	{
		if ((object)left == (object)right)
		{
			return true;
		}
		int result;
		if ((object)left == null)
		{
			result = 0;
		}
		else
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public static explicit operator ushort(GeneralAppearance obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator GeneralAppearance(ushort value)
	{
		return smethod_0(value);
	}

	public static GeneralAppearance FromByteArray(byte[] array, int index)
	{
		if (array != null)
		{
			if (index < 0 || index > array.Length - 1 || index + 2 > array.Length - 1)
			{
				throw new IndexOutOfRangeException();
			}
			return smethod_0(BitConverter.ToUInt16(array, index));
		}
		throw new ArgumentNullException("array");
	}

	public static GeneralAppearance smethod_0(ushort value)
	{
		GeneralAppearance result = default(GeneralAppearance);
		uint num = (uint)(value & 0xFF) >> 0;
		result.PercentComplete = (byte)num;
		uint damage = (uint)(value & 0x300) >> 8;
		result.Damage = (DamageValue)damage;
		uint predistributed = (uint)(value & 0x400) >> 10;
		result.Predistributed = (PredistributedValue)predistributed;
		uint state = (uint)(value & 0x800) >> 11;
		result.State = (StateValue)state;
		uint smoking = (uint)(value & 0x1000) >> 12;
		result.Smoking = (SmokingValue)smoking;
		uint flaming = (uint)(value & 0x2000) >> 13;
		result.Flaming = (FlamingValue)flaming;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is GeneralAppearance))
		{
			return false;
		}
		return Equals((GeneralAppearance)obj);
	}

	public bool Equals(GeneralAppearance other)
	{
		if ((object)other != null)
		{
			if (PercentComplete == other.PercentComplete && Damage == other.Damage && Predistributed == other.Predistributed && State == other.State && Smoking == other.Smoking)
			{
				return Flaming == other.Flaming;
			}
			return false;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt16());
	}

	public ushort ToUInt16()
	{
		return (ushort)((ushort)((ushort)((ushort)((ushort)((ushort)(0 | PercentComplete) | (ushort)((uint)Damage << 8)) | (ushort)((uint)Predistributed << 10)) | (ushort)((uint)State << 11)) | (ushort)((uint)Smoking << 12)) | (ushort)((uint)Flaming << 13));
	}

	public override int GetHashCode()
	{
		return (((((493 + PercentComplete.GetHashCode()) * 29 + Damage.GetHashCode()) * 29 + Predistributed.GetHashCode()) * 29 + State.GetHashCode()) * 29 + Smoking.GetHashCode()) * 29 + Flaming.GetHashCode();
	}

	static GeneralAppearance()
	{
		Class72.smethod_20();
	}
}
