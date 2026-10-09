using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Relationship))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(NamedLocationIdentification))]
[XmlRoot]
[XmlInclude(typeof(EntityType))]
public class IsPartOfPdu : EntityManagementFamilyPdu, IEquatable<IsPartOfPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private Relationship relationship_0 = new Relationship();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private NamedLocationIdentification namedLocationIdentification_0 = new NamedLocationIdentification();

	private EntityType entityType_0 = new EntityType();

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

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
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

	[XmlElement(Type = typeof(Relationship), ElementName = "relationship")]
	public Relationship Relationship
	{
		get
		{
			return relationship_0;
		}
		set
		{
			relationship_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "partLocation")]
	public Vector3Float PartLocation
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
		}
	}

	[XmlElement(Type = typeof(NamedLocationIdentification), ElementName = "namedLocationID")]
	public NamedLocationIdentification NamedLocationID
	{
		get
		{
			return namedLocationIdentification_0;
		}
		set
		{
			namedLocationIdentification_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityType), ElementName = "partEntityType")]
	public EntityType PartEntityType
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

	public IsPartOfPdu()
	{
		base.PduType = 36;
	}

	public static bool operator !=(IsPartOfPdu left, IsPartOfPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(IsPartOfPdu left, IsPartOfPdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + relationship_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + namedLocationIdentification_0.GetMarshalledSize() + entityType_0.GetMarshalledSize();
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
				relationship_0.Marshal(dos);
				vector3Float_0.Marshal(dos);
				namedLocationIdentification_0.Marshal(dos);
				entityType_0.Marshal(dos);
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
				relationship_0.Unmarshal(dis);
				vector3Float_0.Unmarshal(dis);
				namedLocationIdentification_0.Unmarshal(dis);
				entityType_0.Unmarshal(dis);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<IsPartOfPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<orginatingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</orginatingEntityID>");
			sb.AppendLine("<receivingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</receivingEntityID>");
			sb.AppendLine("<relationship>");
			relationship_0.Reflection(sb);
			sb.AppendLine("</relationship>");
			sb.AppendLine("<partLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</partLocation>");
			sb.AppendLine("<namedLocationID>");
			namedLocationIdentification_0.Reflection(sb);
			sb.AppendLine("</namedLocationID>");
			sb.AppendLine("<partEntityType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</partEntityType>");
			sb.AppendLine("</IsPartOfPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IsPartOfPdu;
	}

	public bool Equals(IsPartOfPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((EntityManagementFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (!entityID_1.Equals(obj.entityID_1))
		{
			flag = false;
		}
		if (!relationship_0.Equals(obj.relationship_0))
		{
			flag = false;
		}
		if (!vector3Float_0.Equals(obj.vector3Float_0))
		{
			flag = false;
		}
		if (!namedLocationIdentification_0.Equals(obj.namedLocationIdentification_0))
		{
			flag = false;
		}
		if (!entityType_0.Equals(obj.entityType_0))
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ relationship_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ namedLocationIdentification_0.GetHashCode()) ^ entityType_0.GetHashCode();
	}

	static IsPartOfPdu()
	{
		Class72.smethod_20();
	}
}
