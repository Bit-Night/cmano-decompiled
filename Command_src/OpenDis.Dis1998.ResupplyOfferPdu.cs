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
[XmlInclude(typeof(SupplyQuantity))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class ResupplyOfferPdu : LogisticsFamilyPdu, IEquatable<ResupplyOfferPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_4;

	private short short_1;

	private byte byte_5;

	private List<SupplyQuantity> list_0 = new List<SupplyQuantity>();

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

	[XmlElement(Type = typeof(EntityID), ElementName = "supplyingEntityID")]
	public EntityID SupplyingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSupplyTypes")]
	public byte NumberOfSupplyTypes
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

	[XmlElement(ElementName = "suppliesList", Type = typeof(List<SupplyQuantity>))]
	public List<SupplyQuantity> Supplies => list_0;

	public ResupplyOfferPdu()
	{
		base.PduType = 6;
	}

	public static bool operator !=(ResupplyOfferPdu left, ResupplyOfferPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(ResupplyOfferPdu left, ResupplyOfferPdu right)
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
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num++;
		num += 2;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			SupplyQuantity supplyQuantity = list_0[i];
			num += supplyQuantity.GetMarshalledSize();
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
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteShort(short_1);
			dos.WriteByte(byte_5);
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
			byte_4 = dis.ReadUnsignedByte();
			short_1 = dis.ReadShort();
			byte_5 = dis.ReadByte();
			for (int i = 0; i < NumberOfSupplyTypes; i++)
			{
				SupplyQuantity supplyQuantity = new SupplyQuantity();
				supplyQuantity.Unmarshal(dis);
				list_0.Add(supplyQuantity);
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
		sb.AppendLine("<ResupplyOfferPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<receivingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</receivingEntityID>");
			sb.AppendLine("<supplyingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</supplyingEntityID>");
			sb.AppendLine("<supplies type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</supplies>");
			sb.AppendLine("<padding1 type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<supplies" + i.ToString(CultureInfo.InvariantCulture) + " type=\"SupplyQuantity\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</supplies" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ResupplyOfferPdu>");
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
		return this == obj as ResupplyOfferPdu;
	}

	public bool Equals(ResupplyOfferPdu obj)
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
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ short_1.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ResupplyOfferPdu()
	{
		Class72.smethod_20();
	}
}
