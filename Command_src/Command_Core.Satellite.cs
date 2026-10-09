using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class Satellite : Platform
{
	public enum _SatelliteCategory
	{
		None = 1001,
		GeoStationary = 2001,
		UnmannedTestVehicle = 2003
	}

	public enum _SatelliteType
	{
		None = 1001,
		IMGSAT = 2001,
		RORSAT = 2002,
		EORSAT = 2003,
		SIGINT = 2004,
		ELINT = 2005,
		NOSS = 2006,
		MASINT = 2007,
		ReuseTestVehicle = 2008,
		Communications = 2009
	}

	public class SatelliteOrbitAnchor
	{
		public double Longitude;

		public double Latitude;

		public float Altitude;

		static SatelliteOrbitAnchor()
		{
			Class72.smethod_20();
		}
	}

	public string SpacecraftID;

	public DateTime LaunchDate;

	public DateTime DeOrbitDate;

	public _SatelliteCategory Category;

	public _SatelliteType Type;

	public GlobalVariables.ArmorRating Armor;

	public double WeightEmpty;

	public double WeightMax;

	public double WeightPayload;

	public float Span;

	public float Height;

	public float DamagePoints;

	public SatelliteOrbitAnchor OrbitAnchor;

	private Satellite_Kinematics satellite_Kinematics_0;

	private Satellite_Damage satellite_Damage_0;

	private bool bool_3;

	private MathFunctions.Vector vector_0;

	private static DateTime dateTime_0;

	private static long long_0;

	public int SpaceCraftNumber
	{
		get
		{
			int result;
			if (!string.IsNullOrEmpty(SpacecraftID))
			{
				if (SpacecraftID.Contains("_"))
				{
					return Conversions.ToInteger(SpacecraftID.Split(Conversions.ToCharArrayRankOne("_"))[1]);
				}
				result = 1;
			}
			else
			{
				result = 1;
			}
			return result;
		}
	}

	public override bool RepresentsMobileGroundUnit => false;

	public MathFunctions.Vector PositionVector
	{
		get
		{
			if (!bool_3)
			{
				double r = 6371.0 + (double)((ActiveUnit)this).get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) / 1000.0;
				vector_0 = MathFunctions.Vector.FromSpherical(r, ((ActiveUnit)this).get_Longitude((GlobalVariables.BooleanObject)null) * 0.0174532925199433, ((ActiveUnit)this).get_Latitude((GlobalVariables.BooleanObject)null) * 0.0174532925199433);
				bool_3 = true;
			}
			return vector_0;
		}
	}

	public new Satellite_Kinematics Kinematics => satellite_Kinematics_0;

	public new Satellite_Damage Damage
	{
		get
		{
			if (satellite_Damage_0 == null)
			{
				ActiveUnit theUnit = this;
				satellite_Damage_0 = new Satellite_Damage(ref theUnit);
			}
			return satellite_Damage_0;
		}
	}

	public override float FlatSurfaceArea_m2 => Length * Span;

	public bool IsGEO
	{
		get
		{
			int result;
			if (Kinematics.Apogee >= 40000000L)
			{
				result = 0;
			}
			else
			{
				if (Kinematics.Perigee > 30000000L)
				{
					return true;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
	}

	public override string AnnexAndDBID => "Satellite_" + Conversions.ToString(DBID);

	public override bool IsPlatform => true;

	static Satellite()
	{
		Class72.smethod_20();
		dateTime_0 = new DateTime(1900, 1, 1);
		long_0 = dateTime_0.Ticks;
	}

	public void InvalidatePositionVector()
	{
		bool_3 = false;
	}

	public override void Teleport(ref Scenario theScen, double Destination_Lon, double Destination_Lat)
	{
		base.Teleport(ref theScen, Destination_Lon, Destination_Lat);
		Kinematics.ExportLocationEvent("Telport");
	}

	public Satellite(ref Scenario theScen, string theGUID = null)
		: base(ref theScen, theGUID)
	{
		ActiveUnit theUnit = this;
		satellite_Kinematics_0 = new Satellite_Kinematics(ref theUnit);
		bool_3 = false;
		IsSatellite = true;
		UnitType = GlobalVariables.ActiveUnitType.Satellite;
	}

	internal override void Reinitialize()
	{
		base.Reinitialize();
		OrbitAnchor = null;
		_ParentGroup = null;
	}

	public override void ToXML(ref XmlWriter theWriter, ref HashSet<string> ObjectsAlreadySerialized)
	{
		if (Information.IsNothing((object)((ActiveUnit)this).get_UnitSide(SetSideOnly: false)))
		{
			return;
		}
		try
		{
			theWriter.WriteStartElement("Satellite");
			theWriter.WriteElementString("ID", ObjectID);
			if (ObjectsAlreadySerialized.Contains(ObjectID))
			{
				theWriter.WriteEndElement();
				return;
			}
			ObjectsAlreadySerialized.Add(ObjectID);
			method_2(ref theWriter);
			theWriter.WriteElementString("Name", Name.Replace("\0", "").Replace("\u0010", ""));
			if (ChanceOfAppearance != 0)
			{
				theWriter.WriteElementString("COA", Conversions.ToString(ChanceOfAppearance));
			}
			theWriter.WriteElementString("SID", SpacecraftID);
			theWriter.WriteElementString("Side", ((ActiveUnit)this).get_UnitSide(SetSideOnly: false).Name);
			if (!string.IsNullOrEmpty(Message))
			{
				theWriter.WriteElementString("Message", Message);
			}
			if (Longitude__UnitEntersAreaCheck.HasValue)
			{
				theWriter.WriteElementString("Longitude_UnitEntersAreaCheck", XmlConvert.ToString(Longitude__UnitEntersAreaCheck.Value));
			}
			if (Latitude__UnitEntersAreaCheck.HasValue)
			{
				theWriter.WriteElementString("Latitude_UnitEntersAreaCheck", XmlConvert.ToString(Latitude__UnitEntersAreaCheck.Value));
			}
			if (ActiveEnterAreaTriggers.Count > 0)
			{
				theWriter.WriteStartElement("ActiveEnterAreaTriggers");
				foreach (string activeEnterAreaTrigger in ActiveEnterAreaTriggers)
				{
					theWriter.WriteElementString("ActiveEnterAreaTrigger", activeEnterAreaTrigger);
				}
				theWriter.WriteEndElement();
			}
			if (ActiveRemainAreaTriggers.Count > 0)
			{
				theWriter.WriteStartElement("ActiveRemainAreaTriggers");
				foreach (KeyValuePair<string, DateTime> activeRemainAreaTrigger in ActiveRemainAreaTriggers)
				{
					theWriter.WriteElementString("RemainAreaTrigger", activeRemainAreaTrigger.Key.ToString());
					theWriter.WriteElementString("RemainAreaStartTime", activeRemainAreaTrigger.Value.ToBinary().ToString());
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteElementString("DBID", DBID.ToString());
			if (!Information.IsNothing((object)OrbitAnchor))
			{
				theWriter.WriteStartElement("Anchor");
				theWriter.WriteElementString("Lon", XmlConvert.ToString(OrbitAnchor.Longitude));
				theWriter.WriteElementString("Lat", XmlConvert.ToString(OrbitAnchor.Latitude));
				theWriter.WriteElementString("Alt", XmlConvert.ToString(OrbitAnchor.Altitude));
				theWriter.WriteEndElement();
			}
			if (_Sensors.Count > 0)
			{
				theWriter.WriteStartElement("Sensors");
				foreach (Sensor sensor in _Sensors)
				{
					theWriter.WriteRaw(sensor.ToXML(ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (Comms_ReadOnly.Length > 0)
			{
				theWriter.WriteStartElement("Comms");
				CommDevice[] comms = _Comms;
				foreach (CommDevice commDevice in comms)
				{
					theWriter.WriteRaw(commDevice.ToXML(ref ObjectsAlreadySerialized));
				}
				theWriter.WriteEndElement();
			}
			if (Mounts.Count > 0)
			{
				theWriter.WriteStartElement("Mounts");
				foreach (Mount mount in Mounts)
				{
					theWriter.WriteRaw(mount.ToXML(ref ObjectsAlreadySerialized, ParentScen));
				}
				theWriter.WriteEndElement();
			}
			theWriter.WriteElementString("Status", ((byte)Status).ToString());
			if (ActiveMissionOrPackage() != null)
			{
				theWriter.WriteElementString("AssignedMission", _AssignedMissionOrPackage.ObjectID);
			}
			if (!Information.IsNothing((object)AssignedTaskPool))
			{
				theWriter.WriteElementString("AssignedTaskPool", _AssignedTaskPool.ObjectID);
			}
			if (PrivateSnapshotMission != null)
			{
				theWriter.WriteStartElement("PrivateSnapshotMission");
				PrivateSnapshotMission.ToXML(ref theWriter, ref ObjectsAlreadySerialized, ref ParentScen);
				theWriter.WriteEndElement();
			}
			if (!Information.IsNothing((object)((ActiveUnit)this).get_ParentGroup(UsingMissionPlanner: false)))
			{
				theWriter.WriteElementString("ParentGroup", _ParentGroup.ObjectID);
			}
			if (((ActiveUnit)this).get_IsAutoDetectable((Side)null))
			{
				theWriter.WriteElementString("IsAD", ((ActiveUnit)this).get_IsAutoDetectable((Side)null).ToString());
			}
			Doctrine.ToXML(ref theWriter, ref ParentScen);
			theWriter.WriteStartElement("ActiveUnit_AI");
			AI.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			Sensory.ToXML(ref theWriter);
			theWriter.WriteStartElement("ActiveUnit_CommStuff");
			CommStuff.ToXML(ref theWriter, ref ObjectsAlreadySerialized);
			theWriter.WriteEndElement();
			if (HasCustomOODA)
			{
				theWriter.WriteElementString("OODA_D", OODA_Detection.ToString());
				theWriter.WriteElementString("OODA_T", OODA_Targeting.ToString());
				theWriter.WriteElementString("OODA_E", OODA_Evasion.ToString());
			}
			theWriter.WriteEndElement();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100753", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public static Satellite FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen, Satellite existingObject = null)
	{
		Satellite satellite = default(Satellite);
		try
		{
			satellite = smethod_1(ref theNode, ref theDictionary, ref theScen, theScen.LoadStockUnits, existingObject);
		}
		catch (PlatformComponentNotFoundException projectError)
		{
			ProjectData.SetProjectError((Exception)projectError);
			string innerText = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			ConcurrentDictionary<string, ScenarioObject> obj = theDictionary;
			ScenarioObject value = satellite;
			obj.TryRemove(innerText, out value);
			satellite = smethod_1(ref theNode, ref theDictionary, ref theScen, bool_4: true, existingObject);
			string text = "";
			if (satellite.IsGroupMember())
			{
				text = "(member of group: [" + ((ActiveUnit)satellite).get_ParentGroup(UsingMissionPlanner: false).Name + "])";
			}
			theScen.LoadingNotices.Add("The following satellite:[" + satellite.Name + "]" + text + " failed to shallow-rebuild because of a component missing. The satellite was instead deep-rebuilt, and instantiated in its pristine DB-stock condition. All customizations present in the satellite's components (damaged components, weapon additions/removals etc. etc.) have been lost. Please re-apply any necessary customizations either manually or using an SBR script.");
			ProjectData.ClearProjectError();
		}
		return satellite;
	}

	private static Satellite smethod_1(ref XmlNode xmlNode_0, ref ConcurrentDictionary<string, ScenarioObject> concurrentDictionary_0, ref Scenario scenario_0, bool bool_4, Satellite satellite_0 = null)
	{
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0a5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a62: Expected O, but got Unknown
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		Satellite result = default(Satellite);
		try
		{
			bool flag;
			Satellite theSatellite;
			if (!(flag = satellite_0 != null))
			{
				theSatellite = new Satellite(ref scenario_0);
			}
			else
			{
				theSatellite = satellite_0;
				theSatellite.Reinitialize();
			}
			theSatellite.ParentScen = scenario_0;
			string text = Misc.GetNodeByName(xmlNode_0.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (!concurrentDictionary_0.ContainsKey(text))
			{
				theSatellite.ObjectID_Set(text);
				if (xmlNode_0.ChildNodes.Count == 1)
				{
					scenario_0.UnitsForLateInstantiation.Add(xmlNode_0);
					result = theSatellite;
				}
				else
				{
					concurrentDictionary_0.TryAdd(theSatellite.ObjectID, theSatellite);
					int num = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "DBID").InnerText);
					int spacecraftNumber = Conversions.ToInteger(Misc.GetNodeByName(xmlNode_0.ChildNodes, "SID").InnerText.Split(new char[1] { '_' })[1]);
					try
					{
						DBFunctions.GetSatellite(ref scenario_0, ref theSatellite, num, spacecraftNumber, bool_4);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ConcurrentDictionary<string, ScenarioObject> obj = concurrentDictionary_0;
						string objectID = theSatellite.ObjectID;
						ScenarioObject value = theSatellite;
						obj.TryRemove(objectID, out value);
						scenario_0.LoadingNotices.Add("Satellite with Database ID " + Conversions.ToString(num) + " is missing from the database and has not been loaded.");
						ProjectData.ClearProjectError();
						goto end_IL_0001;
					}
					if (bool_4)
					{
						theSatellite.method_3(ref xmlNode_0, ref concurrentDictionary_0, ref scenario_0);
					}
					if (!bool_4)
					{
						foreach (XmlNode childNode in xmlNode_0.ChildNodes)
						{
							XmlNode val = childNode;
							theSatellite.CommonFromXML(val);
							switch (val.Name)
							{
							case "Sensors":
								if (flag)
								{
									theSatellite._Sensors.Clear();
								}
								foreach (XmlNode childNode2 in val.ChildNodes)
								{
									Sensor sensor = Sensor.FromXML(childNode2, concurrentDictionary_0, theSatellite);
									if (theSatellite.Category == _SatelliteCategory.GeoStationary && sensor.Role == Sensor.Sensor_Role.Infrared_BMEWS)
									{
										sensor.maxRange = 30000f;
										sensor.float_2 = 2000f;
									}
									if (!sensor.IsMk1Eyeball)
									{
										theSatellite._Sensors.Add(sensor);
										sensor.ParentPlatform = theSatellite;
									}
								}
								break;
							case "Comms":
								if (flag)
								{
									ArrayExtensions.Clear(ref theSatellite._Comms);
								}
								foreach (XmlNode childNode3 in val.ChildNodes)
								{
									XmlNode theNode2 = childNode3;
									CommDevice commDevice = CommDevice.FromXML(ref theNode2, ref concurrentDictionary_0, theSatellite);
									theSatellite.AddCommDevice(commDevice);
									commDevice.ParentPlatform = theSatellite;
								}
								break;
							case "Mounts":
								if (flag)
								{
									theSatellite.Mounts.Clear();
								}
								foreach (XmlNode childNode4 in val.ChildNodes)
								{
									XmlNode theNode = childNode4;
									Mount mount = Mount.FromXML(ref theNode, ref concurrentDictionary_0, theSatellite);
									theSatellite.Mounts.Add(mount);
									mount.ParentPlatform = theSatellite;
								}
								break;
							}
						}
					}
					foreach (XmlNode childNode5 in xmlNode_0.ChildNodes)
					{
						XmlNode theNode3 = childNode5;
						switch (theNode3.Name)
						{
						case "ActiveEnterAreaTriggers":
							if (flag)
							{
								theSatellite.ActiveEnterAreaTriggers.Clear();
							}
							foreach (XmlNode childNode6 in theNode3.ChildNodes)
							{
								string innerText2 = childNode6.InnerText;
								theSatellite.ActiveEnterAreaTriggers.Add(innerText2);
							}
							break;
						case "PrivateSnapshotMission":
							theSatellite.PrivateSnapshotMission = Mission.FromXML(ref theNode3, ref concurrentDictionary_0, ref scenario_0);
							break;
						case "OODA_E":
							theSatellite.HasCustomOODA = true;
							theSatellite.OODA_Evasion = Conversions.ToShort(theNode3.InnerText);
							break;
						case "SID":
							theSatellite.SpacecraftID = theNode3.InnerText;
							break;
						case "Latitude_UnitEntersAreaCheck":
							theSatellite.Latitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode3.InnerText);
							break;
						case "OODA_D":
							theSatellite.HasCustomOODA = true;
							theSatellite.OODA_Detection = Conversions.ToShort(theNode3.InnerText);
							break;
						case "Name":
							theSatellite.Name = theNode3.InnerText;
							break;
						case "Status":
							if (Versioned.IsNumeric((object)theNode3.InnerText))
							{
								theSatellite.Status = (_ActiveUnitStatus)Conversions.ToByte(theNode3.InnerText);
							}
							else
							{
								theSatellite.Status = (_ActiveUnitStatus)Enum.Parse(typeof(_ActiveUnitStatus), theNode3.InnerText, ignoreCase: true);
							}
							if (theSatellite.Status == (_ActiveUnitStatus)9)
							{
								theSatellite.Status = _ActiveUnitStatus.RTB;
							}
							break;
						case "COA":
							theSatellite.ChanceOfAppearance = Conversions.ToInteger(theNode3.InnerText);
							break;
						case "ActiveUnit_CommStuff":
						{
							Satellite satellite2 = theSatellite;
							ActiveUnit theAU = theSatellite;
							satellite2._CommStuff = ActiveUnit_CommStuff.FromXML(ref theNode3, ref concurrentDictionary_0, ref theAU);
							break;
						}
						case "AL":
							theSatellite.AutonomyLevel = (DroneAutonomyLevel)Conversions.ToInteger(theNode3.InnerText);
							break;
						case "OODA_T":
							theSatellite.HasCustomOODA = true;
							theSatellite.OODA_Targeting = Conversions.ToShort(theNode3.InnerText);
							break;
						case "AssignedMission":
							if (theNode3.HasChildNodes)
							{
								XmlNode val5 = theNode3.ChildNodes[0];
								theSatellite._AssignedMissionOrPackage_ID = val5.InnerText;
							}
							break;
						case "ActiveUnit_AI":
							ActiveUnit_AI.FromXML(theNode3, concurrentDictionary_0, theSatellite);
							break;
						case "Side":
							theSatellite._SideName = theNode3.InnerText;
							break;
						case "ActiveRemainAreaTriggers":
						{
							string key = null;
							DateTime result2 = DateTime.MinValue;
							foreach (XmlNode childNode7 in theNode3.ChildNodes)
							{
								XmlNode val4 = childNode7;
								if (Operators.CompareString(val4.Name, "RemainAreaTrigger", false) == 0)
								{
									key = val4.InnerText;
									result2 = DateTime.MinValue;
									continue;
								}
								if (DateTime.TryParse(val4.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.None, out result2))
								{
									theSatellite.ActiveRemainAreaTriggers.Add(key, result2);
									continue;
								}
								string innerText = val4.InnerText;
								long result3 = default(long);
								if (long.TryParse(innerText, out result3))
								{
									result2 = DateTime.FromBinary(Conversions.ToLong(val4.InnerText));
									theSatellite.ActiveRemainAreaTriggers.Add(key, result2);
								}
							}
							break;
						}
						case "ActiveUnit_Sensory":
						case "Sensory":
						{
							Satellite satellite = theSatellite;
							ActiveUnit theAU = theSatellite;
							satellite._Sensory = ActiveUnit_Sensory.FromXML(ref theNode3, ref concurrentDictionary_0, ref theAU);
							break;
						}
						case "Message":
							theSatellite.Message = theNode3.InnerText;
							break;
						case "AssignedTaskPool":
							if (theNode3.HasChildNodes)
							{
								XmlNode val3 = theNode3.ChildNodes[0];
								theSatellite._AssignedTaskPool_ID = val3.InnerText;
							}
							break;
						case "CustomIcon":
							theSatellite.CustomIcon = theNode3.InnerText;
							break;
						case "ParentGroup":
							theSatellite._ParentGroup_ID = theNode3.InnerText;
							break;
						case "Anchor":
							theSatellite.OrbitAnchor = new SatelliteOrbitAnchor();
							foreach (XmlNode childNode8 in theNode3.ChildNodes)
							{
								XmlNode val2 = childNode8;
								switch (val2.Name)
								{
								case "Lon":
									theSatellite.OrbitAnchor.Longitude = XmlConvert.ToDouble(val2.InnerText);
									break;
								case "Alt":
									theSatellite.OrbitAnchor.Altitude = XmlConvert.ToSingle(val2.InnerText);
									break;
								case "Lat":
									theSatellite.OrbitAnchor.Latitude = XmlConvert.ToDouble(val2.InnerText);
									break;
								}
							}
							break;
						case "IsAD":
						case "IsAutoDetectable":
							((ActiveUnit)theSatellite).set_IsAutoDetectable((Side)null, Misc.ParseBool(theNode3.InnerText));
							break;
						case "Longitude_UnitEntersAreaCheck":
							theSatellite.Longitude__UnitEntersAreaCheck = XmlConvert.ToDouble(theNode3.InnerText);
							break;
						}
					}
					theSatellite.Kinematics.Move(1f, CheckForMinimumSafeHeight: false, SimplifiedCalcs_DLZ: false, scenario_0.Time);
					theSatellite.EvaluateIfDumb();
					result = theSatellite;
				}
			}
			else
			{
				result = (Satellite)concurrentDictionary_0[text];
			}
			end_IL_0001:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100754", "");
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

	public override bool IsOperating()
	{
		long ticks = ParentScen.Time.Ticks;
		long ticks2 = DeOrbitDate.Ticks;
		if (ticks >= LaunchDate.Ticks)
		{
			int result;
			if (ticks <= ticks2)
			{
				result = 1;
			}
			else
			{
				if (ticks2 > long_0)
				{
					return false;
				}
				result = 1;
			}
			return (byte)result != 0;
		}
		return false;
	}
}
