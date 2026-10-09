#define TRACE
using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
public class SyntheticEnvironmentFamilyPdu : Pdu, IEquatable<SyntheticEnvironmentFamilyPdu>
{
	public SyntheticEnvironmentFamilyPdu()
	{
		base.ProtocolFamily = 9;
	}

	public static bool operator !=(SyntheticEnvironmentFamilyPdu left, SyntheticEnvironmentFamilyPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(SyntheticEnvironmentFamilyPdu left, SyntheticEnvironmentFamilyPdu right)
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
		return base.GetMarshalledSize();
	}

	public new virtual void MarshalAutoLengthSet(DataOutputStream dos)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dos);
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
	}

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<SyntheticEnvironmentFamilyPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("</SyntheticEnvironmentFamilyPdu>");
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
		return this == obj as SyntheticEnvironmentFamilyPdu;
	}

	public bool Equals(SyntheticEnvironmentFamilyPdu obj)
	{
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((Pdu)obj);
	}

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_1(0) ^ base.GetHashCode();
	}

	static SyntheticEnvironmentFamilyPdu()
	{
		Class72.smethod_20();
	}
}
