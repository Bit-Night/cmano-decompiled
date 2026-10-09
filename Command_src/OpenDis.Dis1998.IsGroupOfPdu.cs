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
[XmlInclude(typeof(VariableDatum))]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class IsGroupOfPdu : EntityManagementFamilyPdu, IEquatable<IsGroupOfPdu>
{
	private EntityID entityID_0 = new EntityID();

	private byte byte_4;

	private byte byte_5;

	private uint uint_1;

	private double double_0;

	private double double_1;

	private List<VariableDatum> list_0 = new List<VariableDatum>();

	[XmlElement(Type = typeof(EntityID), ElementName = "groupEntityID")]
	public EntityID GroupEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "groupedEntityCategory")]
	public byte GroupedEntityCategory
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfGroupedEntities")]
	public byte NumberOfGroupedEntities
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

	[XmlElement(Type = typeof(uint), ElementName = "pad2")]
	public uint Pad2
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

	[XmlElement(Type = typeof(double), ElementName = "latitude")]
	public double Latitude
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	[XmlElement(Type = typeof(double), ElementName = "longitude")]
	public double Longitude
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	[XmlElement(ElementName = "groupedEntityDescriptionsList", Type = typeof(List<VariableDatum>))]
	public List<VariableDatum> GroupedEntityDescriptions => list_0;

	public IsGroupOfPdu()
	{
		base.PduType = 34;
	}

	public static bool operator !=(IsGroupOfPdu left, IsGroupOfPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(IsGroupOfPdu left, IsGroupOfPdu right)
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
		num += entityID_0.GetMarshalledSize();
		num++;
		num++;
		num += 4;
		num += 8;
		num += 8;
		for (int i = 0; i < list_0.Count; i++)
		{
			VariableDatum variableDatum = list_0[i];
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
			entityID_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedInt(uint_1);
			dos.WriteDouble(double_0);
			dos.WriteDouble(double_1);
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
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			uint_1 = dis.ReadUnsignedInt();
			double_0 = dis.ReadDouble();
			double_1 = dis.ReadDouble();
			for (int i = 0; i < NumberOfGroupedEntities; i++)
			{
				VariableDatum variableDatum = new VariableDatum();
				variableDatum.Unmarshal(dis);
				list_0.Add(variableDatum);
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
		sb.AppendLine("<IsGroupOfPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<groupEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</groupEntityID>");
			sb.AppendLine("<groupedEntityCategory type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</groupedEntityCategory>");
			sb.AppendLine("<groupedEntityDescriptions type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</groupedEntityDescriptions>");
			sb.AppendLine("<pad2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<latitude type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</latitude>");
			sb.AppendLine("<longitude type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</longitude>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<groupedEntityDescriptions" + i.ToString(CultureInfo.InvariantCulture) + " type=\"VariableDatum\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</groupedEntityDescriptions" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</IsGroupOfPdu>");
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
		return this == obj as IsGroupOfPdu;
	}

	public bool Equals(IsGroupOfPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((EntityManagementFamilyPdu)obj);
		if (!entityID_0.Equals(obj.entityID_0))
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
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		if (double_0 != obj.double_0)
		{
			flag = false;
		}
		if (double_1 != obj.double_1)
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
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		num = smethod_2(num) ^ double_0.GetHashCode();
		num = smethod_2(num) ^ double_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static IsGroupOfPdu()
	{
		Class72.smethod_20();
	}
}
