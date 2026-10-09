using System;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
[XmlInclude(typeof(OneByteChunk))]
public class IntercomSignalPdu : RadioCommunicationsFamilyPdu, IEquatable<IntercomSignalPdu>
{
	private EntityID entityID_1 = new EntityID();

	private ushort vWxYptfiIfm;

	private ushort ushort_2;

	private ushort ushort_3;

	private uint uint_1;

	private ushort ushort_4;

	private ushort ushort_5;

	private byte[] byte_6;

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "communicationsDeviceID")]
	public ushort CommunicationsDeviceID
	{
		get
		{
			return vWxYptfiIfm;
		}
		set
		{
			vWxYptfiIfm = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "encodingScheme")]
	public ushort EncodingScheme
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

	[XmlElement(Type = typeof(ushort), ElementName = "tdlType")]
	public ushort TdlType
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

	[XmlElement(Type = typeof(uint), ElementName = "sampleRate")]
	public uint SampleRate
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

	[XmlElement(Type = typeof(ushort), ElementName = "dataLength")]
	public ushort DataLength
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

	[XmlElement(Type = typeof(ushort), ElementName = "samples")]
	public ushort Samples
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

	[XmlElement(ElementName = "dataList", DataType = "hexBinary")]
	public byte[] Data
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

	public IntercomSignalPdu()
	{
		base.PduType = 31;
	}

	public static bool operator !=(IntercomSignalPdu left, IntercomSignalPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(IntercomSignalPdu left, IntercomSignalPdu right)
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
		return base.GetMarshalledSize() + entityID_1.GetMarshalledSize() + 2 + 2 + 2 + 4 + 2 + 2 + byte_6.Length;
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
				entityID_1.Marshal(dos);
				dos.WriteUnsignedShort(vWxYptfiIfm);
				dos.WriteUnsignedShort(ushort_2);
				dos.WriteUnsignedShort(ushort_3);
				dos.WriteUnsignedInt(uint_1);
				dos.WriteUnsignedShort((ushort)byte_6.Length);
				dos.WriteUnsignedShort(ushort_5);
				dos.WriteByte(byte_6);
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
				entityID_1.Unmarshal(dis);
				vWxYptfiIfm = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
				ushort_3 = dis.ReadUnsignedShort();
				uint_1 = dis.ReadUnsignedInt();
				ushort_4 = dis.ReadUnsignedShort();
				ushort_5 = dis.ReadUnsignedShort();
				byte_6 = dis.ReadByteArray(ushort_4);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<IntercomSignalPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<entityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</entityID>");
			sb.AppendLine("<communicationsDeviceID type=\"ushort\">" + vWxYptfiIfm.ToString(CultureInfo.InvariantCulture) + "</communicationsDeviceID>");
			sb.AppendLine("<encodingScheme type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</encodingScheme>");
			sb.AppendLine("<tdlType type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</tdlType>");
			sb.AppendLine("<sampleRate type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</sampleRate>");
			sb.AppendLine("<data type=\"ushort\">" + byte_6.Length.ToString(CultureInfo.InvariantCulture) + "</data>");
			sb.AppendLine("<samples type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</samples>");
			sb.AppendLine("<data type=\"byte[]\">");
			byte[] array = byte_6;
			foreach (byte b in array)
			{
				sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
			}
			sb.AppendLine("</data>");
			sb.AppendLine("</IntercomSignalPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IntercomSignalPdu;
	}

	public bool Equals(IntercomSignalPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((RadioCommunicationsFamilyPdu)obj);
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (vWxYptfiIfm != obj.vWxYptfiIfm)
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
			if (uint_1 != obj.uint_1)
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
			if (!byte_6.Equals(obj.byte_6))
			{
				flag = false;
			}
			return flag;
		}
		return false;
	}

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_1.GetHashCode();
		num = smethod_3(num) ^ vWxYptfiIfm.GetHashCode();
		num = smethod_3(num) ^ ushort_2.GetHashCode();
		num = smethod_3(num) ^ ushort_3.GetHashCode();
		num = smethod_3(num) ^ uint_1.GetHashCode();
		num = smethod_3(num) ^ ushort_4.GetHashCode();
		num = smethod_3(num) ^ ushort_5.GetHashCode();
		if (byte_6.Length != 0)
		{
			for (int i = 0; i < byte_6.Length; i++)
			{
				num = smethod_3(num) ^ byte_6[i].GetHashCode();
			}
		}
		return num;
	}

	static IntercomSignalPdu()
	{
		Class72.smethod_20();
	}
}
