using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using CSMaterial.ExWorldWind;
using MathNet.Spatial.Euclidean;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Module_Unit
{
	public class Unit : ScenarioObject, IRoadSystemAgent
	{
		public enum RemoteSimEntityTypeEnum : short
		{
			Local,
			DIS,
			AIS
		}

		public enum LOSCheckResult
		{
			Undefined = 0,
			Success = 1,
			Fail_OutOfHorizon = 2,
			Fail_BlockedByTerrain = 3,
			Fail_BlockedByCloud = 4,
			Fail_Other = 9999
		}

		internal bool IsWeapon;

		private float float_0;

		private float float_1;

		private float float_2;

		protected float _Attitude_Pitch;

		private float float_3;

		protected float _DesiredPitch;

		private float float_4;

		protected float _ImpactAltitude;

		public float _LastTick_DeltaTime;

		public float _LastTick_CurrentSpeed;

		public float _LastTick_CurrentHeading;

		public float _LastTick_CurrentAltitude;

		public float _LastTick_VerticalSpeed;

		public float _LastTick_Attitude_Pitch;

		public float _LastTick_Attitude_Roll;

		public double _LastTick_Latitude;

		public double _LastTick_Longitude;

		protected double _Latitude;

		protected double _Longitude;

		private double? nullable_0;

		private double? nullable_1;

		private float? nullable_2;

		private double? nullable_3;

		private double? nullable_4;

		private double? nullable_5;

		private double? nullable_6;

		public List<string> ActiveEnterAreaTriggers;

		public TDictionary<string, DateTime> ActiveRemainAreaTriggers;

		public string UnitClass;

		private List<RangeSymbol> list_0;

		protected Side _UnitSide;

		public string Message;

		public Lazy<TDictionary<int, bool>> Cache_IsInsideArea;

		private List<Explosion> list_1;

		private EndgameReport AoZyPkstsuR;

		public RemoteSimEntityTypeEnum RemoteSimEntityType;

		internal float DeadReckoning_VerticalSpeed;

		public string CustomIcon;

		internal float? CurrentVerticalRate_mpersec;

		public RoadSystem.Node NodeA;

		public RoadSystem.Node NodeB;

		public List<RoadSystem.Node> RoadNetworkPath;

		public bool RoadNetworkNeverStop;

		private float float_5;

		public bool PlayerIsPlottingCourse;

		protected short _SupportsAttitudePitch;

		private int? nullable_7;

		private int? nullable_8;

		private float? gkoyPgDgTi9;

		public Geopoint_Struct Location => new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));

		public EndgameReport EndgameReport
		{
			get
			{
				if (AoZyPkstsuR == null)
				{
					AoZyPkstsuR = new EndgameReport(this);
				}
				return AoZyPkstsuR;
			}
		}

		public List<Explosion> GeneratedParentExplosions
		{
			get
			{
				if (list_1 == null)
				{
					list_1 = new List<Explosion>();
				}
				return list_1;
			}
		}

		public bool IsVehicleDecoy
		{
			get
			{
				if (!IsWeapon)
				{
					return false;
				}
				if (((Weapon)this).Type == Weapon._WeaponType.Decoy_Vehicle)
				{
					return true;
				}
				return false;
			}
		}

		public bool IsBomb
		{
			get
			{
				if (IsWeapon)
				{
					Weapon weapon = (Weapon)this;
					int result;
					if (weapon.Type != Weapon._WeaponType.IronBomb && weapon.Type != Weapon._WeaponType.ContactBomb_Sabotage)
					{
						if (weapon.Type != Weapon._WeaponType.ContactBomb_Suicide)
						{
							if (weapon.Type == Weapon._WeaponType.GuidedWeapon || weapon.Type == Weapon._WeaponType.GuidedProjectile)
							{
								foreach (Engine item in weapon.Propulsion)
								{
									if (item.Type == Engine.EngineType.WeaponCoast)
									{
										return true;
									}
								}
							}
							goto IL_00a9;
						}
						result = 1;
					}
					else
					{
						result = 1;
					}
					return (byte)result != 0;
				}
				goto IL_00a9;
				IL_00a9:
				return false;
			}
		}

		public bool IsMissile
		{
			get
			{
				int result;
				if (IsWeapon)
				{
					Weapon weapon = (Weapon)this;
					if (weapon.Type == Weapon._WeaponType.GuidedWeapon)
					{
						goto IL_003e;
					}
					if (weapon.IsBallisticMissile)
					{
						result = 1;
					}
					else
					{
						if (weapon.IsReEntryVehicle)
						{
							goto IL_003e;
						}
						if (!weapon.IsHGV)
						{
							return false;
						}
						result = 1;
					}
					goto IL_003f;
				}
				return false;
				IL_003f:
				return (byte)result != 0;
				IL_003e:
				result = 1;
				goto IL_003f;
			}
		}

		public RoadSystem.Node DestinationNode
		{
			get
			{
				if (IsAttachedToRoadSystem)
				{
					return NodeB;
				}
				return null;
			}
		}

		public float RoadSystemProgress
		{
			get
			{
				return float_5;
			}
			set
			{
				float_5 = value;
				RefreshRoadSystemPosition();
				if (!(float_5 >= 1f) || NodeB == null)
				{
					return;
				}
				NodeA = NodeB;
				float_5 = 0f;
				RoadSystem.Node destinationNode = DestinationNode;
				if (RoadNetworkPath.Count > 0)
				{
					RoadNetworkPath.RemoveAt(0);
				}
				if (RoadNetworkPath.Count > 0)
				{
					NodeB = RoadNetworkPath.ElementAt(0);
				}
				else if (RoadNetworkNeverStop && destinationNode.ConnectedSegments.Count > 1)
				{
					List<RoadSystem.Node> neighborNode = destinationNode.GetNeighborNode();
					if (neighborNode.Count > 0)
					{
						NodeB = neighborNode.ElementAt(GlobalSingleton.GetInstance().Random.Next(0, neighborNode.Count));
					}
				}
				else
				{
					DetachFromRoadSystem();
				}
			}
		}

		public RoadSystem.Node GetClosestAttachedRoadSystemNode
		{
			get
			{
				RoadSystem.Node result = null;
				double num = double.MaxValue;
				if (NodeA != null)
				{
					result = NodeA;
					num = Math2.CalcDist_Angular(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), NodeA.Coordinates.Latitude, NodeA.Coordinates.Longitude);
				}
				if (NodeB != null)
				{
					double num2 = Math2.CalcDist_Angular(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), NodeB.Coordinates.Latitude, NodeB.Coordinates.Longitude);
					if (num2 < num)
					{
						num = num2;
						result = NodeB;
					}
				}
				return result;
			}
		}

		public bool IsAttachedToRoadSystem
		{
			get
			{
				if (NodeA != null)
				{
					return NodeB != null;
				}
				return false;
			}
		}

		public bool IsAttachedToDefensiveSystem
		{
			get
			{
				RoadSystem.Segment currentRoadSegment = GetCurrentRoadSegment();
				if (currentRoadSegment == null)
				{
					return false;
				}
				return currentRoadSegment.Type.Type == RoadSystem.SegmentEnum.Fortifications;
			}
		}

		public virtual string AnnexAndDBID => "N/A";

		public virtual bool UseAerialUnitUI => false;

		public virtual bool UseSubmerisbleUnitUI => false;

		public virtual bool SupportsAltitude_Control => false;

		public virtual bool SupportsAttitude_Pitch => false;

		public virtual bool SupportsAttitude_Roll => false;

		public virtual Side UnitSide
		{
			get
			{
				return _UnitSide;
			}
			set
			{
				_UnitSide = value;
			}
		}

		public virtual float CurrentHeading
		{
			get
			{
				return float_0;
			}
			set
			{
				if (float.IsNaN(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					float_0 = value;
				}
			}
		}

		public virtual int MastHeight_Radar => 0;

		public virtual int MastHeight_Visual => 0;

		public int LandElevation
		{
			get
			{
				int result;
				try
				{
					int? num = nullable_7;
					if (!IsGroup)
					{
						if (Force || !num.HasValue)
						{
							num = Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI, CurrentScen);
						}
						goto IL_00de;
					}
					Group obj = (Group)this;
					if (obj.Type != Group.GroupType.AirGroup)
					{
						if (obj.Type != Group.GroupType.SubGroup)
						{
							num = Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI, CurrentScen);
							goto IL_00de;
						}
						if (!Information.IsNothing((object)obj.GroupLead))
						{
							Submarine submarine = (Submarine)obj.GroupLead;
							num = ((Unit)submarine).get_LandElevation(AGL: false, RequestIsFromGUI, Force, CurrentScen);
							goto IL_00de;
						}
						result = 0;
					}
					else
					{
						if (!Information.IsNothing((object)obj.GroupLead))
						{
							Aircraft aircraft = (Aircraft)obj.GroupLead;
							num = ((Unit)aircraft).get_LandElevation(AGL: false, RequestIsFromGUI, Force, CurrentScen);
							goto IL_00de;
						}
						result = 0;
					}
					goto end_IL_0001;
					IL_00de:
					if (!num.HasValue)
					{
						num = Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI, CurrentScen);
					}
					nullable_7 = num;
					if (!AGL)
					{
						goto IL_0143;
					}
					int? num2 = num;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() < 0)) != true)
					{
						goto IL_0143;
					}
					result = 0;
					goto end_IL_0001;
					IL_0143:
					result = num.Value;
					end_IL_0001:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200295", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					int elevation = Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI, CurrentScen);
					nullable_7 = elevation;
					result = elevation;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public int LandElevation_next
		{
			get
			{
				int? num = nullable_8;
				if (!num.HasValue)
				{
					Scenario parentScen = default(Scenario);
					if (IsWeapon)
					{
						parentScen = ((Weapon)this).ParentScen;
					}
					else if (this.get_UnitSide(SetSideOnly: false) != null)
					{
						parentScen = this.get_UnitSide(SetSideOnly: false).ParentScen;
					}
					num = Terrain.GetElevation(this.get_Latitude_next(elapsedTime), this.get_Longitude_next(elapsedTime), RequestIsFromGUI: false, parentScen);
				}
				nullable_8 = num;
				if (AGL)
				{
					int? num2 = num;
					if (((!num2.HasValue) ? ((bool?)null) : new bool?(num2.GetValueOrDefault() < 0)) == true)
					{
						return 0;
					}
				}
				return num.Value;
			}
		}

		public double Longitude_next
		{
			get
			{
				if (!nullable_3.HasValue)
				{
					method_0(elapsedTime);
				}
				return nullable_3.Value;
			}
		}

		public double Latitude_next
		{
			get
			{
				if (!nullable_4.HasValue)
				{
					method_0(elapsedTime);
				}
				return nullable_4.Value;
			}
		}

		public virtual float CurrentAltitude_AGL
		{
			get
			{
				float result;
				try
				{
					float? num = gkoyPgDgTi9;
					if (num.HasValue)
					{
						result = num.Value;
					}
					else if (!IsGroup)
					{
						if (!IsContact())
						{
							if (IsAircraft)
							{
								num = (IsOverLand(this) ? new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ((Aircraft)this).ParentScen)) : new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
							}
							else
							{
								if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -11000f)
								{
									this.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
								}
								num = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude(GlobalVariables.ObjectTrue), this.get_Longitude(GlobalVariables.ObjectTrue), RequestIsFromGUI: false, this.get_UnitSide(SetSideOnly: false)?.ParentScen);
							}
							goto IL_02fe;
						}
						Contact contact = (Contact)this;
						if (contact.ActualUnit != null)
						{
							if (contact.ActualUnit.IsAircraft)
							{
								num = ((!IsOverLand(this)) ? new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) : new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ((Aircraft)contact.ActualUnit).ParentScen)));
							}
							else if (contact.ActualUnit.IsWeapon)
							{
								num = (IsOverLand(this) ? new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ((Weapon)contact.ActualUnit).ParentScen)) : (IsTorpedo ? new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, ((Torpedo)contact.ActualUnit).ParentScen)) : new float?(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))));
							}
							else
							{
								if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < -11000f)
								{
									this.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, 0f);
								}
								num = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, this.get_UnitSide(SetSideOnly: false)?.ParentScen);
							}
							goto IL_02fe;
						}
						result = 0f;
					}
					else
					{
						Group obj = (Group)this;
						if (obj.Type != Group.GroupType.AirGroup)
						{
							if (obj.Type != Group.GroupType.SubGroup)
							{
								num = 0f;
								goto IL_02fe;
							}
							if (!Information.IsNothing((object)obj.GroupLead))
							{
								Submarine submarine = (Submarine)obj.GroupLead;
								num = submarine.CurrentAltitude_AGL;
								goto IL_02fe;
							}
							result = 0f;
						}
						else
						{
							if (!Information.IsNothing((object)obj.GroupLead))
							{
								Aircraft aircraft = (Aircraft)obj.GroupLead;
								num = aircraft.CurrentAltitude_AGL;
								goto IL_02fe;
							}
							result = 0f;
						}
					}
					goto end_IL_0001;
					IL_02fe:
					if (!num.HasValue)
					{
						num = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, this.get_UnitSide(SetSideOnly: false).ParentScen);
					}
					gkoyPgDgTi9 = num;
					result = num.Value;
					end_IL_0001:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200320", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					_ = Debugger.IsAttached;
					float num2 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - (float)Terrain.GetElevation(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), RequestIsFromGUI: false, this.get_UnitSide(SetSideOnly: false)?.ParentScen);
					gkoyPgDgTi9 = num2;
					result = num2;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public virtual float CurrentAltitude
		{
			get
			{
				return float_2;
			}
			set
			{
				if (float_2 != value)
				{
					gkoyPgDgTi9 = null;
				}
				float_2 = value;
			}
		}

		public virtual float ImpactAltitude
		{
			get
			{
				return _ImpactAltitude;
			}
			set
			{
				value = (float)Math.Round(value, 2);
				_ImpactAltitude = value;
			}
		}

		public virtual float Attitude_Pitch
		{
			get
			{
				return _Attitude_Pitch;
			}
			set
			{
				_Attitude_Pitch = value;
			}
		}

		public virtual float Attitude_Roll
		{
			get
			{
				return float_3;
			}
			set
			{
				float_3 = value;
			}
		}

		public virtual float DesiredPitch
		{
			get
			{
				return _DesiredPitch;
			}
			set
			{
				if (float.IsInfinity(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					if (float.IsPositiveInfinity(value))
					{
						value = 89.9f;
					}
					if (float.IsNegativeInfinity(value))
					{
						value = -89.9f;
					}
				}
				_DesiredPitch = value;
			}
		}

		public virtual float DesiredRoll
		{
			get
			{
				return float_4;
			}
			set
			{
				float_4 = value;
			}
		}

		public virtual bool IsUnderground
		{
			get
			{
				int result;
				if (_Longitude == _Longitude)
				{
					if (_Latitude == _Latitude)
					{
						return CurrentAltitude_AGL < 0f;
					}
					result = 0;
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}
		}

		public virtual bool IsUnderwater
		{
			get
			{
				if (this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f)
				{
					return this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= (float)this.get_LandElevation(AGL: false, RequestIsFromGUI: false, Force: false, this.get_UnitSide(SetSideOnly: false)?.ParentScen);
				}
				return false;
			}
		}

		public List<RangeSymbol> RangeSymbols
		{
			get
			{
				if (list_0 == null)
				{
					list_0 = new List<RangeSymbol>();
				}
				return list_0;
			}
		}

		public virtual double Longitude
		{
			get
			{
				return _Longitude;
			}
			set
			{
				if (value > 180.0 || value < -180.0)
				{
					value = Math2.NormalizeLongitude(value);
				}
				if (double.IsNaN(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				if (_Longitude != value)
				{
					gkoyPgDgTi9 = null;
				}
				_Longitude = value;
			}
		}

		public virtual double Latitude
		{
			get
			{
				return _Latitude;
			}
			set
			{
				if (value > 90.0 || value < -90.0)
				{
					value = Math2.NormalizeLatitude(value);
				}
				if (double.IsNaN(value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					return;
				}
				if (_Latitude != value)
				{
					gkoyPgDgTi9 = null;
				}
				_Latitude = value;
			}
		}

		public virtual double Longitude_old
		{
			get
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = _Longitude;
				}
				return nullable_0.Value;
			}
			set
			{
				if (value > 180.0 || value < -180.0)
				{
					value = Math2.NormalizeLongitude(value);
				}
				if (!double.IsNaN(value))
				{
					nullable_0 = value;
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}

		public virtual double Latitude_old
		{
			get
			{
				if (!nullable_1.HasValue)
				{
					nullable_1 = _Latitude;
				}
				return nullable_1.Value;
			}
			set
			{
				if (value > 90.0 || value < -90.0)
				{
					value = Math2.NormalizeLatitude(value);
				}
				if (!double.IsNaN(value))
				{
					nullable_1 = value;
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}

		public virtual double? Longitude__UnitEntersAreaCheck
		{
			get
			{
				if (!Information.IsNothing((object)nullable_5))
				{
					return nullable_5.Value;
				}
				return nullable_5;
			}
			set
			{
				if (value.HasValue)
				{
					double? num = value;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > 180.0)) != true)
					{
						num = value;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() < -180.0)) != true)
						{
							goto IL_008d;
						}
					}
					value = Math2.NormalizeLongitude(value.Value);
					goto IL_008d;
				}
				nullable_5 = null;
				return;
				IL_008d:
				if (double.IsNaN(value.Value))
				{
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
				}
				else
				{
					nullable_5 = value;
				}
			}
		}

		public virtual double? Latitude__UnitEntersAreaCheck
		{
			get
			{
				return Information.IsNothing((object)nullable_6) ? ((double?)null) : new double?(nullable_6.Value);
			}
			set
			{
				if (!value.HasValue)
				{
					nullable_6 = null;
					return;
				}
				double? num = value;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() > 90.0)) != true)
				{
					num = value;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() < -90.0)) != true)
					{
						goto IL_0097;
					}
				}
				value = Math2.NormalizeLatitude(value.Value);
				goto IL_0097;
				IL_0097:
				if (!double.IsNaN(value.Value))
				{
					nullable_6 = value;
				}
				else if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
			}
		}

		public float Altitude_old
		{
			get
			{
				if (!nullable_2.HasValue)
				{
					nullable_2 = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				}
				return nullable_2.Value;
			}
			set
			{
				nullable_2 = value;
			}
		}

		public virtual float CurrentSpeed
		{
			get
			{
				return float_1;
			}
			set
			{
				if (float.IsNaN(value) || float.IsInfinity(value))
				{
					value = 0f;
				}
				float_1 = value;
			}
		}

		public bool IsSingleUnitAirbase
		{
			get
			{
				if (!IsGroup)
				{
					if (IsFacility)
					{
						return ((Facility)this).Category == Facility._FacilityCategory.AirBase;
					}
					return false;
				}
				return false;
			}
		}

		public virtual bool IsPlatform
		{
			get
			{
				if ((object)GetType().BaseType != typeof(Platform))
				{
					return (object)GetType() == typeof(Platform);
				}
				return true;
			}
		}

		public bool IsInsideThisArea
		{
			get
			{
				bool result;
				try
				{
					if (theArea == null)
					{
						result = false;
					}
					else if (theArea.Length < 3)
					{
						result = false;
					}
					else
					{
						bool value;
						if (UseCache && (IsActiveUnit || IsContact()))
						{
							int hashCode = theArea.GetHashCode();
							if (!Cache_IsInsideArea.Value.TryGetValue(hashCode, out value))
							{
								value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
								Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, value);
							}
						}
						else
						{
							value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
						}
						result = value;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 10043563407600", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num = 0;
					}
					else
					{
						num = 0;
					}
					result = (byte)num != 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public bool IsInsideThisArea
		{
			get
			{
				bool result;
				try
				{
					if (theArea != null)
					{
						if (theArea.Length < 3)
						{
							result = false;
						}
						else
						{
							bool value;
							if (UseCache && (IsActiveUnit || IsContact()))
							{
								int hashCode = theArea.GetHashCode();
								if (!Cache_IsInsideArea.Value.TryGetValue(hashCode, out value))
								{
									value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
									Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, value);
								}
							}
							else
							{
								value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
							}
							result = value;
						}
					}
					else
					{
						result = false;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 10043563407600", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 0;
					}
					else
					{
						Debugger.Break();
						num = 0;
					}
					result = (byte)num != 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public bool IsInsideThisArea
		{
			get
			{
				bool result;
				try
				{
					if (theArea == null)
					{
						result = false;
					}
					else if (theArea.Count < 3)
					{
						result = false;
					}
					else
					{
						bool value;
						if (UseCache && (IsActiveUnit || IsContact()))
						{
							int hashCode = theArea.GetHashCode();
							if (!Cache_IsInsideArea.Value.TryGetValue(hashCode, out value))
							{
								value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
								Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, value);
							}
						}
						else
						{
							value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
						}
						result = value;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 32490874598647213094873249587", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 0;
					}
					else
					{
						Debugger.Break();
						num = 0;
					}
					result = (byte)num != 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public bool IsInsideThisArea
		{
			get
			{
				bool result;
				try
				{
					if (theArea != null)
					{
						if (theArea.Count < 3)
						{
							result = false;
						}
						else
						{
							bool value;
							if (UseCache && (IsActiveUnit || IsContact()))
							{
								int hashCode = theArea.GetHashCode();
								if (!Cache_IsInsideArea.Value.TryGetValue(hashCode, out value))
								{
									value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
									Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, value);
								}
							}
							else
							{
								value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
							}
							result = value;
						}
					}
					else
					{
						result = false;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 32490874598647213094873249587", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num;
					if (!Debugger.IsAttached)
					{
						num = 0;
					}
					else
					{
						Debugger.Break();
						num = 0;
					}
					result = (byte)num != 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public virtual bool IsInsideThisArea
		{
			get
			{
				bool result;
				try
				{
					if (theArea != null)
					{
						if (theArea.Count < 3)
						{
							result = false;
						}
						else
						{
							bool value;
							if (UseCache && (IsActiveUnit || IsContact()))
							{
								int hashCode = theArea.GetHashCode();
								if (!Cache_IsInsideArea.Value.TryGetValue(hashCode, out value))
								{
									value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
									Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, value);
								}
							}
							else
							{
								value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
							}
							result = value;
						}
					}
					else
					{
						result = false;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100873", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					int num;
					if (Debugger.IsAttached)
					{
						Debugger.Break();
						num = 0;
					}
					else
					{
						num = 0;
					}
					result = (byte)num != 0;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public virtual bool IsInsideThisArea
		{
			get
			{
				bool result;
				try
				{
					if (theArea == null)
					{
						result = false;
					}
					else if (theArea.Count < 3)
					{
						result = false;
					}
					else
					{
						bool value;
						if (UseCache && (IsActiveUnit || IsContact()))
						{
							int hashCode = theArea.GetHashCode();
							if (!Cache_IsInsideArea.Value.TryGetValue(hashCode, out value))
							{
								value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
								Cache_IsInsideArea.Value.AddIfNotExistsElseUpdate(hashCode, value);
							}
						}
						else
						{
							value = GeoPoint.IsInsideThisArea(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theArea);
						}
						result = value;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 100873", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					Geopoint_Struct geopoint_Struct = new Geopoint_Struct(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null));
					result = GeoPoint.IsInsideThisArea(geopoint_Struct.Latitude, geopoint_Struct.Longitude, theArea);
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		public bool CanBePlacedOnIce
		{
			get
			{
				if (IsSubmarine && ((Submarine)this).IsNuke)
				{
					return true;
				}
				int result;
				if (!IsShip)
				{
					result = 0;
				}
				else if (!((Ship)this).IsIcebreaker)
				{
					result = 0;
				}
				else
				{
					bool flag = true;
					result = 0;
				}
				return (byte)result != 0;
			}
		}

		public float HorizMovementDistanceOnThisTime
		{
			get
			{
				if (SupportsAttitude_Pitch)
				{
					return (float)(Math2.Cosd(Attitude_Pitch) * (double)(CurrentSpeed / 3600f)) * elapsedTime;
				}
				return CurrentSpeed / 3600f * elapsedTime;
			}
		}

		public bool IsGuidedWeapon()
		{
			if (IsWeapon)
			{
				if (((Weapon)this).Type == Weapon._WeaponType.GuidedWeapon)
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public new void Reinitialize()
		{
			base.Reinitialize();
			float_0 = 0f;
			float_1 = 0f;
			float_2 = 0f;
			_Attitude_Pitch = 0f;
			float_3 = 0f;
			_DesiredPitch = 0f;
			float_4 = 0f;
			_ImpactAltitude = 0f;
			IsWeapon = false;
			_LastTick_DeltaTime = float.NaN;
			_LastTick_CurrentSpeed = float.NaN;
			_LastTick_CurrentHeading = float.NaN;
			_LastTick_CurrentAltitude = float.NaN;
			_LastTick_VerticalSpeed = float.NaN;
			_LastTick_Attitude_Pitch = float.NaN;
			_LastTick_Attitude_Roll = float.NaN;
			_LastTick_Latitude = double.NaN;
			_LastTick_Longitude = double.NaN;
			_Latitude = 0.0;
			_Longitude = 0.0;
			nullable_0 = null;
			nullable_1 = null;
			nullable_2 = null;
			nullable_3 = null;
			nullable_4 = null;
			nullable_5 = null;
			nullable_6 = null;
			ActiveEnterAreaTriggers.Clear();
			ActiveRemainAreaTriggers.Clear();
			if (list_0 != null)
			{
				list_0.Clear();
			}
			UnitClass = null;
			Message = null;
			CustomIcon = "";
			Cache_IsInsideArea = new Lazy<TDictionary<int, bool>>(smethod_0);
			RemoteSimEntityType = RemoteSimEntityTypeEnum.Local;
			DeadReckoning_VerticalSpeed = 0f;
			CurrentVerticalRate_mpersec = null;
			NodeA = null;
			NodeB = null;
			RoadNetworkPath.Clear();
			RoadNetworkNeverStop = false;
			float_5 = 0f;
			PlayerIsPlottingCourse = false;
			_SupportsAttitudePitch = -1;
			nullable_7 = null;
			nullable_8 = null;
			gkoyPgDgTi9 = null;
		}

		public RoadSystem.Segment GetCurrentRoadSegment()
		{
			if (IsAttachedToRoadSystem)
			{
				return RoadSystem.Segment.GetAssociatedSegment(NodeA, NodeB);
			}
			return null;
		}

		public void AttachToRoadSystem(RoadSystem.Node _nodea, RoadSystem.Node _nodeb, float Progress = 0f)
		{
			NodeA = _nodea;
			NodeB = _nodeb;
			RoadSystemProgress = Progress;
		}

		public void AttachToRoadSystem(RoadSystem.Node _node)
		{
			if (_node != null)
			{
				RoadSystem.Segment segment = _node.ConnectedSegments.ElementAt(0);
				if (_node == segment.NodeA)
				{
					AttachToRoadSystem(segment.NodeA, segment.NodeB);
				}
				else
				{
					AttachToRoadSystem(segment.NodeB, segment.NodeA);
				}
			}
		}

		public void DetachFromRoadSystem()
		{
			if (IsAggregatedUnit)
			{
				((AggregateGroundUnit)this).CurrentTactic = AGU_Tactic.DefaultTactic;
			}
			NodeA = null;
			NodeB = null;
			RoadNetworkPath.Clear();
		}

		public float UnitRelativeBearing(Unit Target, [Optional][DefaultParameterValue(0f)] ref float EngagedUnitBearing)
		{
			EngagedUnitBearing = (float)MathFunctions.GetBearing(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), Target.get_Latitude((GlobalVariables.BooleanObject)null), Target.get_Longitude((GlobalVariables.BooleanObject)null));
			return EngagedUnitBearing;
		}

		public RoadSystem.Node PathFindingToDestination(RoadSystem RoadSystem, double _Latitude, double _Longitude, float MaxNodeDistance)
		{
			double num = Math2.CalcDist_Angular(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), _Latitude, _Longitude);
			if ((double)MaxNodeDistance < num)
			{
				return null;
			}
			RoadSystem.Node closestNode = GetClosestNode(RoadSystem, 50f, -1, RoadSystem.SegmentEnum.AnyRoad);
			RoadSystem.Node node = null;
			if (closestNode != null)
			{
				node = RoadSystem.GetClosestNode(_Latitude, _Longitude, 50f, closestNode.Network, RoadSystem.SegmentEnum.AnyRoad);
			}
			if (closestNode != null && node != null)
			{
				RoadNetworkPath.Clear();
				List<RoadSystem.Node> list = AStar.Search_Nodes(RoadSystem, closestNode, node, null);
				if (list.Count < 3)
				{
					return null;
				}
				ActiveUnit activeUnit = null;
				if (IsActiveUnit)
				{
					activeUnit = (ActiveUnit)this;
				}
				if (Math2.CalcDist_Angular(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), closestNode.Coordinates.Latitude, closestNode.Coordinates.Longitude) < 0.01)
				{
					list.RemoveAt(0);
					RoadNetworkPath = list;
					AttachToRoadSystem(list[0], list[1]);
					list.RemoveAt(1);
					if (activeUnit != null && activeUnit.Navigator.PlottedCourse.Count() > 1)
					{
						Waypoint theAC = activeUnit.Navigator.PlottedCourse[activeUnit.Navigator.PlottedCourse.Count() - 1];
						ActiveUnit_Navigator navigator = activeUnit.Navigator;
						Waypoint[] theArray = navigator.PlottedCourse;
						ArrayExtensions.Clear(ref theArray);
						navigator.PlottedCourse = theArray;
						ActiveUnit_Navigator navigator2 = activeUnit.Navigator;
						theArray = navigator2.PlottedCourse;
						ArrayExtensions.Add(ref theArray, theAC);
						navigator2.PlottedCourse = theArray;
					}
				}
				else if (activeUnit != null)
				{
					Waypoint theWP = new Waypoint(closestNode.Coordinates.Longitude, closestNode.Coordinates.Latitude, 0f, Waypoint.WaypointType.PathfindingPoint, Waypoint.WaypointCreator.Navigator, Waypoint.WaypointCategory.PlottedCourse);
					activeUnit.Navigator.AddWaypoint(0, theWP);
				}
			}
			return closestNode;
		}

		public RoadSystem.Node PathFindingToDestination(Scenario ScenarioContext, double _Latitude, double _Longitude, float MaxNodeDistance)
		{
			return PathFindingToDestination(ScenarioContext.RoadSystem, _Latitude, _Longitude, MaxNodeDistance);
		}

		public RoadSystem.Node GetClosestNode(RoadSystem Roadsystem, float MaxDistance = -1f, int EligibleNetwork = -1, RoadSystem.SegmentEnum segmentType = RoadSystem.SegmentEnum.Any)
		{
			return Roadsystem.GetClosestNode(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), MaxDistance, EligibleNetwork, segmentType);
		}

		public RoadSystem.Node GetClosestNode(Scenario ScenarioContext, float MaxDistance = -1f, int EligibleNetwork = -1, RoadSystem.SegmentEnum segmentType = RoadSystem.SegmentEnum.Any)
		{
			return GetClosestNode(ScenarioContext.RoadSystem, MaxDistance, EligibleNetwork, segmentType);
		}

		public void AttachToClosestRoadSystem(Scenario ScenarioContext, float MaxDistance = -1f, int EligibleNetwork = -1, RoadSystem.SegmentEnum segmentType = RoadSystem.SegmentEnum.Any)
		{
			AttachToClosestRoadSystem(ScenarioContext.RoadSystem, MaxDistance, EligibleNetwork, segmentType);
		}

		public void AttachToClosestRoadSystem(RoadSystem Roadsystem, float MaxDistance = -1f, int EligibleNetwork = -1, RoadSystem.SegmentEnum segmentType = RoadSystem.SegmentEnum.Any)
		{
			RoadSystem.Node closestNode = Roadsystem.GetClosestNode(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), MaxDistance, EligibleNetwork, segmentType);
			if (closestNode != null)
			{
				AttachToRoadSystem(closestNode.ConnectedSegments.ElementAt(0).NodeA, closestNode.ConnectedSegments.ElementAt(0).NodeB);
			}
		}

		public void RefreshRoadSystemPosition()
		{
			if (IsAttachedToRoadSystem)
			{
				Geopoint_Struct geoCoordinate = RoadSystem.Segment.GetGeoCoordinate(NodeA, NodeB, float_5);
				this.set_Latitude((GlobalVariables.BooleanObject)null, geoCoordinate.Latitude);
				this.set_Longitude((GlobalVariables.BooleanObject)null, geoCoordinate.Longitude);
			}
		}

		public void MoveAlongRoadSystem_Factor(float ProgressFactor)
		{
			if (IsAttachedToRoadSystem)
			{
				RoadSystemProgress += ProgressFactor;
			}
		}

		public void MoveAlongRoadSystem_Nm(float ProgressInNm)
		{
			if (IsAttachedToRoadSystem)
			{
				MoveAlongRoadSystem_Factor(1f / RoadSystem.Segment.GetLengthNm(NodeA, NodeB) * ProgressInNm);
			}
		}

		private static TDictionary<int, bool> smethod_0()
		{
			return new TDictionary<int, bool>();
		}

		public virtual float RangeToUnit_Horiz(Unit TargetUnit, GlobalVariables.BooleanObject HintmyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
		{
			if (TargetUnit != null)
			{
				if (IsActiveUnit && HintmyUnitOperating == null)
				{
					HintmyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)this).IsOperating());
				}
				if (TargetUnit.IsActiveUnit && HintTargetUnitOperating == null)
				{
					HintTargetUnitOperating = Misc.ToBooleanObject(((ActiveUnit)TargetUnit).IsOperating());
				}
				double lat;
				double lon;
				if (IsActiveUnit && HintmyUnitOperating == GlobalVariables.ObjectTrue)
				{
					lat = ((ActiveUnit)this).Latitude_KnownOperating();
					lon = ((ActiveUnit)this).Longitude_KnownOperating();
				}
				else
				{
					lat = this.get_Latitude(HintmyUnitOperating);
					lon = this.get_Longitude(HintmyUnitOperating);
				}
				double lat2;
				double lon2;
				if (TargetUnit.IsActiveUnit && HintTargetUnitOperating == GlobalVariables.ObjectTrue)
				{
					lat2 = ((ActiveUnit)TargetUnit).Latitude_KnownOperating();
					lon2 = ((ActiveUnit)TargetUnit).Longitude_KnownOperating();
				}
				else
				{
					lat2 = TargetUnit.get_Latitude(HintTargetUnitOperating);
					lon2 = TargetUnit.get_Longitude(HintTargetUnitOperating);
				}
				return Math2.CalcDist(lat, lon, lat2, lon2);
			}
			return float.MaxValue;
		}

		public virtual void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
		{
			try
			{
				theWriter.WriteStartElement("Unit");
				theWriter.WriteElementString("ID", ObjectID);
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					theWriter.WriteEndElement();
					return;
				}
				ObjectsAlreadySerialized.Add(ObjectID);
				theWriter.WriteElementString("Name", Name);
				theWriter.WriteElementString("CurrentHeading", XmlConvert.ToString(CurrentHeading));
				theWriter.WriteElementString("CurrentSpeed", XmlConvert.ToString(CurrentSpeed));
				theWriter.WriteElementString("CurrentAltitude", XmlConvert.ToString(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
				theWriter.WriteElementString("Longitude", XmlConvert.ToString(_Longitude));
				theWriter.WriteElementString("Latitude", XmlConvert.ToString(_Latitude));
				theWriter.WriteElementString("UnitClass", UnitClass);
				theWriter.WriteElementString("Side", _UnitSide.Name);
				if (!string.IsNullOrEmpty(Message))
				{
					theWriter.WriteElementString("Message", Message);
				}
				if (Longitude__UnitEntersAreaCheck.HasValue)
				{
					theWriter.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
				}
				if (Latitude__UnitEntersAreaCheck.HasValue)
				{
					theWriter.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
				}
				if (ActiveEnterAreaTriggers.Count > 0)
				{
					theWriter.WriteStartElement("ActiveEnterAreaTriggers");
					foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
					{
						theWriter.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
					}
					theWriter.WriteEndElement();
				}
				if (ActiveRemainAreaTriggers.Count > 0)
				{
					theWriter.WriteStartElement("ActiveRemainAreaTriggers");
					foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
					{
						theWriter.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
						theWriter.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
					}
					theWriter.WriteEndElement();
				}
				theWriter.WriteEndElement();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100864", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static Unit FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c5: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			Unit result3;
			try
			{
				Unit unit = new Unit();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "ActiveEnterAreaTriggers":
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							string innerText2 = childNode2.InnerText;
							unit.ActiveEnterAreaTriggers.Add(innerText2);
						}
						break;
					case "CurrentAltitude":
						unit.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, XmlConvert.ToSingle(val.InnerText));
						break;
					case "Name":
						unit.Name = val.InnerText;
						break;
					case "Longitude":
						unit._Longitude = XmlConvert.ToDouble(val.InnerText);
						break;
					case "ID":
						if (theDictionary.ContainsKey(val.InnerText))
						{
							unit = (Unit)theDictionary[val.InnerText];
							break;
						}
						unit.ObjectID_Set(val.InnerText);
						theDictionary.TryAdd(unit.ObjectID, unit);
						break;
					case "UnitClass":
						unit.UnitClass = val.InnerText;
						break;
					case "Latitude":
						unit._Latitude = XmlConvert.ToDouble(val.InnerText);
						break;
					case "Side":
						unit.set_UnitSide(SetSideOnly: false, Side.FromXML_ByName(val.InnerText, ref theDictionary, theScen));
						break;
					case "ActiveRemainAreaTriggers":
					{
						string key = null;
						DateTime result = DateTime.MinValue;
						foreach (XmlNode childNode3 in val.ChildNodes)
						{
							XmlNode val2 = childNode3;
							if (Operators.CompareString(val2.Name, "RemainAreaTrigger", false) == 0)
							{
								key = val2.InnerText;
								result = DateTime.MinValue;
								continue;
							}
							if (DateTime.TryParse(val2.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
							{
								unit.ActiveRemainAreaTriggers.Add(key, result);
								continue;
							}
							string innerText = val2.InnerText;
							long result2 = default(long);
							if (long.TryParse(innerText, out result2))
							{
								result = DateTime.FromBinary(Conversions.ToLong(val2.InnerText));
								unit.ActiveRemainAreaTriggers.Add(key, result);
							}
						}
						break;
					}
					case "Latitude_UnitEntersAreaCheck":
						unit.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(val.InnerText);
						break;
					case "CurrentSpeed":
						unit.CurrentSpeed = XmlConvert.ToSingle(val.InnerText);
						break;
					case "Message":
						unit.Message = val.InnerText;
						break;
					case "CurrentHeading":
						unit.float_0 = XmlConvert.ToSingle(val.InnerText);
						break;
					case "Longitude_UnitEntersAreaCheck":
						unit.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(val.InnerText);
						break;
					}
				}
				result3 = unit;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100865", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result3 = new Unit();
				ProjectData.ClearProjectError();
			}
			return result3;
		}

		public virtual void Housekeeping_PostPulse(float elapsedTime)
		{
		}

		internal bool SetSide(Side NewSide, Scenario ScenarioContext)
		{
			if (Information.IsNothing((object)NewSide))
			{
				return false;
			}
			if (Operators.CompareString(this.get_UnitSide(SetSideOnly: false).ObjectID, NewSide.ObjectID, false) == 0)
			{
				return false;
			}
			string objectID = ObjectID;
			int result;
			if (!IsGroup)
			{
				foreach (Contact contacts_ in NewSide.Contacts_List)
				{
					if (!Information.IsNothing((object)contacts_.ActualUnit) && Operators.CompareString(contacts_.ActualUnit.ObjectID, ObjectID, false) == 0)
					{
						NewSide.DropContact(contacts_, ref ScenarioContext, LogMessage: false);
						break;
					}
				}
				foreach (Contact baseContacts_ in NewSide.BaseContacts_List)
				{
					if (!Information.IsNothing((object)baseContacts_.ActualUnit) && Operators.CompareString(baseContacts_.ActualUnit.ObjectID, ObjectID, false) == 0)
					{
						NewSide.DropBaseContact(baseContacts_, ref ScenarioContext, LogMessage: false);
						break;
					}
				}
				if (((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false) != null)
				{
					((ActiveUnit)this).set_ParentGroup(UsingMissionPlanner: false, (Group)null);
				}
				((ActiveUnit)this).UnassignUnit();
				this.set_UnitSide(SetSideOnly: false, NewSide);
				ScenarioContext.OnUnitSideChanged(ObjectID, objectID);
				result = 1;
			}
			else
			{
				Group obj = (Group)this;
				List<Unit> list = new List<Unit>();
				list = obj.ToList();
				foreach (Unit item in list)
				{
					foreach (Contact contacts_2 in NewSide.Contacts_List)
					{
						if (!Information.IsNothing((object)contacts_2.ActualUnit) && Operators.CompareString(contacts_2.ActualUnit.ObjectID, item.ObjectID, false) == 0)
						{
							NewSide.DropContact(contacts_2, ref ScenarioContext, LogMessage: false);
							break;
						}
					}
					foreach (Contact baseContacts_2 in NewSide.BaseContacts_List)
					{
						if (!Information.IsNothing((object)baseContacts_2.ActualUnit) && Operators.CompareString(baseContacts_2.ActualUnit.ObjectID, item.ObjectID, false) == 0)
						{
							NewSide.DropBaseContact(baseContacts_2, ref ScenarioContext, LogMessage: false);
							break;
						}
					}
					((ActiveUnit)item).UnassignUnit();
					item.set_UnitSide(SetSideOnly: false, NewSide);
					((ActiveUnit)item).set_ParentGroup(UsingMissionPlanner: false, (Group)this);
					ScenarioContext.OnUnitSideChanged(item.ObjectID, objectID);
				}
				this.set_UnitSide(SetSideOnly: false, NewSide);
				foreach (Contact contacts_3 in NewSide.Contacts_List)
				{
					if (!Information.IsNothing((object)contacts_3.ActualUnit) && Operators.CompareString(contacts_3.ActualUnit.ObjectID, ObjectID, false) == 0)
					{
						NewSide.DropContact(contacts_3, ref ScenarioContext, LogMessage: false);
						break;
					}
				}
				foreach (Contact baseContacts_3 in NewSide.BaseContacts_List)
				{
					if (!Information.IsNothing((object)baseContacts_3.ActualUnit) && Operators.CompareString(baseContacts_3.ActualUnit.ObjectID, ObjectID, false) == 0)
					{
						NewSide.DropBaseContact(baseContacts_3, ref ScenarioContext, LogMessage: false);
						break;
					}
				}
				result = 1;
			}
			return (byte)result != 0;
		}

		private void method_0(float float_6)
		{
			if (CurrentSpeed <= 0f)
			{
				nullable_3 = _Longitude;
				nullable_4 = _Latitude;
				return;
			}
			float distance_NM = this.get_HorizMovementDistanceOnThisTime(float_6);
			double out_lon = default(double);
			double out_lat = default(double);
			Geodesic_EdWilliams.CalcPoint_Williams(this.get_Longitude(GlobalVariables.ObjectTrue), this.get_Latitude(GlobalVariables.ObjectTrue), ref out_lon, ref out_lat, distance_NM, CurrentHeading);
			nullable_3 = out_lon;
			nullable_4 = out_lat;
		}

		public virtual void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
		{
			this.set_Longitude((GlobalVariables.BooleanObject)null, Destination_Lon);
			this.set_Latitude((GlobalVariables.BooleanObject)null, Destination_Lat);
			DetachFromRoadSystem();
			if (IsActiveUnit)
			{
				((ActiveUnit)this).updateLastReportedInfo();
			}
			if (IsActiveUnit)
			{
				ActiveUnit obj = (ActiveUnit)this;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_NoBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_1nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_2nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_5nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_10nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideMissionAreaEvaluation_30nmBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideProsecutionAreaEvaluation_NoBuffer = 0.0;
				obj.Navigator.TimeToNextIsInsideProsecutionAreaEvaluation_5nmBuffer = 0.0;
				obj.Navigator.TimeToNextUnitDistanceToNearestNoNavZoneEvaluation = 0.0;
				obj.Navigator.ResetTimeToNextPathfinderCheck();
			}
			if (!IsActiveUnit || !IsAircraft)
			{
				return;
			}
			Aircraft aircraft = (Aircraft)this;
			if (!Information.IsNothing((object)aircraft.Loadout))
			{
				WeaponRec[] weapons = aircraft.Loadout.Weapons;
				for (int i = 0; i < weapons.Length; i = checked(i + 1))
				{
					Weapon weapon = weapons[i].get_ReferenceWeapon(aircraft.ParentScen);
					weapon.set_Longitude((GlobalVariables.BooleanObject)null, aircraft.get_Longitude((GlobalVariables.BooleanObject)null));
					weapon.set_Latitude((GlobalVariables.BooleanObject)null, aircraft.get_Latitude((GlobalVariables.BooleanObject)null));
					weapon.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, aircraft.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
					weapon.CurrentHeading = aircraft.CurrentHeading;
					weapon.CurrentSpeed = aircraft.CurrentSpeed;
				}
			}
		}

		public virtual void PrePulseHousekeeping(float elapsedTime, Scenario theScen)
		{
			if (string.IsNullOrEmpty(ObjectID))
			{
				ResetIDs();
			}
			if (theScen.SecondIsChangingOnThisPulse && Cache_IsInsideArea.Value.Count > 0)
			{
				Cache_IsInsideArea.Value.Clear();
			}
		}

		public Unit()
		{
			IsWeapon = false;
			_LastTick_DeltaTime = float.NaN;
			_LastTick_CurrentSpeed = float.NaN;
			_LastTick_CurrentHeading = float.NaN;
			_LastTick_CurrentAltitude = float.NaN;
			_LastTick_VerticalSpeed = float.NaN;
			_LastTick_Attitude_Pitch = float.NaN;
			_LastTick_Attitude_Roll = float.NaN;
			_LastTick_Latitude = double.NaN;
			_LastTick_Longitude = double.NaN;
			ActiveEnterAreaTriggers = new List<string>();
			ActiveRemainAreaTriggers = new TDictionary<string, DateTime>(StringComparer.Ordinal, useReadLock: false);
			Cache_IsInsideArea = new Lazy<TDictionary<int, bool>>(smethod_0);
			RemoteSimEntityType = RemoteSimEntityTypeEnum.Local;
			CustomIcon = "";
			RoadNetworkPath = new List<RoadSystem.Node>();
			RoadNetworkNeverStop = false;
			PlayerIsPlottingCourse = false;
			_SupportsAttitudePitch = -1;
		}

		public virtual bool CanPlotCourseToThisLocation(double theLat, double theLon)
		{
			return true;
		}

		public virtual bool CanMoveToThisLocation(double theLat, double theLon, ref int MovementCost, bool IsPathfindingQuery, bool UsePathfindingBufferDistance, bool IgnoreMinesBehindUs, ref bool CheckNoNavZones, bool CheckForIcepack, ref bool CheckForMines, float? DistanceFromUnit, short? ProvidedElevation, ref List<ActiveUnit> ProvidedPiers, float proximityThreshold_Deg, bool CheckIfTargetIsOutsideProsecutionArea, bool CheckDistanceToNoNavZones, ref string UserFeedback, ref bool AllowBounce)
		{
			return true;
		}

		public static float DetermineAltitude_SensorTarget_Radar(Unit theUnit, GlobalVariables.BooleanObject HintTheUnitOperating = null)
		{
			float result;
			try
			{
				if (theUnit.IsSubmarine)
				{
					result = (((Submarine)theUnit).IsAtPeriscopeDepth ? 2f : (((Submarine)theUnit).IsSurfaced ? 8f : 0f));
				}
				else if (!theUnit.IsShip && !theUnit.IsFacility && !theUnit.IsVehicle)
				{
					result = theUnit.get_CurrentAltitude(DoSanityCheck: false, HintTheUnitOperating);
				}
				else
				{
					if (HintTheUnitOperating == null)
					{
						HintTheUnitOperating = Misc.ToBooleanObject(((ActiveUnit)theUnit).IsOperating());
					}
					float num = theUnit.get_CurrentAltitude(DoSanityCheck: false, HintTheUnitOperating);
					result = ((!(num < 0f)) ? (num + (float)theUnit.get_MastHeight_Radar((Sensor)null)) : 0f);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100868", "");
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

		public static float DetermineAltitude_SensorObserver_Radar(Unit theUnit, Sensor theSensor)
		{
			if (theSensor != null && theSensor.MastHeight != 0)
			{
				return theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theSensor.MastHeight;
			}
			if (theUnit.IsSubmarine)
			{
				if (Math.Round(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0)
				{
					return 0f;
				}
				if (Math.Round(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) == -20.0)
				{
					return 2f;
				}
				return 2f + ((float)Math.Abs(-20) - Math.Abs(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			}
			if (!theUnit.IsShip && !theUnit.IsFacility && !theUnit.IsVehicle && !theUnit.IsAircraft)
			{
				return theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			if (theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f)
			{
				return 0f;
			}
			return theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theUnit.get_MastHeight_Radar((Sensor)null);
		}

		public float GetLaserToughnessMultiplier(GlobalVariables.WeaponFragilityClass fragility)
		{
			return fragility switch
			{
				GlobalVariables.WeaponFragilityClass.VeryFragile => 0.25f, 
				GlobalVariables.WeaponFragilityClass.Fragile => 0.5f, 
				GlobalVariables.WeaponFragilityClass.Medium => 1f, 
				GlobalVariables.WeaponFragilityClass.Tough => 1.2f, 
				_ => 1f, 
			};
		}

		public GlobalVariables.WeaponFragilityClass GetSpecificWeaponTypeFragility(Weapon usedWeapon)
		{
			GlobalVariables.WeaponFragilityClass weaponFragilityClass = GlobalVariables.WeaponFragilityClass.VeryFragile;
			usedWeapon.WeaponSensors();
			_ = (float)usedWeapon.InitialDP;
			float num = usedWeapon.Kinematics.GetMaximumSpeed();
			float maximumAltitude = usedWeapon.Kinematics.GetMaximumAltitude();
			bool flag = usedWeapon.InfiniteGlideAngle != 0f;
			_ = usedWeapon.Type;
			float num2 = Physics.ComputeMach(maximumAltitude, num);
			bool isUAV = usedWeapon.isUAV;
			bool isBomb = usedWeapon.IsBomb;
			if (!isUAV)
			{
				if (isBomb)
				{
					weaponFragilityClass = (flag ? GlobalVariables.WeaponFragilityClass.Fragile : GlobalVariables.WeaponFragilityClass.Tough);
				}
				if (weaponFragilityClass == GlobalVariables.WeaponFragilityClass.VeryFragile)
				{
					weaponFragilityClass = ((num2 < 1f) ? GlobalVariables.WeaponFragilityClass.Fragile : ((!(num2 > 3f)) ? GlobalVariables.WeaponFragilityClass.Tough : GlobalVariables.WeaponFragilityClass.Medium));
				}
				return weaponFragilityClass;
			}
			return GlobalVariables.WeaponFragilityClass.VeryFragile;
		}

		public void BallisticMovement(BallisticTrajectory.BallisticResult Result, float elapsedTime, bool SimplifiedCalcs_DLZ)
		{
			nullable_0 = this.get_Longitude((GlobalVariables.BooleanObject)null);
			nullable_1 = this.get_Latitude((GlobalVariables.BooleanObject)null);
			double lon_deg = Result.Lon_deg;
			double lat_deg = Result.Lat_deg;
			double num = Result.AltASL_m;
			Altitude_old = this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			BallisticMissile ballisticMissile = (BallisticMissile)this;
			if (!ballisticMissile.IsDLZconstruct && num < (double)Terrain.GlobalMaxTerrainElevation)
			{
				int val;
				if (ballisticMissile.AI.PrimaryTarget == null)
				{
					if (ballisticMissile.Navigator.PlottedCourse.Length <= 0)
					{
						goto IL_0119;
					}
					val = 0;
				}
				else
				{
					val = 0;
				}
				int num2 = Math.Max(val, Terrain.GetElevation(lat_deg, lon_deg, RequestIsFromGUI: false, ballisticMissile.ParentScen));
				if (num < (double)num2)
				{
					float num3 = default(float);
					if (ballisticMissile.AI.PrimaryTarget != null)
					{
						num3 = ballisticMissile.RangeToUnit_Horiz(ballisticMissile.AI.PrimaryTarget);
					}
					else if (ballisticMissile.Navigator.PlottedCourse.Length > 0)
					{
						Waypoint waypoint = ballisticMissile.Navigator.PlottedCourse[0];
						num3 = RangeToPoint_Horiz(ballisticMissile, waypoint.Latitude, waypoint.Longitude);
					}
					float num4 = RangeToPoint_Horiz(ballisticMissile, ballisticMissile.LaunchPoint);
					if (num3 > num4)
					{
						num = num2 + 1;
					}
				}
			}
			goto IL_0119;
			IL_0119:
			this.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, (float)num);
			CurrentSpeed = (float)Result.Speed_kts;
			this.set_Latitude((GlobalVariables.BooleanObject)null, lat_deg);
			this.set_Longitude((GlobalVariables.BooleanObject)null, lon_deg);
			DesiredPitch = (float)Result.Pitch_deg;
			_Attitude_Pitch = (float)Result.Pitch_deg;
			if (IsActiveUnit)
			{
				ActiveUnit obj = (ActiveUnit)this;
				if (obj != null)
				{
					ActiveUnit_Navigator navigator = obj.Navigator;
					if (navigator != null && navigator.HasPlottedCourse())
					{
						ActiveUnit obj2 = (ActiveUnit)this;
						object obj3;
						if (obj2 != null)
						{
							ActiveUnit_Navigator navigator2 = obj2.Navigator;
							obj3 = ((navigator2 == null) ? null : navigator2.PlottedCourse[0]);
						}
						else
						{
							obj3 = null;
						}
						Waypoint waypoint2 = (Waypoint)obj3;
						((ActiveUnit)ballisticMissile).set_DesiredHeading(ActiveUnit.TurnRate.Navigation, BearingToPoint_True(this, waypoint2.Latitude, waypoint2.Longitude));
						ballisticMissile.Kinematics.TurnToDesiredHeading(elapsedTime);
						goto IL_01e4;
					}
				}
			}
			((ActiveUnit)ballisticMissile).set_DesiredHeading(ActiveUnit.TurnRate.Navigation, (float)Result.Heading_deg);
			ballisticMissile.Kinematics.TurnToDesiredHeading(elapsedTime);
			goto IL_01e4;
			IL_01e4:
			if (double.IsNaN(this.get_Latitude((GlobalVariables.BooleanObject)null)))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				this.set_Latitude((GlobalVariables.BooleanObject)null, nullable_1.Value);
			}
			if (double.IsNaN(this.get_Longitude((GlobalVariables.BooleanObject)null)))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				this.set_Longitude((GlobalVariables.BooleanObject)null, nullable_0.Value);
			}
			if (double.IsNaN(this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)))
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				this.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, Altitude_old);
			}
			if (!SimplifiedCalcs_DLZ)
			{
				CacheOldPosAndNextPos(elapsedTime);
			}
		}

		public virtual void ActualHorizMovement(float elapsedTime, bool SimplifiedCalcs_DLZ)
		{
			if (CurrentSpeed == 0f)
			{
				return;
			}
			nullable_0 = this.get_Longitude((GlobalVariables.BooleanObject)null);
			nullable_1 = this.get_Latitude((GlobalVariables.BooleanObject)null);
			try
			{
				float num = (IsActiveUnit ? ((ActiveUnit)this).Kinematics.HorizMovementDistanceOnThisTime(elapsedTime) : this.get_HorizMovementDistanceOnThisTime(elapsedTime));
				if (!IsAttachedToRoadSystem)
				{
					double out_lon = default(double);
					double out_lat = default(double);
					Geodesic_EdWilliams.CalcPoint_Williams(nullable_0.Value, nullable_1.Value, ref out_lon, ref out_lat, num, CurrentHeading);
					if (double.IsNaN(out_lat))
					{
						out_lat = nullable_1.Value;
					}
					if (double.IsNaN(out_lon))
					{
						out_lon = nullable_0.Value;
					}
					if (IsPlatform)
					{
						bool CheckForMines = false;
						bool CheckNoNavZones = true;
						bool AllowBounce = true;
						ActiveUnit activeUnit = default(ActiveUnit);
						List<ActiveUnit> ProvidedPiers = default(List<ActiveUnit>);
						if (IsActiveUnit)
						{
							activeUnit = (ActiveUnit)this;
							ProvidedPiers = activeUnit.DockingOps.GetDestinationPierList();
						}
						double theLat = out_lat;
						double theLon = out_lon;
						int MovementCost = 0;
						string UserFeedback = "";
						if (CanMoveToThisLocation(theLat, theLon, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref AllowBounce))
						{
							this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
							this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
							if (((ActiveUnit)this).ParentScen.MinuteIsChangingOnThisPulse)
							{
								((ActiveUnit)this).Navigator.GetNearestAccessibleSpotHeading = null;
							}
						}
						else if (!CheckForMines && !CheckNoNavZones)
						{
							double value = nullable_1.Value;
							double value2 = nullable_0.Value;
							MovementCost = 0;
							UserFeedback = "";
							if (CanMoveToThisLocation(value, value2, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: true, ref UserFeedback, ref AllowBounce))
							{
								AllowBounce = true;
							}
							if (AllowBounce)
							{
								CurrentHeading = Bounce(float_0, num, bool_0: false);
								Geodesic_EdWilliams.CalcPoint_Williams(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, num, CurrentHeading);
								if (activeUnit != null && activeUnit.ParentScen.MinuteIsChangingOnThisPulse)
								{
									double theLat2 = out_lat;
									double theLon2 = out_lon;
									MovementCost = 0;
									bool CheckNoNavZones2 = false;
									UserFeedback = "";
									bool AllowBounce2 = false;
									double DestLat = default(double);
									double DestLon = default(double);
									if (!CanMoveToThisLocation(theLat2, theLon2, ref MovementCost, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, ref CheckNoNavZones2, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce2) && activeUnit.Navigator.GetNearestAccessibleSpot(out_lat, out_lon, ref DestLat, ref DestLon, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: false))
									{
										out_lat = DestLat;
										out_lon = DestLon;
										activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
									}
									activeUnit.Navigator.GetNearestAccessibleSpotHeading = null;
								}
							}
						}
						else
						{
							if (activeUnit != null)
							{
								if (!activeUnit.ParentScen.MinuteIsChangingOnThisPulse && !Information.IsNothing((object)activeUnit.Navigator.GetNearestAccessibleSpotHeading))
								{
									activeUnit.CurrentHeading = activeUnit.Navigator.GetNearestAccessibleSpotHeading.Value;
								}
								else
								{
									if (CheckForMines && activeUnit.Navigator.HasPathfindingPlottedCourse)
									{
										activeUnit.Navigator.ClearPathfindingWaypoints();
									}
									double DestLat2 = default(double);
									double DestLon2 = default(double);
									if (activeUnit.Navigator.GetNearestAccessibleSpot(out_lat, out_lon, ref DestLat2, ref DestLon2, IsPathfindingQuery: false, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: true, 0f, ref ProvidedPiers, ManouverTowardsTarget: false))
									{
										activeUnit.Navigator.GetNearestAccessibleSpotHeading = Math2.CalcAzimuth(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), DestLat2, DestLon2);
										activeUnit.CurrentHeading = activeUnit.Navigator.GetNearestAccessibleSpotHeading.Value;
										activeUnit.Navigator.ResetTimeToNextPathfinderCheck();
									}
								}
							}
							this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
							this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
						}
					}
					this.set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					this.set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					if (double.IsNaN(this.get_Latitude((GlobalVariables.BooleanObject)null)))
					{
						this.set_Latitude((GlobalVariables.BooleanObject)null, nullable_1.Value);
					}
					if (double.IsNaN(this.get_Longitude((GlobalVariables.BooleanObject)null)))
					{
						this.set_Longitude((GlobalVariables.BooleanObject)null, nullable_0.Value);
					}
					if (!SimplifiedCalcs_DLZ)
					{
						CacheOldPosAndNextPos(elapsedTime);
					}
				}
				else
				{
					MoveAlongRoadSystem_Nm(num);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100875", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		protected void CacheOldPosAndNextPos(float elapsedTime)
		{
			if (Longitude_old != this.get_Longitude((GlobalVariables.BooleanObject)null) || Latitude_old != this.get_Latitude((GlobalVariables.BooleanObject)null))
			{
				gkoyPgDgTi9 = null;
				nullable_7 = null;
			}
			if (CurrentSpeed_Horizontal(this) != 0f)
			{
				nullable_8 = null;
				nullable_3 = null;
				nullable_4 = null;
			}
		}

		public void ContactMovement()
		{
			if (Longitude_old != this.get_Longitude((GlobalVariables.BooleanObject)null) || Latitude_old != this.get_Latitude((GlobalVariables.BooleanObject)null))
			{
				ClearElevationAndAltitudeAGL();
			}
			Longitude_old = this.get_Longitude((GlobalVariables.BooleanObject)null);
			Latitude_old = this.get_Latitude((GlobalVariables.BooleanObject)null);
		}

		public void ClearElevationAndAltitudeAGL()
		{
			gkoyPgDgTi9 = null;
			nullable_7 = null;
		}

		public float Bounce(float originalHeading, float moveDistance, bool bool_0)
		{
			float result;
			try
			{
				int num = 3;
				double out_lon = default(double);
				double out_lat = default(double);
				List<ActiveUnit> ProvidedPiers = default(List<ActiveUnit>);
				while (true)
				{
					float num2 = Math2.NormalizeBearing(originalHeading + (float)num);
					Geodesic_EdWilliams.CalcPoint_Williams(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, moveDistance, num2);
					double theLat = out_lat;
					double theLon = out_lon;
					int MovementCost = 0;
					bool CheckNoNavZones = false;
					bool CheckForMines = true;
					string UserFeedback = "";
					bool AllowBounce = false;
					if (!CanMoveToThisLocation(theLat, theLon, ref MovementCost, bool_0, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, ref CheckNoNavZones, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref AllowBounce))
					{
						num2 = Math2.NormalizeBearing(originalHeading - (float)num);
						Geodesic_EdWilliams.CalcPoint_Williams(this.get_Longitude((GlobalVariables.BooleanObject)null), this.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, moveDistance, num2);
						double theLat2 = out_lat;
						double theLon2 = out_lon;
						MovementCost = 0;
						AllowBounce = true;
						CheckForMines = true;
						UserFeedback = "";
						CheckNoNavZones = false;
						if (!CanMoveToThisLocation(theLat2, theLon2, ref MovementCost, bool_0, UsePathfindingBufferDistance: false, IgnoreMinesBehindUs: false, ref AllowBounce, CheckForIcepack: true, ref CheckForMines, null, null, ref ProvidedPiers, 0f, CheckIfTargetIsOutsideProsecutionArea: false, CheckDistanceToNoNavZones: false, ref UserFeedback, ref CheckNoNavZones))
						{
							num += 3;
							if (num > 177)
							{
								result = originalHeading;
								break;
							}
							continue;
						}
						result = num2;
						break;
					}
					result = num2;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100876", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = originalHeading;
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public float ETA_To_Location(float ClosureSpeed, float Distance)
		{
			if (ClosureSpeed > 0f)
			{
				return (float)Math.Round(Distance / (ClosureSpeed / 3600f), 2);
			}
			return float.MaxValue;
		}

		public float ETA_To_Unit(Unit theUnit)
		{
			float num = RangeToUnit_Horiz(theUnit);
			float num2 = ClosureSpeed(this, theUnit, CurrentSpeed, CurrentHeading);
			return num / num2 * 3600f;
		}

		internal string IsPortOrStarboardOfThisUnit(Unit theUnit)
		{
			string feedbackMessage = "";
			if (AngleOffThisUnitsBoresight(this, theUnit, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage) >= 0f)
			{
				return "Starboard";
			}
			return "Port";
		}

		internal Misc.TurnDirection IsMovingTowardsPortOrStarboardOfThisUnit(Unit theUnit)
		{
			float num = Math2.CalcAzimuth(this.get_Latitude((GlobalVariables.BooleanObject)null), this.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null));
			float num2 = Math2.NormalizeBearing(CurrentHeading - num);
			num = 0f;
			if (num2 > 180f)
			{
				return Misc.TurnDirection.TurnRight;
			}
			return Misc.TurnDirection.TurnLeft;
		}

		public string SpeedString(Game.GamePreferences.SpeedUnitSetting GroundUnitsSpeedUnit)
		{
			if (!IsMobileGroundUnit && !IsFacility)
			{
				return Misc.SpeedToEnglishString(CurrentSpeed, 0, Game.GamePreferences.SpeedUnitSetting.Knots);
			}
			return Misc.SpeedToEnglishString(CurrentSpeed, 0, GroundUnitsSpeedUnit);
		}

		static Unit()
		{
			Class72.smethod_20();
		}
	}

	public static bool IsOrbitalCheck(float alt1, float alt2)
	{
		return Math.Abs(alt1 - alt2) > 100000f;
	}

	public static float RangeToUnit_Slant(this Unit myUnit, Unit theTarget, float HorizRangeProvided = 0f, GlobalVariables.BooleanObject HintMyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
	{
		if (theTarget == null)
		{
			return float.MaxValue;
		}
		float num = theTarget.get_CurrentAltitude(DoSanityCheck: false, HintTargetUnitOperating);
		float num2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating);
		if (!IsOrbitalCheck(num, num2))
		{
			float num3 = ((HorizRangeProvided != 0f) ? HorizRangeProvided : (myUnit.IsActiveUnit ? ((ActiveUnit)myUnit).RangeToUnit_Horiz_Alt(theTarget, HintMyUnitOperating, HintTargetUnitOperating) : myUnit.RangeToUnit_Horiz(theTarget, HintMyUnitOperating, HintTargetUnitOperating)));
			float num4 = (float)((double)Math.Abs(num2 - num) * 0.000539957);
			if (num4 == 0f)
			{
				return num3;
			}
			return (float)Math.Sqrt(num3 * num3 + num4 * num4);
		}
		return RangeToPoint_Slant_OnSphericalEarth(myUnit, theTarget.get_Latitude(HintTargetUnitOperating), theTarget.get_Longitude(HintTargetUnitOperating), num, HintTargetUnitOperating);
	}

	public static float RangeToPoint_Horiz(this Unit myUnit, GeoPoint thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (thePoint == null)
		{
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			return 0f;
		}
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		GlobalVariables.BooleanObject hintIsOperating = HintMyUnitOperating;
		return Math2.CalcDist(myUnit.get_Latitude(hintIsOperating), myUnit.get_Longitude(hintIsOperating), thePoint.Latitude, thePoint.Longitude);
	}

	public static float RangeToPoint_Horiz(this Unit myUnit, Geopoint_Struct thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		return Math2.CalcDist(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), thePoint.Latitude, thePoint.Longitude);
	}

	public static float RangeToPoint_Horiz(this Unit myUnit, double theLat, double theLon, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		return Math2.CalcDist(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), theLat, theLon);
	}

	public static float RangeToPoint_Slant(this Unit myUnit, Geopoint_Struct thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		if (!IsOrbitalCheck(thePoint.Altitude, myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating)))
		{
			float num = Math2.CalcDist(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), thePoint.Latitude, thePoint.Longitude);
			float num2 = (float)((double)Math.Abs(myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating) - thePoint.Altitude) / 1852.0);
			return (float)Math.Sqrt(num * num + num2 * num2);
		}
		return RangeToPoint_Slant_OnSphericalEarth(myUnit, thePoint.Latitude, thePoint.Longitude, thePoint.Altitude, HintMyUnitOperating);
	}

	public static float RangeToPoint_Slant(this Unit myUnit, TrajectoryPoint thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		if (!IsOrbitalCheck(thePoint.Altitude, myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating)))
		{
			float num = Math2.CalcDist(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), thePoint.Latitude, thePoint.Longitude);
			float num2 = (float)((double)Math.Abs(myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating) - thePoint.Altitude) / 1852.0);
			return (float)Math.Sqrt(num * num + num2 * num2);
		}
		return RangeToPoint_Slant_OnSphericalEarth(myUnit, thePoint.Latitude, thePoint.Longitude, thePoint.Altitude, HintMyUnitOperating);
	}

	public static float RangeToPoint_Slant(this Unit myUnit, GeoPoint thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		if (!IsOrbitalCheck(thePoint.Altitude, myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating)))
		{
			float num = Math2.CalcDist(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), thePoint.Latitude, thePoint.Longitude);
			float num2 = (float)((double)Math.Abs(myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating) - thePoint.Altitude) / 1852.0);
			return (float)Math.Sqrt(num * num + num2 * num2);
		}
		return RangeToPoint_Slant_OnSphericalEarth(myUnit, thePoint.Latitude, thePoint.Longitude, thePoint.Altitude, HintMyUnitOperating);
	}

	public static float RangeToPoint_Slant(this Unit myUnit, double PointLat, double PointLon, float PointAlt, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		float num = myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating);
		if (IsOrbitalCheck(PointAlt, num))
		{
			return RangeToPoint_Slant_OnSphericalEarth(myUnit, PointLat, PointLon, PointAlt, HintMyUnitOperating);
		}
		float num2 = Math2.CalcDist(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), PointLat, PointLon);
		float num3 = (float)((double)Math.Abs(num - PointAlt) / 1852.0);
		return (float)Math.Sqrt(num2 * num2 + num3 * num3);
	}

	public static float RangeToPoint_Slant_OnSphericalEarth(this Unit myUnit, double PointLat, double PointLon, float PointAlt, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		double num = 6371008.8 + (double)myUnit.get_CurrentAltitude(DoSanityCheck: false, HintMyUnitOperating);
		double x = myUnit.get_Latitude(HintMyUnitOperating);
		double x2 = myUnit.get_Longitude(HintMyUnitOperating);
		double num2 = Math2.Cosd(x);
		double num3 = num * num2 * Math2.Cosd(x2);
		double num4 = num * num2 * Math2.Sind(x2);
		double num5 = num * Math2.Sind(x);
		double num6 = 6371008.8 + (double)PointAlt;
		double num7 = Math2.Cosd(PointLat);
		double num8 = num6 * num7 * Math2.Cosd(PointLon);
		double num9 = num6 * num7 * Math2.Sind(PointLon);
		double num10 = num6 * Math2.Sind(PointLat);
		double num11 = num3 - num8;
		double num12 = num4 - num9;
		double num13 = num5 - num10;
		return (float)(Math.Sqrt(num11 * num11 + num12 * num12 + num13 * num13) * 0.000539957);
	}

	public static double RangeToPoint_Horiz_Angular(this Unit myUnit, GeoPoint thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		Angle latA = default(Angle);
		Angle lonA = default(Angle);
		Angle latB = default(Angle);
		Angle lonB = default(Angle);
		if (!myUnit.IsActiveUnit)
		{
			latA.Degrees = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			lonA.Degrees = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			if (HintMyUnitOperating == null)
			{
				HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
			}
			latA.Degrees = myUnit.get_Latitude(HintMyUnitOperating);
			lonA.Degrees = myUnit.get_Longitude(HintMyUnitOperating);
		}
		latB.Degrees = thePoint.Latitude;
		lonB.Degrees = thePoint.Longitude;
		return World.ApproxAngularDistance(latA, lonA, latB, lonB).Degrees;
	}

	public static double RangeToPoint_Horiz_Angular(this Unit myUnit, Geopoint_Struct thePoint, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		Angle latA = default(Angle);
		Angle lonA = default(Angle);
		Angle latB = default(Angle);
		Angle lonB = default(Angle);
		if (!myUnit.IsActiveUnit)
		{
			latA.Degrees = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			lonA.Degrees = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			if (HintMyUnitOperating == null)
			{
				HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
			}
			latA.Degrees = myUnit.get_Latitude(HintMyUnitOperating);
			lonA.Degrees = myUnit.get_Longitude(HintMyUnitOperating);
		}
		latB.Degrees = thePoint.Latitude;
		lonB.Degrees = thePoint.Longitude;
		return World.ApproxAngularDistance(latA, lonA, latB, lonB).Degrees;
	}

	public static double RangeToPoint_Horiz_Angular(this Unit myUnit, ref double theLat, ref double theLon, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		double latA;
		double lonA;
		if (!myUnit.IsActiveUnit)
		{
			latA = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			lonA = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		else
		{
			if (HintMyUnitOperating == null)
			{
				HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
			}
			latA = myUnit.get_Latitude(HintMyUnitOperating);
			lonA = myUnit.get_Longitude(HintMyUnitOperating);
		}
		return World.ApproxAngularDistance(latA, lonA, theLat, theLon);
	}

	public static double RangeToUnit_Horiz_Angular(this Unit myUnit, Unit theUnit, GlobalVariables.BooleanObject HintMyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
	{
		double latA;
		double lonA;
		if (myUnit.IsActiveUnit)
		{
			if (HintMyUnitOperating == null)
			{
				HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
			}
			latA = myUnit.get_Latitude(HintMyUnitOperating);
			lonA = myUnit.get_Longitude(HintMyUnitOperating);
		}
		else
		{
			latA = myUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			lonA = myUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		double latB;
		double lonB;
		if (theUnit.IsActiveUnit)
		{
			if (HintTargetUnitOperating == null)
			{
				HintTargetUnitOperating = Misc.ToBooleanObject(((ActiveUnit)theUnit).IsOperating());
			}
			latB = theUnit.get_Latitude(HintTargetUnitOperating);
			lonB = theUnit.get_Longitude(HintTargetUnitOperating);
		}
		else
		{
			latB = theUnit.get_Latitude((GlobalVariables.BooleanObject)null);
			lonB = theUnit.get_Longitude((GlobalVariables.BooleanObject)null);
		}
		return World.ApproxAngularDistance(latA, lonA, latB, lonB);
	}

	public static float BearingToUnit_True(this Unit myUnit, Unit theUnit, GlobalVariables.BooleanObject HintMyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && !myUnit.IsGroup && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		if (theUnit.IsActiveUnit && !theUnit.IsGroup && HintTargetUnitOperating == null)
		{
			HintTargetUnitOperating = Misc.ToBooleanObject(((ActiveUnit)theUnit).IsOperating());
		}
		return Math2.CalcAzimuth(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), theUnit.get_Latitude(HintTargetUnitOperating), theUnit.get_Longitude(HintTargetUnitOperating));
	}

	public static float BearingToUnit_Relative(this Unit myUnit, Unit theUnit, GlobalVariables.BooleanObject HintMyUnitOperating = null, GlobalVariables.BooleanObject HintTargetUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && !myUnit.IsGroup && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		if (theUnit.IsActiveUnit && !theUnit.IsGroup && HintTargetUnitOperating == null)
		{
			HintTargetUnitOperating = Misc.ToBooleanObject(((ActiveUnit)theUnit).IsOperating());
		}
		float newBearing = Math2.CalcAzimuth(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), theUnit.get_Latitude(HintTargetUnitOperating), theUnit.get_Longitude(HintTargetUnitOperating));
		return Math2.NormalizeBearing(MathFunctions.AngularDifference(myUnit.CurrentHeading, newBearing));
	}

	public static float BearingToPoint_True(this Unit myUnit, double PointLat, double PointLon, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		if (myUnit.IsActiveUnit && !myUnit.IsGroup && HintMyUnitOperating == null)
		{
			HintMyUnitOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
		}
		return Math2.CalcAzimuth(myUnit.get_Latitude(HintMyUnitOperating), myUnit.get_Longitude(HintMyUnitOperating), PointLat, PointLon);
	}

	public static float BearingToPoint_Relative(this Unit myUnit, double PointLat, double PointLon, GlobalVariables.BooleanObject HintMyUnitOperating = null)
	{
		float newBearing = Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PointLat, PointLon);
		return Math2.NormalizeBearing(MathFunctions.AngularDifference(myUnit.CurrentHeading, newBearing));
	}

	public static double GrazingAngleToUnit(this Unit myUnit, Unit theUnit)
	{
		return Geodesic_Vincenty.ApproxGrazingAngle(myUnit.RangeToUnit_Horiz(theUnit), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
	}

	public static double GrazingAngleToPoint(this Unit myUnit, double TargetLat, double TargetLon, float TargetAlt)
	{
		return Geodesic_Vincenty.ApproxGrazingAngle(RangeToPoint_Horiz(myUnit, TargetLat, TargetLon), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), TargetAlt);
	}

	public static double OffZenithAngleToPoint(this Unit myUnit, double TargetLat, double TargetLon, float TargetAlt)
	{
		return 90.0 - Geodesic_Vincenty.ApproxGrazingAngle(RangeToPoint_Horiz(myUnit, TargetLat, TargetLon), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), TargetAlt);
	}

	internal static float AngleOffThisUnitsBoresight(this Unit myUnit, Unit ObserverUnit, bool DistinguishBetweenStarboardAndPort, [Optional][DefaultParameterValue("")] ref string feedbackMessage, GlobalVariables.BooleanObject HintMyUnitOperating = null, GlobalVariables.BooleanObject HintObserverUnitOperating = null)
	{
		GlobalVariables.BooleanObject hintIsOperating = ((!myUnit.IsActiveUnit || myUnit.IsGroup || HintMyUnitOperating != null) ? HintMyUnitOperating : Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating()));
		GlobalVariables.BooleanObject hintIsOperating2 = ((!ObserverUnit.IsActiveUnit || ObserverUnit.IsGroup || HintObserverUnitOperating != null) ? HintObserverUnitOperating : Misc.ToBooleanObject(((ActiveUnit)ObserverUnit).IsOperating()));
		float currentHeading = ObserverUnit.CurrentHeading;
		float num = Math2.CalcAzimuth(ObserverUnit.get_Latitude(hintIsOperating2), ObserverUnit.get_Longitude(hintIsOperating2), myUnit.get_Latitude(hintIsOperating), myUnit.get_Longitude(hintIsOperating));
		num = Math2.NormalizeBearing(num - currentHeading);
		currentHeading = 0f;
		feedbackMessage = "horizontal bearing exeed boresight limit";
		if (DistinguishBetweenStarboardAndPort && num > 180f)
		{
			return 0f - (360f - num);
		}
		return num;
	}

	public static double AngleOffThisUnitsBoresight_3D(this ActiveUnit myUnit, Unit target)
	{
		Vector3D b = MathFunctions.GeographicToECEF(myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue), myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 6378137.0, 0.00669437999014);
		Vector3D v = MathFunctions.Subtract(MathFunctions.GeographicToECEF(target.get_Latitude((GlobalVariables.BooleanObject)null), target.get_Longitude((GlobalVariables.BooleanObject)null), target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 6378137.0, 0.00669437999014), b);
		double num = MathFunctions.Magnitude(v);
		if (num >= 1.0)
		{
			Vector3D b2 = MathFunctions.Scale(v, 1.0 / num);
			Vector3D a = MathFunctions.smethod_0(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.CurrentHeading, myUnit.Attitude_Pitch);
			return Math.Acos(Math.Max(-1.0, Math.Min(1.0, MathFunctions.Dot(a, b2)))) * (180.0 / Math.PI);
		}
		return 0.0;
	}

	internal static float AngleOffThisUnitsBoresight3D(this Unit myUnit, Unit ObserverUnit, ref double BearingAngle, ref double VerticalAngle)
	{
		float currentHeading = ObserverUnit.CurrentHeading;
		float num = Math2.CalcAzimuth(ObserverUnit.get_Latitude((GlobalVariables.BooleanObject)null), ObserverUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null));
		num = Math2.NormalizeBearing(num - currentHeading);
		currentHeading = 0f;
		double num2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - ObserverUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
		double num3 = (double)Math2.CalcDist(ObserverUnit.get_Latitude(GlobalVariables.ObjectTrue), ObserverUnit.get_Longitude(GlobalVariables.ObjectTrue), myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue)) * 1852.0;
		double num4 = 90.0;
		if (num3 != 0.0)
		{
			num4 = Math.Atan(num2 / num3) * 57.2957795130823;
		}
		if (ObserverUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))
		{
			num4 = 0.0 - Math.Abs(num4);
		}
		num4 -= (double)ObserverUnit.Attitude_Pitch;
		if (num > 180f)
		{
			num = 360f - num;
		}
		BearingAngle = num;
		VerticalAngle = num4;
		return (float)((double)Math.Abs(num) + Math.Abs(num4));
	}

	internal static bool IsMissile(this Unit myUnit)
	{
		if (!myUnit.IsWeapon)
		{
			return false;
		}
		Weapon weapon = (Weapon)myUnit;
		int result;
		if (weapon.Type != Weapon._WeaponType.GuidedWeapon)
		{
			if (weapon.IsBallisticMissile)
			{
				result = 1;
				goto IL_0040;
			}
			if (!weapon.IsReEntryVehicle && !weapon.IsHGV)
			{
				return false;
			}
		}
		result = 1;
		goto IL_0040;
		IL_0040:
		return (byte)result != 0;
	}

	internal static bool IsRemoteSimEntity(this Unit theUnit)
	{
		return theUnit.RemoteSimEntityType != Unit.RemoteSimEntityTypeEnum.Local;
	}

	internal static bool IsContact(this Unit myUnit)
	{
		return (object)myUnit.GetType() == typeof(Contact);
	}

	internal static bool IsOverLand(this Unit myUnit)
	{
		if (myUnit.IsActiveUnit)
		{
			if (((ActiveUnit)myUnit).ParentScen == null)
			{
				return false;
			}
			GlobalVariables.BooleanObject hintIsOperating = Misc.ToBooleanObject(((ActiveUnit)myUnit).IsOperating());
			int num;
			if (((ActiveUnit)myUnit).ParentScen.NatureSideExists())
			{
				CustomEnvironmentZone[] customEnvironmentZones = ((ActiveUnit)myUnit).ParentScen.GetNatureSide().CustomEnvironmentZones;
				foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
				{
					if (customEnvironmentZone.HasCustomTerrain && GeoPoint.IsInsideThisArea(myUnit.get_Latitude(hintIsOperating), myUnit.get_Longitude(hintIsOperating), customEnvironmentZone.Area_AsArray) && customEnvironmentZone.TerrainType != LandCover.LandCoverType.Water)
					{
						return true;
					}
				}
				num = -70;
			}
			else
			{
				num = -70;
			}
			int num2 = num;
			int num3;
			if (!myUnit.IsVehicle)
			{
				if (!myUnit.IsFacility)
				{
					goto IL_0155;
				}
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			bool flag = (byte)num3 != 0;
			foreach (Engine item in ((ActiveUnit)myUnit).Propulsion)
			{
				if (item.CanBeUsedOnWater())
				{
					flag = true;
					break;
				}
			}
			Scenario theScen = (myUnit.IsVehicle ? ((Vehicle)myUnit).ParentScen : ((Facility)myUnit).ParentScen);
			if (!flag && Terrain.GetElevation(myUnit.get_Latitude(hintIsOperating), myUnit.get_Longitude(hintIsOperating), RequestIsFromGUI: false, theScen) > num2)
			{
				return true;
			}
		}
		goto IL_0155;
		IL_0155:
		return Terrain.PointIsOverland(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null)).IsOverland;
	}

	internal static bool IsWithinAtmosphere(this Unit myUnit)
	{
		return myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 100000f;
	}

	internal static bool IsOverLand_next(this Unit myUnit, float elapsedTime)
	{
		int num = myUnit.get_LandElevation_next(AGL: false, elapsedTime);
		int num2 = -70;
		if (!myUnit.IsVehicle)
		{
			if (myUnit.IsFacility && ((num > num2) & Information.IsNothing((object)((Facility)myUnit).Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0))))
			{
				return true;
			}
		}
		else if ((num > num2) & Information.IsNothing((object)((Vehicle)myUnit).Propulsion.Where([SpecialName] (Engine theE) => theE.CanBeUsedOnWater()).ElementAtOrDefault(0)))
		{
			return true;
		}
		bool result = default(bool);
		return result;
	}

	internal static float CurrentSpeed_Horizontal(this Unit myUnit)
	{
		if ((object)myUnit.GetType() == typeof(Contact))
		{
			Contact contact = (Contact)myUnit;
			if (contact.SpeedIsKnown && contact.ActualUnit != null)
			{
				return CurrentSpeed_Horizontal(((Contact)myUnit).ActualUnit);
			}
		}
		if (!myUnit.SupportsAttitude_Pitch)
		{
			return myUnit.CurrentSpeed;
		}
		return (float)(Math2.Cosd(myUnit.Attitude_Pitch) * (double)myUnit.CurrentSpeed);
	}

	internal static float CurrentSpeed_Vertical(this Unit myUnit, Scenario theScen, bool Recompute = false)
	{
		if (myUnit.IsGroup && ((Group)myUnit).GroupLead != null)
		{
			return CurrentSpeed_Vertical(((Group)myUnit).GroupLead, theScen, Recompute);
		}
		if (Recompute || !myUnit.CurrentVerticalRate_mpersec.HasValue)
		{
			ComputeCurrentSpeed_Vertical(myUnit, theScen.GameResolution);
		}
		return myUnit.CurrentVerticalRate_mpersec.Value;
	}

	internal static void ComputeCurrentSpeed_Vertical(Unit myUnit, float ReferenceResolution)
	{
		myUnit.CurrentVerticalRate_mpersec = (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - myUnit.Altitude_old) / ReferenceResolution;
	}

	public static float ClosureSpeed(this Unit myUnit, double TargetLat, double TargetLon, float TargetHeading, float TargetSpeed, float OwnSpeed, float OwnHeading)
	{
		float result;
		try
		{
			result = ((TargetSpeed == 0f && Math.Abs(Math.Round(MathFunctions.AngularDifference(BearingToPoint_True(myUnit, TargetLat, TargetLon), OwnHeading), 1)) <= 0.1) ? OwnSpeed : ((!(Geodesic_Haversine.Distance_Horiz_Approx_nm(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), TargetLat, TargetLon) < 50.0)) ? smethod_0(myUnit, TargetLat, TargetLon, TargetHeading, TargetSpeed, OwnSpeed, OwnHeading) : ((float)MercatorProjection.ClosureRate_Geocentric(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), OwnSpeed, OwnHeading, TargetLat, TargetLon, TargetSpeed, TargetHeading))));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200045", ex2.Message);
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

	private static float smethod_0(Unit unit_0, double double_0, double double_1, float float_0, float float_1, float float_2, float float_3)
	{
		double lat = unit_0.get_Latitude((GlobalVariables.BooleanObject)null);
		double lon = unit_0.get_Longitude((GlobalVariables.BooleanObject)null);
		float distance_NM = float_2 / 3600f;
		double out_lon = default(double);
		double out_lat = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(lon, lat, ref out_lon, ref out_lat, distance_NM, float_3);
		distance_NM = float_1 / 3600f;
		double out_lat2 = default(double);
		double out_lon2 = default(double);
		Geodesic_EdWilliams.CalcPoint_Williams(double_1, double_0, ref out_lon2, ref out_lat2, distance_NM, float_0);
		float num = Math2.CalcDist(lat, lon, double_0, double_1);
		float num2 = Math2.CalcDist(out_lat, out_lon, out_lat2, out_lon2);
		return (num - num2) * 3600f;
	}

	public static float ClosureSpeed(this Unit myUnit, Unit theTarget, float OwnSpeed, float OwnHeading)
	{
		return ClosureSpeed(myUnit, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), theTarget.CurrentHeading, theTarget.CurrentSpeed, OwnSpeed, OwnHeading);
	}

	public static Unit.LOSCheckResult Has_LOS_ToUnit_Orbital(this Unit myUnit, Unit theUnit, ref Scenario theScen)
	{
		if (myUnit.IsSatellite && theUnit.IsSatellite)
		{
			MathFunctions.Vector positionVector = ((Satellite)myUnit).PositionVector;
			MathFunctions.Vector positionVector2 = ((Satellite)theUnit).PositionVector;
			if (MathFunctions.Arccos(6371.0 / positionVector.Mag) + MathFunctions.Arccos(6371.0 / positionVector2.Mag) - MathFunctions.Arccos(positionVector.Dot(positionVector2) / (positionVector.Mag * positionVector2.Mag)) > 0.0)
			{
				return Unit.LOSCheckResult.Success;
			}
			return Unit.LOSCheckResult.Fail_OutOfHorizon;
		}
		return Unit.LOSCheckResult.Fail_Other;
	}

	public static bool Has_Radar_LOS_ToPoint(this Unit myUnit, Sensor mySensor, double PointLat, double PointLon, float PointAlt, ref Scenario theScen, bool IgnoreRadarHorizon = false)
	{
		bool result;
		try
		{
			float num = ((mySensor != null && mySensor.MastHeight != 0) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)mySensor.MastHeight) : ((myUnit.IsShip || myUnit.IsFacility) ? (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)myUnit.get_MastHeight_Radar((Sensor)null)) : myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)));
			if (IgnoreRadarHorizon || Horizon.RadarHorizonNM(num, PointAlt) >= Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), PointLat, PointLon))
			{
				bool flag = default(bool);
				try
				{
					flag = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, PointLat, PointLon, PointAlt, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon);
				}
				catch (OutOfMemoryException projectError)
				{
					ProjectData.SetProjectError((Exception)projectError);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					flag = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, PointLat, PointLon, PointAlt, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon);
					ProjectData.ClearProjectError();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 101174", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				result = flag;
			}
			else
			{
				result = false;
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100867", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			int num2;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num2 = 0;
			}
			else
			{
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool Has_Radar_LOS_ToUnit(this Unit myUnit, Sensor mySensor, Unit theTarget, ref Scenario theScen, bool IgnoreRadarHorizon = false, float? ExplicitObserverAltitude = null, float? ExplicitTargetAltitude = null, bool considerOverlappingCoordinatesAsValid = false)
	{
		bool result;
		try
		{
			if (myUnit.IsSatellite && theTarget.IsSatellite)
			{
				result = Has_LOS_ToUnit_Orbital(myUnit, theTarget, ref theScen) == Unit.LOSCheckResult.Success;
			}
			else
			{
				float num = ((!ExplicitTargetAltitude.HasValue) ? Unit.DetermineAltitude_SensorTarget_Radar(theTarget) : ExplicitTargetAltitude.Value);
				float num2 = ((!ExplicitObserverAltitude.HasValue) ? Unit.DetermineAltitude_SensorObserver_Radar(myUnit, mySensor) : ExplicitObserverAltitude.Value);
				if ((theTarget.IsShip || theTarget.IsFacility || theTarget.IsMobileGroundUnit || theTarget.IsSubmarine) && myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && myUnit.CurrentAltitude_AGL > 0f)
				{
					result = Has_Radar_LOS_ToUnit(theTarget, null, myUnit, ref theScen, IgnoreRadarHorizon, num, num2);
				}
				else if (!IgnoreRadarHorizon && Horizon.RadarHorizonNM(num2, num) < myUnit.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue))
				{
					result = false;
				}
				else if (myUnit.IsSubmarine && Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, GlobalVariables.ObjectTrue)) < -20.0 && num > 0f)
				{
					result = false;
				}
				else
				{
					bool flag = default(bool);
					try
					{
						flag = LOS.DetermineLOS(myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue), num2, theTarget.get_Latitude(GlobalVariables.ObjectTrue), theTarget.get_Longitude(GlobalVariables.ObjectTrue), num, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon, considerOverlappingCoordinatesAsValid);
					}
					catch (OutOfMemoryException projectError)
					{
						ProjectData.SetProjectError((Exception)projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						flag = LOS.DetermineLOS(myUnit.get_Latitude(GlobalVariables.ObjectTrue), myUnit.get_Longitude(GlobalVariables.ObjectTrue), num2, theTarget.get_Latitude(GlobalVariables.ObjectTrue), theTarget.get_Longitude(GlobalVariables.ObjectTrue), num, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon);
						ProjectData.ClearProjectError();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 101175", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					result = flag;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100869", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool Has_ESM_LOS_ToUnit(this Unit myUnit, Sensor mySensor, Unit theTarget, ref Scenario theScen, bool IgnoreRadarHorizon = false, float? ExplicitObserverAltitude = null, float? ExplicitTargetAltitude = null)
	{
		bool result;
		try
		{
			if (myUnit.IsSatellite && theTarget.IsSatellite)
			{
				result = Has_LOS_ToUnit_Orbital(myUnit, theTarget, ref theScen) == Unit.LOSCheckResult.Success;
			}
			else
			{
				float num = (ExplicitTargetAltitude.HasValue ? ExplicitTargetAltitude.Value : Unit.DetermineAltitude_SensorTarget_Radar(theTarget));
				float num2 = ((!ExplicitObserverAltitude.HasValue) ? Unit.DetermineAltitude_SensorObserver_Radar(myUnit, mySensor) : ExplicitObserverAltitude.Value);
				if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && myUnit.CurrentAltitude_AGL > 0f && (theTarget.IsShip || theTarget.IsFacility || theTarget.IsSubmarine))
				{
					result = Has_ESM_LOS_ToUnit(theTarget, null, myUnit, ref theScen, IgnoreRadarHorizon, num, num2);
				}
				else if (!IgnoreRadarHorizon && Horizon.ESMHorizonNM(num2, num) < myUnit.RangeToUnit_Horiz(theTarget, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue))
				{
					result = false;
				}
				else if (myUnit.IsSubmarine && Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0 && theTarget.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f)
				{
					result = false;
				}
				else
				{
					bool flag = default(bool);
					try
					{
						flag = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num2, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), num, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon);
					}
					catch (OutOfMemoryException projectError)
					{
						ProjectData.SetProjectError((Exception)projectError);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						flag = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num2, theTarget.get_Latitude((GlobalVariables.BooleanObject)null), theTarget.get_Longitude((GlobalVariables.BooleanObject)null), num, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon);
						ProjectData.ClearProjectError();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 3495067356897345", "");
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					result = flag;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 4321857569873459867", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			int num3;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num3 = 0;
			}
			else
			{
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Unit.LOSCheckResult Has_Visual_LOS_ToUnit(this Unit myUnit, Sensor mySensor, Unit theUnit, ref Scenario theScen, bool ConsiderClouds, bool considerOverlappingCoordinatesAsValid = false)
	{
		Unit.LOSCheckResult result;
		try
		{
			if (myUnit.IsSatellite && theUnit.IsSatellite)
			{
				result = Has_LOS_ToUnit_Orbital(myUnit, theUnit, ref theScen);
			}
			else if (myUnit.IsSubmarine && Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0 && theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f)
			{
				result = Unit.LOSCheckResult.Fail_Other;
			}
			else
			{
				float num = default(float);
				if (!theUnit.IsSubmarine)
				{
					bool flag = theUnit.IsMobileGroundUnit && IsOverLand(theUnit);
					bool flag2 = theUnit.IsMobileGroundUnit && !IsOverLand(theUnit);
					num = ((theUnit.IsShip || theUnit.IsFacility || flag) ? (theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)theUnit.get_MastHeight_Visual((Sensor)null)) : ((!flag2) ? theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : ((float)(0 + theUnit.get_MastHeight_Visual((Sensor)null)))));
				}
				else if (((Submarine)theUnit).IsAtPeriscopeDepth)
				{
					num = 2f;
				}
				else if (((Submarine)theUnit).IsSurfaced)
				{
					num = 8f;
				}
				float num2;
				int num3;
				if (!myUnit.IsShip && !myUnit.IsFacility && !myUnit.IsAircraft)
				{
					if (myUnit.IsWeapon && ((Weapon)myUnit).Type == Weapon._WeaponType.Sonobuoy && !theUnit.IsSubmarine)
					{
						num2 = 1f;
						num3 = 1;
					}
					else if (myUnit.IsSubmarine && Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) <= -20.0)
					{
						num2 = (float)(Math.Abs(-20) + 2) + myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						num3 = 1;
					}
					else
					{
						num2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
						num3 = 1;
					}
				}
				else
				{
					num2 = myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) + (float)myUnit.get_MastHeight_Visual(mySensor);
					num3 = 1;
				}
				bool flag3 = (byte)num3 != 0;
				bool flag4 = num2 < 0f;
				bool flag5 = num < 0f;
				if (flag4 && num > 0f)
				{
					result = Unit.LOSCheckResult.Fail_Other;
				}
				else if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 0f && flag5)
				{
					result = Unit.LOSCheckResult.Fail_Other;
				}
				else
				{
					if (flag4 && num == 0f)
					{
						flag3 = false;
					}
					if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) == 0f && flag5)
					{
						flag3 = false;
					}
					if (flag4 && flag5)
					{
						flag3 = false;
					}
					if (flag3 && Horizon.VisualHorizonNM(num2, num) < Math2.CalcDist(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null)))
					{
						result = Unit.LOSCheckResult.Fail_OutOfHorizon;
					}
					else if (ConsiderClouds && !Weather.Visibility(myUnit, theUnit, ref theScen))
					{
						result = Unit.LOSCheckResult.Fail_BlockedByCloud;
					}
					else if (myUnit.IsSatellite)
					{
						result = Unit.LOSCheckResult.Success;
					}
					else if (!theUnit.IsSatellite)
					{
						bool flag6 = default(bool);
						try
						{
							flag6 = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num2, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon: false, considerOverlappingCoordinatesAsValid);
						}
						catch (OutOfMemoryException projectError)
						{
							ProjectData.SetProjectError((Exception)projectError);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							flag6 = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num2, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, LandMassCheck: false, theScen, 0, IgnoreRadarHorizon: false, considerOverlappingCoordinatesAsValid);
							ProjectData.ClearProjectError();
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 101176", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
						result = (flag6 ? Unit.LOSCheckResult.Success : Unit.LOSCheckResult.Fail_BlockedByTerrain);
					}
					else
					{
						result = Has_Visual_LOS_ToUnit(theUnit, null, myUnit, ref theScen, ConsiderClouds, considerOverlappingCoordinatesAsValid);
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100870", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			int num4;
			if (!Debugger.IsAttached)
			{
				num4 = 9999;
			}
			else
			{
				Debugger.Break();
				num4 = 9999;
			}
			result = (Unit.LOSCheckResult)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool Has_Sonar_LOS_ToUnit(this Unit myUnit, Unit theUnit, ref Scenario theScen, ref bool LandmassCheckIsNeeded, float? ExplicitSensorDepth = null)
	{
		bool result;
		try
		{
			float num = ((!ExplicitSensorDepth.HasValue) ? myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) : ExplicitSensorDepth.Value);
			int num2;
			if (!(num <= 0f))
			{
				num2 = 0;
				goto IL_0105;
			}
			if (!(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 0f))
			{
				num2 = 0;
				goto IL_0105;
			}
			float alt_Dest = theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			bool flag = default(bool);
			try
			{
				flag = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), alt_Dest, LandmassCheckIsNeeded, theScen);
			}
			catch (OutOfMemoryException projectError)
			{
				ProjectData.SetProjectError((Exception)projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				flag = LOS.DetermineLOS(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), num, theUnit.get_Latitude((GlobalVariables.BooleanObject)null), theUnit.get_Longitude((GlobalVariables.BooleanObject)null), alt_Dest, LandmassCheckIsNeeded, theScen);
				ProjectData.ClearProjectError();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101178", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			result = flag;
			goto end_IL_0001;
			IL_0105:
			result = (byte)num2 != 0;
			end_IL_0001:;
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100871", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			int num3;
			if (!Debugger.IsAttached)
			{
				num3 = 0;
			}
			else
			{
				Debugger.Break();
				num3 = 0;
			}
			result = (byte)num3 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Module_Unit()
	{
		Class72.smethod_20();
	}
}
