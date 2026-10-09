using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using Command_Core.DAL;
using Cysharp.Text;
using DarkUI.Collections;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Magazine : PlatformComponent
{
	public delegate void MagazineWeaponRecordAddedEventHandler(string MagazineObjectID, string WeaponRecObjectID);

	public delegate void MagazineWeaponRecordRemovedEventHandler(string MagazineObjectID, string WeaponRecObjectID);

	public GlobalVariables.ArmorRating Armor;

	public int ROF;

	public int Capacity;

	[CompilerGenerated]
	[AccessedThroughProperty("Weapons")]
	private ObservableList<WeaponRec> observableList_0;

	public bool IsAviationMag;

	private float float_0;

	public bool Hypothetical;

	[CompilerGenerated]
	private static MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler_0;

	[CompilerGenerated]
	private static MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler_0;

	public virtual ObservableList<WeaponRec> Weapons
	{
		[CompilerGenerated]
		get
		{
			return observableList_0;
		}
		[CompilerGenerated]
		set
		{
			EventHandler<ObservableListModified<WeaponRec>> value2 = method_1;
			EventHandler<ObservableListModified<WeaponRec>> value3 = method_2;
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

	public static event MagazineWeaponRecordAddedEventHandler MagazineWeaponRecordAdded
	{
		[CompilerGenerated]
		add
		{
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler = magazineWeaponRecordAddedEventHandler_0;
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler2;
			do
			{
				magazineWeaponRecordAddedEventHandler2 = magazineWeaponRecordAddedEventHandler;
				MagazineWeaponRecordAddedEventHandler value2 = (MagazineWeaponRecordAddedEventHandler)Delegate.Combine(magazineWeaponRecordAddedEventHandler2, value);
				magazineWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref magazineWeaponRecordAddedEventHandler_0, value2, magazineWeaponRecordAddedEventHandler2);
			}
			while ((object)magazineWeaponRecordAddedEventHandler != magazineWeaponRecordAddedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler = magazineWeaponRecordAddedEventHandler_0;
			MagazineWeaponRecordAddedEventHandler magazineWeaponRecordAddedEventHandler2;
			do
			{
				magazineWeaponRecordAddedEventHandler2 = magazineWeaponRecordAddedEventHandler;
				MagazineWeaponRecordAddedEventHandler value2 = (MagazineWeaponRecordAddedEventHandler)Delegate.Remove(magazineWeaponRecordAddedEventHandler2, value);
				magazineWeaponRecordAddedEventHandler = Interlocked.CompareExchange(ref magazineWeaponRecordAddedEventHandler_0, value2, magazineWeaponRecordAddedEventHandler2);
			}
			while ((object)magazineWeaponRecordAddedEventHandler != magazineWeaponRecordAddedEventHandler2);
		}
	}

	public static event MagazineWeaponRecordRemovedEventHandler MagazineWeaponRecordRemoved
	{
		[CompilerGenerated]
		add
		{
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler = magazineWeaponRecordRemovedEventHandler_0;
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler2;
			do
			{
				magazineWeaponRecordRemovedEventHandler2 = magazineWeaponRecordRemovedEventHandler;
				MagazineWeaponRecordRemovedEventHandler value2 = (MagazineWeaponRecordRemovedEventHandler)Delegate.Combine(magazineWeaponRecordRemovedEventHandler2, value);
				magazineWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref magazineWeaponRecordRemovedEventHandler_0, value2, magazineWeaponRecordRemovedEventHandler2);
			}
			while ((object)magazineWeaponRecordRemovedEventHandler != magazineWeaponRecordRemovedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler = magazineWeaponRecordRemovedEventHandler_0;
			MagazineWeaponRecordRemovedEventHandler magazineWeaponRecordRemovedEventHandler2;
			do
			{
				magazineWeaponRecordRemovedEventHandler2 = magazineWeaponRecordRemovedEventHandler;
				MagazineWeaponRecordRemovedEventHandler value2 = (MagazineWeaponRecordRemovedEventHandler)Delegate.Remove(magazineWeaponRecordRemovedEventHandler2, value);
				magazineWeaponRecordRemovedEventHandler = Interlocked.CompareExchange(ref magazineWeaponRecordRemovedEventHandler_0, value2, magazineWeaponRecordRemovedEventHandler2);
			}
			while ((object)magazineWeaponRecordRemovedEventHandler != magazineWeaponRecordRemovedEventHandler2);
		}
	}

	public override void ResetIDs()
	{
		base.ResetIDs();
		foreach (WeaponRec weapon in Weapons)
		{
			weapon.ResetIDs();
		}
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<Magazine>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					utf16ValueStringBuilder.Append("</Magazine>");
					return utf16ValueStringBuilder.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			utf16ValueStringBuilder.Append("<TTF>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(float_0));
			utf16ValueStringBuilder.Append("</TTF>");
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
			utf16ValueStringBuilder.Append("<DBID>");
			utf16ValueStringBuilder.Append(DBID.ToString());
			utf16ValueStringBuilder.Append("</DBID>");
			if (observableList_0.Count > 0)
			{
				utf16ValueStringBuilder.Append("<Weapons>");
				int num = observableList_0.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					utf16ValueStringBuilder.Append(observableList_0[i].ToXML(ObjectsAlreadySerialized, theScen));
				}
				utf16ValueStringBuilder.Append("</Weapons>");
			}
			utf16ValueStringBuilder.Append("</Magazine>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100671", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	private Magazine()
	{
		Weapons = new ObservableList<WeaponRec>();
	}

	public static Magazine FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		Magazine result = default(Magazine);
		try
		{
			Magazine magazine = new Magazine();
			XmlNode nodeByName = Misc.GetNodeByName(theNode.ChildNodes, "DBID");
			int magazineDBID = (Information.IsNothing((object)nodeByName) ? DBFunctions.smethod_5(Misc.GetNodeByName(theNode.ChildNodes, "Name").InnerText, theScen.DBConnection) : Conversions.ToInteger(nodeByName.InnerText));
			magazine = DBFunctions.GetMagazine(magazineDBID, ref theScen, LoadComponents: false);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (!theDictionary.ContainsKey(innerText))
			{
				magazine.ObjectID_Set(innerText);
				theDictionary.TryAdd(magazine.ObjectID, magazine);
				foreach (XmlNode childNode in theNode.ChildNodes)
				{
					XmlNode val = childNode;
					switch (val.Name)
					{
					case "DamageSeverity":
						magazine.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
						break;
					case "Weapons":
						foreach (XmlNode childNode2 in val.ChildNodes)
						{
							XmlNode theNode2 = childNode2;
							WeaponRec item = WeaponRec.FromXML(ref theNode2, ref theDictionary, ref theScen);
							magazine.Weapons.Add(item);
						}
						break;
					case "TimeToFire":
					case "TTF":
						magazine.float_0 = XmlConvert.ToSingle(val.InnerText);
						break;
					case "Status":
						switch (val.InnerText)
						{
						case "Damaged":
							magazine._Status = _ComponentStatus.Damaged;
							break;
						case "Destroyed":
							magazine._Status = _ComponentStatus.Destroyed;
							break;
						default:
							magazine._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
							break;
						case "Operational":
							magazine._Status = _ComponentStatus.Operational;
							break;
						}
						break;
					}
				}
				result = magazine;
				return result;
			}
			result = (Magazine)theDictionary[innerText];
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100672", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void ResetTimeToFire()
	{
		TimeToFire = ROF;
	}

	public Magazine(ActiveUnit theParent, int MagazineID, string theName, GlobalVariables.ArmorRating theArmor, int theROF, int theCapacity, bool IsAviation)
		: base(theParent)
	{
		Weapons = new ObservableList<WeaponRec>();
		DBID = MagazineID;
		Name = theName;
		Armor = theArmor;
		ROF = theROF;
		float_0 = ROF;
		Capacity = theCapacity;
		IsAviationMag = IsAviation;
	}

	public string WeaponSpaceinMagazine(int int_1)
	{
		string result = default(string);
		try
		{
			int theQty_FullyLoadedCells = 0;
			int theQty_PartiallyLoadedCells = 0;
			if (CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells) >= Capacity)
			{
				result = "Magazine full";
				return result;
			}
			foreach (WeaponRec weapon in Weapons)
			{
				if (weapon.get_ReferenceWeapon(ParentPlatform.ParentScen).DBID == int_1 && weapon.CurrentLoad < weapon.MaxLoad)
				{
					result = "OK";
					return result;
				}
			}
			result = "No suitable weapon record found";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100673", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string AddWeapon(int int_1, bool AllowOverfill = false)
	{
		string result = default(string);
		try
		{
			int theQty_FullyLoadedCells = 0;
			int theQty_PartiallyLoadedCells = 0;
			int num = CurrentCapacity(ref theQty_FullyLoadedCells, ref theQty_PartiallyLoadedCells);
			if (Capacity < 10000)
			{
				if (AllowOverfill)
				{
					if (num > Capacity)
					{
						result = "Magazine full";
						return result;
					}
				}
				else if (num >= Capacity)
				{
					result = "Magazine full";
					return result;
				}
			}
			foreach (WeaponRec weapon in Weapons)
			{
				if (weapon.get_ReferenceWeapon(ParentPlatform.ParentScen).DBID == int_1 && weapon.CurrentLoad < weapon.MaxLoad)
				{
					weapon.CurrentLoad++;
					RaiseEventStatusChanged();
					result = "OK";
					return result;
				}
			}
			result = "No suitable weapon record found";
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100673", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal int CurrentCapacity(ref int theQty_FullyLoadedCells, ref int theQty_PartiallyLoadedCells)
	{
		theQty_FullyLoadedCells = 0;
		theQty_PartiallyLoadedCells = 0;
		foreach (WeaponRec weapon in Weapons)
		{
			if (weapon.CurrentLoad == 0)
			{
				continue;
			}
			if (weapon.Multiple > 1)
			{
				float num = (float)weapon.CurrentLoad / (float)weapon.Multiple;
				if (num != (float)(int)Math.Round(num))
				{
					theQty_PartiallyLoadedCells++;
					theQty_FullyLoadedCells += (int)Math.Floor((double)weapon.CurrentLoad / (double)weapon.Multiple);
				}
				else
				{
					theQty_FullyLoadedCells += (int)Math.Round(num);
				}
			}
			else
			{
				theQty_FullyLoadedCells += weapon.CurrentLoad;
			}
		}
		return theQty_FullyLoadedCells + theQty_PartiallyLoadedCells;
	}

	public string RemoveWeapon(int int_1, bool LoadingAircraft, ref float MagazineReloadTime)
	{
		bool flag = false;
		bool flag2 = false;
		string result = default(string);
		try
		{
			int num = Weapons.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				WeaponRec weaponRec = Weapons[i];
				if (weaponRec.int_3 != int_1)
				{
					continue;
				}
				if (weaponRec.CurrentLoad > 0)
				{
					if (LoadingAircraft)
					{
						weaponRec.CurrentLoad--;
						weaponRec.ResetTimeToFire();
						RaiseEventStatusChanged();
						result = "OK";
						return result;
					}
					if (weaponRec.TimeToFire == 0f)
					{
						weaponRec.CurrentLoad--;
						MagazineReloadTime = weaponRec.ReloadTime;
						RaiseEventStatusChanged();
						result = "OK";
						return result;
					}
					flag = true;
				}
				else
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				result = "Suitable weapon record found but not ready";
				return result;
			}
			if (flag2)
			{
				result = "Suitable weapon record not found";
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100674", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void method_1(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			magazineWeaponRecordAddedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
		}
	}

	private void method_2(object object_0, ObservableListModified<WeaponRec> observableListModified_0)
	{
		foreach (WeaponRec item in observableListModified_0.Items)
		{
			if (!Information.IsNothing((object)item))
			{
				magazineWeaponRecordRemovedEventHandler_0?.Invoke(ObjectID, item.ObjectID);
			}
		}
	}

	static Magazine()
	{
		Class72.smethod_20();
	}
}
