using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlRoot]
public class AngleDeception
{
	private uint uint_0 = 3501u;

	private ushort ushort_0 = 48;

	private ushort ushort_1;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private uint uint_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	private float float_4;

	private float float_5;

	private float float_6;

	private float float_7;

	private uint uint_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "recordType")]
	public uint RecordType
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "recordLength")]
	public ushort RecordLength
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(byte), ElementName = "emitterNumber")]
	public byte EmitterNumber
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "beamNumber")]
	public byte BeamNumber
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "stateIndicator")]
	public byte StateIndicator
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthOffset")]
	public float AzimuthOffset
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthWidth")]
	public float AzimuthWidth
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthPullRate")]
	public float AzimuthPullRate
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthPullAcceleration")]
	public float AzimuthPullAcceleration
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

	[XmlElement(Type = typeof(float), ElementName = "elevationOffset")]
	public float ElevationOffset
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

	[XmlElement(Type = typeof(float), ElementName = "elevationWidth")]
	public float ElevationWidth
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

	[XmlElement(Type = typeof(float), ElementName = "elevationPullRate")]
	public float ElevationPullRate
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

	[XmlElement(Type = typeof(float), ElementName = "elevationPullAcceleration")]
	public float ElevationPullAcceleration
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

	[XmlElement(Type = typeof(uint), ElementName = "padding3")]
	public uint Padding3
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = action_0;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(AngleDeception left, AngleDeception right)
	{
		return !(left == right);
	}

	public static bool operator ==(AngleDeception left, AngleDeception right)
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

	public virtual int GetMarshalledSize()
	{
		return 51;
	}

	protected void OnException(Exception e)
	{
		if (action_0 != null)
		{
			action_0(e);
		}
	}

	public virtual void Marshal(DataOutputStream dos)
	{
		if (dos != null)
		{
			try
			{
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedInt(uint_1);
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				dos.WriteFloat(float_2);
				dos.WriteFloat(float_3);
				dos.WriteFloat(float_4);
				dos.WriteFloat(float_5);
				dos.WriteFloat(float_6);
				dos.WriteFloat(float_7);
				dos.WriteUnsignedInt(uint_2);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Unmarshal(DataInputStream dis)
	{
		if (dis != null)
		{
			try
			{
				uint_0 = dis.ReadUnsignedInt();
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				uint_1 = dis.ReadUnsignedInt();
				float_0 = dis.ReadFloat();
				float_1 = dis.ReadFloat();
				float_2 = dis.ReadFloat();
				float_3 = dis.ReadFloat();
				float_4 = dis.ReadFloat();
				float_5 = dis.ReadFloat();
				float_6 = dis.ReadFloat();
				float_7 = dis.ReadFloat();
				uint_2 = dis.ReadUnsignedInt();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<AngleDeception>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<emitterNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
			sb.AppendLine("<beamNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
			sb.AppendLine("<stateIndicator type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
			sb.AppendLine("<padding2 type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<azimuthOffset type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</azimuthOffset>");
			sb.AppendLine("<azimuthWidth type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</azimuthWidth>");
			sb.AppendLine("<azimuthPullRate type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</azimuthPullRate>");
			sb.AppendLine("<azimuthPullAcceleration type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</azimuthPullAcceleration>");
			sb.AppendLine("<elevationOffset type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</elevationOffset>");
			sb.AppendLine("<elevationWidth type=\"float\">" + float_5.ToString(CultureInfo.InvariantCulture) + "</elevationWidth>");
			sb.AppendLine("<elevationPullRate type=\"float\">" + float_6.ToString(CultureInfo.InvariantCulture) + "</elevationPullRate>");
			sb.AppendLine("<elevationPullAcceleration type=\"float\">" + float_7.ToString(CultureInfo.InvariantCulture) + "</elevationPullAcceleration>");
			sb.AppendLine("<padding3 type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			sb.AppendLine("</AngleDeception>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as AngleDeception;
	}

	public bool Equals(AngleDeception obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (uint_0 != obj.uint_0)
			{
				result = false;
			}
			if (ushort_0 != obj.ushort_0)
			{
				result = false;
			}
			if (ushort_1 != obj.ushort_1)
			{
				result = false;
			}
			if (byte_0 != obj.byte_0)
			{
				result = false;
			}
			if (byte_1 != obj.byte_1)
			{
				result = false;
			}
			if (byte_2 != obj.byte_2)
			{
				result = false;
			}
			if (uint_1 != obj.uint_1)
			{
				result = false;
			}
			if (float_0 != obj.float_0)
			{
				result = false;
			}
			if (float_1 != obj.float_1)
			{
				result = false;
			}
			if (float_2 != obj.float_2)
			{
				result = false;
			}
			if (float_3 != obj.float_3)
			{
				result = false;
			}
			if (float_4 != obj.float_4)
			{
				result = false;
			}
			if (float_5 != obj.float_5)
			{
				result = false;
			}
			if (float_6 != obj.float_6)
			{
				result = false;
			}
			if (float_7 != obj.float_7)
			{
				result = false;
			}
			if (uint_2 != obj.uint_2)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ uint_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ float_5.GetHashCode()) ^ float_6.GetHashCode()) ^ float_7.GetHashCode()) ^ uint_2.GetHashCode();
	}

	static AngleDeception()
	{
		Class72.smethod_20();
	}
}
