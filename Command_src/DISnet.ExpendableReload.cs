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
public class ExpendableReload
{
	private EntityType entityType_0 = new EntityType();

	private uint uint_0;

	private ushort ushort_0;

	private ushort ushort_1;

	private uint uint_1;

	private uint uint_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(EntityType), ElementName = "expendable")]
	public EntityType Expendable
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

	[XmlElement(Type = typeof(ushort), ElementName = "standardQuantity")]
	public ushort StandardQuantity
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

	[XmlElement(Type = typeof(ushort), ElementName = "maximumQuantity")]
	public ushort MaximumQuantity
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

	[XmlElement(Type = typeof(uint), ElementName = "standardQuantityReloadTime")]
	public uint StandardQuantityReloadTime
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

	[XmlElement(Type = typeof(uint), ElementName = "maximumQuantityReloadTime")]
	public uint MaximumQuantityReloadTime
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

	public static bool operator !=(ExpendableReload left, ExpendableReload right)
	{
		return !(left == right);
	}

	public static bool operator ==(ExpendableReload left, ExpendableReload right)
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
		return 0 + entityType_0.GetMarshalledSize() + 4 + 2 + 2 + 4 + 4;
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
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedInt(uint_1);
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
				entityType_0.Unmarshal(dis);
				uint_0 = dis.ReadUnsignedInt();
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				uint_1 = dis.ReadUnsignedInt();
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
		sb.AppendLine("<ExpendableReload>");
		try
		{
			sb.AppendLine("<expendable>");
			entityType_0.Reflection(sb);
			sb.AppendLine("</expendable>");
			sb.AppendLine("<station type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</station>");
			sb.AppendLine("<standardQuantity type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
			sb.AppendLine("<maximumQuantity type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
			sb.AppendLine("<standardQuantityReloadTime type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
			sb.AppendLine("<maximumQuantityReloadTime type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
			sb.AppendLine("</ExpendableReload>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as ExpendableReload;
	}

	public bool Equals(ExpendableReload obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
		}
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
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (uint_1 != obj.uint_1)
		{
			result = false;
		}
		if (uint_2 != obj.uint_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ entityType_0.GetHashCode()) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ uint_1.GetHashCode()) ^ uint_2.GetHashCode();
	}

	static ExpendableReload()
	{
		Class72.smethod_20();
	}
}
