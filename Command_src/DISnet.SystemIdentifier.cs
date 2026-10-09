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
[XmlInclude(typeof(ChangeOptions))]
public class SystemIdentifier
{
	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ChangeOptions changeOptions_0 = new ChangeOptions();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "systemType")]
	public ushort SystemType
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

	[XmlElement(Type = typeof(ushort), ElementName = "systemName")]
	public ushort SystemName
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

	[XmlElement(Type = typeof(ushort), ElementName = "systemMode")]
	public ushort SystemMode
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
		}
	}

	[XmlElement(Type = typeof(ChangeOptions), ElementName = "changeOptions")]
	public ChangeOptions ChangeOptions
	{
		get
		{
			return changeOptions_0;
		}
		set
		{
			changeOptions_0 = value;
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

	public static bool operator !=(SystemIdentifier left, SystemIdentifier right)
	{
		return !(left == right);
	}

	public static bool operator ==(SystemIdentifier left, SystemIdentifier right)
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
		return 6 + changeOptions_0.GetMarshalledSize();
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
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
				changeOptions_0.Marshal(dos);
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
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
				changeOptions_0.Unmarshal(dis);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<SystemIdentifier>");
		try
		{
			sb.AppendLine("<systemType type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</systemType>");
			sb.AppendLine("<systemName type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</systemName>");
			sb.AppendLine("<systemMode type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</systemMode>");
			sb.AppendLine("<changeOptions>");
			changeOptions_0.Reflection(sb);
			sb.AppendLine("</changeOptions>");
			sb.AppendLine("</SystemIdentifier>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SystemIdentifier;
	}

	public bool Equals(SystemIdentifier obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (ushort_0 != obj.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != obj.ushort_1)
			{
				result = false;
			}
			if (ushort_2 != obj.ushort_2)
			{
				result = false;
			}
			if (!changeOptions_0.Equals(obj.changeOptions_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ changeOptions_0.GetHashCode();
	}

	static SystemIdentifier()
	{
		Class72.smethod_20();
	}
}
