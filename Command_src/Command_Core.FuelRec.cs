using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml;
using Cysharp.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Command_Core;

public sealed class FuelRec : ScenarioObject
{
	public enum _FuelType : short
	{
		NoFuel = 1001,
		AviationFuel = 2001,
		DieselFuel = 3001,
		OilFuel = 3002,
		GasFuel = 3003,
		Gasoline = 3006,
		Battery = 4001,
		AirIndepedent = 4002,
		const_8 = 4003,
		RocketFuel = 5001,
		TorpedoFuel = 5002,
		WeaponCoast = 5003
	}

	public int? DBID;

	public int MaxQuantity;

	public double _CurrentQuantity;

	public _FuelType FuelType;

	public float PercentFull => (float)(_CurrentQuantity / (double)MaxQuantity);

	public float CurrentQuantity
	{
		get
		{
			return (float)_CurrentQuantity;
		}
		set
		{
			_CurrentQuantity = value;
		}
	}

	public string ToXML()
	{
		Utf16ValueStringBuilder utf16ValueStringBuilder = ZString.CreateStringBuilder();
		try
		{
			utf16ValueStringBuilder.Append("<FuelRec>");
			utf16ValueStringBuilder.Append("<ID>");
			utf16ValueStringBuilder.Append(ObjectID);
			utf16ValueStringBuilder.Append("</ID>");
			if (DBID.HasValue)
			{
				utf16ValueStringBuilder.Append("<DBID>");
				utf16ValueStringBuilder.Append(DBID);
				utf16ValueStringBuilder.Append("</DBID>");
			}
			utf16ValueStringBuilder.Append("<MQ>");
			utf16ValueStringBuilder.Append(MaxQuantity.ToString());
			utf16ValueStringBuilder.Append("</MQ>");
			utf16ValueStringBuilder.Append("<CQ>");
			utf16ValueStringBuilder.Append(XmlConvert.ToString(CurrentQuantity));
			utf16ValueStringBuilder.Append("</CQ>");
			utf16ValueStringBuilder.Append("<FT>");
			utf16ValueStringBuilder.Append((int)FuelType);
			utf16ValueStringBuilder.Append("</FT>");
			utf16ValueStringBuilder.Append("</FuelRec>");
			string result = utf16ValueStringBuilder.ToString();
			utf16ValueStringBuilder.Dispose();
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101005", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static FuelRec FromXML(ref XmlNode theNode, ref ConcurrentDictionary<string, ScenarioObject> theDictionary)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		FuelRec result = default(FuelRec);
		try
		{
			FuelRec fuelRec = new FuelRec();
			foreach (XmlNode childNode in theNode.ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "CQ":
				case "CurrentQuantity":
					fuelRec.CurrentQuantity = XmlConvert.ToSingle(val.InnerText.Replace(",", "."));
					break;
				case "DBID":
					fuelRec.DBID = Conversions.ToInteger(val.InnerText);
					break;
				case "MQ":
				case "MaxQuantity":
					fuelRec.MaxQuantity = Conversions.ToInteger(val.InnerText);
					break;
				case "ID":
					fuelRec.ObjectID_Set(val.InnerText);
					break;
				case "FT":
				case "FuelType":
					if (Versioned.IsNumeric((object)val.InnerText))
					{
						fuelRec.FuelType = (_FuelType)Conversions.ToShort(val.InnerText);
					}
					else
					{
						fuelRec.FuelType = (_FuelType)Enum.Parse(typeof(_FuelType), val.InnerText, ignoreCase: true);
					}
					break;
				}
			}
			result = fuelRec;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ex2?.Data.Add("Error at 101006", "");
			GameGeneral.WriteExceptionsToLog(ex2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private FuelRec()
	{
	}

	public FuelRec(int theQuantity, short theType)
	{
		MaxQuantity = theQuantity;
		CurrentQuantity = theQuantity;
		FuelType = (_FuelType)theType;
	}

	public void SubtractFuel(float amount)
	{
		_CurrentQuantity -= amount;
		if (_CurrentQuantity < -3.4028234663852886E+38)
		{
			_CurrentQuantity = -3.4028234663852886E+38;
		}
	}

	public void AddFuel(float amount)
	{
		_CurrentQuantity += amount;
		if (_CurrentQuantity > 3.4028234663852886E+38)
		{
			_CurrentQuantity = 3.4028234663852886E+38;
		}
	}

	static FuelRec()
	{
		Class72.smethod_20();
	}
}
