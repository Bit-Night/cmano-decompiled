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
[XmlRoot]
[XmlInclude(typeof(Environment))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
public class EnvironmentalProcessPdu : SyntheticEnvironmentFamilyPdu, IEquatable<EnvironmentalProcessPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityType entityType_0 = new EntityType();

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private ushort ushort_1;

	private List<Environment> list_0 = new List<Environment>();

	[XmlElement(Type = typeof(EntityID), ElementName = "environementalProcessID")]
	public EntityID EnvironementalProcessID
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

	[XmlElement(Type = typeof(EntityType), ElementName = "environmentType")]
	public EntityType EnvironmentType
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

	[XmlElement(Type = typeof(byte), ElementName = "modelType")]
	public byte ModelType
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

	[XmlElement(Type = typeof(byte), ElementName = "environmentStatus")]
	public byte EnvironmentStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfEnvironmentRecords")]
	public byte NumberOfEnvironmentRecords
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

	[XmlElement(Type = typeof(ushort), ElementName = "sequenceNumber")]
	public ushort SequenceNumber
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

	[XmlElement(ElementName = "environmentRecordsList", Type = typeof(List<Environment>))]
	public List<Environment> EnvironmentRecords => list_0;

	public EnvironmentalProcessPdu()
	{
		base.PduType = 41;
	}

	public static bool operator !=(EnvironmentalProcessPdu left, EnvironmentalProcessPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(EnvironmentalProcessPdu left, EnvironmentalProcessPdu right)
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
		num += entityID_0.GetMarshalledSize();
		num += entityType_0.GetMarshalledSize();
		num++;
		num++;
		num++;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			Environment environment = list_0[i];
			num += environment.GetMarshalledSize();
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
			entityID_0.Marshal(dos);
			entityType_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedShort(ushort_1);
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
			entityID_0.Unmarshal(dis);
			entityType_0.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			byte_6 = dis.ReadUnsignedByte();
			ushort_1 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfEnvironmentRecords; i++)
			{
				Environment environment = new Environment();
				environment.Unmarshal(dis);
				list_0.Add(environment);
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
		sb.AppendLine("<EnvironmentalProcessPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<environementalProcessID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</environementalProcessID>");
			sb.AppendLine("<environmentType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</environmentType>");
			sb.AppendLine("<modelType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</modelType>");
			sb.AppendLine("<environmentStatus type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</environmentStatus>");
			sb.AppendLine("<environmentRecords type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</environmentRecords>");
			sb.AppendLine("<sequenceNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</sequenceNumber>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<environmentRecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Environment\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</environmentRecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</EnvironmentalProcessPdu>");
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
		return this == obj as EnvironmentalProcessPdu;
	}

	public bool Equals(EnvironmentalProcessPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SyntheticEnvironmentFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
		{
			flag = false;
		}
		if (!entityType_0.Equals(obj.entityType_0))
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
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
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
		num = smethod_2(num) ^ entityID_0.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static EnvironmentalProcessPdu()
	{
		Class72.smethod_20();
	}
}
