using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FiringProposal : ScenarioObject
{
	[CompilerGenerated]
	internal sealed class _Closure$__11-0
	{
		public XmlNode $VB$Local_theChild;

		public _Closure$__11-0(_Closure$__11-0 arg0)
		{
			if (arg0 != null)
			{
				$VB$Local_theChild = arg0.$VB$Local_theChild;
			}
		}

		[SpecialName]
		internal bool _Lambda$__0(ActiveUnit theU)
		{
			return Operators.CompareString(theU.ObjectID, $VB$Local_theChild.InnerText, false) == 0;
		}

		static _Closure$__11-0()
		{
			Class72.smethod_20();
		}
	}

	public int int_1;

	public Contact Target;

	public DateTime ETA;

	public double Distance;

	public bool ManualFire;

	private Weapon weapon_0;

	public Module_Unit.Unit FiringUnit;

	public int? QuantityToFire;

	public int? QuantityAvailable;

	public int? ShooterQuantity;

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
				if ((uint)(weaponType - 6001) > 1u && (uint)(weaponType - 9002) > 1u)
				{
					result = 0;
					goto IL_004a;
				}
			}
			else
			{
				if ((uint)(weaponType - 2002) <= 2u)
				{
					result2 = 1;
					goto IL_004e;
				}
				if (weaponType != Weapon._WeaponType.DepthCharge)
				{
					result = 0;
					goto IL_004a;
				}
			}
			result2 = 1;
			goto IL_004e;
			IL_004e:
			return (byte)result2 != 0;
			IL_004a:
			return (byte)result != 0;
		}
	}

	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			theWriter.WriteStartElement("FiringProposal");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				theWriter.WriteElementString("WeaponDBID", int_1.ToString());
				theWriter.WriteElementString("QuantityToFire", QuantityToFire.ToString());
				theWriter.WriteElementString("QuantityAvailable", QuantityAvailable.ToString());
				theWriter.WriteElementString("Target", Target.ObjectID);
				theWriter.WriteElementString("ETA", ETA.ToBinary().ToString());
				theWriter.WriteElementString("Distance", Distance.ToString());
				theWriter.WriteElementString("ManualFire", ManualFire.ToString());
				theWriter.WriteElementString("FiringUnit", FiringUnit.ObjectID.ToString());
				theWriter.WriteElementString("ShooterQuantity", FiringUnit.ObjectID.ToString());
				theWriter.WriteEndElement();
			}
			else
			{
				theWriter.WriteEndElement();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 7345554", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static FiringProposal FromXML(ref XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		FiringProposal result;
		try
		{
			FiringProposal firingProposal = new FiringProposal();
			IEnumerator enumerator = theNode.ChildNodes.GetEnumerator();
			try
			{
				_Closure$__11-0 closure$__11- = default(_Closure$__11-0);
				while (enumerator.MoveNext())
				{
					closure$__11- = new _Closure$__11-0(closure$__11-);
					closure$__11-.$VB$Local_theChild = (XmlNode)enumerator.Current;
					switch (closure$__11-.$VB$Local_theChild.Name)
					{
					case "FiringUnit":
						theScen.GetCurrentSide().Units.Where(closure$__11-._Lambda$__0).FirstOrDefault();
						break;
					case "ETA":
						firingProposal.ETA = DateTime.FromBinary(Conversions.ToLong(closure$__11-.$VB$Local_theChild.InnerText));
						break;
					case "ShooterQuantity":
						firingProposal.ShooterQuantity = Conversions.ToInteger(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					case "ID":
						firingProposal.ObjectID_Set(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					case "ManualFire":
						firingProposal.ManualFire = Misc.ParseBool(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					case "Target":
						if (closure$__11-.$VB$Local_theChild.InnerText.StartsWith("Aimpoint_"))
						{
							firingProposal.Target = AimpointContact.FromString(closure$__11-.$VB$Local_theChild.InnerText);
						}
						else if (!closure$__11-.$VB$Local_theChild.InnerText.StartsWith("ActivationPoint_"))
						{
							firingProposal.Target = Contact.FromXML(closure$__11-.$VB$Local_theChild.InnerText, ref theDictionary);
						}
						else
						{
							firingProposal.Target = ActivationPointContact.FromString(closure$__11-.$VB$Local_theChild.InnerText);
						}
						break;
					case "QuantityAvailable":
						firingProposal.QuantityAvailable = Conversions.ToInteger(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					case "WeaponDBID":
						firingProposal.int_1 = Conversions.ToInteger(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					case "Distance":
						firingProposal.Distance = Conversions.ToInteger(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					case "QuantityToFire":
						firingProposal.QuantityToFire = Conversions.ToInteger(closure$__11-.$VB$Local_theChild.InnerText);
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			result = firingProposal;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 7345555", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new FiringProposal();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public FiringProposal()
	{
	}

	public FiringProposal(int TheWeaponDBID, Contact TheTarget, DateTime TheETA, double TheDistance, bool TheManualFire, Weapon The_ReferenceWeapon, Module_Unit.Unit TheFiringUnit)
	{
		int_1 = TheWeaponDBID;
		Target = TheTarget;
		ETA = TheETA;
		Distance = TheDistance;
		ManualFire = TheManualFire;
		weapon_0 = The_ReferenceWeapon;
		FiringUnit = TheFiringUnit;
	}

	static FiringProposal()
	{
		Class72.smethod_20();
	}
}
