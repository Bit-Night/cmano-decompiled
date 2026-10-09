using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
public class DesignatorPdu : DistributedEmissionsFamilyPdu, IEquatable<DesignatorPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_2;

	private float float_0;

	private float float_1;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private byte byte_6;

	private ushort ushort_3;

	private byte byte_7;

	private Vector3Float vector3Float_1 = new Vector3Float();

	[XmlElement(Type = typeof(EntityID), ElementName = "designatingEntityID")]
	public EntityID DesignatingEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "codeName")]
	public ushort CodeName
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

	[XmlElement(Type = typeof(EntityID), ElementName = "designatedEntityID")]
	public EntityID DesignatedEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "designatorCode")]
	public ushort DesignatorCode
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

	[XmlElement(Type = typeof(float), ElementName = "designatorPower")]
	public float DesignatorPower
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

	[XmlElement(Type = typeof(float), ElementName = "designatorWavelength")]
	public float DesignatorWavelength
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "designatorSpotWrtDesignated")]
	public Vector3Float DesignatorSpotWrtDesignated
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "designatorSpotLocation")]
	public Vector3Double DesignatorSpotLocation
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

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
	public Vector3Float EntityLinearAcceleration
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

	public DesignatorPdu()
	{
		base.PduType = 24;
	}

	public static bool operator !=(DesignatorPdu left, DesignatorPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(DesignatorPdu left, DesignatorPdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + 2 + entityID_1.GetMarshalledSize() + 2 + 4 + 4 + vector3Float_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize() + 1 + 2 + 1 + vector3Float_1.GetMarshalledSize();
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
				dos.WriteUnsignedShort(ushort_1);
				entityID_1.Marshal(dos);
				dos.WriteUnsignedShort(ushort_2);
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				vector3Float_0.Marshal(dos);
				vector3Double_0.Marshal(dos);
				dos.WriteByte(byte_6);
				dos.WriteUnsignedShort(ushort_3);
				dos.WriteByte(byte_7);
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
				ushort_1 = dis.ReadUnsignedShort();
				entityID_1.Unmarshal(dis);
				ushort_2 = dis.ReadUnsignedShort();
				float_0 = dis.ReadFloat();
				float_1 = dis.ReadFloat();
				vector3Float_0.Unmarshal(dis);
				vector3Double_0.Unmarshal(dis);
				byte_6 = dis.ReadByte();
				ushort_3 = dis.ReadUnsignedShort();
				byte_7 = dis.ReadByte();
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
		sb.AppendLine("<DesignatorPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<designatingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</designatingEntityID>");
			sb.AppendLine("<codeName type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</codeName>");
			sb.AppendLine("<designatedEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</designatedEntityID>");
			sb.AppendLine("<designatorCode type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</designatorCode>");
			sb.AppendLine("<designatorPower type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</designatorPower>");
			sb.AppendLine("<designatorWavelength type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</designatorWavelength>");
			sb.AppendLine("<designatorSpotWrtDesignated>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</designatorSpotWrtDesignated>");
			sb.AppendLine("<designatorSpotLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</designatorSpotLocation>");
			sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			sb.AppendLine("<padding1 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<entityLinearAcceleration>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</entityLinearAcceleration>");
			sb.AppendLine("</DesignatorPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DesignatorPdu;
	}

	public bool Equals(DesignatorPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((DistributedEmissionsFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (!entityID_1.Equals(obj.entityID_1))
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (float_0 != obj.float_0)
		{
			flag = false;
		}
		if (float_1 != obj.float_1)
		{
			flag = false;
		}
		if (!vector3Float_0.Equals(obj.vector3Float_0))
		{
			flag = false;
		}
		if (!vector3Double_0.Equals(obj.vector3Double_0))
		{
			flag = false;
		}
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (ushort_3 != obj.ushort_3)
		{
			flag = false;
		}
		if (byte_7 != obj.byte_7)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ byte_6.GetHashCode()) ^ ushort_3.GetHashCode()) ^ byte_7.GetHashCode()) ^ vector3Float_1.GetHashCode();
	}

	static DesignatorPdu()
	{
		Class72.smethod_20();
	}
}
