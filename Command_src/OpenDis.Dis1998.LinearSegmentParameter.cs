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
[XmlInclude(typeof(SixByteChunk))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Orientation))]
[XmlRoot]
public class LinearSegmentParameter
{
	private byte byte_0;

	private SixByteChunk sixByteChunk_0 = new SixByteChunk();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Orientation orientation_0 = new Orientation();

	private ushort ushort_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private uint uint_0;

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "segmentNumber")]
	public byte SegmentNumber
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

	[XmlElement(Type = typeof(SixByteChunk), ElementName = "segmentAppearance")]
	public SixByteChunk SegmentAppearance
	{
		get
		{
			return sixByteChunk_0;
		}
		set
		{
			sixByteChunk_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Double), ElementName = "location")]
	public Vector3Double Location
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

	[XmlElement(Type = typeof(Orientation), ElementName = "orientation")]
	public Orientation Orientation
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentLength")]
	public ushort SegmentLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentWidth")]
	public ushort SegmentWidth
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentHeight")]
	public ushort SegmentHeight
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

	[XmlElement(Type = typeof(ushort), ElementName = "segmentDepth")]
	public ushort SegmentDepth
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

	[XmlElement(Type = typeof(uint), ElementName = "pad1")]
	public uint Pad1
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

	public static bool operator !=(LinearSegmentParameter left, LinearSegmentParameter right)
	{
		return !(left == right);
	}

	public static bool operator ==(LinearSegmentParameter left, LinearSegmentParameter right)
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
		return 1 + sixByteChunk_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize() + orientation_0.GetMarshalledSize() + 2 + 2 + 2 + 2 + 4;
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
			sixByteChunk_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			orientation_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_0);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort(ushort_3);
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
			byte_0 = dis.ReadUnsignedByte();
			sixByteChunk_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			orientation_0.Unmarshal(dis);
			ushort_0 = dis.ReadUnsignedShort();
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
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
		sb.AppendLine("<LinearSegmentParameter>");
		try
		{
			sb.AppendLine("<segmentNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</segmentNumber>");
			sb.AppendLine("<segmentAppearance>");
			sixByteChunk_0.Reflection(sb);
			sb.AppendLine("</segmentAppearance>");
			sb.AppendLine("<location>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</location>");
			sb.AppendLine("<orientation>");
			orientation_0.Reflection(sb);
			sb.AppendLine("</orientation>");
			sb.AppendLine("<segmentLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</segmentLength>");
			sb.AppendLine("<segmentWidth type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</segmentWidth>");
			sb.AppendLine("<segmentHeight type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</segmentHeight>");
			sb.AppendLine("<segmentDepth type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</segmentDepth>");
			sb.AppendLine("<pad1 type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("</LinearSegmentParameter>");
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
		return this == obj as LinearSegmentParameter;
	}

	public bool Equals(LinearSegmentParameter obj)
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
		if (!sixByteChunk_0.Equals(obj.sixByteChunk_0))
		{
			result = false;
		}
		if (!vector3Double_0.Equals(obj.vector3Double_0))
		{
			result = false;
		}
		if (!orientation_0.Equals(obj.orientation_0))
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
		if (uint_0 != obj.uint_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ sixByteChunk_0.GetHashCode()) ^ vector3Double_0.GetHashCode()) ^ orientation_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode()) ^ uint_0.GetHashCode();
	}

	static LinearSegmentParameter()
	{
		Class72.smethod_20();
	}
}
