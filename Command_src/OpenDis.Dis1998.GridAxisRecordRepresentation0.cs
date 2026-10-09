#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(OneByteChunk))]
public class GridAxisRecordRepresentation0 : GridAxisRecord, IEquatable<GridAxisRecordRepresentation0>
{
	private ushort ushort_2;

	private byte[] byte_0;

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfBytes")]
	public ushort NumberOfBytes
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

	[XmlElement(ElementName = "dataValuesList", DataType = "hexBinary")]
	public byte[] DataValues
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public static bool operator !=(GridAxisRecordRepresentation0 left, GridAxisRecordRepresentation0 right)
	{
		return !(left == right);
	}

	public static bool operator ==(GridAxisRecordRepresentation0 left, GridAxisRecordRepresentation0 right)
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
		return base.GetMarshalledSize() + 2 + byte_0.Length;
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
			dos.WriteUnsignedShort((ushort)byte_0.Length);
			dos.WriteByte(byte_0);
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
			byte_0 = dis.ReadByteArray(ushort_2);
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
		sb.AppendLine("<GridAxisRecordRepresentation0>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<dataValues type=\"ushort\">" + byte_0.Length.ToString(CultureInfo.InvariantCulture) + "</dataValues>");
			sb.AppendLine("<dataValues type=\"byte[]\">");
			byte[] array = byte_0;
			foreach (byte b in array)
			{
				sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
			}
			sb.AppendLine("</dataValues>");
			sb.AppendLine("</GridAxisRecordRepresentation0>");
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
		return this == obj as GridAxisRecordRepresentation0;
	}

	public bool Equals(GridAxisRecordRepresentation0 obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((GridAxisRecord)obj);
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (!byte_0.Equals(obj.byte_0))
		{
			flag = false;
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
		num = smethod_1(num) ^ ushort_2.GetHashCode();
		if (byte_0.Length != 0)
		{
			for (int i = 0; i < byte_0.Length; i++)
			{
				num = smethod_1(num) ^ byte_0[i].GetHashCode();
			}
		}
		return num;
	}

	static GridAxisRecordRepresentation0()
	{
		Class72.smethod_20();
	}
}
