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
public class IffFundamentalData
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
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

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

	[XmlElement(Type = typeof(byte), ElementName = "alternateParameter4")]
	public byte AlternateParameter4
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

	[XmlElement(Type = typeof(byte), ElementName = "modifier")]
	public byte Modifier
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

	public static bool operator !=(IffFundamentalData left, IffFundamentalData right)
	{
		return !(left == right);
	}

	public static bool operator ==(IffFundamentalData left, IffFundamentalData right)
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
		sb.AppendLine("<IffFundamentalData>");
		try
		{
			sb.AppendLine("<systemStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</systemStatus>");
			sb.AppendLine("<alternateParameter4 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</alternateParameter4>");
			sb.AppendLine("<informationLayers type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</informationLayers>");
			sb.AppendLine("<modifier type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</modifier>");
			sb.AppendLine("<parameter1 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</parameter1>");
			sb.AppendLine("<parameter2 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</parameter2>");
			sb.AppendLine("<parameter3 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</parameter3>");
			sb.AppendLine("<parameter4 type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</parameter4>");
			sb.AppendLine("<parameter5 type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</parameter5>");
			sb.AppendLine("<parameter6 type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</parameter6>");
			sb.AppendLine("</IffFundamentalData>");
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
		return this == obj as IffFundamentalData;
	}

	public bool Equals(IffFundamentalData obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
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

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ ushort_4.GetHashCode()) ^ ushort_5.GetHashCode();
	}

	static IffFundamentalData()
	{
		Class72.smethod_20();
	}
}
