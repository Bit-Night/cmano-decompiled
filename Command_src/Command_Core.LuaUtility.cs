using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Command_Core.Lua;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NLua;

namespace Command_Core;

[StandardModule]
public sealed class LuaUtility
{
	public enum DateFormat
	{
		DDMMYYYY,
		MMDDYYYY,
		YYYYMMDD,
		ISO
	}

	public static readonly Dictionary<string, LuaFunction> _cache;

	private static readonly string[] string_0;

	private static readonly string[] string_1;

	private static readonly string[] string_2;

	private static readonly string[] string_3;

	private static string[] string_4;

	private static string[] string_5;

	private static string[] string_6;

	private static readonly string[] string_7;

	private static bool bool_0;

	static LuaUtility()
	{
		Class72.smethod_20();
		_cache = new Dictionary<string, LuaFunction>();
		string_0 = new string[4] { "d/M/yyyy", "d-M-yyyy", "d.M.yyyy", "d:M:yyyy" };
		string_1 = new string[4] { "M/d/yyyy", "M-d-yyyy", "M.d.yyyy", "M:d:yyyy" };
		string_2 = new string[4] { "yyyy/M/d", "yyyy-M-d", "yyyy.M.d", "yyyy:M:d" };
		string_3 = new string[6] { "HH:mm:ss", "HH.mm.ss", "H:mm:ss", "H.mm.ss", "h:mm:ss tt", "h.mm.ss tt" };
		string_4 = new string[12]
		{
			"d/M/yyyy HH:mm:ss", "d-M-yyyy HH:mm:ss", "d.M.yyyy HH:mm:ss", "d/M/yyyy HH.mm.ss", "d-M-yyyy HH.mm.ss", "d.M.yyyy HH.mm.ss", "d/M/yyyy h:mm:ss tt", "d-M-yyyy h:mm:ss tt", "d.M.yyyy h:mm:ss tt", "d/M/yyyy h.mm.ss tt",
			"d-M-yyyy h.mm.ss tt", "d.M.yyyy h.mm.ss tt"
		};
		string_5 = new string[12]
		{
			"M/d/yyyy HH:mm:ss", "M-d-yyyy HH:mm:ss", "M.d.yyyy HH:mm:ss", "M/d/yyyy HH.mm.ss", "M-d-yyyy HH.mm.ss", "M.d.yyyy HH.mm.ss", "M/d/yyyy h:mm:ss tt", "M-d-yyyy h:mm:ss tt", "M.d.yyyy h:mm:ss tt", "M/d/yyyy h.mm.ss tt",
			"M-d-yyyy h.mm.ss tt", "M.d.yyyy h.mm.ss tt"
		};
		string_6 = new string[12]
		{
			"yyyy/M/d HH:mm:ss", "yyyy-M-d HH:mm:ss", "yyyy.M.d HH:mm:ss", "yyyy/M/d HH.mm.ss", "yyyy-M-d HH.mm.ss", "yyyy.M.d HH.mm.ss", "yyyy/M/d h:mm:ss tt", "yyyy-M-d h:mm:ss tt", "yyyy.M.d h:mm:ss tt", "yyyy/M/d h.mm.ss tt",
			"yyyy-M-d h.mm.ss tt", "yyyy.M.d h.mm.ss tt"
		};
		string_7 = new string[8] { "yyyyMMddHHmmss", "yyyyMMddHHmmssZ", "yyyyMMddTHH:mm:ssZ", "yyyyMMddTHH:mm:ss", "yyyyMMddTHHmmssZ", "yyyyMMddTHHmmss", "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm:ssZ" };
		bool_0 = true;
	}

	public static object[] DoString_Optimized(NLua.Lua lua, string chunk, string chunkName = "CachedChunk")
	{
		lock (_cache)
		{
			LuaFunction value = null;
			if (!_cache.TryGetValue(chunk, out value))
			{
				value = lua.LoadString(chunk, chunkName);
				_cache[chunk] = value;
			}
			return value.Call();
		}
	}

	public static List<object> ToArray(IDictionaryEnumerator iter)
	{
		List<(int, object)> list = new List<(int, object)>();
		while (iter.MoveNext())
		{
			int item = Conversions.ToInteger(iter.Key);
			list.Add((item, iter.Value));
		}
		return (from s in list
			orderby s.Item1
			select s.Item2).ToList();
	}

	public static Dictionary<string, object> ToDictUpper(IDictionaryEnumerator iter)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		while (iter.MoveNext())
		{
			string text = Conversions.ToString(iter.Key).ToUpperInvariant();
			if (Operators.CompareString(text, "LAT", false) == 0)
			{
				text = "LATITUDE";
			}
			if (Operators.CompareString(text, "LON", false) == 0)
			{
				text = "LONGITUDE";
			}
			if (Operators.CompareString(text, "LONG", false) == 0)
			{
				text = "LONGITUDE";
			}
			if (Operators.CompareString(text, "ALT", false) == 0)
			{
				text = "ALTITUDE";
			}
			if (Operators.CompareString(text, "OBJECTID", false) == 0)
			{
				text = "GUID";
			}
			dictionary[text] = RuntimeHelpers.GetObjectValue(iter.Value);
		}
		return dictionary;
	}

	public static Dictionary<string, object> ToDictLower(IDictionaryEnumerator iter)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		while (iter.MoveNext())
		{
			string key = Conversions.ToString(iter.Key).ToLower();
			dictionary[key] = RuntimeHelpers.GetObjectValue(iter.Value);
		}
		return dictionary;
	}

	public static void FromDict(Dictionary<string, object> dict, LuaTable table)
	{
		IDictionaryEnumerator dictionaryEnumerator = dict.GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			table[Conversions.ToString(dictionaryEnumerator.Key).ToLower()] = RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
		}
	}

	public static void FromList(IEnumerable<object> dict, LuaTable table)
	{
		IEnumerator enumerator = dict.GetEnumerator();
		while (enumerator.MoveNext())
		{
			table[table.Keys.Count + 1] = RuntimeHelpers.GetObjectValue(enumerator.Current);
		}
	}

	public static bool ParseUnitDict(ref Dictionary<string, object> dict)
	{
		IDictionaryEnumerator dictionaryEnumerator = new Dictionary<string, object>(dict).GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			string text = Conversions.ToString(dictionaryEnumerator.Key).ToUpperInvariant();
			RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
			if (Operators.CompareString(text, "UNIT", false) == 0)
			{
				text = "UNITNAME";
			}
			if (Operators.CompareString(text, "NAME", false) == 0)
			{
				text = "UNITNAME";
			}
			if (Operators.CompareString(text, "UNITNAMEORID", false) == 0)
			{
				text = "UNITNAME";
			}
			if (Operators.CompareString(text, "FROMUNIT", false) == 0)
			{
				text = "FROMUNITNAME";
			}
			if (Operators.CompareString(text, "FROMNAME", false) == 0)
			{
				text = "FROMUNITNAME";
			}
			if (Operators.CompareString(text, "FROMUNITNAMEORID", false) == 0)
			{
				text = "FROMUNITNAME";
			}
			if (Operators.CompareString(text, "TOUNIT", false) == 0)
			{
				text = "TOUNITNAME";
			}
			if (Operators.CompareString(text, "TONAME", false) == 0)
			{
				text = "TOUNITNAME";
			}
			if (Operators.CompareString(text, "TOUNITNAMEORID", false) == 0)
			{
				text = "TOUNITNAME";
			}
			dict[text] = RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
		}
		return true;
	}

	public static bool ParseSideDict(ref Dictionary<string, object> dict)
	{
		IDictionaryEnumerator dictionaryEnumerator = new Dictionary<string, object>(dict).GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			string text = Conversions.ToString(dictionaryEnumerator.Key).ToUpperInvariant();
			RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
			if (Operators.CompareString(text, "NAME", false) == 0)
			{
				text = "SIDE";
			}
			dict[text] = RuntimeHelpers.GetObjectValue(dictionaryEnumerator.Value);
		}
		return true;
	}

	public static string DecimalDegrees_To_DMS(double decimalDegrees)
	{
		double num = Math.Abs(decimalDegrees);
		double num2 = 60.0 * (num - Math.Floor(num));
		double a = 60.0 * (num2 - Math.Floor(num2));
		return $"{(int)Math.Round(num * (double)Math.Sign(decimalDegrees))}°{(int)Math.Round(num2)}'{(int)Math.Round(a)}\"";
	}

	public static double DMS_To_DecimalDegrees(double Deg, double Min, double Sec)
	{
		return Deg + Min / 60.0 + Sec / 3600.0;
	}

	public static long DateTimeToSeconds(string theDate)
	{
		long num = 10000000L;
		DateTime? dateTime = ParseDateTime_String(theDate, null);
		if (dateTime.HasValue)
		{
			return (long)Math.Round((double)dateTime.Value.Ticks / (double)num);
		}
		return 0L;
	}

	public static string SecondsToDateTime(long theSeconds, string theFormat = null)
	{
		DateTime dateTime = default(DateTime);
		return dateTime.AddSeconds(theSeconds).ToString(theFormat);
	}

	public static double ParseLatitudeString(string LatitudeString)
	{
		try
		{
			string text = LatitudeString.Substring(0, 1).ToUpperInvariant();
			if (Operators.CompareString(text, "S", false) == 0 || Operators.CompareString(text, "N", false) == 0)
			{
				LatitudeString = LatitudeString.Substring(1, LatitudeString.Length - 1);
			}
			LatitudeString = LatitudeString.Replace(",", ".");
			List<string> list = (from s in LatitudeString.Split(new char[1] { '.' })
				select s.Trim()).ToList();
			double num4;
			switch (list.Count)
			{
			default:
				throw new LuaError("Latitude '" + LatitudeString + "' is hard to understand (Too many numbers given). An example of a good latitude string is 'N 60.20.10'.");
			case 1:
				num4 = Conversions.ToInteger(LatitudeString);
				goto IL_0171;
			case 2:
				num4 = XmlConvert.ToDouble(LatitudeString);
				goto IL_0171;
			case 3:
				{
					double num = XmlConvert.ToDouble(list[0]);
					double num2 = XmlConvert.ToDouble(list[1]);
					double num3 = XmlConvert.ToDouble(list[2]);
					if (num < 0.0 || num2 < 0.0 || num3 < 0.0)
					{
						throw new LuaError("Latitude '" + LatitudeString + "' is hard to understand (negative numbers!). An example of a good latitude string is 'N 60.20.10'.");
					}
					if (!(num2 >= 60.0 || num3 >= 60.0))
					{
						num4 = DMS_To_DecimalDegrees(num, num2, num3);
						goto IL_0171;
					}
					throw new LuaError("Latitude '" + LatitudeString + "' is hard to understand (Minutes or Seconds greater or equal to 60).  An example of a good latitude string is 'N 60.20.10'.");
				}
				IL_0171:
				if (Operators.CompareString(text, "S", false) == 0)
				{
					num4 = 0.0 - num4;
				}
				return num4;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("Latitude '" + LatitudeString + "' is hard to understand. An example of a good latitude string is 'N 60.20.10'.");
		}
	}

	public static double ParseLongitudeString(string LongitudeString)
	{
		try
		{
			string text = LongitudeString.Substring(0, 1).ToUpperInvariant();
			if (Operators.CompareString(text, "E", false) == 0 || Operators.CompareString(text, "W", false) == 0)
			{
				LongitudeString = LongitudeString.Substring(1, LongitudeString.Length - 1);
			}
			LongitudeString = LongitudeString.Replace(",", ".");
			List<string> list = (from s in LongitudeString.Split(new char[1] { '.' })
				select s.Trim()).ToList();
			double num4;
			switch (list.Count)
			{
			default:
				throw new LuaError("Longitude '" + LongitudeString + "' is hard to understand (Too many numbers given). An example of a good longitude string is 'E 60.20.10'.");
			case 1:
				num4 = Conversions.ToInteger(LongitudeString);
				goto IL_0176;
			case 2:
				num4 = XmlConvert.ToDouble(LongitudeString);
				goto IL_0176;
			case 3:
				{
					double num = XmlConvert.ToDouble(list[0]);
					double num2 = XmlConvert.ToDouble(list[1]);
					double num3 = XmlConvert.ToDouble(list[2]);
					if (num < 0.0 || num2 < 0.0 || num3 < 0.0)
					{
						throw new LuaError("Longitude '" + LongitudeString + "' is hard to understand (negative numbers!). An example of a good longitude string is 'E 60.20.10'.");
					}
					if (!(num2 >= 60.0 || num3 >= 60.0))
					{
						num4 = DMS_To_DecimalDegrees(num, num2, num3);
						goto IL_0176;
					}
					throw new LuaError("Longitude '" + LongitudeString + "' is hard to understand (Minutes or Seconds greater or equal to 60). An example of a good longitude string is 'E 60.20.10'.");
				}
				IL_0176:
				if (Operators.CompareString(text, "W", false) == 0)
				{
					num4 = 0.0 - num4;
				}
				return num4;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw new LuaError("Longitude '" + LongitudeString + "' is hard to understand. An example of a good longitude string is 'E 60.20.10'.");
		}
	}

	public static bool? ParseBoolean(object value)
	{
		bool? result;
		if (value == null)
		{
			result = null;
		}
		else
		{
			try
			{
				if (!(value is string))
				{
					if (value is int)
					{
						return Conversions.ToInteger(value) != 0;
					}
					if (!(value is bool))
					{
						if (value is double)
						{
							return Conversions.ToDouble(value) != 0.0;
						}
						if (value is long)
						{
							return (ulong)Conversions.ToLong(value) > 0uL;
						}
						throw new LuaError("Lua can't understand '" + value.ToString() + "' as a true/false value. Please use 1 or 0.");
					}
					return (bool?)value;
				}
				if (Operators.CompareString(Conversions.ToString(value).ToLower(), "inherit", false) != 0)
				{
					return bool.Parse(Conversions.ToString(value).ToLower().Replace("yes", "true")
						.Replace("no", "false")
						.Replace("true", "true")
						.Replace("false", "false"));
				}
				result = null;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Lua can't understand '" + value.ToString() + "' as a true/false value. Please use 1 or 0.");
			}
		}
		return result;
	}

	public static double? QueryLatitude(Dictionary<string, object> dict)
	{
		object obj = null;
		if (dict.ContainsKey("LATITUDE"))
		{
			obj = RuntimeHelpers.GetObjectValue(dict["LATITUDE"]);
		}
		return QueryLatitudeObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static double? QueryLatitudeObject(object LatitudeObject)
	{
		double? result;
		if (LatitudeObject == null)
		{
			result = null;
		}
		else
		{
			double value = default(double);
			if (!(LatitudeObject is string))
			{
				if (LatitudeObject is double)
				{
					value = Conversions.ToDouble(LatitudeObject);
				}
				else if (LatitudeObject is int)
				{
					value = Conversions.ToDouble(LatitudeObject);
				}
				else if (LatitudeObject is long)
				{
					value = Conversions.ToDouble(LatitudeObject);
				}
			}
			else
			{
				value = ParseLatitudeString(Conversions.ToString(LatitudeObject));
			}
			result = value;
		}
		return result;
	}

	public static double? QueryLongitude(Dictionary<string, object> dict)
	{
		object obj = null;
		if (dict.ContainsKey("LONGITUDE"))
		{
			obj = RuntimeHelpers.GetObjectValue(dict["LONGITUDE"]);
		}
		return QueryLongitudeObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static double? QueryLongitudeObject(object LongitudeObject)
	{
		double? result;
		if (LongitudeObject == null)
		{
			result = null;
		}
		else
		{
			double value = default(double);
			if (LongitudeObject is string)
			{
				value = ParseLongitudeString(Conversions.ToString(LongitudeObject));
			}
			else if (LongitudeObject is double)
			{
				value = Conversions.ToDouble(LongitudeObject);
			}
			else if (!(LongitudeObject is int))
			{
				if (LongitudeObject is long)
				{
					value = Conversions.ToDouble(LongitudeObject);
				}
			}
			else
			{
				value = Conversions.ToDouble(LongitudeObject);
			}
			result = value;
		}
		return result;
	}

	public static Side QuerySideObject(object SideObject, Scenario ScenarioContext)
	{
		try
		{
			if (ScenarioContext.Sides_ReadOnly.Length == 0)
			{
				return null;
			}
			if (!(SideObject is string))
			{
				return null;
			}
			string text = Conversions.ToString(SideObject);
			if (Operators.CompareString(text.ToUpperInvariant(), "PlayerSide".ToUpperInvariant(), false) == 0)
			{
				return ScenarioContext.GetCurrentSide();
			}
			Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
			int num = 0;
			Side side;
			while (true)
			{
				if (num < sides_ReadOnly.Length)
				{
					side = sides_ReadOnly[num];
					if (string.Equals(side.Name, text, StringComparison.OrdinalIgnoreCase) || string.Equals(side.ObjectID, text, StringComparison.OrdinalIgnoreCase))
					{
						break;
					}
					num = checked(num + 1);
					continue;
				}
				return null;
			}
			return side;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Side QuerySide(Dictionary<string, object> dict, Scenario ScenarioContext)
	{
		try
		{
			if (dict.ContainsKey("SIDE"))
			{
				return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["SIDE"]), ScenarioContext);
			}
			if (!dict.ContainsKey("SIDENAME"))
			{
				throw new LuaError("Missing 'Side' please choose one of PlayerSide, " + string.Join(", ", ScenarioContext.Sides_ReadOnly.Select([SpecialName] (Side s) => s.Name)));
			}
			return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["SIDENAME"]), ScenarioContext);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			throw;
		}
	}

	public static Side QuerySensorSide(Dictionary<string, object> dict, Scenario ScenarioContext)
	{
		if (!dict.ContainsKey("SENSORSIDE"))
		{
			if (dict.ContainsKey("SENSORSIDENAME"))
			{
				return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["SENSORSIDENAME"]), ScenarioContext);
			}
			throw new LuaError("Missing 'SensorSide' please choose one of PlayerSide, " + string.Join(", ", ScenarioContext.Sides_ReadOnly.Select([SpecialName] (Side s) => s.Name)));
		}
		return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["SENSORSIDE"]), ScenarioContext);
	}

	public static Side QueryTargetSide(Dictionary<string, object> dict, Scenario ScenarioContext)
	{
		if (dict.ContainsKey("TARGESIDE"))
		{
			return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["TARGESIDE"]), ScenarioContext);
		}
		if (dict.ContainsKey("TARGESIDENAME"))
		{
			return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["TARGESIDENAME"]), ScenarioContext);
		}
		if (!dict.ContainsKey("TARGETSIDENAME"))
		{
			if (dict.ContainsKey("TARGETSIDE"))
			{
				return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["TARGETSIDE"]), ScenarioContext);
			}
			throw new LuaError("Missing 'TargetSide' please choose one of PlayerSide, " + string.Join(", ", ScenarioContext.Sides_ReadOnly.Select([SpecialName] (Side s) => s.Name)));
		}
		return QuerySideObject(RuntimeHelpers.GetObjectValue(dict["TARGETSIDENAME"]), ScenarioContext);
	}

	public static Side QuerySideOrFail(Dictionary<string, object> dict, Scenario ScenarioContext)
	{
		return QuerySide(dict, ScenarioContext) ?? throw new LuaError("Side '" + Conversions.ToString(dict["SIDE"]) + "' doesn't exist please choose one of PlayerSide, " + string.Join(", ", ScenarioContext.Sides_ReadOnly.Select([SpecialName] (Side s) => s.Name)));
	}

	public static ActiveUnit_AI.AircraftAltitudePreset? QueryAltitudePresetObject(object AltitudeObject)
	{
		ActiveUnit_AI.AircraftAltitudePreset? result;
		if (!(AltitudeObject is string))
		{
			result = null;
		}
		else
		{
			string text = Conversions.ToString(AltitudeObject).ToUpperInvariant();
			text.Replace("-", "");
			ActiveUnit_AI.AircraftAltitudePreset result2 = ActiveUnit_AI.AircraftAltitudePreset.None;
			int num;
			int num2;
			int num3;
			switch (text)
			{
			case "LOW1000":
				num = 2;
				goto IL_00d9;
			case "LOW":
				num = 2;
				goto IL_00d9;
			case "MED12000":
				num2 = 4;
				goto IL_023f;
			case "LOW2000":
				result2 = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
				goto IL_02a3;
			case "HIGH":
				num3 = 6;
				goto IL_01bf;
			case "HIGH36000":
				num3 = 6;
				goto IL_01bf;
			case "MAXALTITUDE":
			case "MAXALT":
			case "MAX":
				result2 = ActiveUnit_AI.AircraftAltitudePreset.MaxAltitude;
				goto IL_02a3;
			case "MEDIUM":
			case "MEDIUM12000":
			case "MED":
				num2 = 4;
				goto IL_023f;
			case "MIN":
			case "MINALTITUDE":
			case "MINALT":
				result2 = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
				goto IL_02a3;
			default:
				if (!Enum.TryParse<ActiveUnit_AI.AircraftAltitudePreset>(text, ignoreCase: true, out result2) || !Enum.IsDefined(typeof(ActiveUnit_AI.AircraftAltitudePreset), result2))
				{
					result = null;
					break;
				}
				goto IL_02a3;
			case "HIGH25000":
				{
					result2 = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					goto IL_02a3;
				}
				IL_02a3:
				result = result2;
				break;
				IL_00d9:
				result2 = (ActiveUnit_AI.AircraftAltitudePreset)num;
				goto IL_02a3;
				IL_01bf:
				result2 = (ActiveUnit_AI.AircraftAltitudePreset)num3;
				goto IL_02a3;
				IL_023f:
				result2 = (ActiveUnit_AI.AircraftAltitudePreset)num2;
				goto IL_02a3;
			}
		}
		return result;
	}

	public static float? QueryAltitudeObject(object AltitudeObject, [Optional][DefaultParameterValue(null)] ref ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset)
	{
		string text;
		ActiveUnit_AI.AircraftAltitudePreset aircraftAltitudePreset;
		float? result2;
		float value = default(float);
		if (!(AltitudeObject is string))
		{
			if (!(AltitudeObject is double))
			{
				if (!(AltitudeObject is float))
				{
					if (!(AltitudeObject is int))
					{
						if (AltitudeObject is long)
						{
							value = Conversions.ToSingle(AltitudeObject);
						}
					}
					else
					{
						value = Conversions.ToSingle(AltitudeObject);
					}
				}
				else
				{
					value = Conversions.ToSingle(AltitudeObject);
				}
			}
			else
			{
				value = Conversions.ToSingle(AltitudeObject);
			}
		}
		else
		{
			text = Conversions.ToString(AltitudeObject).ToUpperInvariant();
			text.Replace("-", "");
			if (!float.TryParse(text, out var _))
			{
				aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.None;
				int num2;
				int num3;
				int num;
				switch (text)
				{
				case "MAX":
					num2 = 7;
					goto IL_02af;
				case "HIGH36000":
					num3 = 6;
					goto IL_01de;
				case "HIGH25000":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_5;
					goto IL_031f;
				case "HIGH":
					num3 = 6;
					goto IL_01de;
				case "MIN":
				case "MINALTITUDE":
				case "MINALT":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.MinAltitude;
					goto IL_031f;
				case "MAXALT":
					num2 = 7;
					goto IL_02af;
				case "LOW2000":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.Low2000;
					goto IL_031f;
				case "LOW1000":
					num = 2;
					goto IL_02c2;
				case "MED":
				case "MEDIUM12000":
				case "MED12000":
					aircraftAltitudePreset = ActiveUnit_AI.AircraftAltitudePreset.const_4;
					goto IL_031f;
				case "MAXALTITUDE":
					num2 = 7;
					goto IL_02af;
				case "LOW":
					num = 2;
					goto IL_02c2;
				default:
					{
						if (text.Contains("FT"))
						{
							break;
						}
						if (text.Contains("M"))
						{
							goto IL_02e3;
						}
						goto IL_031f;
					}
					IL_031f:
					if (AltitudePreset.HasValue)
					{
						goto IL_0327;
					}
					goto IL_0341;
					IL_02c2:
					aircraftAltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)num;
					goto IL_031f;
					IL_01de:
					aircraftAltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)num3;
					goto IL_031f;
					IL_02af:
					aircraftAltitudePreset = (ActiveUnit_AI.AircraftAltitudePreset)num2;
					goto IL_031f;
				}
				value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
				result2 = value;
				goto IL_0412;
			}
			value = (text.Contains("FT") ? (float.Parse(text.Replace("FT", "").Replace("M", "").Trim()) * 0.3048f) : float.Parse(text.Replace("FT", "").Replace("M", "").Trim()));
		}
		goto IL_040a;
		IL_0341:
		value = ActiveUnit_AI.ConvertAltitudePresetToValue(aircraftAltitudePreset);
		goto IL_040a;
		IL_02e3:
		value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
		result2 = value;
		goto IL_0412;
		IL_040a:
		result2 = value;
		goto IL_0412;
		IL_0412:
		return result2;
		IL_0327:
		AltitudePreset = aircraftAltitudePreset;
		result2 = null;
		goto IL_0412;
	}

	public static float? QueryAltitude(Dictionary<string, object> dict)
	{
		object obj = null;
		if (!dict.ContainsKey("ALTITUDE"))
		{
			if (dict.ContainsKey("ALT"))
			{
				obj = RuntimeHelpers.GetObjectValue(dict["ALT"]);
			}
		}
		else
		{
			obj = RuntimeHelpers.GetObjectValue(dict["ALTITUDE"]);
		}
		if (obj != null)
		{
			object? objectValue = RuntimeHelpers.GetObjectValue(obj);
			ActiveUnit_AI.AircraftAltitudePreset? AltitudePreset = null;
			return QueryAltitudeObject(objectValue, ref AltitudePreset);
		}
		return null;
	}

	public static ActiveUnit_AI.SubmarineDepthPreset? QueryDepthPresetObject(object AltitudeObject)
	{
		ActiveUnit_AI.SubmarineDepthPreset? result;
		if (!(AltitudeObject is string))
		{
			result = null;
		}
		else
		{
			string text = Conversions.ToString(AltitudeObject).ToUpperInvariant();
			text.Replace("-", "");
			ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
			int num2;
			int num3;
			int num;
			switch (text)
			{
			case "OVER":
				num2 = 3;
				goto IL_0141;
			case "MAX":
				num3 = 5;
				goto IL_0102;
			case "PERISCOPE":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
				goto IL_0173;
			case "SURFACE":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
				goto IL_0173;
			case "MAXDEPTH":
				num3 = 5;
				goto IL_0102;
			case "UNDER":
				num = 4;
				goto IL_0171;
			case "OVERLAYER":
				num2 = 3;
				goto IL_0141;
			case "SHALLOW":
				submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
				goto IL_0173;
			default:
				result = null;
				break;
			case "UNDERLAYER":
				{
					num = 4;
					goto IL_0171;
				}
				IL_0171:
				submarineDepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)num;
				goto IL_0173;
				IL_0102:
				submarineDepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)num3;
				goto IL_0173;
				IL_0141:
				submarineDepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)num2;
				goto IL_0173;
				IL_0173:
				result = submarineDepthPreset;
				break;
			}
		}
		return result;
	}

	public static float? QueryDepthObject(object AltitudeObject)
	{
		float value = 0f;
		string text;
		float? result2;
		if (!(AltitudeObject is string))
		{
			if (AltitudeObject is double)
			{
				value = Math.Abs(Conversions.ToSingle(AltitudeObject)) * -1f;
			}
			else if (!(AltitudeObject is float))
			{
				if (AltitudeObject is int)
				{
					value = Math.Abs(Conversions.ToSingle(AltitudeObject)) * -1f;
				}
				else if (AltitudeObject is long)
				{
					value = Math.Abs(Conversions.ToSingle(AltitudeObject)) * -1f;
				}
			}
			else
			{
				value = Math.Abs(Conversions.ToSingle(AltitudeObject)) * -1f;
			}
		}
		else
		{
			text = Conversions.ToString(AltitudeObject).ToUpperInvariant();
			text.Replace("-", "");
			if (!float.TryParse(text, out var _))
			{
				ActiveUnit_AI.SubmarineDepthPreset submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.None;
				int num;
				switch (text)
				{
				case "PERISCOPE":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Periscope;
					goto IL_02bb;
				case "SURFACE":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Surface;
					goto IL_02bb;
				case "MAX":
					num = 5;
					goto IL_0194;
				case "MAXDEPTH":
					num = 5;
					goto IL_0194;
				case "OVER":
				case "OVERLAYER":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.OverLayer;
					goto IL_02bb;
				case "SHALLOW":
					submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.Shallow;
					goto IL_02bb;
				default:
					if (text.Contains("FT"))
					{
						break;
					}
					if (text.Contains("M"))
					{
						goto IL_0271;
					}
					goto IL_02bb;
				case "UNDER":
				case "UNDERLAYER":
					{
						submarineDepthPreset = ActiveUnit_AI.SubmarineDepthPreset.UnderLayer;
						goto IL_02bb;
					}
					IL_02bb:
					value = (int)submarineDepthPreset;
					goto IL_0337;
					IL_0194:
					submarineDepthPreset = (ActiveUnit_AI.SubmarineDepthPreset)num;
					goto IL_02bb;
				}
				value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture) * 0.3048f;
				result2 = Math.Abs(value) * -1f;
				goto IL_033f;
			}
			value = (text.Contains("FT") ? (float.Parse(text.Replace("FT", "").Replace("M", "").Trim()) * 0.3048f) : float.Parse(text.Replace("FT", "").Replace("M", "").Trim()));
			value = Math.Abs(value) * -1f;
		}
		goto IL_0337;
		IL_0271:
		value = float.Parse(text.Replace("FT", "").Replace("M", "").Trim(), CultureInfo.InvariantCulture);
		result2 = Math.Abs(value) * -1f;
		goto IL_033f;
		IL_0337:
		result2 = value;
		goto IL_033f;
		IL_033f:
		return result2;
	}

	public static float? QueryDepth(Dictionary<string, object> dict)
	{
		object obj = null;
		if (dict.ContainsKey("DEPTH"))
		{
			obj = RuntimeHelpers.GetObjectValue(dict["DEPTH"]);
		}
		if (obj == null)
		{
			return null;
		}
		return QueryDepthObject(RuntimeHelpers.GetObjectValue(obj));
	}

	public static ActiveUnit.Throttle? QueryThrottle(Dictionary<string, object> dict)
	{
		string text = null;
		if (dict.ContainsKey("THROTTLE"))
		{
			text = Conversions.ToString(dict["THROTTLE"]);
			return QueryThrottleObject(text);
		}
		return null;
	}

	public static ActiveUnit.Throttle? QueryThrottleObject(string ThrottleString)
	{
		ActiveUnit.Throttle throttle = ActiveUnit.Throttle.FullStop;
		int num;
		int num2;
		int num4;
		int num3;
		int num5;
		switch (ThrottleString.ToLower())
		{
		case "1":
			num = 1;
			goto IL_022a;
		case "military":
			num2 = 3;
			goto IL_0217;
		case "3":
			num2 = 3;
			goto IL_0217;
		case "2":
			num4 = 2;
			goto IL_01de;
		case "4":
		case "flank":
			num3 = 4;
			goto IL_01f1;
		case "0":
		case "hover":
		case "fullstop":
			num5 = 0;
			goto IL_019b;
		case "stop":
			num5 = 0;
			goto IL_019b;
		case "loiter":
			num = 1;
			goto IL_022a;
		case "cruise":
			num4 = 2;
			goto IL_01de;
		case "afterburner":
			num3 = 4;
			goto IL_01f1;
		case "full":
			num2 = 3;
			goto IL_0217;
		case "creep":
			num = 1;
			goto IL_022a;
		default:
			{
				throw new LuaError("Invalid throttle " + ThrottleString);
			}
			IL_019b:
			throttle = (ActiveUnit.Throttle)num5;
			break;
			IL_01f1:
			throttle = (ActiveUnit.Throttle)num3;
			break;
			IL_01de:
			throttle = (ActiveUnit.Throttle)num4;
			break;
			IL_0217:
			throttle = (ActiveUnit.Throttle)num2;
			break;
			IL_022a:
			throttle = (ActiveUnit.Throttle)num;
			break;
		}
		return throttle;
	}

	public static Group QueryGroupObject(object GroupSearchObject, Side SideContext, Scenario ScenarioContext)
	{
		if (GroupSearchObject is string)
		{
			string text = Conversions.ToString(GroupSearchObject);
			if (ScenarioContext.ActiveUnits.ContainsKey(text))
			{
				ActiveUnit activeUnit = ScenarioContext.ActiveUnits[text];
				if (activeUnit is Group)
				{
					return (Group)activeUnit;
				}
				throw new LuaError("Unable to understand '" + GroupSearchObject.ToString() + "' as a group. This is the guid for '" + activeUnit.Name + "' which isn't a Group.");
			}
			return (Group)SideContext.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => s.IsGroup && string.Equals(s.Name, text, StringComparison.OrdinalIgnoreCase));
		}
		throw new LuaError("Unable to understand '" + GroupSearchObject.ToString() + "' as a group.");
	}

	public static Group QueryGroup(Dictionary<string, object> dict, Side SideContext, Scenario ScenarioContext)
	{
		object obj = null;
		if (dict.ContainsKey("GROUP"))
		{
			obj = RuntimeHelpers.GetObjectValue(dict["GROUP"]);
		}
		if (obj == null)
		{
			return null;
		}
		return QueryGroupObject(RuntimeHelpers.GetObjectValue(obj), SideContext, ScenarioContext);
	}

	public static string QueryUnit(Dictionary<string, object> dict, Scenario ScenarioContext)
	{
		ActiveUnit activeUnit = null;
		Side side = null;
		ParseUnitDict(ref dict);
		string result;
		if (dict.ContainsKey("GUID"))
		{
			string text;
			try
			{
				text = Conversions.ToString(dict["GUID"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Guid must be a string");
			}
			try
			{
				activeUnit = ScenarioContext.ActiveUnits[text];
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				result = "Can't find guid " + text;
				ProjectData.ClearProjectError();
				goto IL_021a;
			}
			if (activeUnit == null)
			{
				dict.Remove("GUID");
			}
		}
		else if (dict.ContainsKey("UNITNAME"))
		{
			string text2;
			try
			{
				text2 = Conversions.ToString(dict["UNITNAME"]);
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				throw new LuaError("Name must be a string");
			}
			if (dict.ContainsKey("SIDE"))
			{
				string text3;
				try
				{
					text3 = Conversions.ToString(dict["SIDE"]);
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					throw new LuaError("Side must be a string");
				}
				try
				{
					side = QuerySide(dict, ScenarioContext);
				}
				catch (Exception projectError5)
				{
					ProjectData.SetProjectError(projectError5);
					result = "Can't find Side '" + text3 + "'";
					ProjectData.ClearProjectError();
					goto IL_021a;
				}
				try
				{
					activeUnit = side.Units.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception projectError6)
				{
					ProjectData.SetProjectError(projectError6);
					result = "Can't find Unit '" + text2 + "' on Side '" + text3 + "'";
					ProjectData.ClearProjectError();
					goto IL_021a;
				}
				dict["GUID"] = activeUnit.ObjectID;
			}
			else
			{
				try
				{
					activeUnit = ScenarioContext.ActiveUnits_List.First([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text2, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, text2, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception projectError7)
				{
					ProjectData.SetProjectError(projectError7);
					result = "Can't find Unit '" + text2 + "'";
					ProjectData.ClearProjectError();
					goto IL_021a;
				}
				dict["GUID"] = activeUnit.ObjectID;
				dict["SIDE"] = activeUnit.get_UnitSide(SetSideOnly: false).Name;
			}
		}
		result = "";
		goto IL_021a;
		IL_021a:
		return result;
	}

	public static bool QueryBaseUnit(Dictionary<string, object> dict, Scenario ScenarioContext)
	{
		ActiveUnit value = null;
		Side side = null;
		int num;
		bool result;
		if (!dict.ContainsKey("BASE"))
		{
			num = 1;
		}
		else
		{
			side = QuerySideOrFail(dict, ScenarioContext);
			string text = "";
			try
			{
				text = Conversions.ToString(dict["BASE"]);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw new LuaError("Base must be a string");
			}
			ScenarioContext.ActiveUnits.TryGetValue(text, out value);
			if (side != null && value != null && !string.Equals(value.get_UnitSide(SetSideOnly: false).ObjectID, side.ObjectID, StringComparison.OrdinalIgnoreCase))
			{
				value = null;
			}
			if (value == null)
			{
				try
				{
					value = ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, text, StringComparison.OrdinalIgnoreCase));
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					result = false;
					ProjectData.ClearProjectError();
					goto IL_00f5;
				}
			}
			if (value == null)
			{
				dict.Remove("BASE");
				result = false;
				goto IL_00f5;
			}
			dict["BASE"] = value.ObjectID;
			num = 1;
		}
		result = (byte)num != 0;
		goto IL_00f5;
		IL_00f5:
		return result;
	}

	internal static ActiveUnit ValidAsUnit(string NameOrId, Scenario ScenarioContext, [Optional][DefaultParameterValue(null)] ref Side Side)
	{
		ActiveUnit result = null;
		try
		{
			result = ((Side != null) ? Side.Units.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, NameOrId, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, NameOrId, StringComparison.OrdinalIgnoreCase)) : ScenarioContext.ActiveUnits_List.FirstOrDefault([SpecialName] (ActiveUnit s) => string.Equals(s.Name, NameOrId, StringComparison.OrdinalIgnoreCase) || string.Equals(s.ObjectID, NameOrId, StringComparison.OrdinalIgnoreCase)));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	internal static Contact ValidAsContact(string NameOrId, Scenario ScenarioContext, [Optional][DefaultParameterValue(null)] ref Side Side)
	{
		Contact contact = null;
		bool flag = false;
		try
		{
			if (Side != null)
			{
				foreach (Contact contacts_ in Side.Contacts_List)
				{
					if (string.Equals(contacts_.ObjectID, NameOrId, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_.Name, NameOrId, StringComparison.OrdinalIgnoreCase))
					{
						contact = contacts_;
						flag = true;
						break;
					}
				}
				if (contact == null)
				{
					foreach (string key in Side.NewContactsQueue.Keys)
					{
						Contact contact2 = Side.NewContactsQueue[key];
						if (string.Equals(contact2.ObjectID, NameOrId, StringComparison.OrdinalIgnoreCase) || string.Equals(contact2.Name, NameOrId, StringComparison.OrdinalIgnoreCase))
						{
							contact = contact2;
							flag = true;
							break;
						}
					}
				}
			}
			else
			{
				Side[] sides_ReadOnly = ScenarioContext.Sides_ReadOnly;
				foreach (Side side in sides_ReadOnly)
				{
					if (flag)
					{
						break;
					}
					foreach (Contact contacts_2 in side.Contacts_List)
					{
						if (string.Equals(contacts_2.ObjectID, NameOrId, StringComparison.OrdinalIgnoreCase) || string.Equals(contacts_2.Name, NameOrId, StringComparison.OrdinalIgnoreCase))
						{
							contact = contacts_2;
							flag = true;
							break;
						}
					}
					if (contact != null)
					{
						continue;
					}
					foreach (string key2 in side.NewContactsQueue.Keys)
					{
						Contact contact3 = side.NewContactsQueue[key2];
						if (string.Equals(contact3.ObjectID, NameOrId, StringComparison.OrdinalIgnoreCase) || string.Equals(contact3.Name, NameOrId, StringComparison.OrdinalIgnoreCase))
						{
							contact = contact3;
							flag = true;
							break;
						}
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return contact;
	}

	internal static long ParseDateAsSeconds(string datestring)
	{
		double a = 0.0;
		string[] array = Strings.Split(datestring, ":", -1, (CompareMethod)0);
		if (array.Count() == 4)
		{
			int num = array.Length - 1;
			for (int i = 0; i <= num; i++)
			{
				if (array[i] == "")
				{
					array[i] = "0";
				}
			}
			a = new TimeSpan(Conversions.ToInteger(array[0]), Conversions.ToInteger(array[1]), Conversions.ToInteger(array[2]), Conversions.ToInteger(array[3])).TotalSeconds;
		}
		return (long)Math.Round(a);
	}

	internal static (int DayValue, int MonthValue, int YearValue) xParseDate_DDMMYYYY(string dateString)
	{
		string text = string.Empty;
		if (!dateString.Contains(":"))
		{
			if (dateString.Contains("."))
			{
				text = ".";
			}
			else if (dateString.Contains("/"))
			{
				text = "/";
			}
		}
		else
		{
			text = ":";
		}
		if (!string.IsNullOrEmpty(text))
		{
			int item;
			int item2;
			int item3;
			try
			{
				item = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[0]);
				item2 = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[1]);
				item3 = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[2]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError("Error in parsing provided date value: " + dateString + " - Error: " + ex2.Message);
			}
			return (DayValue: item, MonthValue: item2, YearValue: item3);
		}
		throw new LuaError("Error in parsing provided date value: " + dateString + " - The delimiter must be either (.), (/) or (:)");
	}

	internal static (int DayValue, int MonthValue, int YearValue) xParseDate_MMDDYYYY(string dateString)
	{
		string text = string.Empty;
		if (dateString.Contains(":"))
		{
			text = ":";
		}
		else if (dateString.Contains("."))
		{
			text = ".";
		}
		else if (dateString.Contains("/"))
		{
			text = "/";
		}
		if (!string.IsNullOrEmpty(text))
		{
			int item;
			int item2;
			int item3;
			try
			{
				item = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[0]);
				item2 = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[1]);
				item3 = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[2]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError("Error in parsing provided date value: " + dateString + " - Error: " + ex2.Message);
			}
			return (DayValue: item2, MonthValue: item, YearValue: item3);
		}
		throw new LuaError("Error in parsing provided date value: " + dateString + " - The delimiter must be either (.), (/) or (:)");
	}

	internal static (int DayValue, int MonthValue, int YearValue) xParseDate_YYYYMMDD(string dateString)
	{
		string text = string.Empty;
		if (dateString.Contains(":"))
		{
			text = ":";
		}
		else if (dateString.Contains("."))
		{
			text = ".";
		}
		else if (dateString.Contains("/"))
		{
			text = "/";
		}
		if (!string.IsNullOrEmpty(text))
		{
			int item;
			int item2;
			int item3;
			try
			{
				item = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[0]);
				item2 = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[1]);
				item3 = Conversions.ToInteger(dateString.Split(new char[1] { Conversions.ToChar(text) })[2]);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new LuaError("Error in parsing provided date value: " + dateString + " - Error: " + ex2.Message);
			}
			return (DayValue: item3, MonthValue: item2, YearValue: item);
		}
		throw new LuaError("Error in parsing provided date value: " + dateString + " - The delimiter must be either (.), (/) or (:)");
	}

	internal static (int HourValue, int MinuteValue, int SecondValue) xParseTime_HHMMSS(string timeString)
	{
		string text = string.Empty;
		if (timeString.Contains(":"))
		{
			text = ":";
		}
		else if (timeString.Contains("."))
		{
			text = ".";
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new LuaError("Error in parsing provided time value: " + timeString + " - The delimiter must be either (.) or (:)");
		}
		int item;
		int item2;
		int item3;
		try
		{
			item = Conversions.ToInteger(timeString.Split(new char[1] { Conversions.ToChar(text) })[0]);
			item2 = Conversions.ToInteger(timeString.Split(new char[1] { Conversions.ToChar(text) })[1]);
			item3 = Conversions.ToInteger(timeString.Split(new char[1] { Conversions.ToChar(text) })[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("Error in parsing provided time value: " + timeString + " - Error: " + ex2.Message);
		}
		return (HourValue: item, MinuteValue: item2, SecondValue: item3);
	}

	internal static DateTime xParseDateTime_ISO(string iso8601String, [Optional][DefaultParameterValue(null)] ref int? DayValue, [Optional][DefaultParameterValue(null)] ref int? MonthValue, [Optional][DefaultParameterValue(null)] ref int? YearValue, [Optional][DefaultParameterValue(null)] ref int? HourValue, [Optional][DefaultParameterValue(null)] ref int? MinuteValue, [Optional][DefaultParameterValue(null)] ref int? SecondValue)
	{
		DateTime result = DateTime.MinValue;
		if (!DateTime.TryParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out result))
		{
			if (DateTime.TryParseExact(iso8601String, new string[2] { "yyyyMMddHHmmss", "yyyyMMddHHmmssZ" }, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AdjustToUniversal, out result))
			{
				result.ToString("yyyyMMdd");
				result.ToString("HHmmss");
				if (DayValue.HasValue)
				{
					DayValue = result.Day;
				}
				if (MonthValue.HasValue)
				{
					MonthValue = result.Month;
				}
				if (YearValue.HasValue)
				{
					YearValue = result.Year;
				}
				if (HourValue.HasValue)
				{
					HourValue = result.Hour;
				}
				if (MinuteValue.HasValue)
				{
					MinuteValue = result.Minute;
				}
				if (SecondValue.HasValue)
				{
					SecondValue = result.Second;
				}
				return result;
			}
			return DateTime.MinValue;
		}
		result.ToString("yyyyMMdd");
		result.ToString("HHmmss");
		if (DayValue.HasValue)
		{
			DayValue = result.Day;
		}
		if (MonthValue.HasValue)
		{
			MonthValue = result.Month;
		}
		if (YearValue.HasValue)
		{
			YearValue = result.Year;
		}
		if (HourValue.HasValue)
		{
			HourValue = result.Hour;
		}
		if (MinuteValue.HasValue)
		{
			MinuteValue = result.Minute;
		}
		if (SecondValue.HasValue)
		{
			SecondValue = result.Second;
		}
		return result;
	}

	public static DateTime xParseDateTime_String(string theString, DateFormat theDateFormat)
	{
		DateTime result = default(DateTime);
		try
		{
			switch (theDateFormat)
			{
			case DateFormat.DDMMYYYY:
			{
				CultureInfo provider = CultureInfo.CreateSpecificCulture("en-GB");
				if (!DateTime.TryParse(theString, provider, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
				{
					return DateTime.MinValue;
				}
				break;
			}
			case DateFormat.MMDDYYYY:
			{
				CultureInfo provider = CultureInfo.CreateSpecificCulture("en-US");
				if (!DateTime.TryParse(theString, provider, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
				{
					return DateTime.MinValue;
				}
				break;
			}
			case DateFormat.YYYYMMDD:
			{
				CultureInfo provider = CultureInfo.CreateSpecificCulture("fr-FR");
				if (!DateTime.TryParse(theString, provider, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
				{
					return DateTime.MinValue;
				}
				break;
			}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void smethod_0()
	{
		ArrayExtensions.Clear(ref string_4);
		string[] array = string_0;
		foreach (string text in array)
		{
			string[] array2 = string_3;
			foreach (string text2 in array2)
			{
				ArrayExtensions.Add(ref string_4, text + " " + text2);
			}
		}
		ArrayExtensions.Clear(ref string_5);
		string[] array3 = string_1;
		foreach (string text3 in array3)
		{
			string[] array4 = string_3;
			foreach (string text4 in array4)
			{
				ArrayExtensions.Add(ref string_5, text3 + " " + text4);
			}
		}
		ArrayExtensions.Clear(ref string_6);
		string[] array5 = string_2;
		foreach (string text5 in array5)
		{
			string[] array6 = string_3;
			foreach (string text6 in array6)
			{
				ArrayExtensions.Add(ref string_6, text5 + " " + text6);
			}
		}
	}

	internal static DateTime? ParseDateTime_String(string theString, DateFormat? theDateFormat)
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		_ = currentCulture.DateTimeFormat.TimeSeparator;
		_ = currentCulture.DateTimeFormat.DateSeparator;
		List<string> list = new List<string>();
		if (bool_0)
		{
			smethod_0();
			bool_0 = false;
		}
		DateTime result = default(DateTime);
		DateTime? result2;
		if (!Misc.ContainsChar(theString, '!') && theDateFormat.HasValue)
		{
			try
			{
				DateFormat? dateFormat = theDateFormat;
				int? num = (int?)dateFormat;
				if (((!num.HasValue) ? ((bool?)null) : new bool?(num.GetValueOrDefault() == 0)) == true)
				{
					list.AddRange(string_4);
					list.AddRange(string_7);
					DateTimeStyles dateTimeStyles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal;
					if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
					{
						result2 = null;
						goto IL_031e;
					}
				}
				else
				{
					num = (int?)dateFormat;
					if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 1)) != true)
					{
						num = (int?)dateFormat;
						if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 2)) == true)
						{
							list.AddRange(string_6);
							list.AddRange(string_7);
							DateTimeStyles dateTimeStyles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal;
							if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
							{
								result2 = null;
								goto IL_031e;
							}
						}
						else
						{
							num = (int?)dateFormat;
							if (((!num.HasValue) ? ((bool?)null) : new bool?(num == 3)) == true)
							{
								list.AddRange(string_7);
								DateTimeStyles dateTimeStyles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal;
								if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
								{
									result2 = null;
									goto IL_031e;
								}
							}
						}
					}
					else
					{
						list.AddRange(string_5);
						list.AddRange(string_7);
						DateTimeStyles dateTimeStyles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal;
						if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
						{
							result2 = null;
							goto IL_031e;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				ProjectData.ClearProjectError();
			}
			result2 = result;
		}
		else
		{
			list = theString.Split(new char[1] { '!' }).ToList();
			DateTimeStyles dateTimeStyles = DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal;
			if (list.Count == 1)
			{
				if (DateTime.TryParse(list[0], currentCulture, dateTimeStyles, out result))
				{
					goto IL_0316;
				}
				result2 = null;
			}
			else
			{
				if (DateTime.TryParseExact(list[0], list[1], null, dateTimeStyles, out result))
				{
					goto IL_0316;
				}
				result2 = null;
			}
		}
		goto IL_031e;
		IL_0316:
		result2 = result;
		goto IL_031e;
		IL_031e:
		return result2;
	}

	internal static (bool failed, int HourValue, int MinuteValue, int SecondValue) ParseTime_String(string timeString)
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		List<string> list = new List<string>();
		try
		{
			list.AddRange(string_3);
			if (DateTime.TryParseExact(timeString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result))
			{
				result.ToString("yyyyMMdd");
				result.ToString("HHmmss");
				int hour = result.Hour;
				int minute = result.Minute;
				int second = result.Second;
				return (failed: false, HourValue: hour, MinuteValue: minute, SecondValue: second);
			}
			return (failed: true, HourValue: 0, MinuteValue: 0, SecondValue: 0);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("Error in parsing provided time value: " + timeString + " - Error: " + ex2.Message);
		}
	}

	internal static (bool failed, int dayValue, int monthValue, int yearValue) ParseDate_String(string theString, DateFormat theDateFormat)
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		List<string> list = new List<string>();
		try
		{
			DateTime result = default(DateTime);
			switch (theDateFormat)
			{
			case DateFormat.DDMMYYYY:
				list.AddRange(string_0);
				if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
				{
					return (failed: true, dayValue: 0, monthValue: 0, yearValue: 0);
				}
				goto default;
			case DateFormat.MMDDYYYY:
				list.AddRange(string_1);
				if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
				{
					return (failed: true, dayValue: 0, monthValue: 0, yearValue: 0);
				}
				goto default;
			case DateFormat.YYYYMMDD:
				list.AddRange(string_2);
				if (!DateTime.TryParseExact(theString, list.ToArray(), currentCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
				{
					return (failed: true, dayValue: 0, monthValue: 0, yearValue: 0);
				}
				goto default;
			default:
			{
				result.ToString("yyyyMMdd");
				result.ToString("HHmmss");
				int year = result.Year;
				int month = result.Month;
				int day = result.Day;
				return (failed: false, dayValue: day, monthValue: month, yearValue: year);
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("Error in parsing provided date value: " + theString + " - Error: " + ex2.Message);
		}
	}

	internal static (bool failed, int HourValue, int MinuteValue, int SecondValue) ParseTime_Duration(string timeString)
	{
		string text = string.Empty;
		if (timeString.Contains(":"))
		{
			text = ":";
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new LuaError("Error in parsing provided duration value: " + timeString + " - The delimiter must be (:) in format days:hour:min");
		}
		float num;
		float num2;
		float num3;
		try
		{
			num = Conversions.ToSingle(timeString.Split(new char[1] { Conversions.ToChar(text) })[0]);
			num2 = Conversions.ToSingle(timeString.Split(new char[1] { Conversions.ToChar(text) })[1]);
			num3 = Conversions.ToSingle(timeString.Split(new char[1] { Conversions.ToChar(text) })[2]);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new LuaError("Error in parsing provided duration value: " + timeString + " - Error: " + ex2.Message);
		}
		return (failed: false, HourValue: (int)Math.Round(num * 24f + num2), MinuteValue: (int)Math.Round(num3), SecondValue: 0);
	}

	internal static string LuaInterpret(object obj)
	{
		if (!(obj is object[]))
		{
			if (!(obj is string))
			{
				if (!(obj is double))
				{
					if (!(obj is bool))
					{
						if (!(obj is LuaTable))
						{
							if (obj == null)
							{
								return "nil";
							}
							return obj.ToString();
						}
						IDictionaryEnumerator enumerator = ((LuaTable)obj).GetEnumerator();
						string text = "{";
						bool flag = true;
						while (enumerator.MoveNext())
						{
							if (!flag)
							{
								text += ",";
							}
							else
							{
								flag = false;
							}
							text = ((enumerator.Key is string) ? (text + " " + enumerator.Key.ToString() + " = ") : (text + " [" + enumerator.Key.ToString() + "] = "));
							text = ((enumerator.Value is string) ? (text + "'" + LuaInterpret(RuntimeHelpers.GetObjectValue(enumerator.Value)) + "'") : ((enumerator.Value is LuaFunction) ? (text + enumerator.Value.ToString()) : ((!(enumerator.Value is LuaTable)) ? (text + LuaInterpret(RuntimeHelpers.GetObjectValue(enumerator.Value))) : ((((LuaTable)enumerator.Value).Keys.Count <= 50) ? (text + LuaInterpret(RuntimeHelpers.GetObjectValue(enumerator.Value))) : (text + enumerator.Value.ToString())))));
						}
						return text + " }";
					}
					if (Conversions.ToBoolean(obj))
					{
						return "'Yes'";
					}
					return "'No'";
				}
				return Conversions.ToString(obj);
			}
			return Conversions.ToString(obj);
		}
		string text2 = "";
		bool flag2 = true;
		object[] array = (object[])obj;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			object objectValue = RuntimeHelpers.GetObjectValue(array[i]);
			if (!flag2)
			{
				text2 += ",";
			}
			else
			{
				flag2 = false;
			}
			text2 += LuaInterpret(RuntimeHelpers.GetObjectValue(objectValue));
		}
		return text2;
	}

	public static void AddToLuaHistoryFile(ref string InfoText, ref object debugTextObject, bool includeHeader = false)
	{
		try
		{
			if (!LuaSandBox._lua_console & !LuaSandBox._lua_event)
			{
				return;
			}
			string text = null;
			if ((object)debugTextObject.GetType() == typeof(string))
			{
				text = Conversions.ToString(debugTextObject);
			}
			else
			{
				Exception ex = (Exception)debugTextObject;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Exception: ").Append(ex.Message).Append("\r\n")
					.Append("Stack Trace: ")
					.Append(ex.StackTrace)
					.Append("\r\n");
				if (!Information.IsNothing((object)ex.InnerException))
				{
					stringBuilder.Append("Inner Exception: ").Append(ex.InnerException.Message).Append("\r\n")
						.Append("Inner StackTrace: ")
						.Append(ex.InnerException.StackTrace)
						.Append("\r\n");
				}
				if (ex.Data.Count > 0)
				{
					stringBuilder.Append("Call Stack & Error details: ");
					IDictionaryEnumerator enumerator = ex.Data.GetEnumerator();
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						DictionaryEntry dictionaryEntry = ((current == null) ? default(DictionaryEntry) : ((DictionaryEntry)current));
						stringBuilder.Append("\r\n").Append(Conversions.ToString(dictionaryEntry.Key)).Append(", ")
							.Append(Conversions.ToString(dictionaryEntry.Value));
					}
				}
				text = stringBuilder.ToString();
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			if (includeHeader)
			{
				stringBuilder2.Append(DateAndTime.Now).Append(" -- B").Append("v1.10 - Build 1900.20")
					.Append(" -- ")
					.Append("\r\n");
			}
			if (InfoText.Length > 0)
			{
				stringBuilder2.Append(InfoText).Append("\r\n");
			}
			if (text.Length > 0)
			{
				stringBuilder2.Append(text).Append("\r\n");
			}
			try
			{
				string text2 = DateAndTime.Now.Year + "-" + Strings.Right("00" + DateAndTime.Now.Month, 2) + "-" + Strings.Right("00" + DateAndTime.Now.Day, 2);
				StreamWriter streamWriter = File.AppendText(GameGeneral.LogsPath + Conversions.ToString(Path.DirectorySeparatorChar) + "LuaHistory_" + text2 + ".txt");
				streamWriter.Write(stringBuilder2.ToString());
				streamWriter.Close();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			if (Debugger.IsAttached)
			{
				Debugger.Break();
			}
			ProjectData.ClearProjectError();
		}
	}
}
