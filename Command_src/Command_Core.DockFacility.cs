using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using System.Xml;
using Command_Core.DAL;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class DockFacility : PlatformComponent
{
	public enum DockFacilityType : short
	{
		None = 1001,
		DockWell = 2001,
		Davit = 3001,
		BoatRampX = 3005,
		BoatRamp = 3500,
		DryDockShelter = 4001,
		ROV_UUV = 5001,
		Pier = 9001
	}

	public enum DockingPhysicalSize : short
	{
		None = 1001,
		const_1 = 2001,
		SmallPier = 2002,
		MediumPier = 2003,
		LargePier = 2004,
		const_5 = 2005,
		const_6 = 2006,
		VSmallDockDavit = 3001,
		SmallDockDavit = 3002,
		MediumDock = 3003,
		LargeDock = 3004,
		DryDockShelter = 4001,
		ROV_UUV = 5001
	}

	public DockingPhysicalSize Size;

	public DockFacilityType Type;

	public byte Capacity;

	public ConcurrentDictionary<string, ActiveUnit> HostedBoats;

	[ThreadStatic]
	private static StringBuilder stringBuilder_0;

	public bool IsOpenDockFacility
	{
		get
		{
			int result;
			switch (Type)
			{
			case DockFacilityType.DryDockShelter:
				result = 0;
				break;
			default:
				return true;
			case DockFacilityType.DockWell:
				result = 0;
				break;
			}
			return (byte)result != 0;
		}
	}

	public bool IsPier
	{
		get
		{
			DockingPhysicalSize size = Size;
			if ((uint)(size - 2001) <= 5u)
			{
				return true;
			}
			return false;
		}
	}

	public bool IsDock
	{
		get
		{
			int result;
			switch (Size)
			{
			case DockingPhysicalSize.VSmallDockDavit:
			case DockingPhysicalSize.SmallDockDavit:
			case DockingPhysicalSize.MediumDock:
			case DockingPhysicalSize.LargeDock:
				result = 1;
				break;
			case DockingPhysicalSize.ROV_UUV:
				result = 1;
				break;
			default:
				return false;
			case DockingPhysicalSize.DryDockShelter:
				result = 1;
				break;
			}
			return (byte)result != 0;
		}
	}

	public int MaximumSingleBoatLength
	{
		get
		{
			DockingPhysicalSize size = Size;
			int result;
			if (size > DockingPhysicalSize.const_6)
			{
				switch (size)
				{
				case DockingPhysicalSize.ROV_UUV:
					return 10;
				case DockingPhysicalSize.DryDockShelter:
					return 20;
				case DockingPhysicalSize.SmallDockDavit:
					return 17;
				case DockingPhysicalSize.VSmallDockDavit:
					goto IL_007c;
				case DockingPhysicalSize.MediumDock:
					goto IL_0085;
				case DockingPhysicalSize.LargeDock:
					goto IL_008a;
				}
				result = 0;
			}
			else
			{
				switch (size)
				{
				case DockingPhysicalSize.const_1:
					goto IL_007c;
				case DockingPhysicalSize.SmallPier:
					goto IL_0081;
				case DockingPhysicalSize.MediumPier:
					goto IL_0085;
				case DockingPhysicalSize.LargePier:
					goto IL_008a;
				case DockingPhysicalSize.const_5:
					return 200;
				case DockingPhysicalSize.const_6:
					return 500;
				case DockingPhysicalSize.None:
					return 0;
				}
				result = 0;
			}
			goto IL_0082;
			IL_008a:
			return 45;
			IL_0082:
			return result;
			IL_0081:
			result = 0;
			goto IL_0082;
			IL_0085:
			return 25;
			IL_007c:
			return 11;
		}
	}

	public int TotalCapacity_Free
	{
		get
		{
			int result;
			try
			{
				int num = MaximumSingleBoatLength * Capacity;
				int num2 = default(int);
				foreach (ActiveUnit value in HostedBoats.Values)
				{
					if (value.IsShip)
					{
						num2 = (int)Math.Round((float)num2 + ((Ship)value).Length);
						continue;
					}
					if (value.IsSubmarine)
					{
						num2 = (int)Math.Round((float)num2 + ((Submarine)value).Length);
						continue;
					}
					if (value.IsVehicle)
					{
						num2 = (int)Math.Round((float)num2 + ((Vehicle)value).Length);
						continue;
					}
					throw new NotImplementedException();
				}
				result = num - num2;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ex2?.Data.Add("Error at 100668", "");
				GameGeneral.WriteExceptionsToLog(ex2);
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
				result = num3;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	internal bool HasHostedBoats()
	{
		return HostedBoats.Count > 0;
	}

	internal ConcurrentDictionary<string, ActiveUnit> GetHostedBoats()
	{
		return HostedBoats;
	}

	public string ToXML(HashSet<string> ObjectsAlreadySerialized)
	{
		try
		{
			if (stringBuilder_0 == null)
			{
				stringBuilder_0 = new StringBuilder();
			}
			else
			{
				stringBuilder_0.Clear();
			}
			stringBuilder_0.Append("<DockFacility>");
			stringBuilder_0.Append("<ID>").Append(ObjectID).Append("</ID>");
			if (ObjectsAlreadySerialized != null)
			{
				if (ObjectsAlreadySerialized.Contains(ObjectID))
				{
					stringBuilder_0.Append("</DockFacility>");
					return stringBuilder_0.ToString();
				}
				ObjectsAlreadySerialized.Add(ObjectID);
			}
			stringBuilder_0.Append("<DBID>").Append(DBID.ToString()).Append("</DBID>");
			if (_Status != _ComponentStatus.Operational)
			{
				StringBuilder stringBuilder = stringBuilder_0.Append("<Status>");
				byte status = (byte)_Status;
				stringBuilder.Append(status.ToString()).Append("</Status>");
			}
			if (base.DamageSeverity != _DamageSeverityFactor.Light)
			{
				stringBuilder_0.Append("<DamageSeverity>").Append(((byte)base.DamageSeverity).ToString()).Append("</DamageSeverity>");
			}
			stringBuilder_0.Append("</DockFacility>");
			return stringBuilder_0.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100664", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static DockFacility FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary, ref Scenario theScen)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		DockFacility result;
		try
		{
			XmlNode nodeByName = Misc.GetNodeByName(theNode.ChildNodes, "DBID");
			string text = Misc.GetNodeByName(theNode.ChildNodes, "ID").InnerText;
			if (Misc.ContainsChar(text, ' '))
			{
				text = text.Replace(" ", "-");
			}
			if (theDictionary.ContainsKey(text))
			{
				result = (DockFacility)theDictionary[text];
			}
			else
			{
				int facilityDBID = Conversions.ToInteger(nodeByName.InnerText);
				SQLiteConnection sqliteConnection_ = theScen.DBConnection;
				DockFacility dockFacility = DBFunctions.GetDockFacility(facilityDBID, ref sqliteConnection_);
				if (!theDictionary.ContainsKey(text))
				{
					dockFacility.ObjectID_Set(text);
					theDictionary.TryAdd(dockFacility.ObjectID, dockFacility);
					foreach (XmlNode childNode in theNode.ChildNodes)
					{
						XmlNode val = childNode;
						string name = val.Name;
						if (Operators.CompareString(name, "Status", false) == 0)
						{
							switch (val.InnerText)
							{
							default:
								dockFacility._Status = (_ComponentStatus)Conversions.ToByte(val.InnerText);
								break;
							case "Destroyed":
								dockFacility._Status = _ComponentStatus.Destroyed;
								break;
							case "Damaged":
								dockFacility._Status = _ComponentStatus.Damaged;
								break;
							case "Operational":
								dockFacility._Status = _ComponentStatus.Operational;
								break;
							}
						}
						else if (Operators.CompareString(name, "DamageSeverity", false) == 0)
						{
							dockFacility.DamageSeverity = (_DamageSeverityFactor)Conversions.ToByte(val.InnerText);
						}
					}
					result = dockFacility;
				}
				else
				{
					result = (DockFacility)theDictionary[text];
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100665", "");
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

	public DockFacility(ActiveUnit theParent, string theName, DockFacilityType theType, DockingPhysicalSize theSize, byte theCapacity)
		: base(theParent)
	{
		HostedBoats = new ConcurrentDictionary<string, ActiveUnit>();
		Name = theName;
		Type = theType;
		Size = theSize;
		Capacity = theCapacity;
	}

	public DockingOpsAttemptResult CanHostThisBoat(short BoatLength, DockingPhysicalSize BoatSizeClass)
	{
		if (IsPier)
		{
			return method_1(BoatLength);
		}
		if (!ActiveUnit_DockingOps.CanParkOnDock(BoatSizeClass))
		{
			return DockingOpsAttemptResult.Cannot_park_on_dock;
		}
		return method_1(BoatLength);
	}

	public override void Destroy(Side ComponentPlatformSide, bool ScenEditAction, bool IsAimpointFacility, bool RegisterAsLosses = true)
	{
		try
		{
			if (HostedBoats.Count > 0)
			{
				foreach (ActiveUnit value in HostedBoats.Values)
				{
					value.ParentScen.DestroyThisUnit(value, "Dock was destroyed", "Host Destruction");
				}
			}
			base.Destroy(ComponentPlatformSide, ScenEditAction, IsAimpointFacility);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100666", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	public override void Damage(_DamageSeverityFactor DamageSeverity)
	{
		try
		{
			int num2;
			int num = default(int);
			if (HostedBoats.Count > 0)
			{
				switch (DamageSeverity)
				{
				default:
					num2 = 0;
					break;
				case _DamageSeverityFactor.Light:
					num = (int)Math.Round((double)HostedBoats.Count / 3.0);
					num2 = 0;
					break;
				case _DamageSeverityFactor.Medium:
					num = (int)Math.Round((double)HostedBoats.Count / 2.0);
					num2 = 0;
					break;
				case _DamageSeverityFactor.Heavy:
					num = (int)Math.Round((double)(2 * HostedBoats.Count) / 3.0);
					num2 = 0;
					break;
				}
			}
			else
			{
				num2 = 0;
			}
			int num3 = num2;
			foreach (ActiveUnit value in HostedBoats.Values)
			{
				string text = "";
				if (Operators.CompareString(value.Name, value.UnitClass, false) != 0)
				{
					text = " (" + value.UnitClass + ")";
				}
				ParentPlatform.AddMessage(value.Name + text + " was hosted in " + Name + " and has been destroyed by the damage!", value.Name + " destroyed!", LoggedMessage.MessageType.UnitLost, 2, new Geopoint_Struct(ParentPlatform.get_Longitude((GlobalVariables.BooleanObject)null), ParentPlatform.get_Latitude((GlobalVariables.BooleanObject)null)));
				value.ParentScen.DestroyThisUnit(value, value.Name + text + " was hosted in " + Name + " and has been destroyed by the damage!", "Host Destruction");
				num3++;
				if (num3 == num)
				{
					break;
				}
			}
			base.Damage(DamageSeverity);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 100667", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}

	private DockingOpsAttemptResult method_1(float float_0)
	{
		int maximumSingleBoatLength = MaximumSingleBoatLength;
		if (float_0 > (float)maximumSingleBoatLength)
		{
			return DockingOpsAttemptResult.Boat_too_long;
		}
		if ((float)TotalCapacity_Free >= float_0)
		{
			return DockingOpsAttemptResult.Success;
		}
		return DockingOpsAttemptResult.Not_enough_space;
	}

	static DockFacility()
	{
		Class72.smethod_20();
	}
}
