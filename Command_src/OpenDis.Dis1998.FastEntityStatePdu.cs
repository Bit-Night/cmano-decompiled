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
[XmlInclude(typeof(ArticulationParameter))]
[XmlRoot]
public class FastEntityStatePdu : EntityInformationFamilyPdu, IEquatable<FastEntityStatePdu>
{
	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private ushort ushort_4;

	private byte byte_8;

	private byte byte_9;

	private byte byte_10;

	private byte byte_11;

	private byte byte_12;

	private byte byte_13;

	private ushort ushort_5;

	private byte byte_14;

	private byte byte_15;

	private byte byte_16;

	private byte byte_17;

	private float float_0;

	private float float_1;

	private float float_2;

	private double double_0;

	private double double_1;

	private double double_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private int int_0;

	private byte byte_18;

	private byte[] byte_19 = new byte[15];

	private float float_6;

	private float float_7;

	private float float_8;

	private float float_9;

	private float float_10;

	private float float_11;

	private byte[] byte_20 = new byte[12];

	private int int_1;

	private List<ArticulationParameter> list_0 = new List<ArticulationParameter>();

	[XmlElement(Type = typeof(ushort), ElementName = "site")]
	public ushort Site
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

	[XmlElement(Type = typeof(ushort), ElementName = "application")]
	public ushort Application
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

	[XmlElement(Type = typeof(ushort), ElementName = "entity")]
	public ushort Entity
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

	[XmlElement(Type = typeof(byte), ElementName = "forceId")]
	public byte ForceId
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

	[XmlElement(Type = typeof(byte), ElementName = "numberOfArticulationParameters")]
	public byte NumberOfArticulationParameters
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

	[XmlElement(Type = typeof(byte), ElementName = "entityKind")]
	public byte EntityKind
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

	[XmlElement(Type = typeof(byte), ElementName = "domain")]
	public byte Domain
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

	[XmlElement(Type = typeof(ushort), ElementName = "country")]
	public ushort Country
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

	[XmlElement(Type = typeof(byte), ElementName = "category")]
	public byte Category
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

	[XmlElement(Type = typeof(byte), ElementName = "subcategory")]
	public byte Subcategory
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

	[XmlElement(Type = typeof(byte), ElementName = "specific")]
	public byte Specific
	{
		get
		{
			return byte_10;
		}
		set
		{
			byte_10 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "extra")]
	public byte Extra
	{
		get
		{
			return byte_11;
		}
		set
		{
			byte_11 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altEntityKind")]
	public byte AltEntityKind
	{
		get
		{
			return byte_12;
		}
		set
		{
			byte_12 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altDomain")]
	public byte AltDomain
	{
		get
		{
			return byte_13;
		}
		set
		{
			byte_13 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "altCountry")]
	public ushort AltCountry
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

	[XmlElement(Type = typeof(byte), ElementName = "altCategory")]
	public byte AltCategory
	{
		get
		{
			return byte_14;
		}
		set
		{
			byte_14 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altSubcategory")]
	public byte AltSubcategory
	{
		get
		{
			return byte_15;
		}
		set
		{
			byte_15 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altSpecific")]
	public byte AltSpecific
	{
		get
		{
			return byte_16;
		}
		set
		{
			byte_16 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "altExtra")]
	public byte AltExtra
	{
		get
		{
			return byte_17;
		}
		set
		{
			byte_17 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "xVelocity")]
	public float XVelocity
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

	[XmlElement(Type = typeof(float), ElementName = "yVelocity")]
	public float YVelocity
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

	[XmlElement(Type = typeof(float), ElementName = "zVelocity")]
	public float ZVelocity
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

	[XmlElement(Type = typeof(double), ElementName = "xLocation")]
	public double XLocation
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

	[XmlElement(Type = typeof(double), ElementName = "yLocation")]
	public double YLocation
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

	[XmlElement(Type = typeof(double), ElementName = "zLocation")]
	public double ZLocation
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "psi")]
	public float Psi
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

	[XmlElement(Type = typeof(float), ElementName = "theta")]
	public float Theta
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

	[XmlElement(Type = typeof(float), ElementName = "phi")]
	public float Phi
	{
		get
		{
			return float_5;
		}
		set
		{
			float_5 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "entityAppearance")]
	public int EntityAppearance
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

	[XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
	public byte DeadReckoningAlgorithm
	{
		get
		{
			return byte_18;
		}
		set
		{
			byte_18 = value;
		}
	}

	[XmlArray(ElementName = "otherParameters")]
	public byte[] OtherParameters
	{
		get
		{
			return byte_19;
		}
		set
		{
			byte_19 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "xAcceleration")]
	public float XAcceleration
	{
		get
		{
			return float_6;
		}
		set
		{
			float_6 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "yAcceleration")]
	public float YAcceleration
	{
		get
		{
			return float_7;
		}
		set
		{
			float_7 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "zAcceleration")]
	public float ZAcceleration
	{
		get
		{
			return float_8;
		}
		set
		{
			float_8 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "xAngularVelocity")]
	public float XAngularVelocity
	{
		get
		{
			return float_9;
		}
		set
		{
			float_9 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "yAngularVelocity")]
	public float YAngularVelocity
	{
		get
		{
			return float_10;
		}
		set
		{
			float_10 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "zAngularVelocity")]
	public float ZAngularVelocity
	{
		get
		{
			return float_11;
		}
		set
		{
			float_11 = value;
		}
	}

	[XmlArray(ElementName = "marking")]
	public byte[] Marking
	{
		get
		{
			return byte_20;
		}
		set
		{
			byte_20 = value;
		}
	}

	[XmlElement(Type = typeof(int), ElementName = "capabilities")]
	public int Capabilities
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

	[XmlElement(ElementName = "articulationParametersList", Type = typeof(List<ArticulationParameter>))]
	public List<ArticulationParameter> ArticulationParameters => list_0;

	public FastEntityStatePdu()
	{
		base.PduType = 1;
	}

	public static bool operator !=(FastEntityStatePdu left, FastEntityStatePdu right)
	{
		return !(left == right);
	}

	public static bool operator ==(FastEntityStatePdu left, FastEntityStatePdu right)
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
		num += 2;
		num += 2;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num++;
		num++;
		num += 2;
		num++;
		num++;
		num++;
		num++;
		num += 4;
		num += 4;
		num += 4;
		num += 8;
		num += 8;
		num += 8;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num++;
		num += 15;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 4;
		num += 12;
		num += 4;
		for (int i = 0; i < list_0.Count; i++)
		{
			ArticulationParameter articulationParameter = list_0[i];
			num += articulationParameter.GetMarshalledSize();
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
			dos.WriteUnsignedShort(ushort_1);
			dos.WriteUnsignedShort(ushort_2);
			dos.WriteUnsignedShort(ushort_3);
			dos.WriteUnsignedByte(byte_4);
			dos.WriteByte((byte)list_0.Count);
			dos.WriteUnsignedByte(byte_6);
			dos.WriteUnsignedByte(byte_7);
			dos.WriteUnsignedShort(ushort_4);
			dos.WriteUnsignedByte(byte_8);
			dos.WriteUnsignedByte(byte_9);
			dos.WriteUnsignedByte(byte_10);
			dos.WriteUnsignedByte(byte_11);
			dos.WriteUnsignedByte(byte_12);
			dos.WriteUnsignedByte(byte_13);
			dos.WriteUnsignedShort(ushort_5);
			dos.WriteUnsignedByte(byte_14);
			dos.WriteUnsignedByte(byte_15);
			dos.WriteUnsignedByte(byte_16);
			dos.WriteUnsignedByte(byte_17);
			dos.WriteFloat(float_0);
			dos.WriteFloat(float_1);
			dos.WriteFloat(float_2);
			dos.WriteDouble(double_0);
			dos.WriteDouble(double_1);
			dos.WriteDouble(double_2);
			dos.WriteFloat(float_3);
			dos.WriteFloat(float_4);
			dos.WriteFloat(float_5);
			dos.WriteInt(int_0);
			dos.WriteUnsignedByte(byte_18);
			for (int i = 0; i < byte_19.Length; i++)
			{
				dos.WriteByte(byte_19[i]);
			}
			dos.WriteFloat(float_6);
			dos.WriteFloat(float_7);
			dos.WriteFloat(float_8);
			dos.WriteFloat(float_9);
			dos.WriteFloat(float_10);
			dos.WriteFloat(float_11);
			for (int j = 0; j < byte_20.Length; j++)
			{
				dos.WriteByte(byte_20[j]);
			}
			dos.WriteInt(int_1);
			for (int k = 0; k < list_0.Count; k++)
			{
				list_0[k].Marshal(dos);
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
			ushort_1 = dis.ReadUnsignedShort();
			ushort_2 = dis.ReadUnsignedShort();
			ushort_3 = dis.ReadUnsignedShort();
			byte_4 = dis.ReadUnsignedByte();
			byte_5 = dis.ReadByte();
			byte_6 = dis.ReadUnsignedByte();
			byte_7 = dis.ReadUnsignedByte();
			ushort_4 = dis.ReadUnsignedShort();
			byte_8 = dis.ReadUnsignedByte();
			byte_9 = dis.ReadUnsignedByte();
			byte_10 = dis.ReadUnsignedByte();
			byte_11 = dis.ReadUnsignedByte();
			byte_12 = dis.ReadUnsignedByte();
			byte_13 = dis.ReadUnsignedByte();
			ushort_5 = dis.ReadUnsignedShort();
			byte_14 = dis.ReadUnsignedByte();
			byte_15 = dis.ReadUnsignedByte();
			byte_16 = dis.ReadUnsignedByte();
			byte_17 = dis.ReadUnsignedByte();
			float_0 = dis.ReadFloat();
			float_1 = dis.ReadFloat();
			float_2 = dis.ReadFloat();
			double_0 = dis.ReadDouble();
			double_1 = dis.ReadDouble();
			double_2 = dis.ReadDouble();
			float_3 = dis.ReadFloat();
			float_4 = dis.ReadFloat();
			float_5 = dis.ReadFloat();
			int_0 = dis.ReadInt();
			byte_18 = dis.ReadUnsignedByte();
			for (int i = 0; i < byte_19.Length; i++)
			{
				byte_19[i] = dis.ReadByte();
			}
			float_6 = dis.ReadFloat();
			float_7 = dis.ReadFloat();
			float_8 = dis.ReadFloat();
			float_9 = dis.ReadFloat();
			float_10 = dis.ReadFloat();
			float_11 = dis.ReadFloat();
			for (int j = 0; j < byte_20.Length; j++)
			{
				byte_20[j] = dis.ReadByte();
			}
			int_1 = dis.ReadInt();
			for (int k = 0; k < NumberOfArticulationParameters; k++)
			{
				ArticulationParameter articulationParameter = new ArticulationParameter();
				articulationParameter.Unmarshal(dis);
				list_0.Add(articulationParameter);
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
		sb.AppendLine("<FastEntityStatePdu>");
		base.Reflection(sb);
		try
		{
			sb.AppendLine("<site type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</site>");
			sb.AppendLine("<application type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</application>");
			sb.AppendLine("<entity type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</entity>");
			sb.AppendLine("<forceId type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</forceId>");
			sb.AppendLine("<articulationParameters type=\"byte\">" + list_0.Count.ToString(CultureInfo.InvariantCulture) + "</articulationParameters>");
			sb.AppendLine("<entityKind type=\"byte\">" + byte_6.ToString(CultureInfo.InvariantCulture) + "</entityKind>");
			sb.AppendLine("<domain type=\"byte\">" + byte_7.ToString(CultureInfo.InvariantCulture) + "</domain>");
			sb.AppendLine("<country type=\"ushort\">" + ushort_4.ToString(CultureInfo.InvariantCulture) + "</country>");
			sb.AppendLine("<category type=\"byte\">" + byte_8.ToString(CultureInfo.InvariantCulture) + "</category>");
			sb.AppendLine("<subcategory type=\"byte\">" + byte_9.ToString(CultureInfo.InvariantCulture) + "</subcategory>");
			sb.AppendLine("<specific type=\"byte\">" + byte_10.ToString(CultureInfo.InvariantCulture) + "</specific>");
			sb.AppendLine("<extra type=\"byte\">" + byte_11.ToString(CultureInfo.InvariantCulture) + "</extra>");
			sb.AppendLine("<altEntityKind type=\"byte\">" + byte_12.ToString(CultureInfo.InvariantCulture) + "</altEntityKind>");
			sb.AppendLine("<altDomain type=\"byte\">" + byte_13.ToString(CultureInfo.InvariantCulture) + "</altDomain>");
			sb.AppendLine("<altCountry type=\"ushort\">" + ushort_5.ToString(CultureInfo.InvariantCulture) + "</altCountry>");
			sb.AppendLine("<altCategory type=\"byte\">" + byte_14.ToString(CultureInfo.InvariantCulture) + "</altCategory>");
			sb.AppendLine("<altSubcategory type=\"byte\">" + byte_15.ToString(CultureInfo.InvariantCulture) + "</altSubcategory>");
			sb.AppendLine("<altSpecific type=\"byte\">" + byte_16.ToString(CultureInfo.InvariantCulture) + "</altSpecific>");
			sb.AppendLine("<altExtra type=\"byte\">" + byte_17.ToString(CultureInfo.InvariantCulture) + "</altExtra>");
			sb.AppendLine("<xVelocity type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</xVelocity>");
			sb.AppendLine("<yVelocity type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</yVelocity>");
			sb.AppendLine("<zVelocity type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</zVelocity>");
			sb.AppendLine("<xLocation type=\"double\">" + double_0.ToString(CultureInfo.InvariantCulture) + "</xLocation>");
			sb.AppendLine("<yLocation type=\"double\">" + double_1.ToString(CultureInfo.InvariantCulture) + "</yLocation>");
			sb.AppendLine("<zLocation type=\"double\">" + double_2.ToString(CultureInfo.InvariantCulture) + "</zLocation>");
			sb.AppendLine("<psi type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</psi>");
			sb.AppendLine("<theta type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</theta>");
			sb.AppendLine("<phi type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</phi>");
			sb.AppendLine("<entityAppearance type=\"int\">" + int_0.ToString(CultureInfo.InvariantCulture) + "</entityAppearance>");
			sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + byte_18.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
			for (int i = 0; i < byte_19.Length; i++)
			{
				sb.AppendLine("<otherParameters" + i.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_19[i] + "</otherParameters" + i.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<xAcceleration type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</xAcceleration>");
			sb.AppendLine("<yAcceleration type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</yAcceleration>");
			sb.AppendLine("<zAcceleration type=\"float\">" + float_8.ToString(CultureInfo.InvariantCulture) + "</zAcceleration>");
			sb.AppendLine("<xAngularVelocity type=\"float\">" + float_9.ToString(CultureInfo.InvariantCulture) + "</xAngularVelocity>");
			sb.AppendLine("<yAngularVelocity type=\"float\">" + float_10.ToString(CultureInfo.InvariantCulture) + "</yAngularVelocity>");
			sb.AppendLine("<zAngularVelocity type=\"float\">" + float_11.ToString(CultureInfo.InvariantCulture) + "</zAngularVelocity>");
			for (int j = 0; j < byte_20.Length; j++)
			{
				sb.AppendLine("<marking" + j.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + byte_20[j] + "</marking" + j.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("<capabilities type=\"int\">" + int_1.ToString(CultureInfo.InvariantCulture) + "</capabilities>");
			for (int k = 0; k < list_0.Count; k++)
			{
				sb.AppendLine("<articulationParameters" + k.ToString(CultureInfo.InvariantCulture) + " type=\"ArticulationParameter\">");
				list_0[k].Reflection(sb);
				sb.AppendLine("</articulationParameters" + k.ToString(CultureInfo.InvariantCulture) + ">");
			}
			sb.AppendLine("</FastEntityStatePdu>");
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
		return this == obj as FastEntityStatePdu;
	}

	public bool Equals(FastEntityStatePdu obj)
	{
		bool flag = true;
		if (!(obj.GetType() != GetType()))
		{
			flag = Equals((EntityInformationFamilyPdu)obj);
			if (ushort_1 != obj.ushort_1)
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
			if (byte_4 != obj.byte_4)
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
			if (ushort_4 != obj.ushort_4)
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
			if (byte_10 != obj.byte_10)
			{
				flag = false;
			}
			if (byte_11 != obj.byte_11)
			{
				flag = false;
			}
			if (byte_12 != obj.byte_12)
			{
				flag = false;
			}
			if (byte_13 != obj.byte_13)
			{
				flag = false;
			}
			if (ushort_5 != obj.ushort_5)
			{
				flag = false;
			}
			if (byte_14 != obj.byte_14)
			{
				flag = false;
			}
			if (byte_15 != obj.byte_15)
			{
				flag = false;
			}
			if (byte_16 != obj.byte_16)
			{
				flag = false;
			}
			if (byte_17 != obj.byte_17)
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
			if (float_2 != obj.float_2)
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
			if (double_2 != obj.double_2)
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
			if (float_5 != obj.float_5)
			{
				flag = false;
			}
			if (int_0 != obj.int_0)
			{
				flag = false;
			}
			if (byte_18 != obj.byte_18)
			{
				flag = false;
			}
			if (obj.byte_19.Length != 15)
			{
				flag = false;
			}
			if (flag)
			{
				for (int i = 0; i < 15; i++)
				{
					if (byte_19[i] != obj.byte_19[i])
					{
						flag = false;
					}
				}
			}
			if (float_6 != obj.float_6)
			{
				flag = false;
			}
			if (float_7 != obj.float_7)
			{
				flag = false;
			}
			if (float_8 != obj.float_8)
			{
				flag = false;
			}
			if (float_9 != obj.float_9)
			{
				flag = false;
			}
			if (float_10 != obj.float_10)
			{
				flag = false;
			}
			if (float_11 != obj.float_11)
			{
				flag = false;
			}
			if (obj.byte_20.Length != 12)
			{
				flag = false;
			}
			if (flag)
			{
				for (int j = 0; j < 12; j++)
				{
					if (byte_20[j] != obj.byte_20[j])
					{
						flag = false;
					}
				}
			}
			if (int_1 != obj.int_1)
			{
				flag = false;
			}
			if (list_0.Count != obj.list_0.Count)
			{
				flag = false;
			}
			if (flag)
			{
				for (int k = 0; k < list_0.Count; k++)
				{
					if (!list_0[k].Equals(obj.list_0[k]))
					{
						flag = false;
					}
				}
			}
			return flag;
		}
		return false;
	}

	private static int smethod_2(int int_2)
	{
		int_2 <<= 5 + int_2;
		return int_2;
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = smethod_2(0) ^ base.GetHashCode();
		num = smethod_2(num) ^ ushort_1.GetHashCode();
		num = smethod_2(num) ^ ushort_2.GetHashCode();
		num = smethod_2(num) ^ ushort_3.GetHashCode();
		num = smethod_2(num) ^ byte_4.GetHashCode();
		num = smethod_2(num) ^ byte_5.GetHashCode();
		num = smethod_2(num) ^ byte_6.GetHashCode();
		num = smethod_2(num) ^ byte_7.GetHashCode();
		num = smethod_2(num) ^ ushort_4.GetHashCode();
		num = smethod_2(num) ^ byte_8.GetHashCode();
		num = smethod_2(num) ^ byte_9.GetHashCode();
		num = smethod_2(num) ^ byte_10.GetHashCode();
		num = smethod_2(num) ^ byte_11.GetHashCode();
		num = smethod_2(num) ^ byte_12.GetHashCode();
		num = smethod_2(num) ^ byte_13.GetHashCode();
		num = smethod_2(num) ^ ushort_5.GetHashCode();
		num = smethod_2(num) ^ byte_14.GetHashCode();
		num = smethod_2(num) ^ byte_15.GetHashCode();
		num = smethod_2(num) ^ byte_16.GetHashCode();
		num = smethod_2(num) ^ byte_17.GetHashCode();
		num = smethod_2(num) ^ float_0.GetHashCode();
		num = smethod_2(num) ^ float_1.GetHashCode();
		num = smethod_2(num) ^ float_2.GetHashCode();
		num = smethod_2(num) ^ double_0.GetHashCode();
		num = smethod_2(num) ^ double_1.GetHashCode();
		num = smethod_2(num) ^ double_2.GetHashCode();
		num = smethod_2(num) ^ float_3.GetHashCode();
		num = smethod_2(num) ^ float_4.GetHashCode();
		num = smethod_2(num) ^ float_5.GetHashCode();
		num = smethod_2(num) ^ int_0.GetHashCode();
		num = smethod_2(num) ^ byte_18.GetHashCode();
		for (int i = 0; i < 15; i++)
		{
			num = smethod_2(num) ^ byte_19[i].GetHashCode();
		}
		num = smethod_2(num) ^ float_6.GetHashCode();
		num = smethod_2(num) ^ float_7.GetHashCode();
		num = smethod_2(num) ^ float_8.GetHashCode();
		num = smethod_2(num) ^ float_9.GetHashCode();
		num = smethod_2(num) ^ float_10.GetHashCode();
		num = smethod_2(num) ^ float_11.GetHashCode();
		for (int j = 0; j < 12; j++)
		{
			num = smethod_2(num) ^ byte_20[j].GetHashCode();
		}
		num = smethod_2(num) ^ int_1.GetHashCode();
		if (list_0.Count > 0)
		{
			for (int k = 0; k < list_0.Count; k++)
			{
				num = smethod_2(num) ^ list_0[k].GetHashCode();
			}
		}
		return num;
	}

	static FastEntityStatePdu()
	{
		Class72.smethod_20();
	}
}
