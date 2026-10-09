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
[XmlInclude(typeof(GridAxisRecord))]
[XmlInclude(typeof(Orientation))]
[XmlInclude(typeof(EntityType))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class GriddedDataPdu : SyntheticEnvironmentFamilyPdu, IEquatable<GriddedDataPdu>
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private byte byte_4;

	private byte byte_5;

	private EntityType entityType_0 = new EntityType();

	private Orientation orientation_0 = new Orientation();

	private long long_0;

	private uint CfrYroWonIl;

	private byte byte_6;

	private ushort ushort_5;

	private byte byte_7;

	private List<GridAxisRecord> list_0 = new List<GridAxisRecord>();

	[XmlElement(Type = typeof(EntityID), ElementName = "environmentalSimulationApplicationID")]
	public EntityID EnvironmentalSimulationApplicationID
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

	[XmlElement(Type = typeof(ushort), ElementName = "fieldNumber")]
	public ushort FieldNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "pduNumber")]
	public ushort PduNumber
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

	[XmlElement(Type = typeof(ushort), ElementName = "pduTotal")]
	public ushort PduTotal
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

	[XmlElement(Type = typeof(ushort), ElementName = "coordinateSystem")]
	public ushort CoordinateSystem
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfGridAxes")]
	public byte NumberOfGridAxes
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

	[XmlElement(Type = typeof(byte), ElementName = "constantGrid")]
	public byte ConstantGrid
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

	[XmlElement(Type = typeof(long), ElementName = "sampleTime")]
	public long SampleTime
	{
		get
		{
			return long_0;
		}
		set
		{
			long_0 = value;
		}
	}

	[XmlElement(Type = typeof(uint), ElementName = "totalValues")]
	public uint TotalValues
	{
		get
		{
			return CfrYroWonIl;
		}
		set
		{
			CfrYroWonIl = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "vectorDimension")]
	public byte VectorDimension
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
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

	[XmlElement(Type = typeof(byte), ElementName = "padding2")]
	public byte Padding2
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

	[XmlElement(ElementName = "gridDataListList", Type = typeof(List<GridAxisRecord>))]
	public List<GridAxisRecord> GridDataList => list_0;

	public GriddedDataPdu()
	{
		base.PduType = 42;
	}

	public static bool operator !=(GriddedDataPdu left, GriddedDataPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(GriddedDataPdu left, GriddedDataPdu right)
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
		num++;
		num++;
		num += entityType_0.GetMarshalledSize();
		num += orientation_0.GetMarshalledSize();
		num += 8;
		num += 4;
		num++;
		num += 2;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			GridAxisRecord gridAxisRecord = list_0[i];
			num += gridAxisRecord.GetMarshalledSize();
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
			dos.WriteUnsignedShort(ushort_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedByte(byte_5);
			entityType_0.Marshal(dos);
			orientation_0.Marshal(dos);
			dos.WriteLong(long_0);
			dos.WriteUnsignedInt(CfrYroWonIl);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedShort(ushort_5);
			dos.WriteUnsignedByte(byte_7);
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
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			ushort_4 = dis.ReadUnsignedShort();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			entityType_0.Unmarshal(dis);
			orientation_0.Unmarshal(dis);
			long_0 = dis.ReadLong();
			CfrYroWonIl = dis.ReadUnsignedInt();
			byte_6 = dis.ReadUnsignedByte();
			ushort_5 = dis.ReadUnsignedShort();
			byte_7 = dis.ReadUnsignedByte();
			for (int i = 0; i < NumberOfGridAxes; i++)
			{
				GridAxisRecord gridAxisRecord = new GridAxisRecord();
				gridAxisRecord.Unmarshal(dis);
				list_0.Add(gridAxisRecord);
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
		sb.AppendLine("<GriddedDataPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<environmentalSimulationApplicationID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</environmentalSimulationApplicationID>");
			sb.AppendLine("<fieldNumber type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</fieldNumber>");
			sb.AppendLine("<pduNumber type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</pduNumber>");
			sb.AppendLine("<pduTotal type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</pduTotal>");
			sb.AppendLine("<coordinateSystem type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</coordinateSystem>");
			sb.AppendLine("<gridDataList type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</gridDataList>");
			sb.AppendLine("<constantGrid type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</constantGrid>");
			sb.AppendLine("<environmentType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</environmentType>");
			sb.AppendLine("<orientation>");
			orientation_0.Reflection(sb);
			sb.AppendLine("</orientation>");
			sb.AppendLine("<sampleTime type=\"long\">" + long_0.ToString(CultureInfo.InvariantCulture) + "</sampleTime>");
			sb.AppendLine("<totalValues type=\"uint\">" + CfrYroWonIl.ToString(CultureInfo.InvariantCulture) + "</totalValues>");
			sb.AppendLine("<vectorDimension type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</vectorDimension>");
			sb.AppendLine("<padding1 type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<gridDataList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"GridAxisRecord\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</gridDataList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</GriddedDataPdu>");
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
		return this == obj as GriddedDataPdu;
	}

	public bool Equals(GriddedDataPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((SyntheticEnvironmentFamilyPdu)obj);
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
			if (!orientation_0.Equals(obj.orientation_0))
			{
				flag = false;
			}
			if (long_0 != obj.long_0)
			{
				flag = false;
			}
			if (CfrYroWonIl != obj.CfrYroWonIl)
			{
				flag = false;
			}
			if (byte_6 != obj.byte_6)
			{
				flag = false;
			}
			if (ushort_5 != obj.ushort_5)
			{
				flag = false;
			}
			if (byte_7 != obj.byte_7)
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
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ entityType_0.GetHashCode();
		num = smethod_2(num) ^ orientation_0.GetHashCode();
		num = smethod_2(num) ^ long_0.GetHashCode();
		num = smethod_2(num) ^ CfrYroWonIl.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static GriddedDataPdu()
	{
		Class72.smethod_20();
	}
}
