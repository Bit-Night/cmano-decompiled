using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Collections.Pooled;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public class EventExporter_Tacview2x : IEventExporter
{
	public enum _TypeOfNewObjectToDeclare
	{
		None,
		ActiveUnit,
		UnguidedWeapon,
		Contact,
		WeaponImpact,
		Explosion
	}

	[CompilerGenerated]
	internal sealed class _Closure$__110-0
	{
		public IEventExporter.EventExportNotification $VB$Local_theNotification;

		public string $VB$Local_UnitObjectID;

		public _Closure$__110-0(_Closure$__110-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNotification = arg0.$VB$Local_theNotification;
				$VB$Local_UnitObjectID = arg0.$VB$Local_UnitObjectID;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Side theSide)
		{
			return Operators.CompareString(theSide.Name, $VB$Local_theNotification.EventParameters["ObserverSide"].Value.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(Explosion theE)
		{
			return Operators.CompareString(theE.ObjectID, $VB$Local_UnitObjectID, false) == 0;
		}

		static _Closure$__110-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__112-0
	{
		public IEventExporter.EventExportNotification $VB$Local_theNotification;

		public _Closure$__112-0(_Closure$__112-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theNotification = arg0.$VB$Local_theNotification;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(Side theSide)
		{
			return Operators.CompareString(theSide.Name, $VB$Local_theNotification.EventParameters["ObserverSide"].Value.ToString(), false) == 0;
		}

		[SpecialName]
		internal bool _Lambda$__1(Side theSide)
		{
			return Operators.CompareString(theSide.Name, $VB$Local_theNotification.EventParameters["UnitSide"].Value.ToString(), false) == 0;
		}

		static _Closure$__112-0()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	private IEventExporter.EventExporterRunMode eventExporterRunMode_0;

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4;

	[CompilerGenerated]
	private bool bool_5;

	[CompilerGenerated]
	private bool bool_6;

	[CompilerGenerated]
	private bool bool_7;

	[CompilerGenerated]
	private bool bool_8;

	[CompilerGenerated]
	private bool bool_9;

	[CompilerGenerated]
	private bool bool_10;

	[CompilerGenerated]
	private bool bool_11;

	[CompilerGenerated]
	private bool bool_12;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private bool bool_13;

	[CompilerGenerated]
	private EventExporter_Common KdByyLemGpS;

	private string string_1;

	private bool bool_14;

	private ConcurrentQueue<IEventExporter.EventExportNotification> concurrentQueue_0;

	private ConcurrentDictionary<string, Dictionary<string, long>> concurrentDictionary_0;

	private Dictionary<string, StreamWriter> dictionary_0;

	private Thread thread_0;

	protected string LastPrintedTimeString;

	protected static long UnitIDIncrement;

	private static Dictionary<long, (string, string, string, string)> dictionary_1;

	private EventWaitHandle eventWaitHandle_0;

	private static Dictionary<string, DataTable> dictionary_2;

	private static bool bool_15;

	private static Dictionary<string, DataTable> dictionary_3;

	private static bool bool_16;

	private static ConcurrentDictionary<long, Contact_Base.IdentificationStatus> concurrentDictionary_1;

	private bool bool_17;

	public readonly Dictionary<string, string> NewUnitCache;

	private static readonly LockObject lockObject_0;

	private bool lppyypDtuFy;

	public IEventExporter.EventExporterRunMode RunMode
	{
		[CompilerGenerated]
		get
		{
			return eventExporterRunMode_0;
		}
		[CompilerGenerated]
		set
		{
			eventExporterRunMode_0 = value;
		}
	}

	public bool ExportEngagementCycle
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool ExportSensorDetectionFailure
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public bool ExportSensorDetectionSuccess
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool ExportUnitPositions
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool ExportWeaponEndgame
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool ExportWeaponFired
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public bool ExportUnitDestroyed
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public bool ExportFuelConsumed
	{
		[CompilerGenerated]
		get
		{
			return bool_7;
		}
		[CompilerGenerated]
		set
		{
			bool_7 = value;
		}
	}

	public bool ExportFuelTransfer
	{
		[CompilerGenerated]
		get
		{
			return bool_8;
		}
		[CompilerGenerated]
		set
		{
			bool_8 = value;
		}
	}

	public bool ExportCargoTransfer
	{
		[CompilerGenerated]
		get
		{
			return bool_9;
		}
		[CompilerGenerated]
		set
		{
			bool_9 = value;
		}
	}

	public bool ExportAirOps
	{
		[CompilerGenerated]
		get
		{
			return bool_10;
		}
		[CompilerGenerated]
		set
		{
			bool_10 = value;
		}
	}

	public bool ExportDockingOps
	{
		[CompilerGenerated]
		get
		{
			return bool_11;
		}
		[CompilerGenerated]
		set
		{
			bool_11 = value;
		}
	}

	public bool UseZeroHour
	{
		[CompilerGenerated]
		get
		{
			return bool_12;
		}
		[CompilerGenerated]
		set
		{
			bool_12 = value;
		}
	}

	public string FileExportFolder
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

	public bool ExportUnitDamaged
	{
		[CompilerGenerated]
		get
		{
			return bool_13;
		}
		[CompilerGenerated]
		set
		{
			bool_13 = value;
		}
	}

	public EventExporter_Common Common
	{
		[CompilerGenerated]
		get
		{
			return KdByyLemGpS;
		}
		[CompilerGenerated]
		set
		{
			KdByyLemGpS = value;
		}
	}

	public virtual int QueueLength => concurrentQueue_0.Count;

	public virtual string Name => "Tacview2x";

	public virtual IEventExporter.EventExporterType ExporterType => IEventExporter.EventExporterType.const_5;

	public bool ExportExplosions
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public bool ExportWeaponImpacts
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public bool RequiresHeartbeatForStaticUnits => false;

	public bool UsesRAMQueue => true;

	public virtual bool IsOperating
	{
		get
		{
			return lppyypDtuFy;
		}
		set
		{
			lppyypDtuFy = value;
		}
	}

	public bool UsesUnitMissionAndStatus => false;

	public bool UsesUnitDamage => false;

	static EventExporter_Tacview2x()
	{
		Class72.smethod_20();
		dictionary_1 = new Dictionary<long, (string, string, string, string)>();
		dictionary_2 = new Dictionary<string, DataTable>();
		bool_15 = false;
		dictionary_3 = new Dictionary<string, DataTable>();
		bool_16 = false;
		concurrentDictionary_1 = new ConcurrentDictionary<long, Contact_Base.IdentificationStatus>();
		lockObject_0 = new LockObject();
	}

	public EventExporter_Tacview2x(IEventExporter.EventExporterRunMode theRunMode, string theFileExportFolder)
	{
		Common = new EventExporter_Common(this);
		bool_14 = false;
		concurrentQueue_0 = new ConcurrentQueue<IEventExporter.EventExportNotification>();
		concurrentDictionary_0 = new ConcurrentDictionary<string, Dictionary<string, long>>();
		dictionary_0 = new Dictionary<string, StreamWriter>();
		eventWaitHandle_0 = new EventWaitHandle(initialState: false, EventResetMode.AutoReset);
		bool_17 = false;
		NewUnitCache = new Dictionary<string, string>();
		lppyypDtuFy = true;
		RunMode = theRunMode;
		UseZeroHour = true;
		ExportUnitPositions = true;
		ExportWeaponFired = true;
		ExportUnitDestroyed = true;
		ExportWeaponEndgame = true;
		ExportFuelConsumed = false;
		ExportFuelTransfer = false;
		ExportCargoTransfer = false;
		ExportSensorDetectionSuccess = false;
		ExportSensorDetectionFailure = false;
		ExportAirOps = true;
		ExportDockingOps = true;
		ExportUnitDamaged = false;
		Common.GetCommonConfig("Tacview Settings");
		method_0();
		if (ExporterType == IEventExporter.EventExporterType.const_5)
		{
			if (string.IsNullOrEmpty(theFileExportFolder))
			{
				FileExportFolder = GameGeneral.TopLevelWritablePath;
			}
			else
			{
				FileExportFolder = theFileExportFolder;
			}
			Common.LoadPerUnitExportSettings();
			Start();
		}
	}

	private void method_0()
	{
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!bool_15 && FileExistsNative.FileExistsFast(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"))
			{
				dictionary_2.Add("Aircraft", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"));
				dictionary_2.Add("Ship", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 1));
				dictionary_2.Add("Submarine", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 2));
				dictionary_2.Add("Facility", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 3));
				dictionary_2.Add("Weapon", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls", 4));
				bool_15 = true;
			}
			if (!bool_16 && FileExistsNative.FileExistsFast(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls"))
			{
				dictionary_3.Add("Aircraft", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls"));
				dictionary_3.Add("Ship", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 1));
				dictionary_3.Add("Submarine", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 2));
				dictionary_3.Add("Facility", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 3));
				dictionary_3.Add("Weapon", NPOI.ExcelSheetToDataTable(GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_CWDB.xls", 4));
				bool_16 = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			MessageBox.Show(string.Format("Unable to read {0}", GameGeneral.ResourcesFolderPath + "\\Tacview\\Associations_DB3000.xls"));
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void Start()
	{
		thread_0 = new Thread(method_1);
		thread_0.Priority = ThreadPriority.BelowNormal;
		switch (RunMode)
		{
		case IEventExporter.EventExporterRunMode.NonInteractive:
			thread_0.Name = "Tacview 2.x Exporter (Monte Carlo) Thread";
			break;
		case IEventExporter.EventExporterRunMode.Interactive:
			thread_0.Name = "Tacview v2.x Exporter (Interactive) Thread";
			break;
		}
		thread_0.Start();
	}

	private void method_1()
	{
		string_1 = Path.Combine(FileExportFolder, "Tacview2x.acmi");
		try
		{
			if (FileExistsNative.FileExistsFast(string_1))
			{
				File.Delete(string_1);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		while (true)
		{
			eventWaitHandle_0.WaitOne();
			if (!bool_14)
			{
				method_2();
			}
		}
	}

	public virtual void ExportEvent(IEventExporter.ExportedEventType theEventType, PooledDictionary<string, IEventExporter.EventNotificationParameter> EventParameters, Scenario theScen)
	{
		if (!bool_17)
		{
			if (!Directory.Exists(FileExportFolder))
			{
				Directory.CreateDirectory(FileExportFolder);
			}
			bool_17 = true;
		}
		IEventExporter.EventExportNotification eventExportNotification = new IEventExporter.EventExportNotification();
		eventExportNotification.EventType = theEventType;
		eventExportNotification.EventParameters = EventParameters;
		eventExportNotification.ParentScen = theScen;
		eventExportNotification.FileExportFolder = FileExportFolder;
		concurrentQueue_0.Enqueue(eventExportNotification);
		if (!bool_14)
		{
			eventWaitHandle_0.Set();
		}
	}

	protected static void PrintPositionAndAttitude(long theTacviewID, Module_Unit.Unit theU, ref StringBuilder theSB, IEventExporter.EventExportNotification theNotification)
	{
		StringBuilder stringBuilder = StringBuilderCache.Allocate();
		try
		{
			stringBuilder.Append("T=");
			switch (theNotification.EventType)
			{
			case IEventExporter.ExportedEventType.WeaponFired:
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["FiringUnitLongitude"].Value), 6))).Append("|");
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["FiringUnitLatitude"].Value), 6))).Append("|");
				stringBuilder.Append(Conversions.ToInteger(theNotification.EventParameters["FiringUnitAltitude_m"].Value));
				break;
			default:
			{
				string value5 = XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["UnitLongitude"].Value), 6));
				string value6 = XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["UnitLatitude"].Value), 6));
				string text3 = XmlConvert.ToString(Math.Round(Conversions.ToSingle(theNotification.EventParameters["UnitCourse"].Value), 1));
				string text4 = Conversions.ToString(Conversions.ToInteger(theNotification.EventParameters["UnitAltitude_m"].Value));
				string text5 = "";
				string text6 = "";
				if (theU.IsActiveUnit)
				{
					text5 = XmlConvert.ToString(Conversions.ToSingle(theNotification.EventParameters["UnitAttitude_Roll"].Value));
					text6 = XmlConvert.ToString(Conversions.ToSingle(theNotification.EventParameters["UnitAttitude_Pitch"].Value));
				}
				string item = text3;
				string item2 = text4;
				string item3 = "";
				string item4 = "";
				if (theU.IsActiveUnit)
				{
					item3 = text5;
					item4 = text6;
				}
				lock (dictionary_1)
				{
					if (!dictionary_1.ContainsKey(theTacviewID))
					{
						dictionary_1.Add(theTacviewID, (text3, text4, text5, text6));
					}
					else
					{
						(string, string, string, string) tuple = dictionary_1[theTacviewID];
						bool flag = false;
						if (Operators.CompareString(tuple.Item1, text3, false) != 0)
						{
							flag = true;
						}
						if (Operators.CompareString(tuple.Item2, text4, false) != 0)
						{
							flag = true;
						}
						if (Operators.CompareString(tuple.Item3, text5, false) == 0)
						{
							text5 = "";
						}
						else
						{
							flag = true;
						}
						if (Operators.CompareString(tuple.Item4, text6, false) != 0)
						{
							flag = true;
						}
						else
						{
							text6 = "";
						}
						if (flag)
						{
							dictionary_1[theTacviewID] = (item, item2, item3, item4);
						}
					}
				}
				stringBuilder.Append(value5).Append("|");
				stringBuilder.Append(value6).Append("|");
				if ((!theU.IsShip || theU.IsFacility) && !string.IsNullOrEmpty(text4))
				{
					stringBuilder.Append(text4);
				}
				if (theU.IsActiveUnit)
				{
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(text5))
					{
						stringBuilder.Append(text5);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(text6))
					{
						stringBuilder.Append(text6);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(text3))
					{
						stringBuilder.Append(text3);
					}
				}
				break;
			}
			case IEventExporter.ExportedEventType.ContactPositions:
			{
				Contact contact = (Contact)theU;
				string text = XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["ContactLongitude"].Value), 6));
				string text2 = XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["ContactLatitude"].Value), 6));
				string value = (string.IsNullOrEmpty(Conversions.ToString(theNotification.EventParameters["ContactCourse"].Value)) ? "0" : XmlConvert.ToString(Math.Round(Conversions.ToSingle(theNotification.EventParameters["ContactCourse"].Value), 1)));
				string value2 = default(string);
				if (theNotification.EventParameters.ContainsKey("ContactAltitude_m"))
				{
					if (string.IsNullOrEmpty(Conversions.ToString(theNotification.EventParameters["ContactAltitude_m"].Value)))
					{
						if (!contact.IsAir_GuidedWeapon_Contact)
						{
							if (!contact.IsOrbitalContact && !contact.IsBallisticTarget())
							{
								if (!contact.IsLandContact)
								{
									if (!contact.IsSubmergedContact)
									{
										if (!contact.IsShipContact)
										{
											if (Debugger.IsAttached)
											{
												Debugger.Break();
											}
										}
										else
										{
											value2 = "0";
										}
									}
									else
									{
										value2 = Conversions.ToString((int)Math.Round((double)Terrain.GetElevation(Conversions.ToDouble(text2), Conversions.ToDouble(text), RequestIsFromGUI: false, contact.get_UnitSide(SetSideOnly: false).ParentScen) / 2.0));
									}
								}
								else
								{
									value2 = Conversions.ToString((int)Terrain.GetElevation(Conversions.ToDouble(text2), Conversions.ToDouble(text), RequestIsFromGUI: false, contact.get_UnitSide(SetSideOnly: false).ParentScen));
								}
							}
							else
							{
								value2 = "200000";
							}
						}
						else
						{
							value2 = "6000";
						}
					}
					else
					{
						value2 = XmlConvert.ToString(Conversions.ToSingle(theNotification.EventParameters["ContactAltitude_m"].Value));
					}
				}
				else
				{
					value2 = theU.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null).ToString();
				}
				string value3 = "";
				string value4 = "";
				if (theU.IsActiveUnit)
				{
					value3 = XmlConvert.ToString(Conversions.ToSingle(theNotification.EventParameters["UnitAttitude_Roll"].Value));
					value4 = XmlConvert.ToString(Conversions.ToSingle(theNotification.EventParameters["UnitAttitude_Pitch"].Value));
				}
				stringBuilder.Append(text).Append("|");
				stringBuilder.Append(text2).Append("|");
				if ((!theU.IsShip || theU.IsFacility) && !string.IsNullOrEmpty(value2))
				{
					stringBuilder.Append(value2);
				}
				if (theU.IsActiveUnit)
				{
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(value3))
					{
						stringBuilder.Append(value3);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(value4))
					{
						stringBuilder.Append(value4);
					}
					stringBuilder.Append("|");
					if (!string.IsNullOrEmpty(value))
					{
						stringBuilder.Append(value);
					}
				}
				stringBuilder.Append(mcYyLbrbPai(theTacviewID, contact, theNotification.EventParameters["ObserverSide"].Value.ToString()));
				break;
			}
			case IEventExporter.ExportedEventType.Explosion:
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["Longitude"].Value), 6))).Append("|");
				stringBuilder.Append(XmlConvert.ToString(Math.Round(Conversions.ToDouble(theNotification.EventParameters["Latitude"].Value), 6))).Append("|");
				stringBuilder.Append(Conversions.ToInteger(theNotification.EventParameters["Altitude"].Value));
				break;
			case IEventExporter.ExportedEventType.WeaponEndgame:
				break;
			}
			theSB.Append(stringBuilder.ToString());
			StringBuilderCache.Free(theSB);
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

	private static string mcYyLbrbPai(long long_0, object object_0, string string_2)
	{
		if (object_0 != null)
		{
			if (concurrentDictionary_1.TryGetValue(long_0, out var value))
			{
				if (value == ((Contact)object_0).IDStatus)
				{
					return string.Empty;
				}
				concurrentDictionary_1[long_0] = ((Contact)object_0).IDStatus;
			}
			else
			{
				concurrentDictionary_1.TryAdd(long_0, ((Contact)object_0).IDStatus);
			}
			StringBuilder stringBuilder_ = StringBuilderCache.Allocate();
			stringBuilder_.Append(",Name=").Append(((Contact)object_0).Name.Replace(",", "\\,"));
			if (((Contact)object_0).ActualUnit != null)
			{
				ActiveUnit actualUnit = ((Contact)object_0).ActualUnit;
				Scenario parentScen = actualUnit.ParentScen;
				Side side = parentScen.Sides_ReadOnly.Where([SpecialName] (Side theSide) => Operators.CompareString(theSide.Name, string_2, false) == 0).FirstOrDefault();
				string value2 = "White";
				switch (((Contact)object_0).get_Stance(side))
				{
				case Misc.PostureStance.Neutral:
					value2 = "Green";
					break;
				case Misc.PostureStance.Friendly:
					value2 = "Blue";
					break;
				case Misc.PostureStance.Unfriendly:
					value2 = "Orange";
					break;
				case Misc.PostureStance.Hostile:
					value2 = "Red";
					break;
				case Misc.PostureStance.Unknown:
					value2 = "Yellow";
					break;
				}
				stringBuilder_.Append(",Color=").Append(value2);
				if (((Contact)object_0).IDStatus < Contact_Base.IdentificationStatus.KnownClass && !actualUnit.get_IsAutoDetectable((Side)null) && !actualUnit.get_IsAutoDetectable(side))
				{
					switch (((Contact_Base)object_0).Type)
					{
					case Contact_Base.ContactType.Missile:
						stringBuilder_.Append(",Shape=Missile.GenericMRBM.obj");
						break;
					case Contact_Base.ContactType.Orbital:
						stringBuilder_.Append(",Shape=Spacecraft.Satellite.obj");
						break;
					case Contact_Base.ContactType.Torpedo:
						stringBuilder_.Append(",Shape=Core.Torpedo.obj");
						break;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Decoy_Air:
						if (actualUnit.IsAircraft && ((Aircraft)actualUnit).IsHelicopter)
						{
							stringBuilder_.Append(",Shape=TransparentHelo.obj");
						}
						else
						{
							stringBuilder_.Append(",Shape=TransparentBogie.obj");
						}
						break;
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.Decoy_Surface:
						stringBuilder_.Append(",Shape=TransparentSkunk.obj");
						break;
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.Decoy_Land:
						stringBuilder_.Append(",Shape=TransparentVehicle.obj");
						break;
					case Contact_Base.ContactType.Submarine:
					case Contact_Base.ContactType.Decoy_Sub:
						stringBuilder_.Append(",Shape=TransparentGoblin.obj");
						break;
					case Contact_Base.ContactType.Sonobuoy:
						stringBuilder_.Append(",Shape=apache.sonobuoy");
						break;
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						break;
					case Contact_Base.ContactType.Aimpoint:
					case Contact_Base.ContactType.Facility_Fixed:
					case Contact_Base.ContactType.Installation:
					case Contact_Base.ContactType.AirBase:
					case Contact_Base.ContactType.NavalBase:
					case Contact_Base.ContactType.ActivationPoint:
						smethod_1(actualUnit, parentScen, stringBuilder_);
						break;
					case Contact_Base.ContactType.AggregateGroundUnit:
						stringBuilder_.Append(",Shape=TransparentVehicle.obj");
						break;
					}
				}
				else
				{
					smethod_1(actualUnit, parentScen, stringBuilder_);
				}
				stringBuilder_.Append(",");
				smethod_0(object_0, ref stringBuilder_);
			}
			string result = stringBuilder_.ToString();
			StringBuilderCache.Free(stringBuilder_);
			return result;
		}
		return string.Empty;
	}

	private static void smethod_0(object object_0, ref StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append("Type=");
		if (!((ScenarioObject)object_0).IsActiveUnit && !((ScenarioObject)object_0).IsContact())
		{
			if ((object)object_0.GetType() == typeof(UnguidedWeapon))
			{
				stringBuilder_0.Append("+Weapon");
				switch (((UnguidedWeapon)object_0).Type)
				{
				case Weapon._WeaponType.Rocket:
					stringBuilder_0.Append("+Rocket");
					break;
				case Weapon._WeaponType.IronBomb:
					stringBuilder_0.Append("+Bomb");
					break;
				case Weapon._WeaponType.Gun:
					stringBuilder_0.Append("+Projectile");
					if (((UnguidedWeapon)object_0).Warheads.Length > 0)
					{
						Warhead.WarheadCaliber caliber = ((UnguidedWeapon)object_0).Warheads[0].Caliber;
						if (caliber == Warhead.WarheadCaliber.Gun_6_15mm)
						{
							stringBuilder_0.Append("+Bullet");
						}
						else
						{
							stringBuilder_0.Append("+Shell");
						}
					}
					break;
				}
			}
			else if ((object)object_0.GetType() == typeof(WeaponImpact))
			{
				stringBuilder_0.Append("+Explosion");
			}
			return;
		}
		ActiveUnit activeUnit = (((ScenarioObject)object_0).IsActiveUnit ? ((ActiveUnit)object_0) : ((Contact)object_0).ActualUnit);
		if (!activeUnit.IsFixedFacility)
		{
			if (!activeUnit.IsSatellite)
			{
				switch (activeUnit.VisualSizeClass)
				{
				case GlobalVariables.TargetVisualSizeClass.Stealthy:
				case GlobalVariables.TargetVisualSizeClass.VSmall:
					stringBuilder_0.Append("Minor");
					break;
				case GlobalVariables.TargetVisualSizeClass.Small:
					stringBuilder_0.Append("Light");
					break;
				case GlobalVariables.TargetVisualSizeClass.Medium:
					stringBuilder_0.Append("Medium");
					break;
				case GlobalVariables.TargetVisualSizeClass.Large:
				case GlobalVariables.TargetVisualSizeClass.VLarge:
					stringBuilder_0.Append("Heavy");
					break;
				}
			}
			else
			{
				stringBuilder_0.Append("Medium");
			}
		}
		else
		{
			stringBuilder_0.Append("Static");
		}
		switch (activeUnit.UnitType)
		{
		case GlobalVariables.ActiveUnitType.Aircraft:
			stringBuilder_0.Append("+Air");
			if (((Aircraft)activeUnit).IsHelicopter)
			{
				stringBuilder_0.Append("+Rotorcraft");
			}
			else
			{
				stringBuilder_0.Append("+FixedWing");
			}
			break;
		case GlobalVariables.ActiveUnitType.Ship:
			stringBuilder_0.Append("+Sea");
			switch (((Ship)activeUnit).Category)
			{
			case Ship._ShipCategory.SurfaceCombatant:
				stringBuilder_0.Append("+Warship");
				break;
			case Ship._ShipCategory.AviationShip:
			case Ship._ShipCategory.SurfaceCombatantAviation:
				stringBuilder_0.Append("+AircraftCarrier");
				break;
			}
			break;
		case GlobalVariables.ActiveUnitType.Submarine:
			stringBuilder_0.Append("+Sea+Watercraft+Submarine");
			break;
		case GlobalVariables.ActiveUnitType.Facility:
			stringBuilder_0.Append("+Ground");
			if (!activeUnit.IsFixedFacility)
			{
				switch (((Facility)activeUnit).MobileUnitCategory())
				{
				case IMobileGroundUnit._MobileUnitCategory.AAA:
				case IMobileGroundUnit._MobileUnitCategory.SAM:
					stringBuilder_0.Append("+AntiAircraft");
					break;
				case IMobileGroundUnit._MobileUnitCategory.Artillery_Gun:
				case IMobileGroundUnit._MobileUnitCategory.Artillery_Towed:
				case IMobileGroundUnit._MobileUnitCategory.Artillery_SSM:
				case IMobileGroundUnit._MobileUnitCategory.Engineer:
				case IMobileGroundUnit._MobileUnitCategory.MechInfantry:
					stringBuilder_0.Append("+Vehicle");
					break;
				default:
					stringBuilder_0.Append("+Vehicle");
					break;
				case IMobileGroundUnit._MobileUnitCategory.Armor:
					stringBuilder_0.Append("+Armor+Tank");
					break;
				case IMobileGroundUnit._MobileUnitCategory.Infantry:
					stringBuilder_0.Append("+Human");
					break;
				}
			}
			else if (!activeUnit.HasAirFacilities)
			{
				stringBuilder_0.Append("+Building");
			}
			else if (activeUnit.AirFacilities_ReadOnly[0].IsOpenAirFacility)
			{
				stringBuilder_0.Append("+Aerodrome");
			}
			else
			{
				stringBuilder_0.Append("+Building");
			}
			break;
		case GlobalVariables.ActiveUnitType.Weapon:
			stringBuilder_0.Append("+Weapon");
			switch (((Weapon)activeUnit).Type)
			{
			case Weapon._WeaponType.GuidedProjectile:
				stringBuilder_0.Append("+Projectile");
				break;
			case Weapon._WeaponType.Decoy_Expendable:
			case Weapon._WeaponType.Decoy_Towed:
				stringBuilder_0.Append("+Decoy");
				break;
			case Weapon._WeaponType.GuidedWeapon:
				stringBuilder_0.Append("+Missile");
				break;
			case Weapon._WeaponType.BallisticMissile:
			case Weapon._WeaponType.RV:
			case Weapon._WeaponType.HGV:
				stringBuilder_0.Append("+Missile");
				break;
			case Weapon._WeaponType.Torpedo:
				stringBuilder_0.Append("+Torpedo");
				break;
			}
			break;
		}
		if (((ScenarioObject)object_0).IsContact())
		{
			stringBuilder_0.Append("+Static");
		}
	}

	protected static long DeclareNewUnit(string UnitObjectID, _TypeOfNewObjectToDeclare TypeOfObject, string UnitParentID, ref StringBuilder theSB, Scenario theScen, Dictionary<string, long> UnitDeclarations, IEventExporter.EventExportNotification theNotification, Dictionary<string, string> NewUnitCache)
	{
		_Closure$__110-0 arg = default(_Closure$__110-0);
		_Closure$__110-0 CS$<>8__locals48 = new _Closure$__110-0(arg);
		CS$<>8__locals48.$VB$Local_UnitObjectID = UnitObjectID;
		CS$<>8__locals48.$VB$Local_theNotification = theNotification;
		long result;
		try
		{
			lock (lockObject_0)
			{
				UnitIDIncrement++;
				switch (TypeOfObject)
				{
				case _TypeOfNewObjectToDeclare.ActiveUnit:
				{
					if (!theScen.ActiveUnits.ContainsKey(CS$<>8__locals48.$VB$Local_UnitObjectID))
					{
						break;
					}
					ActiveUnit activeUnit = theScen.ActiveUnits[CS$<>8__locals48.$VB$Local_UnitObjectID];
					if (activeUnit == null)
					{
						result = 0L;
					}
					else if (!string.IsNullOrEmpty(activeUnit.UnitClass))
					{
						long unitIDIncrement3 = UnitIDIncrement;
						UnitDeclarations.Add(CS$<>8__locals48.$VB$Local_UnitObjectID, unitIDIncrement3);
						theSB.AppendLine().Append(unitIDIncrement3).Append(",");
						PrintPositionAndAttitude(unitIDIncrement3, activeUnit, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
						theSB.Append(",");
						smethod_0(activeUnit, ref theSB);
						theSB.Append(",");
						switch (activeUnit.UnitType)
						{
						case GlobalVariables.ActiveUnitType.Aircraft:
							theSB.Append("Length=").Append(((Aircraft)activeUnit).Length).Append(",");
							theSB.Append("Width=").Append(((Aircraft)activeUnit).Span).Append(",");
							break;
						case GlobalVariables.ActiveUnitType.Ship:
							theSB.Append("Length=").Append(((Ship)activeUnit).Length).Append(",");
							theSB.Append("Width=").Append(((Ship)activeUnit).Beam).Append(",");
							break;
						case GlobalVariables.ActiveUnitType.Submarine:
							theSB.Append("Length=").Append(((Submarine)activeUnit).Length).Append(",");
							theSB.Append("Width=").Append(((Submarine)activeUnit).Beam).Append(",");
							break;
						case GlobalVariables.ActiveUnitType.Facility:
							theSB.Append("Length=").Append(((Facility)activeUnit).Length).Append(",");
							theSB.Append("Width=").Append(((Facility)activeUnit).Width).Append(",");
							if (!activeUnit.HasAirFacilities || !activeUnit.AirFacilities_ReadOnly[0].IsOpenAirFacility)
							{
								double value = ((Facility)activeUnit).Length / 4f;
								theSB.Append("Height=").Append(value).Append(",");
							}
							break;
						case GlobalVariables.ActiveUnitType.Weapon:
							theSB.Append("Length=").Append(((Weapon)activeUnit).Length).Append(",");
							break;
						}
						if (CS$<>8__locals48.$VB$Local_theNotification.EventType == IEventExporter.ExportedEventType.WeaponFired)
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["FiringUnitSide"].Value));
						}
						else if (CS$<>8__locals48.$VB$Local_theNotification.EventType == IEventExporter.ExportedEventType.WeaponEndgame)
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["WeaponSide"].Value));
						}
						else
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["UnitSide"].Value));
						}
						theSB.Append(",");
						string value2 = "Blue";
						switch (theScen.Sides_ReadOnly[0].get_ConsidersThisSideToBe(activeUnit.get_UnitSide(SetSideOnly: false), (Scenario)null))
						{
						case Misc.PostureStance.Neutral:
							value2 = "White";
							break;
						case Misc.PostureStance.Friendly:
							value2 = "Blue";
							break;
						case Misc.PostureStance.Unfriendly:
							value2 = "Orange";
							break;
						case Misc.PostureStance.Hostile:
							value2 = "Red";
							break;
						}
						theSB.Append("Color=").Append(value2);
						theSB.Append(",Name=").Append(activeUnit.UnitClass.Replace(",", "\\,")).Append(",Pilot=")
							.Append(activeUnit.Name.Replace(",", "\\,"));
						if (activeUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
						{
							theSB.Append(",Group=").Append(activeUnit.get_ParentGroup(UsingMissionPlanner: false).Name.Replace(",", "\\,"));
						}
						if (!string.IsNullOrEmpty(UnitParentID))
						{
							long value3 = ((!UnitDeclarations.ContainsKey(UnitParentID)) ? DeclareNewUnit(UnitParentID, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref theSB, theScen, UnitDeclarations, CS$<>8__locals48.$VB$Local_theNotification, NewUnitCache) : UnitDeclarations[UnitParentID]);
							theSB.Append(",Parent=").Append(value3);
						}
						NewUnitCache[CS$<>8__locals48.$VB$Local_UnitObjectID] = theSB.ToString();
						smethod_1(activeUnit, theScen, theSB);
						result = unitIDIncrement3;
					}
					else
					{
						result = 0L;
					}
					goto end_IL_0016;
				}
				case _TypeOfNewObjectToDeclare.UnguidedWeapon:
				{
					if (!theScen.UnguidedWeapons.ContainsKey(CS$<>8__locals48.$VB$Local_UnitObjectID))
					{
						break;
					}
					UnguidedWeapon unguidedWeapon = theScen.UnguidedWeapons[CS$<>8__locals48.$VB$Local_UnitObjectID];
					if (unguidedWeapon == null)
					{
						result = 0L;
					}
					else
					{
						if (unguidedWeapon.Type == Weapon._WeaponType.Laser || unguidedWeapon.Type == Weapon._WeaponType.Microwave || unguidedWeapon.Type == Weapon._WeaponType.LaserDazzler)
						{
							long unitIDIncrement4 = UnitIDIncrement;
							UnitDeclarations.Add(CS$<>8__locals48.$VB$Local_UnitObjectID, unitIDIncrement4);
							theSB.AppendLine().Append(unitIDIncrement4).Append(",");
							PrintPositionAndAttitude(unitIDIncrement4, unguidedWeapon, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
							Conversions.ToString(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["FiringUnitID"].Value);
							string key = Conversions.ToString(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["TargetContactActualUnitID"].Value);
							long value4 = UnitDeclarations[key];
							theSB.Append(",Type=Beam,FocusedTarget=").Append(value4);
							theSB.Append("\r\n");
							TimeSpan timeSpan4 = TimeSpan.Parse(Conversions.ToString(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["Time"].Value));
							theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan4.Add(new TimeSpan(0, 0, 2)).TotalSeconds)) + "." + timeSpan4.Milliseconds.ToString("D3"));
							theSB.AppendLine().Append("-").Append(unitIDIncrement4)
								.Append("\r\n");
							theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan4.TotalSeconds)) + "." + timeSpan4.Milliseconds.ToString("D3")).Append("\r\n");
							break;
						}
						long unitIDIncrement5 = UnitIDIncrement;
						UnitDeclarations.Add(CS$<>8__locals48.$VB$Local_UnitObjectID, unitIDIncrement5);
						theSB.AppendLine().Append(unitIDIncrement5).Append(",");
						if (CS$<>8__locals48.$VB$Local_theNotification.EventType == IEventExporter.ExportedEventType.WeaponEndgame)
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["WeaponSide"].Value));
						}
						else
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["FiringUnitSide"].Value));
						}
						PrintPositionAndAttitude(unitIDIncrement5, unguidedWeapon, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
						theSB.Append(",");
						smethod_0(unguidedWeapon, ref theSB);
						theSB.Append(",");
						if (CS$<>8__locals48.$VB$Local_theNotification.EventType == IEventExporter.ExportedEventType.WeaponEndgame)
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["WeaponSide"].Value));
						}
						else if (!CS$<>8__locals48.$VB$Local_theNotification.EventParameters.ContainsKey("FiringUnitSide"))
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["UnitSide"].Value));
						}
						else
						{
							theSB.Append("Coalition=").Append(RuntimeHelpers.GetObjectValue(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["FiringUnitSide"].Value));
						}
						theSB.Append(",");
						string value5 = "Blue";
						switch (theScen.Sides_ReadOnly[0].get_ConsidersThisSideToBe(unguidedWeapon.get_UnitSide(SetSideOnly: false), (Scenario)null))
						{
						case Misc.PostureStance.Neutral:
							value5 = "White";
							break;
						case Misc.PostureStance.Friendly:
							value5 = "Blue";
							break;
						case Misc.PostureStance.Unfriendly:
							value5 = "Orange";
							break;
						case Misc.PostureStance.Hostile:
							value5 = "Red";
							break;
						}
						theSB.Append("Color=").Append(value5);
						theSB.Append(",Name=").Append(unguidedWeapon.UnitClass.Replace(",", ".")).Append(",Pilot=")
							.Append(unguidedWeapon.Name.Replace(",", "."));
						if (!string.IsNullOrEmpty(UnitParentID))
						{
							long value6 = (UnitDeclarations.ContainsKey(UnitParentID) ? UnitDeclarations[UnitParentID] : DeclareNewUnit(UnitParentID, _TypeOfNewObjectToDeclare.UnguidedWeapon, null, ref theSB, theScen, UnitDeclarations, CS$<>8__locals48.$VB$Local_theNotification, NewUnitCache));
							theSB.Append(",Parent=").Append(value6);
						}
						result = unitIDIncrement5;
					}
					goto end_IL_0016;
				}
				case _TypeOfNewObjectToDeclare.Contact:
				{
					Contact contact = null;
					Side side = null;
					side = theScen.Sides_ReadOnly.Where([SpecialName] (Side theSide) => Operators.CompareString(theSide.Name, CS$<>8__locals48.$VB$Local_theNotification.EventParameters["ObserverSide"].Value.ToString(), false) == 0).FirstOrDefault();
					if (side != null)
					{
						PooledList<Contact> contacts_List = side.Contacts_List;
						foreach (Contact item in contacts_List)
						{
							if (Operators.CompareString(item.ObjectID, CS$<>8__locals48.$VB$Local_UnitObjectID, false) == 0)
							{
								contact = item;
								break;
							}
						}
						if (contact != null)
						{
							ActiveUnit actualUnit = contact.ActualUnit;
							if (actualUnit == null)
							{
								int num4;
								if (!Debugger.IsAttached)
								{
									num4 = 0;
								}
								else
								{
									Debugger.Break();
									num4 = 0;
								}
								result = num4;
							}
							else if (string.IsNullOrEmpty(actualUnit.UnitClass))
							{
								int num5;
								if (!Debugger.IsAttached)
								{
									num5 = 0;
								}
								else
								{
									Debugger.Break();
									num5 = 0;
								}
								result = num5;
							}
							else
							{
								long unitIDIncrement6 = UnitIDIncrement;
								UnitDeclarations.Add(CS$<>8__locals48.$VB$Local_UnitObjectID, unitIDIncrement6);
								theSB.AppendLine().Append(unitIDIncrement6).Append(",");
								PrintPositionAndAttitude(unitIDIncrement6, contact, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
								theSB.Append(",");
								smethod_0(contact, ref theSB);
								theSB.Append(",");
								switch (actualUnit.UnitType)
								{
								case GlobalVariables.ActiveUnitType.Aircraft:
									theSB.Append("Length=").Append(((Aircraft)actualUnit).Length).Append(",");
									theSB.Append("Width=").Append(((Aircraft)actualUnit).Span).Append(",");
									break;
								case GlobalVariables.ActiveUnitType.Ship:
									theSB.Append("Length=").Append(((Ship)actualUnit).Length).Append(",");
									theSB.Append("Width=").Append(((Ship)actualUnit).Beam).Append(",");
									break;
								case GlobalVariables.ActiveUnitType.Submarine:
									theSB.Append("Length=").Append(((Submarine)actualUnit).Length).Append(",");
									theSB.Append("Width=").Append(((Submarine)actualUnit).Beam).Append(",");
									break;
								case GlobalVariables.ActiveUnitType.Facility:
									theSB.Append("Length=").Append(((Facility)actualUnit).Length).Append(",");
									theSB.Append("Width=").Append(((Facility)actualUnit).Width).Append(",");
									if (!actualUnit.HasAirFacilities || !actualUnit.AirFacilities_ReadOnly[0].IsOpenAirFacility)
									{
										double value7 = ((Facility)actualUnit).Length / 4f;
										theSB.Append("Height=").Append(value7).Append(",");
									}
									break;
								case GlobalVariables.ActiveUnitType.Weapon:
									theSB.Append("Length=").Append(((Weapon)actualUnit).Length).Append(",");
									break;
								}
								string value8 = "White";
								switch (contact.get_Stance(side))
								{
								case Misc.PostureStance.Neutral:
									value8 = "Green";
									break;
								case Misc.PostureStance.Friendly:
									value8 = "Blue";
									break;
								case Misc.PostureStance.Unfriendly:
									value8 = "Orange";
									break;
								case Misc.PostureStance.Hostile:
									value8 = "Red";
									break;
								case Misc.PostureStance.Unknown:
									value8 = "Yellow";
									break;
								}
								theSB.Append("Color=").Append(value8);
								theSB.Append(",Name=").Append(contact.Name.Replace(",", "\\,"));
								if (actualUnit.get_ParentGroup(UsingMissionPlanner: false) != null)
								{
									theSB.Append(",Group=").Append(actualUnit.get_ParentGroup(UsingMissionPlanner: false).Name.Replace(",", "\\,"));
								}
								if (!string.IsNullOrEmpty(UnitParentID))
								{
									long value9 = ((!UnitDeclarations.ContainsKey(UnitParentID)) ? DeclareNewUnit(UnitParentID, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref theSB, theScen, UnitDeclarations, CS$<>8__locals48.$VB$Local_theNotification, NewUnitCache) : UnitDeclarations[UnitParentID]);
									theSB.Append(",Parent=").Append(value9);
								}
								NewUnitCache[CS$<>8__locals48.$VB$Local_UnitObjectID] = theSB.ToString();
								if (contact.IDStatus < Contact_Base.IdentificationStatus.KnownClass && !actualUnit.get_IsAutoDetectable((Side)null) && !actualUnit.get_IsAutoDetectable(side))
								{
									switch (contact.Type)
									{
									case Contact_Base.ContactType.Missile:
										theSB.Append(",Shape=Missile.GenericMRBM.obj");
										break;
									case Contact_Base.ContactType.Orbital:
										theSB.Append(",Shape=Spacecraft.Satellite.obj");
										break;
									case Contact_Base.ContactType.Torpedo:
										theSB.Append(",Shape=Core.Torpedo.obj");
										break;
									case Contact_Base.ContactType.Air:
									case Contact_Base.ContactType.Decoy_Air:
										if (actualUnit.IsAircraft && ((Aircraft)actualUnit).IsHelicopter)
										{
											theSB.Append(",Shape=TransparentHelo.obj");
										}
										else
										{
											theSB.Append(",Shape=TransparentBogie.obj");
										}
										break;
									case Contact_Base.ContactType.Surface:
									case Contact_Base.ContactType.Decoy_Surface:
										theSB.Append(",Shape=TransparentSkunk.obj");
										break;
									case Contact_Base.ContactType.Facility_Mobile:
									case Contact_Base.ContactType.Decoy_Land:
										theSB.Append(",Shape=TransparentVehicle.obj");
										break;
									case Contact_Base.ContactType.Submarine:
									case Contact_Base.ContactType.Decoy_Sub:
										theSB.Append(",Shape=TransparentGoblin.obj");
										break;
									case Contact_Base.ContactType.Sonobuoy:
										theSB.Append(",Shape=apache.sonobuoy");
										break;
									default:
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										break;
									case Contact_Base.ContactType.Aimpoint:
									case Contact_Base.ContactType.Facility_Fixed:
									case Contact_Base.ContactType.Installation:
									case Contact_Base.ContactType.AirBase:
									case Contact_Base.ContactType.NavalBase:
									case Contact_Base.ContactType.ActivationPoint:
										smethod_1(actualUnit, theScen, theSB);
										break;
									case Contact_Base.ContactType.AggregateGroundUnit:
										theSB.Append(",Shape=TransparentVehicle.obj");
										break;
									}
									DeclareNewUnit(CS$<>8__locals48.$VB$Local_UnitObjectID, _TypeOfNewObjectToDeclare.Contact, UnitParentID, ref theSB, theScen, UnitDeclarations, CS$<>8__locals48.$VB$Local_theNotification, NewUnitCache);
								}
								else
								{
									smethod_1(actualUnit, theScen, theSB);
								}
								result = unitIDIncrement6;
							}
						}
						else
						{
							int num6;
							if (!Debugger.IsAttached)
							{
								num6 = 0;
							}
							else
							{
								Debugger.Break();
								num6 = 0;
							}
							result = num6;
						}
					}
					else
					{
						int num7;
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							num7 = 0;
						}
						else
						{
							num7 = 0;
						}
						result = num7;
					}
					goto end_IL_0016;
				}
				case _TypeOfNewObjectToDeclare.WeaponImpact:
				{
					long unitIDIncrement2 = UnitIDIncrement;
					UnitDeclarations.Add(CS$<>8__locals48.$VB$Local_UnitObjectID, unitIDIncrement2);
					theSB.AppendLine().Append(unitIDIncrement2).Append(",");
					Scenario theScen2 = null;
					WeaponImpact theU = new WeaponImpact(ref theScen2, 0.0, 0.0, 0f, WeaponImpact.ImpactType.Kinetic, 0);
					PrintPositionAndAttitude(unitIDIncrement2, theU, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
					theSB.Append(",Type=Misc+Explosion");
					theSB.Append("\r\n");
					TimeSpan timeSpan3 = TimeSpan.Parse(Conversions.ToString(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["Time"].Value));
					theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan3.Add(new TimeSpan(0, 0, 5)).TotalSeconds)) + "." + timeSpan3.Milliseconds.ToString("D3"));
					theSB.AppendLine().Append("-").Append(unitIDIncrement2)
						.Append("\r\n");
					theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan3.TotalSeconds)) + "." + timeSpan3.Milliseconds.ToString("D3")).Append("\r\n");
					result = unitIDIncrement2;
					goto end_IL_0016;
				}
				case _TypeOfNewObjectToDeclare.Explosion:
				{
					long unitIDIncrement = UnitIDIncrement;
					Explosion explosion = CS$<>8__locals48.$VB$Local_theNotification.ParentScen.Explosions.Where([SpecialName] (Explosion theE) => Operators.CompareString(theE.ObjectID, CS$<>8__locals48.$VB$Local_UnitObjectID, false) == 0).FirstOrDefault();
					if (explosion == null)
					{
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
						result = num;
					}
					else
					{
						UnitDeclarations.Add(CS$<>8__locals48.$VB$Local_UnitObjectID, unitIDIncrement);
						theSB.AppendLine().Append(unitIDIncrement).Append(",");
						PrintPositionAndAttitude(unitIDIncrement, explosion, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
						theSB.Append(",Radius=1,Type=Misc+Explosion").Append("\r\n");
						Weapon.DetonationMedium theMedium = (Module_Unit.IsOverLand(explosion) ? ((explosion.CurrentAltitude_AGL < 0f) ? Weapon.DetonationMedium.Underground : Weapon.DetonationMedium.Air) : ((((Module_Unit.Unit)explosion).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 0f) ? Weapon.DetonationMedium.Underwater : Weapon.DetonationMedium.Air));
						float num2 = default(float);
						switch (explosion.WarheadType)
						{
						case Warhead.WarheadType.Incendiary:
							num2 = (float)Math.Sqrt(2100.0 / Math.PI);
							break;
						case Warhead.WarheadType.HE_BlastFrag:
						case Warhead.WarheadType.SemiAP:
						case Warhead.WarheadType.HardTargetPenetrator:
						case Warhead.WarheadType.Torpedo:
						case Warhead.WarheadType.DepthCharge:
						case Warhead.WarheadType.Nuclear:
							num2 = Explosion.GetCutoffRange_Blast_nm(explosion.ExpYield, theMedium);
							break;
						case Warhead.WarheadType.FAE:
							num2 = (float)(explosion.ExpYield / 5.0);
							break;
						case Warhead.WarheadType.Fragmentation:
						case Warhead.WarheadType.SuperFrag:
						case Warhead.WarheadType.Fragmentation_ABM:
							num2 = Explosion.GetCutoffRange_Frag_nm(explosion.ExpYield, theMedium, explosion.WarheadType);
							break;
						}
						TimeSpan timeSpan = TimeSpan.Parse(Conversions.ToString(CS$<>8__locals48.$VB$Local_theNotification.EventParameters["Time"].Value));
						float maxDuration = explosion.MaxDuration;
						float num3 = 0.1f;
						TimeSpan timeSpan2;
						do
						{
							timeSpan2 = timeSpan.Add(new TimeSpan(0, 0, 0, 0, (int)Math.Round(maxDuration * num3 * 1000f)));
							theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan2.TotalSeconds)) + "." + timeSpan2.Milliseconds.ToString("D3"));
							theSB.AppendLine().Append(unitIDIncrement).Append(",");
							PrintPositionAndAttitude(unitIDIncrement, explosion, ref theSB, CS$<>8__locals48.$VB$Local_theNotification);
							theSB.Append(",Radius=").Append((int)Math.Round((double)(num3 * num2) * 1852.0));
							theSB.Append("\r\n");
							num3 += 0.1f;
						}
						while (num3 <= 1f);
						theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan2.Add(new TimeSpan(0, 0, 1)).TotalSeconds)) + "." + timeSpan.Milliseconds.ToString("D3"));
						theSB.AppendLine().Append("-").Append(unitIDIncrement)
							.Append("\r\n");
						theSB.Append("#" + Conversions.ToString(Math.Floor(timeSpan.TotalSeconds)) + "." + timeSpan.Milliseconds.ToString("D3")).Append("\r\n");
						result = unitIDIncrement;
					}
					goto end_IL_0016;
				}
				}
			}
			result = 0L;
			end_IL_0016:;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			_ = Debugger.IsAttached;
			result = 0L;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_1(object object_0, Scenario scenario_0, StringBuilder stringBuilder_0)
	{
		string dBUsed = scenario_0.DBUsed;
		DBOps.DBFileCheckResult theResult = default(DBOps.DBFileCheckResult);
		switch (DBOps.GetDBRecordByHash(dBUsed, ref theResult, CheckLocalFileExists: false, CheckForTampering: false).DBID)
		{
		case 2:
		{
			DataTable dataTable2 = null;
			switch (((ActiveUnit)object_0).UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				dataTable2 = dictionary_3["Aircraft"];
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				dataTable2 = dictionary_3["Ship"];
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				dataTable2 = dictionary_3["Submarine"];
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				dataTable2 = dictionary_3["Weapon"];
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				stringBuilder_0.Append(",Shape=Spacecraft.Satellite.obj");
				break;
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
				dataTable2 = dictionary_3["Facility"];
				break;
			}
			if (((ScenarioObject)object_0).IsSatellite || dataTable2 == null)
			{
				break;
			}
			string text2 = ((ActiveUnit)object_0).DBID.ToString();
			{
				IEnumerator enumerator2 = dataTable2.Rows.GetEnumerator();
				try
				{
					DataRow dataRow2;
					do
					{
						if (enumerator2.MoveNext())
						{
							dataRow2 = (DataRow)enumerator2.Current;
							continue;
						}
						return;
					}
					while (Operators.CompareString(Conversions.ToString(dataRow2["DBID"]), text2, false) != 0);
					stringBuilder_0.Append(",Shape=").Append(RuntimeHelpers.GetObjectValue(dataRow2["Mesh"]));
					break;
				}
				finally
				{
					IDisposable disposable = enumerator2 as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
		}
		case 1:
		{
			DataTable dataTable = null;
			switch (((ActiveUnit)object_0).UnitType)
			{
			case GlobalVariables.ActiveUnitType.Aircraft:
				dataTable = dictionary_2["Aircraft"];
				break;
			case GlobalVariables.ActiveUnitType.Ship:
				dataTable = dictionary_2["Ship"];
				break;
			case GlobalVariables.ActiveUnitType.Submarine:
				dataTable = dictionary_2["Submarine"];
				break;
			case GlobalVariables.ActiveUnitType.Weapon:
				dataTable = dictionary_2["Weapon"];
				break;
			case GlobalVariables.ActiveUnitType.Satellite:
				stringBuilder_0.Append(",Shape=Spacecraft.Satellite.obj");
				break;
			case GlobalVariables.ActiveUnitType.Facility:
			case GlobalVariables.ActiveUnitType.Vehicle:
				dataTable = dictionary_2["Facility"];
				break;
			}
			if (((ScenarioObject)object_0).IsSatellite || dataTable == null)
			{
				break;
			}
			string text = ((ActiveUnit)object_0).DBID.ToString();
			{
				IEnumerator enumerator = dataTable.Rows.GetEnumerator();
				try
				{
					DataRow dataRow;
					do
					{
						if (enumerator.MoveNext())
						{
							dataRow = (DataRow)enumerator.Current;
							continue;
						}
						return;
					}
					while (Operators.CompareString(Conversions.ToString(dataRow["DBID"]), text, false) != 0);
					stringBuilder_0.Append(",Shape=").Append(RuntimeHelpers.GetObjectValue(dataRow["Mesh"]));
					break;
				}
				finally
				{
					IDisposable disposable2 = enumerator as IDisposable;
					if (disposable2 != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		}
	}

	protected static string GetEventString(IEventExporter.EventExportNotification theNotification, Dictionary<string, long> UnitDeclarations, ref string LastPrintedTimeString, Dictionary<string, string> NewUnitCache)
	{
		_Closure$__112-0 arg = default(_Closure$__112-0);
		_Closure$__112-0 CS$<>8__locals55 = new _Closure$__112-0(arg);
		CS$<>8__locals55.$VB$Local_theNotification = theNotification;
		string result;
		try
		{
			StringBuilder theSB = StringBuilderCache.Allocate();
			TimeSpan timeSpan = TimeSpan.Parse(Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["Time"].Value));
			string text = "#" + Conversions.ToString(Math.Floor(timeSpan.TotalSeconds)) + "." + timeSpan.Milliseconds.ToString("D3");
			int num;
			if (Operators.CompareString(text, LastPrintedTimeString, false) != 0)
			{
				theSB.AppendLine().AppendLine().Append(text);
				LastPrintedTimeString = text;
				num = 0;
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (CS$<>8__locals55.$VB$Local_theNotification.EventType == IEventExporter.ExportedEventType.UnitPositions_Destruction)
			{
				CS$<>8__locals55.$VB$Local_theNotification.EventType = IEventExporter.ExportedEventType.UnitPositions;
				flag = true;
			}
			string text3;
			bool flag2;
			string text10;
			ActiveUnit activeUnit;
			UnguidedWeapon unguidedWeapon;
			long num6;
			switch (CS$<>8__locals55.$VB$Local_theNotification.EventType)
			{
			case IEventExporter.ExportedEventType.WeaponFired:
			{
				string text7 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["WeaponID"].Value);
				string text8 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["FiringUnitID"].Value);
				if (!UnitDeclarations.ContainsKey(text8))
				{
					DeclareNewUnit(text8, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache);
					theSB.Append("\r\n");
				}
				if (CS$<>8__locals55.$VB$Local_theNotification.ParentScen.ActiveUnits.ContainsKey(text7))
				{
					DeclareNewUnit(text7, _TypeOfNewObjectToDeclare.ActiveUnit, text8, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache);
				}
				else
				{
					DeclareNewUnit(text7, _TypeOfNewObjectToDeclare.UnguidedWeapon, text8, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache);
				}
				break;
			}
			case IEventExporter.ExportedEventType.WeaponEndgame:
			{
				text3 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["WeaponID"].Value);
				string text4 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["Result"].Value);
				int num3;
				if (Operators.CompareString(text4, "HIT", false) == 0)
				{
					num3 = 1;
				}
				else
				{
					if (Operators.CompareString(text4, "KILL", false) != 0)
					{
						flag2 = false;
						goto IL_0269;
					}
					num3 = 1;
				}
				flag2 = (byte)num3 != 0;
				goto IL_0269;
			}
			case IEventExporter.ExportedEventType.UnitDestroyed:
			{
				string key3 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["UnitID"].Value);
				if (!UnitDeclarations.ContainsKey(key3))
				{
					result = theSB.ToString();
				}
				else
				{
					long num10 = UnitDeclarations[key3];
					if (num10 != 0L)
					{
						theSB.AppendLine().Append("-").Append(num10);
						UnitDeclarations[key3] = 0L;
						break;
					}
					result = theSB.ToString();
				}
				goto end_IL_0011;
			}
			case IEventExporter.ExportedEventType.UnitPositions:
				text10 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["UnitID"].Value);
				activeUnit = null;
				unguidedWeapon = null;
				if (CS$<>8__locals55.$VB$Local_theNotification.ParentScen.ActiveUnits.ContainsKey(text10))
				{
					activeUnit = CS$<>8__locals55.$VB$Local_theNotification.ParentScen.ActiveUnits[text10];
					if (activeUnit != null && (!activeUnit.IsMorituri || !flag))
					{
						goto IL_0472;
					}
					result = theSB.ToString();
				}
				else
				{
					if (!CS$<>8__locals55.$VB$Local_theNotification.ParentScen.UnguidedWeapons.ContainsKey(text10))
					{
						goto IL_0472;
					}
					unguidedWeapon = CS$<>8__locals55.$VB$Local_theNotification.ParentScen.UnguidedWeapons[text10];
					if (unguidedWeapon != null)
					{
						goto IL_0472;
					}
					result = theSB.ToString();
				}
				goto end_IL_0011;
			case IEventExporter.ExportedEventType.EngagementCycle:
			{
				string text5 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["CycleAction"].Value);
				if (Operators.CompareString(text5, "Dropping contact", false) != 0)
				{
					if (!text5.StartsWith("Contact ID status changed"))
					{
						break;
					}
					string text6 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["ContactID"].Value);
					if (UnitDeclarations.TryGetValue(text6, out var value))
					{
						if (value != 0L)
						{
							Contact contact2 = null;
							Side side2 = null;
							side2 = CS$<>8__locals55.$VB$Local_theNotification.ParentScen.Sides_ReadOnly.Where([SpecialName] (Side theSide) => Operators.CompareString(theSide.Name, CS$<>8__locals55.$VB$Local_theNotification.EventParameters["UnitSide"].Value.ToString(), false) == 0).FirstOrDefault();
							if (side2 == null)
							{
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = theSB.ToString();
							}
							else
							{
								PooledList<Contact> contacts_List2 = side2.Contacts_List;
								foreach (Contact item in contacts_List2)
								{
									if (Operators.CompareString(item.ObjectID, text6, false) == 0)
									{
										contact2 = item;
										break;
									}
								}
								if (contact2 != null)
								{
									theSB.AppendLine().Append(value).Append(",");
									switch (contact2.IDStatus)
									{
									case Contact_Base.IdentificationStatus.KnownType:
										theSB.Append("Name=").Append(contact2.Name.Replace(",", "\\,"));
										if (contact2.IsSubmergedContact)
										{
											smethod_1(contact2.ActualUnit, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, theSB);
										}
										break;
									case Contact_Base.IdentificationStatus.KnownClass:
									case Contact_Base.IdentificationStatus.PreciseID:
										theSB.Append("Name=").Append(contact2.ActualUnit.UnitClass.Replace(",", "\\,")).Append(",Pilot=")
											.Append(contact2.Name.Replace(",", "\\,"));
										smethod_1(contact2.ActualUnit, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, theSB);
										break;
									}
									break;
								}
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = theSB.ToString();
							}
						}
						else
						{
							result = theSB.ToString();
						}
					}
					else
					{
						result = theSB.ToString();
					}
				}
				else
				{
					string key = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["ContactID"].Value);
					if (!UnitDeclarations.ContainsKey(key))
					{
						result = theSB.ToString();
					}
					else
					{
						long num4 = UnitDeclarations[key];
						if (num4 != 0L)
						{
							theSB.AppendLine().Append("-").Append(num4);
							UnitDeclarations[key] = 0L;
							break;
						}
						result = theSB.ToString();
					}
				}
				goto end_IL_0011;
			}
			case IEventExporter.ExportedEventType.WeaponImpact:
			{
				string text12 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["UnitID"].Value);
				if (!UnitDeclarations.ContainsKey(text12))
				{
					DeclareNewUnit(text12, _TypeOfNewObjectToDeclare.WeaponImpact, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache);
				}
				break;
			}
			case IEventExporter.ExportedEventType.Explosion:
			{
				string text11 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["ExplosionID"].Value);
				long num8 = ((!UnitDeclarations.ContainsKey(text11)) ? DeclareNewUnit(text11, _TypeOfNewObjectToDeclare.Explosion, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache) : UnitDeclarations[text11]);
				Explosion explosion2 = default(Explosion);
				for (int num9 = CS$<>8__locals55.$VB$Local_theNotification.ParentScen.Explosions.Count - 1; num9 >= 0; num9 += -1)
				{
					try
					{
						Explosion explosion = CS$<>8__locals55.$VB$Local_theNotification.ParentScen.Explosions[num9];
						if (string.CompareOrdinal(explosion.ObjectID, text11) == 0)
						{
							explosion2 = explosion;
							break;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
						break;
					}
				}
				if (explosion2 != null)
				{
					theSB.AppendLine().Append(num8).Append(",");
					PrintPositionAndAttitude(num8, explosion2, ref theSB, CS$<>8__locals55.$VB$Local_theNotification);
					theSB.Append(",Type=Misc+Explosion");
					break;
				}
				result = null;
				goto end_IL_0011;
			}
			case IEventExporter.ExportedEventType.AirOps:
			case IEventExporter.ExportedEventType.DockingOps:
			{
				string text9 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["Action"].Value);
				if (Operators.CompareString(text9, "Landing", false) != 0 && Operators.CompareString(text9, "Docking", false) != 0)
				{
					break;
				}
				string key2 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["UnitID"].Value);
				if (!UnitDeclarations.ContainsKey(key2))
				{
					result = theSB.ToString();
				}
				else
				{
					long num5 = UnitDeclarations[key2];
					if (num5 != 0L)
					{
						theSB.AppendLine().Append("-").Append(num5);
						UnitDeclarations[key2] = 0L;
						break;
					}
					result = theSB.ToString();
				}
				goto end_IL_0011;
			}
			case IEventExporter.ExportedEventType.ContactPositions:
				{
					string text2 = Conversions.ToString(CS$<>8__locals55.$VB$Local_theNotification.EventParameters["ContactID"].Value);
					long num2;
					if (!UnitDeclarations.ContainsKey(text2))
					{
						num2 = DeclareNewUnit(text2, _TypeOfNewObjectToDeclare.Contact, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache);
						break;
					}
					num2 = UnitDeclarations[text2];
					if (num2 == 0L)
					{
						result = theSB.ToString();
					}
					else
					{
						Contact contact = null;
						Side side = null;
						side = CS$<>8__locals55.$VB$Local_theNotification.ParentScen.Sides_ReadOnly.Where([SpecialName] (Side theSide) => Operators.CompareString(theSide.Name, CS$<>8__locals55.$VB$Local_theNotification.EventParameters["ObserverSide"].Value.ToString(), false) == 0).FirstOrDefault();
						if (side != null)
						{
							PooledList<Contact> contacts_List = side.Contacts_List;
							if (contacts_List != null)
							{
								foreach (Contact item2 in contacts_List)
								{
									if (Operators.CompareString(item2.ObjectID, text2, false) == 0)
									{
										contact = item2;
										break;
									}
								}
							}
							if (contact != null)
							{
								theSB.AppendLine().Append(num2).Append(",");
								PrintPositionAndAttitude(num2, contact, ref theSB, CS$<>8__locals55.$VB$Local_theNotification);
								break;
							}
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = theSB.ToString();
						}
						else
						{
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							result = theSB.ToString();
						}
					}
					goto end_IL_0011;
				}
				IL_0472:
				if (!UnitDeclarations.ContainsKey(text10))
				{
					num6 = DeclareNewUnit(text10, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache);
					break;
				}
				num6 = UnitDeclarations[text10];
				if (num6 != 0L)
				{
					theSB.AppendLine().Append(num6).Append(",");
					if (activeUnit != null)
					{
						PrintPositionAndAttitude(num6, activeUnit, ref theSB, CS$<>8__locals55.$VB$Local_theNotification);
					}
					else if (unguidedWeapon != null)
					{
						PrintPositionAndAttitude(num6, unguidedWeapon, ref theSB, CS$<>8__locals55.$VB$Local_theNotification);
					}
					break;
				}
				result = theSB.ToString();
				goto end_IL_0011;
				IL_0269:
				if (!flag2)
				{
					result = theSB.ToString();
				}
				else
				{
					long num7 = (UnitDeclarations.ContainsKey(text3) ? UnitDeclarations[text3] : ((!CS$<>8__locals55.$VB$Local_theNotification.ParentScen.ActiveUnits.ContainsKey(text3)) ? DeclareNewUnit(text3, _TypeOfNewObjectToDeclare.UnguidedWeapon, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache) : DeclareNewUnit(text3, _TypeOfNewObjectToDeclare.ActiveUnit, null, ref theSB, CS$<>8__locals55.$VB$Local_theNotification.ParentScen, UnitDeclarations, CS$<>8__locals55.$VB$Local_theNotification, NewUnitCache)));
					if (num7 != 0L)
					{
						theSB.AppendLine().Append("-").Append(num7);
						UnitDeclarations[text3] = 0L;
						break;
					}
					result = theSB.ToString();
				}
				goto end_IL_0011;
			}
			string text13 = theSB.ToString();
			StringBuilderCache.Free(theSB);
			result = text13;
			end_IL_0011:;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_2()
	{
		lock (this)
		{
			bool_14 = true;
			IEventExporter.EventExportNotification result = null;
			while (concurrentQueue_0.Count > 0)
			{
				try
				{
					concurrentQueue_0.TryDequeue(out result);
					if (result != null)
					{
						string_1 = Path.Combine(result.FileExportFolder, "Tacview2x.acmi");
						Dictionary<string, long> dictionary;
						if (concurrentDictionary_0.ContainsKey(string_1))
						{
							dictionary = concurrentDictionary_0[string_1];
						}
						else
						{
							dictionary = new Dictionary<string, long>();
							concurrentDictionary_0.TryAdd(string_1, dictionary);
						}
						StreamWriter streamWriter;
						if (!dictionary_0.ContainsKey(string_1))
						{
							method_3(string_1, result.ParentScen);
							streamWriter = File.AppendText(string_1);
							streamWriter.AutoFlush = true;
							dictionary_0.Add(string_1, streamWriter);
						}
						else
						{
							streamWriter = dictionary_0[string_1];
						}
						string eventString = GetEventString(result, dictionary, ref LastPrintedTimeString, NewUnitCache);
						if (!string.IsNullOrEmpty(eventString))
						{
							streamWriter.WriteLine(eventString);
						}
						result.EventParameters.Dispose();
						result = null;
					}
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
			bool_14 = false;
		}
	}

	private void method_3(string string_2, Scenario scenario_0)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(string_2);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Append("FileType=text/acmi/tacview").Append("\r\n");
			stringBuilder.Append("FileVersion=2.1").Append("\r\n");
			stringBuilder.Append("0,ReferenceTime=" + scenario_0.ZeroHour.ToString("yyyy-MM-ddThh:mm:ss")).Append("Z").Append("\r\n");
			File.WriteAllText(string_2, stringBuilder.ToString());
			StringBuilderCache.Free(stringBuilder);
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

	private string method_4(string string_2)
	{
		if (string.IsNullOrEmpty(string_2))
		{
			return string_2;
		}
		if (string_2.Contains(","))
		{
			string_2 = string_2.Replace(",", "\\,");
		}
		if (string_2.Contains("="))
		{
			string_2 = string_2.Replace("=", "\\=");
		}
		return string_2;
	}

	public virtual void StopCleanUpAndReset()
	{
		lock (this)
		{
			if (!Information.IsNothing((object)thread_0))
			{
				thread_0.Abort();
				thread_0 = null;
			}
			concurrentQueue_0 = new ConcurrentQueue<IEventExporter.EventExportNotification>();
			concurrentDictionary_0.Clear();
			foreach (StreamWriter value in dictionary_0.Values)
			{
				if (!Information.IsNothing((object)value))
				{
					value.Flush();
					value.Close();
					value.Dispose();
					StreamWriter current = null;
				}
			}
			dictionary_0.Clear();
			bool_14 = false;
		}
	}

	public void Shutdown()
	{
	}

	public virtual void SetScenario(Scenario theScen)
	{
		int num = theScen.ActiveUnits_List.Count - 1;
		for (int i = 0; i <= num; i++)
		{
			if (!theScen.ActiveUnits_List.ElementAt(i).IsGroup)
			{
				theScen.ActiveUnits_List.ElementAt(i).Kinematics.ExportLocationEvent("SetScenario");
			}
		}
	}

	public void SetOutputRate(IEventExporter.ExportedEventType theEventType, IEventExporter.EventExportOutputRate theRate)
	{
	}

	public bool ShouldOutputNow(IEventExporter.ExportedEventType theEventType, Scenario theScen)
	{
		return true;
	}
}
