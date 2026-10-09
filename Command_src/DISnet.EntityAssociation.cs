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
public class EntityAssociation
{
	private byte byte_0 = 2;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private EntityID entityID_0 = new EntityID();

	private ushort ushort_0;

	private ushort ushort_1;

	private byte byte_4;

	private ushort ushort_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(byte), ElementName = "recordType")]
	public byte RecordType
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

	[XmlElement(Type = typeof(byte), ElementName = "changeIndicator")]
	public byte ChangeIndicator
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

	[XmlElement(Type = typeof(byte), ElementName = "associationStatus")]
	public byte AssociationStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "associationType")]
	public byte AssociationType
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
		}
	}

	[XmlElement(Type = typeof(EntityID), ElementName = "entityID")]
	public EntityID EntityID
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

	[XmlElement(Type = typeof(ushort), ElementName = "owsSttionLocation")]
	public ushort OwsSttionLocation
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

	[XmlElement(Type = typeof(ushort), ElementName = "physicalConnectionType")]
	public ushort PhysicalConnectionType
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

	[XmlElement(Type = typeof(byte), ElementName = "groupMemberType")]
	public byte GroupMemberType
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "groupNumber")]
	public ushort GroupNumber
	{
		get
		{
			return ushort_2;
		}
		set
		{
			ushort_2 = value;
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

	public static bool operator !=(EntityAssociation left, EntityAssociation right)
	{
		return !(left == right);
	}

	public static bool operator ==(EntityAssociation left, EntityAssociation right)
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
		return 4 + entityID_0.GetMarshalledSize() + 2 + 2 + 1 + 2;
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedByte(byte_3);
				entityID_0.Marshal(dos);
				dos.WriteUnsignedShort(ushort_0);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedByte(byte_4);
				dos.WriteUnsignedShort(ushort_2);
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
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				byte_3 = dis.ReadUnsignedByte();
				entityID_0.Unmarshal(dis);
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				byte_4 = dis.ReadUnsignedByte();
				ushort_2 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EntityAssociation>");
		try
		{
			sb.AppendLine("<recordType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<changeIndicator type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</changeIndicator>");
			sb.AppendLine("<associationStatus type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</associationStatus>");
			sb.AppendLine("<associationType type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</associationType>");
			sb.AppendLine("<entityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</entityID>");
			sb.AppendLine("<owsSttionLocation type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</owsSttionLocation>");
			sb.AppendLine("<physicalConnectionType type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</physicalConnectionType>");
			sb.AppendLine("<groupMemberType type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</groupMemberType>");
			sb.AppendLine("<groupNumber type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</groupNumber>");
			sb.AppendLine("</EntityAssociation>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EntityAssociation;
	}

	public bool Equals(EntityAssociation obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
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
			if (byte_3 != obj.byte_3)
			{
				result = false;
			}
			if (!entityID_0.Equals(obj.entityID_0))
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
			if (byte_4 != obj.byte_4)
			{
				result = false;
			}
			if (ushort_2 != obj.ushort_2)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ entityID_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ byte_4.GetHashCode()) ^ ushort_2.GetHashCode();
	}

	static EntityAssociation()
	{
		Class72.smethod_20();
	}
}
