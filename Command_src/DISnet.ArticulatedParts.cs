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
public class ArticulatedParts
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private uint uint_0;

	private ulong ulong_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "recordType")]
	public byte RecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "changeIndicator")]
	public byte ChangeIndicator
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

	[XmlElement(Type = typeof(ushort), ElementName = "partAttachedTo")]
	public ushort PartAttachedTo
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

	[XmlElement(Type = typeof(uint), ElementName = "parameterType")]
	public uint ParameterType
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

	[XmlElement(Type = typeof(ulong), ElementName = "parameterValue")]
	public ulong ParameterValue
	{
		get
		{
			return ulong_0;
		}
		set
		{
			ulong_0 = value;
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

	public static bool operator !=(ArticulatedParts left, ArticulatedParts right)
	{
		return !(left == right);
	}

	public static bool operator ==(ArticulatedParts left, ArticulatedParts right)
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

	public virtual int GetMarshalledSize()
	{
		return 16;
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedLong(ulong_0);
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
				ushort_0 = dis.ReadUnsignedShort();
				uint_0 = dis.ReadUnsignedInt();
				ulong_0 = dis.ReadUnsignedLong();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<ArticulatedParts>");
		try
		{
			sb.AppendLine("<recordType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<changeIndicator type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</changeIndicator>");
			sb.AppendLine("<partAttachedTo type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</partAttachedTo>");
			sb.AppendLine("<parameterType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</parameterType>");
			sb.AppendLine("<parameterValue type=\"ulong\">" + ulong_0.ToString(CultureInfo.InvariantCulture) + "</parameterValue>");
			sb.AppendLine("</ArticulatedParts>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ArticulatedParts;
	}

	public bool Equals(ArticulatedParts obj)
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
			if (ushort_0 != obj.ushort_0)
			{
				result = false;
			}
			if (uint_0 != obj.uint_0)
			{
				result = false;
			}
			if (ulong_0 != obj.ulong_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ulong_0.GetHashCode();
	}

	static ArticulatedParts()
	{
		Class72.smethod_20();
	}
}
