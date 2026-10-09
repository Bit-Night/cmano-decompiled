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
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(TwoByteChunk))]
[XmlInclude(typeof(Vector3Float))]
public class MinefieldDataPdu : MinefieldFamilyPdu, IEquatable<MinefieldDataPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private uint uint_1;

	private EntityType entityType_0 = new EntityType();

	private List<TwoByteChunk> list_0 = new List<TwoByteChunk>();

	private byte byte_10;

	private List<Vector3Float> list_1 = new List<Vector3Float>();

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

	[XmlElement(Type = typeof(ushort), ElementName = "minefieldSequenceNumbeer")]
	public ushort MinefieldSequenceNumbeer
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

	[XmlElement(Type = typeof(byte), ElementName = "pduSequenceNumber")]
	public byte PduSequenceNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfPdus")]
	public byte NumberOfPdus
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfMinesInThisPdu")]
	public byte NumberOfMinesInThisPdu
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSensorTypes")]
	public byte NumberOfSensorTypes
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

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
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

	[XmlElement(Type = typeof(EntityType), ElementName = "mineType")]
	public EntityType MineType
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

	[XmlElement(ElementName = "sensorTypesList", Type = typeof(List<TwoByteChunk>))]
	public List<TwoByteChunk> SensorTypes => list_0;

	[XmlElement(Type = typeof(byte), ElementName = "pad3")]
	public byte Pad3
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

	[XmlElement(ElementName = "mineLocationList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> MineLocation => list_1;

	public MinefieldDataPdu()
	{
		base.PduType = 39;
	}

	public static bool operator !=(MinefieldDataPdu left, MinefieldDataPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(MinefieldDataPdu left, MinefieldDataPdu right)
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
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num++;
		num++;
		num += 4;
		num += entityType_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			TwoByteChunk twoByteChunk = list_0[i];
			num += twoByteChunk.GetMarshalledSize();
		}
		num++;
		for (int j = 0; j < list_1.Count; j++)
		{
			Vector3Float vector3Float = list_1[j];
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
			entityID_1.Marshal(dos);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_1.Count);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedByte(byte_9);
			dos.WriteUnsignedInt(uint_1);
			entityType_0.Marshal(dos);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			dos.WriteUnsignedByte(byte_10);
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
			ushort_1 = dis.ReadUnsignedShort();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			uint_1 = dis.ReadUnsignedInt();
			entityType_0.Unmarshal(dis);
			for (int i = 0; i < NumberOfSensorTypes; i++)
			{
				TwoByteChunk twoByteChunk = new TwoByteChunk();
				twoByteChunk.Unmarshal(dis);
				list_0.Add(twoByteChunk);
			}
			byte_10 = dis.ReadUnsignedByte();
			for (int j = 0; j < NumberOfMinesInThisPdu; j++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dis);
				list_1.Add(vector3Float);
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
		sb.AppendLine("<MinefieldDataPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<minefieldID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</minefieldID>");
			sb.AppendLine("<requestingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</requestingEntityID>");
			sb.AppendLine("<minefieldSequenceNumbeer type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</minefieldSequenceNumbeer>");
			sb.AppendLine("<requestID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<pduSequenceNumber type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pduSequenceNumber>");
			sb.AppendLine("<numberOfPdus type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</numberOfPdus>");
			sb.AppendLine("<mineLocation type=\"byte\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</mineLocation>");
			sb.AppendLine("<sensorTypes type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</sensorTypes>");
			sb.AppendLine("<pad2 type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<dataFilter type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</dataFilter>");
			sb.AppendLine("<mineType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</mineType>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<sensorTypes" + i.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</sensorTypes" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<pad3 type=\"byte\">" + byte_10.ToString(CultureInfo.InvariantCulture) + "</pad3>");
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<mineLocation" + j.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</mineLocation" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</MinefieldDataPdu>");
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
		return this == obj as MinefieldDataPdu;
	}

	public bool Equals(MinefieldDataPdu obj)
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
		if (ushort_1 != obj.ushort_1)
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
		if (byte_10 != obj.byte_10)
		{
			flag = false;
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
		num = smethod_1(num) ^ ushort_1.GetHashCode();
		num = smethod_1(num) ^ byte_4.GetHashCode();
		num = smethod_1(num) ^ byte_5.GetHashCode();
		num = smethod_1(num) ^ byte_6.GetHashCode();
		num = smethod_1(num) ^ byte_7.GetHashCode();
		num = smethod_1(num) ^ byte_8.GetHashCode();
		num = smethod_1(num) ^ byte_9.GetHashCode();
		num = smethod_1(num) ^ uint_1.GetHashCode();
		num = smethod_1(num) ^ entityType_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_1(num) ^ list_0[i].GetHashCode();
			}
		}
		num = smethod_1(num) ^ byte_10.GetHashCode();
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_1(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}

	static MinefieldDataPdu()
	{
		Class72.smethod_20();
	}
}
