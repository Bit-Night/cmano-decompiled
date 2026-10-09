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
[XmlInclude(typeof(FourByteChunk))]
public class GridAxisRecordRepresentation2 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation2>
{
	private ushort ushort_2;

	private List<FourByteChunk> list_0 = new List<FourByteChunk>();

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

	[XmlElement(ElementName = "dataValuesList", Type = typeof(List<FourByteChunk>))]
	public List<FourByteChunk> DataValues => list_0;

	public static bool operator !=(GridAxisRecordRepresentation2 left, GridAxisRecordRepresentation2 right)
	{
		return !(left == right);
	}

	public static bool operator ==(GridAxisRecordRepresentation2 left, GridAxisRecordRepresentation2 right)
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
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			FourByteChunk fourByteChunk = list_0[i];
			num += fourByteChunk.GetMarshalledSize();
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
			ushort_2 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfValues; i++)
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
		sb.AppendLine("<GridAxisRecordRepresentation2>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<dataValues type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<dataValues" + i.ToString(CultureInfo.InvariantCulture) + " type=\"FourByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</dataValues" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</GridAxisRecordRepresentation2>");
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
		return this == obj as GridAxisRecordRepresentation2;
	}

	public bool Equals(GridAxisRecordRepresentation2 obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((GridAxisRecord)obj);
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
		return false;
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

	static GridAxisRecordRepresentation2()
	{
		Class72.smethod_20();
	}
}
