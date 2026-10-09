using System;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

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
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
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
		sb.AppendLine("<SyntheticEnvironmentFamilyPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("</SyntheticEnvironmentFamilyPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SyntheticEnvironmentFamilyPdu;
	}

	public bool Equals(SyntheticEnvironmentFamilyPdu obj)
	{
		if (!(obj.GetType() != GetType()))
		{
			return Equals((Pdu)obj);
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
		return smethod_2(0) ^ base.GetHashCode();
	}

	static SyntheticEnvironmentFamilyPdu()
	{
		Class72.smethod_20();
	}
}
