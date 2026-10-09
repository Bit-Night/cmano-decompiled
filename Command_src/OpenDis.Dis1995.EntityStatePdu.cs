#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(DeadReckoningParameter))]
[XmlInclude(typeof(ArticulationParameter))]
public class EntityStatePdu : EntityInformationPdu, IEquatable<EntityStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private EntityType entityType_1 = new EntityType();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private int int_0;

	private DeadReckoningParameter deadReckoningParameter_0 = new DeadReckoningParameter();

	private byte[] byte_6 = new byte[12];

	private int int_1;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

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
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "articulationParameterCount")]
	public byte ArticulationParameterCount
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

	[XmlElement(Type = typeof(Orientation), ElementName = "entityOrientation")]
	public Orientation EntityOrientation
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
	public int EntityAppearance
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

	[XmlElement(Type = typeof(DeadReckoningParameter), ElementName = "deadReckoningParameters")]
	public DeadReckoningParameter DeadReckoningParameters
	{
		get
		{
			return deadReckoningParameter_0;
		}
		set
		{
			deadReckoningParameter_0 = value;
		}
	}

	[XmlArray(ElementName = "marking")]
	public byte[] Marking
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

	[XmlElement(Type = typeof(int), ElementName = "capabilities")]
	public int Capabilities
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

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
		num += orientation_0.GetMarshalledSize();
		num += 4;
		num += deadReckoningParameter_0.GetMarshalledSize();
		num += 12;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			ArticulationParameter articulationParameter = list_0[i];
			num += articulationParameter.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_4);
			dos.WriteByte((byte)list_0.Count);
			entityType_0.Marshal(dos);
			entityType_1.Marshal(dos);
			vector3Float_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			orientation_0.Marshal(dos);
			dos.WriteInt(int_0);
			deadReckoningParameter_0.Marshal(dos);
			for (int i = 0; i < byte_6.Length; i++)
			{
				dos.WriteByte(byte_6[i]);
			}
			dos.WriteInt(int_1);
			for (int j = 0; j < list_0.Count; j++)
			{
				list_0[j].Marshal(dos);
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
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadByte();
			entityType_0.Unmarshal(dis);
			entityType_1.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			orientation_0.Unmarshal(dis);
			int_0 = dis.ReadInt();
			deadReckoningParameter_0.Unmarshal(dis);
			for (int i = 0; i < byte_6.Length; i++)
			{
				byte_6[i] = dis.ReadByte();
			}
			int_1 = dis.ReadInt();
			for (int j = 0; j < ArticulationParameterCount; j++)
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
		sb.AppendLine("<EntityStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<entityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</entityID>");
			sb.AppendLine("<forceId type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceId>");
			sb.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
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
			orientation_0.Reflection(sb);
			sb.AppendLine("</entityOrientation>");
			sb.AppendLine("<entityAppearance type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			sb.AppendLine("<deadReckoningParameters>");
			deadReckoningParameter_0.Reflection(sb);
			sb.AppendLine("</deadReckoningParameters>");
			for (int i = 0; i < byte_6.Length; i++)
			{
				sb.AppendLine("<marking" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_6[i] + "</marking" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<capabilities type=\"int\">" + int_1.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
			for (int j = 0; j < list_0.Count; j++)
			{
				sb.AppendLine("<articulationParameters" + j.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[j].Reflection(sb);
				sb.AppendLine("</articulationParameters" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</EntityStatePdu>");
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
		return this == obj as EntityStatePdu;
	}

	public bool Equals(EntityStatePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((EntityInformationPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
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
		if (!orientation_0.Equals(obj.orientation_0))
		{
			flag = false;
		}
		if (int_0 != obj.int_0)
		{
			flag = false;
		}
		if (!deadReckoningParameter_0.Equals(obj.deadReckoningParameter_0))
		{
			flag = false;
		}
		if (obj.byte_6.Length != 12)
		{
			flag = false;
		}
		if (flag)
		{
			for (int i = 0; i < 12; i++)
			{
				if (byte_6[i] != obj.byte_6[i])
				{
					flag = false;
				}
			}
		}
		if (int_1 != obj.int_1)
		{
			flag = false;
		}
		if (list_0.Count != obj.list_0.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int j = 0; j < list_0.Count; j++)
			{
				if (!list_0[j].Equals(obj.list_0[j]))
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	private static int smethod_2(int int_2)
	{
		int_2 <<= 5 + int_2;
		return int_2;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ entityType_1.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ int_0.GetHashCode();
		num = smethod_2(num) ^ deadReckoningParameter_0.GetHashCode();
		for (int i = 0; i < 12; i++)
		{
			num = smethod_2(num) ^ byte_6[i].GetHashCode();
		}
		num = smethod_2(num) ^ int_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int j = 0; j < list_0.Count; j++)
			{
				num = smethod_2(num) ^ list_0[j].GetHashCode();
			}
		}
		return num;
	}

	static EntityStatePdu()
	{
		Class72.smethod_20();
	}
}
