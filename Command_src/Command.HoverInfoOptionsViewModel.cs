using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;
using Nini.Config;

namespace Command;

[DoNotObfuscate]
[DoNotPrune]
[DoNotPruneType]
public sealed class HoverInfoOptionsViewModel : CommandViewModel
{
	private static HoverInfoOptionsViewModel hoverInfoOptionsViewModel_0;

	private HoverInfoEnableDetailedEnum raSzYleNy5;

	private HoverInfoEnableEnum hoverInfoEnableEnum_0;

	private HoverInfoEnableEnum hoverInfoEnableEnum_1;

	private HoverInfoEnableEnum hoverInfoEnableEnum_2;

	private HoverInfoEnableEnum hvizjgpWqT;

	private HoverInfoEnableEnum hoverInfoEnableEnum_3;

	private HoverInfoEnableDetailedEnum hoverInfoEnableDetailedEnum_0;

	private HoverInfoEnableEnum hoverInfoEnableEnum_4;

	private HoverInfoEnableEnum hoverInfoEnableEnum_5;

	private HoverInfoEnableEnum hoverInfoEnableEnum_6;

	public static HoverInfoOptionsViewModel Singleton => hoverInfoOptionsViewModel_0;

	[Description("Weapon")]
	[Category("Hover Info Settings")]
	[DefaultValue(1)]
	[DisplayName("Weapon")]
	public HoverInfoEnableDetailedEnum Weapons
	{
		get
		{
			return raSzYleNy5;
		}
		set
		{
			SetProperty(ref raSzYleNy5, value, "Weapons");
		}
	}

	[Category("Hover Info Settings")]
	[DefaultValue(0)]
	[DisplayName("Sensor")]
	[Description("Sensor")]
	public HoverInfoEnableEnum Sensor
	{
		get
		{
			return hoverInfoEnableEnum_0;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_0, value, "Sensor");
		}
	}

	[DisplayName("Cargo")]
	[DefaultValue(0)]
	[Category("Hover Info Settings")]
	[Description("Cargo")]
	public HoverInfoEnableEnum Cargo
	{
		get
		{
			return hoverInfoEnableEnum_1;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_1, value, "Cargo");
		}
	}

	[DefaultValue(0)]
	[Category("Hover Info Settings")]
	[Description("Damage")]
	[DisplayName("Damage")]
	public HoverInfoEnableEnum Damage
	{
		get
		{
			return hoverInfoEnableEnum_2;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_2, value, "Damage");
		}
	}

	[DefaultValue(0)]
	[Category("Hover Info Settings")]
	[DisplayName("Landed Aircraft")]
	[Description("Aircraft landed on carrier/airbase")]
	public HoverInfoEnableEnum AirParasite
	{
		get
		{
			return hvizjgpWqT;
		}
		set
		{
			SetProperty(ref hvizjgpWqT, value, "AirParasite");
		}
	}

	[Category("Hover Info Settings")]
	[DefaultValue(0)]
	[DisplayName("Docked Boats")]
	[Description("Boats docked to mothership")]
	public HoverInfoEnableEnum BoatParasite
	{
		get
		{
			return hoverInfoEnableEnum_3;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_3, value, "BoatParasite");
		}
	}

	[DisplayName("Fuel Information")]
	[Description("Fuel Information")]
	[DefaultValue(1)]
	[Category("Hover Info Settings")]
	public HoverInfoEnableDetailedEnum Fuel
	{
		get
		{
			return hoverInfoEnableDetailedEnum_0;
		}
		set
		{
			SetProperty(ref hoverInfoEnableDetailedEnum_0, value, "Fuel");
		}
	}

	[Description("Mission Information")]
	[Category("Hover Info Settings")]
	[DefaultValue(0)]
	[DisplayName("Mission Information")]
	public HoverInfoEnableEnum Mission
	{
		get
		{
			return hoverInfoEnableEnum_4;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_4, value, "Mission");
		}
	}

	[DisplayName("Vehicle Information")]
	[Description("Ground unit vehicles")]
	[Category("Hover Info Settings")]
	[DefaultValue(0)]
	public HoverInfoEnableEnum Vehicles
	{
		get
		{
			return hoverInfoEnableEnum_5;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_5, value, "Vehicles");
		}
	}

	[DefaultValue(0)]
	[DisplayName("Group Members")]
	[Description("Group Members")]
	[Category("Hover Info Settings")]
	public HoverInfoEnableEnum GroupMembers
	{
		get
		{
			return hoverInfoEnableEnum_6;
		}
		set
		{
			SetProperty(ref hoverInfoEnableEnum_6, value, "GroupMembers");
		}
	}

	static HoverInfoOptionsViewModel()
	{
		Class72.smethod_20();
		hoverInfoOptionsViewModel_0 = new HoverInfoOptionsViewModel();
	}

	private HoverInfoOptionsViewModel()
	{
		Load();
	}

	[SpecialName]
	private string method_0()
	{
		return Path.Combine(GameGeneral.ConfigFolderPath, "HoverInfo.ini");
	}

	private void method_1()
	{
		IniConfigSource iniConfigSource = new IniConfigSource();
		IConfig config = iniConfigSource.AddConfig("HoverInfo");
		PropertyInfo[] properties = typeof(HoverInfoOptionsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
		foreach (PropertyInfo propertyInfo in properties)
		{
			DefaultValueAttribute defaultValueAttribute = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: true).Cast<DefaultValueAttribute>().First();
			config.Set(propertyInfo.Name, RuntimeHelpers.GetObjectValue(defaultValueAttribute.Value));
		}
		iniConfigSource.Save(method_0());
	}

	public void Load()
	{
		try
		{
			if (!FileExistsNative.FileExistsFast(method_0()))
			{
				method_1();
			}
			IniConfigSource iniConfigSource = new IniConfigSource(method_0());
			PropertyInfo[] properties = typeof(HoverInfoOptionsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				string value = iniConfigSource.Configs["HoverInfo"].Get(propertyInfo.Name);
				object objectValue = RuntimeHelpers.GetObjectValue(Enum.Parse(propertyInfo.PropertyType, value));
				propertyInfo.SetValue(this, RuntimeHelpers.GetObjectValue(objectValue), null);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			method_1();
			ProjectData.ClearProjectError();
		}
	}

	public void Save()
	{
		try
		{
			if (!FileExistsNative.FileExistsFast(method_0()))
			{
				method_1();
			}
			IniConfigSource iniConfigSource = new IniConfigSource(method_0());
			PropertyInfo[] properties = typeof(HoverInfoOptionsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				iniConfigSource.Configs["HoverInfo"].Set(propertyInfo.Name, RuntimeHelpers.GetObjectValue(propertyInfo.GetValue(this, null)));
			}
			iniConfigSource.Save(method_0());
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			method_1();
			ProjectData.ClearProjectError();
		}
	}
}
