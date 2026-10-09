using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(DirectedEnergyDamage))]
public class EntityDamageStatusPdu : WarfareFamilyPdu, IEquatable<EntityDamageStatusPdu>
{
	private EntityID entityID_2 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private List<DirectedEnergyDamage> list_0 = new List<DirectedEnergyDamage>();

	[XmlElement(Type = typeof(EntityID), ElementName = "damagedEntityID")]
	public EntityID DamagedEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDamageDescription")]
	public ushort NumberOfDamageDescription
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
		}
	}

	[XmlElement(ElementName = "damageDescriptionRecordsList", Type = typeof(List<DirectedEnergyDamage>))]
	public List<DirectedEnergyDamage> DamageDescriptionRecords => list_0;

	public EntityDamageStatusPdu()
	{
		base.PduType = 69;
	}

	public static bool operator !=(EntityDamageStatusPdu left, EntityDamageStatusPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(EntityDamageStatusPdu left, EntityDamageStatusPdu right)
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
		num += entityID_2.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			DirectedEnergyDamage directedEnergyDamage = list_0[i];
			num += directedEnergyDamage.GetMarshalledSize();
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
			entityID_2.Marshal(dos);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort((ushort)list_0.Count);
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
			entityID_2.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfDamageDescription; i++)
			{
				DirectedEnergyDamage directedEnergyDamage = new DirectedEnergyDamage();
				directedEnergyDamage.Unmarshal(dis);
				list_0.Add(directedEnergyDamage);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EntityDamageStatusPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<damagedEntityID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</damagedEntityID>");
			sb.AppendLine("<padding1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<damageDescriptionRecords type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</damageDescriptionRecords>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<damageDescriptionRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"DirectedEnergyDamage\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</damageDescriptionRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</EntityDamageStatusPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityDamageStatusPdu;
	}

	public bool Equals(EntityDamageStatusPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((WarfareFamilyPdu)obj);
		if (!entityID_2.Equals(obj.entityID_2))
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (ushort_3 != obj.ushort_3)
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
		num = smethod_3(num) ^ entityID_2.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static EntityDamageStatusPdu()
	{
		Class72.smethod_20();
	}
}
