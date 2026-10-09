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
[XmlInclude(typeof(AcousticEmitterSystemData))]
[XmlInclude(typeof(ApaData))]
[XmlInclude(typeof(ShaftRPMs))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class UaPdu : DistributedEmissionsFamilyPdu, IEquatable<UaPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_1;

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private List<ShaftRPMs> list_0 = new List<ShaftRPMs>();

	private List<ApaData> list_1 = new List<ApaData>();

	private List<AcousticEmitterSystemData> list_2 = new List<AcousticEmitterSystemData>();

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

	[XmlElement(Type = typeof(byte), ElementName = "stateChangeIndicator")]
	public byte StateChangeIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "pad")]
	public byte Pad
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

	[XmlElement(Type = typeof(ushort), ElementName = "passiveParameterIndex")]
	public ushort PassiveParameterIndex
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

	[XmlElement(Type = typeof(byte), ElementName = "propulsionPlantConfiguration")]
	public byte PropulsionPlantConfiguration
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfShafts")]
	public byte NumberOfShafts
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfAPAs")]
	public byte NumberOfAPAs
	{
		get
		{
			return byte_8;
		}
		set
		{
			byte_8 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfUAEmitterSystems")]
	public byte NumberOfUAEmitterSystems
	{
		get
		{
			return byte_9;
		}
		set
		{
			byte_9 = value;
		}
	}

	[XmlElement(ElementName = "shaftRPMsList", Type = typeof(List<ShaftRPMs>))]
	public List<ShaftRPMs> ShaftRPMs => list_0;

	[XmlElement(ElementName = "apaDataList", Type = typeof(List<ApaData>))]
	public List<ApaData> ApaData => list_1;

	[XmlElement(ElementName = "emitterSystemsList", Type = typeof(List<AcousticEmitterSystemData>))]
	public List<AcousticEmitterSystemData> EmitterSystems => list_2;

	public UaPdu()
	{
		base.PduType = 29;
	}

	public static bool operator !=(UaPdu left, UaPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(UaPdu left, UaPdu right)
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
		num++;
		num++;
		num++;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			ShaftRPMs shaftRPMs = list_0[i];
			num += shaftRPMs.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			ApaData apaData = list_1[j];
			num += apaData.GetMarshalledSize();
		}
		for (int k = 0; k < list_2.Count; k++)
		{
			AcousticEmitterSystemData acousticEmitterSystemData = list_2[k];
			num += acousticEmitterSystemData.GetMarshalledSize();
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
			dos.WriteByte(byte_4);
			dos.WriteByte(byte_5);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedByte((byte)list_1.Count);
			dos.WriteUnsignedByte((byte)list_2.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
			}
			for (int k = 0; k < list_2.Count; k++)
			{
				list_2[k].Marshal(dos);
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
			byte_4 = dis.ReadByte();
			byte_5 = dis.ReadByte();
			ushort_1 = dis.ReadUnsignedShort();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			for (int i = 0; i < NumberOfShafts; i++)
			{
				ShaftRPMs shaftRPMs = new ShaftRPMs();
				shaftRPMs.Unmarshal(dis);
				list_0.Add(shaftRPMs);
			}
			for (int j = 0; j < NumberOfAPAs; j++)
			{
				ApaData apaData = new ApaData();
				apaData.Unmarshal(dis);
				list_1.Add(apaData);
			}
			for (int k = 0; k < NumberOfUAEmitterSystems; k++)
			{
				AcousticEmitterSystemData acousticEmitterSystemData = new AcousticEmitterSystemData();
				acousticEmitterSystemData.Unmarshal(dis);
				list_2.Add(acousticEmitterSystemData);
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
		sb.AppendLine("<UaPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</emittingEntityID>");
			sb.AppendLine("<eventID>");
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<stateChangeIndicator type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</stateChangeIndicator>");
			sb.AppendLine("<pad type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad>");
			sb.AppendLine("<passiveParameterIndex type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</passiveParameterIndex>");
			sb.AppendLine("<propulsionPlantConfiguration type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</propulsionPlantConfiguration>");
			sb.AppendLine("<shaftRPMs type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</shaftRPMs>");
			sb.AppendLine("<apaData type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</apaData>");
			sb.AppendLine("<emitterSystems type=\"byte\">" + list_2.Count.ToString(CultureInfo.InvariantCulture) + "</emitterSystems>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<shaftRPMs" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ShaftRPMs\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</shaftRPMs" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<apaData" + j.ToString(CultureInfo.InvariantCulture) + " type=\"ApaData\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</apaData" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int k = 0; k < list_2.Count; k++)
			{
				sb.AppendLine("<emitterSystems" + k.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticEmitterSystemData\">");
				list_2[k].Reflection(sb);
				sb.AppendLine("</emitterSystems" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</UaPdu>");
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
		return this == obj as UaPdu;
	}

	public bool Equals(UaPdu obj)
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
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (byte_7 != obj.byte_7)
		{
			flag = false;
		}
		if (byte_8 != obj.byte_8)
		{
			flag = false;
		}
		if (byte_9 != obj.byte_9)
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
		if (list_1.Count != obj.list_1.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				if (!list_1[j].Equals(obj.list_1[j]))
				{
					flag = false;
				}
			}
		}
		if (list_2.Count != obj.list_2.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int k = 0; k < list_2.Count; k++)
			{
				if (!list_2[k].Equals(obj.list_2[k]))
				{
					flag = false;
				}
			}
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
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ eventID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ byte_9.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_2(num) ^ list_1[j].GetHashCode();
			}
		}
		if (list_2.Count > 0)
		{
			for (int k = 0; k < list_2.Count; k++)
			{
				num = smethod_2(num) ^ list_2[k].GetHashCode();
			}
		}
		return num;
	}

	static UaPdu()
	{
		Class72.smethod_20();
	}
}
