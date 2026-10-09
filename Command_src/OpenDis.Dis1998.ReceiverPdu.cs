#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class ReceiverPdu : RadioCommunicationsFamilyPdu, IEquatable<ReceiverPdu>
{
	private ushort ushort_2;

	private ushort ushort_3;

	private float float_0;

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_4;

	[XmlElement(Type = typeof(ushort), ElementName = "receiverState")]
	public ushort ReceiverState
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

	[XmlElement(Type = typeof(float), ElementName = "receivedPoser")]
	public float ReceivedPoser
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

	[XmlElement(Type = typeof(EntityID), ElementName = "transmitterEntityId")]
	public EntityID TransmitterEntityId
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

	[XmlElement(Type = typeof(ushort), ElementName = "transmitterRadioId")]
	public ushort TransmitterRadioId
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	public ReceiverPdu()
	{
		base.PduType = 27;
	}

	public static bool operator !=(ReceiverPdu left, ReceiverPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(ReceiverPdu left, ReceiverPdu right)
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
		return base.GetMarshalledSize() + 2 + 2 + 4 + entityID_1.GetMarshalledSize() + 2;
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
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort(ushort_3);
			dos.WriteFloat(float_0);
			entityID_1.Marshal(dos);
			dos.WriteUnsignedShort(ushort_4);
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
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			float_0 = dis.ReadFloat();
			entityID_1.Unmarshal(dis);
			ushort_4 = dis.ReadUnsignedShort();
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
		sb.AppendLine("<ReceiverPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<receiverState type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</receiverState>");
			sb.AppendLine("<padding1 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<receivedPoser type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</receivedPoser>");
			sb.AppendLine("<transmitterEntityId>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</transmitterEntityId>");
			sb.AppendLine("<transmitterRadioId type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</transmitterRadioId>");
			sb.AppendLine("</ReceiverPdu>");
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
		return this == obj as ReceiverPdu;
	}

	public bool Equals(ReceiverPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((RadioCommunicationsFamilyPdu)obj);
			if (ushort_2 != obj.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != obj.ushort_3)
			{
				flag = false;
			}
			if (float_0 != obj.float_0)
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (ushort_4 != obj.ushort_4)
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ float_0.GetHashCode()) ^ entityID_1.GetHashCode()) ^ ushort_4.GetHashCode();
	}

	static ReceiverPdu()
	{
		Class72.smethod_20();
	}
}
