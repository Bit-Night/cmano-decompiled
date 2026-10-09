using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

[StandardModule]
public sealed class WeaponCommMatrix
{
	public enum IFCVariant
	{
		None,
		PrecisionCue,
		LaunchOnRemote,
		EngageOnRemote,
		ForwardPass,
		RemoteFire,
		PreferredShooterDetermination
	}

	public class WeaponCommEntry
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private CommDevice.EnumCommQuality enumCommQuality_0;

		[CompilerGenerated]
		private CommDevice.EnumCommLatency enumCommLatency_0;

		[CompilerGenerated]
		private Weapon.WeaponGuidanceType weaponGuidanceType_0;

		[CompilerGenerated]
		private List<IFCVariant> list_0;

		public Weapon._WeaponType WeaponType { get; set; }

		public string WeaponName
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public CommDevice.EnumCommQuality MinBandwidth
		{
			[CompilerGenerated]
			get
			{
				return enumCommQuality_0;
			}
			[CompilerGenerated]
			set
			{
				enumCommQuality_0 = value;
			}
		}

		public CommDevice.EnumCommLatency MinLatency
		{
			[CompilerGenerated]
			get
			{
				return enumCommLatency_0;
			}
			[CompilerGenerated]
			set
			{
				enumCommLatency_0 = value;
			}
		}

		public Weapon.WeaponGuidanceType Category
		{
			[CompilerGenerated]
			get
			{
				return weaponGuidanceType_0;
			}
			[CompilerGenerated]
			set
			{
				weaponGuidanceType_0 = value;
			}
		}

		public List<IFCVariant> SupportedIFC
		{
			[CompilerGenerated]
			get
			{
				return list_0;
			}
			[CompilerGenerated]
			set
			{
				list_0 = value;
			}
		}

		public WeaponCommEntry(Weapon._WeaponType theWeaponType, CommDevice.EnumCommQuality quality, CommDevice.EnumCommLatency latency, Weapon.WeaponGuidanceType theWpnGuidanceType, List<IFCVariant> list_1)
		{
			WeaponType = theWeaponType;
			WeaponName = theWeaponType.ToString();
			MinBandwidth = quality;
			MinLatency = latency;
			Category = theWpnGuidanceType;
			SupportedIFC = list_1;
		}

		static WeaponCommEntry()
		{
			Class72.smethod_20();
		}
	}

	private static List<WeaponCommEntry> list_0;

	private static List<WeaponCommEntry> smethod_0()
	{
		if (list_0 == null)
		{
			list_0 = smethod_1();
		}
		return list_0;
	}

	private static List<WeaponCommEntry> smethod_1()
	{
		return new List<WeaponCommEntry>
		{
			new WeaponCommEntry(Weapon._WeaponType.None, CommDevice.EnumCommQuality.None, CommDevice.EnumCommLatency.None, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.GuidedWeapon, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.ForwardPass,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.GuidedProjectile, CommDevice.EnumCommQuality.BMD, CommDevice.EnumCommLatency.Instnt, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.ContactBomb_Suicide, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.ContactBomb_Sabotage, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.UAV_Expendable, CommDevice.EnumCommQuality.BMD, CommDevice.EnumCommLatency.Instnt, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.RemoteFire,
				IFCVariant.ForwardPass,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.BallisticMissile, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Inertial, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.RV, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Inertial, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.GlideVehicle, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.Inertial_Plus_Active, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.HGV, CommDevice.EnumCommQuality.BMD, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.HypersonicCruiseMissile, CommDevice.EnumCommQuality.BMD, CommDevice.EnumCommLatency.Instnt, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.Laser, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.BMD, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.EngageOnRemote,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.Microwave, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.BMD, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.EngageOnRemote,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.LaserDazzler, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Instnt, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.Rocket, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.IronBomb, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.Gun, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.SmallArms, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.Dispenser, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.Decoy_Expendable, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.Decoy_Towed, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.Decoy_Vehicle, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.Torpedo, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.DepthCharge, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.GuidedDepthCharge, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote,
				IFCVariant.RemoteFire,
				IFCVariant.PreferredShooterDetermination
			}),
			new WeaponCommEntry(Weapon._WeaponType.Sonobuoy, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote
			}),
			new WeaponCommEntry(Weapon._WeaponType.BottomMine, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.MooredMine, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.FloatingMine, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.MovingMine, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.RisingMine, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.DriftingMine, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.AttachedMine, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.DummyMine, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.SensorPod, CommDevice.EnumCommQuality.BMD, CommDevice.EnumCommLatency.Fast, Weapon.WeaponGuidanceType.CommandGuided_Datalinked, new List<IFCVariant>
			{
				IFCVariant.PrecisionCue,
				IFCVariant.LaunchOnRemote,
				IFCVariant.EngageOnRemote
			}),
			new WeaponCommEntry(Weapon._WeaponType.DropTank, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.BuddyStore, CommDevice.EnumCommQuality.AAW, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.FerryTank, CommDevice.EnumCommQuality.GLoc, CommDevice.EnumCommLatency.Slow, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant>()),
			new WeaponCommEntry(Weapon._WeaponType.HeliTowedPackage, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Passive, new List<IFCVariant> { IFCVariant.PrecisionCue }),
			new WeaponCommEntry(Weapon._WeaponType.PalletWeapon, CommDevice.EnumCommQuality.TacP, CommDevice.EnumCommLatency.Norm, Weapon.WeaponGuidanceType.Undetermined, new List<IFCVariant> { IFCVariant.PrecisionCue })
		};
	}

	public static WeaponCommEntry GetWMatrixEntry(Weapon._WeaponType wt)
	{
		return smethod_0().FirstOrDefault([SpecialName] (WeaponCommEntry e) => e.WeaponType == wt);
	}

	public static int GetMinBandwidth(Weapon._WeaponType wt)
	{
		return (int)(GetWMatrixEntry(wt)?.MinBandwidth ?? CommDevice.EnumCommQuality.None);
	}

	public static int GetMinLatency(Weapon._WeaponType wt)
	{
		return (int)(GetWMatrixEntry(wt)?.MinLatency ?? CommDevice.EnumCommLatency.None);
	}

	public static bool CanEngageCOMMLimitations(Weapon._WeaponType wt, int linkBandwidth, int linkLatency)
	{
		WeaponCommEntry wMatrixEntry = GetWMatrixEntry(wt);
		if (wMatrixEntry == null)
		{
			int result;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				result = 1;
			}
			else
			{
				result = 1;
			}
			return (byte)result != 0;
		}
		bool result2 = false;
		if (linkBandwidth >= (int)wMatrixEntry.MinBandwidth && linkLatency >= (int)wMatrixEntry.MinLatency)
		{
			result2 = true;
		}
		return result2;
	}

	public static List<IFCVariant> GetAvailableIFCVariants(Weapon._WeaponType theWeaponType, int linkBandwidth, int linkLatency)
	{
		if (CanEngageCOMMLimitations(theWeaponType, linkBandwidth, linkLatency))
		{
			WeaponCommEntry wMatrixEntry = GetWMatrixEntry(theWeaponType);
			if (wMatrixEntry == null)
			{
				return new List<IFCVariant>();
			}
			return wMatrixEntry.SupportedIFC;
		}
		return new List<IFCVariant>();
	}

	static WeaponCommMatrix()
	{
		Class72.smethod_20();
	}
}
