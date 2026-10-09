#define TRACE
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
[XmlInclude(typeof(Vector3Double))]
public class AntennaLocation
{
	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> VjyYvlktLm9;

	[XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
	public Vector3Double AntennaLocation_
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "relativeAntennaLocation")]
	public Vector3Float RelativeAntennaLocation
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
		}
	}

	public event EventHandler<PduExceptionEventArgs> ExceptionOccured
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PduExceptionEventArgs> eventHandler = VjyYvlktLm9;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref VjyYvlktLm9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PduExceptionEventArgs> eventHandler = VjyYvlktLm9;
			EventHandler<PduExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PduExceptionEventArgs> value2 = (EventHandler<PduExceptionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref VjyYvlktLm9, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public static bool operator !=(AntennaLocation left, AntennaLocation right)
	{
		return !(left == right);
	}

	public static bool operator ==(AntennaLocation left, AntennaLocation right)
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
		return 0 + vector3Double_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize();
	}

	protected void RaiseExceptionOccured(Exception e)
	{
		if (PduBase.FireExceptionEvents && VjyYvlktLm9 != null)
		{
			VjyYvlktLm9(this, new PduExceptionEventArgs(e));
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
			vector3Double_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
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
			vector3Double_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
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
		sb.AppendLine("<AntennaLocation>");
		try
		{
			sb.AppendLine("<antennaLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</antennaLocation>");
			sb.AppendLine("<relativeAntennaLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</relativeAntennaLocation>");
			sb.AppendLine("</AntennaLocation>");
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
		return this == obj as AntennaLocation;
	}

	public bool Equals(AntennaLocation obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (!vector3Double_0.Equals(obj.vector3Double_0))
		{
			result = false;
		}
		if (!vector3Float_0.Equals(obj.vector3Float_0))
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
		return smethod_0(smethod_0(0) ^ vector3Double_0.GetHashCode()) ^ vector3Float_0.GetHashCode();
	}

	static AntennaLocation()
	{
		Class72.smethod_20();
	}
}
