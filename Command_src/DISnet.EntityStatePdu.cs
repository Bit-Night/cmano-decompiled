using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityMarking))]
[XmlInclude(typeof(VariableParameter))]
[XmlInclude(typeof(DeadReckoningParameters))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EulerAngles))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class EntityStatePdu : EntityInformationFamilyPdu, IEquatable<EntityStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_6;

	private byte byte_7;

	private EntityType entityType_0 = new EntityType();

	private EntityType entityType_1 = new EntityType();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private uint uint_1;

	private DeadReckoningParameters deadReckoningParameters_0 = new DeadReckoningParameters();

	private EntityMarking entityMarking_0 = new EntityMarking();

	private uint uint_2;

	private List<VariableParameter> list_0 = new List<VariableParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "forceId")]
	public byte ForceId
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

	[XmlElement(Type = typeof(EntityType), ElementName = "entityType")]
	public EntityType EntityType
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityType), ElementName = "alternativeEntityType")]
	public EntityType AlternativeEntityType
	{
		get
		{
			return entityType_1;
		}
		set
		{
			entityType_1 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearVelocity")]
	public Vector3Float EntityLinearVelocity
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "entityLocation")]
	public Vector3Double EntityLocation
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

	[XmlElement(Type = typeof(EulerAngles), ElementName = "entityOrientation")]
	public EulerAngles EntityOrientation
	{
		get
		{
			return eulerAngles_0;
		}
		set
		{
			eulerAngles_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "entityAppearance")]
	public uint EntityAppearance
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

	[XmlElement(Type = typeof(DeadReckoningParameters), ElementName = "deadReckoningParameters")]
	public DeadReckoningParameters DeadReckoningParameters
	{
		get
		{
			return deadReckoningParameters_0;
		}
		set
		{
			deadReckoningParameters_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityMarking), ElementName = "marking")]
	public EntityMarking Marking
	{
		get
		{
			return entityMarking_0;
		}
		set
		{
			entityMarking_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "capabilities")]
	public uint Capabilities
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	[XmlElement(ElementName = "variableParametersList", Type = typeof(List<VariableParameter>))]
	public List<VariableParameter> VariableParameters => list_0;

	public EntityStatePdu()
	{
		base.PduType = 1;
	}

	public static bool operator !=(EntityStatePdu left, EntityStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(EntityStatePdu left, EntityStatePdu right)
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
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += entityType_1.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += eulerAngles_0.GetMarshalledSize();
		num += 4;
		num += deadReckoningParameters_0.GetMarshalledSize();
		num += entityMarking_0.GetMarshalledSize();
		num += 4;
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
			entityID_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			entityType_0.Marshal(dos);
			entityType_1.Marshal(dos);
			vector3Float_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			eulerAngles_0.Marshal(dos);
			dos.WriteUnsignedInt(uint_1);
			deadReckoningParameters_0.Marshal(dos);
			entityMarking_0.Marshal(dos);
			dos.WriteUnsignedInt(uint_2);
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
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			entityType_1.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			eulerAngles_0.Unmarshal(dis);
			uint_1 = dis.ReadUnsignedInt();
			deadReckoningParameters_0.Unmarshal(dis);
			entityMarking_0.Unmarshal(dis);
			uint_2 = dis.ReadUnsignedInt();
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
		sb.AppendLine("<EntityStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<entityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</entityID>");
			sb.AppendLine("<forceId type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</forceId>");
			sb.AppendLine("<variableParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableParameters>");
			sb.AppendLine("<entityType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</entityType>");
			sb.AppendLine("<alternativeEntityType>");
			entityType_1.Reflection(sb);
			sb.AppendLine("</alternativeEntityType>");
			sb.AppendLine("<entityLinearVelocity>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</entityLinearVelocity>");
			sb.AppendLine("<entityLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</entityLocation>");
			sb.AppendLine("<entityOrientation>");
			eulerAngles_0.Reflection(sb);
			sb.AppendLine("</entityOrientation>");
			sb.AppendLine("<entityAppearance type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			sb.AppendLine("<deadReckoningParameters>");
			deadReckoningParameters_0.Reflection(sb);
			sb.AppendLine("</deadReckoningParameters>");
			sb.AppendLine("<marking>");
			entityMarking_0.Reflection(sb);
			sb.AppendLine("</marking>");
			sb.AppendLine("<capabilities type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<variableParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableParameter\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</variableParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</EntityStatePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityStatePdu;
	}

	public bool Equals(EntityStatePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((EntityInformationFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
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
		if (!entityType_0.Equals(obj.entityType_0))
		{
			flag = false;
		}
		if (!entityType_1.Equals(obj.entityType_1))
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
		if (!eulerAngles_0.Equals(obj.eulerAngles_0))
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		if (!deadReckoningParameters_0.Equals(obj.deadReckoningParameters_0))
		{
			flag = false;
		}
		if (!entityMarking_0.Equals(obj.entityMarking_0))
		{
			flag = false;
		}
		if (uint_2 != obj.uint_2)
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
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ entityType_1.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		num = smethod_3(num) ^ vector3Double_0.GetHashCode();
		num = smethod_3(num) ^ eulerAngles_0.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ deadReckoningParameters_0.GetHashCode();
		num = smethod_3(num) ^ entityMarking_0.GetHashCode();
		num = smethod_3(num) ^ uint_2.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static EntityStatePdu()
	{
		Class72.smethod_20();
	}
}
