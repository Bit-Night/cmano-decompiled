using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Cysharp.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class CommDevice : PlatformComponent
{
	public enum EnumCommLatency
	{
		None = 0,
		Slow = 1000,
		Norm = 2000,
		Fast = 3000,
		Instnt = 4000,
		BMD = 5000
	}

	public enum EnumCommQuality
	{
		None = 0,
		GLoc = 1000,
		TacP = 2000,
		AAW = 3000,
		BMD = 4000,
		FMV = 5000
	}

	public enum CommLinkType
	{
		NONE = 1001,
		Commercial_SATCOM = 2001,
		USN_FLTSATCOM = 2002,
		MILSTAR_SATCOM = 2003,
		DSCS_SATCOM = 2004,
		Skynet_SATCOM = 2005,
		Big_Ball_SATCOM = 2006,
		SSIXS_SATCOM = 2007,
		Syracuse_SATCOM = 2008,
		Punch_Bowl_SATCOM = 2009,
		SATCOM_Generic = 2010,
		Visual_Comm = 3001,
		Laser_Comm = 3002,
		Land_Line = 3003,
		Link4 = 4001,
		Link10 = 4002,
		Link11 = 4003,
		Link16 = 4004,
		Link14 = 4005,
		Link22 = 4007,
		CEC = 4011,
		LinkY = 4021,
		LinkT = 4022,
		AKT22_Datalink = 5001,
		PEAB_TDMA_Datalink = 5002,
		TERMA_Datalink = 5003,
		LAMPS_Datalink = 5004,
		APD15_Datalink = 5005,
		A346Z_Datalink = 5006,
		ELF_Link = 6001,
		Radio = 7001,
		HaveQuick_Radio = 7002,
		OneWay_WireGuidance = 8001,
		TwoWay_WireGuidance = 8002,
		NATO_SonobuoyLink = 9001,
		RGB_SonobuoyLink = 9002,
		BM_SonobuoyLink = 9003,
		Generic_SonobuoyLink = 9004,
		Type75_SonobuoyLink = 9005,
		AEGIS_WeaponLink = 10001,
		AWG9_WeaponLink = 10002,
		NTU_WeaponLink = 10003,
		NASAMS_WeaponLink = 10004,
		AGM142_WeaponLink = 10005,
		Patriot_WeaponLink = 10006,
		AGM154_WeaponLink = 10007,
		Rapier_WeaponLink = 10008,
		AIM120_WeaponLink = 10009,
		Roland_WeaponLink = 10010,
		AAW9_13_WeaponLink = 10011,
		SA12_WeaponLink = 10012,
		AJ168_WeaponLink = 10013,
		SA5_WeaponLink = 10014,
		AS12_WeaponWire = 10015,
		SA10_WeaponLink = 10016,
		AS15TT_WeaponLink = 10017,
		HUMRAAM_WeaponLink = 10018,
		AS30_WeaponLink = 10019,
		HOT_WeaponLink = 10020,
		APK8_9_WeaponLink = 10021,
		IKARA_WeaponLink = 10022,
		AS7_WeaponLink = 10023,
		MICA_WeaponLink = 10024,
		Aster_WeaponLink = 10025,
		Otomat_WeaponLink = 10026,
		GBU15_WeaponLink = 10027,
		RBS15_WeaponLink = 10028,
		ABM_WeaponLink = 10029,
		ADATS_WeaponLink = 10030,
		Arrow_WeaponLink = 10031,
		AT2_3_6_12_16_WeaponLink = 10032,
		Bamse_WeaponLink = 10033,
		Barak_WeaponLink = 10034,
		Blowpipe_WeaponLink = 10035,
		Bullpup_WeaponLink = 10036,
		C701_WeaponLink = 10037,
		CADSN1_WeaponLink = 10038,
		ASM_SSM_WeaponLink = 10039,
		Crotale_WeaponLink = 10040,
		EFOGM_WeaponLink = 10041,
		Gabriel_WeaponLink = 10042,
		MarteMk2_WeaponLink = 10043,
		Javelin_WeaponLink = 10044,
		SAM1_WeaponLink = 10045,
		SAM4_WeaponLink = 10046,
		SeaCat_WeaponLink = 10047,
		SeaSkua_WeaponLink = 10048,
		SeaWolf_WeaponLink = 10049,
		SkyBow_WeaponLink = 10050,
		Starstreak_WeaponLink = 10051,
		THAAD_WeaponLink = 10052,
		TOW_WeaponLink = 10053,
		AA10_12_WeaponLink = 10054,
		AA9_13_WeaponLink = 10055,
		AA5_WeaponLink = 10056,
		AA7_WeaponLink = 10057,
		AAM4_WeaponLink = 10058,
		SkySwordII_WeaponLink = 10059,
		RBS70_90_WeaponLink = 10060,
		Derby_WeaponLink = 10061,
		TacTom_Weapon_Link = 10062,
		SA_17_SAN_12_Weapon_Link = 10063,
		Hakim_Weapon_Link = 10064,
		Sea_Dart_ADIMP_Link = 10065,
		PL_15_Weapon_Link = 10066,
		DART_DAVIDE_Link = 10067,
		Stunner_Weapon_Link = 10068,
		MHTK_Weapon_Link = 10069,
		SPICE_Weapon_Link = 10070,
		AARGM_Weapon_Link = 10071,
		R_27R_Weapon_Link = 10072,
		Blackwing_UAV_WeaponLink = 10073,
		Qaem_Weapon_Link = 10074,
		Swingfire_WeaponLink = 10075,
		HISAR_WeaponLink = 10076,
		SSM2_WeaponLink = 10077,
		Nag_WeaponLink = 10078,
		FIM_92K_Weapon_Link = 10079,
		Chungum_Weapon_Link = 10080,
		AD_200_Weapon_Link = 10081,
		TSCE_Weapon_Link = 10082,
		Atmaca_Weapon_Link = 10083,
		IRIS_T_SL_Weapon_Link = 10084,
		Astra_Weapon_Link = 10085,
		Shahed_136_Weapon_Link = 10086,
		Gungnir_Weapon_Link = 10087
	}

	public struct _Flags
	{
		public bool Broadcast;

		public bool Secure;

		public bool _Receive_Only;

		public bool _Send_Only;

		public bool LOS_Limited;

		public bool ELF_Radio;

		public bool SLF_Radio;

		public bool VLF_Radio;

		public bool ULF_Radio;

		public bool LF_Radio;

		public bool MF_Radio;

		public bool HF_Radio;

		public bool VHF_Radio;

		public bool UHF_Radio;

		public bool SHF_Radio;

		public bool EHF_Radio;

		public bool DaisyChain;

		public bool LPI;

		public bool Phased_Array_Antenna;

		public bool Jam_Resistant;

		public bool BLOS_LEO;

		public bool BLOS_MEO;

		public bool DegradesWithRange;

		public bool Acoustic_0_1kHz;

		public bool Acoustic_1_10kHz;

		public bool Acoustic_10_100kHz;
	}

	public class QualityGradeDetail
	{
		public int ID;

		public string Description;

		public string Capability;

		public string Example;

		public QualityGradeDetail(int _ID, string _description, string _capability, string _example)
		{
			ID = _ID;
			Description = _description;
			Capability = _capability;
			Example = _example;
		}

		public QualityGradeDetail()
		{
			ID = 0;
			Description = "";
			Capability = "";
			Example = "";
		}

		public string GetDescriptionASSlide()
		{
			int iD = ID;
			if (iD <= 1000)
			{
				return "B:1";
			}
			if (iD <= 2000)
			{
				return "B:2";
			}
			if (iD > 3000)
			{
				if (iD > 4000)
				{
					if (iD > 5000)
					{
						return ID.ToString();
					}
					return "B:5";
				}
				return "B:4";
			}
			return "B:3";
		}

		public static string GetDescriptionASSlide(int theID)
		{
			int num = theID;
			if (num <= 1000)
			{
				return "B:1";
			}
			if (num > 2000)
			{
				if (num > 3000)
				{
					if (num <= 4000)
					{
						return "B:4";
					}
					if (num <= 5000)
					{
						return "B:5";
					}
					return theID.ToString();
				}
				return "B:3";
			}
			return "B:2";
		}

		static QualityGradeDetail()
		{
			Class72.smethod_20();
		}
	}

	public class LatencyGradeDetail
	{
		public int ID;

		public string Description;

		public string Capability;

		public string Example;

		public LatencyGradeDetail(int _ID, string _description, string _capability, string _example)
		{
			ID = _ID;
			Description = _description;
			Capability = _capability;
			Example = _example;
		}

		public LatencyGradeDetail()
		{
			ID = 0;
			Description = "";
			Capability = "";
			Example = "";
		}

		public string GetDescriptionASSlide()
		{
			int iD = ID;
			if (iD <= 1000)
			{
				return "L:1";
			}
			if (iD <= 2000)
			{
				return "L:2";
			}
			if (iD > 3000)
			{
				if (iD > 4000)
				{
					if (iD > 5000)
					{
						return ID.ToString();
					}
					return "L:5";
				}
				return "L:4";
			}
			return "L:3";
		}

		public static string GetDescriptionASSlide(int theID)
		{
			int num = theID;
			if (num <= 1000)
			{
				return "L:1";
			}
			if (num <= 2000)
			{
				return "L:2";
			}
			if (num > 3000)
			{
				if (num <= 4000)
				{
					return "L:4";
				}
				if (num > 5000)
				{
					return theID.ToString();
				}
				return "L:5";
			}
			return "L:3";
		}

		static LatencyGradeDetail()
		{
			Class72.smethod_20();
		}
	}

	public CommLinkType Type;

	public float Range;

	public int MaxChannels;

	public _Flags Flags;

	private int int_1;

	public bool IsOptional;

	public bool ParentSpecific;

	public bool Hypothetical;

	public HashSet<Sensor.FrequencyBand> UsedFrequencies;

	private bool bool_0;

	public bool IsCommsInMount;

	public EnumCommQuality QualityGrade;

	public EnumCommLatency LatencyGrade;

	public DateTime? LastTransmissionTime;

	[CompilerGenerated]
	private QualityGradeDetail qualityGradeDetail_0;

	[CompilerGenerated]
	private LatencyGradeDetail latencyGradeDetail_0;

	public bool IsJammed
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public int OccupiedChannels
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool IsSonobuoyLink
	{
		get
		{
			CommLinkType type = Type;
			if ((uint)(type - 9001) <= 4u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsDaisyChainCapable => Flags.DaisyChain;

	internal QualityGradeDetail QualityGradeinfo
	{
		[CompilerGenerated]
		get
		{
			return qualityGradeDetail_0;
		}
		[CompilerGenerated]
		set
		{
			qualityGradeDetail_0 = value;
		}
	}

	internal LatencyGradeDetail LatencyGradenfo
	{
		[CompilerGenerated]
		get
		{
			return latencyGradeDetail_0;
		}
		[CompilerGenerated]
		set
		{
			latencyGradeDetail_0 = value;
		}
	}

	public bool IsValidWeaponDataLinkParentSpecificCheck(ActiveUnit ParentUnit, ActiveUnit OtherUnit)
	{
		int result;
		if (!ParentSpecific)
		{
			result = 1;
		}
		else if (!ParentUnit.IsWeapon)
		{
			result = 1;
		}
		else if (OtherUnit.IsWeapon)
		{
			result = 1;
		}
		else
		{
			Weapon weapon = (Weapon)ParentUnit;
			if (weapon.FiringParent == null)
			{
				result = 1;
			}
			else
			{
				if (weapon.FiringParent != OtherUnit)
				{
					return false;
				}
				result = 1;
			}
		}
		return (byte)result != 0;
	}

	public string ToXML(ref HashSet<string> ObjectsAlreadySerialized)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		string result = default(string);
		try
		{
			utf16ValueStringBuilder.Append("<CD>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</CD>");
					result = utf16ValueStringBuilder.ToString();
					return result;
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			if (DBID == 0 && !string.IsNullOrEmpty(Name))
			{
				string name = Name;
				SQLiteConnection theConn = ParentPlatform.ParentScen.DBConnection;
				DBID = DBFunctions.GetCommDeviceID(name, ref theConn);
			}
			if (_Status != _ComponentStatus.Operational)
			{
				utf16ValueStringBuilder.Append("<St>");
				byte status = (byte)_Status;
				utf16ValueStringBuilder.Append(status.ToString());
				utf16ValueStringBuilder.Append("</St>");
			}
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(DBID.ToString());
			utf16ValueStringBuilder.Append("</DBID>");
			utf16ValueStringBuilder.Append("<OC>");
			utf16ValueStringBuilder.Append(int_1.ToString());
			utf16ValueStringBuilder.Append("</OC>");
			utf16ValueStringBuilder.Append("<PS>");
			utf16ValueStringBuilder.Append(ParentSpecific.ToString());
			utf16ValueStringBuilder.Append("</PS>");
			if (IsJammed)
			{
				utf16ValueStringBuilder.Append("<IJ>True</IJ>");
			}
			if (base.DamageSeverity != _DamageSeverityFactor.Light)
			{
				utf16ValueStringBuilder.Append("<DamageSeverity>");
				utf16ValueStringBuilder.Append(((byte)base.DamageSeverity).ToString());
				utf16ValueStringBuilder.Append("</DamageSeverity>");
			}
			utf16ValueStringBuilder.Append("<QualityGrade>");
			utf16ValueStringBuilder.Append(QualityGrade.ToString());
			utf16ValueStringBuilder.Append("</QualityGrade>");
			if (LastTransmissionTime.HasValue)
			{
				utf16ValueStringBuilder.Append("<LastTransmission>");
				utf16ValueStringBuilder.Append(LastTransmissionTime.Value.ToBinary().ToString());
				utf16ValueStringBuilder.Append("</LastTransmission>");
			}
			utf16ValueStringBuilder.Append("</CD>");
			string text = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100662", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private CommDevice()
	{
		Flags = default(_Flags);
		ParentSpecific = true;
		UsedFrequencies = new HashSet<Sensor.FrequencyBand>();
		IsCommsInMount = false;
		QualityGrade = EnumCommQuality.None;
		LatencyGrade = EnumCommLatency.None;
		LastTransmissionTime = null;
	}

	public static CommDevice FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit theParentPlatform)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CommDevice commDevice = new CommDevice();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				if (Operators.CompareString(val.Name, "DBID", false) == 0)
				{
					commDevice.DBID = Conversions.ToInteger(val.InnerText);
					if (commDevice.DBID > 0)
					{
						commDevice = DBFunctions.GetCommDevice(Conversions.ToInteger(val.InnerText), ref theParentPlatform);
					}
				}
			}
			foreach (XmlNode childNode2 in theNode.ChildNodes)
			{
				XmlNode val2 = childNode2;
				if (Operators.CompareString(val2.Name, "ID", false) == 0)
				{
					commDevice.ObjectID_Set(val2.InnerText);
				}
			}
			if (commDevice.DBID <= 0)
			{
				IEnumerator enumerator4 = default(IEnumerator);
				foreach (XmlNode childNode3 in theNode.ChildNodes)
				{
					XmlNode val3 = childNode3;
					switch (val3.Name)
					{
					case "LastTransmission":
						commDevice.LastTransmissionTime = DateTime.FromBinary(Conversions.ToLong(val3.InnerText));
						break;
					case "Name":
						commDevice.Name = val3.InnerText;
						break;
					case "Status":
					case "St":
						switch (val3.InnerText)
						{
						case "Operational":
							commDevice._Status = _ComponentStatus.Operational;
							break;
						case "Damaged":
							commDevice._Status = _ComponentStatus.Damaged;
							break;
						case "Destroyed":
							commDevice._Status = _ComponentStatus.Destroyed;
							break;
						default:
							commDevice._Status = (_ComponentStatus)Conversions.ToByte(val3.InnerText);
							break;
						}
						break;
					case "Flags":
						{
							enumerator4 = val3.ChildNodes.GetEnumerator();
							try
							{
								while (enumerator4.MoveNext())
								{
									switch (((XmlNode)enumerator4.Current).Name)
									{
									case "LF_Radio":
										commDevice.Flags.LF_Radio = true;
										break;
									case "Receive_Only":
										commDevice.Flags._Receive_Only = true;
										break;
									case "LOS_Limited":
										commDevice.Flags.LOS_Limited = true;
										break;
									case "Broadcast":
										commDevice.Flags.Broadcast = true;
										break;
									case "UHF_Radio":
										commDevice.Flags.UHF_Radio = true;
										break;
									case "VLF_Radio":
										commDevice.Flags.VLF_Radio = true;
										break;
									case "SHF_Radio":
										commDevice.Flags.SHF_Radio = true;
										break;
									case "HF_Radio":
										commDevice.Flags.HF_Radio = true;
										break;
									case "ELF_Radio":
										commDevice.Flags.ELF_Radio = true;
										break;
									case "Send_Only":
										commDevice.Flags._Send_Only = true;
										break;
									case "Secure":
										commDevice.Flags.Secure = true;
										break;
									case "VHF_Radio":
										commDevice.Flags.VHF_Radio = true;
										break;
									case "MF_Radio":
										commDevice.Flags.MF_Radio = true;
										break;
									}
								}
							}
							finally
							{
								IDisposable disposable = enumerator4 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
							}
						}
						break;
					case "DamageSeverity":
						commDevice.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val3.InnerText);
						break;
					case "ID":
						if (theDictionary == null)
						{
							commDevice.ObjectID_Set(val3.InnerText);
							break;
						}
						if (!theDictionary.ContainsKey(val3.InnerText))
						{
							commDevice.ObjectID_Set(val3.InnerText);
							theDictionary.TryAdd(commDevice.ObjectID, commDevice);
							break;
						}
						return (CommDevice)theDictionary[val3.InnerText];
					case "IsOptional":
						commDevice.IsOptional = Misc.ParseBool(val3.InnerText);
						break;
					case "IJ":
						commDevice.IsJammed = Misc.ParseBool(val3.InnerText);
						break;
					case "MaxChannels":
						commDevice.MaxChannels = Conversions.ToInteger(val3.InnerText);
						break;
					case "Range":
						commDevice.Range = XmlConvert.ToSingle(val3.InnerText);
						break;
					case "Type":
						if (!Versioned.IsNumeric((object)val3.InnerText))
						{
							CommLinkType type = (CommLinkType)Enum.Parse(typeof(CommLinkType), val3.InnerText, ignoreCase: true);
							commDevice.Type = type;
						}
						else
						{
							commDevice.Type = (CommLinkType)Conversions.ToInteger(val3.InnerText);
						}
						break;
					case "OC":
					case "OccupiedChannels":
						commDevice.int_1 = Conversions.ToInteger(val3.InnerText);
						break;
					}
				}
			}
			else
			{
				foreach (XmlNode childNode4 in theNode.ChildNodes)
				{
					XmlNode val4 = childNode4;
					switch (val4.Name)
					{
					case "PS":
						commDevice.ParentSpecific = Misc.ParseBool(val4.InnerText);
						break;
					case "St":
					case "Status":
						switch (val4.InnerText)
						{
						case "Damaged":
							commDevice._Status = _ComponentStatus.Damaged;
							break;
						case "Destroyed":
							commDevice._Status = _ComponentStatus.Destroyed;
							break;
						default:
							commDevice._Status = (_ComponentStatus)Conversions.ToByte(val4.InnerText);
							break;
						case "Operational":
							commDevice._Status = _ComponentStatus.Operational;
							break;
						}
						break;
					case "IJ":
						commDevice.IsJammed = Misc.ParseBool(val4.InnerText);
						break;
					case "DamageSeverity":
						commDevice.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val4.InnerText);
						break;
					case "OccupiedChannels":
					case "OC":
						commDevice.int_1 = Conversions.ToInteger(val4.InnerText);
						break;
					}
				}
			}
			return commDevice;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100663", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public bool IsReceiveOnly()
	{
		return Flags._Receive_Only;
	}

	public bool IsSendOnly()
	{
		if (IsSonobuoyLink)
		{
			return true;
		}
		return Flags._Receive_Only;
	}

	public static GlobalVariables.TechGenerationClass InferCommDeviceTechGeneration(CommDevice theDevice)
	{
		int num = 2001;
		switch (theDevice.QualityGrade)
		{
		case EnumCommQuality.TacP:
			num = Math.Max(num, 2004);
			break;
		case EnumCommQuality.FMV:
			num = Math.Max(num, 2010);
			break;
		case EnumCommQuality.BMD:
			num = Math.Max(num, 2011);
			break;
		case EnumCommQuality.AAW:
			num = Math.Max(num, 2009);
			break;
		}
		switch (theDevice.LatencyGrade)
		{
		case EnumCommLatency.BMD:
			num = Math.Max(num, 2010);
			break;
		case EnumCommLatency.Instnt:
			num = Math.Max(num, 2007);
			break;
		case EnumCommLatency.Fast:
			num = Math.Max(num, 2004);
			break;
		}
		if (theDevice.IsSatelliteLink())
		{
			num = Math.Max(num, 2004);
		}
		if (theDevice.Flags.Secure)
		{
			num = Math.Max(num, 2004);
		}
		if (theDevice.Flags.Jam_Resistant)
		{
			num = Math.Max(num, 2005);
		}
		if (theDevice.Flags.LPI)
		{
			num = Math.Max(num, 2006);
		}
		if (theDevice.Flags.Phased_Array_Antenna)
		{
			num = Math.Max(num, 2007);
		}
		if (theDevice.LatencyGrade >= EnumCommLatency.Instnt && theDevice.QualityGrade >= EnumCommQuality.TacP)
		{
			num = Math.Max(num, 2007);
		}
		if (theDevice.Flags.LPI && theDevice.Flags.Phased_Array_Antenna && theDevice.Flags.Jam_Resistant)
		{
			num = Math.Max(num, 2008);
		}
		if (theDevice.IsSatelliteLink() && theDevice.Flags.Phased_Array_Antenna)
		{
			num = Math.Max(num, 2009);
		}
		if (theDevice.QualityGrade >= EnumCommQuality.AAW && theDevice.LatencyGrade >= EnumCommLatency.Instnt)
		{
			num = Math.Max(num, 2009);
		}
		if ((theDevice.QualityGrade == EnumCommQuality.BMD || theDevice.LatencyGrade == EnumCommLatency.BMD) && theDevice.IsSatelliteLink())
		{
			num = Math.Max(num, 2011);
		}
		int val;
		int val2;
		if (!theDevice.IsSatelliteLink())
		{
			val = 2001;
			val2 = 2016;
		}
		else
		{
			if (!theDevice.Flags.Phased_Array_Antenna)
			{
				goto IL_02c4;
			}
			if (!theDevice.Flags.LPI)
			{
				val = 2001;
				val2 = 2016;
			}
			else if (!theDevice.Flags.Jam_Resistant)
			{
				val = 2001;
				val2 = 2016;
			}
			else if (!theDevice.Flags.Secure)
			{
				val = 2001;
				val2 = 2016;
			}
			else
			{
				if (theDevice.LatencyGrade < EnumCommLatency.Instnt || theDevice.QualityGrade < EnumCommQuality.AAW)
				{
					goto IL_02c4;
				}
				num = Math.Max(num, 2011);
				val = 2001;
				val2 = 2016;
			}
		}
		goto IL_02ce;
		IL_02ce:
		return (GlobalVariables.TechGenerationClass)Math.Max(val, Math.Min(val2, num));
		IL_02c4:
		val = 2001;
		val2 = 2016;
		goto IL_02ce;
	}

	public CommDevice(ActiveUnit theParent)
		: base(theParent)
	{
		Flags = default(_Flags);
		ParentSpecific = true;
		UsedFrequencies = new HashSet<Sensor.FrequencyBand>();
		IsCommsInMount = false;
		QualityGrade = EnumCommQuality.None;
		LatencyGrade = EnumCommLatency.None;
		LastTransmissionTime = null;
	}

	public CommDevice(ActiveUnit theParent, Scenario theScen, int int_2, string theName, CommLinkType theType, float theRange, int theMaxChannels, EnumCommQuality theQualityGrade, EnumCommLatency theLatencyGrade, bool DeviceIsOptional = false)
		: base(theParent)
	{
		Flags = default(_Flags);
		ParentSpecific = true;
		UsedFrequencies = new HashSet<Sensor.FrequencyBand>();
		IsCommsInMount = false;
		QualityGrade = EnumCommQuality.None;
		LatencyGrade = EnumCommLatency.None;
		LastTransmissionTime = null;
		DBID = int_2;
		Name = theName;
		Type = theType;
		Range = theRange;
		MaxChannels = theMaxChannels;
		IsOptional = DeviceIsOptional;
		QualityGrade = theQualityGrade;
		LatencyGrade = theLatencyGrade;
		CommDevice theCD = this;
		DBFunctions.GetCommBandwith(ref theCD, theScen.DBConnection);
		theCD = this;
		DBFunctions.GetCommLatency(ref theCD, theScen.DBConnection);
		theCD = this;
		DBFunctions.GetCommDeviceFlags(ref theCD, theScen.DBConnection);
	}

	internal bool IsWeaponDataLink()
	{
		if (ParentPlatform != null)
		{
			if (DBOps.DBIsRegistered(ParentPlatform.ParentScen.DBUsed))
			{
				int type = (int)Type;
				int result;
				if (type != 16 && type != 5006 && type != 8002 && type != 9001)
				{
					if (type != 9002)
					{
						if (type == 10118)
						{
							return false;
						}
						if (type > 10000)
						{
							return true;
						}
						return ParentPlatform != null && ParentPlatform.IsWeapon && IsSendOnly();
					}
					result = 1;
				}
				else
				{
					result = 1;
				}
				return (byte)result != 0;
			}
			int type2 = (int)Type;
			int result2;
			if (type2 != 16 && type2 != 4011 && type2 != 5006 && type2 != 8002 && type2 != 9001)
			{
				if (type2 != 9002)
				{
					if (type2 == 10118)
					{
						return false;
					}
					if (type2 > 10000)
					{
						return true;
					}
					goto IL_00e5;
				}
				result2 = 1;
			}
			else
			{
				result2 = 1;
			}
			return (byte)result2 != 0;
		}
		goto IL_00e5;
		IL_00e5:
		bool result3 = default(bool);
		return result3;
	}

	public bool IsWireLink()
	{
		int result;
		switch (Type)
		{
		case CommLinkType.AS12_WeaponWire:
			result = 1;
			break;
		default:
			return false;
		case CommLinkType.OneWay_WireGuidance:
		case CommLinkType.TwoWay_WireGuidance:
			result = 1;
			break;
		}
		return (byte)result != 0;
	}

	internal bool IsSatelliteLink()
	{
		CommLinkType type = Type;
		if ((uint)(type - 2001) <= 9u)
		{
			return true;
		}
		return false;
	}

	public override void vmethod_0(float PulseStrengthRatio)
	{
		if (base.Status == _ComponentStatus.Destroyed)
		{
			return;
		}
		float num = ((PulseStrengthRatio < 0.1f) ? 0.05f : ((PulseStrengthRatio < 0.25f) ? 0.15f : ((PulseStrengthRatio < 0.5f) ? 0.3f : ((!(PulseStrengthRatio < 0.75f)) ? 0.75f : 0.5f))));
		if (base.Status != _ComponentStatus.Operational)
		{
			num /= 2f;
		}
		if ((double)num < 0.05)
		{
			num = 0.05f;
		}
		if ((double)num > 0.95)
		{
			num = 0.95f;
		}
		float num2 = num;
		float num3 = (float)((double)num - 0.1);
		float num4 = (float)((double)num - 0.2);
		float num5 = (float)((double)num - 0.3);
		double num6 = GameGeneral.GlobalRNG.NextDouble();
		if (num6 < (double)num5)
		{
			Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a comm/datalink", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
		}
		else if (num6 < (double)num4)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered heavy damage.", ParentPlatform.Name + " had a comm/datalink damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Heavy);
		}
		else if (num6 < (double)num3)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered moderate damage.", ParentPlatform.Name + " had a comm/datalink damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Medium);
		}
		else if (num6 < (double)num2)
		{
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has suffered light damage.", ParentPlatform.Name + " had a comm/datalink damaged", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			Damage(_DamageSeverityFactor.Light);
		}
	}

	internal Contact ApplyCOMMDeviceModifiersToContact(Contact theContact)
	{
		if (theContact == null)
		{
			return null;
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		if (ParentPlatform.CommStuff.ContactsInfoGrade.ContainsKey(theContact.ObjectID))
		{
			ActiveUnit_CommStuff.TransmissionContactData transmissionContactData = ParentPlatform.CommStuff.ContactsInfoGrade[theContact.ObjectID];
			if ((transmissionContactData.Bandwith == EnumCommQuality.None) | (transmissionContactData.Bandwith > QualityGrade))
			{
				switch (QualityGrade)
				{
				case EnumCommQuality.GLoc:
					theContact.HeadingIsKnown = false;
					theContact.SpeedIsKnown = false;
					theContact.AltitudeIsKnown = false;
					break;
				}
				transmissionContactData.Bandwith = QualityGrade;
			}
			if ((transmissionContactData.Latency == EnumCommLatency.None) | (transmissionContactData.Latency > LatencyGrade))
			{
				transmissionContactData.Latency = LatencyGrade;
			}
		}
		return theContact;
	}

	internal double GetLatencyGradeinSeconds()
	{
		return LatencyGrade switch
		{
			EnumCommLatency.Norm => 3.0, 
			EnumCommLatency.Slow => 5.0, 
			EnumCommLatency.BMD => 0.0, 
			EnumCommLatency.Instnt => 1.0, 
			EnumCommLatency.Fast => 2.0, 
			_ => 0.0, 
		};
	}

	internal static double GetLatencyInSeconds(int thePassedLatencyGrade)
	{
		return thePassedLatencyGrade switch
		{
			2000 => 3.0, 
			1000 => 5.0, 
			5000 => 0.0, 
			4000 => 1.0, 
			3000 => 2.0, 
			_ => 0.0, 
		};
	}

	internal Contact ApplyStructuralDegradation(Contact theContact)
	{
		Contact contact = default(Contact);
		return base.Status switch
		{
			_ComponentStatus.Operational => theContact, 
			_ComponentStatus.Damaged => theContact, 
			_ComponentStatus.Destroyed => new Contact(), 
			_ => contact, 
		};
	}

	public Contact WeatherDegradation(ActiveUnit theUnit, Contact theContact)
	{
		Weather.WeatherProfile weatherAtMyLocation = theUnit.WeatherAtMyLocation;
		float rainfallRate = weatherAtMyLocation.RainfallRate;
		if (rainfallRate > 40f || rainfallRate > 30f || rainfallRate > 20f || !(rainfallRate <= 10f))
		{
		}
		float fractionUnderRain = weatherAtMyLocation.FractionUnderRain;
		if (fractionUnderRain > 0.9f || fractionUnderRain > 0.8f || fractionUnderRain > 0.7f || fractionUnderRain > 0.6f || fractionUnderRain > 0.5f || fractionUnderRain > 0.4f || fractionUnderRain > 0.3f || fractionUnderRain > 0.2f || !(fractionUnderRain <= 0.1f))
		{
		}
		return theContact;
	}

	internal Contact CrewProficencyDegradation(Contact theContact)
	{
		GlobalVariables.ProficiencyLevel? proficiency = ParentPlatform.Proficiency;
		int? num = (int?)proficiency;
		if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 4)) != true)
		{
			num = (int?)proficiency;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) != true)
			{
				num = (int?)proficiency;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) != true)
				{
					num = (int?)proficiency;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) != true)
					{
						num = (int?)proficiency;
						_ = ((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) == true;
					}
				}
			}
		}
		return theContact;
	}

	internal Contact ApplyJammingDegradation(Contact theContact)
	{
		return theContact;
	}

	internal Contact DistanceDegradation(ActiveUnit first, ActiveUnit myUnit, Contact theContact)
	{
		return theContact;
	}

	internal Color GetQualityColor()
	{
		int iD = QualityGradeinfo.ID;
		int iD2 = QualityGradeinfo.ID;
		int num = iD + iD2;
		if (num < 10000)
		{
			if (num < 8000)
			{
				if (num >= 6000)
				{
					return Color.Yellow;
				}
				if (num < 4000)
				{
					if (num < 2000)
					{
						return Color.Transparent;
					}
					return Color.Red;
				}
				return Color.Orange;
			}
			return Color.YellowGreen;
		}
		return Color.LimeGreen;
	}

	static CommDevice()
	{
		Class72.smethod_20();
	}
}
