using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(SupplyQuantity))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class ResupplyOfferPdu : LogisticsFamilyPdu, IEquatable<ResupplyOfferPdu>
{
	private EntityID ShsYaZulPkB = new EntityID();

	private EntityID entityID_0 = new EntityID();

	private byte byte_6;

	private byte byte_7;

	private short short_0;

	private List<SupplyQuantity> list_0 = new List<SupplyQuantity>();

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
	{
		get
		{
			return ShsYaZulPkB;
		}
		set
		{
			ShsYaZulPkB = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "supplyingEntityID")]
	public EntityID SupplyingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSupplyTypes")]
	public byte NumberOfSupplyTypes
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(short), ElementName = "padding2")]
	public short Padding2
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
		int num = 0;
		num = base.GetMarshalledSize();
		num += ShsYaZulPkB.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
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
			ShsYaZulPkB.Marshal(dos);
			entityID_0.Marshal(dos);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteByte(byte_7);
			dos.WriteShort(short_0);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
		}
		catch (Exception e)
		{
			OnException(e);
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
			ShsYaZulPkB.Unmarshal(dis);
			entityID_0.Unmarshal(dis);
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadByte();
			short_0 = dis.ReadShort();
			for (int i = 0; i < NumberOfSupplyTypes; i++)
			{
				SupplyQuantity supplyQuantity = new SupplyQuantity();
				supplyQuantity.Unmarshal(dis);
				list_0.Add(supplyQuantity);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<ResupplyOfferPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<receivingEntityID>");
			ShsYaZulPkB.Reflection(sb);
			sb.AppendLine("</receivingEntityID>");
			sb.AppendLine("<supplyingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</supplyingEntityID>");
			sb.AppendLine("<supplies type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</supplies>");
			sb.AppendLine("<padding1 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<supplies" + i.ToString(CultureInfo.InvariantCulture) + " type=\"SupplyQuantity\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</supplies" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ResupplyOfferPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ResupplyOfferPdu;
	}

	public bool Equals(ResupplyOfferPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((LogisticsFamilyPdu)obj);
		if (!ShsYaZulPkB.Equals(obj.ShsYaZulPkB))
		{
			flag = false;
		}
		if (!entityID_0.Equals(obj.entityID_0))
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ ShsYaZulPkB.GetHashCode();
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ short_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ResupplyOfferPdu()
	{
		Class72.smethod_20();
	}
}
