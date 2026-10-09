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
[XmlRoot]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(TwoByteChunk))]
[XmlInclude(typeof(Point))]
public class MinefieldQueryPdu : MinefieldFamilyPdu, IEquatable<MinefieldQueryPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte OcxYfonIhxu;

	private uint uint_1;

	private EntityType entityType_0 = new EntityType();

	private List<Point> list_0 = new List<Point>();

	private List<TwoByteChunk> list_1 = new List<TwoByteChunk>();

	[XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
	public EntityID MinefieldID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
	public EntityID RequestingEntityID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "requestID")]
	public byte RequestID
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

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSensorTypes")]
	public byte NumberOfSensorTypes
	{
		get
		{
			return OcxYfonIhxu;
		}
		set
		{
			OcxYfonIhxu = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "dataFilter")]
	public uint DataFilter
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

	[XmlElement(Type = typeof(EntityType), ElementName = "requestedMineType")]
	public EntityType RequestedMineType
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

	[XmlElement(ElementName = "requestedPerimeterPointsList", Type = typeof(List<Point>))]
	public List<Point> RequestedPerimeterPoints => list_0;

	[XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
	public List<TwoByteChunk> SensorTypes => list_1;

	public MinefieldQueryPdu()
	{
		base.PduType = 38;
	}

	public static bool operator !=(MinefieldQueryPdu left, MinefieldQueryPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(MinefieldQueryPdu left, MinefieldQueryPdu right)
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
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		num++;
		num++;
		num += 4;
		num += entityType_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Point point = list_0[i];
			num += point.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			TwoByteChunk twoByteChunk = list_1[j];
			num += twoByteChunk.GetMarshalledSize();
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
			entityID_1.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_1.Count);
			dos.WriteUnsignedInt(uint_1);
			entityType_0.Marshal(dos);
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
			entityID_0.Unmarshal(dis);
			entityID_1.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			byte_6 = dis.ReadUnsignedByte();
			OcxYfonIhxu = dis.ReadUnsignedByte();
			uint_1 = dis.ReadUnsignedInt();
			entityType_0.Unmarshal(dis);
			for (int i = 0; i < NumberOfPerimeterPoints; i++)
			{
				Point point = new Point();
				point.Unmarshal(dis);
				list_0.Add(point);
			}
			for (int j = 0; j < NumberOfSensorTypes; j++)
			{
				TwoByteChunk twoByteChunk = new TwoByteChunk();
				twoByteChunk.Unmarshal(dis);
				list_1.Add(twoByteChunk);
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
		sb.AppendLine("<MinefieldQueryPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<minefieldID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</minefieldID>");
			sb.AppendLine("<requestingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</requestingEntityID>");
			sb.AppendLine("<requestID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<requestedPerimeterPoints type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</requestedPerimeterPoints>");
			sb.AppendLine("<pad2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<sensorTypes type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
			sb.AppendLine("<dataFilter type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
			sb.AppendLine("<requestedMineType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</requestedMineType>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<requestedPerimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Point\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</requestedPerimeterPoints" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<sensorTypes" + j.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</sensorTypes" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</MinefieldQueryPdu>");
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
		return this == obj as MinefieldQueryPdu;
	}

	public bool Equals(MinefieldQueryPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((MinefieldFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (!entityID_1.Equals(obj.entityID_1))
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
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (OcxYfonIhxu != obj.OcxYfonIhxu)
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		if (!entityType_0.Equals(obj.entityType_0))
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
		num = smethod_1(num) ^ entityID_0.GetHashCode();
		num = smethod_1(num) ^ entityID_1.GetHashCode();
		num = smethod_1(num) ^ byte_4.GetHashCode();
		num = smethod_1(num) ^ byte_5.GetHashCode();
		num = smethod_1(num) ^ byte_6.GetHashCode();
		num = smethod_1(num) ^ OcxYfonIhxu.GetHashCode();
		num = smethod_1(num) ^ uint_1.GetHashCode();
		num = smethod_1(num) ^ entityType_0.GetHashCode();
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

	static MinefieldQueryPdu()
	{
		Class72.smethod_20();
	}
}
