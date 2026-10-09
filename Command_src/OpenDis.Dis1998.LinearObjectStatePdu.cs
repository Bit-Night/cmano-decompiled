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
[XmlInclude(typeof(LinearSegmentParameter))]
[XmlRoot]
[XmlInclude(typeof(ObjectType))]
[XmlInclude(typeof(SimulationAddress))]
[XmlInclude(typeof(EntityID))]
public class LinearObjectStatePdu : SyntheticEnvironmentFamilyPdu, IEquatable<LinearObjectStatePdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private ushort ushort_1;

	private byte byte_4;

	private byte byte_5;

	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private SimulationAddress simulationAddress_1 = new SimulationAddress();

	private ObjectType objectType_0 = new ObjectType();

	private List<LinearSegmentParameter> list_0 = new List<LinearSegmentParameter>();

	[XmlElement(Type = typeof(EntityID), ElementName = "objectID")]
	public EntityID ObjectID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "referencedObjectID")]
	public EntityID ReferencedObjectID
	{
		get
		{
			return entityID_1;
		}
		set
		{
			entityID_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "updateNumber")]
	public ushort UpdateNumber
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfSegments")]
	public byte NumberOfSegments
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

	[XmlElement(Type = typeof(ObjectType), ElementName = "objectType")]
	public ObjectType ObjectType
	{
		get
		{
			return objectType_0;
		}
		set
		{
			objectType_0 = value;
		}
	}

	[XmlElement(ElementName = "linearSegmentParametersList", Type = typeof(List<LinearSegmentParameter>))]
	public List<LinearSegmentParameter> LinearSegmentParameters => list_0;

	public LinearObjectStatePdu()
	{
		base.PduType = 44;
	}

	public static bool operator !=(LinearObjectStatePdu left, LinearObjectStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(LinearObjectStatePdu left, LinearObjectStatePdu right)
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

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += entityID_0.GetMarshalledSize();
		num += entityID_1.GetMarshalledSize();
		num += 2;
		num++;
		num++;
		num += simulationAddress_0.GetMarshalledSize();
		num += simulationAddress_1.GetMarshalledSize();
		num += objectType_0.GetMarshalledSize();
		for (int i = 0; i < list_0.Count; i++)
		{
			LinearSegmentParameter linearSegmentParameter = list_0[i];
			num += linearSegmentParameter.GetMarshalledSize();
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
			entityID_1.Marshal(dos);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			simulationAddress_0.Marshal(dos);
			simulationAddress_1.Marshal(dos);
			objectType_0.Marshal(dos);
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
			entityID_1.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			simulationAddress_0.Unmarshal(dis);
			simulationAddress_1.Unmarshal(dis);
			objectType_0.Unmarshal(dis);
			for (int i = 0; i < NumberOfSegments; i++)
			{
				LinearSegmentParameter linearSegmentParameter = new LinearSegmentParameter();
				linearSegmentParameter.Unmarshal(dis);
				list_0.Add(linearSegmentParameter);
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
		sb.AppendLine("<LinearObjectStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<objectID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</objectID>");
			sb.AppendLine("<referencedObjectID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</referencedObjectID>");
			sb.AppendLine("<updateNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</updateNumber>");
			sb.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			sb.AppendLine("<linearSegmentParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</linearSegmentParameters>");
			sb.AppendLine("<requesterID>");
			simulationAddress_0.Reflection(sb);
			sb.AppendLine("</requesterID>");
			sb.AppendLine("<receivingID>");
			simulationAddress_1.Reflection(sb);
			sb.AppendLine("</receivingID>");
			sb.AppendLine("<objectType>");
			objectType_0.Reflection(sb);
			sb.AppendLine("</objectType>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<linearSegmentParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"LinearSegmentParameter\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</linearSegmentParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</LinearObjectStatePdu>");
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
		return this == obj as LinearObjectStatePdu;
	}

	public bool Equals(LinearObjectStatePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (ushort_1 != obj.ushort_1)
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
			if (!simulationAddress_0.Equals(obj.simulationAddress_0))
			{
				flag = false;
			}
			if (!simulationAddress_1.Equals(obj.simulationAddress_1))
			{
				flag = false;
			}
			if (!objectType_0.Equals(obj.objectType_0))
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
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ simulationAddress_0.GetHashCode();
		num = smethod_2(num) ^ simulationAddress_1.GetHashCode();
		num = smethod_2(num) ^ objectType_0.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static LinearObjectStatePdu()
	{
		Class72.smethod_20();
	}
}
