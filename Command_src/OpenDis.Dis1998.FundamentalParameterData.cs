#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlRoot]
public class FundamentalParameterData
{
	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private float float_8;

	private float float_9;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

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

	[XmlElement(Type = typeof(float), ElementName = "beamAzimuthCenter")]
	public float BeamAzimuthCenter
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamAzimuthSweep")]
	public float BeamAzimuthSweep
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamElevationCenter")]
	public float BeamElevationCenter
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamElevationSweep")]
	public float BeamElevationSweep
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "beamSweepSync")]
	public float BeamSweepSync
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	public event EventHandler<PduExceptionEventArgs> ExceptionOccured
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PduExceptionEventArgs> eventHandler = eventHandler_0;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static bool operator !=(FundamentalParameterData left, FundamentalParameterData right)
	{
		return !(left == right);
	}

	public static bool operator ==(FundamentalParameterData left, FundamentalParameterData right)
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
		return 40;
	}

	protected void RaiseExceptionOccured(Exception e)
	{
		if (PduBase.FireExceptionEvents && eventHandler_0 != null)
		{
			eventHandler_0(this, new PduExceptionEventArgs(e));
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
			dos.WriteFloat(float_4);
			dos.WriteFloat(float_5);
			dos.WriteFloat(float_6);
			dos.WriteFloat(float_7);
			dos.WriteFloat(float_8);
			dos.WriteFloat(float_9);
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
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
			float_4 = dis.ReadFloat();
			float_5 = dis.ReadFloat();
			float_6 = dis.ReadFloat();
			float_7 = dis.ReadFloat();
			float_8 = dis.ReadFloat();
			float_9 = dis.ReadFloat();
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<FundamentalParameterData>");
		try
		{
			sb.AppendLine("<frequency type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			sb.AppendLine("<frequencyRange type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</frequencyRange>");
			sb.AppendLine("<effectiveRadiatedPower type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</effectiveRadiatedPower>");
			sb.AppendLine("<pulseRepetitionFrequency type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
			sb.AppendLine("<pulseWidth type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			sb.AppendLine("<beamAzimuthCenter type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthCenter>");
			sb.AppendLine("<beamAzimuthSweep type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</beamAzimuthSweep>");
			sb.AppendLine("<beamElevationCenter type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</beamElevationCenter>");
			sb.AppendLine("<beamElevationSweep type=\"float\">" + float_8.ToString(CultureInfo.InvariantCulture) + "</beamElevationSweep>");
			sb.AppendLine("<beamSweepSync type=\"float\">" + float_9.ToString(CultureInfo.InvariantCulture) + "</beamSweepSync>");
			sb.AppendLine("</FundamentalParameterData>");
		}
		catch (Exception ex)
		{
			if (PduBase.TraceExceptions)
			{
				Trace.WriteLine(ex);
				Trace.Flush();
			}
			RaiseExceptionOccured(ex);
			if (PduBase.ThrowExceptions)
			{
				throw ex;
			}
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as FundamentalParameterData;
	}

	public bool Equals(FundamentalParameterData obj)
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
			if (float_5 != obj.float_5)
			{
				result = false;
			}
			if (float_6 != obj.float_6)
			{
				result = false;
			}
			if (float_7 != obj.float_7)
			{
				result = false;
			}
			if (float_8 != obj.float_8)
			{
				result = false;
			}
			if (float_9 != obj.float_9)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ float_6.GetHashCode()) ^ float_7.GetHashCode()) ^ float_8.GetHashCode()) ^ float_9.GetHashCode();
	}

	static FundamentalParameterData()
	{
		Class72.smethod_20();
	}
}
