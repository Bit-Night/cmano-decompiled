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
public class BlankingSector
{
	private uint uint_0 = 3500u;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private float eleYjTqZgCl;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

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

	[XmlElement(Type = typeof(float), ElementName = "leftAzimuth")]
	public float LeftAzimuth
	{
		get
		{
			return eleYjTqZgCl;
		}
		set
		{
			eleYjTqZgCl = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "rightAzimuth")]
	public float RightAzimuth
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

	[XmlElement(Type = typeof(float), ElementName = "lowerElevation")]
	public float LowerElevation
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

	[XmlElement(Type = typeof(float), ElementName = "upperElevation")]
	public float UpperElevation
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

	[XmlElement(Type = typeof(float), ElementName = "residualPower")]
	public float ResidualPower
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

	public static bool operator !=(BlankingSector left, BlankingSector right)
	{
		return !(left == right);
	}

	public static bool operator ==(BlankingSector left, BlankingSector right)
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

	public virtual int GetMarshalledSize()
	{
		return 29;
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteFloat(eleYjTqZgCl);
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				dos.WriteFloat(float_2);
				dos.WriteFloat(float_3);
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
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				eleYjTqZgCl = dis.ReadFloat();
				float_0 = dis.ReadFloat();
				float_1 = dis.ReadFloat();
				float_2 = dis.ReadFloat();
				float_3 = dis.ReadFloat();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<BlankingSector>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<emitterNumber type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</emitterNumber>");
			sb.AppendLine("<beamNumber type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</beamNumber>");
			sb.AppendLine("<stateIndicator type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</stateIndicator>");
			sb.AppendLine("<leftAzimuth type=\"float\">" + eleYjTqZgCl.ToString(CultureInfo.InvariantCulture) + "</leftAzimuth>");
			sb.AppendLine("<rightAzimuth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</rightAzimuth>");
			sb.AppendLine("<lowerElevation type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</lowerElevation>");
			sb.AppendLine("<upperElevation type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</upperElevation>");
			sb.AppendLine("<residualPower type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</residualPower>");
			sb.AppendLine("</BlankingSector>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as BlankingSector;
	}

	public bool Equals(BlankingSector obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (uint_0 != obj.uint_0)
		{
			result = false;
		}
		if (ushort_0 != obj.ushort_0)
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
		if (eleYjTqZgCl != obj.eleYjTqZgCl)
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
		return result;
	}

	private static int smethod_0(int int_0)
	{
		int_0 <<= 5 + int_0;
		return int_0;
	}

	public override int GetHashCode()
	{
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ eleYjTqZgCl.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode();
	}

	static BlankingSector()
	{
		Class72.smethod_20();
	}
}
