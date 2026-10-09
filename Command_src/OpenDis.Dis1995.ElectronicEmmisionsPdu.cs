#define TRACE
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1995;

[Serializable]
[XmlInclude(typeof(FundamentalParameterData))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EmitterSystem))]
[XmlInclude(typeof(EventID))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class ElectronicEmmisionsPdu : DistributedEmissionsPdu, IEquatable<ElectronicEmmisionsPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EventID eventID_0 = new EventID();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_1;

	private byte byte_6;

	private byte byte_7;

	private ushort ushort_2;

	private EmitterSystem emitterSystem_0 = new EmitterSystem();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private byte byte_8;

	private byte byte_9;

	private ushort ushort_3;

	private FundamentalParameterData fundamentalParameterData_0 = new FundamentalParameterData();

	[XmlElement(Type = typeof(EntityID), ElementName = "emittingEntityID")]
	public EntityID EmittingEntityID
	{
		get
		{
			return entityID_0;
		}
		set
		{
			entityID_0 = value;
		}
	}

	[XmlElement(Type = typeof(EventID), ElementName = "eventID")]
	public EventID EventID
	{
		get
		{
			return eventID_0;
		}
		set
		{
			eventID_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "stateUpdateIndicator")]
	public byte StateUpdateIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSystems")]
	public byte NumberOfSystems
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

	[XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding")]
	public ushort EmissionsPadding
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

	[XmlElement(Type = typeof(byte), ElementName = "systemDataLength")]
	public byte SystemDataLength
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfBeams")]
	public byte NumberOfBeams
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "emissionsPadding2")]
	public ushort EmissionsPadding2
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

	[XmlElement(Type = typeof(byte), ElementName = "beamDataLength")]
	public byte BeamDataLength
	{
		get
		{
			return byte_8;
		}
		set
		{
			byte_8 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "beamIdNumber")]
	public byte BeamIdNumber
	{
		get
		{
			return byte_9;
		}
		set
		{
			byte_9 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "beamParameterIndex")]
	public ushort BeamParameterIndex
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

	public ElectronicEmmisionsPdu()
	{
		base.PduType = 23;
	}

	public static bool operator !=(ElectronicEmmisionsPdu left, ElectronicEmmisionsPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(ElectronicEmmisionsPdu left, ElectronicEmmisionsPdu right)
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

	public override int GetMarshalledSize()
	{
		return base.GetMarshalledSize() + entityID_0.GetMarshalledSize() + eventID_0.GetMarshalledSize() + 1 + 1 + 2 + 1 + 1 + 2 + emitterSystem_0.GetMarshalledSize() + vector3Float_0.GetMarshalledSize() + 1 + 1 + 2 + fundamentalParameterData_0.GetMarshalledSize();
	}

	public override void MarshalAutoLengthSet(DataOutputStream dos)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dos);
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
		if (dos == null)
		{
			return;
		}
		try
		{
			entityID_0.Marshal(dos);
			eventID_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte(byte_7);
			dos.WriteUnsignedShort(ushort_2);
			emitterSystem_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_8);
			dos.WriteUnsignedByte(byte_9);
			dos.WriteUnsignedShort(ushort_3);
			fundamentalParameterData_0.Marshal(dos);
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

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis == null)
		{
			return;
		}
		try
		{
			entityID_0.Unmarshal(dis);
			eventID_0.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			ushort_2 = dis.ReadUnsignedShort();
			emitterSystem_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			ushort_3 = dis.ReadUnsignedShort();
			fundamentalParameterData_0.Unmarshal(dis);
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

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<ElectronicEmmisionsPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<emittingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</emittingEntityID>");
			sb.AppendLine("<eventID>");
			eventID_0.Reflection(sb);
			sb.AppendLine("</eventID>");
			sb.AppendLine("<stateUpdateIndicator type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</stateUpdateIndicator>");
			sb.AppendLine("<numberOfSystems type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</numberOfSystems>");
			sb.AppendLine("<emissionsPadding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding>");
			sb.AppendLine("<systemDataLength type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</systemDataLength>");
			sb.AppendLine("<numberOfBeams type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</numberOfBeams>");
			sb.AppendLine("<emissionsPadding2 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</emissionsPadding2>");
			sb.AppendLine("<emitterSystem>");
			emitterSystem_0.Reflection(sb);
			sb.AppendLine("</emitterSystem>");
			sb.AppendLine("<location>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</location>");
			sb.AppendLine("<beamDataLength type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</beamDataLength>");
			sb.AppendLine("<beamIdNumber type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</beamIdNumber>");
			sb.AppendLine("<beamParameterIndex type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</beamParameterIndex>");
			sb.AppendLine("<fundamentalParameterData>");
			fundamentalParameterData_0.Reflection(sb);
			sb.AppendLine("</fundamentalParameterData>");
			sb.AppendLine("</ElectronicEmmisionsPdu>");
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
		return this == obj as ElectronicEmmisionsPdu;
	}

	public bool Equals(ElectronicEmmisionsPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((DistributedEmissionsPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (!eventID_0.Equals(obj.eventID_0))
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
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (byte_7 != obj.byte_7)
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
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
		if (byte_8 != obj.byte_8)
		{
			flag = false;
		}
		if (byte_9 != obj.byte_9)
		{
			flag = false;
		}
		if (ushort_3 != obj.ushort_3)
		{
			flag = false;
		}
		if (!fundamentalParameterData_0.Equals(obj.fundamentalParameterData_0))
		{
			flag = false;
		}
		return flag;
	}

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(smethod_2(0) ^ base.GetHashCode()) ^ entityID_0.GetHashCode()) ^ eventID_0.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ ushort_2.GetHashCode()) ^ emitterSystem_0.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ byte_8.GetHashCode()) ^ byte_9.GetHashCode()) ^ ushort_3.GetHashCode()) ^ fundamentalParameterData_0.GetHashCode();
	}

	static ElectronicEmmisionsPdu()
	{
		Class72.smethod_20();
	}
}
