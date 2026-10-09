using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Command_Core;
using Command_Core.SmartAssembly.Attributes;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

[DoNotPrune]
[DoNotPruneType]
[DoNotObfuscate]
public sealed class GClass3 : CommandViewModel
{
	public delegate void SensorsFormRequestedEventHandler();

	private InvertableBool invertableBool_0;

	private InvertableBool invertableBool_1;

	private InvertableBool invertableBool_2;

	private InvertableBool invertableBool_3;

	private InvertableBool invertableBool_4;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	[CompilerGenerated]
	private static SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_0;

	[CompilerGenerated]
	private RelayCommand relayCommand_1;

	[CompilerGenerated]
	private RelayCommand relayCommand_2;

	public ActiveUnit theUnit;

	public InvertableBool Inherit
	{
		get
		{
			return invertableBool_0;
		}
		set
		{
			SetProperty(ref invertableBool_0, value, "Inherit");
		}
	}

	public InvertableBool RadarActive
	{
		get
		{
			return invertableBool_1;
		}
		set
		{
			SetProperty(ref invertableBool_1, value, "RadarActive");
		}
	}

	public InvertableBool SonarActive
	{
		get
		{
			return invertableBool_2;
		}
		set
		{
			SetProperty(ref invertableBool_2, value, "SonarActive");
		}
	}

	public InvertableBool OECMActive
	{
		get
		{
			return invertableBool_3;
		}
		set
		{
			SetProperty(ref invertableBool_3, value, "OECMActive");
		}
	}

	public InvertableBool ObeysEMCON
	{
		get
		{
			return invertableBool_4;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			SetProperty(ref invertableBool_4, value, "ObeysEMCON");
			Visibility field = EmconObeyVisibility;
			SetProperty(ref field, EmconObeyVisibility, "EmconObeyVisibility");
		}
	}

	public bool HasRadarSensor
	{
		get
		{
			return bool_0;
		}
		set
		{
			SetProperty(ref bool_0, value, "HasRadarSensor");
		}
	}

	public bool HasSonarSensor
	{
		get
		{
			return bool_1;
		}
		set
		{
			SetProperty(ref bool_1, value, "HasSonarSensor");
		}
	}

	public bool HasOECMSensor
	{
		get
		{
			return bool_2;
		}
		set
		{
			SetProperty(ref bool_2, value, "HasOECMSensor");
		}
	}

	public RelayCommand EMCONWindowCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_0;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_0 = value;
		}
	}

	public RelayCommand SensorsWindowCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_1;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_1 = value;
		}
	}

	public RelayCommand EMCONWRAWindowCommand
	{
		[CompilerGenerated]
		get
		{
			return relayCommand_2;
		}
		[CompilerGenerated]
		set
		{
			relayCommand_2 = value;
		}
	}

	public Visibility EmconObeyVisibility
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			if (!ObeysEMCON)
			{
				return (Visibility)1;
			}
			return (Visibility)0;
		}
	}

	public static event SensorsFormRequestedEventHandler SensorsFormRequested
	{
		[CompilerGenerated]
		add
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = sensorsFormRequestedEventHandler_0;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Combine(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref sensorsFormRequestedEventHandler_0, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler = sensorsFormRequestedEventHandler_0;
			SensorsFormRequestedEventHandler sensorsFormRequestedEventHandler2;
			do
			{
				sensorsFormRequestedEventHandler2 = sensorsFormRequestedEventHandler;
				SensorsFormRequestedEventHandler value2 = (SensorsFormRequestedEventHandler)Delegate.Remove(sensorsFormRequestedEventHandler2, value);
				sensorsFormRequestedEventHandler = Interlocked.CompareExchange(ref sensorsFormRequestedEventHandler_0, value2, sensorsFormRequestedEventHandler2);
			}
			while ((object)sensorsFormRequestedEventHandler != sensorsFormRequestedEventHandler2);
		}
	}

	public void EMCONWindowWRACommand()
	{
		DoctrineForm obj = new DoctrineForm
		{
			Subject = theUnit
		};
		((TabControl)obj.TabControl1A).SelectedIndex = 2;
		((Control)obj).Show();
	}

	public void method_0()
	{
		DoctrineForm obj = new DoctrineForm
		{
			Subject = theUnit
		};
		((TabControl)obj.TabControl1A).SelectedIndex = 1;
		((Control)obj).Show();
	}

	public void SensorsWindow()
	{
		sensorsFormRequestedEventHandler_0?.Invoke();
	}

	public void Refresh()
	{
		if (Client.SelectedUnit == null)
		{
			return;
		}
		Inherit = theUnit.Doctrine.EMCON_Inherits;
		ObeysEMCON = theUnit.Sensory.ObeysEMCON;
		if (!ObeysEMCON)
		{
			bool flag = false;
			bool flag2 = false;
			Sensor[] sensors_Cached = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
			foreach (Sensor sensor in sensors_Cached)
			{
				if (sensor != null && sensor.Type == Sensor.Sensor_Type.Radar && !sensor.IsPureIlluminator)
				{
					if (sensor.IsActive())
					{
						flag = true;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			int num;
			if (flag && flag2)
			{
				RadarActive = null;
				num = 0;
			}
			else if (!(flag && !flag2))
			{
				RadarActive = false;
				num = 0;
			}
			else
			{
				RadarActive = true;
				num = 0;
			}
			flag = (byte)num != 0;
			flag2 = false;
			Sensor[] sensors_Cached2 = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
			foreach (Sensor sensor2 in sensors_Cached2)
			{
				if (sensor2.IsSonar && !sensor2.IsPureIlluminator)
				{
					if (!sensor2.IsActive())
					{
						flag2 = true;
					}
					else
					{
						flag = true;
					}
				}
			}
			int num2;
			if (flag && flag2)
			{
				SonarActive = null;
				num2 = 0;
			}
			else if (flag && !flag2)
			{
				SonarActive = true;
				num2 = 0;
			}
			else
			{
				SonarActive = false;
				num2 = 0;
			}
			flag = (byte)num2 != 0;
			flag2 = false;
			Sensor[] sensors_Cached3 = ((ActiveUnit)Client.SelectedUnit).Sensors_Cached;
			foreach (Sensor sensor3 in sensors_Cached3)
			{
				if (sensor3 != null && sensor3.IsOECM && !sensor3.IsPureIlluminator)
				{
					if (!sensor3.IsActive())
					{
						flag2 = true;
					}
					else
					{
						flag = true;
					}
				}
			}
			if (!(flag && flag2))
			{
				if (flag && !flag2)
				{
					OECMActive = true;
				}
				else
				{
					OECMActive = false;
				}
			}
			else
			{
				OECMActive = null;
			}
		}
		else
		{
			RadarActive = (theUnit.Doctrine.EMCON(Client.CurrentScenario)?.Radar()).Value != Doctrine.EMCONSettings._EMCONSetting.Passive;
			SonarActive = (theUnit.Doctrine.EMCON(Client.CurrentScenario)?.Sonar()).Value != Doctrine.EMCONSettings._EMCONSetting.Passive;
			OECMActive = (theUnit.Doctrine.EMCON(Client.CurrentScenario)?.OECM()).Value != Doctrine.EMCONSettings._EMCONSetting.Passive;
		}
		HasRadarSensor = theUnit.HasRadarSensor;
		HasSonarSensor = theUnit.HasSonarSensor;
		HasOECMSensor = theUnit.HasOECMSensor;
	}

	public GClass3(ActiveUnit theUnit)
	{
		EMCONWindowCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			method_0();
		});
		SensorsWindowCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			SensorsWindow();
		});
		EMCONWRAWindowCommand = new RelayCommand([SpecialName] (object a0) =>
		{
			EMCONWindowWRACommand();
		});
		try
		{
			this.theUnit = theUnit;
			Refresh();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static GClass3()
	{
		Class72.smethod_20();
	}
}
