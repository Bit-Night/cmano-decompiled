#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998;

[Serializable]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(SixByteChunk))]
[XmlInclude(typeof(SimulationAddress))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(Vector3Double))]
[XmlRoot]
public class ArealObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<ArealObjectStatePdu>
{
	private EntityID ClaYhXvhsPr = new EntityID();

	private EntityID entityID_0 = new EntityID();

	private ushort zJyYhnVnvtJ;

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private SixByteChunk sixByteChunk_0 = new SixByteChunk();

	private ushort ushort_1;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private List<Vector3Double> list_0 = new List<Vector3Double>();

	[XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
	public EntityID ObjectID
	{
		get
		{
			return ClaYhXvhsPr;
		}
		set
		{
			ClaYhXvhsPr = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
	public EntityID ReferencedObjectID
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

	[XmlElement(Type = typeof(ushort), ElementName = "updateNumber")]
	public ushort UpdateNumber
	{
		get
		{
			return zJyYhnVnvtJ;
		}
		set
		{
			zJyYhnVnvtJ = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "forceID")]
	public byte ForceID
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

	[XmlElement(Type = typeof(byte), ElementName = "modifications")]
	public byte Modifications
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

	[XmlElement(Type = typeof(EntityType), ElementName = "objectType")]
	public EntityType ObjectType
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(SixByteChunk), ElementName = "objectAppearance")]
	public SixByteChunk ObjectAppearance
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfPoints")]
	public ushort NumberOfPoints
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

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "requesterID")]
	public SimulationAddress RequesterID
	{
		get
		{
			return simulationAddress_0;
		}
		set
		{
			simulationAddress_0 = value;
		}
	}

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "receivingID")]
	public SimulationAddress ReceivingID
	{
		get
		{
			return simulationAddress_1;
		}
		set
		{
			simulationAddress_1 = value;
		}
	}

	[XmlElement(ElementName = "objectLocationList", Type = typeof(List<Vector3Double>))]
	public List<Vector3Double> ObjectLocation => list_0;

	public ArealObjectStatePdu()
	{
		base.PduType = 45;
	}

	public static bool operator !=(ArealObjectStatePdu left, ArealObjectStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(ArealObjectStatePdu left, ArealObjectStatePdu right)
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
		int num = 0;
		num = base.GetMarshalledSize();
		num += ClaYhXvhsPr.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += sixByteChunk_0.GetMarshalledSize();
		num += 2;
		num += simulationAddress_0.GetMarshalledSize();
		num += simulationAddress_1.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Double vector3Double = list_0[i];
			num += vector3Double.GetMarshalledSize();
		}
		return num;
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
			ClaYhXvhsPr.Marshal(dos);
			entityID_0.Marshal(dos);
			dos.WriteUnsignedShort(zJyYhnVnvtJ);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			entityType_0.Marshal(dos);
			sixByteChunk_0.Marshal(dos);
			dos.WriteUnsignedShort((ushort)list_0.Count);
			simulationAddress_0.Marshal(dos);
			simulationAddress_1.Marshal(dos);
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

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis == null)
		{
			return;
		}
		try
		{
			ClaYhXvhsPr.Unmarshal(dis);
			entityID_0.Unmarshal(dis);
			zJyYhnVnvtJ = dis.ReadUnsignedShort();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			sixByteChunk_0.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			simulationAddress_0.Unmarshal(dis);
			simulationAddress_1.Unmarshal(dis);
			for (int i = 0; i < NumberOfPoints; i++)
			{
				Vector3Double vector3Double = new Vector3Double();
				vector3Double.Unmarshal(dis);
				list_0.Add(vector3Double);
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

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<ArealObjectStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<objectID>");
			ClaYhXvhsPr.Reflection(sb);
			sb.AppendLine("</objectID>");
			sb.AppendLine("<referencedObjectID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</referencedObjectID>");
			sb.AppendLine("<updateNumber type=\"ushort\">" + zJyYhnVnvtJ.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
			sb.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			sb.AppendLine("<modifications type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</modifications>");
			sb.AppendLine("<objectType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</objectType>");
			sb.AppendLine("<objectAppearance>");
			sixByteChunk_0.Reflection(sb);
			sb.AppendLine("</objectAppearance>");
			sb.AppendLine("<objectLocation type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</objectLocation>");
			sb.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(sb);
			sb.AppendLine("</requesterID>");
			sb.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(sb);
			sb.AppendLine("</receivingID>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<objectLocation" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Double\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</objectLocation" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</ArealObjectStatePdu>");
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
		return this == obj as ArealObjectStatePdu;
	}

	public bool Equals(ArealObjectStatePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SyntheticEnvironmentFamilyPdu)obj);
		if (!ClaYhXvhsPr.Equals(obj.ClaYhXvhsPr))
		{
			flag = false;
		}
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (zJyYhnVnvtJ != obj.zJyYhnVnvtJ)
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
		if (!entityType_0.Equals(obj.entityType_0))
		{
			flag = false;
		}
		if (!sixByteChunk_0.Equals(obj.sixByteChunk_0))
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (!simulationAddress_0.Equals(obj.simulationAddress_0))
		{
			flag = false;
		}
		if (!simulationAddress_1.Equals(obj.simulationAddress_1))
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

	private static int smethod_2(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ ClaYhXvhsPr.GetHashCode();
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ zJyYhnVnvtJ.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ sixByteChunk_0.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ simulationAddress_0.GetHashCode();
		num = smethod_2(num) ^ simulationAddress_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static ArealObjectStatePdu()
	{
		Class72.smethod_20();
	}
}
