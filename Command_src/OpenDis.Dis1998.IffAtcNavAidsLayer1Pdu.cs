#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(IffFundamentalData))]
[XmlInclude(typeof(SystemID))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EventID))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class IffAtcNavAidsLayer1Pdu : DistributedEmissionsFamilyPdu, IEquatable<IffAtcNavAidsLayer1Pdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private SystemID systemID_0 = new SystemID();

	private ushort ushort_1;

	private IffFundamentalData iffFundamentalData_0 = new IffFundamentalData();

	[XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityId")]
	public EntityID EmittingEntityId
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
	public Vector3Float Location
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

	[XmlElement(Type = typeof(SystemID), ElementName = "systemID")]
	public SystemID SystemID
	{
		get
		{
			return systemID_0;
		}
		set
		{
			systemID_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "pad2")]
	public ushort Pad2
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

	[XmlElement(Type = typeof(IffFundamentalData), ElementName = "fundamentalParameters")]
	public IffFundamentalData FundamentalParameters
	{
		get
		{
			return iffFundamentalData_0;
		}
		set
		{
			iffFundamentalData_0 = value;
		}
	}

	public IffAtcNavAidsLayer1Pdu()
	{
		base.PduType = 28;
	}

	public static bool operator !=(IffAtcNavAidsLayer1Pdu left, IffAtcNavAidsLayer1Pdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(IffAtcNavAidsLayer1Pdu left, IffAtcNavAidsLayer1Pdu right)
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
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + eventID_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + systemID_0.GetMarshalledSize() + 2 + iffFundamentalData_0.GetMarshalledSize();
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
			eventID_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			systemID_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_1);
			iffFundamentalData_0.Marshal(dos);
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
			eventID_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			systemID_0.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			iffFundamentalData_0.Unmarshal(dis);
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
		sb.AppendLine("<IffAtcNavAidsLayer1Pdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<emittingEntityId>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</emittingEntityId>");
			sb.AppendLine("<eventID>");
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<location>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</location>");
			sb.AppendLine("<systemID>");
			systemID_0.Reflection(sb);
			sb.AppendLine("</systemID>");
			sb.AppendLine("<pad2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<fundamentalParameters>");
			iffFundamentalData_0.Reflection(sb);
			sb.AppendLine("</fundamentalParameters>");
			sb.AppendLine("</IffAtcNavAidsLayer1Pdu>");
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
		return this == obj as IffAtcNavAidsLayer1Pdu;
	}

	public bool Equals(IffAtcNavAidsLayer1Pdu obj)
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
		if (!eventID_0.Equals(obj.eventID_0))
		{
			flag = false;
		}
		if (!vector3Float_0.Equals(obj.vector3Float_0))
		{
			flag = false;
		}
		if (!systemID_0.Equals(obj.systemID_0))
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (!iffFundamentalData_0.Equals(obj.iffFundamentalData_0))
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ eventID_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ systemID_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ iffFundamentalData_0.GetHashCode();
	}

	static IffAtcNavAidsLayer1Pdu()
	{
		Class72.smethod_20();
	}
}
