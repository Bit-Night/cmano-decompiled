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
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(AggregateID))]
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(VariableDatum))]
[XmlRoot]
[XmlInclude(typeof(AggregateMarking))]
public class AggregateStatePdu : EntityManagementFamilyPdu, IEquatable<AggregateStatePdu>
{
	private EntityID xOkYhtFbTie = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private uint uint_1;

	private AggregateMarking aggregateMarking_0 = new AggregateMarking();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private Orientation orientation_0 = new Orientation();

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_1 = new Vector3Float();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private List<AggregateID> list_0 = new List<AggregateID>();

	private List<EntityID> list_1 = new List<EntityID>();

	private byte byte_6;

	private List<EntityType> list_2 = new List<EntityType>();

	private List<EntityType> list_3 = new List<EntityType>();

	private uint uint_2;

	private List<VariableDatum> list_4 = new List<VariableDatum>();

	[XmlElement(Type = typeof(EntityID), ElementName = "aggregateID")]
	public EntityID AggregateID
	{
		get
		{
			return xOkYhtFbTie;
		}
		set
		{
			xOkYhtFbTie = value;
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

	[XmlElement(Type = typeof(byte), ElementName = "aggregateState")]
	public byte AggregateState
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

	[XmlElement(Type = typeof(EntityType), ElementName = "aggregateType")]
	public EntityType AggregateType
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

	[XmlElement(Type = typeof(uint), ElementName = "formation")]
	public uint Formation
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	[XmlElement(Type = typeof(AggregateMarking), ElementName = "aggregateMarking")]
	public AggregateMarking AggregateMarking
	{
		get
		{
			return aggregateMarking_0;
		}
		set
		{
			aggregateMarking_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "dimensions")]
	public Vector3Float Dimensions
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "centerOfMass")]
	public Vector3Double CenterOfMass
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "velocity")]
	public Vector3Float Velocity
	{
		get
		{
			return vector3Float_1;
		}
		set
		{
			vector3Float_1 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDisAggregates")]
	public ushort NumberOfDisAggregates
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDisEntities")]
	public ushort NumberOfDisEntities
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentAggregateTypes")]
	public ushort NumberOfSilentAggregateTypes
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfSilentEntityTypes")]
	public ushort NumberOfSilentEntityTypes
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

	[XmlElement(ElementName = "aggregateIDListList", Type = typeof(List<AggregateID>))]
	public List<AggregateID> AggregateIDList => list_0;

	[XmlElement(ElementName = "entityIDListList", Type = typeof(List<EntityID>))]
	public List<EntityID> EntityIDList => list_1;

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
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

	[XmlElement(ElementName = "silentAggregateSystemListList", Type = typeof(List<EntityType>))]
	public List<EntityType> SilentAggregateSystemList => list_2;

	[XmlElement(ElementName = "silentEntitySystemListList", Type = typeof(List<EntityType>))]
	public List<EntityType> SilentEntitySystemList => list_3;

	[XmlElement(Type = typeof(uint), ElementName = "numberOfVariableDatumRecords")]
	public uint NumberOfVariableDatumRecords
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	[XmlElement(ElementName = "variableDatumListList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> VariableDatumList => list_4;

	public AggregateStatePdu()
	{
		base.PduType = 33;
	}

	public static bool operator !=(AggregateStatePdu left, AggregateStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(AggregateStatePdu left, AggregateStatePdu right)
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

	public override int GetMarshalledSize()
	{
		int num = 0;
		num = base.GetMarshalledSize();
		num += xOkYhtFbTie.GetMarshalledSize();
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += 4;
		num += aggregateMarking_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += vector3Double_0.GetMarshalledSize();
		num += vector3Float_1.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			AggregateID aggregateID = list_0[i];
			num += aggregateID.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			EntityID entityID = list_1[j];
			num += entityID.GetMarshalledSize();
		}
		num++;
		for (int k = 0; k < list_2.Count; k++)
		{
			EntityType entityType = list_2[k];
			num += entityType.GetMarshalledSize();
		}
		for (int l = 0; l < list_3.Count; l++)
		{
			EntityType entityType2 = list_3[l];
			num += entityType2.GetMarshalledSize();
		}
		num += 4;
		for (int m = 0; m < list_4.Count; m++)
		{
			VariableDatum variableDatum = list_4[m];
			num += variableDatum.GetMarshalledSize();
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
			xOkYhtFbTie.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			entityType_0.Marshal(dos);
			dos.WriteUnsignedInt(uint_1);
			aggregateMarking_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			orientation_0.Marshal(dos);
			vector3Double_0.Marshal(dos);
			vector3Float_1.Marshal(dos);
			dos.WriteUnsignedShort((ushort)list_0.Count);
			dos.WriteUnsignedShort((ushort)list_1.Count);
			dos.WriteUnsignedShort((ushort)list_2.Count);
			dos.WriteUnsignedShort((ushort)list_3.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
			}
			dos.WriteUnsignedByte(byte_6);
			for (int k = 0; k < list_2.Count; k++)
			{
				list_2[k].Marshal(dos);
			}
			for (int l = 0; l < list_3.Count; l++)
			{
				list_3[l].Marshal(dos);
			}
			dos.WriteUnsignedInt((uint)list_4.Count);
			for (int m = 0; m < list_4.Count; m++)
			{
				list_4[m].Marshal(dos);
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
			xOkYhtFbTie.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			uint_1 = dis.ReadUnsignedInt();
			aggregateMarking_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			orientation_0.Unmarshal(dis);
			vector3Double_0.Unmarshal(dis);
			vector3Float_1.Unmarshal(dis);
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			ushort_4 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfDisAggregates; i++)
			{
				AggregateID aggregateID = new AggregateID();
				aggregateID.Unmarshal(dis);
				list_0.Add(aggregateID);
			}
			for (int j = 0; j < NumberOfDisEntities; j++)
			{
				EntityID entityID = new EntityID();
				entityID.Unmarshal(dis);
				list_1.Add(entityID);
			}
			byte_6 = dis.ReadUnsignedByte();
			for (int k = 0; k < NumberOfSilentAggregateTypes; k++)
			{
				EntityType entityType = new EntityType();
				entityType.Unmarshal(dis);
				list_2.Add(entityType);
			}
			for (int l = 0; l < NumberOfSilentEntityTypes; l++)
			{
				EntityType entityType2 = new EntityType();
				entityType2.Unmarshal(dis);
				list_3.Add(entityType2);
			}
			uint_2 = dis.ReadUnsignedInt();
			for (int m = 0; m < NumberOfVariableDatumRecords; m++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dis);
				list_4.Add(variableDatum);
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
		sb.AppendLine("<AggregateStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<aggregateID>");
			xOkYhtFbTie.Reflection(sb);
			sb.AppendLine("</aggregateID>");
			sb.AppendLine("<forceID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceID>");
			sb.AppendLine("<aggregateState type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</aggregateState>");
			sb.AppendLine("<aggregateType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</aggregateType>");
			sb.AppendLine("<formation type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</formation>");
			sb.AppendLine("<aggregateMarking>");
			aggregateMarking_0.Reflection(sb);
			sb.AppendLine("</aggregateMarking>");
			sb.AppendLine("<dimensions>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</dimensions>");
			sb.AppendLine("<orientation>");
			orientation_0.Reflection(sb);
			sb.AppendLine("</orientation>");
			sb.AppendLine("<centerOfMass>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</centerOfMass>");
			sb.AppendLine("<velocity>");
			vector3Float_1.Reflection(sb);
			sb.AppendLine("</velocity>");
			sb.AppendLine("<aggregateIDList type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</aggregateIDList>");
			sb.AppendLine("<entityIDList type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</entityIDList>");
			sb.AppendLine("<silentAggregateSystemList type=\"ushort\">" + list_2.Count.ToString(CultureInfo.InvariantCulture) + "</silentAggregateSystemList>");
			sb.AppendLine("<silentEntitySystemList type=\"ushort\">" + list_3.Count.ToString(CultureInfo.InvariantCulture) + "</silentEntitySystemList>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<aggregateIDList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"AggregateID\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</aggregateIDList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<entityIDList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"EntityID\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</entityIDList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<pad2 type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			for (int k = 0; k < list_2.Count; k++)
			{
				sb.AppendLine("<silentAggregateSystemList" + k.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
				list_2[k].Reflection(sb);
				sb.AppendLine("</silentAggregateSystemList" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int l = 0; l < list_3.Count; l++)
			{
				sb.AppendLine("<silentEntitySystemList" + l.ToString(CultureInfo.InvariantCulture) + " type=\"EntityType\">");
				list_3[l].Reflection(sb);
				sb.AppendLine("</silentEntitySystemList" + l.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<variableDatumList type=\"uint\">" + list_4.Count.ToString(CultureInfo.InvariantCulture) + "</variableDatumList>");
			for (int m = 0; m < list_4.Count; m++)
			{
				sb.AppendLine("<variableDatumList" + m.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_4[m].Reflection(sb);
				sb.AppendLine("</variableDatumList" + m.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</AggregateStatePdu>");
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
		return this == obj as AggregateStatePdu;
	}

	public bool Equals(AggregateStatePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((EntityManagementFamilyPdu)obj);
			if (!xOkYhtFbTie.Equals(obj.xOkYhtFbTie))
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
			if (uint_1 != obj.uint_1)
			{
				flag = false;
			}
			if (!aggregateMarking_0.Equals(obj.aggregateMarking_0))
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(obj.vector3Float_0))
			{
				flag = false;
			}
			if (!orientation_0.Equals(obj.orientation_0))
			{
				flag = false;
			}
			if (!vector3Double_0.Equals(obj.vector3Double_0))
			{
				flag = false;
			}
			if (!vector3Float_1.Equals(obj.vector3Float_1))
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
			if (byte_6 != obj.byte_6)
			{
				flag = false;
			}
			if (list_2.Count != obj.list_2.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int k = 0; k < list_2.Count; k++)
				{
					if (!list_2[k].Equals(obj.list_2[k]))
					{
						flag = false;
					}
				}
			}
			if (list_3.Count != obj.list_3.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int l = 0; l < list_3.Count; l++)
				{
					if (!list_3[l].Equals(obj.list_3[l]))
					{
						flag = false;
					}
				}
			}
			if (uint_2 != obj.uint_2)
			{
				flag = false;
			}
			if (list_4.Count != obj.list_4.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int m = 0; m < list_4.Count; m++)
				{
					if (!list_4[m].Equals(obj.list_4[m]))
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
		num = smethod_2(num) ^ xOkYhtFbTie.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ aggregateMarking_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_1.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
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
		num = smethod_2(num) ^ byte_6.GetHashCode();
		if (list_2.Count > 0)
		{
			for (int k = 0; k < list_2.Count; k++)
			{
				num = smethod_2(num) ^ list_2[k].GetHashCode();
			}
		}
		if (list_3.Count > 0)
		{
			for (int l = 0; l < list_3.Count; l++)
			{
				num = smethod_2(num) ^ list_3[l].GetHashCode();
			}
		}
		num = smethod_2(num) ^ uint_2.GetHashCode();
		if (list_4.Count > 0)
		{
			for (int m = 0; m < list_4.Count; m++)
			{
				num = smethod_2(num) ^ list_4[m].GetHashCode();
			}
		}
		return num;
	}

	static AggregateStatePdu()
	{
		Class72.smethod_20();
	}
}
