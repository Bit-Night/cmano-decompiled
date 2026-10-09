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
[XmlInclude(typeof(TwoByteChunk))]
[XmlRoot]
public class GridAxisRecordRepresentation1 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation1>
{
	private float float_0;

	private float float_1;

	private ushort ushort_2;

	private List<TwoByteChunk> list_0 = new List<TwoByteChunk>();

	[XmlElement(Type = typeof(float), ElementName = "fieldScale")]
	public float FieldScale
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "fieldOffset")]
	public float FieldOffset
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfValues")]
	public ushort NumberOfValues
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

	[XmlElement(ElementName = "dataValuesList", Type = typeof(List<TwoByteChunk>))]
	public List<TwoByteChunk> DataValues => list_0;

	public static bool operator !=(GridAxisRecordRepresentation1 left, GridAxisRecordRepresentation1 right)
	{
		return !(left == right);
	}

	public static bool operator ==(GridAxisRecordRepresentation1 left, GridAxisRecordRepresentation1 right)
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
		num += 4;
		num += 4;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			TwoByteChunk twoByteChunk = list_0[i];
			num += twoByteChunk.GetMarshalledSize();
		}
		return num;
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
			dos.WriteFloat(float_0);
			dos.WriteFloat(float_1);
			dos.WriteUnsignedShort((ushort)list_0.Count);
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
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			ushort_2 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfValues; i++)
			{
				TwoByteChunk twoByteChunk = new TwoByteChunk();
				twoByteChunk.Unmarshal(dis);
				list_0.Add(twoByteChunk);
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
		sb.AppendLine("<GridAxisRecordRepresentation1>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<fieldScale type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</fieldScale>");
			sb.AppendLine("<fieldOffset type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</fieldOffset>");
			sb.AppendLine("<dataValues type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<dataValues" + i.ToString(CultureInfo.InvariantCulture) + " type=\"TwoByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</dataValues" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</GridAxisRecordRepresentation1>");
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
		return this == obj as GridAxisRecordRepresentation1;
	}

	public bool Equals(GridAxisRecordRepresentation1 obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((GridAxisRecord)obj);
		if (float_0 != obj.float_0)
		{
			flag = false;
		}
		if (float_1 != obj.float_1)
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
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

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_1(0) ^ base.GetHashCode();
		num = smethod_1(num) ^ float_0.GetHashCode();
		num = smethod_1(num) ^ float_1.GetHashCode();
		num = smethod_1(num) ^ ushort_2.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_1(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static GridAxisRecordRepresentation1()
	{
		Class72.smethod_20();
	}
}
