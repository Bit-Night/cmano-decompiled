#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(ClockTime))]
[XmlRoot]
public class StartResumeReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<StartResumeReliablePdu>
{
	private ClockTime clockTime_0 = new ClockTime();

	private ClockTime clockTime_1 = new ClockTime();

	private byte byte_4;

	private ushort ushort_1;

	private byte byte_5;

	private uint uint_1;

	[XmlElement(Type = typeof(ClockTime), ElementName = "realWorldTime")]
	public ClockTime RealWorldTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(ClockTime), ElementName = "simulationTime")]
	public ClockTime SimulationTime
	{
		get
		{
			return clockTime_1;
		}
		set
		{
			clockTime_1 = value;
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

	public StartResumeReliablePdu()
	{
		base.PduType = 53;
	}

	public static bool operator !=(StartResumeReliablePdu left, StartResumeReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(StartResumeReliablePdu left, StartResumeReliablePdu right)
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
		return base.GetMarshalledSize() + clockTime_0.GetMarshalledSize() + clockTime_1.GetMarshalledSize() + 1 + 2 + 1 + 4;
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
			clockTime_0.Marshal(dos);
			clockTime_1.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedInt(uint_1);
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
			clockTime_0.Unmarshal(dis);
			clockTime_1.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			byte_5 = dis.ReadUnsignedByte();
			uint_1 = dis.ReadUnsignedInt();
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
		sb.AppendLine("<StartResumeReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<realWorldTime>");
			clockTime_0.Reflection(sb);
			sb.AppendLine("</realWorldTime>");
			sb.AppendLine("<simulationTime>");
			clockTime_1.Reflection(sb);
			sb.AppendLine("</simulationTime>");
			sb.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			sb.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("<pad2 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</StartResumeReliablePdu>");
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
		return this == obj as StartResumeReliablePdu;
	}

	public bool Equals(StartResumeReliablePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)obj);
			if (!clockTime_0.Equals(obj.clockTime_0))
			{
				flag = false;
			}
			if (!clockTime_1.Equals(obj.clockTime_1))
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
			if (uint_1 != obj.uint_1)
			{
				flag = false;
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
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ clockTime_0.GetHashCode()) ^ clockTime_1.GetHashCode()) ^ byte_4.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_5.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static StartResumeReliablePdu()
	{
		Class72.smethod_20();
	}
}
