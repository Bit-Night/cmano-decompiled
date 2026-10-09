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
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(AcousticBeamData))]
[XmlInclude(typeof(AcousticEmitterSystem))]
public class AcousticEmitterSystemData
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private AcousticEmitterSystem acousticEmitterSystem_0 = new AcousticEmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private List<AcousticBeamData> list_0 = new List<AcousticBeamData>();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "emitterSystemDataLength")]
	public byte EmitterSystemDataLength
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
	public byte NumberOfBeams
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad2")]
	public ushort Pad2
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

	[XmlElement(Type = typeof(AcousticEmitterSystem), ElementName = "acousticEmitterSystem")]
	public AcousticEmitterSystem AcousticEmitterSystem
	{
		get
		{
			return acousticEmitterSystem_0;
		}
		set
		{
			acousticEmitterSystem_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "emitterLocation")]
	public Vector3Float EmitterLocation
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

	[XmlElement(ElementName = "beamRecordsList", Type = typeof(List<AcousticBeamData>))]
	public List<AcousticBeamData> BeamRecords => list_0;

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

	public static bool operator !=(AcousticEmitterSystemData left, AcousticEmitterSystemData right)
	{
		return !(left == right);
	}

	public static bool operator ==(AcousticEmitterSystemData left, AcousticEmitterSystemData right)
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
		int num = 0;
		num = 1;
		num = 2;
		num = 4;
		num = 4 + acousticEmitterSystem_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			AcousticBeamData acousticBeamData = list_0[i];
			num += acousticBeamData.GetMarshalledSize();
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
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedShort(ushort_0);
			acousticEmitterSystem_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
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
			acousticEmitterSystem_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			for (int i = 0; i < NumberOfBeams; i++)
			{
				AcousticBeamData acousticBeamData = new AcousticBeamData();
				acousticBeamData.Unmarshal(dis);
				list_0.Add(acousticBeamData);
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
		sb.AppendLine("<AcousticEmitterSystemData>");
		try
		{
			sb.AppendLine("<emitterSystemDataLength type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</emitterSystemDataLength>");
			sb.AppendLine("<beamRecords type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</beamRecords>");
			sb.AppendLine("<pad2 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<acousticEmitterSystem>");
			acousticEmitterSystem_0.Reflection(sb);
			sb.AppendLine("</acousticEmitterSystem>");
			sb.AppendLine("<emitterLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</emitterLocation>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<beamRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"AcousticBeamData\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</beamRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</AcousticEmitterSystemData>");
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
		return this == obj as AcousticEmitterSystemData;
	}

	public bool Equals(AcousticEmitterSystemData obj)
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
		if (!acousticEmitterSystem_0.Equals(obj.acousticEmitterSystem_0))
		{
			flag = false;
		}
		if (!vector3Float_0.Equals(obj.vector3Float_0))
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
		num = smethod_0(num) ^ acousticEmitterSystem_0.GetHashCode();
		num = smethod_0(num) ^ vector3Float_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_0(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static AcousticEmitterSystemData()
	{
		Class72.smethod_20();
	}
}
