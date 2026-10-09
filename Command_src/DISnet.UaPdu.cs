using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class UaPdu : DistributedEmissionsFamilyPdu, IEquatable<UaPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private byte byte_6;

	private byte byte_7;

	private ushort ushort_1;

	private byte byte_8;

	private byte byte_9;

	private byte byte_10;

	private byte byte_11;

	private List<Vector3Float> list_0 = new List<Vector3Float>();

	private List<Vector3Float> list_1 = new List<Vector3Float>();

	private List<Vector3Float> list_2 = new List<Vector3Float>();

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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "eventID")]
	public EventIdentifier EventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "stateChangeIndicator")]
	public byte StateChangeIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "pad")]
	public byte Pad
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
			return byte_8;
		}
		set
		{
			byte_8 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfShafts")]
	public byte NumberOfShafts
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfAPAs")]
	public byte NumberOfAPAs
	{
		get
		{
			return byte_10;
		}
		set
		{
			byte_10 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfUAEmitterSystems")]
	public byte NumberOfUAEmitterSystems
	{
		get
		{
			return byte_11;
		}
		set
		{
			byte_11 = value;
		}
	}

	[XmlElement(ElementName = "shaftRPMsList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> ShaftRPMs => list_0;

	[XmlElement(ElementName = "apaDataList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> ApaData => list_1;

	[XmlElement(ElementName = "emitterSystemsList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> EmitterSystems => list_2;

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
		num += eventIdentifier_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Float vector3Float = list_0[i];
			num += vector3Float.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			Vector3Float vector3Float2 = list_1[j];
			num += vector3Float2.GetMarshalledSize();
		}
		for (int k = 0; k < list_2.Count; k++)
		{
			Vector3Float vector3Float3 = list_2[k];
			num += vector3Float3.GetMarshalledSize();
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
			eventIdentifier_0.Marshal(dos);
			dos.WriteByte(byte_6);
			dos.WriteByte(byte_7);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_8);
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
		catch (Exception e)
		{
			OnException(e);
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
			eventIdentifier_0.Unmarshal(dis);
			byte_6 = dis.ReadByte();
			byte_7 = dis.ReadByte();
			ushort_1 = dis.ReadUnsignedShort();
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			byte_10 = dis.ReadUnsignedByte();
			byte_11 = dis.ReadUnsignedByte();
			for (int i = 0; i < NumberOfShafts; i++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dis);
				list_0.Add(vector3Float);
			}
			for (int j = 0; j < NumberOfAPAs; j++)
			{
				Vector3Float vector3Float2 = new Vector3Float();
				vector3Float2.Unmarshal(dis);
				list_1.Add(vector3Float2);
			}
			for (int k = 0; k < NumberOfUAEmitterSystems; k++)
			{
				Vector3Float vector3Float3 = new Vector3Float();
				vector3Float3.Unmarshal(dis);
				list_2.Add(vector3Float3);
			}
		}
		catch (Exception e)
		{
			OnException(e);
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
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<stateChangeIndicator type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</stateChangeIndicator>");
			sb.AppendLine("<pad type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</pad>");
			sb.AppendLine("<passiveParameterIndex type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</passiveParameterIndex>");
			sb.AppendLine("<propulsionPlantConfiguration type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</propulsionPlantConfiguration>");
			sb.AppendLine("<shaftRPMs type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</shaftRPMs>");
			sb.AppendLine("<apaData type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</apaData>");
			sb.AppendLine("<emitterSystems type=\"byte\">" + list_2.Count.ToString(CultureInfo.InvariantCulture) + "</emitterSystems>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<shaftRPMs" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</shaftRPMs" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<apaData" + j.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</apaData" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int k = 0; k < list_2.Count; k++)
			{
				sb.AppendLine("<emitterSystems" + k.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_2[k].Reflection(sb);
				sb.AppendLine("</emitterSystems" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</UaPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
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
		if (!eventIdentifier_0.Equals(obj.eventIdentifier_0))
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
		if (ushort_1 != obj.ushort_1)
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
		if (byte_10 != obj.byte_10)
		{
			flag = false;
		}
		if (byte_11 != obj.byte_11)
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ eventIdentifier_0.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_8.GetHashCode();
		num = smethod_3(num) ^ byte_9.GetHashCode();
		num = smethod_3(num) ^ byte_10.GetHashCode();
		num = smethod_3(num) ^ byte_11.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_3(num) ^ list_1[j].GetHashCode();
			}
		}
		if (list_2.Count > 0)
		{
			for (int k = 0; k < list_2.Count; k++)
			{
				num = smethod_3(num) ^ list_2[k].GetHashCode();
			}
		}
		return num;
	}

	static UaPdu()
	{
		Class72.smethod_20();
	}
}
