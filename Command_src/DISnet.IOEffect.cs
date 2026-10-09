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
public class IOEffect
{
	private uint uint_0 = 5500u;

	private ushort ushort_0 = 16;

	private byte byte_0;

	private byte byte_1;

	private EntityID entityID_0 = new EntityID();

	private byte byte_2;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

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

	[XmlElement(Type = typeof(byte), ElementName = "ioStatus")]
	public byte IoStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "ioLinkType")]
	public byte IoLinkType
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

	[XmlElement(Type = typeof(EntityID), ElementName = "ioEffect")]
	public EntityID IoEffect
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

	[XmlElement(Type = typeof(byte), ElementName = "ioEffectDutyCycle")]
	public byte IoEffectDutyCycle
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

	[XmlElement(Type = typeof(ushort), ElementName = "ioEffectDuration")]
	public ushort IoEffectDuration
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

	[XmlElement(Type = typeof(ushort), ElementName = "ioProcess")]
	public ushort IoProcess
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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
	{
		get
		{
			return ushort_3;
		}
		set
		{
			ushort_3 = value;
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

	public static bool operator !=(IOEffect left, IOEffect right)
	{
		return !(left == right);
	}

	public static bool operator ==(IOEffect left, IOEffect right)
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
		return 8 + entityID_0.GetMarshalledSize() + 1 + 2 + 2 + 2;
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				entityID_0.Marshal(dos);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedShort(ushort_1);
				dos.WriteUnsignedShort(ushort_2);
				dos.WriteUnsignedShort(ushort_3);
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
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				entityID_0.Unmarshal(dis);
				byte_2 = dis.ReadUnsignedByte();
				ushort_1 = dis.ReadUnsignedShort();
				ushort_2 = dis.ReadUnsignedShort();
				ushort_3 = dis.ReadUnsignedShort();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<IOEffect>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<ioStatus type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</ioStatus>");
			sb.AppendLine("<ioLinkType type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</ioLinkType>");
			sb.AppendLine("<ioEffect>");
			entityID_0.Reflection(sb);
			sb.AppendLine("</ioEffect>");
			sb.AppendLine("<ioEffectDutyCycle type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</ioEffectDutyCycle>");
			sb.AppendLine("<ioEffectDuration type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</ioEffectDuration>");
			sb.AppendLine("<ioProcess type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</ioProcess>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_3.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</IOEffect>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as IOEffect;
	}

	public bool Equals(IOEffect obj)
	{
		bool result = true;
		if (obj.GetType() != GetType())
		{
			return false;
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
		if (!entityID_0.Equals(obj.entityID_0))
		{
			result = false;
		}
		if (byte_2 != obj.byte_2)
		{
			result = false;
		}
		if (ushort_1 != obj.ushort_1)
		{
			result = false;
		}
		if (ushort_2 != obj.ushort_2)
		{
			result = false;
		}
		if (ushort_3 != obj.ushort_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ entityID_0.GetHashCode()) ^ byte_2.GetHashCode()) ^ ushort_1.GetHashCode()) ^ ushort_2.GetHashCode()) ^ ushort_3.GetHashCode();
	}

	static IOEffect()
	{
		Class72.smethod_20();
	}
}
