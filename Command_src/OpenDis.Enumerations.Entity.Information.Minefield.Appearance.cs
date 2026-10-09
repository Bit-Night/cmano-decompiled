using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.Entity.Information.Minefield;

[Serializable]
public struct Appearance
{
	[Description("Identifies the type of minefield")]
	public enum MinefieldTypeValue : uint
	{
		MixedAntiPersonnelAndAntiTankMinefield,
		PureAntiPersonnelMinefield,
		PureAntiTankMinefield,
		Unknown
	}

	[Description("Identifies the active status of the minefield")]
	public enum ActiveStatusValue : uint
	{
		Active,
		Inactive
	}

	[Description("Identifies whether the minefield has an active lane")]
	public enum LaneValue : uint
	{
		MinefieldHasActiveLane,
		MinefieldHasAnInactiveLane
	}

	[Description("Describes the state of the minefield")]
	public enum StateValue : uint
	{
		Active,
		Deactivated
	}

	private MinefieldTypeValue minefieldTypeValue_0;

	private ActiveStatusValue activeStatusValue_0;

	private LaneValue laneValue_0;

	private StateValue stateValue_0;

	public MinefieldTypeValue MinefieldType
	{
		get
		{
			return minefieldTypeValue_0;
		}
		set
		{
			minefieldTypeValue_0 = value;
		}
	}

	public ActiveStatusValue ActiveStatus
	{
		get
		{
			return activeStatusValue_0;
		}
		set
		{
			activeStatusValue_0 = value;
		}
	}

	public LaneValue Lane
	{
		get
		{
			return laneValue_0;
		}
		set
		{
			laneValue_0 = value;
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

	public static bool operator !=(Appearance left, Appearance right)
	{
		return !(left == right);
	}

	public static bool operator ==(Appearance left, Appearance right)
	{
		if ((object)left == (object)right)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public static explicit operator ushort(Appearance obj)
	{
		return obj.ToUInt16();
	}

	public static explicit operator Appearance(ushort value)
	{
		return smethod_0(value);
	}

	public static Appearance FromByteArray(byte[] array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0 || index > array.Length - 1 || index + 2 > array.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt16(array, index));
	}

	public static Appearance smethod_0(ushort value)
	{
		Appearance result = default(Appearance);
		uint minefieldType = (uint)(value & 3) >> 0;
		result.MinefieldType = (MinefieldTypeValue)minefieldType;
		uint activeStatus = (uint)(value & 4) >> 2;
		result.ActiveStatus = (ActiveStatusValue)activeStatus;
		uint lane = (uint)(value & 8) >> 3;
		result.Lane = (LaneValue)lane;
		uint state = (uint)(value & 0x2000) >> 13;
		result.State = (StateValue)state;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (obj is Appearance)
			{
				return Equals((Appearance)obj);
			}
			return false;
		}
		return false;
	}

	public bool Equals(Appearance other)
	{
		if ((object)other != null)
		{
			if (MinefieldType == other.MinefieldType && ActiveStatus == other.ActiveStatus && Lane == other.Lane)
			{
				return State == other.State;
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
		return (ushort)((ushort)((ushort)((ushort)(0 | (ushort)MinefieldType) | (ushort)((uint)ActiveStatus << 2)) | (ushort)((uint)Lane << 3)) | (ushort)((uint)State << 13));
	}

	public override int GetHashCode()
	{
		return (((493 + MinefieldType.GetHashCode()) * 29 + ActiveStatus.GetHashCode()) * 29 + Lane.GetHashCode()) * 29 + State.GetHashCode();
	}

	static Appearance()
	{
		Class72.smethod_20();
	}
}
