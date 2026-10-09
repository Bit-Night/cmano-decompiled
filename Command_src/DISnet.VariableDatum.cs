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
public class VariableDatum
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumID")]
	public uint VariableDatumID
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

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumLength")]
	public uint VariableDatumLength
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "variableDatumBits")]
	public uint VariableDatumBits
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "padding")]
	public uint Padding
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
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

	public static bool operator !=(VariableDatum left, VariableDatum right)
	{
		return !(left == right);
	}

	public static bool operator ==(VariableDatum left, VariableDatum right)
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
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedInt(uint_1);
				dos.WriteUnsignedInt(uint_2);
				dos.WriteUnsignedInt(uint_3);
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
				uint_1 = dis.ReadUnsignedInt();
				uint_2 = dis.ReadUnsignedInt();
				uint_3 = dis.ReadUnsignedInt();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<VariableDatum>");
		try
		{
			sb.AppendLine("<variableDatumID type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</variableDatumID>");
			sb.AppendLine("<variableDatumLength type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</variableDatumLength>");
			sb.AppendLine("<variableDatumBits type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</variableDatumBits>");
			sb.AppendLine("<padding type=\"uint\">" + uint_3.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</VariableDatum>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as VariableDatum;
	}

	public bool Equals(VariableDatum obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (uint_0 != obj.uint_0)
			{
				result = false;
			}
			if (uint_1 != obj.uint_1)
			{
				result = false;
			}
			if (uint_2 != obj.uint_2)
			{
				result = false;
			}
			if (uint_3 != obj.uint_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ uint_2.GetHashCode()) ^ uint_3.GetHashCode();
	}

	static VariableDatum()
	{
		Class72.smethod_20();
	}
}
