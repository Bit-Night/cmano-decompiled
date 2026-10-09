#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class CollisionPdu : EntityInformationPdu, IEquatable<CollisionPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

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

	[XmlElement(Type = typeof(EventID), ElementName = "eventID")]
	public EventID EventID
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

	[XmlElement(Type = typeof(byte), ElementName = "collisionType")]
	public byte CollisionType
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

	[XmlElement(Type = typeof(byte), ElementName = "pad")]
	public byte Pad
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + eventID_0.GetMarshalledSize() + 1 + 1 + vector3Float_0.GetMarshalledSize() + 4 + vector3Float_1.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_4);
			dos.WriteByte(byte_5);
			vector3Float_0.Marshal(dos);
			dos.WriteFloat(float_0);
			vector3Float_1.Marshal(dos);
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
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadByte();
			vector3Float_0.Unmarshal(dis);
			float_0 = dis.ReadFloat();
			vector3Float_1.Unmarshal(dis);
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
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<collisionType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</collisionType>");
			sb.AppendLine("<pad type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad>");
			sb.AppendLine("<velocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<mass type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</mass>");
			sb.AppendLine("<location>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</location>");
			sb.AppendLine("</CollisionPdu>");
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
		return this == obj as CollisionPdu;
	}

	public bool Equals(CollisionPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((EntityInformationPdu)obj);
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
			if (byte_4 != obj.byte_4)
			{
				flag = false;
			}
			if (byte_5 != obj.byte_5)
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
		return false;
	}

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ eventID_0.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ vector3Float_1.GetHashCode();
	}

	static CollisionPdu()
	{
		Class72.smethod_20();
	}
}
