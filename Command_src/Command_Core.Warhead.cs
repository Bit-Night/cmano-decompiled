using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using CSMaterial;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Warhead : ScenarioObject
{
	public enum WarheadType
	{
		None = 1001,
		HE_BlastFrag = 2001,
		ArmorPiercing = 2002,
		HEAT = 2003,
		Incendiary = 2004,
		Fragmentation = 2005,
		SemiAP = 2006,
		HESH = 2007,
		ContinuousRod = 2008,
		HardTargetPenetrator = 2009,
		FAE = 2010,
		SuperFrag = 2011,
		Fragmentation_ABM = 2012,
		Torpedo = 3001,
		DepthCharge = 3002,
		Torpedo_ASWOptimized = 3003,
		Nuclear = 4001,
		Chemical = 4011,
		Biological = 4021,
		Microwave = 4031,
		Weapon = 5002,
		Aircraft = 5003,
		Ship = 5004,
		Submarine = 5005,
		GroundUnit = 5006,
		Satellite = 5007,
		Cluster_AP = 6001,
		Cluster_AT = 6002,
		Cluster_Penetrator = 6003,
		Cluster_SmartSubs = 6012,
		Landmine_AP = 7001,
		Landmine_AT = 7002,
		LongRodPenetrator = 8001,
		AntiElectrical = 9001,
		Leaflet = 9002,
		Laser_COIL = 9101,
		Laser_CarbonDioxide = 9102,
		Laser_DeuteriumFluoride = 9103,
		Laser_SolidStateFiber = 9104,
		EMP_Directed = 9201,
		EMP_Omni = 9202,
		Kinetic = 9801
	}

	public enum _LaserType
	{
		None,
		Chemical,
		SolidState
	}

	public enum WarheadExplosivesType : short
	{
		None = 1001,
		HE_TNT = 2001,
		HE_HMX = 2002,
		HE_PETN = 2003,
		HE_RDX = 2004,
		HE_C4 = 2005,
		HE_Tritonal = 2006,
		HE_Ammonite = 2007,
		HE_Trinitrophenol = 2008,
		HE_Torpex = 2009,
		HE_Dynamite = 2010,
		HE_PBXN_1XX = 2011,
		HE_AFX_757 = 2012,
		HE_Minol2 = 2013,
		HE_H6 = 2014,
		HE_Destex = 2015,
		HE_Minol1 = 2016,
		HE_HBX1 = 2017,
		HE_HBX3 = 2018,
		HE_Hexanite = 2019,
		HE_Hexamine = 2020,
		HE_Minol3 = 2021,
		HE_Minol4 = 2022,
		HE_PBX = 2023,
		Incendiary_Napalm = 2101,
		Incendiary_WP = 2102,
		Incendiary_FAE = 2103,
		HEAT_LightArmor = 2201,
		HEAT_MediumArmor = 2202,
		HEAT_HeavyArmor = 2203,
		HEAT_SpecialArmor = 2204,
		Fragmentation = 2301,
		ContinuousRod = 2401,
		Nuclear = 4001,
		Chemical = 4011,
		Bacteriological = 4012,
		Submunitions_AntiPersonnel_Fragmentation = 6001,
		Submunitions_AntiTank_LightArmor = 6002,
		Submunitions_AntiTank_MediumArmor = 6003,
		Submunitions_AntiTank_HeavyArmor = 6004,
		Submunitions_AntiTank_SpecialArmor = 6005,
		Submunitions_AntiRunwayPenetrator = 6011,
		Mine_AntiPersonnel_Fragmentation = 7011,
		Mine_AntiTank_LightArmor = 7012,
		Mine_AntiTank_MediumArmor = 7013,
		Mine_AntiTank_HeavyArmor = 7014,
		Mine_AntiTank_SpecialArmor = 7015,
		LongRodPenetrator_LightArmor = 8001,
		LongRodPenetrator_MediumArmor = 8002,
		LongRodPenetrator_HeavyArmor = 8003,
		LongRodPenetrator_SpecialArmor = 8004,
		AntiElectrical_ConductiveFiber = 9001,
		Leaflets = 9002,
		LaserEnergy = 9101,
		KineticEnergy = 9801,
		WeaponPayload = 9998
	}

	public enum WarheadCaliber : short
	{
		None = 1001,
		Gun_6_15mm = 2001,
		Gun_16_24mm = 2002,
		Gun_25_60mm = 2003,
		Gun_61_80mm = 2004,
		Gun_81_150mm = 2005,
		Gun_151_200mm = 2006,
		Gun_201_350mm = 2007,
		Gun_351_450mm = 2008,
		Rocket_6_15mm = 3001,
		Rocket_16_24mm = 3002,
		Rocket_25_60mm = 3003,
		Rocket_61_80mm = 3004,
		Rocket_81_150mm = 3005,
		Rocket_151_200mm = 3006,
		Rocket_201_350mm = 3007,
		Rocket_351_450mm = 3008
	}

	public const float HardTargetPenetratorDepth = 10f;

	public int DBID;

	public float DP;

	public WarheadType Type;

	public WarheadExplosivesType ExplosivesType;

	public WarheadCaliber Caliber;

	public short NumberOfWarheads;

	public float ExplosivesWeight;

	public short ClusterBombDispersionAreaLength;

	public short ClusterBombDispersionAreaWidth;

	public bool Hypothetical;

	private Weapon weapon_0;

	public bool IsAreaEffect
	{
		get
		{
			WarheadType type = Type;
			int result;
			if (type > WarheadType.Chemical)
			{
				if (type <= WarheadType.Cluster_Penetrator)
				{
					if (type == WarheadType.Biological)
					{
						goto IL_0073;
					}
					if ((uint)(type - 6001) > 2u)
					{
						goto IL_006f;
					}
					result = 1;
				}
				else
				{
					if (type == WarheadType.Cluster_SmartSubs)
					{
						goto IL_0073;
					}
					if (type != WarheadType.AntiElectrical)
					{
						goto IL_006f;
					}
					result = 1;
				}
				goto IL_0074;
			}
			int result2;
			if (type > WarheadType.SuperFrag)
			{
				if (type != WarheadType.Nuclear && type != WarheadType.Chemical)
				{
					result2 = 0;
					goto IL_0070;
				}
			}
			else if (type != WarheadType.Fragmentation)
			{
				if ((uint)(type - 2010) > 1u)
				{
					goto IL_006f;
				}
				result = 1;
				goto IL_0074;
			}
			goto IL_0073;
			IL_006f:
			result2 = 0;
			goto IL_0070;
			IL_0073:
			result = 1;
			goto IL_0074;
			IL_0070:
			return (byte)result2 != 0;
			IL_0074:
			return (byte)result != 0;
		}
	}

	public bool IsAreaEffect_Conventional
	{
		get
		{
			int result;
			int result2;
			if (!IsAreaEffect)
			{
				WarheadType type = Type;
				if (type > WarheadType.Chemical)
				{
					if ((uint)(type - 6001) > 2u && type != WarheadType.Cluster_SmartSubs)
					{
						if (type == WarheadType.AntiElectrical)
						{
							result = 1;
							goto IL_0056;
						}
						result2 = 0;
						goto IL_0052;
					}
				}
				else if (type != WarheadType.Fragmentation && (uint)(type - 2010) > 1u && type != WarheadType.Chemical)
				{
					result2 = 0;
					goto IL_0052;
				}
				result = 1;
				goto IL_0056;
			}
			return true;
			IL_0052:
			return (byte)result2 != 0;
			IL_0056:
			return (byte)result != 0;
		}
	}

	public bool IsExplosive
	{
		get
		{
			WarheadType type = Type;
			int result;
			if (type > WarheadType.Torpedo_ASWOptimized)
			{
				if (type == WarheadType.Nuclear)
				{
					goto IL_0071;
				}
				if ((uint)(type - 7001) > 1u)
				{
					goto IL_006d;
				}
				result = 1;
				goto IL_0072;
			}
			switch (type)
			{
			case WarheadType.ArmorPiercing:
			case WarheadType.Incendiary:
			case WarheadType.SuperFrag:
				goto IL_006d;
			case WarheadType.HE_BlastFrag:
			case WarheadType.HEAT:
			case WarheadType.Fragmentation:
			case WarheadType.SemiAP:
			case WarheadType.HESH:
			case WarheadType.ContinuousRod:
			case WarheadType.HardTargetPenetrator:
			case WarheadType.FAE:
			case WarheadType.Fragmentation_ABM:
			case WarheadType.Torpedo:
			case WarheadType.DepthCharge:
			case WarheadType.Torpedo_ASWOptimized:
				goto IL_0071;
			}
			int result2 = 0;
			goto IL_006e;
			IL_006d:
			result2 = 0;
			goto IL_006e;
			IL_0072:
			return (byte)result != 0;
			IL_006e:
			return (byte)result2 != 0;
			IL_0071:
			result = 1;
			goto IL_0072;
		}
	}

	public bool IsIncendiary
	{
		get
		{
			WarheadType type = Type;
			if (type == WarheadType.Incendiary)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsCluster
	{
		get
		{
			int result;
			switch (Type)
			{
			case WarheadType.Cluster_AP:
			case WarheadType.Cluster_AT:
			case WarheadType.Cluster_Penetrator:
				result = 1;
				break;
			case WarheadType.Cluster_SmartSubs:
				result = 1;
				break;
			default:
				return false;
			case WarheadType.SuperFrag:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsNuclear
	{
		get
		{
			if (Type == WarheadType.Nuclear)
			{
				return true;
			}
			if (this.get_CarriedWeapon(theScen) != null && weapon_0.IsNuke.Value)
			{
				return true;
			}
			bool result = default(bool);
			return result;
		}
	}

	public bool IsEMP
	{
		get
		{
			if (Type != WarheadType.EMP_Directed)
			{
				return Type == WarheadType.EMP_Omni;
			}
			return true;
		}
	}

	public bool IsAirburst
	{
		get
		{
			if (!IsCluster)
			{
				if (Information.IsNothing((object)TargetAU))
				{
					return false;
				}
				if (ParentWeapon.IsMissile && ParentWeapon.IsAAWCapable && !Information.IsNothing((object)TargetAU) && (TargetAU.IsShip || TargetAU.IsFacility) && TargetAU.VisualSizeClass > GlobalVariables.TargetVisualSizeClass.VSmall)
				{
					return false;
				}
				int result;
				switch (Type)
				{
				case WarheadType.Cluster_AP:
				case WarheadType.Cluster_AT:
				case WarheadType.Cluster_Penetrator:
					result = 1;
					break;
				case WarheadType.EMP_Omni:
					result = 1;
					break;
				case WarheadType.FAE:
				case WarheadType.SuperFrag:
					result = 1;
					break;
				default:
					if (this.get_IsNuclear(ParentWeapon.ParentScen))
					{
						if (TargetAU.IsHardTarget)
						{
							return false;
						}
						return true;
					}
					if (ParentWeapon.IsAAWCapable)
					{
						WarheadType type = Type;
						int result2;
						if (type != WarheadType.Fragmentation && type != WarheadType.ContinuousRod)
						{
							if (type != WarheadType.Fragmentation_ABM)
							{
								goto IL_00e2;
							}
							result2 = 1;
						}
						else
						{
							result2 = 1;
						}
						return (byte)result2 != 0;
					}
					goto IL_00e2;
				case WarheadType.Fragmentation:
				case WarheadType.Cluster_SmartSubs:
					{
						result = 1;
						break;
					}
					IL_00e2:
					return false;
				}
				return (byte)result != 0;
			}
			return true;
		}
	}

	public Weapon CarriedWeapon
	{
		get
		{
			if (Type == WarheadType.Weapon)
			{
				if (weapon_0 == null)
				{
					weapon_0 = theScen.Cache_GetWeapon((int)Math.Round(DP));
				}
				return weapon_0;
			}
			Weapon result = default(Weapon);
			return result;
		}
	}

	public _LaserType LaserType
	{
		get
		{
			switch (Type)
			{
			case WarheadType.Laser_DeuteriumFluoride:
			case WarheadType.Laser_SolidStateFiber:
				return _LaserType.SolidState;
			default:
				return _LaserType.None;
			case WarheadType.Laser_COIL:
			case WarheadType.Laser_CarbonDioxide:
				return _LaserType.Chemical;
			}
		}
	}

	public Warhead()
	{
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		if (!Information.IsNothing((object)weapon_0))
		{
			weapon_0.ResetIDs();
		}
	}

	public void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("Warhead");
			theWriter.WriteElementString("DBID", DBID.ToString());
			theWriter.WriteElementString("ID", ObjectID);
			theWriter.WriteElementString("DP", XmlConvert.ToString(DP));
			XmlWriter obj = theWriter;
			int type = (int)Type;
			obj.WriteElementString("Type", type.ToString());
			XmlWriter obj2 = theWriter;
			type = (int)ExplosivesType;
			obj2.WriteElementString("ExpType", type.ToString());
			XmlWriter obj3 = theWriter;
			type = (int)Caliber;
			obj3.WriteElementString("Cal", type.ToString());
			theWriter.WriteElementString("NOW", NumberOfWarheads.ToString());
			theWriter.WriteElementString("CBDAL", ClusterBombDispersionAreaLength.ToString());
			theWriter.WriteElementString("CBDAW", ClusterBombDispersionAreaWidth.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100746", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Warhead FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		Warhead result;
		try
		{
			Warhead warhead = new Warhead();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "DP":
					warhead.DP = XmlConvert.ToSingle(val.InnerText);
					break;
				case "CBDAW":
					warhead.ClusterBombDispersionAreaWidth = Conversions.ToShort(val.InnerText);
					break;
				case "CBDAL":
					warhead.ClusterBombDispersionAreaLength = Conversions.ToShort(val.InnerText);
					break;
				case "ID":
					if (!theDictionary.ContainsKey(val.InnerText))
					{
						warhead.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(warhead.ObjectID, warhead);
						break;
					}
					result = (Warhead)theDictionary[val.InnerText];
					goto end_IL_0001;
				case "Cal":
				case "Caliber":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						warhead.Caliber = (WarheadCaliber)Conversions.ToShort(val.InnerText);
					}
					else
					{
						warhead.Caliber = (WarheadCaliber)Enum.Parse(typeof(WarheadCaliber), val.InnerText, ignoreCase: true);
					}
					break;
				case "DBID":
					warhead.DBID = Conversions.ToInteger(val.InnerText);
					break;
				case "ExplosivesType":
				case "ExpType":
					warhead.ExplosivesType = (WarheadExplosivesType)Conversions.ToShort(val.InnerText);
					break;
				case "Type":
					if (!Versioned.IsNumeric((object)val.InnerText))
					{
						warhead.Type = (WarheadType)Enum.Parse(typeof(WarheadType), val.InnerText, ignoreCase: true);
					}
					else
					{
						warhead.Type = (WarheadType)Conversions.ToInteger(val.InnerText);
					}
					break;
				case "NumberOfWarheads":
				case "NOW":
					warhead.NumberOfWarheads = (short)Conversions.ToInteger(val.InnerText);
					break;
				}
			}
			result = warhead;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100747", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Warhead();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float[] GetCombatPower(float[] ArrayByRef)
	{
		Array.Clear(ArrayByRef, 0, ArrayByRef.Length);
		AGU_CONFIG instance = AGU_CONFIG.Instance;
		float[,] combatMatrix_Offense = instance.CombatMatrix_Offense;
		int num = Enum.GetValues(typeof(CombatPowerType)).Length - 1;
		for (int i = 0; i <= num; i++)
		{
			ArrayByRef[i] = DP * combatMatrix_Offense[instance.WarheadCaliber_IndexMapping[Caliber], i];
		}
		return ArrayByRef;
	}

	public double ClusterCoverageArea(WarheadType theWarheadType, double DP)
	{
		if (ClusterBombDispersionAreaLength == 0 && ClusterBombDispersionAreaWidth == 0)
		{
			double num = 51.36986301369863;
			return theWarheadType switch
			{
				WarheadType.Cluster_AP => num * DP * 1.2, 
				WarheadType.Cluster_AT => num * DP * 0.8, 
				WarheadType.Cluster_Penetrator => num * DP * 0.4, 
				_ => throw new NotImplementedException(), 
			};
		}
		return (short)(ClusterBombDispersionAreaLength * ClusterBombDispersionAreaWidth);
	}

	public Warhead(string theName, float theDP, WarheadType theType, WarheadExplosivesType theExplosivesType, WarheadCaliber theCaliber, string theNumberOfWarheads = "")
	{
		try
		{
			Name = theName;
			DP = theDP;
			Type = theType;
			ExplosivesType = theExplosivesType;
			if (Type == WarheadType.Nuclear)
			{
				DP = 1000000f * DP;
			}
			Caliber = theCaliber;
			if (!string.IsNullOrEmpty(theNumberOfWarheads))
			{
				NumberOfWarheads = (short)Conversions.ToInteger(theNumberOfWarheads);
			}
			else
			{
				NumberOfWarheads = 1;
			}
			if (Type == WarheadType.Cluster_AP || Type == WarheadType.Cluster_AT || Type == WarheadType.Cluster_Penetrator || Type == WarheadType.Cluster_SmartSubs || Type == WarheadType.SuperFrag)
			{
				DP *= NumberOfWarheads;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100748", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static double BombletDamageAtThisTarget(Platform theTarget, double FullDP, double FullEffectArea, float BombletScatterHeading)
	{
		double result;
		try
		{
			_ = theTarget.VisualSizeClass;
			if (theTarget.IsFacility && theTarget.AirFacilities_ReadOnly.Length > 0 && theTarget.AirFacilities_ReadOnly[0].IsRunwayOrPad())
			{
				float num = MathFunctions.AngularDifference(theTarget.CurrentHeading, BombletScatterHeading);
				result = FullDP * 0.1 + FullDP * 0.9 * (1.0 - Math.Abs(Math.Sin((double)num * CSMath.PI_dividedBy_180)));
			}
			else
			{
				float num2 = (float)((double)theTarget.FlatSurfaceArea_m2 / FullEffectArea);
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				result = FullDP * (double)num2;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100749", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static float BombletDamageAtThisAimpoint(Mount theTarget, double FullDP, int ClusterSubmunitionQty, float ClusterSubmunitionYield, double FullEffectArea, WarheadType theWarheadType, WarheadExplosivesType theExplosiveType)
	{
		float result;
		try
		{
			int maxValue = (int)Math.Round(FullEffectArea / 10.0);
			bool flag = ((theWarheadType != WarheadType.Cluster_SmartSubs) ? (GameGeneral.GlobalRNG.Next(1, maxValue) <= ClusterSubmunitionQty) : (GameGeneral.GlobalRNG.Next(1, 101) > 30));
			float num = ((!flag) ? ((float)(FullDP / FullEffectArea)) : ClusterSubmunitionYield);
			switch (theExplosiveType)
			{
			case WarheadExplosivesType.Submunitions_AntiRunwayPenetrator:
				num *= 5f;
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_LightArmor:
				num = (float)((double)num * 1.5);
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_MediumArmor:
				num *= 2f;
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_HeavyArmor:
				num *= 3f;
				break;
			case WarheadExplosivesType.Submunitions_AntiTank_SpecialArmor:
				num *= 4f;
				break;
			}
			num = (float)((double)num * ((double)GameGeneral.GlobalRNG.Next(8, 13) / 10.0));
			result = (float)Math.Min(num * 100f, FullDP);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100750", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static float FragDamageAtThisDistance(double TargetLatitude, double TargetLongitude, double DistanceFromTarget_nm, WarheadType WarheadType, double OriginalYield, Weapon.DetonationMedium theTranmissionMedium, bool LandTypeEffectsEnabled, Scenario theScen)
	{
		float result;
		try
		{
			switch (WarheadType)
			{
			case WarheadType.HE_BlastFrag:
				OriginalYield = OriginalYield;
				break;
			default:
				result = 0f;
				goto end_IL_0001;
			case WarheadType.Fragmentation_ABM:
				OriginalYield *= 2.0;
				break;
			case WarheadType.Fragmentation:
			case WarheadType.SuperFrag:
				break;
			}
			float cutoffRange_Frag_nm = Explosion.GetCutoffRange_Frag_nm(OriginalYield, Weapon.DetonationMedium.Air, WarheadType);
			if (DistanceFromTarget_nm > (double)cutoffRange_Frag_nm)
			{
				result = 0f;
			}
			else
			{
				double num = Math.Pow((float)(((double)cutoffRange_Frag_nm - DistanceFromTarget_nm) / (double)cutoffRange_Frag_nm), 2.0);
				if (LandTypeEffectsEnabled && Terrain.GetElevation(TargetLatitude, TargetLongitude, RequestIsFromGUI: false, theScen) > 0)
				{
					switch (LandCover.GetLandCoverAtThisPoint(TargetLatitude, TargetLongitude, theScen))
					{
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case LandCover.LandCoverType.Urban_CloseInnerCity:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedHighRise:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_AttachedHouses:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_CloseIndustrial:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedApartments:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_DetachedHouses:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_SpacedIndustrial:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Urban_ShantyTown:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
					case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
					case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
					case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
					case LandCover.LandCoverType.Mixed_forest:
						num *= 0.5;
						break;
					case LandCover.LandCoverType.Closed_shrublands:
					case LandCover.LandCoverType.Open_shrublands:
						num *= 0.75;
						break;
					case LandCover.LandCoverType.Woody_savannas:
					case LandCover.LandCoverType.Savannas:
						num *= 0.9;
						break;
					case LandCover.LandCoverType.UrbanAndBuiltUp:
						num *= 0.25;
						break;
					case LandCover.LandCoverType.Croplands:
					case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
						num *= 0.85;
						break;
					case LandCover.LandCoverType.Water:
					case LandCover.LandCoverType.Grasslands:
					case LandCover.LandCoverType.Permanent_wetlands:
					case LandCover.LandCoverType.SnowAndIce:
					case LandCover.LandCoverType.BarrenOrSparselyVegetated:
						break;
					}
				}
				double num2 = OriginalYield * num;
				if (num2 > OriginalYield)
				{
					num2 = OriginalYield;
				}
				result = (float)num2;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100751", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static float BlastDamageAtThisDistance(double TargetLatitude, double TargetLongitude, double DistanceFromTarget_nm, double TargetsOriginalDP, WarheadType WarheadType, double OriginalYield, Weapon.DetonationMedium theTranmissionMedium, bool LandTypeEffectsEnabled, Scenario theScen)
	{
		double num = 0.0;
		float result;
		try
		{
			double num2;
			switch (WarheadType)
			{
			case WarheadType.HardTargetPenetrator:
				num2 = OriginalYield;
				break;
			case WarheadType.HE_BlastFrag:
				num2 = OriginalYield;
				break;
			case WarheadType.HEAT:
				num2 = OriginalYield / 5.0;
				break;
			case WarheadType.Fragmentation:
				num2 = OriginalYield / 3.0;
				break;
			default:
				num2 = OriginalYield;
				break;
			case WarheadType.Nuclear:
				num2 = OriginalYield / 2.0;
				break;
			case WarheadType.Torpedo:
			case WarheadType.DepthCharge:
				num2 = OriginalYield;
				break;
			}
			num += num2;
			if (num == 0.0)
			{
				result = 0f;
			}
			else if (DistanceFromTarget_nm <= 0.0005399568034557236)
			{
				result = (float)num;
			}
			else
			{
				double num3 = Explosion.GetCutoffRange_Blast_nm(num, theTranmissionMedium);
				if (DistanceFromTarget_nm > num3)
				{
					result = 0f;
				}
				else
				{
					double x = 1.0 - DistanceFromTarget_nm / num3;
					Weapon.DetonationMedium detonationMedium = theTranmissionMedium;
					double num4 = ((detonationMedium != Weapon.DetonationMedium.Underwater) ? Math.Pow(x, 2.0) : Math.Pow(x, 3.0));
					if (LandTypeEffectsEnabled && Terrain.GetElevation(TargetLatitude, TargetLongitude, RequestIsFromGUI: false, theScen) > 0)
					{
						switch (LandCover.GetLandCoverAtThisPoint(TargetLatitude, TargetLongitude, theScen))
						{
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							break;
						case LandCover.LandCoverType.Urban_CloseInnerCity:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_SpacedHighRise:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_AttachedHouses:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_CloseIndustrial:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_SpacedApartments:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_DetachedHouses:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_SpacedIndustrial:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Urban_ShantyTown:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Evergreen_Needleleaf_forest:
						case LandCover.LandCoverType.Evergreen_Broadleaf_forest:
						case LandCover.LandCoverType.Deciduous_Needleleaf_forest:
						case LandCover.LandCoverType.Deciduous_Broadleaf_forest:
						case LandCover.LandCoverType.Mixed_forest:
							num4 *= 0.5;
							break;
						case LandCover.LandCoverType.Closed_shrublands:
						case LandCover.LandCoverType.Open_shrublands:
							num4 *= 0.75;
							break;
						case LandCover.LandCoverType.Woody_savannas:
						case LandCover.LandCoverType.Savannas:
							num4 *= 0.9;
							break;
						case LandCover.LandCoverType.UrbanAndBuiltUp:
							num4 *= 0.25;
							break;
						case LandCover.LandCoverType.Croplands:
						case LandCover.LandCoverType.CroplandNaturalVegetationMosaic:
							num4 *= 0.85;
							break;
						case LandCover.LandCoverType.Water:
						case LandCover.LandCoverType.Grasslands:
						case LandCover.LandCoverType.Permanent_wetlands:
						case LandCover.LandCoverType.SnowAndIce:
						case LandCover.LandCoverType.BarrenOrSparselyVegetated:
							break;
						}
					}
					result = (float)Math.Min(num * num4, OriginalYield);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100752", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Warhead()
	{
		Class72.smethod_20();
	}
}
