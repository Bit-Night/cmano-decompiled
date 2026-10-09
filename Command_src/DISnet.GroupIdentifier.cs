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
[XmlInclude(typeof(EntityType))]
public class GroupIdentifier
{
	private EntityType entityType_0 = new EntityType();

	private ushort ushort_0;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "simulationAddress")]
	public EntityType SimulationAddress
	{
		get
		{
			return entityType_0;
		}
		set
		{
			entityType_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "groupNumber")]
	public ushort GroupNumber
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

	public static bool operator !=(GroupIdentifier left, GroupIdentifier right)
	{
		return !(left == right);
	}

	public static bool operator ==(GroupIdentifier left, GroupIdentifier right)
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
		return 0 + entityType_0.GetMarshalledSize() + 2;
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
				entityType_0.Marshal(dos);
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
				entityType_0.Unmarshal(dis);
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
		sb.AppendLine("<GroupIdentifier>");
		try
		{
			sb.AppendLine("<simulationAddress>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</simulationAddress>");
			sb.AppendLine("<groupNumber type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</groupNumber>");
			sb.AppendLine("</GroupIdentifier>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as GroupIdentifier;
	}

	public bool Equals(GroupIdentifier obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (!entityType_0.Equals(obj.entityType_0))
			{
				result = false;
			}
			if (ushort_0 != obj.ushort_0)
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
		return smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ ushort_0.GetHashCode();
	}

	static GroupIdentifier()
	{
		Class72.smethod_20();
	}
}
