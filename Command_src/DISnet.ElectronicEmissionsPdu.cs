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
[XmlInclude(typeof(EmitterSystem))]
[XmlRoot]
[XmlInclude(typeof(EventIdentifier))]
[XmlInclude(typeof(EntityID))]
public class ElectronicEmissionsPdu : DistributedEmissionsFamilyPdu, IEquatable<ElectronicEmissionsPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private byte byte_6;

	private byte byte_7;

	private ushort ushort_1;

	private byte byte_8;

	private byte byte_9;

	private EmitterSystem emitterSystem_0 = new EmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private List<Vector3Float> list_0 = new List<Vector3Float>();

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

	[XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
	public byte StateUpdateIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
	public byte NumberOfSystems
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

	[XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
	public byte SystemDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
	public byte NumberOfBeams
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

	[XmlElement(Type = typeof(EmitterSystem), ElementName = "emitterSystem")]
	public EmitterSystem EmitterSystem
	{
		get
		{
			return emitterSystem_0;
		}
		set
		{
			emitterSystem_0 = value;
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

	[XmlElement(ElementName = "systemsList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> Systems => list_0;

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
		num += eventIdentifier_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num += emitterSystem_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Float vector3Float = list_0[i];
			num += vector3Float.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_8);
			dos.WriteUnsignedByte(byte_9);
			emitterSystem_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
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
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			emitterSystem_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			for (int i = 0; i < NumberOfSystems; i++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dis);
				list_0.Add(vector3Float);
			}
		}
		catch (Exception e)
		{
			OnException(e);
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
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<stateUpdateIndicator type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
			sb.AppendLine("<systems type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</systems>");
			sb.AppendLine("<paddingForEmissionsPdu type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</paddingForEmissionsPdu>");
			sb.AppendLine("<systemDataLength type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
			sb.AppendLine("<numberOfBeams type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</numberOfBeams>");
			sb.AppendLine("<emitterSystem>");
			emitterSystem_0.Reflection(sb);
			sb.AppendLine("</emitterSystem>");
			sb.AppendLine("<location>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</location>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<systems" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</systems" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ElectronicEmissionsPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
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
			if (!emitterSystem_0.Equals(obj.emitterSystem_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(obj.vector3Float_0))
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
		num = smethod_3(num) ^ emitterSystem_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ElectronicEmissionsPdu()
	{
		Class72.smethod_20();
	}
}
