#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class RepairResponsePdu : LogisticsPdu, IEquatable<RepairResponsePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_4;

	private short short_1;

	private byte byte_5;

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
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(short), ElementName = "padding1")]
	public short Padding1
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
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
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
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
		if (dos == null)
		{
			return;
		}
		try
		{
			entityID_0.Marshal(dos);
			entityID_1.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteShort(short_1);
			dos.WriteByte(byte_5);
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis == null)
		{
			return;
		}
		try
		{
			entityID_0.Unmarshal(dis);
			entityID_1.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			short_1 = dis.ReadShort();
			byte_5 = dis.ReadByte();
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
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
			sb.AppendLine("<repairResult type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</repairResult>");
			sb.AppendLine("<padding1 type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("</RepairResponsePdu>");
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RepairResponsePdu;
	}

	public bool Equals(RepairResponsePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((LogisticsPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (!entityID_1.Equals(obj.entityID_1))
		{
			flag = false;
		}
		if (byte_4 != obj.byte_4)
		{
			flag = false;
		}
		if (short_1 != obj.short_1)
		{
			flag = false;
		}
		if (byte_5 != obj.byte_5)
		{
			flag = false;
		}
		return flag;
	}

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ byte_4.GetHashCode()) ^ short_1.GetHashCode()) ^ byte_5.GetHashCode();
	}

	static RepairResponsePdu()
	{
		Class72.smethod_20();
	}
}
