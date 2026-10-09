using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using Command_Core;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command;

public sealed class SoundHandler_Effects : DispatcherObject
{
	[CompilerGenerated]
	internal sealed class _Closure$__16-0
	{
		public int $VB$Local_index;

		public SoundHandler_Effects $VB$Me;

		public Action $I4;

		public Action $I6;

		public _Closure$__16-0(_Closure$__16-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_index = arg0.$VB$Local_index;
			}
		}

		[SpecialName]
		internal void _Lambda$__3(object sender, EventArgs e)
		{
			((DispatcherObject)$VB$Me).Dispatcher.Invoke(($I4 != null) ? $I4 : ($I4 = [SpecialName] () =>
			{
				$VB$Me.list_1[$VB$Local_index] = false;
				$VB$Me.list_2[$VB$Local_index] = "";
			}));
		}

		[SpecialName]
		internal void _Lambda$__4()
		{
			$VB$Me.list_1[$VB$Local_index] = false;
			$VB$Me.list_2[$VB$Local_index] = "";
		}

		[SpecialName]
		internal void _Lambda$__5(object sender, EventArgs e)
		{
			((DispatcherObject)$VB$Me).Dispatcher.Invoke(($I6 != null) ? $I6 : ($I6 = [SpecialName] () =>
			{
				$VB$Me.list_1[$VB$Local_index] = true;
			}));
		}

		[SpecialName]
		internal void _Lambda$__6()
		{
			$VB$Me.list_1[$VB$Local_index] = true;
		}

		static _Closure$__16-0()
		{
			Class72.smethod_20();
		}
	}

	private string string_0;

	private List<MediaPlayer> list_0;

	private List<bool> list_1;

	private List<string> list_2;

	private double double_0;

	private int int_0;

	private string[] string_1;

	public int Volume
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			double_0 = (double)value / 100.0;
			SimConfiguration.DefaultGamePreferences.SFXVolume = value;
		}
	}

	public SoundHandler_Effects()
	{
		list_0 = null;
		list_1 = null;
		list_2 = null;
		string_1 = new string[53]
		{
			"contact_new.mp3", "alert_missile.mp3", "alert_torpedo.mp3", "contact_air.mp3", "contact_surface.mp3", "contact_ground.mp3", "contact_underwater.mp3", "helo_takeoff.mp3", "airplane_takeoff_prop.mp3", "airplane_takeoff.mp3",
			"airplane_carriertakeoff_prop.mp3", "airplane_carriertakeoff.mp3", "gunfire_infantry.mp3", "gunfire_machinegun.mp3", "gunfire_20mm.mp3", "gunfire_40mm.mp3", "gunfire_76mm.mp3", "gunfire_100mm.mp3", "gunfire_120mm.mp3", "gunfire_152mm.mp3",
			"rocket_small.mp3", "aam_ir.mp3", "aam_other.mp3", "ship_missilelaunch.mp3", "ground_missilelaunch.mp3", "missile_small.mp3", "missile_medium.mp3", "torpedo_launch.mp3", "gunfire_laser.mp3", "impact_cluster.mp3",
			"impact_directhit_vsmall.mp3", "impact_directhit_small.mp3", "impact_directhit_medium.mp3", "impact_directhit_large.mp3", "impact_miss_land_small.mp3", "impact_miss_land_medium.mp3", "impact_miss_land_large.mp3", "explosion_air_medium.mp3", "explosion_air_nuclear.mp3", "explosion_underwater_medium.mp3",
			"explosion_underwater_large.mp3", "watersplash_large.mp3", "radiochirp.mp3", "radioChirp1.mp3", "radioChirp2.mp3", "radioChirp3.mp3", "radioChirp4.mp3", "radioChirp5.mp3", "radioChirp6.mp3", "radioChirp7.mp3",
			"radioChirp8.mp3", "telex.mp3", ""
		};
		string_0 = Application.StartupPath + "\\Sound\\Effects\\";
		ActiveUnit_Weaponry.FiredWeapon += method_2;
		Weapon.WeaponImpact += method_3;
		Aircraft_AirOps.TookOff += method_1;
		ActiveUnit_Sensory.NewContactDetected += method_0;
		PrivateMethods.LuaLocalSound += method_5;
	}

	private void method_0(Side side_0, Contact_Base.ContactType contactType_0)
	{
		if (SimConfiguration.DefaultGamePreferences.GameSounds && !Information.IsNothing((object)Client.CurrentSide) && !Information.IsNothing((object)Client.CurrentSide) && (side_0 == Client.CurrentSide || side_0.get_ConsidersThisSideToBe(Client.CurrentSide, (Scenario)null) == Misc.PostureStance.Friendly))
		{
			switch (contactType_0)
			{
			case Contact_Base.ContactType.Air:
				PlaySoundEffect(3);
				break;
			case Contact_Base.ContactType.Missile:
				PlaySoundEffect(1);
				break;
			case Contact_Base.ContactType.Surface:
				PlaySoundEffect(4);
				break;
			case Contact_Base.ContactType.Submarine:
				PlaySoundEffect(6);
				break;
			default:
				PlaySoundEffect(0);
				break;
			case Contact_Base.ContactType.Facility_Fixed:
			case Contact_Base.ContactType.Facility_Mobile:
			case Contact_Base.ContactType.AggregateGroundUnit:
				PlaySoundEffect(5);
				break;
			case Contact_Base.ContactType.Torpedo:
				PlaySoundEffect(2);
				break;
			}
		}
	}

	private void method_1(Aircraft aircraft_0)
	{
		if (!SimConfiguration.DefaultGamePreferences.GameSounds || Information.IsNothing((object)Client.CurrentSide) || ((ActiveUnit)aircraft_0).get_UnitSide(SetSideOnly: false) != Client.CurrentSide)
		{
			return;
		}
		if (!aircraft_0.IsHelicopter)
		{
			if (!(aircraft_0.AirOps.get_AssignedHostUnit(PickNewAssignedHost: false).IsShip & !Module_Unit.IsOverLand(aircraft_0)))
			{
				if ((aircraft_0.Propulsion[0].Type == Engine.EngineType.Turboprop) | (aircraft_0.Propulsion[0].Type == Engine.EngineType.Piston))
				{
					PlaySoundEffect(8);
				}
				else
				{
					PlaySoundEffect(9);
				}
			}
			else if (!((aircraft_0.Propulsion[0].Type == Engine.EngineType.Turboprop) | (aircraft_0.Propulsion[0].Type == Engine.EngineType.Piston)))
			{
				PlaySoundEffect(11);
			}
			else
			{
				PlaySoundEffect(10);
			}
		}
		else
		{
			PlaySoundEffect(7);
		}
	}

	private void method_2(Scenario scenario_0, ActiveUnit activeUnit_0, Weapon weapon_0)
	{
		if (Client.CurrentSide == null || !SimConfiguration.DefaultGamePreferences.GameSounds || !((activeUnit_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide) | Module_Side.IsAlliedWithThisSide(activeUnit_0.get_UnitSide(SetSideOnly: false), Client.CurrentSide)) || scenario_0 != Client.CurrentScenario)
		{
			return;
		}
		switch (weapon_0.Type)
		{
		case Weapon._WeaponType.Laser:
		case Weapon._WeaponType.Microwave:
			PlaySoundEffect(28);
			break;
		case Weapon._WeaponType.Torpedo:
			PlaySoundEffect(27);
			break;
		case Weapon._WeaponType.GuidedWeapon:
			if (weapon_0.Fuel_ReadOnly.Count > 0 && weapon_0.Fuel_ReadOnly[0].FuelType == FuelRec._FuelType.WeaponCoast)
			{
				break;
			}
			if (!(activeUnit_0.IsAircraft & weapon_0.IsAAWCapable))
			{
				if (activeUnit_0.IsShip)
				{
					PlaySoundEffect(23);
				}
				else if (!activeUnit_0.IsFacility)
				{
					if (weapon_0.MaxRange_NoTargetType < 10f)
					{
						PlaySoundEffect(25);
					}
					else
					{
						PlaySoundEffect(26);
					}
				}
				else
				{
					PlaySoundEffect(24);
				}
			}
			else if (!weapon_0.HasInfraredSensor)
			{
				PlaySoundEffect(22);
			}
			else
			{
				PlaySoundEffect(21);
			}
			break;
		case Weapon._WeaponType.Rocket:
			PlaySoundEffect(20);
			break;
		case Weapon._WeaponType.Gun:
			switch (weapon_0.Warheads[0].Caliber)
			{
			default:
				PlaySoundEffect(19);
				break;
			case Warhead.WarheadCaliber.Gun_6_15mm:
				PlaySoundEffect(13);
				break;
			case Warhead.WarheadCaliber.Gun_16_24mm:
				PlaySoundEffect(14);
				break;
			case Warhead.WarheadCaliber.Gun_25_60mm:
				PlaySoundEffect(15);
				break;
			case Warhead.WarheadCaliber.Gun_61_80mm:
				PlaySoundEffect(16);
				break;
			case Warhead.WarheadCaliber.Gun_81_150mm:
				PlaySoundEffect(17);
				break;
			}
			break;
		}
	}

	private void method_3(Scenario scenario_0, Weapon weapon_0, Module_Unit.Unit unit_0, bool bool_0)
	{
		if (!SimConfiguration.DefaultGamePreferences.GameSounds || Client.CurrentSide == null || ((((ActiveUnit)weapon_0).get_UnitSide(SetSideOnly: false) != Client.CurrentSide && ((ActiveUnit)weapon_0).get_UnitSide(SetSideOnly: false) != null) | (unit_0.get_UnitSide(SetSideOnly: false) != null && unit_0.get_UnitSide(SetSideOnly: false) == Client.CurrentSide)) || scenario_0 != Client.CurrentScenario)
		{
			return;
		}
		if (weapon_0.Warheads.Count() > 0 && weapon_0.Warheads[0].IsCluster)
		{
			PlaySoundEffect(29);
			return;
		}
		if (!bool_0)
		{
			if (!Module_Unit.IsOverLand(weapon_0))
			{
				PlaySoundEffect(41);
			}
			else
			{
				if (weapon_0.Warheads.Count() <= 0)
				{
					return;
				}
				switch (weapon_0.Type)
				{
				case Weapon._WeaponType.GuidedWeapon:
				case Weapon._WeaponType.IronBomb:
				{
					float dP = weapon_0.Warheads[0].DP;
					if (dP < 50f)
					{
						PlaySoundEffect(34);
					}
					else if (dP < 200f)
					{
						PlaySoundEffect(35);
					}
					else
					{
						PlaySoundEffect(36);
					}
					break;
				}
				case Weapon._WeaponType.Rocket:
				case Weapon._WeaponType.Gun:
					switch (weapon_0.Warheads[0].Caliber)
					{
					case Warhead.WarheadCaliber.Gun_81_150mm:
					case Warhead.WarheadCaliber.Gun_151_200mm:
						PlaySoundEffect(35);
						break;
					default:
						PlaySoundEffect(36);
						break;
					case Warhead.WarheadCaliber.Gun_6_15mm:
					case Warhead.WarheadCaliber.Gun_16_24mm:
					case Warhead.WarheadCaliber.Gun_25_60mm:
					case Warhead.WarheadCaliber.Gun_61_80mm:
						PlaySoundEffect(34);
						break;
					}
					break;
				}
			}
			return;
		}
		switch (weapon_0.Type)
		{
		case Weapon._WeaponType.GuidedWeapon:
		case Weapon._WeaponType.IronBomb:
			if (!unit_0.IsAircraft)
			{
				if (weapon_0.Warheads.Count() != 0)
				{
					float dP2 = weapon_0.Warheads[0].DP;
					if (dP2 < 5f)
					{
						PlaySoundEffect(30);
					}
					else if (dP2 < 50f)
					{
						PlaySoundEffect(31);
					}
					else if (dP2 < 200f)
					{
						PlaySoundEffect(32);
					}
					else
					{
						PlaySoundEffect(33);
					}
				}
			}
			else
			{
				PlaySoundEffect(37);
			}
			break;
		case Weapon._WeaponType.Rocket:
		case Weapon._WeaponType.Gun:
			if (weapon_0.Warheads.Count() > 0)
			{
				switch (weapon_0.Warheads[0].Caliber)
				{
				default:
					PlaySoundEffect(33);
					break;
				case Warhead.WarheadCaliber.Gun_81_150mm:
				case Warhead.WarheadCaliber.Gun_151_200mm:
					PlaySoundEffect(32);
					break;
				case Warhead.WarheadCaliber.Gun_6_15mm:
				case Warhead.WarheadCaliber.Gun_16_24mm:
				case Warhead.WarheadCaliber.Gun_25_60mm:
				case Warhead.WarheadCaliber.Gun_61_80mm:
					PlaySoundEffect(31);
					break;
				}
			}
			break;
		}
	}

	private void method_4(string string_2)
	{
		if (list_0 == null)
		{
			list_0 = new List<MediaPlayer>();
			list_0.AddRange(Enumerable.Range(0, 8).Select((Func<int, MediaPlayer>)([SpecialName] (int s) => new MediaPlayer())));
			list_1 = new List<bool>();
			list_1.AddRange(from s in Enumerable.Range(0, 8)
				select false);
			list_2 = new List<string>();
			list_2.AddRange(from s in Enumerable.Range(0, 8)
				select "");
			int num = 0;
			_Closure$__16-0 closure$__16- = default(_Closure$__16-0);
			do
			{
				closure$__16- = new _Closure$__16-0(closure$__16-);
				closure$__16-.$VB$Me = this;
				closure$__16-.$VB$Local_index = num;
				list_0[num].MediaEnded += closure$__16-._Lambda$__3;
				list_0[num].MediaOpened += closure$__16-._Lambda$__5;
				list_1[closure$__16-.$VB$Local_index] = false;
				num++;
			}
			while (num <= 7);
		}
		if (!list_2.Contains(string_2))
		{
			int num2 = list_1.IndexOf(item: false);
			if (num2 != -1)
			{
				MediaPlayer obj = list_0.Skip(num2).First();
				obj.Volume = double_0;
				obj.Open(new Uri(string_2));
				obj.Play();
				list_2[num2] = string_2;
			}
		}
	}

	private void method_5(string string_2, int int_1)
	{
		if (SimConfiguration.DefaultGamePreferences.GameSounds)
		{
			method_6(string_2);
		}
	}

	internal void PlaySoundEffect(int theEffect)
	{
		if (theEffect >= 0 && theEffect < 52)
		{
			method_6(string_0 + string_1[theEffect]);
		}
	}

	private void method_6(string string_2)
	{
		try
		{
			((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] () =>
			{
				method_4(string_2);
			}));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200421", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	static SoundHandler_Effects()
	{
		Class72.smethod_20();
	}
}
