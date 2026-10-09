using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(SimulationAddress))]
[XmlRoot]
public class EventIdentifier
{
	private SimulationAddress simulationAddress_0 = new SimulationAddress();

	private ushort ushort_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(SimulationAddress), ElementName = "simulationAddress")]
	public SimulationAddress SimulationAddress
	{
		get
		{
			return simulationAddress_0;
		}
		set
		{
			simulationAddress_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "eventNumber")]
	public ushort EventNumber
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

	public static bool operator !=(EventIdentifier left, EventIdentifier right)
	{
		return !(left == right);
	}

	public static bool operator ==(EventIdentifier left, EventIdentifier right)
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

	public virtual int GetMarshalledSize()
	{
		return 0 + simulationAddress_0.GetMarshalledSize() + 2;
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
				simulationAddress_0.Marshal(dos);
				dos.WriteUnsignedShort(ushort_0);
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
				simulationAddress_0.Unmarshal(dis);
				ushort_0 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EventIdentifier>");
		try
		{
			sb.AppendLine("<simulationAddress>");
			simulationAddress_0.Reflection(sb);
			sb.AppendLine("</simulationAddress>");
			sb.AppendLine("<eventNumber type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</eventNumber>");
			sb.AppendLine("</EventIdentifier>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EventIdentifier;
	}

	public bool Equals(EventIdentifier obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
		if (!simulationAddress_0.Equals(obj.simulationAddress_0))
		{
			result = false;
		}
		if (ushort_0 != obj.ushort_0)
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
		return smethod_0(smethod_0(0) ^ simulationAddress_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}

	static EventIdentifier()
	{
		Class72.smethod_20();
	}
}
