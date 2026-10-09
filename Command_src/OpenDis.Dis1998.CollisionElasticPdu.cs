#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EventID))]
public class CollisionElasticPdu : EntityInformationFamilyPdu, IEquatable<CollisionElasticPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private EventID eventID_0 = new EventID();

	private short short_1;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	private Vector3Float vector3Float_1 = new Vector3Float();

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private Vector3Float vector3Float_2 = new Vector3Float();

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

	[XmlElement(Type = typeof(EventID), ElementName = "collisionEventID")]
	public EventID CollisionEventID
	{
		get
		{
			return eventID_0;
		}
		set
		{
			eventID_0 = value;
		}
	}

	[XmlElement(Type = typeof(short), ElementName = "pad")]
	public short Pad
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "contactVelocity")]
	public Vector3Float ContactVelocity
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

	[XmlElement(Type = typeof(float), ElementName = "collisionResultXX")]
	public float CollisionResultXX
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

	[XmlElement(Type = typeof(float), ElementName = "collisionResultXY")]
	public float CollisionResultXY
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

	[XmlElement(Type = typeof(float), ElementName = "collisionResultXZ")]
	public float CollisionResultXZ
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

	[XmlElement(Type = typeof(float), ElementName = "collisionResultYY")]
	public float CollisionResultYY
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

	[XmlElement(Type = typeof(float), ElementName = "collisionResultYZ")]
	public float CollisionResultYZ
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

	[XmlElement(Type = typeof(float), ElementName = "collisionResultZZ")]
	public float CollisionResultZZ
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
			return vector3Float_2;
		}
		set
		{
			vector3Float_2 = value;
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + eventID_0.GetMarshalledSize() + 2 + vector3Float_0.GetMarshalledSize() + 4 + vector3Float_1.GetMarshalledSize() + 4 + 4 + 4 + 4 + 4 + 4 + vector3Float_2.GetMarshalledSize() + 4;
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
			eventID_0.Marshal(dos);
			dos.WriteShort(short_1);
			vector3Float_0.Marshal(dos);
			dos.WriteFloat(float_0);
			vector3Float_1.Marshal(dos);
			dos.WriteFloat(float_1);
			dos.WriteFloat(float_2);
			dos.WriteFloat(float_3);
			dos.WriteFloat(float_4);
			dos.WriteFloat(float_5);
			dos.WriteFloat(float_6);
			vector3Float_2.Marshal(dos);
			dos.WriteFloat(float_7);
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
			eventID_0.Unmarshal(dis);
			short_1 = dis.ReadShort();
			vector3Float_0.Unmarshal(dis);
			float_0 = dis.ReadFloat();
			vector3Float_1.Unmarshal(dis);
			float_1 = dis.ReadFloat();
			float_2 = dis.ReadFloat();
			float_3 = dis.ReadFloat();
			float_4 = dis.ReadFloat();
			float_5 = dis.ReadFloat();
			float_6 = dis.ReadFloat();
			vector3Float_2.Unmarshal(dis);
			float_7 = dis.ReadFloat();
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
			eventID_0.Reflection(sb);
			sb.AppendLine("</collisionEventID>");
			sb.AppendLine("<pad type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</pad>");
			sb.AppendLine("<contactVelocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</contactVelocity>");
			sb.AppendLine("<mass type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</mass>");
			sb.AppendLine("<location>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</location>");
			sb.AppendLine("<collisionResultXX type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</collisionResultXX>");
			sb.AppendLine("<collisionResultXY type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</collisionResultXY>");
			sb.AppendLine("<collisionResultXZ type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</collisionResultXZ>");
			sb.AppendLine("<collisionResultYY type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</collisionResultYY>");
			sb.AppendLine("<collisionResultYZ type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</collisionResultYZ>");
			sb.AppendLine("<collisionResultZZ type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</collisionResultZZ>");
			sb.AppendLine("<unitSurfaceNormal>");
			vector3Float_2.Reflection(sb);
			sb.AppendLine("</unitSurfaceNormal>");
			sb.AppendLine("<coefficientOfRestitution type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</coefficientOfRestitution>");
			sb.AppendLine("</CollisionElasticPdu>");
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
		return this == obj as CollisionElasticPdu;
	}

	public bool Equals(CollisionElasticPdu obj)
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
		if (!eventID_0.Equals(obj.eventID_0))
		{
			flag = false;
		}
		if (short_1 != obj.short_1)
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
		if (!vector3Float_2.Equals(obj.vector3Float_2))
		{
			flag = false;
		}
		if (float_7 != obj.float_7)
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ eventID_0.GetHashCode()) ^ short_1.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ vector3Float_1.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ float_6.GetHashCode()) ^ vector3Float_2.GetHashCode()) ^ float_7.GetHashCode();
	}

	static CollisionElasticPdu()
	{
		Class72.smethod_20();
	}
}
