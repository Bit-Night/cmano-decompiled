using System;
using System.ComponentModel;

namespace OpenDis.Enumerations.DistributedEmission.UnderwaterAcoustic;

[Serializable]
public struct PropulsionPlantConfiguration
{
	[Description("Run internal simulation clock.")]
	public enum ConfigurationValue : uint
	{
		Other,
		DieselElectric,
		Diesel,
		Battery,
		TurbineReduction,
		Unknown,
		Steam,
		GasTurbine,
		Unknown2
	}

	[Description("Hull Mounted Masker status")]
	public enum HullMountedMaskerValue : uint
	{
		Off,
		On
	}

	private ConfigurationValue configurationValue_0;

	private HullMountedMaskerValue hullMountedMaskerValue_0;

	public ConfigurationValue Configuration
	{
		get
		{
			return configurationValue_0;
		}
		set
		{
			configurationValue_0 = value;
		}
	}

	public HullMountedMaskerValue HullMountedMasker
	{
		get
		{
			return hullMountedMaskerValue_0;
		}
		set
		{
			hullMountedMaskerValue_0 = value;
		}
	}

	public static bool operator !=(PropulsionPlantConfiguration left, PropulsionPlantConfiguration right)
	{
		return !(left == right);
	}

	public static bool operator ==(PropulsionPlantConfiguration left, PropulsionPlantConfiguration right)
	{
		if ((object)left == (object)right)
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

	public static explicit operator uint(PropulsionPlantConfiguration obj)
	{
		return obj.ToUInt32();
	}

	public static explicit operator PropulsionPlantConfiguration(uint value)
	{
		return smethod_0(value);
	}

	public static PropulsionPlantConfiguration FromByteArray(byte[] array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0 || index > array.Length - 1 || index + 4 > array.Length - 1)
		{
			throw new IndexOutOfRangeException();
		}
		return smethod_0(BitConverter.ToUInt32(array, index));
	}

	public static PropulsionPlantConfiguration smethod_0(uint value)
	{
		PropulsionPlantConfiguration result = default(PropulsionPlantConfiguration);
		uint configuration = (value & 0x7F) >> 0;
		result.Configuration = (ConfigurationValue)configuration;
		uint hullMountedMasker = (value & 0x80) >> 7;
		result.HullMountedMasker = (HullMountedMaskerValue)hullMountedMasker;
		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (!(obj is PropulsionPlantConfiguration))
			{
				return false;
			}
			return Equals((PropulsionPlantConfiguration)obj);
		}
		return false;
	}

	public bool Equals(PropulsionPlantConfiguration other)
	{
		if ((object)other != null)
		{
			if (Configuration == other.Configuration)
			{
				return HullMountedMasker == other.HullMountedMasker;
			}
			return false;
		}
		return false;
	}

	public byte[] ToByteArray()
	{
		return BitConverter.GetBytes(ToUInt32());
	}

	public uint ToUInt32()
	{
		return (uint)(ConfigurationValue.Other | Configuration) | ((uint)HullMountedMasker << 7);
	}

	public override int GetHashCode()
	{
		return (493 + Configuration.GetHashCode()) * 29 + HullMountedMasker.GetHashCode();
	}

	static PropulsionPlantConfiguration()
	{
		Class72.smethod_20();
	}
}
