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
public class EEFundamentalParameterData
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(float), ElementName = "frequency")]
	public float Frequency
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

	[XmlElement(Type = typeof(float), ElementName = "frequencyRange")]
	public float FrequencyRange
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

	[XmlElement(Type = typeof(float), ElementName = "effectiveRadiatedPower")]
	public float EffectiveRadiatedPower
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

	[XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
	public float PulseRepetitionFrequency
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

	[XmlElement(Type = typeof(float), ElementName = "pulseWidth")]
	public float PulseWidth
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
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

	public static bool operator !=(EEFundamentalParameterData left, EEFundamentalParameterData right)
	{
		return !(left == right);
	}

	public static bool operator ==(EEFundamentalParameterData left, EEFundamentalParameterData right)
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
		return 20;
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
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				dos.WriteFloat(float_2);
				dos.WriteFloat(float_3);
				dos.WriteFloat(float_4);
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
				float_0 = dis.ReadFloat();
				float_1 = dis.ReadFloat();
				float_2 = dis.ReadFloat();
				float_3 = dis.ReadFloat();
				float_4 = dis.ReadFloat();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EEFundamentalParameterData>");
		try
		{
			sb.AppendLine("<frequency type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			sb.AppendLine("<frequencyRange type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</frequencyRange>");
			sb.AppendLine("<effectiveRadiatedPower type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</effectiveRadiatedPower>");
			sb.AppendLine("<pulseRepetitionFrequency type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
			sb.AppendLine("<pulseWidth type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			sb.AppendLine("</EEFundamentalParameterData>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EEFundamentalParameterData;
	}

	public bool Equals(EEFundamentalParameterData obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (float_0 != obj.float_0)
			{
				result = false;
			}
			if (float_1 != obj.float_1)
			{
				result = false;
			}
			if (float_2 != obj.float_2)
			{
				result = false;
			}
			if (float_3 != obj.float_3)
			{
				result = false;
			}
			if (float_4 != obj.float_4)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode();
	}

	static EEFundamentalParameterData()
	{
		Class72.smethod_20();
	}
}
