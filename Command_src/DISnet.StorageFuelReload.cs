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
public class StorageFuelReload
{
	private uint uint_0;

	private uint uint_1;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	private byte byte_5;

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

	[XmlElement(Type = typeof(byte), ElementName = "standardQuantityReloadTime")]
	public byte StandardQuantityReloadTime
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

	[XmlElement(Type = typeof(byte), ElementName = "maximumQuantityReloadTime")]
	public byte MaximumQuantityReloadTime
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelMeasurementUnits")]
	public byte FuelMeasurementUnits
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelType")]
	public byte FuelType
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

	[XmlElement(Type = typeof(byte), ElementName = "fuelLocation")]
	public byte FuelLocation
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

	[XmlElement(Type = typeof(byte), ElementName = "padding")]
	public byte Padding
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
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

	public static bool operator !=(StorageFuelReload left, StorageFuelReload right)
	{
		return !(left == right);
	}

	public static bool operator ==(StorageFuelReload left, StorageFuelReload right)
	{
		if ((object)left == right)
		{
			return true;
		}
		int result;
		if ((object)left != null)
		{
			if ((object)right != null)
			{
				return left.Equals(right);
			}
			result = 0;
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	public virtual int GetMarshalledSize()
	{
		return 14;
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
				dos.WriteUnsignedByte(byte_0);
				dos.WriteUnsignedByte(byte_1);
				dos.WriteUnsignedByte(byte_2);
				dos.WriteUnsignedByte(byte_3);
				dos.WriteUnsignedByte(byte_4);
				dos.WriteUnsignedByte(byte_5);
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
				byte_0 = dis.ReadUnsignedByte();
				byte_1 = dis.ReadUnsignedByte();
				byte_2 = dis.ReadUnsignedByte();
				byte_3 = dis.ReadUnsignedByte();
				byte_4 = dis.ReadUnsignedByte();
				byte_5 = dis.ReadUnsignedByte();
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}
	}

	public virtual void Reflection(StringBuilder sb)
	{
		sb.AppendLine("<StorageFuelReload>");
		try
		{
			sb.AppendLine("<standardQuantity type=\"uint\">" + uint_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
			sb.AppendLine("<maximumQuantity type=\"uint\">" + uint_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
			sb.AppendLine("<standardQuantityReloadTime type=\"byte\">" + byte_0.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
			sb.AppendLine("<maximumQuantityReloadTime type=\"byte\">" + byte_1.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
			sb.AppendLine("<fuelMeasurementUnits type=\"byte\">" + byte_2.ToString(CultureInfo.InvariantCulture) + "</fuelMeasurementUnits>");
			sb.AppendLine("<fuelType type=\"byte\">" + byte_3.ToString(CultureInfo.InvariantCulture) + "</fuelType>");
			sb.AppendLine("<fuelLocation type=\"byte\">" + byte_4.ToString(CultureInfo.InvariantCulture) + "</fuelLocation>");
			sb.AppendLine("<padding type=\"byte\">" + byte_5.ToString(CultureInfo.InvariantCulture) + "</padding>");
			sb.AppendLine("</StorageFuelReload>");
		}
		catch (Exception e)
		{
			OnException(e);
		}
	}

	public override bool Equals(object obj)
	{
		return this == obj as StorageFuelReload;
	}

	public bool Equals(StorageFuelReload obj)
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
			if (byte_4 != obj.byte_4)
			{
				result = false;
			}
			if (byte_5 != obj.byte_5)
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
		return smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(smethod_0(0) ^ uint_0.GetHashCode()) ^ uint_1.GetHashCode()) ^ byte_0.GetHashCode()) ^ byte_1.GetHashCode()) ^ byte_2.GetHashCode()) ^ byte_3.GetHashCode()) ^ byte_4.GetHashCode()) ^ byte_5.GetHashCode();
	}

	static StorageFuelReload()
	{
		Class72.smethod_20();
	}
}
