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
[XmlInclude(typeof(Vector3Double))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(ModulationType))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(Vector3Float))]
[XmlInclude(typeof(RadioEntityType))]
public class TransmitterPdu : RadioCommunicationsFamilyPdu, IEquatable<TransmitterPdu>
{
	private RadioEntityType radioEntityType_0 = new RadioEntityType();

	private byte byte_4;

	private byte byte_5;

	private ushort ushort_2;

	private Vector3Double vector3Double_0 = new Vector3Double();

	private Vector3Float vector3Float_0 = new Vector3Float();

	private ushort ushort_3;

	private ushort ushort_4;

	private ulong ulong_0;

	private float float_0;

	private float float_1;

	private ModulationType modulationType_0 = new ModulationType();

	private ushort ushort_5;

	private ushort ushort_6;

	private byte byte_6;

	private ushort ushort_7;

	private byte byte_7;

	private List<Vector3Float> list_0 = new List<Vector3Float>();

	private List<Vector3Float> list_1 = new List<Vector3Float>();

	[XmlElement(Type = typeof(RadioEntityType), ElementName = "radioEntityType")]
	public RadioEntityType RadioEntityType
	{
		get
		{
			return radioEntityType_0;
		}
		set
		{
			radioEntityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "transmitState")]
	public byte TransmitState
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

	[XmlElement(Type = typeof(byte), ElementName = "inputSource")]
	public byte InputSource
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding1")]
	public ushort Padding1
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "antennaLocation")]
	public Vector3Double AntennaLocation
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	[XmlElement(Type = typeof(Vector3Float), ElementName = "relativeAntennaLocation")]
	public Vector3Float RelativeAntennaLocation
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

	[XmlElement(Type = typeof(ushort), ElementName = "antennaPatternType")]
	public ushort AntennaPatternType
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

	[XmlElement(Type = typeof(ushort), ElementName = "antennaPatternCount")]
	public ushort AntennaPatternCount
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

	[XmlElement(Type = typeof(ulong), ElementName = "frequency")]
	public ulong Frequency
	{
		get
		{
			return ulong_0;
		}
		set
		{
			ulong_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "transmitFrequencyBandwidth")]
	public float TransmitFrequencyBandwidth
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

	[XmlElement(Type = typeof(float), ElementName = "power")]
	public float Power
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

	[XmlElement(Type = typeof(ModulationType), ElementName = "modulationType")]
	public ModulationType ModulationType
	{
		get
		{
			return modulationType_0;
		}
		set
		{
			modulationType_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "cryptoSystem")]
	public ushort CryptoSystem
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

	[XmlElement(Type = typeof(ushort), ElementName = "cryptoKeyId")]
	public ushort CryptoKeyId
	{
		get
		{
			return ushort_6;
		}
		set
		{
			ushort_6 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "modulationParameterCount")]
	public byte ModulationParameterCount
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
	{
		get
		{
			return ushort_7;
		}
		set
		{
			ushort_7 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding3")]
	public byte Padding3
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

	[XmlElement(ElementName = "modulationParametersListList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> ModulationParametersList => list_0;

	[XmlElement(ElementName = "antennaPatternListList", Type = typeof(List<Vector3Float>))]
	public List<Vector3Float> AntennaPatternList => list_1;

	public TransmitterPdu()
	{
		base.PduType = 25;
	}

	public static bool operator !=(TransmitterPdu left, TransmitterPdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(TransmitterPdu left, TransmitterPdu right)
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
		num += radioEntityType_0.GetMarshalledSize();
		num++;
		num++;
		num += 2;
		num += vector3Double_0.GetMarshalledSize();
		num += vector3Float_0.GetMarshalledSize();
		num += 2;
		num += 2;
		num += 8;
		num += 4;
		num += 4;
		num += modulationType_0.GetMarshalledSize();
		num += 2;
		num += 2;
		num++;
		num += 2;
		num++;
		for (int i = 0; i < list_0.Count; i++)
		{
			Vector3Float vector3Float = list_0[i];
			num += vector3Float.GetMarshalledSize();
		}
		for (int j = 0; j < list_1.Count; j++)
		{
			Vector3Float vector3Float2 = list_1[j];
			num += vector3Float2.GetMarshalledSize();
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
			radioEntityType_0.Marshal(dos);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteUnsignedByte(byte_5);
			dos.WriteUnsignedShort(ushort_2);
			vector3Double_0.Marshal(dos);
			vector3Float_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_3);
			dos.WriteUnsignedShort((ushort)list_1.Count);
			dos.WriteUnsignedLong(ulong_0);
			dos.WriteFloat(float_0);
			dos.WriteFloat(float_1);
			modulationType_0.Marshal(dos);
			dos.WriteUnsignedShort(ushort_5);
			dos.WriteUnsignedShort(ushort_6);
			dos.WriteUnsignedByte((byte)list_0.Count);
			dos.WriteUnsignedShort(ushort_7);
			dos.WriteUnsignedByte(byte_7);
			for (int i = 0; i < list_0.Count; i++)
			{
				list_0[i].Marshal(dos);
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				list_1[j].Marshal(dos);
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
			radioEntityType_0.Unmarshal(dis);
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadUnsignedByte();
			ushort_2 = dis.ReadUnsignedShort();
			vector3Double_0.Unmarshal(dis);
			vector3Float_0.Unmarshal(dis);
			ushort_3 = dis.ReadUnsignedShort();
			ushort_4 = dis.ReadUnsignedShort();
			ulong_0 = dis.ReadUnsignedLong();
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			modulationType_0.Unmarshal(dis);
			ushort_5 = dis.ReadUnsignedShort();
			ushort_6 = dis.ReadUnsignedShort();
			byte_6 = dis.ReadUnsignedByte();
			ushort_7 = dis.ReadUnsignedShort();
			byte_7 = dis.ReadUnsignedByte();
			for (int i = 0; i < ModulationParameterCount; i++)
			{
				Vector3Float vector3Float = new Vector3Float();
				vector3Float.Unmarshal(dis);
				list_0.Add(vector3Float);
			}
			for (int j = 0; j < AntennaPatternCount; j++)
			{
				Vector3Float vector3Float2 = new Vector3Float();
				vector3Float2.Unmarshal(dis);
				list_1.Add(vector3Float2);
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
		sb.AppendLine("<TransmitterPdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<radioEntityType>");
			radioEntityType_0.Reflection(sb);
			sb.AppendLine("</radioEntityType>");
			sb.AppendLine("<transmitState type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</transmitState>");
			sb.AppendLine("<inputSource type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</inputSource>");
			sb.AppendLine("<padding1 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<antennaLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</antennaLocation>");
			sb.AppendLine("<relativeAntennaLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</relativeAntennaLocation>");
			sb.AppendLine("<antennaPatternType type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</antennaPatternType>");
			sb.AppendLine("<antennaPatternList type=\"ushort\">" + list_1.Count.ToString(CultureInfo.InvariantCulture) + "</antennaPatternList>");
			sb.AppendLine("<frequency type=\"ulong\">" + ulong_0.ToString(CultureInfo.InvariantCulture) + "</frequency>");
			sb.AppendLine("<transmitFrequencyBandwidth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</transmitFrequencyBandwidth>");
			sb.AppendLine("<power type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</power>");
			sb.AppendLine("<modulationType>");
			modulationType_0.Reflection(sb);
			sb.AppendLine("</modulationType>");
			sb.AppendLine("<cryptoSystem type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</cryptoSystem>");
			sb.AppendLine("<cryptoKeyId type=\"ushort\">" + ushort_6.ToString(CultureInfo.InvariantCulture) + "</cryptoKeyId>");
			sb.AppendLine("<modulationParametersList type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</modulationParametersList>");
			sb.AppendLine("<padding2 type=\"ushort\">" + ushort_7.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<padding3 type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			for (int i = 0; i < list_0.Count; i++)
			{
				sb.AppendLine("<modulationParametersList" + i.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_0[i].Reflection(sb);
				sb.AppendLine("</modulationParametersList" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			for (int j = 0; j < list_1.Count; j++)
			{
				sb.AppendLine("<antennaPatternList" + j.ToString(CultureInfo.InvariantCulture) + " type=\"Vector3Float\">");
				list_1[j].Reflection(sb);
				sb.AppendLine("</antennaPatternList" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</TransmitterPdu>");
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
		return this == obj as TransmitterPdu;
	}

	public bool Equals(TransmitterPdu obj)
	{
		bool flag = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		flag = Equals((RadioCommunicationsFamilyPdu)obj);
		if (!radioEntityType_0.Equals(obj.radioEntityType_0))
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
		if (ushort_2 != obj.ushort_2)
		{
			flag = false;
		}
		if (!vector3Double_0.Equals(obj.vector3Double_0))
		{
			flag = false;
		}
		if (!vector3Float_0.Equals(obj.vector3Float_0))
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
		if (ulong_0 != obj.ulong_0)
		{
			flag = false;
		}
		if (float_0 != obj.float_0)
		{
			flag = false;
		}
		if (float_1 != obj.float_1)
		{
			flag = false;
		}
		if (!modulationType_0.Equals(obj.modulationType_0))
		{
			flag = false;
		}
		if (ushort_5 != obj.ushort_5)
		{
			flag = false;
		}
		if (ushort_6 != obj.ushort_6)
		{
			flag = false;
		}
		if (byte_6 != obj.byte_6)
		{
			flag = false;
		}
		if (ushort_7 != obj.ushort_7)
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
		if (list_1.Count != obj.list_1.Count)
		{
			flag = false;
		}
		if (flag)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				if (!list_1[j].Equals(obj.list_1[j]))
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
		num = smethod_2(num) ^ radioEntityType_0.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ vector3Double_0.GetHashCode();
		num = smethod_2(num) ^ vector3Float_0.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ ulong_0.GetHashCode();
		num = smethod_2(num) ^ float_0.GetHashCode();
		num = smethod_2(num) ^ float_1.GetHashCode();
		num = smethod_2(num) ^ modulationType_0.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		num = smethod_2(num) ^ ushort_6.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ ushort_7.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				num = smethod_2(num) ^ list_0[i].GetHashCode();
			}
		}
		if (list_1.Count > 0)
		{
			for (int j = 0; j < list_1.Count; j++)
			{
				num = smethod_2(num) ^ list_1[j].GetHashCode();
			}
		}
		return num;
	}

	static TransmitterPdu()
	{
		Class72.smethod_20();
	}
}
