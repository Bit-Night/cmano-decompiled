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
public class Vector3Float
{
	private float float_0;

	private float float_1;

	private float float_2;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	public const double RAD_TO_DEG = 57.2957795130823;

	public const double DEG_TO_RAD = 0.0174532925199433;

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

	public static bool operator !=(Vector3Float left, Vector3Float right)
	{
		return !(left == right);
	}

	public static bool operator ==(Vector3Float left, Vector3Float right)
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
		sb.AppendLine("<Vector3Float>");
		try
		{
			sb.AppendLine("<x type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</x>");
			sb.AppendLine("<y type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</y>");
			sb.AppendLine("<z type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</z>");
			sb.AppendLine("</Vector3Float>");
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
		return this == obj as Vector3Float;
	}

	public bool Equals(Vector3Float obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
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
		return result;
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

	public double CalculateLength()
	{
		return Math.Sqrt(Math.Pow(X, 2.0) + Math.Pow(Y, 2.0) + Math.Pow(Z, 2.0));
	}

	public static Vector3Float converVectorENUtoECEF(Vector3Float ENU_v, double lat_deg, double lon_deg)
	{
		double num = lat_deg * 0.0174532925199433;
		double num2 = lon_deg * 0.0174532925199433;
		double num3 = Math.Cos(num);
		double num4 = Math.Sin(num);
		double num5 = Math.Cos(num2);
		double num6 = Math.Sin(num2);
		double num7 = num3 * (double)ENU_v.Z - num4 * (double)ENU_v.Y;
		double num8 = num4 * (double)ENU_v.Z + num3 * (double)ENU_v.Y;
		double num9 = num5 * num7 - num6 * (double)ENU_v.X;
		double num10 = num6 * num7 + num5 * (double)ENU_v.X;
		return new Vector3Float
		{
			X = (float)num9,
			Y = (float)num10,
			Z = (float)num8
		};
	}

	public static Vector3Float convertVectorECEFtoENU(Vector3Float ECEF_v, double lat_deg, double lon_deg)
	{
		double num = lat_deg * 0.0174532925199433;
		double num2 = lon_deg * 0.0174532925199433;
		double num3 = Math.Cos(num);
		double num4 = Math.Sin(num);
		double num5 = Math.Cos(num2);
		double num6 = Math.Sin(num2);
		double num7 = num5 * (double)ECEF_v.X + num6 * (double)ECEF_v.Y;
		double num8 = (0.0 - num6) * (double)ECEF_v.X + num5 * (double)ECEF_v.Y;
		double num9 = (0.0 - num4) * num7 + num3 * (double)ECEF_v.Z;
		double num10 = num3 * num7 + num4 * (double)ECEF_v.Z;
		return new Vector3Float
		{
			X = (float)num8,
			Y = (float)num9,
			Z = (float)num10
		};
	}

	public static Vector3Float calculateENUvelocityFromHeadingSpeed(double heading_deg, double hSpeed_mPerSec, float vSpeed_mPerSec)
	{
		double num = heading_deg * 0.0174532925199433;
		return new Vector3Float
		{
			X = (float)(hSpeed_mPerSec * Math.Sin(num)),
			Y = (float)(hSpeed_mPerSec * Math.Cos(num)),
			Z = vSpeed_mPerSec
		};
	}

	public static void calculateHeadingSpeedFromENUvelocity(Vector3Float ENU_v, out double heading_deg, out double hSpeed_mPerSec, out float vSpeed_mPerSec)
	{
		hSpeed_mPerSec = Math.Sqrt(ENU_v.X * ENU_v.X + ENU_v.Y * ENU_v.Y);
		heading_deg = Math.Atan2(ENU_v.X, ENU_v.Y) * 57.2957795130823;
		vSpeed_mPerSec = ENU_v.Z;
	}

	public static Vector3Float calculateECEFvelocityFromHeadingSpeed(double lat_deg, double lon_deg, double heading_deg, double hSpeed_mPerSec, float vSpeed_mPerSec)
	{
		return converVectorENUtoECEF(calculateENUvelocityFromHeadingSpeed(heading_deg, hSpeed_mPerSec, vSpeed_mPerSec), lat_deg, lon_deg);
	}

	public static void calculateHeadingSpeedFromECEFvelocity(Vector3Float ECEF_v, double lat_deg, double lon_deg, out double heading_deg, out double hSpeed_mPerSec, out float vSpeed_mPerSec)
	{
		calculateHeadingSpeedFromENUvelocity(convertVectorECEFtoENU(ECEF_v, lat_deg, lon_deg), out heading_deg, out hSpeed_mPerSec, out vSpeed_mPerSec);
	}

	static Vector3Float()
	{
		Class72.smethod_20();
	}
}
