using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class HGV : Weapon
{
	private HGV_AI hgv_AI_0;

	private HGV_Kinematics hgv_Kinematics_0;

	public override Weapon_AI AI => hgv_AI_0;

	public override Weapon_Kinematics Kinematics => hgv_Kinematics_0;

	public override bool SupportsAttitude_Pitch => true;

	public override float Attitude_Pitch
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

	public override float DesiredPitch
	{
		get
		{
			return _DesiredPitch;
		}
		set
		{
			_DesiredPitch = value;
		}
	}

	public override float CurrentAltitude
	{
		get
		{
			return base.get_CurrentAltitude(DoSanityCheck, GlobalVariables.ObjectTrue);
		}
		set
		{
			if (DoSanityCheck && IsGuidedWeapon() && value < 6.0959997f)
			{
				value = 6.0959997f;
			}
			this.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null);
			base.set_CurrentAltitude(DoSanityCheck, (GlobalVariables.BooleanObject)null, value);
		}
	}

	public HGV(ref Scenario theScen, string theGUID = null)
		: base(theScen, theGUID)
	{
		hgv_AI_0 = new HGV_AI(this);
		ActiveUnit theUnit = this;
		hgv_Kinematics_0 = new HGV_Kinematics(ref theUnit);
		IsWeapon = true;
		base.Type = _WeaponType.HGV;
		CruiseAltitude_ASL = 50000f;
		Attitude_Pitch = 0f;
		Attitude_Roll = 0f;
	}

	public new static HGV FromXML_Private(XmlNode theNode, ConcurrentDictionary<string, ScenarioObject> theDictionary, Scenario theScen, bool LoadStockComponents_Force)
	{
		HGV result;
		try
		{
			HGV hGV = new HGV(ref theScen);
			hGV.ParentScen = theScen;
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (theDictionary.ContainsKey(innerText))
			{
				result = (HGV)theDictionary[innerText];
			}
			else
			{
				hGV.ObjectID_Set(innerText);
				if (theNode.ChildNodes.Count == 1)
				{
					theScen.UnitsForLateInstantiation.Add(theNode);
					result = hGV;
				}
				else
				{
					theDictionary.TryAdd(hGV.ObjectID, hGV);
					int num = Conversions.ToInteger(Misc.GetNodeByName(theNode.ChildNodes, "DBID").InnerText);
					DBFunctions.GetWeapon(theScen.DBConnection, hGV, num, theScen, LoadStockComponents_Force);
					if (hGV.IsHGV)
					{
						hGV.CruiseAltitude_ASL = 100000f;
					}
					if (LoadStockComponents_Force)
					{
						hGV.method_3(ref theNode, ref theDictionary, ref theScen);
					}
					if (!LoadStockComponents_Force)
					{
						Weapon.LoadSavedComponents(hGV, theScen, theNode, theDictionary);
					}
					Weapon.LoadMutableProperties(hGV, theScen, theNode, theDictionary);
					float maximumAltitude = hGV.Kinematics.GetMaximumAltitude();
					float minimumAltitude = hGV.Kinematics.GetMinimumAltitude();
					if (hGV.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) > maximumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
					{
						hGV.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, maximumAltitude);
					}
					else if (hGV.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) < minimumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
					{
						hGV.set_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null, minimumAltitude);
					}
					if (hGV.DesiredAltitude > maximumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
					{
						hGV.DesiredAltitude = maximumAltitude;
					}
					else if (hGV.DesiredAltitude < minimumAltitude && (hGV.Type == _WeaponType.GuidedWeapon || hGV.Type == _WeaponType.Torpedo))
					{
						hGV.DesiredAltitude = minimumAltitude;
					}
					result = hGV;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100882", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new HGV(ref theScen);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public override void DoFuelConsumption(float elapsedTime)
	{
	}

	static HGV()
	{
		Class72.smethod_20();
	}
}
