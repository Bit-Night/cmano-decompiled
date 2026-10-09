using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(FixedDatum))]
public class DataQueryPdu : SimulationManagementFamilyPdu, IEquatable<DataQueryPdu>
{
	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private List<FixedDatum> list_0 = new List<FixedDatum>();

	private List<VariableDatum> list_1 = new List<VariableDatum>();

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

	[XmlElement(Type = typeof(uint), ElementName = "timeInterval")]
	public uint TimeInterval
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfFixedDatumRecords")]
	public uint NumberOfFixedDatumRecords
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

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
	public uint NumberOfVariableDatumRecords
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	[XmlElement(ElementName = "fixedDatumsList", Type = typeof(List<FixedDatum>))]
	public List<FixedDatum> FixedDatums => list_0;

	[XmlElement(ElementName = "variableDatumsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatums => list_1;

	public DataQueryPdu()
	{
		base.PduType = 18;
	}

	public static bool operator !=(DataQueryPdu left, DataQueryPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(DataQueryPdu left, DataQueryPdu right)
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
		num += 4;
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
			dos.WriteUnsignedInt(uint_1);
			dos.WriteUnsignedInt(uint_2);
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
			uint_1 = dis.ReadUnsignedInt();
			uint_2 = dis.ReadUnsignedInt();
			uint_3 = dis.ReadUnsignedInt();
			uint_4 = dis.ReadUnsignedInt();
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
		sb.AppendLine("<DataQueryPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<timeInterval type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</timeInterval>");
			sb.AppendLine("<fixedDatums type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</fixedDatums>");
			sb.AppendLine("<variableDatums type=\"uint\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatums>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<fixedDatums" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FixedDatum\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</fixedDatums" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<variableDatums" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</variableDatums" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</DataQueryPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DataQueryPdu;
	}

	public bool Equals(DataQueryPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SimulationManagementFamilyPdu)obj);
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
		if (uint_4 != obj.uint_4)
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
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ uint_2.GetHashCode();
		num = smethod_3(num) ^ uint_3.GetHashCode();
		num = smethod_3(num) ^ uint_4.GetHashCode();
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

	static DataQueryPdu()
	{
		Class72.smethod_20();
	}
}
