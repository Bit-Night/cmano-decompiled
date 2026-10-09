using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(MunitionDescriptor))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(VariableParameter))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EventIdentifier))]
public class DetonationPdu : WarfareFamilyPdu, IEquatable<DetonationPdu>
{
	private EntityID entityID_2 = new EntityID();

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private MunitionDescriptor munitionDescriptor_0 = new MunitionDescriptor();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private byte byte_6;

	private byte byte_7;

	private ushort ushort_1;

	private List<VariableParameter> list_0 = new List<VariableParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "explodingEntityID")]
	public EntityID ExplodingEntityID
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

	[XmlElement(Type = typeof(MunitionDescriptor), ElementName = "descriptor")]
	public MunitionDescriptor Descriptor
	{
		get
		{
			return munitionDescriptor_0;
		}
		set
		{
			munitionDescriptor_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "locationOfEntityCoordinates")]
	public Vector3Float LocationOfEntityCoordinates
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

	[XmlElement(Type = typeof(byte), ElementName = "detonationResult")]
	public byte DetonationResult
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfVariableParameters")]
	public byte NumberOfVariableParameters
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad")]
	public ushort Pad
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

	[XmlElement(ElementName = "variableParametersList", Type = typeof(List<VariableParameter>))]
	public List<VariableParameter> VariableParameters => list_0;

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
		num = base.GetMarshalledSize();
		num += entityID_2.GetMarshalledSize();
		num += eventIdentifier_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += munitionDescriptor_0.GetMarshalledSize();
		num += vector3Float_1.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			VariableParameter variableParameter = list_0[i];
			num += variableParameter.GetMarshalledSize();
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
			entityID_2.Marshal(dos);
			eventIdentifier_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			munitionDescriptor_0.Marshal(dos);
			vector3Float_1.Marshal(dos);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedShort(ushort_1);
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
			entityID_2.Unmarshal(dis);
			eventIdentifier_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			munitionDescriptor_0.Unmarshal(dis);
			vector3Float_1.Unmarshal(dis);
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfVariableParameters; i++)
			{
				VariableParameter variableParameter = new VariableParameter();
				variableParameter.Unmarshal(dis);
				list_0.Add(variableParameter);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DetonationPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<explodingEntityID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</explodingEntityID>");
			sb.AppendLine("<eventID>");
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<velocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<locationInWorldCoordinates>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</locationInWorldCoordinates>");
			sb.AppendLine("<descriptor>");
			munitionDescriptor_0.Reflection(sb);
			sb.AppendLine("</descriptor>");
			sb.AppendLine("<locationOfEntityCoordinates>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</locationOfEntityCoordinates>");
			sb.AppendLine("<detonationResult type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</detonationResult>");
			sb.AppendLine("<variableParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableParameters>");
			sb.AppendLine("<pad type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<variableParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableParameter\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</variableParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</DetonationPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
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
			if (!eventIdentifier_0.Equals(obj.eventIdentifier_0))
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
			if (!munitionDescriptor_0.Equals(obj.munitionDescriptor_0))
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(obj.vector3Float_1))
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
		num = smethod_3(num) ^ entityID_2.GetHashCode();
		num = smethod_3(num) ^ eventIdentifier_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		num = smethod_3(num) ^ vector3Double_0.GetHashCode();
		num = smethod_3(num) ^ munitionDescriptor_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_1.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static DetonationPdu()
	{
		Class72.smethod_20();
	}
}
