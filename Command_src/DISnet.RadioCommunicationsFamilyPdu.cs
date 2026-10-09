using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class RadioCommunicationsFamilyPdu : Pdu, IEquatable<RadioCommunicationsFamilyPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	[XmlElement(Type = typeof(EntityID), ElementName = "entityId")]
	public EntityID EntityId
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

	[XmlElement(Type = typeof(ushort), ElementName = "radioId")]
	public ushort RadioId
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

	public RadioCommunicationsFamilyPdu()
	{
		base.ProtocolFamily = 4;
	}

	public static bool operator !=(RadioCommunicationsFamilyPdu left, RadioCommunicationsFamilyPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(RadioCommunicationsFamilyPdu left, RadioCommunicationsFamilyPdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + 2;
	}

	public virtual void MarshalAutoLengthSet(DataOutputStream dos)
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
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<RadioCommunicationsFamilyPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<entityId>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</entityId>");
			sb.AppendLine("<radioId type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</radioId>");
			sb.AppendLine("</RadioCommunicationsFamilyPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RadioCommunicationsFamilyPdu;
	}

	public bool Equals(RadioCommunicationsFamilyPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((Pdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
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
		return smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_1.GetHashCode();
	}

	static RadioCommunicationsFamilyPdu()
	{
		Class72.smethod_20();
	}
}
