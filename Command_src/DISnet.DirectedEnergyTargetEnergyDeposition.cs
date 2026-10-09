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
[XmlInclude(typeof(EntityID))]
public class DirectedEnergyTargetEnergyDeposition
{
	private EntityID entityID_0 = new EntityID();

	private ushort ushort_0;

	private float float_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityID), ElementName = "targetEntityID")]
	public EntityID TargetEntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(float), ElementName = "peakIrradiance")]
	public float PeakIrradiance
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

	public static bool operator !=(DirectedEnergyTargetEnergyDeposition left, DirectedEnergyTargetEnergyDeposition right)
	{
		return !(left == right);
	}

	public static bool operator ==(DirectedEnergyTargetEnergyDeposition left, DirectedEnergyTargetEnergyDeposition right)
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
		return 0 + entityID_0.GetMarshalledSize() + 2 + 4;
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
				entityID_0.Marshal(dos);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteFloat(float_0);
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
				entityID_0.Unmarshal(dis);
				ushort_0 = dis.ReadUnsignedShort();
				float_0 = dis.ReadFloat();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<DirectedEnergyTargetEnergyDeposition>");
		try
		{
			sb.AppendLine("<targetEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</targetEntityID>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<peakIrradiance type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</peakIrradiance>");
			sb.AppendLine("</DirectedEnergyTargetEnergyDeposition>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyTargetEnergyDeposition;
	}

	public bool Equals(DirectedEnergyTargetEnergyDeposition obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (!entityID_0.Equals(obj.entityID_0))
			{
				result = false;
			}
			if (ushort_0 != obj.ushort_0)
			{
				result = false;
			}
			if (float_0 != obj.float_0)
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
		return smethod_0(smethod_0(smethod_0(0) ^ entityID_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ float_0.GetHashCode();
	}

	static DirectedEnergyTargetEnergyDeposition()
	{
		Class72.smethod_20();
	}
}
