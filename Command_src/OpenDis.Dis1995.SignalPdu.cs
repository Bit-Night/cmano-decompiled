#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlRoot]
public class SignalPdu : RadioCommunicationsPdu, IEquatable<SignalPdu>
{
	private ushort ushort_2;

	private ushort ushort_3;

	private uint uint_1;

	private short short_1;

	private short short_2;

	[XmlElement(Type = typeof(ushort), ElementName = "encodingScheme")]
	public ushort EncodingScheme
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

	[XmlElement(Type = typeof(ushort), ElementName = "tdlType")]
	public ushort TdlType
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

	[XmlElement(Type = typeof(uint), ElementName = "sampleRate")]
	public uint SampleRate
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

	[XmlElement(Type = typeof(short), ElementName = "dataLength")]
	public short DataLength
	{
		get
		{
			return short_1;
		}
		set
		{
			short_1 = value;
		}
	}

	[XmlElement(Type = typeof(short), ElementName = "samples")]
	public short Samples
	{
		get
		{
			return short_2;
		}
		set
		{
			short_2 = value;
		}
	}

	public SignalPdu()
	{
		base.PduType = 26;
	}

	public static bool operator !=(SignalPdu left, SignalPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(SignalPdu left, SignalPdu right)
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
		return base.GetMarshalledSize() + 2 + 2 + 4 + 2 + 2;
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
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort(ushort_3);
			dos.WriteUnsignedInt(uint_1);
			dos.WriteShort(short_1);
			dos.WriteShort(short_2);
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
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<SignalPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<encodingScheme type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</encodingScheme>");
			sb.AppendLine("<tdlType type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</tdlType>");
			sb.AppendLine("<sampleRate type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</sampleRate>");
			sb.AppendLine("<dataLength type=\"short\">" + short_1.ToString(CultureInfo.InvariantCulture) + "</dataLength>");
			sb.AppendLine("<samples type=\"short\">" + short_2.ToString(CultureInfo.InvariantCulture) + "</samples>");
			sb.AppendLine("</SignalPdu>");
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
		return this == obj as SignalPdu;
	}

	public bool Equals(SignalPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((RadioCommunicationsPdu)obj);
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (ushort_3 != obj.ushort_3)
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		if (short_1 != obj.short_1)
		{
			flag = false;
		}
		if (short_2 != obj.short_2)
		{
			flag = false;
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ uint_1.GetHashCode()) ^ short_1.GetHashCode()) ^ short_2.GetHashCode();
	}

	static SignalPdu()
	{
		Class72.smethod_20();
	}
}
