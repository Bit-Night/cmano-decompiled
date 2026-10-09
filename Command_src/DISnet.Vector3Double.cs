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
public class Vector3Double
{
	private double double_0;

	private double double_1;

	private double double_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(double), ElementName = "x")]
	public double X
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "y")]
	public double Y
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "z")]
	public double Z
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
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

	public static bool operator !=(Vector3Double left, Vector3Double right)
	{
		return !(left == right);
	}

	public static bool operator ==(Vector3Double left, Vector3Double right)
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
		return 24;
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
				dos.WriteDouble(double_0);
				dos.WriteDouble(double_1);
				dos.WriteDouble(double_2);
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
				double_0 = dis.ReadDouble();
				double_1 = dis.ReadDouble();
				double_2 = dis.ReadDouble();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<Vector3Double>");
		try
		{
			sb.AppendLine("<x type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</x>");
			sb.AppendLine("<y type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</y>");
			sb.AppendLine("<z type=\"double\">" + double_2.ToString(CultureInfo.InvariantCulture) + "</z>");
			sb.AppendLine("</Vector3Double>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Vector3Double;
	}

	public bool Equals(Vector3Double obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (double_0 != obj.double_0)
			{
				result = false;
			}
			if (double_1 != obj.double_1)
			{
				result = false;
			}
			if (double_2 != obj.double_2)
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
		return smethod_0(smethod_0(smethod_0(0) ^ double_0.GetHashCode()) ^ double_1.GetHashCode()) ^ double_2.GetHashCode();
	}

	static Vector3Double()
	{
		Class72.smethod_20();
	}
}
