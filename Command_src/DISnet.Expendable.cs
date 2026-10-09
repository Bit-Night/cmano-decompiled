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
public class Expendable
{
	private EntityType entityType_0 = new EntityType();

	private uint uint_0;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "expendable")]
	public EntityType Expendable_
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

	[XmlElement(Type = typeof(uint), ElementName = "station")]
	public uint Station
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

	[XmlElement(Type = typeof(ushort), ElementName = "quantity")]
	public ushort Quantity
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

	[XmlElement(Type = typeof(byte), ElementName = "expendableStatus")]
	public byte ExpendableStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(Expendable left, Expendable right)
	{
		return !(left == right);
	}

	public static bool operator ==(Expendable left, Expendable right)
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
		return 0 + entityType_0.GetMarshalledSize() + 4 + 2 + 1 + 1;
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
				dos.WriteUnsignedInt(uint_0);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
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
				uint_0 = dis.ReadUnsignedInt();
				ushort_0 = dis.ReadUnsignedShort();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<Expendable>");
		try
		{
			sb.AppendLine("<expendable>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</expendable>");
			sb.AppendLine("<station type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</station>");
			sb.AppendLine("<quantity type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</quantity>");
			sb.AppendLine("<expendableStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</expendableStatus>");
			sb.AppendLine("<padding type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</Expendable>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Expendable;
	}

	public bool Equals(Expendable obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (!entityType_0.Equals(obj.entityType_0))
			{
				result = false;
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode();
	}

	static Expendable()
	{
		Class72.smethod_20();
	}
}
