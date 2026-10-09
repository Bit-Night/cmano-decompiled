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
public class FundamentalOperationalData
{
	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "systemStatus")]
	public byte SystemStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "dataField1")]
	public byte DataField1
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

	[XmlElement(Type = typeof(byte), ElementName = "informationLayers")]
	public byte InformationLayers
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

	[XmlElement(Type = typeof(byte), ElementName = "dataField2")]
	public byte DataField2
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter1")]
	public ushort Parameter1
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter2")]
	public ushort Parameter2
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter3")]
	public ushort Parameter3
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter4")]
	public ushort Parameter4
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

	[XmlElement(Type = typeof(ushort), ElementName = "parameter5")]
	public ushort Parameter5
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "parameter6")]
	public ushort Parameter6
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
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

	public static bool operator !=(FundamentalOperationalData left, FundamentalOperationalData right)
	{
		return !(left == right);
	}

	public static bool operator ==(FundamentalOperationalData left, FundamentalOperationalData right)
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedByte(byte_3);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
				dos.WriteUnsignedShort(ushort_3);
				dos.WriteUnsignedShort(ushort_4);
				dos.WriteUnsignedShort(ushort_5);
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
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
				ushort_3 = dis.ReadUnsignedShort();
				ushort_4 = dis.ReadUnsignedShort();
				ushort_5 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<FundamentalOperationalData>");
		try
		{
			sb.AppendLine("<systemStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</systemStatus>");
			sb.AppendLine("<dataField1 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</dataField1>");
			sb.AppendLine("<informationLayers type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</informationLayers>");
			sb.AppendLine("<dataField2 type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</dataField2>");
			sb.AppendLine("<parameter1 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</parameter1>");
			sb.AppendLine("<parameter2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</parameter2>");
			sb.AppendLine("<parameter3 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</parameter3>");
			sb.AppendLine("<parameter4 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</parameter4>");
			sb.AppendLine("<parameter5 type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</parameter5>");
			sb.AppendLine("<parameter6 type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</parameter6>");
			sb.AppendLine("</FundamentalOperationalData>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as FundamentalOperationalData;
	}

	public bool Equals(FundamentalOperationalData obj)
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
			if (ushort_4 != obj.ushort_4)
			{
				result = false;
			}
			if (ushort_5 != obj.ushort_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ ushort_4.GetHashCode()) ^ ushort_5.GetHashCode();
	}

	static FundamentalOperationalData()
	{
		Class72.smethod_20();
	}
}
