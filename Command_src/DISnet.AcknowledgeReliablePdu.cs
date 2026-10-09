using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class AcknowledgeReliablePdu : SimulationManagementWithReliabilityFamilyPdu, IEquatable<AcknowledgeReliablePdu>
{
	private ushort ushort_1;

	private ushort ushort_2;

	private uint uint_1;

	[XmlElement(Type = typeof(ushort), ElementName = "acknowledgeFlag")]
	public ushort AcknowledgeFlag
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

	[XmlElement(Type = typeof(ushort), ElementName = "responseFlag")]
	public ushort ResponseFlag
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

	public AcknowledgeReliablePdu()
	{
		base.PduType = 55;
	}

	public static bool operator !=(AcknowledgeReliablePdu left, AcknowledgeReliablePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(AcknowledgeReliablePdu left, AcknowledgeReliablePdu right)
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
		return base.GetMarshalledSize() + 2 + 2 + 4;
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
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
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
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
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
		sb.AppendLine("<AcknowledgeReliablePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<acknowledgeFlag type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</acknowledgeFlag>");
			sb.AppendLine("<responseFlag type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</responseFlag>");
			sb.AppendLine("<requestID type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("</AcknowledgeReliablePdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AcknowledgeReliablePdu;
	}

	public bool Equals(AcknowledgeReliablePdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((SimulationManagementWithReliabilityFamilyPdu)obj);
		if (ushort_1 != obj.ushort_1)
		{
			flag = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (uint_1 != obj.uint_1)
		{
			flag = false;
		}
		return flag;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_3(smethod_3(smethod_3(smethod_3(0) ^ base.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ uint_1.GetHashCode();
	}

	static AcknowledgeReliablePdu()
	{
		Class72.smethod_20();
	}
}
