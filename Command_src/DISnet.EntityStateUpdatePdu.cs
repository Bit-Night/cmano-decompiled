using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(VariableParameter))]
[XmlInclude(typeof(EulerAngles))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
public class EntityStateUpdatePdu : EntityInformationFamilyPdu, IEquatable<EntityStateUpdatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_6;

	private byte byte_7;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private uint uint_1;

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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(ElementName = "variableParametersList", Type = typeof(List<VariableParameter>))]
	public List<VariableParameter> VariableParameters => list_0;

	public EntityStateUpdatePdu()
	{
		base.PduType = 67;
		base.ProtocolFamily = 1;
	}

	public static bool operator !=(EntityStateUpdatePdu left, EntityStateUpdatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(EntityStateUpdatePdu left, EntityStateUpdatePdu right)
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
		num += entityID_0.GetMarshalledSize();
		num++;
		num++;
		num += vector3Float_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += eulerAngles_0.GetMarshalledSize();
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
			dos.WriteByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			vector3Float_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			eulerAngles_0.Marshal(dos);
			dos.WriteUnsignedInt(uint_1);
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
			byte_6 = dis.ReadByte();
			byte_7 = dis.ReadUnsignedByte();
			vector3Float_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			eulerAngles_0.Unmarshal(dis);
			uint_1 = dis.ReadUnsignedInt();
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
		sb.AppendLine("<EntityStateUpdatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<entityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</entityID>");
			sb.AppendLine("<padding1 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<variableParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</variableParameters>");
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
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<variableParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableParameter\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</variableParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</EntityStateUpdatePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityStateUpdatePdu;
	}

	public bool Equals(EntityStateUpdatePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
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
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		num = smethod_3(num) ^ vector3Double_0.GetHashCode();
		num = smethod_3(num) ^ eulerAngles_0.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static EntityStateUpdatePdu()
	{
		Class72.smethod_20();
	}
}
