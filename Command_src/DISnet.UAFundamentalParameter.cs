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
public class UAFundamentalParameter
{
	private ushort ushort_0;

	private ushort ushort_1;

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(ushort), ElementName = "activeEmissionParameterIndex")]
	public ushort ActiveEmissionParameterIndex
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

	[XmlElement(Type = typeof(ushort), ElementName = "scanPattern")]
	public ushort ScanPattern
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

	[XmlElement(Type = typeof(float), ElementName = "beamCenterAzimuthHorizontal")]
	public float BeamCenterAzimuthHorizontal
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

	[XmlElement(Type = typeof(float), ElementName = "azimuthalBeamwidthHorizontal")]
	public float AzimuthalBeamwidthHorizontal
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

	[XmlElement(Type = typeof(float), ElementName = "beamCenterDepressionElevation")]
	public float BeamCenterDepressionElevation
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

	[XmlElement(Type = typeof(float), ElementName = "beamwidthDownElevation")]
	public float BeamwidthDownElevation
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

	public static bool operator !=(UAFundamentalParameter left, UAFundamentalParameter right)
	{
		return !(left == right);
	}

	public static bool operator ==(UAFundamentalParameter left, UAFundamentalParameter right)
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
		return 20;
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
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
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
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
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
		sb.AppendLine("<UAFundamentalParameter>");
		try
		{
			sb.AppendLine("<activeEmissionParameterIndex type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</activeEmissionParameterIndex>");
			sb.AppendLine("<scanPattern type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</scanPattern>");
			sb.AppendLine("<beamCenterAzimuthHorizontal type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</beamCenterAzimuthHorizontal>");
			sb.AppendLine("<azimuthalBeamwidthHorizontal type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</azimuthalBeamwidthHorizontal>");
			sb.AppendLine("<beamCenterDepressionElevation type=\"float\">" + float_2.ToString(CultureInfo.InvariantCulture) + "</beamCenterDepressionElevation>");
			sb.AppendLine("<beamwidthDownElevation type=\"float\">" + float_3.ToString(CultureInfo.InvariantCulture) + "</beamwidthDownElevation>");
			sb.AppendLine("</UAFundamentalParameter>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as UAFundamentalParameter;
	}

	public bool Equals(UAFundamentalParameter obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (ushort_0 != obj.ushort_0)
		{
			result = false;
		}
		if (ushort_1 != obj.ushort_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ float_2.GetHashCode()) ^ float_3.GetHashCode();
	}

	static UAFundamentalParameter()
	{
		Class72.smethod_20();
	}
}
