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
[XmlInclude(typeof(VectoringNozzleSystemData))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(PropulsionSystemData))]
public class SeesPdu : DistributedEmissionsFamilyPdu, IEquatable<SeesPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	private List<PropulsionSystemData> list_0 = new List<PropulsionSystemData>();

	private List<VectoringNozzleSystemData> list_1 = new List<VectoringNozzleSystemData>();

	[XmlElement(Type = typeof(EntityID), ElementName = "orginatingEntityID")]
	public EntityID OrginatingEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "infraredSignatureRepresentationIndex")]
	public ushort InfraredSignatureRepresentationIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "acousticSignatureRepresentationIndex")]
	public ushort AcousticSignatureRepresentationIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "radarCrossSectionSignatureRepresentationIndex")]
	public ushort RadarCrossSectionSignatureRepresentationIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfPropulsionSystems")]
	public ushort NumberOfPropulsionSystems
	{
		get
		{
			return ushort_4;
		}
		set
		{
			ushort_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfVectoringNozzleSystems")]
	public ushort NumberOfVectoringNozzleSystems
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
		}
	}

	[XmlElement(ElementName = "propulsionSystemDataList", Type = typeof(List<PropulsionSystemData>))]
	public List<PropulsionSystemData> PropulsionSystemData => list_0;

	[XmlElement(ElementName = "vectoringSystemDataList", Type = typeof(List<VectoringNozzleSystemData>))]
	public List<VectoringNozzleSystemData> VectoringSystemData => list_1;

	public SeesPdu()
	{
		base.PduType = 30;
	}

	public static bool operator !=(SeesPdu left, SeesPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(SeesPdu left, SeesPdu right)
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
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			PropulsionSystemData propulsionSystemData = list_0[i];
			num += propulsionSystemData.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			VectoringNozzleSystemData vectoringNozzleSystemData = list_1[j];
			num += vectoringNozzleSystemData.GetMarshalledSize();
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
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort(ushort_3);
			dos.WriteUnsignedShort((ushort)list_0.Count);
			dos.WriteUnsignedShort((ushort)list_1.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
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
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			ushort_4 = dis.ReadUnsignedShort();
			ushort_5 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfPropulsionSystems; i++)
			{
				PropulsionSystemData propulsionSystemData = new PropulsionSystemData();
				propulsionSystemData.Unmarshal(dis);
				list_0.Add(propulsionSystemData);
			}
			for (int j = 0; j < NumberOfVectoringNozzleSystems; j++)
			{
				VectoringNozzleSystemData vectoringNozzleSystemData = new VectoringNozzleSystemData();
				vectoringNozzleSystemData.Unmarshal(dis);
				list_1.Add(vectoringNozzleSystemData);
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
		sb.AppendLine("<SeesPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<orginatingEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</orginatingEntityID>");
			sb.AppendLine("<infraredSignatureRepresentationIndex type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</infraredSignatureRepresentationIndex>");
			sb.AppendLine("<acousticSignatureRepresentationIndex type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</acousticSignatureRepresentationIndex>");
			sb.AppendLine("<radarCrossSectionSignatureRepresentationIndex type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</radarCrossSectionSignatureRepresentationIndex>");
			sb.AppendLine("<propulsionSystemData type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</propulsionSystemData>");
			sb.AppendLine("<vectoringSystemData type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</vectoringSystemData>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<propulsionSystemData" + i.ToString(CultureInfo.InvariantCulture) + " type=\"PropulsionSystemData\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</propulsionSystemData" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<vectoringSystemData" + j.ToString(CultureInfo.InvariantCulture) + " type=\"VectoringNozzleSystemData\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</vectoringSystemData" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</SeesPdu>");
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
		return this == obj as SeesPdu;
	}

	public bool Equals(SeesPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((DistributedEmissionsFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (ushort_1 != obj.ushort_1)
			{
				flag = false;
			}
			if (ushort_2 != obj.ushort_2)
			{
				flag = false;
			}
			if (ushort_3 != obj.ushort_3)
			{
				flag = false;
			}
			if (ushort_4 != obj.ushort_4)
			{
				flag = false;
			}
			if (ushort_5 != obj.ushort_5)
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
			if (list_1.Count != obj.list_1.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < list_1.Count; j++)
				{
					if (!list_1[j].Equals(obj.list_1[j]))
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
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_2(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}

	static SeesPdu()
	{
		Class72.smethod_20();
	}
}
