using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(SimulationAddress))]
[XmlInclude(typeof(EntityID))]
public class ArealObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<ArealObjectStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_6;

	private byte byte_7;

	private EntityType entityType_0 = new EntityType();

	private uint uint_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private List<Vector3Double> list_0 = new List<Vector3Double>();

	[XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
	public EntityID ObjectID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
	public EntityID ReferencedObjectID
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

	[XmlElement(Type = typeof(ushort), ElementName = "updateNumber")]
	public ushort UpdateNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "forceID")]
	public byte ForceID
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

	[XmlElement(Type = typeof(byte), ElementName = "modifications")]
	public byte Modifications
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

	[XmlElement(Type = typeof(EntityType), ElementName = "objectType")]
	public EntityType ObjectType
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "specificObjectAppearance")]
	public uint SpecificObjectAppearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "generalObjectAppearance")]
	public ushort GeneralObjectAppearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfPoints")]
	public ushort NumberOfPoints
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

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "requesterID")]
	public SimulationAddress RequesterID
	{
		get
		{
			return simulationAddress_0;
		}
		set
		{
			simulationAddress_0 = value;
		}
	}

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "receivingID")]
	public SimulationAddress ReceivingID
	{
		get
		{
			return simulationAddress_1;
		}
		set
		{
			simulationAddress_1 = value;
		}
	}

	[XmlElement(ElementName = "objectLocationList", Type = typeof(List<Vector3Double>))]
	public List<Vector3Double> ObjectLocation => list_0;

	public ArealObjectStatePdu()
	{
		base.PduType = 45;
	}

	public static bool operator !=(ArealObjectStatePdu left, ArealObjectStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(ArealObjectStatePdu left, ArealObjectStatePdu right)
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
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 4;
		num += 2;
		num += 2;
		num += simulationAddress_0.GetMarshalledSize();
		num += simulationAddress_1.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Double vector3Double = list_0[i];
			num += vector3Double.GetMarshalledSize();
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
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte(byte_7);
			entityType_0.Marshal(dos);
			dos.WriteUnsignedInt(uint_1);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort((ushort)list_0.Count);
			simulationAddress_0.Marshal(dos);
			simulationAddress_1.Marshal(dos);
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
			entityID_0.Unmarshal(dis);
			entityID_1.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			uint_1 = dis.ReadUnsignedInt();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			simulationAddress_0.Unmarshal(dis);
			simulationAddress_1.Unmarshal(dis);
			for (int i = 0; i < NumberOfPoints; i++)
			{
				Vector3Double vector3Double = new Vector3Double();
				vector3Double.Unmarshal(dis);
				list_0.Add(vector3Double);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<ArealObjectStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<objectID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</objectID>");
			sb.AppendLine("<referencedObjectID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</referencedObjectID>");
			sb.AppendLine("<updateNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
			sb.AppendLine("<forceID type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			sb.AppendLine("<modifications type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</modifications>");
			sb.AppendLine("<objectType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</objectType>");
			sb.AppendLine("<specificObjectAppearance type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</specificObjectAppearance>");
			sb.AppendLine("<generalObjectAppearance type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</generalObjectAppearance>");
			sb.AppendLine("<objectLocation type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</objectLocation>");
			sb.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(sb);
			sb.AppendLine("</requesterID>");
			sb.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(sb);
			sb.AppendLine("</receivingID>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<objectLocation" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Double\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</objectLocation" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ArealObjectStatePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ArealObjectStatePdu;
	}

	public bool Equals(ArealObjectStatePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (ushort_1 != obj.ushort_1)
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
			if (!entityType_0.Equals(obj.entityType_0))
			{
				flag = false;
			}
			if (uint_1 != obj.uint_1)
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
			if (!simulationAddress_0.Equals(obj.simulationAddress_0))
			{
				flag = false;
			}
			if (!simulationAddress_1.Equals(obj.simulationAddress_1))
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ entityID_1.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		num = smethod_3(num) ^ simulationAddress_0.GetHashCode();
		num = smethod_3(num) ^ simulationAddress_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ArealObjectStatePdu()
	{
		Class72.smethod_20();
	}
}
