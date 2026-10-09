using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using OpenDis.Core;

namespace DISnet;

[Serializable]
[XmlInclude(typeof(EventIdentifier))]
[XmlRoot]
[XmlInclude(typeof(Vector3Float))]
public class DirectedEnergyDamage
{
	private uint uint_0 = 4500u;

	private ushort ushort_0 = 40;

	private ushort ushort_1;

	private Vector3Float vector3Float_0 = new Vector3Float();

	private float float_0;

	private float float_1 = -273.15f;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private EventIdentifier eventIdentifier_0 = new EventIdentifier();

	private ushort ushort_2;

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

	[XmlElement(Type = typeof(ushort), ElementName = "padding")]
	public ushort Padding
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

	[XmlElement(Type = typeof(Vector3Float), ElementName = "damageLocation")]
	public Vector3Float DamageLocation
	{
		get
		{
			return vector3Float_0;
		}
		set
		{
			vector3Float_0 = value;
		}
	}

	[XmlElement(Type = typeof(float), ElementName = "damageDiameter")]
	public float DamageDiameter
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

	[XmlElement(Type = typeof(float), ElementName = "temperature")]
	public float Temperature
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "componentIdentification")]
	public byte ComponentIdentification
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

	[XmlElement(Type = typeof(byte), ElementName = "componentDamageStatus")]
	public byte ComponentDamageStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "componentVisualDamageStatus")]
	public byte ComponentVisualDamageStatus
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

	[XmlElement(Type = typeof(byte), ElementName = "componentVisualSmokeColor")]
	public byte ComponentVisualSmokeColor
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

	[XmlElement(Type = typeof(EventIdentifier), ElementName = "fireEventID")]
	public EventIdentifier FireEventID
	{
		get
		{
			return eventIdentifier_0;
		}
		set
		{
			eventIdentifier_0 = value;
		}
	}

	[XmlElement(Type = typeof(ushort), ElementName = "padding2")]
	public ushort Padding2
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

	public static bool operator !=(DirectedEnergyDamage left, DirectedEnergyDamage right)
	{
		return !(left == right);
	}

	public static bool operator ==(DirectedEnergyDamage left, DirectedEnergyDamage right)
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
		return 8 + vector3Float_0.GetMarshalledSize() + 4 + 4 + 1 + 1 + 1 + 1 + eventIdentifier_0.GetMarshalledSize() + 2;
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
				dos.WriteUnsignedShort(ushort_1);
				vector3Float_0.Marshal(dos);
				dos.WriteFloat(float_0);
				dos.WriteFloat(float_1);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedByte(byte_3);
				eventIdentifier_0.Marshal(dos);
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
				uint_0 = dis.ReadUnsignedInt();
				ushort_0 = dis.ReadUnsignedShort();
				ushort_1 = dis.ReadUnsignedShort();
				vector3Float_0.Unmarshal(dis);
				float_0 = dis.ReadFloat();
				float_1 = dis.ReadFloat();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				byte_3 = dis.ReadUnsignedByte();
				eventIdentifier_0.Unmarshal(dis);
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
		sb.AppendLine("<DirectedEnergyDamage>");
		try
		{
			sb.AppendLine("<recordType type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</recordType>");
			sb.AppendLine("<recordLength type=\"ushort\">" + ushort_0.ToString(CultureInfo.InvariantCulture) + "</recordLength>");
			sb.AppendLine("<padding type=\"ushort\">" + ushort_1.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("<damageLocation>");
			vector3Float_0.Reflection(sb);
			sb.AppendLine("</damageLocation>");
			sb.AppendLine("<damageDiameter type=\"float\">" + float_0.ToString(CultureInfo.InvariantCulture) + "</damageDiameter>");
			sb.AppendLine("<temperature type=\"float\">" + float_1.ToString(CultureInfo.InvariantCulture) + "</temperature>");
			sb.AppendLine("<componentIdentification type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</componentIdentification>");
			sb.AppendLine("<componentDamageStatus type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</componentDamageStatus>");
			sb.AppendLine("<componentVisualDamageStatus type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</componentVisualDamageStatus>");
			sb.AppendLine("<componentVisualSmokeColor type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</componentVisualSmokeColor>");
			sb.AppendLine("<fireEventID>");
			eventIdentifier_0.Reflection(sb);
			sb.AppendLine("</fireEventID>");
			sb.AppendLine("<padding2 type=\"ushort\">" + ushort_2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
			sb.AppendLine("</DirectedEnergyDamage>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as DirectedEnergyDamage;
	}

	public bool Equals(DirectedEnergyDamage obj)
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
			if (ushort_1 != obj.ushort_1)
			{
				result = false;
			}
			if (!vector3Float_0.Equals(obj.vector3Float_0))
			{
				result = false;
			}
			if (float_0 != obj.float_0)
			{
				result = false;
			}
			if (float_1 != obj.float_1)
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
			if (byte_2 != obj.byte_2)
			{
				result = false;
			}
			if (byte_3 != obj.byte_3)
			{
				result = false;
			}
			if (!eventIdentifier_0.Equals(obj.eventIdentifier_0))
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ ushort_0.GetHashCode()) ^ ushort_1.GetHashCode()) ^ vector3Float_0.GetHashCode()) ^ float_0.GetHashCode()) ^ float_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ eventIdentifier_0.GetHashCode()) ^ ushort_2.GetHashCode();
	}

	static DirectedEnergyDamage()
	{
		Class72.smethod_20();
	}
}
