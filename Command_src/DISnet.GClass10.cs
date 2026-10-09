using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EntityID))]
[XmlRoot]
public class GClass10
{
	private uint uint_0 = 5501u;

	private ushort ushort_0 = 16;

	private byte OjbYpjuYmYu;

	private byte byte_0;

	private EntityID entityID_0 = new EntityID();

	private ushort ushort_1;

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

	[XmlElement(Type = typeof(byte), ElementName = "communcationsNodeType")]
	public byte CommuncationsNodeType
	{
		get
		{
			return OjbYpjuYmYu;
		}
		set
		{
			OjbYpjuYmYu = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	[XmlElement(Type = typeof(EntityID), ElementName = "communicationsNode")]
	public EntityID CommunicationsNode
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

	[XmlElement(Type = typeof(ushort), ElementName = "elementID")]
	public ushort ElementID
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

	public static bool operator !=(GClass10 left, GClass10 right)
	{
		return !(left == right);
	}

	public static bool operator ==(GClass10 left, GClass10 right)
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
		return 8 + entityID_0.GetMarshalledSize() + 2;
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
				dos.WriteUnsignedByte(OjbYpjuYmYu);
				dos.WriteUnsignedByte(byte_0);
				entityID_0.Marshal(dos);
				dos.WriteUnsignedShort(ushort_1);
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
				OjbYpjuYmYu = dis.ReadUnsignedByte();
				byte_0 = dis.ReadUnsignedByte();
				entityID_0.Unmarshal(dis);
				ushort_1 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<IOCommunicationsNode>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<communcationsNodeType type=\"byte\">" + OjbYpjuYmYu.ToString(CultureInfo.InvariantCulture) + "</communcationsNodeType>");
			sb.AppendLine("<padding type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<communicationsNode>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</communicationsNode>");
			sb.AppendLine("<elementID type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</elementID>");
			sb.AppendLine("</IOCommunicationsNode>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as GClass10;
	}

	public bool Equals(GClass10 obj)
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
			if (OjbYpjuYmYu != obj.OjbYpjuYmYu)
			{
				result = false;
			}
			if (byte_0 != obj.byte_0)
			{
				result = false;
			}
			if (!entityID_0.Equals(obj.entityID_0))
			{
				result = false;
			}
			if (ushort_1 != obj.ushort_1)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ OjbYpjuYmYu.GetHashCode()) ^ byte_0.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_1.GetHashCode();
	}

	static GClass10()
	{
		Class72.smethod_20();
	}
}
