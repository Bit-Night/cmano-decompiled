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
public class IFFFundamentalParameterData
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private uint uint_0;

	private byte byte_0;

	private byte[] byte_1 = new byte[3];

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(float), ElementName = "erp")]
	public float Erp
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "frequency")]
	public float Frequency
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pgrf")]
	public float Pgrf
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
	public float PulseWidth
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "burstLength")]
	public uint BurstLength
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

	[XmlElement(Type = typeof(byte), ElementName = "applicableModes")]
	public byte ApplicableModes
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

	[XmlArray(ElementName = "systemSpecificData")]
	public byte[] SystemSpecificData
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

	public static bool operator !=(IFFFundamentalParameterData left, IFFFundamentalParameterData right)
	{
		return !(left == right);
	}

	public static bool operator ==(IFFFundamentalParameterData left, IFFFundamentalParameterData right)
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
		if (dos == null)
		{
			return;
		}
		try
		{
			dos.WriteFloat(float_0);
			dos.WriteFloat(float_1);
			dos.WriteFloat(float_2);
			dos.WriteFloat(float_3);
			dos.WriteUnsignedInt(uint_0);
			dos.WriteUnsignedByte(byte_0);
			for (int i = 0; i < byte_1.Length; i++)
			{
				dos.WriteUnsignedByte(byte_1[i]);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Unmarshal(DataInputStream dis)
	{
		if (dis == null)
		{
			return;
		}
		try
		{
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			float_2 = dis.ReadFloat();
			float_3 = dis.ReadFloat();
			uint_0 = dis.ReadUnsignedInt();
			byte_0 = dis.ReadUnsignedByte();
			for (int i = 0; i < byte_1.Length; i++)
			{
				byte_1[i] = dis.ReadUnsignedByte();
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<IFFFundamentalParameterData>");
		try
		{
			sb.AppendLine("<erp type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</erp>");
			sb.AppendLine("<frequency type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			sb.AppendLine("<pgrf type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</pgrf>");
			sb.AppendLine("<pulseWidth type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			sb.AppendLine("<burstLength type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</burstLength>");
			sb.AppendLine("<applicableModes type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</applicableModes>");
			for (int i = 0; i < byte_1.Length; i++)
			{
				sb.AppendLine("<systemSpecificData" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_1[i] + "</systemSpecificData" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</IFFFundamentalParameterData>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IFFFundamentalParameterData;
	}

	public bool Equals(IFFFundamentalParameterData obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			if (float_0 != obj.float_0)
			{
				flag = false;
			}
			if (float_1 != obj.float_1)
			{
				flag = false;
			}
			if (float_2 != obj.float_2)
			{
				flag = false;
			}
			if (float_3 != obj.float_3)
			{
				flag = false;
			}
			if (uint_0 != obj.uint_0)
			{
				flag = false;
			}
			if (byte_0 != obj.byte_0)
			{
				flag = false;
			}
			if (obj.byte_1.Length != 3)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 3; i++)
				{
					if (byte_1[i] != obj.byte_1[i])
					{
						flag = false;
					}
				}
			}
			return flag;
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
		int num = 0;
		num = smethod_0(0) ^ float_0.GetHashCode();
		num = smethod_0(num) ^ float_1.GetHashCode();
		num = smethod_0(num) ^ float_2.GetHashCode();
		num = smethod_0(num) ^ float_3.GetHashCode();
		num = smethod_0(num) ^ uint_0.GetHashCode();
		num = smethod_0(num) ^ byte_0.GetHashCode();
		for (int i = 0; i < 3; i++)
		{
			num = smethod_0(num) ^ byte_1[i].GetHashCode();
		}
		return num;
	}

	static IFFFundamentalParameterData()
	{
		Class72.smethod_20();
	}
}
