using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Command_Core.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using ThreadSafeCollections;

namespace Command_Core;

[StandardModule]
public sealed class Weather
{
	public enum TTimeOfDayType : byte
	{
		tod_Day = 0,
		tod_Twilight = 1,
		tod_Night = 2,
		NoValue = byte.MaxValue
	}

	public enum THighCloudType : byte
	{
		None = 0,
		Ci_Cirrus = 8,
		Cs_Cirrostratus = 9,
		Cc_Cirrocumulus = 10
	}

	public enum TMiddleCloudType : byte
	{
		None = 0,
		Ac_Altocumulus = 5,
		As_Altostratus = 6,
		Ns_Nimbostratus = 7
	}

	public enum TLowCloudType : byte
	{
		None,
		Cb_Cumulonimbus,
		Sc_Stratocumulus,
		St_Stratus,
		Cu_Cumulus
	}

	public struct TCloudInfo
	{
		public TLowCloudType LowCloudType;

		public int LowCloudBase_m;

		public int LowCloudTop_m;

		public int LowCloudCoverThickness;

		public TMiddleCloudType MiddleCloudType;

		public int MiddleCloudBase_m;

		public int MiddleCloudTop_m;

		public int MiddleCloudCoverThickness;

		public THighCloudType HighCloudType;

		public int HighCloudBase_m;

		public int HighCloudTop_m;

		public int HighCloudCoverThickness;
	}

	public sealed class WeatherProfile
	{
		private static WeatherProfile weatherProfile_0;

		public TDictionary<double, double> GaseousAttenuationByFrequency;

		protected double _AverageTemp;

		protected int _DayNightTempModifier;

		protected double _Pressure;

		protected double _RelativeHumidity;

		public int SeaState;

		public float RainfallRate;

		private float float_0;

		public TCloudInfo CloudInfo;

		public int ContrailAltitude;

		public float SurfaceVisibilityKM;

		public double RunwayVisualRangeNM;

		public double GroundReflectionCoeff;

		protected double _DELTA_N;

		public double SurfaceRefractivity;

		public double SurfaceDuctHeight;

		public double EvaporationDuctHeight;

		public double RadiusEffective;

		public double k50;

		public static WeatherProfile StandardWeatherProfile
		{
			get
			{
				if (theScen.WeatherLevel != Scenario.WeatherModellingLevel.Level0)
				{
					throw new NotImplementedException();
				}
				return weatherProfile_0;
			}
		}

		public short ActualTempAtSL
		{
			get
			{
				switch (TimeOfDay)
				{
				default:
					if (Debugger.IsAttached)
					{
						Debugger.Break();
					}
					throw new NotImplementedException();
				case TTimeOfDayType.tod_Day:
					return (short)Math.Round(AverageTemp + (double)DayNightTempModifier);
				case TTimeOfDayType.tod_Twilight:
					return (short)Math.Round(AverageTemp);
				case TTimeOfDayType.tod_Night:
					return (short)Math.Round(AverageTemp - (double)DayNightTempModifier);
				}
			}
		}

		public string RainfallRate_Description
		{
			get
			{
				float rainfallRate = RainfallRate;
				if (rainfallRate == 0f)
				{
					return "No rain";
				}
				if (rainfallRate < 5f)
				{
					return "Very light rain";
				}
				if (rainfallRate < 10f)
				{
					return "Light rain";
				}
				if (rainfallRate < 20f)
				{
					return "Moderate rain";
				}
				if (rainfallRate < 30f)
				{
					return "Heavy rain";
				}
				if (rainfallRate < 40f)
				{
					return "Very heavy rain";
				}
				return "Extreme rain";
			}
		}

		public float FractionUnderRain
		{
			get
			{
				return float_0;
			}
			set
			{
				float_0 = value;
				double num = (double)float_0 - 0.001;
				if (float_0 == 0f)
				{
					num = 0.0;
				}
				if (num > 0.9)
				{
					CloudInfo.HighCloudTop_m = 10973;
					CloudInfo.HighCloudBase_m = 2134;
					CloudInfo.HighCloudCoverThickness = 8;
					CloudInfo.MiddleCloudTop_m = 0;
					CloudInfo.MiddleCloudBase_m = 0;
					CloudInfo.MiddleCloudCoverThickness = 0;
					CloudInfo.LowCloudTop_m = 610;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 8;
				}
				else if (num > 0.8)
				{
					CloudInfo.HighCloudTop_m = 10973;
					CloudInfo.HighCloudBase_m = 2134;
					CloudInfo.HighCloudCoverThickness = 8;
					CloudInfo.MiddleCloudTop_m = 0;
					CloudInfo.MiddleCloudBase_m = 0;
					CloudInfo.MiddleCloudCoverThickness = 0;
					CloudInfo.LowCloudTop_m = 610;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 2;
				}
				else if (num > 0.7)
				{
					CloudInfo.HighCloudTop_m = 10973;
					CloudInfo.HighCloudBase_m = 9144;
					CloudInfo.HighCloudCoverThickness = 4;
					CloudInfo.MiddleCloudTop_m = 4877;
					CloudInfo.MiddleCloudBase_m = 2134;
					CloudInfo.MiddleCloudCoverThickness = 8;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
				else if (num > 0.6)
				{
					CloudInfo.HighCloudTop_m = 9144;
					CloudInfo.HighCloudBase_m = 8230;
					CloudInfo.HighCloudCoverThickness = 2;
					CloudInfo.MiddleCloudTop_m = 4877;
					CloudInfo.MiddleCloudBase_m = 2134;
					CloudInfo.MiddleCloudCoverThickness = 4;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
				else if (num > 0.5)
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 8534;
					CloudInfo.MiddleCloudBase_m = 7620;
					CloudInfo.MiddleCloudCoverThickness = 4;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
				else if (num > 0.4)
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 4877;
					CloudInfo.MiddleCloudBase_m = 2134;
					CloudInfo.MiddleCloudCoverThickness = 4;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
				else if (num > 0.3)
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 0;
					CloudInfo.MiddleCloudBase_m = 0;
					CloudInfo.MiddleCloudCoverThickness = 0;
					CloudInfo.LowCloudTop_m = 2134;
					CloudInfo.LowCloudBase_m = 610;
					CloudInfo.LowCloudCoverThickness = 4;
				}
				else if (num > 0.2)
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 7010;
					CloudInfo.MiddleCloudBase_m = 6096;
					CloudInfo.MiddleCloudCoverThickness = 2;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
				else if (num > 0.1)
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 4877;
					CloudInfo.MiddleCloudBase_m = 3048;
					CloudInfo.MiddleCloudCoverThickness = 2;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
				else if (num > 0.0)
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 0;
					CloudInfo.MiddleCloudBase_m = 0;
					CloudInfo.MiddleCloudCoverThickness = 0;
					CloudInfo.LowCloudTop_m = 2134;
					CloudInfo.LowCloudBase_m = 1524;
					CloudInfo.LowCloudCoverThickness = 2;
				}
				else
				{
					CloudInfo.HighCloudTop_m = 0;
					CloudInfo.HighCloudBase_m = 0;
					CloudInfo.HighCloudCoverThickness = 0;
					CloudInfo.MiddleCloudTop_m = 0;
					CloudInfo.MiddleCloudBase_m = 0;
					CloudInfo.MiddleCloudCoverThickness = 0;
					CloudInfo.LowCloudTop_m = 0;
					CloudInfo.LowCloudBase_m = 0;
					CloudInfo.LowCloudCoverThickness = 0;
				}
			}
		}

		public string CloudInfo_Description
		{
			get
			{
				float fractionUnderRain = FractionUnderRain;
				if (fractionUnderRain > 0.9f)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Thick fog 0 - " + Conversions.ToString(1) + "km, solid cloud cover " + Conversions.ToString(2) + " - " + Conversions.ToString(11) + " km";
					}
					return "Thick fog 0 - 2k ft, solid cloud cover 7 - 36k ft";
				}
				if (fractionUnderRain > 0.8f)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Thin fog 0 - " + Conversions.ToString(1) + "km, solid cloud cover " + Conversions.ToString(2) + " - " + Conversions.ToString(11) + " km";
					}
					return "Thin fog 0 - 2k ft, solid cloud cover 7 - 36k ft";
				}
				if (fractionUnderRain > 0.7f)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Solid middle clouds " + Conversions.ToString(2) + " - " + Conversions.ToString(5) + " km, moderate high clouds " + Conversions.ToString(9) + " - " + Conversions.ToString(11) + " km";
					}
					return "Solid middle clouds 7 - 16k ft, moderate high clouds 30 - 36k ft";
				}
				if (fractionUnderRain > 0.6f)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Moderate middle clouds 7 - 16k ft, light high clouds 27 - 30k ft";
					}
					return "Moderate middle clouds " + Conversions.ToString(2) + " - " + Conversions.ToString(5) + " km, light high clouds " + Conversions.ToString(8) + " - " + Conversions.ToString(9) + " km";
				}
				if (fractionUnderRain > 0.5f)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Moderate high clouds 25 - 28k ft";
					}
					return "Moderate high clouds " + Conversions.ToString(8) + " - " + Conversions.ToString(9) + " km";
				}
				if (fractionUnderRain > 0.4f)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Moderate middle clouds 7 - 16k ft";
					}
					return "Moderate middle clouds " + Conversions.ToString(2) + " - " + Conversions.ToString(5) + " km";
				}
				if (fractionUnderRain > 0.3f)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Moderate low clouds 2 - 7k ft";
					}
					return "Moderate low clouds " + Conversions.ToString(1) + " - " + Conversions.ToString(2) + " km";
				}
				if (fractionUnderRain > 0.2f)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Light high clouds 20 - 23k ft";
					}
					return "Light high clouds " + Conversions.ToString(6) + " - " + Conversions.ToString(7) + " km";
				}
				if (fractionUnderRain > 0.1f)
				{
					if (SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Light middle clouds 10 - 16k ft";
					}
					return "Light middle clouds " + Conversions.ToString(3) + " - " + Conversions.ToString(5) + " km";
				}
				if (fractionUnderRain > 0f)
				{
					if (!SimConfiguration.DefaultGamePreferences.ShowAltitudeInFeet)
					{
						return "Light low clouds " + Conversions.ToString(2) + " - " + Conversions.ToString(2) + " km";
					}
					return "Light low clouds 5 - 7k ft";
				}
				return "Clear sky";
			}
		}

		public double AverageTemp
		{
			get
			{
				return _AverageTemp;
			}
			set
			{
				if (_AverageTemp != value)
				{
					_AverageTemp = value;
					SurfaceRefractivity = RefractivityN(_AverageTemp, _Pressure, _RelativeHumidity);
					GaseousAttenuationByFrequency.Clear();
				}
			}
		}

		public int DayNightTempModifier
		{
			get
			{
				return _DayNightTempModifier;
			}
			set
			{
				if (_DayNightTempModifier != value)
				{
					_DayNightTempModifier = value;
				}
			}
		}

		public double Pressure
		{
			get
			{
				return _Pressure;
			}
			set
			{
				if (_Pressure != value)
				{
					_Pressure = value;
					SurfaceRefractivity = RefractivityN(_AverageTemp, _Pressure, _RelativeHumidity);
					GaseousAttenuationByFrequency.Clear();
				}
			}
		}

		public double RelativeHumidity
		{
			get
			{
				return _RelativeHumidity;
			}
			set
			{
				if (_RelativeHumidity != value)
				{
					_RelativeHumidity = value;
					SurfaceRefractivity = RefractivityN(_AverageTemp, _Pressure, _RelativeHumidity);
					GaseousAttenuationByFrequency.Clear();
				}
			}
		}

		public float SurfaceVisibilityNM
		{
			get
			{
				return (float)((double)SurfaceVisibilityKM * 1000.0 / 1852.0);
			}
			set
			{
				SurfaceVisibilityKM = (float)((double)value * 1852.0 / 1000.0);
			}
		}

		public double DELTA_N
		{
			get
			{
				return _DELTA_N;
			}
			set
			{
				if (_DELTA_N != value)
				{
					_DELTA_N = value;
					RadiusEffective = median_eff_Re(value);
					k50 = 157.0 / (157.0 - DELTA_N);
				}
			}
		}

		static WeatherProfile()
		{
			Class72.smethod_20();
			weatherProfile_0 = new WeatherProfile();
		}

		public WeatherProfile()
		{
			GaseousAttenuationByFrequency = new TDictionary<double, double>();
			AverageTemp = 15.0;
			DayNightTempModifier = 10;
			Pressure = 1013.25;
			RelativeHumidity = 86.17;
			GroundReflectionCoeff = 0.0;
			DELTA_N = 39.0;
			SurfaceDuctHeight = 0.0;
			EvaporationDuctHeight = 0.0;
			RainfallRate = 0f;
			FractionUnderRain = 0f;
			SeaState = 0;
		}

		public void ToXML(ref XmlWriter theWriter)
		{
			theWriter.WriteStartElement("WeatherProfile");
			theWriter.WriteElementString("DayNightModifier", XmlConvert.ToString(DayNightTempModifier));
			theWriter.WriteElementString("Temp", XmlConvert.ToString(AverageTemp));
			theWriter.WriteElementString("Pressure", XmlConvert.ToString(Pressure));
			theWriter.WriteElementString("RL", XmlConvert.ToString(RelativeHumidity));
			theWriter.WriteElementString("GRC", XmlConvert.ToString(GroundReflectionCoeff));
			theWriter.WriteElementString("DN", XmlConvert.ToString(DELTA_N));
			theWriter.WriteElementString("SDH", XmlConvert.ToString(SurfaceDuctHeight));
			theWriter.WriteElementString("EDH", XmlConvert.ToString(EvaporationDuctHeight));
			theWriter.WriteElementString("RFR", XmlConvert.ToString(RainfallRate));
			theWriter.WriteElementString("FUR", XmlConvert.ToString(FractionUnderRain));
			theWriter.WriteElementString("SS", XmlConvert.ToString(SeaState));
			theWriter.WriteEndElement();
		}

		public static WeatherProfile FromXML(ref XmlNode theNode)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			WeatherProfile weatherProfile = new WeatherProfile();
			foreach (XmlNode childNode in theNode.ChildNodes[0].ChildNodes)
			{
				XmlNode val = childNode;
				switch (val.Name)
				{
				case "Temp":
					weatherProfile.AverageTemp = XmlConvert.ToDouble(val.InnerText);
					break;
				case "SDH":
					weatherProfile.SurfaceDuctHeight = XmlConvert.ToDouble(val.InnerText);
					break;
				case "RL":
					weatherProfile.RelativeHumidity = XmlConvert.ToDouble(val.InnerText);
					break;
				case "SS":
					weatherProfile.SeaState = XmlConvert.ToInt16(val.InnerText);
					break;
				case "DN":
					weatherProfile.DELTA_N = XmlConvert.ToDouble(val.InnerText);
					break;
				case "GRC":
					weatherProfile.GroundReflectionCoeff = XmlConvert.ToDouble(val.InnerText);
					break;
				case "EDH":
					weatherProfile.EvaporationDuctHeight = XmlConvert.ToDouble(val.InnerText);
					break;
				case "RFR":
					weatherProfile.RainfallRate = XmlConvert.ToInt32(val.InnerText);
					break;
				case "FUR":
					weatherProfile.FractionUnderRain = XmlConvert.ToSingle(val.InnerText);
					break;
				case "DayNightModifier":
					try
					{
						weatherProfile.DayNightTempModifier = XmlConvert.ToInt32(val.InnerText);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						weatherProfile.DayNightTempModifier = 10;
						ProjectData.ClearProjectError();
					}
					break;
				case "Pressure":
					weatherProfile.Pressure = XmlConvert.ToDouble(val.InnerText);
					break;
				}
			}
			return weatherProfile;
		}

		public short ActualTempAtAltitude_CurrentScenarioTime(Scenario theScen, double theLat, double theLon, float theAlt)
		{
			DateTime time = theScen.Time;
			TTimeOfDayType timeOfDay = SunModule.GetTimeOfDay(theScen, time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, UseCurrentScenarioTime: true, theLat, theLon, 0.0);
			float num = (float)_AverageTemp;
			short num2;
			int atmosphereType;
			switch (timeOfDay)
			{
			default:
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw new NotImplementedException();
			case TTimeOfDayType.tod_Day:
				num2 = (short)Math.Round(num + 10f);
				atmosphereType = 5;
				break;
			case TTimeOfDayType.tod_Twilight:
				num2 = (short)Math.Round(num);
				atmosphereType = 5;
				break;
			case TTimeOfDayType.tod_Night:
				num2 = (short)Math.Round(num - 10f);
				atmosphereType = 5;
				break;
			}
			return (short)Math.Round(Standard_Atmosphere_AtThisAltitude((TAtmosphereType)atmosphereType, theAlt / 1000f, num2).Temperature - 273.15);
		}

		public void ImportWeatherRecord(ref TWeatherRecord V)
		{
			AverageTemp = (double)(int)V.Temp - 100.0;
			Pressure = V.Pressure;
			if ((V.RelativeHumidity > 100) | (V.RelativeHumidity < 0))
			{
				throw new Exception("Relative humidity out of bounds");
			}
			RelativeHumidity = (int)V.RelativeHumidity;
			if (!((V.SeaState > 9) | (V.SeaState < 0)))
			{
				SeaState = V.SeaState;
				if (V.DELTA_N >= 157)
				{
					throw new Exception("Refractivity gradient out of bounds");
				}
				DELTA_N = V.DELTA_N;
				RainfallRate = V.RainfallRate;
				if (!((V.PercentUnderRain > 100) | (V.PercentUnderRain < 0)))
				{
					FractionUnderRain = (float)((double)(int)V.PercentUnderRain / 100.0);
					if (!(((uint)V.LowCloudType > 4u) | ((uint)V.LowCloudType < 0u)))
					{
						if (((uint)V.MiddleCloudType > 7u) | ((uint)V.MiddleCloudType < 0u))
						{
							throw new Exception("Invalid middle cloud type");
						}
						if (!(((uint)V.HighCloudType > 10u) | ((uint)V.HighCloudType < 0u)))
						{
							CloudInfo.LowCloudType = (TLowCloudType)V.LowCloudType;
							CloudInfo.MiddleCloudType = (TMiddleCloudType)V.MiddleCloudType;
							CloudInfo.HighCloudType = (THighCloudType)V.HighCloudType;
							if ((V.LowCloudBase < 0) | (V.LowCloudTop < V.LowCloudBase))
							{
								throw new Exception("Invalid low cloud limits");
							}
							if ((V.MiddleCloudBase < 0) | (V.MiddleCloudTop < V.MiddleCloudBase))
							{
								throw new Exception("Invalid middle cloud limits");
							}
							if ((V.HighCloudBase < 0) | (V.HighCloudTop < V.HighCloudBase))
							{
								throw new Exception("Invalid high cloud limits");
							}
							if (V.LowCloudBase > 0)
							{
								if ((V.MiddleCloudBase > 0) & (V.MiddleCloudBase < V.LowCloudTop))
								{
									throw new Exception("Middle cloud intersects low cloud");
								}
								if ((V.HighCloudBase > 0) & (V.HighCloudBase < V.LowCloudTop))
								{
									throw new Exception("High cloud intersects low cloud");
								}
							}
							if (V.MiddleCloudBase > 0 && ((V.HighCloudBase > 0) & (V.HighCloudBase < V.MiddleCloudTop)))
							{
								throw new Exception("High cloud intersects low cloud");
							}
							if (!((V.LowCloudCover < 0) | (V.LowCloudCover > 8) | (V.MiddleCloudCover < 0) | (V.MiddleCloudCover > 8) | (V.HighCloudCover < 0) | (V.HighCloudCover > 8)))
							{
								CloudInfo.LowCloudBase_m = V.LowCloudBase;
								CloudInfo.MiddleCloudBase_m = V.MiddleCloudBase;
								CloudInfo.HighCloudBase_m = V.HighCloudBase;
								CloudInfo.LowCloudTop_m = V.LowCloudTop;
								CloudInfo.MiddleCloudTop_m = V.MiddleCloudTop;
								CloudInfo.HighCloudTop_m = V.HighCloudTop;
								CloudInfo.LowCloudCoverThickness = V.LowCloudCover;
								CloudInfo.MiddleCloudCoverThickness = V.MiddleCloudCover;
								CloudInfo.HighCloudCoverThickness = V.HighCloudCover;
								if (V.ContrailAltitude < 0)
								{
									throw new Exception("Contrail altitude cannot be negative");
								}
								ContrailAltitude = V.ContrailAltitude;
								if (V.SurfaceVisibility < 0)
								{
									throw new Exception("Surface visibility cannot be negative");
								}
								SurfaceVisibilityKM = (float)((double)V.SurfaceVisibility / 100.0);
								if (V.SurfaceDuctHeight < 0)
								{
									throw new Exception("Surface visibility cannot be negative");
								}
								SurfaceDuctHeight = V.SurfaceDuctHeight;
								if (V.EvaporationDuctHeight < 0)
								{
									throw new Exception("Surface visibility cannot be negative");
								}
								EvaporationDuctHeight = (int)V.EvaporationDuctHeight;
								return;
							}
							throw new Exception("Cloud cover for one of the layers outside the 0..8 range");
						}
						throw new Exception("Invalid high cloud type");
					}
					throw new Exception("Invalid low cloud type");
				}
				throw new Exception("Rain patchiness out of bounds");
			}
			throw new Exception("Sea state out of bounds");
		}
	}

	public struct TSDSItem
	{
		public double AvgEvapDuct;

		public int MSQ;

		public int[] CDF;
	}

	public struct TESARainItem
	{
		public double MC;

		public double MS;

		public double Pr6;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 35)]
	public struct TWeatherRecord
	{
		[FieldOffset(0)]
		public byte Temp;

		[FieldOffset(1)]
		public short Pressure;

		[FieldOffset(3)]
		public byte RelativeHumidity;

		[FieldOffset(4)]
		public byte SeaState;

		[FieldOffset(5)]
		public short DELTA_N;

		[FieldOffset(7)]
		public short RainfallRate;

		[FieldOffset(9)]
		public byte PercentUnderRain;

		[FieldOffset(10)]
		public byte LowCloudType;

		[FieldOffset(11)]
		public short LowCloudBase;

		[FieldOffset(13)]
		public short LowCloudTop;

		[FieldOffset(15)]
		public byte LowCloudCover;

		[FieldOffset(16)]
		public byte MiddleCloudType;

		[FieldOffset(17)]
		public short MiddleCloudBase;

		[FieldOffset(19)]
		public short MiddleCloudTop;

		[FieldOffset(21)]
		public byte MiddleCloudCover;

		[FieldOffset(22)]
		public byte HighCloudType;

		[FieldOffset(23)]
		public short HighCloudBase;

		[FieldOffset(25)]
		public short HighCloudTop;

		[FieldOffset(27)]
		public byte HighCloudCover;

		[FieldOffset(28)]
		public short ContrailAltitude;

		[FieldOffset(30)]
		public short SurfaceVisibility;

		[FieldOffset(32)]
		public short SurfaceDuctHeight;

		[FieldOffset(34)]
		public byte EvaporationDuctHeight;
	}

	public enum TWeatherGridType : byte
	{
		wgt_LatLonFixedStep,
		wgt_LatLonAdaptive,
		wgt_RectangularFixedStep,
		wgt_RectangularAdaptive,
		wgt_Polar
	}

	public struct TBILInfo
	{
		public int NRows;

		public int NCols;

		public double A;

		public double B;

		public double C;

		public double D;

		public double E;

		public double F;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 35)]
	public struct TWeatherHeader
	{
		[FieldOffset(0)]
		public int Magic;

		[FieldOffset(4)]
		public byte FormatVersion;

		[FieldOffset(5)]
		public byte Smoothing;

		[FieldOffset(6)]
		public byte CompressionAlgorithm;

		[FieldOffset(7)]
		public byte GridType;

		[FieldOffset(8)]
		public short Delta_T;

		[FieldOffset(10)]
		public float Delta_X;

		[FieldOffset(14)]
		public float Delta_Y;

		[FieldOffset(18)]
		public short T;

		[FieldOffset(20)]
		public short X;

		[FieldOffset(22)]
		public short Y;

		[FieldOffset(24)]
		public float LeftX;

		[FieldOffset(28)]
		public float LowerY;

		[FieldOffset(32)]
		public short xReserved1;

		[FieldOffset(34)]
		public byte xReserved2;
	}

	public enum TAtmosphereType
	{
		atm_Summer_Midlat,
		atm_Winter_Midlat,
		atm_Summer_Subart,
		atm_Winter_Subart,
		atm_Annual_Tropic,
		atm_ITU_R_Ref_Std
	}

	public struct TModRefractivityProfileItem
	{
		public int Altitude;

		public double ModRefractivity;
	}

	public struct TAtmosphere
	{
		public double Pressure;

		public double Temperature;

		public double Rho;
	}

	public const string ModuleCredits = "This module includes NOVAS 3.0f library from US Naval Observatory for astronomical calculations.\r\nBased on JPL ASCII ephemerides DE405 valid for 2000-2019 (will extend back to 1940s in the future)\r\nSources: ITU-R P.837 rainfall rate data\r\nDr. Tim Mitchell from UK Met.Office (Tyndall centre), CRU TS 2.1 (1901-2002 data)\r\nHansen's thermal anomaly data from http://data.giss.nasa.gov/gistemp/";

	public const string ModuleVersion = "Version 0.15";

	public const byte THighCloudType_Max = 10;

	public const byte TMiddleCloudType_Max = 7;

	public const byte TLowCloudType_Max = 4;

	public const int int_0 = 35;

	public const int WeatherMagic = 1464094019;

	public const byte WeatherVersionNumber = 2;

	public const int int_1 = 35;

	public static WeatherProfile WeatherAtThisTimeAndPlace
	{
		get
		{
			if (theScen.WeatherLevel != Scenario.WeatherModellingLevel.Level0)
			{
				throw new NotImplementedException();
			}
			WeatherProfile globalWeather = theScen.GlobalWeather;
			if (theScen.NatureSideExists())
			{
				CustomEnvironmentZone[] customEnvironmentZones = theScen.GetNatureSide().CustomEnvironmentZones;
				foreach (CustomEnvironmentZone customEnvironmentZone in customEnvironmentZones)
				{
					if (GeoPoint.IsInsideThisArea(theLat, theLon, customEnvironmentZone.Area_AsArray))
					{
						return customEnvironmentZone.Weather;
					}
				}
			}
			return globalWeather;
		}
	}

	internal static bool smethod_0(string Filename, ref TSDSItem[,] SDS)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01ad: Expected O, but got Unknown
		TextFieldParser val = new TextFieldParser(Filename);
		CultureInfo provider = new CultureInfo("en-US");
		val.TextFieldType = (FieldType)0;
		val.SetDelimiters(new string[1] { "\t" });
		SDS = new TSDSItem[18, 36];
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			do
			{
				SDS[num, num3].CDF = new int[21];
				num3++;
			}
			while (num3 <= 35);
			num++;
			if (num > 17)
			{
				break;
			}
			num2 = 0;
		}
		while (!val.EndOfData)
		{
			try
			{
				string[] array = val.ReadFields();
				if (!int.TryParse(array[0], NumberStyles.Integer, provider, out var result) || !int.TryParse(array[1], NumberStyles.Integer, provider, out var result2))
				{
					continue;
				}
				int num4 = (int)Math.Round((double)result / 10.0 + 9.0);
				int num5 = (int)Math.Round((double)result2 / 10.0 + 18.0);
				if (!double.TryParse(array[2], NumberStyles.AllowDecimalPoint, provider, out SDS[num4, num5].AvgEvapDuct))
				{
					SDS[num4, num5].AvgEvapDuct = 0.0;
				}
				int num6;
				if (!int.TryParse(array[3], NumberStyles.Integer, provider, out SDS[num4, num5].MSQ))
				{
					SDS[num4, num5].MSQ = 0;
					num6 = 0;
				}
				else
				{
					num6 = 0;
				}
				num = num6;
				do
				{
					if (!int.TryParse(array[4 + num], NumberStyles.Integer, provider, out SDS[num4, num5].CDF[num]))
					{
						SDS[num4, num5].CDF[num] = 0;
					}
					num++;
				}
				while (num <= 20);
			}
			catch (MalformedLineException ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				((Exception)ex)?.Data.Add("Error at 101180", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		val.Close();
		bool result3 = default(bool);
		return result3;
	}

	internal static bool smethod_1(string Filename, ref int[,,] SLP)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_00f7: Expected O, but got Unknown
		TextFieldParser val = new TextFieldParser(Filename);
		CultureInfo provider = new CultureInfo("en-US");
		val.TextFieldType = (FieldType)0;
		val.SetDelimiters(new string[1] { "\t" });
		SLP = new int[12, 37, 72];
		while (!val.EndOfData)
		{
			try
			{
				string[] array = val.ReadFields();
				if (int.TryParse(array[0], NumberStyles.Integer, provider, out var result) && int.TryParse(array[1], NumberStyles.Integer, provider, out var result2) && int.TryParse(array[2], NumberStyles.Integer, provider, out var result3))
				{
					int num = (int)Math.Round((double)result2 / 5.0 + 18.0);
					int num2 = (int)Math.Round((double)result3 / 5.0 + 36.0);
					if (!int.TryParse(array[3], NumberStyles.Integer, provider, out SLP[result - 1, num, num2]))
					{
						SLP[result, num, num2] = 0;
					}
				}
			}
			catch (MalformedLineException ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				((Exception)ex)?.Data.Add("Error at 101181", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		val.Close();
		bool result4 = default(bool);
		return result4;
	}

	internal static bool ReadESARainData(string Filename, ref TESARainItem[,] ESARain)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_0160: Expected O, but got Unknown
		TextFieldParser val = new TextFieldParser(Filename);
		CultureInfo provider = new CultureInfo("en-US");
		val.TextFieldType = (FieldType)0;
		val.SetDelimiters(new string[1] { "\t" });
		ESARain = new TESARainItem[121, 241];
		while (!val.EndOfData)
		{
			try
			{
				string[] array = val.ReadFields();
				if (double.TryParse(array[0], NumberStyles.Float, provider, out var result) && double.TryParse(array[1], NumberStyles.Float, provider, out var result2))
				{
					int num = (int)Math.Round(result / 1.5) + 60;
					int num2 = (int)Math.Round(result2 / 1.5);
					if (!double.TryParse(array[2], NumberStyles.Float, provider, out ESARain[num, num2].MC))
					{
						ESARain[num, num2].MC = 0.0;
					}
					if (!double.TryParse(array[3], NumberStyles.Float, provider, out ESARain[num, num2].MS))
					{
						ESARain[num, num2].MS = 0.0;
					}
					if (!double.TryParse(array[4], NumberStyles.Float, provider, out ESARain[num, num2].Pr6))
					{
						ESARain[num, num2].Pr6 = 0.0;
					}
				}
			}
			catch (MalformedLineException ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				((Exception)ex)?.Data.Add("Error at 101182", "");
				if (Debugger.IsAttached)
				{
					Debugger.Break();
				}
				throw;
			}
		}
		val.Close();
		bool result3 = default(bool);
		return result3;
	}

	internal static bool ReadBIL(string string_0, ref double[,] BIL, ref TBILInfo BILInfo, string string_1 = "", string string_2 = "")
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		bool result = false;
		if (!FileExistsNative.FileExistsFast(string_0))
		{
			result = false;
		}
		else
		{
			string text = ((Operators.CompareString(string_1, "", false) == 0) ? Path.ChangeExtension(string_0, ".hdr") : string_1);
			if (!FileExistsNative.FileExistsFast(text))
			{
				result = false;
			}
			else
			{
				string text2 = ((Operators.CompareString(string_2, "", false) == 0) ? Path.ChangeExtension(string_0, ".blw") : string_2);
				if (!FileExistsNative.FileExistsFast(text2))
				{
					result = false;
				}
				else
				{
					TextFieldParser val = new TextFieldParser(text);
					val.TrimWhiteSpace = true;
					val.TextFieldType = (FieldType)0;
					val.SetDelimiters(new string[1] { " " });
					try
					{
						string[] array = val.ReadFields();
						if (Operators.CompareString(Strings.UCase(array[0]), "BYTEORDER", false) == 0)
						{
							int i;
							for (i = 1; Operators.CompareString(array[i], "", false) == 0; i++)
							{
							}
							if (!((Operators.CompareString(Strings.UCase(array[i]), "M", false) == 0) | (Operators.CompareString(Strings.UCase(array[i]), "I", false) == 0)))
							{
								val.Close();
								result = false;
							}
							else
							{
								bool flag = default(bool);
								if (Operators.CompareString(Strings.UCase(array[i]), "M", false) == 0)
								{
									flag = true;
								}
								array = val.ReadFields();
								if (Operators.CompareString(Strings.UCase(array[0]), "LAYOUT", false) != 0)
								{
									val.Close();
									result = false;
								}
								else
								{
									for (i = 1; Operators.CompareString(array[i], "", false) == 0; i++)
									{
									}
									if (Operators.CompareString(Strings.UCase(array[i]), "BIL", false) != 0)
									{
										val.Close();
										result = false;
									}
									else
									{
										array = val.ReadFields();
										if (Operators.CompareString(Strings.UCase(array[0]), "NROWS", false) != 0)
										{
											val.Close();
											result = false;
										}
										else
										{
											for (i = 1; Operators.CompareString(array[i], "", false) == 0; i++)
											{
											}
											if (int.TryParse(array[i], out BILInfo.NRows))
											{
												array = val.ReadFields();
												if (Operators.CompareString(Strings.UCase(array[0]), "NCOLS", false) == 0)
												{
													for (i = 1; Operators.CompareString(array[i], "", false) == 0; i++)
													{
													}
													if (!int.TryParse(array[i], out BILInfo.NCols))
													{
														val.Close();
														result = false;
													}
													else
													{
														array = val.ReadFields();
														if (Operators.CompareString(Strings.UCase(array[0]), "NBANDS", false) != 0)
														{
															val.Close();
															result = false;
														}
														else
														{
															for (i = 1; Operators.CompareString(array[i], "", false) == 0; i++)
															{
															}
															if (int.TryParse(array[i], out var result2))
															{
																if (result2 != 1)
																{
																	throw new Exception("Multi-band files not supported");
																}
																array = val.ReadFields();
																if (Operators.CompareString(Strings.UCase(array[0]), "NBITS", false) != 0)
																{
																	val.Close();
																	result = false;
																}
																else
																{
																	for (i = 1; Operators.CompareString(array[i], "", false) == 0; i++)
																	{
																	}
																	if (int.TryParse(array[i], out var result3))
																	{
																		byte[] array2 = ((ServerComputer)MyProject.Computer).FileSystem.ReadAllBytes(string_0);
																		BIL = new double[BILInfo.NRows - 1 + 1, BILInfo.NCols - 1 + 1];
																		if ((double)array2.Length != (double)(BILInfo.NRows * BILInfo.NCols * result3) / 8.0)
																		{
																			throw new Exception("BIL file doesn't match the header");
																		}
																		switch (result3)
																		{
																		default:
																			throw new Exception("Multi-band files not supported");
																		case 32:
																		{
																			i = 0;
																			int num3 = BILInfo.NRows - 1;
																			for (int j = 0; j <= num3; j++)
																			{
																				int num4 = BILInfo.NCols - 1;
																				for (int k = 0; k <= num4; k++)
																				{
																					ulong num5 = (ulong)((!flag) ? (array2[i] + array2[i + 1] * 256 + array2[i + 2] * 256 * 256 + array2[i + 3] * 256 * 256 * 256) : (array2[i + 3] + array2[i + 2] * 256 + array2[i + 1] * 256 * 256 + array2[i] * 256 * 256 * 256));
																					if (decimal.Compare(new decimal(num5), 2147483647m) > 0)
																					{
																						BIL[j, k] = Convert.ToDouble(decimal.Subtract(new decimal(num5), 4294967296m));
																					}
																					else
																					{
																						BIL[j, k] = num5;
																					}
																					i += 4;
																				}
																			}
																			break;
																		}
																		case 16:
																		{
																			i = 0;
																			int num6 = BILInfo.NRows - 1;
																			for (int j = 0; j <= num6; j++)
																			{
																				int num7 = BILInfo.NCols - 1;
																				for (int k = 0; k <= num7; k++)
																				{
																					uint num8 = (uint)(flag ? (array2[i + 1] + array2[i] * 256) : (array2[i] + array2[i + 1] * 256));
																					if ((long)num8 > 32767L)
																					{
																						BIL[j, k] = (long)num8 - 65536L;
																					}
																					else
																					{
																						BIL[j, k] = num8;
																					}
																					i += 2;
																				}
																			}
																			break;
																		}
																		case 8:
																		{
																			i = 0;
																			int num = BILInfo.NRows - 1;
																			for (int j = 0; j <= num; j++)
																			{
																				int num2 = BILInfo.NCols - 1;
																				for (int k = 0; k <= num2; k++)
																				{
																					byte b = array2[i];
																					if (b > 127)
																					{
																						BIL[j, k] = b - 256;
																					}
																					else
																					{
																						BIL[j, k] = (int)b;
																					}
																					i++;
																				}
																			}
																			break;
																		}
																		}
																		array2 = null;
																		StreamReader streamReader = new StreamReader(text2, Encoding.ASCII, detectEncodingFromByteOrderMarks: false);
																		CultureInfo provider = new CultureInfo("en-US");
																		if (!double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out BILInfo.A))
																		{
																			throw new Exception("Invalid BLW file format");
																		}
																		if (!double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out BILInfo.B))
																		{
																			throw new Exception("Invalid BLW file format");
																		}
																		if (!double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out BILInfo.C))
																		{
																			throw new Exception("Invalid BLW file format");
																		}
																		if (!double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out BILInfo.D))
																		{
																			throw new Exception("Invalid BLW file format");
																		}
																		if (!double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out BILInfo.E))
																		{
																			throw new Exception("Invalid BLW file format");
																		}
																		if (!double.TryParse(streamReader.ReadLine(), NumberStyles.Float, provider, out BILInfo.F))
																		{
																			throw new Exception("Invalid BLW file format");
																		}
																		result = true;
																		streamReader.Close();
																	}
																	else
																	{
																		val.Close();
																		result = false;
																	}
																}
															}
															else
															{
																val.Close();
																result = false;
															}
														}
													}
												}
												else
												{
													val.Close();
													result = false;
												}
											}
											else
											{
												val.Close();
												result = false;
											}
										}
									}
								}
							}
						}
						else
						{
							val.Close();
							result = false;
						}
					}
					finally
					{
						val.Close();
					}
				}
			}
		}
		return result;
	}

	internal static double WorldToNearestBILValue(double Lat, double Lon, ref double[,] BIL, ref TBILInfo BILInfo)
	{
		if ((Information.UBound((Array)BIL, 1) != BILInfo.NRows - 1) | (Information.UBound((Array)BIL, 2) != BILInfo.NCols - 1))
		{
			throw new Exception("BIL array and BILInfo don't match");
		}
		double num = (Lat + BILInfo.E * BILInfo.C / BILInfo.A - BILInfo.C * Lon / BILInfo.A - BILInfo.F) / (BILInfo.D - BILInfo.B * BILInfo.C / BILInfo.A);
		double x = Lon / BILInfo.A - BILInfo.B * num / BILInfo.A - BILInfo.E / BILInfo.A;
		int val = RadarModel.Floor(num);
		int val2 = RadarModel.Floor(x);
		val2 = Math.Max(0, Math.Min(val2, Information.UBound((Array)BIL, 2)));
		val = Math.Max(0, Math.Min(val, Information.UBound((Array)BIL, 1)));
		return BIL[val, val2];
	}

	internal static int CoordToOffset(ref TWeatherHeader Hdr, double Lat, double Lon, int MinutesSinceStart)
	{
		int val = RadarModel.Floor((Lon - (double)Hdr.LeftX) / (double)Hdr.Delta_X);
		int val2 = RadarModel.Floor((Lat - (double)Hdr.LowerY) / (double)Hdr.Delta_Y);
		int val3 = RadarModel.Floor((double)MinutesSinceStart / (double)Hdr.Delta_T);
		val = Math.Max(0, Math.Min(Hdr.X - 1, val));
		val2 = Math.Max(0, Math.Min(Hdr.Y - 1, val2));
		val3 = Math.Max(0, Math.Min(Hdr.T - 1, val3));
		return val2 + Hdr.Y * val + (short)(Hdr.Y * Hdr.X) * val3 + 1;
	}

	public static double median_eff_Re(double DELTA_N)
	{
		double num = 157.0 / (157.0 - DELTA_N);
		return 6371.0 * num;
	}

	internal static TAtmosphere Standard_Atmosphere_AtThisAltitude(TAtmosphereType AtmosphereType, double Altitude_km, float TemperatureAtSL_Celcius = -99999f)
	{
		TAtmosphere result = default(TAtmosphere);
		if (TemperatureAtSL_Celcius == -99999f)
		{
			TemperatureAtSL_Celcius = 15f;
		}
		float num = (float)((double)TemperatureAtSL_Celcius + 273.15);
		switch (AtmosphereType)
		{
		case TAtmosphereType.atm_Summer_Midlat:
			if (!(Altitude_km >= 0.0 && Altitude_km <= 10.0))
			{
				if (Altitude_km > 10.0 && Altitude_km <= 72.0)
				{
					result.Pressure = 283.709 * Math.Exp(-0.147 * (Altitude_km - 10.0));
				}
				else if (!(Altitude_km > 72.0 && Altitude_km <= 100.0))
				{
					result.Pressure = 0.0;
				}
				else
				{
					result.Pressure = 0.0312402229 * Math.Exp(-0.165 * (Altitude_km - 72.0));
				}
			}
			else
			{
				result.Pressure = 1012.8186 - 111.5569 * Altitude_km + 3.8646 * Altitude_km * Altitude_km;
			}
			if (Altitude_km >= 0.0 && Altitude_km <= 13.0)
			{
				result.Temperature = 294.9838 - 5.2159 * Altitude_km - 0.07109 * Altitude_km * Altitude_km;
			}
			else if (Altitude_km > 13.0 && Altitude_km <= 17.0)
			{
				result.Temperature = 215.15;
			}
			else if (Altitude_km > 17.0 && Altitude_km <= 47.0)
			{
				result.Temperature = 215.15 * Math.Exp(0.008128 * (Altitude_km - 17.0));
			}
			else if (!(Altitude_km > 47.0 && Altitude_km <= 53.0))
			{
				if (!(Altitude_km > 53.0 && Altitude_km <= 80.0))
				{
					if (Altitude_km > 80.0 && Altitude_km <= 100.0)
					{
						result.Temperature = 175.0;
					}
					else
					{
						result.Temperature = 0.0;
					}
				}
				else
				{
					result.Temperature = 275.0 + 20.0 * (1.0 - Math.Exp(0.06 * (Altitude_km - 53.0)));
				}
			}
			else
			{
				result.Temperature = 275.0;
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 15.0))
			{
				result.Rho = 0.0;
			}
			else
			{
				result.Rho = 14.2542 * Math.Exp(-0.4174 * Altitude_km - 0.0229 * Altitude_km * Altitude_km + 0.001007 * Altitude_km * Altitude_km * Altitude_km);
			}
			break;
		case TAtmosphereType.atm_Winter_Midlat:
			if (!(Altitude_km >= 0.0 && Altitude_km <= 10.0))
			{
				if (Altitude_km > 10.0 && Altitude_km <= 72.0)
				{
					result.Pressure = 258.9787 * Math.Exp(-0.147 * (Altitude_km - 10.0));
				}
				else if (Altitude_km > 72.0 && Altitude_km <= 100.0)
				{
					result.Pressure = 0.0285170199 * Math.Exp(-0.155 * (Altitude_km - 72.0));
				}
				else
				{
					result.Pressure = 0.0;
				}
			}
			else
			{
				result.Pressure = 1018.8627 - 124.2954 * Altitude_km + 4.8307 * Altitude_km * Altitude_km;
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 10.0))
			{
				if (!(Altitude_km > 10.0 && Altitude_km <= 33.0))
				{
					if (!(Altitude_km > 33.0 && Altitude_km <= 47.0))
					{
						if (!(Altitude_km > 47.0 && Altitude_km <= 53.0))
						{
							if (Altitude_km > 53.0 && Altitude_km <= 80.0)
							{
								result.Temperature = 265.0 - 2.037 * (Altitude_km - 53.0);
							}
							else if (!(Altitude_km > 80.0 && Altitude_km <= 100.0))
							{
								result.Temperature = 0.0;
							}
							else
							{
								result.Temperature = 210.0;
							}
						}
						else
						{
							result.Temperature = 265.0;
						}
					}
					else
					{
						result.Temperature = 218.0 + 3.3571 * (Altitude_km - 33.0);
					}
				}
				else
				{
					result.Temperature = 218.0;
				}
			}
			else
			{
				result.Temperature = 272.7241 - 3.6217 * Altitude_km - 0.1759 * Altitude_km * Altitude_km;
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 10.0))
			{
				result.Rho = 0.0;
			}
			else
			{
				result.Rho = 3.4742 * Math.Exp(-0.2697 * Altitude_km - 0.03604 * Altitude_km * Altitude_km + 0.0004489 * Altitude_km * Altitude_km * Altitude_km);
			}
			break;
		case TAtmosphereType.atm_Summer_Subart:
			if (Altitude_km >= 0.0 && Altitude_km <= 10.0)
			{
				result.Pressure = 1008.0278 - 113.2494 * Altitude_km + 3.9408 * Altitude_km * Altitude_km;
			}
			else if (!(Altitude_km > 10.0 && Altitude_km <= 72.0))
			{
				if (Altitude_km > 72.0 && Altitude_km <= 100.0)
				{
					result.Pressure = 0.0458211532 * Math.Exp(-0.165 * (Altitude_km - 72.0));
				}
				else
				{
					result.Pressure = 0.0;
				}
			}
			else
			{
				result.Pressure = 269.6138 * Math.Exp(-0.14 * (Altitude_km - 10.0));
			}
			if (Altitude_km >= 0.0 && Altitude_km <= 10.0)
			{
				result.Temperature = 286.8374 - 4.7805 * Altitude_km - 0.1402 * Altitude_km * Altitude_km;
			}
			else if (Altitude_km > 10.0 && Altitude_km <= 23.0)
			{
				result.Temperature = 225.0;
			}
			else if (Altitude_km > 23.0 && Altitude_km <= 48.0)
			{
				result.Temperature = 225.0 * Math.Exp(0.008317 * (Altitude_km - 23.0));
			}
			else if (Altitude_km > 48.0 && Altitude_km <= 53.0)
			{
				result.Temperature = 277.0;
			}
			else if (!(Altitude_km > 53.0 && Altitude_km <= 79.0))
			{
				if (Altitude_km > 79.0 && Altitude_km <= 100.0)
				{
					result.Temperature = 171.0;
				}
				else
				{
					result.Temperature = 0.0;
				}
			}
			else
			{
				result.Temperature = 277.0 - 4.0769 * (Altitude_km - 53.0);
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 15.0))
			{
				result.Rho = 0.0;
			}
			else
			{
				result.Rho = 8.988 * Math.Exp(-0.3614 * Altitude_km - 0.005402 * Altitude_km * Altitude_km - 0.001955 * Altitude_km * Altitude_km * Altitude_km);
			}
			break;
		case TAtmosphereType.atm_Winter_Subart:
			if (Altitude_km >= 0.0 && Altitude_km <= 10.0)
			{
				result.Pressure = 1010.8828 - 122.2411 * Altitude_km + 4.554 * Altitude_km * Altitude_km;
			}
			else if (!(Altitude_km > 10.0 && Altitude_km <= 72.0))
			{
				if (Altitude_km > 72.0 && Altitude_km <= 100.0)
				{
					result.Pressure = 0.0268535481 * Math.Exp(-0.15 * (Altitude_km - 72.0));
				}
				else
				{
					result.Pressure = 0.0;
				}
			}
			else
			{
				result.Pressure = 243.8718 * Math.Exp(-0.147 * (Altitude_km - 10.0));
			}
			if (Altitude_km >= 0.0 && Altitude_km <= 8.5)
			{
				result.Temperature = 257.4345 + 2.3474 * Altitude_km - 1.5479 * Altitude_km * Altitude_km + 0.08473 * Altitude_km * Altitude_km * Altitude_km;
			}
			else if (Altitude_km > 8.5 && Altitude_km <= 30.0)
			{
				result.Temperature = 217.5;
			}
			else if (!(Altitude_km > 30.0 && Altitude_km <= 50.0))
			{
				if (!(Altitude_km > 50.0 && Altitude_km <= 54.0))
				{
					if (Altitude_km > 54.0 && Altitude_km <= 100.0)
					{
						result.Temperature = 260.0 - 1.667 * (Altitude_km - 54.0);
					}
					else
					{
						result.Temperature = 0.0;
					}
				}
				else
				{
					result.Temperature = 260.0;
				}
			}
			else
			{
				result.Temperature = 217.5 + 2.125 * (Altitude_km - 30.0);
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 10.0))
			{
				result.Rho = 0.0;
			}
			else
			{
				result.Rho = 1.2319 * Math.Exp(0.07481 * Altitude_km - 0.0981 * Altitude_km * Altitude_km + 0.00281 * Altitude_km * Altitude_km * Altitude_km);
			}
			break;
		case TAtmosphereType.atm_Annual_Tropic:
			if (Altitude_km >= 0.0 && Altitude_km <= 10.0)
			{
				result.Pressure = 1012.0306 - 109.0338 * Altitude_km + 3.6316 * Altitude_km * Altitude_km;
			}
			else if (!(Altitude_km > 10.0 && Altitude_km <= 72.0))
			{
				if (!(Altitude_km > 72.0 && Altitude_km <= 100.0))
				{
					result.Pressure = 0.0;
				}
				else
				{
					result.Pressure = 0.0313660825 * Math.Exp(-0.165 * (Altitude_km - 72.0));
				}
			}
			else
			{
				result.Pressure = 284.8526 * Math.Exp(-0.147 * (Altitude_km - 10.0));
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 17.0))
			{
				if (!(Altitude_km > 17.0 && Altitude_km <= 47.0))
				{
					if (!(Altitude_km > 47.0 && Altitude_km <= 52.0))
					{
						if (Altitude_km > 52.0 && Altitude_km <= 80.0)
						{
							result.Temperature = 270.0 - 3.0714 * (Altitude_km - 52.0);
						}
						else if (!(Altitude_km > 80.0 && Altitude_km <= 100.0))
						{
							result.Temperature = 0.0;
						}
						else
						{
							result.Temperature = 184.0;
						}
					}
					else
					{
						result.Temperature = 270.0;
					}
				}
				else
				{
					result.Temperature = 194.0 + 2.533 * (Altitude_km - 17.0);
				}
			}
			else
			{
				result.Temperature = 300.4222 - 6.3533 * Altitude_km + 0.005886 * Altitude_km * Altitude_km;
			}
			if (!(Altitude_km >= 0.0 && Altitude_km <= 15.0))
			{
				result.Rho = 0.0;
			}
			else
			{
				result.Rho = 19.6542 * Math.Exp(-0.2313 * Altitude_km - 0.1122 * Altitude_km * Altitude_km + 0.01351 * Altitude_km * Altitude_km * Altitude_km - 0.0005923 * Altitude_km * Altitude_km * Altitude_km * Altitude_km);
			}
			break;
		case TAtmosphereType.atm_ITU_R_Ref_Std:
			if (!(Altitude_km >= 0.0 && Altitude_km <= 11.0))
			{
				if (Altitude_km > 11.0 && Altitude_km <= 20.0)
				{
					result.Pressure = 226.3226 * Math.Exp(-34.163 * (Altitude_km - 11.0) / 216.65);
				}
				else if (Altitude_km > 20.0 && Altitude_km <= 32.0)
				{
					result.Pressure = 54.7498 * Math.Pow(216.65 / (216.65 + 1.0 * (Altitude_km - 20.0)), 34.163);
				}
				else if (Altitude_km > 32.0 && Altitude_km <= 47.0)
				{
					result.Pressure = 8.6804 * Math.Pow(228.65 / (228.65 + 2.8 * (Altitude_km - 32.0)), 12.201071428571428);
				}
				else if (Altitude_km > 47.0 && Altitude_km <= 51.0)
				{
					result.Pressure = 1.1091 * Math.Exp(-34.163 * (Altitude_km - 47.0) / 270.65);
				}
				else if (Altitude_km > 51.0 && Altitude_km <= 71.0)
				{
					result.Pressure = 0.6694 * Math.Pow(270.65 / (270.65 + -2.8 * (Altitude_km - 51.0)), -12.201071428571428);
				}
				else if (!(Altitude_km > 71.0 && Altitude_km <= 100.0))
				{
					result.Pressure = 0.0;
				}
				else
				{
					result.Pressure = 0.0396 * Math.Pow(214.65 / (214.65 + -2.0 * (Altitude_km - 71.0)), -17.0815);
				}
			}
			else
			{
				result.Pressure = 1013.25 * Math.Pow(288.15 / (288.15 + -6.5 * Altitude_km), -5.255846153846154);
			}
			if (Altitude_km >= 0.0 && Altitude_km <= 11.0)
			{
				result.Temperature = (double)num + -6.5 * Altitude_km;
			}
			else if (Altitude_km > 11.0 && Altitude_km <= 20.0)
			{
				result.Temperature = (double)num + -71.5;
			}
			else if (!(Altitude_km > 20.0 && Altitude_km <= 32.0))
			{
				if (Altitude_km > 32.0 && Altitude_km <= 47.0)
				{
					result.Temperature = (double)num - 59.5 + 2.8 * (Altitude_km - 32.0);
				}
				else if (Altitude_km > 47.0 && Altitude_km <= 51.0)
				{
					result.Temperature = (double)num - 17.5;
				}
				else if (!(Altitude_km > 51.0 && Altitude_km <= 71.0))
				{
					if (Altitude_km > 71.0 && Altitude_km <= 100.0)
					{
						result.Temperature = (double)num - 73.65 - 2.0 * (Altitude_km - 71.0);
					}
					else
					{
						result.Temperature = 0.0;
					}
				}
				else
				{
					result.Temperature = (double)num - 17.85 - 2.8 * (Altitude_km - 51.0);
				}
			}
			else
			{
				result.Temperature = (double)num - 71.5 + (Altitude_km - 20.0);
			}
			if (!(Altitude_km > 100.0))
			{
				result.Rho = 7.5 * Math.Exp(-0.5 * Altitude_km);
				if (result.Rho * result.Temperature / 216.7 / result.Pressure < 2E-06)
				{
					double num2 = 2E-06 * result.Pressure;
					result.Rho = num2 * 216.7 / result.Temperature;
				}
			}
			break;
		}
		return result;
	}

	internal static double RelativeHumidityToRho(double RH, double Temp)
	{
		double num = 6.11 * Math.Pow(10.0, 7.5 * Temp / (237.7 + Temp));
		return RH * num / 100.0 * 100.0 * 1000.0 / ((273.15 + Temp) * 461.5);
	}

	internal static double RefractivityN(double Temp, double Pressure, double RelativeHumidity)
	{
		double num = Temp + 273.15;
		double d = 25.22 * (Temp / num) - 5.31 * Math.Log(num / 273.15);
		double num2 = RelativeHumidity * 6.105 * Math.Exp(d) / 100.0;
		return 77.6 * Pressure / num + num2 * 373000.0 / (num * num);
	}

	internal static double RefractivityM(double Temp, double Pressure, double RelativeHumidity, double Altitude)
	{
		return RefractivityN(Temp, Pressure, RelativeHumidity) + 0.157 * Altitude;
	}

	internal static double Convert_N_to_M(double N, double Altitude)
	{
		return N + 0.157 * Altitude;
	}

	internal static TTimeOfDayType GetTOD(DateTime DT, ref Geodesic_Vincenty.TCoord Location, double ObserverHeight = 0.0)
	{
		return SunModule.GetTimeOfDay(null, DT.Year, DT.Month, DT.Day, DT.Hour, DT.Minute, DT.Second, UseCurrentScenarioTime: false, Location.Lat, Location.Lon, ObserverHeight);
	}

	internal static double BilinearInterpolation(double X, double Y, double Q_tl, double Q_tr, double Q_bl, double Q_br, double x_l, double y_t, double x_r, double y_b)
	{
		if (Math.Abs(x_r - x_l) <= 0.0)
		{
			if (Math.Abs(y_t - y_b) > 0.0)
			{
				return Q_bl * (y_t - Y) / (y_t - y_b) + Q_tl * (Y - y_b) / (y_t - y_b);
			}
			return Q_bl;
		}
		double num = Q_bl * (x_r - X) / (x_r - x_l) + Q_br * (X - x_l) / (x_r - x_l);
		double num2 = Q_tl * (x_r - X) / (x_r - x_l) + Q_tr * (X - x_l) / (x_r - x_l);
		return num * (y_t - Y) / (y_t - y_b) + num2 * (Y - y_b) / (y_t - y_b);
	}

	internal static bool smethod_2(TESARainItem V, ref double[] CDF)
	{
		CDF = new double[100];
		if (V.Pr6 == 0.0)
		{
			return false;
		}
		double num = V.Pr6 * (1.0 - Math.Exp(-0.0117 * V.MS / V.Pr6));
		double num2 = 1.11;
		double num3 = (V.MC + V.MS) / (22932.0 * num);
		double num4 = 31.5 * num3;
		double num5 = num2 * num3;
		CDF[0] = 0.0;
		int num6 = 1;
		do
		{
			double num7 = num2 + num4 * Math.Log((double)(100 - num6) / 100.0 / num);
			double num8 = Math.Log((double)(100 - num6) / 100.0 / num);
			CDF[num6] = (0.0 - num7 + Math.Sqrt(Math.Pow(num7, 2.0) - 4.0 * num5 * num8)) / (2.0 * num5);
			if (double.IsNaN(CDF[num6]) | (CDF[num6] < CDF[num6 - 1]))
			{
				CDF[num6] = CDF[num6 - 1];
			}
			num6++;
		}
		while (num6 <= 99);
		return true;
	}

	internal static bool InterpolatedRainfallRateCDF100(double Lat, double Lon, ref TESARainItem[,] ESARain, ref double[] CDF)
	{
		if (!((Information.UBound((Array)ESARain, 1) != 120) | (Information.UBound((Array)ESARain, 2) != 240)))
		{
			double num = Lon;
			if (num < 0.0)
			{
				num += 360.0;
			}
			int num2 = RadarModel.Floor(num / 1.5);
			int num3 = RadarModel.Floor(Lat / 1.5) + 60;
			double num4 = (double)num2 * 1.5;
			double num5 = (double)(num3 - 60) * 1.5;
			if (!((Math.Abs(num4 - num) < 1E-12) & (Math.Abs(num5 - Lat) < 1E-12)))
			{
				int num6;
				if (num3 == 120)
				{
					num3 = 119;
					num5 = 88.5;
					num6 = 120;
				}
				else
				{
					num6 = num3 + 1;
				}
				int num7;
				if (num2 == 240)
				{
					num2 = 239;
					num4 = 358.5;
					num7 = 240;
				}
				else
				{
					num7 = num2 + 1;
				}
				double x_r = (double)num7 * 1.5;
				double y_t = (double)(num6 - 60) * 1.5;
				if (num2 - num7 > 1 || num6 - num3 > 1)
				{
					throw new Exception("Non-neighbour interpolation");
				}
				TESARainItem v = default(TESARainItem);
				v.MC = BilinearInterpolation(num, Lat, ESARain[num6, num2].MC, ESARain[num6, num7].MC, ESARain[num3, num2].MC, ESARain[num3, num7].MC, num4, y_t, x_r, num5);
				v.MS = BilinearInterpolation(num, Lat, ESARain[num6, num2].MS, ESARain[num6, num7].MS, ESARain[num3, num2].MS, ESARain[num3, num7].MS, num4, y_t, x_r, num5);
				v.Pr6 = BilinearInterpolation(num, Lat, ESARain[num6, num2].Pr6, ESARain[num6, num7].Pr6, ESARain[num3, num2].Pr6, ESARain[num3, num7].Pr6, num4, y_t, x_r, num5);
				return smethod_2(v, ref CDF);
			}
			return smethod_2(ESARain[num3, num2], ref CDF);
		}
		throw new ArgumentOutOfRangeException("Wrong dimensions of ESARain array");
	}

	internal static double WindFromSeaState(int SeaState)
	{
		double result = 0.0;
		switch (SeaState)
		{
		case 0:
			result = 0.0;
			break;
		case 1:
			result = 3.131;
			break;
		case 2:
			result = 7.67;
			break;
		case 3:
			result = 13.099;
			break;
		case 4:
			result = 19.175;
			break;
		case 5:
			result = 25.246;
			break;
		case 6:
			result = 31.313;
			break;
		case 7:
			result = 38.351;
			break;
		case 8:
			result = 47.489;
			break;
		case 9:
			result = 54.237;
			break;
		}
		return result;
	}

	private static void Main()
	{
		Console.WriteLine(RefractivityM(24.5, 1020.3, 95.0, 2.0));
		Console.WriteLine(RefractivityM(25.9, 1018.91, 90.3, 14.0));
		Console.WriteLine(RefractivityM(26.2, 1018.85, 90.3, 15.0));
		Console.WriteLine(RefractivityM(26.4, 1009.21, 89.8, 99.0));
		Console.WriteLine(RefractivityM(26.6, 1000.0, 82.0, 178.0));
		Console.WriteLine(RefractivityM(21.6, 920.08, 76.4, 913.0));
		Console.WriteLine(RefractivityM(17.0, 850.0, 79.8, 1601.0));
	}

	public static WeatherProfile DefaultWeather()
	{
		return new WeatherProfile();
	}

	public static bool Visibility(Module_Unit.Unit observer, Module_Unit.Unit target, ref Scenario theScen)
	{
		float fractionUnderRain = Weather.get_WeatherAtThisTimeAndPlace(theScen, target.get_Latitude((GlobalVariables.BooleanObject)null), target.get_Longitude((GlobalVariables.BooleanObject)null), (int)Math.Round(target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null))).FractionUnderRain;
		if (fractionUnderRain > 0.9f)
		{
			int result;
			if (observer.IsShip)
			{
				result = 0;
			}
			else
			{
				if (!observer.IsSubmarine && !observer.IsFacility)
				{
					if (!target.IsShip && !target.IsSubmarine && !target.IsFacility)
					{
						if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 10972.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 10972.8f)
						{
							return true;
						}
						if (observer.CurrentAltitude_AGL >= 609.6f && observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f && target.CurrentAltitude_AGL >= 609.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f)
						{
							return true;
						}
						return false;
					}
					return false;
				}
				result = 0;
			}
			return (byte)result != 0;
		}
		if (fractionUnderRain > 0.8f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 10972.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 10972.8f)
			{
				return true;
			}
			if (observer.CurrentAltitude_AGL >= 609.6f && observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f && target.CurrentAltitude_AGL >= 609.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f)
			{
				return true;
			}
			if ((observer.CurrentAltitude_AGL < 2000f || target.CurrentAltitude_AGL < 2000f) && Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 304.8f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.7f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 10972.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 10972.8f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 9144f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 9144f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 762f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.6f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 9144f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 9144f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 8229.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 8229.6f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f)
			{
				if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 1524f)
				{
					return true;
				}
			}
			else if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 762f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.5f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 8534.4f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 8534.4f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 7620f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 7620f)
			{
				return true;
			}
			if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 762f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.4f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 2133.6f)
			{
				return true;
			}
			if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 762f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.3f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 2133.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 2133.6f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 609.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 609.6f)
			{
				return true;
			}
			if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 762f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.2f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 7010.4f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 7010.4f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 6096f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 6096f)
			{
				return true;
			}
			if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 1524f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0.1f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 4876.8f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 3048f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 3048f)
			{
				return true;
			}
			if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 1524f)
			{
				return true;
			}
			return false;
		}
		if (fractionUnderRain > 0f)
		{
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 2133.6f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) >= 2133.6f)
			{
				return true;
			}
			if (observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 1524f && target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) <= 1524f)
			{
				return true;
			}
			if (Math.Abs(observer.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null) - target.get_CurrentAltitude(DoSanityCheck: false, (GlobalVariables.BooleanObject)null)) < 1524f)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	static Weather()
	{
		Class72.smethod_20();
	}
}
