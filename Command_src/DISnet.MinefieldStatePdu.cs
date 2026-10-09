using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EulerAngles))]
[XmlInclude(typeof(Vector2Float))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
[XmlInclude(typeof(MinefieldIdentifier))]
public class MinefieldStatePdu : MinefieldFamilyPdu, IEquatable<MinefieldStatePdu>
{
	private MinefieldIdentifier minefieldIdentifier_0 = new MinefieldIdentifier();

	private ushort ushort_1;

	private byte byte_6;

	private byte byte_7;

	private EntityType entityType_0 = new EntityType();

	private ushort ushort_2;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private EulerAngles eulerAngles_0 = new EulerAngles();

	private ushort ushort_3;

	private ushort ushort_4;

	private List<Vector2Float> list_0 = new List<Vector2Float>();

	private List<EntityType> list_1 = new List<EntityType>();

	[XmlElement(Type = typeof(MinefieldIdentifier), ElementName = "minefieldID")]
	public MinefieldIdentifier MinefieldID
	{
		get
		{
			return minefieldIdentifier_0;
		}
		set
		{
			minefieldIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "minefieldSequence")]
	public ushort MinefieldSequence
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

	[XmlElement(Type = typeof(byte), ElementName = "forceID")]
	public byte ForceID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfPerimeterPoints")]
	public byte NumberOfPerimeterPoints
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

	[XmlElement(Type = typeof(EntityType), ElementName = "minefieldType")]
	public EntityType MinefieldType
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfMineTypes")]
	public ushort NumberOfMineTypes
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "minefieldLocation")]
	public Vector3Double MinefieldLocation
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

	[XmlElement(Type = typeof(EulerAngles), ElementName = "minefieldOrientation")]
	public EulerAngles MinefieldOrientation
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

	[XmlElement(Type = typeof(ushort), ElementName = "appearance")]
	public ushort Appearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "protocolMode")]
	public ushort ProtocolMode
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

	[XmlElement(ElementName = "perimeterPointsList", Type = typeof(List<Vector2Float>))]
	public List<Vector2Float> PerimeterPoints => list_0;

	[XmlElement(ElementName = "mineTypeList", Type = typeof(List<EntityType>))]
	public List<EntityType> MineType => list_1;

	public MinefieldStatePdu()
	{
		base.PduType = 37;
	}

	public static bool operator !=(MinefieldStatePdu left, MinefieldStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(MinefieldStatePdu left, MinefieldStatePdu right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += minefieldIdentifier_0.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 2;
		num += vector3Double_0.GetMarshalledSize();
		num += eulerAngles_0.GetMarshalledSize();
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector2Float vector2Float = list_0[i];
			num += vector2Float.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			EntityType entityType = list_1[j];
			num += entityType.GetMarshalledSize();
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
			minefieldIdentifier_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			entityType_0.Marshal(dos);
			dos.WriteUnsignedShort((ushort)list_1.Count);
			vector3Double_0.Marshal(dos);
			eulerAngles_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_3);
			dos.WriteUnsignedShort(ushort_4);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
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
			minefieldIdentifier_0.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			ushort_2 = dis.ReadUnsignedShort();
			vector3Double_0.Unmarshal(dis);
			eulerAngles_0.Unmarshal(dis);
			ushort_3 = dis.ReadUnsignedShort();
			ushort_4 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfPerimeterPoints; i++)
			{
				Vector2Float vector2Float = new Vector2Float();
				vector2Float.Unmarshal(dis);
				list_0.Add(vector2Float);
			}
			for (int j = 0; j < NumberOfMineTypes; j++)
			{
				EntityType entityType = new EntityType();
				entityType.Unmarshal(dis);
				list_1.Add(entityType);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<MinefieldStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<minefieldID>");
			minefieldIdentifier_0.Reflection(sb);
			sb.AppendLine("</minefieldID>");
			sb.AppendLine("<minefieldSequence type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</minefieldSequence>");
			sb.AppendLine("<forceID type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			sb.AppendLine("<perimeterPoints type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</perimeterPoints>");
			sb.AppendLine("<minefieldType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</minefieldType>");
			sb.AppendLine("<mineType type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</mineType>");
			sb.AppendLine("<minefieldLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</minefieldLocation>");
			sb.AppendLine("<minefieldOrientation>");
			eulerAngles_0.Reflection(sb);
			sb.AppendLine("</minefieldOrientation>");
			sb.AppendLine("<appearance type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</appearance>");
			sb.AppendLine("<protocolMode type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</protocolMode>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<perimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector2Float\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</perimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<mineType" + j.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</mineType" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</MinefieldStatePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as MinefieldStatePdu;
	}

	public bool Equals(MinefieldStatePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((MinefieldFamilyPdu)obj);
			if (!minefieldIdentifier_0.Equals(obj.minefieldIdentifier_0))
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
			if (!entityType_0.Equals(obj.entityType_0))
			{
				flag = false;
			}
			if (ushort_2 != obj.ushort_2)
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
			if (ushort_3 != obj.ushort_3)
			{
				flag = false;
			}
			if (ushort_4 != obj.ushort_4)
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
		num = smethod_3(num) ^ minefieldIdentifier_0.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ vector3Double_0.GetHashCode();
		num = smethod_3(num) ^ eulerAngles_0.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		num = smethod_3(num) ^ ushort_4.GetHashCode();
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
		return num;
	}

	static MinefieldStatePdu()
	{
		Class72.smethod_20();
	}
}
