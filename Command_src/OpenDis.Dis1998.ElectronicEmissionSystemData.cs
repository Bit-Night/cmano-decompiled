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
[XmlInclude(typeof(ElectronicEmissionBeamData))]
[XmlInclude(typeof(EmitterSystem))]
[XmlInclude(typeof(Vector3Float))]
[XmlRoot]
public class ElectronicEmissionSystemData
{
	private byte byte_0;

	private byte byte_1;

	private ushort ushort_0;

	private EmitterSystem emitterSystem_0 = new EmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private List<ElectronicEmissionBeamData> list_0 = new List<ElectronicEmissionBeamData>();

	[CompilerGenerated]
	private EventHandler<PduExceptionEventArgs> eventHandler_0;

	[XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
	public byte SystemDataLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
	public ushort EmissionsPadding2
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

	[XmlElement(Type = typeof(EmitterSystem), ElementName = "emitterSystem")]
	public EmitterSystem EmitterSystem
	{
		get
		{
			return emitterSystem_0;
		}
		set
		{
			emitterSystem_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "location")]
	public Vector3Float Location
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

	[XmlElement(ElementName = "beamDataRecordsList", Type = typeof(List<ElectronicEmissionBeamData>))]
	public List<ElectronicEmissionBeamData> BeamDataRecords => list_0;

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

	public static bool operator !=(ElectronicEmissionSystemData left, ElectronicEmissionSystemData right)
	{
		return !(left == right);
	}

	public static bool operator ==(ElectronicEmissionSystemData left, ElectronicEmissionSystemData right)
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
		int num = 0;
		num = 1;
		num = 2;
		num = 4;
		num = 4 + emitterSystem_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			ElectronicEmissionBeamData electronicEmissionBeamData = list_0[i];
			num += electronicEmissionBeamData.GetMarshalledSize();
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
			emitterSystem_0.Marshal(dos);
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
			emitterSystem_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			for (int i = 0; i < NumberOfBeams; i++)
			{
				ElectronicEmissionBeamData electronicEmissionBeamData = new ElectronicEmissionBeamData();
				electronicEmissionBeamData.Unmarshal(dis);
				list_0.Add(electronicEmissionBeamData);
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
		sb.AppendLine("<ElectronicEmissionSystemData>");
		try
		{
			sb.AppendLine("<systemDataLength type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
			sb.AppendLine("<beamDataRecords type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</beamDataRecords>");
			sb.AppendLine("<emissionsPadding2 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
			sb.AppendLine("<emitterSystem>");
			emitterSystem_0.Reflection(sb);
			sb.AppendLine("</emitterSystem>");
			sb.AppendLine("<location>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</location>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<beamDataRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"ElectronicEmissionBeamData\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</beamDataRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ElectronicEmissionSystemData>");
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
		return this == obj as ElectronicEmissionSystemData;
	}

	public bool Equals(ElectronicEmissionSystemData obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
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
			if (!emitterSystem_0.Equals(obj.emitterSystem_0))
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
		return false;
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
		num = smethod_0(num) ^ emitterSystem_0.GetHashCode();
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

	static ElectronicEmissionSystemData()
	{
		Class72.smethod_20();
	}
}
