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
[XmlInclude(typeof(BurstDescriptor))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class FirePdu : Warfare, IEquatable<FirePdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventID eventID_0 = new EventID();

	private int int_0;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private BurstDescriptor burstDescriptor_0 = new BurstDescriptor();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "munitionID")]
	public EntityID MunitionID
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

	[XmlElement(Type = typeof(int), ElementName = "fireMissionIndex")]
	public int FireMissionIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
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

	[XmlElement(Type = typeof(BurstDescriptor), ElementName = "burstDescriptor")]
	public BurstDescriptor BurstDescriptor
	{
		get
		{
			return burstDescriptor_0;
		}
		set
		{
			burstDescriptor_0 = value;
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
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_2.GetMarshalledSize() + eventID_0.GetMarshalledSize() + 4 + vector3Double_0.GetMarshalledSize() + burstDescriptor_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + 4;
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
			entityID_2.Marshal(dos);
			eventID_0.Marshal(dos);
			dos.WriteInt(int_0);
			vector3Double_0.Marshal(dos);
			burstDescriptor_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			dos.WriteFloat(float_0);
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
			entityID_2.Unmarshal(dis);
			eventID_0.Unmarshal(dis);
			int_0 = dis.ReadInt();
			vector3Double_0.Unmarshal(dis);
			burstDescriptor_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			float_0 = dis.ReadFloat();
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
		sb.AppendLine("<FirePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<munitionID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</munitionID>");
			sb.AppendLine("<eventID>");
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<fireMissionIndex type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</fireMissionIndex>");
			sb.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</locationInWorldCoordinates>");
			sb.AppendLine("<burstDescriptor>");
			burstDescriptor_0.Reflection(sb);
			sb.AppendLine("</burstDescriptor>");
			sb.AppendLine("<velocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<range type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</range>");
			sb.AppendLine("</FirePdu>");
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
		return this == obj as FirePdu;
	}

	public bool Equals(FirePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((Warfare)obj);
			if (!entityID_2.Equals(obj.entityID_2))
			{
				flag = false;
			}
			if (!eventID_0.Equals(obj.eventID_0))
			{
				flag = false;
			}
			if (int_0 != obj.int_0)
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(obj.vector3Double_0))
			{
				flag = false;
			}
			if (!burstDescriptor_0.Equals(obj.burstDescriptor_0))
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
		return false;
	}

	private static int smethod_2(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_2.GetHashCode()) ^ eventID_0.GetHashCode()) ^ int_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ burstDescriptor_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode();
	}

	static FirePdu()
	{
		Class72.smethod_20();
	}
}
