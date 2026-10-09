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
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(Point))]
public class MinefieldStatePdu : MinefieldFamilyPdu, IEquatable<MinefieldStatePdu>
{
	private EntityID kRrYfXicgJk = new EntityID();

	private ushort CtfYfurYsun;

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private ushort ushort_1;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private ushort ushort_2;

	private ushort ushort_3;

	private List<Point> list_0 = new List<Point>();

	private List<EntityType> list_1 = new List<EntityType>();

	[XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
	public EntityID MinefieldID
	{
		get
		{
			return kRrYfXicgJk;
		}
		set
		{
			kRrYfXicgJk = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "minefieldSequence")]
	public ushort MinefieldSequence
	{
		get
		{
			return CtfYfurYsun;
		}
		set
		{
			CtfYfurYsun = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "forceID")]
	public byte ForceID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfPerimeterPoints")]
	public byte NumberOfPerimeterPoints
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
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
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

	[XmlElement(Type = typeof(Orientation), ElementName = "minefieldOrientation")]
	public Orientation MinefieldOrientation
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

	[XmlElement(Type = typeof(ushort), ElementName = "appearance")]
	public ushort Appearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "protocolMode")]
	public ushort ProtocolMode
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

	[XmlElement(ElementName = "perimeterPointsList", Type = typeof(List<Point>))]
	public List<Point> PerimeterPoints => list_0;

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
		num += kRrYfXicgJk.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 2;
		num += vector3Double_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			Point point = list_0[i];
			num += point.GetMarshalledSize();
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
			kRrYfXicgJk.Marshal(dos);
			dos.WriteUnsignedShort(CtfYfurYsun);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			entityType_0.Marshal(dos);
			dos.WriteUnsignedShort((ushort)list_1.Count);
			vector3Double_0.Marshal(dos);
			orientation_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort(ushort_3);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
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
			kRrYfXicgJk.Unmarshal(dis);
			CtfYfurYsun = dis.ReadUnsignedShort();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			vector3Double_0.Unmarshal(dis);
			orientation_0.Unmarshal(dis);
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfPerimeterPoints; i++)
			{
				Point point = new Point();
				point.Unmarshal(dis);
				list_0.Add(point);
			}
			for (int j = 0; j < NumberOfMineTypes; j++)
			{
				EntityType entityType = new EntityType();
				entityType.Unmarshal(dis);
				list_1.Add(entityType);
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
		sb.AppendLine("<MinefieldStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<minefieldID>");
			kRrYfXicgJk.Reflection(sb);
			sb.AppendLine("</minefieldID>");
			sb.AppendLine("<minefieldSequence type=\"ushort\">" + CtfYfurYsun.ToString(CultureInfo.InvariantCulture) + "</minefieldSequence>");
			sb.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			sb.AppendLine("<perimeterPoints type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</perimeterPoints>");
			sb.AppendLine("<minefieldType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</minefieldType>");
			sb.AppendLine("<mineType type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</mineType>");
			sb.AppendLine("<minefieldLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</minefieldLocation>");
			sb.AppendLine("<minefieldOrientation>");
			orientation_0.Reflection(sb);
			sb.AppendLine("</minefieldOrientation>");
			sb.AppendLine("<appearance type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</appearance>");
			sb.AppendLine("<protocolMode type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</protocolMode>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<perimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
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
		return this == obj as MinefieldStatePdu;
	}

	public bool Equals(MinefieldStatePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((MinefieldFamilyPdu)obj);
		if (!kRrYfXicgJk.Equals(obj.kRrYfXicgJk))
		{
			flag = false;
		}
		if (CtfYfurYsun != obj.CtfYfurYsun)
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
		if (ushort_1 != obj.ushort_1)
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
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (ushort_3 != obj.ushort_3)
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

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_1(0) ^ base.GetHashCode();
		num = smethod_1(num) ^ kRrYfXicgJk.GetHashCode();
		num = smethod_1(num) ^ CtfYfurYsun.GetHashCode();
		num = smethod_1(num) ^ byte_4.GetHashCode();
		num = smethod_1(num) ^ byte_5.GetHashCode();
		num = smethod_1(num) ^ entityType_0.GetHashCode();
		num = smethod_1(num) ^ ushort_1.GetHashCode();
		num = smethod_1(num) ^ vector3Double_0.GetHashCode();
		num = smethod_1(num) ^ orientation_0.GetHashCode();
		num = smethod_1(num) ^ ushort_2.GetHashCode();
		num = smethod_1(num) ^ ushort_3.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_1(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_1(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}

	static MinefieldStatePdu()
	{
		Class72.smethod_20();
	}
}
