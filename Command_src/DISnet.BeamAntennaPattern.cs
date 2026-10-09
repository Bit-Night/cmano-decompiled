using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EulerAngles))]
[XmlRoot]
public class BeamAntennaPattern
{
	private EulerAngles eulerAngles_0 = new EulerAngles();

	private float nSdYjqMeyfs;

	private float float_0;

	private float float_1;

	private byte byte_0;

	private ushort ushort_0;

	private float float_2;

	private float float_3;

	private float float_4;

	private uint uint_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EulerAngles), ElementName = "beamDirection")]
	public EulerAngles BeamDirection
	{
		get
		{
			return eulerAngles_0;
		}
		set
		{
			eulerAngles_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "azimuthBeamwidth")]
	public float AzimuthBeamwidth
	{
		get
		{
			return nSdYjqMeyfs;
		}
		set
		{
			nSdYjqMeyfs = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "elevationBeamwidth")]
	public float ElevationBeamwidth
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

	[XmlElement(Type = typeof(float), ElementName = "referenceSystem")]
	public float ReferenceSystem
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

	[XmlElement(Type = typeof(byte), ElementName = "padding1")]
	public byte Padding1
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
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

	[XmlElement(Type = typeof(float), ElementName = "ez")]
	public float Ez
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

	[XmlElement(Type = typeof(float), ElementName = "ex")]
	public float Ex
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

	[XmlElement(Type = typeof(float), ElementName = "phase")]
	public float Phase
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

	[XmlElement(Type = typeof(uint), ElementName = "padding3")]
	public uint Padding3
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

	public static bool operator !=(BeamAntennaPattern left, BeamAntennaPattern right)
	{
		return !(left == right);
	}

	public static bool operator ==(BeamAntennaPattern left, BeamAntennaPattern right)
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
		return 0 + eulerAngles_0.GetMarshalledSize() + 4 + 4 + 4 + 1 + 2 + 4 + 4 + 4 + 4;
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
				eulerAngles_0.Marshal(dos);
				dos.WriteFloat(nSdYjqMeyfs);
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteFloat(float_2);
				dos.WriteFloat(float_3);
				dos.WriteFloat(float_4);
				dos.WriteUnsignedInt(uint_0);
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
				eulerAngles_0.Unmarshal(dis);
				nSdYjqMeyfs = dis.ReadFloat();
				float_0 = dis.ReadFloat();
				float_1 = dis.ReadFloat();
				byte_0 = dis.ReadUnsignedByte();
				ushort_0 = dis.ReadUnsignedShort();
				float_2 = dis.ReadFloat();
				float_3 = dis.ReadFloat();
				float_4 = dis.ReadFloat();
				uint_0 = dis.ReadUnsignedInt();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<BeamAntennaPattern>");
		try
		{
			sb.AppendLine("<beamDirection>");
			eulerAngles_0.Reflection(sb);
			sb.AppendLine("</beamDirection>");
			sb.AppendLine("<azimuthBeamwidth type=\"float\">" + nSdYjqMeyfs.ToString(CultureInfo.InvariantCulture) + "</azimuthBeamwidth>");
			sb.AppendLine("<elevationBeamwidth type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</elevationBeamwidth>");
			sb.AppendLine("<referenceSystem type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</referenceSystem>");
			sb.AppendLine("<padding1 type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</padding1>");
			sb.AppendLine("<padding2 type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("<ez type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</ez>");
			sb.AppendLine("<ex type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</ex>");
			sb.AppendLine("<phase type=\"float\">" + float_4.ToString(CultureInfo.InvariantCulture) + "</phase>");
			sb.AppendLine("<padding3 type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</padding3>");
			sb.AppendLine("</BeamAntennaPattern>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as BeamAntennaPattern;
	}

	public bool Equals(BeamAntennaPattern obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (!eulerAngles_0.Equals(obj.eulerAngles_0))
			{
				result = false;
			}
			if (nSdYjqMeyfs != obj.nSdYjqMeyfs)
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
			if (byte_0 != obj.byte_0)
			{
				result = false;
			}
			if (ushort_0 != obj.ushort_0)
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
			if (uint_0 != obj.uint_0)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ eulerAngles_0.GetHashCode()) ^ nSdYjqMeyfs.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode()) ^ float_4.GetHashCode()) ^ uint_0.GetHashCode();
	}

	static BeamAntennaPattern()
	{
		Class72.smethod_20();
	}
}
