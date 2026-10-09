using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Collections.Pooled;
using Cysharp.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public abstract class PlatformComponent : ScenarioObject
{
	public delegate void StatusChangedEventHandler(PlatformComponent theComponent);

	internal struct ComponentProtection
	{
		internal GlobalVariables.ArmorRating ArmorRating;

		internal ProtectionType ProtectionType;

		internal bool InsideArmoredStructure;
	}

	public enum BooleanResponse : byte
	{
		Undefined,
		ResponseTrue,
		ResponseFalse
	}

	public enum _ComponentStatus : byte
	{
		Operational,
		Damaged,
		Destroyed
	}

	public enum _DamageSeverityFactor : byte
	{
		Light,
		Medium,
		Heavy
	}

	public enum ProtectionType : byte
	{
		Unarmored,
		Armored,
		ArmoredStructure
	}

	public class _Coverage
	{
		public bool PS1;

		public bool PMA1;

		public bool PMF1;

		public bool PB1;

		public bool SS1;

		public bool SMA1;

		public bool SMF1;

		public bool SB1;

		public bool PS2;

		public bool PMA2;

		public bool PMF2;

		public bool PB2;

		public bool SS2;

		public bool SMA2;

		public bool SMF2;

		public bool SB2;

		public const int NUM_COVERAGE_ARCS = 16;

		public Lazy<bool> Has360Coverage;

		public bool HasDefinedArcs
		{
			get
			{
				if (PB1)
				{
					goto IL_009a;
				}
				int result;
				if (PB2)
				{
					result = 1;
				}
				else
				{
					if (PMA1)
					{
						goto IL_009a;
					}
					if (PMA2)
					{
						result = 1;
					}
					else
					{
						if (PMF1 || PMF2)
						{
							goto IL_009a;
						}
						if (PS1)
						{
							result = 1;
						}
						else
						{
							if (PS2 || SB1)
							{
								goto IL_009a;
							}
							if (SB2)
							{
								result = 1;
							}
							else
							{
								if (SMA1)
								{
									goto IL_009a;
								}
								if (SMA2)
								{
									result = 1;
								}
								else if (SMF1)
								{
									result = 1;
								}
								else
								{
									if (SMF2)
									{
										goto IL_009a;
									}
									if (!SS1)
									{
										return SS2;
									}
									result = 1;
								}
							}
						}
					}
				}
				goto IL_009b;
				IL_009b:
				return (byte)result != 0;
				IL_009a:
				result = 1;
				goto IL_009b;
			}
		}

		public _Coverage()
		{
			Has360Coverage = new Lazy<bool>(method_0);
		}

		public _Coverage Clone()
		{
			return (_Coverage)MemberwiseClone();
		}

		public string ToXML(bool IsIlluminate)
		{
			Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
			try
			{
				if (IsIlluminate)
				{
					utf16ValueStringBuilder.Append("<Cov_Ill>");
				}
				else
				{
					utf16ValueStringBuilder.Append("<Cov>");
				}
				if (!Has360Coverage.Value)
				{
					utf16ValueStringBuilder.Append("<Seg>");
					if (PB1)
					{
						utf16ValueStringBuilder.Append("PB1,");
					}
					if (PB2)
					{
						utf16ValueStringBuilder.Append("PB2,");
					}
					if (PMA1)
					{
						utf16ValueStringBuilder.Append("PMA1,");
					}
					if (PMA2)
					{
						utf16ValueStringBuilder.Append("PMA2,");
					}
					if (PMF1)
					{
						utf16ValueStringBuilder.Append("PMF1,");
					}
					if (PMF2)
					{
						utf16ValueStringBuilder.Append("PMF2,");
					}
					if (PS1)
					{
						utf16ValueStringBuilder.Append("PS1,");
					}
					if (PS2)
					{
						utf16ValueStringBuilder.Append("PS2,");
					}
					if (SB1)
					{
						utf16ValueStringBuilder.Append("SB1,");
					}
					if (SB2)
					{
						utf16ValueStringBuilder.Append("SB2,");
					}
					if (SMA1)
					{
						utf16ValueStringBuilder.Append("SMA1,");
					}
					if (SMA2)
					{
						utf16ValueStringBuilder.Append("SMA2,");
					}
					if (SMF1)
					{
						utf16ValueStringBuilder.Append("SMF1,");
					}
					if (SMF2)
					{
						utf16ValueStringBuilder.Append("SMF2,");
					}
					if (SS1)
					{
						utf16ValueStringBuilder.Append("SS1,");
					}
					if (SS2)
					{
						utf16ValueStringBuilder.Append("SS2,");
					}
					utf16ValueStringBuilder.Append("</Seg>");
				}
				else
				{
					utf16ValueStringBuilder.Append("<Seg>360</Seg>");
				}
				if (!IsIlluminate)
				{
					utf16ValueStringBuilder.Append("</Cov>");
				}
				else
				{
					utf16ValueStringBuilder.Append("</Cov_Ill>");
				}
				string result = utf16ValueStringBuilder.ToString();
				utf16ValueStringBuilder.Dispose();
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 104985609568943068", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}

		public static _Coverage FromXML(ref XmlNode theNode)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			_Coverage result = default(_Coverage);
			try
			{
				_Coverage coverage = new _Coverage();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "PortStern":
						coverage.PS1 = Misc.ParseBool(val.InnerText);
						coverage.PS2 = Misc.ParseBool(val.InnerText);
						break;
					case "PortMiddleForward":
						coverage.PMF1 = Misc.ParseBool(val.InnerText);
						coverage.PMF2 = Misc.ParseBool(val.InnerText);
						break;
					case "StarboardStern":
						coverage.SS1 = Misc.ParseBool(val.InnerText);
						coverage.SS2 = Misc.ParseBool(val.InnerText);
						break;
					case "StarboardMiddleForward":
						coverage.SMF1 = Misc.ParseBool(val.InnerText);
						coverage.SMF2 = Misc.ParseBool(val.InnerText);
						break;
					case "Seg":
					case "Segments":
					{
						string[] array = val.InnerText.Split(new char[1] { ',' });
						foreach (string text in array)
						{
							if (!string.IsNullOrEmpty(text))
							{
								switch (text.Trim())
								{
								case "SS2":
									coverage.SS2 = true;
									continue;
								case "PMA2":
									coverage.PMA2 = true;
									continue;
								case "PB2":
									coverage.PB2 = true;
									continue;
								case "SS1":
									coverage.SS1 = true;
									continue;
								case "PMF1":
									coverage.PMF1 = true;
									continue;
								case "PS2":
									coverage.PS2 = true;
									continue;
								case "PMA1":
									coverage.PMA1 = true;
									continue;
								case "PMF2":
									coverage.PMF2 = true;
									continue;
								case "SMA1":
									coverage.SMA1 = true;
									continue;
								case "SMF2":
									coverage.SMF2 = true;
									continue;
								case "SMF1":
									coverage.SMF1 = true;
									continue;
								case "PB1":
									coverage.PB1 = true;
									continue;
								case "PS1":
									coverage.PS1 = true;
									continue;
								case "SB2":
									coverage.SB2 = true;
									continue;
								case "SB1":
									coverage.SB1 = true;
									continue;
								case "SMA2":
									coverage.SMA2 = true;
									continue;
								default:
									continue;
								case "360":
									break;
								}
								coverage.PB1 = true;
								coverage.PMA1 = true;
								coverage.PMF1 = true;
								coverage.PS1 = true;
								coverage.SB1 = true;
								coverage.SMA1 = true;
								coverage.SMF1 = true;
								coverage.SS1 = true;
								coverage.PB2 = true;
								coverage.PMA2 = true;
								coverage.PMF2 = true;
								coverage.PS2 = true;
								coverage.SB2 = true;
								coverage.SMA2 = true;
								coverage.SMF2 = true;
								coverage.SS2 = true;
								break;
							}
						}
						break;
					}
					case "PortBow":
						coverage.PB1 = Misc.ParseBool(val.InnerText);
						coverage.PB2 = Misc.ParseBool(val.InnerText);
						break;
					case "StarboardBow":
						coverage.SB1 = Misc.ParseBool(val.InnerText);
						coverage.SB2 = Misc.ParseBool(val.InnerText);
						break;
					case "StarboardMiddleAft":
						coverage.SMA1 = Misc.ParseBool(val.InnerText);
						coverage.SMA2 = Misc.ParseBool(val.InnerText);
						break;
					case "PortMiddleAft":
						coverage.PMA1 = Misc.ParseBool(val.InnerText);
						coverage.PMA2 = Misc.ParseBool(val.InnerText);
						break;
					}
				}
				result = coverage;
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100688", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			return result;
		}

		private bool method_0()
		{
			int result;
			if (HasDefinedArcs)
			{
				if (!PB1 || !PB2 || !PMA1)
				{
					goto IL_00ac;
				}
				if (!PMA2)
				{
					result = 0;
				}
				else if (!PMF1)
				{
					result = 0;
				}
				else if (!PMF2)
				{
					result = 0;
				}
				else if (!PS1)
				{
					result = 0;
				}
				else if (!PS2)
				{
					result = 0;
				}
				else if (!SB1)
				{
					result = 0;
				}
				else
				{
					if (!SB2 || !SMA1)
					{
						goto IL_00ac;
					}
					if (!SMA2)
					{
						result = 0;
					}
					else if (!SMF1)
					{
						result = 0;
					}
					else
					{
						if (!SMF2 || !SS1)
						{
							goto IL_00ac;
						}
						result = (SS2 ? 1 : 0);
					}
				}
				goto IL_00ad;
			}
			return true;
			IL_00ac:
			result = 0;
			goto IL_00ad;
			IL_00ad:
			return (byte)result != 0;
		}

		public void ComponentArcString(ref PlatformComponent theSensor, ref List<string> theArcList)
		{
			if (Has360Coverage.Value)
			{
				theArcList.Add("360");
				return;
			}
			if (PB1)
			{
				theArcList.Add("PB1");
			}
			if (PB2)
			{
				theArcList.Add("PB2");
			}
			if (PMA1)
			{
				theArcList.Add("PMA1");
			}
			if (PMA2)
			{
				theArcList.Add("PMA2");
			}
			if (PMF1)
			{
				theArcList.Add("PMF1");
			}
			if (PMF2)
			{
				theArcList.Add("PMF2");
			}
			if (PS1)
			{
				theArcList.Add("PS1");
			}
			if (PS2)
			{
				theArcList.Add("PS2");
			}
			if (SB1)
			{
				theArcList.Add("SB1");
			}
			if (SB2)
			{
				theArcList.Add("SB2");
			}
			if (SMA1)
			{
				theArcList.Add("SMA1");
			}
			if (SMA2)
			{
				theArcList.Add("SMA2");
			}
			if (SMF1)
			{
				theArcList.Add("SMF1");
			}
			if (SMF2)
			{
				theArcList.Add("SMF2");
			}
			if (SS1)
			{
				theArcList.Add("SS1");
			}
			if (SS2)
			{
				theArcList.Add("SS2");
			}
		}

		internal int GetNextCoverageIndex(int index, bool clockwise)
		{
			int num = index;
			if (!clockwise)
			{
				num--;
				if (num < 0)
				{
					num += 16;
				}
			}
			else
			{
				num++;
				if (num >= 16)
				{
					num = 16 - num;
				}
			}
			return num;
		}

		internal bool GetCoverageByIndex(int index)
		{
			return index switch
			{
				0 => SB1, 
				1 => SB2, 
				2 => SMF1, 
				3 => SMF2, 
				4 => SMA1, 
				5 => SMA2, 
				6 => SS1, 
				7 => SS2, 
				8 => PS1, 
				9 => PS2, 
				10 => PMA1, 
				11 => PMA2, 
				12 => PMF1, 
				13 => PMF2, 
				14 => PB1, 
				15 => PB2, 
				_ => false, 
			};
		}

		static _Coverage()
		{
			Class72.smethod_20();
		}
	}

	protected _ComponentStatus _Status;

	protected ActiveUnit _ParentPlatform;

	private _DamageSeverityFactor _DamageSeverityFactor_0;

	public _Coverage Coverage;

	public int DBID;

	[CompilerGenerated]
	private static StatusChangedEventHandler statusChangedEventHandler_0;

	public bool IsAirFacility => (object)GetType() == typeof(AirFacility);

	public bool IsCargo => (object)GetType() == typeof(Cargo);

	public bool IsCargoContainer => (object)GetType() == typeof(CargoContainer);

	public bool IsCIC => (object)GetType() == typeof(CIC);

	public bool IsCommDevice => (object)GetType() == typeof(CommDevice);

	public bool IsDockFacility => (object)GetType() == typeof(DockFacility);

	public bool IsEngine => (object)GetType() == typeof(Engine);

	public bool IsMagazine => (object)GetType() == typeof(Magazine);

	public bool IsMount => (object)GetType() == typeof(Mount);

	public bool IsPressureHull => (object)GetType() == typeof(PressureHull);

	public bool IsRudder => (object)GetType() == typeof(Rudder);

	public bool IsSensor => (object)GetType() == typeof(Sensor);

	internal bool StructureVulnerableToBlast => GetArmor.ProtectionType != ProtectionType.ArmoredStructure;

	internal ComponentProtection GetArmor
	{
		get
		{
			ComponentProtection result = default(ComponentProtection);
			result.ArmorRating = GlobalVariables.ArmorRating.None;
			result.ProtectionType = ProtectionType.Unarmored;
			Type type = GetType();
			if (type == typeof(AirFacility))
			{
				Type type2 = ParentPlatform.GetType();
				if (type2 == typeof(Aircraft))
				{
					return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, ((Aircraft)ParentPlatform).Armor_Fuselage);
				}
				if (type2 == typeof(Facility))
				{
					bool flag = ((AirFacility)this).AirFacType == AirFacility._AirFacType.OpenParking || ((AirFacility)this).AirFacType == AirFacility._AirFacType.Runway;
					return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, (!flag) ? ((Facility)ParentPlatform).Armor_General : GlobalVariables.ArmorRating.None);
				}
				if (!(type2 == typeof(Ship)))
				{
					if (type2 == typeof(Submarine))
					{
						return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, GlobalVariables.ArmorRating.Heavy);
					}
				}
				else if (((Ship)ParentPlatform).Category == Ship._ShipCategory.AviationShip)
				{
					AirFacility._AirFacType airFacType = ((AirFacility)this).AirFacType;
					if (airFacType == AirFacility._AirFacType.OpenParking || airFacType == AirFacility._AirFacType.Runway)
					{
						return method_0(((Ship)ParentPlatform).Armor_Deck, ProtectionType.ArmoredStructure);
					}
					return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, ((Ship)ParentPlatform).MaxCitadelArmor);
				}
			}
			else if (!(type == typeof(CIC)))
			{
				if (!(type == typeof(DockFacility)))
				{
					if (!(type == typeof(Engine)))
					{
						if (type == typeof(Magazine))
						{
							if (!(ParentPlatform.GetType() == typeof(Ship)))
							{
								return method_0(((Magazine)this).Armor, ProtectionType.Armored);
							}
							return method_0(((Magazine)this).Armor, ProtectionType.Armored);
						}
						if (type == typeof(Mount))
						{
							return method_0(((Mount)this).ArmorRating, ProtectionType.Armored);
						}
						if (type == typeof(PressureHull))
						{
							return method_0(GlobalVariables.ArmorRating.Heavy, ProtectionType.Armored);
						}
						if (type == typeof(Rudder) && ParentPlatform.GetType() == typeof(Ship))
						{
							return method_0(((Ship)ParentPlatform).Armor_Rudder, ProtectionType.Armored);
						}
					}
					else
					{
						Type type3 = ParentPlatform.GetType();
						if (type3 == typeof(Aircraft))
						{
							return method_0(((Aircraft)ParentPlatform).Armor_Powerplant, ProtectionType.Armored);
						}
						if (type3 == typeof(Facility))
						{
							return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, ((Facility)ParentPlatform).Armor_General);
						}
						if (type3 == typeof(Ship))
						{
							return method_0(((Ship)ParentPlatform).Armor_Engineering, ProtectionType.Armored, ((Ship)ParentPlatform).MinCitadelArmor);
						}
						if (type3 == typeof(Submarine))
						{
							return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, GlobalVariables.ArmorRating.Heavy);
						}
					}
				}
			}
			else
			{
				Type type4 = ParentPlatform.GetType();
				if (type4 == typeof(Facility))
				{
					return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, ((Facility)ParentPlatform).Armor_General);
				}
				if (type4 == typeof(Ship))
				{
					return method_0(((Ship)ParentPlatform).Armor_CIC, ProtectionType.Armored, ((Ship)ParentPlatform).MinCitadelArmor);
				}
				if (type4 == typeof(Submarine))
				{
					return method_0(GlobalVariables.ArmorRating.None, ProtectionType.Unarmored, GlobalVariables.ArmorRating.Heavy);
				}
			}
			return result;
		}
	}

	public int StepsToDestruction
	{
		get
		{
			int num = ((!DestroyableByNonNuclear) ? 1 : 0);
			return Status switch
			{
				_ComponentStatus.Destroyed => 0, 
				_ComponentStatus.Operational => 4 - num, 
				_ => (int)(3 - _DamageSeverityFactor_0) - num, 
			};
		}
	}

	public bool DestroyableByNonNuclear
	{
		get
		{
			int result;
			if (!IsAirFacility)
			{
				result = 1;
			}
			else
			{
				if (((AirFacility)this).IsOpenAirFacility)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
	}

	public _DamageSeverityFactor DamageSeverity
	{
		get
		{
			return _DamageSeverityFactor_0;
		}
		set
		{
			_DamageSeverityFactor_0 = value;
		}
	}

	public virtual ActiveUnit ParentPlatform
	{
		get
		{
			return _ParentPlatform;
		}
		set
		{
			_ParentPlatform = value;
		}
	}

	public virtual (BooleanResponse Response, string ResponseString) ReasonForInoperative => (Response: BooleanResponse.Undefined, ResponseString: "None");

	public _ComponentStatus Status => _Status;

	public static event StatusChangedEventHandler StatusChanged
	{
		[CompilerGenerated]
		add
		{
			StatusChangedEventHandler statusChangedEventHandler = statusChangedEventHandler_0;
			StatusChangedEventHandler statusChangedEventHandler2;
			do
			{
				statusChangedEventHandler2 = statusChangedEventHandler;
				StatusChangedEventHandler value2 = (StatusChangedEventHandler)Delegate.Combine(statusChangedEventHandler2, value);
				statusChangedEventHandler = Interlocked.CompareExchange(ref statusChangedEventHandler_0, value2, statusChangedEventHandler2);
			}
			while ((object)statusChangedEventHandler != statusChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			StatusChangedEventHandler statusChangedEventHandler = statusChangedEventHandler_0;
			StatusChangedEventHandler statusChangedEventHandler2;
			do
			{
				statusChangedEventHandler2 = statusChangedEventHandler;
				StatusChangedEventHandler value2 = (StatusChangedEventHandler)Delegate.Remove(statusChangedEventHandler2, value);
				statusChangedEventHandler = Interlocked.CompareExchange(ref statusChangedEventHandler_0, value2, statusChangedEventHandler2);
			}
			while ((object)statusChangedEventHandler != statusChangedEventHandler2);
		}
	}

	protected PlatformComponent()
	{
	}

	private ComponentProtection method_0(GlobalVariables.ArmorRating armorRating_0, ProtectionType protectionType_0, GlobalVariables.ArmorRating armorRating_1 = GlobalVariables.ArmorRating.None)
	{
		ComponentProtection result = default(ComponentProtection);
		result.ArmorRating = armorRating_0;
		result.ProtectionType = ((armorRating_0 != GlobalVariables.ArmorRating.None) ? protectionType_0 : ProtectionType.Unarmored);
		result.InsideArmoredStructure = armorRating_1 != GlobalVariables.ArmorRating.None;
		return result;
	}

	public bool GetCoverageArc(float AngleOfInterest, ref float startAngle, ref float endAngle)
	{
		int num;
		if (Coverage == null)
		{
			Coverage = new _Coverage();
			num = -1;
		}
		else
		{
			num = -1;
		}
		int num2 = num;
		int num3 = -1;
		startAngle = 0f;
		endAngle = 0f;
		if (!Coverage.Has360Coverage.Value)
		{
			int num4 = (int)Conversion.Int(AngleOfInterest / 22.5f);
			if (AngleOfInterest % 22.5f == 0f && !Coverage.GetCoverageByIndex(num4))
			{
				num4 = Coverage.GetNextCoverageIndex(num4, clockwise: false);
			}
			if (Coverage.GetCoverageByIndex(num4))
			{
				bool flag = true;
				int num5 = num4;
				num2 = num5;
				while (flag)
				{
					if (flag)
					{
						num5 = Coverage.GetNextCoverageIndex(num5, clockwise: false);
						flag = Coverage.GetCoverageByIndex(num5);
					}
				}
				num2 = num5 + 1;
				flag = true;
				num5 = num4;
				num3 = num4;
				while (flag)
				{
					if (flag)
					{
						num5 = Coverage.GetNextCoverageIndex(num5, clockwise: true);
						flag = Coverage.GetCoverageByIndex(num5);
					}
				}
				num3 = num5;
				startAngle = (float)num2 * 22.5f;
				if (startAngle >= 180f)
				{
					startAngle -= 360f;
				}
				endAngle = (float)num3 * 22.5f;
				int result;
				if (startAngle < 0f && endAngle >= 180f)
				{
					endAngle -= 360f;
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			return false;
		}
		startAngle = 0f;
		endAngle = 360f;
		return true;
	}

	public static PooledList<RangeSymbol> RangeWedges_GetArcs(Geopoint_Struct thePoint, PlatformComponent theComponent, float theRange)
	{
		PooledList<RangeSymbol> pooledList = new PooledList<RangeSymbol>(Pools<RangeSymbol>.Local);
		bool flag = false;
		Color theColor = default(Color);
		_Coverage coverage = theComponent.Coverage;
		try
		{
			RangeSymbol item = default(RangeSymbol);
			if (theComponent.IsSensor)
			{
				Sensor sensor = (Sensor)theComponent;
				if (sensor.HasTrackingFOVRestriction())
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, string.Empty, sensor.maxRange, (float)((double)(-sensor.FOVWidth_Tracking()) / 2.0), (float)((double)sensor.FOVWidth_Tracking() / 2.0), theColor);
					pooledList.Add(item);
					return pooledList;
				}
				if (sensor.SemiActiveWeaponsGuided.Count > 0)
				{
					coverage = sensor.Coverage_Illuminate;
				}
			}
			if (coverage.SB1)
			{
				flag = true;
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 0f, 22.5f, theColor);
			}
			if (coverage.SB2)
			{
				if (flag)
				{
					item.RightArc = 45f;
				}
				else
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 22.5f, 45f, theColor);
					flag = true;
				}
			}
			else if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			if (coverage.SMF1)
			{
				if (flag)
				{
					item.RightArc = 67.5f;
				}
				else
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 45f, 67.5f, theColor);
					flag = true;
				}
			}
			else if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			if (!coverage.SMF2)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (flag)
			{
				item.RightArc = 90f;
			}
			else
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 67.5f, 90f, theColor);
				flag = true;
			}
			if (!coverage.SMA1)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (flag)
			{
				item.RightArc = 112.5f;
			}
			else
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 90f, 112.5f, theColor);
				flag = true;
			}
			if (!coverage.SMA2)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (!flag)
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 112.5f, 135f, theColor);
				flag = true;
			}
			else
			{
				item.RightArc = 135f;
			}
			if (coverage.SS1)
			{
				if (flag)
				{
					item.RightArc = 157.5f;
				}
				else
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 135f, 157.5f, theColor);
					flag = true;
				}
			}
			else if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			if (!coverage.SS2)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (!flag)
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 157.5f, 180f, theColor);
				flag = true;
			}
			else
			{
				item.RightArc = 180f;
			}
			if (!coverage.PS1)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (!flag)
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 180f, 202.5f, theColor);
				flag = true;
			}
			else
			{
				item.RightArc = 202.5f;
			}
			if (coverage.PS2)
			{
				if (!flag)
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 202.5f, 225f, theColor);
					flag = true;
				}
				else
				{
					item.RightArc = 225f;
				}
			}
			else if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			if (coverage.PMA1)
			{
				if (flag)
				{
					item.RightArc = 247.5f;
				}
				else
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 225f, 247.5f, theColor);
					flag = true;
				}
			}
			else if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			if (!coverage.PMA2)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (flag)
			{
				item.RightArc = 270f;
			}
			else
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 247.5f, 270f, theColor);
				flag = true;
			}
			if (!coverage.PMF1)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (flag)
			{
				item.RightArc = 292.5f;
			}
			else
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 270f, 292.5f, theColor);
				flag = true;
			}
			if (!coverage.PMF2)
			{
				if (flag)
				{
					pooledList.Add(item);
					flag = false;
				}
			}
			else if (!flag)
			{
				item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 292.5f, 315f, theColor);
				flag = true;
			}
			else
			{
				item.RightArc = 315f;
			}
			if (coverage.PB1)
			{
				if (!flag)
				{
					item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 315f, 337.5f, theColor);
					flag = true;
				}
				else
				{
					item.RightArc = 337.5f;
				}
			}
			else if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			if (coverage.PB2)
			{
				if (!flag)
				{
					if (!coverage.SB1)
					{
						item = new RangeSymbol(RangeSymbol.SymbolType.Wedge, "", theRange, 337.5f, 0f, theColor);
						flag = true;
					}
					else
					{
						pooledList[0].LeftArc = 337.5f;
					}
				}
				else if (coverage.SB1)
				{
					if (pooledList.Count > 0)
					{
						pooledList[0].LeftArc = item.LeftArc;
						flag = false;
					}
					else
					{
						pooledList.Add(item);
						pooledList[0].RightArc = 360f;
						flag = false;
					}
				}
				else
				{
					item.RightArc = 0f;
				}
			}
			if (flag)
			{
				pooledList.Add(item);
				flag = false;
			}
			return pooledList;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public virtual bool TargetIsWithinCoverageArc(Module_Unit.Unit theTarget, float? CustomParentHeading = null)
	{
		bool result = default(bool);
		try
		{
			if (Coverage.Has360Coverage.Value)
			{
				result = true;
				return result;
			}
			ActiveUnit parentPlatform = ParentPlatform;
			if (parentPlatform == null)
			{
				result = false;
				return result;
			}
			if (theTarget == null)
			{
				result = false;
				return result;
			}
			double num = ((!CustomParentHeading.HasValue) ? ((double)parentPlatform.CurrentHeading) : ((double)CustomParentHeading.Value));
			double num2 = Math2.NormalizeBearing((double)Math2.CalcAzimuth(parentPlatform.get_Latitude(GlobalVariables.ObjectTrue), parentPlatform.get_Longitude(GlobalVariables.ObjectTrue), theTarget.get_Latitude(GlobalVariables.ObjectTrue), theTarget.get_Longitude(GlobalVariables.ObjectTrue)) - num);
			num = 0.0;
			double num3 = num2;
			if (num3 <= 22.5)
			{
				result = Coverage.SB1;
				return result;
			}
			if (num3 <= 45.0)
			{
				result = Coverage.SB2;
				return result;
			}
			if (num3 <= 67.5)
			{
				result = Coverage.SMF1;
				return result;
			}
			if (num3 <= 90.0)
			{
				result = Coverage.SMF2;
				return result;
			}
			if (num3 <= 112.5)
			{
				result = Coverage.SMA1;
				return result;
			}
			if (num3 <= 135.0)
			{
				result = Coverage.SMA2;
				return result;
			}
			if (num3 <= 157.5)
			{
				result = Coverage.SS1;
				return result;
			}
			if (num3 <= 180.0)
			{
				result = Coverage.SS2;
				return result;
			}
			if (num3 <= 202.5)
			{
				result = Coverage.PS1;
				return result;
			}
			if (num3 <= 225.0)
			{
				result = Coverage.PS2;
				return result;
			}
			if (num3 <= 247.5)
			{
				result = Coverage.PMA1;
				return result;
			}
			if (num3 <= 270.0)
			{
				result = Coverage.PMA2;
				return result;
			}
			if (num3 <= 292.5)
			{
				result = Coverage.PMF1;
				return result;
			}
			if (num3 <= 315.0)
			{
				result = Coverage.PMF2;
				return result;
			}
			if (num3 <= 337.5)
			{
				result = Coverage.PB1;
				return result;
			}
			result = Coverage.PB2;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100685", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public PlatformComponent(ActiveUnit theParent)
	{
		ParentPlatform = theParent;
	}

	public void RaiseEventStatusChanged()
	{
		statusChangedEventHandler_0?.Invoke(this);
	}

	public virtual void Destroy(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility, bool RegisterAsLosses = true)
	{
		try
		{
			_Status = _ComponentStatus.Destroyed;
			if (!Information.IsNothing((object)ParentPlatform) && ParentPlatform.IsFacility && !ParentPlatform.IsMorituri && ((Facility)ParentPlatform).HasAimpoints && !ScenEditAction && !Information.IsNothing((object)ParentPlatform.Mounts) && ParentPlatform.Mounts.Where([SpecialName] (Mount theM) => !Information.IsNothing((object)theM) && theM.Status == _ComponentStatus.Destroyed).Count() == ParentPlatform.Mounts.Count && !Information.IsNothing((object)ParentPlatform.ParentScen))
			{
				ParentPlatform.ParentScen.DestroyThisUnit(ParentPlatform, "all aimpoints of parent are gone! The entire facility is destroyed", "Weapon Interaction");
			}
			statusChangedEventHandler_0?.Invoke(this);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100686", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Repair()
	{
		_Status = _ComponentStatus.Operational;
		statusChangedEventHandler_0?.Invoke(this);
	}

	public virtual void Damage(_DamageSeverityFactor theDamageSeverity)
	{
		_Status = _ComponentStatus.Damaged;
		_DamageSeverityFactor_0 = theDamageSeverity;
		statusChangedEventHandler_0?.Invoke(this);
	}

	public void MakeOperational(bool GiveUserFeedback)
	{
		_Status = _ComponentStatus.Operational;
		if (GiveUserFeedback && (object)GetType() == typeof(AirFacility))
		{
			GameGeneral.SendMessageBoxToUI("A runway or pad's effective ability to host aircraft depends on its parent platform's integrity, i.e. the amount of damage sustained. Setting the component operational will not improve the aircraft capacity.", ParentPlatform.get_UnitSide(SetSideOnly: false));
		}
		statusChangedEventHandler_0?.Invoke(this);
	}

	public virtual void vmethod_0(float PulseStrengthRatio)
	{
	}

	public virtual void ResolveDamageFromDazzler(float PulseStrengthRatio)
	{
	}

	static PlatformComponent()
	{
		Class72.smethod_20();
	}
}
