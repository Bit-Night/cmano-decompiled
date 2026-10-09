using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class XSection
{
	public enum _SignatureType : short
	{
		HullSonar_PassiveOnly_VLF = 1001,
		HullSonar_PassiveOnly_LF = 1002,
		HullSonar_PassiveOnly_MF = 1003,
		HullSonar_PassiveOnly_HF = 1004,
		ActiveSonar = 2001,
		Visual_Detect = 3001,
		Visual_ID = 3002,
		IR_Detect = 4001,
		IR_ID = 4002,
		Radar_A_D = 5001,
		Radar_E_M = 5002,
		Acoustic_AirGround = 6001
	}

	public enum SignatureAspect : short
	{
		Front,
		Side,
		Rear,
		Top,
		Bottom
	}

	private float float_0;

	private float float_1;

	private float float_2;

	private float float_3;

	public _SignatureType SignatureType;

	private Weapon weapon_0;

	private Weapon weapon_1;

	public float Front
	{
		get
		{
			float result;
			try
			{
				if (theUnit.IsSubmarine)
				{
					Submarine submarine = (Submarine)theUnit;
					if (!submarine.IsSurfaced)
					{
						if (!submarine.IsAtPeriscopeDepth)
						{
							result = float_0;
						}
						else if (theUnit.DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
						{
							switch (SignatureType)
							{
							case _SignatureType.Radar_A_D:
							case _SignatureType.Radar_E_M:
								result = -20f;
								break;
							default:
								result = float_0;
								break;
							case _SignatureType.IR_Detect:
							case _SignatureType.IR_ID:
								result = 2f;
								break;
							case _SignatureType.Visual_Detect:
							case _SignatureType.Visual_ID:
								result = 2f;
								break;
							}
						}
						else
						{
							switch (SignatureType)
							{
							case _SignatureType.Radar_A_D:
							case _SignatureType.Radar_E_M:
								result = -30f;
								break;
							default:
								result = float_0;
								break;
							case _SignatureType.IR_Detect:
							case _SignatureType.IR_ID:
								result = 2f;
								break;
							case _SignatureType.Visual_Detect:
							case _SignatureType.Visual_ID:
								result = 2f;
								break;
							}
						}
					}
					else
					{
						result = float_0;
					}
				}
				else if (theUnit.IsAircraft)
				{
					switch (SignatureType)
					{
					case _SignatureType.Radar_A_D:
					case _SignatureType.Radar_E_M:
						result = method_0((Aircraft)theUnit, float_0, SignatureType, SignatureAspect.Front);
						break;
					default:
						result = float_0;
						break;
					case _SignatureType.IR_Detect:
					{
						double num = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
						float num2;
						if (num > 0.8)
						{
							double relativeIRDetectionRangeMultiplierFromMach = InfraredModel.GetRelativeIRDetectionRangeMultiplierFromMach(num);
							num2 = (float)((double)float_0 * relativeIRDetectionRangeMultiplierFromMach);
						}
						else
						{
							num2 = float_0;
						}
						result = num2;
						break;
					}
					}
				}
				else if (!theUnit.IsMissile)
				{
					if ((object)theUnit.GetType() == typeof(UnguidedRocket))
					{
						switch (SignatureType)
						{
						case _SignatureType.IR_Detect:
						{
							float_0 = 0.77f;
							float maxRange_NoTargetType = ((Weapon)theUnit).MaxRange_NoTargetType;
							float num2 = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType * 0.3)) ? float_0 : ((float)((double)this.get_Rear(theUnit) * 0.5)));
							double num3 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
							if (num3 > 1.0)
							{
								num2 = (float)((double)num2 * Math.Sqrt(num3));
							}
							result = num2;
							break;
						}
						case _SignatureType.Visual_ID:
							result = 0.38f;
							break;
						case _SignatureType.Visual_Detect:
						{
							float_0 = 2f;
							float maxRange_NoTargetType2 = ((Weapon)theUnit).MaxRange_NoTargetType;
							float num2 = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)) ? float_0 : ((float)((double)this.get_Rear(theUnit) * 0.5)));
							result = num2;
							break;
						}
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = float_0;
							break;
						case _SignatureType.Radar_E_M:
							result = -14.6f;
							break;
						case _SignatureType.Radar_A_D:
							result = -14.6f;
							break;
						case _SignatureType.IR_ID:
							result = 0.38f;
							break;
						}
					}
					else
					{
						result = float_0;
					}
				}
				else
				{
					switch (SignatureType)
					{
					case _SignatureType.IR_Detect:
					{
						float num2 = float_0;
						short? num4 = (short?)theUnit.Propulsion.FirstOrDefault()?.Type;
						if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 5001)) != true)
						{
							num2 = float_0;
						}
						else
						{
							Weapon weapon = (Weapon)theUnit;
							num2 = ((!(weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime)) ? float_0 : ((float)((double)float_2 * 0.5)));
						}
						if (((Weapon)theUnit).IsHGV && num2 == 0f)
						{
							num2 = 20f;
						}
						double num5 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
						if (num5 > 1.0)
						{
							num2 = (float)((double)num2 * Math.Sqrt(num5));
						}
						result = num2;
						break;
					}
					case _SignatureType.Visual_Detect:
					{
						float num2 = float_0;
						short? num4 = (short?)theUnit.Propulsion.FirstOrDefault()?.Type;
						if (((!num4.HasValue) ? ((bool?)null) : new bool?(num4 == 5001)) == true)
						{
							Weapon weapon2 = (Weapon)theUnit;
							num2 = ((!(weapon2.TimeSinceLaunch < (float)weapon2.TotalBurnTime)) ? float_0 : ((float)((double)float_2 * 0.5)));
						}
						else
						{
							num2 = float_0;
						}
						if (((Weapon)theUnit).IsHGV && num2 == 0f)
						{
							num2 = 20f;
						}
						result = num2;
						break;
					}
					default:
						result = float_0;
						break;
					case _SignatureType.Radar_E_M:
						if (((Weapon)theUnit).IsHGV && float_0 == 0f)
						{
							float_0 = 5.5f;
						}
						result = float_0;
						break;
					case _SignatureType.Radar_A_D:
						if (((Weapon)theUnit).IsHGV && float_0 == 0f)
						{
							float_0 = 6.5f;
						}
						result = float_0;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101288", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = float_0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public float Side
	{
		get
		{
			float result;
			try
			{
				if (!theUnit.IsSubmarine)
				{
					if (!theUnit.IsAircraft)
					{
						if (!theUnit.IsMissile)
						{
							if ((object)theUnit.GetType() == typeof(UnguidedRocket))
							{
								switch (SignatureType)
								{
								case _SignatureType.IR_Detect:
								{
									float_1 = 4.43f;
									float maxRange_NoTargetType = ((Weapon)theUnit).MaxRange_NoTargetType;
									float num = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType * 0.3)) ? float_1 : ((float)((double)this.get_Rear(theUnit) * 0.75)));
									double num2 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
									if (num2 > 1.0)
									{
										num = (float)((double)num * Math.Sqrt(num2));
									}
									result = num;
									break;
								}
								case _SignatureType.Visual_ID:
									result = 1.01f;
									break;
								case _SignatureType.Visual_Detect:
								{
									float_1 = 5.59f;
									float maxRange_NoTargetType2 = ((Weapon)theUnit).MaxRange_NoTargetType;
									float num = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)) ? float_1 : ((float)((double)this.get_Rear(theUnit) * 0.75)));
									result = num;
									break;
								}
								default:
									if (Debugger.IsAttached)
									{
										Debugger.Break();
									}
									result = float_1;
									break;
								case _SignatureType.Radar_E_M:
									result = -11.5f;
									break;
								case _SignatureType.Radar_A_D:
									result = -11.5f;
									break;
								case _SignatureType.IR_ID:
									result = 1.01f;
									break;
								}
							}
							else
							{
								result = float_1;
							}
						}
						else
						{
							switch (SignatureType)
							{
							case _SignatureType.IR_Detect:
							{
								Engine.EngineType type2 = theUnit.Propulsion[0].Type;
								float num;
								if (type2 == Engine.EngineType.Rocket_BoostCoast)
								{
									Weapon weapon2 = (Weapon)theUnit;
									num = ((!(weapon2.TimeSinceLaunch < (float)weapon2.TotalBurnTime)) ? float_1 : ((float)((double)float_2 * 0.5)));
								}
								else
								{
									num = float_1;
								}
								if (((Weapon)theUnit).IsHGV && num == 0f)
								{
									num = 20f;
								}
								double num3 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
								if (num3 > 1.0)
								{
									num = (float)((double)num * Math.Sqrt(num3));
								}
								result = num;
								break;
							}
							case _SignatureType.Visual_ID:
								result = 1.01f;
								break;
							case _SignatureType.Visual_Detect:
							{
								Engine.EngineType type = theUnit.Propulsion[0].Type;
								float num;
								if (type == Engine.EngineType.Rocket_BoostCoast)
								{
									Weapon weapon = (Weapon)theUnit;
									num = ((!(weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime)) ? float_1 : ((float)((double)float_2 * 0.5)));
								}
								else
								{
									num = float_1;
								}
								if (((Weapon)theUnit).IsHGV && num == 0f)
								{
									num = 20f;
								}
								result = num;
								break;
							}
							default:
								result = float_1;
								break;
							case _SignatureType.Radar_E_M:
								if (((Weapon)theUnit).IsHGV && float_1 == 0f)
								{
									float_1 = 5.5f;
								}
								result = float_1;
								break;
							case _SignatureType.Radar_A_D:
								if (((Weapon)theUnit).IsHGV && float_1 == 0f)
								{
									float_1 = 6.5f;
								}
								result = float_1;
								break;
							case _SignatureType.IR_ID:
								result = 1.01f;
								break;
							}
						}
					}
					else
					{
						switch (SignatureType)
						{
						default:
							result = float_1;
							break;
						case _SignatureType.Radar_A_D:
						case _SignatureType.Radar_E_M:
							result = method_0((Aircraft)theUnit, float_1, SignatureType, SignatureAspect.Side);
							break;
						case _SignatureType.IR_Detect:
						{
							double num4 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
							if (num4 > 0.8)
							{
								double relativeIRDetectionRangeMultiplierFromMach = InfraredModel.GetRelativeIRDetectionRangeMultiplierFromMach(num4);
								float num = (float)((double)float_1 * relativeIRDetectionRangeMultiplierFromMach);
							}
							else
							{
								float num = float_1;
							}
							result = float_1;
							break;
						}
						}
					}
				}
				else if (((Submarine)theUnit).IsSurfaced)
				{
					result = float_1;
				}
				else if (!((Submarine)theUnit).IsAtPeriscopeDepth)
				{
					result = float_1;
				}
				else
				{
					switch (SignatureType)
					{
					case _SignatureType.Radar_A_D:
					case _SignatureType.Radar_E_M:
						result = -30f;
						break;
					default:
						result = float_1;
						break;
					case _SignatureType.IR_Detect:
					case _SignatureType.IR_ID:
						result = 2f;
						break;
					case _SignatureType.Visual_Detect:
					case _SignatureType.Visual_ID:
						result = 2f;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101289", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = float_1;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public float Rear
	{
		get
		{
			float result;
			try
			{
				if (!theUnit.IsSubmarine)
				{
					if (!theUnit.IsAircraft)
					{
						if (theUnit.IsMissile)
						{
							switch (SignatureType)
							{
							case _SignatureType.Visual_Detect:
							case _SignatureType.IR_Detect:
							{
								Engine.EngineType type = theUnit.Propulsion[0].Type;
								float num;
								if (type == Engine.EngineType.Rocket_BoostCoast)
								{
									Weapon weapon = (Weapon)theUnit;
									num = ((!(weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime)) ? float_0 : float_2);
								}
								else
								{
									num = float_2;
								}
								if (((Weapon)theUnit).IsHGV && num == 0f)
								{
									num = 20f;
								}
								result = num;
								break;
							}
							default:
								result = float_2;
								break;
							case _SignatureType.Radar_E_M:
								if (((Weapon)theUnit).IsHGV && float_2 == 0f)
								{
									float_2 = 5.5f;
								}
								result = float_2;
								break;
							case _SignatureType.Radar_A_D:
								if (((Weapon)theUnit).IsHGV && float_2 == 0f)
								{
									float_2 = 6.5f;
								}
								result = float_2;
								break;
							}
						}
						else if ((object)theUnit.GetType() == typeof(UnguidedRocket))
						{
							switch (SignatureType)
							{
							case _SignatureType.IR_Detect:
							{
								float_2 = 9.9f;
								float maxRange_NoTargetType = ((Weapon)theUnit).MaxRange_NoTargetType;
								float num = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType * 0.3)) ? float_2 : (float_2 * 4f));
								double num2 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
								if (num2 > 1.0)
								{
									num = (float)((double)num * Math.Sqrt(num2));
								}
								result = num;
								break;
							}
							case _SignatureType.Visual_ID:
								result = 0.47f;
								break;
							case _SignatureType.Visual_Detect:
							{
								float_2 = 2f;
								float maxRange_NoTargetType2 = ((Weapon)theUnit).MaxRange_NoTargetType;
								float num = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)) ? float_2 : (float_2 * 4f));
								result = num;
								break;
							}
							default:
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = float_2;
								break;
							case _SignatureType.Radar_E_M:
								result = -14.6f;
								break;
							case _SignatureType.Radar_A_D:
								result = -14.6f;
								break;
							case _SignatureType.IR_ID:
								result = 0.38f;
								break;
							}
						}
						else
						{
							result = float_2;
						}
					}
					else
					{
						switch (SignatureType)
						{
						default:
							result = float_2;
							break;
						case _SignatureType.Radar_A_D:
						case _SignatureType.Radar_E_M:
							result = method_0((Aircraft)theUnit, float_2, SignatureType, SignatureAspect.Rear);
							break;
						case _SignatureType.IR_Detect:
						{
							float num3 = float_2;
							result = theUnit.ThrottleSetting switch
							{
								ActiveUnit.Throttle.FullStop => (float)((double)num3 * 1.5), 
								ActiveUnit.Throttle.Loiter => (float)((double)num3 * 0.85), 
								ActiveUnit.Throttle.Cruise => num3, 
								ActiveUnit.Throttle.Full => (float)((double)num3 * 1.2), 
								ActiveUnit.Throttle.Flank => (float)((double)num3 * 1.5), 
								_ => float_2, 
							};
							break;
						}
						}
					}
				}
				else if (!((Submarine)theUnit).IsSurfaced)
				{
					if (((Submarine)theUnit).IsAtPeriscopeDepth)
					{
						switch (SignatureType)
						{
						case _SignatureType.Radar_A_D:
						case _SignatureType.Radar_E_M:
							result = -30f;
							break;
						default:
							result = float_2;
							break;
						case _SignatureType.IR_Detect:
						case _SignatureType.IR_ID:
							result = 2f;
							break;
						case _SignatureType.Visual_Detect:
						case _SignatureType.Visual_ID:
							result = 2f;
							break;
						}
					}
					else
					{
						result = float_2;
					}
				}
				else
				{
					result = float_2;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101290", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = float_2;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public float Top
	{
		get
		{
			float result;
			try
			{
				if (theUnit.IsSubmarine)
				{
					if (((Submarine)theUnit).IsSurfaced)
					{
						result = float_3;
					}
					else if (((Submarine)theUnit).IsAtPeriscopeDepth)
					{
						switch (SignatureType)
						{
						case _SignatureType.Radar_A_D:
						case _SignatureType.Radar_E_M:
							result = -30f;
							break;
						default:
							result = float_3;
							break;
						case _SignatureType.IR_Detect:
						case _SignatureType.IR_ID:
							result = 2f;
							break;
						case _SignatureType.Visual_Detect:
						case _SignatureType.Visual_ID:
							result = 2f;
							break;
						}
					}
					else
					{
						result = float_3;
					}
				}
				else if (!theUnit.IsAircraft)
				{
					if (theUnit.IsMissile)
					{
						switch (SignatureType)
						{
						case _SignatureType.IR_Detect:
						{
							Engine.EngineType type2 = theUnit.Propulsion[0].Type;
							float num;
							if (type2 == Engine.EngineType.Rocket_BoostCoast)
							{
								Weapon weapon2 = (Weapon)theUnit;
								num = ((!(weapon2.TimeSinceLaunch < (float)weapon2.TotalBurnTime)) ? float_3 : ((float)((double)float_2 * 0.5)));
							}
							else
							{
								num = float_3;
							}
							if (((Weapon)theUnit).IsHGV && num == 0f)
							{
								num = 20f;
							}
							double num2 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
							if (num2 > 1.0)
							{
								num = (float)((double)num * Math.Sqrt(num2));
							}
							result = num;
							break;
						}
						case _SignatureType.Visual_ID:
							result = 1.01f;
							break;
						case _SignatureType.Visual_Detect:
						{
							Engine.EngineType type = theUnit.Propulsion[0].Type;
							float num;
							if (type == Engine.EngineType.Rocket_BoostCoast)
							{
								Weapon weapon = (Weapon)theUnit;
								num = ((!(weapon.TimeSinceLaunch < (float)weapon.TotalBurnTime)) ? float_3 : ((float)((double)float_2 * 0.5)));
							}
							else
							{
								num = float_3;
							}
							if (((Weapon)theUnit).IsHGV && num == 0f)
							{
								num = 20f;
							}
							result = num;
							break;
						}
						default:
							result = float_3;
							break;
						case _SignatureType.Radar_E_M:
							if (((Weapon)theUnit).IsHGV && float_3 == 0f)
							{
								float_3 = 5.5f;
							}
							result = float_3;
							break;
						case _SignatureType.Radar_A_D:
							if (((Weapon)theUnit).IsHGV && float_3 == 0f)
							{
								float_3 = 6.5f;
							}
							result = float_3;
							break;
						case _SignatureType.IR_ID:
							result = 1.01f;
							break;
						}
					}
					else if ((object)theUnit.GetType() == typeof(UnguidedRocket))
					{
						switch (SignatureType)
						{
						case _SignatureType.IR_Detect:
						{
							float_3 = 4.43f;
							float maxRange_NoTargetType = ((Weapon)theUnit).MaxRange_NoTargetType;
							float num = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType * 0.3)) ? float_3 : ((float)((double)this.get_Rear(theUnit) * 0.75)));
							double num3 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
							if (num3 > 1.0)
							{
								num = (float)((double)num * Math.Sqrt(num3));
							}
							result = num;
							break;
						}
						case _SignatureType.Visual_ID:
							result = 1.01f;
							break;
						case _SignatureType.Visual_Detect:
						{
							float_3 = 5.59f;
							float maxRange_NoTargetType2 = ((Weapon)theUnit).MaxRange_NoTargetType;
							float num = ((!((double)Module_Unit.RangeToPoint_Horiz(theUnit, ((Weapon)theUnit).LaunchPoint) < (double)maxRange_NoTargetType2 * 0.3)) ? float_3 : ((float)((double)this.get_Rear(theUnit) * 0.75)));
							result = num;
							break;
						}
						default:
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = float_3;
							break;
						case _SignatureType.Radar_E_M:
							result = -11.5f;
							break;
						case _SignatureType.Radar_A_D:
							result = -11.5f;
							break;
						case _SignatureType.IR_ID:
							result = 1.01f;
							break;
						}
					}
					else
					{
						result = float_3;
					}
				}
				else
				{
					switch (SignatureType)
					{
					default:
						result = float_3;
						break;
					case _SignatureType.Radar_A_D:
					case _SignatureType.Radar_E_M:
						result = method_0((Aircraft)theUnit, float_3, SignatureType, SignatureAspect.Top);
						break;
					case _SignatureType.IR_Detect:
					{
						double num4 = Physics.ComputeMach(theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), theUnit.CurrentSpeed);
						if (num4 > 0.8)
						{
							double relativeIRDetectionRangeMultiplierFromMach = InfraredModel.GetRelativeIRDetectionRangeMultiplierFromMach(num4);
							float num = (float)((double)float_3 * relativeIRDetectionRangeMultiplierFromMach);
						}
						else
						{
							float num = float_3;
						}
						result = float_3;
						break;
					}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101289", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = float_3;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public (float, float, float, float) GetRawValues(float Factor = 1f)
	{
		return (float_0 * Factor, float_1 * Factor, float_2 * Factor, float_3 * Factor);
	}

	public void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("XSection");
			theWriter.WriteElementString("Front", XmlConvert.ToString(float_0));
			theWriter.WriteElementString("Side", XmlConvert.ToString(float_1));
			theWriter.WriteElementString("Rear", XmlConvert.ToString(float_2));
			theWriter.WriteElementString("Top", XmlConvert.ToString(float_3));
			XmlWriter obj = theWriter;
			int signatureType = (int)SignatureType;
			obj.WriteElementString("Type", signatureType.ToString());
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101079", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static XSection FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		XSection result;
		try
		{
			XSection xSection = new XSection();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Side":
					xSection.float_1 = XmlConvert.ToInt32(val.InnerText.Replace(",", "."));
					break;
				case "Rear":
					xSection.float_2 = XmlConvert.ToInt32(val.InnerText.Replace(",", "."));
					break;
				case "SignatureType":
				case "Type":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						xSection.SignatureType = (_SignatureType)Conversions.ToShort(val.InnerText);
					}
					else
					{
						xSection.SignatureType = (_SignatureType)Enum.Parse(typeof(_SignatureType), val.InnerText, ignoreCase: true);
					}
					break;
				case "Top":
					xSection.float_3 = XmlConvert.ToInt32(val.InnerText.Replace(",", "."));
					break;
				case "Front":
					xSection.float_0 = XmlConvert.ToInt32(val.InnerText.Replace(",", "."));
					break;
				}
			}
			result = xSection;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101080", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new XSection();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static int GetSignatureTypeIndex(_SignatureType type)
	{
		int num = default(int);
		return type switch
		{
			_SignatureType.ActiveSonar => 4, 
			_SignatureType.HullSonar_PassiveOnly_VLF => 0, 
			_SignatureType.HullSonar_PassiveOnly_LF => 1, 
			_SignatureType.HullSonar_PassiveOnly_MF => 2, 
			_SignatureType.HullSonar_PassiveOnly_HF => 3, 
			_SignatureType.Visual_ID => 6, 
			_SignatureType.Visual_Detect => 5, 
			_SignatureType.Acoustic_AirGround => 11, 
			_SignatureType.Radar_E_M => 10, 
			_SignatureType.Radar_A_D => 9, 
			_SignatureType.IR_ID => 8, 
			_SignatureType.IR_Detect => 7, 
			_ => num, 
		};
	}

	private XSection()
	{
	}

	public XSection(_SignatureType theSensorType, float theFront, float theSide, float theRear, float theTop)
	{
		SignatureType = theSensorType;
		float_0 = theFront;
		float_1 = theSide;
		float_2 = theRear;
		float_3 = theTop;
	}

	public bool isDBInvisible(ActiveUnit theUnit)
	{
		if (float_0 != -10000f && float_1 != -10000f && float_2 != -10000f)
		{
			return float_3 == -10000f;
		}
		return true;
	}

	private float method_0(Aircraft aircraft_0, float float_4, _SignatureType _SignatureType_0, SignatureAspect signatureAspect_0)
	{
		RadarModel.TTarget tTarget = new RadarModel.TTarget();
		float result;
		try
		{
			if (aircraft_0.Loadout == null)
			{
				result = float_4;
			}
			else
			{
				tTarget.RCS = float_4;
				float num = (float)tTarget.RCS_m2;
				WeaponRec[] weapons = aircraft_0.Loadout.Weapons;
				float num2 = default(float);
				float num3 = default(float);
				foreach (WeaponRec weaponRec in weapons)
				{
					if (weaponRec.InternalWeapons)
					{
						continue;
					}
					Weapon weapon = weaponRec.get_ReferenceWeapon(aircraft_0.ParentScen);
					XSection xSection = Sensor.smethod_0(weapon, _SignatureType_0);
					if (xSection == null)
					{
						xSection = Sensor.smethod_0(weapon, _SignatureType_0);
					}
					if (xSection == null || xSection.isDBInvisible(weapon))
					{
						continue;
					}
					switch (signatureAspect_0)
					{
					case SignatureAspect.Front:
					{
						num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Front((ActiveUnit)weapon);
						if (num2 == 0f)
						{
							if (weapon.IsFuelTank)
							{
								if (weapon_0 == null)
								{
									weapon_0 = aircraft_0.ParentScen.Cache_GetWeapon(554);
								}
								weapon = weapon_0;
							}
							else if (weapon.Type == Weapon._WeaponType.SensorPod)
							{
								if (weapon_1 == null)
								{
									weapon_1 = aircraft_0.ParentScen.Cache_GetWeapon(641);
								}
								weapon = weapon_1;
							}
							num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Front((ActiveUnit)weapon);
						}
						num3 = (short)weaponRec.CurrentLoad;
						float num5 = num3;
						if (!(num5 <= 6f))
						{
							num3 = ((!(num5 <= 12f)) ? ((float)(short)Math.Floor(num3 / 3f)) : 6f);
						}
						break;
					}
					case SignatureAspect.Side:
						num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Side((ActiveUnit)weapon);
						if (num2 == 0f)
						{
							if (weapon.IsFuelTank)
							{
								if (weapon_0 == null)
								{
									weapon_0 = aircraft_0.ParentScen.Cache_GetWeapon(554);
								}
								weapon = weapon_0;
							}
							else if (weapon.Type == Weapon._WeaponType.SensorPod)
							{
								if (weapon_1 == null)
								{
									weapon_1 = aircraft_0.ParentScen.Cache_GetWeapon(641);
								}
								weapon = weapon_1;
							}
							num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Side((ActiveUnit)weapon);
						}
						num3 = (short)Math.Round((double)weaponRec.CurrentLoad / 2.0);
						break;
					case SignatureAspect.Rear:
					{
						num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Rear((ActiveUnit)weapon);
						if (num2 == 0f)
						{
							if (!weapon.IsFuelTank)
							{
								if (weapon.Type == Weapon._WeaponType.SensorPod)
								{
									if (weapon_1 == null)
									{
										weapon_1 = aircraft_0.ParentScen.Cache_GetWeapon(641);
									}
									weapon = weapon_1;
								}
							}
							else
							{
								if (weapon_0 == null)
								{
									weapon_0 = aircraft_0.ParentScen.Cache_GetWeapon(554);
								}
								weapon = weapon_0;
							}
							num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Rear((ActiveUnit)weapon);
						}
						num3 = (short)weaponRec.CurrentLoad;
						float num4 = num3;
						if (!(num4 <= 6f))
						{
							num3 = ((!(num4 <= 12f)) ? ((float)(short)Math.Floor(num3 / 6f)) : 6f);
						}
						break;
					}
					case SignatureAspect.Top:
						num3 = 0f;
						break;
					case SignatureAspect.Bottom:
						num2 = Sensor.smethod_0(weapon, _SignatureType_0).get_Side((ActiveUnit)weapon);
						num3 = (short)weaponRec.CurrentLoad;
						break;
					}
					if (!aircraft_0.RCCS_StealthPylons)
					{
						num3 = (float)((double)num3 * 1.2);
					}
					if (num2 != -10000f && num2 != 0f)
					{
						tTarget.RCS = num2;
						float num6 = (float)tTarget.RCS_m2;
						num += num6 * num3;
					}
				}
				tTarget.RCS_m2 = num;
				result = (float)tTarget.RCS;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101081", "");
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

	static XSection()
	{
		Class72.smethod_20();
	}
}
