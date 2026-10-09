using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Collections.Pooled;
using Command_Core.DAL;
using DotSpatial.Topology;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Spatial.Euclidean;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ThreadSafeCollections;

namespace Command_Core;

public class ActiveUnit_Sensory
{
	public delegate void NewContactDetectedEventHandler(Side DetectingSide, Contact_Base.ContactType ContactType);

	public enum SensoryType
	{
		None,
		Radar,
		ESM,
		Visual,
		IR,
		Sonar_Active,
		Sonar_Passive,
		Magnetic,
		Laser
	}

	public enum SpecialDetectionMode
	{
		None,
		SubAssumedFromTorpedoDetection,
		SubAssumedFromMissileDetection,
		FlamingDatum,
		AutoDetection,
		MissileAssumedFromSemiActiveIllumination,
		LuaScript,
		CounterBatteryTrack,
		ContactSharing
	}

	public class EligibleContactEntry
	{
		public ActiveUnit ActiveUnit;

		public Sensor[] SensorList;

		public EligibleContactEntry(ref ActiveUnit theActiveUnit, ref Sensor[] theSensorList)
		{
			ActiveUnit = theActiveUnit;
			SensorList = theSensorList;
		}

		static EligibleContactEntry()
		{
			Class72.smethod_20();
		}
	}

	public class GClass6
	{
		public UnguidedWeapon NonAU_Weapon;

		public Sensor[] SensorList;

		public GClass6(ref UnguidedWeapon theActiveUnit, ref Sensor[] theSensorList)
		{
			NonAU_Weapon = theActiveUnit;
			SensorList = theSensorList;
		}

		static GClass6()
		{
			Class72.smethod_20();
		}
	}

	public class ContactEntry_Local : ScenarioObject
	{
		public float TimeSinceDetection;

		public float? TimeSinceDetection_Radar;

		public float? TimeSinceDetection_ESM;

		public float? TimeSinceDetection_Visual;

		public float? TimeSinceDetection_Infrared;

		public float? TimeSinceDetection_SonarActive;

		public float? TimeSinceDetection_SonarPassive;

		public Contact Contact;

		public float NoDetectionCount;

		public void ToXML(ref XmlWriter theWriter, Side theSide)
		{
			try
			{
				if (!Information.IsNothing((object)Contact) && theSide.Contacts.ContainsKey(Contact.ActualUnit.ObjectID))
				{
					theWriter.WriteStartElement("ContactEntry");
					theWriter.WriteElementString("Contact", Contact.ActualUnit.ObjectID);
					theWriter.WriteElementString("TSD", TimeSinceDetection.ToString());
					if (!Information.IsNothing((object)TimeSinceDetection_Radar))
					{
						theWriter.WriteElementString("TSD_Radar", TimeSinceDetection_Radar.ToString());
					}
					if (!Information.IsNothing((object)TimeSinceDetection_ESM))
					{
						theWriter.WriteElementString("TSD_ESM", TimeSinceDetection_ESM.ToString());
					}
					if (!Information.IsNothing((object)TimeSinceDetection_Visual))
					{
						theWriter.WriteElementString("TSD_Visual", TimeSinceDetection_Visual.ToString());
					}
					if (!Information.IsNothing((object)TimeSinceDetection_Infrared))
					{
						theWriter.WriteElementString("TSD_Infrared", TimeSinceDetection_Infrared.ToString());
					}
					if (!Information.IsNothing((object)TimeSinceDetection_SonarActive))
					{
						theWriter.WriteElementString("TSD_SonarActive", TimeSinceDetection_SonarActive.ToString());
					}
					if (!Information.IsNothing((object)TimeSinceDetection_SonarPassive))
					{
						theWriter.WriteElementString("TSD_SonarPassive", TimeSinceDetection_SonarPassive.ToString());
					}
					theWriter.WriteElementString("NDC", NoDetectionCount.ToString());
					theWriter.WriteEndElement();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101217", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}

		public static ContactEntry_Local FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref string theObjectID)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			ContactEntry_Local result;
			try
			{
				ContactEntry_Local contactEntry_Local = new ContactEntry_Local();
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "TSD_Visual":
					case "TimeSinceDetection_Visual":
						contactEntry_Local.TimeSinceDetection_Visual = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "TimeSinceDetection":
					case "TSD":
						contactEntry_Local.TimeSinceDetection = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "NoDetectionCount":
					case "NDC":
						contactEntry_Local.NoDetectionCount = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "Contact":
						contactEntry_Local.Contact = null;
						theObjectID = val.InnerText;
						break;
					case "TimeSinceDetection_Radar":
					case "TSD_Radar":
						contactEntry_Local.TimeSinceDetection_Radar = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "TSD_SonarPassive":
					case "TimeSinceDetection_SonarPassive":
						contactEntry_Local.TimeSinceDetection_SonarPassive = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "TimeSinceDetection_Infrared":
					case "TSD_Infrared":
						contactEntry_Local.TimeSinceDetection_Infrared = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "TSD_SonarActive":
					case "TimeSinceDetection_SonarActive":
						contactEntry_Local.TimeSinceDetection_SonarActive = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					case "TimeSinceDetection_ESM":
					case "TSD_ESM":
						contactEntry_Local.TimeSinceDetection_ESM = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
						break;
					}
				}
				result = contactEntry_Local;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101218", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new ContactEntry_Local();
				ProjectData.ClearProjectError();
			}
			return result;
		}

		public ContactEntry_Local()
		{
			TimeSinceDetection = 0f;
			NoDetectionCount = 0f;
		}

		static ContactEntry_Local()
		{
			Class72.smethod_20();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure$__166-0
	{
		public float $VB$Local_elapsedTime;

		public ActiveUnit_Sensory $VB$Me;

		public _Closure$__166-0(_Closure$__166-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_elapsedTime = arg0.$VB$Local_elapsedTime;
			}
		}

		[SpecialName]
		internal void _Lambda$__0(Contact theC)
		{
			theC?.PostPulseHousekeeping($VB$Local_elapsedTime, $VB$Me.myUnit.get_UnitSide(SetSideOnly: false), $VB$Me.myUnit.ParentScen, IsPrivateContact: true);
		}

		static _Closure$__166-0()
		{
			Class72.smethod_20();
		}
	}

	internal ActiveUnit myUnit;

	protected bool _ObeysEMCON;

	private bool bool_0;

	internal ConcurrentQueue<(Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>)> SuccessfulDetectionsOnThisPulse;

	internal ConcurrentQueue<string> SuccessfulNonAUDetectionsOnThisPulse;

	private List<Contact> list_0;

	internal TDictionary<long, LoggedMessage> BDAChangeNotices;

	public TDictionary<string, Contact> NewContactsQueue_Local;

	public TDictionary<string, Contact> DroppedContactsQueue_Local;

	public bool HadActiveSensorInLastPulse;

	protected Dictionary<string, Contact> _ContactsList_OffGrid;

	protected List<string> _ContactsList_OffGrid_NonAU;

	private Dictionary<bool, List<ActiveUnit>> dictionary_0;

	internal ActiveEmissionInterval IntermittentEmission;

	[CompilerGenerated]
	private static NewContactDetectedEventHandler newContactDetectedEventHandler_0;

	private TObservableDictionary<string, Contact> tobservableDictionary_0;

	[AccessedThroughProperty("__ContactsList_Local")]
	[CompilerGenerated]
	private TObservableDictionary<string, ContactEntry_Local> tobservableDictionary_1;

	[CompilerGenerated]
	private JammingInfo jammingInfo_0;

	private PooledList<Contact> pooledList_0;

	private LockObject lockObject_0;

	private PooledList<ActiveUnit> pooledList_1;

	private PooledList<EligibleContactEntry> pooledList_2;

	private PooledList<EligibleContactEntry> pooledList_3;

	private PooledList<EligibleContactEntry> pooledList_4;

	private PooledList<EligibleContactEntry> pooledList_5;

	private PooledList<ActiveUnit> pooledList_6;

	private PooledList<ActiveUnit> pooledList_7;

	[ThreadStatic]
	private Sensor[] sensor_0;

	public TDictionary<string, P2PContacSnaphot> tdictionary_0;

	private ConcurrentBag<TransmissionWithFeedback> concurrentBag_0;

	public TObservableDictionary<string, Contact> Contacts_Local
	{
		get
		{
			if (tobservableDictionary_0 == null)
			{
				tobservableDictionary_0 = new TObservableDictionary<string, Contact>();
			}
			return tobservableDictionary_0;
		}
		set
		{
			tobservableDictionary_0 = value;
		}
	}

	protected TObservableDictionary<string, ContactEntry_Local> _ContactsList_Local
	{
		get
		{
			if (vmethod_0() == null)
			{
				vmethod_1(new TObservableDictionary<string, ContactEntry_Local>());
			}
			return vmethod_0();
		}
	}

	public JammingInfo JammingInfo
	{
		[CompilerGenerated]
		get
		{
			return jammingInfo_0;
		}
		[CompilerGenerated]
		set
		{
			jammingInfo_0 = value;
		}
	}

	public virtual bool ObeysEMCON
	{
		get
		{
			return _ObeysEMCON;
		}
		set
		{
			_ObeysEMCON = value;
			if (value)
			{
				vmethod_2(myUnit.Sensors_Cached);
			}
		}
	}

	public bool HasOperationalTowedArray
	{
		get
		{
			bool result;
			try
			{
				Sensor[] sensors_Cached = myUnit.Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						Sensor sensor = sensors_Cached[num];
						if (sensor.Status != PlatformComponent._ComponentStatus.Operational || !sensor.IsTowedArray)
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						break;
					}
					result = false;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100236", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasEyeballOperating
	{
		get
		{
			bool result;
			try
			{
				Sensor[] sensors_Cached = myUnit.Sensors_Cached;
				int num = 0;
				while (true)
				{
					if (num < sensors_Cached.Length)
					{
						Sensor sensor = sensors_Cached[num];
						bool? flag = sensor?.IsMk1Eyeball;
						if (!(flag ?? true) || sensor == null || !sensor.IsOperating || !flag.HasValue)
						{
							num = checked(num + 1);
							continue;
						}
						result = true;
						break;
					}
					result = false;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 1002384", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasSensorsOperating
	{
		get
		{
			bool result;
			try
			{
				if (Information.IsNothing((object)SensorsList))
				{
					SensorsList = myUnit.Sensors_Cached;
				}
				if (SensorsList.Length != 0)
				{
					Sensor[] array = SensorsList;
					int num = 0;
					while (true)
					{
						if (num < array.Length)
						{
							Sensor sensor = array[num];
							if (sensor == null || !sensor.IsOperating)
							{
								num = checked(num + 1);
								continue;
							}
							result = true;
							break;
						}
						result = false;
						break;
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
				ex2?.Data.Add("Error at 100238", "");
				GameGeneral.WriteExceptionsToLog(ex2);
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
	}

	public bool JammerUnitsAreAffectingMe
	{
		get
		{
			bool result;
			try
			{
				if (myUnit?.ParentScen != null)
				{
					bool value;
					if (myUnit.IsSatellite)
					{
						result = false;
					}
					else if (myUnit.IsSubmarine && Math.Round(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < -20.0)
					{
						result = false;
					}
					else if (!myUnit.ParentScen.Cache_UnitsAffectedByJamming.TryGetValue(myUnit, out value))
					{
						new HashSet<ActiveUnit>();
						Sensor[] sensors_Cached = myUnit.Sensors_Cached;
						if (sensors_Cached == null)
						{
							myUnit.ParentScen.Cache_UnitsAffectedByJamming.TryAdd(myUnit, value: false);
							result = false;
						}
						else
						{
							bool flag = false;
							Sensor sensor = null;
							int num = sensors_Cached.Length - 1;
							for (int i = 0; i <= num; i++)
							{
								sensor = sensors_Cached[i];
								if (sensor != null && sensor.Type == Sensor.Sensor_Type.Radar && sensor.IsActive())
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								myUnit.ParentScen.Cache_UnitsAffectedByJamming.TryAdd(myUnit, value: false);
								result = false;
							}
							else
							{
								Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
								int num2 = 0;
								while (true)
								{
									if (num2 < sides_ReadOnly.Length)
									{
										Side side = sides_ReadOnly[num2];
										if (side != myUnit.get_UnitSide(SetSideOnly: false) && !Module_Side.IsAlliedWithThisSide(myUnit.get_UnitSide(SetSideOnly: false), side))
										{
											List<ActiveUnit> list = side.get_Item(Refresh: false);
											if (list != null)
											{
												for (int j = list.Count - 1; j >= 0; j += -1)
												{
													ActiveUnit activeUnit_;
													try
													{
														activeUnit_ = list[j];
													}
													catch (Exception ex)
													{
														ProjectData.SetProjectError(ex);
														Exception ex2 = ex;
														ex2?.Data.Add("Error at 200432", ex2.Message);
														GameGeneral.WriteExceptionsToLog(ex2);
														if (Debugger.IsAttached)
														{
															Debugger.Break();
														}
														ProjectData.ClearProjectError();
														continue;
													}
													if (method_2(activeUnit_))
													{
														myUnit.ParentScen.Cache_UnitsAffectedByJamming.TryAdd(myUnit, value: true);
														result = true;
														goto end_IL_01f1;
													}
												}
											}
										}
										num2 = checked(num2 + 1);
										continue;
									}
									myUnit.ParentScen.Cache_UnitsAffectedByJamming.TryAdd(myUnit, value: false);
									result = false;
									break;
									continue;
									end_IL_01f1:
									break;
								}
							}
						}
					}
					else
					{
						result = value;
					}
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
				ex4?.Data.Add("Error at 100239", "");
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
	}

	public List<ActiveUnit> JammerUnitsAffectingMe
	{
		get
		{
			List<ActiveUnit> result;
			try
			{
				HashSet<ActiveUnit> hashSet;
				List<ActiveUnit> list;
				if (myUnit.IsWeapon && ((Weapon)myUnit).Flags.HomeOnJam)
				{
					result = new List<ActiveUnit>();
				}
				else if (!dictionary_0.ContainsKey(FactorHavingActiveRadars))
				{
					hashSet = new HashSet<ActiveUnit>();
					list = new List<ActiveUnit>();
					if (!FactorHavingActiveRadars)
					{
						goto IL_0108;
					}
					Sensor[] sensors_Cached = myUnit.Sensors_Cached;
					bool flag = false;
					Sensor sensor = null;
					int num = sensors_Cached.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						sensor = sensors_Cached[i];
						if (sensor.Type == Sensor.Sensor_Type.Radar && sensor.IsActive())
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						goto IL_0108;
					}
					list = hashSet.ToList();
					try
					{
						dictionary_0.Add(FactorHavingActiveRadars, list);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200433", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					result = list;
				}
				else
				{
					result = dictionary_0[FactorHavingActiveRadars];
				}
				goto end_IL_0001;
				IL_0108:
				Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (side == null || myUnit.get_UnitSide(SetSideOnly: false) == null || side == myUnit.get_UnitSide(SetSideOnly: false) || Module_Side.IsAlliedWithThisSide(myUnit.get_UnitSide(SetSideOnly: false), side))
					{
						continue;
					}
					for (int k = side.get_Item(Refresh: false).Count - 1; k >= 0; k += -1)
					{
						ActiveUnit activeUnit = side.get_Item(Refresh: false)[k];
						if (!activeUnit.IsGroup && method_2(activeUnit))
						{
							hashSet.Add(activeUnit);
						}
					}
				}
				list = hashSet.ToList();
				try
				{
					lock (lockObject_0)
					{
						if (!dictionary_0.ContainsKey(FactorHavingActiveRadars))
						{
							dictionary_0.Add(FactorHavingActiveRadars, list);
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ex4?.Data.Add("Error at 200434", ex4.Message);
					GameGeneral.WriteExceptionsToLog(ex4);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				result = list;
				end_IL_0001:;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 100240", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = new List<ActiveUnit>();
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public bool HasAvailableDippingSonar
	{
		get
		{
			bool result;
			try
			{
				if (myUnit.IsAircraft && ((Aircraft)myUnit).Kinematics.GetMinimumSpeed(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), ActiveUnit.Throttle.Loiter, ValidateAndFixAltitude: true) > 0)
				{
					result = false;
				}
				else
				{
					Sensor[] sensors_Cached = myUnit.Sensors_Cached;
					int num = 0;
					while (true)
					{
						if (num < sensors_Cached.Length)
						{
							Sensor sensor = sensors_Cached[num];
							if (!sensor.IsDippingSonar || sensor.Status != PlatformComponent._ComponentStatus.Operational)
							{
								num = checked(num + 1);
								continue;
							}
							result = true;
							break;
						}
						result = false;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100267", "");
				GameGeneral.WriteExceptionsToLog(ex2);
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
	}

	public TObservableDictionary<string, Contact> Contacts_Local_ReadOnly
	{
		get
		{
			TObservableDictionary<string, Contact> result;
			try
			{
				if (Contacts_Local == null)
				{
					Contacts_Local = new TObservableDictionary<string, Contact>();
				}
				if (Contacts_Local.Count == 0 && _ContactsList_Local != null && _ContactsList_Local.Count > 0)
				{
					ObservableDictionary<string, Contact> observableDictionary = new ObservableDictionary<string, Contact>();
					foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
					{
						if (item.Value != null && item.Value.Contact != null)
						{
							observableDictionary.Add(item.Key, item.Value.Contact);
						}
						else if (DroppedContactsQueue_Local != null)
						{
							DroppedContactsQueue_Local.AddIfNotExistsElseUpdate(item.Key, null);
						}
					}
					Contacts_Local = new TObservableDictionary<string, Contact>(observableDictionary, useReadLock: false);
				}
				result = Contacts_Local;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 101216", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				int useReadLock;
				if (!Debugger.IsAttached)
				{
					useReadLock = 0;
				}
				else
				{
					Debugger.Break();
					useReadLock = 0;
				}
				result = new TObservableDictionary<string, Contact>((byte)useReadLock != 0);
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static event NewContactDetectedEventHandler NewContactDetected
	{
		[CompilerGenerated]
		add
		{
			NewContactDetectedEventHandler newContactDetectedEventHandler = newContactDetectedEventHandler_0;
			NewContactDetectedEventHandler newContactDetectedEventHandler2;
			do
			{
				newContactDetectedEventHandler2 = newContactDetectedEventHandler;
				NewContactDetectedEventHandler value2 = (NewContactDetectedEventHandler)Delegate.Combine(newContactDetectedEventHandler2, value);
				newContactDetectedEventHandler = Interlocked.CompareExchange(ref newContactDetectedEventHandler_0, value2, newContactDetectedEventHandler2);
			}
			while ((object)newContactDetectedEventHandler != newContactDetectedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			NewContactDetectedEventHandler newContactDetectedEventHandler = newContactDetectedEventHandler_0;
			NewContactDetectedEventHandler newContactDetectedEventHandler2;
			do
			{
				newContactDetectedEventHandler2 = newContactDetectedEventHandler;
				NewContactDetectedEventHandler value2 = (NewContactDetectedEventHandler)Delegate.Remove(newContactDetectedEventHandler2, value);
				newContactDetectedEventHandler = Interlocked.CompareExchange(ref newContactDetectedEventHandler_0, value2, newContactDetectedEventHandler2);
			}
			while ((object)newContactDetectedEventHandler != newContactDetectedEventHandler2);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual TObservableDictionary<string, ContactEntry_Local> vmethod_0()
	{
		return tobservableDictionary_1;
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual void vmethod_1(TObservableDictionary<string, ContactEntry_Local> WithEventsValue)
	{
		NotifyCollectionChangedEventHandler value = method_32;
		TObservableDictionary<string, ContactEntry_Local> tObservableDictionary = tobservableDictionary_1;
		if (tObservableDictionary != null)
		{
			tObservableDictionary.CollectionChanged -= value;
		}
		tobservableDictionary_1 = WithEventsValue;
		tObservableDictionary = tobservableDictionary_1;
		if (tObservableDictionary != null)
		{
			tObservableDictionary.CollectionChanged += value;
		}
	}

	public virtual void ToXML(ref XmlWriter theWriter)
	{
		try
		{
			theWriter.WriteStartElement("Sensory");
			theWriter.WriteElementString("ObE", _ObeysEMCON.ToString());
			if (_ContactsList_Local.Count > 0)
			{
				theWriter.WriteStartElement("ContactList_Local");
				try
				{
					List<ContactEntry_Local> list = _ContactsList_Local.Values.ToList();
					foreach (ContactEntry_Local item in list)
					{
						if (!Information.IsNothing((object)item.Contact) && !Information.IsNothing((object)item.Contact.ActualUnit))
						{
							item.ToXML(ref theWriter, myUnit.get_UnitSide(SetSideOnly: false));
						}
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
				finally
				{
					theWriter.WriteEndElement();
				}
			}
			if (_ContactsList_OffGrid.Count > 0)
			{
				theWriter.WriteStartElement("ContactList_OffGrid");
				List<Contact> list2 = _ContactsList_OffGrid.Values.ToList();
				foreach (Contact item2 in list2)
				{
					if (item2.ActualUnit != null)
					{
						theWriter.WriteRaw(item2.ToXML(null, myUnit.get_UnitSide(SetSideOnly: false)));
					}
				}
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)IntermittentEmission))
			{
				IntermittentEmission.ToXML(ref theWriter);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100234", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			theWriter.WriteEndElement();
		}
	}

	public static ActiveUnit_Sensory FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref ActiveUnit theAU)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		ActiveUnit_Sensory result;
		try
		{
			ActiveUnit_Sensory activeUnit_Sensory = new ActiveUnit_Sensory();
			activeUnit_Sensory.myUnit = theAU;
			string theObjectID = default(string);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "EmissionInterval":
					activeUnit_Sensory.IntermittentEmission = ActiveEmissionInterval.FromXML(ref theNode2);
					activeUnit_Sensory.IntermittentEmission?.Initialize(activeUnit_Sensory);
					break;
				case "ContactList_OffGrid":
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode4 = childNode2;
						Contact contact = Contact.FromXML(ref theNode4, ref theDictionary);
						activeUnit_Sensory._ContactsList_OffGrid.Add(contact._ActualUnitID, contact);
					}
					break;
				case "ContactList":
				case "ContactList_Local":
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode3;
						ContactEntry_Local value = ContactEntry_Local.FromXML(ref theNode3, ref theDictionary, ref theObjectID);
						if (!Information.IsNothing((object)theObjectID) && !activeUnit_Sensory._ContactsList_Local.ContainsKey(theObjectID))
						{
							activeUnit_Sensory._ContactsList_Local.Add(theObjectID, value);
						}
					}
					break;
				case "ObeysEMCON":
				case "ObE":
					activeUnit_Sensory._ObeysEMCON = Misc.ParseBool(theNode2.InnerText);
					break;
				}
			}
			result = activeUnit_Sensory;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100235", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new ActiveUnit_Sensory();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal ActiveUnit GetParentUnit()
	{
		return myUnit;
	}

	internal bool CanTrackThisContact_AAWFireControlGrade(Contact theContact, bool ignoreOperatingState = false, bool ignoreTrackingState = false)
	{
		if (theContact == null)
		{
			return false;
		}
		Sensor[] sensors_Cached = myUnit.Sensors_Cached;
		float targetSlantRange = Module_Unit.RangeToUnit_Slant(myUnit, theContact?.ActualUnit, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
		Sensor[] array = sensors_Cached;
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				Sensor sensor = array[num];
				if (sensor != null && sensor.get_CanTrackThisContact_AAWFireControlGrade(theContact, targetSlantRange, ignoreOperatingState, ignoreTrackingState))
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return false;
		}
		return true;
	}

	internal bool HasLocalTrackOnThisContact(Contact theContact, float ContactLocalAgeThreshold_sec, Sensor.Sensor_Type SpecificSensorType)
	{
		if (theContact.IsAutoDetection)
		{
			return true;
		}
		if (_ContactsList_Local.Count != 0)
		{
			LockedDictionary<(ActiveUnit, Contact, float, Sensor.Sensor_Type), bool> cache_UnitLocalTracksOnContacts = myUnit.ParentScen.Cache_UnitLocalTracksOnContacts;
			(ActiveUnit, Contact, float, Sensor.Sensor_Type) key = (myUnit, theContact, ContactLocalAgeThreshold_sec, SpecificSensorType);
			bool value = default(bool);
			if (cache_UnitLocalTracksOnContacts.TryGetValue(key, ref value))
			{
				return value;
			}
			foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
			{
				ContactEntry_Local value2 = item.Value;
				try
				{
					if (value2 == null || value2.Contact == null || !ContactsAreOfSameActualUnit(value2.Contact, theContact))
					{
						continue;
					}
					switch (SpecificSensorType)
					{
					case Sensor.Sensor_Type.ESM:
						if (value2.TimeSinceDetection_ESM.HasValue)
						{
							float? timeSinceDetection_SonarPassive = value2.TimeSinceDetection_ESM;
							if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= ContactLocalAgeThreshold_sec) : ((bool?)null)) == true)
							{
								value = true;
								cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
								return true;
							}
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						return false;
					case Sensor.Sensor_Type.Radar:
					case Sensor.Sensor_Type.SemiActive:
						if (value2.TimeSinceDetection_Radar.HasValue)
						{
							float? timeSinceDetection_SonarPassive = value2.TimeSinceDetection_Radar;
							if (((!timeSinceDetection_SonarPassive.HasValue) ? ((bool?)null) : new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= ContactLocalAgeThreshold_sec)) == true)
							{
								value = true;
								cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
								return true;
							}
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						value = false;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
						return false;
					case Sensor.Sensor_Type.Visual:
					{
						if (!value2.TimeSinceDetection_Visual.HasValue)
						{
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						float? timeSinceDetection_SonarPassive = value2.TimeSinceDetection_Visual;
						if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= ContactLocalAgeThreshold_sec) : ((bool?)null)) != true)
						{
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						value = true;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
						return true;
					}
					case Sensor.Sensor_Type.Infrared:
					{
						if (!value2.TimeSinceDetection_Infrared.HasValue)
						{
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						float? timeSinceDetection_SonarPassive = value2.TimeSinceDetection_Infrared;
						if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= ContactLocalAgeThreshold_sec) : ((bool?)null)) != true)
						{
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						value = true;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
						return true;
					}
					case Sensor.Sensor_Type.None:
						if (value2.TimeSinceDetection <= ContactLocalAgeThreshold_sec)
						{
							value = true;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
							return true;
						}
						value = false;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
						return false;
					case Sensor.Sensor_Type.HullSonar_ActivePassive:
					case Sensor.Sensor_Type.HullSonar_ActiveOnly:
					case Sensor.Sensor_Type.TowedArray_ActivePassive:
					case Sensor.Sensor_Type.TowedArray_ActiveOnly:
					case Sensor.Sensor_Type.VDS_ActivePassive:
					case Sensor.Sensor_Type.VDS_ActiveOnly:
					case Sensor.Sensor_Type.DippingSonar_ActivePassive:
					case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
						if (value2.TimeSinceDetection_SonarActive.HasValue)
						{
							float? timeSinceDetection_SonarPassive = value2.TimeSinceDetection_SonarActive;
							if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= ContactLocalAgeThreshold_sec) : ((bool?)null)) != true)
							{
								value = false;
								cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
								return false;
							}
							value = true;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
							return true;
						}
						value = false;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
						return false;
					default:
						if (Debugger.IsAttached)
						{
							Debugger.Break();
							break;
						}
						value = false;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
						return false;
					case Sensor.Sensor_Type.LaserDesignator:
					case Sensor.Sensor_Type.LaserSpotTracker:
					case Sensor.Sensor_Type.LaserRangefinder:
					case Sensor.Sensor_Type.PingIntercept:
						value = false;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
						return false;
					case Sensor.Sensor_Type.HullSonar_PassiveOnly:
					case Sensor.Sensor_Type.TowedArray_PassiveOnly:
					case Sensor.Sensor_Type.VDS_PassiveOnly:
					case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
					case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
					{
						if (!value2.TimeSinceDetection_SonarPassive.HasValue)
						{
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						float? timeSinceDetection_SonarPassive = value2.TimeSinceDetection_SonarPassive;
						if ((timeSinceDetection_SonarPassive.HasValue ? new bool?(timeSinceDetection_SonarPassive.GetValueOrDefault() <= ContactLocalAgeThreshold_sec) : ((bool?)null)) != true)
						{
							value = false;
							cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
							return false;
						}
						value = true;
						cache_UnitLocalTracksOnContacts.TryAdd(key, value: true);
						return true;
					}
					}
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
			value = false;
			cache_UnitLocalTracksOnContacts.TryAdd(key, value: false);
			return false;
		}
		return false;
	}

	private ActiveUnit_Sensory()
	{
		list_0 = new List<Contact>();
		BDAChangeNotices = new TDictionary<long, LoggedMessage>();
		NewContactsQueue_Local = new TDictionary<string, Contact>(StringComparer.Ordinal);
		DroppedContactsQueue_Local = new TDictionary<string, Contact>(StringComparer.Ordinal);
		HadActiveSensorInLastPulse = false;
		_ContactsList_OffGrid = new Dictionary<string, Contact>();
		_ContactsList_OffGrid_NonAU = new List<string>();
		dictionary_0 = new Dictionary<bool, List<ActiveUnit>>();
		JammingInfo = new JammingInfo();
		lockObject_0 = new LockObject();
		pooledList_1 = new PooledList<ActiveUnit>();
		tdictionary_0 = new TDictionary<string, P2PContacSnaphot>();
		concurrentBag_0 = new ConcurrentBag<TransmissionWithFeedback>();
	}

	internal void ClearLocalContacts()
	{
		_ContactsList_Local.Clear();
	}

	internal void MakeLocalCopiesOfSideAutodetectables()
	{
		if (myUnit.get_UnitSide(SetSideOnly: false) == null)
		{
			return;
		}
		foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
		{
			if (!Information.IsNothing((object)contacts_.ActualUnit))
			{
				Contact contact = contacts_.Clone();
				contact.RemainingContinousTrackTime = 0f;
				contact.RemainingContinousTrackTime_Precise = 0f;
				_ContactsList_OffGrid.Add(contact.ActualUnit.ObjectID, contact);
			}
		}
	}

	public void RejoinCommsGrid()
	{
		myUnit.AddMessage(myUnit.Name + " has rejoined the communications network.", myUnit.Name + " has reestablished comms", LoggedMessage.MessageType.CommsRelatedMessage, 0, new Geopoint_Struct(myUnit.get_Longitude((GlobalVariables.BooleanObject)null), myUnit.get_Latitude((GlobalVariables.BooleanObject)null)));
		foreach (KeyValuePair<string, Contact> item in _ContactsList_OffGrid)
		{
			if (item.Value.ActualUnit != null)
			{
				if (!Information.IsNothing((object)item.Value.ActualUnit.get_UnitSide(SetSideOnly: false)))
				{
					Side side = item.Value.ActualUnit.get_UnitSide(SetSideOnly: false);
					if (side == myUnit.get_UnitSide(SetSideOnly: false))
					{
						myUnit.AI.DropTarget(item.Value);
					}
					else if (side.get_ConsidersThisSideToBe(myUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) == Misc.PostureStance.Friendly)
					{
						myUnit.AI.DropTarget(item.Value);
					}
					else if (myUnit.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(item.Key))
					{
						_ = myUnit.get_UnitSide(SetSideOnly: false).Contacts[item.Key];
						Module_Side.UpdateMasterContactDataFromOtherContact(myUnit.get_UnitSide(SetSideOnly: false), myUnit.get_UnitSide(SetSideOnly: false).Contacts[item.Key], item.Value, myUnit, myUnit.ParentScen, RefineAoU: true);
					}
					else
					{
						myUnit.AddMessage("NEW DELAYED CONTACT: " + item.Value.Name, "Contact report", LoggedMessage.MessageType.ContactChange, 0, new Geopoint_Struct(((Module_Unit.Unit)item.Value).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)item.Value).get_Latitude((GlobalVariables.BooleanObject)null)));
						myUnit.get_UnitSide(SetSideOnly: false).AddContact(item.Value);
						item.Value.set_IsPrivate(myUnit.get_UnitSide(SetSideOnly: false), value: false);
					}
				}
				else
				{
					myUnit.AI.DropTarget(item.Value);
				}
			}
			else
			{
				myUnit.AI.DropTarget(item.Value);
			}
		}
		_ContactsList_OffGrid.Clear();
		List<Contact> list = new List<Contact>();
		foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
		{
			if (!Information.IsNothing((object)contacts_.ActualUnit) && contacts_.ActualUnit == myUnit)
			{
				list.Add(contacts_);
			}
		}
		foreach (Contact item2 in list)
		{
			myUnit.get_UnitSide(SetSideOnly: false).DropContact(item2, ref myUnit.ParentScen, LogMessage: false);
		}
	}

	public PooledList<Contact> PrivateContactList()
	{
		if (_ContactsList_OffGrid.Count == 0)
		{
			if (pooledList_0 != null)
			{
				pooledList_0.Clear();
			}
			else
			{
				pooledList_0 = new PooledList<Contact>();
			}
			return pooledList_0;
		}
		pooledList_0 = new PooledList<Contact>(_ContactsList_OffGrid.Values);
		return pooledList_0;
	}

	private void method_0()
	{
		if (this.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: true).Count > 0 != bool_0)
		{
			if (!bool_0)
			{
				bool_0 = true;
			}
			else
			{
				bool_0 = false;
			}
		}
	}

	public bool ActivateToObtainTrack_AAWFireControlGrade(Contact theTarget)
	{
		bool result = false;
		if (theTarget != null)
		{
			List<Sensor> list = myUnit.Sensors_Cached.ToList();
			float targetSlantRange = Module_Unit.RangeToUnit_Slant(myUnit, theTarget, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
			foreach (Sensor item in list)
			{
				if (item.CanBeActive && !item.IsActive() && item.get_CanTrackThisContact_AAWFireControlGrade(theTarget, targetSlantRange, ignoreOperatingState: true, ignoreTrackingState: true))
				{
					item.GoActive();
					result = true;
				}
			}
		}
		return result;
	}

	public void ActivateSensorsToHelpDatalinkedOrSemiActiveGuidedWeapons(Sensor[] SensorsList)
	{
		ActiveUnit_Weaponry.DatalinkedWeaponsInAirByTrackState dataLinkeGuidedWeaponsInAirThatNeedTrack = myUnit.Weaponry.getDataLinkeGuidedWeaponsInAirThatNeedTrack();
		if (dataLinkeGuidedWeaponsInAirThatNeedTrack.thatNeedTrack.Count > 0 || dataLinkeGuidedWeaponsInAirThatNeedTrack.thatHaveTrack.Count > 0)
		{
			foreach (Sensor sensor in SensorsList)
			{
				if (!sensor.CanBeActive)
				{
					continue;
				}
				if (!sensor.IsActive())
				{
					foreach (Weapon item in dataLinkeGuidedWeaponsInAirThatNeedTrack.thatNeedTrack)
					{
						if (sensor.TargetIsWithinCoverageArc(item.AI.PrimaryTarget))
						{
							float targetSlantRange = Module_Unit.RangeToUnit_Slant(myUnit, item.AI.PrimaryTarget, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
							if (sensor.get_CanTrackThisContact_AAWFireControlGrade(item.AI.PrimaryTarget, targetSlantRange, ignoreOperatingState: true, ignoreTrackingState: true))
							{
								sensor.GoActive();
								break;
							}
						}
					}
				}
				if (sensor.IsActive())
				{
					continue;
				}
				foreach (Weapon item2 in dataLinkeGuidedWeaponsInAirThatNeedTrack.thatHaveTrack)
				{
					float num = -1f;
					foreach (Contact.Detection_Struct lastDetection in item2.AI.PrimaryTarget.LastDetections)
					{
						if (Operators.CompareString(lastDetection.DetectingSensorID, sensor.ObjectID, false) == 0)
						{
							if (num == -1f)
							{
								num = Module_Unit.RangeToUnit_Slant(myUnit, item2.AI.PrimaryTarget, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue);
							}
							if (sensor.get_CanTrackThisContact_AAWFireControlGrade(item2.AI.PrimaryTarget, num, ignoreOperatingState: true, ignoreTrackingState: true) && sensor.TargetIsWithinCoverageArc(item2.AI.PrimaryTarget))
							{
								sensor.GoActive();
								break;
							}
						}
					}
				}
			}
		}
		List<Weapon> semiActiveGuidedWeaponsInAir = myUnit.Weaponry.getSemiActiveGuidedWeaponsInAir();
		if (semiActiveGuidedWeaponsInAir.Count > 0)
		{
			foreach (Sensor sensor2 in SensorsList)
			{
				if (!sensor2.CanBeActive || sensor2.IsActive())
				{
					continue;
				}
				foreach (Weapon item3 in semiActiveGuidedWeaponsInAir)
				{
					Weapon theWeapon = item3;
					if (sensor2.CanIlluminateForThisWeapon(ref theWeapon))
					{
						sensor2.GoActive();
						break;
					}
				}
			}
		}
		dataLinkeGuidedWeaponsInAirThatNeedTrack.thatHaveTrack.Dispose();
		dataLinkeGuidedWeaponsInAirThatNeedTrack.thatNeedTrack.Dispose();
	}

	public virtual void vmethod_2(Sensor[] SensorsList)
	{
		try
		{
			if (myUnit.IsGroup)
			{
				return;
			}
			if (!myUnit.IsSatellite)
			{
				if (myUnit.IsWeapon && ((Weapon)myUnit).IsDecoy)
				{
					foreach (Sensor sensor in SensorsList)
					{
						if (sensor.IsOECM && !sensor.IsActive())
						{
							sensor.GoActive();
						}
					}
				}
				if (!ObeysEMCON)
				{
					return;
				}
				Doctrine.EMCONSettings eMCONSettings = myUnit.Doctrine.EMCON(myUnit.ParentScen);
				bool bool_ = false;
				if (eMCONSettings.HasActiveEmissions() && !Information.IsNothing((object)myUnit.ActiveMissionOrPackage()))
				{
					if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Patrol)
					{
						if (((Patrol)myUnit.ActiveMissionOrPackage()).ActiveEMCONOnlyInPatrolOrProsecutionArea)
						{
							Patrol patrol = (Patrol)myUnit.ActiveMissionOrPackage();
							if (!myUnit.IsAircraft)
							{
								if (!myUnit.Navigator.IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_2nm_Buffered, ref patrol.PatrolArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: true, IsProsecutionArea: false) && !myUnit.Navigator.IsInsideMissionArea(ref patrol.ProsecutionArea, ref patrol.ProsecutionArea_2nm_Buffered, ref patrol.ProsecutionArea_2nm_ChangeCheck, 2, IgnoreTimeToNextEvaluation: true, IsProsecutionArea: true))
								{
									bool_ = true;
								}
							}
							else if (!myUnit.Navigator.IsInsideMissionArea(ref patrol.PatrolArea, ref patrol.PatrolArea_5nm_Buffered, ref patrol.PatrolArea_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: true, IsProsecutionArea: false) && !myUnit.Navigator.IsInsideMissionArea(ref patrol.ProsecutionArea, ref patrol.ProsecutionArea_5nm_Buffered, ref patrol.ProsecutionArea_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: true, IsProsecutionArea: true))
							{
								bool_ = true;
							}
						}
					}
					else if (myUnit.ActiveMissionOrPackage().MissionClass == Mission._MissionClass.Support && ((SupportMission)myUnit.ActiveMissionOrPackage()).ActiveEMCONOnlyOnStation && myUnit.Navigator.IsInSupportTransit)
					{
						bool_ = true;
					}
				}
				int num = SensorsList.Count() - 1;
				Sensor sensor_ = default(Sensor);
				for (int j = 0; j <= num; j++)
				{
					try
					{
						sensor_ = SensorsList[j];
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200429", ex2.Message);
						GameGeneral.WriteExceptionsToLog(ex2);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					method_1(sensor_, eMCONSettings, bool_);
				}
				if (myUnit.IsMCMPlatform_ThisPulse == -1)
				{
					myUnit.Determine_IsMCMPlatform();
				}
				if (myUnit.IsMCMPlatform_ThisPulse == 0)
				{
					return;
				}
				IEnumerable<Sensor> mineCountermeasures = myUnit.MineCountermeasures;
				if (mineCountermeasures.Count() <= 0)
				{
					return;
				}
				int num2 = mineCountermeasures.Count() - 1;
				for (int k = 0; k <= num2; k++)
				{
					try
					{
						sensor_ = mineCountermeasures.ElementAtOrDefault(k);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ex4?.Data.Add("Error at 200430", ex4.Message);
						GameGeneral.WriteExceptionsToLog(ex4);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					method_1(sensor_, eMCONSettings, bool_);
				}
				return;
			}
			foreach (Sensor sensor2 in SensorsList)
			{
				if (sensor2.CanBeActive)
				{
					sensor2.GoActive();
				}
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100237", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_1(Sensor sensor_1, Doctrine.EMCONSettings emconsettings_0, bool bool_1)
	{
		if (sensor_1 == null || !sensor_1.CanBeActive)
		{
			return;
		}
		try
		{
			if (sensor_1.IsPureIlluminator)
			{
				if (sensor_1.SemiActiveWeaponsGuided.Count == 0)
				{
					sensor_1.GoPassive();
				}
				return;
			}
			if (sensor_1.TargetsTrackedForFireControl_Readonly.Count > 0)
			{
				return;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200431", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		bool flag = default(bool);
		if (sensor_1.Type == Sensor.Sensor_Type.Radar)
		{
			try
			{
				if (emconsettings_0.Radar() == Doctrine.EMCONSettings._EMCONSetting.Active && !bool_1)
				{
					flag = true;
				}
				else if (sensor_1.TargetsTrackedForFireControl_Readonly.Count == 0)
				{
					flag = false;
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 2004310", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (!flag)
			{
				if (myUnit.Status == ActiveUnit._ActiveUnitStatus.EngagedOffensive && myUnit.AI.PrimaryTarget != null)
				{
					try
					{
						ActiveUnit_Weaponry weaponry = myUnit.Weaponry;
						Contact primaryTarget = myUnit.AI.PrimaryTarget;
						Doctrine._GunStrafeGroundTargets? GunStrafingSalvo = null;
						PooledList<Weapon> pooledList = weaponry.SuitableWeaponsForThisTarget(primaryTarget, ref GunStrafingSalvo);
						if (pooledList != null)
						{
							foreach (Weapon item in pooledList)
							{
								if (item != null)
								{
									ActiveUnit_Weaponry weaponry2 = myUnit.Weaponry;
									Contact primaryTarget2 = myUnit.AI.PrimaryTarget;
									int? ASL_atFiringUnit = null;
									Sensor SuitableDirectorSensor = null;
									if (weaponry2.CanThisWeaponEngageThisTarget(item, primaryTarget2, ref ASL_atFiringUnit, ManualFire: false, IgnoreAircraftOrientation: false, HumanFeedBackNeeded: false, null, ref SuitableDirectorSensor, DLZCheckRequested: false).EvaluationEnum == ActiveUnit_Weaponry.WeaponPrefireChecklistEvaluation.NeedHighQualityLocalTrackOrCEC)
									{
										flag = true;
										break;
									}
								}
							}
							pooledList.Dispose();
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						ex6?.Data.Add("Error at 2004311", ex6.Message);
						GameGeneral.WriteExceptionsToLog(ex6);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						List<WeaponSalvo> list = myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosFromThisUnitToAnyTarget(ref myUnit);
						foreach (WeaponSalvo item2 in list)
						{
							if (item2 == null)
							{
								continue;
							}
							WeaponSalvo.Shooter[] shootersList = item2.ShootersList;
							foreach (WeaponSalvo.Shooter shooter in shootersList)
							{
								if (shooter != null && shooter.NeedsSensorTrack_AAWFireControlGrade && Operators.CompareString(shooter.ShooterObjectID, myUnit.ObjectID, false) == 0)
								{
									flag = true;
									break;
								}
							}
						}
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						ex8?.Data.Add("Error at 2004312", ex8.Message);
						GameGeneral.WriteExceptionsToLog(ex8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		try
		{
			if (sensor_1.IsOECM || sensor_1.IsGNSSJammer)
			{
				flag = ((emconsettings_0.OECM() == Doctrine.EMCONSettings._EMCONSetting.Active && !bool_1) ? true : false);
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 2004313", ex10.Message);
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (sensor_1.IsSonar && sensor_1.CanBeActive)
			{
				flag = (sensor_1.Type == Sensor.Sensor_Type.DippingSonar_ActiveOnly && myUnit.IsUsingDippingSonar()) || ((emconsettings_0.Sonar() == Doctrine.EMCONSettings._EMCONSetting.Active && !bool_1) ? true : false);
			}
		}
		catch (Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			Exception ex12 = ex11;
			ex12?.Data.Add("Error at 2004314", ex12.Message);
			GameGeneral.WriteExceptionsToLog(ex12);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (myUnit.IsMCMPlatform_ThisPulse == -1)
			{
				myUnit.Determine_IsMCMPlatform();
			}
		}
		catch (Exception ex13)
		{
			ProjectData.SetProjectError(ex13);
			Exception ex14 = ex13;
			ex14?.Data.Add("Error at 200435", ex14.Message);
			GameGeneral.WriteExceptionsToLog(ex14);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (myUnit.IsMCMPlatform_ThisPulse != 0 && myUnit.IsOnActiveMineClearingMission)
			{
				MineClearingMission mineClearingMission = (MineClearingMission)myUnit.ActiveMissionOrPackage();
				if (myUnit.Navigator.IsInsideMissionArea(ref mineClearingMission.Area, ref mineClearingMission.Area_5nm_Buffered, ref mineClearingMission.Area_5nm_ChangeCheck, 5, IgnoreTimeToNextEvaluation: false, IsProsecutionArea: false))
				{
					if (!myUnit.IsAircraft)
					{
						goto IL_04e8;
					}
					int num;
					if (!(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 76.5048f))
					{
						if (!(myUnit.CurrentSpeed > 30f))
						{
							goto IL_04e8;
						}
						num = 0;
					}
					else
					{
						num = 0;
					}
					flag = (byte)num != 0;
				}
			}
			goto end_IL_044b;
			IL_04e8:
			if ((myUnit.IsShip || myUnit.IsSubmarine) && (myUnit.IsRTB || myUnit.Status == ActiveUnit._ActiveUnitStatus.WaitForPathfinder) && sensor_1.IsMineCountermeasure)
			{
				flag = false;
			}
			else if ((sensor_1.IsMineCountermeasure || sensor_1.IsMineHuntingSensor) && sensor_1.CanBeActive)
			{
				flag = true;
			}
			end_IL_044b:;
		}
		catch (Exception ex15)
		{
			ProjectData.SetProjectError(ex15);
			Exception ex16 = ex15;
			ex16?.Data.Add("Error at 2004316", ex16.Message);
			GameGeneral.WriteExceptionsToLog(ex16);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (flag)
			{
				sensor_1.GoActive();
			}
			else if (sensor_1.IsActive())
			{
				sensor_1.GoPassive();
			}
		}
		catch (Exception ex17)
		{
			ProjectData.SetProjectError(ex17);
			Exception ex18 = ex17;
			ex18?.Data.Add("Error at 200437", ex18.Message);
			GameGeneral.WriteExceptionsToLog(ex18);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_2(ActiveUnit activeUnit_0)
	{
		bool result;
		if (activeUnit_0 != null)
		{
			bool flag = false;
			Sensor[] sensors_Cached = activeUnit_0.Sensors_Cached;
			Sensor[] sensors_Cached2 = myUnit.Sensors_Cached;
			try
			{
				int num;
				if (sensors_Cached != null && sensors_Cached.Length != 0)
				{
					if (sensors_Cached2 != null && sensors_Cached2.Length != 0)
					{
						bool flag2 = false;
						for (int i = sensors_Cached.Count() - 1; i >= 0; i += -1)
						{
							Sensor sensor = sensors_Cached[i];
							if (sensor == null || !sensor.IsOECM)
							{
								continue;
							}
							if (sensor.IsOTH)
							{
								flag2 = true;
							}
							if (!sensor.IsActive() || !sensor.TargetIsWithinCoverageArc(myUnit))
							{
								continue;
							}
							for (int j = sensors_Cached2.Length - 1; j >= 0; j += -1)
							{
								Sensor sensor2 = sensors_Cached2[j];
								if (sensor2 != null && sensor2.TargetIsWithinCoverageArc(activeUnit_0) && sensor.get_CanJamThisSensor(sensor2))
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
						if (!flag)
						{
							result = false;
						}
						else
						{
							if (flag2)
							{
								num = 1;
								goto IL_0128;
							}
							if (Module_Unit.Has_Radar_LOS_ToUnit(myUnit, null, activeUnit_0, ref myUnit.ParentScen))
							{
								num = 1;
								goto IL_0128;
							}
							result = false;
						}
					}
					else
					{
						result = false;
					}
				}
				else
				{
					result = false;
				}
				goto end_IL_001c;
				IL_0128:
				result = (byte)num != 0;
				end_IL_001c:;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200352", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				int num2;
				if (!Debugger.IsAttached)
				{
					num2 = 0;
				}
				else
				{
					Debugger.Break();
					num2 = 0;
				}
				result = (byte)num2 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	public ActiveUnit_Sensory(ref ActiveUnit theUnit)
	{
		list_0 = new List<Contact>();
		BDAChangeNotices = new TDictionary<long, LoggedMessage>();
		NewContactsQueue_Local = new TDictionary<string, Contact>(StringComparer.Ordinal);
		DroppedContactsQueue_Local = new TDictionary<string, Contact>(StringComparer.Ordinal);
		HadActiveSensorInLastPulse = false;
		_ContactsList_OffGrid = new Dictionary<string, Contact>();
		_ContactsList_OffGrid_NonAU = new List<string>();
		dictionary_0 = new Dictionary<bool, List<ActiveUnit>>();
		JammingInfo = new JammingInfo();
		lockObject_0 = new LockObject();
		pooledList_1 = new PooledList<ActiveUnit>();
		tdictionary_0 = new TDictionary<string, P2PContacSnaphot>();
		concurrentBag_0 = new ConcurrentBag<TransmissionWithFeedback>();
		myUnit = theUnit;
		_ObeysEMCON = true;
	}

	public static bool IsUsingGNSSJammer(ActiveUnit theUnit)
	{
		bool result;
		try
		{
			Sensor[] sensors_Cached = theUnit.Sensors_Cached;
			int num;
			if (sensors_Cached == null)
			{
				num = 0;
			}
			else
			{
				if (sensors_Cached.Length > 0)
				{
					try
					{
						Sensor[] sensors_Cached2 = theUnit.Sensors_Cached;
						if (sensors_Cached2 != null)
						{
							Sensor[] array = sensors_Cached2;
							int num2 = 0;
							while (num2 < array.Length)
							{
								Sensor sensor = array[num2];
								bool? flag = sensor?.IsGNSSJammer;
								if (((!flag) ?? false) || sensor == null || !sensor.IsActive() || !flag.HasValue)
								{
									num2 = checked(num2 + 1);
									continue;
								}
								result = true;
								goto end_IL_0001;
							}
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						List<Sensor> list = theUnit.Sensors_Cached?.ToList();
						if (list != null)
						{
							foreach (Sensor item in list)
							{
								bool? flag = item?.IsGNSSJammer;
								if (((!flag) ?? false) || item == null || !item.IsActive() || !flag.HasValue)
								{
									continue;
								}
								result = true;
								ProjectData.ClearProjectError();
								goto end_IL_0001;
							}
						}
						ProjectData.ClearProjectError();
					}
				}
				num = 0;
			}
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
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

	public static bool smethod_0(ActiveUnit theUnit)
	{
		bool result;
		try
		{
			Sensor[] sensors_Cached = theUnit.Sensors_Cached;
			int num;
			if (sensors_Cached == null)
			{
				num = 0;
			}
			else
			{
				if (sensors_Cached.Length > 0)
				{
					try
					{
						Sensor[] array = sensors_Cached;
						int num2 = 0;
						while (num2 < array.Length)
						{
							Sensor sensor = array[num2];
							if (sensor == null || !sensor.IsOECM || !sensor.IsActive())
							{
								num2 = checked(num2 + 1);
								continue;
							}
							result = true;
							goto end_IL_0001;
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						List<Sensor> list = theUnit.Sensors_Cached.ToList();
						if (list != null)
						{
							foreach (Sensor item in list)
							{
								if (item == null || !item.IsOECM || !item.IsActive())
								{
									continue;
								}
								result = true;
								ProjectData.ClearProjectError();
								goto end_IL_0001;
							}
						}
						ProjectData.ClearProjectError();
					}
				}
				num = 0;
			}
			result = (byte)num != 0;
			end_IL_0001:;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
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

	private Sensor[] method_3(Sensor[] sensor_1)
	{
		if (sensor_1.Length != 0)
		{
			List<Sensor> list = new List<Sensor>(sensor_1.Length);
			foreach (Sensor sensor in sensor_1)
			{
				bool? flag2;
				bool? flag = (flag2 = sensor?.CanPerformVolumeSearch.Value);
				bool? flag3 = ((flag.HasValue && flag2 != true) ? new bool?(false) : (method_5(sensor) & flag2));
				if (flag3 ?? true)
				{
					flag2 = sensor?.CanBeActive;
					if ((((!flag2) ?? flag2) == true || GetIntermittentEmission().IsAllowedToEmit()) && flag3.HasValue)
					{
						list.Add(sensor);
					}
				}
			}
			int count = list.Count;
			if (count != 0)
			{
				Sensor[] array = new Sensor[count - 1 + 1];
				int num = count - 1;
				for (int j = 0; j <= num; j++)
				{
					array[j] = list[j];
				}
				return array;
			}
			return new Sensor[0];
		}
		return new Sensor[0];
	}

	private List<Sensor> method_4(Sensor[] sensor_1)
	{
		List<Sensor> list = new List<Sensor>();
		foreach (Sensor sensor in sensor_1)
		{
			if (sensor != null && (!sensor.CanBeActive || GetIntermittentEmission().IsAllowedToEmit()) && !sensor.CanPerformVolumeSearch.Value && sensor.TargetsTrackedForFireControl_Readonly.Count > 0)
			{
				list.Add(sensor);
			}
		}
		return list;
	}

	private bool method_5(Sensor sensor_1)
	{
		if (sensor_1 == null)
		{
			return false;
		}
		if (sensor_1.IsOperating)
		{
			if (sensor_1.HasActiveModeOnly && !sensor_1.IsActive())
			{
				return false;
			}
			if (!sensor_1.IsScanningOnThisPulse)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private bool method_6(Sensor sensor_1)
	{
		if (!sensor_1.IsScanningOnThisPulse_Full)
		{
			return false;
		}
		return true;
	}

	public virtual void PerformBaseDetections(ref ActiveUnit theUnit, ref Side theSide)
	{
		HandleDetectedBaseContact(theUnit, theSide);
	}

	public virtual void PerformDetections(Sensor[] SensorsList, List<ActiveUnit> OffGridUnits, float elapsedTime)
	{
		if (myUnit.IsDecoy)
		{
			return;
		}
		HadActiveSensorInLastPulse = false;
		if (myUnit.IsGroup || myUnit == null)
		{
			return;
		}
		lock (myUnit)
		{
			try
			{
				if (myUnit.get_UnitSide(SetSideOnly: false).AwarenessLevel == Side.AwarenessLevel_Enum.Blind)
				{
					return;
				}
				if (myUnit.IsFacility)
				{
					bool flag = myUnit.Sensors_Cached.Length == 0;
					bool flag2 = myUnit.Mounts.Count == 0;
					if (((Facility)myUnit).Crew == 0 && flag2 && flag)
					{
						return;
					}
				}
				if (Module_ActiveUnit.HasIncomingGuidedWeapons(myUnit, myUnit.ParentScen))
				{
					Sensor[] sensors_Cached = myUnit.Sensors_Cached;
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor.Type == Sensor.Sensor_Type.ESM || sensor.Type == Sensor.Sensor_Type.Infrared || sensor.Type == Sensor.Sensor_Type.Visual || sensor.Type == Sensor.Sensor_Type.PingIntercept)
						{
							sensor.TimeToNextScan = 0;
							sensor.TimeToNextScan_Full = 0;
						}
						if (sensor.Type == Sensor.Sensor_Type.Radar)
						{
							sensor.TimeToNextScan_Full = 0;
						}
					}
				}
				if (!this.get_HasSensorsOperating(SensorsList))
				{
					return;
				}
				Sensor[] array = method_3(SensorsList);
				List<Sensor> list = method_4(SensorsList);
				foreach (Sensor sensor2 in SensorsList)
				{
					if (sensor2 != null && sensor2.IsActive())
					{
						HadActiveSensorInLastPulse = true;
						break;
					}
				}
				if (array.Length == 0 && list.Count == 0)
				{
					return;
				}
				Sensor[] array2 = array.Where([SpecialName] (Sensor theS) => method_6(theS) && !theS.IsHeightFinder).ToArray();
				Sensor[] array3 = array.Where([SpecialName] (Sensor theS) => !method_6(theS) && !theS.IsHeightFinder).ToArray();
				Sensor[] array4 = array.Where([SpecialName] (Sensor theS) => theS.IsHeightFinder).ToArray();
				if (array2.Count() == 0 && array3.Count() == 0 && array4.Count() == 0)
				{
					return;
				}
				if (pooledList_6 != null)
				{
					pooledList_6.Clear();
				}
				else
				{
					pooledList_6 = new PooledList<ActiveUnit>(Pools<ActiveUnit>.Local);
				}
				if (pooledList_7 != null)
				{
					pooledList_7.Clear();
				}
				else
				{
					pooledList_7 = new PooledList<ActiveUnit>(Pools<ActiveUnit>.Local);
				}
				pooledList_1.Clear();
				if (array2.Length > 0)
				{
					if (myUnit.IsWeapon)
					{
						Weapon weapon = (Weapon)myUnit;
						if (weapon.IsFullyAutonomous && !weapon.IsAAWCapable)
						{
							pooledList_1 = new PooledList<ActiveUnit>(myUnit.ParentScen.ActiveUnits_List, Pools<ActiveUnit>.Local);
						}
						else
						{
							pooledList_1 = new PooledList<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).PotentialContacts, Pools<ActiveUnit>.Local);
						}
					}
					else if (myUnit.CommStuff.IsConnectedToSideNetwork)
					{
						pooledList_1 = new PooledList<ActiveUnit>(myUnit.get_UnitSide(SetSideOnly: false).PotentialContacts, Pools<ActiveUnit>.Local);
					}
					else
					{
						pooledList_1 = new PooledList<ActiveUnit>(myUnit.ParentScen.ActiveUnits_List, Pools<ActiveUnit>.Local);
					}
				}
				foreach (ActiveUnit OffGridUnit in OffGridUnits)
				{
					if (OffGridUnit != null && OffGridUnit != myUnit && (!OffGridUnit.IsWeapon || ((Weapon)OffGridUnit).FiringParent != myUnit))
					{
						pooledList_1.Add(OffGridUnit);
					}
				}
				if (myUnit.IsWeapon)
				{
					ActiveUnit dataLinkParent = ((Weapon)myUnit).DataLinkParent;
					if (dataLinkParent != null)
					{
						pooledList_1.Remove(dataLinkParent);
					}
				}
				if (!myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					foreach (Weapon item in myUnit.ParentScen.GuidedWeaponsInAir)
					{
						if (item.FiringParent == myUnit)
						{
							pooledList_1.Remove(item);
						}
					}
				}
				if (array3.Length > 0)
				{
					foreach (Contact value in myUnit.Sensory.Contacts_Local_ReadOnly.Values)
					{
						if (value.ActualUnit != null)
						{
							pooledList_6.Add(value.ActualUnit);
						}
					}
				}
				if (array4.Length > 0)
				{
					foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
					{
						if (contacts_.ActualUnit != null)
						{
							pooledList_7.Add(contacts_.ActualUnit);
						}
					}
				}
				if (pooledList_2 != null)
				{
					pooledList_2.Clear();
				}
				else
				{
					pooledList_2 = new PooledList<EligibleContactEntry>(Pools<EligibleContactEntry>.Local);
				}
				if (pooledList_5 != null)
				{
					pooledList_5.Clear();
				}
				else
				{
					pooledList_5 = new PooledList<EligibleContactEntry>(Pools<EligibleContactEntry>.Local);
				}
				if (array2.Length > 0)
				{
					PooledList<ActiveUnit> pooledList = pooledList_1;
					if (pooledList != null && pooledList.Count > 0)
					{
						pooledList_2 = method_7(array2, pooledList_1);
					}
				}
				if (array3.Count() > 0 && pooledList_6.Count > 0)
				{
					pooledList_3 = method_7(array3, pooledList_6);
					if (pooledList_3 != null)
					{
						pooledList_2.AddRange(pooledList_3);
					}
				}
				if (array4.Count() > 0 && pooledList_7.Count > 0)
				{
					pooledList_4 = method_7(array4, pooledList_7);
					if (pooledList_4 != null)
					{
						pooledList_2.AddRange(pooledList_4);
					}
				}
				if (list.Count > 0)
				{
					foreach (Sensor item2 in list)
					{
						foreach (Contact item3 in item2.TargetsTrackedForFireControl_Readonly)
						{
							if (item3 != null && item3.ActualUnit != null)
							{
								Sensor[] theSensorList = new Sensor[1] { item2 };
								EligibleContactEntry eligibleContactEntry = new EligibleContactEntry(ref item3.ActualUnit, ref theSensorList);
								if (eligibleContactEntry != null)
								{
									pooledList_2.Add(eligibleContactEntry);
								}
							}
						}
					}
				}
				bool flag3 = false;
				if (pooledList_2.Count > 0)
				{
					List<ActiveUnit> list2 = null;
					Sensor[] array5 = array;
					foreach (Sensor sensor3 in array5)
					{
						if (sensor3.Type == Sensor.Sensor_Type.Radar)
						{
							flag3 |= sensor3.HasResolutionCell();
							if (list2 == null)
							{
								list2 = this.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: true);
							}
							break;
						}
					}
					foreach (Sensor item4 in list)
					{
						if (item4.Type == Sensor.Sensor_Type.Radar)
						{
							flag3 |= item4.HasResolutionCell();
							if (list2 == null)
							{
								list2 = this.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: true);
							}
							break;
						}
					}
					if (SuccessfulDetectionsOnThisPulse != null)
					{
						Misc.Clear(SuccessfulDetectionsOnThisPulse);
					}
					else
					{
						SuccessfulDetectionsOnThisPulse = new ConcurrentQueue<(Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>)>();
					}
					foreach (EligibleContactEntry item5 in pooledList_2)
					{
						try
						{
							method_11(item5, list2);
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							ex2?.Data.Add("Error at 101168", "");
							GameGeneral.WriteExceptionsToLog(ex2);
							if (Debugger.IsAttached)
							{
								Debugger.Break();
							}
							ProjectData.ClearProjectError();
						}
					}
				}
				if (array2.Length > 0)
				{
					method_8(array2);
				}
				if (flag3)
				{
					method_30();
				}
				if (pooledList_1 != null)
				{
					pooledList_1.Dispose();
				}
				if (pooledList_2 != null)
				{
					pooledList_2.Dispose();
				}
				if (pooledList_3 != null)
				{
					pooledList_3.Dispose();
				}
				if (pooledList_4 != null)
				{
					pooledList_4.Dispose();
				}
				if (pooledList_5 != null)
				{
					pooledList_5.Dispose();
				}
				if (pooledList_6 != null)
				{
					pooledList_6.Dispose();
				}
				if (pooledList_7 != null)
				{
					pooledList_7.Dispose();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100242", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private PooledList<EligibleContactEntry> method_7(Sensor[] sensor_1, PooledList<ActiveUnit> pooledList_8)
	{
		PooledList<EligibleContactEntry> result;
		try
		{
			(float MaxAirSpace, float MaxSurface, float MaxSubsurface, float MaxLand) longestSensorRanges_AllContactTypes = GetLongestSensorRanges_AllContactTypes(OnlySensorsScanningThisPulse: true);
			float item = longestSensorRanges_AllContactTypes.MaxAirSpace;
			float item2 = longestSensorRanges_AllContactTypes.MaxSurface;
			float item3 = longestSensorRanges_AllContactTypes.MaxLand;
			float item4 = longestSensorRanges_AllContactTypes.MaxSubsurface;
			float num = Math.Max(Math.Max(Math.Max(item, item2), item4), item3);
			PooledList<EligibleContactEntry> pooledList = new PooledList<EligibleContactEntry>(Pools<EligibleContactEntry>.Local);
			if (num == 0f)
			{
				result = pooledList;
			}
			else
			{
				double pointLat = myUnit.get_Latitude(GlobalVariables.ObjectTrue);
				double pointLon = myUnit.get_Longitude(GlobalVariables.ObjectTrue);
				ActiveUnit[] array = Geodesic_Haversine.UnitsWithinDistanceFromPoint(pooledList_8, AssumeAllUnitsAreOperating: true, pointLat, pointLon, num);
				PooledSet<string> pooledSet = new PooledSet<string>();
				ActiveUnit[] array2 = array;
				float num2 = default(float);
				for (int i = 0; i < array2.Length; i = checked(i + 1))
				{
					ActiveUnit theActiveUnit = array2[i];
					if (theActiveUnit == null)
					{
						continue;
					}
					string objectID = theActiveUnit.ObjectID;
					if (pooledSet.Contains(objectID))
					{
						continue;
					}
					pooledSet.Add(objectID);
					if (theActiveUnit == null || theActiveUnit.IsGroup || !theActiveUnit.IsOperating())
					{
						continue;
					}
					if (!theActiveUnit.IsFacility && !theActiveUnit.IsMobileGroundUnit && !theActiveUnit.IsAggregatedUnit)
					{
						if (theActiveUnit.IsVehicle)
						{
							num2 = item3;
						}
						else if (!theActiveUnit.IsShip)
						{
							if (!theActiveUnit.IsSubmarine && !theActiveUnit.IsTorpedo && (!theActiveUnit.IsWeapon || ((Weapon)theActiveUnit).Type != Weapon._WeaponType.Sonobuoy))
							{
								if (theActiveUnit.IsAerospaceUnit)
								{
									num2 = item;
									if (myUnit.IsSubmarine && theActiveUnit.IsUsingDippingSonar())
									{
										num2 = Math.Max(Math.Max(num2, item2), item4);
									}
								}
							}
							else
							{
								num2 = Math.Max(item4, item2);
							}
						}
						else
						{
							num2 = item2;
							if (myUnit.IsSubmarine && theActiveUnit.IsUsingDippingSonar())
							{
								num2 = Math.Max(num2, item2);
							}
						}
					}
					else
					{
						num2 = item3;
					}
					if (num2 != 0f && num2 > Module_Unit.RangeToUnit_Slant(myUnit, theActiveUnit, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue))
					{
						EligibleContactEntry item5 = new EligibleContactEntry(ref theActiveUnit, ref sensor_1);
						pooledList.Add(item5);
					}
				}
				pooledSet.Dispose();
				ArrayPool<ActiveUnit>.Shared.Return(array, clearArray: true);
				result = pooledList;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101224", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new PooledList<EligibleContactEntry>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_8(Sensor[] sensor_1)
	{
		try
		{
			if (myUnit.ParentScen.Mines == null || myUnit.ParentScen.Mines.Count == 0 || myUnit.IsFacility || Misc.IsEmpty_LockFreeCheck(myUnit.ParentScen.UnguidedWeapons))
			{
				return;
			}
			int num;
			if (myUnit.IsWeapon)
			{
				Weapon weapon = (Weapon)myUnit;
				if (weapon.Type != Weapon._WeaponType.HeliTowedPackage)
				{
					if (weapon.ValidTargets.Mine)
					{
						num = 0;
						goto IL_009a;
					}
					return;
				}
			}
			num = 0;
			goto IL_009a;
			IL_009a:
			Sensor[] theArray = new Sensor[num];
			foreach (Sensor sensor in sensor_1)
			{
				if (!sensor.IsSonar && !sensor.IsMineHuntingSensor)
				{
					if (sensor.Type == Sensor.Sensor_Type.Visual && (myUnit.IsAircraft || myUnit.IsShip) && myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < 150f && myUnit.CurrentSpeed < 200f)
					{
						ArrayExtensions.Add(ref theArray, sensor);
					}
				}
				else if (sensor.IsActive() && sensor.IsOperating && (sensor.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar) || sensor.Capabilities.Mine_Obstacle_Search))
				{
					ArrayExtensions.Add(ref theArray, sensor);
				}
			}
			if (theArray.Length == 0)
			{
				return;
			}
			List<GClass6> list = new List<GClass6>();
			list = method_9(ref theArray, ref myUnit.ParentScen.Mines);
			if (list.Count <= 0)
			{
				return;
			}
			if (SuccessfulNonAUDetectionsOnThisPulse != null)
			{
				Misc.Clear(SuccessfulNonAUDetectionsOnThisPulse);
			}
			else
			{
				SuccessfulNonAUDetectionsOnThisPulse = new ConcurrentQueue<string>();
			}
			foreach (GClass6 item in list)
			{
				method_10(item, theArray);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101272", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private List<GClass6> method_9(ref Sensor[] sensor_1, ref List<UnguidedWeapon> list_1)
	{
		List<GClass6> result;
		try
		{
			List<GClass6> list = new List<GClass6>();
			double num = myUnit.get_Latitude(GlobalVariables.ObjectTrue);
			UnguidedWeapon[] array = list_1.ToArray();
			PooledList<Sensor> longestRange_MineSensor = GetLongestRange_MineSensor(ref sensor_1);
			if (sensor_1.Count() > 0 && longestRange_MineSensor != null)
			{
				double num2 = longestRange_MineSensor[0].maxRange;
				if (num2 > 1.0)
				{
					num2 = 1.0;
				}
				float num3 = (float)Math2.Distance_To_AngularDegrees(num2);
				longestRange_MineSensor.Dispose();
				int num4 = array.Length - 1;
				for (int i = 0; i <= num4; i++)
				{
					if (i < array.Length)
					{
						UnguidedWeapon theActiveUnit = array[i];
						if (!(Math.Abs(num - ((Module_Unit.Unit)theActiveUnit).get_Latitude((GlobalVariables.BooleanObject)null)) > (double)num3) && (double)num3 > Module_Unit.RangeToUnit_Horiz_Angular(myUnit, theActiveUnit))
						{
							GClass6 item = new GClass6(ref theActiveUnit, ref sensor_1);
							list.Add(item);
						}
					}
				}
				result = list;
			}
			else
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101224", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new List<GClass6>();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_10(GClass6 gclass6_0, Sensor[] sensor_1)
	{
		try
		{
			UnguidedWeapon nonAU_Weapon = gclass6_0.NonAU_Weapon;
			float targetRange = Module_Unit.RangeToUnit_Slant(myUnit, nonAU_Weapon);
			for (int i = 0; i < sensor_1.Length; i = checked(i + 1))
			{
				if (sensor_1[i].CanDetectTarget_NonAU(myUnit, nonAU_Weapon, targetRange))
				{
					SuccessfulNonAUDetectionsOnThisPulse.Enqueue(nonAU_Weapon.ObjectID);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100244", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_11(EligibleContactEntry eligibleContactEntry_0, List<ActiveUnit> list_1)
	{
		Side side = myUnit.get_UnitSide(SetSideOnly: false);
		ActiveUnit activeUnit = eligibleContactEntry_0.ActiveUnit;
		Sensor[] sensorList = eligibleContactEntry_0.SensorList;
		if (activeUnit == null || activeUnit == myUnit || !activeUnit.IsOperating() || (activeUnit.IsWeapon && ((Weapon)activeUnit).Type == Weapon._WeaponType.Gun))
		{
			return;
		}
		Side side2 = activeUnit.get_UnitSide(SetSideOnly: false);
		if (myUnit.CommStuff.IsConnectedToSideNetwork && activeUnit.CommStuff.IsConnectedToSideNetwork && (side == side2 || side2.get_ConsidersThisSideToBe(side, (Scenario)null) == Misc.PostureStance.Friendly))
		{
			return;
		}
		bool flag = activeUnit.get_IsEligibleForAutodetection(side);
		Contact value = default(Contact);
		try
		{
			if (flag && side != side2)
			{
				if (!myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					if (!_ContactsList_OffGrid.TryGetValue(activeUnit.ObjectID, out value))
					{
						return;
					}
				}
				else if (!side.Contacts.TryGetValue(activeUnit.ObjectID, out value))
				{
					return;
				}
				if (value != null && !myUnit.IsWeapon && (!activeUnit.HasEmittingSensors || value.DetectedEmissions.Count != 0))
				{
					if (value.Recon_HostedUnits(side).Count > 0)
					{
						if (value.TimeSinceBDA < 10f)
						{
							return;
						}
					}
					else if (value.TimeSinceBDA < 15f)
					{
						return;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100245_3", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		List<Sensor> SensorsThatMadeDetection = new List<Sensor>();
		float? num = null;
		try
		{
			num = ((!myUnit.IsSubmarine || !activeUnit.IsUsingDippingSonar()) ? new float?(Module_Unit.RangeToUnit_Slant(myUnit, activeUnit, 0f, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) : new float?(myUnit.RangeToUnit_Horiz(activeUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)));
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100245_4", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		bool? LOS_Exists_Radar = null;
		bool? LOS_Exists_RadarSW = null;
		Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual = null;
		bool? LOS_Exists_Sonar = null;
		bool? LOS_Exists_ESM = null;
		bool? LOS_Exists_ESM_SW = null;
		if (flag && side != side2)
		{
			try
			{
				if (activeUnit.HasEmittingSensors)
				{
					Contact contact = ResultOfDetectionAttempt(activeUnit, sensorList, num.Value, ref SensorsThatMadeDetection, list_1, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, LOS_Exists_ESM, LOS_Exists_ESM_SW, EmissionDetectionOnly: true);
					if (contact != null)
					{
						MergeDetectedEmissions(value, contact.DetectedEmissions);
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 100245_1", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (!myUnit.IsWeapon || (!((Weapon)myUnit).HasGoneAutonomous && myUnit.CommStuff.CommLinksEstablished_ReadOnly.Length != 0))
				{
					Sensor[] sensors_Cached = myUnit.Sensors_Cached;
					List<Geopoint_Struct> UncertaintyArea = default(List<Geopoint_Struct>);
					Dictionary<int, EmissionContainer> DetectedEmissions = default(Dictionary<int, EmissionContainer>);
					foreach (Sensor sensor in sensors_Cached)
					{
						if (sensor.get_CanPerformBDA(AllowRadar: false, AllowSonar: false) && sensor.CanDetectTarget(Sensor.DetectionAttemptType.Recon, myUnit, activeUnit, ref UncertaintyArea, num.Value, ref DetectedEmissions, list_1, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW))
						{
							method_19(value, activeUnit, sensor);
							AttemptReconOfHostedUnits(value, activeUnit, sensor);
						}
					}
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				ex8?.Data.Add("Error at 100245_2", "");
				GameGeneral.WriteExceptionsToLog(ex8);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			if (!myUnit.IsWeapon)
			{
				return;
			}
		}
		try
		{
			value = ResultOfDetectionAttempt(activeUnit, sensorList, num.Value, ref SensorsThatMadeDetection, list_1, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, LOS_Exists_ESM, LOS_Exists_ESM_SW, EmissionDetectionOnly: false);
			if (value == null)
			{
				return;
			}
			SuccessfulDetectionsOnThisPulse.Enqueue((value, activeUnit, SensorsThatMadeDetection, num.Value, SpecialDetectionMode.None, myUnit.ParentScen.Time, value.UncertaintyArea));
			Contact value2 = default(Contact);
			foreach (ActiveUnit item in pooledList_6)
			{
				if (Operators.CompareString(item.ObjectID, value.ActualUnit.ObjectID, false) != 0)
				{
					continue;
				}
				KeyValuePair<string, Contact> keyValuePair = default(KeyValuePair<string, Contact>);
				foreach (KeyValuePair<string, Contact> item2 in Contacts_Local_ReadOnly)
				{
					if (string.CompareOrdinal(item2.Value.ActualUnit.ObjectID, item.ObjectID) == 0)
					{
						keyValuePair = item2;
						if (Operators.CompareString(keyValuePair.Key, "", false) != 0)
						{
							value2 = keyValuePair.Value;
							break;
						}
					}
				}
			}
			if (value2 == null || !myUnit.CommStuff.ContactsInfoGrade.ContainsKey(value2.ObjectID))
			{
				return;
			}
			ActiveUnit_CommStuff.TransmissionContactData transmissionContactData = myUnit.CommStuff.ContactsInfoGrade[value2.ObjectID];
			if (Operators.CompareString(transmissionContactData.ObjectID, "", false) != 0 && transmissionContactData.ObjectID != null)
			{
				ActiveUnit_CommStuff.TransmissionContactData value3 = myUnit.CommStuff.ContactsInfoGrade[value2.ObjectID];
				if (value3.ObjectID != null)
				{
					value3.TransmittedBy = null;
					value3.Latency = CommDevice.EnumCommLatency.None;
					value3.Bandwith = CommDevice.EnumCommQuality.None;
					myUnit.CommStuff.ContactsInfoGrade[value2.ObjectID] = value3;
				}
			}
		}
		catch (Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			Exception ex10 = ex9;
			ex10?.Data.Add("Error at 100245", "");
			GameGeneral.WriteExceptionsToLog(ex10);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public virtual void HandleDetections_OnGrid()
	{
		try
		{
			if (myUnit.get_UnitSide(SetSideOnly: false) == null)
			{
				return;
			}
			while (myUnit.get_UnitSide(SetSideOnly: false).SpecialDetections.Count > 0)
			{
				(Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>) theDetectionRecord = myUnit.get_UnitSide(SetSideOnly: false).SpecialDetections.Dequeue();
				HandleDetectedContact_OnGrid(myUnit, myUnit.get_UnitSide(SetSideOnly: false), theDetectionRecord);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100246", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (SuccessfulDetectionsOnThisPulse != null)
			{
				while (SuccessfulDetectionsOnThisPulse.Count > 0)
				{
					if (SuccessfulDetectionsOnThisPulse.TryDequeue(out var result))
					{
						HandleDetectedContact_OnGrid(myUnit, myUnit.get_UnitSide(SetSideOnly: false), result);
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100246_2", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		if (SuccessfulNonAUDetectionsOnThisPulse != null && SuccessfulNonAUDetectionsOnThisPulse.Count > 0)
		{
			List<EventTrigger> list = new List<EventTrigger>();
			foreach (string item in SuccessfulNonAUDetectionsOnThisPulse)
			{
				if (string.IsNullOrEmpty(item) || myUnit.get_UnitSide(SetSideOnly: false).Contacts_NonAU.Contains(item))
				{
					continue;
				}
				try
				{
					myUnit.get_UnitSide(SetSideOnly: false).Contacts_NonAU.Add(item);
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					ex6?.Data.Add("Error at 100246_3", "");
					GameGeneral.WriteExceptionsToLog(ex6);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!myUnit.ParentScen.UnguidedWeapons.HasElements())
					{
						continue;
					}
					UnguidedWeapon value = null;
					myUnit.ParentScen.UnguidedWeapons.TryGetValue(item, out value);
					if (value == null || !value.IsMine)
					{
						continue;
					}
					string text = "";
					if (myUnit.IsAircraft && Operators.CompareString(myUnit.Name, myUnit.UnitClass, false) != 0)
					{
						text = " (" + myUnit.UnitClass + ")";
					}
					myUnit.AddMessage("New mine contact! Detected by " + myUnit.Name + text + " at " + Conversions.ToString((int)Math.Round(myUnit.AI.BearingToUnit_True(value))) + "deg - " + Conversions.ToString(Math.Round(myUnit.RangeToUnit_Horiz(value), 1)) + "NM", "Mine warfare", LoggedMessage.MessageType.NewMineContact, 1, new Geopoint_Struct(((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null)));
					try
					{
						foreach (ActiveUnit activeUnits_ in myUnit.ParentScen.ActiveUnits_List)
						{
							if ((activeUnits_ == null || !activeUnits_.IsSubmarine) && (activeUnits_ == null || !activeUnits_.IsShip))
							{
								continue;
							}
							if (myUnit.IsMCMPlatform_ThisPulse == -1)
							{
								myUnit.Determine_IsMCMPlatform();
							}
							if (activeUnits_.IsMCMPlatform_ThisPulse == 0)
							{
								List<Sensor> mineCountermeasures = activeUnits_.MineCountermeasures;
								if (mineCountermeasures == null || mineCountermeasures.Count <= 0)
								{
									if (value.RangeToUnit_Horiz(activeUnits_) < 20f)
									{
										activeUnits_.Navigator.ResetTimeToNextPathfinderCheck();
									}
									continue;
								}
							}
							if (value.RangeToUnit_Horiz(activeUnits_) < 2f)
							{
								activeUnits_.Navigator.TimeToNextPathfinderCheck = Math.Max(600f, activeUnits_.Navigator.TimeToNextPathfinderCheck);
							}
							else
							{
								activeUnits_.Navigator.TimeToNextPathfinderCheck = Math.Max(300f, activeUnits_.Navigator.TimeToNextPathfinderCheck);
							}
						}
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						ex8?.Data.Add("Error at 100246_4", "");
						GameGeneral.WriteExceptionsToLog(ex8);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
					try
					{
						foreach (EventTrigger value2 in myUnit.ParentScen.EventTriggers.Values)
						{
							if (value2.Type == EventTrigger.EventTriggerType.UnitDetected && ((EventTrigger_UnitDetected)value2).get_IsFulfilled(value, myUnit, ContactWasDetectedOnThisPulse: true, Contact_Base.IdentificationStatus.KnownClass, (Contact_Base.IdentificationStatus?)Contact_Base.IdentificationStatus.Unknown, (List<Sensor>)null))
							{
								list.Add(value2);
							}
						}
					}
					catch (Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						Exception ex10 = ex9;
						ex10?.Data.Add("Error at 100246_5", "");
						GameGeneral.WriteExceptionsToLog(ex10);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				catch (Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					Exception ex12 = ex11;
					ex12?.Data.Add("Error at 100246_6", "");
					GameGeneral.WriteExceptionsToLog(ex12);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				if (list != null && list.Count > 0)
				{
					myUnit.ParentScen.FireEvents(list);
				}
			}
			catch (Exception ex13)
			{
				ProjectData.SetProjectError(ex13);
				Exception ex14 = ex13;
				ex14?.Data.Add("Error at 100246_7", "");
				GameGeneral.WriteExceptionsToLog(ex14);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		try
		{
			if (BDAChangeNotices == null || BDAChangeNotices.Count <= 0)
			{
				return;
			}
			foreach (LoggedMessage value3 in BDAChangeNotices.Values)
			{
				myUnit.ParentScen.AddMessage(value3);
			}
			BDAChangeNotices.Clear();
		}
		catch (Exception ex15)
		{
			ProjectData.SetProjectError(ex15);
			Exception ex16 = ex15;
			ex16?.Data.Add("Error at 100246_8", "");
			GameGeneral.WriteExceptionsToLog(ex16);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void HandleDetections_OffGrid()
	{
		try
		{
			if (SuccessfulDetectionsOnThisPulse != null)
			{
				foreach (var item in SuccessfulDetectionsOnThisPulse)
				{
					HandleDetectedContact_OffGrid(item);
				}
			}
			if (SuccessfulNonAUDetectionsOnThisPulse != null)
			{
				foreach (string item2 in SuccessfulNonAUDetectionsOnThisPulse)
				{
					if (string.IsNullOrEmpty(item2) || _ContactsList_OffGrid_NonAU.Contains(item2))
					{
						continue;
					}
					_ContactsList_OffGrid_NonAU.Add(item2);
					try
					{
						UnguidedWeapon unguidedWeapon = myUnit.ParentScen.UnguidedWeapons[item2];
						if (unguidedWeapon.IsMine)
						{
							myUnit.AddMessage("New mine contact! Detected by " + myUnit.Name + " at " + Conversions.ToString((int)Math.Round(myUnit.AI.BearingToUnit_True(unguidedWeapon))) + "deg - " + Conversions.ToString(Math.Round(myUnit.RangeToUnit_Horiz(unguidedWeapon), 1)) + "NM", "Mine warfare", LoggedMessage.MessageType.CommsIsolatedMessage, 1, new Geopoint_Struct(((Module_Unit.Unit)unguidedWeapon).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)unguidedWeapon).get_Latitude((GlobalVariables.BooleanObject)null)));
							if (myUnit.IsSubmarine || myUnit.IsShip)
							{
								myUnit.Navigator.ResetTimeToNextPathfinderCheck();
							}
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
			}
			if (BDAChangeNotices != null)
			{
				foreach (LoggedMessage value in BDAChangeNotices.Values)
				{
					myUnit.ParentScen.AddMessage(value);
				}
			}
			BDAChangeNotices.Clear();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200653", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static void UpdateContactData(ref ActiveUnit TheDetectingUnit, ref Contact myContact, ActiveUnit ContactsActualUnit, bool ContactIsNew, List<Geopoint_Struct> theUncertaintyArea = null)
	{
		try
		{
			if (GameGeneral.Beta_PlatformComms && ContactsActualUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm) && myContact.IsFrozenCommsContact)
			{
				return;
			}
			int num;
			bool flag2 = default(bool);
			if (!ContactIsNew)
			{
				Contact_Base.ContactType type = myContact.Type;
				if (type <= Contact_Base.ContactType.Facility_Fixed)
				{
					if (type != Contact_Base.ContactType.Aimpoint)
					{
						if (type != Contact_Base.ContactType.Facility_Fixed)
						{
							num = 1;
							goto IL_00a2;
						}
						bool flag = false;
						if (myContact.ActualUnit != null)
						{
							flag = (((Module_Unit.Unit)myContact).get_Latitude((GlobalVariables.BooleanObject)null) != myContact.ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null)) | (((Module_Unit.Unit)myContact).get_Longitude((GlobalVariables.BooleanObject)null) != myContact.ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null));
						}
						if (myContact.UncertaintyArea != null || flag)
						{
							flag2 = true;
						}
					}
				}
				else if (type != Contact_Base.ContactType.Explosion && type != Contact_Base.ContactType.ActivationPoint)
				{
					num = 1;
					goto IL_00a2;
				}
			}
			else
			{
				flag2 = true;
			}
			goto IL_00a7;
			IL_00a2:
			flag2 = (byte)num != 0;
			goto IL_00a7;
			IL_00a7:
			if (flag2)
			{
				if (theUncertaintyArea != null)
				{
					if (myContact.UncertaintyArea == null)
					{
						if (ContactIsNew)
						{
							myContact.UncertaintyArea = theUncertaintyArea;
						}
					}
					else if (!myContact.IsPreciselyLocatedOnThisPulse)
					{
						if (myContact.ActualUnit == null)
						{
							myContact.UncertaintyArea = theUncertaintyArea;
						}
						else
						{
							myContact.UncertaintyArea = GetRefinedUncertaintyArea_Clipper(myContact.UncertaintyArea, theUncertaintyArea);
						}
					}
				}
				myContact.CurrentHeading = ContactsActualUnit.CurrentHeading;
				myContact.CurrentSpeed = ContactsActualUnit.CurrentSpeed;
				myContact.Altitude_old = ((Module_Unit.Unit)myContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
				((Module_Unit.Unit)myContact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ContactsActualUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				myContact.CurrentVerticalRate_mpersec = null;
				myContact.ContactMovement();
				myContact.UpdateCenter(ContactsActualUnit);
			}
			myContact.Age = 0f;
			if (myContact.ActualUnit.isUAV)
			{
				myContact.Type = Contact_Base.ContactType.Air;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100247", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void ExportContactLocationEvent(Contact theContact, Side ObserverSide, Scenario theScen)
	{
		lock (theContact)
		{
			try
			{
				IEventExporter[] applicableEventExporters = theScen.ApplicableEventExporters;
				foreach (IEventExporter eventExporter in applicableEventExporters)
				{
					if (eventExporter.IsOperating && eventExporter.Common.LocationExportPossibleThisTick(theScen, theContact) && ObserverSide != null)
					{
						PooledDictionary<string, IEventExporter.EventNotificationParameter> pooledDictionary = new PooledDictionary<string, IEventExporter.EventNotificationParameter>(30, ClearMode.Always);
						if (theScen.MonteCarloIteration > 0)
						{
							pooledDictionary.Add("Scenario", new IEventExporter.EventNotificationParameter(theScen.Title, typeof(string), 500));
							pooledDictionary.Add("MC_Run", new IEventExporter.EventNotificationParameter(theScen.MonteCarloIteration, typeof(int)));
						}
						pooledDictionary.Add("TimelineID", new IEventExporter.EventNotificationParameter(theScen.TimelineID, typeof(string), 40));
						if (!eventExporter.UseZeroHour)
						{
							pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.ToString("MM/dd/yyyy HH:mm:ss") + "." + theScen.Time.Millisecond.ToString("D3"), typeof(DateTime)));
						}
						else
						{
							pooledDictionary.Add("Time", new IEventExporter.EventNotificationParameter(theScen.Time.Subtract(theScen.ZeroHour).ToString("c"), typeof(TimeSpan), 30));
						}
						pooledDictionary.Add("ContactID", new IEventExporter.EventNotificationParameter(theContact.ObjectID, typeof(string), 40));
						pooledDictionary.Add("UnitDBID", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.DBID, typeof(string), 10));
						pooledDictionary.Add("ContactName", new IEventExporter.EventNotificationParameter(theContact.Name, typeof(string), 500));
						pooledDictionary.Add("UnitType", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.UnitType_String, typeof(string), 20));
						pooledDictionary.Add("UnitClass", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.UnitClass, typeof(string), 500));
						pooledDictionary.Add("ObserverSide", new IEventExporter.EventNotificationParameter(ObserverSide.Name, typeof(string), 500));
						pooledDictionary.Add("ContactLongitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), typeof(double)));
						pooledDictionary.Add("ContactLatitude", new IEventExporter.EventNotificationParameter(((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null), typeof(double)));
						string theValue = (theContact.HeadingIsKnown ? Conversions.ToString(theContact.CurrentHeading) : string.Empty);
						pooledDictionary.Add("ContactCourse", new IEventExporter.EventNotificationParameter(theValue, typeof(float)));
						string theValue2 = (theContact.SpeedIsKnown ? Conversions.ToString(theContact.CurrentSpeed) : string.Empty);
						pooledDictionary.Add("ContactSpeed_kts", new IEventExporter.EventNotificationParameter(theValue2, typeof(float)));
						if (theContact.AltitudeIsKnown)
						{
							Conversions.ToString(((Module_Unit.Unit)theContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
						}
						if (!theContact.ActualUnit.IsAircraft && !theContact.ActualUnit.IsMissile && !theContact.ActualUnit.IsTorpedo)
						{
							pooledDictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.Attitude_Pitch, typeof(float)));
						}
						else
						{
							pooledDictionary.Add("UnitAttitude_Pitch", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.Attitude_Pitch_Derived(), typeof(float)));
						}
						pooledDictionary.Add("UnitAttitude_Roll", new IEventExporter.EventNotificationParameter(theContact.ActualUnit.Attitude_Roll, typeof(float)));
						eventExporter.ExportEvent(IEventExporter.ExportedEventType.ContactPositions, pooledDictionary, theScen);
						eventExporter.Common.ApplyLastExportLocation(theContact);
					}
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
	}

	public void HandleContactLoss(Contact theC)
	{
		Sensor[] sensors_Cached = myUnit.Sensors_Cached;
		try
		{
			int num = sensors_Cached.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				sensors_Cached[i].HandleTargetLoss(theC);
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

	public static void MergeDetectedEmissions(Contact ExistingContact, TObservableDictionary<int, EmissionContainer> NewEmissions)
	{
		if (NewEmissions.Count == 0)
		{
			return;
		}
		try
		{
			List<int> list = NewEmissions.Keys.ToList();
			foreach (int item in list)
			{
				EmissionContainer emissionContainer = NewEmissions[item];
				if (!ExistingContact.DetectedEmissions.ContainsKey(item))
				{
					try
					{
						if (ExistingContact == null)
						{
							break;
						}
						if (ExistingContact.DetectedEmissions == null)
						{
							ExistingContact.DetectedEmissions = new TObservableDictionary<int, EmissionContainer>();
						}
						lock (ExistingContact.DetectedEmissions)
						{
							if (!ExistingContact.DetectedEmissions.ContainsKey(item))
							{
								ExistingContact.DetectedEmissions.Add(item, emissionContainer);
							}
							else
							{
								ExistingContact.DetectedEmissions[item] = emissionContainer;
							}
						}
						continue;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ex2?.Data.Add("Error at 200011", ex2.Message);
						if (Debugger.IsAttached)
						{
							Debugger.Break();
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					if (ExistingContact.DetectedEmissions[item].PreciseID)
					{
						emissionContainer.PreciseID = true;
					}
					emissionContainer.Age = Math.Min(emissionContainer.Age, ExistingContact.DetectedEmissions[item].Age);
					ExistingContact.DetectedEmissions[item] = emissionContainer;
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 100248", "");
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_12(List<Sensor> list_1, Contact contact_0)
	{
		foreach (Sensor item in list_1)
		{
			bool flag = DetectionIsPrecise(item, item.ParentPlatform.RangeToUnit_Horiz(contact_0.ActualUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue));
			if (!item.IsMk1Eyeball)
			{
				if (!item.IsContinousTrackingCapable)
				{
					ActiveUnit theUnit = contact_0.ActualUnit;
					if (!item.IsTrackingThisUnitForFireControl(ref theUnit))
					{
						if (item.Type == Sensor.Sensor_Type.Radar)
						{
							contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, 3f);
							if (flag)
							{
								contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
							}
						}
						else if (contact_0.IsLandContact)
						{
							contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, item.ScanInterval * 6);
							if (flag)
							{
								contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
							}
						}
						else
						{
							contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, 1f);
						}
					}
					else
					{
						contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, item.ScanInterval);
						if (flag)
						{
							contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
						}
					}
				}
				else
				{
					contact_0.RemainingContinousTrackTime = Math.Max(contact_0.RemainingContinousTrackTime, item.ScanInterval);
					if (flag)
					{
						contact_0.RemainingContinousTrackTime_Precise = Math.Max(contact_0.RemainingContinousTrackTime_Precise, item.ScanInterval);
					}
				}
			}
			else
			{
				contact_0.RemainingContinousTrackTime = 10f;
				contact_0.RemainingContinousTrackTime_Precise = 10f;
			}
		}
	}

	public virtual void HandleDetectedContact_OnGrid(ActiveUnit theSensorUnit, Side theSide, (Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>) theDetectionRecord, bool IgnoreLuaHook = false)
	{
		Contact item = theDetectionRecord.Item1;
		ActiveUnit item2 = theDetectionRecord.Item2;
		List<Sensor> item3 = theDetectionRecord.Item3;
		float item4 = theDetectionRecord.Item4;
		SpecialDetectionMode item5 = theDetectionRecord.Item5;
		List<Geopoint_Struct> list = null;
		_ = item.DetectedEmissions;
		List<Side> list2 = new List<Side>();
		Side[] sides_ReadOnly = theSensorUnit.ParentScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (side != theSide && Module_Side.IsAlliedWithThisSide(theSide, side))
			{
				list2.Add(side);
			}
		}
		try
		{
			GetIntermittentEmission().AttemptToWake_WithDetection(theDetectionRecord.Item1);
			bool flag = myUnit.get_UnitSide(SetSideOnly: false).NewContactsQueue.ContainsKey(item2.ObjectID);
			bool flag2 = UnitIsPreviouslyDetected(item2);
			bool flag3 = myUnit.Sensory.Contacts_Local_ReadOnly.ContainsKey(item2.ObjectID);
			Contact myContact;
			if (flag2)
			{
				myContact = theSide.Contacts[item2.ObjectID];
				if (myContact.HasDetectedEmissions || item.HasDetectedEmissions)
				{
					MergeDetectedEmissions(myContact, item.DetectedEmissions);
				}
			}
			else
			{
				if (flag)
				{
					return;
				}
				myContact = item;
			}
			if (theDetectionRecord.Item7 != null && theDetectionRecord.Item7.Count > 0)
			{
				list = theDetectionRecord.Item7;
			}
			else if (item.UncertaintyArea != null)
			{
				list = item.UncertaintyArea;
			}
			method_12(item3, myContact);
			if (((theSide.AwarenessLevel >= Side.AwarenessLevel_Enum.AutoSideID) | (myContact.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)) && !myContact.SideIsKnown)
			{
				myContact.SideIsKnown = true;
				myContact.RetreivedPostureOnThisPulse = false;
			}
			myContact.set_IDStatus(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: false, bool_5: false, GenerateMessage: false, myContact.IDStatus);
			string name = myContact.Name;
			Contact_Base.IdentificationStatus? nullable_ = default(Contact_Base.IdentificationStatus?);
			Contact_Base.IdentificationStatus? nullable_2 = default(Contact_Base.IdentificationStatus?);
			if (item3.Count != 0)
			{
				Contact_Base.IdentificationStatus? identificationStatus = myContact.IDStatus;
				foreach (Sensor item6 in item3)
				{
					if (flag2)
					{
						method_13(item6, myContact, item2, item4, bool_1: true, ref nullable_, ref nullable_2);
					}
					method_19(myContact, item2, item6);
					AttemptReconOfHostedUnits(myContact, item2, item6);
					method_14(item6, myContact);
					if (!DetectionIsPrecise(item6, item6.ParentPlatform.RangeToUnit_Horiz(myContact.ActualUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)))
					{
						if (!myContact.IsPreciselyLocatedOnThisPulse && (!item2.IsFixedFacility || item6.Type == Sensor.Sensor_Type.ESM))
						{
							if (list == null && theDetectionRecord.Item7 != null)
							{
								list = theDetectionRecord.Item7;
							}
							else if (list != null)
							{
								list = GetRefinedUncertaintyArea_Clipper(list, theDetectionRecord.Item7);
							}
						}
						if (item6.Capabilities.AltitudeInfo || myUnit.IsWeapon)
						{
							myContact.AltitudeIsKnown = true;
						}
					}
					else
					{
						myContact.IsPreciselyLocatedOnThisPulse = true;
					}
				}
				nullable_2 = identificationStatus;
			}
			if (!myContact.ActualUnit.CommStuff.IsConnectedToSideNetwork && (myContact.ActualUnit.get_UnitSide(SetSideOnly: false) == myUnit.get_UnitSide(SetSideOnly: false) || myContact.ActualUnit.get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(myUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) == Misc.PostureStance.Friendly))
			{
				Contact_Base.IdentificationStatus? identificationStatus = myContact.IDStatus;
				foreach (Sensor item7 in item3)
				{
					method_13(item7, myContact, item2, item4, bool_1: false, ref nullable_, ref nullable_2);
				}
				nullable_2 = identificationStatus;
			}
			if ((myContact.IDStatus == Contact_Base.IdentificationStatus.PreciseID || (myContact.IsAircraftContact && myContact.IDStatus == Contact_Base.IdentificationStatus.KnownClass)) && !myContact.ActualUnit.CommStuff.IsConnectedToSideNetwork && (myContact.ActualUnit.get_UnitSide(SetSideOnly: false) == theSide || myContact.ActualUnit.get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(theSide, (Scenario)null) == Misc.PostureStance.Friendly))
			{
				if (flag3)
				{
					myUnit.AddMessage("Contact: " + name + " was identified by " + myUnit.Name + " as " + item2.Name + ", an out-of-comms unit. Dropping contact and updating the unit's last-reported position", "Dropping contact " + name + " (isolated own/friendly unit!)", LoggedMessage.MessageType.ContactChange, 0, new Geopoint_Struct(((Module_Unit.Unit)myContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				if (list != null)
				{
					UpdateContactData(ref myUnit, ref myContact, item2, !flag2, list);
				}
				else
				{
					UpdateContactData(ref myUnit, ref myContact, item2, !flag2);
				}
				myContact.ActualUnit.setLastReportedInfo(((Module_Unit.Unit)myContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myContact.CurrentHeading, myUnit.ObjectID);
				return;
			}
			if (!flag2)
			{
				nullable_ = Contact_Base.IdentificationStatus.KnownDomain;
				nullable_2 = Contact_Base.IdentificationStatus.Unknown;
				List<ActiveUnit> list3 = new List<ActiveUnit>();
				Side[] sides_ReadOnly2 = myUnit.ParentScen.Sides_ReadOnly;
				foreach (Side side2 in sides_ReadOnly2)
				{
					if (side2 != myUnit.get_UnitSide(SetSideOnly: false) && side2.get_ConsidersThisSideToBe(myUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Friendly)
					{
						continue;
					}
					foreach (ActiveUnit unit in side2.Units)
					{
						if (!unit.CommStuff.IsConnectedToSideNetwork)
						{
							list3.Add(unit);
						}
					}
				}
				if (list3.Count > 0)
				{
					if (list != null)
					{
						UpdateContactData(ref myUnit, ref myContact, item2, ContactIsNew: true, list);
					}
					else
					{
						UpdateContactData(ref myUnit, ref myContact, item2, ContactIsNew: true);
					}
					foreach (ActiveUnit item8 in list3)
					{
						_ = Debugger.IsAttached;
						if (((item8.IsAircraft && myContact.IsAircraftContact) || (item8.IsShip && myContact.IsShipContact) || (item8.IsSubmarine && myContact.IsSubmergedContact) || (item8.IsFacility && myContact.Type == Contact_Base.ContactType.Facility_Mobile) || (item8.IsAggregatedUnit && myContact.Type == Contact_Base.ContactType.AggregateGroundUnit)) && !(Module_Unit.RangeToPoint_Horiz(myContact, item8.Latitude_LastReported.Value, item8.Longitude_LastReported.Value) >= 1f))
						{
							item8.setLastReportedInfo(((Module_Unit.Unit)myContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myContact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)myContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), myContact.CurrentHeading, myUnit.ObjectID);
							return;
						}
					}
				}
				myContact.UncertaintyArea = list;
				ProcessNewContact(ref myContact, ref theSensorUnit.ParentScen, theSide, item2, item5, theSensorUnit, Contact_Base.IdentificationStatus.KnownDomain, item3);
			}
			else if (list == null)
			{
				UpdateContactData(ref myUnit, ref myContact, item2, ContactIsNew: false);
			}
			else
			{
				UpdateContactData(ref myUnit, ref myContact, item2, ContactIsNew: false, list);
			}
			method_15(item, item3);
			List<EventTrigger> list4 = new List<EventTrigger>();
			if (nullable_.HasValue && nullable_2.HasValue)
			{
				if (item5 == SpecialDetectionMode.None)
				{
					foreach (EventTrigger value in theSensorUnit.ParentScen.EventTriggers.Values)
					{
						if (value.Type == EventTrigger.EventTriggerType.UnitDetected)
						{
							if (((EventTrigger_UnitDetected)value).get_IsFulfilled(item2, myUnit, flag, nullable_.Value, nullable_2, item3))
							{
								list4.Add(value);
							}
						}
						else if (value.Type == EventTrigger.EventTriggerType.UnitEmissions && ((EventTrigger_UnitEmissions)value).get_IsFulfilled(item2, myUnit, flag, nullable_.Value, nullable_2, item3))
						{
							list4.Add(value);
						}
					}
				}
			}
			else if (myContact != null)
			{
				foreach (EventTrigger value2 in myUnit.ParentScen.EventTriggers.Values)
				{
					if (value2.Type == EventTrigger.EventTriggerType.UnitDetected)
					{
						if (((EventTrigger_UnitDetected)value2).Area.Count <= 0)
						{
							continue;
						}
						if (((Module_Unit.Unit)myContact).get_IsInsideThisArea(((EventTrigger_UnitDetected)value2).Area, myUnit.ParentScen, UseCache: false))
						{
							if (((EventTrigger_UnitDetected)value2).get_IsFulfilled(item2, theSensorUnit, flag, Contact_Base.IdentificationStatus.Unknown, nullable_2, item3))
							{
								list4.Add(value2);
							}
						}
						else if (myContact.ActiveEnterAreaTriggers.Count > 0)
						{
							item2.ActiveEnterAreaTriggers.Remove(((EventTrigger_UnitDetected)value2).ObjectID);
						}
					}
					else if (value2.Type == EventTrigger.EventTriggerType.UnitEmissions && ((EventTrigger_UnitEmissions)value2).get_IsFulfilled(item2, myUnit, flag, Contact_Base.IdentificationStatus.Unknown, nullable_2, item3))
					{
						list4.Add(value2);
					}
				}
			}
			if (list4 != null && list4.Count > 0)
			{
				theSensorUnit.ParentScen.FireEvents(list4);
			}
			if (flag3)
			{
				UpdateContactData_Local(ref item2.ObjectID, item3);
			}
			else
			{
				NewContactsQueue_Local.AddIfNotExistsElseUpdate(item2.ObjectID, myContact);
				UpdateContactData_Local(ref item2.ObjectID, item3);
			}
			if (myContact == null)
			{
				return;
			}
			string objectID = myUnit.ObjectID;
			if (theDetectionRecord.Item5 == SpecialDetectionMode.LuaScript)
			{
				objectID = theSensorUnit.ObjectID;
			}
			foreach (Sensor item9 in theDetectionRecord.Item3)
			{
				myContact.AddDetectionRecord(new Contact.Detection_Struct(objectID, item9, theDetectionRecord.Item4, theDetectionRecord.Item5, theDetectionRecord.Item6));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 100249", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static bool ContactsAreOfSameActualUnit(Contact ContactA, Contact ContactB)
	{
		if (ContactA.Type != ContactB.Type)
		{
			return false;
		}
		if (ContactA.ActualUnit == ContactB.ActualUnit)
		{
			return true;
		}
		if (string.CompareOrdinal(ContactA.ActualUnit.ObjectID, ContactB.ActualUnit.ObjectID) != 0)
		{
			return false;
		}
		return true;
	}

	private void method_13(Sensor sensor_1, Contact contact_0, ActiveUnit activeUnit_0, float float_0, bool bool_1, ref Contact_Base.IdentificationStatus? nullable_0, ref Contact_Base.IdentificationStatus? nullable_1)
	{
		if (contact_0.ActualUnit.isUAV)
		{
			contact_0.Type = Contact_Base.ContactType.Air;
		}
		if (sensor_1.Capabilities.HeadingInfo)
		{
			contact_0.HeadingIsKnown = true;
		}
		if (sensor_1.Capabilities.SpeedInfo)
		{
			contact_0.SpeedIsKnown = true;
		}
		if (sensor_1.Capabilities.AltitudeInfo || myUnit.IsWeapon)
		{
			contact_0.AltitudeIsKnown = true;
		}
		nullable_1 = contact_0.IDStatus;
		int num2;
		bool isNCTRupdate;
		short? num;
		short iDStatus;
		switch (contact_0.Type)
		{
		default:
			num = (short?)nullable_1;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= 4)) != true)
			{
				num2 = 0;
				goto IL_01a5;
			}
			break;
		case Contact_Base.ContactType.Missile:
			num = (short?)nullable_1;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= 3)) != true)
			{
				num2 = 0;
				goto IL_01a5;
			}
			break;
		case Contact_Base.ContactType.Air:
			{
				num = (short?)nullable_1;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() >= 3)) != true)
				{
					num2 = 0;
					goto IL_01a5;
				}
				break;
			}
			IL_01a5:
			isNCTRupdate = (byte)num2 != 0;
			switch (sensor_1.Type)
			{
			case Sensor.Sensor_Type.ESM:
				nullable_0 = Contact_Base.IdentificationStatus.KnownDomain;
				if (sensor_1.Role != Sensor.Sensor_Role.ESM_RWR)
				{
					method_17(contact_0, float_0);
					if (contact_0.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
					{
						nullable_0 = method_25(contact_0, activeUnit_0, sensor_1);
					}
				}
				break;
			case Sensor.Sensor_Type.Radar:
				if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
				{
					break;
				}
				if (contact_0.IsAir_Missile_Orbital_Contact)
				{
					nullable_0 = method_24(contact_0, activeUnit_0, sensor_1, float_0);
					if (nullable_0.HasValue)
					{
						isNCTRupdate = true;
					}
				}
				else
				{
					nullable_0 = method_23(contact_0, activeUnit_0, sensor_1, float_0);
				}
				break;
			case Sensor.Sensor_Type.Visual:
			{
				float num3 = sensor_1.MaxIDRangeOnThisTarget(myUnit, activeUnit_0);
				if (float_0 < num3)
				{
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Missile:
						nullable_0 = Contact_Base.IdentificationStatus.KnownType;
						break;
					case Contact_Base.ContactType.Surface:
						nullable_0 = Contact_Base.IdentificationStatus.PreciseID;
						break;
					case Contact_Base.ContactType.Submarine:
						if (!((Submarine)contact_0.ActualUnit).IsSurfaced)
						{
							nullable_0 = Contact_Base.IdentificationStatus.KnownType;
						}
						else
						{
							nullable_0 = Contact_Base.IdentificationStatus.KnownClass;
						}
						break;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Orbital:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.Torpedo:
					case Contact_Base.ContactType.Mine:
					case Contact_Base.ContactType.AggregateGroundUnit:
						nullable_0 = Contact_Base.IdentificationStatus.KnownClass;
						break;
					}
				}
				else if (float_0 < num3 * 3f)
				{
					nullable_0 = Contact_Base.IdentificationStatus.KnownType;
				}
				else
				{
					nullable_0 = Contact_Base.IdentificationStatus.KnownDomain;
				}
				break;
			}
			case Sensor.Sensor_Type.Infrared:
			{
				if (!sensor_1.Codes.Classification)
				{
					break;
				}
				float num4 = sensor_1.MaxIDRangeOnThisTarget(myUnit, activeUnit_0);
				if (float_0 < num4)
				{
					switch (contact_0.Type)
					{
					case Contact_Base.ContactType.Missile:
						nullable_0 = Contact_Base.IdentificationStatus.KnownType;
						break;
					case Contact_Base.ContactType.Air:
					case Contact_Base.ContactType.Surface:
					case Contact_Base.ContactType.Orbital:
					case Contact_Base.ContactType.Facility_Mobile:
					case Contact_Base.ContactType.Torpedo:
					case Contact_Base.ContactType.Mine:
					case Contact_Base.ContactType.AggregateGroundUnit:
						nullable_0 = Contact_Base.IdentificationStatus.KnownClass;
						break;
					}
				}
				else if (float_0 < num4 * 3f)
				{
					nullable_0 = Contact_Base.IdentificationStatus.KnownType;
				}
				else
				{
					nullable_0 = Contact_Base.IdentificationStatus.KnownDomain;
				}
				break;
			}
			case Sensor.Sensor_Type.HullSonar_PassiveOnly:
			case Sensor.Sensor_Type.HullSonar_ActivePassive:
			case Sensor.Sensor_Type.TowedArray_PassiveOnly:
			case Sensor.Sensor_Type.TowedArray_ActivePassive:
			case Sensor.Sensor_Type.VDS_PassiveOnly:
			case Sensor.Sensor_Type.VDS_ActivePassive:
			case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
			case Sensor.Sensor_Type.DippingSonar_ActivePassive:
			case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
				if (!sensor_1.IsActive())
				{
					method_16(contact_0, float_0);
					nullable_0 = method_26(contact_0, activeUnit_0, sensor_1);
				}
				break;
			}
			if (myUnit.get_UnitSide(SetSideOnly: false).AwarenessLevel >= Side.AwarenessLevel_Enum.AutoSideAndUnitID)
			{
				nullable_0 = Contact_Base.IdentificationStatus.PreciseID;
			}
			if (nullable_0.HasValue)
			{
				num = (short?)nullable_0;
				iDStatus = (short)contact_0.IDStatus;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() != iDStatus)) == true)
				{
					if (contact_0.UncertaintyArea != null)
					{
						contact_0.set_IDStatus(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), sensor_1, (float?)(float)Math.Round(Module_Unit.RangeToUnit_Slant(myUnit, contact_0), 1), isNCTRupdate, myUnit.CommStuff.IsConnectedToSideNetwork, bool_5: true, bool_1, nullable_0.Value);
					}
					else
					{
						contact_0.set_IDStatus(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), sensor_1, (float?)(float)Math.Round(float_0, 1), isNCTRupdate, myUnit.CommStuff.IsConnectedToSideNetwork, bool_5: true, bool_1, nullable_0.Value);
					}
				}
			}
			num = (short?)nullable_0;
			iDStatus = (short)contact_0.IDStatus;
			if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() != iDStatus)) == true)
			{
				nullable_0 = contact_0.IDStatus;
			}
			break;
		}
	}

	private void method_14(Sensor sensor_1, Contact contact_0)
	{
		if (string.IsNullOrEmpty(contact_0.Name))
		{
			contact_0.set_IDStatus(myUnit.ParentScen, myUnit.get_UnitSide(SetSideOnly: false), (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: false, bool_5: false, GenerateMessage: false, contact_0.IDStatus);
		}
		switch (sensor_1.Type)
		{
		case Sensor.Sensor_Type.ESM:
			contact_0.TimeSinceDetection_ESM = 0f;
			break;
		case Sensor.Sensor_Type.Visual:
			contact_0.TimeSinceDetection_Visual = 0f;
			break;
		case Sensor.Sensor_Type.Infrared:
			contact_0.TimeSinceDetection_Infrared = 0f;
			break;
		case Sensor.Sensor_Type.Radar:
		case Sensor.Sensor_Type.PCLS:
			contact_0.TimeSinceDetection_Radar = 0f;
			break;
		case Sensor.Sensor_Type.PingIntercept:
			contact_0.TimeSinceDetection_SonarPassive = 0f;
			break;
		case Sensor.Sensor_Type.HullSonar_PassiveOnly:
		case Sensor.Sensor_Type.HullSonar_ActivePassive:
		case Sensor.Sensor_Type.HullSonar_ActiveOnly:
		case Sensor.Sensor_Type.TowedArray_PassiveOnly:
		case Sensor.Sensor_Type.TowedArray_ActivePassive:
		case Sensor.Sensor_Type.TowedArray_ActiveOnly:
		case Sensor.Sensor_Type.VDS_PassiveOnly:
		case Sensor.Sensor_Type.VDS_ActivePassive:
		case Sensor.Sensor_Type.VDS_ActiveOnly:
		case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
		case Sensor.Sensor_Type.DippingSonar_ActivePassive:
		case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
		case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
			if (sensor_1.HasActiveModeOnly)
			{
				contact_0.TimeSinceDetection_SonarActive = 0f;
			}
			else if (!sensor_1.IsActive())
			{
				contact_0.TimeSinceDetection_SonarPassive = 0f;
			}
			else
			{
				contact_0.TimeSinceDetection_SonarActive = 0f;
			}
			break;
		}
	}

	internal bool UnitIsPreviouslyDetected(ActiveUnit theUnit)
	{
		try
		{
			if (myUnit.get_UnitSide(SetSideOnly: false) != null)
			{
				if (!myUnit.CommStuff.IsConnectedToSideNetwork)
				{
					return _ContactsList_OffGrid.ContainsKey(theUnit.ObjectID);
				}
				return myUnit.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(theUnit.ObjectID);
			}
			return false;
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

	protected virtual void HandleDetectedContact_OffGrid((Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>) theDetectionRecord)
	{
		var (contact, activeUnit, list, float_, specialDetectionMode, _, _) = theDetectionRecord;
		try
		{
			List<Geopoint_Struct> list2 = null;
			_ = contact.DetectedEmissions;
			bool flag = myUnit.get_UnitSide(SetSideOnly: false).NewContactsQueue.ContainsKey(activeUnit.ObjectID);
			bool flag2 = UnitIsPreviouslyDetected(activeUnit);
			bool flag3 = myUnit.Sensory.Contacts_Local_ReadOnly.ContainsKey(activeUnit.ObjectID);
			Contact myContact;
			if (!flag2)
			{
				if (flag)
				{
					return;
				}
				myContact = contact;
			}
			else
			{
				myContact = _ContactsList_OffGrid[activeUnit.ObjectID];
				if (myContact.HasDetectedEmissions || contact.HasDetectedEmissions)
				{
					MergeDetectedEmissions(myContact, contact.DetectedEmissions);
				}
			}
			if (specialDetectionMode != SpecialDetectionMode.None)
			{
				if (theDetectionRecord.Item7 != null && theDetectionRecord.Item7.Count > 0)
				{
					list2 = theDetectionRecord.Item7;
				}
				else if (contact.UncertaintyArea != null)
				{
					list2 = contact.UncertaintyArea;
				}
			}
			method_12(list, myContact);
			if (myUnit.get_UnitSide(SetSideOnly: false).AwarenessLevel >= Side.AwarenessLevel_Enum.AutoSideID && !myContact.SideIsKnown)
			{
				myContact.SideIsKnown = true;
			}
			if (list.Count != 0)
			{
				Contact_Base.IdentificationStatus? nullable_ = default(Contact_Base.IdentificationStatus?);
				Contact_Base.IdentificationStatus? nullable_2 = default(Contact_Base.IdentificationStatus?);
				foreach (Sensor item in list)
				{
					if (flag2)
					{
						method_13(item, myContact, activeUnit, float_, bool_1: true, ref nullable_, ref nullable_2);
					}
					method_14(item, myContact);
					method_19(myContact, activeUnit, item);
					AttemptReconOfHostedUnits(myContact, activeUnit, item);
					if (DetectionIsPrecise(item, item.ParentPlatform.RangeToUnit_Horiz(myContact.ActualUnit)))
					{
						if (myContact.UncertaintyArea != null)
						{
							myContact.ChangedToFirmOnThisPulse = true;
						}
						myContact.IsPreciselyLocatedOnThisPulse = true;
						myContact.UncertaintyArea = null;
						continue;
					}
					if (!myContact.IsPreciselyLocatedOnThisPulse && (!activeUnit.IsFixedFacility || item.Type == Sensor.Sensor_Type.ESM))
					{
						list2 = ((list2 == null) ? theDetectionRecord.Item7 : GetRefinedUncertaintyArea_Clipper(list2, theDetectionRecord.Item7));
					}
					if (item.Capabilities.AltitudeInfo || myUnit.IsWeapon)
					{
						myContact.AltitudeIsKnown = true;
					}
				}
			}
			if (!flag2)
			{
				myContact.UncertaintyArea = list2;
			}
			else if (list2 == null)
			{
				UpdateContactData(ref myUnit, ref myContact, activeUnit, ContactIsNew: false);
			}
			else
			{
				UpdateContactData(ref myUnit, ref myContact, activeUnit, ContactIsNew: false, list2);
			}
			method_15(contact, list);
			if (myContact.IsWeaponContact && myUnit.AI.ContactAppearsToBeInterceptingMe(myContact))
			{
				myContact.set_Stance(myUnit.get_UnitSide(SetSideOnly: false), MarkManually: false, Misc.PostureStance.Hostile);
			}
			if (!flag2 && !_ContactsList_OffGrid.ContainsKey(activeUnit.ObjectID))
			{
				_ContactsList_OffGrid.Add(activeUnit.ObjectID, myContact);
			}
			if (flag3)
			{
				UpdateContactData_Local(ref activeUnit.ObjectID, list);
			}
			else
			{
				NewContactsQueue_Local.AddIfNotExistsElseUpdate(activeUnit.ObjectID, myContact);
				UpdateContactData_Local(ref activeUnit.ObjectID, list);
			}
			if (myContact == null)
			{
				return;
			}
			foreach (Sensor item2 in theDetectionRecord.Item3)
			{
				myContact.AddDetectionRecord(new Contact.Detection_Struct(myUnit.ObjectID, item2, theDetectionRecord.Item4, theDetectionRecord.Item5, theDetectionRecord.Item6));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at 100249", "");
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public void HandleAssumedWeaponContactFromGuidanceDetection(Contact GuidingContact, Sensor SensorThatMadeDetection, Sensor DetectedEmitterSensor, float DetectionRange, Dictionary<int, EmissionContainer> DetectedEmissions)
	{
		Weapon weapon = null;
		bool flag = true;
		Contact myContact = null;
		PooledList<Weapon> pooledList = new PooledList<Weapon>(DetectedEmitterSensor.SemiActiveWeaponsGuided);
		foreach (Weapon item in pooledList)
		{
			if (item.AI.PrimaryTarget != null && item.AI.PrimaryTarget.ActualUnit == myUnit)
			{
				if (myUnit.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(item.ObjectID))
				{
					flag = false;
					myContact = myUnit.get_UnitSide(SetSideOnly: false).Contacts[item.ObjectID];
					weapon = item;
					break;
				}
				weapon = item;
			}
		}
		pooledList.Dispose();
		if (weapon == null)
		{
			return;
		}
		if (flag)
		{
			myContact = Contact.Instantiate(weapon);
		}
		if (myContact != null && (flag || (myContact.UncertaintyArea != null && myContact.RemainingContinousTrackTime < 1f)))
		{
			float num = myUnit.RangeToUnit_Horiz(GuidingContact);
			List<Geopoint_Struct> uncertaintyArea = GetUncertaintyArea(SensorThatMadeDetection, GuidingContact, num, DetectedEmissions, num);
			if (myContact.LastDetections.Count != 0 && !string.IsNullOrEmpty(myContact.LastDetections.ElementAt(myContact.LastDetections.Count - 1).DetectingSensorID))
			{
				UpdateContactData(ref myUnit, ref myContact, myContact.ActualUnit, ContactIsNew: false, uncertaintyArea);
			}
			else
			{
				((Module_Unit.Unit)myContact).set_Latitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)GuidingContact).get_Latitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)myContact).set_Longitude((GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)GuidingContact).get_Longitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)myContact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, ((Module_Unit.Unit)GuidingContact).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				myContact.CurrentHeading = GuidingContact.CurrentHeading;
				myContact.UncertaintyArea = uncertaintyArea;
			}
			SuccessfulDetectionsOnThisPulse.Enqueue((myContact, weapon, new List<Sensor>(), 0f, SpecialDetectionMode.MissileAssumedFromSemiActiveIllumination, myUnit.ParentScen.Time, myContact.UncertaintyArea));
		}
	}

	private void method_15(Contact contact_0, List<Sensor> list_1)
	{
		checked
		{
			Weapon weapon;
			bool flag6;
			switch (contact_0.Type)
			{
			case Contact_Base.ContactType.Torpedo:
			{
				Weapon weapon2 = (Weapon)contact_0.ActualUnit;
				if (weapon2.FiringParent == null || !weapon2.FiringParent.IsSubmarine)
				{
					break;
				}
				bool flag4 = false;
				foreach (Contact contacts_ in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
				{
					if (contacts_.Type == Contact_Base.ContactType.Submarine && myUnit.RangeToUnit_Horiz(contacts_) <= 15f && !(Math.Abs(MathFunctions.AngularDifference(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_).get_Longitude((GlobalVariables.BooleanObject)null)), Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null)))) >= 45f))
					{
						flag4 = true;
						break;
					}
				}
				if (flag4)
				{
					break;
				}
				bool flag5 = default(bool);
				foreach (Contact contacts_2 in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
				{
					if (contacts_2.Type == Contact_Base.ContactType.Submarine && contacts_2.ActualUnit == ((Weapon)contact_0.ActualUnit).FiringParent)
					{
						flag5 = true;
						break;
					}
				}
				if (!flag5 && weapon2.FiringParent.IsMorituri)
				{
					flag5 = true;
				}
				if (!flag5)
				{
					Contact contact2 = Contact.Instantiate(((Weapon)contact_0.ActualUnit).FiringParent);
					((Module_Unit.Unit)contact2).set_Latitude((GlobalVariables.BooleanObject)null, contact_0.ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null));
					((Module_Unit.Unit)contact2).set_Longitude((GlobalVariables.BooleanObject)null, contact_0.ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null));
					Geodesic_Vincenty.Point3D[] CirclePoints2 = new Geodesic_Vincenty.Point3D[46];
					Geodesic_EdWilliams.CircleFromPoint(((Module_Unit.Unit)contact2).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact2).get_Longitude((GlobalVariables.BooleanObject)null), 10.0, 45, ref CirclePoints2);
					List<Geopoint_Struct> list2 = new List<Geopoint_Struct>();
					Geodesic_Vincenty.Point3D[] array2 = CirclePoints2;
					for (int j = 0; j < array2.Length; j++)
					{
						Geodesic_Vincenty.Point3D point3D2 = array2[j];
						list2.Add(new Geopoint_Struct(point3D2.X, point3D2.Y));
					}
					contact2.UncertaintyArea = list2;
					SuccessfulDetectionsOnThisPulse.Enqueue((contact2, ((Weapon)contact_0.ActualUnit).FiringParent, new List<Sensor>(), 0f, SpecialDetectionMode.SubAssumedFromTorpedoDetection, myUnit.ParentScen.Time, list2));
				}
				break;
			}
			case Contact_Base.ContactType.Missile:
				{
					weapon = (Weapon)contact_0.ActualUnit;
					if (weapon.IsDecoy || weapon.FiringParent == null)
					{
						break;
					}
					Contact value;
					if (weapon.FiringParent.IsSubmarine)
					{
						if (weapon.RangeToUnit_Horiz(weapon.FiringParent) < 5f)
						{
							bool flag = false;
							foreach (Contact contacts_3 in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
							{
								if (contacts_3.Type == Contact_Base.ContactType.Submarine && !(Math.Abs(MathFunctions.AngularDifference(Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_3).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contacts_3).get_Longitude((GlobalVariables.BooleanObject)null)), Math2.CalcAzimuth(myUnit.get_Latitude((GlobalVariables.BooleanObject)null), myUnit.get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null)))) >= 45f))
								{
									flag = true;
									break;
								}
							}
							if (!flag)
							{
								bool flag2 = default(bool);
								foreach (Contact contacts_4 in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
								{
									if (contacts_4.Type == Contact_Base.ContactType.Submarine && contacts_4.ActualUnit == ((Weapon)contact_0.ActualUnit).FiringParent)
									{
										flag2 = true;
										break;
									}
								}
								if (!flag2)
								{
									Contact contact = Contact.Instantiate(((Weapon)contact_0.ActualUnit).FiringParent);
									((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, contact_0.ActualUnit.get_Latitude((GlobalVariables.BooleanObject)null));
									((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, contact_0.ActualUnit.get_Longitude((GlobalVariables.BooleanObject)null));
									Geodesic_Vincenty.Point3D[] CirclePoints = new Geodesic_Vincenty.Point3D[46];
									Geodesic_EdWilliams.CircleFromPoint(((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), 1.0, 45, ref CirclePoints);
									List<Geopoint_Struct> list = new List<Geopoint_Struct>();
									Geodesic_Vincenty.Point3D[] array = CirclePoints;
									for (int i = 0; i < array.Length; i++)
									{
										Geodesic_Vincenty.Point3D point3D = array[i];
										list.Add(new Geopoint_Struct(point3D.X, point3D.Y));
									}
									contact.UncertaintyArea = list;
									SuccessfulDetectionsOnThisPulse.Enqueue((contact, ((Weapon)contact_0.ActualUnit).FiringParent, new List<Sensor>(), 0f, SpecialDetectionMode.SubAssumedFromMissileDetection, myUnit.ParentScen.Time, list));
								}
							}
						}
					}
					else if (myUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(weapon.FiringParent.ObjectID, out value) && value.get_Stance(myUnit.get_UnitSide(SetSideOnly: false)) != Misc.PostureStance.Hostile && weapon.AI.PrimaryTarget != null && weapon.AI.PrimaryTarget.Type != Contact_Base.ContactType.ActivationPoint && weapon.AI.PrimaryTarget.Type != Contact_Base.ContactType.Aimpoint)
					{
						Contact primaryTarget = weapon.AI.PrimaryTarget;
						if (primaryTarget.ActualUnit != null)
						{
							int num;
							if (primaryTarget.ActualUnit.get_UnitSide(SetSideOnly: false) != myUnit.get_UnitSide(SetSideOnly: false))
							{
								if (primaryTarget.ActualUnit.get_UnitSide(SetSideOnly: false).get_ConsidersThisSideToBe(myUnit.get_UnitSide(SetSideOnly: false), (Scenario)null) != Misc.PostureStance.Friendly)
								{
									goto IL_072a;
								}
								num = 0;
							}
							else
							{
								num = 0;
							}
							bool flag3 = unchecked((byte)num) != 0;
							string text = "";
							if (value.IDStatus > Contact_Base.IdentificationStatus.KnownDomain)
							{
								flag3 = true;
								text = " (Reason: Contact type)";
							}
							if (!flag3)
							{
								foreach (int key in value.DetectedEmissions.Keys)
								{
									Sensor sensor = value.DetectedEmissions[key].get_AssociatedSensor(key, myUnit.ParentScen);
									if (sensor.IsPureIlluminator || sensor.IsFireControlRadar)
									{
										flag3 = true;
										text = " (Reason: Emissions pattern)";
										break;
									}
								}
							}
							if (flag3)
							{
								value.set_Stance(myUnit.get_UnitSide(SetSideOnly: false), MarkManually: false, Misc.PostureStance.Hostile);
								myUnit.ParentScen.AddMessage("Contact: " + value.Name + " is the most likely firing unit of " + contact_0.Name + " and is now considered as hostile!" + text, value.Name + " is now HOSTILE!", LoggedMessage.MessageType.ContactChange, 0, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null)));
							}
						}
					}
					goto IL_072a;
				}
				IL_072a:
				if ((!weapon.FiringParent.IsMobileGroundUnit && !weapon.FiringParent.IsFacility) || list_1.Where([SpecialName] (Sensor theS) => theS.Role == Sensor.Sensor_Role.CounterBattery).Count() <= 0)
				{
					break;
				}
				flag6 = false;
				foreach (Contact contacts_5 in myUnit.get_UnitSide(SetSideOnly: false).Contacts_List)
				{
					if (contacts_5.IsGroundContact && contacts_5.IDStatus >= Contact_Base.IdentificationStatus.KnownType)
					{
						bool? flag7 = contacts_5.ActualUnit?.IsFacility;
						if ((((flag7 ?? true) && ((Facility)contacts_5.ActualUnit).IsArtillery() && flag7.HasValue) || (contacts_5.ActualUnit.IsMobileGroundUnit && ((IMobileGroundUnit)contacts_5.ActualUnit).IsArtillery())) && !(Module_Unit.RangeToPoint_Horiz(contacts_5, weapon.LaunchPoint) > 1f))
						{
							flag6 = false;
							break;
						}
					}
				}
				if (!flag6)
				{
					Contact contact3 = Contact.Instantiate(((Weapon)contact_0.ActualUnit).FiringParent);
					float bearing = new LockRandom().Next(0, 360);
					double longitude = weapon.LaunchPoint.Longitude;
					double latitude = weapon.LaunchPoint.Latitude;
					Contact contact4;
					double out_lon = ((Module_Unit.Unit)(contact4 = contact3)).get_Longitude((GlobalVariables.BooleanObject)null);
					Contact contact5;
					double out_lat = ((Module_Unit.Unit)(contact5 = contact3)).get_Latitude((GlobalVariables.BooleanObject)null);
					Geodesic_EdWilliams.CalcPoint_Williams(longitude, latitude, ref out_lon, ref out_lat, 0.8, bearing);
					((Module_Unit.Unit)contact5).set_Latitude((GlobalVariables.BooleanObject)null, out_lat);
					((Module_Unit.Unit)contact4).set_Longitude((GlobalVariables.BooleanObject)null, out_lon);
					Geodesic_Vincenty.Point3D[] CirclePoints3 = new Geodesic_Vincenty.Point3D[46];
					Geodesic_EdWilliams.CircleFromPoint(((Module_Unit.Unit)contact3).get_Latitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact3).get_Longitude((GlobalVariables.BooleanObject)null), 1.0, 45, ref CirclePoints3);
					List<Geopoint_Struct> list3 = new List<Geopoint_Struct>();
					Geodesic_Vincenty.Point3D[] array3 = CirclePoints3;
					for (int num2 = 0; num2 < array3.Length; num2++)
					{
						Geodesic_Vincenty.Point3D point3D3 = array3[num2];
						list3.Add(new Geopoint_Struct(point3D3.X, point3D3.Y));
					}
					contact3.UncertaintyArea = list3;
					SuccessfulDetectionsOnThisPulse.Enqueue((contact3, ((Weapon)contact_0.ActualUnit).FiringParent, new List<Sensor>(), 0f, SpecialDetectionMode.CounterBatteryTrack, myUnit.ParentScen.Time, list3));
				}
				break;
			}
		}
	}

	protected virtual void HandleDetectedBaseContact(Module_Unit.Unit theDetectedUnit, Side theSide)
	{
		try
		{
			bool flag = theSide.BaseContacts.ContainsKey(theDetectedUnit.ObjectID);
			bool flag2 = theSide.NewBaseContactsQueue.ContainsKey(theDetectedUnit.ObjectID);
			Contact contact;
			if (flag)
			{
				contact = theSide.BaseContacts[theDetectedUnit.ObjectID];
			}
			else
			{
				if (flag2)
				{
					return;
				}
				contact = Contact.Instantiate((ActiveUnit)theDetectedUnit);
			}
			contact.SideIsKnown = true;
			if (flag)
			{
				contact.CurrentHeading = theDetectedUnit.CurrentHeading;
				contact.CurrentSpeed = theDetectedUnit.CurrentSpeed;
				((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theDetectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, theDetectedUnit.get_Longitude((GlobalVariables.BooleanObject)null));
				((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, theDetectedUnit.get_Latitude((GlobalVariables.BooleanObject)null));
			}
			else
			{
				ProcessNewBaseContact(contact, ref myUnit.ParentScen, theSide, theDetectedUnit, myUnit, Contact_Base.IdentificationStatus.PreciseID);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100250", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_16(Contact contact_0, float float_0)
	{
		if (contact_0.HeadingIsKnown && contact_0.SpeedIsKnown && contact_0.AltitudeIsKnown)
		{
			return;
		}
		float num = TMASolution_Sonar(contact_0, float_0);
		if (!(num < 0.5f))
		{
			if (num < 0.65f)
			{
				contact_0.SpeedIsKnown = true;
			}
			else if (num < 0.85f)
			{
				contact_0.SpeedIsKnown = true;
				contact_0.HeadingIsKnown = true;
			}
			else
			{
				contact_0.SpeedIsKnown = true;
				contact_0.HeadingIsKnown = true;
				contact_0.AltitudeIsKnown = true;
			}
		}
	}

	private void method_17(Contact contact_0, float float_0)
	{
		if (contact_0.HeadingIsKnown && contact_0.SpeedIsKnown)
		{
			return;
		}
		if (Information.IsNothing((object)contact_0.UncertaintyArea))
		{
			contact_0.SpeedIsKnown = true;
			contact_0.HeadingIsKnown = true;
			return;
		}
		float num = TMASolution_ESM(contact_0, float_0);
		if (!(num < 0.5f))
		{
			if (num < 0.75f)
			{
				contact_0.HeadingIsKnown = true;
				return;
			}
			contact_0.SpeedIsKnown = true;
			contact_0.HeadingIsKnown = true;
		}
	}

	public void AddNewHostedUnitReconRecord(ActiveUnit theAU, Contact theHostContact, Sensor theS)
	{
		Contact.HostedUnitReconRecord hostedUnitReconRecord = new Contact.HostedUnitReconRecord();
		hostedUnitReconRecord.UnitID = theAU.ObjectID;
		hostedUnitReconRecord.ReconAge = 0f;
		hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownDomain;
		theHostContact.Recon_HostedUnits(myUnit.get_UnitSide(SetSideOnly: false)).Add(hostedUnitReconRecord);
		LoggedMessage.MessageType messageType = LoggedMessage.MessageType.ContactChange;
		if (!myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			messageType = LoggedMessage.MessageType.CommsIsolatedMessage;
		}
		myUnit.AddMessage("New " + theAU.UnitType_String.ToLower() + " spotted on " + theHostContact.Name + " by " + myUnit.Name + " (Sensor: " + theS.Name + "). ", "Contact report", messageType, 0, new Geopoint_Struct(((Module_Unit.Unit)theHostContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theHostContact).get_Latitude((GlobalVariables.BooleanObject)null)));
	}

	private void method_18(AirFacility airFacility_0, Sensor sensor_1, Contact contact_0, float float_0)
	{
		if (!airFacility_0.IsOpenAirFacility || airFacility_0.HostedAircraft.Count == 0)
		{
			return;
		}
		LoggedMessage.MessageType messageType = LoggedMessage.MessageType.ContactChange;
		if (!myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			messageType = LoggedMessage.MessageType.CommsIsolatedMessage;
		}
		float num = default(float);
		foreach (Aircraft value2 in airFacility_0.HostedAircraft.Values)
		{
			num = sensor_1.MaxIDRangeOnThisTarget(myUnit, value2);
			if (!(num * 3f >= float_0))
			{
				continue;
			}
			Contact.HostedUnitReconRecord hostedUnitReconRecord = null;
			List<Contact.HostedUnitReconRecord> list = new List<Contact.HostedUnitReconRecord>(contact_0.Recon_HostedUnits(myUnit.get_UnitSide(SetSideOnly: false)));
			foreach (Contact.HostedUnitReconRecord item in list)
			{
				if (Operators.CompareString(item.UnitID, value2.ObjectID, false) == 0)
				{
					hostedUnitReconRecord = item;
					hostedUnitReconRecord.ReconAge = 0f;
					break;
				}
			}
			if (hostedUnitReconRecord != null)
			{
				if (float_0 < num)
				{
					if (hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
					{
						hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownClass;
						myUnit.AddMessage("Aircraft previously spotted on " + contact_0.Name + " has been identified as: " + value2.UnitClass + " (recon by: " + myUnit.Name + " - Sensor: " + sensor_1.Name + "). ", "Contact report", messageType, 0, new Geopoint_Struct(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else if (float_0 < num * 2f && hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownType)
				{
					hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownType;
					myUnit.AddMessage("Aircraft previously spotted on " + contact_0.Name + " has been type-classified as: " + value2.SubTypeDescription + " (recon by: " + myUnit.Name + " - Sensor: " + sensor_1.Name + "). ", "Contact report", messageType, 0, new Geopoint_Struct(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				hostedUnitReconRecord.ReconAge = 0f;
			}
			else
			{
				AddNewHostedUnitReconRecord(value2, contact_0, sensor_1);
			}
			contact_0.TimeSinceRecon = 0f;
		}
		Lazy<List<Contact.HostedUnitReconRecord>> lazy = new Lazy<List<Contact.HostedUnitReconRecord>>();
		List<Contact.HostedUnitReconRecord> list2 = contact_0.Recon_HostedUnits(myUnit.get_UnitSide(SetSideOnly: false));
		int num2 = list2.Count - 1;
		for (int i = 0; i <= num2; i++)
		{
			Contact.HostedUnitReconRecord current2;
			try
			{
				current2 = list2[i];
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				continue;
			}
			myUnit.ParentScen.ActiveUnits.TryGetValue(current2.UnitID, out var value);
			if (Information.IsNothing((object)value))
			{
				if (float_0 < num * 2f)
				{
					lazy.Value.Add(current2);
				}
			}
			else if (!airFacility_0.ParentPlatform.DockingOps.EmbarkedBoats_ReadOnly.Contains(value) && (!value.IsAircraft || !airFacility_0.ParentPlatform.AirOps.EmbarkedAircraft_ReadOnly.Contains((Aircraft)value)) && float_0 < num * 2f)
			{
				lazy.Value.Add(current2);
			}
		}
		foreach (Contact.HostedUnitReconRecord item2 in lazy.Value)
		{
			RemoveHostedUnitRecord(contact_0, item2);
		}
	}

	public void AttemptReconOfHostedUnits(Contact theC, ActiveUnit theDetectedUnit, Sensor theS)
	{
		if ((Information.IsNothing((object)theC.ActualUnit) || !theC.ActualUnit.IsSubmarine) && !theDetectedUnit.IsAircraft && theS.get_CanPerformBDA(AllowRadar: true, AllowSonar: false))
		{
			float float_ = Module_Unit.RangeToUnit_Slant(myUnit, theDetectedUnit);
			AirFacility[] airFacilities_ReadOnly = theDetectedUnit.AirFacilities_ReadOnly;
			foreach (AirFacility airFacility_ in airFacilities_ReadOnly)
			{
				method_18(airFacility_, theS, theC, float_);
			}
			DockFacility[] dockFacilities_ReadOnly = theDetectedUnit.DockFacilities_ReadOnly;
			foreach (DockFacility dockFacility_ in dockFacilities_ReadOnly)
			{
				method_29(dockFacility_, theS, theC, float_);
			}
		}
	}

	public void method_19(Contact theC, ActiveUnit theDetectedUnit, Sensor theS)
	{
		try
		{
			if ((!Information.IsNothing((object)theC.ActualUnit) && theC.ActualUnit.IsSubmarine && !((Submarine)theC.ActualUnit).IsSurfaced) || theDetectedUnit.IsAircraft || !theS.get_CanPerformBDA(AllowRadar: true, AllowSonar: true))
			{
				return;
			}
			string text = Misc.ToEnglishString(theC.BDA_StructuralIntegrity) + Misc.ToEnglishString(theC.BDA_FireLevel);
			if (myUnit.IsShip || myUnit.IsSubmarine)
			{
				text += Misc.ToEnglishString(theC.BDA_FloodLevel);
			}
			switch (theS.Type)
			{
			case Sensor.Sensor_Type.Visual:
			case Sensor.Sensor_Type.Infrared:
				method_20(theC, theDetectedUnit, theS);
				method_21(theC, theDetectedUnit, theS);
				method_22(theC, theDetectedUnit, theS);
				break;
			case Sensor.Sensor_Type.Radar:
				if (theS.Codes.Classification)
				{
					method_20(theC, theDetectedUnit, theS);
				}
				break;
			}
			if (theS.IsSonar && !theS.IsActive())
			{
				method_22(theC, theDetectedUnit, theS);
			}
			string text2 = Misc.ToEnglishString(theC.BDA_StructuralIntegrity) + Misc.ToEnglishString(theC.BDA_FireLevel);
			if (myUnit.IsShip || myUnit.IsSubmarine)
			{
				text2 += Misc.ToEnglishString(theC.BDA_FloodLevel);
			}
			if (string.CompareOrdinal(text2, text) != 0 && !string.IsNullOrEmpty(text))
			{
				NotifyBDAChange(theC, myUnit.get_UnitSide(SetSideOnly: false));
			}
			if (!Information.IsNothing((object)theC))
			{
				theC.TimeSinceBDA = 0f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100251", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void NotifyBDAChange(Contact theC, Side ObserverSide)
	{
		try
		{
			if (!Information.IsNothing((object)theC.ActualUnit))
			{
				string text = myUnit.Name + " reports BDA status change on contact: " + theC.Name;
				if (theC.BDA_StructuralIntegrity.HasValue)
				{
					text = text + " - " + Misc.ToEnglishString(theC.BDA_StructuralIntegrity);
				}
				if (theC.BDA_FireLevel.HasValue)
				{
					text = text + " - " + Misc.ToEnglishString(theC.BDA_FireLevel);
				}
				if ((theC.ActualUnit.IsShip || theC.ActualUnit.IsSubmarine) && theC.BDA_FloodLevel.HasValue)
				{
					text = text + " - " + Misc.ToEnglishString(theC.BDA_FloodLevel);
				}
				long messageIncrement = myUnit.ParentScen.MessageIncrement;
				myUnit.ParentScen.MessageIncrement_Add1();
				LoggedMessage value = new LoggedMessage(messageIncrement, text, "Contact report", LoggedMessage.MessageType.ContactChange, myUnit.ParentScen.Time, myUnit.ObjectID, 0, ObserverSide, new Geopoint_Struct(((Module_Unit.Unit)theC).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theC).get_Latitude((GlobalVariables.BooleanObject)null)));
				BDAChangeNotices.Add(messageIncrement, value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100252", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_20(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1)
	{
		try
		{
			if (!Information.IsNothing((object)activeUnit_0) && !activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				float damagePercent = activeUnit_0.Damage.DamagePercent;
				if (damagePercent == 0f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.Undamaged;
				}
				else if (damagePercent < 20f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.LightDamage;
				}
				else if (damagePercent < 50f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.MediumDamage;
				}
				else if (damagePercent < 100f)
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.HeavyDamage;
				}
				else
				{
					contact_0.BDA_StructuralIntegrity = Contact.BDA_StructuralIntegrityLevel.Destroyed;
				}
			}
			else
			{
				contact_0.BDA_StructuralIntegrity = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100253", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_21(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1)
	{
		try
		{
			if (!Information.IsNothing((object)activeUnit_0) && !activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				contact_0.BDA_FireLevel = activeUnit_0.Damage.FireIntensity;
			}
			else
			{
				contact_0.BDA_FireLevel = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100254", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_22(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1)
	{
		try
		{
			if (!Information.IsNothing((object)activeUnit_0) && !activeUnit_0.IsAircraft && !activeUnit_0.IsWeapon)
			{
				contact_0.BDA_FloodLevel = activeUnit_0.Damage.FloodIntensity;
			}
			else
			{
				contact_0.BDA_FloodLevel = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100255", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private Contact_Base.IdentificationStatus? method_23(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1, float float_0)
	{
		Contact_Base.IdentificationStatus? result = default(Contact_Base.IdentificationStatus?);
		try
		{
			if (!sensor_1.Codes.SyntheticApertureRadar)
			{
				result = null;
			}
			else
			{
				if (contact_0.Type != Contact_Base.ContactType.Air)
				{
					Contact_Base.IdentificationStatus value = Contact_Base.IdentificationStatus.Unknown;
					float num = 0.75f;
					float num2 = 0.5f;
					if (sensor_1.IsContinousTrackingCapable)
					{
						num = (float)((double)num * 1.25);
						num2 = (float)((double)num2 * 1.25);
					}
					switch (sensor_1.TechGeneration)
					{
					case GlobalVariables.TechGenerationClass.const_6:
					case GlobalVariables.TechGenerationClass.const_7:
					case GlobalVariables.TechGenerationClass.const_8:
					{
						GlobalVariables.ProficiencyLevel? proficiency2 = myUnit.Proficiency;
						int? num3 = (int?)proficiency2;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
						{
							num3 = (int?)proficiency2;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) != true)
							{
								num3 = (int?)proficiency2;
								bool? flag2;
								bool? flag = (flag2 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)));
								bool? obj;
								bool? flag3;
								if (flag.HasValue && flag2 == true)
								{
									obj = true;
								}
								else
								{
									num3 = (int?)proficiency2;
									flag = (flag3 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)));
									obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
								}
								bool? flag4 = obj;
								flag3 = obj;
								bool? obj2;
								bool? flag5;
								if (flag3.HasValue && flag4 == true)
								{
									obj2 = true;
								}
								else
								{
									num3 = (int?)proficiency2;
									flag3 = (flag5 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)));
									obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
								}
								flag5 = obj2;
								_ = flag5 == true;
							}
							else
							{
								num = (float)((double)num * 0.5);
								num2 = (float)((double)num2 * 0.5);
							}
						}
						else
						{
							num = (float)((double)num * 0.25);
							num2 = (float)((double)num2 * 0.25);
						}
						break;
					}
					case GlobalVariables.TechGenerationClass.const_2:
					case GlobalVariables.TechGenerationClass.const_3:
					case GlobalVariables.TechGenerationClass.const_4:
					case GlobalVariables.TechGenerationClass.const_5:
					{
						GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
						int? num3 = (int?)proficiency;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
						{
							num3 = (int?)proficiency;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) != true)
							{
								num3 = (int?)proficiency;
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) != true)
								{
									num3 = (int?)proficiency;
									if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)) != true)
									{
										num3 = (int?)proficiency;
										if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)) == true)
										{
											num = (float)((double)num * 1.5);
											num2 = (float)((double)num2 * 1.5);
										}
									}
								}
								else
								{
									num = (float)((double)num * 0.5);
									num2 = (float)((double)num2 * 0.5);
								}
							}
							else
							{
								num = (float)((double)num * 0.25);
								num2 = (float)((double)num2 * 0.25);
							}
						}
						else
						{
							num = (float)((double)num * 0.1);
							num2 = (float)((double)num2 * 0.1);
						}
						break;
					}
					}
					float num4 = float_0 / sensor_1.maxRange;
					if (num4 <= num)
					{
						value = Contact_Base.IdentificationStatus.KnownType;
					}
					if (num4 <= num2)
					{
						value = Contact_Base.IdentificationStatus.KnownClass;
					}
					result = value;
					return result;
				}
				result = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100256", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Contact_Base.IdentificationStatus? method_24(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1, float float_0)
	{
		Contact_Base.IdentificationStatus? result = default(Contact_Base.IdentificationStatus?);
		try
		{
			Engine engine;
			Contact_Base.IdentificationStatus value;
			if (!sensor_1.Codes.NCTR_JEM && !sensor_1.Codes.NCTR_NBILST)
			{
				result = null;
			}
			else if (contact_0.Type == Contact_Base.ContactType.Air)
			{
				if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
				{
					result = null;
				}
				else
				{
					value = Contact_Base.IdentificationStatus.Unknown;
					if (!sensor_1.Codes.NCTR_JEM)
					{
						goto IL_0618;
					}
					engine = activeUnit_0.Propulsion.FirstOrDefault();
					if (engine == null)
					{
						goto IL_0618;
					}
					if (activeUnit_0.IsAircraft)
					{
						goto IL_0093;
					}
					Engine.EngineType type = engine.Type;
					if ((uint)(type - 2003) <= 2u)
					{
						goto IL_0093;
					}
					result = null;
				}
			}
			else
			{
				result = null;
			}
			goto end_IL_0001;
			IL_0093:
			if (engine.Type != Engine.EngineType.Piston && engine.Type != Engine.EngineType.Turboprop && engine.Type != Engine.EngineType.Turboshaft)
			{
				ActiveUnit activeUnit = myUnit;
				string feedbackMessage = "";
				if (!(Math.Abs(Module_Unit.AngleOffThisUnitsBoresight(activeUnit, activeUnit_0, DistinguishBetweenStarboardAndPort: true, ref feedbackMessage, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)) <= 15f))
				{
					goto IL_0618;
				}
			}
			float num = 0.75f;
			float num2 = 0.5f;
			if (sensor_1.IsContinousTrackingCapable)
			{
				num = (float)((double)num * 1.25);
				num2 = (float)((double)num2 * 1.25);
			}
			switch (sensor_1.TechGeneration)
			{
			case GlobalVariables.TechGenerationClass.const_6:
			case GlobalVariables.TechGenerationClass.const_7:
			case GlobalVariables.TechGenerationClass.const_8:
			{
				GlobalVariables.ProficiencyLevel? proficiency2 = myUnit.Proficiency;
				int? num3 = (int?)proficiency2;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) == true)
				{
					num = (float)((double)num * 0.25);
					num2 = (float)((double)num2 * 0.25);
					break;
				}
				num3 = (int?)proficiency2;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
				{
					num = (float)((double)num * 0.5);
					num2 = (float)((double)num2 * 0.5);
					break;
				}
				num3 = (int?)proficiency2;
				bool? flag2;
				bool? flag = (flag2 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)));
				bool? obj;
				bool? flag3;
				if (flag.HasValue && flag2 == true)
				{
					obj = true;
				}
				else
				{
					num3 = (int?)proficiency2;
					flag = (flag3 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)));
					obj = ((!flag.HasValue) ? ((bool?)null) : ((flag3 == true) | flag2));
				}
				bool? flag4 = obj;
				flag3 = obj;
				bool? obj2;
				bool? flag5;
				if (flag3.HasValue && flag4 == true)
				{
					obj2 = true;
				}
				else
				{
					num3 = (int?)proficiency2;
					flag3 = (flag5 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)));
					obj2 = ((!flag3.HasValue) ? ((bool?)null) : ((flag5 == true) | flag4));
				}
				flag5 = obj2;
				_ = flag5 == true;
				break;
			}
			case GlobalVariables.TechGenerationClass.const_2:
			case GlobalVariables.TechGenerationClass.const_3:
			case GlobalVariables.TechGenerationClass.const_4:
			case GlobalVariables.TechGenerationClass.const_5:
			{
				GlobalVariables.ProficiencyLevel? proficiency = myUnit.Proficiency;
				int? num3 = (int?)proficiency;
				if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
				{
					num3 = (int?)proficiency;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) != true)
					{
						num3 = (int?)proficiency;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) != true)
						{
							num3 = (int?)proficiency;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)) != true)
							{
								num3 = (int?)proficiency;
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)) == true)
								{
									num = (float)((double)num * 1.5);
									num2 = (float)((double)num2 * 1.5);
								}
							}
						}
						else
						{
							num = (float)((double)num * 0.5);
							num2 = (float)((double)num2 * 0.5);
						}
					}
					else
					{
						num = (float)((double)num * 0.25);
						num2 = (float)((double)num2 * 0.25);
					}
				}
				else
				{
					num = (float)((double)num * 0.1);
					num2 = (float)((double)num2 * 0.1);
				}
				break;
			}
			}
			float num4 = float_0 / sensor_1.maxRange;
			if (num4 <= num)
			{
				value = Contact_Base.IdentificationStatus.KnownType;
			}
			if (num4 <= num2)
			{
				value = Contact_Base.IdentificationStatus.KnownClass;
				result = Contact_Base.IdentificationStatus.KnownClass;
				return result;
			}
			goto IL_0618;
			IL_0618:
			if (sensor_1.Codes.NCTR_NBILST)
			{
				float num5 = 0.6f;
				float num6 = 0.3f;
				switch (sensor_1.TechGeneration)
				{
				case GlobalVariables.TechGenerationClass.const_6:
				case GlobalVariables.TechGenerationClass.const_7:
				case GlobalVariables.TechGenerationClass.const_8:
				{
					GlobalVariables.ProficiencyLevel? proficiency4 = myUnit.Proficiency;
					int? num3 = (int?)proficiency4;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
					{
						num3 = (int?)proficiency4;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
						{
							num5 = (float)((double)num5 * 0.5);
							num6 = (float)((double)num6 * 0.5);
							break;
						}
						num3 = (int?)proficiency4;
						bool? flag3;
						bool? flag = (flag3 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)));
						bool? obj3;
						bool? flag2;
						if (flag.HasValue && flag3 == true)
						{
							obj3 = true;
						}
						else
						{
							num3 = (int?)proficiency4;
							flag = (flag2 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)));
							obj3 = ((!flag.HasValue) ? ((bool?)null) : ((flag2 == true) | flag3));
						}
						bool? flag5 = obj3;
						flag2 = obj3;
						bool? obj4;
						bool? flag4;
						if (flag2.HasValue && flag5 == true)
						{
							obj4 = true;
						}
						else
						{
							num3 = (int?)proficiency4;
							flag2 = (flag4 = ((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)));
							obj4 = ((!flag2.HasValue) ? ((bool?)null) : ((flag4 == true) | flag5));
						}
						flag4 = obj4;
						_ = flag4 == true;
					}
					else
					{
						num5 = (float)((double)num5 * 0.25);
						num6 = (float)((double)num6 * 0.25);
					}
					break;
				}
				case GlobalVariables.TechGenerationClass.const_2:
				case GlobalVariables.TechGenerationClass.const_3:
				case GlobalVariables.TechGenerationClass.const_4:
				case GlobalVariables.TechGenerationClass.const_5:
				{
					GlobalVariables.ProficiencyLevel? proficiency3 = myUnit.Proficiency;
					int? num3 = (int?)proficiency3;
					if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3.GetValueOrDefault() == 0)) != true)
					{
						num3 = (int?)proficiency3;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 1)) == true)
						{
							num5 = (float)((double)num5 * 0.25);
							num6 = (float)((double)num6 * 0.25);
							break;
						}
						num3 = (int?)proficiency3;
						if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 2)) != true)
						{
							num3 = (int?)proficiency3;
							if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 3)) != true)
							{
								num3 = (int?)proficiency3;
								if (((!num3.HasValue) ? ((bool?)null) : new bool?(num3 == 4)) == true)
								{
									num5 = (float)((double)num5 * 1.5);
									num6 = (float)((double)num6 * 1.5);
								}
							}
						}
						else
						{
							num5 = (float)((double)num5 * 0.5);
							num6 = (float)((double)num6 * 0.5);
						}
					}
					else
					{
						num5 = (float)((double)num5 * 0.1);
						num6 = (float)((double)num6 * 0.1);
					}
					break;
				}
				}
				float num7 = float_0 / sensor_1.maxRange;
				if (num7 >= num5)
				{
					value = Contact_Base.IdentificationStatus.KnownType;
				}
				if (num7 >= num6)
				{
					value = Contact_Base.IdentificationStatus.KnownClass;
					result = Contact_Base.IdentificationStatus.KnownClass;
					return result;
				}
			}
			result = value;
			return result;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100256", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Contact_Base.IdentificationStatus method_25(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1)
	{
		Contact_Base.IdentificationStatus result;
		try
		{
			if (contact_0.IDStatus >= Contact_Base.IdentificationStatus.KnownClass)
			{
				result = Contact_Base.IdentificationStatus.Unknown;
			}
			else if (contact_0.TimeSinceESM_Identification < 15f)
			{
				result = Contact_Base.IdentificationStatus.Unknown;
			}
			else if (contact_0.HasDetectedEmissions)
			{
				Scenario theScen = myUnit.ParentScen;
				int num;
				GlobalVariables.ActiveUnitType activeUnitType;
				switch (contact_0.Type)
				{
				default:
					num = 0;
					goto IL_008a;
				case Contact_Base.ContactType.Air:
					activeUnitType = GlobalVariables.ActiveUnitType.Aircraft;
					break;
				case Contact_Base.ContactType.Surface:
					activeUnitType = GlobalVariables.ActiveUnitType.Ship;
					break;
				case Contact_Base.ContactType.Submarine:
					activeUnitType = GlobalVariables.ActiveUnitType.Submarine;
					break;
				case Contact_Base.ContactType.UndeterminedNaval:
				case Contact_Base.ContactType.Aimpoint:
				case Contact_Base.ContactType.Orbital:
					num = 0;
					goto IL_008a;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.AggregateGroundUnit:
					activeUnitType = GlobalVariables.ActiveUnitType.Facility;
					break;
				case Contact_Base.ContactType.Missile:
				case Contact_Base.ContactType.Torpedo:
					{
						activeUnitType = GlobalVariables.ActiveUnitType.Weapon;
						break;
					}
					IL_008a:
					result = (Contact_Base.IdentificationStatus)num;
					goto end_IL_0001;
				}
				List<int> list = new List<int>();
				foreach (int key in contact_0.DetectedEmissions.Keys)
				{
					if (contact_0.DetectedEmissions[key].PreciseID)
					{
						list.Add(key);
					}
				}
				if (contact_0.ListOfESMMatches == null)
				{
					contact_0.ListOfESMMatches = DBFunctions.EW_GetAllUnitsMatchingTheseEmissions(list, activeUnitType, theScen, theScen.DBConnection);
				}
				list = null;
				if (contact_0.ListOfESMMatches.Count == 0)
				{
					result = Contact_Base.IdentificationStatus.Unknown;
				}
				else
				{
					Contact_Base.IdentificationStatus identificationStatus = Contact_Base.IdentificationStatus.Unknown;
					if (contact_0.ListOfESMMatches.Count == 1)
					{
						contact_0.TimeSinceESM_Identification = 0f;
						result = Contact_Base.IdentificationStatus.KnownClass;
					}
					else
					{
						HashSet<int> hashSet = new HashSet<int>();
						switch (activeUnitType)
						{
						case GlobalVariables.ActiveUnitType.Aircraft:
							foreach (int listOfESMMatch in contact_0.ListOfESMMatches)
							{
								hashSet.Add(DBFunctions.GetAircraftType_Int(ref theScen, listOfESMMatch));
							}
							break;
						case GlobalVariables.ActiveUnitType.Ship:
							foreach (int listOfESMMatch2 in contact_0.ListOfESMMatches)
							{
								hashSet.Add(DBFunctions.GetShipType_Int(ref theScen, listOfESMMatch2));
							}
							break;
						case GlobalVariables.ActiveUnitType.Submarine:
							foreach (int listOfESMMatch3 in contact_0.ListOfESMMatches)
							{
								hashSet.Add(DBFunctions.GetSubmarineType_Int(ref theScen, listOfESMMatch3));
							}
							break;
						case GlobalVariables.ActiveUnitType.Facility:
							foreach (int listOfESMMatch4 in contact_0.ListOfESMMatches)
							{
								hashSet.Add(DBFunctions.GetFacilityCategory_Int(ref theScen, listOfESMMatch4));
							}
							break;
						case GlobalVariables.ActiveUnitType.Weapon:
							foreach (int listOfESMMatch5 in contact_0.ListOfESMMatches)
							{
								hashSet.Add(DBFunctions.GetWeaponType_Int(ref theScen, listOfESMMatch5));
							}
							break;
						}
						if (hashSet.Count == 1)
						{
							contact_0.TimeSinceESM_Identification = 0f;
							identificationStatus = Contact_Base.IdentificationStatus.KnownType;
						}
						if (identificationStatus < Contact_Base.IdentificationStatus.KnownType)
						{
							short num2 = 30;
							num2 = (short)(30 + (sensor_1.TechGeneration - 2005));
							float heldFor = contact_0.HeldFor;
							if (!(heldFor < 180f))
							{
								num2 = ((heldFor < 360f) ? ((short)(num2 + 5)) : ((heldFor < 540f) ? ((short)(num2 + 10)) : ((heldFor < 720f) ? ((short)(num2 + 15)) : ((!(heldFor < 900f)) ? ((short)(num2 + 30)) : ((short)(num2 + 25))))));
							}
							int count = hashSet.Count;
							num2 = ((count < 5) ? ((short)Math.Round((double)num2 / 2.0)) : ((count >= 10) ? ((short)Math.Round((double)num2 / 10.0)) : ((short)Math.Round((double)num2 / 5.0))));
							if (GameGeneral.GlobalRNG.Next(0, 101) < num2)
							{
								contact_0.TimeSinceESM_Identification = 0f;
								identificationStatus = Contact_Base.IdentificationStatus.KnownType;
							}
						}
						if (contact_0.ListOfESMMatches.Count == 1)
						{
							contact_0.TimeSinceESM_Identification = 0f;
							identificationStatus = Contact_Base.IdentificationStatus.KnownClass;
						}
						else
						{
							byte b = 10;
							b = (byte)(10 + (sensor_1.TechGeneration - 2005));
							float heldFor2 = contact_0.HeldFor;
							if (!(heldFor2 < 180f))
							{
								b = ((heldFor2 < 360f) ? ((byte)(b + 5)) : ((heldFor2 < 540f) ? ((byte)(b + 10)) : ((heldFor2 < 720f) ? ((byte)(b + 15)) : ((!(heldFor2 < 900f)) ? ((byte)(b + 30)) : ((byte)(b + 25))))));
							}
							int num3 = DBFunctions.EW_GetNumberOfBasicVariants(contact_0.ListOfESMMatches, activeUnitType, myUnit.ParentScen.DBConnection);
							b = ((num3 < 5) ? ((byte)Math.Round((double)(int)b / 2.0)) : ((num3 >= 10) ? ((byte)Math.Round((double)(int)b / 10.0)) : ((byte)Math.Round((double)(int)b / 5.0))));
							if (GameGeneral.GlobalRNG.Next(40, 101) < b)
							{
								contact_0.TimeSinceESM_Identification = 0f;
								identificationStatus = Contact_Base.IdentificationStatus.KnownClass;
							}
						}
						hashSet = null;
						result = identificationStatus;
					}
				}
			}
			else
			{
				result = Contact_Base.IdentificationStatus.Unknown;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100257", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num4;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num4 = 0;
			}
			else
			{
				num4 = 0;
			}
			result = (Contact_Base.IdentificationStatus)num4;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Contact_Base.IdentificationStatus method_26(Contact contact_0, ActiveUnit activeUnit_0, Sensor sensor_1)
	{
		Contact_Base.IdentificationStatus result;
		try
		{
			int num = default(int);
			switch (activeUnit_0.NoiseLevelClass)
			{
			case GlobalVariables.UnitNoiseLevelClass.Loud:
				if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 25;
				}
				else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = 20;
				}
				else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					num = 15;
				}
				else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
				{
					num = 10;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.Noisy:
				if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 20;
				}
				else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					num = 15;
				}
				else if (!sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
				{
					if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
					{
						num = 5;
					}
				}
				else
				{
					num = 10;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.Quiet:
				if (!sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					if (!sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
					{
						if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
						{
							num = 5;
						}
						else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
						{
							num = -1;
						}
					}
					else
					{
						num = 10;
					}
				}
				else
				{
					num = 15;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.VQuiet:
				if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					num = 10;
				}
				else if (!sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
				{
					if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
					{
						num = -1;
					}
					else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
					{
						num = -1;
					}
				}
				else
				{
					num = 5;
				}
				break;
			case GlobalVariables.UnitNoiseLevelClass.ExQuiet:
				if (!sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.VLF_Sonar))
				{
					if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.LF_Sonar))
					{
						num = -1;
					}
					else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.MF_Sonar))
					{
						num = -1;
					}
					else if (sensor_1.get_SearchesInThisFrequency(Sensor.FrequencyBand.HF_Sonar))
					{
						num = -1;
					}
				}
				else
				{
					num = 5;
				}
				break;
			}
			if (num < 0)
			{
				result = Contact_Base.IdentificationStatus.Unknown;
			}
			else
			{
				float desiredSpeed = activeUnit_0.DesiredSpeed;
				if (!(desiredSpeed < 6f))
				{
					num = ((desiredSpeed < 12f) ? (num + 5) : ((desiredSpeed < 18f) ? (num + 10) : ((!(desiredSpeed < 24f)) ? (num + 20) : (num + 15))));
				}
				if (activeUnit_0.IsSubmarine && ((Submarine)activeUnit_0).DockingOps.Condition == ActiveUnit_DockingOps._DockingOpsCondition.RechargingBatteries)
				{
					num += 15;
				}
				float heldFor = contact_0.HeldFor;
				int num2 = ((heldFor < 360f) ? num : ((heldFor < 720f) ? (num + 5) : ((heldFor < 1080f) ? (num + 10) : ((heldFor < 1440f) ? (num + 15) : ((!(heldFor < 1800f)) ? (num + 30) : (num + 25))))));
				int num3 = (int)Math.Round((double)num2 / 2.0);
				int num4 = num2 + 20;
				int num5 = GameGeneral.GlobalRNG.Next(20, 101);
				result = ((num5 < num3) ? Contact_Base.IdentificationStatus.PreciseID : ((num5 < num2) ? Contact_Base.IdentificationStatus.KnownClass : ((num5 >= num4) ? Contact_Base.IdentificationStatus.KnownDomain : Contact_Base.IdentificationStatus.KnownType)));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100258", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num6;
			if (Debugger.IsAttached)
			{
				Debugger.Break();
				num6 = 1;
			}
			else
			{
				num6 = 1;
			}
			result = (Contact_Base.IdentificationStatus)num6;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void ProcessNewContact(ref Contact theContact, ref Scenario theScen, Side theDetectingSide, ActiveUnit theDetectedUnit, SpecialDetectionMode theSpecialDetectionMode, ActiveUnit DetectorUnit = null, Contact_Base.IdentificationStatus IDStatus = Contact_Base.IdentificationStatus.KnownDomain, List<Sensor> DetectingSensors = null)
	{
		try
		{
			List<Geopoint_Struct> uncertaintyArea = null;
			TObservableDictionary<int, EmissionContainer> detectedEmissions = null;
			float remainingContinousTrackTime = 0f;
			if (theContact != null)
			{
				if (theContact.UncertaintyArea != null)
				{
					uncertaintyArea = theContact.UncertaintyArea;
				}
				if (theContact.HasDetectedEmissions)
				{
					detectedEmissions = theContact.DetectedEmissions;
				}
				remainingContinousTrackTime = theContact.RemainingContinousTrackTime;
			}
			theDetectingSide.ContactAutoIncrement++;
			theContact = Contact.Instantiate(theDetectedUnit, theDetectingSide.ContactAutoIncrement);
			theContact.UncertaintyArea = uncertaintyArea;
			theContact.DetectedEmissions = detectedEmissions;
			theContact.RemainingContinousTrackTime = remainingContinousTrackTime;
			if (DetectorUnit != null)
			{
				theContact.set_IDStatus(theScen, theDetectingSide, (Sensor)null, (float?)null, IsNCTRupdate: false, DetectorUnit.CommStuff.IsConnectedToSideNetwork, bool_5: false, GenerateMessage: true, IDStatus);
			}
			else
			{
				theContact.set_IDStatus(theScen, theDetectingSide, (Sensor)null, (float?)null, IsNCTRupdate: false, StatusUpdateIsOnCommsGrid: true, bool_5: false, GenerateMessage: true, IDStatus);
			}
			theContact.OriginalDetectorSide = theDetectingSide;
			if (DetectorUnit != null)
			{
				theContact.OriginalDetectorUnitID = DetectorUnit.ObjectID;
			}
			else if (theContact.LastDetections.Count > 0)
			{
				theContact.OriginalDetectorUnitID = theContact.LastDetections.First().DetectorUnitID;
			}
			else
			{
				theContact.OriginalDetectorUnitID = "";
			}
			bool contactIsNew = !theDetectingSide.Contacts.ContainsKey(theDetectedUnit.ObjectID);
			UpdateContactData(ref DetectorUnit, ref theContact, theDetectedUnit, contactIsNew);
			if (DetectorUnit != null)
			{
				if (!DetectorUnit.CommStuff.IsConnectedToSideNetwork)
				{
					DetectorUnit.Sensory._ContactsList_OffGrid[theDetectedUnit.ObjectID] = theContact;
				}
				else
				{
					theDetectingSide.AddContact(theContact);
				}
			}
			else
			{
				theDetectingSide.AddContact(theContact);
			}
			if (theDetectedUnit.IsActiveUnit && theDetectedUnit.get_IsAutoDetectable(theDetectingSide))
			{
				theContact.IsPreciselyLocatedOnThisPulse = true;
				theContact.HeadingIsKnown = true;
				theContact.SpeedIsKnown = true;
				theContact.AltitudeIsKnown = true;
				theContact.IsAutoDetection = true;
				theContact.AddDetectionRecord(new Contact.Detection_Struct(null, null, 0f, SpecialDetectionMode.AutoDetection, theDetectedUnit.ParentScen.Time));
				return;
			}
			if (DetectingSensors != null)
			{
				float detectionRange = Module_Unit.RangeToUnit_Slant(DetectorUnit, theDetectedUnit);
				foreach (Sensor DetectingSensor in DetectingSensors)
				{
					if (DetectingSensor.get_IsPrecise(detectionRange))
					{
						theContact.IsPreciselyLocatedOnThisPulse = true;
						break;
					}
				}
			}
			string text;
			try
			{
				text = ((theContact.UncertaintyArea == null) ? Math.Round(DetectorUnit.RangeToUnit_Horiz(theContact), 1).ToString() : ("Estimated " + Math.Round(DetectorUnit.RangeToUnit_Horiz(theContact), 0)));
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200012", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text = "[unspecified]";
				ProjectData.ClearProjectError();
			}
			string text2;
			try
			{
				text2 = ((int)Math.Round(DetectorUnit.AI.BearingToUnit_True(theContact))).ToString();
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 200015", ex4.Message);
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				text2 = "[unspecified]";
				ProjectData.ClearProjectError();
			}
			LoggedMessage.MessageType messageType;
			if (DetectorUnit != null && !DetectorUnit.CommStuff.IsConnectedToSideNetwork)
			{
				messageType = LoggedMessage.MessageType.CommsIsolatedMessage;
			}
			else if (theContact.ActualUnit.IsWeapon & !theContact.ActualUnit.IsMobileDecoy)
			{
				messageType = LoggedMessage.MessageType.NewWeaponContact;
			}
			else
			{
				int num;
				switch (theContact.ActualUnit.UnitType)
				{
				default:
					num = 1;
					goto IL_03ab;
				case GlobalVariables.ActiveUnitType.Aircraft:
					messageType = LoggedMessage.MessageType.NewAirContact;
					break;
				case GlobalVariables.ActiveUnitType.Ship:
					messageType = LoggedMessage.MessageType.NewSurfaceContact;
					break;
				case GlobalVariables.ActiveUnitType.Submarine:
					messageType = LoggedMessage.MessageType.NewUnderwaterContact;
					break;
				case GlobalVariables.ActiveUnitType.Aimpoint:
				case GlobalVariables.ActiveUnitType.Weapon:
				case GlobalVariables.ActiveUnitType.Satellite:
					num = 1;
					goto IL_03ab;
				case GlobalVariables.ActiveUnitType.Facility:
				case GlobalVariables.ActiveUnitType.Vehicle:
					{
						messageType = LoggedMessage.MessageType.NewGroundContact;
						break;
					}
					IL_03ab:
					messageType = (LoggedMessage.MessageType)num;
					break;
				}
			}
			string text3 = smethod_1(DetectingSensors, theDetectedUnit, DetectorUnit);
			string text4 = "";
			if (DetectorUnit.IsAircraft && Operators.CompareString(DetectorUnit.Name, DetectorUnit.UnitClass, false) != 0)
			{
				text4 = " (" + DetectorUnit.UnitClass + ")";
			}
			switch (theSpecialDetectionMode)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				break;
			case SpecialDetectionMode.None:
			{
				string messageSummary;
				switch (theContact.Type)
				{
				case Contact_Base.ContactType.Air:
					messageSummary = "New air contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Missile:
					messageSummary = "New weapon contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Surface:
					messageSummary = "New surface contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Submarine:
					messageSummary = "New sub contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Orbital:
					messageSummary = "New space contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Torpedo:
					messageSummary = "New torpedo contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Mine:
					messageSummary = "New mine contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Sonobuoy:
					messageSummary = "New sonobuoy contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Installation:
				case Contact_Base.ContactType.AirBase:
				case Contact_Base.ContactType.NavalBase:
					messageSummary = "New fixed land contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.MobileGroup:
					messageSummary = "New mobile land contact (" + theContact.Name + ")";
					break;
				default:
					messageSummary = "New contact (" + theContact.Name + ")";
					break;
				case Contact_Base.ContactType.AggregateGroundUnit:
					messageSummary = "New land formation contact (" + theContact.Name + ")";
					break;
				}
				if (DetectingSensors != null && DetectingSensors.Count != 0)
				{
					string text5 = "";
					foreach (Sensor DetectingSensor2 in DetectingSensors)
					{
						text5 = Misc.RemoveHiddenString(DetectingSensor2.Name) + ", ";
					}
					if (DetectingSensors.Count > 0)
					{
						text5 = Strings.Left(text5, Strings.Len(text5) - 2);
					}
					DetectorUnit.AddMessage("New contact! Designated " + theContact.Name + " - Detected by " + DetectorUnit.Name + text4 + "  [Sensors: " + text5 + "] at " + text2 + "deg - " + text + "nm" + text3, messageSummary, messageType, 1, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				else
				{
					DetectorUnit.AddMessage("New contact! Designated " + theContact.Name + " - Detected by " + DetectorUnit.Name + text4 + " at " + Conversions.ToString((int)Math.Round(DetectorUnit.AI.BearingToUnit_True(theContact))) + "deg - " + Conversions.ToString(Math.Round(DetectorUnit.RangeToUnit_Horiz(theContact), 1)) + "nm", messageSummary, messageType, 1, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				break;
			}
			case SpecialDetectionMode.SubAssumedFromTorpedoDetection:
				theScen.AddMessage("New probable sub contact! (Torpedo detected). Designated " + theContact.Name, "New sub contact (" + theContact.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, theDetectingSide, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case SpecialDetectionMode.SubAssumedFromMissileDetection:
				theScen.AddMessage("New probable sub contact! (Missile launch observed). Designated " + theContact.Name, "New sub contact (" + theContact.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, theDetectingSide, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case SpecialDetectionMode.FlamingDatum:
				theScen.AddMessage("New probable sub contact! (Flaming datum). Designated " + theContact.Name, "New sub contact (" + theContact.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, theDetectingSide, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case SpecialDetectionMode.MissileAssumedFromSemiActiveIllumination:
				theScen.AddMessage("New probable missile contact! (Guidance illumination detected). Designated " + theContact.Name, "New weapon contact (" + theContact.Name + ")", LoggedMessage.MessageType.NewWeaponContact, 0, null, theDetectingSide, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				theContact.GeneratedFromGuidanceIlluminationDetection = true;
				break;
			case SpecialDetectionMode.CounterBatteryTrack:
				theContact.set_IDStatus(theScen, theDetectingSide, (Sensor)null, (float?)null, IsNCTRupdate: false, DetectorUnit.CommStuff.IsConnectedToSideNetwork, bool_5: false, GenerateMessage: false, Contact_Base.IdentificationStatus.KnownType);
				theScen.AddMessage("New probable artillery contact! (Counter-battery detection). Designated " + theContact.Name, "New artillery contact (" + theContact.Name + ")", LoggedMessage.MessageType.NewContact, 0, null, theDetectingSide, new Geopoint_Struct(((Module_Unit.Unit)theContact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)theContact).get_Latitude((GlobalVariables.BooleanObject)null)));
				break;
			case SpecialDetectionMode.AutoDetection:
			case SpecialDetectionMode.LuaScript:
				break;
			}
			if (!Information.IsNothing((object)DetectorUnit) && DetectorUnit.CommStuff.IsConnectedToSideNetwork)
			{
				newContactDetectedEventHandler_0?.Invoke(theDetectingSide, theContact.Type);
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100259", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private static string smethod_1(List<Sensor> list_1, object object_0, Module_Unit.Unit unit_0)
	{
		if (list_1 != null)
		{
			Ship.ShipWakeSize wakeSize = default(Ship.ShipWakeSize);
			ActiveUnit.AirContrailSize airContrailSize = default(ActiveUnit.AirContrailSize);
			foreach (Sensor item in list_1)
			{
				if (item.Type != Sensor.Sensor_Type.Visual)
				{
					continue;
				}
				if ((((ScenarioObject)object_0).IsShip || ((ScenarioObject)object_0).IsSubmarine) & (unit_0.IsAircraft || unit_0.IsMissile))
				{
					if (((ScenarioObject)object_0).IsShip)
					{
						wakeSize = ((Ship)object_0).WakeSize;
					}
					if (((ScenarioObject)object_0).IsSubmarine)
					{
						wakeSize = ((Submarine)object_0).WakeSize;
					}
					switch (wakeSize)
					{
					case Ship.ShipWakeSize.NoWake:
						return " - No Wake Detected.";
					case Ship.ShipWakeSize.VSmall:
						return " - Very Small Wake Detected.";
					case Ship.ShipWakeSize.Small:
						return " - Small Wake Detected.";
					case Ship.ShipWakeSize.Medium:
						return " - Medium Wake Detected.";
					case Ship.ShipWakeSize.Large:
						return " - Large Wake Detected.";
					case Ship.ShipWakeSize.VLarge:
						return " - Very Large Wake Detected.";
					}
				}
				if (((ScenarioObject)object_0).IsAircraft || ((Module_Unit.Unit)object_0).IsMissile)
				{
					if (((ActiveUnit)object_0).IsAerospaceUnit)
					{
						airContrailSize = ((ActiveUnit)object_0).ContrailSize();
					}
					switch (airContrailSize)
					{
					case ActiveUnit.AirContrailSize.NoContrail:
						return " - No Contrail Detected.";
					case ActiveUnit.AirContrailSize.VSmall:
						return " - Very Small Contrail Detected.";
					case ActiveUnit.AirContrailSize.Small:
						return " - Small Contrail Detected.";
					case ActiveUnit.AirContrailSize.Medium:
						return " - Medium Contrail Detected.";
					case ActiveUnit.AirContrailSize.Large:
						return " - Large Contrail Detected.";
					case ActiveUnit.AirContrailSize.VLarge:
						return " - Very Large Contrail Detected.";
					}
				}
			}
		}
		return "";
	}

	internal static string GetContrailWakeString(ActiveUnit theUnit)
	{
		if (theUnit.IsShip || theUnit.IsSubmarine)
		{
			Ship.ShipWakeSize wakeSize = default(Ship.ShipWakeSize);
			if (theUnit.IsShip)
			{
				wakeSize = ((Ship)theUnit).WakeSize;
			}
			if (theUnit.IsSubmarine)
			{
				wakeSize = ((Submarine)theUnit).WakeSize;
			}
			switch (wakeSize)
			{
			case Ship.ShipWakeSize.NoWake:
				return "(None)";
			case Ship.ShipWakeSize.VSmall:
				return "(VS)";
			case Ship.ShipWakeSize.Small:
				return "(S)";
			case Ship.ShipWakeSize.Medium:
				return "(M)";
			case Ship.ShipWakeSize.Large:
				return "(L)";
			case Ship.ShipWakeSize.VLarge:
				return "(VL)";
			}
		}
		if (theUnit.IsAircraft || theUnit.IsMissile)
		{
			ActiveUnit.AirContrailSize airContrailSize = default(ActiveUnit.AirContrailSize);
			if (theUnit.IsAircraft)
			{
				airContrailSize = theUnit.ContrailSize();
			}
			if (theUnit.IsMissile)
			{
				airContrailSize = theUnit.ContrailSize();
			}
			switch (airContrailSize)
			{
			case ActiveUnit.AirContrailSize.NoContrail:
				return "(None)";
			case ActiveUnit.AirContrailSize.VSmall:
				return "(VS)";
			case ActiveUnit.AirContrailSize.Small:
				return "(S)";
			case ActiveUnit.AirContrailSize.Medium:
				return "(M)";
			case ActiveUnit.AirContrailSize.Large:
				return "(L)";
			case ActiveUnit.AirContrailSize.VLarge:
				return "(VL)";
			}
		}
		return "";
	}

	public static void ProcessNewBaseContact(Contact theContact, ref Scenario theScen, Side theDetectingSide, Module_Unit.Unit theDetectedUnit, ActiveUnit DetectorUnit = null, Contact_Base.IdentificationStatus IDStatus = Contact_Base.IdentificationStatus.KnownDomain)
	{
		try
		{
			theDetectingSide.BaseContactAutoIncrement++;
			theContact = Contact.Instantiate((ActiveUnit)theDetectedUnit, theDetectingSide.BaseContactAutoIncrement);
			theContact.UncertaintyArea = null;
			theContact.IsPreciselyLocatedOnThisPulse = true;
			theContact.HeadingIsKnown = true;
			theContact.SpeedIsKnown = true;
			theContact.AltitudeIsKnown = true;
			theContact.set_IDStatus(theScen, theDetectingSide, (Sensor)null, (float?)null, IsNCTRupdate: false, DetectorUnit.CommStuff.IsConnectedToSideNetwork, bool_5: false, GenerateMessage: true, IDStatus);
			theContact.OriginalDetectorSide = theDetectingSide;
			theContact.Age = 0f;
			theContact.UpdateCenter((ActiveUnit)theDetectedUnit);
			theDetectingSide.AddBaseContact(theContact);
			if (theDetectedUnit.IsActiveUnit && ((ActiveUnit)theDetectedUnit).get_IsAutoDetectable(theDetectingSide) && theContact.IDStatus == Contact_Base.IdentificationStatus.PreciseID)
			{
				theContact.IsAutoDetection = true;
				theContact.AddDetectionRecord(new Contact.Detection_Struct(null, null, 0f, SpecialDetectionMode.AutoDetection, ((ActiveUnit)theDetectedUnit).ParentScen.Time));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100260", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public bool IsIlluminatingThisContact(Contact theContact)
	{
		bool result;
		try
		{
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			int num = 0;
			while (true)
			{
				if (num < sensors_Cached.Length)
				{
					Sensor sensor = sensors_Cached[num];
					if (!sensor.IsActive() || !sensor.TargetsTrackedForFireControl_Readonly.Contains(theContact))
					{
						num = checked(num + 1);
						continue;
					}
					result = true;
					break;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100261", "");
			GameGeneral.WriteExceptionsToLog(ex2);
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

	public bool CanIlluminateThisContactForThisWeapon(Contact theContact, Weapon theWeapon, ref Sensor SuitableIlluminator, ref bool? LOS_Exists_Radar, ref bool? LOS_Exists_RadarSW, ref Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual, ref bool? LOS_Exists_Sonar)
	{
		bool result;
		if (!theWeapon.IsDLZconstruct)
		{
			try
			{
				if (!myUnit.IsMissile)
				{
					if (myUnit.IsOperating())
					{
						List<ActiveUnit> list = null;
						Sensor[] sensors_Cached = myUnit.Sensors_Cached;
						int num = 0;
						while (true)
						{
							if (num < sensors_Cached.Length)
							{
								Sensor sensor = sensors_Cached[num];
								if (sensor.CanIlluminateForThisWeapon(ref theWeapon))
								{
									if (sensor.IsTrackingThisTargetForFireControl(ref theContact))
									{
										SuitableIlluminator = sensor;
										result = true;
										break;
									}
									if (sensor.Status != PlatformComponent._ComponentStatus.Operational)
									{
										result = false;
										break;
									}
									if (sensor.HasFireControlChannelAvailable())
									{
										int num3;
										if (theContact != null)
										{
											if (theContact.ActualUnit != null)
											{
												ActiveUnit actualUnit = theContact.ActualUnit;
												if (actualUnit != null)
												{
													if (sensor.Type == Sensor.Sensor_Type.Radar)
													{
														if (list == null)
														{
															list = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
														}
														if (sensor.TargetsTrackedForFireControl_Readonly.Count > 0)
														{
															bool flag = false;
															List<Module_Unit.Unit> list2 = new List<Module_Unit.Unit>(sensor.TargetsTrackedForFireControl_Readonly);
															list2.Add(theContact);
															int num2 = 0;
															do
															{
																if (!Sensor.CanTrackAllTargetsAtThisBoresightBearing(sensor, num2, list2))
																{
																	num2++;
																	continue;
																}
																flag = true;
																break;
															}
															while (num2 <= 359);
															if (!flag)
															{
																result = false;
																break;
															}
														}
													}
													if (sensor.CanIlluminateTarget(myUnit, actualUnit, Module_Unit.RangeToUnit_Slant(myUnit, theContact), list, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar) == Sensor.SensorDetectionCheckResult.Success)
													{
														SuitableIlluminator = sensor;
														result = true;
														break;
													}
													goto IL_014c;
												}
												result = false;
												break;
											}
											num3 = 0;
										}
										else
										{
											num3 = 0;
										}
										result = (byte)num3 != 0;
										break;
									}
								}
								goto IL_014c;
							}
							result = false;
							break;
							IL_014c:
							num = checked(num + 1);
						}
					}
					else
					{
						result = false;
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
				ex2?.Data.Add("Error at 100262", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				int num4;
				if (Debugger.IsAttached)
				{
					Debugger.Break();
					num4 = 0;
				}
				else
				{
					num4 = 0;
				}
				result = (byte)num4 != 0;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	public bool IlluminateThisContactForThisWeapon(Contact theContact, Weapon theWeapon, ref bool? LOS_Exists_Radar, ref bool? LOS_Exists_RadarSW, ref Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual, ref bool? LOS_Exists_Sonar)
	{
		bool result;
		try
		{
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			int num = 0;
			List<ActiveUnit> list = default(List<ActiveUnit>);
			while (true)
			{
				if (num < sensors_Cached.Length)
				{
					Sensor sensor = sensors_Cached[num];
					if (sensor.Status == PlatformComponent._ComponentStatus.Operational && (sensor.HasFireControlChannelAvailable() || sensor.IsTrackingThisTargetForFireControl(ref theContact)) && sensor.CanIlluminateForThisWeapon(ref theWeapon))
					{
						if (sensor.Type == Sensor.Sensor_Type.Radar && list == null)
						{
							list = myUnit.Sensory.get_JammerUnitsAffectingMe(FactorHavingActiveRadars: false);
						}
						if (sensor.CanIlluminateTarget(myUnit, theContact.ActualUnit, Module_Unit.RangeToUnit_Slant(myUnit, theContact), list, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar) == Sensor.SensorDetectionCheckResult.Success)
						{
							sensor.TrackTargetForFireControl(ref theContact);
							try
							{
								sensor.SemiActiveWeaponsGuided.Add(theWeapon);
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								sensor.SemiActiveWeaponsGuided.Add(theWeapon);
								ProjectData.ClearProjectError();
							}
							theWeapon.SensorProvidingFireControlForMe = sensor;
							result = true;
							break;
						}
					}
					num = checked(num + 1);
					continue;
				}
				result = false;
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100263", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			int num2;
			if (!Debugger.IsAttached)
			{
				num2 = 0;
			}
			else
			{
				Debugger.Break();
				num2 = 0;
			}
			result = (byte)num2 != 0;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public Contact ResultOfDetectionAttempt(ActiveUnit theUnit, Sensor[] mySensors, float SlantRange, ref List<Sensor> SensorsThatMadeDetection, List<ActiveUnit> AffectingJammers, ref bool? LOS_Exists_Radar, ref bool? LOS_Exists_RadarSW, ref Module_Unit.Unit.LOSCheckResult? LOS_Exists_Visual, ref bool? LOS_Exists_Sonar, bool? LOS_Exists_ESM, bool? LOS_Exists_ESM_SW, bool EmissionDetectionOnly)
	{
		Contact result;
		try
		{
			if (!myUnit.IsGuidedWeapon() || !theUnit.IsGuidedWeapon() || !theUnit.IsActiveUnit)
			{
				goto IL_0041;
			}
			Contact_Base.ContactType primaryTarget_Type = theUnit.AI.PrimaryTarget_Type;
			if (primaryTarget_Type != Contact_Base.ContactType.Air && primaryTarget_Type != Contact_Base.ContactType.Missile && primaryTarget_Type != Contact_Base.ContactType.Orbital)
			{
				goto IL_0041;
			}
			result = null;
			goto end_IL_0001;
			IL_0041:
			Sensor[] array = (EmissionDetectionOnly ? mySensors.Where([SpecialName] (Sensor theS) => theS.CanDetectEmissions).ToArray() : mySensors);
			int num = array.Length - 1;
			int num2 = 0;
			Contact contact = default(Contact);
			Dictionary<int, EmissionContainer> DetectedEmissions = default(Dictionary<int, EmissionContainer>);
			while (true)
			{
				if (num2 <= num)
				{
					Sensor sensor = array[num2];
					if (sensor.IsOperating)
					{
						ActiveUnit theUnit2 = theUnit;
						if (sensor.IsTrackingThisUnitForFireControl(ref theUnit2) && sensor.IsScanningOnThisPulse && sensor.CanPerformIllumination)
						{
							if (sensor.CanIlluminateTarget(myUnit, theUnit, SlantRange, AffectingJammers, myUnit.IsShip, WeaponIsAirborne: false, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar) == Sensor.SensorDetectionCheckResult.Success)
							{
								SensorsThatMadeDetection.Add(sensor);
								if (contact == null)
								{
									contact = Contact.Instantiate(theUnit);
								}
							}
							else
							{
								Contact contact2 = (myUnit.CommStuff.IsConnectedToSideNetwork ? myUnit.get_UnitSide(SetSideOnly: false).Contacts[theUnit.ObjectID] : _ContactsList_OffGrid[theUnit.ObjectID]);
								if (contact2 != null)
								{
									sensor.StopTrackingTarget(contact2);
								}
							}
						}
						if (sensor.IsScanningOnThisPulse && sensor.CanPerformVolumeSearch.Value && (sensor.Type != Sensor.Sensor_Type.Radar || sensor.Codes.PESA || sensor.Codes.AESA || sensor.Codes.ICWI || sensor.TargetsTrackedForFireControl_Readonly.Count <= 0))
						{
							List<Geopoint_Struct> UncertaintyArea = null;
							bool flag = false;
							try
							{
								if (theUnit.IsActiveUnit)
								{
									flag = sensor.CanDetectTarget(Sensor.DetectionAttemptType.VolumeSearch, myUnit, theUnit, ref UncertaintyArea, SlantRange, ref DetectedEmissions, AffectingJammers, ref LOS_Exists_Radar, ref LOS_Exists_RadarSW, ref LOS_Exists_Visual, ref LOS_Exists_Sonar, ref LOS_Exists_ESM, ref LOS_Exists_ESM_SW);
								}
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								ex2?.Data.Add("Error at 100264", "");
								GameGeneral.WriteExceptionsToLog(ex2);
								if (Debugger.IsAttached)
								{
									Debugger.Break();
								}
								result = null;
								ProjectData.ClearProjectError();
								break;
							}
							if (flag)
							{
								SensorsThatMadeDetection.Add(sensor);
								if (contact != null)
								{
									if (UncertaintyArea != null && contact.UncertaintyArea != null)
									{
										if (Zone.ComputeArea(contact.UncertaintyArea) > Zone.ComputeArea(UncertaintyArea))
										{
											contact.UncertaintyArea = UncertaintyArea;
										}
									}
									else if (contact.UncertaintyArea == null)
									{
										contact.UncertaintyArea = UncertaintyArea;
									}
								}
								else
								{
									contact = Contact.Instantiate(theUnit);
									if (UncertaintyArea != null)
									{
										contact.UncertaintyArea = UncertaintyArea;
									}
								}
								if (DetectionIsPrecise(sensor, myUnit.RangeToUnit_Horiz(theUnit, GlobalVariables.ObjectTrue, GlobalVariables.ObjectTrue)))
								{
									contact.IsPreciselyLocatedOnThisPulse = true;
									((Module_Unit.Unit)contact).set_Latitude((GlobalVariables.BooleanObject)null, theUnit.get_Latitude((GlobalVariables.BooleanObject)null));
									((Module_Unit.Unit)contact).set_Longitude((GlobalVariables.BooleanObject)null, theUnit.get_Longitude((GlobalVariables.BooleanObject)null));
									if (sensor.Capabilities.AltitudeInfo)
									{
										((Module_Unit.Unit)contact).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, theUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
										contact.AltitudeIsKnown = true;
									}
								}
								if (DetectedEmissions != null)
								{
									try
									{
										foreach (int key in DetectedEmissions.Keys)
										{
											if (contact.DetectedEmissions.TryGetValue(key, out var value))
											{
												value.Age = 0f;
												if (DetectedEmissions[key].IsIllumination)
												{
													value.IsIllumination = true;
												}
												if (DetectedEmissions[key].PreciseID)
												{
													value.PreciseID = true;
												}
											}
											else
											{
												contact.DetectedEmissions.Add(key, new EmissionContainer(0.0, DetectedEmissions[key].IsIllumination, DetectedEmissions[key].PreciseID));
											}
										}
									}
									catch (Exception ex3)
									{
										ProjectData.SetProjectError(ex3);
										Exception ex4 = ex3;
										ex4?.Data.Add("Error at 101169", "");
										GameGeneral.WriteExceptionsToLog(ex4);
										if (Debugger.IsAttached)
										{
											Debugger.Break();
										}
										ProjectData.ClearProjectError();
									}
								}
							}
						}
					}
					num2++;
					continue;
				}
				result = contact;
				break;
			}
			end_IL_0001:;
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			ex6?.Data.Add("Error at 100264", "");
			GameGeneral.WriteExceptionsToLog(ex6);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool DetectionIsPrecise(Sensor theS, float theDetectionRange)
	{
		if (theS.get_IsPrecise(theDetectionRange))
		{
			int result;
			if (theS.IsSonar)
			{
				if (theS.IsActive())
				{
					float num = (float)((double)SonarModel.smethod_0(theS.ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), theS.ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), theS.ParentPlatform.get_UnitSide(SetSideOnly: false), theS.ParentPlatform.ParentScen) - 2.5);
					if (theS.Role == Sensor.Sensor_Role.HullSonarPassiveOnlyVerticalRangingArray)
					{
						num = (float)((double)num * 0.8);
					}
					if (theDetectionRange >= num)
					{
						return false;
					}
					return true;
				}
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

	public void method_27(List<Sensor> SensorList)
	{
		if (SensorList == null)
		{
			return;
		}
		try
		{
			List<Sensor> list = new List<Sensor>(SensorList);
			foreach (Sensor item in list)
			{
				if (item.Status == PlatformComponent._ComponentStatus.Operational)
				{
					if (item.TimeToNextScan != 0)
					{
						item.TimeToNextScan = Math.Max(0, item.TimeToNextScan - 1);
					}
					if (item.TimeToNextScan_Full != 0)
					{
						item.TimeToNextScan_Full = Math.Max(0, item.TimeToNextScan_Full - 1);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100265", "UpdateMCMCountdown");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateSensorsCountdown_PreDetection(Sensor[] SensorList)
	{
		try
		{
			if (SensorList == null)
			{
				return;
			}
			List<Sensor> list = new List<Sensor>(SensorList);
			foreach (Sensor item in list)
			{
				if (item != null && item.Status == PlatformComponent._ComponentStatus.Operational)
				{
					item.TimeToNextScan--;
					item.TimeToNextScan_Full--;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100265", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateSensorsCountdown_PostDetection(Sensor[] SensorList)
	{
		try
		{
			if (SensorList == null)
			{
				return;
			}
			sensor_0 = (Sensor[])SensorList.Clone();
			Sensor[] array = sensor_0;
			foreach (Sensor sensor in array)
			{
				if (sensor != null && sensor.Status == PlatformComponent._ComponentStatus.Operational && sensor.IsScanningOnThisPulse)
				{
					if (!sensor.IsMineCountermeasure)
					{
						sensor.TimeToNextScan = sensor.ScanInterval;
					}
					if (sensor.IsScanningOnThisPulse_Full && sensor.ParentPlatform != null)
					{
						sensor.TimeToNextScan_Full = sensor.ParentPlatform.OODA_Detection;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100266", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public float TMASolution_ESM(Contact theContact, float DetectionRange)
	{
		float result;
		try
		{
			int num = (int)Math.Round(theContact.HeldFor);
			if (num == 0)
			{
				result = 0f;
			}
			else
			{
				result = ((DetectionRange < 10f) ? ((float)Math.Min((double)num / 600.0, 0.99)) : ((DetectionRange < 25f) ? ((float)Math.Min((double)num / 900.0, 0.99)) : ((!(DetectionRange < 50f)) ? ((float)Math.Min((double)num / 3600.0, 0.99)) : ((float)Math.Min((double)num / 1800.0, 0.99)))));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100268", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.99f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public float TMASolution_Sonar(Contact theContact, float DetectionRange)
	{
		float result;
		try
		{
			if (!Information.IsNothing((object)theContact.UncertaintyArea))
			{
				int num = (int)Math.Round(theContact.HeldFor);
				if (num != 0)
				{
					result = ((DetectionRange < 2.5f) ? ((float)Math.Min((double)num / 600.0, 0.99)) : ((DetectionRange < 5f) ? ((float)Math.Min((double)num / 900.0, 0.99)) : ((!(DetectionRange < 10f)) ? ((float)Math.Min((double)num / 3600.0, 0.99)) : ((float)Math.Min((double)num / 1800.0, 0.99)))));
				}
				else
				{
					result = 0f;
				}
			}
			else
			{
				result = 1f;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100269", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = 0.99f;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public List<Geopoint_Struct> GetUncertaintyArea(Sensor theS, Module_Unit.Unit DetectedUnit, float DetectionRange_Horiz, Dictionary<int, EmissionContainer> DetectedEmissions, float? MaxUpperRange = null)
	{
		List<Geopoint_Struct> result;
		if (myUnit != null)
		{
			if (myUnit.get_UnitSide(SetSideOnly: false) != null)
			{
				float num = theS.RangeResolution_Nominal;
				float num2 = theS.AngleResolution;
				bool flag = false;
				double num3 = myUnit.get_Longitude(GlobalVariables.ObjectTrue);
				double num4 = myUnit.get_Latitude(GlobalVariables.ObjectTrue);
				try
				{
					if (!((theS.Type == Sensor.Sensor_Type.ESM) | (theS.Type == Sensor.Sensor_Type.PCLS)))
					{
						if (theS.Type == Sensor.Sensor_Type.Visual)
						{
							float num5 = Module_Unit.RangeToUnit_Slant(theS.ParentPlatform, DetectedUnit);
							num2 = 0.1f;
							num = (float)((double)num5 * 0.1);
						}
						else if (theS.Type == Sensor.Sensor_Type.Infrared)
						{
							float num6 = Module_Unit.RangeToUnit_Slant(theS.ParentPlatform, DetectedUnit);
							num2 = 0.1f;
							num = ((!theS.Codes.Classification) ? ((float)((double)num6 * 0.5)) : ((float)((double)num6 * 0.2)));
						}
						else if (!theS.IsSonar && theS.Type != Sensor.Sensor_Type.PingIntercept)
						{
							num = ((theS.Type != Sensor.Sensor_Type.Radar) ? (num * (DetectionRange_Horiz / theS.maxRange)) : (DetectionRange_Horiz / 20f));
						}
						else
						{
							float num7 = SonarModel.smethod_0(num4, num3, myUnit.get_UnitSide(SetSideOnly: false), myUnit.ParentScen);
							float num8 = (float)((double)num7 - 2.5);
							if (!(DetectionRange_Horiz < num8) && num7 != 0f)
							{
								num = 30f;
								num2 = 4f;
							}
							else
							{
								Contact value = null;
								myUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(DetectedUnit.ObjectID, out value);
								if (value != null && DetectionRange_Horiz <= 20f)
								{
									float num9 = TMASolution_Sonar(value, DetectionRange_Horiz);
									num = DetectionRange_Horiz * (1f - num9);
									flag = true;
								}
							}
						}
					}
					else
					{
						Contact value2 = null;
						myUnit.get_UnitSide(SetSideOnly: false).Contacts.TryGetValue(DetectedUnit.ObjectID, out value2);
						if (value2 != null && theS.Role != Sensor.Sensor_Role.ESM_RWR && DetectionRange_Horiz <= 300f)
						{
							float num10 = TMASolution_ESM(value2, DetectionRange_Horiz);
							num = DetectionRange_Horiz * (1f - num10);
							flag = true;
						}
					}
					float num11 = Math2.CalcAzimuth(num4, num3, DetectedUnit.get_Latitude(GlobalVariables.ObjectTrue), DetectedUnit.get_Longitude(GlobalVariables.ObjectTrue));
					LockRandom lockRandom_ = GameGeneral.GlobalRNG;
					float num12 = (float)Math2.NormalizeBearing((double)num11 + (double)num2 * 0.5 * ((double)lockRandom_.Next(-90, 91) / 100.0));
					float num13 = (float)Math.Max(0.0, (double)DetectionRange_Horiz + (double)num * ((double)lockRandom_.Next(-90, 91) / 100.0));
					List<Geopoint_Struct> list = new List<Geopoint_Struct>(6);
					float distance_NM2;
					float distance_NM;
					if (theS.Type == Sensor.Sensor_Type.ESM)
					{
						if (flag)
						{
							distance_NM = Math.Max(num13 - num, 0f);
							distance_NM2 = num13 + num;
						}
						else
						{
							Horizon.RadarHorizonNM(myUnit, DetectedUnit, theS);
							float num14 = theS.maxRange;
							if (MaxUpperRange.HasValue)
							{
								num14 = Math.Min(MaxUpperRange.Value, num14);
							}
							if (myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > 100000f)
							{
								float num15 = Horizon.ESMHorizonNM(Math.Min(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), 100000f), DetectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null));
								float num16 = Math.Min(3441.6865f, Horizon.RealHorizonNM(myUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), DetectedUnit.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))) + num15;
								if (!float.IsInfinity(num16) && !float.IsNaN(num16))
								{
									distance_NM2 = Math.Min(num16, num13 + theS.maxRange / 3f);
								}
								else
								{
									distance_NM2 = num13 + theS.maxRange / 3f;
									distance_NM = Math.Max(num13 - theS.maxRange / 3f, 0f);
								}
								float num17 = Math.Min(num14 / 3f, num16);
								distance_NM = Math.Max(num13 - num17, 0f);
							}
							else
							{
								distance_NM = Math.Max(num13 - theS.maxRange / 3f, 0f);
								distance_NM2 = num13 + num14 / 3f;
							}
						}
					}
					else if (theS.Type == Sensor.Sensor_Type.PCLS)
					{
						if (flag)
						{
							distance_NM = Math.Max(num13 - num, 0f);
							distance_NM2 = num13 + num;
						}
						else
						{
							distance_NM = Math.Max(num13 - theS.maxRange / 3f, 0f);
							float num18 = Horizon.RadarHorizonNM(myUnit, DetectedUnit, theS);
							distance_NM2 = ((float.IsInfinity(num18) || float.IsNaN(num18)) ? (num13 + theS.maxRange / 3f) : Math.Min(num18, num13 + theS.maxRange / 3f));
						}
					}
					else if (theS.IsSonar)
					{
						float num19 = SonarModel.smethod_0(num4, num3, myUnit.get_UnitSide(SetSideOnly: false), myUnit.ParentScen);
						float num20 = (float)((double)num19 - 2.5);
						if (!(DetectionRange_Horiz < num20) && num19 != 0f)
						{
							distance_NM = num20;
							distance_NM2 = theS.maxRange;
						}
						else if (flag)
						{
							distance_NM = Math.Max(num13 - num, 0f);
							distance_NM2 = num13 + num;
						}
						else
						{
							distance_NM = 1E-05f;
							if (num19 > 0f)
							{
								distance_NM2 = num20;
							}
							else
							{
								Sensor.Sensor_Role role = theS.Role;
								if ((ulong)(role - 5191L) > 2uL && role != Sensor.Sensor_Role.SOSUSPassiveSoundSurveillanceSystems)
								{
									float num21 = SonarModel.SonarPropagationModifier(theS.UsesDeepSoundChannel(), myUnit, (ActiveUnit)DetectedUnit);
									distance_NM2 = (float)(9.87473 * (double)num21);
								}
								else
								{
									distance_NM2 = theS.maxRange;
								}
							}
						}
					}
					else if (theS.Type == Sensor.Sensor_Type.MAD)
					{
						distance_NM = 0.001f;
						distance_NM2 = theS.maxRange;
					}
					else
					{
						distance_NM = Math.Max(num13 - num, 0f);
						distance_NM2 = num13 + num;
					}
					float num22 = num2 * 0.5f;
					float bearing = Math2.NormalizeBearing(num12 - num22);
					float bearing2 = Math2.NormalizeBearing(num12 + num22);
					float bearing3 = Math2.NormalizeBearing(num12);
					Geopoint_Struct item = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(num3, num4, ref item.Longitude, ref item.Latitude, distance_NM, bearing);
					list.Add(item);
					item = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(num3, num4, ref item.Longitude, ref item.Latitude, distance_NM, bearing3);
					list.Add(item);
					item = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(num3, num4, ref item.Longitude, ref item.Latitude, distance_NM, bearing2);
					list.Add(item);
					item = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(num3, num4, ref item.Longitude, ref item.Latitude, distance_NM2, bearing2);
					list.Add(item);
					item = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(num3, num4, ref item.Longitude, ref item.Latitude, distance_NM2, bearing3);
					list.Add(item);
					item = default(Geopoint_Struct);
					Geodesic_EdWilliams.CalcPoint_Williams(num3, num4, ref item.Longitude, ref item.Latitude, distance_NM2, bearing);
					list.Add(item);
					foreach (Geopoint_Struct item2 in list)
					{
						Geopoint_Struct current = item2;
						if (current.Latitude > 90.0)
						{
							current.Latitude = 90.0;
						}
						if (current.Latitude < -90.0)
						{
							current.Latitude = -90.0;
						}
					}
					result = list;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 200585", ex2.Message);
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					result = null;
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				result = null;
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	public static PooledList<Geopoint_Struct> GetRefinedUncertaintyArea_Clipper(PooledList<Geopoint_Struct> OldArea, PooledList<Geopoint_Struct> NewArea, bool ReturnOldAreaAsFailure = false)
	{
		PooledList<Geopoint_Struct> pooledList = (ReturnOldAreaAsFailure ? OldArea : NewArea);
		PooledList<Geopoint_Struct> result;
		try
		{
			if (OldArea == null)
			{
				result = NewArea;
			}
			else if (NewArea == null)
			{
				result = OldArea;
			}
			else
			{
				if (OldArea.Count > 100)
				{
					OldArea = Math2.SimplifyArea(OldArea);
				}
				if (NewArea.Count > 100)
				{
					NewArea = Math2.SimplifyArea(NewArea);
				}
				int count = OldArea.Count;
				int count2 = NewArea.Count;
				int num = count + count2;
				Vector3D[] array = new Vector3D[num - 1 + 1];
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				Geopoint_Struct[] array2 = OldArea.InternalArray();
				int num5 = count - 1;
				for (int i = 0; i <= num5; i++)
				{
					Vector3D vector3D = (array[i] = MathFunctions.Geopoint_Struct_To_UnitVector(array2[i]));
					num2 += vector3D.X;
					num3 += vector3D.Y;
					num4 += vector3D.Z;
				}
				Geopoint_Struct[] array3 = NewArea.InternalArray();
				int num6 = count2 - 1;
				for (int j = 0; j <= num6; j++)
				{
					Vector3D vector3D2 = (array[count + j] = MathFunctions.Geopoint_Struct_To_UnitVector(array3[j]));
					num2 += vector3D2.X;
					num3 += vector3D2.Y;
					num4 += vector3D2.Z;
				}
				double num7 = 1.0 / (double)num;
				num2 *= num7;
				num3 *= num7;
				num4 *= num7;
				double num8 = Math.Sqrt(num2 * num2 + num3 * num3 + num4 * num4);
				double num9 = 1.0 / num8;
				Matrix<double> matrix = Matrix3D.RotationTo(new Vector3D(num2 * num9, num3 * num9, num4 * num9), new Vector3D(1.0, 0.0, 0.0));
				Matrix<double> m = matrix.Inverse();
				int num10 = num - 1;
				for (int k = 0; k <= num10; k++)
				{
					array[k] = array[k].TransformBy(matrix);
				}
				Geopoint_Struct[] Area = new Geopoint_Struct[count - 1 + 1];
				Geopoint_Struct[] Area2 = new Geopoint_Struct[count2 - 1 + 1];
				int num11 = count - 1;
				for (int l = 0; l <= num11; l++)
				{
					Area[l] = MathFunctions.Vector_To_Geopoint_Struct(array[l]);
				}
				int num12 = count2 - 1;
				for (int n = 0; n <= num12; n++)
				{
					Area2[n] = MathFunctions.Vector_To_Geopoint_Struct(array[count + n]);
				}
				List<Geopoint_Struct> areasIntersections_Clipper = Math2.GetAreasIntersections_Clipper(ref Area, ref Area2);
				if (areasIntersections_Clipper.Count != 0)
				{
					int count3 = areasIntersections_Clipper.Count;
					PooledList<Geopoint_Struct> pooledList2 = new PooledList<Geopoint_Struct>(count3);
					int num13 = count3 - 1;
					for (int num14 = 0; num14 <= num13; num14++)
					{
						pooledList2.Add(MathFunctions.Vector_To_Geopoint_Struct(MathFunctions.Geopoint_Struct_To_UnitVector(areasIntersections_Clipper[num14]).TransformBy(m)));
					}
					if (pooledList2.Count > 100)
					{
						pooledList2 = Math2.SimplifyArea(pooledList2);
					}
					result = pooledList2;
				}
				else
				{
					result = pooledList;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200586", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = pooledList;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static List<Geopoint_Struct> GetRefinedUncertaintyArea_Clipper(List<Geopoint_Struct> OldArea, List<Geopoint_Struct> NewArea, bool ReturnOldAreaAsFailure = false)
	{
		List<Geopoint_Struct> list = NewArea;
		if (ReturnOldAreaAsFailure)
		{
			list = OldArea;
		}
		List<Geopoint_Struct> result;
		try
		{
			if (OldArea != null)
			{
				if (OldArea.Count > 100)
				{
					OldArea = Math2.SimplifyArea(OldArea);
				}
				if (NewArea == null)
				{
					result = OldArea;
				}
				else
				{
					if (NewArea.Count > 100)
					{
						NewArea = Math2.SimplifyArea(NewArea);
					}
					List<Vector3D> list2 = new List<Vector3D>(OldArea.Count);
					List<Vector3D> list3 = new List<Vector3D>(NewArea.Count);
					foreach (Geopoint_Struct item3 in OldArea)
					{
						Vector3D item = MathFunctions.Geopoint_Struct_To_UnitVector(item3);
						list2.Add(item);
					}
					foreach (Geopoint_Struct item4 in NewArea)
					{
						Vector3D item = MathFunctions.Geopoint_Struct_To_UnitVector(item4);
						list3.Add(item);
					}
					Vector3D fromVector = default(Vector3D);
					foreach (Vector3D item5 in list3)
					{
						fromVector += item5;
					}
					foreach (Vector3D item6 in list2)
					{
						fromVector += item6;
					}
					fromVector /= (double)(list3.Count + list2.Count);
					fromVector /= fromVector.Length;
					Matrix<double> matrix = Matrix3D.RotationTo(fromVector, new Vector3D(1.0, 0.0, 0.0));
					Matrix<double> m = matrix.Inverse();
					int num = list3.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						list3[i] = list3[i].TransformBy(matrix);
					}
					int num2 = list2.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						list2[j] = list2[j].TransformBy(matrix);
					}
					List<Geopoint_Struct> Area = new List<Geopoint_Struct>(list2.Count);
					List<Geopoint_Struct> Area2 = new List<Geopoint_Struct>(list3.Count);
					foreach (Vector3D item7 in list2)
					{
						Geopoint_Struct item2 = MathFunctions.Vector_To_Geopoint_Struct(item7);
						Area.Add(item2);
					}
					foreach (Vector3D item8 in list3)
					{
						Geopoint_Struct item2 = MathFunctions.Vector_To_Geopoint_Struct(item8);
						Area2.Add(item2);
					}
					List<Geopoint_Struct> areasIntersections_Clipper = Math2.GetAreasIntersections_Clipper(ref Area, ref Area2);
					if (areasIntersections_Clipper.Count == 0)
					{
						result = list;
					}
					else
					{
						List<Vector3D> list4 = new List<Vector3D>(areasIntersections_Clipper.Count);
						foreach (Geopoint_Struct item9 in areasIntersections_Clipper)
						{
							Vector3D item = MathFunctions.Geopoint_Struct_To_UnitVector(item9);
							list4.Add(item);
						}
						int num3 = list4.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							list4[k] = list4[k].TransformBy(m);
						}
						List<Geopoint_Struct> list5 = new List<Geopoint_Struct>(list4.Count);
						foreach (Vector3D item10 in list4)
						{
							list5.Add(MathFunctions.Vector_To_Geopoint_Struct(item10));
						}
						if (list5.Count > 100)
						{
							list5 = Math2.SimplifyArea(list5);
						}
						result = list5;
					}
				}
			}
			else
			{
				result = NewArea;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 200586", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = list;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static List<GeoPoint> GetRefinedUncertaintyArea_DotSpatial(List<GeoPoint> OldArea, List<GeoPoint> NewArea)
	{
		Coordinate[] array = new Coordinate[OldArea.Count + 1];
		List<GeoPoint> result;
		try
		{
			int num = OldArea.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				array[i] = new Coordinate(OldArea[i].Longitude, OldArea[i].Latitude, 0.0);
			}
			array[OldArea.Count] = array[0];
			Polygon polygon = new Polygon(new LinearRing(array));
			Coordinate[] array2 = new Coordinate[NewArea.Count + 1];
			int num2 = NewArea.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				array2[j] = new Coordinate(NewArea[j].Longitude, NewArea[j].Latitude, 0.0);
			}
			array2[NewArea.Count] = array2[0];
			Polygon other = new Polygon(new LinearRing(array2));
			try
			{
				Geometry geometry = (Geometry)polygon.Intersection(other);
				if (geometry.Coordinates.Count > 0)
				{
					List<GeoPoint> list = new List<GeoPoint>();
					int num3 = geometry.Coordinates.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						Coordinate coordinate = geometry.Coordinates[k];
						list.Add(new GeoPoint(coordinate.X, coordinate.Y));
					}
					result = list;
				}
				else
				{
					result = NewArea;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 200017", ex2.Message);
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = NewArea;
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ex4?.Data.Add("Error at 200587", ex4.Message);
			GameGeneral.WriteExceptionsToLog(ex4);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = NewArea;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public PooledList<Sensor> GetSensors_AirSearch()
	{
		PooledList<Sensor> result;
		try
		{
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			if (sensors_Cached == null)
			{
				result = null;
			}
			else
			{
				int num = sensors_Cached.Length;
				PooledList<Sensor> pooledList = null;
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = sensors_Cached[i];
					if (sensor != null && (sensor.CanPerformVolumeSearch.Value || sensor.TargetsTrackedForFireControl_Readonly.Count != 0) && (sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) || sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite) || sensor.Capabilities.SpaceSearch_ABM || sensor.Capabilities.C_RAM))
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(sensor);
					}
				}
				result = pooledList;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100272", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetLongestRange_SensorForContact(Contact target, bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList)
	{
		PooledList<Sensor> result = null;
		try
		{
			if (target != null)
			{
				switch (target.Type)
				{
				case Contact_Base.ContactType.Mine:
					result = GetLongestRange_MineSensor(ref theSensorList);
					break;
				case Contact_Base.ContactType.Air:
				case Contact_Base.ContactType.Missile:
				case Contact_Base.ContactType.Orbital:
				case Contact_Base.ContactType.Decoy_Air:
					result = GetLongestRange_AASensor(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
					break;
				case Contact_Base.ContactType.Surface:
				case Contact_Base.ContactType.Decoy_Surface:
					result = GetLongestRange_ASSensor_SeaSearch(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
					break;
				case Contact_Base.ContactType.Submarine:
				case Contact_Base.ContactType.Torpedo:
				case Contact_Base.ContactType.Decoy_Sub:
					result = GetLongestRange_ASWSensor(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
					break;
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					break;
				case Contact_Base.ContactType.Facility_Fixed:
				case Contact_Base.ContactType.Facility_Mobile:
				case Contact_Base.ContactType.Decoy_Land:
				case Contact_Base.ContactType.AggregateGroundUnit:
					result = GetLongestRange_ASSensor_LandSearch(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
					break;
				}
			}
			return result;
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

	internal (float MaxAirSpace, float MaxSurface, float MaxSubsurface, float MaxLand) GetLongestSensorRanges_AllContactTypes(bool OnlySensorsScanningThisPulse)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		Sensor[] sensors_Cached = myUnit.Sensors_Cached;
		foreach (Sensor sensor in sensors_Cached)
		{
			bool? flag = sensor?.IsOperating;
			if (((!flag) ?? flag) != true && (!OnlySensorsScanningThisPulse || sensor.IsScanningOnThisPulse))
			{
				if (sensor.Capabilities.AirSearch || sensor.Capabilities.SpaceSearch_ABM || sensor.Capabilities.C_RAM)
				{
					num = Math.Max(num, sensor.maxRange);
				}
				if (sensor.Capabilities.SurfaceSearch || sensor.Type == Sensor.Sensor_Type.PingIntercept)
				{
					num2 = Math.Max(num2, sensor.maxRange);
				}
				if (sensor.Type == Sensor.Sensor_Type.PingIntercept || sensor.Capabilities.SubSearch)
				{
					num3 = Math.Max(num3, sensor.maxRange);
				}
				if (sensor.Type == Sensor.Sensor_Type.ESM || sensor.Capabilities.LandSearch_Fixed || sensor.Capabilities.LandSearch_Mobile)
				{
					num4 = Math.Max(num4, sensor.maxRange);
				}
			}
		}
		return (MaxAirSpace: num, MaxSurface: num2, MaxSubsurface: num3, MaxLand: num4);
	}

	internal PooledList<Sensor> GetLongestRange_AASensor(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList)
	{
		PooledList<Sensor> pooledList = null;
		PooledList<Sensor> pooledList2 = null;
		PooledList<Sensor> pooledList3 = null;
		PooledList<Sensor> result;
		try
		{
			pooledList3 = GetUnit_AASensors(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
			float maxRange = default(float);
			int num = default(int);
			if (pooledList3 != null)
			{
				foreach (Sensor item in pooledList3)
				{
					if (item.maxRange >= maxRange)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item);
						maxRange = item.maxRange;
						num = 1;
					}
					else if (item.maxRange == maxRange)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item);
						num++;
					}
				}
				pooledList3.Dispose();
			}
			if (pooledList2 == null)
			{
				result = null;
			}
			else
			{
				foreach (Sensor item2 in pooledList2)
				{
					if (item2.maxRange != maxRange)
					{
						continue;
					}
					if (num == 1)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item2);
						continue;
					}
					if (!item2.Coverage.Has360Coverage.Value)
					{
						num--;
						continue;
					}
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(item2);
					result = pooledList;
					goto end_IL_0008;
				}
				pooledList2.Dispose();
				result = pooledList;
			}
			end_IL_0008:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100273", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetLongestRange_ASSensor(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList)
	{
		PooledList<Sensor> pooledList = null;
		PooledList<Sensor> result;
		try
		{
			PooledList<Sensor> unit_ASSensors = GetUnit_ASSensors(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
			if (unit_ASSensors != null)
			{
				float maxRange = default(float);
				PooledList<Sensor> pooledList2 = default(PooledList<Sensor>);
				int num = default(int);
				float maxRange2 = default(float);
				PooledList<Sensor> pooledList3 = default(PooledList<Sensor>);
				int num2 = default(int);
				foreach (Sensor item in unit_ASSensors)
				{
					if (item.maxRange >= maxRange && !item.Capabilities.OTH_SurfaceWave)
					{
						if (item.maxRange >= maxRange)
						{
							if (pooledList2 == null)
							{
								pooledList2 = new PooledList<Sensor>();
							}
							pooledList2.Add(item);
							maxRange = item.maxRange;
							num = 1;
						}
						else if (item.maxRange == maxRange)
						{
							if (pooledList2 == null)
							{
								pooledList2 = new PooledList<Sensor>();
							}
							pooledList2.Add(item);
							num++;
						}
					}
					else
					{
						if (!(item.maxRange >= maxRange2) || !item.Capabilities.OTH_SurfaceWave)
						{
							continue;
						}
						if (item.maxRange >= maxRange)
						{
							if (pooledList3 == null)
							{
								pooledList3 = new PooledList<Sensor>();
							}
							pooledList3.Add(item);
							maxRange2 = item.maxRange;
							num2 = 1;
						}
						else if (item.maxRange == maxRange)
						{
							if (pooledList3 == null)
							{
								pooledList3 = new PooledList<Sensor>();
							}
							pooledList3.Add(item);
							num2++;
						}
					}
				}
				unit_ASSensors.Dispose();
				if (pooledList2 == null && pooledList3 == null)
				{
					result = null;
				}
				else
				{
					if (pooledList3 != null)
					{
						foreach (Sensor item2 in pooledList3)
						{
							if (item2.maxRange != maxRange2)
							{
								continue;
							}
							if (num2 == 1)
							{
								if (pooledList == null)
								{
									pooledList = new PooledList<Sensor>();
								}
								pooledList.Add(item2);
								continue;
							}
							if (!item2.Coverage.Has360Coverage.Value)
							{
								num2--;
								continue;
							}
							if (pooledList == null)
							{
								pooledList = new PooledList<Sensor>();
							}
							pooledList.Add(item2);
							result = pooledList;
							goto end_IL_0003;
						}
					}
					else
					{
						foreach (Sensor item3 in pooledList2)
						{
							if (item3.maxRange != maxRange)
							{
								continue;
							}
							if (num == 1)
							{
								if (pooledList == null)
								{
									pooledList = new PooledList<Sensor>();
								}
								pooledList.Add(item3);
								continue;
							}
							if (!item3.Coverage.Has360Coverage.Value)
							{
								num--;
								continue;
							}
							if (pooledList == null)
							{
								pooledList = new PooledList<Sensor>();
							}
							pooledList.Add(item3);
							result = pooledList;
							goto end_IL_0003;
						}
					}
					pooledList2?.Dispose();
					pooledList3?.Dispose();
					result = pooledList;
				}
			}
			else
			{
				result = null;
			}
			end_IL_0003:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100274", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetLongestRange_ASSensor_SeaSearch(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList)
	{
		PooledList<Sensor> result;
		try
		{
			PooledList<Sensor> unit_ASSensors_SeaSearch = GetUnit_ASSensors_SeaSearch(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
			float maxRange = default(float);
			PooledList<Sensor> pooledList = default(PooledList<Sensor>);
			int num = default(int);
			if (unit_ASSensors_SeaSearch != null)
			{
				foreach (Sensor item in unit_ASSensors_SeaSearch)
				{
					if (item.maxRange >= maxRange)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item);
						maxRange = item.maxRange;
						num = 1;
					}
					else if (item.maxRange == maxRange)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item);
						num++;
					}
				}
				unit_ASSensors_SeaSearch.Dispose();
			}
			if (pooledList == null)
			{
				result = null;
			}
			else
			{
				PooledList<Sensor> pooledList2 = default(PooledList<Sensor>);
				foreach (Sensor item2 in pooledList)
				{
					if (item2.maxRange != maxRange)
					{
						continue;
					}
					if (num == 1)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item2);
						continue;
					}
					if (!item2.Coverage.Has360Coverage.Value)
					{
						num--;
						continue;
					}
					if (pooledList2 == null)
					{
						pooledList2 = new PooledList<Sensor>();
					}
					pooledList2.Add(item2);
					result = pooledList2;
					goto end_IL_0001;
				}
				pooledList.Dispose();
				result = pooledList2;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100275", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetLongestRange_ASSensor_LandSearch(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList)
	{
		PooledList<Sensor> result;
		try
		{
			PooledList<Sensor> unit_ASSensors_LandSearch = GetUnit_ASSensors_LandSearch(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList);
			float maxRange = default(float);
			PooledList<Sensor> pooledList = default(PooledList<Sensor>);
			int num = default(int);
			if (unit_ASSensors_LandSearch != null)
			{
				foreach (Sensor item in unit_ASSensors_LandSearch)
				{
					if (item.maxRange >= maxRange)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item);
						maxRange = item.maxRange;
						num = 1;
					}
					else if (item.maxRange == maxRange)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item);
						num++;
					}
				}
				unit_ASSensors_LandSearch.Dispose();
			}
			if (pooledList == null)
			{
				result = null;
			}
			else
			{
				PooledList<Sensor> pooledList2 = default(PooledList<Sensor>);
				foreach (Sensor item2 in pooledList)
				{
					if (item2.maxRange != maxRange)
					{
						continue;
					}
					if (num == 1)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item2);
						continue;
					}
					if (!item2.Coverage.Has360Coverage.Value)
					{
						num--;
						continue;
					}
					if (pooledList2 == null)
					{
						pooledList2 = new PooledList<Sensor>();
					}
					pooledList2.Add(item2);
					result = pooledList2;
					goto end_IL_0001;
				}
				pooledList.Dispose();
				result = pooledList2;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100276", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetLongestRange_ASWSensor(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList, bool SonarsOnly = false)
	{
		PooledList<Sensor> pooledList = null;
		PooledList<Sensor> result;
		try
		{
			PooledList<Sensor> unit_ASWSensor = GetUnit_ASWSensor(ActiveCapableSensorsOnly, EmmittingSensorsOnly, OnlyOperatingSensors, OnlySensorsScanningThisPulse, ref theSensorList, SonarsOnly);
			float maxRange = default(float);
			PooledList<Sensor> pooledList2 = default(PooledList<Sensor>);
			int num = default(int);
			if (unit_ASWSensor != null)
			{
				foreach (Sensor item in unit_ASWSensor)
				{
					if (item.maxRange > maxRange)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item);
						maxRange = item.maxRange;
						num = 1;
					}
					else if (item.maxRange == maxRange)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item);
						num++;
					}
				}
				unit_ASWSensor.Dispose();
			}
			if (pooledList2 != null)
			{
				foreach (Sensor item2 in pooledList2)
				{
					if (item2.maxRange != maxRange)
					{
						continue;
					}
					if (num == 1)
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(item2);
						continue;
					}
					if (!item2.Coverage.Has360Coverage.Value)
					{
						num--;
						continue;
					}
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(item2);
					result = pooledList;
					goto end_IL_0002;
				}
				pooledList2.Dispose();
				result = pooledList;
			}
			else
			{
				result = null;
			}
			end_IL_0002:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100277", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetLongestRange_MineSensor(ref Sensor[] theSensorList)
	{
		PooledList<Sensor> result;
		try
		{
			Sensor[] array = theSensorList;
			float maxRange = default(float);
			PooledList<Sensor> pooledList = default(PooledList<Sensor>);
			int num = default(int);
			foreach (Sensor sensor in array)
			{
				if (sensor.maxRange >= maxRange)
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(sensor);
					maxRange = sensor.maxRange;
					num = 1;
				}
				else if (sensor.maxRange == maxRange)
				{
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(sensor);
					num++;
				}
			}
			if (pooledList != null)
			{
				PooledList<Sensor> pooledList2 = default(PooledList<Sensor>);
				foreach (Sensor item in pooledList)
				{
					if (item.maxRange != maxRange)
					{
						continue;
					}
					if (num == 1)
					{
						if (pooledList2 == null)
						{
							pooledList2 = new PooledList<Sensor>();
						}
						pooledList2.Add(item);
						continue;
					}
					if (!item.Coverage.Has360Coverage.Value)
					{
						num--;
						continue;
					}
					if (pooledList2 == null)
					{
						pooledList2 = new PooledList<Sensor>();
					}
					pooledList2.Add(item);
					result = pooledList2;
					goto end_IL_0001;
				}
				pooledList.Dispose();
				result = pooledList2;
			}
			else
			{
				result = null;
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101273", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetUnit_AASensors(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList, bool SonarsOnly = false)
	{
		PooledList<Sensor> result;
		try
		{
			PooledList<Sensor> pooledList = null;
			Sensor[] array = null;
			int num = default(int);
			if (theSensorList != null)
			{
				array = theSensorList;
				num = theSensorList.Count();
			}
			else
			{
				PooledList<Sensor> sensors_AirSearch = GetSensors_AirSearch();
				if (sensors_AirSearch != null)
				{
					array = sensors_AirSearch.InternalArray();
					num = sensors_AirSearch.Count;
				}
			}
			if (array == null)
			{
				result = null;
			}
			else
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = array[i];
					if ((ActiveCapableSensorsOnly && !sensor.CanBeActive) || (EmmittingSensorsOnly && !sensor.IsActive()) || (OnlySensorsScanningThisPulse && !sensor.IsScanningOnThisPulse) || (!sensor.CanPerformVolumeSearch.Value && sensor.TargetsTrackedForFireControl_Readonly.Count == 0) || (OnlyOperatingSensors && !sensor.IsOperating))
					{
						continue;
					}
					if (myUnit.IsWeapon)
					{
						if (!sensor.get_IsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Aircraft, (Weapon)myUnit) && !sensor.get_IsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Weapon, (Weapon)myUnit))
						{
							continue;
						}
					}
					else if (!sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Aircraft) && !sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Weapon) && !sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Satellite))
					{
						continue;
					}
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(sensor);
				}
				result = pooledList;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100278", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal PooledList<Sensor> GetUnit_ASSensors(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList)
	{
		Sensor[] array = ((theSensorList == null) ? myUnit.Sensors_Cached : theSensorList);
		PooledList<Sensor> result;
		if (array != null)
		{
			PooledList<Sensor> pooledList = null;
			int num = array.Length;
			try
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = array[i];
					if (sensor != null && (!ActiveCapableSensorsOnly || sensor.CanBeActive) && (!EmmittingSensorsOnly || sensor.IsActive()) && (!OnlySensorsScanningThisPulse || sensor.IsScanningOnThisPulse) && sensor.CanPerformVolumeSearch.Value && (!OnlyOperatingSensors || sensor.IsOperating) && (sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship) || sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility)))
					{
						if (pooledList == null)
						{
							pooledList = new PooledList<Sensor>();
						}
						pooledList.Add(sensor);
					}
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100279", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	internal PooledList<Sensor> GetUnit_ASSensors_SeaSearch(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList, bool SonarsOnly = false)
	{
		Sensor[] array = ((theSensorList != null) ? theSensorList : myUnit.Sensors_Cached);
		PooledList<Sensor> result;
		if (array != null)
		{
			int num = array.Length;
			PooledList<Sensor> pooledList = null;
			try
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = array[i];
					if ((ActiveCapableSensorsOnly && !sensor.CanBeActive) || (EmmittingSensorsOnly && !sensor.IsActive()) || (OnlySensorsScanningThisPulse && !sensor.IsScanningOnThisPulse) || !sensor.CanPerformVolumeSearch.Value || (OnlyOperatingSensors && !sensor.IsOperating))
					{
						continue;
					}
					if (!myUnit.IsWeapon)
					{
						if (!sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Ship))
						{
							continue;
						}
					}
					else if (!sensor.get_IsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Ship, (Weapon)myUnit))
					{
						continue;
					}
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(sensor);
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100280", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	internal PooledList<Sensor> GetUnit_ASSensors_LandSearch(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList, bool SonarsOnly = false)
	{
		Sensor[] array = ((theSensorList == null) ? myUnit.Sensors_Cached : theSensorList);
		PooledList<Sensor> result;
		if (array == null)
		{
			result = null;
		}
		else
		{
			PooledList<Sensor> pooledList = null;
			int num = array.Length;
			try
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = array[i];
					if ((ActiveCapableSensorsOnly && !sensor.CanBeActive) || (EmmittingSensorsOnly && !sensor.IsActive()) || (OnlySensorsScanningThisPulse && !sensor.IsScanningOnThisPulse) || !sensor.CanPerformVolumeSearch.Value || (OnlyOperatingSensors && !sensor.IsOperating))
					{
						continue;
					}
					if (!myUnit.IsWeapon)
					{
						if (!sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Facility))
						{
							continue;
						}
					}
					else if (!sensor.get_IsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Facility, (Weapon)myUnit))
					{
						continue;
					}
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(sensor);
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100281", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = pooledList;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	internal PooledList<Sensor> GetUnit_ASWSensor(bool ActiveCapableSensorsOnly, bool EmmittingSensorsOnly, bool OnlyOperatingSensors, bool OnlySensorsScanningThisPulse, ref Sensor[] theSensorList, bool SonarsOnly = false)
	{
		PooledList<Sensor> pooledList = null;
		Sensor[] array = ((theSensorList == null) ? myUnit.Sensors_Cached : theSensorList);
		PooledList<Sensor> result;
		if (array != null)
		{
			int num = array.Length;
			try
			{
				int num2 = num - 1;
				for (int i = 0; i <= num2; i++)
				{
					Sensor sensor = array[i];
					if (sensor == null || (SonarsOnly && !sensor.IsSonar) || (ActiveCapableSensorsOnly && !sensor.CanBeActive) || (EmmittingSensorsOnly && !sensor.IsActive()) || (OnlySensorsScanningThisPulse && !sensor.IsScanningOnThisPulse) || !sensor.CanPerformVolumeSearch.Value || (OnlyOperatingSensors && !sensor.IsOperating))
					{
						continue;
					}
					if (!myUnit.IsWeapon)
					{
						if (!sensor.get_IsSuitableForThisTargetType(GlobalVariables.ActiveUnitType.Submarine))
						{
							continue;
						}
					}
					else if (((Weapon)myUnit).Type != Weapon._WeaponType.Sonobuoy && !sensor.get_IsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Submarine, (Weapon)myUnit) && (!sensor.get_IsSuitableForThisTargetType_WeaponSensor(GlobalVariables.ActiveUnitType.Ship, (Weapon)myUnit) || !myUnit.IsTorpedo))
					{
						continue;
					}
					if (pooledList == null)
					{
						pooledList = new PooledList<Sensor>();
					}
					pooledList.Add(sensor);
				}
				result = pooledList;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100282", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				result = null;
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	public void CheckMountDirectors()
	{
		try
		{
			bool flag = false;
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			Sensor[] array = sensors_Cached;
			foreach (Sensor sensor in array)
			{
				if (sensor != null && sensor.TargetsTrackedForFireControl_Readonly.Contains(myUnit.AI.PrimaryTarget))
				{
					flag = true;
					break;
				}
			}
			Sensor[] array2 = sensors_Cached;
			foreach (Sensor sensor2 in array2)
			{
				if (sensor2 == null || sensor2.TargetsTrackedForFireControl_Readonly.Count <= 0)
				{
					continue;
				}
				if (sensor2.SemiActiveWeaponsGuided.Count != 0)
				{
					List<Contact> list = new List<Contact>();
					foreach (Contact item in sensor2.TargetsTrackedForFireControl_Readonly)
					{
						if (!Information.IsNothing((object)item))
						{
							if (item.get_IsDestroyed(myUnit.ParentScen))
							{
								list.Add(item);
							}
						}
						else
						{
							list.Add(item);
						}
					}
					foreach (Contact item2 in list)
					{
						sensor2.StopTrackingTarget(item2);
					}
					continue;
				}
				List<Contact> list2 = new List<Contact>();
				foreach (Contact item3 in sensor2.TargetsTrackedForFireControl_Readonly)
				{
					if (item3 == null || item3.get_IsOutOfUnguidedWeaponsRange(myUnit))
					{
						list2.Add(item3);
					}
				}
				if (!flag && !sensor2.HasFireControlChannelAvailable())
				{
					list2.Add(sensor2.TargetsTrackedForFireControl_Readonly.ElementAtOrDefault(0));
				}
				foreach (Contact item4 in list2)
				{
					sensor2.StopTrackingTarget(item4);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100283", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ApplyP2PContactOverrides()
	{
		try
		{
			TObservableDictionary<string, Contact> contacts_Local = Contacts_Local;
			if (contacts_Local == null)
			{
				return;
			}
			DateTime time = myUnit.ParentScen.Time;
			TDictionary<string, P2PContacSnaphot> tDictionary = new TDictionary<string, P2PContacSnaphot>(contacts_Local.Count);
			foreach (KeyValuePair<string, Contact> item in contacts_Local)
			{
				Contact value = item.Value;
				if (value == null)
				{
					continue;
				}
				string objectID = value.ObjectID;
				string text = string.Empty;
				if (value.LastDetections != null && value.LastDetections.Count > 0)
				{
					text = value.LastDetections.Last().DetectorUnitID;
				}
				bool flag = Operators.CompareString(text, myUnit.ObjectID, false) == 0;
				ActiveUnit_CommStuff.TransmissionContactData value2 = default(ActiveUnit_CommStuff.TransmissionContactData);
				bool flag2;
				if ((flag2 = myUnit.CommStuff.ContactsInfoGrade.TryGetValue(objectID, out value2)) && value2.IsFrozen)
				{
					P2PContacSnaphot value3;
					DateTime dateTime = ((!tdictionary_0.TryGetValue(objectID, out value3) || DateTime.Compare(value3.FrozenAt, DateTime.MinValue) == 0) ? value2.LastUpdate : value3.FrozenAt);
					tDictionary.Add(objectID, new P2PContacSnaphot
					{
						Latitude = value2.Latitude,
						Longitude = value2.Longitude,
						Altitude = value2.Altitude,
						Heading = value2.Heading,
						Speed = value2.Speed,
						Age = (float)time.Subtract(dateTime).TotalSeconds,
						KnownThroughComms = true,
						FrozenAt = dateTime
					});
					continue;
				}
				if (flag2 && !flag)
				{
					((Module_Unit.Unit)value).set_Latitude((GlobalVariables.BooleanObject)null, value2.Latitude);
					((Module_Unit.Unit)value).set_Longitude((GlobalVariables.BooleanObject)null, value2.Longitude);
					((Module_Unit.Unit)value).set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, value2.Altitude);
					value.CurrentHeading = value2.Heading;
					value.CurrentSpeed = value2.Speed;
				}
				float age = ((!flag2 || flag) ? value.Age : ((float)time.Subtract(value2.LastUpdate).TotalSeconds));
				tDictionary.Add(objectID, new P2PContacSnaphot
				{
					Latitude = ((Module_Unit.Unit)value).get_Latitude((GlobalVariables.BooleanObject)null),
					Longitude = ((Module_Unit.Unit)value).get_Longitude((GlobalVariables.BooleanObject)null),
					Altitude = ((Module_Unit.Unit)value).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null),
					Heading = value.CurrentHeading,
					Speed = value.CurrentSpeed,
					Age = age,
					KnownThroughComms = !flag,
					FrozenAt = DateTime.MinValue
				});
			}
			tdictionary_0 = tDictionary;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1254145141110", ex2.Message);
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void UpdateContactData_Local(ref string theAU_ObjectID, List<Sensor> SensorsThatMadeDetection)
	{
		if (!_ContactsList_Local.ContainsKey(theAU_ObjectID))
		{
			return;
		}
		ContactEntry_Local contactEntry_Local = _ContactsList_Local[theAU_ObjectID];
		contactEntry_Local.NoDetectionCount = 0f;
		foreach (Sensor item in SensorsThatMadeDetection)
		{
			switch (item.Type)
			{
			case Sensor.Sensor_Type.ESM:
				contactEntry_Local.TimeSinceDetection_ESM = 0f;
				break;
			case Sensor.Sensor_Type.Radar:
				contactEntry_Local.TimeSinceDetection_Radar = 0f;
				break;
			case Sensor.Sensor_Type.Visual:
				contactEntry_Local.TimeSinceDetection_Visual = 0f;
				break;
			case Sensor.Sensor_Type.Infrared:
				contactEntry_Local.TimeSinceDetection_Infrared = 0f;
				break;
			case Sensor.Sensor_Type.PingIntercept:
				contactEntry_Local.TimeSinceDetection_SonarPassive = 0f;
				break;
			case Sensor.Sensor_Type.HullSonar_PassiveOnly:
			case Sensor.Sensor_Type.HullSonar_ActivePassive:
			case Sensor.Sensor_Type.HullSonar_ActiveOnly:
			case Sensor.Sensor_Type.TowedArray_PassiveOnly:
			case Sensor.Sensor_Type.TowedArray_ActivePassive:
			case Sensor.Sensor_Type.TowedArray_ActiveOnly:
			case Sensor.Sensor_Type.VDS_PassiveOnly:
			case Sensor.Sensor_Type.VDS_ActivePassive:
			case Sensor.Sensor_Type.VDS_ActiveOnly:
			case Sensor.Sensor_Type.DippingSonar_PassiveOnly:
			case Sensor.Sensor_Type.DippingSonar_ActivePassive:
			case Sensor.Sensor_Type.DippingSonar_ActiveOnly:
			case Sensor.Sensor_Type.BottomFixedSonar_PassiveOnly:
				if (!item.HasActiveModeOnly)
				{
					if (!item.IsActive())
					{
						contactEntry_Local.TimeSinceDetection_SonarPassive = 0f;
					}
					else
					{
						contactEntry_Local.TimeSinceDetection_SonarActive = 0f;
					}
				}
				else
				{
					contactEntry_Local.TimeSinceDetection_SonarActive = 0f;
				}
				break;
			}
		}
	}

	internal float? GetTimeSinceDetection_Local(ref Contact theC)
	{
		float? result = default(float?);
		if (theC.ActualUnit != null)
		{
			if (_ContactsList_Local.ContainsKey(theC.ActualUnit.ObjectID))
			{
				result = _ContactsList_Local[theC.ActualUnit.ObjectID].TimeSinceDetection;
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	public void RemoveContact_Local(ref string theObjectID)
	{
		if (_ContactsList_Local.ContainsKey(theObjectID))
		{
			_ContactsList_Local.Remove(theObjectID);
		}
	}

	public void ProcessContactListChanges_Local()
	{
		try
		{
			if (NewContactsQueue_Local != null && NewContactsQueue_Local.Count > 0)
			{
				foreach (KeyValuePair<string, Contact> item in NewContactsQueue_Local)
				{
					bool flag = false;
					if (_ContactsList_Local != null && _ContactsList_Local.Count > 0)
					{
						foreach (KeyValuePair<string, ContactEntry_Local> item2 in _ContactsList_Local)
						{
							if (item2.Value != null && item2.Value.Contact != null && ((Operators.CompareString(item2.Value.Contact.ObjectID, item.Value.ObjectID, false) == 0) | (Operators.CompareString(item.Value.ActualUnit.ObjectID, item2.Value.Contact.ActualUnit.ObjectID, false) == 0)))
							{
								flag = true;
								break;
							}
						}
					}
					if (flag)
					{
						continue;
					}
					ContactEntry_Local contactEntry_Local = new ContactEntry_Local();
					contactEntry_Local.Contact = NewContactsQueue_Local[item.Key];
					if (GameGeneral.Beta_PlatformComms && myUnit.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.PointToPointComm))
					{
						ActiveUnit_CommStuff.TransmissionContactData contactGradeInfo = myUnit.CommStuff.GetContactGradeInfo(contactEntry_Local.Contact.ObjectID);
						if (contactGradeInfo.TransmittedBy == null)
						{
							contactGradeInfo.Bandwith = CommDevice.EnumCommQuality.None;
							contactGradeInfo.Latency = CommDevice.EnumCommLatency.None;
						}
					}
					if (!_ContactsList_Local.ContainsKey(item.Value.ActualUnit.ObjectID))
					{
						_ContactsList_Local.Add(item.Value.ActualUnit.ObjectID, contactEntry_Local);
					}
					else
					{
						_ContactsList_Local[item.Value.ActualUnit.ObjectID] = contactEntry_Local;
					}
				}
				NewContactsQueue_Local.Clear();
			}
			if (DroppedContactsQueue_Local != null && DroppedContactsQueue_Local.Count > 0)
			{
				foreach (string key in DroppedContactsQueue_Local.Keys)
				{
					_ContactsList_Local.Remove(key);
				}
				DroppedContactsQueue_Local.Clear();
			}
			if (myUnit.IsWeapon && myUnit.AI.PrimaryTarget == null && _ContactsList_Local.Count > 0)
			{
				Weapon weapon = (Weapon)myUnit;
				if (weapon.HasGoneAutonomous)
				{
					weapon.AI.TimeToNextTargetsEvaluation = 0f;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101220", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void AgeLocalAndPrivateContacts(float elapsedTime)
	{
		try
		{
			if (_ContactsList_Local.Count > 0)
			{
				foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
				{
					if (item.Value == null)
					{
						continue;
					}
					ContactEntry_Local value = item.Value;
					value.TimeSinceDetection = item.Value.TimeSinceDetection + elapsedTime;
					if (value.TimeSinceDetection > (float)myUnit.OODA_Targeting)
					{
						if (myUnit.OODA_Targeting > 0 && myUnit.get_UnitSide(SetSideOnly: false).WeaponSalvosForThisTarget(value.Contact).Count > 0)
						{
							value.NoDetectionCount = 0f;
						}
						else if (value.NoDetectionCount > 300f)
						{
							DroppedContactsQueue_Local.AddIfNotExistsElseUpdate(item.Key, value.Contact);
						}
						else
						{
							float num = 1f;
							if (myUnit.ParentScen.UsesHighFidelity())
							{
								num = 10f;
							}
							value.NoDetectionCount += 1f / num;
						}
					}
					if (value.TimeSinceDetection_Radar.HasValue)
					{
						value.TimeSinceDetection_Radar = Misc.AddSingleToSignificantDigit(value.TimeSinceDetection_Radar.Value, elapsedTime, 1);
					}
					if (value.TimeSinceDetection_ESM.HasValue)
					{
						value.TimeSinceDetection_ESM = Misc.AddSingleToSignificantDigit(value.TimeSinceDetection_ESM.Value, elapsedTime, 1);
					}
					if (value.TimeSinceDetection_Visual.HasValue)
					{
						value.TimeSinceDetection_Visual = Misc.AddSingleToSignificantDigit(value.TimeSinceDetection_Visual.Value, elapsedTime, 1);
					}
					if (value.TimeSinceDetection_Infrared.HasValue)
					{
						value.TimeSinceDetection_Infrared = Misc.AddSingleToSignificantDigit(value.TimeSinceDetection_Infrared.Value, elapsedTime, 1);
					}
					if (value.TimeSinceDetection_SonarActive.HasValue)
					{
						value.TimeSinceDetection_SonarActive = Misc.AddSingleToSignificantDigit(value.TimeSinceDetection_SonarActive.Value, elapsedTime, 1);
					}
					if (value.TimeSinceDetection_SonarPassive.HasValue)
					{
						value.TimeSinceDetection_SonarPassive = Misc.AddSingleToSignificantDigit(value.TimeSinceDetection_SonarPassive.Value, elapsedTime, 1);
					}
				}
			}
			if (!myUnit.ParentScen.SecondIsChangingOnThisPulse || _ContactsList_OffGrid.Count <= 0)
			{
				return;
			}
			foreach (Contact value2 in _ContactsList_OffGrid.Values)
			{
				Contact.IncreaseAge(value2, myUnit.get_UnitSide(SetSideOnly: false), myUnit.ParentScen.ElapsedTimeSinceLastSecondChangeCheck, myUnit.ParentScen);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101223", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void Housekeeping_PrePulse(float elapsedTime)
	{
		if (dictionary_0.Count > 0)
		{
			dictionary_0.Clear();
		}
		if (myUnit.IsOperating())
		{
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			if (sensors_Cached != null && sensors_Cached.Length > 0)
			{
				try
				{
					Sensor[] array = sensors_Cached;
					foreach (Sensor sensor in array)
					{
						if (sensor != null && sensor.HasResolutionCell())
						{
							sensor.ReCalculateResolutionCell();
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
		}
		if (myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			return;
		}
		PooledList<Contact> pooledList = PrivateContactList();
		for (int j = pooledList.Count - 1; j >= 0; j += -1)
		{
			Contact contact;
			try
			{
				contact = pooledList[j];
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
				continue;
			}
			contact?.PrePulseHousekeeping(elapsedTime, myUnit.ParentScen);
		}
	}

	public void Housekeeping_PostPulse(float elapsedTime)
	{
		_Closure$__166-0 arg = default(_Closure$__166-0);
		_Closure$__166-0 CS$<>8__locals5 = new _Closure$__166-0(arg);
		CS$<>8__locals5.$VB$Me = this;
		CS$<>8__locals5.$VB$Local_elapsedTime = elapsedTime;
		if (dictionary_0.Count > 0)
		{
			dictionary_0.Clear();
		}
		if (!myUnit.CommStuff.IsConnectedToSideNetwork)
		{
			List<Contact> list = new List<Contact>(PrivateContactList());
			if (list.Count > 0)
			{
				Parallel.ForEach(list, [SpecialName] (Contact theC) =>
				{
					theC?.PostPulseHousekeeping(CS$<>8__locals5.$VB$Local_elapsedTime, CS$<>8__locals5.$VB$Me.myUnit.get_UnitSide(SetSideOnly: false), CS$<>8__locals5.$VB$Me.myUnit.ParentScen, IsPrivateContact: true);
				});
			}
			method_28();
		}
		if (myUnit.IsOperating())
		{
			Sensor[] sensors_Cached = myUnit.Sensors_Cached;
			for (int num = 0; num < sensors_Cached.Length; num = checked(num + 1))
			{
				sensors_Cached[num]?.DetectionChecksThisPulse?.Clear();
			}
		}
	}

	private void method_28()
	{
		try
		{
			if (_ContactsList_OffGrid.Count <= 0)
			{
				return;
			}
			Contact[] array = _ContactsList_OffGrid.Values.ToArray();
			foreach (Contact contact in array)
			{
				if (contact != null && !contact.IsDueToExpire() && !contact.get_IsDestroyed(myUnit.ParentScen))
				{
					continue;
				}
				myUnit.ParentScen.AddMessage(myUnit.Name + ": Private contact " + contact.Name + " has been lost.", contact.Name + " vanished", LoggedMessage.MessageType.CommsIsolatedMessage, 5, null, myUnit.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(((Module_Unit.Unit)contact).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact).get_Latitude((GlobalVariables.BooleanObject)null)));
				try
				{
					_ContactsList_OffGrid.Remove(contact.ActualUnit?.ObjectID);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					KeyValuePair<string, Contact>[] array2 = _ContactsList_OffGrid.ToArray();
					for (int j = 0; j < array2.Length; j = checked(j + 1))
					{
						KeyValuePair<string, Contact> keyValuePair = array2[j];
						if (keyValuePair.Value == contact)
						{
							_ContactsList_OffGrid.Remove(keyValuePair.Key);
							break;
						}
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 300011", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void PostDeserializationHousekeeping_LocalAndPrivateContacts(ref ActiveUnit theAU, ConcurrentDictionary<string, ScenarioObject> ObjectsDictionary)
	{
		foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
		{
			if (theAU.get_UnitSide(SetSideOnly: false).Contacts.ContainsKey(item.Key))
			{
				item.Value.Contact = theAU.get_UnitSide(SetSideOnly: false).Contacts[item.Key];
			}
		}
		foreach (Contact value in _ContactsList_OffGrid.Values)
		{
			ref Scenario parentScen = ref myUnit.ParentScen;
			ActiveUnit activeUnit;
			Side theSide = (activeUnit = myUnit).get_UnitSide(SetSideOnly: false);
			value.PostDeserializationHousekeeping(ref parentScen, ref ObjectsDictionary, ref theSide);
			activeUnit.set_UnitSide(SetSideOnly: false, theSide);
		}
	}

	public void DestroyLocalContacts()
	{
		try
		{
			foreach (KeyValuePair<string, ContactEntry_Local> item in _ContactsList_Local)
			{
				if (!Information.IsNothing((object)item.Value.Contact) && !Information.IsNothing((object)item.Value.Contact.ActualUnit))
				{
					item.Value.Contact.ActualUnit = null;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101225", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_29(DockFacility dockFacility_0, Sensor sensor_1, Contact contact_0, float float_0)
	{
		if (!dockFacility_0.IsOpenDockFacility || dockFacility_0.HostedBoats.Count == 0)
		{
			return;
		}
		float num = default(float);
		foreach (ActiveUnit value2 in dockFacility_0.HostedBoats.Values)
		{
			num = sensor_1.MaxIDRangeOnThisTarget(myUnit, value2);
			if (!(num * 3f >= float_0))
			{
				continue;
			}
			Contact.HostedUnitReconRecord hostedUnitReconRecord = null;
			foreach (Contact.HostedUnitReconRecord item in contact_0.Recon_HostedUnits(myUnit.get_UnitSide(SetSideOnly: false)))
			{
				if (Operators.CompareString(item.UnitID, value2.ObjectID, false) == 0)
				{
					hostedUnitReconRecord = item;
					hostedUnitReconRecord.ReconAge = 0f;
					break;
				}
			}
			if (!Information.IsNothing((object)hostedUnitReconRecord))
			{
				if (float_0 < num)
				{
					if (hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownClass)
					{
						hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownClass;
						myUnit.AddMessage(value2.UnitType_String + " previously spotted on " + contact_0.Name + " has been identified as: " + value2.UnitClass + " (recon by: " + myUnit.Name + " - Sensor: " + sensor_1.Name + "). ", "Contact report", LoggedMessage.MessageType.ContactChange, 0, new Geopoint_Struct(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null)));
					}
				}
				else if (float_0 < num * 2f && hostedUnitReconRecord.IDStatus < Contact_Base.IdentificationStatus.KnownType)
				{
					hostedUnitReconRecord.IDStatus = Contact_Base.IdentificationStatus.KnownType;
					myUnit.AddMessage(value2.UnitType_String + " previously spotted on " + contact_0.Name + " has been type-classified as: " + value2.SubTypeDescription + " (recon by: " + myUnit.Name + " - Sensor: " + sensor_1.Name + "). ", "Contact report", LoggedMessage.MessageType.ContactChange, 0, new Geopoint_Struct(((Module_Unit.Unit)contact_0).get_Longitude((GlobalVariables.BooleanObject)null), ((Module_Unit.Unit)contact_0).get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				hostedUnitReconRecord.ReconAge = 0f;
			}
			else
			{
				AddNewHostedUnitReconRecord(value2, contact_0, sensor_1);
			}
		}
		Lazy<List<Contact.HostedUnitReconRecord>> lazy = new Lazy<List<Contact.HostedUnitReconRecord>>();
		foreach (Contact.HostedUnitReconRecord item2 in contact_0.Recon_HostedUnits(myUnit.get_UnitSide(SetSideOnly: false)))
		{
			myUnit.ParentScen.ActiveUnits.TryGetValue(item2.UnitID, out var value);
			if (value != null)
			{
				if (!dockFacility_0.ParentPlatform.DockingOps.EmbarkedBoats_ReadOnly.Contains(value) && (!value.IsAircraft || !dockFacility_0.ParentPlatform.AirOps.EmbarkedAircraft_ReadOnly.Contains((Aircraft)value)) && float_0 < num * 2f)
				{
					lazy.Value.Add(item2);
				}
			}
			else if (float_0 < num * 2f)
			{
				lazy.Value.Add(item2);
			}
		}
		foreach (Contact.HostedUnitReconRecord item3 in lazy.Value)
		{
			RemoveHostedUnitRecord(contact_0, item3);
		}
	}

	internal void RemoveHostedUnitRecord(Contact HostContact, Contact.HostedUnitReconRecord theRec)
	{
		HostContact.Recon_HostedUnits(myUnit.get_UnitSide(SetSideOnly: false)).Remove(theRec);
		HashSet<string> FriendsList = new HashSet<string>();
		myUnit.get_UnitSide(SetSideOnly: false).GetAllFriendlySides(myUnit.ParentScen, ref FriendsList);
		Side[] sides_ReadOnly = myUnit.ParentScen.Sides_ReadOnly;
		foreach (Side side in sides_ReadOnly)
		{
			if (!FriendsList.Contains(side.Name) || !side.Contacts.TryGetValue(HostContact.ActualUnit.ObjectID, out var value))
			{
				continue;
			}
			foreach (Contact.HostedUnitReconRecord item in value.Recon_HostedUnits(side))
			{
				if (Operators.CompareString(item.UnitID, theRec.UnitID, false) == 0)
				{
					value.Recon_HostedUnits(side).Remove(item);
					break;
				}
			}
		}
	}

	private void method_30()
	{
		if (SuccessfulDetectionsOnThisPulse == null || SuccessfulDetectionsOnThisPulse.Count < 2)
		{
			return;
		}
		ConcurrentQueue<(Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>)> concurrentQueue = null;
		foreach (var item in SuccessfulDetectionsOnThisPulse)
		{
			List<Sensor> list = new List<Sensor>(item.Item3);
			foreach (Sensor item2 in list)
			{
				if (item2.HasResolutionCell() && item2.MaskedByCloserTargetInResolutionCell(item.Item2, SuccessfulDetectionsOnThisPulse))
				{
					item.Item3.Remove(item2);
				}
			}
			if (item.Item3.Count != 0)
			{
				concurrentQueue?.Enqueue(item);
			}
			else
			{
				if (concurrentQueue != null)
				{
					continue;
				}
				concurrentQueue = new ConcurrentQueue<(Contact, ActiveUnit, List<Sensor>, float, SpecialDetectionMode, DateTime, List<Geopoint_Struct>)>();
				foreach (var item3 in SuccessfulDetectionsOnThisPulse)
				{
					if (!item3.Equals(item))
					{
						concurrentQueue.Enqueue(item3);
						continue;
					}
					break;
				}
			}
		}
		if (concurrentQueue != null)
		{
			SuccessfulDetectionsOnThisPulse = concurrentQueue;
		}
	}

	internal ActiveEmissionInterval GetIntermittentEmission()
	{
		if (IntermittentEmission == null)
		{
			IntermittentEmission = new ActiveEmissionInterval(this);
		}
		return IntermittentEmission;
	}

	internal void AddTransmissionToMergeBuffer(TransmissionWithFeedback value)
	{
		concurrentBag_0.Add(value);
	}

	public void ProcessQueuedTransmission(float elapsedTime)
	{
		try
		{
			if (concurrentBag_0.Count == 0)
			{
				return;
			}
			List<TransmissionWithFeedback> list = (from x in concurrentBag_0.ToList()
				orderby x.result
				select x).ToList();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (TransmissionWithFeedback item in list)
			{
				bool flag = false;
				if (Contacts_Local != null)
				{
					foreach (KeyValuePair<string, Contact> item2 in Contacts_Local)
					{
						if (item2.Value.ActualUnit != null && Operators.CompareString(item2.Value.ActualUnit.ObjectID, item.theContact.ActualUnit.ObjectID, false) == 0)
						{
							if (item2.Value.LastDetections.Count > 0 && item.theContact.LastDetections.Count > 0 && DateTime.Compare(item2.Value.LastDetections.Last().theTime, item.theContact.LastDetections.Last().theTime) > 0)
							{
								flag = true;
							}
							break;
						}
					}
				}
				if (flag || hashSet.Contains(item.theContact.ObjectID))
				{
					continue;
				}
				if (item.result == TransmissionFeedbacResult.Invalid)
				{
					hashSet.Add(item.theContact.ObjectID);
					Contact theContact = item.theContact;
					Contact value = null;
					if (Contacts_Local != null)
					{
						Contacts_Local.TryGetValue(theContact.ObjectID, out value);
					}
					else
					{
						Contacts_Local = new TObservableDictionary<string, Contact>();
					}
					if (value == null)
					{
						Contacts_Local.TryGetValue(theContact.ActualUnit.ObjectID, out value);
					}
				}
				else
				{
					hashSet.Add(item.theContact.ObjectID);
					Contact theContact2 = item.theContact;
					bool flag2 = false;
					Contact value2 = null;
					if (Contacts_Local == null)
					{
						Contacts_Local = new TObservableDictionary<string, Contact>();
					}
					else
					{
						Contacts_Local.TryGetValue(theContact2.ObjectID, out value2);
					}
					if (value2 == null)
					{
						Contacts_Local.TryGetValue(theContact2.ActualUnit.ObjectID, out value2);
						if (value2 != null)
						{
							flag2 = true;
						}
					}
					TransmissionFeedbacResult result;
					if (value2 == null)
					{
						Contacts_Local.Add(theContact2.ObjectID, theContact2);
						result = TransmissionFeedbacResult.Added;
					}
					else if (method_31(theContact2, value2))
					{
						int num;
						if (flag2)
						{
							Contacts_Local[theContact2.ActualUnit.ObjectID] = theContact2;
							num = 2;
						}
						else
						{
							Contacts_Local[theContact2.ObjectID] = theContact2;
							num = 2;
						}
						result = (TransmissionFeedbacResult)num;
					}
					else
					{
						result = TransmissionFeedbacResult.Discarded;
					}
					item.result = result;
				}
				myUnit.CommStuff.UpdateNetworkLasttransmission(item.theTransmission);
				myUnit.CommStuff.PushTransmissionFeedbackToSide(item);
				if (item.result != TransmissionFeedbacResult.Invalid)
				{
					myUnit.get_UnitSide(SetSideOnly: false).ExportContactTransmissionWithFeedback(item);
				}
			}
			concurrentBag_0 = new ConcurrentBag<TransmissionWithFeedback>();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 9653231111215_2", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private bool method_31(Contact contact_0, Contact contact_1)
	{
		if (contact_1 != null)
		{
			if (contact_0 != null)
			{
				ActiveUnit_CommStuff.TransmissionContactData contactGradeInfo = myUnit.CommStuff.GetContactGradeInfo(contact_0.ObjectID);
				ActiveUnit_CommStuff.TransmissionContactData contactGradeInfo2 = myUnit.CommStuff.GetContactGradeInfo(contact_1.ObjectID);
				bool result = default(bool);
				try
				{
					if (contactGradeInfo2.Bandwith <= contactGradeInfo.Bandwith)
					{
						result = DateTime.Compare(contactGradeInfo.LastUpdate, contact_0.LastDetections.Last().theTime) <= 0;
						return result;
					}
					double latencyInSeconds = CommDevice.GetLatencyInSeconds((int)contactGradeInfo2.Latency);
					if (DateTime.Compare(contact_1.LastDetections.Last().theTime.AddSeconds(latencyInSeconds), myUnit.ParentScen.Time) <= 0)
					{
						result = false;
						return result;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					ex2?.Data.Add("Error at 9653231111215_9", "");
					GameGeneral.WriteExceptionsToLog(ex2);
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					ProjectData.ClearProjectError();
				}
				return result;
			}
			return false;
		}
		return true;
	}

	private void method_32(object sender, NotifyCollectionChangedEventArgs e)
	{
		Contacts_Local = null;
	}

	~ActiveUnit_Sensory()
	{
		base.Finalize();
	}

	static ActiveUnit_Sensory()
	{
		Class72.smethod_20();
	}
}
