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
[XmlInclude(typeof(IntercomCommunicationsParameters))]
public class IntercomControlPdu : RadioCommunicationsFamilyPdu, IEquatable<IntercomControlPdu>
{
	private byte byte_4;

	private byte MctYsYkZbl1;

	private EntityID entityID_1 = new EntityID();

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private byte byte_8;

	private byte byte_9;

	private EntityID entityID_2 = new EntityID();

	private ushort ushort_2;

	private uint uint_1;

	private List<IntercomCommunicationsParameters> list_0 = new List<IntercomCommunicationsParameters>();

	[XmlElement(Type = typeof(byte), ElementName = "controlType")]
	public byte ControlType
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

	[XmlElement(Type = typeof(byte), ElementName = "communicationsChannelType")]
	public byte CommunicationsChannelType
	{
		get
		{
			return MctYsYkZbl1;
		}
		set
		{
			MctYsYkZbl1 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "sourceEntityID")]
	public EntityID SourceEntityID
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

	[XmlElement(Type = typeof(byte), ElementName = "sourceCommunicationsDeviceID")]
	public byte SourceCommunicationsDeviceID
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

	[XmlElement(Type = typeof(byte), ElementName = "sourceLineID")]
	public byte SourceLineID
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

	[XmlElement(Type = typeof(byte), ElementName = "transmitPriority")]
	public byte TransmitPriority
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

	[XmlElement(Type = typeof(byte), ElementName = "transmitLineState")]
	public byte TransmitLineState
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

	[XmlElement(Type = typeof(byte), ElementName = "command")]
	public byte Command
	{
		get
		{
			return byte_9;
		}
		set
		{
			byte_9 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "masterEntityID")]
	public EntityID MasterEntityID
	{
		get
		{
			return entityID_2;
		}
		set
		{
			entityID_2 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "masterCommunicationsDeviceID")]
	public ushort MasterCommunicationsDeviceID
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

	[XmlElement(Type = typeof(uint), ElementName = "intercomParametersLength")]
	public uint IntercomParametersLength
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

	[XmlElement(ElementName = "intercomParametersList", Type = typeof(List<IntercomCommunicationsParameters>))]
	public List<IntercomCommunicationsParameters> IntercomParameters => list_0;

	public IntercomControlPdu()
	{
		base.PduType = 32;
	}

	public static bool operator !=(IntercomControlPdu left, IntercomControlPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(IntercomControlPdu left, IntercomControlPdu right)
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
		num++;
		num++;
		num += entityID_1.GetMarshalledSize();
		num++;
		num++;
		num++;
		num++;
		num++;
		num += entityID_2.GetMarshalledSize();
		num += 2;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			IntercomCommunicationsParameters intercomCommunicationsParameters = list_0[i];
			num += intercomCommunicationsParameters.GetMarshalledSize();
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
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(MctYsYkZbl1);
			entityID_1.Marshal(dos);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte(byte_7);
			dos.WriteUnsignedByte(byte_8);
			dos.WriteUnsignedByte(byte_9);
			entityID_2.Marshal(dos);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedInt((uint)list_0.Count);
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
			byte_4 = dis.ReadUnsignedByte();
			MctYsYkZbl1 = dis.ReadUnsignedByte();
			entityID_1.Unmarshal(dis);
			byte_5 = dis.ReadUnsignedByte();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			entityID_2.Unmarshal(dis);
			ushort_2 = dis.ReadUnsignedShort();
			uint_1 = dis.ReadUnsignedInt();
			for (int i = 0; i < IntercomParametersLength; i++)
			{
				IntercomCommunicationsParameters intercomCommunicationsParameters = new IntercomCommunicationsParameters();
				intercomCommunicationsParameters.Unmarshal(dis);
				list_0.Add(intercomCommunicationsParameters);
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
		sb.AppendLine("<IntercomControlPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<controlType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</controlType>");
			sb.AppendLine("<communicationsChannelType type=\"byte\">" + MctYsYkZbl1.ToString(CultureInfo.InvariantCulture) + "</communicationsChannelType>");
			sb.AppendLine("<sourceEntityID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</sourceEntityID>");
			sb.AppendLine("<sourceCommunicationsDeviceID type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</sourceCommunicationsDeviceID>");
			sb.AppendLine("<sourceLineID type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</sourceLineID>");
			sb.AppendLine("<transmitPriority type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</transmitPriority>");
			sb.AppendLine("<transmitLineState type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</transmitLineState>");
			sb.AppendLine("<command type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</command>");
			sb.AppendLine("<masterEntityID>");
			entityID_2.Reflection(sb);
			sb.AppendLine("</masterEntityID>");
			sb.AppendLine("<masterCommunicationsDeviceID type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</masterCommunicationsDeviceID>");
			sb.AppendLine("<intercomParameters type=\"uint\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</intercomParameters>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<intercomParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"IntercomCommunicationsParameters\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</intercomParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</IntercomControlPdu>");
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
		return this == obj as IntercomControlPdu;
	}

	public bool Equals(IntercomControlPdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((RadioCommunicationsFamilyPdu)obj);
			if (byte_4 != obj.byte_4)
			{
				flag = false;
			}
			if (MctYsYkZbl1 != obj.MctYsYkZbl1)
			{
				flag = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
			{
				flag = false;
			}
			if (byte_5 != obj.byte_5)
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
			if (byte_8 != obj.byte_8)
			{
				flag = false;
			}
			if (byte_9 != obj.byte_9)
			{
				flag = false;
			}
			if (!entityID_2.Equals(obj.entityID_2))
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
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ MctYsYkZbl1.GetHashCode();
		num = smethod_2(num) ^ entityID_1.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ byte_9.GetHashCode();
		num = smethod_2(num) ^ entityID_2.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ uint_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		return num;
	}

	static IntercomControlPdu()
	{
		Class72.smethod_20();
	}
}
