using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class DistributedEmissionsFamilyPdu : Pdu, IEquatable<DistributedEmissionsFamilyPdu>
{
	public DistributedEmissionsFamilyPdu()
	{
		base.ProtocolFamily = 6;
	}

	public static bool operator !=(DistributedEmissionsFamilyPdu left, DistributedEmissionsFamilyPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(DistributedEmissionsFamilyPdu left, DistributedEmissionsFamilyPdu right)
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
		return base.GetMarshalledSize();
	}

	public virtual void MarshalAutoLengthSet(DataOutputStream dos)
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
		sb.AppendLine("<DistributedEmissionsFamilyPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("</DistributedEmissionsFamilyPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DistributedEmissionsFamilyPdu;
	}

	public bool Equals(DistributedEmissionsFamilyPdu obj)
	{
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((Pdu)obj);
	}

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_2(0) ^ base.GetHashCode();
	}

	static DistributedEmissionsFamilyPdu()
	{
		Class72.smethod_20();
	}
}
