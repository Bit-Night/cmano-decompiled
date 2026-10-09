#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(RecordSet))]
public class TransferControlRequestPdu : EntityManagementFamilyPdu, IEquatable<TransferControlRequestPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private uint uint_1;

	private byte byte_4;

	private byte byte_5;

	private EntityID entityID_2 = new EntityID();

	private byte byte_6;

	private List<RecordSet> list_0 = new List<RecordSet>();

	[XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
	public EntityID OrginatingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "recevingEntityID")]
	public EntityID RecevingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
	public byte RequiredReliabilityService
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

	[XmlElement(Type = typeof(byte), ElementName = "tranferType")]
	public byte TranferType
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

	[XmlElement(Type = typeof(EntityID), ElementName = "transferEntityID")]
	public EntityID TransferEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfRecordSets")]
	public byte NumberOfRecordSets
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

	[XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSet>))]
	public List<RecordSet> RecordSets => list_0;

	public TransferControlRequestPdu()
	{
		base.PduType = 35;
	}

	public static bool operator !=(TransferControlRequestPdu left, TransferControlRequestPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(TransferControlRequestPdu left, TransferControlRequestPdu right)
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
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num += 4;
		num++;
		num++;
		num += entityID_2.GetMarshalledSize();
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			RecordSet recordSet = list_0[i];
			num += recordSet.GetMarshalledSize();
		}
		return num;
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
			dos.WriteUnsignedInt(uint_1);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			entityID_2.Marshal(dos);
			dos.WriteUnsignedByte((byte)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
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
			uint_1 = dis.ReadUnsignedInt();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			entityID_2.Unmarshal(dis);
			byte_6 = dis.ReadUnsignedByte();
			for (int i = 0; i < NumberOfRecordSets; i++)
			{
				RecordSet recordSet = new RecordSet();
				recordSet.Unmarshal(dis);
				list_0.Add(recordSet);
			}
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
		sb.AppendLine("<TransferControlRequestPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<orginatingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</orginatingEntityID>");
			sb.AppendLine("<recevingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</recevingEntityID>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			sb.AppendLine("<tranferType type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</tranferType>");
			sb.AppendLine("<transferEntityID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</transferEntityID>");
			sb.AppendLine("<recordSets type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<recordSets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</recordSets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</TransferControlRequestPdu>");
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
		return this == obj as TransferControlRequestPdu;
	}

	public bool Equals(TransferControlRequestPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((EntityManagementFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (uint_1 != obj.uint_1)
			{
				flag = false;
			}
			if (byte_4 != obj.byte_4)
			{
				flag = false;
			}
			if (byte_5 != obj.byte_5)
			{
				flag = false;
			}
			if (!entityID_2.Equals(obj.entityID_2))
			{
				flag = false;
			}
			if (byte_6 != obj.byte_6)
			{
				flag = false;
			}
			if (list_0.Count != obj.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(obj.list_0[i]))
					{
						flag = false;
					}
				}
			}
			return flag;
		}
		return false;
	}

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityID_2.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static TransferControlRequestPdu()
	{
		Class72.smethod_20();
	}
}
