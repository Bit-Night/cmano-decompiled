using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class CollisionElasticPdu : EntityInformationFamilyPdu, IEquatable<CollisionElasticPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private short short_0;

	private Vector3Float GcuYmmobOmu = new Vector3Float();

	private float float_0;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private Vector3Float vector3Float_1 = new Vector3Float();

	private float float_7;

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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "collisionEventID")]
	public EventIdentifier CollisionEventID
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

	[XmlElement(Type = typeof(short), ElementName = "pad")]
	public short Pad
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "contactVelocity")]
	public Vector3Float ContactVelocity
	{
		get
		{
			return GcuYmmobOmu;
		}
		set
		{
			GcuYmmobOmu = value;
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "locationOfImpact")]
	public Vector3Float LocationOfImpact
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

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultXX")]
	public float CollisionIntermediateResultXX
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultXY")]
	public float CollisionIntermediateResultXY
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultXZ")]
	public float CollisionIntermediateResultXZ
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultYY")]
	public float CollisionIntermediateResultYY
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultYZ")]
	public float CollisionIntermediateResultYZ
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "collisionIntermediateResultZZ")]
	public float CollisionIntermediateResultZZ
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "unitSurfaceNormal")]
	public Vector3Float UnitSurfaceNormal
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

	[XmlElement(Type = typeof(float), ElementName = "coefficientOfRestitution")]
	public float CoefficientOfRestitution
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	public CollisionElasticPdu()
	{
		base.PduType = 66;
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(CollisionElasticPdu left, CollisionElasticPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(CollisionElasticPdu left, CollisionElasticPdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + eventIdentifier_0.GetMarshalledSize() + 2 + GcuYmmobOmu.GetMarshalledSize() + 4 + vector3Float_0.GetMarshalledSize() + 4 + 4 + 4 + 4 + 4 + 4 + vector3Float_1.GetMarshalledSize() + 4;
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
				dos.WriteShort(short_0);
				GcuYmmobOmu.Marshal(dos);
				dos.WriteFloat(float_0);
				vector3Float_0.Marshal(dos);
				dos.WriteFloat(float_1);
				dos.WriteFloat(float_2);
				dos.WriteFloat(float_3);
				dos.WriteFloat(float_4);
				dos.WriteFloat(float_5);
				dos.WriteFloat(float_6);
				vector3Float_1.Marshal(dos);
				dos.WriteFloat(float_7);
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
				short_0 = dis.ReadShort();
				GcuYmmobOmu.Unmarshal(dis);
				float_0 = dis.ReadFloat();
				vector3Float_0.Unmarshal(dis);
				float_1 = dis.ReadFloat();
				float_2 = dis.ReadFloat();
				float_3 = dis.ReadFloat();
				float_4 = dis.ReadFloat();
				float_5 = dis.ReadFloat();
				float_6 = dis.ReadFloat();
				vector3Float_1.Unmarshal(dis);
				float_7 = dis.ReadFloat();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<CollisionElasticPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<issuingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</issuingEntityID>");
			sb.AppendLine("<collidingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</collidingEntityID>");
			sb.AppendLine("<collisionEventID>");
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</collisionEventID>");
			sb.AppendLine("<pad type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</pad>");
			sb.AppendLine("<contactVelocity>");
			GcuYmmobOmu.Reflection(sb);
			sb.AppendLine("</contactVelocity>");
			sb.AppendLine("<mass type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</mass>");
			sb.AppendLine("<locationOfImpact>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</locationOfImpact>");
			sb.AppendLine("<collisionIntermediateResultXX type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultXX>");
			sb.AppendLine("<collisionIntermediateResultXY type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultXY>");
			sb.AppendLine("<collisionIntermediateResultXZ type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultXZ>");
			sb.AppendLine("<collisionIntermediateResultYY type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultYY>");
			sb.AppendLine("<collisionIntermediateResultYZ type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultYZ>");
			sb.AppendLine("<collisionIntermediateResultZZ type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</collisionIntermediateResultZZ>");
			sb.AppendLine("<unitSurfaceNormal>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</unitSurfaceNormal>");
			sb.AppendLine("<coefficientOfRestitution type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</coefficientOfRestitution>");
			sb.AppendLine("</CollisionElasticPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as CollisionElasticPdu;
	}

	public bool Equals(CollisionElasticPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
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
			if (short_0 != obj.short_0)
			{
				flag = false;
			}
			if (!GcuYmmobOmu.Equals(obj.GcuYmmobOmu))
			{
				flag = false;
			}
			if (float_0 != obj.float_0)
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(obj.vector3Float_0))
			{
				flag = false;
			}
			if (float_1 != obj.float_1)
			{
				flag = false;
			}
			if (float_2 != obj.float_2)
			{
				flag = false;
			}
			if (float_3 != obj.float_3)
			{
				flag = false;
			}
			if (float_4 != obj.float_4)
			{
				flag = false;
			}
			if (float_5 != obj.float_5)
			{
				flag = false;
			}
			if (float_6 != obj.float_6)
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(obj.vector3Float_1))
			{
				flag = false;
			}
			if (float_7 != obj.float_7)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ short_0.GetHashCode()) ^ GcuYmmobOmu.GetHashCode()) ^ float_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ float_6.GetHashCode()) ^ vector3Float_1.GetHashCode()) ^ float_7.GetHashCode();
	}

	static CollisionElasticPdu()
	{
		Class72.smethod_20();
	}
}
