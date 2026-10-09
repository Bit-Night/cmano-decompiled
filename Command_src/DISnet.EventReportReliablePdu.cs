using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(FixedDatum))]
[XmlRoot]
public class EventReportReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<EventReportReliablePdu>
{
	private ushort ushort_1;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private List<FixedDatum> list_0 = new List<FixedDatum>();

	private List<VariableDatum> list_1 = new List<VariableDatum>();

	[XmlElement(Type = typeof(ushort), ElementName = "eventType")]
	public ushort EventType
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

	[XmlElement(Type = typeof(uint), ElementName = "pad1")]
	public uint Pad1
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatumRecords")]
	public uint NumberOfFixedDatumRecords
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
	public uint NumberOfVariableDatumRecords
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

	[XmlElement(ElementName = "fixedDatumRecordsList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatumRecords => list_0;

	[XmlElement(ElementName = "variableDatumRecordsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatumRecords => list_1;

	public EventReportReliablePdu()
	{
		base.PduType = 61;
	}

	public static bool operator !=(EventReportReliablePdu left, EventReportReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(EventReportReliablePdu left, EventReportReliablePdu right)
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
		num += 2;
		num += 4;
		num += 4;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			FixedDatum fixedDatum = list_0[i];
			num += fixedDatum.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			VariableDatum variableDatum = list_1[j];
			num += variableDatum.GetMarshalledSize();
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
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedInt(uint_1);
			dos.WriteUnsignedInt((uint)list_0.Count);
			dos.WriteUnsignedInt((uint)list_1.Count);
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
			ushort_1 = dis.ReadUnsignedShort();
			uint_1 = dis.ReadUnsignedInt();
			uint_2 = dis.ReadUnsignedInt();
			uint_3 = dis.ReadUnsignedInt();
			for (int i = 0; i < NumberOfFixedDatumRecords; i++)
			{
				FixedDatum fixedDatum = new FixedDatum();
				fixedDatum.Unmarshal(dis);
				list_0.Add(fixedDatum);
			}
			for (int j = 0; j < NumberOfVariableDatumRecords; j++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dis);
				list_1.Add(variableDatum);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EventReportReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<eventType type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</eventType>");
			sb.AppendLine("<pad1 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("<fixedDatumRecords type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatumRecords>");
			sb.AppendLine("<variableDatumRecords type=\"uint\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumRecords>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<fixedDatumRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</fixedDatumRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<variableDatumRecords" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</variableDatumRecords" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</EventReportReliablePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EventReportReliablePdu;
	}

	public bool Equals(EventReportReliablePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SimulationManagementWithReliabilityFamilyPdu)obj);
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ uint_2.GetHashCode();
		num = smethod_3(num) ^ uint_3.GetHashCode();
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

	static EventReportReliablePdu()
	{
		Class72.smethod_20();
	}
}
