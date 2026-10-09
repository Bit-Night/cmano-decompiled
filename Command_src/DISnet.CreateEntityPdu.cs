using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class CreateEntityPdu : SimulationManagementFamilyPdu, IEquatable<CreateEntityPdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

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

	public CreateEntityPdu()
	{
		base.PduType = 11;
	}

	public static bool operator !=(CreateEntityPdu left, CreateEntityPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(CreateEntityPdu left, CreateEntityPdu right)
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
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + 4;
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
		sb.AppendLine("<CreateEntityPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<originatingID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</originatingID>");
			sb.AppendLine("<receivingID>");
			entityID_3.Reflection(sb);
			sb.AppendLine("</receivingID>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</CreateEntityPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as CreateEntityPdu;
	}

	public bool Equals(CreateEntityPdu obj)
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
		return smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static CreateEntityPdu()
	{
		Class72.smethod_20();
	}
}
