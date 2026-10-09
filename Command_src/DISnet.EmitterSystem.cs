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
public class EmitterSystem
{
	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "emitterName")]
	public ushort EmitterName
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

	[XmlElement(Type = typeof(byte), ElementName = "function")]
	public byte Function
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

	[XmlElement(Type = typeof(byte), ElementName = "emitterIdNumber")]
	public byte EmitterIdNumber
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

	public static bool operator !=(EmitterSystem left, EmitterSystem right)
	{
		return !(left == right);
	}

	public static bool operator ==(EmitterSystem left, EmitterSystem right)
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

	public virtual int GetMarshalledSize()
	{
		return 4;
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
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
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
				ushort_0 = dis.ReadUnsignedShort();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EmitterSystem>");
		try
		{
			sb.AppendLine("<emitterName type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</emitterName>");
			sb.AppendLine("<function type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</function>");
			sb.AppendLine("<emitterIdNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</emitterIdNumber>");
			sb.AppendLine("</EmitterSystem>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EmitterSystem;
	}

	public bool Equals(EmitterSystem obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (ushort_0 != obj.ushort_0)
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
		return result;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode();
	}

	static EmitterSystem()
	{
		Class72.smethod_20();
	}
}
