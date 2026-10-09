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
[XmlInclude(typeof(EntityID))]
[XmlInclude(typeof(EightByteChunk))]
public class MinefieldResponseNackPdu : MinefieldFamilyPdu, IEquatable<MinefieldResponseNackPdu>
{
	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	private byte byte_4;

	private byte byte_5;

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
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "numberOfMissingPdus")]
	public byte NumberOfMissingPdus
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
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte((byte)list_0.Count);
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
			entityID_1.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			for (int i = 0; i < NumberOfMissingPdus; i++)
			{
				EightByteChunk eightByteChunk = new EightByteChunk();
				eightByteChunk.Unmarshal(dis);
				list_0.Add(eightByteChunk);
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
			sb.AppendLine("<requestID type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</requestID>");
			sb.AppendLine("<missingPduSequenceNumbers type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</missingPduSequenceNumbers>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<missingPduSequenceNumbers" + i.ToString(CultureInfo.InvariantCulture) + " type=\"EightByteChunk\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</missingPduSequenceNumbers" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</MinefieldResponseNackPdu>");
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
			if (byte_4 != obj.byte_4)
			{
				flag = false;
			}
			if (byte_5 != obj.byte_5)
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

	private static int smethod_1(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_1(0) ^ base.GetHashCode();
		num = smethod_1(num) ^ entityID_0.GetHashCode();
		num = smethod_1(num) ^ entityID_1.GetHashCode();
		num = smethod_1(num) ^ byte_4.GetHashCode();
		num = smethod_1(num) ^ byte_5.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_1(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static MinefieldResponseNackPdu()
	{
		Class72.smethod_20();
	}
}
