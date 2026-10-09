using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Rudder : PlatformComponent
{
	protected float _lastHeadingChangePerSecond;

	public float lastHeadingChangePerSecond => _lastHeadingChangePerSecond;

	public void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized, Scenario theScen)
	{
		try
		{
			theWriter.WriteStartElement("Rudder");
			theWriter.WriteElementString("ID", ObjectID);
			if (!ObjectsAlreadySerialized.Contains(ObjectID))
			{
				ObjectsAlreadySerialized.Add(ObjectID);
				XmlWriter obj = theWriter;
				byte status = (byte)_Status;
				obj.WriteElementString("Status", status.ToString());
				theWriter.WriteElementString("DamageSeverity", ((byte)base.DamageSeverity).ToString());
				theWriter.WriteElementString("Name", Name);
				if (_lastHeadingChangePerSecond != 0f)
				{
					theWriter.WriteElementString("LHCPS", XmlConvert.ToString(_lastHeadingChangePerSecond));
				}
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
			ex2?.Data.Add("Error at 100691", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Rudder FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		Rudder result;
		try
		{
			Rudder rudder = new Rudder();
			foreach (XmlNode childNode in theNode.ChildNodes[0].ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Name":
					rudder.Name = val.InnerText;
					break;
				case "LHCPS":
					rudder._lastHeadingChangePerSecond = XmlConvert.ToSingle(val.InnerText);
					break;
				case "DamageSeverity":
					rudder.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
					break;
				case "Status":
					switch (val.InnerText)
					{
					case "Operational":
						rudder._Status = _ComponentStatus.Operational;
						break;
					default:
						rudder._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
						break;
					case "Destroyed":
						rudder._Status = _ComponentStatus.Destroyed;
						break;
					case "Damaged":
						rudder._Status = _ComponentStatus.Damaged;
						break;
					}
					break;
				case "ID":
					rudder.ObjectID_Set(val.InnerText);
					break;
				}
			}
			result = rudder;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100692", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Rudder();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private Rudder()
	{
		_lastHeadingChangePerSecond = 0f;
		Name = "Rudder";
	}

	public Rudder(ActiveUnit theParent)
		: base(theParent)
	{
		_lastHeadingChangePerSecond = 0f;
		Name = "Rudder";
	}

	public float headingChangeAsFractionOfTurnrate()
	{
		float result = default(float);
		return result;
	}

	public float TurningSpeed()
	{
		if (ParentPlatform.IsShip)
		{
			return ((Ship)ParentPlatform).Kinematics.RudderTurningSpeed();
		}
		if (ParentPlatform.IsSubmarine)
		{
			return ((Submarine)ParentPlatform).Kinematics.RudderTurningSpeed();
		}
		if (Debugger.IsAttached)
		{
			Debugger.Break();
		}
		return 0f;
	}

	public float MaxDeflection()
	{
		if (!ParentPlatform.IsShip)
		{
			if (!ParentPlatform.IsSubmarine)
			{
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				return 0f;
			}
			return ((Submarine)ParentPlatform).Kinematics.TurnRate();
		}
		return ((Ship)ParentPlatform).Kinematics.TurnRate();
	}

	internal float adjustBoatHeadingChangeBasedOnRudderStatus(float targetDeflection, float maxRudderRotationSpeed, float maxRudderDeflection, float elapsedTime)
	{
		float num = maxRudderRotationSpeed * elapsedTime;
		float num2 = _lastHeadingChangePerSecond * elapsedTime;
		float val = targetDeflection;
		val = Math.Max(num2 - num, val);
		val = Math.Min(num2 + num, val);
		val = Math.Max((0f - maxRudderDeflection) * elapsedTime, val);
		val = Math.Min(maxRudderDeflection * elapsedTime, val);
		float num3 = 1f;
		if (base.Status == _ComponentStatus.Destroyed)
		{
			_lastHeadingChangePerSecond = 0f;
			return 0f;
		}
		if (base.Status == _ComponentStatus.Damaged)
		{
			switch (base.DamageSeverity)
			{
			case _DamageSeverityFactor.Light:
				num3 = 0.66f;
				break;
			case _DamageSeverityFactor.Medium:
				num3 = 0.33f;
				break;
			case _DamageSeverityFactor.Heavy:
				num3 = 0f;
				break;
			}
		}
		float num4 = num3;
		if (num4 == 0f)
		{
			val = num2;
		}
		else if (num4 != 1f)
		{
			val = val * num4 + num2 * (1f - num4);
		}
		_lastHeadingChangePerSecond = val / elapsedTime;
		return val;
	}

	static Rudder()
	{
		Class72.smethod_20();
	}
}
