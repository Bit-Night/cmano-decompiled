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
[XmlInclude(typeof(FourByteChunk))]
[XmlRoot]
public class RecordQueryReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<RecordQueryReliablePdu>
{
	private uint uint_1;

	private byte byte_4;

	private ushort ushort_1;

	private byte byte_5;

	private ushort ushort_2;

	private uint uint_2;

	private uint uint_3;

	private List<FourByteChunk> list_0 = new List<FourByteChunk>();

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
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

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
	public byte RequiredReliabilityService
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad1")]
	public ushort Pad1
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

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
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

	[XmlElement(Type = typeof(ushort), ElementName = "eventType")]
	public ushort EventType
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

	[XmlElement(Type = typeof(uint), ElementName = "time")]
	public uint Time
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecords")]
	public uint NumberOfRecords
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	[XmlElement(ElementName = "recordIDsList", Type = typeof(List<FourByteChunk>))]
	public List<FourByteChunk> RecordIDs => list_0;

	public RecordQueryReliablePdu()
	{
		base.PduType = 63;
	}

	public static bool operator !=(RecordQueryReliablePdu left, RecordQueryReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(RecordQueryReliablePdu left, RecordQueryReliablePdu right)
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
		num += 4;
		num++;
		num += 2;
		num++;
		num += 2;
		num += 4;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			FourByteChunk fourByteChunk = list_0[i];
			num += fourByteChunk.GetMarshalledSize();
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
			dos.WriteUnsignedInt(uint_1);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedInt(uint_2);
			dos.WriteUnsignedInt((uint)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
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
			uint_1 = dis.ReadUnsignedInt();
			byte_4 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			byte_5 = dis.ReadUnsignedByte();
			ushort_2 = dis.ReadUnsignedShort();
			uint_2 = dis.ReadUnsignedInt();
			uint_3 = dis.ReadUnsignedInt();
			for (int i = 0; i < NumberOfRecords; i++)
			{
				FourByteChunk fourByteChunk = new FourByteChunk();
				fourByteChunk.Unmarshal(dis);
				list_0.Add(fourByteChunk);
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
		sb.AppendLine("<RecordQueryReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			sb.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("<pad2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<eventType type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</eventType>");
			sb.AppendLine("<time type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</time>");
			sb.AppendLine("<recordIDs type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordIDs>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<recordIDs" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</recordIDs" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</RecordQueryReliablePdu>");
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
		return this == obj as RecordQueryReliablePdu;
	}

	public bool Equals(RecordQueryReliablePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SimulationManagementWithReliabilityFamilyPdu)obj);
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		if (byte_4 != obj.byte_4)
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (byte_5 != obj.byte_5)
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (uint_2 != obj.uint_2)
		{
			flag = false;
		}
		if (uint_3 != obj.uint_3)
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

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ uint_2.GetHashCode();
		num = smethod_2(num) ^ uint_3.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static RecordQueryReliablePdu()
	{
		Class72.smethod_20();
	}
}
