using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class Pdu : PduSuperclass, IEquatable<Pdu>
{
	private byte byte_4;

	private byte byte_5;

	[XmlElement(Type = typeof(byte), ElementName = "pduStatus")]
	public byte PduStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(Pdu left, Pdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(Pdu left, Pdu right)
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
		return base.GetMarshalledSize() + 1 + 1;
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
		if (dos != null)
		{
			try
			{
				dos.WriteUnsignedByte(byte_4);
				dos.WriteUnsignedByte(byte_5);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis != null)
		{
			try
			{
				byte_4 = dis.ReadUnsignedByte();
				byte_5 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<Pdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<pduStatus type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</pduStatus>");
			sb.AppendLine("<padding type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</Pdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Pdu;
	}

	public bool Equals(Pdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((PduSuperclass)obj);
		if (byte_4 != obj.byte_4)
		{
			flag = false;
		}
		if (byte_5 != obj.byte_5)
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
		return smethod_1(smethod_1(smethod_1(0) ^ base.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode();
	}

	static Pdu()
	{
		Class72.smethod_20();
	}
}
