using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
[XmlInclude(typeof(EightByteChunk))]
[XmlInclude(typeof(EntityID))]
public class MinefieldResponseNackPdu : MinefieldFamilyPdu, IEquatable<MinefieldResponseNackPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_6;

	private byte byte_7;

	private List<EightByteChunk> list_0 = new List<EightByteChunk>();

	[XmlElement(Type = typeof(EntityID), ElementName = "minefieldID")]
	public EntityID MinefieldID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "requestingEntityID")]
	public EntityID RequestingEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "requestID")]
	public byte RequestID
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfMissingPdus")]
	public byte NumberOfMissingPdus
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

	[XmlElement(ElementName = "missingPduSequenceNumbersList", Type = typeof(List<EightByteChunk>))]
	public List<EightByteChunk> MissingPduSequenceNumbers => list_0;

	public MinefieldResponseNackPdu()
	{
		base.PduType = 40;
	}

	public static bool operator !=(MinefieldResponseNackPdu left, MinefieldResponseNackPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(MinefieldResponseNackPdu left, MinefieldResponseNackPdu right)
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
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			EightByteChunk eightByteChunk = list_0[i];
			num += eightByteChunk.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
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
			entityID_0.Unmarshal(dis);
			entityID_1.Unmarshal(dis);
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			for (int i = 0; i < NumberOfMissingPdus; i++)
			{
				EightByteChunk eightByteChunk = new EightByteChunk();
				eightByteChunk.Unmarshal(dis);
				list_0.Add(eightByteChunk);
			}
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<MinefieldResponseNackPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<minefieldID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</minefieldID>");
			sb.AppendLine("<requestingEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</requestingEntityID>");
			sb.AppendLine("<requestID type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<missingPduSequenceNumbers type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</missingPduSequenceNumbers>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<missingPduSequenceNumbers" + i.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</missingPduSequenceNumbers" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</MinefieldResponseNackPdu>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as MinefieldResponseNackPdu;
	}

	public bool Equals(MinefieldResponseNackPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((MinefieldFamilyPdu)obj);
			if (!entityID_0.Equals(obj.entityID_0))
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
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

	private static int smethod_3(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_3(0) ^ base.GetHashCode();
		num = smethod_3(num) ^ entityID_0.GetHashCode();
		num = smethod_3(num) ^ entityID_1.GetHashCode();
		num = smethod_3(num) ^ byte_6.GetHashCode();
		num = smethod_3(num) ^ byte_7.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_3(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static MinefieldResponseNackPdu()
	{
		Class72.smethod_20();
	}
}
