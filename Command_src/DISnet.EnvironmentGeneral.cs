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
public class EnvironmentGeneral
{
	private uint uint_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "environmentType")]
	public uint EnvironmentType
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

	[XmlElement(Type = typeof(byte), ElementName = "length")]
	public byte Length
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

	[XmlElement(Type = typeof(byte), ElementName = "index")]
	public byte Index
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(byte), ElementName = "geometry")]
	public byte Geometry
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(EnvironmentGeneral left, EnvironmentGeneral right)
	{
		return !(left == right);
	}

	public static bool operator ==(EnvironmentGeneral left, EnvironmentGeneral right)
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
		return 9;
	}

	protected void OnException(Exception e)
	{
		if (action_0 != null)
		{
			action_0(e);
		}
	}

	public virtual void Marshal(DataOutputStream dos)
	{
		if (dos != null)
		{
			try
			{
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedByte(byte_3);
				dos.WriteUnsignedByte(byte_4);
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
				uint_0 = dis.ReadUnsignedInt();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				byte_3 = dis.ReadUnsignedByte();
				byte_4 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EnvironmentGeneral>");
		try
		{
			sb.AppendLine("<environmentType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</environmentType>");
			sb.AppendLine("<length type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</length>");
			sb.AppendLine("<index type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</index>");
			sb.AppendLine("<padding1 type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<geometry type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</geometry>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("</EnvironmentGeneral>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EnvironmentGeneral;
	}

	public bool Equals(EnvironmentGeneral obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (uint_0 != obj.uint_0)
		{
			result = false;
		}
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
		if (byte_4 != obj.byte_4)
		{
			result = false;
		}
		return result;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode();
	}

	static EnvironmentGeneral()
	{
		Class72.smethod_20();
	}
}
