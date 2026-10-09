using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(EulerAngles))]
[XmlInclude(typeof(SimulationAddress))]
[XmlInclude(typeof(ObjectType))]
[XmlInclude(typeof(Vector3Double))]
public class PointObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<PointObjectStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_6;

	private byte byte_7;

	private ObjectType objectType_0 = new ObjectType();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private double double_0;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private uint uint_1;

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

	[XmlElement(Type = typeof(ObjectType), ElementName = "objectType")]
	public ObjectType ObjectType
	{
		get
		{
			return objectType_0;
		}
		set
		{
			objectType_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Double), ElementName = "objectLocation")]
	public Vector3Double ObjectLocation
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

	[XmlElement(Type = typeof(EulerAngles), ElementName = "objectOrientation")]
	public EulerAngles ObjectOrientation
	{
		get
		{
			return eulerAngles_0;
		}
		set
		{
			eulerAngles_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "objectAppearance")]
	public double ObjectAppearance
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
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

	[XmlElement(Type = typeof(uint), ElementName = "pad2")]
	public uint Pad2
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

	public PointObjectStatePdu()
	{
		base.PduType = 43;
	}

	public static bool operator !=(PointObjectStatePdu left, PointObjectStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(PointObjectStatePdu left, PointObjectStatePdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 2 + 1 + 1 + objectType_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize() + eulerAngles_0.GetMarshalledSize() + 8 + simulationAddress_0.GetMarshalledSize() + simulationAddress_1.GetMarshalledSize() + 4;
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
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedByte(byte_6);
				dos.WriteUnsignedByte(byte_7);
				objectType_0.Marshal(dos);
				vector3Double_0.Marshal(dos);
				eulerAngles_0.Marshal(dos);
				dos.WriteDouble(double_0);
				simulationAddress_0.Marshal(dos);
				simulationAddress_1.Marshal(dos);
				dos.WriteUnsignedInt(uint_1);
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
				ushort_1 = dis.ReadUnsignedShort();
				byte_6 = dis.ReadUnsignedByte();
				byte_7 = dis.ReadUnsignedByte();
				objectType_0.Unmarshal(dis);
				vector3Double_0.Unmarshal(dis);
				eulerAngles_0.Unmarshal(dis);
				double_0 = dis.ReadDouble();
				simulationAddress_0.Unmarshal(dis);
				simulationAddress_1.Unmarshal(dis);
				uint_1 = dis.ReadUnsignedInt();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<PointObjectStatePdu>");
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
			objectType_0.Reflection(sb);
			sb.AppendLine("</objectType>");
			sb.AppendLine("<objectLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</objectLocation>");
			sb.AppendLine("<objectOrientation>");
			eulerAngles_0.Reflection(sb);
			sb.AppendLine("</objectOrientation>");
			sb.AppendLine("<objectAppearance type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</objectAppearance>");
			sb.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(sb);
			sb.AppendLine("</requesterID>");
			sb.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(sb);
			sb.AppendLine("</receivingID>");
			sb.AppendLine("<pad2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("</PointObjectStatePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as PointObjectStatePdu;
	}

	public bool Equals(PointObjectStatePdu obj)
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
			if (!objectType_0.Equals(obj.objectType_0))
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(obj.vector3Double_0))
			{
				flag = false;
			}
			if (!eulerAngles_0.Equals(obj.eulerAngles_0))
			{
				flag = false;
			}
			if (double_0 != obj.double_0)
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
			if (uint_1 != obj.uint_1)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ objectType_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ eulerAngles_0.GetHashCode()) ^ double_0.GetHashCode()) ^ simulationAddress_0.GetHashCode()) ^ simulationAddress_1.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static PointObjectStatePdu()
	{
		Class72.smethod_20();
	}
}
