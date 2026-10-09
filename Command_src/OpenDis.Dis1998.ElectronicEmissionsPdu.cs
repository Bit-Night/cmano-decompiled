#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(ElectronicEmissionSystemData))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class ElectronicEmissionsPdu : DistributedEmissionsFamilyPdu, IEquatable<ElectronicEmissionsPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_1;

	private List<ElectronicEmissionSystemData> list_0 = new List<ElectronicEmissionSystemData>();

	[XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
	public EntityID EmittingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
	public byte StateUpdateIndicator
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
	public byte NumberOfSystems
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "paddingForEmissionsPdu")]
	public ushort PaddingForEmissionsPdu
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

	[XmlElement(ElementName = "systemsList", Type = typeof(List<ElectronicEmissionSystemData>))]
	public List<ElectronicEmissionSystemData> Systems => list_0;

	public ElectronicEmissionsPdu()
	{
		base.PduType = 23;
	}

	public static bool operator !=(ElectronicEmissionsPdu left, ElectronicEmissionsPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(ElectronicEmissionsPdu left, ElectronicEmissionsPdu right)
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
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += eventID_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			ElectronicEmissionSystemData electronicEmissionSystemData = list_0[i];
			num += electronicEmissionSystemData.GetMarshalledSize();
		}
		return num;
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
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedShort(ushort_1);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
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
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfSystems; i++)
			{
				ElectronicEmissionSystemData electronicEmissionSystemData = new ElectronicEmissionSystemData();
				electronicEmissionSystemData.Unmarshal(dis);
				list_0.Add(electronicEmissionSystemData);
			}
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
		sb.AppendLine("<ElectronicEmissionsPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</emittingEntityID>");
			sb.AppendLine("<eventID>");
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<stateUpdateIndicator type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
			sb.AppendLine("<systems type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</systems>");
			sb.AppendLine("<paddingForEmissionsPdu type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</paddingForEmissionsPdu>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<systems" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionSystemData\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</systems" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ElectronicEmissionsPdu>");
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
		return this == obj as ElectronicEmissionsPdu;
	}

	public bool Equals(ElectronicEmissionsPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((DistributedEmissionsFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!eventID_0.Equals(obj.eventID_0))
			{
				flag = false;
			}
			if (byte_4 != obj.byte_4)
			{
				flag = false;
			}
			if (byte_5 != obj.byte_5)
			{
				flag = false;
			}
			if (ushort_1 != obj.ushort_1)
			{
				flag = false;
			}
			if (list_0.Count != obj.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!list_0[i].Equals(obj.list_0[i]))
					{
						flag = false;
					}
				}
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
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ eventID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ElectronicEmissionsPdu()
	{
		Class72.smethod_20();
	}
}
