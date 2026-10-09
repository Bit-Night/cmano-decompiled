using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class MinefieldFamilyPdu : Pdu, IEquatable<MinefieldFamilyPdu>
{
	public MinefieldFamilyPdu()
	{
		base.ProtocolFamily = 8;
	}

	public static bool operator !=(MinefieldFamilyPdu left, MinefieldFamilyPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(MinefieldFamilyPdu left, MinefieldFamilyPdu right)
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
		sb.AppendLine("<MinefieldFamilyPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("</MinefieldFamilyPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as MinefieldFamilyPdu;
	}

	public bool Equals(MinefieldFamilyPdu obj)
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

	static MinefieldFamilyPdu()
	{
		Class72.smethod_20();
	}
}
