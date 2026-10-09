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
public class AcousticBeamFundamentalParameter
{
	private ushort ushort_0;

	private ushort ushort_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(ushort), ElementName = "activeEmissionParameterIndex")]
	public ushort ActiveEmissionParameterIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "scanPattern")]
	public ushort ScanPattern
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

	[XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuth")]
	public float BeamCenterAzimuth
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidth")]
	public float AzimuthalBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "beamCenterDE")]
	public float BeamCenterDE
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

	[XmlElement(Type = typeof(float), ElementName = "deBeamwidth")]
	public float DeBeamwidth
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

	public static bool operator !=(AcousticBeamFundamentalParameter left, AcousticBeamFundamentalParameter right)
	{
		return !(left == right);
	}

	public static bool operator ==(AcousticBeamFundamentalParameter left, AcousticBeamFundamentalParameter right)
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
			dos.WriteUnsignedShort(ushort_0);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteFloat(float_0);
			dos.WriteFloat(float_1);
			dos.WriteFloat(float_2);
			dos.WriteFloat(float_3);
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
			ushort_0 = dis.ReadUnsignedShort();
			ushort_1 = dis.ReadUnsignedShort();
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			float_2 = dis.ReadFloat();
			float_3 = dis.ReadFloat();
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
		sb.AppendLine("<AcousticBeamFundamentalParameter>");
		try
		{
			sb.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
			sb.AppendLine("<scanPattern type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
			sb.AppendLine("<beamCenterAzimuth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuth>");
			sb.AppendLine("<azimuthalBeamwidth type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidth>");
			sb.AppendLine("<beamCenterDE type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</beamCenterDE>");
			sb.AppendLine("<deBeamwidth type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</deBeamwidth>");
			sb.AppendLine("</AcousticBeamFundamentalParameter>");
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
		return this == obj as AcousticBeamFundamentalParameter;
	}

	public bool Equals(AcousticBeamFundamentalParameter obj)
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
		return result;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode();
	}

	static AcousticBeamFundamentalParameter()
	{
		Class72.smethod_20();
	}
}
