using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class LiveEntityPdu : PduSuperclass, IEquatable<LiveEntityPdu>
{
	private ushort ushort_1;

	private byte byte_4;

	[XmlElement(Type = typeof(ushort), ElementName = "subprotocolNumber")]
	public ushort SubprotocolNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(LiveEntityPdu left, LiveEntityPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(LiveEntityPdu left, LiveEntityPdu right)
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
		return base.GetMarshalledSize() + 2 + 1;
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
		if (dos != null)
		{
			try
			{
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedByte(byte_4);
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
				ushort_1 = dis.ReadUnsignedShort();
				byte_4 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<LiveEntityPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<subprotocolNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</subprotocolNumber>");
			sb.AppendLine("<padding type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</LiveEntityPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as LiveEntityPdu;
	}

	public bool Equals(LiveEntityPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((PduSuperclass)obj);
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (byte_4 != obj.byte_4)
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
		return smethod_1(smethod_1(smethod_1(0) ^ base.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_4.GetHashCode();
	}

	static LiveEntityPdu()
	{
		Class72.smethod_20();
	}
}
