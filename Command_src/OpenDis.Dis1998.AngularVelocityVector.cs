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
public class AngularVelocityVector
{
	private float float_0;

	private float float_1;

	private float float_2;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(float), ElementName = "x")]
	public float X
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

	[XmlElement(Type = typeof(float), ElementName = "y")]
	public float Y
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

	[XmlElement(Type = typeof(float), ElementName = "z")]
	public float Z
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

	public static bool operator !=(AngularVelocityVector left, AngularVelocityVector right)
	{
		return !(left == right);
	}

	public static bool operator ==(AngularVelocityVector left, AngularVelocityVector right)
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
		return 12;
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
		sb.AppendLine("<AngularVelocityVector>");
		try
		{
			sb.AppendLine("<x type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</x>");
			sb.AppendLine("<y type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</y>");
			sb.AppendLine("<z type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</z>");
			sb.AppendLine("</AngularVelocityVector>");
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
		return this == obj as AngularVelocityVector;
	}

	public bool Equals(AngularVelocityVector obj)
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
		return smethod_0(smethod_0(smethod_0(0) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode();
	}

	static AngularVelocityVector()
	{
		Class72.smethod_20();
	}
}
