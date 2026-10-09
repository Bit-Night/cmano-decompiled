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
public class Vector3Double
{
	private double double_0;

	private double double_1;

	private double double_2;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(double), ElementName = "x")]
	public double X
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "y")]
	public double Y
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "z")]
	public double Z
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
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

	public static bool operator !=(Vector3Double left, Vector3Double right)
	{
		return !(left == right);
	}

	public static bool operator ==(Vector3Double left, Vector3Double right)
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
		return 24;
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
			dos.WriteDouble(double_0);
			dos.WriteDouble(double_1);
			dos.WriteDouble(double_2);
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
			double_0 = dis.ReadDouble();
			double_1 = dis.ReadDouble();
			double_2 = dis.ReadDouble();
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
		sb.AppendLine("<Vector3Double>");
		try
		{
			sb.AppendLine("<x type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</x>");
			sb.AppendLine("<y type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</y>");
			sb.AppendLine("<z type=\"double\">" + double_2.ToString(CultureInfo.InvariantCulture) + "</z>");
			sb.AppendLine("</Vector3Double>");
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
		return this == obj as Vector3Double;
	}

	public bool Equals(Vector3Double obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (double_0 != obj.double_0)
		{
			result = false;
		}
		if (double_1 != obj.double_1)
		{
			result = false;
		}
		if (double_2 != obj.double_2)
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
		return smethod_0(smethod_0(smethod_0(0) ^ double_0.GetHashCode()) ^ double_1.GetHashCode()) ^ double_2.GetHashCode();
	}

	public double CalculateLength()
	{
		return Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0) + Math.Pow(Z, 2.0));
	}

	static Vector3Double()
	{
		Class72.smethod_20();
	}
}
