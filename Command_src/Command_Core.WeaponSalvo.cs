using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class WeaponSalvo : ScenarioObject
{
	public sealed class Shooter
	{
		public string ShooterObjectID;

		public string PreferredMountObjectID;

		[CompilerGenerated]
		private int int_0;

		private int int_1;

		public bool WeaponIsReadyToFire;

		public int TimeToNextLaunch;

		public int Timeout;

		public int? BombStickTotalQty;

		public int BombStickImpactedQty;

		public float? BombStickDirection;

		public float? BombStickLength;

		public int? BombStickIndexOfCenterShot;

		public GeoPoint BombStickFirstWeaponDPI;

		public GeoPoint BombStickFirstWeaponActualPI;

		public string BombStickAimpointObjectID;

		public bool NeedsSensorTrack_AAWFireControlGrade;

		public int QuantityAssigned
		{
			get
			{
				return method_0();
			}
			set
			{
				method_1(value);
			}
		}

		public int QuantityFired
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

		[SpecialName]
		[CompilerGenerated]
		private int method_0()
		{
			return int_0;
		}

		[SpecialName]
		[CompilerGenerated]
		private void method_1(int int_2)
		{
			int_0 = int_2;
		}

		public Shooter(string theShooterObjectID)
		{
			method_1(0);
			NeedsSensorTrack_AAWFireControlGrade = false;
			ShooterObjectID = theShooterObjectID;
		}

		public Shooter(string theShooterObjectID, int theQuantityAssigned, int theQuantityFired)
		{
			method_1(0);
			NeedsSensorTrack_AAWFireControlGrade = false;
			ShooterObjectID = theShooterObjectID;
			QuantityAssigned = theQuantityAssigned;
			QuantityFired = theQuantityFired;
			WeaponIsReadyToFire = false;
		}

		public Shooter(string theShooterObjectID, string thePreferredMountObjectID, int theQuantityAssigned, int theQuantityFired, int theTimeToNextLaunch)
		{
			method_1(0);
			NeedsSensorTrack_AAWFireControlGrade = false;
			ShooterObjectID = theShooterObjectID;
			PreferredMountObjectID = thePreferredMountObjectID;
			QuantityAssigned = theQuantityAssigned;
			QuantityFired = theQuantityFired;
			TimeToNextLaunch = theTimeToNextLaunch;
		}

		static Shooter()
		{
			Class72.smethod_20();
		}
	}

	public int int_1;

	public Shooter[] ShootersList;

	public ConcurrentDictionary<string, byte> WeaponList;

	public int MaxNumberOfShooters;

	public int MaxNumberOfWeapons;

	public bool FireSimultaneouslyFromMultipleMounts;

	public Contact Target;

	public DateTime ScheduledFireTime;

	public Waypoint[] PlottedCourse;

	public bool ManualFire;

	private Weapon weapon_0;

	public Weapon.WeaponSpecialMode ActiveSpecialMode;

	public DateTime ETA;

	public string Tag;

	public static DateTime SCHEDULE_IMMEDIATELY;

	public static DateTime SCHEDULE_AS_PALLETIZED_WEAPON;

	public static DateTime SCHEDULE_AS_MANUAL;

	public int WpnQuantityAssigned
	{
		get
		{
			Shooter[] shootersList = ShootersList;
			int num = 0;
			Shooter shooter;
			int num2 = default(int);
			while (true)
			{
				if (num < shootersList.Length)
				{
					shooter = shootersList[num];
					if (shooter != null)
					{
						if (shooter.QuantityAssigned == int.MaxValue)
						{
							break;
						}
						num2 += shooter.QuantityAssigned;
					}
					num = checked(num + 1);
					continue;
				}
				return num2;
			}
			return shooter.QuantityAssigned;
		}
	}

	public int WpnQuantityFired
	{
		get
		{
			Shooter[] shootersList = ShootersList;
			int num = default(int);
			foreach (Shooter shooter in shootersList)
			{
				if (shooter != null)
				{
					num += shooter.QuantityFired;
				}
			}
			return num;
		}
	}

	public Weapon ReferenceWeapon
	{
		get
		{
			if (weapon_0 == null)
			{
				if (this.get_IsUnguidedWeapon(theScen))
				{
					weapon_0 = theScen.Cache_GetWeapon(int_1);
				}
				else
				{
					weapon_0 = Weapon.GetNewWeapon(ref theScen, int_1, bool_5: false);
				}
			}
			return weapon_0;
		}
	}

	public bool IsUnguidedWeapon
	{
		get
		{
			int num = int_1;
			SQLiteConnection sqliteConnection_ = theScen.DBConnection;
			Weapon._WeaponType weaponType = DBFunctions.GetWeaponType(num, ref sqliteConnection_);
			int result;
			int result2;
			if (weaponType > Weapon._WeaponType.DepthCharge)
			{
				if ((uint)(weaponType - 6001) <= 2u)
				{
					goto IL_0050;
				}
				if ((uint)(weaponType - 9002) > 1u)
				{
					result = 0;
					goto IL_004d;
				}
				result2 = 1;
			}
			else
			{
				if ((uint)(weaponType - 2002) > 2u)
				{
					if (weaponType != Weapon._WeaponType.DepthCharge)
					{
						result = 0;
						goto IL_004d;
					}
					goto IL_0050;
				}
				result2 = 1;
			}
			goto IL_0051;
			IL_004d:
			return (byte)result != 0;
			IL_0050:
			result2 = 1;
			goto IL_0051;
			IL_0051:
			return (byte)result2 != 0;
		}
	}

	static WeaponSalvo()
	{
		Class72.smethod_20();
		SCHEDULE_IMMEDIATELY = DateTime.MinValue;
		SCHEDULE_AS_PALLETIZED_WEAPON = DateTime.MaxValue;
		DateTime maxValue = DateTime.MaxValue;
		SCHEDULE_AS_MANUAL = new DateTime(maxValue.Ticks - 1L);
	}

	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("WeaponSalvo");
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				theWriter.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			theWriter.WriteStartElement("Weapons");
			foreach (string key in WeaponList.Keys)
			{
				theWriter.WriteElementString("Weapon_ObjectID", key);
			}
			theWriter.WriteEndElement();
			theWriter.WriteStartElement("Shooters");
			Shooter[] shootersList = ShootersList;
			foreach (Shooter shooter in shootersList)
			{
				theWriter.WriteStartElement("Shooter");
				theWriter.WriteElementString("ShooterObjectID", shooter.ShooterObjectID);
				theWriter.WriteElementString("PreferredMountObjectID", shooter.PreferredMountObjectID);
				if (shooter.QuantityAssigned > 0)
				{
					theWriter.WriteElementString("QuantityAssigned", shooter.QuantityAssigned.ToString());
				}
				if (shooter.QuantityFired > 0)
				{
					theWriter.WriteElementString("QuantityFired", shooter.QuantityFired.ToString());
				}
				theWriter.WriteElementString("TimeToNextLaunch", shooter.TimeToNextLaunch.ToString());
				theWriter.WriteElementString("Timeout", shooter.Timeout.ToString());
				if (!Information.IsNothing((object)shooter.BombStickFirstWeaponDPI))
				{
					theWriter.WriteStartElement("FirstWeaponDPI");
					theWriter.WriteRaw(shooter.BombStickFirstWeaponDPI.ToXML(ObjectsAlreadySerialized));
					theWriter.WriteEndElement();
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteEndElement();
			theWriter.WriteElementString("NumberOfShooters", MaxNumberOfShooters.ToString());
			theWriter.WriteElementString("WeaponDBID", int_1.ToString());
			theWriter.WriteElementString("Quantity_Total", MaxNumberOfWeapons.ToString());
			theWriter.WriteElementString("Target", Target.ObjectID);
			theWriter.WriteElementString("ScheduledFireTime", ScheduledFireTime.ToBinary().ToString());
			if (ActiveSpecialMode != Weapon.WeaponSpecialMode.None)
			{
				XmlWriter obj = theWriter;
				int activeSpecialMode = (int)ActiveSpecialMode;
				obj.WriteElementString("ASMode", activeSpecialMode.ToString());
			}
			theWriter.WriteStartElement("PlottedCourse");
			Waypoint[] plottedCourse = PlottedCourse;
			foreach (Waypoint waypoint in plottedCourse)
			{
				if (!Information.IsNothing((object)waypoint))
				{
					waypoint.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
				}
			}
			theWriter.WriteEndElement();
			theWriter.WriteElementString("ManualFire", ManualFire.ToString());
			theWriter.WriteElementString("FireSimultaneouslyFromMultipleMounts", FireSimultaneouslyFromMultipleMounts.ToString());
			if (!string.IsNullOrEmpty(Tag))
			{
				theWriter.WriteElementString("TAG", Tag);
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101206", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static WeaponSalvo FromXML(ref XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, WeaponSalvo existingObject = null)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected O, but got Unknown
		WeaponSalvo result;
		try
		{
			bool flag = false;
			WeaponSalvo weaponSalvo;
			if (existingObject == null)
			{
				weaponSalvo = new WeaponSalvo();
			}
			else
			{
				weaponSalvo = existingObject;
				flag = true;
			}
			int theTimeToNextLaunch = default(int);
			GeoPoint bombStickFirstWeaponDPI = default(GeoPoint);
			int theQuantityFired = default(int);
			int theQuantityAssigned = default(int);
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode theNode2 = childNode;
				switch (theNode2.Name)
				{
				case "ASMode":
					weaponSalvo.ActiveSpecialMode = (Weapon.WeaponSpecialMode)Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Quantity_Total":
					weaponSalvo.MaxNumberOfWeapons = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "Target":
					if (!theNode2.InnerText.StartsWith("Aimpoint_"))
					{
						if (!theNode2.InnerText.StartsWith("ActivationPoint_"))
						{
							weaponSalvo.Target = Contact.FromXML(theNode2.InnerText, ref theDictionary);
						}
						else
						{
							weaponSalvo.Target = ActivationPointContact.FromString(theNode2.InnerText);
						}
					}
					else
					{
						weaponSalvo.Target = AimpointContact.FromString(theNode2.InnerText);
					}
					break;
				case "PlottedCourse":
					if (flag)
					{
						ArrayExtensions.Clear(ref weaponSalvo.PlottedCourse);
					}
					foreach (XmlNode childNode2 in theNode2.ChildNodes)
					{
						XmlNode theNode3 = childNode2;
						Waypoint theAC = Waypoint.FromXML(ref theNode3, ref theDictionary, theScen);
						ArrayExtensions.Add(ref weaponSalvo.PlottedCourse, theAC);
					}
					break;
				case "WeaponDBID":
					weaponSalvo.int_1 = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "ScheduledFireTime":
					weaponSalvo.ScheduledFireTime = DateTime.FromBinary(Conversions.ToLong(theNode2.InnerText));
					break;
				case "Shooters":
					if (flag)
					{
						ArrayExtensions.Clear(ref weaponSalvo.ShootersList);
					}
					foreach (XmlNode childNode3 in theNode2.ChildNodes)
					{
						XmlNode val = childNode3;
						string theShooterObjectID = "";
						string thePreferredMountObjectID = "";
						foreach (XmlNode childNode4 in val.ChildNodes)
						{
							XmlNode val2 = childNode4;
							switch (val2.Name)
							{
							case "PreferredMountObjectID":
								thePreferredMountObjectID = val2.InnerText;
								break;
							case "TimeToNextLaunch":
								theTimeToNextLaunch = Conversions.ToInteger(val2.InnerText);
								break;
							case "FirstWeaponDPI":
								bombStickFirstWeaponDPI = GeoPoint.FromXML(ref theNode2, ref theDictionary);
								break;
							case "QuantityFired":
								theQuantityFired = Conversions.ToInteger(val2.InnerText);
								break;
							case "Timeout":
								Conversions.ToInteger(val2.InnerText);
								break;
							case "QuantityAssigned":
								theQuantityAssigned = Conversions.ToInteger(val2.InnerText);
								break;
							case "ShooterObjectID":
								theShooterObjectID = val2.InnerText;
								break;
							}
						}
						Shooter shooter = new Shooter(theShooterObjectID, thePreferredMountObjectID, theQuantityAssigned, theQuantityFired, theTimeToNextLaunch);
						shooter.BombStickFirstWeaponDPI = bombStickFirstWeaponDPI;
						ArrayExtensions.Add(ref weaponSalvo.ShootersList, shooter);
					}
					break;
				case "ManualFire":
					weaponSalvo.ManualFire = Misc.ParseBool(theNode2.InnerText);
					break;
				case "NumberOfShooters":
					weaponSalvo.MaxNumberOfShooters = Conversions.ToInteger(theNode2.InnerText);
					break;
				case "TAG":
					weaponSalvo.Tag = theNode2.InnerText;
					break;
				case "FireSimultaneouslyFromMultipleMounts":
					weaponSalvo.FireSimultaneouslyFromMultipleMounts = Misc.ParseBool(theNode2.InnerText);
					break;
				case "ID":
					weaponSalvo.ObjectID_Set(theNode2.InnerText);
					break;
				case "Weapons":
					if (flag)
					{
						weaponSalvo.WeaponList = new ConcurrentDictionary<string, byte>();
					}
					foreach (XmlNode childNode5 in theNode2.ChildNodes)
					{
						string innerText = childNode5.InnerText;
						weaponSalvo.WeaponList.TryAdd(innerText, 0);
					}
					break;
				}
			}
			result = weaponSalvo;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101205", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new WeaponSalvo();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private WeaponSalvo()
	{
		ShootersList = new Shooter[0];
		WeaponList = new ConcurrentDictionary<string, byte>();
		PlottedCourse = new Waypoint[0];
	}

	public WeaponSalvo(ref int theWeaponDBID, int theQuantity_ToFire, int theQuantity_Fired, int theQuantity_Assigned, ref Contact theTarget, ref bool theManualFire, string theShooterObjectID, int theNumberOfShooters, bool theFireSimultaneouslyFromMultipleMounts, [Optional][DateTimeConstant(0L)] DateTime theScheduledTime, List<Waypoint> thePlottedCourse = null)
	{
		ShootersList = new Shooter[0];
		WeaponList = new ConcurrentDictionary<string, byte>();
		PlottedCourse = new Waypoint[0];
		try
		{
			int_1 = theWeaponDBID;
			MaxNumberOfWeapons = theQuantity_ToFire;
			MaxNumberOfShooters = theNumberOfShooters;
			Target = theTarget;
			ManualFire = theManualFire;
			FireSimultaneouslyFromMultipleMounts = theFireSimultaneouslyFromMultipleMounts;
			Shooter theAC = new Shooter(theShooterObjectID, theQuantity_Assigned, theQuantity_Fired);
			ArrayExtensions.Add(ref ShootersList, theAC);
			if (!Information.IsNothing((object)theScheduledTime))
			{
				ScheduledFireTime = theScheduledTime;
			}
			if (!Information.IsNothing((object)thePlottedCourse))
			{
				PlottedCourse = thePlottedCourse.ToArray();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101207", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
