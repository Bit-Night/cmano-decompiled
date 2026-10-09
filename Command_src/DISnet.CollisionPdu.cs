using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(Vector3Float))]
public class CollisionPdu : EntityInformationFamilyPdu, IEquatable<CollisionPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private byte byte_6;

	private byte byte_7;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	private Vector3Float vector3Float_1 = new Vector3Float();

	[XmlElement(Type = typeof(EntityID), ElementName = "issuingEntityID")]
	public EntityID IssuingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "collidingEntityID")]
	public EntityID CollidingEntityID
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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "eventID")]
	public EventIdentifier EventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "collisionType")]
	public byte CollisionType
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

	[XmlElement(Type = typeof(byte), ElementName = "pad")]
	public byte Pad
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
	public Vector3Float Velocity
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

	[XmlElement(Type = typeof(float), ElementName = "mass")]
	public float Mass
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
	public Vector3Float Location
	{
		get
		{
			return vector3Float_1;
		}
		set
		{
			vector3Float_1 = value;
		}
	}

	public CollisionPdu()
	{
		base.PduType = 4;
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(CollisionPdu left, CollisionPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(CollisionPdu left, CollisionPdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + eventIdentifier_0.GetMarshalledSize() + 1 + 1 + vector3Float_0.GetMarshalledSize() + 4 + vector3Float_1.GetMarshalledSize();
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
				eventIdentifier_0.Marshal(dos);
				dos.WriteUnsignedByte(byte_6);
				dos.WriteByte(byte_7);
				vector3Float_0.Marshal(dos);
				dos.WriteFloat(float_0);
				vector3Float_1.Marshal(dos);
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
				eventIdentifier_0.Unmarshal(dis);
				byte_6 = dis.ReadUnsignedByte();
				byte_7 = dis.ReadByte();
				vector3Float_0.Unmarshal(dis);
				float_0 = dis.ReadFloat();
				vector3Float_1.Unmarshal(dis);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<CollisionPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<issuingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</issuingEntityID>");
			sb.AppendLine("<collidingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</collidingEntityID>");
			sb.AppendLine("<eventID>");
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<collisionType type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</collisionType>");
			sb.AppendLine("<pad type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</pad>");
			sb.AppendLine("<velocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<mass type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</mass>");
			sb.AppendLine("<location>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</location>");
			sb.AppendLine("</CollisionPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as CollisionPdu;
	}

	public bool Equals(CollisionPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((EntityInformationFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (!entityID_1.Equals(obj.entityID_1))
		{
			flag = false;
		}
		if (!eventIdentifier_0.Equals(obj.eventIdentifier_0))
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
		if (!vector3Float_0.Equals(obj.vector3Float_0))
		{
			flag = false;
		}
		if (float_0 != obj.float_0)
		{
			flag = false;
		}
		if (!vector3Float_1.Equals(obj.vector3Float_1))
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ vector3Float_1.GetHashCode();
	}

	static CollisionPdu()
	{
		Class72.smethod_20();
	}
}
