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
[XmlInclude(typeof(AcousticBeamFundamentalParameter))]
[XmlRoot]
public class AcousticBeamData
{
	private ushort ushort_0;

	private byte byte_0;

	private ushort ushort_1;

	private AcousticBeamFundamentalParameter acousticBeamFundamentalParameter_0 = new AcousticBeamFundamentalParameter();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(ushort), ElementName = "beamDataLength")]
	public ushort BeamDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
	public byte BeamIDNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad2")]
	public ushort Pad2
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

	[XmlElement(Type = typeof(AcousticBeamFundamentalParameter), ElementName = "fundamentalDataParameters")]
	public AcousticBeamFundamentalParameter FundamentalDataParameters
	{
		get
		{
			return acousticBeamFundamentalParameter_0;
		}
		set
		{
			acousticBeamFundamentalParameter_0 = value;
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

	public static bool operator !=(AcousticBeamData left, AcousticBeamData right)
	{
		return !(left == right);
	}

	public static bool operator ==(AcousticBeamData left, AcousticBeamData right)
	{
		if ((object)left == right)
		{
			return true;
		}
		if ((object)left != null && (object)right != null)
		{
			return left.Equals(right);
		}
		return false;
	}

	public virtual int GetMarshalledSize()
	{
		return 5 + acousticBeamFundamentalParameter_0.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_0);
			dos.WriteUnsignedShort(ushort_1);
			acousticBeamFundamentalParameter_0.Marshal(dos);
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
		if (dis != null)
		{
			ushort_0 = dis.ReadUnsignedShort();
			byte_0 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			acousticBeamFundamentalParameter_0.Unmarshal(dis);
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<AcousticBeamData>");
		try
		{
			sb.AppendLine("<beamDataLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
			sb.AppendLine("<beamIDNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
			sb.AppendLine("<pad2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<fundamentalDataParameters>");
			acousticBeamFundamentalParameter_0.Reflection(sb);
			sb.AppendLine("</fundamentalDataParameters>");
			sb.AppendLine("</AcousticBeamData>");
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
		return this == obj as AcousticBeamData;
	}

	public bool Equals(AcousticBeamData obj)
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
		if (byte_0 != obj.byte_0)
		{
			result = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (!acousticBeamFundamentalParameter_0.Equals(obj.acousticBeamFundamentalParameter_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ acousticBeamFundamentalParameter_0.GetHashCode();
	}

	static AcousticBeamData()
	{
		Class72.smethod_20();
	}
}
