using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(ClockTime))]
public class StopFreezeReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<StopFreezeReliablePdu>
{
	private ClockTime clockTime_0 = new ClockTime();

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private uint uint_1;

	[XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
	public ClockTime RealWorldTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "reason")]
	public byte Reason
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "frozenBehavior")]
	public byte FrozenBehavior
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliablityService")]
	public byte RequiredReliablityService
	{
		get
		{
			return byte_8;
		}
		set
		{
			byte_8 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pad1")]
	public byte Pad1
	{
		get
		{
			return byte_9;
		}
		set
		{
			byte_9 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public StopFreezeReliablePdu()
	{
		base.PduType = 54;
	}

	public static bool operator !=(StopFreezeReliablePdu left, StopFreezeReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(StopFreezeReliablePdu left, StopFreezeReliablePdu right)
	{
		if ((object)left == right)
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

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + 1 + 1 + 1 + 1 + 4;
	}

	public override void MarshalAutoLengthSet(DataOutputStream dos)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dos);
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
		if (dos != null)
		{
			try
			{
				clockTime_0.Marshal(dos);
				dos.WriteUnsignedByte(byte_6);
				dos.WriteUnsignedByte(byte_7);
				dos.WriteUnsignedByte(byte_8);
				dos.WriteUnsignedByte(byte_9);
				dos.WriteUnsignedInt(uint_1);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis != null)
		{
			try
			{
				clockTime_0.Unmarshal(dis);
				byte_6 = dis.ReadUnsignedByte();
				byte_7 = dis.ReadUnsignedByte();
				byte_8 = dis.ReadUnsignedByte();
				byte_9 = dis.ReadUnsignedByte();
				uint_1 = dis.ReadUnsignedInt();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<StopFreezeReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<realWorldTime>");
			clockTime_0.Reflection(sb);
			sb.AppendLine("</realWorldTime>");
			sb.AppendLine("<reason type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</reason>");
			sb.AppendLine("<frozenBehavior type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</frozenBehavior>");
			sb.AppendLine("<requiredReliablityService type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</requiredReliablityService>");
			sb.AppendLine("<pad1 type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</StopFreezeReliablePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StopFreezeReliablePdu;
	}

	public bool Equals(StopFreezeReliablePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SimulationManagementWithReliabilityFamilyPdu)obj);
		if (!clockTime_0.Equals(obj.clockTime_0))
		{
			flag = false;
		}
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (byte_7 != obj.byte_7)
		{
			flag = false;
		}
		if (byte_8 != obj.byte_8)
		{
			flag = false;
		}
		if (byte_9 != obj.byte_9)
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		return flag;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ byte_8.GetHashCode()) ^ byte_9.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static StopFreezeReliablePdu()
	{
		Class72.smethod_20();
	}
}
