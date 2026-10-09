using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class AcknowledgePdu : SimulationManagementFamilyPdu, IEquatable<AcknowledgePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private uint uint_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingID")]
	public EntityID ReceivingID
	{
		get
		{
			return entityID_3;
		}
		set
		{
			entityID_3 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "acknowledgeFlag")]
	public ushort AcknowledgeFlag
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

	[XmlElement(Type = typeof(ushort), ElementName = "responseFlag")]
	public ushort ResponseFlag
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

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
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

	public AcknowledgePdu()
	{
		base.PduType = 15;
	}

	public static bool operator !=(AcknowledgePdu left, AcknowledgePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(AcknowledgePdu left, AcknowledgePdu right)
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
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + 2 + 2 + 4;
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
				entityID_3.Marshal(dos);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
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
				entityID_2.Unmarshal(dis);
				entityID_3.Unmarshal(dis);
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
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
		sb.AppendLine("<AcknowledgePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<originatingID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</originatingID>");
			sb.AppendLine("<receivingID>");
			entityID_3.Reflection(sb);
			sb.AppendLine("</receivingID>");
			sb.AppendLine("<acknowledgeFlag type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</acknowledgeFlag>");
			sb.AppendLine("<responseFlag type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</responseFlag>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</AcknowledgePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AcknowledgePdu;
	}

	public bool Equals(AcknowledgePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((SimulationManagementFamilyPdu)obj);
			if (!entityID_2.Equals(obj.entityID_2))
			{
				flag = false;
			}
			if (!entityID_3.Equals(obj.entityID_3))
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static AcknowledgePdu()
	{
		Class72.smethod_20();
	}
}
