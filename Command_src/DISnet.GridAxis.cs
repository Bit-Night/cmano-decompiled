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
public class GridAxis
{
	private double double_0;

	private double double_1;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	private ushort ushort_1;

	private ushort ushort_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(double), ElementName = "domainInitialXi")]
	public double DomainInitialXi
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

	[XmlElement(Type = typeof(double), ElementName = "domainFinalXi")]
	public double DomainFinalXi
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

	[XmlElement(Type = typeof(ushort), ElementName = "domainPointsXi")]
	public ushort DomainPointsXi
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

	[XmlElement(Type = typeof(byte), ElementName = "interleafFactor")]
	public byte InterleafFactor
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

	[XmlElement(Type = typeof(byte), ElementName = "axisType")]
	public byte AxisType
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfPointsOnXiAxis")]
	public ushort NumberOfPointsOnXiAxis
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

	[XmlElement(Type = typeof(ushort), ElementName = "initialIndex")]
	public ushort InitialIndex
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

	public static bool operator !=(GridAxis left, GridAxis right)
	{
		return !(left == right);
	}

	public static bool operator ==(GridAxis left, GridAxis right)
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
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
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
				ushort_0 = dis.ReadUnsignedShort();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<GridAxis>");
		try
		{
			sb.AppendLine("<domainInitialXi type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</domainInitialXi>");
			sb.AppendLine("<domainFinalXi type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</domainFinalXi>");
			sb.AppendLine("<domainPointsXi type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</domainPointsXi>");
			sb.AppendLine("<interleafFactor type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</interleafFactor>");
			sb.AppendLine("<axisType type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</axisType>");
			sb.AppendLine("<numberOfPointsOnXiAxis type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</numberOfPointsOnXiAxis>");
			sb.AppendLine("<initialIndex type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</initialIndex>");
			sb.AppendLine("</GridAxis>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as GridAxis;
	}

	public bool Equals(GridAxis obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (double_0 != obj.double_0)
		{
			result = false;
		}
		if (double_1 != obj.double_1)
		{
			result = false;
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
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (ushort_2 != obj.ushort_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ double_0.GetHashCode()) ^ double_1.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode();
	}

	static GridAxis()
	{
		Class72.smethod_20();
	}
}
