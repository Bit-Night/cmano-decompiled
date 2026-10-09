using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public class FlightPlanInfo
{
	public float FlightTime;

	public double ParentElapsedFlightTimeAtLaunch;

	public double FuelUsed;

	public bool InsufficientFuel;

	public bool Doglegged;

	private double double_0;

	public DateTime TOT;

	public List<KeyValuePair<Waypoint, double>> WpReachedPoint;

	public double TimeError
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public FlightPlanInfo()
	{
		WpReachedPoint = new List<KeyValuePair<Waypoint, double>>();
	}

	public FlightPlanInfo(float FlightTime, double ParentElapsedFlightTimeAtLaunch, double fuelUsed, bool insufficientFuel, bool doglegged, DateTime dateTime_0)
	{
		WpReachedPoint = new List<KeyValuePair<Waypoint, double>>();
		this.FlightTime = FlightTime;
		this.ParentElapsedFlightTimeAtLaunch = ParentElapsedFlightTimeAtLaunch;
		FuelUsed = fuelUsed;
		InsufficientFuel = insufficientFuel;
		Doglegged = doglegged;
		TOT = dateTime_0;
		TimeError = 0.0;
	}

	public string ToXML([Optional][DefaultParameterValue(null)] ref HashSet<string> ObjectsAlreadySerialized)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		string result;
		try
		{
			XmlWriterSettings val = new XmlWriterSettings
			{
				Indent = true,
				OmitXmlDeclaration = true
			};
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter val2 = XmlWriter.Create(stringBuilder, val);
			try
			{
				val2.WriteStartElement("FlightPlanInfo");
				val2.WriteElementString("FlightTime", XmlConvert.ToString(FlightTime));
				val2.WriteElementString("ParentElapsedFlightTimeAtLaunch", XmlConvert.ToString(ParentElapsedFlightTimeAtLaunch));
				val2.WriteElementString("FuelUsed", XmlConvert.ToString(FuelUsed));
				val2.WriteElementString("InsufficientFuel", InsufficientFuel.ToString());
				val2.WriteElementString("Doglegged", Doglegged.ToString());
				val2.WriteElementString("TimeError", XmlConvert.ToString(TimeError));
				val2.WriteElementString("TOT", XmlConvert.ToString(TOT));
				val2.WriteEndElement();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			result = stringBuilder.ToString();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at ToXML", "");
			result = string.Empty;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static FlightPlanInfo FromXML(ref XmlNode theNode)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		FlightPlanInfo result;
		try
		{
			FlightPlanInfo flightPlanInfo = new FlightPlanInfo();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Doglegged":
					flightPlanInfo.Doglegged = bool.Parse(val.InnerText);
					break;
				case "FuelUsed":
					flightPlanInfo.FuelUsed = XmlConvert.ToDouble(val.InnerText);
					break;
				case "TOT":
					flightPlanInfo.TOT = XmlConvert.ToDateTime(val.InnerText);
					break;
				case "ParentElapsedFlightTimeAtLaunch":
					flightPlanInfo.ParentElapsedFlightTimeAtLaunch = XmlConvert.ToDouble(val.InnerText);
					break;
				case "TimeError":
					flightPlanInfo.TimeError = XmlConvert.ToDouble(val.InnerText);
					break;
				case "InsufficientFuel":
					flightPlanInfo.InsufficientFuel = bool.Parse(val.InnerText);
					break;
				case "FlightTime":
					flightPlanInfo.FlightTime = XmlConvert.ToSingle(val.InnerText);
					break;
				}
			}
			result = flightPlanInfo;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			ex?.Data.Add("Error at FromXML", "");
			result = new FlightPlanInfo();
			ProjectData.ClearProjectError();
		}
		return result;
	}

	static FlightPlanInfo()
	{
		Class72.smethod_20();
	}
}
