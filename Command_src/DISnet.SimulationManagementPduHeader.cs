using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(PduHeader))]
[XmlRoot]
[XmlInclude(typeof(EntityID))]
public class SimulationManagementPduHeader
{
	private PduHeader pduHeader_0 = new PduHeader();

	private EntityID entityID_0 = new EntityID();

	private EntityID entityID_1 = new EntityID();

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(PduHeader), ElementName = "pduHeader")]
	public PduHeader PduHeader
	{
		get
		{
			return pduHeader_0;
		}
		set
		{
			pduHeader_0 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "originatingID")]
	public EntityID OriginatingID
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

	[XmlElement(Type = typeof(EntityID), ElementName = "recevingID")]
	public EntityID RecevingID
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

	public static bool operator !=(SimulationManagementPduHeader left, SimulationManagementPduHeader right)
	{
		return !(left == right);
	}

	public static bool operator ==(SimulationManagementPduHeader left, SimulationManagementPduHeader right)
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
		return 0 + pduHeader_0.GetMarshalledSize() + entityID_0.GetMarshalledSize() + entityID_1.GetMarshalledSize();
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
				pduHeader_0.Marshal(dos);
				entityID_0.Marshal(dos);
				entityID_1.Marshal(dos);
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
				pduHeader_0.Unmarshal(dis);
				entityID_0.Unmarshal(dis);
				entityID_1.Unmarshal(dis);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<SimulationManagementPduHeader>");
		try
		{
			sb.AppendLine("<pduHeader>");
			pduHeader_0.Reflection(sb);
			sb.AppendLine("</pduHeader>");
			sb.AppendLine("<originatingID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</originatingID>");
			sb.AppendLine("<recevingID>");
			entityID_1.Reflection(sb);
			sb.AppendLine("</recevingID>");
			sb.AppendLine("</SimulationManagementPduHeader>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as SimulationManagementPduHeader;
	}

	public bool Equals(SimulationManagementPduHeader obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (!pduHeader_0.Equals(obj.pduHeader_0))
			{
				result = false;
			}
			if (!entityID_0.Equals(obj.entityID_0))
			{
				result = false;
			}
			if (!entityID_1.Equals(obj.entityID_1))
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
		return smethod_0(smethod_0(smethod_0(0) ^ pduHeader_0.GetHashCode()) ^ entityID_0.GetHashCode()) ^ entityID_1.GetHashCode();
	}

	static SimulationManagementPduHeader()
	{
		Class72.smethod_20();
	}
}
