#define TRACE
using System;
using System.Collections.Generic;
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
[XmlInclude(typeof(TrackJamTarget))]
[XmlInclude(typeof(FundamentalParameterData))]
public class ElectronicEmissionBeamData
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private FundamentalParameterData fundamentalParameterData_0 = new FundamentalParameterData();

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

	private uint uint_0;

	private List<TrackJamTarget> list_0 = new List<TrackJamTarget>();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
	public byte BeamDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "beamIDNumber")]
	public byte BeamIDNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
	public ushort BeamParameterIndex
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

	[XmlElement(Type = typeof(FundamentalParameterData), ElementName = "fundamentalParameterData")]
	public FundamentalParameterData FundamentalParameterData
	{
		get
		{
			return fundamentalParameterData_0;
		}
		set
		{
			fundamentalParameterData_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "beamFunction")]
	public byte BeamFunction
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfTrackJamTargets")]
	public byte NumberOfTrackJamTargets
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

	[XmlElement(Type = typeof(byte), ElementName = "highDensityTrackJam")]
	public byte HighDensityTrackJam
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pad4")]
	public byte Pad4
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "jammingModeSequence")]
	public uint JammingModeSequence
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

	[XmlElement(ElementName = "trackJamTargetsList", Type = typeof(List<TrackJamTarget>))]
	public List<TrackJamTarget> TrackJamTargets => list_0;

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

	public static bool operator !=(ElectronicEmissionBeamData left, ElectronicEmissionBeamData right)
	{
		return !(left == right);
	}

	public static bool operator ==(ElectronicEmissionBeamData left, ElectronicEmissionBeamData right)
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
		int num = 0;
		num = 1;
		num = 2;
		num = 4;
		num = 4 + fundamentalParameterData_0.GetMarshalledSize();
		num++;
		num++;
		num++;
		num++;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			TrackJamTarget trackJamTarget = list_0[i];
			num += trackJamTarget.GetMarshalledSize();
		}
		return num;
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
			dos.WriteUnsignedShort(ushort_0);
			fundamentalParameterData_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_2);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedInt(uint_0);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
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
			ushort_0 = dis.ReadUnsignedShort();
			fundamentalParameterData_0.Unmarshal(dis);
			byte_2 = dis.ReadUnsignedByte();
			byte_3 = dis.ReadUnsignedByte();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			uint_0 = dis.ReadUnsignedInt();
			for (int i = 0; i < NumberOfTrackJamTargets; i++)
			{
				TrackJamTarget trackJamTarget = new TrackJamTarget();
				trackJamTarget.Unmarshal(dis);
				list_0.Add(trackJamTarget);
			}
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
		sb.AppendLine("<ElectronicEmissionBeamData>");
		try
		{
			sb.AppendLine("<beamDataLength type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
			sb.AppendLine("<beamIDNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamIDNumber>");
			sb.AppendLine("<beamParameterIndex type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
			sb.AppendLine("<fundamentalParameterData>");
			fundamentalParameterData_0.Reflection(sb);
			sb.AppendLine("</fundamentalParameterData>");
			sb.AppendLine("<beamFunction type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</beamFunction>");
			sb.AppendLine("<trackJamTargets type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</trackJamTargets>");
			sb.AppendLine("<highDensityTrackJam type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</highDensityTrackJam>");
			sb.AppendLine("<pad4 type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</pad4>");
			sb.AppendLine("<jammingModeSequence type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</jammingModeSequence>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<trackJamTargets" + i.ToString(CultureInfo.InvariantCulture) + " type=\"TrackJamTarget\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</trackJamTargets" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ElectronicEmissionBeamData>");
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
		return this == obj as ElectronicEmissionBeamData;
	}

	public bool Equals(ElectronicEmissionBeamData obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (byte_0 != obj.byte_0)
		{
			flag = false;
		}
		if (byte_1 != obj.byte_1)
		{
			flag = false;
		}
		if (ushort_0 != obj.ushort_0)
		{
			flag = false;
		}
		if (!fundamentalParameterData_0.Equals(obj.fundamentalParameterData_0))
		{
			flag = false;
		}
		if (byte_2 != obj.byte_2)
		{
			flag = false;
		}
		if (byte_3 != obj.byte_3)
		{
			flag = false;
		}
		if (byte_4 != obj.byte_4)
		{
			flag = false;
		}
		if (byte_5 != obj.byte_5)
		{
			flag = false;
		}
		if (uint_0 != obj.uint_0)
		{
			flag = false;
		}
		if (list_0.Count != obj.list_0.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				if (!list_0[i].Equals(obj.list_0[i]))
				{
					flag = false;
				}
			}
		}
		return flag;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_0(0) ^ byte_0.GetHashCode();
		num = smethod_0(num) ^ byte_1.GetHashCode();
		num = smethod_0(num) ^ ushort_0.GetHashCode();
		num = smethod_0(num) ^ fundamentalParameterData_0.GetHashCode();
		num = smethod_0(num) ^ byte_2.GetHashCode();
		num = smethod_0(num) ^ byte_3.GetHashCode();
		num = smethod_0(num) ^ byte_4.GetHashCode();
		num = smethod_0(num) ^ byte_5.GetHashCode();
		num = smethod_0(num) ^ uint_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ElectronicEmissionBeamData()
	{
		Class72.smethod_20();
	}
}
