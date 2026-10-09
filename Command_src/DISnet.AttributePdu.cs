using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(SimulationAddress))]
public class AttributePdu : EntityInformationFamilyPdu, IEquatable<AttributePdu>
{
	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private int int_0;

	private short short_0;

	private byte byte_6;

	private byte byte_7;

	private uint uint_1;

	private byte byte_8;

	private byte ikvYjQajqPK;

	private ushort ushort_1;

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "originatingSimulationAddress")]
	public SimulationAddress OriginatingSimulationAddress
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

	[XmlElement(Type = typeof(int), ElementName = "padding1")]
	public int Padding1
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

	[XmlElement(Type = typeof(short), ElementName = "padding2")]
	public short Padding2
	{
		get
		{
			return short_0;
		}
		set
		{
			short_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "attributeRecordPduType")]
	public byte AttributeRecordPduType
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

	[XmlElement(Type = typeof(byte), ElementName = "attributeRecordProtocolVersion")]
	public byte AttributeRecordProtocolVersion
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

	[XmlElement(Type = typeof(uint), ElementName = "masterAttributeRecordType")]
	public uint MasterAttributeRecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "actionCode")]
	public byte ActionCode
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

	[XmlElement(Type = typeof(byte), ElementName = "padding3")]
	public byte Padding3
	{
		get
		{
			return ikvYjQajqPK;
		}
		set
		{
			ikvYjQajqPK = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "numberAttributeRecordSet")]
	public ushort NumberAttributeRecordSet
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

	public static bool operator !=(AttributePdu left, AttributePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(AttributePdu left, AttributePdu right)
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
		return base.GetMarshalledSize() + simulationAddress_0.GetMarshalledSize() + 4 + 2 + 1 + 1 + 4 + 1 + 1 + 2;
	}

	public override void MarshalAutoLengthSet(DataOutputStream dos)
	{
		base.Length = (ushort)GetMarshalledSize();
		Marshal(dos);
	}

	public override void Marshal(DataOutputStream dos)
	{
		base.Marshal(dos);
		if (dos != null)
		{
			try
			{
				simulationAddress_0.Marshal(dos);
				dos.WriteInt(int_0);
				dos.WriteShort(short_0);
				dos.WriteUnsignedByte(byte_6);
				dos.WriteUnsignedByte(byte_7);
				dos.WriteUnsignedInt(uint_1);
				dos.WriteUnsignedByte(byte_8);
				dos.WriteByte(ikvYjQajqPK);
				dos.WriteUnsignedShort(ushort_1);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Unmarshal(DataInputStream dis)
	{
		base.Unmarshal(dis);
		if (dis != null)
		{
			try
			{
				simulationAddress_0.Unmarshal(dis);
				int_0 = dis.ReadInt();
				short_0 = dis.ReadShort();
				byte_6 = dis.ReadUnsignedByte();
				byte_7 = dis.ReadUnsignedByte();
				uint_1 = dis.ReadUnsignedInt();
				byte_8 = dis.ReadUnsignedByte();
				ikvYjQajqPK = dis.ReadByte();
				ushort_1 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<AttributePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<originatingSimulationAddress>");
			simulationAddress_0.Reflection(sb);
			sb.AppendLine("</originatingSimulationAddress>");
			sb.AppendLine("<padding1 type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"short\">" + short_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<attributeRecordPduType type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</attributeRecordPduType>");
			sb.AppendLine("<attributeRecordProtocolVersion type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</attributeRecordProtocolVersion>");
			sb.AppendLine("<masterAttributeRecordType type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</masterAttributeRecordType>");
			sb.AppendLine("<actionCode type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</actionCode>");
			sb.AppendLine("<padding3 type=\"byte\">" + ikvYjQajqPK.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			sb.AppendLine("<numberAttributeRecordSet type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</numberAttributeRecordSet>");
			sb.AppendLine("</AttributePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AttributePdu;
	}

	public bool Equals(AttributePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((EntityInformationFamilyPdu)obj);
		if (!simulationAddress_0.Equals(obj.simulationAddress_0))
		{
			flag = false;
		}
		if (int_0 != obj.int_0)
		{
			flag = false;
		}
		if (short_0 != obj.short_0)
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
		if (byte_8 != obj.byte_8)
		{
			flag = false;
		}
		if (ikvYjQajqPK != obj.ikvYjQajqPK)
		{
			flag = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		return flag;
	}

	private static int smethod_3(int int_1)
	{
		int_1 <<= 5 + int_1;
		return int_1;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ simulationAddress_0.GetHashCode()) ^ int_0.GetHashCode()) ^ short_0.GetHashCode()) ^ byte_6.GetHashCode()) ^ byte_7.GetHashCode()) ^ uint_1.GetHashCode()) ^ byte_8.GetHashCode()) ^ ikvYjQajqPK.GetHashCode()) ^ ushort_1.GetHashCode();
	}

	static AttributePdu()
	{
		Class72.smethod_20();
	}
}
