using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class PduSuperclass
{
	private byte byte_0 = 7;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private uint uint_0;

	private ushort ushort_0;

	[CompilerGenerated]
	private Action<Exception> lwoYgGqywZp;

	[XmlElement(Type = typeof(byte), ElementName = "protocolVersion")]
	public byte ProtocolVersion
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

	[XmlElement(Type = typeof(byte), ElementName = "exerciseID")]
	public byte ExerciseID
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pduType")]
	public byte PduType
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "protocolFamily")]
	public byte ProtocolFamily
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "timestamp")]
	public uint Timestamp
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "length")]
	public ushort Length
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = lwoYgGqywZp;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref lwoYgGqywZp, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = lwoYgGqywZp;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref lwoYgGqywZp, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(PduSuperclass left, PduSuperclass right)
	{
		return !(left == right);
	}

	public static bool operator ==(PduSuperclass left, PduSuperclass right)
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

	public virtual int GetMarshalledSize()
	{
		return 10;
	}

	protected void OnException(Exception e)
	{
		if (lwoYgGqywZp != null)
		{
			lwoYgGqywZp(e);
		}
	}

	public virtual void Marshal(DataOutputStream dos)
	{
		if (dos != null)
		{
			try
			{
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedByte(byte_3);
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedShort(ushort_0);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dis)
	{
		if (dis != null)
		{
			try
			{
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				byte_3 = dis.ReadUnsignedByte();
				uint_0 = dis.ReadUnsignedInt();
				ushort_0 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<PduSuperclass>");
		try
		{
			sb.AppendLine("<protocolVersion type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</protocolVersion>");
			sb.AppendLine("<exerciseID type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</exerciseID>");
			sb.AppendLine("<pduType type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</pduType>");
			sb.AppendLine("<protocolFamily type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</protocolFamily>");
			sb.AppendLine("<timestamp type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</timestamp>");
			sb.AppendLine("<length type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</length>");
			sb.AppendLine("</PduSuperclass>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as PduSuperclass;
	}

	public bool Equals(PduSuperclass obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (byte_0 != obj.byte_0)
			{
				result = false;
			}
			if (byte_1 != obj.byte_1)
			{
				result = false;
			}
			if (byte_2 != obj.byte_2)
			{
				result = false;
			}
			if (byte_3 != obj.byte_3)
			{
				result = false;
			}
			if (uint_0 != obj.uint_0)
			{
				result = false;
			}
			if (ushort_0 != obj.ushort_0)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}

	static PduSuperclass()
	{
		Class72.smethod_20();
	}
}
