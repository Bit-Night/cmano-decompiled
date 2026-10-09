using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(StandardVariableSpecification))]
[XmlInclude(typeof(ClockTime))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(EntityType))]
public class DirectedEnergyFirePdu : WarfareFamilyPdu, IEquatable<DirectedEnergyFirePdu>
{
	private EntityType entityType_0 = new EntityType();

	private ClockTime clockTime_0 = new ClockTime();

	private float float_0;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private int int_0;

	private int int_1;

	private byte byte_6;

	private byte byte_7;

	private uint uint_1;

	private ushort ushort_1;

	private ushort ushort_2;

	private List<StandardVariableSpecification> list_0 = new List<StandardVariableSpecification>();

	[XmlElement(Type = typeof(EntityType), ElementName = "munitionType")]
	public EntityType MunitionType
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

	[XmlElement(Type = typeof(ClockTime), ElementName = "shotStartTime")]
	public ClockTime ShotStartTime
	{
		get
		{
			return clockTime_0;
		}
		set
		{
			clockTime_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "commulativeShotTime")]
	public float CommulativeShotTime
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "ApertureEmitterLocation")]
	public Vector3Float ApertureEmitterLocation
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

	[XmlElement(Type = typeof(float), ElementName = "apertureDiameter")]
	public float ApertureDiameter
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "wavelength")]
	public float Wavelength
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "peakIrradiance")]
	public float PeakIrradiance
	{
		get
		{
			return float_3;
		}
		set
		{
			float_3 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "pulseRepetitionFrequency")]
	public float PulseRepetitionFrequency
	{
		get
		{
			return float_4;
		}
		set
		{
			float_4 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "pulseWidth")]
	public int PulseWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "flags")]
	public int Flags
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "pulseShape")]
	public byte PulseShape
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(uint), ElementName = "padding2")]
	public uint Padding2
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding3")]
	public ushort Padding3
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

	[XmlElement(Type = typeof(ushort), ElementName = "numberOfDERecords")]
	public ushort NumberOfDERecords
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

	[XmlElement(ElementName = "dERecordsList", Type = typeof(List<StandardVariableSpecification>))]
	public List<StandardVariableSpecification> DERecords => list_0;

	public DirectedEnergyFirePdu()
	{
		base.PduType = 68;
	}

	public static bool operator !=(DirectedEnergyFirePdu left, DirectedEnergyFirePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(DirectedEnergyFirePdu left, DirectedEnergyFirePdu right)
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
		num += entityType_0.GetMarshalledSize();
		num += clockTime_0.GetMarshalledSize();
		num += 4;
		num += vector3Float_0.GetMarshalledSize();
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num++;
		num++;
		num += 4;
		num += 2;
		num += 2;
		for (int i = 0; i < list_0.Count; i++)
		{
			StandardVariableSpecification standardVariableSpecification = list_0[i];
			num += standardVariableSpecification.GetMarshalledSize();
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
			entityType_0.Marshal(dos);
			clockTime_0.Marshal(dos);
			dos.WriteFloat(float_0);
			vector3Float_0.Marshal(dos);
			dos.WriteFloat(float_1);
			dos.WriteFloat(float_2);
			dos.WriteFloat(float_3);
			dos.WriteFloat(float_4);
			dos.WriteInt(int_0);
			dos.WriteInt(int_1);
			dos.WriteByte(byte_6);
			dos.WriteUnsignedByte(byte_7);
			dos.WriteUnsignedInt(uint_1);
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedShort((ushort)list_0.Count);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
		}
		catch (Exception e)
		{
			OnException(e);
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
			entityType_0.Unmarshal(dis);
			clockTime_0.Unmarshal(dis);
			float_0 = dis.ReadFloat();
			vector3Float_0.Unmarshal(dis);
			float_1 = dis.ReadFloat();
			float_2 = dis.ReadFloat();
			float_3 = dis.ReadFloat();
			float_4 = dis.ReadFloat();
			int_0 = dis.ReadInt();
			int_1 = dis.ReadInt();
			byte_6 = dis.ReadByte();
			byte_7 = dis.ReadUnsignedByte();
			uint_1 = dis.ReadUnsignedInt();
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			for (int i = 0; i < NumberOfDERecords; i++)
			{
				StandardVariableSpecification standardVariableSpecification = new StandardVariableSpecification();
				standardVariableSpecification.Unmarshal(dis);
				list_0.Add(standardVariableSpecification);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DirectedEnergyFirePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<munitionType>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</munitionType>");
			sb.AppendLine("<shotStartTime>");
			clockTime_0.Reflection(sb);
			sb.AppendLine("</shotStartTime>");
			sb.AppendLine("<commulativeShotTime type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</commulativeShotTime>");
			sb.AppendLine("<ApertureEmitterLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</ApertureEmitterLocation>");
			sb.AppendLine("<apertureDiameter type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</apertureDiameter>");
			sb.AppendLine("<wavelength type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</wavelength>");
			sb.AppendLine("<peakIrradiance type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</peakIrradiance>");
			sb.AppendLine("<pulseRepetitionFrequency type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</pulseRepetitionFrequency>");
			sb.AppendLine("<pulseWidth type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</pulseWidth>");
			sb.AppendLine("<flags type=\"int\">" + int_1.ToString(CultureInfo.InvariantCulture) + "</flags>");
			sb.AppendLine("<pulseShape type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</pulseShape>");
			sb.AppendLine("<padding1 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<padding3 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			sb.AppendLine("<dERecords type=\"ushort\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</dERecords>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<dERecords" + i.ToString(CultureInfo.InvariantCulture) + " type=\"StandardVariableSpecification\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</dERecords" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</DirectedEnergyFirePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyFirePdu;
	}

	public bool Equals(DirectedEnergyFirePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((WarfareFamilyPdu)obj);
			if (!entityType_0.Equals(obj.entityType_0))
			{
				flag = false;
			}
			if (!clockTime_0.Equals(obj.clockTime_0))
			{
				flag = false;
			}
			if (float_0 != obj.float_0)
			{
				flag = false;
			}
			if (!vector3Float_0.Equals(obj.vector3Float_0))
			{
				flag = false;
			}
			if (float_1 != obj.float_1)
			{
				flag = false;
			}
			if (float_2 != obj.float_2)
			{
				flag = false;
			}
			if (float_3 != obj.float_3)
			{
				flag = false;
			}
			if (float_4 != obj.float_4)
			{
				flag = false;
			}
			if (int_0 != obj.int_0)
			{
				flag = false;
			}
			if (int_1 != obj.int_1)
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
			if (uint_1 != obj.uint_1)
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

	private static int smethod_3(int int_2)
	{
		int_2 <<= 5 + int_2;
		return int_2;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityType_0.GetHashCode();
		num = smethod_3(num) ^ clockTime_0.GetHashCode();
		num = smethod_3(num) ^ float_0.GetHashCode();
		num = smethod_3(num) ^ vector3Float_0.GetHashCode();
		num = smethod_3(num) ^ float_1.GetHashCode();
		num = smethod_3(num) ^ float_2.GetHashCode();
		num = smethod_3(num) ^ float_3.GetHashCode();
		num = smethod_3(num) ^ float_4.GetHashCode();
		num = smethod_3(num) ^ int_0.GetHashCode();
		num = smethod_3(num) ^ int_1.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ ushort_1.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static DirectedEnergyFirePdu()
	{
		Class72.smethod_20();
	}
}
