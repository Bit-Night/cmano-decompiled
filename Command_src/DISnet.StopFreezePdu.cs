using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(ClockTime))]
[XmlInclude(typeof(EntityID))]
public class StopFreezePdu : SimulationManagementFamilyPdu, IEquatable<StopFreezePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

	private ClockTime clockTime_0 = new ClockTime();

	private byte byte_6;

	private byte byte_7;

	private short short_0;

	private uint uint_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
	{
		get
		{
			return entityID_2;
		}
		set
		{
			entityID_2 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingID")]
	public EntityID ReceivingID
	{
		get
		{
			return entityID_3;
		}
		set
		{
			entityID_3 = value;
		}
	}

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

	[XmlElement(Type = typeof(short), ElementName = "padding1")]
	public short Padding1
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
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

	public StopFreezePdu()
	{
		base.PduType = 14;
	}

	public static bool operator !=(StopFreezePdu left, StopFreezePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(StopFreezePdu left, StopFreezePdu right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + 1 + 1 + 2 + 4;
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
				entityID_2.Marshal(dos);
				entityID_3.Marshal(dos);
				clockTime_0.Marshal(dos);
				dos.WriteUnsignedByte(byte_6);
				dos.WriteUnsignedByte(byte_7);
				dos.WriteShort(short_0);
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
				entityID_2.Unmarshal(dis);
				entityID_3.Unmarshal(dis);
				clockTime_0.Unmarshal(dis);
				byte_6 = dis.ReadUnsignedByte();
				byte_7 = dis.ReadUnsignedByte();
				short_0 = dis.ReadShort();
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
		sb.AppendLine("<StopFreezePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<originatingID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</originatingID>");
			sb.AppendLine("<receivingID>");
			entityID_3.Reflection(sb);
			sb.AppendLine("</receivingID>");
			sb.AppendLine("<realWorldTime>");
			clockTime_0.Reflection(sb);
			sb.AppendLine("</realWorldTime>");
			sb.AppendLine("<reason type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</reason>");
			sb.AppendLine("<frozenBehavior type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</frozenBehavior>");
			sb.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</StopFreezePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StopFreezePdu;
	}

	public bool Equals(StopFreezePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SimulationManagementFamilyPdu)obj);
		if (!entityID_2.Equals(obj.entityID_2))
		{
			flag = false;
		}
		if (!entityID_3.Equals(obj.entityID_3))
		{
			flag = false;
		}
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
		if (short_0 != obj.short_0)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ short_0.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static StopFreezePdu()
	{
		Class72.smethod_20();
	}
}
