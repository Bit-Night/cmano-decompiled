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
public class EngineFuelReload
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	[CompilerGenerated]
	private Action<Exception> action_0;

	[XmlElement(Type = typeof(uint), ElementName = "standardQuantity")]
	public uint StandardQuantity
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

	[XmlElement(Type = typeof(uint), ElementName = "maximumQuantity")]
	public uint MaximumQuantity
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

	[XmlElement(Type = typeof(uint), ElementName = "standardQuantityReloadTime")]
	public uint StandardQuantityReloadTime
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

	[XmlElement(Type = typeof(uint), ElementName = "maximumQuantityReloadTime")]
	public uint MaximumQuantityReloadTime
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	[XmlElement(Type = typeof(byte), ElementName = "fuelMeasurmentUnits")]
	public byte FuelMeasurmentUnits
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelLocation")]
	public byte FuelLocation
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
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

	public static bool operator !=(EngineFuelReload left, EngineFuelReload right)
	{
		return !(left == right);
	}

	public static bool operator ==(EngineFuelReload left, EngineFuelReload right)
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
		return 19;
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
				dos.WriteUnsignedInt(uint_1);
				dos.WriteUnsignedInt(uint_2);
				dos.WriteUnsignedInt(uint_3);
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
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
				uint_1 = dis.ReadUnsignedInt();
				uint_2 = dis.ReadUnsignedInt();
				uint_3 = dis.ReadUnsignedInt();
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<EngineFuelReload>");
		try
		{
			sb.AppendLine("<standardQuantity type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
			sb.AppendLine("<maximumQuantity type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
			sb.AppendLine("<standardQuantityReloadTime type=\"uint\">" + uint_2.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
			sb.AppendLine("<maximumQuantityReloadTime type=\"uint\">" + uint_3.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
			sb.AppendLine("<fuelMeasurmentUnits type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</fuelMeasurmentUnits>");
			sb.AppendLine("<fuelLocation type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</fuelLocation>");
			sb.AppendLine("<padding type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</EngineFuelReload>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as EngineFuelReload;
	}

	public bool Equals(EngineFuelReload obj)
	{
		bool result = true;
		if (!(obj.GetType() != GetType()))
		{
			if (uint_0 != obj.uint_0)
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
			if (uint_3 != obj.uint_3)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ uint_2.GetHashCode()) ^ uint_3.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode();
	}

	static EngineFuelReload()
	{
		Class72.smethod_20();
	}
}
