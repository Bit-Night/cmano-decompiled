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
public class ModulationType
{
	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "spreadSpectrum")]
	public ushort SpreadSpectrum
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

	[XmlElement(Type = typeof(ushort), ElementName = "majorModulation")]
	public ushort MajorModulation
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

	[XmlElement(Type = typeof(ushort), ElementName = "detail")]
	public ushort Detail
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

	[XmlElement(Type = typeof(ushort), ElementName = "radioSystem")]
	public ushort RadioSystem
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
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

	public static bool operator !=(ModulationType left, ModulationType right)
	{
		return !(left == right);
	}

	public static bool operator ==(ModulationType left, ModulationType right)
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
		return 8;
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
				dos.WriteUnsignedShort(ushort_3);
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
				ushort_3 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<ModulationType>");
		try
		{
			sb.AppendLine("<spreadSpectrum type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</spreadSpectrum>");
			sb.AppendLine("<majorModulation type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</majorModulation>");
			sb.AppendLine("<detail type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</detail>");
			sb.AppendLine("<radioSystem type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</radioSystem>");
			sb.AppendLine("</ModulationType>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ModulationType;
	}

	public bool Equals(ModulationType obj)
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
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			result = false;
		}
		if (ushort_3 != obj.ushort_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode();
	}

	static ModulationType()
	{
		Class72.smethod_20();
	}
}
