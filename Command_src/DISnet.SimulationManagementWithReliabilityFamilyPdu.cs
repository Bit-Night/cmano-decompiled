using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class SimulationManagementWithReliabilityFamilyPdu : Pdu, IEquatable<SimulationManagementWithReliabilityFamilyPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingEntityID")]
	public EntityID OriginatingEntityID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "receivingEntityID")]
	public EntityID ReceivingEntityID
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

	public SimulationManagementWithReliabilityFamilyPdu()
	{
		base.ProtocolFamily = 10;
	}

	public static bool operator !=(SimulationManagementWithReliabilityFamilyPdu left, SimulationManagementWithReliabilityFamilyPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(SimulationManagementWithReliabilityFamilyPdu left, SimulationManagementWithReliabilityFamilyPdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize();
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
				entityID_1.Marshal(dos);
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
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<SimulationManagementWithReliabilityFamilyPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<originatingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</originatingEntityID>");
			sb.AppendLine("<receivingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</receivingEntityID>");
			sb.AppendLine("</SimulationManagementWithReliabilityFamilyPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SimulationManagementWithReliabilityFamilyPdu;
	}

	public bool Equals(SimulationManagementWithReliabilityFamilyPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((Pdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
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
		return smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode();
	}

	static SimulationManagementWithReliabilityFamilyPdu()
	{
		Class72.smethod_20();
	}
}
