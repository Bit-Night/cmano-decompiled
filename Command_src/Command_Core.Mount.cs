using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Cysharp.Text;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Mount : PlatformComponent, ICargoClient
{
	public delegate void MountWeaponRecordAddedEventHandler(string MountObjectID, string WeaponRecObjectID);

	public delegate void MountWeaponRecordRemovedEventHandler(string MountObjectID, string WeaponRecObjectID);

	public enum _ReloadStatus : byte
	{
		Ready,
		Reloading,
		Unloading
	}

	public GlobalVariables.ArmorRating ArmorRating;

	public int ROF;

	public int MaxCapacity;

	public bool IsAutonomous;

	public bool IsLogistic;

	public bool LocalControl;

	public bool IsTrainable;

	public _ReloadStatus ReloadStatus;

	public bool ReserveTarget;

	[AccessedThroughProperty("MountWeapons")]
	[CompilerGenerated]
	private ObservableList<WeaponRec> observableList_0;

	private Magazine magazine_0;

	private int int_1;

	private int int_2;

	private Sensor[] sensor_0;

	public CommDevice[] CommDevices;

	private float float_0;

	private float float_1;

	public float DP;

	public bool CanHotReload;

	public HashSet<int> ReloadPriority;

	private int? nullable_0;

	private float? nullable_1;

	public HashSet<int> CompatibleDirectors;

	public bool Hypothetical;

	public float? Boresight;

	public int Cargo_Crew;

	public float Cargo_Area;

	public CargoType Cargo_Type;

	public float Cargo_Mass;

	public bool Cargo_ParadropCapable;

	public IMobileGroundUnit._MobileUnitCategory MobileUnitCategory;

	[CompilerGenerated]
	private static MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler_0;

	[CompilerGenerated]
	private static MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler_0;

	public string LastFiredWeaponID;

	public static float PersonnelMass;

	public static float PersonnelArea;

	private bool? nullable_2;

	private bool? nullable_3;

	public virtual ObservableList<WeaponRec> MountWeapons
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponRec>> value2 = method_4;
			EventHandler<ObservableListModified<WeaponRec>> value3 = method_5;
			ObservableList<WeaponRec> observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded -= value2;
				observableList.ItemsRemoved -= value3;
			}
			observableList_0 = value;
			observableList = observableList_0;
			if (observableList != null)
			{
				observableList.ItemsAdded += value2;
				observableList.ItemsRemoved += value3;
			}
		}
	}

	public bool IsVLS
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				nullable_2 = Name.Contains(" VLS");
			}
			return nullable_2.Value;
		}
	}

	public bool IsRail
	{
		get
		{
			if (!nullable_3.HasValue)
			{
				nullable_3 = Name.Contains(" Rail");
			}
			return nullable_3.Value;
		}
	}

	public int AimpointOffset_Bearing
	{
		get
		{
			if (ParentPlatform != null)
			{
				if (Module_ActiveUnit.IsAimpointFacility(ParentPlatform))
				{
					if (!nullable_0.HasValue)
					{
						nullable_0 = GameGeneral.GlobalRNG.Next(0, 360);
					}
					return nullable_0.Value;
				}
				return 0;
			}
			return 0;
		}
	}

	public float AimpointOffset_Distance
	{
		get
		{
			if (ParentPlatform == null)
			{
				return 0f;
			}
			if (Module_ActiveUnit.IsAimpointFacility(ParentPlatform))
			{
				if (!nullable_1.HasValue)
				{
					if (MountWeapons.Count > 0)
					{
						nullable_1 = (float)((double)GameGeneral.GlobalRNG.Next(75, 101) / 100.0 * (double)((Facility)ParentPlatform).AimpointDispersalRadius);
					}
					else
					{
						nullable_1 = (float)((double)GameGeneral.GlobalRNG.Next(0, 51) / 100.0 * (double)((Facility)ParentPlatform).AimpointDispersalRadius);
					}
				}
				return nullable_1.Value;
			}
			return 0f;
		}
	}

	public float TimeToFire
	{
		get
		{
			return float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public float TimeToReloadAttempt
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public Magazine MountMagazine
	{
		get
		{
			if (magazine_0 == null)
			{
				magazine_0 = new Magazine(ParentPlatform, 0, "Magazine for mount: " + Misc.RemoveHiddenString(Name), ArmorRating, int_1, int_2, IsAviation: false);
			}
			if (magazine_0.ParentPlatform == null)
			{
				magazine_0.ParentPlatform = ParentPlatform;
			}
			return magazine_0;
		}
	}

	public bool IsCountermeasuresDispenser
	{
		get
		{
			Weapon._WeaponType type = MountWeapons[0].get_ReferenceWeapon(ParentPlatform.ParentScen).Type;
			if ((uint)(type - 2005) > 1u)
			{
				return false;
			}
			return true;
		}
	}

	public bool HasEmittingSensors
	{
		get
		{
			Sensor[] sensors_ReadOnly = Sensors_ReadOnly;
			for (int i = 0; i < sensors_ReadOnly.Length; i = checked(i + 1))
			{
				if (sensors_ReadOnly[i].IsActive())
				{
					return true;
				}
			}
			return false;
		}
	}

	public Sensor[] Sensors_ReadOnly => sensor_0;

	public bool IsEmpty => MountWeapons.Where([SpecialName] (WeaponRec WR) => WR.CurrentLoad == 0).Count() == MountWeapons.Count;

	public bool HasGuns
	{
		get
		{
			foreach (WeaponRec mountWeapon in MountWeapons)
			{
				if (mountWeapon.get_ReferenceWeapon(ParentPlatform.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool HasAAW
	{
		get
		{
			foreach (WeaponRec mountWeapon in MountWeapons)
			{
				if (mountWeapon.get_ReferenceWeapon(ParentPlatform.ParentScen).Type == Weapon._WeaponType.Gun)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsFacilityAimpoint
	{
		get
		{
			if (Module_ActiveUnit.IsAimpointFacility(ParentPlatform))
			{
				return true;
			}
			return false;
		}
	}

	public static event MountWeaponRecordAddedEventHandler MountWeaponRecordAdded
	{
		[CompilerGenerated]
		add
		{
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler = mountWeaponRecordAddedEventHandler_0;
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler2;
			do
			{
				mountWeaponRecordAddedEventHandler2 = mountWeaponRecordAddedEventHandler;
				MountWeaponRecordAddedEventHandler value2 = (MountWeaponRecordAddedEventHandler)Delegate.Combine(mountWeaponRecordAddedEventHandler2, value);
				mountWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref mountWeaponRecordAddedEventHandler_0, value2, mountWeaponRecordAddedEventHandler2);
			}
			while ((object)mountWeaponRecordAddedEventHandler != mountWeaponRecordAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler = mountWeaponRecordAddedEventHandler_0;
			MountWeaponRecordAddedEventHandler mountWeaponRecordAddedEventHandler2;
			do
			{
				mountWeaponRecordAddedEventHandler2 = mountWeaponRecordAddedEventHandler;
				MountWeaponRecordAddedEventHandler value2 = (MountWeaponRecordAddedEventHandler)Delegate.Remove(mountWeaponRecordAddedEventHandler2, value);
				mountWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref mountWeaponRecordAddedEventHandler_0, value2, mountWeaponRecordAddedEventHandler2);
			}
			while ((object)mountWeaponRecordAddedEventHandler != mountWeaponRecordAddedEventHandler2);
		}
	}

	public static event MountWeaponRecordRemovedEventHandler MountWeaponRecordRemoved
	{
		[CompilerGenerated]
		add
		{
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler = mountWeaponRecordRemovedEventHandler_0;
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler2;
			do
			{
				mountWeaponRecordRemovedEventHandler2 = mountWeaponRecordRemovedEventHandler;
				MountWeaponRecordRemovedEventHandler value2 = (MountWeaponRecordRemovedEventHandler)Delegate.Combine(mountWeaponRecordRemovedEventHandler2, value);
				mountWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref mountWeaponRecordRemovedEventHandler_0, value2, mountWeaponRecordRemovedEventHandler2);
			}
			while ((object)mountWeaponRecordRemovedEventHandler != mountWeaponRecordRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler = mountWeaponRecordRemovedEventHandler_0;
			MountWeaponRecordRemovedEventHandler mountWeaponRecordRemovedEventHandler2;
			do
			{
				mountWeaponRecordRemovedEventHandler2 = mountWeaponRecordRemovedEventHandler;
				MountWeaponRecordRemovedEventHandler value2 = (MountWeaponRecordRemovedEventHandler)Delegate.Remove(mountWeaponRecordRemovedEventHandler2, value);
				mountWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref mountWeaponRecordRemovedEventHandler_0, value2, mountWeaponRecordRemovedEventHandler2);
			}
			while ((object)mountWeaponRecordRemovedEventHandler != mountWeaponRecordRemovedEventHandler2);
		}
	}

	static Mount()
	{
		Class72.smethod_20();
		PersonnelMass = 0.1f;
		PersonnelArea = 0.16f;
	}

	internal bool IsLauncherOccupied()
	{
		if (string.IsNullOrEmpty(LastFiredWeaponID))
		{
			return false;
		}
		ActiveUnit value = null;
		ActiveUnit parentPlatform = _ParentPlatform;
		int result;
		if (parentPlatform == null)
		{
			result = 0;
		}
		else if (!parentPlatform.ParentScen.ActiveUnits.TryGetValue(LastFiredWeaponID, out value))
		{
			result = 0;
		}
		else
		{
			if (value.IsWeapon)
			{
				return ((Weapon)value).Flags.LauncherOccupiedDuringGuidance;
			}
			result = 0;
		}
		return (byte)result != 0;
	}

	public override void ResetIDs()
	{
		checked
		{
			try
			{
				base.ResetIDs();
				foreach (WeaponRec mountWeapon in MountWeapons)
				{
					mountWeapon.ResetIDs();
				}
				if (!Information.IsNothing((object)magazine_0))
				{
					magazine_0.ResetIDs();
				}
				Sensor[] array = sensor_0;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ResetIDs();
				}
				CommDevice[] commDevices = CommDevices;
				for (int j = 0; j < commDevices.Length; j++)
				{
					commDevices[j].ResetIDs();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100675", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	public string ToXML(ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		string result = default(string);
		try
		{
			utf16ValueStringBuilder.Append("<Mount>");
			try
			{
				utf16ValueStringBuilder.Append("<ID>");
				utf16ValueStringBuilder.Append(ObjectID);
				utf16ValueStringBuilder.Append("</ID>");
				if (ObjectsAlreadySerialized != null)
				{
					if (ObjectsAlreadySerialized.Contains(ObjectID))
					{
						utf16ValueStringBuilder.Append("</Mount>");
						result = utf16ValueStringBuilder.ToString();
						return result;
					}
					ObjectsAlreadySerialized.Add(ObjectID);
				}
				if (!string.IsNullOrEmpty(Name))
				{
					utf16ValueStringBuilder.Append("<Name>");
					utf16ValueStringBuilder.Append(SecurityElement.Escape(Name));
					utf16ValueStringBuilder.Append("</Name>");
				}
				if (_Status != _ComponentStatus.Operational)
				{
					utf16ValueStringBuilder.Append("<Status>");
					byte status = (byte)_Status;
					utf16ValueStringBuilder.Append(status.ToString());
					utf16ValueStringBuilder.Append("</Status>");
				}
				if (base.DamageSeverity != _DamageSeverityFactor.Light)
				{
					utf16ValueStringBuilder.Append("<DamageSeverity>");
					utf16ValueStringBuilder.Append(((byte)base.DamageSeverity).ToString());
					utf16ValueStringBuilder.Append("</DamageSeverity>");
				}
				if (_ParentPlatform != null)
				{
					utf16ValueStringBuilder.Append("<PP>");
					utf16ValueStringBuilder.Append(_ParentPlatform.ObjectID);
					utf16ValueStringBuilder.Append("</PP>");
				}
				if (Boresight.HasValue)
				{
					utf16ValueStringBuilder.Append("<Boresight>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(Boresight.Value));
					utf16ValueStringBuilder.Append("</Boresight>");
				}
				utf16ValueStringBuilder.Append("<DBID>");
				utf16ValueStringBuilder.Append(DBID.ToString());
				utf16ValueStringBuilder.Append("</DBID>");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100676-A", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (MountWeapons.Count > 0)
				{
					utf16ValueStringBuilder.Append("<MW>");
					foreach (WeaponRec mountWeapon in MountWeapons)
					{
						utf16ValueStringBuilder.Append(mountWeapon.ToXML(ObjectsAlreadySerialized, theScen));
					}
					utf16ValueStringBuilder.Append("</MW>");
				}
				if (MountMagazine.Weapons.Count > 0)
				{
					utf16ValueStringBuilder.Append("<MMW>");
					foreach (WeaponRec weapon in MountMagazine.Weapons)
					{
						utf16ValueStringBuilder.Append(weapon.ToXML(ObjectsAlreadySerialized, theScen));
					}
					utf16ValueStringBuilder.Append("</MMW>");
				}
				if (sensor_0.Length > 0)
				{
					utf16ValueStringBuilder.Append("<Sensors>");
					Sensor[] array = sensor_0;
					foreach (Sensor sensor in array)
					{
						utf16ValueStringBuilder.Append(sensor.ToXML(ObjectsAlreadySerialized));
					}
					utf16ValueStringBuilder.Append("</Sensors>");
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ex4?.Data.Add("Error at 100676-B", "");
				GameGeneral.WriteExceptionsToLog(ex4);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			try
			{
				if (CommDevices.Length > 0)
				{
					utf16ValueStringBuilder.Append("<CommDevices>");
					CommDevice[] commDevices = CommDevices;
					foreach (CommDevice commDevice in commDevices)
					{
						utf16ValueStringBuilder.Append(commDevice.ToXML(ref ObjectsAlreadySerialized));
					}
					utf16ValueStringBuilder.Append("</CommDevices>");
				}
				if (Coverage.HasDefinedArcs)
				{
					utf16ValueStringBuilder.Append(Coverage.ToXML(IsIlluminate: false));
				}
				if (float_0 != 0f)
				{
					utf16ValueStringBuilder.Append("<TTF>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(float_0));
					utf16ValueStringBuilder.Append("</TTF>");
				}
				if (MountMagazine.TimeToFire != 0f)
				{
					utf16ValueStringBuilder.Append("<TTF_MountMagazine>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(MountMagazine.TimeToFire));
					utf16ValueStringBuilder.Append("</TTF_MountMagazine>");
				}
				utf16ValueStringBuilder.Append("<DP>");
				utf16ValueStringBuilder.Append(XmlConvert.ToString(DP));
				utf16ValueStringBuilder.Append("</DP>");
				if (float_1 != 0f)
				{
					utf16ValueStringBuilder.Append("<TTRA>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(float_1));
					utf16ValueStringBuilder.Append("</TTRA>");
				}
				if (ReserveTarget)
				{
					utf16ValueStringBuilder.Append("<ReserveTarget>True</ReserveTarget>");
				}
				if (ReloadStatus != _ReloadStatus.Ready)
				{
					utf16ValueStringBuilder.Append("<ReloadStatus>");
					utf16ValueStringBuilder.Append((byte)ReloadStatus);
					utf16ValueStringBuilder.Append("</ReloadStatus>");
				}
				if (ReloadPriority.Count > 0)
				{
					utf16ValueStringBuilder.Append("<RPriority>");
					utf16ValueStringBuilder.Append(string.Join(",", ReloadPriority));
					utf16ValueStringBuilder.Append("</RPriority>");
				}
				if (AimpointOffset_Bearing != 0)
				{
					utf16ValueStringBuilder.Append("<AO_B>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(AimpointOffset_Bearing));
					utf16ValueStringBuilder.Append("</AO_B>");
				}
				if (AimpointOffset_Distance != 0f)
				{
					utf16ValueStringBuilder.Append("<AO_D>");
					utf16ValueStringBuilder.Append(XmlConvert.ToString(AimpointOffset_Distance));
					utf16ValueStringBuilder.Append("</AO_D>");
				}
				utf16ValueStringBuilder.Append("</Mount>");
				string text = utf16ValueStringBuilder.ToString();
				utf16ValueStringBuilder.Dispose();
				result = text;
				return result;
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				ex6?.Data.Add("Error at 100676-C", "");
				GameGeneral.WriteExceptionsToLog(ex6);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ex8?.Data.Add("Error at 100676", "");
			GameGeneral.WriteExceptionsToLog(ex8);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Mount FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ActiveUnit theAU)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		Mount result;
		try
		{
			int num = Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText);
			if (num != 0)
			{
				goto IL_006d;
			}
			if (!Information.IsNothing((object)Misc.GetNodeByName(theNode.ChildNodes, "Name")))
			{
				num = DBFunctions.GetMountIDByName(Misc.RemoveHiddenString(Misc.GetNodeByName(theNode.ChildNodes, "Name").InnerText), theAU.ParentScen.DBConnection);
				goto IL_006d;
			}
			result = null;
			goto end_IL_0001;
			IL_006d:
			Mount mount = DBFunctions.GetMount(num, ref theAU.ParentScen, LoadComponents: false);
			mount.ParentPlatform = theAU;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (theDictionary == null)
			{
				goto IL_00c9;
			}
			if (!theDictionary.ContainsKey(innerText))
			{
				mount.ObjectID_Set(innerText);
				theDictionary.TryAdd(mount.ObjectID, mount);
				goto IL_00c9;
			}
			result = (Mount)theDictionary[innerText];
			goto end_IL_0001;
			IL_00c9:
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				try
				{
					switch (theNode2.Name)
					{
					case "TTF_MountMagazine":
						mount.MountMagazine.TimeToFire = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "Status":
						switch (theNode2.InnerText)
						{
						case "Damaged":
							mount._Status = _ComponentStatus.Damaged;
							break;
						case "Destroyed":
							mount._Status = _ComponentStatus.Destroyed;
							break;
						default:
							mount._Status = (_ComponentStatus)Conversions.ToByte(theNode2.InnerText);
							break;
						case "Operational":
							mount._Status = _ComponentStatus.Operational;
							break;
						}
						break;
					case "DP":
						mount.DP = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "MountMagazineWeapons":
					case "MMW":
						foreach (XmlNode childNode2 in theNode2.ChildNodes)
						{
							XmlNode theNode5 = childNode2;
							WeaponRec item2 = WeaponRec.FromXML(ref theNode5, ref theDictionary, ref theAU.ParentScen);
							mount.MountMagazine.Weapons.Add(item2);
						}
						break;
					case "TTF":
						mount.float_0 = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "Sensors":
						foreach (XmlNode childNode3 in theNode2.ChildNodes)
						{
							Sensor sensor = Sensor.FromXML(childNode3, theDictionary, mount.ParentPlatform);
							sensor.ParentPlatform = theAU;
							ArrayExtensions.Add(ref mount.sensor_0, sensor);
						}
						break;
					case "ReloadStatus":
						switch (theNode2.InnerText)
						{
						case "Ready":
							mount.ReloadStatus = _ReloadStatus.Ready;
							break;
						case "Unloading":
							mount.ReloadStatus = _ReloadStatus.Unloading;
							break;
						default:
							mount.ReloadStatus = (_ReloadStatus)Conversions.ToByte(theNode2.InnerText);
							break;
						case "Reloading":
							mount.ReloadStatus = _ReloadStatus.Reloading;
							break;
						}
						break;
					case "DamageSeverity":
						mount.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(theNode2.InnerText);
						break;
					case "MW":
					case "MountWeapons":
						foreach (XmlNode childNode4 in theNode2.ChildNodes)
						{
							XmlNode theNode4 = childNode4;
							WeaponRec item = WeaponRec.FromXML(ref theNode4, ref theDictionary, ref theAU.ParentScen);
							mount.MountWeapons.Add(item);
						}
						break;
					case "ReserveTarget":
						mount.ReserveTarget = Misc.ParseBool(theNode2.InnerText);
						break;
					case "Boresight":
						mount.Boresight = Convert.ToSingle(theNode2.InnerText, CultureInfo.InvariantCulture);
						break;
					case "CommDevices":
						foreach (XmlNode childNode5 in theNode2.ChildNodes)
						{
							XmlNode theNode3 = childNode5;
							CommDevice commDevice = CommDevice.FromXML(ref theNode3, ref theDictionary, theAU);
							commDevice.ParentPlatform = theAU;
							ArrayExtensions.Add(ref mount.CommDevices, commDevice);
						}
						break;
					case "RPriority":
					case "ReloadPriority":
					{
						string[] array = theNode2.InnerText.Split(new char[1] { ',' });
						foreach (string text in array)
						{
							if (Operators.CompareString(text, "", false) != 0)
							{
								mount.ReloadPriority.Add(Conversions.ToInteger(text));
							}
						}
						break;
					}
					case "Cov":
					case "Coverage":
						mount.Coverage = _Coverage.FromXML(ref theNode2);
						break;
					case "AimpointOffset_Distance":
					case "AO_D":
						mount.nullable_1 = XmlConvert.ToSingle(theNode2.InnerText);
						break;
					case "AimpointOffset_Bearing":
					case "AO_B":
						mount.nullable_0 = XmlConvert.ToInt32(theNode2.InnerText);
						break;
					case "TTRA":
						mount.float_1 = XmlConvert.ToSingle(theNode2.InnerText);
						break;
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
			result = mount;
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100677", "");
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

	public Mount()
		: base(null)
	{
		MountWeapons = new ObservableList<WeaponRec>();
		sensor_0 = new Sensor[0];
		CommDevices = new CommDevice[0];
		ReloadPriority = new HashSet<int>();
		CompatibleDirectors = new HashSet<int>();
		LastFiredWeaponID = "";
		Coverage = new _Coverage();
	}

	internal int CurrentCapacity(ref int theQty_FullyLoadedCells, ref int theQty_PartiallyLoadedCells)
	{
		theQty_FullyLoadedCells = 0;
		theQty_PartiallyLoadedCells = 0;
		foreach (WeaponRec mountWeapon in MountWeapons)
		{
			if (mountWeapon.CurrentLoad == 0)
			{
				continue;
			}
			if (mountWeapon.Multiple > 1)
			{
				float num = (float)mountWeapon.CurrentLoad / (float)mountWeapon.Multiple;
				if (num != (float)(int)Math.Round(num))
				{
					theQty_PartiallyLoadedCells++;
					theQty_FullyLoadedCells += (int)Math.Floor((double)mountWeapon.CurrentLoad / (double)mountWeapon.Multiple);
				}
				else
				{
					theQty_FullyLoadedCells += (int)Math.Round(num);
				}
			}
			else
			{
				theQty_FullyLoadedCells += mountWeapon.CurrentLoad;
			}
		}
		return theQty_FullyLoadedCells + theQty_PartiallyLoadedCells;
	}

	public void AddSensor(Sensor theSensor)
	{
		ArrayExtensions.Add(ref sensor_0, theSensor);
		if (_ParentPlatform != null)
		{
			_ParentPlatform.Sensors_Cached = null;
		}
	}

	public void RemoveSensor(Sensor theSensor)
	{
		ArrayExtensions.Remove(ref sensor_0, theSensor);
		if (_ParentPlatform != null)
		{
			_ParentPlatform.Sensors_Cached = null;
		}
	}

	internal void Destroy_Cargo(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility)
	{
		base.Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility);
		Sensor[] array = sensor_0;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility);
			}
			CommDevice[] commDevices = CommDevices;
			for (int j = 0; j < commDevices.Length; j++)
			{
				commDevices[j].Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility);
			}
		}
	}

	public override void Destroy(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility, bool RegisterAsLosses = true)
	{
		checked
		{
			try
			{
				float num = 0f;
				if (ParentPlatform != null)
				{
					num = ParentPlatform.Damage.DamagePercent;
				}
				base.Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility, RegisterAsLosses);
				Sensor[] array = sensor_0;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility, RegisterAsLosses);
				}
				CommDevice[] commDevices = CommDevices;
				for (int j = 0; j < commDevices.Length; j++)
				{
					commDevices[j].Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility, RegisterAsLosses);
				}
				if (!IsAimpointFacility || !IsAimpointFacility || ScenEditAction)
				{
					return;
				}
				if (RegisterAsLosses)
				{
					ComponentPlatformSide.AAR.AddToLosses(this, IsAimpointFacility);
				}
				float num2 = 0f;
				if (ParentPlatform != null)
				{
					num2 = ParentPlatform.Damage.DamagePercent;
				}
				if (num2 == num)
				{
					return;
				}
				List<EventTrigger> list = new List<EventTrigger>();
				foreach (EventTrigger value in ParentPlatform.ParentScen.EventTriggers.Values)
				{
					if (value.Type == EventTrigger.EventTriggerType.UnitDamaged && ((EventTrigger_UnitDamaged)value).get_IsFulfilled(ParentPlatform, num, num2, (ActiveUnit)null))
					{
						list.Add(value);
					}
				}
				ParentPlatform.ParentScen.FireEvents(list);
				ParentPlatform._OldDamagePercent = num2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100678", "");
				GameGeneral.WriteExceptionsToLog(ex2);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
		}
	}

	private void method_1(Weapon weapon_0, double double_0, double double_1, double double_2)
	{
		if (weapon_0.Warheads.Length > 0 && weapon_0.Warheads[0].get_IsAirburst(weapon_0, ParentPlatform))
		{
			string text = " airbursted off ";
			if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
			{
				ParentPlatform.ParentScen.AddMessage("Weapon: " + weapon_0.Name + text + Misc.RemoveHiddenString(Name) + " (of " + ParentPlatform.Name + ") by " + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0))) + "m", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
			}
			else
			{
				ParentPlatform.ParentScen.AddMessage("Weapon: " + weapon_0.Name + text + Misc.RemoveHiddenString(Name) + " (of " + ParentPlatform.Name + ") by " + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0 * 3.2808399200439453))) + "ft", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
			}
		}
		else if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
		{
			ParentPlatform.ParentScen.AddMessage("Weapon: " + weapon_0.Name + " missed " + Misc.RemoveHiddenString(Name) + " (of " + ParentPlatform.Name + ") by " + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0))) + "m", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
		}
		else
		{
			ParentPlatform.ParentScen.AddMessage("Weapon: " + weapon_0.Name + " missed " + Misc.RemoveHiddenString(Name) + " (of " + ParentPlatform.Name + ") by " + Conversions.ToString(Math.Max(1, (int)Math.Round(double_0 * 3.2808399200439453))) + "ft", weapon_0.UnitClass + " near-missed", LoggedMessage.MessageType.WeaponDamage, 10, ObjectID, null, new Geopoint_Struct(double_1, double_2));
		}
	}

	public void ResolveDamageFromWeapon(Weapon theWeapon, float DistanceFromImpact_meters, float BearingFromImpact, ActiveUnit ExcludedUnit, double? Expl_Latitude, double? Expl_Longitude, float? Expl_Altitude, bool DirectHit, UnguidedWeapon theUnguidedWeapon)
	{
		try
		{
			Warhead warhead = theWeapon.Warheads[0];
			double out_lon2 = default(double);
			double out_lat2 = default(double);
			if (Module_ActiveUnit.IsAimpointFacility(ParentPlatform))
			{
				double out_lon = default(double);
				double out_lat = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, AimpointOffset_Distance / 1852f, AimpointOffset_Bearing);
				Geodesic_EdWilliams.CalcPoint_Williams(out_lon, out_lat, ref out_lon2, ref out_lat2, DistanceFromImpact_meters / 1852f, BearingFromImpact);
			}
			else
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon2, ref out_lat2, DistanceFromImpact_meters / 1852f, BearingFromImpact);
			}
			float num = (((!theWeapon.IsReEntryVehicle && !theWeapon.IsBallisticMissile) || !theWeapon.Navigator.HasPlottedCourse()) ? ((float)(Terrain.GetElevation(out_lat2, out_lon2, RequestIsFromGUI: false, theWeapon.ParentScen) + theWeapon.get_OptimumBurstHeight_AGL(ParentPlatform))) : Math.Max(theWeapon.Navigator.PlottedCourse.First().Altitude, Terrain.GetElevation(theWeapon.Navigator.PlottedCourse.First().Latitude, theWeapon.Navigator.PlottedCourse.First().Longitude, RequestIsFromGUI: false, theWeapon.ParentScen) + theWeapon.get_OptimumBurstHeight_AGL(ParentPlatform)));
			if (!Expl_Latitude.HasValue || !Expl_Longitude.HasValue)
			{
				float num2 = num - (float)Math.Max(0, (int)Terrain.GetElevation(out_lat2, out_lon2, RequestIsFromGUI: false, ParentPlatform.ParentScen));
				double out_lon3 = default(double);
				double out_lat3 = default(double);
				Geodesic_EdWilliams.CalcPoint_Williams(out_lon2, out_lat2, ref out_lon3, ref out_lat3, DistanceFromImpact_meters / 1852f, BearingFromImpact);
				Expl_Latitude = out_lat3;
				Expl_Longitude = out_lon3;
				_ = Debugger.IsAttached;
				num = num2 + (float)Math.Max(0, (int)Terrain.GetElevation(Expl_Latitude.Value, Expl_Longitude.Value, RequestIsFromGUI: false, ParentPlatform.ParentScen));
			}
			Module_Unit.Unit explodingUnit = ((theUnguidedWeapon != null) ? ((Module_Unit.Unit)theUnguidedWeapon) : ((Module_Unit.Unit)theWeapon));
			if (warhead.IsAreaEffect)
			{
				ref Scenario parentScen = ref ParentPlatform.ParentScen;
				Weapon_AI aI;
				Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
				new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, out_lon2, out_lat2, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num, theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, ExcludedUnit, null, null, 0, 0);
				aI.PrimaryTarget = thePrimaryTarget;
				double double_ = ((!warhead.IsAreaEffect_Conventional) ? Math.Sqrt(Math.Pow(Math.Abs(num - ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), 2.0) + Math.Pow(DistanceFromImpact_meters, 2.0)) : ((double)DistanceFromImpact_meters));
				method_1(theWeapon, double_, out_lon2, out_lat2);
				return;
			}
			if (DistanceFromImpact_meters == 0f)
			{
				method_2(theWeapon, ExcludedUnit, Expl_Latitude, Expl_Longitude, Expl_Altitude, theUnguidedWeapon);
			}
			else
			{
				double num3 = Math.Sqrt(Math.Pow(Math.Abs(num - ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)), 2.0) + Math.Pow(DistanceFromImpact_meters, 2.0));
				method_1(theWeapon, num3, out_lon2, out_lat2);
				if (warhead.IsExplosive || warhead.IsIncendiary)
				{
					bool landTypeEffectsEnabled = ParentPlatform.ParentScen.DeclaredFeatures.Contains(Scenario.ScenarioFeatureOption.LandTypeEffects);
					Warhead.WarheadType type = warhead.Type;
					if (type != Warhead.WarheadType.Fragmentation && type != Warhead.WarheadType.ContinuousRod && type != Warhead.WarheadType.Fragmentation_ABM)
					{
						double num4 = Warhead.BlastDamageAtThisDistance(ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), num3 / 1852.0, DP, warhead.Type, warhead.DP, Weapon.DetonationMedium.Air, landTypeEffectsEnabled, ParentPlatform.ParentScen);
						if (num4 > 0.0)
						{
							ResolveDamageFromBlast(num4, warhead.Type);
						}
					}
					else
					{
						float cutoffRange_Frag_nm = Explosion.GetCutoffRange_Frag_nm(theWeapon.Warheads[0].DP, Weapon.DetonationMedium.Air, warhead.Type);
						double damageYield = Warhead.FragDamageAtThisDistance(ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), num3 / 1852.0, warhead.Type, warhead.DP, Weapon.DetonationMedium.Air, landTypeEffectsEnabled, ParentPlatform.ParentScen);
						ResolveDamageFromFrag(damageYield, cutoffRange_Frag_nm);
					}
					ref Scenario parentScen2 = ref ParentPlatform.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = theWeapon.AI).PrimaryTarget;
					new Explosion(ref parentScen2, explodingUnit, ref thePrimaryTarget, out_lon2, out_lat2, Expl_Longitude.Value, Expl_Latitude.Value, theWeapon.CurrentHeading, num, theWeapon.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, this, null, 0, 0);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			ParentPlatform.Damage.LastWeaponHit = theWeapon;
			if (DP <= 0f)
			{
				DP = 0f;
				if (!ParentPlatform.IsWeapon)
				{
					ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a mount/weapon", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(out_lon2, out_lat2));
				}
				Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100679", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_2(Weapon weapon_0, ActiveUnit activeUnit_0, double? nullable_4, double? nullable_5, float? nullable_6, UnguidedWeapon unguidedWeapon_0)
	{
		try
		{
			double out_lat = default(double);
			double out_lon = default(double);
			float theAltitude;
			if (!Module_ActiveUnit.IsAimpointFacility(ParentPlatform))
			{
				out_lat = ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null);
				out_lon = ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null);
				theAltitude = ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			}
			else
			{
				Geodesic_EdWilliams.CalcPoint_Williams(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ref out_lon, ref out_lat, AimpointOffset_Distance / 1852f, AimpointOffset_Bearing);
				theAltitude = Terrain.GetElevation(out_lat, out_lon, RequestIsFromGUI: false, weapon_0.ParentScen) + weapon_0.get_OptimumBurstHeight_AGL(ParentPlatform);
			}
			if (unguidedWeapon_0 == null)
			{
				weapon_0.EndgameReport.AddEndGameMessage(hit: true, "Has impacted " + Misc.RemoveHiddenString(Name) + " (of " + ParentPlatform.Name + ")");
			}
			else
			{
				unguidedWeapon_0.EndgameReport.AddEndGameMessage(hit: true, "Has impacted " + Misc.RemoveHiddenString(Name) + " (of " + ParentPlatform.Name + ")");
			}
			Warhead warhead = weapon_0.Warheads[0];
			double num;
			double val = default(double);
			if (!warhead.get_IsNuclear(weapon_0.ParentScen) && !warhead.get_IsAirburst(weapon_0, ParentPlatform))
			{
				num = weapon_0.ArmorPenetrationPercent(ArmorRating, ParentPlatform.VisualSizeClass) / 100f;
				val = weapon_0.ShockDamage_KE();
			}
			else
			{
				num = 0.0;
			}
			if (Information.IsNothing((object)nullable_4) || Information.IsNothing((object)nullable_5))
			{
				nullable_4 = out_lat;
				nullable_5 = out_lon;
			}
			Module_Unit.Unit explodingUnit = ((unguidedWeapon_0 == null) ? ((Module_Unit.Unit)weapon_0) : ((Module_Unit.Unit)unguidedWeapon_0));
			double val2 = default(double);
			if (num > 0.0)
			{
				ParentPlatform.ParentScen.AddMessage(Conversions.ToString((int)Math.Round(num * 100.0)) + "% penetration achieved", ParentPlatform.Name + " - armor penetrated", LoggedMessage.MessageType.WeaponDamage, 20, weapon_0.ObjectID, null, new Geopoint_Struct(out_lon, out_lat));
				val2 = ((!warhead.IsExplosive) ? Math.Round(num * (double)warhead.DP, 2) : Math.Round(num * 2.0 * (double)warhead.DP, 2));
				if (num < 1.0 && warhead.IsExplosive)
				{
					ref Scenario parentScen = ref ParentPlatform.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = weapon_0.AI).PrimaryTarget;
					new Explosion(ref parentScen, explodingUnit, ref thePrimaryTarget, out_lon, out_lat, nullable_5.Value, nullable_4.Value, weapon_0.CurrentHeading, theAltitude, weapon_0.Type, (float)((double)warhead.DP * (1.0 - num)), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, this, null, 0, 0);
					aI.PrimaryTarget = thePrimaryTarget;
				}
				else if (((Facility)ParentPlatform).Armor_General == GlobalVariables.ArmorRating.None && warhead.IsExplosive)
				{
					ref Scenario parentScen2 = ref ParentPlatform.ParentScen;
					Weapon_AI aI;
					Contact thePrimaryTarget = (aI = weapon_0.AI).PrimaryTarget;
					new Explosion(ref parentScen2, explodingUnit, ref thePrimaryTarget, out_lon, out_lat, nullable_5.Value, nullable_4.Value, weapon_0.CurrentHeading, theAltitude, weapon_0.Type, (float)((double)warhead.DP * num * 0.25), warhead.DP, warhead.Type, warhead.ExplosivesType, null, null, null, this, null, 0, 0);
					aI.PrimaryTarget = thePrimaryTarget;
				}
			}
			else if (warhead.IsExplosive || warhead.IsIncendiary)
			{
				ref Scenario parentScen3 = ref ParentPlatform.ParentScen;
				Weapon_AI aI;
				Contact thePrimaryTarget = (aI = weapon_0.AI).PrimaryTarget;
				new Explosion(ref parentScen3, explodingUnit, ref thePrimaryTarget, out_lon, out_lat, nullable_5.Value, nullable_4.Value, weapon_0.CurrentHeading, theAltitude, weapon_0.Type, warhead.DP, warhead.DP, warhead.Type, warhead.ExplosivesType, null, this, null, null, null, 0, 0);
				aI.PrimaryTarget = thePrimaryTarget;
			}
			if (num > 0.0)
			{
				ParentPlatform.AddMessage(Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a mount/weapon", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(out_lon, out_lat));
				Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			}
			float num2 = (float)Math.Max(val, val2);
			ResolveDamageForOnboardSensors(num2);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100680", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageForOnboardSensors(double DamageYield)
	{
		foreach (Sensor item in Sensors_ReadOnly.Where([SpecialName] (Sensor theSen) => !theSen.IsMk1Eyeball))
		{
			if (DamageYield < 1.0)
			{
				if (item.DamageSeverity < _DamageSeverityFactor.Light)
				{
					if (!ParentPlatform.IsWeapon)
					{
						ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(item.Name) + " has been lightly damaged. ", ParentPlatform.Name + " - damage to sensor", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					item.Damage(_DamageSeverityFactor.Light);
				}
			}
			else if (DamageYield < 2.0)
			{
				if (item.DamageSeverity < _DamageSeverityFactor.Medium)
				{
					if (!ParentPlatform.IsWeapon)
					{
						ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(item.Name) + " has been moderately damaged. ", ParentPlatform.Name + " - damage to sensor", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					item.Damage(_DamageSeverityFactor.Medium);
				}
			}
			else if (DamageYield < 5.0)
			{
				if (item.DamageSeverity < _DamageSeverityFactor.Heavy)
				{
					if (!ParentPlatform.IsWeapon)
					{
						ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(item.Name) + " has been heavily damaged. ", ParentPlatform.Name + " - damage to sensor", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
					}
					item.Damage(_DamageSeverityFactor.Heavy);
				}
			}
			else
			{
				if (!ParentPlatform.IsWeapon)
				{
					ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(item.Name) + " has been destroyed. ", ParentPlatform.Name + " lost a sensor", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				item.Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, IsAimpointFacility: false);
			}
		}
	}

	public void ResolveDamageFromFrag(double DamageYield, float theCutOffRange_Frag, int ARM_TargetedRadar = 0)
	{
		try
		{
			if (DamageYield == 0.0)
			{
				return;
			}
			ResolveDamageForOnboardSensors(DamageYield);
			if (ArmorRating > GlobalVariables.ArmorRating.RHA_20mm)
			{
				return;
			}
			DP = (float)Math.Round((double)DP - DamageYield, 1);
			if (!(Math.Round(DamageYield, 2) > 0.0))
			{
				return;
			}
			new WeaponImpact(ref ParentPlatform.ParentScen, ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
			if (base.Status != _ComponentStatus.Operational)
			{
				ParentPlatform.AddMessage(Misc.RemoveHiddenString(Name) + " has suffered additional fragmentation damage: " + Conversions.ToString(Math.Ceiling(DamageYield)) + " DPs", Misc.RemoveHiddenString(Name) + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			else
			{
				ParentPlatform.AddMessage(Misc.RemoveHiddenString(Name) + " has suffered fragmentation damage: " + Conversions.ToString(Math.Ceiling(DamageYield)) + " DPs", Misc.RemoveHiddenString(Name) + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			if (DP <= 0f)
			{
				DP = 0f;
				if (!ParentPlatform.IsWeapon)
				{
					ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a mount/weapon", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
				return;
			}
			switch (GameGeneral.GlobalRNG.Next(0, 3))
			{
			case 0:
				if (base.DamageSeverity < _DamageSeverityFactor.Light)
				{
					Damage(_DamageSeverityFactor.Light);
				}
				break;
			default:
				if (base.DamageSeverity < _DamageSeverityFactor.Heavy)
				{
					Damage(_DamageSeverityFactor.Heavy);
				}
				break;
			case 1:
				if (base.DamageSeverity < _DamageSeverityFactor.Medium)
				{
					Damage(_DamageSeverityFactor.Medium);
				}
				break;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100681", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public void ResolveDamageFromBomblets(double DamageYield, Warhead.WarheadType theWarheadType, float ClusterCoverageLength)
	{
		try
		{
			if (DamageYield == 0.0)
			{
				return;
			}
			method_3(ref DamageYield, theWarheadType);
			DP = (float)Math.Round((double)DP - DamageYield, 1);
			ResolveDamageForOnboardSensors(DamageYield);
			if (!(Math.Round(DamageYield, 2) > 0.0))
			{
				return;
			}
			new WeaponImpact(ref ParentPlatform.ParentScen, ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
			ParentPlatform.AddMessage(Misc.RemoveHiddenString(Name) + " has suffered bomblet damage: " + Conversions.ToString(Math.Round(DamageYield, 1)) + " DPs", Misc.RemoveHiddenString(Name) + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			if (!(DP <= 0f) && (!Module_ActiveUnit.IsAimpointFacility(ParentPlatform) || !((Facility)ParentPlatform).RepresentsMobileGroundUnit))
			{
				switch (GameGeneral.GlobalRNG.Next(0, 3))
				{
				case 0:
					if (base.DamageSeverity < _DamageSeverityFactor.Light)
					{
						Damage(_DamageSeverityFactor.Light);
					}
					break;
				default:
					if (base.DamageSeverity < _DamageSeverityFactor.Heavy)
					{
						Damage(_DamageSeverityFactor.Heavy);
					}
					break;
				case 1:
					if (base.DamageSeverity < _DamageSeverityFactor.Medium)
					{
						Damage(_DamageSeverityFactor.Medium);
					}
					break;
				}
			}
			else
			{
				DP = 0f;
				if (!ParentPlatform.IsWeapon)
				{
					ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a mount/weapon", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100682", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private void method_3(ref double double_0, Warhead.WarheadType warheadType_0)
	{
		switch (warheadType_0)
		{
		case Warhead.WarheadType.Cluster_AP:
			switch (ArmorRating)
			{
			case GlobalVariables.ArmorRating.Light:
				double_0 = 0.5 * double_0;
				break;
			default:
				double_0 = 0.0;
				break;
			case GlobalVariables.ArmorRating.None:
				break;
			}
			break;
		case Warhead.WarheadType.Cluster_AT:
		case Warhead.WarheadType.Cluster_SmartSubs:
			if (!IsFacilityAimpoint)
			{
				switch (ArmorRating)
				{
				default:
					double_0 = 0.0;
					break;
				case GlobalVariables.ArmorRating.Medium:
					double_0 = 0.5 * double_0;
					break;
				case GlobalVariables.ArmorRating.Light:
					double_0 = 0.7 * double_0;
					break;
				case GlobalVariables.ArmorRating.None:
					break;
				}
			}
			break;
		case Warhead.WarheadType.Cluster_Penetrator:
			if (!IsFacilityAimpoint)
			{
				switch (ArmorRating)
				{
				case GlobalVariables.ArmorRating.Light:
					double_0 = 0.9 * double_0;
					break;
				case GlobalVariables.ArmorRating.Medium:
					double_0 = 0.7 * double_0;
					break;
				case GlobalVariables.ArmorRating.Heavy:
					double_0 = 0.5 * double_0;
					break;
				case GlobalVariables.ArmorRating.Special:
					double_0 = 0.2 * double_0;
					break;
				}
			}
			break;
		case Warhead.WarheadType.SuperFrag:
		{
			GlobalVariables.ArmorRating armorRating = ArmorRating;
			if (armorRating != GlobalVariables.ArmorRating.None && armorRating != GlobalVariables.ArmorRating.Light)
			{
				double_0 = 0.0;
			}
			break;
		}
		}
	}

	public void ResolveDamageFromBlast(double BlastYield, Warhead.WarheadType theWarheadType)
	{
		try
		{
			int num = default(int);
			switch (ArmorRating)
			{
			case GlobalVariables.ArmorRating.Light:
				num = 10;
				break;
			case GlobalVariables.ArmorRating.Medium:
				num = 30;
				break;
			case GlobalVariables.ArmorRating.Heavy:
				num = 75;
				break;
			case GlobalVariables.ArmorRating.Special:
				num = 100;
				break;
			case GlobalVariables.ArmorRating.None:
				num = 1;
				break;
			}
			if (!ParentPlatform.IsWeapon)
			{
				ParentPlatform.AddMessage(Misc.RemoveHiddenString(Name) + " has suffered blast damage: " + Conversions.ToString(Math.Round(BlastYield, 1)) + " DPs", Misc.RemoveHiddenString(Name) + " damaged", LoggedMessage.MessageType.UnitDamage, 1, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
			}
			ResolveDamageForOnboardSensors(BlastYield);
			if (BlastYield > (double)num)
			{
				new WeaponImpact(ref ParentPlatform.ParentScen, ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
				if (!ParentPlatform.IsWeapon)
				{
					ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been destroyed!", ParentPlatform.Name + " lost a mount/weapon", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				Destroy(ParentPlatform.get_UnitSide(SetSideOnly: false), ScenEditAction: false, Module_ActiveUnit.IsAimpointFacility(ParentPlatform));
			}
			else if (BlastYield > (double)num / 2.0)
			{
				new WeaponImpact(ref ParentPlatform.ParentScen, ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null), WeaponImpact.ImpactType.Kinetic, 0);
				if (!ParentPlatform.IsWeapon)
				{
					ParentPlatform.ParentScen.AddMessage(Misc.RemoveHiddenString(ParentPlatform.Name) + " damage report: " + Misc.RemoveHiddenString(Name) + " has been damaged.", ParentPlatform.Name + " - damage to mount/weapon", LoggedMessage.MessageType.UnitDamage, 5, ParentPlatform.ObjectID, ParentPlatform.get_UnitSide(SetSideOnly: false), new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				}
				Damage(_DamageSeverityFactor.Medium);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100683", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void vmethod_0(float PulseStrengthRatio)
	{
		Sensor[] sensors_ReadOnly = Sensors_ReadOnly;
		checked
		{
			for (int i = 0; i < sensors_ReadOnly.Length; i++)
			{
				sensors_ReadOnly[i].vmethod_0(PulseStrengthRatio);
			}
			CommDevice[] commDevices = CommDevices;
			for (int j = 0; j < commDevices.Length; j++)
			{
				commDevices[j].vmethod_0(PulseStrengthRatio);
			}
		}
	}

	private void method_4(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			mountWeaponRecordAddedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
		}
	}

	private void method_5(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			if (item != null)
			{
				mountWeaponRecordRemovedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
			}
		}
	}

	public float[] ApplyCombatPower(float[] ArrayToApply, float[] WarheadMatrix_GC, float[] WarheadHighest_GC, Scenario ParentScen)
	{
		Array.Clear(WarheadHighest_GC, 0, WarheadHighest_GC.Length);
		Array.Clear(WarheadMatrix_GC, 0, WarheadMatrix_GC.Length);
		foreach (WeaponRec mountWeapon in MountWeapons)
		{
			Warhead[] warheads = mountWeapon.get_ReferenceWeapon(ParentScen).Warheads;
			for (int i = 0; i < warheads.Length; i = checked(i + 1))
			{
				warheads[i].GetCombatPower(WarheadMatrix_GC);
				int num = WarheadMatrix_GC.Length - 1;
				for (int j = 0; j <= num; j++)
				{
					if (WarheadMatrix_GC[j] > WarheadHighest_GC[j])
					{
						WarheadHighest_GC[j] = WarheadMatrix_GC[j];
					}
				}
			}
		}
		int num2 = WarheadHighest_GC.Length - 1;
		for (int k = 0; k <= num2; k++)
		{
			ArrayToApply[k] += WarheadHighest_GC[k];
		}
		return ArrayToApply;
	}

	public CargoType GetRequiredCargoType()
	{
		return Cargo_Type;
	}

	public float GetRequiredCrewSpace()
	{
		return Cargo_Crew;
	}

	public float GetRequiredArea()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Area == 0f)
		{
			Cargo_Area = (float)Math.Round((float)Cargo_Crew * PersonnelArea, 2);
		}
		return Cargo_Area;
	}

	public float GetRequiredAreaStacked(ICargoHost Host, int TotalQuantity)
	{
		return GetRequiredArea() * (float)TotalQuantity;
	}

	public float GetRequiredMass()
	{
		if (Cargo_Type == CargoType.Personnel && Cargo_Mass == 0f)
		{
			Cargo_Mass = (float)Math.Round((float)Cargo_Crew * PersonnelMass, 1);
		}
		return Cargo_Mass;
	}

	public bool GetParadropCapable()
	{
		return Cargo_ParadropCapable;
	}

	public string GetCargoName()
	{
		return Name;
	}

	public string GetCargoObjectID()
	{
		return ObjectID;
	}

	public int imethod_0()
	{
		return DBID;
	}

	public _ComponentStatus GetCargoObjectStatus()
	{
		return base.Status;
	}

	public _DamageSeverityFactor GetCargoObjectDamageSeverity()
	{
		return base.DamageSeverity;
	}

	public string GetCargoObjectReasonForInoperative()
	{
		return ReasonForInoperative.ResponseString;
	}

	public string GetCargoObjectLossString()
	{
		return "FacilityAimpointCargo_" + DBID;
	}

	public string CargoObjectToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		return ToXML(ref ObjectsAlreadySerialized, theScen);
	}

	public void imethod_1()
	{
		ResetIDs();
	}

	public void DestroyCargoObject(Side ComponentPlatformSide, bool ScenEditAction, bool IsFacilityAimpoint, bool DestroyUnitNow, string theReason, string WhatCausedIt = null, bool RegisterAsLosses = true)
	{
		Destroy(ComponentPlatformSide, ScenEditAction, IsFacilityAimpoint, RegisterAsLosses);
	}

	public bool WantsToUnload()
	{
		return false;
	}

	public bool IsTowable()
	{
		return false;
	}

	public bool IsStackable()
	{
		return false;
	}

	public float GetRequiredHeight()
	{
		return 0f;
	}

	public int GetCargoQuantity()
	{
		return 1;
	}

	public bool isMatch(Cargo c)
	{
		if (c != null && c.CurrentType == Cargo.CargoObjectType.Mount && c.CargoObjectDBID == DBID)
		{
			return true;
		}
		return false;
	}
}
