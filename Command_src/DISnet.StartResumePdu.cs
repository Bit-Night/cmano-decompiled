using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(ClockTime))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class StartResumePdu : SimulationManagementFamilyPdu, IEquatable<StartResumePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EntityID entityID_3 = new EntityID();

	private ClockTime clockTime_0 = new ClockTime();

	private ClockTime clockTime_1 = new ClockTime();

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

	[XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
	public ClockTime RealWorldTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(ClockTime), ElementName = "simulationTime")]
	public ClockTime SimulationTime
	{
		get
		{
			return clockTime_1;
		}
		set
		{
			clockTime_1 = value;
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

	public StartResumePdu()
	{
		base.PduType = 13;
	}

	public static bool operator !=(StartResumePdu left, StartResumePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(StartResumePdu left, StartResumePdu right)
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
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + entityID_3.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + clockTime_1.GetMarshalledSize() + 4;
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
				clockTime_0.Marshal(dos);
				clockTime_1.Marshal(dos);
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
				clockTime_0.Unmarshal(dis);
				clockTime_1.Unmarshal(dis);
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
		sb.AppendLine("<StartResumePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<originatingID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</originatingID>");
			sb.AppendLine("<receivingID>");
			entityID_3.Reflection(sb);
			sb.AppendLine("</receivingID>");
			sb.AppendLine("<realWorldTime>");
			clockTime_0.Reflection(sb);
			sb.AppendLine("</realWorldTime>");
			sb.AppendLine("<simulationTime>");
			clockTime_1.Reflection(sb);
			sb.AppendLine("</simulationTime>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</StartResumePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StartResumePdu;
	}

	public bool Equals(StartResumePdu obj)
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
			if (!clockTime_0.Equals(obj.clockTime_0))
			{
				flag = false;
			}
			if (!clockTime_1.Equals(obj.clockTime_1))
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
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ entityID_3.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ clockTime_1.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static StartResumePdu()
	{
		Class72.smethod_20();
	}
}
