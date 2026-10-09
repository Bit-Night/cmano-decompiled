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
[XmlInclude(typeof(Vector3Double))]
public class Association
{
	private byte byte_0;

	private byte byte_1;

	private EntityID entityID_0 = new EntityID();

	private Vector3Double vector3Double_0 = new Vector3Double();

	[CompilerGenerated]
	private Action<Exception> yjiYjeqyUeA;

	[XmlElement(Type = typeof(byte), ElementName = "associationType")]
	public byte AssociationType
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

	[XmlElement(Type = typeof(byte), ElementName = "padding4")]
	public byte Padding4
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

	[XmlElement(Type = typeof(EntityID), ElementName = "associatedEntityID")]
	public EntityID AssociatedEntityID
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

	[XmlElement(Type = typeof(Vector3Double), ElementName = "associatedLocation")]
	public Vector3Double AssociatedLocation
	{
		get
		{
			return vector3Double_0;
		}
		set
		{
			vector3Double_0 = value;
		}
	}

	public event Action<Exception> Exception
	{
		[CompilerGenerated]
		add
		{
			Action<Exception> action = yjiYjeqyUeA;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref yjiYjeqyUeA, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<Exception> action = yjiYjeqyUeA;
			Action<Exception> action2;
			do
			{
				action2 = action;
				Action<Exception> value2 = (Action<Exception>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref yjiYjeqyUeA, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static bool operator !=(Association left, Association right)
	{
		return !(left == right);
	}

	public static bool operator ==(Association left, Association right)
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
		return 2 + entityID_0.GetMarshalledSize() + vector3Double_0.GetMarshalledSize();
	}

	protected void OnException(Exception e)
	{
		if (yjiYjeqyUeA != null)
		{
			yjiYjeqyUeA(e);
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
				entityID_0.Marshal(dos);
				vector3Double_0.Marshal(dos);
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
				entityID_0.Unmarshal(dis);
				vector3Double_0.Unmarshal(dis);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<Association>");
		try
		{
			sb.AppendLine("<associationType type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</associationType>");
			sb.AppendLine("<padding4 type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</padding4>");
			sb.AppendLine("<associatedEntityID>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</associatedEntityID>");
			sb.AppendLine("<associatedLocation>");
			vector3Double_0.Reflection(sb);
			sb.AppendLine("</associatedLocation>");
			sb.AppendLine("</Association>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as Association;
	}

	public bool Equals(Association obj)
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
			if (!entityID_0.Equals(obj.entityID_0))
			{
				result = false;
			}
			if (!vector3Double_0.Equals(obj.vector3Double_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(0) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ entityID_0.GetHashCode()) ^ vector3Double_0.GetHashCode();
	}

	static Association()
	{
		Class72.smethod_20();
	}
}
