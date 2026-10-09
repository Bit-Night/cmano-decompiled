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
[XmlInclude(typeof(RecordSet))]
[XmlRoot]
public class SetRecordReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<SetRecordReliablePdu>
{
	private uint uint_1;

	private byte byte_4;

	private ushort ushort_1;

	private byte byte_5;

	private uint uint_2;

	private List<RecordSet> list_0 = new List<RecordSet>();

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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfRecordSets")]
	public uint NumberOfRecordSets
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

	[XmlElement(ElementName = "recordSetsList", Type = typeof(List<RecordSet>))]
	public List<RecordSet> RecordSets => list_0;

	public SetRecordReliablePdu()
	{
		base.PduType = 64;
	}

	public static bool operator !=(SetRecordReliablePdu left, SetRecordReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(SetRecordReliablePdu left, SetRecordReliablePdu right)
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
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			RecordSet recordSet = list_0[i];
			num += recordSet.GetMarshalledSize();
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
			uint_2 = dis.ReadUnsignedInt();
			for (int i = 0; i < NumberOfRecordSets; i++)
			{
				RecordSet recordSet = new RecordSet();
				recordSet.Unmarshal(dis);
				list_0.Add(recordSet);
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
		sb.AppendLine("<SetRecordReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			sb.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("<pad2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<recordSets type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</recordSets>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<recordSets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"RecordSet\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</recordSets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</SetRecordReliablePdu>");
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
		return this == obj as SetRecordReliablePdu;
	}

	public bool Equals(SetRecordReliablePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
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
		return false;
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
		num = smethod_2(num) ^ uint_2.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static SetRecordReliablePdu()
	{
		Class72.smethod_20();
	}
}
