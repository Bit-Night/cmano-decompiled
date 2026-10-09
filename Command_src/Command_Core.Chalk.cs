using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ServiceStack.Text;

namespace Command_Core;

public class Chalk
{
	private int int_0;

	public Dictionary<Cargo, int> Cargo;

	public List<string> _CargoIDs;

	public string _AssociatedMothershipID;

	public ActiveUnit AssociatedMothership;

	public int Priority;

	public Transport Preboat;

	public bool SelfTransport;

	public int ID
	{
		get
		{
			return int_0;
		}
		set
		{
			if (!Information.IsNothing((object)AssociatedMothership))
			{
				if (ValidateChalkID(value, AssociatedMothership.get_UnitSide(SetSideOnly: false)))
				{
					int_0 = value;
				}
			}
			else
			{
				int_0 = value;
			}
		}
	}

	public Chalk()
	{
		Cargo = new Dictionary<Cargo, int>();
		_CargoIDs = new List<string>();
		SelfTransport = false;
	}

	public Chalk(int _ID, ActiveUnit _AssociatedMothership)
	{
		Cargo = new Dictionary<Cargo, int>();
		_CargoIDs = new List<string>();
		SelfTransport = false;
		ID = _ID;
		AssociatedMothership = _AssociatedMothership;
	}

	public void AddCargo(Cargo CargoToAdd)
	{
		if (CargoToAdd != null && !Cargo.ContainsKey(CargoToAdd))
		{
			Cargo.Add(CargoToAdd, 0);
		}
	}

	public void RemoveCargo(Cargo CargoToRemove)
	{
		object obj = default(object);
		if (obj != null && Cargo.ContainsKey(CargoToRemove))
		{
			Cargo.Remove(CargoToRemove);
		}
	}

	internal string IsTransportEligible(ActiveUnit Transport, ref float RunRequired)
	{
		ICargoHost cargoHost = (ICargoHost)Transport;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			Cargo key = item.Key;
			if (key.RequiredMass <= cargoHost.GetCargo_Mass())
			{
				if (key.RequiredArea <= cargoHost.GetCargo_Area())
				{
					if (key.RequiredCrewSpace <= cargoHost.GetCargo_Crew())
					{
						if (key.RequiredCargoType > cargoHost.GetCargo_Type())
						{
							return "A single cargo exceeds max cargo type size";
						}
						continue;
					}
					return key.Name + " exceeds max PAX";
				}
				return key.Name + " exceeds max area";
			}
			return key.Name + " exceeds max mass";
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		num2 = ((GetMass() == 0f || cargoHost.GetCargo_Mass() == 0f) ? 0f : (GetMass() / cargoHost.GetCargo_Mass()));
		num3 = ((GetArea() == 0f || cargoHost.GetCargo_Area() == 0f) ? 0f : (GetArea() / cargoHost.GetCargo_Area()));
		num4 = ((GetCrew() == 0f || cargoHost.GetCargo_Crew() == 0f) ? 0f : (GetCrew() / cargoHost.GetCargo_Crew()));
		num = Math.Max(num2, num3);
		num = Math.Max(num, num4);
		RunRequired = num;
		return "OK";
	}

	internal CargoType GetLargestCargo()
	{
		CargoType cargoType = CargoType.NoCargo;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			if (item.Key.RequiredCargoType > cargoType)
			{
				cargoType = item.Key.RequiredCargoType;
			}
		}
		return cargoType;
	}

	internal float GetMass()
	{
		float num = 0f;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			num += item.Key.RequiredMass;
		}
		return num;
	}

	internal float GetArea()
	{
		float num = 0f;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			num += item.Key.RequiredArea;
		}
		return num;
	}

	internal float GetCrew()
	{
		float num = 0f;
		foreach (KeyValuePair<Cargo, int> item in Cargo)
		{
			num += item.Key.RequiredCrewSpace;
		}
		return num;
	}

	public static void AddNewChalk(Side TargetSide, ActiveUnit Mothership)
	{
		if (Mothership != null)
		{
			TargetSide.Chalks.Add(new Chalk(FetchHighestChalkSerial(TargetSide), Mothership));
		}
	}

	public static void RemoveChalk(Side TargetSide, Chalk ChalkToRemove)
	{
		TargetSide.Chalks.Contains(ChalkToRemove);
		TargetSide.Chalks.Remove(ChalkToRemove);
	}

	public static int FetchHighestChalkSerial(Side TargetSide)
	{
		int num = -5;
		foreach (Chalk chalk in TargetSide.Chalks)
		{
			if (chalk.ID > num)
			{
				num = chalk.ID;
			}
		}
		return num + 5;
	}

	public static bool ValidateChalkID(int TargetID, Side TargetSide)
	{
		if (TargetID < 0)
		{
			return false;
		}
		foreach (Chalk chalk in TargetSide.Chalks)
		{
			if (TargetID == chalk.ID)
			{
				return false;
			}
		}
		return true;
	}

	public string ToXML([Optional][DefaultParameterValue(null)] ref HashSet<string> ObjectsAlreadySerialized)
	{
		string result = default(string);
		try
		{
			StringBuilder stringBuilder = StringBuilderCache.Allocate();
			stringBuilder.Clear();
			stringBuilder.Append("<Chalk>");
			stringBuilder.Append("<ID>").Append(ID).Append("</ID>");
			if (Cargo.Count > 0)
			{
				foreach (KeyValuePair<Cargo, int> item in Cargo)
				{
					stringBuilder.Append("<Cargo>").Append(item.Key.ObjectID).Append("</Cargo>");
				}
			}
			stringBuilder.Append("<AssociatedMothership>").Append(AssociatedMothership.ObjectID).Append("</AssociatedMothership>");
			stringBuilder.Append("</Chalk>");
			string text = stringBuilder.ToString();
			StringBuilderCache.Free(stringBuilder);
			result = text;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1005845_b", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static Chalk FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		Chalk result;
		try
		{
			Chalk chalk = new Chalk();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "ID":
					chalk.ID = Conversions.ToInteger(val.InnerText);
					break;
				case "Cargo":
					chalk._CargoIDs.Add(val.InnerText);
					break;
				case "AssociatedMothership":
					chalk._AssociatedMothershipID = val.InnerText;
					break;
				}
			}
			result = chalk;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 1005855_b", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			result = new Chalk();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static Chalk()
	{
		Class72.smethod_20();
	}
}
