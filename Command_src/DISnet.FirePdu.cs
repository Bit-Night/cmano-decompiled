using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(MunitionDescriptor))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Vector3Float))]
public class FirePdu : WarfareFamilyPdu, IEquatable<FirePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private uint uint_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private MunitionDescriptor munitionDescriptor_0 = new MunitionDescriptor();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "munitionExpendibleID")]
	public EntityID MunitionExpendibleID
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

	[XmlElement(Type = typeof(uint), ElementName = "fireMissionIndex")]
	public uint FireMissionIndex
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "locationInWorldCoordinates")]
	public Vector3Double LocationInWorldCoordinates
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(MunitionDescriptor), ElementName = "descriptor")]
	public MunitionDescriptor Descriptor
	{
		get
		{
			return munitionDescriptor_0;
		}
		set
		{
			munitionDescriptor_0 = value;
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

	[XmlElement(Type = typeof(float), ElementName = "range")]
	public float Range
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

	public FirePdu()
	{
		base.PduType = 2;
	}

	public static bool operator !=(FirePdu left, FirePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(FirePdu left, FirePdu right)
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
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + eventIdentifier_0.GetMarshalledSize() + 4 + vector3Double_0.GetMarshalledSize() + munitionDescriptor_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + 4;
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
				entityID_2.Marshal(dos);
				eventIdentifier_0.Marshal(dos);
				dos.WriteUnsignedInt(uint_1);
				vector3Double_0.Marshal(dos);
				munitionDescriptor_0.Marshal(dos);
				vector3Float_0.Marshal(dos);
				dos.WriteFloat(float_0);
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
				entityID_2.Unmarshal(dis);
				eventIdentifier_0.Unmarshal(dis);
				uint_1 = dis.ReadUnsignedInt();
				vector3Double_0.Unmarshal(dis);
				munitionDescriptor_0.Unmarshal(dis);
				vector3Float_0.Unmarshal(dis);
				float_0 = dis.ReadFloat();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<FirePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<munitionExpendibleID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</munitionExpendibleID>");
			sb.AppendLine("<eventID>");
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<fireMissionIndex type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</fireMissionIndex>");
			sb.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</locationInWorldCoordinates>");
			sb.AppendLine("<descriptor>");
			munitionDescriptor_0.Reflection(sb);
			sb.AppendLine("</descriptor>");
			sb.AppendLine("<velocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<range type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</range>");
			sb.AppendLine("</FirePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as FirePdu;
	}

	public bool Equals(FirePdu obj)
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
		if (!eventIdentifier_0.Equals(obj.eventIdentifier_0))
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		if (!vector3Double_0.Equals(obj.vector3Double_0))
		{
			flag = false;
		}
		if (!munitionDescriptor_0.Equals(obj.munitionDescriptor_0))
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
		return flag;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ munitionDescriptor_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode();
	}

	static FirePdu()
	{
		Class72.smethod_20();
	}
}
