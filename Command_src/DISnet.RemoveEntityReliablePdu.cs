using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class RemoveEntityReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<RemoveEntityReliablePdu>
{
	private byte byte_6;

	private ushort ushort_1;

	private byte byte_7;

	private uint uint_1;

	[XmlElement(Type = typeof(byte), ElementName = "requiredReliabilityService")]
	public byte RequiredReliabilityService
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

	[XmlElement(Type = typeof(ushort), ElementName = "pad1")]
	public ushort Pad1
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

	[XmlElement(Type = typeof(byte), ElementName = "pad2")]
	public byte Pad2
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

	[XmlElement(Type = typeof(uint), ElementName = "requestID")]
	public uint RequestID
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

	public RemoveEntityReliablePdu()
	{
		base.PduType = 52;
	}

	public static bool operator !=(RemoveEntityReliablePdu left, RemoveEntityReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(RemoveEntityReliablePdu left, RemoveEntityReliablePdu right)
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
		return base.GetMarshalledSize() + 1 + 2 + 1 + 4;
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
				dos.WriteUnsignedByte(byte_6);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedByte(byte_7);
				dos.WriteUnsignedInt(uint_1);
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
				byte_6 = dis.ReadUnsignedByte();
				ushort_1 = dis.ReadUnsignedShort();
				byte_7 = dis.ReadUnsignedByte();
				uint_1 = dis.ReadUnsignedInt();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<RemoveEntityReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<requiredReliabilityService type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</requiredReliabilityService>");
			sb.AppendLine("<pad1 type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</pad1>");
			sb.AppendLine("<pad2 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</pad2>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</RemoveEntityReliablePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as RemoveEntityReliablePdu;
	}

	public bool Equals(RemoveEntityReliablePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((SimulationManagementWithReliabilityFamilyPdu)obj);
			if (byte_6 != obj.byte_6)
			{
				flag = false;
			}
			if (ushort_1 != obj.ushort_1)
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
			return flag;
		}
		return false;
	}

	private static int bUxYalFicla(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return bUxYalFicla(bUxYalFicla(bUxYalFicla(bUxYalFicla(bUxYalFicla(0) ^ base.GetHashCode()) ^ byte_6.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_7.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static RemoveEntityReliablePdu()
	{
		Class72.smethod_20();
	}
}
