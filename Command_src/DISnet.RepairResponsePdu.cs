using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class RepairResponsePdu : LogisticsFamilyPdu, IEquatable<RepairResponsePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_6;

	private short short_0;

	private byte byte_7;

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "repairingEntityID")]
	public EntityID RepairingEntityID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "repairResult")]
	public byte RepairResult
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	public RepairResponsePdu()
	{
		base.PduType = 10;
	}

	public static bool operator !=(RepairResponsePdu left, RepairResponsePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(RepairResponsePdu left, RepairResponsePdu right)
	{
		if ((object)left == right)
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

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 1 + 2 + 1;
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
				entityID_0.Marshal(dos);
				entityID_1.Marshal(dos);
				dos.WriteUnsignedByte(byte_6);
				dos.WriteShort(short_0);
				dos.WriteByte(byte_7);
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
				entityID_0.Unmarshal(dis);
				entityID_1.Unmarshal(dis);
				byte_6 = dis.ReadUnsignedByte();
				short_0 = dis.ReadShort();
				byte_7 = dis.ReadByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<RepairResponsePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<receivingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</receivingEntityID>");
			sb.AppendLine("<repairingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</repairingEntityID>");
			sb.AppendLine("<repairResult type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</repairResult>");
			sb.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("</RepairResponsePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RepairResponsePdu;
	}

	public bool Equals(RepairResponsePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((LogisticsFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (byte_6 != obj.byte_6)
			{
				flag = false;
			}
			if (short_0 != obj.short_0)
			{
				flag = false;
			}
			if (byte_7 != obj.byte_7)
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ byte_6.GetHashCode()) ^ short_0.GetHashCode()) ^ byte_7.GetHashCode();
	}

	static RepairResponsePdu()
	{
		Class72.smethod_20();
	}
}
