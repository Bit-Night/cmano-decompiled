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
public class IntercomCommunicationsParameters
{
	private ushort ushort_0;

	private ushort ushort_1;

	private uint uint_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(ushort), ElementName = "recordType")]
	public ushort RecordType
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

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
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

	[XmlElement(Type = typeof(uint), ElementName = "recordSpecificField")]
	public uint RecordSpecificField
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

	public static bool operator !=(IntercomCommunicationsParameters left, IntercomCommunicationsParameters right)
	{
		return !(left == right);
	}

	public static bool operator ==(IntercomCommunicationsParameters left, IntercomCommunicationsParameters right)
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
		return 8;
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
			dos.WriteUnsignedInt(uint_0);
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
			uint_0 = dis.ReadUnsignedInt();
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
		sb.AppendLine("<IntercomCommunicationsParameters>");
		try
		{
			sb.AppendLine("<recordType type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<recordSpecificField type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordSpecificField>");
			sb.AppendLine("</IntercomCommunicationsParameters>");
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
		return this == obj as IntercomCommunicationsParameters;
	}

	public bool Equals(IntercomCommunicationsParameters obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (ushort_0 != obj.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != obj.ushort_1)
			{
				result = false;
			}
			if (uint_0 != obj.uint_0)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int GxyYrzpvoPR(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return GxyYrzpvoPR(GxyYrzpvoPR(GxyYrzpvoPR(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ uint_0.GetHashCode();
	}

	static IntercomCommunicationsParameters()
	{
		Class72.smethod_20();
	}
}
