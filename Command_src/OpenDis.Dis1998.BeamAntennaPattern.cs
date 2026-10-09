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
[XmlInclude(typeof(Orientation))]
public class BeamAntennaPattern
{
	private Orientation orientation_0 = new Orientation();

	private float float_0;

	private float float_1;

	private short short_0;

	private byte byte_0;

	private float float_2;

	private float float_3;

	private float float_4;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(Orientation), ElementName = "beamDirection")]
	public Orientation BeamDirection
	{
		get
		{
			return orientation_0;
		}
		set
		{
			orientation_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "azimuthBeamwidth")]
	public float AzimuthBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "referenceSystem")]
	public float ReferenceSystem
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

	[XmlElement(Type = typeof(short), ElementName = "padding1")]
	public short Padding1
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	[XmlElement(Type = typeof(float), ElementName = "ez")]
	public float Ez
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

	[XmlElement(Type = typeof(float), ElementName = "ex")]
	public float Ex
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

	[XmlElement(Type = typeof(float), ElementName = "phase")]
	public float Phase
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

	public static bool operator !=(BeamAntennaPattern left, BeamAntennaPattern right)
	{
		return !(left == right);
	}

	public static bool operator ==(BeamAntennaPattern left, BeamAntennaPattern right)
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
		return 0 + orientation_0.GetMarshalledSize() + 4 + 4 + 2 + 1 + 4 + 4 + 4;
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
			orientation_0.Marshal(dos);
			dos.WriteFloat(float_0);
			dos.WriteFloat(float_1);
			dos.WriteShort(short_0);
			dos.WriteByte(byte_0);
			dos.WriteFloat(float_2);
			dos.WriteFloat(float_3);
			dos.WriteFloat(float_4);
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
			orientation_0.Unmarshal(dis);
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			short_0 = dis.ReadShort();
			byte_0 = dis.ReadByte();
			float_2 = dis.ReadFloat();
			float_3 = dis.ReadFloat();
			float_4 = dis.ReadFloat();
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
		sb.AppendLine("<BeamAntennaPattern>");
		try
		{
			sb.AppendLine("<beamDirection>");
			orientation_0.Reflection(sb);
			sb.AppendLine("</beamDirection>");
			sb.AppendLine("<azimuthBeamwidth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</azimuthBeamwidth>");
			sb.AppendLine("<referenceSystem type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</referenceSystem>");
			sb.AppendLine("<padding1 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<ez type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</ez>");
			sb.AppendLine("<ex type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</ex>");
			sb.AppendLine("<phase type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</phase>");
			sb.AppendLine("</BeamAntennaPattern>");
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
		return this == obj as BeamAntennaPattern;
	}

	public bool Equals(BeamAntennaPattern obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (!orientation_0.Equals(obj.orientation_0))
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
		if (short_0 != obj.short_0)
		{
			result = false;
		}
		if (byte_0 != obj.byte_0)
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

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ orientation_0.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ short_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode();
	}

	static BeamAntennaPattern()
	{
		Class72.smethod_20();
	}
}
