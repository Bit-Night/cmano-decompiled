#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;
using OpenDis.Enumerations.Warfare;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(BurstDescriptor))]
[XmlInclude(typeof(ArticulationParameter))]
public class DetonationPdu : WarfareFamilyPdu, IEquatable<DetonationPdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventID eventID_0 = new EventID();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private BurstDescriptor burstDescriptor_0 = new BurstDescriptor();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private byte byte_4;

	private byte byte_5;

	private short short_1;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "locationInEntityCoordinates")]
	public Vector3Float LocationInEntityCoordinates
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

	[XmlElement(Type = typeof(DetonationResult), ElementName = "detonationResult")]
	public byte DetonationResult
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
	public byte NumberOfArticulationParameters
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

	[XmlElement(Type = typeof(short), ElementName = "pad")]
	public short Pad
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

	public DetonationPdu()
	{
		base.PduType = 3;
	}

	public static bool operator !=(DetonationPdu left, DetonationPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(DetonationPdu left, DetonationPdu right)
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
		int num = 0;
		try
		{
			num = base.GetMarshalledSize();
			num += entityID_2.GetMarshalledSize();
			num += eventID_0.GetMarshalledSize();
			num += vector3Float_0.GetMarshalledSize();
			num += vector3Double_0.GetMarshalledSize();
			num += burstDescriptor_0.GetMarshalledSize();
			num += vector3Float_1.GetMarshalledSize();
			num++;
			num++;
			num += 2;
			for (int i = 0; i < list_0.Count; i++)
			{
				ArticulationParameter articulationParameter = list_0[i];
				num += articulationParameter.GetMarshalledSize();
			}
			return num;
		}
		catch (Exception)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
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
			vector3Float_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			burstDescriptor_0.Marshal(dos);
			vector3Float_1.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteShort(short_1);
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
			entityID_2.Unmarshal(dis);
			eventID_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			burstDescriptor_0.Unmarshal(dis);
			vector3Float_1.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			short_1 = dis.ReadShort();
			for (int i = 0; i < NumberOfArticulationParameters; i++)
			{
				ArticulationParameter articulationParameter = new ArticulationParameter();
				articulationParameter.Unmarshal(dis);
				list_0.Add(articulationParameter);
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
		sb.AppendLine("<DetonationPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<munitionID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</munitionID>");
			sb.AppendLine("<eventID>");
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<velocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</locationInWorldCoordinates>");
			sb.AppendLine("<burstDescriptor>");
			burstDescriptor_0.Reflection(sb);
			sb.AppendLine("</burstDescriptor>");
			sb.AppendLine("<locationInEntityCoordinates>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</locationInEntityCoordinates>");
			sb.AppendLine("<detonationResult type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
			sb.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
			sb.AppendLine("<pad type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</pad>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</articulationParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</DetonationPdu>");
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
		return this == obj as DetonationPdu;
	}

	public bool Equals(DetonationPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((WarfareFamilyPdu)obj);
			if (!entityID_2.Equals(obj.entityID_2))
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
			if (!vector3Double_0.Equals(obj.vector3Double_0))
			{
				flag = false;
			}
			if (!burstDescriptor_0.Equals(obj.burstDescriptor_0))
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(obj.vector3Float_1))
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
			if (short_1 != obj.short_1)
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
		num = smethod_2(num) ^ entityID_2.GetHashCode();
		num = smethod_2(num) ^ eventID_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ burstDescriptor_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ short_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static DetonationPdu()
	{
		Class72.smethod_20();
	}
}
